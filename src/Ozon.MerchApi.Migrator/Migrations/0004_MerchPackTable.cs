using FluentMigrator;

namespace Ozon.MerchApi.Migrator.Migrations
{
    [Migration(4)]
    public class MerchPackTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("merch_pack")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey()
                .WithColumn("MerchPackType_id").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_pack");
        }
    }
}