#if false
using Microsoft.Build.Definition;
using Microsoft.Build.Evaluation;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSharpLua {
  public static class MSBuildHelper {
    public static void SetMsBuildExePath() {
      var dotnetListSdksProcessInfo = new ProcessStartInfo {
        CreateNoWindow = true,
        RedirectStandardOutput = true,
        FileName = "dotnet",
        Arguments = "--list-sdks",
      };

      using var dotnetListSdksProcess = Process.Start(dotnetListSdksProcessInfo);
      dotnetListSdksProcess.WaitForExit();

      var output = dotnetListSdksProcess.StandardOutput.ReadToEnd();
      var sdkPaths = Regex.Matches(output, "([0-9]+.[0-9]+.[0-9]+) \\[(.*)\\]")
        .OfType<Match>()
        .Select(m => Path.Combine(m.Groups[2].Value, m.Groups[1].Value, "MSBuild.dll"));

      var sdkPath = sdkPaths.Last();
      Environment.SetEnvironmentVariable("MSBUILD_EXE_PATH", sdkPath);
    }

    public static IEnumerable<Project> FindProjects(Project mainProject, ProjectOptions options) {
      var result = new Dictionary<string, Project>(StringComparer.OrdinalIgnoreCase);
      var uncheckedProjects = new Queue<Project>();
      uncheckedProjects.Enqueue(mainProject);

      while (uncheckedProjects.TryDequeue(out var project)) {
        result.Add(project.FullPath, project);
        foreach (var projectReference in project.GetItems("ProjectReference")) {
          var projectReferencePath = Path.GetFullPath(Path.Combine(project.DirectoryPath, projectReference.EvaluatedInclude));
          if (result.ContainsKey(projectReferencePath)) {
            continue;
          }
          uncheckedProjects.Enqueue(Project.FromFile(projectReferencePath, options));
        }
      }

      return result.Values;
    }

    public static IEnumerable<PackageReferenceModel> FindPackages(string targetFrameworkVersion, IEnumerable<Project> projects) {
      var packageReferences = projects.SelectMany(project => project.GetItems("PackageReference").Select(packageReference =>
        (packageReference.EvaluatedInclude,
        VersionRange.Parse(packageReference.Metadata.Single(metadata => string.Equals(metadata.Name, "Version", StringComparison.Ordinal)).EvaluatedValue))));

      return PackageHelper.EnumeratePackages(targetFrameworkVersion, packageReferences);
    }

    public static IEnumerable<string> GetCompileFiles(IEnumerable<Project> projects) {
      throw new NotImplementedException();
    }
  }
}
#endif
