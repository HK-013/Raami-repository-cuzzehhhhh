
 
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
	/// Chassis Code
	/// </summary>
	public class CSGenioAchassis_code : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAchassis_code(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL TA3 CONSTRUTOR CHASSIS_CODE]/
		}

		public CSGenioAchassis_code(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codchassis_code", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "code_name", FieldType.TEXT);
			Qfield.FieldDescription = "Chassis Code";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CHASSIS_CODE51162";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "year_range", FieldType.TEXT);
			Qfield.FieldDescription = "Year";
			Qfield.FieldSize =  9;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "YEAR61794";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "cod_models", FieldType.KEY_INT);
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
			info.ChildTable = new ChildRelation[1];
			info.ChildTable[0]= new ChildRelation("upgrade", new String[] {"cod_chassis"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("models", new Relation("TA3", "ta3chassis_code", "chassis_code", "codchassis_code", "cod_models", "TA3", "ta3models", "models", "codmodels", "codmodels"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(2);
			info.Pathways.Add("models","models");
			info.Pathways.Add("make","models");
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
		/// static CSGenioAchassis_code()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="TA3";
			info.TableName="ta3chassis_code";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codchassis_code";
			info.HumanKeyName="code_name,".TrimEnd(',');
			info.Alias="chassis_code";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Codebase;
			info.AreaDesignation="Chassis Code";
			info.AreaPluralDesignation="Chassis Codes";
			info.DescriptionCav="CHASSIS_CODE51162";

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
		public static FieldRef FldCodchassis_code { get { return m_fldCodchassis_code; } }
		private static FieldRef m_fldCodchassis_code = new FieldRef("chassis_code", "codchassis_code");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodchassis_code
		{
			get { return (string)returnValueField(FldCodchassis_code); }
			set { insertNameValueField(FldCodchassis_code, value); }
		}

		/// <summary>Field : "Chassis Code" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCode_name { get { return m_fldCode_name; } }
		private static FieldRef m_fldCode_name = new FieldRef("chassis_code", "code_name");

		/// <summary>Field : "Chassis Code" Tipo: "C" Formula:  ""</summary>
		public string ValCode_name
		{
			get { return (string)returnValueField(FldCode_name); }
			set { insertNameValueField(FldCode_name, value); }
		}

		/// <summary>Field : "Year" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldYear_range { get { return m_fldYear_range; } }
		private static FieldRef m_fldYear_range = new FieldRef("chassis_code", "year_range");

		/// <summary>Field : "Year" Tipo: "C" Formula:  ""</summary>
		public string ValYear_range
		{
			get { return (string)returnValueField(FldYear_range); }
			set { insertNameValueField(FldYear_range, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCod_models { get { return m_fldCod_models; } }
		private static FieldRef m_fldCod_models = new FieldRef("chassis_code", "cod_models");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCod_models
		{
			get { return (string)returnValueField(FldCod_models); }
			set { insertNameValueField(FldCod_models, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("chassis_code", "zzstate");



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
        public static CSGenioAchassis_code search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
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
        public static List<CSGenioAchassis_code> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAchassis_code> listing)
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
        public static List<CSGenioAchassis_code> SearchListCustom(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAchassis_code> listing, string[] fields)
        {
			return new List<CSGenioAchassis_code>();
		}







		// USE /[MANUAL TA3 TABAUX CHASSIS_CODE]/

 
     

	}
}
