
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 2017-02-20 7:11:17 PM
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
	/// Encapsulates the 'StaffHour' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(StaffHour))]	
	[XmlType("StaffHour")]
	public partial class StaffHour : esStaffHour
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new StaffHour();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid staffHourID)
		{
			var obj = new StaffHour();
			obj.StaffHourID = staffHourID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid staffHourID, esSqlAccessType sqlAccessType)
		{
			var obj = new StaffHour();
			obj.StaffHourID = staffHourID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("StaffHourCollection")]
	public partial class StaffHourCollection : esStaffHourCollection, IEnumerable<StaffHour>
	{
		public StaffHour FindByPrimaryKey(System.Guid staffHourID)
		{
			return this.SingleOrDefault(e => e.StaffHourID == staffHourID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(StaffHour))]
		public class StaffHourCollectionWCFPacket : esCollectionWCFPacket<StaffHourCollection>
		{
			public static implicit operator StaffHourCollection(StaffHourCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator StaffHourCollectionWCFPacket(StaffHourCollection collection)
			{
				return new StaffHourCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class StaffHourQuery : esStaffHourQuery
	{
		public StaffHourQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "StaffHourQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(StaffHourQuery query)
		{
			return StaffHourQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator StaffHourQuery(string query)
		{
			return (StaffHourQuery)StaffHourQuery.SerializeHelper.FromXml(query, typeof(StaffHourQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esStaffHour : EntityBase
	{
		public esStaffHour()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid staffHourID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(staffHourID);
			else
				return LoadByPrimaryKeyStoredProcedure(staffHourID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid staffHourID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(staffHourID);
			else
				return LoadByPrimaryKeyStoredProcedure(staffHourID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid staffHourID)
		{
			StaffHourQuery query = new StaffHourQuery();
			query.Where(query.StaffHourID == staffHourID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid staffHourID)
		{
			esParameters parms = new esParameters();
			parms.Add("StaffHourID", staffHourID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to StaffHour.StaffHourID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? StaffHourID
		{
			get
			{
				return base.GetSystemGuid(StaffHourMetadata.ColumnNames.StaffHourID);
			}
			
			set
			{
				if(base.SetSystemGuid(StaffHourMetadata.ColumnNames.StaffHourID, value))
				{
					OnPropertyChanged(StaffHourMetadata.PropertyNames.StaffHourID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to StaffHour.CompanyID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CompanyID
		{
			get
			{
				return base.GetSystemGuid(StaffHourMetadata.ColumnNames.CompanyID);
			}
			
			set
			{
				if(base.SetSystemGuid(StaffHourMetadata.ColumnNames.CompanyID, value))
				{
					this._UpToCompanyByCompanyID = null;
					this.OnPropertyChanged("UpToCompanyByCompanyID");
					OnPropertyChanged(StaffHourMetadata.PropertyNames.CompanyID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to StaffHour.StaffID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? StaffID
		{
			get
			{
				return base.GetSystemGuid(StaffHourMetadata.ColumnNames.StaffID);
			}
			
			set
			{
				if(base.SetSystemGuid(StaffHourMetadata.ColumnNames.StaffID, value))
				{
					this._UpToStaffByStaffID = null;
					this.OnPropertyChanged("UpToStaffByStaffID");
					OnPropertyChanged(StaffHourMetadata.PropertyNames.StaffID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to StaffHour.StoreID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? StoreID
		{
			get
			{
				return base.GetSystemGuid(StaffHourMetadata.ColumnNames.StoreID);
			}
			
			set
			{
				if(base.SetSystemGuid(StaffHourMetadata.ColumnNames.StoreID, value))
				{
					this._UpToStoreByStoreID = null;
					this.OnPropertyChanged("UpToStoreByStoreID");
					OnPropertyChanged(StaffHourMetadata.PropertyNames.StoreID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to StaffHour.StartTime
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? StartTime
		{
			get
			{
				return base.GetSystemDateTime(StaffHourMetadata.ColumnNames.StartTime);
			}
			
			set
			{
				if(base.SetSystemDateTime(StaffHourMetadata.ColumnNames.StartTime, value))
				{
					OnPropertyChanged(StaffHourMetadata.PropertyNames.StartTime);
				}
			}
		}		
		
		/// <summary>
		/// Maps to StaffHour.EndTime
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? EndTime
		{
			get
			{
				return base.GetSystemDateTime(StaffHourMetadata.ColumnNames.EndTime);
			}
			
			set
			{
				if(base.SetSystemDateTime(StaffHourMetadata.ColumnNames.EndTime, value))
				{
					OnPropertyChanged(StaffHourMetadata.PropertyNames.EndTime);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected StaffHour _UpToStaffHourByStaffHourID;
		[CLSCompliant(false)]
		internal protected Company _UpToCompanyByCompanyID;
		[CLSCompliant(false)]
		internal protected Staff _UpToStaffByStaffID;
		[CLSCompliant(false)]
		internal protected Store _UpToStoreByStoreID;
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
						case "StaffHourID": this.str().StaffHourID = (string)value; break;							
						case "CompanyID": this.str().CompanyID = (string)value; break;							
						case "StaffID": this.str().StaffID = (string)value; break;							
						case "StoreID": this.str().StoreID = (string)value; break;							
						case "StartTime": this.str().StartTime = (string)value; break;							
						case "EndTime": this.str().EndTime = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "StaffHourID":
						
							if (value == null || value is System.Guid)
								this.StaffHourID = (System.Guid?)value;
								OnPropertyChanged(StaffHourMetadata.PropertyNames.StaffHourID);
							break;
						
						case "CompanyID":
						
							if (value == null || value is System.Guid)
								this.CompanyID = (System.Guid?)value;
								OnPropertyChanged(StaffHourMetadata.PropertyNames.CompanyID);
							break;
						
						case "StaffID":
						
							if (value == null || value is System.Guid)
								this.StaffID = (System.Guid?)value;
								OnPropertyChanged(StaffHourMetadata.PropertyNames.StaffID);
							break;
						
						case "StoreID":
						
							if (value == null || value is System.Guid)
								this.StoreID = (System.Guid?)value;
								OnPropertyChanged(StaffHourMetadata.PropertyNames.StoreID);
							break;
						
						case "StartTime":
						
							if (value == null || value is System.DateTime)
								this.StartTime = (System.DateTime?)value;
								OnPropertyChanged(StaffHourMetadata.PropertyNames.StartTime);
							break;
						
						case "EndTime":
						
							if (value == null || value is System.DateTime)
								this.EndTime = (System.DateTime?)value;
								OnPropertyChanged(StaffHourMetadata.PropertyNames.EndTime);
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
			public esStrings(esStaffHour entity)
			{
				this.entity = entity;
			}
			
	
			public System.String StaffHourID
			{
				get
				{
					System.Guid? data = entity.StaffHourID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.StaffHourID = null;
					else entity.StaffHourID = new Guid(value);
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
				
			public System.String StaffID
			{
				get
				{
					System.Guid? data = entity.StaffID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.StaffID = null;
					else entity.StaffID = new Guid(value);
				}
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
				
			public System.String StartTime
			{
				get
				{
					System.DateTime? data = entity.StartTime;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.StartTime = null;
					else entity.StartTime = Convert.ToDateTime(value);
				}
			}
				
			public System.String EndTime
			{
				get
				{
					System.DateTime? data = entity.EndTime;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.EndTime = null;
					else entity.EndTime = Convert.ToDateTime(value);
				}
			}
			

			private esStaffHour entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return StaffHourMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public StaffHourQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new StaffHourQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(StaffHourQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(StaffHourQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private StaffHourQuery query;		
	}



	[Serializable]
	abstract public partial class esStaffHourCollection : CollectionBase<StaffHour>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return StaffHourMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "StaffHourCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public StaffHourQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new StaffHourQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(StaffHourQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new StaffHourQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(StaffHourQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((StaffHourQuery)query);
		}

		#endregion
		
		private StaffHourQuery query;
	}



	[Serializable]
	abstract public partial class esStaffHourQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return StaffHourMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "StaffHourID": return this.StaffHourID;
				case "CompanyID": return this.CompanyID;
				case "StaffID": return this.StaffID;
				case "StoreID": return this.StoreID;
				case "StartTime": return this.StartTime;
				case "EndTime": return this.EndTime;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem StaffHourID
		{
			get { return new esQueryItem(this, StaffHourMetadata.ColumnNames.StaffHourID, esSystemType.Guid); }
		} 
		
		public esQueryItem CompanyID
		{
			get { return new esQueryItem(this, StaffHourMetadata.ColumnNames.CompanyID, esSystemType.Guid); }
		} 
		
		public esQueryItem StaffID
		{
			get { return new esQueryItem(this, StaffHourMetadata.ColumnNames.StaffID, esSystemType.Guid); }
		} 
		
		public esQueryItem StoreID
		{
			get { return new esQueryItem(this, StaffHourMetadata.ColumnNames.StoreID, esSystemType.Guid); }
		} 
		
		public esQueryItem StartTime
		{
			get { return new esQueryItem(this, StaffHourMetadata.ColumnNames.StartTime, esSystemType.DateTime); }
		} 
		
		public esQueryItem EndTime
		{
			get { return new esQueryItem(this, StaffHourMetadata.ColumnNames.EndTime, esSystemType.DateTime); }
		} 
		
		#endregion
		
	}


	
	public partial class StaffHour : esStaffHour
	{

		#region StaffHourCollectionByStaffHourID - Zero To Many
		
		static public esPrefetchMap Prefetch_StaffHourCollectionByStaffHourID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.StaffHour.StaffHourCollectionByStaffHourID_Delegate;
				map.PropertyName = "StaffHourCollectionByStaffHourID";
				map.MyColumnName = "StaffHourID";
				map.ParentColumnName = "StaffHourID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void StaffHourCollectionByStaffHourID_Delegate(esPrefetchParameters data)
		{
			StaffHourQuery parent = new StaffHourQuery(data.NextAlias());

			StaffHourQuery me = data.You != null ? data.You as StaffHourQuery : new StaffHourQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.StaffHourID == me.StaffHourID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_StaffHour_StaffHour
		/// </summary>

		[XmlIgnore]
		public StaffHourCollection StaffHourCollectionByStaffHourID
		{
			get
			{
				if(this._StaffHourCollectionByStaffHourID == null)
				{
					this._StaffHourCollectionByStaffHourID = new StaffHourCollection();
					this._StaffHourCollectionByStaffHourID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("StaffHourCollectionByStaffHourID", this._StaffHourCollectionByStaffHourID);
				
					if (this.StaffHourID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._StaffHourCollectionByStaffHourID.Query.Where(this._StaffHourCollectionByStaffHourID.Query.StaffHourID == this.StaffHourID);
							this._StaffHourCollectionByStaffHourID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._StaffHourCollectionByStaffHourID.fks.Add(StaffHourMetadata.ColumnNames.StaffHourID, this.StaffHourID);
					}
				}

				return this._StaffHourCollectionByStaffHourID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._StaffHourCollectionByStaffHourID != null) 
				{ 
					this.RemovePostSave("StaffHourCollectionByStaffHourID"); 
					this._StaffHourCollectionByStaffHourID = null;
					this.OnPropertyChanged("StaffHourCollectionByStaffHourID");
				} 
			} 			
		}
			
		
		private StaffHourCollection _StaffHourCollectionByStaffHourID;
		#endregion

				
		#region UpToStaffHourByStaffHourID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_StaffHour_StaffHour
		/// </summary>

		[XmlIgnore]
					
		public StaffHour UpToStaffHourByStaffHourID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToStaffHourByStaffHourID == null && StaffHourID != null)
				{
					this._UpToStaffHourByStaffHourID = new StaffHour();
					this._UpToStaffHourByStaffHourID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToStaffHourByStaffHourID", this._UpToStaffHourByStaffHourID);
					this._UpToStaffHourByStaffHourID.Query.Where(this._UpToStaffHourByStaffHourID.Query.StaffHourID == this.StaffHourID);
					this._UpToStaffHourByStaffHourID.Query.Load();
				}	
				return this._UpToStaffHourByStaffHourID;
			}
			
			set
			{
				this.RemovePreSave("UpToStaffHourByStaffHourID");
				
				bool changed = this._UpToStaffHourByStaffHourID != value;

				if(value == null)
				{
					this.StaffHourID = null;
					this._UpToStaffHourByStaffHourID = null;
				}
				else
				{
					this.StaffHourID = value.StaffHourID;
					this._UpToStaffHourByStaffHourID = value;
					this.SetPreSave("UpToStaffHourByStaffHourID", this._UpToStaffHourByStaffHourID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToStaffHourByStaffHourID");
				}
			}
		}
		#endregion
		

				
		#region UpToCompanyByCompanyID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_StaffHour_Company
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
		

				
		#region UpToStaffByStaffID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_StaffHour_Staff
		/// </summary>

		[XmlIgnore]
					
		public Staff UpToStaffByStaffID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToStaffByStaffID == null && StaffID != null)
				{
					this._UpToStaffByStaffID = new Staff();
					this._UpToStaffByStaffID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToStaffByStaffID", this._UpToStaffByStaffID);
					this._UpToStaffByStaffID.Query.Where(this._UpToStaffByStaffID.Query.StaffID == this.StaffID);
					this._UpToStaffByStaffID.Query.Load();
				}	
				return this._UpToStaffByStaffID;
			}
			
			set
			{
				this.RemovePreSave("UpToStaffByStaffID");
				
				bool changed = this._UpToStaffByStaffID != value;

				if(value == null)
				{
					this.StaffID = null;
					this._UpToStaffByStaffID = null;
				}
				else
				{
					this.StaffID = value.StaffID;
					this._UpToStaffByStaffID = value;
					this.SetPreSave("UpToStaffByStaffID", this._UpToStaffByStaffID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToStaffByStaffID");
				}
			}
		}
		#endregion
		

				
		#region UpToStoreByStoreID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_StaffHour_Store
		/// </summary>

		[XmlIgnore]
					
		public Store UpToStoreByStoreID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToStoreByStoreID == null && StoreID != null)
				{
					this._UpToStoreByStoreID = new Store();
					this._UpToStoreByStoreID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToStoreByStoreID", this._UpToStoreByStoreID);
					this._UpToStoreByStoreID.Query.Where(this._UpToStoreByStoreID.Query.StoreID == this.StoreID);
					this._UpToStoreByStoreID.Query.Load();
				}	
				return this._UpToStoreByStoreID;
			}
			
			set
			{
				this.RemovePreSave("UpToStoreByStoreID");
				
				bool changed = this._UpToStoreByStoreID != value;

				if(value == null)
				{
					this.StoreID = null;
					this._UpToStoreByStoreID = null;
				}
				else
				{
					this.StoreID = value.StoreID;
					this._UpToStoreByStoreID = value;
					this.SetPreSave("UpToStoreByStoreID", this._UpToStoreByStoreID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToStoreByStoreID");
				}
			}
		}
		#endregion
		

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "StaffHourCollectionByStaffHourID":
					coll = this.StaffHourCollectionByStaffHourID;
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
			
			props.Add(new esPropertyDescriptor(this, "StaffHourCollectionByStaffHourID", typeof(StaffHourCollection), new StaffHour()));
		
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToStaffHourByStaffHourID != null)
			{
				this.StaffHourID = this._UpToStaffHourByStaffHourID.StaffHourID;
			}
			if(!this.es.IsDeleted && this._UpToCompanyByCompanyID != null)
			{
				this.CompanyID = this._UpToCompanyByCompanyID.CompanyID;
			}
			if(!this.es.IsDeleted && this._UpToStaffByStaffID != null)
			{
				this.StaffID = this._UpToStaffByStaffID.StaffID;
			}
			if(!this.es.IsDeleted && this._UpToStoreByStoreID != null)
			{
				this.StoreID = this._UpToStoreByStoreID.StoreID;
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
			if(this._StaffHourCollectionByStaffHourID != null)
			{
				Apply(this._StaffHourCollectionByStaffHourID, "StaffHourID", this.StaffHourID);
			}
		}
		
	}
	



	[Serializable]
	public partial class StaffHourMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected StaffHourMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(StaffHourMetadata.ColumnNames.StaffHourID, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = StaffHourMetadata.PropertyNames.StaffHourID;
			c.IsInPrimaryKey = true;
			c.HasDefault = true;
			c.Default = @"(newid())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffHourMetadata.ColumnNames.CompanyID, 1, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = StaffHourMetadata.PropertyNames.CompanyID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffHourMetadata.ColumnNames.StaffID, 2, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = StaffHourMetadata.PropertyNames.StaffID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffHourMetadata.ColumnNames.StoreID, 3, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = StaffHourMetadata.PropertyNames.StoreID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffHourMetadata.ColumnNames.StartTime, 4, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = StaffHourMetadata.PropertyNames.StartTime;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffHourMetadata.ColumnNames.EndTime, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = StaffHourMetadata.PropertyNames.EndTime;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public StaffHourMetadata Meta()
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
			 public const string StaffHourID = "StaffHourID";
			 public const string CompanyID = "CompanyID";
			 public const string StaffID = "StaffID";
			 public const string StoreID = "StoreID";
			 public const string StartTime = "StartTime";
			 public const string EndTime = "EndTime";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string StaffHourID = "StaffHourID";
			 public const string CompanyID = "CompanyID";
			 public const string StaffID = "StaffID";
			 public const string StoreID = "StoreID";
			 public const string StartTime = "StartTime";
			 public const string EndTime = "EndTime";
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
			lock (typeof(StaffHourMetadata))
			{
				if(StaffHourMetadata.mapDelegates == null)
				{
					StaffHourMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (StaffHourMetadata.meta == null)
				{
					StaffHourMetadata.meta = new StaffHourMetadata();
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


				meta.AddTypeMap("StaffHourID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("CompanyID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("StaffID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("StoreID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("StartTime", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("EndTime", new esTypeMap("datetime", "System.DateTime"));			
				
				
				
				meta.Source = "StaffHour";
				meta.Destination = "StaffHour";
				
				meta.spInsert = "proc_StaffHourInsert";				
				meta.spUpdate = "proc_StaffHourUpdate";		
				meta.spDelete = "proc_StaffHourDelete";
				meta.spLoadAll = "proc_StaffHourLoadAll";
				meta.spLoadByPrimaryKey = "proc_StaffHourLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private StaffHourMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
