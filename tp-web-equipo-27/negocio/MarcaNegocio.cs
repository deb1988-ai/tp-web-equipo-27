using System;
using System.Collections.Generic;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marcas> listarMarcas()
        {
            List<Marcas> lista = new List<Marcas>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion From MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marcas aux = new Marcas();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

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
        public void eliminar(int id)
        {
            try
            {
                validarEliminar(id);
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from MARCAS where id= @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void validarEliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select id from articulos where idMarca = @idMarca");
                datos.setearParametro("@idMarca", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    throw new Exception("Existen articulos con esta marca, no se puede eliminar");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Existen articulos con esta marca, no se puede eliminar");
            }
            finally 
            {
                datos.cerrarConexion();
            }

        }

        public void agregar(Marcas marca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into Marcas (Descripcion)values(@descripcion)");
                datos.setearParametro("@descripcion", marca.Descripcion);
                datos.ejecutarAccion();
                datos.cerrarConexion();

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

        public void editar(Marcas marca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update Marcas set Descripcion = @descripcion where id = @id");
                datos.setearParametro("@descripcion", marca.Descripcion);
                datos.setearParametro("@id", marca.Id);
                datos.ejecutarAccion();
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


    }
}
