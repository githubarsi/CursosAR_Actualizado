using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services;
using CursosArsi.Models;
using CursosArsi.WebService;

namespace CursosArsi.Servicios
{
    public class ServiceModel
    {
        public int RegistroUsuario(UsuariosEntity user)
        {
            int resultado = 0;
            int identificador = 0;
            string passw = string.Empty;

            try
            {
                UsuarioEntity wue = new UsuarioEntity
                {
                    idUsuario = user.idUsuario,
                    nombre = user.nombre,
                    eMail = user.eMail,
                    contrasena = user.contrasena,
                    cp = user.cp,
                    calle = user.calle,
                    numeroExt = user.numeroExt,
                    numeroInt = user.numeroInt,
                    colonia = user.colonia,
                    municipio = user.municipio,
                    estado = user.estado,
                    telefonoContacto = user.telefonoContacto,
                    telefonoWhats = user.telefonoContacto,
                    estatus = user.estatus,
                };
                SAdmDatosClient sdata = new SAdmDatosClient();
                string respuesta = sdata.SetRegisterUserApp(wue);

                if (respuesta.Length > 0)
                {
                    string[] words = respuesta.Split(',');
                    int i = 0;

                    foreach (var word in words)
                    {
                        if (i == 0)
                        {
                            identificador = Convert.ToInt32(word);
                        }
                        else
                        {
                            passw = word;
                        }
                        i += 1;
                    }

                    //user.idUsuario = identificador;
                    //user.contrasena = passw;
                    //CRUDUsuarioModel cm = new CRUDUsuarioModel();
                    //cm.InsertaTabla(user);
                    resultado = identificador;
                }
            }
            catch
            {
                resultado = -1;
            }
            return resultado;
        }

        public List<ProductoEntity> ObtenerProductos(string cadena = "a", string cp = "0", int idTienda = 0, int idCliente = 0)
        {
            SAdmDatosClient sdata = new SAdmDatosClient();
            List<ProductoEntity> lista = sdata.GetProductos(cadena, cp, idTienda, idCliente).ToList();
            return lista;
        }


        public List<ProductoEntity> ObtenerCarrito(int idUsuario = 0)
        {
            SAdmDatosClient sdata = new SAdmDatosClient();
            List<ProductoEntity> lista = sdata.GetCarrito(idUsuario).ToList<ProductoEntity>();
            return lista;
        }

        public List<CategoriaEntity> ListaCategoria()
        {
            SAdmDatosClient sdata = new SAdmDatosClient();
            List<CategoriaEntity> listaCat = sdata.GetListaCategorias().ToList<CategoriaEntity>();

            return listaCat;
        }

        public DireccionEntity ObtenerDatosCP(string cp)
        {
            SAdmDatosClient sdata = new SAdmDatosClient();
            DireccionEntity de = sdata.GetDatosDireccion(cp);

            return de;
        }

        //public int RegistraPedidoUsuario(List<CursosArsi.Entitys.CarritoEntity> carrito, int idUsuario)
        //{

        //    List<WebService.CarritoEntity> carritoWeb = new List<WebService.CarritoEntity>();

        //    foreach (var carritoParcial in carrito)
        //    {
        //        WebService.CarritoEntity carr = new WebService.CarritoEntity
        //        {
        //            Id = carritoParcial.Id,
        //            IdCliente = carritoParcial.IdCliente,
        //            IdTienda = carritoParcial.IdTienda,
        //            IdProducto = carritoParcial.IdProducto,
        //            Precio = carritoParcial.Precio,
        //            Cantidad = carritoParcial.Cantidad
        //        };
        //        carritoWeb.Add(carr);
        //    }

        //    SAdmDatosClient sdata = new SAdmDatosClient();
        //    int resultado = sdata.SetRegistraPedidoApp(carritoWeb.ToArray(), idUsuario);

        //    return resultado;
        //}

        //public bool RegistraProducto(WebService.ProductoEntity producto)
        //{
        //    SAdmDatosClient sdata = new SAdmDatosClient();
        //    bool resultado = sdata.SetRegistraProductoApp(producto);

        //    return resultado;
        //}
    }
}
