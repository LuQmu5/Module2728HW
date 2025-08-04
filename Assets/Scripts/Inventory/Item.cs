public class Item
{
    public Item(int iD, string name)
    {
        ID = iD;
        Name = name;
    }

    public int ID { get; private set; }
    public string Name { get; private set; }
}