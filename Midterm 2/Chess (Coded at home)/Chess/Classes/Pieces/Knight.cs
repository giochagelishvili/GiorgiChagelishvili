namespace Chess.Classes.Pieces
{
    public class Knight : Piece
    {
        public Knight(int rowPosition, int columnPosition, string color) : base(rowPosition, columnPosition, color)
        {
            Name = "Knight";
        }

        public override void Move(int row = 0, int column = 0)
        {
            if (row != 0 && column != 0)
            {
                RowPosition = row;
                ColumnPosition = column;
            }
        }
    }
}
