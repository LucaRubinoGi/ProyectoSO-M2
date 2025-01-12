using Microsoft.VisualBasic.Logging;
using System.Net;
using System.Net.Sockets;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TanquesForms.Properties;
using TanquesLib;

namespace TanquesForms
{
    public partial class Form1 : Form
    {
        public Random r = new Random();
        public Tank Tank1;
        public Tank Tank2;
        public int left_turn = 0;
        public int right_turn = 0;
        public int left_hull_moves = 3;
        public int right_hull_moves = 0;
        public int left_turret_moves = 0;
        public int right_turret_moves = 0;
        public int left_fire_moves = 0;
        public int right_fire_moves = 0;
        public string player;
        public string enemy;
        public int playern;
        public int npartida;
        public int clase1;
        public int clase2;

        string H_hull;
        string H_turret;
        string H_inertia;
        string H_pen;
        string H_damage;
        string H_armor;
        string H_HP;
        string H_range;
        string H_ammo;
        string H_recharge;

        Socket server;
        public static Form1 instance;
        public Label lbl1;

        public Form1(string player, string enemy, Socket server, int playern, int npartida, int clase1, int clase2)
        {
            InitializeComponent();
            this.player = player;
            this.enemy = enemy;
            this.server = server;
            this.playern = playern;
            this.npartida = npartida;
            this.clase1 = clase1;
            this.clase2 = clase2;

            instance = this;
            lbl1 = fight_info;

            //server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //server.Connect(ipep);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Tank_Left_HP.Text = "20";
            Tank_Right_HP.Text = "20";
            Turret_Turn_Left.Visible = false;
            Turret_Turn_Right.Visible = false;
            Fire.Visible = false;
            t2_Next.Visible = false;
            fight_info.Text = npartida + " " + player;
            if (clase1 == 1) { Tank1 = new Tank("E", "E", [5, 180], 3, 2, 1, 6, 5, 13, 20, 3, 1, 2, 1); }
            else if (clase1 == 2) { Tank1 = new Tank("E", "E", [5, 180], 2, 1, 0, 6, 7, 15, 25, 3, 2, 1, 1); }
            else { Tank1 = new Tank("E", "E", [5, 180], 5, 2, 2, 4, 3, 11, 15, 2, 3, 1, 1); }
            if (clase2 == 1) { Tank2 = new Tank("W", "W", [705, 180], 3, 2, 1, 6, 5, 13, 20, 3, 1, 2, 1); }
            else if (clase2 == 2) { Tank2 = new Tank("W", "W", [705, 180], 2, 1, 0, 6, 7, 15, 25, 3, 2, 1, 1); }
            else { Tank2 = new Tank("W", "W", [705, 180], 5, 2, 2, 4, 3, 11, 15, 2, 3, 1, 1); }

            if (playern == 1)
            {
                moveslbl.Text = "Hull/Turret moves: " + Tank1.GHull_Moves().ToString() + "/" + Tank1.GTurret_Moves().ToString();
                bulletslbl.Text = "current/max bullets: " + Tank1.GFire_Moves().ToString() + "/" + Tank1.GMax_Fire_Moves().ToString();
                inertialbl.Text = "inertia: " + Tank1.GInertia().ToString();
                Hit_or_Miss.Text = "PLAY";

                H_hull = Tank1.GMax_Hull_Moves().ToString();
                H_turret = Tank1.GMax_Turret_Moves().ToString();
                H_inertia = Tank1.GMax_Inertia().ToString();
                H_pen = Tank1.GPen().ToString();
                H_damage = Tank1.GDamage().ToString();
                H_armor = Tank1.GAC().ToString();
                H_HP = Tank1.GMax_HP().ToString();
                H_range = Tank1.GRange().ToString();
                H_ammo = Tank1.GMax_Fire_Moves().ToString();
                H_recharge = Tank1.GFire_Recharge().ToString();
            }
            else
            {
                Turn_Left.Visible = false;
                Turn_Right.Visible = false;
                Move_Forward.Visible = false;
                Next.Visible = false;
                moveslbl.Text = "Hull/Turret moves: " + Tank2.GHull_Moves().ToString() + "/" + Tank2.GTurret_Moves().ToString();
                bulletslbl.Text = "current/max bullets: " + Tank2.GFire_Moves().ToString() + "/" + Tank2.GMax_Fire_Moves().ToString();
                inertialbl.Text = "inertia: " + Tank2.GInertia().ToString();
                Hit_or_Miss.Text = "WAIT";

                H_hull = Tank2.GMax_Hull_Moves().ToString();
                H_turret = Tank2.GMax_Turret_Moves().ToString();
                H_inertia = Tank2.GMax_Inertia().ToString();
                H_pen = Tank2.GPen().ToString();
                H_damage = Tank2.GDamage().ToString();
                H_armor = Tank2.GAC().ToString();
                H_HP = Tank2.GMax_HP().ToString();
                H_range = Tank2.GRange().ToString();
                H_ammo = Tank2.GMax_Fire_Moves().ToString();
                H_recharge = Tank2.GFire_Recharge().ToString();
            }
        }

        public void update_text()
        {
            if (playern == 1)
            {
                if (Tank1.GHull_Moves() == 0) { Turn_Left.Visible = false; Turn_Right.Visible = false; Move_Forward.Visible = false; }
                if (Tank1.GTurret_Moves() == 0) { Turret_Turn_Left.Visible = false; Turret_Turn_Right.Visible = false; }
                if (Tank1.GFire_Moves() == 0) { Fire.Visible = false; }
                moveslbl.Text = "Hull/Turret moves: " + Tank1.GHull_Moves().ToString() + "/" + Tank1.GTurret_Moves().ToString();
                bulletslbl.Text = "current/max bullets: " + Tank1.GFire_Moves().ToString() + "/" + Tank1.GMax_Fire_Moves().ToString();
                inertialbl.Text = "inertia: " + Tank1.GInertia().ToString();
            }
            else if (playern == 2)
            {
                if (Tank2.GHull_Moves() == 0) { Turn_Left.Visible = false; Turn_Right.Visible = false; Move_Forward.Visible = false; }
                if (Tank2.GTurret_Moves() == 0) { Turret_Turn_Left.Visible = false; Turret_Turn_Right.Visible = false; }
                if (Tank2.GFire_Moves() == 0) { Fire.Visible = false; }
                moveslbl.Text = "Hull/Turret moves: " + Tank2.GHull_Moves().ToString() + "/" + Tank2.GTurret_Moves().ToString();
                bulletslbl.Text = "current/max bullets: " + Tank2.GFire_Moves().ToString() + "/" + Tank2.GMax_Fire_Moves().ToString();
                inertialbl.Text = "inertia: " + Tank2.GInertia().ToString();
            }

            fight_info.Text = npartida + " " + player;
            //+ " " + Tank1.GHull_Moves().ToString() + " " + Tank1.GTurret_Moves().ToString() + " " + Tank1.GFire_Moves().ToString() + " " +
            //    Tank2.GHull_Moves().ToString() + " " + Tank2.GTurret_Moves().ToString() + " " + Tank2.GFire_Moves().ToString() + " " +
            //    Tank1.GHP().ToString() + " " + Tank2.GHP().ToString();
        }
        public void Map_Paint(object sender, PaintEventArgs e)
        {
            Object Objtank1 = Properties.Resources.ResourceManager.GetObject("Tank" + Tank1.GSprite() + Tank1.GDirection() + Tank1.GTurret_Direction());
            Bitmap Bittank1 = (Bitmap)Objtank1;
            Image imagetank1 = Bittank1;

            PictureBox PTank1 = new PictureBox();
            PTank1.Size = new Size(40, 40);
            PTank1.BackgroundImage = imagetank1;
            PTank1.Location = new Point(Tank1.GLocationn(0), Tank1.GLocationn(1));
            Map.Controls.Add(PTank1);


            Object Objtank2 = Properties.Resources.ResourceManager.GetObject("Tank" + Tank2.GSprite() + Tank2.GDirection() + Tank2.GTurret_Direction());
            Bitmap Bittank2 = (Bitmap)Objtank2;
            Image imagetank2 = Bittank2;

            PictureBox PTank2 = new PictureBox();
            PTank2.Size = new Size(40, 40);
            PTank2.BackgroundImage = imagetank2;
            PTank2.Location = new Point(Tank2.GLocationn(0), Tank2.GLocationn(1));
            Map.Controls.Add(PTank2);
        }

        private void Turn_Left_Click(object sender, EventArgs e)
        {
            string mensaje = "30/L-H-" + playern.ToString() + "/" + enemy + "/" + npartida + "/0";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            Form2.instance.server.Send(msg);
        }

        private void Move_Forward_Click(object sender, EventArgs e)
        {
            string mensaje = "30/M-" + playern.ToString() + "/" + enemy + "/" + npartida + "/0";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            Form2.instance.server.Send(msg);
        }

        private void Turn_Right_Click(object sender, EventArgs e)
        {
            string mensaje = "30/R-H-" + playern.ToString() + "/" + enemy + "/" + npartida + "/0";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            Form2.instance.server.Send(msg);
        }

        private void Turret_Turn_Left_Click(object sender, EventArgs e)
        {
            string mensaje = "30/L-T-" + playern.ToString() + "/" + enemy + "/" + npartida + "/0";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            Form2.instance.server.Send(msg);
        }

        private void Turret_Turn_Right_Click(object sender, EventArgs e)
        {
            string mensaje = "30/R-T-" + playern.ToString() + "/" + enemy + "/" + npartida + "/0";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            Form2.instance.server.Send(msg);
        }

        private void Fire_Click(object sender, EventArgs e)
        {
            string Q = "Q";
            string mensaje = "";
            if (playern == 1)
            {
                Q = Tank1.Fire(Tank2);
                if (Q != "Q")
                {
                    Tank_Right_HP.Text = Tank2.GHP().ToString();
                    fight_info.Text = Q;
                    mensaje = "30/F-" + Tank2.GHP().ToString() + "-" + Q + "-" + playern.ToString() + "-" + Tank1.GFire_Moves().ToString() + "/" + enemy + "/" + npartida;
                }
            }
            else if (playern == 2)
            {
                Q = Tank2.Fire(Tank1);
                if (Q != "Q")
                {
                    Tank_Left_HP.Text = Tank1.GHP().ToString();
                    fight_info.Text = Q;
                    mensaje = "30/F-" + Tank1.GHP().ToString() + "-" + Q + "-" + playern.ToString() + "-" + Tank2.GFire_Moves().ToString() + "/" + enemy + "/" + npartida;
                }
            }
            if (Tank1.GHP() < 1) { mensaje = mensaje + "/2"; }
            else if (Tank2.GHP() < 1) { mensaje = mensaje + "/1"; }
            else { mensaje = mensaje + "/0"; }
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            Form2.instance.server.Send(msg);
        }

        private void Next_Click(object sender, EventArgs e)
        {
            Turn_Left.Visible = false;
            Turn_Right.Visible = false;
            Move_Forward.Visible = false;
            Turret_Turn_Left.Visible = true;
            Turret_Turn_Right.Visible = true;
            Fire.Visible = true;
            Next.Visible = false;
            t2_Next.Visible = true;
        }

        public void Next_1F()
        {
            if (playern == 1)
            {
                Turn_Left.Visible = true;
                Turn_Right.Visible = true;
                Move_Forward.Visible = true;
                Next.Visible = true;
                Hit_or_Miss.Text = "PLAY";
            }
            else { Hit_or_Miss.Text = "WAIT"; }
            Tank1.RHull_Moves();
            Tank1.UFire_Moves();
            Tank1.RTurret_Moves();
        }
        public void Next_2F()
        {
            if (playern == 2)
            {
                Turn_Left.Visible = true;
                Turn_Right.Visible = true;
                Move_Forward.Visible = true;
                Next.Visible = true;
                Hit_or_Miss.Text = "PLAY";
            }
            else { Hit_or_Miss.Text = "WAIT"; }
            Tank2.RHull_Moves();
            Tank2.UFire_Moves();
            Tank2.RTurret_Moves();
        }

        private void t2_Next_Click(object sender, EventArgs e)
        {
            Turret_Turn_Left.Visible = false;
            Turret_Turn_Right.Visible = false;
            Fire.Visible = false;
            t2_Next.Visible = false;

            string mensaje = "30/N-" + playern.ToString() + "/" + enemy + "/" + npartida + "/0";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            Form2.instance.server.Send(msg);
        }

        private void helpbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Moving the hull:\n" +
                "Each turn you have " + H_hull + " moves to either turn your hull Left/Right <L>/<R> or move forward <F>.\n" +
                "Each one consumes a hull move.\n" +
                "When you are done using the hull you can click <N> to go to the turret controls.\n\n" +
                "Using the turret:\n" +
                "Each turn you have " + H_turret + " moves to either turn your turret Left/Right <L>/<R>.\n" +
                "You also can shoot a number of times equal to your current ammo. You start the game with " + H_recharge +
                " bullets and regain another " + H_recharge + " every turn up to a maximum of " + H_ammo + ".\n" +
                "When you are done using the turret you can click <N> to end your turn.\n\n" +
                "Shooting:\n" +
                "If the enemy is within range, you add your pen <" + H_pen + "> to a random number from 1 to 20. " +
                "If the result is equal or greater than the enemy armor you deal damage.\n" +
                "The damage you deal is " + H_damage + " +-1.\n\n" +
                "Inertia:\n" +
                "Inertia increases your speed, increases your armor and decreases your penetration.\n" +
                "You loose 1 inertia when you turn your hull.\n\n" +
                "Range:\n" +
                "You can hit targets in a 90 degree cone area <triangular shape> up to a distance of tiles equal to double your range.\n" +
                "The cone is pointing to the direction of your turret.");
        }

        public void Final(string ganador)
        {
            MessageBox.Show("Ha ganado el jugador " + ganador + ".");
            this.Close();
        }

        public void TanqueClase(int clase)
        {
            if (clase == 1)
            {

            }
            if (clase == 2)
            {

            }
            if (clase == 3)
            {

            }

        }
    }
}
