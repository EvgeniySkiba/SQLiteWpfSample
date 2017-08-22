using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWpfSample.Helpers
{
    public static class KeyValueHelper
    {
        public static IList<KeyValuePair<int, string>> GetStatusKeyValuePairs()
        {
            IList<KeyValuePair<int, string>> keyPairsList = new List<KeyValuePair<int, string>>();

            foreach (var name in Enum.GetNames(typeof(Status)))
            {

                int key = (int)Enum.Parse(typeof(Status), name);
                string value = name;
                KeyValuePair<int, string> keyVal = new KeyValuePair<int, string>(key, value);
                keyPairsList.Add(keyVal);
            }

            return keyPairsList;
        }

        public static KeyValuePair<int, string> GetStatusKeyValueByKey(int currentKey  = -1)
        {
            KeyValuePair<int, string> item = new KeyValuePair<int, string>(currentKey, "");

            foreach (var name in Enum.GetNames(typeof(Status)))
            {
                int itemKey = (int)Enum.Parse(typeof(Status), name);
                if (itemKey == currentKey)
                {
                    string value = name;
                    item = new KeyValuePair<int, string>(currentKey, value);
                    break;
                }
            }

            return item;
        }

    }
}
