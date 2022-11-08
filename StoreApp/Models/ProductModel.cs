using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StoreApp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public IEnumerable<ProductType> Categories { get; set; }
        public int Discount { get; set; }
        [NotMapped]
        public IBrowserFile Picture { get; set; }
        public string? PictureName { get; set; }
        public string? Description { get; set; }
    }

    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public IEnumerable<ProductModel> Products { get; set; }

        override public string ToString()
        {
            return Name;
        }
    }
    public enum ProductTypeNames
    {
        TVs,
        PSs,
        Notebooks,
        Multicookers
    }
}