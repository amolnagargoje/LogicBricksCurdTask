//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CovidDetails.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestDetail
    {
        public int TestDetailsId { get; set; }
       
        public string TestName { get; set; }
        public System.DateTime TestDate { get; set; }
        public string TestResult { get; set; }
        public decimal TotalPrice { get; set; }
        public string DoctorRemark { get; set; }
    
    }
}
