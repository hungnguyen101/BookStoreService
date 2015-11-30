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
    public interface IGroup : IModel<Group>
    {
    }
}
