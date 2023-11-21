using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace task4_2
{
    public partial class MainWindow
    {
        // Створюємо елементи керування, які успадковують властивості від базових класів
        private Label _label = new Label();
        private TextBox _textBox = new TextBox();
        private Button _button = new Button();

        public MainWindow()
        {
            // Додаємо елементи керування до вікна
            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(_label);
            stackPanel.Children.Add(_textBox);
            stackPanel.Children.Add(_button);
            this.Content = stackPanel;

            // Задаємо початкові значення для елементів керування
            _label.Content = "Це вікно з успадкованими елементами керування";
            _textBox.Text = "Введіть щось тут";
            _button.Content = "Натисніть мене";
            //InitializeComponent();
        }



        // Метод, який змінює стилі елементів керування за параметрами
        public void ChangeStyles(string color, string font, string size)
        {
            // Перевіряємо, чи є параметри валідними
            try
            {
                Color textColor = (Color)ColorConverter.ConvertFromString(color);
                _label.Foreground = new SolidColorBrush(textColor);
                _textBox.Foreground = new SolidColorBrush(textColor);
                _button.Foreground = new SolidColorBrush(textColor);

                FontFamily fontFamily = new FontFamily(font);
                _label.FontFamily = fontFamily;
                _textBox.FontFamily = fontFamily;
                _button.FontFamily = fontFamily;

                double fontSize = double.Parse(size);
                _label.FontSize = fontSize;
                _textBox.FontSize = fontSize;
                _button.FontSize = fontSize;
            }
            catch (Exception ex)
            {
                // Якщо щось пішло не так, виводимо повідомлення про помилку
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}