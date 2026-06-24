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
   public class wpduplicarpromo : GXDataArea
   {
      public wpduplicarpromo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpduplicarpromo( IGxContext context )
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
         PA412( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START412( ) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         GXEncryptionTmp = "wpduplicarpromo.aspx"+UrlEncode(StringUtil.LTrimStr(AV9PromocionID,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV7TabCode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpduplicarpromo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Width", StringUtil.RTrim( Dvpanel_unnamedtable2_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Cls", StringUtil.RTrim( Dvpanel_unnamedtable2_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Title", StringUtil.RTrim( Dvpanel_unnamedtable2_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable2_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE2_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Autoscroll));
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
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_tabs1_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs1_Historymanagement));
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
         if ( ! ( WebComp_Wcwcduplicarpromo == null ) )
         {
            WebComp_Wcwcduplicarpromo.componentjscripts();
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
            WE412( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT412( ) ;
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
         GXEncryptionTmp = "wpduplicarpromo.aspx"+UrlEncode(StringUtil.LTrimStr(AV9PromocionID,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV7TabCode));
         return formatLink("wpduplicarpromo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WPDuplicarPromo" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Duplicar promoción", "") ;
      }

      protected void WB410( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs1.SetProperty("PageCount", Gxuitabspanel_tabs1_Pagecount);
            ucGxuitabspanel_tabs1.SetProperty("Class", Gxuitabspanel_tabs1_Class);
            ucGxuitabspanel_tabs1.SetProperty("HistoryManagement", Gxuitabspanel_tabs1_Historymanagement);
            ucGxuitabspanel_tabs1.Render(context, "tab", Gxuitabspanel_tabs1_Internalname, "GXUITABSPANEL_TABS1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab1_title_Internalname, context.GetMessage( "Promoción", ""), "", "", lblTab1_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDuplicarPromo.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab1") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ViewCardCellWidth40", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemaincomponent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0019"+"", StringUtil.RTrim( WebComp_Wcwcduplicarpromo_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0019"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwcduplicarpromo_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcduplicarpromo), StringUtil.Lower( WebComp_Wcwcduplicarpromo_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0019"+"");
                  }
                  WebComp_Wcwcduplicarpromo.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcduplicarpromo), StringUtil.Lower( WebComp_Wcwcduplicarpromo_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab2_title_Internalname, context.GetMessage( "Detalle", ""), "", "", lblTab2_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDuplicarPromo.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab2") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, context.GetMessage( "La información mostrada es la misma que la de la promoción que se va a copiar. Para modificarla, primero debe duplicarla", ""), "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SimpleCardAttributeTitle", 0, "", 1, 1, 0, 0, "HLP_WPDuplicarPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, " ", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDuplicarPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightcomponents_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divWpduplicarpromopromociondistribuidorwc_cell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
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
               GxWebStd.gx_hidden_field( context, "W0041"+"", StringUtil.RTrim( WebComp_Webcomponent_promociondistribuidor_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0041"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Webcomponent_promociondistribuidor_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_promociondistribuidor), StringUtil.Lower( WebComp_Webcomponent_promociondistribuidor_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0041"+"");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable2.SetProperty("Width", Dvpanel_unnamedtable2_Width);
            ucDvpanel_unnamedtable2.SetProperty("AutoWidth", Dvpanel_unnamedtable2_Autowidth);
            ucDvpanel_unnamedtable2.SetProperty("AutoHeight", Dvpanel_unnamedtable2_Autoheight);
            ucDvpanel_unnamedtable2.SetProperty("Cls", Dvpanel_unnamedtable2_Cls);
            ucDvpanel_unnamedtable2.SetProperty("Title", Dvpanel_unnamedtable2_Title);
            ucDvpanel_unnamedtable2.SetProperty("Collapsible", Dvpanel_unnamedtable2_Collapsible);
            ucDvpanel_unnamedtable2.SetProperty("Collapsed", Dvpanel_unnamedtable2_Collapsed);
            ucDvpanel_unnamedtable2.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable2_Showcollapseicon);
            ucDvpanel_unnamedtable2.SetProperty("IconPosition", Dvpanel_unnamedtable2_Iconposition);
            ucDvpanel_unnamedtable2.SetProperty("AutoScroll", Dvpanel_unnamedtable2_Autoscroll);
            ucDvpanel_unnamedtable2.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable2_Internalname, "DVPANEL_UNNAMEDTABLE2Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE2Container"+"UnnamedTable2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0048"+"", StringUtil.RTrim( WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0048"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwpdetallepromocionpromocionsegmentowc), StringUtil.Lower( WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0048"+"");
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
            GxWebStd.gx_div_start( context, divWpduplicarpromopromocionmodelowc_cell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
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
               GxWebStd.gx_hidden_field( context, "W0056"+"", StringUtil.RTrim( WebComp_Webcomponent_promocionmodelo_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0056"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Webcomponent_promocionmodelo_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_promocionmodelo), StringUtil.Lower( WebComp_Webcomponent_promocionmodelo_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0056"+"");
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

      protected void START412( )
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
         Form.Meta.addItem("description", context.GetMessage( "Duplicar promoción", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP410( ) ;
      }

      protected void WS412( )
      {
         START412( ) ;
         EVT412( ) ;
      }

      protected void EVT412( )
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
                              E11412 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E12412 ();
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
                           OldWcwcduplicarpromo = cgiGet( "W0019");
                           if ( ( StringUtil.Len( OldWcwcduplicarpromo) == 0 ) || ( StringUtil.StrCmp(OldWcwcduplicarpromo, WebComp_Wcwcduplicarpromo_Component) != 0 ) )
                           {
                              WebComp_Wcwcduplicarpromo = getWebComponent(GetType(), "GeneXus.Programs", OldWcwcduplicarpromo, new Object[] {context} );
                              WebComp_Wcwcduplicarpromo.ComponentInit();
                              WebComp_Wcwcduplicarpromo.Name = "OldWcwcduplicarpromo";
                              WebComp_Wcwcduplicarpromo_Component = OldWcwcduplicarpromo;
                           }
                           if ( StringUtil.Len( WebComp_Wcwcduplicarpromo_Component) != 0 )
                           {
                              WebComp_Wcwcduplicarpromo.componentprocess("W0019", "", sEvt);
                           }
                           WebComp_Wcwcduplicarpromo_Component = OldWcwcduplicarpromo;
                        }
                        else if ( nCmpId == 41 )
                        {
                           OldWebcomponent_promociondistribuidor = cgiGet( "W0041");
                           if ( ( StringUtil.Len( OldWebcomponent_promociondistribuidor) == 0 ) || ( StringUtil.StrCmp(OldWebcomponent_promociondistribuidor, WebComp_Webcomponent_promociondistribuidor_Component) != 0 ) )
                           {
                              WebComp_Webcomponent_promociondistribuidor = getWebComponent(GetType(), "GeneXus.Programs", OldWebcomponent_promociondistribuidor, new Object[] {context} );
                              WebComp_Webcomponent_promociondistribuidor.ComponentInit();
                              WebComp_Webcomponent_promociondistribuidor.Name = "OldWebcomponent_promociondistribuidor";
                              WebComp_Webcomponent_promociondistribuidor_Component = OldWebcomponent_promociondistribuidor;
                           }
                           if ( StringUtil.Len( WebComp_Webcomponent_promociondistribuidor_Component) != 0 )
                           {
                              WebComp_Webcomponent_promociondistribuidor.componentprocess("W0041", "", sEvt);
                           }
                           WebComp_Webcomponent_promociondistribuidor_Component = OldWebcomponent_promociondistribuidor;
                        }
                        else if ( nCmpId == 48 )
                        {
                           OldWcwpdetallepromocionpromocionsegmentowc = cgiGet( "W0048");
                           if ( ( StringUtil.Len( OldWcwpdetallepromocionpromocionsegmentowc) == 0 ) || ( StringUtil.StrCmp(OldWcwpdetallepromocionpromocionsegmentowc, WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component) != 0 ) )
                           {
                              WebComp_Wcwpdetallepromocionpromocionsegmentowc = getWebComponent(GetType(), "GeneXus.Programs", OldWcwpdetallepromocionpromocionsegmentowc, new Object[] {context} );
                              WebComp_Wcwpdetallepromocionpromocionsegmentowc.ComponentInit();
                              WebComp_Wcwpdetallepromocionpromocionsegmentowc.Name = "OldWcwpdetallepromocionpromocionsegmentowc";
                              WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component = OldWcwpdetallepromocionpromocionsegmentowc;
                           }
                           if ( StringUtil.Len( WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component) != 0 )
                           {
                              WebComp_Wcwpdetallepromocionpromocionsegmentowc.componentprocess("W0048", "", sEvt);
                           }
                           WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component = OldWcwpdetallepromocionpromocionsegmentowc;
                        }
                        else if ( nCmpId == 56 )
                        {
                           OldWebcomponent_promocionmodelo = cgiGet( "W0056");
                           if ( ( StringUtil.Len( OldWebcomponent_promocionmodelo) == 0 ) || ( StringUtil.StrCmp(OldWebcomponent_promocionmodelo, WebComp_Webcomponent_promocionmodelo_Component) != 0 ) )
                           {
                              WebComp_Webcomponent_promocionmodelo = getWebComponent(GetType(), "GeneXus.Programs", OldWebcomponent_promocionmodelo, new Object[] {context} );
                              WebComp_Webcomponent_promocionmodelo.ComponentInit();
                              WebComp_Webcomponent_promocionmodelo.Name = "OldWebcomponent_promocionmodelo";
                              WebComp_Webcomponent_promocionmodelo_Component = OldWebcomponent_promocionmodelo;
                           }
                           if ( StringUtil.Len( WebComp_Webcomponent_promocionmodelo_Component) != 0 )
                           {
                              WebComp_Webcomponent_promocionmodelo.componentprocess("W0056", "", sEvt);
                           }
                           WebComp_Webcomponent_promocionmodelo_Component = OldWebcomponent_promocionmodelo;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE412( )
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

      protected void PA412( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpduplicarpromo.aspx")), "wpduplicarpromo.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpduplicarpromo.aspx")))) ;
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
         RF412( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF412( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwcduplicarpromo_Component) != 0 )
               {
                  WebComp_Wcwcduplicarpromo.componentstart();
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
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12412 ();
            WB410( ) ;
         }
      }

      protected void send_integrity_lvl_hashes412( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP410( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11412 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
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
            Dvpanel_unnamedtable2_Width = cgiGet( "DVPANEL_UNNAMEDTABLE2_Width");
            Dvpanel_unnamedtable2_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE2_Autowidth"));
            Dvpanel_unnamedtable2_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE2_Autoheight"));
            Dvpanel_unnamedtable2_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE2_Cls");
            Dvpanel_unnamedtable2_Title = cgiGet( "DVPANEL_UNNAMEDTABLE2_Title");
            Dvpanel_unnamedtable2_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE2_Collapsible"));
            Dvpanel_unnamedtable2_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE2_Collapsed"));
            Dvpanel_unnamedtable2_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE2_Showcollapseicon"));
            Dvpanel_unnamedtable2_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE2_Iconposition");
            Dvpanel_unnamedtable2_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE2_Autoscroll"));
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
            Gxuitabspanel_tabs1_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS1_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs1_Class = cgiGet( "GXUITABSPANEL_TABS1_Class");
            Gxuitabspanel_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS1_Historymanagement"));
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
         E11412 ();
         if (returnInSub) return;
      }

      protected void E11412( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         AV12GXLvl8 = 0;
         /* Using cursor H00412 */
         pr_default.execute(0, new Object[] {AV9PromocionID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A41PromocionID = H00412_A41PromocionID[0];
            A42PromocionDescripcion = H00412_A42PromocionDescripcion[0];
            AV12GXLvl8 = 1;
            Form.Caption = A42PromocionDescripcion;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV8Exists = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV12GXLvl8 == 0 )
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
            WebComp_Wcwpdetallepromocionpromocionsegmentowc.componentprepare(new Object[] {(string)"W0048",(string)"",(int)AV9PromocionID});
            WebComp_Wcwpdetallepromocionpromocionsegmentowc.componentbind(new Object[] {(string)""});
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwcduplicarpromo = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcduplicarpromo_Component), StringUtil.Lower( "WCDuplicarPromo")) != 0 )
         {
            WebComp_Wcwcduplicarpromo = getWebComponent(GetType(), "GeneXus.Programs", "wcduplicarpromo", new Object[] {context} );
            WebComp_Wcwcduplicarpromo.ComponentInit();
            WebComp_Wcwcduplicarpromo.Name = "WCDuplicarPromo";
            WebComp_Wcwcduplicarpromo_Component = "WCDuplicarPromo";
         }
         if ( StringUtil.Len( WebComp_Wcwcduplicarpromo_Component) != 0 )
         {
            WebComp_Wcwcduplicarpromo.setjustcreated();
            WebComp_Wcwcduplicarpromo.componentprepare(new Object[] {(string)"W0019",(string)"",(int)AV9PromocionID});
            WebComp_Wcwcduplicarpromo.componentbind(new Object[] {(string)""});
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12412( )
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
            bDynCreated_Webcomponent_promociondistribuidor = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Webcomponent_promociondistribuidor_Component), StringUtil.Lower( "WPDuplicarPromoPromocionDistribuidorWC")) != 0 )
         {
            WebComp_Webcomponent_promociondistribuidor = getWebComponent(GetType(), "GeneXus.Programs", "wpduplicarpromopromociondistribuidorwc", new Object[] {context} );
            WebComp_Webcomponent_promociondistribuidor.ComponentInit();
            WebComp_Webcomponent_promociondistribuidor.Name = "WPDuplicarPromoPromocionDistribuidorWC";
            WebComp_Webcomponent_promociondistribuidor_Component = "WPDuplicarPromoPromocionDistribuidorWC";
         }
         if ( StringUtil.Len( WebComp_Webcomponent_promociondistribuidor_Component) != 0 )
         {
            WebComp_Webcomponent_promociondistribuidor.setjustcreated();
            WebComp_Webcomponent_promociondistribuidor.componentprepare(new Object[] {(string)"W0041",(string)"",(int)AV9PromocionID});
            WebComp_Webcomponent_promociondistribuidor.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Webcomponent_promociondistribuidor )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0041"+"");
            WebComp_Webcomponent_promociondistribuidor.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Webcomponent_promocionmodelo = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Webcomponent_promocionmodelo_Component), StringUtil.Lower( "WPDuplicarPromoPromocionModeloWC")) != 0 )
         {
            WebComp_Webcomponent_promocionmodelo = getWebComponent(GetType(), "GeneXus.Programs", "wpduplicarpromopromocionmodelowc", new Object[] {context} );
            WebComp_Webcomponent_promocionmodelo.ComponentInit();
            WebComp_Webcomponent_promocionmodelo.Name = "WPDuplicarPromoPromocionModeloWC";
            WebComp_Webcomponent_promocionmodelo_Component = "WPDuplicarPromoPromocionModeloWC";
         }
         if ( StringUtil.Len( WebComp_Webcomponent_promocionmodelo_Component) != 0 )
         {
            WebComp_Webcomponent_promocionmodelo.setjustcreated();
            WebComp_Webcomponent_promocionmodelo.componentprepare(new Object[] {(string)"W0056",(string)"",(int)AV9PromocionID});
            WebComp_Webcomponent_promocionmodelo.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Webcomponent_promocionmodelo )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0056"+"");
            WebComp_Webcomponent_promocionmodelo.componentdraw();
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
         PA412( ) ;
         WS412( ) ;
         WE412( ) ;
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
         if ( ! ( WebComp_Wcwcduplicarpromo == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwcduplicarpromo_Component) != 0 )
            {
               WebComp_Wcwcduplicarpromo.componentthemes();
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025102815463022", true, true);
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
         context.AddJavascriptSource("wpduplicarpromo.js", "?2025102815463022", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         lblTab1_title_Internalname = "TAB1_TITLE";
         divTablemaincomponent_Internalname = "TABLEMAINCOMPONENT";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         lblTab2_title_Internalname = "TAB2_TITLE";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         divTablepanel_promociondistribuidor_Internalname = "TABLEPANEL_PROMOCIONDISTRIBUIDOR";
         Panel_promociondistribuidor_Internalname = "PANEL_PROMOCIONDISTRIBUIDOR";
         divWpduplicarpromopromociondistribuidorwc_cell_Internalname = "WPDUPLICARPROMOPROMOCIONDISTRIBUIDORWC_CELL";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         Dvpanel_unnamedtable2_Internalname = "DVPANEL_UNNAMEDTABLE2";
         divTablepanel_promocionmodelo_Internalname = "TABLEPANEL_PROMOCIONMODELO";
         Panel_promocionmodelo_Internalname = "PANEL_PROMOCIONMODELO";
         divWpduplicarpromopromocionmodelowc_cell_Internalname = "WPDUPLICARPROMOPROMOCIONMODELOWC_CELL";
         divTablerightcomponents_Internalname = "TABLERIGHTCOMPONENTS";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs1_Internalname = "GXUITABSPANEL_TABS1";
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
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "Tab";
         Gxuitabspanel_tabs1_Pagecount = 2;
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
         Dvpanel_unnamedtable2_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Iconposition = "Right";
         Dvpanel_unnamedtable2_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Title = context.GetMessage( "Segmentos asignados", "");
         Dvpanel_unnamedtable2_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable2_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable2_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Width = "100%";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Duplicar promoción", "");
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
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblTab1_title_Jsonclick = "";
         WebComp_Wcwcduplicarpromo_Component = "";
         OldWcwcduplicarpromo = "";
         lblTab2_title_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         ucPanel_promociondistribuidor = new GXUserControl();
         WebComp_Webcomponent_promociondistribuidor_Component = "";
         OldWebcomponent_promociondistribuidor = "";
         ucDvpanel_unnamedtable2 = new GXUserControl();
         WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component = "";
         OldWcwpdetallepromocionpromocionsegmentowc = "";
         ucPanel_promocionmodelo = new GXUserControl();
         WebComp_Webcomponent_promocionmodelo_Component = "";
         OldWebcomponent_promocionmodelo = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H00412_A41PromocionID = new int[1] ;
         H00412_A42PromocionDescripcion = new string[] {""} ;
         A42PromocionDescripcion = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpduplicarpromo__default(),
            new Object[][] {
                new Object[] {
               H00412_A41PromocionID, H00412_A42PromocionDescripcion
               }
            }
         );
         WebComp_Wcwcduplicarpromo = new GeneXus.Http.GXNullWebComponent();
         WebComp_Webcomponent_promociondistribuidor = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcwpdetallepromocionpromocionsegmentowc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Webcomponent_promocionmodelo = new GeneXus.Http.GXNullWebComponent();
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
      private short AV12GXLvl8 ;
      private short nGXWrapped ;
      private int AV9PromocionID ;
      private int wcpOAV9PromocionID ;
      private int Gxuitabspanel_tabs1_Pagecount ;
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
      private string Panel_promociondistribuidor_Width ;
      private string Panel_promociondistribuidor_Cls ;
      private string Panel_promociondistribuidor_Title ;
      private string Panel_promociondistribuidor_Iconposition ;
      private string Dvpanel_unnamedtable2_Width ;
      private string Dvpanel_unnamedtable2_Cls ;
      private string Dvpanel_unnamedtable2_Title ;
      private string Dvpanel_unnamedtable2_Iconposition ;
      private string Panel_promocionmodelo_Width ;
      private string Panel_promocionmodelo_Cls ;
      private string Panel_promocionmodelo_Title ;
      private string Panel_promocionmodelo_Iconposition ;
      private string Gxuitabspanel_tabs1_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblTab1_title_Internalname ;
      private string lblTab1_title_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string divTablemaincomponent_Internalname ;
      private string WebComp_Wcwcduplicarpromo_Component ;
      private string OldWcwcduplicarpromo ;
      private string lblTab2_title_Internalname ;
      private string lblTab2_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string divTablerightcomponents_Internalname ;
      private string divWpduplicarpromopromociondistribuidorwc_cell_Internalname ;
      private string Panel_promociondistribuidor_Internalname ;
      private string divTablepanel_promociondistribuidor_Internalname ;
      private string WebComp_Webcomponent_promociondistribuidor_Component ;
      private string OldWebcomponent_promociondistribuidor ;
      private string Dvpanel_unnamedtable2_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string WebComp_Wcwpdetallepromocionpromocionsegmentowc_Component ;
      private string OldWcwpdetallepromocionpromocionsegmentowc ;
      private string divWpduplicarpromopromocionmodelowc_cell_Internalname ;
      private string Panel_promocionmodelo_Internalname ;
      private string divTablepanel_promocionmodelo_Internalname ;
      private string WebComp_Webcomponent_promocionmodelo_Component ;
      private string OldWebcomponent_promocionmodelo ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Panel_promociondistribuidor_Autowidth ;
      private bool Panel_promociondistribuidor_Autoheight ;
      private bool Panel_promociondistribuidor_Collapsible ;
      private bool Panel_promociondistribuidor_Collapsed ;
      private bool Panel_promociondistribuidor_Showcollapseicon ;
      private bool Panel_promociondistribuidor_Autoscroll ;
      private bool Dvpanel_unnamedtable2_Autowidth ;
      private bool Dvpanel_unnamedtable2_Autoheight ;
      private bool Dvpanel_unnamedtable2_Collapsible ;
      private bool Dvpanel_unnamedtable2_Collapsed ;
      private bool Dvpanel_unnamedtable2_Showcollapseicon ;
      private bool Dvpanel_unnamedtable2_Autoscroll ;
      private bool Panel_promocionmodelo_Autowidth ;
      private bool Panel_promocionmodelo_Autoheight ;
      private bool Panel_promocionmodelo_Collapsible ;
      private bool Panel_promocionmodelo_Collapsed ;
      private bool Panel_promocionmodelo_Showcollapseicon ;
      private bool Panel_promocionmodelo_Autoscroll ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV8Exists ;
      private bool bDynCreated_Wcwpdetallepromocionpromocionsegmentowc ;
      private bool bDynCreated_Wcwcduplicarpromo ;
      private bool bDynCreated_Webcomponent_promociondistribuidor ;
      private bool bDynCreated_Webcomponent_promocionmodelo ;
      private string A42PromocionDescripcion ;
      private GXWebComponent WebComp_Wcwcduplicarpromo ;
      private GXWebComponent WebComp_Webcomponent_promociondistribuidor ;
      private GXWebComponent WebComp_Wcwpdetallepromocionpromocionsegmentowc ;
      private GXWebComponent WebComp_Webcomponent_promocionmodelo ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private GXUserControl ucPanel_promociondistribuidor ;
      private GXUserControl ucDvpanel_unnamedtable2 ;
      private GXUserControl ucPanel_promocionmodelo ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private IDataStoreProvider pr_default ;
      private int[] H00412_A41PromocionID ;
      private string[] H00412_A42PromocionDescripcion ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpduplicarpromo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00412;
          prmH00412 = new Object[] {
          new ParDef("@AV9PromocionID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00412", "SELECT `PromocionID`, `PromocionDescripcion` FROM `Promocion` WHERE `PromocionID` = @AV9PromocionID ORDER BY `PromocionID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00412,1, GxCacheFrequency.OFF ,false,true )
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
