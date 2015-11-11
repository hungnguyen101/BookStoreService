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
    public interface IAccount : IModel<Account>
    {
        [OperationContract]
        Account Authenticate(string username, string password);


        [OperationContract]
        List<Account> findAccountsByGroup(string groupID);

    }
}
