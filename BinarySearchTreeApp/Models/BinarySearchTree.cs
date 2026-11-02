using BinarySearchTreeApp.Models;

namespace BinarySearchTreeApp.Services;

/// <summary>
/// Árbol binario de búsqueda (ABB) con memoria dinámica.
/// Todos los nodos se reservan en el Heap con 'new' y se enlazan por referencias.
/// No se usa ninguna colección nativa de C#.
/// </summary>
public class BinarySearchTree
{
    /// <summary>
    /// Referencia a la raíz del árbol. Null cuando el árbol está vacío.
    /// </summary>
    public TreeNode? Root { get; private set; }

    /// <summary>
    /// Cantidad de nodos actualmente almacenados.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Indica si el árbol no contiene nodos.
    /// </summary>
    public bool IsEmpty => Root == null;

    // ---------------------------------------------------------------
    // INSERCIÓN
    // ---------------------------------------------------------------

    /// <summary>
    /// Inserta un valor respetando la propiedad del ABB:
    /// menores a la izquierda, mayores a la derecha.
    /// </summary>
    /// <returns>True si se insertó; false si el valor ya existía (no se permiten duplicados).</returns>
    public bool Insert(int value)
    {
        bool inserted = false;
        Root = InsertNode(Root, value, ref inserted);

        if (inserted)
        {
            Count++;
        }

        return inserted;
    }

    /// <summary>
    /// Inserción recursiva: baja por el árbol hasta encontrar una referencia nula
    /// y ahí reserva el nuevo nodo en el Heap.
    /// </summary>
    private TreeNode InsertNode(TreeNode? current, int value, ref bool inserted)
    {
        // Caso base: posición vacía, se crea el nodo con 'new'.
        if (current == null)
        {
            inserted = true;
            return new TreeNode(value);
        }

        if (value < current.Value)
        {
            current.Left = InsertNode(current.Left, value, ref inserted);
        }
        else if (value > current.Value)
        {
            current.Right = InsertNode(current.Right, value, ref inserted);
        }
        // Si es igual, se ignora (inserted permanece en false).

        return current;
    }

    // ---------------------------------------------------------------
    // BÚSQUEDA
    // ---------------------------------------------------------------

    /// <summary>
    /// Busca un valor descendiendo por una sola rama.
    /// </summary>
    /// <returns>El nodo encontrado o null si el valor no existe.</returns>
    public TreeNode? Search(int value)
    {
        TreeNode? current = Root;

        while (current != null)
        {
            if (value == current.Value)
            {
                return current;
            }

            current = value < current.Value ? current.Left : current.Right;
        }

        return null;
    }

    // ---------------------------------------------------------------
    // ELIMINACIÓN
    // ---------------------------------------------------------------

    /// <summary>
    /// Elimina un valor del árbol.
    /// </summary>
    /// <returns>True si el valor existía y se eliminó.</returns>
    public bool Delete(int value)
    {
        bool deleted = false;
        Root = DeleteNode(Root, value, ref deleted);

        if (deleted)
        {
            Count--;
        }

        return deleted;
    }

    /// <summary>
    /// Eliminación recursiva. Devuelve la nueva referencia que debe ocupar
    /// la posición del nodo visitado.
    /// </summary>
    private TreeNode? DeleteNode(TreeNode? current, int value, ref bool deleted)
    {
        // El valor no existe en esta rama.
        if (current == null)
        {
            return null;
        }

        if (value < current.Value)
        {
            current.Left = DeleteNode(current.Left, value, ref deleted);
            return current;
        }

        if (value > current.Value)
        {
            current.Right = DeleteNode(current.Right, value, ref deleted);
            return current;
        }

        // Nodo encontrado: se aplica uno de los 3 casos.
        deleted = true;

        // CASO 1: nodo hoja. El padre pasa a apuntar a null.
        if (current.Left == null && current.Right == null)
        {
            return null;
        }

        // CASO 2: un solo hijo. El padre pasa a apuntar al hijo existente.
        if (current.Left == null)
        {
            return current.Right;
        }

        if (current.Right == null)
        {
            return current.Left;
        }

        // CASO 3: dos hijos. Se reemplaza el valor por el sucesor inorden
        // (el menor de la rama derecha) y luego se elimina ese sucesor.
        TreeNode successor = FindMinimum(current.Right);
        current.Value = successor.Value;

        bool successorDeleted = false;
        current.Right = DeleteNode(current.Right, successor.Value, ref successorDeleted);

        return current;
    }

    /// <summary>
    /// Devuelve el nodo con el menor valor de un subárbol (el más a la izquierda).
    /// </summary>
    private TreeNode FindMinimum(TreeNode node)
    {
        TreeNode current = node;

        while (current.Left != null)
        {
            current = current.Left;
        }

        return current;
    }

    // ---------------------------------------------------------------
    // ALTURA
    // ---------------------------------------------------------------

    /// <summary>
    /// Altura del árbol en niveles (0 si está vacío, 1 si solo hay raíz).
    /// </summary>
    public int GetHeight()
    {
        return CalculateHeight(Root);
    }

    private int CalculateHeight(TreeNode? node)
    {
        if (node == null)
        {
            return 0;
        }

        int leftHeight = CalculateHeight(node.Left);
        int rightHeight = CalculateHeight(node.Right);

        return 1 + (leftHeight > rightHeight ? leftHeight : rightHeight);
    }

    // ---------------------------------------------------------------
    // RECORRIDOS EN PROFUNDIDAD
    // ---------------------------------------------------------------

    /// <summary>
    /// Preorden: Raíz, Izquierda, Derecha.
    /// </summary>
    public IntLinkedList GetPreOrder()
    {
        IntLinkedList result = new IntLinkedList();
        PreOrder(Root, result);
        return result;
    }

    private void PreOrder(TreeNode? node, IntLinkedList result)
    {
        if (node == null)
        {
            return;
        }

        result.Add(node.Value);      // Visita la raíz primero.
        PreOrder(node.Left, result);
        PreOrder(node.Right, result);
    }

    /// <summary>
    /// Inorden: Izquierda, Raíz, Derecha. En un ABB devuelve los valores ordenados.
    /// </summary>
    public IntLinkedList GetInOrder()
    {
        IntLinkedList result = new IntLinkedList();
        InOrder(Root, result);
        return result;
    }

    private void InOrder(TreeNode? node, IntLinkedList result)
    {
        if (node == null)
        {
            return;
        }

        InOrder(node.Left, result);
        result.Add(node.Value);      // Visita la raíz entre ambos subárboles.
        InOrder(node.Right, result);
    }

    /// <summary>
    /// Postorden: Izquierda, Derecha, Raíz.
    /// </summary>
    public IntLinkedList GetPostOrder()
    {
        IntLinkedList result = new IntLinkedList();
        PostOrder(Root, result);
        return result;
    }

    private void PostOrder(TreeNode? node, IntLinkedList result)
    {
        if (node == null)
        {
            return;
        }

        PostOrder(node.Left, result);
        PostOrder(node.Right, result);
        result.Add(node.Value);      // Visita la raíz al final.
    }
}
