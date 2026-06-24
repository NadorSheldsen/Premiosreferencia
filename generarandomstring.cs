using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class generarandomstring : GXProcedure
   {
      public generarandomstring( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public generarandomstring( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_Result )
      {
         this.AV10Result = "" ;
         initialize();
         ExecuteImpl();
         aP0_Result=this.AV10Result;
      }

      public string executeUdp( )
      {
         execute(out aP0_Result);
         return AV10Result ;
      }

      public void executeSubmit( out string aP0_Result )
      {
         this.AV10Result = "" ;
         SubmitImpl();
         aP0_Result=this.AV10Result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Length = 10;
         AV9Chars = context.GetMessage( "0123456789abcdefghijklmnopqrstuvwxyz", "");
         AV10Result = "";
         AV11i = 1;
         while ( AV11i <= AV8Length )
         {
            AV12Index = (short)(NumberUtil.Trunc( (decimal)(NumberUtil.Random( )*StringUtil.Len( AV9Chars)), 0)+1);
            AV10Result += StringUtil.Substring( AV9Chars, AV12Index, 1);
            AV11i = (short)(AV11i+1);
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
         AV10Result = "";
         AV9Chars = "";
         /* GeneXus formulas. */
      }

      private short AV8Length ;
      private short AV11i ;
      private short AV12Index ;
      private string AV10Result ;
      private string AV9Chars ;
      private string aP0_Result ;
   }

}
