//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kwetter
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gebruikers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gebruikers()
        {
            this.Gebruikers1 = new HashSet<Gebruikers>();
            this.Tweets = new HashSet<Tweets>();
            this.Gebruikers11 = new HashSet<Gebruikers>();
            this.Gebruikers3 = new HashSet<Gebruikers>();
        }
    
        public int Id { get; set; }
        public string naam { get; set; }
        public string bio { get; set; }
        public Nullable<int> Gebruiker_Id { get; set; }
        public string password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gebruikers> Gebruikers1 { get; set; }
        public virtual Gebruikers Gebruikers2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tweets> Tweets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gebruikers> Gebruikers11 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gebruikers> Gebruikers3 { get; set; }
    }
}
