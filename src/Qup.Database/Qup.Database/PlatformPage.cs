//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Qup.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlatformPage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlatformPage()
        {
            this.UserGroupsToPages = new HashSet<UserGroupsToPage>();
        }
    
        public int Id { get; set; }
        public string Url { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserGroupsToPage> UserGroupsToPages { get; set; }
    }
}
