using Gimji.Data;
using Gimji.DTO;
using Gimji.Models;
using Gimji.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Net;

namespace Gimji.Services
{
    public class ProductService : ProductRepository
    {
        private MyPostgresDbContext dbContext;
        private CategoryRepository categoryRepository;
        private IWebHostEnvironment environment;
        private readonly IHttpContextAccessor httpContextAccessor;
        public ProductService(MyPostgresDbContext dbContext , CategoryRepository categoryRepository , IWebHostEnvironment environment , IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.categoryRepository = categoryRepository;
            this.environment = environment;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task AddProduct(Product product)
        {
            await dbContext.products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(string id)
        {
            var product = await dbContext.products.FindAsync(id);
            dbContext.products.Remove(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> DoesItemExist(string id)
        {
            return await dbContext.products.FindAsync(id) != null;
        }
        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryCode, string? search, double? from, double? to, string? sortBy, int? limit, int? page = 1)
        {
            var allProduct = dbContext.products.AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProduct = allProduct.Where(item => item.name.Contains(search));
            }
            if (from.HasValue)
            {
                allProduct = allProduct.Where(item => item.price >= from);
            }
            if (to.HasValue)
            {
                allProduct = allProduct.Where(item => item.price <= to);
            }

            if (categoryCode != null)
            {
                allProduct = allProduct.Where(item => item.category.CodeValue == categoryCode);
            }

            #endregion

            #region Sorting
            allProduct = allProduct.OrderBy(item => item.name);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc": allProduct = allProduct.OrderByDescending(item => item.name); break;
                    case "price_desc": allProduct = allProduct.OrderByDescending(item => item.price); break;
                    case "price_asc": allProduct = allProduct.OrderBy(item => item.price); break;
                }
            }
            #endregion

            #region Pagging
            if (page.HasValue && page > 0 && limit.HasValue && limit > 0)
            {
                allProduct = allProduct.Skip((page.Value - 1) * limit.Value).Take(limit.Value);
            }
            #endregion

            return await allProduct
                .Select(x => new Product()
                {
                    productID = x.productID,
                    name = x.name,
                    image1 = x.image1,
                    image2 = x.image2,
                    image3 = x.image3,
                    price = x.price,
                    description = x.description,
                    nsn = x.nsn,
                    category = x.category,
                    ImageSrc = string.Format("{0}://{1}{2}/images/{3}", httpContextAccessor.HttpContext.Request.Scheme, httpContextAccessor.HttpContext.Request.Host, httpContextAccessor.HttpContext.Request.PathBase, x.image1)
                })
                .ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetAllProduct(string? search , double? from , double? to , string? sortBy , int? limit ,int? page = 1)
        {
            var allProduct = dbContext.products.AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProduct = allProduct.Where(item => item.name.Contains(search));
            }
            if (from.HasValue) 
            {
                allProduct = allProduct.Where(item => item.price >= from);
            }
            if (to.HasValue)
            {
                allProduct = allProduct.Where(item => item.price <= to);
            }
            #endregion

            #region Sorting
            allProduct = allProduct.OrderBy(item => item.name);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "name_desc": allProduct = allProduct.OrderByDescending(item => item.name); break;
                    case "price_desc": allProduct = allProduct.OrderByDescending(item => item.price); break;
                    case "price_asc": allProduct = allProduct.OrderBy(item => item.price); break;
                }
            }
            #endregion

            #region Pagging
            if (page.HasValue && page > 0 && limit.HasValue && limit > 0)
            {
                allProduct = allProduct.Skip((page.Value - 1) * limit.Value).Take(limit.Value);
            }
            #endregion

            return await allProduct
                .Select(x => new Product()
                {
                    productID = x.productID,
                    name = x.name,
                    image1 = x.image1,
                    image2 = x.image2,
                    image3 = x.image3,
                    price = x.price,
                    description = x.description,
                    nsn = x.nsn,
                    category = x.category,
                    ImageSrc = string.Format("{0}://{1}{2}/images/{3}" ,httpContextAccessor.HttpContext.Request.Scheme , httpContextAccessor.HttpContext.Request.Host , httpContextAccessor.HttpContext.Request.PathBase , x.image1 )
                })
                .ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            Product product = await dbContext.products
                .Include(p => p.category)
                .FirstOrDefaultAsync(item => item.productID == id);
            product.ImageSrc = string.Format("{0}://{1}{2}/images/{3}", httpContextAccessor.HttpContext.Request.Scheme, httpContextAccessor.HttpContext.Request.Host, httpContextAccessor.HttpContext.Request.PathBase, product.image1);
            return product;
        }

        public async Task<Product> GetProductByName(string name)
        {
            Product product =  await dbContext.products.FirstOrDefaultAsync(item => item.name == name);
            product.ImageSrc = string.Format("{0}://{1}{2}/images/{3}", httpContextAccessor.HttpContext.Request.Scheme, httpContextAccessor.HttpContext.Request.Host, httpContextAccessor.HttpContext.Request.PathBase, product.image1);
            return product;
        }
        public async Task UpdateProduct(string id, ProductDTO productDTO)
        {
            var product_Update = await dbContext.products.FindAsync(id);
            if(product_Update != null)
            {
                product_Update.name = productDTO.name;
                product_Update.image1 = productDTO.image1;
                product_Update.image2 = productDTO.image2;
                product_Update.image3 = productDTO.image3;
                product_Update.description = productDTO.description;
                product_Update.nsn = productDTO.nsn;
                product_Update.category = await categoryRepository.GetCategoryById(productDTO.categoryId).ConfigureAwait(false);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("khong tim thay san pham can cap nhat");
            }

        }
        public async Task<string> saveImages(IFormFile imageFile)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray());
            imageName = imageName + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(environment.ContentRootPath,"images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
        public async Task DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(environment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
        public async Task<Product> MapDTO(ProductDTO productDTO)
        {
            return new Product
            {
                productID = productDTO.productID,
                name = productDTO.name,
                image1 = productDTO.image1,
                image2 = productDTO.image2,
                image3 = productDTO.image3,
                description = productDTO.description,
                nsn = productDTO.nsn,
                category = await categoryRepository.GetCategoryById(productDTO.categoryId)
            };
        }
    }
}
