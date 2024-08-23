using NUnit.Framework;
using static PermissionSystem.Model;
using PermissionSystem;


public class PermissionSystemTests
{
    private Service _Service;

    [SetUp]
    public void Setup()
    {
        _Service = new Service();
    }

    [Test]
    public void GrantPermission_ShouldAssignCorrectRoleToUser()
    {
        // Arrange
        var user = new User("admin");
        var folder = new Folder("RootFolder");

        // Act
        _Service.GrantPermission(user, folder, "Admin");

        // Assert
        Assert.AreEqual("Admin", folder.Permissions[user.Username]);
    }

    [TestCase("Admin", "read", true)]
    [TestCase("Admin", "write", true)]
    [TestCase("Admin", "delete", true)]
    [TestCase("Contributor", "read", true)]
    [TestCase("Contributor", "write", true)]
    [TestCase("Contributor", "delete", false)]
    [TestCase("Reader", "read", true)]
    [TestCase("Reader", "write", false)]
    [TestCase("Reader", "delete", false)]
    public void HasPermission_ShouldReturnCorrectPermissionBasedOnRole(string role, string action, bool expectedResult)
    {
        // Arrange
        var user = new User("testuser");
        var folder = new Folder("TestFolder");

        _Service.GrantPermission(user, folder, role);

        // Act
        var hasPermission = _Service.HasPermission(user, folder, action);

        // Assert
        Assert.AreEqual(expectedResult, hasPermission);
    }

    [Test]
    public void HasPermission_ShouldReturnFalseForUnknownUser()
    {
        // Arrange
        var knownUser = new User("knownuser");
        var unknownUser = new User("unknownuser");
        var folder = new Folder("TestFolder");

        _Service.GrantPermission(knownUser, folder, "Admin");

        // Act
        var hasPermission = _Service.HasPermission(unknownUser, folder, "read");

        // Assert
        Assert.IsFalse(hasPermission);
    }

    [Test]
    public void HasPermission_ShouldReturnFalseForUnknownFolder()
    {
        // Arrange
        var user = new User("testuser");
        var knownFolder = new Folder("KnownFolder");
        var unknownFolder = new Folder("UnknownFolder");

        _Service.GrantPermission(user, knownFolder, "Admin");

        // Act
        var hasPermission = _Service.HasPermission(user, unknownFolder, "read");

        // Assert
        Assert.IsFalse(hasPermission);
    }
}
