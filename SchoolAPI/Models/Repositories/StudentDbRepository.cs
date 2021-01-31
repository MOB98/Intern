//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace DEMO.Models.Repositories
//{
//    public class StudentDbRepository : ISchoolManagmentRepository<Student>
//    {
//        SchoolAPIDbContext db;
//        public StudentDbRepository(SchoolAPIDbContext _db)
//        {
//            db = _db;      
//        }
//        public void Add(Student entity)
//        {
//            db.Students.Add(entity);
//            db.SaveChanges();
//        }

//        public void Delete(int id)
//        {
//            var student= Find(id);
//            db.Students.Remove(student);
//            db.SaveChanges();


//        }

//        public Student Find(int id)
//        {
//            var student = db.Students.FirstOrDefault(p => p.Id == id);
//            return student;
       
//        }

//        public IList<Student> List()
//        {

//            return db.Students.ToList();
//        }

//        public List<Student> Search(string term)
//        {
//            return db.Students.Where(a => a.name.Contains(term)).ToList();
//        }

//        public void Update(int id, Student entity)
//        {

//            db.Update(entity);
//            db.SaveChanges();
//        }
//    }
//}
