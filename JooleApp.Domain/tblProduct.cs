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
    
    public partial class tblProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProduct()
        {
            this.tblProductAttributes = new HashSet<tblProductAttribute>();
        }
    
        public int productID { get; set; }
        public Nullable<int> subCategoryID { get; set; }
        public string productName { get; set; }
        public string imagePath { get; set; }
        public string modelName { get; set; }
        public string modelYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductAttribute> tblProductAttributes { get; set; } = new List<tblProductAttribute>();
        public virtual tblSubCategory tblSubCategory { get; set; }
    }
}
