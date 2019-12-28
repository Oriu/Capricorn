using Capricorn.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Capricorn.Db.SqlServer
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        /// <summary>
        /// 数据库链接配置
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Add - Migration Init  //其中Init是你的版本名称
                //update - database Init //更新数据库操作 init为版本名称
                optionsBuilder.UseSqlServer(Config.Get("ConnectionStrings:BaseDb:ConnectionString"), option => option.UseRowNumberForPaging());
            }
        }

        /// <summary>
        /// 模型创建重载
        /// </summary>
        /// <remarks>
        /// 重载DbContext默认的OnModelCreating方法,使用自定义的方法动态加载实体映射类型
        /// </remarks>
        /// <param name="modelBuilder">模型创建器</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 通过反射获取继承IEntityTypeConfiguration的实体类型
            string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("Capricorn.Db.SqlServer.dll", "Capricorn.Entity.Mapping.dll").Replace("file:///", "");
            Assembly asm = Assembly.LoadFile(assembleFileName);
            var configurationTypes = asm.GetTypes()
                .Where(type => !string.IsNullOrWhiteSpace(type.Namespace))
                .Where(type => type.GetTypeInfo().IsClass)
                .Where(type => type.GetTypeInfo().BaseType != null)
                .Where(type => type.GetInterfaces().Where(o => o.Name == typeof(IEntityTypeConfiguration<>).Name).Count() != 0)
                .ToList();
            // 实例化实体类加入模型创建器
            foreach (var type in configurationTypes)
            {
                dynamic obj = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(obj);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
