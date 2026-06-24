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
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class dpgraficamodelos : GXProcedure
   {
      public dpgraficamodelos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpgraficamodelos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDTGraficaModelos_SDTGraficaModelosItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTGraficaModelos_SDTGraficaModelosItem>( context, "SDTGraficaModelosItem", "Premios") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTGraficaModelos_SDTGraficaModelosItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTGraficaModelos_SDTGraficaModelosItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTGraficaModelos_SDTGraficaModelosItem>( context, "SDTGraficaModelosItem", "Premios") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P000H2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A26MedidaID = P000H2_A26MedidaID[0];
            A23ModeloDescripcion = P000H2_A23ModeloDescripcion[0];
            A22ModeloID = P000H2_A22ModeloID[0];
            A77FacturaMedidaID = P000H2_A77FacturaMedidaID[0];
            A22ModeloID = P000H2_A22ModeloID[0];
            A23ModeloDescripcion = P000H2_A23ModeloDescripcion[0];
            Gxm1sdtgraficamodelos = new SdtSDTGraficaModelos_SDTGraficaModelosItem(context);
            Gxm2rootcol.Add(Gxm1sdtgraficamodelos, 0);
            Gxm1sdtgraficamodelos.gxTpr_Modelodescripcion = A23ModeloDescripcion;
            GXt_decimal1 = 0;
            new calculartotalpormodelo(context ).execute(  A22ModeloID, out  GXt_decimal1) ;
            Gxm1sdtgraficamodelos.gxTpr_Total = GXt_decimal1;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P000H2_A26MedidaID = new int[1] ;
         P000H2_A23ModeloDescripcion = new string[] {""} ;
         P000H2_A22ModeloID = new int[1] ;
         P000H2_A77FacturaMedidaID = new int[1] ;
         A23ModeloDescripcion = "";
         Gxm1sdtgraficamodelos = new SdtSDTGraficaModelos_SDTGraficaModelosItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpgraficamodelos__default(),
            new Object[][] {
                new Object[] {
               P000H2_A26MedidaID, P000H2_A23ModeloDescripcion, P000H2_A22ModeloID, P000H2_A77FacturaMedidaID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A26MedidaID ;
      private int A22ModeloID ;
      private int A77FacturaMedidaID ;
      private decimal GXt_decimal1 ;
      private string A23ModeloDescripcion ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTGraficaModelos_SDTGraficaModelosItem> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private int[] P000H2_A26MedidaID ;
      private string[] P000H2_A23ModeloDescripcion ;
      private int[] P000H2_A22ModeloID ;
      private int[] P000H2_A77FacturaMedidaID ;
      private SdtSDTGraficaModelos_SDTGraficaModelosItem Gxm1sdtgraficamodelos ;
      private GXBaseCollection<SdtSDTGraficaModelos_SDTGraficaModelosItem> aP0_Gxm2rootcol ;
   }

   public class dpgraficamodelos__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000H2;
          prmP000H2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000H2", "SELECT T1.`MedidaID`, T3.`ModeloDescripcion`, T2.`ModeloID`, T1.`FacturaMedidaID` FROM ((`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T3 ON T3.`ModeloID` = T2.`ModeloID`) ORDER BY T1.`FacturaMedidaID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
