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
    
    public partial class UserGroupsToPage
    {
        public int Id { get; set; }
        public Nullable<int> UserGroupId { get; set; }
        public Nullable<int> PageId { get; set; }
    
        public virtual PlatformPage PlatformPage { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}