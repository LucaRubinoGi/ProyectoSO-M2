namespace TanquesForms
{
    partial class Form2
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
            groupBox1 = new GroupBox();
            Class = new TextBox();
            Log = new Button();
            label3 = new Label();
            LogIn = new TextBox();
            Desconectar = new Button();
            Conectar = new Button();
            groupBox2 = new GroupBox();
            Registrar = new Button();
            label2 = new Label();
            label1 = new Label();
            Clase = new TextBox();
            Nombre = new TextBox();
            groupBox3 = new GroupBox();
            dataGridView1 = new DataGridView();
            Consultar = new Button();
            UPartidas = new RadioButton();
            RPartida = new RadioButton();
            LJugadores = new RadioButton();
            groupBox4 = new GroupBox();
            btnInvitar = new Button();
            label4 = new Label();
            InvitadoBox = new TextBox();
            listBoxConectados = new ListBox();
            groupBox5 = new GroupBox();
            ChatEnviar = new Button();
            label5 = new Label();
            ChatTextBox = new TextBox();
            ChatListBox = new ListBox();
            dataGridView2 = new DataGridView();
            Column13 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(255, 192, 192);
            groupBox1.BackgroundImageLayout = ImageLayout.None;
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(Class);
            groupBox1.Controls.Add(Log);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(LogIn);
            groupBox1.Controls.Add(Desconectar);
            groupBox1.Controls.Add(Conectar);
            groupBox1.Location = new Point(468, 14);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(320, 239);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "LogIn";
            // 
            // Class
            // 
            Class.BorderStyle = BorderStyle.FixedSingle;
            Class.ForeColor = Color.Black;
            Class.Location = new Point(171, 77);
            Class.Margin = new Padding(3, 4, 3, 4);
            Class.Name = "Class";
            Class.Size = new Size(143, 27);
            Class.TabIndex = 5;
            Class.Text = "1";
            Class.TextChanged += Class_TextChanged;
            // 
            // Log
            // 
            Log.Location = new Point(184, 112);
            Log.Margin = new Padding(3, 4, 3, 4);
            Log.Name = "Log";
            Log.Size = new Size(125, 115);
            Log.TabIndex = 4;
            Log.Text = "Log In";
            Log.UseVisualStyleBackColor = true;
            Log.Click += Log_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 34);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 3;
            label3.Text = "Nombre ->";
            // 
            // LogIn
            // 
            LogIn.BorderStyle = BorderStyle.FixedSingle;
            LogIn.ForeColor = Color.Black;
            LogIn.Location = new Point(171, 28);
            LogIn.Margin = new Padding(3, 4, 3, 4);
            LogIn.Name = "LogIn";
            LogIn.Size = new Size(143, 27);
            LogIn.TabIndex = 2;
            LogIn.Text = "Luc";
            LogIn.TextChanged += LogIn_TextChanged;
            // 
            // Desconectar
            // 
            Desconectar.Location = new Point(6, 174);
            Desconectar.Margin = new Padding(3, 4, 3, 4);
            Desconectar.Name = "Desconectar";
            Desconectar.Size = new Size(172, 54);
            Desconectar.TabIndex = 1;
            Desconectar.Text = "Desconectar y darse de baja";
            Desconectar.UseVisualStyleBackColor = true;
            Desconectar.Click += Desconectar_Click;
            // 
            // Conectar
            // 
            Conectar.Location = new Point(6, 115);
            Conectar.Margin = new Padding(3, 4, 3, 4);
            Conectar.Name = "Conectar";
            Conectar.Size = new Size(172, 54);
            Conectar.TabIndex = 0;
            Conectar.Text = "Conectar";
            Conectar.UseVisualStyleBackColor = true;
            Conectar.Click += Conectar_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(128, 255, 255);
            groupBox2.Controls.Add(Registrar);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(Clase);
            groupBox2.Controls.Add(Nombre);
            groupBox2.Location = new Point(13, 14);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(438, 239);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Registro";
            // 
            // Registrar
            // 
            Registrar.Location = new Point(164, 156);
            Registrar.Margin = new Padding(3, 4, 3, 4);
            Registrar.Name = "Registrar";
            Registrar.Size = new Size(172, 54);
            Registrar.TabIndex = 4;
            Registrar.Text = "Registrar";
            Registrar.UseVisualStyleBackColor = true;
            Registrar.Click += Registrar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 112);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 3;
            label2.Text = "Clase (1, 2 o 3) ->";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 64);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 2;
            label1.Text = "Nombre ->";
            label1.Click += label1_Click;
            // 
            // Clase
            // 
            Clase.BorderStyle = BorderStyle.FixedSingle;
            Clase.Location = new Point(173, 109);
            Clase.Margin = new Padding(3, 4, 3, 4);
            Clase.Name = "Clase";
            Clase.Size = new Size(143, 27);
            Clase.TabIndex = 1;
            Clase.TextChanged += Clase_TextChanged;
            // 
            // Nombre
            // 
            Nombre.BorderStyle = BorderStyle.FixedSingle;
            Nombre.ForeColor = Color.Black;
            Nombre.Location = new Point(173, 61);
            Nombre.Margin = new Padding(3, 4, 3, 4);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(143, 27);
            Nombre.TabIndex = 0;
            Nombre.TextChanged += Nombre_TextChanged;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.FromArgb(255, 255, 128);
            groupBox3.Controls.Add(dataGridView1);
            groupBox3.Controls.Add(Consultar);
            groupBox3.Controls.Add(UPartidas);
            groupBox3.Controls.Add(RPartida);
            groupBox3.Controls.Add(LJugadores);
            groupBox3.Location = new Point(12, 276);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(722, 420);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Consultas";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 253);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(654, 178);
            dataGridView1.TabIndex = 6;
            // 
            // Consultar
            // 
            Consultar.Location = new Point(35, 165);
            Consultar.Margin = new Padding(3, 4, 3, 4);
            Consultar.Name = "Consultar";
            Consultar.Size = new Size(172, 54);
            Consultar.TabIndex = 5;
            Consultar.Text = "Consultar";
            Consultar.UseVisualStyleBackColor = true;
            Consultar.Click += Consultar_Click;
            // 
            // UPartidas
            // 
            UPartidas.AutoSize = true;
            UPartidas.Location = new Point(6, 114);
            UPartidas.Margin = new Padding(3, 4, 3, 4);
            UPartidas.Name = "UPartidas";
            UPartidas.Size = new Size(234, 24);
            UPartidas.TabIndex = 2;
            UPartidas.TabStop = true;
            UPartidas.Text = "Datos de las 5 últimas partidas";
            UPartidas.UseVisualStyleBackColor = true;
            UPartidas.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // RPartida
            // 
            RPartida.AutoSize = true;
            RPartida.Location = new Point(6, 82);
            RPartida.Margin = new Padding(3, 4, 3, 4);
            RPartida.Name = "RPartida";
            RPartida.Size = new Size(480, 24);
            RPartida.TabIndex = 1;
            RPartida.TabStop = true;
            RPartida.Text = "Resultado de partida con la persona que esta en el nombre invitado";
            RPartida.UseVisualStyleBackColor = true;
            // 
            // LJugadores
            // 
            LJugadores.AutoSize = true;
            LJugadores.Location = new Point(6, 50);
            LJugadores.Margin = new Padding(3, 4, 3, 4);
            LJugadores.Name = "LJugadores";
            LJugadores.Size = new Size(393, 24);
            LJugadores.TabIndex = 0;
            LJugadores.TabStop = true;
            LJugadores.Text = "Dime los nombres de los jugadores con que he jugado";
            LJugadores.UseVisualStyleBackColor = true;
            LJugadores.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.FromArgb(255, 192, 128);
            groupBox4.Controls.Add(btnInvitar);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(InvitadoBox);
            groupBox4.Controls.Add(listBoxConectados);
            groupBox4.Location = new Point(468, 260);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(320, 271);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Jugadores Conectados";
            // 
            // btnInvitar
            // 
            btnInvitar.Location = new Point(6, 196);
            btnInvitar.Margin = new Padding(3, 4, 3, 4);
            btnInvitar.Name = "btnInvitar";
            btnInvitar.Size = new Size(229, 54);
            btnInvitar.TabIndex = 6;
            btnInvitar.Text = "Invitar";
            btnInvitar.UseVisualStyleBackColor = true;
            btnInvitar.Click += btnInvitar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 164);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 5;
            label4.Text = "Nombre ->";
            // 
            // InvitadoBox
            // 
            InvitadoBox.BorderStyle = BorderStyle.FixedSingle;
            InvitadoBox.ForeColor = Color.Black;
            InvitadoBox.Location = new Point(82, 161);
            InvitadoBox.Margin = new Padding(3, 4, 3, 4);
            InvitadoBox.Name = "InvitadoBox";
            InvitadoBox.Size = new Size(153, 27);
            InvitadoBox.TabIndex = 1;
            InvitadoBox.Text = "Luca";
            // 
            // listBoxConectados
            // 
            listBoxConectados.FormattingEnabled = true;
            listBoxConectados.Location = new Point(6, 26);
            listBoxConectados.Margin = new Padding(3, 4, 3, 4);
            listBoxConectados.Name = "listBoxConectados";
            listBoxConectados.Size = new Size(229, 124);
            listBoxConectados.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.FromArgb(192, 0, 192);
            groupBox5.Controls.Add(ChatEnviar);
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(ChatTextBox);
            groupBox5.Controls.Add(ChatListBox);
            groupBox5.ForeColor = Color.Black;
            groupBox5.Location = new Point(794, 14);
            groupBox5.Margin = new Padding(3, 4, 3, 4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 4, 3, 4);
            groupBox5.Size = new Size(411, 518);
            groupBox5.TabIndex = 5;
            groupBox5.TabStop = false;
            groupBox5.Text = "Chat";
            // 
            // ChatEnviar
            // 
            ChatEnviar.Location = new Point(96, 428);
            ChatEnviar.Margin = new Padding(3, 4, 3, 4);
            ChatEnviar.Name = "ChatEnviar";
            ChatEnviar.Size = new Size(229, 54);
            ChatEnviar.TabIndex = 7;
            ChatEnviar.Text = "Enviar mensaje";
            ChatEnviar.UseVisualStyleBackColor = true;
            ChatEnviar.Click += ChatEnviar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 372);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 7;
            label5.Text = "Mensaje ->";
            // 
            // ChatTextBox
            // 
            ChatTextBox.BorderStyle = BorderStyle.FixedSingle;
            ChatTextBox.ForeColor = Color.Black;
            ChatTextBox.Location = new Point(96, 370);
            ChatTextBox.Margin = new Padding(3, 4, 3, 4);
            ChatTextBox.Name = "ChatTextBox";
            ChatTextBox.Size = new Size(294, 27);
            ChatTextBox.TabIndex = 7;
            // 
            // ChatListBox
            // 
            ChatListBox.FormattingEnabled = true;
            ChatListBox.Location = new Point(6, 26);
            ChatListBox.Margin = new Padding(3, 4, 3, 4);
            ChatListBox.Name = "ChatListBox";
            ChatListBox.Size = new Size(399, 304);
            ChatListBox.TabIndex = 1;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Column13, Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column11, Column12 });
            dataGridView2.Location = new Point(734, 529);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(471, 167);
            dataGridView2.TabIndex = 7;
            // 
            // Column13
            // 
            Column13.HeaderText = "Class ID";
            Column13.MinimumWidth = 6;
            Column13.Name = "Column13";
            Column13.ReadOnly = true;
            Column13.Width = 125;
            // 
            // Column1
            // 
            Column1.HeaderText = "Color";
            Column1.MinimumWidth = 4;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Hull moves";
            Column2.MinimumWidth = 4;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Turret moves";
            Column3.MinimumWidth = 4;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "Inertia";
            Column4.MinimumWidth = 4;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "Pen";
            Column5.MinimumWidth = 4;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 125;
            // 
            // Column6
            // 
            Column6.HeaderText = "Damage";
            Column6.MinimumWidth = 4;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 125;
            // 
            // Column7
            // 
            Column7.HeaderText = "Armor";
            Column7.MinimumWidth = 4;
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Width = 125;
            // 
            // Column8
            // 
            Column8.HeaderText = "Health";
            Column8.MinimumWidth = 4;
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            Column8.Width = 125;
            // 
            // Column9
            // 
            Column9.HeaderText = "Range";
            Column9.MinimumWidth = 4;
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            Column9.Width = 125;
            // 
            // Column11
            // 
            Column11.HeaderText = "Max ammo";
            Column11.MinimumWidth = 4;
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            Column11.Width = 125;
            // 
            // Column12
            // 
            Column12.HeaderText = "Ammo recharge";
            Column12.MinimumWidth = 4;
            Column12.Name = "Column12";
            Column12.ReadOnly = true;
            Column12.Width = 125;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 751);
            label6.Name = "label6";
            label6.Size = new Size(1095, 20);
            label6.TabIndex = 8;
            label6.Text = "ATENCION! PARA EL CORRECTO FUNCIONAMIENTO DE LA APLICACION SOLO SE PUEDE HACER LOG IN CON UN NOMBRE JUGAR UNA PARTIDA Y DESCONECTARSE";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 781);
            label7.Name = "label7";
            label7.Size = new Size(657, 20);
            label7.TabIndex = 9;
            label7.Text = "EN LA SIGUIENTE PARTIDA NINGUNO DE LOS DOS NOMBRES UTILIZADOS SE PODRÁN REPETIR!!!";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 84);
            label8.Name = "label8";
            label8.Size = new Size(126, 20);
            label8.TabIndex = 5;
            label8.Text = "Clase (1, 2 o 3) ->";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1343, 897);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dataGridView2);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form2";
            Text = "  ";
            Load += Form2_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.RadioButton UPartidas;
        private System.Windows.Forms.RadioButton RPartida;
        private System.Windows.Forms.RadioButton LJugadores;
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
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}

