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
   public class wpcambiarestatus : GXDataArea
   {
      public wpcambiarestatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpcambiarestatus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           int aP1_FacturaID )
      {
         this.AV10TrnMode = aP0_TrnMode;
         this.AV14FacturaID = aP1_FacturaID;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavEstatusadmin = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "TrnMode");
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
               gxfirstwebparm = GetFirstPar( "TrnMode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TrnMode");
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageprompt", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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
         PA3A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3A2( ) ;
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpcambiarestatus.aspx"+UrlEncode(StringUtil.RTrim(AV10TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV14FacturaID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("wpcambiarestatus.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV10TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14FacturaID), "ZZZZZZZZ9"), context));
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMOTIVORECHAZOID_DATA", AV16MotivoRechazoID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMOTIVORECHAZOID_DATA", AV16MotivoRechazoID_Data);
         }
         GxWebStd.gx_hidden_field( context, "vFACTURAESTATUS", StringUtil.RTrim( AV18FacturaEstatus));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV12CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV9Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV9Messages);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV10TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14FacturaID), "ZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFACTURA", AV5Factura);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFACTURA", AV5Factura);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_MOTIVORECHAZOID_Cls", StringUtil.RTrim( Combo_motivorechazoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MOTIVORECHAZOID_Selectedvalue_set", StringUtil.RTrim( Combo_motivorechazoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MOTIVORECHAZOID_Visible", StringUtil.BoolToStr( Combo_motivorechazoid_Visible));
         GxWebStd.gx_hidden_field( context, "COMBO_MOTIVORECHAZOID_Selectedvalue_get", StringUtil.RTrim( Combo_motivorechazoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_MOTIVORECHAZOID_Ddointernalname", StringUtil.RTrim( Combo_motivorechazoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_MOTIVORECHAZOID_Ddointernalname", StringUtil.RTrim( Combo_motivorechazoid_Ddointernalname));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE3A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3A2( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpcambiarestatus.aspx"+UrlEncode(StringUtil.RTrim(AV10TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV14FacturaID,9,0));
         return formatLink("wpcambiarestatus.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WPCambiarEstatus" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Cambiar Estatus", "") ;
      }

      protected void WB3A0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransactionPopUp", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavEstatusadmin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavEstatusadmin_Internalname, context.GetMessage( "Estatus", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEstatusadmin, cmbavEstatusadmin_Internalname, StringUtil.RTrim( AV17EstatusAdmin), 1, cmbavEstatusadmin_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavEstatusadmin.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "", true, 0, "HLP_WPCambiarEstatus.htm");
            cmbavEstatusadmin.CurrentValue = StringUtil.RTrim( AV17EstatusAdmin);
            AssignProp("", false, cmbavEstatusadmin_Internalname, "Values", (string)(cmbavEstatusadmin.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCombo_motivorechazoid_cell_Internalname, 1, 0, "px", 0, "px", divCombo_motivorechazoid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedmotivorechazoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_motivorechazoid_Internalname, context.GetMessage( "Motivo de rechazo", ""), "", "", lblTextblockcombo_motivorechazoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPCambiarEstatus.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_motivorechazoid.SetProperty("Caption", Combo_motivorechazoid_Caption);
            ucCombo_motivorechazoid.SetProperty("Cls", Combo_motivorechazoid_Cls);
            ucCombo_motivorechazoid.SetProperty("DropDownOptionsData", AV16MotivoRechazoID_Data);
            ucCombo_motivorechazoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_motivorechazoid_Internalname, "COMBO_MOTIVORECHAZOIDContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPCambiarEstatus.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPCambiarEstatus.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMotivorechazoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15MotivoRechazoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15MotivoRechazoID), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMotivorechazoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavMotivorechazoid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPCambiarEstatus.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFactura_facturaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Factura.gxTpr_Facturaid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Factura.gxTpr_Facturaid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFactura_facturaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavFactura_facturaid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPCambiarEstatus.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3A2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Cambiar Estatus", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3A0( ) ;
      }

      protected void WS3A2( )
      {
         START3A2( ) ;
         EVT3A2( ) ;
      }

      protected void EVT3A2( )
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
                              E113A2 ();
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
                                    E123A2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E133A2 ();
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

      protected void WE3A2( )
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

      protected void PA3A2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpcambiarestatus.aspx")), "wpcambiarestatus.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpcambiarestatus.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "TrnMode");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV10TrnMode = gxfirstwebparm;
                     AssignAttri("", false, "AV10TrnMode", AV10TrnMode);
                     GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV14FacturaID = (int)(Math.Round(NumberUtil.Val( GetPar( "FacturaID"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV14FacturaID", StringUtil.LTrimStr( (decimal)(AV14FacturaID), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vFACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14FacturaID), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = cmbavEstatusadmin_Internalname;
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
         if ( cmbavEstatusadmin.ItemCount > 0 )
         {
            AV17EstatusAdmin = cmbavEstatusadmin.getValidValue(AV17EstatusAdmin);
            AssignAttri("", false, "AV17EstatusAdmin", AV17EstatusAdmin);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEstatusadmin.CurrentValue = StringUtil.RTrim( AV17EstatusAdmin);
            AssignProp("", false, cmbavEstatusadmin_Internalname, "Values", cmbavEstatusadmin.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF3A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E133A2 ();
            WB3A0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3A2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFACTURA"), AV5Factura);
            ajax_req_read_hidden_sdt(cgiGet( "Factura"), AV5Factura);
            ajax_req_read_hidden_sdt(cgiGet( "vMOTIVORECHAZOID_DATA"), AV16MotivoRechazoID_Data);
            /* Read saved values. */
            Combo_motivorechazoid_Cls = cgiGet( "COMBO_MOTIVORECHAZOID_Cls");
            Combo_motivorechazoid_Selectedvalue_set = cgiGet( "COMBO_MOTIVORECHAZOID_Selectedvalue_set");
            Combo_motivorechazoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_MOTIVORECHAZOID_Visible"));
            Combo_motivorechazoid_Ddointernalname = cgiGet( "COMBO_MOTIVORECHAZOID_Ddointernalname");
            /* Read variables values. */
            cmbavEstatusadmin.CurrentValue = cgiGet( cmbavEstatusadmin_Internalname);
            AV17EstatusAdmin = cgiGet( cmbavEstatusadmin_Internalname);
            AssignAttri("", false, "AV17EstatusAdmin", AV17EstatusAdmin);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMotivorechazoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMotivorechazoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMOTIVORECHAZOID");
               GX_FocusControl = edtavMotivorechazoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15MotivoRechazoID = 0;
               AssignAttri("", false, "AV15MotivoRechazoID", StringUtil.LTrimStr( (decimal)(AV15MotivoRechazoID), 9, 0));
            }
            else
            {
               AV15MotivoRechazoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavMotivorechazoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15MotivoRechazoID", StringUtil.LTrimStr( (decimal)(AV15MotivoRechazoID), 9, 0));
            }
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
         E113A2 ();
         if (returnInSub) return;
      }

      protected void E113A2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV11LoadSuccess = true;
         if ( StringUtil.StrCmp(AV10TrnMode, "UPD") == 0 )
         {
            AV5Factura.Load(AV14FacturaID);
            AV11LoadSuccess = AV5Factura.Success();
            if ( ! AV11LoadSuccess )
            {
               AV9Messages = AV5Factura.GetMessages();
               /* Execute user subroutine: 'SHOW MESSAGES' */
               S112 ();
               if (returnInSub) return;
            }
         }
         else
         {
            AV11LoadSuccess = false;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         edtavMotivorechazoid_Visible = 0;
         AssignProp("", false, edtavMotivorechazoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMotivorechazoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOMOTIVORECHAZOID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if (returnInSub) return;
         edtavFactura_facturaid_Visible = 0;
         AssignProp("", false, edtavFactura_facturaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFactura_facturaid_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV5Factura.gxTpr_Facturaestatus, "En Proceso") == 0 )
         {
            AV17EstatusAdmin = "En Proceso";
            AssignAttri("", false, "AV17EstatusAdmin", AV17EstatusAdmin);
         }
         else if ( StringUtil.StrCmp(AV5Factura.gxTpr_Facturaestatus, "Aprobada") == 0 )
         {
            AV17EstatusAdmin = "Aprobada";
            AssignAttri("", false, "AV17EstatusAdmin", AV17EstatusAdmin);
         }
         else if ( StringUtil.StrCmp(AV5Factura.gxTpr_Facturaestatus, "Rechazada") == 0 )
         {
            AV17EstatusAdmin = "Rechazada";
            AssignAttri("", false, "AV17EstatusAdmin", AV17EstatusAdmin);
         }
         else if ( StringUtil.StrCmp(AV5Factura.gxTpr_Facturaestatus, "Cancelada") == 0 )
         {
            AV17EstatusAdmin = "";
            AssignAttri("", false, "AV17EstatusAdmin", AV17EstatusAdmin);
         }
         if ( StringUtil.StrCmp(AV5Factura.gxTpr_Facturaestatus, "Rechazada") == 0 )
         {
            Combo_motivorechazoid_Visible = true;
            ucCombo_motivorechazoid.SendProperty(context, "", false, Combo_motivorechazoid_Internalname, "Visible", StringUtil.BoolToStr( Combo_motivorechazoid_Visible));
         }
         else
         {
            edtavMotivorechazoid_Visible = 0;
            AssignProp("", false, edtavMotivorechazoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMotivorechazoid_Visible), 5, 0), true);
            Combo_motivorechazoid_Visible = false;
            ucCombo_motivorechazoid.SendProperty(context, "", false, Combo_motivorechazoid_Internalname, "Visible", StringUtil.BoolToStr( Combo_motivorechazoid_Visible));
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E123A2 ();
         if (returnInSub) return;
      }

      protected void E123A2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17EstatusAdmin, "Aprobada") == 0 )
         {
            AV18FacturaEstatus = "Aprobada";
            AssignAttri("", false, "AV18FacturaEstatus", AV18FacturaEstatus);
         }
         else if ( StringUtil.StrCmp(AV17EstatusAdmin, "En Proceso") == 0 )
         {
            AV18FacturaEstatus = "En Proceso";
            AssignAttri("", false, "AV18FacturaEstatus", AV18FacturaEstatus);
         }
         else if ( StringUtil.StrCmp(AV17EstatusAdmin, "Rechazada") == 0 )
         {
            AV18FacturaEstatus = "Rechazada";
            AssignAttri("", false, "AV18FacturaEstatus", AV18FacturaEstatus);
         }
         AV5Factura.gxTpr_Facturaestatus = AV18FacturaEstatus;
         AV5Factura.gxTpr_Motivorechazoid = AV15MotivoRechazoID;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S142 ();
         if (returnInSub) return;
         if ( AV12CheckRequiredFieldsResult )
         {
            AV5Factura.Save();
            if ( AV5Factura.Success() )
            {
               /* Execute user subroutine: 'AFTER_TRN' */
               S152 ();
               if (returnInSub) return;
            }
            else
            {
               AV9Messages = AV5Factura.GetMessages();
               /* Execute user subroutine: 'SHOW MESSAGES' */
               S112 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Factura", AV5Factura);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9Messages", AV9Messages);
      }

      protected void S142( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV12CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17EstatusAdmin)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Estatus", ""), "", "", "", "", "", "", "", ""),  "error",  cmbavEstatusadmin_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( ( ( StringUtil.StrCmp(AV17EstatusAdmin, "Rechazada") == 0 ) ) && (0==AV15MotivoRechazoID) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Motivo de rechazo", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_motivorechazoid_Ddointernalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
      }

      protected void S132( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17EstatusAdmin, "Rechazada") == 0 )
         {
            divCombo_motivorechazoid_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell";
            AssignProp("", false, divCombo_motivorechazoid_cell_Internalname, "Class", divCombo_motivorechazoid_cell_Class, true);
         }
         else
         {
            divCombo_motivorechazoid_cell_Class = "col-xs-12 DataContentCellFL ExtendedComboCell";
            AssignProp("", false, divCombo_motivorechazoid_cell_Internalname, "Class", divCombo_motivorechazoid_cell_Class, true);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOMOTIVORECHAZOID' Routine */
         returnInSub = false;
         /* Using cursor H003A2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A19MotivoRechazoID = H003A2_A19MotivoRechazoID[0];
            A20MotivoRechazoDescripcion = H003A2_A20MotivoRechazoDescripcion[0];
            AV7Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV7Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A19MotivoRechazoID), 9, 0));
            AV7Combo_DataItem.gxTpr_Title = A20MotivoRechazoDescripcion;
            AV16MotivoRechazoID_Data.Add(AV7Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_motivorechazoid_Selectedvalue_set = ((0==AV15MotivoRechazoID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV15MotivoRechazoID), 9, 0)));
         ucCombo_motivorechazoid.SendProperty(context, "", false, Combo_motivorechazoid_Internalname, "SelectedValue_set", Combo_motivorechazoid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV21GXV2 = 1;
         while ( AV21GXV2 <= AV9Messages.Count )
         {
            AV8Message = ((GeneXus.Utils.SdtMessages_Message)AV9Messages.Item(AV21GXV2));
            GX_msglist.addItem(AV8Message.gxTpr_Description);
            AV21GXV2 = (int)(AV21GXV2+1);
         }
      }

      protected void S152( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("wpcambiarestatus",pr_default);
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

      protected void E133A2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV10TrnMode", AV10TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
         AV14FacturaID = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV14FacturaID", StringUtil.LTrimStr( (decimal)(AV14FacturaID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vFACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14FacturaID), "ZZZZZZZZ9"), context));
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
         PA3A2( ) ;
         WS3A2( ) ;
         WE3A2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20265111131837", true, true);
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
         context.AddJavascriptSource("wpcambiarestatus.js", "?20265111131837", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavEstatusadmin.Name = "vESTATUSADMIN";
         cmbavEstatusadmin.WebTags = "";
         cmbavEstatusadmin.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavEstatusadmin.addItem("En Proceso", context.GetMessage( "En Proceso", ""), 0);
         cmbavEstatusadmin.addItem("Aprobada", context.GetMessage( "Aprobada", ""), 0);
         cmbavEstatusadmin.addItem("Rechazada", context.GetMessage( "Rechazada", ""), 0);
         if ( cmbavEstatusadmin.ItemCount > 0 )
         {
            AV17EstatusAdmin = cmbavEstatusadmin.getValidValue(AV17EstatusAdmin);
            AssignAttri("", false, "AV17EstatusAdmin", AV17EstatusAdmin);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavEstatusadmin_Internalname = "vESTATUSADMIN";
         lblTextblockcombo_motivorechazoid_Internalname = "TEXTBLOCKCOMBO_MOTIVORECHAZOID";
         Combo_motivorechazoid_Internalname = "COMBO_MOTIVORECHAZOID";
         divTablesplittedmotivorechazoid_Internalname = "TABLESPLITTEDMOTIVORECHAZOID";
         divCombo_motivorechazoid_cell_Internalname = "COMBO_MOTIVORECHAZOID_CELL";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavMotivorechazoid_Internalname = "vMOTIVORECHAZOID";
         edtavFactura_facturaid_Internalname = "FACTURA_FACTURAID";
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
         edtavFactura_facturaid_Jsonclick = "";
         edtavFactura_facturaid_Visible = 1;
         edtavMotivorechazoid_Jsonclick = "";
         edtavMotivorechazoid_Visible = 1;
         divCombo_motivorechazoid_cell_Class = "col-xs-12";
         cmbavEstatusadmin_Jsonclick = "";
         cmbavEstatusadmin.Enabled = 1;
         Combo_motivorechazoid_Visible = Convert.ToBoolean( -1);
         Combo_motivorechazoid_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Cambiar Estatus", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV14FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("ENTER","""{"handler":"E123A2","iparms":[{"av":"cmbavEstatusadmin"},{"av":"AV17EstatusAdmin","fld":"vESTATUSADMIN"},{"av":"AV18FacturaEstatus","fld":"vFACTURAESTATUS"},{"av":"AV5Factura","fld":"vFACTURA"},{"av":"AV15MotivoRechazoID","fld":"vMOTIVORECHAZOID","pic":"ZZZZZZZZ9"},{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"Combo_motivorechazoid_Ddointernalname","ctrl":"COMBO_MOTIVORECHAZOID","prop":"DDOInternalName"},{"av":"AV9Messages","fld":"vMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV18FacturaEstatus","fld":"vFACTURAESTATUS"},{"av":"AV5Factura","fld":"vFACTURA"},{"av":"AV9Messages","fld":"vMESSAGES"},{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VALIDV_ESTATUSADMIN","""{"handler":"Validv_Estatusadmin","iparms":[]}""");
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
         wcpOAV10TrnMode = "";
         Combo_motivorechazoid_Selectedvalue_get = "";
         Combo_motivorechazoid_Ddointernalname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV5Factura = new SdtFactura(context);
         AV16MotivoRechazoID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV18FacturaEstatus = "En Proceso";
         AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         Combo_motivorechazoid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV17EstatusAdmin = "";
         lblTextblockcombo_motivorechazoid_Jsonclick = "";
         ucCombo_motivorechazoid = new GXUserControl();
         Combo_motivorechazoid_Caption = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H003A2_A19MotivoRechazoID = new int[1] ;
         H003A2_A20MotivoRechazoDescripcion = new string[] {""} ;
         A20MotivoRechazoDescripcion = "";
         AV7Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV8Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpcambiarestatus__default(),
            new Object[][] {
                new Object[] {
               H003A2_A19MotivoRechazoID, H003A2_A20MotivoRechazoDescripcion
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV14FacturaID ;
      private int wcpOAV14FacturaID ;
      private int AV15MotivoRechazoID ;
      private int edtavMotivorechazoid_Visible ;
      private int edtavFactura_facturaid_Visible ;
      private int A19MotivoRechazoID ;
      private int AV21GXV2 ;
      private int idxLst ;
      private string AV10TrnMode ;
      private string wcpOAV10TrnMode ;
      private string Combo_motivorechazoid_Selectedvalue_get ;
      private string Combo_motivorechazoid_Ddointernalname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV18FacturaEstatus ;
      private string Combo_motivorechazoid_Cls ;
      private string Combo_motivorechazoid_Selectedvalue_set ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableattributes_Internalname ;
      private string cmbavEstatusadmin_Internalname ;
      private string TempTags ;
      private string AV17EstatusAdmin ;
      private string cmbavEstatusadmin_Jsonclick ;
      private string divCombo_motivorechazoid_cell_Internalname ;
      private string divCombo_motivorechazoid_cell_Class ;
      private string divTablesplittedmotivorechazoid_Internalname ;
      private string lblTextblockcombo_motivorechazoid_Internalname ;
      private string lblTextblockcombo_motivorechazoid_Jsonclick ;
      private string Combo_motivorechazoid_Caption ;
      private string Combo_motivorechazoid_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavMotivorechazoid_Internalname ;
      private string edtavMotivorechazoid_Jsonclick ;
      private string edtavFactura_facturaid_Internalname ;
      private string edtavFactura_facturaid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12CheckRequiredFieldsResult ;
      private bool Combo_motivorechazoid_Visible ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV11LoadSuccess ;
      private string A20MotivoRechazoDescripcion ;
      private GXUserControl ucCombo_motivorechazoid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavEstatusadmin ;
      private SdtFactura AV5Factura ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV16MotivoRechazoID_Data ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9Messages ;
      private IDataStoreProvider pr_default ;
      private int[] H003A2_A19MotivoRechazoID ;
      private string[] H003A2_A20MotivoRechazoDescripcion ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV7Combo_DataItem ;
      private GeneXus.Utils.SdtMessages_Message AV8Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpcambiarestatus__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003A2;
          prmH003A2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H003A2", "SELECT `MotivoRechazoID`, `MotivoRechazoDescripcion` FROM `MotivoRechazo` WHERE Not `MotivoRechazoID` = 0 ORDER BY `MotivoRechazoDescripcion` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003A2,100, GxCacheFrequency.OFF ,false,false )
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
