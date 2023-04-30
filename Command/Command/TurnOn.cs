namespace Command
{
    public class TurnOn : Command
    {
        Light light;
        
        public TurnOn(Light light) : base(light) {
            this.light = light;
        }
        
        public override void Execute() {
            light.TurnOn();
        }
    }
}