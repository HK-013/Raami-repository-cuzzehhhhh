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
	public class Chassis_code : ModelBase
	{
		[JsonIgnore]
		public CSGenioAchassis_code klass { get { return baseklass as CSGenioAchassis_code; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Chassis_code.ValCodchassis_code")]
		public string ValCodchassis_code { get { return klass.ValCodchassis_code; } set { klass.ValCodchassis_code = value; } }

		[DisplayName("Chassis Code")]
		/// <summary>Field : "Chassis Code" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Chassis_code.ValCode_name")]
		public string ValCode_name { get { return klass.ValCode_name; } set { klass.ValCode_name = value; } }

		[DisplayName("Year")]
		/// <summary>Field : "Year" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Chassis_code.ValYear_range")]
		public string ValYear_range { get { return klass.ValYear_range; } set { klass.ValYear_range = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Chassis_code.ValCod_models")]
		public string ValCod_models { get { return klass.ValCod_models; } set { klass.ValCod_models = value; } }

		private Models _models;
		[DisplayName("Models")]
		[ShouldSerialize("Models")]
		public virtual Models Models
		{
			get
			{
				if (!isEmptyModel && (_models == null || (!string.IsNullOrEmpty(ValCod_models) && (_models.isEmptyModel || _models.klass.QPrimaryKey != ValCod_models))))
					_models = Models.Models.Find(ValCod_models, m_userContext, Identifier, _fieldsToSerialize);
				_models ??= new Models.Models(m_userContext, true, _fieldsToSerialize);
				return _models;
			}
			set { _models = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Chassis_code.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Chassis_code(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAchassis_code(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Chassis_code(UserContext userContext, CSGenioAchassis_code val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAchassis_code csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "models":
						_models ??= new Models(m_userContext, true, _fieldsToSerialize);
						_models.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Chassis_code Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAchassis_code>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Chassis_code(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Chassis_code> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAchassis_code>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Chassis_code>((r) => new Chassis_code(userCtx, r));
		}

// USE /[MANUAL TA3 MODEL CHASSIS_CODE]/
	}
}
