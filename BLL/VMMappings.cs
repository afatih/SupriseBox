
using DTOs.DTOModels.EntityDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class VMMappings
    {
        public static Box MappingBoxVMtoBoxEntity(BoxDTO BoxDTO)
        {
            Box box = new Box()
            {
                BoxName = BoxDTO.BoxName,
                BoxTypeID = BoxDTO.BoxTypeID,
                Description = BoxDTO.Description,

            };

            return box; 
        }
    }
}
