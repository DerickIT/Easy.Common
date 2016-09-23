using Sinosoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sinosoft.Interfaces
{
   public  interface IValidData
    {
       void ValidOracleHelper(string TableName, List<DataAttrEntity> Alist, List<DataAttrEntity> Blist, Action<string, DataAttrEntity, DataAttrEntity> VolidAtt,Action<string,DataAttrEntity> AddAction);
    }
}
