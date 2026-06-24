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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aexportfacturasigualqueejemploxml : GXWebProcedure
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "aexportfacturasigualqueejemploxml.aspx")), "aexportfacturasigualqueejemploxml.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "aexportfacturasigualqueejemploxml.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "FromDate");
            if ( ! entryPointCalled )
            {
               AV34FromDate = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV35ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV39UsuariosFiltro);
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV16PromocionID);
                  AV36FacturaNo = GetPar( "FacturaNo");
                  AV20FacturaEstatus = GetPar( "FacturaEstatus");
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aexportfacturasigualqueejemploxml( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aexportfacturasigualqueejemploxml( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<int> aP2_UsuariosFiltro ,
                           GxSimpleCollection<int> aP3_PromocionID ,
                           string aP4_FacturaNo ,
                           string aP5_FacturaEstatus )
      {
         this.AV34FromDate = aP0_FromDate;
         this.AV35ToDate = aP1_ToDate;
         this.AV39UsuariosFiltro = aP2_UsuariosFiltro;
         this.AV16PromocionID = aP3_PromocionID;
         this.AV36FacturaNo = aP4_FacturaNo;
         this.AV20FacturaEstatus = aP5_FacturaEstatus;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<int> aP2_UsuariosFiltro ,
                                 GxSimpleCollection<int> aP3_PromocionID ,
                                 string aP4_FacturaNo ,
                                 string aP5_FacturaEstatus )
      {
         this.AV34FromDate = aP0_FromDate;
         this.AV35ToDate = aP1_ToDate;
         this.AV39UsuariosFiltro = aP2_UsuariosFiltro;
         this.AV16PromocionID = aP3_PromocionID;
         this.AV36FacturaNo = aP4_FacturaNo;
         this.AV20FacturaEstatus = aP5_FacturaEstatus;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! context.isAjaxRequest( ) )
         {
            AV45HttpResponse.AppendHeader(context.GetMessage( "Content-Type", ""), context.GetMessage( "application/vnd.ms-excel", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV45HttpResponse.AppendHeader(context.GetMessage( "Content-Disposition", ""), "attachment;filename=Reporte.xls");
         }
         AV45HttpResponse.AddString(context.GetMessage( "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />", ""));
         AV48xml.OpenResponse(AV45HttpResponse);
         AV50tdNum = context.GetMessage( " x:num style='mso-number-format:#,##0'", "");
         AV51tdMon = context.GetMessage( " x:num style='mso-number-format:", "") + StringUtil.Chr( 34) + "$#,##0.00" + StringUtil.Chr( 34) + "'";
         AV46tdDate = context.GetMessage( " style='mso-number-format:", "") + StringUtil.Chr( 34) + context.GetMessage( "dd/mm/yy", "") + StringUtil.Chr( 34) + "'";
         AV52tdText = context.GetMessage( " style='mso-number-format:", "") + StringUtil.Chr( 34) + "@" + StringUtil.Chr( 34) + "'";
         AV43ColorEnProceso = "#f79b10";
         AV42ColorAprobada = "#00a75a";
         AV57Colorrechazada = "#dd4b39";
         AV44ColorCancelada = "#3e8cba";
         AV48xml.WriteStartElement(context.GetMessage( "table border='1' cellpadding='4' cellspacing='0' style='border-collapse:collapse;'", ""));
         AV48xml.WriteStartElement(context.GetMessage( "tr style='background-color:#e6e6e6;font-weight:bold;'", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), "#");
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "FOLIO #", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "FECHA REGISTRO", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "PROMOCIÓN", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "FECHA FACTURA", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "NO. FACTURA", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "ESTATUS", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "MOTIVO DE RECHAZO", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "DISTRIBUIDOR", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "ZONA", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "ESTADO", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "CIUDAD", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "VENDEDOR", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "GÉNERO", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "MODELO", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "MEDIDA", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "CÓDIGO", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "RIN", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "CANTIDAD", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "BONO UNITARIO", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "BONO TOTAL", ""));
         AV48xml.WriteElement(context.GetMessage( "th", ""), context.GetMessage( "PRECIO UNITARIO", ""));
         AV48xml.WriteEndElement();
         AV23Consecutivo = 0;
         AV49FilaPar = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV39UsuariosFiltro ,
                                              A41PromocionID ,
                                              AV16PromocionID ,
                                              AV34FromDate ,
                                              AV35ToDate ,
                                              AV39UsuariosFiltro.Count ,
                                              AV20FacturaEstatus ,
                                              AV16PromocionID.Count ,
                                              AV36FacturaNo ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              A71FacturaNo ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P004D2 */
         pr_default.execute(0, new Object[] {AV34FromDate, AV35ToDate, AV20FacturaEstatus, AV36FacturaNo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A19MotivoRechazoID = P004D2_A19MotivoRechazoID[0];
            A4CiudadID = P004D2_A4CiudadID[0];
            n4CiudadID = P004D2_n4CiudadID[0];
            A1EstadoID = P004D2_A1EstadoID[0];
            A26MedidaID = P004D2_A26MedidaID[0];
            A93FacturaCompleta = P004D2_A93FacturaCompleta[0];
            A71FacturaNo = P004D2_A71FacturaNo[0];
            A41PromocionID = P004D2_A41PromocionID[0];
            A80FacturaEstatus = P004D2_A80FacturaEstatus[0];
            A29UsuarioID = P004D2_A29UsuarioID[0];
            A73FacturaFechaFactura = P004D2_A73FacturaFechaFactura[0];
            A22ModeloID = P004D2_A22ModeloID[0];
            A78FacturaMedidaCantidad = P004D2_A78FacturaMedidaCantidad[0];
            A69FacturaID = P004D2_A69FacturaID[0];
            A72FacturaFechaRegistro = P004D2_A72FacturaFechaRegistro[0];
            A42PromocionDescripcion = P004D2_A42PromocionDescripcion[0];
            A20MotivoRechazoDescripcion = P004D2_A20MotivoRechazoDescripcion[0];
            A63UsuarioZona = P004D2_A63UsuarioZona[0];
            A2EstadoDescripcion = P004D2_A2EstadoDescripcion[0];
            A5CiudadDescripcion = P004D2_A5CiudadDescripcion[0];
            A53UsuarioGenero = P004D2_A53UsuarioGenero[0];
            A23ModeloDescripcion = P004D2_A23ModeloDescripcion[0];
            A28MedidaDescripcion = P004D2_A28MedidaDescripcion[0];
            A27MedidaCodigo = P004D2_A27MedidaCodigo[0];
            A74MedidaRin = P004D2_A74MedidaRin[0];
            A79FacturaMedidaPrecio = P004D2_A79FacturaMedidaPrecio[0];
            A51UsuarioApellido = P004D2_A51UsuarioApellido[0];
            A30UsuarioNombre = P004D2_A30UsuarioNombre[0];
            A77FacturaMedidaID = P004D2_A77FacturaMedidaID[0];
            A22ModeloID = P004D2_A22ModeloID[0];
            A28MedidaDescripcion = P004D2_A28MedidaDescripcion[0];
            A27MedidaCodigo = P004D2_A27MedidaCodigo[0];
            A74MedidaRin = P004D2_A74MedidaRin[0];
            A23ModeloDescripcion = P004D2_A23ModeloDescripcion[0];
            A19MotivoRechazoID = P004D2_A19MotivoRechazoID[0];
            A93FacturaCompleta = P004D2_A93FacturaCompleta[0];
            A71FacturaNo = P004D2_A71FacturaNo[0];
            A41PromocionID = P004D2_A41PromocionID[0];
            A80FacturaEstatus = P004D2_A80FacturaEstatus[0];
            A29UsuarioID = P004D2_A29UsuarioID[0];
            A73FacturaFechaFactura = P004D2_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P004D2_A72FacturaFechaRegistro[0];
            A20MotivoRechazoDescripcion = P004D2_A20MotivoRechazoDescripcion[0];
            A42PromocionDescripcion = P004D2_A42PromocionDescripcion[0];
            A4CiudadID = P004D2_A4CiudadID[0];
            n4CiudadID = P004D2_n4CiudadID[0];
            A63UsuarioZona = P004D2_A63UsuarioZona[0];
            A53UsuarioGenero = P004D2_A53UsuarioGenero[0];
            A51UsuarioApellido = P004D2_A51UsuarioApellido[0];
            A30UsuarioNombre = P004D2_A30UsuarioNombre[0];
            A1EstadoID = P004D2_A1EstadoID[0];
            A5CiudadDescripcion = P004D2_A5CiudadDescripcion[0];
            A2EstadoDescripcion = P004D2_A2EstadoDescripcion[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AV37TempPromocionID = A41PromocionID;
            AV38TempModeloID = A22ModeloID;
            AV40TempUsuarioID = A29UsuarioID;
            AV15DistribuidorDescripcion = "";
            /* Using cursor P004D3 */
            pr_default.execute(1, new Object[] {AV40TempUsuarioID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A10DistribuidorID = P004D3_A10DistribuidorID[0];
               A29UsuarioID = P004D3_A29UsuarioID[0];
               A11DistribuidorDescripcion = P004D3_A11DistribuidorDescripcion[0];
               A81DistribuidoresUsuarioID = P004D3_A81DistribuidoresUsuarioID[0];
               A11DistribuidorDescripcion = P004D3_A11DistribuidorDescripcion[0];
               AV15DistribuidorDescripcion = A11DistribuidorDescripcion;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV17BonoUnitario = 0;
            /* Using cursor P004D4 */
            pr_default.execute(2, new Object[] {AV37TempPromocionID, AV38TempModeloID});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A22ModeloID = P004D4_A22ModeloID[0];
               A41PromocionID = P004D4_A41PromocionID[0];
               A49PromocionModeloPrecio = P004D4_A49PromocionModeloPrecio[0];
               A48PromocionModeloID = P004D4_A48PromocionModeloID[0];
               AV17BonoUnitario = (long)(Math.Round(A49PromocionModeloPrecio, 18, MidpointRounding.ToEven));
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV18BonoTotal = (long)(AV17BonoUnitario*A78FacturaMedidaCantidad);
            AV49FilaPar = (bool)(!AV49FilaPar);
            AV56RowStyle = (AV49FilaPar ? context.GetMessage( " style='background-color:#f7f7f7'", "") : "");
            AV47tdEstatus = "";
            AV53tdMotivo = "";
            if ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 )
            {
               AV47tdEstatus = " style='background-color:" + AV43ColorEnProceso + ";color:#ffffff;font-weight:bold;'";
            }
            else if ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 )
            {
               AV47tdEstatus = " style='background-color:" + AV42ColorAprobada + ";color:#ffffff;font-weight:bold;'";
            }
            else if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
            {
               AV47tdEstatus = " style='background-color:" + AV57Colorrechazada + ";color:#ffffff;font-weight:bold;'";
               AV53tdMotivo = AV47tdEstatus;
            }
            else if ( StringUtil.StrCmp(A80FacturaEstatus, "Cancelada") == 0 )
            {
               AV47tdEstatus = " style='background-color:" + AV44ColorCancelada + ";color:#ffffff;font-weight:bold;'";
            }
            AV48xml.WriteStartElement(context.GetMessage( "tr", "")+AV56RowStyle);
            AV23Consecutivo = (long)(AV23Consecutivo+1);
            AV48xml.WriteElement(context.GetMessage( "td", "")+AV50tdNum, StringUtil.Str( (decimal)(AV23Consecutivo), 10, 0));
            AV48xml.WriteElement(context.GetMessage( "td", "")+AV52tdText, StringUtil.Str( (decimal)(A69FacturaID), 9, 0));
            AV48xml.WriteElement(context.GetMessage( "td", "")+AV46tdDate, context.localUtil.DToC( A72FacturaFechaRegistro, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            AV48xml.WriteElement(context.GetMessage( "td", ""), A42PromocionDescripcion);
            AV48xml.WriteElement(context.GetMessage( "td", "")+AV46tdDate, context.localUtil.DToC( A73FacturaFechaFactura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            AV48xml.WriteElement(context.GetMessage( "td", "")+AV52tdText, A71FacturaNo);
            AV48xml.WriteElement(context.GetMessage( "td", "")+AV47tdEstatus, A80FacturaEstatus);
            AV48xml.WriteElement(context.GetMessage( "td", "")+AV53tdMotivo, ((StringUtil.StrCmp(StringUtil.Trim( A20MotivoRechazoDescripcion), "")==0) ? "" : A20MotivoRechazoDescripcion));
            AV48xml.WriteElement(context.GetMessage( "td", ""), AV15DistribuidorDescripcion);
            AV48xml.WriteElement(context.GetMessage( "td", ""), A63UsuarioZona);
            AV48xml.WriteElement(context.GetMessage( "td", ""), A2EstadoDescripcion);
            AV48xml.WriteElement(context.GetMessage( "td", ""), A5CiudadDescripcion);
            AV48xml.WriteElement(context.GetMessage( "td", ""), A52UsuarioNombreCompleto);
            AV48xml.WriteElement(context.GetMessage( "td", ""), A53UsuarioGenero);
            AV48xml.WriteElement(context.GetMessage( "td", ""), A23ModeloDescripcion);
            AV48xml.WriteElement(context.GetMessage( "td", ""), A28MedidaDescripcion);
            AV48xml.WriteElement(context.GetMessage( "td", ""), A27MedidaCodigo);
            AV48xml.WriteElement(context.GetMessage( "td", ""), A74MedidaRin);
            AV48xml.WriteElement(context.GetMessage( "td", "")+AV50tdNum, StringUtil.Str( (decimal)(A78FacturaMedidaCantidad), 4, 0));
            AV48xml.WriteElement(context.GetMessage( "td", "")+AV51tdMon, StringUtil.Str( (decimal)(AV17BonoUnitario), 12, 0));
            AV48xml.WriteElement(context.GetMessage( "td", "")+AV51tdMon, StringUtil.Str( (decimal)(AV18BonoTotal), 12, 0));
            AV48xml.WriteElement(context.GetMessage( "td", "")+AV51tdMon, StringUtil.Str( A79FacturaMedidaPrecio, 10, 2));
            AV48xml.WriteEndElement();
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV48xml.WriteEndElement();
         AV48xml.Close();
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
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
         AV45HttpResponse = new GxHttpResponse( context);
         AV48xml = new GXXMLWriter(context.GetPhysicalPath());
         AV50tdNum = "";
         AV51tdMon = "";
         AV46tdDate = "";
         AV52tdText = "";
         AV43ColorEnProceso = "";
         AV42ColorAprobada = "";
         AV57Colorrechazada = "";
         AV44ColorCancelada = "";
         A73FacturaFechaFactura = DateTime.MinValue;
         A80FacturaEstatus = "";
         A71FacturaNo = "";
         P004D2_A19MotivoRechazoID = new int[1] ;
         P004D2_A4CiudadID = new int[1] ;
         P004D2_n4CiudadID = new bool[] {false} ;
         P004D2_A1EstadoID = new int[1] ;
         P004D2_A26MedidaID = new int[1] ;
         P004D2_A93FacturaCompleta = new bool[] {false} ;
         P004D2_A71FacturaNo = new string[] {""} ;
         P004D2_A41PromocionID = new int[1] ;
         P004D2_A80FacturaEstatus = new string[] {""} ;
         P004D2_A29UsuarioID = new int[1] ;
         P004D2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P004D2_A22ModeloID = new int[1] ;
         P004D2_A78FacturaMedidaCantidad = new short[1] ;
         P004D2_A69FacturaID = new int[1] ;
         P004D2_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P004D2_A42PromocionDescripcion = new string[] {""} ;
         P004D2_A20MotivoRechazoDescripcion = new string[] {""} ;
         P004D2_A63UsuarioZona = new string[] {""} ;
         P004D2_A2EstadoDescripcion = new string[] {""} ;
         P004D2_A5CiudadDescripcion = new string[] {""} ;
         P004D2_A53UsuarioGenero = new string[] {""} ;
         P004D2_A23ModeloDescripcion = new string[] {""} ;
         P004D2_A28MedidaDescripcion = new string[] {""} ;
         P004D2_A27MedidaCodigo = new string[] {""} ;
         P004D2_A74MedidaRin = new string[] {""} ;
         P004D2_A79FacturaMedidaPrecio = new decimal[1] ;
         P004D2_A51UsuarioApellido = new string[] {""} ;
         P004D2_A30UsuarioNombre = new string[] {""} ;
         P004D2_A77FacturaMedidaID = new int[1] ;
         A72FacturaFechaRegistro = DateTime.MinValue;
         A42PromocionDescripcion = "";
         A20MotivoRechazoDescripcion = "";
         A63UsuarioZona = "";
         A2EstadoDescripcion = "";
         A5CiudadDescripcion = "";
         A53UsuarioGenero = "";
         A23ModeloDescripcion = "";
         A28MedidaDescripcion = "";
         A27MedidaCodigo = "";
         A74MedidaRin = "";
         A51UsuarioApellido = "";
         A30UsuarioNombre = "";
         A52UsuarioNombreCompleto = "";
         AV15DistribuidorDescripcion = "";
         P004D3_A10DistribuidorID = new int[1] ;
         P004D3_A29UsuarioID = new int[1] ;
         P004D3_A11DistribuidorDescripcion = new string[] {""} ;
         P004D3_A81DistribuidoresUsuarioID = new int[1] ;
         A11DistribuidorDescripcion = "";
         P004D4_A22ModeloID = new int[1] ;
         P004D4_A41PromocionID = new int[1] ;
         P004D4_A49PromocionModeloPrecio = new decimal[1] ;
         P004D4_A48PromocionModeloID = new int[1] ;
         AV56RowStyle = "";
         AV47tdEstatus = "";
         AV53tdMotivo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aexportfacturasigualqueejemploxml__default(),
            new Object[][] {
                new Object[] {
               P004D2_A19MotivoRechazoID, P004D2_A4CiudadID, P004D2_n4CiudadID, P004D2_A1EstadoID, P004D2_A26MedidaID, P004D2_A93FacturaCompleta, P004D2_A71FacturaNo, P004D2_A41PromocionID, P004D2_A80FacturaEstatus, P004D2_A29UsuarioID,
               P004D2_A73FacturaFechaFactura, P004D2_A22ModeloID, P004D2_A78FacturaMedidaCantidad, P004D2_A69FacturaID, P004D2_A72FacturaFechaRegistro, P004D2_A42PromocionDescripcion, P004D2_A20MotivoRechazoDescripcion, P004D2_A63UsuarioZona, P004D2_A2EstadoDescripcion, P004D2_A5CiudadDescripcion,
               P004D2_A53UsuarioGenero, P004D2_A23ModeloDescripcion, P004D2_A28MedidaDescripcion, P004D2_A27MedidaCodigo, P004D2_A74MedidaRin, P004D2_A79FacturaMedidaPrecio, P004D2_A51UsuarioApellido, P004D2_A30UsuarioNombre, P004D2_A77FacturaMedidaID
               }
               , new Object[] {
               P004D3_A10DistribuidorID, P004D3_A29UsuarioID, P004D3_A11DistribuidorDescripcion, P004D3_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               P004D4_A22ModeloID, P004D4_A41PromocionID, P004D4_A49PromocionModeloPrecio, P004D4_A48PromocionModeloID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GxWebError ;
      private short nGotPars ;
      private short A78FacturaMedidaCantidad ;
      private int AV39UsuariosFiltro_Count ;
      private int AV16PromocionID_Count ;
      private int A29UsuarioID ;
      private int A41PromocionID ;
      private int A19MotivoRechazoID ;
      private int A4CiudadID ;
      private int A1EstadoID ;
      private int A26MedidaID ;
      private int A22ModeloID ;
      private int A69FacturaID ;
      private int A77FacturaMedidaID ;
      private int AV37TempPromocionID ;
      private int AV38TempModeloID ;
      private int AV40TempUsuarioID ;
      private int A10DistribuidorID ;
      private int A81DistribuidoresUsuarioID ;
      private int A48PromocionModeloID ;
      private long AV23Consecutivo ;
      private long AV17BonoUnitario ;
      private long AV18BonoTotal ;
      private decimal A79FacturaMedidaPrecio ;
      private decimal A49PromocionModeloPrecio ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV36FacturaNo ;
      private string AV20FacturaEstatus ;
      private string AV43ColorEnProceso ;
      private string AV42ColorAprobada ;
      private string AV57Colorrechazada ;
      private string AV44ColorCancelada ;
      private string A80FacturaEstatus ;
      private string A71FacturaNo ;
      private string A63UsuarioZona ;
      private string A53UsuarioGenero ;
      private string A27MedidaCodigo ;
      private string A74MedidaRin ;
      private string A51UsuarioApellido ;
      private string A30UsuarioNombre ;
      private DateTime AV34FromDate ;
      private DateTime AV35ToDate ;
      private DateTime A73FacturaFechaFactura ;
      private DateTime A72FacturaFechaRegistro ;
      private bool entryPointCalled ;
      private bool AV49FilaPar ;
      private bool A93FacturaCompleta ;
      private bool n4CiudadID ;
      private string AV50tdNum ;
      private string AV51tdMon ;
      private string AV46tdDate ;
      private string AV52tdText ;
      private string A42PromocionDescripcion ;
      private string A20MotivoRechazoDescripcion ;
      private string A2EstadoDescripcion ;
      private string A5CiudadDescripcion ;
      private string A23ModeloDescripcion ;
      private string A28MedidaDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string AV15DistribuidorDescripcion ;
      private string A11DistribuidorDescripcion ;
      private string AV56RowStyle ;
      private string AV47tdEstatus ;
      private string AV53tdMotivo ;
      private GXXMLWriter AV48xml ;
      private GxHttpResponse AV45HttpResponse ;
      private GxSimpleCollection<int> AV39UsuariosFiltro ;
      private GxSimpleCollection<int> AV16PromocionID ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P004D2_A19MotivoRechazoID ;
      private int[] P004D2_A4CiudadID ;
      private bool[] P004D2_n4CiudadID ;
      private int[] P004D2_A1EstadoID ;
      private int[] P004D2_A26MedidaID ;
      private bool[] P004D2_A93FacturaCompleta ;
      private string[] P004D2_A71FacturaNo ;
      private int[] P004D2_A41PromocionID ;
      private string[] P004D2_A80FacturaEstatus ;
      private int[] P004D2_A29UsuarioID ;
      private DateTime[] P004D2_A73FacturaFechaFactura ;
      private int[] P004D2_A22ModeloID ;
      private short[] P004D2_A78FacturaMedidaCantidad ;
      private int[] P004D2_A69FacturaID ;
      private DateTime[] P004D2_A72FacturaFechaRegistro ;
      private string[] P004D2_A42PromocionDescripcion ;
      private string[] P004D2_A20MotivoRechazoDescripcion ;
      private string[] P004D2_A63UsuarioZona ;
      private string[] P004D2_A2EstadoDescripcion ;
      private string[] P004D2_A5CiudadDescripcion ;
      private string[] P004D2_A53UsuarioGenero ;
      private string[] P004D2_A23ModeloDescripcion ;
      private string[] P004D2_A28MedidaDescripcion ;
      private string[] P004D2_A27MedidaCodigo ;
      private string[] P004D2_A74MedidaRin ;
      private decimal[] P004D2_A79FacturaMedidaPrecio ;
      private string[] P004D2_A51UsuarioApellido ;
      private string[] P004D2_A30UsuarioNombre ;
      private int[] P004D2_A77FacturaMedidaID ;
      private int[] P004D3_A10DistribuidorID ;
      private int[] P004D3_A29UsuarioID ;
      private string[] P004D3_A11DistribuidorDescripcion ;
      private int[] P004D3_A81DistribuidoresUsuarioID ;
      private int[] P004D4_A22ModeloID ;
      private int[] P004D4_A41PromocionID ;
      private decimal[] P004D4_A49PromocionModeloPrecio ;
      private int[] P004D4_A48PromocionModeloID ;
   }

   public class aexportfacturasigualqueejemploxml__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004D2( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV39UsuariosFiltro ,
                                             int A41PromocionID ,
                                             GxSimpleCollection<int> AV16PromocionID ,
                                             DateTime AV34FromDate ,
                                             DateTime AV35ToDate ,
                                             int AV39UsuariosFiltro_Count ,
                                             string AV20FacturaEstatus ,
                                             int AV16PromocionID_Count ,
                                             string AV36FacturaNo ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             string A71FacturaNo ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T4.`MotivoRechazoID`, T7.`CiudadID`, T8.`EstadoID`, T1.`MedidaID`, T4.`FacturaCompleta`, T4.`FacturaNo`, T4.`PromocionID`, T4.`FacturaEstatus`, T4.`UsuarioID`, T4.`FacturaFechaFactura`, T2.`ModeloID`, T1.`FacturaMedidaCantidad`, T1.`FacturaID`, T4.`FacturaFechaRegistro`, T6.`PromocionDescripcion`, T5.`MotivoRechazoDescripcion`, T7.`UsuarioZona`, T9.`EstadoDescripcion`, T8.`CiudadDescripcion`, T7.`UsuarioGenero`, T3.`ModeloDescripcion`, T2.`MedidaDescripcion`, T2.`MedidaCodigo`, T2.`MedidaRin`, T1.`FacturaMedidaPrecio`, T7.`UsuarioApellido`, T7.`UsuarioNombre`, T1.`FacturaMedidaID` FROM ((((((((`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T3 ON T3.`ModeloID` = T2.`ModeloID`) INNER JOIN `Factura` T4 ON T4.`FacturaID` = T1.`FacturaID`) INNER JOIN `MotivoRechazo` T5 ON T5.`MotivoRechazoID` = T4.`MotivoRechazoID`) INNER JOIN `Promocion` T6 ON T6.`PromocionID` = T4.`PromocionID`) INNER JOIN `Usuario` T7 ON T7.`UsuarioID` = T4.`UsuarioID`) LEFT JOIN `Ciudad` T8 ON T8.`CiudadID` = T7.`CiudadID`) LEFT JOIN `Estado` T9 ON T9.`EstadoID` = T8.`EstadoID`)";
         AddWhere(sWhereString, "(T4.`FacturaCompleta` = 1)");
         if ( ! (DateTime.MinValue==AV34FromDate) )
         {
            AddWhere(sWhereString, "(T4.`FacturaFechaFactura` >= @AV34FromDate)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV35ToDate) )
         {
            AddWhere(sWhereString, "(T4.`FacturaFechaFactura` <= @AV35ToDate)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV39UsuariosFiltro_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV39UsuariosFiltro, "T4.`UsuarioID` IN (", ")")+")");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20FacturaEstatus)) )
         {
            AddWhere(sWhereString, "(T4.`FacturaEstatus` = @AV20FacturaEstatus)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV16PromocionID_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV16PromocionID, "T4.`PromocionID` IN (", ")")+")");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36FacturaNo)) )
         {
            AddWhere(sWhereString, "(T4.`FacturaNo` = @AV36FacturaNo)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`FacturaMedidaID`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004D2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (GxSimpleCollection<int>)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP004D3;
          prmP004D3 = new Object[] {
          new ParDef("@AV40TempUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmP004D4;
          prmP004D4 = new Object[] {
          new ParDef("@AV37TempPromocionID",GXType.Int32,9,0) ,
          new ParDef("@AV38TempModeloID",GXType.Int32,9,0)
          };
          Object[] prmP004D2;
          prmP004D2 = new Object[] {
          new ParDef("@AV34FromDate",GXType.Date,8,0) ,
          new ParDef("@AV35ToDate",GXType.Date,8,0) ,
          new ParDef("@AV20FacturaEstatus",GXType.Char,20,0) ,
          new ParDef("@AV36FacturaNo",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004D2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004D3", "SELECT T1.`DistribuidorID`, T1.`UsuarioID`, T2.`DistribuidorDescripcion`, T1.`DistribuidoresUsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Distribuidor` T2 ON T2.`DistribuidorID` = T1.`DistribuidorID`) WHERE T1.`UsuarioID` = @AV40TempUsuarioID ORDER BY T1.`UsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004D3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P004D4", "SELECT `ModeloID`, `PromocionID`, `PromocionModeloPrecio`, `PromocionModeloID` FROM `PromocionModelo` WHERE `PromocionID` = @AV37TempPromocionID and `ModeloID` = @AV38TempModeloID ORDER BY `PromocionID`, `ModeloID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004D4,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[5])[0] = rslt.getBool(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((short[]) buf[12])[0] = rslt.getShort(12);
                ((int[]) buf[13])[0] = rslt.getInt(13);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(14);
                ((string[]) buf[15])[0] = rslt.getVarchar(15);
                ((string[]) buf[16])[0] = rslt.getVarchar(16);
                ((string[]) buf[17])[0] = rslt.getString(17, 30);
                ((string[]) buf[18])[0] = rslt.getVarchar(18);
                ((string[]) buf[19])[0] = rslt.getVarchar(19);
                ((string[]) buf[20])[0] = rslt.getString(20, 20);
                ((string[]) buf[21])[0] = rslt.getVarchar(21);
                ((string[]) buf[22])[0] = rslt.getVarchar(22);
                ((string[]) buf[23])[0] = rslt.getString(23, 20);
                ((string[]) buf[24])[0] = rslt.getString(24, 20);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(25);
                ((string[]) buf[26])[0] = rslt.getString(26, 50);
                ((string[]) buf[27])[0] = rslt.getString(27, 50);
                ((int[]) buf[28])[0] = rslt.getInt(28);
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
