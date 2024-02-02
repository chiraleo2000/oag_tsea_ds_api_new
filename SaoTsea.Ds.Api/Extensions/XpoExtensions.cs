using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace SaoTsea.Ds.Api.Extensions
{
	public static class XpoExtensions
	{
		public static bool HasValue(this IXPObject xpo, string memberName)
		{
			XPMemberInfo m = xpo.ClassInfo.FindMember(memberName);
			return m?.GetValue(xpo) != null;
		}

		public static bool TrySetMemberValue(this IXPObject xpo, string propertyName, object newValue)
		{
			XPMemberInfo m = xpo.ClassInfo.FindMember(propertyName);
			if (m != null)
			{
				m.SetValue(xpo, newValue);
				return true;
			}

			return false;
		}
	}
}