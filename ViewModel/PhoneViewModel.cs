using SQLiteWpfSample.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWpfSample.ViewModel
{
    // Crtl + r Ctrl +E
    public class PhoneViewModel
    {
        private int Id;
        private string title;
        private string company;
        private int price;   
      
        private IList<KeyValuePair<int, string>> statuses = new List<KeyValuePair<int, string>>();
        private KeyValuePair<int, string> currentStatus;

        public PhoneViewModel()
        {
            Id = 0;
            Statuses = KeyValueHelper.GetStatusKeyValuePairs();
            this.CurrentStatus = KeyValueHelper.GetStatusKeyValueByKey();

        }

        public PhoneViewModel(Phone phone)
        {
            this.Id = ID;
            this.title = phone.Title;
            this.company = phone.Company;
            this.price = phone.Price;
            this.CurrentStatus = KeyValueHelper.GetStatusKeyValueByKey(phone.Status); // new KeyValuePair<int,string>(-1,"");

            Statuses = KeyValueHelper.GetStatusKeyValuePairs();

        }
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                company = value;
            }
        }

        public int Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public KeyValuePair<int, string> CurrentStatus
        {
            get
            {
                return currentStatus;
            }

            set
            {
                currentStatus = value;
            }
        }

        public int ID
        {
            get
            {
                return Id;
            }

            set
            {
                Id = value;
            }
        }

        public IList<KeyValuePair<int, string>> Statuses
        {
            get
            {
                return statuses;
            }

            set
            {
                statuses = value;
            }
        }
    }
}
