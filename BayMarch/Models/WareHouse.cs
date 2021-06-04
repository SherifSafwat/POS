namespace BayMarch.Models
{
    public class WareHouse : MastrerWithContact
    {
        public long WareHouseId { get; set; }

        //Data
        public long WarehouseNum { get; set; }
        public long AreaId { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}
