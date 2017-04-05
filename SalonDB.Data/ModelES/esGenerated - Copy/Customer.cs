
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 2016-12-23 2:58:23 PM
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'Customer' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Customer))]	
	[XmlType("Customer")]
	public partial class Customer : esCustomer
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Customer();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid customerID)
		{
			var obj = new Customer();
			obj.CustomerID = customerID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid customerID, esSqlAccessType sqlAccessType)
		{
			var obj = new Customer();
			obj.CustomerID = customerID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("CustomerCollection")]
	public partial class CustomerCollection : esCustomerCollection, IEnumerable<Customer>
	{
		public Customer FindByPrimaryKey(System.Guid customerID)
		{
			return this.SingleOrDefault(e => e.CustomerID == customerID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Customer))]
		public class CustomerCollectionWCFPacket : esCollectionWCFPacket<CustomerCollection>
		{
			public static implicit operator CustomerCollection(CustomerCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator CustomerCollectionWCFPacket(CustomerCollection collection)
			{
				return new CustomerCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class CustomerQuery : esCustomerQuery
	{
		public CustomerQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "CustomerQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CustomerQuery query)
		{
			return CustomerQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CustomerQuery(string query)
		{
			return (CustomerQuery)CustomerQuery.SerializeHelper.FromXml(query, typeof(CustomerQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esCustomer : EntityBase
	{
		public esCustomer()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid customerID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerID);
			else
				return LoadByPrimaryKeyStoredProcedure(customerID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid customerID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerID);
			else
				return LoadByPrimaryKeyStoredProcedure(customerID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid customerID)
		{
			CustomerQuery query = new CustomerQuery();
			query.Where(query.CustomerID == customerID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid customerID)
		{
			esParameters parms = new esParameters();
			parms.Add("CustomerID", customerID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Customer.CustomerID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CustomerID
		{
			get
			{
				return base.GetSystemGuid(CustomerMetadata.ColumnNames.CustomerID);
			}
			
			set
			{
				if(base.SetSystemGuid(CustomerMetadata.ColumnNames.CustomerID, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.CustomerID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.CompanyID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CompanyID
		{
			get
			{
				return base.GetSystemGuid(CustomerMetadata.ColumnNames.CompanyID);
			}
			
			set
			{
				if(base.SetSystemGuid(CustomerMetadata.ColumnNames.CompanyID, value))
				{
					this._UpToCompanyByCompanyID = null;
					this.OnPropertyChanged("UpToCompanyByCompanyID");
					OnPropertyChanged(CustomerMetadata.PropertyNames.CompanyID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.FirstName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String FirstName
		{
			get
			{
				return base.GetSystemString(CustomerMetadata.ColumnNames.FirstName);
			}
			
			set
			{
				if(base.SetSystemString(CustomerMetadata.ColumnNames.FirstName, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.FirstName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.LastName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String LastName
		{
			get
			{
				return base.GetSystemString(CustomerMetadata.ColumnNames.LastName);
			}
			
			set
			{
				if(base.SetSystemString(CustomerMetadata.ColumnNames.LastName, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.LastName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.Phone
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Phone
		{
			get
			{
				return base.GetSystemString(CustomerMetadata.ColumnNames.Phone);
			}
			
			set
			{
				if(base.SetSystemString(CustomerMetadata.ColumnNames.Phone, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.Phone);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.Email
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Email
		{
			get
			{
				return base.GetSystemString(CustomerMetadata.ColumnNames.Email);
			}
			
			set
			{
				if(base.SetSystemString(CustomerMetadata.ColumnNames.Email, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.Email);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.Address
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Address
		{
			get
			{
				return base.GetSystemString(CustomerMetadata.ColumnNames.Address);
			}
			
			set
			{
				if(base.SetSystemString(CustomerMetadata.ColumnNames.Address, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.Address);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.City
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String City
		{
			get
			{
				return base.GetSystemString(CustomerMetadata.ColumnNames.City);
			}
			
			set
			{
				if(base.SetSystemString(CustomerMetadata.ColumnNames.City, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.City);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.PostalCode
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String PostalCode
		{
			get
			{
				return base.GetSystemString(CustomerMetadata.ColumnNames.PostalCode);
			}
			
			set
			{
				if(base.SetSystemString(CustomerMetadata.ColumnNames.PostalCode, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.PostalCode);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.Discount
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Discount
		{
			get
			{
				return base.GetSystemDecimal(CustomerMetadata.ColumnNames.Discount);
			}
			
			set
			{
				if(base.SetSystemDecimal(CustomerMetadata.ColumnNames.Discount, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.Discount);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.Notes
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Notes
		{
			get
			{
				return base.GetSystemString(CustomerMetadata.ColumnNames.Notes);
			}
			
			set
			{
				if(base.SetSystemString(CustomerMetadata.ColumnNames.Notes, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.Notes);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Company _UpToCompanyByCompanyID;
		#endregion	

		#region .str() Properties
		
		public override void SetProperties(IDictionary values)
		{
			foreach (string propertyName in values.Keys)
			{
				this.SetProperty(propertyName, values[propertyName]);
			}
		}
		
		public override void SetProperty(string name, object value)
		{
			esColumnMetadata col = this.Meta.Columns.FindByPropertyName(name);
			if (col != null)
			{
				if(value == null || value is System.String)
				{				
					// Use the strongly typed property
					switch (name)
					{							
						case "CustomerID": this.str().CustomerID = (string)value; break;							
						case "CompanyID": this.str().CompanyID = (string)value; break;							
						case "FirstName": this.str().FirstName = (string)value; break;							
						case "LastName": this.str().LastName = (string)value; break;							
						case "Phone": this.str().Phone = (string)value; break;							
						case "Email": this.str().Email = (string)value; break;							
						case "Address": this.str().Address = (string)value; break;							
						case "City": this.str().City = (string)value; break;							
						case "PostalCode": this.str().PostalCode = (string)value; break;							
						case "Discount": this.str().Discount = (string)value; break;							
						case "Notes": this.str().Notes = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "CustomerID":
						
							if (value == null || value is System.Guid)
								this.CustomerID = (System.Guid?)value;
								OnPropertyChanged(CustomerMetadata.PropertyNames.CustomerID);
							break;
						
						case "CompanyID":
						
							if (value == null || value is System.Guid)
								this.CompanyID = (System.Guid?)value;
								OnPropertyChanged(CustomerMetadata.PropertyNames.CompanyID);
							break;
						
						case "Discount":
						
							if (value == null || value is System.Decimal)
								this.Discount = (System.Decimal?)value;
								OnPropertyChanged(CustomerMetadata.PropertyNames.Discount);
							break;
					

						default:
							break;
					}
				}
			}
            else if (this.ContainsColumn(name))
            {
                this.SetColumn(name, value);
            }
			else
			{
				throw new Exception("SetProperty Error: '" + name + "' not found");
			}
		}		

		public esStrings str()
		{
			if (esstrings == null)
			{
				esstrings = new esStrings(this);
			}
			return esstrings;
		}

		sealed public class esStrings
		{
			public esStrings(esCustomer entity)
			{
				this.entity = entity;
			}
			
	
			public System.String CustomerID
			{
				get
				{
					System.Guid? data = entity.CustomerID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CustomerID = null;
					else entity.CustomerID = new Guid(value);
				}
			}
				
			public System.String CompanyID
			{
				get
				{
					System.Guid? data = entity.CompanyID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CompanyID = null;
					else entity.CompanyID = new Guid(value);
				}
			}
				
			public System.String FirstName
			{
				get
				{
					System.String data = entity.FirstName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.FirstName = null;
					else entity.FirstName = Convert.ToString(value);
				}
			}
				
			public System.String LastName
			{
				get
				{
					System.String data = entity.LastName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.LastName = null;
					else entity.LastName = Convert.ToString(value);
				}
			}
				
			public System.String Phone
			{
				get
				{
					System.String data = entity.Phone;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Phone = null;
					else entity.Phone = Convert.ToString(value);
				}
			}
				
			public System.String Email
			{
				get
				{
					System.String data = entity.Email;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Email = null;
					else entity.Email = Convert.ToString(value);
				}
			}
				
			public System.String Address
			{
				get
				{
					System.String data = entity.Address;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Address = null;
					else entity.Address = Convert.ToString(value);
				}
			}
				
			public System.String City
			{
				get
				{
					System.String data = entity.City;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.City = null;
					else entity.City = Convert.ToString(value);
				}
			}
				
			public System.String PostalCode
			{
				get
				{
					System.String data = entity.PostalCode;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.PostalCode = null;
					else entity.PostalCode = Convert.ToString(value);
				}
			}
				
			public System.String Discount
			{
				get
				{
					System.Decimal? data = entity.Discount;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Discount = null;
					else entity.Discount = Convert.ToDecimal(value);
				}
			}
				
			public System.String Notes
			{
				get
				{
					System.String data = entity.Notes;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Notes = null;
					else entity.Notes = Convert.ToString(value);
				}
			}
			

			private esCustomer entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return CustomerMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public CustomerQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomerQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomerQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(CustomerQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private CustomerQuery query;		
	}



	[Serializable]
	abstract public partial class esCustomerCollection : CollectionBase<Customer>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return CustomerMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "CustomerCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public CustomerQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomerQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomerQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new CustomerQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(CustomerQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((CustomerQuery)query);
		}

		#endregion
		
		private CustomerQuery query;
	}



	[Serializable]
	abstract public partial class esCustomerQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return CustomerMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "CustomerID": return this.CustomerID;
				case "CompanyID": return this.CompanyID;
				case "FirstName": return this.FirstName;
				case "LastName": return this.LastName;
				case "Phone": return this.Phone;
				case "Email": return this.Email;
				case "Address": return this.Address;
				case "City": return this.City;
				case "PostalCode": return this.PostalCode;
				case "Discount": return this.Discount;
				case "Notes": return this.Notes;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem CustomerID
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.CustomerID, esSystemType.Guid); }
		} 
		
		public esQueryItem CompanyID
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.CompanyID, esSystemType.Guid); }
		} 
		
		public esQueryItem FirstName
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.FirstName, esSystemType.String); }
		} 
		
		public esQueryItem LastName
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.LastName, esSystemType.String); }
		} 
		
		public esQueryItem Phone
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.Phone, esSystemType.String); }
		} 
		
		public esQueryItem Email
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.Email, esSystemType.String); }
		} 
		
		public esQueryItem Address
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.Address, esSystemType.String); }
		} 
		
		public esQueryItem City
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.City, esSystemType.String); }
		} 
		
		public esQueryItem PostalCode
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.PostalCode, esSystemType.String); }
		} 
		
		public esQueryItem Discount
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.Discount, esSystemType.Decimal); }
		} 
		
		public esQueryItem Notes
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.Notes, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Customer : esCustomer
	{

		#region AppointmentCollectionByCustomerID - Zero To Many
		
		static public esPrefetchMap Prefetch_AppointmentCollectionByCustomerID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Customer.AppointmentCollectionByCustomerID_Delegate;
				map.PropertyName = "AppointmentCollectionByCustomerID";
				map.MyColumnName = "CustomerID";
				map.ParentColumnName = "CustomerID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void AppointmentCollectionByCustomerID_Delegate(esPrefetchParameters data)
		{
			CustomerQuery parent = new CustomerQuery(data.NextAlias());

			AppointmentQuery me = data.You != null ? data.You as AppointmentQuery : new AppointmentQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CustomerID == me.CustomerID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Appointment_Customer
		/// </summary>

		[XmlIgnore]
		public AppointmentCollection AppointmentCollectionByCustomerID
		{
			get
			{
				if(this._AppointmentCollectionByCustomerID == null)
				{
					this._AppointmentCollectionByCustomerID = new AppointmentCollection();
					this._AppointmentCollectionByCustomerID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("AppointmentCollectionByCustomerID", this._AppointmentCollectionByCustomerID);
				
					if (this.CustomerID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._AppointmentCollectionByCustomerID.Query.Where(this._AppointmentCollectionByCustomerID.Query.CustomerID == this.CustomerID);
							this._AppointmentCollectionByCustomerID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._AppointmentCollectionByCustomerID.fks.Add(AppointmentMetadata.ColumnNames.CustomerID, this.CustomerID);
					}
				}

				return this._AppointmentCollectionByCustomerID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._AppointmentCollectionByCustomerID != null) 
				{ 
					this.RemovePostSave("AppointmentCollectionByCustomerID"); 
					this._AppointmentCollectionByCustomerID = null;
					this.OnPropertyChanged("AppointmentCollectionByCustomerID");
				} 
			} 			
		}
			
		
		private AppointmentCollection _AppointmentCollectionByCustomerID;
		#endregion

				
		#region UpToCompanyByCompanyID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Customer_Company
		/// </summary>

		[XmlIgnore]
					
		public Company UpToCompanyByCompanyID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToCompanyByCompanyID == null && CompanyID != null)
				{
					this._UpToCompanyByCompanyID = new Company();
					this._UpToCompanyByCompanyID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToCompanyByCompanyID", this._UpToCompanyByCompanyID);
					this._UpToCompanyByCompanyID.Query.Where(this._UpToCompanyByCompanyID.Query.CompanyID == this.CompanyID);
					this._UpToCompanyByCompanyID.Query.Load();
				}	
				return this._UpToCompanyByCompanyID;
			}
			
			set
			{
				this.RemovePreSave("UpToCompanyByCompanyID");
				
				bool changed = this._UpToCompanyByCompanyID != value;

				if(value == null)
				{
					this.CompanyID = null;
					this._UpToCompanyByCompanyID = null;
				}
				else
				{
					this.CompanyID = value.CompanyID;
					this._UpToCompanyByCompanyID = value;
					this.SetPreSave("UpToCompanyByCompanyID", this._UpToCompanyByCompanyID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToCompanyByCompanyID");
				}
			}
		}
		#endregion
		

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "AppointmentCollectionByCustomerID":
					coll = this.AppointmentCollectionByCustomerID;
					break;	
			}

			return coll;
		}		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();
			
			props.Add(new esPropertyDescriptor(this, "AppointmentCollectionByCustomerID", typeof(AppointmentCollection), new Appointment()));
		
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToCompanyByCompanyID != null)
			{
				this.CompanyID = this._UpToCompanyByCompanyID.CompanyID;
			}
		}
		
		/// <summary>
		/// Called by ApplyPostSaveKeys 
		/// </summary>
		/// <param name="coll">The collection to enumerate over</param>
		/// <param name="key">"The column name</param>
		/// <param name="value">The column value</param>
		private void Apply(esEntityCollectionBase coll, string key, object value)
		{
			foreach (esEntity obj in coll)
			{
				if (obj.es.IsAdded)
				{
					obj.SetProperty(key, value);
				}
			}
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
			if(this._AppointmentCollectionByCustomerID != null)
			{
				Apply(this._AppointmentCollectionByCustomerID, "CustomerID", this.CustomerID);
			}
		}
		
	}
	



	[Serializable]
	public partial class CustomerMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CustomerMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(CustomerMetadata.ColumnNames.CustomerID, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = CustomerMetadata.PropertyNames.CustomerID;
			c.IsInPrimaryKey = true;
			c.HasDefault = true;
			c.Default = @"(newid())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.CompanyID, 1, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = CustomerMetadata.PropertyNames.CompanyID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.FirstName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerMetadata.PropertyNames.FirstName;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.LastName, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerMetadata.PropertyNames.LastName;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.Phone, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerMetadata.PropertyNames.Phone;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.Email, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerMetadata.PropertyNames.Email;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.Address, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerMetadata.PropertyNames.Address;
			c.CharacterMaxLength = 500;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.City, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerMetadata.PropertyNames.City;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.PostalCode, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerMetadata.PropertyNames.PostalCode;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.Discount, 9, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = CustomerMetadata.PropertyNames.Discount;
			c.NumericPrecision = 18;
			c.NumericScale = 4;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.Notes, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerMetadata.PropertyNames.Notes;
			c.CharacterMaxLength = 500;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public CustomerMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base.m_dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return false; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base.m_columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string CustomerID = "CustomerID";
			 public const string CompanyID = "CompanyID";
			 public const string FirstName = "FirstName";
			 public const string LastName = "LastName";
			 public const string Phone = "Phone";
			 public const string Email = "Email";
			 public const string Address = "Address";
			 public const string City = "City";
			 public const string PostalCode = "PostalCode";
			 public const string Discount = "Discount";
			 public const string Notes = "Notes";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string CustomerID = "CustomerID";
			 public const string CompanyID = "CompanyID";
			 public const string FirstName = "FirstName";
			 public const string LastName = "LastName";
			 public const string Phone = "Phone";
			 public const string Email = "Email";
			 public const string Address = "Address";
			 public const string City = "City";
			 public const string PostalCode = "PostalCode";
			 public const string Discount = "Discount";
			 public const string Notes = "Notes";
		}
		#endregion	

		public esProviderSpecificMetadata GetProviderMetadata(string mapName)
		{
			MapToMeta mapMethod = mapDelegates[mapName];

			if (mapMethod != null)
				return mapMethod(mapName);
			else
				return null;
		}
		
		#region MAP esDefault
		
		static private int RegisterDelegateesDefault()
		{
			// This is only executed once per the life of the application
			lock (typeof(CustomerMetadata))
			{
				if(CustomerMetadata.mapDelegates == null)
				{
					CustomerMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomerMetadata.meta == null)
				{
					CustomerMetadata.meta = new CustomerMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();			


				meta.AddTypeMap("CustomerID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("CompanyID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("FirstName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("LastName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Phone", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Email", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Address", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("City", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("PostalCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Discount", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("Notes", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "Customer";
				meta.Destination = "Customer";
				
				meta.spInsert = "proc_CustomerInsert";				
				meta.spUpdate = "proc_CustomerUpdate";		
				meta.spDelete = "proc_CustomerDelete";
				meta.spLoadAll = "proc_CustomerLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomerLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private CustomerMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
