using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.DAL.Entity;
using Microsoft.AspNetCore.Http;

namespace TraininingSystem.BLL.ModelVM.ProductVM
{
    public class ProductVM
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string Name { get; set; }

        public string? Image { get; set; }
        public IFormFile?  ImageFile { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value")]
        public decimal Price { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }

        [ForeignKey("Customer")]
        public int CustID { get; set; }

    }
}
