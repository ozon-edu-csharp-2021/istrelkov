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
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_pack_type");
        }
    }
}