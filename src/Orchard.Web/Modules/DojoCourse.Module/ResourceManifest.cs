using Orchard.UI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoCourse.Module
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest
                .DefineStyle("DojoCourse.Module.Dependency")
                .SetUrl("dojocourse-module-dependency.css");

            manifest
                .DefineStyle("DojoCourse.Module.Other")
                .SetUrl("dojocourse-module-other.css")
                .SetDependencies("DojoCourse.Module.Dependency");

            manifest
                .DefineScript("DojoCourse.Module.Filtered")
                .SetUrl("dojocourse-module-filtered")
                .SetDependencies("jQuery");
        }
    }
}