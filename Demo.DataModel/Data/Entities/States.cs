using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataModel.Data.Entities
{
    public class States
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Countries")]
        public int CountryId { get; set; }
        public Countries Countries { get; set; }

    }
}
