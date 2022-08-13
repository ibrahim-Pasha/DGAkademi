using HW_2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW_2
{
    public class IStudentService
    {
        private HW_2Context _context = new HW_2Context();
       
       public Student UpdateStudents(int studentId,Student student)
        {
            var _student = _context.Students.FirstOrDefault(s => s.Id == studentId);
            if (_student!=null)
            {
                _student.Name = student.Name;
                _context.SaveChanges();
            }
            return _student;
        }
    }
}
