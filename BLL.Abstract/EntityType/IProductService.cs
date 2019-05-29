using Common;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Absract
{
    public interface IProductService:IService<Box>
    {
        ServiceResult<IEnumerable<Box>> GetProducts();
        ServiceResult AddProduct(Box product);
    }
}
