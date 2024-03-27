using InventoryManagement;

public enum SortOrder
{
    NONE = 0,
    ASC = 1,
    DESC = 2,
}

public class Store
{

    private List<Item> _items = new List<Item>();
    public List<Item> Items { get { return _items; } }

    private int _maximumCapacity;

    public Store(int capacity)
    {
        _maximumCapacity = capacity;
    }

    public bool AddItem(Item item)
    {
        if (FindItemByName(item.Name) != null) return false;

        // the current + the new item quantity should not exceed the maximum capacity
        if (GetCurrentVolume() + item.Quantity >= _maximumCapacity) return false;

        _items.Add(item);
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if (FindItemByName(item.Name) == null) return false;
        _items.Remove(item);
        return true;
    }

    public int GetCurrentVolume()
    {
        return _items.Sum(item => item.Quantity); ;
    }

    public Item? FindItemByName(string name)
    {
        return _items.Find(item => item.Name.ToUpper().Equals(name.ToUpper()));
    }

    public void SortByNameAsc()
    {
        _items = _items.OrderBy(item => item.Name.ToUpper()).ToList<Item>();
    }

    public void SortByDate(SortOrder order)
    {
        switch (order)
        {
            case SortOrder.NONE:
                break;
            case SortOrder.ASC:
                _items = _items.OrderBy(item => item.DateCreated).ToList<Item>();
                break;
            case SortOrder.DESC:
                _items = _items.OrderByDescending(item => item.DateCreated).ToList<Item>();
                break;

        }
    }

    public (List<Item> newArrivals, List<Item> oldItems) GroupByDate()
    {
        DateTime minDate = DateTime.Now.AddMonths(-3);

        List<Item> newArrivals = (from item in _items
                                  where item.DateCreated > minDate
                                  select item).ToList<Item>();
        List<Item> oldItems = (from item in _items
                               where item.DateCreated <= minDate
                               select item).ToList<Item>();

        return (newArrivals, oldItems);
    }
}