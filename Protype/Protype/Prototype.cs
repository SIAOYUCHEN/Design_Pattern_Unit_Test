namespace Protype
{
    public abstract class Prototype
    {
        private readonly string _id;

        protected Prototype(string id)
        {
            _id = id;
        }

        public string Id
        {
            get { return _id; }
        }

        public abstract Prototype Clone();
    }
}