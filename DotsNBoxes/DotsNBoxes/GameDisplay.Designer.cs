namespace DotsNBoxes
{
    partial class GameDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameDisplay));
            this.pbDrawContainer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDrawContainer
            // 
            this.pbDrawContainer.Location = new System.Drawing.Point(0, 0);
            this.pbDrawContainer.Name = "pbDrawContainer";
            this.pbDrawContainer.Size = new System.Drawing.Size(794, 571);
            this.pbDrawContainer.TabIndex = 0;
            this.pbDrawContainer.TabStop = false;
            // 
            // GameDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 571);
            this.Controls.Add(this.pbDrawContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(810, 610);
            this.MinimumSize = new System.Drawing.Size(810, 610);
            this.Name = "GameDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameDisplay";
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDrawContainer;
    }
}