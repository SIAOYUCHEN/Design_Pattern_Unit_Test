namespace Strategy
{
    public class NormalAttack : IFlightStrategy
    {
        public string Execute()
        {
            return "NormalAttack";
        }
    }
}