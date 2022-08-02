namespace Battleship
{
    public static class ConsoleHelpers
    {
        public static void ResetColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ShowHeader()
        {
            //Console.Clear();
            Console.WriteLine("Battleships by Mateusz Leszner");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
        }

        public static (int col, int row) AskForInput()
        {
            Console.Write("Enter your aim: ");
            var input = Console.ReadLine();
            try
            {
                return ParseInput(input);
            }
            catch (ArgumentException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Use values like: A1");
                Console.ForegroundColor = ConsoleColor.White;
                return AskForInput();
            }
        }

        private static (int col, int row) ParseInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length > 3 || input.Length == 1)
            {
                throw new ArgumentException("Wrong user input");
            }

            try
            {
                var col = input.ToUpper()[0] - 65; // to get col number from a char
                var row = int.Parse(input.Substring(1, input.Length - 1)) - 1;
                if (col >= Board.BOARD_SIZE || row >= Board.BOARD_SIZE)
                {
                    throw new ArgumentException("Wrong user input");
                }
                return (col, row);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Wrong user input", e);
            }
        }
    }
}
