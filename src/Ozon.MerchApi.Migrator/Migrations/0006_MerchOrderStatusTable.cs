using FluentMigrator;

namespace Ozon.MerchApi.Migrator.Migrations
{
    [Migration(6)]
    public class MerchOrderStatusTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("merch_order_status")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_order_status");
        }
    }
}