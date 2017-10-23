using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ToDo;
using System;

namespace ToDo.Models
{
  public class Task
  {
    private int _id;
    private string _description;

    public Task(string Description, int Id = 0)
    {
      _id = Id;
      _description = Description;

      // Getters and Setters

      public static List<Task> GetAll()
      {
        List<Task> allTasks = new List<Task> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand
        cmd.CommandText = @"SELECT * FROM tasks;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int taskId = rdr.GetInt32(0);
          string taskDescription = rdr.GetString(1);
          Task newTask = new Task(taskDescription, taskId);
          allTasks.Add(newTask);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allTasks;
      }
    }
  }
}
