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
using System.Threading;

namespace ClienteProyectoSO
{
    public partial class Form1 : Form
    {
        Socket server;
        int connect = 0;
        int login = 0;
        int partida = 0;
        Thread atender;
        
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

        public void PonLista()
        {

        }
        private static string LimpiarCaracteres(string input)
        {
            StringBuilder resultado = new StringBuilder();
            foreach (char c in input)
            {
                // Solo incluimos caracteres imprimibles (códigos ASCII entre 32 y 126)
                if (c >= 32 && c <= 126)
                {
                    resultado.Append(c);
                }
            }
            return resultado.ToString().Trim();  // Quitamos cualquier espacio adicional al inicio o fin
        }


        private void AtenderServidor()
        {
            while (true)
            {
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje;
                switch (codigo)
                {
                    case 1:
                        mensaje = trozos[1].Split('\0')[0];
                        MessageBox.Show("Resultado: " + mensaje);
                        break;
                    case 2:
                        StringBuilder nombresConcatenados = new StringBuilder();
                        for (int i = 1; i < trozos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(trozos[i]))
                            {
                                nombresConcatenados.Append(trozos[i]);
                                if (i < trozos.Length - 1)
                                    nombresConcatenados.Append(", ");  // Separador entre nombres
                            }
                        }
                        MessageBox.Show("Los nombres son: " + nombresConcatenados.ToString());
                        break;
                    case 3:
                        mensaje = trozos[1].Split('\0')[0];
                        MessageBox.Show("La duracion es: " + mensaje + " minutos");
                        break;
                    case 4:
                        mensaje = trozos[1].Split('\0')[0];
                        MessageBox.Show("El ganador de la partida tenia: " + mensaje + " puntos de vida.");
                        break;
                    case 5:
                        listBoxConectados.Invoke((MethodInvoker)delegate
                        {
                            listBoxConectados.Items.Clear();
                            for (int i = 2; i < trozos.Length; i++)  // empezamos en 1 para saltar el código
                            {
                                mensaje = trozos[i].Split('\0')[0];  // eliminamos el terminador de cadena si existe
                                if (!string.IsNullOrEmpty(mensaje))  // asegurarse de que no esté vacío
                                {
                                    listBoxConectados.Items.Add(mensaje);  // Agregar cada nombre al ListBox
                                }
                            }
                        });
                        break;
                    case 7: // Caso para la actualización de la lista de conectados al desconectar un cliente
                        listBoxConectados.Invoke((MethodInvoker)delegate
                        {
                            listBoxConectados.Items.Clear();
                            for (int i = 2; i < trozos.Length; i++)
                            {
                                mensaje = trozos[i].Split('\0')[0];
                                if (!string.IsNullOrEmpty(mensaje))
                                {
                                    listBoxConectados.Items.Add(mensaje);
                                }
                            }
                        });
                        break;
                    case 10:  // Recibir invitación
                        if (trozos.Length > 1)
                        {
                            
                            string nombreInvitador = trozos[1];

                           

                            // Limpiar caracteres no imprimibles y espacios en blanco
                            nombreInvitador = LimpiarCaracteres(nombreInvitador);

                            string nombreInvitado = LogIn.Text;

                            

                            // Mostramos el mensaje de invitación y obtenemos la respuesta
                            string textomb = $"Has sido invitado por {nombreInvitador}";
                            DialogResult result = MessageBox.Show(textomb, "Invitación", MessageBoxButtons.YesNo);

                            // Construimos la respuesta paso a paso
                            string respuesta;
                            if (result == DialogResult.Yes)
                                respuesta = "11/" + nombreInvitador + "/" + LogIn.Text + "/aceptado";
                            else
                                respuesta = "11/" + nombreInvitador + "/" + LogIn.Text + "/rechazado";

                          

                            // Convertimos a bytes y enviamos al servidor
                            byte[] respuestaMsg = Encoding.ASCII.GetBytes(respuesta);

                            Console.WriteLine("Mensaje enviado al servidor: " + respuesta);

                            server.Send(respuestaMsg);
                        }
                        else
                        {
                            MessageBox.Show("Error: el mensaje de invitación está incompleto.", "Error");
                        }
                        break;



                    case 12:  // Resultado de la invitación
                        if (Convert.ToInt32(trozos[1]) == 1)
                        {
                            partida = 1;
                        }
                        string resultado = trozos[2];
                        MessageBox.Show(resultado, "Resultado de la invitación");
                        break;

                    case 20:  // Mensaje de chat
                        if (trozos.Length > 2)
                        {
                            string remitente = trozos[1];  // Nombre del remitente
                            string mensajeRecibido = trozos[2];  // Mensaje de chat

                            // Añadir el mensaje al ListBox del chat
                            ChatListBox.Invoke((MethodInvoker)delegate
                            {
                                ChatListBox.Items.Add($"{remitente}: {mensajeRecibido}");
                            });
                        }
                        break;

                }


            }

        }
        private void Conectar_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("10.4.119.5");
            IPEndPoint ipep = new IPEndPoint(direc, 50005);


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

            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();

        }

        private void Desconectar_Click(object sender, EventArgs e)
        {
            if (connect == 1) 
            {
                string mensaje = "0/";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                // Nos desconectamos
                atender.Abort();
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
            
        }

        private void Class_TextChanged(object sender, EventArgs e)
        {
            TextBoxFilled();
        }

        private void LogIn_TextChanged(object sender, EventArgs e)
        {
            TextBoxFilled();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnInvitar_Click(object sender, EventArgs e)
        {
            if (connect == 1 && login == 1)
            {
                if (LogIn.Text != InvitadoBox.Text)
                {
                    string mensaje = $"10/{LogIn.Text}/{InvitadoBox.Text}";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else
                {
                    MessageBox.Show("No te puedes invitar a ti mismo");
                }
            }
            else
            {
                MessageBox.Show("No has hecho Log In");
            }
        }

        private void Nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clase_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChatEnviar_Click(object sender, EventArgs e)
        {
            if (connect == 1 && login == 1 && partida == 1)
            {
                if (!string.IsNullOrWhiteSpace(ChatTextBox.Text))
                {
                    string mensaje = $"20/{LogIn.Text}/{ChatTextBox.Text}";  // Código 20 para chat
                    byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    // Limpiar el TextBox después de enviar el mensaje
                    ChatTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("El mensaje no puede estar vacío.");
                }
            }
            else
            {
                MessageBox.Show("Debes estar conectado, haber iniciado sesión y estar en una partida para enviar mensajes.");
            }

        }
    }
}
