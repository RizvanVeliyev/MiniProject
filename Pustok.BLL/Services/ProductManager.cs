using AutoMapper;
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
        
        public ProductManager(IProductRepository productRepository, IMapper mapper,CloudinaryManager cloudinaryManager) : base(productRepository, mapper)
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
            var createdProductViewModel = await base.CreateAsync(createViewModel);
            return createdProductViewModel;
        }


        //public override async Task<ProductViewModel> CreateAsync(ProductCreateViewModel createViewModel)
        //{
        //    if (!createViewModel.MainImage.IsImage())
        //    {
        //        throw new Exception("Not an Image");
        //    }

        //    if (!createViewModel.MainImage.AllowedSize(2))
        //    {
        //        throw new Exception("Invalid image size");
        //    }


        //    foreach (var image in createViewModel.AdditionalImages)
        //    {
        //        if (!image.IsImage())
        //        {
        //            throw new Exception("Not an Image");

        //        }

        //        if (!image.AllowedSize(2))
        //        {
        //            throw new Exception("Invalid image size");
        //        }
        //    }





        //    //Product product = new()
        //    //{
        //    //    Name = createViewModel.Name,
        //    //    Price = createViewModel.Price,
        //    //    ProductCode=createViewModel.ProductCode,
        //    //    Brand=createViewModel.Brand,
        //    //    Description=createViewModel.Description,
        //    //    DiscountPrice=createViewModel.DiscountPrice,
        //    //    Color=createViewModel.Color,
        //    //    StockQuantity=createViewModel.StockQuantity,
        //    //    Rating = createViewModel.Rating,
        //    //    Tax=createViewModel.Tax,
        //    //    RewardPoint=createViewModel.RewardPoint,
        //    //    Category=createViewModel.Category,

        //    //};



        //    //var mainImagePath = await _cloudinaryManager.FileCreateAsync(createViewModel.MainImage);

        //    //ProductImage mainImage = new()
        //    //{
        //    //    IsMain = true,
        //    //    Path = mainImagePath,
        //    //    Product = product
        //    //};

        //    //product.ProductImages.Add(mainImage);




        //    //foreach (var image in createViewModel.AdditionalImages)
        //    //{
        //    //    var ImagePath = await _cloudinaryManager.FileCreateAsync(createViewModel.MainImage);

        //    //    ProductImage productImg = new()
        //    //    {
        //    //        Path = ImagePath,
        //    //        Product = product
        //    //    };

        //    //    product.ProductImages.Add(productImg);

        //    //}

        //    ////var imageName = await createViewModel.ImageFile.GenerateFile(FilePathConstants.CategoryImagePath);

        //    //var imageName = await _cloudinaryManager.FileCreateAsync(createViewModel.MainImage);
        //    ////createViewModel.ImageUrl = imageName;
        //    ///
        //    var imageName = await _cloudinaryManager.FileCreateAsync(createViewModel.MainImage);
        //    createViewModel.ImageUrl = imageName;

        //    return await base.CreateAsync(createViewModel);
        //}

        //public async Task<IActionResult> Update(int id)
        //{
        //    var product = (await _productRepository.GetAllAsync(predicate: p => !p.IsDeleted, include: p => p.Include(p => p.ProductImages))).FirstOrDefault(x => x.Id == id);

        //    if (product is null)
        //        return NotFound(); 


        //    ProductUpdateViewModel vm = new()
        //    {
        //        Id = id,
        //        Name = product.Name,
        //        Price = product.Price,
        //        ProductCode= product.ProductCode,
        //        Brand= product.Brand,
        //        Description= product.Description,
        //        DiscountPrice= product.DiscountPrice,
        //        Color= product.Color,
        //        StockQuantity= product.StockQuantity,
        //        Rating = product.Rating,
        //        Tax= product.Tax,
        //        RewardPoint= product.RewardPoint,
        //        Category= product.Category,
        //        MainImagePath = product.ProductImages.FirstOrDefault(x => x.IsMain)?.Path ?? "undifenied",
        //        AdditionalImagePaths = product.ProductImages.Where(x => x.IsMain == false).Select(x => x.Path).ToList(),
        //        AdditionalImageIds = product.ProductImages.Where(x => x.IsMain == false).Select(x => x.Id).ToList()
        //    };

        //    return View(vm);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Update(ProductUpdateViewModel vm)
        //{

        //    if (!ModelState.IsValid)
        //        return View(vm);


        //    var existProduct = await _context.Products.Include(x => x.ProductImages).FirstOrDefaultAsync(x => x.Id == vm.Id);

        //    if (existProduct is null)
        //        return BadRequest();



        //    #region File Validations
        //    if (!vm.MainImage?.CheckType() ?? false)
        //    {
        //        ModelState.AddModelError("MainImage", "Please enter valid input");
        //        return View(vm);
        //    }

        //    if (!vm.MainImage?.CheckSize(2) ?? false)
        //    {
        //        ModelState.AddModelError("MainImage", "Please enter valid input");
        //        return View(vm);
        //    }

        //    if (!vm.HoverImage?.CheckType() ?? false)
        //    {
        //        ModelState.AddModelError("HoverImage", "Please enter valid input");
        //        return View(vm);
        //    }

        //    if (!vm.HoverImage?.CheckSize(2) ?? false)
        //    {
        //        ModelState.AddModelError("HoverImage", "Please enter valid input");
        //        return View(vm);
        //    }



        //    foreach (var image in vm.AdditionalImages)
        //    {
        //        if (!image.CheckType())
        //        {
        //            ModelState.AddModelError("AdditionalImages", "Please enter valid input");
        //            return View(vm);
        //        }

        //        if (!image.CheckSize(2))
        //        {
        //            ModelState.AddModelError("AdditionalImages", "Please enter valid input");
        //            return View(vm);
        //        }
        //    }
        //    #endregion

        //    #region modifie MainImage
        //    if (vm.MainImage is { })
        //    {
        //        var mainImage = existProduct.ProductImages.FirstOrDefault(x => x.IsMain);

        //        string mainImagePath = await vm.MainImage.CreateImageAsync(FOLDER_PATH);
        //        if (mainImage != null)
        //        {
        //            mainImage.Path.DeleteFile(FOLDER_PATH);
        //            mainImage!.Path = mainImagePath;

        //            _context.ProductImages.Update(mainImage);
        //        }
        //        else
        //        {
        //            ProductImage newMainImage = new()
        //            {
        //                IsMain = true,
        //                Path = mainImagePath,
        //                Product = existProduct
        //            };

        //            existProduct.ProductImages.Add(newMainImage);
        //        }
        //    }
        //    #endregion

        //    #region modifie HoverImage
        //    if (vm.HoverImage is { })
        //    {
        //        var hoverImage = existProduct.ProductImages.FirstOrDefault(x => x.IsHover);
        //        string hoverImagePath = await vm.HoverImage.CreateImageAsync(FOLDER_PATH);

        //        if (hoverImage is not null)
        //        {
        //            hoverImage.Path.DeleteFile(FOLDER_PATH);
        //            hoverImage.Path = hoverImagePath;

        //            _context.ProductImages.Update(hoverImage);
        //        }
        //        else
        //        {
        //            ProductImage newHoverImage = new()
        //            {
        //                IsHover = true,
        //                Path = hoverImagePath,
        //                Product = existProduct
        //            };

        //            existProduct.ProductImages.Add(newHoverImage);
        //        }
        //    }

        //    #endregion

        //    #region delete old images


        //    var oldImgIds = existProduct.ProductImages.Where(x => x.IsMain == false && x.IsHover == false).Select(x => x.Id).ToList();


        //    foreach (var imageId in oldImgIds)
        //    {

        //        var isExist = vm.AdditionalImageIds.Any(x => x == imageId);

        //        if (isExist is false)
        //        {
        //            var image = await _context.ProductImages.FirstOrDefaultAsync(x => x.Id == imageId);

        //            if (image is { })
        //            {
        //                image.Path.DeleteFile(FOLDER_PATH);
        //                _context.ProductImages.Remove(image);
        //            }
        //        }

        //    }

        //    #endregion

        //    #region create new images
        //    foreach (var image in vm.AdditionalImages)
        //    {
        //        string imagePath = await image.CreateImageAsync(FOLDER_PATH);

        //        ProductImage productImage = new()
        //        {
        //            Path = imagePath,
        //            Product = existProduct
        //        };
        //        existProduct.ProductImages.Add(productImage);

        //    }
        //    #endregion

        //    existProduct.Name = vm.Name;
        //    existProduct.Rating = vm.Rating;
        //    existProduct.Price = vm.Price;


        //    await _context.SaveChangesAsync();

        //    return RedirectToAction("Index");

        //}
    }





}
