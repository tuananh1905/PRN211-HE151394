using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BusinessObject;
using DataAccess.Repository;
using System.Configuration;
using System.IO;

namespace MyStoreWinApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            MemberObject admin = new MemberObject
            {
                MemberID = int.Parse(Convert.ToString(config["MemberID"])),
                MemberName = config["MemberName"],
                Email = config["Email"],
                Password = config["Password"],
                City = config["City"],
                Country = config["Country"]
            };
            IMemberRepository MemberRepository = new MemberRepository();
            MemberRepository.InsertMember(admin);
            Application.Run(new frmLogin());
        }
    }
    
}
