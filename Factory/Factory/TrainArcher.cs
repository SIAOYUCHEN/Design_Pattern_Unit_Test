namespace Factory
{
    public class TrainArcher : ITrainAdventure
    {
        public IAdventurer Training()
        {
            return new Archer();
        }
    }
}