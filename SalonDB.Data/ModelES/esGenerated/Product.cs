
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 2017-02-20 7:11:16 PM
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
	/// Encapsulates the 'Product' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Product))]	
	[XmlType("Product")]
	public partial class Product : esProduct
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Product();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid productID)
		{
			var obj = new Product();
			obj.ProductID = productID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid productID, esSqlAccessType sqlAccessType)
		{
			var obj = new Product();
			obj.ProductID = productID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("ProductCollection")]
	public partial class ProductCollection : esProductCollection, IEnumerable<Product>
	{
		public Product FindByPrimaryKey(System.Guid productID)
		{
			return this.SingleOrDefault(e => e.ProductID == productID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Product))]
		public class ProductCollectionWCFPacket : esCollectionWCFPacket<ProductCollection>
		{
			public static implicit operator ProductCollection(ProductCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator ProductCollectionWCFPacket(ProductCollection collection)
			{
				return new ProductCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class ProductQuery : esProductQuery
	{
		public ProductQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "ProductQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(ProductQuery query)
		{
			return ProductQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ProductQuery(string query)
		{
			return (ProductQuery)ProductQuery.SerializeHelper.FromXml(query, typeof(ProductQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esProduct : EntityBase
	{
		public esProduct()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid productID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(productID);
			else
				return LoadByPrimaryKeyStoredProcedure(productID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid productID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(productID);
			else
				return LoadByPrimaryKeyStoredProcedure(productID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid productID)
		{
			ProductQuery query = new ProductQuery();
			query.Where(query.ProductID == productID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid productID)
		{
			esParameters parms = new esParameters();
			parms.Add("ProductID", productID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Product.ProductID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? ProductID
		{
			get
			{
				return base.GetSystemGuid(ProductMetadata.ColumnNames.ProductID);
			}
			
			set
			{
				if(base.SetSystemGuid(ProductMetadata.ColumnNames.ProductID, value))
				{
					OnPropertyChanged(ProductMetadata.PropertyNames.ProductID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Product.CompanyID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CompanyID
		{
			get
			{
				return base.GetSystemGuid(ProductMetadata.ColumnNames.CompanyID);
			}
			
			set
			{
				if(base.SetSystemGuid(ProductMetadata.ColumnNames.CompanyID, value))
				{
					this._UpToCompanyByCompanyID = null;
					this.OnPropertyChanged("UpToCompanyByCompanyID");
					OnPropertyChanged(ProductMetadata.PropertyNames.CompanyID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Product.CategoryID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CategoryID
		{
			get
			{
				return base.GetSystemGuid(ProductMetadata.ColumnNames.CategoryID);
			}
			
			set
			{
				if(base.SetSystemGuid(ProductMetadata.ColumnNames.CategoryID, value))
				{
					this._UpToCategoryByCategoryID = null;
					this.OnPropertyChanged("UpToCategoryByCategoryID");
					OnPropertyChanged(ProductMetadata.PropertyNames.CategoryID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Product.SupplierID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? SupplierID
		{
			get
			{
				return base.GetSystemGuid(ProductMetadata.ColumnNames.SupplierID);
			}
			
			set
			{
				if(base.SetSystemGuid(ProductMetadata.ColumnNames.SupplierID, value))
				{
					this._UpToSupplierBySupplierID = null;
					this.OnPropertyChanged("UpToSupplierBySupplierID");
					OnPropertyChanged(ProductMetadata.PropertyNames.SupplierID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Product.Name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(ProductMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(ProductMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(ProductMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Product.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(ProductMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(ProductMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(ProductMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Product.Price
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Price
		{
			get
			{
				return base.GetSystemDecimal(ProductMetadata.ColumnNames.Price);
			}
			
			set
			{
				if(base.SetSystemDecimal(ProductMetadata.ColumnNames.Price, value))
				{
					OnPropertyChanged(ProductMetadata.PropertyNames.Price);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Product.WholesalePrice
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? WholesalePrice
		{
			get
			{
				return base.GetSystemDecimal(ProductMetadata.ColumnNames.WholesalePrice);
			}
			
			set
			{
				if(base.SetSystemDecimal(ProductMetadata.ColumnNames.WholesalePrice, value))
				{
					OnPropertyChanged(ProductMetadata.PropertyNames.WholesalePrice);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Product.Commission
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Commission
		{
			get
			{
				return base.GetSystemDecimal(ProductMetadata.ColumnNames.Commission);
			}
			
			set
			{
				if(base.SetSystemDecimal(ProductMetadata.ColumnNames.Commission, value))
				{
					OnPropertyChanged(ProductMetadata.PropertyNames.Commission);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Product.BarCode
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String BarCode
		{
			get
			{
				return base.GetSystemString(ProductMetadata.ColumnNames.BarCode);
			}
			
			set
			{
				if(base.SetSystemString(ProductMetadata.ColumnNames.BarCode, value))
				{
					OnPropertyChanged(ProductMetadata.PropertyNames.BarCode);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Product.UnitsInStock
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? UnitsInStock
		{
			get
			{
				return base.GetSystemInt32(ProductMetadata.ColumnNames.UnitsInStock);
			}
			
			set
			{
				if(base.SetSystemInt32(ProductMetadata.ColumnNames.UnitsInStock, value))
				{
					OnPropertyChanged(ProductMetadata.PropertyNames.UnitsInStock);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Product.UnitsOnOrder
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? UnitsOnOrder
		{
			get
			{
				return base.GetSystemInt32(ProductMetadata.ColumnNames.UnitsOnOrder);
			}
			
			set
			{
				if(base.SetSystemInt32(ProductMetadata.ColumnNames.UnitsOnOrder, value))
				{
					OnPropertyChanged(ProductMetadata.PropertyNames.UnitsOnOrder);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Product.MinimumStockLevel
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? MinimumStockLevel
		{
			get
			{
				return base.GetSystemInt32(ProductMetadata.ColumnNames.MinimumStockLevel);
			}
			
			set
			{
				if(base.SetSystemInt32(ProductMetadata.ColumnNames.MinimumStockLevel, value))
				{
					OnPropertyChanged(ProductMetadata.PropertyNames.MinimumStockLevel);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Category _UpToCategoryByCategoryID;
		[CLSCompliant(false)]
		internal protected Company _UpToCompanyByCompanyID;
		[CLSCompliant(false)]
		internal protected Supplier _UpToSupplierBySupplierID;
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
						case "ProductID": this.str().ProductID = (string)value; break;							
						case "CompanyID": this.str().CompanyID = (string)value; break;							
						case "CategoryID": this.str().CategoryID = (string)value; break;							
						case "SupplierID": this.str().SupplierID = (string)value; break;							
						case "Name": this.str().Name = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;							
						case "Price": this.str().Price = (string)value; break;							
						case "WholesalePrice": this.str().WholesalePrice = (string)value; break;							
						case "Commission": this.str().Commission = (string)value; break;							
						case "BarCode": this.str().BarCode = (string)value; break;							
						case "UnitsInStock": this.str().UnitsInStock = (string)value; break;							
						case "UnitsOnOrder": this.str().UnitsOnOrder = (string)value; break;							
						case "MinimumStockLevel": this.str().MinimumStockLevel = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "ProductID":
						
							if (value == null || value is System.Guid)
								this.ProductID = (System.Guid?)value;
								OnPropertyChanged(ProductMetadata.PropertyNames.ProductID);
							break;
						
						case "CompanyID":
						
							if (value == null || value is System.Guid)
								this.CompanyID = (System.Guid?)value;
								OnPropertyChanged(ProductMetadata.PropertyNames.CompanyID);
							break;
						
						case "CategoryID":
						
							if (value == null || value is System.Guid)
								this.CategoryID = (System.Guid?)value;
								OnPropertyChanged(ProductMetadata.PropertyNames.CategoryID);
							break;
						
						case "SupplierID":
						
							if (value == null || value is System.Guid)
								this.SupplierID = (System.Guid?)value;
								OnPropertyChanged(ProductMetadata.PropertyNames.SupplierID);
							break;
						
						case "Price":
						
							if (value == null || value is System.Decimal)
								this.Price = (System.Decimal?)value;
								OnPropertyChanged(ProductMetadata.PropertyNames.Price);
							break;
						
						case "WholesalePrice":
						
							if (value == null || value is System.Decimal)
								this.WholesalePrice = (System.Decimal?)value;
								OnPropertyChanged(ProductMetadata.PropertyNames.WholesalePrice);
							break;
						
						case "Commission":
						
							if (value == null || value is System.Decimal)
								this.Commission = (System.Decimal?)value;
								OnPropertyChanged(ProductMetadata.PropertyNames.Commission);
							break;
						
						case "UnitsInStock":
						
							if (value == null || value is System.Int32)
								this.UnitsInStock = (System.Int32?)value;
								OnPropertyChanged(ProductMetadata.PropertyNames.UnitsInStock);
							break;
						
						case "UnitsOnOrder":
						
							if (value == null || value is System.Int32)
								this.UnitsOnOrder = (System.Int32?)value;
								OnPropertyChanged(ProductMetadata.PropertyNames.UnitsOnOrder);
							break;
						
						case "MinimumStockLevel":
						
							if (value == null || value is System.Int32)
								this.MinimumStockLevel = (System.Int32?)value;
								OnPropertyChanged(ProductMetadata.PropertyNames.MinimumStockLevel);
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
			public esStrings(esProduct entity)
			{
				this.entity = entity;
			}
			
	
			public System.String ProductID
			{
				get
				{
					System.Guid? data = entity.ProductID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ProductID = null;
					else entity.ProductID = new Guid(value);
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
				
			public System.String WholesalePrice
			{
				get
				{
					System.Decimal? data = entity.WholesalePrice;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.WholesalePrice = null;
					else entity.WholesalePrice = Convert.ToDecimal(value);
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
				
			public System.String BarCode
			{
				get
				{
					System.String data = entity.BarCode;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.BarCode = null;
					else entity.BarCode = Convert.ToString(value);
				}
			}
				
			public System.String UnitsInStock
			{
				get
				{
					System.Int32? data = entity.UnitsInStock;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UnitsInStock = null;
					else entity.UnitsInStock = Convert.ToInt32(value);
				}
			}
				
			public System.String UnitsOnOrder
			{
				get
				{
					System.Int32? data = entity.UnitsOnOrder;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UnitsOnOrder = null;
					else entity.UnitsOnOrder = Convert.ToInt32(value);
				}
			}
				
			public System.String MinimumStockLevel
			{
				get
				{
					System.Int32? data = entity.MinimumStockLevel;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.MinimumStockLevel = null;
					else entity.MinimumStockLevel = Convert.ToInt32(value);
				}
			}
			

			private esProduct entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return ProductMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public ProductQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ProductQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ProductQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(ProductQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private ProductQuery query;		
	}



	[Serializable]
	abstract public partial class esProductCollection : CollectionBase<Product>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ProductMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "ProductCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public ProductQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ProductQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ProductQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ProductQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(ProductQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((ProductQuery)query);
		}

		#endregion
		
		private ProductQuery query;
	}



	[Serializable]
	abstract public partial class esProductQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return ProductMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "ProductID": return this.ProductID;
				case "CompanyID": return this.CompanyID;
				case "CategoryID": return this.CategoryID;
				case "SupplierID": return this.SupplierID;
				case "Name": return this.Name;
				case "Description": return this.Description;
				case "Price": return this.Price;
				case "WholesalePrice": return this.WholesalePrice;
				case "Commission": return this.Commission;
				case "BarCode": return this.BarCode;
				case "UnitsInStock": return this.UnitsInStock;
				case "UnitsOnOrder": return this.UnitsOnOrder;
				case "MinimumStockLevel": return this.MinimumStockLevel;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem ProductID
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.ProductID, esSystemType.Guid); }
		} 
		
		public esQueryItem CompanyID
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.CompanyID, esSystemType.Guid); }
		} 
		
		public esQueryItem CategoryID
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.CategoryID, esSystemType.Guid); }
		} 
		
		public esQueryItem SupplierID
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.SupplierID, esSystemType.Guid); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem Price
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.Price, esSystemType.Decimal); }
		} 
		
		public esQueryItem WholesalePrice
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.WholesalePrice, esSystemType.Decimal); }
		} 
		
		public esQueryItem Commission
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.Commission, esSystemType.Decimal); }
		} 
		
		public esQueryItem BarCode
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.BarCode, esSystemType.String); }
		} 
		
		public esQueryItem UnitsInStock
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.UnitsInStock, esSystemType.Int32); }
		} 
		
		public esQueryItem UnitsOnOrder
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.UnitsOnOrder, esSystemType.Int32); }
		} 
		
		public esQueryItem MinimumStockLevel
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.MinimumStockLevel, esSystemType.Int32); }
		} 
		
		#endregion
		
	}


	
	public partial class Product : esProduct
	{

		#region TransactionDetailProductCollectionByProductID - Zero To Many
		
		static public esPrefetchMap Prefetch_TransactionDetailProductCollectionByProductID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Product.TransactionDetailProductCollectionByProductID_Delegate;
				map.PropertyName = "TransactionDetailProductCollectionByProductID";
				map.MyColumnName = "ProductID";
				map.ParentColumnName = "ProductID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void TransactionDetailProductCollectionByProductID_Delegate(esPrefetchParameters data)
		{
			ProductQuery parent = new ProductQuery(data.NextAlias());

			TransactionDetailProductQuery me = data.You != null ? data.You as TransactionDetailProductQuery : new TransactionDetailProductQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.ProductID == me.ProductID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_TransactionDetailProduct_Product
		/// </summary>

		[XmlIgnore]
		public TransactionDetailProductCollection TransactionDetailProductCollectionByProductID
		{
			get
			{
				if(this._TransactionDetailProductCollectionByProductID == null)
				{
					this._TransactionDetailProductCollectionByProductID = new TransactionDetailProductCollection();
					this._TransactionDetailProductCollectionByProductID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("TransactionDetailProductCollectionByProductID", this._TransactionDetailProductCollectionByProductID);
				
					if (this.ProductID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._TransactionDetailProductCollectionByProductID.Query.Where(this._TransactionDetailProductCollectionByProductID.Query.ProductID == this.ProductID);
							this._TransactionDetailProductCollectionByProductID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._TransactionDetailProductCollectionByProductID.fks.Add(TransactionDetailProductMetadata.ColumnNames.ProductID, this.ProductID);
					}
				}

				return this._TransactionDetailProductCollectionByProductID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._TransactionDetailProductCollectionByProductID != null) 
				{ 
					this.RemovePostSave("TransactionDetailProductCollectionByProductID"); 
					this._TransactionDetailProductCollectionByProductID = null;
					this.OnPropertyChanged("TransactionDetailProductCollectionByProductID");
				} 
			} 			
		}
			
		
		private TransactionDetailProductCollection _TransactionDetailProductCollectionByProductID;
		#endregion

				
		#region UpToCategoryByCategoryID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Product_Product
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
		/// Foreign Key Name - FK_Product_Company
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
		

				
		#region UpToSupplierBySupplierID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Product_Supplier
		/// </summary>

		[XmlIgnore]
					
		public Supplier UpToSupplierBySupplierID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToSupplierBySupplierID == null && SupplierID != null)
				{
					this._UpToSupplierBySupplierID = new Supplier();
					this._UpToSupplierBySupplierID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToSupplierBySupplierID", this._UpToSupplierBySupplierID);
					this._UpToSupplierBySupplierID.Query.Where(this._UpToSupplierBySupplierID.Query.SupplierID == this.SupplierID);
					this._UpToSupplierBySupplierID.Query.Load();
				}	
				return this._UpToSupplierBySupplierID;
			}
			
			set
			{
				this.RemovePreSave("UpToSupplierBySupplierID");
				
				bool changed = this._UpToSupplierBySupplierID != value;

				if(value == null)
				{
					this.SupplierID = null;
					this._UpToSupplierBySupplierID = null;
				}
				else
				{
					this.SupplierID = value.SupplierID;
					this._UpToSupplierBySupplierID = value;
					this.SetPreSave("UpToSupplierBySupplierID", this._UpToSupplierBySupplierID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToSupplierBySupplierID");
				}
			}
		}
		#endregion
		

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "TransactionDetailProductCollectionByProductID":
					coll = this.TransactionDetailProductCollectionByProductID;
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
			
			props.Add(new esPropertyDescriptor(this, "TransactionDetailProductCollectionByProductID", typeof(TransactionDetailProductCollection), new TransactionDetailProduct()));
		
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
			if(!this.es.IsDeleted && this._UpToSupplierBySupplierID != null)
			{
				this.SupplierID = this._UpToSupplierBySupplierID.SupplierID;
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
			if(this._TransactionDetailProductCollectionByProductID != null)
			{
				Apply(this._TransactionDetailProductCollectionByProductID, "ProductID", this.ProductID);
			}
		}
		
	}
	



	[Serializable]
	public partial class ProductMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ProductMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ProductMetadata.ColumnNames.ProductID, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = ProductMetadata.PropertyNames.ProductID;
			c.IsInPrimaryKey = true;
			c.HasDefault = true;
			c.Default = @"(newid())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.CompanyID, 1, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = ProductMetadata.PropertyNames.CompanyID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.CategoryID, 2, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = ProductMetadata.PropertyNames.CategoryID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.SupplierID, 3, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = ProductMetadata.PropertyNames.SupplierID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.Name, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = ProductMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.Description, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = ProductMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 250;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.Price, 6, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = ProductMetadata.PropertyNames.Price;
			c.NumericPrecision = 18;
			c.NumericScale = 4;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.WholesalePrice, 7, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = ProductMetadata.PropertyNames.WholesalePrice;
			c.NumericPrecision = 18;
			c.NumericScale = 4;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.Commission, 8, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = ProductMetadata.PropertyNames.Commission;
			c.NumericPrecision = 18;
			c.NumericScale = 4;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.BarCode, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = ProductMetadata.PropertyNames.BarCode;
			c.CharacterMaxLength = 128;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.UnitsInStock, 10, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ProductMetadata.PropertyNames.UnitsInStock;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.UnitsOnOrder, 11, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ProductMetadata.PropertyNames.UnitsOnOrder;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.MinimumStockLevel, 12, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ProductMetadata.PropertyNames.MinimumStockLevel;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public ProductMetadata Meta()
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
			 public const string ProductID = "ProductID";
			 public const string CompanyID = "CompanyID";
			 public const string CategoryID = "CategoryID";
			 public const string SupplierID = "SupplierID";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Price = "Price";
			 public const string WholesalePrice = "WholesalePrice";
			 public const string Commission = "Commission";
			 public const string BarCode = "BarCode";
			 public const string UnitsInStock = "UnitsInStock";
			 public const string UnitsOnOrder = "UnitsOnOrder";
			 public const string MinimumStockLevel = "MinimumStockLevel";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string ProductID = "ProductID";
			 public const string CompanyID = "CompanyID";
			 public const string CategoryID = "CategoryID";
			 public const string SupplierID = "SupplierID";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Price = "Price";
			 public const string WholesalePrice = "WholesalePrice";
			 public const string Commission = "Commission";
			 public const string BarCode = "BarCode";
			 public const string UnitsInStock = "UnitsInStock";
			 public const string UnitsOnOrder = "UnitsOnOrder";
			 public const string MinimumStockLevel = "MinimumStockLevel";
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
			lock (typeof(ProductMetadata))
			{
				if(ProductMetadata.mapDelegates == null)
				{
					ProductMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ProductMetadata.meta == null)
				{
					ProductMetadata.meta = new ProductMetadata();
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


				meta.AddTypeMap("ProductID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("CompanyID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("CategoryID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("SupplierID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Price", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("WholesalePrice", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("Commission", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("BarCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("UnitsInStock", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("UnitsOnOrder", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("MinimumStockLevel", new esTypeMap("int", "System.Int32"));			
				
				
				
				meta.Source = "Product";
				meta.Destination = "Product";
				
				meta.spInsert = "proc_ProductInsert";				
				meta.spUpdate = "proc_ProductUpdate";		
				meta.spDelete = "proc_ProductDelete";
				meta.spLoadAll = "proc_ProductLoadAll";
				meta.spLoadByPrimaryKey = "proc_ProductLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ProductMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
