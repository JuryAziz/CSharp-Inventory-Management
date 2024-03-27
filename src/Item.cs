public class Item
{
    private readonly string _name;
    public string Name { get { return _name; } }

    private int _quantity;
    public int Quantity { get { return _quantity; } }

    private DateTime _dateCreated;
    public DateTime DateCreated { get { return _dateCreated; } }

    public Item(string name, int quantity, DateTime date = default)
    {
        _name = name;
        _quantity = quantity >= 0 ? quantity : throw new Exception("Invalid. quantity cannot be negative!");
        _dateCreated = date == default ? DateTime.Now : date;
    }

    public override string ToString()
    {
        return $"- {Name}, {Quantity} pcs, Created: {DateCreated.ToShortDateString()}";
    }
}