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
	public class Models : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmodels klass { get { return baseklass as CSGenioAmodels; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Models.ValCodmodels")]
		public string ValCodmodels { get { return klass.ValCodmodels; } set { klass.ValCodmodels = value; } }

		[DisplayName("Model")]
		/// <summary>Field : "Model" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Models.ValModel_name")]
		public string ValModel_name { get { return klass.ValModel_name; } set { klass.ValModel_name = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Models.ValCod_make")]
		public string ValCod_make { get { return klass.ValCod_make; } set { klass.ValCod_make = value; } }

		private Make _make;
		[DisplayName("Make")]
		[ShouldSerialize("Make")]
		public virtual Make Make
		{
			get
			{
				if (!isEmptyModel && (_make == null || (!string.IsNullOrEmpty(ValCod_make) && (_make.isEmptyModel || _make.klass.QPrimaryKey != ValCod_make))))
					_make = Models.Make.Find(ValCod_make, m_userContext, Identifier, _fieldsToSerialize);
				_make ??= new Models.Make(m_userContext, true, _fieldsToSerialize);
				return _make;
			}
			set { _make = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Models.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Models(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAmodels(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Models(UserContext userContext, CSGenioAmodels val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAmodels csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "make":
						_make ??= new Make(m_userContext, true, _fieldsToSerialize);
						_make.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Models Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmodels>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Models(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Models> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmodels>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Models>((r) => new Models(userCtx, r));
		}

// USE /[MANUAL TA3 MODEL MODELS]/
	}
}
