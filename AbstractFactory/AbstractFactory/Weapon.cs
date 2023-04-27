namespace AbstractFactory
{
    public abstract class Weapon
    {
        protected int Attack;        // 攻擊力
        protected int Range;   // 攻擊範圍
        
        public void Display(){
            
        }

        public void SetAttack(int attack)
        {
            this.Attack = attack;
        }

        public int GetAttack()
        {
            return this.Attack;
        }

        public void SetRange(int range)
        {
            this.Range = range;
        }

        public int GetRange()
        {
            return this.Range;
        }
    }
}