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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class amostrarfacturapdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            GxWebError = 1;
            context.HttpContext.Response.StatusCode = 403;
            context.WriteHtmlText( "<title>403 Forbidden</title>") ;
            context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
            context.WriteHtmlText( "<p /><hr />") ;
            GXUtil.WriteLog("send_http_error_code " + 403.ToString());
         }
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "amostrarfacturapdf.aspx")), "amostrarfacturapdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "amostrarfacturapdf.aspx")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "FacturaId");
            if ( ! entryPointCalled )
            {
               AV8FacturaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public amostrarfacturapdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public amostrarfacturapdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_FacturaId )
      {
         this.AV8FacturaId = aP0_FacturaId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( int aP0_FacturaId )
      {
         this.AV8FacturaId = aP0_FacturaId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00392 */
         pr_default.execute(0, new Object[] {AV8FacturaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A69FacturaID = P00392_A69FacturaID[0];
            A40000FacturaPDF_GXI = P00392_A40000FacturaPDF_GXI[0];
            A75FacturaPDF = P00392_A75FacturaPDF[0];
            if ( ! context.isAjaxRequest( ) )
            {
               AV17HttpResponse.AppendHeader("Content-Type", GXDbFile.GetFileType( A40000FacturaPDF_GXI));
            }
            if ( ! context.isAjaxRequest( ) )
            {
               AV17HttpResponse.AppendHeader("Content-Disposition", "inline; filename="+GXDbFile.GetFileName( A40000FacturaPDF_GXI)+"."+GXDbFile.GetFileType( A40000FacturaPDF_GXI));
            }
            AV18blob = A75FacturaPDF;
            AV17HttpResponse.AddFile(AV18blob);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         GXDecQS = "";
         gxfirstwebparm = "";
         P00392_A69FacturaID = new int[1] ;
         P00392_A40000FacturaPDF_GXI = new string[] {""} ;
         P00392_A75FacturaPDF = new string[] {""} ;
         A40000FacturaPDF_GXI = "";
         A75FacturaPDF = "";
         AV17HttpResponse = new GxHttpResponse( context);
         AV18blob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.amostrarfacturapdf__default(),
            new Object[][] {
                new Object[] {
               P00392_A69FacturaID, P00392_A40000FacturaPDF_GXI, P00392_A75FacturaPDF
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GxWebError ;
      private short nGotPars ;
      private int AV8FacturaId ;
      private int A69FacturaID ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private bool entryPointCalled ;
      private string A40000FacturaPDF_GXI ;
      private string A75FacturaPDF ;
      private string AV18blob ;
      private GxHttpResponse AV17HttpResponse ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00392_A69FacturaID ;
      private string[] P00392_A40000FacturaPDF_GXI ;
      private string[] P00392_A75FacturaPDF ;
   }

   public class amostrarfacturapdf__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00392;
          prmP00392 = new Object[] {
          new ParDef("@AV8FacturaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00392", "SELECT `FacturaID`, `FacturaPDF_GXI`, `FacturaPDF` FROM `Factura` WHERE `FacturaID` = @AV8FacturaId ORDER BY `FacturaID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00392,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
       }
    }

 }

}
