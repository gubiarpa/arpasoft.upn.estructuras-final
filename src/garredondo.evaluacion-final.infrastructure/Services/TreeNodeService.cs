using garredondo.evaluacion_final.core.Entities;
using garredondo.evaluacion_final.core.Enums;
using garredondo.evaluacion_final.core.Services;

namespace garredondo.evaluacion_final.infrastructure.Services
{
    public abstract class TreeNodeService<T> : ITreeNodeService<T>
    {
        public IEnumerable<TreeNode<T>>? GetPaths(T cellStart, T cellEnd)
        {
            if (!IsValidNode(cellStart))
                return null;

            if (!IsValidNode(cellEnd))
                return null;

            var rootNode = new TreeNode<T>(cellStart);

            var activeLeaves = new List<TreeNode<T>>() { rootNode };
            var matchedLeaves = new List<TreeNode<T>>();

            while (activeLeaves != null && activeLeaves.Count > 0)
            {
                ExploreLeaves(cellEnd, ref activeLeaves, ref matchedLeaves);
            }

            return matchedLeaves;
        }

        /// <summary>
        /// A partir de una lista de nodos en estado Active, devuelve otra lista de los nodos hijos
        /// </summary>
        /// <param name="searchedCell">Nodo buscado</param>
        /// <param name="activeLeaves">Lista de nodos en estado Active (se volverá a explorar)</param>
        /// <param name="matchedLeaves">Lista de nodos en estado Matched (cuando coincide con el nodo buscado)</param>
        private void ExploreLeaves(T searchedCell, ref List<TreeNode<T>> activeLeaves, ref List<TreeNode<T>> matchedLeaves)
        {
            if (activeLeaves == null || activeLeaves.Count == 0)
                return;

            var newLeaves = new List<TreeNode<T>>();

            foreach (var leaf in activeLeaves)
            {
                if (leaf == null || leaf.Data == null)
                    continue;

                var adjacentsNodes = GetAdjacentNodesByID(leaf.Data);

                if (adjacentsNodes == null)
                    continue;

                foreach (var adjacentNode in adjacentsNodes)
                {
                    var newLeaf = new TreeNode<T>(adjacentNode, leaf!);
                    leaf?.Children?.Add(newLeaf);
                    newLeaf.State = SetState(searchedCell, newLeaf);

                    switch (newLeaf.State)
                    {
                        case TreeNodeState.Active:
                            newLeaves.Add(newLeaf);
                            break;
                        case TreeNodeState.Matched:
                            matchedLeaves.Add(newLeaf);
                            break;
                    }
                }
            }

            activeLeaves = newLeaves;
        }

        #region Abstract
        /// <summary>
        /// Valida si el nodo es válido (lógica depende de clase derivada)
        /// </summary>
        /// <returns>true si el nodo es válido; false, en caso contrario</returns>
        protected abstract bool IsValidNode(T? node);

        /// <summary>
        /// Valida si dos nodos son el mismo
        /// </summary>
        /// <param name="node1">Nodo 1</param>
        /// <param name="node2">Nodo 2</param>
        /// <returns>true si ambos nodos son el mismo nodo; false, en caso contrario</returns>
        protected abstract bool Equals(T? node1, T? node2);

        /// <summary>
        /// Devuelve la lista de nodo adyacentes a un nodo específico
        /// </summary>
        /// <param name="node">Nodo a consultar</param>
        /// <returns>Lista de nodos adyacentes</returns>
        protected abstract IEnumerable<T> GetAdjacentNodesByID(T node);
        #endregion

        #region Utils
        /// <summary>
        /// Establece el estado de un nodo según el valor que contenga
        /// </summary>
        /// <param name="searchedNode">Nodo buscado</param>
        /// <param name="node">Nodo a analizar</param>
        /// <returns></returns>
        private TreeNodeState SetState(T searchedNode, TreeNode<T> node)
        {
            if (Equals(node.Data, searchedNode))
                return TreeNodeState.Matched;

            var nodeRun = node.Parent;

            while (nodeRun != null)
            {
                if (Equals(node.Data, nodeRun.Data))
                    return TreeNodeState.Loop;
                else
                    nodeRun = nodeRun.Parent;
            }

            return TreeNodeState.Active;
        }
        #endregion
    }
}
