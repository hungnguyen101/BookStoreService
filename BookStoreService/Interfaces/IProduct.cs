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
    public interface IProduct :IModel<Product>
    {
        [OperationContract]
        List<Product> findProductsByCategory(long catId);
        [OperationContract]
        List<Product> findByKeyword(string key);
        [OperationContract]
        List<Product> findByPrice(decimal start, decimal end);
    }
}
