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
   public class puedeverpassword : GXProcedure
   {
      public puedeverpassword( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public puedeverpassword( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_RolQueAccede ,
                           string aP1_RolDelUsuario ,
                           out bool aP2_PuedeVer )
      {
         this.AV8RolQueAccede = aP0_RolQueAccede;
         this.AV9RolDelUsuario = aP1_RolDelUsuario;
         this.AV10PuedeVer = false ;
         initialize();
         ExecuteImpl();
         aP2_PuedeVer=this.AV10PuedeVer;
      }

      public bool executeUdp( string aP0_RolQueAccede ,
                              string aP1_RolDelUsuario )
      {
         execute(aP0_RolQueAccede, aP1_RolDelUsuario, out aP2_PuedeVer);
         return AV10PuedeVer ;
      }

      public void executeSubmit( string aP0_RolQueAccede ,
                                 string aP1_RolDelUsuario ,
                                 out bool aP2_PuedeVer )
      {
         this.AV8RolQueAccede = aP0_RolQueAccede;
         this.AV9RolDelUsuario = aP1_RolDelUsuario;
         this.AV10PuedeVer = false ;
         SubmitImpl();
         aP2_PuedeVer=this.AV10PuedeVer;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10PuedeVer = false;
         if ( StringUtil.StrCmp(AV8RolQueAccede, "Super Administrador") == 0 )
         {
            AV10PuedeVer = true;
         }
         else
         {
            if ( StringUtil.StrCmp(AV8RolQueAccede, "Administrador Yokohama") == 0 )
            {
               if ( StringUtil.StrCmp(AV9RolDelUsuario, "Super Administrador") != 0 )
               {
                  AV10PuedeVer = true;
               }
            }
            else if ( StringUtil.StrCmp(AV8RolQueAccede, "Asesor") == 0 )
            {
               if ( ( StringUtil.StrCmp(AV9RolDelUsuario, "Asesor") == 0 ) || ( StringUtil.StrCmp(AV9RolDelUsuario, "Participante") == 0 ) )
               {
                  AV10PuedeVer = true;
               }
            }
            else if ( StringUtil.StrCmp(AV8RolQueAccede, "Participante") == 0 )
            {
               AV10PuedeVer = false;
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
         /* GeneXus formulas. */
      }

      private string AV8RolQueAccede ;
      private string AV9RolDelUsuario ;
      private bool AV10PuedeVer ;
      private bool aP2_PuedeVer ;
   }

}
