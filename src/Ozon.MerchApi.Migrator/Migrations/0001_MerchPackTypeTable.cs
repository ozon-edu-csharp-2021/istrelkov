using FluentMigrator;

namespace Ozon.MerchApi.Migrator.Migrations
{
    [Migration(1)]
    public class MerchPackTypeTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("merch_pack_type")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_pack_type");
        }
    }
}