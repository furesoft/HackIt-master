using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Windows.Forms;

namespace HackIt.Core
{
    public static class ServiceLocator
    {
        public class DynamicDictionary : DynamicObject
        {
            internal static Dictionary<string, List<IObserver<object>>> _dictionary;
                        static DynamicDictionary()
            {
                _dictionary = new Dictionary<string, List<IObserver<object>>>();
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                List<IObserver<object>> data;
                if (!_dictionary.TryGetValue(binder.Name, out data))
                {
                    throw new KeyNotFoundException("There's no key by that name");
                }

                result = data;

                return true;
            }

            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                if (_dictionary.ContainsKey(binder.Name))
                {
                    _dictionary[binder.Name] = (List<IObserver<object>>)value;
                }
                else
                {
                    _dictionary.Add(binder.Name, (List<IObserver<object>>)value);
                }

                return true;
            }
        }
        public class Observer : IObserver<object>
        {
            private Action<object> _handler;

            public Observer(Action<object> handler)
            {
                _handler = handler;
            }

            public void OnCompleted()
            {
                return;
            }

            public void OnError(Exception error)
            {
                _handler(error);
            }

            public void OnNext(object value)
            {
                _handler(value);
            }
        }

        static Dictionary<string, object> _data = new Dictionary<string, object>();
        static DynamicDictionary Events = new DynamicDictionary();

        public static void CallEvent(string name, object arg)
        {
            if(DynamicDictionary._dictionary.ContainsKey(name))
            {
                foreach (var e in DynamicDictionary._dictionary [name])
                {
                    e.OnNext(arg);
                }
            }
        }

        public static void Subscribe(string name, Action<object> handler)
        {
            if (DynamicDictionary._dictionary.ContainsKey(name))
            {
                var v = DynamicDictionary._dictionary[name];
                if (v != null)
                {
                    v.Add(new Observer(handler));
                }
            }
            else
            {
                DynamicDictionary._dictionary.Add(name, new List<IObserver<object>>());
                var v = DynamicDictionary._dictionary[name];

                v.Add(new Observer(handler));
            }
            
        }

        public static object Add(string k, object v)
        {
            if (_data.ContainsKey(k))
            {
                _data[k] = v;
            }
            else
            {
                _data.Add(k, v);
            }

            return v;
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