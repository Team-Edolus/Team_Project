namespace RPG_AdvancedCS_May
{
    partial class InitialScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialScreen));
            this.BTN_Play = new System.Windows.Forms.Button();
            this.LBL_GameTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTN_Play
            // 
            this.BTN_Play.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BTN_Play.Font = new System.Drawing.Font("Old English Text MT", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Play.Location = new System.Drawing.Point(88, 160);
            this.BTN_Play.Name = "BTN_Play";
            this.BTN_Play.Size = new System.Drawing.Size(134, 61);
            this.BTN_Play.TabIndex = 0;
            this.BTN_Play.Text = "Play";
            this.BTN_Play.UseVisualStyleBackColor = false;
            this.BTN_Play.Click += new System.EventHandler(this.BTN_Play_Click);
            // 
            // LBL_GameTitle
            // 
            this.LBL_GameTitle.AutoSize = true;
            this.LBL_GameTitle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LBL_GameTitle.Font = new System.Drawing.Font("Old English Text MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_GameTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LBL_GameTitle.Location = new System.Drawing.Point(40, 25);
            this.LBL_GameTitle.Name = "LBL_GameTitle";
            this.LBL_GameTitle.Size = new System.Drawing.Size(260, 44);
            this.LBL_GameTitle.TabIndex = 1;
            this.LBL_GameTitle.Text = "Monster World";
            // 
            // InitialScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::RPG_AdvancedCS_May.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(328, 294);
            this.Controls.Add(this.LBL_GameTitle);
            this.Controls.Add(this.BTN_Play);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InitialScreen";
            this.Text = "InitialScreen";
            this.Load += new System.EventHandler(this.InitialScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Play;
        private System.Windows.Forms.Label LBL_GameTitle;
    }
}