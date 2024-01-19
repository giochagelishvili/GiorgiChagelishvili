namespace Chess.Classes
{
    public abstract class Piece
    {
        public string? Name { get; set; }
        public int RowPosition { get; set; }
        public int ColumnPosition { get; set; }
        public string Color { get; set; }
        public bool IsAlive { get; set; } = true;

        public Piece(int rowPosition, int columnPosition, string color)
        {
            RowPosition = rowPosition;
            ColumnPosition = columnPosition;
            Color = color;
        }

        public abstract void Move(int row = 0, int column = 0);
    }
}
