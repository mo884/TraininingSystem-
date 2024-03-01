﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.DAL.Entity.Enum;

namespace TraininingSystem.DAL.Entity
{
    [Table("Trainee")]

    public class Trainee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Min 2 letter")]
        public string Name { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,Phone]  
        public string Phone { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [ForeignKey("Trak")]
        public int? TrakID { get; set; }
        public Track? Trak { get; set; }
        public List<Course> Courses { get; set; }

    }
}
