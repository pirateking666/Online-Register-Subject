namespace SoftwareTechnology.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Class")]
    public partial class Class
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Class()
        {
            StudentDetails = new HashSet<StudentDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int ClassTypeID { get; set; }

        public int CourseID { get; set; }

        public int BranchID { get; set; }

        public int SubjectID { get; set; }

        public int DayID { get; set; }

        public int TimeID { get; set; }

        public int RoomID { get; set; }

        public int TeacherID { get; set; }

        public int StatusID { get; set; }

        public int? NumberOfStudent { get; set; }

        public DateTime? DayStart { get; set; }

        public DateTime? DayEnd { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual Course Course { get; set; }

        public virtual ClassType ClassType { get; set; }

        public virtual Day Day { get; set; }

        public virtual Room Room { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Status Status { get; set; }

        public virtual Time Time { get; set; }

        public virtual Teacher Teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentDetail> StudentDetails { get; set; }
    }
}
