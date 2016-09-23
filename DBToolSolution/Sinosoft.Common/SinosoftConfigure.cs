using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace Sinosoft.Common
{
    public class SinosoftConfigure : ConfigurationSection
    {


        [ConfigurationProperty("DBtable", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(GetValues), AddItemName = "values")]
        public valueCollection DBtable
        {
            get { return (valueCollection)base["DBtable"]; }
            set { base["DBtable"] = value; }
        }

        [ConfigurationProperty("DBtable1", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(GetValues), AddItemName = "values")]
        public valueCollection DBtable1
        {
            get
            {
                return (valueCollection)base["DBtable1"];


            }
            set { base["DBtable1"] = value; }
        }



        //public dbs dbs
        //{
        //    get { return (dbs)base["dbs"]; }
        //    set { base["dbs"] = value; }
        //}

    }






    //public class dbs : ConfigurationElementCollection
    //{

    //    protected override ConfigurationElement CreateNewElement()
    //    {
    //        return new db();
    //    }

    //    protected override object GetElementKey(ConfigurationElement element)
    //    {
    //        return ((db)element).name;
    //    }

    //    public db this[string key]
    //    {
    //        get { return (db)base.BaseGet(key); }
    //    }
    //}

    //public class db : ConfigurationElement
    //{
    //    public string name { set; get; }

    //    public tables tbs;
    //}

    //public class tables : ConfigurationElementCollection
    //{

    //    protected override ConfigurationElement CreateNewElement()
    //    {
    //        return new table();
    //    }

    //    protected override object GetElementKey(ConfigurationElement element)
    //    {
    //        return ((table)element).tablename;
    //    }

    //    public table this[string key]
    //    {
    //        get { return (table)base.BaseGet(key); }
    //    }

    //    public table this[int index]
    //    {
    //        get { return (table)base.BaseGet(index); }
    //    }
    //}

    //public class table : ConfigurationElement
    //{
    //    public string tablename { set; get; }
    //    public string des { set; get; }
    //}
}