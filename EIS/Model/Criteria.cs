//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EIS.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Criteria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Criteria()
        {
            this.SubCriteria = new HashSet<SubCriteria>();
        }
    
        public int IdCriteria { get; set; }
        public string Title { get; set; }
        public int IdProModule { get; set; }
        public string MaxValue { get; set; }
    
        public virtual ProModule ProModule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubCriteria> SubCriteria { get; set; }
    }
}
