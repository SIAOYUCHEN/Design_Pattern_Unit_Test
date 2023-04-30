namespace Command
{
    public class Daker : Command
    {
        Light light;
        
        public Daker(Light light) : base(light) {
            this.light = light;
        }
        
        public override void Execute() {
            light.Darker();
        }
    }
}