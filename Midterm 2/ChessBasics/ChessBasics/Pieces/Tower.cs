namespace ChessBasics.Pieces
{
    public class Tower : Piece
    {
        public Tower(string color, int rowPosition, int columnPosition, int number) : base(color, rowPosition, columnPosition, number)
        {
            PieceName = "Tower";
        }
    }
}
