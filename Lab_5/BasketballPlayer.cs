using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    public class BasketballPlayer
    {
        private string name;
        private int age;
        private Position playerPosition;
        private double height;
        private double weight;
        private bool isInjured;
        private int shirtNumber;

        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length >= 3 && value.All(char.IsLetter))
                    name = value;
                else
                    throw new ArgumentException("Некоректне ім'я. Ім'я має містити хоча б 3 букви і складатися з літер.");
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (!int.TryParse(value.ToString(), out int parsedValue) || parsedValue < 1 || parsedValue > 99)
                {
                    throw new ArgumentException("Erroe: Age should be more than 1 and less than 99");
                }

                age = parsedValue;
            }
        }

        public Position PlayerPosition
        {
            get { return playerPosition; }
            set { playerPosition = value; }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (!double.TryParse(value.ToString(), out double parsedValue) || parsedValue > 0)
                    height = parsedValue;
                else
                    throw new ArgumentException("Некоректний зріст. Зріст має бути більше 0.");
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (!double.TryParse(value.ToString(), out double parsedValue) || parsedValue > 0)
                    weight = parsedValue;
                else
                    throw new ArgumentException("Некоректна вага. Вага має бути більше 0.");
            }
        }

        public bool IsInjured { get; set; } = false;

        public int ShirtNumber
        {
            get { return shirtNumber; }
            set
            {
                if (value > 0 || value < 99)
                    shirtNumber = value;
                else
                    shirtNumber = 0;
            }
        }


        public BasketballPlayer()
        {
            isInjured = false;
        }

        public BasketballPlayer(string name, int age) : this()
        {
            Name = name;
            Age = age;
        }

        public BasketballPlayer(string name, int age, Position position, double hight, double weight, bool isInjured, int shitNumbmer) : this(name, age)
        {
            PlayerPosition = position;
            Height = hight;
            Weight = weight;
            IsInjured = isInjured;
            ShirtNumber = shitNumbmer;

        }



        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Position: {PlayerPosition}, Height: {Height}, Weight: {Weight}, IsInjured: {IsInjured}, ShirtNumber: {ShirtNumber}";
        }

        public static BasketballPlayer Parse(string s)
        {
            try
            {
                string[] data = s.Split(',');


                string name = data[0].Trim();
                int age = int.Parse(data[1].Trim());
                Position position = (Position)Enum.Parse(typeof(Position), data[2].Trim());
                double height = double.Parse(data[3].Trim());
                double weight = double.Parse(data[4].Trim());
                bool isInjured = bool.Parse(data[5].Trim());
                int shirtNumber = int.Parse(data[6].Trim());

                return new BasketballPlayer(name, age, position, height, weight, isInjured, shirtNumber);
            }
            catch (Exception)
            {
                throw new ArgumentException("Неможливо розібрати рядок на об'єкт BasketballPlayer");
            }
        }

        public static bool TryParse(string s, out BasketballPlayer obj)
        {
            try
            {
                obj = Parse(s);
                return true;
            }
            catch (ArgumentException)
            {
                obj = null;
                return false;
            }
        }
    }
}
