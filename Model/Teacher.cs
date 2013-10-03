using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Photo { get; set; }
        public DateTime Birthdate { get; set; }

        public DateTime Created { get; set; }
    }
}
