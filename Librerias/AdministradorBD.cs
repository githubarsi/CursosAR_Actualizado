using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using Librerias;
using MySql.Data.MySqlClient;

namespace Librerias
{
    public class AdministradorBD
    {
        private static string rutaConfig;
        private MySqlConnection conexion = new MySqlConnection();

        public MySqlConnection Conexion
        {
            get { return this.conexion; }
            set { this.conexion = value; }
        }

        public string RutaConfig
        {
            get { return rutaConfig; }
            set { rutaConfig = value; }
        }


        public bool AbrirConexion()
        {
            try
            {
                this.conexion.ConnectionString = ObtenerCadenaConexion();
                this.Conexion.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CerrarConexion()
        {
            try
            {
                this.Conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int SPValidaUser(string usuario, string password, string opcion)
        {
            int statusUser;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_valida_usuario", this.conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@i_opcion", opcion);
                    cmd.Parameters.AddWithValue("@i_usuario", usuario);
                    cmd.Parameters.AddWithValue("@i_password", password);
                    MySqlParameter respuestaSP = new MySqlParameter("@o_respuesta", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output,
                    };
                    cmd.Parameters.Add(respuestaSP);
                    cmd.ExecuteNonQuery();

                    statusUser = (int)cmd.Parameters["@o_respuesta"].Value;
                }

                return statusUser;
            }
            catch
            {
                return -1;
            }
        }

        private static string ObtenerCadenaConexion()
        {
            StringBuilder server = new StringBuilder();
            string servidor;
            string usuario;
            string passw;
            string baseDeDatos;
            string valor;

            try
            {
                if (File.Exists(rutaConfig))
                {
                    Util.GetPrivateProfileString("Datos", "Server", string.Empty, server, 100, rutaConfig);
                    servidor = Encriptador.DesEncriptar(server.ToString());
                    Util.GetPrivateProfileString("Datos", "DataBase", string.Empty, server, 100, rutaConfig);
                    baseDeDatos = Encriptador.DesEncriptar(server.ToString());
                    Util.GetPrivateProfileString("Datos", "User", string.Empty, server, 100, rutaConfig);
                    usuario = Encriptador.DesEncriptar(server.ToString());
                    Util.GetPrivateProfileString("Datos", "Pass", string.Empty, server, 100, rutaConfig);
                    passw = Encriptador.DesEncriptar(server.ToString());
                    valor = "Server=" + servidor + ";Database=" + baseDeDatos + ";Uid=" + usuario + ";Pwd=" + passw + ";";
                }
                else
                {
                    return "Error de archivo";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return valor;
        }
    }
}
