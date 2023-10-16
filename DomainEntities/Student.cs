using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDomainEntities
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public double Phone { get; set; }
        [ForeignKey(nameof(Class))]

        public int? ClassId { get; set; }
        public Class Class { get; set; }
    }
}
