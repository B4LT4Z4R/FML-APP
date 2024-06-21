# FML APP
 Flat Manager Log

dotnet new mvc -o AdminBlog
 dotnet new mvc -o SiteBlog

 dotnet run-- projeyi başlatmak için



, code terminalinde:

 dotnet add package Microsoft.EntityFrameworkCore-- paketleri yükler

dotnet ef migrations add first -- migration klasörü oluşturur / Bunun için gerekli olan şunlar yüklenir:

dotnet add package Microsoft.EntityFrameworkCore.design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer



hataların giderilmesi için appsettingsjson ve program cse şunlar eklenmeli:
appsettingsjson:
allowed hosts un üzerine süsülü paraentezve virgülün altına:


  "ConnectionStrings": {
    "BlogDb": "Server=B4LT4Z4R\\SQLEXPRESS;Database=FMLDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },

program.cs e:
Builder services add controllersın altına,


var connectionString = builder.Configuration.GetConnectionString("FMLDb");
builder.Services.AddDbContext<FMLContext>(options => options.UseSqlServer(connectionString));


versiyon hatası varsa bin klasöründe deps.json ile biten dosyadaki dotnet versiyonları seçilip değiştirilir
bunun ardından şu kod girilir:
 dotnet tool install --global dotnet-ef --version 8.*


En son MSSQLde databse ve tabloların oluşturulması için girilecek kod:
--    dotnet ef database update


//// login ekranı entegre edildikten sonra session hatası alınıyorsa

dotnet add package Microsoft.AspNetCore.Session

programcs e 

app.UseSession();

 eklenir yoksa çalışmaz

////




site blog için paketler:

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design