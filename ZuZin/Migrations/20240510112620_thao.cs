using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZuZin.Migrations
{
    /// <inheritdoc />
    public partial class thao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsTrendingProduct = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Email", "Message", "Name" },
                values: new object[,]
                {
                    { 1, "Thuyen2003@gmail.com", "Cà phê đen rất ngon nhá Shop", "Đinh Thuyền" },
                    { 2, "Quyen2004@gmail.com", "MoCha thật sự rất tuyệt, cảm ơn Shop", "Phan Thị Thúy Quyên" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Description", "Image", "IsTrendingProduct", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Đây là loại cà phê có hương vị mạnh mẽ, đậm đà và thơm nồng.", "data:image/png;base64,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", false, "Espresso", 25m },
                    { 2, "Hương vị của Americano thường nhẹ nhàng hơn so với espresso đơn thuần, nhưng vẫn giữ được một phần của độ đậm và đắng của espresso.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZyQXS7p7D7joovsULkr-NbhfQIlvg94EQWA&usqp=CAU", false, "Americano", 20m },
                    { 3, "Vị của Latte thường mềm mại, cân bằng giữa hương vị của espresso và sữa, có thể được tùy chỉnh theo sở thích cá nhân", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQAgQgtpjfcUCe9LG3w9qdTxmHGbuldlEKm4Q&usqp=CAU", false, "Latte", 15m },
                    { 4, "Cappuccino có lớp bọt sữa đặc đặc trên cùng, tạo ra một hương vị cân bằng giữa đắng của espresso và độ ngọt của sữa.", "data:image/jpeg;base64,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", false, "Cappuccino", 15m },
                    { 5, "Với hương vị ngọt ngào và thơm của sô-cô-la, Mocha thường được coi là một loại cà phê đáng ngưỡng mộ cho những người yêu thích hương vị đắng ngọt.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQwjx5QNdVZ99iTvlU4dcMHeFsBqizbhuNDg&usqp=CAU", false, "Cà phê Mocha", 25m },
                    { 6, "Với hương vị đậm đà và đắng, cà phê đen thường được ưa chuộng bởi những người thích hương vị chính của cà phê.", "data:image/jpeg;base64,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", false, "Cà phê Đen", 35m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
