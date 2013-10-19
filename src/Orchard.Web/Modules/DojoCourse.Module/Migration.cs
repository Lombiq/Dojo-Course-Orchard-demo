using DojoCourse.Module.Models;
using Orchard.Data.Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoCourse.Module
{
    public class Migration : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable(typeof(PersonRecord).Name,
                table => table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<string>("Name", column => column.WithLength(100))
                    .Column<string>("Sex")
                    .Column<DateTime>("BirthDateUtc")
                    .Column<string>("Biography", column => column.Unlimited())
                )
            .AlterTable(typeof(PersonRecord).Name,
                table => table
                    .CreateIndex("Name", new string[] { "Name" })
                );

            return 1;
        }
    }
}