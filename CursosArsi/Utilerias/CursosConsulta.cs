using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using AdmServer.Utilerias;
using Librerias;
using CursosArsi.Models;



namespace CursosArsi.Utilerias
{
    public class CursosConsulta
    {

        public IEnumerable<Cursos>ListadoCursos()
        {
              Configuracion iniConfig = new Configuracion();
            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };
            
            List<Cursos> lista = new List<Cursos>();
            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_obtiene_datos_Curso1", clsBD.Conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                  
                        MySqlDataReader lector = cmd.ExecuteReader();
                        while (lector.Read())
                        {
                            Cursos modelo = new Cursos()
                            {
                                Id_producto = int.Parse(lector[0] + ""),
                                descripcion_producto = lector[1] + "",
                                marca = lector[2] + ""

                            };
                            lista.Add(modelo);
                          
                        }
                    }
                }
                return (lista);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            finally
            {
                clsBD.CerrarConexion();
            }

            return (lista);
        }
        public IEnumerable<Modulos> ListadoModulos(int id )
        {
            Configuracion iniConfig = new Configuracion();
            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };

            List<Modulos> lista = new List<Modulos>();
            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_obtiene_datos_modulo", clsBD.Conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_id_producto", id);

                        MySqlDataReader lector = cmd.ExecuteReader();
                        while (lector.Read())
                        {
                            Modulos modelo = new Modulos()
                            {
                                id_modulo = int.Parse(lector[0] + ""),
                                descripcion_modulo = lector[1] + "",
                                url_modulo = lector[2] + ""

                            };
                            lista.Add(modelo);

                        }
                    }
                }
                return (lista);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            finally
            {
                clsBD.CerrarConexion();
            }

            return (lista);
        }
        public IEnumerable<Temas> ListadoTemas(int id)
        {
            Configuracion iniConfig = new Configuracion();
            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };

            List<Temas> lista = new List<Temas>();
            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_obtiene_datos_tema", clsBD.Conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_id_modulo", id);

                        MySqlDataReader lector = cmd.ExecuteReader();
                        while (lector.Read())
                        {
                            Temas modelo = new Temas()
                            {
                                id_tema = int.Parse(lector[0] + ""),
                                descripcion_tema = lector[1] + "",
                                url_tema = lector[2] + ""

                            };
                            lista.Add(modelo);

                        }
                    }
                }
                return (lista);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            finally
            {
                clsBD.CerrarConexion();
            }

            return (lista);
        }
        public IEnumerable<Subtemas> ListadoSubTemas(int id)
        {
            Configuracion iniConfig = new Configuracion();
            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };

            List<Subtemas> lista = new List<Subtemas>();
            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_obtiene_datos_subtema", clsBD.Conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_id_tema", id);

                        MySqlDataReader lector = cmd.ExecuteReader();
                        while (lector.Read())
                        {
                            Subtemas modelo = new Subtemas()
                            {
                                id_subtema = int.Parse(lector[0] + ""),
                                descripcion_subtema = lector[1] + "",
                                url_subtema = lector[2] + ""

                            };
                            lista.Add(modelo);

                        }
                    }
                }
                return (lista);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            finally
            {
                clsBD.CerrarConexion();
            }

            return (lista);
        }

        public Modulos ConsultaModulos(int id, string letra)
        {
            Configuracion iniConfig = new Configuracion();
            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };

            Modulos modelo = null;

            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_visualizarModulosTemasSubtemas", clsBD.Conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_id", id);
                        cmd.Parameters.AddWithValue("@i_opcion", letra);

                        MySqlDataReader lector = cmd.ExecuteReader();
                        lector.Read();
                            modelo = new Modulos()
                            {
                                id_modulo = int.Parse(lector[0] + ""),
                                descripcion_modulo = lector[1] + "",
                                url_modulo = lector[2] + ""

                            };
                        }
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            finally
            {
                clsBD.CerrarConexion();
            }

            return (modelo);
        }
        public Temas ConsultaTemas(int id, string letra)
        {
            Configuracion iniConfig = new Configuracion();
            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };

            Temas modelo = null;

            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_visualizarModulosTemasSubtemas", clsBD.Conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_id", id);
                        cmd.Parameters.AddWithValue("@i_opcion", letra);

                        MySqlDataReader lector = cmd.ExecuteReader();
                        lector.Read();
                        modelo = new Temas()
                        {
                            id_tema = int.Parse(lector[0] + ""),
                            descripcion_tema = lector[1] + "",
                            url_tema = lector[2] + ""

                        };
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            finally
            {
                clsBD.CerrarConexion();
            }

            return (modelo);
        }

        public Subtemas ConsultaSubtemas(int id, string letra)
        {
            Configuracion iniConfig = new Configuracion();
            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };

            Subtemas modelo = null;

            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_visualizarModulosTemasSubtemas", clsBD.Conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_id", id);
                        cmd.Parameters.AddWithValue("@i_opcion", letra);

                        MySqlDataReader lector = cmd.ExecuteReader();
                        lector.Read();
                        modelo = new Subtemas()
                        {
                            id_subtema = int.Parse(lector[0] + ""),
                            descripcion_subtema = lector[1] + "",
                            url_subtema = lector[2] + ""

                        };
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            finally
            {
                clsBD.CerrarConexion();
            }

            return (modelo);
        }
    }
}