using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store.Dtos.Request;
using store.Dtos.Responce;
using store.Models;
using store.Services.Contract;
using store.Services.Implementation;

namespace store.Controllers
{ 
 [Route("api/[controller]")]
[ApiController]
public class PhotoProduitsController : ControllerBase
{
    private readonly IPhotoProduitService _photoProduitService;

    public PhotoProduitsController(IPhotoProduitService photoProduitService)
    {
        _photoProduitService = photoProduitService;
    }



    [HttpGet("{id}")]
    public async Task<ActionResult<PhotoProduit>> GetPhotoProductById(int id)
    {
        var product = await _photoProduitService.GetPhotoProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> AddProduct([FromForm] PhotoProduit product, [FromForm] IFormFile imageFile)
    {
        await _photoProduitService.AddPhotoProduit(product, imageFile);
        return CreatedAtAction(nameof(GetProductById), new { id = product.PhotoProduitId }, product);
    }

        private object GetProductById()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduct(int id, [FromForm] PhotoProduit product, [FromForm] IFormFile? imageFile)
    {
        var existingProduct = await _photoProduitService.GetPhotoProductById(id);
        if (existingProduct == null)
        {
            return NotFound();
        }

        await _photoProduitService.UpdatePhotoProduit(id, product, imageFile);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var existingProduct = await _photoProduitService.GetPhotoProductById(id);
        if (existingProduct == null)
        {
            return NotFound();
        }

        await _photoProduitService.DeletePhotoProduit(id);
        return NoContent();
    }
}
}