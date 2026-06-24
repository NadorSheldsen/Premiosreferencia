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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class testagregarparticipante : GXDataArea
   {
      public testagregarparticipante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public testagregarparticipante( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavUsuario_usuariogenero = new GXCombobox();
         cmbavUsuario_usuariodirectoasociado = new GXCombobox();
         cmbavUsuario_usuariozona = new GXCombobox();
         cmbavUsuario_usuarioproducto = new GXCombobox();
         cmbavUsuario_usuariorol = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA3Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3Y2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1018140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1018140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1018140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1018140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1018140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1018140), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("testagregarparticipante.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Usuario", AV5Usuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Usuario", AV5Usuario);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV13DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV13DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIO_PUESTOID_DATA", AV12Usuario_PuestoID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIO_PUESTOID_DATA", AV12Usuario_PuestoID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPAISID_DATA", AV15PaisID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPAISID_DATA", AV15PaisID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vESTADOID_DATA", AV16EstadoID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vESTADOID_DATA", AV16EstadoID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIO_CIUDADID_DATA", AV18Usuario_CiudadID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIO_CIUDADID_DATA", AV18Usuario_CiudadID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISTRIBUIDORID_DATA", AV20DistribuidorID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISTRIBUIDORID_DATA", AV20DistribuidorID_Data);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV11CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV22Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV22Messages);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIO", AV5Usuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIO", AV5Usuario);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_PUESTOID_Cls", StringUtil.RTrim( Combo_usuario_puestoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_PUESTOID_Selectedvalue_set", StringUtil.RTrim( Combo_usuario_puestoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_PUESTOID_Emptyitem", StringUtil.BoolToStr( Combo_usuario_puestoid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Cls", StringUtil.RTrim( Combo_paisid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Selectedvalue_set", StringUtil.RTrim( Combo_paisid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Cls", StringUtil.RTrim( Combo_estadoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Selectedvalue_set", StringUtil.RTrim( Combo_estadoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Selectedtext_set", StringUtil.RTrim( Combo_estadoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Datalistproc", StringUtil.RTrim( Combo_estadoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_estadoid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Cls", StringUtil.RTrim( Combo_usuario_ciudadid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Selectedvalue_set", StringUtil.RTrim( Combo_usuario_ciudadid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Selectedtext_set", StringUtil.RTrim( Combo_usuario_ciudadid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Datalistproc", StringUtil.RTrim( Combo_usuario_ciudadid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_usuario_ciudadid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Cls", StringUtil.RTrim( Combo_distribuidorid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Selectedvalue_set", StringUtil.RTrim( Combo_distribuidorid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Width", StringUtil.RTrim( Dvpanel_datosdistribuidor_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Autowidth", StringUtil.BoolToStr( Dvpanel_datosdistribuidor_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Autoheight", StringUtil.BoolToStr( Dvpanel_datosdistribuidor_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Cls", StringUtil.RTrim( Dvpanel_datosdistribuidor_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Title", StringUtil.RTrim( Dvpanel_datosdistribuidor_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Collapsible", StringUtil.BoolToStr( Dvpanel_datosdistribuidor_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Collapsed", StringUtil.BoolToStr( Dvpanel_datosdistribuidor_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_datosdistribuidor_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Iconposition", StringUtil.RTrim( Dvpanel_datosdistribuidor_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Autoscroll", StringUtil.BoolToStr( Dvpanel_datosdistribuidor_Autoscroll));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Selectedvalue_get", StringUtil.RTrim( Combo_distribuidorid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Selectedvalue_get", StringUtil.RTrim( Combo_usuario_ciudadid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Selectedvalue_get", StringUtil.RTrim( Combo_estadoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Selectedvalue_get", StringUtil.RTrim( Combo_paisid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_PUESTOID_Selectedvalue_get", StringUtil.RTrim( Combo_usuario_puestoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_PUESTOID_Ddointernalname", StringUtil.RTrim( Combo_usuario_puestoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Ddointernalname", StringUtil.RTrim( Combo_paisid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Ddointernalname", StringUtil.RTrim( Combo_estadoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Ddointernalname", StringUtil.RTrim( Combo_usuario_ciudadid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Ddointernalname", StringUtil.RTrim( Combo_distribuidorid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_PUESTOID_Ddointernalname", StringUtil.RTrim( Combo_usuario_puestoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Ddointernalname", StringUtil.RTrim( Combo_paisid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Ddointernalname", StringUtil.RTrim( Combo_estadoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Ddointernalname", StringUtil.RTrim( Combo_usuario_ciudadid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Ddointernalname", StringUtil.RTrim( Combo_distribuidorid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Selectedvalue_get", StringUtil.RTrim( Combo_usuario_ciudadid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Selectedvalue_get", StringUtil.RTrim( Combo_estadoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Selectedvalue_get", StringUtil.RTrim( Combo_paisid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_PUESTOID_Selectedvalue_get", StringUtil.RTrim( Combo_usuario_puestoid_Selectedvalue_get));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+1+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE3Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3Y2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("testagregarparticipante.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TestAgregarParticipante" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Agregar Participante", "") ;
      }

      protected void WB3Y0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableTransactionTemplate", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
            ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
            ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
            ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
            ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
            ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
            ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
            ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
            ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
            ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
            ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarionombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarionombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarionombre_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuarionombre), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuarionombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarionombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarionombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarioapellido_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarioapellido_Internalname, context.GetMessage( "Apellido(s)", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarioapellido_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioapellido), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuarioapellido, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarioapellido_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarioapellido_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocorreo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocorreo_Internalname, context.GetMessage( "Correo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocorreo_Internalname, AV5Usuario.gxTpr_Usuariocorreo, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariocorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocorreo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocorreo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuariogenero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuariogenero_Internalname, context.GetMessage( "Género", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariogenero, cmbavUsuario_usuariogenero_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariogenero), 1, cmbavUsuario_usuariogenero_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUsuario_usuariogenero.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 0, "HLP_TestAgregarParticipante.htm");
            cmbavUsuario_usuariogenero.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariogenero);
            AssignProp("", false, cmbavUsuario_usuariogenero_Internalname, "Values", (string)(cmbavUsuario_usuariogenero.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariofechanacimiento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariofechanacimiento_Internalname, context.GetMessage( "Fecha de nacimiento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavUsuario_usuariofechanacimiento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariofechanacimiento_Internalname, context.localUtil.Format(AV5Usuario.gxTpr_Usuariofechanacimiento, "99/99/9999"), context.localUtil.Format( AV5Usuario.gxTpr_Usuariofechanacimiento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariofechanacimiento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariofechanacimiento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_bitmap( context, edtavUsuario_usuariofechanacimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavUsuario_usuariofechanacimiento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TestAgregarParticipante.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocelular_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocelular_Internalname, context.GetMessage( "Celular", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocelular_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Usuariocelular), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavUsuario_usuariocelular_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariocelular), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariocelular), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocelular_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocelular_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedusuario_puestoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_usuario_puestoid_Internalname, context.GetMessage( "Puesto", ""), "", "", lblTextblockcombo_usuario_puestoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_usuario_puestoid.SetProperty("Caption", Combo_usuario_puestoid_Caption);
            ucCombo_usuario_puestoid.SetProperty("Cls", Combo_usuario_puestoid_Cls);
            ucCombo_usuario_puestoid.SetProperty("EmptyItem", Combo_usuario_puestoid_Emptyitem);
            ucCombo_usuario_puestoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV13DDO_TitleSettingsIcons);
            ucCombo_usuario_puestoid.SetProperty("DropDownOptionsData", AV12Usuario_PuestoID_Data);
            ucCombo_usuario_puestoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_usuario_puestoid_Internalname, "COMBO_USUARIO_PUESTOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPass_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPass_Internalname, context.GetMessage( "Contraseña", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPass_Internalname, StringUtil.RTrim( AV6Pass), StringUtil.RTrim( context.localUtil.Format( AV6Pass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\""+" "+"data-gx-password-reveal"+" "+"idenableshowpasswordhint=\"True\""+" ", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPass_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPass_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPass2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPass2_Internalname, context.GetMessage( "Confirmar contraseña", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPass2_Internalname, StringUtil.RTrim( AV7Pass2), StringUtil.RTrim( context.localUtil.Format( AV7Pass2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\""+" "+"data-gx-password-reveal"+" "+"idenableshowpasswordhint=\"True\""+" ", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPass2_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPass2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, " ", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_datosdistribuidor.SetProperty("Width", Dvpanel_datosdistribuidor_Width);
            ucDvpanel_datosdistribuidor.SetProperty("AutoWidth", Dvpanel_datosdistribuidor_Autowidth);
            ucDvpanel_datosdistribuidor.SetProperty("AutoHeight", Dvpanel_datosdistribuidor_Autoheight);
            ucDvpanel_datosdistribuidor.SetProperty("Cls", Dvpanel_datosdistribuidor_Cls);
            ucDvpanel_datosdistribuidor.SetProperty("Title", Dvpanel_datosdistribuidor_Title);
            ucDvpanel_datosdistribuidor.SetProperty("Collapsible", Dvpanel_datosdistribuidor_Collapsible);
            ucDvpanel_datosdistribuidor.SetProperty("Collapsed", Dvpanel_datosdistribuidor_Collapsed);
            ucDvpanel_datosdistribuidor.SetProperty("ShowCollapseIcon", Dvpanel_datosdistribuidor_Showcollapseicon);
            ucDvpanel_datosdistribuidor.SetProperty("IconPosition", Dvpanel_datosdistribuidor_Iconposition);
            ucDvpanel_datosdistribuidor.SetProperty("AutoScroll", Dvpanel_datosdistribuidor_Autoscroll);
            ucDvpanel_datosdistribuidor.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_datosdistribuidor_Internalname, "DVPANEL_DATOSDISTRIBUIDORContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_DATOSDISTRIBUIDORContainer"+"DatosDistribuidor"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatosdistribuidor_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariorazonsocialasociado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariorazonsocialasociado_Internalname, context.GetMessage( "Razón Social Asociado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariorazonsocialasociado_Internalname, AV5Usuario.gxTpr_Usuariorazonsocialasociado, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariorazonsocialasociado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariorazonsocialasociado_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariorazonsocialasociado_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarionombrecomercial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarionombrecomercial_Internalname, context.GetMessage( "Nombre Comercial", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarionombrecomercial_Internalname, AV5Usuario.gxTpr_Usuarionombrecomercial, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuarionombrecomercial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarionombrecomercial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarionombrecomercial_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariosucursal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariosucursal_Internalname, context.GetMessage( "Sucursal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariosucursal_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariosucursal), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariosucursal, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariosucursal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariosucursal_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuariodirectoasociado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuariodirectoasociado_Internalname, context.GetMessage( "Directo/Asociado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariodirectoasociado, cmbavUsuario_usuariodirectoasociado_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariodirectoasociado), 1, cmbavUsuario_usuariodirectoasociado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUsuario_usuariodirectoasociado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "", true, 0, "HLP_TestAgregarParticipante.htm");
            cmbavUsuario_usuariodirectoasociado.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariodirectoasociado);
            AssignProp("", false, cmbavUsuario_usuariodirectoasociado_Internalname, "Values", (string)(cmbavUsuario_usuariodirectoasociado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedpaisid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_paisid_Internalname, context.GetMessage( "País", ""), "", "", lblTextblockcombo_paisid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_paisid.SetProperty("Caption", Combo_paisid_Caption);
            ucCombo_paisid.SetProperty("Cls", Combo_paisid_Cls);
            ucCombo_paisid.SetProperty("DropDownOptionsTitleSettingsIcons", AV13DDO_TitleSettingsIcons);
            ucCombo_paisid.SetProperty("DropDownOptionsData", AV15PaisID_Data);
            ucCombo_paisid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_paisid_Internalname, "COMBO_PAISIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedestadoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_estadoid_Internalname, context.GetMessage( "Estado", ""), "", "", lblTextblockcombo_estadoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_estadoid.SetProperty("Caption", Combo_estadoid_Caption);
            ucCombo_estadoid.SetProperty("Cls", Combo_estadoid_Cls);
            ucCombo_estadoid.SetProperty("DataListProc", Combo_estadoid_Datalistproc);
            ucCombo_estadoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV13DDO_TitleSettingsIcons);
            ucCombo_estadoid.SetProperty("DropDownOptionsData", AV16EstadoID_Data);
            ucCombo_estadoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_estadoid_Internalname, "COMBO_ESTADOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedusuario_ciudadid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_usuario_ciudadid_Internalname, context.GetMessage( "Ciudad", ""), "", "", lblTextblockcombo_usuario_ciudadid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_usuario_ciudadid.SetProperty("Caption", Combo_usuario_ciudadid_Caption);
            ucCombo_usuario_ciudadid.SetProperty("Cls", Combo_usuario_ciudadid_Cls);
            ucCombo_usuario_ciudadid.SetProperty("DataListProc", Combo_usuario_ciudadid_Datalistproc);
            ucCombo_usuario_ciudadid.SetProperty("DropDownOptionsTitleSettingsIcons", AV13DDO_TitleSettingsIcons);
            ucCombo_usuario_ciudadid.SetProperty("DropDownOptionsData", AV18Usuario_CiudadID_Data);
            ucCombo_usuario_ciudadid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_usuario_ciudadid_Internalname, "COMBO_USUARIO_CIUDADIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocallenum_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocallenum_Internalname, context.GetMessage( "Calle y número", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocallenum_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariocallenum), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariocallenum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocallenum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocallenum_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocolonia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocolonia_Internalname, context.GetMessage( "Colonia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocolonia_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariocolonia), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariocolonia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocolonia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocolonia_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariodelegacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariodelegacion_Internalname, context.GetMessage( "Delegación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariodelegacion_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariodelegacion), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariodelegacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,133);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariodelegacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariodelegacion_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocp_Internalname, context.GetMessage( "Código Postal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Usuariocp), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavUsuario_usuariocp_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariocp), "ZZZZ9") : context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariocp), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,137);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocp_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocp_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuariozona_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuariozona_Internalname, context.GetMessage( "Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariozona, cmbavUsuario_usuariozona_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariozona), 1, cmbavUsuario_usuariozona_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUsuario_usuariozona.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,142);\"", "", true, 0, "HLP_TestAgregarParticipante.htm");
            cmbavUsuario_usuariozona.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariozona);
            AssignProp("", false, cmbavUsuario_usuariozona_Internalname, "Values", (string)(cmbavUsuario_usuariozona.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariotelefonosucursal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariotelefonosucursal_Internalname, context.GetMessage( "Teléfono Sucursal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariotelefonosucursal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Usuariotelefonosucursal), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavUsuario_usuariotelefonosucursal_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariotelefonosucursal), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariotelefonosucursal), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariotelefonosucursal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariotelefonosucursal_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuarioproducto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuarioproducto_Internalname, context.GetMessage( "Producto que vendes", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuarioproducto, cmbavUsuario_usuarioproducto_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioproducto), 1, cmbavUsuario_usuarioproducto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavUsuario_usuarioproducto.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "", true, 0, "HLP_TestAgregarParticipante.htm");
            cmbavUsuario_usuarioproducto.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioproducto);
            AssignProp("", false, cmbavUsuario_usuarioproducto_Internalname, "Values", (string)(cmbavUsuario_usuarioproducto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarionocuentabroxel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarionocuentabroxel_Internalname, context.GetMessage( "No Cuenta BROXEL", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarionocuentabroxel_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuarionocuentabroxel), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuarionocuentabroxel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,155);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarionocuentabroxel_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarionocuentabroxel_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarioreferenciabroxel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarioreferenciabroxel_Internalname, context.GetMessage( "Referencia BROXEL", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarioreferenciabroxel_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioreferenciabroxel), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuarioreferenciabroxel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,160);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarioreferenciabroxel_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarioreferenciabroxel_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledistribuidor_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplitteddistribuidorid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_distribuidorid_Internalname, context.GetMessage( "Distribuidor", ""), "", "", lblTextblockcombo_distribuidorid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_distribuidorid.SetProperty("Caption", Combo_distribuidorid_Caption);
            ucCombo_distribuidorid.SetProperty("Cls", Combo_distribuidorid_Cls);
            ucCombo_distribuidorid.SetProperty("DropDownOptionsTitleSettingsIcons", AV13DDO_TitleSettingsIcons);
            ucCombo_distribuidorid.SetProperty("DropDownOptionsData", AV20DistribuidorID_Data);
            ucCombo_distribuidorid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_distribuidorid_Internalname, "COMBO_DISTRIBUIDORIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPaisid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8PaisID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8PaisID), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,181);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPaisid_Jsonclick, 0, "Attribute", "", "", "", "", edtavPaisid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TestAgregarParticipante.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 182,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEstadoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9EstadoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV9EstadoID), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,182);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEstadoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavEstadoid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TestAgregarParticipante.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 183,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDistribuidorid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10DistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10DistribuidorID), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,183);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDistribuidorid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDistribuidorid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TestAgregarParticipante.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariorol, cmbavUsuario_usuariorol_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariorol), 1, cmbavUsuario_usuariorol_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavUsuario_usuariorol.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,184);\"", "", true, 0, "HLP_TestAgregarParticipante.htm");
            cmbavUsuario_usuariorol.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariorol);
            AssignProp("", false, cmbavUsuario_usuariorol_Internalname, "Values", (string)(cmbavUsuario_usuariorol.ToJavascriptSource()), true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 185,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Usuarioid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuarioid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,185);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuario_usuarioid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TestAgregarParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3Y2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Agregar Participante", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3Y0( ) ;
      }

      protected void WS3Y2( )
      {
         START3Y2( ) ;
         EVT3Y2( ) ;
      }

      protected void EVT3Y2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_USUARIO_PUESTOID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_usuario_puestoid.Onoptionclicked */
                              E113Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_PAISID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_paisid.Onoptionclicked */
                              E123Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_ESTADOID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_estadoid.Onoptionclicked */
                              E133Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_USUARIO_CIUDADID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_usuario_ciudadid.Onoptionclicked */
                              E143Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E153Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E163Y2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E173Y2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA3Y2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavUsuario_usuarionombre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavUsuario_usuariogenero.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariogenero = cmbavUsuario_usuariogenero.getValidValue(AV5Usuario.gxTpr_Usuariogenero);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuariogenero.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariogenero);
            AssignProp("", false, cmbavUsuario_usuariogenero_Internalname, "Values", cmbavUsuario_usuariogenero.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuariodirectoasociado.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariodirectoasociado = cmbavUsuario_usuariodirectoasociado.getValidValue(AV5Usuario.gxTpr_Usuariodirectoasociado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuariodirectoasociado.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariodirectoasociado);
            AssignProp("", false, cmbavUsuario_usuariodirectoasociado_Internalname, "Values", cmbavUsuario_usuariodirectoasociado.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuariozona.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariozona = cmbavUsuario_usuariozona.getValidValue(AV5Usuario.gxTpr_Usuariozona);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuariozona.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariozona);
            AssignProp("", false, cmbavUsuario_usuariozona_Internalname, "Values", cmbavUsuario_usuariozona.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuarioproducto.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuarioproducto = cmbavUsuario_usuarioproducto.getValidValue(AV5Usuario.gxTpr_Usuarioproducto);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuarioproducto.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioproducto);
            AssignProp("", false, cmbavUsuario_usuarioproducto_Internalname, "Values", cmbavUsuario_usuarioproducto.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuariorol.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariorol = cmbavUsuario_usuariorol.getValidValue(AV5Usuario.gxTpr_Usuariorol);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuariorol.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariorol);
            AssignProp("", false, cmbavUsuario_usuariorol_Internalname, "Values", cmbavUsuario_usuariorol.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF3Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E173Y2 ();
            WB3Y0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3Y2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E153Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vUSUARIO"), AV5Usuario);
            ajax_req_read_hidden_sdt(cgiGet( "Usuario"), AV5Usuario);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV13DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vUSUARIO_PUESTOID_DATA"), AV12Usuario_PuestoID_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vPAISID_DATA"), AV15PaisID_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vESTADOID_DATA"), AV16EstadoID_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vUSUARIO_CIUDADID_DATA"), AV18Usuario_CiudadID_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vDISTRIBUIDORID_DATA"), AV20DistribuidorID_Data);
            /* Read saved values. */
            Combo_usuario_puestoid_Cls = cgiGet( "COMBO_USUARIO_PUESTOID_Cls");
            Combo_usuario_puestoid_Selectedvalue_set = cgiGet( "COMBO_USUARIO_PUESTOID_Selectedvalue_set");
            Combo_usuario_puestoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_USUARIO_PUESTOID_Emptyitem"));
            Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
            Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
            Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
            Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
            Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
            Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
            Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
            Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
            Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
            Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
            Combo_paisid_Cls = cgiGet( "COMBO_PAISID_Cls");
            Combo_paisid_Selectedvalue_set = cgiGet( "COMBO_PAISID_Selectedvalue_set");
            Combo_estadoid_Cls = cgiGet( "COMBO_ESTADOID_Cls");
            Combo_estadoid_Selectedvalue_set = cgiGet( "COMBO_ESTADOID_Selectedvalue_set");
            Combo_estadoid_Selectedtext_set = cgiGet( "COMBO_ESTADOID_Selectedtext_set");
            Combo_estadoid_Datalistproc = cgiGet( "COMBO_ESTADOID_Datalistproc");
            Combo_estadoid_Datalistprocparametersprefix = cgiGet( "COMBO_ESTADOID_Datalistprocparametersprefix");
            Combo_usuario_ciudadid_Cls = cgiGet( "COMBO_USUARIO_CIUDADID_Cls");
            Combo_usuario_ciudadid_Selectedvalue_set = cgiGet( "COMBO_USUARIO_CIUDADID_Selectedvalue_set");
            Combo_usuario_ciudadid_Selectedtext_set = cgiGet( "COMBO_USUARIO_CIUDADID_Selectedtext_set");
            Combo_usuario_ciudadid_Datalistproc = cgiGet( "COMBO_USUARIO_CIUDADID_Datalistproc");
            Combo_usuario_ciudadid_Datalistprocparametersprefix = cgiGet( "COMBO_USUARIO_CIUDADID_Datalistprocparametersprefix");
            Combo_distribuidorid_Cls = cgiGet( "COMBO_DISTRIBUIDORID_Cls");
            Combo_distribuidorid_Selectedvalue_set = cgiGet( "COMBO_DISTRIBUIDORID_Selectedvalue_set");
            Dvpanel_datosdistribuidor_Width = cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Width");
            Dvpanel_datosdistribuidor_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Autowidth"));
            Dvpanel_datosdistribuidor_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Autoheight"));
            Dvpanel_datosdistribuidor_Cls = cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Cls");
            Dvpanel_datosdistribuidor_Title = cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Title");
            Dvpanel_datosdistribuidor_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Collapsible"));
            Dvpanel_datosdistribuidor_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Collapsed"));
            Dvpanel_datosdistribuidor_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Showcollapseicon"));
            Dvpanel_datosdistribuidor_Iconposition = cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Iconposition");
            Dvpanel_datosdistribuidor_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Autoscroll"));
            Combo_usuario_puestoid_Ddointernalname = cgiGet( "COMBO_USUARIO_PUESTOID_Ddointernalname");
            Combo_paisid_Ddointernalname = cgiGet( "COMBO_PAISID_Ddointernalname");
            Combo_estadoid_Ddointernalname = cgiGet( "COMBO_ESTADOID_Ddointernalname");
            Combo_usuario_ciudadid_Ddointernalname = cgiGet( "COMBO_USUARIO_CIUDADID_Ddointernalname");
            Combo_distribuidorid_Ddointernalname = cgiGet( "COMBO_DISTRIBUIDORID_Ddointernalname");
            Combo_usuario_ciudadid_Selectedvalue_get = cgiGet( "COMBO_USUARIO_CIUDADID_Selectedvalue_get");
            Combo_estadoid_Selectedvalue_get = cgiGet( "COMBO_ESTADOID_Selectedvalue_get");
            Combo_paisid_Selectedvalue_get = cgiGet( "COMBO_PAISID_Selectedvalue_get");
            Combo_usuario_puestoid_Selectedvalue_get = cgiGet( "COMBO_USUARIO_PUESTOID_Selectedvalue_get");
            /* Read variables values. */
            AV5Usuario.gxTpr_Usuarionombre = cgiGet( edtavUsuario_usuarionombre_Internalname);
            AV5Usuario.gxTpr_Usuarioapellido = cgiGet( edtavUsuario_usuarioapellido_Internalname);
            AV5Usuario.gxTpr_Usuariocorreo = cgiGet( edtavUsuario_usuariocorreo_Internalname);
            cmbavUsuario_usuariogenero.CurrentValue = cgiGet( cmbavUsuario_usuariogenero_Internalname);
            AV5Usuario.gxTpr_Usuariogenero = cgiGet( cmbavUsuario_usuariogenero_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavUsuario_usuariofechanacimiento_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha de nacimiento", "")}), 1, "USUARIO_USUARIOFECHANACIMIENTO");
               GX_FocusControl = edtavUsuario_usuariofechanacimiento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Usuario.gxTpr_Usuariofechanacimiento = DateTime.MinValue;
            }
            else
            {
               AV5Usuario.gxTpr_Usuariofechanacimiento = context.localUtil.CToD( cgiGet( edtavUsuario_usuariofechanacimiento_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariocelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariocelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_USUARIOCELULAR");
               GX_FocusControl = edtavUsuario_usuariocelular_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Usuario.gxTpr_Usuariocelular = 0;
            }
            else
            {
               AV5Usuario.gxTpr_Usuariocelular = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_usuariocelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV6Pass = cgiGet( edtavPass_Internalname);
            AssignAttri("", false, "AV6Pass", AV6Pass);
            AV7Pass2 = cgiGet( edtavPass2_Internalname);
            AssignAttri("", false, "AV7Pass2", AV7Pass2);
            AV5Usuario.gxTpr_Usuariorazonsocialasociado = cgiGet( edtavUsuario_usuariorazonsocialasociado_Internalname);
            AV5Usuario.gxTpr_Usuarionombrecomercial = cgiGet( edtavUsuario_usuarionombrecomercial_Internalname);
            AV5Usuario.gxTpr_Usuariosucursal = cgiGet( edtavUsuario_usuariosucursal_Internalname);
            cmbavUsuario_usuariodirectoasociado.CurrentValue = cgiGet( cmbavUsuario_usuariodirectoasociado_Internalname);
            AV5Usuario.gxTpr_Usuariodirectoasociado = cgiGet( cmbavUsuario_usuariodirectoasociado_Internalname);
            AV5Usuario.gxTpr_Usuariocallenum = cgiGet( edtavUsuario_usuariocallenum_Internalname);
            AV5Usuario.gxTpr_Usuariocolonia = cgiGet( edtavUsuario_usuariocolonia_Internalname);
            AV5Usuario.gxTpr_Usuariodelegacion = cgiGet( edtavUsuario_usuariodelegacion_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariocp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariocp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_USUARIOCP");
               GX_FocusControl = edtavUsuario_usuariocp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Usuario.gxTpr_Usuariocp = 0;
            }
            else
            {
               AV5Usuario.gxTpr_Usuariocp = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_usuariocp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            cmbavUsuario_usuariozona.CurrentValue = cgiGet( cmbavUsuario_usuariozona_Internalname);
            AV5Usuario.gxTpr_Usuariozona = cgiGet( cmbavUsuario_usuariozona_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariotelefonosucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariotelefonosucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_USUARIOTELEFONOSUCURSAL");
               GX_FocusControl = edtavUsuario_usuariotelefonosucursal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Usuario.gxTpr_Usuariotelefonosucursal = 0;
            }
            else
            {
               AV5Usuario.gxTpr_Usuariotelefonosucursal = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_usuariotelefonosucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            cmbavUsuario_usuarioproducto.CurrentValue = cgiGet( cmbavUsuario_usuarioproducto_Internalname);
            AV5Usuario.gxTpr_Usuarioproducto = cgiGet( cmbavUsuario_usuarioproducto_Internalname);
            AV5Usuario.gxTpr_Usuarionocuentabroxel = cgiGet( edtavUsuario_usuarionocuentabroxel_Internalname);
            AV5Usuario.gxTpr_Usuarioreferenciabroxel = cgiGet( edtavUsuario_usuarioreferenciabroxel_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPaisid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPaisid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPAISID");
               GX_FocusControl = edtavPaisid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8PaisID = 0;
               AssignAttri("", false, "AV8PaisID", StringUtil.LTrimStr( (decimal)(AV8PaisID), 9, 0));
            }
            else
            {
               AV8PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPaisid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8PaisID", StringUtil.LTrimStr( (decimal)(AV8PaisID), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEstadoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEstadoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vESTADOID");
               GX_FocusControl = edtavEstadoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9EstadoID = 0;
               AssignAttri("", false, "AV9EstadoID", StringUtil.LTrimStr( (decimal)(AV9EstadoID), 9, 0));
            }
            else
            {
               AV9EstadoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavEstadoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9EstadoID", StringUtil.LTrimStr( (decimal)(AV9EstadoID), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDistribuidorid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDistribuidorid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDISTRIBUIDORID");
               GX_FocusControl = edtavDistribuidorid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10DistribuidorID = 0;
               AssignAttri("", false, "AV10DistribuidorID", StringUtil.LTrimStr( (decimal)(AV10DistribuidorID), 9, 0));
            }
            else
            {
               AV10DistribuidorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavDistribuidorid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10DistribuidorID", StringUtil.LTrimStr( (decimal)(AV10DistribuidorID), 9, 0));
            }
            cmbavUsuario_usuariorol.CurrentValue = cgiGet( cmbavUsuario_usuariorol_Internalname);
            AV5Usuario.gxTpr_Usuariorol = cgiGet( cmbavUsuario_usuariorol_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_USUARIOID");
               GX_FocusControl = edtavUsuario_usuarioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Usuario.gxTpr_Usuarioid = 0;
            }
            else
            {
               AV5Usuario.gxTpr_Usuarioid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_usuarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E153Y2 ();
         if (returnInSub) return;
      }

      protected void E153Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = context.GetMessage( "Agregar participante", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV30UsuarioJSON = AV31WebSession.Get(context.GetMessage( "Usuario", ""));
         AV32SDTUsuario.FromJSonString(AV30UsuarioJSON, null);
         AV33UsuarioIDIngresa = AV32SDTUsuario.gxTpr_Usuarioid;
         AssignAttri("", false, "AV33UsuarioIDIngresa", StringUtil.LTrimStr( (decimal)(AV33UsuarioIDIngresa), 9, 0));
         AV23TrnMode = "INS";
         AV24LoadSuccess = true;
         if ( ! ( ( StringUtil.StrCmp(AV23TrnMode, "INS") == 0 ) ) )
         {
            AV24LoadSuccess = false;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV13DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV13DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavDistribuidorid_Visible = 0;
         AssignProp("", false, edtavDistribuidorid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDistribuidorid_Visible), 5, 0), true);
         edtavEstadoid_Visible = 0;
         AssignProp("", false, edtavEstadoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEstadoid_Visible), 5, 0), true);
         edtavPaisid_Visible = 0;
         AssignProp("", false, edtavPaisid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPaisid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOUSUARIO_PUESTOID' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOPAISID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOESTADOID' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOUSUARIO_CIUDADID' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBODISTRIBUIDORID' */
         S152 ();
         if (returnInSub) return;
         cmbavUsuario_usuariorol.Visible = 0;
         AssignProp("", false, cmbavUsuario_usuariorol_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariorol.Visible), 5, 0), true);
         edtavUsuario_usuarioid_Visible = 0;
         AssignProp("", false, edtavUsuario_usuarioid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarioid_Visible), 5, 0), true);
         AV5Usuario.gxTpr_Usuariorol = "Participante";
      }

      protected void E143Y2( )
      {
         /* Combo_usuario_ciudadid_Onoptionclicked Routine */
         returnInSub = false;
         AV5Usuario.gxTpr_Ciudadid = (int)(Math.Round(NumberUtil.Val( Combo_usuario_ciudadid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Usuario", AV5Usuario);
      }

      protected void E133Y2( )
      {
         /* Combo_estadoid_Onoptionclicked Routine */
         returnInSub = false;
         AV19Cond_EstadoID = AV9EstadoID;
         AssignAttri("", false, "AV19Cond_EstadoID", StringUtil.LTrimStr( (decimal)(AV19Cond_EstadoID), 9, 0));
         AV9EstadoID = (int)(Math.Round(NumberUtil.Val( Combo_estadoid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV9EstadoID", StringUtil.LTrimStr( (decimal)(AV9EstadoID), 9, 0));
         if ( AV19Cond_EstadoID != AV9EstadoID )
         {
            AV5Usuario.gxTpr_Ciudadid = 0;
            Combo_usuario_ciudadid_Selectedvalue_set = "";
            ucCombo_usuario_ciudadid.SendProperty(context, "", false, Combo_usuario_ciudadid_Internalname, "SelectedValue_set", Combo_usuario_ciudadid_Selectedvalue_set);
            Combo_usuario_ciudadid_Selectedtext_set = "";
            ucCombo_usuario_ciudadid.SendProperty(context, "", false, Combo_usuario_ciudadid_Internalname, "SelectedText_set", Combo_usuario_ciudadid_Selectedtext_set);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Usuario", AV5Usuario);
      }

      protected void E123Y2( )
      {
         /* Combo_paisid_Onoptionclicked Routine */
         returnInSub = false;
         AV17Cond_PaisID = AV8PaisID;
         AssignAttri("", false, "AV17Cond_PaisID", StringUtil.LTrimStr( (decimal)(AV17Cond_PaisID), 9, 0));
         AV8PaisID = (int)(Math.Round(NumberUtil.Val( Combo_paisid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV8PaisID", StringUtil.LTrimStr( (decimal)(AV8PaisID), 9, 0));
         if ( AV17Cond_PaisID != AV8PaisID )
         {
            AV9EstadoID = 0;
            AssignAttri("", false, "AV9EstadoID", StringUtil.LTrimStr( (decimal)(AV9EstadoID), 9, 0));
            Combo_estadoid_Selectedvalue_set = "";
            ucCombo_estadoid.SendProperty(context, "", false, Combo_estadoid_Internalname, "SelectedValue_set", Combo_estadoid_Selectedvalue_set);
            Combo_estadoid_Selectedtext_set = "";
            ucCombo_estadoid.SendProperty(context, "", false, Combo_estadoid_Internalname, "SelectedText_set", Combo_estadoid_Selectedtext_set);
         }
         /*  Sending Event outputs  */
      }

      protected void E113Y2( )
      {
         /* Combo_usuario_puestoid_Onoptionclicked Routine */
         returnInSub = false;
         AV5Usuario.gxTpr_Puestoid = (int)(Math.Round(NumberUtil.Val( Combo_usuario_puestoid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Usuario", AV5Usuario);
      }

      protected void S162( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV11CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuarionombre)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Nombre", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuarionombre_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioapellido)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Apellido(s)", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuarioapellido_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuariocorreo)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Correo", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuariocorreo_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuariogenero)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Género", ""), "", "", "", "", "", "", "", ""),  "error",  cmbavUsuario_usuariogenero_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( (0==AV5Usuario.gxTpr_Usuariocelular) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Celular", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuariocelular_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( (0==AV5Usuario.gxTpr_Puestoid) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Puesto", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_usuario_puestoid_Ddointernalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6Pass)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Contraseña", ""), "", "", "", "", "", "", "", ""),  "error",  edtavPass_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7Pass2)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Confirmar contraseña", ""), "", "", "", "", "", "", "", ""),  "error",  edtavPass2_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( (0==AV8PaisID) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "País", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_paisid_Ddointernalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( (0==AV9EstadoID) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_estadoid_Ddointernalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( (0==AV5Usuario.gxTpr_Ciudadid) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_usuario_ciudadid_Ddointernalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuariocallenum)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Calle y número", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuariocallenum_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuariocolonia)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Colonia", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuariocolonia_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuariodelegacion)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Delegación", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuariodelegacion_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( (0==AV5Usuario.gxTpr_Usuariocp) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Código Postal", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuariocp_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuariozona)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Zona", ""), "", "", "", "", "", "", "", ""),  "error",  cmbavUsuario_usuariozona_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( (0==AV10DistribuidorID) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Distribuidor", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_distribuidorid_Ddointernalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
      }

      protected void S152( )
      {
         /* 'LOADCOMBODISTRIBUIDORID' Routine */
         returnInSub = false;
         AV34DistribuidorIDCol.Clear();
         /* Using cursor H003Y2 */
         pr_default.execute(0, new Object[] {AV33UsuarioIDIngresa});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29UsuarioID = H003Y2_A29UsuarioID[0];
            A10DistribuidorID = H003Y2_A10DistribuidorID[0];
            AV36YaExiste = false;
            AV60GXV22 = 1;
            while ( AV60GXV22 <= AV34DistribuidorIDCol.Count )
            {
               AV37DistribuidorIDItem = (int)(AV34DistribuidorIDCol.GetNumeric(AV60GXV22));
               if ( AV37DistribuidorIDItem == A10DistribuidorID )
               {
                  AV36YaExiste = true;
                  if (true) break;
               }
               AV60GXV22 = (int)(AV60GXV22+1);
            }
            if ( ! AV36YaExiste )
            {
               AV34DistribuidorIDCol.Add(A10DistribuidorID, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A10DistribuidorID ,
                                              AV34DistribuidorIDCol } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         /* Using cursor H003Y3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A10DistribuidorID = H003Y3_A10DistribuidorID[0];
            A11DistribuidorDescripcion = H003Y3_A11DistribuidorDescripcion[0];
            AV14Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A10DistribuidorID), 9, 0));
            AV14Combo_DataItem.gxTpr_Title = A11DistribuidorDescripcion;
            AV20DistribuidorID_Data.Add(AV14Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_distribuidorid_Selectedvalue_set = ((0==AV10DistribuidorID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV10DistribuidorID), 9, 0)));
         ucCombo_distribuidorid.SendProperty(context, "", false, Combo_distribuidorid_Internalname, "SelectedValue_set", Combo_distribuidorid_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOUSUARIO_CIUDADID' Routine */
         returnInSub = false;
         Combo_usuario_ciudadid_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"Usuario_CiudadID\", \"Cond_PaisID\": \"#%1#\", \"Cond_EstadoID\": \"#%2#\"", edtavPaisid_Internalname, edtavEstadoid_Internalname, "", "", "", "", "", "", "");
         ucCombo_usuario_ciudadid.SendProperty(context, "", false, Combo_usuario_ciudadid_Internalname, "DataListProcParametersPrefix", Combo_usuario_ciudadid_Datalistprocparametersprefix);
         AV19Cond_EstadoID = AV9EstadoID;
         AssignAttri("", false, "AV19Cond_EstadoID", StringUtil.LTrimStr( (decimal)(AV19Cond_EstadoID), 9, 0));
         AV62GXLvl220 = 0;
         /* Using cursor H003Y4 */
         pr_default.execute(2, new Object[] {AV5Usuario.gxTpr_Ciudadid, AV19Cond_EstadoID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A1EstadoID = H003Y4_A1EstadoID[0];
            A4CiudadID = H003Y4_A4CiudadID[0];
            A5CiudadDescripcion = H003Y4_A5CiudadDescripcion[0];
            AV62GXLvl220 = 1;
            Combo_usuario_ciudadid_Selectedtext_set = A5CiudadDescripcion;
            ucCombo_usuario_ciudadid.SendProperty(context, "", false, Combo_usuario_ciudadid_Internalname, "SelectedText_set", Combo_usuario_ciudadid_Selectedtext_set);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( AV62GXLvl220 == 0 )
         {
            Combo_usuario_ciudadid_Selectedtext_set = "";
            ucCombo_usuario_ciudadid.SendProperty(context, "", false, Combo_usuario_ciudadid_Internalname, "SelectedText_set", Combo_usuario_ciudadid_Selectedtext_set);
         }
         Combo_usuario_ciudadid_Selectedvalue_set = ((0==AV5Usuario.gxTpr_Ciudadid) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5Usuario.gxTpr_Ciudadid), 9, 0)));
         ucCombo_usuario_ciudadid.SendProperty(context, "", false, Combo_usuario_ciudadid_Internalname, "SelectedValue_set", Combo_usuario_ciudadid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOESTADOID' Routine */
         returnInSub = false;
         Combo_estadoid_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"EstadoID\", \"Cond_PaisID\": \"#%1#\", \"Cond_EstadoID\": \"#%2#\"", edtavPaisid_Internalname, edtavEstadoid_Internalname, "", "", "", "", "", "", "");
         ucCombo_estadoid.SendProperty(context, "", false, Combo_estadoid_Internalname, "DataListProcParametersPrefix", Combo_estadoid_Datalistprocparametersprefix);
         AV17Cond_PaisID = AV8PaisID;
         AssignAttri("", false, "AV17Cond_PaisID", StringUtil.LTrimStr( (decimal)(AV17Cond_PaisID), 9, 0));
         AV63GXLvl241 = 0;
         /* Using cursor H003Y5 */
         pr_default.execute(3, new Object[] {AV9EstadoID, AV17Cond_PaisID});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A16PaisID = H003Y5_A16PaisID[0];
            A1EstadoID = H003Y5_A1EstadoID[0];
            A2EstadoDescripcion = H003Y5_A2EstadoDescripcion[0];
            AV63GXLvl241 = 1;
            Combo_estadoid_Selectedtext_set = A2EstadoDescripcion;
            ucCombo_estadoid.SendProperty(context, "", false, Combo_estadoid_Internalname, "SelectedText_set", Combo_estadoid_Selectedtext_set);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         if ( AV63GXLvl241 == 0 )
         {
            Combo_estadoid_Selectedtext_set = "";
            ucCombo_estadoid.SendProperty(context, "", false, Combo_estadoid_Internalname, "SelectedText_set", Combo_estadoid_Selectedtext_set);
         }
         Combo_estadoid_Selectedvalue_set = ((0==AV9EstadoID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV9EstadoID), 9, 0)));
         ucCombo_estadoid.SendProperty(context, "", false, Combo_estadoid_Internalname, "SelectedValue_set", Combo_estadoid_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPAISID' Routine */
         returnInSub = false;
         /* Using cursor H003Y6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A16PaisID = H003Y6_A16PaisID[0];
            A17PaisDescripcion = H003Y6_A17PaisDescripcion[0];
            AV14Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A16PaisID), 9, 0));
            AV14Combo_DataItem.gxTpr_Title = A17PaisDescripcion;
            AV15PaisID_Data.Add(AV14Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_paisid_Selectedvalue_set = ((0==AV8PaisID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV8PaisID), 9, 0)));
         ucCombo_paisid.SendProperty(context, "", false, Combo_paisid_Internalname, "SelectedValue_set", Combo_paisid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOUSUARIO_PUESTOID' Routine */
         returnInSub = false;
         /* Using cursor H003Y7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A15PuestoActivo = H003Y7_A15PuestoActivo[0];
            A13PuestoID = H003Y7_A13PuestoID[0];
            A14PuestoDescripcion = H003Y7_A14PuestoDescripcion[0];
            AV14Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A13PuestoID), 9, 0));
            AV14Combo_DataItem.gxTpr_Title = A14PuestoDescripcion;
            AV12Usuario_PuestoID_Data.Add(AV14Combo_DataItem, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         Combo_usuario_puestoid_Selectedvalue_set = ((0==AV5Usuario.gxTpr_Puestoid) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5Usuario.gxTpr_Puestoid), 9, 0)));
         ucCombo_usuario_puestoid.SendProperty(context, "", false, Combo_usuario_puestoid_Internalname, "SelectedValue_set", Combo_usuario_puestoid_Selectedvalue_set);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E163Y2 ();
         if (returnInSub) return;
      }

      protected void E163Y2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV6Pass, AV7Pass2) == 0 )
         {
            AV29UsuarioKey = Crypto.GetEncryptionKey( );
            AV5Usuario.gxTpr_Usuariopass = Encrypt64( AV7Pass2, AV29UsuarioKey);
            AV5Usuario.gxTpr_Usuariokey = AV29UsuarioKey;
            /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
            S162 ();
            if (returnInSub) return;
            if ( AV11CheckRequiredFieldsResult )
            {
               AV5Usuario.Save();
               if ( AV5Usuario.Success() )
               {
                  AV26UsuarioID = AV5Usuario.gxTpr_Usuarioid;
                  AV28DistribuidoresUsuario = new SdtDistribuidoresUsuario(context);
                  AV28DistribuidoresUsuario.gxTpr_Usuarioid = AV26UsuarioID;
                  AV28DistribuidoresUsuario.gxTpr_Distribuidorid = AV10DistribuidorID;
                  AV28DistribuidoresUsuario.Save();
                  if ( AV28DistribuidoresUsuario.Success() )
                  {
                     /* Execute user subroutine: 'AFTER_TRN' */
                     S172 ();
                     if (returnInSub) return;
                  }
                  else
                  {
                     AV22Messages = AV28DistribuidoresUsuario.GetMessages();
                     /* Execute user subroutine: 'SHOW MESSAGES' */
                     S182 ();
                     if (returnInSub) return;
                  }
               }
               else
               {
                  AV22Messages = AV5Usuario.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S182 ();
                  if (returnInSub) return;
               }
            }
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "Error, las contraseñas no coinciden, intenta de nuevo", ""));
            GX_FocusControl = edtavPass2_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            context.DoAjaxSetFocus(GX_FocusControl);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Usuario", AV5Usuario);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22Messages", AV22Messages);
      }

      protected void S182( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV66GXV23 = 1;
         while ( AV66GXV23 <= AV22Messages.Count )
         {
            AV21Message = ((GeneXus.Utils.SdtMessages_Message)AV22Messages.Item(AV66GXV23));
            GX_msglist.addItem(AV21Message.gxTpr_Description);
            AV66GXV23 = (int)(AV66GXV23+1);
         }
      }

      protected void S172( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("testagregarparticipante",pr_default);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E173Y2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA3Y2( ) ;
         WS3Y2( ) ;
         WE3Y2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20265111131861", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("testagregarparticipante.js", "?20265111131861", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavUsuario_usuariogenero.Name = "USUARIO_USUARIOGENERO";
         cmbavUsuario_usuariogenero.WebTags = "";
         cmbavUsuario_usuariogenero.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavUsuario_usuariogenero.addItem("Masculino", context.GetMessage( "Masculino", ""), 0);
         cmbavUsuario_usuariogenero.addItem("Femenino", context.GetMessage( "Femenino", ""), 0);
         if ( cmbavUsuario_usuariogenero.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariogenero = cmbavUsuario_usuariogenero.getValidValue(AV5Usuario.gxTpr_Usuariogenero);
         }
         cmbavUsuario_usuariodirectoasociado.Name = "USUARIO_USUARIODIRECTOASOCIADO";
         cmbavUsuario_usuariodirectoasociado.WebTags = "";
         cmbavUsuario_usuariodirectoasociado.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavUsuario_usuariodirectoasociado.addItem("Directo", context.GetMessage( "Directo", ""), 0);
         cmbavUsuario_usuariodirectoasociado.addItem("Asociado", context.GetMessage( "Asociado", ""), 0);
         if ( cmbavUsuario_usuariodirectoasociado.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariodirectoasociado = cmbavUsuario_usuariodirectoasociado.getValidValue(AV5Usuario.gxTpr_Usuariodirectoasociado);
         }
         cmbavUsuario_usuariozona.Name = "USUARIO_USUARIOZONA";
         cmbavUsuario_usuariozona.WebTags = "";
         cmbavUsuario_usuariozona.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavUsuario_usuariozona.addItem("Centro", context.GetMessage( "Centro", ""), 0);
         cmbavUsuario_usuariozona.addItem("Centro América", context.GetMessage( "Centro América", ""), 0);
         cmbavUsuario_usuariozona.addItem("Norte", context.GetMessage( "Norte", ""), 0);
         cmbavUsuario_usuariozona.addItem("Pacífico", context.GetMessage( "Pacifico", ""), 0);
         cmbavUsuario_usuariozona.addItem("Sur", context.GetMessage( "Sur", ""), 0);
         if ( cmbavUsuario_usuariozona.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariozona = cmbavUsuario_usuariozona.getValidValue(AV5Usuario.gxTpr_Usuariozona);
         }
         cmbavUsuario_usuarioproducto.Name = "USUARIO_USUARIOPRODUCTO";
         cmbavUsuario_usuarioproducto.WebTags = "";
         cmbavUsuario_usuarioproducto.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavUsuario_usuarioproducto.addItem("Auto y Camioneta", context.GetMessage( "Auto y Camioneta", ""), 0);
         cmbavUsuario_usuarioproducto.addItem("Auto y Camioneta/Camión", context.GetMessage( "Auto y Camioneta/Camión", ""), 0);
         cmbavUsuario_usuarioproducto.addItem("Camión", context.GetMessage( "Camión", ""), 0);
         cmbavUsuario_usuarioproducto.addItem("Empleado", context.GetMessage( "Empleado", ""), 0);
         cmbavUsuario_usuarioproducto.addItem("OTR/Camión", context.GetMessage( "OTR/Camión", ""), 0);
         if ( cmbavUsuario_usuarioproducto.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuarioproducto = cmbavUsuario_usuarioproducto.getValidValue(AV5Usuario.gxTpr_Usuarioproducto);
         }
         cmbavUsuario_usuariorol.Name = "USUARIO_USUARIOROL";
         cmbavUsuario_usuariorol.WebTags = "";
         cmbavUsuario_usuariorol.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavUsuario_usuariorol.addItem("Super Administrador", context.GetMessage( "Super Administrador", ""), 0);
         cmbavUsuario_usuariorol.addItem("Administrador Yokohama", context.GetMessage( "Administrador Yokohama", ""), 0);
         cmbavUsuario_usuariorol.addItem("Asesor", context.GetMessage( "Asesor", ""), 0);
         cmbavUsuario_usuariorol.addItem("Participante", context.GetMessage( "Participante", ""), 0);
         if ( cmbavUsuario_usuariorol.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariorol = cmbavUsuario_usuariorol.getValidValue(AV5Usuario.gxTpr_Usuariorol);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavUsuario_usuarionombre_Internalname = "USUARIO_USUARIONOMBRE";
         edtavUsuario_usuarioapellido_Internalname = "USUARIO_USUARIOAPELLIDO";
         edtavUsuario_usuariocorreo_Internalname = "USUARIO_USUARIOCORREO";
         cmbavUsuario_usuariogenero_Internalname = "USUARIO_USUARIOGENERO";
         edtavUsuario_usuariofechanacimiento_Internalname = "USUARIO_USUARIOFECHANACIMIENTO";
         edtavUsuario_usuariocelular_Internalname = "USUARIO_USUARIOCELULAR";
         lblTextblockcombo_usuario_puestoid_Internalname = "TEXTBLOCKCOMBO_USUARIO_PUESTOID";
         Combo_usuario_puestoid_Internalname = "COMBO_USUARIO_PUESTOID";
         divTablesplittedusuario_puestoid_Internalname = "TABLESPLITTEDUSUARIO_PUESTOID";
         edtavPass_Internalname = "vPASS";
         edtavPass2_Internalname = "vPASS2";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         edtavUsuario_usuariorazonsocialasociado_Internalname = "USUARIO_USUARIORAZONSOCIALASOCIADO";
         edtavUsuario_usuarionombrecomercial_Internalname = "USUARIO_USUARIONOMBRECOMERCIAL";
         edtavUsuario_usuariosucursal_Internalname = "USUARIO_USUARIOSUCURSAL";
         cmbavUsuario_usuariodirectoasociado_Internalname = "USUARIO_USUARIODIRECTOASOCIADO";
         lblTextblockcombo_paisid_Internalname = "TEXTBLOCKCOMBO_PAISID";
         Combo_paisid_Internalname = "COMBO_PAISID";
         divTablesplittedpaisid_Internalname = "TABLESPLITTEDPAISID";
         lblTextblockcombo_estadoid_Internalname = "TEXTBLOCKCOMBO_ESTADOID";
         Combo_estadoid_Internalname = "COMBO_ESTADOID";
         divTablesplittedestadoid_Internalname = "TABLESPLITTEDESTADOID";
         lblTextblockcombo_usuario_ciudadid_Internalname = "TEXTBLOCKCOMBO_USUARIO_CIUDADID";
         Combo_usuario_ciudadid_Internalname = "COMBO_USUARIO_CIUDADID";
         divTablesplittedusuario_ciudadid_Internalname = "TABLESPLITTEDUSUARIO_CIUDADID";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         edtavUsuario_usuariocallenum_Internalname = "USUARIO_USUARIOCALLENUM";
         edtavUsuario_usuariocolonia_Internalname = "USUARIO_USUARIOCOLONIA";
         edtavUsuario_usuariodelegacion_Internalname = "USUARIO_USUARIODELEGACION";
         edtavUsuario_usuariocp_Internalname = "USUARIO_USUARIOCP";
         cmbavUsuario_usuariozona_Internalname = "USUARIO_USUARIOZONA";
         edtavUsuario_usuariotelefonosucursal_Internalname = "USUARIO_USUARIOTELEFONOSUCURSAL";
         cmbavUsuario_usuarioproducto_Internalname = "USUARIO_USUARIOPRODUCTO";
         edtavUsuario_usuarionocuentabroxel_Internalname = "USUARIO_USUARIONOCUENTABROXEL";
         edtavUsuario_usuarioreferenciabroxel_Internalname = "USUARIO_USUARIOREFERENCIABROXEL";
         lblTextblockcombo_distribuidorid_Internalname = "TEXTBLOCKCOMBO_DISTRIBUIDORID";
         Combo_distribuidorid_Internalname = "COMBO_DISTRIBUIDORID";
         divTablesplitteddistribuidorid_Internalname = "TABLESPLITTEDDISTRIBUIDORID";
         divTabledistribuidor_Internalname = "TABLEDISTRIBUIDOR";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divDatosdistribuidor_Internalname = "DATOSDISTRIBUIDOR";
         Dvpanel_datosdistribuidor_Internalname = "DVPANEL_DATOSDISTRIBUIDOR";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavPaisid_Internalname = "vPAISID";
         edtavEstadoid_Internalname = "vESTADOID";
         edtavDistribuidorid_Internalname = "vDISTRIBUIDORID";
         cmbavUsuario_usuariorol_Internalname = "USUARIO_USUARIOROL";
         edtavUsuario_usuarioid_Internalname = "USUARIO_USUARIOID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavUsuario_usuarioid_Jsonclick = "";
         edtavUsuario_usuarioid_Visible = 1;
         cmbavUsuario_usuariorol_Jsonclick = "";
         cmbavUsuario_usuariorol.Visible = 1;
         edtavDistribuidorid_Jsonclick = "";
         edtavDistribuidorid_Visible = 1;
         edtavEstadoid_Jsonclick = "";
         edtavEstadoid_Visible = 1;
         edtavPaisid_Jsonclick = "";
         edtavPaisid_Visible = 1;
         Combo_distribuidorid_Caption = "";
         edtavUsuario_usuarioreferenciabroxel_Jsonclick = "";
         edtavUsuario_usuarioreferenciabroxel_Enabled = 1;
         edtavUsuario_usuarionocuentabroxel_Jsonclick = "";
         edtavUsuario_usuarionocuentabroxel_Enabled = 1;
         cmbavUsuario_usuarioproducto_Jsonclick = "";
         cmbavUsuario_usuarioproducto.Enabled = 1;
         edtavUsuario_usuariotelefonosucursal_Jsonclick = "";
         edtavUsuario_usuariotelefonosucursal_Enabled = 1;
         cmbavUsuario_usuariozona_Jsonclick = "";
         cmbavUsuario_usuariozona.Enabled = 1;
         edtavUsuario_usuariocp_Jsonclick = "";
         edtavUsuario_usuariocp_Enabled = 1;
         edtavUsuario_usuariodelegacion_Jsonclick = "";
         edtavUsuario_usuariodelegacion_Enabled = 1;
         edtavUsuario_usuariocolonia_Jsonclick = "";
         edtavUsuario_usuariocolonia_Enabled = 1;
         edtavUsuario_usuariocallenum_Jsonclick = "";
         edtavUsuario_usuariocallenum_Enabled = 1;
         Combo_usuario_ciudadid_Caption = "";
         Combo_estadoid_Caption = "";
         Combo_paisid_Caption = "";
         cmbavUsuario_usuariodirectoasociado_Jsonclick = "";
         cmbavUsuario_usuariodirectoasociado.Enabled = 1;
         edtavUsuario_usuariosucursal_Jsonclick = "";
         edtavUsuario_usuariosucursal_Enabled = 1;
         edtavUsuario_usuarionombrecomercial_Jsonclick = "";
         edtavUsuario_usuarionombrecomercial_Enabled = 1;
         edtavUsuario_usuariorazonsocialasociado_Jsonclick = "";
         edtavUsuario_usuariorazonsocialasociado_Enabled = 1;
         edtavPass2_Jsonclick = "";
         edtavPass2_Enabled = 1;
         edtavPass_Jsonclick = "";
         edtavPass_Enabled = 1;
         Combo_usuario_puestoid_Caption = "";
         edtavUsuario_usuariocelular_Jsonclick = "";
         edtavUsuario_usuariocelular_Enabled = 1;
         edtavUsuario_usuariofechanacimiento_Jsonclick = "";
         edtavUsuario_usuariofechanacimiento_Enabled = 1;
         cmbavUsuario_usuariogenero_Jsonclick = "";
         cmbavUsuario_usuariogenero.Enabled = 1;
         edtavUsuario_usuariocorreo_Jsonclick = "";
         edtavUsuario_usuariocorreo_Enabled = 1;
         edtavUsuario_usuarioapellido_Jsonclick = "";
         edtavUsuario_usuarioapellido_Enabled = 1;
         edtavUsuario_usuarionombre_Jsonclick = "";
         edtavUsuario_usuarionombre_Enabled = 1;
         Dvpanel_datosdistribuidor_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_datosdistribuidor_Iconposition = "Right";
         Dvpanel_datosdistribuidor_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_datosdistribuidor_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_datosdistribuidor_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_datosdistribuidor_Title = context.GetMessage( "Datos Distribuidor", "");
         Dvpanel_datosdistribuidor_Cls = "PanelCard_GrayTitle";
         Dvpanel_datosdistribuidor_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_datosdistribuidor_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_datosdistribuidor_Width = "100%";
         Combo_distribuidorid_Cls = "ExtendedCombo AttributeFL";
         Combo_usuario_ciudadid_Datalistprocparametersprefix = "";
         Combo_usuario_ciudadid_Datalistproc = "TestAgregarParticipanteLoadDVCombo";
         Combo_usuario_ciudadid_Cls = "ExtendedCombo AttributeFL";
         Combo_estadoid_Datalistprocparametersprefix = "";
         Combo_estadoid_Datalistproc = "TestAgregarParticipanteLoadDVCombo";
         Combo_estadoid_Cls = "ExtendedCombo AttributeFL";
         Combo_paisid_Cls = "ExtendedCombo AttributeFL";
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = context.GetMessage( "Datos personales", "");
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         Combo_usuario_puestoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_usuario_puestoid_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Agregar Participante", "");
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("COMBO_USUARIO_CIUDADID.ONOPTIONCLICKED","""{"handler":"E143Y2","iparms":[{"av":"Combo_usuario_ciudadid_Selectedvalue_get","ctrl":"COMBO_USUARIO_CIUDADID","prop":"SelectedValue_get"},{"av":"AV5Usuario","fld":"vUSUARIO"}]""");
         setEventMetadata("COMBO_USUARIO_CIUDADID.ONOPTIONCLICKED",""","oparms":[{"av":"AV5Usuario","fld":"vUSUARIO"}]}""");
         setEventMetadata("COMBO_ESTADOID.ONOPTIONCLICKED","""{"handler":"E133Y2","iparms":[{"av":"AV9EstadoID","fld":"vESTADOID","pic":"ZZZZZZZZ9"},{"av":"Combo_estadoid_Selectedvalue_get","ctrl":"COMBO_ESTADOID","prop":"SelectedValue_get"},{"av":"AV5Usuario","fld":"vUSUARIO"}]""");
         setEventMetadata("COMBO_ESTADOID.ONOPTIONCLICKED",""","oparms":[{"av":"AV19Cond_EstadoID","fld":"vCOND_ESTADOID","pic":"ZZZZZZZZ9"},{"av":"AV9EstadoID","fld":"vESTADOID","pic":"ZZZZZZZZ9"},{"av":"AV5Usuario","fld":"vUSUARIO"},{"av":"Combo_usuario_ciudadid_Selectedvalue_set","ctrl":"COMBO_USUARIO_CIUDADID","prop":"SelectedValue_set"},{"av":"Combo_usuario_ciudadid_Selectedtext_set","ctrl":"COMBO_USUARIO_CIUDADID","prop":"SelectedText_set"}]}""");
         setEventMetadata("COMBO_PAISID.ONOPTIONCLICKED","""{"handler":"E123Y2","iparms":[{"av":"AV8PaisID","fld":"vPAISID","pic":"ZZZZZZZZ9"},{"av":"Combo_paisid_Selectedvalue_get","ctrl":"COMBO_PAISID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_PAISID.ONOPTIONCLICKED",""","oparms":[{"av":"AV17Cond_PaisID","fld":"vCOND_PAISID","pic":"ZZZZZZZZ9"},{"av":"AV8PaisID","fld":"vPAISID","pic":"ZZZZZZZZ9"},{"av":"AV9EstadoID","fld":"vESTADOID","pic":"ZZZZZZZZ9"},{"av":"Combo_estadoid_Selectedvalue_set","ctrl":"COMBO_ESTADOID","prop":"SelectedValue_set"},{"av":"Combo_estadoid_Selectedtext_set","ctrl":"COMBO_ESTADOID","prop":"SelectedText_set"}]}""");
         setEventMetadata("COMBO_USUARIO_PUESTOID.ONOPTIONCLICKED","""{"handler":"E113Y2","iparms":[{"av":"Combo_usuario_puestoid_Selectedvalue_get","ctrl":"COMBO_USUARIO_PUESTOID","prop":"SelectedValue_get"},{"av":"AV5Usuario","fld":"vUSUARIO"}]""");
         setEventMetadata("COMBO_USUARIO_PUESTOID.ONOPTIONCLICKED",""","oparms":[{"av":"AV5Usuario","fld":"vUSUARIO"}]}""");
         setEventMetadata("ENTER","""{"handler":"E163Y2","iparms":[{"av":"AV6Pass","fld":"vPASS"},{"av":"AV7Pass2","fld":"vPASS2"},{"av":"AV5Usuario","fld":"vUSUARIO"},{"av":"AV11CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10DistribuidorID","fld":"vDISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"Combo_usuario_puestoid_Ddointernalname","ctrl":"COMBO_USUARIO_PUESTOID","prop":"DDOInternalName"},{"av":"AV8PaisID","fld":"vPAISID","pic":"ZZZZZZZZ9"},{"av":"Combo_paisid_Ddointernalname","ctrl":"COMBO_PAISID","prop":"DDOInternalName"},{"av":"AV9EstadoID","fld":"vESTADOID","pic":"ZZZZZZZZ9"},{"av":"Combo_estadoid_Ddointernalname","ctrl":"COMBO_ESTADOID","prop":"DDOInternalName"},{"av":"Combo_usuario_ciudadid_Ddointernalname","ctrl":"COMBO_USUARIO_CIUDADID","prop":"DDOInternalName"},{"av":"Combo_distribuidorid_Ddointernalname","ctrl":"COMBO_DISTRIBUIDORID","prop":"DDOInternalName"},{"av":"AV22Messages","fld":"vMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5Usuario","fld":"vUSUARIO"},{"av":"AV22Messages","fld":"vMESSAGES"},{"av":"AV11CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV10","""{"handler":"Validv_Gxv10","iparms":[]}""");
         setEventMetadata("VALIDV_GXV15","""{"handler":"Validv_Gxv15","iparms":[]}""");
         setEventMetadata("VALIDV_GXV17","""{"handler":"Validv_Gxv17","iparms":[]}""");
         setEventMetadata("VALIDV_ESTADOID","""{"handler":"Validv_Estadoid","iparms":[]}""");
         setEventMetadata("VALIDV_GXV20","""{"handler":"Validv_Gxv20","iparms":[]}""");
         return  ;
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
         Combo_distribuidorid_Selectedvalue_get = "";
         Combo_usuario_ciudadid_Selectedvalue_get = "";
         Combo_estadoid_Selectedvalue_get = "";
         Combo_paisid_Selectedvalue_get = "";
         Combo_usuario_puestoid_Selectedvalue_get = "";
         Combo_usuario_puestoid_Ddointernalname = "";
         Combo_paisid_Ddointernalname = "";
         Combo_estadoid_Ddointernalname = "";
         Combo_usuario_ciudadid_Ddointernalname = "";
         Combo_distribuidorid_Ddointernalname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV5Usuario = new SdtUsuario(context);
         AV13DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12Usuario_PuestoID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV15PaisID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV16EstadoID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV18Usuario_CiudadID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV20DistribuidorID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV22Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         Combo_usuario_puestoid_Selectedvalue_set = "";
         Combo_paisid_Selectedvalue_set = "";
         Combo_estadoid_Selectedvalue_set = "";
         Combo_estadoid_Selectedtext_set = "";
         Combo_usuario_ciudadid_Selectedvalue_set = "";
         Combo_usuario_ciudadid_Selectedtext_set = "";
         Combo_distribuidorid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         lblTextblockcombo_usuario_puestoid_Jsonclick = "";
         ucCombo_usuario_puestoid = new GXUserControl();
         AV6Pass = "";
         AV7Pass2 = "";
         lblTextblock1_Jsonclick = "";
         ucDvpanel_datosdistribuidor = new GXUserControl();
         lblTextblockcombo_paisid_Jsonclick = "";
         ucCombo_paisid = new GXUserControl();
         lblTextblockcombo_estadoid_Jsonclick = "";
         ucCombo_estadoid = new GXUserControl();
         lblTextblockcombo_usuario_ciudadid_Jsonclick = "";
         ucCombo_usuario_ciudadid = new GXUserControl();
         lblTextblockcombo_distribuidorid_Jsonclick = "";
         ucCombo_distribuidorid = new GXUserControl();
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV30UsuarioJSON = "";
         AV31WebSession = context.GetSession();
         AV32SDTUsuario = new SdtSDTUsuario(context);
         AV23TrnMode = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV34DistribuidorIDCol = new GxSimpleCollection<int>();
         H003Y2_A81DistribuidoresUsuarioID = new int[1] ;
         H003Y2_A29UsuarioID = new int[1] ;
         H003Y2_A10DistribuidorID = new int[1] ;
         H003Y3_A10DistribuidorID = new int[1] ;
         H003Y3_A11DistribuidorDescripcion = new string[] {""} ;
         A11DistribuidorDescripcion = "";
         AV14Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         H003Y4_A1EstadoID = new int[1] ;
         H003Y4_A4CiudadID = new int[1] ;
         H003Y4_A5CiudadDescripcion = new string[] {""} ;
         A5CiudadDescripcion = "";
         H003Y5_A16PaisID = new int[1] ;
         H003Y5_A1EstadoID = new int[1] ;
         H003Y5_A2EstadoDescripcion = new string[] {""} ;
         A2EstadoDescripcion = "";
         H003Y6_A16PaisID = new int[1] ;
         H003Y6_A17PaisDescripcion = new string[] {""} ;
         A17PaisDescripcion = "";
         H003Y7_A15PuestoActivo = new bool[] {false} ;
         H003Y7_A13PuestoID = new int[1] ;
         H003Y7_A14PuestoDescripcion = new string[] {""} ;
         A14PuestoDescripcion = "";
         AV29UsuarioKey = "";
         AV28DistribuidoresUsuario = new SdtDistribuidoresUsuario(context);
         AV21Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.testagregarparticipante__default(),
            new Object[][] {
                new Object[] {
               H003Y2_A81DistribuidoresUsuarioID, H003Y2_A29UsuarioID, H003Y2_A10DistribuidorID
               }
               , new Object[] {
               H003Y3_A10DistribuidorID, H003Y3_A11DistribuidorDescripcion
               }
               , new Object[] {
               H003Y4_A1EstadoID, H003Y4_A4CiudadID, H003Y4_A5CiudadDescripcion
               }
               , new Object[] {
               H003Y5_A16PaisID, H003Y5_A1EstadoID, H003Y5_A2EstadoDescripcion
               }
               , new Object[] {
               H003Y6_A16PaisID, H003Y6_A17PaisDescripcion
               }
               , new Object[] {
               H003Y7_A15PuestoActivo, H003Y7_A13PuestoID, H003Y7_A14PuestoDescripcion
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV62GXLvl220 ;
      private short AV63GXLvl241 ;
      private short nGXWrapped ;
      private int edtavUsuario_usuarionombre_Enabled ;
      private int edtavUsuario_usuarioapellido_Enabled ;
      private int edtavUsuario_usuariocorreo_Enabled ;
      private int edtavUsuario_usuariofechanacimiento_Enabled ;
      private int edtavUsuario_usuariocelular_Enabled ;
      private int edtavPass_Enabled ;
      private int edtavPass2_Enabled ;
      private int edtavUsuario_usuariorazonsocialasociado_Enabled ;
      private int edtavUsuario_usuarionombrecomercial_Enabled ;
      private int edtavUsuario_usuariosucursal_Enabled ;
      private int edtavUsuario_usuariocallenum_Enabled ;
      private int edtavUsuario_usuariocolonia_Enabled ;
      private int edtavUsuario_usuariodelegacion_Enabled ;
      private int edtavUsuario_usuariocp_Enabled ;
      private int edtavUsuario_usuariotelefonosucursal_Enabled ;
      private int edtavUsuario_usuarionocuentabroxel_Enabled ;
      private int edtavUsuario_usuarioreferenciabroxel_Enabled ;
      private int AV8PaisID ;
      private int edtavPaisid_Visible ;
      private int AV9EstadoID ;
      private int edtavEstadoid_Visible ;
      private int AV10DistribuidorID ;
      private int edtavDistribuidorid_Visible ;
      private int edtavUsuario_usuarioid_Visible ;
      private int AV33UsuarioIDIngresa ;
      private int AV19Cond_EstadoID ;
      private int AV17Cond_PaisID ;
      private int A29UsuarioID ;
      private int A10DistribuidorID ;
      private int AV60GXV22 ;
      private int AV37DistribuidorIDItem ;
      private int A1EstadoID ;
      private int A4CiudadID ;
      private int A16PaisID ;
      private int A13PuestoID ;
      private int AV26UsuarioID ;
      private int AV66GXV23 ;
      private int idxLst ;
      private string Combo_distribuidorid_Selectedvalue_get ;
      private string Combo_usuario_ciudadid_Selectedvalue_get ;
      private string Combo_estadoid_Selectedvalue_get ;
      private string Combo_paisid_Selectedvalue_get ;
      private string Combo_usuario_puestoid_Selectedvalue_get ;
      private string Combo_usuario_puestoid_Ddointernalname ;
      private string Combo_paisid_Ddointernalname ;
      private string Combo_estadoid_Ddointernalname ;
      private string Combo_usuario_ciudadid_Ddointernalname ;
      private string Combo_distribuidorid_Ddointernalname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_usuario_puestoid_Cls ;
      private string Combo_usuario_puestoid_Selectedvalue_set ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Combo_paisid_Cls ;
      private string Combo_paisid_Selectedvalue_set ;
      private string Combo_estadoid_Cls ;
      private string Combo_estadoid_Selectedvalue_set ;
      private string Combo_estadoid_Selectedtext_set ;
      private string Combo_estadoid_Datalistproc ;
      private string Combo_estadoid_Datalistprocparametersprefix ;
      private string Combo_usuario_ciudadid_Cls ;
      private string Combo_usuario_ciudadid_Selectedvalue_set ;
      private string Combo_usuario_ciudadid_Selectedtext_set ;
      private string Combo_usuario_ciudadid_Datalistproc ;
      private string Combo_usuario_ciudadid_Datalistprocparametersprefix ;
      private string Combo_distribuidorid_Cls ;
      private string Combo_distribuidorid_Selectedvalue_set ;
      private string Dvpanel_datosdistribuidor_Width ;
      private string Dvpanel_datosdistribuidor_Cls ;
      private string Dvpanel_datosdistribuidor_Title ;
      private string Dvpanel_datosdistribuidor_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavUsuario_usuarionombre_Internalname ;
      private string TempTags ;
      private string edtavUsuario_usuarionombre_Jsonclick ;
      private string edtavUsuario_usuarioapellido_Internalname ;
      private string edtavUsuario_usuarioapellido_Jsonclick ;
      private string edtavUsuario_usuariocorreo_Internalname ;
      private string edtavUsuario_usuariocorreo_Jsonclick ;
      private string cmbavUsuario_usuariogenero_Internalname ;
      private string cmbavUsuario_usuariogenero_Jsonclick ;
      private string edtavUsuario_usuariofechanacimiento_Internalname ;
      private string edtavUsuario_usuariofechanacimiento_Jsonclick ;
      private string edtavUsuario_usuariocelular_Internalname ;
      private string edtavUsuario_usuariocelular_Jsonclick ;
      private string divTablesplittedusuario_puestoid_Internalname ;
      private string lblTextblockcombo_usuario_puestoid_Internalname ;
      private string lblTextblockcombo_usuario_puestoid_Jsonclick ;
      private string Combo_usuario_puestoid_Caption ;
      private string Combo_usuario_puestoid_Internalname ;
      private string edtavPass_Internalname ;
      private string AV6Pass ;
      private string edtavPass_Jsonclick ;
      private string edtavPass2_Internalname ;
      private string AV7Pass2 ;
      private string edtavPass2_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string Dvpanel_datosdistribuidor_Internalname ;
      private string divDatosdistribuidor_Internalname ;
      private string edtavUsuario_usuariorazonsocialasociado_Internalname ;
      private string edtavUsuario_usuariorazonsocialasociado_Jsonclick ;
      private string edtavUsuario_usuarionombrecomercial_Internalname ;
      private string edtavUsuario_usuarionombrecomercial_Jsonclick ;
      private string edtavUsuario_usuariosucursal_Internalname ;
      private string edtavUsuario_usuariosucursal_Jsonclick ;
      private string cmbavUsuario_usuariodirectoasociado_Internalname ;
      private string cmbavUsuario_usuariodirectoasociado_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string divTablesplittedpaisid_Internalname ;
      private string lblTextblockcombo_paisid_Internalname ;
      private string lblTextblockcombo_paisid_Jsonclick ;
      private string Combo_paisid_Caption ;
      private string Combo_paisid_Internalname ;
      private string divTablesplittedestadoid_Internalname ;
      private string lblTextblockcombo_estadoid_Internalname ;
      private string lblTextblockcombo_estadoid_Jsonclick ;
      private string Combo_estadoid_Caption ;
      private string Combo_estadoid_Internalname ;
      private string divTablesplittedusuario_ciudadid_Internalname ;
      private string lblTextblockcombo_usuario_ciudadid_Internalname ;
      private string lblTextblockcombo_usuario_ciudadid_Jsonclick ;
      private string Combo_usuario_ciudadid_Caption ;
      private string Combo_usuario_ciudadid_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtavUsuario_usuariocallenum_Internalname ;
      private string edtavUsuario_usuariocallenum_Jsonclick ;
      private string edtavUsuario_usuariocolonia_Internalname ;
      private string edtavUsuario_usuariocolonia_Jsonclick ;
      private string edtavUsuario_usuariodelegacion_Internalname ;
      private string edtavUsuario_usuariodelegacion_Jsonclick ;
      private string edtavUsuario_usuariocp_Internalname ;
      private string edtavUsuario_usuariocp_Jsonclick ;
      private string cmbavUsuario_usuariozona_Internalname ;
      private string cmbavUsuario_usuariozona_Jsonclick ;
      private string edtavUsuario_usuariotelefonosucursal_Internalname ;
      private string edtavUsuario_usuariotelefonosucursal_Jsonclick ;
      private string cmbavUsuario_usuarioproducto_Internalname ;
      private string cmbavUsuario_usuarioproducto_Jsonclick ;
      private string edtavUsuario_usuarionocuentabroxel_Internalname ;
      private string edtavUsuario_usuarionocuentabroxel_Jsonclick ;
      private string edtavUsuario_usuarioreferenciabroxel_Internalname ;
      private string edtavUsuario_usuarioreferenciabroxel_Jsonclick ;
      private string divTabledistribuidor_Internalname ;
      private string divTablesplitteddistribuidorid_Internalname ;
      private string lblTextblockcombo_distribuidorid_Internalname ;
      private string lblTextblockcombo_distribuidorid_Jsonclick ;
      private string Combo_distribuidorid_Caption ;
      private string Combo_distribuidorid_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavPaisid_Internalname ;
      private string edtavPaisid_Jsonclick ;
      private string edtavEstadoid_Internalname ;
      private string edtavEstadoid_Jsonclick ;
      private string edtavDistribuidorid_Internalname ;
      private string edtavDistribuidorid_Jsonclick ;
      private string cmbavUsuario_usuariorol_Internalname ;
      private string cmbavUsuario_usuariorol_Jsonclick ;
      private string edtavUsuario_usuarioid_Internalname ;
      private string edtavUsuario_usuarioid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV23TrnMode ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV11CheckRequiredFieldsResult ;
      private bool Combo_usuario_puestoid_Emptyitem ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_datosdistribuidor_Autowidth ;
      private bool Dvpanel_datosdistribuidor_Autoheight ;
      private bool Dvpanel_datosdistribuidor_Collapsible ;
      private bool Dvpanel_datosdistribuidor_Collapsed ;
      private bool Dvpanel_datosdistribuidor_Showcollapseicon ;
      private bool Dvpanel_datosdistribuidor_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV24LoadSuccess ;
      private bool AV36YaExiste ;
      private bool A15PuestoActivo ;
      private string AV30UsuarioJSON ;
      private string A11DistribuidorDescripcion ;
      private string A5CiudadDescripcion ;
      private string A2EstadoDescripcion ;
      private string A17PaisDescripcion ;
      private string A14PuestoDescripcion ;
      private string AV29UsuarioKey ;
      private IGxSession AV31WebSession ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_usuario_puestoid ;
      private GXUserControl ucDvpanel_datosdistribuidor ;
      private GXUserControl ucCombo_paisid ;
      private GXUserControl ucCombo_estadoid ;
      private GXUserControl ucCombo_usuario_ciudadid ;
      private GXUserControl ucCombo_distribuidorid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavUsuario_usuariogenero ;
      private GXCombobox cmbavUsuario_usuariodirectoasociado ;
      private GXCombobox cmbavUsuario_usuariozona ;
      private GXCombobox cmbavUsuario_usuarioproducto ;
      private GXCombobox cmbavUsuario_usuariorol ;
      private SdtUsuario AV5Usuario ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV13DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV12Usuario_PuestoID_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15PaisID_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV16EstadoID_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV18Usuario_CiudadID_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV20DistribuidorID_Data ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV22Messages ;
      private SdtSDTUsuario AV32SDTUsuario ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GxSimpleCollection<int> AV34DistribuidorIDCol ;
      private IDataStoreProvider pr_default ;
      private int[] H003Y2_A81DistribuidoresUsuarioID ;
      private int[] H003Y2_A29UsuarioID ;
      private int[] H003Y2_A10DistribuidorID ;
      private int[] H003Y3_A10DistribuidorID ;
      private string[] H003Y3_A11DistribuidorDescripcion ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
      private int[] H003Y4_A1EstadoID ;
      private int[] H003Y4_A4CiudadID ;
      private string[] H003Y4_A5CiudadDescripcion ;
      private int[] H003Y5_A16PaisID ;
      private int[] H003Y5_A1EstadoID ;
      private string[] H003Y5_A2EstadoDescripcion ;
      private int[] H003Y6_A16PaisID ;
      private string[] H003Y6_A17PaisDescripcion ;
      private bool[] H003Y7_A15PuestoActivo ;
      private int[] H003Y7_A13PuestoID ;
      private string[] H003Y7_A14PuestoDescripcion ;
      private SdtDistribuidoresUsuario AV28DistribuidoresUsuario ;
      private GeneXus.Utils.SdtMessages_Message AV21Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class testagregarparticipante__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003Y3( IGxContext context ,
                                             int A10DistribuidorID ,
                                             GxSimpleCollection<int> AV34DistribuidorIDCol )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT `DistribuidorID`, `DistribuidorDescripcion` FROM `Distribuidor`";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV34DistribuidorIDCol, "`DistribuidorID` IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `DistribuidorDescripcion`";
         GXv_Object2[0] = scmdbuf;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H003Y3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH003Y2;
          prmH003Y2 = new Object[] {
          new ParDef("@AV33UsuarioIDIngresa",GXType.Int32,9,0)
          };
          Object[] prmH003Y4;
          prmH003Y4 = new Object[] {
          new ParDef("@AV5Usuario__Ciudadid",GXType.Int32,9,0) ,
          new ParDef("@AV19Cond_EstadoID",GXType.Int32,9,0)
          };
          Object[] prmH003Y5;
          prmH003Y5 = new Object[] {
          new ParDef("@AV9EstadoID",GXType.Int32,9,0) ,
          new ParDef("@AV17Cond_PaisID",GXType.Int32,9,0)
          };
          Object[] prmH003Y6;
          prmH003Y6 = new Object[] {
          };
          Object[] prmH003Y7;
          prmH003Y7 = new Object[] {
          };
          Object[] prmH003Y3;
          prmH003Y3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H003Y2", "SELECT `DistribuidoresUsuarioID`, `UsuarioID`, `DistribuidorID` FROM `DistribuidoresUsuario` WHERE `UsuarioID` = @AV33UsuarioIDIngresa ORDER BY `UsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Y2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H003Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Y3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H003Y4", "SELECT `EstadoID`, `CiudadID`, `CiudadDescripcion` FROM `Ciudad` WHERE (`CiudadID` = @AV5Usuario__Ciudadid) AND (`EstadoID` = @AV19Cond_EstadoID) ORDER BY `CiudadID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Y4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H003Y5", "SELECT `PaisID`, `EstadoID`, `EstadoDescripcion` FROM `Estado` WHERE (`EstadoID` = @AV9EstadoID) AND (`PaisID` = @AV17Cond_PaisID) ORDER BY `EstadoID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Y5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H003Y6", "SELECT `PaisID`, `PaisDescripcion` FROM `Pais` ORDER BY `PaisDescripcion` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Y6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H003Y7", "SELECT `PuestoActivo`, `PuestoID`, `PuestoDescripcion` FROM `Puesto` WHERE `PuestoActivo` = 1 ORDER BY `PuestoDescripcion` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Y7,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
