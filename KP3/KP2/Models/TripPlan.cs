//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KP2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TripPlan
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public int Id_trip { get; set; }
        public int Id_driver { get; set; }
        public int Id_worker { get; set; }
        public int Id_buss { get; set; }
    
        public virtual Buss Buss { get; set; }
        public virtual Trip Trip { get; set; }
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
    }
}
