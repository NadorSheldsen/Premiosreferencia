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
   public class atestjwt : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new atestjwt().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         string aP0_responseHtml = new string(' ',0)  ;
         string aP1_token = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_responseHtml=((string)(args[0]));
         }
         else
         {
            aP0_responseHtml="";
         }
         if ( 1 < args.Length )
         {
            aP1_token=((string)(args[1]));
         }
         else
         {
            aP1_token="";
         }
         execute(out aP0_responseHtml, out aP1_token);
         return GX.GXRuntime.ExitCode ;
      }

      public atestjwt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public atestjwt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_responseHtml ,
                           out string aP1_token )
      {
         this.AV33responseHtml = "" ;
         this.AV23token = "" ;
         initialize();
         ExecuteImpl();
         aP0_responseHtml=this.AV33responseHtml;
         aP1_token=this.AV23token;
      }

      public string executeUdp( out string aP0_responseHtml )
      {
         execute(out aP0_responseHtml, out aP1_token);
         return AV23token ;
      }

      public void executeSubmit( out string aP0_responseHtml ,
                                 out string aP1_token )
      {
         this.AV33responseHtml = "" ;
         this.AV23token = "" ;
         SubmitImpl();
         aP0_responseHtml=this.AV33responseHtml;
         aP1_token=this.AV23token;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV41hex = "EFBFBDEFBFBDEFBFBDEFBFBD3FEFBFBD60D884EFBFBD0E394B39EFBFBD7F3671222414EFBFBD1AEFBFBDEFBFBDE398911340EFBFBD";
         AV21SymmetricKey = AV28HexaEncoder.fromhexa(AV41hex);
         if ( AV28HexaEncoder.haserror() )
         {
            AV23token = context.GetMessage( "Error del hexa: ", "") + AV21SymmetricKey;
            AV33responseHtml = AV28HexaEncoder.geterrorcode() + ": " + AV28HexaEncoder.geterrordescription();
         }
         else
         {
            AV12PrivateClaims.setclaim( context.GetMessage( "email", ""),  context.GetMessage( "javier@gmail.com", ""));
            AV12PrivateClaims.setclaim( context.GetMessage( "name", ""),  context.GetMessage( "Javier", ""));
            AV12PrivateClaims.setclaim( context.GetMessage( "firstName", ""),  context.GetMessage( "Ugalde", ""));
            AV12PrivateClaims.setclaim( context.GetMessage( "lastName", ""),  context.GetMessage( "Orozco", ""));
            AV17JWTOptions.addcustomtimevalidationclaim( "exp",  "2030/07/07 10:15:20",  "0");
            AV17JWTOptions.addregisteredclaim( "jti",  context.GetMessage( "0696bb20-6223-4a1c-9ebf-e15c74387b9c", ""));
            AV17JWTOptions.setsecret( AV41hex);
            AV23token = AV16JWTCreator.docreate("HS256", AV12PrivateClaims, AV17JWTOptions);
            if ( ! AV16JWTCreator.haserror() )
            {
               AV30httpClient.Host = context.GetMessage( "yokohama.kiubix.biz", "");
               AV30httpClient.Secure = 1;
               AV30httpClient.AddHeader(context.GetMessage( "Content-Type", ""), "multipart/form-data");
               AV30httpClient.AddVariable(context.GetMessage( "jwt", ""), AV23token);
               AV30httpClient.Execute(context.GetMessage( "POST", ""), context.GetMessage( "/auth/fromExternal", ""));
               AV33responseHtml = AV30httpClient.ToString();
            }
            else
            {
               AV23token = context.GetMessage( "Hexa generado: ", "") + AV21SymmetricKey + context.GetMessage( ". Hexa convertido nuevamente: ", "") + AV28HexaEncoder.tohexa(AV21SymmetricKey);
               AV33responseHtml = AV16JWTCreator.geterrorcode() + ": " + AV16JWTCreator.geterrordescription();
            }
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
         AV33responseHtml = "";
         AV23token = "";
         AV41hex = "";
         AV21SymmetricKey = "";
         AV28HexaEncoder = new GeneXus.Programs.securityapicommons.SdtHexaEncoder(context);
         AV12PrivateClaims = new GeneXus.Programs.genexusjwt.SdtPrivateClaims(context);
         AV17JWTOptions = new GeneXus.Programs.genexusjwt.SdtJWTOptions(context);
         AV16JWTCreator = new GeneXus.Programs.genexusjwt.SdtJWTCreator(context);
         AV30httpClient = new GxHttpClient( context);
         /* GeneXus formulas. */
      }

      private string AV33responseHtml ;
      private string AV23token ;
      private string AV41hex ;
      private string AV21SymmetricKey ;
      private GxHttpClient AV30httpClient ;
      private GeneXus.Programs.securityapicommons.SdtHexaEncoder AV28HexaEncoder ;
      private GeneXus.Programs.genexusjwt.SdtPrivateClaims AV12PrivateClaims ;
      private GeneXus.Programs.genexusjwt.SdtJWTOptions AV17JWTOptions ;
      private GeneXus.Programs.genexusjwt.SdtJWTCreator AV16JWTCreator ;
      private string aP0_responseHtml ;
      private string aP1_token ;
   }

}
