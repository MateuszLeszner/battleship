using Battleship.FieldType;

namespace Battleship
{
    public class Board
    {
        public const int BOARD_SIZE = 12;

        public string Name { get; set; }

        private readonly IFieldType[,] _board = new IFieldType[BOARD_SIZE, BOARD_SIZE];

        public Board(string name)
        {
            Name = name;
            for (var col = 0; col < _board.GetLength(0); col++)
            {
                for (var row = 0; row < _board.GetLength(1); row++)
                {
                    _board[col, row] = new Water();
                }
            }
        }

        public IFieldType[,] GetBoard() => _board;

        public IFieldType GetField((int col, int row) position) => _board[position.col, position.row];

        public void SetField((int col, int row) position, IFieldType fieldType) => _board[position.col, position.row] = fieldType;

        public void Draw()
        {
            Console.WriteLine();
            Console.WriteLine(Name);

            DrawColumnHeaders();

            for (var row = 0; row < _board.GetLength(0); row++)
            {
                DrawRowHeader(row);
                for (var col = 0; col < _board.GetLength(1); col++)
                {
                    _board[col, row].Draw();
                }
                ConsoleHelpers.ResetColors();
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private void DrawRowHeader(int row)
        {
            Console.Write($"{row + 1,2} ");
        }

        private void DrawColumnHeaders()
        {
            Console.WriteLine("   ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(0, BOARD_SIZE + 3));
        }
    }
}
