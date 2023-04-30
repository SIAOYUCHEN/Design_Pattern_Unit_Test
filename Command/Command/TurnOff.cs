namespace Command
{
    public class TurnOff : Command
    {
        Light light;
        
        public TurnOff(Light light) : base(light) {
            ;this.light = light;
        }
        
        public override void Execute() {
            light.TurnOff();
        }
    }
}