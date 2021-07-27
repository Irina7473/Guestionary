using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using Microsoft.Data.Sqlite;

namespace Guestionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private const string _connection = "Data Source=user_db.sqlite;Mode=ReadWrite;";
        public ObservableCollection<User> users;
        //private SqliteConnection _db;
        //private SqliteCommand _query;
        
        public MainWindow()
        {
            InitializeComponent();
            
            users = new ObservableCollection<User> { new User(0,"a", "a", "a", "a") };
            UsersList.ItemsSource = users;

            /*
            users = GetUsers();
            _db = new SqliteConnection(_connection);
            _query = new SqliteCommand { Connection = _db };
            */
            /*
            _db.Open();
            _query = _db.CreateCommand();
            _query.CommandText = "SELECT * FROM table_user";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(_query.CommandText, _db);
            DataSet DS = new DataSet();
            UsersList.DataContext = DS.Tables[0].DefaultView;*/
        }
        /*
        private ObservableCollection<User> GetUsers()
        {
            var result = new ObservableCollection<User>();
            
            using var db = new SqliteConnection(_connection);
            db.Open();
            var sql = "SELECT * FROM table_users";
            _query = new SqliteCommand
            {
                Connection = db,
                CommandText = sql
            };
                        
            var res = _query.ExecuteReader();

            if (!res.HasRows)
            {
                MessageBox.Show("БД пуста!");
                return result;
            }

            while (res.Read())
            {
                var user = new User
                {
                    Id = res.GetInt32(0),
                    Surname = res.GetString(1),
                    Firstname = res.GetString(2),
                    Phone = res.GetString(3),
                    Mail = res.GetString(4)
                };
                result.Add(user);
            }
            return result;
        }
        */

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            var surname = Surname_NEW.Text.ToString();
            var firstname = Firstname_NEW.Text.ToString();
            var phone = Phone_NEW.Text.ToString();
            var mail = Mail_NEW.Text.ToString();
            //MessageBox.Show("Добавляем пользователя " + surname);
            var user=new User(num, surname, firstname, phone, mail);
            users.Add(user);
            MessageBox.Show("Добавляем пользователя " + surname + " " + user.Id);            
        }

        private void UsersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var user = (User)((ListView)sender).SelectedItem;

            Surname_NEW.Text = user.Surname;
            Firstname_NEW.Text = user.Firstname;
            Phone_NEW.Text = user.Phone;
            Mail_NEW.Text = user.Mail;
        }
        
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            User user = (User)((ListView)sender).SelectedItem;
            user.Surname = Surname_NEW.Text.ToString();
            user.Firstname = Firstname_NEW.Text.ToString();
            user.Phone = Phone_NEW.Text.ToString();
            user.Mail = Mail_NEW.Text.ToString();
            //users.Add(new User(surname, firstname, phone, mail));
            MessageBox.Show("Изменяем данные пользователя "+ user.Surname);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var user = (User)((ListView)sender).SelectedItem;
            users.Remove(user);
        }
        
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Surname_NEW.Text = "";
            Firstname_NEW.Text = "";
            Phone_NEW.Text = "";
            Mail_NEW.Text = "";
        }
        /*
        private class SQLiteDataAdapter
        {
            private string commandText;
            private SqliteConnection db;

            public SQLiteDataAdapter(string commandText, SqliteConnection db)
            {
                this.commandText = commandText;
                this.db = db;
            }
        }*/
    }
}        