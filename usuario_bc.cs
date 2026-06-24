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
   public class usuario_bc : GxSilentTrn, IGxSilentTrn
   {
      public usuario_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usuario_bc( IGxContext context )
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
         ReadRow0A18( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0A18( ) ;
         standaloneModal( ) ;
         AddRow0A18( ) ;
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
               Z29UsuarioID = A29UsuarioID;
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

      protected void CONFIRM_0A0( )
      {
         BeforeValidate0A18( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0A18( ) ;
            }
            else
            {
               CheckExtendedTable0A18( ) ;
               if ( AnyError == 0 )
               {
                  ZM0A18( 12) ;
                  ZM0A18( 13) ;
                  ZM0A18( 14) ;
                  ZM0A18( 15) ;
               }
               CloseExtendedTableCursors0A18( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0A18( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z30UsuarioNombre = A30UsuarioNombre;
            Z51UsuarioApellido = A51UsuarioApellido;
            Z31UsuarioCorreo = A31UsuarioCorreo;
            Z32UsuarioPass = A32UsuarioPass;
            Z33UsuarioKey = A33UsuarioKey;
            Z53UsuarioGenero = A53UsuarioGenero;
            Z54UsuarioDirectoAsociado = A54UsuarioDirectoAsociado;
            Z55UsuarioRazonSocialAsociado = A55UsuarioRazonSocialAsociado;
            Z56UsuarioNombreComercial = A56UsuarioNombreComercial;
            Z57UsuarioFechaNacimiento = A57UsuarioFechaNacimiento;
            Z59UsuarioCalleNum = A59UsuarioCalleNum;
            Z60UsuarioColonia = A60UsuarioColonia;
            Z61UsuarioDelegacion = A61UsuarioDelegacion;
            Z62UsuarioCP = A62UsuarioCP;
            Z63UsuarioZona = A63UsuarioZona;
            Z64UsuarioCelular = A64UsuarioCelular;
            Z65UsuarioTelefonoSucursal = A65UsuarioTelefonoSucursal;
            Z66UsuarioSucursal = A66UsuarioSucursal;
            Z67UsuarioProducto = A67UsuarioProducto;
            Z40UsuarioRol = A40UsuarioRol;
            Z82UsuarioNoCuentaBROXEL = A82UsuarioNoCuentaBROXEL;
            Z83UsuarioReferenciaBROXEL = A83UsuarioReferenciaBROXEL;
            Z87UsuarioFechaRegistro = A87UsuarioFechaRegistro;
            Z92UsuarioAvisoPrivacidad = A92UsuarioAvisoPrivacidad;
            Z13PuestoID = A13PuestoID;
            Z4CiudadID = A4CiudadID;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z14PuestoDescripcion = A14PuestoDescripcion;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z5CiudadDescripcion = A5CiudadDescripcion;
            Z1EstadoID = A1EstadoID;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z2EstadoDescripcion = A2EstadoDescripcion;
            Z16PaisID = A16PaisID;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z17PaisDescripcion = A17PaisDescripcion;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( GX_JID == -11 )
         {
            Z29UsuarioID = A29UsuarioID;
            Z30UsuarioNombre = A30UsuarioNombre;
            Z51UsuarioApellido = A51UsuarioApellido;
            Z31UsuarioCorreo = A31UsuarioCorreo;
            Z32UsuarioPass = A32UsuarioPass;
            Z33UsuarioKey = A33UsuarioKey;
            Z53UsuarioGenero = A53UsuarioGenero;
            Z54UsuarioDirectoAsociado = A54UsuarioDirectoAsociado;
            Z55UsuarioRazonSocialAsociado = A55UsuarioRazonSocialAsociado;
            Z56UsuarioNombreComercial = A56UsuarioNombreComercial;
            Z57UsuarioFechaNacimiento = A57UsuarioFechaNacimiento;
            Z59UsuarioCalleNum = A59UsuarioCalleNum;
            Z60UsuarioColonia = A60UsuarioColonia;
            Z61UsuarioDelegacion = A61UsuarioDelegacion;
            Z62UsuarioCP = A62UsuarioCP;
            Z63UsuarioZona = A63UsuarioZona;
            Z64UsuarioCelular = A64UsuarioCelular;
            Z65UsuarioTelefonoSucursal = A65UsuarioTelefonoSucursal;
            Z66UsuarioSucursal = A66UsuarioSucursal;
            Z67UsuarioProducto = A67UsuarioProducto;
            Z40UsuarioRol = A40UsuarioRol;
            Z82UsuarioNoCuentaBROXEL = A82UsuarioNoCuentaBROXEL;
            Z83UsuarioReferenciaBROXEL = A83UsuarioReferenciaBROXEL;
            Z87UsuarioFechaRegistro = A87UsuarioFechaRegistro;
            Z92UsuarioAvisoPrivacidad = A92UsuarioAvisoPrivacidad;
            Z13PuestoID = A13PuestoID;
            Z4CiudadID = A4CiudadID;
            Z14PuestoDescripcion = A14PuestoDescripcion;
            Z5CiudadDescripcion = A5CiudadDescripcion;
            Z1EstadoID = A1EstadoID;
            Z2EstadoDescripcion = A2EstadoDescripcion;
            Z16PaisID = A16PaisID;
            Z17PaisDescripcion = A17PaisDescripcion;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A92UsuarioAvisoPrivacidad) && ( Gx_BScreen == 0 ) )
         {
            A92UsuarioAvisoPrivacidad = false;
         }
      }

      protected void Load0A18( )
      {
         /* Using cursor BC000A8 */
         pr_default.execute(6, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound18 = 1;
            A30UsuarioNombre = BC000A8_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000A8_A51UsuarioApellido[0];
            A31UsuarioCorreo = BC000A8_A31UsuarioCorreo[0];
            A32UsuarioPass = BC000A8_A32UsuarioPass[0];
            A33UsuarioKey = BC000A8_A33UsuarioKey[0];
            A14PuestoDescripcion = BC000A8_A14PuestoDescripcion[0];
            A53UsuarioGenero = BC000A8_A53UsuarioGenero[0];
            A54UsuarioDirectoAsociado = BC000A8_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = BC000A8_n54UsuarioDirectoAsociado[0];
            A55UsuarioRazonSocialAsociado = BC000A8_A55UsuarioRazonSocialAsociado[0];
            A56UsuarioNombreComercial = BC000A8_A56UsuarioNombreComercial[0];
            A57UsuarioFechaNacimiento = BC000A8_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = BC000A8_n57UsuarioFechaNacimiento[0];
            A59UsuarioCalleNum = BC000A8_A59UsuarioCalleNum[0];
            A60UsuarioColonia = BC000A8_A60UsuarioColonia[0];
            A61UsuarioDelegacion = BC000A8_A61UsuarioDelegacion[0];
            A62UsuarioCP = BC000A8_A62UsuarioCP[0];
            A63UsuarioZona = BC000A8_A63UsuarioZona[0];
            A64UsuarioCelular = BC000A8_A64UsuarioCelular[0];
            A65UsuarioTelefonoSucursal = BC000A8_A65UsuarioTelefonoSucursal[0];
            A17PaisDescripcion = BC000A8_A17PaisDescripcion[0];
            A2EstadoDescripcion = BC000A8_A2EstadoDescripcion[0];
            A5CiudadDescripcion = BC000A8_A5CiudadDescripcion[0];
            A66UsuarioSucursal = BC000A8_A66UsuarioSucursal[0];
            A67UsuarioProducto = BC000A8_A67UsuarioProducto[0];
            n67UsuarioProducto = BC000A8_n67UsuarioProducto[0];
            A40UsuarioRol = BC000A8_A40UsuarioRol[0];
            A82UsuarioNoCuentaBROXEL = BC000A8_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = BC000A8_A83UsuarioReferenciaBROXEL[0];
            A87UsuarioFechaRegistro = BC000A8_A87UsuarioFechaRegistro[0];
            n87UsuarioFechaRegistro = BC000A8_n87UsuarioFechaRegistro[0];
            A92UsuarioAvisoPrivacidad = BC000A8_A92UsuarioAvisoPrivacidad[0];
            A13PuestoID = BC000A8_A13PuestoID[0];
            n13PuestoID = BC000A8_n13PuestoID[0];
            A4CiudadID = BC000A8_A4CiudadID[0];
            n4CiudadID = BC000A8_n4CiudadID[0];
            A1EstadoID = BC000A8_A1EstadoID[0];
            A16PaisID = BC000A8_A16PaisID[0];
            ZM0A18( -11) ;
         }
         pr_default.close(6);
         OnLoadActions0A18( ) ;
      }

      protected void OnLoadActions0A18( )
      {
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
      }

      protected void CheckExtendedTable0A18( )
      {
         standaloneModal( ) ;
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
         if ( ! ( GxRegex.IsMatch(A31UsuarioCorreo,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Correo", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000A4 */
         pr_default.execute(2, new Object[] {n13PuestoID, A13PuestoID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A13PuestoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Puesto", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PUESTOID");
               AnyError = 1;
            }
         }
         A14PuestoDescripcion = BC000A4_A14PuestoDescripcion[0];
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A53UsuarioGenero, "Masculino") == 0 ) || ( StringUtil.StrCmp(A53UsuarioGenero, "Femenino") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Género", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A54UsuarioDirectoAsociado, "Directo") == 0 ) || ( StringUtil.StrCmp(A54UsuarioDirectoAsociado, "Asociado") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A54UsuarioDirectoAsociado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Directo/Asociado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A57UsuarioFechaNacimiento) || ( DateTimeUtil.ResetTime ( A57UsuarioFechaNacimiento ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1000, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha de nacimiento", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A63UsuarioZona, "Centro") == 0 ) || ( StringUtil.StrCmp(A63UsuarioZona, "Centro América") == 0 ) || ( StringUtil.StrCmp(A63UsuarioZona, "Norte") == 0 ) || ( StringUtil.StrCmp(A63UsuarioZona, "Pacífico") == 0 ) || ( StringUtil.StrCmp(A63UsuarioZona, "Sur") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Usuario Zona", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000A5 */
         pr_default.execute(3, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
            }
         }
         A5CiudadDescripcion = BC000A5_A5CiudadDescripcion[0];
         A1EstadoID = BC000A5_A1EstadoID[0];
         pr_default.close(3);
         /* Using cursor BC000A6 */
         pr_default.execute(4, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A2EstadoDescripcion = BC000A6_A2EstadoDescripcion[0];
         A16PaisID = BC000A6_A16PaisID[0];
         pr_default.close(4);
         /* Using cursor BC000A7 */
         pr_default.execute(5, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = BC000A7_A17PaisDescripcion[0];
         pr_default.close(5);
         if ( ! ( ( StringUtil.StrCmp(A67UsuarioProducto, "Auto y Camioneta") == 0 ) || ( StringUtil.StrCmp(A67UsuarioProducto, "Auto y Camioneta/Camión") == 0 ) || ( StringUtil.StrCmp(A67UsuarioProducto, "Camión") == 0 ) || ( StringUtil.StrCmp(A67UsuarioProducto, "Empleado") == 0 ) || ( StringUtil.StrCmp(A67UsuarioProducto, "OTR/Camión") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A67UsuarioProducto)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Producto que vendes", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A40UsuarioRol, "Super Administrador") == 0 ) || ( StringUtil.StrCmp(A40UsuarioRol, "Administrador Yokohama") == 0 ) || ( StringUtil.StrCmp(A40UsuarioRol, "Asesor") == 0 ) || ( StringUtil.StrCmp(A40UsuarioRol, "Participante") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Rol", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A87UsuarioFechaRegistro) || ( DateTimeUtil.ResetTime ( A87UsuarioFechaRegistro ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1000, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Usuario Fecha Registro", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0A18( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0A18( )
      {
         /* Using cursor BC000A9 */
         pr_default.execute(7, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000A3 */
         pr_default.execute(1, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A18( 11) ;
            RcdFound18 = 1;
            A29UsuarioID = BC000A3_A29UsuarioID[0];
            A30UsuarioNombre = BC000A3_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000A3_A51UsuarioApellido[0];
            A31UsuarioCorreo = BC000A3_A31UsuarioCorreo[0];
            A32UsuarioPass = BC000A3_A32UsuarioPass[0];
            A33UsuarioKey = BC000A3_A33UsuarioKey[0];
            A53UsuarioGenero = BC000A3_A53UsuarioGenero[0];
            A54UsuarioDirectoAsociado = BC000A3_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = BC000A3_n54UsuarioDirectoAsociado[0];
            A55UsuarioRazonSocialAsociado = BC000A3_A55UsuarioRazonSocialAsociado[0];
            A56UsuarioNombreComercial = BC000A3_A56UsuarioNombreComercial[0];
            A57UsuarioFechaNacimiento = BC000A3_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = BC000A3_n57UsuarioFechaNacimiento[0];
            A59UsuarioCalleNum = BC000A3_A59UsuarioCalleNum[0];
            A60UsuarioColonia = BC000A3_A60UsuarioColonia[0];
            A61UsuarioDelegacion = BC000A3_A61UsuarioDelegacion[0];
            A62UsuarioCP = BC000A3_A62UsuarioCP[0];
            A63UsuarioZona = BC000A3_A63UsuarioZona[0];
            A64UsuarioCelular = BC000A3_A64UsuarioCelular[0];
            A65UsuarioTelefonoSucursal = BC000A3_A65UsuarioTelefonoSucursal[0];
            A66UsuarioSucursal = BC000A3_A66UsuarioSucursal[0];
            A67UsuarioProducto = BC000A3_A67UsuarioProducto[0];
            n67UsuarioProducto = BC000A3_n67UsuarioProducto[0];
            A40UsuarioRol = BC000A3_A40UsuarioRol[0];
            A82UsuarioNoCuentaBROXEL = BC000A3_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = BC000A3_A83UsuarioReferenciaBROXEL[0];
            A87UsuarioFechaRegistro = BC000A3_A87UsuarioFechaRegistro[0];
            n87UsuarioFechaRegistro = BC000A3_n87UsuarioFechaRegistro[0];
            A92UsuarioAvisoPrivacidad = BC000A3_A92UsuarioAvisoPrivacidad[0];
            A13PuestoID = BC000A3_A13PuestoID[0];
            n13PuestoID = BC000A3_n13PuestoID[0];
            A4CiudadID = BC000A3_A4CiudadID[0];
            n4CiudadID = BC000A3_n4CiudadID[0];
            Z29UsuarioID = A29UsuarioID;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0A18( ) ;
            if ( AnyError == 1 )
            {
               RcdFound18 = 0;
               InitializeNonKey0A18( ) ;
            }
            Gx_mode = sMode18;
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0A18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode18;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A18( ) ;
         if ( RcdFound18 == 0 )
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
         CONFIRM_0A0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0A18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000A2 */
            pr_default.execute(0, new Object[] {A29UsuarioID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuario"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z30UsuarioNombre, BC000A2_A30UsuarioNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z51UsuarioApellido, BC000A2_A51UsuarioApellido[0]) != 0 ) || ( StringUtil.StrCmp(Z31UsuarioCorreo, BC000A2_A31UsuarioCorreo[0]) != 0 ) || ( StringUtil.StrCmp(Z32UsuarioPass, BC000A2_A32UsuarioPass[0]) != 0 ) || ( StringUtil.StrCmp(Z33UsuarioKey, BC000A2_A33UsuarioKey[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z53UsuarioGenero, BC000A2_A53UsuarioGenero[0]) != 0 ) || ( StringUtil.StrCmp(Z54UsuarioDirectoAsociado, BC000A2_A54UsuarioDirectoAsociado[0]) != 0 ) || ( StringUtil.StrCmp(Z55UsuarioRazonSocialAsociado, BC000A2_A55UsuarioRazonSocialAsociado[0]) != 0 ) || ( StringUtil.StrCmp(Z56UsuarioNombreComercial, BC000A2_A56UsuarioNombreComercial[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z57UsuarioFechaNacimiento ) != DateTimeUtil.ResetTime ( BC000A2_A57UsuarioFechaNacimiento[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z59UsuarioCalleNum, BC000A2_A59UsuarioCalleNum[0]) != 0 ) || ( StringUtil.StrCmp(Z60UsuarioColonia, BC000A2_A60UsuarioColonia[0]) != 0 ) || ( StringUtil.StrCmp(Z61UsuarioDelegacion, BC000A2_A61UsuarioDelegacion[0]) != 0 ) || ( Z62UsuarioCP != BC000A2_A62UsuarioCP[0] ) || ( StringUtil.StrCmp(Z63UsuarioZona, BC000A2_A63UsuarioZona[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z64UsuarioCelular != BC000A2_A64UsuarioCelular[0] ) || ( Z65UsuarioTelefonoSucursal != BC000A2_A65UsuarioTelefonoSucursal[0] ) || ( StringUtil.StrCmp(Z66UsuarioSucursal, BC000A2_A66UsuarioSucursal[0]) != 0 ) || ( StringUtil.StrCmp(Z67UsuarioProducto, BC000A2_A67UsuarioProducto[0]) != 0 ) || ( StringUtil.StrCmp(Z40UsuarioRol, BC000A2_A40UsuarioRol[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z82UsuarioNoCuentaBROXEL, BC000A2_A82UsuarioNoCuentaBROXEL[0]) != 0 ) || ( StringUtil.StrCmp(Z83UsuarioReferenciaBROXEL, BC000A2_A83UsuarioReferenciaBROXEL[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z87UsuarioFechaRegistro ) != DateTimeUtil.ResetTime ( BC000A2_A87UsuarioFechaRegistro[0] ) ) || ( Z92UsuarioAvisoPrivacidad != BC000A2_A92UsuarioAvisoPrivacidad[0] ) || ( Z13PuestoID != BC000A2_A13PuestoID[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z4CiudadID != BC000A2_A4CiudadID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Usuario"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A18( )
      {
         BeforeValidate0A18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A18( 0) ;
            CheckOptimisticConcurrency0A18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A10 */
                     pr_default.execute(8, new Object[] {A30UsuarioNombre, A51UsuarioApellido, A31UsuarioCorreo, A32UsuarioPass, A33UsuarioKey, A53UsuarioGenero, n54UsuarioDirectoAsociado, A54UsuarioDirectoAsociado, A55UsuarioRazonSocialAsociado, A56UsuarioNombreComercial, n57UsuarioFechaNacimiento, A57UsuarioFechaNacimiento, A59UsuarioCalleNum, A60UsuarioColonia, A61UsuarioDelegacion, A62UsuarioCP, A63UsuarioZona, A64UsuarioCelular, A65UsuarioTelefonoSucursal, A66UsuarioSucursal, n67UsuarioProducto, A67UsuarioProducto, A40UsuarioRol, A82UsuarioNoCuentaBROXEL, A83UsuarioReferenciaBROXEL, n87UsuarioFechaRegistro, A87UsuarioFechaRegistro, A92UsuarioAvisoPrivacidad, n13PuestoID, A13PuestoID, n4CiudadID, A4CiudadID});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000A11 */
                     pr_default.execute(9);
                     A29UsuarioID = BC000A11_A29UsuarioID[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Usuario");
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
               Load0A18( ) ;
            }
            EndLevel0A18( ) ;
         }
         CloseExtendedTableCursors0A18( ) ;
      }

      protected void Update0A18( )
      {
         BeforeValidate0A18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A12 */
                     pr_default.execute(10, new Object[] {A30UsuarioNombre, A51UsuarioApellido, A31UsuarioCorreo, A32UsuarioPass, A33UsuarioKey, A53UsuarioGenero, n54UsuarioDirectoAsociado, A54UsuarioDirectoAsociado, A55UsuarioRazonSocialAsociado, A56UsuarioNombreComercial, n57UsuarioFechaNacimiento, A57UsuarioFechaNacimiento, A59UsuarioCalleNum, A60UsuarioColonia, A61UsuarioDelegacion, A62UsuarioCP, A63UsuarioZona, A64UsuarioCelular, A65UsuarioTelefonoSucursal, A66UsuarioSucursal, n67UsuarioProducto, A67UsuarioProducto, A40UsuarioRol, A82UsuarioNoCuentaBROXEL, A83UsuarioReferenciaBROXEL, n87UsuarioFechaRegistro, A87UsuarioFechaRegistro, A92UsuarioAvisoPrivacidad, n13PuestoID, A13PuestoID, n4CiudadID, A4CiudadID, A29UsuarioID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Usuario");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuario"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A18( ) ;
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
            EndLevel0A18( ) ;
         }
         CloseExtendedTableCursors0A18( ) ;
      }

      protected void DeferredUpdate0A18( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0A18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A18( ) ;
            AfterConfirm0A18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000A13 */
                  pr_default.execute(11, new Object[] {A29UsuarioID});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Usuario");
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
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0A18( ) ;
         Gx_mode = sMode18;
      }

      protected void OnDeleteControls0A18( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            /* Using cursor BC000A14 */
            pr_default.execute(12, new Object[] {n13PuestoID, A13PuestoID});
            A14PuestoDescripcion = BC000A14_A14PuestoDescripcion[0];
            pr_default.close(12);
            /* Using cursor BC000A15 */
            pr_default.execute(13, new Object[] {n4CiudadID, A4CiudadID});
            A5CiudadDescripcion = BC000A15_A5CiudadDescripcion[0];
            A1EstadoID = BC000A15_A1EstadoID[0];
            pr_default.close(13);
            /* Using cursor BC000A16 */
            pr_default.execute(14, new Object[] {A1EstadoID});
            A2EstadoDescripcion = BC000A16_A2EstadoDescripcion[0];
            A16PaisID = BC000A16_A16PaisID[0];
            pr_default.close(14);
            /* Using cursor BC000A17 */
            pr_default.execute(15, new Object[] {A16PaisID});
            A17PaisDescripcion = BC000A17_A17PaisDescripcion[0];
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000A18 */
            pr_default.execute(16, new Object[] {A29UsuarioID});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Factura", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor BC000A19 */
            pr_default.execute(17, new Object[] {A29UsuarioID});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "DistribuidoresUsuario", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void EndLevel0A18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A18( ) ;
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

      public void ScanKeyStart0A18( )
      {
         /* Using cursor BC000A20 */
         pr_default.execute(18, new Object[] {A29UsuarioID});
         RcdFound18 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound18 = 1;
            A29UsuarioID = BC000A20_A29UsuarioID[0];
            A30UsuarioNombre = BC000A20_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000A20_A51UsuarioApellido[0];
            A31UsuarioCorreo = BC000A20_A31UsuarioCorreo[0];
            A32UsuarioPass = BC000A20_A32UsuarioPass[0];
            A33UsuarioKey = BC000A20_A33UsuarioKey[0];
            A14PuestoDescripcion = BC000A20_A14PuestoDescripcion[0];
            A53UsuarioGenero = BC000A20_A53UsuarioGenero[0];
            A54UsuarioDirectoAsociado = BC000A20_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = BC000A20_n54UsuarioDirectoAsociado[0];
            A55UsuarioRazonSocialAsociado = BC000A20_A55UsuarioRazonSocialAsociado[0];
            A56UsuarioNombreComercial = BC000A20_A56UsuarioNombreComercial[0];
            A57UsuarioFechaNacimiento = BC000A20_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = BC000A20_n57UsuarioFechaNacimiento[0];
            A59UsuarioCalleNum = BC000A20_A59UsuarioCalleNum[0];
            A60UsuarioColonia = BC000A20_A60UsuarioColonia[0];
            A61UsuarioDelegacion = BC000A20_A61UsuarioDelegacion[0];
            A62UsuarioCP = BC000A20_A62UsuarioCP[0];
            A63UsuarioZona = BC000A20_A63UsuarioZona[0];
            A64UsuarioCelular = BC000A20_A64UsuarioCelular[0];
            A65UsuarioTelefonoSucursal = BC000A20_A65UsuarioTelefonoSucursal[0];
            A17PaisDescripcion = BC000A20_A17PaisDescripcion[0];
            A2EstadoDescripcion = BC000A20_A2EstadoDescripcion[0];
            A5CiudadDescripcion = BC000A20_A5CiudadDescripcion[0];
            A66UsuarioSucursal = BC000A20_A66UsuarioSucursal[0];
            A67UsuarioProducto = BC000A20_A67UsuarioProducto[0];
            n67UsuarioProducto = BC000A20_n67UsuarioProducto[0];
            A40UsuarioRol = BC000A20_A40UsuarioRol[0];
            A82UsuarioNoCuentaBROXEL = BC000A20_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = BC000A20_A83UsuarioReferenciaBROXEL[0];
            A87UsuarioFechaRegistro = BC000A20_A87UsuarioFechaRegistro[0];
            n87UsuarioFechaRegistro = BC000A20_n87UsuarioFechaRegistro[0];
            A92UsuarioAvisoPrivacidad = BC000A20_A92UsuarioAvisoPrivacidad[0];
            A13PuestoID = BC000A20_A13PuestoID[0];
            n13PuestoID = BC000A20_n13PuestoID[0];
            A4CiudadID = BC000A20_A4CiudadID[0];
            n4CiudadID = BC000A20_n4CiudadID[0];
            A1EstadoID = BC000A20_A1EstadoID[0];
            A16PaisID = BC000A20_A16PaisID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0A18( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound18 = 0;
         ScanKeyLoad0A18( ) ;
      }

      protected void ScanKeyLoad0A18( )
      {
         sMode18 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound18 = 1;
            A29UsuarioID = BC000A20_A29UsuarioID[0];
            A30UsuarioNombre = BC000A20_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000A20_A51UsuarioApellido[0];
            A31UsuarioCorreo = BC000A20_A31UsuarioCorreo[0];
            A32UsuarioPass = BC000A20_A32UsuarioPass[0];
            A33UsuarioKey = BC000A20_A33UsuarioKey[0];
            A14PuestoDescripcion = BC000A20_A14PuestoDescripcion[0];
            A53UsuarioGenero = BC000A20_A53UsuarioGenero[0];
            A54UsuarioDirectoAsociado = BC000A20_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = BC000A20_n54UsuarioDirectoAsociado[0];
            A55UsuarioRazonSocialAsociado = BC000A20_A55UsuarioRazonSocialAsociado[0];
            A56UsuarioNombreComercial = BC000A20_A56UsuarioNombreComercial[0];
            A57UsuarioFechaNacimiento = BC000A20_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = BC000A20_n57UsuarioFechaNacimiento[0];
            A59UsuarioCalleNum = BC000A20_A59UsuarioCalleNum[0];
            A60UsuarioColonia = BC000A20_A60UsuarioColonia[0];
            A61UsuarioDelegacion = BC000A20_A61UsuarioDelegacion[0];
            A62UsuarioCP = BC000A20_A62UsuarioCP[0];
            A63UsuarioZona = BC000A20_A63UsuarioZona[0];
            A64UsuarioCelular = BC000A20_A64UsuarioCelular[0];
            A65UsuarioTelefonoSucursal = BC000A20_A65UsuarioTelefonoSucursal[0];
            A17PaisDescripcion = BC000A20_A17PaisDescripcion[0];
            A2EstadoDescripcion = BC000A20_A2EstadoDescripcion[0];
            A5CiudadDescripcion = BC000A20_A5CiudadDescripcion[0];
            A66UsuarioSucursal = BC000A20_A66UsuarioSucursal[0];
            A67UsuarioProducto = BC000A20_A67UsuarioProducto[0];
            n67UsuarioProducto = BC000A20_n67UsuarioProducto[0];
            A40UsuarioRol = BC000A20_A40UsuarioRol[0];
            A82UsuarioNoCuentaBROXEL = BC000A20_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = BC000A20_A83UsuarioReferenciaBROXEL[0];
            A87UsuarioFechaRegistro = BC000A20_A87UsuarioFechaRegistro[0];
            n87UsuarioFechaRegistro = BC000A20_n87UsuarioFechaRegistro[0];
            A92UsuarioAvisoPrivacidad = BC000A20_A92UsuarioAvisoPrivacidad[0];
            A13PuestoID = BC000A20_A13PuestoID[0];
            n13PuestoID = BC000A20_n13PuestoID[0];
            A4CiudadID = BC000A20_A4CiudadID[0];
            n4CiudadID = BC000A20_n4CiudadID[0];
            A1EstadoID = BC000A20_A1EstadoID[0];
            A16PaisID = BC000A20_A16PaisID[0];
         }
         Gx_mode = sMode18;
      }

      protected void ScanKeyEnd0A18( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0A18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A18( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A18( )
      {
      }

      protected void send_integrity_lvl_hashes0A18( )
      {
      }

      protected void AddRow0A18( )
      {
         VarsToRow18( bcUsuario) ;
      }

      protected void ReadRow0A18( )
      {
         RowToVars18( bcUsuario, 1) ;
      }

      protected void InitializeNonKey0A18( )
      {
         A52UsuarioNombreCompleto = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A31UsuarioCorreo = "";
         A32UsuarioPass = "";
         A33UsuarioKey = "";
         A13PuestoID = 0;
         n13PuestoID = false;
         A14PuestoDescripcion = "";
         A53UsuarioGenero = "";
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
         A63UsuarioZona = "";
         A64UsuarioCelular = 0;
         A65UsuarioTelefonoSucursal = 0;
         A16PaisID = 0;
         A17PaisDescripcion = "";
         A1EstadoID = 0;
         A2EstadoDescripcion = "";
         A4CiudadID = 0;
         n4CiudadID = false;
         A5CiudadDescripcion = "";
         A66UsuarioSucursal = "";
         A67UsuarioProducto = "";
         n67UsuarioProducto = false;
         A40UsuarioRol = "";
         A82UsuarioNoCuentaBROXEL = "";
         A83UsuarioReferenciaBROXEL = "";
         A87UsuarioFechaRegistro = DateTime.MinValue;
         n87UsuarioFechaRegistro = false;
         A92UsuarioAvisoPrivacidad = false;
         Z30UsuarioNombre = "";
         Z51UsuarioApellido = "";
         Z31UsuarioCorreo = "";
         Z32UsuarioPass = "";
         Z33UsuarioKey = "";
         Z53UsuarioGenero = "";
         Z54UsuarioDirectoAsociado = "";
         Z55UsuarioRazonSocialAsociado = "";
         Z56UsuarioNombreComercial = "";
         Z57UsuarioFechaNacimiento = DateTime.MinValue;
         Z59UsuarioCalleNum = "";
         Z60UsuarioColonia = "";
         Z61UsuarioDelegacion = "";
         Z62UsuarioCP = 0;
         Z63UsuarioZona = "";
         Z64UsuarioCelular = 0;
         Z65UsuarioTelefonoSucursal = 0;
         Z66UsuarioSucursal = "";
         Z67UsuarioProducto = "";
         Z40UsuarioRol = "";
         Z82UsuarioNoCuentaBROXEL = "";
         Z83UsuarioReferenciaBROXEL = "";
         Z87UsuarioFechaRegistro = DateTime.MinValue;
         Z92UsuarioAvisoPrivacidad = false;
         Z13PuestoID = 0;
         Z4CiudadID = 0;
      }

      protected void InitAll0A18( )
      {
         A29UsuarioID = 0;
         InitializeNonKey0A18( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A92UsuarioAvisoPrivacidad = i92UsuarioAvisoPrivacidad;
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

      public void VarsToRow18( SdtUsuario obj18 )
      {
         obj18.gxTpr_Mode = Gx_mode;
         obj18.gxTpr_Usuarionombrecompleto = A52UsuarioNombreCompleto;
         obj18.gxTpr_Usuarionombre = A30UsuarioNombre;
         obj18.gxTpr_Usuarioapellido = A51UsuarioApellido;
         obj18.gxTpr_Usuariocorreo = A31UsuarioCorreo;
         obj18.gxTpr_Usuariopass = A32UsuarioPass;
         obj18.gxTpr_Usuariokey = A33UsuarioKey;
         obj18.gxTpr_Puestoid = A13PuestoID;
         obj18.gxTpr_Puestodescripcion = A14PuestoDescripcion;
         obj18.gxTpr_Usuariogenero = A53UsuarioGenero;
         obj18.gxTpr_Usuariodirectoasociado = A54UsuarioDirectoAsociado;
         obj18.gxTpr_Usuariorazonsocialasociado = A55UsuarioRazonSocialAsociado;
         obj18.gxTpr_Usuarionombrecomercial = A56UsuarioNombreComercial;
         obj18.gxTpr_Usuariofechanacimiento = A57UsuarioFechaNacimiento;
         obj18.gxTpr_Usuariocallenum = A59UsuarioCalleNum;
         obj18.gxTpr_Usuariocolonia = A60UsuarioColonia;
         obj18.gxTpr_Usuariodelegacion = A61UsuarioDelegacion;
         obj18.gxTpr_Usuariocp = A62UsuarioCP;
         obj18.gxTpr_Usuariozona = A63UsuarioZona;
         obj18.gxTpr_Usuariocelular = A64UsuarioCelular;
         obj18.gxTpr_Usuariotelefonosucursal = A65UsuarioTelefonoSucursal;
         obj18.gxTpr_Paisid = A16PaisID;
         obj18.gxTpr_Paisdescripcion = A17PaisDescripcion;
         obj18.gxTpr_Estadoid = A1EstadoID;
         obj18.gxTpr_Estadodescripcion = A2EstadoDescripcion;
         obj18.gxTpr_Ciudadid = A4CiudadID;
         obj18.gxTpr_Ciudaddescripcion = A5CiudadDescripcion;
         obj18.gxTpr_Usuariosucursal = A66UsuarioSucursal;
         obj18.gxTpr_Usuarioproducto = A67UsuarioProducto;
         obj18.gxTpr_Usuariorol = A40UsuarioRol;
         obj18.gxTpr_Usuarionocuentabroxel = A82UsuarioNoCuentaBROXEL;
         obj18.gxTpr_Usuarioreferenciabroxel = A83UsuarioReferenciaBROXEL;
         obj18.gxTpr_Usuariofecharegistro = A87UsuarioFechaRegistro;
         obj18.gxTpr_Usuarioavisoprivacidad = A92UsuarioAvisoPrivacidad;
         obj18.gxTpr_Usuarioid = A29UsuarioID;
         obj18.gxTpr_Usuarioid_Z = Z29UsuarioID;
         obj18.gxTpr_Usuarionombre_Z = Z30UsuarioNombre;
         obj18.gxTpr_Usuarioapellido_Z = Z51UsuarioApellido;
         obj18.gxTpr_Usuarionombrecompleto_Z = Z52UsuarioNombreCompleto;
         obj18.gxTpr_Usuariocorreo_Z = Z31UsuarioCorreo;
         obj18.gxTpr_Usuariopass_Z = Z32UsuarioPass;
         obj18.gxTpr_Usuariokey_Z = Z33UsuarioKey;
         obj18.gxTpr_Puestoid_Z = Z13PuestoID;
         obj18.gxTpr_Puestodescripcion_Z = Z14PuestoDescripcion;
         obj18.gxTpr_Usuariogenero_Z = Z53UsuarioGenero;
         obj18.gxTpr_Usuariodirectoasociado_Z = Z54UsuarioDirectoAsociado;
         obj18.gxTpr_Usuariorazonsocialasociado_Z = Z55UsuarioRazonSocialAsociado;
         obj18.gxTpr_Usuarionombrecomercial_Z = Z56UsuarioNombreComercial;
         obj18.gxTpr_Usuariofechanacimiento_Z = Z57UsuarioFechaNacimiento;
         obj18.gxTpr_Usuariocallenum_Z = Z59UsuarioCalleNum;
         obj18.gxTpr_Usuariocolonia_Z = Z60UsuarioColonia;
         obj18.gxTpr_Usuariodelegacion_Z = Z61UsuarioDelegacion;
         obj18.gxTpr_Usuariocp_Z = Z62UsuarioCP;
         obj18.gxTpr_Usuariozona_Z = Z63UsuarioZona;
         obj18.gxTpr_Usuariocelular_Z = Z64UsuarioCelular;
         obj18.gxTpr_Usuariotelefonosucursal_Z = Z65UsuarioTelefonoSucursal;
         obj18.gxTpr_Paisid_Z = Z16PaisID;
         obj18.gxTpr_Paisdescripcion_Z = Z17PaisDescripcion;
         obj18.gxTpr_Estadoid_Z = Z1EstadoID;
         obj18.gxTpr_Estadodescripcion_Z = Z2EstadoDescripcion;
         obj18.gxTpr_Ciudadid_Z = Z4CiudadID;
         obj18.gxTpr_Ciudaddescripcion_Z = Z5CiudadDescripcion;
         obj18.gxTpr_Usuariosucursal_Z = Z66UsuarioSucursal;
         obj18.gxTpr_Usuarioproducto_Z = Z67UsuarioProducto;
         obj18.gxTpr_Usuariorol_Z = Z40UsuarioRol;
         obj18.gxTpr_Usuarionocuentabroxel_Z = Z82UsuarioNoCuentaBROXEL;
         obj18.gxTpr_Usuarioreferenciabroxel_Z = Z83UsuarioReferenciaBROXEL;
         obj18.gxTpr_Usuariofecharegistro_Z = Z87UsuarioFechaRegistro;
         obj18.gxTpr_Usuarioavisoprivacidad_Z = Z92UsuarioAvisoPrivacidad;
         obj18.gxTpr_Puestoid_N = (short)(Convert.ToInt16(n13PuestoID));
         obj18.gxTpr_Usuariodirectoasociado_N = (short)(Convert.ToInt16(n54UsuarioDirectoAsociado));
         obj18.gxTpr_Usuariofechanacimiento_N = (short)(Convert.ToInt16(n57UsuarioFechaNacimiento));
         obj18.gxTpr_Ciudadid_N = (short)(Convert.ToInt16(n4CiudadID));
         obj18.gxTpr_Usuarioproducto_N = (short)(Convert.ToInt16(n67UsuarioProducto));
         obj18.gxTpr_Usuariofecharegistro_N = (short)(Convert.ToInt16(n87UsuarioFechaRegistro));
         obj18.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow18( SdtUsuario obj18 )
      {
         obj18.gxTpr_Usuarioid = A29UsuarioID;
         return  ;
      }

      public void RowToVars18( SdtUsuario obj18 ,
                               int forceLoad )
      {
         Gx_mode = obj18.gxTpr_Mode;
         A52UsuarioNombreCompleto = obj18.gxTpr_Usuarionombrecompleto;
         A30UsuarioNombre = obj18.gxTpr_Usuarionombre;
         A51UsuarioApellido = obj18.gxTpr_Usuarioapellido;
         A31UsuarioCorreo = obj18.gxTpr_Usuariocorreo;
         A32UsuarioPass = obj18.gxTpr_Usuariopass;
         A33UsuarioKey = obj18.gxTpr_Usuariokey;
         A13PuestoID = obj18.gxTpr_Puestoid;
         n13PuestoID = false;
         A14PuestoDescripcion = obj18.gxTpr_Puestodescripcion;
         A53UsuarioGenero = obj18.gxTpr_Usuariogenero;
         A54UsuarioDirectoAsociado = obj18.gxTpr_Usuariodirectoasociado;
         n54UsuarioDirectoAsociado = false;
         A55UsuarioRazonSocialAsociado = obj18.gxTpr_Usuariorazonsocialasociado;
         A56UsuarioNombreComercial = obj18.gxTpr_Usuarionombrecomercial;
         A57UsuarioFechaNacimiento = obj18.gxTpr_Usuariofechanacimiento;
         n57UsuarioFechaNacimiento = false;
         A59UsuarioCalleNum = obj18.gxTpr_Usuariocallenum;
         A60UsuarioColonia = obj18.gxTpr_Usuariocolonia;
         A61UsuarioDelegacion = obj18.gxTpr_Usuariodelegacion;
         A62UsuarioCP = obj18.gxTpr_Usuariocp;
         A63UsuarioZona = obj18.gxTpr_Usuariozona;
         A64UsuarioCelular = obj18.gxTpr_Usuariocelular;
         A65UsuarioTelefonoSucursal = obj18.gxTpr_Usuariotelefonosucursal;
         A16PaisID = obj18.gxTpr_Paisid;
         A17PaisDescripcion = obj18.gxTpr_Paisdescripcion;
         A1EstadoID = obj18.gxTpr_Estadoid;
         A2EstadoDescripcion = obj18.gxTpr_Estadodescripcion;
         A4CiudadID = obj18.gxTpr_Ciudadid;
         n4CiudadID = false;
         A5CiudadDescripcion = obj18.gxTpr_Ciudaddescripcion;
         A66UsuarioSucursal = obj18.gxTpr_Usuariosucursal;
         A67UsuarioProducto = obj18.gxTpr_Usuarioproducto;
         n67UsuarioProducto = false;
         A40UsuarioRol = obj18.gxTpr_Usuariorol;
         A82UsuarioNoCuentaBROXEL = obj18.gxTpr_Usuarionocuentabroxel;
         A83UsuarioReferenciaBROXEL = obj18.gxTpr_Usuarioreferenciabroxel;
         A87UsuarioFechaRegistro = obj18.gxTpr_Usuariofecharegistro;
         n87UsuarioFechaRegistro = false;
         A92UsuarioAvisoPrivacidad = obj18.gxTpr_Usuarioavisoprivacidad;
         A29UsuarioID = obj18.gxTpr_Usuarioid;
         Z29UsuarioID = obj18.gxTpr_Usuarioid_Z;
         Z30UsuarioNombre = obj18.gxTpr_Usuarionombre_Z;
         Z51UsuarioApellido = obj18.gxTpr_Usuarioapellido_Z;
         Z52UsuarioNombreCompleto = obj18.gxTpr_Usuarionombrecompleto_Z;
         Z31UsuarioCorreo = obj18.gxTpr_Usuariocorreo_Z;
         Z32UsuarioPass = obj18.gxTpr_Usuariopass_Z;
         Z33UsuarioKey = obj18.gxTpr_Usuariokey_Z;
         Z13PuestoID = obj18.gxTpr_Puestoid_Z;
         Z14PuestoDescripcion = obj18.gxTpr_Puestodescripcion_Z;
         Z53UsuarioGenero = obj18.gxTpr_Usuariogenero_Z;
         Z54UsuarioDirectoAsociado = obj18.gxTpr_Usuariodirectoasociado_Z;
         Z55UsuarioRazonSocialAsociado = obj18.gxTpr_Usuariorazonsocialasociado_Z;
         Z56UsuarioNombreComercial = obj18.gxTpr_Usuarionombrecomercial_Z;
         Z57UsuarioFechaNacimiento = obj18.gxTpr_Usuariofechanacimiento_Z;
         Z59UsuarioCalleNum = obj18.gxTpr_Usuariocallenum_Z;
         Z60UsuarioColonia = obj18.gxTpr_Usuariocolonia_Z;
         Z61UsuarioDelegacion = obj18.gxTpr_Usuariodelegacion_Z;
         Z62UsuarioCP = obj18.gxTpr_Usuariocp_Z;
         Z63UsuarioZona = obj18.gxTpr_Usuariozona_Z;
         Z64UsuarioCelular = obj18.gxTpr_Usuariocelular_Z;
         Z65UsuarioTelefonoSucursal = obj18.gxTpr_Usuariotelefonosucursal_Z;
         Z16PaisID = obj18.gxTpr_Paisid_Z;
         Z17PaisDescripcion = obj18.gxTpr_Paisdescripcion_Z;
         Z1EstadoID = obj18.gxTpr_Estadoid_Z;
         Z2EstadoDescripcion = obj18.gxTpr_Estadodescripcion_Z;
         Z4CiudadID = obj18.gxTpr_Ciudadid_Z;
         Z5CiudadDescripcion = obj18.gxTpr_Ciudaddescripcion_Z;
         Z66UsuarioSucursal = obj18.gxTpr_Usuariosucursal_Z;
         Z67UsuarioProducto = obj18.gxTpr_Usuarioproducto_Z;
         Z40UsuarioRol = obj18.gxTpr_Usuariorol_Z;
         Z82UsuarioNoCuentaBROXEL = obj18.gxTpr_Usuarionocuentabroxel_Z;
         Z83UsuarioReferenciaBROXEL = obj18.gxTpr_Usuarioreferenciabroxel_Z;
         Z87UsuarioFechaRegistro = obj18.gxTpr_Usuariofecharegistro_Z;
         Z92UsuarioAvisoPrivacidad = obj18.gxTpr_Usuarioavisoprivacidad_Z;
         n13PuestoID = (bool)(Convert.ToBoolean(obj18.gxTpr_Puestoid_N));
         n54UsuarioDirectoAsociado = (bool)(Convert.ToBoolean(obj18.gxTpr_Usuariodirectoasociado_N));
         n57UsuarioFechaNacimiento = (bool)(Convert.ToBoolean(obj18.gxTpr_Usuariofechanacimiento_N));
         n4CiudadID = (bool)(Convert.ToBoolean(obj18.gxTpr_Ciudadid_N));
         n67UsuarioProducto = (bool)(Convert.ToBoolean(obj18.gxTpr_Usuarioproducto_N));
         n87UsuarioFechaRegistro = (bool)(Convert.ToBoolean(obj18.gxTpr_Usuariofecharegistro_N));
         Gx_mode = obj18.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A29UsuarioID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0A18( ) ;
         ScanKeyStart0A18( ) ;
         if ( RcdFound18 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z29UsuarioID = A29UsuarioID;
         }
         ZM0A18( -11) ;
         OnLoadActions0A18( ) ;
         AddRow0A18( ) ;
         ScanKeyEnd0A18( ) ;
         if ( RcdFound18 == 0 )
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
         RowToVars18( bcUsuario, 0) ;
         ScanKeyStart0A18( ) ;
         if ( RcdFound18 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z29UsuarioID = A29UsuarioID;
         }
         ZM0A18( -11) ;
         OnLoadActions0A18( ) ;
         AddRow0A18( ) ;
         ScanKeyEnd0A18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0A18( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0A18( ) ;
         }
         else
         {
            if ( RcdFound18 == 1 )
            {
               if ( A29UsuarioID != Z29UsuarioID )
               {
                  A29UsuarioID = Z29UsuarioID;
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
                  Update0A18( ) ;
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
                  if ( A29UsuarioID != Z29UsuarioID )
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
                        Insert0A18( ) ;
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
                        Insert0A18( ) ;
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
         RowToVars18( bcUsuario, 1) ;
         SaveImpl( ) ;
         VarsToRow18( bcUsuario) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars18( bcUsuario, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A18( ) ;
         AfterTrn( ) ;
         VarsToRow18( bcUsuario) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow18( bcUsuario) ;
         }
         else
         {
            SdtUsuario auxBC = new SdtUsuario(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A29UsuarioID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcUsuario);
               auxBC.Save();
               bcUsuario.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars18( bcUsuario, 1) ;
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
         RowToVars18( bcUsuario, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A18( ) ;
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
               VarsToRow18( bcUsuario) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow18( bcUsuario) ;
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
         RowToVars18( bcUsuario, 0) ;
         GetKey0A18( ) ;
         if ( RcdFound18 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A29UsuarioID != Z29UsuarioID )
            {
               A29UsuarioID = Z29UsuarioID;
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
            if ( A29UsuarioID != Z29UsuarioID )
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
         context.RollbackDataStores("usuario_bc",pr_default);
         VarsToRow18( bcUsuario) ;
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
         Gx_mode = bcUsuario.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcUsuario.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcUsuario )
         {
            bcUsuario = (SdtUsuario)(sdt);
            if ( StringUtil.StrCmp(bcUsuario.gxTpr_Mode, "") == 0 )
            {
               bcUsuario.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow18( bcUsuario) ;
            }
            else
            {
               RowToVars18( bcUsuario, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcUsuario.gxTpr_Mode, "") == 0 )
            {
               bcUsuario.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars18( bcUsuario, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtUsuario Usuario_BC
      {
         get {
            return bcUsuario ;
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
         pr_default.close(12);
         pr_default.close(13);
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
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
         Z53UsuarioGenero = "";
         A53UsuarioGenero = "";
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
         Z63UsuarioZona = "";
         A63UsuarioZona = "";
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
         Z87UsuarioFechaRegistro = DateTime.MinValue;
         A87UsuarioFechaRegistro = DateTime.MinValue;
         Z52UsuarioNombreCompleto = "";
         A52UsuarioNombreCompleto = "";
         Z14PuestoDescripcion = "";
         A14PuestoDescripcion = "";
         Z5CiudadDescripcion = "";
         A5CiudadDescripcion = "";
         Z2EstadoDescripcion = "";
         A2EstadoDescripcion = "";
         Z17PaisDescripcion = "";
         A17PaisDescripcion = "";
         BC000A8_A29UsuarioID = new int[1] ;
         BC000A8_A30UsuarioNombre = new string[] {""} ;
         BC000A8_A51UsuarioApellido = new string[] {""} ;
         BC000A8_A31UsuarioCorreo = new string[] {""} ;
         BC000A8_A32UsuarioPass = new string[] {""} ;
         BC000A8_A33UsuarioKey = new string[] {""} ;
         BC000A8_A14PuestoDescripcion = new string[] {""} ;
         BC000A8_A53UsuarioGenero = new string[] {""} ;
         BC000A8_A54UsuarioDirectoAsociado = new string[] {""} ;
         BC000A8_n54UsuarioDirectoAsociado = new bool[] {false} ;
         BC000A8_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         BC000A8_A56UsuarioNombreComercial = new string[] {""} ;
         BC000A8_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000A8_n57UsuarioFechaNacimiento = new bool[] {false} ;
         BC000A8_A59UsuarioCalleNum = new string[] {""} ;
         BC000A8_A60UsuarioColonia = new string[] {""} ;
         BC000A8_A61UsuarioDelegacion = new string[] {""} ;
         BC000A8_A62UsuarioCP = new int[1] ;
         BC000A8_A63UsuarioZona = new string[] {""} ;
         BC000A8_A64UsuarioCelular = new long[1] ;
         BC000A8_A65UsuarioTelefonoSucursal = new long[1] ;
         BC000A8_A17PaisDescripcion = new string[] {""} ;
         BC000A8_A2EstadoDescripcion = new string[] {""} ;
         BC000A8_A5CiudadDescripcion = new string[] {""} ;
         BC000A8_A66UsuarioSucursal = new string[] {""} ;
         BC000A8_A67UsuarioProducto = new string[] {""} ;
         BC000A8_n67UsuarioProducto = new bool[] {false} ;
         BC000A8_A40UsuarioRol = new string[] {""} ;
         BC000A8_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         BC000A8_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         BC000A8_A87UsuarioFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         BC000A8_n87UsuarioFechaRegistro = new bool[] {false} ;
         BC000A8_A92UsuarioAvisoPrivacidad = new bool[] {false} ;
         BC000A8_A13PuestoID = new int[1] ;
         BC000A8_n13PuestoID = new bool[] {false} ;
         BC000A8_A4CiudadID = new int[1] ;
         BC000A8_n4CiudadID = new bool[] {false} ;
         BC000A8_A1EstadoID = new int[1] ;
         BC000A8_A16PaisID = new int[1] ;
         BC000A4_A14PuestoDescripcion = new string[] {""} ;
         BC000A5_A5CiudadDescripcion = new string[] {""} ;
         BC000A5_A1EstadoID = new int[1] ;
         BC000A6_A2EstadoDescripcion = new string[] {""} ;
         BC000A6_A16PaisID = new int[1] ;
         BC000A7_A17PaisDescripcion = new string[] {""} ;
         BC000A9_A29UsuarioID = new int[1] ;
         BC000A3_A29UsuarioID = new int[1] ;
         BC000A3_A30UsuarioNombre = new string[] {""} ;
         BC000A3_A51UsuarioApellido = new string[] {""} ;
         BC000A3_A31UsuarioCorreo = new string[] {""} ;
         BC000A3_A32UsuarioPass = new string[] {""} ;
         BC000A3_A33UsuarioKey = new string[] {""} ;
         BC000A3_A53UsuarioGenero = new string[] {""} ;
         BC000A3_A54UsuarioDirectoAsociado = new string[] {""} ;
         BC000A3_n54UsuarioDirectoAsociado = new bool[] {false} ;
         BC000A3_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         BC000A3_A56UsuarioNombreComercial = new string[] {""} ;
         BC000A3_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000A3_n57UsuarioFechaNacimiento = new bool[] {false} ;
         BC000A3_A59UsuarioCalleNum = new string[] {""} ;
         BC000A3_A60UsuarioColonia = new string[] {""} ;
         BC000A3_A61UsuarioDelegacion = new string[] {""} ;
         BC000A3_A62UsuarioCP = new int[1] ;
         BC000A3_A63UsuarioZona = new string[] {""} ;
         BC000A3_A64UsuarioCelular = new long[1] ;
         BC000A3_A65UsuarioTelefonoSucursal = new long[1] ;
         BC000A3_A66UsuarioSucursal = new string[] {""} ;
         BC000A3_A67UsuarioProducto = new string[] {""} ;
         BC000A3_n67UsuarioProducto = new bool[] {false} ;
         BC000A3_A40UsuarioRol = new string[] {""} ;
         BC000A3_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         BC000A3_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         BC000A3_A87UsuarioFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         BC000A3_n87UsuarioFechaRegistro = new bool[] {false} ;
         BC000A3_A92UsuarioAvisoPrivacidad = new bool[] {false} ;
         BC000A3_A13PuestoID = new int[1] ;
         BC000A3_n13PuestoID = new bool[] {false} ;
         BC000A3_A4CiudadID = new int[1] ;
         BC000A3_n4CiudadID = new bool[] {false} ;
         sMode18 = "";
         BC000A2_A29UsuarioID = new int[1] ;
         BC000A2_A30UsuarioNombre = new string[] {""} ;
         BC000A2_A51UsuarioApellido = new string[] {""} ;
         BC000A2_A31UsuarioCorreo = new string[] {""} ;
         BC000A2_A32UsuarioPass = new string[] {""} ;
         BC000A2_A33UsuarioKey = new string[] {""} ;
         BC000A2_A53UsuarioGenero = new string[] {""} ;
         BC000A2_A54UsuarioDirectoAsociado = new string[] {""} ;
         BC000A2_n54UsuarioDirectoAsociado = new bool[] {false} ;
         BC000A2_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         BC000A2_A56UsuarioNombreComercial = new string[] {""} ;
         BC000A2_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000A2_n57UsuarioFechaNacimiento = new bool[] {false} ;
         BC000A2_A59UsuarioCalleNum = new string[] {""} ;
         BC000A2_A60UsuarioColonia = new string[] {""} ;
         BC000A2_A61UsuarioDelegacion = new string[] {""} ;
         BC000A2_A62UsuarioCP = new int[1] ;
         BC000A2_A63UsuarioZona = new string[] {""} ;
         BC000A2_A64UsuarioCelular = new long[1] ;
         BC000A2_A65UsuarioTelefonoSucursal = new long[1] ;
         BC000A2_A66UsuarioSucursal = new string[] {""} ;
         BC000A2_A67UsuarioProducto = new string[] {""} ;
         BC000A2_n67UsuarioProducto = new bool[] {false} ;
         BC000A2_A40UsuarioRol = new string[] {""} ;
         BC000A2_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         BC000A2_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         BC000A2_A87UsuarioFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         BC000A2_n87UsuarioFechaRegistro = new bool[] {false} ;
         BC000A2_A92UsuarioAvisoPrivacidad = new bool[] {false} ;
         BC000A2_A13PuestoID = new int[1] ;
         BC000A2_n13PuestoID = new bool[] {false} ;
         BC000A2_A4CiudadID = new int[1] ;
         BC000A2_n4CiudadID = new bool[] {false} ;
         BC000A11_A29UsuarioID = new int[1] ;
         BC000A14_A14PuestoDescripcion = new string[] {""} ;
         BC000A15_A5CiudadDescripcion = new string[] {""} ;
         BC000A15_A1EstadoID = new int[1] ;
         BC000A16_A2EstadoDescripcion = new string[] {""} ;
         BC000A16_A16PaisID = new int[1] ;
         BC000A17_A17PaisDescripcion = new string[] {""} ;
         BC000A18_A69FacturaID = new int[1] ;
         BC000A19_A81DistribuidoresUsuarioID = new int[1] ;
         BC000A20_A29UsuarioID = new int[1] ;
         BC000A20_A30UsuarioNombre = new string[] {""} ;
         BC000A20_A51UsuarioApellido = new string[] {""} ;
         BC000A20_A31UsuarioCorreo = new string[] {""} ;
         BC000A20_A32UsuarioPass = new string[] {""} ;
         BC000A20_A33UsuarioKey = new string[] {""} ;
         BC000A20_A14PuestoDescripcion = new string[] {""} ;
         BC000A20_A53UsuarioGenero = new string[] {""} ;
         BC000A20_A54UsuarioDirectoAsociado = new string[] {""} ;
         BC000A20_n54UsuarioDirectoAsociado = new bool[] {false} ;
         BC000A20_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         BC000A20_A56UsuarioNombreComercial = new string[] {""} ;
         BC000A20_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000A20_n57UsuarioFechaNacimiento = new bool[] {false} ;
         BC000A20_A59UsuarioCalleNum = new string[] {""} ;
         BC000A20_A60UsuarioColonia = new string[] {""} ;
         BC000A20_A61UsuarioDelegacion = new string[] {""} ;
         BC000A20_A62UsuarioCP = new int[1] ;
         BC000A20_A63UsuarioZona = new string[] {""} ;
         BC000A20_A64UsuarioCelular = new long[1] ;
         BC000A20_A65UsuarioTelefonoSucursal = new long[1] ;
         BC000A20_A17PaisDescripcion = new string[] {""} ;
         BC000A20_A2EstadoDescripcion = new string[] {""} ;
         BC000A20_A5CiudadDescripcion = new string[] {""} ;
         BC000A20_A66UsuarioSucursal = new string[] {""} ;
         BC000A20_A67UsuarioProducto = new string[] {""} ;
         BC000A20_n67UsuarioProducto = new bool[] {false} ;
         BC000A20_A40UsuarioRol = new string[] {""} ;
         BC000A20_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         BC000A20_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         BC000A20_A87UsuarioFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         BC000A20_n87UsuarioFechaRegistro = new bool[] {false} ;
         BC000A20_A92UsuarioAvisoPrivacidad = new bool[] {false} ;
         BC000A20_A13PuestoID = new int[1] ;
         BC000A20_n13PuestoID = new bool[] {false} ;
         BC000A20_A4CiudadID = new int[1] ;
         BC000A20_n4CiudadID = new bool[] {false} ;
         BC000A20_A1EstadoID = new int[1] ;
         BC000A20_A16PaisID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuario_bc__default(),
            new Object[][] {
                new Object[] {
               BC000A2_A29UsuarioID, BC000A2_A30UsuarioNombre, BC000A2_A51UsuarioApellido, BC000A2_A31UsuarioCorreo, BC000A2_A32UsuarioPass, BC000A2_A33UsuarioKey, BC000A2_A53UsuarioGenero, BC000A2_A54UsuarioDirectoAsociado, BC000A2_n54UsuarioDirectoAsociado, BC000A2_A55UsuarioRazonSocialAsociado,
               BC000A2_A56UsuarioNombreComercial, BC000A2_A57UsuarioFechaNacimiento, BC000A2_n57UsuarioFechaNacimiento, BC000A2_A59UsuarioCalleNum, BC000A2_A60UsuarioColonia, BC000A2_A61UsuarioDelegacion, BC000A2_A62UsuarioCP, BC000A2_A63UsuarioZona, BC000A2_A64UsuarioCelular, BC000A2_A65UsuarioTelefonoSucursal,
               BC000A2_A66UsuarioSucursal, BC000A2_A67UsuarioProducto, BC000A2_n67UsuarioProducto, BC000A2_A40UsuarioRol, BC000A2_A82UsuarioNoCuentaBROXEL, BC000A2_A83UsuarioReferenciaBROXEL, BC000A2_A87UsuarioFechaRegistro, BC000A2_n87UsuarioFechaRegistro, BC000A2_A92UsuarioAvisoPrivacidad, BC000A2_A13PuestoID,
               BC000A2_n13PuestoID, BC000A2_A4CiudadID, BC000A2_n4CiudadID
               }
               , new Object[] {
               BC000A3_A29UsuarioID, BC000A3_A30UsuarioNombre, BC000A3_A51UsuarioApellido, BC000A3_A31UsuarioCorreo, BC000A3_A32UsuarioPass, BC000A3_A33UsuarioKey, BC000A3_A53UsuarioGenero, BC000A3_A54UsuarioDirectoAsociado, BC000A3_n54UsuarioDirectoAsociado, BC000A3_A55UsuarioRazonSocialAsociado,
               BC000A3_A56UsuarioNombreComercial, BC000A3_A57UsuarioFechaNacimiento, BC000A3_n57UsuarioFechaNacimiento, BC000A3_A59UsuarioCalleNum, BC000A3_A60UsuarioColonia, BC000A3_A61UsuarioDelegacion, BC000A3_A62UsuarioCP, BC000A3_A63UsuarioZona, BC000A3_A64UsuarioCelular, BC000A3_A65UsuarioTelefonoSucursal,
               BC000A3_A66UsuarioSucursal, BC000A3_A67UsuarioProducto, BC000A3_n67UsuarioProducto, BC000A3_A40UsuarioRol, BC000A3_A82UsuarioNoCuentaBROXEL, BC000A3_A83UsuarioReferenciaBROXEL, BC000A3_A87UsuarioFechaRegistro, BC000A3_n87UsuarioFechaRegistro, BC000A3_A92UsuarioAvisoPrivacidad, BC000A3_A13PuestoID,
               BC000A3_n13PuestoID, BC000A3_A4CiudadID, BC000A3_n4CiudadID
               }
               , new Object[] {
               BC000A4_A14PuestoDescripcion
               }
               , new Object[] {
               BC000A5_A5CiudadDescripcion, BC000A5_A1EstadoID
               }
               , new Object[] {
               BC000A6_A2EstadoDescripcion, BC000A6_A16PaisID
               }
               , new Object[] {
               BC000A7_A17PaisDescripcion
               }
               , new Object[] {
               BC000A8_A29UsuarioID, BC000A8_A30UsuarioNombre, BC000A8_A51UsuarioApellido, BC000A8_A31UsuarioCorreo, BC000A8_A32UsuarioPass, BC000A8_A33UsuarioKey, BC000A8_A14PuestoDescripcion, BC000A8_A53UsuarioGenero, BC000A8_A54UsuarioDirectoAsociado, BC000A8_n54UsuarioDirectoAsociado,
               BC000A8_A55UsuarioRazonSocialAsociado, BC000A8_A56UsuarioNombreComercial, BC000A8_A57UsuarioFechaNacimiento, BC000A8_n57UsuarioFechaNacimiento, BC000A8_A59UsuarioCalleNum, BC000A8_A60UsuarioColonia, BC000A8_A61UsuarioDelegacion, BC000A8_A62UsuarioCP, BC000A8_A63UsuarioZona, BC000A8_A64UsuarioCelular,
               BC000A8_A65UsuarioTelefonoSucursal, BC000A8_A17PaisDescripcion, BC000A8_A2EstadoDescripcion, BC000A8_A5CiudadDescripcion, BC000A8_A66UsuarioSucursal, BC000A8_A67UsuarioProducto, BC000A8_n67UsuarioProducto, BC000A8_A40UsuarioRol, BC000A8_A82UsuarioNoCuentaBROXEL, BC000A8_A83UsuarioReferenciaBROXEL,
               BC000A8_A87UsuarioFechaRegistro, BC000A8_n87UsuarioFechaRegistro, BC000A8_A92UsuarioAvisoPrivacidad, BC000A8_A13PuestoID, BC000A8_n13PuestoID, BC000A8_A4CiudadID, BC000A8_n4CiudadID, BC000A8_A1EstadoID, BC000A8_A16PaisID
               }
               , new Object[] {
               BC000A9_A29UsuarioID
               }
               , new Object[] {
               }
               , new Object[] {
               BC000A11_A29UsuarioID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000A14_A14PuestoDescripcion
               }
               , new Object[] {
               BC000A15_A5CiudadDescripcion, BC000A15_A1EstadoID
               }
               , new Object[] {
               BC000A16_A2EstadoDescripcion, BC000A16_A16PaisID
               }
               , new Object[] {
               BC000A17_A17PaisDescripcion
               }
               , new Object[] {
               BC000A18_A69FacturaID
               }
               , new Object[] {
               BC000A19_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               BC000A20_A29UsuarioID, BC000A20_A30UsuarioNombre, BC000A20_A51UsuarioApellido, BC000A20_A31UsuarioCorreo, BC000A20_A32UsuarioPass, BC000A20_A33UsuarioKey, BC000A20_A14PuestoDescripcion, BC000A20_A53UsuarioGenero, BC000A20_A54UsuarioDirectoAsociado, BC000A20_n54UsuarioDirectoAsociado,
               BC000A20_A55UsuarioRazonSocialAsociado, BC000A20_A56UsuarioNombreComercial, BC000A20_A57UsuarioFechaNacimiento, BC000A20_n57UsuarioFechaNacimiento, BC000A20_A59UsuarioCalleNum, BC000A20_A60UsuarioColonia, BC000A20_A61UsuarioDelegacion, BC000A20_A62UsuarioCP, BC000A20_A63UsuarioZona, BC000A20_A64UsuarioCelular,
               BC000A20_A65UsuarioTelefonoSucursal, BC000A20_A17PaisDescripcion, BC000A20_A2EstadoDescripcion, BC000A20_A5CiudadDescripcion, BC000A20_A66UsuarioSucursal, BC000A20_A67UsuarioProducto, BC000A20_n67UsuarioProducto, BC000A20_A40UsuarioRol, BC000A20_A82UsuarioNoCuentaBROXEL, BC000A20_A83UsuarioReferenciaBROXEL,
               BC000A20_A87UsuarioFechaRegistro, BC000A20_n87UsuarioFechaRegistro, BC000A20_A92UsuarioAvisoPrivacidad, BC000A20_A13PuestoID, BC000A20_n13PuestoID, BC000A20_A4CiudadID, BC000A20_n4CiudadID, BC000A20_A1EstadoID, BC000A20_A16PaisID
               }
            }
         );
         Z92UsuarioAvisoPrivacidad = false;
         A92UsuarioAvisoPrivacidad = false;
         i92UsuarioAvisoPrivacidad = false;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound18 ;
      private int trnEnded ;
      private int Z29UsuarioID ;
      private int A29UsuarioID ;
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
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z30UsuarioNombre ;
      private string A30UsuarioNombre ;
      private string Z51UsuarioApellido ;
      private string A51UsuarioApellido ;
      private string Z53UsuarioGenero ;
      private string A53UsuarioGenero ;
      private string Z54UsuarioDirectoAsociado ;
      private string A54UsuarioDirectoAsociado ;
      private string Z59UsuarioCalleNum ;
      private string A59UsuarioCalleNum ;
      private string Z60UsuarioColonia ;
      private string A60UsuarioColonia ;
      private string Z61UsuarioDelegacion ;
      private string A61UsuarioDelegacion ;
      private string Z63UsuarioZona ;
      private string A63UsuarioZona ;
      private string Z66UsuarioSucursal ;
      private string A66UsuarioSucursal ;
      private string Z40UsuarioRol ;
      private string A40UsuarioRol ;
      private string Z82UsuarioNoCuentaBROXEL ;
      private string A82UsuarioNoCuentaBROXEL ;
      private string Z83UsuarioReferenciaBROXEL ;
      private string A83UsuarioReferenciaBROXEL ;
      private string sMode18 ;
      private DateTime Z57UsuarioFechaNacimiento ;
      private DateTime A57UsuarioFechaNacimiento ;
      private DateTime Z87UsuarioFechaRegistro ;
      private DateTime A87UsuarioFechaRegistro ;
      private bool Z92UsuarioAvisoPrivacidad ;
      private bool A92UsuarioAvisoPrivacidad ;
      private bool n54UsuarioDirectoAsociado ;
      private bool n57UsuarioFechaNacimiento ;
      private bool n67UsuarioProducto ;
      private bool n87UsuarioFechaRegistro ;
      private bool n13PuestoID ;
      private bool n4CiudadID ;
      private bool Gx_longc ;
      private bool i92UsuarioAvisoPrivacidad ;
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
      private string Z52UsuarioNombreCompleto ;
      private string A52UsuarioNombreCompleto ;
      private string Z14PuestoDescripcion ;
      private string A14PuestoDescripcion ;
      private string Z5CiudadDescripcion ;
      private string A5CiudadDescripcion ;
      private string Z2EstadoDescripcion ;
      private string A2EstadoDescripcion ;
      private string Z17PaisDescripcion ;
      private string A17PaisDescripcion ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000A8_A29UsuarioID ;
      private string[] BC000A8_A30UsuarioNombre ;
      private string[] BC000A8_A51UsuarioApellido ;
      private string[] BC000A8_A31UsuarioCorreo ;
      private string[] BC000A8_A32UsuarioPass ;
      private string[] BC000A8_A33UsuarioKey ;
      private string[] BC000A8_A14PuestoDescripcion ;
      private string[] BC000A8_A53UsuarioGenero ;
      private string[] BC000A8_A54UsuarioDirectoAsociado ;
      private bool[] BC000A8_n54UsuarioDirectoAsociado ;
      private string[] BC000A8_A55UsuarioRazonSocialAsociado ;
      private string[] BC000A8_A56UsuarioNombreComercial ;
      private DateTime[] BC000A8_A57UsuarioFechaNacimiento ;
      private bool[] BC000A8_n57UsuarioFechaNacimiento ;
      private string[] BC000A8_A59UsuarioCalleNum ;
      private string[] BC000A8_A60UsuarioColonia ;
      private string[] BC000A8_A61UsuarioDelegacion ;
      private int[] BC000A8_A62UsuarioCP ;
      private string[] BC000A8_A63UsuarioZona ;
      private long[] BC000A8_A64UsuarioCelular ;
      private long[] BC000A8_A65UsuarioTelefonoSucursal ;
      private string[] BC000A8_A17PaisDescripcion ;
      private string[] BC000A8_A2EstadoDescripcion ;
      private string[] BC000A8_A5CiudadDescripcion ;
      private string[] BC000A8_A66UsuarioSucursal ;
      private string[] BC000A8_A67UsuarioProducto ;
      private bool[] BC000A8_n67UsuarioProducto ;
      private string[] BC000A8_A40UsuarioRol ;
      private string[] BC000A8_A82UsuarioNoCuentaBROXEL ;
      private string[] BC000A8_A83UsuarioReferenciaBROXEL ;
      private DateTime[] BC000A8_A87UsuarioFechaRegistro ;
      private bool[] BC000A8_n87UsuarioFechaRegistro ;
      private bool[] BC000A8_A92UsuarioAvisoPrivacidad ;
      private int[] BC000A8_A13PuestoID ;
      private bool[] BC000A8_n13PuestoID ;
      private int[] BC000A8_A4CiudadID ;
      private bool[] BC000A8_n4CiudadID ;
      private int[] BC000A8_A1EstadoID ;
      private int[] BC000A8_A16PaisID ;
      private string[] BC000A4_A14PuestoDescripcion ;
      private string[] BC000A5_A5CiudadDescripcion ;
      private int[] BC000A5_A1EstadoID ;
      private string[] BC000A6_A2EstadoDescripcion ;
      private int[] BC000A6_A16PaisID ;
      private string[] BC000A7_A17PaisDescripcion ;
      private int[] BC000A9_A29UsuarioID ;
      private int[] BC000A3_A29UsuarioID ;
      private string[] BC000A3_A30UsuarioNombre ;
      private string[] BC000A3_A51UsuarioApellido ;
      private string[] BC000A3_A31UsuarioCorreo ;
      private string[] BC000A3_A32UsuarioPass ;
      private string[] BC000A3_A33UsuarioKey ;
      private string[] BC000A3_A53UsuarioGenero ;
      private string[] BC000A3_A54UsuarioDirectoAsociado ;
      private bool[] BC000A3_n54UsuarioDirectoAsociado ;
      private string[] BC000A3_A55UsuarioRazonSocialAsociado ;
      private string[] BC000A3_A56UsuarioNombreComercial ;
      private DateTime[] BC000A3_A57UsuarioFechaNacimiento ;
      private bool[] BC000A3_n57UsuarioFechaNacimiento ;
      private string[] BC000A3_A59UsuarioCalleNum ;
      private string[] BC000A3_A60UsuarioColonia ;
      private string[] BC000A3_A61UsuarioDelegacion ;
      private int[] BC000A3_A62UsuarioCP ;
      private string[] BC000A3_A63UsuarioZona ;
      private long[] BC000A3_A64UsuarioCelular ;
      private long[] BC000A3_A65UsuarioTelefonoSucursal ;
      private string[] BC000A3_A66UsuarioSucursal ;
      private string[] BC000A3_A67UsuarioProducto ;
      private bool[] BC000A3_n67UsuarioProducto ;
      private string[] BC000A3_A40UsuarioRol ;
      private string[] BC000A3_A82UsuarioNoCuentaBROXEL ;
      private string[] BC000A3_A83UsuarioReferenciaBROXEL ;
      private DateTime[] BC000A3_A87UsuarioFechaRegistro ;
      private bool[] BC000A3_n87UsuarioFechaRegistro ;
      private bool[] BC000A3_A92UsuarioAvisoPrivacidad ;
      private int[] BC000A3_A13PuestoID ;
      private bool[] BC000A3_n13PuestoID ;
      private int[] BC000A3_A4CiudadID ;
      private bool[] BC000A3_n4CiudadID ;
      private int[] BC000A2_A29UsuarioID ;
      private string[] BC000A2_A30UsuarioNombre ;
      private string[] BC000A2_A51UsuarioApellido ;
      private string[] BC000A2_A31UsuarioCorreo ;
      private string[] BC000A2_A32UsuarioPass ;
      private string[] BC000A2_A33UsuarioKey ;
      private string[] BC000A2_A53UsuarioGenero ;
      private string[] BC000A2_A54UsuarioDirectoAsociado ;
      private bool[] BC000A2_n54UsuarioDirectoAsociado ;
      private string[] BC000A2_A55UsuarioRazonSocialAsociado ;
      private string[] BC000A2_A56UsuarioNombreComercial ;
      private DateTime[] BC000A2_A57UsuarioFechaNacimiento ;
      private bool[] BC000A2_n57UsuarioFechaNacimiento ;
      private string[] BC000A2_A59UsuarioCalleNum ;
      private string[] BC000A2_A60UsuarioColonia ;
      private string[] BC000A2_A61UsuarioDelegacion ;
      private int[] BC000A2_A62UsuarioCP ;
      private string[] BC000A2_A63UsuarioZona ;
      private long[] BC000A2_A64UsuarioCelular ;
      private long[] BC000A2_A65UsuarioTelefonoSucursal ;
      private string[] BC000A2_A66UsuarioSucursal ;
      private string[] BC000A2_A67UsuarioProducto ;
      private bool[] BC000A2_n67UsuarioProducto ;
      private string[] BC000A2_A40UsuarioRol ;
      private string[] BC000A2_A82UsuarioNoCuentaBROXEL ;
      private string[] BC000A2_A83UsuarioReferenciaBROXEL ;
      private DateTime[] BC000A2_A87UsuarioFechaRegistro ;
      private bool[] BC000A2_n87UsuarioFechaRegistro ;
      private bool[] BC000A2_A92UsuarioAvisoPrivacidad ;
      private int[] BC000A2_A13PuestoID ;
      private bool[] BC000A2_n13PuestoID ;
      private int[] BC000A2_A4CiudadID ;
      private bool[] BC000A2_n4CiudadID ;
      private int[] BC000A11_A29UsuarioID ;
      private string[] BC000A14_A14PuestoDescripcion ;
      private string[] BC000A15_A5CiudadDescripcion ;
      private int[] BC000A15_A1EstadoID ;
      private string[] BC000A16_A2EstadoDescripcion ;
      private int[] BC000A16_A16PaisID ;
      private string[] BC000A17_A17PaisDescripcion ;
      private int[] BC000A18_A69FacturaID ;
      private int[] BC000A19_A81DistribuidoresUsuarioID ;
      private int[] BC000A20_A29UsuarioID ;
      private string[] BC000A20_A30UsuarioNombre ;
      private string[] BC000A20_A51UsuarioApellido ;
      private string[] BC000A20_A31UsuarioCorreo ;
      private string[] BC000A20_A32UsuarioPass ;
      private string[] BC000A20_A33UsuarioKey ;
      private string[] BC000A20_A14PuestoDescripcion ;
      private string[] BC000A20_A53UsuarioGenero ;
      private string[] BC000A20_A54UsuarioDirectoAsociado ;
      private bool[] BC000A20_n54UsuarioDirectoAsociado ;
      private string[] BC000A20_A55UsuarioRazonSocialAsociado ;
      private string[] BC000A20_A56UsuarioNombreComercial ;
      private DateTime[] BC000A20_A57UsuarioFechaNacimiento ;
      private bool[] BC000A20_n57UsuarioFechaNacimiento ;
      private string[] BC000A20_A59UsuarioCalleNum ;
      private string[] BC000A20_A60UsuarioColonia ;
      private string[] BC000A20_A61UsuarioDelegacion ;
      private int[] BC000A20_A62UsuarioCP ;
      private string[] BC000A20_A63UsuarioZona ;
      private long[] BC000A20_A64UsuarioCelular ;
      private long[] BC000A20_A65UsuarioTelefonoSucursal ;
      private string[] BC000A20_A17PaisDescripcion ;
      private string[] BC000A20_A2EstadoDescripcion ;
      private string[] BC000A20_A5CiudadDescripcion ;
      private string[] BC000A20_A66UsuarioSucursal ;
      private string[] BC000A20_A67UsuarioProducto ;
      private bool[] BC000A20_n67UsuarioProducto ;
      private string[] BC000A20_A40UsuarioRol ;
      private string[] BC000A20_A82UsuarioNoCuentaBROXEL ;
      private string[] BC000A20_A83UsuarioReferenciaBROXEL ;
      private DateTime[] BC000A20_A87UsuarioFechaRegistro ;
      private bool[] BC000A20_n87UsuarioFechaRegistro ;
      private bool[] BC000A20_A92UsuarioAvisoPrivacidad ;
      private int[] BC000A20_A13PuestoID ;
      private bool[] BC000A20_n13PuestoID ;
      private int[] BC000A20_A4CiudadID ;
      private bool[] BC000A20_n4CiudadID ;
      private int[] BC000A20_A1EstadoID ;
      private int[] BC000A20_A16PaisID ;
      private SdtUsuario bcUsuario ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class usuario_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000A2;
          prmBC000A2 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000A3;
          prmBC000A3 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000A4;
          prmBC000A4 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000A5;
          prmBC000A5 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000A6;
          prmBC000A6 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC000A7;
          prmBC000A7 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmBC000A8;
          prmBC000A8 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000A9;
          prmBC000A9 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000A10;
          prmBC000A10 = new Object[] {
          new ParDef("@UsuarioNombre",GXType.Char,50,0) ,
          new ParDef("@UsuarioApellido",GXType.Char,50,0) ,
          new ParDef("@UsuarioCorreo",GXType.Char,100,0) ,
          new ParDef("@UsuarioPass",GXType.Char,40,0) ,
          new ParDef("@UsuarioKey",GXType.Char,40,0) ,
          new ParDef("@UsuarioGenero",GXType.Char,20,0) ,
          new ParDef("@UsuarioDirectoAsociado",GXType.Char,20,0){Nullable=true} ,
          new ParDef("@UsuarioRazonSocialAsociado",GXType.Char,40,0) ,
          new ParDef("@UsuarioNombreComercial",GXType.Char,40,0) ,
          new ParDef("@UsuarioFechaNacimiento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@UsuarioCalleNum",GXType.Char,40,0) ,
          new ParDef("@UsuarioColonia",GXType.Char,20,0) ,
          new ParDef("@UsuarioDelegacion",GXType.Char,20,0) ,
          new ParDef("@UsuarioCP",GXType.Int32,5,0) ,
          new ParDef("@UsuarioZona",GXType.Char,30,0) ,
          new ParDef("@UsuarioCelular",GXType.Int64,10,0) ,
          new ParDef("@UsuarioTelefonoSucursal",GXType.Int64,10,0) ,
          new ParDef("@UsuarioSucursal",GXType.Char,20,0) ,
          new ParDef("@UsuarioProducto",GXType.Char,40,0){Nullable=true} ,
          new ParDef("@UsuarioRol",GXType.Char,40,0) ,
          new ParDef("@UsuarioNoCuentaBROXEL",GXType.Char,20,0) ,
          new ParDef("@UsuarioReferenciaBROXEL",GXType.Char,20,0) ,
          new ParDef("@UsuarioFechaRegistro",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@UsuarioAvisoPrivacidad",GXType.Byte,4,0) ,
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000A11;
          prmBC000A11 = new Object[] {
          };
          Object[] prmBC000A12;
          prmBC000A12 = new Object[] {
          new ParDef("@UsuarioNombre",GXType.Char,50,0) ,
          new ParDef("@UsuarioApellido",GXType.Char,50,0) ,
          new ParDef("@UsuarioCorreo",GXType.Char,100,0) ,
          new ParDef("@UsuarioPass",GXType.Char,40,0) ,
          new ParDef("@UsuarioKey",GXType.Char,40,0) ,
          new ParDef("@UsuarioGenero",GXType.Char,20,0) ,
          new ParDef("@UsuarioDirectoAsociado",GXType.Char,20,0){Nullable=true} ,
          new ParDef("@UsuarioRazonSocialAsociado",GXType.Char,40,0) ,
          new ParDef("@UsuarioNombreComercial",GXType.Char,40,0) ,
          new ParDef("@UsuarioFechaNacimiento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@UsuarioCalleNum",GXType.Char,40,0) ,
          new ParDef("@UsuarioColonia",GXType.Char,20,0) ,
          new ParDef("@UsuarioDelegacion",GXType.Char,20,0) ,
          new ParDef("@UsuarioCP",GXType.Int32,5,0) ,
          new ParDef("@UsuarioZona",GXType.Char,30,0) ,
          new ParDef("@UsuarioCelular",GXType.Int64,10,0) ,
          new ParDef("@UsuarioTelefonoSucursal",GXType.Int64,10,0) ,
          new ParDef("@UsuarioSucursal",GXType.Char,20,0) ,
          new ParDef("@UsuarioProducto",GXType.Char,40,0){Nullable=true} ,
          new ParDef("@UsuarioRol",GXType.Char,40,0) ,
          new ParDef("@UsuarioNoCuentaBROXEL",GXType.Char,20,0) ,
          new ParDef("@UsuarioReferenciaBROXEL",GXType.Char,20,0) ,
          new ParDef("@UsuarioFechaRegistro",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@UsuarioAvisoPrivacidad",GXType.Byte,4,0) ,
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000A13;
          prmBC000A13 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000A14;
          prmBC000A14 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000A15;
          prmBC000A15 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000A16;
          prmBC000A16 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC000A17;
          prmBC000A17 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmBC000A18;
          prmBC000A18 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000A19;
          prmBC000A19 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000A20;
          prmBC000A20 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000A2", "SELECT `UsuarioID`, `UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioGenero`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioZona`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `UsuarioNoCuentaBROXEL`, `UsuarioReferenciaBROXEL`, `UsuarioFechaRegistro`, `UsuarioAvisoPrivacidad`, `PuestoID`, `CiudadID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A3", "SELECT `UsuarioID`, `UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioGenero`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioZona`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `UsuarioNoCuentaBROXEL`, `UsuarioReferenciaBROXEL`, `UsuarioFechaRegistro`, `UsuarioAvisoPrivacidad`, `PuestoID`, `CiudadID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A4", "SELECT `PuestoDescripcion` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A5", "SELECT `CiudadDescripcion`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A6", "SELECT `EstadoDescripcion`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A7", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A8", "SELECT TM1.`UsuarioID`, TM1.`UsuarioNombre`, TM1.`UsuarioApellido`, TM1.`UsuarioCorreo`, TM1.`UsuarioPass`, TM1.`UsuarioKey`, T2.`PuestoDescripcion`, TM1.`UsuarioGenero`, TM1.`UsuarioDirectoAsociado`, TM1.`UsuarioRazonSocialAsociado`, TM1.`UsuarioNombreComercial`, TM1.`UsuarioFechaNacimiento`, TM1.`UsuarioCalleNum`, TM1.`UsuarioColonia`, TM1.`UsuarioDelegacion`, TM1.`UsuarioCP`, TM1.`UsuarioZona`, TM1.`UsuarioCelular`, TM1.`UsuarioTelefonoSucursal`, T5.`PaisDescripcion`, T4.`EstadoDescripcion`, T3.`CiudadDescripcion`, TM1.`UsuarioSucursal`, TM1.`UsuarioProducto`, TM1.`UsuarioRol`, TM1.`UsuarioNoCuentaBROXEL`, TM1.`UsuarioReferenciaBROXEL`, TM1.`UsuarioFechaRegistro`, TM1.`UsuarioAvisoPrivacidad`, TM1.`PuestoID`, TM1.`CiudadID`, T3.`EstadoID`, T4.`PaisID` FROM ((((`Usuario` TM1 LEFT JOIN `Puesto` T2 ON T2.`PuestoID` = TM1.`PuestoID`) LEFT JOIN `Ciudad` T3 ON T3.`CiudadID` = TM1.`CiudadID`) LEFT JOIN `Estado` T4 ON T4.`EstadoID` = T3.`EstadoID`) LEFT JOIN `Pais` T5 ON T5.`PaisID` = T4.`PaisID`) WHERE TM1.`UsuarioID` = @UsuarioID ORDER BY TM1.`UsuarioID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A9", "SELECT `UsuarioID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A10", "INSERT INTO `Usuario`(`UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioGenero`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioZona`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `UsuarioNoCuentaBROXEL`, `UsuarioReferenciaBROXEL`, `UsuarioFechaRegistro`, `UsuarioAvisoPrivacidad`, `PuestoID`, `CiudadID`) VALUES(@UsuarioNombre, @UsuarioApellido, @UsuarioCorreo, @UsuarioPass, @UsuarioKey, @UsuarioGenero, @UsuarioDirectoAsociado, @UsuarioRazonSocialAsociado, @UsuarioNombreComercial, @UsuarioFechaNacimiento, @UsuarioCalleNum, @UsuarioColonia, @UsuarioDelegacion, @UsuarioCP, @UsuarioZona, @UsuarioCelular, @UsuarioTelefonoSucursal, @UsuarioSucursal, @UsuarioProducto, @UsuarioRol, @UsuarioNoCuentaBROXEL, @UsuarioReferenciaBROXEL, @UsuarioFechaRegistro, @UsuarioAvisoPrivacidad, @PuestoID, @CiudadID)", GxErrorMask.GX_NOMASK,prmBC000A10)
             ,new CursorDef("BC000A11", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A12", "UPDATE `Usuario` SET `UsuarioNombre`=@UsuarioNombre, `UsuarioApellido`=@UsuarioApellido, `UsuarioCorreo`=@UsuarioCorreo, `UsuarioPass`=@UsuarioPass, `UsuarioKey`=@UsuarioKey, `UsuarioGenero`=@UsuarioGenero, `UsuarioDirectoAsociado`=@UsuarioDirectoAsociado, `UsuarioRazonSocialAsociado`=@UsuarioRazonSocialAsociado, `UsuarioNombreComercial`=@UsuarioNombreComercial, `UsuarioFechaNacimiento`=@UsuarioFechaNacimiento, `UsuarioCalleNum`=@UsuarioCalleNum, `UsuarioColonia`=@UsuarioColonia, `UsuarioDelegacion`=@UsuarioDelegacion, `UsuarioCP`=@UsuarioCP, `UsuarioZona`=@UsuarioZona, `UsuarioCelular`=@UsuarioCelular, `UsuarioTelefonoSucursal`=@UsuarioTelefonoSucursal, `UsuarioSucursal`=@UsuarioSucursal, `UsuarioProducto`=@UsuarioProducto, `UsuarioRol`=@UsuarioRol, `UsuarioNoCuentaBROXEL`=@UsuarioNoCuentaBROXEL, `UsuarioReferenciaBROXEL`=@UsuarioReferenciaBROXEL, `UsuarioFechaRegistro`=@UsuarioFechaRegistro, `UsuarioAvisoPrivacidad`=@UsuarioAvisoPrivacidad, `PuestoID`=@PuestoID, `CiudadID`=@CiudadID  WHERE `UsuarioID` = @UsuarioID", GxErrorMask.GX_NOMASK,prmBC000A12)
             ,new CursorDef("BC000A13", "DELETE FROM `Usuario`  WHERE `UsuarioID` = @UsuarioID", GxErrorMask.GX_NOMASK,prmBC000A13)
             ,new CursorDef("BC000A14", "SELECT `PuestoDescripcion` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A15", "SELECT `CiudadDescripcion`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A16", "SELECT `EstadoDescripcion`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A17", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A18", "SELECT `FacturaID` FROM `Factura` WHERE `UsuarioID` = @UsuarioID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A18,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000A19", "SELECT `DistribuidoresUsuarioID` FROM `DistribuidoresUsuario` WHERE `UsuarioID` = @UsuarioID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A19,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000A20", "SELECT TM1.`UsuarioID`, TM1.`UsuarioNombre`, TM1.`UsuarioApellido`, TM1.`UsuarioCorreo`, TM1.`UsuarioPass`, TM1.`UsuarioKey`, T2.`PuestoDescripcion`, TM1.`UsuarioGenero`, TM1.`UsuarioDirectoAsociado`, TM1.`UsuarioRazonSocialAsociado`, TM1.`UsuarioNombreComercial`, TM1.`UsuarioFechaNacimiento`, TM1.`UsuarioCalleNum`, TM1.`UsuarioColonia`, TM1.`UsuarioDelegacion`, TM1.`UsuarioCP`, TM1.`UsuarioZona`, TM1.`UsuarioCelular`, TM1.`UsuarioTelefonoSucursal`, T5.`PaisDescripcion`, T4.`EstadoDescripcion`, T3.`CiudadDescripcion`, TM1.`UsuarioSucursal`, TM1.`UsuarioProducto`, TM1.`UsuarioRol`, TM1.`UsuarioNoCuentaBROXEL`, TM1.`UsuarioReferenciaBROXEL`, TM1.`UsuarioFechaRegistro`, TM1.`UsuarioAvisoPrivacidad`, TM1.`PuestoID`, TM1.`CiudadID`, T3.`EstadoID`, T4.`PaisID` FROM ((((`Usuario` TM1 LEFT JOIN `Puesto` T2 ON T2.`PuestoID` = TM1.`PuestoID`) LEFT JOIN `Ciudad` T3 ON T3.`CiudadID` = TM1.`CiudadID`) LEFT JOIN `Estado` T4 ON T4.`EstadoID` = T3.`EstadoID`) LEFT JOIN `Pais` T5 ON T5.`PaisID` = T4.`PaisID`) WHERE TM1.`UsuarioID` = @UsuarioID ORDER BY TM1.`UsuarioID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A20,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
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
                ((string[]) buf[17])[0] = rslt.getString(16, 30);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                ((long[]) buf[19])[0] = rslt.getLong(18);
                ((string[]) buf[20])[0] = rslt.getString(19, 20);
                ((string[]) buf[21])[0] = rslt.getVarchar(20);
                ((bool[]) buf[22])[0] = rslt.wasNull(20);
                ((string[]) buf[23])[0] = rslt.getString(21, 40);
                ((string[]) buf[24])[0] = rslt.getString(22, 20);
                ((string[]) buf[25])[0] = rslt.getString(23, 20);
                ((DateTime[]) buf[26])[0] = rslt.getGXDate(24);
                ((bool[]) buf[27])[0] = rslt.wasNull(24);
                ((bool[]) buf[28])[0] = rslt.getBool(25);
                ((int[]) buf[29])[0] = rslt.getInt(26);
                ((bool[]) buf[30])[0] = rslt.wasNull(26);
                ((int[]) buf[31])[0] = rslt.getInt(27);
                ((bool[]) buf[32])[0] = rslt.wasNull(27);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
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
                ((string[]) buf[17])[0] = rslt.getString(16, 30);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                ((long[]) buf[19])[0] = rslt.getLong(18);
                ((string[]) buf[20])[0] = rslt.getString(19, 20);
                ((string[]) buf[21])[0] = rslt.getVarchar(20);
                ((bool[]) buf[22])[0] = rslt.wasNull(20);
                ((string[]) buf[23])[0] = rslt.getString(21, 40);
                ((string[]) buf[24])[0] = rslt.getString(22, 20);
                ((string[]) buf[25])[0] = rslt.getString(23, 20);
                ((DateTime[]) buf[26])[0] = rslt.getGXDate(24);
                ((bool[]) buf[27])[0] = rslt.wasNull(24);
                ((bool[]) buf[28])[0] = rslt.getBool(25);
                ((int[]) buf[29])[0] = rslt.getInt(26);
                ((bool[]) buf[30])[0] = rslt.wasNull(26);
                ((int[]) buf[31])[0] = rslt.getInt(27);
                ((bool[]) buf[32])[0] = rslt.wasNull(27);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(12);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 40);
                ((string[]) buf[15])[0] = rslt.getString(14, 20);
                ((string[]) buf[16])[0] = rslt.getString(15, 20);
                ((int[]) buf[17])[0] = rslt.getInt(16);
                ((string[]) buf[18])[0] = rslt.getString(17, 30);
                ((long[]) buf[19])[0] = rslt.getLong(18);
                ((long[]) buf[20])[0] = rslt.getLong(19);
                ((string[]) buf[21])[0] = rslt.getVarchar(20);
                ((string[]) buf[22])[0] = rslt.getVarchar(21);
                ((string[]) buf[23])[0] = rslt.getVarchar(22);
                ((string[]) buf[24])[0] = rslt.getString(23, 20);
                ((string[]) buf[25])[0] = rslt.getVarchar(24);
                ((bool[]) buf[26])[0] = rslt.wasNull(24);
                ((string[]) buf[27])[0] = rslt.getString(25, 40);
                ((string[]) buf[28])[0] = rslt.getString(26, 20);
                ((string[]) buf[29])[0] = rslt.getString(27, 20);
                ((DateTime[]) buf[30])[0] = rslt.getGXDate(28);
                ((bool[]) buf[31])[0] = rslt.wasNull(28);
                ((bool[]) buf[32])[0] = rslt.getBool(29);
                ((int[]) buf[33])[0] = rslt.getInt(30);
                ((bool[]) buf[34])[0] = rslt.wasNull(30);
                ((int[]) buf[35])[0] = rslt.getInt(31);
                ((bool[]) buf[36])[0] = rslt.wasNull(31);
                ((int[]) buf[37])[0] = rslt.getInt(32);
                ((int[]) buf[38])[0] = rslt.getInt(33);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(12);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 40);
                ((string[]) buf[15])[0] = rslt.getString(14, 20);
                ((string[]) buf[16])[0] = rslt.getString(15, 20);
                ((int[]) buf[17])[0] = rslt.getInt(16);
                ((string[]) buf[18])[0] = rslt.getString(17, 30);
                ((long[]) buf[19])[0] = rslt.getLong(18);
                ((long[]) buf[20])[0] = rslt.getLong(19);
                ((string[]) buf[21])[0] = rslt.getVarchar(20);
                ((string[]) buf[22])[0] = rslt.getVarchar(21);
                ((string[]) buf[23])[0] = rslt.getVarchar(22);
                ((string[]) buf[24])[0] = rslt.getString(23, 20);
                ((string[]) buf[25])[0] = rslt.getVarchar(24);
                ((bool[]) buf[26])[0] = rslt.wasNull(24);
                ((string[]) buf[27])[0] = rslt.getString(25, 40);
                ((string[]) buf[28])[0] = rslt.getString(26, 20);
                ((string[]) buf[29])[0] = rslt.getString(27, 20);
                ((DateTime[]) buf[30])[0] = rslt.getGXDate(28);
                ((bool[]) buf[31])[0] = rslt.wasNull(28);
                ((bool[]) buf[32])[0] = rslt.getBool(29);
                ((int[]) buf[33])[0] = rslt.getInt(30);
                ((bool[]) buf[34])[0] = rslt.wasNull(30);
                ((int[]) buf[35])[0] = rslt.getInt(31);
                ((bool[]) buf[36])[0] = rslt.wasNull(31);
                ((int[]) buf[37])[0] = rslt.getInt(32);
                ((int[]) buf[38])[0] = rslt.getInt(33);
                return;
       }
    }

 }

}
