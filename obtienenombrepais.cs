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
   public class obtienenombrepais : GXProcedure
   {
      public obtienenombrepais( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtienenombrepais( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PaisID ,
                           out string aP1_PaisDescripcion )
      {
         this.AV8PaisID = aP0_PaisID;
         this.AV9PaisDescripcion = "" ;
         initialize();
         ExecuteImpl();
         aP1_PaisDescripcion=this.AV9PaisDescripcion;
      }

      public string executeUdp( int aP0_PaisID )
      {
         execute(aP0_PaisID, out aP1_PaisDescripcion);
         return AV9PaisDescripcion ;
      }

      public void executeSubmit( int aP0_PaisID ,
                                 out string aP1_PaisDescripcion )
      {
         this.AV8PaisID = aP0_PaisID;
         this.AV9PaisDescripcion = "" ;
         SubmitImpl();
         aP1_PaisDescripcion=this.AV9PaisDescripcion;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P002D2 */
         pr_default.execute(0, new Object[] {AV8PaisID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A16PaisID = P002D2_A16PaisID[0];
            A17PaisDescripcion = P002D2_A17PaisDescripcion[0];
            AV9PaisDescripcion = A17PaisDescripcion;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV9PaisDescripcion = "";
         P002D2_A16PaisID = new int[1] ;
         P002D2_A17PaisDescripcion = new string[] {""} ;
         A17PaisDescripcion = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtienenombrepais__default(),
            new Object[][] {
                new Object[] {
               P002D2_A16PaisID, P002D2_A17PaisDescripcion
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV8PaisID ;
      private int A16PaisID ;
      private string AV9PaisDescripcion ;
      private string A17PaisDescripcion ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P002D2_A16PaisID ;
      private string[] P002D2_A17PaisDescripcion ;
      private string aP1_PaisDescripcion ;
   }

   public class obtienenombrepais__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002D2;
          prmP002D2 = new Object[] {
          new ParDef("@AV8PaisID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002D2", "SELECT `PaisID`, `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @AV8PaisID ORDER BY `PaisID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D2,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
