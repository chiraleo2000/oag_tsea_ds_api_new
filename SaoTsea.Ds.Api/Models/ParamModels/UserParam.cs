namespace SaoTsea.Ds.Api.Models.ParamModels
{
    public class UserParam
    {
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string SessionId { get; set; }
        public string NewPassword { get; set; }
        public string Otp { get; set; }
    }
}
