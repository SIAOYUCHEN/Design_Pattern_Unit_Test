namespace Facade
{
    public class Facade
    {
        SubSystemOne one;
        SubSystemTwo two;
        SubSystemThree three;
        SubSystemFour four;

        public Facade()
        {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubSystemThree();
            four = new SubSystemFour();
        }

        public string MethodA()
        {
            return one.MethodOne() + two.MethodTwo() + four.MethodFour();
        }

        public string MethodB()
        {
            return two.MethodTwo()+ three.MethodThree();
        }
    }
}