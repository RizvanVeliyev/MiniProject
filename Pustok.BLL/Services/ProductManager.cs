using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pustok.BLL.Exceptions;
using Pustok.BLL.Extensions;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.ProductViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.BLL.Services
{
    public class ProductManager : CrudManager<Product, ProductViewModel, ProductCreateViewModel, ProductUpdateViewModel>, IProductService
    {
        private readonly IMapper _mapper;
        private readonly CloudinaryManager _cloudinaryManager;
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository, IMapper mapper, CloudinaryManager cloudinaryManager) : base(productRepository, mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _cloudinaryManager = cloudinaryManager;

        }
        public override async Task<ProductViewModel> CreateAsync(ProductCreateViewModel createViewModel)
        {
            // Check if main image is valid
            if (!createViewModel.MainImage.IsImage())
            {
                throw new Exception("Not an Image");
            }

            if (!createViewModel.MainImage.AllowedSize(2))
            {
                throw new Exception("Invalid image size");
            }

            // Check additional images
            foreach (var image in createViewModel.AdditionalImages)
            {
                if (!image.IsImage())
                {
                    throw new Exception("Not an Image");
                }

                if (!image.AllowedSize(2))
                {
                    throw new Exception("Invalid image size");
                }
            }

            // Map ProductCreateViewModel to Product entity using AutoMapper
            Product product = _mapper.Map<Product>(createViewModel);

            product.ProductImages = [];

            // Upload main image and set as primary
            var mainImagePath = await _cloudinaryManager.FileCreateAsync(createViewModel.MainImage);
            ProductImage mainImage = new()
            {
                IsMain = true,
                Path = mainImagePath,
                Product = product
            };
            product.ProductImages.Add(mainImage);

            // Upload additional images
            foreach (var image in createViewModel.AdditionalImages)
            {
                var imagePath = await _cloudinaryManager.FileCreateAsync(image);
                ProductImage additionalImage = new()
                {
                    IsMain = false,
                    Path = imagePath,
                    Product = product
                };
                product.ProductImages.Add(additionalImage);
            }

            // Save the product using the base method
            //var productLastVersion = _mapper.Map<ProductCreateViewModel, Product>(createViewModel);


            await _productRepository.CreateAsync(product);

            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return productViewModel;
        }


        //public async Task<IActionResult> Update(int id)
        //{
        //    var product = await _context.Products.Include(x => x.ProductImages).FirstOrDefaultAsync(x => x.Id == id);

        //    if (product is null)
        //        return NotFound();


        //    ProductUpdateViewModel vm = new()
        //    {
        //        Id = id,
        //        Name = product.Name,
        //        Price = product.Price,
        //        Rating = product.Rating,
        //        HoverImagePath = product.ProductImages.FirstOrDefault(x => x.IsHover)?.Path ?? "undifenied",
        //        MainImagePath = product.ProductImages.FirstOrDefault(x => x.IsMain)?.Path ?? "undifenied",
        //        AdditionalImagePaths = product.ProductImages.Where(x => x.IsMain == false && x.IsHover == false).Select(x => x.Path).ToList(),
        //        AdditionalImageIds = product.ProductImages.Where(x => x.IsMain == false && x.IsHover == false).Select(x => x.Id).ToList()
        //    };

        //    return View(vm);
        //}

        public async Task<ProductUpdateViewModel> GetUpdatedProductAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);

            if (product is null)
                throw new NotFoundException($"{id}-this category is not found");


            ProductUpdateViewModel vm = _mapper.Map<ProductUpdateViewModel>(product);


            return vm;
        }

        public override async Task<ProductViewModel> UpdateAsync(ProductUpdateViewModel updateViewModel)
        {

            //var existProduct = await _context.Products.Include(x => x.ProductImages).FirstOrDefaultAsync(x => x.Id == vm.Id);
            var existProduct = await _productRepository.GetAsync(predicate: p => p.Id == updateViewModel.Id, include: p => p.Include(p => p.ProductImages));
            if (existProduct == null) throw new Exception("product not found");

            if (!updateViewModel.MainImage.IsImage())
            {
                throw new Exception("Not an Image");
            }

            if (!updateViewModel.MainImage.AllowedSize(2))
            {
                throw new Exception("Invalid image size");
            }



            foreach (var image in updateViewModel.AdditionalImages)
            {
                if (!image.IsImage())
                {
                    throw new Exception("Not an Image");
                }

                if (!image.AllowedSize(2))
                {
                    throw new Exception("Invalid image size");
                }
            }

            #region modifie MainImage
            if (updateViewModel.MainImage is { })
            {
                var mainImage = existProduct.ProductImages.FirstOrDefault(x => x.IsMain);

                //string mainImagePath = await vm.MainImage.CreateImageAsync(FOLDER_PATH);
                var mainImagePath = await _cloudinaryManager.FileCreateAsync(updateViewModel.MainImage);

                if (mainImage != null)
                {
                    //mainImage.Path.DeleteFile(FOLDER_PATH);
                    var Isdeleted = await _cloudinaryManager.FileDeleteAsync(mainImagePath);
                    mainImage!.Path = mainImagePath;

                    //_context.ProductImages.Update(mainImage);
                    //_productImageRepository.UpdateAsync(mainImage);
                }
                else
                {
                    ProductImage newMainImage = new()
                    {
                        IsMain = true,
                        Path = mainImagePath,
                        Product = existProduct
                    };

                    existProduct.ProductImages.Add(newMainImage);
                }
            }
            #endregion


            #region delete old images


            var oldImgIds = existProduct.ProductImages.Where(x => x.IsMain == false).Select(x => x.Id).ToList();


            foreach (var imageId in oldImgIds)
            {

                var isExist = updateViewModel.AdditionalImageIds.Any(x => x == imageId);

                if (isExist is false)
                {
                    //var image = await _context.ProductImages.FirstOrDefaultAsync(x => x.Id == imageId);
                    //var image=await _productImageRepository.GetAsync(imageId);
                    var image = existProduct.ProductImages.FirstOrDefault(x => x.Id == imageId);


                    if (image is { })
                    {
                        //image.Path.DeleteFile(FOLDER_PATH);
                        var isDeleted=await _cloudinaryManager.FileDeleteAsync(image.Path);
                        //_context.ProductImages.Remove(image);
                        existProduct.ProductImages.Remove(image);
                    }
                }

            }

            #endregion

            #region create new images
            foreach (var image in updateViewModel.AdditionalImages)
            {
                //string imagePath = await image.CreateImageAsync(FOLDER_PATH);
                var imagePath = await _cloudinaryManager.FileCreateAsync(image);


                ProductImage productImage = new()
                {
                    Path = imagePath,
                    Product = existProduct
                };
                existProduct.ProductImages.Add(productImage);

            }
            #endregion
            _mapper.Map(updateViewModel, existProduct);



            //await _context.SaveChangesAsync();

            //return RedirectToAction("Index");

            //var updatedProductViewModel = await base.UpdateAsync(updateViewModel);
            //return updatedProductViewModel;

            await _productRepository.UpdateAsync(existProduct);

            var productViewModel = _mapper.Map<ProductViewModel>(existProduct);
            return productViewModel;

        }
    }





}
