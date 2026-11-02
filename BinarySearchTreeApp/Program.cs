using BinarySearchTreeApp.Forms;

namespace BinarySearchTreeApp;

internal static class Program
{
    /// <summary>
    /// Punto de entrada de la aplicación.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
