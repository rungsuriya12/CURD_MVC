using CRUD_nut.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_nut.Data
{
   //สร้างฐานข้อมูลจาก Models
    public class AppplicationDBContext : DbContext
    {
        public AppplicationDBContext(DbContextOptions<AppplicationDBContext> options) : base(options)
        {

        }
        public DbSet<StudentModel> StudentTess { get; set; }//ชื่อตารางที่สร้าง StudentTess
    }
}
