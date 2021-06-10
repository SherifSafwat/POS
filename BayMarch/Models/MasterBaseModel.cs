using System;
namespace BayMarch.Models
{
    public class MasterBaseModel
    {
        //Data
        public long Number{ get; set; }
        public string EName { get; set; }
        public string AName { get; set; }
        public string DataComment { get; set; }

        //Info
        public string InfoName1 { get; set; }
        public string InfoName2 { get; set; }
        public string InfoName3 { get; set; }
        public string InfoName4 { get; set; }
        public string InfoName5 { get; set; }
        public string InfoValue1 { get; set; }
        public string InfoValue2 { get; set; }
        public string InfoValue3 { get; set; }
        public string InfoValue4 { get; set; }
        public string InfoValue5 { get; set; }


        //Comments
        public string Comment1 { get; set; }
        public string Comment2 { get; set; }
        public string Comment3 { get; set; }
        public string Comment4 { get; set; }
        public string Comment5 { get; set; }


        //Hierarchy
        public long SourceId { get; set; } //system or sellerid
        public long SellerId { get; set; }
        public long UserId { get; set; }
        public string BranchId { get; set; }

        //Security
        public bool Enabled { get; set; }
        public string GrantBy { get; set; }  //userid
        public DateTime GrantFromDate { get; set; }
        public DateTime GrantToDate { get; set; }
        public string GrantComment { get; set; }

        //System
        public DateTime CreationDate { get; set; }
        public string CreatedID { get; set; }
        public DateTime UpdatingDate { get; set; }
        public string UpdatedID { get; set; }
        public string SysComment { get; set; }
    }
}
