namespace BayMarch.Models
{
    public class ParentCategory : MasterBaseModel
    {
        public long ParentCategoryId { get; set; }

        //Foreign
        public long TypeId { get; set; }
    }
}
