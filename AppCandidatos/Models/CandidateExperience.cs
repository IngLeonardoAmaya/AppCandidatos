using System.ComponentModel.DataAnnotations;

namespace AppCandidatos.Models
{
    public class CandidateExperience
    {
        [Key]
        [Display(Name = "Id Experiencia Candidato")]
        public int IdCandidateExperience { get; set; }

        [Display(Name = "Empresa Candidato")]
        [Required(ErrorMessage = "El nombre de la empresa es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre de la empresa no puede tener más de 100 caracteres")]
        public string Company { get; set; }

        [Display(Name = "Empleo Candidato")]
        [Required(ErrorMessage = "El cargo es obligatorio")]
        [MaxLength(100, ErrorMessage = "El cargo no puede tener más de 100 caracteres")]
        public string Job { get; set; }


        [Display(Name = "Descripcion Candidato")]
        [MaxLength(4000, ErrorMessage = "La descripción no puede tener más de 4000 caracteres")]
        public string Description { get; set; }


        [Display(Name = "Sueldo Candidato")]
        [DataType(DataType.Currency, ErrorMessage = "El formato de salario no es válido")]
        public decimal Salary { get; set; }


        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        [DataType(DataType.Date, ErrorMessage = "El formato de la fecha de inicio no es válido")]
        [Display(Name = "Fecha de Inicio")]
        public DateTime BeginDate { get; set; }


        [DataType(DataType.Date, ErrorMessage = "El formato de la fecha de fin no es válido")]
        [Display(Name = "Fecha de Fin")]
        public DateTime? EndDate { get; set; }

        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        // Relación con Candidate (FK)
        public int IdCandidate { get; set; }
        public Candidate Candidate { get; set; }
    }
}
