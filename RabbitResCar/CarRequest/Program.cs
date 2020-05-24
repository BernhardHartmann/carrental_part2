using CarsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectMessageToCars directmessages = new DirectMessageToCars();
            directmessages.SendMessageToCars();
            Console.ReadLine(); 
        }
    }
}
