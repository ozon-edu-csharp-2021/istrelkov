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
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_request_type");
        }
    }
}