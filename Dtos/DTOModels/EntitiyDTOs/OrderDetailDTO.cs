using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DTOModels.EntitiyDTOs
{
    public class OrderDetailDTO
    {
        public int ID { get; set; }

        public int BoxID { get; set; }

        public int OrderID { get; set; }

        public int BoxAmount { get; set; }
    }
}
