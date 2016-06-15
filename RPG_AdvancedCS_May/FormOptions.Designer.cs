namespace RPG_AdvancedCS_May
{
    partial class FormOptions
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
            this.CLBOX_Options = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // CLBOX_Options
            // 
            this.CLBOX_Options.FormattingEnabled = true;
            this.CLBOX_Options.Items.AddRange(new object[] {
            "Game Music",
            "Sound Effects",
            "Others",
            "Not set yet"});
            this.CLBOX_Options.Location = new System.Drawing.Point(12, 12);
            this.CLBOX_Options.Name = "CLBOX_Options";
            this.CLBOX_Options.Size = new System.Drawing.Size(258, 225);
            this.CLBOX_Options.TabIndex = 0;
            this.CLBOX_Options.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.CLBOX_Options);
            this.Name = "FormOptions";
            this.Text = "FormOptions";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CLBOX_Options;
    }
}