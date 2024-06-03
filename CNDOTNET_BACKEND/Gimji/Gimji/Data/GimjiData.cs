using Gimji.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Gimji.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<MyPostgresDbContext>(), isProd);
            }
        }

        private static void SeedData(MyPostgresDbContext context, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }

            if (!context.categoryCodes.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                CategoryCode tobokki = new CategoryCode { CodeValue = "tokbokki", Name = "Tokbokki", Image = "image1.jpg", Description = "Description 1" };
                CategoryCode kimbak = new CategoryCode { CodeValue = "kimbak", Name = "Kimbak", Image = "image2.jpg", Description = "Description 2" };
                CategoryCode salad = new CategoryCode { CodeValue = "salad", Name = "Salad", Image = "image3.jpg", Description = "Description 3" };
                CategoryCode thitNuong = new CategoryCode { CodeValue = "thit-nuong", Name = "Thịt Nướng", Image = "image4.jpg", Description = "Description 4" };
                CategoryCode gaSot = new CategoryCode { CodeValue = "ga-sot", Name = "Gà Sốt", Image = "image5.jpg", Description = "Description 5" };
                CategoryCode mi = new CategoryCode { CodeValue = "mien-mi", Name = "Miến/Mì", Image = "image6.jpg", Description = "Description 6" };
                CategoryCode miCay = new CategoryCode { CodeValue = "mi-cay", Name = "Mì Cay", Image = "image6.jpg", Description = "Description 7" };
                CategoryCode com = new CategoryCode { CodeValue = "com", Name = "Cơm", Image = "image7.jpg", Description = "Description 8" };
                context.categoryCodes.AddRange(
                    tobokki, kimbak, salad, thitNuong, gaSot, mi, miCay, com
                );

                context.SaveChanges();
   
                Console.WriteLine("--> Seeding Data...");
                context.products.AddRange(
                    new Product
                    {
                        productID = "com-tron-han-quoc",
                        name = "Cơm Trộn Hàn QUốc",
                        price = 69000,
                        image1 = "comtronhanquoc.png",
                        image2 = "",
                        image3 = "",
                        description = "Cơm Trộn Hàn Quốc là một món ăn phổ biến trong ẩm thực Hàn Quốc. Món này bao gồm cơm trắng được trộn đều với các loại rau sống như cà rốt, dưa leo, cà chua, thêm vào đó là thịt gà hoặc thịt bò đã được xào qua. Sự kết hợp của cơm, rau và thịt cùng với sốt đậm đà tạo nên một hương vị đặc trưng và hấp dẫn. Cơm Trộn Hàn Quốc thường được phục vụ kèm theo trứng ốp-la và kimchi, tạo nên bữa ăn đầy đủ dinh dưỡng và ngon miệng.",
                        nsn = "nsn",
                        category = com
                    },
                    new Product
                    {
                        productID = "kimbak-chien-xu",
                        name = "Kimbak Chiên Xù",
                        price = 45000,
                        image1 = "kimbakchienxu.png",
                        image2 = "",
                        image3 = "",
                        description = "Kimbak Chiên Xù là một món ăn đặc trưng của ẩm thực Hàn Quốc. Món này được làm từ bột gạo truyền thống, được nhồi với nhân bên trong thường là thịt hoặc rau củ. Sau đó, Kimbak được chiên vàng giòn, tạo nên lớp vỏ giòn và nhân mềm thơm ngon. Kimbak thường được thưởng thức cùng với nước chấm đặc trưng, là một món ăn phổ biến và được yêu thích trong các bữa ăn gia đình và hội bạn.",
                        nsn = "nsn",
                        category = kimbak
                    },
                    new Product
                    {
                        productID = "kimbak-truyen-thong",
                        name = "Kimbak Truyền Thống",
                        price = 39000,
                        image1 = "kimbaktruyenthong.png",
                        image2 = "",
                        image3 = "",
                        description = "Kimbak Truyền Thống là một món ăn đặc trưng của ẩm thực Hàn Quốc. Món này được làm từ bột gạo truyền thống, được nhồi với nhân bên trong thường là thịt hoặc rau củ. Sau đó, Kimbak được hấp chín, tạo nên lớp vỏ mềm mịn và nhân thơm ngon. Thường được ăn kèm với nước chấm đặc trưng, Kimbak Truyền Thống là một lựa chọn ngon miệng cho các bữa ăn gia đình hoặc những buổi gặp mặt bạn bè.",
                        nsn = "nsn",
                        category = kimbak
                    },
                    new Product
                    {
                        productID = "kimbak-thit-heo-nuong",
                        name = "Kimbak Thịt Heo Nướng",
                        price = 49000,
                        image1 = "kimbakthitheonuong.png",
                        image2 = "",
                        image3 = "",
                        description = "Kimbak Thịt Heo Nướng là một món ăn đặc trưng trong ẩm thực Hàn Quốc. Món này được làm từ bột gạo truyền thống và nhân bên trong là thịt heo được ướp gia vị và nướng chín. Kimbak thường được ăn kèm với rau sống và nước chấm đậm đà, tạo nên hương vị ngon miệng và đầy đặn.",
                        nsn = "nsn",
                        category = kimbak
                    },
                    new Product
                    {
                        productID = "kimbak-trung-cuon",
                        name = "Kimbak Trứng Cuộn",
                        price = 49000,
                        image1 = "kimbaktrungcuon.png",
                        image2 = "",
                        image3 = "",
                        description = "Kimbak Trứng Cuộn là một món ăn độc đáo trong ẩm thực Hàn Quốc. Món này được làm từ bột gạo truyền thống và cuộn cùng với trứng, thịt và rau củ. Sau đó, Kimbak được nướng chín và thưởng thức cùng với nước chấm đặc trưng, tạo nên hương vị đặc biệt và ngon miệng.",
                        nsn = "nsn",
                        category = kimbak
                    },
                    new Product
                    {
                        productID = "salad-ga-sot-mayonnaise",
                        name = "Salad Gà Sốt Mayonnaise",
                        price = 39000,
                        image1 = "saladgasot.png",
                        image2 = "",
                        image3 = "",
                        description = "Salad Gà Sốt Mayonnaise là một món salad phổ biến trong ẩm thực Hàn Quốc. Món này bao gồm gà xào hoặc luộc kèm với các loại rau xanh như cà rốt, dưa leo, cải bắp, thêm vào đó là sốt mayonnaise thơm ngon. Salad Gà Sốt Mayonnaise là một lựa chọn lý tưởng cho bữa ăn nhẹ hoặc bữa trưa sảng khoái.",
                        nsn = "nsn",
                        category = salad
                    },
                    new Product
                    {
                        productID = "salad-gimji",
                        name = "Salad Gimji",
                        price = 49000,
                        image1 = "saladgimji.png",
                        image2 = "",
                        image3 = "",
                        description = "Salad Gimji là một món salad truyền thống của ẩm thực Hàn Quốc. Món này được làm từ rong biển Gimji xanh mát, kèm theo các loại rau sống và thêm vào đó là sốt chua ngọt đặc trưng. Salad Gimji thường được thưởng thức trong các bữa ăn nhẹ hoặc những buổi picnic ngoài trời.",
                        nsn = "nsn",
                        category = salad
                    },
                    new Product
                    {
                        productID = "salad-thanh-cua",
                        name = "Salad Thanh Cua",
                        price = 39000,
                        image1 = "saladthanhcua.png",
                        image2 = "",
                        image3 = "",
                        description = "Salad Thanh Cua là một món salad đặc trưng của ẩm thực Hàn Quốc. Món này bao gồm cua tươi xào hoặc luộc kèm với các loại rau xanh như cà rốt, dưa leo, cải bắp, thêm vào đó là sốt chua ngọt đậm đà. Salad Thanh Cua là một lựa chọn tuyệt vời cho các bữa ăn nhẹ hoặc bữa trưa ngon miệng.",
                        nsn = "nsn",
                        category = salad
                    },
                    new Product
                    {
                        productID = "ba-chi-heo-nuong",
                        name = "Ba Chỉ Heo Nướng",
                        price = 75000,
                        image1 = "bachiheonuongmatong.png",
                        image2 = "",
                        image3 = "",
                        description = "Ba Chỉ Heo Nướng là một món ăn phổ biến trong ẩm thực Hàn Quốc. Ba Chỉ là phần thịt từ lưng heo, được ướp gia vị và nướng chín trên lửa than hoặc lò nướng. Ba Chỉ Heo Nướng thường được ăn kèm với nước chấm đặc trưng và rau sống, tạo nên một bữa ăn ngon miệng và bổ dưỡng.",
                        nsn = "nsn",
                        category = thitNuong
                    },
                    new Product
                    {
                        productID = "ba-chi-heo-nuong-mat-ong",
                        name = "Ba Chỉ Heo Nướng Mật Ong",
                        price = 75000,
                        image1 = "bachithitheonuong.png",
                        image2 = "",
                        image3 = "",
                        description = "Ba Chỉ Heo Nướng Mật Ong là một món ăn đặc biệt trong ẩm thực Hàn Quốc. Ba Chỉ là phần thịt từ lưng heo, được ướp gia vị và nướng chín trên lửa than hoặc lò nướng, sau đó được chấm mật ong thơm ngon. Ba Chỉ Heo Nướng Mật Ong là một lựa chọn ngon miệng cho các dịp tiệc tùng và hội bạn.",
                        nsn = "nsn",
                        category = thitNuong
                    },
                    new Product
                    {
                        productID = "tobokki-cha-ca-sot",
                        name = "Tobokki Chả Cá Sốt",
                        price = 55000,
                        image1 = "tobokkichaca.png",
                        image2 = "",
                        image3 = "",
                        description = "Tobokki Chả Cá Sốt là một món ăn độc đáo trong ẩm thực Hàn Quốc. Món này bao gồm tobokki (bánh gạo dẻo) được kết hợp với chả cá và sốt cay nồng, tạo nên hương vị đặc trưng và ngon miệng. Tobokki Chả Cá Sốt thường được thưởng thức trong các quán nhậu hoặc các buổi tiệc.",
                        nsn = "nsn",
                        category = tobokki
                    },
                    new Product
                    {
                        productID = "tobokki-ga-sot-hq",
                        name = "Tobokki Gà Sốt HQ",
                        price = 69000,
                        image1 = "tobokkigasot.png",
                        image2 = "",
                        image3 = "",
                        description = "Tobokki Gà Sốt HQ là một món ăn phổ biến trong ẩm thực Hàn Quốc. Món này bao gồm tobokki (bánh gạo dẻo) được kết hợp với thịt gà và sốt cay đậm đà. Tobokki Gà Sốt HQ thường được thưởng thức trong các quán ăn nhanh hoặc là một món nhẹ vào buổi chiều.",
                        nsn = "nsn",
                        category = tobokki
                    },
                    new Product
                    {
                        productID = "tobokki-sot-pho-mai",
                        name = "Tobokki Sốt Phô Mai",
                        price = 59000,
                        image1 = "tobokkisotphomai.png",
                        image2 = "",
                        image3 = "",
                        description = "Tobokki Sốt Phô Mai là một món ăn độc đáo và thú vị trong ẩm thực Hàn Quốc. Món này bao gồm tobokki (bánh gạo dẻo) được kết hợp với sốt phô mai thơm ngon và béo ngậy. Tobokki Sốt Phô Mai thường được thưởng thức trong các quán ăn vặt hoặc là một món nhẹ vào buổi tối.",
                        nsn = "nsn",
                        category = tobokki
                    }
                );
                context.SaveChanges();
            }
            if (!context.roles.Any())
            {
                Console.WriteLine("--> Seeding Role Data...");
                Role admin = new Role
                {
                    numberedPosition = 1,
                    roleName = "ADMIN",
                    startDate = new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc), // Chỉ định kiểu là Utc
                    endDate = new DateTime(2022, 12, 31, 0, 0, 0, DateTimeKind.Utc), // Chỉ định kiểu là Utc
                    salaryCurrency = 5000.00f
                };
                Role employee = new Role
                {
                    numberedPosition = 2,
                    roleName = "USER",
                    startDate = new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc), // Chỉ định kiểu là Utc
                    endDate = new DateTime(2022, 12, 31, 0, 0, 0, DateTimeKind.Utc), // Chỉ định kiểu là Utc
                    salaryCurrency = 3000.00f
                };
                context.roles.AddRange(admin , employee);
                context.SaveChanges();

                if (!context.employees.Any())
                {
                    Console.WriteLine("--> Seeding Employee Data...");
                    var adminRole = context.roles.FirstOrDefault(r => r.roleName == "ADMIN");
                    var employeeRole = context.roles.FirstOrDefault(r => r.roleName == "USER");

                    context.employees.AddRange(
                        new employee
                        {
                            id = 1,
                            givenName = "Long",
                            familyName = "Nguyen Lam Thanh",
                            email = "thanhlongndp@gmail.com",
                            telephone = "1234567890",
                            gender = "Male",
                            birthDate = new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc), // Chỉ định kiểu là Utc
                            jobTitle = "Software Engineer",
                            homeLocation = "Viet Nam",
                            hasCertification = true,
                            accountId = "thanhlongndp@gmail.com",
                            accountPassword = "password123",
                            Roles = new List<Role> { adminRole }
                        },
                        new employee
                        {
                            id = 2,
                            givenName = "Thanh đẹp trai",
                            familyName = "",
                            email = "thanhlongndp@gmail.com",
                            telephone = "0987654321",
                            gender = "male",
                            birthDate = new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc), // Chỉ định kiểu là Utc
                            jobTitle = "Project Manager",
                            homeLocation = "Los Angeles",
                            hasCertification = false,
                            accountId = "doanxuanthanh@gmail.com",
                            accountPassword = "password123",
                            Roles = new List<Role> { employeeRole }
                        },
                        // Adding more employees
                        new employee
                        {
                            id = 3,
                            givenName = "Ha",
                            familyName = "Tran",
                            email = "ha.tran@example.com",
                            telephone = "2345678901",
                            gender = "Female",
                            birthDate = new DateTime(1990, 2, 15, 0, 0, 0, DateTimeKind.Utc),
                            jobTitle = "Data Analyst",
                            homeLocation = "Ha Noi",
                            hasCertification = true,
                            accountId = "ha.tran@example.com",
                            accountPassword = "password123",
                            Roles = new List<Role> { employeeRole }
                        },
                        new employee
                        {
                            id = 4,
                            givenName = "Minh",
                            familyName = "Le",
                            email = "minh.le@example.com",
                            telephone = "3456789012",
                            gender = "Male",
                            birthDate = new DateTime(1985, 7, 22, 0, 0, 0, DateTimeKind.Utc),
                            jobTitle = "UX Designer",
                            homeLocation = "Ho Chi Minh City",
                            hasCertification = false,
                            accountId = "minh.le@example.com",
                            accountPassword = "password123",
                            Roles = new List<Role> { employeeRole }
                        },
                        new employee
                        {
                            id = 5,
                            givenName = "Anh",
                            familyName = "Nguyen",
                            email = "anh.nguyen@example.com",
                            telephone = "4567890123",
                            gender = "Female",
                            birthDate = new DateTime(1995, 11, 30, 0, 0, 0, DateTimeKind.Utc),
                            jobTitle = "Marketing Specialist",
                            homeLocation = "Da Nang",
                            hasCertification = true,
                            accountId = "anh.nguyen@example.com",
                            accountPassword = "password123",
                            Roles = new List<Role> { employeeRole }
                        },
                        new employee
                        {
                            id = 6,
                            givenName = "Cuong",
                            familyName = "Pham",
                            email = "cuong.pham@example.com",
                            telephone = "5678901234",
                            gender = "Male",
                            birthDate = new DateTime(1987, 3, 10, 0, 0, 0, DateTimeKind.Utc),
                            jobTitle = "Network Engineer",
                            homeLocation = "Can Tho",
                            hasCertification = true,
                            accountId = "cuong.pham@example.com",
                            accountPassword = "password123",
                            Roles = new List<Role> { employeeRole }
                        },
                        new employee
                        {
                            id = 7,
                            givenName = "Duyen",
                            familyName = "Tran",
                            email = "duyen.tran@example.com",
                            telephone = "6789012345",
                            gender = "Female",
                            birthDate = new DateTime(1992, 5, 5, 0, 0, 0, DateTimeKind.Utc),
                            jobTitle = "HR Specialist",
                            homeLocation = "Nha Trang",
                            hasCertification = false,
                            accountId = "duyen.tran@example.com",
                            accountPassword = "password123",
                            Roles = new List<Role> { employeeRole }
                        },
                        new employee
                        {
                            id = 8,
                            givenName = "Hieu",
                            familyName = "Nguyen",
                            email = "hieu.nguyen@example.com",
                            telephone = "7890123456",
                            gender = "Male",
                            birthDate = new DateTime(1993, 8, 18, 0, 0, 0, DateTimeKind.Utc),
                            jobTitle = "Database Administrator",
                            homeLocation = "Hue",
                            hasCertification = true,
                            accountId = "hieu.nguyen@example.com",
                            accountPassword = "password123",
                            Roles = new List<Role> { employeeRole }
                        },
                        new employee
                        {
                            id = 9,
                            givenName = "Hoa",
                            familyName = "Phan",
                            email = "hoa.phan@example.com",
                            telephone = "8901234567",
                            gender = "Female",
                            birthDate = new DateTime(1988, 4, 20, 0, 0, 0, DateTimeKind.Utc),
                            jobTitle = "Web Developer",
                            homeLocation = "Quang Ngai",
                            hasCertification = true,
                            accountId = "hoa.phan@example.com",
                            accountPassword = "password123",
                            Roles = new List<Role> { employeeRole }
                        },
                        new employee
                        {
                            id = 10,
                            givenName = "Khoa",
                            familyName = "Do",
                            email = "khoa.do@example.com",
                            telephone = "9012345678",
                            gender = "Male",
                            birthDate = new DateTime(1983, 9, 25, 0, 0, 0, DateTimeKind.Utc),
                            jobTitle = "Systems Analyst",
                            homeLocation = "Binh Dinh",
                            hasCertification = false,
                            accountId = "khoa.do@example.com",
                            accountPassword = "password123",
                            Roles = new List<Role> { employeeRole }
                        },
                        new employee
                        {
                            id = 11,
                            givenName = "Linh",
                            familyName = "Nguyen",
                            email = "linh.nguyen@example.com",
                            telephone = "1230984567",
                            gender = "Female",
                            birthDate = new DateTime(1991, 6, 15, 0, 0, 0, DateTimeKind.Utc),
                            jobTitle = "Financial Analyst",
                            homeLocation = "Phu Quoc",
                            hasCertification = true,
                            accountId = "linh.nguyen@example.com",
                            accountPassword = "password123",
                            Roles = new List<Role> { employeeRole }
                        },
                        new employee
                        {
                            id = 12,
                            givenName = "Nam",
                            familyName = "Bui",
                            email = "nam.bui@example.com",
                            telephone = "2345678901",
                            gender = "Male",
                            birthDate = new DateTime(1990, 12, 1, 0, 0, 0, DateTimeKind.Utc),
                            jobTitle = "Graphic Designer",
                            homeLocation = "Vung Tau",
                            hasCertification = false,
                            accountId = "nam.bui@example.com",
                            accountPassword = "password123",
                            Roles = new List<Role> { employeeRole }
                        }
                    );

                    context.SaveChanges();
                }
            }
            if (!context.customers.Any())
            {
                Console.WriteLine("--> Seeding Customer Data...");
                context.customers.AddRange(
                    new customer
                    {
                        id = 1,
                        givenName = "Customer1",
                        familyName = "Family1",
                        gender = "Male",
                        birthDate = new DateTime(1990, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer1@example.com",
                        telephone = "1111111111",
                        jobTitle = "Developer",
                        homeLocation = "City1",
                        hasCertification = true,
                        accountId = "customer1",
                        accountPassword = "password1"
                    },
                    new customer
                    {
                        id = 2,
                        givenName = "Customer2",
                        familyName = "Family2",
                        gender = "Female",
                        birthDate = new DateTime(1991, 2, 2, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer2@example.com",
                        telephone = "2222222222",
                        jobTitle = "Manager",
                        homeLocation = "City2",
                        hasCertification = false,
                        accountId = "customer2",
                        accountPassword = "password2"
                    },
                    new customer
                    {
                        id = 3,
                        givenName = "Customer3",
                        familyName = "Family3",
                        gender = "Male",
                        birthDate = new DateTime(1992, 3, 3, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer3@example.com",
                        telephone = "3333333333",
                        jobTitle = "Analyst",
                        homeLocation = "City3",
                        hasCertification = true,
                        accountId = "customer3",
                        accountPassword = "password3"
                    },
                    new customer
                    {
                        id = 4,
                        givenName = "Customer4",
                        familyName = "Family4",
                        gender = "Female",
                        birthDate = new DateTime(1993, 4, 4, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer4@example.com",
                        telephone = "4444444444",
                        jobTitle = "Designer",
                        homeLocation = "City4",
                        hasCertification = false,
                        accountId = "customer4",
                        accountPassword = "password4"
                    },
                    new customer
                    {
                        id = 5,
                        givenName = "Customer5",
                        familyName = "Family5",
                        gender = "Male",
                        birthDate = new DateTime(1994, 5, 5, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer5@example.com",
                        telephone = "5555555555",
                        jobTitle = "Developer",
                        homeLocation = "City5",
                        hasCertification = true,
                        accountId = "customer5",
                        accountPassword = "password5"
                    },
                    new customer
                    {
                        id = 6,
                        givenName = "Customer6",
                        familyName = "Family6",
                        gender = "Female",
                        birthDate = new DateTime(1995, 6, 6, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer6@example.com",
                        telephone = "6666666666",
                        jobTitle = "Tester",
                        homeLocation = "City6",
                        hasCertification = false,
                        accountId = "customer6",
                        accountPassword = "password6"
                    },
                    new customer
                    {
                        id = 7,
                        givenName = "Customer7",
                        familyName = "Family7",
                        gender = "Male",
                        birthDate = new DateTime(1996, 7, 7, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer7@example.com",
                        telephone = "7777777777",
                        jobTitle = "Support",
                        homeLocation = "City7",
                        hasCertification = true,
                        accountId = "customer7",
                        accountPassword = "password7"
                    },
                    new customer
                    {
                        id = 8,
                        givenName = "Customer8",
                        familyName = "Family8",
                        gender = "Female",
                        birthDate = new DateTime(1997, 8, 8, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer8@example.com",
                        telephone = "8888888888",
                        jobTitle = "Engineer",
                        homeLocation = "City8",
                        hasCertification = false,
                        accountId = "customer8",
                        accountPassword = "password8"
                    },
                    new customer
                    {
                        id = 9,
                        givenName = "Customer9",
                        familyName = "Family9",
                        gender = "Male",
                        birthDate = new DateTime(1998, 9, 9, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer9@example.com",
                        telephone = "9999999999",
                        jobTitle = "Architect",
                        homeLocation = "City9",
                        hasCertification = true,
                        accountId = "customer9",
                        accountPassword = "password9"
                    },
                    new customer
                    {
                        id = 10,
                        givenName = "Customer10",
                        familyName = "Family10",
                        gender = "Female",
                        birthDate = new DateTime(1999, 10, 10, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer10@example.com",
                        telephone = "1010101010",
                        jobTitle = "Consultant",
                        homeLocation = "City10",
                        hasCertification = false,
                        accountId = "customer10",
                        accountPassword = "password10"
                    },
                    new customer
                    {
                        id = 11,
                        givenName = "Customer11",
                        familyName = "Family11",
                        gender = "Male",
                        birthDate = new DateTime(1980, 11, 11, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer11@example.com",
                        telephone = "1111111112",
                        jobTitle = "Developer",
                        homeLocation = "City11",
                        hasCertification = true,
                        accountId = "customer11",
                        accountPassword = "password11"
                    },
                    new customer
                    {
                        id = 12,
                        givenName = "Customer12",
                        familyName = "Family12",
                        gender = "Female",
                        birthDate = new DateTime(1981, 12, 12, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer12@example.com",
                        telephone = "1212121212",
                        jobTitle = "Manager",
                        homeLocation = "City12",
                        hasCertification = false,
                        accountId = "customer12",
                        accountPassword = "password12"
                    },
                    new customer
                    {
                        id = 13,
                        givenName = "Customer13",
                        familyName = "Family13",
                        gender = "Male",
                        birthDate = new DateTime(1982, 1, 13, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer13@example.com",
                        telephone = "1313131313",
                        jobTitle = "Analyst",
                        homeLocation = "City13",
                        hasCertification = true,
                        accountId = "customer13",
                        accountPassword = "password13"
                    },
                    new customer
                    {
                        id = 14,
                        givenName = "Customer14",
                        familyName = "Family14",
                        gender = "Female",
                        birthDate = new DateTime(1983, 2, 14, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer14@example.com",
                        telephone = "1414141414",
                        jobTitle = "Designer",
                        homeLocation = "City14",
                        hasCertification = false,
                        accountId = "customer14",
                        accountPassword = "password14"
                    },
                    new customer
                    {
                        id = 15,
                        givenName = "Customer15",
                        familyName = "Family15",
                        gender = "Male",
                        birthDate = new DateTime(1984, 3, 15, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer15@example.com",
                        telephone = "1515151515",
                        jobTitle = "Developer",
                        homeLocation = "City15",
                        hasCertification = true,
                        accountId = "customer15",
                        accountPassword = "password15"
                    },
                    new customer
                    {
                        id = 16,
                        givenName = "Customer16",
                        familyName = "Family16",
                        gender = "Female",
                        birthDate = new DateTime(1985, 4, 16, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer16@example.com",
                        telephone = "1616161616",
                        jobTitle = "Tester",
                        homeLocation = "City16",
                        hasCertification = false,
                        accountId = "customer16",
                        accountPassword = "password16"
                    },
                    new customer
                    {
                        id = 17,
                        givenName = "Customer17",
                        familyName = "Family17",
                        gender = "Male",
                        birthDate = new DateTime(1986, 5, 17, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer17@example.com",
                        telephone = "1717171717",
                        jobTitle = "Support",
                        homeLocation = "City17",
                        hasCertification = true,
                        accountId = "customer17",
                        accountPassword = "password17"
                    },
                    new customer
                    {
                        id = 18,
                        givenName = "Customer18",
                        familyName = "Family18",
                        gender = "Female",
                        birthDate = new DateTime(1987, 6, 18, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer18@example.com",
                        telephone = "1818181818",
                        jobTitle = "Engineer",
                        homeLocation = "City18",
                        hasCertification = false,
                        accountId = "customer18",
                        accountPassword = "password18"
                    },
                    new customer
                    {
                        id = 19,
                        givenName = "Customer19",
                        familyName = "Family19",
                        gender = "Male",
                        birthDate = new DateTime(1988, 7, 19, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer19@example.com",
                        telephone = "1919191919",
                        jobTitle = "Architect",
                        homeLocation = "City19",
                        hasCertification = true,
                        accountId = "customer19",
                        accountPassword = "password19"
                    },
                    new customer
                    {
                        id = 20,
                        givenName = "Customer20",
                        familyName = "Family20",
                        gender = "Female",
                        birthDate = new DateTime(1989, 8, 20, 0, 0, 0, DateTimeKind.Utc),
                        email = "customer20@example.com",
                        telephone = "2020202020",
                        jobTitle = "Consultant",
                        homeLocation = "City20",
                        hasCertification = false,
                        accountId = "customer20",
                        accountPassword = "password20"
                    }
                );

                context.SaveChanges();
            }
            if (!context.restaurantTables.Any())
            {
                Console.WriteLine("--> Seeding RestaurantTable Data...");
                context.restaurantTables.AddRange(
                    new RestaurantTable { TableNumber = 1, TableName = "Table1", IsOccupied = false, IsReserved = false },
                    new RestaurantTable { TableNumber = 2, TableName = "Table2", IsOccupied = true, IsReserved = false },
                    new RestaurantTable { TableNumber = 3, TableName = "Table3", IsOccupied = false, IsReserved = true },
                    new RestaurantTable { TableNumber = 4, TableName = "Table4", IsOccupied = true, IsReserved = true },
                    new RestaurantTable { TableNumber = 5, TableName = "Table5", IsOccupied = false, IsReserved = false },
                    new RestaurantTable { TableNumber = 6, TableName = "Table6", IsOccupied = true, IsReserved = false },
                    new RestaurantTable { TableNumber = 7, TableName = "Table7", IsOccupied = false, IsReserved = true },
                    new RestaurantTable { TableNumber = 8, TableName = "Table8", IsOccupied = true, IsReserved = true },
                    new RestaurantTable { TableNumber = 9, TableName = "Table9", IsOccupied = false, IsReserved = false },
                    new RestaurantTable { TableNumber = 10, TableName = "Table10", IsOccupied = true, IsReserved = false },
                    new RestaurantTable { TableNumber = 11, TableName = "Table11", IsOccupied = false, IsReserved = true },
                    new RestaurantTable { TableNumber = 12, TableName = "Table12", IsOccupied = true, IsReserved = true },
                    new RestaurantTable { TableNumber = 13, TableName = "Table13", IsOccupied = false, IsReserved = false },
                    new RestaurantTable { TableNumber = 14, TableName = "Table14", IsOccupied = true, IsReserved = false },
                    new RestaurantTable { TableNumber = 15, TableName = "Table15", IsOccupied = false, IsReserved = true },
                    new RestaurantTable { TableNumber = 16, TableName = "Table16", IsOccupied = true, IsReserved = true },
                    new RestaurantTable { TableNumber = 17, TableName = "Table17", IsOccupied = false, IsReserved = false },
                    new RestaurantTable { TableNumber = 18, TableName = "Table18", IsOccupied = true, IsReserved = false },
                    new RestaurantTable { TableNumber = 19, TableName = "Table19", IsOccupied = false, IsReserved = true },
                    new RestaurantTable { TableNumber = 20, TableName = "Table20", IsOccupied = true, IsReserved = true }
                );

                context.SaveChanges();
            }

            if (!context.reservations.Any())
            {
                Console.WriteLine("--> Seeding FoodEstablishmentReservation Data...");
                context.reservations.AddRange(
                    new FoodEstablishmentReservation
                    {
                        reservationId = 1,
                        reservationStatus = "Confirmed",
                        bookingTime = DateTime.UtcNow.AddHours(-1),
                        modifiedTime = DateTime.UtcNow,
                        underName = "Customer1",
                        provider = context.employees.FirstOrDefault(e => e.id == 1),
                        startTime = DateTime.UtcNow.AddHours(1),
                        endTime = DateTime.UtcNow.AddHours(2),
                        partySize = 2
                    },
                    new FoodEstablishmentReservation
                    {
                        reservationId = 2,
                        reservationStatus = "Pending",
                        bookingTime = DateTime.UtcNow.AddHours(-2),
                        modifiedTime = DateTime.UtcNow,
                        underName = "Customer2",
                        provider = context.employees.FirstOrDefault(e => e.id == 2),
                        startTime = DateTime.UtcNow.AddHours(3),
                        endTime = DateTime.UtcNow.AddHours(4),
                        partySize = 4
                    }
                    // Add more reservation objects here
                    // ...
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
