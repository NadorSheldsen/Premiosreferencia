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
   public class generaexcelresumenpromocion : GXProcedure
   {
      public generaexcelresumenpromocion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public generaexcelresumenpromocion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PromocionID ,
                           out string aP1_ExcelFilename )
      {
         this.AV38PromocionID = aP0_PromocionID;
         this.AV28ExcelFilename = "" ;
         initialize();
         ExecuteImpl();
         aP1_ExcelFilename=this.AV28ExcelFilename;
      }

      public string executeUdp( int aP0_PromocionID )
      {
         execute(aP0_PromocionID, out aP1_ExcelFilename);
         return AV28ExcelFilename ;
      }

      public void executeSubmit( int aP0_PromocionID ,
                                 out string aP1_ExcelFilename )
      {
         this.AV38PromocionID = aP0_PromocionID;
         this.AV28ExcelFilename = "" ;
         SubmitImpl();
         aP1_ExcelFilename=this.AV28ExcelFilename;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV33FileName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV33FileName = GXt_char1 + "ReporteResumenPromocion.xlsx";
         AV27ExcelDocument.Open(AV33FileName);
         AV27ExcelDocument.Clear();
         AV27ExcelDocument.AutoFit = 1;
         AV18CellRow = 1;
         AV27ExcelDocument.get_Cells(AV18CellRow, 1, 1, 1).Text = "#";
         AV27ExcelDocument.get_Cells(AV18CellRow, 2, 1, 1).Text = context.GetMessage( "PROMOCIÓN", "");
         AV27ExcelDocument.get_Cells(AV18CellRow, 3, 1, 1).Text = context.GetMessage( "DISTRIBUIDOR", "");
         AV27ExcelDocument.get_Cells(AV18CellRow, 4, 1, 1).Text = context.GetMessage( "ZONA", "");
         AV27ExcelDocument.get_Cells(AV18CellRow, 5, 1, 1).Text = context.GetMessage( "ESTADO", "");
         AV27ExcelDocument.get_Cells(AV18CellRow, 6, 1, 1).Text = context.GetMessage( "CIUDAD", "");
         AV27ExcelDocument.get_Cells(AV18CellRow, 7, 1, 1).Text = context.GetMessage( "VENDEDOR", "");
         AV27ExcelDocument.get_Cells(AV18CellRow, 8, 1, 1).Text = context.GetMessage( "No de Cuenta Broxel", "");
         AV27ExcelDocument.get_Cells(AV18CellRow, 9, 1, 1).Text = context.GetMessage( "Referencia Broxel", "");
         AV27ExcelDocument.get_Cells(AV18CellRow, 10, 1, 1).Text = context.GetMessage( "BONO TOTAL", "");
         AV34i = 1;
         while ( AV34i <= 10 )
         {
            AV27ExcelDocument.get_Cells(AV18CellRow, AV34i, 1, 1).Bold = 1;
            AV34i = (short)(AV34i+1);
         }
         AV19Consecutivo = 0;
         AV41UsuarioSDT.Clear();
         /* Using cursor P003K2 */
         pr_default.execute(0, new Object[] {AV38PromocionID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A93FacturaCompleta = P003K2_A93FacturaCompleta[0];
            A80FacturaEstatus = P003K2_A80FacturaEstatus[0];
            A41PromocionID = P003K2_A41PromocionID[0];
            A29UsuarioID = P003K2_A29UsuarioID[0];
            A69FacturaID = P003K2_A69FacturaID[0];
            AV40UsuarioID = A29UsuarioID;
            AV69Existe = false;
            AV71GXV1 = 1;
            while ( AV71GXV1 <= AV41UsuarioSDT.Count )
            {
               AV43u = ((SdtUsuarioSDT_UsuarioSDTItem)AV41UsuarioSDT.Item(AV71GXV1));
               if ( AV43u.gxTpr_Usuarioid == AV40UsuarioID )
               {
                  AV69Existe = true;
                  if (true) break;
               }
               AV71GXV1 = (int)(AV71GXV1+1);
            }
            if ( ! AV69Existe )
            {
               AV68UsuarioSDTItem = new SdtUsuarioSDT_UsuarioSDTItem(context);
               AV68UsuarioSDTItem.gxTpr_Usuarioid = AV40UsuarioID;
               AV41UsuarioSDT.Add(AV68UsuarioSDTItem, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV72GXV2 = 1;
         while ( AV72GXV2 <= AV41UsuarioSDT.Count )
         {
            AV43u = ((SdtUsuarioSDT_UsuarioSDTItem)AV41UsuarioSDT.Item(AV72GXV2));
            AV18CellRow = (short)(AV18CellRow+1);
            AV19Consecutivo = (long)(AV19Consecutivo+1);
            AV40UsuarioID = AV43u.gxTpr_Usuarioid;
            /* Using cursor P003K3 */
            pr_default.execute(1, new Object[] {AV40UsuarioID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A4CiudadID = P003K3_A4CiudadID[0];
               n4CiudadID = P003K3_n4CiudadID[0];
               A1EstadoID = P003K3_A1EstadoID[0];
               A29UsuarioID = P003K3_A29UsuarioID[0];
               A63UsuarioZona = P003K3_A63UsuarioZona[0];
               A2EstadoDescripcion = P003K3_A2EstadoDescripcion[0];
               A5CiudadDescripcion = P003K3_A5CiudadDescripcion[0];
               A82UsuarioNoCuentaBROXEL = P003K3_A82UsuarioNoCuentaBROXEL[0];
               A83UsuarioReferenciaBROXEL = P003K3_A83UsuarioReferenciaBROXEL[0];
               A51UsuarioApellido = P003K3_A51UsuarioApellido[0];
               A30UsuarioNombre = P003K3_A30UsuarioNombre[0];
               A1EstadoID = P003K3_A1EstadoID[0];
               A5CiudadDescripcion = P003K3_A5CiudadDescripcion[0];
               A2EstadoDescripcion = P003K3_A2EstadoDescripcion[0];
               A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
               AV45UsuarioZona = A63UsuarioZona;
               AV47EstadoDescripcion = A2EstadoDescripcion;
               AV49CiudadDescripcion = A5CiudadDescripcion;
               AV50UsuarioNombreCompleto = A52UsuarioNombreCompleto;
               AV51UsuarioNoCuentaBROXEL = A82UsuarioNoCuentaBROXEL;
               AV52UsuarioReferenciaBROXEL = A83UsuarioReferenciaBROXEL;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Execute user subroutine: 'OBTIENEDISTRIBUIDOR' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            AV67TotalBono = 0;
            /* Using cursor P003K4 */
            pr_default.execute(2, new Object[] {AV38PromocionID, AV40UsuarioID});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A80FacturaEstatus = P003K4_A80FacturaEstatus[0];
               A41PromocionID = P003K4_A41PromocionID[0];
               A29UsuarioID = P003K4_A29UsuarioID[0];
               A69FacturaID = P003K4_A69FacturaID[0];
               A42PromocionDescripcion = P003K4_A42PromocionDescripcion[0];
               A42PromocionDescripcion = P003K4_A42PromocionDescripcion[0];
               AV53FacturaID = A69FacturaID;
               AV54PromocionDescripcion = A42PromocionDescripcion;
               /* Using cursor P003K5 */
               pr_default.execute(3, new Object[] {AV53FacturaID});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A26MedidaID = P003K5_A26MedidaID[0];
                  A69FacturaID = P003K5_A69FacturaID[0];
                  A22ModeloID = P003K5_A22ModeloID[0];
                  A78FacturaMedidaCantidad = P003K5_A78FacturaMedidaCantidad[0];
                  A77FacturaMedidaID = P003K5_A77FacturaMedidaID[0];
                  A22ModeloID = P003K5_A22ModeloID[0];
                  AV16BonoUnitario = 0;
                  AV35ModeloID = A22ModeloID;
                  /* Using cursor P003K6 */
                  pr_default.execute(4, new Object[] {AV38PromocionID, AV35ModeloID});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A22ModeloID = P003K6_A22ModeloID[0];
                     A41PromocionID = P003K6_A41PromocionID[0];
                     A49PromocionModeloPrecio = P003K6_A49PromocionModeloPrecio[0];
                     A48PromocionModeloID = P003K6_A48PromocionModeloID[0];
                     AV16BonoUnitario = A49PromocionModeloPrecio;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     pr_default.readNext(4);
                  }
                  pr_default.close(4);
                  AV15BonoTotal = (decimal)(AV16BonoUnitario*A78FacturaMedidaCantidad);
                  AV67TotalBono = (decimal)(AV67TotalBono+AV15BonoTotal);
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV27ExcelDocument.get_Cells(AV18CellRow, 1, 1, 1).Text = StringUtil.Str( (decimal)(AV19Consecutivo), 10, 0);
            AV27ExcelDocument.get_Cells(AV18CellRow, 2, 1, 1).Text = AV54PromocionDescripcion;
            AV27ExcelDocument.get_Cells(AV18CellRow, 3, 1, 1).Text = AV20DistribuidorDescripcion;
            AV27ExcelDocument.get_Cells(AV18CellRow, 4, 1, 1).Text = AV45UsuarioZona;
            AV27ExcelDocument.get_Cells(AV18CellRow, 5, 1, 1).Text = AV47EstadoDescripcion;
            AV27ExcelDocument.get_Cells(AV18CellRow, 6, 1, 1).Text = AV49CiudadDescripcion;
            AV27ExcelDocument.get_Cells(AV18CellRow, 7, 1, 1).Text = AV50UsuarioNombreCompleto;
            AV27ExcelDocument.get_Cells(AV18CellRow, 8, 1, 1).Text = AV51UsuarioNoCuentaBROXEL;
            AV27ExcelDocument.get_Cells(AV18CellRow, 9, 1, 1).Text = AV52UsuarioReferenciaBROXEL;
            AV27ExcelDocument.get_Cells(AV18CellRow, 10, 1, 1).Text = "$"+StringUtil.Trim( StringUtil.Str( AV67TotalBono, 10, 2));
            AV72GXV2 = (int)(AV72GXV2+1);
         }
         AV27ExcelDocument.AutoFit = 1;
         AV27ExcelDocument.Save();
         AV27ExcelDocument.Close();
         AV39Session.Set(context.GetMessage( "WWPExportFilePath", ""), AV33FileName);
         AV39Session.Set(context.GetMessage( "WWPExportFileName", ""), "ReporteResumenPromocion.xlsx");
         AV28ExcelFilename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
         cleanup();
      }

      protected void S111( )
      {
         /* 'OBTIENEDISTRIBUIDOR' Routine */
         returnInSub = false;
         /* Using cursor P003K7 */
         pr_default.execute(5, new Object[] {AV40UsuarioID});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A10DistribuidorID = P003K7_A10DistribuidorID[0];
            A29UsuarioID = P003K7_A29UsuarioID[0];
            A11DistribuidorDescripcion = P003K7_A11DistribuidorDescripcion[0];
            A81DistribuidoresUsuarioID = P003K7_A81DistribuidoresUsuarioID[0];
            A11DistribuidorDescripcion = P003K7_A11DistribuidorDescripcion[0];
            AV20DistribuidorDescripcion = A11DistribuidorDescripcion;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(5);
         }
         pr_default.close(5);
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
         AV28ExcelFilename = "";
         AV33FileName = "";
         GXt_char1 = "";
         AV27ExcelDocument = new ExcelDocumentI();
         AV41UsuarioSDT = new GXBaseCollection<SdtUsuarioSDT_UsuarioSDTItem>( context, "UsuarioSDTItem", "Premios");
         P003K2_A93FacturaCompleta = new bool[] {false} ;
         P003K2_A80FacturaEstatus = new string[] {""} ;
         P003K2_A41PromocionID = new int[1] ;
         P003K2_A29UsuarioID = new int[1] ;
         P003K2_A69FacturaID = new int[1] ;
         A80FacturaEstatus = "";
         AV43u = new SdtUsuarioSDT_UsuarioSDTItem(context);
         AV68UsuarioSDTItem = new SdtUsuarioSDT_UsuarioSDTItem(context);
         P003K3_A4CiudadID = new int[1] ;
         P003K3_n4CiudadID = new bool[] {false} ;
         P003K3_A1EstadoID = new int[1] ;
         P003K3_A29UsuarioID = new int[1] ;
         P003K3_A63UsuarioZona = new string[] {""} ;
         P003K3_A2EstadoDescripcion = new string[] {""} ;
         P003K3_A5CiudadDescripcion = new string[] {""} ;
         P003K3_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         P003K3_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         P003K3_A51UsuarioApellido = new string[] {""} ;
         P003K3_A30UsuarioNombre = new string[] {""} ;
         A63UsuarioZona = "";
         A2EstadoDescripcion = "";
         A5CiudadDescripcion = "";
         A82UsuarioNoCuentaBROXEL = "";
         A83UsuarioReferenciaBROXEL = "";
         A51UsuarioApellido = "";
         A30UsuarioNombre = "";
         A52UsuarioNombreCompleto = "";
         AV45UsuarioZona = "";
         AV47EstadoDescripcion = "";
         AV49CiudadDescripcion = "";
         AV50UsuarioNombreCompleto = "";
         AV51UsuarioNoCuentaBROXEL = "";
         AV52UsuarioReferenciaBROXEL = "";
         P003K4_A80FacturaEstatus = new string[] {""} ;
         P003K4_A41PromocionID = new int[1] ;
         P003K4_A29UsuarioID = new int[1] ;
         P003K4_A69FacturaID = new int[1] ;
         P003K4_A42PromocionDescripcion = new string[] {""} ;
         A42PromocionDescripcion = "";
         AV54PromocionDescripcion = "";
         P003K5_A26MedidaID = new int[1] ;
         P003K5_A69FacturaID = new int[1] ;
         P003K5_A22ModeloID = new int[1] ;
         P003K5_A78FacturaMedidaCantidad = new short[1] ;
         P003K5_A77FacturaMedidaID = new int[1] ;
         P003K6_A22ModeloID = new int[1] ;
         P003K6_A41PromocionID = new int[1] ;
         P003K6_A49PromocionModeloPrecio = new decimal[1] ;
         P003K6_A48PromocionModeloID = new int[1] ;
         AV20DistribuidorDescripcion = "";
         AV39Session = context.GetSession();
         P003K7_A10DistribuidorID = new int[1] ;
         P003K7_A29UsuarioID = new int[1] ;
         P003K7_A11DistribuidorDescripcion = new string[] {""} ;
         P003K7_A81DistribuidoresUsuarioID = new int[1] ;
         A11DistribuidorDescripcion = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.generaexcelresumenpromocion__default(),
            new Object[][] {
                new Object[] {
               P003K2_A93FacturaCompleta, P003K2_A80FacturaEstatus, P003K2_A41PromocionID, P003K2_A29UsuarioID, P003K2_A69FacturaID
               }
               , new Object[] {
               P003K3_A4CiudadID, P003K3_n4CiudadID, P003K3_A1EstadoID, P003K3_A29UsuarioID, P003K3_A63UsuarioZona, P003K3_A2EstadoDescripcion, P003K3_A5CiudadDescripcion, P003K3_A82UsuarioNoCuentaBROXEL, P003K3_A83UsuarioReferenciaBROXEL, P003K3_A51UsuarioApellido,
               P003K3_A30UsuarioNombre
               }
               , new Object[] {
               P003K4_A80FacturaEstatus, P003K4_A41PromocionID, P003K4_A29UsuarioID, P003K4_A69FacturaID, P003K4_A42PromocionDescripcion
               }
               , new Object[] {
               P003K5_A26MedidaID, P003K5_A69FacturaID, P003K5_A22ModeloID, P003K5_A78FacturaMedidaCantidad, P003K5_A77FacturaMedidaID
               }
               , new Object[] {
               P003K6_A22ModeloID, P003K6_A41PromocionID, P003K6_A49PromocionModeloPrecio, P003K6_A48PromocionModeloID
               }
               , new Object[] {
               P003K7_A10DistribuidorID, P003K7_A29UsuarioID, P003K7_A11DistribuidorDescripcion, P003K7_A81DistribuidoresUsuarioID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18CellRow ;
      private short AV34i ;
      private short A78FacturaMedidaCantidad ;
      private int AV38PromocionID ;
      private int A41PromocionID ;
      private int A29UsuarioID ;
      private int A69FacturaID ;
      private int AV40UsuarioID ;
      private int AV71GXV1 ;
      private int AV72GXV2 ;
      private int A4CiudadID ;
      private int A1EstadoID ;
      private int AV53FacturaID ;
      private int A26MedidaID ;
      private int A22ModeloID ;
      private int A77FacturaMedidaID ;
      private int AV35ModeloID ;
      private int A48PromocionModeloID ;
      private int A10DistribuidorID ;
      private int A81DistribuidoresUsuarioID ;
      private long AV19Consecutivo ;
      private decimal AV67TotalBono ;
      private decimal AV16BonoUnitario ;
      private decimal A49PromocionModeloPrecio ;
      private decimal AV15BonoTotal ;
      private string GXt_char1 ;
      private string A80FacturaEstatus ;
      private string A63UsuarioZona ;
      private string A82UsuarioNoCuentaBROXEL ;
      private string A83UsuarioReferenciaBROXEL ;
      private string A51UsuarioApellido ;
      private string A30UsuarioNombre ;
      private string AV45UsuarioZona ;
      private string AV51UsuarioNoCuentaBROXEL ;
      private string AV52UsuarioReferenciaBROXEL ;
      private bool A93FacturaCompleta ;
      private bool AV69Existe ;
      private bool n4CiudadID ;
      private bool returnInSub ;
      private string AV28ExcelFilename ;
      private string AV33FileName ;
      private string A2EstadoDescripcion ;
      private string A5CiudadDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string AV47EstadoDescripcion ;
      private string AV49CiudadDescripcion ;
      private string AV50UsuarioNombreCompleto ;
      private string A42PromocionDescripcion ;
      private string AV54PromocionDescripcion ;
      private string AV20DistribuidorDescripcion ;
      private string A11DistribuidorDescripcion ;
      private IGxSession AV39Session ;
      private ExcelDocumentI AV27ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtUsuarioSDT_UsuarioSDTItem> AV41UsuarioSDT ;
      private IDataStoreProvider pr_default ;
      private bool[] P003K2_A93FacturaCompleta ;
      private string[] P003K2_A80FacturaEstatus ;
      private int[] P003K2_A41PromocionID ;
      private int[] P003K2_A29UsuarioID ;
      private int[] P003K2_A69FacturaID ;
      private SdtUsuarioSDT_UsuarioSDTItem AV43u ;
      private SdtUsuarioSDT_UsuarioSDTItem AV68UsuarioSDTItem ;
      private int[] P003K3_A4CiudadID ;
      private bool[] P003K3_n4CiudadID ;
      private int[] P003K3_A1EstadoID ;
      private int[] P003K3_A29UsuarioID ;
      private string[] P003K3_A63UsuarioZona ;
      private string[] P003K3_A2EstadoDescripcion ;
      private string[] P003K3_A5CiudadDescripcion ;
      private string[] P003K3_A82UsuarioNoCuentaBROXEL ;
      private string[] P003K3_A83UsuarioReferenciaBROXEL ;
      private string[] P003K3_A51UsuarioApellido ;
      private string[] P003K3_A30UsuarioNombre ;
      private string[] P003K4_A80FacturaEstatus ;
      private int[] P003K4_A41PromocionID ;
      private int[] P003K4_A29UsuarioID ;
      private int[] P003K4_A69FacturaID ;
      private string[] P003K4_A42PromocionDescripcion ;
      private int[] P003K5_A26MedidaID ;
      private int[] P003K5_A69FacturaID ;
      private int[] P003K5_A22ModeloID ;
      private short[] P003K5_A78FacturaMedidaCantidad ;
      private int[] P003K5_A77FacturaMedidaID ;
      private int[] P003K6_A22ModeloID ;
      private int[] P003K6_A41PromocionID ;
      private decimal[] P003K6_A49PromocionModeloPrecio ;
      private int[] P003K6_A48PromocionModeloID ;
      private int[] P003K7_A10DistribuidorID ;
      private int[] P003K7_A29UsuarioID ;
      private string[] P003K7_A11DistribuidorDescripcion ;
      private int[] P003K7_A81DistribuidoresUsuarioID ;
      private string aP1_ExcelFilename ;
   }

   public class generaexcelresumenpromocion__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP003K2;
          prmP003K2 = new Object[] {
          new ParDef("@AV38PromocionID",GXType.Int32,9,0)
          };
          Object[] prmP003K3;
          prmP003K3 = new Object[] {
          new ParDef("@AV40UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmP003K4;
          prmP003K4 = new Object[] {
          new ParDef("@AV38PromocionID",GXType.Int32,9,0) ,
          new ParDef("@AV40UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmP003K5;
          prmP003K5 = new Object[] {
          new ParDef("@AV53FacturaID",GXType.Int32,9,0)
          };
          Object[] prmP003K6;
          prmP003K6 = new Object[] {
          new ParDef("@AV38PromocionID",GXType.Int32,9,0) ,
          new ParDef("@AV35ModeloID",GXType.Int32,9,0)
          };
          Object[] prmP003K7;
          prmP003K7 = new Object[] {
          new ParDef("@AV40UsuarioID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003K2", "SELECT `FacturaCompleta`, `FacturaEstatus`, `PromocionID`, `UsuarioID`, `FacturaID` FROM `Factura` WHERE (`PromocionID` = @AV38PromocionID) AND (`FacturaEstatus` = 'Aprobada') AND (`FacturaCompleta` = 1) ORDER BY `PromocionID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P003K3", "SELECT T1.`CiudadID`, T2.`EstadoID`, T1.`UsuarioID`, T1.`UsuarioZona`, T3.`EstadoDescripcion`, T2.`CiudadDescripcion`, T1.`UsuarioNoCuentaBROXEL`, T1.`UsuarioReferenciaBROXEL`, T1.`UsuarioApellido`, T1.`UsuarioNombre` FROM ((`Usuario` T1 LEFT JOIN `Ciudad` T2 ON T2.`CiudadID` = T1.`CiudadID`) LEFT JOIN `Estado` T3 ON T3.`EstadoID` = T2.`EstadoID`) WHERE T1.`UsuarioID` = @AV40UsuarioID ORDER BY T1.`UsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003K4", "SELECT T1.`FacturaEstatus`, T1.`PromocionID`, T1.`UsuarioID`, T1.`FacturaID`, T2.`PromocionDescripcion` FROM (`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) WHERE (T1.`PromocionID` = @AV38PromocionID) AND (T1.`UsuarioID` = @AV40UsuarioID) AND (T1.`FacturaEstatus` = 'Aprobada') ORDER BY T1.`PromocionID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003K5", "SELECT T1.`MedidaID`, T1.`FacturaID`, T2.`ModeloID`, T1.`FacturaMedidaCantidad`, T1.`FacturaMedidaID` FROM (`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) WHERE T1.`FacturaID` = @AV53FacturaID ORDER BY T1.`FacturaID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003K6", "SELECT `ModeloID`, `PromocionID`, `PromocionModeloPrecio`, `PromocionModeloID` FROM `PromocionModelo` WHERE `PromocionID` = @AV38PromocionID and `ModeloID` = @AV35ModeloID ORDER BY `PromocionID`, `ModeloID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003K7", "SELECT T1.`DistribuidorID`, T1.`UsuarioID`, T2.`DistribuidorDescripcion`, T1.`DistribuidoresUsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Distribuidor` T2 ON T2.`DistribuidorID` = T1.`DistribuidorID`) WHERE T1.`UsuarioID` = @AV40UsuarioID ORDER BY T1.`UsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K7,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 30);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((string[]) buf[9])[0] = rslt.getString(9, 50);
                ((string[]) buf[10])[0] = rslt.getString(10, 50);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
