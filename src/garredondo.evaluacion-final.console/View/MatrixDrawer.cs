using garredondo.evaluacion_final.core.Entities;

namespace garredondo.evaluacion_final.console.View
{
    public class MatrixDrawer
    {
        private const string WAY_ACTIVE = "1";
        private const string WAY_INACTIVE = "0";
        private bool[,] _matrix;

        public MatrixDrawer(bool[,] matrix)
        {
            _matrix = matrix;
        }

        public void DrawMatrix()
        {
            if (!IsValidMatrix(_matrix))
                return;

            var rowSize = _matrix.GetLength(0);
            var colSize = _matrix.GetLength(1);

            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    var cell = _matrix[i, j];

                    Console.ForegroundColor = cell ? ConsoleColor.DarkRed : ConsoleColor.DarkBlue;
                    Console.Write(cell ? WAY_ACTIVE : WAY_INACTIVE);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine();
            }
        }

        public void DrawMatrixWithPath(IEnumerable<TreeNode<Cell>>? path)
        {

        }

        private bool IsValidMatrix(bool[,] matrix)
        {
            if (matrix == null)
                return false;

            if (matrix.GetLength(0) == 0)
                return false;

            if (matrix.GetLength(0) == 0)
                return false;

            if (matrix.GetLength(1) == 0)
                return false;

            return true;
        }
    }
}
