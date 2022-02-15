using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GigaWorkshop.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Inventory");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category",
                        column: x => x.ParentCategoryId,
                        principalSchema: "Inventory",
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SKU = table.Column<string>(type: "varchar(10)", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Product",
                        column: x => x.CategoryId,
                        principalSchema: "Inventory",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "varchar(200)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FK_Product_Image = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Product_FK_Product_Image",
                        column: x => x.FK_Product_Image,
                        principalSchema: "Inventory",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    LastQuantity = table.Column<float>(type: "real", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    FK_Product_Stock = table.Column<int>(type: "int", nullable: false),
                    FK_Product_Warehouse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Product_FK_Product_Stock",
                        column: x => x.FK_Product_Stock,
                        principalSchema: "Inventory",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Warehouse_FK_Product_Warehouse",
                        column: x => x.FK_Product_Warehouse,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Inventory",
                table: "Category",
                columns: new[] { "Id", "IsActive", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, true, "Category One", null },
                    { 2, true, "Category Two", null },
                    { 3, true, "Category Three", null }
                });

            migrationBuilder.InsertData(
                schema: "Inventory",
                table: "Warehouse",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Warehouse North One" },
                    { 2, true, "Warehouse East" },
                    { 3, true, "Warehouse West" }
                });

            migrationBuilder.InsertData(
                schema: "Inventory",
                table: "Category",
                columns: new[] { "Id", "IsActive", "Name", "ParentCategoryId" },
                values: new object[] { 4, true, "Category Four", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                schema: "Inventory",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_FK_Product_Image",
                schema: "Inventory",
                table: "Image",
                column: "FK_Product_Image");

            migrationBuilder.CreateIndex(
                name: "IDX_Name_Description",
                schema: "Inventory",
                table: "Product",
                columns: new[] { "SKU", "Name", "Description" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "Inventory",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_FK_Product_Stock",
                schema: "Inventory",
                table: "Stock",
                column: "FK_Product_Stock");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_FK_Product_Warehouse",
                schema: "Inventory",
                table: "Stock",
                column: "FK_Product_Warehouse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Stock",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Warehouse",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Inventory");
        }
    }
}
