using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ligjerata_7___xhelali2.Data.Migrations
{
    public partial class imageadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Mesuesi",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Mesuesi");
        }
    }
}
