using System;
namespace BayMarch.Models
{
    public class Seller 
    {
        public long SellerId { get; set; }

        //Data
        public long SellerNum { get; set; }
        public string EName { get; set; }
        public string AName { get; set; }
        public string DataComment { get; set; }
        public string StoreName { get; set; }
        public string TaxNumber { get; set; }
        public string RegisterNumber { get; set; }

        //Contact
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Email4 { get; set; }
        public string Email5 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public string Contact3 { get; set; }
        public string Contact4 { get; set; }
        public string Contact5 { get; set; }
        public string Person1 { get; set; }
        public string Person2 { get; set; }
        public string Person3 { get; set; }
        public string Person4 { get; set; }
        public string Person5 { get; set; }

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

        //Foreign
        public long TypeId { get; set; }

        //Hierarchy
        public long SourceId { get; set; } //system or sellerid
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
