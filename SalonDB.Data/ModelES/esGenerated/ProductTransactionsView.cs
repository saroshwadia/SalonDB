
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 2017-02-20 4:43:21 PM
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
	/// Encapsulates the 'ProductTransactionsView' view
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(ProductTransactionsView))]	
	[XmlType("ProductTransactionsView")]
	public partial class ProductTransactionsView : esProductTransactionsView
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new ProductTransactionsView();
		}
		
		#region Static Quick Access Methods
		
		#endregion

		
		
		override protected string GetConnectionName()
		{
			return "Generated Views";
		}			
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("ProductTransactionsViewCollection")]
	public partial class ProductTransactionsViewCollection : esProductTransactionsViewCollection, IEnumerable<ProductTransactionsView>
	{

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(ProductTransactionsView))]
		public class ProductTransactionsViewCollectionWCFPacket : esCollectionWCFPacket<ProductTransactionsViewCollection>
		{
			public static implicit operator ProductTransactionsViewCollection(ProductTransactionsViewCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator ProductTransactionsViewCollectionWCFPacket(ProductTransactionsViewCollection collection)
			{
				return new ProductTransactionsViewCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
		
		override protected string GetConnectionName()
		{
			return "Generated Views";
		}		
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class ProductTransactionsViewQuery : esProductTransactionsViewQuery
	{
		public ProductTransactionsViewQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "ProductTransactionsViewQuery";
		}
		
		
		override protected string GetConnectionName()
		{
			return "Generated Views";
		}			
	
		#region Explicit Casts
		
		public static explicit operator string(ProductTransactionsViewQuery query)
		{
			return ProductTransactionsViewQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ProductTransactionsViewQuery(string query)
		{
			return (ProductTransactionsViewQuery)ProductTransactionsViewQuery.SerializeHelper.FromXml(query, typeof(ProductTransactionsViewQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esProductTransactionsView : EntityBase
	{
		public esProductTransactionsView()
		{

		}
		
		#region LoadByPrimaryKey
		
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to ProductTransactionsView.TransactionNumber
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? TransactionNumber
		{
			get
			{
				return base.GetSystemInt32(ProductTransactionsViewMetadata.ColumnNames.TransactionNumber);
			}
			
			set
			{
				if(base.SetSystemInt32(ProductTransactionsViewMetadata.ColumnNames.TransactionNumber, value))
				{
					OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.TransactionNumber);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ProductTransactionsView.TransactionDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? TransactionDate
		{
			get
			{
				return base.GetSystemDateTime(ProductTransactionsViewMetadata.ColumnNames.TransactionDate);
			}
			
			set
			{
				if(base.SetSystemDateTime(ProductTransactionsViewMetadata.ColumnNames.TransactionDate, value))
				{
					OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.TransactionDate);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ProductTransactionsView.Name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(ProductTransactionsViewMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(ProductTransactionsViewMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ProductTransactionsView.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(ProductTransactionsViewMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(ProductTransactionsViewMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ProductTransactionsView.Quantity
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Quantity
		{
			get
			{
				return base.GetSystemInt32(ProductTransactionsViewMetadata.ColumnNames.Quantity);
			}
			
			set
			{
				if(base.SetSystemInt32(ProductTransactionsViewMetadata.ColumnNames.Quantity, value))
				{
					OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.Quantity);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ProductTransactionsView.UnitPrice
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? UnitPrice
		{
			get
			{
				return base.GetSystemDecimal(ProductTransactionsViewMetadata.ColumnNames.UnitPrice);
			}
			
			set
			{
				if(base.SetSystemDecimal(ProductTransactionsViewMetadata.ColumnNames.UnitPrice, value))
				{
					OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.UnitPrice);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ProductTransactionsView.Amount
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Amount
		{
			get
			{
				return base.GetSystemDecimal(ProductTransactionsViewMetadata.ColumnNames.Amount);
			}
			
			set
			{
				if(base.SetSystemDecimal(ProductTransactionsViewMetadata.ColumnNames.Amount, value))
				{
					OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.Amount);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ProductTransactionsView.TaxPercent
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? TaxPercent
		{
			get
			{
				return base.GetSystemDecimal(ProductTransactionsViewMetadata.ColumnNames.TaxPercent);
			}
			
			set
			{
				if(base.SetSystemDecimal(ProductTransactionsViewMetadata.ColumnNames.TaxPercent, value))
				{
					OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.TaxPercent);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ProductTransactionsView.TType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String TType
		{
			get
			{
				return base.GetSystemString(ProductTransactionsViewMetadata.ColumnNames.TType);
			}
			
			set
			{
				if(base.SetSystemString(ProductTransactionsViewMetadata.ColumnNames.TType, value))
				{
					OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.TType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ProductTransactionsView.TransactionID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? TransactionID
		{
			get
			{
				return base.GetSystemGuid(ProductTransactionsViewMetadata.ColumnNames.TransactionID);
			}
			
			set
			{
				if(base.SetSystemGuid(ProductTransactionsViewMetadata.ColumnNames.TransactionID, value))
				{
					OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.TransactionID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ProductTransactionsView.CompanyID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CompanyID
		{
			get
			{
				return base.GetSystemGuid(ProductTransactionsViewMetadata.ColumnNames.CompanyID);
			}
			
			set
			{
				if(base.SetSystemGuid(ProductTransactionsViewMetadata.ColumnNames.CompanyID, value))
				{
					OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.CompanyID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ProductTransactionsView.Month
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Month
		{
			get
			{
				return base.GetSystemInt32(ProductTransactionsViewMetadata.ColumnNames.Month);
			}
			
			set
			{
				if(base.SetSystemInt32(ProductTransactionsViewMetadata.ColumnNames.Month, value))
				{
					OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.Month);
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
						case "TransactionNumber": this.str().TransactionNumber = (string)value; break;							
						case "TransactionDate": this.str().TransactionDate = (string)value; break;							
						case "Name": this.str().Name = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;							
						case "Quantity": this.str().Quantity = (string)value; break;							
						case "UnitPrice": this.str().UnitPrice = (string)value; break;							
						case "Amount": this.str().Amount = (string)value; break;							
						case "TaxPercent": this.str().TaxPercent = (string)value; break;							
						case "TType": this.str().TType = (string)value; break;							
						case "TransactionID": this.str().TransactionID = (string)value; break;							
						case "CompanyID": this.str().CompanyID = (string)value; break;							
						case "Month": this.str().Month = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "TransactionNumber":
						
							if (value == null || value is System.Int32)
								this.TransactionNumber = (System.Int32?)value;
								OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.TransactionNumber);
							break;
						
						case "TransactionDate":
						
							if (value == null || value is System.DateTime)
								this.TransactionDate = (System.DateTime?)value;
								OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.TransactionDate);
							break;
						
						case "Quantity":
						
							if (value == null || value is System.Int32)
								this.Quantity = (System.Int32?)value;
								OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.Quantity);
							break;
						
						case "UnitPrice":
						
							if (value == null || value is System.Decimal)
								this.UnitPrice = (System.Decimal?)value;
								OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.UnitPrice);
							break;
						
						case "Amount":
						
							if (value == null || value is System.Decimal)
								this.Amount = (System.Decimal?)value;
								OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.Amount);
							break;
						
						case "TaxPercent":
						
							if (value == null || value is System.Decimal)
								this.TaxPercent = (System.Decimal?)value;
								OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.TaxPercent);
							break;
						
						case "TransactionID":
						
							if (value == null || value is System.Guid)
								this.TransactionID = (System.Guid?)value;
								OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.TransactionID);
							break;
						
						case "CompanyID":
						
							if (value == null || value is System.Guid)
								this.CompanyID = (System.Guid?)value;
								OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.CompanyID);
							break;
						
						case "Month":
						
							if (value == null || value is System.Int32)
								this.Month = (System.Int32?)value;
								OnPropertyChanged(ProductTransactionsViewMetadata.PropertyNames.Month);
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
			public esStrings(esProductTransactionsView entity)
			{
				this.entity = entity;
			}
			
	
			public System.String TransactionNumber
			{
				get
				{
					System.Int32? data = entity.TransactionNumber;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TransactionNumber = null;
					else entity.TransactionNumber = Convert.ToInt32(value);
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
				
			public System.String Quantity
			{
				get
				{
					System.Int32? data = entity.Quantity;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Quantity = null;
					else entity.Quantity = Convert.ToInt32(value);
				}
			}
				
			public System.String UnitPrice
			{
				get
				{
					System.Decimal? data = entity.UnitPrice;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UnitPrice = null;
					else entity.UnitPrice = Convert.ToDecimal(value);
				}
			}
				
			public System.String Amount
			{
				get
				{
					System.Decimal? data = entity.Amount;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Amount = null;
					else entity.Amount = Convert.ToDecimal(value);
				}
			}
				
			public System.String TaxPercent
			{
				get
				{
					System.Decimal? data = entity.TaxPercent;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TaxPercent = null;
					else entity.TaxPercent = Convert.ToDecimal(value);
				}
			}
				
			public System.String TType
			{
				get
				{
					System.String data = entity.TType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TType = null;
					else entity.TType = Convert.ToString(value);
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
				
			public System.String Month
			{
				get
				{
					System.Int32? data = entity.Month;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Month = null;
					else entity.Month = Convert.ToInt32(value);
				}
			}
			

			private esProductTransactionsView entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return ProductTransactionsViewMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public ProductTransactionsViewQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ProductTransactionsViewQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ProductTransactionsViewQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(ProductTransactionsViewQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private ProductTransactionsViewQuery query;		
	}



	[Serializable]
	abstract public partial class esProductTransactionsViewCollection : CollectionBase<ProductTransactionsView>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ProductTransactionsViewMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "ProductTransactionsViewCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public ProductTransactionsViewQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ProductTransactionsViewQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ProductTransactionsViewQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ProductTransactionsViewQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(ProductTransactionsViewQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((ProductTransactionsViewQuery)query);
		}

		#endregion
		
		private ProductTransactionsViewQuery query;
	}



	[Serializable]
	abstract public partial class esProductTransactionsViewQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return ProductTransactionsViewMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "TransactionNumber": return this.TransactionNumber;
				case "TransactionDate": return this.TransactionDate;
				case "Name": return this.Name;
				case "Description": return this.Description;
				case "Quantity": return this.Quantity;
				case "UnitPrice": return this.UnitPrice;
				case "Amount": return this.Amount;
				case "TaxPercent": return this.TaxPercent;
				case "TType": return this.TType;
				case "TransactionID": return this.TransactionID;
				case "CompanyID": return this.CompanyID;
				case "Month": return this.Month;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem TransactionNumber
		{
			get { return new esQueryItem(this, ProductTransactionsViewMetadata.ColumnNames.TransactionNumber, esSystemType.Int32); }
		} 
		
		public esQueryItem TransactionDate
		{
			get { return new esQueryItem(this, ProductTransactionsViewMetadata.ColumnNames.TransactionDate, esSystemType.DateTime); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, ProductTransactionsViewMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, ProductTransactionsViewMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem Quantity
		{
			get { return new esQueryItem(this, ProductTransactionsViewMetadata.ColumnNames.Quantity, esSystemType.Int32); }
		} 
		
		public esQueryItem UnitPrice
		{
			get { return new esQueryItem(this, ProductTransactionsViewMetadata.ColumnNames.UnitPrice, esSystemType.Decimal); }
		} 
		
		public esQueryItem Amount
		{
			get { return new esQueryItem(this, ProductTransactionsViewMetadata.ColumnNames.Amount, esSystemType.Decimal); }
		} 
		
		public esQueryItem TaxPercent
		{
			get { return new esQueryItem(this, ProductTransactionsViewMetadata.ColumnNames.TaxPercent, esSystemType.Decimal); }
		} 
		
		public esQueryItem TType
		{
			get { return new esQueryItem(this, ProductTransactionsViewMetadata.ColumnNames.TType, esSystemType.String); }
		} 
		
		public esQueryItem TransactionID
		{
			get { return new esQueryItem(this, ProductTransactionsViewMetadata.ColumnNames.TransactionID, esSystemType.Guid); }
		} 
		
		public esQueryItem CompanyID
		{
			get { return new esQueryItem(this, ProductTransactionsViewMetadata.ColumnNames.CompanyID, esSystemType.Guid); }
		} 
		
		public esQueryItem Month
		{
			get { return new esQueryItem(this, ProductTransactionsViewMetadata.ColumnNames.Month, esSystemType.Int32); }
		} 
		
		#endregion
		
	}



	[Serializable]
	public partial class ProductTransactionsViewMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ProductTransactionsViewMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ProductTransactionsViewMetadata.ColumnNames.TransactionNumber, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ProductTransactionsViewMetadata.PropertyNames.TransactionNumber;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductTransactionsViewMetadata.ColumnNames.TransactionDate, 1, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = ProductTransactionsViewMetadata.PropertyNames.TransactionDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductTransactionsViewMetadata.ColumnNames.Name, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = ProductTransactionsViewMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductTransactionsViewMetadata.ColumnNames.Description, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = ProductTransactionsViewMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 250;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductTransactionsViewMetadata.ColumnNames.Quantity, 4, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ProductTransactionsViewMetadata.PropertyNames.Quantity;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductTransactionsViewMetadata.ColumnNames.UnitPrice, 5, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = ProductTransactionsViewMetadata.PropertyNames.UnitPrice;
			c.NumericPrecision = 18;
			c.NumericScale = 2;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductTransactionsViewMetadata.ColumnNames.Amount, 6, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = ProductTransactionsViewMetadata.PropertyNames.Amount;
			c.NumericPrecision = 29;
			c.NumericScale = 2;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductTransactionsViewMetadata.ColumnNames.TaxPercent, 7, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = ProductTransactionsViewMetadata.PropertyNames.TaxPercent;
			c.NumericPrecision = 18;
			c.NumericScale = 2;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductTransactionsViewMetadata.ColumnNames.TType, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = ProductTransactionsViewMetadata.PropertyNames.TType;
			c.CharacterMaxLength = 7;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductTransactionsViewMetadata.ColumnNames.TransactionID, 9, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = ProductTransactionsViewMetadata.PropertyNames.TransactionID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductTransactionsViewMetadata.ColumnNames.CompanyID, 10, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = ProductTransactionsViewMetadata.PropertyNames.CompanyID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductTransactionsViewMetadata.ColumnNames.Month, 11, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ProductTransactionsViewMetadata.PropertyNames.Month;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public ProductTransactionsViewMetadata Meta()
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
			 public const string TransactionNumber = "TransactionNumber";
			 public const string TransactionDate = "TransactionDate";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Quantity = "Quantity";
			 public const string UnitPrice = "UnitPrice";
			 public const string Amount = "Amount";
			 public const string TaxPercent = "TaxPercent";
			 public const string TType = "TType";
			 public const string TransactionID = "TransactionID";
			 public const string CompanyID = "CompanyID";
			 public const string Month = "Month";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string TransactionNumber = "TransactionNumber";
			 public const string TransactionDate = "TransactionDate";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Quantity = "Quantity";
			 public const string UnitPrice = "UnitPrice";
			 public const string Amount = "Amount";
			 public const string TaxPercent = "TaxPercent";
			 public const string TType = "TType";
			 public const string TransactionID = "TransactionID";
			 public const string CompanyID = "CompanyID";
			 public const string Month = "Month";
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
			lock (typeof(ProductTransactionsViewMetadata))
			{
				if(ProductTransactionsViewMetadata.mapDelegates == null)
				{
					ProductTransactionsViewMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ProductTransactionsViewMetadata.meta == null)
				{
					ProductTransactionsViewMetadata.meta = new ProductTransactionsViewMetadata();
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


				meta.AddTypeMap("TransactionNumber", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("TransactionDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Quantity", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("Amount", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("TaxPercent", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("TType", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("TransactionID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("CompanyID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Month", new esTypeMap("int", "System.Int32"));			
				
				
				
				meta.Source = "ProductTransactionsView";
				meta.Destination = "ProductTransactionsView";
				
				meta.spInsert = "proc_ProductTransactionsViewInsert";				
				meta.spUpdate = "proc_ProductTransactionsViewUpdate";		
				meta.spDelete = "proc_ProductTransactionsViewDelete";
				meta.spLoadAll = "proc_ProductTransactionsViewLoadAll";
				meta.spLoadByPrimaryKey = "proc_ProductTransactionsViewLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ProductTransactionsViewMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
