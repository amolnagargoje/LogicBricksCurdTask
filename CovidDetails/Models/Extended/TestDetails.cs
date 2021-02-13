using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovidDetails.Models
{
    [MetadataType(typeof(TestDetailsMetadata))]
    public partial class TestDetails
    {

    }
    public class TestDetailsMetadata
    {
       [Required(AllowEmptyStrings =false,ErrorMessage = "Please provide Test Name")]
        public string TestName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Test Result")]
        public string TestResult { get; set; }
    }
}