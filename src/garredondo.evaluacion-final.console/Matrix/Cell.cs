namespace garredondo.evaluacion_final.console.Matrix
{
    public class Cell
    {
        private readonly int _row;
        private readonly int _col;

        public Cell(int row, int col)
        {
            _row = row;
            _col = col;
        }

        public int Row => _row;
        public int Col => _col;
    }
}
