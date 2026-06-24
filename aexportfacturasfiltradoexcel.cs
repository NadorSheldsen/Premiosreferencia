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
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aexportfacturasfiltradoexcel : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aexportfacturasfiltradoexcel().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

      public aexportfacturasfiltradoexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aexportfacturasfiltradoexcel( IGxContext context )
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
                           string aP5_FacturaEstatus ,
                           out string aP6_ExcelFilename )
      {
         this.AV34FromDate = aP0_FromDate;
         this.AV35ToDate = aP1_ToDate;
         this.AV39UsuariosFiltro = aP2_UsuariosFiltro;
         this.AV16PromocionID = aP3_PromocionID;
         this.AV36FacturaNo = aP4_FacturaNo;
         this.AV20FacturaEstatus = aP5_FacturaEstatus;
         this.AV10ExcelFilename = "" ;
         initialize();
         ExecuteImpl();
         aP6_ExcelFilename=this.AV10ExcelFilename;
      }

      public string executeUdp( DateTime aP0_FromDate ,
                                DateTime aP1_ToDate ,
                                GxSimpleCollection<int> aP2_UsuariosFiltro ,
                                GxSimpleCollection<int> aP3_PromocionID ,
                                string aP4_FacturaNo ,
                                string aP5_FacturaEstatus )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_UsuariosFiltro, aP3_PromocionID, aP4_FacturaNo, aP5_FacturaEstatus, out aP6_ExcelFilename);
         return AV10ExcelFilename ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<int> aP2_UsuariosFiltro ,
                                 GxSimpleCollection<int> aP3_PromocionID ,
                                 string aP4_FacturaNo ,
                                 string aP5_FacturaEstatus ,
                                 out string aP6_ExcelFilename )
      {
         this.AV34FromDate = aP0_FromDate;
         this.AV35ToDate = aP1_ToDate;
         this.AV39UsuariosFiltro = aP2_UsuariosFiltro;
         this.AV16PromocionID = aP3_PromocionID;
         this.AV36FacturaNo = aP4_FacturaNo;
         this.AV20FacturaEstatus = aP5_FacturaEstatus;
         this.AV10ExcelFilename = "" ;
         SubmitImpl();
         aP6_ExcelFilename=this.AV10ExcelFilename;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV11FileName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV11FileName = GXt_char1 + "ListadoDeFacturas.xlsx";
         AV9ExcelDocument.Open(AV11FileName);
         AV9ExcelDocument.Clear();
         AV9ExcelDocument.AutoFit = 1;
         AV8CellRow = 1;
         AV9ExcelDocument.get_Cells(AV8CellRow, 1, 1, 1).Text = "#";
         AV9ExcelDocument.get_Cells(AV8CellRow, 2, 1, 1).Text = context.GetMessage( "FOLIO #", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 3, 1, 1).Text = context.GetMessage( "FECHA REGISTRO", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 4, 1, 1).Text = context.GetMessage( "PROMOCIÓN", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 5, 1, 1).Text = context.GetMessage( "FECHA FACTURA", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 6, 1, 1).Text = context.GetMessage( "NO. FACTURA", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 7, 1, 1).Text = context.GetMessage( "ESTATUS", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 8, 1, 1).Text = context.GetMessage( "MOTIVO DE RECHAZO", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 9, 1, 1).Text = context.GetMessage( "DISTRIBUIDOR", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 10, 1, 1).Text = context.GetMessage( "ZONA", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 11, 1, 1).Text = context.GetMessage( "ESTADO", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 12, 1, 1).Text = context.GetMessage( "CIUDAD", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 13, 1, 1).Text = context.GetMessage( "VENDEDOR", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 14, 1, 1).Text = context.GetMessage( "No de Cuenta Broxel", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 15, 1, 1).Text = context.GetMessage( "Referencia Broxel", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 16, 1, 1).Text = context.GetMessage( "GÉNERO", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 17, 1, 1).Text = context.GetMessage( "MODELO", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 18, 1, 1).Text = context.GetMessage( "MEDIDA", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 19, 1, 1).Text = context.GetMessage( "CÓDIGO", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 20, 1, 1).Text = context.GetMessage( "RIN", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 21, 1, 1).Text = context.GetMessage( "CANTIDAD", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 22, 1, 1).Text = context.GetMessage( "BONO UNITARIO", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 23, 1, 1).Text = context.GetMessage( "BONO TOTAL", "");
         AV9ExcelDocument.get_Cells(AV8CellRow, 24, 1, 1).Text = context.GetMessage( "PRECIO UNITARIO", "");
         AV32i = 1;
         while ( AV32i <= 24 )
         {
            AV9ExcelDocument.get_Cells(AV8CellRow, AV32i, 1, 1).Bold = 1;
            AV32i = (short)(AV32i+1);
         }
         AV41ColorRechazo = GXUtil.RGB( 250, 88, 88);
         AV42ColorAprobada = GXUtil.RGB( 16, 124, 65);
         AV23Consecutivo = 0;
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
         /* Using cursor P004B2 */
         pr_default.execute(0, new Object[] {AV34FromDate, AV35ToDate, AV20FacturaEstatus, AV36FacturaNo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A19MotivoRechazoID = P004B2_A19MotivoRechazoID[0];
            A4CiudadID = P004B2_A4CiudadID[0];
            n4CiudadID = P004B2_n4CiudadID[0];
            A1EstadoID = P004B2_A1EstadoID[0];
            A26MedidaID = P004B2_A26MedidaID[0];
            A93FacturaCompleta = P004B2_A93FacturaCompleta[0];
            A71FacturaNo = P004B2_A71FacturaNo[0];
            A41PromocionID = P004B2_A41PromocionID[0];
            A80FacturaEstatus = P004B2_A80FacturaEstatus[0];
            A29UsuarioID = P004B2_A29UsuarioID[0];
            A73FacturaFechaFactura = P004B2_A73FacturaFechaFactura[0];
            A22ModeloID = P004B2_A22ModeloID[0];
            A78FacturaMedidaCantidad = P004B2_A78FacturaMedidaCantidad[0];
            A69FacturaID = P004B2_A69FacturaID[0];
            A72FacturaFechaRegistro = P004B2_A72FacturaFechaRegistro[0];
            A42PromocionDescripcion = P004B2_A42PromocionDescripcion[0];
            A20MotivoRechazoDescripcion = P004B2_A20MotivoRechazoDescripcion[0];
            A63UsuarioZona = P004B2_A63UsuarioZona[0];
            A2EstadoDescripcion = P004B2_A2EstadoDescripcion[0];
            A5CiudadDescripcion = P004B2_A5CiudadDescripcion[0];
            A82UsuarioNoCuentaBROXEL = P004B2_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = P004B2_A83UsuarioReferenciaBROXEL[0];
            A53UsuarioGenero = P004B2_A53UsuarioGenero[0];
            A23ModeloDescripcion = P004B2_A23ModeloDescripcion[0];
            A28MedidaDescripcion = P004B2_A28MedidaDescripcion[0];
            A27MedidaCodigo = P004B2_A27MedidaCodigo[0];
            A74MedidaRin = P004B2_A74MedidaRin[0];
            A79FacturaMedidaPrecio = P004B2_A79FacturaMedidaPrecio[0];
            A51UsuarioApellido = P004B2_A51UsuarioApellido[0];
            A30UsuarioNombre = P004B2_A30UsuarioNombre[0];
            A77FacturaMedidaID = P004B2_A77FacturaMedidaID[0];
            A22ModeloID = P004B2_A22ModeloID[0];
            A28MedidaDescripcion = P004B2_A28MedidaDescripcion[0];
            A27MedidaCodigo = P004B2_A27MedidaCodigo[0];
            A74MedidaRin = P004B2_A74MedidaRin[0];
            A23ModeloDescripcion = P004B2_A23ModeloDescripcion[0];
            A19MotivoRechazoID = P004B2_A19MotivoRechazoID[0];
            A93FacturaCompleta = P004B2_A93FacturaCompleta[0];
            A71FacturaNo = P004B2_A71FacturaNo[0];
            A41PromocionID = P004B2_A41PromocionID[0];
            A80FacturaEstatus = P004B2_A80FacturaEstatus[0];
            A29UsuarioID = P004B2_A29UsuarioID[0];
            A73FacturaFechaFactura = P004B2_A73FacturaFechaFactura[0];
            A72FacturaFechaRegistro = P004B2_A72FacturaFechaRegistro[0];
            A20MotivoRechazoDescripcion = P004B2_A20MotivoRechazoDescripcion[0];
            A42PromocionDescripcion = P004B2_A42PromocionDescripcion[0];
            A4CiudadID = P004B2_A4CiudadID[0];
            n4CiudadID = P004B2_n4CiudadID[0];
            A63UsuarioZona = P004B2_A63UsuarioZona[0];
            A82UsuarioNoCuentaBROXEL = P004B2_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = P004B2_A83UsuarioReferenciaBROXEL[0];
            A53UsuarioGenero = P004B2_A53UsuarioGenero[0];
            A51UsuarioApellido = P004B2_A51UsuarioApellido[0];
            A30UsuarioNombre = P004B2_A30UsuarioNombre[0];
            A1EstadoID = P004B2_A1EstadoID[0];
            A5CiudadDescripcion = P004B2_A5CiudadDescripcion[0];
            A2EstadoDescripcion = P004B2_A2EstadoDescripcion[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AV23Consecutivo = (long)(AV23Consecutivo+1);
            AV37TempPromocionID = A41PromocionID;
            AV38TempModeloID = A22ModeloID;
            AV40TempUsuarioID = A29UsuarioID;
            AV15DistribuidorDescripcion = "";
            /* Using cursor P004B3 */
            pr_default.execute(1, new Object[] {AV40TempUsuarioID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A10DistribuidorID = P004B3_A10DistribuidorID[0];
               A29UsuarioID = P004B3_A29UsuarioID[0];
               A11DistribuidorDescripcion = P004B3_A11DistribuidorDescripcion[0];
               A81DistribuidoresUsuarioID = P004B3_A81DistribuidoresUsuarioID[0];
               A11DistribuidorDescripcion = P004B3_A11DistribuidorDescripcion[0];
               AV15DistribuidorDescripcion = A11DistribuidorDescripcion;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV17BonoUnitario = 0;
            /* Using cursor P004B4 */
            pr_default.execute(2, new Object[] {AV37TempPromocionID, AV38TempModeloID});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A22ModeloID = P004B4_A22ModeloID[0];
               A41PromocionID = P004B4_A41PromocionID[0];
               A49PromocionModeloPrecio = P004B4_A49PromocionModeloPrecio[0];
               A48PromocionModeloID = P004B4_A48PromocionModeloID[0];
               AV17BonoUnitario = A49PromocionModeloPrecio;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV18BonoTotal = (decimal)(AV17BonoUnitario*A78FacturaMedidaCantidad);
            AV8CellRow = (short)(AV8CellRow+1);
            AV9ExcelDocument.get_Cells(AV8CellRow, 1, 1, 1).Number = AV23Consecutivo;
            AV9ExcelDocument.get_Cells(AV8CellRow, 2, 1, 1).Text = StringUtil.Trim( StringUtil.Str( (decimal)(A69FacturaID), 9, 0));
            GXt_dtime2 = DateTimeUtil.ResetTime( A72FacturaFechaRegistro ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV8CellRow, 3, 1, 1).Date = GXt_dtime2;
            AV9ExcelDocument.get_Cells(AV8CellRow, 4, 1, 1).Text = A42PromocionDescripcion;
            GXt_dtime2 = DateTimeUtil.ResetTime( A73FacturaFechaFactura ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV8CellRow, 5, 1, 1).Date = GXt_dtime2;
            AV9ExcelDocument.get_Cells(AV8CellRow, 6, 1, 1).Text = A71FacturaNo;
            if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
            {
               AV9ExcelDocument.get_Cells(AV8CellRow, 7, 1, 1).Color = AV41ColorRechazo;
               AV9ExcelDocument.get_Cells(AV8CellRow, 8, 1, 1).Color = AV41ColorRechazo;
            }
            else
            {
               AV9ExcelDocument.get_Cells(AV8CellRow, 7, 1, 1).Color = AV42ColorAprobada;
               AV9ExcelDocument.get_Cells(AV8CellRow, 8, 1, 1).Color = AV42ColorAprobada;
            }
            AV9ExcelDocument.get_Cells(AV8CellRow, 7, 1, 1).Text = A80FacturaEstatus;
            AV9ExcelDocument.get_Cells(AV8CellRow, 8, 1, 1).Text = A20MotivoRechazoDescripcion;
            AV9ExcelDocument.get_Cells(AV8CellRow, 9, 1, 1).Text = AV15DistribuidorDescripcion;
            AV9ExcelDocument.get_Cells(AV8CellRow, 10, 1, 1).Text = A63UsuarioZona;
            AV9ExcelDocument.get_Cells(AV8CellRow, 11, 1, 1).Text = A2EstadoDescripcion;
            AV9ExcelDocument.get_Cells(AV8CellRow, 12, 1, 1).Text = A5CiudadDescripcion;
            AV9ExcelDocument.get_Cells(AV8CellRow, 13, 1, 1).Text = A52UsuarioNombreCompleto;
            AV9ExcelDocument.get_Cells(AV8CellRow, 14, 1, 1).Text = A82UsuarioNoCuentaBROXEL;
            AV9ExcelDocument.get_Cells(AV8CellRow, 15, 1, 1).Text = A83UsuarioReferenciaBROXEL;
            AV9ExcelDocument.get_Cells(AV8CellRow, 16, 1, 1).Text = A53UsuarioGenero;
            AV9ExcelDocument.get_Cells(AV8CellRow, 17, 1, 1).Text = A23ModeloDescripcion;
            AV9ExcelDocument.get_Cells(AV8CellRow, 18, 1, 1).Text = A28MedidaDescripcion;
            AV9ExcelDocument.get_Cells(AV8CellRow, 19, 1, 1).Text = A27MedidaCodigo;
            AV9ExcelDocument.get_Cells(AV8CellRow, 20, 1, 1).Text = A74MedidaRin;
            AV9ExcelDocument.get_Cells(AV8CellRow, 21, 1, 1).Number = A78FacturaMedidaCantidad;
            AV9ExcelDocument.get_Cells(AV8CellRow, 22, 1, 1).Number = (double)(AV17BonoUnitario);
            AV9ExcelDocument.get_Cells(AV8CellRow, 23, 1, 1).Number = (double)(AV18BonoTotal);
            AV9ExcelDocument.get_Cells(AV8CellRow, 24, 1, 1).Number = (double)(A79FacturaMedidaPrecio);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV9ExcelDocument.AutoFit = 1;
         AV9ExcelDocument.Save();
         AV9ExcelDocument.Close();
         AV12Session.Set(context.GetMessage( "WWPExportFilePath", ""), AV11FileName);
         AV12Session.Set(context.GetMessage( "WWPExportFileName", ""), "ListadoDeFacturas.xlsx");
         AV10ExcelFilename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10ExcelFilename = "";
         AV11FileName = "";
         GXt_char1 = "";
         AV9ExcelDocument = new ExcelDocumentI();
         A73FacturaFechaFactura = DateTime.MinValue;
         A80FacturaEstatus = "";
         A71FacturaNo = "";
         P004B2_A19MotivoRechazoID = new int[1] ;
         P004B2_A4CiudadID = new int[1] ;
         P004B2_n4CiudadID = new bool[] {false} ;
         P004B2_A1EstadoID = new int[1] ;
         P004B2_A26MedidaID = new int[1] ;
         P004B2_A93FacturaCompleta = new bool[] {false} ;
         P004B2_A71FacturaNo = new string[] {""} ;
         P004B2_A41PromocionID = new int[1] ;
         P004B2_A80FacturaEstatus = new string[] {""} ;
         P004B2_A29UsuarioID = new int[1] ;
         P004B2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P004B2_A22ModeloID = new int[1] ;
         P004B2_A78FacturaMedidaCantidad = new short[1] ;
         P004B2_A69FacturaID = new int[1] ;
         P004B2_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P004B2_A42PromocionDescripcion = new string[] {""} ;
         P004B2_A20MotivoRechazoDescripcion = new string[] {""} ;
         P004B2_A63UsuarioZona = new string[] {""} ;
         P004B2_A2EstadoDescripcion = new string[] {""} ;
         P004B2_A5CiudadDescripcion = new string[] {""} ;
         P004B2_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         P004B2_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         P004B2_A53UsuarioGenero = new string[] {""} ;
         P004B2_A23ModeloDescripcion = new string[] {""} ;
         P004B2_A28MedidaDescripcion = new string[] {""} ;
         P004B2_A27MedidaCodigo = new string[] {""} ;
         P004B2_A74MedidaRin = new string[] {""} ;
         P004B2_A79FacturaMedidaPrecio = new decimal[1] ;
         P004B2_A51UsuarioApellido = new string[] {""} ;
         P004B2_A30UsuarioNombre = new string[] {""} ;
         P004B2_A77FacturaMedidaID = new int[1] ;
         A72FacturaFechaRegistro = DateTime.MinValue;
         A42PromocionDescripcion = "";
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
         AV15DistribuidorDescripcion = "";
         P004B3_A10DistribuidorID = new int[1] ;
         P004B3_A29UsuarioID = new int[1] ;
         P004B3_A11DistribuidorDescripcion = new string[] {""} ;
         P004B3_A81DistribuidoresUsuarioID = new int[1] ;
         A11DistribuidorDescripcion = "";
         P004B4_A22ModeloID = new int[1] ;
         P004B4_A41PromocionID = new int[1] ;
         P004B4_A49PromocionModeloPrecio = new decimal[1] ;
         P004B4_A48PromocionModeloID = new int[1] ;
         GXt_dtime2 = (DateTime)(DateTime.MinValue);
         AV12Session = context.GetSession();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aexportfacturasfiltradoexcel__default(),
            new Object[][] {
                new Object[] {
               P004B2_A19MotivoRechazoID, P004B2_A4CiudadID, P004B2_n4CiudadID, P004B2_A1EstadoID, P004B2_A26MedidaID, P004B2_A93FacturaCompleta, P004B2_A71FacturaNo, P004B2_A41PromocionID, P004B2_A80FacturaEstatus, P004B2_A29UsuarioID,
               P004B2_A73FacturaFechaFactura, P004B2_A22ModeloID, P004B2_A78FacturaMedidaCantidad, P004B2_A69FacturaID, P004B2_A72FacturaFechaRegistro, P004B2_A42PromocionDescripcion, P004B2_A20MotivoRechazoDescripcion, P004B2_A63UsuarioZona, P004B2_A2EstadoDescripcion, P004B2_A5CiudadDescripcion,
               P004B2_A82UsuarioNoCuentaBROXEL, P004B2_A83UsuarioReferenciaBROXEL, P004B2_A53UsuarioGenero, P004B2_A23ModeloDescripcion, P004B2_A28MedidaDescripcion, P004B2_A27MedidaCodigo, P004B2_A74MedidaRin, P004B2_A79FacturaMedidaPrecio, P004B2_A51UsuarioApellido, P004B2_A30UsuarioNombre,
               P004B2_A77FacturaMedidaID
               }
               , new Object[] {
               P004B3_A10DistribuidorID, P004B3_A29UsuarioID, P004B3_A11DistribuidorDescripcion, P004B3_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               P004B4_A22ModeloID, P004B4_A41PromocionID, P004B4_A49PromocionModeloPrecio, P004B4_A48PromocionModeloID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8CellRow ;
      private short AV32i ;
      private short A78FacturaMedidaCantidad ;
      private int AV41ColorRechazo ;
      private int AV42ColorAprobada ;
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
      private decimal A79FacturaMedidaPrecio ;
      private decimal AV17BonoUnitario ;
      private decimal A49PromocionModeloPrecio ;
      private decimal AV18BonoTotal ;
      private string AV36FacturaNo ;
      private string AV20FacturaEstatus ;
      private string GXt_char1 ;
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
      private DateTime GXt_dtime2 ;
      private DateTime AV34FromDate ;
      private DateTime AV35ToDate ;
      private DateTime A73FacturaFechaFactura ;
      private DateTime A72FacturaFechaRegistro ;
      private bool A93FacturaCompleta ;
      private bool n4CiudadID ;
      private string AV10ExcelFilename ;
      private string AV11FileName ;
      private string A42PromocionDescripcion ;
      private string A20MotivoRechazoDescripcion ;
      private string A2EstadoDescripcion ;
      private string A5CiudadDescripcion ;
      private string A23ModeloDescripcion ;
      private string A28MedidaDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string AV15DistribuidorDescripcion ;
      private string A11DistribuidorDescripcion ;
      private IGxSession AV12Session ;
      private ExcelDocumentI AV9ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<int> AV39UsuariosFiltro ;
      private GxSimpleCollection<int> AV16PromocionID ;
      private IDataStoreProvider pr_default ;
      private int[] P004B2_A19MotivoRechazoID ;
      private int[] P004B2_A4CiudadID ;
      private bool[] P004B2_n4CiudadID ;
      private int[] P004B2_A1EstadoID ;
      private int[] P004B2_A26MedidaID ;
      private bool[] P004B2_A93FacturaCompleta ;
      private string[] P004B2_A71FacturaNo ;
      private int[] P004B2_A41PromocionID ;
      private string[] P004B2_A80FacturaEstatus ;
      private int[] P004B2_A29UsuarioID ;
      private DateTime[] P004B2_A73FacturaFechaFactura ;
      private int[] P004B2_A22ModeloID ;
      private short[] P004B2_A78FacturaMedidaCantidad ;
      private int[] P004B2_A69FacturaID ;
      private DateTime[] P004B2_A72FacturaFechaRegistro ;
      private string[] P004B2_A42PromocionDescripcion ;
      private string[] P004B2_A20MotivoRechazoDescripcion ;
      private string[] P004B2_A63UsuarioZona ;
      private string[] P004B2_A2EstadoDescripcion ;
      private string[] P004B2_A5CiudadDescripcion ;
      private string[] P004B2_A82UsuarioNoCuentaBROXEL ;
      private string[] P004B2_A83UsuarioReferenciaBROXEL ;
      private string[] P004B2_A53UsuarioGenero ;
      private string[] P004B2_A23ModeloDescripcion ;
      private string[] P004B2_A28MedidaDescripcion ;
      private string[] P004B2_A27MedidaCodigo ;
      private string[] P004B2_A74MedidaRin ;
      private decimal[] P004B2_A79FacturaMedidaPrecio ;
      private string[] P004B2_A51UsuarioApellido ;
      private string[] P004B2_A30UsuarioNombre ;
      private int[] P004B2_A77FacturaMedidaID ;
      private int[] P004B3_A10DistribuidorID ;
      private int[] P004B3_A29UsuarioID ;
      private string[] P004B3_A11DistribuidorDescripcion ;
      private int[] P004B3_A81DistribuidoresUsuarioID ;
      private int[] P004B4_A22ModeloID ;
      private int[] P004B4_A41PromocionID ;
      private decimal[] P004B4_A49PromocionModeloPrecio ;
      private int[] P004B4_A48PromocionModeloID ;
      private string aP6_ExcelFilename ;
   }

   public class aexportfacturasfiltradoexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004B2( IGxContext context ,
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
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T4.`MotivoRechazoID`, T7.`CiudadID`, T8.`EstadoID`, T1.`MedidaID`, T4.`FacturaCompleta`, T4.`FacturaNo`, T4.`PromocionID`, T4.`FacturaEstatus`, T4.`UsuarioID`, T4.`FacturaFechaFactura`, T2.`ModeloID`, T1.`FacturaMedidaCantidad`, T1.`FacturaID`, T4.`FacturaFechaRegistro`, T6.`PromocionDescripcion`, T5.`MotivoRechazoDescripcion`, T7.`UsuarioZona`, T9.`EstadoDescripcion`, T8.`CiudadDescripcion`, T7.`UsuarioNoCuentaBROXEL`, T7.`UsuarioReferenciaBROXEL`, T7.`UsuarioGenero`, T3.`ModeloDescripcion`, T2.`MedidaDescripcion`, T2.`MedidaCodigo`, T2.`MedidaRin`, T1.`FacturaMedidaPrecio`, T7.`UsuarioApellido`, T7.`UsuarioNombre`, T1.`FacturaMedidaID` FROM ((((((((`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T3 ON T3.`ModeloID` = T2.`ModeloID`) INNER JOIN `Factura` T4 ON T4.`FacturaID` = T1.`FacturaID`) INNER JOIN `MotivoRechazo` T5 ON T5.`MotivoRechazoID` = T4.`MotivoRechazoID`) INNER JOIN `Promocion` T6 ON T6.`PromocionID` = T4.`PromocionID`) INNER JOIN `Usuario` T7 ON T7.`UsuarioID` = T4.`UsuarioID`) LEFT JOIN `Ciudad` T8 ON T8.`CiudadID` = T7.`CiudadID`) LEFT JOIN `Estado` T9 ON T9.`EstadoID` = T8.`EstadoID`)";
         AddWhere(sWhereString, "(T4.`FacturaCompleta` = 1)");
         if ( ! (DateTime.MinValue==AV34FromDate) )
         {
            AddWhere(sWhereString, "(T4.`FacturaFechaFactura` >= @AV34FromDate)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV35ToDate) )
         {
            AddWhere(sWhereString, "(T4.`FacturaFechaFactura` <= @AV35ToDate)");
         }
         else
         {
            GXv_int3[1] = 1;
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
            GXv_int3[2] = 1;
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
            GXv_int3[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`FacturaMedidaID`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004B2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (GxSimpleCollection<int>)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] );
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
          Object[] prmP004B3;
          prmP004B3 = new Object[] {
          new ParDef("@AV40TempUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmP004B4;
          prmP004B4 = new Object[] {
          new ParDef("@AV37TempPromocionID",GXType.Int32,9,0) ,
          new ParDef("@AV38TempModeloID",GXType.Int32,9,0)
          };
          Object[] prmP004B2;
          prmP004B2 = new Object[] {
          new ParDef("@AV34FromDate",GXType.Date,8,0) ,
          new ParDef("@AV35ToDate",GXType.Date,8,0) ,
          new ParDef("@AV20FacturaEstatus",GXType.Char,20,0) ,
          new ParDef("@AV36FacturaNo",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004B2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004B3", "SELECT T1.`DistribuidorID`, T1.`UsuarioID`, T2.`DistribuidorDescripcion`, T1.`DistribuidoresUsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Distribuidor` T2 ON T2.`DistribuidorID` = T1.`DistribuidorID`) WHERE T1.`UsuarioID` = @AV40TempUsuarioID ORDER BY T1.`UsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004B3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P004B4", "SELECT `ModeloID`, `PromocionID`, `PromocionModeloPrecio`, `PromocionModeloID` FROM `PromocionModelo` WHERE `PromocionID` = @AV37TempPromocionID and `ModeloID` = @AV38TempModeloID ORDER BY `PromocionID`, `ModeloID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004B4,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[21])[0] = rslt.getString(21, 20);
                ((string[]) buf[22])[0] = rslt.getString(22, 20);
                ((string[]) buf[23])[0] = rslt.getVarchar(23);
                ((string[]) buf[24])[0] = rslt.getVarchar(24);
                ((string[]) buf[25])[0] = rslt.getString(25, 20);
                ((string[]) buf[26])[0] = rslt.getString(26, 20);
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
