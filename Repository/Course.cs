using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{

    public class Course : Repository<Dal.EntityFramework.Course,Model.Course>
    {
        private Dal.Course dalCourse = new Dal.Course();



        
    }
}
