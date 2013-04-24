using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureMaker.Core;

namespace AdventureMaker.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Executable exec = new Executable();
            exec.Run();
            Console.ReadLine();
        }
    }
}
