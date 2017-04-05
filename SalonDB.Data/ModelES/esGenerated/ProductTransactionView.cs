
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 2017-01-20 2:36:47 PM
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
	/// Encapsulates the 'ProductTransactionView' view
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(ProductTransactionView))]	
	[XmlType("ProductTransactionView")]
	public partial class ProductTransactionView : esProductTransactionView
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new ProductTransactionView();
		}
		
		#region Static Quick Access Methods
		
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("ProductTransactionViewCollection")]
	public partial class ProductTransactionViewCollection : esProductTransactionViewCollection, IEnumerable<ProductTransactionView>
	{

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(ProductTransactionView))]
		public class ProductTransactionViewCollectionWCFPacket : esCollectionWCFPacket<ProductTransactionViewCollection>
		{
			public static implicit operator ProductTransactionViewCollection(ProductTransactionViewCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator ProductTransactionViewCollectionWCFPacket(ProductTransactionViewCollection collection)
			{
				return new ProductTransactionViewCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class ProductTransactionViewQuery : esProductTransactionViewQuery
	{
		public ProductTransactionViewQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "ProductTransactionViewQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(ProductTransactionViewQuery query)
		{
			return ProductTransactionViewQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ProductTransactionViewQuery(string query)
		{
			return (ProductTransactionViewQuery)ProductTransactionViewQuery.SerializeHelper.FromXml(query, typeof(ProductTransactionViewQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esProductTransactionView : EntityBase
	{
		public esProductTransactionView()
		{

		}
		
		#region LoadByPrimaryKey
		
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to ProductTransactionView.TransactionID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? TransactionID
		{
			get
			{
				return base.GetSystemGuid(ProductTransactionViewMetadata.ColumnNames.TransactionID);
			}
			
			set
			{
				if(base.SetSystemGuid(ProductTransactionViewMetadata.ColumnNames.TransactionID, value))
				{
					OnPropertyChanged(ProductTransactionViewMetadata.PropertyNames.TransactionID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ProductTransactionView.Name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(ProductTransactionViewMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(ProductTransactionViewMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(ProductTransactionViewMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ProductTransactionView.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(ProductTransactionViewMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(ProductTransactionViewMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(ProductTransactionViewMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ProductTransactionView.Price
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Price
		{
			get
			{
				return base.GetSystemDecimal(ProductTransactionViewMetadata.ColumnNames.Price);
			}
			
			set
			{
				if(base.SetSystemDecimal(ProductTransactionViewMetadata.ColumnNames.Price, value))
				{
					OnPropertyChanged(ProductTransactionViewMetadata.PropertyNames.Price);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ProductTransactionView.TransactionDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? TransactionDate
		{
			get
			{
				return base.GetSystemDateTime(ProductTransactionViewMetadata.ColumnNames.TransactionDate);
			}
			
			set
			{
				if(base.SetSystemDateTime(ProductTransactionViewMetadata.ColumnNames.TransactionDate, value))
				{
					OnPropertyChanged(ProductTransactionViewMetadata.PropertyNames.TransactionDate);
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
						case "TransactionID": this.str().TransactionID = (string)value; break;							
						case "Name": this.str().Name = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;							
						case "Price": this.str().Price = (string)value; break;							
						case "TransactionDate": this.str().TransactionDate = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "TransactionID":
						
							if (value == null || value is System.Guid)
								this.TransactionID = (System.Guid?)value;
								OnPropertyChanged(ProductTransactionViewMetadata.PropertyNames.TransactionID);
							break;
						
						case "Price":
						
							if (value == null || value is System.Decimal)
								this.Price = (System.Decimal?)value;
								OnPropertyChanged(ProductTransactionViewMetadata.PropertyNames.Price);
							break;
						
						case "TransactionDate":
						
							if (value == null || value is System.DateTime)
								this.TransactionDate = (System.DateTime?)value;
								OnPropertyChanged(ProductTransactionViewMetadata.PropertyNames.TransactionDate);
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
			public esStrings(esProductTransactionView entity)
			{
				this.entity = entity;
			}
			
	
			public System.String TransactionID
			{
				get
				{
					System.Guid? data = entity.TransactionID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TransactionID = null;
					else entity.TransactionID = new Guid(value);
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
				
			public System.String TransactionDate
			{
				get
				{
					System.DateTime? data = entity.TransactionDate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TransactionDate = null;
					else entity.TransactionDate = Convert.ToDateTime(value);
				}
			}
			

			private esProductTransactionView entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return ProductTransactionViewMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public ProductTransactionViewQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ProductTransactionViewQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ProductTransactionViewQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(ProductTransactionViewQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private ProductTransactionViewQuery query;		
	}



	[Serializable]
	abstract public partial class esProductTransactionViewCollection : CollectionBase<ProductTransactionView>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ProductTransactionViewMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "ProductTransactionViewCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public ProductTransactionViewQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ProductTransactionViewQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ProductTransactionViewQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ProductTransactionViewQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(ProductTransactionViewQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((ProductTransactionViewQuery)query);
		}

		#endregion
		
		private ProductTransactionViewQuery query;
	}



	[Serializable]
	abstract public partial class esProductTransactionViewQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return ProductTransactionViewMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "TransactionID": return this.TransactionID;
				case "Name": return this.Name;
				case "Description": return this.Description;
				case "Price": return this.Price;
				case "TransactionDate": return this.TransactionDate;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem TransactionID
		{
			get { return new esQueryItem(this, ProductTransactionViewMetadata.ColumnNames.TransactionID, esSystemType.Guid); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, ProductTransactionViewMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, ProductTransactionViewMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem Price
		{
			get { return new esQueryItem(this, ProductTransactionViewMetadata.ColumnNames.Price, esSystemType.Decimal); }
		} 
		
		public esQueryItem TransactionDate
		{
			get { return new esQueryItem(this, ProductTransactionViewMetadata.ColumnNames.TransactionDate, esSystemType.DateTime); }
		} 
		
		#endregion
		
	}



	[Serializable]
	public partial class ProductTransactionViewMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ProductTransactionViewMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ProductTransactionViewMetadata.ColumnNames.TransactionID, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = ProductTransactionViewMetadata.PropertyNames.TransactionID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductTransactionViewMetadata.ColumnNames.Name, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = ProductTransactionViewMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductTransactionViewMetadata.ColumnNames.Description, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = ProductTransactionViewMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 250;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductTransactionViewMetadata.ColumnNames.Price, 3, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = ProductTransactionViewMetadata.PropertyNames.Price;
			c.NumericPrecision = 18;
			c.NumericScale = 4;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductTransactionViewMetadata.ColumnNames.TransactionDate, 4, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = ProductTransactionViewMetadata.PropertyNames.TransactionDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public ProductTransactionViewMetadata Meta()
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
			 public const string TransactionID = "TransactionID";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Price = "Price";
			 public const string TransactionDate = "TransactionDate";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string TransactionID = "TransactionID";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Price = "Price";
			 public const string TransactionDate = "TransactionDate";
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
			lock (typeof(ProductTransactionViewMetadata))
			{
				if(ProductTransactionViewMetadata.mapDelegates == null)
				{
					ProductTransactionViewMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ProductTransactionViewMetadata.meta == null)
				{
					ProductTransactionViewMetadata.meta = new ProductTransactionViewMetadata();
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


				meta.AddTypeMap("TransactionID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Price", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("TransactionDate", new esTypeMap("datetime", "System.DateTime"));			
				
				
				
				meta.Source = "ProductTransactionView";
				meta.Destination = "ProductTransactionView";
				
				meta.spInsert = "proc_ProductTransactionViewInsert";				
				meta.spUpdate = "proc_ProductTransactionViewUpdate";		
				meta.spDelete = "proc_ProductTransactionViewDelete";
				meta.spLoadAll = "proc_ProductTransactionViewLoadAll";
				meta.spLoadByPrimaryKey = "proc_ProductTransactionViewLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ProductTransactionViewMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
