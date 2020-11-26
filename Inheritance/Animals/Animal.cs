using System;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if(String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid input!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get { return this.gender; }
            set
            {
                if(value != "Male" && value != "Female")
                {
                    throw new Exception("Invalid input!");
                }

                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.GetType().Name);
            stringBuilder.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            stringBuilder.AppendLine(ProduceSound());

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
