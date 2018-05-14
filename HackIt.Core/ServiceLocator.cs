using System.Collections.Generic;
using System.Windows.Forms;

namespace HackIt.Core
{
    public static class ServiceLocator
    {
        static Dictionary<string, object> _data = new Dictionary<string, object>();

        public static void Add(string k, object v)
        {
            if (_data.ContainsKey(k))
            {
                _data[k] = v;
            }
            else
            {
                _data.Add(k, v);
            }
        }

        public static T Get<T>(string k) where T : class
        {
            if (!_data.ContainsKey(k))
                if(MessageBox.Show("Please Select an Mission") == DialogResult.OK)
                {
                    return null;
                }

            return _data[k] as T;
        }
    }
}