namespace CodeFirstSample.DataLayer.Dbo.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblBookDetail")]
    public partial class tblBookDetail
    {
        [Key]
        public int BookDetailID { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        [StringLength(50)]
        public string Publisher { get; set; }

        public int BookID { get; set; }

        public virtual tblBook tblBook { get; set; }
    }
}
