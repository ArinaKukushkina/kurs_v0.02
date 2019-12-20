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
    /// Логика взаимодействия для card_izd.xaml
    /// </summary>
    public partial class card_izd : Window
    {
        public bool ok;
        public BLL.Model.Izdatelstvo izd;
        public card_izd()
        {
            InitializeComponent();
            ok = false;
            izd = new BLL.Model.Izdatelstvo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ok = true;
            izd.Name = Name.Text;
            this.Close();
        }
    }
}
