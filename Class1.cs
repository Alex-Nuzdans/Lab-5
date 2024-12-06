using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Lab_5_1
{
    class paintings
    {
        internal int id;
        private string name;
        private int id_artsts;
        private int part;
        private string year;
        private int id_stile;
        public paintings(int id, string name, int id_artsts, int part,string year, int stile)
        {
            
            this.id = id;
            this.name = name;
            this.id_artsts = id_artsts;
            this.part = part;
            this.year = year;
            this.id_stile = stile;
        }
        public List<string> StrCon() {
            List<string> temp=new List<string>();
            temp.Add(Convert.ToString(id));
            temp.Add(name);
            temp.Add(Convert.ToString(id_artsts));
            temp.Add(Convert.ToString(part));
            temp.Add(year);
            temp.Add(Convert.ToString(id_stile));
            return temp;
        }
        public void newvalue(string s,string L)
        {
            if (s == "name")
            {
                name = L;
            }
            else if (s == "year")
            {
                year = L;
            }
        }
        public void newvalue(string s, int L)
        {
            if(s == "a_id")
            {
                id_artsts = L;
            }
            else if (s == "part")
            {
                part = L;
            }
            else if (s == "s_id")
            {
                id_stile = L;
            }
        }
        public override string ToString()
        { 
            return ("id: "+Convert.ToString(id) +"\nНазвание: " +Convert.ToString(name) + "\nid_художника: " + Convert.ToString(id_artsts) + "\nЧасть Эрмитажа: " + Convert.ToString(part) + "\nГод: " + Convert.ToString(year) + "\nid_стиля: " + Convert.ToString(id_stile));
        }
    }
    class artists
    {
        internal int id;
        private string name;
        public artists(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public List<string> StrCon()
        {
            List<string> temp = new List<string>();
            temp.Add(Convert.ToString(id));
            temp.Add(name);
            return temp;
        }
        public void newvalue(string s, string L)
        {
            if (s == "name")
            {
                name = L;
            }
        }
        public override string ToString()
        {
            return ("id: " + Convert.ToString(id) + "\nНазвание: " + Convert.ToString(name));
        }
    }
    class styles
    {
        internal int id;
        private string name;
        public styles(int id, string name) {
            this.id = id;
            this.name = name;
        }
        public List<string> StrCon()
        {
            List<string> temp = new List<string>();
            temp.Add(Convert.ToString(id));
            temp.Add(name);
            return temp;
        }
        public void newvalue(string s, string L)
        {
            if (s == "name")
            {
                name = L;
            }
        }
        public override string ToString()
        {
            return ("id: " + Convert.ToString(id) + "\nНазвание: " + Convert.ToString(name));
        }

    }
}
