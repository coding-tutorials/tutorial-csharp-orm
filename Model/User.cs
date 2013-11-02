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
        public String Login { get; set; }
        public String Password { get; set; }
        public String Image { get; set; }
        public DateTime Created { get; set; }
    }
}
