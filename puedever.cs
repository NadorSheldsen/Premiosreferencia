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
   public class puedever : GXProcedure
   {
      public puedever( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public puedever( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_RolQueAccede ,
                           out bool aP1_PuedeVer )
      {
         this.AV18RolQueAccede = aP0_RolQueAccede;
         this.AV16PuedeVer = false ;
         initialize();
         ExecuteImpl();
         aP1_PuedeVer=this.AV16PuedeVer;
      }

      public bool executeUdp( string aP0_RolQueAccede )
      {
         execute(aP0_RolQueAccede, out aP1_PuedeVer);
         return AV16PuedeVer ;
      }

      public void executeSubmit( string aP0_RolQueAccede ,
                                 out bool aP1_PuedeVer )
      {
         this.AV18RolQueAccede = aP0_RolQueAccede;
         this.AV16PuedeVer = false ;
         SubmitImpl();
         aP1_PuedeVer=this.AV16PuedeVer;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16PuedeVer = false;
         if ( ( StringUtil.StrCmp(AV18RolQueAccede, "Super Administrador") == 0 ) || ( StringUtil.StrCmp(AV18RolQueAccede, "Administrador Yokohama") == 0 ) )
         {
            AV16PuedeVer = true;
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
         /* GeneXus formulas. */
      }

      private string AV18RolQueAccede ;
      private bool AV16PuedeVer ;
      private bool aP1_PuedeVer ;
   }

}
