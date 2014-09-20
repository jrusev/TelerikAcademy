using StudentServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentServices.Repositories
{
    interface IStudentsRepository:IRepository<Student>
    {
    }
}
