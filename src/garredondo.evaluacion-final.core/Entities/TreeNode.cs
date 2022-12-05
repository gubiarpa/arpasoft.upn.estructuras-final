using garredondo.evaluacion_final.core.Enums;

namespace garredondo.evaluacion_final.core.Entities
{
    public class TreeNode<T>
    {
        #region Attributes
        private readonly T? _data;
        private readonly TreeNode<T>? _parent;
        private readonly List<TreeNode<T>>? _children;
        #endregion

        #region Constructors
        public TreeNode(T data)
        {
            _data = data;
            _parent = null;
            _children = new List<TreeNode<T>>();
        }

        public TreeNode(T data, TreeNode<T> parent) : this(data)
        {
            _parent = parent;
        }
        #endregion

        #region Readonly
        public T? Data => _data;
        public TreeNode<T>? Parent => _parent;
        public List<TreeNode<T>>? Children => _children;
        #endregion

        #region Properties
        public TreeNodeState State { get; set; }
        #endregion
    }
}
