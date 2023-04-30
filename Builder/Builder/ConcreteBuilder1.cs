namespace Builder
{
    public class ConcreteBuilder1 : Builder
    {
        Product product = new Product();
        public override void BuildPartA()
        {
            product.Add("PartA");
        }

        public override void BuildPartB()
        {
            product.Add("PartB");
        }

        public override Product GetResult()
        {
            return product;
        }
    }
}