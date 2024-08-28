RODAR O CONTAINER DO SQL SERVER =>

sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Senha_182830" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2022-latest

 Data Source=tcp:::1,1433;Initial Catalog=TCCLions;User ID=sa;Password=Senha_182830;TrustServerCertificate=True;
