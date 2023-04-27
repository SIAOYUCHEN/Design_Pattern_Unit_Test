namespace Strategy
{
    public class UseItem : IFlightStrategy
    {
        public string Execute()
        {
            return "UserItem";
        }
    }
}