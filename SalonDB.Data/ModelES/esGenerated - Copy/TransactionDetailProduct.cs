
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
	/// Encapsulates the 'TransactionDetailProduct' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(TransactionDetailProduct))]	
	[XmlType("TransactionDetailProduct")]
	public partial class TransactionDetailProduct : esTransactionDetailProduct
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new TransactionDetailProduct();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid transactionDetailProductID)
		{
			var obj = new TransactionDetailProduct();
			obj.TransactionDetailProductID = transactionDetailProductID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid transactionDetailProductID, esSqlAccessType sqlAccessType)
		{
			var obj = new TransactionDetailProduct();
			obj.TransactionDetailProductID = transactionDetailProductID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("TransactionDetailProductCollection")]
	public partial class TransactionDetailProductCollection : esTransactionDetailProductCollection, IEnumerable<TransactionDetailProduct>
	{
		public TransactionDetailProduct FindByPrimaryKey(System.Guid transactionDetailProductID)
		{
			return this.SingleOrDefault(e => e.TransactionDetailProductID == transactionDetailProductID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(TransactionDetailProduct))]
		public class TransactionDetailProductCollectionWCFPacket : esCollectionWCFPacket<TransactionDetailProductCollection>
		{
			public static implicit operator TransactionDetailProductCollection(TransactionDetailProductCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator TransactionDetailProductCollectionWCFPacket(TransactionDetailProductCollection collection)
			{
				return new TransactionDetailProductCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class TransactionDetailProductQuery : esTransactionDetailProductQuery
	{
		public TransactionDetailProductQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "TransactionDetailProductQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(TransactionDetailProductQuery query)
		{
			return TransactionDetailProductQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator TransactionDetailProductQuery(string query)
		{
			return (TransactionDetailProductQuery)TransactionDetailProductQuery.SerializeHelper.FromXml(query, typeof(TransactionDetailProductQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esTransactionDetailProduct : EntityBase
	{
		public esTransactionDetailProduct()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid transactionDetailProductID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(transactionDetailProductID);
			else
				return LoadByPrimaryKeyStoredProcedure(transactionDetailProductID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid transactionDetailProductID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(transactionDetailProductID);
			else
				return LoadByPrimaryKeyStoredProcedure(transactionDetailProductID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid transactionDetailProductID)
		{
			TransactionDetailProductQuery query = new TransactionDetailProductQuery();
			query.Where(query.TransactionDetailProductID == transactionDetailProductID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid transactionDetailProductID)
		{
			esParameters parms = new esParameters();
			parms.Add("TransactionDetailProductID", transactionDetailProductID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to TransactionDetailProduct.TransactionDetailProductID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? TransactionDetailProductID
		{
			get
			{
				return base.GetSystemGuid(TransactionDetailProductMetadata.ColumnNames.TransactionDetailProductID);
			}
			
			set
			{
				if(base.SetSystemGuid(TransactionDetailProductMetadata.ColumnNames.TransactionDetailProductID, value))
				{
					OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.TransactionDetailProductID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailProduct.CompanyID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CompanyID
		{
			get
			{
				return base.GetSystemGuid(TransactionDetailProductMetadata.ColumnNames.CompanyID);
			}
			
			set
			{
				if(base.SetSystemGuid(TransactionDetailProductMetadata.ColumnNames.CompanyID, value))
				{
					this._UpToCompanyByCompanyID = null;
					this.OnPropertyChanged("UpToCompanyByCompanyID");
					OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.CompanyID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailProduct.TransactionID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? TransactionID
		{
			get
			{
				return base.GetSystemGuid(TransactionDetailProductMetadata.ColumnNames.TransactionID);
			}
			
			set
			{
				if(base.SetSystemGuid(TransactionDetailProductMetadata.ColumnNames.TransactionID, value))
				{
					this._UpToTransactionByTransactionID = null;
					this.OnPropertyChanged("UpToTransactionByTransactionID");
					OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.TransactionID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailProduct.ProductID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? ProductID
		{
			get
			{
				return base.GetSystemGuid(TransactionDetailProductMetadata.ColumnNames.ProductID);
			}
			
			set
			{
				if(base.SetSystemGuid(TransactionDetailProductMetadata.ColumnNames.ProductID, value))
				{
					this._UpToProductByProductID = null;
					this.OnPropertyChanged("UpToProductByProductID");
					OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.ProductID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailProduct.Name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(TransactionDetailProductMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(TransactionDetailProductMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailProduct.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(TransactionDetailProductMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(TransactionDetailProductMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailProduct.Price
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Price
		{
			get
			{
				return base.GetSystemDecimal(TransactionDetailProductMetadata.ColumnNames.Price);
			}
			
			set
			{
				if(base.SetSystemDecimal(TransactionDetailProductMetadata.ColumnNames.Price, value))
				{
					OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.Price);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailProduct.WholesalePrice
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? WholesalePrice
		{
			get
			{
				return base.GetSystemDecimal(TransactionDetailProductMetadata.ColumnNames.WholesalePrice);
			}
			
			set
			{
				if(base.SetSystemDecimal(TransactionDetailProductMetadata.ColumnNames.WholesalePrice, value))
				{
					OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.WholesalePrice);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailProduct.Commission
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Commission
		{
			get
			{
				return base.GetSystemDecimal(TransactionDetailProductMetadata.ColumnNames.Commission);
			}
			
			set
			{
				if(base.SetSystemDecimal(TransactionDetailProductMetadata.ColumnNames.Commission, value))
				{
					OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.Commission);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailProduct.BarCode
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String BarCode
		{
			get
			{
				return base.GetSystemString(TransactionDetailProductMetadata.ColumnNames.BarCode);
			}
			
			set
			{
				if(base.SetSystemString(TransactionDetailProductMetadata.ColumnNames.BarCode, value))
				{
					OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.BarCode);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Company _UpToCompanyByCompanyID;
		[CLSCompliant(false)]
		internal protected Product _UpToProductByProductID;
		[CLSCompliant(false)]
		internal protected Transaction _UpToTransactionByTransactionID;
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
						case "TransactionDetailProductID": this.str().TransactionDetailProductID = (string)value; break;							
						case "CompanyID": this.str().CompanyID = (string)value; break;							
						case "TransactionID": this.str().TransactionID = (string)value; break;							
						case "ProductID": this.str().ProductID = (string)value; break;							
						case "Name": this.str().Name = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;							
						case "Price": this.str().Price = (string)value; break;							
						case "WholesalePrice": this.str().WholesalePrice = (string)value; break;							
						case "Commission": this.str().Commission = (string)value; break;							
						case "BarCode": this.str().BarCode = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "TransactionDetailProductID":
						
							if (value == null || value is System.Guid)
								this.TransactionDetailProductID = (System.Guid?)value;
								OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.TransactionDetailProductID);
							break;
						
						case "CompanyID":
						
							if (value == null || value is System.Guid)
								this.CompanyID = (System.Guid?)value;
								OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.CompanyID);
							break;
						
						case "TransactionID":
						
							if (value == null || value is System.Guid)
								this.TransactionID = (System.Guid?)value;
								OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.TransactionID);
							break;
						
						case "ProductID":
						
							if (value == null || value is System.Guid)
								this.ProductID = (System.Guid?)value;
								OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.ProductID);
							break;
						
						case "Price":
						
							if (value == null || value is System.Decimal)
								this.Price = (System.Decimal?)value;
								OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.Price);
							break;
						
						case "WholesalePrice":
						
							if (value == null || value is System.Decimal)
								this.WholesalePrice = (System.Decimal?)value;
								OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.WholesalePrice);
							break;
						
						case "Commission":
						
							if (value == null || value is System.Decimal)
								this.Commission = (System.Decimal?)value;
								OnPropertyChanged(TransactionDetailProductMetadata.PropertyNames.Commission);
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
			public esStrings(esTransactionDetailProduct entity)
			{
				this.entity = entity;
			}
			
	
			public System.String TransactionDetailProductID
			{
				get
				{
					System.Guid? data = entity.TransactionDetailProductID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TransactionDetailProductID = null;
					else entity.TransactionDetailProductID = new Guid(value);
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
			

			private esTransactionDetailProduct entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return TransactionDetailProductMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public TransactionDetailProductQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TransactionDetailProductQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(TransactionDetailProductQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(TransactionDetailProductQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private TransactionDetailProductQuery query;		
	}



	[Serializable]
	abstract public partial class esTransactionDetailProductCollection : CollectionBase<TransactionDetailProduct>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return TransactionDetailProductMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "TransactionDetailProductCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public TransactionDetailProductQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TransactionDetailProductQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(TransactionDetailProductQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new TransactionDetailProductQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(TransactionDetailProductQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((TransactionDetailProductQuery)query);
		}

		#endregion
		
		private TransactionDetailProductQuery query;
	}



	[Serializable]
	abstract public partial class esTransactionDetailProductQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return TransactionDetailProductMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "TransactionDetailProductID": return this.TransactionDetailProductID;
				case "CompanyID": return this.CompanyID;
				case "TransactionID": return this.TransactionID;
				case "ProductID": return this.ProductID;
				case "Name": return this.Name;
				case "Description": return this.Description;
				case "Price": return this.Price;
				case "WholesalePrice": return this.WholesalePrice;
				case "Commission": return this.Commission;
				case "BarCode": return this.BarCode;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem TransactionDetailProductID
		{
			get { return new esQueryItem(this, TransactionDetailProductMetadata.ColumnNames.TransactionDetailProductID, esSystemType.Guid); }
		} 
		
		public esQueryItem CompanyID
		{
			get { return new esQueryItem(this, TransactionDetailProductMetadata.ColumnNames.CompanyID, esSystemType.Guid); }
		} 
		
		public esQueryItem TransactionID
		{
			get { return new esQueryItem(this, TransactionDetailProductMetadata.ColumnNames.TransactionID, esSystemType.Guid); }
		} 
		
		public esQueryItem ProductID
		{
			get { return new esQueryItem(this, TransactionDetailProductMetadata.ColumnNames.ProductID, esSystemType.Guid); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, TransactionDetailProductMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, TransactionDetailProductMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem Price
		{
			get { return new esQueryItem(this, TransactionDetailProductMetadata.ColumnNames.Price, esSystemType.Decimal); }
		} 
		
		public esQueryItem WholesalePrice
		{
			get { return new esQueryItem(this, TransactionDetailProductMetadata.ColumnNames.WholesalePrice, esSystemType.Decimal); }
		} 
		
		public esQueryItem Commission
		{
			get { return new esQueryItem(this, TransactionDetailProductMetadata.ColumnNames.Commission, esSystemType.Decimal); }
		} 
		
		public esQueryItem BarCode
		{
			get { return new esQueryItem(this, TransactionDetailProductMetadata.ColumnNames.BarCode, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class TransactionDetailProduct : esTransactionDetailProduct
	{

				
		#region UpToCompanyByCompanyID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_TransactionDetailProduct_Company
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
		

				
		#region UpToProductByProductID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_TransactionDetailProduct_Product
		/// </summary>

		[XmlIgnore]
					
		public Product UpToProductByProductID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToProductByProductID == null && ProductID != null)
				{
					this._UpToProductByProductID = new Product();
					this._UpToProductByProductID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToProductByProductID", this._UpToProductByProductID);
					this._UpToProductByProductID.Query.Where(this._UpToProductByProductID.Query.ProductID == this.ProductID);
					this._UpToProductByProductID.Query.Load();
				}	
				return this._UpToProductByProductID;
			}
			
			set
			{
				this.RemovePreSave("UpToProductByProductID");
				
				bool changed = this._UpToProductByProductID != value;

				if(value == null)
				{
					this.ProductID = null;
					this._UpToProductByProductID = null;
				}
				else
				{
					this.ProductID = value.ProductID;
					this._UpToProductByProductID = value;
					this.SetPreSave("UpToProductByProductID", this._UpToProductByProductID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToProductByProductID");
				}
			}
		}
		#endregion
		

				
		#region UpToTransactionByTransactionID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_TransactionDetailProduct_Transaction
		/// </summary>

		[XmlIgnore]
					
		public Transaction UpToTransactionByTransactionID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToTransactionByTransactionID == null && TransactionID != null)
				{
					this._UpToTransactionByTransactionID = new Transaction();
					this._UpToTransactionByTransactionID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToTransactionByTransactionID", this._UpToTransactionByTransactionID);
					this._UpToTransactionByTransactionID.Query.Where(this._UpToTransactionByTransactionID.Query.TransactionID == this.TransactionID);
					this._UpToTransactionByTransactionID.Query.Load();
				}	
				return this._UpToTransactionByTransactionID;
			}
			
			set
			{
				this.RemovePreSave("UpToTransactionByTransactionID");
				
				bool changed = this._UpToTransactionByTransactionID != value;

				if(value == null)
				{
					this.TransactionID = null;
					this._UpToTransactionByTransactionID = null;
				}
				else
				{
					this.TransactionID = value.TransactionID;
					this._UpToTransactionByTransactionID = value;
					this.SetPreSave("UpToTransactionByTransactionID", this._UpToTransactionByTransactionID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToTransactionByTransactionID");
				}
			}
		}
		#endregion
		

		
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
			if(!this.es.IsDeleted && this._UpToProductByProductID != null)
			{
				this.ProductID = this._UpToProductByProductID.ProductID;
			}
			if(!this.es.IsDeleted && this._UpToTransactionByTransactionID != null)
			{
				this.TransactionID = this._UpToTransactionByTransactionID.TransactionID;
			}
		}
		
	}
	



	[Serializable]
	public partial class TransactionDetailProductMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected TransactionDetailProductMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(TransactionDetailProductMetadata.ColumnNames.TransactionDetailProductID, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = TransactionDetailProductMetadata.PropertyNames.TransactionDetailProductID;
			c.IsInPrimaryKey = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailProductMetadata.ColumnNames.CompanyID, 1, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = TransactionDetailProductMetadata.PropertyNames.CompanyID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailProductMetadata.ColumnNames.TransactionID, 2, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = TransactionDetailProductMetadata.PropertyNames.TransactionID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailProductMetadata.ColumnNames.ProductID, 3, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = TransactionDetailProductMetadata.PropertyNames.ProductID;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailProductMetadata.ColumnNames.Name, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = TransactionDetailProductMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailProductMetadata.ColumnNames.Description, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = TransactionDetailProductMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 250;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailProductMetadata.ColumnNames.Price, 6, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = TransactionDetailProductMetadata.PropertyNames.Price;
			c.NumericPrecision = 18;
			c.NumericScale = 4;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailProductMetadata.ColumnNames.WholesalePrice, 7, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = TransactionDetailProductMetadata.PropertyNames.WholesalePrice;
			c.NumericPrecision = 18;
			c.NumericScale = 4;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailProductMetadata.ColumnNames.Commission, 8, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = TransactionDetailProductMetadata.PropertyNames.Commission;
			c.NumericPrecision = 18;
			c.NumericScale = 4;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailProductMetadata.ColumnNames.BarCode, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = TransactionDetailProductMetadata.PropertyNames.BarCode;
			c.CharacterMaxLength = 128;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public TransactionDetailProductMetadata Meta()
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
			 public const string TransactionDetailProductID = "TransactionDetailProductID";
			 public const string CompanyID = "CompanyID";
			 public const string TransactionID = "TransactionID";
			 public const string ProductID = "ProductID";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Price = "Price";
			 public const string WholesalePrice = "WholesalePrice";
			 public const string Commission = "Commission";
			 public const string BarCode = "BarCode";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string TransactionDetailProductID = "TransactionDetailProductID";
			 public const string CompanyID = "CompanyID";
			 public const string TransactionID = "TransactionID";
			 public const string ProductID = "ProductID";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Price = "Price";
			 public const string WholesalePrice = "WholesalePrice";
			 public const string Commission = "Commission";
			 public const string BarCode = "BarCode";
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
			lock (typeof(TransactionDetailProductMetadata))
			{
				if(TransactionDetailProductMetadata.mapDelegates == null)
				{
					TransactionDetailProductMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (TransactionDetailProductMetadata.meta == null)
				{
					TransactionDetailProductMetadata.meta = new TransactionDetailProductMetadata();
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


				meta.AddTypeMap("TransactionDetailProductID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("CompanyID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("TransactionID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("ProductID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Price", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("WholesalePrice", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("Commission", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("BarCode", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "TransactionDetailProduct";
				meta.Destination = "TransactionDetailProduct";
				
				meta.spInsert = "proc_TransactionDetailProductInsert";				
				meta.spUpdate = "proc_TransactionDetailProductUpdate";		
				meta.spDelete = "proc_TransactionDetailProductDelete";
				meta.spLoadAll = "proc_TransactionDetailProductLoadAll";
				meta.spLoadByPrimaryKey = "proc_TransactionDetailProductLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private TransactionDetailProductMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
