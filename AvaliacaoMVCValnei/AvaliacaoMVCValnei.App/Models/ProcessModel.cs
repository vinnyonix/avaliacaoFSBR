using System.ComponentModel.DataAnnotations;

namespace AvaliacaoMVCValnei.App.Models
{
    public class ProcessModel
    {
        [Key]
        [Display(Name = "Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório.")]
        public int ProcessId { get; set; }

        [Display(Name = "Nome")]
        [MaxLength(100, ErrorMessage = "Limite de caracteres ultrapassado.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o nome do processo.")]
        public string? Name { get; set; }

        [Display(Name = "NPU")]
        [MaxLength(25, ErrorMessage = "Limite de caracteres ultrapassado.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a Unidade de Processamento Neural.")]
        public string? NPU { get; set; }

        [Display(Name = "Data de criação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a data de criação.")]
        public DateTime? CreateAt { get; set; }

        [Display(Name = "Data de visualização")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a data de visualização.")]
        public DateTime? ViewedAt { get; set; }

        [Display(Name = "Município")]
        [MaxLength(50, ErrorMessage = "Limite de caracteres ultrapassado.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o município.")]
        public string? Municipality { get; set; }

        [Display(Name = "Unidade federativa")]
        [MaxLength(2, ErrorMessage = "Limite de caracteres ultrapassado.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a unidade federativa.")]
        public string? FederativeUnit { get; set; }

        public string? FederativeUnitIdSelected { get; set; }

        //[DisplayFormat(DataFormatString = "{0:#,##0.00}")]
    }
}

