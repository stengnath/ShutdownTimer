using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShutdownTimer
{

  public partial class Form1 : Form
  {
    public DateTime? _EndDate = null;
    public DateTime? EndDate
    {
      get
      {
        return _EndDate;
      }
      set
      {
        _EndDate = value;
        if (_EndDate == null)
        {
          lblEndTime.Text = "";
          lblRemaining.Text = "";
        }
        else
        {
          lblEndTime.Text = _EndDate.ToString();
        }
      }
    }

    public DateTime? _startDate = null;
    public DateTime? StartDate
    {
      get
      {
        return _startDate;
      }
      set
      {
        _startDate = value;
        if (_startDate == null)
        {
          lblStartTime.Text = "";
        }
        else
        {
          lblStartTime.Text = _startDate.ToString();
        }
      }
    }
    private enum eProgramMode
    {
      none,
      shutdown,
      reboot
    }
    private eProgramMode _ProgramMode = eProgramMode.none;

    private eProgramMode ProgramMode
    {
      get
      {
        return _ProgramMode;
      }
      set
      {
        _ProgramMode = value;
        if (_ProgramMode == eProgramMode.none)
        {
          cmdAbort.Enabled = false;
          cmdStartShutdown.Enabled = true;
          cmdNeustartPlanen.Enabled = true;
          cmbAnzahl.Enabled = true;
          cmbEinheit.Enabled = true;
        }
        else
        {
          cmdAbort.Enabled = true;
          cmdStartShutdown.Enabled = false;
          cmdNeustartPlanen.Enabled = false;
          cmbAnzahl.Enabled = false;
          cmbEinheit.Enabled = false;
        }
      }
    }

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.trayicon.Visible = true;
      ContextMenuStrip traymenu = new ContextMenuStrip();
      traymenu.Items.Add("Anzeigen", null, new EventHandler(Anzeigen));
      traymenu.Items.Add("Timer Beenden", null, new EventHandler(Beenden));
      trayicon.ContextMenuStrip = traymenu;
      cmbAnzahl.SelectedIndex = 0;
      cmbEinheit.SelectedIndex = 1;
      StartDate = null;
      EndDate = null;

    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {

      if (e.CloseReason == CloseReason.TaskManagerClosing || e.CloseReason == CloseReason.WindowsShutDown)
      {
        Environment.Exit(0);
      }
      else
      {
        e.Cancel = true;
        HideWindow();
      }
    }

    private void HideWindow()
    {
      this.ShowInTaskbar = false;
      this.Visible = false;
    }
    private void ShowWindow()
    {
      this.ShowInTaskbar = true;
      this.Visible = true;
      this.BringToFront();
    }

    private void trayicon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      ShowWindow();
    }

    private void timerCheck_Tick(object sender, EventArgs e)
    {
      if (EndDate == null)
      {
        timerCheck.Stop();
        return;
      }
      if (DateTime.Now >= EndDate)
      {
        ProcessStartInfo psi = null;
        if (ProgramMode == eProgramMode.reboot)
        {
          psi = new ProcessStartInfo("shutdown", "/r /t 0");
        }
        else if (ProgramMode == eProgramMode.shutdown)
        {
          psi = new ProcessStartInfo("shutdown", "/s /t 0");
        }
        psi.CreateNoWindow = true;
        psi.UseShellExecute = false;
        Process.Start(psi);
      }
      else
      {
        var diff = EndDate.Value.Subtract(DateTime.Now);
        if (diff.TotalMinutes <= 10 && (Convert.ToInt64(diff.TotalMinutes) % 2) == 0 && (Convert.ToInt64(diff.TotalSeconds) % 60) == 0)
        {
          ShowPushInfo(getNotifcationText(diff));
        }
        lblRemaining.Text = $"{diff.Hours.ToString("F0")} Stunden {diff.Minutes.ToString("F0")} Minuten {diff.Seconds.ToString("F0")} Sekunden";
      }
    }

    private void ShowPushInfo(string Content)
    {
      Tulpep.NotificationWindow.PopupNotifier notification = new Tulpep.NotificationWindow.PopupNotifier();
      notification.TitleText = "ACHTUNG - ShutdownTimer meldet";
      notification.TitleFont = new Font("Tahoma", 12);
      notification.ContentText = Content;
      notification.ContentFont = new Font("Tahoma", 12);
      notification.Image = ShutdownTimer.Properties.Resources.shutdown;
      notification.ImageSize = new Size(70, 70);
      notification.BodyColor = Color.White;
      notification.Delay = 5000;
      notification.Popup();
    }

    private string getNotifcationText(TimeSpan diff)
    {
      if (ProgramMode == eProgramMode.reboot)
      {
        if (diff.TotalSeconds <= 60)
        {
          return $"Das System wird in {diff.TotalSeconds.ToString("F0")} Sekunden neu gestartet";
        }
        return $"Das System wird in {diff.TotalMinutes.ToString("F0")} Minuten neu gestartet";
      }
      else if (ProgramMode == eProgramMode.shutdown)
      {
        if (diff.TotalSeconds <= 60)
        {
          return $"Das System wird in {diff.TotalSeconds.ToString("F0")} Sekunden heruntergefahren";
        }
        return $"Das System wird in {diff.TotalMinutes.ToString("F0")} Minuten heruntergefahren";
      }
      return "";
    }
    private void cmdAbort_Click(object sender, EventArgs e)
    {
      StartDate = null;
      EndDate = null;
      timerCheck.Stop();
      ProgramMode = eProgramMode.none;
    }

    private void cmdStartShutdown_Click(object sender, EventArgs e)
    {

      EndDate = CalculateEndTime();
      if (EndDate != null)
      {
        ProgramMode = eProgramMode.shutdown;
        StartDate = DateTime.Now;
        timerCheck.Start();
        ShowPushInfo($"Herunterfahren wurde geplant.{Environment.NewLine}Shutdown wird ausgeführt um {EndDate.ToString()}");
        HideWindow();
      }

    }

    private void cmdNeustartPlanen_Click(object sender, EventArgs e)
    {
      EndDate = CalculateEndTime();
      if (EndDate != null)
      {
        ProgramMode = eProgramMode.reboot;
        StartDate = DateTime.Now;
        timerCheck.Start();
        ShowPushInfo($"Neustart wurde geplant.{Environment.NewLine}Reboot wird ausgeführt um {EndDate.ToString()}");
        HideWindow();
      }
    }

    private void trayicon_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {

      }
    }

    private void Beenden(object sender, EventArgs e)
    {
      trayicon.Visible = false;
      timerCheck.Stop();
      Environment.Exit(0);
    }

    private void Anzeigen(object sender, EventArgs e)
    {
      ShowWindow();
    }
    private DateTime? CalculateEndTime()
    {
      try
      {
        if (cmbEinheit.SelectedItem.ToString() == "Sekunden")
        {
          return DateTime.Now.AddSeconds(Convert.ToDouble(cmbAnzahl.Text.ToString()));
        }
        else if (cmbEinheit.SelectedItem.ToString() == "Minuten")
        {
          return DateTime.Now.AddMinutes(Convert.ToDouble(cmbAnzahl.Text.ToString()));
        }
        else if (cmbEinheit.SelectedItem.ToString() == "Stunden")
        {
          return DateTime.Now.AddHours(Convert.ToDouble(cmbAnzahl.Text.ToString()));
        }
      }
      catch (Exception)
      {
      }
      return null;
    }

    private void cmbEinheit_KeyUp(object sender, KeyEventArgs e)
    {
      e.Handled = true;
    }

    private void cmbEinheit_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = true;
    }

    private void cmbAnzahl_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (Char.IsNumber(e.KeyChar) == false)
      {
        e.Handled = true;
      }
    }
  }
}
