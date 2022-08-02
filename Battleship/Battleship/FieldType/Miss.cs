namespace Battleship.FieldType;

public struct Miss : IFieldType
{
    public readonly string Symbol => "o";

    public readonly ConsoleColor Color => ConsoleColor.Blue;
}