namespace ConsoleApp3;

public class Card
{
    public int Number { get; }
    public Color Color { get; }

    public Card(int number, Color color)
    {
        Number = ValidateNumber(number);
        Color = color;
    }

    private int ValidateNumber(int number)
    {
        if (number < 0 || number > 9)
        {
            throw new ArgumentException("The number must be within 0~9.");
        }
        return number;
    }

    public override string ToString()
    {
        return $"{Color}-{Number}";
    }
}

public enum Color
{
    Blue, Red, Yellow, Green
}