﻿using BLL.Interface;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ninject;
using BLL;
using DIApp.Util;
using System.Data;
using System.ComponentModel;

namespace kurs_v0._01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IOutService outServ;
        IDbCrud crudServ;
        public MainWindow()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule("123567891011001112"));
            crudServ = kernel.Get<IDbCrud>();
            outServ = kernel.Get<IOutService>();
            InitializeComponent();
            refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            card_chit chit = new card_chit();
            chit.Show();
            chit.Closing += Add_chit;
            /*начальные параметры*/
           /* crudServ.Create_Outtype(new BLL.Model.Outtype { Id = 1, Name = "Выдача" });
            crudServ.Create_Outtype(new BLL.Model.Outtype { Id = 2, Name = "Прием" });
            

            crudServ.Create_stat_chit(new BLL.Model.Chitatel_status { Id = 1, Name = "Должник" });
            crudServ.Create_stat_chit(new BLL.Model.Chitatel_status { Id = 2, Name = "Обычный" });

            crudServ.CreateChitatel(new BLL.Model.Chitatel { Nomer_chit = 1, FIO = "Иванов Иван Иванович", Telephone = "9611111111", Adress = "Москва", Status_id = 2 });
            crudServ.CreateChitatel(new BLL.Model.Chitatel { Nomer_chit = 2, FIO = "Петров петр Петрович", Telephone = "9611111112", Adress = "Иваново", Status_id = 2 });


            crudServ.Create_stat_book(new BLL.Model.Book_status { Id = 1, Name = "Выдана" });
            crudServ.Create_stat_book(new BLL.Model.Book_status { Id = 2, Name = "В началии" });
            crudServ.Create_stat_book(new BLL.Model.Book_status { Id = 3, Name = "Утеряна" });

            crudServ.Create_izdat(new BLL.Model.Izdatelstvo { Id = 1, Name = "Гриф" });

            crudServ.Create_rubrika(new BLL.Model.Rubrika { Id = 1, Name = "учебник", Head_id = -1 });
            crudServ.Create_rubrika(new BLL.Model.Rubrika { Id = 2, Name = "учебник русского", Head_id = 1 });

            crudServ.CreateBook(new BLL.Model.Book { Name = "Учебник русского языка", Autor = "Сидоров", Annot = "Просто учебник, почти без ошибок", Status_id = 2, Rubrika_id = 2, God = 1995, Izdatelstvo_id = 1 });
            crudServ.CreateBook(new BLL.Model.Book { Name = "Учебник русского языка", Autor = "Сидоров", Annot = "Просто учебник, почти без ошибок", Status_id = 2, Rubrika_id = 2, God = 1995, Izdatelstvo_id = 1 });
            crudServ.CreateBook(new BLL.Model.Book { Name = "Учебник русского языка", Autor = "Сидоров", Annot = "Просто учебник, почти без ошибок", Status_id = 2, Rubrika_id = 2, God = 1995, Izdatelstvo_id = 1 });
            crudServ.CreateBook(new BLL.Model.Book { Name = "Учебник русского языка", Autor = "Сидоров", Annot = "Просто учебник, почти без ошибок", Status_id = 2, Rubrika_id = 2, God = 1995, Izdatelstvo_id = 1 });
            crudServ.CreateBook(new BLL.Model.Book { Name = "Учебник русского языка", Autor = "Сидоров", Annot = "Просто учебник, почти без ошибок", Status_id = 2, Rubrika_id = 2, God = 1995, Izdatelstvo_id = 1 });
            crudServ.CreateBook(new BLL.Model.Book { Name = "Учебник русского языка", Autor = "Сидоров", Annot = "Просто учебник, почти без ошибок", Status_id = 2, Rubrika_id = 2, God = 1995, Izdatelstvo_id = 1 });
            */
            refresh();
        }
        private void Add_chit(object sender, CancelEventArgs e)
        {
            if((sender as card_chit).ok)
            {
                crudServ.CreateChitatel((sender as card_chit).n_ch);
            }
            refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int parse = chit_list.SelectedIndex;
            if (parse == -1) MessageBox.Show("Не выбран читатель.");
            else
            {
                card_chit chit = new card_chit(chit_list.SelectedValue as BLL.Model.Chitatel) ;
                chit.Show();
                chit.Closing += Update_chit;
            }
        }

        private void Update_chit(object sender, CancelEventArgs e)
        {
            if ((sender as card_chit).update)
            {
                crudServ.UpdateChit((sender as card_chit).n_ch);

            }

            refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            card_book book = new card_book(crudServ.GetAllRubrikas(), crudServ.GetAllIzdatelstvs());
            book.Show();
            book.Closing += Add_book;
        }
        private void Add_book(object sender, CancelEventArgs e)
        {
            if((sender as card_book).ok)
            {
                for(int i=0;i< (sender as card_book).count;i++)
                    crudServ.CreateBook((sender as card_book).b);
            }
            refresh();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Poisk_book poisk = new Poisk_book(crudServ.GetBook_Statuses(), crudServ.GetAllRubrikas(),crudServ.GetAllIzdatelstvs(),crudServ.GetAllBook());
            poisk.Show();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            int parse = chit_list.SelectedIndex;
            int dolg1 = 0;
            if (dolg.IsChecked==true) dolg1 = 1;
            if(search_chit.Text=="")
                chit_list.ItemsSource = crudServ.GetAllChit(dolg1);
            else
                chit_list.ItemsSource = crudServ.GetAllChit(dolg1).Where(i => i.FIO.StartsWith(search_chit.Text));
            if (search_book.Text == "")
                book_list.ItemsSource = crudServ.GetAllBookGroup().Select(i=>new Model.Book(i.ToList()));
            else
                book_list.ItemsSource = crudServ.GetAllBookGroup().Select(i => new Model.Book(i.ToList())).Where(i => i.name.StartsWith(search_book.Text));
            Rubrika_list.ItemsSource = crudServ.GetAllRubrikas();
            Izd_list.ItemsSource = crudServ.GetAllIzdatelstvs();
            if (parse!=-1)
            {
                chit_list.SelectedIndex = parse;
                refresh_info();
            }
            //chit_list.ItemsSource = crudServ.GetAllChitatelStatus();
            /*chit_list.Columns[0].Visibility = Visibility.Collapsed;
            chit_list.Columns[1].Header = "Номер читательского";
            chit_list.Columns[2].Header = "ФИО";
            chit_list.Columns[3].Header = "Адрес";
            chit_list.Columns[4].Header = "Телефон";
            chit_list.Columns[5].Visibility = Visibility.Collapsed;
            chit_list.Columns[6].Header = "Статус";
            chit_list.Columns[7].Visibility = Visibility.Collapsed;
            chit_list.Columns[8].Visibility = Visibility.Collapsed;*/
        }

        private List<Model.Book> filter(List<Model.Book> book)
        {
            List<Model.Book> tmp=new List<Model.Book>();
            foreach(Model.Book t in book)
            {
                if (t.onboard_count > 0) tmp.Add(t);
            }
            return tmp;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int parse = chit_list.SelectedIndex;
            if (parse == -1) MessageBox.Show("Не выбран читатель.");
            else
            {
                Out_chit Out = new Out_chit(filter(crudServ.GetAllBookGroup().Select(i => new Model.Book(i.ToList())).ToList()), chit_list.SelectedValue as BLL.Model.Chitatel);
                Out.Closing+= out_book_from_chit;
                Out.Show();
            } 
        }
        private void out_book_from_chit(object sender, EventArgs e)
        {
            BLL.Model.Book book = (sender as Out_chit).book;
            BLL.Model.Chitatel chitatel = (sender as Out_chit).chit;
            bool ok = (sender as Out_chit).ok;
            if(ok)
            {
                crudServ.CreateOut(new BLL.Model.Out {Id_chit=chitatel.Id,Id_book=book.Id,Date=DateTime.Now,Outtype_id=1 });
            }
            refresh();
        }

        private void refresh_info()
        {
            int parse = chit_list.SelectedIndex;
            BLL.Model.Chitatel rowView = chit_list.SelectedValue as BLL.Model.Chitatel;
            if (parse != -1)
            {
                list_out_chit.ItemsSource = rowView.OutList;
                list_book_chit.ItemsSource = rowView.BookList;
            }
        }

        private void refresh_list(object sender, MouseButtonEventArgs e)
        {
            refresh();
        }
        public void return_book_from_chit(object sender, RoutedEventArgs e)
        {
            BLL.Model.Chitatel chitatel = chit_list.SelectedValue as BLL.Model.Chitatel;
            BLL.Model.Book book = list_book_chit.SelectedValue as BLL.Model.Book;
            crudServ.CreateOut(new BLL.Model.Out { Id_chit = chitatel.Id, Id_book = book.Id, Date = DateTime.Now, Outtype_id = 2 });
            refresh();
        }

        public void lost_book_from_chit(object sender, RoutedEventArgs e)
        {
            BLL.Model.Book book = list_book_chit.SelectedValue as BLL.Model.Book;
            book.Status_id = 3;
            crudServ.UpdateBook(book);
            refresh();
        }

        private void chit_list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Button_Click_1(sender, e);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            card_rubrika r = new card_rubrika(crudServ.GetAllRubrikas());
            r.Show();
            r.Closing += Add_rubrika;
        }
        private void Add_rubrika(object sender, CancelEventArgs e)
        {
            if((sender as card_rubrika).ok)
            {
                crudServ.Create_rubrika((sender as card_rubrika).rubrika);
            }
            refresh();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            card_izd iz = new card_izd();
            iz.Show();
            iz.Closing += Add_izd;
        }
        private void Add_izd(object sender, CancelEventArgs e)
        {
            if((sender as card_izd).ok)
            {
                crudServ.Create_izdat((sender as card_izd).izd);
            }
            refresh();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            refresh();
            //chit_list.ItemsSource = crudServ.GetAllChit().Where(i=>i.FIO.StartsWith(search_chit.Text));
        }

        private void search_book_TextChanged(object sender, TextChangedEventArgs e)
        {
            book_list.ItemsSource = crudServ.GetAllBookGroup().Select(i => new Model.Book(i.ToList())).Where(i=>i.name.StartsWith(search_book.Text));
        }
    }
}
