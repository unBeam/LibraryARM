//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryARM.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reader()
        {
            this.TakedInfoes = new HashSet<TakedInfo>();
        }
    
        public Nullable<int> UserId { get; set; }
        public string TicketNumber { get; set; }
        public string FIO { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string PlaceToWork { get; set; }
        public string Number { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TakedInfo> TakedInfoes { get; set; }
    }
}