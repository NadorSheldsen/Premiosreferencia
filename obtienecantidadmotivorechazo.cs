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
   public class obtienecantidadmotivorechazo : GXProcedure
   {
      public obtienecantidadmotivorechazo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtienecantidadmotivorechazo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_MotivoRechazoID ,
                           out short aP1_Count )
      {
         this.AV8MotivoRechazoID = aP0_MotivoRechazoID;
         this.AV9Count = 0 ;
         initialize();
         ExecuteImpl();
         aP1_Count=this.AV9Count;
      }

      public short executeUdp( int aP0_MotivoRechazoID )
      {
         execute(aP0_MotivoRechazoID, out aP1_Count);
         return AV9Count ;
      }

      public void executeSubmit( int aP0_MotivoRechazoID ,
                                 out short aP1_Count )
      {
         this.AV8MotivoRechazoID = aP0_MotivoRechazoID;
         this.AV9Count = 0 ;
         SubmitImpl();
         aP1_Count=this.AV9Count;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Count = 0;
         /* Optimized group. */
         /* Using cursor P00332 */
         pr_default.execute(0, new Object[] {AV8MotivoRechazoID});
         cV9Count = P00332_AV9Count[0];
         pr_default.close(0);
         AV9Count = (short)(AV9Count+cV9Count*1);
         /* End optimized group. */
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
         P00332_AV9Count = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtienecantidadmotivorechazo__default(),
            new Object[][] {
                new Object[] {
               P00332_AV9Count
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9Count ;
      private short cV9Count ;
      private int AV8MotivoRechazoID ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00332_AV9Count ;
      private short aP1_Count ;
   }

   public class obtienecantidadmotivorechazo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00332;
          prmP00332 = new Object[] {
          new ParDef("@AV8MotivoRechazoID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00332", "SELECT COUNT(*) FROM `Factura` WHERE (`MotivoRechazoID` = @AV8MotivoRechazoID) AND (`FacturaEstatus` = 'Rechazada') ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00332,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
