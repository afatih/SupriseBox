using Common;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Absract
{
    public interface ICategoryService:IService<Category>
    {
        ServiceResult<IEnumerable<Category>> GetCategories();
        ServiceResult<Category> Get(Guid id);
        ServiceResult AddCategory(Category category);
        ServiceResult UpdateCategory(Category category);
        ServiceResult DeleteCategory(Category category);
    }
}
