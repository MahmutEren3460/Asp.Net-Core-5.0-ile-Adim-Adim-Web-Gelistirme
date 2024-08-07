using System.ComponentModel.DataAnnotations;

namespace Core_Proje_Api.DAL.Entity
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string CategoryName { get; set; }
    }
}
