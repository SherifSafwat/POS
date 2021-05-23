namespace BayMarch.Dto.Request
{
    public class PageReq
    {
        public int First = 1;
        public string Orderby = "CreationDate";
        public int MaxPageSize = 50;
        public long TotalPages { get; set; }
    }
}
