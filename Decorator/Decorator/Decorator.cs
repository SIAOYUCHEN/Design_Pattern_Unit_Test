namespace Decorator
{
    public abstract class Decorator : Phone
    {
        private Phone phone;

        public Decorator(Phone p)
        {
            this.phone = p;
        }

        public override string Print()
        {
            return phone.Print();
        }
    }
}