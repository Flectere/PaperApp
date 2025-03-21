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
    
    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            this.MaterialProduct = new HashSet<MaterialProduct>();
            this.Provide = new HashSet<Provide>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> IdType { get; set; }
        public Nullable<int> CountInPack { get; set; }
        public Nullable<int> IdUnit { get; set; }
        public Nullable<int> CountInStorage { get; set; }
        public Nullable<int> MinCount { get; set; }
        public Nullable<int> Cost { get; set; }
    
        public virtual TypeMaterial TypeMaterial { get; set; }
        public virtual Unit Unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialProduct> MaterialProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Provide> Provide { get; set; }
    }
}
