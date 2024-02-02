namespace SaoTsea.Ds.Api.Models.ParamModels.SSO
{
    public class SSOParam
    {
        public class SSORequest
        {
            public string userName { get; set; }
            public string password { get; set; }
            public string otp { get; set; }
        }

        public class SSOResponse
        {
            public string result { get; set; }
            public string statusDescription { get; set; }
            public string status { get; set; }
            public string statusCode { get; set; }
        }
    }
}
