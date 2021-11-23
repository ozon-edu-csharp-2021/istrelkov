using FluentMigrator;

namespace Ozon.MerchApi.Migrator.Migrations
{
    [Migration(3)]
    public class ItemPackTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("item_pack")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("merchPack_id").AsInt64().NotNullable()
                .WithColumn("stockItem_id").AsInt64().NotNullable()
                .WithColumn("quantity").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("item_pack");
        }
    }
}