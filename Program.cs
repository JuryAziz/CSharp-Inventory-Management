﻿namespace InventoryManagement;

public class InventoryManagement
{
    public static void Main(string[] args)
    {
        try
        {
            // items example - You do not need to follow exactly the same
            var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
            var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
            var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
            var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
            var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
            var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 6, 1));
            var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
            var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
            var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
            var toothbrush = new Item("Toothbrush", 50, new DateTime(2023, 10, 1));
            var coffee = new Item("Coffee", 20);
            var sandwich = new Item("Sandwich", 15);
            var batteries = new Item("Batteries", 10);
            var umbrella = new Item("Umbrella", 5);
            var sunscreen = new Item("Sunscreen", 8);

            // method invocation example - You do not need to follow exactly the same
            Store store = new Store(300);
            // ... add all items to the store
            store.AddItem(waterBottle);
            store.AddItem(chocolateBar);
            store.AddItem(notebook);
            store.AddItem(pen);
            store.AddItem(tissuePack);
            store.AddItem(chipsBag);
            store.AddItem(sodaCan);
            store.AddItem(soap);
            store.AddItem(shampoo);
            store.AddItem(toothbrush);
            store.AddItem(coffee);
            store.AddItem(sandwich);
            store.AddItem(batteries);
            store.AddItem(umbrella);
            store.AddItem(sunscreen);

            store.SortByDate(SortOrder.DESC);
            // print all items
            foreach (Item item in store.Items)
            {
                Console.WriteLine(item.ToString());
            }

            (List<Item> newArrivals, List<Item> oldItems) = store.GroupByDate();

            Console.WriteLine($"\nNew Arrival Items:");
            foreach (Item item in newArrivals)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine($"\nold Items:");
            foreach (Item item in oldItems)
            {
                Console.WriteLine(item.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }

    }
}