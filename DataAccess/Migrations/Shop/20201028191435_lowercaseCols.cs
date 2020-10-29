using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations.Shop
{
    public partial class lowercaseCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cart_ıtem_carts_cart_ıd",
                table: "cart_ıtem");

            migrationBuilder.DropForeignKey(
                name: "fk_cart_ıtem_products_product_ıd",
                table: "cart_ıtem");

            migrationBuilder.DropForeignKey(
                name: "fk_comment_products_product_ıd",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "fk_favorites_products_product_ıd",
                table: "favorites");

            migrationBuilder.DropForeignKey(
                name: "fk_order_ıtem_orders_order_ıd",
                table: "order_ıtem");

            migrationBuilder.DropForeignKey(
                name: "fk_product_ımage_products_product_ıd",
                table: "product_ımage");

            migrationBuilder.DropForeignKey(
                name: "fk_product_specification_products_product_ıd",
                table: "product_specification");

            migrationBuilder.DropForeignKey(
                name: "fk_product_specification_specifications_specification_ıd",
                table: "product_specification");

            migrationBuilder.DropForeignKey(
                name: "fk_products_categories_category_ıd",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "pk_product_specification",
                table: "product_specification");

            migrationBuilder.DropPrimaryKey(
                name: "pk_product_ımage",
                table: "product_ımage");

            migrationBuilder.DropPrimaryKey(
                name: "pk_order_ıtem",
                table: "order_ıtem");

            migrationBuilder.DropPrimaryKey(
                name: "pk_email_list",
                table: "email_list");

            migrationBuilder.DropPrimaryKey(
                name: "pk_cart_ıtem",
                table: "cart_ıtem");

            migrationBuilder.RenameTable(
                name: "product_specification",
                newName: "productspecification");

            migrationBuilder.RenameTable(
                name: "product_ımage",
                newName: "productimage");

            migrationBuilder.RenameTable(
                name: "order_ıtem",
                newName: "orderitem");

            migrationBuilder.RenameTable(
                name: "email_list",
                newName: "emaillist");

            migrationBuilder.RenameTable(
                name: "cart_ıtem",
                newName: "cartitem");

            migrationBuilder.RenameColumn(
                name: "specification_value",
                table: "specifications",
                newName: "specificationvalue");

            migrationBuilder.RenameColumn(
                name: "specification_name",
                table: "specifications",
                newName: "specificationname");

            migrationBuilder.RenameColumn(
                name: "ıd",
                table: "specifications",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "products",
                newName: "productname");

            migrationBuilder.RenameColumn(
                name: "product_description",
                table: "products",
                newName: "productdescription");

            migrationBuilder.RenameColumn(
                name: "order_count",
                table: "products",
                newName: "ordercount");

            migrationBuilder.RenameColumn(
                name: "old_price",
                table: "products",
                newName: "oldprice");

            migrationBuilder.RenameColumn(
                name: "new_price",
                table: "products",
                newName: "newprice");

            migrationBuilder.RenameColumn(
                name: "date_added",
                table: "products",
                newName: "dateadded");

            migrationBuilder.RenameColumn(
                name: "category_ıd",
                table: "products",
                newName: "categoryid");

            migrationBuilder.RenameColumn(
                name: "ıd",
                table: "products",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "ıx_products_category_ıd",
                table: "products",
                newName: "ix_products_categoryid");

            migrationBuilder.RenameColumn(
                name: "user_ıd",
                table: "orders",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "total_price",
                table: "orders",
                newName: "totalprice");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "orders",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "order_date",
                table: "orders",
                newName: "orderdate");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "orders",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "address_header",
                table: "orders",
                newName: "addressheader");

            migrationBuilder.RenameColumn(
                name: "address_description",
                table: "orders",
                newName: "addressdescription");

            migrationBuilder.RenameColumn(
                name: "ıd",
                table: "orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "feedback_text",
                table: "feedbacks",
                newName: "feedbacktext");

            migrationBuilder.RenameColumn(
                name: "ıd",
                table: "feedbacks",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "user_ıd",
                table: "favorites",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "product_ıd",
                table: "favorites",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "ıd",
                table: "favorites",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "ıx_favorites_product_ıd",
                table: "favorites",
                newName: "ix_favorites_productid");

            migrationBuilder.RenameColumn(
                name: "user_ıd",
                table: "comment",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "product_ıd",
                table: "comment",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "comment_text",
                table: "comment",
                newName: "commenttext");

            migrationBuilder.RenameColumn(
                name: "ıd",
                table: "comment",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "ıx_comment_product_ıd",
                table: "comment",
                newName: "ix_comment_productid");

            migrationBuilder.RenameColumn(
                name: "category_name",
                table: "categories",
                newName: "categoryname");

            migrationBuilder.RenameColumn(
                name: "ıd",
                table: "categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "user_ıd",
                table: "carts",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "ıd",
                table: "carts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "specification_ıd",
                table: "productspecification",
                newName: "specificationid");

            migrationBuilder.RenameColumn(
                name: "product_ıd",
                table: "productspecification",
                newName: "productid");

            migrationBuilder.RenameIndex(
                name: "ıx_product_specification_specification_ıd",
                table: "productspecification",
                newName: "ix_productspecification_specificationid");

            migrationBuilder.RenameColumn(
                name: "product_ıd",
                table: "productimage",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "ımage_url",
                table: "productimage",
                newName: "imageurl");

            migrationBuilder.RenameColumn(
                name: "file_name",
                table: "productimage",
                newName: "filename");

            migrationBuilder.RenameColumn(
                name: "ıd",
                table: "productimage",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "ıx_product_ımage_product_ıd",
                table: "productimage",
                newName: "ix_productimage_productid");

            migrationBuilder.RenameColumn(
                name: "product_quantity",
                table: "orderitem",
                newName: "productquantity");

            migrationBuilder.RenameColumn(
                name: "product_price",
                table: "orderitem",
                newName: "productprice");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "orderitem",
                newName: "productname");

            migrationBuilder.RenameColumn(
                name: "order_ıd",
                table: "orderitem",
                newName: "orderid");

            migrationBuilder.RenameColumn(
                name: "ıd",
                table: "orderitem",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "ıx_order_ıtem_order_ıd",
                table: "orderitem",
                newName: "ix_orderitem_orderid");

            migrationBuilder.RenameColumn(
                name: "product_quantity",
                table: "cartitem",
                newName: "productquantity");

            migrationBuilder.RenameColumn(
                name: "product_ıd",
                table: "cartitem",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "cart_ıd",
                table: "cartitem",
                newName: "cartid");

            migrationBuilder.RenameColumn(
                name: "ıd",
                table: "cartitem",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "ıx_cart_ıtem_product_ıd",
                table: "cartitem",
                newName: "ix_cartitem_productid");

            migrationBuilder.RenameIndex(
                name: "ıx_cart_ıtem_cart_ıd",
                table: "cartitem",
                newName: "ix_cartitem_cartid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_productspecification",
                table: "productspecification",
                columns: new[] { "productid", "specificationid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_productimage",
                table: "productimage",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_orderitem",
                table: "orderitem",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_emaillist",
                table: "emaillist",
                column: "email");

            migrationBuilder.AddPrimaryKey(
                name: "pk_cartitem",
                table: "cartitem",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_cartitem_carts_cartid",
                table: "cartitem",
                column: "cartid",
                principalTable: "carts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_cartitem_products_productid",
                table: "cartitem",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_comment_products_productid",
                table: "comment",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_favorites_products_productid",
                table: "favorites",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orderitem_orders_orderid",
                table: "orderitem",
                column: "orderid",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_productimage_products_productid",
                table: "productimage",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_products_categories_categoryid",
                table: "products",
                column: "categoryid",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_productspecification_products_productid",
                table: "productspecification",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_productspecification_specifications_specificationid",
                table: "productspecification",
                column: "specificationid",
                principalTable: "specifications",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cartitem_carts_cartid",
                table: "cartitem");

            migrationBuilder.DropForeignKey(
                name: "fk_cartitem_products_productid",
                table: "cartitem");

            migrationBuilder.DropForeignKey(
                name: "fk_comment_products_productid",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "fk_favorites_products_productid",
                table: "favorites");

            migrationBuilder.DropForeignKey(
                name: "fk_orderitem_orders_orderid",
                table: "orderitem");

            migrationBuilder.DropForeignKey(
                name: "fk_productimage_products_productid",
                table: "productimage");

            migrationBuilder.DropForeignKey(
                name: "fk_products_categories_categoryid",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "fk_productspecification_products_productid",
                table: "productspecification");

            migrationBuilder.DropForeignKey(
                name: "fk_productspecification_specifications_specificationid",
                table: "productspecification");

            migrationBuilder.DropPrimaryKey(
                name: "pk_productspecification",
                table: "productspecification");

            migrationBuilder.DropPrimaryKey(
                name: "pk_productimage",
                table: "productimage");

            migrationBuilder.DropPrimaryKey(
                name: "pk_orderitem",
                table: "orderitem");

            migrationBuilder.DropPrimaryKey(
                name: "pk_emaillist",
                table: "emaillist");

            migrationBuilder.DropPrimaryKey(
                name: "pk_cartitem",
                table: "cartitem");

            migrationBuilder.RenameTable(
                name: "productspecification",
                newName: "product_specification");

            migrationBuilder.RenameTable(
                name: "productimage",
                newName: "product_ımage");

            migrationBuilder.RenameTable(
                name: "orderitem",
                newName: "order_ıtem");

            migrationBuilder.RenameTable(
                name: "emaillist",
                newName: "email_list");

            migrationBuilder.RenameTable(
                name: "cartitem",
                newName: "cart_ıtem");

            migrationBuilder.RenameColumn(
                name: "specificationvalue",
                table: "specifications",
                newName: "specification_value");

            migrationBuilder.RenameColumn(
                name: "specificationname",
                table: "specifications",
                newName: "specification_name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "specifications",
                newName: "ıd");

            migrationBuilder.RenameColumn(
                name: "productname",
                table: "products",
                newName: "product_name");

            migrationBuilder.RenameColumn(
                name: "productdescription",
                table: "products",
                newName: "product_description");

            migrationBuilder.RenameColumn(
                name: "ordercount",
                table: "products",
                newName: "order_count");

            migrationBuilder.RenameColumn(
                name: "oldprice",
                table: "products",
                newName: "old_price");

            migrationBuilder.RenameColumn(
                name: "newprice",
                table: "products",
                newName: "new_price");

            migrationBuilder.RenameColumn(
                name: "dateadded",
                table: "products",
                newName: "date_added");

            migrationBuilder.RenameColumn(
                name: "categoryid",
                table: "products",
                newName: "category_ıd");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "products",
                newName: "ıd");

            migrationBuilder.RenameIndex(
                name: "ix_products_categoryid",
                table: "products",
                newName: "ıx_products_category_ıd");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "orders",
                newName: "user_ıd");

            migrationBuilder.RenameColumn(
                name: "totalprice",
                table: "orders",
                newName: "total_price");

            migrationBuilder.RenameColumn(
                name: "phonenumber",
                table: "orders",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "orderdate",
                table: "orders",
                newName: "order_date");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "orders",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "addressheader",
                table: "orders",
                newName: "address_header");

            migrationBuilder.RenameColumn(
                name: "addressdescription",
                table: "orders",
                newName: "address_description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "orders",
                newName: "ıd");

            migrationBuilder.RenameColumn(
                name: "feedbacktext",
                table: "feedbacks",
                newName: "feedback_text");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "feedbacks",
                newName: "ıd");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "favorites",
                newName: "user_ıd");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "favorites",
                newName: "product_ıd");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "favorites",
                newName: "ıd");

            migrationBuilder.RenameIndex(
                name: "ix_favorites_productid",
                table: "favorites",
                newName: "ıx_favorites_product_ıd");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "comment",
                newName: "user_ıd");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "comment",
                newName: "product_ıd");

            migrationBuilder.RenameColumn(
                name: "commenttext",
                table: "comment",
                newName: "comment_text");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "comment",
                newName: "ıd");

            migrationBuilder.RenameIndex(
                name: "ix_comment_productid",
                table: "comment",
                newName: "ıx_comment_product_ıd");

            migrationBuilder.RenameColumn(
                name: "categoryname",
                table: "categories",
                newName: "category_name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "categories",
                newName: "ıd");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "carts",
                newName: "user_ıd");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "carts",
                newName: "ıd");

            migrationBuilder.RenameColumn(
                name: "specificationid",
                table: "product_specification",
                newName: "specification_ıd");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "product_specification",
                newName: "product_ıd");

            migrationBuilder.RenameIndex(
                name: "ix_productspecification_specificationid",
                table: "product_specification",
                newName: "ıx_product_specification_specification_ıd");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "product_ımage",
                newName: "product_ıd");

            migrationBuilder.RenameColumn(
                name: "imageurl",
                table: "product_ımage",
                newName: "ımage_url");

            migrationBuilder.RenameColumn(
                name: "filename",
                table: "product_ımage",
                newName: "file_name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "product_ımage",
                newName: "ıd");

            migrationBuilder.RenameIndex(
                name: "ix_productimage_productid",
                table: "product_ımage",
                newName: "ıx_product_ımage_product_ıd");

            migrationBuilder.RenameColumn(
                name: "productquantity",
                table: "order_ıtem",
                newName: "product_quantity");

            migrationBuilder.RenameColumn(
                name: "productprice",
                table: "order_ıtem",
                newName: "product_price");

            migrationBuilder.RenameColumn(
                name: "productname",
                table: "order_ıtem",
                newName: "product_name");

            migrationBuilder.RenameColumn(
                name: "orderid",
                table: "order_ıtem",
                newName: "order_ıd");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "order_ıtem",
                newName: "ıd");

            migrationBuilder.RenameIndex(
                name: "ix_orderitem_orderid",
                table: "order_ıtem",
                newName: "ıx_order_ıtem_order_ıd");

            migrationBuilder.RenameColumn(
                name: "productquantity",
                table: "cart_ıtem",
                newName: "product_quantity");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "cart_ıtem",
                newName: "product_ıd");

            migrationBuilder.RenameColumn(
                name: "cartid",
                table: "cart_ıtem",
                newName: "cart_ıd");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "cart_ıtem",
                newName: "ıd");

            migrationBuilder.RenameIndex(
                name: "ix_cartitem_productid",
                table: "cart_ıtem",
                newName: "ıx_cart_ıtem_product_ıd");

            migrationBuilder.RenameIndex(
                name: "ix_cartitem_cartid",
                table: "cart_ıtem",
                newName: "ıx_cart_ıtem_cart_ıd");

            migrationBuilder.AddPrimaryKey(
                name: "pk_product_specification",
                table: "product_specification",
                columns: new[] { "product_ıd", "specification_ıd" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_product_ımage",
                table: "product_ımage",
                column: "ıd");

            migrationBuilder.AddPrimaryKey(
                name: "pk_order_ıtem",
                table: "order_ıtem",
                column: "ıd");

            migrationBuilder.AddPrimaryKey(
                name: "pk_email_list",
                table: "email_list",
                column: "email");

            migrationBuilder.AddPrimaryKey(
                name: "pk_cart_ıtem",
                table: "cart_ıtem",
                column: "ıd");

            migrationBuilder.AddForeignKey(
                name: "fk_cart_ıtem_carts_cart_ıd",
                table: "cart_ıtem",
                column: "cart_ıd",
                principalTable: "carts",
                principalColumn: "ıd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_cart_ıtem_products_product_ıd",
                table: "cart_ıtem",
                column: "product_ıd",
                principalTable: "products",
                principalColumn: "ıd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_comment_products_product_ıd",
                table: "comment",
                column: "product_ıd",
                principalTable: "products",
                principalColumn: "ıd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_favorites_products_product_ıd",
                table: "favorites",
                column: "product_ıd",
                principalTable: "products",
                principalColumn: "ıd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_order_ıtem_orders_order_ıd",
                table: "order_ıtem",
                column: "order_ıd",
                principalTable: "orders",
                principalColumn: "ıd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_ımage_products_product_ıd",
                table: "product_ımage",
                column: "product_ıd",
                principalTable: "products",
                principalColumn: "ıd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_specification_products_product_ıd",
                table: "product_specification",
                column: "product_ıd",
                principalTable: "products",
                principalColumn: "ıd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_product_specification_specifications_specification_ıd",
                table: "product_specification",
                column: "specification_ıd",
                principalTable: "specifications",
                principalColumn: "ıd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_products_categories_category_ıd",
                table: "products",
                column: "category_ıd",
                principalTable: "categories",
                principalColumn: "ıd",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
