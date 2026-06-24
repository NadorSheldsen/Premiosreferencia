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
   public class wpavisoprivacidad : GXDataArea
   {
      public wpavisoprivacidad( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpavisoprivacidad( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( bool aP0_Aviso )
      {
         this.AV9Aviso = aP0_Aviso;
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
            gxfirstwebparm = GetFirstPar( "Aviso");
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
               gxfirstwebparm = GetFirstPar( "Aviso");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Aviso");
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpagenoauth", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpagenoauth", new Object[] {context});
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
         PA4Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4Y2( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wpavisoprivacidad.aspx"+UrlEncode(StringUtil.BoolToStr(AV9Aviso));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpavisoprivacidad.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vAVISO", AV9Aviso);
         GxWebStd.gx_hidden_field( context, "gxhash_vAVISO", GetSecureSignedToken( "", AV9Aviso, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vAVISO", AV9Aviso);
         GxWebStd.gx_hidden_field( context, "gxhash_vAVISO", GetSecureSignedToken( "", AV9Aviso, context));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLERESULTS_Width", StringUtil.RTrim( Dvpanel_tableresults_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLERESULTS_Autowidth", StringUtil.BoolToStr( Dvpanel_tableresults_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLERESULTS_Autoheight", StringUtil.BoolToStr( Dvpanel_tableresults_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLERESULTS_Cls", StringUtil.RTrim( Dvpanel_tableresults_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLERESULTS_Title", StringUtil.RTrim( Dvpanel_tableresults_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLERESULTS_Collapsible", StringUtil.BoolToStr( Dvpanel_tableresults_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLERESULTS_Collapsed", StringUtil.BoolToStr( Dvpanel_tableresults_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLERESULTS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableresults_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLERESULTS_Iconposition", StringUtil.RTrim( Dvpanel_tableresults_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLERESULTS_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableresults_Autoscroll));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
            WE4Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4Y2( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wpavisoprivacidad.aspx"+UrlEncode(StringUtil.BoolToStr(AV9Aviso));
         return formatLink("wpavisoprivacidad.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WPAvisoPrivacidad" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Aviso de Privacidad", "") ;
      }

      protected void WB4Y0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableresults.SetProperty("Width", Dvpanel_tableresults_Width);
            ucDvpanel_tableresults.SetProperty("AutoWidth", Dvpanel_tableresults_Autowidth);
            ucDvpanel_tableresults.SetProperty("AutoHeight", Dvpanel_tableresults_Autoheight);
            ucDvpanel_tableresults.SetProperty("Cls", Dvpanel_tableresults_Cls);
            ucDvpanel_tableresults.SetProperty("Title", Dvpanel_tableresults_Title);
            ucDvpanel_tableresults.SetProperty("Collapsible", Dvpanel_tableresults_Collapsible);
            ucDvpanel_tableresults.SetProperty("Collapsed", Dvpanel_tableresults_Collapsed);
            ucDvpanel_tableresults.SetProperty("ShowCollapseIcon", Dvpanel_tableresults_Showcollapseicon);
            ucDvpanel_tableresults.SetProperty("IconPosition", Dvpanel_tableresults_Iconposition);
            ucDvpanel_tableresults.SetProperty("AutoScroll", Dvpanel_tableresults_Autoscroll);
            ucDvpanel_tableresults.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableresults_Internalname, "DVPANEL_TABLERESULTSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLERESULTSContainer"+"TableResults"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableresults_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, lblTextblock1_Caption, "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WPAvisoPrivacidad.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableaccion_Internalname, divTableaccion_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_29_4Y2( true) ;
         }
         else
         {
            wb_table1_29_4Y2( false) ;
         }
         return  ;
      }

      protected void wb_table1_29_4Y2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFocustrap_Internalname, StringUtil.RTrim( AV10FocusTrap), StringUtil.RTrim( context.localUtil.Format( AV10FocusTrap, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFocustrap_Jsonclick, 0, "Attribute", "", "", "", "", edtavFocustrap_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPAvisoPrivacidad.htm");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDescription_Internalname, AV6Description, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, edtavDescription_Visible, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WPAvisoPrivacidad.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4Y2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Aviso de Privacidad", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4Y0( ) ;
      }

      protected void WS4Y2( )
      {
         START4Y2( ) ;
         EVT4Y2( ) ;
      }

      protected void EVT4Y2( )
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
                              E114Y2 ();
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
                                    E124Y2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction2' */
                              E134Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E144Y2 ();
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

      protected void WE4Y2( )
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

      protected void PA4Y2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpavisoprivacidad.aspx")), "wpavisoprivacidad.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpavisoprivacidad.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "Aviso");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV9Aviso = StringUtil.StrToBool( gxfirstwebparm);
                     AssignAttri("", false, "AV9Aviso", AV9Aviso);
                     GxWebStd.gx_hidden_field( context, "gxhash_vAVISO", GetSecureSignedToken( "", AV9Aviso, context));
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
         RF4Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF4Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E144Y2 ();
            WB4Y0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4Y2( )
      {
      }

      protected void before_start_formulas( )
      {
         if ( (false==AV9Aviso) )
         {
            AV9Aviso = false;
            AssignAttri("", false, "AV9Aviso", AV9Aviso);
            GxWebStd.gx_hidden_field( context, "gxhash_vAVISO", GetSecureSignedToken( "", AV9Aviso, context));
         }
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_tableresults_Width = cgiGet( "DVPANEL_TABLERESULTS_Width");
            Dvpanel_tableresults_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLERESULTS_Autowidth"));
            Dvpanel_tableresults_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLERESULTS_Autoheight"));
            Dvpanel_tableresults_Cls = cgiGet( "DVPANEL_TABLERESULTS_Cls");
            Dvpanel_tableresults_Title = cgiGet( "DVPANEL_TABLERESULTS_Title");
            Dvpanel_tableresults_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLERESULTS_Collapsible"));
            Dvpanel_tableresults_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLERESULTS_Collapsed"));
            Dvpanel_tableresults_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLERESULTS_Showcollapseicon"));
            Dvpanel_tableresults_Iconposition = cgiGet( "DVPANEL_TABLERESULTS_Iconposition");
            Dvpanel_tableresults_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLERESULTS_Autoscroll"));
            /* Read variables values. */
            AV10FocusTrap = cgiGet( edtavFocustrap_Internalname);
            AssignAttri("", false, "AV10FocusTrap", AV10FocusTrap);
            AV6Description = cgiGet( edtavDescription_Internalname);
            AssignAttri("", false, "AV6Description", AV6Description);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E114Y2 ();
         if (returnInSub) return;
      }

      protected void E114Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = context.GetMessage( "Aviso de Privacidad", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( AV9Aviso )
         {
            divTableaccion_Visible = 0;
            AssignProp("", false, divTableaccion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableaccion_Visible), 5, 0), true);
         }
         Form.Headerrawhtml = Form.Headerrawhtml+context.GetMessage( "<style>", "")+context.GetMessage( ".privacy-html{font-size:14px; line-height:1.55; text-align:justify;}", "")+context.GetMessage( ".privacy-html h2{margin:0 0 12px 0; font-size:20px;}", "")+context.GetMessage( ".privacy-html h3{margin:16px 0 8px 0; font-size:16px;}", "")+context.GetMessage( ".privacy-html h4{margin:12px 0 6px 0; font-size:14px;}", "")+context.GetMessage( ".privacy-html p{margin:0 0 10px 0;}", "")+context.GetMessage( ".privacy-html a{text-decoration:underline;}", "")+context.GetMessage( ".privacy-html ol.roman{margin:6px 0 12px 18px; padding:0;}", "")+context.GetMessage( ".privacy-html ol.roman{list-style-type:lower-roman;}", "")+context.GetMessage( "</style>", "");
         /* Execute user subroutine: 'LOADAVISOHTML' */
         S112 ();
         if (returnInSub) return;
         lblTextblock1_Caption = AV12HtmlAviso;
         AssignProp("", false, lblTextblock1_Internalname, "Caption", lblTextblock1_Caption, true);
         edtavFocustrap_Visible = 0;
         AssignProp("", false, edtavFocustrap_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFocustrap_Visible), 5, 0), true);
         edtavDescription_Visible = 0;
         AssignProp("", false, edtavDescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDescription_Visible), 5, 0), true);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E124Y2 ();
         if (returnInSub) return;
      }

      protected void E124Y2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV7URL = formatLink("wpvideo.aspx") ;
         this.executeExternalObjectMethod("", false, "GlobalEvents", "PrivacyDecision", new Object[] {(bool)true,(string)AV7URL}, true);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E134Y2( )
      {
         /* 'DoUserAction2' Routine */
         returnInSub = false;
         this.executeExternalObjectMethod("", false, "GlobalEvents", "PrivacyDecision", new Object[] {(bool)false,(string)""}, true);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADAVISOHTML' Routine */
         returnInSub = false;
         AV12HtmlAviso = context.GetMessage( "<div class='privacy-html'>", "") + context.GetMessage( "<p>Con fundamento en lo dispuesto por la Ley Federal de Protección de Datos Personales en Posesión de los Particulares, su Reglamento y los Lineamientos aplicables al Aviso de Privacidad, <strong>[YOKOHAMA TIRE MÉXICO, S. DE R.L. DE C.V.]</strong> (el “Responsable”), quien tiene su domicilio en <strong>Prol. Bernardo Quintana No. 300-Interior 1102, Centro Sur, 76090 Santiago de Querétaro, Qro</strong>, emite el presente Aviso de Privacidad (el “Aviso”), mediante el cual informa que es responsable de la obtención y tratamiento de los datos personales proporcionados por los titulares para la prestación de los servicios que ofrece al público en general.</p>", "") + context.GetMessage( "<p>Dicha información será manejada con estricta confidencialidad, garantizando su uso y protección, y se pone a disposición de cualquier persona física (el “Titular”) cuyos datos sean objeto de tratamiento.</p>", "") + context.GetMessage( "<p>El presente Aviso podrá ser consultado en el sitio web <a href='https://premiosyokohama.com/wpavisoprivacidad.aspx' target='_blank' rel='noopener'>https://premiosyokohama.com/wpavisoprivacidad.aspx</a> y/o en el domicilio antes indicado.</p>", "") + context.GetMessage( "<h3>OBJETO</h3>", "") + context.GetMessage( "<p>El responsable podrá utilizar los datos personales del Titular para las siguientes finalidades:</p>", "") + context.GetMessage( "<h4>Clientes</h4>", "") + context.GetMessage( "<ol class='roman'>", "") + context.GetMessage( "<li>suministrar los productos o servicios solicitados por el Titular;</li>", "") + context.GetMessage( "<li>efectuar modificaciones o reparaciones a los productos adquiridos;</li>", "") + context.GetMessage( "<li>cumplir con las obligaciones contraídas con o por el Titular;</li>", "") + context.GetMessage( "<li>integrar el expediente correspondiente como cliente;</li>", "") + context.GetMessage( "<li>registrar pedidos por los medios acordados;</li>", "") + context.GetMessage( "<li>comunicar noticias, novedades, promociones, puntos de venta, materiales de apoyo y proporcionar asistencia técnica;</li>", "") + context.GetMessage( "<li>otorgar información relacionada con facturación, entrega de productos, estados de cuenta y procesos de cobranza;</li>", "") + context.GetMessage( "<li>realizar encuestas para evaluar la calidad de los productos y servicios;</li>", "") + context.GetMessage( "<li>atender asuntos relativos a satisfacción del cliente, servicio post-venta, garantías con proveedores y otros similares;</li>", "") + context.GetMessage( "<li>en general, dar cumplimiento a las operaciones comerciales existentes entre el Titular y el Responsable.</li>", "") + context.GetMessage( "</ol>", "") + context.GetMessage( "<h4>Empleados</h4>", "") + context.GetMessage( "<ol class='roman'>", "") + context.GetMessage( "<li>llevar a cabo procesos de reclutamiento y selección de personal;</li>", "") + context.GetMessage( "<li>integrar el expediente laboral en caso de contratación; y</li>", "") + context.GetMessage( "<li>cumplir con las prestaciones y obligaciones derivadas de la relación laboral.</li>", "") + context.GetMessage( "</ol>", "") + context.GetMessage( "<p>En caso de que el Responsable requiera tratar los datos personales para finalidades distintas a las aquí previstas, se lo notificará al Titular y recabará su consentimiento para el nuevo tratamiento.</p>", "") + context.GetMessage( "<p>Adicionalmente, la información personal podrá utilizarse para fines no indispensables, pero que permiten brindar una mejor atención, tales como: actividades de venta y post-venta; difusión de información sobre productos (noticias, promociones, puntos de venta, materiales de apoyo); asesoría técnica, capacitaciones, garantías y encuestas de calidad.</p>", "") + context.GetMessage( "<p>Si el Titular no desea que sus datos sean tratados para estas finalidades adicionales, podrá manifestarlo al correo electrónico <a href='mailto:mercadotecnia@yokohamatire.mx'>mercadotecnia@yokohamatire.mx</a>.</p>", "") + context.GetMessage( "<h3>DATOS PERSONALES</h3>", "") + context.GetMessage( "<p>El Responsable podrá recabar los siguientes datos del Titular:</p>", "") + context.GetMessage( "<h4>Clientes</h4>", "") + context.GetMessage( "<p>Datos de identificación, contacto, patrimoniales y financieros: nombre, domicilio, correo electrónico, número telefónico fijo y móvil, cuentas bancarias, firma autógrafa y Registro Federal de Contribuyentes (RFC).</p>", "") + context.GetMessage( "<h4>Empleados</h4>", "") + context.GetMessage( "<p>Datos de identificación, contacto, académicos, laborales, patrimoniales y financieros: nombre, domicilio, correo electrónico, números telefónicos, firma autógrafa, RFC, Clave Única de Registro de Población (CURP), nivel de estudios, título, cédula profesional, puesto, referencias laborales, número de seguridad social, créditos con entidades gubernamentales (INFONAVIT o FONACOT) y cuenta bancaria.</p>", "") + context.GetMessage( "<p>Los datos patrimoniales o financieros solo serán recabados cuando resulten necesarios para el cumplimiento de las obligaciones derivadas de la relación existente entre el Titular y el Responsable.</p>", "") + context.GetMessage( "<p>El Responsable declara que no recaba datos personales sensibles para las finalidades señaladas en el presente Aviso.</p>", "") + context.GetMessage( "<h3>CONSENTIMIENTO</h3>", "") + context.GetMessage( "<p>Se entenderá que el Titular ha otorgado su consentimiento para el tratamiento de sus datos personales conforme a este Aviso cuando: (i) no manifieste oposición alguna una vez puesto a su disposición; (ii) lo otorgue de forma expresa; y/o (iii) mantenga una relación vigente con el Responsable.</p>", "") + context.GetMessage( "<h3>TRANSFERENCIAS</h3>", "") + context.GetMessage( "<p>El Responsable informa que los datos personales del Titular no serán transferidos a terceros, salvo cuando dicha transferencia sea necesaria para cumplir con las obligaciones derivadas de la relación jurídica con el Titular o cuando se actualice alguna de las excepciones previstas en el artículo 37 de la Ley Federal de Protección de Datos Personales en Posesión de los Particulares.</p>", "") + context.GetMessage( "<p>Si el Titular no está de acuerdo con alguna de las transferencias señaladas, deberá comunicarlo al correo electrónico <a href='mailto:mercadotecnia@yokohamatire.mx'>mercadotecnia@yokohamatire.mx</a>.</p>", "") + context.GetMessage( "<h3>DERECHOS DEL TITULAR (YOKOHAMA TIRE MX)</h3>", "") + context.GetMessage( "<p>El Titular podrá ejercer los derechos de: (i) acceso a sus datos personales y a la información sobre su tratamiento; (ii) rectificación cuando estos sean inexactos o incompletos; (iii) cancelación cuando ya no sean necesarios para las finalidades indicadas, se hayan utilizado en contravención a este Aviso o haya concluido la relación que dio origen a su obtención; (iv) oposición al tratamiento para fines específicos; (v) revocación del consentimiento otorgado; y (vi) limitación del uso o divulgación de sus datos.</p>", "") + context.GetMessage( "<p>Para ejercer cualquiera de estos derechos, el Titular deberá presentar una solicitud por escrito en el domicilio del Responsable o al correo electrónico <a href='mailto:mercadotecnia@yokohamatire.mx'>mercadotecnia@yokohamatire.mx</a>, la cual deberá incluir: (i) nombre y domicilio del Titular; (ii) documentos que acrediten su identidad o, en su caso, la representación legal; (iii) descripción clara y precisa de los datos respecto de los cuales desea ejercer sus derechos; y (iv) cualquier otro elemento que facilite la localización de los datos, así como la documentación que sustente la procedencia de las correcciones solicitadas.</p>", "") + context.GetMessage( "<p>El área de protección de datos personales del Responsable dará respuesta a la solicitud en un plazo de 15 (quince) días hábiles contados a partir de su recepción, el cual podrá ampliarse por 10 (diez) días hábiles adicionales, previa notificación al Titular. La respuesta se enviará al domicilio o correo electrónico que éste haya señalado. En caso de solicitudes de acceso, los datos se pondrán a disposición mediante copias simples, documentos electrónicos o cualquier otro medio que permita su consulta.</p>", "") + context.GetMessage( "<p>Adicionalmente, para solicitudes de: (i) rectificación, deberán indicarse las modificaciones y anexar la documentación oficial correspondiente; (ii) cancelación, señalar las causas que justifiquen la eliminación; y (iii) oposición, expresar los motivos que fundamenten la terminación del tratamiento.</p>", "") + context.GetMessage( "<h3>MODIFICACIONES</h3>", "") + context.GetMessage( "<p>El Responsable se reserva el derecho de realizar en cualquier momento modificaciones o actualizaciones al presente Aviso, derivadas de cambios legislativos o de nuevas políticas internas, las cuales estarán disponibles en el domicilio del Responsable.</p>", "") + context.GetMessage( "</div>", "");
         AssignAttri("", false, "AV12HtmlAviso", AV12HtmlAviso);
      }

      protected void nextLoad( )
      {
      }

      protected void E144Y2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_29_4Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedbtnenter_Internalname, tblTablemergedbtnenter_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPAvisoPrivacidad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction2_Internalname, "", context.GetMessage( "Cancelar", ""), bttBtnuseraction2_Jsonclick, 5, context.GetMessage( "Cancelar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION2\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPAvisoPrivacidad.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_29_4Y2e( true) ;
         }
         else
         {
            wb_table1_29_4Y2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV9Aviso = (bool)getParm(obj,0);
         AssignAttri("", false, "AV9Aviso", AV9Aviso);
         GxWebStd.gx_hidden_field( context, "gxhash_vAVISO", GetSecureSignedToken( "", AV9Aviso, context));
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
         PA4Y2( ) ;
         WS4Y2( ) ;
         WE4Y2( ) ;
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20265111131977", true, true);
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
         context.AddJavascriptSource("wpavisoprivacidad.js", "?20265111131977", false, true);
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
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTableresults_Internalname = "TABLERESULTS";
         Dvpanel_tableresults_Internalname = "DVPANEL_TABLERESULTS";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtnuseraction2_Internalname = "BTNUSERACTION2";
         tblTablemergedbtnenter_Internalname = "TABLEMERGEDBTNENTER";
         divTableaccion_Internalname = "TABLEACCION";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavFocustrap_Internalname = "vFOCUSTRAP";
         edtavDescription_Internalname = "vDESCRIPTION";
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
         edtavDescription_Visible = 1;
         edtavFocustrap_Jsonclick = "";
         edtavFocustrap_Visible = 1;
         divTableaccion_Visible = 1;
         lblTextblock1_Caption = "";
         Dvpanel_tableresults_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableresults_Iconposition = "Right";
         Dvpanel_tableresults_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableresults_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableresults_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableresults_Title = "";
         Dvpanel_tableresults_Cls = "PanelNoHeader";
         Dvpanel_tableresults_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableresults_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableresults_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Aviso de Privacidad", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV9Aviso","fld":"vAVISO","hsh":true}]}""");
         setEventMetadata("ENTER","""{"handler":"E124Y2","iparms":[]}""");
         setEventMetadata("'DOUSERACTION2'","""{"handler":"E134Y2","iparms":[]}""");
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
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableresults = new GXUserControl();
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         AV10FocusTrap = "";
         AV6Description = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV12HtmlAviso = "";
         AV7URL = "";
         sStyleString = "";
         bttBtnenter_Jsonclick = "";
         bttBtnuseraction2_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int divTableaccion_Visible ;
      private int edtavFocustrap_Visible ;
      private int edtavDescription_Visible ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_tableresults_Width ;
      private string Dvpanel_tableresults_Cls ;
      private string Dvpanel_tableresults_Title ;
      private string Dvpanel_tableresults_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableresults_Internalname ;
      private string divTableresults_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Caption ;
      private string lblTextblock1_Jsonclick ;
      private string divTableaccion_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string TempTags ;
      private string edtavFocustrap_Internalname ;
      private string AV10FocusTrap ;
      private string edtavFocustrap_Jsonclick ;
      private string edtavDescription_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sStyleString ;
      private string tblTablemergedbtnenter_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtnuseraction2_Internalname ;
      private string bttBtnuseraction2_Jsonclick ;
      private bool AV9Aviso ;
      private bool wcpOAV9Aviso ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tableresults_Autowidth ;
      private bool Dvpanel_tableresults_Autoheight ;
      private bool Dvpanel_tableresults_Collapsible ;
      private bool Dvpanel_tableresults_Collapsed ;
      private bool Dvpanel_tableresults_Showcollapseicon ;
      private bool Dvpanel_tableresults_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV6Description ;
      private string AV12HtmlAviso ;
      private string AV7URL ;
      private GXUserControl ucDvpanel_tableresults ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
