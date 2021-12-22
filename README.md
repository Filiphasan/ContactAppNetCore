# Rise Consulting Rehber Uygulaması [TR]
Bu proje web veya mobil uygulamaların kullanacağı bir web servistir. Kodlanırken aşağıdaki teknolojiler ve araçlar kullanılmıştır.
- .Net 5.0 [Doc & Download](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
- Asp.Net Core Web Api [Doc](https://docs.microsoft.com/tr-tr/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio)
- Entity Framework Core Code First [Tutorial](https://www.entityframeworktutorial.net/) & [Doc](https://docs.microsoft.com/tr-tr/ef/core/)
- Redis Distrubuted Cache [Doc & Download](https://redis.io/)
- Docker Container [Doc & Download](https://www.docker.com/)
- Fluent Validation [Doc](https://docs.fluentvalidation.net/en/latest/aspnet.html)
- xUnit Unit Test Tool [Doc](https://xunit.net/)
- Swagger - Swaschbuckle 
- Moq Framework [Doc](https://www.moqthis.com/moq4/)
- Microsoft SQL Server 2017 Express Edition
- Visual Studio 2019 IDE

**Projeyi kullanmak için aşağıdaki teknolojilere ve araçlara zorunlu ihtiyaç duyulmaktadır.**
- [x] Git VCS [Download](https://git-scm.com/downloads)
- [x] .Net 5+ SDK (Software Development Kit) [Download](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
- [x] Docker [Download](https://www.docker.com/get-started)
- [x] Microsoft SQL Server 2017+ [Download](https://www.microsoft.com/en-us/download/details.aspx?id=55994)

**Projeyi kullanmak için aşağıdaki teknolojiler ve araçlar tavsiye edilmektedir.**
- [ ] Visual Studio 2019 Community Edition [Download](https://visualstudio.microsoft.com/tr/downloads/)

**Yukarıdaki maddeler tamam ise projeyi çalıştırmak için sırasıyla şu adımlar izlenmelidir.**

1. Powershell veya terminal ekranı açalım.
2. Docker kurulu olduğu için aşağıdaki kodu çalıştırarak Redis container ayağa kaldırmış oluyoruz.
3. Kod `docker run -p 6380:6379 --name some-redis -d redis`
4. Docker aracılığı ile son sürüm bir Redis container çalıştırmış oluyoruz. Bu kod redis image dosyası bilgisayarda yok ise indirmektedir. Çalıştırdığımız Redis container varsayılan olarak 6379 portunu kullanmaktadır. Yukarıdaki kod ile bir Redis containerı dışarıya 6380 portundan açmaktayız.
5. Projeyi kendi bilgisayarını indirmek için git cli kullanacağız. Bir terminal ekranı açtıktan sonra aşağıdaki kodu çalıştırıyoruz.
6. `cd your_local_project_direct`
7. Bu kod ile projeyi indirmek istediğimiz dosya dizinine geçiyoruz. Terminal ekranında aşağıdaki kodu çalıştırarak projeyi indirmiş oluyoruz.
8. `git clone https://github.com/Filiphasan/RiseConsulting_ContactApp.git`
9. İndirdiğimiz projeyi Visual Studio ile açmak için ContactApp.sln dosyasına çift tıklıyoruz. Eğer VS Code gibi bir editör kullanmak istiyorsak projenin bulunduğudizinde terminal açıp `code .` kodunu çalıştırıyoruz.
10. Visual Studio ile açtığımız zaman Visual Studio proje için gerekli dll vb. dosyaları otomatik indirmektedir. Emin olmak için Solution Explorer ekranında ContactApp.sln dosyasına sağ tıklayıp önce Clean Solution ve ardından Rebuil Solution diyebilirsiniz.
11. Projede migration yapısı kurulu olduğu için veri tabanını oluşturmak için SQL Server ihtiyaç duyulmaktadır. .Net CLI kullanarak veri tabanını oluşturacağız.
12. Bunun için ContactApp.API dizinine gitmeliyiz. Bu dizinde bir teminal ekranı açıp aşağıdaki kodu girmeliyiz.
13. `dotnet ef` kodu ile aşağıdaki benzer bir çıktı almıyor isek dotnet ef aracı kurulu değildir. Kurmak için bu kodu girmek gerekiyor. `dotnet tool install --global dotnet-ef`
```
_/\__
               ---==/    \\
         ___  ___   |.    \|\
        | __|| __|  |  )   \\\
        | _| | _|   \_/ |  //|\\
        |___||_|       /   \\\/\\

Entity Framework Core .NET Command-line Tools 2.1.3-rtm-32065

<Usage documentation follows, not shown.>
```
14. Benzer çıktıaldıysak proje içerisinde ContactApp.API dizininde bulunan `appsetting.json` dosyasındaki ConnectionStrings altındaki SqlServer bağlantı adresini kendi bilgisayarınıza uygun şekilde değiştirmelisiniz.
15. Her şey tamam ise ContactApp.API dizininde açtığımız terminalde `dotnet ef database update` komutunu çalıştırarak veri tabanını oluşturuyoruz.
16. Eğer projeyi VS Code ile açtıysak `dotnet build` komutunu terminalde çalıştırmalıyız. Gerekli paketler yüklenecektir.
17. Veri tabanı oluşturduk. Projeyi Visual Studio kullanarak çalıştırmak için ContactApp.API seçili olarak Debug modda IIS Express butonu ile çalıştırıyoruz.

# Rise Consulting Contact Application [EN]"
This project is a web service that will be used by web or mobile applications. The following technologies and tools were used while coding.
- .Net 5.0 [Doc & Download](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
- Asp.Net Core Web Api [Doc](https://docs.microsoft.com/tr-tr/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio)
- Entity Framework Core Code First [Tutorial](https://www.entityframeworktutorial.net/) & [Doc](https://docs.microsoft.com/tr-tr/ef/core/)
- Redis Distrubuted Cache [Doc & Download](https://redis.io/)
- Docker Container [Doc & Download](https://www.docker.com/)
- Fluent Validation [Doc](https://docs.fluentvalidation.net/en/latest/aspnet.html)
- xUnit Unit Test Tool [Doc](https://xunit.net/)
- Swagger - Swaschbuckle 
- Moq Framework [Doc](https://www.moqthis.com/moq4/)
- Microsoft SQL Server 2017 Express Edition
- Visual Studio 2019 IDE

**The following technologies and tools are required to use the project.**
- [x] Git VCS [Download](https://git-scm.com/downloads)
- [x] .Net 5+ SDK (Software Development Kit) [Download](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
- [x] Docker [Download](https://www.docker.com/get-started)
- [x] Microsoft SQL Server 2017+ [Download](https://www.microsoft.com/en-us/download/details.aspx?id=55994)

**The following technologies and tools are recommended for using the project.**
- [ ] Visual Studio 2019 Community Edition [Download](https://visualstudio.microsoft.com/tr/downloads/)

**If the above items are OK, the following steps should be followed to run the project.**
