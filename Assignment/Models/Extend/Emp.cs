using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Emp
    {
    }
    public class EmployeeMetadata
    {
        [Required (AllowEmptyStrings =false, ErrorMessage ="Input is Required")]
        public string Gender { get; set; }
        [Required(AllowEmptyStrings =false , ErrorMessage ="Input is Required")]
        public string Department { get; set; }
    }
}