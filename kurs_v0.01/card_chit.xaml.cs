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
    /// Логика взаимодействия для card_chit.xaml
    /// </summary>
    public partial class card_chit : Window
    {
        public BLL.Model.Chitatel chitatel;
        public BLL.Model.Chitatel n_ch;
        public bool ok;
        public bool update;
        public card_chit()
        {
            InitializeComponent();
            ok = false;
            update = false;
            n_ch = new BLL.Model.Chitatel();
            chitatel = null;
        }
        public card_chit(BLL.Model.Chitatel ch)
        {
            InitializeComponent();
            ok = false;
            update = false;
            chitatel = ch;
            n_ch = new BLL.Model.Chitatel();
            Data_in();
        }
        public void Data_in()
        {
            FIO.Text = chitatel.FIO;
            Nomer.Text = chitatel.Nomer_chit.ToString();
            phone.Text = chitatel.Telephone;
            adress.Text = chitatel.Adress;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ok = true;
            n_ch.FIO = FIO.Text;
            n_ch.Nomer_chit =Convert.ToInt32( Nomer.Text);
            n_ch.Telephone = phone.Text;
            n_ch.Adress = adress.Text;
            n_ch.Status_id = 2;
            if (chitatel != null)
            {
                if ((n_ch.FIO == chitatel.FIO) && (n_ch.Nomer_chit == chitatel.Nomer_chit) && (n_ch.Telephone == chitatel.Telephone) && (n_ch.Adress == chitatel.Adress))
                {
                    update = false;
                }
                else
                {
                    update = true;
                    n_ch.Id = chitatel.Id;
                }
            }
            this.Close();
        }
    }
}
