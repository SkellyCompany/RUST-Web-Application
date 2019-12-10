using RUSTWebApplication.Core.Authentication;
using RUSTWebApplication.Core.Entity.Authentication;
using RUSTWebApplication.Core.Entity.Order;
using RUSTWebApplication.Core.Entity.Product;
using System;
using System.Collections.Generic;

namespace RUSTWebApplication.Infrastructure
{
	public class DbInitializer : IDbInitializer
	{
		private readonly IAuthenticationHelper _authenticationHelper;


		public DbInitializer(IAuthenticationHelper authenticationHelper)
		{
			_authenticationHelper = authenticationHelper;
		}

		public void Seed(RUSTWebApplicationContext context)
		{
			/*Authentication*/
			//Users
			string userPassword = "1234";
			_authenticationHelper.CreatePasswordHash(userPassword, out byte[] passwordHashAdmin, out byte[] passwordSaltAdmin);
			context.Users.Add(new User() { Username = "Admin", PasswordHash = passwordHashAdmin, PasswordSalt = passwordSaltAdmin, IsAdmin = true });


			/*Product*/
			//ProductCategories
			ProductCategory categoryTop = context.ProductCategories.Add(new ProductCategory() { Id = 1, Name = "Top" }).Entity;
			ProductCategory categoryBottom = context.ProductCategories.Add(new ProductCategory() { Id = 2, Name = "Bottom" }).Entity;

			//ProductMetrics
			context.ProductMetrics.Add(new ProductMetric() { Id = 1, Name = "Oversized Hoodie", MetricX = "Width", MetricY = "Length", MetricZ = "Sleeve Length"  });
			context.ProductMetrics.Add(new ProductMetric() { Id = 2, Name = "Chino", MetricX = "Waist", MetricY = "Leg Length" });

			//ProductSizes
			ProductSize sSize = context.ProductSizes.Add(new ProductSize() { Id = 1, Size = "S", MetricXValue = 66, MetricYValue = 94, MetricZValue = 70 }).Entity;
			ProductSize mSize = context.ProductSizes.Add(new ProductSize() { Id = 2, Size = "M", MetricXValue = 68, MetricYValue = 96, MetricZValue = 72 }).Entity;
			ProductSize lSize = context.ProductSizes.Add(new ProductSize() { Id = 3, Size = "L", MetricXValue = 70, MetricYValue = 98, MetricZValue = 74 }).Entity;
			ProductSize xlSize = context.ProductSizes.Add(new ProductSize() { Id = 4, Size = "XL", MetricXValue = 72, MetricYValue = 100, MetricZValue = 76 }).Entity;
			ProductSize xxlSize = context.ProductSizes.Add(new ProductSize() { Id = 5, Size = "XXL", MetricXValue = 74, MetricYValue = 102, MetricZValue = 78 }).Entity;

			//ProductModels
			ProductModel hoodieModel1 = context.ProductModels.Add(new ProductModel() { Id = 1, Name = "Rust In Peace Hoodie", ProductCategory = categoryTop, Price = 59.99, Products = null }).Entity;
			ProductModel hoodieModel2 = context.ProductModels.Add(new ProductModel() { Id = 2, Name = "Apocalypse Hoodie", ProductCategory = categoryTop, Price = 59.99, Products = null }).Entity;
			ProductModel hoodieModel3 = context.ProductModels.Add(new ProductModel() { Id = 3, Name = "Rape Hoodie", ProductCategory = categoryTop, Price = 59.99, Products = null }).Entity;
			ProductModel hoodieModel4 = context.ProductModels.Add(new ProductModel() { Id = 4, Name = "Ryu Hoodie", ProductCategory = categoryTop, Price = 59.99, Products = null }).Entity;
			ProductModel hoodieModel5 = context.ProductModels.Add(new ProductModel() { Id = 5, Name = "Logo Hoodie", ProductCategory = categoryTop, Price = 59.99, Products = null }).Entity;
			ProductModel pantsModel1 = context.ProductModels.Add(new ProductModel() { Id = 6, Name = "Rust In Peace Pants", ProductCategory = categoryBottom, Price = 75.99, Products = null }).Entity;
			ProductModel pantsModel2 = context.ProductModels.Add(new ProductModel() { Id = 7, Name = "Apocalypse Pants", ProductCategory = categoryBottom, Price = 75.99, Products = null }).Entity;
			ProductModel pantsModel3 = context.ProductModels.Add(new ProductModel() { Id = 8, Name = "Rape Pants", ProductCategory = categoryBottom, Price = 75.99, Products = null }).Entity;
			ProductModel pantsModel4 = context.ProductModels.Add(new ProductModel() { Id = 9, Name = "Ryu Pants", ProductCategory = categoryBottom, Price = 75.99, Products = null }).Entity;
			ProductModel pantsModel5 = context.ProductModels.Add(new ProductModel() { Id = 10, Name = "Logo Pants", ProductCategory = categoryBottom, Price = 75.99, Products = null }).Entity;

			//Products
			Product hoodieProduct1 = context.Products.Add(new Product() { Id = 1, ProductModel = hoodieModel1, ProductStocks = null, Color = "Black" }).Entity;
			Product hoodieProduct2 = context.Products.Add(new Product() { Id = 2, ProductModel = hoodieModel1, ProductStocks = null, Color = "Yellow" }).Entity;
			Product hoodieProduct3 = context.Products.Add(new Product() { Id = 3, ProductModel = hoodieModel1, ProductStocks = null, Color = "Pink" }).Entity;
			Product pantsProduct1 = context.Products.Add(new Product() { Id = 4, ProductModel = pantsModel1, ProductStocks = null, Color = "Black" }).Entity;
			Product pantsProduct2 = context.Products.Add(new Product() { Id = 5, ProductModel = pantsModel1, ProductStocks = null, Color = "Yellow" }).Entity;
			Product pantsProduct3 = context.Products.Add(new Product() { Id = 6, ProductModel = pantsModel1, ProductStocks = null, Color = "Pink" }).Entity;

			Product hoodieProduct4 = context.Products.Add(new Product() { Id = 7, ProductModel = hoodieModel2, ProductStocks = null, Color = "Black" }).Entity;
			Product hoodieProduct5 = context.Products.Add(new Product() { Id = 8, ProductModel = hoodieModel2, ProductStocks = null, Color = "Yellow" }).Entity;
			Product hoodieProduct6 = context.Products.Add(new Product() { Id = 9, ProductModel = hoodieModel2, ProductStocks = null, Color = "Pink" }).Entity;
			Product pantsProduct4 = context.Products.Add(new Product() { Id = 10, ProductModel = pantsModel2, ProductStocks = null, Color = "Black" }).Entity;
			Product pantsProduct5 = context.Products.Add(new Product() { Id = 11, ProductModel = pantsModel2, ProductStocks = null, Color = "Yellow" }).Entity;
			Product pantsProduct6 = context.Products.Add(new Product() { Id = 12, ProductModel = pantsModel2, ProductStocks = null, Color = "Pink" }).Entity;

			Product hoodieProduct7 = context.Products.Add(new Product() { Id = 13, ProductModel = hoodieModel3, ProductStocks = null, Color = "Black" }).Entity;
			Product hoodieProduct8 = context.Products.Add(new Product() { Id = 14, ProductModel = hoodieModel3, ProductStocks = null, Color = "Yellow" }).Entity;
			Product hoodieProduct9 = context.Products.Add(new Product() { Id = 15, ProductModel = hoodieModel3, ProductStocks = null, Color = "Pink" }).Entity;
			Product pantsProduct7 = context.Products.Add(new Product() { Id = 16, ProductModel = pantsModel3, ProductStocks = null, Color = "Black" }).Entity;
			Product pantsProduct8 = context.Products.Add(new Product() { Id = 17, ProductModel = pantsModel3, ProductStocks = null, Color = "Yellow" }).Entity;
			Product pantsProduct9 = context.Products.Add(new Product() { Id = 18, ProductModel = pantsModel3, ProductStocks = null, Color = "Pink" }).Entity;

			Product hoodieProduct10 = context.Products.Add(new Product() { Id = 19, ProductModel = hoodieModel4, ProductStocks = null, Color = "Black" }).Entity;
			Product hoodieProduct11 = context.Products.Add(new Product() { Id = 20, ProductModel = hoodieModel4, ProductStocks = null, Color = "Yellow" }).Entity;
			Product hoodieProduct12 = context.Products.Add(new Product() { Id = 21, ProductModel = hoodieModel4, ProductStocks = null, Color = "Pink" }).Entity;
			Product pantsProduct10 = context.Products.Add(new Product() { Id = 22, ProductModel = pantsModel4, ProductStocks = null, Color = "Black" }).Entity;
			Product pantsProduct11 = context.Products.Add(new Product() { Id = 23, ProductModel = pantsModel4, ProductStocks = null, Color = "Yellow" }).Entity;
			Product pantsProduct12 = context.Products.Add(new Product() { Id = 24, ProductModel = pantsModel4, ProductStocks = null, Color = "Pink" }).Entity;

			Product hoodieProduct13 = context.Products.Add(new Product() { Id = 25, ProductModel = hoodieModel5, ProductStocks = null, Color = "Black" }).Entity;
			Product hoodieProduct14 = context.Products.Add(new Product() { Id = 26, ProductModel = hoodieModel5, ProductStocks = null, Color = "Yellow" }).Entity;
			Product hoodieProduct15 = context.Products.Add(new Product() { Id = 27, ProductModel = hoodieModel5, ProductStocks = null, Color = "Pink" }).Entity;
			Product pantsProduct13 = context.Products.Add(new Product() { Id = 28, ProductModel = pantsModel5, ProductStocks = null, Color = "Black" }).Entity;
			Product pantsProduct14 = context.Products.Add(new Product() { Id = 29, ProductModel = pantsModel5, ProductStocks = null, Color = "Yellow" }).Entity;
			Product pantsProduct15 = context.Products.Add(new Product() { Id = 30, ProductModel = pantsModel5, ProductStocks = null, Color = "Pink" }).Entity;

			//ProductStocks
			ProductStock blackHoodieSmallStock1 = context.ProductStocks.Add(new ProductStock() { Id = 1, Product = hoodieProduct1, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieMediumStock1 = context.ProductStocks.Add(new ProductStock() { Id = 2, Product = hoodieProduct1, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 3, Product = hoodieProduct1, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieExtraLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 4, Product = hoodieProduct1, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieExtraExtraLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 5, Product = hoodieProduct1, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieSmallStock1 = context.ProductStocks.Add(new ProductStock() { Id = 6, Product = hoodieProduct2, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieMediumStock1 = context.ProductStocks.Add(new ProductStock() { Id = 7, Product = hoodieProduct2, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 8, Product = hoodieProduct2, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieExtraLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 9, Product = hoodieProduct2, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieExtraExtraLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 10, Product = hoodieProduct2, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieSmallStock1 = context.ProductStocks.Add(new ProductStock() { Id = 11, Product = hoodieProduct3, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieMediumStock1 = context.ProductStocks.Add(new ProductStock() { Id = 12, Product = hoodieProduct3, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 13, Product = hoodieProduct3, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieExtraLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 14, Product = hoodieProduct3, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieExtraExtraLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 15, Product = hoodieProduct3, ProductSize = xxlSize, Quantity = 20 }).Entity;

			ProductStock blackPantsSmallStock1 = context.ProductStocks.Add(new ProductStock() { Id = 16, Product = pantsProduct1, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock blackPantsMediumStock1 = context.ProductStocks.Add(new ProductStock() { Id = 17, Product = pantsProduct1, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock blackPantsLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 18, Product = pantsProduct1, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock blackPantsExtraLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 19, Product = pantsProduct1, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock blackPantsExtraExtraLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 20, Product = pantsProduct1, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock yellowPantseSmallStock1 = context.ProductStocks.Add(new ProductStock() { Id = 21, Product = pantsProduct2, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsMediumStock1 = context.ProductStocks.Add(new ProductStock() { Id = 22, Product = pantsProduct2, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 23, Product = pantsProduct2, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsExtraLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 24, Product = pantsProduct2, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsExtraExtraLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 25, Product = pantsProduct2, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsSmallStock1 = context.ProductStocks.Add(new ProductStock() { Id = 26, Product = pantsProduct3, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsMediumStock1 = context.ProductStocks.Add(new ProductStock() { Id = 27, Product = pantsProduct3, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 28, Product = pantsProduct3, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsExtraLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 29, Product = pantsProduct3, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsExtraExtraLargeStock1 = context.ProductStocks.Add(new ProductStock() { Id = 30, Product = pantsProduct3, ProductSize = xxlSize, Quantity = 20 }).Entity;

			//=============================//

			ProductStock blackHoodieSmallStock2 = context.ProductStocks.Add(new ProductStock() { Id = 31, Product = hoodieProduct4, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieMediumStock2 = context.ProductStocks.Add(new ProductStock() { Id = 32, Product = hoodieProduct4, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 33, Product = hoodieProduct4, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieExtraLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 34, Product = hoodieProduct4, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieExtraExtraLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 35, Product = hoodieProduct4, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieSmallStock2 = context.ProductStocks.Add(new ProductStock() { Id = 36, Product = hoodieProduct5, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieMediumStock2 = context.ProductStocks.Add(new ProductStock() { Id = 37, Product = hoodieProduct5, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 38, Product = hoodieProduct5, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieExtraLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 39, Product = hoodieProduct5, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieExtraExtraLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 40, Product = hoodieProduct5, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieSmallStock2 = context.ProductStocks.Add(new ProductStock() { Id = 41, Product = hoodieProduct6, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieMediumStock2 = context.ProductStocks.Add(new ProductStock() { Id = 42, Product = hoodieProduct6, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 43, Product = hoodieProduct6, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieExtraLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 44, Product = hoodieProduct6, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieExtraExtraLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 45, Product = hoodieProduct6, ProductSize = xxlSize, Quantity = 20 }).Entity;

			ProductStock blackPantsSmallStock2 = context.ProductStocks.Add(new ProductStock() { Id = 46, Product = pantsProduct4, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock blackPantsMediumStock2 = context.ProductStocks.Add(new ProductStock() { Id = 47, Product = pantsProduct4, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock blackPantsLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 48, Product = pantsProduct4, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock blackPantsExtraLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 49, Product = pantsProduct4, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock blackPantsExtraExtraLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 50, Product = pantsProduct4, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock yellowPantseSmallStock2 = context.ProductStocks.Add(new ProductStock() { Id = 51, Product = pantsProduct5, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsMediumStock2 = context.ProductStocks.Add(new ProductStock() { Id = 52, Product = pantsProduct5, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 53, Product = pantsProduct5, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsExtraLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 54, Product = pantsProduct5, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsExtraExtraLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 55, Product = pantsProduct5, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsSmallStock2 = context.ProductStocks.Add(new ProductStock() { Id = 56, Product = pantsProduct6, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsMediumStock2 = context.ProductStocks.Add(new ProductStock() { Id = 57, Product = pantsProduct6, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 58, Product = pantsProduct6, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsExtraLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 59, Product = pantsProduct6, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsExtraExtraLargeStock2 = context.ProductStocks.Add(new ProductStock() { Id = 60, Product = pantsProduct6, ProductSize = xxlSize, Quantity = 20 }).Entity;

			//=============================//

			ProductStock blackHoodieSmallStock3 = context.ProductStocks.Add(new ProductStock() { Id = 61, Product = hoodieProduct7, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieMediumStock3 = context.ProductStocks.Add(new ProductStock() { Id = 62, Product = hoodieProduct7, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 63, Product = hoodieProduct7, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieExtraLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 64, Product = hoodieProduct7, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieExtraExtraLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 65, Product = hoodieProduct7, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieSmallStock3 = context.ProductStocks.Add(new ProductStock() { Id = 66, Product = hoodieProduct8, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieMediumStock3 = context.ProductStocks.Add(new ProductStock() { Id = 67, Product = hoodieProduct8, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 68, Product = hoodieProduct8, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieExtraLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 69, Product = hoodieProduct8, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieExtraExtraLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 70, Product = hoodieProduct8, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieSmallStock3 = context.ProductStocks.Add(new ProductStock() { Id = 71, Product = hoodieProduct9, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieMediumStock3 = context.ProductStocks.Add(new ProductStock() { Id = 72, Product = hoodieProduct9, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 73, Product = hoodieProduct9, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieExtraLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 74, Product = hoodieProduct9, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieExtraExtraLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 75, Product = hoodieProduct9, ProductSize = xxlSize, Quantity = 20 }).Entity;

			ProductStock blackPantsSmallStock3 = context.ProductStocks.Add(new ProductStock() { Id = 76, Product = pantsProduct7, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock blackPantsMediumStock3 = context.ProductStocks.Add(new ProductStock() { Id = 77, Product = pantsProduct7, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock blackPantsLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 78, Product = pantsProduct7, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock blackPantsExtraLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 79, Product = pantsProduct7, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock blackPantsExtraExtraLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 80, Product = pantsProduct7, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock yellowPantseSmallStock3 = context.ProductStocks.Add(new ProductStock() { Id = 81, Product = pantsProduct8, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsMediumStock3 = context.ProductStocks.Add(new ProductStock() { Id = 82, Product = pantsProduct8, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 83, Product = pantsProduct8, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsExtraLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 84, Product = pantsProduct8, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsExtraExtraLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 85, Product = pantsProduct8, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsSmallStock3 = context.ProductStocks.Add(new ProductStock() { Id = 86, Product = pantsProduct9, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsMediumStock3 = context.ProductStocks.Add(new ProductStock() { Id = 87, Product = pantsProduct9, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 88, Product = pantsProduct9, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsExtraLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 89, Product = pantsProduct9, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsExtraExtraLargeStock3 = context.ProductStocks.Add(new ProductStock() { Id = 90, Product = pantsProduct9, ProductSize = xxlSize, Quantity = 20 }).Entity;

			//=============================//


			ProductStock blackHoodieSmallStock4 = context.ProductStocks.Add(new ProductStock() { Id = 91, Product = hoodieProduct10, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieMediumStock4 = context.ProductStocks.Add(new ProductStock() { Id = 92, Product = hoodieProduct10, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 93, Product = hoodieProduct10, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieExtraLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 94, Product = hoodieProduct10, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieExtraExtraLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 95, Product = hoodieProduct10, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieSmallStock4 = context.ProductStocks.Add(new ProductStock() { Id = 96, Product = hoodieProduct11, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieMediumStock4 = context.ProductStocks.Add(new ProductStock() { Id = 97, Product = hoodieProduct11, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 98, Product = hoodieProduct11, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieExtraLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 99, Product = hoodieProduct11, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieExtraExtraLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 100, Product = hoodieProduct11, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieSmallStock4 = context.ProductStocks.Add(new ProductStock() { Id = 101, Product = hoodieProduct12, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieMediumStock4 = context.ProductStocks.Add(new ProductStock() { Id = 102, Product = hoodieProduct12, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 103, Product = hoodieProduct12, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieExtraLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 104, Product = hoodieProduct12, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieExtraExtraLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 105, Product = hoodieProduct12, ProductSize = xxlSize, Quantity = 20 }).Entity;

			ProductStock blackPantsSmallStock4 = context.ProductStocks.Add(new ProductStock() { Id = 106, Product = pantsProduct10, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock blackPantsMediumStock4 = context.ProductStocks.Add(new ProductStock() { Id = 107, Product = pantsProduct10, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock blackPantsLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 108, Product = pantsProduct10, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock blackPantsExtraLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 109, Product = pantsProduct10, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock blackPantsExtraExtraLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 110, Product = pantsProduct10, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock yellowPantseSmallStock4 = context.ProductStocks.Add(new ProductStock() { Id = 111, Product = pantsProduct11, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsMediumStock4 = context.ProductStocks.Add(new ProductStock() { Id = 112, Product = pantsProduct11, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 113, Product = pantsProduct11, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsExtraLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 114, Product = pantsProduct11, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsExtraExtraLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 115, Product = pantsProduct11, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsSmallStock4 = context.ProductStocks.Add(new ProductStock() { Id = 116, Product = pantsProduct12, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsMediumStock4 = context.ProductStocks.Add(new ProductStock() { Id = 117, Product = pantsProduct12, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 118, Product = pantsProduct12, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsExtraLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 119, Product = pantsProduct12, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsExtraExtraLargeStock4 = context.ProductStocks.Add(new ProductStock() { Id = 120, Product = pantsProduct12, ProductSize = xxlSize, Quantity = 20 }).Entity;

			//=============================//

			ProductStock blackHoodieSmallStock5 = context.ProductStocks.Add(new ProductStock() { Id = 121, Product = hoodieProduct13, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieMediumStock5 = context.ProductStocks.Add(new ProductStock() { Id = 122, Product = hoodieProduct13, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 123, Product = hoodieProduct13, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieExtraLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 124, Product = hoodieProduct13, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock blackHoodieExtraExtraLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 125, Product = hoodieProduct13, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieSmallStock5 = context.ProductStocks.Add(new ProductStock() { Id = 126, Product = hoodieProduct14, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieMediumStock5 = context.ProductStocks.Add(new ProductStock() { Id = 127, Product = hoodieProduct14, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 128, Product = hoodieProduct14, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieExtraLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 129, Product = hoodieProduct14, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock yellowHoodieExtraExtraLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 130, Product = hoodieProduct14, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieSmallStock5 = context.ProductStocks.Add(new ProductStock() { Id = 131, Product = hoodieProduct15, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieMediumStock5 = context.ProductStocks.Add(new ProductStock() { Id = 132, Product = hoodieProduct15, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 133, Product = hoodieProduct15, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieExtraLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 134, Product = hoodieProduct15, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock pinkHoodieExtraExtraLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 135, Product = hoodieProduct15, ProductSize = xxlSize, Quantity = 20 }).Entity;

			ProductStock blackPantsSmallStock5 = context.ProductStocks.Add(new ProductStock() { Id = 136, Product = pantsProduct13, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock blackPantsMediumStock5 = context.ProductStocks.Add(new ProductStock() { Id = 137, Product = pantsProduct13, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock blackPantsLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 138, Product = pantsProduct13, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock blackPantsExtraLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 139, Product = pantsProduct13, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock blackPantsExtraExtraLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 140, Product = pantsProduct13, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock yellowPantseSmallStock5 = context.ProductStocks.Add(new ProductStock() { Id = 141, Product = pantsProduct14, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsMediumStock5 = context.ProductStocks.Add(new ProductStock() { Id = 142, Product = pantsProduct14, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 143, Product = pantsProduct14, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsExtraLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 144, Product = pantsProduct14, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock yellowPantsExtraExtraLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 145, Product = pantsProduct14, ProductSize = xxlSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsSmallStock5 = context.ProductStocks.Add(new ProductStock() { Id = 146, Product = pantsProduct15, ProductSize = sSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsMediumStock5 = context.ProductStocks.Add(new ProductStock() { Id = 147, Product = pantsProduct15, ProductSize = mSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 148, Product = pantsProduct15, ProductSize = lSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsExtraLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 149, Product = pantsProduct15, ProductSize = xlSize, Quantity = 20 }).Entity;
			ProductStock pinkPantsExtraExtraLargeStock5 = context.ProductStocks.Add(new ProductStock() { Id = 150, Product = pantsProduct15, ProductSize = xxlSize, Quantity = 20 }).Entity;

			/*Order*/
			//Countries
			Country denmarkCountry = context.Countries.Add(new Country() { Id = 1, Name = "Denmark" }).Entity;
			Country polandCountry = context.Countries.Add(new Country() { Id = 2, Name = "Poland" }).Entity;
			Country unitedStatesCountry = context.Countries.Add(new Country() { Id = 3, Name = "United States" }).Entity;

			//OrderLines
			OrderLine blackHoodieExtraExtraLargeOrderLine = context.OrderLines.Add(new OrderLine() { Order = null, ProductStock = blackHoodieExtraExtraLargeStock1, Quantity = 1 }).Entity;
			OrderLine pinkHoodieExtraExtraLargeOrderLine = context.OrderLines.Add(new OrderLine() { Order = null, ProductStock = pinkHoodieExtraExtraLargeStock2, Quantity = 1 }).Entity;
			OrderLine yellowHoodieMediumOrderLine = context.OrderLines.Add(new OrderLine() { Order = null, ProductStock = yellowHoodieMediumStock4, Quantity = 1 }).Entity;
			OrderLine yellowPantseSmallStockOrderLine = context.OrderLines.Add(new OrderLine() { Order = null, ProductStock = yellowPantseSmallStock2, Quantity = 1 }).Entity;

			//Orders
			context.Orders.Add(new Order() { Id = 1, OrderLines = new List<OrderLine>(){ blackHoodieExtraExtraLargeOrderLine}, Country = polandCountry, OrderDate = DateTime.Parse("07/05/2019"), DeliveryDate = DateTime.Parse("07/21/2019"), FirstName = "Grzegorz", LastName = "Charyszczak", Address = "Zelwerowicza 18/6", ZipCode = "54-238", City = "Warszawa", Phone = "+48509840123", Email = "schemaboi@gmail.com" });
			context.Orders.Add(new Order() { Id = 2, OrderLines = new List<OrderLine>() { pinkHoodieExtraExtraLargeOrderLine, yellowPantseSmallStockOrderLine, yellowHoodieMediumOrderLine }, Country = denmarkCountry, OrderDate = DateTime.Parse("09/01/2019"), DeliveryDate = DateTime.Parse("09/10/2019"), FirstName = "David", LastName = "Kalatzis",Address = "Jyllandsgade 55st", ZipCode = "6700", City = "Esbjerg", Phone = "+45409720140", Email = "steven1995@gmail.com" });

            context.SaveChanges();
		}
	}
}
