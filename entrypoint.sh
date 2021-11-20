#!/bin/bash
set -e
run_cmd="dotnet Ozon.MerchApi.dll --no-build -v d"

echo "Run MerchApi DB migrations"
dotnet Ozon.MerchApi.Migrator.dll --no-build -v d -- --dryrun

dotnet Ozon.MerchApi.Migrator.dll --no-build -v d
echo "Run MerchApi DB migrations complete"

echo "Run MerchApi: $run_cmd"
exec $run_cmd