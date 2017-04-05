
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 2016-12-23 2:58:22 PM
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
	/// Encapsulates the 'Appointment' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Appointment))]	
	[XmlType("Appointment")]
	public partial class Appointment : esAppointment
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Appointment();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid appointmentID)
		{
			var obj = new Appointment();
			obj.AppointmentID = appointmentID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid appointmentID, esSqlAccessType sqlAccessType)
		{
			var obj = new Appointment();
			obj.AppointmentID = appointmentID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("AppointmentCollection")]
	public partial class AppointmentCollection : esAppointmentCollection, IEnumerable<Appointment>
	{
		public Appointment FindByPrimaryKey(System.Guid appointmentID)
		{
			return this.SingleOrDefault(e => e.AppointmentID == appointmentID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Appointment))]
		public class AppointmentCollectionWCFPacket : esCollectionWCFPacket<AppointmentCollection>
		{
			public static implicit operator AppointmentCollection(AppointmentCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator AppointmentCollectionWCFPacket(AppointmentCollection collection)
			{
				return new AppointmentCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class AppointmentQuery : esAppointmentQuery
	{
		public AppointmentQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "AppointmentQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(AppointmentQuery query)
		{
			return AppointmentQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator AppointmentQuery(string query)
		{
			return (AppointmentQuery)AppointmentQuery.SerializeHelper.FromXml(query, typeof(AppointmentQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esAppointment : EntityBase
	{
		public esAppointment()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid appointmentID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(appointmentID);
			else
				return LoadByPrimaryKeyStoredProcedure(appointmentID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid appointmentID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(appointmentID);
			else
				return LoadByPrimaryKeyStoredProcedure(appointmentID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid appointmentID)
		{
			AppointmentQuery query = new AppointmentQuery();
			query.Where(query.AppointmentID == appointmentID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid appointmentID)
		{
			esParameters parms = new esParameters();
			parms.Add("AppointmentID", appointmentID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Appointment.AppointmentID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? AppointmentID
		{
			get
			{
				return base.GetSystemGuid(AppointmentMetadata.ColumnNames.AppointmentID);
			}
			
			set
			{
				if(base.SetSystemGuid(AppointmentMetadata.ColumnNames.AppointmentID, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.AppointmentID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.CompanyID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CompanyID
		{
			get
			{
				return base.GetSystemGuid(AppointmentMetadata.ColumnNames.CompanyID);
			}
			
			set
			{
				if(base.SetSystemGuid(AppointmentMetadata.ColumnNames.CompanyID, value))
				{
					this._UpToCompanyByCompanyID = null;
					this.OnPropertyChanged("UpToCompanyByCompanyID");
					OnPropertyChanged(AppointmentMetadata.PropertyNames.CompanyID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.StoreID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? StoreID
		{
			get
			{
				return base.GetSystemGuid(AppointmentMetadata.ColumnNames.StoreID);
			}
			
			set
			{
				if(base.SetSystemGuid(AppointmentMetadata.ColumnNames.StoreID, value))
				{
					this._UpToStoreByStoreID = null;
					this.OnPropertyChanged("UpToStoreByStoreID");
					OnPropertyChanged(AppointmentMetadata.PropertyNames.StoreID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.StaffID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? StaffID
		{
			get
			{
				return base.GetSystemGuid(AppointmentMetadata.ColumnNames.StaffID);
			}
			
			set
			{
				if(base.SetSystemGuid(AppointmentMetadata.ColumnNames.StaffID, value))
				{
					this._UpToStaffByStaffID = null;
					this.OnPropertyChanged("UpToStaffByStaffID");
					OnPropertyChanged(AppointmentMetadata.PropertyNames.StaffID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.CustomerID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CustomerID
		{
			get
			{
				return base.GetSystemGuid(AppointmentMetadata.ColumnNames.CustomerID);
			}
			
			set
			{
				if(base.SetSystemGuid(AppointmentMetadata.ColumnNames.CustomerID, value))
				{
					this._UpToCustomerByCustomerID = null;
					this.OnPropertyChanged("UpToCustomerByCustomerID");
					OnPropertyChanged(AppointmentMetadata.PropertyNames.CustomerID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.Notes
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Notes
		{
			get
			{
				return base.GetSystemString(AppointmentMetadata.ColumnNames.Notes);
			}
			
			set
			{
				if(base.SetSystemString(AppointmentMetadata.ColumnNames.Notes, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.Notes);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.Color
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Color
		{
			get
			{
				return base.GetSystemString(AppointmentMetadata.ColumnNames.Color);
			}
			
			set
			{
				if(base.SetSystemString(AppointmentMetadata.ColumnNames.Color, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.Color);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.Subject
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Subject
		{
			get
			{
				return base.GetSystemString(AppointmentMetadata.ColumnNames.Subject);
			}
			
			set
			{
				if(base.SetSystemString(AppointmentMetadata.ColumnNames.Subject, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.Subject);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(AppointmentMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(AppointmentMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.StartTime
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? StartTime
		{
			get
			{
				return base.GetSystemDateTime(AppointmentMetadata.ColumnNames.StartTime);
			}
			
			set
			{
				if(base.SetSystemDateTime(AppointmentMetadata.ColumnNames.StartTime, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.StartTime);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.EndTime
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? EndTime
		{
			get
			{
				return base.GetSystemDateTime(AppointmentMetadata.ColumnNames.EndTime);
			}
			
			set
			{
				if(base.SetSystemDateTime(AppointmentMetadata.ColumnNames.EndTime, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.EndTime);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.AllDay
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Boolean? AllDay
		{
			get
			{
				return base.GetSystemBoolean(AppointmentMetadata.ColumnNames.AllDay);
			}
			
			set
			{
				if(base.SetSystemBoolean(AppointmentMetadata.ColumnNames.AllDay, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.AllDay);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.ReminderInfo
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ReminderInfo
		{
			get
			{
				return base.GetSystemString(AppointmentMetadata.ColumnNames.ReminderInfo);
			}
			
			set
			{
				if(base.SetSystemString(AppointmentMetadata.ColumnNames.ReminderInfo, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.ReminderInfo);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.RecurrenceInfo
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String RecurrenceInfo
		{
			get
			{
				return base.GetSystemString(AppointmentMetadata.ColumnNames.RecurrenceInfo);
			}
			
			set
			{
				if(base.SetSystemString(AppointmentMetadata.ColumnNames.RecurrenceInfo, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.RecurrenceInfo);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.Recurrence
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Recurrence
		{
			get
			{
				return base.GetSystemInt32(AppointmentMetadata.ColumnNames.Recurrence);
			}
			
			set
			{
				if(base.SetSystemInt32(AppointmentMetadata.ColumnNames.Recurrence, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.Recurrence);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.RecurrenceRule
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String RecurrenceRule
		{
			get
			{
				return base.GetSystemString(AppointmentMetadata.ColumnNames.RecurrenceRule);
			}
			
			set
			{
				if(base.SetSystemString(AppointmentMetadata.ColumnNames.RecurrenceRule, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.RecurrenceRule);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.StartTimeZone
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String StartTimeZone
		{
			get
			{
				return base.GetSystemString(AppointmentMetadata.ColumnNames.StartTimeZone);
			}
			
			set
			{
				if(base.SetSystemString(AppointmentMetadata.ColumnNames.StartTimeZone, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.StartTimeZone);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.EndTimeZone
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String EndTimeZone
		{
			get
			{
				return base.GetSystemString(AppointmentMetadata.ColumnNames.EndTimeZone);
			}
			
			set
			{
				if(base.SetSystemString(AppointmentMetadata.ColumnNames.EndTimeZone, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.EndTimeZone);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.Status
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Status
		{
			get
			{
				return base.GetSystemInt32(AppointmentMetadata.ColumnNames.Status);
			}
			
			set
			{
				if(base.SetSystemInt32(AppointmentMetadata.ColumnNames.Status, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.Status);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Appointment.Label
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Label
		{
			get
			{
				return base.GetSystemInt32(AppointmentMetadata.ColumnNames.Label);
			}
			
			set
			{
				if(base.SetSystemInt32(AppointmentMetadata.ColumnNames.Label, value))
				{
					OnPropertyChanged(AppointmentMetadata.PropertyNames.Label);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Company _UpToCompanyByCompanyID;
		[CLSCompliant(false)]
		internal protected Customer _UpToCustomerByCustomerID;
		[CLSCompliant(false)]
		internal protected Staff _UpToStaffByStaffID;
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
						case "AppointmentID": this.str().AppointmentID = (string)value; break;							
						case "CompanyID": this.str().CompanyID = (string)value; break;							
						case "StoreID": this.str().StoreID = (string)value; break;							
						case "StaffID": this.str().StaffID = (string)value; break;							
						case "CustomerID": this.str().CustomerID = (string)value; break;							
						case "Notes": this.str().Notes = (string)value; break;							
						case "Color": this.str().Color = (string)value; break;							
						case "Subject": this.str().Subject = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;							
						case "StartTime": this.str().StartTime = (string)value; break;							
						case "EndTime": this.str().EndTime = (string)value; break;							
						case "AllDay": this.str().AllDay = (string)value; break;							
						case "ReminderInfo": this.str().ReminderInfo = (string)value; break;							
						case "RecurrenceInfo": this.str().RecurrenceInfo = (string)value; break;							
						case "Recurrence": this.str().Recurrence = (string)value; break;							
						case "RecurrenceRule": this.str().RecurrenceRule = (string)value; break;							
						case "StartTimeZone": this.str().StartTimeZone = (string)value; break;							
						case "EndTimeZone": this.str().EndTimeZone = (string)value; break;							
						case "Status": this.str().Status = (string)value; break;							
						case "Label": this.str().Label = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "AppointmentID":
						
							if (value == null || value is System.Guid)
								this.AppointmentID = (System.Guid?)value;
								OnPropertyChanged(AppointmentMetadata.PropertyNames.AppointmentID);
							break;
						
						case "CompanyID":
						
							if (value == null || value is System.Guid)
								this.CompanyID = (System.Guid?)value;
								OnPropertyChanged(AppointmentMetadata.PropertyNames.CompanyID);
							break;
						
						case "StoreID":
						
							if (value == null || value is System.Guid)
								this.StoreID = (System.Guid?)value;
								OnPropertyChanged(AppointmentMetadata.PropertyNames.StoreID);
							break;
						
						case "StaffID":
						
							if (value == null || value is System.Guid)
								this.StaffID = (System.Guid?)value;
								OnPropertyChanged(AppointmentMetadata.PropertyNames.StaffID);
							break;
						
						case "CustomerID":
						
							if (value == null || value is System.Guid)
								this.CustomerID = (System.Guid?)value;
								OnPropertyChanged(AppointmentMetadata.PropertyNames.CustomerID);
							break;
						
						case "StartTime":
						
							if (value == null || value is System.DateTime)
								this.StartTime = (System.DateTime?)value;
								OnPropertyChanged(AppointmentMetadata.PropertyNames.StartTime);
							break;
						
						case "EndTime":
						
							if (value == null || value is System.DateTime)
								this.EndTime = (System.DateTime?)value;
								OnPropertyChanged(AppointmentMetadata.PropertyNames.EndTime);
							break;
						
						case "AllDay":
						
							if (value == null || value is System.Boolean)
								this.AllDay = (System.Boolean?)value;
								OnPropertyChanged(AppointmentMetadata.PropertyNames.AllDay);
							break;
						
						case "Recurrence":
						
							if (value == null || value is System.Int32)
								this.Recurrence = (System.Int32?)value;
								OnPropertyChanged(AppointmentMetadata.PropertyNames.Recurrence);
							break;
						
						case "Status":
						
							if (value == null || value is System.Int32)
								this.Status = (System.Int32?)value;
								OnPropertyChanged(AppointmentMetadata.PropertyNames.Status);
							break;
						
						case "Label":
						
							if (value == null || value is System.Int32)
								this.Label = (System.Int32?)value;
								OnPropertyChanged(AppointmentMetadata.PropertyNames.Label);
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
			public esStrings(esAppointment entity)
			{
				this.entity = entity;
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
				
			public System.String CustomerID
			{
				get
				{
					System.Guid? data = entity.CustomerID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CustomerID = null;
					else entity.CustomerID = new Guid(value);
				}
			}
				
			public System.String Notes
			{
				get
				{
					System.String data = entity.Notes;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Notes = null;
					else entity.Notes = Convert.ToString(value);
				}
			}
				
			public System.String Color
			{
				get
				{
					System.String data = entity.Color;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Color = null;
					else entity.Color = Convert.ToString(value);
				}
			}
				
			public System.String Subject
			{
				get
				{
					System.String data = entity.Subject;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Subject = null;
					else entity.Subject = Convert.ToString(value);
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
				
			public System.String StartTime
			{
				get
				{
					System.DateTime? data = entity.StartTime;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.StartTime = null;
					else entity.StartTime = Convert.ToDateTime(value);
				}
			}
				
			public System.String EndTime
			{
				get
				{
					System.DateTime? data = entity.EndTime;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.EndTime = null;
					else entity.EndTime = Convert.ToDateTime(value);
				}
			}
				
			public System.String AllDay
			{
				get
				{
					System.Boolean? data = entity.AllDay;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AllDay = null;
					else entity.AllDay = Convert.ToBoolean(value);
				}
			}
				
			public System.String ReminderInfo
			{
				get
				{
					System.String data = entity.ReminderInfo;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ReminderInfo = null;
					else entity.ReminderInfo = Convert.ToString(value);
				}
			}
				
			public System.String RecurrenceInfo
			{
				get
				{
					System.String data = entity.RecurrenceInfo;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.RecurrenceInfo = null;
					else entity.RecurrenceInfo = Convert.ToString(value);
				}
			}
				
			public System.String Recurrence
			{
				get
				{
					System.Int32? data = entity.Recurrence;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Recurrence = null;
					else entity.Recurrence = Convert.ToInt32(value);
				}
			}
				
			public System.String RecurrenceRule
			{
				get
				{
					System.String data = entity.RecurrenceRule;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.RecurrenceRule = null;
					else entity.RecurrenceRule = Convert.ToString(value);
				}
			}
				
			public System.String StartTimeZone
			{
				get
				{
					System.String data = entity.StartTimeZone;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.StartTimeZone = null;
					else entity.StartTimeZone = Convert.ToString(value);
				}
			}
				
			public System.String EndTimeZone
			{
				get
				{
					System.String data = entity.EndTimeZone;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.EndTimeZone = null;
					else entity.EndTimeZone = Convert.ToString(value);
				}
			}
				
			public System.String Status
			{
				get
				{
					System.Int32? data = entity.Status;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Status = null;
					else entity.Status = Convert.ToInt32(value);
				}
			}
				
			public System.String Label
			{
				get
				{
					System.Int32? data = entity.Label;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Label = null;
					else entity.Label = Convert.ToInt32(value);
				}
			}
			

			private esAppointment entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return AppointmentMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public AppointmentQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AppointmentQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AppointmentQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(AppointmentQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private AppointmentQuery query;		
	}



	[Serializable]
	abstract public partial class esAppointmentCollection : CollectionBase<Appointment>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return AppointmentMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "AppointmentCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public AppointmentQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AppointmentQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AppointmentQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AppointmentQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(AppointmentQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((AppointmentQuery)query);
		}

		#endregion
		
		private AppointmentQuery query;
	}



	[Serializable]
	abstract public partial class esAppointmentQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return AppointmentMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "AppointmentID": return this.AppointmentID;
				case "CompanyID": return this.CompanyID;
				case "StoreID": return this.StoreID;
				case "StaffID": return this.StaffID;
				case "CustomerID": return this.CustomerID;
				case "Notes": return this.Notes;
				case "Color": return this.Color;
				case "Subject": return this.Subject;
				case "Description": return this.Description;
				case "StartTime": return this.StartTime;
				case "EndTime": return this.EndTime;
				case "AllDay": return this.AllDay;
				case "ReminderInfo": return this.ReminderInfo;
				case "RecurrenceInfo": return this.RecurrenceInfo;
				case "Recurrence": return this.Recurrence;
				case "RecurrenceRule": return this.RecurrenceRule;
				case "StartTimeZone": return this.StartTimeZone;
				case "EndTimeZone": return this.EndTimeZone;
				case "Status": return this.Status;
				case "Label": return this.Label;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem AppointmentID
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.AppointmentID, esSystemType.Guid); }
		} 
		
		public esQueryItem CompanyID
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.CompanyID, esSystemType.Guid); }
		} 
		
		public esQueryItem StoreID
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.StoreID, esSystemType.Guid); }
		} 
		
		public esQueryItem StaffID
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.StaffID, esSystemType.Guid); }
		} 
		
		public esQueryItem CustomerID
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.CustomerID, esSystemType.Guid); }
		} 
		
		public esQueryItem Notes
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.Notes, esSystemType.String); }
		} 
		
		public esQueryItem Color
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.Color, esSystemType.String); }
		} 
		
		public esQueryItem Subject
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.Subject, esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem StartTime
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.StartTime, esSystemType.DateTime); }
		} 
		
		public esQueryItem EndTime
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.EndTime, esSystemType.DateTime); }
		} 
		
		public esQueryItem AllDay
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.AllDay, esSystemType.Boolean); }
		} 
		
		public esQueryItem ReminderInfo
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.ReminderInfo, esSystemType.String); }
		} 
		
		public esQueryItem RecurrenceInfo
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.RecurrenceInfo, esSystemType.String); }
		} 
		
		public esQueryItem Recurrence
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.Recurrence, esSystemType.Int32); }
		} 
		
		public esQueryItem RecurrenceRule
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.RecurrenceRule, esSystemType.String); }
		} 
		
		public esQueryItem StartTimeZone
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.StartTimeZone, esSystemType.String); }
		} 
		
		public esQueryItem EndTimeZone
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.EndTimeZone, esSystemType.String); }
		} 
		
		public esQueryItem Status
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.Status, esSystemType.Int32); }
		} 
		
		public esQueryItem Label
		{
			get { return new esQueryItem(this, AppointmentMetadata.ColumnNames.Label, esSystemType.Int32); }
		} 
		
		#endregion
		
	}


	
	public partial class Appointment : esAppointment
	{

		#region TransactionCollectionByAppointmentID - Zero To Many
		
		static public esPrefetchMap Prefetch_TransactionCollectionByAppointmentID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Appointment.TransactionCollectionByAppointmentID_Delegate;
				map.PropertyName = "TransactionCollectionByAppointmentID";
				map.MyColumnName = "AppointmentID";
				map.ParentColumnName = "AppointmentID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void TransactionCollectionByAppointmentID_Delegate(esPrefetchParameters data)
		{
			AppointmentQuery parent = new AppointmentQuery(data.NextAlias());

			TransactionQuery me = data.You != null ? data.You as TransactionQuery : new TransactionQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.AppointmentID == me.AppointmentID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Transaction_Appointment
		/// </summary>

		[XmlIgnore]
		public TransactionCollection TransactionCollectionByAppointmentID
		{
			get
			{
				if(this._TransactionCollectionByAppointmentID == null)
				{
					this._TransactionCollectionByAppointmentID = new TransactionCollection();
					this._TransactionCollectionByAppointmentID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("TransactionCollectionByAppointmentID", this._TransactionCollectionByAppointmentID);
				
					if (this.AppointmentID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._TransactionCollectionByAppointmentID.Query.Where(this._TransactionCollectionByAppointmentID.Query.AppointmentID == this.AppointmentID);
							this._TransactionCollectionByAppointmentID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._TransactionCollectionByAppointmentID.fks.Add(TransactionMetadata.ColumnNames.AppointmentID, this.AppointmentID);
					}
				}

				return this._TransactionCollectionByAppointmentID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._TransactionCollectionByAppointmentID != null) 
				{ 
					this.RemovePostSave("TransactionCollectionByAppointmentID"); 
					this._TransactionCollectionByAppointmentID = null;
					this.OnPropertyChanged("TransactionCollectionByAppointmentID");
				} 
			} 			
		}
			
		
		private TransactionCollection _TransactionCollectionByAppointmentID;
		#endregion

				
		#region UpToCompanyByCompanyID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Appointment_Company
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
		

				
		#region UpToCustomerByCustomerID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Appointment_Customer
		/// </summary>

		[XmlIgnore]
					
		public Customer UpToCustomerByCustomerID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToCustomerByCustomerID == null && CustomerID != null)
				{
					this._UpToCustomerByCustomerID = new Customer();
					this._UpToCustomerByCustomerID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToCustomerByCustomerID", this._UpToCustomerByCustomerID);
					this._UpToCustomerByCustomerID.Query.Where(this._UpToCustomerByCustomerID.Query.CustomerID == this.CustomerID);
					this._UpToCustomerByCustomerID.Query.Load();
				}	
				return this._UpToCustomerByCustomerID;
			}
			
			set
			{
				this.RemovePreSave("UpToCustomerByCustomerID");
				
				bool changed = this._UpToCustomerByCustomerID != value;

				if(value == null)
				{
					this.CustomerID = null;
					this._UpToCustomerByCustomerID = null;
				}
				else
				{
					this.CustomerID = value.CustomerID;
					this._UpToCustomerByCustomerID = value;
					this.SetPreSave("UpToCustomerByCustomerID", this._UpToCustomerByCustomerID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToCustomerByCustomerID");
				}
			}
		}
		#endregion
		

				
		#region UpToStaffByStaffID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Appointment_Staff
		/// </summary>

		[XmlIgnore]
					
		public Staff UpToStaffByStaffID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToStaffByStaffID == null && StaffID != null)
				{
					this._UpToStaffByStaffID = new Staff();
					this._UpToStaffByStaffID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToStaffByStaffID", this._UpToStaffByStaffID);
					this._UpToStaffByStaffID.Query.Where(this._UpToStaffByStaffID.Query.StaffID == this.StaffID);
					this._UpToStaffByStaffID.Query.Load();
				}	
				return this._UpToStaffByStaffID;
			}
			
			set
			{
				this.RemovePreSave("UpToStaffByStaffID");
				
				bool changed = this._UpToStaffByStaffID != value;

				if(value == null)
				{
					this.StaffID = null;
					this._UpToStaffByStaffID = null;
				}
				else
				{
					this.StaffID = value.StaffID;
					this._UpToStaffByStaffID = value;
					this.SetPreSave("UpToStaffByStaffID", this._UpToStaffByStaffID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToStaffByStaffID");
				}
			}
		}
		#endregion
		

				
		#region UpToStoreByStoreID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Appointment_Store
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
				case "TransactionCollectionByAppointmentID":
					coll = this.TransactionCollectionByAppointmentID;
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
			
			props.Add(new esPropertyDescriptor(this, "TransactionCollectionByAppointmentID", typeof(TransactionCollection), new Transaction()));
		
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
			if(!this.es.IsDeleted && this._UpToCustomerByCustomerID != null)
			{
				this.CustomerID = this._UpToCustomerByCustomerID.CustomerID;
			}
			if(!this.es.IsDeleted && this._UpToStaffByStaffID != null)
			{
				this.StaffID = this._UpToStaffByStaffID.StaffID;
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
			if(this._TransactionCollectionByAppointmentID != null)
			{
				Apply(this._TransactionCollectionByAppointmentID, "AppointmentID", this.AppointmentID);
			}
		}
		
	}
	



	[Serializable]
	public partial class AppointmentMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected AppointmentMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.AppointmentID, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = AppointmentMetadata.PropertyNames.AppointmentID;
			c.IsInPrimaryKey = true;
			c.HasDefault = true;
			c.Default = @"(newid())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.CompanyID, 1, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = AppointmentMetadata.PropertyNames.CompanyID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.StoreID, 2, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = AppointmentMetadata.PropertyNames.StoreID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.StaffID, 3, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = AppointmentMetadata.PropertyNames.StaffID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.CustomerID, 4, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = AppointmentMetadata.PropertyNames.CustomerID;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.Notes, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = AppointmentMetadata.PropertyNames.Notes;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.Color, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = AppointmentMetadata.PropertyNames.Color;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.Subject, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = AppointmentMetadata.PropertyNames.Subject;
			c.CharacterMaxLength = 250;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.Description, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = AppointmentMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 500;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.StartTime, 9, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = AppointmentMetadata.PropertyNames.StartTime;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.EndTime, 10, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = AppointmentMetadata.PropertyNames.EndTime;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.AllDay, 11, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = AppointmentMetadata.PropertyNames.AllDay;
			c.HasDefault = true;
			c.Default = @"('False')";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.ReminderInfo, 12, typeof(System.String), esSystemType.String);
			c.PropertyName = AppointmentMetadata.PropertyNames.ReminderInfo;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.RecurrenceInfo, 13, typeof(System.String), esSystemType.String);
			c.PropertyName = AppointmentMetadata.PropertyNames.RecurrenceInfo;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.Recurrence, 14, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AppointmentMetadata.PropertyNames.Recurrence;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((0))";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.RecurrenceRule, 15, typeof(System.String), esSystemType.String);
			c.PropertyName = AppointmentMetadata.PropertyNames.RecurrenceRule;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.StartTimeZone, 16, typeof(System.String), esSystemType.String);
			c.PropertyName = AppointmentMetadata.PropertyNames.StartTimeZone;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.EndTimeZone, 17, typeof(System.String), esSystemType.String);
			c.PropertyName = AppointmentMetadata.PropertyNames.EndTimeZone;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.Status, 18, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AppointmentMetadata.PropertyNames.Status;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(AppointmentMetadata.ColumnNames.Label, 19, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AppointmentMetadata.PropertyNames.Label;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public AppointmentMetadata Meta()
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
			 public const string AppointmentID = "AppointmentID";
			 public const string CompanyID = "CompanyID";
			 public const string StoreID = "StoreID";
			 public const string StaffID = "StaffID";
			 public const string CustomerID = "CustomerID";
			 public const string Notes = "Notes";
			 public const string Color = "Color";
			 public const string Subject = "Subject";
			 public const string Description = "Description";
			 public const string StartTime = "StartTime";
			 public const string EndTime = "EndTime";
			 public const string AllDay = "AllDay";
			 public const string ReminderInfo = "ReminderInfo";
			 public const string RecurrenceInfo = "RecurrenceInfo";
			 public const string Recurrence = "Recurrence";
			 public const string RecurrenceRule = "RecurrenceRule";
			 public const string StartTimeZone = "StartTimeZone";
			 public const string EndTimeZone = "EndTimeZone";
			 public const string Status = "Status";
			 public const string Label = "Label";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string AppointmentID = "AppointmentID";
			 public const string CompanyID = "CompanyID";
			 public const string StoreID = "StoreID";
			 public const string StaffID = "StaffID";
			 public const string CustomerID = "CustomerID";
			 public const string Notes = "Notes";
			 public const string Color = "Color";
			 public const string Subject = "Subject";
			 public const string Description = "Description";
			 public const string StartTime = "StartTime";
			 public const string EndTime = "EndTime";
			 public const string AllDay = "AllDay";
			 public const string ReminderInfo = "ReminderInfo";
			 public const string RecurrenceInfo = "RecurrenceInfo";
			 public const string Recurrence = "Recurrence";
			 public const string RecurrenceRule = "RecurrenceRule";
			 public const string StartTimeZone = "StartTimeZone";
			 public const string EndTimeZone = "EndTimeZone";
			 public const string Status = "Status";
			 public const string Label = "Label";
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
			lock (typeof(AppointmentMetadata))
			{
				if(AppointmentMetadata.mapDelegates == null)
				{
					AppointmentMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AppointmentMetadata.meta == null)
				{
					AppointmentMetadata.meta = new AppointmentMetadata();
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


				meta.AddTypeMap("AppointmentID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("CompanyID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("StoreID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("StaffID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("CustomerID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Notes", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Color", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Subject", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("StartTime", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("EndTime", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("AllDay", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("ReminderInfo", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("RecurrenceInfo", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Recurrence", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("RecurrenceRule", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("StartTimeZone", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("EndTimeZone", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Status", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Label", new esTypeMap("int", "System.Int32"));			
				
				
				
				meta.Source = "Appointment";
				meta.Destination = "Appointment";
				
				meta.spInsert = "proc_AppointmentInsert";				
				meta.spUpdate = "proc_AppointmentUpdate";		
				meta.spDelete = "proc_AppointmentDelete";
				meta.spLoadAll = "proc_AppointmentLoadAll";
				meta.spLoadByPrimaryKey = "proc_AppointmentLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private AppointmentMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
