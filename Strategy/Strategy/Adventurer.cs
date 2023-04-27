namespace Strategy
{
    public class Adventurer
    {
        private IFlightStrategy flightStrategy;
        
        public string Attack(){
            // 預設為普通攻擊
            if(flightStrategy == null){
                flightStrategy = new NormalAttack();
            }
            
            return flightStrategy.Execute();
        }
        
        public void ChoiceStrategy(IFlightStrategy strategy){
            this.flightStrategy = strategy;
        }
    }
}