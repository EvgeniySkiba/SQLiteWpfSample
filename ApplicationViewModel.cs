using SQLiteWpfSample.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;

namespace SQLiteWpfSample
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;
        IEnumerable<Phone> phones;

        public IEnumerable<Phone> Phones
        {
            get { return phones; }
            set
            {
                phones = value;
                OnPropertyChanged("Phones");
            }
        }

        public ApplicationViewModel()
        {
            int b = 10;
            try
            {
                db = new ApplicationContext();
                db.Phones.Load();
                // загружаем данные из бд в локальный кэш:
                Phones = db.Phones.Local.ToBindingList();
            }
            catch(Exception ex)
            {
                int a = 10;
            }
        }
        // команда добавления
        public RelayCommand AddCommand
        {
            get 
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      /*  PhoneWindow phoneWindow = new PhoneWindow(new Phone() { Status = (int)Status.Bad});
                        if (phoneWindow.ShowDialog() == true)
                        {
                            Phone phone = phoneWindow.Phone;
                            db.Phones.Add(phone);
                            db.SaveChanges();
                        }*/

                      PhoneWindow2 phoneWindow = new PhoneWindow2(new PhoneViewModel());
                      if (phoneWindow.ShowDialog() == true)
                      {
                          PhoneViewModel phone = phoneWindow.PhoneViewModel;
                          var test = phone.CurrentStatus;
                         /* Phone newPhone = new Phone()
                          {
                              Id = phone.ID,
                              Company = phone.Company,
                              Title = phone.Title
                          };
                          
                           db.Phones.Add(newPhone);*/
                         // db.SaveChanges();
                      }
                  }));
            }
        }
        // команда редактирования
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Phone phone = selectedItem as Phone;

                      Phone vm = new Phone()
                      {
                          Id = phone.Id,
                          Company = phone.Company,
                          Price = phone.Price,
                          Title = phone.Title
                      };
                      PhoneWindow phoneWindow = new PhoneWindow(vm);


                      if (phoneWindow.ShowDialog() == true)
                      {
                          // получаем измененный объект
                          phone = db.Phones.Find(phoneWindow.Phone.Id);
                          if (phone != null)
                          {
                              phone.Company = phoneWindow.Phone.Company;
                              phone.Title = phoneWindow.Phone.Title;
                              phone.Price = phoneWindow.Phone.Price;
                              db.Entry(phone).State = EntityState.Modified;
                              db.SaveChanges();
                          }
                      }
                  }));
            }
        }
        // команда удаления
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Phone phone = selectedItem as Phone;
                      db.Phones.Remove(phone);
                      db.SaveChanges();
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
