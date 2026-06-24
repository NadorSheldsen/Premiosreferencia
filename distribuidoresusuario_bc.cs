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
   public class distribuidoresusuario_bc : GxSilentTrn, IGxSilentTrn
   {
      public distribuidoresusuario_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public distribuidoresusuario_bc( IGxContext context )
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
         ReadRow0H10( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0H10( ) ;
         standaloneModal( ) ;
         AddRow0H10( ) ;
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
               Z81DistribuidoresUsuarioID = A81DistribuidoresUsuarioID;
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

      protected void CONFIRM_0H0( )
      {
         BeforeValidate0H10( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0H10( ) ;
            }
            else
            {
               CheckExtendedTable0H10( ) ;
               if ( AnyError == 0 )
               {
                  ZM0H10( 3) ;
                  ZM0H10( 4) ;
                  ZM0H10( 5) ;
                  ZM0H10( 6) ;
                  ZM0H10( 7) ;
                  ZM0H10( 8) ;
               }
               CloseExtendedTableCursors0H10( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0H10( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z10DistribuidorID = A10DistribuidorID;
            Z29UsuarioID = A29UsuarioID;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z11DistribuidorDescripcion = A11DistribuidorDescripcion;
            Z12DistribuidorRFC = A12DistribuidorRFC;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
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
            Z13PuestoID = A13PuestoID;
            Z4CiudadID = A4CiudadID;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z14PuestoDescripcion = A14PuestoDescripcion;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z5CiudadDescripcion = A5CiudadDescripcion;
            Z1EstadoID = A1EstadoID;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z2EstadoDescripcion = A2EstadoDescripcion;
            Z16PaisID = A16PaisID;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z17PaisDescripcion = A17PaisDescripcion;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( GX_JID == -2 )
         {
            Z81DistribuidoresUsuarioID = A81DistribuidoresUsuarioID;
            Z10DistribuidorID = A10DistribuidorID;
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
            Z13PuestoID = A13PuestoID;
            Z4CiudadID = A4CiudadID;
            Z14PuestoDescripcion = A14PuestoDescripcion;
            Z5CiudadDescripcion = A5CiudadDescripcion;
            Z1EstadoID = A1EstadoID;
            Z2EstadoDescripcion = A2EstadoDescripcion;
            Z16PaisID = A16PaisID;
            Z17PaisDescripcion = A17PaisDescripcion;
            Z11DistribuidorDescripcion = A11DistribuidorDescripcion;
            Z12DistribuidorRFC = A12DistribuidorRFC;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0H10( )
      {
         /* Using cursor BC000H10 */
         pr_default.execute(8, new Object[] {A81DistribuidoresUsuarioID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound10 = 1;
            A30UsuarioNombre = BC000H10_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000H10_A51UsuarioApellido[0];
            A31UsuarioCorreo = BC000H10_A31UsuarioCorreo[0];
            A32UsuarioPass = BC000H10_A32UsuarioPass[0];
            A33UsuarioKey = BC000H10_A33UsuarioKey[0];
            A14PuestoDescripcion = BC000H10_A14PuestoDescripcion[0];
            A53UsuarioGenero = BC000H10_A53UsuarioGenero[0];
            A54UsuarioDirectoAsociado = BC000H10_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = BC000H10_n54UsuarioDirectoAsociado[0];
            A55UsuarioRazonSocialAsociado = BC000H10_A55UsuarioRazonSocialAsociado[0];
            A56UsuarioNombreComercial = BC000H10_A56UsuarioNombreComercial[0];
            A57UsuarioFechaNacimiento = BC000H10_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = BC000H10_n57UsuarioFechaNacimiento[0];
            A59UsuarioCalleNum = BC000H10_A59UsuarioCalleNum[0];
            A60UsuarioColonia = BC000H10_A60UsuarioColonia[0];
            A61UsuarioDelegacion = BC000H10_A61UsuarioDelegacion[0];
            A62UsuarioCP = BC000H10_A62UsuarioCP[0];
            A63UsuarioZona = BC000H10_A63UsuarioZona[0];
            A64UsuarioCelular = BC000H10_A64UsuarioCelular[0];
            A65UsuarioTelefonoSucursal = BC000H10_A65UsuarioTelefonoSucursal[0];
            A17PaisDescripcion = BC000H10_A17PaisDescripcion[0];
            A2EstadoDescripcion = BC000H10_A2EstadoDescripcion[0];
            A5CiudadDescripcion = BC000H10_A5CiudadDescripcion[0];
            A66UsuarioSucursal = BC000H10_A66UsuarioSucursal[0];
            A67UsuarioProducto = BC000H10_A67UsuarioProducto[0];
            n67UsuarioProducto = BC000H10_n67UsuarioProducto[0];
            A40UsuarioRol = BC000H10_A40UsuarioRol[0];
            A11DistribuidorDescripcion = BC000H10_A11DistribuidorDescripcion[0];
            A12DistribuidorRFC = BC000H10_A12DistribuidorRFC[0];
            A10DistribuidorID = BC000H10_A10DistribuidorID[0];
            A29UsuarioID = BC000H10_A29UsuarioID[0];
            A13PuestoID = BC000H10_A13PuestoID[0];
            n13PuestoID = BC000H10_n13PuestoID[0];
            A4CiudadID = BC000H10_A4CiudadID[0];
            n4CiudadID = BC000H10_n4CiudadID[0];
            A1EstadoID = BC000H10_A1EstadoID[0];
            A16PaisID = BC000H10_A16PaisID[0];
            ZM0H10( -2) ;
         }
         pr_default.close(8);
         OnLoadActions0H10( ) ;
      }

      protected void OnLoadActions0H10( )
      {
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
      }

      protected void CheckExtendedTable0H10( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000H5 */
         pr_default.execute(3, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
         }
         A30UsuarioNombre = BC000H5_A30UsuarioNombre[0];
         A51UsuarioApellido = BC000H5_A51UsuarioApellido[0];
         A31UsuarioCorreo = BC000H5_A31UsuarioCorreo[0];
         A32UsuarioPass = BC000H5_A32UsuarioPass[0];
         A33UsuarioKey = BC000H5_A33UsuarioKey[0];
         A53UsuarioGenero = BC000H5_A53UsuarioGenero[0];
         A54UsuarioDirectoAsociado = BC000H5_A54UsuarioDirectoAsociado[0];
         n54UsuarioDirectoAsociado = BC000H5_n54UsuarioDirectoAsociado[0];
         A55UsuarioRazonSocialAsociado = BC000H5_A55UsuarioRazonSocialAsociado[0];
         A56UsuarioNombreComercial = BC000H5_A56UsuarioNombreComercial[0];
         A57UsuarioFechaNacimiento = BC000H5_A57UsuarioFechaNacimiento[0];
         n57UsuarioFechaNacimiento = BC000H5_n57UsuarioFechaNacimiento[0];
         A59UsuarioCalleNum = BC000H5_A59UsuarioCalleNum[0];
         A60UsuarioColonia = BC000H5_A60UsuarioColonia[0];
         A61UsuarioDelegacion = BC000H5_A61UsuarioDelegacion[0];
         A62UsuarioCP = BC000H5_A62UsuarioCP[0];
         A63UsuarioZona = BC000H5_A63UsuarioZona[0];
         A64UsuarioCelular = BC000H5_A64UsuarioCelular[0];
         A65UsuarioTelefonoSucursal = BC000H5_A65UsuarioTelefonoSucursal[0];
         A66UsuarioSucursal = BC000H5_A66UsuarioSucursal[0];
         A67UsuarioProducto = BC000H5_A67UsuarioProducto[0];
         n67UsuarioProducto = BC000H5_n67UsuarioProducto[0];
         A40UsuarioRol = BC000H5_A40UsuarioRol[0];
         A13PuestoID = BC000H5_A13PuestoID[0];
         n13PuestoID = BC000H5_n13PuestoID[0];
         A4CiudadID = BC000H5_A4CiudadID[0];
         n4CiudadID = BC000H5_n4CiudadID[0];
         pr_default.close(3);
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
         /* Using cursor BC000H6 */
         pr_default.execute(4, new Object[] {n13PuestoID, A13PuestoID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A13PuestoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Puesto", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PUESTOID");
               AnyError = 1;
            }
         }
         A14PuestoDescripcion = BC000H6_A14PuestoDescripcion[0];
         pr_default.close(4);
         /* Using cursor BC000H7 */
         pr_default.execute(5, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
            }
         }
         A5CiudadDescripcion = BC000H7_A5CiudadDescripcion[0];
         A1EstadoID = BC000H7_A1EstadoID[0];
         pr_default.close(5);
         /* Using cursor BC000H8 */
         pr_default.execute(6, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A2EstadoDescripcion = BC000H8_A2EstadoDescripcion[0];
         A16PaisID = BC000H8_A16PaisID[0];
         pr_default.close(6);
         /* Using cursor BC000H9 */
         pr_default.execute(7, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = BC000H9_A17PaisDescripcion[0];
         pr_default.close(7);
         /* Using cursor BC000H4 */
         pr_default.execute(2, new Object[] {A10DistribuidorID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Distribuidor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DISTRIBUIDORID");
            AnyError = 1;
         }
         A11DistribuidorDescripcion = BC000H4_A11DistribuidorDescripcion[0];
         A12DistribuidorRFC = BC000H4_A12DistribuidorRFC[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0H10( )
      {
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0H10( )
      {
         /* Using cursor BC000H11 */
         pr_default.execute(9, new Object[] {A81DistribuidoresUsuarioID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000H3 */
         pr_default.execute(1, new Object[] {A81DistribuidoresUsuarioID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H10( 2) ;
            RcdFound10 = 1;
            A81DistribuidoresUsuarioID = BC000H3_A81DistribuidoresUsuarioID[0];
            A10DistribuidorID = BC000H3_A10DistribuidorID[0];
            A29UsuarioID = BC000H3_A29UsuarioID[0];
            Z81DistribuidoresUsuarioID = A81DistribuidoresUsuarioID;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0H10( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0H10( ) ;
            }
            Gx_mode = sMode10;
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0H10( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode10;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H10( ) ;
         if ( RcdFound10 == 0 )
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
         CONFIRM_0H0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0H10( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000H2 */
            pr_default.execute(0, new Object[] {A81DistribuidoresUsuarioID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DistribuidoresUsuario"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z10DistribuidorID != BC000H2_A10DistribuidorID[0] ) || ( Z29UsuarioID != BC000H2_A29UsuarioID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DistribuidoresUsuario"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H10( )
      {
         BeforeValidate0H10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H10( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H10( 0) ;
            CheckOptimisticConcurrency0H10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H12 */
                     pr_default.execute(10, new Object[] {A10DistribuidorID, A29UsuarioID});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000H13 */
                     pr_default.execute(11);
                     A81DistribuidoresUsuarioID = BC000H13_A81DistribuidoresUsuarioID[0];
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("DistribuidoresUsuario");
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
               Load0H10( ) ;
            }
            EndLevel0H10( ) ;
         }
         CloseExtendedTableCursors0H10( ) ;
      }

      protected void Update0H10( )
      {
         BeforeValidate0H10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H10( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H14 */
                     pr_default.execute(12, new Object[] {A10DistribuidorID, A29UsuarioID, A81DistribuidoresUsuarioID});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("DistribuidoresUsuario");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DistribuidoresUsuario"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H10( ) ;
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
            EndLevel0H10( ) ;
         }
         CloseExtendedTableCursors0H10( ) ;
      }

      protected void DeferredUpdate0H10( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0H10( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H10( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H10( ) ;
            AfterConfirm0H10( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H10( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000H15 */
                  pr_default.execute(13, new Object[] {A81DistribuidoresUsuarioID});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("DistribuidoresUsuario");
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0H10( ) ;
         Gx_mode = sMode10;
      }

      protected void OnDeleteControls0H10( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000H16 */
            pr_default.execute(14, new Object[] {A29UsuarioID});
            A30UsuarioNombre = BC000H16_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000H16_A51UsuarioApellido[0];
            A31UsuarioCorreo = BC000H16_A31UsuarioCorreo[0];
            A32UsuarioPass = BC000H16_A32UsuarioPass[0];
            A33UsuarioKey = BC000H16_A33UsuarioKey[0];
            A53UsuarioGenero = BC000H16_A53UsuarioGenero[0];
            A54UsuarioDirectoAsociado = BC000H16_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = BC000H16_n54UsuarioDirectoAsociado[0];
            A55UsuarioRazonSocialAsociado = BC000H16_A55UsuarioRazonSocialAsociado[0];
            A56UsuarioNombreComercial = BC000H16_A56UsuarioNombreComercial[0];
            A57UsuarioFechaNacimiento = BC000H16_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = BC000H16_n57UsuarioFechaNacimiento[0];
            A59UsuarioCalleNum = BC000H16_A59UsuarioCalleNum[0];
            A60UsuarioColonia = BC000H16_A60UsuarioColonia[0];
            A61UsuarioDelegacion = BC000H16_A61UsuarioDelegacion[0];
            A62UsuarioCP = BC000H16_A62UsuarioCP[0];
            A63UsuarioZona = BC000H16_A63UsuarioZona[0];
            A64UsuarioCelular = BC000H16_A64UsuarioCelular[0];
            A65UsuarioTelefonoSucursal = BC000H16_A65UsuarioTelefonoSucursal[0];
            A66UsuarioSucursal = BC000H16_A66UsuarioSucursal[0];
            A67UsuarioProducto = BC000H16_A67UsuarioProducto[0];
            n67UsuarioProducto = BC000H16_n67UsuarioProducto[0];
            A40UsuarioRol = BC000H16_A40UsuarioRol[0];
            A13PuestoID = BC000H16_A13PuestoID[0];
            n13PuestoID = BC000H16_n13PuestoID[0];
            A4CiudadID = BC000H16_A4CiudadID[0];
            n4CiudadID = BC000H16_n4CiudadID[0];
            pr_default.close(14);
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            /* Using cursor BC000H17 */
            pr_default.execute(15, new Object[] {n13PuestoID, A13PuestoID});
            A14PuestoDescripcion = BC000H17_A14PuestoDescripcion[0];
            pr_default.close(15);
            /* Using cursor BC000H18 */
            pr_default.execute(16, new Object[] {n4CiudadID, A4CiudadID});
            A5CiudadDescripcion = BC000H18_A5CiudadDescripcion[0];
            A1EstadoID = BC000H18_A1EstadoID[0];
            pr_default.close(16);
            /* Using cursor BC000H19 */
            pr_default.execute(17, new Object[] {A1EstadoID});
            A2EstadoDescripcion = BC000H19_A2EstadoDescripcion[0];
            A16PaisID = BC000H19_A16PaisID[0];
            pr_default.close(17);
            /* Using cursor BC000H20 */
            pr_default.execute(18, new Object[] {A16PaisID});
            A17PaisDescripcion = BC000H20_A17PaisDescripcion[0];
            pr_default.close(18);
            /* Using cursor BC000H21 */
            pr_default.execute(19, new Object[] {A10DistribuidorID});
            A11DistribuidorDescripcion = BC000H21_A11DistribuidorDescripcion[0];
            A12DistribuidorRFC = BC000H21_A12DistribuidorRFC[0];
            pr_default.close(19);
         }
      }

      protected void EndLevel0H10( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H10( ) ;
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

      public void ScanKeyStart0H10( )
      {
         /* Using cursor BC000H22 */
         pr_default.execute(20, new Object[] {A81DistribuidoresUsuarioID});
         RcdFound10 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound10 = 1;
            A81DistribuidoresUsuarioID = BC000H22_A81DistribuidoresUsuarioID[0];
            A30UsuarioNombre = BC000H22_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000H22_A51UsuarioApellido[0];
            A31UsuarioCorreo = BC000H22_A31UsuarioCorreo[0];
            A32UsuarioPass = BC000H22_A32UsuarioPass[0];
            A33UsuarioKey = BC000H22_A33UsuarioKey[0];
            A14PuestoDescripcion = BC000H22_A14PuestoDescripcion[0];
            A53UsuarioGenero = BC000H22_A53UsuarioGenero[0];
            A54UsuarioDirectoAsociado = BC000H22_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = BC000H22_n54UsuarioDirectoAsociado[0];
            A55UsuarioRazonSocialAsociado = BC000H22_A55UsuarioRazonSocialAsociado[0];
            A56UsuarioNombreComercial = BC000H22_A56UsuarioNombreComercial[0];
            A57UsuarioFechaNacimiento = BC000H22_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = BC000H22_n57UsuarioFechaNacimiento[0];
            A59UsuarioCalleNum = BC000H22_A59UsuarioCalleNum[0];
            A60UsuarioColonia = BC000H22_A60UsuarioColonia[0];
            A61UsuarioDelegacion = BC000H22_A61UsuarioDelegacion[0];
            A62UsuarioCP = BC000H22_A62UsuarioCP[0];
            A63UsuarioZona = BC000H22_A63UsuarioZona[0];
            A64UsuarioCelular = BC000H22_A64UsuarioCelular[0];
            A65UsuarioTelefonoSucursal = BC000H22_A65UsuarioTelefonoSucursal[0];
            A17PaisDescripcion = BC000H22_A17PaisDescripcion[0];
            A2EstadoDescripcion = BC000H22_A2EstadoDescripcion[0];
            A5CiudadDescripcion = BC000H22_A5CiudadDescripcion[0];
            A66UsuarioSucursal = BC000H22_A66UsuarioSucursal[0];
            A67UsuarioProducto = BC000H22_A67UsuarioProducto[0];
            n67UsuarioProducto = BC000H22_n67UsuarioProducto[0];
            A40UsuarioRol = BC000H22_A40UsuarioRol[0];
            A11DistribuidorDescripcion = BC000H22_A11DistribuidorDescripcion[0];
            A12DistribuidorRFC = BC000H22_A12DistribuidorRFC[0];
            A10DistribuidorID = BC000H22_A10DistribuidorID[0];
            A29UsuarioID = BC000H22_A29UsuarioID[0];
            A13PuestoID = BC000H22_A13PuestoID[0];
            n13PuestoID = BC000H22_n13PuestoID[0];
            A4CiudadID = BC000H22_A4CiudadID[0];
            n4CiudadID = BC000H22_n4CiudadID[0];
            A1EstadoID = BC000H22_A1EstadoID[0];
            A16PaisID = BC000H22_A16PaisID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0H10( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound10 = 0;
         ScanKeyLoad0H10( ) ;
      }

      protected void ScanKeyLoad0H10( )
      {
         sMode10 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound10 = 1;
            A81DistribuidoresUsuarioID = BC000H22_A81DistribuidoresUsuarioID[0];
            A30UsuarioNombre = BC000H22_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000H22_A51UsuarioApellido[0];
            A31UsuarioCorreo = BC000H22_A31UsuarioCorreo[0];
            A32UsuarioPass = BC000H22_A32UsuarioPass[0];
            A33UsuarioKey = BC000H22_A33UsuarioKey[0];
            A14PuestoDescripcion = BC000H22_A14PuestoDescripcion[0];
            A53UsuarioGenero = BC000H22_A53UsuarioGenero[0];
            A54UsuarioDirectoAsociado = BC000H22_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = BC000H22_n54UsuarioDirectoAsociado[0];
            A55UsuarioRazonSocialAsociado = BC000H22_A55UsuarioRazonSocialAsociado[0];
            A56UsuarioNombreComercial = BC000H22_A56UsuarioNombreComercial[0];
            A57UsuarioFechaNacimiento = BC000H22_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = BC000H22_n57UsuarioFechaNacimiento[0];
            A59UsuarioCalleNum = BC000H22_A59UsuarioCalleNum[0];
            A60UsuarioColonia = BC000H22_A60UsuarioColonia[0];
            A61UsuarioDelegacion = BC000H22_A61UsuarioDelegacion[0];
            A62UsuarioCP = BC000H22_A62UsuarioCP[0];
            A63UsuarioZona = BC000H22_A63UsuarioZona[0];
            A64UsuarioCelular = BC000H22_A64UsuarioCelular[0];
            A65UsuarioTelefonoSucursal = BC000H22_A65UsuarioTelefonoSucursal[0];
            A17PaisDescripcion = BC000H22_A17PaisDescripcion[0];
            A2EstadoDescripcion = BC000H22_A2EstadoDescripcion[0];
            A5CiudadDescripcion = BC000H22_A5CiudadDescripcion[0];
            A66UsuarioSucursal = BC000H22_A66UsuarioSucursal[0];
            A67UsuarioProducto = BC000H22_A67UsuarioProducto[0];
            n67UsuarioProducto = BC000H22_n67UsuarioProducto[0];
            A40UsuarioRol = BC000H22_A40UsuarioRol[0];
            A11DistribuidorDescripcion = BC000H22_A11DistribuidorDescripcion[0];
            A12DistribuidorRFC = BC000H22_A12DistribuidorRFC[0];
            A10DistribuidorID = BC000H22_A10DistribuidorID[0];
            A29UsuarioID = BC000H22_A29UsuarioID[0];
            A13PuestoID = BC000H22_A13PuestoID[0];
            n13PuestoID = BC000H22_n13PuestoID[0];
            A4CiudadID = BC000H22_A4CiudadID[0];
            n4CiudadID = BC000H22_n4CiudadID[0];
            A1EstadoID = BC000H22_A1EstadoID[0];
            A16PaisID = BC000H22_A16PaisID[0];
         }
         Gx_mode = sMode10;
      }

      protected void ScanKeyEnd0H10( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0H10( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H10( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H10( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H10( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H10( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H10( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H10( )
      {
      }

      protected void send_integrity_lvl_hashes0H10( )
      {
      }

      protected void AddRow0H10( )
      {
         VarsToRow10( bcDistribuidoresUsuario) ;
      }

      protected void ReadRow0H10( )
      {
         RowToVars10( bcDistribuidoresUsuario, 1) ;
      }

      protected void InitializeNonKey0H10( )
      {
         A52UsuarioNombreCompleto = "";
         A29UsuarioID = 0;
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
         A10DistribuidorID = 0;
         A11DistribuidorDescripcion = "";
         A12DistribuidorRFC = "";
         Z10DistribuidorID = 0;
         Z29UsuarioID = 0;
      }

      protected void InitAll0H10( )
      {
         A81DistribuidoresUsuarioID = 0;
         InitializeNonKey0H10( ) ;
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

      public void VarsToRow10( SdtDistribuidoresUsuario obj10 )
      {
         obj10.gxTpr_Mode = Gx_mode;
         obj10.gxTpr_Usuarionombrecompleto = A52UsuarioNombreCompleto;
         obj10.gxTpr_Usuarioid = A29UsuarioID;
         obj10.gxTpr_Usuarionombre = A30UsuarioNombre;
         obj10.gxTpr_Usuarioapellido = A51UsuarioApellido;
         obj10.gxTpr_Usuariocorreo = A31UsuarioCorreo;
         obj10.gxTpr_Usuariopass = A32UsuarioPass;
         obj10.gxTpr_Usuariokey = A33UsuarioKey;
         obj10.gxTpr_Puestoid = A13PuestoID;
         obj10.gxTpr_Puestodescripcion = A14PuestoDescripcion;
         obj10.gxTpr_Usuariogenero = A53UsuarioGenero;
         obj10.gxTpr_Usuariodirectoasociado = A54UsuarioDirectoAsociado;
         obj10.gxTpr_Usuariorazonsocialasociado = A55UsuarioRazonSocialAsociado;
         obj10.gxTpr_Usuarionombrecomercial = A56UsuarioNombreComercial;
         obj10.gxTpr_Usuariofechanacimiento = A57UsuarioFechaNacimiento;
         obj10.gxTpr_Usuariocallenum = A59UsuarioCalleNum;
         obj10.gxTpr_Usuariocolonia = A60UsuarioColonia;
         obj10.gxTpr_Usuariodelegacion = A61UsuarioDelegacion;
         obj10.gxTpr_Usuariocp = A62UsuarioCP;
         obj10.gxTpr_Usuariozona = A63UsuarioZona;
         obj10.gxTpr_Usuariocelular = A64UsuarioCelular;
         obj10.gxTpr_Usuariotelefonosucursal = A65UsuarioTelefonoSucursal;
         obj10.gxTpr_Paisid = A16PaisID;
         obj10.gxTpr_Paisdescripcion = A17PaisDescripcion;
         obj10.gxTpr_Estadoid = A1EstadoID;
         obj10.gxTpr_Estadodescripcion = A2EstadoDescripcion;
         obj10.gxTpr_Ciudadid = A4CiudadID;
         obj10.gxTpr_Ciudaddescripcion = A5CiudadDescripcion;
         obj10.gxTpr_Usuariosucursal = A66UsuarioSucursal;
         obj10.gxTpr_Usuarioproducto = A67UsuarioProducto;
         obj10.gxTpr_Usuariorol = A40UsuarioRol;
         obj10.gxTpr_Distribuidorid = A10DistribuidorID;
         obj10.gxTpr_Distribuidordescripcion = A11DistribuidorDescripcion;
         obj10.gxTpr_Distribuidorrfc = A12DistribuidorRFC;
         obj10.gxTpr_Distribuidoresusuarioid = A81DistribuidoresUsuarioID;
         obj10.gxTpr_Distribuidoresusuarioid_Z = Z81DistribuidoresUsuarioID;
         obj10.gxTpr_Usuarioid_Z = Z29UsuarioID;
         obj10.gxTpr_Usuarionombre_Z = Z30UsuarioNombre;
         obj10.gxTpr_Usuarioapellido_Z = Z51UsuarioApellido;
         obj10.gxTpr_Usuarionombrecompleto_Z = Z52UsuarioNombreCompleto;
         obj10.gxTpr_Usuariocorreo_Z = Z31UsuarioCorreo;
         obj10.gxTpr_Usuariopass_Z = Z32UsuarioPass;
         obj10.gxTpr_Usuariokey_Z = Z33UsuarioKey;
         obj10.gxTpr_Puestoid_Z = Z13PuestoID;
         obj10.gxTpr_Puestodescripcion_Z = Z14PuestoDescripcion;
         obj10.gxTpr_Usuariogenero_Z = Z53UsuarioGenero;
         obj10.gxTpr_Usuariodirectoasociado_Z = Z54UsuarioDirectoAsociado;
         obj10.gxTpr_Usuariorazonsocialasociado_Z = Z55UsuarioRazonSocialAsociado;
         obj10.gxTpr_Usuarionombrecomercial_Z = Z56UsuarioNombreComercial;
         obj10.gxTpr_Usuariofechanacimiento_Z = Z57UsuarioFechaNacimiento;
         obj10.gxTpr_Usuariocallenum_Z = Z59UsuarioCalleNum;
         obj10.gxTpr_Usuariocolonia_Z = Z60UsuarioColonia;
         obj10.gxTpr_Usuariodelegacion_Z = Z61UsuarioDelegacion;
         obj10.gxTpr_Usuariocp_Z = Z62UsuarioCP;
         obj10.gxTpr_Usuariozona_Z = Z63UsuarioZona;
         obj10.gxTpr_Usuariocelular_Z = Z64UsuarioCelular;
         obj10.gxTpr_Usuariotelefonosucursal_Z = Z65UsuarioTelefonoSucursal;
         obj10.gxTpr_Paisid_Z = Z16PaisID;
         obj10.gxTpr_Paisdescripcion_Z = Z17PaisDescripcion;
         obj10.gxTpr_Estadoid_Z = Z1EstadoID;
         obj10.gxTpr_Estadodescripcion_Z = Z2EstadoDescripcion;
         obj10.gxTpr_Ciudadid_Z = Z4CiudadID;
         obj10.gxTpr_Ciudaddescripcion_Z = Z5CiudadDescripcion;
         obj10.gxTpr_Usuariosucursal_Z = Z66UsuarioSucursal;
         obj10.gxTpr_Usuarioproducto_Z = Z67UsuarioProducto;
         obj10.gxTpr_Usuariorol_Z = Z40UsuarioRol;
         obj10.gxTpr_Distribuidorid_Z = Z10DistribuidorID;
         obj10.gxTpr_Distribuidordescripcion_Z = Z11DistribuidorDescripcion;
         obj10.gxTpr_Distribuidorrfc_Z = Z12DistribuidorRFC;
         obj10.gxTpr_Puestoid_N = (short)(Convert.ToInt16(n13PuestoID));
         obj10.gxTpr_Usuariodirectoasociado_N = (short)(Convert.ToInt16(n54UsuarioDirectoAsociado));
         obj10.gxTpr_Usuariofechanacimiento_N = (short)(Convert.ToInt16(n57UsuarioFechaNacimiento));
         obj10.gxTpr_Ciudadid_N = (short)(Convert.ToInt16(n4CiudadID));
         obj10.gxTpr_Usuarioproducto_N = (short)(Convert.ToInt16(n67UsuarioProducto));
         obj10.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow10( SdtDistribuidoresUsuario obj10 )
      {
         obj10.gxTpr_Distribuidoresusuarioid = A81DistribuidoresUsuarioID;
         return  ;
      }

      public void RowToVars10( SdtDistribuidoresUsuario obj10 ,
                               int forceLoad )
      {
         Gx_mode = obj10.gxTpr_Mode;
         A52UsuarioNombreCompleto = obj10.gxTpr_Usuarionombrecompleto;
         A29UsuarioID = obj10.gxTpr_Usuarioid;
         A30UsuarioNombre = obj10.gxTpr_Usuarionombre;
         A51UsuarioApellido = obj10.gxTpr_Usuarioapellido;
         A31UsuarioCorreo = obj10.gxTpr_Usuariocorreo;
         A32UsuarioPass = obj10.gxTpr_Usuariopass;
         A33UsuarioKey = obj10.gxTpr_Usuariokey;
         A13PuestoID = obj10.gxTpr_Puestoid;
         n13PuestoID = false;
         A14PuestoDescripcion = obj10.gxTpr_Puestodescripcion;
         A53UsuarioGenero = obj10.gxTpr_Usuariogenero;
         A54UsuarioDirectoAsociado = obj10.gxTpr_Usuariodirectoasociado;
         n54UsuarioDirectoAsociado = false;
         A55UsuarioRazonSocialAsociado = obj10.gxTpr_Usuariorazonsocialasociado;
         A56UsuarioNombreComercial = obj10.gxTpr_Usuarionombrecomercial;
         A57UsuarioFechaNacimiento = obj10.gxTpr_Usuariofechanacimiento;
         n57UsuarioFechaNacimiento = false;
         A59UsuarioCalleNum = obj10.gxTpr_Usuariocallenum;
         A60UsuarioColonia = obj10.gxTpr_Usuariocolonia;
         A61UsuarioDelegacion = obj10.gxTpr_Usuariodelegacion;
         A62UsuarioCP = obj10.gxTpr_Usuariocp;
         A63UsuarioZona = obj10.gxTpr_Usuariozona;
         A64UsuarioCelular = obj10.gxTpr_Usuariocelular;
         A65UsuarioTelefonoSucursal = obj10.gxTpr_Usuariotelefonosucursal;
         A16PaisID = obj10.gxTpr_Paisid;
         A17PaisDescripcion = obj10.gxTpr_Paisdescripcion;
         A1EstadoID = obj10.gxTpr_Estadoid;
         A2EstadoDescripcion = obj10.gxTpr_Estadodescripcion;
         A4CiudadID = obj10.gxTpr_Ciudadid;
         n4CiudadID = false;
         A5CiudadDescripcion = obj10.gxTpr_Ciudaddescripcion;
         A66UsuarioSucursal = obj10.gxTpr_Usuariosucursal;
         A67UsuarioProducto = obj10.gxTpr_Usuarioproducto;
         n67UsuarioProducto = false;
         A40UsuarioRol = obj10.gxTpr_Usuariorol;
         A10DistribuidorID = obj10.gxTpr_Distribuidorid;
         A11DistribuidorDescripcion = obj10.gxTpr_Distribuidordescripcion;
         A12DistribuidorRFC = obj10.gxTpr_Distribuidorrfc;
         A81DistribuidoresUsuarioID = obj10.gxTpr_Distribuidoresusuarioid;
         Z81DistribuidoresUsuarioID = obj10.gxTpr_Distribuidoresusuarioid_Z;
         Z29UsuarioID = obj10.gxTpr_Usuarioid_Z;
         Z30UsuarioNombre = obj10.gxTpr_Usuarionombre_Z;
         Z51UsuarioApellido = obj10.gxTpr_Usuarioapellido_Z;
         Z52UsuarioNombreCompleto = obj10.gxTpr_Usuarionombrecompleto_Z;
         Z31UsuarioCorreo = obj10.gxTpr_Usuariocorreo_Z;
         Z32UsuarioPass = obj10.gxTpr_Usuariopass_Z;
         Z33UsuarioKey = obj10.gxTpr_Usuariokey_Z;
         Z13PuestoID = obj10.gxTpr_Puestoid_Z;
         Z14PuestoDescripcion = obj10.gxTpr_Puestodescripcion_Z;
         Z53UsuarioGenero = obj10.gxTpr_Usuariogenero_Z;
         Z54UsuarioDirectoAsociado = obj10.gxTpr_Usuariodirectoasociado_Z;
         Z55UsuarioRazonSocialAsociado = obj10.gxTpr_Usuariorazonsocialasociado_Z;
         Z56UsuarioNombreComercial = obj10.gxTpr_Usuarionombrecomercial_Z;
         Z57UsuarioFechaNacimiento = obj10.gxTpr_Usuariofechanacimiento_Z;
         Z59UsuarioCalleNum = obj10.gxTpr_Usuariocallenum_Z;
         Z60UsuarioColonia = obj10.gxTpr_Usuariocolonia_Z;
         Z61UsuarioDelegacion = obj10.gxTpr_Usuariodelegacion_Z;
         Z62UsuarioCP = obj10.gxTpr_Usuariocp_Z;
         Z63UsuarioZona = obj10.gxTpr_Usuariozona_Z;
         Z64UsuarioCelular = obj10.gxTpr_Usuariocelular_Z;
         Z65UsuarioTelefonoSucursal = obj10.gxTpr_Usuariotelefonosucursal_Z;
         Z16PaisID = obj10.gxTpr_Paisid_Z;
         Z17PaisDescripcion = obj10.gxTpr_Paisdescripcion_Z;
         Z1EstadoID = obj10.gxTpr_Estadoid_Z;
         Z2EstadoDescripcion = obj10.gxTpr_Estadodescripcion_Z;
         Z4CiudadID = obj10.gxTpr_Ciudadid_Z;
         Z5CiudadDescripcion = obj10.gxTpr_Ciudaddescripcion_Z;
         Z66UsuarioSucursal = obj10.gxTpr_Usuariosucursal_Z;
         Z67UsuarioProducto = obj10.gxTpr_Usuarioproducto_Z;
         Z40UsuarioRol = obj10.gxTpr_Usuariorol_Z;
         Z10DistribuidorID = obj10.gxTpr_Distribuidorid_Z;
         Z11DistribuidorDescripcion = obj10.gxTpr_Distribuidordescripcion_Z;
         Z12DistribuidorRFC = obj10.gxTpr_Distribuidorrfc_Z;
         n13PuestoID = (bool)(Convert.ToBoolean(obj10.gxTpr_Puestoid_N));
         n54UsuarioDirectoAsociado = (bool)(Convert.ToBoolean(obj10.gxTpr_Usuariodirectoasociado_N));
         n57UsuarioFechaNacimiento = (bool)(Convert.ToBoolean(obj10.gxTpr_Usuariofechanacimiento_N));
         n4CiudadID = (bool)(Convert.ToBoolean(obj10.gxTpr_Ciudadid_N));
         n67UsuarioProducto = (bool)(Convert.ToBoolean(obj10.gxTpr_Usuarioproducto_N));
         Gx_mode = obj10.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A81DistribuidoresUsuarioID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0H10( ) ;
         ScanKeyStart0H10( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z81DistribuidoresUsuarioID = A81DistribuidoresUsuarioID;
         }
         ZM0H10( -2) ;
         OnLoadActions0H10( ) ;
         AddRow0H10( ) ;
         ScanKeyEnd0H10( ) ;
         if ( RcdFound10 == 0 )
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
         RowToVars10( bcDistribuidoresUsuario, 0) ;
         ScanKeyStart0H10( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z81DistribuidoresUsuarioID = A81DistribuidoresUsuarioID;
         }
         ZM0H10( -2) ;
         OnLoadActions0H10( ) ;
         AddRow0H10( ) ;
         ScanKeyEnd0H10( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0H10( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0H10( ) ;
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A81DistribuidoresUsuarioID != Z81DistribuidoresUsuarioID )
               {
                  A81DistribuidoresUsuarioID = Z81DistribuidoresUsuarioID;
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
                  Update0H10( ) ;
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
                  if ( A81DistribuidoresUsuarioID != Z81DistribuidoresUsuarioID )
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
                        Insert0H10( ) ;
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
                        Insert0H10( ) ;
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
         RowToVars10( bcDistribuidoresUsuario, 1) ;
         SaveImpl( ) ;
         VarsToRow10( bcDistribuidoresUsuario) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars10( bcDistribuidoresUsuario, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H10( ) ;
         AfterTrn( ) ;
         VarsToRow10( bcDistribuidoresUsuario) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow10( bcDistribuidoresUsuario) ;
         }
         else
         {
            SdtDistribuidoresUsuario auxBC = new SdtDistribuidoresUsuario(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A81DistribuidoresUsuarioID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDistribuidoresUsuario);
               auxBC.Save();
               bcDistribuidoresUsuario.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars10( bcDistribuidoresUsuario, 1) ;
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
         RowToVars10( bcDistribuidoresUsuario, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H10( ) ;
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
               VarsToRow10( bcDistribuidoresUsuario) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow10( bcDistribuidoresUsuario) ;
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
         RowToVars10( bcDistribuidoresUsuario, 0) ;
         GetKey0H10( ) ;
         if ( RcdFound10 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A81DistribuidoresUsuarioID != Z81DistribuidoresUsuarioID )
            {
               A81DistribuidoresUsuarioID = Z81DistribuidoresUsuarioID;
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
            if ( A81DistribuidoresUsuarioID != Z81DistribuidoresUsuarioID )
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
         context.RollbackDataStores("distribuidoresusuario_bc",pr_default);
         VarsToRow10( bcDistribuidoresUsuario) ;
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
         Gx_mode = bcDistribuidoresUsuario.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDistribuidoresUsuario.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDistribuidoresUsuario )
         {
            bcDistribuidoresUsuario = (SdtDistribuidoresUsuario)(sdt);
            if ( StringUtil.StrCmp(bcDistribuidoresUsuario.gxTpr_Mode, "") == 0 )
            {
               bcDistribuidoresUsuario.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow10( bcDistribuidoresUsuario) ;
            }
            else
            {
               RowToVars10( bcDistribuidoresUsuario, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDistribuidoresUsuario.gxTpr_Mode, "") == 0 )
            {
               bcDistribuidoresUsuario.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars10( bcDistribuidoresUsuario, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtDistribuidoresUsuario DistribuidoresUsuario_BC
      {
         get {
            return bcDistribuidoresUsuario ;
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
         pr_default.close(19);
         pr_default.close(14);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(17);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z52UsuarioNombreCompleto = "";
         A52UsuarioNombreCompleto = "";
         Z11DistribuidorDescripcion = "";
         A11DistribuidorDescripcion = "";
         Z12DistribuidorRFC = "";
         A12DistribuidorRFC = "";
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
         Z14PuestoDescripcion = "";
         A14PuestoDescripcion = "";
         Z5CiudadDescripcion = "";
         A5CiudadDescripcion = "";
         Z2EstadoDescripcion = "";
         A2EstadoDescripcion = "";
         Z17PaisDescripcion = "";
         A17PaisDescripcion = "";
         BC000H10_A81DistribuidoresUsuarioID = new int[1] ;
         BC000H10_A30UsuarioNombre = new string[] {""} ;
         BC000H10_A51UsuarioApellido = new string[] {""} ;
         BC000H10_A31UsuarioCorreo = new string[] {""} ;
         BC000H10_A32UsuarioPass = new string[] {""} ;
         BC000H10_A33UsuarioKey = new string[] {""} ;
         BC000H10_A14PuestoDescripcion = new string[] {""} ;
         BC000H10_A53UsuarioGenero = new string[] {""} ;
         BC000H10_A54UsuarioDirectoAsociado = new string[] {""} ;
         BC000H10_n54UsuarioDirectoAsociado = new bool[] {false} ;
         BC000H10_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         BC000H10_A56UsuarioNombreComercial = new string[] {""} ;
         BC000H10_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000H10_n57UsuarioFechaNacimiento = new bool[] {false} ;
         BC000H10_A59UsuarioCalleNum = new string[] {""} ;
         BC000H10_A60UsuarioColonia = new string[] {""} ;
         BC000H10_A61UsuarioDelegacion = new string[] {""} ;
         BC000H10_A62UsuarioCP = new int[1] ;
         BC000H10_A63UsuarioZona = new string[] {""} ;
         BC000H10_A64UsuarioCelular = new long[1] ;
         BC000H10_A65UsuarioTelefonoSucursal = new long[1] ;
         BC000H10_A17PaisDescripcion = new string[] {""} ;
         BC000H10_A2EstadoDescripcion = new string[] {""} ;
         BC000H10_A5CiudadDescripcion = new string[] {""} ;
         BC000H10_A66UsuarioSucursal = new string[] {""} ;
         BC000H10_A67UsuarioProducto = new string[] {""} ;
         BC000H10_n67UsuarioProducto = new bool[] {false} ;
         BC000H10_A40UsuarioRol = new string[] {""} ;
         BC000H10_A11DistribuidorDescripcion = new string[] {""} ;
         BC000H10_A12DistribuidorRFC = new string[] {""} ;
         BC000H10_A10DistribuidorID = new int[1] ;
         BC000H10_A29UsuarioID = new int[1] ;
         BC000H10_A13PuestoID = new int[1] ;
         BC000H10_n13PuestoID = new bool[] {false} ;
         BC000H10_A4CiudadID = new int[1] ;
         BC000H10_n4CiudadID = new bool[] {false} ;
         BC000H10_A1EstadoID = new int[1] ;
         BC000H10_A16PaisID = new int[1] ;
         BC000H5_A30UsuarioNombre = new string[] {""} ;
         BC000H5_A51UsuarioApellido = new string[] {""} ;
         BC000H5_A31UsuarioCorreo = new string[] {""} ;
         BC000H5_A32UsuarioPass = new string[] {""} ;
         BC000H5_A33UsuarioKey = new string[] {""} ;
         BC000H5_A53UsuarioGenero = new string[] {""} ;
         BC000H5_A54UsuarioDirectoAsociado = new string[] {""} ;
         BC000H5_n54UsuarioDirectoAsociado = new bool[] {false} ;
         BC000H5_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         BC000H5_A56UsuarioNombreComercial = new string[] {""} ;
         BC000H5_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000H5_n57UsuarioFechaNacimiento = new bool[] {false} ;
         BC000H5_A59UsuarioCalleNum = new string[] {""} ;
         BC000H5_A60UsuarioColonia = new string[] {""} ;
         BC000H5_A61UsuarioDelegacion = new string[] {""} ;
         BC000H5_A62UsuarioCP = new int[1] ;
         BC000H5_A63UsuarioZona = new string[] {""} ;
         BC000H5_A64UsuarioCelular = new long[1] ;
         BC000H5_A65UsuarioTelefonoSucursal = new long[1] ;
         BC000H5_A66UsuarioSucursal = new string[] {""} ;
         BC000H5_A67UsuarioProducto = new string[] {""} ;
         BC000H5_n67UsuarioProducto = new bool[] {false} ;
         BC000H5_A40UsuarioRol = new string[] {""} ;
         BC000H5_A13PuestoID = new int[1] ;
         BC000H5_n13PuestoID = new bool[] {false} ;
         BC000H5_A4CiudadID = new int[1] ;
         BC000H5_n4CiudadID = new bool[] {false} ;
         BC000H6_A14PuestoDescripcion = new string[] {""} ;
         BC000H7_A5CiudadDescripcion = new string[] {""} ;
         BC000H7_A1EstadoID = new int[1] ;
         BC000H8_A2EstadoDescripcion = new string[] {""} ;
         BC000H8_A16PaisID = new int[1] ;
         BC000H9_A17PaisDescripcion = new string[] {""} ;
         BC000H4_A11DistribuidorDescripcion = new string[] {""} ;
         BC000H4_A12DistribuidorRFC = new string[] {""} ;
         BC000H11_A81DistribuidoresUsuarioID = new int[1] ;
         BC000H3_A81DistribuidoresUsuarioID = new int[1] ;
         BC000H3_A10DistribuidorID = new int[1] ;
         BC000H3_A29UsuarioID = new int[1] ;
         sMode10 = "";
         BC000H2_A81DistribuidoresUsuarioID = new int[1] ;
         BC000H2_A10DistribuidorID = new int[1] ;
         BC000H2_A29UsuarioID = new int[1] ;
         BC000H13_A81DistribuidoresUsuarioID = new int[1] ;
         BC000H16_A30UsuarioNombre = new string[] {""} ;
         BC000H16_A51UsuarioApellido = new string[] {""} ;
         BC000H16_A31UsuarioCorreo = new string[] {""} ;
         BC000H16_A32UsuarioPass = new string[] {""} ;
         BC000H16_A33UsuarioKey = new string[] {""} ;
         BC000H16_A53UsuarioGenero = new string[] {""} ;
         BC000H16_A54UsuarioDirectoAsociado = new string[] {""} ;
         BC000H16_n54UsuarioDirectoAsociado = new bool[] {false} ;
         BC000H16_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         BC000H16_A56UsuarioNombreComercial = new string[] {""} ;
         BC000H16_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000H16_n57UsuarioFechaNacimiento = new bool[] {false} ;
         BC000H16_A59UsuarioCalleNum = new string[] {""} ;
         BC000H16_A60UsuarioColonia = new string[] {""} ;
         BC000H16_A61UsuarioDelegacion = new string[] {""} ;
         BC000H16_A62UsuarioCP = new int[1] ;
         BC000H16_A63UsuarioZona = new string[] {""} ;
         BC000H16_A64UsuarioCelular = new long[1] ;
         BC000H16_A65UsuarioTelefonoSucursal = new long[1] ;
         BC000H16_A66UsuarioSucursal = new string[] {""} ;
         BC000H16_A67UsuarioProducto = new string[] {""} ;
         BC000H16_n67UsuarioProducto = new bool[] {false} ;
         BC000H16_A40UsuarioRol = new string[] {""} ;
         BC000H16_A13PuestoID = new int[1] ;
         BC000H16_n13PuestoID = new bool[] {false} ;
         BC000H16_A4CiudadID = new int[1] ;
         BC000H16_n4CiudadID = new bool[] {false} ;
         BC000H17_A14PuestoDescripcion = new string[] {""} ;
         BC000H18_A5CiudadDescripcion = new string[] {""} ;
         BC000H18_A1EstadoID = new int[1] ;
         BC000H19_A2EstadoDescripcion = new string[] {""} ;
         BC000H19_A16PaisID = new int[1] ;
         BC000H20_A17PaisDescripcion = new string[] {""} ;
         BC000H21_A11DistribuidorDescripcion = new string[] {""} ;
         BC000H21_A12DistribuidorRFC = new string[] {""} ;
         BC000H22_A81DistribuidoresUsuarioID = new int[1] ;
         BC000H22_A30UsuarioNombre = new string[] {""} ;
         BC000H22_A51UsuarioApellido = new string[] {""} ;
         BC000H22_A31UsuarioCorreo = new string[] {""} ;
         BC000H22_A32UsuarioPass = new string[] {""} ;
         BC000H22_A33UsuarioKey = new string[] {""} ;
         BC000H22_A14PuestoDescripcion = new string[] {""} ;
         BC000H22_A53UsuarioGenero = new string[] {""} ;
         BC000H22_A54UsuarioDirectoAsociado = new string[] {""} ;
         BC000H22_n54UsuarioDirectoAsociado = new bool[] {false} ;
         BC000H22_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         BC000H22_A56UsuarioNombreComercial = new string[] {""} ;
         BC000H22_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         BC000H22_n57UsuarioFechaNacimiento = new bool[] {false} ;
         BC000H22_A59UsuarioCalleNum = new string[] {""} ;
         BC000H22_A60UsuarioColonia = new string[] {""} ;
         BC000H22_A61UsuarioDelegacion = new string[] {""} ;
         BC000H22_A62UsuarioCP = new int[1] ;
         BC000H22_A63UsuarioZona = new string[] {""} ;
         BC000H22_A64UsuarioCelular = new long[1] ;
         BC000H22_A65UsuarioTelefonoSucursal = new long[1] ;
         BC000H22_A17PaisDescripcion = new string[] {""} ;
         BC000H22_A2EstadoDescripcion = new string[] {""} ;
         BC000H22_A5CiudadDescripcion = new string[] {""} ;
         BC000H22_A66UsuarioSucursal = new string[] {""} ;
         BC000H22_A67UsuarioProducto = new string[] {""} ;
         BC000H22_n67UsuarioProducto = new bool[] {false} ;
         BC000H22_A40UsuarioRol = new string[] {""} ;
         BC000H22_A11DistribuidorDescripcion = new string[] {""} ;
         BC000H22_A12DistribuidorRFC = new string[] {""} ;
         BC000H22_A10DistribuidorID = new int[1] ;
         BC000H22_A29UsuarioID = new int[1] ;
         BC000H22_A13PuestoID = new int[1] ;
         BC000H22_n13PuestoID = new bool[] {false} ;
         BC000H22_A4CiudadID = new int[1] ;
         BC000H22_n4CiudadID = new bool[] {false} ;
         BC000H22_A1EstadoID = new int[1] ;
         BC000H22_A16PaisID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.distribuidoresusuario_bc__default(),
            new Object[][] {
                new Object[] {
               BC000H2_A81DistribuidoresUsuarioID, BC000H2_A10DistribuidorID, BC000H2_A29UsuarioID
               }
               , new Object[] {
               BC000H3_A81DistribuidoresUsuarioID, BC000H3_A10DistribuidorID, BC000H3_A29UsuarioID
               }
               , new Object[] {
               BC000H4_A11DistribuidorDescripcion, BC000H4_A12DistribuidorRFC
               }
               , new Object[] {
               BC000H5_A30UsuarioNombre, BC000H5_A51UsuarioApellido, BC000H5_A31UsuarioCorreo, BC000H5_A32UsuarioPass, BC000H5_A33UsuarioKey, BC000H5_A53UsuarioGenero, BC000H5_A54UsuarioDirectoAsociado, BC000H5_n54UsuarioDirectoAsociado, BC000H5_A55UsuarioRazonSocialAsociado, BC000H5_A56UsuarioNombreComercial,
               BC000H5_A57UsuarioFechaNacimiento, BC000H5_n57UsuarioFechaNacimiento, BC000H5_A59UsuarioCalleNum, BC000H5_A60UsuarioColonia, BC000H5_A61UsuarioDelegacion, BC000H5_A62UsuarioCP, BC000H5_A63UsuarioZona, BC000H5_A64UsuarioCelular, BC000H5_A65UsuarioTelefonoSucursal, BC000H5_A66UsuarioSucursal,
               BC000H5_A67UsuarioProducto, BC000H5_n67UsuarioProducto, BC000H5_A40UsuarioRol, BC000H5_A13PuestoID, BC000H5_n13PuestoID, BC000H5_A4CiudadID, BC000H5_n4CiudadID
               }
               , new Object[] {
               BC000H6_A14PuestoDescripcion
               }
               , new Object[] {
               BC000H7_A5CiudadDescripcion, BC000H7_A1EstadoID
               }
               , new Object[] {
               BC000H8_A2EstadoDescripcion, BC000H8_A16PaisID
               }
               , new Object[] {
               BC000H9_A17PaisDescripcion
               }
               , new Object[] {
               BC000H10_A81DistribuidoresUsuarioID, BC000H10_A30UsuarioNombre, BC000H10_A51UsuarioApellido, BC000H10_A31UsuarioCorreo, BC000H10_A32UsuarioPass, BC000H10_A33UsuarioKey, BC000H10_A14PuestoDescripcion, BC000H10_A53UsuarioGenero, BC000H10_A54UsuarioDirectoAsociado, BC000H10_n54UsuarioDirectoAsociado,
               BC000H10_A55UsuarioRazonSocialAsociado, BC000H10_A56UsuarioNombreComercial, BC000H10_A57UsuarioFechaNacimiento, BC000H10_n57UsuarioFechaNacimiento, BC000H10_A59UsuarioCalleNum, BC000H10_A60UsuarioColonia, BC000H10_A61UsuarioDelegacion, BC000H10_A62UsuarioCP, BC000H10_A63UsuarioZona, BC000H10_A64UsuarioCelular,
               BC000H10_A65UsuarioTelefonoSucursal, BC000H10_A17PaisDescripcion, BC000H10_A2EstadoDescripcion, BC000H10_A5CiudadDescripcion, BC000H10_A66UsuarioSucursal, BC000H10_A67UsuarioProducto, BC000H10_n67UsuarioProducto, BC000H10_A40UsuarioRol, BC000H10_A11DistribuidorDescripcion, BC000H10_A12DistribuidorRFC,
               BC000H10_A10DistribuidorID, BC000H10_A29UsuarioID, BC000H10_A13PuestoID, BC000H10_n13PuestoID, BC000H10_A4CiudadID, BC000H10_n4CiudadID, BC000H10_A1EstadoID, BC000H10_A16PaisID
               }
               , new Object[] {
               BC000H11_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               }
               , new Object[] {
               BC000H13_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000H16_A30UsuarioNombre, BC000H16_A51UsuarioApellido, BC000H16_A31UsuarioCorreo, BC000H16_A32UsuarioPass, BC000H16_A33UsuarioKey, BC000H16_A53UsuarioGenero, BC000H16_A54UsuarioDirectoAsociado, BC000H16_n54UsuarioDirectoAsociado, BC000H16_A55UsuarioRazonSocialAsociado, BC000H16_A56UsuarioNombreComercial,
               BC000H16_A57UsuarioFechaNacimiento, BC000H16_n57UsuarioFechaNacimiento, BC000H16_A59UsuarioCalleNum, BC000H16_A60UsuarioColonia, BC000H16_A61UsuarioDelegacion, BC000H16_A62UsuarioCP, BC000H16_A63UsuarioZona, BC000H16_A64UsuarioCelular, BC000H16_A65UsuarioTelefonoSucursal, BC000H16_A66UsuarioSucursal,
               BC000H16_A67UsuarioProducto, BC000H16_n67UsuarioProducto, BC000H16_A40UsuarioRol, BC000H16_A13PuestoID, BC000H16_n13PuestoID, BC000H16_A4CiudadID, BC000H16_n4CiudadID
               }
               , new Object[] {
               BC000H17_A14PuestoDescripcion
               }
               , new Object[] {
               BC000H18_A5CiudadDescripcion, BC000H18_A1EstadoID
               }
               , new Object[] {
               BC000H19_A2EstadoDescripcion, BC000H19_A16PaisID
               }
               , new Object[] {
               BC000H20_A17PaisDescripcion
               }
               , new Object[] {
               BC000H21_A11DistribuidorDescripcion, BC000H21_A12DistribuidorRFC
               }
               , new Object[] {
               BC000H22_A81DistribuidoresUsuarioID, BC000H22_A30UsuarioNombre, BC000H22_A51UsuarioApellido, BC000H22_A31UsuarioCorreo, BC000H22_A32UsuarioPass, BC000H22_A33UsuarioKey, BC000H22_A14PuestoDescripcion, BC000H22_A53UsuarioGenero, BC000H22_A54UsuarioDirectoAsociado, BC000H22_n54UsuarioDirectoAsociado,
               BC000H22_A55UsuarioRazonSocialAsociado, BC000H22_A56UsuarioNombreComercial, BC000H22_A57UsuarioFechaNacimiento, BC000H22_n57UsuarioFechaNacimiento, BC000H22_A59UsuarioCalleNum, BC000H22_A60UsuarioColonia, BC000H22_A61UsuarioDelegacion, BC000H22_A62UsuarioCP, BC000H22_A63UsuarioZona, BC000H22_A64UsuarioCelular,
               BC000H22_A65UsuarioTelefonoSucursal, BC000H22_A17PaisDescripcion, BC000H22_A2EstadoDescripcion, BC000H22_A5CiudadDescripcion, BC000H22_A66UsuarioSucursal, BC000H22_A67UsuarioProducto, BC000H22_n67UsuarioProducto, BC000H22_A40UsuarioRol, BC000H22_A11DistribuidorDescripcion, BC000H22_A12DistribuidorRFC,
               BC000H22_A10DistribuidorID, BC000H22_A29UsuarioID, BC000H22_A13PuestoID, BC000H22_n13PuestoID, BC000H22_A4CiudadID, BC000H22_n4CiudadID, BC000H22_A1EstadoID, BC000H22_A16PaisID
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound10 ;
      private int trnEnded ;
      private int Z81DistribuidoresUsuarioID ;
      private int A81DistribuidoresUsuarioID ;
      private int Z10DistribuidorID ;
      private int A10DistribuidorID ;
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
      private string Z12DistribuidorRFC ;
      private string A12DistribuidorRFC ;
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
      private string sMode10 ;
      private DateTime Z57UsuarioFechaNacimiento ;
      private DateTime A57UsuarioFechaNacimiento ;
      private bool n54UsuarioDirectoAsociado ;
      private bool n57UsuarioFechaNacimiento ;
      private bool n67UsuarioProducto ;
      private bool n13PuestoID ;
      private bool n4CiudadID ;
      private string Z52UsuarioNombreCompleto ;
      private string A52UsuarioNombreCompleto ;
      private string Z11DistribuidorDescripcion ;
      private string A11DistribuidorDescripcion ;
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
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000H10_A81DistribuidoresUsuarioID ;
      private string[] BC000H10_A30UsuarioNombre ;
      private string[] BC000H10_A51UsuarioApellido ;
      private string[] BC000H10_A31UsuarioCorreo ;
      private string[] BC000H10_A32UsuarioPass ;
      private string[] BC000H10_A33UsuarioKey ;
      private string[] BC000H10_A14PuestoDescripcion ;
      private string[] BC000H10_A53UsuarioGenero ;
      private string[] BC000H10_A54UsuarioDirectoAsociado ;
      private bool[] BC000H10_n54UsuarioDirectoAsociado ;
      private string[] BC000H10_A55UsuarioRazonSocialAsociado ;
      private string[] BC000H10_A56UsuarioNombreComercial ;
      private DateTime[] BC000H10_A57UsuarioFechaNacimiento ;
      private bool[] BC000H10_n57UsuarioFechaNacimiento ;
      private string[] BC000H10_A59UsuarioCalleNum ;
      private string[] BC000H10_A60UsuarioColonia ;
      private string[] BC000H10_A61UsuarioDelegacion ;
      private int[] BC000H10_A62UsuarioCP ;
      private string[] BC000H10_A63UsuarioZona ;
      private long[] BC000H10_A64UsuarioCelular ;
      private long[] BC000H10_A65UsuarioTelefonoSucursal ;
      private string[] BC000H10_A17PaisDescripcion ;
      private string[] BC000H10_A2EstadoDescripcion ;
      private string[] BC000H10_A5CiudadDescripcion ;
      private string[] BC000H10_A66UsuarioSucursal ;
      private string[] BC000H10_A67UsuarioProducto ;
      private bool[] BC000H10_n67UsuarioProducto ;
      private string[] BC000H10_A40UsuarioRol ;
      private string[] BC000H10_A11DistribuidorDescripcion ;
      private string[] BC000H10_A12DistribuidorRFC ;
      private int[] BC000H10_A10DistribuidorID ;
      private int[] BC000H10_A29UsuarioID ;
      private int[] BC000H10_A13PuestoID ;
      private bool[] BC000H10_n13PuestoID ;
      private int[] BC000H10_A4CiudadID ;
      private bool[] BC000H10_n4CiudadID ;
      private int[] BC000H10_A1EstadoID ;
      private int[] BC000H10_A16PaisID ;
      private string[] BC000H5_A30UsuarioNombre ;
      private string[] BC000H5_A51UsuarioApellido ;
      private string[] BC000H5_A31UsuarioCorreo ;
      private string[] BC000H5_A32UsuarioPass ;
      private string[] BC000H5_A33UsuarioKey ;
      private string[] BC000H5_A53UsuarioGenero ;
      private string[] BC000H5_A54UsuarioDirectoAsociado ;
      private bool[] BC000H5_n54UsuarioDirectoAsociado ;
      private string[] BC000H5_A55UsuarioRazonSocialAsociado ;
      private string[] BC000H5_A56UsuarioNombreComercial ;
      private DateTime[] BC000H5_A57UsuarioFechaNacimiento ;
      private bool[] BC000H5_n57UsuarioFechaNacimiento ;
      private string[] BC000H5_A59UsuarioCalleNum ;
      private string[] BC000H5_A60UsuarioColonia ;
      private string[] BC000H5_A61UsuarioDelegacion ;
      private int[] BC000H5_A62UsuarioCP ;
      private string[] BC000H5_A63UsuarioZona ;
      private long[] BC000H5_A64UsuarioCelular ;
      private long[] BC000H5_A65UsuarioTelefonoSucursal ;
      private string[] BC000H5_A66UsuarioSucursal ;
      private string[] BC000H5_A67UsuarioProducto ;
      private bool[] BC000H5_n67UsuarioProducto ;
      private string[] BC000H5_A40UsuarioRol ;
      private int[] BC000H5_A13PuestoID ;
      private bool[] BC000H5_n13PuestoID ;
      private int[] BC000H5_A4CiudadID ;
      private bool[] BC000H5_n4CiudadID ;
      private string[] BC000H6_A14PuestoDescripcion ;
      private string[] BC000H7_A5CiudadDescripcion ;
      private int[] BC000H7_A1EstadoID ;
      private string[] BC000H8_A2EstadoDescripcion ;
      private int[] BC000H8_A16PaisID ;
      private string[] BC000H9_A17PaisDescripcion ;
      private string[] BC000H4_A11DistribuidorDescripcion ;
      private string[] BC000H4_A12DistribuidorRFC ;
      private int[] BC000H11_A81DistribuidoresUsuarioID ;
      private int[] BC000H3_A81DistribuidoresUsuarioID ;
      private int[] BC000H3_A10DistribuidorID ;
      private int[] BC000H3_A29UsuarioID ;
      private int[] BC000H2_A81DistribuidoresUsuarioID ;
      private int[] BC000H2_A10DistribuidorID ;
      private int[] BC000H2_A29UsuarioID ;
      private int[] BC000H13_A81DistribuidoresUsuarioID ;
      private string[] BC000H16_A30UsuarioNombre ;
      private string[] BC000H16_A51UsuarioApellido ;
      private string[] BC000H16_A31UsuarioCorreo ;
      private string[] BC000H16_A32UsuarioPass ;
      private string[] BC000H16_A33UsuarioKey ;
      private string[] BC000H16_A53UsuarioGenero ;
      private string[] BC000H16_A54UsuarioDirectoAsociado ;
      private bool[] BC000H16_n54UsuarioDirectoAsociado ;
      private string[] BC000H16_A55UsuarioRazonSocialAsociado ;
      private string[] BC000H16_A56UsuarioNombreComercial ;
      private DateTime[] BC000H16_A57UsuarioFechaNacimiento ;
      private bool[] BC000H16_n57UsuarioFechaNacimiento ;
      private string[] BC000H16_A59UsuarioCalleNum ;
      private string[] BC000H16_A60UsuarioColonia ;
      private string[] BC000H16_A61UsuarioDelegacion ;
      private int[] BC000H16_A62UsuarioCP ;
      private string[] BC000H16_A63UsuarioZona ;
      private long[] BC000H16_A64UsuarioCelular ;
      private long[] BC000H16_A65UsuarioTelefonoSucursal ;
      private string[] BC000H16_A66UsuarioSucursal ;
      private string[] BC000H16_A67UsuarioProducto ;
      private bool[] BC000H16_n67UsuarioProducto ;
      private string[] BC000H16_A40UsuarioRol ;
      private int[] BC000H16_A13PuestoID ;
      private bool[] BC000H16_n13PuestoID ;
      private int[] BC000H16_A4CiudadID ;
      private bool[] BC000H16_n4CiudadID ;
      private string[] BC000H17_A14PuestoDescripcion ;
      private string[] BC000H18_A5CiudadDescripcion ;
      private int[] BC000H18_A1EstadoID ;
      private string[] BC000H19_A2EstadoDescripcion ;
      private int[] BC000H19_A16PaisID ;
      private string[] BC000H20_A17PaisDescripcion ;
      private string[] BC000H21_A11DistribuidorDescripcion ;
      private string[] BC000H21_A12DistribuidorRFC ;
      private int[] BC000H22_A81DistribuidoresUsuarioID ;
      private string[] BC000H22_A30UsuarioNombre ;
      private string[] BC000H22_A51UsuarioApellido ;
      private string[] BC000H22_A31UsuarioCorreo ;
      private string[] BC000H22_A32UsuarioPass ;
      private string[] BC000H22_A33UsuarioKey ;
      private string[] BC000H22_A14PuestoDescripcion ;
      private string[] BC000H22_A53UsuarioGenero ;
      private string[] BC000H22_A54UsuarioDirectoAsociado ;
      private bool[] BC000H22_n54UsuarioDirectoAsociado ;
      private string[] BC000H22_A55UsuarioRazonSocialAsociado ;
      private string[] BC000H22_A56UsuarioNombreComercial ;
      private DateTime[] BC000H22_A57UsuarioFechaNacimiento ;
      private bool[] BC000H22_n57UsuarioFechaNacimiento ;
      private string[] BC000H22_A59UsuarioCalleNum ;
      private string[] BC000H22_A60UsuarioColonia ;
      private string[] BC000H22_A61UsuarioDelegacion ;
      private int[] BC000H22_A62UsuarioCP ;
      private string[] BC000H22_A63UsuarioZona ;
      private long[] BC000H22_A64UsuarioCelular ;
      private long[] BC000H22_A65UsuarioTelefonoSucursal ;
      private string[] BC000H22_A17PaisDescripcion ;
      private string[] BC000H22_A2EstadoDescripcion ;
      private string[] BC000H22_A5CiudadDescripcion ;
      private string[] BC000H22_A66UsuarioSucursal ;
      private string[] BC000H22_A67UsuarioProducto ;
      private bool[] BC000H22_n67UsuarioProducto ;
      private string[] BC000H22_A40UsuarioRol ;
      private string[] BC000H22_A11DistribuidorDescripcion ;
      private string[] BC000H22_A12DistribuidorRFC ;
      private int[] BC000H22_A10DistribuidorID ;
      private int[] BC000H22_A29UsuarioID ;
      private int[] BC000H22_A13PuestoID ;
      private bool[] BC000H22_n13PuestoID ;
      private int[] BC000H22_A4CiudadID ;
      private bool[] BC000H22_n4CiudadID ;
      private int[] BC000H22_A1EstadoID ;
      private int[] BC000H22_A16PaisID ;
      private SdtDistribuidoresUsuario bcDistribuidoresUsuario ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class distribuidoresusuario_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000H2;
          prmBC000H2 = new Object[] {
          new ParDef("@DistribuidoresUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000H3;
          prmBC000H3 = new Object[] {
          new ParDef("@DistribuidoresUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000H4;
          prmBC000H4 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC000H5;
          prmBC000H5 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000H6;
          prmBC000H6 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000H7;
          prmBC000H7 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000H8;
          prmBC000H8 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC000H9;
          prmBC000H9 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmBC000H10;
          prmBC000H10 = new Object[] {
          new ParDef("@DistribuidoresUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000H11;
          prmBC000H11 = new Object[] {
          new ParDef("@DistribuidoresUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000H12;
          prmBC000H12 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0) ,
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000H13;
          prmBC000H13 = new Object[] {
          };
          Object[] prmBC000H14;
          prmBC000H14 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0) ,
          new ParDef("@UsuarioID",GXType.Int32,9,0) ,
          new ParDef("@DistribuidoresUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000H15;
          prmBC000H15 = new Object[] {
          new ParDef("@DistribuidoresUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000H16;
          prmBC000H16 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000H17;
          prmBC000H17 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000H18;
          prmBC000H18 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000H19;
          prmBC000H19 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC000H20;
          prmBC000H20 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmBC000H21;
          prmBC000H21 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmBC000H22;
          prmBC000H22 = new Object[] {
          new ParDef("@DistribuidoresUsuarioID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000H2", "SELECT `DistribuidoresUsuarioID`, `DistribuidorID`, `UsuarioID` FROM `DistribuidoresUsuario` WHERE `DistribuidoresUsuarioID` = @DistribuidoresUsuarioID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H3", "SELECT `DistribuidoresUsuarioID`, `DistribuidorID`, `UsuarioID` FROM `DistribuidoresUsuario` WHERE `DistribuidoresUsuarioID` = @DistribuidoresUsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H4", "SELECT `DistribuidorDescripcion`, `DistribuidorRFC` FROM `Distribuidor` WHERE `DistribuidorID` = @DistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H5", "SELECT `UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioGenero`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioZona`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `PuestoID`, `CiudadID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H6", "SELECT `PuestoDescripcion` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H7", "SELECT `CiudadDescripcion`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H8", "SELECT `EstadoDescripcion`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H9", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H10", "SELECT TM1.`DistribuidoresUsuarioID`, T2.`UsuarioNombre`, T2.`UsuarioApellido`, T2.`UsuarioCorreo`, T2.`UsuarioPass`, T2.`UsuarioKey`, T3.`PuestoDescripcion`, T2.`UsuarioGenero`, T2.`UsuarioDirectoAsociado`, T2.`UsuarioRazonSocialAsociado`, T2.`UsuarioNombreComercial`, T2.`UsuarioFechaNacimiento`, T2.`UsuarioCalleNum`, T2.`UsuarioColonia`, T2.`UsuarioDelegacion`, T2.`UsuarioCP`, T2.`UsuarioZona`, T2.`UsuarioCelular`, T2.`UsuarioTelefonoSucursal`, T6.`PaisDescripcion`, T5.`EstadoDescripcion`, T4.`CiudadDescripcion`, T2.`UsuarioSucursal`, T2.`UsuarioProducto`, T2.`UsuarioRol`, T7.`DistribuidorDescripcion`, T7.`DistribuidorRFC`, TM1.`DistribuidorID`, TM1.`UsuarioID`, T2.`PuestoID`, T2.`CiudadID`, T4.`EstadoID`, T5.`PaisID` FROM ((((((`DistribuidoresUsuario` TM1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = TM1.`UsuarioID`) LEFT JOIN `Puesto` T3 ON T3.`PuestoID` = T2.`PuestoID`) LEFT JOIN `Ciudad` T4 ON T4.`CiudadID` = T2.`CiudadID`) LEFT JOIN `Estado` T5 ON T5.`EstadoID` = T4.`EstadoID`) LEFT JOIN `Pais` T6 ON T6.`PaisID` = T5.`PaisID`) INNER JOIN `Distribuidor` T7 ON T7.`DistribuidorID` = TM1.`DistribuidorID`) WHERE TM1.`DistribuidoresUsuarioID` = @DistribuidoresUsuarioID ORDER BY TM1.`DistribuidoresUsuarioID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H11", "SELECT `DistribuidoresUsuarioID` FROM `DistribuidoresUsuario` WHERE `DistribuidoresUsuarioID` = @DistribuidoresUsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H12", "INSERT INTO `DistribuidoresUsuario`(`DistribuidorID`, `UsuarioID`) VALUES(@DistribuidorID, @UsuarioID)", GxErrorMask.GX_NOMASK,prmBC000H12)
             ,new CursorDef("BC000H13", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H14", "UPDATE `DistribuidoresUsuario` SET `DistribuidorID`=@DistribuidorID, `UsuarioID`=@UsuarioID  WHERE `DistribuidoresUsuarioID` = @DistribuidoresUsuarioID", GxErrorMask.GX_NOMASK,prmBC000H14)
             ,new CursorDef("BC000H15", "DELETE FROM `DistribuidoresUsuario`  WHERE `DistribuidoresUsuarioID` = @DistribuidoresUsuarioID", GxErrorMask.GX_NOMASK,prmBC000H15)
             ,new CursorDef("BC000H16", "SELECT `UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioGenero`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioZona`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `PuestoID`, `CiudadID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H17", "SELECT `PuestoDescripcion` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H18", "SELECT `CiudadDescripcion`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H19", "SELECT `EstadoDescripcion`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H20", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H21", "SELECT `DistribuidorDescripcion`, `DistribuidorRFC` FROM `Distribuidor` WHERE `DistribuidorID` = @DistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000H22", "SELECT TM1.`DistribuidoresUsuarioID`, T2.`UsuarioNombre`, T2.`UsuarioApellido`, T2.`UsuarioCorreo`, T2.`UsuarioPass`, T2.`UsuarioKey`, T3.`PuestoDescripcion`, T2.`UsuarioGenero`, T2.`UsuarioDirectoAsociado`, T2.`UsuarioRazonSocialAsociado`, T2.`UsuarioNombreComercial`, T2.`UsuarioFechaNacimiento`, T2.`UsuarioCalleNum`, T2.`UsuarioColonia`, T2.`UsuarioDelegacion`, T2.`UsuarioCP`, T2.`UsuarioZona`, T2.`UsuarioCelular`, T2.`UsuarioTelefonoSucursal`, T6.`PaisDescripcion`, T5.`EstadoDescripcion`, T4.`CiudadDescripcion`, T2.`UsuarioSucursal`, T2.`UsuarioProducto`, T2.`UsuarioRol`, T7.`DistribuidorDescripcion`, T7.`DistribuidorRFC`, TM1.`DistribuidorID`, TM1.`UsuarioID`, T2.`PuestoID`, T2.`CiudadID`, T4.`EstadoID`, T5.`PaisID` FROM ((((((`DistribuidoresUsuario` TM1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = TM1.`UsuarioID`) LEFT JOIN `Puesto` T3 ON T3.`PuestoID` = T2.`PuestoID`) LEFT JOIN `Ciudad` T4 ON T4.`CiudadID` = T2.`CiudadID`) LEFT JOIN `Estado` T5 ON T5.`EstadoID` = T4.`EstadoID`) LEFT JOIN `Pais` T6 ON T6.`PaisID` = T5.`PaisID`) INNER JOIN `Distribuidor` T7 ON T7.`DistribuidorID` = TM1.`DistribuidorID`) WHERE TM1.`DistribuidoresUsuarioID` = @DistribuidoresUsuarioID ORDER BY TM1.`DistribuidoresUsuarioID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H22,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 13);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 40);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((int[]) buf[15])[0] = rslt.getInt(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 30);
                ((long[]) buf[17])[0] = rslt.getLong(16);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 20);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((string[]) buf[22])[0] = rslt.getString(20, 40);
                ((int[]) buf[23])[0] = rslt.getInt(21);
                ((bool[]) buf[24])[0] = rslt.wasNull(21);
                ((int[]) buf[25])[0] = rslt.getInt(22);
                ((bool[]) buf[26])[0] = rslt.wasNull(22);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
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
                ((string[]) buf[28])[0] = rslt.getVarchar(26);
                ((string[]) buf[29])[0] = rslt.getString(27, 13);
                ((int[]) buf[30])[0] = rslt.getInt(28);
                ((int[]) buf[31])[0] = rslt.getInt(29);
                ((int[]) buf[32])[0] = rslt.getInt(30);
                ((bool[]) buf[33])[0] = rslt.wasNull(30);
                ((int[]) buf[34])[0] = rslt.getInt(31);
                ((bool[]) buf[35])[0] = rslt.wasNull(31);
                ((int[]) buf[36])[0] = rslt.getInt(32);
                ((int[]) buf[37])[0] = rslt.getInt(33);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 40);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((int[]) buf[15])[0] = rslt.getInt(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 30);
                ((long[]) buf[17])[0] = rslt.getLong(16);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 20);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((string[]) buf[22])[0] = rslt.getString(20, 40);
                ((int[]) buf[23])[0] = rslt.getInt(21);
                ((bool[]) buf[24])[0] = rslt.wasNull(21);
                ((int[]) buf[25])[0] = rslt.getInt(22);
                ((bool[]) buf[26])[0] = rslt.wasNull(22);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 13);
                return;
             case 20 :
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
                ((string[]) buf[28])[0] = rslt.getVarchar(26);
                ((string[]) buf[29])[0] = rslt.getString(27, 13);
                ((int[]) buf[30])[0] = rslt.getInt(28);
                ((int[]) buf[31])[0] = rslt.getInt(29);
                ((int[]) buf[32])[0] = rslt.getInt(30);
                ((bool[]) buf[33])[0] = rslt.wasNull(30);
                ((int[]) buf[34])[0] = rslt.getInt(31);
                ((bool[]) buf[35])[0] = rslt.wasNull(31);
                ((int[]) buf[36])[0] = rslt.getInt(32);
                ((int[]) buf[37])[0] = rslt.getInt(33);
                return;
       }
    }

 }

}
