namespace SoftwareTechnology.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentDetail")]
    public partial class StudentDetail
    {
        public int ClassID { get; set; }

        public int StudentID { get; set; }

        public int ID { get; set; }

        public virtual Class Class { get; set; }

        public virtual Student Student { get; set; }
    }
}
