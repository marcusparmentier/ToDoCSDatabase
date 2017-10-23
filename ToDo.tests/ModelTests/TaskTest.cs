using System;

[TestClass]
public class TaskTest : TDisposable
{
  public void Dispose()
  {
    Task.ClearAll();
  }
}
