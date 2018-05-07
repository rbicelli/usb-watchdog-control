/*
 * Created by SharpDevelop.
 * User: Riccardo Bicelli <r.bicelli@gmail.com>
 * Date: 07/05/2018
 * Time: 11:59
 * 
 */
namespace USBWatchdogControl
{
	partial class FormOptions
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label lblTimeout;
		private System.Windows.Forms.NumericUpDown nUDHeartbeatTimeout;
		private System.Windows.Forms.Label lblSeconds;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.CheckBox chkAutostart;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblTimeout = new System.Windows.Forms.Label();
			this.nUDHeartbeatTimeout = new System.Windows.Forms.NumericUpDown();
			this.lblSeconds = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.chkAutostart = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.nUDHeartbeatTimeout)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTimeout
			// 
			this.lblTimeout.Location = new System.Drawing.Point(15, 16);
			this.lblTimeout.Name = "lblTimeout";
			this.lblTimeout.Size = new System.Drawing.Size(99, 18);
			this.lblTimeout.TabIndex = 0;
			this.lblTimeout.Text = "Heartbeat Timeout:";
			// 
			// nUDHeartbeatTimeout
			// 
			this.nUDHeartbeatTimeout.Location = new System.Drawing.Point(120, 16);
			this.nUDHeartbeatTimeout.Maximum = new decimal(new int[] {
			1280,
			0,
			0,
			0});
			this.nUDHeartbeatTimeout.Minimum = new decimal(new int[] {
			30,
			0,
			0,
			0});
			this.nUDHeartbeatTimeout.Name = "nUDHeartbeatTimeout";
			this.nUDHeartbeatTimeout.Size = new System.Drawing.Size(54, 20);
			this.nUDHeartbeatTimeout.TabIndex = 1;
			this.nUDHeartbeatTimeout.Value = new decimal(new int[] {
			30,
			0,
			0,
			0});
			// 
			// lblSeconds
			// 
			this.lblSeconds.Location = new System.Drawing.Point(182, 18);
			this.lblSeconds.Name = "lblSeconds";
			this.lblSeconds.Size = new System.Drawing.Size(66, 18);
			this.lblSeconds.TabIndex = 2;
			this.lblSeconds.Text = "Seconds";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(110, 86);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(190, 86);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// chkAutostart
			// 
			this.chkAutostart.Location = new System.Drawing.Point(19, 41);
			this.chkAutostart.Name = "chkAutostart";
			this.chkAutostart.Size = new System.Drawing.Size(155, 24);
			this.chkAutostart.TabIndex = 5;
			this.chkAutostart.Text = "Autostart";
			this.chkAutostart.UseVisualStyleBackColor = true;
			// 
			// FormOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(273, 119);
			this.Controls.Add(this.chkAutostart);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lblSeconds);
			this.Controls.Add(this.nUDHeartbeatTimeout);
			this.Controls.Add(this.lblTimeout);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormOptions";
			this.Text = "Options";
			((System.ComponentModel.ISupportInitialize)(this.nUDHeartbeatTimeout)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
