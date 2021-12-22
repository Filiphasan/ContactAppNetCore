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
> Postman API Testi için json dosyası [indir](https://drive.google.com/file/d/1sn28g6SBuPW6USMdKkIWseoqu3bh3YjI/view?usp=sharing)
18. Her şey doğru gittiyse aşağıdaki ekranı görmeliyiz.
![alt](https://i.ibb.co/dD005fV/Ekran-g-r-nt-s-2021-12-22-215905.png)

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
1. Open Powershell or Terminal Screen.
2. Since Docker is installed, we run the code below and get the Redis container up.
3. Code `docker run -p 6380:6379 --name some-redis -d redis`
4. We are running a latest version of Redis container via Docker. This code downloads the redis image file if it is not available on the computer. The Redis container we run uses port 6379 by default. With the code above, we open a Redis container from port 6380.
5. We will use git cli to download the project on own computer. After opening a terminal screen, we run the following code.
6. `cd your_local_project_direct`
7. With this code, we move to the file directory where we want to download the project. By running the code below on the terminal screen, we download the project.
8. `git clone https://github.com/Filiphasan/RiseConsulting_ContactApp.git`
9. Double-click the ContactApp.sln file to open the downloaded project with Visual Studio. If we want to use an editor like VS Code, we open a terminal in the project directory and run the `code .`
10. When we open it with Visual Studio, the necessary dll for the Visual Studio project etc. It downloads files automatically. To be sure, you can right-click the ContactApp.sln file on the Solution Explorer screen and select Clean Solution and then Rebuil Solution.
11. Since the migration structure is installed in the project, SQL Server is needed to create the database. We will create the database using the .Net CLI.
12. For this we have to go to the ContactApp.API directory. In this directory, we need to open a terminal screen and enter the following code.
13. If we do not get an output similar to the one below with the `dotnet ef` code, the dotnet ef tool is not installed. You need to enter this code to install. `dotnet tool install --global dotnet-ef`
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
14. If we have a similar output, you should change the SqlServer connection address under ConnectionStrings in the `appsetting.json` file in the ContactApp.API directory in the project to suit your own computer.
15. If everything is ok, we create the database by running the `dotnet ef database update` command in the terminal we opened in the ContactApp.API directory.
16. f we opened the project with VS Code, we should run the `dotnet build ` command in the terminal. Required packages will be installed.
17. We created a database. To run the project using Visual Studio, we run it in Debug mode with the IIS Express button with ContactApp.API selected.
> Json file for Postman API Test [Download](https://drive.google.com/file/d/1sn28g6SBuPW6USMdKkIWseoqu3bh3YjI/view?usp=sharing)
18. And we see that screen.
![alt](https://i.ibb.co/dD005fV/Ekran-g-r-nt-s-2021-12-22-215905.png)
