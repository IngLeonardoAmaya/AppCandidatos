using System.ComponentModel.DataAnnotations;

namespace AppCandidatos.Models.ViewModels
{
    public class CandidateViewModel
    {
        // Datos del Candidato
        public int IdCandidate { get; set; }

        [Display(Name = "Nombre Candidato")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string Name { get; set; }


        [Display(Name = "Apellido Candidato")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [MaxLength(150, ErrorMessage = "El apellido no puede tener más de 150 caracteres")]
        public string Surname { get; set; }


        [Display(Name = "Fecha Nacimiento Candidato")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date, ErrorMessage = "El formato de la fecha de nacimiento no es válido")]
        public DateTime Birthdate { get; set; }


        [Display(Name = "Email Candidato")]
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo electrónico inválido")]
        [MaxLength(250, ErrorMessage = "El correo no puede tener más de 250 caracteres")]
        public string Email { get; set; }

        // Lista de experiencias profesionales del candidato
        public List<CandidateExperienceViewModel> CandidateExperiences { get; set; } = new List<CandidateExperienceViewModel>();
    }
}
