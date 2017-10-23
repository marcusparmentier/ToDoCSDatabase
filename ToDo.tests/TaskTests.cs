using MIcrosoft.VisualStudio.TestTools.UnitTesting;
using ToDo.Models;

namespace ToDo.Tests
{
  [TestClass]
  public class TaskTests : IDisposable
  {
    public void Dispose()
    {
      Task.DeleteAll();
    }
    public TaskTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;port=3306;database=todo_test;";
    }
  }

  [TestMethod]
  public void GetAll_DatabaseEmptyAtFirst_0()
  {
    // Arrange, act
    int result = Task.GetAll().Count;

    // Assert
    Assert.AreEqual(0, result);
  }
}
