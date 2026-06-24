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
   public class generaexcelpartidasfiltrado : GXProcedure
   {
      public generaexcelpartidasfiltrado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public generaexcelpartidasfiltrado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PromocionID ,
                           GxSimpleCollection<int> aP1_ListaUsuarioID ,
                           out string aP2_ExcelFilename ,
                           out string aP3_ErrorMessage )
      {
         this.AV2PromocionID = aP0_PromocionID;
         this.AV3ListaUsuarioID = aP1_ListaUsuarioID;
         this.AV4ExcelFilename = "" ;
         this.AV5ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP2_ExcelFilename=this.AV4ExcelFilename;
         aP3_ErrorMessage=this.AV5ErrorMessage;
      }

      public string executeUdp( int aP0_PromocionID ,
                                GxSimpleCollection<int> aP1_ListaUsuarioID ,
                                out string aP2_ExcelFilename )
      {
         execute(aP0_PromocionID, aP1_ListaUsuarioID, out aP2_ExcelFilename, out aP3_ErrorMessage);
         return AV5ErrorMessage ;
      }

      public void executeSubmit( int aP0_PromocionID ,
                                 GxSimpleCollection<int> aP1_ListaUsuarioID ,
                                 out string aP2_ExcelFilename ,
                                 out string aP3_ErrorMessage )
      {
         this.AV2PromocionID = aP0_PromocionID;
         this.AV3ListaUsuarioID = aP1_ListaUsuarioID;
         this.AV4ExcelFilename = "" ;
         this.AV5ErrorMessage = "" ;
         SubmitImpl();
         aP2_ExcelFilename=this.AV4ExcelFilename;
         aP3_ErrorMessage=this.AV5ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(int)AV2PromocionID,(GxSimpleCollection<int>)AV3ListaUsuarioID,(string)AV4ExcelFilename,(string)AV5ErrorMessage} ;
         ClassLoader.Execute("ageneraexcelpartidasfiltrado","GeneXus.Programs","ageneraexcelpartidasfiltrado", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
            AV4ExcelFilename = (string)(args[2]) ;
            AV5ErrorMessage = (string)(args[3]) ;
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
         AV4ExcelFilename = "";
         AV5ErrorMessage = "";
         /* GeneXus formulas. */
      }

      private int AV2PromocionID ;
      private string AV4ExcelFilename ;
      private string AV5ErrorMessage ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<int> AV3ListaUsuarioID ;
      private Object[] args ;
      private string aP2_ExcelFilename ;
      private string aP3_ErrorMessage ;
   }

}
