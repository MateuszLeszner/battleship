namespace Battleship.FieldType
{
    public interface IFieldType
    {
        string Symbol { get; }
        ConsoleColor Color { get; }

        /// <summary>
        /// Draws a field of the board
        /// </summary>
        virtual void Draw()
        {
            // Why implementation is inside the interface? Because it's allowed since c# 8.

            Console.ForegroundColor = Color;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(Symbol);
        }
    }
}
