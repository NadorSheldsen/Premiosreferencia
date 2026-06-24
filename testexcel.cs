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
   public class testexcel : GXProcedure
   {
      public testexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public testexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_ExcelFilename ,
                           out string aP1_ErrorMessage )
      {
         this.AV2ExcelFilename = "" ;
         this.AV3ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP0_ExcelFilename=this.AV2ExcelFilename;
         aP1_ErrorMessage=this.AV3ErrorMessage;
      }

      public string executeUdp( out string aP0_ExcelFilename )
      {
         execute(out aP0_ExcelFilename, out aP1_ErrorMessage);
         return AV3ErrorMessage ;
      }

      public void executeSubmit( out string aP0_ExcelFilename ,
                                 out string aP1_ErrorMessage )
      {
         this.AV2ExcelFilename = "" ;
         this.AV3ErrorMessage = "" ;
         SubmitImpl();
         aP0_ExcelFilename=this.AV2ExcelFilename;
         aP1_ErrorMessage=this.AV3ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2ExcelFilename,(string)AV3ErrorMessage} ;
         ClassLoader.Execute("atestexcel","GeneXus.Programs","atestexcel", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV2ExcelFilename = (string)(args[0]) ;
            AV3ErrorMessage = (string)(args[1]) ;
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
      }

      public override void initialize( )
      {
         AV2ExcelFilename = "";
         AV3ErrorMessage = "";
         /* GeneXus formulas. */
      }

      private string AV2ExcelFilename ;
      private string AV3ErrorMessage ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP0_ExcelFilename ;
      private string aP1_ErrorMessage ;
   }

}
