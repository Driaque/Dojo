//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dojo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestPayment
    {
        public string TestPayment_ID { get; set; }
        public string Test_ID { get; set; }
        public string STUDENT_ID { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Test Test { get; set; }
    }
}
