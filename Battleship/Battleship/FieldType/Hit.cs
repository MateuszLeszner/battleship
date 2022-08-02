namespace Battleship.FieldType;

public struct Hit : IFieldType
{
    public readonly string Symbol => "#";
    public readonly ConsoleColor Color => ConsoleColor.DarkRed;
}