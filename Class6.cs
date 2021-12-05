using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITParkApp
{
    class Character
    {
        string _name;
        public virtual int MinStr { get; }
        int MinDex { get; set; }
        int MinInt { get; set; }
        int strength;
        int dexterity;
        int inteligence;
        int constitution;
        //public Character(string name, int MinStr, int MinDex, int MinInt)
        //{
        //    _name = name;
        //    strength = MinStr;
        //    dexterity = MinDex;
        //    inteligence = MinInt;
        //}



    }
}
