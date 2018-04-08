public class Threeuple : Tuple
{
    public Threeuple(object item1, object item2, object item3) : base(item1, item2)
    {
        this.Item3 = item3;
    }

    public object Item3 { get; set; }
}