using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme.Models.Validation.ModelMetaDataTypes
{
    public class OgrenciMetaData
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Soyad { get; set; }
        public int Numara { get; set; }
        public int BolumId { get; set; }

    }
}
