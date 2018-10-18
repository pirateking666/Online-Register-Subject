namespace SoftwareTechnology.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ListSubject")]
    public partial class ListSubject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int CourseID { get; set; }

        public int BranchID { get; set; }

        public int SubjectID { get; set; }

        public int StatusID { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual Course Course { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Status Status { get; set; }
    }
}
