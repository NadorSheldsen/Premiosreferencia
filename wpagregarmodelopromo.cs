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
   public class wpagregarmodelopromo : GXDataArea
   {
      public wpagregarmodelopromo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpagregarmodelopromo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           int aP1_PromocionModeloID ,
                           int aP2_PromocionID )
      {
         this.AV10TrnMode = aP0_TrnMode;
         this.AV14PromocionModeloID = aP1_PromocionModeloID;
         this.AV15PromocionID = aP2_PromocionID;
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
         PA2R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2R2( ) ;
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
         GXEncryptionTmp = "wpagregarmodelopromo.aspx"+UrlEncode(StringUtil.RTrim(AV10TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV14PromocionModeloID,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV15PromocionID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("wpagregarmodelopromo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPROMOCIONMODELOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14PromocionModeloID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONMODELOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14PromocionModeloID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15PromocionID), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Promocionmodelo", AV5PromocionModelo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Promocionmodelo", AV5PromocionModelo);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROMOCIONMODELO_MODELOID_DATA", AV6PromocionModelo_ModeloID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROMOCIONMODELO_MODELOID_DATA", AV6PromocionModelo_ModeloID_Data);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV10TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV12CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "PROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15PromocionID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "MODELOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22ModeloID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROMOCIONMODELOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A48PromocionModeloID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV9Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV9Messages);
         }
         GxWebStd.gx_hidden_field( context, "vPROMOCIONMODELOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14PromocionModeloID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONMODELOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14PromocionModeloID), "ZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROMOCIONMODELO", AV5PromocionModelo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROMOCIONMODELO", AV5PromocionModelo);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONMODELO_MODELOID_Cls", StringUtil.RTrim( Combo_promocionmodelo_modeloid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONMODELO_MODELOID_Selectedvalue_set", StringUtil.RTrim( Combo_promocionmodelo_modeloid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONMODELO_MODELOID_Enabled", StringUtil.BoolToStr( Combo_promocionmodelo_modeloid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONMODELO_MODELOID_Selectedvalue_get", StringUtil.RTrim( Combo_promocionmodelo_modeloid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONMODELO_MODELOID_Ddointernalname", StringUtil.RTrim( Combo_promocionmodelo_modeloid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONMODELO_MODELOID_Ddointernalname", StringUtil.RTrim( Combo_promocionmodelo_modeloid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONMODELO_MODELOID_Selectedvalue_get", StringUtil.RTrim( Combo_promocionmodelo_modeloid_Selectedvalue_get));
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
            WE2R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2R2( ) ;
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
         GXEncryptionTmp = "wpagregarmodelopromo.aspx"+UrlEncode(StringUtil.RTrim(AV10TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV14PromocionModeloID,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV15PromocionID,9,0));
         return formatLink("wpagregarmodelopromo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WPAgregarModeloPromo" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WPAgregar Modelo Promo", "") ;
      }

      protected void WB2R0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedpromocionmodelo_modeloid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_promocionmodelo_modeloid_Internalname, context.GetMessage( "Modelo", ""), "", "", lblTextblockcombo_promocionmodelo_modeloid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPAgregarModeloPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_promocionmodelo_modeloid.SetProperty("Caption", Combo_promocionmodelo_modeloid_Caption);
            ucCombo_promocionmodelo_modeloid.SetProperty("Cls", Combo_promocionmodelo_modeloid_Cls);
            ucCombo_promocionmodelo_modeloid.SetProperty("DropDownOptionsData", AV6PromocionModelo_ModeloID_Data);
            ucCombo_promocionmodelo_modeloid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_promocionmodelo_modeloid_Internalname, "COMBO_PROMOCIONMODELO_MODELOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPromocionmodelo_promocionmodeloprecio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPromocionmodelo_promocionmodeloprecio_Internalname, context.GetMessage( "Comisión", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPromocionmodelo_promocionmodeloprecio_Internalname, StringUtil.LTrim( StringUtil.NToC( AV5PromocionModelo.gxTpr_Promocionmodeloprecio, 14, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( AV5PromocionModelo.gxTpr_Promocionmodeloprecio, "$ Z,ZZZ,ZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPromocionmodelo_promocionmodeloprecio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPromocionmodelo_promocionmodeloprecio_Enabled, 1, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPAgregarModeloPromo.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPAgregarModeloPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPAgregarModeloPromo.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavPromocionmodelo_promocionmodeloid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5PromocionModelo.gxTpr_Promocionmodeloid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5PromocionModelo.gxTpr_Promocionmodeloid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPromocionmodelo_promocionmodeloid_Jsonclick, 0, "Attribute", "", "", "", "", edtavPromocionmodelo_promocionmodeloid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPAgregarModeloPromo.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPromocionmodelo_promocionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5PromocionModelo.gxTpr_Promocionid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5PromocionModelo.gxTpr_Promocionid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPromocionmodelo_promocionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavPromocionmodelo_promocionid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPAgregarModeloPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2R2( )
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
         Form.Meta.addItem("description", context.GetMessage( "WPAgregar Modelo Promo", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2R0( ) ;
      }

      protected void WS2R2( )
      {
         START2R2( ) ;
         EVT2R2( ) ;
      }

      protected void EVT2R2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_PROMOCIONMODELO_MODELOID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_promocionmodelo_modeloid.Onoptionclicked */
                              E112R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E122R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E132R2 ();
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
                                    E142R2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E152R2 ();
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

      protected void WE2R2( )
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

      protected void PA2R2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpagregarmodelopromo.aspx")), "wpagregarmodelopromo.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpagregarmodelopromo.aspx")))) ;
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
                        AV14PromocionModeloID = (int)(Math.Round(NumberUtil.Val( GetPar( "PromocionModeloID"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV14PromocionModeloID", StringUtil.LTrimStr( (decimal)(AV14PromocionModeloID), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONMODELOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14PromocionModeloID), "ZZZZZZZZ9"), context));
                        AV15PromocionID = (int)(Math.Round(NumberUtil.Val( GetPar( "PromocionID"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV15PromocionID", StringUtil.LTrimStr( (decimal)(AV15PromocionID), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15PromocionID), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavPromocionmodelo_promocionmodeloprecio_Internalname;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E132R2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E152R2 ();
            WB2R0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2R2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vPROMOCIONMODELO"), AV5PromocionModelo);
            ajax_req_read_hidden_sdt(cgiGet( "Promocionmodelo"), AV5PromocionModelo);
            ajax_req_read_hidden_sdt(cgiGet( "vPROMOCIONMODELO_MODELOID_DATA"), AV6PromocionModelo_ModeloID_Data);
            /* Read saved values. */
            Combo_promocionmodelo_modeloid_Cls = cgiGet( "COMBO_PROMOCIONMODELO_MODELOID_Cls");
            Combo_promocionmodelo_modeloid_Selectedvalue_set = cgiGet( "COMBO_PROMOCIONMODELO_MODELOID_Selectedvalue_set");
            Combo_promocionmodelo_modeloid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PROMOCIONMODELO_MODELOID_Enabled"));
            Combo_promocionmodelo_modeloid_Ddointernalname = cgiGet( "COMBO_PROMOCIONMODELO_MODELOID_Ddointernalname");
            Combo_promocionmodelo_modeloid_Selectedvalue_get = cgiGet( "COMBO_PROMOCIONMODELO_MODELOID_Selectedvalue_get");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPromocionmodelo_promocionmodeloprecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPromocionmodelo_promocionmodeloprecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROMOCIONMODELO_PROMOCIONMODELOPRECIO");
               GX_FocusControl = edtavPromocionmodelo_promocionmodeloprecio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5PromocionModelo.gxTpr_Promocionmodeloprecio = 0;
            }
            else
            {
               AV5PromocionModelo.gxTpr_Promocionmodeloprecio = context.localUtil.CToN( cgiGet( edtavPromocionmodelo_promocionmodeloprecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPromocionmodelo_promocionmodeloid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPromocionmodelo_promocionmodeloid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROMOCIONMODELO_PROMOCIONMODELOID");
               GX_FocusControl = edtavPromocionmodelo_promocionmodeloid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5PromocionModelo.gxTpr_Promocionmodeloid = 0;
            }
            else
            {
               AV5PromocionModelo.gxTpr_Promocionmodeloid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPromocionmodelo_promocionmodeloid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPromocionmodelo_promocionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPromocionmodelo_promocionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROMOCIONMODELO_PROMOCIONID");
               GX_FocusControl = edtavPromocionmodelo_promocionid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5PromocionModelo.gxTpr_Promocionid = 0;
            }
            else
            {
               AV5PromocionModelo.gxTpr_Promocionid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPromocionmodelo_promocionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         E122R2 ();
         if (returnInSub) return;
      }

      protected void E122R2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Using cursor H002R2 */
         pr_default.execute(0, new Object[] {AV15PromocionID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A41PromocionID = H002R2_A41PromocionID[0];
            A68PromocionSegmentosJson = H002R2_A68PromocionSegmentosJson[0];
            AV16PromocionSegmentosJson = A68PromocionSegmentosJson;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV18SDTSegmentos.FromJSonString(AV16PromocionSegmentosJson, null);
         AV26GXV4 = 1;
         while ( AV26GXV4 <= AV18SDTSegmentos.Count )
         {
            AV19Item = ((SdtSDTSegmentos_Segmento)AV18SDTSegmentos.Item(AV26GXV4));
            AV21SegmentosSeleccionados.Add(AV19Item.gxTpr_Segmento, 0);
            AV26GXV4 = (int)(AV26GXV4+1);
         }
         AV11LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV10TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV10TrnMode, "INS") == 0 ) ) || ( ( StringUtil.StrCmp(AV10TrnMode, "UPD") == 0 ) ) || ( ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 ) ) )
         {
            if ( StringUtil.StrCmp(AV10TrnMode, "INS") != 0 )
            {
               AV5PromocionModelo.Load(AV14PromocionModeloID);
               AV11LoadSuccess = AV5PromocionModelo.Success();
               if ( ! AV11LoadSuccess )
               {
                  AV9Messages = AV5PromocionModelo.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV10TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 ) )
               {
                  Combo_promocionmodelo_modeloid_Enabled = false;
                  ucCombo_promocionmodelo_modeloid.SendProperty(context, "", false, Combo_promocionmodelo_modeloid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_promocionmodelo_modeloid_Enabled));
                  edtavPromocionmodelo_promocionmodeloprecio_Enabled = 0;
                  AssignProp("", false, edtavPromocionmodelo_promocionmodeloprecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPromocionmodelo_promocionmodeloprecio_Enabled), 5, 0), true);
               }
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
         if ( AV11LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""));
            }
         }
         /* Execute user subroutine: 'LOADCOMBOPROMOCIONMODELO_MODELOID' */
         S122 ();
         if (returnInSub) return;
         edtavPromocionmodelo_promocionmodeloid_Visible = 0;
         AssignProp("", false, edtavPromocionmodelo_promocionmodeloid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPromocionmodelo_promocionmodeloid_Visible), 5, 0), true);
         edtavPromocionmodelo_promocionid_Visible = 0;
         AssignProp("", false, edtavPromocionmodelo_promocionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPromocionmodelo_promocionid_Visible), 5, 0), true);
         AV5PromocionModelo.gxTpr_Promocionid = AV15PromocionID;
      }

      protected void E132R2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E112R2( )
      {
         /* Combo_promocionmodelo_modeloid_Onoptionclicked Routine */
         returnInSub = false;
         AV5PromocionModelo.gxTpr_Modeloid = (int)(Math.Round(NumberUtil.Val( Combo_promocionmodelo_modeloid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5PromocionModelo", AV5PromocionModelo);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E142R2 ();
         if (returnInSub) return;
      }

      protected void E142R2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV10TrnMode, "DSP") != 0 )
         {
            if ( StringUtil.StrCmp(AV10TrnMode, "DLT") != 0 )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S142 ();
               if (returnInSub) return;
            }
            if ( ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 ) || AV12CheckRequiredFieldsResult )
            {
               if ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 )
               {
                  AV5PromocionModelo.Delete();
               }
               else
               {
                  AV5PromocionModelo.Save();
               }
               if ( AV5PromocionModelo.Success() )
               {
                  /* Execute user subroutine: 'AFTER_TRN' */
                  S152 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV9Messages = AV5PromocionModelo.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5PromocionModelo", AV5PromocionModelo);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9Messages", AV9Messages);
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV10TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV12CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         if ( (0==AV5PromocionModelo.gxTpr_Modeloid) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Modelo", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_promocionmodelo_modeloid_Ddointernalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( (Convert.ToDecimal(0)==AV5PromocionModelo.gxTpr_Promocionmodeloprecio) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Comisión", ""), "", "", "", "", "", "", "", ""),  "error",  edtavPromocionmodelo_promocionmodeloprecio_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         /* Using cursor H002R3 */
         pr_default.execute(1, new Object[] {AV15PromocionID, AV5PromocionModelo.gxTpr_Modeloid, AV5PromocionModelo.gxTpr_Promocionmodeloid});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A48PromocionModeloID = H002R3_A48PromocionModeloID[0];
            A22ModeloID = H002R3_A22ModeloID[0];
            A41PromocionID = H002R3_A41PromocionID[0];
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Este modelo ya está registrado en la promoción.", ""),  "error",  Combo_promocionmodelo_modeloid_Ddointernalname,  "true",  ""));
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPROMOCIONMODELO_MODELOID' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A25ModeloSegmento ,
                                              AV21SegmentosSeleccionados } ,
                                              new int[]{
                                              }
         });
         /* Using cursor H002R4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A25ModeloSegmento = H002R4_A25ModeloSegmento[0];
            A22ModeloID = H002R4_A22ModeloID[0];
            A23ModeloDescripcion = H002R4_A23ModeloDescripcion[0];
            AV7Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV7Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A22ModeloID), 9, 0));
            AV7Combo_DataItem.gxTpr_Title = A23ModeloDescripcion;
            AV6PromocionModelo_ModeloID_Data.Add(AV7Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_promocionmodelo_modeloid_Selectedvalue_set = ((0==AV5PromocionModelo.gxTpr_Modeloid) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5PromocionModelo.gxTpr_Modeloid), 9, 0)));
         ucCombo_promocionmodelo_modeloid.SendProperty(context, "", false, Combo_promocionmodelo_modeloid_Internalname, "SelectedValue_set", Combo_promocionmodelo_modeloid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV29GXV5 = 1;
         while ( AV29GXV5 <= AV9Messages.Count )
         {
            AV8Message = ((GeneXus.Utils.SdtMessages_Message)AV9Messages.Item(AV29GXV5));
            GX_msglist.addItem(AV8Message.gxTpr_Description);
            AV29GXV5 = (int)(AV29GXV5+1);
         }
      }

      protected void S152( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("wpagregarmodelopromo",pr_default);
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

      protected void E152R2( )
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
         AV14PromocionModeloID = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV14PromocionModeloID", StringUtil.LTrimStr( (decimal)(AV14PromocionModeloID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONMODELOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14PromocionModeloID), "ZZZZZZZZ9"), context));
         AV15PromocionID = Convert.ToInt32(getParm(obj,2));
         AssignAttri("", false, "AV15PromocionID", StringUtil.LTrimStr( (decimal)(AV15PromocionID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15PromocionID), "ZZZZZZZZ9"), context));
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
         PA2R2( ) ;
         WS2R2( ) ;
         WE2R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025102815462564", true, true);
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
         context.AddJavascriptSource("wpagregarmodelopromo.js", "?2025102815462564", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockcombo_promocionmodelo_modeloid_Internalname = "TEXTBLOCKCOMBO_PROMOCIONMODELO_MODELOID";
         Combo_promocionmodelo_modeloid_Internalname = "COMBO_PROMOCIONMODELO_MODELOID";
         divTablesplittedpromocionmodelo_modeloid_Internalname = "TABLESPLITTEDPROMOCIONMODELO_MODELOID";
         edtavPromocionmodelo_promocionmodeloprecio_Internalname = "PROMOCIONMODELO_PROMOCIONMODELOPRECIO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavPromocionmodelo_promocionmodeloid_Internalname = "PROMOCIONMODELO_PROMOCIONMODELOID";
         edtavPromocionmodelo_promocionid_Internalname = "PROMOCIONMODELO_PROMOCIONID";
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
         edtavPromocionmodelo_promocionmodeloprecio_Enabled = 1;
         edtavPromocionmodelo_promocionid_Jsonclick = "";
         edtavPromocionmodelo_promocionid_Visible = 1;
         edtavPromocionmodelo_promocionmodeloid_Jsonclick = "";
         edtavPromocionmodelo_promocionmodeloid_Visible = 1;
         bttBtnenter_Visible = 1;
         edtavPromocionmodelo_promocionmodeloprecio_Jsonclick = "";
         edtavPromocionmodelo_promocionmodeloprecio_Enabled = 1;
         Combo_promocionmodelo_modeloid_Enabled = Convert.ToBoolean( -1);
         Combo_promocionmodelo_modeloid_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "WPAgregar Modelo Promo", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV15PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV14PromocionModeloID","fld":"vPROMOCIONMODELOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("COMBO_PROMOCIONMODELO_MODELOID.ONOPTIONCLICKED","""{"handler":"E112R2","iparms":[{"av":"Combo_promocionmodelo_modeloid_Selectedvalue_get","ctrl":"COMBO_PROMOCIONMODELO_MODELOID","prop":"SelectedValue_get"},{"av":"AV5PromocionModelo","fld":"vPROMOCIONMODELO"}]""");
         setEventMetadata("COMBO_PROMOCIONMODELO_MODELOID.ONOPTIONCLICKED",""","oparms":[{"av":"AV5PromocionModelo","fld":"vPROMOCIONMODELO"}]}""");
         setEventMetadata("ENTER","""{"handler":"E142R2","iparms":[{"av":"AV10TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV5PromocionModelo","fld":"vPROMOCIONMODELO"},{"av":"Combo_promocionmodelo_modeloid_Ddointernalname","ctrl":"COMBO_PROMOCIONMODELO_MODELOID","prop":"DDOInternalName"},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV15PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A22ModeloID","fld":"MODELOID","pic":"ZZZZZZZZ9"},{"av":"A48PromocionModeloID","fld":"PROMOCIONMODELOID","pic":"ZZZZZZZZ9"},{"av":"AV9Messages","fld":"vMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5PromocionModelo","fld":"vPROMOCIONMODELO"},{"av":"AV9Messages","fld":"vMESSAGES"},{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
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
         Combo_promocionmodelo_modeloid_Selectedvalue_get = "";
         Combo_promocionmodelo_modeloid_Ddointernalname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV5PromocionModelo = new SdtPromocionModelo(context);
         AV6PromocionModelo_ModeloID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         Combo_promocionmodelo_modeloid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblTextblockcombo_promocionmodelo_modeloid_Jsonclick = "";
         ucCombo_promocionmodelo_modeloid = new GXUserControl();
         Combo_promocionmodelo_modeloid_Caption = "";
         TempTags = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H002R2_A41PromocionID = new int[1] ;
         H002R2_A68PromocionSegmentosJson = new string[] {""} ;
         A68PromocionSegmentosJson = "";
         AV16PromocionSegmentosJson = "";
         AV18SDTSegmentos = new GXBaseCollection<SdtSDTSegmentos_Segmento>( context, "Segmento", "Premios");
         AV19Item = new SdtSDTSegmentos_Segmento(context);
         AV21SegmentosSeleccionados = new GxSimpleCollection<string>();
         H002R3_A48PromocionModeloID = new int[1] ;
         H002R3_A22ModeloID = new int[1] ;
         H002R3_A41PromocionID = new int[1] ;
         A25ModeloSegmento = "";
         H002R4_A25ModeloSegmento = new string[] {""} ;
         H002R4_A22ModeloID = new int[1] ;
         H002R4_A23ModeloDescripcion = new string[] {""} ;
         A23ModeloDescripcion = "";
         AV7Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV8Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpagregarmodelopromo__default(),
            new Object[][] {
                new Object[] {
               H002R2_A41PromocionID, H002R2_A68PromocionSegmentosJson
               }
               , new Object[] {
               H002R3_A48PromocionModeloID, H002R3_A22ModeloID, H002R3_A41PromocionID
               }
               , new Object[] {
               H002R4_A25ModeloSegmento, H002R4_A22ModeloID, H002R4_A23ModeloDescripcion
               }
            }
         );
         /* GeneXus formulas. */
      }

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
      private short nGXWrapped ;
      private int AV14PromocionModeloID ;
      private int AV15PromocionID ;
      private int wcpOAV14PromocionModeloID ;
      private int wcpOAV15PromocionID ;
      private int A41PromocionID ;
      private int A22ModeloID ;
      private int A48PromocionModeloID ;
      private int edtavPromocionmodelo_promocionmodeloprecio_Enabled ;
      private int bttBtnenter_Visible ;
      private int edtavPromocionmodelo_promocionmodeloid_Visible ;
      private int edtavPromocionmodelo_promocionid_Visible ;
      private int AV26GXV4 ;
      private int AV29GXV5 ;
      private int idxLst ;
      private string AV10TrnMode ;
      private string wcpOAV10TrnMode ;
      private string Combo_promocionmodelo_modeloid_Selectedvalue_get ;
      private string Combo_promocionmodelo_modeloid_Ddointernalname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_promocionmodelo_modeloid_Cls ;
      private string Combo_promocionmodelo_modeloid_Selectedvalue_set ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableattributes_Internalname ;
      private string divTablesplittedpromocionmodelo_modeloid_Internalname ;
      private string lblTextblockcombo_promocionmodelo_modeloid_Internalname ;
      private string lblTextblockcombo_promocionmodelo_modeloid_Jsonclick ;
      private string Combo_promocionmodelo_modeloid_Caption ;
      private string Combo_promocionmodelo_modeloid_Internalname ;
      private string edtavPromocionmodelo_promocionmodeloprecio_Internalname ;
      private string TempTags ;
      private string edtavPromocionmodelo_promocionmodeloprecio_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavPromocionmodelo_promocionmodeloid_Internalname ;
      private string edtavPromocionmodelo_promocionmodeloid_Jsonclick ;
      private string edtavPromocionmodelo_promocionid_Internalname ;
      private string edtavPromocionmodelo_promocionid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string A25ModeloSegmento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12CheckRequiredFieldsResult ;
      private bool Combo_promocionmodelo_modeloid_Enabled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV11LoadSuccess ;
      private string A68PromocionSegmentosJson ;
      private string AV16PromocionSegmentosJson ;
      private string A23ModeloDescripcion ;
      private GXUserControl ucCombo_promocionmodelo_modeloid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private SdtPromocionModelo AV5PromocionModelo ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV6PromocionModelo_ModeloID_Data ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9Messages ;
      private IDataStoreProvider pr_default ;
      private int[] H002R2_A41PromocionID ;
      private string[] H002R2_A68PromocionSegmentosJson ;
      private GXBaseCollection<SdtSDTSegmentos_Segmento> AV18SDTSegmentos ;
      private SdtSDTSegmentos_Segmento AV19Item ;
      private GxSimpleCollection<string> AV21SegmentosSeleccionados ;
      private int[] H002R3_A48PromocionModeloID ;
      private int[] H002R3_A22ModeloID ;
      private int[] H002R3_A41PromocionID ;
      private string[] H002R4_A25ModeloSegmento ;
      private int[] H002R4_A22ModeloID ;
      private string[] H002R4_A23ModeloDescripcion ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV7Combo_DataItem ;
      private GeneXus.Utils.SdtMessages_Message AV8Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpagregarmodelopromo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002R4( IGxContext context ,
                                             string A25ModeloSegmento ,
                                             GxSimpleCollection<string> AV21SegmentosSeleccionados )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object1 = new Object[2];
         scmdbuf = "SELECT `ModeloSegmento`, `ModeloID`, `ModeloDescripcion` FROM `Modelo`";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV21SegmentosSeleccionados, "`ModeloSegmento` IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `ModeloDescripcion`";
         GXv_Object1[0] = scmdbuf;
         return GXv_Object1 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_H002R4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002R2;
          prmH002R2 = new Object[] {
          new ParDef("@AV15PromocionID",GXType.Int32,9,0)
          };
          Object[] prmH002R3;
          prmH002R3 = new Object[] {
          new ParDef("@AV15PromocionID",GXType.Int32,9,0) ,
          new ParDef("@AV5PromocionModelo__Modeloid",GXType.Int32,9,0) ,
          new ParDef("@AV5Promo_1Promocionmodeloid",GXType.Int32,9,0)
          };
          Object[] prmH002R4;
          prmH002R4 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H002R2", "SELECT `PromocionID`, `PromocionSegmentosJson` FROM `Promocion` WHERE `PromocionID` = @AV15PromocionID ORDER BY `PromocionID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002R2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002R3", "SELECT `PromocionModeloID`, `ModeloID`, `PromocionID` FROM `PromocionModelo` WHERE (`PromocionID` = @AV15PromocionID and `ModeloID` = @AV5PromocionModelo__Modeloid) AND (`PromocionModeloID` <> @AV5Promo_1Promocionmodeloid) ORDER BY `PromocionID`, `ModeloID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002R3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002R4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002R4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
