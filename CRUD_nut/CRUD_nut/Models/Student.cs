using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD_nut.Models
{
    public class StudentModel
    {
        //พื้นที่จัดเก็บข้อมูล
        [Key]
        public int Id { get; set; }

        [DisplayName("ชื่อ")]
        [Required(ErrorMessage ="กรุณาป้อนชื่อ")]//ห้ามเป็นค่าว่าง
        public string Name { get; set; }

        [DisplayName("คะแนนสอบ")]
        [Required(ErrorMessage = "กรุณาป้อนคะแนน")]//ห้ามเป็นค่าว่าง
        [Range(0,100,ErrorMessage="กรุณาใส่ค่าช่วง 0-100")]//ตรวจสอบเลขเฉพาะ 0-100
        public int Score { get; set; }
    }
}
