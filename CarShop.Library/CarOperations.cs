using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarOperations : ICarOperations
    {
        //public Car[] CarArray = new Car[100];
        public List<Car> CarList = new();

        public void AddCarToTheList(Car car)
        {
            CarList.Add(car);
            //var index = CarList.Count;
            //CarList[index] = car;
        }

        public void FindAvailableCarsCount()
        {
            UserOutput.Message1(CarList.Count(x => x is { IsAvailable: true }));
            //Console.WriteLine($"Available car count is: {CarList.Count(x => x is { IsAvailable: true })}. Their availability is marked as 'true' in the list below:");
            ShowListOfAllCars();
        }

        public Car[] FindCarByYear(int year)
        {
            return CarList.Where(x => x != null && x.Year == year).ToArray();
        }

        public void ByCar(int id)
        {
            var selectedCar = CarList.FirstOrDefault(x => x.Id == id);

            if (selectedCar != null)
            {
                selectedCar.Sold = true;
                selectedCar.IsAvailable = false;

                UserOutput.Message2(selectedCar.Model);
                //Console.WriteLine(
                //    $"Congratulation with purchasing car : {selectedCar.Model}. Would you like to have receipt (type 'Yes' / 'No')?");

                var acceptReceipt = Console.ReadLine() == "Yes";

                if (acceptReceipt)
                {
                    Console.WriteLine(GetReceipt(selectedCar));
                }
            }
            else
            {
                Console.WriteLine($"There is no car with id#: {id}");
            }
        }

        public string GetReceipt(Car car)
        {
            var receipt = new Recipient()
            {
                Car = car,
                RecipientId = Guid.NewGuid().ToString().Substring(0, 8),
                RecipientName = "Car selling receipt"
            };

            return @$"
                        Receipt number: {receipt.RecipientId}
                        Receipt name: {receipt.RecipientName}
                        Model: {receipt.Car.Model}
                        Year:  {receipt.Car.Year}
                        Color: {receipt.Car.Color}
                        Date:  {DateTime.Now}
                        Price: {receipt.Car.Price}
                    ";
        }

        public void ShowMenu()
        {
            Console.WriteLine("Input number to choose your option or input word 'exit' to stop the program");
            Console.WriteLine("1  Add car to the shop");
            Console.WriteLine("2  Check car count that are available for purchase");
            Console.WriteLine("3  Find car by year");
            Console.WriteLine("4  Show list of all cars in the shop");
            Console.WriteLine("5  Buy a car");
        }

        public Car CreateCarObject(int id)
        {
            var car = new Car
            {
                Id = id
            };

            Console.Write("Please add car model:");
            car.Model = Console.ReadLine();

            Console.Write("Add car color:");
            car.Color = Console.ReadLine();

            Console.Write("Add car year:");
            car.Year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Add price:");
            car.Price = Convert.ToDecimal(Console.ReadLine());

            return car;
        }

        public void AddCarToTheList()
        {
            int id = 0;
            var continues = true;

            while (continues)
            {
                var car = CreateCarObject(id);
                AddCarToTheList(car);

                Console.WriteLine("Do you want to add more cars to the shop? Type 'Yes' or 'No'");

                var yesNo = Console.ReadLine();
                if (yesNo != "Yes")
                {
                    continues = false;
                    ShowMenu();
                }

                id++;
            }
        }

        public void GetCarByYear()
        {
            Console.WriteLine("Please provide year");
            var year = Convert.ToInt32(Console.ReadLine());
            var carArray = FindCarByYear(year);

            foreach (var car in carArray)
            {
                Console.WriteLine($"Found car Id#: {car.Id} \t{car.Model} \t{car.Color} \t{car.Year} \t{car.Price} \t?available to buy: {car.IsAvailable}");
            }
        }

        public void ShowListOfAllCars()
        {
            int i = 0;

            foreach (var car in CarList)
            {
                if (car != null)
                {
                    Console.WriteLine($"Car Id#: {car.Id} \t{car.Model} \t{car.Color} \t{car.Year} \t{car.Price} \t?available to buy: {car.IsAvailable}");
                }

                i++;
            }
        }

        public void BuyCar()
        {
            Console.WriteLine("Please provide car id# from the car list that you wish to buy");
            var carId = Convert.ToInt32(Console.ReadLine());

            ByCar(carId);
        }
    }
}
