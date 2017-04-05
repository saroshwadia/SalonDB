/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 2017-01-20 9:46:09 PM
===============================================================================
*/

using System;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

namespace BusinessObjects
{
    public partial class ServiceTransactionsView : esServiceTransactionsView
    {
        public ServiceTransactionsView()
        {

        }

        //override protected  System.Collections.Generic.List<EntitySpaces.Core.esPropertyDescriptor> GetLocalBindingProperties()
        //{
        //    var props = new System.Collections.Generic.List<EntitySpaces.Core.esPropertyDescriptor>();
        //    props.Add(new EntitySpaces.Core.esPropertyDescriptor(this, "MonthSort", typeof(int)));
        //    return props;

        //}

        //public int MonthSort {
        //    get {
        //        int RetValue=0;
        //        switch (this.Month)
        //        {
        //            case 1:
        //                Console.WriteLine("Case 1");
        //                break;
        //            case 2:
        //                Console.WriteLine("Case 2");
        //                break;
        //            default:
        //                Console.WriteLine("Default case");
        //                break;
        //        }


        //        return RetValue;
        //    }

    }

}
       

