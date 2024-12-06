// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using Lab_5_2;
using static System.Net.Mime.MediaTypeNames;
class Home
{
    static void Main()
    {
        Class2 Temp = new Class2();
        Workbook wb = new Workbook("LR5var11.xls");
        var Paint = Temp.outputP(wb);
        var Art = Temp.outputA(wb);
        var Styl = Temp.outputS(wb);
        Temp=new Class2(Paint, Art, Styl);
        string T = null;
        string test2 = null;
        int id = 0;
        while (T != "exit")
        {
            Console.WriteLine("Введите All, чтобы вывести все данные\nВведите delete, чтобы удалить элемент\nВведите corrected, чтобы изменить элемент\nВведите add, чтобы добавить элемент\nВведите part, чтобы вывести все картины и их авторов из определённой части эрмитажа\nВведите count_part, чтобы определить количество художников, у которых больше определённого количества картин в определённой части Эрмитажа\nВведите print_style, чтобы вывести всех художников и все картины определённого стиля\nnВведите print_artist, чтобы вывести всех стилей и все картины определённого автора\nВведите print_part, чтобы вывести всех художников и их картины определённого стиля в определённой части Эрмитажа \nВведите exit, чтобы выйти.\n");
            T=Console.ReadLine();
            if (T == "All") {
                Temp.print_ALL();
            }
            else if (T == "delete")
            {
                Console.WriteLine("Введите P — чтобы удалить из таблицы 'Картины', A — чтобы удалить из таблицы 'Художники', S — чтобы удалить из таблицы 'Стили'");
                string test = Console.ReadLine();
                try
                {
                    Console.WriteLine("Введите id удаляемого элемента");
                    id = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка. Введено недопустимое знвчение!");
                    continue;
                }
                Temp.refuse(id,test);
            }
            else if(T == "corrected")
            {
                Console.WriteLine("Введите P — чтобы модернезировать таблицу 'Картины', A — чтобы модернезировать таблицу 'Художники', S — чтобы модернезировать таблицу 'Стили'");
                string test = Console.ReadLine();
                Console.WriteLine("Введите id изменяемого элемента");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка. Введено недопустимое знвчение!");
                    continue;
                }
                if (test == "P")
                {
                    Console.WriteLine("Введите название одного из следующих изменяемых элементов(имя — name, ID_Художника — id_artsts, Часть Эрмитажа — part, Год создания — year, ID_Стиля — id_stile)");
                    test2= Console.ReadLine();
                    Console.WriteLine("Введите новое значение");
                    if(test2== "name" || test2 == "year") {
                        string test3 = Console.ReadLine();
                        Temp.corrected(id,test2,test3, test);
                    }
                    else
                    {
                        int test3 =0;
                        try
                        {
                            test3 = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка, задано стандартное значение.");
                        }
                        Temp.corrected(id, test2, test3);
                    }
                }
                else
                {
                    
                    Console.WriteLine("Введите новое имя");
                    test2 = Console.ReadLine();
                    Temp.corrected(id,"name", test2,test);
                }
            }
            else if (T == "add")
            {
                Console.WriteLine("Введите P — чтобы добавить элемент в таблицу 'Картины', A — чтобы добавить элемент в таблицу 'Художники', S — чтобы добавить элемент в таблицу 'Стили'");
                string test = Console.ReadLine();
                if (test == "P")
                {
                    Console.WriteLine("Введите название картины");
                    string N = Console.ReadLine();
                    Console.WriteLine("Введите id Автора");
                    int IA = 0;
                    try
                    {
                        IA = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка, задано стандартное значение");
                    }
                    Console.WriteLine("Введите часть Эрмитажа");
                    int Part = 0;
                    try
                    {
                        Part = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка, задано стандартное значение");
                    }
                    Console.WriteLine("Введите год написания картины");
                    string Y = Console.ReadLine();
                    Console.WriteLine("Введите id стиля");
                    int IS = 0;
                    try
                    {
                        IS = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка, задано стандартное значение");
                    }
                    Temp.newvalue(N,IA,Part,Y,IS);
                }
                else
                {
                    if (test == "S")
                    {
                        Console.WriteLine("Введите название Стиял");
                    }
                    else if (test == "A") {
                        Console.WriteLine("Введите имя Художника");
                    }
                    string N = Console.ReadLine();
                    Temp.newvalue(N, test);
                }
            }
            else if (T == "part")
            {
                Console.WriteLine("Введите номер части Эрмитажа");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка, задано стандартное значение");
                    id = 1;
                }
                Temp.print_one(id);
            }
            else if (T== "count_part")
            {
                Console.WriteLine("Введите максимальное число картин");
                int count = 0;
                try
                {
                    count = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка, задано стандартное значение");
                }
                Console.WriteLine("Введите номер часть Эрмитажа");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка, задано стандартное значение");
                    id = 1;
                }
                Temp.print_two(count,id);
            }
            else if(T== "print_style")
            {
                Console.WriteLine("Введите название Стиля");
                test2 = Console.ReadLine();
                Temp.print_tree(test2, 1);
            }
            else if (T == "print_artist")
            {
                Console.WriteLine("Введите имя Художника");
                test2 = Console.ReadLine();
                Temp.print_tree(test2);
            }
            else if(T== "print_part")
            {
                Console.WriteLine("Введите номер часть Эрмитажа");
                try
                {
                   id = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка, задано стандартное значение");
                    id = 1;
                }
                Console.WriteLine("Введите название Стиля");
                test2 = Console.ReadLine();
                Temp.print_fore(id,test2);
            }
        }
    }
}
