using System.Windows;

namespace task4_1
{
    public partial class MainWindow : Window
    {
        private task4_2.MainWindow secondWindow = new task4_2.MainWindow();

        public MainWindow()
        {
            InitializeComponent();
            secondWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            secondWindow.ChangeStyles(TextBox1.Text, TextBox2.Text, TextBox3.Text);
        }
    }
}