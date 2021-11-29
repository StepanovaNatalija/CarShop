using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public abstract class UserOutput
    {
        public static void Message1(int count)
        {
            Console.WriteLine($"Available car count is: {count}. Their availability is marked as 'true' in the list below:");
        }

        public static void Message2(string model) 
        {
            Console.WriteLine($"Congratulation with purchasing car : {model}. Would you like to have receipt (type 'Yes' / 'No')?");
        }

    }
}
