namespace facedetector
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cameraBox = new Emgu.CV.UI.ImageBox();
            this.start = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cameraBox
            // 
            this.cameraBox.Location = new System.Drawing.Point(27, 22);
            this.cameraBox.Name = "cameraBox";
            this.cameraBox.Size = new System.Drawing.Size(549, 405);
            this.cameraBox.TabIndex = 2;
            this.cameraBox.TabStop = false;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(655, 72);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(105, 57);
            this.start.TabIndex = 3;
            this.start.Text = "zacznij rozpoznawac twarz ";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(655, 240);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(105, 79);
            this.save.TabIndex = 4;
            this.save.Text = "zapisz twarz";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(655, 177);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(105, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(653, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "podaj elegancko imie";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.start);
            this.Controls.Add(this.cameraBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox cameraBox;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

