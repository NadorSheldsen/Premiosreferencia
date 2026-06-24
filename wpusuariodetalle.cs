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
   public class wpusuariodetalle : GXDataArea
   {
      public wpusuariodetalle( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpusuariodetalle( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_UsuarioID ,
                           string aP1_TabCode )
      {
         this.AV12UsuarioID = aP0_UsuarioID;
         this.AV15TabCode = aP1_TabCode;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "UsuarioID");
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
               gxfirstwebparm = GetFirstPar( "UsuarioID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "UsuarioID");
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
         PA312( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START312( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpusuariodetalle.aspx"+UrlEncode(StringUtil.LTrimStr(AV12UsuarioID,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV15TabCode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpusuariodetalle.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12UsuarioID), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV15TabCode));
         GxWebStd.gx_hidden_field( context, "DVPANEL_INFOGENERAL_Width", StringUtil.RTrim( Dvpanel_infogeneral_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_INFOGENERAL_Autowidth", StringUtil.BoolToStr( Dvpanel_infogeneral_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_INFOGENERAL_Autoheight", StringUtil.BoolToStr( Dvpanel_infogeneral_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_INFOGENERAL_Cls", StringUtil.RTrim( Dvpanel_infogeneral_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_INFOGENERAL_Title", StringUtil.RTrim( Dvpanel_infogeneral_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_INFOGENERAL_Collapsible", StringUtil.BoolToStr( Dvpanel_infogeneral_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_INFOGENERAL_Collapsed", StringUtil.BoolToStr( Dvpanel_infogeneral_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_INFOGENERAL_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_infogeneral_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_INFOGENERAL_Iconposition", StringUtil.RTrim( Dvpanel_infogeneral_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_INFOGENERAL_Autoscroll", StringUtil.BoolToStr( Dvpanel_infogeneral_Autoscroll));
         GxWebStd.gx_hidden_field( context, "PANEL_DISTRIBUIDORESUSUARIO_Width", StringUtil.RTrim( Panel_distribuidoresusuario_Width));
         GxWebStd.gx_hidden_field( context, "PANEL_DISTRIBUIDORESUSUARIO_Autowidth", StringUtil.BoolToStr( Panel_distribuidoresusuario_Autowidth));
         GxWebStd.gx_hidden_field( context, "PANEL_DISTRIBUIDORESUSUARIO_Autoheight", StringUtil.BoolToStr( Panel_distribuidoresusuario_Autoheight));
         GxWebStd.gx_hidden_field( context, "PANEL_DISTRIBUIDORESUSUARIO_Cls", StringUtil.RTrim( Panel_distribuidoresusuario_Cls));
         GxWebStd.gx_hidden_field( context, "PANEL_DISTRIBUIDORESUSUARIO_Title", StringUtil.RTrim( Panel_distribuidoresusuario_Title));
         GxWebStd.gx_hidden_field( context, "PANEL_DISTRIBUIDORESUSUARIO_Collapsible", StringUtil.BoolToStr( Panel_distribuidoresusuario_Collapsible));
         GxWebStd.gx_hidden_field( context, "PANEL_DISTRIBUIDORESUSUARIO_Collapsed", StringUtil.BoolToStr( Panel_distribuidoresusuario_Collapsed));
         GxWebStd.gx_hidden_field( context, "PANEL_DISTRIBUIDORESUSUARIO_Showcollapseicon", StringUtil.BoolToStr( Panel_distribuidoresusuario_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "PANEL_DISTRIBUIDORESUSUARIO_Iconposition", StringUtil.RTrim( Panel_distribuidoresusuario_Iconposition));
         GxWebStd.gx_hidden_field( context, "PANEL_DISTRIBUIDORESUSUARIO_Autoscroll", StringUtil.BoolToStr( Panel_distribuidoresusuario_Autoscroll));
         GxWebStd.gx_hidden_field( context, "PANEL_FACTURA_Width", StringUtil.RTrim( Panel_factura_Width));
         GxWebStd.gx_hidden_field( context, "PANEL_FACTURA_Autowidth", StringUtil.BoolToStr( Panel_factura_Autowidth));
         GxWebStd.gx_hidden_field( context, "PANEL_FACTURA_Autoheight", StringUtil.BoolToStr( Panel_factura_Autoheight));
         GxWebStd.gx_hidden_field( context, "PANEL_FACTURA_Cls", StringUtil.RTrim( Panel_factura_Cls));
         GxWebStd.gx_hidden_field( context, "PANEL_FACTURA_Title", StringUtil.RTrim( Panel_factura_Title));
         GxWebStd.gx_hidden_field( context, "PANEL_FACTURA_Collapsible", StringUtil.BoolToStr( Panel_factura_Collapsible));
         GxWebStd.gx_hidden_field( context, "PANEL_FACTURA_Collapsed", StringUtil.BoolToStr( Panel_factura_Collapsed));
         GxWebStd.gx_hidden_field( context, "PANEL_FACTURA_Showcollapseicon", StringUtil.BoolToStr( Panel_factura_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "PANEL_FACTURA_Iconposition", StringUtil.RTrim( Panel_factura_Iconposition));
         GxWebStd.gx_hidden_field( context, "PANEL_FACTURA_Autoscroll", StringUtil.BoolToStr( Panel_factura_Autoscroll));
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
         if ( ! ( WebComp_Wcwcdetalleusuariocol == null ) )
         {
            WebComp_Wcwcdetalleusuariocol.componentjscripts();
         }
         if ( ! ( WebComp_Webcomponent_distribuidoresusuario == null ) )
         {
            WebComp_Webcomponent_distribuidoresusuario.componentjscripts();
         }
         if ( ! ( WebComp_Webcomponent_factura == null ) )
         {
            WebComp_Webcomponent_factura.componentjscripts();
         }
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
            WE312( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT312( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpusuariodetalle.aspx"+UrlEncode(StringUtil.LTrimStr(AV12UsuarioID,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV15TabCode));
         return formatLink("wpusuariodetalle.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WPUsuarioDetalle" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WPUsuario Detalle", "") ;
      }

      protected void WB310( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain TableViewCardsCell ViewGridNoBorderCell", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ViewCardCellWidth60", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemaincomponent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_infogeneral.SetProperty("Width", Dvpanel_infogeneral_Width);
            ucDvpanel_infogeneral.SetProperty("AutoWidth", Dvpanel_infogeneral_Autowidth);
            ucDvpanel_infogeneral.SetProperty("AutoHeight", Dvpanel_infogeneral_Autoheight);
            ucDvpanel_infogeneral.SetProperty("Cls", Dvpanel_infogeneral_Cls);
            ucDvpanel_infogeneral.SetProperty("Title", Dvpanel_infogeneral_Title);
            ucDvpanel_infogeneral.SetProperty("Collapsible", Dvpanel_infogeneral_Collapsible);
            ucDvpanel_infogeneral.SetProperty("Collapsed", Dvpanel_infogeneral_Collapsed);
            ucDvpanel_infogeneral.SetProperty("ShowCollapseIcon", Dvpanel_infogeneral_Showcollapseicon);
            ucDvpanel_infogeneral.SetProperty("IconPosition", Dvpanel_infogeneral_Iconposition);
            ucDvpanel_infogeneral.SetProperty("AutoScroll", Dvpanel_infogeneral_Autoscroll);
            ucDvpanel_infogeneral.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_infogeneral_Internalname, "DVPANEL_INFOGENERALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_INFOGENERALContainer"+"InfoGeneral"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divInfogeneral_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0016"+"", StringUtil.RTrim( WebComp_Wcwcdetalleusuariocol_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0016"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwcdetalleusuariocol_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcdetalleusuariocol), StringUtil.Lower( WebComp_Wcwcdetalleusuariocol_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0016"+"");
                  }
                  WebComp_Wcwcdetalleusuariocol.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcdetalleusuariocol), StringUtil.Lower( WebComp_Wcwcdetalleusuariocol_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWpusuariodetalledistribuidoresusuariowc_cell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucPanel_distribuidoresusuario.SetProperty("Width", Panel_distribuidoresusuario_Width);
            ucPanel_distribuidoresusuario.SetProperty("AutoWidth", Panel_distribuidoresusuario_Autowidth);
            ucPanel_distribuidoresusuario.SetProperty("AutoHeight", Panel_distribuidoresusuario_Autoheight);
            ucPanel_distribuidoresusuario.SetProperty("Cls", Panel_distribuidoresusuario_Cls);
            ucPanel_distribuidoresusuario.SetProperty("Title", Panel_distribuidoresusuario_Title);
            ucPanel_distribuidoresusuario.SetProperty("Collapsible", Panel_distribuidoresusuario_Collapsible);
            ucPanel_distribuidoresusuario.SetProperty("Collapsed", Panel_distribuidoresusuario_Collapsed);
            ucPanel_distribuidoresusuario.SetProperty("ShowCollapseIcon", Panel_distribuidoresusuario_Showcollapseicon);
            ucPanel_distribuidoresusuario.SetProperty("IconPosition", Panel_distribuidoresusuario_Iconposition);
            ucPanel_distribuidoresusuario.SetProperty("AutoScroll", Panel_distribuidoresusuario_Autoscroll);
            ucPanel_distribuidoresusuario.Render(context, "dvelop.gxbootstrap.panel_al", Panel_distribuidoresusuario_Internalname, "PANEL_DISTRIBUIDORESUSUARIOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"PANEL_DISTRIBUIDORESUSUARIOContainer"+"TablePanel_DistribuidoresUsuario"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepanel_distribuidoresusuario_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0026"+"", StringUtil.RTrim( WebComp_Webcomponent_distribuidoresusuario_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0026"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Webcomponent_distribuidoresusuario_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_distribuidoresusuario), StringUtil.Lower( WebComp_Webcomponent_distribuidoresusuario_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0026"+"");
                  }
                  WebComp_Webcomponent_distribuidoresusuario.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_distribuidoresusuario), StringUtil.Lower( WebComp_Webcomponent_distribuidoresusuario_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWpusuariodetallefacturawc_cell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucPanel_factura.SetProperty("Width", Panel_factura_Width);
            ucPanel_factura.SetProperty("AutoWidth", Panel_factura_Autowidth);
            ucPanel_factura.SetProperty("AutoHeight", Panel_factura_Autoheight);
            ucPanel_factura.SetProperty("Cls", Panel_factura_Cls);
            ucPanel_factura.SetProperty("Title", Panel_factura_Title);
            ucPanel_factura.SetProperty("Collapsible", Panel_factura_Collapsible);
            ucPanel_factura.SetProperty("Collapsed", Panel_factura_Collapsed);
            ucPanel_factura.SetProperty("ShowCollapseIcon", Panel_factura_Showcollapseicon);
            ucPanel_factura.SetProperty("IconPosition", Panel_factura_Iconposition);
            ucPanel_factura.SetProperty("AutoScroll", Panel_factura_Autoscroll);
            ucPanel_factura.Render(context, "dvelop.gxbootstrap.panel_al", Panel_factura_Internalname, "PANEL_FACTURAContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"PANEL_FACTURAContainer"+"TablePanel_Factura"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepanel_factura_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0034"+"", StringUtil.RTrim( WebComp_Webcomponent_factura_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0034"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Webcomponent_factura_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_factura), StringUtil.Lower( WebComp_Webcomponent_factura_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0034"+"");
                  }
                  WebComp_Webcomponent_factura.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_factura), StringUtil.Lower( WebComp_Webcomponent_factura_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START312( )
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
         Form.Meta.addItem("description", context.GetMessage( "WPUsuario Detalle", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP310( ) ;
      }

      protected void WS312( )
      {
         START312( ) ;
         EVT312( ) ;
      }

      protected void EVT312( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E11312 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E12312 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 16 )
                        {
                           OldWcwcdetalleusuariocol = cgiGet( "W0016");
                           if ( ( StringUtil.Len( OldWcwcdetalleusuariocol) == 0 ) || ( StringUtil.StrCmp(OldWcwcdetalleusuariocol, WebComp_Wcwcdetalleusuariocol_Component) != 0 ) )
                           {
                              WebComp_Wcwcdetalleusuariocol = getWebComponent(GetType(), "GeneXus.Programs", OldWcwcdetalleusuariocol, new Object[] {context} );
                              WebComp_Wcwcdetalleusuariocol.ComponentInit();
                              WebComp_Wcwcdetalleusuariocol.Name = "OldWcwcdetalleusuariocol";
                              WebComp_Wcwcdetalleusuariocol_Component = OldWcwcdetalleusuariocol;
                           }
                           if ( StringUtil.Len( WebComp_Wcwcdetalleusuariocol_Component) != 0 )
                           {
                              WebComp_Wcwcdetalleusuariocol.componentprocess("W0016", "", sEvt);
                           }
                           WebComp_Wcwcdetalleusuariocol_Component = OldWcwcdetalleusuariocol;
                        }
                        else if ( nCmpId == 26 )
                        {
                           OldWebcomponent_distribuidoresusuario = cgiGet( "W0026");
                           if ( ( StringUtil.Len( OldWebcomponent_distribuidoresusuario) == 0 ) || ( StringUtil.StrCmp(OldWebcomponent_distribuidoresusuario, WebComp_Webcomponent_distribuidoresusuario_Component) != 0 ) )
                           {
                              WebComp_Webcomponent_distribuidoresusuario = getWebComponent(GetType(), "GeneXus.Programs", OldWebcomponent_distribuidoresusuario, new Object[] {context} );
                              WebComp_Webcomponent_distribuidoresusuario.ComponentInit();
                              WebComp_Webcomponent_distribuidoresusuario.Name = "OldWebcomponent_distribuidoresusuario";
                              WebComp_Webcomponent_distribuidoresusuario_Component = OldWebcomponent_distribuidoresusuario;
                           }
                           if ( StringUtil.Len( WebComp_Webcomponent_distribuidoresusuario_Component) != 0 )
                           {
                              WebComp_Webcomponent_distribuidoresusuario.componentprocess("W0026", "", sEvt);
                           }
                           WebComp_Webcomponent_distribuidoresusuario_Component = OldWebcomponent_distribuidoresusuario;
                        }
                        else if ( nCmpId == 34 )
                        {
                           OldWebcomponent_factura = cgiGet( "W0034");
                           if ( ( StringUtil.Len( OldWebcomponent_factura) == 0 ) || ( StringUtil.StrCmp(OldWebcomponent_factura, WebComp_Webcomponent_factura_Component) != 0 ) )
                           {
                              WebComp_Webcomponent_factura = getWebComponent(GetType(), "GeneXus.Programs", OldWebcomponent_factura, new Object[] {context} );
                              WebComp_Webcomponent_factura.ComponentInit();
                              WebComp_Webcomponent_factura.Name = "OldWebcomponent_factura";
                              WebComp_Webcomponent_factura_Component = OldWebcomponent_factura;
                           }
                           if ( StringUtil.Len( WebComp_Webcomponent_factura_Component) != 0 )
                           {
                              WebComp_Webcomponent_factura.componentprocess("W0034", "", sEvt);
                           }
                           WebComp_Webcomponent_factura_Component = OldWebcomponent_factura;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE312( )
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

      protected void PA312( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpusuariodetalle.aspx")), "wpusuariodetalle.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpusuariodetalle.aspx")))) ;
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
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "UsuarioID");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV12UsuarioID = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV12UsuarioID", StringUtil.LTrimStr( (decimal)(AV12UsuarioID), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12UsuarioID), "ZZZZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV15TabCode = GetPar( "TabCode");
                        AssignAttri("", false, "AV15TabCode", AV15TabCode);
                     }
                  }
                  if ( toggleJsOutput )
                  {
                     if ( context.isSpaRequest( ) )
                     {
                        enableJsOutput();
                     }
                  }
               }
            }
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF312( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF312( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwcdetalleusuariocol_Component) != 0 )
               {
                  WebComp_Wcwcdetalleusuariocol.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Webcomponent_distribuidoresusuario_Component) != 0 )
               {
                  WebComp_Webcomponent_distribuidoresusuario.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Webcomponent_factura_Component) != 0 )
               {
                  WebComp_Webcomponent_factura.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12312 ();
            WB310( ) ;
         }
      }

      protected void send_integrity_lvl_hashes312( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP310( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11312 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_infogeneral_Width = cgiGet( "DVPANEL_INFOGENERAL_Width");
            Dvpanel_infogeneral_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_INFOGENERAL_Autowidth"));
            Dvpanel_infogeneral_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_INFOGENERAL_Autoheight"));
            Dvpanel_infogeneral_Cls = cgiGet( "DVPANEL_INFOGENERAL_Cls");
            Dvpanel_infogeneral_Title = cgiGet( "DVPANEL_INFOGENERAL_Title");
            Dvpanel_infogeneral_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_INFOGENERAL_Collapsible"));
            Dvpanel_infogeneral_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_INFOGENERAL_Collapsed"));
            Dvpanel_infogeneral_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_INFOGENERAL_Showcollapseicon"));
            Dvpanel_infogeneral_Iconposition = cgiGet( "DVPANEL_INFOGENERAL_Iconposition");
            Dvpanel_infogeneral_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_INFOGENERAL_Autoscroll"));
            Panel_distribuidoresusuario_Width = cgiGet( "PANEL_DISTRIBUIDORESUSUARIO_Width");
            Panel_distribuidoresusuario_Autowidth = StringUtil.StrToBool( cgiGet( "PANEL_DISTRIBUIDORESUSUARIO_Autowidth"));
            Panel_distribuidoresusuario_Autoheight = StringUtil.StrToBool( cgiGet( "PANEL_DISTRIBUIDORESUSUARIO_Autoheight"));
            Panel_distribuidoresusuario_Cls = cgiGet( "PANEL_DISTRIBUIDORESUSUARIO_Cls");
            Panel_distribuidoresusuario_Title = cgiGet( "PANEL_DISTRIBUIDORESUSUARIO_Title");
            Panel_distribuidoresusuario_Collapsible = StringUtil.StrToBool( cgiGet( "PANEL_DISTRIBUIDORESUSUARIO_Collapsible"));
            Panel_distribuidoresusuario_Collapsed = StringUtil.StrToBool( cgiGet( "PANEL_DISTRIBUIDORESUSUARIO_Collapsed"));
            Panel_distribuidoresusuario_Showcollapseicon = StringUtil.StrToBool( cgiGet( "PANEL_DISTRIBUIDORESUSUARIO_Showcollapseicon"));
            Panel_distribuidoresusuario_Iconposition = cgiGet( "PANEL_DISTRIBUIDORESUSUARIO_Iconposition");
            Panel_distribuidoresusuario_Autoscroll = StringUtil.StrToBool( cgiGet( "PANEL_DISTRIBUIDORESUSUARIO_Autoscroll"));
            Panel_factura_Width = cgiGet( "PANEL_FACTURA_Width");
            Panel_factura_Autowidth = StringUtil.StrToBool( cgiGet( "PANEL_FACTURA_Autowidth"));
            Panel_factura_Autoheight = StringUtil.StrToBool( cgiGet( "PANEL_FACTURA_Autoheight"));
            Panel_factura_Cls = cgiGet( "PANEL_FACTURA_Cls");
            Panel_factura_Title = cgiGet( "PANEL_FACTURA_Title");
            Panel_factura_Collapsible = StringUtil.StrToBool( cgiGet( "PANEL_FACTURA_Collapsible"));
            Panel_factura_Collapsed = StringUtil.StrToBool( cgiGet( "PANEL_FACTURA_Collapsed"));
            Panel_factura_Showcollapseicon = StringUtil.StrToBool( cgiGet( "PANEL_FACTURA_Showcollapseicon"));
            Panel_factura_Iconposition = cgiGet( "PANEL_FACTURA_Iconposition");
            Panel_factura_Autoscroll = StringUtil.StrToBool( cgiGet( "PANEL_FACTURA_Autoscroll"));
            /* Read variables values. */
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
         E11312 ();
         if (returnInSub) return;
      }

      protected void E11312( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV14WWPContext) ;
         AV19GXLvl8 = 0;
         /* Using cursor H00312 */
         pr_default.execute(0, new Object[] {AV12UsuarioID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29UsuarioID = H00312_A29UsuarioID[0];
            A51UsuarioApellido = H00312_A51UsuarioApellido[0];
            A30UsuarioNombre = H00312_A30UsuarioNombre[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
            AV19GXLvl8 = 1;
            Form.Caption = StringUtil.Trim( A52UsuarioNombreCompleto);
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV16Exists = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV19GXLvl8 == 0 )
         {
            Form.Caption = context.GetMessage( "WWP_RecordNotFound", "");
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV16Exists = false;
         }
         if ( AV16Exists )
         {
            /* Execute user subroutine: 'LOADTABS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwcdetalleusuariocol = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcdetalleusuariocol_Component), StringUtil.Lower( "WCDetalleUsuarioCol")) != 0 )
         {
            WebComp_Wcwcdetalleusuariocol = getWebComponent(GetType(), "GeneXus.Programs", "wcdetalleusuariocol", new Object[] {context} );
            WebComp_Wcwcdetalleusuariocol.ComponentInit();
            WebComp_Wcwcdetalleusuariocol.Name = "WCDetalleUsuarioCol";
            WebComp_Wcwcdetalleusuariocol_Component = "WCDetalleUsuarioCol";
         }
         if ( StringUtil.Len( WebComp_Wcwcdetalleusuariocol_Component) != 0 )
         {
            WebComp_Wcwcdetalleusuariocol.setjustcreated();
            WebComp_Wcwcdetalleusuariocol.componentprepare(new Object[] {(string)"W0016",(string)"",(int)AV12UsuarioID});
            WebComp_Wcwcdetalleusuariocol.componentbind(new Object[] {(string)""});
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12312( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'LOADTABS' Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Webcomponent_distribuidoresusuario = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Webcomponent_distribuidoresusuario_Component), StringUtil.Lower( "WPUsuarioDetalleDistribuidoresUsuarioWC")) != 0 )
         {
            WebComp_Webcomponent_distribuidoresusuario = getWebComponent(GetType(), "GeneXus.Programs", "wpusuariodetalledistribuidoresusuariowc", new Object[] {context} );
            WebComp_Webcomponent_distribuidoresusuario.ComponentInit();
            WebComp_Webcomponent_distribuidoresusuario.Name = "WPUsuarioDetalleDistribuidoresUsuarioWC";
            WebComp_Webcomponent_distribuidoresusuario_Component = "WPUsuarioDetalleDistribuidoresUsuarioWC";
         }
         if ( StringUtil.Len( WebComp_Webcomponent_distribuidoresusuario_Component) != 0 )
         {
            WebComp_Webcomponent_distribuidoresusuario.setjustcreated();
            WebComp_Webcomponent_distribuidoresusuario.componentprepare(new Object[] {(string)"W0026",(string)"",(int)AV12UsuarioID});
            WebComp_Webcomponent_distribuidoresusuario.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Webcomponent_distribuidoresusuario )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0026"+"");
            WebComp_Webcomponent_distribuidoresusuario.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Webcomponent_factura = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Webcomponent_factura_Component), StringUtil.Lower( "WPUsuarioDetalleFacturaWC")) != 0 )
         {
            WebComp_Webcomponent_factura = getWebComponent(GetType(), "GeneXus.Programs", "wpusuariodetallefacturawc", new Object[] {context} );
            WebComp_Webcomponent_factura.ComponentInit();
            WebComp_Webcomponent_factura.Name = "WPUsuarioDetalleFacturaWC";
            WebComp_Webcomponent_factura_Component = "WPUsuarioDetalleFacturaWC";
         }
         if ( StringUtil.Len( WebComp_Webcomponent_factura_Component) != 0 )
         {
            WebComp_Webcomponent_factura.setjustcreated();
            WebComp_Webcomponent_factura.componentprepare(new Object[] {(string)"W0034",(string)"",(int)AV12UsuarioID});
            WebComp_Webcomponent_factura.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Webcomponent_factura )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0034"+"");
            WebComp_Webcomponent_factura.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12UsuarioID = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV12UsuarioID", StringUtil.LTrimStr( (decimal)(AV12UsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12UsuarioID), "ZZZZZZZZ9"), context));
         AV15TabCode = (string)getParm(obj,1);
         AssignAttri("", false, "AV15TabCode", AV15TabCode);
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
         PA312( ) ;
         WS312( ) ;
         WE312( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcwcdetalleusuariocol == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwcdetalleusuariocol_Component) != 0 )
            {
               WebComp_Wcwcdetalleusuariocol.componentthemes();
            }
         }
         if ( ! ( WebComp_Webcomponent_distribuidoresusuario == null ) )
         {
            if ( StringUtil.Len( WebComp_Webcomponent_distribuidoresusuario_Component) != 0 )
            {
               WebComp_Webcomponent_distribuidoresusuario.componentthemes();
            }
         }
         if ( ! ( WebComp_Webcomponent_factura == null ) )
         {
            if ( StringUtil.Len( WebComp_Webcomponent_factura_Component) != 0 )
            {
               WebComp_Webcomponent_factura.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20265111131275", true, true);
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
         context.AddJavascriptSource("wpusuariodetalle.js", "?20265111131275", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divInfogeneral_Internalname = "INFOGENERAL";
         Dvpanel_infogeneral_Internalname = "DVPANEL_INFOGENERAL";
         divTablemaincomponent_Internalname = "TABLEMAINCOMPONENT";
         divTablepanel_distribuidoresusuario_Internalname = "TABLEPANEL_DISTRIBUIDORESUSUARIO";
         Panel_distribuidoresusuario_Internalname = "PANEL_DISTRIBUIDORESUSUARIO";
         divWpusuariodetalledistribuidoresusuariowc_cell_Internalname = "WPUSUARIODETALLEDISTRIBUIDORESUSUARIOWC_CELL";
         divTablepanel_factura_Internalname = "TABLEPANEL_FACTURA";
         Panel_factura_Internalname = "PANEL_FACTURA";
         divWpusuariodetallefacturawc_cell_Internalname = "WPUSUARIODETALLEFACTURAWC_CELL";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablemain_Internalname = "TABLEMAIN";
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
         Panel_factura_Autoscroll = Convert.ToBoolean( 0);
         Panel_factura_Iconposition = "Right";
         Panel_factura_Showcollapseicon = Convert.ToBoolean( 0);
         Panel_factura_Collapsed = Convert.ToBoolean( 0);
         Panel_factura_Collapsible = Convert.ToBoolean( -1);
         Panel_factura_Title = context.GetMessage( "Facturas registradas", "");
         Panel_factura_Cls = "PanelCard_GrayTitle";
         Panel_factura_Autoheight = Convert.ToBoolean( -1);
         Panel_factura_Autowidth = Convert.ToBoolean( 0);
         Panel_factura_Width = "100%";
         Panel_distribuidoresusuario_Autoscroll = Convert.ToBoolean( 0);
         Panel_distribuidoresusuario_Iconposition = "Right";
         Panel_distribuidoresusuario_Showcollapseicon = Convert.ToBoolean( 0);
         Panel_distribuidoresusuario_Collapsed = Convert.ToBoolean( 0);
         Panel_distribuidoresusuario_Collapsible = Convert.ToBoolean( -1);
         Panel_distribuidoresusuario_Title = context.GetMessage( "Distribuidor(es) asignado(s)", "");
         Panel_distribuidoresusuario_Cls = "PanelCard_GrayTitle";
         Panel_distribuidoresusuario_Autoheight = Convert.ToBoolean( -1);
         Panel_distribuidoresusuario_Autowidth = Convert.ToBoolean( 0);
         Panel_distribuidoresusuario_Width = "100%";
         Dvpanel_infogeneral_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_infogeneral_Iconposition = "Right";
         Dvpanel_infogeneral_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_infogeneral_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_infogeneral_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_infogeneral_Title = context.GetMessage( "Información general", "");
         Dvpanel_infogeneral_Cls = "PanelCard_GrayTitle";
         Dvpanel_infogeneral_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_infogeneral_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_infogeneral_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "WPUsuario Detalle", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV12UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true}]}""");
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
         wcpOAV15TabCode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_infogeneral = new GXUserControl();
         WebComp_Wcwcdetalleusuariocol_Component = "";
         OldWcwcdetalleusuariocol = "";
         ucPanel_distribuidoresusuario = new GXUserControl();
         WebComp_Webcomponent_distribuidoresusuario_Component = "";
         OldWebcomponent_distribuidoresusuario = "";
         ucPanel_factura = new GXUserControl();
         WebComp_Webcomponent_factura_Component = "";
         OldWebcomponent_factura = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV14WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H00312_A29UsuarioID = new int[1] ;
         H00312_A51UsuarioApellido = new string[] {""} ;
         H00312_A30UsuarioNombre = new string[] {""} ;
         A51UsuarioApellido = "";
         A30UsuarioNombre = "";
         A52UsuarioNombreCompleto = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpusuariodetalle__default(),
            new Object[][] {
                new Object[] {
               H00312_A29UsuarioID, H00312_A51UsuarioApellido, H00312_A30UsuarioNombre
               }
            }
         );
         WebComp_Wcwcdetalleusuariocol = new GeneXus.Http.GXNullWebComponent();
         WebComp_Webcomponent_distribuidoresusuario = new GeneXus.Http.GXNullWebComponent();
         WebComp_Webcomponent_factura = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV19GXLvl8 ;
      private short nGXWrapped ;
      private int AV12UsuarioID ;
      private int wcpOAV12UsuarioID ;
      private int A29UsuarioID ;
      private int idxLst ;
      private string AV15TabCode ;
      private string wcpOAV15TabCode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_infogeneral_Width ;
      private string Dvpanel_infogeneral_Cls ;
      private string Dvpanel_infogeneral_Title ;
      private string Dvpanel_infogeneral_Iconposition ;
      private string Panel_distribuidoresusuario_Width ;
      private string Panel_distribuidoresusuario_Cls ;
      private string Panel_distribuidoresusuario_Title ;
      private string Panel_distribuidoresusuario_Iconposition ;
      private string Panel_factura_Width ;
      private string Panel_factura_Cls ;
      private string Panel_factura_Title ;
      private string Panel_factura_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablemaincomponent_Internalname ;
      private string Dvpanel_infogeneral_Internalname ;
      private string divInfogeneral_Internalname ;
      private string WebComp_Wcwcdetalleusuariocol_Component ;
      private string OldWcwcdetalleusuariocol ;
      private string divUnnamedtable1_Internalname ;
      private string divWpusuariodetalledistribuidoresusuariowc_cell_Internalname ;
      private string Panel_distribuidoresusuario_Internalname ;
      private string divTablepanel_distribuidoresusuario_Internalname ;
      private string WebComp_Webcomponent_distribuidoresusuario_Component ;
      private string OldWebcomponent_distribuidoresusuario ;
      private string divWpusuariodetallefacturawc_cell_Internalname ;
      private string Panel_factura_Internalname ;
      private string divTablepanel_factura_Internalname ;
      private string WebComp_Webcomponent_factura_Component ;
      private string OldWebcomponent_factura ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string A51UsuarioApellido ;
      private string A30UsuarioNombre ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_infogeneral_Autowidth ;
      private bool Dvpanel_infogeneral_Autoheight ;
      private bool Dvpanel_infogeneral_Collapsible ;
      private bool Dvpanel_infogeneral_Collapsed ;
      private bool Dvpanel_infogeneral_Showcollapseicon ;
      private bool Dvpanel_infogeneral_Autoscroll ;
      private bool Panel_distribuidoresusuario_Autowidth ;
      private bool Panel_distribuidoresusuario_Autoheight ;
      private bool Panel_distribuidoresusuario_Collapsible ;
      private bool Panel_distribuidoresusuario_Collapsed ;
      private bool Panel_distribuidoresusuario_Showcollapseicon ;
      private bool Panel_distribuidoresusuario_Autoscroll ;
      private bool Panel_factura_Autowidth ;
      private bool Panel_factura_Autoheight ;
      private bool Panel_factura_Collapsible ;
      private bool Panel_factura_Collapsed ;
      private bool Panel_factura_Showcollapseicon ;
      private bool Panel_factura_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV16Exists ;
      private bool bDynCreated_Wcwcdetalleusuariocol ;
      private bool bDynCreated_Webcomponent_distribuidoresusuario ;
      private bool bDynCreated_Webcomponent_factura ;
      private string A52UsuarioNombreCompleto ;
      private GXWebComponent WebComp_Wcwcdetalleusuariocol ;
      private GXWebComponent WebComp_Webcomponent_distribuidoresusuario ;
      private GXWebComponent WebComp_Webcomponent_factura ;
      private GXUserControl ucDvpanel_infogeneral ;
      private GXUserControl ucPanel_distribuidoresusuario ;
      private GXUserControl ucPanel_factura ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV14WWPContext ;
      private IDataStoreProvider pr_default ;
      private int[] H00312_A29UsuarioID ;
      private string[] H00312_A51UsuarioApellido ;
      private string[] H00312_A30UsuarioNombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpusuariodetalle__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00312;
          prmH00312 = new Object[] {
          new ParDef("@AV12UsuarioID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00312", "SELECT `UsuarioID`, `UsuarioApellido`, `UsuarioNombre` FROM `Usuario` WHERE `UsuarioID` = @AV12UsuarioID ORDER BY `UsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00312,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
