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
    /// Логика взаимодействия для Out_chit.xaml
    /// </summary>
    public partial class Out_chit : Window
    {
        List<BLL.Model.Book> books;
        public BLL.Model.Chitatel chit;
        public bool ok;
        public BLL.Model.Book book;
        public Out_chit()
        {
            InitializeComponent();
        }
        public Out_chit(List<BLL.Model.Book> l, BLL.Model.Chitatel ch)
        {
            books = l;
            chit = ch;
            InitializeComponent();
            books_l.ItemsSource = books;
            info.Text += "ФИО: " + ch.FIO + " Адрес: " + ch.Adress + " Телефон: " + ch.Telephone;
            ok = false;
        }
        void Out_from_chit(object sender, RoutedEventArgs e)
        {
            ok = true;
            int parse = books_l.SelectedIndex;
            book = books_l.SelectedValue as BLL.Model.Book;
            this.Close();
        }
    }
}
