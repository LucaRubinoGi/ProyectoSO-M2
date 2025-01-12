using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanquesLib
{
    public class Tank
    {
        Random r = new Random();
        string Direction;
        string Turret_Direction;
        int[] Location;
        int Max_Hull_Moves;
        int Hull_Moves;
        int Max_Turret_Moves;
        int Turret_Moves;
        int Max_Inertia;
        int Inertia = 0;
        int Pen;
        int Damage;
        int AC;
        int Max_HP;
        int HP;
        int Range;
        int Sprite;
        int Max_Fire_Moves;
        int Fire_Moves;
        int Fire_Recharge;

        public Tank(string Direction, string Turret_Direction, int[] Location, int Max_Hull_Moves, int Max_Turret_Moves, int Max_Inertia,
            int Pen, int Damage, int AC, int Max_HP, int Range, int Sprite, int Max_Fire_Moves, int Fire_Recharge)
        {
            this.Direction = Direction;
            this.Turret_Direction = Turret_Direction;
            this.Location = Location;
            this.Max_Hull_Moves = Max_Hull_Moves;
            this.Hull_Moves = Max_Hull_Moves;
            this.Max_Turret_Moves = Max_Turret_Moves;
            this.Turret_Moves = Max_Turret_Moves;
            this.Max_Inertia = Max_Inertia;
            this.Pen = Pen;
            this.Damage = Damage;
            this.AC = AC;
            this.Max_HP = Max_HP;
            this.HP = Max_HP;
            this.Range = Range;
            this.Sprite = Sprite;
            this.Max_Fire_Moves = Max_Fire_Moves;
            this.Fire_Moves = Fire_Recharge;
            this.Fire_Recharge = Fire_Recharge;
        }

        public string GDirection() { return Direction; }
        public string GTurret_Direction() { return Turret_Direction; }
        public int GLocationn(int n) { return Location[n]; }
        public int[] GLocation() { return Location; }
        public int GMax_Hull_Moves() { return Max_Hull_Moves; }
        public int GHull_Moves() { return Hull_Moves; }
        public int GMax_Turret_Moves() { return Max_Turret_Moves; }
        public int GTurret_Moves() { return Turret_Moves; }
        public int GMax_Inertia() { return Max_Inertia; }
        public int GInertia() { return Inertia; }
        public int GPen() { return Pen; }
        public int GDamage() { return Damage; }
        public int GAC() { return AC; }
        public int GMax_HP() { return Max_HP; }
        public int GHP() { return HP; }
        public int GRange() { return Range; }
        public int GSprite() { return Sprite; }
        public int GMax_Fire_Moves() { return Max_Fire_Moves; }
        public int GFire_Moves() { return Fire_Moves; }
        public int GFire_Recharge() { return Fire_Recharge; }

        public void SDirection(string Direction) { this.Direction = Direction; }
        public void STurret_Direction(string Turret_Direction) { this.Turret_Direction = Turret_Direction; }
        public void SLocationn(int n, int value) { this.Location[n] = value; }
        public void SLocation(int[] location) { this.Location = location; }
        public void SMax_Hull_Moves(int Max_Hull_Moves) { this.Max_Hull_Moves = Max_Hull_Moves; }
        public void SHull_Moves(int Hull_Moves) { this.Hull_Moves = Hull_Moves; }
        public void SMax_Turret_Moves(int Max_Turret_Moves) { this.Max_Turret_Moves = Max_Turret_Moves; }
        public void STurret_Moves(int Turret_Moves) { this.Turret_Moves = Turret_Moves; }
        public void SMax_Inertia(int Max_Inertia) { this.Max_Inertia = Max_Inertia; }
        public void SInertia(int Inertia) { this.Inertia = Inertia; }
        public void SPen(int Pen) { this.Pen = Pen; }
        public void SDamage(int Damage) { this.Damage = Damage; }
        public void SAC(int AC) { this.AC = AC; }
        public void SMax_HP(int Max_HP) { this.Max_HP = Max_HP; }
        public void SHP(int HP) { this.HP = HP; }
        public void SRange(int Range) { this.Range = Range; }
        public void SSprite(int Sprite) { this.Sprite = Sprite; }
        public void SMax_Fire_Moves(int Max_Fire_Moves) { this.Max_Fire_Moves = Max_Fire_Moves; }
        public void SFire_Moves(int Fire_Moves) { this.Fire_Moves = Fire_Moves; }
        public void SFire_Recharge(int Fire_Recharge) { this.Fire_Recharge = Fire_Recharge; }
        public void MHP(int Damage) { if (HP > Damage) { HP -= Damage; } else { HP = 0; } }
        public void RHull_Moves() { Hull_Moves = Max_Hull_Moves; }
        public void RTurret_Moves() { Turret_Moves = Max_Turret_Moves; }
        public void UFire_Moves() { Fire_Moves += Fire_Recharge; if (Fire_Moves > Max_Fire_Moves) { Fire_Moves = Max_Fire_Moves; } }

        public void Turn(string direction,string sel)
        {
            string str = "Q";
            if (sel == "H" && Hull_Moves > 0) { str = Direction; }
            else if (sel == "T" && Turret_Moves > 0) { str = Turret_Direction; }
            if (str != "Q")
            {
                if (direction == "L")
                {
                    if (str == "N") { str = "W"; }
                    else if (str == "E") { str = "N"; }
                    else if (str == "S") { str = "E"; }
                    else if (str == "W") { str = "S"; }
                }
                else if (direction == "R")
                {
                    if (str == "N") { str = "E"; }
                    else if (str == "E") { str = "S"; }
                    else if (str == "S") { str = "W"; }
                    else if (str == "W") { str = "N"; }
                }
                if (sel == "H") { Direction = str; Hull_Moves -= 1; if (Inertia > 0) { Inertia -= 1; } }
                else if (sel == "T") { Turret_Direction = str; Turret_Moves -= 1; }
            }
            if (Sprite == 4) { Turret_Direction = Direction; }
        }

        public void Move(Tank other_Tank)
        {
            int dist = 25;
            int[] other_tank = other_Tank.GLocation();
            if (Hull_Moves > 0)
            {
                for (int i = 0; i <= Inertia; i++)
                {
                    if (Direction == "N" && Location[1] > 5 && !((Location[1] == other_tank[1] + dist) && ((Location[0] < other_tank[0] + 50) && (Location[0] > other_tank[0] - 50))))
                    { Location[1] -= dist; }
                    else if (Direction == "E" && Location[0] < 705 && !((Location[0] == other_tank[0] - dist) && ((Location[1] < other_tank[1] + 50) && (Location[1] > other_tank[1] - 50))))
                    { Location[0] += dist; }
                    else if (Direction == "S" && Location[1] < 355 && !((Location[1] == other_tank[1] - dist) && ((Location[0] < other_tank[0] + 50) && (Location[0] > other_tank[0] - 50))))
                    { Location[1] += dist; }
                    else if (Direction == "W" && Location[0] > 5 && !((Location[0] == other_tank[0] + dist) && ((Location[1] < other_tank[1] + 50) && (Location[1] > other_tank[1] - 50))))
                    { Location[0] -= dist; }
                }
                Hull_Moves -= 1;
                if (Inertia < Max_Inertia) { Inertia += 1; }
            }
        }

        public bool Enemy_in_range(Tank other_Tank)
        {
            int[] other_tank = other_Tank.GLocation();
            if (Turret_Direction == "N"
                && other_tank[1] >= Location[1] - 50 * Range
                && (other_tank[1] - Location[1]) <= (other_tank[0] - Location[0])
                && (other_tank[1] - Location[1]) <= -(other_tank[0] - Location[0])
                )
            { return true; }
            else if (Turret_Direction == "E"
                && other_tank[0] <= Location[0] + 50 * Range
                && (other_tank[1] - Location[1]) <= (other_tank[0] - Location[0])
                && (other_tank[1] - Location[1]) >= -(other_tank[0] - Location[0])
                )
            { return true; }
            else if (Turret_Direction == "S"
                && other_tank[1] <= Location[1] + 50 * Range
                && (other_tank[1] - Location[1]) >= (other_tank[0] - Location[0])
                && (other_tank[1] - Location[1]) >= -(other_tank[0] - Location[0])
                )
            { return true; }
            else if (Turret_Direction == "W"
                && other_tank[0] >= Location[0] - 50 * Range
                && (other_tank[1] - Location[1]) >= (other_tank[0] - Location[0])
                && (other_tank[1] - Location[1]) <= -(other_tank[0] - Location[0])
                )
            { return true; }
            else { return false; }
        }

        public string Fire(Tank tank)
        {
            string str = "Q";
            if (Fire_Moves > 0)
            {
                if (Enemy_in_range(tank))
                {
                    int Hroll = r.Next(0, 21) + Pen - tank.GInertia();
                    int Droll = 0;
                    if (Hroll >= tank.GAC())
                    {
                        Droll = r.Next(-1, 1) + Damage;
                        str = "hit";
                    }
                    else { str = "miss"; }
                    tank.MHP(Droll);
                }
                else { str = "out of range"; }
                Fire_Moves -= 1;
            }
            return str;
        }
    }
}
