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
    
    public partial class Aspect
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aspect()
        {
            this.DescriptionOfJudgeAspects = new HashSet<DescriptionOfJudgeAspects>();
            this.StudentResult = new HashSet<StudentResult>();
        }
    
        public int IdAspect { get; set; }
        public string Title { get; set; }
        public int IdSubCriteria { get; set; }
        public string NumberOfPoints { get; set; }
        public Nullable<int> IdTypeAspect { get; set; }
        public string Description { get; set; }
    
        public virtual SubCriteria SubCriteria { get; set; }
        public virtual TypeAspect TypeAspect { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DescriptionOfJudgeAspects> DescriptionOfJudgeAspects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentResult> StudentResult { get; set; }
    }
}
