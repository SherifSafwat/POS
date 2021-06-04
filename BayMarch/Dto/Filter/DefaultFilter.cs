namespace BayMarch.Dto.Filter
{
    public class DefaultFilter
    {
        //public bool Filter = false;
        //public bool IsDesc = false;
        //public long PageNumber = 1;
        public int MaxPageSize = 50;
        //public string Orderby = "CreationDate";

        //Filter
        public long Id { get; set; }
        public long Number { get; set; }
        public string EName { get; set; }
        public string AName { get; set; }
        public string DataComment { get; set; }

        //Data
        public bool Filter { get; set; }
        public bool IsDesc { get; set; }
        public long PageNumber { get; set; }
        public string Orderby { get; set; }

    }
}
