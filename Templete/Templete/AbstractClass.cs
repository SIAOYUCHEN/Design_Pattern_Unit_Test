namespace Templete
{
    public abstract class AbstractClass
    {
        public abstract string PrimitiveOperation1();
        public abstract string PrimitiveOperation2();

        public string TemplateMethod()
        {
            return PrimitiveOperation1() + PrimitiveOperation2();
        }
    }
}