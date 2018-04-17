using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocceBall
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bocce Ball Database Manager!");
            ReadLineIfDebug();
        }

        [Conditional("DEBUG")]
        static void ReadLineIfDebug()
        {
            Console.ReadLine();
        }
    }
}
