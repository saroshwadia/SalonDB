
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
	/// Encapsulates the 'Category' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Category))]	
	[XmlType("Category")]
	public partial class Category : esCategory
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Category();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid categoryID)
		{
			var obj = new Category();
			obj.CategoryID = categoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid categoryID, esSqlAccessType sqlAccessType)
		{
			var obj = new Category();
			obj.CategoryID = categoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("CategoryCollection")]
	public partial class CategoryCollection : esCategoryCollection, IEnumerable<Category>
	{
		public Category FindByPrimaryKey(System.Guid categoryID)
		{
			return this.SingleOrDefault(e => e.CategoryID == categoryID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Category))]
		public class CategoryCollectionWCFPacket : esCollectionWCFPacket<CategoryCollection>
		{
			public static implicit operator CategoryCollection(CategoryCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator CategoryCollectionWCFPacket(CategoryCollection collection)
			{
				return new CategoryCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class CategoryQuery : esCategoryQuery
	{
		public CategoryQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "CategoryQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CategoryQuery query)
		{
			return CategoryQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CategoryQuery(string query)
		{
			return (CategoryQuery)CategoryQuery.SerializeHelper.FromXml(query, typeof(CategoryQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esCategory : EntityBase
	{
		public esCategory()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid categoryID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(categoryID);
			else
				return LoadByPrimaryKeyStoredProcedure(categoryID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid categoryID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(categoryID);
			else
				return LoadByPrimaryKeyStoredProcedure(categoryID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid categoryID)
		{
			CategoryQuery query = new CategoryQuery();
			query.Where(query.CategoryID == categoryID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid categoryID)
		{
			esParameters parms = new esParameters();
			parms.Add("CategoryID", categoryID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Category.CategoryID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CategoryID
		{
			get
			{
				return base.GetSystemGuid(CategoryMetadata.ColumnNames.CategoryID);
			}
			
			set
			{
				if(base.SetSystemGuid(CategoryMetadata.ColumnNames.CategoryID, value))
				{
					OnPropertyChanged(CategoryMetadata.PropertyNames.CategoryID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Category.CompanyID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CompanyID
		{
			get
			{
				return base.GetSystemGuid(CategoryMetadata.ColumnNames.CompanyID);
			}
			
			set
			{
				if(base.SetSystemGuid(CategoryMetadata.ColumnNames.CompanyID, value))
				{
					this._UpToCompanyByCompanyID = null;
					this.OnPropertyChanged("UpToCompanyByCompanyID");
					OnPropertyChanged(CategoryMetadata.PropertyNames.CompanyID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Category.Name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(CategoryMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(CategoryMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(CategoryMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Category.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(CategoryMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(CategoryMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(CategoryMetadata.PropertyNames.Description);
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
						case "CategoryID": this.str().CategoryID = (string)value; break;							
						case "CompanyID": this.str().CompanyID = (string)value; break;							
						case "Name": this.str().Name = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "CategoryID":
						
							if (value == null || value is System.Guid)
								this.CategoryID = (System.Guid?)value;
								OnPropertyChanged(CategoryMetadata.PropertyNames.CategoryID);
							break;
						
						case "CompanyID":
						
							if (value == null || value is System.Guid)
								this.CompanyID = (System.Guid?)value;
								OnPropertyChanged(CategoryMetadata.PropertyNames.CompanyID);
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
			public esStrings(esCategory entity)
			{
				this.entity = entity;
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
			

			private esCategory entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return CategoryMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public CategoryQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CategoryQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CategoryQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(CategoryQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private CategoryQuery query;		
	}



	[Serializable]
	abstract public partial class esCategoryCollection : CollectionBase<Category>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return CategoryMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "CategoryCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public CategoryQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CategoryQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CategoryQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new CategoryQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(CategoryQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((CategoryQuery)query);
		}

		#endregion
		
		private CategoryQuery query;
	}



	[Serializable]
	abstract public partial class esCategoryQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return CategoryMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "CategoryID": return this.CategoryID;
				case "CompanyID": return this.CompanyID;
				case "Name": return this.Name;
				case "Description": return this.Description;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem CategoryID
		{
			get { return new esQueryItem(this, CategoryMetadata.ColumnNames.CategoryID, esSystemType.Guid); }
		} 
		
		public esQueryItem CompanyID
		{
			get { return new esQueryItem(this, CategoryMetadata.ColumnNames.CompanyID, esSystemType.Guid); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, CategoryMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, CategoryMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Category : esCategory
	{

		#region ProductCollectionByCategoryID - Zero To Many
		
		static public esPrefetchMap Prefetch_ProductCollectionByCategoryID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Category.ProductCollectionByCategoryID_Delegate;
				map.PropertyName = "ProductCollectionByCategoryID";
				map.MyColumnName = "CategoryID";
				map.ParentColumnName = "CategoryID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void ProductCollectionByCategoryID_Delegate(esPrefetchParameters data)
		{
			CategoryQuery parent = new CategoryQuery(data.NextAlias());

			ProductQuery me = data.You != null ? data.You as ProductQuery : new ProductQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CategoryID == me.CategoryID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Product_Product
		/// </summary>

		[XmlIgnore]
		public ProductCollection ProductCollectionByCategoryID
		{
			get
			{
				if(this._ProductCollectionByCategoryID == null)
				{
					this._ProductCollectionByCategoryID = new ProductCollection();
					this._ProductCollectionByCategoryID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("ProductCollectionByCategoryID", this._ProductCollectionByCategoryID);
				
					if (this.CategoryID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._ProductCollectionByCategoryID.Query.Where(this._ProductCollectionByCategoryID.Query.CategoryID == this.CategoryID);
							this._ProductCollectionByCategoryID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._ProductCollectionByCategoryID.fks.Add(ProductMetadata.ColumnNames.CategoryID, this.CategoryID);
					}
				}

				return this._ProductCollectionByCategoryID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._ProductCollectionByCategoryID != null) 
				{ 
					this.RemovePostSave("ProductCollectionByCategoryID"); 
					this._ProductCollectionByCategoryID = null;
					this.OnPropertyChanged("ProductCollectionByCategoryID");
				} 
			} 			
		}
			
		
		private ProductCollection _ProductCollectionByCategoryID;
		#endregion

		#region ServiceCollectionByCategoryID - Zero To Many
		
		static public esPrefetchMap Prefetch_ServiceCollectionByCategoryID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Category.ServiceCollectionByCategoryID_Delegate;
				map.PropertyName = "ServiceCollectionByCategoryID";
				map.MyColumnName = "CategoryID";
				map.ParentColumnName = "CategoryID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void ServiceCollectionByCategoryID_Delegate(esPrefetchParameters data)
		{
			CategoryQuery parent = new CategoryQuery(data.NextAlias());

			ServiceQuery me = data.You != null ? data.You as ServiceQuery : new ServiceQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CategoryID == me.CategoryID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Service_Category
		/// </summary>

		[XmlIgnore]
		public ServiceCollection ServiceCollectionByCategoryID
		{
			get
			{
				if(this._ServiceCollectionByCategoryID == null)
				{
					this._ServiceCollectionByCategoryID = new ServiceCollection();
					this._ServiceCollectionByCategoryID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("ServiceCollectionByCategoryID", this._ServiceCollectionByCategoryID);
				
					if (this.CategoryID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._ServiceCollectionByCategoryID.Query.Where(this._ServiceCollectionByCategoryID.Query.CategoryID == this.CategoryID);
							this._ServiceCollectionByCategoryID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._ServiceCollectionByCategoryID.fks.Add(ServiceMetadata.ColumnNames.CategoryID, this.CategoryID);
					}
				}

				return this._ServiceCollectionByCategoryID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._ServiceCollectionByCategoryID != null) 
				{ 
					this.RemovePostSave("ServiceCollectionByCategoryID"); 
					this._ServiceCollectionByCategoryID = null;
					this.OnPropertyChanged("ServiceCollectionByCategoryID");
				} 
			} 			
		}
			
		
		private ServiceCollection _ServiceCollectionByCategoryID;
		#endregion

				
		#region UpToCompanyByCompanyID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Category_Company
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
				case "ProductCollectionByCategoryID":
					coll = this.ProductCollectionByCategoryID;
					break;
				case "ServiceCollectionByCategoryID":
					coll = this.ServiceCollectionByCategoryID;
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
			
			props.Add(new esPropertyDescriptor(this, "ProductCollectionByCategoryID", typeof(ProductCollection), new Product()));
			props.Add(new esPropertyDescriptor(this, "ServiceCollectionByCategoryID", typeof(ServiceCollection), new Service()));
		
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
			if(this._ProductCollectionByCategoryID != null)
			{
				Apply(this._ProductCollectionByCategoryID, "CategoryID", this.CategoryID);
			}
			if(this._ServiceCollectionByCategoryID != null)
			{
				Apply(this._ServiceCollectionByCategoryID, "CategoryID", this.CategoryID);
			}
		}
		
	}
	



	[Serializable]
	public partial class CategoryMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CategoryMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(CategoryMetadata.ColumnNames.CategoryID, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = CategoryMetadata.PropertyNames.CategoryID;
			c.IsInPrimaryKey = true;
			c.HasDefault = true;
			c.Default = @"(newid())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(CategoryMetadata.ColumnNames.CompanyID, 1, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = CategoryMetadata.PropertyNames.CompanyID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CategoryMetadata.ColumnNames.Name, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = CategoryMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CategoryMetadata.ColumnNames.Description, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = CategoryMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 250;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public CategoryMetadata Meta()
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
			 public const string CategoryID = "CategoryID";
			 public const string CompanyID = "CompanyID";
			 public const string Name = "Name";
			 public const string Description = "Description";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string CategoryID = "CategoryID";
			 public const string CompanyID = "CompanyID";
			 public const string Name = "Name";
			 public const string Description = "Description";
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
			lock (typeof(CategoryMetadata))
			{
				if(CategoryMetadata.mapDelegates == null)
				{
					CategoryMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CategoryMetadata.meta == null)
				{
					CategoryMetadata.meta = new CategoryMetadata();
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


				meta.AddTypeMap("CategoryID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("CompanyID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "Category";
				meta.Destination = "Category";
				
				meta.spInsert = "proc_CategoryInsert";				
				meta.spUpdate = "proc_CategoryUpdate";		
				meta.spDelete = "proc_CategoryDelete";
				meta.spLoadAll = "proc_CategoryLoadAll";
				meta.spLoadByPrimaryKey = "proc_CategoryLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private CategoryMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
