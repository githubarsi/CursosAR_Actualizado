using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CursosArsi.Models;
using MySql.Data.MySqlClient;
using AdmServer.Utilerias;
using Librerias;
using System.Data;

namespace CursosArsi.Utilerias
{
    public class IngresarDatosCurso
    {
        public int  Guardar(Modulos modelo, int id_curso)
        {
            Configuracion iniConfig = new Configuracion();
            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };
            int respuesta = 20;
            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("realiza_crud_modulos", clsBD.Conexion))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_id_modulo", 0);
                        cmd.Parameters.AddWithValue("@i_opcion", "I");
                        cmd.Parameters.AddWithValue("@i_descripcion_modulo", modelo.descripcion_modulo);
                        cmd.Parameters.AddWithValue("@i_url_modulo", modelo.url_modulo);
                        cmd.Parameters.AddWithValue("@i_id_producto", id_curso);

                        MySqlParameter respuestaSP = new MySqlParameter("@o_respuesta", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output,
                        };
                        cmd.Parameters.Add(respuestaSP);
                        cmd.ExecuteNonQuery();

                        respuesta = (int)cmd.Parameters["@o_respuesta"].Value;



                    }

                }
                return respuesta;
            }

            catch (Exception e)
            {
                return -2;
            }
            finally
            {
                clsBD.CerrarConexion();
            }

            return respuesta;
        }
        public int GuardarTemas(Temas modelo, int id_modelo)
        {
            Configuracion iniConfig = new Configuracion();
            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };
            int respuesta = 20;
            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_realiza_crud_temas", clsBD.Conexion))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_id_tema", 0);
                        cmd.Parameters.AddWithValue("@i_opcion", "I");
                        cmd.Parameters.AddWithValue("@i_descripcion_tema", modelo.descripcion_tema);
                        cmd.Parameters.AddWithValue("@i_url_tema", modelo.url_tema);
                        cmd.Parameters.AddWithValue("@i_id_modulo", id_modelo);

                        MySqlParameter respuestaSP = new MySqlParameter("@o_respuesta", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output,
                        };
                        cmd.Parameters.Add(respuestaSP);
                        cmd.ExecuteNonQuery();

                        respuesta = (int)cmd.Parameters["@o_respuesta"].Value;



                    }

                }
                return respuesta;
            }

            catch (Exception e)
            {
                return -2;
            }
            finally
            {
                clsBD.CerrarConexion();
            }

            return respuesta;
        }
        public int GuardarSubTemas(Subtemas modelo, int id_tema)
        {
            Configuracion iniConfig = new Configuracion();
            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };
            int respuesta = 20;
            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_realiza_crud_subtemas", clsBD.Conexion))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_id_subtema", 0);
                        cmd.Parameters.AddWithValue("@i_opcion", "I");
                        cmd.Parameters.AddWithValue("@i_descripcion_subtema", modelo.descripcion_subtema);
                        cmd.Parameters.AddWithValue("@i_url_subtema", modelo.url_subtema);
                        cmd.Parameters.AddWithValue("@i_id_tema", id_tema);

                        MySqlParameter respuestaSP = new MySqlParameter("@o_respuesta", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output,
                        };
                        cmd.Parameters.Add(respuestaSP);
                        cmd.ExecuteNonQuery();

                        respuesta = (int)cmd.Parameters["@o_respuesta"].Value;



                    }

                }
                return respuesta;
            }

            catch (Exception e)
            {
                return -2;
            }
            finally
            {
                clsBD.CerrarConexion();
            }

            return respuesta;
        }
        public int EditarModulos(Modulos datosModulo)
        {
            Configuracion iniConfig = new Configuracion();
            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };
            int respuesta = 20;
            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("realiza_crud_modulos", clsBD.Conexion))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_id_modulo", datosModulo.id_modulo);
                        cmd.Parameters.AddWithValue("@i_opcion", "U");
                        cmd.Parameters.AddWithValue("@i_descripcion_modulo", datosModulo.descripcion_modulo);
                        cmd.Parameters.AddWithValue("@i_url_modulo", datosModulo.url_modulo);
                        cmd.Parameters.AddWithValue("@i_id_producto", 0);

                        MySqlParameter respuestaSP = new MySqlParameter("@o_respuesta", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output,
                        };
                        cmd.Parameters.Add(respuestaSP);
                        cmd.ExecuteNonQuery();

                        respuesta = (int)cmd.Parameters["@o_respuesta"].Value;



                    }

                }
                return respuesta;
            }

            catch (Exception e)
            {
                return -2;
            }
            finally
            {
                clsBD.CerrarConexion();
            }

            return respuesta;
        }

        public int EditarTemas(Temas datosTema)
        {
            
                Configuracion iniConfig = new Configuracion();
                AdministradorBD clsBD = new AdministradorBD
                {
                    RutaConfig = iniConfig.ReturnIni(),
                };
                int respuesta = 20;
                try
                {
                    if (clsBD.AbrirConexion())
                    {
                        using (MySqlCommand cmd = new MySqlCommand("sp_realiza_crud_temas", clsBD.Conexion))
                        {

                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@i_id_tema",datosTema.id_tema);
                            cmd.Parameters.AddWithValue("@i_opcion", "U");
                            cmd.Parameters.AddWithValue("@i_descripcion_tema", datosTema.descripcion_tema);
                            cmd.Parameters.AddWithValue("@i_url_tema", datosTema.url_tema);
                            cmd.Parameters.AddWithValue("@i_id_modulo",0);

                            MySqlParameter respuestaSP = new MySqlParameter("@o_respuesta", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output,
                            };
                            cmd.Parameters.Add(respuestaSP);
                            cmd.ExecuteNonQuery();

                            respuesta = (int)cmd.Parameters["@o_respuesta"].Value;



                        }

                    }
                    return respuesta;
                }

                catch (Exception e)
                {
                    return -2;
                }
                finally
                {
                    clsBD.CerrarConexion();
                }

                return respuesta;
            }
        public int EditarSubTemas(Subtemas datosSubtema)
        {

            Configuracion iniConfig = new Configuracion();
            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };
            int respuesta = 20;
            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_realiza_crud_subtemas", clsBD.Conexion))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_id_subtema", datosSubtema.id_subtema);
                        cmd.Parameters.AddWithValue("@i_opcion", "U");
                        cmd.Parameters.AddWithValue("@i_descripcion_subtema", datosSubtema.descripcion_subtema);
                        cmd.Parameters.AddWithValue("@i_url_subtema", datosSubtema.url_subtema);
                        cmd.Parameters.AddWithValue("@i_id_tema", 0);

                        MySqlParameter respuestaSP = new MySqlParameter("@o_respuesta", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output,
                        };
                        cmd.Parameters.Add(respuestaSP);
                        cmd.ExecuteNonQuery();

                        respuesta = (int)cmd.Parameters["@o_respuesta"].Value;



                    }

                }
                return respuesta;
            }

            catch (Exception e)
            {
                return -2;
            }
            finally
            {
                clsBD.CerrarConexion();
            }

            return respuesta;
        }
        public int ElminarMTS(int id, string letra)
        {
            Configuracion iniConfig = new Configuracion();
            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };
            int respuesta = 20;
           

            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_elimarModulosTemasSubtemas", clsBD.Conexion))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_id", id);
                        cmd.Parameters.AddWithValue("@i_opcion",letra);
                        

                        MySqlParameter respuestaSP = new MySqlParameter("@o_respuesta", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output,
                        };
                        cmd.Parameters.Add(respuestaSP);
                        cmd.ExecuteNonQuery();

                        respuesta = (int)cmd.Parameters["@o_respuesta"].Value;



                    }

                }
                return respuesta;
            }

            catch (Exception e)
            {
                return -2;
            }
            finally
            {
                clsBD.CerrarConexion();
            }

            return respuesta;
        }

    }
}

