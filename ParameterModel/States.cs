using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace database
{
    public class States
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }

        public int State { get; set; }
        public string Parameter { get; set; }



    }
}
