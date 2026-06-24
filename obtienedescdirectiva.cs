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
   public class obtienedescdirectiva : GXProcedure
   {
      public obtienedescdirectiva( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtienedescdirectiva( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnDirectivaTitle ,
                           out string aP1_TrnDirectivaDescripcion )
      {
         this.AV8TrnDirectivaTitle = aP0_TrnDirectivaTitle;
         this.AV19TrnDirectivaDescripcion = "" ;
         initialize();
         ExecuteImpl();
         aP1_TrnDirectivaDescripcion=this.AV19TrnDirectivaDescripcion;
      }

      public string executeUdp( string aP0_TrnDirectivaTitle )
      {
         execute(aP0_TrnDirectivaTitle, out aP1_TrnDirectivaDescripcion);
         return AV19TrnDirectivaDescripcion ;
      }

      public void executeSubmit( string aP0_TrnDirectivaTitle ,
                                 out string aP1_TrnDirectivaDescripcion )
      {
         this.AV8TrnDirectivaTitle = aP0_TrnDirectivaTitle;
         this.AV19TrnDirectivaDescripcion = "" ;
         SubmitImpl();
         aP1_TrnDirectivaDescripcion=this.AV19TrnDirectivaDescripcion;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV20GXLvl1 = 0;
         /* Using cursor P004J2 */
         pr_default.execute(0, new Object[] {AV8TrnDirectivaTitle});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A89TrnDirectivaTitle = P004J2_A89TrnDirectivaTitle[0];
            A91TrnDirectivaDescripcion = P004J2_A91TrnDirectivaDescripcion[0];
            AV20GXLvl1 = 1;
            AV19TrnDirectivaDescripcion = A91TrnDirectivaDescripcion;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV20GXLvl1 == 0 )
         {
            AV19TrnDirectivaDescripcion = "";
         }
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
         AV19TrnDirectivaDescripcion = "";
         P004J2_A89TrnDirectivaTitle = new string[] {""} ;
         P004J2_A91TrnDirectivaDescripcion = new string[] {""} ;
         A89TrnDirectivaTitle = "";
         A91TrnDirectivaDescripcion = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtienedescdirectiva__default(),
            new Object[][] {
                new Object[] {
               P004J2_A89TrnDirectivaTitle, P004J2_A91TrnDirectivaDescripcion
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20GXLvl1 ;
      private string AV19TrnDirectivaDescripcion ;
      private string A91TrnDirectivaDescripcion ;
      private string AV8TrnDirectivaTitle ;
      private string A89TrnDirectivaTitle ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004J2_A89TrnDirectivaTitle ;
      private string[] P004J2_A91TrnDirectivaDescripcion ;
      private string aP1_TrnDirectivaDescripcion ;
   }

   public class obtienedescdirectiva__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP004J2;
          prmP004J2 = new Object[] {
          new ParDef("@AV8TrnDirectivaTitle",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004J2", "SELECT `TrnDirectivaTitle`, `TrnDirectivaDescripcion` FROM `TrnDirectiva` WHERE `TrnDirectivaTitle` = @AV8TrnDirectivaTitle ORDER BY `TrnDirectivaTitle`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004J2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                return;
       }
    }

 }

}
