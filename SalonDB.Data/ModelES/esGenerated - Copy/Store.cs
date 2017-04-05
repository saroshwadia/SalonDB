
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 2016-12-23 2:58:24 PM
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
	/// Encapsulates the 'Store' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Store))]	
	[XmlType("Store")]
	public partial class Store : esStore
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Store();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid storeID)
		{
			var obj = new Store();
			obj.StoreID = storeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid storeID, esSqlAccessType sqlAccessType)
		{
			var obj = new Store();
			obj.StoreID = storeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("StoreCollection")]
	public partial class StoreCollection : esStoreCollection, IEnumerable<Store>
	{
		public Store FindByPrimaryKey(System.Guid storeID)
		{
			return this.SingleOrDefault(e => e.StoreID == storeID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Store))]
		public class StoreCollectionWCFPacket : esCollectionWCFPacket<StoreCollection>
		{
			public static implicit operator StoreCollection(StoreCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator StoreCollectionWCFPacket(StoreCollection collection)
			{
				return new StoreCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class StoreQuery : esStoreQuery
	{
		public StoreQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "StoreQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(StoreQuery query)
		{
			return StoreQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator StoreQuery(string query)
		{
			return (StoreQuery)StoreQuery.SerializeHelper.FromXml(query, typeof(StoreQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esStore : EntityBase
	{
		public esStore()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid storeID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(storeID);
			else
				return LoadByPrimaryKeyStoredProcedure(storeID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid storeID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(storeID);
			else
				return LoadByPrimaryKeyStoredProcedure(storeID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid storeID)
		{
			StoreQuery query = new StoreQuery();
			query.Where(query.StoreID == storeID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid storeID)
		{
			esParameters parms = new esParameters();
			parms.Add("StoreID", storeID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Store.StoreID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? StoreID
		{
			get
			{
				return base.GetSystemGuid(StoreMetadata.ColumnNames.StoreID);
			}
			
			set
			{
				if(base.SetSystemGuid(StoreMetadata.ColumnNames.StoreID, value))
				{
					OnPropertyChanged(StoreMetadata.PropertyNames.StoreID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Store.CompanyID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CompanyID
		{
			get
			{
				return base.GetSystemGuid(StoreMetadata.ColumnNames.CompanyID);
			}
			
			set
			{
				if(base.SetSystemGuid(StoreMetadata.ColumnNames.CompanyID, value))
				{
					this._UpToCompanyByCompanyID = null;
					this.OnPropertyChanged("UpToCompanyByCompanyID");
					OnPropertyChanged(StoreMetadata.PropertyNames.CompanyID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Store.Name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(StoreMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(StoreMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(StoreMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Store.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(StoreMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(StoreMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(StoreMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Store.Phone
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Phone
		{
			get
			{
				return base.GetSystemString(StoreMetadata.ColumnNames.Phone);
			}
			
			set
			{
				if(base.SetSystemString(StoreMetadata.ColumnNames.Phone, value))
				{
					OnPropertyChanged(StoreMetadata.PropertyNames.Phone);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Store.Address
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Address
		{
			get
			{
				return base.GetSystemString(StoreMetadata.ColumnNames.Address);
			}
			
			set
			{
				if(base.SetSystemString(StoreMetadata.ColumnNames.Address, value))
				{
					OnPropertyChanged(StoreMetadata.PropertyNames.Address);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Store.City
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String City
		{
			get
			{
				return base.GetSystemString(StoreMetadata.ColumnNames.City);
			}
			
			set
			{
				if(base.SetSystemString(StoreMetadata.ColumnNames.City, value))
				{
					OnPropertyChanged(StoreMetadata.PropertyNames.City);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Store.PostalCode
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String PostalCode
		{
			get
			{
				return base.GetSystemString(StoreMetadata.ColumnNames.PostalCode);
			}
			
			set
			{
				if(base.SetSystemString(StoreMetadata.ColumnNames.PostalCode, value))
				{
					OnPropertyChanged(StoreMetadata.PropertyNames.PostalCode);
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
						case "StoreID": this.str().StoreID = (string)value; break;							
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
						case "StoreID":
						
							if (value == null || value is System.Guid)
								this.StoreID = (System.Guid?)value;
								OnPropertyChanged(StoreMetadata.PropertyNames.StoreID);
							break;
						
						case "CompanyID":
						
							if (value == null || value is System.Guid)
								this.CompanyID = (System.Guid?)value;
								OnPropertyChanged(StoreMetadata.PropertyNames.CompanyID);
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
			public esStrings(esStore entity)
			{
				this.entity = entity;
			}
			
	
			public System.String StoreID
			{
				get
				{
					System.Guid? data = entity.StoreID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.StoreID = null;
					else entity.StoreID = new Guid(value);
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
			

			private esStore entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return StoreMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public StoreQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new StoreQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(StoreQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(StoreQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private StoreQuery query;		
	}



	[Serializable]
	abstract public partial class esStoreCollection : CollectionBase<Store>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return StoreMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "StoreCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public StoreQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new StoreQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(StoreQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new StoreQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(StoreQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((StoreQuery)query);
		}

		#endregion
		
		private StoreQuery query;
	}



	[Serializable]
	abstract public partial class esStoreQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return StoreMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "StoreID": return this.StoreID;
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

		public esQueryItem StoreID
		{
			get { return new esQueryItem(this, StoreMetadata.ColumnNames.StoreID, esSystemType.Guid); }
		} 
		
		public esQueryItem CompanyID
		{
			get { return new esQueryItem(this, StoreMetadata.ColumnNames.CompanyID, esSystemType.Guid); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, StoreMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, StoreMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem Phone
		{
			get { return new esQueryItem(this, StoreMetadata.ColumnNames.Phone, esSystemType.String); }
		} 
		
		public esQueryItem Address
		{
			get { return new esQueryItem(this, StoreMetadata.ColumnNames.Address, esSystemType.String); }
		} 
		
		public esQueryItem City
		{
			get { return new esQueryItem(this, StoreMetadata.ColumnNames.City, esSystemType.String); }
		} 
		
		public esQueryItem PostalCode
		{
			get { return new esQueryItem(this, StoreMetadata.ColumnNames.PostalCode, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Store : esStore
	{

		#region AppointmentCollectionByStoreID - Zero To Many
		
		static public esPrefetchMap Prefetch_AppointmentCollectionByStoreID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Store.AppointmentCollectionByStoreID_Delegate;
				map.PropertyName = "AppointmentCollectionByStoreID";
				map.MyColumnName = "StoreID";
				map.ParentColumnName = "StoreID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void AppointmentCollectionByStoreID_Delegate(esPrefetchParameters data)
		{
			StoreQuery parent = new StoreQuery(data.NextAlias());

			AppointmentQuery me = data.You != null ? data.You as AppointmentQuery : new AppointmentQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.StoreID == me.StoreID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Appointment_Store
		/// </summary>

		[XmlIgnore]
		public AppointmentCollection AppointmentCollectionByStoreID
		{
			get
			{
				if(this._AppointmentCollectionByStoreID == null)
				{
					this._AppointmentCollectionByStoreID = new AppointmentCollection();
					this._AppointmentCollectionByStoreID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("AppointmentCollectionByStoreID", this._AppointmentCollectionByStoreID);
				
					if (this.StoreID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._AppointmentCollectionByStoreID.Query.Where(this._AppointmentCollectionByStoreID.Query.StoreID == this.StoreID);
							this._AppointmentCollectionByStoreID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._AppointmentCollectionByStoreID.fks.Add(AppointmentMetadata.ColumnNames.StoreID, this.StoreID);
					}
				}

				return this._AppointmentCollectionByStoreID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._AppointmentCollectionByStoreID != null) 
				{ 
					this.RemovePostSave("AppointmentCollectionByStoreID"); 
					this._AppointmentCollectionByStoreID = null;
					this.OnPropertyChanged("AppointmentCollectionByStoreID");
				} 
			} 			
		}
			
		
		private AppointmentCollection _AppointmentCollectionByStoreID;
		#endregion

		#region StaffCollectionByStoreID - Zero To Many
		
		static public esPrefetchMap Prefetch_StaffCollectionByStoreID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Store.StaffCollectionByStoreID_Delegate;
				map.PropertyName = "StaffCollectionByStoreID";
				map.MyColumnName = "StoreID";
				map.ParentColumnName = "StoreID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void StaffCollectionByStoreID_Delegate(esPrefetchParameters data)
		{
			StoreQuery parent = new StoreQuery(data.NextAlias());

			StaffQuery me = data.You != null ? data.You as StaffQuery : new StaffQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.StoreID == me.StoreID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Staff_Store
		/// </summary>

		[XmlIgnore]
		public StaffCollection StaffCollectionByStoreID
		{
			get
			{
				if(this._StaffCollectionByStoreID == null)
				{
					this._StaffCollectionByStoreID = new StaffCollection();
					this._StaffCollectionByStoreID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("StaffCollectionByStoreID", this._StaffCollectionByStoreID);
				
					if (this.StoreID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._StaffCollectionByStoreID.Query.Where(this._StaffCollectionByStoreID.Query.StoreID == this.StoreID);
							this._StaffCollectionByStoreID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._StaffCollectionByStoreID.fks.Add(StaffMetadata.ColumnNames.StoreID, this.StoreID);
					}
				}

				return this._StaffCollectionByStoreID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._StaffCollectionByStoreID != null) 
				{ 
					this.RemovePostSave("StaffCollectionByStoreID"); 
					this._StaffCollectionByStoreID = null;
					this.OnPropertyChanged("StaffCollectionByStoreID");
				} 
			} 			
		}
			
		
		private StaffCollection _StaffCollectionByStoreID;
		#endregion

		#region StaffHourCollectionByStoreID - Zero To Many
		
		static public esPrefetchMap Prefetch_StaffHourCollectionByStoreID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Store.StaffHourCollectionByStoreID_Delegate;
				map.PropertyName = "StaffHourCollectionByStoreID";
				map.MyColumnName = "StoreID";
				map.ParentColumnName = "StoreID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void StaffHourCollectionByStoreID_Delegate(esPrefetchParameters data)
		{
			StoreQuery parent = new StoreQuery(data.NextAlias());

			StaffHourQuery me = data.You != null ? data.You as StaffHourQuery : new StaffHourQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.StoreID == me.StoreID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_StaffHour_Store
		/// </summary>

		[XmlIgnore]
		public StaffHourCollection StaffHourCollectionByStoreID
		{
			get
			{
				if(this._StaffHourCollectionByStoreID == null)
				{
					this._StaffHourCollectionByStoreID = new StaffHourCollection();
					this._StaffHourCollectionByStoreID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("StaffHourCollectionByStoreID", this._StaffHourCollectionByStoreID);
				
					if (this.StoreID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._StaffHourCollectionByStoreID.Query.Where(this._StaffHourCollectionByStoreID.Query.StoreID == this.StoreID);
							this._StaffHourCollectionByStoreID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._StaffHourCollectionByStoreID.fks.Add(StaffHourMetadata.ColumnNames.StoreID, this.StoreID);
					}
				}

				return this._StaffHourCollectionByStoreID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._StaffHourCollectionByStoreID != null) 
				{ 
					this.RemovePostSave("StaffHourCollectionByStoreID"); 
					this._StaffHourCollectionByStoreID = null;
					this.OnPropertyChanged("StaffHourCollectionByStoreID");
				} 
			} 			
		}
			
		
		private StaffHourCollection _StaffHourCollectionByStoreID;
		#endregion

				
		#region UpToCompanyByCompanyID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Store_Company
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
				case "AppointmentCollectionByStoreID":
					coll = this.AppointmentCollectionByStoreID;
					break;
				case "StaffCollectionByStoreID":
					coll = this.StaffCollectionByStoreID;
					break;
				case "StaffHourCollectionByStoreID":
					coll = this.StaffHourCollectionByStoreID;
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
			
			props.Add(new esPropertyDescriptor(this, "AppointmentCollectionByStoreID", typeof(AppointmentCollection), new Appointment()));
			props.Add(new esPropertyDescriptor(this, "StaffCollectionByStoreID", typeof(StaffCollection), new Staff()));
			props.Add(new esPropertyDescriptor(this, "StaffHourCollectionByStoreID", typeof(StaffHourCollection), new StaffHour()));
		
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
			if(this._AppointmentCollectionByStoreID != null)
			{
				Apply(this._AppointmentCollectionByStoreID, "StoreID", this.StoreID);
			}
			if(this._StaffCollectionByStoreID != null)
			{
				Apply(this._StaffCollectionByStoreID, "StoreID", this.StoreID);
			}
			if(this._StaffHourCollectionByStoreID != null)
			{
				Apply(this._StaffHourCollectionByStoreID, "StoreID", this.StoreID);
			}
		}
		
	}
	



	[Serializable]
	public partial class StoreMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected StoreMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(StoreMetadata.ColumnNames.StoreID, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = StoreMetadata.PropertyNames.StoreID;
			c.IsInPrimaryKey = true;
			c.HasDefault = true;
			c.Default = @"(newid())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(StoreMetadata.ColumnNames.CompanyID, 1, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = StoreMetadata.PropertyNames.CompanyID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StoreMetadata.ColumnNames.Name, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = StoreMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StoreMetadata.ColumnNames.Description, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = StoreMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 250;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StoreMetadata.ColumnNames.Phone, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = StoreMetadata.PropertyNames.Phone;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StoreMetadata.ColumnNames.Address, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = StoreMetadata.PropertyNames.Address;
			c.CharacterMaxLength = 500;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StoreMetadata.ColumnNames.City, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = StoreMetadata.PropertyNames.City;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StoreMetadata.ColumnNames.PostalCode, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = StoreMetadata.PropertyNames.PostalCode;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public StoreMetadata Meta()
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
			 public const string StoreID = "StoreID";
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
			 public const string StoreID = "StoreID";
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
			lock (typeof(StoreMetadata))
			{
				if(StoreMetadata.mapDelegates == null)
				{
					StoreMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (StoreMetadata.meta == null)
				{
					StoreMetadata.meta = new StoreMetadata();
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


				meta.AddTypeMap("StoreID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("CompanyID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Phone", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Address", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("City", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("PostalCode", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "Store";
				meta.Destination = "Store";
				
				meta.spInsert = "proc_StoreInsert";				
				meta.spUpdate = "proc_StoreUpdate";		
				meta.spDelete = "proc_StoreDelete";
				meta.spLoadAll = "proc_StoreLoadAll";
				meta.spLoadByPrimaryKey = "proc_StoreLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private StoreMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
