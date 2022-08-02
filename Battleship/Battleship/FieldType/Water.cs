namespace Battleship.FieldType;

public struct Water : IFieldType
{
    public readonly string Symbol => " ";
    public readonly ConsoleColor Color => ConsoleColor.DarkBlue;
}