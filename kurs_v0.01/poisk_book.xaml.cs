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
    /// Логика взаимодействия для Poisk_book.xaml
    /// </summary>
    public partial class Poisk_book : Window
    {
        List<BLL.Model.Book> books;
        List<BLL.Model.Book> out_list;
        public Poisk_book(List<BLL.Model.Book_status> bs, List<BLL.Model.Rubrika> r,List<BLL.Model.Izdatelstvo >izd,List<BLL.Model.Book> b)
        {
            InitializeComponent();
            status.ItemsSource = bs;
            status.DisplayMemberPath = "Name";
            status.SelectedValuePath = "Id";

            rubrika.ItemsSource = r;
            rubrika.DisplayMemberPath = "Name";
            rubrika.SelectedValuePath = "Id";

            izdat.ItemsSource = izd;
            izdat.DisplayMemberPath = "Name";
            izdat.SelectedValuePath = "Id";
            books = b;
            out_list =new List<BLL.Model.Book> (books);
            refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            status.SelectedIndex = -1;
            rubrika.SelectedIndex = -1;
            izdat.SelectedIndex = -1;
            refresh();
        }
        private void refresh()
        {
            List<BLL.Model.Book> tmp=new List<BLL.Model.Book>(books);
            if (status.SelectedIndex!=-1)
            {
                tmp = tmp.FindAll(i => i.Status_id == Convert.ToInt32(status.SelectedValue));
            }
            if (rubrika.SelectedIndex != -1)
            {
                tmp = tmp.FindAll(i => i.Rubrika_id == Convert.ToInt32(rubrika.SelectedValue));
            }
            if (izdat.SelectedIndex != -1)
            {
                tmp = tmp.FindAll(i => i.Izdatelstvo_id == Convert.ToInt32(izdat.SelectedValue));
            }
            out_list = new List<BLL.Model.Book>(tmp);
            rich_search.ItemsSource = out_list;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            refresh();
        }
    }
}
