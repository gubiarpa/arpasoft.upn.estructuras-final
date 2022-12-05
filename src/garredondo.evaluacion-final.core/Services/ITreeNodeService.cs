using garredondo.evaluacion_final.core.Entities;

namespace garredondo.evaluacion_final.core.Services
{
    public interface ITreeNodeService<T>
    {
        /// <summary>
        /// Devuelve una lista de posibles soluciones de caminos de una celda a otra
        /// </summary>
        /// <param name="cellStart">Celda de inicio del camino</param>
        /// <param name="cellEnd">Celda de fin del camino</param>
        /// <returns></returns>
        IEnumerable<TreeNode<T>>? GetPaths(T cellStart, T cellEnd);
    }
}
