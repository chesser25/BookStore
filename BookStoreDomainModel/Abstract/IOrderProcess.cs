using BookStoreDomainModel.Entities;

namespace BookStoreDomainModel.Abstract
{
    public interface IOrderProcess
    {
        void Order(Cart cart, Order order);
    }
}
