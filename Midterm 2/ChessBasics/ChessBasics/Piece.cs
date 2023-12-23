namespace ChessBasics
{
    public class Piece
    {
        public string Color {  get; set; }
        protected int RowPosition { get; set; }
        protected int ColumnPosition { get; set; }
        protected bool IsAlive { get; set; } = true;
        public int Number { get; set; }

        public string PieceName { get; set; }

        protected Guid Identifier = Guid.NewGuid();

        public Piece(string color, int rowPosition, int columnPosition, int number)
        {
            Color = color;
            RowPosition = rowPosition;
            ColumnPosition = columnPosition;
            Number = number;
        }

        public Piece(string color, int rowPosition, int columnPosition)
        {
            Color = color;
            RowPosition = rowPosition;
            ColumnPosition = columnPosition;
        }
    }
}
