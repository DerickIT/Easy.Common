using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sinosoft.Interfaces;
using Sinosoft.Model;
using Sinosoft.Output;
namespace Sinosoft.ValidLibrary
{
    public class ValidFunc : IValidData
    {

        public void ValidOracleHelper(string TableName, List<DataAttrEntity> Alist, List<DataAttrEntity> Blist, Action<string, DataAttrEntity, DataAttrEntity> VolidAction, Action<string, DataAttrEntity> AddAction)
        {
            if (Alist != null && Alist.Count > 0)
            {
                if (Blist != null && Blist.Count > 0)
                {

                    var vc = new ValidClass(); var comp = new IEComparer();
                    for (int i = 0; i < Alist.Count; i++)
                    {
                        if (i < Blist.Count)
                        {

                            var index = Alist.FindIndex(a => a.ColumnName == Blist[i].ColumnName);
                            if (index >= 0)
                            {
                                Alist[index].Flag = true;//然后验证标记是否是true，如果是true就比较和更改，如果不是，就跳过，
                                VolidAction(TableName, Alist[index], Blist[i]);
                                if (!Alist[i].Flag)
                                {
                                    if (Alist[i].ColumnName == (Blist[i].ColumnName))
                                    {
                                        //在这里面先判断A的type，然后根据A的type比较B的type，不是两个相等，
                                        VolidAction(TableName, Alist[i], Blist[i]);
                                        //存在，就比较类型，大小，
                                    }
                                    else
                                    {
                                        AddAction(TableName, Alist[i]);
                                        //不存在，就生成新的sql
                                    }
                                }
                            }
                            else
                            {
                                if (!Alist[i].Flag)
                                {
                                    if (Alist[i].ColumnName == (Blist[i].ColumnName))
                                    {
                                        //在这里面先判断A的type，然后根据A的type比较B的type，不是两个相等，
                                        VolidAction(TableName, Alist[i], Blist[i]);
                                        //存在，就比较类型，大小，

                                    }
                                    else
                                    {
                                        AddAction(TableName, Alist[i]);
                                        //不存在，就生成新的sql
                                    }
                                }
                            }
                        }
                        else
                        {
                            //生成剩下的添加语句
                            if (!Alist[i].Flag)
                            {
                                AddAction(TableName, Alist[i]);
                            }

                        }
                    }
                }
                else
                {
                    var vc = new ValidClass();
                    for (int i = 0; i < Alist.Count; i++)
                    {
                        AddAction(TableName, Alist[i]);
                    }
                }
            }

        }

    }
}


