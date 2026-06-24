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
   public class generaexcelpartidas : GXProcedure
   {
      public generaexcelpartidas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public generaexcelpartidas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PromocionID ,
                           out string aP1_ExcelFilename ,
                           out string aP2_ErrorMessage )
      {
         this.AV2PromocionID = aP0_PromocionID;
         this.AV3ExcelFilename = "" ;
         this.AV4ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP1_ExcelFilename=this.AV3ExcelFilename;
         aP2_ErrorMessage=this.AV4ErrorMessage;
      }

      public string executeUdp( int aP0_PromocionID ,
                                out string aP1_ExcelFilename )
      {
         execute(aP0_PromocionID, out aP1_ExcelFilename, out aP2_ErrorMessage);
         return AV4ErrorMessage ;
      }

      public void executeSubmit( int aP0_PromocionID ,
                                 out string aP1_ExcelFilename ,
                                 out string aP2_ErrorMessage )
      {
         this.AV2PromocionID = aP0_PromocionID;
         this.AV3ExcelFilename = "" ;
         this.AV4ErrorMessage = "" ;
         SubmitImpl();
         aP1_ExcelFilename=this.AV3ExcelFilename;
         aP2_ErrorMessage=this.AV4ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(int)AV2PromocionID,(string)AV3ExcelFilename,(string)AV4ErrorMessage} ;
         ClassLoader.Execute("ageneraexcelpartidas","GeneXus.Programs","ageneraexcelpartidas", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV3ExcelFilename = (string)(args[1]) ;
            AV4ErrorMessage = (string)(args[2]) ;
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
         AV3ExcelFilename = "";
         AV4ErrorMessage = "";
         /* GeneXus formulas. */
      }

      private int AV2PromocionID ;
      private string AV3ExcelFilename ;
      private string AV4ErrorMessage ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP1_ExcelFilename ;
      private string aP2_ErrorMessage ;
   }

}
