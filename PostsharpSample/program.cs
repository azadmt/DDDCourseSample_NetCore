using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostsharpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var ns = new NotificationService();
            ns.SendNotification("Postshrp message");

            Console.ReadKey();

        }
    }
}
