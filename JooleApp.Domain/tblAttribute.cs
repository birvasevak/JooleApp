//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JooleApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAttribute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAttribute()
        {
            this.tblProductAttributes = new HashSet<tblProductAttribute>();
            this.tblTechSpecFilters = new HashSet<tblTechSpecFilter>();
            this.tblSubCategories = new HashSet<tblSubCategory>();
        }
    
        public int attributeID { get; set; }
        public string attributeName { get; set; }
        public Nullable<bool> isTechSpec { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductAttribute> tblProductAttributes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTechSpecFilter> tblTechSpecFilters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSubCategory> tblSubCategories { get; set; }
    }
}
