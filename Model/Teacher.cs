using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Teacher : User
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
    }
}
