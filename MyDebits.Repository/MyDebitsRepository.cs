using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyDebits.Domain;

namespace MyDebits.Repository
{
    public class MyDebitsRepository : IMyDebitsRepository
    {
        private readonly MyDebitsContext _context;

        public MyDebitsRepository(MyDebitsContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }


        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Debit[] GetAllDebits()
        {
            IQueryable<Debit> query = _context.Debits;

            query = query.AsNoTracking().OrderBy(q => q.Id);

            return query.ToArray();
        }

        public Debit GetDebitById(int id)
        {
            IQueryable<Debit> query = _context.Debits;

            query = query.AsNoTracking()
                         .OrderBy(x => x.Id)
                         .Where(x => x.Id == id);
            
            return query.FirstOrDefault();
        }

        public Category[] GetAllCategories()
        {
            IQueryable<Category> query = _context.Categories;

            query = query.AsNoTracking().OrderBy(q => q.Id);
            
            return query.ToArray();
        }

        public Category GetCategoryById(int id)
        {
            IQueryable<Category> query = _context.Categories;

            query = query.AsNoTracking()
                         .OrderBy(x => x.Id)
                         .Where(x => x.Id == id);
            
            return query.FirstOrDefault();
        }

        public PaymentMethod[] GetAllPaymentMethods()
        {
            IQueryable<PaymentMethod> query = _context.PaymentMethods;

            query = query.AsNoTracking().OrderBy(q => q.Id);

            return query.ToArray();
        }

        public PaymentMethod GetPaymentMethodById(int id)
        {
            IQueryable<PaymentMethod> query = _context.PaymentMethods;

            query = query.AsNoTracking()
                         .OrderBy(x => x.Id)
                         .Where(x => x.Id == id);
            
            return query.FirstOrDefault();
        }
    }
}