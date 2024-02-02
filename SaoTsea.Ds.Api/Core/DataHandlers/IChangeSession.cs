using DevExpress.Xpo;

namespace SaoTsea.Ds.Api.Core.DataHandlers
{
	public interface IChangeSession
	{
		void ChangeSession(UnitOfWork session);
	}
}