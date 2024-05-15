using store.Models;

namespace store.Dtos.Responce
{
    public class PhotoProduitResponseDto
    {
        public int PhotoProduitId { get; set; }
        public String UrlImage { get; set; }
        public Product Produit { get; set; }
        public int ProductId { get; set; }
    }
}
