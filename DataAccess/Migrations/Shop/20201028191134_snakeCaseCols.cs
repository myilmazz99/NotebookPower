using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccess.Migrations.Shop
{
    public partial class snakeCaseCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    ıd = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_ıd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_carts", x => x.ıd);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    ıd = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.ıd);
                });

            migrationBuilder.CreateTable(
                name: "email_list",
                columns: table => new
                {
                    email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_email_list", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    ıd = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(nullable: true),
                    feedback_text = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_feedbacks", x => x.ıd);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    ıd = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<int>(nullable: false),
                    order_date = table.Column<DateTime>(nullable: false),
                    total_price = table.Column<double>(nullable: false),
                    user_ıd = table.Column<string>(nullable: true),
                    full_name = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    address_header = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    address_description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.ıd);
                });

            migrationBuilder.CreateTable(
                name: "specifications",
                columns: table => new
                {
                    ıd = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    specification_name = table.Column<string>(nullable: true),
                    specification_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_specifications", x => x.ıd);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ıd = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_name = table.Column<string>(nullable: true),
                    product_description = table.Column<string>(nullable: true),
                    stock = table.Column<int>(nullable: false),
                    old_price = table.Column<double>(nullable: false),
                    new_price = table.Column<double>(nullable: false),
                    order_count = table.Column<int>(nullable: false),
                    date_added = table.Column<DateTime>(nullable: false),
                    category_ıd = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.ıd);
                    table.ForeignKey(
                        name: "fk_products_categories_category_ıd",
                        column: x => x.category_ıd,
                        principalTable: "categories",
                        principalColumn: "ıd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_ıtem",
                columns: table => new
                {
                    ıd = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_name = table.Column<string>(nullable: true),
                    product_price = table.Column<double>(nullable: false),
                    product_quantity = table.Column<int>(nullable: false),
                    order_ıd = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_ıtem", x => x.ıd);
                    table.ForeignKey(
                        name: "fk_order_ıtem_orders_order_ıd",
                        column: x => x.order_ıd,
                        principalTable: "orders",
                        principalColumn: "ıd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cart_ıtem",
                columns: table => new
                {
                    ıd = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_quantity = table.Column<int>(nullable: false),
                    product_ıd = table.Column<int>(nullable: false),
                    cart_ıd = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cart_ıtem", x => x.ıd);
                    table.ForeignKey(
                        name: "fk_cart_ıtem_carts_cart_ıd",
                        column: x => x.cart_ıd,
                        principalTable: "carts",
                        principalColumn: "ıd",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cart_ıtem_products_product_ıd",
                        column: x => x.product_ıd,
                        principalTable: "products",
                        principalColumn: "ıd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    ıd = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comment_text = table.Column<string>(nullable: true),
                    rating = table.Column<byte>(nullable: false),
                    user_ıd = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    product_ıd = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comment", x => x.ıd);
                    table.ForeignKey(
                        name: "fk_comment_products_product_ıd",
                        column: x => x.product_ıd,
                        principalTable: "products",
                        principalColumn: "ıd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "favorites",
                columns: table => new
                {
                    ıd = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_ıd = table.Column<int>(nullable: false),
                    user_ıd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_favorites", x => x.ıd);
                    table.ForeignKey(
                        name: "fk_favorites_products_product_ıd",
                        column: x => x.product_ıd,
                        principalTable: "products",
                        principalColumn: "ıd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_ımage",
                columns: table => new
                {
                    ıd = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ımage_url = table.Column<string>(nullable: true),
                    file_name = table.Column<string>(nullable: true),
                    product_ıd = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_ımage", x => x.ıd);
                    table.ForeignKey(
                        name: "fk_product_ımage_products_product_ıd",
                        column: x => x.product_ıd,
                        principalTable: "products",
                        principalColumn: "ıd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_specification",
                columns: table => new
                {
                    product_ıd = table.Column<int>(nullable: false),
                    specification_ıd = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_specification", x => new { x.product_ıd, x.specification_ıd });
                    table.ForeignKey(
                        name: "fk_product_specification_products_product_ıd",
                        column: x => x.product_ıd,
                        principalTable: "products",
                        principalColumn: "ıd",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_product_specification_specifications_specification_ıd",
                        column: x => x.specification_ıd,
                        principalTable: "specifications",
                        principalColumn: "ıd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ıx_cart_ıtem_cart_ıd",
                table: "cart_ıtem",
                column: "cart_ıd");

            migrationBuilder.CreateIndex(
                name: "ıx_cart_ıtem_product_ıd",
                table: "cart_ıtem",
                column: "product_ıd");

            migrationBuilder.CreateIndex(
                name: "ıx_comment_product_ıd",
                table: "comment",
                column: "product_ıd");

            migrationBuilder.CreateIndex(
                name: "ıx_favorites_product_ıd",
                table: "favorites",
                column: "product_ıd");

            migrationBuilder.CreateIndex(
                name: "ıx_order_ıtem_order_ıd",
                table: "order_ıtem",
                column: "order_ıd");

            migrationBuilder.CreateIndex(
                name: "ıx_product_ımage_product_ıd",
                table: "product_ımage",
                column: "product_ıd");

            migrationBuilder.CreateIndex(
                name: "ıx_product_specification_specification_ıd",
                table: "product_specification",
                column: "specification_ıd");

            migrationBuilder.CreateIndex(
                name: "ıx_products_category_ıd",
                table: "products",
                column: "category_ıd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cart_ıtem");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "email_list");

            migrationBuilder.DropTable(
                name: "favorites");

            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DropTable(
                name: "order_ıtem");

            migrationBuilder.DropTable(
                name: "product_ımage");

            migrationBuilder.DropTable(
                name: "product_specification");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "specifications");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
