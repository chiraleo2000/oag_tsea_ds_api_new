using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Core.DataHandlers
{
	public class StoredProcedureHandler : IChangeSession
	{
		private UnitOfWork _session;
		public StoredProcedureHandler(UnitOfWork session)
		{
			_session = session;
		}

		void IChangeSession.ChangeSession(UnitOfWork session)
		{
			_session = session;
		}

		public async Task<List<OrganizeAppResult>> GetsApp(int userId, int orgRootId)
		{
			OperandValue[] args =
			{
				new OperandValue(userId),
				new OperandValue(orgRootId)
			};
			return (await GetObjectFromSprocAsync<OrganizeAppResult>("get_apps", args));
		}

		public async Task<List<OrganizePkiResult>> GetsOrganizePki(int orgId)
		{
			OperandValue[] args =
			{
				new OperandValue(orgId)
			};
			return (await GetObjectFromSprocAsync<OrganizePkiResult>("get_organize_pki", args));
		}

		public Task<PagingResult<SearchOrganizeResult>> SearchOrganize(string condition, int? offset, int? length)
		{
			return GetObjectFromSprocPagingAsync<SearchOrganizeResult>("search_organize", new OperandValue(condition),
				new OperandValue(offset ?? 0), new OperandValue(length));
		}

		public async Task<StatusResult> CreateRolePermission(int roleId, int appId)
		{
			var resultSet = await _session.ExecuteSprocAsync(CancellationToken.None, "create_role_permission",
				new OperandValue(roleId), new OperandValue(appId));
			return ConvertToStoredProcResult(resultSet);
		}

		public async Task<List<DashbordMenu>> GetsDashbord(int userId, string appCode)
		{
			OperandValue[] args =
			{
				new OperandValue(userId),
				new OperandValue(appCode)
			};
			return (await GetObjectFromSprocAsync<DashbordMenu>("get_dashbord", args));
		}
		public async Task<List<ProcInstRelationResult>> GetProcInstDistinctRelation(int instId)
		{
			OperandValue[] args =
			{
				new OperandValue(instId)
			};

			return (await GetObjectFromSprocAsync<ProcInstRelationResult>("get_proc_inst_distinct_relation", args));
		}

		public async Task<StatusResult> MergeAppointment(int fromCaseId, int toCaseId, int user_id)
		{
			var resultSet = await _session.ExecuteSprocAsync(CancellationToken.None, "merge_appointment",
				new OperandValue(fromCaseId), new OperandValue(toCaseId), new OperandValue(user_id));
			return ConvertToStoredProcResult(resultSet);
		}
		public async Task<ModuleCodeSeqLast> GetModuleCodeSeqLast(int appId)
		{
			return (await GetObjectFromSprocAsync<ModuleCodeSeqLast>("get_last_seq_module_code", appId)).FirstOrDefault();
		}
		public Task<PagingResult<SearchPersonalResult>> SearchPersonal(string condition, int? offset, int? length)
		{
			return GetObjectFromSprocPagingAsync<SearchPersonalResult>("search_personal", new OperandValue(condition),
				new OperandValue(offset ?? 0), new OperandValue(length));
		}

		public async Task<List<Menu>> GetsMenu(int userId, string appCode)
		{
			OperandValue[] args =
			{
				new OperandValue(userId),
				new OperandValue(appCode)
			};
			return (await GetObjectFromSprocAsync<Menu>("get_menus", args));
		}

		public async Task<List<UserRoleEntity>> GetRoleUser(int userId , string appcode)
		{
			OperandValue[] args =
   {
		new OperandValue(userId),

        new OperandValue(appcode)
    };

			List<UserRoleEntity> user_list = await GetObjectFromSprocAsync<UserRoleEntity>("get_user_role", args);

			if (user_list == null)
			{
				return new List<UserRoleEntity>(); // Return an empty list if the result is null
			}

			return user_list;
		}



		public Task<PagingResult<SearchSubDistrict>> SearchSubDistrict(string condition, int? offset, int? length)
		{
			return GetObjectFromSprocPagingAsync<SearchSubDistrict>("search_sub_district", new OperandValue(condition),
				new OperandValue(offset ?? 0), new OperandValue(length));
		}
		public Task<PagingResult<SearchPostCode>> SearchPostCode(string condition, int? offset, int? length)
		{
			return GetObjectFromSprocPagingAsync<SearchPostCode>("search_post_code", new OperandValue(condition),
				new OperandValue(offset ?? 0), new OperandValue(length));
		}
		private async Task<PagingResult<T>> GetObjectFromSprocPagingAsync<T>(string sprocName,
	params OperandValue[] parameters)
		{
			var resultSet = await _session.ExecuteSprocAsync(CancellationToken.None,
				sprocName, parameters);
			var rows = resultSet.ResultSet.LastOrDefault()?.Rows;
			var totalCountRow = rows?.GetValue(rows.Length - 1) as SelectStatementResultRow;
			int totalCount = 0;

			if (totalCountRow == null || !totalCountRow.Values[0].Equals("total_count"))
			{
				throw new NullReferenceException("TotalCount not found");
			}

			if (totalCountRow.Values[1] != null)
			{
				if (!int.TryParse(totalCountRow.Values[1].ToString(), out totalCount))
				{
					throw new InvalidCastException("TotalCount must is number");
				}
			}

			var data = Materialize<T>(resultSet.ResultSet[0]?.Rows, 1);

			return new PagingResult<T>(data, totalCount);
		}

		private StatusResult ConvertToStoredProcResult(SelectedData s)
		{
			var resultSet = GetStatementResult(s);

			var procResult = new StatusResult(
				resultSet.Rows[1].Values[1]?.ToString() ?? "",
				(int) resultSet.Rows[0].Values[1],
				(int) resultSet.Rows[0].Values[1] == 0
			);

			return procResult;
		}

		private SelectStatementResult GetStatementResult(SelectedData s)
		{
			if (s == null)
			{
				throw new NullReferenceException("s is null");
			}

			//Find @STATUS_OUT
			var resultSet = s.ResultSet.FirstOrDefault(
				_ => _.Rows.Length > 1 && _.Rows[0].Values[0].ToString().ToLower() == "_status_out");

			if (resultSet == null)
				throw new Exception("StoredProc return empty resultSet");

			return resultSet;
		}

		private async Task<List<T>> GetObjectFromSprocAsync<T>(string sprocName, params OperandValue[] parameters)
		{
			var resultSet = await _session.ExecuteSprocAsync(CancellationToken.None,
				sprocName, parameters);
			var rows = resultSet.ResultSet.FirstOrDefault()?.Rows;

			return Materialize<T>(rows);
		}
        
		private List<T> Materialize<T>(SelectStatementResultRow[] resutSet, int skipLast = 0)
		{
			if (resutSet?.Length == 0)
			{
				return null;
			}

			List<T> list = new List<T>(resutSet.Length);
			T newValue = Activator.CreateInstance<T>();
			Type newValueType = null;
			var properyNames = newValue.GetType().GetProperties()
									   .Where(p => !Attribute.IsDefined(p, typeof(ExcludeFromResultSetAttribute)))
									   .Select(p => p.Name)
									   .ToArray();


			foreach (var item in resutSet)
			{
				int itemCount = item.Values.Length;
				if (newValueType != null)
				{
					newValue = Activator.CreateInstance<T>();
				}

				newValueType = newValue.GetType();

                if (properyNames.Length != item.Values.Length - skipLast)
                {
                    throw new Exception("ResultSet count not match with type: " + newValueType);
                }

                string pname = "";
                try
                {
                    for (int i = 0; i < itemCount - skipLast; i++)
                    {
                        pname = properyNames[i];
                        var property = newValueType.GetProperty(pname);
                        object value = item.Values[i];
                        property.SetValue(newValue, value);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message + $" # at field: {pname}", e);
                }

				list.Add(newValue);
			}

			return list;
		}
		
	}


}
