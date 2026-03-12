
 
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
	/// Model
	/// </summary>
	public class CSGenioAmodels : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAmodels(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL TA3 CONSTRUTOR MODELS]/
		}

		public CSGenioAmodels(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codmodels", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "model_name", FieldType.TEXT);
			Qfield.FieldDescription = "Model";
			Qfield.FieldSize =  85;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "MODEL27263";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "cod_make", FieldType.KEY_INT);
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
			info.ChildTable[0]= new ChildRelation("chassis_code", new String[] {"cod_models"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("make", new Relation("TA3", "ta3models", "models", "codmodels", "cod_make", "TA3", "ta3make", "make", "codmake", "codmake"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(1);
			info.Pathways.Add("make","make");
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
		/// static CSGenioAmodels()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="TA3";
			info.TableName="ta3models";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codmodels";
			info.HumanKeyName="model_name,".TrimEnd(',');
			info.Alias="models";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Codebase;
			info.AreaDesignation="Model";
			info.AreaPluralDesignation="Models";
			info.DescriptionCav="MODEL27263";

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
		public static FieldRef FldCodmodels { get { return m_fldCodmodels; } }
		private static FieldRef m_fldCodmodels = new FieldRef("models", "codmodels");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodmodels
		{
			get { return (string)returnValueField(FldCodmodels); }
			set { insertNameValueField(FldCodmodels, value); }
		}

		/// <summary>Field : "Model" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldModel_name { get { return m_fldModel_name; } }
		private static FieldRef m_fldModel_name = new FieldRef("models", "model_name");

		/// <summary>Field : "Model" Tipo: "C" Formula:  ""</summary>
		public string ValModel_name
		{
			get { return (string)returnValueField(FldModel_name); }
			set { insertNameValueField(FldModel_name, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCod_make { get { return m_fldCod_make; } }
		private static FieldRef m_fldCod_make = new FieldRef("models", "cod_make");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCod_make
		{
			get { return (string)returnValueField(FldCod_make); }
			set { insertNameValueField(FldCod_make, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("models", "zzstate");



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
        public static CSGenioAmodels search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
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
        public static List<CSGenioAmodels> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAmodels> listing)
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
        public static List<CSGenioAmodels> SearchListCustom(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAmodels> listing, string[] fields)
        {
			return new List<CSGenioAmodels>();
		}







		// USE /[MANUAL TA3 TABAUX MODELS]/

 
    

	}
}
