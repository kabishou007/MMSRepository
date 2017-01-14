using MMS.Models.SysModels;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace MMS.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        
        // 初始化数据库插入数据调用的方法
        protected override void Seed(DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            var users = new List<User>
            {
                new User { Name="管理员",LoginName="admin",WorkNumber="admin",Password="admin"}
            };
            users.ForEach(s => context.Users.AddOrUpdate(u => u.LoginName, s));
            var roles = new List<Role>
            {
                new Role {Name="管理员",Description="系统管理员",Users= users}
            };
            roles.ForEach(s => context.Roles.AddOrUpdate(r => r.Name, s));
            context.SaveChanges();
        }
    }
}
