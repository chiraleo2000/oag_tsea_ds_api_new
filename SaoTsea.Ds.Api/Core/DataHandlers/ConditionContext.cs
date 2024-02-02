using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DevExpress.Xpo.Metadata;
using Newtonsoft.Json.Linq;
using SaoTsea.Ds.Api.Utility;

namespace SaoTsea.Ds.Api.Core.DataHandlers
{
	public class ConditionContext
	{
		private readonly Dictionary<string, Field> _context;
		private Dictionary<string, string> _mapFieldName;
		public ConditionContext()
		{
			_context = new Dictionary<string, Field>(4);
			RecordStatus = true;
			DeleteFlag = true;
		}

		public bool RecordStatus
		{
			get => _context.ContainsKey("RecordStatus") && _context["RecordStatus"].GetValue<string>() == "A";
			set
			{
				if (!_context.ContainsKey("RecordStatus"))
				{
					string fieldName = "RECORD_STATUS";
					if (_mapFieldName != null && _mapFieldName.ContainsKey("RecordStatus"))
					{
						fieldName = _mapFieldName["RecordStatus"];
					}
					_context["RecordStatus"] = new Field(fieldName, value ? "A" : "");
				}
				else
				{
					_context["RecordStatus"].Value = value ? "A" : "";
				}
			}
		}

		public bool DeleteFlag
		{
			get => _context.ContainsKey("DeleteFlag") && _context["DeleteFlag"].GetValue<string>() == "N";
			set
			{
				if (!_context.ContainsKey("DeleteFlag"))
				{
					string fieldName = "DEL_FLAG";
					if (_mapFieldName != null && _mapFieldName.ContainsKey("DeleteFlag"))
					{
						fieldName = _mapFieldName["DeleteFlag"];
					}
					_context["DeleteFlag"] = new Field(fieldName, value ? "N" : "");
				}
				else
				{
					_context["DeleteFlag"].Value =  value ? "N" : "";
				}
			}
		}

		public int SelfRootId
		{
			get
			{
				if (_context.ContainsKey("SelfRootId"))
				{
					return 0;
				}

				return _context["SelfRootId"].GetValue<int>();
			}
			set
			{
				if (!_context.ContainsKey("SelfRootId"))
				{
					string fieldName = "ORG_ROOT_ID";
					if (_mapFieldName != null && _mapFieldName.ContainsKey("SelfRootId"))
					{
						fieldName = _mapFieldName["SelfRootId"];
					}

					_context["SelfRootId"] = new Field(fieldName, value);
				}
				else
				{
					_context["SelfRootId"].Value = value;
				}
			}
		}

		public int AppId
		{
			get
			{
				if (_context.ContainsKey("AppId"))
				{
					return 0;
				}

				return _context["AppId"].GetValue<int>();
			}
			set
			{
				if (!_context.ContainsKey("AppId"))
				{
					string fieldName = "APP_ID";
					if (_mapFieldName != null && _mapFieldName.ContainsKey("AppId"))
					{
						fieldName = _mapFieldName["AppId"];
					}
					_context["AppId"] = new Field(fieldName, value);
				}
				else
				{
					_context["AppId"].Value = value;
				}
			}
		}

		public void MapFieldName<TPropery>(Expression<Func<ConditionContext, TPropery>> property,
			string fieldName)
		{
			if (property.Body.NodeType != ExpressionType.MemberAccess)
			{
				throw new ArgumentException("NodeType must to ExpressionType.MemberAccess");
			}

			if (_mapFieldName == null)
			{
				_mapFieldName = new Dictionary<string, string>();
			}

			string memberName = (property.Body as MemberExpression).Member.Name;
			if (!_mapFieldName.ContainsKey(memberName))
			{
				_mapFieldName.Add(memberName, fieldName);
			}

			if (_context.ContainsKey(memberName))
			{
				_context[memberName].Name = fieldName;
			}

		}

		public string ToSql(XPClassInfo classInfo)
		{
			//TODO: ทำแบบนี้ไปก่อนพอมีเวลาค่อยมาแก้
			string criteria = "";
			
			foreach (var item in _context)
			{
				if (classInfo.FindMember(item.Value.Name) != null)
				{
					criteria = WhereUtility.And(criteria, CreateAssign(item.Value));
				}
			}

			return criteria;
		}

		public string ToSql(JObject searchObj)
		{
			//TODO: ทำแบบนี้ไปก่อนพอมีเวลาค่อยมาแก้
			string criteria = null;

			foreach (var item in _context)
			{
				criteria = WhereUtility.And(criteria, CreateAssign(item.Value));
			}

			criteria = WhereUtility.And(criteria, WhereUtility.BuildWhere(searchObj));

			return criteria;
		}

		private string CreateAssign(Field field)
		{
			string assign = "";
			if (field.Value is string s && !string.IsNullOrEmpty(s))
			{
				assign = $"{field.Name}='{s}'";
			}
			else if (field.Value is int i && i > 0)
			{
				assign = $"{field.Name}={field.Value}";
			}
			return assign;
		}


		public class Field
		{
			public Field(string name, object value)
			{
				Name = name;
				Value = value;
			}

			public string Name { get; set; }
			public object Value { get; set; }

			public T GetValue<T>()
			{
				return (T) Value;
			}
		}
	}
}