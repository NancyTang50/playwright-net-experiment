using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace playwright.net.experiment.tests.Extensions;

internal class NameAttribute : NUnitAttribute, IApplyToTest
{
    public string Name { get; set; }

    public string Description { get; set; }

    public NameAttribute(string name, string description) {
        Name = name;
        Description = description;
    }

    public void ApplyToTest(Test test)
    {
        test.Properties.Add("Name", Name);
        test.Properties.Add("Description", Description);
    }
}
