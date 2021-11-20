using FluentMigrator;

namespace Ozon.MerchApi.Migrator.Migrations
{
    [Migration(7)]
    public class MerchRequestTypeTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("merch_request_type")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_request_type");
        }
    }
}