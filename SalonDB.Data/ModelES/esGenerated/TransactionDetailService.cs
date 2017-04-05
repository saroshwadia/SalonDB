
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
	/// Encapsulates the 'TransactionDetailService' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(TransactionDetailService))]	
	[XmlType("TransactionDetailService")]
	public partial class TransactionDetailService : esTransactionDetailService
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new TransactionDetailService();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid transactionDetailServiceID)
		{
			var obj = new TransactionDetailService();
			obj.TransactionDetailServiceID = transactionDetailServiceID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid transactionDetailServiceID, esSqlAccessType sqlAccessType)
		{
			var obj = new TransactionDetailService();
			obj.TransactionDetailServiceID = transactionDetailServiceID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("TransactionDetailServiceCollection")]
	public partial class TransactionDetailServiceCollection : esTransactionDetailServiceCollection, IEnumerable<TransactionDetailService>
	{
		public TransactionDetailService FindByPrimaryKey(System.Guid transactionDetailServiceID)
		{
			return this.SingleOrDefault(e => e.TransactionDetailServiceID == transactionDetailServiceID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(TransactionDetailService))]
		public class TransactionDetailServiceCollectionWCFPacket : esCollectionWCFPacket<TransactionDetailServiceCollection>
		{
			public static implicit operator TransactionDetailServiceCollection(TransactionDetailServiceCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator TransactionDetailServiceCollectionWCFPacket(TransactionDetailServiceCollection collection)
			{
				return new TransactionDetailServiceCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class TransactionDetailServiceQuery : esTransactionDetailServiceQuery
	{
		public TransactionDetailServiceQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "TransactionDetailServiceQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(TransactionDetailServiceQuery query)
		{
			return TransactionDetailServiceQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator TransactionDetailServiceQuery(string query)
		{
			return (TransactionDetailServiceQuery)TransactionDetailServiceQuery.SerializeHelper.FromXml(query, typeof(TransactionDetailServiceQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esTransactionDetailService : EntityBase
	{
		public esTransactionDetailService()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid transactionDetailServiceID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(transactionDetailServiceID);
			else
				return LoadByPrimaryKeyStoredProcedure(transactionDetailServiceID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid transactionDetailServiceID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(transactionDetailServiceID);
			else
				return LoadByPrimaryKeyStoredProcedure(transactionDetailServiceID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid transactionDetailServiceID)
		{
			TransactionDetailServiceQuery query = new TransactionDetailServiceQuery();
			query.Where(query.TransactionDetailServiceID == transactionDetailServiceID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid transactionDetailServiceID)
		{
			esParameters parms = new esParameters();
			parms.Add("TransactionDetailServiceID", transactionDetailServiceID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to TransactionDetailService.TransactionDetailServiceID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? TransactionDetailServiceID
		{
			get
			{
				return base.GetSystemGuid(TransactionDetailServiceMetadata.ColumnNames.TransactionDetailServiceID);
			}
			
			set
			{
				if(base.SetSystemGuid(TransactionDetailServiceMetadata.ColumnNames.TransactionDetailServiceID, value))
				{
					OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.TransactionDetailServiceID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailService.TransactionID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? TransactionID
		{
			get
			{
				return base.GetSystemGuid(TransactionDetailServiceMetadata.ColumnNames.TransactionID);
			}
			
			set
			{
				if(base.SetSystemGuid(TransactionDetailServiceMetadata.ColumnNames.TransactionID, value))
				{
					this._UpToTransactionByTransactionID = null;
					this.OnPropertyChanged("UpToTransactionByTransactionID");
					OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.TransactionID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailService.ServiceID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? ServiceID
		{
			get
			{
				return base.GetSystemGuid(TransactionDetailServiceMetadata.ColumnNames.ServiceID);
			}
			
			set
			{
				if(base.SetSystemGuid(TransactionDetailServiceMetadata.ColumnNames.ServiceID, value))
				{
					this._UpToServiceByServiceID = null;
					this.OnPropertyChanged("UpToServiceByServiceID");
					OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.ServiceID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailService.Name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(TransactionDetailServiceMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(TransactionDetailServiceMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailService.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(TransactionDetailServiceMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(TransactionDetailServiceMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailService.Quantity
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Quantity
		{
			get
			{
				return base.GetSystemInt32(TransactionDetailServiceMetadata.ColumnNames.Quantity);
			}
			
			set
			{
				if(base.SetSystemInt32(TransactionDetailServiceMetadata.ColumnNames.Quantity, value))
				{
					OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.Quantity);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailService.UnitPrice
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? UnitPrice
		{
			get
			{
				return base.GetSystemDecimal(TransactionDetailServiceMetadata.ColumnNames.UnitPrice);
			}
			
			set
			{
				if(base.SetSystemDecimal(TransactionDetailServiceMetadata.ColumnNames.UnitPrice, value))
				{
					OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.UnitPrice);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailService.DiscountPercent
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? DiscountPercent
		{
			get
			{
				return base.GetSystemDecimal(TransactionDetailServiceMetadata.ColumnNames.DiscountPercent);
			}
			
			set
			{
				if(base.SetSystemDecimal(TransactionDetailServiceMetadata.ColumnNames.DiscountPercent, value))
				{
					OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.DiscountPercent);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailService.Duration
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Duration
		{
			get
			{
				return base.GetSystemInt32(TransactionDetailServiceMetadata.ColumnNames.Duration);
			}
			
			set
			{
				if(base.SetSystemInt32(TransactionDetailServiceMetadata.ColumnNames.Duration, value))
				{
					OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.Duration);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailService.ShowOnline
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Boolean? ShowOnline
		{
			get
			{
				return base.GetSystemBoolean(TransactionDetailServiceMetadata.ColumnNames.ShowOnline);
			}
			
			set
			{
				if(base.SetSystemBoolean(TransactionDetailServiceMetadata.ColumnNames.ShowOnline, value))
				{
					OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.ShowOnline);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TransactionDetailService.Sequence
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Sequence
		{
			get
			{
				return base.GetSystemInt32(TransactionDetailServiceMetadata.ColumnNames.Sequence);
			}
			
			set
			{
				if(base.SetSystemInt32(TransactionDetailServiceMetadata.ColumnNames.Sequence, value))
				{
					OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.Sequence);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Service _UpToServiceByServiceID;
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
						case "TransactionDetailServiceID": this.str().TransactionDetailServiceID = (string)value; break;							
						case "TransactionID": this.str().TransactionID = (string)value; break;							
						case "ServiceID": this.str().ServiceID = (string)value; break;							
						case "Name": this.str().Name = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;							
						case "Quantity": this.str().Quantity = (string)value; break;							
						case "UnitPrice": this.str().UnitPrice = (string)value; break;							
						case "DiscountPercent": this.str().DiscountPercent = (string)value; break;							
						case "Duration": this.str().Duration = (string)value; break;							
						case "ShowOnline": this.str().ShowOnline = (string)value; break;							
						case "Sequence": this.str().Sequence = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "TransactionDetailServiceID":
						
							if (value == null || value is System.Guid)
								this.TransactionDetailServiceID = (System.Guid?)value;
								OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.TransactionDetailServiceID);
							break;
						
						case "TransactionID":
						
							if (value == null || value is System.Guid)
								this.TransactionID = (System.Guid?)value;
								OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.TransactionID);
							break;
						
						case "ServiceID":
						
							if (value == null || value is System.Guid)
								this.ServiceID = (System.Guid?)value;
								OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.ServiceID);
							break;
						
						case "Quantity":
						
							if (value == null || value is System.Int32)
								this.Quantity = (System.Int32?)value;
								OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.Quantity);
							break;
						
						case "UnitPrice":
						
							if (value == null || value is System.Decimal)
								this.UnitPrice = (System.Decimal?)value;
								OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.UnitPrice);
							break;
						
						case "DiscountPercent":
						
							if (value == null || value is System.Decimal)
								this.DiscountPercent = (System.Decimal?)value;
								OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.DiscountPercent);
							break;
						
						case "Duration":
						
							if (value == null || value is System.Int32)
								this.Duration = (System.Int32?)value;
								OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.Duration);
							break;
						
						case "ShowOnline":
						
							if (value == null || value is System.Boolean)
								this.ShowOnline = (System.Boolean?)value;
								OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.ShowOnline);
							break;
						
						case "Sequence":
						
							if (value == null || value is System.Int32)
								this.Sequence = (System.Int32?)value;
								OnPropertyChanged(TransactionDetailServiceMetadata.PropertyNames.Sequence);
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
			public esStrings(esTransactionDetailService entity)
			{
				this.entity = entity;
			}
			
	
			public System.String TransactionDetailServiceID
			{
				get
				{
					System.Guid? data = entity.TransactionDetailServiceID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TransactionDetailServiceID = null;
					else entity.TransactionDetailServiceID = new Guid(value);
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
				
			public System.String ServiceID
			{
				get
				{
					System.Guid? data = entity.ServiceID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ServiceID = null;
					else entity.ServiceID = new Guid(value);
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
				
			public System.String DiscountPercent
			{
				get
				{
					System.Decimal? data = entity.DiscountPercent;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DiscountPercent = null;
					else entity.DiscountPercent = Convert.ToDecimal(value);
				}
			}
				
			public System.String Duration
			{
				get
				{
					System.Int32? data = entity.Duration;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Duration = null;
					else entity.Duration = Convert.ToInt32(value);
				}
			}
				
			public System.String ShowOnline
			{
				get
				{
					System.Boolean? data = entity.ShowOnline;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ShowOnline = null;
					else entity.ShowOnline = Convert.ToBoolean(value);
				}
			}
				
			public System.String Sequence
			{
				get
				{
					System.Int32? data = entity.Sequence;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Sequence = null;
					else entity.Sequence = Convert.ToInt32(value);
				}
			}
			

			private esTransactionDetailService entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return TransactionDetailServiceMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public TransactionDetailServiceQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TransactionDetailServiceQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(TransactionDetailServiceQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(TransactionDetailServiceQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private TransactionDetailServiceQuery query;		
	}



	[Serializable]
	abstract public partial class esTransactionDetailServiceCollection : CollectionBase<TransactionDetailService>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return TransactionDetailServiceMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "TransactionDetailServiceCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public TransactionDetailServiceQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TransactionDetailServiceQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(TransactionDetailServiceQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new TransactionDetailServiceQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(TransactionDetailServiceQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((TransactionDetailServiceQuery)query);
		}

		#endregion
		
		private TransactionDetailServiceQuery query;
	}



	[Serializable]
	abstract public partial class esTransactionDetailServiceQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return TransactionDetailServiceMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "TransactionDetailServiceID": return this.TransactionDetailServiceID;
				case "TransactionID": return this.TransactionID;
				case "ServiceID": return this.ServiceID;
				case "Name": return this.Name;
				case "Description": return this.Description;
				case "Quantity": return this.Quantity;
				case "UnitPrice": return this.UnitPrice;
				case "DiscountPercent": return this.DiscountPercent;
				case "Duration": return this.Duration;
				case "ShowOnline": return this.ShowOnline;
				case "Sequence": return this.Sequence;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem TransactionDetailServiceID
		{
			get { return new esQueryItem(this, TransactionDetailServiceMetadata.ColumnNames.TransactionDetailServiceID, esSystemType.Guid); }
		} 
		
		public esQueryItem TransactionID
		{
			get { return new esQueryItem(this, TransactionDetailServiceMetadata.ColumnNames.TransactionID, esSystemType.Guid); }
		} 
		
		public esQueryItem ServiceID
		{
			get { return new esQueryItem(this, TransactionDetailServiceMetadata.ColumnNames.ServiceID, esSystemType.Guid); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, TransactionDetailServiceMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, TransactionDetailServiceMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem Quantity
		{
			get { return new esQueryItem(this, TransactionDetailServiceMetadata.ColumnNames.Quantity, esSystemType.Int32); }
		} 
		
		public esQueryItem UnitPrice
		{
			get { return new esQueryItem(this, TransactionDetailServiceMetadata.ColumnNames.UnitPrice, esSystemType.Decimal); }
		} 
		
		public esQueryItem DiscountPercent
		{
			get { return new esQueryItem(this, TransactionDetailServiceMetadata.ColumnNames.DiscountPercent, esSystemType.Decimal); }
		} 
		
		public esQueryItem Duration
		{
			get { return new esQueryItem(this, TransactionDetailServiceMetadata.ColumnNames.Duration, esSystemType.Int32); }
		} 
		
		public esQueryItem ShowOnline
		{
			get { return new esQueryItem(this, TransactionDetailServiceMetadata.ColumnNames.ShowOnline, esSystemType.Boolean); }
		} 
		
		public esQueryItem Sequence
		{
			get { return new esQueryItem(this, TransactionDetailServiceMetadata.ColumnNames.Sequence, esSystemType.Int32); }
		} 
		
		#endregion
		
	}


	
	public partial class TransactionDetailService : esTransactionDetailService
	{

				
		#region UpToServiceByServiceID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_TransactionDetailService_Service
		/// </summary>

		[XmlIgnore]
					
		public Service UpToServiceByServiceID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToServiceByServiceID == null && ServiceID != null)
				{
					this._UpToServiceByServiceID = new Service();
					this._UpToServiceByServiceID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToServiceByServiceID", this._UpToServiceByServiceID);
					this._UpToServiceByServiceID.Query.Where(this._UpToServiceByServiceID.Query.ServiceID == this.ServiceID);
					this._UpToServiceByServiceID.Query.Load();
				}	
				return this._UpToServiceByServiceID;
			}
			
			set
			{
				this.RemovePreSave("UpToServiceByServiceID");
				
				bool changed = this._UpToServiceByServiceID != value;

				if(value == null)
				{
					this.ServiceID = null;
					this._UpToServiceByServiceID = null;
				}
				else
				{
					this.ServiceID = value.ServiceID;
					this._UpToServiceByServiceID = value;
					this.SetPreSave("UpToServiceByServiceID", this._UpToServiceByServiceID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToServiceByServiceID");
				}
			}
		}
		#endregion
		

				
		#region UpToTransactionByTransactionID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_TransactionDetailService_Transaction
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
			if(!this.es.IsDeleted && this._UpToServiceByServiceID != null)
			{
				this.ServiceID = this._UpToServiceByServiceID.ServiceID;
			}
			if(!this.es.IsDeleted && this._UpToTransactionByTransactionID != null)
			{
				this.TransactionID = this._UpToTransactionByTransactionID.TransactionID;
			}
		}
		
	}
	



	[Serializable]
	public partial class TransactionDetailServiceMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected TransactionDetailServiceMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(TransactionDetailServiceMetadata.ColumnNames.TransactionDetailServiceID, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = TransactionDetailServiceMetadata.PropertyNames.TransactionDetailServiceID;
			c.IsInPrimaryKey = true;
			c.HasDefault = true;
			c.Default = @"(newid())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailServiceMetadata.ColumnNames.TransactionID, 1, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = TransactionDetailServiceMetadata.PropertyNames.TransactionID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailServiceMetadata.ColumnNames.ServiceID, 2, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = TransactionDetailServiceMetadata.PropertyNames.ServiceID;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailServiceMetadata.ColumnNames.Name, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = TransactionDetailServiceMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailServiceMetadata.ColumnNames.Description, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = TransactionDetailServiceMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 250;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailServiceMetadata.ColumnNames.Quantity, 5, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = TransactionDetailServiceMetadata.PropertyNames.Quantity;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailServiceMetadata.ColumnNames.UnitPrice, 6, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = TransactionDetailServiceMetadata.PropertyNames.UnitPrice;
			c.NumericPrecision = 18;
			c.NumericScale = 2;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailServiceMetadata.ColumnNames.DiscountPercent, 7, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = TransactionDetailServiceMetadata.PropertyNames.DiscountPercent;
			c.NumericPrecision = 18;
			c.NumericScale = 2;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailServiceMetadata.ColumnNames.Duration, 8, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = TransactionDetailServiceMetadata.PropertyNames.Duration;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailServiceMetadata.ColumnNames.ShowOnline, 9, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = TransactionDetailServiceMetadata.PropertyNames.ShowOnline;
			c.HasDefault = true;
			c.Default = @"('False')";
			m_columns.Add(c);
				
			c = new esColumnMetadata(TransactionDetailServiceMetadata.ColumnNames.Sequence, 10, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = TransactionDetailServiceMetadata.PropertyNames.Sequence;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public TransactionDetailServiceMetadata Meta()
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
			 public const string TransactionDetailServiceID = "TransactionDetailServiceID";
			 public const string TransactionID = "TransactionID";
			 public const string ServiceID = "ServiceID";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Quantity = "Quantity";
			 public const string UnitPrice = "UnitPrice";
			 public const string DiscountPercent = "DiscountPercent";
			 public const string Duration = "Duration";
			 public const string ShowOnline = "ShowOnline";
			 public const string Sequence = "Sequence";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string TransactionDetailServiceID = "TransactionDetailServiceID";
			 public const string TransactionID = "TransactionID";
			 public const string ServiceID = "ServiceID";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Quantity = "Quantity";
			 public const string UnitPrice = "UnitPrice";
			 public const string DiscountPercent = "DiscountPercent";
			 public const string Duration = "Duration";
			 public const string ShowOnline = "ShowOnline";
			 public const string Sequence = "Sequence";
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
			lock (typeof(TransactionDetailServiceMetadata))
			{
				if(TransactionDetailServiceMetadata.mapDelegates == null)
				{
					TransactionDetailServiceMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (TransactionDetailServiceMetadata.meta == null)
				{
					TransactionDetailServiceMetadata.meta = new TransactionDetailServiceMetadata();
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


				meta.AddTypeMap("TransactionDetailServiceID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("TransactionID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("ServiceID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Quantity", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("DiscountPercent", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("Duration", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ShowOnline", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("Sequence", new esTypeMap("int", "System.Int32"));			
				
				
				
				meta.Source = "TransactionDetailService";
				meta.Destination = "TransactionDetailService";
				
				meta.spInsert = "proc_TransactionDetailServiceInsert";				
				meta.spUpdate = "proc_TransactionDetailServiceUpdate";		
				meta.spDelete = "proc_TransactionDetailServiceDelete";
				meta.spLoadAll = "proc_TransactionDetailServiceLoadAll";
				meta.spLoadByPrimaryKey = "proc_TransactionDetailServiceLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private TransactionDetailServiceMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
