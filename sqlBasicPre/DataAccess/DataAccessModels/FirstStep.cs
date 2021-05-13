using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace sqlBasicPre.DataAccess.DataAccessModels
{
    [Table("firstStep")]
    public partial class FirstStep
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("key")]
        [StringLength(10)]
        public string Key { get; set; }
        [Required]
        [Column("value")]
        [StringLength(10)]
        public string Value { get; set; }
    }
}
