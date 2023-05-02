namespace Proxy
{
    public class Proxy : Subject
    {
        private RealSubject realSubject;
        
        public override string Request()
        {
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }
            
            return realSubject.Request();
        }
    }
}