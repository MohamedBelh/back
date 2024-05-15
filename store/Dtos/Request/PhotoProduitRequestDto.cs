using store.Models;

namespace store.Dtos.Request
{
    public class PhotoProduitRequestDto
    {
        public String UrlImage { get; set; }
        public Product Produit { get; set; }
        public int ProductId { get; set; }
    }
}
