using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BackEnd.DAL
{
    public class FacturaDALImpl : IFacturaDAL
    {

        private DBContext context;

        public int Add(Factura factura)
        {
            try
            {
                //using (context = new DBContext())
                //{
                //    context.Facturas.Add(factura);
                //    context.SaveChanges();
                //}

                //string conn = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
                string conn = "metadata=res://*/Entities.Factura_DigitalModel.csdl|res://*/Entities.Factura_DigitalModel.ssdl|res://*/Entities.Factura_DigitalModel.msl;provider=System.Data.SqlClient;provider connection string=\"data source=localhost;initial catalog=FACTURA_DIGITAL;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework\"";
                if (conn.ToLower().StartsWith("metadata="))
                {
                    System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(conn);
                    conn = efBuilder.ProviderConnectionString;
                }

                var sql = "insert into facturas ( [compania], [usuario], [tipo_comprobante], [monera], [condicion_venta], [forma_de_pago], [NumeroConsecutivo], [clave], [CodigoActividad], [Emisor], [sucursal], [cliente], [moneda], [FechaEmision], [FechaVencimiento], [detalle], [total_servicios_gravados], [total_servicios_exentos], [total_servicios_exonerados], [total_mercaderia_gravados], [total_mecaderia_exentas], [total_mecaderia_exoneradas], [total_gravado], [total_exento], [total_exonerado], [total_venta], [total_descuentos], [total_venta_neta], [total_impuesto], [total_comprobante], [notas]) output INSERTED.numero_factura values(@compania, @usuario, @tipo_comprobante, @monera, @condicion_venta, @forma_de_pago, @NumeroConsecutivo, @clave, @CodigoActividad, @Emisor, @sucursal, @cliente, @moneda, @FechaEmision, @FechaVencimiento, @detalle, @total_servicios_gravados, @total_servicios_exentos, @total_servicios_exonerados, @total_mercaderia_gravados, @total_mecaderia_exentas, @total_mecaderia_exoneradas, @total_gravado, @total_exento, @total_exonerado, @total_venta, @total_descuentos, @total_venta_neta, @total_impuesto, @total_comprobante, @notas)";

                SqlConnection cnn = new SqlConnection(conn);
                SqlCommand command = new SqlCommand(sql);
                SqlDataAdapter adapter = new SqlDataAdapter();

                command = new SqlCommand(sql, cnn);

                command.Parameters.AddWithValue("@compania", factura.compania);
                command.Parameters.AddWithValue("@usuario", factura.usuario);
                command.Parameters.AddWithValue("@tipo_comprobante", factura.tipo_comprobante);
                command.Parameters.AddWithValue("@monera", factura.monera);
                command.Parameters.AddWithValue("@condicion_venta", factura.condicion_venta);
                command.Parameters.AddWithValue("@forma_de_pago", factura.forma_de_pago);
                command.Parameters.AddWithValue("@NumeroConsecutivo", factura.NumeroConsecutivo);
                command.Parameters.AddWithValue("@clave", factura.clave);
                command.Parameters.AddWithValue("@CodigoActividad", factura.CodigoActividad);
                command.Parameters.AddWithValue("@Emisor", factura.Emisor);
                command.Parameters.AddWithValue("@sucursal", factura.sucursal);
                command.Parameters.AddWithValue("@cliente", factura.cliente);
                command.Parameters.AddWithValue("@moneda", factura.moneda);
                command.Parameters.AddWithValue("@FechaEmision", factura.FechaEmision);
                command.Parameters.AddWithValue("@FechaVencimiento", factura.FechaVencimiento);
                command.Parameters.AddWithValue("@detalle", factura.detalle);
                command.Parameters.AddWithValue("@total_servicios_gravados", factura.total_servicios_gravados);
                command.Parameters.AddWithValue("@total_servicios_exentos", factura.total_servicios_exentos);
                command.Parameters.AddWithValue("@total_servicios_exonerados", factura.total_servicios_exonerados);
                command.Parameters.AddWithValue("@total_mercaderia_gravados", factura.total_mercaderia_gravados);
                command.Parameters.AddWithValue("@total_mecaderia_exentas", factura.total_mecaderia_exentas);
                command.Parameters.AddWithValue("@total_mecaderia_exoneradas", factura.total_mecaderia_exoneradas);
                command.Parameters.AddWithValue("@total_gravado", factura.total_gravado);
                command.Parameters.AddWithValue("@total_exento", factura.total_exonerado);
                command.Parameters.AddWithValue("@total_exonerado", factura.total_exonerado);
                command.Parameters.AddWithValue("@total_venta", factura.total_venta);
                command.Parameters.AddWithValue("@total_descuentos", factura.total_descuentos);
                command.Parameters.AddWithValue("@total_venta_neta", factura.total_venta_neta);
                command.Parameters.AddWithValue("@total_impuesto", factura.total_impuesto);
                command.Parameters.AddWithValue("@total_comprobante", factura.total_comprobante);
                command.Parameters.AddWithValue("@notas", factura.notas);


                cnn.Open();
                int modified =(int)command.ExecuteScalar();
                //int modified = (int)command.ExecuteNonQuery();

                //update consecutivo
                command.Dispose();
                sql = "update Consecutivos_Facturas set consecutivo_factura = (consecutivo_factura+1) where compania = @compania";
                command = new SqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@compania", factura.compania);
                command.ExecuteNonQuery();
                command.Dispose();
                cnn.Close();

                return modified;

            }
            catch (Exception)
            {

                return 0;
            }

        }

        public int Add_Linea(Detalle_Factura detalle)
        {
            try
            {

                //string conn = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
                string conn = "metadata=res://*/Entities.Factura_DigitalModel.csdl|res://*/Entities.Factura_DigitalModel.ssdl|res://*/Entities.Factura_DigitalModel.msl;provider=System.Data.SqlClient;provider connection string=\"data source=localhost;initial catalog=FACTURA_DIGITAL;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework\"";
                if (conn.ToLower().StartsWith("metadata="))
                {
                    System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(conn);
                    conn = efBuilder.ProviderConnectionString;
                }

                var sql = "insert into [dbo].[Detalle_Facturas] ([numero_factura], [NumeroLinea], [producto], [LineaDetalle], [PartidaArancelaria], [UnidadMedida], [Cantidad], [PrecioUnitario], [MontoDescuento], [codigo_impuesto], [Impuesto], [TotalLinea]) values (@numero_factura, @NumeroLinea, @producto, @LineaDetalle, @PartidaArancelaria, @UnidadMedida, @Cantidad, @PrecioUnitario, @MontoDescuento, @codigo_impuesto, @Impuesto, @TotalLinea)";

                SqlConnection cnn = new SqlConnection(conn);
                SqlCommand command = new SqlCommand(sql);
                SqlDataAdapter adapter = new SqlDataAdapter();

                command = new SqlCommand(sql, cnn);

                command.Parameters.AddWithValue("@numero_factura", detalle.numero_factura);
                command.Parameters.AddWithValue("@NumeroLinea", detalle.NumeroLinea);
                command.Parameters.AddWithValue("@producto", detalle.producto);
                command.Parameters.AddWithValue("@LineaDetalle", detalle.LineaDetalle);
                command.Parameters.AddWithValue("@PartidaArancelaria", detalle.PartidaArancelaria);
                command.Parameters.AddWithValue("@UnidadMedida", detalle.PartidaArancelaria);
                command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                command.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
                command.Parameters.AddWithValue("@MontoDescuento", detalle.MontoDescuento);
                command.Parameters.AddWithValue("@codigo_impuesto", 1);
                command.Parameters.AddWithValue("@Impuesto", detalle.Impuesto);
                command.Parameters.AddWithValue("@TotalLinea", detalle.TotalLinea);

                cnn.Open();
                command.ExecuteScalar();
                //int modified = (int)command.ExecuteNonQuery();

                //Actualizar el inventario
                command.Dispose();
                sql = "update Inventarios set cantidad=(cantidad-1) where id = @id";
                command = new SqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@id", detalle.producto);
                command.ExecuteScalar();
                command.Dispose();
                cnn.Close();

                return 1;

            }
            catch (Exception)
            {

                return 0;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                Factura factura = this.Get(id);
                using (context = new DBContext())
                {
                    context.Facturas.Attach(factura);
                    context.Facturas.Remove(factura);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public List<Factura> Get()
        {
            List<Factura> result;
            using (context = new DBContext())
            {
                result = (from c in context.Facturas

                          select c).ToList();
            }
            return result;
        }

        public Factura Get(int id)
        {

            Factura result;
            using (context = new DBContext())
            {
                result = (from c in context.Facturas
                          where c.numero_factura == id
                          select c).FirstOrDefault();
            }
            return result;
        }

        public bool Update(Factura factura)
        {
            try
            {
                using (context = new DBContext())
                {
                    context.Entry(factura).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
