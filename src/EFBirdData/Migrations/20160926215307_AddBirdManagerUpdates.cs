using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFBirdData.Migrations
{
    public partial class AddBirdManagerUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Birds_PrimaryColors_PrimaryColorId",
                table: "Birds");

            migrationBuilder.DropForeignKey(
                name: "FK_Birds_SecondaryColors_SecondaryColorId",
                table: "Birds");

            migrationBuilder.AddColumn<string>(
                name: "ObserverLastName",
                table: "Sightings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SightingDate",
                table: "Sightings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Climate",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TerrainType",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConservationCode",
                table: "Birds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConservationStatus",
                table: "Birds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Family",
                table: "Birds",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Length",
                table: "Birds",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryColor",
                table: "Birds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScientificName",
                table: "Birds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryColor",
                table: "Birds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Birds",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Birds",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Width",
                table: "Birds",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "SecondaryColorId",
                table: "Birds",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PrimaryColorId",
                table: "Birds",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Birds_PrimaryColors_PrimaryColorId",
                table: "Birds",
                column: "PrimaryColorId",
                principalTable: "PrimaryColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Birds_SecondaryColors_SecondaryColorId",
                table: "Birds",
                column: "SecondaryColorId",
                principalTable: "SecondaryColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Birds_PrimaryColors_PrimaryColorId",
                table: "Birds");

            migrationBuilder.DropForeignKey(
                name: "FK_Birds_SecondaryColors_SecondaryColorId",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "ObserverLastName",
                table: "Sightings");

            migrationBuilder.DropColumn(
                name: "SightingDate",
                table: "Sightings");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Climate",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "TerrainType",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "ConservationCode",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "ConservationStatus",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "Family",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "PrimaryColor",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "ScientificName",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "SecondaryColor",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Birds");

            migrationBuilder.AlterColumn<int>(
                name: "SecondaryColorId",
                table: "Birds",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "PrimaryColorId",
                table: "Birds",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Birds_PrimaryColors_PrimaryColorId",
                table: "Birds",
                column: "PrimaryColorId",
                principalTable: "PrimaryColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Birds_SecondaryColors_SecondaryColorId",
                table: "Birds",
                column: "SecondaryColorId",
                principalTable: "SecondaryColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
