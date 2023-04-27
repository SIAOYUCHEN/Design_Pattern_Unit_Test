namespace AbstractFactory
{
    public abstract class Clothes
    {
        protected int Defence;    // 防禦力
        
        public void Display(){
            
        }

        public void SetDefence(int defence)
        {
            this.Defence = defence;
        }

        public int GetDefence()
        {
            return this.Defence;
        }
    }
}