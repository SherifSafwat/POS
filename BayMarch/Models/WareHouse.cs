using System.ComponentModel.DataAnnotations.Schema;

namespace BayMarch.Models
{
    [Table("WareHouse")]
    public class WareHouse : MastrerBaseModel
    {
        public long WareHouseId { get; set; }

        //Data
        public long WarehouseNum { get; set; }
        public long AreaId { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }

    }
}
