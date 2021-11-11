using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public abstract class UserOutput
    {
        public static void Message1()
        {
            Console.WriteLine($"Available car count is: {CarList.Count(x => x is { IsAvailable: true })}. Their availability is marked as 'true' in the list below:");
        }

        public static void Message2() 
        {
            Console.WriteLine($"Congratulation with purchasing car : {selectedCar.Model}. Would you like to have receipt (type 'Yes' / 'No')?");
        }

    }
}
