using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.Models
{
	public class Upgrade : ModelBase
	{
		[JsonIgnore]
		public CSGenioAupgrade klass { get { return baseklass as CSGenioAupgrade; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Upgrade.ValCodupgrade")]
		public string ValCodupgrade { get { return klass.ValCodupgrade; } set { klass.ValCodupgrade = value; } }

		[DisplayName("Part Name")]
		/// <summary>Field : "Part Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Upgrade.ValPart_name")]
		public string ValPart_name { get { return klass.ValPart_name; } set { klass.ValPart_name = value; } }

		[DisplayName("Stage")]
		/// <summary>Field : "Stage" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Upgrade.ValStage")]
		public string ValStage { get { return klass.ValStage; } set { klass.ValStage = value; } }

		[DisplayName("Price")]
		/// <summary>Field : "Price" Tipo: "$D" Formula:  ""</summary>
		[ShouldSerialize("Upgrade.ValPrice")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrice { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPrice, 2)); } set { klass.ValPrice = Convert.ToDecimal(value); } }

		[DisplayName("Click here to buy product")]
		/// <summary>Field : "Click here to buy product" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Upgrade.ValBuy_link")]
		public string ValBuy_link { get { return klass.ValBuy_link; } set { klass.ValBuy_link = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Upgrade.ValCod_chassis")]
		public string ValCod_chassis { get { return klass.ValCod_chassis; } set { klass.ValCod_chassis = value; } }

		private Chassis_code _chassis_code;
		[DisplayName("Chassis_code")]
		[ShouldSerialize("Chassis_code")]
		public virtual Chassis_code Chassis_code
		{
			get
			{
				if (!isEmptyModel && (_chassis_code == null || (!string.IsNullOrEmpty(ValCod_chassis) && (_chassis_code.isEmptyModel || _chassis_code.klass.QPrimaryKey != ValCod_chassis))))
					_chassis_code = Models.Chassis_code.Find(ValCod_chassis, m_userContext, Identifier, _fieldsToSerialize);
				_chassis_code ??= new Models.Chassis_code(m_userContext, true, _fieldsToSerialize);
				return _chassis_code;
			}
			set { _chassis_code = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Upgrade.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Upgrade(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAupgrade(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Upgrade(UserContext userContext, CSGenioAupgrade val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAupgrade csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "chassis_code":
						_chassis_code ??= new Chassis_code(m_userContext, true, _fieldsToSerialize);
						_chassis_code.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Upgrade Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAupgrade>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Upgrade(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Upgrade> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAupgrade>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Upgrade>((r) => new Upgrade(userCtx, r));
		}

// USE /[MANUAL TA3 MODEL UPGRADE]/
	}
}
