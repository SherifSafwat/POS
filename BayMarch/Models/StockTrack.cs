using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BayMarch.Models
{
    public class StockTrack : MasterBaseModel
    {
        public long StockTrackId { get; set; }

        //Data
        public long TrxDate { get; set; }
        public long TrxType { get; set; }
        public string ProductId { get; set; }
        public long WareHouseId { get; set; }
        public long LastValue { get; set; }
        public long TrxValue { get; set; }
        public long CurrentValue { get; set; }
        public bool Last { get; set; }
       
        // select  lastvalue where Last=true *  update last = false * create new row with last=ture , se lastval & trxval & currentval =  lastval + trxval

    }
}
