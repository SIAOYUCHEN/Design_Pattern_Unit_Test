namespace Command
{
    public class Brighter : Command
    {
        Light light;
        
        public Brighter(Light light) : base(light) {
            this.light = light;
        }
        
        public override void Execute() {
            light.Brighter();
        }
    }
}