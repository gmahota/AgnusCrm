using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgnusCrm.Models
{
    public class IAgnusCrmMasterChild : IAgnusCrmBasic
    {
        //never used to store data, just a mark for master detail
        public string HasChild { get; set; }
    }
}
