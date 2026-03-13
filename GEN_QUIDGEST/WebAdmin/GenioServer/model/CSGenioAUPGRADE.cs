
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using CSGenio.framework;
using CSGenio.persistence;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Linq;

namespace CSGenio.business
{
	/// <summary>
	/// Upgrade
	/// </summary>
	public class CSGenioAupgrade : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAupgrade(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL TA3 CONSTRUTOR UPGRADE]/
		}

		public CSGenioAupgrade(User user) : this(user, user.CurrentModule)
		{
		}

		/// <summary>
		/// Initializes the metadata relative to the fields of this area
		/// </summary>
		private static void InicializaCampos(AreaInfo info)
		{
			Field Qfield = null;
#pragma warning disable CS0168, S1481 // Variable is declared but never used
			List<ByAreaArguments> argumentsListByArea;
#pragma warning restore CS0168, S1481 // Variable is declared but never used
			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codupgrade", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "part_name", FieldType.TEXT);
			Qfield.FieldDescription = "Part Name";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PART_NAME55942";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "stage", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Stage";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "STAGE09691";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCenum_stage";
            Qfield.ArrayClassName = "Enum_stage";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "price", FieldType.CURRENCY);
			Qfield.FieldDescription = "Price";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 5;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "PRICE06900";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "buy_link", FieldType.TEXT);
			Qfield.FieldDescription = "Click here to buy product";
			Qfield.FieldSize =  255;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CLICK_HERE_TO_BUY_PR34749";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "cod_chassis", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "zzstate", FieldType.INTEGER);
			Qfield.FieldDescription = "Estado da ficha";
			info.RegisterFieldDB(Qfield);

		}

		/// <summary>
		/// Initializes metadata for paths direct to other areas
		/// </summary>
		private static void InicializaRelacoes(AreaInfo info)
		{
			// Daughters Relations
			//------------------------------

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("chassis_code", new Relation("TA3", "ta3upgrade", "upgrade", "codupgrade", "cod_chassis", "TA3", "ta3chassis_code", "chassis_code", "codchassis_code", "codchassis_code"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(3);
			info.Pathways.Add("chassis_code","chassis_code");
			info.Pathways.Add("models","chassis_code");
			info.Pathways.Add("make","chassis_code");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------








			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAupgrade()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="TA3";
			info.TableName="ta3upgrade";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codupgrade";
			info.HumanKeyName="part_name,".TrimEnd(',');
			info.Alias="upgrade";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Codebase;
			info.AreaDesignation="Upgrade";
			info.AreaPluralDesignation="Upgrades";
			info.DescriptionCav="UPGRADE13909";

			//sincronização
			info.SyncIncrementalDateStart = TimeSpan.FromHours(8);
			info.SyncIncrementalDateEnd = TimeSpan.FromHours(23);
			info.SyncCompleteHour = TimeSpan.FromHours(0.5);
			info.SyncIncrementalPeriod = TimeSpan.FromHours(1);
			info.BatchSync = 100;
			info.SyncType = SyncType.Central;
            info.SolrList = new List<string>();
        	info.QueuesList = new List<GenioServer.business.QueueGenio>();





			//RS 22.03.2011 I separated in submetodos due to performance problems with the JIT in 64bits
			// that in very large projects took 2 minutes on the first call.
			// After a Microsoft analysis of the JIT algortimo it was revealed that it has a
			// complexity O(n*m) where n are the lines of code and m the number of variables of a function.
			// Tests have revealed that splitting into subfunctions cuts the JIT time by more than half by 64-bit.
			//------------------------------
			InicializaCampos(info);

			//------------------------------
			InicializaRelacoes(info);

			//------------------------------
			InicializaCaminhos(info);

			//------------------------------
			InicializaFormulas(info);

			// Automatic audit stamps in BD
            //------------------------------

            // Documents in DB
            //------------------------------

            // Historics
            //------------------------------

			// Duplication
			//------------------------------

			// Ephs
			//------------------------------
			info.Ephs=new Hashtable();

			// Table minimum roles and access levels
			//------------------------------
            info.QLevel = new QLevel();
            info.QLevel.Query = Role.AUTHORIZED;
            info.QLevel.Create = Role.AUTHORIZED;
            info.QLevel.AlterAlways = Role.AUTHORIZED;
            info.QLevel.RemoveAlways = Role.AUTHORIZED;

      		return info;
		}

		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public override AreaInfo Information
		{
			get { return informacao; }
		}
		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public static AreaInfo GetInformation()
		{
			return informacao;
		}

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodupgrade { get { return m_fldCodupgrade; } }
		private static FieldRef m_fldCodupgrade = new FieldRef("upgrade", "codupgrade");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodupgrade
		{
			get { return (string)returnValueField(FldCodupgrade); }
			set { insertNameValueField(FldCodupgrade, value); }
		}

		/// <summary>Field : "Part Name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPart_name { get { return m_fldPart_name; } }
		private static FieldRef m_fldPart_name = new FieldRef("upgrade", "part_name");

		/// <summary>Field : "Part Name" Tipo: "C" Formula:  ""</summary>
		public string ValPart_name
		{
			get { return (string)returnValueField(FldPart_name); }
			set { insertNameValueField(FldPart_name, value); }
		}

		/// <summary>Field : "Stage" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldStage { get { return m_fldStage; } }
		private static FieldRef m_fldStage = new FieldRef("upgrade", "stage");

		/// <summary>Field : "Stage" Tipo: "AC" Formula:  ""</summary>
		public string ValStage
		{
			get { return (string)returnValueField(FldStage); }
			set { insertNameValueField(FldStage, value); }
		}

		/// <summary>Field : "Price" Tipo: "$D" Formula:  ""</summary>
		public static FieldRef FldPrice { get { return m_fldPrice; } }
		private static FieldRef m_fldPrice = new FieldRef("upgrade", "price");

		/// <summary>Field : "Price" Tipo: "$D" Formula:  ""</summary>
		public decimal ValPrice
		{
			get { return (decimal)returnValueField(FldPrice); }
			set { insertNameValueField(FldPrice, value); }
		}

		/// <summary>Field : "Click here to buy product" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldBuy_link { get { return m_fldBuy_link; } }
		private static FieldRef m_fldBuy_link = new FieldRef("upgrade", "buy_link");

		/// <summary>Field : "Click here to buy product" Tipo: "C" Formula:  ""</summary>
		public string ValBuy_link
		{
			get { return (string)returnValueField(FldBuy_link); }
			set { insertNameValueField(FldBuy_link, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCod_chassis { get { return m_fldCod_chassis; } }
		private static FieldRef m_fldCod_chassis = new FieldRef("upgrade", "cod_chassis");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCod_chassis
		{
			get { return (string)returnValueField(FldCod_chassis); }
			set { insertNameValueField(FldCod_chassis, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("upgrade", "zzstate");



		/// <summary>Field : "ZZSTATE" Type: "INT"</summary>
		public int ValZzstate
		{
			get { return (int)returnValueField(FldZzstate); }
			set { insertNameValueField(FldZzstate, value); }
		}

        /// <summary>
        /// Obtains a partially populated area with the record corresponding to a primary key
        /// </summary>
        /// <param name="sp">Persistent support from where to get the registration</param>
        /// <param name="key">The value of the primary key</param>
        /// <param name="user">The context of the user</param>
        /// <param name="fields">The fields to be filled in the area</param>
		/// <param name="forUpdate">True if you are preparing to update this record, false otherwise</param>
        /// <returns>An area with the fields requests of the record read or null if the key does not exist</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static CSGenioAupgrade search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			var l = searchList(
				sp,
				user,
				CriteriaSet.And().Equal(informacao.Alias, informacao.PrimaryKeyName, key),
				null
			);

			if (l?.Count > 0)
				return l[0];

			return null;
        }


		public static string GetkeyFromControlledRecord(PersistentSupport sp, string ID, User user)
		{
			if (informacao.ControlledRecords != null)
				return informacao.ControlledRecords.GetPrimaryKeyFromControlledRecord(sp, user, ID);
			return String.Empty;
		}


        /// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="fields">The fields to be filled in the area</param>
        /// <param name="distinct">Get distinct from fields</param>
        /// <param name="noLock">NOLOCK</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static List<CSGenioAupgrade> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return SearchListCustom(sp, user, where, null, fields);
        }



       	/// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="listing">List configuration</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAupgrade> listing)
        {
			listing.Rows = SearchListCustom(sp, user, where, listing, null);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => false;

		/// <summary>
        /// Common method used by custom table. Use the manwin tag to add your own code to get the table values.
        /// </summary>
        /// <param name="sp">Persistent support</param>
        /// <param name="user">User</param>
        /// <param name="where">A criteria set with the filtering being done</param>
        /// <param name="listing">A ListingMVC with all necessary information to present a list. Only has value when this function is called from searchListAdvancedWhere (MVC) </param>
        /// <param name="fields">The field names being passed. This parameter only has values when this function is called from searchList (QWeb and WS usually)</param>
        /// <returns>A list with all records filled</returns>
        public static List<CSGenioAupgrade> SearchListCustom(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAupgrade> listing, string[] fields)
        {
			return new List<CSGenioAupgrade>();
		}







		// USE /[MANUAL TA3 TABAUX UPGRADE]/

 
       

	}
}
