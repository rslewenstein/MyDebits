using System;

namespace MyDebits.Domain
{
    public class Debit
    {
        public Debit (){}
        public Debit(int id, 
                     string description,
                     DateTime datedebit,
                     decimal debitValue,
                     int? quota)
        {
            this.Id = id;
            this.Description = description;
            this.DateDebit = datedebit;
            this.DebitValue = debitValue;
            this.Quota = quota;
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public DateTime DateDebit { get; set; }
        public decimal DebitValue { get; set; }
        public int? Quota { get; set; }
        public int? PaymentMethodId { get; set; }

        public Category Category { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}