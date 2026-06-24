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
   public class wpagregardistribuidorpromo : GXDataArea
   {
      public wpagregardistribuidorpromo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpagregardistribuidorpromo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           int aP1_PromocionDistribuidorID ,
                           int aP2_PromocionID )
      {
         this.AV11TrnMode = aP0_TrnMode;
         this.AV14PromocionDistribuidorID = aP1_PromocionDistribuidorID;
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
         PA2S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2S2( ) ;
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
         GXEncryptionTmp = "wpagregardistribuidorpromo.aspx"+UrlEncode(StringUtil.RTrim(AV11TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV14PromocionDistribuidorID,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV15PromocionID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("wpagregardistribuidorpromo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV11TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROMOCIONDISTRIBUIDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14PromocionDistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONDISTRIBUIDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14PromocionDistribuidorID), "ZZZZZZZZ9"), context));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Promociondistribuidor", AV5PromocionDistribuidor);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Promociondistribuidor", AV5PromocionDistribuidor);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROMOCIONDISTRIBUIDOR_DISTRIBUIDORID_DATA", AV7PromocionDistribuidor_DistribuidorID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROMOCIONDISTRIBUIDOR_DISTRIBUIDORID_DATA", AV7PromocionDistribuidor_DistribuidorID_Data);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV11TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV6CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "PROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15PromocionID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DISTRIBUIDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10DistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROMOCIONDISTRIBUIDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A47PromocionDistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV10Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV10Messages);
         }
         GxWebStd.gx_hidden_field( context, "vPROMOCIONDISTRIBUIDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14PromocionDistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONDISTRIBUIDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14PromocionDistribuidorID), "ZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROMOCIONDISTRIBUIDOR", AV5PromocionDistribuidor);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROMOCIONDISTRIBUIDOR", AV5PromocionDistribuidor);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID_Cls", StringUtil.RTrim( Combo_promociondistribuidor_distribuidorid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID_Selectedvalue_set", StringUtil.RTrim( Combo_promociondistribuidor_distribuidorid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID_Enabled", StringUtil.BoolToStr( Combo_promociondistribuidor_distribuidorid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID_Selectedvalue_get", StringUtil.RTrim( Combo_promociondistribuidor_distribuidorid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID_Ddointernalname", StringUtil.RTrim( Combo_promociondistribuidor_distribuidorid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID_Ddointernalname", StringUtil.RTrim( Combo_promociondistribuidor_distribuidorid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID_Selectedvalue_get", StringUtil.RTrim( Combo_promociondistribuidor_distribuidorid_Selectedvalue_get));
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
            WE2S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2S2( ) ;
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
         GXEncryptionTmp = "wpagregardistribuidorpromo.aspx"+UrlEncode(StringUtil.RTrim(AV11TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV14PromocionDistribuidorID,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV15PromocionID,9,0));
         return formatLink("wpagregardistribuidorpromo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WPAgregarDistribuidorPromo" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WPAgregar Distribuidor Promo", "") ;
      }

      protected void WB2S0( )
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
            GxWebStd.gx_div_start( context, divTablesplittedpromociondistribuidor_distribuidorid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_promociondistribuidor_distribuidorid_Internalname, context.GetMessage( "Distribuidor", ""), "", "", lblTextblockcombo_promociondistribuidor_distribuidorid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPAgregarDistribuidorPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_promociondistribuidor_distribuidorid.SetProperty("Caption", Combo_promociondistribuidor_distribuidorid_Caption);
            ucCombo_promociondistribuidor_distribuidorid.SetProperty("Cls", Combo_promociondistribuidor_distribuidorid_Cls);
            ucCombo_promociondistribuidor_distribuidorid.SetProperty("DropDownOptionsData", AV7PromocionDistribuidor_DistribuidorID_Data);
            ucCombo_promociondistribuidor_distribuidorid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_promociondistribuidor_distribuidorid_Internalname, "COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORIDContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPAgregarDistribuidorPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPAgregarDistribuidorPromo.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPromociondistribuidor_promociondistribuidorid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5PromocionDistribuidor.gxTpr_Promociondistribuidorid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5PromocionDistribuidor.gxTpr_Promociondistribuidorid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPromociondistribuidor_promociondistribuidorid_Jsonclick, 0, "Attribute", "", "", "", "", edtavPromociondistribuidor_promociondistribuidorid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPAgregarDistribuidorPromo.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPromociondistribuidor_promocionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5PromocionDistribuidor.gxTpr_Promocionid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5PromocionDistribuidor.gxTpr_Promocionid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPromociondistribuidor_promocionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavPromociondistribuidor_promocionid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPAgregarDistribuidorPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2S2( )
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
         Form.Meta.addItem("description", context.GetMessage( "WPAgregar Distribuidor Promo", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2S0( ) ;
      }

      protected void WS2S2( )
      {
         START2S2( ) ;
         EVT2S2( ) ;
      }

      protected void EVT2S2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_promociondistribuidor_distribuidorid.Onoptionclicked */
                              E112S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E122S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E132S2 ();
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
                                    E142S2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E152S2 ();
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

      protected void WE2S2( )
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

      protected void PA2S2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpagregardistribuidorpromo.aspx")), "wpagregardistribuidorpromo.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpagregardistribuidorpromo.aspx")))) ;
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
                     AV11TrnMode = gxfirstwebparm;
                     AssignAttri("", false, "AV11TrnMode", AV11TrnMode);
                     GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV14PromocionDistribuidorID = (int)(Math.Round(NumberUtil.Val( GetPar( "PromocionDistribuidorID"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV14PromocionDistribuidorID", StringUtil.LTrimStr( (decimal)(AV14PromocionDistribuidorID), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONDISTRIBUIDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14PromocionDistribuidorID), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavPromociondistribuidor_promociondistribuidorid_Internalname;
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
         RF2S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E132S2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E152S2 ();
            WB2S0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2S2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vPROMOCIONDISTRIBUIDOR"), AV5PromocionDistribuidor);
            ajax_req_read_hidden_sdt(cgiGet( "Promociondistribuidor"), AV5PromocionDistribuidor);
            ajax_req_read_hidden_sdt(cgiGet( "vPROMOCIONDISTRIBUIDOR_DISTRIBUIDORID_DATA"), AV7PromocionDistribuidor_DistribuidorID_Data);
            /* Read saved values. */
            Combo_promociondistribuidor_distribuidorid_Cls = cgiGet( "COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID_Cls");
            Combo_promociondistribuidor_distribuidorid_Selectedvalue_set = cgiGet( "COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID_Selectedvalue_set");
            Combo_promociondistribuidor_distribuidorid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID_Enabled"));
            Combo_promociondistribuidor_distribuidorid_Ddointernalname = cgiGet( "COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID_Ddointernalname");
            Combo_promociondistribuidor_distribuidorid_Selectedvalue_get = cgiGet( "COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID_Selectedvalue_get");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPromociondistribuidor_promociondistribuidorid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPromociondistribuidor_promociondistribuidorid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROMOCIONDISTRIBUIDOR_PROMOCIONDISTRIBUIDORID");
               GX_FocusControl = edtavPromociondistribuidor_promociondistribuidorid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5PromocionDistribuidor.gxTpr_Promociondistribuidorid = 0;
            }
            else
            {
               AV5PromocionDistribuidor.gxTpr_Promociondistribuidorid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPromociondistribuidor_promociondistribuidorid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPromociondistribuidor_promocionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPromociondistribuidor_promocionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROMOCIONDISTRIBUIDOR_PROMOCIONID");
               GX_FocusControl = edtavPromociondistribuidor_promocionid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5PromocionDistribuidor.gxTpr_Promocionid = 0;
            }
            else
            {
               AV5PromocionDistribuidor.gxTpr_Promocionid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPromociondistribuidor_promocionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         E122S2 ();
         if (returnInSub) return;
      }

      protected void E122S2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV12LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV11TrnMode, "INS") == 0 ) ) || ( ( StringUtil.StrCmp(AV11TrnMode, "UPD") == 0 ) ) || ( ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) ) )
         {
            if ( StringUtil.StrCmp(AV11TrnMode, "INS") != 0 )
            {
               AV5PromocionDistribuidor.Load(AV14PromocionDistribuidorID);
               AV12LoadSuccess = AV5PromocionDistribuidor.Success();
               if ( ! AV12LoadSuccess )
               {
                  AV10Messages = AV5PromocionDistribuidor.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) )
               {
                  Combo_promociondistribuidor_distribuidorid_Enabled = false;
                  ucCombo_promociondistribuidor_distribuidorid.SendProperty(context, "", false, Combo_promociondistribuidor_distribuidorid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_promociondistribuidor_distribuidorid_Enabled));
               }
            }
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
         if ( AV12LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""));
            }
         }
         /* Execute user subroutine: 'LOADCOMBOPROMOCIONDISTRIBUIDOR_DISTRIBUIDORID' */
         S122 ();
         if (returnInSub) return;
         edtavPromociondistribuidor_promociondistribuidorid_Visible = 0;
         AssignProp("", false, edtavPromociondistribuidor_promociondistribuidorid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPromociondistribuidor_promociondistribuidorid_Visible), 5, 0), true);
         edtavPromociondistribuidor_promocionid_Visible = 0;
         AssignProp("", false, edtavPromociondistribuidor_promocionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPromociondistribuidor_promocionid_Visible), 5, 0), true);
         AV5PromocionDistribuidor.gxTpr_Promocionid = AV15PromocionID;
      }

      protected void E132S2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E112S2( )
      {
         /* Combo_promociondistribuidor_distribuidorid_Onoptionclicked Routine */
         returnInSub = false;
         AV5PromocionDistribuidor.gxTpr_Distribuidorid = (int)(Math.Round(NumberUtil.Val( Combo_promociondistribuidor_distribuidorid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5PromocionDistribuidor", AV5PromocionDistribuidor);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E142S2 ();
         if (returnInSub) return;
      }

      protected void E142S2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV11TrnMode, "DSP") != 0 )
         {
            if ( StringUtil.StrCmp(AV11TrnMode, "DLT") != 0 )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S142 ();
               if (returnInSub) return;
            }
            if ( ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) || AV6CheckRequiredFieldsResult )
            {
               if ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 )
               {
                  AV5PromocionDistribuidor.Delete();
               }
               else
               {
                  AV5PromocionDistribuidor.Save();
               }
               if ( AV5PromocionDistribuidor.Success() )
               {
                  /* Execute user subroutine: 'AFTER_TRN' */
                  S152 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV10Messages = AV5PromocionDistribuidor.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5PromocionDistribuidor", AV5PromocionDistribuidor);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10Messages", AV10Messages);
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV6CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         if ( (0==AV5PromocionDistribuidor.gxTpr_Distribuidorid) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Distribuidor", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_promociondistribuidor_distribuidorid_Ddointernalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         }
         if ( AV6CheckRequiredFieldsResult )
         {
            /* Using cursor H002S2 */
            pr_default.execute(0, new Object[] {AV5PromocionDistribuidor.gxTpr_Distribuidorid, AV5PromocionDistribuidor.gxTpr_Promociondistribuidorid, AV15PromocionID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A47PromocionDistribuidorID = H002S2_A47PromocionDistribuidorID[0];
               A10DistribuidorID = H002S2_A10DistribuidorID[0];
               A41PromocionID = H002S2_A41PromocionID[0];
               GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Ya se ha registrado este distribuidor en la promoción.", ""),  "error",  Combo_promociondistribuidor_distribuidorid_Ddointernalname,  "true",  ""));
               AV6CheckRequiredFieldsResult = false;
               AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPROMOCIONDISTRIBUIDOR_DISTRIBUIDORID' Routine */
         returnInSub = false;
         /* Using cursor H002S3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A10DistribuidorID = H002S3_A10DistribuidorID[0];
            A11DistribuidorDescripcion = H002S3_A11DistribuidorDescripcion[0];
            AV8Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A10DistribuidorID), 9, 0));
            AV8Combo_DataItem.gxTpr_Title = A11DistribuidorDescripcion;
            AV7PromocionDistribuidor_DistribuidorID_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_promociondistribuidor_distribuidorid_Selectedvalue_set = ((0==AV5PromocionDistribuidor.gxTpr_Distribuidorid) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5PromocionDistribuidor.gxTpr_Distribuidorid), 9, 0)));
         ucCombo_promociondistribuidor_distribuidorid.SendProperty(context, "", false, Combo_promociondistribuidor_distribuidorid_Internalname, "SelectedValue_set", Combo_promociondistribuidor_distribuidorid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV20GXV3 = 1;
         while ( AV20GXV3 <= AV10Messages.Count )
         {
            AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV10Messages.Item(AV20GXV3));
            GX_msglist.addItem(AV9Message.gxTpr_Description);
            AV20GXV3 = (int)(AV20GXV3+1);
         }
      }

      protected void S152( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("wpagregardistribuidorpromo",pr_default);
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

      protected void E152S2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV11TrnMode", AV11TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         AV14PromocionDistribuidorID = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV14PromocionDistribuidorID", StringUtil.LTrimStr( (decimal)(AV14PromocionDistribuidorID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONDISTRIBUIDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14PromocionDistribuidorID), "ZZZZZZZZ9"), context));
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
         PA2S2( ) ;
         WS2S2( ) ;
         WE2S2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025102815462552", true, true);
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
         context.AddJavascriptSource("wpagregardistribuidorpromo.js", "?2025102815462552", false, true);
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
         lblTextblockcombo_promociondistribuidor_distribuidorid_Internalname = "TEXTBLOCKCOMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID";
         Combo_promociondistribuidor_distribuidorid_Internalname = "COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID";
         divTablesplittedpromociondistribuidor_distribuidorid_Internalname = "TABLESPLITTEDPROMOCIONDISTRIBUIDOR_DISTRIBUIDORID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavPromociondistribuidor_promociondistribuidorid_Internalname = "PROMOCIONDISTRIBUIDOR_PROMOCIONDISTRIBUIDORID";
         edtavPromociondistribuidor_promocionid_Internalname = "PROMOCIONDISTRIBUIDOR_PROMOCIONID";
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
         edtavPromociondistribuidor_promocionid_Jsonclick = "";
         edtavPromociondistribuidor_promocionid_Visible = 1;
         edtavPromociondistribuidor_promociondistribuidorid_Jsonclick = "";
         edtavPromociondistribuidor_promociondistribuidorid_Visible = 1;
         bttBtnenter_Visible = 1;
         Combo_promociondistribuidor_distribuidorid_Enabled = Convert.ToBoolean( -1);
         Combo_promociondistribuidor_distribuidorid_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "WPAgregar Distribuidor Promo", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV15PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV14PromocionDistribuidorID","fld":"vPROMOCIONDISTRIBUIDORID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID.ONOPTIONCLICKED","""{"handler":"E112S2","iparms":[{"av":"Combo_promociondistribuidor_distribuidorid_Selectedvalue_get","ctrl":"COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID","prop":"SelectedValue_get"},{"av":"AV5PromocionDistribuidor","fld":"vPROMOCIONDISTRIBUIDOR"}]""");
         setEventMetadata("COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID.ONOPTIONCLICKED",""","oparms":[{"av":"AV5PromocionDistribuidor","fld":"vPROMOCIONDISTRIBUIDOR"}]}""");
         setEventMetadata("ENTER","""{"handler":"E142S2","iparms":[{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV6CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV5PromocionDistribuidor","fld":"vPROMOCIONDISTRIBUIDOR"},{"av":"Combo_promociondistribuidor_distribuidorid_Ddointernalname","ctrl":"COMBO_PROMOCIONDISTRIBUIDOR_DISTRIBUIDORID","prop":"DDOInternalName"},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV15PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"A47PromocionDistribuidorID","fld":"PROMOCIONDISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"AV10Messages","fld":"vMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5PromocionDistribuidor","fld":"vPROMOCIONDISTRIBUIDOR"},{"av":"AV10Messages","fld":"vMESSAGES"},{"av":"AV6CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
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
         wcpOAV11TrnMode = "";
         Combo_promociondistribuidor_distribuidorid_Selectedvalue_get = "";
         Combo_promociondistribuidor_distribuidorid_Ddointernalname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV5PromocionDistribuidor = new SdtPromocionDistribuidor(context);
         AV7PromocionDistribuidor_DistribuidorID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         Combo_promociondistribuidor_distribuidorid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblTextblockcombo_promociondistribuidor_distribuidorid_Jsonclick = "";
         ucCombo_promociondistribuidor_distribuidorid = new GXUserControl();
         Combo_promociondistribuidor_distribuidorid_Caption = "";
         TempTags = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H002S2_A47PromocionDistribuidorID = new int[1] ;
         H002S2_A10DistribuidorID = new int[1] ;
         H002S2_A41PromocionID = new int[1] ;
         H002S3_A10DistribuidorID = new int[1] ;
         H002S3_A11DistribuidorDescripcion = new string[] {""} ;
         A11DistribuidorDescripcion = "";
         AV8Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpagregardistribuidorpromo__default(),
            new Object[][] {
                new Object[] {
               H002S2_A47PromocionDistribuidorID, H002S2_A10DistribuidorID, H002S2_A41PromocionID
               }
               , new Object[] {
               H002S3_A10DistribuidorID, H002S3_A11DistribuidorDescripcion
               }
            }
         );
         /* GeneXus formulas. */
      }

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
      private int AV14PromocionDistribuidorID ;
      private int AV15PromocionID ;
      private int wcpOAV14PromocionDistribuidorID ;
      private int wcpOAV15PromocionID ;
      private int A41PromocionID ;
      private int A10DistribuidorID ;
      private int A47PromocionDistribuidorID ;
      private int bttBtnenter_Visible ;
      private int edtavPromociondistribuidor_promociondistribuidorid_Visible ;
      private int edtavPromociondistribuidor_promocionid_Visible ;
      private int AV20GXV3 ;
      private int idxLst ;
      private string AV11TrnMode ;
      private string wcpOAV11TrnMode ;
      private string Combo_promociondistribuidor_distribuidorid_Selectedvalue_get ;
      private string Combo_promociondistribuidor_distribuidorid_Ddointernalname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_promociondistribuidor_distribuidorid_Cls ;
      private string Combo_promociondistribuidor_distribuidorid_Selectedvalue_set ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableattributes_Internalname ;
      private string divTablesplittedpromociondistribuidor_distribuidorid_Internalname ;
      private string lblTextblockcombo_promociondistribuidor_distribuidorid_Internalname ;
      private string lblTextblockcombo_promociondistribuidor_distribuidorid_Jsonclick ;
      private string Combo_promociondistribuidor_distribuidorid_Caption ;
      private string Combo_promociondistribuidor_distribuidorid_Internalname ;
      private string TempTags ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavPromociondistribuidor_promociondistribuidorid_Internalname ;
      private string edtavPromociondistribuidor_promociondistribuidorid_Jsonclick ;
      private string edtavPromociondistribuidor_promocionid_Internalname ;
      private string edtavPromociondistribuidor_promocionid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV6CheckRequiredFieldsResult ;
      private bool Combo_promociondistribuidor_distribuidorid_Enabled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV12LoadSuccess ;
      private string A11DistribuidorDescripcion ;
      private GXUserControl ucCombo_promociondistribuidor_distribuidorid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private SdtPromocionDistribuidor AV5PromocionDistribuidor ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV7PromocionDistribuidor_DistribuidorID_Data ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private IDataStoreProvider pr_default ;
      private int[] H002S2_A47PromocionDistribuidorID ;
      private int[] H002S2_A10DistribuidorID ;
      private int[] H002S2_A41PromocionID ;
      private int[] H002S3_A10DistribuidorID ;
      private string[] H002S3_A11DistribuidorDescripcion ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV8Combo_DataItem ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpagregardistribuidorpromo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002S2;
          prmH002S2 = new Object[] {
          new ParDef("@AV5Promo_1Distribuidorid",GXType.Int32,9,0) ,
          new ParDef("@AV5Promo_2Promociondistribuid",GXType.Int32,9,0) ,
          new ParDef("@AV15PromocionID",GXType.Int32,9,0)
          };
          Object[] prmH002S3;
          prmH002S3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H002S2", "SELECT `PromocionDistribuidorID`, `DistribuidorID`, `PromocionID` FROM `PromocionDistribuidor` WHERE (`DistribuidorID` = @AV5Promo_1Distribuidorid) AND (`PromocionDistribuidorID` <> @AV5Promo_2Promociondistribuid) AND (`PromocionID` = @AV15PromocionID) ORDER BY `DistribuidorID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002S2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002S3", "SELECT `DistribuidorID`, `DistribuidorDescripcion` FROM `Distribuidor` ORDER BY `DistribuidorDescripcion` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002S3,100, GxCacheFrequency.OFF ,false,false )
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
       }
    }

 }

}
