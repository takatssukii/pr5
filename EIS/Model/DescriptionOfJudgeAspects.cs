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
    
    public partial class DescriptionOfJudgeAspects
    {
        public int IdDescriptionOfJudgeAspects { get; set; }
        public int IdAspect { get; set; }
        public string Judg { get; set; }
        public string Description { get; set; }
    
        public virtual Aspect Aspect { get; set; }
    }
}