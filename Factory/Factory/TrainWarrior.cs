namespace Factory
{
    public class TrainWarrior : ITrainAdventure
    {
        public IAdventurer Training()
        {
            return new Warrior();
        }
    }
}