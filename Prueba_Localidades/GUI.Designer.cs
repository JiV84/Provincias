namespace Prueba_Provincias
{
    partial class GUI
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.AnadirProvincia = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(220, 147);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(290, 30);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(215, 147);
            this.listBox2.TabIndex = 1;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Provincias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Localidades";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Borrar Provincia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(430, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Conectar a DB";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sin conexión";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(457, 203);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 49);
            this.button3.TabIndex = 7;
            this.button3.Text = "Configurar Conexion";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AnadirProvincia
            // 
            this.AnadirProvincia.Location = new System.Drawing.Point(16, 229);
            this.AnadirProvincia.Name = "AnadirProvincia";
            this.AnadirProvincia.Size = new System.Drawing.Size(75, 40);
            this.AnadirProvincia.TabIndex = 8;
            this.AnadirProvincia.Text = "Añadir Provincia";
            this.AnadirProvincia.UseVisualStyleBackColor = true;
            this.AnadirProvincia.Click += new System.EventHandler(this.AnadirProvincia_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 240);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(215, 240);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(72, 20);
            this.textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(97, 336);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(136, 20);
            this.textBox3.TabIndex = 12;
            this.textBox3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox3_MouseClick);
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Filtrar Provincias";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(212, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Código Provincia";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(430, 333);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Desconectar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(16, 286);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 36);
            this.button5.TabIndex = 17;
            this.button5.Text = "Buscar Localidad";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(97, 289);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(136, 20);
            this.textBox4.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 19;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(318, 240);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(70, 20);
            this.textBox5.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(315, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Código Postal";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 366);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.AnadirProvincia);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Name = "GUI";
            this.Text = "Provincias y Localidades";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button AnadirProvincia;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
    }
}

