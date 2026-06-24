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
   public class getcantidadporestatus : GXProcedure
   {
      public getcantidadporestatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getcantidadporestatus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Estatus ,
                           out long aP1_Cantidad )
      {
         this.AV8Estatus = aP0_Estatus;
         this.AV9Cantidad = 0 ;
         initialize();
         ExecuteImpl();
         aP1_Cantidad=this.AV9Cantidad;
      }

      public long executeUdp( string aP0_Estatus )
      {
         execute(aP0_Estatus, out aP1_Cantidad);
         return AV9Cantidad ;
      }

      public void executeSubmit( string aP0_Estatus ,
                                 out long aP1_Cantidad )
      {
         this.AV8Estatus = aP0_Estatus;
         this.AV9Cantidad = 0 ;
         SubmitImpl();
         aP1_Cantidad=this.AV9Cantidad;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Cantidad = 0;
         /* Optimized group. */
         /* Using cursor P00322 */
         pr_default.execute(0, new Object[] {AV8Estatus});
         cV9Cantidad = P00322_AV9Cantidad[0];
         pr_default.close(0);
         AV9Cantidad = (long)(AV9Cantidad+cV9Cantidad*1);
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
         P00322_AV9Cantidad = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getcantidadporestatus__default(),
            new Object[][] {
                new Object[] {
               P00322_AV9Cantidad
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9Cantidad ;
      private long cV9Cantidad ;
      private string AV8Estatus ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00322_AV9Cantidad ;
      private long aP1_Cantidad ;
   }

   public class getcantidadporestatus__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00322;
          prmP00322 = new Object[] {
          new ParDef("@AV8Estatus",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00322", "SELECT COUNT(*) FROM `Factura` WHERE `FacturaEstatus` = @AV8Estatus ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00322,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
