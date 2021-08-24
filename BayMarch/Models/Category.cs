namespace BayMarch.Models
{
    public class Category : MasterBaseModel
    {
        public long CategoryId { get; set; }

        //Foreign
        public long ParentCategoryId { get; set; }        
    }
}
