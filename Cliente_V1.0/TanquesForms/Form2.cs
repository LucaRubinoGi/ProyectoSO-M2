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
using Microsoft.VisualBasic.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using TanquesLib;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics.Eventing.Reader;

namespace TanquesForms
{
    public partial class Form2 : Form
    {
        int bindn = 50007;
        public Socket server;
        int connect = 0;
        int login = 0;
        int partida = 0;
        Thread atender;
        List<Form1> formularios = new List<Form1>();
        int[] indexV = new int[50];
        int indexi = 0;
        public static Form2 instance;
        string nombrelogin;
        string nombreinvitado;
        public Form2()
        {
            InitializeComponent();
            // Inicialmente deshabilitamos el botón
            LogIn.TextChanged += new EventHandler(LogIn_TextChanged);
            Class.TextChanged += new EventHandler(Class_TextChanged);
            Log.Enabled = false;

            instance = this;

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //List<int> aaa = new List<int>();
            //aaa.Add(1);
            //aaa.Add(2);
            //aaa.Add(3);
            //MessageBox.Show(aaa[2].ToString());

            Console.WriteLine("Cargando el formulario...");
            dataGridView1.Columns.Add("idpartida", "Match ID");
            dataGridView1.Columns.Add("ganador", "Ganador");
            dataGridView1.Columns.Add("perdedor", "Perdedor");
            dataGridView1.Columns.Add("fecha", "Fecha");
            dataGridView1.Columns.Add("duracion", "Duración");
            Console.WriteLine($"Columnas: {dataGridView1.Columns.Count}");

            dataGridView2.Rows.Add("1", "Blue", "3", "2", "1", "6", "5", "13", "20", "3", "2", "1");
            dataGridView2.Rows.Add("2", "Red", "2", "1", "0", "6", "7", "15", "25", "3", "1", "1");
            dataGridView2.Rows.Add("3", "Green", "5", "2", "2", "4", "3", "11", "15", "2", "3", "3");
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
                byte[] msg2 = new byte[512];
                try
                {
                    server.Receive(msg2);
                    //MessageBox.Show(Encoding.ASCII.GetString(msg2));
                    string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                    int codigo = Convert.ToInt32(trozos[0]);
                    string mensaje;
                    switch (codigo)
                    {
                        case 1:
                            mensaje = trozos[1].Split('\0')[0];
                            //MessageBox.Show("Resultado: " + mensaje);
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
                            this.Invoke((MethodInvoker)delegate
                            {
                                for (int i = 1; i < trozos.Length; i += 5) // Iterar en bloques de 5
                                {
                                    if (i + 4 < trozos.Length) // Verificar que haya suficientes datos para una partida
                                    {
                                        string idpartida = trozos[i].Split('\0')[0];
                                        string ganador = trozos[i + 1].Split('\0')[0];
                                        string perdedor = trozos[i + 2].Split('\0')[0];
                                        string fecha = trozos[i + 3].Split('\0')[0];
                                        string duracion = trozos[i + 4].Split('\0')[0];

                                        // Agregar fila al DataGridView
                                        dataGridView1.Rows.Add(idpartida, ganador, perdedor, fecha, duracion);
                                    }
                                }
                            });
                            break;
                        case 4:
                            this.Invoke((MethodInvoker)delegate
                            {
                                for (int i = 1; i < trozos.Length; i += 5) // Iterar en bloques de 5
                                {
                                    if (i + 4 < trozos.Length) // Verificar que haya suficientes datos para una partida
                                    {
                                        string idpartida = trozos[i];
                                        string ganador = trozos[i + 1];
                                        string perdedor = trozos[i + 2];
                                        string fecha = trozos[i + 3];
                                        string duracion = trozos[i + 4];

                                        // Agregar fila al DataGridView
                                        dataGridView1.Rows.Add(idpartida, ganador, perdedor, fecha, duracion);
                                    }
                                }
                            });
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
                                string npartida = trozos[2];
                                string clase1 = Convert.ToInt32(trozos[3]).ToString();



                                // Limpiar caracteres no imprimibles y espacios en blanco
                                nombreInvitador = LimpiarCaracteres(nombreInvitador);

                                string nombreInvitado = LogIn.Text;
                                string clase2 = Convert.ToInt32(Class.Text).ToString();
                                MessageBox.Show(clase2);


                                // Mostramos el mensaje de invitación y obtenemos la respuesta
                                string textomb = $"Has sido invitado por {nombreInvitador}";
                                DialogResult result = MessageBox.Show(textomb, "Invitación", MessageBoxButtons.YesNo);

                                // Construimos la respuesta paso a paso
                                string respuesta;
                                if (result == DialogResult.Yes)
                                {
                                    respuesta = "11/" + nombreInvitador + "/" + nombreInvitado + "/aceptado/" + npartida + "/" + clase1 + "/" + clase2;
                                    MessageBox.Show(respuesta);
                                }
                                else
                                {
                                    respuesta = "11/" + nombreInvitador + "/" + nombreInvitado + "/rechazado/" + npartida + "/" + clase1 + "/" + clase2;
                                }

                                // Convertimos a bytes y enviamos al servidor
                                byte[] respuestaMsg = Encoding.ASCII.GetBytes(respuesta);

                                Console.WriteLine("Mensaje enviado al servidor: " + respuesta);
                                MessageBox.Show(respuesta);

                                server.Send(respuestaMsg);
                            }
                            else
                            {
                                MessageBox.Show("Error: el mensaje de invitación está incompleto.", "Error");
                            }
                            break;
                        case 12:  // Resultado de la invitación
                            //MessageBox.Show(trozos[5] + " " + trozos[5].GetType().ToString());
                            //MessageBox.Show(Encoding.ASCII.GetString(msg2));
                            if (Convert.ToInt32(trozos[1]) == 1)
                            {
                                partida = 1;
                            }
                            string resultado = trozos[4];
                            //MessageBox.Show(resultado, "Resultado de la invitación");
                            if (partida == 1)
                            {

                                ThreadStart ts; Thread t;
                                int num = Convert.ToInt32(trozos[6]);
                                int clase1 = Convert.ToInt32(trozos[7]);
                                int clase2 = Convert.ToInt32(trozos[8]);
                                // Creamos un thread que simplemente pondrá en marcha el nuevo formulario.
                                // Enviamos al thread el numero de orden que servirá de identificador de conversación en los mensajes que se
                                // intercambien con el servidor
                                ts = delegate { atender_conversacion(trozos[2], trozos[3], num, trozos[5], clase1, clase2); };
                                t = new Thread(ts); t.Start();
                            }

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
                        case 30:
                            string[] tecla = trozos[1].Split('-');
                            int n = indexV[Convert.ToInt32(trozos[2])];
                            //MessageBox.Show(LogIn.Text + " serv:" +nn.ToString() + " client:" + n.ToString());
                            formularios[n].Invoke((MethodInvoker)delegate
                            {
                                if (tecla[0] == "M")
                                {
                                    if (Convert.ToInt32(tecla[1]) == 1)
                                    {
                                        formularios[n].Tank1.Move(formularios[n].Tank2);
                                    }
                                    else if (Convert.ToInt32(tecla[1]) == 2)
                                    {
                                        formularios[n].Tank2.Move(formularios[n].Tank1);
                                    }
                                }
                                else if (tecla[0] == "F")
                                {
                                    if (Convert.ToInt32(tecla[3]) == 1)
                                    {
                                        formularios[n].Tank_Right_HP.Text = tecla[1];
                                        formularios[n].Tank2.SHP(Convert.ToInt32(tecla[1]));
                                        formularios[n].Tank1.SFire_Moves(Convert.ToInt32(tecla[4]));
                                    }
                                    else if (Convert.ToInt32(tecla[3]) == 2)
                                    {
                                        formularios[n].Tank_Left_HP.Text = tecla[1];
                                        formularios[n].Tank1.SHP(Convert.ToInt32(tecla[1]));
                                        formularios[n].Tank2.SFire_Moves(Convert.ToInt32(tecla[4]));
                                    }
                                    formularios[n].Hit_or_Miss.Text = tecla[2];
                                }
                                else if (tecla[0] == "N")
                                {
                                    if (Convert.ToInt32(tecla[1]) == 1)
                                    {
                                        formularios[n].Next_2F();
                                    }
                                    else if (Convert.ToInt32(tecla[1]) == 2)
                                    {
                                        formularios[n].Next_1F();
                                    }
                                }
                                else if ((tecla[0] == "L") || (tecla[0] == "R"))
                                {
                                    if (Convert.ToInt32(tecla[2]) == 1)
                                    {
                                        formularios[n].Tank1.Turn(tecla[0], tecla[1]);
                                    }
                                    else if (Convert.ToInt32(tecla[2]) == 2)
                                    {
                                        formularios[n].Tank2.Turn(tecla[0], tecla[1]);
                                    }
                                }
                                formularios[n].Map.Controls.Clear();
                                formularios[n].Map.Invalidate();
                                formularios[n].update_text();
                            });
                            break;
                        case 31:  // Final Partida
                            int m = indexV[Convert.ToInt32(trozos[2])];
                            formularios[m].Invoke((MethodInvoker)delegate
                            {
                                formularios[m].Final(trozos[1]);
                            });

                            DateTime hora = DateTime.Now;
                            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            Random random = new Random();
                            int numeroAleatorio = random.Next(3, 21);
                            string env = "31/" + datetime + "/" + numeroAleatorio.ToString();
                            byte[] respuestaenv = Encoding.ASCII.GetBytes(env);
                            server.Send(respuestaenv);

                            break;
                        case 32:
                            string ganador = Convert.ToString(trozos[1]);
                            string perdedor = Convert.ToString(trozos[2]);
                            string nombres = "Los nombres son: " + ganador + " y " + perdedor;
                            MessageBox.Show(nombres);
                            break;
                    }
                }
                catch { }

            }

        }

        private void atender_conversacion(string player, string enemy, int num, string njugador, int clase1, int clase2)
        {
            Form1 f = new Form1(player, enemy, server, Convert.ToInt32(njugador), num, clase1, clase2);
            // añado el formulario a la tabla de hash
            formularios.Add(f);
            indexV[num] = indexi;
            indexi = indexi + 1;
            //MessageBox.Show(formularios.Count.ToString() + " " + indexi +" " + player);
            f.ShowDialog();

        }

        private void Conectar_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidols
            //r y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("10.4.119.5");
            IPEndPoint ipep = new IPEndPoint(direc, bindn);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                //MessageBox.Show("Conectado");
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
            if (connect == 1 && login == 1)
            {
                byte[] msg = System.Text.Encoding.ASCII.GetBytes($"0/{LogIn.Text}");
                server.Send(msg);

                // Nos desconectamos

                server.Shutdown(SocketShutdown.Both);
                server.Close();
                this.BackColor = Color.Gray;
                login = 0;
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
            if (LJugadores.Checked)
            {
                if (connect == 1)
                {
                    string mensaje = $"2/SELECT DISTINCT p.name FROM juego j JOIN players p ON p.playerid = j.winnerid OR p.playerid = j.loserid WHERE (j.winnerid = (SELECT playerid FROM players WHERE name = '{nombrelogin}' LIMIT 1) OR j.loserid = (SELECT playerid FROM players WHERE name = '{nombrelogin}' LIMIT 1)) AND p.name != '{nombrelogin}';";
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

            if (RPartida.Checked)
            {
                if (connect == 1)
                {
                    string mensaje = $"3/SELECT j.matchid, p1.name AS winner, p2.name AS loser, j.datetimefinish, j.duration FROM juego j JOIN players p1 ON p1.playerid = j.winnerid JOIN players p2 ON p2.playerid = j.loserid WHERE (p1.name = '{nombrelogin}' AND p2.name = '{InvitadoBox.Text}') OR (p2.name = '{nombrelogin}' AND p1.name = '{InvitadoBox.Text}');";
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

            if (UPartidas.Checked)
            {
                if (connect == 1)
                {
                    string mensaje = $"4/SELECT j.matchid, p1.name AS winner, p2.name AS loser, j.datetimefinish, j.duration FROM juego j JOIN players p1 ON p1.playerid = j.winnerid JOIN players p2 ON p2.playerid = j.loserid ORDER BY j.datetimefinish DESC LIMIT 5;";
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
                            nombrelogin = LogIn.Text;
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
                    string mensaje = $"10/{nombrelogin}/{InvitadoBox.Text}/{Class.Text}";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    nombreinvitado = InvitadoBox.Text;
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
            if (connect == 1 && login == 1)
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
                MessageBox.Show("Debes estar conectado y haber iniciado sesión para enviar mensajes.");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
