# FML APP
 Flat Manager Log

Uygulamanın çalışması için
appsettingsjson ve program cse şunlar eklenmeli;

appsettingsjson:
allowed hosts un üzerine süsülü paraentezve virgülün altına:

  "ConnectionStrings": {
    "FMLDb": Sizin CONNECTION STRING"
  },


program.cs e:
Builder services add controllersın altına:

var connectionString = builder.Configuration.GetConnectionString("FMLDb");
builder.Services.AddDbContext<FMLContext>(options => options.UseSqlServer(connectionString));

Ardından SQLde Managers tablosuna manuel olarak giriş ekranında girilecek bilgiler eksiksiz girilip kaydedilmelidir.