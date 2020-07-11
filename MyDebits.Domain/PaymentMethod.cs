namespace MyDebits.Domain
{
    public class PaymentMethod
    {
        public PaymentMethod(){}

        public PaymentMethod(int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }
        public int Id { get; set; }
        public string Description { get; set; }
    }
}