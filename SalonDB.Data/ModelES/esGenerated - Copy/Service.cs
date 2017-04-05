
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
	/// Encapsulates the 'Service' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Service))]	
	[XmlType("Service")]
	public partial class Service : esService
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Service();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid serviceID)
		{
			var obj = new Service();
			obj.ServiceID = serviceID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid serviceID, esSqlAccessType sqlAccessType)
		{
			var obj = new Service();
			obj.ServiceID = serviceID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("ServiceCollection")]
	public partial class ServiceCollection : esServiceCollection, IEnumerable<Service>
	{
		public Service FindByPrimaryKey(System.Guid serviceID)
		{
			return this.SingleOrDefault(e => e.ServiceID == serviceID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Service))]
		public class ServiceCollectionWCFPacket : esCollectionWCFPacket<ServiceCollection>
		{
			public static implicit operator ServiceCollection(ServiceCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator ServiceCollectionWCFPacket(ServiceCollection collection)
			{
				return new ServiceCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class ServiceQuery : esServiceQuery
	{
		public ServiceQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "ServiceQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(ServiceQuery query)
		{
			return ServiceQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ServiceQuery(string query)
		{
			return (ServiceQuery)ServiceQuery.SerializeHelper.FromXml(query, typeof(ServiceQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esService : EntityBase
	{
		public esService()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid serviceID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(serviceID);
			else
				return LoadByPrimaryKeyStoredProcedure(serviceID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid serviceID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(serviceID);
			else
				return LoadByPrimaryKeyStoredProcedure(serviceID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid serviceID)
		{
			ServiceQuery query = new ServiceQuery();
			query.Where(query.ServiceID == serviceID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid serviceID)
		{
			esParameters parms = new esParameters();
			parms.Add("ServiceID", serviceID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Service.ServiceID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? ServiceID
		{
			get
			{
				return base.GetSystemGuid(ServiceMetadata.ColumnNames.ServiceID);
			}
			
			set
			{
				if(base.SetSystemGuid(ServiceMetadata.ColumnNames.ServiceID, value))
				{
					OnPropertyChanged(ServiceMetadata.PropertyNames.ServiceID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Service.CompanyID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CompanyID
		{
			get
			{
				return base.GetSystemGuid(ServiceMetadata.ColumnNames.CompanyID);
			}
			
			set
			{
				if(base.SetSystemGuid(ServiceMetadata.ColumnNames.CompanyID, value))
				{
					this._UpToCompanyByCompanyID = null;
					this.OnPropertyChanged("UpToCompanyByCompanyID");
					OnPropertyChanged(ServiceMetadata.PropertyNames.CompanyID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Service.CategoryID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CategoryID
		{
			get
			{
				return base.GetSystemGuid(ServiceMetadata.ColumnNames.CategoryID);
			}
			
			set
			{
				if(base.SetSystemGuid(ServiceMetadata.ColumnNames.CategoryID, value))
				{
					this._UpToCategoryByCategoryID = null;
					this.OnPropertyChanged("UpToCategoryByCategoryID");
					OnPropertyChanged(ServiceMetadata.PropertyNames.CategoryID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Service.Name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(ServiceMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(ServiceMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(ServiceMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Service.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(ServiceMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(ServiceMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(ServiceMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Service.Price
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Price
		{
			get
			{
				return base.GetSystemDecimal(ServiceMetadata.ColumnNames.Price);
			}
			
			set
			{
				if(base.SetSystemDecimal(ServiceMetadata.ColumnNames.Price, value))
				{
					OnPropertyChanged(ServiceMetadata.PropertyNames.Price);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Service.Duration
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Duration
		{
			get
			{
				return base.GetSystemInt32(ServiceMetadata.ColumnNames.Duration);
			}
			
			set
			{
				if(base.SetSystemInt32(ServiceMetadata.ColumnNames.Duration, value))
				{
					OnPropertyChanged(ServiceMetadata.PropertyNames.Duration);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Service.ShowOnline
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Boolean? ShowOnline
		{
			get
			{
				return base.GetSystemBoolean(ServiceMetadata.ColumnNames.ShowOnline);
			}
			
			set
			{
				if(base.SetSystemBoolean(ServiceMetadata.ColumnNames.ShowOnline, value))
				{
					OnPropertyChanged(ServiceMetadata.PropertyNames.ShowOnline);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Category _UpToCategoryByCategoryID;
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
						case "ServiceID": this.str().ServiceID = (string)value; break;							
						case "CompanyID": this.str().CompanyID = (string)value; break;							
						case "CategoryID": this.str().CategoryID = (string)value; break;							
						case "Name": this.str().Name = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;							
						case "Price": this.str().Price = (string)value; break;							
						case "Duration": this.str().Duration = (string)value; break;							
						case "ShowOnline": this.str().ShowOnline = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "ServiceID":
						
							if (value == null || value is System.Guid)
								this.ServiceID = (System.Guid?)value;
								OnPropertyChanged(ServiceMetadata.PropertyNames.ServiceID);
							break;
						
						case "CompanyID":
						
							if (value == null || value is System.Guid)
								this.CompanyID = (System.Guid?)value;
								OnPropertyChanged(ServiceMetadata.PropertyNames.CompanyID);
							break;
						
						case "CategoryID":
						
							if (value == null || value is System.Guid)
								this.CategoryID = (System.Guid?)value;
								OnPropertyChanged(ServiceMetadata.PropertyNames.CategoryID);
							break;
						
						case "Price":
						
							if (value == null || value is System.Decimal)
								this.Price = (System.Decimal?)value;
								OnPropertyChanged(ServiceMetadata.PropertyNames.Price);
							break;
						
						case "Duration":
						
							if (value == null || value is System.Int32)
								this.Duration = (System.Int32?)value;
								OnPropertyChanged(ServiceMetadata.PropertyNames.Duration);
							break;
						
						case "ShowOnline":
						
							if (value == null || value is System.Boolean)
								this.ShowOnline = (System.Boolean?)value;
								OnPropertyChanged(ServiceMetadata.PropertyNames.ShowOnline);
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
			public esStrings(esService entity)
			{
				this.entity = entity;
			}
			
	
			public System.String ServiceID
			{
				get
				{
					System.Guid? data = entity.ServiceID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ServiceID = null;
					else entity.ServiceID = new Guid(value);
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
				
			public System.String CategoryID
			{
				get
				{
					System.Guid? data = entity.CategoryID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CategoryID = null;
					else entity.CategoryID = new Guid(value);
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
				
			public System.String Price
			{
				get
				{
					System.Decimal? data = entity.Price;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Price = null;
					else entity.Price = Convert.ToDecimal(value);
				}
			}
				
			public System.String Duration
			{
				get
				{
					System.Int32? data = entity.Duration;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Duration = null;
					else entity.Duration = Convert.ToInt32(value);
				}
			}
				
			public System.String ShowOnline
			{
				get
				{
					System.Boolean? data = entity.ShowOnline;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ShowOnline = null;
					else entity.ShowOnline = Convert.ToBoolean(value);
				}
			}
			

			private esService entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return ServiceMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public ServiceQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ServiceQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ServiceQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(ServiceQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private ServiceQuery query;		
	}



	[Serializable]
	abstract public partial class esServiceCollection : CollectionBase<Service>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ServiceMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "ServiceCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public ServiceQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ServiceQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ServiceQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ServiceQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(ServiceQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((ServiceQuery)query);
		}

		#endregion
		
		private ServiceQuery query;
	}



	[Serializable]
	abstract public partial class esServiceQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return ServiceMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "ServiceID": return this.ServiceID;
				case "CompanyID": return this.CompanyID;
				case "CategoryID": return this.CategoryID;
				case "Name": return this.Name;
				case "Description": return this.Description;
				case "Price": return this.Price;
				case "Duration": return this.Duration;
				case "ShowOnline": return this.ShowOnline;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem ServiceID
		{
			get { return new esQueryItem(this, ServiceMetadata.ColumnNames.ServiceID, esSystemType.Guid); }
		} 
		
		public esQueryItem CompanyID
		{
			get { return new esQueryItem(this, ServiceMetadata.ColumnNames.CompanyID, esSystemType.Guid); }
		} 
		
		public esQueryItem CategoryID
		{
			get { return new esQueryItem(this, ServiceMetadata.ColumnNames.CategoryID, esSystemType.Guid); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, ServiceMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, ServiceMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem Price
		{
			get { return new esQueryItem(this, ServiceMetadata.ColumnNames.Price, esSystemType.Decimal); }
		} 
		
		public esQueryItem Duration
		{
			get { return new esQueryItem(this, ServiceMetadata.ColumnNames.Duration, esSystemType.Int32); }
		} 
		
		public esQueryItem ShowOnline
		{
			get { return new esQueryItem(this, ServiceMetadata.ColumnNames.ShowOnline, esSystemType.Boolean); }
		} 
		
		#endregion
		
	}


	
	public partial class Service : esService
	{

		#region TransactionDetailServiceCollectionByServiceID - Zero To Many
		
		static public esPrefetchMap Prefetch_TransactionDetailServiceCollectionByServiceID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Service.TransactionDetailServiceCollectionByServiceID_Delegate;
				map.PropertyName = "TransactionDetailServiceCollectionByServiceID";
				map.MyColumnName = "ServiceID";
				map.ParentColumnName = "ServiceID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void TransactionDetailServiceCollectionByServiceID_Delegate(esPrefetchParameters data)
		{
			ServiceQuery parent = new ServiceQuery(data.NextAlias());

			TransactionDetailServiceQuery me = data.You != null ? data.You as TransactionDetailServiceQuery : new TransactionDetailServiceQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.ServiceID == me.ServiceID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_TransactionDetailService_Service
		/// </summary>

		[XmlIgnore]
		public TransactionDetailServiceCollection TransactionDetailServiceCollectionByServiceID
		{
			get
			{
				if(this._TransactionDetailServiceCollectionByServiceID == null)
				{
					this._TransactionDetailServiceCollectionByServiceID = new TransactionDetailServiceCollection();
					this._TransactionDetailServiceCollectionByServiceID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("TransactionDetailServiceCollectionByServiceID", this._TransactionDetailServiceCollectionByServiceID);
				
					if (this.ServiceID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._TransactionDetailServiceCollectionByServiceID.Query.Where(this._TransactionDetailServiceCollectionByServiceID.Query.ServiceID == this.ServiceID);
							this._TransactionDetailServiceCollectionByServiceID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._TransactionDetailServiceCollectionByServiceID.fks.Add(TransactionDetailServiceMetadata.ColumnNames.ServiceID, this.ServiceID);
					}
				}

				return this._TransactionDetailServiceCollectionByServiceID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._TransactionDetailServiceCollectionByServiceID != null) 
				{ 
					this.RemovePostSave("TransactionDetailServiceCollectionByServiceID"); 
					this._TransactionDetailServiceCollectionByServiceID = null;
					this.OnPropertyChanged("TransactionDetailServiceCollectionByServiceID");
				} 
			} 			
		}
			
		
		private TransactionDetailServiceCollection _TransactionDetailServiceCollectionByServiceID;
		#endregion

				
		#region UpToCategoryByCategoryID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Service_Category
		/// </summary>

		[XmlIgnore]
					
		public Category UpToCategoryByCategoryID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToCategoryByCategoryID == null && CategoryID != null)
				{
					this._UpToCategoryByCategoryID = new Category();
					this._UpToCategoryByCategoryID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToCategoryByCategoryID", this._UpToCategoryByCategoryID);
					this._UpToCategoryByCategoryID.Query.Where(this._UpToCategoryByCategoryID.Query.CategoryID == this.CategoryID);
					this._UpToCategoryByCategoryID.Query.Load();
				}	
				return this._UpToCategoryByCategoryID;
			}
			
			set
			{
				this.RemovePreSave("UpToCategoryByCategoryID");
				
				bool changed = this._UpToCategoryByCategoryID != value;

				if(value == null)
				{
					this.CategoryID = null;
					this._UpToCategoryByCategoryID = null;
				}
				else
				{
					this.CategoryID = value.CategoryID;
					this._UpToCategoryByCategoryID = value;
					this.SetPreSave("UpToCategoryByCategoryID", this._UpToCategoryByCategoryID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToCategoryByCategoryID");
				}
			}
		}
		#endregion
		

				
		#region UpToCompanyByCompanyID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Service_Company
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
				case "TransactionDetailServiceCollectionByServiceID":
					coll = this.TransactionDetailServiceCollectionByServiceID;
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
			
			props.Add(new esPropertyDescriptor(this, "TransactionDetailServiceCollectionByServiceID", typeof(TransactionDetailServiceCollection), new TransactionDetailService()));
		
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToCategoryByCategoryID != null)
			{
				this.CategoryID = this._UpToCategoryByCategoryID.CategoryID;
			}
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
			if(this._TransactionDetailServiceCollectionByServiceID != null)
			{
				Apply(this._TransactionDetailServiceCollectionByServiceID, "ServiceID", this.ServiceID);
			}
		}
		
	}
	



	[Serializable]
	public partial class ServiceMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ServiceMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ServiceMetadata.ColumnNames.ServiceID, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = ServiceMetadata.PropertyNames.ServiceID;
			c.IsInPrimaryKey = true;
			c.HasDefault = true;
			c.Default = @"(newid())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(ServiceMetadata.ColumnNames.CompanyID, 1, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = ServiceMetadata.PropertyNames.CompanyID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ServiceMetadata.ColumnNames.CategoryID, 2, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = ServiceMetadata.PropertyNames.CategoryID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ServiceMetadata.ColumnNames.Name, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = ServiceMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ServiceMetadata.ColumnNames.Description, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = ServiceMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 250;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ServiceMetadata.ColumnNames.Price, 5, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = ServiceMetadata.PropertyNames.Price;
			c.NumericPrecision = 18;
			c.NumericScale = 4;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(ServiceMetadata.ColumnNames.Duration, 6, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ServiceMetadata.PropertyNames.Duration;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(ServiceMetadata.ColumnNames.ShowOnline, 7, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = ServiceMetadata.PropertyNames.ShowOnline;
			c.HasDefault = true;
			c.Default = @"('False')";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public ServiceMetadata Meta()
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
			 public const string ServiceID = "ServiceID";
			 public const string CompanyID = "CompanyID";
			 public const string CategoryID = "CategoryID";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Price = "Price";
			 public const string Duration = "Duration";
			 public const string ShowOnline = "ShowOnline";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string ServiceID = "ServiceID";
			 public const string CompanyID = "CompanyID";
			 public const string CategoryID = "CategoryID";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Price = "Price";
			 public const string Duration = "Duration";
			 public const string ShowOnline = "ShowOnline";
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
			lock (typeof(ServiceMetadata))
			{
				if(ServiceMetadata.mapDelegates == null)
				{
					ServiceMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ServiceMetadata.meta == null)
				{
					ServiceMetadata.meta = new ServiceMetadata();
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


				meta.AddTypeMap("ServiceID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("CompanyID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("CategoryID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Price", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("Duration", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ShowOnline", new esTypeMap("bit", "System.Boolean"));			
				
				
				
				meta.Source = "Service";
				meta.Destination = "Service";
				
				meta.spInsert = "proc_ServiceInsert";				
				meta.spUpdate = "proc_ServiceUpdate";		
				meta.spDelete = "proc_ServiceDelete";
				meta.spLoadAll = "proc_ServiceLoadAll";
				meta.spLoadByPrimaryKey = "proc_ServiceLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ServiceMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
