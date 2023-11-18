using System.Runtime.InteropServices;
using System;
using System.Windows;

namespace task2
{
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, string lParam);

        // Коди повідомлень
        const int WM_SETTEXT = 0x000C;
        const int WM_CLOSE = 0x0010;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnApplyAction_Click(object sender, RoutedEventArgs e)
        {
            // Знайдемо вікно свого додатка за назвою
            IntPtr hWnd = FindWindow(null, "Window Manipulation");

            if (hWnd != IntPtr.Zero)
            {
                // Відправимо повідомлення залежно від вибору користувача
                if (rbChangeTitle.IsChecked == true)
                {
                    SendMessage(hWnd, WM_SETTEXT, 0, txtWindowTitle.Text);
                }
                else if (rbCloseWindow.IsChecked == true)
                {
                    SendMessage(hWnd, WM_CLOSE, 0, null);
                }
                // Тут можна додати інші варіанти
            }
            else
            {
                MessageBox.Show("Вікно не знайдено.", "Помилка");
            }
        }
    }
}
