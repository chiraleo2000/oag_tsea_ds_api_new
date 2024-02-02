using System.Text.RegularExpressions;

namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class StartProcessBusinessKey
	{
		private const string _bnId = "bnId";
		private const string _smId = "smId";
		private const string _fcId = "fcId";
		private const string _bpmId = "bpmId";

		public StartProcessBusinessKey(int backendId, int bpmId, string submitId, string formConfigId)
		{
			BackendId = backendId;
			SubmissionId = submitId;
			FormConfigId = formConfigId;
			BpmId = bpmId;
		}

		public StartProcessBusinessKey() {}

		public int BpmId { get; set; }
		public int BackendId { get; set; }
		public string SubmissionId { get; set; }
		public string FormConfigId { get; set; }

		public override string ToString()
		{
			return $"{_bnId}={BackendId};{_smId}={SubmissionId};{_fcId}={FormConfigId};{_bpmId}={BpmId}";
		}

		public static implicit operator string(StartProcessBusinessKey v)
		{
			return v.ToString();
		}

		public static StartProcessBusinessKey FromBusinessKey(string busKey)
		{
			Regex rx =new Regex(@"(?<prop>\w+)=(?<value>[^\s;]+)");
			MatchCollection matches = rx.Matches(busKey);

			if (matches.Count == 0)
			{
				return null;
			}

			StartProcessBusinessKey ins = new StartProcessBusinessKey();
			foreach (Match match in matches)
			{
				switch (match.Groups["prop"].Value)
				{
					case _bnId:
					{
						if (!int.TryParse(match.Groups["value"].Value, out int id))
						{
							return null;
						}
						ins.BackendId = id;
						break;
					}
					case _smId:
					{
						ins.SubmissionId = match.Groups["value"].Value;
						break;
					}
					case _fcId:
					{
						ins.FormConfigId = match.Groups["value"].Value;
						break;
					}
					case _bpmId:
					{
						if (!int.TryParse(match.Groups["value"].Value, out int id))
						{
							return null;
						}
						ins.BpmId = id;
						break;
					}
				}
			}

			return ins;
		}
	}
}
