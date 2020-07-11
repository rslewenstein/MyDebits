using MyDebits.Domain;

namespace MyDebits.Repository
{
    public interface IMyDebitsRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         bool SaveChanges();

         //Debits
         Debit[] GetAllDebits();
         Debit GetDebitById(int id);

         //Category
         Category[] GetAllCategories();
         Category GetCategoryById(int id);

         //Payment Method
         PaymentMethod[] GetAllPaymentMethods();
         PaymentMethod GetPaymentMethodById(int id);
    }
}