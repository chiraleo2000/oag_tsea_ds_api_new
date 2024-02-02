using SaoTsea.Ds.Api.Core;
using SaoTsea.Ds.Api.EntitiesCode;

namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class RoleUserParam : INeedXpoBinding
	{
		public ADM_ROLE_INFO RoleInfo { get; set; }
		public ADM_USER_ROLE[] UserRole { get; set; }
	}
}
