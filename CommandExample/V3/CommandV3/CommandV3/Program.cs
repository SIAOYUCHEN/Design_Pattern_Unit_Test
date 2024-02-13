
using CommandV1;
using CommandV3;

class Program
{
    static void Main(string[] args)
    {
        AirConditioner ac = new AirConditioner();
        Fan fan = new Fan();
        Television tv = new Television();

        Controller controller = new Controller();
        controller.SetCommand(0, new FanNextLevelCommand(fan));
        controller.SetCommand(1, new FanPreviousLevelCommand(fan));
        controller.SetCommand(2, new TurnOnAirConditionerCommand(ac));
        controller.SetCommand(3, new TurnOffAirConditionerCommand(ac));
        controller.SetCommand(4, new TurnOnTvCommand(tv));
        controller.SetCommand(5, new TurnOffTvCommand(tv));

        while (true)
        {
            Console.WriteLine("Click a button (0~5) or undo (-1) or redo (-2): ");
            if (int.TryParse(Console.ReadLine(), out int button))
            {
                switch (button)
                {
                    case -1:
                        controller.Undo();
                        break;
                    case -2:
                        controller.Redo();
                        break;
                    default:
                        controller.Press(button);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
}