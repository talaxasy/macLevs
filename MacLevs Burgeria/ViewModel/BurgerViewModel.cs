using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MacLevs_Burgeria.Model;

namespace MacLevs_Burgeria.ViewModel
{
    public class BurgerViewModel : INotifyPropertyChanged
    {
        private Burger burger;

        public BurgerViewModel(Burger p)
        {
            burger = p;
        }

        public string Title
        {
            get { return burger.Title; }
            set
            {
                burger.Title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Company
        {
            get { return burger.Description; }
            set
            {
                burger.Description = value;
                OnPropertyChanged("Company");
            }
        }
        public double Price
        {
            get { return burger.Price; }
            set
            {
                burger.Price = value;
                OnPropertyChanged("Price");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
