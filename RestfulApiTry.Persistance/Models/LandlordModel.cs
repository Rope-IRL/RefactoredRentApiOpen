using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulApiTry.Persistence.Models
{
    public class LandlordModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login {  get; set; } = string.Empty;

        [Required]
        public string HashedPassword { get; set; } = string.Empty;

        [ForeignKey("LandlordInformationId")]
        public int LandlordInformationId { get; set; }
        public LandlordInformationModel? LandlordInformationModel { get; set; }
        public List<FlatModel>? Flats { get; set; }
    }
}
