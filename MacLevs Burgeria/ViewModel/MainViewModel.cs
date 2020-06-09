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
using System.Windows.Controls.Primitives;
using System.Diagnostics;
using System.Threading;
using MacLevs_Burgeria.View;
using MacLevs_Burgeria.ViewModel;
using System.Windows.Interactivity;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using MacLevs_Burgeria.Model;
using System.Data;
using System.Data.SqlClient;
using Superpower;

namespace MacLevs_Burgeria.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        SqlConnection SQLconnection;
        string pathToDataBase = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Учёба\ТРПО\2-й семестр\MacLevs Burgeria\MacLevs Burgeria\Database1.mdf;Integrated Security=True";
        
        
        public MainViewModel()
        {

            Burgers = new ObservableCollection<Burger> { };
            SQLconnection = new SqlConnection(pathToDataBase);
            SQLconnection.Open();
            SqlDataReader dataReader = null;
            SqlCommand comm1 = new SqlCommand("SELECT * FROM [Продукт]", SQLconnection);
            try
            {
                dataReader = comm1.ExecuteReader();
                while (dataReader.Read())
                {
                    Burgers.Add(new Burger {Id = Convert.ToInt32(dataReader["ID продукта"]), Title = dataReader["Название"].ToString(), Description = dataReader["Описание"].ToString(), Price = Convert.ToInt32(dataReader["Цена"]) });
                }
                (App.Current.MainWindow as MainWindow).ListProductBurgers.ItemsSource = Burgers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
            }
            
            

        }
        private Burger selectedBurger;
        public ObservableCollection<Burger> Burgers { get; set; }
        public Burger SelectedBurger
        {
            get { return selectedBurger; }
            set
            {
                selectedBurger = value;
                OnPropertyChanged("SelectedBurger");
            }
        }

        private RelayCommand addProductCommand;
        public RelayCommand AddProductCommand
        {
            get
            {
                return addProductCommand ??
                    (addProductCommand = new RelayCommand(obj =>
                    {
                        
                        SqlCommand comm1 = new SqlCommand("INSERT INTO [Продукт] (Название, Описание, Цена) VALUES(N'Пусто',N'Пусто', 0)", SQLconnection);
                        var burger = new Burger()
                        {
                            Title = "Пусто",
                            Description = "Пусто",
                            Price = 0
                        };
                        comm1.ExecuteNonQuery();
                        Burgers.Insert(0, burger);
                        SelectedBurger = burger;
                    }));
            }
        }

        private RelayCommand removeAllProductCommand;
        public RelayCommand RemoveAllProductCommand
        {
            get
            {
                return removeAllProductCommand ??
                    (removeAllProductCommand = new RelayCommand(obj => 
                    {
                        SqlCommand comm1 = new SqlCommand("DELETE FROM [Продукт]", SQLconnection);
                        comm1.ExecuteNonQuery();
                        Burgers.Clear();
                    }));
            }
        }


        private RelayCommand removeProductCommand;
        public RelayCommand RemoveProductCommand
        {
            get
            {
                return removeProductCommand ??
                    (removeProductCommand = new RelayCommand(obj => // Логика самого события (команды)
                    {
                        Burger burger = obj as Burger;
                        if (burger != null)
                        {
                            SqlCommand comm1 = new SqlCommand("DELETE FROM [Продукт] WHERE [ID продукта] = @id", SQLconnection);
                            comm1.Parameters.AddWithValue("id", burger.Id);
                            comm1.ExecuteNonQuery();
                            Burgers.Remove(burger);
                        }
                    },
                    (obj) => Burgers.Count > 0)); // Условие при котором присходит комманда (событие)
            }
        }

        private RelayCommand doubleProductCommand;
        public RelayCommand DoubleProductCommand
        {
            get
            {
                return doubleProductCommand ??
                    (doubleProductCommand = new RelayCommand(obj =>
                    {
                        Burger burger = obj as Burger;
                        if (burger != null)
                        {
                            SqlCommand comm1 = new SqlCommand("INSERT INTO [Продукт] (Название, Описание, Цена) VALUES(@name, @descr, @price)", SQLconnection);
                            comm1.Parameters.AddWithValue("name", burger.Title);
                            comm1.Parameters.AddWithValue("descr", burger.Description);
                            comm1.Parameters.AddWithValue("price", burger.Price);
                            Burger burgerCopy = new Burger
                            {
                                Description = burger.Description,
                                Price = burger.Price,
                                Title = burger.Title
                            };
                            comm1.ExecuteNonQuery();
                            Burgers.Insert(0, burgerCopy);
                        }
                    }));
            }
        }

        private RelayCommand editProductCommand;
        public RelayCommand EditProductCommand
        {
            get
            {
                return editProductCommand ??
                    (editProductCommand = new RelayCommand(obj =>
                    {
                        Burger burger = obj as Burger;
                        if (burger != null)
                        {
                            
                            SqlCommand comm1 = new SqlCommand("UPDATE [Продукт] SET [Название] = @name, [Описание] = @descr, [Цена] = @price WHERE [ID продукта] = @id", SQLconnection);
                            comm1.Parameters.AddWithValue("name", burger.Title);
                            comm1.Parameters.AddWithValue("id", burger.Id);
                            comm1.Parameters.AddWithValue("descr", burger.Description);
                            comm1.Parameters.AddWithValue("price", burger.Price);
                            comm1.ExecuteNonQuery();
                        }
                    }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        
    }
    
}
