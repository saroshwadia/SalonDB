
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
	/// Encapsulates the 'Staff' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Staff))]	
	[XmlType("Staff")]
	public partial class Staff : esStaff
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Staff();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid staffID)
		{
			var obj = new Staff();
			obj.StaffID = staffID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid staffID, esSqlAccessType sqlAccessType)
		{
			var obj = new Staff();
			obj.StaffID = staffID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("StaffCollection")]
	public partial class StaffCollection : esStaffCollection, IEnumerable<Staff>
	{
		public Staff FindByPrimaryKey(System.Guid staffID)
		{
			return this.SingleOrDefault(e => e.StaffID == staffID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Staff))]
		public class StaffCollectionWCFPacket : esCollectionWCFPacket<StaffCollection>
		{
			public static implicit operator StaffCollection(StaffCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator StaffCollectionWCFPacket(StaffCollection collection)
			{
				return new StaffCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class StaffQuery : esStaffQuery
	{
		public StaffQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "StaffQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(StaffQuery query)
		{
			return StaffQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator StaffQuery(string query)
		{
			return (StaffQuery)StaffQuery.SerializeHelper.FromXml(query, typeof(StaffQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esStaff : EntityBase
	{
		public esStaff()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid staffID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(staffID);
			else
				return LoadByPrimaryKeyStoredProcedure(staffID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid staffID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(staffID);
			else
				return LoadByPrimaryKeyStoredProcedure(staffID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid staffID)
		{
			StaffQuery query = new StaffQuery();
			query.Where(query.StaffID == staffID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid staffID)
		{
			esParameters parms = new esParameters();
			parms.Add("StaffID", staffID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Staff.StaffID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? StaffID
		{
			get
			{
				return base.GetSystemGuid(StaffMetadata.ColumnNames.StaffID);
			}
			
			set
			{
				if(base.SetSystemGuid(StaffMetadata.ColumnNames.StaffID, value))
				{
					OnPropertyChanged(StaffMetadata.PropertyNames.StaffID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Staff.CompanyID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CompanyID
		{
			get
			{
				return base.GetSystemGuid(StaffMetadata.ColumnNames.CompanyID);
			}
			
			set
			{
				if(base.SetSystemGuid(StaffMetadata.ColumnNames.CompanyID, value))
				{
					this._UpToCompanyByCompanyID = null;
					this.OnPropertyChanged("UpToCompanyByCompanyID");
					OnPropertyChanged(StaffMetadata.PropertyNames.CompanyID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Staff.StoreID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? StoreID
		{
			get
			{
				return base.GetSystemGuid(StaffMetadata.ColumnNames.StoreID);
			}
			
			set
			{
				if(base.SetSystemGuid(StaffMetadata.ColumnNames.StoreID, value))
				{
					this._UpToStoreByStoreID = null;
					this.OnPropertyChanged("UpToStoreByStoreID");
					OnPropertyChanged(StaffMetadata.PropertyNames.StoreID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Staff.FirstName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String FirstName
		{
			get
			{
				return base.GetSystemString(StaffMetadata.ColumnNames.FirstName);
			}
			
			set
			{
				if(base.SetSystemString(StaffMetadata.ColumnNames.FirstName, value))
				{
					OnPropertyChanged(StaffMetadata.PropertyNames.FirstName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Staff.LastName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String LastName
		{
			get
			{
				return base.GetSystemString(StaffMetadata.ColumnNames.LastName);
			}
			
			set
			{
				if(base.SetSystemString(StaffMetadata.ColumnNames.LastName, value))
				{
					OnPropertyChanged(StaffMetadata.PropertyNames.LastName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Staff.Password
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Password
		{
			get
			{
				return base.GetSystemString(StaffMetadata.ColumnNames.Password);
			}
			
			set
			{
				if(base.SetSystemString(StaffMetadata.ColumnNames.Password, value))
				{
					OnPropertyChanged(StaffMetadata.PropertyNames.Password);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Staff.Phone
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Phone
		{
			get
			{
				return base.GetSystemString(StaffMetadata.ColumnNames.Phone);
			}
			
			set
			{
				if(base.SetSystemString(StaffMetadata.ColumnNames.Phone, value))
				{
					OnPropertyChanged(StaffMetadata.PropertyNames.Phone);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Staff.Email
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Email
		{
			get
			{
				return base.GetSystemString(StaffMetadata.ColumnNames.Email);
			}
			
			set
			{
				if(base.SetSystemString(StaffMetadata.ColumnNames.Email, value))
				{
					OnPropertyChanged(StaffMetadata.PropertyNames.Email);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Staff.Address
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Address
		{
			get
			{
				return base.GetSystemString(StaffMetadata.ColumnNames.Address);
			}
			
			set
			{
				if(base.SetSystemString(StaffMetadata.ColumnNames.Address, value))
				{
					OnPropertyChanged(StaffMetadata.PropertyNames.Address);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Staff.City
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String City
		{
			get
			{
				return base.GetSystemString(StaffMetadata.ColumnNames.City);
			}
			
			set
			{
				if(base.SetSystemString(StaffMetadata.ColumnNames.City, value))
				{
					OnPropertyChanged(StaffMetadata.PropertyNames.City);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Staff.PostalCode
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String PostalCode
		{
			get
			{
				return base.GetSystemString(StaffMetadata.ColumnNames.PostalCode);
			}
			
			set
			{
				if(base.SetSystemString(StaffMetadata.ColumnNames.PostalCode, value))
				{
					OnPropertyChanged(StaffMetadata.PropertyNames.PostalCode);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Staff.Role
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Role
		{
			get
			{
				return base.GetSystemString(StaffMetadata.ColumnNames.Role);
			}
			
			set
			{
				if(base.SetSystemString(StaffMetadata.ColumnNames.Role, value))
				{
					OnPropertyChanged(StaffMetadata.PropertyNames.Role);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Staff.Commission
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Commission
		{
			get
			{
				return base.GetSystemDecimal(StaffMetadata.ColumnNames.Commission);
			}
			
			set
			{
				if(base.SetSystemDecimal(StaffMetadata.ColumnNames.Commission, value))
				{
					OnPropertyChanged(StaffMetadata.PropertyNames.Commission);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Staff.Rate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Rate
		{
			get
			{
				return base.GetSystemDecimal(StaffMetadata.ColumnNames.Rate);
			}
			
			set
			{
				if(base.SetSystemDecimal(StaffMetadata.ColumnNames.Rate, value))
				{
					OnPropertyChanged(StaffMetadata.PropertyNames.Rate);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Staff.ResourceColor
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? ResourceColor
		{
			get
			{
				return base.GetSystemInt32(StaffMetadata.ColumnNames.ResourceColor);
			}
			
			set
			{
				if(base.SetSystemInt32(StaffMetadata.ColumnNames.ResourceColor, value))
				{
					OnPropertyChanged(StaffMetadata.PropertyNames.ResourceColor);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Company _UpToCompanyByCompanyID;
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
						case "StaffID": this.str().StaffID = (string)value; break;							
						case "CompanyID": this.str().CompanyID = (string)value; break;							
						case "StoreID": this.str().StoreID = (string)value; break;							
						case "FirstName": this.str().FirstName = (string)value; break;							
						case "LastName": this.str().LastName = (string)value; break;							
						case "Password": this.str().Password = (string)value; break;							
						case "Phone": this.str().Phone = (string)value; break;							
						case "Email": this.str().Email = (string)value; break;							
						case "Address": this.str().Address = (string)value; break;							
						case "City": this.str().City = (string)value; break;							
						case "PostalCode": this.str().PostalCode = (string)value; break;							
						case "Role": this.str().Role = (string)value; break;							
						case "Commission": this.str().Commission = (string)value; break;							
						case "Rate": this.str().Rate = (string)value; break;							
						case "ResourceColor": this.str().ResourceColor = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "StaffID":
						
							if (value == null || value is System.Guid)
								this.StaffID = (System.Guid?)value;
								OnPropertyChanged(StaffMetadata.PropertyNames.StaffID);
							break;
						
						case "CompanyID":
						
							if (value == null || value is System.Guid)
								this.CompanyID = (System.Guid?)value;
								OnPropertyChanged(StaffMetadata.PropertyNames.CompanyID);
							break;
						
						case "StoreID":
						
							if (value == null || value is System.Guid)
								this.StoreID = (System.Guid?)value;
								OnPropertyChanged(StaffMetadata.PropertyNames.StoreID);
							break;
						
						case "Commission":
						
							if (value == null || value is System.Decimal)
								this.Commission = (System.Decimal?)value;
								OnPropertyChanged(StaffMetadata.PropertyNames.Commission);
							break;
						
						case "Rate":
						
							if (value == null || value is System.Decimal)
								this.Rate = (System.Decimal?)value;
								OnPropertyChanged(StaffMetadata.PropertyNames.Rate);
							break;
						
						case "ResourceColor":
						
							if (value == null || value is System.Int32)
								this.ResourceColor = (System.Int32?)value;
								OnPropertyChanged(StaffMetadata.PropertyNames.ResourceColor);
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
			public esStrings(esStaff entity)
			{
				this.entity = entity;
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
				
			public System.String Password
			{
				get
				{
					System.String data = entity.Password;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Password = null;
					else entity.Password = Convert.ToString(value);
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
				
			public System.String Role
			{
				get
				{
					System.String data = entity.Role;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Role = null;
					else entity.Role = Convert.ToString(value);
				}
			}
				
			public System.String Commission
			{
				get
				{
					System.Decimal? data = entity.Commission;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Commission = null;
					else entity.Commission = Convert.ToDecimal(value);
				}
			}
				
			public System.String Rate
			{
				get
				{
					System.Decimal? data = entity.Rate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Rate = null;
					else entity.Rate = Convert.ToDecimal(value);
				}
			}
				
			public System.String ResourceColor
			{
				get
				{
					System.Int32? data = entity.ResourceColor;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ResourceColor = null;
					else entity.ResourceColor = Convert.ToInt32(value);
				}
			}
			

			private esStaff entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return StaffMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public StaffQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new StaffQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(StaffQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(StaffQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private StaffQuery query;		
	}



	[Serializable]
	abstract public partial class esStaffCollection : CollectionBase<Staff>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return StaffMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "StaffCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public StaffQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new StaffQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(StaffQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new StaffQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(StaffQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((StaffQuery)query);
		}

		#endregion
		
		private StaffQuery query;
	}



	[Serializable]
	abstract public partial class esStaffQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return StaffMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "StaffID": return this.StaffID;
				case "CompanyID": return this.CompanyID;
				case "StoreID": return this.StoreID;
				case "FirstName": return this.FirstName;
				case "LastName": return this.LastName;
				case "Password": return this.Password;
				case "Phone": return this.Phone;
				case "Email": return this.Email;
				case "Address": return this.Address;
				case "City": return this.City;
				case "PostalCode": return this.PostalCode;
				case "Role": return this.Role;
				case "Commission": return this.Commission;
				case "Rate": return this.Rate;
				case "ResourceColor": return this.ResourceColor;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem StaffID
		{
			get { return new esQueryItem(this, StaffMetadata.ColumnNames.StaffID, esSystemType.Guid); }
		} 
		
		public esQueryItem CompanyID
		{
			get { return new esQueryItem(this, StaffMetadata.ColumnNames.CompanyID, esSystemType.Guid); }
		} 
		
		public esQueryItem StoreID
		{
			get { return new esQueryItem(this, StaffMetadata.ColumnNames.StoreID, esSystemType.Guid); }
		} 
		
		public esQueryItem FirstName
		{
			get { return new esQueryItem(this, StaffMetadata.ColumnNames.FirstName, esSystemType.String); }
		} 
		
		public esQueryItem LastName
		{
			get { return new esQueryItem(this, StaffMetadata.ColumnNames.LastName, esSystemType.String); }
		} 
		
		public esQueryItem Password
		{
			get { return new esQueryItem(this, StaffMetadata.ColumnNames.Password, esSystemType.String); }
		} 
		
		public esQueryItem Phone
		{
			get { return new esQueryItem(this, StaffMetadata.ColumnNames.Phone, esSystemType.String); }
		} 
		
		public esQueryItem Email
		{
			get { return new esQueryItem(this, StaffMetadata.ColumnNames.Email, esSystemType.String); }
		} 
		
		public esQueryItem Address
		{
			get { return new esQueryItem(this, StaffMetadata.ColumnNames.Address, esSystemType.String); }
		} 
		
		public esQueryItem City
		{
			get { return new esQueryItem(this, StaffMetadata.ColumnNames.City, esSystemType.String); }
		} 
		
		public esQueryItem PostalCode
		{
			get { return new esQueryItem(this, StaffMetadata.ColumnNames.PostalCode, esSystemType.String); }
		} 
		
		public esQueryItem Role
		{
			get { return new esQueryItem(this, StaffMetadata.ColumnNames.Role, esSystemType.String); }
		} 
		
		public esQueryItem Commission
		{
			get { return new esQueryItem(this, StaffMetadata.ColumnNames.Commission, esSystemType.Decimal); }
		} 
		
		public esQueryItem Rate
		{
			get { return new esQueryItem(this, StaffMetadata.ColumnNames.Rate, esSystemType.Decimal); }
		} 
		
		public esQueryItem ResourceColor
		{
			get { return new esQueryItem(this, StaffMetadata.ColumnNames.ResourceColor, esSystemType.Int32); }
		} 
		
		#endregion
		
	}


	
	public partial class Staff : esStaff
	{

		#region AppointmentCollectionByStaffID - Zero To Many
		
		static public esPrefetchMap Prefetch_AppointmentCollectionByStaffID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Staff.AppointmentCollectionByStaffID_Delegate;
				map.PropertyName = "AppointmentCollectionByStaffID";
				map.MyColumnName = "StaffID";
				map.ParentColumnName = "StaffID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void AppointmentCollectionByStaffID_Delegate(esPrefetchParameters data)
		{
			StaffQuery parent = new StaffQuery(data.NextAlias());

			AppointmentQuery me = data.You != null ? data.You as AppointmentQuery : new AppointmentQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.StaffID == me.StaffID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Appointment_Staff
		/// </summary>

		[XmlIgnore]
		public AppointmentCollection AppointmentCollectionByStaffID
		{
			get
			{
				if(this._AppointmentCollectionByStaffID == null)
				{
					this._AppointmentCollectionByStaffID = new AppointmentCollection();
					this._AppointmentCollectionByStaffID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("AppointmentCollectionByStaffID", this._AppointmentCollectionByStaffID);
				
					if (this.StaffID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._AppointmentCollectionByStaffID.Query.Where(this._AppointmentCollectionByStaffID.Query.StaffID == this.StaffID);
							this._AppointmentCollectionByStaffID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._AppointmentCollectionByStaffID.fks.Add(AppointmentMetadata.ColumnNames.StaffID, this.StaffID);
					}
				}

				return this._AppointmentCollectionByStaffID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._AppointmentCollectionByStaffID != null) 
				{ 
					this.RemovePostSave("AppointmentCollectionByStaffID"); 
					this._AppointmentCollectionByStaffID = null;
					this.OnPropertyChanged("AppointmentCollectionByStaffID");
				} 
			} 			
		}
			
		
		private AppointmentCollection _AppointmentCollectionByStaffID;
		#endregion

		#region StaffHourCollectionByStaffID - Zero To Many
		
		static public esPrefetchMap Prefetch_StaffHourCollectionByStaffID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Staff.StaffHourCollectionByStaffID_Delegate;
				map.PropertyName = "StaffHourCollectionByStaffID";
				map.MyColumnName = "StaffID";
				map.ParentColumnName = "StaffID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void StaffHourCollectionByStaffID_Delegate(esPrefetchParameters data)
		{
			StaffQuery parent = new StaffQuery(data.NextAlias());

			StaffHourQuery me = data.You != null ? data.You as StaffHourQuery : new StaffHourQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.StaffID == me.StaffID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_StaffHour_Staff
		/// </summary>

		[XmlIgnore]
		public StaffHourCollection StaffHourCollectionByStaffID
		{
			get
			{
				if(this._StaffHourCollectionByStaffID == null)
				{
					this._StaffHourCollectionByStaffID = new StaffHourCollection();
					this._StaffHourCollectionByStaffID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("StaffHourCollectionByStaffID", this._StaffHourCollectionByStaffID);
				
					if (this.StaffID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._StaffHourCollectionByStaffID.Query.Where(this._StaffHourCollectionByStaffID.Query.StaffID == this.StaffID);
							this._StaffHourCollectionByStaffID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._StaffHourCollectionByStaffID.fks.Add(StaffHourMetadata.ColumnNames.StaffID, this.StaffID);
					}
				}

				return this._StaffHourCollectionByStaffID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._StaffHourCollectionByStaffID != null) 
				{ 
					this.RemovePostSave("StaffHourCollectionByStaffID"); 
					this._StaffHourCollectionByStaffID = null;
					this.OnPropertyChanged("StaffHourCollectionByStaffID");
				} 
			} 			
		}
			
		
		private StaffHourCollection _StaffHourCollectionByStaffID;
		#endregion

				
		#region UpToCompanyByCompanyID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Staff_Company
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
		

				
		#region UpToStoreByStoreID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Staff_Store
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
				case "AppointmentCollectionByStaffID":
					coll = this.AppointmentCollectionByStaffID;
					break;
				case "StaffHourCollectionByStaffID":
					coll = this.StaffHourCollectionByStaffID;
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
			
			props.Add(new esPropertyDescriptor(this, "AppointmentCollectionByStaffID", typeof(AppointmentCollection), new Appointment()));
			props.Add(new esPropertyDescriptor(this, "StaffHourCollectionByStaffID", typeof(StaffHourCollection), new StaffHour()));
		
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
			if(this._AppointmentCollectionByStaffID != null)
			{
				Apply(this._AppointmentCollectionByStaffID, "StaffID", this.StaffID);
			}
			if(this._StaffHourCollectionByStaffID != null)
			{
				Apply(this._StaffHourCollectionByStaffID, "StaffID", this.StaffID);
			}
		}
		
	}
	



	[Serializable]
	public partial class StaffMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected StaffMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(StaffMetadata.ColumnNames.StaffID, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = StaffMetadata.PropertyNames.StaffID;
			c.IsInPrimaryKey = true;
			c.HasDefault = true;
			c.Default = @"(newid())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffMetadata.ColumnNames.CompanyID, 1, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = StaffMetadata.PropertyNames.CompanyID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffMetadata.ColumnNames.StoreID, 2, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = StaffMetadata.PropertyNames.StoreID;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffMetadata.ColumnNames.FirstName, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = StaffMetadata.PropertyNames.FirstName;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffMetadata.ColumnNames.LastName, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = StaffMetadata.PropertyNames.LastName;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffMetadata.ColumnNames.Password, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = StaffMetadata.PropertyNames.Password;
			c.CharacterMaxLength = 250;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffMetadata.ColumnNames.Phone, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = StaffMetadata.PropertyNames.Phone;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffMetadata.ColumnNames.Email, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = StaffMetadata.PropertyNames.Email;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffMetadata.ColumnNames.Address, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = StaffMetadata.PropertyNames.Address;
			c.CharacterMaxLength = 500;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffMetadata.ColumnNames.City, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = StaffMetadata.PropertyNames.City;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffMetadata.ColumnNames.PostalCode, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = StaffMetadata.PropertyNames.PostalCode;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffMetadata.ColumnNames.Role, 11, typeof(System.String), esSystemType.String);
			c.PropertyName = StaffMetadata.PropertyNames.Role;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffMetadata.ColumnNames.Commission, 12, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = StaffMetadata.PropertyNames.Commission;
			c.NumericPrecision = 18;
			c.NumericScale = 4;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffMetadata.ColumnNames.Rate, 13, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = StaffMetadata.PropertyNames.Rate;
			c.NumericPrecision = 18;
			c.NumericScale = 4;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(StaffMetadata.ColumnNames.ResourceColor, 14, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = StaffMetadata.PropertyNames.ResourceColor;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public StaffMetadata Meta()
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
			 public const string StaffID = "StaffID";
			 public const string CompanyID = "CompanyID";
			 public const string StoreID = "StoreID";
			 public const string FirstName = "FirstName";
			 public const string LastName = "LastName";
			 public const string Password = "Password";
			 public const string Phone = "Phone";
			 public const string Email = "Email";
			 public const string Address = "Address";
			 public const string City = "City";
			 public const string PostalCode = "PostalCode";
			 public const string Role = "Role";
			 public const string Commission = "Commission";
			 public const string Rate = "Rate";
			 public const string ResourceColor = "ResourceColor";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string StaffID = "StaffID";
			 public const string CompanyID = "CompanyID";
			 public const string StoreID = "StoreID";
			 public const string FirstName = "FirstName";
			 public const string LastName = "LastName";
			 public const string Password = "Password";
			 public const string Phone = "Phone";
			 public const string Email = "Email";
			 public const string Address = "Address";
			 public const string City = "City";
			 public const string PostalCode = "PostalCode";
			 public const string Role = "Role";
			 public const string Commission = "Commission";
			 public const string Rate = "Rate";
			 public const string ResourceColor = "ResourceColor";
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
			lock (typeof(StaffMetadata))
			{
				if(StaffMetadata.mapDelegates == null)
				{
					StaffMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (StaffMetadata.meta == null)
				{
					StaffMetadata.meta = new StaffMetadata();
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


				meta.AddTypeMap("StaffID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("CompanyID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("StoreID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("FirstName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("LastName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Password", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Phone", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Email", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Address", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("City", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("PostalCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Role", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Commission", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("Rate", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("ResourceColor", new esTypeMap("int", "System.Int32"));			
				
				
				
				meta.Source = "Staff";
				meta.Destination = "Staff";
				
				meta.spInsert = "proc_StaffInsert";				
				meta.spUpdate = "proc_StaffUpdate";		
				meta.spDelete = "proc_StaffDelete";
				meta.spLoadAll = "proc_StaffLoadAll";
				meta.spLoadByPrimaryKey = "proc_StaffLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private StaffMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
