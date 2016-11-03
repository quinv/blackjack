namespace Blackjack
{
    partial class Form1
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
            this.drawingPanel = new System.Windows.Forms.PictureBox();
            this.drawCard = new System.Windows.Forms.Button();
            this.ChangeGameState = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.drawingPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.DarkGreen;
            this.drawingPanel.Location = new System.Drawing.Point(0, 0);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(1600, 900);
            this.drawingPanel.TabIndex = 0;
            this.drawingPanel.TabStop = false;
            // 
            // drawCard
            // 
            this.drawCard.Font = new System.Drawing.Font("Kozuka Mincho Pro H", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawCard.Location = new System.Drawing.Point(1268, 620);
            this.drawCard.Name = "drawCard";
            this.drawCard.Size = new System.Drawing.Size(274, 94);
            this.drawCard.TabIndex = 1;
            this.drawCard.Text = "draw card";
            this.drawCard.UseVisualStyleBackColor = true;
            // 
            // stop
            // 
            this.ChangeGameState.Font = new System.Drawing.Font("Kozuka Mincho Pro H", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeGameState.Location = new System.Drawing.Point(1268, 746);
            this.ChangeGameState.Name = "stop";
            this.ChangeGameState.Size = new System.Drawing.Size(274, 94);
            this.ChangeGameState.TabIndex = 2;
            this.ChangeGameState.Text = "stop";
            this.ChangeGameState.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.ChangeGameState);
            this.Controls.Add(this.drawCard);
            this.Controls.Add(this.drawingPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.drawingPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox drawingPanel;
        public System.Windows.Forms.Button drawCard;
        public System.Windows.Forms.Button ChangeGameState;
    }
}

