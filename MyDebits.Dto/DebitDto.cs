using System;

namespace MyDebits.Dto
{
    public class DebitDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public DateTime DateDebit { get; set; }
        public decimal DebitValue { get; set; }
        public int? Quota { get; set; }
        public int? PaymentMethodId { get; set; }
    }
}