using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiveLogBook.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dives",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<Guid>(nullable: false),
                    DiveLocationID = table.Column<long>(nullable: false),
                    DiveEnteredAt = table.Column<DateTime>(nullable: false),
                    Depth = table.Column<int>(nullable: false),
                    BottomTime = table.Column<int>(nullable: false),
                    DiveDateTime = table.Column<DateTime>(nullable: false),
                    WaterEntryID = table.Column<int>(nullable: false),
                    WaterTypeID = table.Column<int>(nullable: false),
                    CertificationNo = table.Column<string>(nullable: true),
                    SignatureTypeID = table.Column<int>(nullable: false),
                    VerificationSignature = table.Column<string>(nullable: true),
                    AirTemperature = table.Column<int>(nullable: true),
                    BreathingID = table.Column<int>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    EndPressureGroup = table.Column<string>(nullable: true),
                    ExposureProtectionHHFID = table.Column<string>(nullable: true),
                    ExposureProtectionID = table.Column<int>(nullable: true),
                    ExposureProtectionMM = table.Column<int>(nullable: true),
                    NewPressureGroup = table.Column<string>(nullable: true),
                    ResidualNitrogen = table.Column<int>(nullable: true),
                    SpecialtyDive = table.Column<bool>(nullable: true),
                    SpecialtyTypeID = table.Column<int>(nullable: true),
                    StartPressureGroup = table.Column<string>(nullable: true),
                    SurfaceInterval = table.Column<int>(nullable: true),
                    TankPressureEnd = table.Column<int>(nullable: true),
                    TankPressureStart = table.Column<int>(nullable: true),
                    WaterConditionID = table.Column<int>(nullable: true),
                    WaterSurfaceTemperature = table.Column<int>(nullable: true),
                    WaterBottomTemperature = table.Column<int>(nullable: true),
                    WaterVisibility = table.Column<int>(nullable: true),
                    WeatherID = table.Column<int>(nullable: true),
                    Weight = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lkps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lkps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dives");

            migrationBuilder.DropTable(
                name: "Lkps");
        }
    }
}
