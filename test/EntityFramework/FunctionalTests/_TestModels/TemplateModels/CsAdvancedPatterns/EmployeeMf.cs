//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#if !NET40
namespace FunctionalTests.ProductivityApi.TemplateModels.CsAdvancedPatterns
{
    using System;
    using System.Collections.Generic;
    
    public abstract partial class EmployeeMf
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; private set; }
        internal string LastName { private get; set; }
    }
}
#endif
