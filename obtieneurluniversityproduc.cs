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
   public class obtieneurluniversityproduc : GXProcedure
   {
      public obtieneurluniversityproduc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtieneurluniversityproduc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_UsuarioID ,
                           out string aP1_FinalURL )
      {
         this.AV23UsuarioID = aP0_UsuarioID;
         this.AV10FinalURL = "" ;
         initialize();
         ExecuteImpl();
         aP1_FinalURL=this.AV10FinalURL;
      }

      public string executeUdp( int aP0_UsuarioID )
      {
         execute(aP0_UsuarioID, out aP1_FinalURL);
         return AV10FinalURL ;
      }

      public void executeSubmit( int aP0_UsuarioID ,
                                 out string aP1_FinalURL )
      {
         this.AV23UsuarioID = aP0_UsuarioID;
         this.AV10FinalURL = "" ;
         SubmitImpl();
         aP1_FinalURL=this.AV10FinalURL;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12httpClient.Execute(context.GetMessage( "GET", ""), context.GetMessage( "https://tutorialesyokohama.com/auth/getTokenToAuth?token=93E8FFCF3FA260D884F20E394B39C37F36712224149C1A858A00E398911340F8", ""));
         AV18responseText = AV12httpClient.ToString();
         AV22TokenResponse.FromJSonString(AV18responseText, null);
         if ( AV22TokenResponse.gxTpr_Status )
         {
            AV21Token = AV22TokenResponse.gxTpr_Token;
            /* Execute user subroutine: 'OBTIENEINFOUSUARIO' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            AV10FinalURL = "https://tutorialesyokohama.com/auth/fromExternal";
            AV10FinalURL += context.GetMessage( "?name=", "") + GXUtil.UrlEncode( StringUtil.Trim( AV14Name));
            AV10FinalURL += context.GetMessage( "&firstName=", "") + GXUtil.UrlEncode( StringUtil.Trim( AV11FirstName));
            AV10FinalURL += context.GetMessage( "&lastName=", "") + GXUtil.UrlEncode( StringUtil.Trim( AV13LastName));
            AV10FinalURL += context.GetMessage( "&email=", "") + GXUtil.UrlEncode( StringUtil.Trim( AV9Email));
            AV10FinalURL += context.GetMessage( "&token=", "") + GXUtil.UrlEncode( StringUtil.Trim( AV21Token));
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OBTIENEINFOUSUARIO' Routine */
         returnInSub = false;
         /* Using cursor P003Y2 */
         pr_default.execute(0, new Object[] {AV23UsuarioID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29UsuarioID = P003Y2_A29UsuarioID[0];
            A30UsuarioNombre = P003Y2_A30UsuarioNombre[0];
            A51UsuarioApellido = P003Y2_A51UsuarioApellido[0];
            A31UsuarioCorreo = P003Y2_A31UsuarioCorreo[0];
            AV14Name = A30UsuarioNombre;
            AV8Apellidos = StringUtil.Trim( A51UsuarioApellido);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8Apellidos)) )
            {
               AV11FirstName = "-";
               AV13LastName = "-";
            }
            else
            {
               AV15Partes = (GxSimpleCollection<string>)(GxRegex.Split(AV8Apellidos,context.GetMessage( "\\s+", "")));
               AV11FirstName = ((AV15Partes.Count>=1) ? ((string)AV15Partes.Item(1)) : "-");
               if ( AV15Partes.Count == 1 )
               {
                  AV13LastName = "-";
               }
               if ( AV15Partes.Count >= 2 )
               {
                  AV13LastName = ((string)AV15Partes.Item(2));
                  AV24i = 3;
                  while ( AV24i <= AV15Partes.Count )
                  {
                     AV13LastName += " " + ((string)AV15Partes.Item(AV24i));
                     AV24i = (short)(AV24i+1);
                  }
               }
            }
            AV9Email = A31UsuarioCorreo;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
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
         AV10FinalURL = "";
         AV12httpClient = new GxHttpClient( context);
         AV18responseText = "";
         AV22TokenResponse = new SdtTokenResponse(context);
         AV21Token = "";
         AV14Name = "";
         AV11FirstName = "";
         AV13LastName = "";
         AV9Email = "";
         P003Y2_A29UsuarioID = new int[1] ;
         P003Y2_A30UsuarioNombre = new string[] {""} ;
         P003Y2_A51UsuarioApellido = new string[] {""} ;
         P003Y2_A31UsuarioCorreo = new string[] {""} ;
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A31UsuarioCorreo = "";
         AV8Apellidos = "";
         AV15Partes = new GxSimpleCollection<string>();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtieneurluniversityproduc__default(),
            new Object[][] {
                new Object[] {
               P003Y2_A29UsuarioID, P003Y2_A30UsuarioNombre, P003Y2_A51UsuarioApellido, P003Y2_A31UsuarioCorreo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24i ;
      private int AV23UsuarioID ;
      private int A29UsuarioID ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
      private bool returnInSub ;
      private string AV10FinalURL ;
      private string AV18responseText ;
      private string AV21Token ;
      private string AV14Name ;
      private string AV11FirstName ;
      private string AV13LastName ;
      private string AV9Email ;
      private string A31UsuarioCorreo ;
      private string AV8Apellidos ;
      private GxHttpClient AV12httpClient ;
      private IGxDataStore dsDefault ;
      private SdtTokenResponse AV22TokenResponse ;
      private IDataStoreProvider pr_default ;
      private int[] P003Y2_A29UsuarioID ;
      private string[] P003Y2_A30UsuarioNombre ;
      private string[] P003Y2_A51UsuarioApellido ;
      private string[] P003Y2_A31UsuarioCorreo ;
      private GxSimpleCollection<string> AV15Partes ;
      private string aP1_FinalURL ;
   }

   public class obtieneurluniversityproduc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003Y2;
          prmP003Y2 = new Object[] {
          new ParDef("@AV23UsuarioID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003Y2", "SELECT `UsuarioID`, `UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo` FROM `Usuario` WHERE `UsuarioID` = @AV23UsuarioID ORDER BY `UsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Y2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
