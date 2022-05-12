using System;
using System.IO;
using System.Text;

namespace PM03
{
    public class Car : IComparable
    {
        public string model;
        public int price;
        public int power;

        public Car(string model, int price, int power)
        {
            this.model = model;
            this.price = price;
            this.power = power;
        }

        public string ToString()
        {
            return string.Format("Модель: {0}  Цена: {1} Мощность двигателя: {2}", model, price, power);
        }

        public int CompareTo(object o)
        {
            Car c = o as Car;
            if (c != null)
            {
                int result = power.CompareTo(c.power);
                if (result != 0)
                {
                    return result;
                }
                return price.CompareTo(c.price);
            }
            else
            {
                throw new Exception("Невозможно сравнить два объекта");
            }
        }

    }

    public class CarControl
    {
        int cntCars;
        public Car[] Cars;

        public CarControl(int cntCars)
        {
            this.cntCars = cntCars;
            Cars = new Car[cntCars];
        }

        public void Fill()
        {
            string model;
            int price;
            int power;
            for (int i = 0; i < this.cntCars; i++)
            {
                Console.WriteLine("Модель: ");
                model = Console.ReadLine();
                Console.WriteLine("Цена: ");
                price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Мощность двигателя: ");
                power = Convert.ToInt32(Console.ReadLine());
                this.Cars[i] = new Car(model, price, power);
            }
        }

        public void Sort()
        {
            Array.Sort(this.Cars);
        }

        public void PrintToFile()
        {
            using (StreamWriter file = new StreamWriter("result.txt", false, Encoding.UTF8))
            {
                foreach (Car c in this.Cars)
                {
                    file.WriteLine(c.ToString());
                }
            }
        }
    }


}