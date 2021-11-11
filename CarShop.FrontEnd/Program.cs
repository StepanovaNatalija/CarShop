using System;
using System.Collections.Generic;
using System.Linq;
using CarShop.Library;

namespace CarShop.Frontend
{
    class Program
    {
        static readonly CarOperations CarOperator = new();

        static void Main(string[] args)
        {
            CarOperator.ShowMenu();

            var exit = "continue";

            while (exit == "continue")
            {
                var option = Console.ReadLine();

                if (option is "exit")
                {
                    exit = option;
                }

                switch (option)
                {
                    case "1":
                        CarOperator.AddCarToTheList();
                        break;
                    case "2":
                        CarOperator.FindAvailableCarsCount();
                        break;
                    case "3":
                        CarOperator.GetCarByYear();
                        break;
                    case "4":
                        CarOperator.ShowListOfAllCars();
                        break;
                    case "5":
                        CarOperator.BuyCar();
                        break;
                }
            };
        }
    }
}
