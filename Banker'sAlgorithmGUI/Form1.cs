namespace Banker_sAlgorithmGUI
{
    public partial class Form1 : Form
    {
        public static int numOfResources;
        public static int numOfProcesses;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            numOfResources = int.Parse(txtBoxNumResources.Text);
            numOfProcesses = int.Parse(txtBoxNumProcesses.Text);
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}