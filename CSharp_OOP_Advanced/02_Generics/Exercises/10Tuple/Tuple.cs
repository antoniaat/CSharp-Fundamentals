public class Tuple
{
    //private object item1;
    //private object item2;

    public Tuple(object item1, object item2)
    {
        this.Item1 = item1;
        this.Item2 = item2;
    }

    public object Item1 { get; set; }
    public object Item2 { get; set; }
}