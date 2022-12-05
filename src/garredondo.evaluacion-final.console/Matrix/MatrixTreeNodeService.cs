using garredondo.evaluacion_final.infrastructure.Services;

namespace garredondo.evaluacion_final.console.Matrix
{
    public class MatrixTreeNodeService : TreeNodeService<Cell>
    {
        private readonly bool[,] _matrix;
        private readonly int _rowSize;
        private readonly int _colSize;

        public MatrixTreeNodeService(bool[,] matrix)
        {
            _matrix = matrix;
            _rowSize = matrix.GetLength(0);
            _colSize = matrix.GetLength(1);
        }

        protected override bool Equals(Cell? node1, Cell? node2)
        {
            if (!IsValidNode(node1))
                return false;

            if (!IsValidNode(node2))
                return false;

            return (node1!.Row == node2!.Row && node1!.Col == node2.Col);
        }

        protected override IEnumerable<Cell> GetAdjacentNodesByID(Cell node)
        {
            var adjacentNodes = new List<Cell>();

            /// Up
            if (node.Row > 0 && _matrix[node.Row - 1, node.Col])
                adjacentNodes.Add(new Cell(node.Row - 1, node.Col));

            /// Right
            if (node.Col < _colSize - 1 && _matrix[node.Row, node.Col + 1])
                adjacentNodes.Add(new Cell(node.Row, node.Col + 1));

            /// Down
            if (node.Row < _rowSize - 1 && _matrix[node.Row + 1, node.Col])
                adjacentNodes.Add(new Cell(node.Row + 1, node.Col));

            /// Left
            if (node.Col > 0 && _matrix[node.Row, node.Col - 1])
                adjacentNodes.Add(new Cell(node.Row, node.Col - 1));

            return adjacentNodes;
        }

        protected override bool IsValidNode(Cell? node)
        {
            if (node == null)
                return false;

            if (node.Row < 0)
                return false;

            if (node.Col < 0)
                return false;

            if (node.Row >= _rowSize)
                return false;

            if (node.Col >= _colSize)
                return false;

            return true;
        }
    }
}
