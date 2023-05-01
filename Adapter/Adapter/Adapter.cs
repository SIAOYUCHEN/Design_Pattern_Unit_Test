namespace Adapter
{
    public class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();

        public override string Request()
        {
            return adaptee.SpecificRequest();
        }
    }
}