namespace ChessBasics.Pieces
{
    public class Pawn : Piece
    {
        private bool FirstMove { get; set; } = true;

        public Pawn(string color, int rowPosition, int columnPosition, int number) : base(color, rowPosition, columnPosition, number)
        {
            PieceName = "Pawn";
        }
    }
}
