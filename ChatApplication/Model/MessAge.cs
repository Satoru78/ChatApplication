//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatApplication.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MessAge
    {
        public int ID { get; set; }
        public string TextR { get; set; }
        public Nullable<System.TimeSpan> TimePush { get; set; }
        public Nullable<int> IDUser { get; set; }
    
        public virtual UserLog UserLog { get; set; }
    }
}