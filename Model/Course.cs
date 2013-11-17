using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Course
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }

        public List<Student> StudentList { get; set; }

        public DateTime Created { get; set; }
        public DateTime Deleted { get; set; }
    }
}
