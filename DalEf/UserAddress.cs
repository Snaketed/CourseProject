//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DalEf
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserAddress
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public int Country { get; set; }
        public int City { get; set; }
        public long PostalCode { get; set; }
    
        public virtual City City1 { get; set; }
        public virtual Country Country1 { get; set; }
        public virtual User User { get; set; }
    }
}