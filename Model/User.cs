using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime Deleted { get; set; }
    }
}
