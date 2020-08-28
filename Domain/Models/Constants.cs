namespace Domain.Models
{
    public static class Constants
    {
#if DEBUG
        public const string DefaultConnection = "Server=DESKTOP-JPQ21PS;Database=TestBd;Trusted_Connection=True;MultipleActiveResultSets=true";
        

#else
        //.102
        public const string DefaultConnection =
            "Server=SP-VL;Database=TestBd;Persist Security Info=True;User ID=xxx;Password=xxx";

#endif
    }
}
