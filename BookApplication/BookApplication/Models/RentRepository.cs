using BookApplication.Utility;

namespace BookApplication.Models
{
    public class RentRepository : Repository<Rent>, IRentRepository
    {
        private  ApplicationDbContext _applicationDbContext;
        public RentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Update(Rent rent)
        {
            _applicationDbContext.Update(rent);
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }

}
