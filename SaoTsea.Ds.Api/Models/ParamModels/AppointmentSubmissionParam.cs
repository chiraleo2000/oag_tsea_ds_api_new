using Newtonsoft.Json.Linq;

namespace SaoTsea.Ds.Api.Models.ParamModels
{
    public class AppointmentSubmissionParam
    {
        public JObject Submission { get; set; }
        public string FormCode { get; set; }
        public string DocumentId { get; set; }
    }
}
