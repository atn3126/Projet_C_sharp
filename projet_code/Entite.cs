﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_sharp
{
    internal class Entite
    {
        public int _Hp;         //{ get; set; }
        public int _Mana;       //{ get; set; }
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
                    _Tag = "chevalier";
                    break;
                
                case "archer":
                    _Hp = 90;
                    _Mana = 12;
                    _Defense = 7;
                    _Attack = 11;
                    _Agility = 35;
                    _Tag = "archer";
                    break;

                case "mage":
                    _Hp = 110;
                    _Mana = 60;
                    _Defense = 5;
                    _Attack = 13;
                    _Agility = 18;
                    _Tag = "mage";
                    break;

                case "Loup":           //Enemie
                    _Hp = 50;
                    _Mana = 0;
                    _Defense = 5;
                    _Attack = 8;
                    _Agility = 22;
                    _Tag = "Loup";
                    break;

                case "Gobelin":
                    _Hp = 90;
                    _Mana = 0;
                    _Defense = 6;
                    _Attack = 11;
                    _Agility = 18;
                    _Tag = "Gobelin";
                    break;

                case "Orc":
                    _Hp = 160;
                    _Mana = 12;
                    _Defense = 10;
                    _Attack = 13;
                    _Agility = 3;
                    _Tag = "Orc";
                    break;

                case "Mage_noir":
                    _Hp = 999;
                    _Mana = 999;
                    _Defense = 999;
                    _Attack = 999;
                    _Agility = 99;
                    _Tag = "Mage_noir";
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

            return 0;                   //Echoue et sera attaqué 
        }


    }
}
