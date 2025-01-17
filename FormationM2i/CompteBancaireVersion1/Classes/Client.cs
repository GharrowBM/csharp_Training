﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CompteBancaireVersion1.Classes
{
    internal class Client
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;
        public static string request;
        public static SqlCommand command;
        public static SqlConnection connection;

        public int Id { get { return id; } }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }

        public Client(string nom, string prenom, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
        }

        public Client()
        {

        }

        public override string ToString()
        {
            return $"Client : {Nom} {Prenom}, Tel : {Telephone}";
        }

        public static Client GetClientFromAccountID(int id)
        {
            Client client = default(Client);
            connection = DB.Connection;
            request = "SELECT * FROM clients WHERE id = @id;";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                client = new Client()
                {
                    id = reader.GetInt32(0),
                    nom = reader.GetString(1),
                    prenom = reader.GetString(2),
                    telephone = reader.GetString(3)
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();

            return client;
        }

        public static bool ClientExist(string telephone)
        {
            bool exist = false;
            request = "SELECT count(*) from clients where telephone=@telephone";
            connection = DB.Connection;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@telephone", telephone));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                exist = reader.GetInt32(0) > 0;
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return exist;
        }

        public bool Save()
        {

            connection = DB.Connection;
            request = "INSERT INTO clients (nom, prenom, telephone) OUTPUT INSERTED.ID VALUES (@nom, @prenom, @telephone);";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            command.Parameters.Add(new SqlParameter("@prenom", prenom));
            command.Parameters.Add(new SqlParameter("@telephone", telephone));
            connection.Open();
            id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return id > 0;
        }
    }
}
