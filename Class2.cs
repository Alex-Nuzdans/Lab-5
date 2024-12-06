using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using Lab_5_1;

namespace Lab_5_2
{
    internal class Class2
    {
        List<paintings> P;
        List<artists> A;
        List<styles> S;
        public Class2(List<paintings> P, List<artists> A, List<styles> S)
        {
            this.P = P;
            this.A = A;
            this.S = S;
        }
        public Class2()
        {
            P = new List<paintings>();
            A = new List<artists>();
            S = new List<styles>();
        }
        public List<paintings> outputP(Workbook wb)
        {
            WorksheetCollection collection = wb.Worksheets;
            ArrayList Lists = new ArrayList();
            List<paintings> Pain = new List<paintings>();
            Worksheet work = collection[0];
            int row = work.Cells.MaxDataRow;
            int collon = work.Cells.MaxDataColumn;
            for (int j = 1; j < row; j++)
            {
                for (int k = 0; k <= collon; k++)
                {
                    Lists.Add(work.Cells[j, k].Value);
                }
                Pain.Add(new paintings(Convert.ToInt32(Lists[0]), Convert.ToString(Lists[1]), Convert.ToInt32(Lists[2]), Convert.ToInt32(Lists[3]), Convert.ToString(Lists[4]), Convert.ToInt32(Lists[5])));
                Lists.Clear();
            };
            return Pain;
        }
        public List<artists> outputA(Workbook wb)
        {
            WorksheetCollection collection = wb.Worksheets;
            ArrayList Lists = new ArrayList();
            List<artists> Art = new List<artists>();
            Worksheet work = collection[1];
            int row = work.Cells.MaxDataRow;
            int collon = work.Cells.MaxDataColumn;
            for (int j = 1; j < row; j++)
            {
                for (int k = 0; k <= collon; k++)
                {
                    Lists.Add(work.Cells[j, k].Value);
                }
                Art.Add(new artists(Convert.ToInt32(Lists[0]), Convert.ToString(Lists[1])));
                Lists.Clear();
            };
            return Art;
        }
        public List<styles> outputS(Workbook wb)
        {
            WorksheetCollection collection = wb.Worksheets;
            ArrayList Lists = new ArrayList();
            List<styles> Styl = new List<styles>();
            Worksheet work = collection[2];
            int row = work.Cells.MaxDataRow;
            int collon = work.Cells.MaxDataColumn;
            for (int j = 1; j < row; j++)
            {
                for (int k = 0; k <= collon; k++)
                {
                    Lists.Add(work.Cells[j, k].Value);
                }
                Styl.Add(new styles(Convert.ToInt32(Lists[0]), Convert.ToString(Lists[1])));
                Lists.Clear();
            };
            return Styl;
        }
        public void print_ALL()
        {
            List < List<string> > tests1= new List<List<string>>();
            List<List<string>> tests2 = new List<List<string>>();
            List<List<string>> tests3 = new List<List<string>>();
            foreach (var i in P) { 
                tests1.Add(i.StrCon());
            }
            foreach (var i in A)
            {
                tests2.Add(i.StrCon());
            }
            foreach (var i in S)
            {
                tests3.Add(i.StrCon());
            }
            var temp = from p in tests1 join a in tests2 on p[2] equals a[0] join s in tests3 on p[5] equals s[0] orderby Convert.ToInt32(p[0]) select new{ID=p[0]+"\n",Название = p[1]+"\n", Имя_Художника = a[1] + "\n", Часть_Эрмитажа = p[3] + "\n", Стиль = s[1] + "\n" };
            foreach(var i in temp)
            {
                Console.WriteLine(i);
            }
        }
        public void refuse(int id,string mode="P")
        {
            if (mode == "P")
            {
                var j = P.Where(p=>p.id==id);
                foreach (var i in j)
                {
                    P.Remove(i);
                    break;
                }
            }
            if (mode == "A")
            {
                var j = A.Where(p => p.id == id);
                foreach (var i in j)
                {
                    A.Remove(i);
                    break;
                }
            }
            if (mode == "S")
            {
                var j = S.Where(p => p.id == id);
                foreach (var i in j)
                {
                    S.Remove(i);
                    break;
                }
            }
        }
        public void newvalue(string newname,int newActid,int newPart, string newyear,int newStileid) {
            var j = P.Max(p=>p.id);
            P.Add(new paintings(j+1,newname, newActid, newPart, newyear, newStileid));
        }
        public void newvalue(string newname, string temp = "A")
        {
            if (temp == "A")
            {
                var j = A.Max(p => p.id);
                A.Add(new artists(j + 1, newname));
            }
            else
            {
                var j = S.Max(p => p.id);
                S.Add(new styles(j + 1, newname));
            }
        }
        public void corrected(int id,string I, string J,string temp="P")
        {
            if (temp == "P")
            {
                var j = P.Where(p => p.id == id);
                foreach (var i in j)
                {
                    i.newvalue(I, J);
                }
            }
            if (temp == "A") {
                var j = A.Where(p => p.id == id);
                foreach (var i in j)
                {
                    i.newvalue(I, J);
                }
            }
            if (temp == "S")
            {
                var j = S.Where(p => p.id == id);
                foreach (var i in j)
                {
                    i.newvalue(I, J);
                }
            }
        }
        public void corrected(int id, string I, int J)
        {
            var j = P.Where(p => p.id == id);
            foreach (var i in j)
            {
                i.newvalue(I, J);
            }
        }
        public void print_one(int part)
        {
            List<List<string>> tests = new List<List<string>>();
            foreach (var i in P)
            {
                tests.Add(i.StrCon());
            }
            var temp = from p in tests where p[3]==Convert.ToString(part) select new { Название = p[1] };
            foreach (var i in temp)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Общее количество картин равно: " + temp.Count());
        }
        public void print_two(int longs, int part)
        {
            List<List<string>> tests1 = new List<List<string>>();
            List<List<string>> tests2 = new List<List<string>>();
            foreach (var i in P)
            {
                tests1.Add(i.StrCon());
            }
            foreach (var i in A)
            {
                tests2.Add(i.StrCon());
            }
            var temp = from p in tests1 join a in tests2 on p[2] equals a[0] where p[3] == Convert.ToString(part) select a[1];
            var temp2 = temp.GroupBy(i => i).Select(g => g.Count());
            int c = 0;
            foreach (var i in temp2)
            {
                if (i > longs)
                {
                    c++;
                }
            }
            Console.WriteLine("Ответ: "+c);
        }
        public void print_tree(string style, int t=0)
        {
            List<List<string>> tests1 = new List<List<string>>();
            List<List<string>> tests2 = new List<List<string>>();
            List<List<string>> tests3 = new List<List<string>>();
            foreach (var i in P)
            {
                tests1.Add(i.StrCon());
            }
            foreach (var i in A)
            {
                tests2.Add(i.StrCon());
            }
            foreach (var i in S)
            {
                tests3.Add(i.StrCon());
            }
            var temp = from p in tests1
                       join a in tests2 on p[2] equals a[0]
                       join s in tests3 on p[5] equals s[0]
                       orderby p[0] where s[1]==style
                       select (new { Автор = a[1]+"\n", Картина = p[1]+"\n" });
            foreach(var i in temp)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Общее количество картин равно: " + temp.Count());
        }
        public void print_tree(string artist)
        {
            List<List<string>> tests1 = new List<List<string>>();
            List<List<string>> tests2 = new List<List<string>>();
            List<List<string>> tests3 = new List<List<string>>();
            foreach (var i in P)
            {
                tests1.Add(i.StrCon());
            }
            foreach (var i in A)
            {
                tests2.Add(i.StrCon());
            }
            foreach (var i in S)
            {
                tests3.Add(i.StrCon());
            }
            var temp = from p in tests1
                       join a in tests2 on p[2] equals a[0]
                       join s in tests3 on p[5] equals s[0]
                       orderby p[0]
                       where a[1] == artist
                       select (new { Стиль = s[1] + "\n", Картина = p[1] + "\n" });
            foreach (var i in temp)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Общее количество картин равно: " + temp.Count());
        }
        public void print_fore(int part, string style)
        {
            List<List<string>> tests1 = new List<List<string>>();
            List<List<string>> tests2 = new List<List<string>>();
            List<List<string>> tests3 = new List<List<string>>();
            foreach (var i in P)
            {
                tests1.Add(i.StrCon());
            }
            foreach (var i in A)
            {
                tests2.Add(i.StrCon());
            }
            foreach (var i in S)
            {
                tests3.Add(i.StrCon());
            }
            var temp = from p in tests1
                       join a in tests2 on p[2] equals a[0]
                       join s in tests3 on p[5] equals s[0]
                       orderby p[0]
                       where p[3]==Convert.ToString(part) && s[1] == style
                       select (new { Художник = a[1] + "\n", Картина = p[1] + "\n" });
            foreach (var i in temp)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Общее количество картин равно: "+temp.Count());
        }
    }
}
