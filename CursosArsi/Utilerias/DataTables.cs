using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Librerias;
using MySql.Data.MySqlClient;
namespace AdmServer.Utilerias
{
    public class DataTables
    {
        public DataTable ListaTipoEmpresas(int categoriaEmpresa)
        {
            DataTable dt = new DataTable();
            Configuracion iniConfig = new Configuracion();
            RegistraLog regLog = new RegistraLog();

            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };

            try
            {
                if (clsBD.AbrirConexion())
                {
                    string strComan = "SELECT id_tipo_empresa, descripcion_te FROM tipo_empresa WHERE id_categoria_emp = " + categoriaEmpresa.ToString();
                    using (MySqlCommand cmd = new MySqlCommand(strComan, clsBD.Conexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        clsBD.CerrarConexion();
                    }
                }
            }
            catch (Exception e)
            {
                string mensaje = string.Format("No se pudo obtener el listado de las empresas", "Lista de empresas");
                regLog.Guardar("Lista de empresas", mensaje);
                regLog.Guardar("Lista de empresas", e.Message);
            }

            return dt;
        }

        public DataTable ListaCursos(int idUsuario)
        {
            DataTable dt = new DataTable();
            Configuracion iniConfig = new Configuracion();
            RegistraLog regLog = new RegistraLog();

            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };

            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_obtiene_datos_Curso", clsBD.Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_usuario", idUsuario);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        clsBD.CerrarConexion();
                    }
                }
            }
            catch (Exception e)
            {
                string mensaje = string.Format("No se pudo obtener el listado de las empresas", "Lista de empresas");
                regLog.Guardar("Lista de empresas", mensaje);
                regLog.Guardar("Lista de empresas", e.Message);
            }

            return dt;
        }
        public DataTable ListaModulos(int idProducto)
        {
            DataTable dt = new DataTable();
            Configuracion iniConfig = new Configuracion();
            RegistraLog regLog = new RegistraLog();

            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };

            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_obtiene_datos_modulo", clsBD.Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_id_producto", idProducto);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        clsBD.CerrarConexion();
                    }
                }
            }
            catch (Exception e)
            {
                string mensaje = string.Format("No se pudo obtener el listado de las empresas", "Lista de empresas");
                regLog.Guardar("Lista de empresas", mensaje);
                regLog.Guardar("Lista de empresas", e.Message);
            }

            return dt;
        }

        public DataTable ListaTemas(int idModulo)
        {
            DataTable dtm = new DataTable();
            Configuracion iniConfig = new Configuracion();
            RegistraLog regLog = new RegistraLog();

            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };

            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_obtiene_datos_tema", clsBD.Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_id_modulo", idModulo);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dtm);
                        clsBD.CerrarConexion();
                    }
                }
            }
            catch (Exception e)
            {
                string mensaje = string.Format("No se pudo obtener el listado de las empresas", "Lista de empresas");
                regLog.Guardar("Lista de empresas", mensaje);
                regLog.Guardar("Lista de empresas", e.Message);
            }

            return dtm;
        }
        public DataTable ListaSubtemas(int idTema)
        {
            DataTable dt = new DataTable();
            Configuracion iniConfig = new Configuracion();
            RegistraLog regLog = new RegistraLog();

            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = iniConfig.ReturnIni(),
            };

            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_obtiene_datos_subtema", clsBD.Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_id_tema", idTema);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        clsBD.CerrarConexion();
                    }
                }
            }
            catch (Exception e)
            {
                string mensaje = string.Format("No se pudo obtener el listado de las empresas", "Lista de empresas");
                regLog.Guardar("Lista de empresas", mensaje);
                regLog.Guardar("Lista de empresas", e.Message);
            }

            return dt;
        }


    }
}