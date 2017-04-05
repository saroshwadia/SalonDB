
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
	/// Encapsulates the 'Company' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Company))]	
	[XmlType("Company")]
	public partial class Company : esCompany
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Company();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid companyID)
		{
			var obj = new Company();
			obj.CompanyID = companyID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid companyID, esSqlAccessType sqlAccessType)
		{
			var obj = new Company();
			obj.CompanyID = companyID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("CompanyCollection")]
	public partial class CompanyCollection : esCompanyCollection, IEnumerable<Company>
	{
		public Company FindByPrimaryKey(System.Guid companyID)
		{
			return this.SingleOrDefault(e => e.CompanyID == companyID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Company))]
		public class CompanyCollectionWCFPacket : esCollectionWCFPacket<CompanyCollection>
		{
			public static implicit operator CompanyCollection(CompanyCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator CompanyCollectionWCFPacket(CompanyCollection collection)
			{
				return new CompanyCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class CompanyQuery : esCompanyQuery
	{
		public CompanyQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "CompanyQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CompanyQuery query)
		{
			return CompanyQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CompanyQuery(string query)
		{
			return (CompanyQuery)CompanyQuery.SerializeHelper.FromXml(query, typeof(CompanyQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esCompany : EntityBase
	{
		public esCompany()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid companyID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(companyID);
			else
				return LoadByPrimaryKeyStoredProcedure(companyID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid companyID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(companyID);
			else
				return LoadByPrimaryKeyStoredProcedure(companyID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid companyID)
		{
			CompanyQuery query = new CompanyQuery();
			query.Where(query.CompanyID == companyID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid companyID)
		{
			esParameters parms = new esParameters();
			parms.Add("CompanyID", companyID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Company.CompanyID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CompanyID
		{
			get
			{
				return base.GetSystemGuid(CompanyMetadata.ColumnNames.CompanyID);
			}
			
			set
			{
				if(base.SetSystemGuid(CompanyMetadata.ColumnNames.CompanyID, value))
				{
					OnPropertyChanged(CompanyMetadata.PropertyNames.CompanyID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Company.Name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(CompanyMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(CompanyMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(CompanyMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Company.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(CompanyMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(CompanyMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(CompanyMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Company.Phone
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Phone
		{
			get
			{
				return base.GetSystemString(CompanyMetadata.ColumnNames.Phone);
			}
			
			set
			{
				if(base.SetSystemString(CompanyMetadata.ColumnNames.Phone, value))
				{
					OnPropertyChanged(CompanyMetadata.PropertyNames.Phone);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Company.Address
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Address
		{
			get
			{
				return base.GetSystemString(CompanyMetadata.ColumnNames.Address);
			}
			
			set
			{
				if(base.SetSystemString(CompanyMetadata.ColumnNames.Address, value))
				{
					OnPropertyChanged(CompanyMetadata.PropertyNames.Address);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Company.City
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String City
		{
			get
			{
				return base.GetSystemString(CompanyMetadata.ColumnNames.City);
			}
			
			set
			{
				if(base.SetSystemString(CompanyMetadata.ColumnNames.City, value))
				{
					OnPropertyChanged(CompanyMetadata.PropertyNames.City);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Company.PostalCode
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String PostalCode
		{
			get
			{
				return base.GetSystemString(CompanyMetadata.ColumnNames.PostalCode);
			}
			
			set
			{
				if(base.SetSystemString(CompanyMetadata.ColumnNames.PostalCode, value))
				{
					OnPropertyChanged(CompanyMetadata.PropertyNames.PostalCode);
				}
			}
		}		
		
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
						case "CompanyID": this.str().CompanyID = (string)value; break;							
						case "Name": this.str().Name = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;							
						case "Phone": this.str().Phone = (string)value; break;							
						case "Address": this.str().Address = (string)value; break;							
						case "City": this.str().City = (string)value; break;							
						case "PostalCode": this.str().PostalCode = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "CompanyID":
						
							if (value == null || value is System.Guid)
								this.CompanyID = (System.Guid?)value;
								OnPropertyChanged(CompanyMetadata.PropertyNames.CompanyID);
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
			public esStrings(esCompany entity)
			{
				this.entity = entity;
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
				
			public System.String Name
			{
				get
				{
					System.String data = entity.Name;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Name = null;
					else entity.Name = Convert.ToString(value);
				}
			}
				
			public System.String Description
			{
				get
				{
					System.String data = entity.Description;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Description = null;
					else entity.Description = Convert.ToString(value);
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
			

			private esCompany entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return CompanyMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public CompanyQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CompanyQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CompanyQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(CompanyQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private CompanyQuery query;		
	}



	[Serializable]
	abstract public partial class esCompanyCollection : CollectionBase<Company>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return CompanyMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "CompanyCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public CompanyQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CompanyQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CompanyQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new CompanyQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(CompanyQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((CompanyQuery)query);
		}

		#endregion
		
		private CompanyQuery query;
	}



	[Serializable]
	abstract public partial class esCompanyQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return CompanyMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "CompanyID": return this.CompanyID;
				case "Name": return this.Name;
				case "Description": return this.Description;
				case "Phone": return this.Phone;
				case "Address": return this.Address;
				case "City": return this.City;
				case "PostalCode": return this.PostalCode;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem CompanyID
		{
			get { return new esQueryItem(this, CompanyMetadata.ColumnNames.CompanyID, esSystemType.Guid); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, CompanyMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, CompanyMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem Phone
		{
			get { return new esQueryItem(this, CompanyMetadata.ColumnNames.Phone, esSystemType.String); }
		} 
		
		public esQueryItem Address
		{
			get { return new esQueryItem(this, CompanyMetadata.ColumnNames.Address, esSystemType.String); }
		} 
		
		public esQueryItem City
		{
			get { return new esQueryItem(this, CompanyMetadata.ColumnNames.City, esSystemType.String); }
		} 
		
		public esQueryItem PostalCode
		{
			get { return new esQueryItem(this, CompanyMetadata.ColumnNames.PostalCode, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Company : esCompany
	{

		#region AppointmentCollectionByCompanyID - Zero To Many
		
		static public esPrefetchMap Prefetch_AppointmentCollectionByCompanyID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Company.AppointmentCollectionByCompanyID_Delegate;
				map.PropertyName = "AppointmentCollectionByCompanyID";
				map.MyColumnName = "CompanyID";
				map.ParentColumnName = "CompanyID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void AppointmentCollectionByCompanyID_Delegate(esPrefetchParameters data)
		{
			CompanyQuery parent = new CompanyQuery(data.NextAlias());

			AppointmentQuery me = data.You != null ? data.You as AppointmentQuery : new AppointmentQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CompanyID == me.CompanyID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Appointment_Company
		/// </summary>

		[XmlIgnore]
		public AppointmentCollection AppointmentCollectionByCompanyID
		{
			get
			{
				if(this._AppointmentCollectionByCompanyID == null)
				{
					this._AppointmentCollectionByCompanyID = new AppointmentCollection();
					this._AppointmentCollectionByCompanyID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("AppointmentCollectionByCompanyID", this._AppointmentCollectionByCompanyID);
				
					if (this.CompanyID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._AppointmentCollectionByCompanyID.Query.Where(this._AppointmentCollectionByCompanyID.Query.CompanyID == this.CompanyID);
							this._AppointmentCollectionByCompanyID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._AppointmentCollectionByCompanyID.fks.Add(AppointmentMetadata.ColumnNames.CompanyID, this.CompanyID);
					}
				}

				return this._AppointmentCollectionByCompanyID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._AppointmentCollectionByCompanyID != null) 
				{ 
					this.RemovePostSave("AppointmentCollectionByCompanyID"); 
					this._AppointmentCollectionByCompanyID = null;
					this.OnPropertyChanged("AppointmentCollectionByCompanyID");
				} 
			} 			
		}
			
		
		private AppointmentCollection _AppointmentCollectionByCompanyID;
		#endregion

		#region CategoryCollectionByCompanyID - Zero To Many
		
		static public esPrefetchMap Prefetch_CategoryCollectionByCompanyID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Company.CategoryCollectionByCompanyID_Delegate;
				map.PropertyName = "CategoryCollectionByCompanyID";
				map.MyColumnName = "CompanyID";
				map.ParentColumnName = "CompanyID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void CategoryCollectionByCompanyID_Delegate(esPrefetchParameters data)
		{
			CompanyQuery parent = new CompanyQuery(data.NextAlias());

			CategoryQuery me = data.You != null ? data.You as CategoryQuery : new CategoryQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CompanyID == me.CompanyID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Category_Company
		/// </summary>

		[XmlIgnore]
		public CategoryCollection CategoryCollectionByCompanyID
		{
			get
			{
				if(this._CategoryCollectionByCompanyID == null)
				{
					this._CategoryCollectionByCompanyID = new CategoryCollection();
					this._CategoryCollectionByCompanyID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("CategoryCollectionByCompanyID", this._CategoryCollectionByCompanyID);
				
					if (this.CompanyID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._CategoryCollectionByCompanyID.Query.Where(this._CategoryCollectionByCompanyID.Query.CompanyID == this.CompanyID);
							this._CategoryCollectionByCompanyID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._CategoryCollectionByCompanyID.fks.Add(CategoryMetadata.ColumnNames.CompanyID, this.CompanyID);
					}
				}

				return this._CategoryCollectionByCompanyID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._CategoryCollectionByCompanyID != null) 
				{ 
					this.RemovePostSave("CategoryCollectionByCompanyID"); 
					this._CategoryCollectionByCompanyID = null;
					this.OnPropertyChanged("CategoryCollectionByCompanyID");
				} 
			} 			
		}
			
		
		private CategoryCollection _CategoryCollectionByCompanyID;
		#endregion

		#region CustomerCollectionByCompanyID - Zero To Many
		
		static public esPrefetchMap Prefetch_CustomerCollectionByCompanyID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Company.CustomerCollectionByCompanyID_Delegate;
				map.PropertyName = "CustomerCollectionByCompanyID";
				map.MyColumnName = "CompanyID";
				map.ParentColumnName = "CompanyID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void CustomerCollectionByCompanyID_Delegate(esPrefetchParameters data)
		{
			CompanyQuery parent = new CompanyQuery(data.NextAlias());

			CustomerQuery me = data.You != null ? data.You as CustomerQuery : new CustomerQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CompanyID == me.CompanyID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Customer_Company
		/// </summary>

		[XmlIgnore]
		public CustomerCollection CustomerCollectionByCompanyID
		{
			get
			{
				if(this._CustomerCollectionByCompanyID == null)
				{
					this._CustomerCollectionByCompanyID = new CustomerCollection();
					this._CustomerCollectionByCompanyID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("CustomerCollectionByCompanyID", this._CustomerCollectionByCompanyID);
				
					if (this.CompanyID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._CustomerCollectionByCompanyID.Query.Where(this._CustomerCollectionByCompanyID.Query.CompanyID == this.CompanyID);
							this._CustomerCollectionByCompanyID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._CustomerCollectionByCompanyID.fks.Add(CustomerMetadata.ColumnNames.CompanyID, this.CompanyID);
					}
				}

				return this._CustomerCollectionByCompanyID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._CustomerCollectionByCompanyID != null) 
				{ 
					this.RemovePostSave("CustomerCollectionByCompanyID"); 
					this._CustomerCollectionByCompanyID = null;
					this.OnPropertyChanged("CustomerCollectionByCompanyID");
				} 
			} 			
		}
			
		
		private CustomerCollection _CustomerCollectionByCompanyID;
		#endregion

		#region ProductCollectionByCompanyID - Zero To Many
		
		static public esPrefetchMap Prefetch_ProductCollectionByCompanyID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Company.ProductCollectionByCompanyID_Delegate;
				map.PropertyName = "ProductCollectionByCompanyID";
				map.MyColumnName = "CompanyID";
				map.ParentColumnName = "CompanyID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void ProductCollectionByCompanyID_Delegate(esPrefetchParameters data)
		{
			CompanyQuery parent = new CompanyQuery(data.NextAlias());

			ProductQuery me = data.You != null ? data.You as ProductQuery : new ProductQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CompanyID == me.CompanyID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Product_Company
		/// </summary>

		[XmlIgnore]
		public ProductCollection ProductCollectionByCompanyID
		{
			get
			{
				if(this._ProductCollectionByCompanyID == null)
				{
					this._ProductCollectionByCompanyID = new ProductCollection();
					this._ProductCollectionByCompanyID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("ProductCollectionByCompanyID", this._ProductCollectionByCompanyID);
				
					if (this.CompanyID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._ProductCollectionByCompanyID.Query.Where(this._ProductCollectionByCompanyID.Query.CompanyID == this.CompanyID);
							this._ProductCollectionByCompanyID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._ProductCollectionByCompanyID.fks.Add(ProductMetadata.ColumnNames.CompanyID, this.CompanyID);
					}
				}

				return this._ProductCollectionByCompanyID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._ProductCollectionByCompanyID != null) 
				{ 
					this.RemovePostSave("ProductCollectionByCompanyID"); 
					this._ProductCollectionByCompanyID = null;
					this.OnPropertyChanged("ProductCollectionByCompanyID");
				} 
			} 			
		}
			
		
		private ProductCollection _ProductCollectionByCompanyID;
		#endregion

		#region ServiceCollectionByCompanyID - Zero To Many
		
		static public esPrefetchMap Prefetch_ServiceCollectionByCompanyID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Company.ServiceCollectionByCompanyID_Delegate;
				map.PropertyName = "ServiceCollectionByCompanyID";
				map.MyColumnName = "CompanyID";
				map.ParentColumnName = "CompanyID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void ServiceCollectionByCompanyID_Delegate(esPrefetchParameters data)
		{
			CompanyQuery parent = new CompanyQuery(data.NextAlias());

			ServiceQuery me = data.You != null ? data.You as ServiceQuery : new ServiceQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CompanyID == me.CompanyID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Service_Company
		/// </summary>

		[XmlIgnore]
		public ServiceCollection ServiceCollectionByCompanyID
		{
			get
			{
				if(this._ServiceCollectionByCompanyID == null)
				{
					this._ServiceCollectionByCompanyID = new ServiceCollection();
					this._ServiceCollectionByCompanyID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("ServiceCollectionByCompanyID", this._ServiceCollectionByCompanyID);
				
					if (this.CompanyID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._ServiceCollectionByCompanyID.Query.Where(this._ServiceCollectionByCompanyID.Query.CompanyID == this.CompanyID);
							this._ServiceCollectionByCompanyID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._ServiceCollectionByCompanyID.fks.Add(ServiceMetadata.ColumnNames.CompanyID, this.CompanyID);
					}
				}

				return this._ServiceCollectionByCompanyID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._ServiceCollectionByCompanyID != null) 
				{ 
					this.RemovePostSave("ServiceCollectionByCompanyID"); 
					this._ServiceCollectionByCompanyID = null;
					this.OnPropertyChanged("ServiceCollectionByCompanyID");
				} 
			} 			
		}
			
		
		private ServiceCollection _ServiceCollectionByCompanyID;
		#endregion

		#region StaffCollectionByCompanyID - Zero To Many
		
		static public esPrefetchMap Prefetch_StaffCollectionByCompanyID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Company.StaffCollectionByCompanyID_Delegate;
				map.PropertyName = "StaffCollectionByCompanyID";
				map.MyColumnName = "CompanyID";
				map.ParentColumnName = "CompanyID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void StaffCollectionByCompanyID_Delegate(esPrefetchParameters data)
		{
			CompanyQuery parent = new CompanyQuery(data.NextAlias());

			StaffQuery me = data.You != null ? data.You as StaffQuery : new StaffQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CompanyID == me.CompanyID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Staff_Company
		/// </summary>

		[XmlIgnore]
		public StaffCollection StaffCollectionByCompanyID
		{
			get
			{
				if(this._StaffCollectionByCompanyID == null)
				{
					this._StaffCollectionByCompanyID = new StaffCollection();
					this._StaffCollectionByCompanyID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("StaffCollectionByCompanyID", this._StaffCollectionByCompanyID);
				
					if (this.CompanyID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._StaffCollectionByCompanyID.Query.Where(this._StaffCollectionByCompanyID.Query.CompanyID == this.CompanyID);
							this._StaffCollectionByCompanyID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._StaffCollectionByCompanyID.fks.Add(StaffMetadata.ColumnNames.CompanyID, this.CompanyID);
					}
				}

				return this._StaffCollectionByCompanyID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._StaffCollectionByCompanyID != null) 
				{ 
					this.RemovePostSave("StaffCollectionByCompanyID"); 
					this._StaffCollectionByCompanyID = null;
					this.OnPropertyChanged("StaffCollectionByCompanyID");
				} 
			} 			
		}
			
		
		private StaffCollection _StaffCollectionByCompanyID;
		#endregion

		#region StaffHourCollectionByCompanyID - Zero To Many
		
		static public esPrefetchMap Prefetch_StaffHourCollectionByCompanyID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Company.StaffHourCollectionByCompanyID_Delegate;
				map.PropertyName = "StaffHourCollectionByCompanyID";
				map.MyColumnName = "CompanyID";
				map.ParentColumnName = "CompanyID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void StaffHourCollectionByCompanyID_Delegate(esPrefetchParameters data)
		{
			CompanyQuery parent = new CompanyQuery(data.NextAlias());

			StaffHourQuery me = data.You != null ? data.You as StaffHourQuery : new StaffHourQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CompanyID == me.CompanyID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_StaffHour_Company
		/// </summary>

		[XmlIgnore]
		public StaffHourCollection StaffHourCollectionByCompanyID
		{
			get
			{
				if(this._StaffHourCollectionByCompanyID == null)
				{
					this._StaffHourCollectionByCompanyID = new StaffHourCollection();
					this._StaffHourCollectionByCompanyID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("StaffHourCollectionByCompanyID", this._StaffHourCollectionByCompanyID);
				
					if (this.CompanyID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._StaffHourCollectionByCompanyID.Query.Where(this._StaffHourCollectionByCompanyID.Query.CompanyID == this.CompanyID);
							this._StaffHourCollectionByCompanyID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._StaffHourCollectionByCompanyID.fks.Add(StaffHourMetadata.ColumnNames.CompanyID, this.CompanyID);
					}
				}

				return this._StaffHourCollectionByCompanyID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._StaffHourCollectionByCompanyID != null) 
				{ 
					this.RemovePostSave("StaffHourCollectionByCompanyID"); 
					this._StaffHourCollectionByCompanyID = null;
					this.OnPropertyChanged("StaffHourCollectionByCompanyID");
				} 
			} 			
		}
			
		
		private StaffHourCollection _StaffHourCollectionByCompanyID;
		#endregion

		#region StoreCollectionByCompanyID - Zero To Many
		
		static public esPrefetchMap Prefetch_StoreCollectionByCompanyID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Company.StoreCollectionByCompanyID_Delegate;
				map.PropertyName = "StoreCollectionByCompanyID";
				map.MyColumnName = "CompanyID";
				map.ParentColumnName = "CompanyID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void StoreCollectionByCompanyID_Delegate(esPrefetchParameters data)
		{
			CompanyQuery parent = new CompanyQuery(data.NextAlias());

			StoreQuery me = data.You != null ? data.You as StoreQuery : new StoreQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CompanyID == me.CompanyID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Store_Company
		/// </summary>

		[XmlIgnore]
		public StoreCollection StoreCollectionByCompanyID
		{
			get
			{
				if(this._StoreCollectionByCompanyID == null)
				{
					this._StoreCollectionByCompanyID = new StoreCollection();
					this._StoreCollectionByCompanyID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("StoreCollectionByCompanyID", this._StoreCollectionByCompanyID);
				
					if (this.CompanyID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._StoreCollectionByCompanyID.Query.Where(this._StoreCollectionByCompanyID.Query.CompanyID == this.CompanyID);
							this._StoreCollectionByCompanyID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._StoreCollectionByCompanyID.fks.Add(StoreMetadata.ColumnNames.CompanyID, this.CompanyID);
					}
				}

				return this._StoreCollectionByCompanyID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._StoreCollectionByCompanyID != null) 
				{ 
					this.RemovePostSave("StoreCollectionByCompanyID"); 
					this._StoreCollectionByCompanyID = null;
					this.OnPropertyChanged("StoreCollectionByCompanyID");
				} 
			} 			
		}
			
		
		private StoreCollection _StoreCollectionByCompanyID;
		#endregion

		#region SupplierCollectionByCompanyID - Zero To Many
		
		static public esPrefetchMap Prefetch_SupplierCollectionByCompanyID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Company.SupplierCollectionByCompanyID_Delegate;
				map.PropertyName = "SupplierCollectionByCompanyID";
				map.MyColumnName = "CompanyID";
				map.ParentColumnName = "CompanyID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void SupplierCollectionByCompanyID_Delegate(esPrefetchParameters data)
		{
			CompanyQuery parent = new CompanyQuery(data.NextAlias());

			SupplierQuery me = data.You != null ? data.You as SupplierQuery : new SupplierQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CompanyID == me.CompanyID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Supplier_Company
		/// </summary>

		[XmlIgnore]
		public SupplierCollection SupplierCollectionByCompanyID
		{
			get
			{
				if(this._SupplierCollectionByCompanyID == null)
				{
					this._SupplierCollectionByCompanyID = new SupplierCollection();
					this._SupplierCollectionByCompanyID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("SupplierCollectionByCompanyID", this._SupplierCollectionByCompanyID);
				
					if (this.CompanyID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._SupplierCollectionByCompanyID.Query.Where(this._SupplierCollectionByCompanyID.Query.CompanyID == this.CompanyID);
							this._SupplierCollectionByCompanyID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._SupplierCollectionByCompanyID.fks.Add(SupplierMetadata.ColumnNames.CompanyID, this.CompanyID);
					}
				}

				return this._SupplierCollectionByCompanyID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._SupplierCollectionByCompanyID != null) 
				{ 
					this.RemovePostSave("SupplierCollectionByCompanyID"); 
					this._SupplierCollectionByCompanyID = null;
					this.OnPropertyChanged("SupplierCollectionByCompanyID");
				} 
			} 			
		}
			
		
		private SupplierCollection _SupplierCollectionByCompanyID;
		#endregion

		#region TransactionCollectionByCompanyID - Zero To Many
		
		static public esPrefetchMap Prefetch_TransactionCollectionByCompanyID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Company.TransactionCollectionByCompanyID_Delegate;
				map.PropertyName = "TransactionCollectionByCompanyID";
				map.MyColumnName = "CompanyID";
				map.ParentColumnName = "CompanyID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void TransactionCollectionByCompanyID_Delegate(esPrefetchParameters data)
		{
			CompanyQuery parent = new CompanyQuery(data.NextAlias());

			TransactionQuery me = data.You != null ? data.You as TransactionQuery : new TransactionQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CompanyID == me.CompanyID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Transaction_Company
		/// </summary>

		[XmlIgnore]
		public TransactionCollection TransactionCollectionByCompanyID
		{
			get
			{
				if(this._TransactionCollectionByCompanyID == null)
				{
					this._TransactionCollectionByCompanyID = new TransactionCollection();
					this._TransactionCollectionByCompanyID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("TransactionCollectionByCompanyID", this._TransactionCollectionByCompanyID);
				
					if (this.CompanyID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._TransactionCollectionByCompanyID.Query.Where(this._TransactionCollectionByCompanyID.Query.CompanyID == this.CompanyID);
							this._TransactionCollectionByCompanyID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._TransactionCollectionByCompanyID.fks.Add(TransactionMetadata.ColumnNames.CompanyID, this.CompanyID);
					}
				}

				return this._TransactionCollectionByCompanyID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._TransactionCollectionByCompanyID != null) 
				{ 
					this.RemovePostSave("TransactionCollectionByCompanyID"); 
					this._TransactionCollectionByCompanyID = null;
					this.OnPropertyChanged("TransactionCollectionByCompanyID");
				} 
			} 			
		}
			
		
		private TransactionCollection _TransactionCollectionByCompanyID;
		#endregion

		#region TransactionDetailProductCollectionByCompanyID - Zero To Many
		
		static public esPrefetchMap Prefetch_TransactionDetailProductCollectionByCompanyID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Company.TransactionDetailProductCollectionByCompanyID_Delegate;
				map.PropertyName = "TransactionDetailProductCollectionByCompanyID";
				map.MyColumnName = "CompanyID";
				map.ParentColumnName = "CompanyID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void TransactionDetailProductCollectionByCompanyID_Delegate(esPrefetchParameters data)
		{
			CompanyQuery parent = new CompanyQuery(data.NextAlias());

			TransactionDetailProductQuery me = data.You != null ? data.You as TransactionDetailProductQuery : new TransactionDetailProductQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CompanyID == me.CompanyID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_TransactionDetailProduct_Company
		/// </summary>

		[XmlIgnore]
		public TransactionDetailProductCollection TransactionDetailProductCollectionByCompanyID
		{
			get
			{
				if(this._TransactionDetailProductCollectionByCompanyID == null)
				{
					this._TransactionDetailProductCollectionByCompanyID = new TransactionDetailProductCollection();
					this._TransactionDetailProductCollectionByCompanyID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("TransactionDetailProductCollectionByCompanyID", this._TransactionDetailProductCollectionByCompanyID);
				
					if (this.CompanyID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._TransactionDetailProductCollectionByCompanyID.Query.Where(this._TransactionDetailProductCollectionByCompanyID.Query.CompanyID == this.CompanyID);
							this._TransactionDetailProductCollectionByCompanyID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._TransactionDetailProductCollectionByCompanyID.fks.Add(TransactionDetailProductMetadata.ColumnNames.CompanyID, this.CompanyID);
					}
				}

				return this._TransactionDetailProductCollectionByCompanyID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._TransactionDetailProductCollectionByCompanyID != null) 
				{ 
					this.RemovePostSave("TransactionDetailProductCollectionByCompanyID"); 
					this._TransactionDetailProductCollectionByCompanyID = null;
					this.OnPropertyChanged("TransactionDetailProductCollectionByCompanyID");
				} 
			} 			
		}
			
		
		private TransactionDetailProductCollection _TransactionDetailProductCollectionByCompanyID;
		#endregion

		#region TransactionDetailServiceCollectionByCompanyID - Zero To Many
		
		static public esPrefetchMap Prefetch_TransactionDetailServiceCollectionByCompanyID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Company.TransactionDetailServiceCollectionByCompanyID_Delegate;
				map.PropertyName = "TransactionDetailServiceCollectionByCompanyID";
				map.MyColumnName = "CompanyID";
				map.ParentColumnName = "CompanyID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void TransactionDetailServiceCollectionByCompanyID_Delegate(esPrefetchParameters data)
		{
			CompanyQuery parent = new CompanyQuery(data.NextAlias());

			TransactionDetailServiceQuery me = data.You != null ? data.You as TransactionDetailServiceQuery : new TransactionDetailServiceQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CompanyID == me.CompanyID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_TransactionDetailService_Company
		/// </summary>

		[XmlIgnore]
		public TransactionDetailServiceCollection TransactionDetailServiceCollectionByCompanyID
		{
			get
			{
				if(this._TransactionDetailServiceCollectionByCompanyID == null)
				{
					this._TransactionDetailServiceCollectionByCompanyID = new TransactionDetailServiceCollection();
					this._TransactionDetailServiceCollectionByCompanyID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("TransactionDetailServiceCollectionByCompanyID", this._TransactionDetailServiceCollectionByCompanyID);
				
					if (this.CompanyID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._TransactionDetailServiceCollectionByCompanyID.Query.Where(this._TransactionDetailServiceCollectionByCompanyID.Query.CompanyID == this.CompanyID);
							this._TransactionDetailServiceCollectionByCompanyID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._TransactionDetailServiceCollectionByCompanyID.fks.Add(TransactionDetailServiceMetadata.ColumnNames.CompanyID, this.CompanyID);
					}
				}

				return this._TransactionDetailServiceCollectionByCompanyID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._TransactionDetailServiceCollectionByCompanyID != null) 
				{ 
					this.RemovePostSave("TransactionDetailServiceCollectionByCompanyID"); 
					this._TransactionDetailServiceCollectionByCompanyID = null;
					this.OnPropertyChanged("TransactionDetailServiceCollectionByCompanyID");
				} 
			} 			
		}
			
		
		private TransactionDetailServiceCollection _TransactionDetailServiceCollectionByCompanyID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "AppointmentCollectionByCompanyID":
					coll = this.AppointmentCollectionByCompanyID;
					break;
				case "CategoryCollectionByCompanyID":
					coll = this.CategoryCollectionByCompanyID;
					break;
				case "CustomerCollectionByCompanyID":
					coll = this.CustomerCollectionByCompanyID;
					break;
				case "ProductCollectionByCompanyID":
					coll = this.ProductCollectionByCompanyID;
					break;
				case "ServiceCollectionByCompanyID":
					coll = this.ServiceCollectionByCompanyID;
					break;
				case "StaffCollectionByCompanyID":
					coll = this.StaffCollectionByCompanyID;
					break;
				case "StaffHourCollectionByCompanyID":
					coll = this.StaffHourCollectionByCompanyID;
					break;
				case "StoreCollectionByCompanyID":
					coll = this.StoreCollectionByCompanyID;
					break;
				case "SupplierCollectionByCompanyID":
					coll = this.SupplierCollectionByCompanyID;
					break;
				case "TransactionCollectionByCompanyID":
					coll = this.TransactionCollectionByCompanyID;
					break;
				case "TransactionDetailProductCollectionByCompanyID":
					coll = this.TransactionDetailProductCollectionByCompanyID;
					break;
				case "TransactionDetailServiceCollectionByCompanyID":
					coll = this.TransactionDetailServiceCollectionByCompanyID;
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
			
			props.Add(new esPropertyDescriptor(this, "AppointmentCollectionByCompanyID", typeof(AppointmentCollection), new Appointment()));
			props.Add(new esPropertyDescriptor(this, "CategoryCollectionByCompanyID", typeof(CategoryCollection), new Category()));
			props.Add(new esPropertyDescriptor(this, "CustomerCollectionByCompanyID", typeof(CustomerCollection), new Customer()));
			props.Add(new esPropertyDescriptor(this, "ProductCollectionByCompanyID", typeof(ProductCollection), new Product()));
			props.Add(new esPropertyDescriptor(this, "ServiceCollectionByCompanyID", typeof(ServiceCollection), new Service()));
			props.Add(new esPropertyDescriptor(this, "StaffCollectionByCompanyID", typeof(StaffCollection), new Staff()));
			props.Add(new esPropertyDescriptor(this, "StaffHourCollectionByCompanyID", typeof(StaffHourCollection), new StaffHour()));
			props.Add(new esPropertyDescriptor(this, "StoreCollectionByCompanyID", typeof(StoreCollection), new Store()));
			props.Add(new esPropertyDescriptor(this, "SupplierCollectionByCompanyID", typeof(SupplierCollection), new Supplier()));
			props.Add(new esPropertyDescriptor(this, "TransactionCollectionByCompanyID", typeof(TransactionCollection), new Transaction()));
			props.Add(new esPropertyDescriptor(this, "TransactionDetailProductCollectionByCompanyID", typeof(TransactionDetailProductCollection), new TransactionDetailProduct()));
			props.Add(new esPropertyDescriptor(this, "TransactionDetailServiceCollectionByCompanyID", typeof(TransactionDetailServiceCollection), new TransactionDetailService()));
		
			return props;
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
			if(this._AppointmentCollectionByCompanyID != null)
			{
				Apply(this._AppointmentCollectionByCompanyID, "CompanyID", this.CompanyID);
			}
			if(this._CategoryCollectionByCompanyID != null)
			{
				Apply(this._CategoryCollectionByCompanyID, "CompanyID", this.CompanyID);
			}
			if(this._CustomerCollectionByCompanyID != null)
			{
				Apply(this._CustomerCollectionByCompanyID, "CompanyID", this.CompanyID);
			}
			if(this._ProductCollectionByCompanyID != null)
			{
				Apply(this._ProductCollectionByCompanyID, "CompanyID", this.CompanyID);
			}
			if(this._ServiceCollectionByCompanyID != null)
			{
				Apply(this._ServiceCollectionByCompanyID, "CompanyID", this.CompanyID);
			}
			if(this._StaffCollectionByCompanyID != null)
			{
				Apply(this._StaffCollectionByCompanyID, "CompanyID", this.CompanyID);
			}
			if(this._StaffHourCollectionByCompanyID != null)
			{
				Apply(this._StaffHourCollectionByCompanyID, "CompanyID", this.CompanyID);
			}
			if(this._StoreCollectionByCompanyID != null)
			{
				Apply(this._StoreCollectionByCompanyID, "CompanyID", this.CompanyID);
			}
			if(this._SupplierCollectionByCompanyID != null)
			{
				Apply(this._SupplierCollectionByCompanyID, "CompanyID", this.CompanyID);
			}
			if(this._TransactionCollectionByCompanyID != null)
			{
				Apply(this._TransactionCollectionByCompanyID, "CompanyID", this.CompanyID);
			}
			if(this._TransactionDetailProductCollectionByCompanyID != null)
			{
				Apply(this._TransactionDetailProductCollectionByCompanyID, "CompanyID", this.CompanyID);
			}
			if(this._TransactionDetailServiceCollectionByCompanyID != null)
			{
				Apply(this._TransactionDetailServiceCollectionByCompanyID, "CompanyID", this.CompanyID);
			}
		}
		
	}
	



	[Serializable]
	public partial class CompanyMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CompanyMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(CompanyMetadata.ColumnNames.CompanyID, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = CompanyMetadata.PropertyNames.CompanyID;
			c.IsInPrimaryKey = true;
			c.HasDefault = true;
			c.Default = @"(newid())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(CompanyMetadata.ColumnNames.Name, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = CompanyMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CompanyMetadata.ColumnNames.Description, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = CompanyMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 250;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CompanyMetadata.ColumnNames.Phone, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = CompanyMetadata.PropertyNames.Phone;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CompanyMetadata.ColumnNames.Address, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = CompanyMetadata.PropertyNames.Address;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CompanyMetadata.ColumnNames.City, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = CompanyMetadata.PropertyNames.City;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CompanyMetadata.ColumnNames.PostalCode, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = CompanyMetadata.PropertyNames.PostalCode;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public CompanyMetadata Meta()
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
			 public const string CompanyID = "CompanyID";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Phone = "Phone";
			 public const string Address = "Address";
			 public const string City = "City";
			 public const string PostalCode = "PostalCode";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string CompanyID = "CompanyID";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Phone = "Phone";
			 public const string Address = "Address";
			 public const string City = "City";
			 public const string PostalCode = "PostalCode";
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
			lock (typeof(CompanyMetadata))
			{
				if(CompanyMetadata.mapDelegates == null)
				{
					CompanyMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CompanyMetadata.meta == null)
				{
					CompanyMetadata.meta = new CompanyMetadata();
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


				meta.AddTypeMap("CompanyID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Phone", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Address", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("City", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("PostalCode", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "Company";
				meta.Destination = "Company";
				
				meta.spInsert = "proc_CompanyInsert";				
				meta.spUpdate = "proc_CompanyUpdate";		
				meta.spDelete = "proc_CompanyDelete";
				meta.spLoadAll = "proc_CompanyLoadAll";
				meta.spLoadByPrimaryKey = "proc_CompanyLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private CompanyMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
