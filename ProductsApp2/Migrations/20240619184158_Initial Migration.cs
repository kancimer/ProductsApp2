using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductsApp2.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ProductDescription", "ProductImageUrl", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { new Guid("2de2b713-e287-4572-9d69-7167522a9894"), "Boneless chicken breast", "https://example.com/chicken.jpg", "Chicken Breast", 5.0 },
                    { new Guid("35f6d981-8227-43fa-b12d-170c16129f37"), "Basmati rice", "https://example.com/rice.jpg", "Rice", 1.3 },
                    { new Guid("4a5c4d3c-6043-49c5-a3f6-5a4c45127b1b"), "Fresh red apples", "https://example.com/apple.jpg", "Apple", 1.2 },
                    { new Guid("52bada25-0165-4489-bdb1-aeaf45a579d7"), "Natural yogurt", "https://example.com/yogurt.jpg", "Yogurt", 0.90000000000000002 },
                    { new Guid("55d7d402-0e9d-409c-9211-b5cbb18eb8b3"), "Extra virgin olive oil", "https://example.com/oliveoil.jpg", "Olive Oil", 4.0 },
                    { new Guid("5f980d5e-5ded-4123-8261-497a9c9c4ae5"), "Sea salt", "https://example.com/salt.jpg", "Salt", 0.5 },
                    { new Guid("5f9ca34e-2943-4b78-b9a3-34a0614ef227"), "1 litre of whole milk", "https://example.com/milk.jpg", "Milk", 1.0 },
                    { new Guid("6dde3239-dddf-47cc-88f3-d682865f0d49"), "Black pepper", "https://example.com/pepper.jpg", "Pepper", 0.69999999999999996 },
                    { new Guid("867810b4-892b-4c8c-a061-56f6775bc875"), "Italian pasta", "https://example.com/pasta.jpg", "Pasta", 1.5 },
                    { new Guid("8726df8a-8b98-4790-a657-42f72d36c711"), "Juicy oranges", "https://example.com/orange.jpg", "Orange", 1.5 },
                    { new Guid("8819ca40-5dc2-457b-b738-c1bfe1489fcc"), "Cheddar cheese", "https://example.com/cheese.jpg", "Cheese", 2.5 },
                    { new Guid("9edebc18-5288-4e00-ae65-b9ef47d0e177"), "Fresh tomatoes", "https://example.com/tomato.jpg", "Tomato", 1.3 },
                    { new Guid("b700e3ca-9ccb-4eb1-8bca-44d7755fb3a0"), "Fresh potatoes", "https://example.com/potato.jpg", "Potato", 0.69999999999999996 },
                    { new Guid("c96b1755-5bfe-441d-b423-85a94df5045c"), "Whole grain bread", "https://example.com/bread.jpg", "Bread", 1.1000000000000001 },
                    { new Guid("d642480d-71a5-491e-8f91-c525ebbbc55d"), "Ripe bananas", "https://example.com/banana.jpg", "Banana", 0.80000000000000004 },
                    { new Guid("dd829339-d0ad-4887-bf2b-a060d528d6f4"), "A dozen eggs", "https://example.com/eggs.jpg", "Eggs", 2.0 },
                    { new Guid("e7af36fd-7a29-4ece-a2bf-a24f7592f170"), "Organic carrots", "https://example.com/carrot.jpg", "Carrot", 1.0 },
                    { new Guid("f831a1ff-68a3-4f57-a202-c2db685d727c"), "Green lettuce", "https://example.com/lettuce.jpg", "Lettuce", 1.2 },
                    { new Guid("f8fa3c1b-f100-4a56-b8c3-1aa6309fa908"), "Fresh salmon fillets", "https://example.com/salmon.jpg", "Salmon", 10.0 },
                    { new Guid("fce725c8-54c8-4292-bb25-ee35101e814f"), "Salted butter", "https://example.com/butter.jpg", "Butter", 1.8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
