namespace Chess.Classes.Pieces
{
    public class King : Piece
    {
        public King(int rowPosition, int columnPosition, string color) : base(rowPosition, columnPosition, color)
        {
            Name = "King";
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
