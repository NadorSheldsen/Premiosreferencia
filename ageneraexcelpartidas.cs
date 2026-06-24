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
   public class ageneraexcelpartidas : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new ageneraexcelpartidas().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
          int aP0_PromocionID ;
         string aP1_ExcelFilename = new string(' ',0)  ;
         string aP2_ErrorMessage = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_PromocionID=((int)(NumberUtil.Val( (string)(args[0]), ".")));
         }
         else
         {
            aP0_PromocionID=0;
         }
         if ( 1 < args.Length )
         {
            aP1_ExcelFilename=((string)(args[1]));
         }
         else
         {
            aP1_ExcelFilename="";
         }
         if ( 2 < args.Length )
         {
            aP2_ErrorMessage=((string)(args[2]));
         }
         else
         {
            aP2_ErrorMessage="";
         }
         execute(aP0_PromocionID, out aP1_ExcelFilename, out aP2_ErrorMessage);
         return GX.GXRuntime.ExitCode ;
      }

      public ageneraexcelpartidas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ageneraexcelpartidas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PromocionID ,
                           out string aP1_ExcelFilename ,
                           out string aP2_ErrorMessage )
      {
         this.AV37PromocionID = aP0_PromocionID;
         this.AV19ExcelFilename = "" ;
         this.AV34ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP1_ExcelFilename=this.AV19ExcelFilename;
         aP2_ErrorMessage=this.AV34ErrorMessage;
      }

      public string executeUdp( int aP0_PromocionID ,
                                out string aP1_ExcelFilename )
      {
         execute(aP0_PromocionID, out aP1_ExcelFilename, out aP2_ErrorMessage);
         return AV34ErrorMessage ;
      }

      public void executeSubmit( int aP0_PromocionID ,
                                 out string aP1_ExcelFilename ,
                                 out string aP2_ErrorMessage )
      {
         this.AV37PromocionID = aP0_PromocionID;
         this.AV19ExcelFilename = "" ;
         this.AV34ErrorMessage = "" ;
         SubmitImpl();
         aP1_ExcelFilename=this.AV19ExcelFilename;
         aP2_ErrorMessage=this.AV34ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV20FileName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV20FileName = GXt_char1 + "ListadoDeFacturas.xlsx";
         AV18ExcelDocument.Open(AV20FileName);
         AV18ExcelDocument.Clear();
         AV18ExcelDocument.AutoFit = 1;
         AV15CellRow = 1;
         AV18ExcelDocument.get_Cells(AV15CellRow, 1, 1, 1).Text = "#";
         AV18ExcelDocument.get_Cells(AV15CellRow, 2, 1, 1).Text = context.GetMessage( "FOLIO #", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 3, 1, 1).Text = context.GetMessage( "FECHA REGISTRO", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 4, 1, 1).Text = context.GetMessage( "PROMOCIÓN", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 5, 1, 1).Text = context.GetMessage( "FECHA FACTURA", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 6, 1, 1).Text = context.GetMessage( "NO. FACTURA", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 7, 1, 1).Text = context.GetMessage( "ESTATUS", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 8, 1, 1).Text = context.GetMessage( "MOTIVO DE RECHAZO", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 9, 1, 1).Text = context.GetMessage( "DISTRIBUIDOR", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 10, 1, 1).Text = context.GetMessage( "ZONA", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 11, 1, 1).Text = context.GetMessage( "ESTADO", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 12, 1, 1).Text = context.GetMessage( "CIUDAD", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 13, 1, 1).Text = context.GetMessage( "VENDEDOR", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 14, 1, 1).Text = context.GetMessage( "No de Cuenta Broxel", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 15, 1, 1).Text = context.GetMessage( "Referencia Broxel", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 16, 1, 1).Text = context.GetMessage( "GÉNERO", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 17, 1, 1).Text = context.GetMessage( "MODELO", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 18, 1, 1).Text = context.GetMessage( "MEDIDA", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 19, 1, 1).Text = context.GetMessage( "CÓDIGO", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 20, 1, 1).Text = context.GetMessage( "RIN", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 21, 1, 1).Text = context.GetMessage( "CANTIDAD", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 22, 1, 1).Text = context.GetMessage( "BONO UNITARIO", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 23, 1, 1).Text = context.GetMessage( "BONO TOTAL", "");
         AV18ExcelDocument.get_Cells(AV15CellRow, 24, 1, 1).Text = context.GetMessage( "PRECIO UNITARIO", "");
         AV53i = 1;
         while ( AV53i <= 24 )
         {
            AV18ExcelDocument.get_Cells(AV15CellRow, AV53i, 1, 1).Bold = 1;
            AV53i = (short)(AV53i+1);
         }
         AV44Consecutivo = 0;
         /* Using cursor P003I2 */
         pr_default.execute(0, new Object[] {AV37PromocionID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A19MotivoRechazoID = P003I2_A19MotivoRechazoID[0];
            A4CiudadID = P003I2_A4CiudadID[0];
            n4CiudadID = P003I2_n4CiudadID[0];
            A1EstadoID = P003I2_A1EstadoID[0];
            A26MedidaID = P003I2_A26MedidaID[0];
            A41PromocionID = P003I2_A41PromocionID[0];
            A93FacturaCompleta = P003I2_A93FacturaCompleta[0];
            A29UsuarioID = P003I2_A29UsuarioID[0];
            A22ModeloID = P003I2_A22ModeloID[0];
            A80FacturaEstatus = P003I2_A80FacturaEstatus[0];
            A69FacturaID = P003I2_A69FacturaID[0];
            A72FacturaFechaRegistro = P003I2_A72FacturaFechaRegistro[0];
            A42PromocionDescripcion = P003I2_A42PromocionDescripcion[0];
            A73FacturaFechaFactura = P003I2_A73FacturaFechaFactura[0];
            A71FacturaNo = P003I2_A71FacturaNo[0];
            A20MotivoRechazoDescripcion = P003I2_A20MotivoRechazoDescripcion[0];
            A63UsuarioZona = P003I2_A63UsuarioZona[0];
            A2EstadoDescripcion = P003I2_A2EstadoDescripcion[0];
            A5CiudadDescripcion = P003I2_A5CiudadDescripcion[0];
            A82UsuarioNoCuentaBROXEL = P003I2_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = P003I2_A83UsuarioReferenciaBROXEL[0];
            A53UsuarioGenero = P003I2_A53UsuarioGenero[0];
            A23ModeloDescripcion = P003I2_A23ModeloDescripcion[0];
            A28MedidaDescripcion = P003I2_A28MedidaDescripcion[0];
            A27MedidaCodigo = P003I2_A27MedidaCodigo[0];
            A74MedidaRin = P003I2_A74MedidaRin[0];
            A78FacturaMedidaCantidad = P003I2_A78FacturaMedidaCantidad[0];
            A79FacturaMedidaPrecio = P003I2_A79FacturaMedidaPrecio[0];
            A51UsuarioApellido = P003I2_A51UsuarioApellido[0];
            A30UsuarioNombre = P003I2_A30UsuarioNombre[0];
            A77FacturaMedidaID = P003I2_A77FacturaMedidaID[0];
            A22ModeloID = P003I2_A22ModeloID[0];
            A28MedidaDescripcion = P003I2_A28MedidaDescripcion[0];
            A27MedidaCodigo = P003I2_A27MedidaCodigo[0];
            A74MedidaRin = P003I2_A74MedidaRin[0];
            A23ModeloDescripcion = P003I2_A23ModeloDescripcion[0];
            A19MotivoRechazoID = P003I2_A19MotivoRechazoID[0];
            A41PromocionID = P003I2_A41PromocionID[0];
            A93FacturaCompleta = P003I2_A93FacturaCompleta[0];
            A29UsuarioID = P003I2_A29UsuarioID[0];
            A80FacturaEstatus = P003I2_A80FacturaEstatus[0];
            A72FacturaFechaRegistro = P003I2_A72FacturaFechaRegistro[0];
            A73FacturaFechaFactura = P003I2_A73FacturaFechaFactura[0];
            A71FacturaNo = P003I2_A71FacturaNo[0];
            A20MotivoRechazoDescripcion = P003I2_A20MotivoRechazoDescripcion[0];
            A42PromocionDescripcion = P003I2_A42PromocionDescripcion[0];
            A4CiudadID = P003I2_A4CiudadID[0];
            n4CiudadID = P003I2_n4CiudadID[0];
            A63UsuarioZona = P003I2_A63UsuarioZona[0];
            A82UsuarioNoCuentaBROXEL = P003I2_A82UsuarioNoCuentaBROXEL[0];
            A83UsuarioReferenciaBROXEL = P003I2_A83UsuarioReferenciaBROXEL[0];
            A53UsuarioGenero = P003I2_A53UsuarioGenero[0];
            A51UsuarioApellido = P003I2_A51UsuarioApellido[0];
            A30UsuarioNombre = P003I2_A30UsuarioNombre[0];
            A1EstadoID = P003I2_A1EstadoID[0];
            A5CiudadDescripcion = P003I2_A5CiudadDescripcion[0];
            A2EstadoDescripcion = P003I2_A2EstadoDescripcion[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            OV41FacturaEstatus = AV41FacturaEstatus;
            AV15CellRow = (short)(AV15CellRow+1);
            AV44Consecutivo = (long)(AV44Consecutivo+1);
            AV35UsuarioID = A29UsuarioID;
            AV40ModeloID = A22ModeloID;
            AV41FacturaEstatus = A80FacturaEstatus;
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
            AV18ExcelDocument.get_Cells(AV15CellRow, 1, 1, 1).Text = StringUtil.Trim( StringUtil.Str( (decimal)(AV44Consecutivo), 10, 0));
            AV18ExcelDocument.get_Cells(AV15CellRow, 2, 1, 1).Text = StringUtil.Trim( StringUtil.Str( (decimal)(A69FacturaID), 9, 0));
            GXt_dtime2 = DateTimeUtil.ResetTime( A72FacturaFechaRegistro ) ;
            AV18ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV18ExcelDocument.get_Cells(AV15CellRow, 3, 1, 1).Date = GXt_dtime2;
            AV18ExcelDocument.get_Cells(AV15CellRow, 4, 1, 1).Text = A42PromocionDescripcion;
            GXt_dtime2 = DateTimeUtil.ResetTime( A73FacturaFechaFactura ) ;
            AV18ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV18ExcelDocument.get_Cells(AV15CellRow, 5, 1, 1).Date = GXt_dtime2;
            AV18ExcelDocument.get_Cells(AV15CellRow, 6, 1, 1).Text = A71FacturaNo;
            if ( StringUtil.StrCmp(AV41FacturaEstatus, "Rechazada") == 0 )
            {
               AV18ExcelDocument.get_Cells(AV15CellRow, 7, 1, 1).Color = GXUtil.RGB( 250, 88, 88);
               AV18ExcelDocument.get_Cells(AV15CellRow, 8, 1, 1).Color = GXUtil.RGB( 250, 88, 88);
            }
            else
            {
               AV18ExcelDocument.get_Cells(AV15CellRow, 7, 1, 1).Color = GXUtil.RGB( 16, 124, 65);
               AV18ExcelDocument.get_Cells(AV15CellRow, 8, 1, 1).Color = GXUtil.RGB( 16, 124, 65);
            }
            AV18ExcelDocument.get_Cells(AV15CellRow, 7, 1, 1).Text = A80FacturaEstatus;
            AV18ExcelDocument.get_Cells(AV15CellRow, 8, 1, 1).Text = A20MotivoRechazoDescripcion;
            AV18ExcelDocument.get_Cells(AV15CellRow, 9, 1, 1).Text = AV36DistribuidorDescripcion;
            AV18ExcelDocument.get_Cells(AV15CellRow, 10, 1, 1).Text = A63UsuarioZona;
            AV18ExcelDocument.get_Cells(AV15CellRow, 11, 1, 1).Text = A2EstadoDescripcion;
            AV18ExcelDocument.get_Cells(AV15CellRow, 12, 1, 1).Text = A5CiudadDescripcion;
            AV18ExcelDocument.get_Cells(AV15CellRow, 13, 1, 1).Text = A52UsuarioNombreCompleto;
            AV18ExcelDocument.get_Cells(AV15CellRow, 14, 1, 1).Text = A82UsuarioNoCuentaBROXEL;
            AV18ExcelDocument.get_Cells(AV15CellRow, 15, 1, 1).Text = A83UsuarioReferenciaBROXEL;
            AV18ExcelDocument.get_Cells(AV15CellRow, 16, 1, 1).Text = A53UsuarioGenero;
            AV18ExcelDocument.get_Cells(AV15CellRow, 17, 1, 1).Text = A23ModeloDescripcion;
            AV18ExcelDocument.get_Cells(AV15CellRow, 18, 1, 1).Text = A28MedidaDescripcion;
            AV18ExcelDocument.get_Cells(AV15CellRow, 19, 1, 1).Text = A27MedidaCodigo;
            AV18ExcelDocument.get_Cells(AV15CellRow, 20, 1, 1).Text = A74MedidaRin;
            AV18ExcelDocument.get_Cells(AV15CellRow, 21, 1, 1).Number = A78FacturaMedidaCantidad;
            AV18ExcelDocument.get_Cells(AV15CellRow, 22, 1, 1).Number = (double)(AV38BonoUnitario);
            AV18ExcelDocument.get_Cells(AV15CellRow, 23, 1, 1).Number = (double)(AV39BonoTotal);
            AV18ExcelDocument.get_Cells(AV15CellRow, 24, 1, 1).Number = (double)(A79FacturaMedidaPrecio);
            AV18ExcelDocument.AutoFit = 1;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV18ExcelDocument.Save();
         AV18ExcelDocument.Close();
         AV22Session.Set(context.GetMessage( "WWPExportFilePath", ""), AV20FileName);
         AV22Session.Set(context.GetMessage( "WWPExportFileName", ""), "ListadoDeFacturas.xlsx");
         AV19ExcelFilename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
         cleanup();
      }

      protected void S111( )
      {
         /* 'OBTIENEDISTRIBUIDOR' Routine */
         returnInSub = false;
         /* Using cursor P003I3 */
         pr_default.execute(1, new Object[] {AV35UsuarioID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A10DistribuidorID = P003I3_A10DistribuidorID[0];
            A29UsuarioID = P003I3_A29UsuarioID[0];
            A11DistribuidorDescripcion = P003I3_A11DistribuidorDescripcion[0];
            A81DistribuidoresUsuarioID = P003I3_A81DistribuidoresUsuarioID[0];
            A11DistribuidorDescripcion = P003I3_A11DistribuidorDescripcion[0];
            AV36DistribuidorDescripcion = A11DistribuidorDescripcion;
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
         /* Using cursor P003I4 */
         pr_default.execute(2, new Object[] {AV37PromocionID, AV40ModeloID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A41PromocionID = P003I4_A41PromocionID[0];
            A22ModeloID = P003I4_A22ModeloID[0];
            A49PromocionModeloPrecio = P003I4_A49PromocionModeloPrecio[0];
            A48PromocionModeloID = P003I4_A48PromocionModeloID[0];
            AV38BonoUnitario = A49PromocionModeloPrecio;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV39BonoTotal = (decimal)(AV38BonoUnitario*A78FacturaMedidaCantidad);
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
         AV19ExcelFilename = "";
         AV34ErrorMessage = "";
         AV20FileName = "";
         GXt_char1 = "";
         AV18ExcelDocument = new ExcelDocumentI();
         P003I2_A19MotivoRechazoID = new int[1] ;
         P003I2_A4CiudadID = new int[1] ;
         P003I2_n4CiudadID = new bool[] {false} ;
         P003I2_A1EstadoID = new int[1] ;
         P003I2_A26MedidaID = new int[1] ;
         P003I2_A41PromocionID = new int[1] ;
         P003I2_A93FacturaCompleta = new bool[] {false} ;
         P003I2_A29UsuarioID = new int[1] ;
         P003I2_A22ModeloID = new int[1] ;
         P003I2_A80FacturaEstatus = new string[] {""} ;
         P003I2_A69FacturaID = new int[1] ;
         P003I2_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         P003I2_A42PromocionDescripcion = new string[] {""} ;
         P003I2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P003I2_A71FacturaNo = new string[] {""} ;
         P003I2_A20MotivoRechazoDescripcion = new string[] {""} ;
         P003I2_A63UsuarioZona = new string[] {""} ;
         P003I2_A2EstadoDescripcion = new string[] {""} ;
         P003I2_A5CiudadDescripcion = new string[] {""} ;
         P003I2_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         P003I2_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         P003I2_A53UsuarioGenero = new string[] {""} ;
         P003I2_A23ModeloDescripcion = new string[] {""} ;
         P003I2_A28MedidaDescripcion = new string[] {""} ;
         P003I2_A27MedidaCodigo = new string[] {""} ;
         P003I2_A74MedidaRin = new string[] {""} ;
         P003I2_A78FacturaMedidaCantidad = new short[1] ;
         P003I2_A79FacturaMedidaPrecio = new decimal[1] ;
         P003I2_A51UsuarioApellido = new string[] {""} ;
         P003I2_A30UsuarioNombre = new string[] {""} ;
         P003I2_A77FacturaMedidaID = new int[1] ;
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
         OV41FacturaEstatus = "";
         AV41FacturaEstatus = "En Proceso";
         GXt_dtime2 = (DateTime)(DateTime.MinValue);
         AV36DistribuidorDescripcion = "";
         AV22Session = context.GetSession();
         P003I3_A10DistribuidorID = new int[1] ;
         P003I3_A29UsuarioID = new int[1] ;
         P003I3_A11DistribuidorDescripcion = new string[] {""} ;
         P003I3_A81DistribuidoresUsuarioID = new int[1] ;
         A11DistribuidorDescripcion = "";
         P003I4_A41PromocionID = new int[1] ;
         P003I4_A22ModeloID = new int[1] ;
         P003I4_A49PromocionModeloPrecio = new decimal[1] ;
         P003I4_A48PromocionModeloID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ageneraexcelpartidas__default(),
            new Object[][] {
                new Object[] {
               P003I2_A19MotivoRechazoID, P003I2_A4CiudadID, P003I2_n4CiudadID, P003I2_A1EstadoID, P003I2_A26MedidaID, P003I2_A41PromocionID, P003I2_A93FacturaCompleta, P003I2_A29UsuarioID, P003I2_A22ModeloID, P003I2_A80FacturaEstatus,
               P003I2_A69FacturaID, P003I2_A72FacturaFechaRegistro, P003I2_A42PromocionDescripcion, P003I2_A73FacturaFechaFactura, P003I2_A71FacturaNo, P003I2_A20MotivoRechazoDescripcion, P003I2_A63UsuarioZona, P003I2_A2EstadoDescripcion, P003I2_A5CiudadDescripcion, P003I2_A82UsuarioNoCuentaBROXEL,
               P003I2_A83UsuarioReferenciaBROXEL, P003I2_A53UsuarioGenero, P003I2_A23ModeloDescripcion, P003I2_A28MedidaDescripcion, P003I2_A27MedidaCodigo, P003I2_A74MedidaRin, P003I2_A78FacturaMedidaCantidad, P003I2_A79FacturaMedidaPrecio, P003I2_A51UsuarioApellido, P003I2_A30UsuarioNombre,
               P003I2_A77FacturaMedidaID
               }
               , new Object[] {
               P003I3_A10DistribuidorID, P003I3_A29UsuarioID, P003I3_A11DistribuidorDescripcion, P003I3_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               P003I4_A41PromocionID, P003I4_A22ModeloID, P003I4_A49PromocionModeloPrecio, P003I4_A48PromocionModeloID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV15CellRow ;
      private short AV53i ;
      private short A78FacturaMedidaCantidad ;
      private int AV37PromocionID ;
      private int A19MotivoRechazoID ;
      private int A4CiudadID ;
      private int A1EstadoID ;
      private int A26MedidaID ;
      private int A41PromocionID ;
      private int A29UsuarioID ;
      private int A22ModeloID ;
      private int A69FacturaID ;
      private int A77FacturaMedidaID ;
      private int AV35UsuarioID ;
      private int AV40ModeloID ;
      private int A10DistribuidorID ;
      private int A81DistribuidoresUsuarioID ;
      private int A48PromocionModeloID ;
      private long AV44Consecutivo ;
      private decimal A79FacturaMedidaPrecio ;
      private decimal AV38BonoUnitario ;
      private decimal AV39BonoTotal ;
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
      private string OV41FacturaEstatus ;
      private string AV41FacturaEstatus ;
      private DateTime GXt_dtime2 ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A73FacturaFechaFactura ;
      private bool n4CiudadID ;
      private bool A93FacturaCompleta ;
      private bool returnInSub ;
      private string AV19ExcelFilename ;
      private string AV34ErrorMessage ;
      private string AV20FileName ;
      private string A42PromocionDescripcion ;
      private string A20MotivoRechazoDescripcion ;
      private string A2EstadoDescripcion ;
      private string A5CiudadDescripcion ;
      private string A23ModeloDescripcion ;
      private string A28MedidaDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string AV36DistribuidorDescripcion ;
      private string A11DistribuidorDescripcion ;
      private IGxSession AV22Session ;
      private ExcelDocumentI AV18ExcelDocument ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P003I2_A19MotivoRechazoID ;
      private int[] P003I2_A4CiudadID ;
      private bool[] P003I2_n4CiudadID ;
      private int[] P003I2_A1EstadoID ;
      private int[] P003I2_A26MedidaID ;
      private int[] P003I2_A41PromocionID ;
      private bool[] P003I2_A93FacturaCompleta ;
      private int[] P003I2_A29UsuarioID ;
      private int[] P003I2_A22ModeloID ;
      private string[] P003I2_A80FacturaEstatus ;
      private int[] P003I2_A69FacturaID ;
      private DateTime[] P003I2_A72FacturaFechaRegistro ;
      private string[] P003I2_A42PromocionDescripcion ;
      private DateTime[] P003I2_A73FacturaFechaFactura ;
      private string[] P003I2_A71FacturaNo ;
      private string[] P003I2_A20MotivoRechazoDescripcion ;
      private string[] P003I2_A63UsuarioZona ;
      private string[] P003I2_A2EstadoDescripcion ;
      private string[] P003I2_A5CiudadDescripcion ;
      private string[] P003I2_A82UsuarioNoCuentaBROXEL ;
      private string[] P003I2_A83UsuarioReferenciaBROXEL ;
      private string[] P003I2_A53UsuarioGenero ;
      private string[] P003I2_A23ModeloDescripcion ;
      private string[] P003I2_A28MedidaDescripcion ;
      private string[] P003I2_A27MedidaCodigo ;
      private string[] P003I2_A74MedidaRin ;
      private short[] P003I2_A78FacturaMedidaCantidad ;
      private decimal[] P003I2_A79FacturaMedidaPrecio ;
      private string[] P003I2_A51UsuarioApellido ;
      private string[] P003I2_A30UsuarioNombre ;
      private int[] P003I2_A77FacturaMedidaID ;
      private int[] P003I3_A10DistribuidorID ;
      private int[] P003I3_A29UsuarioID ;
      private string[] P003I3_A11DistribuidorDescripcion ;
      private int[] P003I3_A81DistribuidoresUsuarioID ;
      private int[] P003I4_A41PromocionID ;
      private int[] P003I4_A22ModeloID ;
      private decimal[] P003I4_A49PromocionModeloPrecio ;
      private int[] P003I4_A48PromocionModeloID ;
      private string aP1_ExcelFilename ;
      private string aP2_ErrorMessage ;
   }

   public class ageneraexcelpartidas__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003I2;
          prmP003I2 = new Object[] {
          new ParDef("@AV37PromocionID",GXType.Int32,9,0)
          };
          Object[] prmP003I3;
          prmP003I3 = new Object[] {
          new ParDef("@AV35UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmP003I4;
          prmP003I4 = new Object[] {
          new ParDef("@AV37PromocionID",GXType.Int32,9,0) ,
          new ParDef("@AV40ModeloID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003I2", "SELECT T4.`MotivoRechazoID`, T7.`CiudadID`, T8.`EstadoID`, T1.`MedidaID`, T4.`PromocionID`, T4.`FacturaCompleta`, T4.`UsuarioID`, T2.`ModeloID`, T4.`FacturaEstatus`, T1.`FacturaID`, T4.`FacturaFechaRegistro`, T6.`PromocionDescripcion`, T4.`FacturaFechaFactura`, T4.`FacturaNo`, T5.`MotivoRechazoDescripcion`, T7.`UsuarioZona`, T9.`EstadoDescripcion`, T8.`CiudadDescripcion`, T7.`UsuarioNoCuentaBROXEL`, T7.`UsuarioReferenciaBROXEL`, T7.`UsuarioGenero`, T3.`ModeloDescripcion`, T2.`MedidaDescripcion`, T2.`MedidaCodigo`, T2.`MedidaRin`, T1.`FacturaMedidaCantidad`, T1.`FacturaMedidaPrecio`, T7.`UsuarioApellido`, T7.`UsuarioNombre`, T1.`FacturaMedidaID` FROM ((((((((`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T3 ON T3.`ModeloID` = T2.`ModeloID`) INNER JOIN `Factura` T4 ON T4.`FacturaID` = T1.`FacturaID`) INNER JOIN `MotivoRechazo` T5 ON T5.`MotivoRechazoID` = T4.`MotivoRechazoID`) INNER JOIN `Promocion` T6 ON T6.`PromocionID` = T4.`PromocionID`) INNER JOIN `Usuario` T7 ON T7.`UsuarioID` = T4.`UsuarioID`) LEFT JOIN `Ciudad` T8 ON T8.`CiudadID` = T7.`CiudadID`) LEFT JOIN `Estado` T9 ON T9.`EstadoID` = T8.`EstadoID`) WHERE (T4.`FacturaCompleta` = 1) AND (T4.`PromocionID` = @AV37PromocionID) ORDER BY T1.`FacturaMedidaID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003I2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003I3", "SELECT T1.`DistribuidorID`, T1.`UsuarioID`, T2.`DistribuidorDescripcion`, T1.`DistribuidoresUsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Distribuidor` T2 ON T2.`DistribuidorID` = T1.`DistribuidorID`) WHERE T1.`UsuarioID` = @AV35UsuarioID ORDER BY T1.`UsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003I3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003I4", "SELECT `PromocionID`, `ModeloID`, `PromocionModeloPrecio`, `PromocionModeloID` FROM `PromocionModelo` WHERE `PromocionID` = @AV37PromocionID and `ModeloID` = @AV40ModeloID ORDER BY `PromocionID`, `ModeloID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003I4,1, GxCacheFrequency.OFF ,false,true )
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
