using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoolHelper
{
    class Program
    {
        private static string s;
        private static Functions F;
        static void Main(string[] args)
        {
            F = new Functions();
            Console.Write("Добро пожаловать!\nДля просмотра всех команд введите help\nВведите команду для исполнения: >>");

            while(!F.IsExit)
            {
                s = Console.ReadLine();
                F.Detector(s);
                F.Selector();
                Console.Write("\n>>");
            }
        }
    }
}
