using System;
using System.Linq.Expressions;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace SaoTsea.Ds.Api.Core.DataHandlers
{
	public class PersistentObject <TXpo> where TXpo : XPLiteObject
	{
		private TXpo _xpo;

		public PersistentObject(TXpo xpo)
		{
			_xpo = xpo;
		}

		public bool GetModified <TPropery>(Expression<Func<TXpo, TPropery>> property)
		{
			if (property.Body.NodeType != ExpressionType.MemberAccess)
			{
				throw new ArgumentException("NodeType must to ExpressionType.MemberAccess");
			};

			string memberName = (property.Body as MemberExpression).Member.Name;
			XPMemberInfo xpoMember = _xpo.ClassInfo.GetMember(memberName);
			return xpoMember.GetModified(_xpo);
		}

		public void SetModified <TPropery>(Expression<Func<TXpo, TPropery>> property)
		{
			SetModified(property, null);
		}

		public void SetModified <TPropery>(Expression<Func<TXpo, TPropery>> property,
			object oldValue)
		{
			if (property.Body.NodeType != ExpressionType.MemberAccess)
			{
				throw new ArgumentException("NodeType must to ExpressionType.MemberAccess");
			}

			string memberName = (property.Body as MemberExpression).Member.Name;
			XPMemberInfo xpoMember = _xpo.ClassInfo.GetMember(memberName);
			xpoMember.SetModified(_xpo, oldValue);
		}
	}
}