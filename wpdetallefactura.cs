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
   public class wpdetallefactura : GXDataArea
   {
      public wpdetallefactura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpdetallefactura( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_FacturaID )
      {
         this.AV6FacturaID = aP0_FacturaID;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavFactura_usuariozona = new GXCombobox();
         cmbavFactura_usuariogenero = new GXCombobox();
         cmbavFactura_facturaestatus = new GXCombobox();
         chkavFactura_motivorechazoactivo = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "FacturaID");
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
               gxfirstwebparm = GetFirstPar( "FacturaID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "FacturaID");
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
         PA3E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3E2( ) ;
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
         GXEncryptionTmp = "wpdetallefactura.aspx"+UrlEncode(StringUtil.LTrimStr(AV6FacturaID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpdetallefactura.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6FacturaID), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Factura", AV5Factura);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Factura", AV5Factura);
         }
         GxWebStd.gx_hidden_field( context, "vFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6FacturaID), "ZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFACTURA", AV5Factura);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFACTURA", AV5Factura);
         }
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
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Width", StringUtil.RTrim( Dvpanel_unnamedtable3_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Cls", StringUtil.RTrim( Dvpanel_unnamedtable3_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Title", StringUtil.RTrim( Dvpanel_unnamedtable3_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable3_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Autoscroll));
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
         if ( ! ( WebComp_Wcwcpartidasfactura == null ) )
         {
            WebComp_Wcwcpartidasfactura.componentjscripts();
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
            WE3E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3E2( ) ;
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
         GXEncryptionTmp = "wpdetallefactura.aspx"+UrlEncode(StringUtil.LTrimStr(AV6FacturaID,9,0));
         return formatLink("wpdetallefactura.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WPDetalleFactura" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WPDetalle Factura", "") ;
      }

      protected void WB3E0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain TableViewCardsCell ViewGridNoBorderCell", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ViewCardCellWidth40", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFactura_facturaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFactura_facturaid_Internalname, context.GetMessage( "Folio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFactura_facturaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Factura.gxTpr_Facturaid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavFactura_facturaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5Factura.gxTpr_Facturaid), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5Factura.gxTpr_Facturaid), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFactura_facturaid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFactura_facturaid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDetalleFactura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFactura_facturano_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFactura_facturano_Internalname, context.GetMessage( "No. Factura", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFactura_facturano_Internalname, StringUtil.RTrim( AV5Factura.gxTpr_Facturano), StringUtil.RTrim( context.localUtil.Format( AV5Factura.gxTpr_Facturano, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFactura_facturano_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFactura_facturano_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDetalleFactura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFactura_facturafechafactura_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFactura_facturafechafactura_Internalname, context.GetMessage( "Fecha Factura", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFactura_facturafechafactura_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFactura_facturafechafactura_Internalname, context.localUtil.Format(AV5Factura.gxTpr_Facturafechafactura, "99/99/99"), context.localUtil.Format( AV5Factura.gxTpr_Facturafechafactura, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFactura_facturafechafactura_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFactura_facturafechafactura_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDetalleFactura.htm");
            GxWebStd.gx_bitmap( context, edtavFactura_facturafechafactura_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFactura_facturafechafactura_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPDetalleFactura.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFactura_facturafecharegistro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFactura_facturafecharegistro_Internalname, context.GetMessage( "Fecha Registro", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFactura_facturafecharegistro_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFactura_facturafecharegistro_Internalname, context.localUtil.Format(AV5Factura.gxTpr_Facturafecharegistro, "99/99/99"), context.localUtil.Format( AV5Factura.gxTpr_Facturafecharegistro, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFactura_facturafecharegistro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFactura_facturafecharegistro_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDetalleFactura.htm");
            GxWebStd.gx_bitmap( context, edtavFactura_facturafecharegistro_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFactura_facturafecharegistro_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPDetalleFactura.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFactura_usuarionombrecompleto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFactura_usuarionombrecompleto_Internalname, context.GetMessage( "Nombre completo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFactura_usuarionombrecompleto_Internalname, AV5Factura.gxTpr_Usuarionombrecompleto, StringUtil.RTrim( context.localUtil.Format( AV5Factura.gxTpr_Usuarionombrecompleto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFactura_usuarionombrecompleto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFactura_usuarionombrecompleto_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDetalleFactura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavFactura_usuariozona_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFactura_usuariozona_Internalname, context.GetMessage( "Usuario Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFactura_usuariozona, cmbavFactura_usuariozona_Internalname, StringUtil.RTrim( AV5Factura.gxTpr_Usuariozona), 1, cmbavFactura_usuariozona_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFactura_usuariozona.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", true, 0, "HLP_WPDetalleFactura.htm");
            cmbavFactura_usuariozona.CurrentValue = StringUtil.RTrim( AV5Factura.gxTpr_Usuariozona);
            AssignProp("", false, cmbavFactura_usuariozona_Internalname, "Values", (string)(cmbavFactura_usuariozona.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFactura_estadodescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFactura_estadodescripcion_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFactura_estadodescripcion_Internalname, AV5Factura.gxTpr_Estadodescripcion, StringUtil.RTrim( context.localUtil.Format( AV5Factura.gxTpr_Estadodescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFactura_estadodescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFactura_estadodescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDetalleFactura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFactura_ciudaddescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFactura_ciudaddescripcion_Internalname, context.GetMessage( "Ciudad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFactura_ciudaddescripcion_Internalname, AV5Factura.gxTpr_Ciudaddescripcion, StringUtil.RTrim( context.localUtil.Format( AV5Factura.gxTpr_Ciudaddescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFactura_ciudaddescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFactura_ciudaddescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDetalleFactura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFactura_paisdescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFactura_paisdescripcion_Internalname, context.GetMessage( "País", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFactura_paisdescripcion_Internalname, AV5Factura.gxTpr_Paisdescripcion, StringUtil.RTrim( context.localUtil.Format( AV5Factura.gxTpr_Paisdescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFactura_paisdescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFactura_paisdescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDetalleFactura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavFactura_usuariogenero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFactura_usuariogenero_Internalname, context.GetMessage( "Género", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFactura_usuariogenero, cmbavFactura_usuariogenero_Internalname, StringUtil.RTrim( AV5Factura.gxTpr_Usuariogenero), 1, cmbavFactura_usuariogenero_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFactura_usuariogenero.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", true, 0, "HLP_WPDetalleFactura.htm");
            cmbavFactura_usuariogenero.CurrentValue = StringUtil.RTrim( AV5Factura.gxTpr_Usuariogenero);
            AssignProp("", false, cmbavFactura_usuariogenero_Internalname, "Values", (string)(cmbavFactura_usuariogenero.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFactura_facturapdf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFactura_facturapdf_Internalname, context.GetMessage( "PDF", ""), "col-sm-3 AttributeFLLabel BootstrapTooltipRightLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* BinaryFile Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            ClassString = "AttributeFL BootstrapTooltipRight";
            StyleString = "";
            GxWebStd.gx_file( context, edtavFactura_facturapdf_Internalname, (String.IsNullOrEmpty(StringUtil.RTrim( AV5Factura.gxTpr_Facturapdf)) ? AV5Factura.gxTpr_Facturapdf_gxi : context.PathToRelativeUrl( AV5Factura.gxTpr_Facturapdf)), edtavFactura_facturapdf_Filename, 1, 1, edtavFactura_facturapdf_Enabled, 0, 0, "", 0, "", 0, "", "", StyleString, ClassString, "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "", "", 1, false, "HLP_WPDetalleFactura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavFactura_facturaestatus_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFactura_facturaestatus_Internalname, context.GetMessage( "Estatus", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFactura_facturaestatus, cmbavFactura_facturaestatus_Internalname, StringUtil.RTrim( AV5Factura.gxTpr_Facturaestatus), 1, cmbavFactura_facturaestatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFactura_facturaestatus.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", true, 0, "HLP_WPDetalleFactura.htm");
            cmbavFactura_facturaestatus.CurrentValue = StringUtil.RTrim( AV5Factura.gxTpr_Facturaestatus);
            AssignProp("", false, cmbavFactura_facturaestatus_Internalname, "Values", (string)(cmbavFactura_facturaestatus.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFactura_motivorechazodescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFactura_motivorechazodescripcion_Internalname, context.GetMessage( "Motivo de rechazo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFactura_motivorechazodescripcion_Internalname, AV5Factura.gxTpr_Motivorechazodescripcion, StringUtil.RTrim( context.localUtil.Format( AV5Factura.gxTpr_Motivorechazodescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFactura_motivorechazodescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFactura_motivorechazodescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDetalleFactura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPrecio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPrecio_Internalname, context.GetMessage( "Precio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7Precio, 14, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavPrecio_Enabled!=0) ? context.localUtil.Format( AV7Precio, "$ Z,ZZZ,ZZ9.99") : context.localUtil.Format( AV7Precio, "$ Z,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPrecio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPrecio_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_WPDetalleFactura.htm");
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
            /* User Defined Control */
            ucDvpanel_unnamedtable3.SetProperty("Width", Dvpanel_unnamedtable3_Width);
            ucDvpanel_unnamedtable3.SetProperty("AutoWidth", Dvpanel_unnamedtable3_Autowidth);
            ucDvpanel_unnamedtable3.SetProperty("AutoHeight", Dvpanel_unnamedtable3_Autoheight);
            ucDvpanel_unnamedtable3.SetProperty("Cls", Dvpanel_unnamedtable3_Cls);
            ucDvpanel_unnamedtable3.SetProperty("Title", Dvpanel_unnamedtable3_Title);
            ucDvpanel_unnamedtable3.SetProperty("Collapsible", Dvpanel_unnamedtable3_Collapsible);
            ucDvpanel_unnamedtable3.SetProperty("Collapsed", Dvpanel_unnamedtable3_Collapsed);
            ucDvpanel_unnamedtable3.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable3_Showcollapseicon);
            ucDvpanel_unnamedtable3.SetProperty("IconPosition", Dvpanel_unnamedtable3_Iconposition);
            ucDvpanel_unnamedtable3.SetProperty("AutoScroll", Dvpanel_unnamedtable3_Autoscroll);
            ucDvpanel_unnamedtable3.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable3_Internalname, "DVPANEL_UNNAMEDTABLE3Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE3Container"+"UnnamedTable3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFactura_promociondescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFactura_promociondescripcion_Internalname, context.GetMessage( "Nom. Promoción", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFactura_promociondescripcion_Internalname, AV5Factura.gxTpr_Promociondescripcion, StringUtil.RTrim( context.localUtil.Format( AV5Factura.gxTpr_Promociondescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFactura_promociondescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFactura_promociondescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDetalleFactura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFactura_promocionvigencia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFactura_promocionvigencia_Internalname, context.GetMessage( "Vigencia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFactura_promocionvigencia_Internalname, AV5Factura.gxTpr_Promocionvigencia, StringUtil.RTrim( context.localUtil.Format( AV5Factura.gxTpr_Promocionvigencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFactura_promocionvigencia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFactura_promocionvigencia_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDetalleFactura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFactura_promocionbase_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFactura_promocionbase_Internalname, context.GetMessage( "Bases", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavFactura_promocionbase_Internalname, AV5Factura.gxTpr_Promocionbase, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", 0, 1, edtavFactura_promocionbase_Enabled, 0, 80, "chr", 9, "row", 0, StyleString, ClassString, "", "", "700", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WPDetalleFactura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgavFactura_promocionarte_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Arte", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "AttributeFL" + " " + ((StringUtil.StrCmp(imgavFactura_promocionarte_gximage, "")==0) ? "" : "GX_Image_"+imgavFactura_promocionarte_gximage+"_Class");
            StyleString = "";
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5Factura.gxTpr_Promocionarte)) ? AV5Factura.gxTpr_Promocionarte_gxi : context.PathToRelativeUrl( AV5Factura.gxTpr_Promocionarte));
            GxWebStd.gx_bitmap( context, imgavFactura_promocionarte_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPDetalleFactura.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
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
               GxWebStd.gx_hidden_field( context, "W0111"+"", StringUtil.RTrim( WebComp_Wcwcpartidasfactura_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0111"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwcpartidasfactura_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcpartidasfactura), StringUtil.Lower( WebComp_Wcwcpartidasfactura_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0111"+"");
                  }
                  WebComp_Wcwcpartidasfactura.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcpartidasfactura), StringUtil.Lower( WebComp_Wcwcpartidasfactura_Component)) != 0 )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFactura_promocionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Factura.gxTpr_Promocionid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Factura.gxTpr_Promocionid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFactura_promocionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavFactura_promocionid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDetalleFactura.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFactura_usuarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Factura.gxTpr_Usuarioid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Factura.gxTpr_Usuarioid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFactura_usuarioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavFactura_usuarioid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDetalleFactura.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFactura_motivorechazoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Factura.gxTpr_Motivorechazoid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Factura.gxTpr_Motivorechazoid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFactura_motivorechazoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavFactura_motivorechazoid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDetalleFactura.htm");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFactura_motivorechazoactivo_Internalname, StringUtil.BoolToStr( AV5Factura.gxTpr_Motivorechazoactivo), "", "", chkavFactura_motivorechazoactivo.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(118, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,118);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3E2( )
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
         Form.Meta.addItem("description", context.GetMessage( "WPDetalle Factura", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3E0( ) ;
      }

      protected void WS3E2( )
      {
         START3E2( ) ;
         EVT3E2( ) ;
      }

      protected void EVT3E2( )
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
                              E113E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E123E2 ();
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
                        if ( nCmpId == 111 )
                        {
                           OldWcwcpartidasfactura = cgiGet( "W0111");
                           if ( ( StringUtil.Len( OldWcwcpartidasfactura) == 0 ) || ( StringUtil.StrCmp(OldWcwcpartidasfactura, WebComp_Wcwcpartidasfactura_Component) != 0 ) )
                           {
                              WebComp_Wcwcpartidasfactura = getWebComponent(GetType(), "GeneXus.Programs", OldWcwcpartidasfactura, new Object[] {context} );
                              WebComp_Wcwcpartidasfactura.ComponentInit();
                              WebComp_Wcwcpartidasfactura.Name = "OldWcwcpartidasfactura";
                              WebComp_Wcwcpartidasfactura_Component = OldWcwcpartidasfactura;
                           }
                           if ( StringUtil.Len( WebComp_Wcwcpartidasfactura_Component) != 0 )
                           {
                              WebComp_Wcwcpartidasfactura.componentprocess("W0111", "", sEvt);
                           }
                           WebComp_Wcwcpartidasfactura_Component = OldWcwcpartidasfactura;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3E2( )
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

      protected void PA3E2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpdetallefactura.aspx")), "wpdetallefactura.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpdetallefactura.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "FacturaID");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV6FacturaID = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV6FacturaID", StringUtil.LTrimStr( (decimal)(AV6FacturaID), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vFACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6FacturaID), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavFactura_facturaid_Internalname;
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
         if ( cmbavFactura_usuariozona.ItemCount > 0 )
         {
            AV5Factura.gxTpr_Usuariozona = cmbavFactura_usuariozona.getValidValue(AV5Factura.gxTpr_Usuariozona);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFactura_usuariozona.CurrentValue = StringUtil.RTrim( AV5Factura.gxTpr_Usuariozona);
            AssignProp("", false, cmbavFactura_usuariozona_Internalname, "Values", cmbavFactura_usuariozona.ToJavascriptSource(), true);
         }
         if ( cmbavFactura_usuariogenero.ItemCount > 0 )
         {
            AV5Factura.gxTpr_Usuariogenero = cmbavFactura_usuariogenero.getValidValue(AV5Factura.gxTpr_Usuariogenero);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFactura_usuariogenero.CurrentValue = StringUtil.RTrim( AV5Factura.gxTpr_Usuariogenero);
            AssignProp("", false, cmbavFactura_usuariogenero_Internalname, "Values", cmbavFactura_usuariogenero.ToJavascriptSource(), true);
         }
         if ( cmbavFactura_facturaestatus.ItemCount > 0 )
         {
            AV5Factura.gxTpr_Facturaestatus = cmbavFactura_facturaestatus.getValidValue(AV5Factura.gxTpr_Facturaestatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFactura_facturaestatus.CurrentValue = StringUtil.RTrim( AV5Factura.gxTpr_Facturaestatus);
            AssignProp("", false, cmbavFactura_facturaestatus_Internalname, "Values", cmbavFactura_facturaestatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavFactura_facturaid_Enabled = 0;
         AssignProp("", false, edtavFactura_facturaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_facturaid_Enabled), 5, 0), true);
         edtavFactura_facturano_Enabled = 0;
         AssignProp("", false, edtavFactura_facturano_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_facturano_Enabled), 5, 0), true);
         edtavFactura_facturafechafactura_Enabled = 0;
         AssignProp("", false, edtavFactura_facturafechafactura_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_facturafechafactura_Enabled), 5, 0), true);
         edtavFactura_facturafecharegistro_Enabled = 0;
         AssignProp("", false, edtavFactura_facturafecharegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_facturafecharegistro_Enabled), 5, 0), true);
         edtavFactura_usuarionombrecompleto_Enabled = 0;
         AssignProp("", false, edtavFactura_usuarionombrecompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_usuarionombrecompleto_Enabled), 5, 0), true);
         cmbavFactura_usuariozona.Enabled = 0;
         AssignProp("", false, cmbavFactura_usuariozona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFactura_usuariozona.Enabled), 5, 0), true);
         edtavFactura_estadodescripcion_Enabled = 0;
         AssignProp("", false, edtavFactura_estadodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_estadodescripcion_Enabled), 5, 0), true);
         edtavFactura_ciudaddescripcion_Enabled = 0;
         AssignProp("", false, edtavFactura_ciudaddescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_ciudaddescripcion_Enabled), 5, 0), true);
         edtavFactura_paisdescripcion_Enabled = 0;
         AssignProp("", false, edtavFactura_paisdescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_paisdescripcion_Enabled), 5, 0), true);
         cmbavFactura_usuariogenero.Enabled = 0;
         AssignProp("", false, cmbavFactura_usuariogenero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFactura_usuariogenero.Enabled), 5, 0), true);
         edtavFactura_facturapdf_Enabled = 0;
         AssignProp("", false, edtavFactura_facturapdf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_facturapdf_Enabled), 5, 0), true);
         cmbavFactura_facturaestatus.Enabled = 0;
         AssignProp("", false, cmbavFactura_facturaestatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFactura_facturaestatus.Enabled), 5, 0), true);
         edtavFactura_motivorechazodescripcion_Enabled = 0;
         AssignProp("", false, edtavFactura_motivorechazodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_motivorechazodescripcion_Enabled), 5, 0), true);
         edtavPrecio_Enabled = 0;
         AssignProp("", false, edtavPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPrecio_Enabled), 5, 0), true);
         edtavFactura_promociondescripcion_Enabled = 0;
         AssignProp("", false, edtavFactura_promociondescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_promociondescripcion_Enabled), 5, 0), true);
         edtavFactura_promocionvigencia_Enabled = 0;
         AssignProp("", false, edtavFactura_promocionvigencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_promocionvigencia_Enabled), 5, 0), true);
         edtavFactura_promocionbase_Enabled = 0;
         AssignProp("", false, edtavFactura_promocionbase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_promocionbase_Enabled), 5, 0), true);
      }

      protected void RF3E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwcpartidasfactura_Component) != 0 )
               {
                  WebComp_Wcwcpartidasfactura.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E123E2 ();
            WB3E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3E2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavFactura_facturaid_Enabled = 0;
         AssignProp("", false, edtavFactura_facturaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_facturaid_Enabled), 5, 0), true);
         edtavFactura_facturano_Enabled = 0;
         AssignProp("", false, edtavFactura_facturano_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_facturano_Enabled), 5, 0), true);
         edtavFactura_facturafechafactura_Enabled = 0;
         AssignProp("", false, edtavFactura_facturafechafactura_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_facturafechafactura_Enabled), 5, 0), true);
         edtavFactura_facturafecharegistro_Enabled = 0;
         AssignProp("", false, edtavFactura_facturafecharegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_facturafecharegistro_Enabled), 5, 0), true);
         edtavFactura_usuarionombrecompleto_Enabled = 0;
         AssignProp("", false, edtavFactura_usuarionombrecompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_usuarionombrecompleto_Enabled), 5, 0), true);
         cmbavFactura_usuariozona.Enabled = 0;
         AssignProp("", false, cmbavFactura_usuariozona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFactura_usuariozona.Enabled), 5, 0), true);
         edtavFactura_estadodescripcion_Enabled = 0;
         AssignProp("", false, edtavFactura_estadodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_estadodescripcion_Enabled), 5, 0), true);
         edtavFactura_ciudaddescripcion_Enabled = 0;
         AssignProp("", false, edtavFactura_ciudaddescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_ciudaddescripcion_Enabled), 5, 0), true);
         edtavFactura_paisdescripcion_Enabled = 0;
         AssignProp("", false, edtavFactura_paisdescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_paisdescripcion_Enabled), 5, 0), true);
         cmbavFactura_usuariogenero.Enabled = 0;
         AssignProp("", false, cmbavFactura_usuariogenero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFactura_usuariogenero.Enabled), 5, 0), true);
         edtavFactura_facturapdf_Enabled = 0;
         AssignProp("", false, edtavFactura_facturapdf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_facturapdf_Enabled), 5, 0), true);
         cmbavFactura_facturaestatus.Enabled = 0;
         AssignProp("", false, cmbavFactura_facturaestatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFactura_facturaestatus.Enabled), 5, 0), true);
         edtavFactura_motivorechazodescripcion_Enabled = 0;
         AssignProp("", false, edtavFactura_motivorechazodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_motivorechazodescripcion_Enabled), 5, 0), true);
         edtavPrecio_Enabled = 0;
         AssignProp("", false, edtavPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPrecio_Enabled), 5, 0), true);
         edtavFactura_promociondescripcion_Enabled = 0;
         AssignProp("", false, edtavFactura_promociondescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_promociondescripcion_Enabled), 5, 0), true);
         edtavFactura_promocionvigencia_Enabled = 0;
         AssignProp("", false, edtavFactura_promocionvigencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_promocionvigencia_Enabled), 5, 0), true);
         edtavFactura_promocionbase_Enabled = 0;
         AssignProp("", false, edtavFactura_promocionbase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFactura_promocionbase_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFACTURA"), AV5Factura);
            ajax_req_read_hidden_sdt(cgiGet( "Factura"), AV5Factura);
            /* Read saved values. */
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
            Dvpanel_unnamedtable3_Width = cgiGet( "DVPANEL_UNNAMEDTABLE3_Width");
            Dvpanel_unnamedtable3_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE3_Autowidth"));
            Dvpanel_unnamedtable3_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE3_Autoheight"));
            Dvpanel_unnamedtable3_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE3_Cls");
            Dvpanel_unnamedtable3_Title = cgiGet( "DVPANEL_UNNAMEDTABLE3_Title");
            Dvpanel_unnamedtable3_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE3_Collapsible"));
            Dvpanel_unnamedtable3_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE3_Collapsed"));
            Dvpanel_unnamedtable3_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE3_Showcollapseicon"));
            Dvpanel_unnamedtable3_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE3_Iconposition");
            Dvpanel_unnamedtable3_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE3_Autoscroll"));
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
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFactura_facturaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFactura_facturaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FACTURA_FACTURAID");
               GX_FocusControl = edtavFactura_facturaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Factura.gxTpr_Facturaid = 0;
            }
            else
            {
               AV5Factura.gxTpr_Facturaid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavFactura_facturaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV5Factura.gxTpr_Facturano = cgiGet( edtavFactura_facturano_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavFactura_facturafechafactura_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Factura Fecha Factura", "")}), 1, "FACTURA_FACTURAFECHAFACTURA");
               GX_FocusControl = edtavFactura_facturafechafactura_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Factura.gxTpr_Facturafechafactura = DateTime.MinValue;
            }
            else
            {
               AV5Factura.gxTpr_Facturafechafactura = context.localUtil.CToD( cgiGet( edtavFactura_facturafechafactura_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFactura_facturafecharegistro_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Factura Fecha Registro", "")}), 1, "FACTURA_FACTURAFECHAREGISTRO");
               GX_FocusControl = edtavFactura_facturafecharegistro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Factura.gxTpr_Facturafecharegistro = DateTime.MinValue;
            }
            else
            {
               AV5Factura.gxTpr_Facturafecharegistro = context.localUtil.CToD( cgiGet( edtavFactura_facturafecharegistro_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV5Factura.gxTpr_Usuarionombrecompleto = cgiGet( edtavFactura_usuarionombrecompleto_Internalname);
            cmbavFactura_usuariozona.CurrentValue = cgiGet( cmbavFactura_usuariozona_Internalname);
            AV5Factura.gxTpr_Usuariozona = cgiGet( cmbavFactura_usuariozona_Internalname);
            AV5Factura.gxTpr_Estadodescripcion = cgiGet( edtavFactura_estadodescripcion_Internalname);
            AV5Factura.gxTpr_Ciudaddescripcion = cgiGet( edtavFactura_ciudaddescripcion_Internalname);
            AV5Factura.gxTpr_Paisdescripcion = cgiGet( edtavFactura_paisdescripcion_Internalname);
            cmbavFactura_usuariogenero.CurrentValue = cgiGet( cmbavFactura_usuariogenero_Internalname);
            AV5Factura.gxTpr_Usuariogenero = cgiGet( cmbavFactura_usuariogenero_Internalname);
            AV5Factura.gxTpr_Facturapdf = cgiGet( edtavFactura_facturapdf_Internalname);
            cmbavFactura_facturaestatus.CurrentValue = cgiGet( cmbavFactura_facturaestatus_Internalname);
            AV5Factura.gxTpr_Facturaestatus = cgiGet( cmbavFactura_facturaestatus_Internalname);
            AV5Factura.gxTpr_Motivorechazodescripcion = cgiGet( edtavFactura_motivorechazodescripcion_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRECIO");
               GX_FocusControl = edtavPrecio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Precio = 0;
               AssignAttri("", false, "AV7Precio", StringUtil.LTrimStr( AV7Precio, 10, 2));
            }
            else
            {
               AV7Precio = context.localUtil.CToN( cgiGet( edtavPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV7Precio", StringUtil.LTrimStr( AV7Precio, 10, 2));
            }
            AV5Factura.gxTpr_Promociondescripcion = cgiGet( edtavFactura_promociondescripcion_Internalname);
            AV5Factura.gxTpr_Promocionvigencia = cgiGet( edtavFactura_promocionvigencia_Internalname);
            AV5Factura.gxTpr_Promocionbase = cgiGet( edtavFactura_promocionbase_Internalname);
            AV5Factura.gxTpr_Promocionarte = cgiGet( imgavFactura_promocionarte_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFactura_promocionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFactura_promocionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FACTURA_PROMOCIONID");
               GX_FocusControl = edtavFactura_promocionid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Factura.gxTpr_Promocionid = 0;
            }
            else
            {
               AV5Factura.gxTpr_Promocionid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavFactura_promocionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFactura_usuarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFactura_usuarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FACTURA_USUARIOID");
               GX_FocusControl = edtavFactura_usuarioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Factura.gxTpr_Usuarioid = 0;
            }
            else
            {
               AV5Factura.gxTpr_Usuarioid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavFactura_usuarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFactura_motivorechazoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFactura_motivorechazoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FACTURA_MOTIVORECHAZOID");
               GX_FocusControl = edtavFactura_motivorechazoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Factura.gxTpr_Motivorechazoid = 0;
            }
            else
            {
               AV5Factura.gxTpr_Motivorechazoid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavFactura_motivorechazoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV5Factura.gxTpr_Motivorechazoactivo = StringUtil.StrToBool( cgiGet( chkavFactura_motivorechazoactivo_Internalname));
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
         E113E2 ();
         if (returnInSub) return;
      }

      protected void E113E2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV5Factura.Load(AV6FacturaID);
         new obtienetotalpartidas(context ).execute(  AV6FacturaID, out  AV7Precio) ;
         AssignAttri("", false, "AV7Precio", StringUtil.LTrimStr( AV7Precio, 10, 2));
         edtavFactura_facturapdf_Tooltiptext = context.GetMessage( "Factura", "");
         AssignProp("", false, edtavFactura_facturapdf_Internalname, "Tooltiptext", edtavFactura_facturapdf_Tooltiptext, true);
         edtavFactura_promocionid_Visible = 0;
         AssignProp("", false, edtavFactura_promocionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFactura_promocionid_Visible), 5, 0), true);
         edtavFactura_usuarioid_Visible = 0;
         AssignProp("", false, edtavFactura_usuarioid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFactura_usuarioid_Visible), 5, 0), true);
         edtavFactura_motivorechazoid_Visible = 0;
         AssignProp("", false, edtavFactura_motivorechazoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFactura_motivorechazoid_Visible), 5, 0), true);
         chkavFactura_motivorechazoactivo.Visible = 0;
         AssignProp("", false, chkavFactura_motivorechazoactivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavFactura_motivorechazoactivo.Visible), 5, 0), true);
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwcpartidasfactura = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcpartidasfactura_Component), StringUtil.Lower( "WCPartidasFactura")) != 0 )
         {
            WebComp_Wcwcpartidasfactura = getWebComponent(GetType(), "GeneXus.Programs", "wcpartidasfactura", new Object[] {context} );
            WebComp_Wcwcpartidasfactura.ComponentInit();
            WebComp_Wcwcpartidasfactura.Name = "WCPartidasFactura";
            WebComp_Wcwcpartidasfactura_Component = "WCPartidasFactura";
         }
         if ( StringUtil.Len( WebComp_Wcwcpartidasfactura_Component) != 0 )
         {
            WebComp_Wcwcpartidasfactura.setjustcreated();
            WebComp_Wcwcpartidasfactura.componentprepare(new Object[] {(string)"W0111",(string)"",(int)AV6FacturaID});
            WebComp_Wcwcpartidasfactura.componentbind(new Object[] {(string)""});
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E123E2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6FacturaID = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV6FacturaID", StringUtil.LTrimStr( (decimal)(AV6FacturaID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vFACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6FacturaID), "ZZZZZZZZ9"), context));
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
         PA3E2( ) ;
         WS3E2( ) ;
         WE3E2( ) ;
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
         if ( ! ( WebComp_Wcwcpartidasfactura == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwcpartidasfactura_Component) != 0 )
            {
               WebComp_Wcwcpartidasfactura.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20265111131543", true, true);
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
         context.AddJavascriptSource("wpdetallefactura.js", "?20265111131543", false, true);
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
         cmbavFactura_usuariozona.Name = "FACTURA_USUARIOZONA";
         cmbavFactura_usuariozona.WebTags = "";
         cmbavFactura_usuariozona.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavFactura_usuariozona.addItem("Centro", context.GetMessage( "Centro", ""), 0);
         cmbavFactura_usuariozona.addItem("Centro América", context.GetMessage( "Centro América", ""), 0);
         cmbavFactura_usuariozona.addItem("Norte", context.GetMessage( "Norte", ""), 0);
         cmbavFactura_usuariozona.addItem("Pacífico", context.GetMessage( "Pacifico", ""), 0);
         cmbavFactura_usuariozona.addItem("Sur", context.GetMessage( "Sur", ""), 0);
         if ( cmbavFactura_usuariozona.ItemCount > 0 )
         {
            AV5Factura.gxTpr_Usuariozona = cmbavFactura_usuariozona.getValidValue(AV5Factura.gxTpr_Usuariozona);
         }
         cmbavFactura_usuariogenero.Name = "FACTURA_USUARIOGENERO";
         cmbavFactura_usuariogenero.WebTags = "";
         cmbavFactura_usuariogenero.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavFactura_usuariogenero.addItem("Masculino", context.GetMessage( "Masculino", ""), 0);
         cmbavFactura_usuariogenero.addItem("Femenino", context.GetMessage( "Femenino", ""), 0);
         if ( cmbavFactura_usuariogenero.ItemCount > 0 )
         {
            AV5Factura.gxTpr_Usuariogenero = cmbavFactura_usuariogenero.getValidValue(AV5Factura.gxTpr_Usuariogenero);
         }
         cmbavFactura_facturaestatus.Name = "FACTURA_FACTURAESTATUS";
         cmbavFactura_facturaestatus.WebTags = "";
         cmbavFactura_facturaestatus.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavFactura_facturaestatus.addItem("En Proceso", context.GetMessage( "En Proceso", ""), 0);
         cmbavFactura_facturaestatus.addItem("Aprobada", context.GetMessage( "Aprobada", ""), 0);
         cmbavFactura_facturaestatus.addItem("Rechazada", context.GetMessage( "Rechazada", ""), 0);
         cmbavFactura_facturaestatus.addItem("Cancelada", context.GetMessage( "Cancelada", ""), 0);
         if ( cmbavFactura_facturaestatus.ItemCount > 0 )
         {
            AV5Factura.gxTpr_Facturaestatus = cmbavFactura_facturaestatus.getValidValue(AV5Factura.gxTpr_Facturaestatus);
         }
         chkavFactura_motivorechazoactivo.Name = "FACTURA_MOTIVORECHAZOACTIVO";
         chkavFactura_motivorechazoactivo.WebTags = "";
         chkavFactura_motivorechazoactivo.Caption = "";
         AssignProp("", false, chkavFactura_motivorechazoactivo_Internalname, "TitleCaption", chkavFactura_motivorechazoactivo.Caption, true);
         chkavFactura_motivorechazoactivo.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavFactura_facturaid_Internalname = "FACTURA_FACTURAID";
         edtavFactura_facturano_Internalname = "FACTURA_FACTURANO";
         edtavFactura_facturafechafactura_Internalname = "FACTURA_FACTURAFECHAFACTURA";
         edtavFactura_facturafecharegistro_Internalname = "FACTURA_FACTURAFECHAREGISTRO";
         edtavFactura_usuarionombrecompleto_Internalname = "FACTURA_USUARIONOMBRECOMPLETO";
         cmbavFactura_usuariozona_Internalname = "FACTURA_USUARIOZONA";
         edtavFactura_estadodescripcion_Internalname = "FACTURA_ESTADODESCRIPCION";
         edtavFactura_ciudaddescripcion_Internalname = "FACTURA_CIUDADDESCRIPCION";
         edtavFactura_paisdescripcion_Internalname = "FACTURA_PAISDESCRIPCION";
         cmbavFactura_usuariogenero_Internalname = "FACTURA_USUARIOGENERO";
         edtavFactura_facturapdf_Internalname = "FACTURA_FACTURAPDF";
         cmbavFactura_facturaestatus_Internalname = "FACTURA_FACTURAESTATUS";
         edtavFactura_motivorechazodescripcion_Internalname = "FACTURA_MOTIVORECHAZODESCRIPCION";
         edtavPrecio_Internalname = "vPRECIO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         edtavFactura_promociondescripcion_Internalname = "FACTURA_PROMOCIONDESCRIPCION";
         edtavFactura_promocionvigencia_Internalname = "FACTURA_PROMOCIONVIGENCIA";
         edtavFactura_promocionbase_Internalname = "FACTURA_PROMOCIONBASE";
         imgavFactura_promocionarte_Internalname = "FACTURA_PROMOCIONARTE";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         Dvpanel_unnamedtable3_Internalname = "DVPANEL_UNNAMEDTABLE3";
         divTablecontent_Internalname = "TABLECONTENT";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         Dvpanel_unnamedtable2_Internalname = "DVPANEL_UNNAMEDTABLE2";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablemain_Internalname = "TABLEMAIN";
         edtavFactura_promocionid_Internalname = "FACTURA_PROMOCIONID";
         edtavFactura_usuarioid_Internalname = "FACTURA_USUARIOID";
         edtavFactura_motivorechazoid_Internalname = "FACTURA_MOTIVORECHAZOID";
         chkavFactura_motivorechazoactivo_Internalname = "FACTURA_MOTIVORECHAZOACTIVO";
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
         chkavFactura_motivorechazoactivo.Caption = "";
         edtavFactura_facturapdf_Tooltiptext = "";
         edtavFactura_promocionbase_Enabled = -1;
         edtavFactura_promocionvigencia_Enabled = -1;
         edtavFactura_promociondescripcion_Enabled = -1;
         edtavFactura_motivorechazodescripcion_Enabled = -1;
         cmbavFactura_facturaestatus.Enabled = -1;
         edtavFactura_facturapdf_Enabled = -1;
         cmbavFactura_usuariogenero.Enabled = -1;
         edtavFactura_paisdescripcion_Enabled = -1;
         edtavFactura_ciudaddescripcion_Enabled = -1;
         edtavFactura_estadodescripcion_Enabled = -1;
         cmbavFactura_usuariozona.Enabled = -1;
         edtavFactura_usuarionombrecompleto_Enabled = -1;
         edtavFactura_facturafecharegistro_Enabled = -1;
         edtavFactura_facturafechafactura_Enabled = -1;
         edtavFactura_facturano_Enabled = -1;
         edtavFactura_facturaid_Enabled = -1;
         chkavFactura_motivorechazoactivo.Visible = 1;
         edtavFactura_motivorechazoid_Jsonclick = "";
         edtavFactura_motivorechazoid_Visible = 1;
         edtavFactura_usuarioid_Jsonclick = "";
         edtavFactura_usuarioid_Visible = 1;
         edtavFactura_promocionid_Jsonclick = "";
         edtavFactura_promocionid_Visible = 1;
         imgavFactura_promocionarte_gximage = "";
         edtavFactura_promocionbase_Enabled = 0;
         edtavFactura_promocionvigencia_Jsonclick = "";
         edtavFactura_promocionvigencia_Enabled = 0;
         edtavFactura_promociondescripcion_Jsonclick = "";
         edtavFactura_promociondescripcion_Enabled = 0;
         edtavPrecio_Jsonclick = "";
         edtavPrecio_Enabled = 1;
         edtavFactura_motivorechazodescripcion_Jsonclick = "";
         edtavFactura_motivorechazodescripcion_Enabled = 0;
         cmbavFactura_facturaestatus_Jsonclick = "";
         cmbavFactura_facturaestatus.Enabled = 0;
         edtavFactura_facturapdf_Filename = "";
         edtavFactura_facturapdf_Enabled = 0;
         cmbavFactura_usuariogenero_Jsonclick = "";
         cmbavFactura_usuariogenero.Enabled = 0;
         edtavFactura_paisdescripcion_Jsonclick = "";
         edtavFactura_paisdescripcion_Enabled = 0;
         edtavFactura_ciudaddescripcion_Jsonclick = "";
         edtavFactura_ciudaddescripcion_Enabled = 0;
         edtavFactura_estadodescripcion_Jsonclick = "";
         edtavFactura_estadodescripcion_Enabled = 0;
         cmbavFactura_usuariozona_Jsonclick = "";
         cmbavFactura_usuariozona.Enabled = 0;
         edtavFactura_usuarionombrecompleto_Jsonclick = "";
         edtavFactura_usuarionombrecompleto_Enabled = 0;
         edtavFactura_facturafecharegistro_Jsonclick = "";
         edtavFactura_facturafecharegistro_Enabled = 0;
         edtavFactura_facturafechafactura_Jsonclick = "";
         edtavFactura_facturafechafactura_Enabled = 0;
         edtavFactura_facturano_Jsonclick = "";
         edtavFactura_facturano_Enabled = 0;
         edtavFactura_facturaid_Jsonclick = "";
         edtavFactura_facturaid_Enabled = 0;
         Dvpanel_unnamedtable2_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Iconposition = "Right";
         Dvpanel_unnamedtable2_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Title = context.GetMessage( "Partidas", "");
         Dvpanel_unnamedtable2_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable2_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable2_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Width = "100%";
         Dvpanel_unnamedtable3_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Iconposition = "Right";
         Dvpanel_unnamedtable3_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Title = context.GetMessage( "Promoción", "");
         Dvpanel_unnamedtable3_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable3_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable3_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Width = "100%";
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = context.GetMessage( "WWP_TemplateDataPanelTitle", "");
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "WPDetalle Factura", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GXV21","fld":"FACTURA_MOTIVORECHAZOACTIVO"},{"av":"AV6FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("VALIDV_GXV6","""{"handler":"Validv_Gxv6","iparms":[]}""");
         setEventMetadata("VALIDV_GXV10","""{"handler":"Validv_Gxv10","iparms":[]}""");
         setEventMetadata("VALIDV_GXV12","""{"handler":"Validv_Gxv12","iparms":[]}""");
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
         AV5Factura = new SdtFactura(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         ucDvpanel_unnamedtable3 = new GXUserControl();
         sImgUrl = "";
         ucDvpanel_unnamedtable2 = new GXUserControl();
         WebComp_Wcwcpartidasfactura_Component = "";
         OldWcwcpartidasfactura = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         WebComp_Wcwcpartidasfactura = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavFactura_facturaid_Enabled = 0;
         edtavFactura_facturano_Enabled = 0;
         edtavFactura_facturafechafactura_Enabled = 0;
         edtavFactura_facturafecharegistro_Enabled = 0;
         edtavFactura_usuarionombrecompleto_Enabled = 0;
         cmbavFactura_usuariozona.Enabled = 0;
         edtavFactura_estadodescripcion_Enabled = 0;
         edtavFactura_ciudaddescripcion_Enabled = 0;
         edtavFactura_paisdescripcion_Enabled = 0;
         cmbavFactura_usuariogenero.Enabled = 0;
         edtavFactura_facturapdf_Enabled = 0;
         cmbavFactura_facturaestatus.Enabled = 0;
         edtavFactura_motivorechazodescripcion_Enabled = 0;
         edtavPrecio_Enabled = 0;
         edtavFactura_promociondescripcion_Enabled = 0;
         edtavFactura_promocionvigencia_Enabled = 0;
         edtavFactura_promocionbase_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV6FacturaID ;
      private int wcpOAV6FacturaID ;
      private int edtavFactura_facturaid_Enabled ;
      private int edtavFactura_facturano_Enabled ;
      private int edtavFactura_facturafechafactura_Enabled ;
      private int edtavFactura_facturafecharegistro_Enabled ;
      private int edtavFactura_usuarionombrecompleto_Enabled ;
      private int edtavFactura_estadodescripcion_Enabled ;
      private int edtavFactura_ciudaddescripcion_Enabled ;
      private int edtavFactura_paisdescripcion_Enabled ;
      private int edtavFactura_facturapdf_Enabled ;
      private int edtavFactura_motivorechazodescripcion_Enabled ;
      private int edtavPrecio_Enabled ;
      private int edtavFactura_promociondescripcion_Enabled ;
      private int edtavFactura_promocionvigencia_Enabled ;
      private int edtavFactura_promocionbase_Enabled ;
      private int edtavFactura_promocionid_Visible ;
      private int edtavFactura_usuarioid_Visible ;
      private int edtavFactura_motivorechazoid_Visible ;
      private int idxLst ;
      private decimal AV7Precio ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_unnamedtable3_Width ;
      private string Dvpanel_unnamedtable3_Cls ;
      private string Dvpanel_unnamedtable3_Title ;
      private string Dvpanel_unnamedtable3_Iconposition ;
      private string Dvpanel_unnamedtable2_Width ;
      private string Dvpanel_unnamedtable2_Cls ;
      private string Dvpanel_unnamedtable2_Title ;
      private string Dvpanel_unnamedtable2_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavFactura_facturaid_Internalname ;
      private string TempTags ;
      private string edtavFactura_facturaid_Jsonclick ;
      private string edtavFactura_facturano_Internalname ;
      private string edtavFactura_facturano_Jsonclick ;
      private string edtavFactura_facturafechafactura_Internalname ;
      private string edtavFactura_facturafechafactura_Jsonclick ;
      private string edtavFactura_facturafecharegistro_Internalname ;
      private string edtavFactura_facturafecharegistro_Jsonclick ;
      private string edtavFactura_usuarionombrecompleto_Internalname ;
      private string edtavFactura_usuarionombrecompleto_Jsonclick ;
      private string cmbavFactura_usuariozona_Internalname ;
      private string cmbavFactura_usuariozona_Jsonclick ;
      private string edtavFactura_estadodescripcion_Internalname ;
      private string edtavFactura_estadodescripcion_Jsonclick ;
      private string edtavFactura_ciudaddescripcion_Internalname ;
      private string edtavFactura_ciudaddescripcion_Jsonclick ;
      private string edtavFactura_paisdescripcion_Internalname ;
      private string edtavFactura_paisdescripcion_Jsonclick ;
      private string cmbavFactura_usuariogenero_Internalname ;
      private string cmbavFactura_usuariogenero_Jsonclick ;
      private string edtavFactura_facturapdf_Internalname ;
      private string edtavFactura_facturapdf_Filename ;
      private string cmbavFactura_facturaestatus_Internalname ;
      private string cmbavFactura_facturaestatus_Jsonclick ;
      private string edtavFactura_motivorechazodescripcion_Internalname ;
      private string edtavFactura_motivorechazodescripcion_Jsonclick ;
      private string edtavPrecio_Internalname ;
      private string edtavPrecio_Jsonclick ;
      private string Dvpanel_unnamedtable3_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtavFactura_promociondescripcion_Internalname ;
      private string edtavFactura_promociondescripcion_Jsonclick ;
      private string edtavFactura_promocionvigencia_Internalname ;
      private string edtavFactura_promocionvigencia_Jsonclick ;
      private string edtavFactura_promocionbase_Internalname ;
      private string imgavFactura_promocionarte_Internalname ;
      private string imgavFactura_promocionarte_gximage ;
      private string sImgUrl ;
      private string divUnnamedtable1_Internalname ;
      private string Dvpanel_unnamedtable2_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string WebComp_Wcwcpartidasfactura_Component ;
      private string OldWcwcpartidasfactura ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavFactura_promocionid_Internalname ;
      private string edtavFactura_promocionid_Jsonclick ;
      private string edtavFactura_usuarioid_Internalname ;
      private string edtavFactura_usuarioid_Jsonclick ;
      private string edtavFactura_motivorechazoid_Internalname ;
      private string edtavFactura_motivorechazoid_Jsonclick ;
      private string chkavFactura_motivorechazoactivo_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string edtavFactura_facturapdf_Tooltiptext ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_unnamedtable3_Autowidth ;
      private bool Dvpanel_unnamedtable3_Autoheight ;
      private bool Dvpanel_unnamedtable3_Collapsible ;
      private bool Dvpanel_unnamedtable3_Collapsed ;
      private bool Dvpanel_unnamedtable3_Showcollapseicon ;
      private bool Dvpanel_unnamedtable3_Autoscroll ;
      private bool Dvpanel_unnamedtable2_Autowidth ;
      private bool Dvpanel_unnamedtable2_Autoheight ;
      private bool Dvpanel_unnamedtable2_Collapsible ;
      private bool Dvpanel_unnamedtable2_Collapsed ;
      private bool Dvpanel_unnamedtable2_Showcollapseicon ;
      private bool Dvpanel_unnamedtable2_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcwcpartidasfactura ;
      private GXWebComponent WebComp_Wcwcpartidasfactura ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucDvpanel_unnamedtable3 ;
      private GXUserControl ucDvpanel_unnamedtable2 ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavFactura_usuariozona ;
      private GXCombobox cmbavFactura_usuariogenero ;
      private GXCombobox cmbavFactura_facturaestatus ;
      private GXCheckbox chkavFactura_motivorechazoactivo ;
      private SdtFactura AV5Factura ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
