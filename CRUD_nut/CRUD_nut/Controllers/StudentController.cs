
using CRUD_nut.Data;
using Microsoft.AspNetCore.Mvc;
using CRUD_nut.Models;//ดึงมาใช้


namespace CRUD_nut.Controllers
{
    public class StudentController : Controller
    {
          private readonly AppplicationDBContext _db;
        

            public StudentController(AppplicationDBContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            // Student s1 = new Student();หลายรูปแบบการสร้างรับของมูล
            // var student = new Student();;หลายรูปแบบการสร้างรับของมูล
         //   StudentModel s1 = new();//เชื่อมข้อมูลกับ model
         //   s1.Id = 1;
         //   s1.Name = "Test1";
         //   s1.Score = 1;

         //   StudentModel s2 = new();//เชื่อมข้อมูลกับ model
         //   s2.Id = 2;
         //   s2.Name = "Test2";
         //   s2.Score = 52;

         //   StudentModel s3 = new();//เชื่อมข้อมูลกับ model
         //   s3.Id = 3;
         //   s3.Name = "Test3";
        //    s3.Score = 11;

            // ส่งค่า 3 ค่าไม่ได้ต้องเก็บใน list คำสั่ง AllStudents
         //   List<StudentModel> AllStudents = new List<StudentModel>();
         //   AllStudents.Add(s1);
        //    AllStudents.Add(s2);
        //    AllStudents.Add(s3);

            // return View(s1);//ส่ง s1
        //    return View(AllStudents);//ส่งค่าใน AllStudents ไป 3 ก้อน




            IEnumerable <StudentModel> allstudent = _db.StudentTess;//
            return View(allstudent);
      
        }
        //[HttpGet]เริ่มต้นไม่ต้องเขียนมีให้เพื่อแสดงผลหน้า View Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]//ต้องมาคู่การรับค่าเพื่อความปลอดภัย
        [ValidateAntiForgeryToken]//ต้องมาคู่การรับค่าเพื่อความปลอดภัย
        public IActionResult Create(StudentModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.StudentTess.Add(obj);//ส่งข้อมูลไปเพิ่ม
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);//ส่งกลับค่าเดิม
            
        }
        public IActionResult Edit(int? id) //โชว์ข้อมูลหนเาแก้ไขเพื่อแก้ไขข้อมูล
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.StudentTess.Find(id);
            if (obj == null)
            {
                return NotFound();

            }
            return View(obj);

        }

        [HttpPost]//ต้องมาคู่การรับค่าเพื่อความปลอดภัย
        [ValidateAntiForgeryToken]//ต้องมาคู่การรับค่าเพื่อความปลอดภัย
        public IActionResult Edit(StudentModel obj) //แก้ไขข้อมูล
        {
            if (ModelState.IsValid)
            {
                _db.StudentTess.Update(obj);//ส่งข้อมูลไปแก้ไข
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);//ส่งกลับค่าเดิม

        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //ค้นข้อมูล
            var obj = _db.StudentTess.Find(id);
            if (obj == null)
            {
                return NotFound();

            }
            _db.StudentTess.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


        //แสดงแบบไม่ผ่าน views
        //       public IActionResult ShowScore(int id) 
        //      {
        //          return Content($"คะแนนสอบ เลขที่ {id} ");
        //      }


    }
}
