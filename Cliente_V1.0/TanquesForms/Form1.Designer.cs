namespace TanquesForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Map = new Panel();
            Turn_Left = new Button();
            Move_Forward = new Button();
            Turn_Right = new Button();
            Turret_Turn_Left = new Button();
            Fire = new Button();
            Turret_Turn_Right = new Button();
            Tank_Left_HP = new Label();
            Tank_Right_HP = new Label();
            Next = new Button();
            t2_Next = new Button();
            fight_info = new Label();
            Hit_or_Miss = new Label();
            moveslbl = new Label();
            bulletslbl = new Label();
            inertialbl = new Label();
            helpbtn = new Button();
            SuspendLayout();
            // 
            // Map
            // 
            Map.BackgroundImage = Properties.Resources.grassland_cropped;
            Map.Location = new Point(25, 25);
            Map.Name = "Map";
            Map.Size = new Size(750, 400);
            Map.TabIndex = 0;
            Map.Paint += Map_Paint;
            // 
            // Turn_Left
            // 
            Turn_Left.FlatStyle = FlatStyle.Flat;
            Turn_Left.Location = new Point(25, 450);
            Turn_Left.Name = "Turn_Left";
            Turn_Left.Size = new Size(50, 50);
            Turn_Left.TabIndex = 1;
            Turn_Left.Text = "L";
            Turn_Left.UseVisualStyleBackColor = true;
            Turn_Left.Click += Turn_Left_Click;
            // 
            // Move_Forward
            // 
            Move_Forward.FlatStyle = FlatStyle.Flat;
            Move_Forward.Location = new Point(100, 450);
            Move_Forward.Name = "Move_Forward";
            Move_Forward.Size = new Size(50, 50);
            Move_Forward.TabIndex = 2;
            Move_Forward.Text = "F";
            Move_Forward.UseVisualStyleBackColor = true;
            Move_Forward.Click += Move_Forward_Click;
            // 
            // Turn_Right
            // 
            Turn_Right.FlatStyle = FlatStyle.Flat;
            Turn_Right.Location = new Point(175, 450);
            Turn_Right.Name = "Turn_Right";
            Turn_Right.Size = new Size(50, 50);
            Turn_Right.TabIndex = 3;
            Turn_Right.Text = "R";
            Turn_Right.UseVisualStyleBackColor = true;
            Turn_Right.Click += Turn_Right_Click;
            // 
            // Turret_Turn_Left
            // 
            Turret_Turn_Left.FlatStyle = FlatStyle.Flat;
            Turret_Turn_Left.Location = new Point(25, 450);
            Turret_Turn_Left.Name = "Turret_Turn_Left";
            Turret_Turn_Left.Size = new Size(50, 50);
            Turret_Turn_Left.TabIndex = 4;
            Turret_Turn_Left.Text = "TL";
            Turret_Turn_Left.UseVisualStyleBackColor = true;
            Turret_Turn_Left.Click += Turret_Turn_Left_Click;
            // 
            // Fire
            // 
            Fire.FlatStyle = FlatStyle.Flat;
            Fire.Location = new Point(100, 450);
            Fire.Name = "Fire";
            Fire.Size = new Size(50, 50);
            Fire.TabIndex = 5;
            Fire.Text = "TF";
            Fire.UseVisualStyleBackColor = true;
            Fire.Click += Fire_Click;
            // 
            // Turret_Turn_Right
            // 
            Turret_Turn_Right.FlatStyle = FlatStyle.Flat;
            Turret_Turn_Right.Location = new Point(175, 450);
            Turret_Turn_Right.Name = "Turret_Turn_Right";
            Turret_Turn_Right.Size = new Size(50, 50);
            Turret_Turn_Right.TabIndex = 6;
            Turret_Turn_Right.Text = "TR";
            Turret_Turn_Right.UseVisualStyleBackColor = true;
            Turret_Turn_Right.Click += Turret_Turn_Right_Click;
            // 
            // Tank_Left_HP
            // 
            Tank_Left_HP.AutoSize = true;
            Tank_Left_HP.Location = new Point(25, 0);
            Tank_Left_HP.Name = "Tank_Left_HP";
            Tank_Left_HP.Size = new Size(0, 20);
            Tank_Left_HP.TabIndex = 7;
            // 
            // Tank_Right_HP
            // 
            Tank_Right_HP.AutoSize = true;
            Tank_Right_HP.Location = new Point(750, 2);
            Tank_Right_HP.Name = "Tank_Right_HP";
            Tank_Right_HP.Size = new Size(0, 20);
            Tank_Right_HP.TabIndex = 15;
            // 
            // Next
            // 
            Next.FlatStyle = FlatStyle.Flat;
            Next.Location = new Point(250, 450);
            Next.Name = "Next";
            Next.Size = new Size(50, 50);
            Next.TabIndex = 16;
            Next.Text = "N";
            Next.UseVisualStyleBackColor = true;
            Next.Click += Next_Click;
            // 
            // t2_Next
            // 
            t2_Next.FlatStyle = FlatStyle.Flat;
            t2_Next.Location = new Point(250, 450);
            t2_Next.Name = "t2_Next";
            t2_Next.Size = new Size(50, 50);
            t2_Next.TabIndex = 17;
            t2_Next.Text = "N";
            t2_Next.UseVisualStyleBackColor = true;
            t2_Next.Click += t2_Next_Click;
            // 
            // fight_info
            // 
            fight_info.AutoSize = true;
            fight_info.Location = new Point(362, 2);
            fight_info.Name = "fight_info";
            fight_info.Size = new Size(15, 20);
            fight_info.TabIndex = 18;
            fight_info.Text = "*";
            // 
            // Hit_or_Miss
            // 
            Hit_or_Miss.AutoSize = true;
            Hit_or_Miss.ForeColor = Color.Lime;
            Hit_or_Miss.Location = new Point(362, 450);
            Hit_or_Miss.Name = "Hit_or_Miss";
            Hit_or_Miss.Size = new Size(27, 20);
            Hit_or_Miss.TabIndex = 19;
            Hit_or_Miss.Text = "***";
            // 
            // moveslbl
            // 
            moveslbl.AutoSize = true;
            moveslbl.Location = new Point(475, 450);
            moveslbl.Name = "moveslbl";
            moveslbl.Size = new Size(52, 20);
            moveslbl.TabIndex = 20;
            moveslbl.Text = "moves";
            // 
            // bulletslbl
            // 
            bulletslbl.AutoSize = true;
            bulletslbl.Location = new Point(475, 480);
            bulletslbl.Name = "bulletslbl";
            bulletslbl.Size = new Size(52, 20);
            bulletslbl.TabIndex = 21;
            bulletslbl.Text = "ammo";
            // 
            // inertialbl
            // 
            inertialbl.AutoSize = true;
            inertialbl.Location = new Point(362, 480);
            inertialbl.Name = "inertialbl";
            inertialbl.Size = new Size(51, 20);
            inertialbl.TabIndex = 22;
            inertialbl.Text = "inertia";
            // 
            // helpbtn
            // 
            helpbtn.FlatStyle = FlatStyle.Flat;
            helpbtn.Location = new Point(725, 450);
            helpbtn.Name = "helpbtn";
            helpbtn.Size = new Size(50, 50);
            helpbtn.TabIndex = 23;
            helpbtn.Text = "help";
            helpbtn.UseVisualStyleBackColor = true;
            helpbtn.Click += helpbtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 525);
            Controls.Add(helpbtn);
            Controls.Add(inertialbl);
            Controls.Add(bulletslbl);
            Controls.Add(moveslbl);
            Controls.Add(Hit_or_Miss);
            Controls.Add(fight_info);
            Controls.Add(t2_Next);
            Controls.Add(Next);
            Controls.Add(Tank_Right_HP);
            Controls.Add(Tank_Left_HP);
            Controls.Add(Turret_Turn_Right);
            Controls.Add(Fire);
            Controls.Add(Turret_Turn_Left);
            Controls.Add(Turn_Right);
            Controls.Add(Move_Forward);
            Controls.Add(Turn_Left);
            Controls.Add(Map);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Panel Map;
        public Button Turn_Left;
        public Button Move_Forward;
        public Button Turn_Right;
        public Button Turret_Turn_Left;
        public Button Fire;
        public Button Turret_Turn_Right;
        public Label Tank_Left_HP;
        public Label Tank_Right_HP;
        public Button Next;
        public Button t2_Next;
        public Label fight_info;
        public Label Hit_or_Miss;
        public Label moveslbl;
        public Label bulletslbl;
        public Label inertialbl;
        public Button helpbtn;
    }
}
