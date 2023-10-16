using APIDomainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDTOs
{
    public class ClassDTOs
    {
        public int Id { get; set; }
        [Required]
        public string ClassName { get; set; } = string.Empty;
        public List<StudentDTOs> Students { get; set; }= new List<StudentDTOs>();
    }
}
