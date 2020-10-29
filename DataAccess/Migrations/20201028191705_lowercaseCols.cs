using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class lowercaseCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_role_claims_asp_net_roles_ıdentity_role_ıd",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "fk_user_claims_asp_net_users_application_user_ıd",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "fk_user_logins_asp_net_users_application_user_ıd",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "fk_user_roles_asp_net_roles_ıdentity_role_ıd",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "fk_user_roles_asp_net_users_application_user_ıd",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "fk_user_tokens_asp_net_users_application_user_ıd",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_tokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_roles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_logins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_claims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "pk_role_claims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameColumn(
                name: "login_provider",
                table: "AspNetUserTokens",
                newName: "loginprovider");

            migrationBuilder.RenameColumn(
                name: "user_ıd",
                table: "AspNetUserTokens",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "AspNetUsers",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "two_factor_enabled",
                table: "AspNetUsers",
                newName: "twofactorenabled");

            migrationBuilder.RenameColumn(
                name: "security_stamp",
                table: "AspNetUsers",
                newName: "securitystamp");

            migrationBuilder.RenameColumn(
                name: "role_name",
                table: "AspNetUsers",
                newName: "rolename");

            migrationBuilder.RenameColumn(
                name: "phone_number_confirmed",
                table: "AspNetUsers",
                newName: "phonenumberconfirmed");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "AspNetUsers",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "AspNetUsers",
                newName: "passwordhash");

            migrationBuilder.RenameColumn(
                name: "normalized_user_name",
                table: "AspNetUsers",
                newName: "normalizedusername");

            migrationBuilder.RenameColumn(
                name: "normalized_email",
                table: "AspNetUsers",
                newName: "normalizedemail");

            migrationBuilder.RenameColumn(
                name: "lockout_end",
                table: "AspNetUsers",
                newName: "lockoutend");

            migrationBuilder.RenameColumn(
                name: "lockout_enabled",
                table: "AspNetUsers",
                newName: "lockoutenabled");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "AspNetUsers",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "email_confirmed",
                table: "AspNetUsers",
                newName: "emailconfirmed");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                table: "AspNetUsers",
                newName: "concurrencystamp");

            migrationBuilder.RenameColumn(
                name: "access_failed_count",
                table: "AspNetUsers",
                newName: "accessfailedcount");

            migrationBuilder.RenameColumn(
                name: "ıd",
                table: "AspNetUsers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "role_ıd",
                table: "AspNetUserRoles",
                newName: "roleid");

            migrationBuilder.RenameColumn(
                name: "user_ıd",
                table: "AspNetUserRoles",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "ıx_user_roles_role_ıd",
                table: "AspNetUserRoles",
                newName: "ix_userroles_roleid");

            migrationBuilder.RenameColumn(
                name: "user_ıd",
                table: "AspNetUserLogins",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "provider_display_name",
                table: "AspNetUserLogins",
                newName: "providerdisplayname");

            migrationBuilder.RenameColumn(
                name: "provider_key",
                table: "AspNetUserLogins",
                newName: "providerkey");

            migrationBuilder.RenameColumn(
                name: "login_provider",
                table: "AspNetUserLogins",
                newName: "loginprovider");

            migrationBuilder.RenameIndex(
                name: "ıx_user_logins_user_ıd",
                table: "AspNetUserLogins",
                newName: "ix_userlogins_userid");

            migrationBuilder.RenameColumn(
                name: "user_ıd",
                table: "AspNetUserClaims",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "claim_value",
                table: "AspNetUserClaims",
                newName: "claimvalue");

            migrationBuilder.RenameColumn(
                name: "claim_type",
                table: "AspNetUserClaims",
                newName: "claimtype");

            migrationBuilder.RenameColumn(
                name: "ıd",
                table: "AspNetUserClaims",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "ıx_user_claims_user_ıd",
                table: "AspNetUserClaims",
                newName: "ix_userclaims_userid");

            migrationBuilder.RenameColumn(
                name: "normalized_name",
                table: "AspNetRoles",
                newName: "normalizedname");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                table: "AspNetRoles",
                newName: "concurrencystamp");

            migrationBuilder.RenameColumn(
                name: "ıd",
                table: "AspNetRoles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "role_ıd",
                table: "AspNetRoleClaims",
                newName: "roleid");

            migrationBuilder.RenameColumn(
                name: "claim_value",
                table: "AspNetRoleClaims",
                newName: "claimvalue");

            migrationBuilder.RenameColumn(
                name: "claim_type",
                table: "AspNetRoleClaims",
                newName: "claimtype");

            migrationBuilder.RenameColumn(
                name: "ıd",
                table: "AspNetRoleClaims",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "ıx_role_claims_role_ıd",
                table: "AspNetRoleClaims",
                newName: "ix_roleclaims_roleid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_usertokens",
                table: "AspNetUserTokens",
                columns: new[] { "userid", "loginprovider", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_userroles",
                table: "AspNetUserRoles",
                columns: new[] { "userid", "roleid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_userlogins",
                table: "AspNetUserLogins",
                columns: new[] { "loginprovider", "providerkey" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_userclaims",
                table: "AspNetUserClaims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_roleclaims",
                table: "AspNetRoleClaims",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_roleclaims_aspnetroles_identityroleid",
                table: "AspNetRoleClaims",
                column: "roleid",
                principalTable: "AspNetRoles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_userclaims_aspnetusers_applicationuserid",
                table: "AspNetUserClaims",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_userlogins_aspnetusers_applicationuserid",
                table: "AspNetUserLogins",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_userroles_aspnetroles_identityroleid",
                table: "AspNetUserRoles",
                column: "roleid",
                principalTable: "AspNetRoles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_userroles_aspnetusers_applicationuserid",
                table: "AspNetUserRoles",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_usertokens_aspnetusers_applicationuserid",
                table: "AspNetUserTokens",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_roleclaims_aspnetroles_identityroleid",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "fk_userclaims_aspnetusers_applicationuserid",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "fk_userlogins_aspnetusers_applicationuserid",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "fk_userroles_aspnetroles_identityroleid",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "fk_userroles_aspnetusers_applicationuserid",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "fk_usertokens_aspnetusers_applicationuserid",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_usertokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_userroles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_userlogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "pk_userclaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "pk_roleclaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameColumn(
                name: "loginprovider",
                table: "AspNetUserTokens",
                newName: "login_provider");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "AspNetUserTokens",
                newName: "user_ıd");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "AspNetUsers",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "twofactorenabled",
                table: "AspNetUsers",
                newName: "two_factor_enabled");

            migrationBuilder.RenameColumn(
                name: "securitystamp",
                table: "AspNetUsers",
                newName: "security_stamp");

            migrationBuilder.RenameColumn(
                name: "rolename",
                table: "AspNetUsers",
                newName: "role_name");

            migrationBuilder.RenameColumn(
                name: "phonenumberconfirmed",
                table: "AspNetUsers",
                newName: "phone_number_confirmed");

            migrationBuilder.RenameColumn(
                name: "phonenumber",
                table: "AspNetUsers",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "passwordhash",
                table: "AspNetUsers",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "normalizedusername",
                table: "AspNetUsers",
                newName: "normalized_user_name");

            migrationBuilder.RenameColumn(
                name: "normalizedemail",
                table: "AspNetUsers",
                newName: "normalized_email");

            migrationBuilder.RenameColumn(
                name: "lockoutend",
                table: "AspNetUsers",
                newName: "lockout_end");

            migrationBuilder.RenameColumn(
                name: "lockoutenabled",
                table: "AspNetUsers",
                newName: "lockout_enabled");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "AspNetUsers",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "emailconfirmed",
                table: "AspNetUsers",
                newName: "email_confirmed");

            migrationBuilder.RenameColumn(
                name: "concurrencystamp",
                table: "AspNetUsers",
                newName: "concurrency_stamp");

            migrationBuilder.RenameColumn(
                name: "accessfailedcount",
                table: "AspNetUsers",
                newName: "access_failed_count");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetUsers",
                newName: "ıd");

            migrationBuilder.RenameColumn(
                name: "roleid",
                table: "AspNetUserRoles",
                newName: "role_ıd");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "AspNetUserRoles",
                newName: "user_ıd");

            migrationBuilder.RenameIndex(
                name: "ix_userroles_roleid",
                table: "AspNetUserRoles",
                newName: "ıx_user_roles_role_ıd");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "AspNetUserLogins",
                newName: "user_ıd");

            migrationBuilder.RenameColumn(
                name: "providerdisplayname",
                table: "AspNetUserLogins",
                newName: "provider_display_name");

            migrationBuilder.RenameColumn(
                name: "providerkey",
                table: "AspNetUserLogins",
                newName: "provider_key");

            migrationBuilder.RenameColumn(
                name: "loginprovider",
                table: "AspNetUserLogins",
                newName: "login_provider");

            migrationBuilder.RenameIndex(
                name: "ix_userlogins_userid",
                table: "AspNetUserLogins",
                newName: "ıx_user_logins_user_ıd");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "AspNetUserClaims",
                newName: "user_ıd");

            migrationBuilder.RenameColumn(
                name: "claimvalue",
                table: "AspNetUserClaims",
                newName: "claim_value");

            migrationBuilder.RenameColumn(
                name: "claimtype",
                table: "AspNetUserClaims",
                newName: "claim_type");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetUserClaims",
                newName: "ıd");

            migrationBuilder.RenameIndex(
                name: "ix_userclaims_userid",
                table: "AspNetUserClaims",
                newName: "ıx_user_claims_user_ıd");

            migrationBuilder.RenameColumn(
                name: "normalizedname",
                table: "AspNetRoles",
                newName: "normalized_name");

            migrationBuilder.RenameColumn(
                name: "concurrencystamp",
                table: "AspNetRoles",
                newName: "concurrency_stamp");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetRoles",
                newName: "ıd");

            migrationBuilder.RenameColumn(
                name: "roleid",
                table: "AspNetRoleClaims",
                newName: "role_ıd");

            migrationBuilder.RenameColumn(
                name: "claimvalue",
                table: "AspNetRoleClaims",
                newName: "claim_value");

            migrationBuilder.RenameColumn(
                name: "claimtype",
                table: "AspNetRoleClaims",
                newName: "claim_type");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetRoleClaims",
                newName: "ıd");

            migrationBuilder.RenameIndex(
                name: "ix_roleclaims_roleid",
                table: "AspNetRoleClaims",
                newName: "ıx_role_claims_role_ıd");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_tokens",
                table: "AspNetUserTokens",
                columns: new[] { "user_ıd", "login_provider", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_roles",
                table: "AspNetUserRoles",
                columns: new[] { "user_ıd", "role_ıd" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_logins",
                table: "AspNetUserLogins",
                columns: new[] { "login_provider", "provider_key" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_claims",
                table: "AspNetUserClaims",
                column: "ıd");

            migrationBuilder.AddPrimaryKey(
                name: "pk_role_claims",
                table: "AspNetRoleClaims",
                column: "ıd");

            migrationBuilder.AddForeignKey(
                name: "fk_role_claims_asp_net_roles_ıdentity_role_ıd",
                table: "AspNetRoleClaims",
                column: "role_ıd",
                principalTable: "AspNetRoles",
                principalColumn: "ıd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_claims_asp_net_users_application_user_ıd",
                table: "AspNetUserClaims",
                column: "user_ıd",
                principalTable: "AspNetUsers",
                principalColumn: "ıd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_logins_asp_net_users_application_user_ıd",
                table: "AspNetUserLogins",
                column: "user_ıd",
                principalTable: "AspNetUsers",
                principalColumn: "ıd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_roles_asp_net_roles_ıdentity_role_ıd",
                table: "AspNetUserRoles",
                column: "role_ıd",
                principalTable: "AspNetRoles",
                principalColumn: "ıd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_roles_asp_net_users_application_user_ıd",
                table: "AspNetUserRoles",
                column: "user_ıd",
                principalTable: "AspNetUsers",
                principalColumn: "ıd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_tokens_asp_net_users_application_user_ıd",
                table: "AspNetUserTokens",
                column: "user_ıd",
                principalTable: "AspNetUsers",
                principalColumn: "ıd",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
