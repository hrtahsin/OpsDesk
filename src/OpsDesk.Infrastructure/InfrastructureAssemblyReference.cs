using System.Reflection;

namespace OpsDesk.Infrastructure;

public static class InfrastructureAssemblyReference
{
    public static readonly Assembly Assembly = typeof(InfrastructureAssemblyReference).Assembly;
}
