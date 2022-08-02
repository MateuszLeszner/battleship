using Battleship.FieldType;

namespace Battleship
{
    public class ShipFactory
    {
        private readonly Random _rnd = new();

        public bool Create(IFieldType[,] board, int size)
        {
            for (var tries = 10; tries > 0; tries--)
            {
                var isHorizontal = _rnd.Next(2) == 0;

                var maxCol = isHorizontal
                    ? board.GetLength(0) - size
                    : board.GetLength(0);

                var maxRow = isHorizontal
                    ? board.GetLength(1)
                    : board.GetLength(1) - size;

                var col = _rnd.Next(maxCol);
                var row = _rnd.Next(maxRow);

                if (Create(board, size, (col, row), isHorizontal))
                    return true;
            }

            return false;
        }

        public bool Create(IFieldType[,] board, int size, (int col, int row) shipPosition, bool isHorizontal)
        {
            var shipPositions = new List<(int col, int row)>();
            for (var i = 0; i < size; i++)
            {
                shipPositions.Add((isHorizontal ? shipPosition.col + i : shipPosition.col, isHorizontal ? shipPosition.row : shipPosition.row + i));
            }

            var shipNeighborhood = shipPositions
                .Select(position => new (int col, int row)[]
                {
                    (position.col - 1, position.row - 1),
                    (position.col, position.row - 1),
                    (position.col + 1, position.row - 1),
                    (position.col - 1, position.row),
                    (position.col, position.row),
                    (position.col + 1, position.row),
                    (position.col - 1, position.row + 1),
                    (position.col, position.row + 1),
                    (position.col + 1, position.row + 1)
                })
                .SelectMany(position => position)
                .Distinct()
                .Where(position =>
                    position.col >= 0 && position.col < board.GetLength(0) &&
                    position.row >= 0 && position.row < board.GetLength(1))
                .ToList();

            if (IsPossibleToPlaceShip(board, shipNeighborhood))
            {
                CreateShip(board, shipPositions);
                return true;
            }

            return false;
        }

        private bool IsPossibleToPlaceShip(IFieldType[,] board, List<(int col, int row)> shipNeighborhood)
        {
            return shipNeighborhood.All(position => board[position.col, position.row] is Water);
        }

        private void CreateShip(IFieldType[,] board, List<(int col, int row)> shipPositions)
        {
            foreach (var position in shipPositions)
            {
                board[position.col, position.row] = new Ship();
            }
        }


    }
}
