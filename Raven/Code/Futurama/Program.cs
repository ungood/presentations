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
        private static void Main(string[] args)
        {
            var demo = new Demo();
            demo.CreateCharacters();
            demo.LoadAll();
            //demo.CreateVotes();
            //demo.LoadIncludes();
            //demo.IndexedQuery();

            Console.WriteLine("PRESS ENTER");
            Console.ReadLine();
        }

        public Program()
        {

        }

        public void Run()
        {
            
        }

        public static void Print <T>(IQueryable<T> query)
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