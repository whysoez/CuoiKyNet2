using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoUniversity.Migrations
{
    public partial class _1806Chuyenphatnhanh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChuyenPhatNhanh",
                columns: table => new
                {
                    ChuyenPhatNhanhID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguoiGui = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SdtNguoiGui = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SdtNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TienCuoc = table.Column<int>(type: "int", nullable: true),
                    TinhTrang = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenPhatNhanh", x => x.ChuyenPhatNhanhID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChuyenPhatNhanh");
        }
    }
}
