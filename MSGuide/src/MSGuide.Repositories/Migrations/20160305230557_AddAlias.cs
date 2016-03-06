using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace MSGuide.Repositories.Migrations
{
    public partial class AddAlias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Article_Writer_WriterId", table: "Article");
            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Article",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Article_Writer_WriterId",
                table: "Article",
                column: "WriterId",
                principalTable: "Writer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Article_Writer_WriterId", table: "Article");
            migrationBuilder.DropColumn(name: "Alias", table: "Article");
            migrationBuilder.AddForeignKey(
                name: "FK_Article_Writer_WriterId",
                table: "Article",
                column: "WriterId",
                principalTable: "Writer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
