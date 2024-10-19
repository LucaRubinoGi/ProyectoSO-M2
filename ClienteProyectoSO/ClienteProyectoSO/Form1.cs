using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClienteProyectoSO
{
    public partial class Form1 : Form
    {
        Socket server;
        int connect = 0;
        int login = 0;
        
        public Form1()
        {
            InitializeComponent();


            // Inicialmente deshabilitamos el botón
            LogIn.TextChanged += new EventHandler(LogIn_TextChanged);
            Class.TextChanged += new EventHandler(Class_TextChanged);
            Log.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Conectar_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9030);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");
                connect = 1;

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
        }

        private void Desconectar_Click(object sender, EventArgs e)
        {
            if (connect == 1) 
            {
                string mensaje = "0/";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                // Nos desconectamos
                this.BackColor = Color.Gray;
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ya estas desconectado del servidor");
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            if (connect == 1)
            {
                try
                {
                    if (Convert.ToInt32(Clase.Text) == 1 || Convert.ToInt32(Clase.Text) == 2 || Convert.ToInt32(Clase.Text) == 3)
                    {
                        string mensaje = $"1/INSERT INTO players (name, class) VALUES ('{Nombre.Text}', {Clase.Text});";
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        //Recibimos la respuesta del servidor
                        byte[] msg2 = new byte[80];
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                        MessageBox.Show("Resultado: " + mensaje);
                    }
                    else
                    {
                        MessageBox.Show("Introduce un 1,2 o 3");
                    }
                }
                catch 
                {
                    MessageBox.Show("Introduce un 1,2 o 3");
                }
            }
            else
            {
                MessageBox.Show("No estas conectado al servidor");
            }
        }
        private void TextBoxFilled()
        {
            // Si ambos TextBox tienen texto, habilitamos el botón, de lo contrario lo deshabilitamos
            if (!string.IsNullOrWhiteSpace(LogIn.Text) && !string.IsNullOrWhiteSpace(Class.Text))
            {
                Log.Enabled = true; // Habilitamos el botón si ambos campos están rellenados
            }
            else
            {
                Log.Enabled = false; // Deshabilitamos el botón si alguno está vacío
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            if (Ganadores.Checked)
            {
                if (connect == 1)
                {
                    string mensaje = "2/SELECT players.name FROM players, juego WHERE players.playerid = juego.winnerid;";
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show("Los nombres son: " + mensaje);

                }
                else
                {
                    MessageBox.Show("No estas conectado al servidor");
                }
                
            }

            if (Duracion.Checked)
            {
                if (connect == 1)
                {
                    string mensaje = "3/SELECT juego.duration FROM juego JOIN players ON players.playerid = juego.loserid WHERE players.name = \"Alex\";";
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show("La duracion es: " + mensaje + " minutos");

                }
                else
                {
                    MessageBox.Show("No estas conectado al servidor");
                }
                
            }

            if (HP.Checked)
            {
                if (connect == 1)
                {
                    string mensaje = "4/SELECT clase.hp FROM juego JOIN players ON juego.winnerid = players.playerid JOIN clase ON players.class = clase.classid WHERE juego.matchid = 1 LIMIT 1;";
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show("El ganador de la partida tenia: " + mensaje + " puntos de vida.");

                }
                else
                {
                    MessageBox.Show("No estas conectado al servidor");
                }

                
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Log_Click(object sender, EventArgs e)
        {
            if (login == 0)
            {
                if (connect == 1)
                {
                    try
                    {


                        if (Convert.ToInt32(Class.Text) == 1 || Convert.ToInt32(Class.Text) == 2 || Convert.ToInt32(Class.Text) == 3)
                        {
                            string mensaje = $"5/{LogIn.Text}/{Class.Text}";

                            // Enviamos al servidor el nombre tecleado
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                            login = 1;

                            //Recibimos la respuesta del servidor
                            byte[] msg2 = new byte[80];
                            server.Receive(msg2);
                            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                            MessageBox.Show(mensaje);
                        }
                        else
                        {
                            MessageBox.Show("Introduce un 1, 2 o 3");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Introduce un 1,2 o 3");
                    }
                }
                else
                {
                    MessageBox.Show("No estas conectado al servidor");
                }
            }
            else
            {
                MessageBox.Show("Ya has hecho Log In");
            }
        }

        private void Conectados_Click(object sender, EventArgs e)
        {
            if (connect == 1)
            {
                string mensaje = "6/";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show(mensaje);

            }
            else
            {
                MessageBox.Show("No estas conectado al servidor");
            }
        }

        private void Class_TextChanged(object sender, EventArgs e)
        {
            TextBoxFilled();
        }

        private void LogIn_TextChanged(object sender, EventArgs e)
        {
            TextBoxFilled();
        }
    }
}
