namespace Chess.Classes.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(int rowPosition, int columnPosition, string color) : base(rowPosition, columnPosition, color)
        {
            Name = "Pawn";
        }

        public override void Move(int row = 0, int column = 0)
        {
            if (Color == "Black")
                RowPosition--;

            if (Color == "White")
                RowPosition++;

            if (column != 0)
                ColumnPosition = column;
        }
    }
}
