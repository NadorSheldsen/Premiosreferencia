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
   public class testjwt : GXProcedure
   {
      public testjwt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public testjwt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_responseHtml ,
                           out string aP1_token )
      {
         this.AV2responseHtml = "" ;
         this.AV3token = "" ;
         initialize();
         ExecuteImpl();
         aP0_responseHtml=this.AV2responseHtml;
         aP1_token=this.AV3token;
      }

      public string executeUdp( out string aP0_responseHtml )
      {
         execute(out aP0_responseHtml, out aP1_token);
         return AV3token ;
      }

      public void executeSubmit( out string aP0_responseHtml ,
                                 out string aP1_token )
      {
         this.AV2responseHtml = "" ;
         this.AV3token = "" ;
         SubmitImpl();
         aP0_responseHtml=this.AV2responseHtml;
         aP1_token=this.AV3token;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2responseHtml,(string)AV3token} ;
         ClassLoader.Execute("atestjwt","GeneXus.Programs","atestjwt", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV2responseHtml = (string)(args[0]) ;
            AV3token = (string)(args[1]) ;
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
         AV2responseHtml = "";
         AV3token = "";
         /* GeneXus formulas. */
      }

      private string AV2responseHtml ;
      private string AV3token ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP0_responseHtml ;
      private string aP1_token ;
   }

}
