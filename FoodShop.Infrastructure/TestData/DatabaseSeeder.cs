using FoodShop.Domain.Entities;

namespace FoodShop.Infrastructure.TestData
{
	public class DatabaseSeeder
	{

		public static async Task Seed(ApplicationDbContext dbContext)
		{

			dbContext.Database.EnsureCreated();


			var baseCategoryDiscriminators = new BaseCategoryDiscriminator[]
			{
				new BaseCategoryDiscriminator(Guid.NewGuid(),"Men"),
				new BaseCategoryDiscriminator(Guid.NewGuid(),"Women"),
			};

			dbContext.Set<BaseCategoryDiscriminator>().AddRange(baseCategoryDiscriminators);
			

			var SubCategories = new Category[]
			{
				new Category(Guid.NewGuid(),"Clothing",null,null),
				new Category(Guid.NewGuid(),"Shoes",null,null),
				new Category(Guid.NewGuid(),"Bags",null,null),
				new Category(Guid.NewGuid(),"Accessories",null,null),
			};

			dbContext.Set<Category>().AddRange(SubCategories);

			var WomenSubSubCategories = new Category[]
			{
				new Category(Guid.NewGuid(),"Dresses",SubCategories[0].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Tops & Bodysuits",SubCategories[0].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Knitwear",SubCategories[0].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Coats and trench coats",SubCategories[0].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Jackets",SubCategories[0].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Jeans",SubCategories[0].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Trousers",SubCategories[0].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Cargo & Parachute",SubCategories[0].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Skirts and shorts",SubCategories[0].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Sweatshirts and hoodies",SubCategories[0].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"T-shirts",SubCategories[0].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Blazer & suits",SubCategories[0].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Waistcoats",SubCategories[0].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Shirts & blouses",SubCategories[0].Id,baseCategoryDiscriminators[1].Id),


				new Category(Guid.NewGuid(),"Boots and ankle boots",SubCategories[1].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Biker boots",SubCategories[1].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Trainers",SubCategories[1].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Flat shoes",SubCategories[1].Id, baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Heeled shoes",SubCategories[1].Id, baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Sandals",SubCategories[1].Id, baseCategoryDiscriminators[1].Id),


				new Category(Guid.NewGuid(),"Large bags",SubCategories[2].Id, baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Shoulder bags",SubCategories[2].Id, baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Crossbody bags",SubCategories[2].Id, baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Travel bags",SubCategories[2].Id, baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Backbags bags",SubCategories[2].Id, baseCategoryDiscriminators[1].Id),
				
				new Category(Guid.NewGuid(),"Scarves",SubCategories[3].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Caps",SubCategories[3].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Hair accessories",SubCategories[3].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Earrings",SubCategories[3].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Necklace",SubCategories[3].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Rings",SubCategories[3].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Bracelets",SubCategories[3].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Socks",SubCategories[3].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Belts",SubCategories[3].Id,baseCategoryDiscriminators[1].Id),
				new Category(Guid.NewGuid(),"Sunglasses",SubCategories[3].Id,baseCategoryDiscriminators[1].Id),
			};

			dbContext.Set<Category>().AddRange(WomenSubSubCategories);


			var MenSubSubCategories = new Category[]
			{
				new Category(Guid.NewGuid(),"Trausers",SubCategories[0].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Jeans",SubCategories[0].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Shorts",SubCategories[0].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"T-shirts",SubCategories[0].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Sweatshirts and hoodies",SubCategories[0].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Jackets",SubCategories[0].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Coats",SubCategories[0].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Shirts",SubCategories[0].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Overshirts",SubCategories[0].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Knits",SubCategories[0].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Tracksuit",SubCategories[0].Id,baseCategoryDiscriminators[0].Id),


				new Category(Guid.NewGuid(),"Boots and ankle boots",SubCategories[1].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Trainers",SubCategories[1].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Casual shoes",SubCategories[1].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Sandals",SubCategories[1].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Leather",SubCategories[1].Id,baseCategoryDiscriminators[0].Id),

				new Category(Guid.NewGuid(),"Crossbody bags",SubCategories[2].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Backbags",SubCategories[2].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Large bags",SubCategories[2].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Travel bags",SubCategories[2].Id,baseCategoryDiscriminators[0].Id),

				new Category(Guid.NewGuid(),"Jewellery",SubCategories[3].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Sunglasses",SubCategories[3].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Wallets",SubCategories[3].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Belts",SubCategories[3].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Caps, Hats",SubCategories[3].Id,baseCategoryDiscriminators[0].Id),
				new Category(Guid.NewGuid(),"Gloves",SubCategories[3].Id,baseCategoryDiscriminators[0].Id),
			};

			dbContext.Set<Category>().AddRange(MenSubSubCategories);

			var variations = new Variation[]
			{
				new Variation(Guid.NewGuid(),"Size")
			};

			dbContext.Set<Variation>().AddRange(variations);

			var variationCategories = new VariationCategory[]
			{

				new VariationCategory(SubCategories[0].Id, variations[0].Id),
				new VariationCategory(SubCategories[1].Id, variations[0].Id),
				new VariationCategory(SubCategories[2].Id, variations[0].Id),
				new VariationCategory(SubCategories[3].Id, variations[0].Id),
			};

			dbContext.AddRange(variationCategories);

			var variationOptions = new VariationOption[]
			{
				new VariationOption(Guid.NewGuid(),variations[0].Id,"Small","S"),
				new VariationOption(Guid.NewGuid(),variations[0].Id,"Medium","M"),
				new VariationOption(Guid.NewGuid(),variations[0].Id,"Large","L"),
				new VariationOption(Guid.NewGuid(),variations[0].Id,"XL","XL"),
			};

			dbContext.Set<VariationOption>().AddRange(variationOptions);

			var products = new Product[]
			{
				new Product(Guid.NewGuid(),"Jeans1","Some desc",MenSubSubCategories[1].Id,"https://th.bing.com/th/id/R.77bd6611845095f8efa6f689078aead8?rik=zsU8Iq2Po6xdSg&riu=http%3a%2f%2fwww.pngall.com%2fwp-content%2fuploads%2f2016%2f04%2fJeans-PNG-Images.png&ehk=JJB05IBFMcp6b4uc2pLqmL8sNTfTGioIvL08ka6ySEY%3d&risl=&pid=ImgRaw&r=0"),
				new Product(Guid.NewGuid(),"Jeans2","Some desc2",MenSubSubCategories[1].Id,"https://th.bing.com/th/id/R.77bd6611845095f8efa6f689078aead8?rik=zsU8Iq2Po6xdSg&riu=http%3a%2f%2fwww.pngall.com%2fwp-content%2fuploads%2f2016%2f04%2fJeans-PNG-Images.png&ehk=JJB05IBFMcp6b4uc2pLqmL8sNTfTGioIvL08ka6ySEY%3d&risl=&pid=ImgRaw&r=0"),
				new Product(Guid.NewGuid(),"Short1","Some desc1",MenSubSubCategories[3].Id,"https://th.bing.com/th/id/R.4b7fa19469f9341bbd6e3e793a881fab?rik=k%2fUVCywmkjcf9w&pid=ImgRaw&r=0"),
				new Product(Guid.NewGuid(),"Short2","Some desc2",MenSubSubCategories[3].Id,"https://th.bing.com/th/id/R.4b7fa19469f9341bbd6e3e793a881fab?rik=k%2fUVCywmkjcf9w&pid=ImgRaw&r=0"),
			};

			await dbContext.Set<Product>().AddRangeAsync(products);

			var prodEntries = new ProductEntry[]
			{
				new ProductEntry(Guid.NewGuid(),products[0].Id,"SKU",45.55m,"https://th.bing.com/th/id/R.4b7fa19469f9341bbd6e3e793a881fab?rik=k%2fUVCywmkjcf9w&pid=ImgRaw&r=0",3),
				new ProductEntry(Guid.NewGuid(),products[1].Id,"SKU",45.55m,"https://th.bing.com/th/id/R.4b7fa19469f9341bbd6e3e793a881fab?rik=k%2fUVCywmkjcf9w&pid=ImgRaw&r=0",3),
				new ProductEntry(Guid.NewGuid(),products[2].Id,"SKU",45.55m,"https://th.bing.com/th/id/R.4b7fa19469f9341bbd6e3e793a881fab?rik=k%2fUVCywmkjcf9w&pid=ImgRaw&r=0",3),
			};

			await dbContext.Set<ProductEntry>().AddRangeAsync(prodEntries);



			dbContext.SaveChanges();
		}


	}
}
