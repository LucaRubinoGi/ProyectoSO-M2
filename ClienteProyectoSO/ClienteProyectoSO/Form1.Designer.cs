﻿namespace ClienteProyectoSO
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Class = new System.Windows.Forms.TextBox();
            this.Log = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LogIn = new System.Windows.Forms.TextBox();
            this.Desconectar = new System.Windows.Forms.Button();
            this.Conectar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Registrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Clase = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Consultar = new System.Windows.Forms.Button();
            this.HP = new System.Windows.Forms.RadioButton();
            this.Duracion = new System.Windows.Forms.RadioButton();
            this.Ganadores = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnInvitar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.InvitadoBox = new System.Windows.Forms.TextBox();
            this.listBoxConectados = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ChatListBox = new System.Windows.Forms.ListBox();
            this.ChatTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ChatEnviar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.Class);
            this.groupBox1.Controls.Add(this.Log);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LogIn);
            this.groupBox1.Controls.Add(this.Desconectar);
            this.groupBox1.Controls.Add(this.Conectar);
            this.groupBox1.Location = new System.Drawing.Point(468, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LogIn";
            // 
            // Class
            // 
            this.Class.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Class.ForeColor = System.Drawing.Color.Black;
            this.Class.Location = new System.Drawing.Point(82, 62);
            this.Class.Name = "Class";
            this.Class.Size = new System.Drawing.Size(143, 22);
            this.Class.TabIndex = 5;
            this.Class.TextChanged += new System.EventHandler(this.Class_TextChanged);
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(184, 90);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(125, 92);
            this.Log.TabIndex = 4;
            this.Log.Text = "Log In";
            this.Log.UseVisualStyleBackColor = true;
            this.Log.Click += new System.EventHandler(this.Log_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre ->";
            // 
            // LogIn
            // 
            this.LogIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogIn.ForeColor = System.Drawing.Color.Black;
            this.LogIn.Location = new System.Drawing.Point(82, 25);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(143, 22);
            this.LogIn.TabIndex = 2;
            this.LogIn.TextChanged += new System.EventHandler(this.LogIn_TextChanged);
            // 
            // Desconectar
            // 
            this.Desconectar.Location = new System.Drawing.Point(6, 139);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(172, 43);
            this.Desconectar.TabIndex = 1;
            this.Desconectar.Text = "Desconectar";
            this.Desconectar.UseVisualStyleBackColor = true;
            this.Desconectar.Click += new System.EventHandler(this.Desconectar_Click);
            // 
            // Conectar
            // 
            this.Conectar.Location = new System.Drawing.Point(6, 92);
            this.Conectar.Name = "Conectar";
            this.Conectar.Size = new System.Drawing.Size(172, 43);
            this.Conectar.TabIndex = 0;
            this.Conectar.Text = "Conectar";
            this.Conectar.UseVisualStyleBackColor = true;
            this.Conectar.Click += new System.EventHandler(this.Conectar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.Registrar);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Clase);
            this.groupBox2.Controls.Add(this.Nombre);
            this.groupBox2.Location = new System.Drawing.Point(13, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 191);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registro";
            // 
            // Registrar
            // 
            this.Registrar.Location = new System.Drawing.Point(164, 125);
            this.Registrar.Name = "Registrar";
            this.Registrar.Size = new System.Drawing.Size(172, 43);
            this.Registrar.TabIndex = 4;
            this.Registrar.Text = "Registrar";
            this.Registrar.UseVisualStyleBackColor = true;
            this.Registrar.Click += new System.EventHandler(this.Registrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Clase (1, 2 o 3) ->";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre ->";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Clase
            // 
            this.Clase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Clase.Location = new System.Drawing.Point(173, 87);
            this.Clase.Name = "Clase";
            this.Clase.Size = new System.Drawing.Size(143, 22);
            this.Clase.TabIndex = 1;
            this.Clase.TextChanged += new System.EventHandler(this.Clase_TextChanged);
            // 
            // Nombre
            // 
            this.Nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Nombre.ForeColor = System.Drawing.Color.Black;
            this.Nombre.Location = new System.Drawing.Point(173, 49);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(143, 22);
            this.Nombre.TabIndex = 0;
            this.Nombre.TextChanged += new System.EventHandler(this.Nombre_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox3.Controls.Add(this.Consultar);
            this.groupBox3.Controls.Add(this.HP);
            this.groupBox3.Controls.Add(this.Duracion);
            this.groupBox3.Controls.Add(this.Ganadores);
            this.groupBox3.Location = new System.Drawing.Point(12, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(439, 204);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consultas";
            // 
            // Consultar
            // 
            this.Consultar.Location = new System.Drawing.Point(35, 132);
            this.Consultar.Name = "Consultar";
            this.Consultar.Size = new System.Drawing.Size(172, 43);
            this.Consultar.TabIndex = 5;
            this.Consultar.Text = "Consultar";
            this.Consultar.UseVisualStyleBackColor = true;
            this.Consultar.Click += new System.EventHandler(this.Consultar_Click);
            // 
            // HP
            // 
            this.HP.AutoSize = true;
            this.HP.Location = new System.Drawing.Point(35, 92);
            this.HP.Name = "HP";
            this.HP.Size = new System.Drawing.Size(375, 20);
            this.HP.TabIndex = 2;
            this.HP.TabStop = true;
            this.HP.Text = "Dime los puntos de vida del ganador de la primera partida";
            this.HP.UseVisualStyleBackColor = true;
            this.HP.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // Duracion
            // 
            this.Duracion.AutoSize = true;
            this.Duracion.Location = new System.Drawing.Point(35, 66);
            this.Duracion.Name = "Duracion";
            this.Duracion.Size = new System.Drawing.Size(380, 20);
            this.Duracion.TabIndex = 1;
            this.Duracion.TabStop = true;
            this.Duracion.Text = "Dime la duración/nes de la/las partidas que ha jugado Alex";
            this.Duracion.UseVisualStyleBackColor = true;
            // 
            // Ganadores
            // 
            this.Ganadores.AutoSize = true;
            this.Ganadores.Location = new System.Drawing.Point(35, 40);
            this.Ganadores.Name = "Ganadores";
            this.Ganadores.Size = new System.Drawing.Size(338, 20);
            this.Ganadores.TabIndex = 0;
            this.Ganadores.TabStop = true;
            this.Ganadores.Text = "Dime los nombres de los ganadores de las partidas";
            this.Ganadores.UseVisualStyleBackColor = true;
            this.Ganadores.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox4.Controls.Add(this.btnInvitar);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.InvitadoBox);
            this.groupBox4.Controls.Add(this.listBoxConectados);
            this.groupBox4.Location = new System.Drawing.Point(468, 208);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(320, 217);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Jugadores Conectados";
            // 
            // btnInvitar
            // 
            this.btnInvitar.Location = new System.Drawing.Point(6, 157);
            this.btnInvitar.Name = "btnInvitar";
            this.btnInvitar.Size = new System.Drawing.Size(229, 43);
            this.btnInvitar.TabIndex = 6;
            this.btnInvitar.Text = "Invitar";
            this.btnInvitar.UseVisualStyleBackColor = true;
            this.btnInvitar.Click += new System.EventHandler(this.btnInvitar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nombre ->";
            // 
            // InvitadoBox
            // 
            this.InvitadoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InvitadoBox.ForeColor = System.Drawing.Color.Black;
            this.InvitadoBox.Location = new System.Drawing.Point(82, 129);
            this.InvitadoBox.Name = "InvitadoBox";
            this.InvitadoBox.Size = new System.Drawing.Size(153, 22);
            this.InvitadoBox.TabIndex = 1;
            // 
            // listBoxConectados
            // 
            this.listBoxConectados.FormattingEnabled = true;
            this.listBoxConectados.ItemHeight = 16;
            this.listBoxConectados.Location = new System.Drawing.Point(6, 21);
            this.listBoxConectados.Name = "listBoxConectados";
            this.listBoxConectados.Size = new System.Drawing.Size(229, 100);
            this.listBoxConectados.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox5.Controls.Add(this.ChatEnviar);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.ChatTextBox);
            this.groupBox5.Controls.Add(this.ChatListBox);
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(794, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(411, 414);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Chat";
            // 
            // ChatListBox
            // 
            this.ChatListBox.FormattingEnabled = true;
            this.ChatListBox.ItemHeight = 16;
            this.ChatListBox.Location = new System.Drawing.Point(6, 21);
            this.ChatListBox.Name = "ChatListBox";
            this.ChatListBox.Size = new System.Drawing.Size(399, 244);
            this.ChatListBox.TabIndex = 1;
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChatTextBox.ForeColor = System.Drawing.Color.Black;
            this.ChatTextBox.Location = new System.Drawing.Point(96, 296);
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.Size = new System.Drawing.Size(294, 22);
            this.ChatTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mensaje ->";
            // 
            // ChatEnviar
            // 
            this.ChatEnviar.Location = new System.Drawing.Point(96, 342);
            this.ChatEnviar.Name = "ChatEnviar";
            this.ChatEnviar.Size = new System.Drawing.Size(229, 43);
            this.ChatEnviar.TabIndex = 7;
            this.ChatEnviar.Text = "Enviar mensaje";
            this.ChatEnviar.UseVisualStyleBackColor = true;
            this.ChatEnviar.Click += new System.EventHandler(this.ChatEnviar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 450);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "  ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Desconectar;
        private System.Windows.Forms.Button Conectar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Clase;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Registrar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton HP;
        private System.Windows.Forms.RadioButton Duracion;
        private System.Windows.Forms.RadioButton Ganadores;
        private System.Windows.Forms.Button Consultar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LogIn;
        private System.Windows.Forms.Button Log;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox Class;
        private System.Windows.Forms.ListBox listBoxConectados;
        private System.Windows.Forms.Button btnInvitar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox InvitadoBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox ChatListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ChatTextBox;
        private System.Windows.Forms.Button ChatEnviar;
    }
}

