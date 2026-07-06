using System.Reflection;

namespace OpsDesk.Shared;

public static class SharedAssemblyReference
{
    public static readonly Assembly Assembly = typeof(SharedAssemblyReference).Assembly;
}
