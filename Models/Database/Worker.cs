using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Worker")]
    public partial class Worker
    {
        public Worker()
        {
            CorrespondenceRecipients = new HashSet<CorrespondenceRecipient>();
            Correspondences = new HashSet<Correspondence>();
            Failures = new HashSet<Failure>();
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        [Column("w_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WId { get; set; }
        [Column("w_nickname")]
        [StringLength(255)]
        [Unicode(false)]
        public string? WNickname { get; set; }
        [Column("w_password")]
        [StringLength(255)]
        [Unicode(false)]
        public string? WPassword { get; set; }
        [Column("w_name")]
        [StringLength(255)]
        [Unicode(false)]
        public string? WName { get; set; }
        [Column("w_lastname")]
        [StringLength(255)]
        [Unicode(false)]
        public string? WLastname { get; set; }
        [Column("w_email")]
        [StringLength(255)]
        [Unicode(false)]
        public string? WEmail { get; set; }
        [Column("w_birth_date", TypeName = "date")]
        public DateTime? WBirthDate { get; set; }
        [Column("w_adress")]
        [StringLength(255)]
        [Unicode(false)]
        public string? WAdress { get; set; }
        [Column("w_phone_number")]
        [StringLength(255)]
        [Unicode(false)]
        public string? WPhoneNumber { get; set; }
        [Column("w_gender")]
        public bool? WGender { get; set; }
        [Column("fk_Worker_typeworker_type_id")]
        public int FkWorkerTypeworkerTypeId { get; set; }
        [Column("fk_MessageCorrespondence")]
        public int? FkMessageCorrespondence { get; set; }

        [ForeignKey("FkMessageCorrespondence")]
        [InverseProperty("Workers")]
        public virtual Message? FkMessageCorrespondenceNavigation { get; set; }
        [ForeignKey("FkWorkerTypeworkerTypeId")]
        [InverseProperty("Workers")]
        public virtual WorkerType FkWorkerTypeworkerType { get; set; } = null!;
        [InverseProperty("FkWorkerw")]
        public virtual ICollection<CorrespondenceRecipient> CorrespondenceRecipients { get; set; }
        [InverseProperty("FkWorkerw")]
        public virtual ICollection<Correspondence> Correspondences { get; set; }
        [InverseProperty("FkWorkerw")]
        public virtual ICollection<Failure> Failures { get; set; }
        [InverseProperty("FkWorkerw")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
