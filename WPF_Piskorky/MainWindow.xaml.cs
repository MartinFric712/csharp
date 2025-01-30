using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Piskorky
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public char LastPlayer { get; set; } = '◯';
        public char PlayerOne { get; set; } = '✕';
        public char PlayerTwo { get; set; } = '◯';

        public MainWindow()
        {
            InitializeComponent(); 
        }

        public void ProcessClick(Button button)
        {
            var buttonContent = button.Content.ToString();
            if (buttonContent.Contains(PlayerOne) || buttonContent.Contains(PlayerTwo))
            {
                return;
            }
            if (LastPlayer == PlayerOne) 
            {
                button.Content = PlayerTwo;
                button.Background = new SolidColorBrush(Colors.Red);
                LastPlayer = PlayerTwo;
            }
            else if (LastPlayer == PlayerTwo)
            {
                button.Content = PlayerOne;
                button.Background = new SolidColorBrush(Colors.Green);
                LastPlayer = PlayerOne;
            }
            var isWinner = CheckWinner();
            if (isWinner)
            {
                MessageBox.Show("Vyhral hrac: " + LastPlayer);
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProcessClick(sender as Button);
        }

        public bool CheckWinner()
        {
            var b_0x0 = Button_0x0.Content.ToString();
            var b_1x0 = Button_1x0.Content.ToString();
            var b_2x0 = Button_2x0.Content.ToString();

            var b_0x1 = Button_0x1.Content.ToString();
            var b_1x1 = Button_1x1.Content.ToString();
            var b_2x1 = Button_2x1.Content.ToString();

            var b_0x2 = Button_0x2.Content.ToString();
            var b_1x2 = Button_1x2.Content.ToString();
            var b_2x2 = Button_2x2.Content.ToString();

            // Kontrola 1 riadku
            if (b_0x0 == b_0x1 && b_0x0 == b_0x2)
            {
                return true;
            }

            // Kontrola 2 riadku
            if (b_1x0 == b_1x1 && b_1x0 == b_1x2)
            {
                return true;
            }

            // Kontrola 3 riadku
            if (b_2x0 == b_2x1 && b_2x0 == b_2x2)
            {
                return true;
            }

            // Kontrola 1 stlpca
            if (b_0x0 == b_0x1 && b_0x0 == b_0x2)
            {
                return true;
            }

            // Kontrola 2 stlpca
            if (b_0x1 == b_1x1 && b_0x1 == b_2x1)
            {
                return true;
            }

            // Kontrola 3 stlpca
            if (b_0x2 == b_1x2 && b_0x2 == b_2x2)
            {
                return true;
            }

            // Kontrola 1 diagonaly
            if (b_0x0 == b_1x1 && b_0x0 == b_2x2)
            {
                return true;
            }

            // Kontrola 2 diagonaly
            if (b_2x0 == b_1x1 && b_2x0 == b_0x2)
            {
                return true;
            }
                return false;
        }
    }
}