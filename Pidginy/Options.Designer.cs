namespace Pidginy
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.XmlPathLabel = new System.Windows.Forms.Label();
            this.AvatarPathLabel = new System.Windows.Forms.Label();
            this.AvatarPath = new System.Windows.Forms.TextBox();
            this.XmlPath = new System.Windows.Forms.TextBox();
            this.SupportetProtocolsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // XmlPathLabel
            // 
            this.XmlPathLabel.AutoSize = true;
            this.XmlPathLabel.Location = new System.Drawing.Point(13, 13);
            this.XmlPathLabel.Name = "XmlPathLabel";
            this.XmlPathLabel.Size = new System.Drawing.Size(90, 17);
            this.XmlPathLabel.TabIndex = 0;
            this.XmlPathLabel.Text = "blist.xml Path";
            // 
            // AvatarPathLabel
            // 
            this.AvatarPathLabel.AutoSize = true;
            this.AvatarPathLabel.Location = new System.Drawing.Point(12, 48);
            this.AvatarPathLabel.Name = "AvatarPathLabel";
            this.AvatarPathLabel.Size = new System.Drawing.Size(120, 17);
            this.AvatarPathLabel.TabIndex = 1;
            this.AvatarPathLabel.Text = "Avatar-Icons Path";
            // 
            // AvatarPath
            // 
            this.AvatarPath.Location = new System.Drawing.Point(139, 48);
            this.AvatarPath.Name = "AvatarPath";
            this.AvatarPath.Size = new System.Drawing.Size(444, 22);
            this.AvatarPath.TabIndex = 2;
            // 
            // XmlPath
            // 
            this.XmlPath.Location = new System.Drawing.Point(139, 8);
            this.XmlPath.Name = "XmlPath";
            this.XmlPath.Size = new System.Drawing.Size(444, 22);
            this.XmlPath.TabIndex = 3;
            // 
            // SupportetProtocolsLabel
            // 
            this.SupportetProtocolsLabel.AutoSize = true;
            this.SupportetProtocolsLabel.Location = new System.Drawing.Point(16, 117);
            this.SupportetProtocolsLabel.Name = "SupportetProtocolsLabel";
            this.SupportetProtocolsLabel.Size = new System.Drawing.Size(276, 17);
            this.SupportetProtocolsLabel.TabIndex = 4;
            this.SupportetProtocolsLabel.Text = "Only XMPP/Jabber-Buddies are supported";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(595, 432);
            this.ControlBox = false;
            this.Controls.Add(this.SupportetProtocolsLabel);
            this.Controls.Add(this.XmlPath);
            this.Controls.Add(this.AvatarPath);
            this.Controls.Add(this.AvatarPathLabel);
            this.Controls.Add(this.XmlPathLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Options";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label XmlPathLabel;
        private System.Windows.Forms.Label AvatarPathLabel;
        private System.Windows.Forms.TextBox AvatarPath;
        private System.Windows.Forms.TextBox XmlPath;
        private System.Windows.Forms.Label SupportetProtocolsLabel;


    }
}