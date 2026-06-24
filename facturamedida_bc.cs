using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class facturamedida_bc : GxSilentTrn, IGxSilentTrn
   {
      public facturamedida_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public facturamedida_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0G16( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0G16( ) ;
         standaloneModal( ) ;
         AddRow0G16( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z77FacturaMedidaID = A77FacturaMedidaID;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_0G0( )
      {
         BeforeValidate0G16( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0G16( ) ;
            }
            else
            {
               CheckExtendedTable0G16( ) ;
               if ( AnyError == 0 )
               {
                  ZM0G16( 4) ;
                  ZM0G16( 5) ;
                  ZM0G16( 6) ;
                  ZM0G16( 7) ;
                  ZM0G16( 8) ;
                  ZM0G16( 9) ;
                  ZM0G16( 10) ;
                  ZM0G16( 11) ;
                  ZM0G16( 12) ;
                  ZM0G16( 13) ;
               }
               CloseExtendedTableCursors0G16( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0G16( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z78FacturaMedidaCantidad = A78FacturaMedidaCantidad;
            Z79FacturaMedidaPrecio = A79FacturaMedidaPrecio;
            Z69FacturaID = A69FacturaID;
            Z26MedidaID = A26MedidaID;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z71FacturaNo = A71FacturaNo;
            Z73FacturaFechaFactura = A73FacturaFechaFactura;
            Z72FacturaFechaRegistro = A72FacturaFechaRegistro;
            Z80FacturaEstatus = A80FacturaEstatus;
            Z41PromocionID = A41PromocionID;
            Z19MotivoRechazoID = A19MotivoRechazoID;
            Z29UsuarioID = A29UsuarioID;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z28MedidaDescripcion = A28MedidaDescripcion;
            Z74MedidaRin = A74MedidaRin;
            Z27MedidaCodigo = A27MedidaCodigo;
            Z22ModeloID = A22ModeloID;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z42PromocionDescripcion = A42PromocionDescripcion;
            Z43PromocionBase = A43PromocionBase;
            Z45PromocionFechaInicio = A45PromocionFechaInicio;
            Z46PromocionFechaFin = A46PromocionFechaFin;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z20MotivoRechazoDescripcion = A20MotivoRechazoDescripcion;
            Z21MotivoRechazoActivo = A21MotivoRechazoActivo;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z63UsuarioZona = A63UsuarioZona;
            Z53UsuarioGenero = A53UsuarioGenero;
            Z30UsuarioNombre = A30UsuarioNombre;
            Z51UsuarioApellido = A51UsuarioApellido;
            Z31UsuarioCorreo = A31UsuarioCorreo;
            Z32UsuarioPass = A32UsuarioPass;
            Z33UsuarioKey = A33UsuarioKey;
            Z54UsuarioDirectoAsociado = A54UsuarioDirectoAsociado;
            Z55UsuarioRazonSocialAsociado = A55UsuarioRazonSocialAsociado;
            Z56UsuarioNombreComercial = A56UsuarioNombreComercial;
            Z57UsuarioFechaNacimiento = A57UsuarioFechaNacimiento;
            Z59UsuarioCalleNum = A59UsuarioCalleNum;
            Z60UsuarioColonia = A60UsuarioColonia;
            Z61UsuarioDelegacion = A61UsuarioDelegacion;
            Z62UsuarioCP = A62UsuarioCP;
            Z64UsuarioCelular = A64UsuarioCelular;
            Z65UsuarioTelefonoSucursal = A65UsuarioTelefonoSucursal;
            Z66UsuarioSucursal = A66UsuarioSucursal;
            Z67UsuarioProducto = A67UsuarioProducto;
            Z40UsuarioRol = A40UsuarioRol;
            Z82UsuarioNoCuentaBROXEL = A82UsuarioNoCuentaBROXEL;
            Z83UsuarioReferenciaBROXEL = A83UsuarioReferenciaBROXEL;
            Z13PuestoID = A13PuestoID;
            Z4CiudadID = A4CiudadID;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z14PuestoDescripcion = A14PuestoDescripcion;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z5CiudadDescripcion = A5CiudadDescripcion;
            Z1EstadoID = A1EstadoID;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z2EstadoDescripcion = A2EstadoDescripcion;
            Z16PaisID = A16PaisID;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z17PaisDescripcion = A17PaisDescripcion;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z23ModeloDescripcion = A23ModeloDescripcion;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( GX_JID == -3 )
         {
            Z77FacturaMedidaID = A77FacturaMedidaID;
            Z78FacturaMedidaCantidad = A78FacturaMedidaCantidad;
            Z79FacturaMedidaPrecio = A79FacturaMedidaPrecio;
            Z69FacturaID = A69FacturaID;
            Z26MedidaID = A26MedidaID;
            Z71FacturaNo = A71FacturaNo;
            Z73FacturaFechaFactura = A73FacturaFechaFactura;
            Z72FacturaFechaRegistro = A72FacturaFechaRegistro;
            Z75FacturaPDF = A75FacturaPDF;
            Z40001FacturaPDF_GXI = A40001FacturaPDF_GXI;
            Z80FacturaEstatus = A80FacturaEstatus;
            Z41PromocionID = A41PromocionID;
            Z19MotivoRechazoID = A19MotivoRechazoID;
            Z29UsuarioID = A29UsuarioID;
            Z42PromocionDescripcion = A42PromocionDescripcion;
            Z43PromocionBase = A43PromocionBase;
            Z44PromocionArte = A44PromocionArte;
            Z40000PromocionArte_GXI = A40000PromocionArte_GXI;
            Z45PromocionFechaInicio = A45PromocionFechaInicio;
            Z46PromocionFechaFin = A46PromocionFechaFin;
            Z20MotivoRechazoDescripcion = A20MotivoRechazoDescripcion;
            Z21MotivoRechazoActivo = A21MotivoRechazoActivo;
            Z63UsuarioZona = A63UsuarioZona;
            Z53UsuarioGenero = A53UsuarioGenero;
            Z30UsuarioNombre = A30UsuarioNombre;
            Z51UsuarioApellido = A51UsuarioApellido;
            Z31UsuarioCorreo = A31UsuarioCorreo;
            Z32UsuarioPass = A32UsuarioPass;
            Z33UsuarioKey = A33UsuarioKey;
            Z54UsuarioDirectoAsociado = A54UsuarioDirectoAsociado;
            Z55UsuarioRazonSocialAsociado = A55UsuarioRazonSocialAsociado;
            Z56UsuarioNombreComercial = A56UsuarioNombreComercial;
            Z57UsuarioFechaNacimiento = A57UsuarioFechaNacimiento;
            Z59UsuarioCalleNum = A59UsuarioCalleNum;
            Z60UsuarioColonia = A60UsuarioColonia;
            Z61UsuarioDelegacion = A61UsuarioDelegacion;
            Z62UsuarioCP = A62UsuarioCP;
            Z64UsuarioCelular = A64UsuarioCelular;
            Z65UsuarioTelefonoSucursal = A65UsuarioTelefonoSucursal;
            Z66UsuarioSucursal = A66UsuarioSucursal;
            Z67UsuarioProducto = A67UsuarioProducto;
            Z40UsuarioRol = A40UsuarioRol;
            Z82UsuarioNoCuentaBROXEL = A82UsuarioNoCuentaBROXEL;
            Z83UsuarioReferenciaBROXEL = A83UsuarioReferenciaBROXEL;
            Z13PuestoID = A13PuestoID;
            Z4CiudadID = A4CiudadID;
            Z14PuestoDescripcion = A14PuestoDescripcion;
            Z5CiudadDescripcion = A5CiudadDescripcion;
            Z1EstadoID = A1EstadoID;
            Z2EstadoDescripcion = A2EstadoDescripcion;
            Z16PaisID = A16PaisID;
            Z17PaisDescripcion = A17PaisDescripcion;
            Z28MedidaDescripcion = A28MedidaDescripcion;
            Z74MedidaRin = A74MedidaRin;
            Z27MedidaCodigo = A27MedidaCodigo;
            Z22ModeloID = A22ModeloID;
            Z23ModeloDescripcion = A23ModeloDescripcion;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0G16( )
      {
         /* Using cursor BC000G14 */
         pr_default.execute(12, new Object[] {A77FacturaMedidaID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound16 = 1;
            A42PromocionDescripcion = BC000G14_A42PromocionDescripcion[0];
            A43PromocionBase = BC000G14_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000G14_A40000PromocionArte_GXI[0];
            A71FacturaNo = BC000G14_A71FacturaNo[0];
            A73FacturaFechaFactura = BC000G14_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = BC000G14_A72FacturaFechaRegistro[0];
            A63UsuarioZona = BC000G14_A63UsuarioZona[0];
            A2EstadoDescripcion = BC000G14_A2EstadoDescripcion[0];
            A5CiudadDescripcion = BC000G14_A5CiudadDescripcion[0];
            A17PaisDescripcion = BC000G14_A17PaisDescripcion[0];
            A53UsuarioGenero = BC000G14_A53UsuarioGenero[0];
            A40001FacturaPDF_GXI = BC000G14_A40001FacturaPDF_GXI[0];
            A80FacturaEstatus = BC000G14_A80FacturaEstatus[0];
            A20MotivoRechazoDescripcion = BC000G14_A20MotivoRechazoDescripcion[0];
            A21MotivoRechazoActivo = BC000G14_A21MotivoRechazoActivo[0];
            A28MedidaDescripcion = BC000G14_A28MedidaDescripcion[0];
            A74MedidaRin = BC000G14_A74MedidaRin[0];
            A27MedidaCodigo = BC000G14_A27MedidaCodigo[0];
            A23ModeloDescripcion = BC000G14_A23ModeloDescripcion[0];
            A78FacturaMedidaCantidad = BC000G14_A78FacturaMedidaCantidad[0];
            A79FacturaMedidaPrecio = BC000G14_A79FacturaMedidaPrecio[0];
            A30UsuarioNombre = BC000G14_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000G14_A51UsuarioApellido[0];
            A31UsuarioCorreo = BC000G14_A31UsuarioCorreo[0];
            A32UsuarioPass = BC000G14_A32UsuarioPass[0];
            A33UsuarioKey = BC000G14_A33UsuarioKey[0];
            A14PuestoDescripcion = BC000G14_A14PuestoDescripcion[0];
            A54UsuarioDirectoAsociado = BC000G14_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = BC000G14_n54UsuarioDirectoAsociado[0];
            A55UsuarioRazonSocialAsociado = BC000G14_A55UsuarioRazonSocialAsociado[0];
            A56UsuarioNombreComercial = BC000G14_A56UsuarioNombreComercial[0];
            A57UsuarioFechaNacimiento = BC000G14_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = BC000G14_n57UsuarioFechaNacimiento[0];
            A59UsuarioCalleNum = BC000G14_A59UsuarioCalleNum[0];
            A60UsuarioColonia = BC000G14_A60UsuarioColonia[0];
            A61UsuarioDelegacion = BC000G14_A61UsuarioDelegacion[0];
            A62UsuarioCP = BC000G14_A62UsuarioCP[0];
            A64UsuarioCelular = BC000G14_A64UsuarioCelular[0];
            A65UsuarioTelefonoSucursal = BC000G14_A65UsuarioTelefonoSucursal[0];
            A66UsuarioSucursal = BC000G14_A66UsuarioSucursal[0];
            A67UsuarioProducto = BC000G14_A67UsuarioProducto[0];
            n67UsuarioProducto = BC000G14_n67UsuarioProducto[0];
            A40UsuarioRol = BC000G14_A40UsuarioRol[0];
            A82UsuarioNoCuentaBROXEL = BC000G14_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = BC000G14_A83UsuarioReferenciaBROXEL[0];
            A45PromocionFechaInicio = BC000G14_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000G14_A46PromocionFechaFin[0];
            A69FacturaID = BC000G14_A69FacturaID[0];
            A26MedidaID = BC000G14_A26MedidaID[0];
            A41PromocionID = BC000G14_A41PromocionID[0];
            A19MotivoRechazoID = BC000G14_A19MotivoRechazoID[0];
            A29UsuarioID = BC000G14_A29UsuarioID[0];
            A13PuestoID = BC000G14_A13PuestoID[0];
            n13PuestoID = BC000G14_n13PuestoID[0];
            A4CiudadID = BC000G14_A4CiudadID[0];
            n4CiudadID = BC000G14_n4CiudadID[0];
            A1EstadoID = BC000G14_A1EstadoID[0];
            A16PaisID = BC000G14_A16PaisID[0];
            A22ModeloID = BC000G14_A22ModeloID[0];
            A44PromocionArte = BC000G14_A44PromocionArte[0];
            A75FacturaPDF = BC000G14_A75FacturaPDF[0];
            ZM0G16( -3) ;
         }
         pr_default.close(12);
         OnLoadActions0G16( ) ;
      }

      protected void OnLoadActions0G16( )
      {
         A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
      }

      protected void CheckExtendedTable0G16( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000G4 */
         pr_default.execute(2, new Object[] {A69FacturaID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Factura", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "FACTURAID");
            AnyError = 1;
         }
         A71FacturaNo = BC000G4_A71FacturaNo[0];
         A73FacturaFechaFactura = BC000G4_A73FacturaFechaFactura[0];
         A72FacturaFechaRegistro = BC000G4_A72FacturaFechaRegistro[0];
         A40001FacturaPDF_GXI = BC000G4_A40001FacturaPDF_GXI[0];
         A80FacturaEstatus = BC000G4_A80FacturaEstatus[0];
         A41PromocionID = BC000G4_A41PromocionID[0];
         A19MotivoRechazoID = BC000G4_A19MotivoRechazoID[0];
         A29UsuarioID = BC000G4_A29UsuarioID[0];
         A75FacturaPDF = BC000G4_A75FacturaPDF[0];
         pr_default.close(2);
         /* Using cursor BC000G6 */
         pr_default.execute(4, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
         }
         A42PromocionDescripcion = BC000G6_A42PromocionDescripcion[0];
         A43PromocionBase = BC000G6_A43PromocionBase[0];
         A40000PromocionArte_GXI = BC000G6_A40000PromocionArte_GXI[0];
         A45PromocionFechaInicio = BC000G6_A45PromocionFechaInicio[0];
         A46PromocionFechaFin = BC000G6_A46PromocionFechaFin[0];
         A44PromocionArte = BC000G6_A44PromocionArte[0];
         pr_default.close(4);
         A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         /* Using cursor BC000G7 */
         pr_default.execute(5, new Object[] {A19MotivoRechazoID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Motivo Rechazo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MOTIVORECHAZOID");
            AnyError = 1;
         }
         A20MotivoRechazoDescripcion = BC000G7_A20MotivoRechazoDescripcion[0];
         A21MotivoRechazoActivo = BC000G7_A21MotivoRechazoActivo[0];
         pr_default.close(5);
         /* Using cursor BC000G8 */
         pr_default.execute(6, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
         }
         A63UsuarioZona = BC000G8_A63UsuarioZona[0];
         A53UsuarioGenero = BC000G8_A53UsuarioGenero[0];
         A30UsuarioNombre = BC000G8_A30UsuarioNombre[0];
         A51UsuarioApellido = BC000G8_A51UsuarioApellido[0];
         A31UsuarioCorreo = BC000G8_A31UsuarioCorreo[0];
         A32UsuarioPass = BC000G8_A32UsuarioPass[0];
         A33UsuarioKey = BC000G8_A33UsuarioKey[0];
         A54UsuarioDirectoAsociado = BC000G8_A54UsuarioDirectoAsociado[0];
         n54UsuarioDirectoAsociado = BC000G8_n54UsuarioDirectoAsociado[0];
         A55UsuarioRazonSocialAsociado = BC000G8_A55UsuarioRazonSocialAsociado[0];
         A56UsuarioNombreComercial = BC000G8_A56UsuarioNombreComercial[0];
         A57UsuarioFechaNacimiento = BC000G8_A57UsuarioFechaNacimiento[0];
         n57UsuarioFechaNacimiento = BC000G8_n57UsuarioFechaNacimiento[0];
         A59UsuarioCalleNum = BC000G8_A59UsuarioCalleNum[0];
         A60UsuarioColonia = BC000G8_A60UsuarioColonia[0];
         A61UsuarioDelegacion = BC000G8_A61UsuarioDelegacion[0];
         A62UsuarioCP = BC000G8_A62UsuarioCP[0];
         A64UsuarioCelular = BC000G8_A64UsuarioCelular[0];
         A65UsuarioTelefonoSucursal = BC000G8_A65UsuarioTelefonoSucursal[0];
         A66UsuarioSucursal = BC000G8_A66UsuarioSucursal[0];
         A67UsuarioProducto = BC000G8_A67UsuarioProducto[0];
         n67UsuarioProducto = BC000G8_n67UsuarioProducto[0];
         A40UsuarioRol = BC000G8_A40UsuarioRol[0];
         A82UsuarioNoCuentaBROXEL = BC000G8_A82UsuarioNoCuentaBROXEL[0];
         A83UsuarioReferenciaBROXEL = BC000G8_A83UsuarioReferenciaBROXEL[0];
         A13PuestoID = BC000G8_A13PuestoID[0];
         n13PuestoID = BC000G8_n13PuestoID[0];
         A4CiudadID = BC000G8_A4CiudadID[0];
         n4CiudadID = BC000G8_n4CiudadID[0];
         pr_default.close(6);
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
         /* Using cursor BC000G9 */
         pr_default.execute(7, new Object[] {n13PuestoID, A13PuestoID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A13PuestoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Puesto", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PUESTOID");
               AnyError = 1;
            }
         }
         A14PuestoDescripcion = BC000G9_A14PuestoDescripcion[0];
         pr_default.close(7);
         /* Using cursor BC000G10 */
         pr_default.execute(8, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
            }
         }
         A5CiudadDescripcion = BC000G10_A5CiudadDescripcion[0];
         A1EstadoID = BC000G10_A1EstadoID[0];
         pr_default.close(8);
         /* Using cursor BC000G11 */
         pr_default.execute(9, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A2EstadoDescripcion = BC000G11_A2EstadoDescripcion[0];
         A16PaisID = BC000G11_A16PaisID[0];
         pr_default.close(9);
         /* Using cursor BC000G12 */
         pr_default.execute(10, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = BC000G12_A17PaisDescripcion[0];
         pr_default.close(10);
         /* Using cursor BC000G5 */
         pr_default.execute(3, new Object[] {A26MedidaID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Medida", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDIDAID");
            AnyError = 1;
         }
         A28MedidaDescripcion = BC000G5_A28MedidaDescripcion[0];
         A74MedidaRin = BC000G5_A74MedidaRin[0];
         A27MedidaCodigo = BC000G5_A27MedidaCodigo[0];
         A22ModeloID = BC000G5_A22ModeloID[0];
         pr_default.close(3);
         /* Using cursor BC000G13 */
         pr_default.execute(11, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Modelo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MODELOID");
            AnyError = 1;
         }
         A23ModeloDescripcion = BC000G13_A23ModeloDescripcion[0];
         pr_default.close(11);
      }

      protected void CloseExtendedTableCursors0G16( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
         pr_default.close(3);
         pr_default.close(11);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0G16( )
      {
         /* Using cursor BC000G15 */
         pr_default.execute(13, new Object[] {A77FacturaMedidaID});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000G3 */
         pr_default.execute(1, new Object[] {A77FacturaMedidaID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G16( 3) ;
            RcdFound16 = 1;
            A77FacturaMedidaID = BC000G3_A77FacturaMedidaID[0];
            A78FacturaMedidaCantidad = BC000G3_A78FacturaMedidaCantidad[0];
            A79FacturaMedidaPrecio = BC000G3_A79FacturaMedidaPrecio[0];
            A69FacturaID = BC000G3_A69FacturaID[0];
            A26MedidaID = BC000G3_A26MedidaID[0];
            Z77FacturaMedidaID = A77FacturaMedidaID;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0G16( ) ;
            if ( AnyError == 1 )
            {
               RcdFound16 = 0;
               InitializeNonKey0G16( ) ;
            }
            Gx_mode = sMode16;
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0G16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode16;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G16( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_0G0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0G16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000G2 */
            pr_default.execute(0, new Object[] {A77FacturaMedidaID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FacturaMedida"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z78FacturaMedidaCantidad != BC000G2_A78FacturaMedidaCantidad[0] ) || ( Z79FacturaMedidaPrecio != BC000G2_A79FacturaMedidaPrecio[0] ) || ( Z69FacturaID != BC000G2_A69FacturaID[0] ) || ( Z26MedidaID != BC000G2_A26MedidaID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FacturaMedida"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G16( )
      {
         BeforeValidate0G16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G16( 0) ;
            CheckOptimisticConcurrency0G16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G16 */
                     pr_default.execute(14, new Object[] {A78FacturaMedidaCantidad, A79FacturaMedidaPrecio, A69FacturaID, A26MedidaID});
                     pr_default.close(14);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000G17 */
                     pr_default.execute(15);
                     A77FacturaMedidaID = BC000G17_A77FacturaMedidaID[0];
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("FacturaMedida");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0G16( ) ;
            }
            EndLevel0G16( ) ;
         }
         CloseExtendedTableCursors0G16( ) ;
      }

      protected void Update0G16( )
      {
         BeforeValidate0G16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G16( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G18 */
                     pr_default.execute(16, new Object[] {A78FacturaMedidaCantidad, A79FacturaMedidaPrecio, A69FacturaID, A26MedidaID, A77FacturaMedidaID});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("FacturaMedida");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FacturaMedida"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G16( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0G16( ) ;
         }
         CloseExtendedTableCursors0G16( ) ;
      }

      protected void DeferredUpdate0G16( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0G16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G16( ) ;
            AfterConfirm0G16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G16( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000G19 */
                  pr_default.execute(17, new Object[] {A77FacturaMedidaID});
                  pr_default.close(17);
                  pr_default.SmartCacheProvider.SetUpdated("FacturaMedida");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0G16( ) ;
         Gx_mode = sMode16;
      }

      protected void OnDeleteControls0G16( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000G20 */
            pr_default.execute(18, new Object[] {A69FacturaID});
            A71FacturaNo = BC000G20_A71FacturaNo[0];
            A73FacturaFechaFactura = BC000G20_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = BC000G20_A72FacturaFechaRegistro[0];
            A40001FacturaPDF_GXI = BC000G20_A40001FacturaPDF_GXI[0];
            A80FacturaEstatus = BC000G20_A80FacturaEstatus[0];
            A41PromocionID = BC000G20_A41PromocionID[0];
            A19MotivoRechazoID = BC000G20_A19MotivoRechazoID[0];
            A29UsuarioID = BC000G20_A29UsuarioID[0];
            A75FacturaPDF = BC000G20_A75FacturaPDF[0];
            pr_default.close(18);
            /* Using cursor BC000G21 */
            pr_default.execute(19, new Object[] {A41PromocionID});
            A42PromocionDescripcion = BC000G21_A42PromocionDescripcion[0];
            A43PromocionBase = BC000G21_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000G21_A40000PromocionArte_GXI[0];
            A45PromocionFechaInicio = BC000G21_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000G21_A46PromocionFechaFin[0];
            A44PromocionArte = BC000G21_A44PromocionArte[0];
            pr_default.close(19);
            A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            /* Using cursor BC000G22 */
            pr_default.execute(20, new Object[] {A19MotivoRechazoID});
            A20MotivoRechazoDescripcion = BC000G22_A20MotivoRechazoDescripcion[0];
            A21MotivoRechazoActivo = BC000G22_A21MotivoRechazoActivo[0];
            pr_default.close(20);
            /* Using cursor BC000G23 */
            pr_default.execute(21, new Object[] {A29UsuarioID});
            A63UsuarioZona = BC000G23_A63UsuarioZona[0];
            A53UsuarioGenero = BC000G23_A53UsuarioGenero[0];
            A30UsuarioNombre = BC000G23_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000G23_A51UsuarioApellido[0];
            A31UsuarioCorreo = BC000G23_A31UsuarioCorreo[0];
            A32UsuarioPass = BC000G23_A32UsuarioPass[0];
            A33UsuarioKey = BC000G23_A33UsuarioKey[0];
            A54UsuarioDirectoAsociado = BC000G23_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = BC000G23_n54UsuarioDirectoAsociado[0];
            A55UsuarioRazonSocialAsociado = BC000G23_A55UsuarioRazonSocialAsociado[0];
            A56UsuarioNombreComercial = BC000G23_A56UsuarioNombreComercial[0];
            A57UsuarioFechaNacimiento = BC000G23_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = BC000G23_n57UsuarioFechaNacimiento[0];
            A59UsuarioCalleNum = BC000G23_A59UsuarioCalleNum[0];
            A60UsuarioColonia = BC000G23_A60UsuarioColonia[0];
            A61UsuarioDelegacion = BC000G23_A61UsuarioDelegacion[0];
            A62UsuarioCP = BC000G23_A62UsuarioCP[0];
            A64UsuarioCelular = BC000G23_A64UsuarioCelular[0];
            A65UsuarioTelefonoSucursal = BC000G23_A65UsuarioTelefonoSucursal[0];
            A66UsuarioSucursal = BC000G23_A66UsuarioSucursal[0];
            A67UsuarioProducto = BC000G23_A67UsuarioProducto[0];
            n67UsuarioProducto = BC000G23_n67UsuarioProducto[0];
            A40UsuarioRol = BC000G23_A40UsuarioRol[0];
            A82UsuarioNoCuentaBROXEL = BC000G23_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = BC000G23_A83UsuarioReferenciaBROXEL[0];
            A13PuestoID = BC000G23_A13PuestoID[0];
            n13PuestoID = BC000G23_n13PuestoID[0];
            A4CiudadID = BC000G23_A4CiudadID[0];
            n4CiudadID = BC000G23_n4CiudadID[0];
            pr_default.close(21);
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            /* Using cursor BC000G24 */
            pr_default.execute(22, new Object[] {n13PuestoID, A13PuestoID});
            A14PuestoDescripcion = BC000G24_A14PuestoDescripcion[0];
            pr_default.close(22);
            /* Using cursor BC000G25 */
            pr_default.execute(23, new Object[] {n4CiudadID, A4CiudadID});
            A5CiudadDescripcion = BC000G25_A5CiudadDescripcion[0];
            A1EstadoID = BC000G25_A1EstadoID[0];
            pr_default.close(23);
            /* Using cursor BC000G26 */
            pr_default.execute(24, new Object[] {A1EstadoID});
            A2EstadoDescripcion = BC000G26_A2EstadoDescripcion[0];
            A16PaisID = BC000G26_A16PaisID[0];
            pr_default.close(24);
            /* Using cursor BC000G27 */
            pr_default.execute(25, new Object[] {A16PaisID});
            A17PaisDescripcion = BC000G27_A17PaisDescripcion[0];
            pr_default.close(25);
            /* Using cursor BC000G28 */
            pr_default.execute(26, new Object[] {A26MedidaID});
            A28MedidaDescripcion = BC000G28_A28MedidaDescripcion[0];
            A74MedidaRin = BC000G28_A74MedidaRin[0];
            A27MedidaCodigo = BC000G28_A27MedidaCodigo[0];
            A22ModeloID = BC000G28_A22ModeloID[0];
            pr_default.close(26);
            /* Using cursor BC000G29 */
            pr_default.execute(27, new Object[] {A22ModeloID});
            A23ModeloDescripcion = BC000G29_A23ModeloDescripcion[0];
            pr_default.close(27);
         }
      }

      protected void EndLevel0G16( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G16( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0G16( )
      {
         /* Using cursor BC000G30 */
         pr_default.execute(28, new Object[] {A77FacturaMedidaID});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound16 = 1;
            A77FacturaMedidaID = BC000G30_A77FacturaMedidaID[0];
            A42PromocionDescripcion = BC000G30_A42PromocionDescripcion[0];
            A43PromocionBase = BC000G30_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000G30_A40000PromocionArte_GXI[0];
            A71FacturaNo = BC000G30_A71FacturaNo[0];
            A73FacturaFechaFactura = BC000G30_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = BC000G30_A72FacturaFechaRegistro[0];
            A63UsuarioZona = BC000G30_A63UsuarioZona[0];
            A2EstadoDescripcion = BC000G30_A2EstadoDescripcion[0];
            A5CiudadDescripcion = BC000G30_A5CiudadDescripcion[0];
            A17PaisDescripcion = BC000G30_A17PaisDescripcion[0];
            A53UsuarioGenero = BC000G30_A53UsuarioGenero[0];
            A40001FacturaPDF_GXI = BC000G30_A40001FacturaPDF_GXI[0];
            A80FacturaEstatus = BC000G30_A80FacturaEstatus[0];
            A20MotivoRechazoDescripcion = BC000G30_A20MotivoRechazoDescripcion[0];
            A21MotivoRechazoActivo = BC000G30_A21MotivoRechazoActivo[0];
            A28MedidaDescripcion = BC000G30_A28MedidaDescripcion[0];
            A74MedidaRin = BC000G30_A74MedidaRin[0];
            A27MedidaCodigo = BC000G30_A27MedidaCodigo[0];
            A23ModeloDescripcion = BC000G30_A23ModeloDescripcion[0];
            A78FacturaMedidaCantidad = BC000G30_A78FacturaMedidaCantidad[0];
            A79FacturaMedidaPrecio = BC000G30_A79FacturaMedidaPrecio[0];
            A30UsuarioNombre = BC000G30_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000G30_A51UsuarioApellido[0];
            A31UsuarioCorreo = BC000G30_A31UsuarioCorreo[0];
            A32UsuarioPass = BC000G30_A32UsuarioPass[0];
            A33UsuarioKey = BC000G30_A33UsuarioKey[0];
            A14PuestoDescripcion = BC000G30_A14PuestoDescripcion[0];
            A54UsuarioDirectoAsociado = BC000G30_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = BC000G30_n54UsuarioDirectoAsociado[0];
            A55UsuarioRazonSocialAsociado = BC000G30_A55UsuarioRazonSocialAsociado[0];
            A56UsuarioNombreComercial = BC000G30_A56UsuarioNombreComercial[0];
            A57UsuarioFechaNacimiento = BC000G30_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = BC000G30_n57UsuarioFechaNacimiento[0];
            A59UsuarioCalleNum = BC000G30_A59UsuarioCalleNum[0];
            A60UsuarioColonia = BC000G30_A60UsuarioColonia[0];
            A61UsuarioDelegacion = BC000G30_A61UsuarioDelegacion[0];
            A62UsuarioCP = BC000G30_A62UsuarioCP[0];
            A64UsuarioCelular = BC000G30_A64UsuarioCelular[0];
            A65UsuarioTelefonoSucursal = BC000G30_A65UsuarioTelefonoSucursal[0];
            A66UsuarioSucursal = BC000G30_A66UsuarioSucursal[0];
            A67UsuarioProducto = BC000G30_A67UsuarioProducto[0];
            n67UsuarioProducto = BC000G30_n67UsuarioProducto[0];
            A40UsuarioRol = BC000G30_A40UsuarioRol[0];
            A82UsuarioNoCuentaBROXEL = BC000G30_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = BC000G30_A83UsuarioReferenciaBROXEL[0];
            A45PromocionFechaInicio = BC000G30_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000G30_A46PromocionFechaFin[0];
            A69FacturaID = BC000G30_A69FacturaID[0];
            A26MedidaID = BC000G30_A26MedidaID[0];
            A41PromocionID = BC000G30_A41PromocionID[0];
            A19MotivoRechazoID = BC000G30_A19MotivoRechazoID[0];
            A29UsuarioID = BC000G30_A29UsuarioID[0];
            A13PuestoID = BC000G30_A13PuestoID[0];
            n13PuestoID = BC000G30_n13PuestoID[0];
            A4CiudadID = BC000G30_A4CiudadID[0];
            n4CiudadID = BC000G30_n4CiudadID[0];
            A1EstadoID = BC000G30_A1EstadoID[0];
            A16PaisID = BC000G30_A16PaisID[0];
            A22ModeloID = BC000G30_A22ModeloID[0];
            A44PromocionArte = BC000G30_A44PromocionArte[0];
            A75FacturaPDF = BC000G30_A75FacturaPDF[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0G16( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound16 = 0;
         ScanKeyLoad0G16( ) ;
      }

      protected void ScanKeyLoad0G16( )
      {
         sMode16 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound16 = 1;
            A77FacturaMedidaID = BC000G30_A77FacturaMedidaID[0];
            A42PromocionDescripcion = BC000G30_A42PromocionDescripcion[0];
            A43PromocionBase = BC000G30_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000G30_A40000PromocionArte_GXI[0];
            A71FacturaNo = BC000G30_A71FacturaNo[0];
            A73FacturaFechaFactura = BC000G30_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = BC000G30_A72FacturaFechaRegistro[0];
            A63UsuarioZona = BC000G30_A63UsuarioZona[0];
            A2EstadoDescripcion = BC000G30_A2EstadoDescripcion[0];
            A5CiudadDescripcion = BC000G30_A5CiudadDescripcion[0];
            A17PaisDescripcion = BC000G30_A17PaisDescripcion[0];
            A53UsuarioGenero = BC000G30_A53UsuarioGenero[0];
            A40001FacturaPDF_GXI = BC000G30_A40001FacturaPDF_GXI[0];
            A80FacturaEstatus = BC000G30_A80FacturaEstatus[0];
            A20MotivoRechazoDescripcion = BC000G30_A20MotivoRechazoDescripcion[0];
            A21MotivoRechazoActivo = BC000G30_A21MotivoRechazoActivo[0];
            A28MedidaDescripcion = BC000G30_A28MedidaDescripcion[0];
            A74MedidaRin = BC000G30_A74MedidaRin[0];
            A27MedidaCodigo = BC000G30_A27MedidaCodigo[0];
            A23ModeloDescripcion = BC000G30_A23ModeloDescripcion[0];
            A78FacturaMedidaCantidad = BC000G30_A78FacturaMedidaCantidad[0];
            A79FacturaMedidaPrecio = BC000G30_A79FacturaMedidaPrecio[0];
            A30UsuarioNombre = BC000G30_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000G30_A51UsuarioApellido[0];
            A31UsuarioCorreo = BC000G30_A31UsuarioCorreo[0];
            A32UsuarioPass = BC000G30_A32UsuarioPass[0];
            A33UsuarioKey = BC000G30_A33UsuarioKey[0];
            A14PuestoDescripcion = BC000G30_A14PuestoDescripcion[0];
            A54UsuarioDirectoAsociado = BC000G30_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = BC000G30_n54UsuarioDirectoAsociado[0];
            A55UsuarioRazonSocialAsociado = BC000G30_A55UsuarioRazonSocialAsociado[0];
            A56UsuarioNombreComercial = BC000G30_A56UsuarioNombreComercial[0];
            A57UsuarioFechaNacimiento = BC000G30_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = BC000G30_n57UsuarioFechaNacimiento[0];
            A59UsuarioCalleNum = BC000G30_A59UsuarioCalleNum[0];
            A60UsuarioColonia = BC000G30_A60UsuarioColonia[0];
            A61UsuarioDelegacion = BC000G30_A61UsuarioDelegacion[0];
            A62UsuarioCP = BC000G30_A62UsuarioCP[0];
            A64UsuarioCelular = BC000G30_A64UsuarioCelular[0];
            A65UsuarioTelefonoSucursal = BC000G30_A65UsuarioTelefonoSucursal[0];
            A66UsuarioSucursal = BC000G30_A66UsuarioSucursal[0];
            A67UsuarioProducto = BC000G30_A67UsuarioProducto[0];
            n67UsuarioProducto = BC000G30_n67UsuarioProducto[0];
            A40UsuarioRol = BC000G30_A40UsuarioRol[0];
            A82UsuarioNoCuentaBROXEL = BC000G30_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = BC000G30_A83UsuarioReferenciaBROXEL[0];
            A45PromocionFechaInicio = BC000G30_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000G30_A46PromocionFechaFin[0];
            A69FacturaID = BC000G30_A69FacturaID[0];
            A26MedidaID = BC000G30_A26MedidaID[0];
            A41PromocionID = BC000G30_A41PromocionID[0];
            A19MotivoRechazoID = BC000G30_A19MotivoRechazoID[0];
            A29UsuarioID = BC000G30_A29UsuarioID[0];
            A13PuestoID = BC000G30_A13PuestoID[0];
            n13PuestoID = BC000G30_n13PuestoID[0];
            A4CiudadID = BC000G30_A4CiudadID[0];
            n4CiudadID = BC000G30_n4CiudadID[0];
            A1EstadoID = BC000G30_A1EstadoID[0];
            A16PaisID = BC000G30_A16PaisID[0];
            A22ModeloID = BC000G30_A22ModeloID[0];
            A44PromocionArte = BC000G30_A44PromocionArte[0];
            A75FacturaPDF = BC000G30_A75FacturaPDF[0];
         }
         Gx_mode = sMode16;
      }

      protected void ScanKeyEnd0G16( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm0G16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G16( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G16( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G16( )
      {
      }

      protected void send_integrity_lvl_hashes0G16( )
      {
      }

      protected void AddRow0G16( )
      {
         VarsToRow16( bcFacturaMedida) ;
      }

      protected void ReadRow0G16( )
      {
         RowToVars16( bcFacturaMedida, 1) ;
      }

      protected void InitializeNonKey0G16( )
      {
         A52UsuarioNombreCompleto = "";
         A69FacturaID = 0;
         A42PromocionDescripcion = "";
         A43PromocionBase = "";
         A44PromocionArte = "";
         A40000PromocionArte_GXI = "";
         A70PromocionVigencia = "";
         A71FacturaNo = "";
         A73FacturaFechaFactura = DateTime.MinValue;
         A72FacturaFechaRegistro = DateTime.MinValue;
         A29UsuarioID = 0;
         A63UsuarioZona = "";
         A2EstadoDescripcion = "";
         A5CiudadDescripcion = "";
         A17PaisDescripcion = "";
         A53UsuarioGenero = "";
         A75FacturaPDF = "";
         A40001FacturaPDF_GXI = "";
         A80FacturaEstatus = "";
         A19MotivoRechazoID = 0;
         A20MotivoRechazoDescripcion = "";
         A21MotivoRechazoActivo = false;
         A41PromocionID = 0;
         A26MedidaID = 0;
         A28MedidaDescripcion = "";
         A74MedidaRin = "";
         A27MedidaCodigo = "";
         A22ModeloID = 0;
         A23ModeloDescripcion = "";
         A78FacturaMedidaCantidad = 0;
         A79FacturaMedidaPrecio = 0;
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A31UsuarioCorreo = "";
         A32UsuarioPass = "";
         A33UsuarioKey = "";
         A13PuestoID = 0;
         n13PuestoID = false;
         A14PuestoDescripcion = "";
         A54UsuarioDirectoAsociado = "";
         n54UsuarioDirectoAsociado = false;
         A55UsuarioRazonSocialAsociado = "";
         A56UsuarioNombreComercial = "";
         A57UsuarioFechaNacimiento = DateTime.MinValue;
         n57UsuarioFechaNacimiento = false;
         A59UsuarioCalleNum = "";
         A60UsuarioColonia = "";
         A61UsuarioDelegacion = "";
         A62UsuarioCP = 0;
         A64UsuarioCelular = 0;
         A65UsuarioTelefonoSucursal = 0;
         A16PaisID = 0;
         A1EstadoID = 0;
         A4CiudadID = 0;
         n4CiudadID = false;
         A66UsuarioSucursal = "";
         A67UsuarioProducto = "";
         n67UsuarioProducto = false;
         A40UsuarioRol = "";
         A82UsuarioNoCuentaBROXEL = "";
         A83UsuarioReferenciaBROXEL = "";
         A45PromocionFechaInicio = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         Z78FacturaMedidaCantidad = 0;
         Z79FacturaMedidaPrecio = 0;
         Z69FacturaID = 0;
         Z26MedidaID = 0;
      }

      protected void InitAll0G16( )
      {
         A77FacturaMedidaID = 0;
         InitializeNonKey0G16( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow16( SdtFacturaMedida obj16 )
      {
         obj16.gxTpr_Mode = Gx_mode;
         obj16.gxTpr_Usuarionombrecompleto = A52UsuarioNombreCompleto;
         obj16.gxTpr_Facturaid = A69FacturaID;
         obj16.gxTpr_Promociondescripcion = A42PromocionDescripcion;
         obj16.gxTpr_Promocionbase = A43PromocionBase;
         obj16.gxTpr_Promocionarte = A44PromocionArte;
         obj16.gxTpr_Promocionarte_gxi = A40000PromocionArte_GXI;
         obj16.gxTpr_Promocionvigencia = A70PromocionVigencia;
         obj16.gxTpr_Facturano = A71FacturaNo;
         obj16.gxTpr_Facturafechafactura = A73FacturaFechaFactura;
         obj16.gxTpr_Facturafecharegistro = A72FacturaFechaRegistro;
         obj16.gxTpr_Usuarioid = A29UsuarioID;
         obj16.gxTpr_Usuariozona = A63UsuarioZona;
         obj16.gxTpr_Estadodescripcion = A2EstadoDescripcion;
         obj16.gxTpr_Ciudaddescripcion = A5CiudadDescripcion;
         obj16.gxTpr_Paisdescripcion = A17PaisDescripcion;
         obj16.gxTpr_Usuariogenero = A53UsuarioGenero;
         obj16.gxTpr_Facturapdf = A75FacturaPDF;
         obj16.gxTpr_Facturapdf_gxi = A40001FacturaPDF_GXI;
         obj16.gxTpr_Facturaestatus = A80FacturaEstatus;
         obj16.gxTpr_Motivorechazoid = A19MotivoRechazoID;
         obj16.gxTpr_Motivorechazodescripcion = A20MotivoRechazoDescripcion;
         obj16.gxTpr_Motivorechazoactivo = A21MotivoRechazoActivo;
         obj16.gxTpr_Promocionid = A41PromocionID;
         obj16.gxTpr_Medidaid = A26MedidaID;
         obj16.gxTpr_Medidadescripcion = A28MedidaDescripcion;
         obj16.gxTpr_Medidarin = A74MedidaRin;
         obj16.gxTpr_Medidacodigo = A27MedidaCodigo;
         obj16.gxTpr_Modeloid = A22ModeloID;
         obj16.gxTpr_Modelodescripcion = A23ModeloDescripcion;
         obj16.gxTpr_Facturamedidacantidad = A78FacturaMedidaCantidad;
         obj16.gxTpr_Facturamedidaprecio = A79FacturaMedidaPrecio;
         obj16.gxTpr_Usuarionombre = A30UsuarioNombre;
         obj16.gxTpr_Usuarioapellido = A51UsuarioApellido;
         obj16.gxTpr_Usuariocorreo = A31UsuarioCorreo;
         obj16.gxTpr_Usuariopass = A32UsuarioPass;
         obj16.gxTpr_Usuariokey = A33UsuarioKey;
         obj16.gxTpr_Puestoid = A13PuestoID;
         obj16.gxTpr_Puestodescripcion = A14PuestoDescripcion;
         obj16.gxTpr_Usuariodirectoasociado = A54UsuarioDirectoAsociado;
         obj16.gxTpr_Usuariorazonsocialasociado = A55UsuarioRazonSocialAsociado;
         obj16.gxTpr_Usuarionombrecomercial = A56UsuarioNombreComercial;
         obj16.gxTpr_Usuariofechanacimiento = A57UsuarioFechaNacimiento;
         obj16.gxTpr_Usuariocallenum = A59UsuarioCalleNum;
         obj16.gxTpr_Usuariocolonia = A60UsuarioColonia;
         obj16.gxTpr_Usuariodelegacion = A61UsuarioDelegacion;
         obj16.gxTpr_Usuariocp = A62UsuarioCP;
         obj16.gxTpr_Usuariocelular = A64UsuarioCelular;
         obj16.gxTpr_Usuariotelefonosucursal = A65UsuarioTelefonoSucursal;
         obj16.gxTpr_Paisid = A16PaisID;
         obj16.gxTpr_Estadoid = A1EstadoID;
         obj16.gxTpr_Ciudadid = A4CiudadID;
         obj16.gxTpr_Usuariosucursal = A66UsuarioSucursal;
         obj16.gxTpr_Usuarioproducto = A67UsuarioProducto;
         obj16.gxTpr_Usuariorol = A40UsuarioRol;
         obj16.gxTpr_Usuarionocuentabroxel = A82UsuarioNoCuentaBROXEL;
         obj16.gxTpr_Usuarioreferenciabroxel = A83UsuarioReferenciaBROXEL;
         obj16.gxTpr_Facturamedidaid = A77FacturaMedidaID;
         obj16.gxTpr_Facturamedidaid_Z = Z77FacturaMedidaID;
         obj16.gxTpr_Facturaid_Z = Z69FacturaID;
         obj16.gxTpr_Promociondescripcion_Z = Z42PromocionDescripcion;
         obj16.gxTpr_Promocionbase_Z = Z43PromocionBase;
         obj16.gxTpr_Promocionvigencia_Z = Z70PromocionVigencia;
         obj16.gxTpr_Facturano_Z = Z71FacturaNo;
         obj16.gxTpr_Facturafechafactura_Z = Z73FacturaFechaFactura;
         obj16.gxTpr_Facturafecharegistro_Z = Z72FacturaFechaRegistro;
         obj16.gxTpr_Usuarioid_Z = Z29UsuarioID;
         obj16.gxTpr_Usuarionombrecompleto_Z = Z52UsuarioNombreCompleto;
         obj16.gxTpr_Usuariozona_Z = Z63UsuarioZona;
         obj16.gxTpr_Estadodescripcion_Z = Z2EstadoDescripcion;
         obj16.gxTpr_Ciudaddescripcion_Z = Z5CiudadDescripcion;
         obj16.gxTpr_Paisdescripcion_Z = Z17PaisDescripcion;
         obj16.gxTpr_Usuariogenero_Z = Z53UsuarioGenero;
         obj16.gxTpr_Facturaestatus_Z = Z80FacturaEstatus;
         obj16.gxTpr_Motivorechazoid_Z = Z19MotivoRechazoID;
         obj16.gxTpr_Motivorechazodescripcion_Z = Z20MotivoRechazoDescripcion;
         obj16.gxTpr_Motivorechazoactivo_Z = Z21MotivoRechazoActivo;
         obj16.gxTpr_Promocionid_Z = Z41PromocionID;
         obj16.gxTpr_Medidaid_Z = Z26MedidaID;
         obj16.gxTpr_Medidadescripcion_Z = Z28MedidaDescripcion;
         obj16.gxTpr_Medidarin_Z = Z74MedidaRin;
         obj16.gxTpr_Medidacodigo_Z = Z27MedidaCodigo;
         obj16.gxTpr_Modeloid_Z = Z22ModeloID;
         obj16.gxTpr_Modelodescripcion_Z = Z23ModeloDescripcion;
         obj16.gxTpr_Facturamedidacantidad_Z = Z78FacturaMedidaCantidad;
         obj16.gxTpr_Facturamedidaprecio_Z = Z79FacturaMedidaPrecio;
         obj16.gxTpr_Usuarionombre_Z = Z30UsuarioNombre;
         obj16.gxTpr_Usuarioapellido_Z = Z51UsuarioApellido;
         obj16.gxTpr_Usuariocorreo_Z = Z31UsuarioCorreo;
         obj16.gxTpr_Usuariopass_Z = Z32UsuarioPass;
         obj16.gxTpr_Usuariokey_Z = Z33UsuarioKey;
         obj16.gxTpr_Puestoid_Z = Z13PuestoID;
         obj16.gxTpr_Puestodescripcion_Z = Z14PuestoDescripcion;
         obj16.gxTpr_Usuariodirectoasociado_Z = Z54UsuarioDirectoAsociado;
         obj16.gxTpr_Usuariorazonsocialasociado_Z = Z55UsuarioRazonSocialAsociado;
         obj16.gxTpr_Usuarionombrecomercial_Z = Z56UsuarioNombreComercial;
         obj16.gxTpr_Usuariofechanacimiento_Z = Z57UsuarioFechaNacimiento;
         obj16.gxTpr_Usuariocallenum_Z = Z59UsuarioCalleNum;
         obj16.gxTpr_Usuariocolonia_Z = Z60UsuarioColonia;
         obj16.gxTpr_Usuariodelegacion_Z = Z61UsuarioDelegacion;
         obj16.gxTpr_Usuariocp_Z = Z62UsuarioCP;
         obj16.gxTpr_Usuariocelular_Z = Z64UsuarioCelular;
         obj16.gxTpr_Usuariotelefonosucursal_Z = Z65UsuarioTelefonoSucursal;
         obj16.gxTpr_Paisid_Z = Z16PaisID;
         obj16.gxTpr_Estadoid_Z = Z1EstadoID;
         obj16.gxTpr_Ciudadid_Z = Z4CiudadID;
         obj16.gxTpr_Usuariosucursal_Z = Z66UsuarioSucursal;
         obj16.gxTpr_Usuarioproducto_Z = Z67UsuarioProducto;
         obj16.gxTpr_Usuariorol_Z = Z40UsuarioRol;
         obj16.gxTpr_Usuarionocuentabroxel_Z = Z82UsuarioNoCuentaBROXEL;
         obj16.gxTpr_Usuarioreferenciabroxel_Z = Z83UsuarioReferenciaBROXEL;
         obj16.gxTpr_Promocionarte_gxi_Z = Z40000PromocionArte_GXI;
         obj16.gxTpr_Facturapdf_gxi_Z = Z40001FacturaPDF_GXI;
         obj16.gxTpr_Puestoid_N = (short)(Convert.ToInt16(n13PuestoID));
         obj16.gxTpr_Usuariodirectoasociado_N = (short)(Convert.ToInt16(n54UsuarioDirectoAsociado));
         obj16.gxTpr_Usuariofechanacimiento_N = (short)(Convert.ToInt16(n57UsuarioFechaNacimiento));
         obj16.gxTpr_Ciudadid_N = (short)(Convert.ToInt16(n4CiudadID));
         obj16.gxTpr_Usuarioproducto_N = (short)(Convert.ToInt16(n67UsuarioProducto));
         obj16.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow16( SdtFacturaMedida obj16 )
      {
         obj16.gxTpr_Facturamedidaid = A77FacturaMedidaID;
         return  ;
      }

      public void RowToVars16( SdtFacturaMedida obj16 ,
                               int forceLoad )
      {
         Gx_mode = obj16.gxTpr_Mode;
         A52UsuarioNombreCompleto = obj16.gxTpr_Usuarionombrecompleto;
         A69FacturaID = obj16.gxTpr_Facturaid;
         A42PromocionDescripcion = obj16.gxTpr_Promociondescripcion;
         A43PromocionBase = obj16.gxTpr_Promocionbase;
         A44PromocionArte = obj16.gxTpr_Promocionarte;
         A40000PromocionArte_GXI = obj16.gxTpr_Promocionarte_gxi;
         A70PromocionVigencia = obj16.gxTpr_Promocionvigencia;
         A71FacturaNo = obj16.gxTpr_Facturano;
         A73FacturaFechaFactura = obj16.gxTpr_Facturafechafactura;
         A72FacturaFechaRegistro = obj16.gxTpr_Facturafecharegistro;
         A29UsuarioID = obj16.gxTpr_Usuarioid;
         A63UsuarioZona = obj16.gxTpr_Usuariozona;
         A2EstadoDescripcion = obj16.gxTpr_Estadodescripcion;
         A5CiudadDescripcion = obj16.gxTpr_Ciudaddescripcion;
         A17PaisDescripcion = obj16.gxTpr_Paisdescripcion;
         A53UsuarioGenero = obj16.gxTpr_Usuariogenero;
         A75FacturaPDF = obj16.gxTpr_Facturapdf;
         A40001FacturaPDF_GXI = obj16.gxTpr_Facturapdf_gxi;
         A80FacturaEstatus = obj16.gxTpr_Facturaestatus;
         A19MotivoRechazoID = obj16.gxTpr_Motivorechazoid;
         A20MotivoRechazoDescripcion = obj16.gxTpr_Motivorechazodescripcion;
         A21MotivoRechazoActivo = obj16.gxTpr_Motivorechazoactivo;
         A41PromocionID = obj16.gxTpr_Promocionid;
         A26MedidaID = obj16.gxTpr_Medidaid;
         A28MedidaDescripcion = obj16.gxTpr_Medidadescripcion;
         A74MedidaRin = obj16.gxTpr_Medidarin;
         A27MedidaCodigo = obj16.gxTpr_Medidacodigo;
         A22ModeloID = obj16.gxTpr_Modeloid;
         A23ModeloDescripcion = obj16.gxTpr_Modelodescripcion;
         A78FacturaMedidaCantidad = obj16.gxTpr_Facturamedidacantidad;
         A79FacturaMedidaPrecio = obj16.gxTpr_Facturamedidaprecio;
         A30UsuarioNombre = obj16.gxTpr_Usuarionombre;
         A51UsuarioApellido = obj16.gxTpr_Usuarioapellido;
         A31UsuarioCorreo = obj16.gxTpr_Usuariocorreo;
         A32UsuarioPass = obj16.gxTpr_Usuariopass;
         A33UsuarioKey = obj16.gxTpr_Usuariokey;
         A13PuestoID = obj16.gxTpr_Puestoid;
         n13PuestoID = false;
         A14PuestoDescripcion = obj16.gxTpr_Puestodescripcion;
         A54UsuarioDirectoAsociado = obj16.gxTpr_Usuariodirectoasociado;
         n54UsuarioDirectoAsociado = false;
         A55UsuarioRazonSocialAsociado = obj16.gxTpr_Usuariorazonsocialasociado;
         A56UsuarioNombreComercial = obj16.gxTpr_Usuarionombrecomercial;
         A57UsuarioFechaNacimiento = obj16.gxTpr_Usuariofechanacimiento;
         n57UsuarioFechaNacimiento = false;
         A59UsuarioCalleNum = obj16.gxTpr_Usuariocallenum;
         A60UsuarioColonia = obj16.gxTpr_Usuariocolonia;
         A61UsuarioDelegacion = obj16.gxTpr_Usuariodelegacion;
         A62UsuarioCP = obj16.gxTpr_Usuariocp;
         A64UsuarioCelular = obj16.gxTpr_Usuariocelular;
         A65UsuarioTelefonoSucursal = obj16.gxTpr_Usuariotelefonosucursal;
         A16PaisID = obj16.gxTpr_Paisid;
         A1EstadoID = obj16.gxTpr_Estadoid;
         A4CiudadID = obj16.gxTpr_Ciudadid;
         n4CiudadID = false;
         A66UsuarioSucursal = obj16.gxTpr_Usuariosucursal;
         A67UsuarioProducto = obj16.gxTpr_Usuarioproducto;
         n67UsuarioProducto = false;
         A40UsuarioRol = obj16.gxTpr_Usuariorol;
         A82UsuarioNoCuentaBROXEL = obj16.gxTpr_Usuarionocuentabroxel;
         A83UsuarioReferenciaBROXEL = obj16.gxTpr_Usuarioreferenciabroxel;
         A77FacturaMedidaID = obj16.gxTpr_Facturamedidaid;
         Z77FacturaMedidaID = obj16.gxTpr_Facturamedidaid_Z;
         Z69FacturaID = obj16.gxTpr_Facturaid_Z;
         Z42PromocionDescripcion = obj16.gxTpr_Promociondescripcion_Z;
         Z43PromocionBase = obj16.gxTpr_Promocionbase_Z;
         Z70PromocionVigencia = obj16.gxTpr_Promocionvigencia_Z;
         Z71FacturaNo = obj16.gxTpr_Facturano_Z;
         Z73FacturaFechaFactura = obj16.gxTpr_Facturafechafactura_Z;
         Z72FacturaFechaRegistro = obj16.gxTpr_Facturafecharegistro_Z;
         Z29UsuarioID = obj16.gxTpr_Usuarioid_Z;
         Z52UsuarioNombreCompleto = obj16.gxTpr_Usuarionombrecompleto_Z;
         Z63UsuarioZona = obj16.gxTpr_Usuariozona_Z;
         Z2EstadoDescripcion = obj16.gxTpr_Estadodescripcion_Z;
         Z5CiudadDescripcion = obj16.gxTpr_Ciudaddescripcion_Z;
         Z17PaisDescripcion = obj16.gxTpr_Paisdescripcion_Z;
         Z53UsuarioGenero = obj16.gxTpr_Usuariogenero_Z;
         Z80FacturaEstatus = obj16.gxTpr_Facturaestatus_Z;
         Z19MotivoRechazoID = obj16.gxTpr_Motivorechazoid_Z;
         Z20MotivoRechazoDescripcion = obj16.gxTpr_Motivorechazodescripcion_Z;
         Z21MotivoRechazoActivo = obj16.gxTpr_Motivorechazoactivo_Z;
         Z41PromocionID = obj16.gxTpr_Promocionid_Z;
         Z26MedidaID = obj16.gxTpr_Medidaid_Z;
         Z28MedidaDescripcion = obj16.gxTpr_Medidadescripcion_Z;
         Z74MedidaRin = obj16.gxTpr_Medidarin_Z;
         Z27MedidaCodigo = obj16.gxTpr_Medidacodigo_Z;
         Z22ModeloID = obj16.gxTpr_Modeloid_Z;
         Z23ModeloDescripcion = obj16.gxTpr_Modelodescripcion_Z;
         Z78FacturaMedidaCantidad = obj16.gxTpr_Facturamedidacantidad_Z;
         Z79FacturaMedidaPrecio = obj16.gxTpr_Facturamedidaprecio_Z;
         Z30UsuarioNombre = obj16.gxTpr_Usuarionombre_Z;
         Z51UsuarioApellido = obj16.gxTpr_Usuarioapellido_Z;
         Z31UsuarioCorreo = obj16.gxTpr_Usuariocorreo_Z;
         Z32UsuarioPass = obj16.gxTpr_Usuariopass_Z;
         Z33UsuarioKey = obj16.gxTpr_Usuariokey_Z;
         Z13PuestoID = obj16.gxTpr_Puestoid_Z;
         Z14PuestoDescripcion = obj16.gxTpr_Puestodescripcion_Z;
         Z54UsuarioDirectoAsociado = obj16.gxTpr_Usuariodirectoasociado_Z;
         Z55UsuarioRazonSocialAsociado = obj16.gxTpr_Usuariorazonsocialasociado_Z;
         Z56UsuarioNombreComercial = obj16.gxTpr_Usuarionombrecomercial_Z;
         Z57UsuarioFechaNacimiento = obj16.gxTpr_Usuariofechanacimiento_Z;
         Z59UsuarioCalleNum = obj16.gxTpr_Usuariocallenum_Z;
         Z60UsuarioColonia = obj16.gxTpr_Usuariocolonia_Z;
         Z61UsuarioDelegacion = obj16.gxTpr_Usuariodelegacion_Z;
         Z62UsuarioCP = obj16.gxTpr_Usuariocp_Z;
         Z64UsuarioCelular = obj16.gxTpr_Usuariocelular_Z;
         Z65UsuarioTelefonoSucursal = obj16.gxTpr_Usuariotelefonosucursal_Z;
         Z16PaisID = obj16.gxTpr_Paisid_Z;
         Z1EstadoID = obj16.gxTpr_Estadoid_Z;
         Z4CiudadID = obj16.gxTpr_Ciudadid_Z;
         Z66UsuarioSucursal = obj16.gxTpr_Usuariosucursal_Z;
         Z67UsuarioProducto = obj16.gxTpr_Usuarioproducto_Z;
         Z40UsuarioRol = obj16.gxTpr_Usuariorol_Z;
         Z82UsuarioNoCuentaBROXEL = obj16.gxTpr_Usuarionocuentabroxel_Z;
         Z83UsuarioReferenciaBROXEL = obj16.gxTpr_Usuarioreferenciabroxel_Z;
         Z40000PromocionArte_GXI = obj16.gxTpr_Promocionarte_gxi_Z;
         Z40001FacturaPDF_GXI = obj16.gxTpr_Facturapdf_gxi_Z;
         n13PuestoID = (bool)(Convert.ToBoolean(obj16.gxTpr_Puestoid_N));
         n54UsuarioDirectoAsociado = (bool)(Convert.ToBoolean(obj16.gxTpr_Usuariodirectoasociado_N));
         n57UsuarioFechaNacimiento = (bool)(Convert.ToBoolean(obj16.gxTpr_Usuariofechanacimiento_N));
         n4CiudadID = (bool)(Convert.ToBoolean(obj16.gxTpr_Ciudadid_N));
         n67UsuarioProducto = (bool)(Convert.ToBoolean(obj16.gxTpr_Usuarioproducto_N));
         Gx_mode = obj16.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A77FacturaMedidaID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0G16( ) ;
         ScanKeyStart0G16( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z77FacturaMedidaID = A77FacturaMedidaID;
         }
         ZM0G16( -3) ;
         OnLoadActions0G16( ) ;
         AddRow0G16( ) ;
         ScanKeyEnd0G16( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars16( bcFacturaMedida, 0) ;
         ScanKeyStart0G16( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z77FacturaMedidaID = A77FacturaMedidaID;
         }
         ZM0G16( -3) ;
         OnLoadActions0G16( ) ;
         AddRow0G16( ) ;
         ScanKeyEnd0G16( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0G16( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0G16( ) ;
         }
         else
         {
            if ( RcdFound16 == 1 )
            {
               if ( A77FacturaMedidaID != Z77FacturaMedidaID )
               {
                  A77FacturaMedidaID = Z77FacturaMedidaID;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0G16( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A77FacturaMedidaID != Z77FacturaMedidaID )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0G16( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0G16( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars16( bcFacturaMedida, 1) ;
         SaveImpl( ) ;
         VarsToRow16( bcFacturaMedida) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars16( bcFacturaMedida, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G16( ) ;
         AfterTrn( ) ;
         VarsToRow16( bcFacturaMedida) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow16( bcFacturaMedida) ;
         }
         else
         {
            SdtFacturaMedida auxBC = new SdtFacturaMedida(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A77FacturaMedidaID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcFacturaMedida);
               auxBC.Save();
               bcFacturaMedida.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars16( bcFacturaMedida, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars16( bcFacturaMedida, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G16( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow16( bcFacturaMedida) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow16( bcFacturaMedida) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars16( bcFacturaMedida, 0) ;
         GetKey0G16( ) ;
         if ( RcdFound16 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A77FacturaMedidaID != Z77FacturaMedidaID )
            {
               A77FacturaMedidaID = Z77FacturaMedidaID;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A77FacturaMedidaID != Z77FacturaMedidaID )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("facturamedida_bc",pr_default);
         VarsToRow16( bcFacturaMedida) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcFacturaMedida.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcFacturaMedida.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcFacturaMedida )
         {
            bcFacturaMedida = (SdtFacturaMedida)(sdt);
            if ( StringUtil.StrCmp(bcFacturaMedida.gxTpr_Mode, "") == 0 )
            {
               bcFacturaMedida.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow16( bcFacturaMedida) ;
            }
            else
            {
               RowToVars16( bcFacturaMedida, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcFacturaMedida.gxTpr_Mode, "") == 0 )
            {
               bcFacturaMedida.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars16( bcFacturaMedida, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtFacturaMedida FacturaMedida_BC
      {
         get {
            return bcFacturaMedida ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(18);
         pr_default.close(26);
         pr_default.close(19);
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(22);
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(25);
         pr_default.close(27);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z70PromocionVigencia = "";
         A70PromocionVigencia = "";
         Z52UsuarioNombreCompleto = "";
         A52UsuarioNombreCompleto = "";
         Z71FacturaNo = "";
         A71FacturaNo = "";
         Z73FacturaFechaFactura = DateTime.MinValue;
         A73FacturaFechaFactura = DateTime.MinValue;
         Z72FacturaFechaRegistro = DateTime.MinValue;
         A72FacturaFechaRegistro = DateTime.MinValue;
         Z80FacturaEstatus = "";
         A80FacturaEstatus = "";
         Z28MedidaDescripcion = "";
         A28MedidaDescripcion = "";
         Z74MedidaRin = "";
         A74MedidaRin = "";
         Z27MedidaCodigo = "";
         A27MedidaCodigo = "";
         Z42PromocionDescripcion = "";
         A42PromocionDescripcion = "";
         Z43PromocionBase = "";
         A43PromocionBase = "";
         Z45PromocionFechaInicio = DateTime.MinValue;
         A45PromocionFechaInicio = DateTime.MinValue;
         Z46PromocionFechaFin = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         Z20MotivoRechazoDescripcion = "";
         A20MotivoRechazoDescripcion = "";
         Z63UsuarioZona = "";
         A63UsuarioZona = "";
         Z53UsuarioGenero = "";
         A53UsuarioGenero = "";
         Z30UsuarioNombre = "";
         A30UsuarioNombre = "";
         Z51UsuarioApellido = "";
         A51UsuarioApellido = "";
         Z31UsuarioCorreo = "";
         A31UsuarioCorreo = "";
         Z32UsuarioPass = "";
         A32UsuarioPass = "";
         Z33UsuarioKey = "";
         A33UsuarioKey = "";
         Z54UsuarioDirectoAsociado = "";
         A54UsuarioDirectoAsociado = "";
         Z55UsuarioRazonSocialAsociado = "";
         A55UsuarioRazonSocialAsociado = "";
         Z56UsuarioNombreComercial = "";
         A56UsuarioNombreComercial = "";
         Z57UsuarioFechaNacimiento = DateTime.MinValue;
         A57UsuarioFechaNacimiento = DateTime.MinValue;
         Z59UsuarioCalleNum = "";
         A59UsuarioCalleNum = "";
         Z60UsuarioColonia = "";
         A60UsuarioColonia = "";
         Z61UsuarioDelegacion = "";
         A61UsuarioDelegacion = "";
         Z66UsuarioSucursal = "";
         A66UsuarioSucursal = "";
         Z67UsuarioProducto = "";
         A67UsuarioProducto = "";
         Z40UsuarioRol = "";
         A40UsuarioRol = "";
         Z82UsuarioNoCuentaBROXEL = "";
         A82UsuarioNoCuentaBROXEL = "";
         Z83UsuarioReferenciaBROXEL = "";
         A83UsuarioReferenciaBROXEL = "";
         Z14PuestoDescripcion = "";
         A14PuestoDescripcion = "";
         Z5CiudadDescripcion = "";
         A5CiudadDescripcion = "";
         Z2EstadoDescripcion = "";
         A2EstadoDescripcion = "";
         Z17PaisDescripcion = "";
         A17PaisDescripcion = "";
         Z23ModeloDescripcion = "";
         A23ModeloDescripcion = "";
         Z75FacturaPDF = "";
         A75FacturaPDF = "";
         Z40001FacturaPDF_GXI = "";
         A40001FacturaPDF_GXI = "";
         Z44PromocionArte = "";
         A44PromocionArte = "";
         Z40000PromocionArte_GXI = "";
         A40000PromocionArte_GXI = "";
         BC000G14_A77FacturaMedidaID = new int[1] ;
         BC000G14_A42PromocionDescripcion = new string[] {""} ;
         BC000G14_A43PromocionBase = new string[] {""} ;
         BC000G14_A40000PromocionArte_GXI = new string[] {""} ;
         BC000G14_A71FacturaNo = new string[] {""} ;
         BC000G14_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         BC000G14_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         BC000G14_A63UsuarioZona = new string[] {""} ;
         BC000G14_A2EstadoDescripcion = new string[] {""} ;
         BC000G14_A5CiudadDescripcion = new string[] {""} ;
         BC000G14_A17PaisDescripcion = new string[] {""} ;
         BC000G14_A53UsuarioGenero = new string[] {""} ;
         BC000G14_A40001FacturaPDF_GXI = new string[] {""} ;
         BC000G14_A80FacturaEstatus = new string[] {""} ;
         BC000G14_A20MotivoRechazoDescripcion = new string[] {""} ;
         BC000G14_A21MotivoRechazoActivo = new bool[] {false} ;
         BC000G14_A28MedidaDescripcion = new string[] {""} ;
         BC000G14_A74MedidaRin = new string[] {""} ;
         BC000G14_A27MedidaCodigo = new string[] {""} ;
         BC000G14_A23ModeloDescripcion = new string[] {""} ;
         BC000G14_A78FacturaMedidaCantidad = new short[1] ;
         BC000G14_A79FacturaMedidaPrecio = new decimal[1] ;
         BC000G14_A30UsuarioNombre = new string[] {""} ;
         BC000G14_A51UsuarioApellido = new string[] {""} ;
         BC000G14_A31UsuarioCorreo = new string[] {""} ;
         BC000G14_A32UsuarioPass = new string[] {""} ;
         BC000G14_A33UsuarioKey = new string[] {""} ;
         BC000G14_A14PuestoDescripcion = new string[] {""} ;
         BC000G14_A54UsuarioDirectoAsociado = new string[] {""} ;
         BC000G14_n54UsuarioDirectoAsociado = new bool[] {false} ;
         BC000G14_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         BC000G14_A56UsuarioNombreComercial = new string[] {""} ;
         BC000G14_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000G14_n57UsuarioFechaNacimiento = new bool[] {false} ;
         BC000G14_A59UsuarioCalleNum = new string[] {""} ;
         BC000G14_A60UsuarioColonia = new string[] {""} ;
         BC000G14_A61UsuarioDelegacion = new string[] {""} ;
         BC000G14_A62UsuarioCP = new int[1] ;
         BC000G14_A64UsuarioCelular = new long[1] ;
         BC000G14_A65UsuarioTelefonoSucursal = new long[1] ;
         BC000G14_A66UsuarioSucursal = new string[] {""} ;
         BC000G14_A67UsuarioProducto = new string[] {""} ;
         BC000G14_n67UsuarioProducto = new bool[] {false} ;
         BC000G14_A40UsuarioRol = new string[] {""} ;
         BC000G14_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         BC000G14_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         BC000G14_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000G14_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000G14_A69FacturaID = new int[1] ;
         BC000G14_A26MedidaID = new int[1] ;
         BC000G14_A41PromocionID = new int[1] ;
         BC000G14_A19MotivoRechazoID = new int[1] ;
         BC000G14_A29UsuarioID = new int[1] ;
         BC000G14_A13PuestoID = new int[1] ;
         BC000G14_n13PuestoID = new bool[] {false} ;
         BC000G14_A4CiudadID = new int[1] ;
         BC000G14_n4CiudadID = new bool[] {false} ;
         BC000G14_A1EstadoID = new int[1] ;
         BC000G14_A16PaisID = new int[1] ;
         BC000G14_A22ModeloID = new int[1] ;
         BC000G14_A44PromocionArte = new string[] {""} ;
         BC000G14_A75FacturaPDF = new string[] {""} ;
         BC000G4_A71FacturaNo = new string[] {""} ;
         BC000G4_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         BC000G4_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         BC000G4_A40001FacturaPDF_GXI = new string[] {""} ;
         BC000G4_A80FacturaEstatus = new string[] {""} ;
         BC000G4_A41PromocionID = new int[1] ;
         BC000G4_A19MotivoRechazoID = new int[1] ;
         BC000G4_A29UsuarioID = new int[1] ;
         BC000G4_A75FacturaPDF = new string[] {""} ;
         BC000G6_A42PromocionDescripcion = new string[] {""} ;
         BC000G6_A43PromocionBase = new string[] {""} ;
         BC000G6_A40000PromocionArte_GXI = new string[] {""} ;
         BC000G6_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000G6_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000G6_A44PromocionArte = new string[] {""} ;
         BC000G7_A20MotivoRechazoDescripcion = new string[] {""} ;
         BC000G7_A21MotivoRechazoActivo = new bool[] {false} ;
         BC000G8_A63UsuarioZona = new string[] {""} ;
         BC000G8_A53UsuarioGenero = new string[] {""} ;
         BC000G8_A30UsuarioNombre = new string[] {""} ;
         BC000G8_A51UsuarioApellido = new string[] {""} ;
         BC000G8_A31UsuarioCorreo = new string[] {""} ;
         BC000G8_A32UsuarioPass = new string[] {""} ;
         BC000G8_A33UsuarioKey = new string[] {""} ;
         BC000G8_A54UsuarioDirectoAsociado = new string[] {""} ;
         BC000G8_n54UsuarioDirectoAsociado = new bool[] {false} ;
         BC000G8_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         BC000G8_A56UsuarioNombreComercial = new string[] {""} ;
         BC000G8_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000G8_n57UsuarioFechaNacimiento = new bool[] {false} ;
         BC000G8_A59UsuarioCalleNum = new string[] {""} ;
         BC000G8_A60UsuarioColonia = new string[] {""} ;
         BC000G8_A61UsuarioDelegacion = new string[] {""} ;
         BC000G8_A62UsuarioCP = new int[1] ;
         BC000G8_A64UsuarioCelular = new long[1] ;
         BC000G8_A65UsuarioTelefonoSucursal = new long[1] ;
         BC000G8_A66UsuarioSucursal = new string[] {""} ;
         BC000G8_A67UsuarioProducto = new string[] {""} ;
         BC000G8_n67UsuarioProducto = new bool[] {false} ;
         BC000G8_A40UsuarioRol = new string[] {""} ;
         BC000G8_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         BC000G8_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         BC000G8_A13PuestoID = new int[1] ;
         BC000G8_n13PuestoID = new bool[] {false} ;
         BC000G8_A4CiudadID = new int[1] ;
         BC000G8_n4CiudadID = new bool[] {false} ;
         BC000G9_A14PuestoDescripcion = new string[] {""} ;
         BC000G10_A5CiudadDescripcion = new string[] {""} ;
         BC000G10_A1EstadoID = new int[1] ;
         BC000G11_A2EstadoDescripcion = new string[] {""} ;
         BC000G11_A16PaisID = new int[1] ;
         BC000G12_A17PaisDescripcion = new string[] {""} ;
         BC000G5_A28MedidaDescripcion = new string[] {""} ;
         BC000G5_A74MedidaRin = new string[] {""} ;
         BC000G5_A27MedidaCodigo = new string[] {""} ;
         BC000G5_A22ModeloID = new int[1] ;
         BC000G13_A23ModeloDescripcion = new string[] {""} ;
         BC000G15_A77FacturaMedidaID = new int[1] ;
         BC000G3_A77FacturaMedidaID = new int[1] ;
         BC000G3_A78FacturaMedidaCantidad = new short[1] ;
         BC000G3_A79FacturaMedidaPrecio = new decimal[1] ;
         BC000G3_A69FacturaID = new int[1] ;
         BC000G3_A26MedidaID = new int[1] ;
         sMode16 = "";
         BC000G2_A77FacturaMedidaID = new int[1] ;
         BC000G2_A78FacturaMedidaCantidad = new short[1] ;
         BC000G2_A79FacturaMedidaPrecio = new decimal[1] ;
         BC000G2_A69FacturaID = new int[1] ;
         BC000G2_A26MedidaID = new int[1] ;
         BC000G17_A77FacturaMedidaID = new int[1] ;
         BC000G20_A71FacturaNo = new string[] {""} ;
         BC000G20_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         BC000G20_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         BC000G20_A40001FacturaPDF_GXI = new string[] {""} ;
         BC000G20_A80FacturaEstatus = new string[] {""} ;
         BC000G20_A41PromocionID = new int[1] ;
         BC000G20_A19MotivoRechazoID = new int[1] ;
         BC000G20_A29UsuarioID = new int[1] ;
         BC000G20_A75FacturaPDF = new string[] {""} ;
         BC000G21_A42PromocionDescripcion = new string[] {""} ;
         BC000G21_A43PromocionBase = new string[] {""} ;
         BC000G21_A40000PromocionArte_GXI = new string[] {""} ;
         BC000G21_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000G21_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000G21_A44PromocionArte = new string[] {""} ;
         BC000G22_A20MotivoRechazoDescripcion = new string[] {""} ;
         BC000G22_A21MotivoRechazoActivo = new bool[] {false} ;
         BC000G23_A63UsuarioZona = new string[] {""} ;
         BC000G23_A53UsuarioGenero = new string[] {""} ;
         BC000G23_A30UsuarioNombre = new string[] {""} ;
         BC000G23_A51UsuarioApellido = new string[] {""} ;
         BC000G23_A31UsuarioCorreo = new string[] {""} ;
         BC000G23_A32UsuarioPass = new string[] {""} ;
         BC000G23_A33UsuarioKey = new string[] {""} ;
         BC000G23_A54UsuarioDirectoAsociado = new string[] {""} ;
         BC000G23_n54UsuarioDirectoAsociado = new bool[] {false} ;
         BC000G23_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         BC000G23_A56UsuarioNombreComercial = new string[] {""} ;
         BC000G23_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000G23_n57UsuarioFechaNacimiento = new bool[] {false} ;
         BC000G23_A59UsuarioCalleNum = new string[] {""} ;
         BC000G23_A60UsuarioColonia = new string[] {""} ;
         BC000G23_A61UsuarioDelegacion = new string[] {""} ;
         BC000G23_A62UsuarioCP = new int[1] ;
         BC000G23_A64UsuarioCelular = new long[1] ;
         BC000G23_A65UsuarioTelefonoSucursal = new long[1] ;
         BC000G23_A66UsuarioSucursal = new string[] {""} ;
         BC000G23_A67UsuarioProducto = new string[] {""} ;
         BC000G23_n67UsuarioProducto = new bool[] {false} ;
         BC000G23_A40UsuarioRol = new string[] {""} ;
         BC000G23_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         BC000G23_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         BC000G23_A13PuestoID = new int[1] ;
         BC000G23_n13PuestoID = new bool[] {false} ;
         BC000G23_A4CiudadID = new int[1] ;
         BC000G23_n4CiudadID = new bool[] {false} ;
         BC000G24_A14PuestoDescripcion = new string[] {""} ;
         BC000G25_A5CiudadDescripcion = new string[] {""} ;
         BC000G25_A1EstadoID = new int[1] ;
         BC000G26_A2EstadoDescripcion = new string[] {""} ;
         BC000G26_A16PaisID = new int[1] ;
         BC000G27_A17PaisDescripcion = new string[] {""} ;
         BC000G28_A28MedidaDescripcion = new string[] {""} ;
         BC000G28_A74MedidaRin = new string[] {""} ;
         BC000G28_A27MedidaCodigo = new string[] {""} ;
         BC000G28_A22ModeloID = new int[1] ;
         BC000G29_A23ModeloDescripcion = new string[] {""} ;
         BC000G30_A77FacturaMedidaID = new int[1] ;
         BC000G30_A42PromocionDescripcion = new string[] {""} ;
         BC000G30_A43PromocionBase = new string[] {""} ;
         BC000G30_A40000PromocionArte_GXI = new string[] {""} ;
         BC000G30_A71FacturaNo = new string[] {""} ;
         BC000G30_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         BC000G30_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         BC000G30_A63UsuarioZona = new string[] {""} ;
         BC000G30_A2EstadoDescripcion = new string[] {""} ;
         BC000G30_A5CiudadDescripcion = new string[] {""} ;
         BC000G30_A17PaisDescripcion = new string[] {""} ;
         BC000G30_A53UsuarioGenero = new string[] {""} ;
         BC000G30_A40001FacturaPDF_GXI = new string[] {""} ;
         BC000G30_A80FacturaEstatus = new string[] {""} ;
         BC000G30_A20MotivoRechazoDescripcion = new string[] {""} ;
         BC000G30_A21MotivoRechazoActivo = new bool[] {false} ;
         BC000G30_A28MedidaDescripcion = new string[] {""} ;
         BC000G30_A74MedidaRin = new string[] {""} ;
         BC000G30_A27MedidaCodigo = new string[] {""} ;
         BC000G30_A23ModeloDescripcion = new string[] {""} ;
         BC000G30_A78FacturaMedidaCantidad = new short[1] ;
         BC000G30_A79FacturaMedidaPrecio = new decimal[1] ;
         BC000G30_A30UsuarioNombre = new string[] {""} ;
         BC000G30_A51UsuarioApellido = new string[] {""} ;
         BC000G30_A31UsuarioCorreo = new string[] {""} ;
         BC000G30_A32UsuarioPass = new string[] {""} ;
         BC000G30_A33UsuarioKey = new string[] {""} ;
         BC000G30_A14PuestoDescripcion = new string[] {""} ;
         BC000G30_A54UsuarioDirectoAsociado = new string[] {""} ;
         BC000G30_n54UsuarioDirectoAsociado = new bool[] {false} ;
         BC000G30_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         BC000G30_A56UsuarioNombreComercial = new string[] {""} ;
         BC000G30_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000G30_n57UsuarioFechaNacimiento = new bool[] {false} ;
         BC000G30_A59UsuarioCalleNum = new string[] {""} ;
         BC000G30_A60UsuarioColonia = new string[] {""} ;
         BC000G30_A61UsuarioDelegacion = new string[] {""} ;
         BC000G30_A62UsuarioCP = new int[1] ;
         BC000G30_A64UsuarioCelular = new long[1] ;
         BC000G30_A65UsuarioTelefonoSucursal = new long[1] ;
         BC000G30_A66UsuarioSucursal = new string[] {""} ;
         BC000G30_A67UsuarioProducto = new string[] {""} ;
         BC000G30_n67UsuarioProducto = new bool[] {false} ;
         BC000G30_A40UsuarioRol = new string[] {""} ;
         BC000G30_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         BC000G30_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         BC000G30_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000G30_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000G30_A69FacturaID = new int[1] ;
         BC000G30_A26MedidaID = new int[1] ;
         BC000G30_A41PromocionID = new int[1] ;
         BC000G30_A19MotivoRechazoID = new int[1] ;
         BC000G30_A29UsuarioID = new int[1] ;
         BC000G30_A13PuestoID = new int[1] ;
         BC000G30_n13PuestoID = new bool[] {false} ;
         BC000G30_A4CiudadID = new int[1] ;
         BC000G30_n4CiudadID = new bool[] {false} ;
         BC000G30_A1EstadoID = new int[1] ;
         BC000G30_A16PaisID = new int[1] ;
         BC000G30_A22ModeloID = new int[1] ;
         BC000G30_A44PromocionArte = new string[] {""} ;
         BC000G30_A75FacturaPDF = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.facturamedida_bc__default(),
            new Object[][] {
                new Object[] {
               BC000G2_A77FacturaMedidaID, BC000G2_A78FacturaMedidaCantidad, BC000G2_A79FacturaMedidaPrecio, BC000G2_A69FacturaID, BC000G2_A26MedidaID
               }
               , new Object[] {
               BC000G3_A77FacturaMedidaID, BC000G3_A78FacturaMedidaCantidad, BC000G3_A79FacturaMedidaPrecio, BC000G3_A69FacturaID, BC000G3_A26MedidaID
               }
               , new Object[] {
               BC000G4_A71FacturaNo, BC000G4_A73FacturaFechaFactura, BC000G4_A72FacturaFechaRegistro, BC000G4_A40001FacturaPDF_GXI, BC000G4_A80FacturaEstatus, BC000G4_A41PromocionID, BC000G4_A19MotivoRechazoID, BC000G4_A29UsuarioID, BC000G4_A75FacturaPDF
               }
               , new Object[] {
               BC000G5_A28MedidaDescripcion, BC000G5_A74MedidaRin, BC000G5_A27MedidaCodigo, BC000G5_A22ModeloID
               }
               , new Object[] {
               BC000G6_A42PromocionDescripcion, BC000G6_A43PromocionBase, BC000G6_A40000PromocionArte_GXI, BC000G6_A45PromocionFechaInicio, BC000G6_A46PromocionFechaFin, BC000G6_A44PromocionArte
               }
               , new Object[] {
               BC000G7_A20MotivoRechazoDescripcion, BC000G7_A21MotivoRechazoActivo
               }
               , new Object[] {
               BC000G8_A63UsuarioZona, BC000G8_A53UsuarioGenero, BC000G8_A30UsuarioNombre, BC000G8_A51UsuarioApellido, BC000G8_A31UsuarioCorreo, BC000G8_A32UsuarioPass, BC000G8_A33UsuarioKey, BC000G8_A54UsuarioDirectoAsociado, BC000G8_n54UsuarioDirectoAsociado, BC000G8_A55UsuarioRazonSocialAsociado,
               BC000G8_A56UsuarioNombreComercial, BC000G8_A57UsuarioFechaNacimiento, BC000G8_n57UsuarioFechaNacimiento, BC000G8_A59UsuarioCalleNum, BC000G8_A60UsuarioColonia, BC000G8_A61UsuarioDelegacion, BC000G8_A62UsuarioCP, BC000G8_A64UsuarioCelular, BC000G8_A65UsuarioTelefonoSucursal, BC000G8_A66UsuarioSucursal,
               BC000G8_A67UsuarioProducto, BC000G8_n67UsuarioProducto, BC000G8_A40UsuarioRol, BC000G8_A82UsuarioNoCuentaBROXEL, BC000G8_A83UsuarioReferenciaBROXEL, BC000G8_A13PuestoID, BC000G8_n13PuestoID, BC000G8_A4CiudadID, BC000G8_n4CiudadID
               }
               , new Object[] {
               BC000G9_A14PuestoDescripcion
               }
               , new Object[] {
               BC000G10_A5CiudadDescripcion, BC000G10_A1EstadoID
               }
               , new Object[] {
               BC000G11_A2EstadoDescripcion, BC000G11_A16PaisID
               }
               , new Object[] {
               BC000G12_A17PaisDescripcion
               }
               , new Object[] {
               BC000G13_A23ModeloDescripcion
               }
               , new Object[] {
               BC000G14_A77FacturaMedidaID, BC000G14_A42PromocionDescripcion, BC000G14_A43PromocionBase, BC000G14_A40000PromocionArte_GXI, BC000G14_A71FacturaNo, BC000G14_A73FacturaFechaFactura, BC000G14_A72FacturaFechaRegistro, BC000G14_A63UsuarioZona, BC000G14_A2EstadoDescripcion, BC000G14_A5CiudadDescripcion,
               BC000G14_A17PaisDescripcion, BC000G14_A53UsuarioGenero, BC000G14_A40001FacturaPDF_GXI, BC000G14_A80FacturaEstatus, BC000G14_A20MotivoRechazoDescripcion, BC000G14_A21MotivoRechazoActivo, BC000G14_A28MedidaDescripcion, BC000G14_A74MedidaRin, BC000G14_A27MedidaCodigo, BC000G14_A23ModeloDescripcion,
               BC000G14_A78FacturaMedidaCantidad, BC000G14_A79FacturaMedidaPrecio, BC000G14_A30UsuarioNombre, BC000G14_A51UsuarioApellido, BC000G14_A31UsuarioCorreo, BC000G14_A32UsuarioPass, BC000G14_A33UsuarioKey, BC000G14_A14PuestoDescripcion, BC000G14_A54UsuarioDirectoAsociado, BC000G14_n54UsuarioDirectoAsociado,
               BC000G14_A55UsuarioRazonSocialAsociado, BC000G14_A56UsuarioNombreComercial, BC000G14_A57UsuarioFechaNacimiento, BC000G14_n57UsuarioFechaNacimiento, BC000G14_A59UsuarioCalleNum, BC000G14_A60UsuarioColonia, BC000G14_A61UsuarioDelegacion, BC000G14_A62UsuarioCP, BC000G14_A64UsuarioCelular, BC000G14_A65UsuarioTelefonoSucursal,
               BC000G14_A66UsuarioSucursal, BC000G14_A67UsuarioProducto, BC000G14_n67UsuarioProducto, BC000G14_A40UsuarioRol, BC000G14_A82UsuarioNoCuentaBROXEL, BC000G14_A83UsuarioReferenciaBROXEL, BC000G14_A45PromocionFechaInicio, BC000G14_A46PromocionFechaFin, BC000G14_A69FacturaID, BC000G14_A26MedidaID,
               BC000G14_A41PromocionID, BC000G14_A19MotivoRechazoID, BC000G14_A29UsuarioID, BC000G14_A13PuestoID, BC000G14_n13PuestoID, BC000G14_A4CiudadID, BC000G14_n4CiudadID, BC000G14_A1EstadoID, BC000G14_A16PaisID, BC000G14_A22ModeloID,
               BC000G14_A44PromocionArte, BC000G14_A75FacturaPDF
               }
               , new Object[] {
               BC000G15_A77FacturaMedidaID
               }
               , new Object[] {
               }
               , new Object[] {
               BC000G17_A77FacturaMedidaID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000G20_A71FacturaNo, BC000G20_A73FacturaFechaFactura, BC000G20_A72FacturaFechaRegistro, BC000G20_A40001FacturaPDF_GXI, BC000G20_A80FacturaEstatus, BC000G20_A41PromocionID, BC000G20_A19MotivoRechazoID, BC000G20_A29UsuarioID, BC000G20_A75FacturaPDF
               }
               , new Object[] {
               BC000G21_A42PromocionDescripcion, BC000G21_A43PromocionBase, BC000G21_A40000PromocionArte_GXI, BC000G21_A45PromocionFechaInicio, BC000G21_A46PromocionFechaFin, BC000G21_A44PromocionArte
               }
               , new Object[] {
               BC000G22_A20MotivoRechazoDescripcion, BC000G22_A21MotivoRechazoActivo
               }
               , new Object[] {
               BC000G23_A63UsuarioZona, BC000G23_A53UsuarioGenero, BC000G23_A30UsuarioNombre, BC000G23_A51UsuarioApellido, BC000G23_A31UsuarioCorreo, BC000G23_A32UsuarioPass, BC000G23_A33UsuarioKey, BC000G23_A54UsuarioDirectoAsociado, BC000G23_n54UsuarioDirectoAsociado, BC000G23_A55UsuarioRazonSocialAsociado,
               BC000G23_A56UsuarioNombreComercial, BC000G23_A57UsuarioFechaNacimiento, BC000G23_n57UsuarioFechaNacimiento, BC000G23_A59UsuarioCalleNum, BC000G23_A60UsuarioColonia, BC000G23_A61UsuarioDelegacion, BC000G23_A62UsuarioCP, BC000G23_A64UsuarioCelular, BC000G23_A65UsuarioTelefonoSucursal, BC000G23_A66UsuarioSucursal,
               BC000G23_A67UsuarioProducto, BC000G23_n67UsuarioProducto, BC000G23_A40UsuarioRol, BC000G23_A82UsuarioNoCuentaBROXEL, BC000G23_A83UsuarioReferenciaBROXEL, BC000G23_A13PuestoID, BC000G23_n13PuestoID, BC000G23_A4CiudadID, BC000G23_n4CiudadID
               }
               , new Object[] {
               BC000G24_A14PuestoDescripcion
               }
               , new Object[] {
               BC000G25_A5CiudadDescripcion, BC000G25_A1EstadoID
               }
               , new Object[] {
               BC000G26_A2EstadoDescripcion, BC000G26_A16PaisID
               }
               , new Object[] {
               BC000G27_A17PaisDescripcion
               }
               , new Object[] {
               BC000G28_A28MedidaDescripcion, BC000G28_A74MedidaRin, BC000G28_A27MedidaCodigo, BC000G28_A22ModeloID
               }
               , new Object[] {
               BC000G29_A23ModeloDescripcion
               }
               , new Object[] {
               BC000G30_A77FacturaMedidaID, BC000G30_A42PromocionDescripcion, BC000G30_A43PromocionBase, BC000G30_A40000PromocionArte_GXI, BC000G30_A71FacturaNo, BC000G30_A73FacturaFechaFactura, BC000G30_A72FacturaFechaRegistro, BC000G30_A63UsuarioZona, BC000G30_A2EstadoDescripcion, BC000G30_A5CiudadDescripcion,
               BC000G30_A17PaisDescripcion, BC000G30_A53UsuarioGenero, BC000G30_A40001FacturaPDF_GXI, BC000G30_A80FacturaEstatus, BC000G30_A20MotivoRechazoDescripcion, BC000G30_A21MotivoRechazoActivo, BC000G30_A28MedidaDescripcion, BC000G30_A74MedidaRin, BC000G30_A27MedidaCodigo, BC000G30_A23ModeloDescripcion,
               BC000G30_A78FacturaMedidaCantidad, BC000G30_A79FacturaMedidaPrecio, BC000G30_A30UsuarioNombre, BC000G30_A51UsuarioApellido, BC000G30_A31UsuarioCorreo, BC000G30_A32UsuarioPass, BC000G30_A33UsuarioKey, BC000G30_A14PuestoDescripcion, BC000G30_A54UsuarioDirectoAsociado, BC000G30_n54UsuarioDirectoAsociado,
               BC000G30_A55UsuarioRazonSocialAsociado, BC000G30_A56UsuarioNombreComercial, BC000G30_A57UsuarioFechaNacimiento, BC000G30_n57UsuarioFechaNacimiento, BC000G30_A59UsuarioCalleNum, BC000G30_A60UsuarioColonia, BC000G30_A61UsuarioDelegacion, BC000G30_A62UsuarioCP, BC000G30_A64UsuarioCelular, BC000G30_A65UsuarioTelefonoSucursal,
               BC000G30_A66UsuarioSucursal, BC000G30_A67UsuarioProducto, BC000G30_n67UsuarioProducto, BC000G30_A40UsuarioRol, BC000G30_A82UsuarioNoCuentaBROXEL, BC000G30_A83UsuarioReferenciaBROXEL, BC000G30_A45PromocionFechaInicio, BC000G30_A46PromocionFechaFin, BC000G30_A69FacturaID, BC000G30_A26MedidaID,
               BC000G30_A41PromocionID, BC000G30_A19MotivoRechazoID, BC000G30_A29UsuarioID, BC000G30_A13PuestoID, BC000G30_n13PuestoID, BC000G30_A4CiudadID, BC000G30_n4CiudadID, BC000G30_A1EstadoID, BC000G30_A16PaisID, BC000G30_A22ModeloID,
               BC000G30_A44PromocionArte, BC000G30_A75FacturaPDF
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z78FacturaMedidaCantidad ;
      private short A78FacturaMedidaCantidad ;
      private short RcdFound16 ;
      private int trnEnded ;
      private int Z77FacturaMedidaID ;
      private int A77FacturaMedidaID ;
      private int Z69FacturaID ;
      private int A69FacturaID ;
      private int Z26MedidaID ;
      private int A26MedidaID ;
      private int Z41PromocionID ;
      private int A41PromocionID ;
      private int Z19MotivoRechazoID ;
      private int A19MotivoRechazoID ;
      private int Z29UsuarioID ;
      private int A29UsuarioID ;
      private int Z22ModeloID ;
      private int A22ModeloID ;
      private int Z62UsuarioCP ;
      private int A62UsuarioCP ;
      private int Z13PuestoID ;
      private int A13PuestoID ;
      private int Z4CiudadID ;
      private int A4CiudadID ;
      private int Z1EstadoID ;
      private int A1EstadoID ;
      private int Z16PaisID ;
      private int A16PaisID ;
      private long Z64UsuarioCelular ;
      private long A64UsuarioCelular ;
      private long Z65UsuarioTelefonoSucursal ;
      private long A65UsuarioTelefonoSucursal ;
      private decimal Z79FacturaMedidaPrecio ;
      private decimal A79FacturaMedidaPrecio ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z71FacturaNo ;
      private string A71FacturaNo ;
      private string Z80FacturaEstatus ;
      private string A80FacturaEstatus ;
      private string Z74MedidaRin ;
      private string A74MedidaRin ;
      private string Z27MedidaCodigo ;
      private string A27MedidaCodigo ;
      private string Z63UsuarioZona ;
      private string A63UsuarioZona ;
      private string Z53UsuarioGenero ;
      private string A53UsuarioGenero ;
      private string Z30UsuarioNombre ;
      private string A30UsuarioNombre ;
      private string Z51UsuarioApellido ;
      private string A51UsuarioApellido ;
      private string Z54UsuarioDirectoAsociado ;
      private string A54UsuarioDirectoAsociado ;
      private string Z59UsuarioCalleNum ;
      private string A59UsuarioCalleNum ;
      private string Z60UsuarioColonia ;
      private string A60UsuarioColonia ;
      private string Z61UsuarioDelegacion ;
      private string A61UsuarioDelegacion ;
      private string Z66UsuarioSucursal ;
      private string A66UsuarioSucursal ;
      private string Z40UsuarioRol ;
      private string A40UsuarioRol ;
      private string Z82UsuarioNoCuentaBROXEL ;
      private string A82UsuarioNoCuentaBROXEL ;
      private string Z83UsuarioReferenciaBROXEL ;
      private string A83UsuarioReferenciaBROXEL ;
      private string sMode16 ;
      private DateTime Z73FacturaFechaFactura ;
      private DateTime A73FacturaFechaFactura ;
      private DateTime Z72FacturaFechaRegistro ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime Z45PromocionFechaInicio ;
      private DateTime A45PromocionFechaInicio ;
      private DateTime Z46PromocionFechaFin ;
      private DateTime A46PromocionFechaFin ;
      private DateTime Z57UsuarioFechaNacimiento ;
      private DateTime A57UsuarioFechaNacimiento ;
      private bool Z21MotivoRechazoActivo ;
      private bool A21MotivoRechazoActivo ;
      private bool n54UsuarioDirectoAsociado ;
      private bool n57UsuarioFechaNacimiento ;
      private bool n67UsuarioProducto ;
      private bool n13PuestoID ;
      private bool n4CiudadID ;
      private string Z70PromocionVigencia ;
      private string A70PromocionVigencia ;
      private string Z52UsuarioNombreCompleto ;
      private string A52UsuarioNombreCompleto ;
      private string Z28MedidaDescripcion ;
      private string A28MedidaDescripcion ;
      private string Z42PromocionDescripcion ;
      private string A42PromocionDescripcion ;
      private string Z43PromocionBase ;
      private string A43PromocionBase ;
      private string Z20MotivoRechazoDescripcion ;
      private string A20MotivoRechazoDescripcion ;
      private string Z31UsuarioCorreo ;
      private string A31UsuarioCorreo ;
      private string Z32UsuarioPass ;
      private string A32UsuarioPass ;
      private string Z33UsuarioKey ;
      private string A33UsuarioKey ;
      private string Z55UsuarioRazonSocialAsociado ;
      private string A55UsuarioRazonSocialAsociado ;
      private string Z56UsuarioNombreComercial ;
      private string A56UsuarioNombreComercial ;
      private string Z67UsuarioProducto ;
      private string A67UsuarioProducto ;
      private string Z14PuestoDescripcion ;
      private string A14PuestoDescripcion ;
      private string Z5CiudadDescripcion ;
      private string A5CiudadDescripcion ;
      private string Z2EstadoDescripcion ;
      private string A2EstadoDescripcion ;
      private string Z17PaisDescripcion ;
      private string A17PaisDescripcion ;
      private string Z23ModeloDescripcion ;
      private string A23ModeloDescripcion ;
      private string Z40001FacturaPDF_GXI ;
      private string A40001FacturaPDF_GXI ;
      private string Z40000PromocionArte_GXI ;
      private string A40000PromocionArte_GXI ;
      private string Z44PromocionArte ;
      private string A44PromocionArte ;
      private string Z75FacturaPDF ;
      private string A75FacturaPDF ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000G14_A77FacturaMedidaID ;
      private string[] BC000G14_A42PromocionDescripcion ;
      private string[] BC000G14_A43PromocionBase ;
      private string[] BC000G14_A40000PromocionArte_GXI ;
      private string[] BC000G14_A71FacturaNo ;
      private DateTime[] BC000G14_A73FacturaFechaFactura ;
      private DateTime[] BC000G14_A72FacturaFechaRegistro ;
      private string[] BC000G14_A63UsuarioZona ;
      private string[] BC000G14_A2EstadoDescripcion ;
      private string[] BC000G14_A5CiudadDescripcion ;
      private string[] BC000G14_A17PaisDescripcion ;
      private string[] BC000G14_A53UsuarioGenero ;
      private string[] BC000G14_A40001FacturaPDF_GXI ;
      private string[] BC000G14_A80FacturaEstatus ;
      private string[] BC000G14_A20MotivoRechazoDescripcion ;
      private bool[] BC000G14_A21MotivoRechazoActivo ;
      private string[] BC000G14_A28MedidaDescripcion ;
      private string[] BC000G14_A74MedidaRin ;
      private string[] BC000G14_A27MedidaCodigo ;
      private string[] BC000G14_A23ModeloDescripcion ;
      private short[] BC000G14_A78FacturaMedidaCantidad ;
      private decimal[] BC000G14_A79FacturaMedidaPrecio ;
      private string[] BC000G14_A30UsuarioNombre ;
      private string[] BC000G14_A51UsuarioApellido ;
      private string[] BC000G14_A31UsuarioCorreo ;
      private string[] BC000G14_A32UsuarioPass ;
      private string[] BC000G14_A33UsuarioKey ;
      private string[] BC000G14_A14PuestoDescripcion ;
      private string[] BC000G14_A54UsuarioDirectoAsociado ;
      private bool[] BC000G14_n54UsuarioDirectoAsociado ;
      private string[] BC000G14_A55UsuarioRazonSocialAsociado ;
      private string[] BC000G14_A56UsuarioNombreComercial ;
      private DateTime[] BC000G14_A57UsuarioFechaNacimiento ;
      private bool[] BC000G14_n57UsuarioFechaNacimiento ;
      private string[] BC000G14_A59UsuarioCalleNum ;
      private string[] BC000G14_A60UsuarioColonia ;
      private string[] BC000G14_A61UsuarioDelegacion ;
      private int[] BC000G14_A62UsuarioCP ;
      private long[] BC000G14_A64UsuarioCelular ;
      private long[] BC000G14_A65UsuarioTelefonoSucursal ;
      private string[] BC000G14_A66UsuarioSucursal ;
      private string[] BC000G14_A67UsuarioProducto ;
      private bool[] BC000G14_n67UsuarioProducto ;
      private string[] BC000G14_A40UsuarioRol ;
      private string[] BC000G14_A82UsuarioNoCuentaBROXEL ;
      private string[] BC000G14_A83UsuarioReferenciaBROXEL ;
      private DateTime[] BC000G14_A45PromocionFechaInicio ;
      private DateTime[] BC000G14_A46PromocionFechaFin ;
      private int[] BC000G14_A69FacturaID ;
      private int[] BC000G14_A26MedidaID ;
      private int[] BC000G14_A41PromocionID ;
      private int[] BC000G14_A19MotivoRechazoID ;
      private int[] BC000G14_A29UsuarioID ;
      private int[] BC000G14_A13PuestoID ;
      private bool[] BC000G14_n13PuestoID ;
      private int[] BC000G14_A4CiudadID ;
      private bool[] BC000G14_n4CiudadID ;
      private int[] BC000G14_A1EstadoID ;
      private int[] BC000G14_A16PaisID ;
      private int[] BC000G14_A22ModeloID ;
      private string[] BC000G14_A44PromocionArte ;
      private string[] BC000G14_A75FacturaPDF ;
      private string[] BC000G4_A71FacturaNo ;
      private DateTime[] BC000G4_A73FacturaFechaFactura ;
      private DateTime[] BC000G4_A72FacturaFechaRegistro ;
      private string[] BC000G4_A40001FacturaPDF_GXI ;
      private string[] BC000G4_A80FacturaEstatus ;
      private int[] BC000G4_A41PromocionID ;
      private int[] BC000G4_A19MotivoRechazoID ;
      private int[] BC000G4_A29UsuarioID ;
      private string[] BC000G4_A75FacturaPDF ;
      private string[] BC000G6_A42PromocionDescripcion ;
      private string[] BC000G6_A43PromocionBase ;
      private string[] BC000G6_A40000PromocionArte_GXI ;
      private DateTime[] BC000G6_A45PromocionFechaInicio ;
      private DateTime[] BC000G6_A46PromocionFechaFin ;
      private string[] BC000G6_A44PromocionArte ;
      private string[] BC000G7_A20MotivoRechazoDescripcion ;
      private bool[] BC000G7_A21MotivoRechazoActivo ;
      private string[] BC000G8_A63UsuarioZona ;
      private string[] BC000G8_A53UsuarioGenero ;
      private string[] BC000G8_A30UsuarioNombre ;
      private string[] BC000G8_A51UsuarioApellido ;
      private string[] BC000G8_A31UsuarioCorreo ;
      private string[] BC000G8_A32UsuarioPass ;
      private string[] BC000G8_A33UsuarioKey ;
      private string[] BC000G8_A54UsuarioDirectoAsociado ;
      private bool[] BC000G8_n54UsuarioDirectoAsociado ;
      private string[] BC000G8_A55UsuarioRazonSocialAsociado ;
      private string[] BC000G8_A56UsuarioNombreComercial ;
      private DateTime[] BC000G8_A57UsuarioFechaNacimiento ;
      private bool[] BC000G8_n57UsuarioFechaNacimiento ;
      private string[] BC000G8_A59UsuarioCalleNum ;
      private string[] BC000G8_A60UsuarioColonia ;
      private string[] BC000G8_A61UsuarioDelegacion ;
      private int[] BC000G8_A62UsuarioCP ;
      private long[] BC000G8_A64UsuarioCelular ;
      private long[] BC000G8_A65UsuarioTelefonoSucursal ;
      private string[] BC000G8_A66UsuarioSucursal ;
      private string[] BC000G8_A67UsuarioProducto ;
      private bool[] BC000G8_n67UsuarioProducto ;
      private string[] BC000G8_A40UsuarioRol ;
      private string[] BC000G8_A82UsuarioNoCuentaBROXEL ;
      private string[] BC000G8_A83UsuarioReferenciaBROXEL ;
      private int[] BC000G8_A13PuestoID ;
      private bool[] BC000G8_n13PuestoID ;
      private int[] BC000G8_A4CiudadID ;
      private bool[] BC000G8_n4CiudadID ;
      private string[] BC000G9_A14PuestoDescripcion ;
      private string[] BC000G10_A5CiudadDescripcion ;
      private int[] BC000G10_A1EstadoID ;
      private string[] BC000G11_A2EstadoDescripcion ;
      private int[] BC000G11_A16PaisID ;
      private string[] BC000G12_A17PaisDescripcion ;
      private string[] BC000G5_A28MedidaDescripcion ;
      private string[] BC000G5_A74MedidaRin ;
      private string[] BC000G5_A27MedidaCodigo ;
      private int[] BC000G5_A22ModeloID ;
      private string[] BC000G13_A23ModeloDescripcion ;
      private int[] BC000G15_A77FacturaMedidaID ;
      private int[] BC000G3_A77FacturaMedidaID ;
      private short[] BC000G3_A78FacturaMedidaCantidad ;
      private decimal[] BC000G3_A79FacturaMedidaPrecio ;
      private int[] BC000G3_A69FacturaID ;
      private int[] BC000G3_A26MedidaID ;
      private int[] BC000G2_A77FacturaMedidaID ;
      private short[] BC000G2_A78FacturaMedidaCantidad ;
      private decimal[] BC000G2_A79FacturaMedidaPrecio ;
      private int[] BC000G2_A69FacturaID ;
      private int[] BC000G2_A26MedidaID ;
      private int[] BC000G17_A77FacturaMedidaID ;
      private string[] BC000G20_A71FacturaNo ;
      private DateTime[] BC000G20_A73FacturaFechaFactura ;
      private DateTime[] BC000G20_A72FacturaFechaRegistro ;
      private string[] BC000G20_A40001FacturaPDF_GXI ;
      private string[] BC000G20_A80FacturaEstatus ;
      private int[] BC000G20_A41PromocionID ;
      private int[] BC000G20_A19MotivoRechazoID ;
      private int[] BC000G20_A29UsuarioID ;
      private string[] BC000G20_A75FacturaPDF ;
      private string[] BC000G21_A42PromocionDescripcion ;
      private string[] BC000G21_A43PromocionBase ;
      private string[] BC000G21_A40000PromocionArte_GXI ;
      private DateTime[] BC000G21_A45PromocionFechaInicio ;
      private DateTime[] BC000G21_A46PromocionFechaFin ;
      private string[] BC000G21_A44PromocionArte ;
      private string[] BC000G22_A20MotivoRechazoDescripcion ;
      private bool[] BC000G22_A21MotivoRechazoActivo ;
      private string[] BC000G23_A63UsuarioZona ;
      private string[] BC000G23_A53UsuarioGenero ;
      private string[] BC000G23_A30UsuarioNombre ;
      private string[] BC000G23_A51UsuarioApellido ;
      private string[] BC000G23_A31UsuarioCorreo ;
      private string[] BC000G23_A32UsuarioPass ;
      private string[] BC000G23_A33UsuarioKey ;
      private string[] BC000G23_A54UsuarioDirectoAsociado ;
      private bool[] BC000G23_n54UsuarioDirectoAsociado ;
      private string[] BC000G23_A55UsuarioRazonSocialAsociado ;
      private string[] BC000G23_A56UsuarioNombreComercial ;
      private DateTime[] BC000G23_A57UsuarioFechaNacimiento ;
      private bool[] BC000G23_n57UsuarioFechaNacimiento ;
      private string[] BC000G23_A59UsuarioCalleNum ;
      private string[] BC000G23_A60UsuarioColonia ;
      private string[] BC000G23_A61UsuarioDelegacion ;
      private int[] BC000G23_A62UsuarioCP ;
      private long[] BC000G23_A64UsuarioCelular ;
      private long[] BC000G23_A65UsuarioTelefonoSucursal ;
      private string[] BC000G23_A66UsuarioSucursal ;
      private string[] BC000G23_A67UsuarioProducto ;
      private bool[] BC000G23_n67UsuarioProducto ;
      private string[] BC000G23_A40UsuarioRol ;
      private string[] BC000G23_A82UsuarioNoCuentaBROXEL ;
      private string[] BC000G23_A83UsuarioReferenciaBROXEL ;
      private int[] BC000G23_A13PuestoID ;
      private bool[] BC000G23_n13PuestoID ;
      private int[] BC000G23_A4CiudadID ;
      private bool[] BC000G23_n4CiudadID ;
      private string[] BC000G24_A14PuestoDescripcion ;
      private string[] BC000G25_A5CiudadDescripcion ;
      private int[] BC000G25_A1EstadoID ;
      private string[] BC000G26_A2EstadoDescripcion ;
      private int[] BC000G26_A16PaisID ;
      private string[] BC000G27_A17PaisDescripcion ;
      private string[] BC000G28_A28MedidaDescripcion ;
      private string[] BC000G28_A74MedidaRin ;
      private string[] BC000G28_A27MedidaCodigo ;
      private int[] BC000G28_A22ModeloID ;
      private string[] BC000G29_A23ModeloDescripcion ;
      private int[] BC000G30_A77FacturaMedidaID ;
      private string[] BC000G30_A42PromocionDescripcion ;
      private string[] BC000G30_A43PromocionBase ;
      private string[] BC000G30_A40000PromocionArte_GXI ;
      private string[] BC000G30_A71FacturaNo ;
      private DateTime[] BC000G30_A73FacturaFechaFactura ;
      private DateTime[] BC000G30_A72FacturaFechaRegistro ;
      private string[] BC000G30_A63UsuarioZona ;
      private string[] BC000G30_A2EstadoDescripcion ;
      private string[] BC000G30_A5CiudadDescripcion ;
      private string[] BC000G30_A17PaisDescripcion ;
      private string[] BC000G30_A53UsuarioGenero ;
      private string[] BC000G30_A40001FacturaPDF_GXI ;
      private string[] BC000G30_A80FacturaEstatus ;
      private string[] BC000G30_A20MotivoRechazoDescripcion ;
      private bool[] BC000G30_A21MotivoRechazoActivo ;
      private string[] BC000G30_A28MedidaDescripcion ;
      private string[] BC000G30_A74MedidaRin ;
      private string[] BC000G30_A27MedidaCodigo ;
      private string[] BC000G30_A23ModeloDescripcion ;
      private short[] BC000G30_A78FacturaMedidaCantidad ;
      private decimal[] BC000G30_A79FacturaMedidaPrecio ;
      private string[] BC000G30_A30UsuarioNombre ;
      private string[] BC000G30_A51UsuarioApellido ;
      private string[] BC000G30_A31UsuarioCorreo ;
      private string[] BC000G30_A32UsuarioPass ;
      private string[] BC000G30_A33UsuarioKey ;
      private string[] BC000G30_A14PuestoDescripcion ;
      private string[] BC000G30_A54UsuarioDirectoAsociado ;
      private bool[] BC000G30_n54UsuarioDirectoAsociado ;
      private string[] BC000G30_A55UsuarioRazonSocialAsociado ;
      private string[] BC000G30_A56UsuarioNombreComercial ;
      private DateTime[] BC000G30_A57UsuarioFechaNacimiento ;
      private bool[] BC000G30_n57UsuarioFechaNacimiento ;
      private string[] BC000G30_A59UsuarioCalleNum ;
      private string[] BC000G30_A60UsuarioColonia ;
      private string[] BC000G30_A61UsuarioDelegacion ;
      private int[] BC000G30_A62UsuarioCP ;
      private long[] BC000G30_A64UsuarioCelular ;
      private long[] BC000G30_A65UsuarioTelefonoSucursal ;
      private string[] BC000G30_A66UsuarioSucursal ;
      private string[] BC000G30_A67UsuarioProducto ;
      private bool[] BC000G30_n67UsuarioProducto ;
      private string[] BC000G30_A40UsuarioRol ;
      private string[] BC000G30_A82UsuarioNoCuentaBROXEL ;
      private string[] BC000G30_A83UsuarioReferenciaBROXEL ;
      private DateTime[] BC000G30_A45PromocionFechaInicio ;
      private DateTime[] BC000G30_A46PromocionFechaFin ;
      private int[] BC000G30_A69FacturaID ;
      private int[] BC000G30_A26MedidaID ;
      private int[] BC000G30_A41PromocionID ;
      private int[] BC000G30_A19MotivoRechazoID ;
      private int[] BC000G30_A29UsuarioID ;
      private int[] BC000G30_A13PuestoID ;
      private bool[] BC000G30_n13PuestoID ;
      private int[] BC000G30_A4CiudadID ;
      private bool[] BC000G30_n4CiudadID ;
      private int[] BC000G30_A1EstadoID ;
      private int[] BC000G30_A16PaisID ;
      private int[] BC000G30_A22ModeloID ;
      private string[] BC000G30_A44PromocionArte ;
      private string[] BC000G30_A75FacturaPDF ;
      private SdtFacturaMedida bcFacturaMedida ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class facturamedida_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000G2;
          prmBC000G2 = new Object[] {
          new ParDef("@FacturaMedidaID",GXType.Int32,9,0)
          };
          Object[] prmBC000G3;
          prmBC000G3 = new Object[] {
          new ParDef("@FacturaMedidaID",GXType.Int32,9,0)
          };
          Object[] prmBC000G4;
          prmBC000G4 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmBC000G5;
          prmBC000G5 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmBC000G6;
          prmBC000G6 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000G7;
          prmBC000G7 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmBC000G8;
          prmBC000G8 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000G9;
          prmBC000G9 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000G10;
          prmBC000G10 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000G11;
          prmBC000G11 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC000G12;
          prmBC000G12 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmBC000G13;
          prmBC000G13 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC000G14;
          prmBC000G14 = new Object[] {
          new ParDef("@FacturaMedidaID",GXType.Int32,9,0)
          };
          string cmdBufferBC000G14;
          cmdBufferBC000G14=" SELECT TM1.`FacturaMedidaID`, T3.`PromocionDescripcion`, T3.`PromocionBase`, T3.`PromocionArte_GXI`, T2.`FacturaNo`, T2.`FacturaFechaFactura`, T2.`FacturaFechaRegistro`, T5.`UsuarioZona`, T8.`EstadoDescripcion`, T7.`CiudadDescripcion`, T9.`PaisDescripcion`, T5.`UsuarioGenero`, T2.`FacturaPDF_GXI`, T2.`FacturaEstatus`, T4.`MotivoRechazoDescripcion`, T4.`MotivoRechazoActivo`, T10.`MedidaDescripcion`, T10.`MedidaRin`, T10.`MedidaCodigo`, T11.`ModeloDescripcion`, TM1.`FacturaMedidaCantidad`, TM1.`FacturaMedidaPrecio`, T5.`UsuarioNombre`, T5.`UsuarioApellido`, T5.`UsuarioCorreo`, T5.`UsuarioPass`, T5.`UsuarioKey`, T6.`PuestoDescripcion`, T5.`UsuarioDirectoAsociado`, T5.`UsuarioRazonSocialAsociado`, T5.`UsuarioNombreComercial`, T5.`UsuarioFechaNacimiento`, T5.`UsuarioCalleNum`, T5.`UsuarioColonia`, T5.`UsuarioDelegacion`, T5.`UsuarioCP`, T5.`UsuarioCelular`, T5.`UsuarioTelefonoSucursal`, T5.`UsuarioSucursal`, T5.`UsuarioProducto`, T5.`UsuarioRol`, T5.`UsuarioNoCuentaBROXEL`, T5.`UsuarioReferenciaBROXEL`, T3.`PromocionFechaInicio`, T3.`PromocionFechaFin`, TM1.`FacturaID`, TM1.`MedidaID`, T2.`PromocionID`, T2.`MotivoRechazoID`, T2.`UsuarioID`, T5.`PuestoID`, T5.`CiudadID`, T7.`EstadoID`, T8.`PaisID`, T10.`ModeloID`, T3.`PromocionArte`, T2.`FacturaPDF` FROM ((((((((((`FacturaMedida` TM1 INNER JOIN `Factura` T2 ON T2.`FacturaID` = TM1.`FacturaID`) INNER JOIN `Promocion` T3 ON T3.`PromocionID` = T2.`PromocionID`) INNER JOIN `MotivoRechazo` T4 ON T4.`MotivoRechazoID` = T2.`MotivoRechazoID`) INNER JOIN `Usuario` T5 ON T5.`UsuarioID` = T2.`UsuarioID`) LEFT JOIN `Puesto` T6 ON T6.`PuestoID` = T5.`PuestoID`) LEFT JOIN `Ciudad` T7 ON T7.`CiudadID` = T5.`CiudadID`) LEFT JOIN `Estado` T8 ON T8.`EstadoID` = T7.`EstadoID`) LEFT JOIN `Pais` T9 ON T9.`PaisID` = T8.`PaisID`) INNER JOIN `Medida` "
          + " T10 ON T10.`MedidaID` = TM1.`MedidaID`) INNER JOIN `Modelo` T11 ON T11.`ModeloID` = T10.`ModeloID`) WHERE TM1.`FacturaMedidaID` = @FacturaMedidaID ORDER BY TM1.`FacturaMedidaID`" ;
          Object[] prmBC000G15;
          prmBC000G15 = new Object[] {
          new ParDef("@FacturaMedidaID",GXType.Int32,9,0)
          };
          Object[] prmBC000G16;
          prmBC000G16 = new Object[] {
          new ParDef("@FacturaMedidaCantidad",GXType.Int16,4,0) ,
          new ParDef("@FacturaMedidaPrecio",GXType.Number,10,2) ,
          new ParDef("@FacturaID",GXType.Int32,9,0) ,
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmBC000G17;
          prmBC000G17 = new Object[] {
          };
          Object[] prmBC000G18;
          prmBC000G18 = new Object[] {
          new ParDef("@FacturaMedidaCantidad",GXType.Int16,4,0) ,
          new ParDef("@FacturaMedidaPrecio",GXType.Number,10,2) ,
          new ParDef("@FacturaID",GXType.Int32,9,0) ,
          new ParDef("@MedidaID",GXType.Int32,9,0) ,
          new ParDef("@FacturaMedidaID",GXType.Int32,9,0)
          };
          Object[] prmBC000G19;
          prmBC000G19 = new Object[] {
          new ParDef("@FacturaMedidaID",GXType.Int32,9,0)
          };
          Object[] prmBC000G20;
          prmBC000G20 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmBC000G21;
          prmBC000G21 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000G22;
          prmBC000G22 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmBC000G23;
          prmBC000G23 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000G24;
          prmBC000G24 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000G25;
          prmBC000G25 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000G26;
          prmBC000G26 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC000G27;
          prmBC000G27 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmBC000G28;
          prmBC000G28 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmBC000G29;
          prmBC000G29 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmBC000G30;
          prmBC000G30 = new Object[] {
          new ParDef("@FacturaMedidaID",GXType.Int32,9,0)
          };
          string cmdBufferBC000G30;
          cmdBufferBC000G30=" SELECT TM1.`FacturaMedidaID`, T3.`PromocionDescripcion`, T3.`PromocionBase`, T3.`PromocionArte_GXI`, T2.`FacturaNo`, T2.`FacturaFechaFactura`, T2.`FacturaFechaRegistro`, T5.`UsuarioZona`, T8.`EstadoDescripcion`, T7.`CiudadDescripcion`, T9.`PaisDescripcion`, T5.`UsuarioGenero`, T2.`FacturaPDF_GXI`, T2.`FacturaEstatus`, T4.`MotivoRechazoDescripcion`, T4.`MotivoRechazoActivo`, T10.`MedidaDescripcion`, T10.`MedidaRin`, T10.`MedidaCodigo`, T11.`ModeloDescripcion`, TM1.`FacturaMedidaCantidad`, TM1.`FacturaMedidaPrecio`, T5.`UsuarioNombre`, T5.`UsuarioApellido`, T5.`UsuarioCorreo`, T5.`UsuarioPass`, T5.`UsuarioKey`, T6.`PuestoDescripcion`, T5.`UsuarioDirectoAsociado`, T5.`UsuarioRazonSocialAsociado`, T5.`UsuarioNombreComercial`, T5.`UsuarioFechaNacimiento`, T5.`UsuarioCalleNum`, T5.`UsuarioColonia`, T5.`UsuarioDelegacion`, T5.`UsuarioCP`, T5.`UsuarioCelular`, T5.`UsuarioTelefonoSucursal`, T5.`UsuarioSucursal`, T5.`UsuarioProducto`, T5.`UsuarioRol`, T5.`UsuarioNoCuentaBROXEL`, T5.`UsuarioReferenciaBROXEL`, T3.`PromocionFechaInicio`, T3.`PromocionFechaFin`, TM1.`FacturaID`, TM1.`MedidaID`, T2.`PromocionID`, T2.`MotivoRechazoID`, T2.`UsuarioID`, T5.`PuestoID`, T5.`CiudadID`, T7.`EstadoID`, T8.`PaisID`, T10.`ModeloID`, T3.`PromocionArte`, T2.`FacturaPDF` FROM ((((((((((`FacturaMedida` TM1 INNER JOIN `Factura` T2 ON T2.`FacturaID` = TM1.`FacturaID`) INNER JOIN `Promocion` T3 ON T3.`PromocionID` = T2.`PromocionID`) INNER JOIN `MotivoRechazo` T4 ON T4.`MotivoRechazoID` = T2.`MotivoRechazoID`) INNER JOIN `Usuario` T5 ON T5.`UsuarioID` = T2.`UsuarioID`) LEFT JOIN `Puesto` T6 ON T6.`PuestoID` = T5.`PuestoID`) LEFT JOIN `Ciudad` T7 ON T7.`CiudadID` = T5.`CiudadID`) LEFT JOIN `Estado` T8 ON T8.`EstadoID` = T7.`EstadoID`) LEFT JOIN `Pais` T9 ON T9.`PaisID` = T8.`PaisID`) INNER JOIN `Medida` "
          + " T10 ON T10.`MedidaID` = TM1.`MedidaID`) INNER JOIN `Modelo` T11 ON T11.`ModeloID` = T10.`ModeloID`) WHERE TM1.`FacturaMedidaID` = @FacturaMedidaID ORDER BY TM1.`FacturaMedidaID`" ;
          def= new CursorDef[] {
              new CursorDef("BC000G2", "SELECT `FacturaMedidaID`, `FacturaMedidaCantidad`, `FacturaMedidaPrecio`, `FacturaID`, `MedidaID` FROM `FacturaMedida` WHERE `FacturaMedidaID` = @FacturaMedidaID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G3", "SELECT `FacturaMedidaID`, `FacturaMedidaCantidad`, `FacturaMedidaPrecio`, `FacturaID`, `MedidaID` FROM `FacturaMedida` WHERE `FacturaMedidaID` = @FacturaMedidaID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G4", "SELECT `FacturaNo`, `FacturaFechaFactura`, `FacturaFechaRegistro`, `FacturaPDF_GXI`, `FacturaEstatus`, `PromocionID`, `MotivoRechazoID`, `UsuarioID`, `FacturaPDF` FROM `Factura` WHERE `FacturaID` = @FacturaID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G5", "SELECT `MedidaDescripcion`, `MedidaRin`, `MedidaCodigo`, `ModeloID` FROM `Medida` WHERE `MedidaID` = @MedidaID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G6", "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G7", "SELECT `MotivoRechazoDescripcion`, `MotivoRechazoActivo` FROM `MotivoRechazo` WHERE `MotivoRechazoID` = @MotivoRechazoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G8", "SELECT `UsuarioZona`, `UsuarioGenero`, `UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `UsuarioNoCuentaBROXEL`, `UsuarioReferenciaBROXEL`, `PuestoID`, `CiudadID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G9", "SELECT `PuestoDescripcion` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G10", "SELECT `CiudadDescripcion`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G11", "SELECT `EstadoDescripcion`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G12", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G13", "SELECT `ModeloDescripcion` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G14", cmdBufferBC000G14,true, GxErrorMask.GX_NOMASK, false, this,prmBC000G14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G15", "SELECT `FacturaMedidaID` FROM `FacturaMedida` WHERE `FacturaMedidaID` = @FacturaMedidaID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G16", "INSERT INTO `FacturaMedida`(`FacturaMedidaCantidad`, `FacturaMedidaPrecio`, `FacturaID`, `MedidaID`) VALUES(@FacturaMedidaCantidad, @FacturaMedidaPrecio, @FacturaID, @MedidaID)", GxErrorMask.GX_NOMASK,prmBC000G16)
             ,new CursorDef("BC000G17", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G18", "UPDATE `FacturaMedida` SET `FacturaMedidaCantidad`=@FacturaMedidaCantidad, `FacturaMedidaPrecio`=@FacturaMedidaPrecio, `FacturaID`=@FacturaID, `MedidaID`=@MedidaID  WHERE `FacturaMedidaID` = @FacturaMedidaID", GxErrorMask.GX_NOMASK,prmBC000G18)
             ,new CursorDef("BC000G19", "DELETE FROM `FacturaMedida`  WHERE `FacturaMedidaID` = @FacturaMedidaID", GxErrorMask.GX_NOMASK,prmBC000G19)
             ,new CursorDef("BC000G20", "SELECT `FacturaNo`, `FacturaFechaFactura`, `FacturaFechaRegistro`, `FacturaPDF_GXI`, `FacturaEstatus`, `PromocionID`, `MotivoRechazoID`, `UsuarioID`, `FacturaPDF` FROM `Factura` WHERE `FacturaID` = @FacturaID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G21", "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G22", "SELECT `MotivoRechazoDescripcion`, `MotivoRechazoActivo` FROM `MotivoRechazo` WHERE `MotivoRechazoID` = @MotivoRechazoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G23", "SELECT `UsuarioZona`, `UsuarioGenero`, `UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `UsuarioNoCuentaBROXEL`, `UsuarioReferenciaBROXEL`, `PuestoID`, `CiudadID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G24", "SELECT `PuestoDescripcion` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G24,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G25", "SELECT `CiudadDescripcion`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G26", "SELECT `EstadoDescripcion`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G26,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G27", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G27,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G28", "SELECT `MedidaDescripcion`, `MedidaRin`, `MedidaCodigo`, `ModeloID` FROM `Medida` WHERE `MedidaID` = @MedidaID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G28,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G29", "SELECT `ModeloDescripcion` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000G30", cmdBufferBC000G30,true, GxErrorMask.GX_NOMASK, false, this,prmBC000G30,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 40);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((string[]) buf[15])[0] = rslt.getString(14, 20);
                ((int[]) buf[16])[0] = rslt.getInt(15);
                ((long[]) buf[17])[0] = rslt.getLong(16);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 20);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((string[]) buf[22])[0] = rslt.getString(20, 40);
                ((string[]) buf[23])[0] = rslt.getString(21, 20);
                ((string[]) buf[24])[0] = rslt.getString(22, 20);
                ((int[]) buf[25])[0] = rslt.getInt(23);
                ((bool[]) buf[26])[0] = rslt.wasNull(23);
                ((int[]) buf[27])[0] = rslt.getInt(24);
                ((bool[]) buf[28])[0] = rslt.wasNull(24);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 30);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((string[]) buf[12])[0] = rslt.getMultimediaUri(13);
                ((string[]) buf[13])[0] = rslt.getString(14, 20);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((bool[]) buf[15])[0] = rslt.getBool(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                ((string[]) buf[17])[0] = rslt.getString(18, 20);
                ((string[]) buf[18])[0] = rslt.getString(19, 20);
                ((string[]) buf[19])[0] = rslt.getVarchar(20);
                ((short[]) buf[20])[0] = rslt.getShort(21);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(22);
                ((string[]) buf[22])[0] = rslt.getString(23, 50);
                ((string[]) buf[23])[0] = rslt.getString(24, 50);
                ((string[]) buf[24])[0] = rslt.getVarchar(25);
                ((string[]) buf[25])[0] = rslt.getVarchar(26);
                ((string[]) buf[26])[0] = rslt.getVarchar(27);
                ((string[]) buf[27])[0] = rslt.getVarchar(28);
                ((string[]) buf[28])[0] = rslt.getString(29, 20);
                ((bool[]) buf[29])[0] = rslt.wasNull(29);
                ((string[]) buf[30])[0] = rslt.getVarchar(30);
                ((string[]) buf[31])[0] = rslt.getVarchar(31);
                ((DateTime[]) buf[32])[0] = rslt.getGXDate(32);
                ((bool[]) buf[33])[0] = rslt.wasNull(32);
                ((string[]) buf[34])[0] = rslt.getString(33, 40);
                ((string[]) buf[35])[0] = rslt.getString(34, 20);
                ((string[]) buf[36])[0] = rslt.getString(35, 20);
                ((int[]) buf[37])[0] = rslt.getInt(36);
                ((long[]) buf[38])[0] = rslt.getLong(37);
                ((long[]) buf[39])[0] = rslt.getLong(38);
                ((string[]) buf[40])[0] = rslt.getString(39, 20);
                ((string[]) buf[41])[0] = rslt.getVarchar(40);
                ((bool[]) buf[42])[0] = rslt.wasNull(40);
                ((string[]) buf[43])[0] = rslt.getString(41, 40);
                ((string[]) buf[44])[0] = rslt.getString(42, 20);
                ((string[]) buf[45])[0] = rslt.getString(43, 20);
                ((DateTime[]) buf[46])[0] = rslt.getGXDate(44);
                ((DateTime[]) buf[47])[0] = rslt.getGXDate(45);
                ((int[]) buf[48])[0] = rslt.getInt(46);
                ((int[]) buf[49])[0] = rslt.getInt(47);
                ((int[]) buf[50])[0] = rslt.getInt(48);
                ((int[]) buf[51])[0] = rslt.getInt(49);
                ((int[]) buf[52])[0] = rslt.getInt(50);
                ((int[]) buf[53])[0] = rslt.getInt(51);
                ((bool[]) buf[54])[0] = rslt.wasNull(51);
                ((int[]) buf[55])[0] = rslt.getInt(52);
                ((bool[]) buf[56])[0] = rslt.wasNull(52);
                ((int[]) buf[57])[0] = rslt.getInt(53);
                ((int[]) buf[58])[0] = rslt.getInt(54);
                ((int[]) buf[59])[0] = rslt.getInt(55);
                ((string[]) buf[60])[0] = rslt.getMultimediaFile(56, rslt.getVarchar(4));
                ((string[]) buf[61])[0] = rslt.getMultimediaFile(57, rslt.getVarchar(13));
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 40);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((string[]) buf[15])[0] = rslt.getString(14, 20);
                ((int[]) buf[16])[0] = rslt.getInt(15);
                ((long[]) buf[17])[0] = rslt.getLong(16);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 20);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((string[]) buf[22])[0] = rslt.getString(20, 40);
                ((string[]) buf[23])[0] = rslt.getString(21, 20);
                ((string[]) buf[24])[0] = rslt.getString(22, 20);
                ((int[]) buf[25])[0] = rslt.getInt(23);
                ((bool[]) buf[26])[0] = rslt.wasNull(23);
                ((int[]) buf[27])[0] = rslt.getInt(24);
                ((bool[]) buf[28])[0] = rslt.wasNull(24);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 23 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 27 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 30);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((string[]) buf[12])[0] = rslt.getMultimediaUri(13);
                ((string[]) buf[13])[0] = rslt.getString(14, 20);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((bool[]) buf[15])[0] = rslt.getBool(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                ((string[]) buf[17])[0] = rslt.getString(18, 20);
                ((string[]) buf[18])[0] = rslt.getString(19, 20);
                ((string[]) buf[19])[0] = rslt.getVarchar(20);
                ((short[]) buf[20])[0] = rslt.getShort(21);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(22);
                ((string[]) buf[22])[0] = rslt.getString(23, 50);
                ((string[]) buf[23])[0] = rslt.getString(24, 50);
                ((string[]) buf[24])[0] = rslt.getVarchar(25);
                ((string[]) buf[25])[0] = rslt.getVarchar(26);
                ((string[]) buf[26])[0] = rslt.getVarchar(27);
                ((string[]) buf[27])[0] = rslt.getVarchar(28);
                ((string[]) buf[28])[0] = rslt.getString(29, 20);
                ((bool[]) buf[29])[0] = rslt.wasNull(29);
                ((string[]) buf[30])[0] = rslt.getVarchar(30);
                ((string[]) buf[31])[0] = rslt.getVarchar(31);
                ((DateTime[]) buf[32])[0] = rslt.getGXDate(32);
                ((bool[]) buf[33])[0] = rslt.wasNull(32);
                ((string[]) buf[34])[0] = rslt.getString(33, 40);
                ((string[]) buf[35])[0] = rslt.getString(34, 20);
                ((string[]) buf[36])[0] = rslt.getString(35, 20);
                ((int[]) buf[37])[0] = rslt.getInt(36);
                ((long[]) buf[38])[0] = rslt.getLong(37);
                ((long[]) buf[39])[0] = rslt.getLong(38);
                ((string[]) buf[40])[0] = rslt.getString(39, 20);
                ((string[]) buf[41])[0] = rslt.getVarchar(40);
                ((bool[]) buf[42])[0] = rslt.wasNull(40);
                ((string[]) buf[43])[0] = rslt.getString(41, 40);
                ((string[]) buf[44])[0] = rslt.getString(42, 20);
                ((string[]) buf[45])[0] = rslt.getString(43, 20);
                ((DateTime[]) buf[46])[0] = rslt.getGXDate(44);
                ((DateTime[]) buf[47])[0] = rslt.getGXDate(45);
                ((int[]) buf[48])[0] = rslt.getInt(46);
                ((int[]) buf[49])[0] = rslt.getInt(47);
                ((int[]) buf[50])[0] = rslt.getInt(48);
                ((int[]) buf[51])[0] = rslt.getInt(49);
                ((int[]) buf[52])[0] = rslt.getInt(50);
                ((int[]) buf[53])[0] = rslt.getInt(51);
                ((bool[]) buf[54])[0] = rslt.wasNull(51);
                ((int[]) buf[55])[0] = rslt.getInt(52);
                ((bool[]) buf[56])[0] = rslt.wasNull(52);
                ((int[]) buf[57])[0] = rslt.getInt(53);
                ((int[]) buf[58])[0] = rslt.getInt(54);
                ((int[]) buf[59])[0] = rslt.getInt(55);
                ((string[]) buf[60])[0] = rslt.getMultimediaFile(56, rslt.getVarchar(4));
                ((string[]) buf[61])[0] = rslt.getMultimediaFile(57, rslt.getVarchar(13));
                return;
       }
    }

 }

}
