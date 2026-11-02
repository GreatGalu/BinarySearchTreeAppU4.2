using System.Drawing.Drawing2D;

namespace BinarySearchTreeApp.Services;

/// <summary>
/// Dibuja el árbol sobre un Graphics. Solo LEE los nodos; nunca los modifica.
/// Se mantiene fuera del formulario para que la UI no contenga lógica sobre nodos.
/// </summary>
public class TreeDrawer
{
    private const int NodeRadius = 17;
    private const int VerticalSpacing = 62;
    private const int TopMargin = 35;
    private const int MinimumOffset = 14;

    /// <summary>
    /// Dibuja el árbol completo centrado en el ancho indicado.
    /// </summary>
    /// <param name="graphics">Superficie de dibujo.</param>
    /// <param name="root">Raíz del árbol (puede ser null).</param>
    /// <param name="width">Ancho disponible del área de dibujo.</param>
    /// <param name="highlighted">Nodo a resaltar (resultado de una búsqueda).</param>
    public void Draw(Graphics graphics, TreeNode? root, int width, TreeNode? highlighted)
    {
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        if (root == null)
        {
            using Font emptyFont = new Font("Segoe UI", 11F, FontStyle.Italic);
            graphics.DrawString("El árbol está vacío", emptyFont, Brushes.Gray, 15, 15);
            return;
        }

        DrawNode(graphics, root, width / 2, TopMargin, width / 4, highlighted);
    }

    /// <summary>
    /// Dibuja recursivamente un nodo y sus enlaces. La separación horizontal
    /// entre hermanos se reduce a la mitad en cada nivel.
    /// </summary>
    private void DrawNode(Graphics graphics, TreeNode node, int x, int y, int offset, TreeNode? highlighted)
    {
        int childY = y + VerticalSpacing;
        int nextOffset = offset / 2 > MinimumOffset ? offset / 2 : MinimumOffset;

        using Pen linkPen = new Pen(Color.DimGray, 2F);

        // Primero los enlaces y los hijos, para que el círculo del padre quede encima.
        if (node.Left != null)
        {
            int childX = x - offset;
            graphics.DrawLine(linkPen, x, y, childX, childY);
            DrawNode(graphics, node.Left, childX, childY, nextOffset, highlighted);
        }

        if (node.Right != null)
        {
            int childX = x + offset;
            graphics.DrawLine(linkPen, x, y, childX, childY);
            DrawNode(graphics, node.Right, childX, childY, nextOffset, highlighted);
        }

        Rectangle circle = new Rectangle(x - NodeRadius, y - NodeRadius, NodeRadius * 2, NodeRadius * 2);
        Color fill = node == highlighted ? Color.Gold : Color.SteelBlue;

        using SolidBrush fillBrush = new SolidBrush(fill);
        using Font font = new Font("Segoe UI", 9F, FontStyle.Bold);
        using StringFormat format = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        graphics.FillEllipse(fillBrush, circle);
        graphics.DrawEllipse(Pens.Black, circle);
        graphics.DrawString(node.Value.ToString(), font,
            node == highlighted ? Brushes.Black : Brushes.White, circle, format);
    }
}
