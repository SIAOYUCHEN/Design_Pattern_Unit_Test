namespace Command
{
    public abstract class Command {
    
        Light light;

        public Command(Light light){
            this.light = light;
        }

        public abstract void Execute();
    }
}