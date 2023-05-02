namespace Proxy
{
    public class RealSubject : Subject
    {
        public override string Request()
        {
            return "RealSubjectRequest";
        }
    }
}