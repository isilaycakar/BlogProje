﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string? WriterAbout { get; set; }
        public string? WriterImage { get; set; }
        public string WriterMail { get; set; }

        [DataType("Password")]
        public string WriterPassword { get; set; }

        [DataType("Password")]
        [Compare("WriterPassword", ErrorMessage = "Girdiğiniz şifreler eşleşmiyor!")]
        public string ConfirmPassword { get; set; }
        public bool? WriterStatus { get; set; }

        public Cities? Cities { get; set; }
    }

    public enum Cities
    {
        İstanbul,
        Ankara,
        Eskişehir,
        İzmir
    }
}
