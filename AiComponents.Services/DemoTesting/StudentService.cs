using AIComponents.Data.Connection;
using AIComponents.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiComponents.Services.DemoTesting
{
    public partial interface IStudentService
    {
        Task<Student?> GetStudent(int id);
        Task<IEnumerable<Student>> GetStudents();
    }
    public class StudentService: IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        #region Cstor
        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }


        #endregion

        public async Task<Student?> GetStudent(int id)
        {
            return await _studentRepository.Get(id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentRepository.GetAll();
        }


    }
}
