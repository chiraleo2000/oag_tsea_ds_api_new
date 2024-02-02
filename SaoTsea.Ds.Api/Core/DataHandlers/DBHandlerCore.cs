using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Helpers;
using DevExpress.Xpo.Metadata;
using Microsoft.Extensions.Configuration;
using SaoTsea.Ds.Api.Extensions;
using SaoTsea.Ds.Api.Models.ReadModels;
using SaoTsea.Ds.Api.Utility;

namespace SaoTsea.Ds.Api.Core.DataHandlers
{
	public class DBHandlerCore: IXpoUpdate
	{
		public UnitOfWork Session { get; private set; }
		public bool IncludeSystemRecord { get; set; }
		private readonly UserPayload _user;
		private readonly IConfiguration _config;
		private readonly AppSetting _settings;
		private List<XPLiteObject> _updateList;

		public DBHandlerCore(
			BetimesUntiOfWork session,
			UserPayload userInfo,
			ConditionContext conditionContext,
			IConfiguration configuration,
			AppSetting settings)
		{
			_updateList = new List<XPLiteObject>();
			_user = userInfo;
			Session = session;
			IncludeSystemRecord = true;
			_config = configuration;
			_settings = settings;
			ConditionContext = conditionContext;
			StoredProcedure = new StoredProcedureHandler(session);
		}

		public ConditionContext ConditionContext { get; }

		public StoredProcedureHandler StoredProcedure { get; }

		void IXpoUpdate.AddUpdate(XPLiteObject obj)
		{
			_updateList.Add(obj);
		}

		public T CreatePersistent <T>() where T : IXPObject
		{
			return (T) Session.GetClassInfo<T>().CreateNewObject(Session);
		}

		public T CreatePersistent <T>(object key) where T : IXPObject
		{
			T p = (T) Session.GetClassInfo<T>().CreateNewObject(Session);
			p.ClassInfo.KeyProperty.SetValue(p, key);
			return p;
		}

		public T GetPersistent <T>(object key, bool createIfEmpty = false) where T : IXPObject
		{
			var loadedObject = SessionIdentityMap.GetLoadedObjectByKey(Session, Session.GetClassInfo<T>(), key);
			if (loadedObject == null && createIfEmpty)
			{
				return CreatePersistent<T>(key);
			}

			return (T) loadedObject;
		}

		public Task<T> GetObjectAsync <T>(string criteria) where T: IXPObject
		{
			criteria = WhereUtility.And(criteria, ConditionContext.ToSql(Session.GetClassInfo<T>()));
			return Session.FindObjectAsync<T>(CriteriaOperator.Parse(criteria));
		}

		public async Task<T[]> GetObjectListAsync <T>(string criteria) where T: XPLiteObject
		{
			criteria = WhereUtility.And(criteria, ConditionContext.ToSql(Session.GetClassInfo<T>()));
            var sourceCol = Session.GetClassInfo<T>().KeyProperty.Name;
			
			if (Session.GetClassInfo<T>().GetMember("CREATE_DATE") != null)
			{
				sourceCol = "CREATE_DATE";
			}
			XPCollection<T> bag = new XPCollection<T>(Session, CriteriaOperator.Parse(criteria), new SortProperty(
				sourceCol, SortingDirection.Descending));
			await bag.LoadAsync(CancellationToken.None);

			return bag.Count > 0 ? bag.ToArray() : null;
		}

		/// <summary>
		/// สำคัญมากเวลาใช้ ExplicitUnitOfWork อย่าลืมมาปิด connection เอง
		/// </summary>
		public ExplicitUnitOfWork UseExplicitUnitOfWork()
		{
			var session = new ExplicitUnitOfWork(
				new SimpleDataLayer(Session.Dictionary, XpoDefault.GetConnectionProvider(
					_config.GetConnectionString(_settings.DbConnectionName), Session.DataLayer.AutoCreateOption))
			);
			Session = session;
			return session;
		}

		public XPQuery<T> GetXpQuery <T>() where T: XPLiteObject
		{
			var classInfo = Session.GetClassInfo<T>();
			IQueryable<T> query = new XPQuery<T>(Session);
			string condition = "";
			if (ConditionContext.RecordStatus && classInfo.FindMember("RECORD_STATUS") != null)
			{
				condition = WhereUtility.And(condition, "RECORD_STATUS='A'");
			}

			if (ConditionContext.DeleteFlag && classInfo.FindMember("DEL_FLAG") != null)
			{
				condition = WhereUtility.And(condition, "DEL_FLAG='N'");
			}

			if (!string.IsNullOrEmpty(condition))
			{
				CriteriaToExpressionConverter converter = new CriteriaToExpressionConverter();
				query = query.AppendWhere(converter, CriteriaOperator.Parse(condition)) as IQueryable<T>;
			}

			return (XPQuery<T>)query;
		}

		public IQueryable<T> ConvertCriteriaToExpression<T>(string criteria) where T: XPLiteObject
		{
			CriteriaToExpressionConverter converter = new CriteriaToExpressionConverter();
			var source = GetXpQuery<T>();
			return source.AppendWhere(converter, CriteriaOperator.Parse(criteria)) as IQueryable<T>;
		}


		public PersistentObject<T> Entry <T>(T obj) where T : XPLiteObject
		{
			return new PersistentObject<T>(obj);
		}

		public Task<T[]> GetObjectListAsync <T>() where T: XPLiteObject
		{
			return GetObjectListAsync<T>("");
		}

		public async Task<T> GetObjectByKeyAsync <T>(object key, bool alwaysGetFromDataStore = false)
		{
			return (T) (await GetObjectByKeyAsync(typeof(T), key, alwaysGetFromDataStore));
		}

		public async Task<object> GetObjectByKeyAsync(Type classType, object key, bool alwaysGetFromDataStore)
		{
			return await Session.GetObjectByKeyAsync(classType, key, alwaysGetFromDataStore);
		}

		public async Task CommitChangesAsync()
		{
			if (_updateList.Count > 0)
			{
				for (int i = 0; i < _updateList.Count; i++)
				{
					UpdateObject(_updateList[i]);
				}
				_updateList.Clear();
			}
			await Session.CommitChangesAsync();
			//Session.DropIdentityMap();
		}

		public void ClearAllChanges()
		{
			Session.DropChanges();
		}

		public void ClearCache <T>()
		{
			SessionIdentityMap.UnregisterObject(Session, typeof(T));
		}

		public T InsertObject <T>(T value) where T : XPLiteObject
		{
			T newValue = value;
			if (!ReferenceEquals(Session, value.Session))
			{
				newValue = XpoHelper.Clone(value, Session);
			}

			if (IncludeSystemRecord)
			{
				newValue.TrySetMemberValue("CREATE_DATE", DateTime.Now);
				newValue.TrySetMemberValue("CREATE_USER_ID", _user.UserId);
				if (!newValue.HasValue("DEL_FLAG"))
				{
					newValue.TrySetMemberValue("DEL_FLAG", "N");
				}

				if (!newValue.HasValue("RECORD_STATUS"))
				{
					newValue.TrySetMemberValue("RECORD_STATUS", "A");
				}
			}

			return newValue;
		}

		public T UpdateObject <T>(T value) where T : XPLiteObject
		{
			T newValue = value;
			var keyValue = value.Session.GetKeyValue(value);

			if (!ReferenceEquals(Session, value.Session))
			{
				newValue = XpoHelper.Clone(value, Session, true);
			}

			var loadedObject = SessionIdentityMap.GetLoadedObjectByKey(Session, newValue.ClassInfo, keyValue);

			//ตรวจสอบว่ามี cache ไหมถ้ามี ดูอีกว่าค่าที่เราส่งมา update มันเป็นตัวเดียวกันกับใน cache หรือไม่
			if (loadedObject != null && !ReferenceEquals(loadedObject, value))
			{
				SessionIdentityMap.UnregisterObject(Session, loadedObject);
				SessionIdentityMap.RegisterObject(Session, newValue, keyValue);
			}
			else if (loadedObject == null)
			{
				SessionIdentityMap.RegisterObject(Session, newValue, keyValue);
			}

			if (IncludeSystemRecord)
			{
				newValue.TrySetMemberValue("UPDATE_DATE", DateTime.Now);
				newValue.TrySetMemberValue("UPDATE_USER_ID", -1);
			}

			return newValue;
		}

		public T DeleteObject <T>(int key, bool softDelete = true) where T : XPLiteObject
		{
			var obj = CreatePersistent<T>(key);
			if (obj.ClassInfo.FindMember("DEL_FLAG") != null && softDelete)
			{
				obj.SetMemberValue("DEL_FLAG", "Y");
			}
			else
			{
				obj.Delete();
			}

			return UpdateObject(obj);
		}

		public Task<int> DirectDeleteAsync <T>(int key) where T : IXPObject
		{
			XPClassInfo classInfo = Session.GetClassInfo(typeof(T));
			var keyName = classInfo.KeyProperty.MappingField;
			string sql = $"DELETE FROM {classInfo.TableName} WHERE {keyName}={key}";
			return Session.ExecuteNonQueryAsync(sql);
		}
	}

}