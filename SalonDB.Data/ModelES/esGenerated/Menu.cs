
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
	/// Encapsulates the 'Menu' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Menu))]	
	[XmlType("Menu")]
	public partial class Menu : esMenu
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Menu();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid menuID)
		{
			var obj = new Menu();
			obj.MenuID = menuID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid menuID, esSqlAccessType sqlAccessType)
		{
			var obj = new Menu();
			obj.MenuID = menuID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("MenuCollection")]
	public partial class MenuCollection : esMenuCollection, IEnumerable<Menu>
	{
		public Menu FindByPrimaryKey(System.Guid menuID)
		{
			return this.SingleOrDefault(e => e.MenuID == menuID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Menu))]
		public class MenuCollectionWCFPacket : esCollectionWCFPacket<MenuCollection>
		{
			public static implicit operator MenuCollection(MenuCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator MenuCollectionWCFPacket(MenuCollection collection)
			{
				return new MenuCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class MenuQuery : esMenuQuery
	{
		public MenuQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "MenuQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(MenuQuery query)
		{
			return MenuQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator MenuQuery(string query)
		{
			return (MenuQuery)MenuQuery.SerializeHelper.FromXml(query, typeof(MenuQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esMenu : EntityBase
	{
		public esMenu()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid menuID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(menuID);
			else
				return LoadByPrimaryKeyStoredProcedure(menuID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid menuID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(menuID);
			else
				return LoadByPrimaryKeyStoredProcedure(menuID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid menuID)
		{
			MenuQuery query = new MenuQuery();
			query.Where(query.MenuID == menuID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid menuID)
		{
			esParameters parms = new esParameters();
			parms.Add("MenuID", menuID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Menu.MenuID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? MenuID
		{
			get
			{
				return base.GetSystemGuid(MenuMetadata.ColumnNames.MenuID);
			}
			
			set
			{
				if(base.SetSystemGuid(MenuMetadata.ColumnNames.MenuID, value))
				{
					OnPropertyChanged(MenuMetadata.PropertyNames.MenuID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Menu.ParentMenuID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? ParentMenuID
		{
			get
			{
				return base.GetSystemGuid(MenuMetadata.ColumnNames.ParentMenuID);
			}
			
			set
			{
				if(base.SetSystemGuid(MenuMetadata.ColumnNames.ParentMenuID, value))
				{
					this._UpToMenuByParentMenuID = null;
					this.OnPropertyChanged("UpToMenuByParentMenuID");
					OnPropertyChanged(MenuMetadata.PropertyNames.ParentMenuID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Menu.Name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(MenuMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(MenuMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(MenuMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Menu.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(MenuMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(MenuMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(MenuMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Menu.Icon
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Icon
		{
			get
			{
				return base.GetSystemString(MenuMetadata.ColumnNames.Icon);
			}
			
			set
			{
				if(base.SetSystemString(MenuMetadata.ColumnNames.Icon, value))
				{
					OnPropertyChanged(MenuMetadata.PropertyNames.Icon);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Menu.Url
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Url
		{
			get
			{
				return base.GetSystemString(MenuMetadata.ColumnNames.Url);
			}
			
			set
			{
				if(base.SetSystemString(MenuMetadata.ColumnNames.Url, value))
				{
					OnPropertyChanged(MenuMetadata.PropertyNames.Url);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Menu.Sequence
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Sequence
		{
			get
			{
				return base.GetSystemInt32(MenuMetadata.ColumnNames.Sequence);
			}
			
			set
			{
				if(base.SetSystemInt32(MenuMetadata.ColumnNames.Sequence, value))
				{
					OnPropertyChanged(MenuMetadata.PropertyNames.Sequence);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Menu.MenuLevel
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? MenuLevel
		{
			get
			{
				return base.GetSystemInt32(MenuMetadata.ColumnNames.MenuLevel);
			}
			
			set
			{
				if(base.SetSystemInt32(MenuMetadata.ColumnNames.MenuLevel, value))
				{
					OnPropertyChanged(MenuMetadata.PropertyNames.MenuLevel);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Menu _UpToMenuByParentMenuID;
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
						case "MenuID": this.str().MenuID = (string)value; break;							
						case "ParentMenuID": this.str().ParentMenuID = (string)value; break;							
						case "Name": this.str().Name = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;							
						case "Icon": this.str().Icon = (string)value; break;							
						case "Url": this.str().Url = (string)value; break;							
						case "Sequence": this.str().Sequence = (string)value; break;							
						case "MenuLevel": this.str().MenuLevel = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "MenuID":
						
							if (value == null || value is System.Guid)
								this.MenuID = (System.Guid?)value;
								OnPropertyChanged(MenuMetadata.PropertyNames.MenuID);
							break;
						
						case "ParentMenuID":
						
							if (value == null || value is System.Guid)
								this.ParentMenuID = (System.Guid?)value;
								OnPropertyChanged(MenuMetadata.PropertyNames.ParentMenuID);
							break;
						
						case "Sequence":
						
							if (value == null || value is System.Int32)
								this.Sequence = (System.Int32?)value;
								OnPropertyChanged(MenuMetadata.PropertyNames.Sequence);
							break;
						
						case "MenuLevel":
						
							if (value == null || value is System.Int32)
								this.MenuLevel = (System.Int32?)value;
								OnPropertyChanged(MenuMetadata.PropertyNames.MenuLevel);
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
			public esStrings(esMenu entity)
			{
				this.entity = entity;
			}
			
	
			public System.String MenuID
			{
				get
				{
					System.Guid? data = entity.MenuID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.MenuID = null;
					else entity.MenuID = new Guid(value);
				}
			}
				
			public System.String ParentMenuID
			{
				get
				{
					System.Guid? data = entity.ParentMenuID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ParentMenuID = null;
					else entity.ParentMenuID = new Guid(value);
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
				
			public System.String Icon
			{
				get
				{
					System.String data = entity.Icon;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Icon = null;
					else entity.Icon = Convert.ToString(value);
				}
			}
				
			public System.String Url
			{
				get
				{
					System.String data = entity.Url;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Url = null;
					else entity.Url = Convert.ToString(value);
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
				
			public System.String MenuLevel
			{
				get
				{
					System.Int32? data = entity.MenuLevel;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.MenuLevel = null;
					else entity.MenuLevel = Convert.ToInt32(value);
				}
			}
			

			private esMenu entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return MenuMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public MenuQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new MenuQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(MenuQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(MenuQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private MenuQuery query;		
	}



	[Serializable]
	abstract public partial class esMenuCollection : CollectionBase<Menu>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return MenuMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "MenuCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public MenuQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new MenuQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(MenuQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new MenuQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(MenuQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((MenuQuery)query);
		}

		#endregion
		
		private MenuQuery query;
	}



	[Serializable]
	abstract public partial class esMenuQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return MenuMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "MenuID": return this.MenuID;
				case "ParentMenuID": return this.ParentMenuID;
				case "Name": return this.Name;
				case "Description": return this.Description;
				case "Icon": return this.Icon;
				case "Url": return this.Url;
				case "Sequence": return this.Sequence;
				case "MenuLevel": return this.MenuLevel;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem MenuID
		{
			get { return new esQueryItem(this, MenuMetadata.ColumnNames.MenuID, esSystemType.Guid); }
		} 
		
		public esQueryItem ParentMenuID
		{
			get { return new esQueryItem(this, MenuMetadata.ColumnNames.ParentMenuID, esSystemType.Guid); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, MenuMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, MenuMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem Icon
		{
			get { return new esQueryItem(this, MenuMetadata.ColumnNames.Icon, esSystemType.String); }
		} 
		
		public esQueryItem Url
		{
			get { return new esQueryItem(this, MenuMetadata.ColumnNames.Url, esSystemType.String); }
		} 
		
		public esQueryItem Sequence
		{
			get { return new esQueryItem(this, MenuMetadata.ColumnNames.Sequence, esSystemType.Int32); }
		} 
		
		public esQueryItem MenuLevel
		{
			get { return new esQueryItem(this, MenuMetadata.ColumnNames.MenuLevel, esSystemType.Int32); }
		} 
		
		#endregion
		
	}


	
	public partial class Menu : esMenu
	{

		#region MenuCollectionByParentMenuID - Zero To Many
		
		static public esPrefetchMap Prefetch_MenuCollectionByParentMenuID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Menu.MenuCollectionByParentMenuID_Delegate;
				map.PropertyName = "MenuCollectionByParentMenuID";
				map.MyColumnName = "MenuID";
				map.ParentColumnName = "ParentMenuID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void MenuCollectionByParentMenuID_Delegate(esPrefetchParameters data)
		{
			MenuQuery parent = new MenuQuery(data.NextAlias());

			MenuQuery me = data.You != null ? data.You as MenuQuery : new MenuQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.ParentMenuID == me.MenuID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Menu_Menu
		/// </summary>

		[XmlIgnore]
		public MenuCollection MenuCollectionByParentMenuID
		{
			get
			{
				if(this._MenuCollectionByParentMenuID == null)
				{
					this._MenuCollectionByParentMenuID = new MenuCollection();
					this._MenuCollectionByParentMenuID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("MenuCollectionByParentMenuID", this._MenuCollectionByParentMenuID);
				
					if (this.MenuID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._MenuCollectionByParentMenuID.Query.Where(this._MenuCollectionByParentMenuID.Query.ParentMenuID == this.MenuID);
							this._MenuCollectionByParentMenuID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._MenuCollectionByParentMenuID.fks.Add(MenuMetadata.ColumnNames.ParentMenuID, this.MenuID);
					}
				}

				return this._MenuCollectionByParentMenuID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._MenuCollectionByParentMenuID != null) 
				{ 
					this.RemovePostSave("MenuCollectionByParentMenuID"); 
					this._MenuCollectionByParentMenuID = null;
					this.OnPropertyChanged("MenuCollectionByParentMenuID");
				} 
			} 			
		}
			
		
		private MenuCollection _MenuCollectionByParentMenuID;
		#endregion

				
		#region UpToMenuByParentMenuID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Menu_Menu
		/// </summary>

		[XmlIgnore]
					
		public Menu UpToMenuByParentMenuID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToMenuByParentMenuID == null && ParentMenuID != null)
				{
					this._UpToMenuByParentMenuID = new Menu();
					this._UpToMenuByParentMenuID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToMenuByParentMenuID", this._UpToMenuByParentMenuID);
					this._UpToMenuByParentMenuID.Query.Where(this._UpToMenuByParentMenuID.Query.MenuID == this.ParentMenuID);
					this._UpToMenuByParentMenuID.Query.Load();
				}	
				return this._UpToMenuByParentMenuID;
			}
			
			set
			{
				this.RemovePreSave("UpToMenuByParentMenuID");
				
				bool changed = this._UpToMenuByParentMenuID != value;

				if(value == null)
				{
					this.ParentMenuID = null;
					this._UpToMenuByParentMenuID = null;
				}
				else
				{
					this.ParentMenuID = value.MenuID;
					this._UpToMenuByParentMenuID = value;
					this.SetPreSave("UpToMenuByParentMenuID", this._UpToMenuByParentMenuID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToMenuByParentMenuID");
				}
			}
		}
		#endregion
		

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "MenuCollectionByParentMenuID":
					coll = this.MenuCollectionByParentMenuID;
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
			
			props.Add(new esPropertyDescriptor(this, "MenuCollectionByParentMenuID", typeof(MenuCollection), new Menu()));
		
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToMenuByParentMenuID != null)
			{
				this.ParentMenuID = this._UpToMenuByParentMenuID.MenuID;
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
			if(this._MenuCollectionByParentMenuID != null)
			{
				Apply(this._MenuCollectionByParentMenuID, "ParentMenuID", this.MenuID);
			}
		}
		
	}
	



	[Serializable]
	public partial class MenuMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected MenuMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(MenuMetadata.ColumnNames.MenuID, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = MenuMetadata.PropertyNames.MenuID;
			c.IsInPrimaryKey = true;
			c.HasDefault = true;
			c.Default = @"(newid())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(MenuMetadata.ColumnNames.ParentMenuID, 1, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = MenuMetadata.PropertyNames.ParentMenuID;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MenuMetadata.ColumnNames.Name, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = MenuMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MenuMetadata.ColumnNames.Description, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = MenuMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 250;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MenuMetadata.ColumnNames.Icon, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = MenuMetadata.PropertyNames.Icon;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MenuMetadata.ColumnNames.Url, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = MenuMetadata.PropertyNames.Url;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MenuMetadata.ColumnNames.Sequence, 6, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = MenuMetadata.PropertyNames.Sequence;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(MenuMetadata.ColumnNames.MenuLevel, 7, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = MenuMetadata.PropertyNames.MenuLevel;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public MenuMetadata Meta()
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
			 public const string MenuID = "MenuID";
			 public const string ParentMenuID = "ParentMenuID";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Icon = "Icon";
			 public const string Url = "Url";
			 public const string Sequence = "Sequence";
			 public const string MenuLevel = "MenuLevel";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string MenuID = "MenuID";
			 public const string ParentMenuID = "ParentMenuID";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Icon = "Icon";
			 public const string Url = "Url";
			 public const string Sequence = "Sequence";
			 public const string MenuLevel = "MenuLevel";
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
			lock (typeof(MenuMetadata))
			{
				if(MenuMetadata.mapDelegates == null)
				{
					MenuMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (MenuMetadata.meta == null)
				{
					MenuMetadata.meta = new MenuMetadata();
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


				meta.AddTypeMap("MenuID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("ParentMenuID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Icon", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Url", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Sequence", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("MenuLevel", new esTypeMap("int", "System.Int32"));			
				
				
				
				meta.Source = "Menu";
				meta.Destination = "Menu";
				
				meta.spInsert = "proc_MenuInsert";				
				meta.spUpdate = "proc_MenuUpdate";		
				meta.spDelete = "proc_MenuDelete";
				meta.spLoadAll = "proc_MenuLoadAll";
				meta.spLoadByPrimaryKey = "proc_MenuLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private MenuMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
