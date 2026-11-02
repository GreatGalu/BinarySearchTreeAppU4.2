namespace BinarySearchTreeApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlControls = new FlowLayoutPanel();
            lblValue = new Label();
            txtValue = new TextBox();
            btnInsert = new Button();
            btnSearch = new Button();
            btnDelete = new Button();
            btnPreOrder = new Button();
            btnInOrder = new Button();
            btnPostOrder = new Button();
            picTree = new PictureBox();
            lstOutput = new ListBox();
            lblStatus = new Label();
            pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picTree).BeginInit();
            SuspendLayout();
            //
            // pnlControls
            //
            pnlControls.AutoSize = true;
            pnlControls.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlControls.Controls.Add(lblValue);
            pnlControls.Controls.Add(txtValue);
            pnlControls.Controls.Add(btnInsert);
            pnlControls.Controls.Add(btnSearch);
            pnlControls.Controls.Add(btnDelete);
            pnlControls.Controls.Add(btnPreOrder);
            pnlControls.Controls.Add(btnInOrder);
            pnlControls.Controls.Add(btnPostOrder);
            pnlControls.Dock = DockStyle.Top;
            pnlControls.Padding = new Padding(8, 8, 8, 4);
            pnlControls.Name = "pnlControls";
            pnlControls.TabIndex = 0;
            //
            // lblValue
            //
            lblValue.Anchor = AnchorStyles.Left;
            lblValue.AutoSize = true;
            lblValue.Name = "lblValue";
            lblValue.Text = "Valor:";
            //
            // txtValue
            //
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(90, 27);
            txtValue.TabIndex = 0;
            //
            // btnInsert
            //
            btnInsert.AutoSize = true;
            btnInsert.Name = "btnInsert";
            btnInsert.TabIndex = 1;
            btnInsert.Text = "Insertar";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += BtnInsert_Click;
            //
            // btnSearch
            //
            btnSearch.AutoSize = true;
            btnSearch.Name = "btnSearch";
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Buscar";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += BtnSearch_Click;
            //
            // btnDelete
            //
            btnDelete.AutoSize = true;
            btnDelete.Name = "btnDelete";
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            //
            // btnPreOrder
            //
            btnPreOrder.AutoSize = true;
            btnPreOrder.Margin = new Padding(25, 3, 3, 3);
            btnPreOrder.Name = "btnPreOrder";
            btnPreOrder.TabIndex = 4;
            btnPreOrder.Text = "Preorden";
            btnPreOrder.UseVisualStyleBackColor = true;
            btnPreOrder.Click += BtnPreOrder_Click;
            //
            // btnInOrder
            //
            btnInOrder.AutoSize = true;
            btnInOrder.Name = "btnInOrder";
            btnInOrder.TabIndex = 5;
            btnInOrder.Text = "Inorden";
            btnInOrder.UseVisualStyleBackColor = true;
            btnInOrder.Click += BtnInOrder_Click;
            //
            // btnPostOrder
            //
            btnPostOrder.AutoSize = true;
            btnPostOrder.Name = "btnPostOrder";
            btnPostOrder.TabIndex = 6;
            btnPostOrder.Text = "Postorden";
            btnPostOrder.UseVisualStyleBackColor = true;
            btnPostOrder.Click += BtnPostOrder_Click;
            //
            // lblStatus
            //
            lblStatus.BackColor = SystemColors.ControlLight;
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(8, 4, 0, 4);
            lblStatus.Size = new Size(900, 28);
            lblStatus.TabIndex = 3;
            //
            // lstOutput
            //
            lstOutput.Dock = DockStyle.Bottom;
            lstOutput.FormattingEnabled = true;
            lstOutput.HorizontalScrollbar = true;
            lstOutput.Name = "lstOutput";
            lstOutput.Size = new Size(900, 144);
            lstOutput.TabIndex = 2;
            //
            // picTree
            //
            picTree.BackColor = Color.White;
            picTree.BorderStyle = BorderStyle.FixedSingle;
            picTree.Dock = DockStyle.Fill;
            picTree.Name = "picTree";
            picTree.TabStop = false;
            picTree.Paint += PicTree_Paint;
            picTree.Resize += PicTree_Resize;
            //
            // MainForm
            //
            AcceptButton = btnInsert;
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 640);
            Controls.Add(picTree);
            Controls.Add(lstOutput);
            Controls.Add(lblStatus);
            Controls.Add(pnlControls);
            MinimumSize = new Size(760, 480);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Árbol Binario de Búsqueda (ABB)";
            pnlControls.ResumeLayout(false);
            pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picTree).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel pnlControls;
        private Label lblValue;
        private TextBox txtValue;
        private Button btnInsert;
        private Button btnSearch;
        private Button btnDelete;
        private Button btnPreOrder;
        private Button btnInOrder;
        private Button btnPostOrder;
        private PictureBox picTree;
        private ListBox lstOutput;
        private Label lblStatus;
    }
}
