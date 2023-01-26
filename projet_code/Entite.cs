using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_sharp
{
    internal class Entite
    {
        protected int _Hp;         //{ get; set; }
        protected int _Mana;       //{ get; set; }
        protected int _Defense;    //{ get; set; }
        protected int _Attack;     //{ get; set; }
        protected int _Agility;     //{ get; set; }

        protected int _BuffAttack;     //{ get; set; }
        protected int _BuffDefense;     //{ get; set; }



        public Entite()
        {

        }

        public void entity_type(string n_type)
        {
            switch (n_type)
            {
                case "chevalier":       //Equipe Allie
                    _Hp = 170;
                    _Mana = 0;
                    _Defense = 12;
                    _Attack= 15;
                    _Agility = 11;

                    _BuffAttack = 0;
                    _BuffDefense = 0;
                    break;
                case "archer":
                    _Hp = 90;
                    _Mana = 12;
                    _Defense = 7;
                    _Attack = 11;
                    _Agility = 35;

                    _BuffAttack = 0;
                    _BuffDefense = 0;
                    break;
                case "mage":
                    _Hp = 110;
                    _Mana = 60;
                    _Defense = 5;
                    _Attack = 13;
                    _Agility = 18;

                    _BuffAttack = 0;
                    _BuffDefense = 0;
                    break;

                case "Loup":           //Enemie
                    _Hp = 50;
                    break;
                case "Gobelin":
                    _Hp = 50;
                    break;
                case "Orc":
                    _Hp = 50;
                    break;
                case "Mage_noir":
                    _Hp = 50;
                    break;

            }
        }

        public void lostHp(int attack)
        {
            _Hp -= attack;
        }

        public int death_test()
        {
            if (_Hp <= 0) 
            {
                return 1;
            }
            return 0;
        }

        public int attack_test()
        {
            Random aleatoire = new Random();
            int esquive = aleatoire.Next(0, 100);
            if (esquive >= 90 - _Agility)
            {
                return 1;               //Esquive avec succée
            }

            return 0;                   //Echou et sera attaqué 
        }


    }
}
