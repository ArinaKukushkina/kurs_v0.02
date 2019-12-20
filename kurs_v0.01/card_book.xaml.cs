using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kurs_v0._01
{
    /// <summary>
    /// Логика взаимодействия для card_book.xaml
    /// </summary>
    public partial class card_book : Window
    {
        public bool ok;
        public BLL.Model.Book b;
        public int count;
        public card_book(List<BLL.Model.Rubrika> r, List<BLL.Model.Izdatelstvo> iz)
        {
            InitializeComponent();
            Rubrika.ItemsSource = r;
            Rubrika.DisplayMemberPath = "Name";
            Rubrika.SelectedValuePath = "Id";
            Izdat.ItemsSource = iz;
            Izdat.DisplayMemberPath = "Name";
            Izdat.SelectedValuePath = "Id";
            ok = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ok = true;
            b = new BLL.Model.Book();
            b.Name = Name.Text;
            b.Autor = Autor.Text;
            count = Convert.ToInt32(Count.Text);
            b.God = Convert.ToInt32(God.Text);
            b.Annot = Annot.Text;
            b.Rubrika_id =Convert.ToInt32(Rubrika.SelectedValue);
            b.Izdatelstvo_id = Convert.ToInt32(Izdat.SelectedValue);
            b.Status_id = 2;
            this.Close();
        }
    }
}
