// See https://aka.ms/new-console-template for more information

namespace InventoryManagement
{

    public class Item
    {

        private readonly string _name;
        private int _quantity { get; }
        private DateTime _dateCreated;

        public Item(string name, int quantity, DateTime? date = null)
        {
            _name = name;
            _quantity = quantity >= 0 ? quantity : throw new Exception("Invalid. quantity cannot be negative!");
            _dateCreated = date ?? DateTime.Now;
        }

        public string GetName()
        {
            return _name;
        }
        public int GetQuantity()
        {
            return _quantity;
        }
    }

    public class Store
    {

        private List<Item> _items = new List<Item>();
        private int _maximumCapacity;

        public Store(int capacity){
            _maximumCapacity = capacity;
        }

        public bool AddItem(Item item)
        {
            if (FindItemByName(item.GetName()) == null) return false;
            
            if (_items.Count == _maximumCapacity) return false;

            _items.Add(item);
            return true;
        }

        public bool RemoveItem(Item item)
        {
            if (FindItemByName(item.GetName()) == null) return false;
            _items.Remove(item);
            return true;
        }

        public int GetCurrentVolume()
        {
            return _items.Sum(item => item.GetQuantity()); ;
        }
        public Item FindItemByName(string name)
        {
            return _items.Find(item => item.GetName().ToUpper().Equals(name.ToUpper()));
        }

        public void SortByNameAsc()
        {
            _items.OrderBy(item => item.GetName().ToUpper());
        }
    }
}