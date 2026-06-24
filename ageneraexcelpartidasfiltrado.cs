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
   public class ageneraexcelpartidasfiltrado : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new ageneraexcelpartidasfiltrado().MainImpl(args); ;
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

      public ageneraexcelpartidasfiltrado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ageneraexcelpartidasfiltrado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PromocionID ,
                           GxSimpleCollection<int> aP1_ListaUsuarioID ,
                           out string aP2_ExcelFilename ,
                           out string aP3_ErrorMessage )
      {
         this.AV16PromocionID = aP0_PromocionID;
         this.AV34ListaUsuarioID = aP1_ListaUsuarioID;
         this.AV10ExcelFilename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP2_ExcelFilename=this.AV10ExcelFilename;
         aP3_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( int aP0_PromocionID ,
                                GxSimpleCollection<int> aP1_ListaUsuarioID ,
                                out string aP2_ExcelFilename )
      {
         execute(aP0_PromocionID, aP1_ListaUsuarioID, out aP2_ExcelFilename, out aP3_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( int aP0_PromocionID ,
                                 GxSimpleCollection<int> aP1_ListaUsuarioID ,
                                 out string aP2_ExcelFilename ,
                                 out string aP3_ErrorMessage )
      {
         this.AV16PromocionID = aP0_PromocionID;
         this.AV34ListaUsuarioID = aP1_ListaUsuarioID;
         this.AV10ExcelFilename = "" ;
         this.AV13ErrorMessage = "" ;
         SubmitImpl();
         aP2_ExcelFilename=this.AV10ExcelFilename;
         aP3_ErrorMessage=this.AV13ErrorMessage;
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
         AV23Consecutivo = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV34ListaUsuarioID ,
                                              A41PromocionID ,
                                              AV16PromocionID ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00402 */
         pr_default.execute(0, new Object[] {AV16PromocionID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A19MotivoRechazoID = P00402_A19MotivoRechazoID[0];
            A4CiudadID = P00402_A4CiudadID[0];
            n4CiudadID = P00402_n4CiudadID[0];
            A1EstadoID = P00402_A1EstadoID[0];
            A26MedidaID = P00402_A26MedidaID[0];
            A93FacturaCompleta = P00402_A93FacturaCompleta[0];
            A29UsuarioID = P00402_A29UsuarioID[0];
            A41PromocionID = P00402_A41PromocionID[0];
            A22ModeloID = P00402_A22ModeloID[0];
            A80FacturaEstatus = P00402_A80FacturaEstatus[0];
            A69FacturaID = P00402_A69FacturaID[0];
            A72FacturaFechaRegistro = P00402_A72FacturaFechaRegistro[0];
            A42PromocionDescripcion = P00402_A42PromocionDescripcion[0];
            A73FacturaFechaFactura = P00402_A73FacturaFechaFactura[0];
            A71FacturaNo = P00402_A71FacturaNo[0];
            A20MotivoRechazoDescripcion = P00402_A20MotivoRechazoDescripcion[0];
            A63UsuarioZona = P00402_A63UsuarioZona[0];
            A2EstadoDescripcion = P00402_A2EstadoDescripcion[0];
            A5CiudadDescripcion = P00402_A5CiudadDescripcion[0];
            A82UsuarioNoCuentaBROXEL = P00402_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = P00402_A83UsuarioReferenciaBROXEL[0];
            A53UsuarioGenero = P00402_A53UsuarioGenero[0];
            A23ModeloDescripcion = P00402_A23ModeloDescripcion[0];
            A28MedidaDescripcion = P00402_A28MedidaDescripcion[0];
            A27MedidaCodigo = P00402_A27MedidaCodigo[0];
            A74MedidaRin = P00402_A74MedidaRin[0];
            A78FacturaMedidaCantidad = P00402_A78FacturaMedidaCantidad[0];
            A79FacturaMedidaPrecio = P00402_A79FacturaMedidaPrecio[0];
            A51UsuarioApellido = P00402_A51UsuarioApellido[0];
            A30UsuarioNombre = P00402_A30UsuarioNombre[0];
            A77FacturaMedidaID = P00402_A77FacturaMedidaID[0];
            A22ModeloID = P00402_A22ModeloID[0];
            A28MedidaDescripcion = P00402_A28MedidaDescripcion[0];
            A27MedidaCodigo = P00402_A27MedidaCodigo[0];
            A74MedidaRin = P00402_A74MedidaRin[0];
            A23ModeloDescripcion = P00402_A23ModeloDescripcion[0];
            A19MotivoRechazoID = P00402_A19MotivoRechazoID[0];
            A93FacturaCompleta = P00402_A93FacturaCompleta[0];
            A29UsuarioID = P00402_A29UsuarioID[0];
            A41PromocionID = P00402_A41PromocionID[0];
            A80FacturaEstatus = P00402_A80FacturaEstatus[0];
            A72FacturaFechaRegistro = P00402_A72FacturaFechaRegistro[0];
            A73FacturaFechaFactura = P00402_A73FacturaFechaFactura[0];
            A71FacturaNo = P00402_A71FacturaNo[0];
            A20MotivoRechazoDescripcion = P00402_A20MotivoRechazoDescripcion[0];
            A4CiudadID = P00402_A4CiudadID[0];
            n4CiudadID = P00402_n4CiudadID[0];
            A63UsuarioZona = P00402_A63UsuarioZona[0];
            A82UsuarioNoCuentaBROXEL = P00402_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = P00402_A83UsuarioReferenciaBROXEL[0];
            A53UsuarioGenero = P00402_A53UsuarioGenero[0];
            A51UsuarioApellido = P00402_A51UsuarioApellido[0];
            A30UsuarioNombre = P00402_A30UsuarioNombre[0];
            A1EstadoID = P00402_A1EstadoID[0];
            A5CiudadDescripcion = P00402_A5CiudadDescripcion[0];
            A2EstadoDescripcion = P00402_A2EstadoDescripcion[0];
            A42PromocionDescripcion = P00402_A42PromocionDescripcion[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            OV20FacturaEstatus = AV20FacturaEstatus;
            AV8CellRow = (short)(AV8CellRow+1);
            AV23Consecutivo = (long)(AV23Consecutivo+1);
            AV14UsuarioID = A29UsuarioID;
            AV19ModeloID = A22ModeloID;
            AV20FacturaEstatus = A80FacturaEstatus;
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
            AV9ExcelDocument.get_Cells(AV8CellRow, 1, 1, 1).Text = StringUtil.Trim( StringUtil.Str( (decimal)(AV23Consecutivo), 10, 0));
            AV9ExcelDocument.get_Cells(AV8CellRow, 2, 1, 1).Text = StringUtil.Trim( StringUtil.Str( (decimal)(A69FacturaID), 9, 0));
            AV9ExcelDocument.get_Cells(AV8CellRow, 3, 1, 1).Text = StringUtil.Trim( context.localUtil.DToC( A72FacturaFechaRegistro, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            AV9ExcelDocument.get_Cells(AV8CellRow, 4, 1, 1).Text = A42PromocionDescripcion;
            AV9ExcelDocument.get_Cells(AV8CellRow, 5, 1, 1).Text = StringUtil.Trim( context.localUtil.DToC( A73FacturaFechaFactura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            AV9ExcelDocument.get_Cells(AV8CellRow, 6, 1, 1).Text = A71FacturaNo;
            if ( StringUtil.StrCmp(AV20FacturaEstatus, "Rechazada") == 0 )
            {
               AV9ExcelDocument.get_Cells(AV8CellRow, 7, 1, 1).Color = GXUtil.RGB( 250, 88, 88);
               AV9ExcelDocument.get_Cells(AV8CellRow, 8, 1, 1).Color = GXUtil.RGB( 250, 88, 88);
            }
            else
            {
               AV9ExcelDocument.get_Cells(AV8CellRow, 7, 1, 1).Color = GXUtil.RGB( 16, 124, 65);
               AV9ExcelDocument.get_Cells(AV8CellRow, 8, 1, 1).Color = GXUtil.RGB( 16, 124, 65);
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
            AV9ExcelDocument.get_Cells(AV8CellRow, 21, 1, 1).Text = "$"+StringUtil.Trim( StringUtil.Str( (decimal)(A78FacturaMedidaCantidad), 4, 0));
            AV9ExcelDocument.get_Cells(AV8CellRow, 22, 1, 1).Text = "$"+StringUtil.Trim( StringUtil.Trim( StringUtil.Str( AV17BonoUnitario, 10, 2)));
            AV9ExcelDocument.get_Cells(AV8CellRow, 23, 1, 1).Text = "$"+StringUtil.Trim( StringUtil.Str( AV18BonoTotal, 10, 2));
            AV9ExcelDocument.get_Cells(AV8CellRow, 24, 1, 1).Text = "$"+StringUtil.Trim( StringUtil.Str( A79FacturaMedidaPrecio, 10, 2));
            AV9ExcelDocument.AutoFit = 1;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV9ExcelDocument.Save();
         AV9ExcelDocument.Close();
         AV12Session.Set(context.GetMessage( "WWPExportFilePath", ""), AV11FileName);
         AV12Session.Set(context.GetMessage( "WWPExportFileName", ""), "ListadoDeFacturas.xlsx");
         AV10ExcelFilename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
         cleanup();
      }

      protected void S111( )
      {
         /* 'OBTIENEDISTRIBUIDOR' Routine */
         returnInSub = false;
         /* Using cursor P00403 */
         pr_default.execute(1, new Object[] {AV14UsuarioID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A10DistribuidorID = P00403_A10DistribuidorID[0];
            A29UsuarioID = P00403_A29UsuarioID[0];
            A11DistribuidorDescripcion = P00403_A11DistribuidorDescripcion[0];
            A81DistribuidoresUsuarioID = P00403_A81DistribuidoresUsuarioID[0];
            A11DistribuidorDescripcion = P00403_A11DistribuidorDescripcion[0];
            AV15DistribuidorDescripcion = A11DistribuidorDescripcion;
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
         /* Using cursor P00404 */
         pr_default.execute(2, new Object[] {AV16PromocionID, AV19ModeloID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A41PromocionID = P00404_A41PromocionID[0];
            A22ModeloID = P00404_A22ModeloID[0];
            A49PromocionModeloPrecio = P00404_A49PromocionModeloPrecio[0];
            A48PromocionModeloID = P00404_A48PromocionModeloID[0];
            AV17BonoUnitario = A49PromocionModeloPrecio;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV18BonoTotal = (decimal)(AV17BonoUnitario*A78FacturaMedidaCantidad);
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
         AV13ErrorMessage = "";
         AV11FileName = "";
         GXt_char1 = "";
         AV9ExcelDocument = new ExcelDocumentI();
         P00402_A19MotivoRechazoID = new int[1] ;
         P00402_A4CiudadID = new int[1] ;
         P00402_n4CiudadID = new bool[] {false} ;
         P00402_A1EstadoID = new int[1] ;
         P00402_A26MedidaID = new int[1] ;
         P00402_A93FacturaCompleta = new bool[] {false} ;
         P00402_A29UsuarioID = new int[1] ;
         P00402_A41PromocionID = new int[1] ;
         P00402_A22ModeloID = new int[1] ;
         P00402_A80FacturaEstatus = new string[] {""} ;
         P00402_A69FacturaID = new int[1] ;
         P00402_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P00402_A42PromocionDescripcion = new string[] {""} ;
         P00402_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P00402_A71FacturaNo = new string[] {""} ;
         P00402_A20MotivoRechazoDescripcion = new string[] {""} ;
         P00402_A63UsuarioZona = new string[] {""} ;
         P00402_A2EstadoDescripcion = new string[] {""} ;
         P00402_A5CiudadDescripcion = new string[] {""} ;
         P00402_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         P00402_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         P00402_A53UsuarioGenero = new string[] {""} ;
         P00402_A23ModeloDescripcion = new string[] {""} ;
         P00402_A28MedidaDescripcion = new string[] {""} ;
         P00402_A27MedidaCodigo = new string[] {""} ;
         P00402_A74MedidaRin = new string[] {""} ;
         P00402_A78FacturaMedidaCantidad = new short[1] ;
         P00402_A79FacturaMedidaPrecio = new decimal[1] ;
         P00402_A51UsuarioApellido = new string[] {""} ;
         P00402_A30UsuarioNombre = new string[] {""} ;
         P00402_A77FacturaMedidaID = new int[1] ;
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
         OV20FacturaEstatus = "";
         AV20FacturaEstatus = "En Proceso";
         AV15DistribuidorDescripcion = "";
         AV12Session = context.GetSession();
         P00403_A10DistribuidorID = new int[1] ;
         P00403_A29UsuarioID = new int[1] ;
         P00403_A11DistribuidorDescripcion = new string[] {""} ;
         P00403_A81DistribuidoresUsuarioID = new int[1] ;
         A11DistribuidorDescripcion = "";
         P00404_A41PromocionID = new int[1] ;
         P00404_A22ModeloID = new int[1] ;
         P00404_A49PromocionModeloPrecio = new decimal[1] ;
         P00404_A48PromocionModeloID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ageneraexcelpartidasfiltrado__default(),
            new Object[][] {
                new Object[] {
               P00402_A19MotivoRechazoID, P00402_A4CiudadID, P00402_n4CiudadID, P00402_A1EstadoID, P00402_A26MedidaID, P00402_A93FacturaCompleta, P00402_A29UsuarioID, P00402_A41PromocionID, P00402_A22ModeloID, P00402_A80FacturaEstatus,
               P00402_A69FacturaID, P00402_A72FacturaFechaRegistro, P00402_A42PromocionDescripcion, P00402_A73FacturaFechaFactura, P00402_A71FacturaNo, P00402_A20MotivoRechazoDescripcion, P00402_A63UsuarioZona, P00402_A2EstadoDescripcion, P00402_A5CiudadDescripcion, P00402_A82UsuarioNoCuentaBROXEL,
               P00402_A83UsuarioReferenciaBROXEL, P00402_A53UsuarioGenero, P00402_A23ModeloDescripcion, P00402_A28MedidaDescripcion, P00402_A27MedidaCodigo, P00402_A74MedidaRin, P00402_A78FacturaMedidaCantidad, P00402_A79FacturaMedidaPrecio, P00402_A51UsuarioApellido, P00402_A30UsuarioNombre,
               P00402_A77FacturaMedidaID
               }
               , new Object[] {
               P00403_A10DistribuidorID, P00403_A29UsuarioID, P00403_A11DistribuidorDescripcion, P00403_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               P00404_A41PromocionID, P00404_A22ModeloID, P00404_A49PromocionModeloPrecio, P00404_A48PromocionModeloID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8CellRow ;
      private short AV32i ;
      private short A78FacturaMedidaCantidad ;
      private int AV16PromocionID ;
      private int A29UsuarioID ;
      private int A41PromocionID ;
      private int A19MotivoRechazoID ;
      private int A4CiudadID ;
      private int A1EstadoID ;
      private int A26MedidaID ;
      private int A22ModeloID ;
      private int A69FacturaID ;
      private int A77FacturaMedidaID ;
      private int AV14UsuarioID ;
      private int AV19ModeloID ;
      private int A10DistribuidorID ;
      private int A81DistribuidoresUsuarioID ;
      private int A48PromocionModeloID ;
      private long AV23Consecutivo ;
      private decimal A79FacturaMedidaPrecio ;
      private decimal AV17BonoUnitario ;
      private decimal AV18BonoTotal ;
      private decimal A49PromocionModeloPrecio ;
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
      private string OV20FacturaEstatus ;
      private string AV20FacturaEstatus ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A73FacturaFechaFactura ;
      private bool A93FacturaCompleta ;
      private bool n4CiudadID ;
      private bool returnInSub ;
      private string AV10ExcelFilename ;
      private string AV13ErrorMessage ;
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
      private GxSimpleCollection<int> AV34ListaUsuarioID ;
      private IDataStoreProvider pr_default ;
      private int[] P00402_A19MotivoRechazoID ;
      private int[] P00402_A4CiudadID ;
      private bool[] P00402_n4CiudadID ;
      private int[] P00402_A1EstadoID ;
      private int[] P00402_A26MedidaID ;
      private bool[] P00402_A93FacturaCompleta ;
      private int[] P00402_A29UsuarioID ;
      private int[] P00402_A41PromocionID ;
      private int[] P00402_A22ModeloID ;
      private string[] P00402_A80FacturaEstatus ;
      private int[] P00402_A69FacturaID ;
      private DateTime[] P00402_A72FacturaFechaRegistro ;
      private string[] P00402_A42PromocionDescripcion ;
      private DateTime[] P00402_A73FacturaFechaFactura ;
      private string[] P00402_A71FacturaNo ;
      private string[] P00402_A20MotivoRechazoDescripcion ;
      private string[] P00402_A63UsuarioZona ;
      private string[] P00402_A2EstadoDescripcion ;
      private string[] P00402_A5CiudadDescripcion ;
      private string[] P00402_A82UsuarioNoCuentaBROXEL ;
      private string[] P00402_A83UsuarioReferenciaBROXEL ;
      private string[] P00402_A53UsuarioGenero ;
      private string[] P00402_A23ModeloDescripcion ;
      private string[] P00402_A28MedidaDescripcion ;
      private string[] P00402_A27MedidaCodigo ;
      private string[] P00402_A74MedidaRin ;
      private short[] P00402_A78FacturaMedidaCantidad ;
      private decimal[] P00402_A79FacturaMedidaPrecio ;
      private string[] P00402_A51UsuarioApellido ;
      private string[] P00402_A30UsuarioNombre ;
      private int[] P00402_A77FacturaMedidaID ;
      private int[] P00403_A10DistribuidorID ;
      private int[] P00403_A29UsuarioID ;
      private string[] P00403_A11DistribuidorDescripcion ;
      private int[] P00403_A81DistribuidoresUsuarioID ;
      private int[] P00404_A41PromocionID ;
      private int[] P00404_A22ModeloID ;
      private decimal[] P00404_A49PromocionModeloPrecio ;
      private int[] P00404_A48PromocionModeloID ;
      private string aP2_ExcelFilename ;
      private string aP3_ErrorMessage ;
   }

   public class ageneraexcelpartidasfiltrado__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00402( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV34ListaUsuarioID ,
                                             int A41PromocionID ,
                                             int AV16PromocionID ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[1];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T4.`MotivoRechazoID`, T6.`CiudadID`, T7.`EstadoID`, T1.`MedidaID`, T4.`FacturaCompleta`, T4.`UsuarioID`, T4.`PromocionID`, T2.`ModeloID`, T4.`FacturaEstatus`, T1.`FacturaID`, T4.`FacturaFechaRegistro`, T9.`PromocionDescripcion`, T4.`FacturaFechaFactura`, T4.`FacturaNo`, T5.`MotivoRechazoDescripcion`, T6.`UsuarioZona`, T8.`EstadoDescripcion`, T7.`CiudadDescripcion`, T6.`UsuarioNoCuentaBROXEL`, T6.`UsuarioReferenciaBROXEL`, T6.`UsuarioGenero`, T3.`ModeloDescripcion`, T2.`MedidaDescripcion`, T2.`MedidaCodigo`, T2.`MedidaRin`, T1.`FacturaMedidaCantidad`, T1.`FacturaMedidaPrecio`, T6.`UsuarioApellido`, T6.`UsuarioNombre`, T1.`FacturaMedidaID` FROM ((((((((`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T3 ON T3.`ModeloID` = T2.`ModeloID`) INNER JOIN `Factura` T4 ON T4.`FacturaID` = T1.`FacturaID`) INNER JOIN `MotivoRechazo` T5 ON T5.`MotivoRechazoID` = T4.`MotivoRechazoID`) INNER JOIN `Usuario` T6 ON T6.`UsuarioID` = T4.`UsuarioID`) LEFT JOIN `Ciudad` T7 ON T7.`CiudadID` = T6.`CiudadID`) LEFT JOIN `Estado` T8 ON T8.`EstadoID` = T7.`EstadoID`) INNER JOIN `Promocion` T9 ON T9.`PromocionID` = T4.`PromocionID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV34ListaUsuarioID, "T4.`UsuarioID` IN (", ")")+")");
         AddWhere(sWhereString, "(T4.`PromocionID` = @AV16PromocionID)");
         AddWhere(sWhereString, "(T4.`FacturaCompleta` = 1)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`FacturaMedidaID`";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00402(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (bool)dynConstraints[4] );
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
          Object[] prmP00403;
          prmP00403 = new Object[] {
          new ParDef("@AV14UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmP00404;
          prmP00404 = new Object[] {
          new ParDef("@AV16PromocionID",GXType.Int32,9,0) ,
          new ParDef("@AV19ModeloID",GXType.Int32,9,0)
          };
          Object[] prmP00402;
          prmP00402 = new Object[] {
          new ParDef("@AV16PromocionID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00402", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00402,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00403", "SELECT T1.`DistribuidorID`, T1.`UsuarioID`, T2.`DistribuidorDescripcion`, T1.`DistribuidoresUsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Distribuidor` T2 ON T2.`DistribuidorID` = T1.`DistribuidorID`) WHERE T1.`UsuarioID` = @AV14UsuarioID ORDER BY T1.`UsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00403,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00404", "SELECT `PromocionID`, `ModeloID`, `PromocionModeloPrecio`, `PromocionModeloID` FROM `PromocionModelo` WHERE `PromocionID` = @AV16PromocionID and `ModeloID` = @AV19ModeloID ORDER BY `PromocionID`, `ModeloID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00404,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[6])[0] = rslt.getInt(6);
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
