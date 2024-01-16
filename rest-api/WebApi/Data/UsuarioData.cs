using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data
{
    public class UsuarioData
    {
        public static bool Login(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Login", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;  
                cmd.Parameters.AddWithValue("@correo", oUsuario.correo);
                cmd.Parameters.AddWithValue("@password", oUsuario.password);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Agregar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand(" sp_CreateEmpleado", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombres", oUsuario.Nombes);
                cmd.Parameters.AddWithValue("@Apellidos", oUsuario.apellidos);
                cmd.Parameters.AddWithValue("@Dpi", oUsuario.DPI);
                cmd.Parameters.AddWithValue("@FechaNacimiento", oUsuario.fechaNacimiento);
                cmd.Parameters.AddWithValue("@Sexo", oUsuario.sexo);
                cmd.Parameters.AddWithValue("@FechaIngreso", oUsuario.fechaIngreso);
                cmd.Parameters.AddWithValue("@Direccion", oUsuario.direccion);
                cmd.Parameters.AddWithValue("@Nit", oUsuario.NIT)
                cmd.Parameters.AddWithValue("@CodigoDepartamento", oUsuario.codigoDepartamento);
                cmd.Parameters.AddWithValue("@CodigoEmpleadoGenerated", oUsuario.codigoEmpleadoGenerated);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand(" sp_CreateEmpleado", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoEmpleado", oUsuario.codigoEmpleado);
                cmd.Parameters.AddWithValue("@nombres", oUsuario.nombes);
                cmd.Parameters.AddWithValue("@Apellidos", oUsuario.apellidos);
                cmd.Parameters.AddWithValue("@Dpi", oUsuario.DPI);
                cmd.Parameters.AddWithValue("@FechaNacimiento", oUsuario.fechaNacimiento);
                cmd.Parameters.AddWithValue("@Sexo", oUsuario.sexo);
                cmd.Parameters.AddWithValue("@FechaIngreso", oUsuario.fechaIngreso);
                cmd.Parameters.AddWithValue("@Direccion", oUsuario.direccion);
                cmd.Parameters.AddWithValue("@Nit", oUsuario.NIT)
                cmd.Parameters.AddWithValue("@CodigoDepartamento", oUsuario.codigoDepartamento);
                cmd.Parameters.AddWithValue("@CodigoEmpleadoGenerated", oUsuario.codigoEmpleadoGenerated);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Usuario> Listar()
        {
            List<Usuario> oListaUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarEmpleados", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        
                        while (dr.Read())
                        {
                            oListaUsuario.Add(new Usuario()
                            {
                                CodigoEmpleado = Convert.ToInt32(dr["codigoEmpleado"]),
                                DPI = dr["DPI"].ToString(),
                                Nombres = dr["nombres"].ToString(),
                                Apellidos = dr["apellidos"].ToString(),
                                Correo = dr["correo"].ToString(),
                                Password = dr["password"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"]),
                                Sexo = Convert.ToChar(dr["sexo"]),
                                FechaIngreso = Convert.ToDateTime(dr["fechaIngreso"]),
                                Direccion = dr["direccion"].ToString(),
                                NIT = dr["NIT"].ToString(),
                                CodigoDepartamento = Convert.ToInt32(dr["codigoDepartamento"]),
                                Rol = dr["rol"].ToString(),
                                Edad = Convert.ToInt32(dr["edad"]) 
                            });

                        }

                    }



                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    return oListaUsuario;
                }
            }
        }

        public static Usuario Obtener(int idusuario)
        {
            Usuario oUsuario = new Usuario();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_GetEmpleadoByCodigo", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigoEmpleado", codigoEmpleado);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oUsuario = new Usuario()
                            {
                                CodigoEmpleado = Convert.ToInt32(dr["codigoEmpleado"]),
                                DPI = dr["DPI"].ToString(),
                                Nombres = dr["nombres"].ToString(),
                                Apellidos = dr["apellidos"].ToString(),
                                Correo = dr["correo"].ToString(),
                                Password = dr["password"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"]),
                                Sexo = Convert.ToChar(dr["sexo"]),
                                FechaIngreso = Convert.ToDateTime(dr["fechaIngreso"]),
                                Direccion = dr["direccion"].ToString(),
                                NIT = dr["NIT"].ToString(),
                                CodigoDepartamento = Convert.ToInt32(dr["codigoDepartamento"]),
                                Rol = dr["rol"].ToString(),
                                Edad = Convert.ToInt32(dr["edad"])
                            };
                        }

                    }



                    return oUsuario;
                }
                catch (Exception ex)
                {
                    return oUsuario;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateEmpleado", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigoEmpleado", codigoEmpleado);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }
}