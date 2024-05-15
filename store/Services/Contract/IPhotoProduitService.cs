using store.Models;

namespace store.Services.Contract
{
    
    

        public interface IPhotoProduitService
        {
            Task<PhotoProduit?> GetPhotoProductById(int PhotoProduitId);
  
            Task DeletePhotoProduit(int PhotoProduitId);
            Task AddPhotoProduit(PhotoProduit product, IFormFile imageFile);
            Task UpdatePhotoProduit(int PhotoProduitId, PhotoProduit newPhotoProduit, IFormFile? newImageFile);
        }
    
}
