namespace Battleship.FieldType;

public struct Ship : IFieldType
{
    public readonly string Symbol => "#";
    public readonly ConsoleColor Color => ConsoleColor.Green;
}