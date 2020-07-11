namespace MyDebits.Domain
{
    public class Category
    {
        public Category(){}

        public Category(int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}