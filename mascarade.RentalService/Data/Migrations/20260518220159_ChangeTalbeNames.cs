using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mascarade.RentalService.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTalbeNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Costumes_CostumeId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Customers_CustomerId",
                table: "Rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Costumes",
                table: "Costumes");

            migrationBuilder.RenameTable(
                name: "Rentals",
                newName: "rentals");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "customers");

            migrationBuilder.RenameTable(
                name: "Costumes",
                newName: "costumes");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "rentals",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "rentals",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "rentals",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "rentals",
                newName: "total_price");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "rentals",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "rentals",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "rentals",
                newName: "customer_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "rentals",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CostumeId",
                table: "rentals",
                newName: "costume_id");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_CustomerId",
                table: "rentals",
                newName: "ix_rentals_customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_CostumeId",
                table: "rentals",
                newName: "ix_rentals_costume_id");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "customers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "customers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "customers",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "customers",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "customers",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "customers",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "costumes",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "costumes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "costumes",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "costumes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "costumes",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "RentalPriceDay",
                table: "costumes",
                newName: "rental_price_day");

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "costumes",
                newName: "is_available");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "costumes",
                newName: "image_url");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "costumes",
                newName: "created_at");

            migrationBuilder.AddPrimaryKey(
                name: "pk_rentals",
                table: "rentals",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_customers",
                table: "customers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_costumes",
                table: "costumes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_rentals_costumes_costume_id",
                table: "rentals",
                column: "costume_id",
                principalTable: "costumes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_rentals_customers_customer_id",
                table: "rentals",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_rentals_costumes_costume_id",
                table: "rentals");

            migrationBuilder.DropForeignKey(
                name: "fk_rentals_customers_customer_id",
                table: "rentals");

            migrationBuilder.DropPrimaryKey(
                name: "pk_rentals",
                table: "rentals");

            migrationBuilder.DropPrimaryKey(
                name: "pk_customers",
                table: "customers");

            migrationBuilder.DropPrimaryKey(
                name: "pk_costumes",
                table: "costumes");

            migrationBuilder.RenameTable(
                name: "rentals",
                newName: "Rentals");

            migrationBuilder.RenameTable(
                name: "customers",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "costumes",
                newName: "Costumes");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Rentals",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Rentals",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Rentals",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "total_price",
                table: "Rentals",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "Rentals",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "Rentals",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "Rentals",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Rentals",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "costume_id",
                table: "Rentals",
                newName: "CostumeId");

            migrationBuilder.RenameIndex(
                name: "ix_rentals_customer_id",
                table: "Rentals",
                newName: "IX_Rentals_CustomerId");

            migrationBuilder.RenameIndex(
                name: "ix_rentals_costume_id",
                table: "Rentals",
                newName: "IX_Rentals_CostumeId");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Customers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Customers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Customers",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Customers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "Customers",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Customers",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "size",
                table: "Costumes",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Costumes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Costumes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Costumes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Costumes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "rental_price_day",
                table: "Costumes",
                newName: "RentalPriceDay");

            migrationBuilder.RenameColumn(
                name: "is_available",
                table: "Costumes",
                newName: "IsAvailable");

            migrationBuilder.RenameColumn(
                name: "image_url",
                table: "Costumes",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Costumes",
                newName: "CreatedAt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Costumes",
                table: "Costumes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Costumes_CostumeId",
                table: "Rentals",
                column: "CostumeId",
                principalTable: "Costumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Customers_CustomerId",
                table: "Rentals",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
