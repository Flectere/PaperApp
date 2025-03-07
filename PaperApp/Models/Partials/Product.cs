using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperApp.Models
{
    public partial class Product
    {
        public string Materials
        {
            get
            {
                List<MaterialProduct>AllMaterials = App.db.MaterialProduct.Where(i => i.IdProduct == ID).ToList();
                string materialsString = "";
                foreach (MaterialProduct material in AllMaterials)
                {
                    materialsString += $"{material.Material.Name}, ";
                }
                if (materialsString.Length > 0)
                    materialsString = materialsString.Remove(materialsString.Length-2);
                return materialsString;
            }
        }
    }
}
