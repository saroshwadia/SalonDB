
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
	/// Encapsulates the 'SalesView' view
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(SalesView))]	
	[XmlType("SalesView")]
	public partial class SalesView : esSalesView
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new SalesView();
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
	[XmlType("SalesViewCollection")]
	public partial class SalesViewCollection : esSalesViewCollection, IEnumerable<SalesView>
	{

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(SalesView))]
		public class SalesViewCollectionWCFPacket : esCollectionWCFPacket<SalesViewCollection>
		{
			public static implicit operator SalesViewCollection(SalesViewCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator SalesViewCollectionWCFPacket(SalesViewCollection collection)
			{
				return new SalesViewCollectionWCFPacket() { Collection = collection };
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
	public partial class SalesViewQuery : esSalesViewQuery
	{
		public SalesViewQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "SalesViewQuery";
		}
		
		
		override protected string GetConnectionName()
		{
			return "Generated Views";
		}			
	
		#region Explicit Casts
		
		public static explicit operator string(SalesViewQuery query)
		{
			return SalesViewQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator SalesViewQuery(string query)
		{
			return (SalesViewQuery)SalesViewQuery.SerializeHelper.FromXml(query, typeof(SalesViewQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esSalesView : EntityBase
	{
		public esSalesView()
		{

		}
		
		#region LoadByPrimaryKey
		
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to SalesView.TransactionNumber
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? TransactionNumber
		{
			get
			{
				return base.GetSystemInt32(SalesViewMetadata.ColumnNames.TransactionNumber);
			}
			
			set
			{
				if(base.SetSystemInt32(SalesViewMetadata.ColumnNames.TransactionNumber, value))
				{
					OnPropertyChanged(SalesViewMetadata.PropertyNames.TransactionNumber);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SalesView.TransactionDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? TransactionDate
		{
			get
			{
				return base.GetSystemDateTime(SalesViewMetadata.ColumnNames.TransactionDate);
			}
			
			set
			{
				if(base.SetSystemDateTime(SalesViewMetadata.ColumnNames.TransactionDate, value))
				{
					OnPropertyChanged(SalesViewMetadata.PropertyNames.TransactionDate);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SalesView.Name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(SalesViewMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(SalesViewMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(SalesViewMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SalesView.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(SalesViewMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(SalesViewMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(SalesViewMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SalesView.Quantity
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Quantity
		{
			get
			{
				return base.GetSystemInt32(SalesViewMetadata.ColumnNames.Quantity);
			}
			
			set
			{
				if(base.SetSystemInt32(SalesViewMetadata.ColumnNames.Quantity, value))
				{
					OnPropertyChanged(SalesViewMetadata.PropertyNames.Quantity);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SalesView.UnitPrice
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? UnitPrice
		{
			get
			{
				return base.GetSystemDecimal(SalesViewMetadata.ColumnNames.UnitPrice);
			}
			
			set
			{
				if(base.SetSystemDecimal(SalesViewMetadata.ColumnNames.UnitPrice, value))
				{
					OnPropertyChanged(SalesViewMetadata.PropertyNames.UnitPrice);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SalesView.Amount
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Amount
		{
			get
			{
				return base.GetSystemDecimal(SalesViewMetadata.ColumnNames.Amount);
			}
			
			set
			{
				if(base.SetSystemDecimal(SalesViewMetadata.ColumnNames.Amount, value))
				{
					OnPropertyChanged(SalesViewMetadata.PropertyNames.Amount);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SalesView.Tax
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Tax
		{
			get
			{
				return base.GetSystemDecimal(SalesViewMetadata.ColumnNames.Tax);
			}
			
			set
			{
				if(base.SetSystemDecimal(SalesViewMetadata.ColumnNames.Tax, value))
				{
					OnPropertyChanged(SalesViewMetadata.PropertyNames.Tax);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SalesView.TType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String TType
		{
			get
			{
				return base.GetSystemString(SalesViewMetadata.ColumnNames.TType);
			}
			
			set
			{
				if(base.SetSystemString(SalesViewMetadata.ColumnNames.TType, value))
				{
					OnPropertyChanged(SalesViewMetadata.PropertyNames.TType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SalesView.TransactionID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? TransactionID
		{
			get
			{
				return base.GetSystemGuid(SalesViewMetadata.ColumnNames.TransactionID);
			}
			
			set
			{
				if(base.SetSystemGuid(SalesViewMetadata.ColumnNames.TransactionID, value))
				{
					OnPropertyChanged(SalesViewMetadata.PropertyNames.TransactionID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SalesView.CompanyID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CompanyID
		{
			get
			{
				return base.GetSystemGuid(SalesViewMetadata.ColumnNames.CompanyID);
			}
			
			set
			{
				if(base.SetSystemGuid(SalesViewMetadata.ColumnNames.CompanyID, value))
				{
					OnPropertyChanged(SalesViewMetadata.PropertyNames.CompanyID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SalesView.Expr1
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Expr1
		{
			get
			{
				return base.GetSystemInt32(SalesViewMetadata.ColumnNames.Expr1);
			}
			
			set
			{
				if(base.SetSystemInt32(SalesViewMetadata.ColumnNames.Expr1, value))
				{
					OnPropertyChanged(SalesViewMetadata.PropertyNames.Expr1);
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
						case "Tax": this.str().Tax = (string)value; break;							
						case "TType": this.str().TType = (string)value; break;							
						case "TransactionID": this.str().TransactionID = (string)value; break;							
						case "CompanyID": this.str().CompanyID = (string)value; break;							
						case "Expr1": this.str().Expr1 = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "TransactionNumber":
						
							if (value == null || value is System.Int32)
								this.TransactionNumber = (System.Int32?)value;
								OnPropertyChanged(SalesViewMetadata.PropertyNames.TransactionNumber);
							break;
						
						case "TransactionDate":
						
							if (value == null || value is System.DateTime)
								this.TransactionDate = (System.DateTime?)value;
								OnPropertyChanged(SalesViewMetadata.PropertyNames.TransactionDate);
							break;
						
						case "Quantity":
						
							if (value == null || value is System.Int32)
								this.Quantity = (System.Int32?)value;
								OnPropertyChanged(SalesViewMetadata.PropertyNames.Quantity);
							break;
						
						case "UnitPrice":
						
							if (value == null || value is System.Decimal)
								this.UnitPrice = (System.Decimal?)value;
								OnPropertyChanged(SalesViewMetadata.PropertyNames.UnitPrice);
							break;
						
						case "Amount":
						
							if (value == null || value is System.Decimal)
								this.Amount = (System.Decimal?)value;
								OnPropertyChanged(SalesViewMetadata.PropertyNames.Amount);
							break;
						
						case "Tax":
						
							if (value == null || value is System.Decimal)
								this.Tax = (System.Decimal?)value;
								OnPropertyChanged(SalesViewMetadata.PropertyNames.Tax);
							break;
						
						case "TransactionID":
						
							if (value == null || value is System.Guid)
								this.TransactionID = (System.Guid?)value;
								OnPropertyChanged(SalesViewMetadata.PropertyNames.TransactionID);
							break;
						
						case "CompanyID":
						
							if (value == null || value is System.Guid)
								this.CompanyID = (System.Guid?)value;
								OnPropertyChanged(SalesViewMetadata.PropertyNames.CompanyID);
							break;
						
						case "Expr1":
						
							if (value == null || value is System.Int32)
								this.Expr1 = (System.Int32?)value;
								OnPropertyChanged(SalesViewMetadata.PropertyNames.Expr1);
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
			public esStrings(esSalesView entity)
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
				
			public System.String Tax
			{
				get
				{
					System.Decimal? data = entity.Tax;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Tax = null;
					else entity.Tax = Convert.ToDecimal(value);
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
				
			public System.String Expr1
			{
				get
				{
					System.Int32? data = entity.Expr1;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Expr1 = null;
					else entity.Expr1 = Convert.ToInt32(value);
				}
			}
			

			private esSalesView entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return SalesViewMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public SalesViewQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SalesViewQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SalesViewQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(SalesViewQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private SalesViewQuery query;		
	}



	[Serializable]
	abstract public partial class esSalesViewCollection : CollectionBase<SalesView>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return SalesViewMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "SalesViewCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public SalesViewQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SalesViewQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SalesViewQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new SalesViewQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(SalesViewQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((SalesViewQuery)query);
		}

		#endregion
		
		private SalesViewQuery query;
	}



	[Serializable]
	abstract public partial class esSalesViewQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return SalesViewMetadata.Meta();
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
				case "Tax": return this.Tax;
				case "TType": return this.TType;
				case "TransactionID": return this.TransactionID;
				case "CompanyID": return this.CompanyID;
				case "Expr1": return this.Expr1;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem TransactionNumber
		{
			get { return new esQueryItem(this, SalesViewMetadata.ColumnNames.TransactionNumber, esSystemType.Int32); }
		} 
		
		public esQueryItem TransactionDate
		{
			get { return new esQueryItem(this, SalesViewMetadata.ColumnNames.TransactionDate, esSystemType.DateTime); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, SalesViewMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, SalesViewMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem Quantity
		{
			get { return new esQueryItem(this, SalesViewMetadata.ColumnNames.Quantity, esSystemType.Int32); }
		} 
		
		public esQueryItem UnitPrice
		{
			get { return new esQueryItem(this, SalesViewMetadata.ColumnNames.UnitPrice, esSystemType.Decimal); }
		} 
		
		public esQueryItem Amount
		{
			get { return new esQueryItem(this, SalesViewMetadata.ColumnNames.Amount, esSystemType.Decimal); }
		} 
		
		public esQueryItem Tax
		{
			get { return new esQueryItem(this, SalesViewMetadata.ColumnNames.Tax, esSystemType.Decimal); }
		} 
		
		public esQueryItem TType
		{
			get { return new esQueryItem(this, SalesViewMetadata.ColumnNames.TType, esSystemType.String); }
		} 
		
		public esQueryItem TransactionID
		{
			get { return new esQueryItem(this, SalesViewMetadata.ColumnNames.TransactionID, esSystemType.Guid); }
		} 
		
		public esQueryItem CompanyID
		{
			get { return new esQueryItem(this, SalesViewMetadata.ColumnNames.CompanyID, esSystemType.Guid); }
		} 
		
		public esQueryItem Expr1
		{
			get { return new esQueryItem(this, SalesViewMetadata.ColumnNames.Expr1, esSystemType.Int32); }
		} 
		
		#endregion
		
	}



	[Serializable]
	public partial class SalesViewMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected SalesViewMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(SalesViewMetadata.ColumnNames.TransactionNumber, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = SalesViewMetadata.PropertyNames.TransactionNumber;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SalesViewMetadata.ColumnNames.TransactionDate, 1, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = SalesViewMetadata.PropertyNames.TransactionDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SalesViewMetadata.ColumnNames.Name, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = SalesViewMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SalesViewMetadata.ColumnNames.Description, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = SalesViewMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 250;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SalesViewMetadata.ColumnNames.Quantity, 4, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = SalesViewMetadata.PropertyNames.Quantity;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SalesViewMetadata.ColumnNames.UnitPrice, 5, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = SalesViewMetadata.PropertyNames.UnitPrice;
			c.NumericPrecision = 18;
			c.NumericScale = 2;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SalesViewMetadata.ColumnNames.Amount, 6, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = SalesViewMetadata.PropertyNames.Amount;
			c.NumericPrecision = 29;
			c.NumericScale = 2;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SalesViewMetadata.ColumnNames.Tax, 7, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = SalesViewMetadata.PropertyNames.Tax;
			c.NumericPrecision = 18;
			c.NumericScale = 2;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SalesViewMetadata.ColumnNames.TType, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = SalesViewMetadata.PropertyNames.TType;
			c.CharacterMaxLength = 7;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SalesViewMetadata.ColumnNames.TransactionID, 9, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = SalesViewMetadata.PropertyNames.TransactionID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SalesViewMetadata.ColumnNames.CompanyID, 10, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = SalesViewMetadata.PropertyNames.CompanyID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SalesViewMetadata.ColumnNames.Expr1, 11, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = SalesViewMetadata.PropertyNames.Expr1;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public SalesViewMetadata Meta()
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
			 public const string Tax = "Tax";
			 public const string TType = "TType";
			 public const string TransactionID = "TransactionID";
			 public const string CompanyID = "CompanyID";
			 public const string Expr1 = "Expr1";
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
			 public const string Tax = "Tax";
			 public const string TType = "TType";
			 public const string TransactionID = "TransactionID";
			 public const string CompanyID = "CompanyID";
			 public const string Expr1 = "Expr1";
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
			lock (typeof(SalesViewMetadata))
			{
				if(SalesViewMetadata.mapDelegates == null)
				{
					SalesViewMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (SalesViewMetadata.meta == null)
				{
					SalesViewMetadata.meta = new SalesViewMetadata();
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
				meta.AddTypeMap("Tax", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("TType", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("TransactionID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("CompanyID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Expr1", new esTypeMap("int", "System.Int32"));			
				
				
				
				meta.Source = "SalesView";
				meta.Destination = "SalesView";
				
				meta.spInsert = "proc_SalesViewInsert";				
				meta.spUpdate = "proc_SalesViewUpdate";		
				meta.spDelete = "proc_SalesViewDelete";
				meta.spLoadAll = "proc_SalesViewLoadAll";
				meta.spLoadByPrimaryKey = "proc_SalesViewLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private SalesViewMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
