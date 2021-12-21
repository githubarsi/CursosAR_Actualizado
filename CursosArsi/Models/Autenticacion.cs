using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using AdmServer.Utilerias;
using Librerias;
using MySql.Data.MySqlClient;
namespace AdmServer.Models
{
    public class Autenticacion
    {

        public int UsuarioValido(string usr, string pass)
        {
            RegistraLog regLog = new RegistraLog();
            Configuracion cadConfig = new Configuracion();
            int idUsr;

            ClsUsuario usuario = new ClsUsuario
            {
                Usuario = usr,
                Password = pass,
                Ruta = cadConfig.ReturnIni(),
            };

            idUsr = usuario.ValidaUsuario("1");
            HttpContext.Current.Session["id_usuario"] = idUsr;

            try
            {
                if (idUsr > 0)
                {
                    string mensaje = string.Format("El usuario {0} accedió al sistema correctamente", usr);
                    regLog.Guardar("UsuarioValido: ", mensaje);
                }
                else
                {
                    string mensaje = string.Format("Error en el acceso de {0}, error en el usuario o contraseña, revise el estatus del usuario, debe ser R", usr);
                    regLog.Guardar("UsuarioValido: ", mensaje);
                }
            }
            catch (Exception e)
            {
                string mensaje = string.Format("Error en el acceso de {0}, error en el usuario o contraseña, revise el estatus del usuario, debe ser R", usr);
                regLog.Guardar("UsuarioValido: ", mensaje);
                regLog.Guardar("UsuarioValido: ", e.Message);
            }

            return idUsr;
        }

        public int ObtieneTipoEmpresa(int usuario)
        {
            AdministradorBD clsBD = new AdministradorBD();
            int tipoEmpresa = 0;

            try
            {
                if (clsBD.AbrirConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_obtiene_tipo_empresa", clsBD.Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_usuario", usuario);
                        MySqlParameter respuestaSP = new MySqlParameter("@o_respuesta", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output,
                        };
                        cmd.Parameters.Add(respuestaSP);
                        cmd.ExecuteNonQuery();

                        tipoEmpresa = (int)cmd.Parameters["@o_respuesta"].Value;
                    }
                }
            }
            catch (Exception e)
            {
                RegistraLog regLog = new RegistraLog();
                string mensaje = string.Format("No se pudo obtener el tipo de empresa del usuario {0}", usuario.ToString());
                regLog.Guardar("ObtieneTipoEmpresa", mensaje);
                regLog.Guardar("ObtieneTipoEmpresa", e.Message);
                tipoEmpresa = 0;
            }
            finally
            {
                clsBD.CerrarConexion();
            }

            return tipoEmpresa;
        }

        public int EmpresaValida(string usr, string pass)
        {
            RegistraLog regLog = new RegistraLog();
            Configuracion cadConfig = new Configuracion();
            int idUsr;

            ClsUsuario usuario = new ClsUsuario
            {
                Usuario = usr,
                Password = pass,
                Ruta = cadConfig.ReturnIni(),
            };

            try
            {
                idUsr = usuario.ValidaUsuario("2");
                HttpContext.Current.Session["id_usuario"] = idUsr;

                return idUsr;

            }
            catch (Exception e)
            {
                string mensaje = string.Format("Error en el acceso de {0}, error en el usuario o contraseña, revise el registro de la empresa", usr);
                regLog.Guardar("EmpresaValida: ", mensaje);
                regLog.Guardar("EmpresaValida: ", e.Message);
            }

            return -1;
        }
    }
}