using System;
using System.Collections.Generic;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listarArticulos()
        {
			List<Articulo> lista = new List<Articulo>();
			AccesoDatos datos = new AccesoDatos();
            ImagenesNegocio imagenesNegocio = new ImagenesNegocio();

			try
			{
                datos.setearConsulta("Select a.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, Precio, A.idMarca, A.idCategoria From ARTICULOS A,MARCAS M, CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.ListaImagenes = new List<Imagenes>();
                    aux.ListaImagenes = imagenesNegocio.listarImagenes(aux.Id);

                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["idMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.Lector["idCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    lista.Add(aux);
                }
                return lista;
			}
			catch (Exception ex)
			{

				throw ex;
			}
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)values(" +
                    "@codigo, @nombre, @descripcion, @idMarca, @idCategoria,@precio)");
                datos.setearParametro("@codigo", articulo.Codigo);
                datos.setearParametro("@nombre", articulo.Nombre);
                datos.setearParametro("@descripcion", articulo.Descripcion);
                datos.setearParametro("@idMarca", articulo.Marca.Id);
                datos.setearParametro("@idCategoria", articulo.Categoria.Id);
                datos.setearParametro("@precio", articulo.Precio);
                datos.ejecutarAccion();
                datos.cerrarConexion();

                datos.setearConsulta("select top 1 Id from ARTICULOS order by id desc");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    articulo.Id = (int)datos.Lector["Id"];
                }
                datos.cerrarConexion();

                foreach (var imagen in articulo.ListaImagenes)
                {
                    datos.setearConsulta("insert into IMAGENES (idArticulo, ImagenUrl) values (@id,@url)");
                    datos.setearParametro("@id", articulo.Id);
                    datos.setearParametro("@url", imagen.ImagenUrl);

                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo," +
                    " Nombre = @nombre," +
                    " Descripcion = @descripcion," +
                    " IdMarca = @IdMarca," +
                    " IdCategoria = @idCategoria," +
                    " Precio = @precio" +
                    " Where Id = @id");

                datos.setearParametro("@codigo", articulo.Codigo);
                datos.setearParametro("@nombre", articulo.Nombre);
                datos.setearParametro("@descripcion", articulo.Descripcion);
                datos.setearParametro("@idMarca", articulo.Marca.Id);
                datos.setearParametro("@idCategoria", articulo.Categoria.Id);
                datos.setearParametro("@precio", articulo.Precio);
                datos.setearParametro("@id", articulo.Id);

                datos.ejecutarAccion();
                datos.cerrarConexion();

                datos.setearConsulta("delete from IMAGENES where idArticulo = @id");

                datos.ejecutarAccion();
                datos.cerrarConexion();

                foreach (var imagen in articulo.ListaImagenes)
                {
                    datos.setearConsulta("insert into IMAGENES (idArticulo, ImagenUrl) values (@id,@url)");
                    datos.setearParametro("@id", articulo.Id);
                    datos.setearParametro("@url", imagen.ImagenUrl);
                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where id= @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
                datos.cerrarConexion();
                datos.setearConsulta("delete from IMAGENES where idArticulo = @id");
                datos.ejecutarAccion();
                datos.cerrarConexion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select * from(Select a.Id," +
                    " Codigo," +
                    " Nombre," +
                    " A.Descripcion," +
                    " M.Descripcion Marca," +
                    " C.Descripcion Categoria," +
                    " Precio, " +
                    " A.IdMarca," +
                    " A.IdCategoria" +
                    " From articulos a" +
                    " join marcas m on m.id = a.idmarca" +
                    " join categorias c on c.id = a.IdCategoria) tabla";


                switch (criterio.ToUpper())
                {
                    case "COMIENZA CON":
                        consulta += " where " + campo.ToUpper() + " like '" + filtro + "%' ";
                        break;
                    case "TERMINA CON":
                        consulta += " where " + campo.ToUpper() + " like '%" + filtro + "'";
                        break;
                    case "CONTIENE":
                        consulta += " where " + campo.ToUpper() + " like '%" + filtro + "%'";
                        break;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    aux.ListaImagenes = new List<Imagenes>();
                    aux.ListaImagenes = imagenesNegocio.listarImagenes(aux.Id);


                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
