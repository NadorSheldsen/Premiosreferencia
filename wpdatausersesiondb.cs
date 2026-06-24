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
   public class wpdatausersesiondb : GXDataArea
   {
      public wpdatausersesiondb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpdatausersesiondb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_UsuarioID )
      {
         this.AV15UsuarioID = aP0_UsuarioID;
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
         chkavUsuario_usuarioavisoprivacidad = new GXCheckbox();
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
         PA522( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START522( ) ;
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
         GXEncryptionTmp = "wpdatausersesiondb.aspx"+UrlEncode(StringUtil.LTrimStr(AV15UsuarioID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpdatausersesiondb.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV11TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15UsuarioID), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Usuario", AV8Usuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Usuario", AV8Usuario);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV11TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15UsuarioID), "ZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIO", AV8Usuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIO", AV8Usuario);
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
            WE522( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT522( ) ;
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
         GXEncryptionTmp = "wpdatausersesiondb.aspx"+UrlEncode(StringUtil.LTrimStr(AV15UsuarioID,9,0));
         return formatLink("wpdatausersesiondb.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WPDataUserSesionDB" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WPData User Sesion DB", "") ;
      }

      protected void WB520( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarioid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarioid_Internalname, context.GetMessage( "ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Usuario.gxTpr_Usuarioid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavUsuario_usuarioid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8Usuario.gxTpr_Usuarioid), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8Usuario.gxTpr_Usuarioid), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarioid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarioid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarionombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarionombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarionombre_Internalname, StringUtil.RTrim( AV8Usuario.gxTpr_Usuarionombre), StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Usuarionombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarionombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarionombre_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarioapellido_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarioapellido_Internalname, context.GetMessage( "Apellido(s)", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarioapellido_Internalname, StringUtil.RTrim( AV8Usuario.gxTpr_Usuarioapellido), StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Usuarioapellido, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarioapellido_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarioapellido_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarionombrecompleto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarionombrecompleto_Internalname, context.GetMessage( "Nombre completo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarionombrecompleto_Internalname, AV8Usuario.gxTpr_Usuarionombrecompleto, StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Usuarionombrecompleto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarionombrecompleto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarionombrecompleto_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocorreo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocorreo_Internalname, context.GetMessage( "Correo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocorreo_Internalname, AV8Usuario.gxTpr_Usuariocorreo, StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Usuariocorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocorreo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocorreo_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariopass_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariopass_Internalname, context.GetMessage( "Pass", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariopass_Internalname, AV8Usuario.gxTpr_Usuariopass, StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Usuariopass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariopass_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariopass_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariokey_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariokey_Internalname, context.GetMessage( "Key", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariokey_Internalname, AV8Usuario.gxTpr_Usuariokey, StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Usuariokey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariokey_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariokey_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_puestoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_puestoid_Internalname, context.GetMessage( "Puesto ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_puestoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Usuario.gxTpr_Puestoid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8Usuario.gxTpr_Puestoid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_puestoid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_puestoid_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_puestodescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_puestodescripcion_Internalname, context.GetMessage( "Puesto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_puestodescripcion_Internalname, AV8Usuario.gxTpr_Puestodescripcion, StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Puestodescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_puestodescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_puestodescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuariogenero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuariogenero_Internalname, context.GetMessage( "Género", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariogenero, cmbavUsuario_usuariogenero_Internalname, StringUtil.RTrim( AV8Usuario.gxTpr_Usuariogenero), 1, cmbavUsuario_usuariogenero_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUsuario_usuariogenero.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "", true, 0, "HLP_WPDataUserSesionDB.htm");
            cmbavUsuario_usuariogenero.CurrentValue = StringUtil.RTrim( AV8Usuario.gxTpr_Usuariogenero);
            AssignProp("", false, cmbavUsuario_usuariogenero_Internalname, "Values", (string)(cmbavUsuario_usuariogenero.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuariodirectoasociado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuariodirectoasociado_Internalname, context.GetMessage( "Directo/Asociado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariodirectoasociado, cmbavUsuario_usuariodirectoasociado_Internalname, StringUtil.RTrim( AV8Usuario.gxTpr_Usuariodirectoasociado), 1, cmbavUsuario_usuariodirectoasociado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUsuario_usuariodirectoasociado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "", true, 0, "HLP_WPDataUserSesionDB.htm");
            cmbavUsuario_usuariodirectoasociado.CurrentValue = StringUtil.RTrim( AV8Usuario.gxTpr_Usuariodirectoasociado);
            AssignProp("", false, cmbavUsuario_usuariodirectoasociado_Internalname, "Values", (string)(cmbavUsuario_usuariodirectoasociado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariorazonsocialasociado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariorazonsocialasociado_Internalname, context.GetMessage( "Razón Social Asociado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariorazonsocialasociado_Internalname, AV8Usuario.gxTpr_Usuariorazonsocialasociado, StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Usuariorazonsocialasociado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariorazonsocialasociado_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariorazonsocialasociado_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarionombrecomercial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarionombrecomercial_Internalname, context.GetMessage( "Nombre Comercial", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarionombrecomercial_Internalname, AV8Usuario.gxTpr_Usuarionombrecomercial, StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Usuarionombrecomercial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarionombrecomercial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarionombrecomercial_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariofechanacimiento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariofechanacimiento_Internalname, context.GetMessage( "Fecha de nacimiento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavUsuario_usuariofechanacimiento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariofechanacimiento_Internalname, context.localUtil.Format(AV8Usuario.gxTpr_Usuariofechanacimiento, "99/99/9999"), context.localUtil.Format( AV8Usuario.gxTpr_Usuariofechanacimiento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariofechanacimiento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariofechanacimiento_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_bitmap( context, edtavUsuario_usuariofechanacimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavUsuario_usuariofechanacimiento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPDataUserSesionDB.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocallenum_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocallenum_Internalname, context.GetMessage( "Calle y número", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocallenum_Internalname, StringUtil.RTrim( AV8Usuario.gxTpr_Usuariocallenum), StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Usuariocallenum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocallenum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocallenum_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocolonia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocolonia_Internalname, context.GetMessage( "Colonia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocolonia_Internalname, StringUtil.RTrim( AV8Usuario.gxTpr_Usuariocolonia), StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Usuariocolonia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocolonia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocolonia_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariodelegacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariodelegacion_Internalname, context.GetMessage( "Delegación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariodelegacion_Internalname, StringUtil.RTrim( AV8Usuario.gxTpr_Usuariodelegacion), StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Usuariodelegacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariodelegacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariodelegacion_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocp_Internalname, context.GetMessage( "Código Postal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Usuario.gxTpr_Usuariocp), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8Usuario.gxTpr_Usuariocp), "ZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,107);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocp_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocp_Enabled, 1, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuariozona_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuariozona_Internalname, context.GetMessage( "Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariozona, cmbavUsuario_usuariozona_Internalname, StringUtil.RTrim( AV8Usuario.gxTpr_Usuariozona), 1, cmbavUsuario_usuariozona_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUsuario_usuariozona.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "", true, 0, "HLP_WPDataUserSesionDB.htm");
            cmbavUsuario_usuariozona.CurrentValue = StringUtil.RTrim( AV8Usuario.gxTpr_Usuariozona);
            AssignProp("", false, cmbavUsuario_usuariozona_Internalname, "Values", (string)(cmbavUsuario_usuariozona.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocelular_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocelular_Internalname, context.GetMessage( "Celular", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocelular_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Usuario.gxTpr_Usuariocelular), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8Usuario.gxTpr_Usuariocelular), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocelular_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocelular_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariotelefonosucursal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariotelefonosucursal_Internalname, context.GetMessage( "Teléfono Sucursal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariotelefonosucursal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Usuario.gxTpr_Usuariotelefonosucursal), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8Usuario.gxTpr_Usuariotelefonosucursal), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,122);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariotelefonosucursal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariotelefonosucursal_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_paisid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_paisid_Internalname, context.GetMessage( "Pais ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_paisid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Usuario.gxTpr_Paisid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavUsuario_paisid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8Usuario.gxTpr_Paisid), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8Usuario.gxTpr_Paisid), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_paisid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_paisid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_paisdescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_paisdescripcion_Internalname, context.GetMessage( "País", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_paisdescripcion_Internalname, AV8Usuario.gxTpr_Paisdescripcion, StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Paisdescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,132);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_paisdescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_paisdescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_estadoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_estadoid_Internalname, context.GetMessage( "Estado ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_estadoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Usuario.gxTpr_Estadoid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavUsuario_estadoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8Usuario.gxTpr_Estadoid), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8Usuario.gxTpr_Estadoid), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,137);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_estadoid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_estadoid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_estadodescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_estadodescripcion_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_estadodescripcion_Internalname, AV8Usuario.gxTpr_Estadodescripcion, StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Estadodescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,142);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_estadodescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_estadodescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_ciudadid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_ciudadid_Internalname, context.GetMessage( "Ciudad ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_ciudadid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Usuario.gxTpr_Ciudadid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8Usuario.gxTpr_Ciudadid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,147);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_ciudadid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_ciudadid_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_ciudaddescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_ciudaddescripcion_Internalname, context.GetMessage( "Ciudad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_ciudaddescripcion_Internalname, AV8Usuario.gxTpr_Ciudaddescripcion, StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Ciudaddescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,152);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_ciudaddescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_ciudaddescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariosucursal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariosucursal_Internalname, context.GetMessage( "Sucursal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariosucursal_Internalname, StringUtil.RTrim( AV8Usuario.gxTpr_Usuariosucursal), StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Usuariosucursal, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariosucursal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariosucursal_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuarioproducto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuarioproducto_Internalname, context.GetMessage( "Producto que vendes", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuarioproducto, cmbavUsuario_usuarioproducto_Internalname, StringUtil.RTrim( AV8Usuario.gxTpr_Usuarioproducto), 1, cmbavUsuario_usuarioproducto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavUsuario_usuarioproducto.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,162);\"", "", true, 0, "HLP_WPDataUserSesionDB.htm");
            cmbavUsuario_usuarioproducto.CurrentValue = StringUtil.RTrim( AV8Usuario.gxTpr_Usuarioproducto);
            AssignProp("", false, cmbavUsuario_usuarioproducto_Internalname, "Values", (string)(cmbavUsuario_usuarioproducto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuariorol_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuariorol_Internalname, context.GetMessage( "Rol", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariorol, cmbavUsuario_usuariorol_Internalname, StringUtil.RTrim( AV8Usuario.gxTpr_Usuariorol), 1, cmbavUsuario_usuariorol_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUsuario_usuariorol.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,167);\"", "", true, 0, "HLP_WPDataUserSesionDB.htm");
            cmbavUsuario_usuariorol.CurrentValue = StringUtil.RTrim( AV8Usuario.gxTpr_Usuariorol);
            AssignProp("", false, cmbavUsuario_usuariorol_Internalname, "Values", (string)(cmbavUsuario_usuariorol.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarionocuentabroxel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarionocuentabroxel_Internalname, context.GetMessage( "Cuenta BROXEL", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarionocuentabroxel_Internalname, StringUtil.RTrim( AV8Usuario.gxTpr_Usuarionocuentabroxel), StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Usuarionocuentabroxel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,172);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarionocuentabroxel_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarionocuentabroxel_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarioreferenciabroxel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarioreferenciabroxel_Internalname, context.GetMessage( "Referencia BROXEL", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarioreferenciabroxel_Internalname, StringUtil.RTrim( AV8Usuario.gxTpr_Usuarioreferenciabroxel), StringUtil.RTrim( context.localUtil.Format( AV8Usuario.gxTpr_Usuarioreferenciabroxel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,177);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarioreferenciabroxel_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarioreferenciabroxel_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariofecharegistro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariofecharegistro_Internalname, context.GetMessage( "Fecha Registro", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 182,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavUsuario_usuariofecharegistro_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariofecharegistro_Internalname, context.localUtil.Format(AV8Usuario.gxTpr_Usuariofecharegistro, "99/99/99"), context.localUtil.Format( AV8Usuario.gxTpr_Usuariofecharegistro, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,182);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariofecharegistro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariofecharegistro_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_bitmap( context, edtavUsuario_usuariofecharegistro_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavUsuario_usuariofecharegistro_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPDataUserSesionDB.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavUsuario_usuarioavisoprivacidad_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUsuario_usuarioavisoprivacidad_Internalname, context.GetMessage( "de Privacidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 187,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUsuario_usuarioavisoprivacidad_Internalname, StringUtil.BoolToStr( AV8Usuario.gxTpr_Usuarioavisoprivacidad), "", context.GetMessage( "de Privacidad", ""), 1, chkavUsuario_usuarioavisoprivacidad.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(187, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,187);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 192,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPDataUserSesionDB.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPDataUserSesionDB.htm");
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

      protected void START522( )
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
         Form.Meta.addItem("description", context.GetMessage( "WPData User Sesion DB", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP520( ) ;
      }

      protected void WS522( )
      {
         START522( ) ;
         EVT522( ) ;
      }

      protected void EVT522( )
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
                              E11522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E12522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13522 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE522( )
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

      protected void PA522( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpdatausersesiondb.aspx")), "wpdatausersesiondb.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpdatausersesiondb.aspx")))) ;
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
                     AV15UsuarioID = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV15UsuarioID", StringUtil.LTrimStr( (decimal)(AV15UsuarioID), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15UsuarioID), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavUsuario_usuarioid_Internalname;
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
            AV8Usuario.gxTpr_Usuariogenero = cmbavUsuario_usuariogenero.getValidValue(AV8Usuario.gxTpr_Usuariogenero);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuariogenero.CurrentValue = StringUtil.RTrim( AV8Usuario.gxTpr_Usuariogenero);
            AssignProp("", false, cmbavUsuario_usuariogenero_Internalname, "Values", cmbavUsuario_usuariogenero.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuariodirectoasociado.ItemCount > 0 )
         {
            AV8Usuario.gxTpr_Usuariodirectoasociado = cmbavUsuario_usuariodirectoasociado.getValidValue(AV8Usuario.gxTpr_Usuariodirectoasociado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuariodirectoasociado.CurrentValue = StringUtil.RTrim( AV8Usuario.gxTpr_Usuariodirectoasociado);
            AssignProp("", false, cmbavUsuario_usuariodirectoasociado_Internalname, "Values", cmbavUsuario_usuariodirectoasociado.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuariozona.ItemCount > 0 )
         {
            AV8Usuario.gxTpr_Usuariozona = cmbavUsuario_usuariozona.getValidValue(AV8Usuario.gxTpr_Usuariozona);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuariozona.CurrentValue = StringUtil.RTrim( AV8Usuario.gxTpr_Usuariozona);
            AssignProp("", false, cmbavUsuario_usuariozona_Internalname, "Values", cmbavUsuario_usuariozona.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuarioproducto.ItemCount > 0 )
         {
            AV8Usuario.gxTpr_Usuarioproducto = cmbavUsuario_usuarioproducto.getValidValue(AV8Usuario.gxTpr_Usuarioproducto);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuarioproducto.CurrentValue = StringUtil.RTrim( AV8Usuario.gxTpr_Usuarioproducto);
            AssignProp("", false, cmbavUsuario_usuarioproducto_Internalname, "Values", cmbavUsuario_usuarioproducto.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuariorol.ItemCount > 0 )
         {
            AV8Usuario.gxTpr_Usuariorol = cmbavUsuario_usuariorol.getValidValue(AV8Usuario.gxTpr_Usuariorol);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuariorol.CurrentValue = StringUtil.RTrim( AV8Usuario.gxTpr_Usuariorol);
            AssignProp("", false, cmbavUsuario_usuariorol_Internalname, "Values", cmbavUsuario_usuariorol.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF522( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavUsuario_usuarioid_Enabled = 0;
         AssignProp("", false, edtavUsuario_usuarioid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarioid_Enabled), 5, 0), true);
         edtavUsuario_usuarionombrecompleto_Enabled = 0;
         AssignProp("", false, edtavUsuario_usuarionombrecompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarionombrecompleto_Enabled), 5, 0), true);
         edtavUsuario_puestodescripcion_Enabled = 0;
         AssignProp("", false, edtavUsuario_puestodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_puestodescripcion_Enabled), 5, 0), true);
         edtavUsuario_paisid_Enabled = 0;
         AssignProp("", false, edtavUsuario_paisid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_paisid_Enabled), 5, 0), true);
         edtavUsuario_paisdescripcion_Enabled = 0;
         AssignProp("", false, edtavUsuario_paisdescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_paisdescripcion_Enabled), 5, 0), true);
         edtavUsuario_estadoid_Enabled = 0;
         AssignProp("", false, edtavUsuario_estadoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_estadoid_Enabled), 5, 0), true);
         edtavUsuario_estadodescripcion_Enabled = 0;
         AssignProp("", false, edtavUsuario_estadodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_estadodescripcion_Enabled), 5, 0), true);
         edtavUsuario_ciudaddescripcion_Enabled = 0;
         AssignProp("", false, edtavUsuario_ciudaddescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_ciudaddescripcion_Enabled), 5, 0), true);
      }

      protected void RF522( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E12522 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13522 ();
            WB520( ) ;
         }
      }

      protected void send_integrity_lvl_hashes522( )
      {
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV11TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
      }

      protected void before_start_formulas( )
      {
         edtavUsuario_usuarioid_Enabled = 0;
         AssignProp("", false, edtavUsuario_usuarioid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarioid_Enabled), 5, 0), true);
         edtavUsuario_usuarionombrecompleto_Enabled = 0;
         AssignProp("", false, edtavUsuario_usuarionombrecompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarionombrecompleto_Enabled), 5, 0), true);
         edtavUsuario_puestodescripcion_Enabled = 0;
         AssignProp("", false, edtavUsuario_puestodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_puestodescripcion_Enabled), 5, 0), true);
         edtavUsuario_paisid_Enabled = 0;
         AssignProp("", false, edtavUsuario_paisid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_paisid_Enabled), 5, 0), true);
         edtavUsuario_paisdescripcion_Enabled = 0;
         AssignProp("", false, edtavUsuario_paisdescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_paisdescripcion_Enabled), 5, 0), true);
         edtavUsuario_estadoid_Enabled = 0;
         AssignProp("", false, edtavUsuario_estadoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_estadoid_Enabled), 5, 0), true);
         edtavUsuario_estadodescripcion_Enabled = 0;
         AssignProp("", false, edtavUsuario_estadodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_estadodescripcion_Enabled), 5, 0), true);
         edtavUsuario_ciudaddescripcion_Enabled = 0;
         AssignProp("", false, edtavUsuario_ciudaddescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_ciudaddescripcion_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP520( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11522 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vUSUARIO"), AV8Usuario);
            ajax_req_read_hidden_sdt(cgiGet( "Usuario"), AV8Usuario);
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
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_USUARIOID");
               GX_FocusControl = edtavUsuario_usuarioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8Usuario.gxTpr_Usuarioid = 0;
            }
            else
            {
               AV8Usuario.gxTpr_Usuarioid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_usuarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV8Usuario.gxTpr_Usuarionombre = cgiGet( edtavUsuario_usuarionombre_Internalname);
            AV8Usuario.gxTpr_Usuarioapellido = cgiGet( edtavUsuario_usuarioapellido_Internalname);
            AV8Usuario.gxTpr_Usuarionombrecompleto = cgiGet( edtavUsuario_usuarionombrecompleto_Internalname);
            AV8Usuario.gxTpr_Usuariocorreo = cgiGet( edtavUsuario_usuariocorreo_Internalname);
            AV8Usuario.gxTpr_Usuariopass = cgiGet( edtavUsuario_usuariopass_Internalname);
            AV8Usuario.gxTpr_Usuariokey = cgiGet( edtavUsuario_usuariokey_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_puestoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_puestoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_PUESTOID");
               GX_FocusControl = edtavUsuario_puestoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8Usuario.gxTpr_Puestoid = 0;
            }
            else
            {
               AV8Usuario.gxTpr_Puestoid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_puestoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV8Usuario.gxTpr_Puestodescripcion = cgiGet( edtavUsuario_puestodescripcion_Internalname);
            cmbavUsuario_usuariogenero.CurrentValue = cgiGet( cmbavUsuario_usuariogenero_Internalname);
            AV8Usuario.gxTpr_Usuariogenero = cgiGet( cmbavUsuario_usuariogenero_Internalname);
            cmbavUsuario_usuariodirectoasociado.CurrentValue = cgiGet( cmbavUsuario_usuariodirectoasociado_Internalname);
            AV8Usuario.gxTpr_Usuariodirectoasociado = cgiGet( cmbavUsuario_usuariodirectoasociado_Internalname);
            AV8Usuario.gxTpr_Usuariorazonsocialasociado = cgiGet( edtavUsuario_usuariorazonsocialasociado_Internalname);
            AV8Usuario.gxTpr_Usuarionombrecomercial = cgiGet( edtavUsuario_usuarionombrecomercial_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavUsuario_usuariofechanacimiento_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha de nacimiento", "")}), 1, "USUARIO_USUARIOFECHANACIMIENTO");
               GX_FocusControl = edtavUsuario_usuariofechanacimiento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8Usuario.gxTpr_Usuariofechanacimiento = DateTime.MinValue;
            }
            else
            {
               AV8Usuario.gxTpr_Usuariofechanacimiento = context.localUtil.CToD( cgiGet( edtavUsuario_usuariofechanacimiento_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV8Usuario.gxTpr_Usuariocallenum = cgiGet( edtavUsuario_usuariocallenum_Internalname);
            AV8Usuario.gxTpr_Usuariocolonia = cgiGet( edtavUsuario_usuariocolonia_Internalname);
            AV8Usuario.gxTpr_Usuariodelegacion = cgiGet( edtavUsuario_usuariodelegacion_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariocp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariocp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_USUARIOCP");
               GX_FocusControl = edtavUsuario_usuariocp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8Usuario.gxTpr_Usuariocp = 0;
            }
            else
            {
               AV8Usuario.gxTpr_Usuariocp = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_usuariocp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            cmbavUsuario_usuariozona.CurrentValue = cgiGet( cmbavUsuario_usuariozona_Internalname);
            AV8Usuario.gxTpr_Usuariozona = cgiGet( cmbavUsuario_usuariozona_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariocelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariocelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_USUARIOCELULAR");
               GX_FocusControl = edtavUsuario_usuariocelular_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8Usuario.gxTpr_Usuariocelular = 0;
            }
            else
            {
               AV8Usuario.gxTpr_Usuariocelular = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_usuariocelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariotelefonosucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariotelefonosucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_USUARIOTELEFONOSUCURSAL");
               GX_FocusControl = edtavUsuario_usuariotelefonosucursal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8Usuario.gxTpr_Usuariotelefonosucursal = 0;
            }
            else
            {
               AV8Usuario.gxTpr_Usuariotelefonosucursal = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_usuariotelefonosucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_paisid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_paisid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_PAISID");
               GX_FocusControl = edtavUsuario_paisid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8Usuario.gxTpr_Paisid = 0;
            }
            else
            {
               AV8Usuario.gxTpr_Paisid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_paisid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV8Usuario.gxTpr_Paisdescripcion = cgiGet( edtavUsuario_paisdescripcion_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_estadoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_estadoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_ESTADOID");
               GX_FocusControl = edtavUsuario_estadoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8Usuario.gxTpr_Estadoid = 0;
            }
            else
            {
               AV8Usuario.gxTpr_Estadoid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_estadoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV8Usuario.gxTpr_Estadodescripcion = cgiGet( edtavUsuario_estadodescripcion_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_ciudadid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_ciudadid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_CIUDADID");
               GX_FocusControl = edtavUsuario_ciudadid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8Usuario.gxTpr_Ciudadid = 0;
            }
            else
            {
               AV8Usuario.gxTpr_Ciudadid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_ciudadid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV8Usuario.gxTpr_Ciudaddescripcion = cgiGet( edtavUsuario_ciudaddescripcion_Internalname);
            AV8Usuario.gxTpr_Usuariosucursal = cgiGet( edtavUsuario_usuariosucursal_Internalname);
            cmbavUsuario_usuarioproducto.CurrentValue = cgiGet( cmbavUsuario_usuarioproducto_Internalname);
            AV8Usuario.gxTpr_Usuarioproducto = cgiGet( cmbavUsuario_usuarioproducto_Internalname);
            cmbavUsuario_usuariorol.CurrentValue = cgiGet( cmbavUsuario_usuariorol_Internalname);
            AV8Usuario.gxTpr_Usuariorol = cgiGet( cmbavUsuario_usuariorol_Internalname);
            AV8Usuario.gxTpr_Usuarionocuentabroxel = cgiGet( edtavUsuario_usuarionocuentabroxel_Internalname);
            AV8Usuario.gxTpr_Usuarioreferenciabroxel = cgiGet( edtavUsuario_usuarioreferenciabroxel_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavUsuario_usuariofecharegistro_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Usuario Fecha Registro", "")}), 1, "USUARIO_USUARIOFECHAREGISTRO");
               GX_FocusControl = edtavUsuario_usuariofecharegistro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8Usuario.gxTpr_Usuariofecharegistro = DateTime.MinValue;
            }
            else
            {
               AV8Usuario.gxTpr_Usuariofecharegistro = context.localUtil.CToD( cgiGet( edtavUsuario_usuariofecharegistro_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV8Usuario.gxTpr_Usuarioavisoprivacidad = StringUtil.StrToBool( cgiGet( chkavUsuario_usuarioavisoprivacidad_Internalname));
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
         E11522 ();
         if (returnInSub) return;
      }

      protected void E11522( )
      {
         /* Start Routine */
         returnInSub = false;
         AV11TrnMode = "DSP";
         AssignAttri("", false, "AV11TrnMode", AV11TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         AV12LoadSuccess = true;
         if ( StringUtil.StrCmp(AV11TrnMode, "DSP") == 0 )
         {
            AV8Usuario.Load(AV15UsuarioID);
            AV12LoadSuccess = AV8Usuario.Success();
            if ( ! AV12LoadSuccess )
            {
               AV10Messages = AV8Usuario.GetMessages();
               /* Execute user subroutine: 'SHOW MESSAGES' */
               S112 ();
               if (returnInSub) return;
            }
            edtavUsuario_usuarionombre_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuarionombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarionombre_Enabled), 5, 0), true);
            edtavUsuario_usuarioapellido_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuarioapellido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarioapellido_Enabled), 5, 0), true);
            edtavUsuario_usuariocorreo_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuariocorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocorreo_Enabled), 5, 0), true);
            edtavUsuario_usuariopass_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuariopass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariopass_Enabled), 5, 0), true);
            edtavUsuario_usuariokey_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuariokey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariokey_Enabled), 5, 0), true);
            edtavUsuario_puestoid_Enabled = 0;
            AssignProp("", false, edtavUsuario_puestoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_puestoid_Enabled), 5, 0), true);
            cmbavUsuario_usuariogenero.Enabled = 0;
            AssignProp("", false, cmbavUsuario_usuariogenero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariogenero.Enabled), 5, 0), true);
            cmbavUsuario_usuariodirectoasociado.Enabled = 0;
            AssignProp("", false, cmbavUsuario_usuariodirectoasociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariodirectoasociado.Enabled), 5, 0), true);
            edtavUsuario_usuariorazonsocialasociado_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuariorazonsocialasociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariorazonsocialasociado_Enabled), 5, 0), true);
            edtavUsuario_usuarionombrecomercial_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuarionombrecomercial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarionombrecomercial_Enabled), 5, 0), true);
            edtavUsuario_usuariofechanacimiento_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuariofechanacimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariofechanacimiento_Enabled), 5, 0), true);
            edtavUsuario_usuariocallenum_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuariocallenum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocallenum_Enabled), 5, 0), true);
            edtavUsuario_usuariocolonia_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuariocolonia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocolonia_Enabled), 5, 0), true);
            edtavUsuario_usuariodelegacion_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuariodelegacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariodelegacion_Enabled), 5, 0), true);
            edtavUsuario_usuariocp_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuariocp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocp_Enabled), 5, 0), true);
            cmbavUsuario_usuariozona.Enabled = 0;
            AssignProp("", false, cmbavUsuario_usuariozona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariozona.Enabled), 5, 0), true);
            edtavUsuario_usuariocelular_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuariocelular_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocelular_Enabled), 5, 0), true);
            edtavUsuario_usuariotelefonosucursal_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuariotelefonosucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariotelefonosucursal_Enabled), 5, 0), true);
            edtavUsuario_ciudadid_Enabled = 0;
            AssignProp("", false, edtavUsuario_ciudadid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_ciudadid_Enabled), 5, 0), true);
            edtavUsuario_usuariosucursal_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuariosucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariosucursal_Enabled), 5, 0), true);
            cmbavUsuario_usuarioproducto.Enabled = 0;
            AssignProp("", false, cmbavUsuario_usuarioproducto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuarioproducto.Enabled), 5, 0), true);
            cmbavUsuario_usuariorol.Enabled = 0;
            AssignProp("", false, cmbavUsuario_usuariorol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariorol.Enabled), 5, 0), true);
            edtavUsuario_usuarionocuentabroxel_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuarionocuentabroxel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarionocuentabroxel_Enabled), 5, 0), true);
            edtavUsuario_usuarioreferenciabroxel_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuarioreferenciabroxel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarioreferenciabroxel_Enabled), 5, 0), true);
            edtavUsuario_usuariofecharegistro_Enabled = 0;
            AssignProp("", false, edtavUsuario_usuariofecharegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariofecharegistro_Enabled), 5, 0), true);
            chkavUsuario_usuarioavisoprivacidad.Enabled = 0;
            AssignProp("", false, chkavUsuario_usuarioavisoprivacidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUsuario_usuarioavisoprivacidad.Enabled), 5, 0), true);
         }
         else
         {
            AV12LoadSuccess = false;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12522( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV50GXV35 = 1;
         while ( AV50GXV35 <= AV10Messages.Count )
         {
            AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV10Messages.Item(AV50GXV35));
            GX_msglist.addItem(AV9Message.gxTpr_Description);
            AV50GXV35 = (int)(AV50GXV35+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E13522( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV15UsuarioID = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV15UsuarioID", StringUtil.LTrimStr( (decimal)(AV15UsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15UsuarioID), "ZZZZZZZZ9"), context));
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
         PA522( ) ;
         WS522( ) ;
         WE522( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202651111311219", true, true);
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
         context.AddJavascriptSource("wpdatausersesiondb.js", "?202651111311219", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
            AV8Usuario.gxTpr_Usuariogenero = cmbavUsuario_usuariogenero.getValidValue(AV8Usuario.gxTpr_Usuariogenero);
         }
         cmbavUsuario_usuariodirectoasociado.Name = "USUARIO_USUARIODIRECTOASOCIADO";
         cmbavUsuario_usuariodirectoasociado.WebTags = "";
         cmbavUsuario_usuariodirectoasociado.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavUsuario_usuariodirectoasociado.addItem("Directo", context.GetMessage( "Directo", ""), 0);
         cmbavUsuario_usuariodirectoasociado.addItem("Asociado", context.GetMessage( "Asociado", ""), 0);
         if ( cmbavUsuario_usuariodirectoasociado.ItemCount > 0 )
         {
            AV8Usuario.gxTpr_Usuariodirectoasociado = cmbavUsuario_usuariodirectoasociado.getValidValue(AV8Usuario.gxTpr_Usuariodirectoasociado);
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
            AV8Usuario.gxTpr_Usuariozona = cmbavUsuario_usuariozona.getValidValue(AV8Usuario.gxTpr_Usuariozona);
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
            AV8Usuario.gxTpr_Usuarioproducto = cmbavUsuario_usuarioproducto.getValidValue(AV8Usuario.gxTpr_Usuarioproducto);
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
            AV8Usuario.gxTpr_Usuariorol = cmbavUsuario_usuariorol.getValidValue(AV8Usuario.gxTpr_Usuariorol);
         }
         chkavUsuario_usuarioavisoprivacidad.Name = "USUARIO_USUARIOAVISOPRIVACIDAD";
         chkavUsuario_usuarioavisoprivacidad.WebTags = "";
         chkavUsuario_usuarioavisoprivacidad.Caption = context.GetMessage( "de Privacidad", "");
         AssignProp("", false, chkavUsuario_usuarioavisoprivacidad_Internalname, "TitleCaption", chkavUsuario_usuarioavisoprivacidad.Caption, true);
         chkavUsuario_usuarioavisoprivacidad.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavUsuario_usuarioid_Internalname = "USUARIO_USUARIOID";
         edtavUsuario_usuarionombre_Internalname = "USUARIO_USUARIONOMBRE";
         edtavUsuario_usuarioapellido_Internalname = "USUARIO_USUARIOAPELLIDO";
         edtavUsuario_usuarionombrecompleto_Internalname = "USUARIO_USUARIONOMBRECOMPLETO";
         edtavUsuario_usuariocorreo_Internalname = "USUARIO_USUARIOCORREO";
         edtavUsuario_usuariopass_Internalname = "USUARIO_USUARIOPASS";
         edtavUsuario_usuariokey_Internalname = "USUARIO_USUARIOKEY";
         edtavUsuario_puestoid_Internalname = "USUARIO_PUESTOID";
         edtavUsuario_puestodescripcion_Internalname = "USUARIO_PUESTODESCRIPCION";
         cmbavUsuario_usuariogenero_Internalname = "USUARIO_USUARIOGENERO";
         cmbavUsuario_usuariodirectoasociado_Internalname = "USUARIO_USUARIODIRECTOASOCIADO";
         edtavUsuario_usuariorazonsocialasociado_Internalname = "USUARIO_USUARIORAZONSOCIALASOCIADO";
         edtavUsuario_usuarionombrecomercial_Internalname = "USUARIO_USUARIONOMBRECOMERCIAL";
         edtavUsuario_usuariofechanacimiento_Internalname = "USUARIO_USUARIOFECHANACIMIENTO";
         edtavUsuario_usuariocallenum_Internalname = "USUARIO_USUARIOCALLENUM";
         edtavUsuario_usuariocolonia_Internalname = "USUARIO_USUARIOCOLONIA";
         edtavUsuario_usuariodelegacion_Internalname = "USUARIO_USUARIODELEGACION";
         edtavUsuario_usuariocp_Internalname = "USUARIO_USUARIOCP";
         cmbavUsuario_usuariozona_Internalname = "USUARIO_USUARIOZONA";
         edtavUsuario_usuariocelular_Internalname = "USUARIO_USUARIOCELULAR";
         edtavUsuario_usuariotelefonosucursal_Internalname = "USUARIO_USUARIOTELEFONOSUCURSAL";
         edtavUsuario_paisid_Internalname = "USUARIO_PAISID";
         edtavUsuario_paisdescripcion_Internalname = "USUARIO_PAISDESCRIPCION";
         edtavUsuario_estadoid_Internalname = "USUARIO_ESTADOID";
         edtavUsuario_estadodescripcion_Internalname = "USUARIO_ESTADODESCRIPCION";
         edtavUsuario_ciudadid_Internalname = "USUARIO_CIUDADID";
         edtavUsuario_ciudaddescripcion_Internalname = "USUARIO_CIUDADDESCRIPCION";
         edtavUsuario_usuariosucursal_Internalname = "USUARIO_USUARIOSUCURSAL";
         cmbavUsuario_usuarioproducto_Internalname = "USUARIO_USUARIOPRODUCTO";
         cmbavUsuario_usuariorol_Internalname = "USUARIO_USUARIOROL";
         edtavUsuario_usuarionocuentabroxel_Internalname = "USUARIO_USUARIONOCUENTABROXEL";
         edtavUsuario_usuarioreferenciabroxel_Internalname = "USUARIO_USUARIOREFERENCIABROXEL";
         edtavUsuario_usuariofecharegistro_Internalname = "USUARIO_USUARIOFECHAREGISTRO";
         chkavUsuario_usuarioavisoprivacidad_Internalname = "USUARIO_USUARIOAVISOPRIVACIDAD";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
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
         chkavUsuario_usuarioavisoprivacidad.Caption = context.GetMessage( "de Privacidad", "");
         chkavUsuario_usuarioavisoprivacidad.Enabled = 1;
         edtavUsuario_usuariofecharegistro_Enabled = 1;
         edtavUsuario_usuarioreferenciabroxel_Enabled = 1;
         edtavUsuario_usuarionocuentabroxel_Enabled = 1;
         cmbavUsuario_usuariorol.Enabled = 1;
         cmbavUsuario_usuarioproducto.Enabled = 1;
         edtavUsuario_usuariosucursal_Enabled = 1;
         edtavUsuario_ciudadid_Enabled = 1;
         edtavUsuario_usuariotelefonosucursal_Enabled = 1;
         edtavUsuario_usuariocelular_Enabled = 1;
         cmbavUsuario_usuariozona.Enabled = 1;
         edtavUsuario_usuariocp_Enabled = 1;
         edtavUsuario_usuariodelegacion_Enabled = 1;
         edtavUsuario_usuariocolonia_Enabled = 1;
         edtavUsuario_usuariocallenum_Enabled = 1;
         edtavUsuario_usuariofechanacimiento_Enabled = 1;
         edtavUsuario_usuarionombrecomercial_Enabled = 1;
         edtavUsuario_usuariorazonsocialasociado_Enabled = 1;
         cmbavUsuario_usuariodirectoasociado.Enabled = 1;
         cmbavUsuario_usuariogenero.Enabled = 1;
         edtavUsuario_puestoid_Enabled = 1;
         edtavUsuario_usuariokey_Enabled = 1;
         edtavUsuario_usuariopass_Enabled = 1;
         edtavUsuario_usuariocorreo_Enabled = 1;
         edtavUsuario_usuarioapellido_Enabled = 1;
         edtavUsuario_usuarionombre_Enabled = 1;
         edtavUsuario_ciudaddescripcion_Enabled = -1;
         edtavUsuario_estadodescripcion_Enabled = -1;
         edtavUsuario_estadoid_Enabled = -1;
         edtavUsuario_paisdescripcion_Enabled = -1;
         edtavUsuario_paisid_Enabled = -1;
         edtavUsuario_puestodescripcion_Enabled = -1;
         edtavUsuario_usuarionombrecompleto_Enabled = -1;
         edtavUsuario_usuarioid_Enabled = -1;
         bttBtnenter_Visible = 1;
         chkavUsuario_usuarioavisoprivacidad.Enabled = 1;
         edtavUsuario_usuariofecharegistro_Jsonclick = "";
         edtavUsuario_usuariofecharegistro_Enabled = 1;
         edtavUsuario_usuarioreferenciabroxel_Jsonclick = "";
         edtavUsuario_usuarioreferenciabroxel_Enabled = 1;
         edtavUsuario_usuarionocuentabroxel_Jsonclick = "";
         edtavUsuario_usuarionocuentabroxel_Enabled = 1;
         cmbavUsuario_usuariorol_Jsonclick = "";
         cmbavUsuario_usuariorol.Enabled = 1;
         cmbavUsuario_usuarioproducto_Jsonclick = "";
         cmbavUsuario_usuarioproducto.Enabled = 1;
         edtavUsuario_usuariosucursal_Jsonclick = "";
         edtavUsuario_usuariosucursal_Enabled = 1;
         edtavUsuario_ciudaddescripcion_Jsonclick = "";
         edtavUsuario_ciudaddescripcion_Enabled = 0;
         edtavUsuario_ciudadid_Jsonclick = "";
         edtavUsuario_ciudadid_Enabled = 1;
         edtavUsuario_estadodescripcion_Jsonclick = "";
         edtavUsuario_estadodescripcion_Enabled = 0;
         edtavUsuario_estadoid_Jsonclick = "";
         edtavUsuario_estadoid_Enabled = 0;
         edtavUsuario_paisdescripcion_Jsonclick = "";
         edtavUsuario_paisdescripcion_Enabled = 0;
         edtavUsuario_paisid_Jsonclick = "";
         edtavUsuario_paisid_Enabled = 0;
         edtavUsuario_usuariotelefonosucursal_Jsonclick = "";
         edtavUsuario_usuariotelefonosucursal_Enabled = 1;
         edtavUsuario_usuariocelular_Jsonclick = "";
         edtavUsuario_usuariocelular_Enabled = 1;
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
         edtavUsuario_usuariofechanacimiento_Jsonclick = "";
         edtavUsuario_usuariofechanacimiento_Enabled = 1;
         edtavUsuario_usuarionombrecomercial_Jsonclick = "";
         edtavUsuario_usuarionombrecomercial_Enabled = 1;
         edtavUsuario_usuariorazonsocialasociado_Jsonclick = "";
         edtavUsuario_usuariorazonsocialasociado_Enabled = 1;
         cmbavUsuario_usuariodirectoasociado_Jsonclick = "";
         cmbavUsuario_usuariodirectoasociado.Enabled = 1;
         cmbavUsuario_usuariogenero_Jsonclick = "";
         cmbavUsuario_usuariogenero.Enabled = 1;
         edtavUsuario_puestodescripcion_Jsonclick = "";
         edtavUsuario_puestodescripcion_Enabled = 0;
         edtavUsuario_puestoid_Jsonclick = "";
         edtavUsuario_puestoid_Enabled = 1;
         edtavUsuario_usuariokey_Jsonclick = "";
         edtavUsuario_usuariokey_Enabled = 1;
         edtavUsuario_usuariopass_Jsonclick = "";
         edtavUsuario_usuariopass_Enabled = 1;
         edtavUsuario_usuariocorreo_Jsonclick = "";
         edtavUsuario_usuariocorreo_Enabled = 1;
         edtavUsuario_usuarionombrecompleto_Jsonclick = "";
         edtavUsuario_usuarionombrecompleto_Enabled = 0;
         edtavUsuario_usuarioapellido_Jsonclick = "";
         edtavUsuario_usuarioapellido_Enabled = 1;
         edtavUsuario_usuarionombre_Jsonclick = "";
         edtavUsuario_usuarionombre_Enabled = 1;
         edtavUsuario_usuarioid_Jsonclick = "";
         edtavUsuario_usuarioid_Enabled = 0;
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
         Form.Caption = context.GetMessage( "WPData User Sesion DB", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GXV34","fld":"USUARIO_USUARIOAVISOPRIVACIDAD"},{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV15UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("VALIDV_GXV5","""{"handler":"Validv_Gxv5","iparms":[]}""");
         setEventMetadata("VALIDV_GXV10","""{"handler":"Validv_Gxv10","iparms":[]}""");
         setEventMetadata("VALIDV_GXV11","""{"handler":"Validv_Gxv11","iparms":[]}""");
         setEventMetadata("VALIDV_GXV19","""{"handler":"Validv_Gxv19","iparms":[]}""");
         setEventMetadata("VALIDV_GXV29","""{"handler":"Validv_Gxv29","iparms":[]}""");
         setEventMetadata("VALIDV_GXV30","""{"handler":"Validv_Gxv30","iparms":[]}""");
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
         AV11TrnMode = "";
         AV8Usuario = new SdtUsuario(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         edtavUsuario_usuarioid_Enabled = 0;
         edtavUsuario_usuarionombrecompleto_Enabled = 0;
         edtavUsuario_puestodescripcion_Enabled = 0;
         edtavUsuario_paisid_Enabled = 0;
         edtavUsuario_paisdescripcion_Enabled = 0;
         edtavUsuario_estadoid_Enabled = 0;
         edtavUsuario_estadodescripcion_Enabled = 0;
         edtavUsuario_ciudaddescripcion_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV15UsuarioID ;
      private int wcpOAV15UsuarioID ;
      private int edtavUsuario_usuarioid_Enabled ;
      private int edtavUsuario_usuarionombre_Enabled ;
      private int edtavUsuario_usuarioapellido_Enabled ;
      private int edtavUsuario_usuarionombrecompleto_Enabled ;
      private int edtavUsuario_usuariocorreo_Enabled ;
      private int edtavUsuario_usuariopass_Enabled ;
      private int edtavUsuario_usuariokey_Enabled ;
      private int edtavUsuario_puestoid_Enabled ;
      private int edtavUsuario_puestodescripcion_Enabled ;
      private int edtavUsuario_usuariorazonsocialasociado_Enabled ;
      private int edtavUsuario_usuarionombrecomercial_Enabled ;
      private int edtavUsuario_usuariofechanacimiento_Enabled ;
      private int edtavUsuario_usuariocallenum_Enabled ;
      private int edtavUsuario_usuariocolonia_Enabled ;
      private int edtavUsuario_usuariodelegacion_Enabled ;
      private int edtavUsuario_usuariocp_Enabled ;
      private int edtavUsuario_usuariocelular_Enabled ;
      private int edtavUsuario_usuariotelefonosucursal_Enabled ;
      private int edtavUsuario_paisid_Enabled ;
      private int edtavUsuario_paisdescripcion_Enabled ;
      private int edtavUsuario_estadoid_Enabled ;
      private int edtavUsuario_estadodescripcion_Enabled ;
      private int edtavUsuario_ciudadid_Enabled ;
      private int edtavUsuario_ciudaddescripcion_Enabled ;
      private int edtavUsuario_usuariosucursal_Enabled ;
      private int edtavUsuario_usuarionocuentabroxel_Enabled ;
      private int edtavUsuario_usuarioreferenciabroxel_Enabled ;
      private int edtavUsuario_usuariofecharegistro_Enabled ;
      private int bttBtnenter_Visible ;
      private int AV50GXV35 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV11TrnMode ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavUsuario_usuarioid_Internalname ;
      private string TempTags ;
      private string edtavUsuario_usuarioid_Jsonclick ;
      private string edtavUsuario_usuarionombre_Internalname ;
      private string edtavUsuario_usuarionombre_Jsonclick ;
      private string edtavUsuario_usuarioapellido_Internalname ;
      private string edtavUsuario_usuarioapellido_Jsonclick ;
      private string edtavUsuario_usuarionombrecompleto_Internalname ;
      private string edtavUsuario_usuarionombrecompleto_Jsonclick ;
      private string edtavUsuario_usuariocorreo_Internalname ;
      private string edtavUsuario_usuariocorreo_Jsonclick ;
      private string edtavUsuario_usuariopass_Internalname ;
      private string edtavUsuario_usuariopass_Jsonclick ;
      private string edtavUsuario_usuariokey_Internalname ;
      private string edtavUsuario_usuariokey_Jsonclick ;
      private string edtavUsuario_puestoid_Internalname ;
      private string edtavUsuario_puestoid_Jsonclick ;
      private string edtavUsuario_puestodescripcion_Internalname ;
      private string edtavUsuario_puestodescripcion_Jsonclick ;
      private string cmbavUsuario_usuariogenero_Internalname ;
      private string cmbavUsuario_usuariogenero_Jsonclick ;
      private string cmbavUsuario_usuariodirectoasociado_Internalname ;
      private string cmbavUsuario_usuariodirectoasociado_Jsonclick ;
      private string edtavUsuario_usuariorazonsocialasociado_Internalname ;
      private string edtavUsuario_usuariorazonsocialasociado_Jsonclick ;
      private string edtavUsuario_usuarionombrecomercial_Internalname ;
      private string edtavUsuario_usuarionombrecomercial_Jsonclick ;
      private string edtavUsuario_usuariofechanacimiento_Internalname ;
      private string edtavUsuario_usuariofechanacimiento_Jsonclick ;
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
      private string edtavUsuario_usuariocelular_Internalname ;
      private string edtavUsuario_usuariocelular_Jsonclick ;
      private string edtavUsuario_usuariotelefonosucursal_Internalname ;
      private string edtavUsuario_usuariotelefonosucursal_Jsonclick ;
      private string edtavUsuario_paisid_Internalname ;
      private string edtavUsuario_paisid_Jsonclick ;
      private string edtavUsuario_paisdescripcion_Internalname ;
      private string edtavUsuario_paisdescripcion_Jsonclick ;
      private string edtavUsuario_estadoid_Internalname ;
      private string edtavUsuario_estadoid_Jsonclick ;
      private string edtavUsuario_estadodescripcion_Internalname ;
      private string edtavUsuario_estadodescripcion_Jsonclick ;
      private string edtavUsuario_ciudadid_Internalname ;
      private string edtavUsuario_ciudadid_Jsonclick ;
      private string edtavUsuario_ciudaddescripcion_Internalname ;
      private string edtavUsuario_ciudaddescripcion_Jsonclick ;
      private string edtavUsuario_usuariosucursal_Internalname ;
      private string edtavUsuario_usuariosucursal_Jsonclick ;
      private string cmbavUsuario_usuarioproducto_Internalname ;
      private string cmbavUsuario_usuarioproducto_Jsonclick ;
      private string cmbavUsuario_usuariorol_Internalname ;
      private string cmbavUsuario_usuariorol_Jsonclick ;
      private string edtavUsuario_usuarionocuentabroxel_Internalname ;
      private string edtavUsuario_usuarionocuentabroxel_Jsonclick ;
      private string edtavUsuario_usuarioreferenciabroxel_Internalname ;
      private string edtavUsuario_usuarioreferenciabroxel_Jsonclick ;
      private string edtavUsuario_usuariofecharegistro_Internalname ;
      private string edtavUsuario_usuariofecharegistro_Jsonclick ;
      private string chkavUsuario_usuarioavisoprivacidad_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV12LoadSuccess ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavUsuario_usuariogenero ;
      private GXCombobox cmbavUsuario_usuariodirectoasociado ;
      private GXCombobox cmbavUsuario_usuariozona ;
      private GXCombobox cmbavUsuario_usuarioproducto ;
      private GXCombobox cmbavUsuario_usuariorol ;
      private GXCheckbox chkavUsuario_usuarioavisoprivacidad ;
      private SdtUsuario AV8Usuario ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
