using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_sharp
{
    internal class Entite
    {
        public int _Hp;       //{ get; set; }
        public int _HpMax;         //{ get; set; }
        public int _Mana;       //{ get; set; }
        public int _ManaMax;       //{ get; set; }
        public int _Defense;    //{ get; set; }
        public int _Attack;     //{ get; set; }
        public int _Agility;    //{ get; set; }
        public string _Tag;     //{ get; set; }


        public int _BuffAttack;     //{ get; set; }
        public int _BuffDefense;    //{ get; set; }


        public Entite()
        {
            _BuffAttack = 0;
            _BuffDefense = 0;
        }

        public Entite(string type_name)
        {
            entity_type(type_name);
            _BuffAttack = 0;
            _BuffDefense = 0;
        }
        ~Entite()
        {
        }

        public void entity_type(string n_type)
        {
            switch (n_type)
            {
                case "chevalier":       //Equipe Allie
                    _Hp = 170;
                    _HpMax = _Hp;
                    _Mana = 0;
                    _ManaMax = _Mana;
                    _Defense = 12;
                    _Attack= 15;
                    _Agility = 11;
                    _Tag = "chevalier";
                    break;
                
                case "archer":
                    _Hp = 90;
                    _HpMax = _Hp;
                    _Mana = 12;
                    _ManaMax = _Mana;
                    _Defense = 7;
                    _Attack = 11;
                    _Agility = 35;
                    _Tag = "archer";
                    break;

                case "mage":
                    _Hp = 110;
                    _HpMax = _Hp;
                    _Mana = 60;
                    _ManaMax = _Mana;
                    _Defense = 5;
                    _Attack = 13;
                    _Agility = 18;
                    _Tag = "mage";
                    break;

                case "Loup":           //Enemie
                    _Hp = 50;
                    _HpMax = _Hp;
                    _Mana = 0;
                    _ManaMax = _Mana;
                    _Defense = 5;
                    _Attack = 8;
                    _Agility = 22;
                    _Tag = "Loup";
                    break;

                case "Gobelin":
                    _Hp = 90;
                    _HpMax = _Hp;
                    _Mana = 0;
                    _ManaMax = _Mana;
                    _Defense = 6;
                    _Attack = 11;
                    _Agility = 18;
                    _Tag = "Gobelin";
                    break;

                case "Orc":
                    _Hp = 160;
                    _HpMax = _Hp;
                    _Mana = 12;
                    _ManaMax = _Mana;
                    _Defense = 10;
                    _Attack = 13;
                    _Agility = 3;
                    _Tag = "Orc";
                    break;

                case "Mage_noir":
                    _Hp = 999;
                    _HpMax = _Hp;
                    _Mana = 999;
                    _ManaMax = _Mana;
                    _Defense = 999;
                    _Attack = 999;
                    _Agility = 99;
                    _Tag = "Mage_noir";
                    break;

            }
        }

        public void lostHp(int attack)              //prend une attaque est perd de la vie
        {
            _Hp -= attack;
        }

        public void giveHp()                         //utilisation de la potion de vie
        {
            Random aleatoire = new Random();
            int vie = aleatoire.Next(30, 60);
            if (_Hp + vie > _HpMax)
            {
                _Hp = _HpMax;
            }
            else
            {
                _Hp += vie;
            }

        }

        public int getHp()
        {
            return _Hp;
        }

        public int getAttack()
        {
            return _Attack;
        }

        public void giveAttackBuff()                 //utilisation de la potion d'attaque
        {
            Random aleatoire = new Random();
            int buff = aleatoire.Next(2, 5);
            _BuffAttack += buff;
        }

        public bool death_test()
        {
            if (_Hp <= 0) 
            {
                return true;
            }
            return false;
        }

        public bool dodge_test()                    //teste si l'entité esquive
        {
            Random aleatoire = new Random();
            int esquive = aleatoire.Next(0, 100);
            if (esquive >= 90 - _Agility)
            {
                return true;               //Esquive avec succée
            }

            return false;                   //Echoue et sera attaqué 
        }


    }
}
