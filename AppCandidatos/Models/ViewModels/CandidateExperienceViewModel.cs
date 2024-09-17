using System.ComponentModel.DataAnnotations;

namespace AppCandidatos.Models.ViewModels
{
    public class CandidateExperienceViewModel
    {
        public int IdCandidateExperience { get; set; }


        [Display(Name = "Empresa Candidato")]
        [Required(ErrorMessage = "El nombre de la empresa es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre de la empresa no puede tener más de 100 caracteres")]
        public string Company { get; set; }


        [Display(Name = "Cargo Candidato")]
        [Required(ErrorMessage = "El cargo es obligatorio")]
        [MaxLength(100, ErrorMessage = "El cargo no puede tener más de 100 caracteres")]
        public string Job { get; set; }


        [Display(Name = "Descripcion Candidato")]
        [MaxLength(4000, ErrorMessage = "La descripción no puede tener más de 4000 caracteres")]
        public string? Description { get; set; }


        [Display(Name = "Sueldo Candidato")]
        [DataType(DataType.Currency, ErrorMessage = "El formato de salario no es válido")]
        public decimal Salary { get; set; }

        [Display(Name = "Fecha inicio de contrato")]
        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        [DataType(DataType.Date, ErrorMessage = "El formato de la fecha de inicio no es válido")]
        public DateTime BeginDate { get; set; }

        [Display(Name = "Fecha final de contrato")]
        [DataType(DataType.Date, ErrorMessage = "El formato de la fecha de fin no es válido")]
        public DateTime? EndDate { get; set; }
    }
}
