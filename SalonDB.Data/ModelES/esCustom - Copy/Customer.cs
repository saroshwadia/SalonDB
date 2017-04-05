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
	public partial class Customer : esCustomer
	{
		public Customer()
		{
		
		}

        protected override List<esPropertyDescriptor> GetLocalBindingProperties()
        {
            var props = new List<esPropertyDescriptor>();
            props.Add(new EntitySpaces.Core.esPropertyDescriptor(this, "Name", typeof(string)));

            return props;
        }

        public string Name
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
            set
            {
            }         
        }

    }
}
