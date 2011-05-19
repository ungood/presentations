using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Futurama.Models;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using Raven.Client.Linq;

namespace Futurama
{
    internal class Program
    {
        private static void Main()
        {
            new Program().Run();
            
            Console.WriteLine("PRESS ENTER");
            Console.ReadLine();
        }

        private Program()
        {

        }

        private void Run()
        {
            
        }

        public static void Print <T>(IEnumerable<T> query)
        {
            foreach(var item in query.ToArray())
                Console.WriteLine(item);
        }

        public static void Print(params Character[] objects)
        {
            foreach(var item in objects)
                Console.WriteLine(item);
        }
    }
}