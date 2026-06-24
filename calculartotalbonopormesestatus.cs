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
   public class calculartotalbonopormesestatus : GXProcedure
   {
      public calculartotalbonopormesestatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public calculartotalbonopormesestatus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_Mes ,
                           short aP1_Year ,
                           string aP2_Estatus ,
                           out decimal aP3_TotalBono )
      {
         this.AV22Mes = aP0_Mes;
         this.AV24Year = aP1_Year;
         this.AV23Estatus = aP2_Estatus;
         this.AV21TotalBono = 0 ;
         initialize();
         ExecuteImpl();
         aP3_TotalBono=this.AV21TotalBono;
      }

      public decimal executeUdp( short aP0_Mes ,
                                 short aP1_Year ,
                                 string aP2_Estatus )
      {
         execute(aP0_Mes, aP1_Year, aP2_Estatus, out aP3_TotalBono);
         return AV21TotalBono ;
      }

      public void executeSubmit( short aP0_Mes ,
                                 short aP1_Year ,
                                 string aP2_Estatus ,
                                 out decimal aP3_TotalBono )
      {
         this.AV22Mes = aP0_Mes;
         this.AV24Year = aP1_Year;
         this.AV23Estatus = aP2_Estatus;
         this.AV21TotalBono = 0 ;
         SubmitImpl();
         aP3_TotalBono=this.AV21TotalBono;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21TotalBono = 0;
         AV25BonoFactura = 0;
         /* Using cursor P003F2 */
         pr_default.execute(0, new Object[] {AV23Estatus, AV22Mes, AV24Year});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A93FacturaCompleta = P003F2_A93FacturaCompleta[0];
            A80FacturaEstatus = P003F2_A80FacturaEstatus[0];
            A73FacturaFechaFactura = P003F2_A73FacturaFechaFactura[0];
            A69FacturaID = P003F2_A69FacturaID[0];
            AV25BonoFactura = 0;
            new calculartotalbonofactura(context ).execute(  A69FacturaID, out  AV25BonoFactura) ;
            AV21TotalBono = (decimal)(AV21TotalBono+AV25BonoFactura);
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
         P003F2_A93FacturaCompleta = new bool[] {false} ;
         P003F2_A80FacturaEstatus = new string[] {""} ;
         P003F2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         P003F2_A69FacturaID = new int[1] ;
         A80FacturaEstatus = "";
         A73FacturaFechaFactura = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.calculartotalbonopormesestatus__default(),
            new Object[][] {
                new Object[] {
               P003F2_A93FacturaCompleta, P003F2_A80FacturaEstatus, P003F2_A73FacturaFechaFactura, P003F2_A69FacturaID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22Mes ;
      private short AV24Year ;
      private int A69FacturaID ;
      private decimal AV21TotalBono ;
      private decimal AV25BonoFactura ;
      private string AV23Estatus ;
      private string A80FacturaEstatus ;
      private DateTime A73FacturaFechaFactura ;
      private bool A93FacturaCompleta ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P003F2_A93FacturaCompleta ;
      private string[] P003F2_A80FacturaEstatus ;
      private DateTime[] P003F2_A73FacturaFechaFactura ;
      private int[] P003F2_A69FacturaID ;
      private decimal aP3_TotalBono ;
   }

   public class calculartotalbonopormesestatus__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003F2;
          prmP003F2 = new Object[] {
          new ParDef("@AV23Estatus",GXType.Char,20,0) ,
          new ParDef("@AV22Mes",GXType.Int16,4,0) ,
          new ParDef("@AV24Year",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003F2", "SELECT `FacturaCompleta`, `FacturaEstatus`, `FacturaFechaFactura`, `FacturaID` FROM `Factura` WHERE (`FacturaEstatus` = @AV23Estatus) AND (month(`FacturaFechaFactura`) = @AV22Mes) AND (year(`FacturaFechaFactura`) = @AV24Year) AND (`FacturaCompleta` = 1) ORDER BY `FacturaEstatus` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003F2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
