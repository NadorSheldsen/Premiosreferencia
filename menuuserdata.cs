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
   public class menuuserdata : GXProcedure
   {
      public menuuserdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public menuuserdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out WorkWithPlus.workwithplus_web.SdtDVelop_Menu_UserData aP0_Gxm1dvelop_menu_userdata )
      {
         this.Gxm1dvelop_menu_userdata = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_UserData(context) ;
         initialize();
         ExecuteImpl();
         aP0_Gxm1dvelop_menu_userdata=this.Gxm1dvelop_menu_userdata;
      }

      public WorkWithPlus.workwithplus_web.SdtDVelop_Menu_UserData executeUdp( )
      {
         execute(out aP0_Gxm1dvelop_menu_userdata);
         return Gxm1dvelop_menu_userdata ;
      }

      public void executeSubmit( out WorkWithPlus.workwithplus_web.SdtDVelop_Menu_UserData aP0_Gxm1dvelop_menu_userdata )
      {
         this.Gxm1dvelop_menu_userdata = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_UserData(context) ;
         SubmitImpl();
         aP0_Gxm1dvelop_menu_userdata=this.Gxm1dvelop_menu_userdata;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1dvelop_menu_userdata.gxTpr_Firstline = " ";
         Gxm1dvelop_menu_userdata.gxTpr_Secondline = "";
         Gxm1dvelop_menu_userdata.gxTpr_Auxiliardata = context.GetMessage( "Auxiliar data (1)", "");
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

      private WorkWithPlus.workwithplus_web.SdtDVelop_Menu_UserData Gxm1dvelop_menu_userdata ;
      private WorkWithPlus.workwithplus_web.SdtDVelop_Menu_UserData aP0_Gxm1dvelop_menu_userdata ;
   }

}
