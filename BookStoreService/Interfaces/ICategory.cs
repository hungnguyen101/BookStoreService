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
    public interface ICategory : IModel<Category>
    {
    }
}
