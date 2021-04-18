using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.totalIncome = 0;
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == typeof(Tea).Name)
            {
                this.drinks.Add(new Tea(name, portion, brand));
            }
            else if (type == typeof(Water).Name)
            {
                this.drinks.Add(new Water(name, portion, brand));
            }

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == typeof(Cake).Name)
            {
                this.bakedFoods.Add(new Cake(name, price));
            }
            else if (type == typeof(Bread).Name)
            {
                this.bakedFoods.Add(new Bread(name, price));
            }

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == typeof(InsideTable).Name)
            {
                this.tables.Add(new InsideTable(tableNumber, capacity));
            }
            else if (type == typeof(OutsideTable).Name)
            {
                this.tables.Add(new OutsideTable(tableNumber, capacity));
            }

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            var notReservedTables = this.tables.Where(x => !x.IsReserved);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var table in notReservedTables)
            {
                stringBuilder.AppendLine(table.GetFreeTableInfo());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {this.totalIncome}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            this.totalIncome += bill;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Table: {tableNumber}");
            stringBuilder.AppendLine($"Bill: {bill}");

            table.Clear();

            return stringBuilder.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            var drink = this.drinks.FirstOrDefault(x => x.Name == drinkName);

            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            var food = this.bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = this.tables.FirstOrDefault(x => !x.IsReserved && x.NumberOfPeople < numberOfPeople);

            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);

            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }
    }
}
