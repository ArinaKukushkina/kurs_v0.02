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
    /// Логика взаимодействия для card_rubrika.xaml
    /// </summary>
    public partial class card_rubrika : Window
    {
        public bool ok;
        public BLL.Model.Rubrika rubrika;
        public card_rubrika(List<BLL.Model.Rubrika> r)
        {
            InitializeComponent();
            ok = false;
            rubrika = new BLL.Model.Rubrika();
            Head.ItemsSource = r;
            Head.DisplayMemberPath = "Name";
            Head.SelectedValuePath = "Id";
            Head.SelectedIndex = -1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ok = true;
            rubrika.Name = Name.Text;
            if (Head.SelectedIndex == -1) rubrika.Head_id = -1;
            else
                rubrika.Head_id = Convert.ToInt32(Head.SelectedValue);
            this.Close();
        }
    }
}
