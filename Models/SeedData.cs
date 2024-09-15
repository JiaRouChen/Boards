﻿using Microsoft.EntityFrameworkCore;

namespace MyModel_CodeFirst.Models
{
    //1.3.2 撰寫SeedData類別的內容
    //      (1)撰寫靜態方法 Initialize(IServiceProvider serviceProvider)
    //      (2)撰寫Book及ReBook資料表內的初始資料程式
    //      (3)撰寫getFileBytes，功能為將照片轉成二進位資料(寫在class要給一個方法函數)
    //Book book = new Book();
    //book.Title = "今天天氣真好啊!!";
    public class SeedData
    {
        //(1)撰寫靜態方法 Initialize(IServiceProvider serviceProvider)
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //(2)撰寫Book及ReBook資料表內的初始資料程式，所有用到資料庫的要用using包起來，只要存取到I/O資源一定要寫馬上釋放資源給下一個人用(一杯飲料和一百杯飲料要買)

            using (GuestBookContext context = new GuestBookContext(serviceProvider.GetRequiredService<DbContextOptions<GuestBookContext>>()))
            {
                //找回刪除的留言
                //context.Book.UpdateRange(
                //    new Book
                //    {
                //        GId= 5,
                //        Title = "三杯鴨",
                //        Description = "鴨肉鮮甜",
                //        Photo = getFileBytes("wwwroot/SeedSourcePhoto/5.jpg"),
                //        ImageType = "image/jpeg",
                //        Author = "Jack",
                //        TimeStamp = DateTime.Now
                //    });

                //context.SaveChanges();



                if (!context.Book.Any()) //如果資料庫沒有任何一筆資料存在，我才建立種子資料
                {

                    context.Book.AddRange(
                     //new Book 
                     //{
                     //    Title = "",
                     //    Description = "",
                     //    ImageType = "",
                     //    Author = "",
                     //    TimeStamp = DateTime.Now
                     //},
                     new Book
                     {
                         Title = "櫻桃鴨",
                         Description = "這看起來好好吃哦!!!",
                         Photo = getFileBytes("wwwroot/SeedSourcePhoto/1.JPG"),
                         ImageType = "image/jpeg",
                         Author = "Jack",
                         TimeStamp = DateTime.Now
                     },
                     new Book
                     {
                         Title = "鴨油高麗菜",
                         Description = "好像稍微有點油....",
                         Photo = getFileBytes("wwwroot/SeedSourcePhoto/2.JPG"),
                         ImageType = "image/jpeg",
                         Author = "Mary",
                         TimeStamp = DateTime.Now
                     },
                      new Book
                      {
                          Title = "鴨油麻婆豆腐",
                          Description = "這太下飯了！可以吃好幾碗白飯",
                          Photo = getFileBytes("wwwroot/SeedSourcePhoto/3.jpg"),
                          ImageType = "image/jpeg",
                          Author = "王小花",
                          TimeStamp = DateTime.Now
                      },
                      new Book
                      {
                          Title = "櫻桃鴨握壽司",
                          Description = "握壽司就是好吃！",
                          Photo = getFileBytes("wwwroot/SeedSourcePhoto/4.jpg"),
                          ImageType = "image/jpeg",
                          Author = "王小花",
                          TimeStamp = DateTime.Now
                      },
                      new Book
                      {
                          Title = "三杯鴨",
                          Description = "鴨肉鮮甜",
                          Photo = getFileBytes("wwwroot/SeedSourcePhoto/5.jpg"),
                          ImageType = "image/jpeg",
                          Author = "Jack",
                          TimeStamp = DateTime.Now
                      });
                    context.SaveChanges();

                    context.ReBook.AddRange(
                     new ReBook
                     {
                         Description = "我也覺得好吃！",
                         Author = "小蘭",
                         TimeStamp = DateTime.Now,
                         GId = 1
                     },
                    new ReBook
                    {
                        Description = "我不喜歡....",
                        Author = "柯南",
                        TimeStamp = DateTime.Now,
                        GId = 1
                    },
                    new ReBook
                    {
                        Description = "你最好餓死",
                        Author = "小蘭",
                        TimeStamp = DateTime.Now,
                        GId = 1
                    },
                    new ReBook
                    {
                        Description = "高麗菜這樣超好吃啊～",
                        Author = "小英",
                        TimeStamp = DateTime.Now,
                        GId = 2
                    },
                    new ReBook
                    {
                        Description = "口味似乎偏辣",
                        Author = "阿狗",
                        TimeStamp = DateTime.Now,
                        GId = 3
                    },
                    new ReBook
                    {
                        Description = "我還是喜歡生魚片的握壽司",
                        Author = "嫩嫩",
                        TimeStamp = DateTime.Now,
                        GId = 4
                    },
                    new ReBook
                    {
                        Description = "我也是喜歡生魚片的握壽司，但這個也不錯",
                        Author = "王小花",
                        TimeStamp = DateTime.Now,
                        GId = 4
                    },
                    new ReBook
                    {
                        Description = "三杯雞比較對味",
                        Author = "芷若",
                        TimeStamp = DateTime.Now,
                        GId = 5
                    });
                    context.SaveChanges();
                }
            }


            //(3)撰寫getFileBytes，功能為將照片轉成二進位資料，靜態方法一定要全部寫在一個家庭裡面
            byte[] getFileBytes(string path)
            {
                FileStream file = new FileStream(path, FileMode.Open);

                byte[] filebytes;

                using (BinaryReader binaryReader = new BinaryReader(file))//二進位讀取器
                {

                    filebytes = binaryReader.ReadBytes((int)file.Length); //檔案大小.長度大小,轉成(int)
                }
                return filebytes;
            }
        }
    }
}


