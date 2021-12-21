using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using Librerias;

namespace Librerias
{
    public class ClsUsuario
    {
        private string usuario;
        private string password;
        private string ruta;

        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string Ruta
        {
            get { return this.ruta; }
            set { this.ruta = value; }
        }

        public int ValidaUsuario(string opcion)
        {
            AdministradorBD clsBD = new AdministradorBD
            {
                RutaConfig = this.ruta,
            };

            try
            {
                if (clsBD.AbrirConexion())
                {
                    string passCod = Librerias.Encriptador.Encriptar(this.password);
                    int resultUser = clsBD.SPValidaUser(this.Usuario, passCod, opcion);
                    bool conexion = clsBD.CerrarConexion();

                    return resultUser;
                }
            }
            catch
            {
                return -1;
            }

            return -1;
        }
    }
}
