using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.DTO
{
    internal class Voucher
    {
        public string voucherId { get; set; }
        public string voucherName { get; set; }
        public string voucherStatus { get; set; }
        public string voucherDescription { get; set;}
        public string voucherCondition { get; set;}
        public DateTime voucherDateTimeIn { get; set;}
        public DateTime voucherDateTimeOut { get; set;}
    }
}
