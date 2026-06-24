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
   public class factura_bc : GxSilentTrn, IGxSilentTrn
   {
      public factura_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public factura_bc( IGxContext context )
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
         ReadRow0F15( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0F15( ) ;
         standaloneModal( ) ;
         AddRow0F15( ) ;
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
               Z69FacturaID = A69FacturaID;
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F15( ) ;
            }
            else
            {
               CheckExtendedTable0F15( ) ;
               if ( AnyError == 0 )
               {
                  ZM0F15( 9) ;
                  ZM0F15( 10) ;
                  ZM0F15( 11) ;
                  ZM0F15( 12) ;
                  ZM0F15( 13) ;
                  ZM0F15( 14) ;
               }
               CloseExtendedTableCursors0F15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0F15( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z71FacturaNo = A71FacturaNo;
            Z73FacturaFechaFactura = A73FacturaFechaFactura;
            Z72FacturaFechaRegistro = A72FacturaFechaRegistro;
            Z80FacturaEstatus = A80FacturaEstatus;
            Z93FacturaCompleta = A93FacturaCompleta;
            Z41PromocionID = A41PromocionID;
            Z19MotivoRechazoID = A19MotivoRechazoID;
            Z29UsuarioID = A29UsuarioID;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z42PromocionDescripcion = A42PromocionDescripcion;
            Z43PromocionBase = A43PromocionBase;
            Z45PromocionFechaInicio = A45PromocionFechaInicio;
            Z46PromocionFechaFin = A46PromocionFechaFin;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z20MotivoRechazoDescripcion = A20MotivoRechazoDescripcion;
            Z21MotivoRechazoActivo = A21MotivoRechazoActivo;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z4CiudadID = A4CiudadID;
            Z63UsuarioZona = A63UsuarioZona;
            Z53UsuarioGenero = A53UsuarioGenero;
            Z30UsuarioNombre = A30UsuarioNombre;
            Z51UsuarioApellido = A51UsuarioApellido;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z1EstadoID = A1EstadoID;
            Z5CiudadDescripcion = A5CiudadDescripcion;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z16PaisID = A16PaisID;
            Z2EstadoDescripcion = A2EstadoDescripcion;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z17PaisDescripcion = A17PaisDescripcion;
            Z70PromocionVigencia = A70PromocionVigencia;
            Z52UsuarioNombreCompleto = A52UsuarioNombreCompleto;
         }
         if ( GX_JID == -8 )
         {
            Z69FacturaID = A69FacturaID;
            Z71FacturaNo = A71FacturaNo;
            Z73FacturaFechaFactura = A73FacturaFechaFactura;
            Z72FacturaFechaRegistro = A72FacturaFechaRegistro;
            Z75FacturaPDF = A75FacturaPDF;
            Z40001FacturaPDF_GXI = A40001FacturaPDF_GXI;
            Z80FacturaEstatus = A80FacturaEstatus;
            Z93FacturaCompleta = A93FacturaCompleta;
            Z41PromocionID = A41PromocionID;
            Z19MotivoRechazoID = A19MotivoRechazoID;
            Z29UsuarioID = A29UsuarioID;
            Z42PromocionDescripcion = A42PromocionDescripcion;
            Z43PromocionBase = A43PromocionBase;
            Z44PromocionArte = A44PromocionArte;
            Z40000PromocionArte_GXI = A40000PromocionArte_GXI;
            Z45PromocionFechaInicio = A45PromocionFechaInicio;
            Z46PromocionFechaFin = A46PromocionFechaFin;
            Z4CiudadID = A4CiudadID;
            Z63UsuarioZona = A63UsuarioZona;
            Z53UsuarioGenero = A53UsuarioGenero;
            Z30UsuarioNombre = A30UsuarioNombre;
            Z51UsuarioApellido = A51UsuarioApellido;
            Z1EstadoID = A1EstadoID;
            Z5CiudadDescripcion = A5CiudadDescripcion;
            Z16PaisID = A16PaisID;
            Z2EstadoDescripcion = A2EstadoDescripcion;
            Z17PaisDescripcion = A17PaisDescripcion;
            Z20MotivoRechazoDescripcion = A20MotivoRechazoDescripcion;
            Z21MotivoRechazoActivo = A21MotivoRechazoActivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A93FacturaCompleta) && ( Gx_BScreen == 0 ) )
         {
            A93FacturaCompleta = false;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A80FacturaEstatus)) && ( Gx_BScreen == 0 ) )
         {
            A80FacturaEstatus = "En Proceso";
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0F15( )
      {
         /* Using cursor BC000F10 */
         pr_default.execute(8, new Object[] {A69FacturaID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound15 = 1;
            A4CiudadID = BC000F10_A4CiudadID[0];
            n4CiudadID = BC000F10_n4CiudadID[0];
            A1EstadoID = BC000F10_A1EstadoID[0];
            A16PaisID = BC000F10_A16PaisID[0];
            A42PromocionDescripcion = BC000F10_A42PromocionDescripcion[0];
            A43PromocionBase = BC000F10_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000F10_A40000PromocionArte_GXI[0];
            A71FacturaNo = BC000F10_A71FacturaNo[0];
            A73FacturaFechaFactura = BC000F10_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = BC000F10_A72FacturaFechaRegistro[0];
            A63UsuarioZona = BC000F10_A63UsuarioZona[0];
            A2EstadoDescripcion = BC000F10_A2EstadoDescripcion[0];
            A5CiudadDescripcion = BC000F10_A5CiudadDescripcion[0];
            A17PaisDescripcion = BC000F10_A17PaisDescripcion[0];
            A53UsuarioGenero = BC000F10_A53UsuarioGenero[0];
            A40001FacturaPDF_GXI = BC000F10_A40001FacturaPDF_GXI[0];
            A80FacturaEstatus = BC000F10_A80FacturaEstatus[0];
            A20MotivoRechazoDescripcion = BC000F10_A20MotivoRechazoDescripcion[0];
            A21MotivoRechazoActivo = BC000F10_A21MotivoRechazoActivo[0];
            A93FacturaCompleta = BC000F10_A93FacturaCompleta[0];
            A30UsuarioNombre = BC000F10_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000F10_A51UsuarioApellido[0];
            A45PromocionFechaInicio = BC000F10_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000F10_A46PromocionFechaFin[0];
            A41PromocionID = BC000F10_A41PromocionID[0];
            A19MotivoRechazoID = BC000F10_A19MotivoRechazoID[0];
            A29UsuarioID = BC000F10_A29UsuarioID[0];
            A44PromocionArte = BC000F10_A44PromocionArte[0];
            A75FacturaPDF = BC000F10_A75FacturaPDF[0];
            ZM0F15( -8) ;
         }
         pr_default.close(8);
         OnLoadActions0F15( ) ;
      }

      protected void OnLoadActions0F15( )
      {
         A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
      }

      protected void CheckExtendedTable0F15( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000F4 */
         pr_default.execute(2, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
         }
         A42PromocionDescripcion = BC000F4_A42PromocionDescripcion[0];
         A43PromocionBase = BC000F4_A43PromocionBase[0];
         A40000PromocionArte_GXI = BC000F4_A40000PromocionArte_GXI[0];
         A45PromocionFechaInicio = BC000F4_A45PromocionFechaInicio[0];
         A46PromocionFechaFin = BC000F4_A46PromocionFechaFin[0];
         A44PromocionArte = BC000F4_A44PromocionArte[0];
         pr_default.close(2);
         A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         if ( ! ( (DateTime.MinValue==A73FacturaFechaFactura) || ( DateTimeUtil.ResetTime ( A73FacturaFechaFactura ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1000, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Factura Fecha Factura", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A72FacturaFechaRegistro) || ( DateTimeUtil.ResetTime ( A72FacturaFechaRegistro ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1000, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Factura Fecha Registro", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000F6 */
         pr_default.execute(4, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
         }
         A4CiudadID = BC000F6_A4CiudadID[0];
         n4CiudadID = BC000F6_n4CiudadID[0];
         A63UsuarioZona = BC000F6_A63UsuarioZona[0];
         A53UsuarioGenero = BC000F6_A53UsuarioGenero[0];
         A30UsuarioNombre = BC000F6_A30UsuarioNombre[0];
         A51UsuarioApellido = BC000F6_A51UsuarioApellido[0];
         pr_default.close(4);
         /* Using cursor BC000F7 */
         pr_default.execute(5, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
            }
         }
         A1EstadoID = BC000F7_A1EstadoID[0];
         A5CiudadDescripcion = BC000F7_A5CiudadDescripcion[0];
         pr_default.close(5);
         /* Using cursor BC000F8 */
         pr_default.execute(6, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A16PaisID = BC000F8_A16PaisID[0];
         A2EstadoDescripcion = BC000F8_A2EstadoDescripcion[0];
         pr_default.close(6);
         /* Using cursor BC000F9 */
         pr_default.execute(7, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = BC000F9_A17PaisDescripcion[0];
         pr_default.close(7);
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
         if ( ! ( ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 ) || ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 ) || ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 ) || ( StringUtil.StrCmp(A80FacturaEstatus, "Cancelada") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Factura Estatus", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000F5 */
         pr_default.execute(3, new Object[] {A19MotivoRechazoID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Motivo Rechazo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MOTIVORECHAZOID");
            AnyError = 1;
         }
         A20MotivoRechazoDescripcion = BC000F5_A20MotivoRechazoDescripcion[0];
         A21MotivoRechazoActivo = BC000F5_A21MotivoRechazoActivo[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0F15( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F15( )
      {
         /* Using cursor BC000F11 */
         pr_default.execute(9, new Object[] {A69FacturaID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000F3 */
         pr_default.execute(1, new Object[] {A69FacturaID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F15( 8) ;
            RcdFound15 = 1;
            A69FacturaID = BC000F3_A69FacturaID[0];
            A71FacturaNo = BC000F3_A71FacturaNo[0];
            A73FacturaFechaFactura = BC000F3_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = BC000F3_A72FacturaFechaRegistro[0];
            A40001FacturaPDF_GXI = BC000F3_A40001FacturaPDF_GXI[0];
            A80FacturaEstatus = BC000F3_A80FacturaEstatus[0];
            A93FacturaCompleta = BC000F3_A93FacturaCompleta[0];
            A41PromocionID = BC000F3_A41PromocionID[0];
            A19MotivoRechazoID = BC000F3_A19MotivoRechazoID[0];
            A29UsuarioID = BC000F3_A29UsuarioID[0];
            A75FacturaPDF = BC000F3_A75FacturaPDF[0];
            Z69FacturaID = A69FacturaID;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0F15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0F15( ) ;
            }
            Gx_mode = sMode15;
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0F15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode15;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F15( ) ;
         if ( RcdFound15 == 0 )
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
         CONFIRM_0F0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0F15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F2 */
            pr_default.execute(0, new Object[] {A69FacturaID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Factura"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z71FacturaNo, BC000F2_A71FacturaNo[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z73FacturaFechaFactura ) != DateTimeUtil.ResetTime ( BC000F2_A73FacturaFechaFactura[0] ) ) || ( DateTimeUtil.ResetTime ( Z72FacturaFechaRegistro ) != DateTimeUtil.ResetTime ( BC000F2_A72FacturaFechaRegistro[0] ) ) || ( StringUtil.StrCmp(Z80FacturaEstatus, BC000F2_A80FacturaEstatus[0]) != 0 ) || ( Z93FacturaCompleta != BC000F2_A93FacturaCompleta[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z41PromocionID != BC000F2_A41PromocionID[0] ) || ( Z19MotivoRechazoID != BC000F2_A19MotivoRechazoID[0] ) || ( Z29UsuarioID != BC000F2_A29UsuarioID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Factura"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F15( )
      {
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F15( 0) ;
            CheckOptimisticConcurrency0F15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F12 */
                     pr_default.execute(10, new Object[] {A71FacturaNo, A73FacturaFechaFactura, A72FacturaFechaRegistro, A75FacturaPDF, A40001FacturaPDF_GXI, A80FacturaEstatus, A93FacturaCompleta, A41PromocionID, A19MotivoRechazoID, A29UsuarioID});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000F13 */
                     pr_default.execute(11);
                     A69FacturaID = BC000F13_A69FacturaID[0];
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Factura");
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
               Load0F15( ) ;
            }
            EndLevel0F15( ) ;
         }
         CloseExtendedTableCursors0F15( ) ;
      }

      protected void Update0F15( )
      {
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F14 */
                     pr_default.execute(12, new Object[] {A71FacturaNo, A73FacturaFechaFactura, A72FacturaFechaRegistro, A80FacturaEstatus, A93FacturaCompleta, A41PromocionID, A19MotivoRechazoID, A29UsuarioID, A69FacturaID});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Factura");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Factura"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F15( ) ;
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
            EndLevel0F15( ) ;
         }
         CloseExtendedTableCursors0F15( ) ;
      }

      protected void DeferredUpdate0F15( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000F15 */
            pr_default.execute(13, new Object[] {A75FacturaPDF, A40001FacturaPDF_GXI, A69FacturaID});
            pr_default.close(13);
            pr_default.SmartCacheProvider.SetUpdated("Factura");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F15( ) ;
            AfterConfirm0F15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000F16 */
                  pr_default.execute(14, new Object[] {A69FacturaID});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("Factura");
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F15( ) ;
         Gx_mode = sMode15;
      }

      protected void OnDeleteControls0F15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000F17 */
            pr_default.execute(15, new Object[] {A41PromocionID});
            A42PromocionDescripcion = BC000F17_A42PromocionDescripcion[0];
            A43PromocionBase = BC000F17_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000F17_A40000PromocionArte_GXI[0];
            A45PromocionFechaInicio = BC000F17_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000F17_A46PromocionFechaFin[0];
            A44PromocionArte = BC000F17_A44PromocionArte[0];
            pr_default.close(15);
            A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            /* Using cursor BC000F18 */
            pr_default.execute(16, new Object[] {A29UsuarioID});
            A4CiudadID = BC000F18_A4CiudadID[0];
            n4CiudadID = BC000F18_n4CiudadID[0];
            A63UsuarioZona = BC000F18_A63UsuarioZona[0];
            A53UsuarioGenero = BC000F18_A53UsuarioGenero[0];
            A30UsuarioNombre = BC000F18_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000F18_A51UsuarioApellido[0];
            pr_default.close(16);
            /* Using cursor BC000F19 */
            pr_default.execute(17, new Object[] {n4CiudadID, A4CiudadID});
            A1EstadoID = BC000F19_A1EstadoID[0];
            A5CiudadDescripcion = BC000F19_A5CiudadDescripcion[0];
            pr_default.close(17);
            /* Using cursor BC000F20 */
            pr_default.execute(18, new Object[] {A1EstadoID});
            A16PaisID = BC000F20_A16PaisID[0];
            A2EstadoDescripcion = BC000F20_A2EstadoDescripcion[0];
            pr_default.close(18);
            /* Using cursor BC000F21 */
            pr_default.execute(19, new Object[] {A16PaisID});
            A17PaisDescripcion = BC000F21_A17PaisDescripcion[0];
            pr_default.close(19);
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            /* Using cursor BC000F22 */
            pr_default.execute(20, new Object[] {A19MotivoRechazoID});
            A20MotivoRechazoDescripcion = BC000F22_A20MotivoRechazoDescripcion[0];
            A21MotivoRechazoActivo = BC000F22_A21MotivoRechazoActivo[0];
            pr_default.close(20);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000F23 */
            pr_default.execute(21, new Object[] {A69FacturaID});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Factura Medida", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
         }
      }

      protected void EndLevel0F15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F15( ) ;
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

      public void ScanKeyStart0F15( )
      {
         /* Using cursor BC000F24 */
         pr_default.execute(22, new Object[] {A69FacturaID});
         RcdFound15 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound15 = 1;
            A4CiudadID = BC000F24_A4CiudadID[0];
            n4CiudadID = BC000F24_n4CiudadID[0];
            A1EstadoID = BC000F24_A1EstadoID[0];
            A16PaisID = BC000F24_A16PaisID[0];
            A69FacturaID = BC000F24_A69FacturaID[0];
            A42PromocionDescripcion = BC000F24_A42PromocionDescripcion[0];
            A43PromocionBase = BC000F24_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000F24_A40000PromocionArte_GXI[0];
            A71FacturaNo = BC000F24_A71FacturaNo[0];
            A73FacturaFechaFactura = BC000F24_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = BC000F24_A72FacturaFechaRegistro[0];
            A63UsuarioZona = BC000F24_A63UsuarioZona[0];
            A2EstadoDescripcion = BC000F24_A2EstadoDescripcion[0];
            A5CiudadDescripcion = BC000F24_A5CiudadDescripcion[0];
            A17PaisDescripcion = BC000F24_A17PaisDescripcion[0];
            A53UsuarioGenero = BC000F24_A53UsuarioGenero[0];
            A40001FacturaPDF_GXI = BC000F24_A40001FacturaPDF_GXI[0];
            A80FacturaEstatus = BC000F24_A80FacturaEstatus[0];
            A20MotivoRechazoDescripcion = BC000F24_A20MotivoRechazoDescripcion[0];
            A21MotivoRechazoActivo = BC000F24_A21MotivoRechazoActivo[0];
            A93FacturaCompleta = BC000F24_A93FacturaCompleta[0];
            A30UsuarioNombre = BC000F24_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000F24_A51UsuarioApellido[0];
            A45PromocionFechaInicio = BC000F24_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000F24_A46PromocionFechaFin[0];
            A41PromocionID = BC000F24_A41PromocionID[0];
            A19MotivoRechazoID = BC000F24_A19MotivoRechazoID[0];
            A29UsuarioID = BC000F24_A29UsuarioID[0];
            A44PromocionArte = BC000F24_A44PromocionArte[0];
            A75FacturaPDF = BC000F24_A75FacturaPDF[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F15( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound15 = 0;
         ScanKeyLoad0F15( ) ;
      }

      protected void ScanKeyLoad0F15( )
      {
         sMode15 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound15 = 1;
            A4CiudadID = BC000F24_A4CiudadID[0];
            n4CiudadID = BC000F24_n4CiudadID[0];
            A1EstadoID = BC000F24_A1EstadoID[0];
            A16PaisID = BC000F24_A16PaisID[0];
            A69FacturaID = BC000F24_A69FacturaID[0];
            A42PromocionDescripcion = BC000F24_A42PromocionDescripcion[0];
            A43PromocionBase = BC000F24_A43PromocionBase[0];
            A40000PromocionArte_GXI = BC000F24_A40000PromocionArte_GXI[0];
            A71FacturaNo = BC000F24_A71FacturaNo[0];
            A73FacturaFechaFactura = BC000F24_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = BC000F24_A72FacturaFechaRegistro[0];
            A63UsuarioZona = BC000F24_A63UsuarioZona[0];
            A2EstadoDescripcion = BC000F24_A2EstadoDescripcion[0];
            A5CiudadDescripcion = BC000F24_A5CiudadDescripcion[0];
            A17PaisDescripcion = BC000F24_A17PaisDescripcion[0];
            A53UsuarioGenero = BC000F24_A53UsuarioGenero[0];
            A40001FacturaPDF_GXI = BC000F24_A40001FacturaPDF_GXI[0];
            A80FacturaEstatus = BC000F24_A80FacturaEstatus[0];
            A20MotivoRechazoDescripcion = BC000F24_A20MotivoRechazoDescripcion[0];
            A21MotivoRechazoActivo = BC000F24_A21MotivoRechazoActivo[0];
            A93FacturaCompleta = BC000F24_A93FacturaCompleta[0];
            A30UsuarioNombre = BC000F24_A30UsuarioNombre[0];
            A51UsuarioApellido = BC000F24_A51UsuarioApellido[0];
            A45PromocionFechaInicio = BC000F24_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = BC000F24_A46PromocionFechaFin[0];
            A41PromocionID = BC000F24_A41PromocionID[0];
            A19MotivoRechazoID = BC000F24_A19MotivoRechazoID[0];
            A29UsuarioID = BC000F24_A29UsuarioID[0];
            A44PromocionArte = BC000F24_A44PromocionArte[0];
            A75FacturaPDF = BC000F24_A75FacturaPDF[0];
         }
         Gx_mode = sMode15;
      }

      protected void ScanKeyEnd0F15( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm0F15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F15( )
      {
      }

      protected void send_integrity_lvl_hashes0F15( )
      {
      }

      protected void AddRow0F15( )
      {
         VarsToRow15( bcFactura) ;
      }

      protected void ReadRow0F15( )
      {
         RowToVars15( bcFactura, 1) ;
      }

      protected void InitializeNonKey0F15( )
      {
         A16PaisID = 0;
         A1EstadoID = 0;
         A4CiudadID = 0;
         n4CiudadID = false;
         A41PromocionID = 0;
         A42PromocionDescripcion = "";
         A43PromocionBase = "";
         A44PromocionArte = "";
         A40000PromocionArte_GXI = "";
         A70PromocionVigencia = "";
         A71FacturaNo = "";
         A73FacturaFechaFactura = DateTime.MinValue;
         A72FacturaFechaRegistro = DateTime.MinValue;
         A29UsuarioID = 0;
         A52UsuarioNombreCompleto = "";
         A63UsuarioZona = "";
         A2EstadoDescripcion = "";
         A5CiudadDescripcion = "";
         A17PaisDescripcion = "";
         A53UsuarioGenero = "";
         A75FacturaPDF = "";
         A40001FacturaPDF_GXI = "";
         A19MotivoRechazoID = 0;
         A20MotivoRechazoDescripcion = "";
         A21MotivoRechazoActivo = false;
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A45PromocionFechaInicio = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         A80FacturaEstatus = "En Proceso";
         A93FacturaCompleta = false;
         Z71FacturaNo = "";
         Z73FacturaFechaFactura = DateTime.MinValue;
         Z72FacturaFechaRegistro = DateTime.MinValue;
         Z80FacturaEstatus = "";
         Z93FacturaCompleta = false;
         Z41PromocionID = 0;
         Z19MotivoRechazoID = 0;
         Z29UsuarioID = 0;
      }

      protected void InitAll0F15( )
      {
         A69FacturaID = 0;
         InitializeNonKey0F15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A93FacturaCompleta = i93FacturaCompleta;
         A80FacturaEstatus = i80FacturaEstatus;
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

      public void VarsToRow15( SdtFactura obj15 )
      {
         obj15.gxTpr_Mode = Gx_mode;
         obj15.gxTpr_Promocionid = A41PromocionID;
         obj15.gxTpr_Promociondescripcion = A42PromocionDescripcion;
         obj15.gxTpr_Promocionbase = A43PromocionBase;
         obj15.gxTpr_Promocionarte = A44PromocionArte;
         obj15.gxTpr_Promocionarte_gxi = A40000PromocionArte_GXI;
         obj15.gxTpr_Promocionvigencia = A70PromocionVigencia;
         obj15.gxTpr_Facturano = A71FacturaNo;
         obj15.gxTpr_Facturafechafactura = A73FacturaFechaFactura;
         obj15.gxTpr_Facturafecharegistro = A72FacturaFechaRegistro;
         obj15.gxTpr_Usuarioid = A29UsuarioID;
         obj15.gxTpr_Usuarionombrecompleto = A52UsuarioNombreCompleto;
         obj15.gxTpr_Usuariozona = A63UsuarioZona;
         obj15.gxTpr_Estadodescripcion = A2EstadoDescripcion;
         obj15.gxTpr_Ciudaddescripcion = A5CiudadDescripcion;
         obj15.gxTpr_Paisdescripcion = A17PaisDescripcion;
         obj15.gxTpr_Usuariogenero = A53UsuarioGenero;
         obj15.gxTpr_Facturapdf = A75FacturaPDF;
         obj15.gxTpr_Facturapdf_gxi = A40001FacturaPDF_GXI;
         obj15.gxTpr_Motivorechazoid = A19MotivoRechazoID;
         obj15.gxTpr_Motivorechazodescripcion = A20MotivoRechazoDescripcion;
         obj15.gxTpr_Motivorechazoactivo = A21MotivoRechazoActivo;
         obj15.gxTpr_Facturaestatus = A80FacturaEstatus;
         obj15.gxTpr_Facturacompleta = A93FacturaCompleta;
         obj15.gxTpr_Facturaid = A69FacturaID;
         obj15.gxTpr_Facturaid_Z = Z69FacturaID;
         obj15.gxTpr_Promocionid_Z = Z41PromocionID;
         obj15.gxTpr_Promociondescripcion_Z = Z42PromocionDescripcion;
         obj15.gxTpr_Promocionbase_Z = Z43PromocionBase;
         obj15.gxTpr_Promocionvigencia_Z = Z70PromocionVigencia;
         obj15.gxTpr_Facturano_Z = Z71FacturaNo;
         obj15.gxTpr_Facturafechafactura_Z = Z73FacturaFechaFactura;
         obj15.gxTpr_Facturafecharegistro_Z = Z72FacturaFechaRegistro;
         obj15.gxTpr_Usuarioid_Z = Z29UsuarioID;
         obj15.gxTpr_Usuarionombrecompleto_Z = Z52UsuarioNombreCompleto;
         obj15.gxTpr_Usuariozona_Z = Z63UsuarioZona;
         obj15.gxTpr_Estadodescripcion_Z = Z2EstadoDescripcion;
         obj15.gxTpr_Ciudaddescripcion_Z = Z5CiudadDescripcion;
         obj15.gxTpr_Paisdescripcion_Z = Z17PaisDescripcion;
         obj15.gxTpr_Usuariogenero_Z = Z53UsuarioGenero;
         obj15.gxTpr_Facturaestatus_Z = Z80FacturaEstatus;
         obj15.gxTpr_Motivorechazoid_Z = Z19MotivoRechazoID;
         obj15.gxTpr_Motivorechazodescripcion_Z = Z20MotivoRechazoDescripcion;
         obj15.gxTpr_Motivorechazoactivo_Z = Z21MotivoRechazoActivo;
         obj15.gxTpr_Facturacompleta_Z = Z93FacturaCompleta;
         obj15.gxTpr_Promocionarte_gxi_Z = Z40000PromocionArte_GXI;
         obj15.gxTpr_Facturapdf_gxi_Z = Z40001FacturaPDF_GXI;
         obj15.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow15( SdtFactura obj15 )
      {
         obj15.gxTpr_Facturaid = A69FacturaID;
         return  ;
      }

      public void RowToVars15( SdtFactura obj15 ,
                               int forceLoad )
      {
         Gx_mode = obj15.gxTpr_Mode;
         A41PromocionID = obj15.gxTpr_Promocionid;
         A42PromocionDescripcion = obj15.gxTpr_Promociondescripcion;
         A43PromocionBase = obj15.gxTpr_Promocionbase;
         A44PromocionArte = obj15.gxTpr_Promocionarte;
         A40000PromocionArte_GXI = obj15.gxTpr_Promocionarte_gxi;
         A70PromocionVigencia = obj15.gxTpr_Promocionvigencia;
         A71FacturaNo = obj15.gxTpr_Facturano;
         A73FacturaFechaFactura = obj15.gxTpr_Facturafechafactura;
         A72FacturaFechaRegistro = obj15.gxTpr_Facturafecharegistro;
         A29UsuarioID = obj15.gxTpr_Usuarioid;
         A52UsuarioNombreCompleto = obj15.gxTpr_Usuarionombrecompleto;
         A63UsuarioZona = obj15.gxTpr_Usuariozona;
         A2EstadoDescripcion = obj15.gxTpr_Estadodescripcion;
         A5CiudadDescripcion = obj15.gxTpr_Ciudaddescripcion;
         A17PaisDescripcion = obj15.gxTpr_Paisdescripcion;
         A53UsuarioGenero = obj15.gxTpr_Usuariogenero;
         A75FacturaPDF = obj15.gxTpr_Facturapdf;
         A40001FacturaPDF_GXI = obj15.gxTpr_Facturapdf_gxi;
         A19MotivoRechazoID = obj15.gxTpr_Motivorechazoid;
         A20MotivoRechazoDescripcion = obj15.gxTpr_Motivorechazodescripcion;
         A21MotivoRechazoActivo = obj15.gxTpr_Motivorechazoactivo;
         A80FacturaEstatus = obj15.gxTpr_Facturaestatus;
         A93FacturaCompleta = obj15.gxTpr_Facturacompleta;
         A69FacturaID = obj15.gxTpr_Facturaid;
         Z69FacturaID = obj15.gxTpr_Facturaid_Z;
         Z41PromocionID = obj15.gxTpr_Promocionid_Z;
         Z42PromocionDescripcion = obj15.gxTpr_Promociondescripcion_Z;
         Z43PromocionBase = obj15.gxTpr_Promocionbase_Z;
         Z70PromocionVigencia = obj15.gxTpr_Promocionvigencia_Z;
         Z71FacturaNo = obj15.gxTpr_Facturano_Z;
         Z73FacturaFechaFactura = obj15.gxTpr_Facturafechafactura_Z;
         Z72FacturaFechaRegistro = obj15.gxTpr_Facturafecharegistro_Z;
         Z29UsuarioID = obj15.gxTpr_Usuarioid_Z;
         Z52UsuarioNombreCompleto = obj15.gxTpr_Usuarionombrecompleto_Z;
         Z63UsuarioZona = obj15.gxTpr_Usuariozona_Z;
         Z2EstadoDescripcion = obj15.gxTpr_Estadodescripcion_Z;
         Z5CiudadDescripcion = obj15.gxTpr_Ciudaddescripcion_Z;
         Z17PaisDescripcion = obj15.gxTpr_Paisdescripcion_Z;
         Z53UsuarioGenero = obj15.gxTpr_Usuariogenero_Z;
         Z80FacturaEstatus = obj15.gxTpr_Facturaestatus_Z;
         Z19MotivoRechazoID = obj15.gxTpr_Motivorechazoid_Z;
         Z20MotivoRechazoDescripcion = obj15.gxTpr_Motivorechazodescripcion_Z;
         Z21MotivoRechazoActivo = obj15.gxTpr_Motivorechazoactivo_Z;
         Z93FacturaCompleta = obj15.gxTpr_Facturacompleta_Z;
         Z40000PromocionArte_GXI = obj15.gxTpr_Promocionarte_gxi_Z;
         Z40001FacturaPDF_GXI = obj15.gxTpr_Facturapdf_gxi_Z;
         Gx_mode = obj15.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A69FacturaID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0F15( ) ;
         ScanKeyStart0F15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z69FacturaID = A69FacturaID;
         }
         ZM0F15( -8) ;
         OnLoadActions0F15( ) ;
         AddRow0F15( ) ;
         ScanKeyEnd0F15( ) ;
         if ( RcdFound15 == 0 )
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
         RowToVars15( bcFactura, 0) ;
         ScanKeyStart0F15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z69FacturaID = A69FacturaID;
         }
         ZM0F15( -8) ;
         OnLoadActions0F15( ) ;
         AddRow0F15( ) ;
         ScanKeyEnd0F15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0F15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0F15( ) ;
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A69FacturaID != Z69FacturaID )
               {
                  A69FacturaID = Z69FacturaID;
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
                  Update0F15( ) ;
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
                  if ( A69FacturaID != Z69FacturaID )
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
                        Insert0F15( ) ;
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
                        Insert0F15( ) ;
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
         RowToVars15( bcFactura, 1) ;
         SaveImpl( ) ;
         VarsToRow15( bcFactura) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars15( bcFactura, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F15( ) ;
         AfterTrn( ) ;
         VarsToRow15( bcFactura) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow15( bcFactura) ;
         }
         else
         {
            SdtFactura auxBC = new SdtFactura(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A69FacturaID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcFactura);
               auxBC.Save();
               bcFactura.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars15( bcFactura, 1) ;
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
         RowToVars15( bcFactura, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F15( ) ;
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
               VarsToRow15( bcFactura) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow15( bcFactura) ;
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
         RowToVars15( bcFactura, 0) ;
         GetKey0F15( ) ;
         if ( RcdFound15 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A69FacturaID != Z69FacturaID )
            {
               A69FacturaID = Z69FacturaID;
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
            if ( A69FacturaID != Z69FacturaID )
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
         context.RollbackDataStores("factura_bc",pr_default);
         VarsToRow15( bcFactura) ;
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
         Gx_mode = bcFactura.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcFactura.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcFactura )
         {
            bcFactura = (SdtFactura)(sdt);
            if ( StringUtil.StrCmp(bcFactura.gxTpr_Mode, "") == 0 )
            {
               bcFactura.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow15( bcFactura) ;
            }
            else
            {
               RowToVars15( bcFactura, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcFactura.gxTpr_Mode, "") == 0 )
            {
               bcFactura.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars15( bcFactura, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtFactura Factura_BC
      {
         get {
            return bcFactura ;
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
         pr_default.close(15);
         pr_default.close(20);
         pr_default.close(16);
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z71FacturaNo = "";
         A71FacturaNo = "";
         Z73FacturaFechaFactura = DateTime.MinValue;
         A73FacturaFechaFactura = DateTime.MinValue;
         Z72FacturaFechaRegistro = DateTime.MinValue;
         A72FacturaFechaRegistro = DateTime.MinValue;
         Z80FacturaEstatus = "";
         A80FacturaEstatus = "";
         Z70PromocionVigencia = "";
         A70PromocionVigencia = "";
         Z52UsuarioNombreCompleto = "";
         A52UsuarioNombreCompleto = "";
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
         Z5CiudadDescripcion = "";
         A5CiudadDescripcion = "";
         Z2EstadoDescripcion = "";
         A2EstadoDescripcion = "";
         Z17PaisDescripcion = "";
         A17PaisDescripcion = "";
         Z75FacturaPDF = "";
         A75FacturaPDF = "";
         Z40001FacturaPDF_GXI = "";
         A40001FacturaPDF_GXI = "";
         Z44PromocionArte = "";
         A44PromocionArte = "";
         Z40000PromocionArte_GXI = "";
         A40000PromocionArte_GXI = "";
         BC000F10_A4CiudadID = new int[1] ;
         BC000F10_n4CiudadID = new bool[] {false} ;
         BC000F10_A1EstadoID = new int[1] ;
         BC000F10_A16PaisID = new int[1] ;
         BC000F10_A69FacturaID = new int[1] ;
         BC000F10_A42PromocionDescripcion = new string[] {""} ;
         BC000F10_A43PromocionBase = new string[] {""} ;
         BC000F10_A40000PromocionArte_GXI = new string[] {""} ;
         BC000F10_A71FacturaNo = new string[] {""} ;
         BC000F10_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         BC000F10_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         BC000F10_A63UsuarioZona = new string[] {""} ;
         BC000F10_A2EstadoDescripcion = new string[] {""} ;
         BC000F10_A5CiudadDescripcion = new string[] {""} ;
         BC000F10_A17PaisDescripcion = new string[] {""} ;
         BC000F10_A53UsuarioGenero = new string[] {""} ;
         BC000F10_A40001FacturaPDF_GXI = new string[] {""} ;
         BC000F10_A80FacturaEstatus = new string[] {""} ;
         BC000F10_A20MotivoRechazoDescripcion = new string[] {""} ;
         BC000F10_A21MotivoRechazoActivo = new bool[] {false} ;
         BC000F10_A93FacturaCompleta = new bool[] {false} ;
         BC000F10_A30UsuarioNombre = new string[] {""} ;
         BC000F10_A51UsuarioApellido = new string[] {""} ;
         BC000F10_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000F10_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000F10_A41PromocionID = new int[1] ;
         BC000F10_A19MotivoRechazoID = new int[1] ;
         BC000F10_A29UsuarioID = new int[1] ;
         BC000F10_A44PromocionArte = new string[] {""} ;
         BC000F10_A75FacturaPDF = new string[] {""} ;
         BC000F4_A42PromocionDescripcion = new string[] {""} ;
         BC000F4_A43PromocionBase = new string[] {""} ;
         BC000F4_A40000PromocionArte_GXI = new string[] {""} ;
         BC000F4_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000F4_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000F4_A44PromocionArte = new string[] {""} ;
         BC000F6_A4CiudadID = new int[1] ;
         BC000F6_n4CiudadID = new bool[] {false} ;
         BC000F6_A63UsuarioZona = new string[] {""} ;
         BC000F6_A53UsuarioGenero = new string[] {""} ;
         BC000F6_A30UsuarioNombre = new string[] {""} ;
         BC000F6_A51UsuarioApellido = new string[] {""} ;
         BC000F7_A1EstadoID = new int[1] ;
         BC000F7_A5CiudadDescripcion = new string[] {""} ;
         BC000F8_A16PaisID = new int[1] ;
         BC000F8_A2EstadoDescripcion = new string[] {""} ;
         BC000F9_A17PaisDescripcion = new string[] {""} ;
         BC000F5_A20MotivoRechazoDescripcion = new string[] {""} ;
         BC000F5_A21MotivoRechazoActivo = new bool[] {false} ;
         BC000F11_A69FacturaID = new int[1] ;
         BC000F3_A69FacturaID = new int[1] ;
         BC000F3_A71FacturaNo = new string[] {""} ;
         BC000F3_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         BC000F3_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         BC000F3_A40001FacturaPDF_GXI = new string[] {""} ;
         BC000F3_A80FacturaEstatus = new string[] {""} ;
         BC000F3_A93FacturaCompleta = new bool[] {false} ;
         BC000F3_A41PromocionID = new int[1] ;
         BC000F3_A19MotivoRechazoID = new int[1] ;
         BC000F3_A29UsuarioID = new int[1] ;
         BC000F3_A75FacturaPDF = new string[] {""} ;
         sMode15 = "";
         BC000F2_A69FacturaID = new int[1] ;
         BC000F2_A71FacturaNo = new string[] {""} ;
         BC000F2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         BC000F2_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         BC000F2_A40001FacturaPDF_GXI = new string[] {""} ;
         BC000F2_A80FacturaEstatus = new string[] {""} ;
         BC000F2_A93FacturaCompleta = new bool[] {false} ;
         BC000F2_A41PromocionID = new int[1] ;
         BC000F2_A19MotivoRechazoID = new int[1] ;
         BC000F2_A29UsuarioID = new int[1] ;
         BC000F2_A75FacturaPDF = new string[] {""} ;
         BC000F13_A69FacturaID = new int[1] ;
         BC000F17_A42PromocionDescripcion = new string[] {""} ;
         BC000F17_A43PromocionBase = new string[] {""} ;
         BC000F17_A40000PromocionArte_GXI = new string[] {""} ;
         BC000F17_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000F17_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000F17_A44PromocionArte = new string[] {""} ;
         BC000F18_A4CiudadID = new int[1] ;
         BC000F18_n4CiudadID = new bool[] {false} ;
         BC000F18_A63UsuarioZona = new string[] {""} ;
         BC000F18_A53UsuarioGenero = new string[] {""} ;
         BC000F18_A30UsuarioNombre = new string[] {""} ;
         BC000F18_A51UsuarioApellido = new string[] {""} ;
         BC000F19_A1EstadoID = new int[1] ;
         BC000F19_A5CiudadDescripcion = new string[] {""} ;
         BC000F20_A16PaisID = new int[1] ;
         BC000F20_A2EstadoDescripcion = new string[] {""} ;
         BC000F21_A17PaisDescripcion = new string[] {""} ;
         BC000F22_A20MotivoRechazoDescripcion = new string[] {""} ;
         BC000F22_A21MotivoRechazoActivo = new bool[] {false} ;
         BC000F23_A77FacturaMedidaID = new int[1] ;
         BC000F24_A4CiudadID = new int[1] ;
         BC000F24_n4CiudadID = new bool[] {false} ;
         BC000F24_A1EstadoID = new int[1] ;
         BC000F24_A16PaisID = new int[1] ;
         BC000F24_A69FacturaID = new int[1] ;
         BC000F24_A42PromocionDescripcion = new string[] {""} ;
         BC000F24_A43PromocionBase = new string[] {""} ;
         BC000F24_A40000PromocionArte_GXI = new string[] {""} ;
         BC000F24_A71FacturaNo = new string[] {""} ;
         BC000F24_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         BC000F24_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         BC000F24_A63UsuarioZona = new string[] {""} ;
         BC000F24_A2EstadoDescripcion = new string[] {""} ;
         BC000F24_A5CiudadDescripcion = new string[] {""} ;
         BC000F24_A17PaisDescripcion = new string[] {""} ;
         BC000F24_A53UsuarioGenero = new string[] {""} ;
         BC000F24_A40001FacturaPDF_GXI = new string[] {""} ;
         BC000F24_A80FacturaEstatus = new string[] {""} ;
         BC000F24_A20MotivoRechazoDescripcion = new string[] {""} ;
         BC000F24_A21MotivoRechazoActivo = new bool[] {false} ;
         BC000F24_A93FacturaCompleta = new bool[] {false} ;
         BC000F24_A30UsuarioNombre = new string[] {""} ;
         BC000F24_A51UsuarioApellido = new string[] {""} ;
         BC000F24_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000F24_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000F24_A41PromocionID = new int[1] ;
         BC000F24_A19MotivoRechazoID = new int[1] ;
         BC000F24_A29UsuarioID = new int[1] ;
         BC000F24_A44PromocionArte = new string[] {""} ;
         BC000F24_A75FacturaPDF = new string[] {""} ;
         i80FacturaEstatus = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.factura_bc__default(),
            new Object[][] {
                new Object[] {
               BC000F2_A69FacturaID, BC000F2_A71FacturaNo, BC000F2_A73FacturaFechaFactura, BC000F2_A72FacturaFechaRegistro, BC000F2_A40001FacturaPDF_GXI, BC000F2_A80FacturaEstatus, BC000F2_A93FacturaCompleta, BC000F2_A41PromocionID, BC000F2_A19MotivoRechazoID, BC000F2_A29UsuarioID,
               BC000F2_A75FacturaPDF
               }
               , new Object[] {
               BC000F3_A69FacturaID, BC000F3_A71FacturaNo, BC000F3_A73FacturaFechaFactura, BC000F3_A72FacturaFechaRegistro, BC000F3_A40001FacturaPDF_GXI, BC000F3_A80FacturaEstatus, BC000F3_A93FacturaCompleta, BC000F3_A41PromocionID, BC000F3_A19MotivoRechazoID, BC000F3_A29UsuarioID,
               BC000F3_A75FacturaPDF
               }
               , new Object[] {
               BC000F4_A42PromocionDescripcion, BC000F4_A43PromocionBase, BC000F4_A40000PromocionArte_GXI, BC000F4_A45PromocionFechaInicio, BC000F4_A46PromocionFechaFin, BC000F4_A44PromocionArte
               }
               , new Object[] {
               BC000F5_A20MotivoRechazoDescripcion, BC000F5_A21MotivoRechazoActivo
               }
               , new Object[] {
               BC000F6_A4CiudadID, BC000F6_n4CiudadID, BC000F6_A63UsuarioZona, BC000F6_A53UsuarioGenero, BC000F6_A30UsuarioNombre, BC000F6_A51UsuarioApellido
               }
               , new Object[] {
               BC000F7_A1EstadoID, BC000F7_A5CiudadDescripcion
               }
               , new Object[] {
               BC000F8_A16PaisID, BC000F8_A2EstadoDescripcion
               }
               , new Object[] {
               BC000F9_A17PaisDescripcion
               }
               , new Object[] {
               BC000F10_A4CiudadID, BC000F10_n4CiudadID, BC000F10_A1EstadoID, BC000F10_A16PaisID, BC000F10_A69FacturaID, BC000F10_A42PromocionDescripcion, BC000F10_A43PromocionBase, BC000F10_A40000PromocionArte_GXI, BC000F10_A71FacturaNo, BC000F10_A73FacturaFechaFactura,
               BC000F10_A72FacturaFechaRegistro, BC000F10_A63UsuarioZona, BC000F10_A2EstadoDescripcion, BC000F10_A5CiudadDescripcion, BC000F10_A17PaisDescripcion, BC000F10_A53UsuarioGenero, BC000F10_A40001FacturaPDF_GXI, BC000F10_A80FacturaEstatus, BC000F10_A20MotivoRechazoDescripcion, BC000F10_A21MotivoRechazoActivo,
               BC000F10_A93FacturaCompleta, BC000F10_A30UsuarioNombre, BC000F10_A51UsuarioApellido, BC000F10_A45PromocionFechaInicio, BC000F10_A46PromocionFechaFin, BC000F10_A41PromocionID, BC000F10_A19MotivoRechazoID, BC000F10_A29UsuarioID, BC000F10_A44PromocionArte, BC000F10_A75FacturaPDF
               }
               , new Object[] {
               BC000F11_A69FacturaID
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F13_A69FacturaID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F17_A42PromocionDescripcion, BC000F17_A43PromocionBase, BC000F17_A40000PromocionArte_GXI, BC000F17_A45PromocionFechaInicio, BC000F17_A46PromocionFechaFin, BC000F17_A44PromocionArte
               }
               , new Object[] {
               BC000F18_A4CiudadID, BC000F18_n4CiudadID, BC000F18_A63UsuarioZona, BC000F18_A53UsuarioGenero, BC000F18_A30UsuarioNombre, BC000F18_A51UsuarioApellido
               }
               , new Object[] {
               BC000F19_A1EstadoID, BC000F19_A5CiudadDescripcion
               }
               , new Object[] {
               BC000F20_A16PaisID, BC000F20_A2EstadoDescripcion
               }
               , new Object[] {
               BC000F21_A17PaisDescripcion
               }
               , new Object[] {
               BC000F22_A20MotivoRechazoDescripcion, BC000F22_A21MotivoRechazoActivo
               }
               , new Object[] {
               BC000F23_A77FacturaMedidaID
               }
               , new Object[] {
               BC000F24_A4CiudadID, BC000F24_n4CiudadID, BC000F24_A1EstadoID, BC000F24_A16PaisID, BC000F24_A69FacturaID, BC000F24_A42PromocionDescripcion, BC000F24_A43PromocionBase, BC000F24_A40000PromocionArte_GXI, BC000F24_A71FacturaNo, BC000F24_A73FacturaFechaFactura,
               BC000F24_A72FacturaFechaRegistro, BC000F24_A63UsuarioZona, BC000F24_A2EstadoDescripcion, BC000F24_A5CiudadDescripcion, BC000F24_A17PaisDescripcion, BC000F24_A53UsuarioGenero, BC000F24_A40001FacturaPDF_GXI, BC000F24_A80FacturaEstatus, BC000F24_A20MotivoRechazoDescripcion, BC000F24_A21MotivoRechazoActivo,
               BC000F24_A93FacturaCompleta, BC000F24_A30UsuarioNombre, BC000F24_A51UsuarioApellido, BC000F24_A45PromocionFechaInicio, BC000F24_A46PromocionFechaFin, BC000F24_A41PromocionID, BC000F24_A19MotivoRechazoID, BC000F24_A29UsuarioID, BC000F24_A44PromocionArte, BC000F24_A75FacturaPDF
               }
            }
         );
         Z93FacturaCompleta = false;
         A93FacturaCompleta = false;
         i93FacturaCompleta = false;
         Z80FacturaEstatus = "En Proceso";
         A80FacturaEstatus = "En Proceso";
         i80FacturaEstatus = "En Proceso";
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound15 ;
      private int trnEnded ;
      private int Z69FacturaID ;
      private int A69FacturaID ;
      private int Z41PromocionID ;
      private int A41PromocionID ;
      private int Z19MotivoRechazoID ;
      private int A19MotivoRechazoID ;
      private int Z29UsuarioID ;
      private int A29UsuarioID ;
      private int Z4CiudadID ;
      private int A4CiudadID ;
      private int Z1EstadoID ;
      private int A1EstadoID ;
      private int Z16PaisID ;
      private int A16PaisID ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z71FacturaNo ;
      private string A71FacturaNo ;
      private string Z80FacturaEstatus ;
      private string A80FacturaEstatus ;
      private string Z63UsuarioZona ;
      private string A63UsuarioZona ;
      private string Z53UsuarioGenero ;
      private string A53UsuarioGenero ;
      private string Z30UsuarioNombre ;
      private string A30UsuarioNombre ;
      private string Z51UsuarioApellido ;
      private string A51UsuarioApellido ;
      private string sMode15 ;
      private string i80FacturaEstatus ;
      private DateTime Z73FacturaFechaFactura ;
      private DateTime A73FacturaFechaFactura ;
      private DateTime Z72FacturaFechaRegistro ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime Z45PromocionFechaInicio ;
      private DateTime A45PromocionFechaInicio ;
      private DateTime Z46PromocionFechaFin ;
      private DateTime A46PromocionFechaFin ;
      private bool Z93FacturaCompleta ;
      private bool A93FacturaCompleta ;
      private bool Z21MotivoRechazoActivo ;
      private bool A21MotivoRechazoActivo ;
      private bool n4CiudadID ;
      private bool Gx_longc ;
      private bool i93FacturaCompleta ;
      private string Z70PromocionVigencia ;
      private string A70PromocionVigencia ;
      private string Z52UsuarioNombreCompleto ;
      private string A52UsuarioNombreCompleto ;
      private string Z42PromocionDescripcion ;
      private string A42PromocionDescripcion ;
      private string Z43PromocionBase ;
      private string A43PromocionBase ;
      private string Z20MotivoRechazoDescripcion ;
      private string A20MotivoRechazoDescripcion ;
      private string Z5CiudadDescripcion ;
      private string A5CiudadDescripcion ;
      private string Z2EstadoDescripcion ;
      private string A2EstadoDescripcion ;
      private string Z17PaisDescripcion ;
      private string A17PaisDescripcion ;
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
      private int[] BC000F10_A4CiudadID ;
      private bool[] BC000F10_n4CiudadID ;
      private int[] BC000F10_A1EstadoID ;
      private int[] BC000F10_A16PaisID ;
      private int[] BC000F10_A69FacturaID ;
      private string[] BC000F10_A42PromocionDescripcion ;
      private string[] BC000F10_A43PromocionBase ;
      private string[] BC000F10_A40000PromocionArte_GXI ;
      private string[] BC000F10_A71FacturaNo ;
      private DateTime[] BC000F10_A73FacturaFechaFactura ;
      private DateTime[] BC000F10_A72FacturaFechaRegistro ;
      private string[] BC000F10_A63UsuarioZona ;
      private string[] BC000F10_A2EstadoDescripcion ;
      private string[] BC000F10_A5CiudadDescripcion ;
      private string[] BC000F10_A17PaisDescripcion ;
      private string[] BC000F10_A53UsuarioGenero ;
      private string[] BC000F10_A40001FacturaPDF_GXI ;
      private string[] BC000F10_A80FacturaEstatus ;
      private string[] BC000F10_A20MotivoRechazoDescripcion ;
      private bool[] BC000F10_A21MotivoRechazoActivo ;
      private bool[] BC000F10_A93FacturaCompleta ;
      private string[] BC000F10_A30UsuarioNombre ;
      private string[] BC000F10_A51UsuarioApellido ;
      private DateTime[] BC000F10_A45PromocionFechaInicio ;
      private DateTime[] BC000F10_A46PromocionFechaFin ;
      private int[] BC000F10_A41PromocionID ;
      private int[] BC000F10_A19MotivoRechazoID ;
      private int[] BC000F10_A29UsuarioID ;
      private string[] BC000F10_A44PromocionArte ;
      private string[] BC000F10_A75FacturaPDF ;
      private string[] BC000F4_A42PromocionDescripcion ;
      private string[] BC000F4_A43PromocionBase ;
      private string[] BC000F4_A40000PromocionArte_GXI ;
      private DateTime[] BC000F4_A45PromocionFechaInicio ;
      private DateTime[] BC000F4_A46PromocionFechaFin ;
      private string[] BC000F4_A44PromocionArte ;
      private int[] BC000F6_A4CiudadID ;
      private bool[] BC000F6_n4CiudadID ;
      private string[] BC000F6_A63UsuarioZona ;
      private string[] BC000F6_A53UsuarioGenero ;
      private string[] BC000F6_A30UsuarioNombre ;
      private string[] BC000F6_A51UsuarioApellido ;
      private int[] BC000F7_A1EstadoID ;
      private string[] BC000F7_A5CiudadDescripcion ;
      private int[] BC000F8_A16PaisID ;
      private string[] BC000F8_A2EstadoDescripcion ;
      private string[] BC000F9_A17PaisDescripcion ;
      private string[] BC000F5_A20MotivoRechazoDescripcion ;
      private bool[] BC000F5_A21MotivoRechazoActivo ;
      private int[] BC000F11_A69FacturaID ;
      private int[] BC000F3_A69FacturaID ;
      private string[] BC000F3_A71FacturaNo ;
      private DateTime[] BC000F3_A73FacturaFechaFactura ;
      private DateTime[] BC000F3_A72FacturaFechaRegistro ;
      private string[] BC000F3_A40001FacturaPDF_GXI ;
      private string[] BC000F3_A80FacturaEstatus ;
      private bool[] BC000F3_A93FacturaCompleta ;
      private int[] BC000F3_A41PromocionID ;
      private int[] BC000F3_A19MotivoRechazoID ;
      private int[] BC000F3_A29UsuarioID ;
      private string[] BC000F3_A75FacturaPDF ;
      private int[] BC000F2_A69FacturaID ;
      private string[] BC000F2_A71FacturaNo ;
      private DateTime[] BC000F2_A73FacturaFechaFactura ;
      private DateTime[] BC000F2_A72FacturaFechaRegistro ;
      private string[] BC000F2_A40001FacturaPDF_GXI ;
      private string[] BC000F2_A80FacturaEstatus ;
      private bool[] BC000F2_A93FacturaCompleta ;
      private int[] BC000F2_A41PromocionID ;
      private int[] BC000F2_A19MotivoRechazoID ;
      private int[] BC000F2_A29UsuarioID ;
      private string[] BC000F2_A75FacturaPDF ;
      private int[] BC000F13_A69FacturaID ;
      private string[] BC000F17_A42PromocionDescripcion ;
      private string[] BC000F17_A43PromocionBase ;
      private string[] BC000F17_A40000PromocionArte_GXI ;
      private DateTime[] BC000F17_A45PromocionFechaInicio ;
      private DateTime[] BC000F17_A46PromocionFechaFin ;
      private string[] BC000F17_A44PromocionArte ;
      private int[] BC000F18_A4CiudadID ;
      private bool[] BC000F18_n4CiudadID ;
      private string[] BC000F18_A63UsuarioZona ;
      private string[] BC000F18_A53UsuarioGenero ;
      private string[] BC000F18_A30UsuarioNombre ;
      private string[] BC000F18_A51UsuarioApellido ;
      private int[] BC000F19_A1EstadoID ;
      private string[] BC000F19_A5CiudadDescripcion ;
      private int[] BC000F20_A16PaisID ;
      private string[] BC000F20_A2EstadoDescripcion ;
      private string[] BC000F21_A17PaisDescripcion ;
      private string[] BC000F22_A20MotivoRechazoDescripcion ;
      private bool[] BC000F22_A21MotivoRechazoActivo ;
      private int[] BC000F23_A77FacturaMedidaID ;
      private int[] BC000F24_A4CiudadID ;
      private bool[] BC000F24_n4CiudadID ;
      private int[] BC000F24_A1EstadoID ;
      private int[] BC000F24_A16PaisID ;
      private int[] BC000F24_A69FacturaID ;
      private string[] BC000F24_A42PromocionDescripcion ;
      private string[] BC000F24_A43PromocionBase ;
      private string[] BC000F24_A40000PromocionArte_GXI ;
      private string[] BC000F24_A71FacturaNo ;
      private DateTime[] BC000F24_A73FacturaFechaFactura ;
      private DateTime[] BC000F24_A72FacturaFechaRegistro ;
      private string[] BC000F24_A63UsuarioZona ;
      private string[] BC000F24_A2EstadoDescripcion ;
      private string[] BC000F24_A5CiudadDescripcion ;
      private string[] BC000F24_A17PaisDescripcion ;
      private string[] BC000F24_A53UsuarioGenero ;
      private string[] BC000F24_A40001FacturaPDF_GXI ;
      private string[] BC000F24_A80FacturaEstatus ;
      private string[] BC000F24_A20MotivoRechazoDescripcion ;
      private bool[] BC000F24_A21MotivoRechazoActivo ;
      private bool[] BC000F24_A93FacturaCompleta ;
      private string[] BC000F24_A30UsuarioNombre ;
      private string[] BC000F24_A51UsuarioApellido ;
      private DateTime[] BC000F24_A45PromocionFechaInicio ;
      private DateTime[] BC000F24_A46PromocionFechaFin ;
      private int[] BC000F24_A41PromocionID ;
      private int[] BC000F24_A19MotivoRechazoID ;
      private int[] BC000F24_A29UsuarioID ;
      private string[] BC000F24_A44PromocionArte ;
      private string[] BC000F24_A75FacturaPDF ;
      private SdtFactura bcFactura ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class factura_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000F2;
          prmBC000F2 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmBC000F3;
          prmBC000F3 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmBC000F4;
          prmBC000F4 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000F5;
          prmBC000F5 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmBC000F6;
          prmBC000F6 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000F7;
          prmBC000F7 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000F8;
          prmBC000F8 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC000F9;
          prmBC000F9 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmBC000F10;
          prmBC000F10 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmBC000F11;
          prmBC000F11 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmBC000F12;
          prmBC000F12 = new Object[] {
          new ParDef("@FacturaNo",GXType.Char,20,0) ,
          new ParDef("@FacturaFechaFactura",GXType.Date,8,0) ,
          new ParDef("@FacturaFechaRegistro",GXType.Date,8,0) ,
          new ParDef("@FacturaPDF",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@FacturaPDF_GXI",GXType.Char,2048,0){AddAtt=true, ImgIdx=3, Tbl="Factura", Fld="FacturaPDF"} ,
          new ParDef("@FacturaEstatus",GXType.Char,20,0) ,
          new ParDef("@FacturaCompleta",GXType.Byte,4,0) ,
          new ParDef("@PromocionID",GXType.Int32,9,0) ,
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0) ,
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000F13;
          prmBC000F13 = new Object[] {
          };
          Object[] prmBC000F14;
          prmBC000F14 = new Object[] {
          new ParDef("@FacturaNo",GXType.Char,20,0) ,
          new ParDef("@FacturaFechaFactura",GXType.Date,8,0) ,
          new ParDef("@FacturaFechaRegistro",GXType.Date,8,0) ,
          new ParDef("@FacturaEstatus",GXType.Char,20,0) ,
          new ParDef("@FacturaCompleta",GXType.Byte,4,0) ,
          new ParDef("@PromocionID",GXType.Int32,9,0) ,
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0) ,
          new ParDef("@UsuarioID",GXType.Int32,9,0) ,
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmBC000F15;
          prmBC000F15 = new Object[] {
          new ParDef("@FacturaPDF",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@FacturaPDF_GXI",GXType.Char,2048,0){AddAtt=true, ImgIdx=0, Tbl="Factura", Fld="FacturaPDF"} ,
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmBC000F16;
          prmBC000F16 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmBC000F17;
          prmBC000F17 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmBC000F18;
          prmBC000F18 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmBC000F19;
          prmBC000F19 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000F20;
          prmBC000F20 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmBC000F21;
          prmBC000F21 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmBC000F22;
          prmBC000F22 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmBC000F23;
          prmBC000F23 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmBC000F24;
          prmBC000F24 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000F2", "SELECT `FacturaID`, `FacturaNo`, `FacturaFechaFactura`, `FacturaFechaRegistro`, `FacturaPDF_GXI`, `FacturaEstatus`, `FacturaCompleta`, `PromocionID`, `MotivoRechazoID`, `UsuarioID`, `FacturaPDF` FROM `Factura` WHERE `FacturaID` = @FacturaID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F3", "SELECT `FacturaID`, `FacturaNo`, `FacturaFechaFactura`, `FacturaFechaRegistro`, `FacturaPDF_GXI`, `FacturaEstatus`, `FacturaCompleta`, `PromocionID`, `MotivoRechazoID`, `UsuarioID`, `FacturaPDF` FROM `Factura` WHERE `FacturaID` = @FacturaID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F4", "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F5", "SELECT `MotivoRechazoDescripcion`, `MotivoRechazoActivo` FROM `MotivoRechazo` WHERE `MotivoRechazoID` = @MotivoRechazoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F6", "SELECT `CiudadID`, `UsuarioZona`, `UsuarioGenero`, `UsuarioNombre`, `UsuarioApellido` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F7", "SELECT `EstadoID`, `CiudadDescripcion` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F8", "SELECT `PaisID`, `EstadoDescripcion` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F9", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F10", "SELECT T3.`CiudadID`, T4.`EstadoID`, T5.`PaisID`, TM1.`FacturaID`, T2.`PromocionDescripcion`, T2.`PromocionBase`, T2.`PromocionArte_GXI`, TM1.`FacturaNo`, TM1.`FacturaFechaFactura`, TM1.`FacturaFechaRegistro`, T3.`UsuarioZona`, T5.`EstadoDescripcion`, T4.`CiudadDescripcion`, T6.`PaisDescripcion`, T3.`UsuarioGenero`, TM1.`FacturaPDF_GXI`, TM1.`FacturaEstatus`, T7.`MotivoRechazoDescripcion`, T7.`MotivoRechazoActivo`, TM1.`FacturaCompleta`, T3.`UsuarioNombre`, T3.`UsuarioApellido`, T2.`PromocionFechaInicio`, T2.`PromocionFechaFin`, TM1.`PromocionID`, TM1.`MotivoRechazoID`, TM1.`UsuarioID`, T2.`PromocionArte`, TM1.`FacturaPDF` FROM ((((((`Factura` TM1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = TM1.`PromocionID`) INNER JOIN `Usuario` T3 ON T3.`UsuarioID` = TM1.`UsuarioID`) LEFT JOIN `Ciudad` T4 ON T4.`CiudadID` = T3.`CiudadID`) LEFT JOIN `Estado` T5 ON T5.`EstadoID` = T4.`EstadoID`) LEFT JOIN `Pais` T6 ON T6.`PaisID` = T5.`PaisID`) INNER JOIN `MotivoRechazo` T7 ON T7.`MotivoRechazoID` = TM1.`MotivoRechazoID`) WHERE TM1.`FacturaID` = @FacturaID ORDER BY TM1.`FacturaID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F11", "SELECT `FacturaID` FROM `Factura` WHERE `FacturaID` = @FacturaID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F12", "INSERT INTO `Factura`(`FacturaNo`, `FacturaFechaFactura`, `FacturaFechaRegistro`, `FacturaPDF`, `FacturaPDF_GXI`, `FacturaEstatus`, `FacturaCompleta`, `PromocionID`, `MotivoRechazoID`, `UsuarioID`) VALUES(@FacturaNo, @FacturaFechaFactura, @FacturaFechaRegistro, @FacturaPDF, @FacturaPDF_GXI, @FacturaEstatus, @FacturaCompleta, @PromocionID, @MotivoRechazoID, @UsuarioID)", GxErrorMask.GX_NOMASK,prmBC000F12)
             ,new CursorDef("BC000F13", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F14", "UPDATE `Factura` SET `FacturaNo`=@FacturaNo, `FacturaFechaFactura`=@FacturaFechaFactura, `FacturaFechaRegistro`=@FacturaFechaRegistro, `FacturaEstatus`=@FacturaEstatus, `FacturaCompleta`=@FacturaCompleta, `PromocionID`=@PromocionID, `MotivoRechazoID`=@MotivoRechazoID, `UsuarioID`=@UsuarioID  WHERE `FacturaID` = @FacturaID", GxErrorMask.GX_NOMASK,prmBC000F14)
             ,new CursorDef("BC000F15", "UPDATE `Factura` SET `FacturaPDF`=@FacturaPDF, `FacturaPDF_GXI`=@FacturaPDF_GXI  WHERE `FacturaID` = @FacturaID", GxErrorMask.GX_NOMASK,prmBC000F15)
             ,new CursorDef("BC000F16", "DELETE FROM `Factura`  WHERE `FacturaID` = @FacturaID", GxErrorMask.GX_NOMASK,prmBC000F16)
             ,new CursorDef("BC000F17", "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F18", "SELECT `CiudadID`, `UsuarioZona`, `UsuarioGenero`, `UsuarioNombre`, `UsuarioApellido` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F19", "SELECT `EstadoID`, `CiudadDescripcion` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F20", "SELECT `PaisID`, `EstadoDescripcion` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F21", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F22", "SELECT `MotivoRechazoDescripcion`, `MotivoRechazoActivo` FROM `MotivoRechazo` WHERE `MotivoRechazoID` = @MotivoRechazoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F23", "SELECT `FacturaMedidaID` FROM `FacturaMedida` WHERE `FacturaID` = @FacturaID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F23,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000F24", "SELECT T3.`CiudadID`, T4.`EstadoID`, T5.`PaisID`, TM1.`FacturaID`, T2.`PromocionDescripcion`, T2.`PromocionBase`, T2.`PromocionArte_GXI`, TM1.`FacturaNo`, TM1.`FacturaFechaFactura`, TM1.`FacturaFechaRegistro`, T3.`UsuarioZona`, T5.`EstadoDescripcion`, T4.`CiudadDescripcion`, T6.`PaisDescripcion`, T3.`UsuarioGenero`, TM1.`FacturaPDF_GXI`, TM1.`FacturaEstatus`, T7.`MotivoRechazoDescripcion`, T7.`MotivoRechazoActivo`, TM1.`FacturaCompleta`, T3.`UsuarioNombre`, T3.`UsuarioApellido`, T2.`PromocionFechaInicio`, T2.`PromocionFechaFin`, TM1.`PromocionID`, TM1.`MotivoRechazoID`, TM1.`UsuarioID`, T2.`PromocionArte`, TM1.`FacturaPDF` FROM ((((((`Factura` TM1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = TM1.`PromocionID`) INNER JOIN `Usuario` T3 ON T3.`UsuarioID` = TM1.`UsuarioID`) LEFT JOIN `Ciudad` T4 ON T4.`CiudadID` = T3.`CiudadID`) LEFT JOIN `Estado` T5 ON T5.`EstadoID` = T4.`EstadoID`) LEFT JOIN `Pais` T6 ON T6.`PaisID` = T5.`PaisID`) INNER JOIN `MotivoRechazo` T7 ON T7.`MotivoRechazoID` = TM1.`MotivoRechazoID`) WHERE TM1.`FacturaID` = @FacturaID ORDER BY TM1.`FacturaID` ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F24,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 30);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((string[]) buf[4])[0] = rslt.getString(4, 50);
                ((string[]) buf[5])[0] = rslt.getString(5, 50);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getMultimediaUri(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 30);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getVarchar(13);
                ((string[]) buf[14])[0] = rslt.getVarchar(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 20);
                ((string[]) buf[16])[0] = rslt.getMultimediaUri(16);
                ((string[]) buf[17])[0] = rslt.getString(17, 20);
                ((string[]) buf[18])[0] = rslt.getVarchar(18);
                ((bool[]) buf[19])[0] = rslt.getBool(19);
                ((bool[]) buf[20])[0] = rslt.getBool(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 50);
                ((string[]) buf[22])[0] = rslt.getString(22, 50);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(23);
                ((DateTime[]) buf[24])[0] = rslt.getGXDate(24);
                ((int[]) buf[25])[0] = rslt.getInt(25);
                ((int[]) buf[26])[0] = rslt.getInt(26);
                ((int[]) buf[27])[0] = rslt.getInt(27);
                ((string[]) buf[28])[0] = rslt.getMultimediaFile(28, rslt.getVarchar(7));
                ((string[]) buf[29])[0] = rslt.getMultimediaFile(29, rslt.getVarchar(16));
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 30);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((string[]) buf[4])[0] = rslt.getString(4, 50);
                ((string[]) buf[5])[0] = rslt.getString(5, 50);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getMultimediaUri(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 30);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getVarchar(13);
                ((string[]) buf[14])[0] = rslt.getVarchar(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 20);
                ((string[]) buf[16])[0] = rslt.getMultimediaUri(16);
                ((string[]) buf[17])[0] = rslt.getString(17, 20);
                ((string[]) buf[18])[0] = rslt.getVarchar(18);
                ((bool[]) buf[19])[0] = rslt.getBool(19);
                ((bool[]) buf[20])[0] = rslt.getBool(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 50);
                ((string[]) buf[22])[0] = rslt.getString(22, 50);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(23);
                ((DateTime[]) buf[24])[0] = rslt.getGXDate(24);
                ((int[]) buf[25])[0] = rslt.getInt(25);
                ((int[]) buf[26])[0] = rslt.getInt(26);
                ((int[]) buf[27])[0] = rslt.getInt(27);
                ((string[]) buf[28])[0] = rslt.getMultimediaFile(28, rslt.getVarchar(7));
                ((string[]) buf[29])[0] = rslt.getMultimediaFile(29, rslt.getVarchar(16));
                return;
       }
    }

 }

}
