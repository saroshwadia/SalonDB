/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 2016-12-14 11:41:15 AM
===============================================================================
*/

using System;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;
using System.Collections.Generic;

namespace BusinessObjects
{
	public partial class Service : esService
	{
		public Service()
		{
		
		}

        protected override List<esPropertyDescriptor> GetLocalBindingProperties()
        {
            var props = new List<esPropertyDescriptor>();
            props.Add(new EntitySpaces.Core.esPropertyDescriptor(this, "CategoryName", typeof(string)));

            return props;
        }

        public string CategoryName
        {
            get
            {
                var ReturnValue = string.Empty;

                if (this.UpToCategoryByCategoryID != null)
                {
                    ReturnValue = this.UpToCategoryByCategoryID.Name;
                }

                return ReturnValue;
            }
            set
            {
            }
        }
    }
}
