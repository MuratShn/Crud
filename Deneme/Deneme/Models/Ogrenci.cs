using Deneme.Models.Validation.ModelMetaDataTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme.Models
{
    //[ModelMetadataType(typeof(OgrenciMetaData))]
    public class Ogrenci
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Numara { get; set; }
        public int BolumId { get; set; }

        public Bolum Bolum { get; set; }
    }
}
