namespace AdamAsmaca
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        /// <param name="disposing">yönetilen kaynaklar silinmeli mi, değil mi?</param>
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
        /// Tasarımcı desteği için gerekli metot
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTime = new System.Windows.Forms.Label();
            this.txtGuess = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.txtFullGuess = new System.Windows.Forms.TextBox();
            this.btnGuess = new System.Windows.Forms.Button();
            this.btnEndGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Linen;
            this.lblTime.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTime.Location = new System.Drawing.Point(10, 10);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(255, 33);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "\"Kalan Süre: 90\"";
            this.lblTime.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // txtGuess
            // 
            this.txtGuess.BackColor = System.Drawing.Color.Ivory;
            this.txtGuess.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuess.Location = new System.Drawing.Point(15, 504);
            this.txtGuess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGuess.Name = "txtGuess";
            this.txtGuess.Size = new System.Drawing.Size(481, 36);
            this.txtGuess.TabIndex = 1;
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.RosyBrown;
            this.btnEnter.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEnter.Location = new System.Drawing.Point(514, 504);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(194, 38);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "Harf Tahmin";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // txtFullGuess
            // 
            this.txtFullGuess.BackColor = System.Drawing.Color.Ivory;
            this.txtFullGuess.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFullGuess.Location = new System.Drawing.Point(15, 555);
            this.txtFullGuess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFullGuess.Name = "txtFullGuess";
            this.txtFullGuess.Size = new System.Drawing.Size(481, 36);
            this.txtFullGuess.TabIndex = 3;
            // 
            // btnGuess
            // 
            this.btnGuess.BackColor = System.Drawing.Color.RosyBrown;
            this.btnGuess.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuess.Location = new System.Drawing.Point(514, 555);
            this.btnGuess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuess.Name = "btnGuess";
            this.btnGuess.Size = new System.Drawing.Size(194, 38);
            this.btnGuess.TabIndex = 4;
            this.btnGuess.Text = "Kelime Tahmin";
            this.btnGuess.UseVisualStyleBackColor = false;
            this.btnGuess.Click += new System.EventHandler(this.btnGuess_Click);
            // 
            // btnEndGame
            // 
            this.btnEndGame.BackColor = System.Drawing.Color.RosyBrown;
            this.btnEndGame.Font = new System.Drawing.Font("Cascadia Code", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEndGame.Location = new System.Drawing.Point(295, 676);
            this.btnEndGame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEndGame.Name = "btnEndGame";
            this.btnEndGame.Size = new System.Drawing.Size(201, 44);
            this.btnEndGame.TabIndex = 5;
            this.btnEndGame.Text = "Oyunu Bitir";
            this.btnEndGame.UseVisualStyleBackColor = false;
            this.btnEndGame.Click += new System.EventHandler(this.btnEndGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(786, 733);
            this.Controls.Add(this.btnEndGame);
            this.Controls.Add(this.btnGuess);
            this.Controls.Add(this.txtFullGuess);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtGuess);
            this.Controls.Add(this.lblTime);
            this.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Adam Asmaca";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtGuess;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox txtFullGuess;
        private System.Windows.Forms.Button btnGuess;
        private System.Windows.Forms.Button btnEndGame;
    }
}
