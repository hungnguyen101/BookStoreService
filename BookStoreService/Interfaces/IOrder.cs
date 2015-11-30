using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreService.EF;
using System.ServiceModel;

namespace BookstoreService.Interfaces
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
        bool update(Order entity);

        [OperationContract]
        bool delete(long id);

        [OperationContract]
        List<DetailOrder> findDetailByOrder(long id);
    }
}
