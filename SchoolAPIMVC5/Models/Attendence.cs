//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolAPIMVC5.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    
    
    public partial class Attendence
    {
        public Attendence()
        {
            this.Students = new HashSet<Student>();
        }
    
        public int AttID { get; set; }
        public Nullable<System.DateTime> AttDate { get; set; }
        public Nullable<bool> IsPresent { get; set; }
        public Nullable<int> ClassID { get; set; }
        public Nullable<int> StudentID { get; set; }
    
        public virtual tblClass tblClass { get; set; }
        public virtual Student Student { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Student> Students { get; set; }
    }
}
