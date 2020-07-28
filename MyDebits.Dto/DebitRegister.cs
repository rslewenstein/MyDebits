using System;

namespace MyDebits.Dto
{
    public class DebitRegister
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; } = null;
        public DateTime DateDebit { get; set; }
        public decimal DebitValue { get; set; }
        public int? Quota { get; set; } = null;
        public int? PaymentMethodId { get; set; } = null;
    }
}