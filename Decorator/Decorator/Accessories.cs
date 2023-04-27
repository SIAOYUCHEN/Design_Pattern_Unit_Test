namespace Decorator
{
    public class Accessories : Decorator
    {
        public Accessories(Phone p) : base(p)
        {
        }

        public override string Print()
        {
            return base.Print() + "-" + AddAccessories();
        }
        
        public string AddAccessories()
        {
            return "AddAccessories";
        }
    }
}