
using CommandV1;
using CommandV2;

class Program
{
    static void Main(string[] args)
    {
        AirConditioner ac = new AirConditioner();
        Fan fan = new Fan();
        Television tv = new Television();

        Controller controller = new Controller();
        // Dependency injection
        controller.SetCommand(0, new FanNextLevelCommand(fan));
        controller.SetCommand(1, new FanPreviousLevelCommand(fan));
        controller.SetCommand(2, new TurnOnAirConditionerCommand(ac));
        controller.SetCommand(3, new TurnOffAirConditionerCommand(ac));
        controller.SetCommand(4, new TurnOnTvCommand(tv));
        controller.SetCommand(5, new TurnOffTvCommand(tv));

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