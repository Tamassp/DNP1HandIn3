using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models {
    public class Adult : Person
    {
        [Key] 
        public int Id { get; set; }
       
       
}
}