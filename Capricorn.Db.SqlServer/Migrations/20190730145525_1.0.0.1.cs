using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capricorn.Db.SqlServer.Migrations
{
    public partial class _1001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BASE_COMPANY",
                columns: table => new
                {
                    F_COMPANYID = table.Column<string>(maxLength: 12, nullable: false),
                    F_ENCODE = table.Column<string>(type: "varchar(200)", maxLength: 12, nullable: false),
                    F_CATEGORY = table.Column<int>(nullable: true),
                    F_PARENTID = table.Column<string>(nullable: true),
                    F_SHORTNAME = table.Column<string>(nullable: true),
                    F_FULLNAME = table.Column<string>(nullable: true),
                    F_NATURE = table.Column<string>(nullable: true),
                    F_OUTERPHONE = table.Column<string>(nullable: true),
                    F_INNERPHONE = table.Column<string>(nullable: true),
                    F_FAX = table.Column<string>(nullable: true),
                    F_POSTALCODE = table.Column<string>(nullable: true),
                    F_EMAIL = table.Column<string>(nullable: true),
                    F_MANAGER = table.Column<string>(nullable: true),
                    F_PROVINCEID = table.Column<string>(nullable: true),
                    F_CITYID = table.Column<string>(nullable: true),
                    F_COUNTYID = table.Column<string>(nullable: true),
                    F_ADDRESS = table.Column<string>(nullable: true),
                    F_WEBADDRESS = table.Column<string>(nullable: true),
                    F_FOUNDEDTIME = table.Column<DateTime>(nullable: true),
                    F_BUSINESSSCOPE = table.Column<string>(nullable: true),
                    F_SORTCODE = table.Column<int>(nullable: true),
                    F_DELETEMARK = table.Column<int>(nullable: true),
                    F_ENABLEDMARK = table.Column<int>(nullable: true),
                    F_DESCRIPTION = table.Column<string>(nullable: true),
                    F_CREATEDATE = table.Column<DateTime>(nullable: true),
                    F_CREATEUSERID = table.Column<string>(nullable: true),
                    F_CREATEUSERNAME = table.Column<string>(nullable: true),
                    F_MODIFYDATE = table.Column<DateTime>(nullable: true),
                    F_MODIFYUSERID = table.Column<string>(nullable: true),
                    F_MODIFYUSERNAME = table.Column<string>(nullable: true),
                    F_SYSMANAGER = table.Column<string>(nullable: true),
                    F_SYSMANAGERTEL = table.Column<string>(nullable: true),
                    F_LEADER = table.Column<string>(nullable: true),
                    F_LEADERNAME = table.Column<string>(nullable: true),
                    F_MANAGERDEPART = table.Column<string>(nullable: true),
                    F_MANAGERDEPARTNAME = table.Column<string>(nullable: true),
                    F_MANAGERNAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASE_COMPANY", x => x.F_COMPANYID);
                });

            migrationBuilder.CreateTable(
                name: "BASE_USER",
                columns: table => new
                {
                    F_USERID = table.Column<string>(nullable: false),
                    F_ENCODE = table.Column<string>(nullable: true),
                    F_ACCOUNT = table.Column<string>(nullable: true),
                    F_PASSWORD = table.Column<string>(nullable: true),
                    F_SECRETKEY = table.Column<string>(nullable: true),
                    F_REALNAME = table.Column<string>(nullable: true),
                    F_NICKNAME = table.Column<string>(nullable: true),
                    F_HEADICON = table.Column<string>(nullable: true),
                    F_QUICKQUERY = table.Column<string>(nullable: true),
                    F_SIMPLESPELLING = table.Column<string>(nullable: true),
                    F_GENDER = table.Column<int>(nullable: true),
                    F_BIRTHDAY = table.Column<DateTime>(nullable: true),
                    F_MOBILE = table.Column<string>(nullable: true),
                    F_TELEPHONE = table.Column<string>(nullable: true),
                    F_EMAIL = table.Column<string>(nullable: true),
                    F_OICQ = table.Column<string>(nullable: true),
                    F_WECHAT = table.Column<string>(nullable: true),
                    F_MSN = table.Column<string>(nullable: true),
                    F_COMPANYID = table.Column<string>(nullable: true),
                    F_DEPARTMENTID = table.Column<string>(nullable: true),
                    F_SECURITYLEVEL = table.Column<int>(nullable: true),
                    F_OPENID = table.Column<int>(nullable: true),
                    F_QUESTION = table.Column<string>(nullable: true),
                    F_ANSWERQUESTION = table.Column<string>(nullable: true),
                    F_CHECKONLINE = table.Column<int>(nullable: true),
                    F_ALLOWSTARTTIME = table.Column<DateTime>(nullable: true),
                    F_ALLOWENDTIME = table.Column<DateTime>(nullable: true),
                    F_LOCKSTARTDATE = table.Column<DateTime>(nullable: true),
                    F_LOCKENDDATE = table.Column<DateTime>(nullable: true),
                    F_SORTCODE = table.Column<int>(nullable: true),
                    F_DELETEMARK = table.Column<int>(nullable: true),
                    F_ENABLEDMARK = table.Column<int>(nullable: true),
                    F_DESCRIPTION = table.Column<string>(nullable: true),
                    F_CREATEDATE = table.Column<DateTime>(nullable: true),
                    F_CREATEUSERID = table.Column<string>(nullable: true),
                    F_CREATEUSERNAME = table.Column<string>(nullable: true),
                    F_MODIFYDATE = table.Column<DateTime>(nullable: true),
                    F_MODIFYUSERID = table.Column<string>(nullable: true),
                    F_MODIFYUSERNAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASE_USER", x => x.F_USERID);
                });

            migrationBuilder.CreateTable(
                name: "BASE_DEPARTMENT",
                columns: table => new
                {
                    F_DEPARTMENTID = table.Column<string>(nullable: false),
                    F_COMPANYID = table.Column<string>(nullable: true),
                    F_PARENTID = table.Column<string>(nullable: true),
                    F_ENCODE = table.Column<string>(nullable: true),
                    F_FULLNAME = table.Column<string>(nullable: true),
                    F_SHORTNAME = table.Column<string>(nullable: true),
                    F_NATURE = table.Column<string>(nullable: true),
                    F_MANAGER = table.Column<string>(nullable: true),
                    F_OUTERPHONE = table.Column<string>(nullable: true),
                    F_INNERPHONE = table.Column<string>(nullable: true),
                    F_EMAIL = table.Column<string>(nullable: true),
                    F_FAX = table.Column<string>(nullable: true),
                    F_SORTCODE = table.Column<int>(nullable: true),
                    F_DELETEMARK = table.Column<int>(nullable: true),
                    F_ENABLEDMARK = table.Column<int>(nullable: true),
                    F_DESCRIPTION = table.Column<string>(nullable: true),
                    F_CREATEDATE = table.Column<DateTime>(nullable: true),
                    F_CREATEUSERID = table.Column<string>(nullable: true),
                    F_CREATEUSERNAME = table.Column<string>(nullable: true),
                    F_MODIFYDATE = table.Column<DateTime>(nullable: true),
                    F_MODIFYUSERID = table.Column<string>(nullable: true),
                    F_MODIFYUSERNAME = table.Column<string>(nullable: true),
                    F_MANAGERDEPART = table.Column<string>(nullable: true),
                    F_MANAGERNAME = table.Column<string>(nullable: true),
                    F_MANAGERDEPARTNAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASE_DEPARTMENT", x => x.F_DEPARTMENTID);
                    table.ForeignKey(
                        name: "FK_BASE_DEPARTMENT_BASE_COMPANY_F_COMPANYID",
                        column: x => x.F_COMPANYID,
                        principalTable: "BASE_COMPANY",
                        principalColumn: "F_COMPANYID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BASE_DEPARTMENT_F_COMPANYID",
                table: "BASE_DEPARTMENT",
                column: "F_COMPANYID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BASE_DEPARTMENT");

            migrationBuilder.DropTable(
                name: "BASE_USER");

            migrationBuilder.DropTable(
                name: "BASE_COMPANY");
        }
    }
}
