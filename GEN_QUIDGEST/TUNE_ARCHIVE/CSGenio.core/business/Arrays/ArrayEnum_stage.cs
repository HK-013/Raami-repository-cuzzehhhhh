using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array ENUM_STAGE (Stage)
	/// </summary>
	public class ArrayEnum_stage : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayEnum_stage _instance = new ArrayEnum_stage();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayEnum_stage Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Stage 1
		/// </summary>
		public const string E_1_1 = "1";
		/// <summary>
		/// Stage 2
		/// </summary>
		public const string E_2_2 = "2";
		/// <summary>
		/// Stage 3
		/// </summary>
		public const string E_3_3 = "3";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayEnum_stage"/> class from being created.
		/// </summary>
		private ArrayEnum_stage() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_1_1, new ArrayElement() { ResourceId = "STAGE_120545", HelpId = "", Group = "" } },
				{ E_2_2, new ArrayElement() { ResourceId = "STAGE_220652", HelpId = "", Group = "" } },
				{ E_3_3, new ArrayElement() { ResourceId = "STAGE_320799", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(string cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<string> GetElements()
		{
			return Instance.GetElementsImpl();
		}

		/// <summary>
		/// Gets the element.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static ArrayElement GetElement(string cod)
		{
            return Instance.GetElementImpl(cod);
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<string, string> GetDictionary()
		{
			return Instance.GetDictionaryImpl();
		}

		/// <summary>
		/// Gets the help identifier.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string GetHelpId(string cod)
		{
			return Instance.GetHelpIdImpl(cod);
		}
	}
}
