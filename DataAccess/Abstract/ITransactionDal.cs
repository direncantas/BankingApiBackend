using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ITransactionDal : IEntityRepository<Transaction>
    {
    }
}
