//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PaperApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CreateProduct
    {
        public int ID { get; set; }
        public Nullable<int> IdEmployee { get; set; }
        public Nullable<int> IdWorkshop { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> IdProduct { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Product Product { get; set; }
        public virtual WorkShop WorkShop { get; set; }
    }
}
