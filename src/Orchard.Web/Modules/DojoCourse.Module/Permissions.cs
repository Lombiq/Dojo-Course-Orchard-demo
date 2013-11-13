using Orchard.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Environment.Extensions.Models;
using Orchard.Environment.Extensions;

namespace DojoCourse.Module
{
    [OrchardFeature("DojoCourse.Module.Contents")]
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission EditPersonList = new Permission { Description = "Edit Person List items", Name = "EditPersonList" };
        public static readonly Permission AccessPersonListDashboard = new Permission { Description = "Access the Person List dashboard", Name = "AccessPersonListDashboard", ImpliedBy = new[] { EditPersonList } };

        public virtual Feature Feature { get; set; }

        public IEnumerable<Permission> GetPermissions()
        {
            return new[]
            {
                EditPersonList,
                AccessPersonListDashboard
            };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { EditPersonList }
                },
                new PermissionStereotype
                {
                    Name = "Editor",
                    Permissions = new[] { AccessPersonListDashboard }
                }
            };
        }
    }
}