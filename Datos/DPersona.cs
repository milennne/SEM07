using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Microsoft.Data.SqlClient;

namespace Datos
{
    public class DPersona
    {
        private readonly Conexion conexion = new Conexion();

        public List<Persona> Listar()
        {
            List<Persona> lista = new List<Persona>();

            try
            {
                using SqlConnection connection = conexion.ObtenerConexion();
                connection.Open();

                using SqlCommand cmd = new SqlCommand("USP_ListarPersonas", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Persona
                    {
                        IdPersona = Convert.ToInt32(dr["IdPersona"]),
                        Nombres = dr["Nombres"].ToString() ?? string.Empty,
                        Apellidos = dr["Apellidos"].ToString() ?? string.Empty,
                        Dni = dr["Dni"].ToString() ?? string.Empty,
                        Telefono = dr["Telefono"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar personas: " + ex.Message);
            }

            return lista;
        }

        public void Crear(Persona persona)
        {
            try
            {
                using SqlConnection connection = conexion.ObtenerConexion();
                connection.Open();

                using SqlCommand cmd = new SqlCommand("USP_InsPersona", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombres", persona.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                cmd.Parameters.AddWithValue("@Dni", persona.Dni);
                cmd.Parameters.AddWithValue("@Telefono", (object?)persona.Telefono ?? DBNull.Value);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear persona: " + ex.Message);
            }
        }

        public void Actualizar(Persona persona)
        {
            try
            {
                using SqlConnection connection = conexion.ObtenerConexion();
                connection.Open();

                using SqlCommand cmd = new SqlCommand("USP_UpdPersona", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdPersona", persona.IdPersona);
                cmd.Parameters.AddWithValue("@Nombres", persona.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                cmd.Parameters.AddWithValue("@Dni", persona.Dni);
                cmd.Parameters.AddWithValue("@Telefono", (object?)persona.Telefono ?? DBNull.Value);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar persona: " + ex.Message);
            }
        }

        public void Eliminar(int idPersona)
        {
            try
            {
                using SqlConnection connection = conexion.ObtenerConexion();
                connection.Open();

                using SqlCommand cmd = new SqlCommand("USP_DelPersonaLogico", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdPersona", idPersona);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar persona: " + ex.Message);
            }
        }
    }
}