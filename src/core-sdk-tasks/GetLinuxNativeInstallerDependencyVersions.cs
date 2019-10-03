using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Newtonsoft.Json.Linq;

namespace Microsoft.DotNet.Cli.Build
{
    public class GetRuntimePackRids : Task
    {
        [Required]
        public string PackageVersion { get; set; }

        [Output]
        public string MajorMinorVersion { get; }

        [Output]
        public string MajorMinorPatchVersion { get; }

        [Output]
        public string VersionWithTilde { get; }

        public override bool Execute()
        {
            string[] dotSplit = PackageVersion.Split('.');
            MajorMinorVersion = dotSplit[0] + "." + dotSplit[1];

            string[] prereleaseSplit = PackageVersion.Split('-', count: 2);
            MajorMinorPatchVersion = prereleaseSplit[0];            
            VersionWithTilde = MajorMinorPatchVersion + prereleaseSplit.Length > 1 ? "~" + prereleaseSplit[1] : "";

            return true;
        }
    }
}
