using System;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;
using DojoCourse.Module.Models;


namespace DojoCourse.Module
{
    [OrchardFeature("DojoCourse.Module.Contents")]
    public class ContentMigrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable(typeof(PersonListPartRecord).Name,
                table => table
                    .ContentPartRecord()
                    .Column<int>("MaxCount")
                );

            ContentDefinitionManager.AlterPartDefinition(typeof(PersonListPart).Name,
                part => part.Attachable());

            ContentDefinitionManager.AlterTypeDefinition("PersonList",
                cfg => cfg
                    .WithPart(typeof(PersonListPart).Name)
                    .WithPart("CommonPart")
                    .WithPart("TitlePart")
                    .Creatable()
                    .Draftable());


            return 2;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterPartDefinition(typeof(PersonListPart).Name,
                part => part.Attachable());

            ContentDefinitionManager.AlterTypeDefinition("PersonList",
                cfg => cfg
                    .WithPart(typeof(PersonListPart).Name)
                    .WithPart("CommonPart")
                    .WithPart("TitlePart")
                    .Creatable()
                    .Draftable());


            return 2;
        }
    }
}