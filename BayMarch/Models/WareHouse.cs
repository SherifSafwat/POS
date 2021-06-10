namespace BayMarch.Models
{
    public class WareHouse : MasterWithContact
    {
        public long WareHouseId { get; set; }

        //Data
        public long AreaId { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}
