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
    
    public partial class spGetUserQueue_Result
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> QueueJoinDateTime { get; set; }
        public Nullable<int> PatronId { get; set; }
        public Nullable<System.DateTime> ActualEntryDateTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}