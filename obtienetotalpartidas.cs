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
   public class obtienetotalpartidas : GXProcedure
   {
      public obtienetotalpartidas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtienetotalpartidas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_FacturaID ,
                           out decimal aP1_TotalBono )
      {
         this.AV8FacturaID = aP0_FacturaID;
         this.AV9TotalBono = 0 ;
         initialize();
         ExecuteImpl();
         aP1_TotalBono=this.AV9TotalBono;
      }

      public decimal executeUdp( int aP0_FacturaID )
      {
         execute(aP0_FacturaID, out aP1_TotalBono);
         return AV9TotalBono ;
      }

      public void executeSubmit( int aP0_FacturaID ,
                                 out decimal aP1_TotalBono )
      {
         this.AV8FacturaID = aP0_FacturaID;
         this.AV9TotalBono = 0 ;
         SubmitImpl();
         aP1_TotalBono=this.AV9TotalBono;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9TotalBono = 0;
         AV10BonoUnitario = 0;
         AV11BonoTotal = 0;
         /* Using cursor P003B2 */
         pr_default.execute(0, new Object[] {AV8FacturaID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A26MedidaID = P003B2_A26MedidaID[0];
            A69FacturaID = P003B2_A69FacturaID[0];
            A41PromocionID = P003B2_A41PromocionID[0];
            A22ModeloID = P003B2_A22ModeloID[0];
            A78FacturaMedidaCantidad = P003B2_A78FacturaMedidaCantidad[0];
            A77FacturaMedidaID = P003B2_A77FacturaMedidaID[0];
            A22ModeloID = P003B2_A22ModeloID[0];
            A41PromocionID = P003B2_A41PromocionID[0];
            AV10BonoUnitario = 0;
            AV13PromocionID = A41PromocionID;
            AV15ModeloID = A22ModeloID;
            /* Using cursor P003B3 */
            pr_default.execute(1, new Object[] {AV13PromocionID, AV15ModeloID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A22ModeloID = P003B3_A22ModeloID[0];
               A41PromocionID = P003B3_A41PromocionID[0];
               A49PromocionModeloPrecio = P003B3_A49PromocionModeloPrecio[0];
               A48PromocionModeloID = P003B3_A48PromocionModeloID[0];
               AV10BonoUnitario = A49PromocionModeloPrecio;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV11BonoTotal = (decimal)(AV10BonoUnitario*A78FacturaMedidaCantidad);
            AV9TotalBono = (decimal)(AV9TotalBono+AV11BonoTotal);
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
         P003B2_A26MedidaID = new int[1] ;
         P003B2_A69FacturaID = new int[1] ;
         P003B2_A41PromocionID = new int[1] ;
         P003B2_A22ModeloID = new int[1] ;
         P003B2_A78FacturaMedidaCantidad = new short[1] ;
         P003B2_A77FacturaMedidaID = new int[1] ;
         P003B3_A22ModeloID = new int[1] ;
         P003B3_A41PromocionID = new int[1] ;
         P003B3_A49PromocionModeloPrecio = new decimal[1] ;
         P003B3_A48PromocionModeloID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtienetotalpartidas__default(),
            new Object[][] {
                new Object[] {
               P003B2_A26MedidaID, P003B2_A69FacturaID, P003B2_A41PromocionID, P003B2_A22ModeloID, P003B2_A78FacturaMedidaCantidad, P003B2_A77FacturaMedidaID
               }
               , new Object[] {
               P003B3_A22ModeloID, P003B3_A41PromocionID, P003B3_A49PromocionModeloPrecio, P003B3_A48PromocionModeloID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A78FacturaMedidaCantidad ;
      private int AV8FacturaID ;
      private int A26MedidaID ;
      private int A69FacturaID ;
      private int A41PromocionID ;
      private int A22ModeloID ;
      private int A77FacturaMedidaID ;
      private int AV13PromocionID ;
      private int AV15ModeloID ;
      private int A48PromocionModeloID ;
      private decimal AV9TotalBono ;
      private decimal AV10BonoUnitario ;
      private decimal AV11BonoTotal ;
      private decimal A49PromocionModeloPrecio ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P003B2_A26MedidaID ;
      private int[] P003B2_A69FacturaID ;
      private int[] P003B2_A41PromocionID ;
      private int[] P003B2_A22ModeloID ;
      private short[] P003B2_A78FacturaMedidaCantidad ;
      private int[] P003B2_A77FacturaMedidaID ;
      private int[] P003B3_A22ModeloID ;
      private int[] P003B3_A41PromocionID ;
      private decimal[] P003B3_A49PromocionModeloPrecio ;
      private int[] P003B3_A48PromocionModeloID ;
      private decimal aP1_TotalBono ;
   }

   public class obtienetotalpartidas__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP003B2;
          prmP003B2 = new Object[] {
          new ParDef("@AV8FacturaID",GXType.Int32,9,0)
          };
          Object[] prmP003B3;
          prmP003B3 = new Object[] {
          new ParDef("@AV13PromocionID",GXType.Int32,9,0) ,
          new ParDef("@AV15ModeloID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003B2", "SELECT T1.`MedidaID`, T1.`FacturaID`, T3.`PromocionID`, T2.`ModeloID`, T1.`FacturaMedidaCantidad`, T1.`FacturaMedidaID` FROM ((`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) INNER JOIN `Factura` T3 ON T3.`FacturaID` = T1.`FacturaID`) WHERE T1.`FacturaID` = @AV8FacturaID ORDER BY T1.`FacturaID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003B2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003B3", "SELECT `ModeloID`, `PromocionID`, `PromocionModeloPrecio`, `PromocionModeloID` FROM `PromocionModelo` WHERE `PromocionID` = @AV13PromocionID and `ModeloID` = @AV15ModeloID ORDER BY `PromocionID`, `ModeloID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003B3,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
