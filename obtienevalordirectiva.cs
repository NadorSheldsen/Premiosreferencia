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
   public class obtienevalordirectiva : GXProcedure
   {
      public obtienevalordirectiva( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtienevalordirectiva( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnDirectivaTitle ,
                           out string aP1_TrnDirectivaValue )
      {
         this.AV8TrnDirectivaTitle = aP0_TrnDirectivaTitle;
         this.AV9TrnDirectivaValue = "" ;
         initialize();
         ExecuteImpl();
         aP1_TrnDirectivaValue=this.AV9TrnDirectivaValue;
      }

      public string executeUdp( string aP0_TrnDirectivaTitle )
      {
         execute(aP0_TrnDirectivaTitle, out aP1_TrnDirectivaValue);
         return AV9TrnDirectivaValue ;
      }

      public void executeSubmit( string aP0_TrnDirectivaTitle ,
                                 out string aP1_TrnDirectivaValue )
      {
         this.AV8TrnDirectivaTitle = aP0_TrnDirectivaTitle;
         this.AV9TrnDirectivaValue = "" ;
         SubmitImpl();
         aP1_TrnDirectivaValue=this.AV9TrnDirectivaValue;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10GXLvl1 = 0;
         /* Using cursor P004H2 */
         pr_default.execute(0, new Object[] {AV8TrnDirectivaTitle});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A89TrnDirectivaTitle = P004H2_A89TrnDirectivaTitle[0];
            A90TrnDirectivaValue = P004H2_A90TrnDirectivaValue[0];
            AV10GXLvl1 = 1;
            AV9TrnDirectivaValue = A90TrnDirectivaValue;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV10GXLvl1 == 0 )
         {
            AV9TrnDirectivaValue = "";
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
         AV9TrnDirectivaValue = "";
         P004H2_A89TrnDirectivaTitle = new string[] {""} ;
         P004H2_A90TrnDirectivaValue = new string[] {""} ;
         A89TrnDirectivaTitle = "";
         A90TrnDirectivaValue = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtienevalordirectiva__default(),
            new Object[][] {
                new Object[] {
               P004H2_A89TrnDirectivaTitle, P004H2_A90TrnDirectivaValue
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10GXLvl1 ;
      private string AV8TrnDirectivaTitle ;
      private string AV9TrnDirectivaValue ;
      private string A89TrnDirectivaTitle ;
      private string A90TrnDirectivaValue ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004H2_A89TrnDirectivaTitle ;
      private string[] P004H2_A90TrnDirectivaValue ;
      private string aP1_TrnDirectivaValue ;
   }

   public class obtienevalordirectiva__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP004H2;
          prmP004H2 = new Object[] {
          new ParDef("@AV8TrnDirectivaTitle",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004H2", "SELECT `TrnDirectivaTitle`, `TrnDirectivaValue` FROM `TrnDirectiva` WHERE `TrnDirectivaTitle` = @AV8TrnDirectivaTitle ORDER BY `TrnDirectivaTitle`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004H2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
