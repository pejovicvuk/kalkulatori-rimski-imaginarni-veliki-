namespace kalkulatori__rimski__imaginarni__veliki_
{
    partial class FormVeliki
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
            this.textBoxPrvi = new System.Windows.Forms.TextBox();
            this.textBoxRezultat = new System.Windows.Forms.TextBox();
            this.textBoxDrugi = new System.Windows.Forms.TextBox();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonDeljenje = new System.Windows.Forms.Button();
            this.buttonMnozenje = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxPrvi
            // 
            this.textBoxPrvi.Location = new System.Drawing.Point(12, 92);
            this.textBoxPrvi.Name = "textBoxPrvi";
            this.textBoxPrvi.Size = new System.Drawing.Size(760, 20);
            this.textBoxPrvi.TabIndex = 0;
            // 
            // textBoxRezultat
            // 
            this.textBoxRezultat.Location = new System.Drawing.Point(12, 325);
            this.textBoxRezultat.Name = "textBoxRezultat";
            this.textBoxRezultat.Size = new System.Drawing.Size(760, 20);
            this.textBoxRezultat.TabIndex = 1;
            // 
            // textBoxDrugi
            // 
            this.textBoxDrugi.Location = new System.Drawing.Point(12, 133);
            this.textBoxDrugi.Name = "textBoxDrugi";
            this.textBoxDrugi.Size = new System.Drawing.Size(760, 20);
            this.textBoxDrugi.TabIndex = 2;
            // 
            // buttonPlus
            // 
            this.buttonPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlus.Location = new System.Drawing.Point(151, 205);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(76, 55);
            this.buttonPlus.TabIndex = 3;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // buttonMinus
            // 
            this.buttonMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinus.Location = new System.Drawing.Point(272, 205);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(76, 55);
            this.buttonMinus.TabIndex = 4;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.buttonMinus_Click);
            // 
            // buttonDeljenje
            // 
            this.buttonDeljenje.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeljenje.Location = new System.Drawing.Point(518, 205);
            this.buttonDeljenje.Name = "buttonDeljenje";
            this.buttonDeljenje.Size = new System.Drawing.Size(76, 55);
            this.buttonDeljenje.TabIndex = 5;
            this.buttonDeljenje.Text = "/";
            this.buttonDeljenje.UseVisualStyleBackColor = true;
            this.buttonDeljenje.Click += new System.EventHandler(this.buttonDeljenje_Click);
            // 
            // buttonMnozenje
            // 
            this.buttonMnozenje.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMnozenje.Location = new System.Drawing.Point(389, 205);
            this.buttonMnozenje.Name = "buttonMnozenje";
            this.buttonMnozenje.Size = new System.Drawing.Size(76, 55);
            this.buttonMnozenje.TabIndex = 7;
            this.buttonMnozenje.Text = "*";
            this.buttonMnozenje.UseVisualStyleBackColor = true;
            this.buttonMnozenje.Click += new System.EventHandler(this.buttonMnozenje_Click);
            // 
            // FormVeliki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonMnozenje);
            this.Controls.Add(this.buttonDeljenje);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.buttonPlus);
            this.Controls.Add(this.textBoxDrugi);
            this.Controls.Add(this.textBoxRezultat);
            this.Controls.Add(this.textBoxPrvi);
            this.Name = "FormVeliki";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPrvi;
        private System.Windows.Forms.TextBox textBoxRezultat;
        private System.Windows.Forms.TextBox textBoxDrugi;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonDeljenje;
        private System.Windows.Forms.Button buttonMnozenje;
    }
}