//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TasarimDesenleri_odev1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OkulCantalari
    {
        public int id { get; set; }
        public string adi { get; set; }
        public double fiyat { get; set; }
        public string urun_bilgisi { get; set; }
        public int ResimYolu_id { get; set; }
    
        public virtual ResimYolu ResimYolu { get; set; }
    }
}