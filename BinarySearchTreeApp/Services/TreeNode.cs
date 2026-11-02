namespace BinarySearchTreeApp.Services;

/// <summary>
/// Nodo del árbol binario de búsqueda.
/// Cada nodo se crea en el Heap con 'new' y se enlaza a sus hijos
/// mediante referencias (los "punteros" de C#).
/// </summary>
public class TreeNode
{
    /// <summary>
    /// Valor almacenado en el nodo (la clave de ordenamiento).
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// Referencia al hijo izquierdo (valores menores). Null si no existe.
    /// </summary>
    public TreeNode? Left { get; set; }

    /// <summary>
    /// Referencia al hijo derecho (valores mayores). Null si no existe.
    /// </summary>
    public TreeNode? Right { get; set; }

    /// <summary>
    /// Crea un nodo hoja: sin hijos, con ambas referencias en null.
    /// </summary>
    /// <param name="value">Valor que almacenará el nodo.</param>
    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}
