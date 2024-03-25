// See https://aka.ms/new-console-template for more information
using System.Dynamic;

namespace InventoryManagement
{

    public class Item
    {

        private readonly string _name;
        private int _quantity;
        private DateTime _dateCreated;

        Item(string name, int quantity, DateTime? date = null)
        {
            _name = name;
            _quantity = quantity >= 0 ? quantity : throw new Exception("Invalid. quantity cannot be negative!");
            _dateCreated = date ?? DateTime.Now;
        }

        public string GetName()
        {
            return _name;
        }
    }

    public class Store
    {

        private List<Item> _items = new List<Item>();

        bool AddItem(Item item)
        {
            if (FindItemByName(item.GetName()) == null) return false;
            _items.Add(item);
            return true;
        }

        bool RemoveItem(Item item)
        {
            if (FindItemByName(item.GetName()) == null) return false;
            _items.Remove(item);
            return true;
        }


        Item FindItemByName(string name)
        {
            return _items.Find(item => item.GetName().ToUpper().Equals(name.ToUpper()));
        }

        void SortByNameAsc()
        {
            _items.OrderBy(item => item.GetName().ToUpper());
        }
    }
}