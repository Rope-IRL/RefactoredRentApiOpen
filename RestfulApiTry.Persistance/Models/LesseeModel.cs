using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulApiTry.Persistence.Models
{
    public class LesseeModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; } = string.Empty;

        [Required]
        public string HashedPassword { get; set; } = string.Empty;
       
        [ForeignKey("LesseeInformationId")]
        public int LesseeInformationId { get; set; }
        public LesseeInformationModel LesseeInformationModel { get; set;}
    }
}
