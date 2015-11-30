using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using BookstoreService.EF;

namespace BookstoreService.Interfaces
{
    [ServiceContract]
    public interface IAccount : IModel<Account>
    {
        [OperationContract]
        Account Authenticate(string username, string password);


        [OperationContract]
        List<Account> findAccountsByGroup(string groupID);

        [OperationContract]
        Account findAccountByUsername(string username);

    }
}
