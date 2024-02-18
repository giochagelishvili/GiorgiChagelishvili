using Chess.Exceptions;

namespace Chess.Classes
{
    public class Game
    {
        private bool GameOver { get; set; } = false;
        private List<Piece>? BlackPieces { get; set; } = Helpers.CreateBlackPieces();
        private List<Piece>? WhitePieces { get; set; } = Helpers.CreateWhitePieces();

        public void Start()
        {
            do
            {
                string color = Helpers.GetColor();

                if (color == "Black")
                    PlayBlack();
                else if (color == "White")
                    PlayWhite();
            } while (GameOver == false);
        }

        private void PlayBlack()
        {
            Piece piece = BlackPieces[GetPieceIndex("Black") - 1];

            if (piece.Name == "Pawn")
                PlayPawn(piece);
            else if (piece.Name == "Knight")
                PlayKnight(piece);            
            else if(piece.Name == "King")
                PlayKing(piece);
        }
        private void PlayWhite()
        {
            int pieceIndex = GetPieceIndex("White");

            Piece piece = WhitePieces[pieceIndex - 1];

            if (piece.Name == "Pawn")
                PlayPawn(piece);

            if (piece.Name == "Knight")
                PlayKnight(piece);

            if (piece.Name == "King")
                PlayKing(piece);
        }

        private void PlayPawn(Piece piece)
        {
            bool canMoveForward = true;
            bool canKill = false;

            List<int> columnToKill = new();

            if (piece.Color == "Black")
            {
                foreach (Piece otherPiece in BlackPieces)
                {
                    // If front is clear
                    if (otherPiece.ColumnPosition == piece.ColumnPosition && otherPiece.RowPosition == piece.RowPosition - 1)
                        canMoveForward = false;

                    // If there are pieces to kill
                    if ((otherPiece.ColumnPosition == piece.ColumnPosition - 1 || otherPiece.ColumnPosition == piece.ColumnPosition + 1) && (otherPiece.RowPosition == piece.RowPosition - 1) && otherPiece.Color != piece.Color && otherPiece.Name != "King")
                    {
                        canKill = true;
                        columnToKill.Add(otherPiece.ColumnPosition);
                    }
                }

                foreach (Piece otherPiece in WhitePieces)
                {
                    // Check if front is clear
                    if (otherPiece.ColumnPosition == piece.ColumnPosition && otherPiece.RowPosition == piece.RowPosition - 1)
                        canMoveForward = false;

                    // Check if there are any pieces to kill
                    if ((otherPiece.ColumnPosition == piece.ColumnPosition - 1 || otherPiece.ColumnPosition == piece.ColumnPosition + 1) && (otherPiece.RowPosition == piece.RowPosition - 1) && otherPiece.Color != piece.Color && otherPiece.Name != "King")
                    {
                        canKill = true;
                        columnToKill.Add(otherPiece.ColumnPosition);
                    }
                }

                // Check if piece is at the edge of board
                if (piece.RowPosition - 1 <= 0)
                    canMoveForward = false;
            }
            else if (piece.Color == "White")
            {
                foreach (Piece otherPiece in BlackPieces)
                {
                    // Check if front is clear
                    if (otherPiece.ColumnPosition == piece.ColumnPosition && otherPiece.RowPosition == piece.RowPosition + 1)
                        canMoveForward = false;

                    // Check if there are any pieces to kill
                    if ((otherPiece.ColumnPosition == piece.ColumnPosition - 1 || otherPiece.ColumnPosition == piece.ColumnPosition + 1) && (otherPiece.RowPosition == piece.RowPosition + 1) && otherPiece.Color != piece.Color && otherPiece.Name != "King")
                    {
                        canKill = true;
                        columnToKill.Add(otherPiece.ColumnPosition);
                    }
                }

                foreach (Piece otherPiece in WhitePieces)
                {
                    // Check if front is clear
                    if (otherPiece.ColumnPosition == piece.ColumnPosition && otherPiece.RowPosition == piece.RowPosition + 1)
                        canMoveForward = false;

                    // Check if there are any pieces to kill
                    if ((otherPiece.ColumnPosition == piece.ColumnPosition - 1 || otherPiece.ColumnPosition == piece.ColumnPosition + 1) && (otherPiece.RowPosition == piece.RowPosition + 1) && otherPiece.Color != piece.Color && otherPiece.Name != "King")
                    {
                        canKill = true;
                        columnToKill.Add(otherPiece.ColumnPosition);
                    }
                }

                // Check if piece is at the edge of the board
                if (piece.RowPosition + 1 > 8)
                    canMoveForward = false;
            }

            if (!canKill && !canMoveForward)
            {
                Console.WriteLine("This pawn is blocked.");
                return;
            }

            int indexer = 1;

            // Available moves
            Dictionary<int, string> moves = new();

            if (canMoveForward)
            {
                if (piece.Color == "Black")
                    Console.WriteLine($"{indexer}) Move to {piece.RowPosition - 1}, {piece.ColumnPosition}");
                else if (piece.Color == "White")
                    Console.WriteLine($"{indexer}) Move to {piece.RowPosition + 1}, {piece.ColumnPosition}");

                moves.Add(indexer, "Move");
                indexer++;
            }
            
            if (canKill)
            {   
                if (piece.Color == "Black")
                    Console.WriteLine($"{indexer}) Kill at {piece.RowPosition - 1}, {columnToKill[0]}");
                else if (piece.Color == "White")
                    Console.WriteLine($"{indexer}) Kill at {piece.RowPosition + 1}, {columnToKill[0]}");

                moves.Add(indexer, "Kill Left");
                indexer++;
            }
                
            if (canKill && columnToKill.Count > 1)
            {
                if (piece.Color == "Black")
                    Console.WriteLine($"{indexer}) Kill at {piece.RowPosition - 1}, {columnToKill[1]}");
                else if (piece.Color == "White")
                    Console.WriteLine($"{indexer}) Kill at {piece.RowPosition + 1}, {columnToKill[1]}");

                moves.Add(indexer, "Kill Right");
            }

            int playInput = 0;

            do
            {
                try
                {
                    bool userInput = int.TryParse(Console.ReadLine(), out playInput);

                    if (!userInput)
                        throw new InvalidInputException("Please enter a number.");
                    else if (playInput < 1 || playInput > moves.Count)
                        throw new InvalidInputException("Please choose one of the above.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (playInput < 1 || playInput > moves.Count);

            if (moves[playInput] == "Move")
                piece.Move();

            if (moves[playInput] == "Kill Left")
            {
                piece.Move(0, columnToKill[0]);

                if (piece.Color == "Black")
                    WhiteKilled(piece.RowPosition, piece.ColumnPosition);
                else if (piece.Color == "White")
                    BlackKilled(piece.RowPosition, piece.ColumnPosition);
            }

            if (moves[playInput] == "Kill Right")
            {
                piece.Move(0, columnToKill[1]);
                
                if (piece.Color == "Black")
                    WhiteKilled(piece.RowPosition, piece.ColumnPosition);
                else if (piece.Color == "White")
                    BlackKilled(piece.RowPosition, piece.ColumnPosition);
            }
        }
        private void PlayKnight(Piece piece)
        {
            int currentColumn = piece.ColumnPosition;
            int currentRow = piece.RowPosition;

            int indexer = 1;

            Dictionary<int, string> moves = new();
            Dictionary<int, int[]> positions = new();

            if (AvailableSquare(currentRow + 1, currentColumn + 2) && currentRow + 1 <= 8 && currentColumn + 2 <= 8)
            {
                moves.Add(indexer, $"Move to {currentRow + 1}, {currentColumn + 2}");
                positions.Add(indexer, new int[] {currentRow + 1, currentColumn + 2});
                indexer++;
            }
            else if (CanKill(currentRow + 1, currentColumn + 2, piece.Color))
            {
                moves.Add(indexer, $"Kill at {currentRow + 1}, {currentColumn + 2}");
                positions.Add(indexer, new int[] { currentRow + 1, currentColumn + 2 });
                indexer++;
            }

            if (AvailableSquare(currentRow + 2, currentColumn + 1) && currentRow + 2 <= 8 && currentColumn + 1 <= 8)
            {
                moves.Add(indexer, $"Move to {currentRow + 2}, {currentColumn + 1}");
                positions.Add(indexer, new int[] { currentRow + 2, currentColumn + 1});
                indexer++;
            }
            else if (CanKill(currentRow + 2, currentColumn + 1, piece.Color))
            {
                moves.Add(indexer, $"Kill at {currentRow + 2}, {currentColumn + 1}");
                positions.Add(indexer, new int[] { currentRow + 2, currentColumn + 1 });
                indexer++;
            }

            if (AvailableSquare(currentRow + 1, currentColumn - 2) && currentRow + 1 <= 8 && currentColumn - 2 >= 1)
            {
                moves.Add(indexer, $"Move to {currentRow + 1}, {currentColumn - 2}");
                positions.Add(indexer, new int[] { currentRow + 1, currentColumn - 2 });
                indexer++;
            }
            else if (CanKill(currentRow + 1, currentColumn - 2, piece.Color))
            {
                moves.Add(indexer, $"Kill at {currentRow + 1}, {currentColumn - 2}");
                positions.Add(indexer, new int[] { currentRow + 1, currentColumn - 2 });
                indexer++;
            }

            if (AvailableSquare(currentRow + 2, currentColumn - 1) && currentRow + 2 <= 8 && currentColumn - 1 >= 1)
            {
                moves.Add(indexer, $"Move to {currentRow + 2}, {currentColumn - 1}");
                positions.Add(indexer, new int[] { currentRow + 2, currentColumn - 1 });
                indexer++;
            }
            else if(CanKill(currentRow + 2, currentColumn - 1, piece.Color))
            {
                moves.Add(indexer, $"Kill at {currentRow + 2}, {currentColumn - 1}");
                positions.Add(indexer, new int[] { currentRow + 2, currentColumn - 1 });
                indexer++;
            }

            if (AvailableSquare(currentRow - 1, currentColumn + 2) && currentRow - 1 >= 1 && currentColumn + 2 <= 8)
            {
                moves.Add(indexer, $"Move to {currentRow - 1}, {currentColumn + 2}");
                positions.Add(indexer, new int[] { currentRow - 1, currentColumn + 2 });
                indexer++;
            }
            else if (CanKill(currentRow - 1, currentColumn + 2, piece.Color))
            {
                moves.Add(indexer, $"Kill at {currentRow - 1}, {currentColumn + 2}");
                positions.Add(indexer, new int[] { currentRow - 1, currentColumn + 2 });
                indexer++;
            }

            if (AvailableSquare(currentRow - 2, currentColumn + 1) && currentRow - 2 >= 1 && currentColumn + 1 <= 8)
            {
                moves.Add(indexer, $"Move to {currentRow - 2}, {currentColumn + 1}");
                positions.Add(indexer, new int[] { currentRow - 2, currentColumn + 1 });
                indexer++;
            }
            else if (CanKill(currentRow - 2, currentColumn + 1, piece.Color))
            {
                moves.Add(indexer, $"Kill at {currentRow - 2}, {currentColumn + 1}");
                positions.Add(indexer, new int[] { currentRow - 2, currentColumn + 1 });
                indexer++;
            }

            if (AvailableSquare(currentRow - 1, currentColumn - 2) && currentRow - 1 >= 1 && currentColumn - 2 >= 1)
            {
                moves.Add(indexer, $"Move to {currentRow + 1}, {currentColumn - 2}");
                positions.Add(indexer, new int[] { currentRow - 1, currentColumn - 2 });
                indexer++;
            }
            else if (CanKill(currentRow - 1, currentColumn - 2, piece.Color))
            {
                moves.Add(indexer, $"Kill at {currentRow + 1}, {currentColumn - 2}");
                positions.Add(indexer, new int[] { currentRow - 1, currentColumn - 2 });
                indexer++;
            }

            if (AvailableSquare(currentRow - 2, currentColumn - 1) && currentRow - 2 >= 1 && currentColumn - 1 >= 1)
            {
                moves.Add(indexer, $"Move to {currentRow - 2}, {currentColumn - 1}");
                positions.Add(indexer, new int[] { currentRow - 2, currentColumn - 1 });
                indexer++;
            }
            else if (CanKill(currentRow - 2, currentColumn - 1, piece.Color))
            {
                moves.Add(indexer, $"Move to {currentRow - 2}, {currentColumn - 1}");
                positions.Add(indexer, new int[] { currentRow - 2, currentColumn - 1 });
                indexer++;
            }

            if (moves.Count == 0)
            {
                Console.WriteLine("This knight is stuck.");
                return;
            }

            for (int i = 1; i < indexer; i++)
                Console.WriteLine($"{i}) {moves[i]}");

            int moveInput = 0;

            do
            {
                try
                {
                    bool userInput = int.TryParse(Console.ReadLine(), out moveInput);

                    if (!userInput)
                        throw new InvalidInputException("Please enter a number.");
                    else if (moveInput < 1 || moveInput > indexer - 1)
                        throw new InvalidInputException("Please choose one of the above.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (moveInput < 1 || moveInput > indexer - 1);

            int row = positions[moveInput][0];
            int column = positions[moveInput][1];

            if (CanKill(row, column, piece.Color))
            {
                piece.Move(row, column);

                if (piece.Color == "White")
                    BlackKilled(row, column);
                else if (piece.Color == "Black")
                    WhiteKilled(row, column);
            }
            else
            {
                piece.Move(row, column);
            }
        }
        private void PlayKing(Piece piece)
        {
            int row = piece.RowPosition;
            int column = piece.ColumnPosition;

            Dictionary<int, string> moves = new();
            Dictionary<int, int[]> positions = new();

            int indexer = 1;

            // Back one square
            if (AvailableSquare(row - 1, column) && row - 1 >= 1)
            {
                moves.Add(indexer, $"Move to {row - 1}, {column}");
                positions.Add(indexer, new int[] { row - 1, column });
                indexer++;
            }
            else if (CanKill(row - 1, column, piece.Color))
            {
                moves.Add(indexer, $"Kill at {row - 1}, {column}");
                positions.Add(indexer, new int[] { row - 1, column });
                indexer++;
            }

            // Front one square
            if (AvailableSquare(row + 1, column) && row + 1 <= 8)
            {
                moves.Add(indexer, $"Move to {row + 1}, {column}");
                positions.Add(indexer, new int[] { row + 1, column });
                indexer++;
            }
            else if (CanKill(row + 1, column, piece.Color))
            {
                moves.Add(indexer, $"Kill at {row + 1}, {column}");
                positions.Add(indexer, new int[] { row + 1, column });
                indexer++;
            }

            // Left one square
            if (AvailableSquare(row, column - 1) && column - 1 >= 1)
            {
                moves.Add(indexer, $"Move to {row}, {column - 1}");
                positions.Add(indexer, new int[] { row, column - 1});
                indexer++;
            }
            else if (CanKill(row, column - 1, piece.Color))
            {
                moves.Add(indexer, $"Kill at {row}, {column - 1}");
                positions.Add(indexer, new int[] { row, column - 1});
                indexer++;
            }

            // Right one square
            if (AvailableSquare(row, column + 1) && column + 1 <= 8)
            {
                moves.Add(indexer, $"Move to {row}, {column + 1}");
                positions.Add(indexer, new int[] {row,  column + 1});
                indexer++;
            }
            else if (CanKill(row, column + 1, piece.Color))
            {
                moves.Add(indexer, $"Kill at {row}, {column + 1}");
                positions.Add(indexer, new int[] { row, column + 1 });
                indexer++;
            }

            // Front and left square
            if (AvailableSquare(row + 1, column - 1) && row + 1 <= 8 && column - 1 >= 1)
            {
                moves.Add(indexer, $"Move to {row + 1}, {column - 1}");
                positions.Add(indexer, new int[] { row + 1, column - 1 });
                indexer++;
            }
            else if (CanKill(row + 1, column - 1, piece.Color))
            {
                moves.Add(indexer, $"Kill at {row + 1}, {column - 1}");
                positions.Add(indexer, new int[] { row + 1, column - 1 });
                indexer++;
            }

            // Front and right square
            if (AvailableSquare(row + 1, column + 1) && row + 1 <= 8 && column + 1 <= 8)
            {
                moves.Add(indexer, $"Move to {row + 1}, {column + 1}");
                positions.Add(indexer, new int[] { row + 1, column + 1 });
                indexer++;
            }
            else if (CanKill(row + 1, column + 1, piece.Color))
            {
                moves.Add(indexer, $"Kill at {row + 1}, {column + 1}");
                positions.Add(indexer, new int[] { row + 1, column + 1 });
                indexer++;
            }

            // Back and left square
            if (AvailableSquare(row - 1, column - 1) && row - 1 >= 1 && column - 1 >= 1)
            {
                moves.Add(indexer, $"Move to {row - 1}, {column - 1}");
                positions.Add(indexer, new int[] { row - 1, column - 1 });
                indexer++;
            }
            else if (CanKill(row - 1, column - 1, piece.Color))
            {
                moves.Add(indexer, $"Kill at {row - 1}, {column - 1}");
                positions.Add(indexer, new int[] { row - 1, column - 1 });
                indexer++;
            }

            // Back and right square
            if (AvailableSquare(row - 1, column + 1) && row - 1 >= 1 && column + 1 <= 8)
            {
                moves.Add(indexer, $"Move to {row - 1}, {column + 1}");
                positions.Add(indexer, new int[] { row - 1, column + 1 });
                indexer++;
            }
            else if (CanKill(row - 1, column + 1, piece.Color))
            {
                moves.Add(indexer, $"Kill at {row - 1}, {column + 1}");
                positions.Add(indexer, new int[] { row - 1, column + 1 });
                indexer++;
            }

            if (moves.Count == 0)
            {
                Console.WriteLine("King is stuck.");
                return;
            }

            for (int i = 1; i < indexer; i++)
                Console.WriteLine($"{i}) {moves[i]}");

            int moveInput;

            do
            {
                bool userInput = int.TryParse(Console.ReadLine(), out moveInput);

                if (!userInput)
                    throw new InvalidInputException("Please enter a number.");
                else if (moveInput < 1 || moveInput > indexer)
                    throw new InvalidInputException("Please choose one of the above.");
            } while (moveInput < 1 || moveInput > indexer);

            int newRow = positions[moveInput][0];
            int newColumn = positions[moveInput][1];

            piece.Move(newRow, newColumn);
        }

        private void WhiteKilled(int row, int column)
        {
            for (int i = 0; i < WhitePieces.Count; i++)
            {
                if (WhitePieces[i].RowPosition == row && WhitePieces[i].ColumnPosition == column)
                    WhitePieces.RemoveAt(i);
            }
        }
        private void BlackKilled(int row, int column)
        {
            for (int i = 0; i < BlackPieces.Count; i++)
            {
                if (BlackPieces[i].RowPosition == row && BlackPieces[i].ColumnPosition == column)
                    BlackPieces.RemoveAt(i);
            }
        }

        private int GetPieceIndex(string color)
        {
            int indexer = 1;

            if (color == "Black")
            {
                foreach (Piece piece in BlackPieces)
                {
                    if (piece.IsAlive)
                    {
                        Console.WriteLine($"{indexer}) {piece.Name} ({piece.RowPosition}, {piece.ColumnPosition})");
                        indexer++;
                    }
                }
            }
            else if (color == "White")
            {
                foreach (Piece piece in WhitePieces)
                {
                    if (piece.IsAlive)
                    {
                        Console.WriteLine($"{indexer}) {piece.Name} ({piece.RowPosition}, {piece.ColumnPosition})");
                        indexer++;
                    }
                }
            }

            Console.WriteLine("Please choose piece to play:");

            int pieceIndex = 0;

            do
            {
                try
                {
                    bool userInput = int.TryParse(Console.ReadLine(), out pieceIndex);

                    if (!userInput)
                        throw new InvalidInputException("Please enter a number.");
                    else if (pieceIndex < 1 || pieceIndex > indexer - 1)
                        throw new InvalidInputException("Please choose one of the above.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (pieceIndex < 1 || pieceIndex > indexer - 1);

            return pieceIndex;
        }
        private bool AvailableSquare(int row, int column)
        {
            bool available = true;

            foreach (Piece piece in BlackPieces)
                if (piece.RowPosition == row && piece.ColumnPosition == column)
                    available = false;

            foreach (Piece piece in WhitePieces)
                if (piece.RowPosition == row && piece.ColumnPosition == column)
                    available = false;

            return available;
        }
        private bool CanKill(int row, int column, string color)
        {
            foreach (Piece piece in BlackPieces)
            {
                if (piece.RowPosition == row && piece.ColumnPosition == column && piece.Color != color && piece.Name != "King")
                    return true;
            }

            foreach (Piece piece in WhitePieces)
            {
                if (piece.RowPosition == row && piece.ColumnPosition == column && piece.Color != color && piece.Name != "King")
                    return true;
            }

            return false;
        }
    }
}
