using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using BookStoreService.EF;

namespace BookStoreService.Interfaces
{
    [ServiceContract]
    public interface IOrder
    {
        [OperationContract]
        List<Order> findOrderByAccount(long id);

        [OperationContract]
        List<Order> findAll();

        [OperationContract]
        Order findById(long id);

        [OperationContract]
        bool insert(Order entity, DetailOrder[] items);

        [OperationContract]
        bool delete(long id);

        [OperationContract]
        List<DetailOrder> findDetailByOrder(long id);

    }
}
