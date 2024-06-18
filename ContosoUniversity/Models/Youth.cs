using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Youth
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int YouthId { get; set; }
        public string? YouthName { get; set; }
    }
}
