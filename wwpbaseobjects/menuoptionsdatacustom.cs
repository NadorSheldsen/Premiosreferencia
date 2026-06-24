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
namespace GeneXus.Programs.wwpbaseobjects {
   public class menuoptionsdatacustom : GXProcedure
   {
      public menuoptionsdatacustom( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public menuoptionsdatacustom( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UsuarioRol ,
                           int aP1_UsuarioID ,
                           out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> aP2_Gxm2rootcol )
      {
         this.AV7UsuarioRol = aP0_UsuarioRol;
         this.AV8UsuarioID = aP1_UsuarioID;
         this.Gxm2rootcol = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item>( context, "Item", "Premios") ;
         initialize();
         ExecuteImpl();
         aP2_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> executeUdp( string aP0_UsuarioRol ,
                                                                                             int aP1_UsuarioID )
      {
         execute(aP0_UsuarioRol, aP1_UsuarioID, out aP2_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( string aP0_UsuarioRol ,
                                 int aP1_UsuarioID ,
                                 out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> aP2_Gxm2rootcol )
      {
         this.AV7UsuarioRol = aP0_UsuarioRol;
         this.AV8UsuarioID = aP1_UsuarioID;
         this.Gxm2rootcol = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item>( context, "Item", "Premios") ;
         SubmitImpl();
         aP2_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV5id = 0;
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Caption = "Main Options";
         Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("inicio.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "menu-icon fa fa-home";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = context.GetMessage( "WWP_HomeTitle", "");
         if ( ( StringUtil.StrCmp(AV7UsuarioRol, "Super Administrador") == 0 ) || ( StringUtil.StrCmp(AV7UsuarioRol, "Administrador Yokohama") == 0 ) || ( StringUtil.StrCmp(AV7UsuarioRol, "Asesor") == 0 ) )
         {
            Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
            Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
            AV5id = (short)(AV5id+1);
            Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
            Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
            Gxm3dvelop_menu_subitems.gxTpr_Link = "";
            Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
            Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "menu-icon fa fa-folder-open";
            Gxm3dvelop_menu_subitems.gxTpr_Caption = "Catálogos";
            if ( StringUtil.StrCmp(AV7UsuarioRol, "Super Administrador") == 0 )
            {
               Gxm4dvelop_menu_subitems_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
               Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
               AV5id = (short)(AV5id+1);
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("wppais.aspx") ;
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Iconclass = "menu-icon fa fa-map-marker-alt";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "       Ubicación";
            }
            if ( ( StringUtil.StrCmp(AV7UsuarioRol, "Super Administrador") == 0 ) || ( StringUtil.StrCmp(AV7UsuarioRol, "Administrador Yokohama") == 0 ) || ( StringUtil.StrCmp(AV7UsuarioRol, "Asesor") == 0 ) )
            {
               Gxm4dvelop_menu_subitems_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
               Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
               AV5id = (short)(AV5id+1);
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("wpdistribuidor.aspx") ;
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Iconclass = "menu-icon fa fa-building";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "       Distribuidor";
            }
            if ( StringUtil.StrCmp(AV7UsuarioRol, "Super Administrador") == 0 )
            {
               Gxm4dvelop_menu_subitems_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
               Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
               AV5id = (short)(AV5id+1);
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("wpescolaridad.aspx") ;
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Iconclass = "menu-icon fa fa-graduation-cap";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "       Escolaridad";
            }
            if ( StringUtil.StrCmp(AV7UsuarioRol, "Super Administrador") == 0 )
            {
               Gxm4dvelop_menu_subitems_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
               Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
               AV5id = (short)(AV5id+1);
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("wppuesto.aspx") ;
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Iconclass = "menu-icon fa fa-user-tie";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "       Puesto";
            }
            if ( StringUtil.StrCmp(AV7UsuarioRol, "Super Administrador") == 0 )
            {
               Gxm4dvelop_menu_subitems_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
               Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
               AV5id = (short)(AV5id+1);
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("wpmotivorechazo.aspx") ;
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Iconclass = "menu-icon fa fa-times-circle";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "       Motivo de Rechazo";
            }
            if ( ( StringUtil.StrCmp(AV7UsuarioRol, "Administrador Yokohama") == 0 ) || ( StringUtil.StrCmp(AV7UsuarioRol, "Super Administrador") == 0 ) )
            {
               Gxm4dvelop_menu_subitems_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
               Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
               AV5id = (short)(AV5id+1);
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("wpmodelo.aspx") ;
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Iconclass = "menu-icon fa fa-cube";
               Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "       Llantas";
            }
         }
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Caption = "Ventas";
         if ( ( StringUtil.StrCmp(AV7UsuarioRol, "Super Administrador") == 0 ) || ( StringUtil.StrCmp(AV7UsuarioRol, "Administrador Yokohama") == 0 ) )
         {
            Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
            Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
            AV5id = (short)(AV5id+1);
            Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
            Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
            Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("wpfacturasnew.aspx") ;
            Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
            Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "menu-icon fa fa-file-invoice";
            Gxm3dvelop_menu_subitems.gxTpr_Caption = "Facturas";
         }
         if ( StringUtil.StrCmp(AV7UsuarioRol, "Participante") == 0 )
         {
            Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
            Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
            AV5id = (short)(AV5id+1);
            Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
            Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
            Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("wpfacturaspart.aspx") ;
            Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
            Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "menu-icon fa fa-file-invoice";
            Gxm3dvelop_menu_subitems.gxTpr_Caption = "Facturas";
         }
         if ( StringUtil.StrCmp(AV7UsuarioRol, "Asesor") == 0 )
         {
            Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
            Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
            AV5id = (short)(AV5id+1);
            Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
            Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
            Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("wpfacturasases.aspx") ;
            Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
            Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "menu-icon fa fa-file-invoice";
            Gxm3dvelop_menu_subitems.gxTpr_Caption = "Facturas";
         }
         if ( ( StringUtil.StrCmp(AV7UsuarioRol, "Super Administrador") == 0 ) || ( StringUtil.StrCmp(AV7UsuarioRol, "Administrador Yokohama") == 0 ) )
         {
            Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
            Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
            AV5id = (short)(AV5id+1);
            Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
            Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
            Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("wppromocion.aspx") ;
            Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
            Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "menu-icon fa fa-bullhorn";
            Gxm3dvelop_menu_subitems.gxTpr_Caption = "Promociones";
         }
         if ( StringUtil.StrCmp(AV7UsuarioRol, "Participante") == 0 )
         {
            Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
            Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
            AV5id = (short)(AV5id+1);
            Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
            Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
            Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("wplistaasesores.aspx") ;
            Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
            Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "menu-icon fa-solid fa-users";
            Gxm3dvelop_menu_subitems.gxTpr_Caption = "Asesores asignados";
         }
         if ( StringUtil.StrCmp(AV7UsuarioRol, "Asesor") == 0 )
         {
            Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
            Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
            AV5id = (short)(AV5id+1);
            Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
            Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
            Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("wplistaparticipantes.aspx") ;
            Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
            Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "menu-icon fa-solid fa-users";
            Gxm3dvelop_menu_subitems.gxTpr_Caption = "Participantes asignados";
         }
         if ( StringUtil.StrCmp(AV7UsuarioRol, "Asesor") == 0 )
         {
            Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
            Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
            AV5id = (short)(AV5id+1);
            Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
            Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
            Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("wpdistribuidoresasesor.aspx") ;
            Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
            Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "menu-icon fa fa-building";
            Gxm3dvelop_menu_subitems.gxTpr_Caption = "Mis distribuidores";
         }
         if ( StringUtil.StrCmp(AV7UsuarioRol, "Asesor") == 0 )
         {
            Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
            Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
            AV5id = (short)(AV5id+1);
            Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
            Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
            Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("wplistapromocionesasesor.aspx") ;
            Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
            Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "menu-icon fa fa-bullhorn";
            Gxm3dvelop_menu_subitems.gxTpr_Caption = "Promociones";
         }
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Caption = "Configuración";
         if ( ( StringUtil.StrCmp(AV7UsuarioRol, "Super Administrador") == 0 ) || ( StringUtil.StrCmp(AV7UsuarioRol, "Administrador Yokohama") == 0 ) )
         {
            Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
            Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
            AV5id = (short)(AV5id+1);
            Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
            Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
            Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("wpusuario.aspx") ;
            Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
            Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "menu-icon fa fa-users-cog";
            Gxm3dvelop_menu_subitems.gxTpr_Caption = "Usuarios";
         }
         Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpcambiarpass2.aspx"+GXUtil.UrlEncode(StringUtil.RTrim("UPD")) + "," + GXUtil.UrlEncode(StringUtil.LTrimStr(AV8UsuarioID,9,0));
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("wpcambiarpass2.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "menu-icon fa fa-key";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Cambiar Contraseña";
         if ( StringUtil.StrCmp(AV7UsuarioRol, "Super Administrador") == 0 )
         {
            Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
            Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
            AV5id = (short)(AV5id+1);
            Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
            Gxm3dvelop_menu_subitems.gxTpr_Tooltip = context.GetMessage( "Directivas", "");
            Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("trndirectivaww.aspx") ;
            Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
            Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "menu-icon fa fa-file-text";
            Gxm3dvelop_menu_subitems.gxTpr_Caption = "Directivas";
         }
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Caption = "Recursos adicionales";
         Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink(context.GetMessage( "https://www.dropbox.com/scl/fo/a7hvh9f3p5otrhtzcorqe/AHcXWDi9uH8SL5mVdCUkED4?rlkey=ga6lmqy6nwbogopdyuqzg8uup&e=1&dl=0", "")) ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = formatLink(context.GetMessage( "https://www.dropbox.com/scl/fo/a7hvh9f3p5otrhtzcorqe/AHcXWDi9uH8SL5mVdCUkED4?rlkey=ga6lmqy6nwbogopdyuqzg8uup&e=1&dl=0", "")) ;
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "menu-icon fa fa-circle-down";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Descargas";
         Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("wpyokohamauniversity.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "menu-icon fa fa-graduation-cap";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Yokohama University";
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
         Gxm1dvelop_menu = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm3dvelop_menu_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         Gxm4dvelop_menu_subitems_subitems = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         GXKey = "";
         GXEncryptionTmp = "";
         /* GeneXus formulas. */
      }

      private short AV5id ;
      private short gxcookieaux ;
      private int AV8UsuarioID ;
      private string AV7UsuarioRol ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> Gxm2rootcol ;
      private WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item Gxm1dvelop_menu ;
      private WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item Gxm3dvelop_menu_subitems ;
      private WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item Gxm4dvelop_menu_subitems_subitems ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> aP2_Gxm2rootcol ;
   }

}
