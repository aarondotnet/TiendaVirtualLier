﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using TiendaVirtual.Entidades;

namespace TiendaVirtual.AccesoDatos
{
    class DaoFacturaSqlServer : IDaoFactura
    {
        private const string SQL_INSERT = "INSERT INTO facturas (Numero, Fecha,UsuariosId) VALUES ((select count(*) from facturas),@fecha,@UsuariosId)";
        private const string SQL_INSERT2 = "INSERT INTO lineasfactura (FacturaId,ProductoId,Cantidad) VALUES ((select MAX(ID) from facturas), @ProductoId, @Cantidad)";

        private string connectionString;
        public DaoFacturaSqlServer(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public DaoFacturaSqlServer()
        {

        }
        public void Alta(IFactura factura)
        {
            try
            {
                using (IDbConnection con = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    //"Zona declarativa"
                    con.Open();

                    IDbCommand comInsert = con.CreateCommand();

                    comInsert.CommandText = SQL_INSERT;

                    //IDbDataParameter parNumero = comInsert.CreateParameter();
                    //parNumero.ParameterName = "Numero";
                    //parNumero.DbType = DbType.String;

                    IDbDataParameter parFecha = comInsert.CreateParameter();
                    parFecha.ParameterName = "Fecha";
                    parFecha.DbType = DbType.String;
                   
                    IDbDataParameter parUsuariosId = comInsert.CreateParameter();
                    parUsuariosId.ParameterName = "UsuariosId";
                    parUsuariosId.DbType = DbType.String;

                    //comInsert.Parameters.Add(parNumero);
                    comInsert.Parameters.Add(parFecha);
                    comInsert.Parameters.Add(parUsuariosId);

                    //"Zona concreta"
                    //parNumero.Value = factura.Numero;
                    parFecha.Value = factura.Fecha;
                    parUsuariosId.Value = factura.Usuario.Id;

                    int numRegistrosInsertados = comInsert.ExecuteNonQuery();

                    if (numRegistrosInsertados != 1)
                        throw new AccesoDatosException("Número de registros insertados: " +
                            numRegistrosInsertados);
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException("No se ha podido realizar el alta", e);
            }
            foreach (ILineaFactura linea in factura.LineasFactura)
            {
                try
                {
                    using (IDbConnection con = new System.Data.SqlClient.SqlConnection(connectionString))
                    {
                        //"Zona declarativa"
                        con.Open();

                        IDbCommand comInsert = con.CreateCommand();

                        comInsert.CommandText = SQL_INSERT2;

                        //IDbDataParameter parFacturaID = comInsert.CreateParameter();
                        //parFacturaID.ParameterName = "FacturaID";
                        //parFacturaID.DbType = DbType.String;

                        IDbDataParameter parProductoId = comInsert.CreateParameter();
                        parProductoId.ParameterName = "ProductoId";
                        parProductoId.DbType = DbType.String;

                        IDbDataParameter parCantidad = comInsert.CreateParameter();
                        parCantidad.ParameterName = "Cantidad";
                        parCantidad.DbType = DbType.String;

                        //comInsert.Parameters.Add(parFacturaID);
                        comInsert.Parameters.Add(parProductoId);
                        comInsert.Parameters.Add(parCantidad);

                        //"Zona concreta"
                        //parFacturaID.Value = factura.Numero;
                        parProductoId.Value = linea.Producto.Id;
                        parCantidad.Value = factura.Usuario.Id;

                        int numRegistrosInsertados = comInsert.ExecuteNonQuery();

                        if (numRegistrosInsertados != 1)
                            throw new AccesoDatosException("Número de registros insertados: " +
                                numRegistrosInsertados);
                    }
                }
                catch (Exception e)
                {
                    throw new AccesoDatosException("No se ha podido realizar el alta", e);
                }

            }

              

        }
    }
}
