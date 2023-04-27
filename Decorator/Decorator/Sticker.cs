namespace Decorator
{
    public class Sticker : Decorator
    {
        public Sticker(Phone p) : base(p)
        { 
        }

        public override string Print()
        {
            return base.Print() + "-" + AddSticker();
        }
        
        public string AddSticker()
        {
            return "AddSticker";
        }
    }
}