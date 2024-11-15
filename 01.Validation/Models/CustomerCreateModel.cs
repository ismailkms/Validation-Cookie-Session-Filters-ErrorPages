using System.ComponentModel.DataAnnotations;

namespace _01.Validation.Models
{
    public class CustomerCreateModel
    {
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        [MaxLength(30, ErrorMessage = "Ad alanı en fazla 30 karakter olabilir")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        [MinLength(2, ErrorMessage = "Soyad alanı en az 2 karakter olabilir")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Yaş alanı boş geçilemez")]
        [Range(18, 40, ErrorMessage = "Yaş değeri en az 18, en fazla 40 olabilir")]
        public int Age { get; set; }
    }
}
