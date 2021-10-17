using EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

namespace EntityFramework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var context=new LibraryEntities())
            {
                //add
                //var book = new Book
                //{
                //    AuthorId = 1,
                //    CategoryId = 2,
                //    Name = "New Book",
                //    Pages = 1100
                //};
                //context.Books.Add(book);
                //context.SaveChanges();



                //var book = context.Books.FirstOrDefault(b => b.Name == "New Book");
                //if (book != null) { 
                //context.Books.Remove(book);
                //context.SaveChanges();
                //}


                //Eager loading
                //var book = context.Books.Include("Author").FirstOrDefault(b => b.Id == 1);
                //MessageBox.Show(book.Author.Name);



                //update
                var book = context.Books.FirstOrDefault(b => b.Id == 1);
                book.AuthorId = 3;
                context.SaveChanges();

                //var book = new Book
                //{
                //    AuthorId = 1,
                //    CategoryId = 2,
                //    Name = "My New Book",
                //    Pages = 1100
                //};
                //context.Entry(book).State = EntityState.Added;
                //context.SaveChanges();



                //var book = context.Books.FirstOrDefault(b => b.Id == 1);
                //book.AuthorId = 1;
                //context.Entry(book).State = EntityState.Modified;
                //context.SaveChanges();

                var books = context
                    .Books
                    .Include("Author")//Eager loading , it comes navigation properties
                    .Include("Category").ToList();
                var list = new ObservableCollection<Book>(books);
                mydatagrid.ItemsSource = list;


            }


        }
    }
}
