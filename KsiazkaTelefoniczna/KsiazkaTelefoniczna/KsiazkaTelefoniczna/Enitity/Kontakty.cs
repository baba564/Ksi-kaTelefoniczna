namespace KsiazkaTelefoniczna.Enitity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kontakty")]
    public partial class Kontakty
    {
      //  [Key]
       // [Column(Order = 0)]
       // public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Imie { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Nazwisko { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? NumerTelefonu { get; set; }
    }
}
