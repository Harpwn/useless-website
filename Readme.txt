#TEST COVERAGE
dotnet test /p:CollectCoverage=true /p:ExcludeByFile=\"**/Migrations/**.cs%2c**/Seeding/**.cs%2c**/Model/**.cs\"
#ADD MIGRATION
##In uselesscms dir
dotnet ef migrations add 00_name --project ../UselessCore

#UPDATE DATABASE 

##For Production
$env:ASPNETCORE_ENVIRONMENT='Production'

dotnet ef database update


#LIVE DEPLOYMENT

#Update SQL Production Database
#public cms and api
#in vscode - useless-website
npm run build
#static website deployment