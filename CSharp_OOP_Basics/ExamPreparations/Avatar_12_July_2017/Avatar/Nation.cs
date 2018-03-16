//using System.Collections.Generic;
//using System.Linq;

//public abstract class Nation
//{
//    private List<Bender> benders;
//    private List<Monument> monuments;
//    private string type;
//    private double totalPower;

//    protected Nation(string type)
//    {
//        Type = type;
//        Benders = new List<Bender>();
//        Monuments = new List<Monument>();
//        //this.TotalPower = benders.Sum(x => x.TotalPower);
//        //this.TotalPower += (TotalPower / 100) * monuments.Sum(x => x.TotalPower);
//    }

//    public string Type { get; set; }

//    public List<Bender> Benders { get; set; }

//    public List<Monument> Monuments { get; set; }

//    public virtual double TotalPower { get; protected set; }

//    public void AddBender(Bender bender)
//    {
//        benders.Add(bender);
//    }

//    public void AddMonument(Monument monument)
//    {
//        monuments.Add(monument);
//    }
//}