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

namespace weddebering2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            nameTextBox.Text = string.Empty;
            hourTextBox.Text = "0";
            hourlyWageTextBox.Text = "0";
            resultTextBox.Text = string.Empty;
            
            nameTextBox.Focus();
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            float gross;
            float tax;
            float net;


            string name = nameTextBox.Text;
            float hour = float.Parse(hourTextBox.Text);
            float hourWage = float.Parse(hourlyWageTextBox.Text);


            gross = hour * hourWage;

            if (gross <= 10000)
            {
                tax = 0;
            }
            else if (gross <= 15000)
            {
                tax = (gross - 10000) * 0.2f;
            }
            else if (gross <= 25000)
            {
                tax = ((gross - 15000) * 0.3f) + 1000;
            }
            else if (gross <= 50000)
            {
                tax = ((gross - 25000) * 0.4f) + 4000;
            }
            else
            {
                tax = ((gross - 50000) * 0.5f) + 14000;
            }

            net = gross - tax;

            resultTextBox.Text = $"LOONFICHE VAN {name}\r\n\r\n" +
                $"Aantal gewerkte uren : {hourWage}\r\n" +
                $"Uurloon : {hour:c}\r\n" +
                $"Brutojaarwedde : {gross:C}\r\n" +
                $"Belasting : {tax:C} \r\nNettojaarwedde : {net:c}";
        }
    }
}