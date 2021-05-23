using Microsoft.AspNetCore.Identity;
using System;

namespace BayMarch.Data
{
    public class ApplicationUser : IdentityUser
    {
        //ID
        public long ParamId { get; set; }
        //public Param ParamObj { get; set; }
        public long SellerId { get; set; }
        //public Seller SellerObj { get; set; }
        public long WareHouseId { get; set; }
        //public Warehouse WareHouseObj { get; set; }
        public string RoleId { get; set; }
        public string DeviceId { get; set; }

        //Data
        public string EName { get; set; }
        public string AName { get; set; }
        public string GenUserName { get; set; }  //Gen
        public string DataComment { get; set; }

        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public string Contact3 { get; set; }
        public string Contact4 { get; set; }
        public string Contact5 { get; set; }

        //Comments
        public string Comment1 { get; set; }
        public string Comment2 { get; set; }
        public string Comment3 { get; set; }
        public string Comment4 { get; set; }
        public string Comment5 { get; set; }

        //Hierarchy
        public long SourceId { get; set; }            //system or sellerid
        public long OwnerId { get; set; }             //sellerid
        public string BranchId { get; set; }

        //Security
        public bool Enabled { get; set; }
        public string GrantBy { get; set; }          //userid
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