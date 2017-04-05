
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
	/// Encapsulates the 'Supplier' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Supplier))]	
	[XmlType("Supplier")]
	public partial class Supplier : esSupplier
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Supplier();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid supplierID)
		{
			var obj = new Supplier();
			obj.SupplierID = supplierID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid supplierID, esSqlAccessType sqlAccessType)
		{
			var obj = new Supplier();
			obj.SupplierID = supplierID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("SupplierCollection")]
	public partial class SupplierCollection : esSupplierCollection, IEnumerable<Supplier>
	{
		public Supplier FindByPrimaryKey(System.Guid supplierID)
		{
			return this.SingleOrDefault(e => e.SupplierID == supplierID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Supplier))]
		public class SupplierCollectionWCFPacket : esCollectionWCFPacket<SupplierCollection>
		{
			public static implicit operator SupplierCollection(SupplierCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator SupplierCollectionWCFPacket(SupplierCollection collection)
			{
				return new SupplierCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class SupplierQuery : esSupplierQuery
	{
		public SupplierQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "SupplierQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(SupplierQuery query)
		{
			return SupplierQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator SupplierQuery(string query)
		{
			return (SupplierQuery)SupplierQuery.SerializeHelper.FromXml(query, typeof(SupplierQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esSupplier : EntityBase
	{
		public esSupplier()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid supplierID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(supplierID);
			else
				return LoadByPrimaryKeyStoredProcedure(supplierID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid supplierID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(supplierID);
			else
				return LoadByPrimaryKeyStoredProcedure(supplierID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid supplierID)
		{
			SupplierQuery query = new SupplierQuery();
			query.Where(query.SupplierID == supplierID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid supplierID)
		{
			esParameters parms = new esParameters();
			parms.Add("SupplierID", supplierID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Supplier.SupplierID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? SupplierID
		{
			get
			{
				return base.GetSystemGuid(SupplierMetadata.ColumnNames.SupplierID);
			}
			
			set
			{
				if(base.SetSystemGuid(SupplierMetadata.ColumnNames.SupplierID, value))
				{
					OnPropertyChanged(SupplierMetadata.PropertyNames.SupplierID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Supplier.CompanyID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CompanyID
		{
			get
			{
				return base.GetSystemGuid(SupplierMetadata.ColumnNames.CompanyID);
			}
			
			set
			{
				if(base.SetSystemGuid(SupplierMetadata.ColumnNames.CompanyID, value))
				{
					this._UpToCompanyByCompanyID = null;
					this.OnPropertyChanged("UpToCompanyByCompanyID");
					OnPropertyChanged(SupplierMetadata.PropertyNames.CompanyID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Supplier.Name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(SupplierMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(SupplierMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(SupplierMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Supplier.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(SupplierMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(SupplierMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(SupplierMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Supplier.Phone
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Phone
		{
			get
			{
				return base.GetSystemString(SupplierMetadata.ColumnNames.Phone);
			}
			
			set
			{
				if(base.SetSystemString(SupplierMetadata.ColumnNames.Phone, value))
				{
					OnPropertyChanged(SupplierMetadata.PropertyNames.Phone);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Supplier.Address
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Address
		{
			get
			{
				return base.GetSystemString(SupplierMetadata.ColumnNames.Address);
			}
			
			set
			{
				if(base.SetSystemString(SupplierMetadata.ColumnNames.Address, value))
				{
					OnPropertyChanged(SupplierMetadata.PropertyNames.Address);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Supplier.City
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String City
		{
			get
			{
				return base.GetSystemString(SupplierMetadata.ColumnNames.City);
			}
			
			set
			{
				if(base.SetSystemString(SupplierMetadata.ColumnNames.City, value))
				{
					OnPropertyChanged(SupplierMetadata.PropertyNames.City);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Supplier.PostalCode
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String PostalCode
		{
			get
			{
				return base.GetSystemString(SupplierMetadata.ColumnNames.PostalCode);
			}
			
			set
			{
				if(base.SetSystemString(SupplierMetadata.ColumnNames.PostalCode, value))
				{
					OnPropertyChanged(SupplierMetadata.PropertyNames.PostalCode);
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
						case "SupplierID": this.str().SupplierID = (string)value; break;							
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
						case "SupplierID":
						
							if (value == null || value is System.Guid)
								this.SupplierID = (System.Guid?)value;
								OnPropertyChanged(SupplierMetadata.PropertyNames.SupplierID);
							break;
						
						case "CompanyID":
						
							if (value == null || value is System.Guid)
								this.CompanyID = (System.Guid?)value;
								OnPropertyChanged(SupplierMetadata.PropertyNames.CompanyID);
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
			public esStrings(esSupplier entity)
			{
				this.entity = entity;
			}
			
	
			public System.String SupplierID
			{
				get
				{
					System.Guid? data = entity.SupplierID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.SupplierID = null;
					else entity.SupplierID = new Guid(value);
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
			

			private esSupplier entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return SupplierMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public SupplierQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SupplierQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SupplierQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(SupplierQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private SupplierQuery query;		
	}



	[Serializable]
	abstract public partial class esSupplierCollection : CollectionBase<Supplier>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return SupplierMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "SupplierCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public SupplierQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SupplierQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SupplierQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new SupplierQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(SupplierQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((SupplierQuery)query);
		}

		#endregion
		
		private SupplierQuery query;
	}



	[Serializable]
	abstract public partial class esSupplierQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return SupplierMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "SupplierID": return this.SupplierID;
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

		public esQueryItem SupplierID
		{
			get { return new esQueryItem(this, SupplierMetadata.ColumnNames.SupplierID, esSystemType.Guid); }
		} 
		
		public esQueryItem CompanyID
		{
			get { return new esQueryItem(this, SupplierMetadata.ColumnNames.CompanyID, esSystemType.Guid); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, SupplierMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, SupplierMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem Phone
		{
			get { return new esQueryItem(this, SupplierMetadata.ColumnNames.Phone, esSystemType.String); }
		} 
		
		public esQueryItem Address
		{
			get { return new esQueryItem(this, SupplierMetadata.ColumnNames.Address, esSystemType.String); }
		} 
		
		public esQueryItem City
		{
			get { return new esQueryItem(this, SupplierMetadata.ColumnNames.City, esSystemType.String); }
		} 
		
		public esQueryItem PostalCode
		{
			get { return new esQueryItem(this, SupplierMetadata.ColumnNames.PostalCode, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Supplier : esSupplier
	{

		#region ProductCollectionBySupplierID - Zero To Many
		
		static public esPrefetchMap Prefetch_ProductCollectionBySupplierID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Supplier.ProductCollectionBySupplierID_Delegate;
				map.PropertyName = "ProductCollectionBySupplierID";
				map.MyColumnName = "SupplierID";
				map.ParentColumnName = "SupplierID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void ProductCollectionBySupplierID_Delegate(esPrefetchParameters data)
		{
			SupplierQuery parent = new SupplierQuery(data.NextAlias());

			ProductQuery me = data.You != null ? data.You as ProductQuery : new ProductQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.SupplierID == me.SupplierID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Product_Supplier
		/// </summary>

		[XmlIgnore]
		public ProductCollection ProductCollectionBySupplierID
		{
			get
			{
				if(this._ProductCollectionBySupplierID == null)
				{
					this._ProductCollectionBySupplierID = new ProductCollection();
					this._ProductCollectionBySupplierID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("ProductCollectionBySupplierID", this._ProductCollectionBySupplierID);
				
					if (this.SupplierID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._ProductCollectionBySupplierID.Query.Where(this._ProductCollectionBySupplierID.Query.SupplierID == this.SupplierID);
							this._ProductCollectionBySupplierID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._ProductCollectionBySupplierID.fks.Add(ProductMetadata.ColumnNames.SupplierID, this.SupplierID);
					}
				}

				return this._ProductCollectionBySupplierID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._ProductCollectionBySupplierID != null) 
				{ 
					this.RemovePostSave("ProductCollectionBySupplierID"); 
					this._ProductCollectionBySupplierID = null;
					this.OnPropertyChanged("ProductCollectionBySupplierID");
				} 
			} 			
		}
			
		
		private ProductCollection _ProductCollectionBySupplierID;
		#endregion

				
		#region UpToCompanyByCompanyID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Supplier_Company
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
				case "ProductCollectionBySupplierID":
					coll = this.ProductCollectionBySupplierID;
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
			
			props.Add(new esPropertyDescriptor(this, "ProductCollectionBySupplierID", typeof(ProductCollection), new Product()));
		
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
			if(this._ProductCollectionBySupplierID != null)
			{
				Apply(this._ProductCollectionBySupplierID, "SupplierID", this.SupplierID);
			}
		}
		
	}
	



	[Serializable]
	public partial class SupplierMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected SupplierMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(SupplierMetadata.ColumnNames.SupplierID, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = SupplierMetadata.PropertyNames.SupplierID;
			c.IsInPrimaryKey = true;
			c.HasDefault = true;
			c.Default = @"(newid())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(SupplierMetadata.ColumnNames.CompanyID, 1, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = SupplierMetadata.PropertyNames.CompanyID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SupplierMetadata.ColumnNames.Name, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = SupplierMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SupplierMetadata.ColumnNames.Description, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = SupplierMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 250;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SupplierMetadata.ColumnNames.Phone, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = SupplierMetadata.PropertyNames.Phone;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SupplierMetadata.ColumnNames.Address, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = SupplierMetadata.PropertyNames.Address;
			c.CharacterMaxLength = 500;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SupplierMetadata.ColumnNames.City, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = SupplierMetadata.PropertyNames.City;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SupplierMetadata.ColumnNames.PostalCode, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = SupplierMetadata.PropertyNames.PostalCode;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public SupplierMetadata Meta()
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
			 public const string SupplierID = "SupplierID";
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
			 public const string SupplierID = "SupplierID";
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
			lock (typeof(SupplierMetadata))
			{
				if(SupplierMetadata.mapDelegates == null)
				{
					SupplierMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (SupplierMetadata.meta == null)
				{
					SupplierMetadata.meta = new SupplierMetadata();
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


				meta.AddTypeMap("SupplierID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("CompanyID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Phone", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Address", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("City", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("PostalCode", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "Supplier";
				meta.Destination = "Supplier";
				
				meta.spInsert = "proc_SupplierInsert";				
				meta.spUpdate = "proc_SupplierUpdate";		
				meta.spDelete = "proc_SupplierDelete";
				meta.spLoadAll = "proc_SupplierLoadAll";
				meta.spLoadByPrimaryKey = "proc_SupplierLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private SupplierMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
