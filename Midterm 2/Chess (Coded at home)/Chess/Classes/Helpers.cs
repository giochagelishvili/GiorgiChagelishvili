using Chess.Classes.Pieces;
using Chess.Exceptions;
using System.Reflection.Metadata.Ecma335;

namespace Chess.Classes
{
    public static class Helpers
    {
        public static List<Piece> CreateBlackPieces()
        {
            List<Piece> pieces = new();

            // Add pawns to the list
            for (int i = 1; i <= 8; i++)
            {
                Piece pawn = new Pawn(7, i, "Black");
                pieces.Add(pawn);
            }

            // Add knights to the list
            pieces.Add(new Knight(8, 2, "Black"));
            pieces.Add(new Knight(8, 7, "Black"));

            // Add king to the list
            pieces.Add(new King(8, 5, "Black"));

            return pieces;
        }        
        
        public static List<Piece> CreateWhitePieces()
        {
            List<Piece> pieces = new();

            // Add pawns to the list
            for (int i = 1; i <= 8; i++)
            {
                Piece pawn = new Pawn(2, i, "White");
                pieces.Add(pawn);
            }

            // Add knights to the list
            pieces.Add(new Knight(1, 2, "White"));
            pieces.Add(new Knight(1, 7, "White"));

            // Add king to the list
            pieces.Add(new King(1, 5, "White"));

            return pieces;
        }

        public static string GetColor()
        {
            Console.WriteLine("Please choose color to play:");
            Console.WriteLine("1) White");
            Console.WriteLine("2) Black");

            int colorInput = 0;

            do
            {
                bool userInput = int.TryParse(Console.ReadLine(), out colorInput);

                if (!userInput)
                    Console.WriteLine("Please enter a number.");
                else if (colorInput < 1 || colorInput > 2)
                    Console.WriteLine("Please choose one of the above.");
            } while (colorInput < 1 || colorInput > 2);

            return colorInput == 1 ? "White" : "Black";
        }
    }
}
