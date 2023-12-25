namespace ChessBasics.Pieces
{
    public class King : Piece
    {
        public King(string color, int rowPosition, int columnPosition) : base(color, rowPosition, columnPosition)
        {
            PieceName = "King";
            Number = 1;
        }
    }
}
