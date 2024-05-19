using CapaAccesoDatos.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Entidades
{
    public class CNUsuario
    {
        private InterfaceNegocio obj_interface = new();
        private string Rol, Usuario, contraseña;

        public CNUsuario()
        {
            Rol = string.Empty;
            Usuario = string.Empty;
            contraseña = string.Empty;
        }
        public string rol { get { return Rol; } set { Rol = value; } }
        public string usuario { get { return Usuario; } set { Usuario = value; } }
        public string Contraseña { get { return contraseña; } set { contraseña = value; } }

        public bool CrearUsuario(CNUsuario Usuario)
        {
            try
            {
                List<Parametros> lista_parametros = new List<Parametros>();
                lista_parametros.Add(new Parametros("@Rol", SqlDbType.Text, Usuario.rol));
                lista_parametros.Add(new Parametros("@Usuario", SqlDbType.Text, Usuario.usuario));
                lista_parametros.Add(new Parametros("@password", SqlDbType.Text, Usuario.Contraseña));


                return obj_interface.crearUsuario(lista_parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear Mantenimiento" + ex.Message.ToString());
            }
        }
        public bool comprobarUsuario(string Usuario, string password)
        {
            try
            {
                List<Parametros> lista_parametros = new List<Parametros>();
                lista_parametros.Add(new Parametros("@nombre_usuario", SqlDbType.Text, Usuario));
                lista_parametros.Add(new Parametros("@password", SqlDbType.Text, password));
                lista_parametros.Add(new Parametros("@resultado", SqlDbType.Bit, ParameterDirection.Output));
                return obj_interface.comprobarUsuarioEnBaseDatos(lista_parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error de comprobacion de usuario: " + ex.Message);
            }
        }

        public bool ObtenerRolUsuario(string Usuario)
        {
            try
            {
                List<Parametros> listaParametros = new List<Parametros>
        {
            new Parametros("@nombre_usuario", SqlDbType.VarChar, Usuario),
            new Parametros("@resultado", SqlDbType.Bit, ParameterDirection.Output)
        };

                // Llamada al método que ejecuta el procedimiento almacenado
                return obj_interface.ObtencionRolUsuario(listaParametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el rol del usuario: " + ex.Message);
            }
        }


    }
}
