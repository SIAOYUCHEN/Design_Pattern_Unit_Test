
using CommandV1;

class Program
{
    static void Main(string[] args)
    {
        AirConditioner ac = new AirConditioner();
        Fan fan = new Fan();
        Television tv = new Television();
        Controller controller = new Controller(ac, fan, tv);

        while (true)
        {
            Console.WriteLine("Click a button (0~5): ");
            if (int.TryParse(Console.ReadLine(), out int button))
            {
                try
                {
                    controller.Press(button);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
}