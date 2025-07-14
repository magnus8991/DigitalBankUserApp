using System.Collections.Generic;
using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using UserApp.Models;

namespace UserApp.Data.Repositories;

public class UserRepository
{
    private readonly string _connectionString;

    public UserRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public List<User> GetAll()
    {
        var users = new List<User>();

        using var conn = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand("sp_User_CRUD", conn)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("in_Action", "SELECT");
        cmd.Parameters.AddWithValue("in_Id", DBNull.Value);
        cmd.Parameters.AddWithValue("in_Name", DBNull.Value);
        cmd.Parameters.AddWithValue("in_BirthDate", DBNull.Value);
        cmd.Parameters.AddWithValue("in_Gender", DBNull.Value);

        conn.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            users.Add(new User
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString() ?? "",
                BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                Gender = char.Parse(reader["Gender"].ToString())
            });
        }

        return users;
    }

    public User? GetById(int id)
    {
        using var conn = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand("sp_User_CRUD", conn)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("in_Action", "SELECT_BY_ID");
        cmd.Parameters.AddWithValue("in_Id", id);
        cmd.Parameters.AddWithValue("in_Name", DBNull.Value);
        cmd.Parameters.AddWithValue("in_BirthDate", DBNull.Value);
        cmd.Parameters.AddWithValue("in_Gender", DBNull.Value);

        conn.Open();
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new User
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString() ?? "",
                BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                Gender = char.Parse(reader["Gender"].ToString())
            };
        }

        return null;
    }

    public void Insert(User user)
    {
        using var conn = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand("sp_User_CRUD", conn)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("in_Action", "INSERT");
        cmd.Parameters.AddWithValue("in_Id", DBNull.Value);
        cmd.Parameters.AddWithValue("in_Name", user.Name);
        cmd.Parameters.AddWithValue("in_BirthDate", user.BirthDate);
        cmd.Parameters.AddWithValue("in_Gender", user.Gender);

        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void Update(User user)
    {
        using var conn = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand("sp_User_CRUD", conn)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("in_Action", "UPDATE");
        cmd.Parameters.AddWithValue("in_Id", user.Id);
        cmd.Parameters.AddWithValue("in_Name", user.Name);
        cmd.Parameters.AddWithValue("in_BirthDate", user.BirthDate);
        cmd.Parameters.AddWithValue("in_Gender", user.Gender);

        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var conn = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand("sp_User_CRUD", conn)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("in_Action", "DELETE");
        cmd.Parameters.AddWithValue("in_Id", id);
        cmd.Parameters.AddWithValue("in_Name", DBNull.Value);
        cmd.Parameters.AddWithValue("in_BirthDate", DBNull.Value);
        cmd.Parameters.AddWithValue("in_Gender", DBNull.Value);

        conn.Open();
        cmd.ExecuteNonQuery();
    }
}