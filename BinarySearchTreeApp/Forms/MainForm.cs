using BinarySearchTreeApp.Models;
using BinarySearchTreeApp.Services;

namespace BinarySearchTreeApp.Forms;

/// <summary>
/// Capa de presentación. Solo lee datos de la interfaz, delega todo en
/// BinarySearchTree y muestra los resultados. No manipula nodos.
/// </summary>
public partial class MainForm : Form
{
    private readonly BinarySearchTree _tree = new BinarySearchTree();
    private readonly TreeDrawer _drawer = new TreeDrawer();

    /// <summary>Nodo resaltado tras una búsqueda exitosa.</summary>
    private BinarySearchTreeApp.Services.TreeNode? _highlightedNode;
    public MainForm()
    {
        InitializeComponent();
        UpdateStatus();
    }

    // ---------------------------------------------------------------
    // EVENTOS DE LOS BOTONES
    // ---------------------------------------------------------------

    private void BtnInsert_Click(object? sender, EventArgs e)
    {
        if (!TryReadValue(out int value))
        {
            return;
        }

        _highlightedNode = null;

        if (_tree.Insert(value))
        {
            Log($"Se insertó el valor {value}.");
        }
        else
        {
            Log($"El valor {value} ya existe; no se permiten duplicados.");
        }

        RefreshView();
    }

    private void BtnSearch_Click(object? sender, EventArgs e)
    {
        if (!TryReadValue(out int value))
        {
            return;
        }

        _highlightedNode = _tree.Search(value);

        Log(_highlightedNode != null
            ? $"Búsqueda: el valor {value} SÍ existe en el árbol (resaltado en dorado)."
            : $"Búsqueda: el valor {value} NO existe en el árbol.");

        RefreshView();
    }

    private void BtnDelete_Click(object? sender, EventArgs e)
    {
        if (!TryReadValue(out int value))
        {
            return;
        }

        _highlightedNode = null;

        Log(_tree.Delete(value)
            ? $"Se eliminó el valor {value}."
            : $"No se pudo eliminar: el valor {value} no existe.");

        RefreshView();
    }

    private void BtnPreOrder_Click(object? sender, EventArgs e)
    {
        ShowTraversal("Preorden (Raíz, Izq, Der)", _tree.GetPreOrder());
    }

    private void BtnInOrder_Click(object? sender, EventArgs e)
    {
        ShowTraversal("Inorden (Izq, Raíz, Der)", _tree.GetInOrder());
    }

    private void BtnPostOrder_Click(object? sender, EventArgs e)
    {
        ShowTraversal("Postorden (Izq, Der, Raíz)", _tree.GetPostOrder());
    }

    private void PicTree_Paint(object? sender, PaintEventArgs e)
    {
        _drawer.Draw(e.Graphics, _tree.Root, picTree.ClientSize.Width, _highlightedNode);
    }

    private void PicTree_Resize(object? sender, EventArgs e)
    {
        picTree.Invalidate();
    }

    // ---------------------------------------------------------------
    // MÉTODOS AUXILIARES DE PRESENTACIÓN
    // ---------------------------------------------------------------

    /// <summary>
    /// Lee y valida el número escrito en el cuadro de texto.
    /// </summary>
    private bool TryReadValue(out int value)
    {
        if (int.TryParse(txtValue.Text.Trim(), out value))
        {
            return true;
        }

        MessageBox.Show("Ingrese un número entero válido.", "Valor inválido",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        txtValue.SelectAll();
        txtValue.Focus();
        return false;
    }

    /// <summary>
    /// Convierte la lista de un recorrido en una línea de texto y la muestra.
    /// </summary>
    private void ShowTraversal(string title, IntLinkedList traversal)
    {
        if (traversal.Count == 0)
        {
            Log($"{title}: el árbol está vacío.");
            return;
        }

        string text = string.Empty;
        ListNode? current = traversal.Head;

        while (current != null)
        {
            text += current.Value + (current.Next != null ? " → " : string.Empty);
            current = current.Next;
        }

        Log($"{title}: {text}");
    }

    private void RefreshView()
    {
        txtValue.Clear();
        txtValue.Focus();
        UpdateStatus();
        picTree.Invalidate();
    }

    private void UpdateStatus()
    {
        lblStatus.Text = $"Nodos: {_tree.Count}   |   Altura: {_tree.GetHeight()}";
    }

    private void Log(string message)
    {
        lstOutput.Items.Add(message);
        lstOutput.TopIndex = lstOutput.Items.Count - 1;
    }
}
