using Newtonsoft.Json.Linq;

namespace SaoTsea.Ds.Api.Models.ParamModels
{
    public class SearchParam : OffsetParam
    {
        public JObject Condition { get; set; }
    }
}
