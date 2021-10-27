namespace ShutdownTimer
{
  partial class Form1
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.cmdStartShutdown = new System.Windows.Forms.Button();
      this.cmdNeustartPlanen = new System.Windows.Forms.Button();
      this.trayicon = new System.Windows.Forms.NotifyIcon(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.cmbEinheit = new System.Windows.Forms.ComboBox();
      this.cmbAnzahl = new System.Windows.Forms.ComboBox();
      this.cmdAbort = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.lblStartTime = new System.Windows.Forms.Label();
      this.timerCheck = new System.Windows.Forms.Timer(this.components);
      this.label3 = new System.Windows.Forms.Label();
      this.lblEndTime = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.lblRemaining = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // cmdStartShutdown
      // 
      this.cmdStartShutdown.BackColor = System.Drawing.Color.White;
      this.cmdStartShutdown.Location = new System.Drawing.Point(12, 167);
      this.cmdStartShutdown.Name = "cmdStartShutdown";
      this.cmdStartShutdown.Size = new System.Drawing.Size(191, 61);
      this.cmdStartShutdown.TabIndex = 0;
      this.cmdStartShutdown.Text = "Herunterfahren planen";
      this.cmdStartShutdown.UseVisualStyleBackColor = false;
      this.cmdStartShutdown.Click += new System.EventHandler(this.cmdStartShutdown_Click);
      // 
      // cmdNeustartPlanen
      // 
      this.cmdNeustartPlanen.BackColor = System.Drawing.Color.White;
      this.cmdNeustartPlanen.Location = new System.Drawing.Point(209, 167);
      this.cmdNeustartPlanen.Name = "cmdNeustartPlanen";
      this.cmdNeustartPlanen.Size = new System.Drawing.Size(161, 61);
      this.cmdNeustartPlanen.TabIndex = 1;
      this.cmdNeustartPlanen.Text = "Neustart planen";
      this.cmdNeustartPlanen.UseVisualStyleBackColor = false;
      this.cmdNeustartPlanen.Click += new System.EventHandler(this.cmdNeustartPlanen_Click);
      // 
      // trayicon
      // 
      this.trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayicon.Icon")));
      this.trayicon.Text = "Shutdown Timer";
      this.trayicon.Visible = true;
      this.trayicon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayicon_MouseClick);
      this.trayicon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayicon_MouseDoubleClick);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 23);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(134, 20);
      this.label1.TabIndex = 2;
      this.label1.Text = "Herunterfahren in";
      // 
      // cmbEinheit
      // 
      this.cmbEinheit.BackColor = System.Drawing.SystemColors.Window;
      this.cmbEinheit.FormattingEnabled = true;
      this.cmbEinheit.Items.AddRange(new object[] {
            "Sekunden",
            "Minuten",
            "Stunden"});
      this.cmbEinheit.Location = new System.Drawing.Point(376, 20);
      this.cmbEinheit.Name = "cmbEinheit";
      this.cmbEinheit.Size = new System.Drawing.Size(161, 28);
      this.cmbEinheit.TabIndex = 3;
      this.cmbEinheit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbEinheit_KeyPress);
      this.cmbEinheit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbEinheit_KeyUp);
      // 
      // cmbAnzahl
      // 
      this.cmbAnzahl.BackColor = System.Drawing.SystemColors.Window;
      this.cmbAnzahl.FormattingEnabled = true;
      this.cmbAnzahl.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "60"});
      this.cmbAnzahl.Location = new System.Drawing.Point(209, 20);
      this.cmbAnzahl.MaxLength = 2;
      this.cmbAnzahl.Name = "cmbAnzahl";
      this.cmbAnzahl.Size = new System.Drawing.Size(161, 28);
      this.cmbAnzahl.TabIndex = 4;
      this.cmbAnzahl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAnzahl_KeyPress);
      // 
      // cmdAbort
      // 
      this.cmdAbort.BackColor = System.Drawing.Color.White;
      this.cmdAbort.Enabled = false;
      this.cmdAbort.Location = new System.Drawing.Point(376, 167);
      this.cmdAbort.Name = "cmdAbort";
      this.cmdAbort.Size = new System.Drawing.Size(161, 61);
      this.cmdAbort.TabIndex = 5;
      this.cmdAbort.Text = "Abbrechen";
      this.cmdAbort.UseVisualStyleBackColor = false;
      this.cmdAbort.Click += new System.EventHandler(this.cmdAbort_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 61);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(165, 20);
      this.label2.TabIndex = 6;
      this.label2.Text = "Planung gestartet am ";
      // 
      // lblStartTime
      // 
      this.lblStartTime.AutoSize = true;
      this.lblStartTime.Location = new System.Drawing.Point(205, 61);
      this.lblStartTime.Name = "lblStartTime";
      this.lblStartTime.Size = new System.Drawing.Size(54, 20);
      this.lblStartTime.TabIndex = 7;
      this.lblStartTime.Text = "<Zeit>";
      // 
      // timerCheck
      // 
      this.timerCheck.Interval = 900;
      this.timerCheck.Tick += new System.EventHandler(this.timerCheck_Tick);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 92);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(138, 20);
      this.label3.TabIndex = 8;
      this.label3.Text = "Planung endet am";
      // 
      // lblEndTime
      // 
      this.lblEndTime.AutoSize = true;
      this.lblEndTime.Location = new System.Drawing.Point(205, 92);
      this.lblEndTime.Name = "lblEndTime";
      this.lblEndTime.Size = new System.Drawing.Size(54, 20);
      this.lblEndTime.TabIndex = 9;
      this.lblEndTime.Text = "<Zeit>";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 121);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(46, 20);
      this.label4.TabIndex = 10;
      this.label4.Text = "Noch";
      // 
      // lblRemaining
      // 
      this.lblRemaining.AutoSize = true;
      this.lblRemaining.Location = new System.Drawing.Point(205, 121);
      this.lblRemaining.Name = "lblRemaining";
      this.lblRemaining.Size = new System.Drawing.Size(103, 20);
      this.lblRemaining.TabIndex = 11;
      this.lblRemaining.Text = "<Remaining>";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(553, 244);
      this.Controls.Add(this.lblRemaining);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.lblEndTime);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.lblStartTime);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cmdAbort);
      this.Controls.Add(this.cmbAnzahl);
      this.Controls.Add(this.cmbEinheit);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cmdNeustartPlanen);
      this.Controls.Add(this.cmdStartShutdown);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "ShutdownTimer";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cmdStartShutdown;
    private System.Windows.Forms.Button cmdNeustartPlanen;
    private System.Windows.Forms.NotifyIcon trayicon;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cmbEinheit;
    private System.Windows.Forms.ComboBox cmbAnzahl;
    private System.Windows.Forms.Button cmdAbort;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lblStartTime;
    private System.Windows.Forms.Timer timerCheck;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lblEndTime;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label lblRemaining;
  }
}

