namespace CommandV1;

public class Controller
{
    private readonly AirConditioner _ac;
    private readonly Fan _fan;
    private readonly Television _tv;

    public Controller(AirConditioner ac, Fan fan, Television tv)
    {
        _ac = ac;
        _fan = fan;
        _tv = tv;
    }

    public void Press(int button)
    {
        switch (button)
        {
            case 0:
                _fan.NextLevel();
                break;
            case 1:
                _fan.PreviousLevel();
                break;
            case 2:
                _ac.TurnOn();
                break;
            case 3:
                _ac.TurnOff();
                break;
            case 4:
                _tv.TurnOn();
                break;
            case 5:
                _tv.TurnOff();
                break;
            default:
                throw new ArgumentException("Non-recognizable button.");
        }
    }
}