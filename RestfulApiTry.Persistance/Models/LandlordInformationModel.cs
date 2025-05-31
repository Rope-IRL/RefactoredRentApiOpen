using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulApiTry.Persistence.Models
{
    public class LandlordInformationModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [DefaultValue("")]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        [DefaultValue("")]
        public string Surname { get; set; }

        [Required]
        [DefaultValue(18)]
        public int Age { get; set; }

        [Required]
        [MaxLength(15)]
        [DefaultValue("")]
        public string PhoneNumber { get; set; }

        [Precision(3,1)]
        [DefaultValue(0)]
        public decimal Score { get; set; }

        [ForeignKey("LandlordId")]
        public int LandlordId { get; set; }
        public LandlordModel? LandlordModel { get; set; }
        

    }
}
