namespace CustomAttributes
{
    using System;

    // Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods
    // and holds a version in the format major.minor (e.g. 2.11).
    // Apply the version attribute to a sample class and display its version at runtime.
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method)]
    public class VersionAttribute : System.Attribute
    {
        public VersionAttribute(int major, int minor)
        {
            this.VersionMajor = major;
            this.VersionMinor = minor;
        }

        public int VersionMajor { get; private set; }

        public int VersionMinor { get; private set; }

        public string Version
        {
            get
            {
                return string.Format("{0}.{1:00}", this.VersionMajor, this.VersionMinor);
            }
        }
    }
}