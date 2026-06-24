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
   public class wpdatausersesion : GXDataArea
   {
      public wpdatausersesion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpdatausersesion( IGxContext context )
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
         cmbavSdtusuario_usuariorol = new GXCombobox();
         cmbavSdtusuario_usuariogenero = new GXCombobox();
         cmbavSdtusuario_usuariodirectoasociado = new GXCombobox();
         cmbavSdtusuario_usuariozona = new GXCombobox();
         cmbavSdtusuario_usuarioproducto = new GXCombobox();
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
         PA512( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START512( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpdatausersesion.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtusuario", AV5SDTUsuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtusuario", AV5SDTUsuario);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTUSUARIO", AV5SDTUsuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTUSUARIO", AV5SDTUsuario);
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
            WE512( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT512( ) ;
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
         return formatLink("wpdatausersesion.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPDataUserSesion" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WPData User Sesion", "") ;
      }

      protected void WB510( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_usuarioid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_usuarioid_Internalname, context.GetMessage( "Usuario ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_usuarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SDTUsuario.gxTpr_Usuarioid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSdtusuario_usuarioid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Usuarioid), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Usuarioid), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_usuarioid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_usuarioid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_usuarionombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_usuarionombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_usuarionombre_Internalname, StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuarionombre), StringUtil.RTrim( context.localUtil.Format( AV5SDTUsuario.gxTpr_Usuarionombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_usuarionombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_usuarionombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_usuariocorreo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_usuariocorreo_Internalname, context.GetMessage( "Correo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_usuariocorreo_Internalname, AV5SDTUsuario.gxTpr_Usuariocorreo, StringUtil.RTrim( context.localUtil.Format( AV5SDTUsuario.gxTpr_Usuariocorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_usuariocorreo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_usuariocorreo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSdtusuario_usuariorol_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSdtusuario_usuariorol_Internalname, context.GetMessage( "Rol", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSdtusuario_usuariorol, cmbavSdtusuario_usuariorol_Internalname, StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariorol), 1, cmbavSdtusuario_usuariorol_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavSdtusuario_usuariorol.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 0, "HLP_WPDataUserSesion.htm");
            cmbavSdtusuario_usuariorol.CurrentValue = StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariorol);
            AssignProp("", false, cmbavSdtusuario_usuariorol_Internalname, "Values", (string)(cmbavSdtusuario_usuariorol.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_usuarioapellido_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_usuarioapellido_Internalname, context.GetMessage( "Apellido(s)", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_usuarioapellido_Internalname, StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuarioapellido), StringUtil.RTrim( context.localUtil.Format( AV5SDTUsuario.gxTpr_Usuarioapellido, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_usuarioapellido_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_usuarioapellido_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_usuarionombrecompleto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_usuarionombrecompleto_Internalname, context.GetMessage( "Nombre completo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_usuarionombrecompleto_Internalname, AV5SDTUsuario.gxTpr_Usuarionombrecompleto, StringUtil.RTrim( context.localUtil.Format( AV5SDTUsuario.gxTpr_Usuarionombrecompleto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_usuarionombrecompleto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_usuarionombrecompleto_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_puestoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_puestoid_Internalname, context.GetMessage( "Puesto ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_puestoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SDTUsuario.gxTpr_Puestoid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSdtusuario_puestoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Puestoid), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Puestoid), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_puestoid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_puestoid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_puestodescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_puestodescripcion_Internalname, context.GetMessage( "Puesto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_puestodescripcion_Internalname, AV5SDTUsuario.gxTpr_Puestodescripcion, StringUtil.RTrim( context.localUtil.Format( AV5SDTUsuario.gxTpr_Puestodescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_puestodescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_puestodescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSdtusuario_usuariogenero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSdtusuario_usuariogenero_Internalname, context.GetMessage( "Género", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSdtusuario_usuariogenero, cmbavSdtusuario_usuariogenero_Internalname, StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariogenero), 1, cmbavSdtusuario_usuariogenero_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavSdtusuario_usuariogenero.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "", true, 0, "HLP_WPDataUserSesion.htm");
            cmbavSdtusuario_usuariogenero.CurrentValue = StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariogenero);
            AssignProp("", false, cmbavSdtusuario_usuariogenero_Internalname, "Values", (string)(cmbavSdtusuario_usuariogenero.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSdtusuario_usuariodirectoasociado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSdtusuario_usuariodirectoasociado_Internalname, context.GetMessage( "Directo/Asociado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSdtusuario_usuariodirectoasociado, cmbavSdtusuario_usuariodirectoasociado_Internalname, StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariodirectoasociado), 1, cmbavSdtusuario_usuariodirectoasociado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavSdtusuario_usuariodirectoasociado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "", true, 0, "HLP_WPDataUserSesion.htm");
            cmbavSdtusuario_usuariodirectoasociado.CurrentValue = StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariodirectoasociado);
            AssignProp("", false, cmbavSdtusuario_usuariodirectoasociado_Internalname, "Values", (string)(cmbavSdtusuario_usuariodirectoasociado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_usuariorazonsocialasociado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_usuariorazonsocialasociado_Internalname, context.GetMessage( "Razón Social Asociado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_usuariorazonsocialasociado_Internalname, AV5SDTUsuario.gxTpr_Usuariorazonsocialasociado, StringUtil.RTrim( context.localUtil.Format( AV5SDTUsuario.gxTpr_Usuariorazonsocialasociado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_usuariorazonsocialasociado_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_usuariorazonsocialasociado_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_usuarionombrecomercial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_usuarionombrecomercial_Internalname, context.GetMessage( "Nombre Comercial", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_usuarionombrecomercial_Internalname, AV5SDTUsuario.gxTpr_Usuarionombrecomercial, StringUtil.RTrim( context.localUtil.Format( AV5SDTUsuario.gxTpr_Usuarionombrecomercial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_usuarionombrecomercial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_usuarionombrecomercial_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_usuariofechanacimiento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_usuariofechanacimiento_Internalname, context.GetMessage( "Fecha de nacimiento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavSdtusuario_usuariofechanacimiento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_usuariofechanacimiento_Internalname, context.localUtil.Format(AV5SDTUsuario.gxTpr_Usuariofechanacimiento, "99/99/9999"), context.localUtil.Format( AV5SDTUsuario.gxTpr_Usuariofechanacimiento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_usuariofechanacimiento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_usuariofechanacimiento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_bitmap( context, edtavSdtusuario_usuariofechanacimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavSdtusuario_usuariofechanacimiento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPDataUserSesion.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_usuariocallenum_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_usuariocallenum_Internalname, context.GetMessage( "Calle y número", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_usuariocallenum_Internalname, StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariocallenum), StringUtil.RTrim( context.localUtil.Format( AV5SDTUsuario.gxTpr_Usuariocallenum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_usuariocallenum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_usuariocallenum_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_usuariocolonia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_usuariocolonia_Internalname, context.GetMessage( "Colonia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_usuariocolonia_Internalname, StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariocolonia), StringUtil.RTrim( context.localUtil.Format( AV5SDTUsuario.gxTpr_Usuariocolonia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_usuariocolonia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_usuariocolonia_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_usuariodelegacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_usuariodelegacion_Internalname, context.GetMessage( "Delegación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_usuariodelegacion_Internalname, StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariodelegacion), StringUtil.RTrim( context.localUtil.Format( AV5SDTUsuario.gxTpr_Usuariodelegacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_usuariodelegacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_usuariodelegacion_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_usuariocp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_usuariocp_Internalname, context.GetMessage( "Código Postal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_usuariocp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SDTUsuario.gxTpr_Usuariocp), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSdtusuario_usuariocp_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Usuariocp), "ZZZZ9") : context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Usuariocp), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_usuariocp_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_usuariocp_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSdtusuario_usuariozona_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSdtusuario_usuariozona_Internalname, context.GetMessage( "Usuario Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSdtusuario_usuariozona, cmbavSdtusuario_usuariozona_Internalname, StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariozona), 1, cmbavSdtusuario_usuariozona_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavSdtusuario_usuariozona.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "", true, 0, "HLP_WPDataUserSesion.htm");
            cmbavSdtusuario_usuariozona.CurrentValue = StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariozona);
            AssignProp("", false, cmbavSdtusuario_usuariozona_Internalname, "Values", (string)(cmbavSdtusuario_usuariozona.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_usuariocelular_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_usuariocelular_Internalname, context.GetMessage( "Usuario Celular", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_usuariocelular_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SDTUsuario.gxTpr_Usuariocelular), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSdtusuario_usuariocelular_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Usuariocelular), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Usuariocelular), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_usuariocelular_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_usuariocelular_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_usuariotelefonosucursal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_usuariotelefonosucursal_Internalname, context.GetMessage( "Teléfono Sucursal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_usuariotelefonosucursal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SDTUsuario.gxTpr_Usuariotelefonosucursal), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSdtusuario_usuariotelefonosucursal_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Usuariotelefonosucursal), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Usuariotelefonosucursal), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_usuariotelefonosucursal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_usuariotelefonosucursal_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_paisid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_paisid_Internalname, context.GetMessage( "Pais ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_paisid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SDTUsuario.gxTpr_Paisid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSdtusuario_paisid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Paisid), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Paisid), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,122);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_paisid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_paisid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_paisdescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_paisdescripcion_Internalname, context.GetMessage( "País", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_paisdescripcion_Internalname, AV5SDTUsuario.gxTpr_Paisdescripcion, StringUtil.RTrim( context.localUtil.Format( AV5SDTUsuario.gxTpr_Paisdescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_paisdescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_paisdescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_estadoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_estadoid_Internalname, context.GetMessage( "Estado ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_estadoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SDTUsuario.gxTpr_Estadoid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSdtusuario_estadoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Estadoid), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Estadoid), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,132);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_estadoid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_estadoid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_estadodescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_estadodescripcion_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_estadodescripcion_Internalname, AV5SDTUsuario.gxTpr_Estadodescripcion, StringUtil.RTrim( context.localUtil.Format( AV5SDTUsuario.gxTpr_Estadodescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,137);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_estadodescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_estadodescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_ciudadid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_ciudadid_Internalname, context.GetMessage( "Ciudad ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_ciudadid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SDTUsuario.gxTpr_Ciudadid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSdtusuario_ciudadid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Ciudadid), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5SDTUsuario.gxTpr_Ciudadid), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,142);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_ciudadid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_ciudadid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_ciudaddescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_ciudaddescripcion_Internalname, context.GetMessage( "Ciudad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_ciudaddescripcion_Internalname, AV5SDTUsuario.gxTpr_Ciudaddescripcion, StringUtil.RTrim( context.localUtil.Format( AV5SDTUsuario.gxTpr_Ciudaddescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_ciudaddescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_ciudaddescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtusuario_usuariosucursal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtusuario_usuariosucursal_Internalname, context.GetMessage( "Usuario Sucursal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtusuario_usuariosucursal_Internalname, StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariosucursal), StringUtil.RTrim( context.localUtil.Format( AV5SDTUsuario.gxTpr_Usuariosucursal, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,152);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtusuario_usuariosucursal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtusuario_usuariosucursal_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSdtusuario_usuarioproducto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSdtusuario_usuarioproducto_Internalname, context.GetMessage( "Producto que vendes", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSdtusuario_usuarioproducto, cmbavSdtusuario_usuarioproducto_Internalname, StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuarioproducto), 1, cmbavSdtusuario_usuarioproducto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavSdtusuario_usuarioproducto.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"", "", true, 0, "HLP_WPDataUserSesion.htm");
            cmbavSdtusuario_usuarioproducto.CurrentValue = StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuarioproducto);
            AssignProp("", false, cmbavSdtusuario_usuarioproducto_Internalname, "Values", (string)(cmbavSdtusuario_usuarioproducto.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPDataUserSesion.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPDataUserSesion.htm");
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

      protected void START512( )
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
         Form.Meta.addItem("description", context.GetMessage( "WPData User Sesion", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP510( ) ;
      }

      protected void WS512( )
      {
         START512( ) ;
         EVT512( ) ;
      }

      protected void EVT512( )
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
                              E11512 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E12512 ();
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

      protected void WE512( )
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

      protected void PA512( )
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
               GX_FocusControl = edtavSdtusuario_usuarioid_Internalname;
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
         if ( cmbavSdtusuario_usuariorol.ItemCount > 0 )
         {
            AV5SDTUsuario.gxTpr_Usuariorol = cmbavSdtusuario_usuariorol.getValidValue(AV5SDTUsuario.gxTpr_Usuariorol);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSdtusuario_usuariorol.CurrentValue = StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariorol);
            AssignProp("", false, cmbavSdtusuario_usuariorol_Internalname, "Values", cmbavSdtusuario_usuariorol.ToJavascriptSource(), true);
         }
         if ( cmbavSdtusuario_usuariogenero.ItemCount > 0 )
         {
            AV5SDTUsuario.gxTpr_Usuariogenero = cmbavSdtusuario_usuariogenero.getValidValue(AV5SDTUsuario.gxTpr_Usuariogenero);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSdtusuario_usuariogenero.CurrentValue = StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariogenero);
            AssignProp("", false, cmbavSdtusuario_usuariogenero_Internalname, "Values", cmbavSdtusuario_usuariogenero.ToJavascriptSource(), true);
         }
         if ( cmbavSdtusuario_usuariodirectoasociado.ItemCount > 0 )
         {
            AV5SDTUsuario.gxTpr_Usuariodirectoasociado = cmbavSdtusuario_usuariodirectoasociado.getValidValue(AV5SDTUsuario.gxTpr_Usuariodirectoasociado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSdtusuario_usuariodirectoasociado.CurrentValue = StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariodirectoasociado);
            AssignProp("", false, cmbavSdtusuario_usuariodirectoasociado_Internalname, "Values", cmbavSdtusuario_usuariodirectoasociado.ToJavascriptSource(), true);
         }
         if ( cmbavSdtusuario_usuariozona.ItemCount > 0 )
         {
            AV5SDTUsuario.gxTpr_Usuariozona = cmbavSdtusuario_usuariozona.getValidValue(AV5SDTUsuario.gxTpr_Usuariozona);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSdtusuario_usuariozona.CurrentValue = StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuariozona);
            AssignProp("", false, cmbavSdtusuario_usuariozona_Internalname, "Values", cmbavSdtusuario_usuariozona.ToJavascriptSource(), true);
         }
         if ( cmbavSdtusuario_usuarioproducto.ItemCount > 0 )
         {
            AV5SDTUsuario.gxTpr_Usuarioproducto = cmbavSdtusuario_usuarioproducto.getValidValue(AV5SDTUsuario.gxTpr_Usuarioproducto);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSdtusuario_usuarioproducto.CurrentValue = StringUtil.RTrim( AV5SDTUsuario.gxTpr_Usuarioproducto);
            AssignProp("", false, cmbavSdtusuario_usuarioproducto_Internalname, "Values", cmbavSdtusuario_usuarioproducto.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF512( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSdtusuario_usuarioid_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuarioid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuarioid_Enabled), 5, 0), true);
         edtavSdtusuario_usuarionombre_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuarionombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuarionombre_Enabled), 5, 0), true);
         edtavSdtusuario_usuariocorreo_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariocorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariocorreo_Enabled), 5, 0), true);
         cmbavSdtusuario_usuariorol.Enabled = 0;
         AssignProp("", false, cmbavSdtusuario_usuariorol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdtusuario_usuariorol.Enabled), 5, 0), true);
         edtavSdtusuario_usuarioapellido_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuarioapellido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuarioapellido_Enabled), 5, 0), true);
         edtavSdtusuario_usuarionombrecompleto_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuarionombrecompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuarionombrecompleto_Enabled), 5, 0), true);
         edtavSdtusuario_puestoid_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_puestoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_puestoid_Enabled), 5, 0), true);
         edtavSdtusuario_puestodescripcion_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_puestodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_puestodescripcion_Enabled), 5, 0), true);
         cmbavSdtusuario_usuariogenero.Enabled = 0;
         AssignProp("", false, cmbavSdtusuario_usuariogenero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdtusuario_usuariogenero.Enabled), 5, 0), true);
         cmbavSdtusuario_usuariodirectoasociado.Enabled = 0;
         AssignProp("", false, cmbavSdtusuario_usuariodirectoasociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdtusuario_usuariodirectoasociado.Enabled), 5, 0), true);
         edtavSdtusuario_usuariorazonsocialasociado_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariorazonsocialasociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariorazonsocialasociado_Enabled), 5, 0), true);
         edtavSdtusuario_usuarionombrecomercial_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuarionombrecomercial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuarionombrecomercial_Enabled), 5, 0), true);
         edtavSdtusuario_usuariofechanacimiento_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariofechanacimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariofechanacimiento_Enabled), 5, 0), true);
         edtavSdtusuario_usuariocallenum_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariocallenum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariocallenum_Enabled), 5, 0), true);
         edtavSdtusuario_usuariocolonia_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariocolonia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariocolonia_Enabled), 5, 0), true);
         edtavSdtusuario_usuariodelegacion_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariodelegacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariodelegacion_Enabled), 5, 0), true);
         edtavSdtusuario_usuariocp_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariocp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariocp_Enabled), 5, 0), true);
         cmbavSdtusuario_usuariozona.Enabled = 0;
         AssignProp("", false, cmbavSdtusuario_usuariozona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdtusuario_usuariozona.Enabled), 5, 0), true);
         edtavSdtusuario_usuariocelular_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariocelular_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariocelular_Enabled), 5, 0), true);
         edtavSdtusuario_usuariotelefonosucursal_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariotelefonosucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariotelefonosucursal_Enabled), 5, 0), true);
         edtavSdtusuario_paisid_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_paisid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_paisid_Enabled), 5, 0), true);
         edtavSdtusuario_paisdescripcion_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_paisdescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_paisdescripcion_Enabled), 5, 0), true);
         edtavSdtusuario_estadoid_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_estadoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_estadoid_Enabled), 5, 0), true);
         edtavSdtusuario_estadodescripcion_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_estadodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_estadodescripcion_Enabled), 5, 0), true);
         edtavSdtusuario_ciudadid_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_ciudadid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_ciudadid_Enabled), 5, 0), true);
         edtavSdtusuario_ciudaddescripcion_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_ciudaddescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_ciudaddescripcion_Enabled), 5, 0), true);
         edtavSdtusuario_usuariosucursal_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariosucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariosucursal_Enabled), 5, 0), true);
         cmbavSdtusuario_usuarioproducto.Enabled = 0;
         AssignProp("", false, cmbavSdtusuario_usuarioproducto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdtusuario_usuarioproducto.Enabled), 5, 0), true);
      }

      protected void RF512( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12512 ();
            WB510( ) ;
         }
      }

      protected void send_integrity_lvl_hashes512( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavSdtusuario_usuarioid_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuarioid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuarioid_Enabled), 5, 0), true);
         edtavSdtusuario_usuarionombre_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuarionombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuarionombre_Enabled), 5, 0), true);
         edtavSdtusuario_usuariocorreo_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariocorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariocorreo_Enabled), 5, 0), true);
         cmbavSdtusuario_usuariorol.Enabled = 0;
         AssignProp("", false, cmbavSdtusuario_usuariorol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdtusuario_usuariorol.Enabled), 5, 0), true);
         edtavSdtusuario_usuarioapellido_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuarioapellido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuarioapellido_Enabled), 5, 0), true);
         edtavSdtusuario_usuarionombrecompleto_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuarionombrecompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuarionombrecompleto_Enabled), 5, 0), true);
         edtavSdtusuario_puestoid_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_puestoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_puestoid_Enabled), 5, 0), true);
         edtavSdtusuario_puestodescripcion_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_puestodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_puestodescripcion_Enabled), 5, 0), true);
         cmbavSdtusuario_usuariogenero.Enabled = 0;
         AssignProp("", false, cmbavSdtusuario_usuariogenero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdtusuario_usuariogenero.Enabled), 5, 0), true);
         cmbavSdtusuario_usuariodirectoasociado.Enabled = 0;
         AssignProp("", false, cmbavSdtusuario_usuariodirectoasociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdtusuario_usuariodirectoasociado.Enabled), 5, 0), true);
         edtavSdtusuario_usuariorazonsocialasociado_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariorazonsocialasociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariorazonsocialasociado_Enabled), 5, 0), true);
         edtavSdtusuario_usuarionombrecomercial_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuarionombrecomercial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuarionombrecomercial_Enabled), 5, 0), true);
         edtavSdtusuario_usuariofechanacimiento_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariofechanacimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariofechanacimiento_Enabled), 5, 0), true);
         edtavSdtusuario_usuariocallenum_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariocallenum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariocallenum_Enabled), 5, 0), true);
         edtavSdtusuario_usuariocolonia_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariocolonia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariocolonia_Enabled), 5, 0), true);
         edtavSdtusuario_usuariodelegacion_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariodelegacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariodelegacion_Enabled), 5, 0), true);
         edtavSdtusuario_usuariocp_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariocp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariocp_Enabled), 5, 0), true);
         cmbavSdtusuario_usuariozona.Enabled = 0;
         AssignProp("", false, cmbavSdtusuario_usuariozona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdtusuario_usuariozona.Enabled), 5, 0), true);
         edtavSdtusuario_usuariocelular_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariocelular_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariocelular_Enabled), 5, 0), true);
         edtavSdtusuario_usuariotelefonosucursal_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariotelefonosucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariotelefonosucursal_Enabled), 5, 0), true);
         edtavSdtusuario_paisid_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_paisid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_paisid_Enabled), 5, 0), true);
         edtavSdtusuario_paisdescripcion_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_paisdescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_paisdescripcion_Enabled), 5, 0), true);
         edtavSdtusuario_estadoid_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_estadoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_estadoid_Enabled), 5, 0), true);
         edtavSdtusuario_estadodescripcion_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_estadodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_estadodescripcion_Enabled), 5, 0), true);
         edtavSdtusuario_ciudadid_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_ciudadid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_ciudadid_Enabled), 5, 0), true);
         edtavSdtusuario_ciudaddescripcion_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_ciudaddescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_ciudaddescripcion_Enabled), 5, 0), true);
         edtavSdtusuario_usuariosucursal_Enabled = 0;
         AssignProp("", false, edtavSdtusuario_usuariosucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtusuario_usuariosucursal_Enabled), 5, 0), true);
         cmbavSdtusuario_usuarioproducto.Enabled = 0;
         AssignProp("", false, cmbavSdtusuario_usuarioproducto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdtusuario_usuarioproducto.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP510( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11512 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vSDTUSUARIO"), AV5SDTUsuario);
            ajax_req_read_hidden_sdt(cgiGet( "Sdtusuario"), AV5SDTUsuario);
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_usuarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_usuarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SDTUSUARIO_USUARIOID");
               GX_FocusControl = edtavSdtusuario_usuarioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SDTUsuario.gxTpr_Usuarioid = 0;
            }
            else
            {
               AV5SDTUsuario.gxTpr_Usuarioid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavSdtusuario_usuarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV5SDTUsuario.gxTpr_Usuarionombre = cgiGet( edtavSdtusuario_usuarionombre_Internalname);
            AV5SDTUsuario.gxTpr_Usuariocorreo = cgiGet( edtavSdtusuario_usuariocorreo_Internalname);
            cmbavSdtusuario_usuariorol.CurrentValue = cgiGet( cmbavSdtusuario_usuariorol_Internalname);
            AV5SDTUsuario.gxTpr_Usuariorol = cgiGet( cmbavSdtusuario_usuariorol_Internalname);
            AV5SDTUsuario.gxTpr_Usuarioapellido = cgiGet( edtavSdtusuario_usuarioapellido_Internalname);
            AV5SDTUsuario.gxTpr_Usuarionombrecompleto = cgiGet( edtavSdtusuario_usuarionombrecompleto_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_puestoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_puestoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SDTUSUARIO_PUESTOID");
               GX_FocusControl = edtavSdtusuario_puestoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SDTUsuario.gxTpr_Puestoid = 0;
            }
            else
            {
               AV5SDTUsuario.gxTpr_Puestoid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavSdtusuario_puestoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV5SDTUsuario.gxTpr_Puestodescripcion = cgiGet( edtavSdtusuario_puestodescripcion_Internalname);
            cmbavSdtusuario_usuariogenero.CurrentValue = cgiGet( cmbavSdtusuario_usuariogenero_Internalname);
            AV5SDTUsuario.gxTpr_Usuariogenero = cgiGet( cmbavSdtusuario_usuariogenero_Internalname);
            cmbavSdtusuario_usuariodirectoasociado.CurrentValue = cgiGet( cmbavSdtusuario_usuariodirectoasociado_Internalname);
            AV5SDTUsuario.gxTpr_Usuariodirectoasociado = cgiGet( cmbavSdtusuario_usuariodirectoasociado_Internalname);
            AV5SDTUsuario.gxTpr_Usuariorazonsocialasociado = cgiGet( edtavSdtusuario_usuariorazonsocialasociado_Internalname);
            AV5SDTUsuario.gxTpr_Usuarionombrecomercial = cgiGet( edtavSdtusuario_usuarionombrecomercial_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavSdtusuario_usuariofechanacimiento_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {""}), 1, "SDTUSUARIO_USUARIOFECHANACIMIENTO");
               GX_FocusControl = edtavSdtusuario_usuariofechanacimiento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SDTUsuario.gxTpr_Usuariofechanacimiento = DateTime.MinValue;
            }
            else
            {
               AV5SDTUsuario.gxTpr_Usuariofechanacimiento = context.localUtil.CToD( cgiGet( edtavSdtusuario_usuariofechanacimiento_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV5SDTUsuario.gxTpr_Usuariocallenum = cgiGet( edtavSdtusuario_usuariocallenum_Internalname);
            AV5SDTUsuario.gxTpr_Usuariocolonia = cgiGet( edtavSdtusuario_usuariocolonia_Internalname);
            AV5SDTUsuario.gxTpr_Usuariodelegacion = cgiGet( edtavSdtusuario_usuariodelegacion_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_usuariocp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_usuariocp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SDTUSUARIO_USUARIOCP");
               GX_FocusControl = edtavSdtusuario_usuariocp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SDTUsuario.gxTpr_Usuariocp = 0;
            }
            else
            {
               AV5SDTUsuario.gxTpr_Usuariocp = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavSdtusuario_usuariocp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            cmbavSdtusuario_usuariozona.CurrentValue = cgiGet( cmbavSdtusuario_usuariozona_Internalname);
            AV5SDTUsuario.gxTpr_Usuariozona = cgiGet( cmbavSdtusuario_usuariozona_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_usuariocelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_usuariocelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SDTUSUARIO_USUARIOCELULAR");
               GX_FocusControl = edtavSdtusuario_usuariocelular_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SDTUsuario.gxTpr_Usuariocelular = 0;
            }
            else
            {
               AV5SDTUsuario.gxTpr_Usuariocelular = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavSdtusuario_usuariocelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_usuariotelefonosucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_usuariotelefonosucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SDTUSUARIO_USUARIOTELEFONOSUCURSAL");
               GX_FocusControl = edtavSdtusuario_usuariotelefonosucursal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SDTUsuario.gxTpr_Usuariotelefonosucursal = 0;
            }
            else
            {
               AV5SDTUsuario.gxTpr_Usuariotelefonosucursal = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavSdtusuario_usuariotelefonosucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_paisid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_paisid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SDTUSUARIO_PAISID");
               GX_FocusControl = edtavSdtusuario_paisid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SDTUsuario.gxTpr_Paisid = 0;
            }
            else
            {
               AV5SDTUsuario.gxTpr_Paisid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavSdtusuario_paisid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV5SDTUsuario.gxTpr_Paisdescripcion = cgiGet( edtavSdtusuario_paisdescripcion_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_estadoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_estadoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SDTUSUARIO_ESTADOID");
               GX_FocusControl = edtavSdtusuario_estadoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SDTUsuario.gxTpr_Estadoid = 0;
            }
            else
            {
               AV5SDTUsuario.gxTpr_Estadoid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavSdtusuario_estadoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV5SDTUsuario.gxTpr_Estadodescripcion = cgiGet( edtavSdtusuario_estadodescripcion_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_ciudadid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSdtusuario_ciudadid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SDTUSUARIO_CIUDADID");
               GX_FocusControl = edtavSdtusuario_ciudadid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SDTUsuario.gxTpr_Ciudadid = 0;
            }
            else
            {
               AV5SDTUsuario.gxTpr_Ciudadid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavSdtusuario_ciudadid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV5SDTUsuario.gxTpr_Ciudaddescripcion = cgiGet( edtavSdtusuario_ciudaddescripcion_Internalname);
            AV5SDTUsuario.gxTpr_Usuariosucursal = cgiGet( edtavSdtusuario_usuariosucursal_Internalname);
            cmbavSdtusuario_usuarioproducto.CurrentValue = cgiGet( cmbavSdtusuario_usuarioproducto_Internalname);
            AV5SDTUsuario.gxTpr_Usuarioproducto = cgiGet( cmbavSdtusuario_usuarioproducto_Internalname);
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
         E11512 ();
         if (returnInSub) return;
      }

      protected void E11512( )
      {
         /* Start Routine */
         returnInSub = false;
         AV6UsuarioJSON = AV7WebSession.Get("Usuario");
         AV5SDTUsuario = new SdtSDTUsuario(context);
         AV5SDTUsuario.FromJSonString(AV6UsuarioJSON, null);
      }

      protected void nextLoad( )
      {
      }

      protected void E12512( )
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
         PA512( ) ;
         WS512( ) ;
         WE512( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202651111311145", true, true);
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
         context.AddJavascriptSource("wpdatausersesion.js", "?202651111311145", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavSdtusuario_usuariorol.Name = "SDTUSUARIO_USUARIOROL";
         cmbavSdtusuario_usuariorol.WebTags = "";
         cmbavSdtusuario_usuariorol.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavSdtusuario_usuariorol.addItem("Super Administrador", context.GetMessage( "Super Administrador", ""), 0);
         cmbavSdtusuario_usuariorol.addItem("Administrador Yokohama", context.GetMessage( "Administrador Yokohama", ""), 0);
         cmbavSdtusuario_usuariorol.addItem("Asesor", context.GetMessage( "Asesor", ""), 0);
         cmbavSdtusuario_usuariorol.addItem("Participante", context.GetMessage( "Participante", ""), 0);
         if ( cmbavSdtusuario_usuariorol.ItemCount > 0 )
         {
            AV5SDTUsuario.gxTpr_Usuariorol = cmbavSdtusuario_usuariorol.getValidValue(AV5SDTUsuario.gxTpr_Usuariorol);
         }
         cmbavSdtusuario_usuariogenero.Name = "SDTUSUARIO_USUARIOGENERO";
         cmbavSdtusuario_usuariogenero.WebTags = "";
         cmbavSdtusuario_usuariogenero.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavSdtusuario_usuariogenero.addItem("Masculino", context.GetMessage( "Masculino", ""), 0);
         cmbavSdtusuario_usuariogenero.addItem("Femenino", context.GetMessage( "Femenino", ""), 0);
         if ( cmbavSdtusuario_usuariogenero.ItemCount > 0 )
         {
            AV5SDTUsuario.gxTpr_Usuariogenero = cmbavSdtusuario_usuariogenero.getValidValue(AV5SDTUsuario.gxTpr_Usuariogenero);
         }
         cmbavSdtusuario_usuariodirectoasociado.Name = "SDTUSUARIO_USUARIODIRECTOASOCIADO";
         cmbavSdtusuario_usuariodirectoasociado.WebTags = "";
         cmbavSdtusuario_usuariodirectoasociado.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavSdtusuario_usuariodirectoasociado.addItem("Directo", context.GetMessage( "Directo", ""), 0);
         cmbavSdtusuario_usuariodirectoasociado.addItem("Asociado", context.GetMessage( "Asociado", ""), 0);
         if ( cmbavSdtusuario_usuariodirectoasociado.ItemCount > 0 )
         {
            AV5SDTUsuario.gxTpr_Usuariodirectoasociado = cmbavSdtusuario_usuariodirectoasociado.getValidValue(AV5SDTUsuario.gxTpr_Usuariodirectoasociado);
         }
         cmbavSdtusuario_usuariozona.Name = "SDTUSUARIO_USUARIOZONA";
         cmbavSdtusuario_usuariozona.WebTags = "";
         cmbavSdtusuario_usuariozona.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavSdtusuario_usuariozona.addItem("Centro", context.GetMessage( "Centro", ""), 0);
         cmbavSdtusuario_usuariozona.addItem("Centro América", context.GetMessage( "Centro América", ""), 0);
         cmbavSdtusuario_usuariozona.addItem("Norte", context.GetMessage( "Norte", ""), 0);
         cmbavSdtusuario_usuariozona.addItem("Pacífico", context.GetMessage( "Pacifico", ""), 0);
         cmbavSdtusuario_usuariozona.addItem("Sur", context.GetMessage( "Sur", ""), 0);
         if ( cmbavSdtusuario_usuariozona.ItemCount > 0 )
         {
            AV5SDTUsuario.gxTpr_Usuariozona = cmbavSdtusuario_usuariozona.getValidValue(AV5SDTUsuario.gxTpr_Usuariozona);
         }
         cmbavSdtusuario_usuarioproducto.Name = "SDTUSUARIO_USUARIOPRODUCTO";
         cmbavSdtusuario_usuarioproducto.WebTags = "";
         cmbavSdtusuario_usuarioproducto.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavSdtusuario_usuarioproducto.addItem("Auto y Camioneta", context.GetMessage( "Auto y Camioneta", ""), 0);
         cmbavSdtusuario_usuarioproducto.addItem("Auto y Camioneta/Camión", context.GetMessage( "Auto y Camioneta/Camión", ""), 0);
         cmbavSdtusuario_usuarioproducto.addItem("Camión", context.GetMessage( "Camión", ""), 0);
         cmbavSdtusuario_usuarioproducto.addItem("Empleado", context.GetMessage( "Empleado", ""), 0);
         cmbavSdtusuario_usuarioproducto.addItem("OTR/Camión", context.GetMessage( "OTR/Camión", ""), 0);
         if ( cmbavSdtusuario_usuarioproducto.ItemCount > 0 )
         {
            AV5SDTUsuario.gxTpr_Usuarioproducto = cmbavSdtusuario_usuarioproducto.getValidValue(AV5SDTUsuario.gxTpr_Usuarioproducto);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavSdtusuario_usuarioid_Internalname = "SDTUSUARIO_USUARIOID";
         edtavSdtusuario_usuarionombre_Internalname = "SDTUSUARIO_USUARIONOMBRE";
         edtavSdtusuario_usuariocorreo_Internalname = "SDTUSUARIO_USUARIOCORREO";
         cmbavSdtusuario_usuariorol_Internalname = "SDTUSUARIO_USUARIOROL";
         edtavSdtusuario_usuarioapellido_Internalname = "SDTUSUARIO_USUARIOAPELLIDO";
         edtavSdtusuario_usuarionombrecompleto_Internalname = "SDTUSUARIO_USUARIONOMBRECOMPLETO";
         edtavSdtusuario_puestoid_Internalname = "SDTUSUARIO_PUESTOID";
         edtavSdtusuario_puestodescripcion_Internalname = "SDTUSUARIO_PUESTODESCRIPCION";
         cmbavSdtusuario_usuariogenero_Internalname = "SDTUSUARIO_USUARIOGENERO";
         cmbavSdtusuario_usuariodirectoasociado_Internalname = "SDTUSUARIO_USUARIODIRECTOASOCIADO";
         edtavSdtusuario_usuariorazonsocialasociado_Internalname = "SDTUSUARIO_USUARIORAZONSOCIALASOCIADO";
         edtavSdtusuario_usuarionombrecomercial_Internalname = "SDTUSUARIO_USUARIONOMBRECOMERCIAL";
         edtavSdtusuario_usuariofechanacimiento_Internalname = "SDTUSUARIO_USUARIOFECHANACIMIENTO";
         edtavSdtusuario_usuariocallenum_Internalname = "SDTUSUARIO_USUARIOCALLENUM";
         edtavSdtusuario_usuariocolonia_Internalname = "SDTUSUARIO_USUARIOCOLONIA";
         edtavSdtusuario_usuariodelegacion_Internalname = "SDTUSUARIO_USUARIODELEGACION";
         edtavSdtusuario_usuariocp_Internalname = "SDTUSUARIO_USUARIOCP";
         cmbavSdtusuario_usuariozona_Internalname = "SDTUSUARIO_USUARIOZONA";
         edtavSdtusuario_usuariocelular_Internalname = "SDTUSUARIO_USUARIOCELULAR";
         edtavSdtusuario_usuariotelefonosucursal_Internalname = "SDTUSUARIO_USUARIOTELEFONOSUCURSAL";
         edtavSdtusuario_paisid_Internalname = "SDTUSUARIO_PAISID";
         edtavSdtusuario_paisdescripcion_Internalname = "SDTUSUARIO_PAISDESCRIPCION";
         edtavSdtusuario_estadoid_Internalname = "SDTUSUARIO_ESTADOID";
         edtavSdtusuario_estadodescripcion_Internalname = "SDTUSUARIO_ESTADODESCRIPCION";
         edtavSdtusuario_ciudadid_Internalname = "SDTUSUARIO_CIUDADID";
         edtavSdtusuario_ciudaddescripcion_Internalname = "SDTUSUARIO_CIUDADDESCRIPCION";
         edtavSdtusuario_usuariosucursal_Internalname = "SDTUSUARIO_USUARIOSUCURSAL";
         cmbavSdtusuario_usuarioproducto_Internalname = "SDTUSUARIO_USUARIOPRODUCTO";
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
         cmbavSdtusuario_usuarioproducto.Enabled = -1;
         edtavSdtusuario_usuariosucursal_Enabled = -1;
         edtavSdtusuario_ciudaddescripcion_Enabled = -1;
         edtavSdtusuario_ciudadid_Enabled = -1;
         edtavSdtusuario_estadodescripcion_Enabled = -1;
         edtavSdtusuario_estadoid_Enabled = -1;
         edtavSdtusuario_paisdescripcion_Enabled = -1;
         edtavSdtusuario_paisid_Enabled = -1;
         edtavSdtusuario_usuariotelefonosucursal_Enabled = -1;
         edtavSdtusuario_usuariocelular_Enabled = -1;
         cmbavSdtusuario_usuariozona.Enabled = -1;
         edtavSdtusuario_usuariocp_Enabled = -1;
         edtavSdtusuario_usuariodelegacion_Enabled = -1;
         edtavSdtusuario_usuariocolonia_Enabled = -1;
         edtavSdtusuario_usuariocallenum_Enabled = -1;
         edtavSdtusuario_usuariofechanacimiento_Enabled = -1;
         edtavSdtusuario_usuarionombrecomercial_Enabled = -1;
         edtavSdtusuario_usuariorazonsocialasociado_Enabled = -1;
         cmbavSdtusuario_usuariodirectoasociado.Enabled = -1;
         cmbavSdtusuario_usuariogenero.Enabled = -1;
         edtavSdtusuario_puestodescripcion_Enabled = -1;
         edtavSdtusuario_puestoid_Enabled = -1;
         edtavSdtusuario_usuarionombrecompleto_Enabled = -1;
         edtavSdtusuario_usuarioapellido_Enabled = -1;
         cmbavSdtusuario_usuariorol.Enabled = -1;
         edtavSdtusuario_usuariocorreo_Enabled = -1;
         edtavSdtusuario_usuarionombre_Enabled = -1;
         edtavSdtusuario_usuarioid_Enabled = -1;
         cmbavSdtusuario_usuarioproducto_Jsonclick = "";
         cmbavSdtusuario_usuarioproducto.Enabled = 0;
         edtavSdtusuario_usuariosucursal_Jsonclick = "";
         edtavSdtusuario_usuariosucursal_Enabled = 0;
         edtavSdtusuario_ciudaddescripcion_Jsonclick = "";
         edtavSdtusuario_ciudaddescripcion_Enabled = 0;
         edtavSdtusuario_ciudadid_Jsonclick = "";
         edtavSdtusuario_ciudadid_Enabled = 0;
         edtavSdtusuario_estadodescripcion_Jsonclick = "";
         edtavSdtusuario_estadodescripcion_Enabled = 0;
         edtavSdtusuario_estadoid_Jsonclick = "";
         edtavSdtusuario_estadoid_Enabled = 0;
         edtavSdtusuario_paisdescripcion_Jsonclick = "";
         edtavSdtusuario_paisdescripcion_Enabled = 0;
         edtavSdtusuario_paisid_Jsonclick = "";
         edtavSdtusuario_paisid_Enabled = 0;
         edtavSdtusuario_usuariotelefonosucursal_Jsonclick = "";
         edtavSdtusuario_usuariotelefonosucursal_Enabled = 0;
         edtavSdtusuario_usuariocelular_Jsonclick = "";
         edtavSdtusuario_usuariocelular_Enabled = 0;
         cmbavSdtusuario_usuariozona_Jsonclick = "";
         cmbavSdtusuario_usuariozona.Enabled = 0;
         edtavSdtusuario_usuariocp_Jsonclick = "";
         edtavSdtusuario_usuariocp_Enabled = 0;
         edtavSdtusuario_usuariodelegacion_Jsonclick = "";
         edtavSdtusuario_usuariodelegacion_Enabled = 0;
         edtavSdtusuario_usuariocolonia_Jsonclick = "";
         edtavSdtusuario_usuariocolonia_Enabled = 0;
         edtavSdtusuario_usuariocallenum_Jsonclick = "";
         edtavSdtusuario_usuariocallenum_Enabled = 0;
         edtavSdtusuario_usuariofechanacimiento_Jsonclick = "";
         edtavSdtusuario_usuariofechanacimiento_Enabled = 0;
         edtavSdtusuario_usuarionombrecomercial_Jsonclick = "";
         edtavSdtusuario_usuarionombrecomercial_Enabled = 0;
         edtavSdtusuario_usuariorazonsocialasociado_Jsonclick = "";
         edtavSdtusuario_usuariorazonsocialasociado_Enabled = 0;
         cmbavSdtusuario_usuariodirectoasociado_Jsonclick = "";
         cmbavSdtusuario_usuariodirectoasociado.Enabled = 0;
         cmbavSdtusuario_usuariogenero_Jsonclick = "";
         cmbavSdtusuario_usuariogenero.Enabled = 0;
         edtavSdtusuario_puestodescripcion_Jsonclick = "";
         edtavSdtusuario_puestodescripcion_Enabled = 0;
         edtavSdtusuario_puestoid_Jsonclick = "";
         edtavSdtusuario_puestoid_Enabled = 0;
         edtavSdtusuario_usuarionombrecompleto_Jsonclick = "";
         edtavSdtusuario_usuarionombrecompleto_Enabled = 0;
         edtavSdtusuario_usuarioapellido_Jsonclick = "";
         edtavSdtusuario_usuarioapellido_Enabled = 0;
         cmbavSdtusuario_usuariorol_Jsonclick = "";
         cmbavSdtusuario_usuariorol.Enabled = 0;
         edtavSdtusuario_usuariocorreo_Jsonclick = "";
         edtavSdtusuario_usuariocorreo_Enabled = 0;
         edtavSdtusuario_usuarionombre_Jsonclick = "";
         edtavSdtusuario_usuarionombre_Enabled = 0;
         edtavSdtusuario_usuarioid_Jsonclick = "";
         edtavSdtusuario_usuarioid_Enabled = 0;
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
         Form.Caption = context.GetMessage( "WPData User Sesion", "");
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
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV9","""{"handler":"Validv_Gxv9","iparms":[]}""");
         setEventMetadata("VALIDV_GXV10","""{"handler":"Validv_Gxv10","iparms":[]}""");
         setEventMetadata("VALIDV_GXV18","""{"handler":"Validv_Gxv18","iparms":[]}""");
         setEventMetadata("VALIDV_GXV28","""{"handler":"Validv_Gxv28","iparms":[]}""");
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
         AV5SDTUsuario = new SdtSDTUsuario(context);
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
         AV6UsuarioJSON = "";
         AV7WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         edtavSdtusuario_usuarioid_Enabled = 0;
         edtavSdtusuario_usuarionombre_Enabled = 0;
         edtavSdtusuario_usuariocorreo_Enabled = 0;
         cmbavSdtusuario_usuariorol.Enabled = 0;
         edtavSdtusuario_usuarioapellido_Enabled = 0;
         edtavSdtusuario_usuarionombrecompleto_Enabled = 0;
         edtavSdtusuario_puestoid_Enabled = 0;
         edtavSdtusuario_puestodescripcion_Enabled = 0;
         cmbavSdtusuario_usuariogenero.Enabled = 0;
         cmbavSdtusuario_usuariodirectoasociado.Enabled = 0;
         edtavSdtusuario_usuariorazonsocialasociado_Enabled = 0;
         edtavSdtusuario_usuarionombrecomercial_Enabled = 0;
         edtavSdtusuario_usuariofechanacimiento_Enabled = 0;
         edtavSdtusuario_usuariocallenum_Enabled = 0;
         edtavSdtusuario_usuariocolonia_Enabled = 0;
         edtavSdtusuario_usuariodelegacion_Enabled = 0;
         edtavSdtusuario_usuariocp_Enabled = 0;
         cmbavSdtusuario_usuariozona.Enabled = 0;
         edtavSdtusuario_usuariocelular_Enabled = 0;
         edtavSdtusuario_usuariotelefonosucursal_Enabled = 0;
         edtavSdtusuario_paisid_Enabled = 0;
         edtavSdtusuario_paisdescripcion_Enabled = 0;
         edtavSdtusuario_estadoid_Enabled = 0;
         edtavSdtusuario_estadodescripcion_Enabled = 0;
         edtavSdtusuario_ciudadid_Enabled = 0;
         edtavSdtusuario_ciudaddescripcion_Enabled = 0;
         edtavSdtusuario_usuariosucursal_Enabled = 0;
         cmbavSdtusuario_usuarioproducto.Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavSdtusuario_usuarioid_Enabled ;
      private int edtavSdtusuario_usuarionombre_Enabled ;
      private int edtavSdtusuario_usuariocorreo_Enabled ;
      private int edtavSdtusuario_usuarioapellido_Enabled ;
      private int edtavSdtusuario_usuarionombrecompleto_Enabled ;
      private int edtavSdtusuario_puestoid_Enabled ;
      private int edtavSdtusuario_puestodescripcion_Enabled ;
      private int edtavSdtusuario_usuariorazonsocialasociado_Enabled ;
      private int edtavSdtusuario_usuarionombrecomercial_Enabled ;
      private int edtavSdtusuario_usuariofechanacimiento_Enabled ;
      private int edtavSdtusuario_usuariocallenum_Enabled ;
      private int edtavSdtusuario_usuariocolonia_Enabled ;
      private int edtavSdtusuario_usuariodelegacion_Enabled ;
      private int edtavSdtusuario_usuariocp_Enabled ;
      private int edtavSdtusuario_usuariocelular_Enabled ;
      private int edtavSdtusuario_usuariotelefonosucursal_Enabled ;
      private int edtavSdtusuario_paisid_Enabled ;
      private int edtavSdtusuario_paisdescripcion_Enabled ;
      private int edtavSdtusuario_estadoid_Enabled ;
      private int edtavSdtusuario_estadodescripcion_Enabled ;
      private int edtavSdtusuario_ciudadid_Enabled ;
      private int edtavSdtusuario_ciudaddescripcion_Enabled ;
      private int edtavSdtusuario_usuariosucursal_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string edtavSdtusuario_usuarioid_Internalname ;
      private string TempTags ;
      private string edtavSdtusuario_usuarioid_Jsonclick ;
      private string edtavSdtusuario_usuarionombre_Internalname ;
      private string edtavSdtusuario_usuarionombre_Jsonclick ;
      private string edtavSdtusuario_usuariocorreo_Internalname ;
      private string edtavSdtusuario_usuariocorreo_Jsonclick ;
      private string cmbavSdtusuario_usuariorol_Internalname ;
      private string cmbavSdtusuario_usuariorol_Jsonclick ;
      private string edtavSdtusuario_usuarioapellido_Internalname ;
      private string edtavSdtusuario_usuarioapellido_Jsonclick ;
      private string edtavSdtusuario_usuarionombrecompleto_Internalname ;
      private string edtavSdtusuario_usuarionombrecompleto_Jsonclick ;
      private string edtavSdtusuario_puestoid_Internalname ;
      private string edtavSdtusuario_puestoid_Jsonclick ;
      private string edtavSdtusuario_puestodescripcion_Internalname ;
      private string edtavSdtusuario_puestodescripcion_Jsonclick ;
      private string cmbavSdtusuario_usuariogenero_Internalname ;
      private string cmbavSdtusuario_usuariogenero_Jsonclick ;
      private string cmbavSdtusuario_usuariodirectoasociado_Internalname ;
      private string cmbavSdtusuario_usuariodirectoasociado_Jsonclick ;
      private string edtavSdtusuario_usuariorazonsocialasociado_Internalname ;
      private string edtavSdtusuario_usuariorazonsocialasociado_Jsonclick ;
      private string edtavSdtusuario_usuarionombrecomercial_Internalname ;
      private string edtavSdtusuario_usuarionombrecomercial_Jsonclick ;
      private string edtavSdtusuario_usuariofechanacimiento_Internalname ;
      private string edtavSdtusuario_usuariofechanacimiento_Jsonclick ;
      private string edtavSdtusuario_usuariocallenum_Internalname ;
      private string edtavSdtusuario_usuariocallenum_Jsonclick ;
      private string edtavSdtusuario_usuariocolonia_Internalname ;
      private string edtavSdtusuario_usuariocolonia_Jsonclick ;
      private string edtavSdtusuario_usuariodelegacion_Internalname ;
      private string edtavSdtusuario_usuariodelegacion_Jsonclick ;
      private string edtavSdtusuario_usuariocp_Internalname ;
      private string edtavSdtusuario_usuariocp_Jsonclick ;
      private string cmbavSdtusuario_usuariozona_Internalname ;
      private string cmbavSdtusuario_usuariozona_Jsonclick ;
      private string edtavSdtusuario_usuariocelular_Internalname ;
      private string edtavSdtusuario_usuariocelular_Jsonclick ;
      private string edtavSdtusuario_usuariotelefonosucursal_Internalname ;
      private string edtavSdtusuario_usuariotelefonosucursal_Jsonclick ;
      private string edtavSdtusuario_paisid_Internalname ;
      private string edtavSdtusuario_paisid_Jsonclick ;
      private string edtavSdtusuario_paisdescripcion_Internalname ;
      private string edtavSdtusuario_paisdescripcion_Jsonclick ;
      private string edtavSdtusuario_estadoid_Internalname ;
      private string edtavSdtusuario_estadoid_Jsonclick ;
      private string edtavSdtusuario_estadodescripcion_Internalname ;
      private string edtavSdtusuario_estadodescripcion_Jsonclick ;
      private string edtavSdtusuario_ciudadid_Internalname ;
      private string edtavSdtusuario_ciudadid_Jsonclick ;
      private string edtavSdtusuario_ciudaddescripcion_Internalname ;
      private string edtavSdtusuario_ciudaddescripcion_Jsonclick ;
      private string edtavSdtusuario_usuariosucursal_Internalname ;
      private string edtavSdtusuario_usuariosucursal_Jsonclick ;
      private string cmbavSdtusuario_usuarioproducto_Internalname ;
      private string cmbavSdtusuario_usuarioproducto_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
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
      private string AV6UsuarioJSON ;
      private IGxSession AV7WebSession ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavSdtusuario_usuariorol ;
      private GXCombobox cmbavSdtusuario_usuariogenero ;
      private GXCombobox cmbavSdtusuario_usuariodirectoasociado ;
      private GXCombobox cmbavSdtusuario_usuariozona ;
      private GXCombobox cmbavSdtusuario_usuarioproducto ;
      private SdtSDTUsuario AV5SDTUsuario ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
