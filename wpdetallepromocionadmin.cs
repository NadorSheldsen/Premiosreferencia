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
   public class wpdetallepromocionadmin : GXDataArea
   {
      public wpdetallepromocionadmin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpdetallepromocionadmin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PromocionID ,
                           string aP1_TabCode )
      {
         this.AV9PromocionID = aP0_PromocionID;
         this.AV7TabCode = aP1_TabCode;
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
            gxfirstwebparm = GetFirstPar( "PromocionID");
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
               gxfirstwebparm = GetFirstPar( "PromocionID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "PromocionID");
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
         PA3H2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3H2( ) ;
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
         GXEncryptionTmp = "wpdetallepromocionadmin.aspx"+UrlEncode(StringUtil.LTrimStr(AV9PromocionID,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV7TabCode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpdetallepromocionadmin.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9PromocionID), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vPROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9PromocionID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV7TabCode));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Width", StringUtil.RTrim( Panel_general_Width));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Autowidth", StringUtil.BoolToStr( Panel_general_Autowidth));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Autoheight", StringUtil.BoolToStr( Panel_general_Autoheight));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Cls", StringUtil.RTrim( Panel_general_Cls));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Title", StringUtil.RTrim( Panel_general_Title));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Collapsible", StringUtil.BoolToStr( Panel_general_Collapsible));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Collapsed", StringUtil.BoolToStr( Panel_general_Collapsed));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Showcollapseicon", StringUtil.BoolToStr( Panel_general_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Iconposition", StringUtil.RTrim( Panel_general_Iconposition));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Autoscroll", StringUtil.BoolToStr( Panel_general_Autoscroll));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONDISTRIBUIDOR_Width", StringUtil.RTrim( Panel_promociondistribuidor_Width));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONDISTRIBUIDOR_Autowidth", StringUtil.BoolToStr( Panel_promociondistribuidor_Autowidth));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONDISTRIBUIDOR_Autoheight", StringUtil.BoolToStr( Panel_promociondistribuidor_Autoheight));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONDISTRIBUIDOR_Cls", StringUtil.RTrim( Panel_promociondistribuidor_Cls));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONDISTRIBUIDOR_Title", StringUtil.RTrim( Panel_promociondistribuidor_Title));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONDISTRIBUIDOR_Collapsible", StringUtil.BoolToStr( Panel_promociondistribuidor_Collapsible));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONDISTRIBUIDOR_Collapsed", StringUtil.BoolToStr( Panel_promociondistribuidor_Collapsed));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONDISTRIBUIDOR_Showcollapseicon", StringUtil.BoolToStr( Panel_promociondistribuidor_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONDISTRIBUIDOR_Iconposition", StringUtil.RTrim( Panel_promociondistribuidor_Iconposition));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONDISTRIBUIDOR_Autoscroll", StringUtil.BoolToStr( Panel_promociondistribuidor_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Width", StringUtil.RTrim( Dvpanel_unnamedtable1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Cls", StringUtil.RTrim( Dvpanel_unnamedtable1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Title", StringUtil.RTrim( Dvpanel_unnamedtable1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONMODELO_Width", StringUtil.RTrim( Panel_promocionmodelo_Width));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONMODELO_Autowidth", StringUtil.BoolToStr( Panel_promocionmodelo_Autowidth));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONMODELO_Autoheight", StringUtil.BoolToStr( Panel_promocionmodelo_Autoheight));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONMODELO_Cls", StringUtil.RTrim( Panel_promocionmodelo_Cls));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONMODELO_Title", StringUtil.RTrim( Panel_promocionmodelo_Title));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONMODELO_Collapsible", StringUtil.BoolToStr( Panel_promocionmodelo_Collapsible));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONMODELO_Collapsed", StringUtil.BoolToStr( Panel_promocionmodelo_Collapsed));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONMODELO_Showcollapseicon", StringUtil.BoolToStr( Panel_promocionmodelo_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONMODELO_Iconposition", StringUtil.RTrim( Panel_promocionmodelo_Iconposition));
         GxWebStd.gx_hidden_field( context, "PANEL_PROMOCIONMODELO_Autoscroll", StringUtil.BoolToStr( Panel_promocionmodelo_Autoscroll));
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
         if ( ! ( WebComp_Webcomponent_general == null ) )
         {
            WebComp_Webcomponent_general.componentjscripts();
         }
         if ( ! ( WebComp_Webcomponent_promociondistribuidor == null ) )
         {
            WebComp_Webcomponent_promociondistribuidor.componentjscripts();
         }
         if ( ! ( WebComp_Wcwpdetallepromocionpromocionsegmentowc == null ) )
         {
            WebComp_Wcwpdetallepromocionpromocionsegmentowc.componentjscripts();
         }
         if ( ! ( WebComp_Webcomponent_promocionmodelo == null ) )
         {
            WebComp_Webcomponent_promocionmodelo.componentjscripts();
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
            WE3H2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3H2( ) ;
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
         GXEncryptionTmp = "wpdetallepromocionadmin.aspx"+UrlEncode(StringUtil.LTrimStr(AV9PromocionID,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV7TabCode));
         return formatLink("wpdetallepromocionadmin.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WPDetallePromocionAdmin" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WPDetalle Promocion Admin", "") ;
      }

      protected void WB3H0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ViewCardCellWidth40", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemaincomponent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWWLinkPanel", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableviewrightitems_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWpdetallepromocionadmingeneral_cell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucPanel_general.SetProperty("Width", Panel_general_Width);
            ucPanel_general.SetProperty("AutoWidth", Panel_general_Autowidth);
            ucPanel_general.SetProperty("AutoHeight", Panel_general_Autoheight);
            ucPanel_general.SetProperty("Cls", Panel_general_Cls);
            ucPanel_general.SetProperty("Title", Panel_general_Title);
            ucPanel_general.SetProperty("Collapsible", Panel_general_Collapsible);
            ucPanel_general.SetProperty("Collapsed", Panel_general_Collapsed);
            ucPanel_general.SetProperty("ShowCollapseIcon", Panel_general_Showcollapseicon);
            ucPanel_general.SetProperty("IconPosition", Panel_general_Iconposition);
            ucPanel_general.SetProperty("AutoScroll", Panel_general_Autoscroll);
            ucPanel_general.Render(context, "dvelop.gxbootstrap.panel_al", Panel_general_Internalname, "PANEL_GENERALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"PANEL_GENERALContainer"+"TablePanel_General"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepanel_general_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0019"+"", StringUtil.RTrim( WebComp_Webcomponent_general_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0019"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_general), StringUtil.Lower( WebComp_Webcomponent_general_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0019"+"");
                  }
                  WebComp_Webcomponent_general.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_general), StringUtil.Lower( WebComp_Webcomponent_general_Component)) != 0 )
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
            GxWebStd.gx_div_start( context, divTablerightcomponents_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWpdetallepromocionadminpromociondistribuidorwc_cell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucPanel_promociondistribuidor.SetProperty("Width", Panel_promociondistribuidor_Width);
            ucPanel_promociondistribuidor.SetProperty("AutoWidth", Panel_promociondistribuidor_Autowidth);
            ucPanel_promociondistribuidor.SetProperty("AutoHeight", Panel_promociondistribuidor_Autoheight);
            ucPanel_promociondistribuidor.SetProperty("Cls", Panel_promociondistribuidor_Cls);
            ucPanel_promociondistribuidor.SetProperty("Title", Panel_promociondistribuidor_Title);
            ucPanel_promociondistribuidor.SetProperty("Collapsible", Panel_promociondistribuidor_Collapsible);
            ucPanel_promociondistribuidor.SetProperty("Collapsed", Panel_promociondistribuidor_Collapsed);
            ucPanel_promociondistribuidor.SetProperty("ShowCollapseIcon", Panel_promociondistribuidor_Showcollapseicon);
            ucPanel_promociondistribuidor.SetProperty("IconPosition", Panel_promociondistribuidor_Iconposition);
            ucPanel_promociondistribuidor.SetProperty("AutoScroll", Panel_promociondistribuidor_Autoscroll);
            ucPanel_promociondistribuidor.Render(context, "dvelop.gxbootstrap.panel_al", Panel_promociondistribuidor_Internalname, "PANEL_PROMOCIONDISTRIBUIDORContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"PANEL_PROMOCIONDISTRIBUIDORContainer"+"TablePanel_PromocionDistribuidor"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepanel_promociondistribuidor_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0029"+"", StringUtil.RTrim( WebComp_Webcomponent_promociondistribuidor_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0029"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Webcomponent_promociondistribuidor_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_promociondistribuidor), StringUtil.Lower( WebComp_Webcomponent_promociondistribuidor_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0029"+"");
                  }
                  WebComp_Webcomponent_promociondistribuidor.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_promociondistribuidor), StringUtil.Lower( WebComp_Webcomponent_promociondistribuidor_Component)) != 0 )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable1.SetProperty("Width", Dvpanel_unnamedtable1_Width);
            ucDvpanel_unnamedtable1.SetProperty("AutoWidth", Dvpanel_unnamedtable1_Autowidth);
            ucDvpanel_unnamedtable1.SetProperty("AutoHeight", Dvpanel_unnamedtable1_Autoheight);
            ucDvpanel_unnamedtable1.SetProperty("Cls", Dvpanel_unnamedtable1_Cls);
            ucDvpanel_unnamedtable1.SetProperty("Title", Dvpanel_unnamedtable1_Title);
            ucDvpanel_unnamedtable1.SetProperty("Collapsible", Dvpanel_unnamedtable1_Collapsible);
            ucDvpanel_unnamedtable1.SetProperty("Collapsed", Dvpanel_unnamedtable1_Collapsed);
            ucDvpanel_unnamedtable1.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable1_Showcollapseicon);
            ucDvpanel_unnamedtable1.SetProperty("IconPosition", Dvpanel_unnamedtable1_Iconposition);
            ucDvpanel_unnamedtable1.SetProperty("AutoScroll", Dvpanel_unnamedtable1_Autoscroll);
            ucDvpanel_unnamedtable1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable1_Internalname, "DVPANEL_UNNAMEDTABLE1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE1Container"+"UnnamedTable1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0037"+"", StringUtil.RTrim( WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0037"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwpdetallepromocionpromocionsegmentowc), StringUtil.Lower( WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0037"+"");
                  }
                  WebComp_Wcwpdetallepromocionpromocionsegmentowc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwpdetallepromocionpromocionsegmentowc), StringUtil.Lower( WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component)) != 0 )
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
            GxWebStd.gx_div_start( context, divWpdetallepromocionadminpromocionmodelowc_cell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucPanel_promocionmodelo.SetProperty("Width", Panel_promocionmodelo_Width);
            ucPanel_promocionmodelo.SetProperty("AutoWidth", Panel_promocionmodelo_Autowidth);
            ucPanel_promocionmodelo.SetProperty("AutoHeight", Panel_promocionmodelo_Autoheight);
            ucPanel_promocionmodelo.SetProperty("Cls", Panel_promocionmodelo_Cls);
            ucPanel_promocionmodelo.SetProperty("Title", Panel_promocionmodelo_Title);
            ucPanel_promocionmodelo.SetProperty("Collapsible", Panel_promocionmodelo_Collapsible);
            ucPanel_promocionmodelo.SetProperty("Collapsed", Panel_promocionmodelo_Collapsed);
            ucPanel_promocionmodelo.SetProperty("ShowCollapseIcon", Panel_promocionmodelo_Showcollapseicon);
            ucPanel_promocionmodelo.SetProperty("IconPosition", Panel_promocionmodelo_Iconposition);
            ucPanel_promocionmodelo.SetProperty("AutoScroll", Panel_promocionmodelo_Autoscroll);
            ucPanel_promocionmodelo.Render(context, "dvelop.gxbootstrap.panel_al", Panel_promocionmodelo_Internalname, "PANEL_PROMOCIONMODELOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"PANEL_PROMOCIONMODELOContainer"+"TablePanel_PromocionModelo"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepanel_promocionmodelo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0045"+"", StringUtil.RTrim( WebComp_Webcomponent_promocionmodelo_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0045"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Webcomponent_promocionmodelo_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_promocionmodelo), StringUtil.Lower( WebComp_Webcomponent_promocionmodelo_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0045"+"");
                  }
                  WebComp_Webcomponent_promocionmodelo.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_promocionmodelo), StringUtil.Lower( WebComp_Webcomponent_promocionmodelo_Component)) != 0 )
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
            GxWebStd.gx_div_start( context, divWpdetallepromocionadminfacturawc_cell_Internalname, 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
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
               GxWebStd.gx_hidden_field( context, "W0052"+"", StringUtil.RTrim( WebComp_Webcomponent_factura_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0052"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Webcomponent_factura_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_factura), StringUtil.Lower( WebComp_Webcomponent_factura_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0052"+"");
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
         }
         wbLoad = true;
      }

      protected void START3H2( )
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
         Form.Meta.addItem("description", context.GetMessage( "WPDetalle Promocion Admin", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3H0( ) ;
      }

      protected void WS3H2( )
      {
         START3H2( ) ;
         EVT3H2( ) ;
      }

      protected void EVT3H2( )
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
                              E113H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E123H2 ();
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
                        if ( nCmpId == 19 )
                        {
                           OldWebcomponent_general = cgiGet( "W0019");
                           if ( ( StringUtil.Len( OldWebcomponent_general) == 0 ) || ( StringUtil.StrCmp(OldWebcomponent_general, WebComp_Webcomponent_general_Component) != 0 ) )
                           {
                              WebComp_Webcomponent_general = getWebComponent(GetType(), "GeneXus.Programs", OldWebcomponent_general, new Object[] {context} );
                              WebComp_Webcomponent_general.ComponentInit();
                              WebComp_Webcomponent_general.Name = "OldWebcomponent_general";
                              WebComp_Webcomponent_general_Component = OldWebcomponent_general;
                           }
                           if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
                           {
                              WebComp_Webcomponent_general.componentprocess("W0019", "", sEvt);
                           }
                           WebComp_Webcomponent_general_Component = OldWebcomponent_general;
                        }
                        else if ( nCmpId == 29 )
                        {
                           OldWebcomponent_promociondistribuidor = cgiGet( "W0029");
                           if ( ( StringUtil.Len( OldWebcomponent_promociondistribuidor) == 0 ) || ( StringUtil.StrCmp(OldWebcomponent_promociondistribuidor, WebComp_Webcomponent_promociondistribuidor_Component) != 0 ) )
                           {
                              WebComp_Webcomponent_promociondistribuidor = getWebComponent(GetType(), "GeneXus.Programs", OldWebcomponent_promociondistribuidor, new Object[] {context} );
                              WebComp_Webcomponent_promociondistribuidor.ComponentInit();
                              WebComp_Webcomponent_promociondistribuidor.Name = "OldWebcomponent_promociondistribuidor";
                              WebComp_Webcomponent_promociondistribuidor_Component = OldWebcomponent_promociondistribuidor;
                           }
                           if ( StringUtil.Len( WebComp_Webcomponent_promociondistribuidor_Component) != 0 )
                           {
                              WebComp_Webcomponent_promociondistribuidor.componentprocess("W0029", "", sEvt);
                           }
                           WebComp_Webcomponent_promociondistribuidor_Component = OldWebcomponent_promociondistribuidor;
                        }
                        else if ( nCmpId == 37 )
                        {
                           OldWcwpdetallepromocionpromocionsegmentowc = cgiGet( "W0037");
                           if ( ( StringUtil.Len( OldWcwpdetallepromocionpromocionsegmentowc) == 0 ) || ( StringUtil.StrCmp(OldWcwpdetallepromocionpromocionsegmentowc, WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component) != 0 ) )
                           {
                              WebComp_Wcwpdetallepromocionpromocionsegmentowc = getWebComponent(GetType(), "GeneXus.Programs", OldWcwpdetallepromocionpromocionsegmentowc, new Object[] {context} );
                              WebComp_Wcwpdetallepromocionpromocionsegmentowc.ComponentInit();
                              WebComp_Wcwpdetallepromocionpromocionsegmentowc.Name = "OldWcwpdetallepromocionpromocionsegmentowc";
                              WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component = OldWcwpdetallepromocionpromocionsegmentowc;
                           }
                           if ( StringUtil.Len( WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component) != 0 )
                           {
                              WebComp_Wcwpdetallepromocionpromocionsegmentowc.componentprocess("W0037", "", sEvt);
                           }
                           WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component = OldWcwpdetallepromocionpromocionsegmentowc;
                        }
                        else if ( nCmpId == 45 )
                        {
                           OldWebcomponent_promocionmodelo = cgiGet( "W0045");
                           if ( ( StringUtil.Len( OldWebcomponent_promocionmodelo) == 0 ) || ( StringUtil.StrCmp(OldWebcomponent_promocionmodelo, WebComp_Webcomponent_promocionmodelo_Component) != 0 ) )
                           {
                              WebComp_Webcomponent_promocionmodelo = getWebComponent(GetType(), "GeneXus.Programs", OldWebcomponent_promocionmodelo, new Object[] {context} );
                              WebComp_Webcomponent_promocionmodelo.ComponentInit();
                              WebComp_Webcomponent_promocionmodelo.Name = "OldWebcomponent_promocionmodelo";
                              WebComp_Webcomponent_promocionmodelo_Component = OldWebcomponent_promocionmodelo;
                           }
                           if ( StringUtil.Len( WebComp_Webcomponent_promocionmodelo_Component) != 0 )
                           {
                              WebComp_Webcomponent_promocionmodelo.componentprocess("W0045", "", sEvt);
                           }
                           WebComp_Webcomponent_promocionmodelo_Component = OldWebcomponent_promocionmodelo;
                        }
                        else if ( nCmpId == 52 )
                        {
                           OldWebcomponent_factura = cgiGet( "W0052");
                           if ( ( StringUtil.Len( OldWebcomponent_factura) == 0 ) || ( StringUtil.StrCmp(OldWebcomponent_factura, WebComp_Webcomponent_factura_Component) != 0 ) )
                           {
                              WebComp_Webcomponent_factura = getWebComponent(GetType(), "GeneXus.Programs", OldWebcomponent_factura, new Object[] {context} );
                              WebComp_Webcomponent_factura.ComponentInit();
                              WebComp_Webcomponent_factura.Name = "OldWebcomponent_factura";
                              WebComp_Webcomponent_factura_Component = OldWebcomponent_factura;
                           }
                           if ( StringUtil.Len( WebComp_Webcomponent_factura_Component) != 0 )
                           {
                              WebComp_Webcomponent_factura.componentprocess("W0052", "", sEvt);
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

      protected void WE3H2( )
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

      protected void PA3H2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpdetallepromocionadmin.aspx")), "wpdetallepromocionadmin.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpdetallepromocionadmin.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "PromocionID");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV9PromocionID = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV9PromocionID", StringUtil.LTrimStr( (decimal)(AV9PromocionID), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9PromocionID), "ZZZZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV7TabCode = GetPar( "TabCode");
                        AssignAttri("", false, "AV7TabCode", AV7TabCode);
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
         RF3H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF3H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
               {
                  WebComp_Webcomponent_general.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Webcomponent_promociondistribuidor_Component) != 0 )
               {
                  WebComp_Webcomponent_promociondistribuidor.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component) != 0 )
               {
                  WebComp_Wcwpdetallepromocionpromocionsegmentowc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Webcomponent_promocionmodelo_Component) != 0 )
               {
                  WebComp_Webcomponent_promocionmodelo.componentstart();
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
            E123H2 ();
            WB3H0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3H2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113H2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Panel_general_Width = cgiGet( "PANEL_GENERAL_Width");
            Panel_general_Autowidth = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Autowidth"));
            Panel_general_Autoheight = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Autoheight"));
            Panel_general_Cls = cgiGet( "PANEL_GENERAL_Cls");
            Panel_general_Title = cgiGet( "PANEL_GENERAL_Title");
            Panel_general_Collapsible = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Collapsible"));
            Panel_general_Collapsed = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Collapsed"));
            Panel_general_Showcollapseicon = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Showcollapseicon"));
            Panel_general_Iconposition = cgiGet( "PANEL_GENERAL_Iconposition");
            Panel_general_Autoscroll = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Autoscroll"));
            Panel_promociondistribuidor_Width = cgiGet( "PANEL_PROMOCIONDISTRIBUIDOR_Width");
            Panel_promociondistribuidor_Autowidth = StringUtil.StrToBool( cgiGet( "PANEL_PROMOCIONDISTRIBUIDOR_Autowidth"));
            Panel_promociondistribuidor_Autoheight = StringUtil.StrToBool( cgiGet( "PANEL_PROMOCIONDISTRIBUIDOR_Autoheight"));
            Panel_promociondistribuidor_Cls = cgiGet( "PANEL_PROMOCIONDISTRIBUIDOR_Cls");
            Panel_promociondistribuidor_Title = cgiGet( "PANEL_PROMOCIONDISTRIBUIDOR_Title");
            Panel_promociondistribuidor_Collapsible = StringUtil.StrToBool( cgiGet( "PANEL_PROMOCIONDISTRIBUIDOR_Collapsible"));
            Panel_promociondistribuidor_Collapsed = StringUtil.StrToBool( cgiGet( "PANEL_PROMOCIONDISTRIBUIDOR_Collapsed"));
            Panel_promociondistribuidor_Showcollapseicon = StringUtil.StrToBool( cgiGet( "PANEL_PROMOCIONDISTRIBUIDOR_Showcollapseicon"));
            Panel_promociondistribuidor_Iconposition = cgiGet( "PANEL_PROMOCIONDISTRIBUIDOR_Iconposition");
            Panel_promociondistribuidor_Autoscroll = StringUtil.StrToBool( cgiGet( "PANEL_PROMOCIONDISTRIBUIDOR_Autoscroll"));
            Dvpanel_unnamedtable1_Width = cgiGet( "DVPANEL_UNNAMEDTABLE1_Width");
            Dvpanel_unnamedtable1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autowidth"));
            Dvpanel_unnamedtable1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoheight"));
            Dvpanel_unnamedtable1_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE1_Cls");
            Dvpanel_unnamedtable1_Title = cgiGet( "DVPANEL_UNNAMEDTABLE1_Title");
            Dvpanel_unnamedtable1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsible"));
            Dvpanel_unnamedtable1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsed"));
            Dvpanel_unnamedtable1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Showcollapseicon"));
            Dvpanel_unnamedtable1_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE1_Iconposition");
            Dvpanel_unnamedtable1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoscroll"));
            Panel_promocionmodelo_Width = cgiGet( "PANEL_PROMOCIONMODELO_Width");
            Panel_promocionmodelo_Autowidth = StringUtil.StrToBool( cgiGet( "PANEL_PROMOCIONMODELO_Autowidth"));
            Panel_promocionmodelo_Autoheight = StringUtil.StrToBool( cgiGet( "PANEL_PROMOCIONMODELO_Autoheight"));
            Panel_promocionmodelo_Cls = cgiGet( "PANEL_PROMOCIONMODELO_Cls");
            Panel_promocionmodelo_Title = cgiGet( "PANEL_PROMOCIONMODELO_Title");
            Panel_promocionmodelo_Collapsible = StringUtil.StrToBool( cgiGet( "PANEL_PROMOCIONMODELO_Collapsible"));
            Panel_promocionmodelo_Collapsed = StringUtil.StrToBool( cgiGet( "PANEL_PROMOCIONMODELO_Collapsed"));
            Panel_promocionmodelo_Showcollapseicon = StringUtil.StrToBool( cgiGet( "PANEL_PROMOCIONMODELO_Showcollapseicon"));
            Panel_promocionmodelo_Iconposition = cgiGet( "PANEL_PROMOCIONMODELO_Iconposition");
            Panel_promocionmodelo_Autoscroll = StringUtil.StrToBool( cgiGet( "PANEL_PROMOCIONMODELO_Autoscroll"));
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
         E113H2 ();
         if (returnInSub) return;
      }

      protected void E113H2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         AV13GXLvl8 = 0;
         /* Using cursor H003H2 */
         pr_default.execute(0, new Object[] {AV9PromocionID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A41PromocionID = H003H2_A41PromocionID[0];
            A42PromocionDescripcion = H003H2_A42PromocionDescripcion[0];
            AV13GXLvl8 = 1;
            Form.Caption = A42PromocionDescripcion;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV8Exists = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV13GXLvl8 == 0 )
         {
            Form.Caption = context.GetMessage( "WWP_RecordNotFound", "");
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV8Exists = false;
         }
         if ( AV8Exists )
         {
            /* Execute user subroutine: 'LOADTABS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwpdetallepromocionpromocionsegmentowc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component), StringUtil.Lower( "WPDetallePromocionPromocionSegmentoWC")) != 0 )
         {
            WebComp_Wcwpdetallepromocionpromocionsegmentowc = getWebComponent(GetType(), "GeneXus.Programs", "wpdetallepromocionpromocionsegmentowc", new Object[] {context} );
            WebComp_Wcwpdetallepromocionpromocionsegmentowc.ComponentInit();
            WebComp_Wcwpdetallepromocionpromocionsegmentowc.Name = "WPDetallePromocionPromocionSegmentoWC";
            WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component = "WPDetallePromocionPromocionSegmentoWC";
         }
         if ( StringUtil.Len( WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component) != 0 )
         {
            WebComp_Wcwpdetallepromocionpromocionsegmentowc.setjustcreated();
            WebComp_Wcwpdetallepromocionpromocionsegmentowc.componentprepare(new Object[] {(string)"W0037",(string)"",(int)AV9PromocionID});
            WebComp_Wcwpdetallepromocionpromocionsegmentowc.componentbind(new Object[] {(string)""});
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E123H2( )
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
            bDynCreated_Webcomponent_factura = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Webcomponent_factura_Component), StringUtil.Lower( "WPDetallePromocionAdminFacturaWC")) != 0 )
         {
            WebComp_Webcomponent_factura = getWebComponent(GetType(), "GeneXus.Programs", "wpdetallepromocionadminfacturawc", new Object[] {context} );
            WebComp_Webcomponent_factura.ComponentInit();
            WebComp_Webcomponent_factura.Name = "WPDetallePromocionAdminFacturaWC";
            WebComp_Webcomponent_factura_Component = "WPDetallePromocionAdminFacturaWC";
         }
         if ( StringUtil.Len( WebComp_Webcomponent_factura_Component) != 0 )
         {
            WebComp_Webcomponent_factura.setjustcreated();
            WebComp_Webcomponent_factura.componentprepare(new Object[] {(string)"W0052",(string)"",(int)AV9PromocionID});
            WebComp_Webcomponent_factura.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Webcomponent_factura )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0052"+"");
            WebComp_Webcomponent_factura.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Webcomponent_promociondistribuidor = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Webcomponent_promociondistribuidor_Component), StringUtil.Lower( "WPDetallePromocionAdminPromocionDistribuidorWC")) != 0 )
         {
            WebComp_Webcomponent_promociondistribuidor = getWebComponent(GetType(), "GeneXus.Programs", "wpdetallepromocionadminpromociondistribuidorwc", new Object[] {context} );
            WebComp_Webcomponent_promociondistribuidor.ComponentInit();
            WebComp_Webcomponent_promociondistribuidor.Name = "WPDetallePromocionAdminPromocionDistribuidorWC";
            WebComp_Webcomponent_promociondistribuidor_Component = "WPDetallePromocionAdminPromocionDistribuidorWC";
         }
         if ( StringUtil.Len( WebComp_Webcomponent_promociondistribuidor_Component) != 0 )
         {
            WebComp_Webcomponent_promociondistribuidor.setjustcreated();
            WebComp_Webcomponent_promociondistribuidor.componentprepare(new Object[] {(string)"W0029",(string)"",(int)AV9PromocionID});
            WebComp_Webcomponent_promociondistribuidor.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Webcomponent_promociondistribuidor )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0029"+"");
            WebComp_Webcomponent_promociondistribuidor.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Webcomponent_promocionmodelo = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Webcomponent_promocionmodelo_Component), StringUtil.Lower( "WPDetallePromocionAdminPromocionModeloWC")) != 0 )
         {
            WebComp_Webcomponent_promocionmodelo = getWebComponent(GetType(), "GeneXus.Programs", "wpdetallepromocionadminpromocionmodelowc", new Object[] {context} );
            WebComp_Webcomponent_promocionmodelo.ComponentInit();
            WebComp_Webcomponent_promocionmodelo.Name = "WPDetallePromocionAdminPromocionModeloWC";
            WebComp_Webcomponent_promocionmodelo_Component = "WPDetallePromocionAdminPromocionModeloWC";
         }
         if ( StringUtil.Len( WebComp_Webcomponent_promocionmodelo_Component) != 0 )
         {
            WebComp_Webcomponent_promocionmodelo.setjustcreated();
            WebComp_Webcomponent_promocionmodelo.componentprepare(new Object[] {(string)"W0045",(string)"",(int)AV9PromocionID});
            WebComp_Webcomponent_promocionmodelo.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Webcomponent_promocionmodelo )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0045"+"");
            WebComp_Webcomponent_promocionmodelo.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Webcomponent_general = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Webcomponent_general_Component), StringUtil.Lower( "WPDetallePromocionAdminGeneral")) != 0 )
         {
            WebComp_Webcomponent_general = getWebComponent(GetType(), "GeneXus.Programs", "wpdetallepromocionadmingeneral", new Object[] {context} );
            WebComp_Webcomponent_general.ComponentInit();
            WebComp_Webcomponent_general.Name = "WPDetallePromocionAdminGeneral";
            WebComp_Webcomponent_general_Component = "WPDetallePromocionAdminGeneral";
         }
         if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
         {
            WebComp_Webcomponent_general.setjustcreated();
            WebComp_Webcomponent_general.componentprepare(new Object[] {(string)"W0019",(string)"",(int)AV9PromocionID});
            WebComp_Webcomponent_general.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Webcomponent_general )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0019"+"");
            WebComp_Webcomponent_general.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV9PromocionID = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV9PromocionID", StringUtil.LTrimStr( (decimal)(AV9PromocionID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9PromocionID), "ZZZZZZZZ9"), context));
         AV7TabCode = (string)getParm(obj,1);
         AssignAttri("", false, "AV7TabCode", AV7TabCode);
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
         PA3H2( ) ;
         WS3H2( ) ;
         WE3H2( ) ;
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
         if ( ! ( WebComp_Webcomponent_general == null ) )
         {
            if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
            {
               WebComp_Webcomponent_general.componentthemes();
            }
         }
         if ( ! ( WebComp_Webcomponent_promociondistribuidor == null ) )
         {
            if ( StringUtil.Len( WebComp_Webcomponent_promociondistribuidor_Component) != 0 )
            {
               WebComp_Webcomponent_promociondistribuidor.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcwpdetallepromocionpromocionsegmentowc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component) != 0 )
            {
               WebComp_Wcwpdetallepromocionpromocionsegmentowc.componentthemes();
            }
         }
         if ( ! ( WebComp_Webcomponent_promocionmodelo == null ) )
         {
            if ( StringUtil.Len( WebComp_Webcomponent_promocionmodelo_Component) != 0 )
            {
               WebComp_Webcomponent_promocionmodelo.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025102815462796", true, true);
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
         context.AddJavascriptSource("wpdetallepromocionadmin.js", "?2025102815462796", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         divTableviewrightitems_Internalname = "TABLEVIEWRIGHTITEMS";
         divTablepanel_general_Internalname = "TABLEPANEL_GENERAL";
         Panel_general_Internalname = "PANEL_GENERAL";
         divWpdetallepromocionadmingeneral_cell_Internalname = "WPDETALLEPROMOCIONADMINGENERAL_CELL";
         divTablemaincomponent_Internalname = "TABLEMAINCOMPONENT";
         divTablepanel_promociondistribuidor_Internalname = "TABLEPANEL_PROMOCIONDISTRIBUIDOR";
         Panel_promociondistribuidor_Internalname = "PANEL_PROMOCIONDISTRIBUIDOR";
         divWpdetallepromocionadminpromociondistribuidorwc_cell_Internalname = "WPDETALLEPROMOCIONADMINPROMOCIONDISTRIBUIDORWC_CELL";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Dvpanel_unnamedtable1_Internalname = "DVPANEL_UNNAMEDTABLE1";
         divTablepanel_promocionmodelo_Internalname = "TABLEPANEL_PROMOCIONMODELO";
         Panel_promocionmodelo_Internalname = "PANEL_PROMOCIONMODELO";
         divWpdetallepromocionadminpromocionmodelowc_cell_Internalname = "WPDETALLEPROMOCIONADMINPROMOCIONMODELOWC_CELL";
         divTablerightcomponents_Internalname = "TABLERIGHTCOMPONENTS";
         divTablepanel_factura_Internalname = "TABLEPANEL_FACTURA";
         Panel_factura_Internalname = "PANEL_FACTURA";
         divWpdetallepromocionadminfacturawc_cell_Internalname = "WPDETALLEPROMOCIONADMINFACTURAWC_CELL";
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
         Panel_factura_Title = context.GetMessage( "Factura", "");
         Panel_factura_Cls = "PanelCard_GrayTitle";
         Panel_factura_Autoheight = Convert.ToBoolean( -1);
         Panel_factura_Autowidth = Convert.ToBoolean( 0);
         Panel_factura_Width = "100%";
         Panel_promocionmodelo_Autoscroll = Convert.ToBoolean( 0);
         Panel_promocionmodelo_Iconposition = "Right";
         Panel_promocionmodelo_Showcollapseicon = Convert.ToBoolean( 0);
         Panel_promocionmodelo_Collapsed = Convert.ToBoolean( 0);
         Panel_promocionmodelo_Collapsible = Convert.ToBoolean( -1);
         Panel_promocionmodelo_Title = context.GetMessage( "Modelos", "");
         Panel_promocionmodelo_Cls = "PanelCard_GrayTitle";
         Panel_promocionmodelo_Autoheight = Convert.ToBoolean( -1);
         Panel_promocionmodelo_Autowidth = Convert.ToBoolean( 0);
         Panel_promocionmodelo_Width = "100%";
         Dvpanel_unnamedtable1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Iconposition = "Right";
         Dvpanel_unnamedtable1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Title = context.GetMessage( "Segmentos asignados", "");
         Dvpanel_unnamedtable1_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Width = "100%";
         Panel_promociondistribuidor_Autoscroll = Convert.ToBoolean( 0);
         Panel_promociondistribuidor_Iconposition = "Right";
         Panel_promociondistribuidor_Showcollapseicon = Convert.ToBoolean( 0);
         Panel_promociondistribuidor_Collapsed = Convert.ToBoolean( 0);
         Panel_promociondistribuidor_Collapsible = Convert.ToBoolean( -1);
         Panel_promociondistribuidor_Title = context.GetMessage( "Distribuidores", "");
         Panel_promociondistribuidor_Cls = "PanelCard_GrayTitle";
         Panel_promociondistribuidor_Autoheight = Convert.ToBoolean( -1);
         Panel_promociondistribuidor_Autowidth = Convert.ToBoolean( 0);
         Panel_promociondistribuidor_Width = "100%";
         Panel_general_Autoscroll = Convert.ToBoolean( 0);
         Panel_general_Iconposition = "Right";
         Panel_general_Showcollapseicon = Convert.ToBoolean( 0);
         Panel_general_Collapsed = Convert.ToBoolean( 0);
         Panel_general_Collapsible = Convert.ToBoolean( -1);
         Panel_general_Title = context.GetMessage( "WWP_TemplateDataPanelTitle", "");
         Panel_general_Cls = "PanelCard_GrayTitle";
         Panel_general_Autoheight = Convert.ToBoolean( -1);
         Panel_general_Autowidth = Convert.ToBoolean( 0);
         Panel_general_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "WPDetalle Promocion Admin", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV9PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9","hsh":true}]}""");
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
         wcpOAV7TabCode = "";
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
         ucPanel_general = new GXUserControl();
         WebComp_Webcomponent_general_Component = "";
         OldWebcomponent_general = "";
         ucPanel_promociondistribuidor = new GXUserControl();
         WebComp_Webcomponent_promociondistribuidor_Component = "";
         OldWebcomponent_promociondistribuidor = "";
         ucDvpanel_unnamedtable1 = new GXUserControl();
         WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component = "";
         OldWcwpdetallepromocionpromocionsegmentowc = "";
         ucPanel_promocionmodelo = new GXUserControl();
         WebComp_Webcomponent_promocionmodelo_Component = "";
         OldWebcomponent_promocionmodelo = "";
         ucPanel_factura = new GXUserControl();
         WebComp_Webcomponent_factura_Component = "";
         OldWebcomponent_factura = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H003H2_A41PromocionID = new int[1] ;
         H003H2_A42PromocionDescripcion = new string[] {""} ;
         A42PromocionDescripcion = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpdetallepromocionadmin__default(),
            new Object[][] {
                new Object[] {
               H003H2_A41PromocionID, H003H2_A42PromocionDescripcion
               }
            }
         );
         WebComp_Webcomponent_general = new GeneXus.Http.GXNullWebComponent();
         WebComp_Webcomponent_promociondistribuidor = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcwpdetallepromocionpromocionsegmentowc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Webcomponent_promocionmodelo = new GeneXus.Http.GXNullWebComponent();
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
      private short AV13GXLvl8 ;
      private short nGXWrapped ;
      private int AV9PromocionID ;
      private int wcpOAV9PromocionID ;
      private int A41PromocionID ;
      private int idxLst ;
      private string AV7TabCode ;
      private string wcpOAV7TabCode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Panel_general_Width ;
      private string Panel_general_Cls ;
      private string Panel_general_Title ;
      private string Panel_general_Iconposition ;
      private string Panel_promociondistribuidor_Width ;
      private string Panel_promociondistribuidor_Cls ;
      private string Panel_promociondistribuidor_Title ;
      private string Panel_promociondistribuidor_Iconposition ;
      private string Dvpanel_unnamedtable1_Width ;
      private string Dvpanel_unnamedtable1_Cls ;
      private string Dvpanel_unnamedtable1_Title ;
      private string Dvpanel_unnamedtable1_Iconposition ;
      private string Panel_promocionmodelo_Width ;
      private string Panel_promocionmodelo_Cls ;
      private string Panel_promocionmodelo_Title ;
      private string Panel_promocionmodelo_Iconposition ;
      private string Panel_factura_Width ;
      private string Panel_factura_Cls ;
      private string Panel_factura_Title ;
      private string Panel_factura_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablemaincomponent_Internalname ;
      private string divTableviewrightitems_Internalname ;
      private string divWpdetallepromocionadmingeneral_cell_Internalname ;
      private string Panel_general_Internalname ;
      private string divTablepanel_general_Internalname ;
      private string WebComp_Webcomponent_general_Component ;
      private string OldWebcomponent_general ;
      private string divTablerightcomponents_Internalname ;
      private string divWpdetallepromocionadminpromociondistribuidorwc_cell_Internalname ;
      private string Panel_promociondistribuidor_Internalname ;
      private string divTablepanel_promociondistribuidor_Internalname ;
      private string WebComp_Webcomponent_promociondistribuidor_Component ;
      private string OldWebcomponent_promociondistribuidor ;
      private string Dvpanel_unnamedtable1_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component ;
      private string OldWcwpdetallepromocionpromocionsegmentowc ;
      private string divWpdetallepromocionadminpromocionmodelowc_cell_Internalname ;
      private string Panel_promocionmodelo_Internalname ;
      private string divTablepanel_promocionmodelo_Internalname ;
      private string WebComp_Webcomponent_promocionmodelo_Component ;
      private string OldWebcomponent_promocionmodelo ;
      private string divWpdetallepromocionadminfacturawc_cell_Internalname ;
      private string Panel_factura_Internalname ;
      private string divTablepanel_factura_Internalname ;
      private string WebComp_Webcomponent_factura_Component ;
      private string OldWebcomponent_factura ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Panel_general_Autowidth ;
      private bool Panel_general_Autoheight ;
      private bool Panel_general_Collapsible ;
      private bool Panel_general_Collapsed ;
      private bool Panel_general_Showcollapseicon ;
      private bool Panel_general_Autoscroll ;
      private bool Panel_promociondistribuidor_Autowidth ;
      private bool Panel_promociondistribuidor_Autoheight ;
      private bool Panel_promociondistribuidor_Collapsible ;
      private bool Panel_promociondistribuidor_Collapsed ;
      private bool Panel_promociondistribuidor_Showcollapseicon ;
      private bool Panel_promociondistribuidor_Autoscroll ;
      private bool Dvpanel_unnamedtable1_Autowidth ;
      private bool Dvpanel_unnamedtable1_Autoheight ;
      private bool Dvpanel_unnamedtable1_Collapsible ;
      private bool Dvpanel_unnamedtable1_Collapsed ;
      private bool Dvpanel_unnamedtable1_Showcollapseicon ;
      private bool Dvpanel_unnamedtable1_Autoscroll ;
      private bool Panel_promocionmodelo_Autowidth ;
      private bool Panel_promocionmodelo_Autoheight ;
      private bool Panel_promocionmodelo_Collapsible ;
      private bool Panel_promocionmodelo_Collapsed ;
      private bool Panel_promocionmodelo_Showcollapseicon ;
      private bool Panel_promocionmodelo_Autoscroll ;
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
      private bool AV8Exists ;
      private bool bDynCreated_Wcwpdetallepromocionpromocionsegmentowc ;
      private bool bDynCreated_Webcomponent_factura ;
      private bool bDynCreated_Webcomponent_promociondistribuidor ;
      private bool bDynCreated_Webcomponent_promocionmodelo ;
      private bool bDynCreated_Webcomponent_general ;
      private string A42PromocionDescripcion ;
      private GXWebComponent WebComp_Webcomponent_general ;
      private GXWebComponent WebComp_Webcomponent_promociondistribuidor ;
      private GXWebComponent WebComp_Wcwpdetallepromocionpromocionsegmentowc ;
      private GXWebComponent WebComp_Webcomponent_promocionmodelo ;
      private GXWebComponent WebComp_Webcomponent_factura ;
      private GXUserControl ucPanel_general ;
      private GXUserControl ucPanel_promociondistribuidor ;
      private GXUserControl ucDvpanel_unnamedtable1 ;
      private GXUserControl ucPanel_promocionmodelo ;
      private GXUserControl ucPanel_factura ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private IDataStoreProvider pr_default ;
      private int[] H003H2_A41PromocionID ;
      private string[] H003H2_A42PromocionDescripcion ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpdetallepromocionadmin__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003H2;
          prmH003H2 = new Object[] {
          new ParDef("@AV9PromocionID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003H2", "SELECT `PromocionID`, `PromocionDescripcion` FROM `Promocion` WHERE `PromocionID` = @AV9PromocionID ORDER BY `PromocionID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003H2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
