using System.ComponentModel.DataAnnotations;

namespace AppCandidatos.Models
{
    public class Candidate
    {
        [Key]
        public int IdCandidate { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [MaxLength(150, ErrorMessage = "El apellido no puede tener más de 150 caracteres")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date, ErrorMessage = "El formato de la fecha de nacimiento no es válido")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo electrónico inválido")]
        [MaxLength(250, ErrorMessage = "El correo no puede tener más de 250 caracteres")]
        public string Email { get; set; }

        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        // Relación con CandidateExperience
        public List<CandidateExperience> CandidateExperiences { get; set; } = new List<CandidateExperience>();
    }
}
