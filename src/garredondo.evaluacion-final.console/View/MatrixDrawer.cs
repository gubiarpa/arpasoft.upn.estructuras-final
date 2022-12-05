using garredondo.evaluacion_final.console.Matrix;
using garredondo.evaluacion_final.core.Entities;

namespace garredondo.evaluacion_final.console.View
{
    public class MatrixDrawer
    {
        #region Config
        private const string MAP_HEADER = "  0 1 2 3 4 5 6 7";
        private const string WAY_ACTIVE = "1 ";
        private const string WAY_INACTIVE = "0 ";
        #endregion

        #region Matrix
        private bool[,] _matrix;

        public MatrixDrawer(bool[,] matrix)
        {
            _matrix = matrix;
        }
        #endregion

        public void DrawMatrix()
        {
            if (!IsValidMatrix(_matrix))
                return;

            var rowSize = _matrix.GetLength(0);
            var colSize = _matrix.GetLength(1);

            Console.WriteLine("Mapa original:\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(MAP_HEADER);

            for (int i = 0; i < rowSize; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"{i} ");
                for (int j = 0; j < colSize; j++)
                {
                    var cellValue = _matrix[i, j];

                    Console.ForegroundColor = cellValue ? ConsoleColor.DarkCyan : ConsoleColor.DarkGray;
                    Console.Write(cellValue ? WAY_ACTIVE : WAY_INACTIVE);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine();
            }
        }

        public void DrawMatrixWithPath(IEnumerable<TreeNode<Cell>>? path)
        {

        }

        #region Helpers
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
        #endregion
    }
}
