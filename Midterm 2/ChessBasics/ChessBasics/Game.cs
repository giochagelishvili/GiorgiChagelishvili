using ChessBasics.Pieces;

namespace ChessBasics
{
    public class Game
    {
        private List<Piece> pieces = CreatePieces();

        public void StartGame()
        {
            string color = ChooseColor();
            string piece = ChoosePiece();
            int pieceNumber = ChoosePieceNumber(piece, color);
        }

        private void GetPieces()
        {
            string color = ChooseColor();

            foreach(var piece in pieces)
            {
                if (piece.Color == color)
                    Console.WriteLine(piece.PieceName);
            }
        }

        private int ChoosePieceNumber(string chosenPiece, string chosenColor)
        {
            int indexer = 1;

            foreach(var item in pieces)
            {
                if (item.PieceName == chosenPiece && item.Color == chosenColor)
                {
                    Console.WriteLine($"{indexer}) {item.Number}");
                    indexer++;
                }
            }

            Console.WriteLine("Type \"info\" to see pieces.");

            int pieceNumber = 0;

            while(pieceNumber < 1 || pieceNumber > indexer - 1)
            {
                string input = Console.ReadLine();

                if (input == "info")
                    GetPieces();

                int.TryParse(input, out pieceNumber);
            }

            return pieceNumber;
        }

        private static string ChoosePiece()
        {
            Console.WriteLine("Please choose piece:");
            Console.WriteLine("1) Pawn");
            Console.WriteLine("2) Knight");
            Console.WriteLine("3) Tower");
            Console.WriteLine("4) King");

            int pieceInput = 0;

            while (pieceInput != 1 && pieceInput != 2 && pieceInput != 3 && pieceInput != 4)
            {
                int.TryParse(Console.ReadLine(), out pieceInput);
            }

            if (pieceInput == 1)
                return "Pawn";
            if (pieceInput == 2)
                return "Knight";
            if (pieceInput == 3)
                return "Tower";
            else
                return "King";
        }

        private static List<Piece> CreatePieces()
        {
            string white = "White";
            string black = "Black";

            List<Piece> pieces = new List<Piece>();

            // create white pawns
            for (int i = 1; i <= 8; i++)
            {
                Pawn pawn = new Pawn(white, 2, i, i);
                pieces.Add(pawn);
            }

            // create black pawns
            for (int i = 1; i <= 8; i++)
            {
                Pawn pawn = new Pawn(black, 7, i, i);
                pieces.Add(pawn);
            }

            // create white towers
            Tower firstWhiteTower = new Tower(white, 1, 1, 1);
            Tower secondWhiteTower = new Tower(white, 1, 8, 2);

            pieces.Add(firstWhiteTower);
            pieces.Add(secondWhiteTower);

            // create black towers
            Tower firstBlackTower = new Tower(black, 8, 1, 1);
            Tower secondBlackTower = new Tower(black, 8, 8, 2);

            pieces.Add(firstBlackTower);
            pieces.Add(secondBlackTower);

            // create white knights
            Knight firstWhiteKnight = new Knight(white, 1, 2, 1);
            Knight secondWhiteKnight = new Knight(white, 1, 7, 2);

            pieces.Add(firstWhiteKnight);
            pieces.Add(secondWhiteKnight);

            // create black knights
            Knight firstBlackKnight = new Knight(black, 7, 2, 1);
            Knight secondBlackKnight = new Knight(black, 7, 7, 2);

            pieces.Add(firstBlackKnight);
            pieces.Add(secondBlackKnight);

            // white king
            King whiteKing = new King(white, 1, 4);

            pieces.Add(whiteKing);

            // black king
            King blackKing = new King(black, 7, 5);

            pieces.Add(blackKing);

            return pieces;
        }

        private static string ChooseColor()
        {
            Console.WriteLine("Please choose color:");
            Console.WriteLine("1) White");
            Console.WriteLine("2) Black");

            int colorInput = 0;

            while (colorInput != 1 && colorInput != 2)
            {
                int.TryParse(Console.ReadLine(), out colorInput);
            }

            return colorInput == 1 ? "White" : "Black";
        }
    }
}
