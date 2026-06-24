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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class atestexcel : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new atestexcel().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         string aP0_ExcelFilename = new string(' ',0)  ;
         string aP1_ErrorMessage = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_ExcelFilename=((string)(args[0]));
         }
         else
         {
            aP0_ExcelFilename="";
         }
         if ( 1 < args.Length )
         {
            aP1_ErrorMessage=((string)(args[1]));
         }
         else
         {
            aP1_ErrorMessage="";
         }
         execute(out aP0_ExcelFilename, out aP1_ErrorMessage);
         return GX.GXRuntime.ExitCode ;
      }

      public atestexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public atestexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_ExcelFilename ,
                           out string aP1_ErrorMessage )
      {
         this.AV17ExcelFilename = "" ;
         this.AV16ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP0_ExcelFilename=this.AV17ExcelFilename;
         aP1_ErrorMessage=this.AV16ErrorMessage;
      }

      public string executeUdp( out string aP0_ExcelFilename )
      {
         execute(out aP0_ExcelFilename, out aP1_ErrorMessage);
         return AV16ErrorMessage ;
      }

      public void executeSubmit( out string aP0_ExcelFilename ,
                                 out string aP1_ErrorMessage )
      {
         this.AV17ExcelFilename = "" ;
         this.AV16ErrorMessage = "" ;
         SubmitImpl();
         aP0_ExcelFilename=this.AV17ExcelFilename;
         aP1_ErrorMessage=this.AV16ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV10FileName;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV10FileName = GXt_char1 + "UsuariosExport.xlsx";
         AV8ExcelDocument.Open(AV10FileName);
         AV8ExcelDocument.Clear();
         AV13CellRow = 1;
         AV8ExcelDocument.get_Cells(AV13CellRow, 1, 1, 1).Text = context.GetMessage( "Nombre Completo", "");
         AV8ExcelDocument.get_Cells(AV13CellRow, 2, 1, 1).Text = context.GetMessage( "Fecha de Nacimiento", "");
         AV8ExcelDocument.get_Cells(AV13CellRow, 1, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells(AV13CellRow, 2, 1, 1).Bold = 1;
         /* Using cursor P003H2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A57UsuarioFechaNacimiento = P003H2_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = P003H2_n57UsuarioFechaNacimiento[0];
            A51UsuarioApellido = P003H2_A51UsuarioApellido[0];
            A30UsuarioNombre = P003H2_A30UsuarioNombre[0];
            A29UsuarioID = P003H2_A29UsuarioID[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AV13CellRow = (short)(AV13CellRow+1);
            AV8ExcelDocument.get_Cells(AV13CellRow, 1, 1, 1).Text = A52UsuarioNombreCompleto;
            AV8ExcelDocument.get_Cells(AV13CellRow, 2, 1, 1).Text = context.localUtil.Format( A57UsuarioFechaNacimiento, "99/99/9999");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8ExcelDocument.Save();
         AV8ExcelDocument.Close();
         AV15Session.Set(context.GetMessage( "WWPExportFilePath", ""), AV10FileName);
         AV15Session.Set(context.GetMessage( "WWPExportFileName", ""), "UsuariosExport.xlsx");
         AV17ExcelFilename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
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
         AV17ExcelFilename = "";
         AV16ErrorMessage = "";
         AV10FileName = "";
         GXt_char1 = "";
         AV8ExcelDocument = new ExcelDocumentI();
         P003H2_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         P003H2_n57UsuarioFechaNacimiento = new bool[] {false} ;
         P003H2_A51UsuarioApellido = new string[] {""} ;
         P003H2_A30UsuarioNombre = new string[] {""} ;
         P003H2_A29UsuarioID = new int[1] ;
         A57UsuarioFechaNacimiento = DateTime.MinValue;
         A51UsuarioApellido = "";
         A30UsuarioNombre = "";
         A52UsuarioNombreCompleto = "";
         AV15Session = context.GetSession();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.atestexcel__default(),
            new Object[][] {
                new Object[] {
               P003H2_A57UsuarioFechaNacimiento, P003H2_n57UsuarioFechaNacimiento, P003H2_A51UsuarioApellido, P003H2_A30UsuarioNombre, P003H2_A29UsuarioID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13CellRow ;
      private int A29UsuarioID ;
      private string GXt_char1 ;
      private string A51UsuarioApellido ;
      private string A30UsuarioNombre ;
      private DateTime A57UsuarioFechaNacimiento ;
      private bool n57UsuarioFechaNacimiento ;
      private string AV17ExcelFilename ;
      private string AV16ErrorMessage ;
      private string AV10FileName ;
      private string A52UsuarioNombreCompleto ;
      private IGxSession AV15Session ;
      private ExcelDocumentI AV8ExcelDocument ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P003H2_A57UsuarioFechaNacimiento ;
      private bool[] P003H2_n57UsuarioFechaNacimiento ;
      private string[] P003H2_A51UsuarioApellido ;
      private string[] P003H2_A30UsuarioNombre ;
      private int[] P003H2_A29UsuarioID ;
      private string aP0_ExcelFilename ;
      private string aP1_ErrorMessage ;
   }

   public class atestexcel__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003H2;
          prmP003H2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P003H2", "SELECT `UsuarioFechaNacimiento`, `UsuarioApellido`, `UsuarioNombre`, `UsuarioID` FROM `Usuario` ORDER BY `UsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003H2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 50);
                ((string[]) buf[3])[0] = rslt.getString(3, 50);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
