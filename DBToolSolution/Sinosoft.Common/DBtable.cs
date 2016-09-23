using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Sinosoft.Common
{
    public class DBtable : ConfigurationElement
    {
        //[ConfigurationProperty("values", IsDefaultCollection = true)]
        //[ConfigurationCollection(typeof(GetValues), AddItemName = "values")]
        //public valueCollection values
        //{
        //    get { return (valueCollection)base["values"]; }
        //    set { base["values"] = value; }
        //}
    }
    public class DBtable1 : ConfigurationElement
    {

    }
    public class valueCollection : ConfigurationElementCollection
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new GetValues();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((GetValues)element).TableName;
        }

        public new GetValues this[string key]
        {
            get { return (GetValues)base.BaseGet(key); }
        }

        public GetValues this[int index]
        {
            get { return (GetValues)base.BaseGet(index); }
        }

        public List<GetValues> ToList()
        {
            var list = new List<GetValues>();
            IEnumerator ie = this.GetEnumerator();
            while (ie.MoveNext())
                list.Add(ie.Current as GetValues);
            return list;
        }
    }
    public class GetValues : ConfigurationElement
    {
        [ConfigurationProperty("tablename", IsRequired = true)]
        public string TableName
        {
            get { return (string)base["tablename"]; }
            set { base["tablename"] = value; }
        }
        [ConfigurationProperty("desc", IsRequired = true)]
        public string Desc
        {
            get { return (string)base["desc"]; }
            set { base["desc"] = value; }
        }
    }
}
