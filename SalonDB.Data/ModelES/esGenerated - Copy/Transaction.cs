
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
	/// Encapsulates the 'Transaction' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Transaction))]	
	[XmlType("Transaction")]
	public partial class Transaction : esTransaction
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Transaction();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid transactionID)
		{
			var obj = new Transaction();
			obj.TransactionID = transactionID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid transactionID, esSqlAccessType sqlAccessType)
		{
			var obj = new Transaction();
			obj.TransactionID = transactionID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("TransactionCollection")]
	public partial class TransactionCollection : esTransactionCollection, IEnumerable<Transaction>
	{
		public Transaction FindByPrimaryKey(System.Guid transactionID)
		{
			return this.SingleOrDefault(e => e.TransactionID == transactionID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Transaction))]
		public class TransactionCollectionWCFPacket : esCollectionWCFPacket<TransactionCollection>
		{
			public static implicit operator TransactionCollection(TransactionCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator TransactionCollectionWCFPacket(TransactionCollection collection)
			{
				return new TransactionCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class TransactionQuery : esTransactionQuery
	{
		public TransactionQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "TransactionQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(TransactionQuery query)
		{
			return TransactionQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator TransactionQuery(string query)
		{
			return (TransactionQuery)TransactionQuery.SerializeHelper.FromXml(query, typeof(TransactionQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esTransaction : EntityBase
	{
		public esTransaction()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid transactionID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(transactionID);
			else
				return LoadByPrimaryKeyStoredProcedure(transactionID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid transactionID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(transactionID);
			else
				return LoadByPrimaryKeyStoredProcedure(transactionID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid transactionID)
		{
			TransactionQuery query = new TransactionQuery();
			query.Where(query.TransactionID == transactionID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid transactionID)
		{
			esParameters parms = new esParameters();
			parms.Add("TransactionID", transactionID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Transaction.TransactionID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? TransactionID
		{
			get
			{
				return base.GetSystemGuid(TransactionMetadata.ColumnNames.TransactionID);
			}
			
			set
			{
				if(base.SetSystemGuid(TransactionMetadata.ColumnNames.TransactionID, value))
				{
					OnPropertyChanged(TransactionMetadata.PropertyNames.TransactionID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Transaction.CompanyID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CompanyID
		{
			get
			{
				return base.GetSystemGuid(TransactionMetadata.ColumnNames.CompanyID);
			}
			
			set
			{
				if(base.SetSystemGuid(TransactionMetadata.ColumnNames.CompanyID, value))
				{
					this._UpToCompanyByCompanyID = null;
					this.OnPropertyChanged("UpToCompanyByCompanyID");
					OnPropertyChanged(TransactionMetadata.PropertyNames.CompanyID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Transaction.AppointmentID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? AppointmentID
		{
			get
			{
				return base.GetSystemGuid(TransactionMetadata.ColumnNames.AppointmentID);
			}
			
			set
			{
				if(base.SetSystemGuid(TransactionMetadata.ColumnNames.AppointmentID, value))
				{
					this._UpToAppointmentByAppointmentID = null;
					this.OnPropertyChanged("UpToAppointmentByAppointmentID");
					OnPropertyChanged(TransactionMetadata.PropertyNames.AppointmentID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Transaction.TransactionDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? TransactionDate
		{
			get
			{
				return base.GetSystemDateTime(TransactionMetadata.ColumnNames.TransactionDate);
			}
			
			set
			{
				if(base.SetSystemDateTime(TransactionMetadata.ColumnNames.TransactionDate, value))
				{
					OnPropertyChanged(TransactionMetadata.PropertyNames.TransactionDate);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Transaction.Amount
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Amount
		{
			get
			{
				return base.GetSystemDecimal(TransactionMetadata.ColumnNames.Amount);
			}
			
			set
			{
				if(base.SetSystemDecimal(TransactionMetadata.ColumnNames.Amount, value))
				{
					OnPropertyChanged(TransactionMetadata.PropertyNames.Amount);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Transaction.Tax
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Tax
		{
			get
			{
				return base.GetSystemDecimal(TransactionMetadata.ColumnNames.Tax);
			}
			
			set
			{
				if(base.SetSystemDecimal(TransactionMetadata.ColumnNames.Tax, value))
				{
					OnPropertyChanged(TransactionMetadata.PropertyNames.Tax);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Transaction.Status
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Status
		{
			get
			{
				return base.GetSystemString(TransactionMetadata.ColumnNames.Status);
			}
			
			set
			{
				if(base.SetSystemString(TransactionMetadata.ColumnNames.Status, value))
				{
					OnPropertyChanged(TransactionMetadata.PropertyNames.Status);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Appointment _UpToAppointmentByAppointmentID;
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
						case "TransactionID": this.str().TransactionID = (string)value; break;							
						case "CompanyID": this.str().CompanyID = (string)value; break;							
						case "AppointmentID": this.str().AppointmentID = (string)value; break;							
						case "TransactionDate": this.str().TransactionDate = (string)value; break;							
						case "Amount": this.str().Amount = (string)value; break;							
						case "Tax": this.str().Tax = (string)value; break;							
						case "Status": this.str().Status = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "TransactionID":
						
							if (value == null || value is System.Guid)
								this.TransactionID = (System.Guid?)value;
								OnPropertyChanged(TransactionMetadata.PropertyNames.TransactionID);
							break;
						
						case "CompanyID":
						
							if (value == null || value is System.Guid)
								this.CompanyID = (System.Guid?)value;
								OnPropertyChanged(TransactionMetadata.PropertyNames.CompanyID);
							break;
						
						case "AppointmentID":
						
							if (value == null || value is System.Guid)
								this.AppointmentID = (System.Guid?)value;
								OnPropertyChanged(TransactionMetadata.PropertyNames.AppointmentID);
							break;
						
						case "TransactionDate":
						
							if (value == null || value is System.DateTime)
								this.TransactionDate = (System.DateTime?)value;
								OnPropertyChanged(TransactionMetadata.PropertyNames.TransactionDate);
							break;
						
						case "Amount":
						
							if (value == null || value is System.Decimal)
								this.Amount = (System.Decimal?)value;
								OnPropertyChanged(TransactionMetadata.PropertyNames.Amount);
							break;
						
						case "Tax":
						
							if (value == null || value is System.Decimal)
								this.Tax = (System.Decimal?)value;
								OnPropertyChanged(TransactionMetadata.PropertyNames.Tax);
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
			public esStrings(esTransaction entity)
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
				
			public System.String AppointmentID
			{
				get
				{
					System.Guid? data = entity.AppointmentID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AppointmentID = null;
					else entity.AppointmentID = new Guid(value);
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
				
			public System.String Status
			{
				get
				{
					System.String data = entity.Status;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Status = null;
					else entity.Status = Convert.ToString(value);
				}
			}
			

			private esTransaction entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return TransactionMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public TransactionQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TransactionQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(TransactionQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(TransactionQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private TransactionQuery query;		
	}



	[Serializable]
	abstract public partial class esTransactionCollection : CollectionBase<Transaction>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return TransactionMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "TransactionCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public TransactionQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TransactionQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(TransactionQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new TransactionQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(TransactionQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((TransactionQuery)query);
		}

		#endregion
		
		private TransactionQuery query;
	}



	[Serializable]
	abstract public partial class esTransactionQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return TransactionMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "TransactionID": return this.TransactionID;
				case "CompanyID": return this.CompanyID;
				case "AppointmentID": return this.AppointmentID;
				case "TransactionDate": return this.TransactionDate;
				case "Amount": return this.Amount;
				case "Tax": return this.Tax;
				case "Status": return this.Status;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem TransactionID
		{
			get { return new esQueryItem(this, TransactionMetadata.ColumnNames.TransactionID, esSystemType.Guid); }
		} 
		
		public esQueryItem CompanyID
		{
			get { return new esQueryItem(this, TransactionMetadata.ColumnNames.CompanyID, esSystemType.Guid); }
		} 
		
		public esQueryItem AppointmentID
		{
			get { return new esQueryItem(this, TransactionMetadata.ColumnNames.AppointmentID, esSystemType.Guid); }
		} 
		
		public esQueryItem TransactionDate
		{
			get { return new esQueryItem(this, TransactionMetadata.ColumnNames.TransactionDate, esSystemType.DateTime); }
		} 
		
		public esQueryItem Amount
		{
			get { return new esQueryItem(this, TransactionMetadata.ColumnNames.Amount, esSystemType.Decimal); }
		} 
		
		public esQueryItem Tax
		{
			get { return new esQueryItem(this, TransactionMetadata.ColumnNames.Tax, esSystemType.Decimal); }
		} 
		
		public esQueryItem Status
		{
			get { return new esQueryItem(this, TransactionMetadata.ColumnNames.Status, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Transaction : esTransaction
	{

		#region TransactionDetailProductCollectionByTransactionID - Zero To Many
		
		static public esPrefetchMap Prefetch_TransactionDetailProductCollectionByTransactionID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Transaction.TransactionDetailProductCollectionByTransactionID_Delegate;
				map.PropertyName = "TransactionDetailProductCollectionByTransactionID";
				map.MyColumnName = "TransactionID";
				map.ParentColumnName = "TransactionID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void TransactionDetailProductCollectionByTransactionID_Delegate(esPrefetchParameters data)
		{
			TransactionQuery parent = new TransactionQuery(data.NextAlias());

			TransactionDetailProductQuery me = data.You != null ? data.You as TransactionDetailProductQuery : new TransactionDetailProductQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.TransactionID == me.TransactionID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_TransactionDetailProduct_Transaction
		/// </summary>

		[XmlIgnore]
		public TransactionDetailProductCollection TransactionDetailProductCollectionByTransactionID
		{
			get
			{
				if(this._TransactionDetailProductCollectionByTransactionID == null)
				{
					this._TransactionDetailProductCollectionByTransactionID = new TransactionDetailProductCollection();
					this._TransactionDetailProductCollectionByTransactionID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("TransactionDetailProductCollectionByTransactionID", this._TransactionDetailProductCollectionByTransactionID);
				
					if (this.TransactionID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._TransactionDetailProductCollectionByTransactionID.Query.Where(this._TransactionDetailProductCollectionByTransactionID.Query.TransactionID == this.TransactionID);
							this._TransactionDetailProductCollectionByTransactionID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._TransactionDetailProductCollectionByTransactionID.fks.Add(TransactionDetailProductMetadata.ColumnNames.TransactionID, this.TransactionID);
					}
				}

				return this._TransactionDetailProductCollectionByTransactionID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._TransactionDetailProductCollectionByTransactionID != null) 
				{ 
					this.RemovePostSave("TransactionDetailProductCollectionByTransactionID"); 
					this._TransactionDetailProductCollectionByTransactionID = null;
					this.OnPropertyChanged("TransactionDetailProductCollectionByTransactionID");
				} 
			} 			
		}
			
		
		private TransactionDetailProductCollection _TransactionDetailProductCollectionByTransactionID;
		#endregion

		#region TransactionDetailServiceCollectionByTransactionID - Zero To Many
		
		static public esPrefetchMap Prefetch_TransactionDetailServiceCollectionByTransactionID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Transaction.TransactionDetailServiceCollectionByTransactionID_Delegate;
				map.PropertyName = "TransactionDetailServiceCollectionByTransactionID";
				map.MyColumnName = "TransactionID";
				map.ParentColumnName = "TransactionID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void TransactionDetailServiceCollectionByTransactionID_Delegate(esPrefetchParameters data)
		{
			TransactionQuery parent = new TransactionQuery(data.NextAlias());

			TransactionDetailServiceQuery me = data.You != null ? data.You as TransactionDetailServiceQuery : new TransactionDetailServiceQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.TransactionID == me.TransactionID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_TransactionDetailService_Transaction
		/// </summary>

		[XmlIgnore]
		public TransactionDetailServiceCollection TransactionDetailServiceCollectionByTransactionID
		{
			get
			{
				if(this._TransactionDetailServiceCollectionByTransactionID == null)
				{
					this._TransactionDetailServiceCollectionByTransactionID = new TransactionDetailServiceCollection();
					this._TransactionDetailServiceCollectionByTransactionID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("TransactionDetailServiceCollectionByTransactionID", this._TransactionDetailServiceCollectionByTransactionID);
				
					if (this.TransactionID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._TransactionDetailServiceCollectionByTransactionID.Query.Where(this._TransactionDetailServiceCollectionByTransactionID.Query.TransactionID == this.TransactionID);
							this._TransactionDetailServiceCollectionByTransactionID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._TransactionDetailServiceCollectionByTransactionID.fks.Add(TransactionDetailServiceMetadata.ColumnNames.TransactionID, this.TransactionID);
					}
				}

				return this._TransactionDetailServiceCollectionByTransactionID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._TransactionDetailServiceCollectionByTransactionID != null) 
				{ 
					this.RemovePostSave("TransactionDetailServiceCollectionByTransactionID"); 
					this._TransactionDetailServiceCollectionByTransactionID = null;
					this.OnPropertyChanged("TransactionDetailServiceCollectionByTransactionID");
				} 
			} 			
		}
			
		
		private TransactionDetailServiceCollection _TransactionDetailServiceCollectionByTransactionID;
		#endregion

				
		#region UpToAppointmentByAppointmentID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Transaction_Appointment
		/// </summary>

		[XmlIgnore]
					
		public Appointment UpToAppointmentByAppointmentID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToAppointmentByAppointmentID == null && AppointmentID != null)
				{
					this._UpToAppointmentByAppointmentID = new Appointment();
					this._UpToAppointmentByAppointmentID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToAppointmentByAppointmentID", this._UpToAppointmentByAppointmentID);
					this._UpToAppointmentByAppointmentID.Query.Where(this._UpToAppointmentByAppointmentID.Query.AppointmentID == this.AppointmentID);
					this._UpToAppointmentByAppointmentID.Query.Load();
				}	
				return this._UpToAppointmentByAppointmentID;
			}
			
			set
			{
				this.RemovePreSave("UpToAppointmentByAppointmentID");
				
				bool changed = this._UpToAppointmentByAppointmentID != value;

				if(value == null)
				{
					this.AppointmentID = null;
					this._UpToAppointmentByAppointmentID = null;
				}
				else
				{
					this.AppointmentID = value.AppointmentID;
					this._UpToAppointmentByAppointmentID = value;
					this.SetPreSave("UpToAppointmentByAppointmentID", this._UpToAppointmentByAppointmentID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToAppointmentByAppointmentID");
				}
			}
		}
		#endregion
		

				
		#region UpToCompanyByCompanyID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Transaction_Company
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
				case "TransactionDetailProductCollectionByTransactionID":
					coll = this.TransactionDetailProductCollectionByTransactionID;
					break;
				case "TransactionDetailServiceCollectionByTransactionID":
					coll = this.TransactionDetailServiceCollectionByTransactionID;
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
			
			props.Add(new esPropertyDescriptor(this, "TransactionDetailProductCollectionByTransactionID", typeof(TransactionDetailProductCollection), new TransactionDetailProduct()));
			props.Add(new esPropertyDescriptor(this, "TransactionDetailServiceCollectionByTransactionID", typeof(TransactionDetailServiceCollection), new TransactionDetailService()));
		
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToAppointmentByAppointmentID != null)
			{
				this.AppointmentID = this._UpToAppointmentByAppointmentID.AppointmentID;
			}
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
			if(this._TransactionDetailProductCollectionByTransactionID != null)
			{
				Apply(this._TransactionDetailProductCollectionByTransactionID, "TransactionID", this.TransactionID);
			}
			if(this._TransactionDetailServiceCollectionByTransactionID != null)
			{
				Apply(this._TransactionDetailServiceCollectionByTransactionID, "TransactionID", this.TransactionID);
			}
		}
		
	}
	



	[Serializable]
	public partial class TransactionMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected TransactionMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(TransactionMetadata.ColumnNames.TransactionID, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = TransactionMetadata.PropertyNames.TransactionID;
			c.IsInPrimaryKey = true;
			c.HasDefault = true;
			c.Default = @"(newid())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionMetadata.ColumnNames.CompanyID, 1, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = TransactionMetadata.PropertyNames.CompanyID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionMetadata.ColumnNames.AppointmentID, 2, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = TransactionMetadata.PropertyNames.AppointmentID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionMetadata.ColumnNames.TransactionDate, 3, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = TransactionMetadata.PropertyNames.TransactionDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionMetadata.ColumnNames.Amount, 4, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = TransactionMetadata.PropertyNames.Amount;
			c.NumericPrecision = 18;
			c.NumericScale = 4;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionMetadata.ColumnNames.Tax, 5, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = TransactionMetadata.PropertyNames.Tax;
			c.NumericPrecision = 18;
			c.NumericScale = 4;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionMetadata.ColumnNames.Status, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = TransactionMetadata.PropertyNames.Status;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public TransactionMetadata Meta()
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
			 public const string CompanyID = "CompanyID";
			 public const string AppointmentID = "AppointmentID";
			 public const string TransactionDate = "TransactionDate";
			 public const string Amount = "Amount";
			 public const string Tax = "Tax";
			 public const string Status = "Status";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string TransactionID = "TransactionID";
			 public const string CompanyID = "CompanyID";
			 public const string AppointmentID = "AppointmentID";
			 public const string TransactionDate = "TransactionDate";
			 public const string Amount = "Amount";
			 public const string Tax = "Tax";
			 public const string Status = "Status";
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
			lock (typeof(TransactionMetadata))
			{
				if(TransactionMetadata.mapDelegates == null)
				{
					TransactionMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (TransactionMetadata.meta == null)
				{
					TransactionMetadata.meta = new TransactionMetadata();
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
				meta.AddTypeMap("CompanyID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("AppointmentID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("TransactionDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("Amount", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("Tax", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("Status", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "Transaction";
				meta.Destination = "Transaction";
				
				meta.spInsert = "proc_TransactionInsert";				
				meta.spUpdate = "proc_TransactionUpdate";		
				meta.spDelete = "proc_TransactionDelete";
				meta.spLoadAll = "proc_TransactionLoadAll";
				meta.spLoadByPrimaryKey = "proc_TransactionLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private TransactionMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
