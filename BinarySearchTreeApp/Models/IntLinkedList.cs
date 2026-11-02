namespace BinarySearchTreeApp.Models;

/// <summary>
/// Nodo de la lista enlazada simple que usan los recorridos.
/// </summary>
public class ListNode
{
    /// <summary>Valor guardado en este eslabón.</summary>
    public int Value { get; }

    /// <summary>Referencia al siguiente eslabón. Null al final de la lista.</summary>
    public ListNode? Next { get; set; }

    public ListNode(int value)
    {
        Value = value;
        Next = null;
    }
}

/// <summary>
/// Lista enlazada simple implementada desde cero.
/// Sustituye a List&lt;T&gt; para respetar la restricción de no usar colecciones nativas.
/// </summary>
public class IntLinkedList
{
    /// <summary>Primer eslabón de la lista.</summary>
    public ListNode? Head { get; private set; }

    /// <summary>Último eslabón (permite agregar en O(1)).</summary>
    private ListNode? _tail;

    /// <summary>Cantidad de elementos almacenados.</summary>
    public int Count { get; private set; }

    /// <summary>
    /// Agrega un valor al final de la lista creando un nuevo eslabón en el Heap.
    /// </summary>
    public void Add(int value)
    {
        ListNode newNode = new ListNode(value);

        if (Head == null)
        {
            Head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail!.Next = newNode;
            _tail = newNode;
        }

        Count++;
    }
}
