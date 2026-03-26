using System.Collections.ObjectModel;
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

namespace databaze
{

    public partial class MainWindow : Window
    {
        public ObservableCollection<Food> Foods { get; set; } = new ObservableCollection<Food>();
        public MainWindow()
        {
            InitializeComponent();

            Foods.Add(new Food { Name = "Jablko", Type = "Ovoce", Quantity = 3, ConsumedPercent = 50 });
            Foods.Add(new Food { Name = "Chleba", Type = "Pečivo", Quantity = 1, ConsumedPercent = 20 });
            Foods.Add(new Food { Name = "Mléko", Type = "Mléčný výrobek", Quantity = 2, ConsumedPercent = 80 });

            DataContext = this;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Foods.Add(new Food
            {
                Name = tbName.Text,
                Type = tbType.Text,
                Quantity = int.Parse(tbQuantity.Text),
                ConsumedPercent = int.Parse(tbConsumedPercent.Text)
            });
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            if (dgJidlo.SelectedItem is Food f)
            {
                tbName.Text = f.Name;
                tbType.Text = f.Type;
                tbQuantity.Text = f.Quantity.ToString();
                tbConsumedPercent.Text = f.ConsumedPercent.ToString();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (dgJidlo.SelectedItem is Food f)
            {
                f.Name = tbName.Text;
                f.Type = tbType.Text;
                f.Quantity = int.Parse(tbQuantity.Text);
                f.ConsumedPercent = int.Parse(tbConsumedPercent.Text);
                dgJidlo.Items.Refresh();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dgJidlo.SelectedItem is Food f)
                Foods.Remove(f);
        }

        private void dgJidlo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }



}
