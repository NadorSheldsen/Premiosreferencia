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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class ageneraexcelpartidasxml : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            GxWebError = 1;
            context.HttpContext.Response.StatusCode = 403;
            context.WriteHtmlText( "<title>403 Forbidden</title>") ;
            context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
            context.WriteHtmlText( "<p /><hr />") ;
            GXUtil.WriteLog("send_http_error_code " + 403.ToString());
         }
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "ageneraexcelpartidasxml.aspx")), "ageneraexcelpartidasxml.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "ageneraexcelpartidasxml.aspx")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "PromocionID");
            if ( ! entryPointCalled )
            {
               AV41PromocionID = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public ageneraexcelpartidasxml( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ageneraexcelpartidasxml( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PromocionID )
      {
         this.AV41PromocionID = aP0_PromocionID;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( int aP0_PromocionID )
      {
         this.AV41PromocionID = aP0_PromocionID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! context.isAjaxRequest( ) )
         {
            AV10HttpResponse.AppendHeader(context.GetMessage( "Content-Type", ""), context.GetMessage( "application/vnd.ms-excel", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV10HttpResponse.AppendHeader(context.GetMessage( "Content-Disposition", ""), "attachment;filename=ListadoDeFacturas.xls");
         }
         AV10HttpResponse.AddString(context.GetMessage( "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />", ""));
         AV9xml.OpenResponse(AV10HttpResponse);
         AV9xml.WriteStartElement(context.GetMessage( "table border='1' style='border-collapse:collapse;'", ""));
         AV9xml.WriteStartElement(context.GetMessage( "tr", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), "#");
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "FOLIO #", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "FECHA REGISTRO", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "PROMOCIÓN", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "FECHA FACTURA", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "NO. FACTURA", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "ESTATUS", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "MOTIVO DE RECHAZO", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "DISTRIBUIDOR", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "ZONA", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "ESTADO", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "CIUDAD", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "VENDEDOR", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "No de Cuenta Broxel", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "Referencia Broxel", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "GÉNERO", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "MODELO", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "MEDIDA", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "CÓDIGO", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "RIN", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "CANTIDAD", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "BONO UNITARIO", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "BONO TOTAL", ""));
         AV9xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "PRECIO UNITARIO", ""));
         AV9xml.WriteEndElement();
         AV22Consecutivo = 0;
         /* Using cursor P003J2 */
         pr_default.execute(0, new Object[] {AV41PromocionID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A19MotivoRechazoID = P003J2_A19MotivoRechazoID[0];
            A4CiudadID = P003J2_A4CiudadID[0];
            n4CiudadID = P003J2_n4CiudadID[0];
            A1EstadoID = P003J2_A1EstadoID[0];
            A26MedidaID = P003J2_A26MedidaID[0];
            A41PromocionID = P003J2_A41PromocionID[0];
            A93FacturaCompleta = P003J2_A93FacturaCompleta[0];
            A29UsuarioID = P003J2_A29UsuarioID[0];
            A22ModeloID = P003J2_A22ModeloID[0];
            A80FacturaEstatus = P003J2_A80FacturaEstatus[0];
            A69FacturaID = P003J2_A69FacturaID[0];
            A72FacturaFechaRegistro = P003J2_A72FacturaFechaRegistro[0];
            A42PromocionDescripcion = P003J2_A42PromocionDescripcion[0];
            A73FacturaFechaFactura = P003J2_A73FacturaFechaFactura[0];
            A71FacturaNo = P003J2_A71FacturaNo[0];
            A20MotivoRechazoDescripcion = P003J2_A20MotivoRechazoDescripcion[0];
            A63UsuarioZona = P003J2_A63UsuarioZona[0];
            A2EstadoDescripcion = P003J2_A2EstadoDescripcion[0];
            A5CiudadDescripcion = P003J2_A5CiudadDescripcion[0];
            A82UsuarioNoCuentaBROXEL = P003J2_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = P003J2_A83UsuarioReferenciaBROXEL[0];
            A53UsuarioGenero = P003J2_A53UsuarioGenero[0];
            A23ModeloDescripcion = P003J2_A23ModeloDescripcion[0];
            A28MedidaDescripcion = P003J2_A28MedidaDescripcion[0];
            A27MedidaCodigo = P003J2_A27MedidaCodigo[0];
            A74MedidaRin = P003J2_A74MedidaRin[0];
            A78FacturaMedidaCantidad = P003J2_A78FacturaMedidaCantidad[0];
            A79FacturaMedidaPrecio = P003J2_A79FacturaMedidaPrecio[0];
            A51UsuarioApellido = P003J2_A51UsuarioApellido[0];
            A30UsuarioNombre = P003J2_A30UsuarioNombre[0];
            A77FacturaMedidaID = P003J2_A77FacturaMedidaID[0];
            A22ModeloID = P003J2_A22ModeloID[0];
            A28MedidaDescripcion = P003J2_A28MedidaDescripcion[0];
            A27MedidaCodigo = P003J2_A27MedidaCodigo[0];
            A74MedidaRin = P003J2_A74MedidaRin[0];
            A23ModeloDescripcion = P003J2_A23ModeloDescripcion[0];
            A19MotivoRechazoID = P003J2_A19MotivoRechazoID[0];
            A41PromocionID = P003J2_A41PromocionID[0];
            A93FacturaCompleta = P003J2_A93FacturaCompleta[0];
            A29UsuarioID = P003J2_A29UsuarioID[0];
            A80FacturaEstatus = P003J2_A80FacturaEstatus[0];
            A72FacturaFechaRegistro = P003J2_A72FacturaFechaRegistro[0];
            A73FacturaFechaFactura = P003J2_A73FacturaFechaFactura[0];
            A71FacturaNo = P003J2_A71FacturaNo[0];
            A20MotivoRechazoDescripcion = P003J2_A20MotivoRechazoDescripcion[0];
            A42PromocionDescripcion = P003J2_A42PromocionDescripcion[0];
            A4CiudadID = P003J2_A4CiudadID[0];
            n4CiudadID = P003J2_n4CiudadID[0];
            A63UsuarioZona = P003J2_A63UsuarioZona[0];
            A82UsuarioNoCuentaBROXEL = P003J2_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = P003J2_A83UsuarioReferenciaBROXEL[0];
            A53UsuarioGenero = P003J2_A53UsuarioGenero[0];
            A51UsuarioApellido = P003J2_A51UsuarioApellido[0];
            A30UsuarioNombre = P003J2_A30UsuarioNombre[0];
            A1EstadoID = P003J2_A1EstadoID[0];
            A5CiudadDescripcion = P003J2_A5CiudadDescripcion[0];
            A2EstadoDescripcion = P003J2_A2EstadoDescripcion[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            OV35FacturaEstatus = AV35FacturaEstatus;
            AV22Consecutivo = (long)(AV22Consecutivo+1);
            AV43UsuarioID = A29UsuarioID;
            AV38ModeloID = A22ModeloID;
            AV35FacturaEstatus = A80FacturaEstatus;
            /* Execute user subroutine: 'OBTIENEDISTRIBUIDOR' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'OBTIENBONOS' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            AV44Color = ((StringUtil.StrCmp(AV35FacturaEstatus, "Rechazada")==0) ? context.GetMessage( " style='background-color:#FA5858'", "") : context.GetMessage( " style='background-color:#107C41'", ""));
            AV9xml.WriteStartElement(context.GetMessage( "tr", ""));
            AV9xml.WriteElement(context.GetMessage( "td", ""), StringUtil.Str( (decimal)(AV22Consecutivo), 10, 0));
            AV9xml.WriteElement(context.GetMessage( "td", ""), StringUtil.Str( (decimal)(A69FacturaID), 9, 0));
            AV9xml.WriteElement(context.GetMessage( "td", ""), context.localUtil.DToC( A72FacturaFechaRegistro, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            AV9xml.WriteElement(context.GetMessage( "td", ""), A42PromocionDescripcion);
            AV9xml.WriteElement(context.GetMessage( "td", ""), context.localUtil.DToC( A73FacturaFechaFactura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            AV9xml.WriteElement(context.GetMessage( "td", ""), A71FacturaNo);
            AV9xml.WriteElement(context.GetMessage( "td", "")+AV44Color, A80FacturaEstatus);
            AV9xml.WriteElement(context.GetMessage( "td", "")+AV44Color, A20MotivoRechazoDescripcion);
            AV9xml.WriteElement(context.GetMessage( "td", ""), AV23DistribuidorDescripcion);
            AV9xml.WriteElement(context.GetMessage( "td", ""), A63UsuarioZona);
            AV9xml.WriteElement(context.GetMessage( "td", ""), A2EstadoDescripcion);
            AV9xml.WriteElement(context.GetMessage( "td", ""), A5CiudadDescripcion);
            AV9xml.WriteElement(context.GetMessage( "td", ""), A52UsuarioNombreCompleto);
            AV9xml.WriteElement(context.GetMessage( "td", ""), A82UsuarioNoCuentaBROXEL);
            AV9xml.WriteElement(context.GetMessage( "td", ""), A83UsuarioReferenciaBROXEL);
            AV9xml.WriteElement(context.GetMessage( "td", ""), A53UsuarioGenero);
            AV9xml.WriteElement(context.GetMessage( "td", ""), A23ModeloDescripcion);
            AV9xml.WriteElement(context.GetMessage( "td", ""), A28MedidaDescripcion);
            AV9xml.WriteElement(context.GetMessage( "td", ""), A27MedidaCodigo);
            AV9xml.WriteElement(context.GetMessage( "td", ""), A74MedidaRin);
            AV9xml.WriteElement(context.GetMessage( "td", ""), "$"+StringUtil.Str( (decimal)(A78FacturaMedidaCantidad), 4, 0));
            AV9xml.WriteElement(context.GetMessage( "td", ""), "$"+StringUtil.Str( AV19BonoUnitario, 10, 2));
            AV9xml.WriteElement(context.GetMessage( "td", ""), "$"+StringUtil.Str( AV18BonoTotal, 10, 2));
            AV9xml.WriteElement(context.GetMessage( "td", ""), "$"+StringUtil.Str( A79FacturaMedidaPrecio, 10, 2));
            AV9xml.WriteEndElement();
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV9xml.WriteEndElement();
         AV9xml.Close();
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OBTIENEDISTRIBUIDOR' Routine */
         returnInSub = false;
         /* Using cursor P003J3 */
         pr_default.execute(1, new Object[] {AV43UsuarioID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A10DistribuidorID = P003J3_A10DistribuidorID[0];
            A29UsuarioID = P003J3_A29UsuarioID[0];
            A11DistribuidorDescripcion = P003J3_A11DistribuidorDescripcion[0];
            A81DistribuidoresUsuarioID = P003J3_A81DistribuidoresUsuarioID[0];
            A11DistribuidorDescripcion = P003J3_A11DistribuidorDescripcion[0];
            AV23DistribuidorDescripcion = A11DistribuidorDescripcion;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'OBTIENBONOS' Routine */
         returnInSub = false;
         /* Using cursor P003J4 */
         pr_default.execute(2, new Object[] {AV41PromocionID, AV38ModeloID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A41PromocionID = P003J4_A41PromocionID[0];
            A22ModeloID = P003J4_A22ModeloID[0];
            A49PromocionModeloPrecio = P003J4_A49PromocionModeloPrecio[0];
            A48PromocionModeloID = P003J4_A48PromocionModeloID[0];
            AV19BonoUnitario = A49PromocionModeloPrecio;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV18BonoTotal = (decimal)(AV19BonoUnitario*A78FacturaMedidaCantidad);
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         GXDecQS = "";
         gxfirstwebparm = "";
         AV10HttpResponse = new GxHttpResponse( context);
         AV9xml = new GXXMLWriter(context.GetPhysicalPath());
         P003J2_A19MotivoRechazoID = new int[1] ;
         P003J2_A4CiudadID = new int[1] ;
         P003J2_n4CiudadID = new bool[] {false} ;
         P003J2_A1EstadoID = new int[1] ;
         P003J2_A26MedidaID = new int[1] ;
         P003J2_A41PromocionID = new int[1] ;
         P003J2_A93FacturaCompleta = new bool[] {false} ;
         P003J2_A29UsuarioID = new int[1] ;
         P003J2_A22ModeloID = new int[1] ;
         P003J2_A80FacturaEstatus = new string[] {""} ;
         P003J2_A69FacturaID = new int[1] ;
         P003J2_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P003J2_A42PromocionDescripcion = new string[] {""} ;
         P003J2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P003J2_A71FacturaNo = new string[] {""} ;
         P003J2_A20MotivoRechazoDescripcion = new string[] {""} ;
         P003J2_A63UsuarioZona = new string[] {""} ;
         P003J2_A2EstadoDescripcion = new string[] {""} ;
         P003J2_A5CiudadDescripcion = new string[] {""} ;
         P003J2_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         P003J2_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         P003J2_A53UsuarioGenero = new string[] {""} ;
         P003J2_A23ModeloDescripcion = new string[] {""} ;
         P003J2_A28MedidaDescripcion = new string[] {""} ;
         P003J2_A27MedidaCodigo = new string[] {""} ;
         P003J2_A74MedidaRin = new string[] {""} ;
         P003J2_A78FacturaMedidaCantidad = new short[1] ;
         P003J2_A79FacturaMedidaPrecio = new decimal[1] ;
         P003J2_A51UsuarioApellido = new string[] {""} ;
         P003J2_A30UsuarioNombre = new string[] {""} ;
         P003J2_A77FacturaMedidaID = new int[1] ;
         A80FacturaEstatus = "";
         A72FacturaFechaRegistro = DateTime.MinValue;
         A42PromocionDescripcion = "";
         A73FacturaFechaFactura = DateTime.MinValue;
         A71FacturaNo = "";
         A20MotivoRechazoDescripcion = "";
         A63UsuarioZona = "";
         A2EstadoDescripcion = "";
         A5CiudadDescripcion = "";
         A82UsuarioNoCuentaBROXEL = "";
         A83UsuarioReferenciaBROXEL = "";
         A53UsuarioGenero = "";
         A23ModeloDescripcion = "";
         A28MedidaDescripcion = "";
         A27MedidaCodigo = "";
         A74MedidaRin = "";
         A51UsuarioApellido = "";
         A30UsuarioNombre = "";
         A52UsuarioNombreCompleto = "";
         OV35FacturaEstatus = "";
         AV35FacturaEstatus = "En Proceso";
         AV44Color = "";
         AV23DistribuidorDescripcion = "";
         P003J3_A10DistribuidorID = new int[1] ;
         P003J3_A29UsuarioID = new int[1] ;
         P003J3_A11DistribuidorDescripcion = new string[] {""} ;
         P003J3_A81DistribuidoresUsuarioID = new int[1] ;
         A11DistribuidorDescripcion = "";
         P003J4_A41PromocionID = new int[1] ;
         P003J4_A22ModeloID = new int[1] ;
         P003J4_A49PromocionModeloPrecio = new decimal[1] ;
         P003J4_A48PromocionModeloID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ageneraexcelpartidasxml__default(),
            new Object[][] {
                new Object[] {
               P003J2_A19MotivoRechazoID, P003J2_A4CiudadID, P003J2_n4CiudadID, P003J2_A1EstadoID, P003J2_A26MedidaID, P003J2_A41PromocionID, P003J2_A93FacturaCompleta, P003J2_A29UsuarioID, P003J2_A22ModeloID, P003J2_A80FacturaEstatus,
               P003J2_A69FacturaID, P003J2_A72FacturaFechaRegistro, P003J2_A42PromocionDescripcion, P003J2_A73FacturaFechaFactura, P003J2_A71FacturaNo, P003J2_A20MotivoRechazoDescripcion, P003J2_A63UsuarioZona, P003J2_A2EstadoDescripcion, P003J2_A5CiudadDescripcion, P003J2_A82UsuarioNoCuentaBROXEL,
               P003J2_A83UsuarioReferenciaBROXEL, P003J2_A53UsuarioGenero, P003J2_A23ModeloDescripcion, P003J2_A28MedidaDescripcion, P003J2_A27MedidaCodigo, P003J2_A74MedidaRin, P003J2_A78FacturaMedidaCantidad, P003J2_A79FacturaMedidaPrecio, P003J2_A51UsuarioApellido, P003J2_A30UsuarioNombre,
               P003J2_A77FacturaMedidaID
               }
               , new Object[] {
               P003J3_A10DistribuidorID, P003J3_A29UsuarioID, P003J3_A11DistribuidorDescripcion, P003J3_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               P003J4_A41PromocionID, P003J4_A22ModeloID, P003J4_A49PromocionModeloPrecio, P003J4_A48PromocionModeloID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GxWebError ;
      private short nGotPars ;
      private short A78FacturaMedidaCantidad ;
      private int AV41PromocionID ;
      private int A19MotivoRechazoID ;
      private int A4CiudadID ;
      private int A1EstadoID ;
      private int A26MedidaID ;
      private int A41PromocionID ;
      private int A29UsuarioID ;
      private int A22ModeloID ;
      private int A69FacturaID ;
      private int A77FacturaMedidaID ;
      private int AV43UsuarioID ;
      private int AV38ModeloID ;
      private int A10DistribuidorID ;
      private int A81DistribuidoresUsuarioID ;
      private int A48PromocionModeloID ;
      private long AV22Consecutivo ;
      private decimal A79FacturaMedidaPrecio ;
      private decimal AV19BonoUnitario ;
      private decimal AV18BonoTotal ;
      private decimal A49PromocionModeloPrecio ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string A80FacturaEstatus ;
      private string A71FacturaNo ;
      private string A63UsuarioZona ;
      private string A82UsuarioNoCuentaBROXEL ;
      private string A83UsuarioReferenciaBROXEL ;
      private string A53UsuarioGenero ;
      private string A27MedidaCodigo ;
      private string A74MedidaRin ;
      private string A51UsuarioApellido ;
      private string A30UsuarioNombre ;
      private string OV35FacturaEstatus ;
      private string AV35FacturaEstatus ;
      private string AV44Color ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A73FacturaFechaFactura ;
      private bool entryPointCalled ;
      private bool n4CiudadID ;
      private bool A93FacturaCompleta ;
      private bool returnInSub ;
      private string A42PromocionDescripcion ;
      private string A20MotivoRechazoDescripcion ;
      private string A2EstadoDescripcion ;
      private string A5CiudadDescripcion ;
      private string A23ModeloDescripcion ;
      private string A28MedidaDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string AV23DistribuidorDescripcion ;
      private string A11DistribuidorDescripcion ;
      private GXXMLWriter AV9xml ;
      private GxHttpResponse AV10HttpResponse ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P003J2_A19MotivoRechazoID ;
      private int[] P003J2_A4CiudadID ;
      private bool[] P003J2_n4CiudadID ;
      private int[] P003J2_A1EstadoID ;
      private int[] P003J2_A26MedidaID ;
      private int[] P003J2_A41PromocionID ;
      private bool[] P003J2_A93FacturaCompleta ;
      private int[] P003J2_A29UsuarioID ;
      private int[] P003J2_A22ModeloID ;
      private string[] P003J2_A80FacturaEstatus ;
      private int[] P003J2_A69FacturaID ;
      private DateTime[] P003J2_A72FacturaFechaRegistro ;
      private string[] P003J2_A42PromocionDescripcion ;
      private DateTime[] P003J2_A73FacturaFechaFactura ;
      private string[] P003J2_A71FacturaNo ;
      private string[] P003J2_A20MotivoRechazoDescripcion ;
      private string[] P003J2_A63UsuarioZona ;
      private string[] P003J2_A2EstadoDescripcion ;
      private string[] P003J2_A5CiudadDescripcion ;
      private string[] P003J2_A82UsuarioNoCuentaBROXEL ;
      private string[] P003J2_A83UsuarioReferenciaBROXEL ;
      private string[] P003J2_A53UsuarioGenero ;
      private string[] P003J2_A23ModeloDescripcion ;
      private string[] P003J2_A28MedidaDescripcion ;
      private string[] P003J2_A27MedidaCodigo ;
      private string[] P003J2_A74MedidaRin ;
      private short[] P003J2_A78FacturaMedidaCantidad ;
      private decimal[] P003J2_A79FacturaMedidaPrecio ;
      private string[] P003J2_A51UsuarioApellido ;
      private string[] P003J2_A30UsuarioNombre ;
      private int[] P003J2_A77FacturaMedidaID ;
      private int[] P003J3_A10DistribuidorID ;
      private int[] P003J3_A29UsuarioID ;
      private string[] P003J3_A11DistribuidorDescripcion ;
      private int[] P003J3_A81DistribuidoresUsuarioID ;
      private int[] P003J4_A41PromocionID ;
      private int[] P003J4_A22ModeloID ;
      private decimal[] P003J4_A49PromocionModeloPrecio ;
      private int[] P003J4_A48PromocionModeloID ;
   }

   public class ageneraexcelpartidasxml__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP003J2;
          prmP003J2 = new Object[] {
          new ParDef("@AV41PromocionID",GXType.Int32,9,0)
          };
          Object[] prmP003J3;
          prmP003J3 = new Object[] {
          new ParDef("@AV43UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmP003J4;
          prmP003J4 = new Object[] {
          new ParDef("@AV41PromocionID",GXType.Int32,9,0) ,
          new ParDef("@AV38ModeloID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003J2", "SELECT T4.`MotivoRechazoID`, T7.`CiudadID`, T8.`EstadoID`, T1.`MedidaID`, T4.`PromocionID`, T4.`FacturaCompleta`, T4.`UsuarioID`, T2.`ModeloID`, T4.`FacturaEstatus`, T1.`FacturaID`, T4.`FacturaFechaRegistro`, T6.`PromocionDescripcion`, T4.`FacturaFechaFactura`, T4.`FacturaNo`, T5.`MotivoRechazoDescripcion`, T7.`UsuarioZona`, T9.`EstadoDescripcion`, T8.`CiudadDescripcion`, T7.`UsuarioNoCuentaBROXEL`, T7.`UsuarioReferenciaBROXEL`, T7.`UsuarioGenero`, T3.`ModeloDescripcion`, T2.`MedidaDescripcion`, T2.`MedidaCodigo`, T2.`MedidaRin`, T1.`FacturaMedidaCantidad`, T1.`FacturaMedidaPrecio`, T7.`UsuarioApellido`, T7.`UsuarioNombre`, T1.`FacturaMedidaID` FROM ((((((((`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T3 ON T3.`ModeloID` = T2.`ModeloID`) INNER JOIN `Factura` T4 ON T4.`FacturaID` = T1.`FacturaID`) INNER JOIN `MotivoRechazo` T5 ON T5.`MotivoRechazoID` = T4.`MotivoRechazoID`) INNER JOIN `Promocion` T6 ON T6.`PromocionID` = T4.`PromocionID`) INNER JOIN `Usuario` T7 ON T7.`UsuarioID` = T4.`UsuarioID`) LEFT JOIN `Ciudad` T8 ON T8.`CiudadID` = T7.`CiudadID`) LEFT JOIN `Estado` T9 ON T9.`EstadoID` = T8.`EstadoID`) WHERE (T4.`FacturaCompleta` = 1) AND (T4.`PromocionID` = @AV41PromocionID) ORDER BY T1.`FacturaMedidaID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003J2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003J3", "SELECT T1.`DistribuidorID`, T1.`UsuarioID`, T2.`DistribuidorDescripcion`, T1.`DistribuidoresUsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Distribuidor` T2 ON T2.`DistribuidorID` = T1.`DistribuidorID`) WHERE T1.`UsuarioID` = @AV43UsuarioID ORDER BY T1.`UsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003J3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003J4", "SELECT `PromocionID`, `ModeloID`, `PromocionModeloPrecio`, `PromocionModeloID` FROM `PromocionModelo` WHERE `PromocionID` = @AV41PromocionID and `ModeloID` = @AV38ModeloID ORDER BY `PromocionID`, `ModeloID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003J4,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((bool[]) buf[6])[0] = rslt.getBool(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(13);
                ((string[]) buf[14])[0] = rslt.getString(14, 20);
                ((string[]) buf[15])[0] = rslt.getVarchar(15);
                ((string[]) buf[16])[0] = rslt.getString(16, 30);
                ((string[]) buf[17])[0] = rslt.getVarchar(17);
                ((string[]) buf[18])[0] = rslt.getVarchar(18);
                ((string[]) buf[19])[0] = rslt.getString(19, 20);
                ((string[]) buf[20])[0] = rslt.getString(20, 20);
                ((string[]) buf[21])[0] = rslt.getString(21, 20);
                ((string[]) buf[22])[0] = rslt.getVarchar(22);
                ((string[]) buf[23])[0] = rslt.getVarchar(23);
                ((string[]) buf[24])[0] = rslt.getString(24, 20);
                ((string[]) buf[25])[0] = rslt.getString(25, 20);
                ((short[]) buf[26])[0] = rslt.getShort(26);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(27);
                ((string[]) buf[28])[0] = rslt.getString(28, 50);
                ((string[]) buf[29])[0] = rslt.getString(29, 50);
                ((int[]) buf[30])[0] = rslt.getInt(30);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
