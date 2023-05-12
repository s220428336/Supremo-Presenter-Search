using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Supremo_Presenter_Search.Models
{
    public class VotesModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Voting Bundle")]
        public string VoteOption { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int VoteQuantity { get; set; }

        [Required]
        [DisplayName("Presenter")]
        public string Contestant { get; set; }
    }
}
