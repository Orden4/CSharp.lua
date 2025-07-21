using System.Collections.Generic;
using System.IO;

namespace CSharpLua.CoreSystem {
  public static class CoreSystemProvider {
    private const string CoreSystemDirectory = @".\CoreSystem";

    public static IEnumerable<string> GetCoreSystemFiles(Wc3Api wc3Api = Wc3Api.War3Api, string coreSystemDirectory = null) {
      if (coreSystemDirectory == null)
        coreSystemDirectory = CoreSystemDirectory;

      yield return Path.Combine(coreSystemDirectory, @"Natives.lua");
      yield return Path.Combine(coreSystemDirectory, @"Core.lua");
      yield return Path.Combine(coreSystemDirectory, @"Interfaces.lua");
      yield return Path.Combine(coreSystemDirectory, @"Exception.lua");
      yield return Path.Combine(coreSystemDirectory, @"Number.lua");
      yield return Path.Combine(coreSystemDirectory, @"Char.lua");
      yield return Path.Combine(coreSystemDirectory, @"String.lua");
      yield return Path.Combine(coreSystemDirectory, @"Boolean.lua");
      yield return Path.Combine(coreSystemDirectory, @"Delegate.lua");
      yield return Path.Combine(coreSystemDirectory, @"Enum.lua");
      yield return Path.Combine(coreSystemDirectory, @"TimeSpan.lua");
      yield return Path.Combine(coreSystemDirectory, @"DateTime.lua");
      switch (wc3Api) {
        case Wc3Api.War3Api:
          yield return Path.Combine(coreSystemDirectory, @"Wc3Api\War3Api.lua");
          break;
        case Wc3Api.WCSharp:
          yield return Path.Combine(coreSystemDirectory, @"Wc3Api\WCSharp.lua");
          break;
      }
      yield return Path.Combine(coreSystemDirectory, @"Collections\EqualityComparer.lua");
      yield return Path.Combine(coreSystemDirectory, @"Array.lua");
      yield return Path.Combine(coreSystemDirectory, @"Type.lua");
      yield return Path.Combine(coreSystemDirectory, @"Collections\List.lua");
      yield return Path.Combine(coreSystemDirectory, @"Collections\Dictionary.lua");
      yield return Path.Combine(coreSystemDirectory, @"Collections\Queue.lua");
      yield return Path.Combine(coreSystemDirectory, @"Collections\Stack.lua");
      yield return Path.Combine(coreSystemDirectory, @"Collections\HashSet.lua");
      yield return Path.Combine(coreSystemDirectory, @"Collections\LinkedList.lua");
      yield return Path.Combine(coreSystemDirectory, @"Collections\Linq.lua");
      yield return Path.Combine(coreSystemDirectory, @"Collections\SortedSet.lua");
      yield return Path.Combine(coreSystemDirectory, @"Collections\SortedList.lua");
      yield return Path.Combine(coreSystemDirectory, @"Collections\SortedDictionary.lua");
      yield return Path.Combine(coreSystemDirectory, @"Collections\PriorityQueue.lua");
      yield return Path.Combine(coreSystemDirectory, @"Convert.lua");
      yield return Path.Combine(coreSystemDirectory, @"Math.lua");
      yield return Path.Combine(coreSystemDirectory, @"Random.lua");
      yield return Path.Combine(coreSystemDirectory, @"Text\StringBuilder.lua");
      yield return Path.Combine(coreSystemDirectory, @"Console.lua");
      yield return Path.Combine(coreSystemDirectory, @"IO\File.lua");
      yield return Path.Combine(coreSystemDirectory, @"Reflection\Assembly.lua");
      yield return Path.Combine(coreSystemDirectory, @"Threading\Timer.lua");
      yield return Path.Combine(coreSystemDirectory, @"Threading\Thread.lua");
      yield return Path.Combine(coreSystemDirectory, @"Threading\Task.lua");
      yield return Path.Combine(coreSystemDirectory, @"Utilities.lua");
      yield return Path.Combine(coreSystemDirectory, @"Globalization\Globalization.lua");
      yield return Path.Combine(coreSystemDirectory, @"Numerics\HashCodeHelper.lua");
      yield return Path.Combine(coreSystemDirectory, @"Numerics\Complex.lua");
      yield return Path.Combine(coreSystemDirectory, @"Numerics\Vector2.lua");
      yield return Path.Combine(coreSystemDirectory, @"Numerics\Vector3.lua");
      yield return Path.Combine(coreSystemDirectory, @"Numerics\Vector4.lua");
      yield return Path.Combine(coreSystemDirectory, @"Numerics\Matrix3x2.lua");
      yield return Path.Combine(coreSystemDirectory, @"Numerics\Matrix4x4.lua");
      yield return Path.Combine(coreSystemDirectory, @"Numerics\Plane.lua");
      yield return Path.Combine(coreSystemDirectory, @"Numerics\Quaternion.lua");
    }
  }
}
