namespace Facens.Api.Extensions
{
    public class ApiTokenSettings
    {
        public string Secret { get; set; }
        public int TimeExpire { get; set; }
        public string Emission { get; set; }
        public string ValidIn { get; set; }
    }
}
