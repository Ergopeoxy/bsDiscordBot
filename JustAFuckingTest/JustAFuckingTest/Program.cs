using Discord;
using Discord.WebSocket;
using JustAFuckingTest.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustAFuckingTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bot bt = new Bot();
            bt.RunAsync().GetAwaiter().GetResult();

        }

       

      
    }
}
