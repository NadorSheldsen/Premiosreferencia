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
   public class wpwizardpromoresumen : GXWebComponent
   {
      public wpwizardpromoresumen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wpwizardpromoresumen( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WebSessionKey ,
                           string aP1_PreviousStep ,
                           bool aP2_GoingBack )
      {
         this.AV6WebSessionKey = aP0_WebSessionKey;
         this.AV8PreviousStep = aP1_PreviousStep;
         this.AV7GoingBack = aP2_GoingBack;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavWizarddata_segmentos_grid__segmento = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV6WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
                  AV8PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
                  AV7GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV6WebSessionKey,(string)AV8PreviousStep,(bool)AV7GoingBack});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Segmentos_grid") == 0 )
               {
                  gxnrSegmentos_grid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Segmentos_grid") == 0 )
               {
                  gxgrSegmentos_grid_refresh_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Modelos_grid") == 0 )
               {
                  gxnrModelos_grid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Modelos_grid") == 0 )
               {
                  gxgrModelos_grid_refresh_invoke( ) ;
                  return  ;
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrSegmentos_grid_newrow_invoke( )
      {
         nRC_GXsfl_70 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_70"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_70_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_70_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_70_idx = GetPar( "sGXsfl_70_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrSegmentos_grid_newrow( ) ;
         /* End function gxnrSegmentos_grid_newrow_invoke */
      }

      protected void gxgrSegmentos_grid_refresh_invoke( )
      {
         subSegmentos_grid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subSegmentos_grid_Rows"), "."), 18, MidpointRounding.ToEven));
         subModelos_grid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subModelos_grid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV10HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrSegmentos_grid_refresh( subSegmentos_grid_Rows, subModelos_grid_Rows, AV10HasValidationErrors, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrSegmentos_grid_refresh_invoke */
      }

      protected void gxnrModelos_grid_newrow_invoke( )
      {
         nRC_GXsfl_87 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_87"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_87_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_87_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_87_idx = GetPar( "sGXsfl_87_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrModelos_grid_newrow( ) ;
         /* End function gxnrModelos_grid_newrow_invoke */
      }

      protected void gxgrModelos_grid_refresh_invoke( )
      {
         subSegmentos_grid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subSegmentos_grid_Rows"), "."), 18, MidpointRounding.ToEven));
         subModelos_grid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subModelos_grid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV10HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrModelos_grid_refresh( subSegmentos_grid_Rows, subModelos_grid_Rows, AV10HasValidationErrors, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrModelos_grid_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA272( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavWizarddata_infogeneral_promodescripcion_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_infogeneral_promodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_promodescripcion_Enabled), 5, 0), true);
               edtavWizarddata_infogeneral_iniciopromo_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_infogeneral_iniciopromo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_iniciopromo_Enabled), 5, 0), true);
               edtavWizarddata_infogeneral_finpromo_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_infogeneral_finpromo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_finpromo_Enabled), 5, 0), true);
               edtavWizarddata_infogeneral_promobase_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_infogeneral_promobase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_promobase_Enabled), 5, 0), true);
               edtavWizarddata_infogeneral_distribuidorid_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_infogeneral_distribuidorid_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_distribuidorid_description_Enabled), 5, 0), true);
               edtavWizarddata_infogeneral_promoarte_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_infogeneral_promoarte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_promoarte_Enabled), 5, 0), true);
               cmbavWizarddata_segmentos_grid__segmento.Enabled = 0;
               AssignProp(sPrefix, false, cmbavWizarddata_segmentos_grid__segmento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavWizarddata_segmentos_grid__segmento.Enabled), 5, 0), !bGXsfl_70_Refreshing);
               edtavWizarddata_modelos_grid__modelodescripcion_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_modelos_grid__modelodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_modelos_grid__modelodescripcion_Enabled), 5, 0), !bGXsfl_87_Refreshing);
               edtavWizarddata_modelos_grid__modeloid_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_modelos_grid__modeloid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_modelos_grid__modeloid_Enabled), 5, 0), !bGXsfl_87_Refreshing);
               edtavWizarddata_modelos_grid__precio_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_modelos_grid__precio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_modelos_grid__precio_Enabled), 5, 0), !bGXsfl_87_Refreshing);
               WS272( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "WPWizard Promo Resumen", "")) ;
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
         }
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
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpwizardpromoresumen.aspx"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpwizardpromoresumen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wizarddata", AV11WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wizarddata", AV11WizardData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wizarddata_segmentos_grid", AV13WizardData_Segmentos_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wizarddata_segmentos_grid", AV13WizardData_Segmentos_Grid);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wizarddata_modelos_grid", AV12WizardData_Modelos_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wizarddata_modelos_grid", AV12WizardData_Modelos_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_70", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_70), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_87", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_87), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA_SEGMENTOS_GRID", AV13WizardData_Segmentos_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA_SEGMENTOS_GRID", AV13WizardData_Segmentos_Grid);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA_MODELOS_GRID", AV12WizardData_Modelos_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA_MODELOS_GRID", AV12WizardData_Modelos_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"SEGMENTOS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(SEGMENTOS_GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"MODELOS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(MODELOS_GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SEGMENTOS_GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(SEGMENTOS_GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"MODELOS_GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(MODELOS_GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"SEGMENTOS_GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSegmentos_grid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"MODELOS_GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subModelos_grid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm272( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WPWizardPromoResumen" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WPWizard Promo Resumen", "") ;
      }

      protected void WB270( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpwizardpromoresumen.aspx");
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divInfogeneral_summarytable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divInfogeneral_summaryheadertable_Internalname, 1, 0, "px", 0, "px", "TableWizardSummaryStep", "start", "top", " "+"data-gx-flex"+" ", "justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblInfogeneral_summarytitle_Internalname, context.GetMessage( "Datos generales", ""), "", "", lblInfogeneral_summarytitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "WizardStepDescription", 0, "", 1, 1, 0, 0, "HLP_WPWizardPromoResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonAsLinkBasecolor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardgotoinfogeneral_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(70), 2, 0)+","+"null"+");", context.GetMessage( "WWP_WizardGoToCaption", ""), bttBtnwizardgotoinfogeneral_Jsonclick, 5, context.GetMessage( "WWP_WizardGoToCaption", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'WIZARDGOTO INFOGENERAL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPWizardPromoResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divInfogeneral_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWizarddata_infogeneral_promodescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWizarddata_infogeneral_promodescripcion_Internalname, context.GetMessage( "Nombre de la promoción", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWizarddata_infogeneral_promodescripcion_Internalname, AV11WizardData.gxTpr_Infogeneral.gxTpr_Promodescripcion, StringUtil.RTrim( context.localUtil.Format( AV11WizardData.gxTpr_Infogeneral.gxTpr_Promodescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWizarddata_infogeneral_promodescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavWizarddata_infogeneral_promodescripcion_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPWizardPromoResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divInfogeneral_unnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWizarddata_infogeneral_iniciopromo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWizarddata_infogeneral_iniciopromo_Internalname, context.GetMessage( "Inicio de la promoción", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'" + sGXsfl_70_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavWizarddata_infogeneral_iniciopromo_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavWizarddata_infogeneral_iniciopromo_Internalname, context.localUtil.Format(AV11WizardData.gxTpr_Infogeneral.gxTpr_Iniciopromo, "99/99/99"), context.localUtil.Format( AV11WizardData.gxTpr_Infogeneral.gxTpr_Iniciopromo, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWizarddata_infogeneral_iniciopromo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavWizarddata_infogeneral_iniciopromo_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPWizardPromoResumen.htm");
            GxWebStd.gx_bitmap( context, edtavWizarddata_infogeneral_iniciopromo_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavWizarddata_infogeneral_iniciopromo_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPWizardPromoResumen.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWizarddata_infogeneral_finpromo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWizarddata_infogeneral_finpromo_Internalname, context.GetMessage( "Fin de la promoción", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'" + sGXsfl_70_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavWizarddata_infogeneral_finpromo_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavWizarddata_infogeneral_finpromo_Internalname, context.localUtil.Format(AV11WizardData.gxTpr_Infogeneral.gxTpr_Finpromo, "99/99/99"), context.localUtil.Format( AV11WizardData.gxTpr_Infogeneral.gxTpr_Finpromo, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWizarddata_infogeneral_finpromo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavWizarddata_infogeneral_finpromo_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPWizardPromoResumen.htm");
            GxWebStd.gx_bitmap( context, edtavWizarddata_infogeneral_finpromo_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavWizarddata_infogeneral_finpromo_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPWizardPromoResumen.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWizarddata_infogeneral_promobase_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWizarddata_infogeneral_promobase_Internalname, context.GetMessage( "Bases de la promoción", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'" + sGXsfl_70_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavWizarddata_infogeneral_promobase_Internalname, AV11WizardData.gxTpr_Infogeneral.gxTpr_Promobase, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtavWizarddata_infogeneral_promobase_Enabled, 0, 80, "chr", 9, "row", 0, StyleString, ClassString, "", "", "700", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WPWizardPromoResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWizarddata_infogeneral_distribuidorid_description_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWizarddata_infogeneral_distribuidorid_description_Internalname, context.GetMessage( "Distribuidores", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWizarddata_infogeneral_distribuidorid_description_Internalname, AV11WizardData.gxTpr_Infogeneral.gxTpr_Distribuidorid_description, StringUtil.RTrim( context.localUtil.Format( AV11WizardData.gxTpr_Infogeneral.gxTpr_Distribuidorid_description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWizarddata_infogeneral_distribuidorid_description_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavWizarddata_infogeneral_distribuidorid_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPWizardPromoResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWizarddata_infogeneral_promoarte_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWizarddata_infogeneral_promoarte_Internalname, context.GetMessage( "Subir arte", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            ClassString = "AttributeFL";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'" + sGXsfl_70_idx + "',0)\"";
            edtavWizarddata_infogeneral_promoarte_Filetype = "tmp";
            AssignProp(sPrefix, false, edtavWizarddata_infogeneral_promoarte_Internalname, "Filetype", edtavWizarddata_infogeneral_promoarte_Filetype, true);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11WizardData.gxTpr_Infogeneral.gxTpr_Promoarte)) )
            {
               gxblobfileaux.Source = AV11WizardData.gxTpr_Infogeneral.gxTpr_Promoarte;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavWizarddata_infogeneral_promoarte_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavWizarddata_infogeneral_promoarte_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV11WizardData.gxTpr_Infogeneral.gxTpr_Promoarte = gxblobfileaux.GetURI();
                  edtavWizarddata_infogeneral_promoarte_Filetype = gxblobfileaux.GetExtension();
                  AssignProp(sPrefix, false, edtavWizarddata_infogeneral_promoarte_Internalname, "Filetype", edtavWizarddata_infogeneral_promoarte_Filetype, true);
               }
               AssignProp(sPrefix, false, edtavWizarddata_infogeneral_promoarte_Internalname, "URL", context.PathToRelativeUrl( AV11WizardData.gxTpr_Infogeneral.gxTpr_Promoarte), true);
            }
            GxWebStd.gx_blob_field( context, edtavWizarddata_infogeneral_promoarte_Internalname, StringUtil.RTrim( AV11WizardData.gxTpr_Infogeneral.gxTpr_Promoarte), context.PathToRelativeUrl( AV11WizardData.gxTpr_Infogeneral.gxTpr_Promoarte), (String.IsNullOrEmpty(StringUtil.RTrim( edtavWizarddata_infogeneral_promoarte_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavWizarddata_infogeneral_promoarte_Filetype)) ? AV11WizardData.gxTpr_Infogeneral.gxTpr_Promoarte : edtavWizarddata_infogeneral_promoarte_Filetype)) : edtavWizarddata_infogeneral_promoarte_Contenttype), false, "", edtavWizarddata_infogeneral_promoarte_Parameters, 0, edtavWizarddata_infogeneral_promoarte_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtavWizarddata_infogeneral_promoarte_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", "", "HLP_WPWizardPromoResumen.htm");
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
            GxWebStd.gx_div_start( context, divSegmentos_summarytable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSegmentos_summaryheadertable_Internalname, 1, 0, "px", 0, "px", "TableWizardSummaryStep", "start", "top", " "+"data-gx-flex"+" ", "justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSegmentos_summarytitle_Internalname, context.GetMessage( "Segmentos", ""), "", "", lblSegmentos_summarytitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "WizardStepDescription", 0, "", 1, 1, 0, 0, "HLP_WPWizardPromoResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonAsLinkBasecolor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardgotosegmentos_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(70), 2, 0)+","+"null"+");", context.GetMessage( "WWP_WizardGoToCaption", ""), bttBtnwizardgotosegmentos_Jsonclick, 5, context.GetMessage( "WWP_WizardGoToCaption", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'WIZARDGOTO SEGMENTOS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPWizardPromoResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSegmentos_tablegrid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Segmentos_gridContainer.SetWrapped(nGXWrapped);
            StartGridControl70( ) ;
         }
         if ( wbEnd == 70 )
         {
            wbEnd = 0;
            nRC_GXsfl_70 = (int)(nGXsfl_70_idx-1);
            if ( Segmentos_gridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Segmentos_gridContainer.AddObjectProperty("SEGMENTOS_GRID_nEOF", SEGMENTOS_GRID_nEOF);
               Segmentos_gridContainer.AddObjectProperty("SEGMENTOS_GRID_nFirstRecordOnPage", SEGMENTOS_GRID_nFirstRecordOnPage);
               AV24GXV7 = nGXsfl_70_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Segmentos_gridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Segmentos_grid", Segmentos_gridContainer, subSegmentos_grid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Segmentos_gridContainerData", Segmentos_gridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Segmentos_gridContainerData"+"V", Segmentos_gridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Segmentos_gridContainerData"+"V"+"\" value='"+Segmentos_gridContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            GxWebStd.gx_div_start( context, divModelos_summarytable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divModelos_summaryheadertable_Internalname, 1, 0, "px", 0, "px", "TableWizardSummaryStep", "start", "top", " "+"data-gx-flex"+" ", "justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblModelos_summarytitle_Internalname, context.GetMessage( "Modelos", ""), "", "", lblModelos_summarytitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "WizardStepDescription", 0, "", 1, 1, 0, 0, "HLP_WPWizardPromoResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonAsLinkBasecolor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardgotomodelos_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(70), 2, 0)+","+"null"+");", context.GetMessage( "WWP_WizardGoToCaption", ""), bttBtnwizardgotomodelos_Jsonclick, 5, context.GetMessage( "WWP_WizardGoToCaption", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'WIZARDGOTO MODELOS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPWizardPromoResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divModelos_tablegrid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Modelos_gridContainer.SetWrapped(nGXWrapped);
            StartGridControl87( ) ;
         }
         if ( wbEnd == 87 )
         {
            wbEnd = 0;
            nRC_GXsfl_87 = (int)(nGXsfl_87_idx-1);
            if ( Modelos_gridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Modelos_gridContainer.AddObjectProperty("MODELOS_GRID_nEOF", MODELOS_GRID_nEOF);
               Modelos_gridContainer.AddObjectProperty("MODELOS_GRID_nFirstRecordOnPage", MODELOS_GRID_nFirstRecordOnPage);
               AV26GXV9 = nGXsfl_87_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Modelos_gridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Modelos_grid", Modelos_gridContainer, subModelos_grid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Modelos_gridContainerData", Modelos_gridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Modelos_gridContainerData"+"V", Modelos_gridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Modelos_gridContainerData"+"V"+"\" value='"+Modelos_gridContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWizardActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardprevious.SetProperty("TooltipText", Btnwizardprevious_Tooltiptext);
            ucBtnwizardprevious.SetProperty("BeforeIconClass", Btnwizardprevious_Beforeiconclass);
            ucBtnwizardprevious.SetProperty("Caption", Btnwizardprevious_Caption);
            ucBtnwizardprevious.SetProperty("Class", Btnwizardprevious_Class);
            ucBtnwizardprevious.Render(context, "wwp_iconbutton", Btnwizardprevious_Internalname, sPrefix+"BTNWIZARDPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardlastnext.SetProperty("TooltipText", Btnwizardlastnext_Tooltiptext);
            ucBtnwizardlastnext.SetProperty("AfterIconClass", Btnwizardlastnext_Aftericonclass);
            ucBtnwizardlastnext.SetProperty("Caption", Btnwizardlastnext_Caption);
            ucBtnwizardlastnext.SetProperty("Class", Btnwizardlastnext_Class);
            ucBtnwizardlastnext.Render(context, "wwp_iconbutton", Btnwizardlastnext_Internalname, sPrefix+"BTNWIZARDLASTNEXTContainer");
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
            /* User Defined Control */
            ucModelos_grid_empowerer.Render(context, "wwp.gridempowerer", Modelos_grid_empowerer_Internalname, sPrefix+"MODELOS_GRID_EMPOWERERContainer");
            /* User Defined Control */
            ucSegmentos_grid_empowerer.Render(context, "wwp.gridempowerer", Segmentos_grid_empowerer_Internalname, sPrefix+"SEGMENTOS_GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 70 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Segmentos_gridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Segmentos_gridContainer.AddObjectProperty("SEGMENTOS_GRID_nEOF", SEGMENTOS_GRID_nEOF);
                  Segmentos_gridContainer.AddObjectProperty("SEGMENTOS_GRID_nFirstRecordOnPage", SEGMENTOS_GRID_nFirstRecordOnPage);
                  AV24GXV7 = nGXsfl_70_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Segmentos_gridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Segmentos_grid", Segmentos_gridContainer, subSegmentos_grid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Segmentos_gridContainerData", Segmentos_gridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Segmentos_gridContainerData"+"V", Segmentos_gridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Segmentos_gridContainerData"+"V"+"\" value='"+Segmentos_gridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 87 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Modelos_gridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Modelos_gridContainer.AddObjectProperty("MODELOS_GRID_nEOF", MODELOS_GRID_nEOF);
                  Modelos_gridContainer.AddObjectProperty("MODELOS_GRID_nFirstRecordOnPage", MODELOS_GRID_nFirstRecordOnPage);
                  AV26GXV9 = nGXsfl_87_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Modelos_gridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Modelos_grid", Modelos_gridContainer, subModelos_grid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Modelos_gridContainerData", Modelos_gridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Modelos_gridContainerData"+"V", Modelos_gridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Modelos_gridContainerData"+"V"+"\" value='"+Modelos_gridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START272( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "WPWizard Promo Resumen", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP270( ) ;
            }
         }
      }

      protected void WS272( )
      {
         START272( ) ;
         EVT272( ) ;
      }

      protected void EVT272( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E11272 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E12272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDGOTO MODELOS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardGoTo Modelos' */
                                    E13272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDGOTO SEGMENTOS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardGoTo Segmentos' */
                                    E14272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDGOTO INFOGENERAL'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardGoTo InfoGeneral' */
                                    E15272 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavWizarddata_infogeneral_promodescripcion_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SEGMENTOS_GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"SEGMENTOS_GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subsegmentos_grid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subsegmentos_grid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subsegmentos_grid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subsegmentos_grid_lastpage( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "MODELOS_GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"MODELOS_GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 submodelos_grid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 submodelos_grid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 submodelos_grid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 submodelos_grid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "SEGMENTOS_GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              nGXsfl_70_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
                              SubsflControlProps_702( ) ;
                              AV24GXV7 = (int)(nGXsfl_70_idx+SEGMENTOS_GRID_nFirstRecordOnPage);
                              if ( ( AV13WizardData_Segmentos_Grid.Count >= AV24GXV7 ) && ( AV24GXV7 > 0 ) )
                              {
                                 AV13WizardData_Segmentos_Grid.CurrentItem = ((SdtWPWizardPromoData_Segmentos_GridItem)AV13WizardData_Segmentos_Grid.Item(AV24GXV7));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavWizarddata_infogeneral_promodescripcion_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E16272 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "SEGMENTOS_GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavWizarddata_infogeneral_promodescripcion_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Segmentos_grid.Load */
                                          E17272 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP270( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavWizarddata_infogeneral_promodescripcion_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "MODELOS_GRID.LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP270( ) ;
                              }
                              nGXsfl_87_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_87_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_87_idx), 4, 0), 4, "0");
                              SubsflControlProps_873( ) ;
                              AV26GXV9 = (int)(nGXsfl_87_idx+MODELOS_GRID_nFirstRecordOnPage);
                              if ( ( AV12WizardData_Modelos_Grid.Count >= AV26GXV9 ) && ( AV26GXV9 > 0 ) )
                              {
                                 AV12WizardData_Modelos_Grid.CurrentItem = ((SdtWPWizardPromoData_Modelos_GridItem)AV12WizardData_Modelos_Grid.Item(AV26GXV9));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "MODELOS_GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavWizarddata_infogeneral_promodescripcion_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Modelos_grid.Load */
                                          E18273 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP270( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavWizarddata_infogeneral_promodescripcion_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE272( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm272( ) ;
            }
         }
      }

      protected void PA272( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( StringUtil.Len( sPrefix) == 0 )
            {
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpwizardpromoresumen.aspx")), "wpwizardpromoresumen.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpwizardpromoresumen.aspx")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "WebSessionKey");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
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
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavWizarddata_infogeneral_promodescripcion_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrSegmentos_grid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_702( ) ;
         while ( nGXsfl_70_idx <= nRC_GXsfl_70 )
         {
            sendrow_702( ) ;
            nGXsfl_70_idx = ((subSegmentos_grid_Islastpage==1)&&(nGXsfl_70_idx+1>subSegmentos_grid_fnc_Recordsperpage( )) ? 1 : nGXsfl_70_idx+1);
            sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
            SubsflControlProps_702( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Segmentos_gridContainer)) ;
         /* End function gxnrSegmentos_grid_newrow */
      }

      protected void gxnrModelos_grid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_873( ) ;
         while ( nGXsfl_87_idx <= nRC_GXsfl_87 )
         {
            sendrow_873( ) ;
            nGXsfl_87_idx = ((subModelos_grid_Islastpage==1)&&(nGXsfl_87_idx+1>subModelos_grid_fnc_Recordsperpage( )) ? 1 : nGXsfl_87_idx+1);
            sGXsfl_87_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_87_idx), 4, 0), 4, "0");
            SubsflControlProps_873( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Modelos_gridContainer)) ;
         /* End function gxnrModelos_grid_newrow */
      }

      protected void gxgrSegmentos_grid_refresh( int subSegmentos_grid_Rows ,
                                                 int subModelos_grid_Rows ,
                                                 bool AV10HasValidationErrors ,
                                                 string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         SEGMENTOS_GRID_nCurrentRecord = 0;
         RF272( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrSegmentos_grid_refresh */
      }

      protected void gxgrModelos_grid_refresh( int subSegmentos_grid_Rows ,
                                               int subModelos_grid_Rows ,
                                               bool AV10HasValidationErrors ,
                                               string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         MODELOS_GRID_nCurrentRecord = 0;
         RF273( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrModelos_grid_refresh */
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
         RF272( ) ;
         RF273( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavWizarddata_infogeneral_promodescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_infogeneral_promodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_promodescripcion_Enabled), 5, 0), true);
         edtavWizarddata_infogeneral_iniciopromo_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_infogeneral_iniciopromo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_iniciopromo_Enabled), 5, 0), true);
         edtavWizarddata_infogeneral_finpromo_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_infogeneral_finpromo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_finpromo_Enabled), 5, 0), true);
         edtavWizarddata_infogeneral_promobase_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_infogeneral_promobase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_promobase_Enabled), 5, 0), true);
         edtavWizarddata_infogeneral_distribuidorid_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_infogeneral_distribuidorid_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_distribuidorid_description_Enabled), 5, 0), true);
         edtavWizarddata_infogeneral_promoarte_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_infogeneral_promoarte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_promoarte_Enabled), 5, 0), true);
         cmbavWizarddata_segmentos_grid__segmento.Enabled = 0;
         edtavWizarddata_modelos_grid__modelodescripcion_Enabled = 0;
         edtavWizarddata_modelos_grid__modeloid_Enabled = 0;
         edtavWizarddata_modelos_grid__precio_Enabled = 0;
      }

      protected void RF272( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Segmentos_gridContainer.ClearRows();
         }
         wbStart = 70;
         nGXsfl_70_idx = 1;
         sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
         SubsflControlProps_702( ) ;
         bGXsfl_70_Refreshing = true;
         Segmentos_gridContainer.AddObjectProperty("GridName", "Segmentos_grid");
         Segmentos_gridContainer.AddObjectProperty("CmpContext", sPrefix);
         Segmentos_gridContainer.AddObjectProperty("InMasterPage", "false");
         Segmentos_gridContainer.AddObjectProperty("Class", "GridNoBorder WorkWith");
         Segmentos_gridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Segmentos_gridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Segmentos_gridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSegmentos_grid_Backcolorstyle), 1, 0, ".", "")));
         Segmentos_gridContainer.PageSize = subSegmentos_grid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_702( ) ;
            /* Execute user event: Segmentos_grid.Load */
            E17272 ();
            if ( ( subSegmentos_grid_Islastpage == 0 ) && ( SEGMENTOS_GRID_nCurrentRecord > 0 ) && ( SEGMENTOS_GRID_nGridOutOfScope == 0 ) && ( nGXsfl_70_idx == 1 ) )
            {
               SEGMENTOS_GRID_nCurrentRecord = 0;
               SEGMENTOS_GRID_nGridOutOfScope = 1;
               subsegmentos_grid_firstpage( ) ;
               /* Execute user event: Segmentos_grid.Load */
               E17272 ();
            }
            wbEnd = 70;
            WB270( ) ;
         }
         bGXsfl_70_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes272( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected void RF273( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Modelos_gridContainer.ClearRows();
         }
         wbStart = 87;
         nGXsfl_87_idx = 1;
         sGXsfl_87_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_87_idx), 4, 0), 4, "0");
         SubsflControlProps_873( ) ;
         bGXsfl_87_Refreshing = true;
         Modelos_gridContainer.AddObjectProperty("GridName", "Modelos_grid");
         Modelos_gridContainer.AddObjectProperty("CmpContext", sPrefix);
         Modelos_gridContainer.AddObjectProperty("InMasterPage", "false");
         Modelos_gridContainer.AddObjectProperty("Class", "GridNoBorder WorkWith");
         Modelos_gridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Modelos_gridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Modelos_gridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subModelos_grid_Backcolorstyle), 1, 0, ".", "")));
         Modelos_gridContainer.PageSize = subModelos_grid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_873( ) ;
            /* Execute user event: Modelos_grid.Load */
            E18273 ();
            if ( ( subModelos_grid_Islastpage == 0 ) && ( MODELOS_GRID_nCurrentRecord > 0 ) && ( MODELOS_GRID_nGridOutOfScope == 0 ) && ( nGXsfl_87_idx == 1 ) )
            {
               MODELOS_GRID_nCurrentRecord = 0;
               MODELOS_GRID_nGridOutOfScope = 1;
               submodelos_grid_firstpage( ) ;
               /* Execute user event: Modelos_grid.Load */
               E18273 ();
            }
            wbEnd = 87;
            WB270( ) ;
         }
         bGXsfl_87_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes273( )
      {
      }

      protected int subSegmentos_grid_fnc_Pagecount( )
      {
         SEGMENTOS_GRID_nRecordCount = subSegmentos_grid_fnc_Recordcount( );
         if ( ((int)((SEGMENTOS_GRID_nRecordCount) % (subSegmentos_grid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(SEGMENTOS_GRID_nRecordCount/ (decimal)(subSegmentos_grid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(SEGMENTOS_GRID_nRecordCount/ (decimal)(subSegmentos_grid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subSegmentos_grid_fnc_Recordcount( )
      {
         return AV13WizardData_Segmentos_Grid.Count ;
      }

      protected int subSegmentos_grid_fnc_Recordsperpage( )
      {
         if ( subSegmentos_grid_Rows > 0 )
         {
            return subSegmentos_grid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subSegmentos_grid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(SEGMENTOS_GRID_nFirstRecordOnPage/ (decimal)(subSegmentos_grid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subsegmentos_grid_firstpage( )
      {
         SEGMENTOS_GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"SEGMENTOS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(SEGMENTOS_GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrSegmentos_grid_refresh( subSegmentos_grid_Rows, subModelos_grid_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subsegmentos_grid_nextpage( )
      {
         SEGMENTOS_GRID_nRecordCount = subSegmentos_grid_fnc_Recordcount( );
         if ( ( SEGMENTOS_GRID_nRecordCount >= subSegmentos_grid_fnc_Recordsperpage( ) ) && ( SEGMENTOS_GRID_nEOF == 0 ) )
         {
            SEGMENTOS_GRID_nFirstRecordOnPage = (long)(SEGMENTOS_GRID_nFirstRecordOnPage+subSegmentos_grid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"SEGMENTOS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(SEGMENTOS_GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         Segmentos_gridContainer.AddObjectProperty("SEGMENTOS_GRID_nFirstRecordOnPage", SEGMENTOS_GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrSegmentos_grid_refresh( subSegmentos_grid_Rows, subModelos_grid_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((SEGMENTOS_GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subsegmentos_grid_previouspage( )
      {
         if ( SEGMENTOS_GRID_nFirstRecordOnPage >= subSegmentos_grid_fnc_Recordsperpage( ) )
         {
            SEGMENTOS_GRID_nFirstRecordOnPage = (long)(SEGMENTOS_GRID_nFirstRecordOnPage-subSegmentos_grid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"SEGMENTOS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(SEGMENTOS_GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrSegmentos_grid_refresh( subSegmentos_grid_Rows, subModelos_grid_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subsegmentos_grid_lastpage( )
      {
         SEGMENTOS_GRID_nRecordCount = subSegmentos_grid_fnc_Recordcount( );
         if ( SEGMENTOS_GRID_nRecordCount > subSegmentos_grid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((SEGMENTOS_GRID_nRecordCount) % (subSegmentos_grid_fnc_Recordsperpage( )))) == 0 )
            {
               SEGMENTOS_GRID_nFirstRecordOnPage = (long)(SEGMENTOS_GRID_nRecordCount-subSegmentos_grid_fnc_Recordsperpage( ));
            }
            else
            {
               SEGMENTOS_GRID_nFirstRecordOnPage = (long)(SEGMENTOS_GRID_nRecordCount-((int)((SEGMENTOS_GRID_nRecordCount) % (subSegmentos_grid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            SEGMENTOS_GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"SEGMENTOS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(SEGMENTOS_GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrSegmentos_grid_refresh( subSegmentos_grid_Rows, subModelos_grid_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subsegmentos_grid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            SEGMENTOS_GRID_nFirstRecordOnPage = (long)(subSegmentos_grid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            SEGMENTOS_GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"SEGMENTOS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(SEGMENTOS_GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrSegmentos_grid_refresh( subSegmentos_grid_Rows, subModelos_grid_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subModelos_grid_fnc_Pagecount( )
      {
         MODELOS_GRID_nRecordCount = subModelos_grid_fnc_Recordcount( );
         if ( ((int)((MODELOS_GRID_nRecordCount) % (subModelos_grid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(MODELOS_GRID_nRecordCount/ (decimal)(subModelos_grid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(MODELOS_GRID_nRecordCount/ (decimal)(subModelos_grid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subModelos_grid_fnc_Recordcount( )
      {
         return AV12WizardData_Modelos_Grid.Count ;
      }

      protected int subModelos_grid_fnc_Recordsperpage( )
      {
         if ( subModelos_grid_Rows > 0 )
         {
            return subModelos_grid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subModelos_grid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(MODELOS_GRID_nFirstRecordOnPage/ (decimal)(subModelos_grid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short submodelos_grid_firstpage( )
      {
         MODELOS_GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"MODELOS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(MODELOS_GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrModelos_grid_refresh( subSegmentos_grid_Rows, subModelos_grid_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short submodelos_grid_nextpage( )
      {
         MODELOS_GRID_nRecordCount = subModelos_grid_fnc_Recordcount( );
         if ( ( MODELOS_GRID_nRecordCount >= subModelos_grid_fnc_Recordsperpage( ) ) && ( MODELOS_GRID_nEOF == 0 ) )
         {
            MODELOS_GRID_nFirstRecordOnPage = (long)(MODELOS_GRID_nFirstRecordOnPage+subModelos_grid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"MODELOS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(MODELOS_GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         Modelos_gridContainer.AddObjectProperty("MODELOS_GRID_nFirstRecordOnPage", MODELOS_GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrModelos_grid_refresh( subSegmentos_grid_Rows, subModelos_grid_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((MODELOS_GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short submodelos_grid_previouspage( )
      {
         if ( MODELOS_GRID_nFirstRecordOnPage >= subModelos_grid_fnc_Recordsperpage( ) )
         {
            MODELOS_GRID_nFirstRecordOnPage = (long)(MODELOS_GRID_nFirstRecordOnPage-subModelos_grid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"MODELOS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(MODELOS_GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrModelos_grid_refresh( subSegmentos_grid_Rows, subModelos_grid_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short submodelos_grid_lastpage( )
      {
         MODELOS_GRID_nRecordCount = subModelos_grid_fnc_Recordcount( );
         if ( MODELOS_GRID_nRecordCount > subModelos_grid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((MODELOS_GRID_nRecordCount) % (subModelos_grid_fnc_Recordsperpage( )))) == 0 )
            {
               MODELOS_GRID_nFirstRecordOnPage = (long)(MODELOS_GRID_nRecordCount-subModelos_grid_fnc_Recordsperpage( ));
            }
            else
            {
               MODELOS_GRID_nFirstRecordOnPage = (long)(MODELOS_GRID_nRecordCount-((int)((MODELOS_GRID_nRecordCount) % (subModelos_grid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            MODELOS_GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"MODELOS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(MODELOS_GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrModelos_grid_refresh( subSegmentos_grid_Rows, subModelos_grid_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int submodelos_grid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            MODELOS_GRID_nFirstRecordOnPage = (long)(subModelos_grid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            MODELOS_GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"MODELOS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(MODELOS_GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrModelos_grid_refresh( subSegmentos_grid_Rows, subModelos_grid_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavWizarddata_infogeneral_promodescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_infogeneral_promodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_promodescripcion_Enabled), 5, 0), true);
         edtavWizarddata_infogeneral_iniciopromo_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_infogeneral_iniciopromo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_iniciopromo_Enabled), 5, 0), true);
         edtavWizarddata_infogeneral_finpromo_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_infogeneral_finpromo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_finpromo_Enabled), 5, 0), true);
         edtavWizarddata_infogeneral_promobase_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_infogeneral_promobase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_promobase_Enabled), 5, 0), true);
         edtavWizarddata_infogeneral_distribuidorid_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_infogeneral_distribuidorid_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_distribuidorid_description_Enabled), 5, 0), true);
         edtavWizarddata_infogeneral_promoarte_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_infogeneral_promoarte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_infogeneral_promoarte_Enabled), 5, 0), true);
         cmbavWizarddata_segmentos_grid__segmento.Enabled = 0;
         edtavWizarddata_modelos_grid__modelodescripcion_Enabled = 0;
         edtavWizarddata_modelos_grid__modeloid_Enabled = 0;
         edtavWizarddata_modelos_grid__precio_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP270( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16272 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vWIZARDDATA"), AV11WizardData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wizarddata"), AV11WizardData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wizarddata_segmentos_grid"), AV13WizardData_Segmentos_Grid);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wizarddata_modelos_grid"), AV12WizardData_Modelos_Grid);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vWIZARDDATA_SEGMENTOS_GRID"), AV13WizardData_Segmentos_Grid);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vWIZARDDATA_MODELOS_GRID"), AV12WizardData_Modelos_Grid);
            /* Read saved values. */
            nRC_GXsfl_70 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_70"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_87 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_87"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            SEGMENTOS_GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"SEGMENTOS_GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            MODELOS_GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"MODELOS_GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            SEGMENTOS_GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"SEGMENTOS_GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            MODELOS_GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"MODELOS_GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subSegmentos_grid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"SEGMENTOS_GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"SEGMENTOS_GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSegmentos_grid_Rows), 6, 0, ".", "")));
            subModelos_grid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"MODELOS_GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"MODELOS_GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subModelos_grid_Rows), 6, 0, ".", "")));
            nRC_GXsfl_70 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_70"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_70_fel_idx = 0;
            while ( nGXsfl_70_fel_idx < nRC_GXsfl_70 )
            {
               nGXsfl_70_fel_idx = ((subSegmentos_grid_Islastpage==1)&&(nGXsfl_70_fel_idx+1>subSegmentos_grid_fnc_Recordsperpage( )) ? 1 : nGXsfl_70_fel_idx+1);
               sGXsfl_70_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_702( ) ;
               AV24GXV7 = (int)(nGXsfl_70_fel_idx+SEGMENTOS_GRID_nFirstRecordOnPage);
               if ( ( AV13WizardData_Segmentos_Grid.Count >= AV24GXV7 ) && ( AV24GXV7 > 0 ) )
               {
                  AV13WizardData_Segmentos_Grid.CurrentItem = ((SdtWPWizardPromoData_Segmentos_GridItem)AV13WizardData_Segmentos_Grid.Item(AV24GXV7));
               }
            }
            if ( nGXsfl_70_fel_idx == 0 )
            {
               nGXsfl_70_idx = 1;
               sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
               SubsflControlProps_702( ) ;
            }
            nGXsfl_70_fel_idx = 1;
            nRC_GXsfl_87 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_87"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_87_fel_idx = 0;
            while ( nGXsfl_87_fel_idx < nRC_GXsfl_87 )
            {
               nGXsfl_87_fel_idx = ((subModelos_grid_Islastpage==1)&&(nGXsfl_87_fel_idx+1>subModelos_grid_fnc_Recordsperpage( )) ? 1 : nGXsfl_87_fel_idx+1);
               sGXsfl_87_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_87_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_873( ) ;
               AV26GXV9 = (int)(nGXsfl_87_fel_idx+MODELOS_GRID_nFirstRecordOnPage);
               if ( ( AV12WizardData_Modelos_Grid.Count >= AV26GXV9 ) && ( AV26GXV9 > 0 ) )
               {
                  AV12WizardData_Modelos_Grid.CurrentItem = ((SdtWPWizardPromoData_Modelos_GridItem)AV12WizardData_Modelos_Grid.Item(AV26GXV9));
               }
            }
            if ( nGXsfl_87_fel_idx == 0 )
            {
               nGXsfl_87_idx = 1;
               sGXsfl_87_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_87_idx), 4, 0), 4, "0");
               SubsflControlProps_873( ) ;
            }
            nGXsfl_87_fel_idx = 1;
            /* Read variables values. */
            AV11WizardData.gxTpr_Infogeneral.gxTpr_Promodescripcion = cgiGet( edtavWizarddata_infogeneral_promodescripcion_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavWizarddata_infogeneral_iniciopromo_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {""}), 1, "WIZARDDATA_INFOGENERAL_INICIOPROMO");
               GX_FocusControl = edtavWizarddata_infogeneral_iniciopromo_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11WizardData.gxTpr_Infogeneral.gxTpr_Iniciopromo = DateTime.MinValue;
            }
            else
            {
               AV11WizardData.gxTpr_Infogeneral.gxTpr_Iniciopromo = context.localUtil.CToD( cgiGet( edtavWizarddata_infogeneral_iniciopromo_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavWizarddata_infogeneral_finpromo_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {""}), 1, "WIZARDDATA_INFOGENERAL_FINPROMO");
               GX_FocusControl = edtavWizarddata_infogeneral_finpromo_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11WizardData.gxTpr_Infogeneral.gxTpr_Finpromo = DateTime.MinValue;
            }
            else
            {
               AV11WizardData.gxTpr_Infogeneral.gxTpr_Finpromo = context.localUtil.CToD( cgiGet( edtavWizarddata_infogeneral_finpromo_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV11WizardData.gxTpr_Infogeneral.gxTpr_Promobase = cgiGet( edtavWizarddata_infogeneral_promobase_Internalname);
            AV11WizardData.gxTpr_Infogeneral.gxTpr_Distribuidorid_description = cgiGet( edtavWizarddata_infogeneral_distribuidorid_description_Internalname);
            AV11WizardData.gxTpr_Infogeneral.gxTpr_Promoarte = cgiGet( edtavWizarddata_infogeneral_promoarte_Internalname);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E16272 ();
         if (returnInSub) return;
      }

      protected void E16272( )
      {
         /* Start Routine */
         returnInSub = false;
         AV17Pasa = true;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         Modelos_grid_empowerer_Gridinternalname = subModelos_grid_Internalname;
         ucModelos_grid_empowerer.SendProperty(context, sPrefix, false, Modelos_grid_empowerer_Internalname, "GridInternalName", Modelos_grid_empowerer_Gridinternalname);
         subModelos_grid_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"MODELOS_GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subModelos_grid_Rows), 6, 0, ".", "")));
         Segmentos_grid_empowerer_Gridinternalname = subSegmentos_grid_Internalname;
         ucSegmentos_grid_empowerer.SendProperty(context, sPrefix, false, Segmentos_grid_empowerer_Internalname, "GridInternalName", Segmentos_grid_empowerer_Gridinternalname);
         subSegmentos_grid_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"SEGMENTOS_GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSegmentos_grid_Rows), 6, 0, ".", "")));
      }

      private void E17272( )
      {
         /* Segmentos_grid_Load Routine */
         returnInSub = false;
         AV24GXV7 = 1;
         while ( AV24GXV7 <= AV13WizardData_Segmentos_Grid.Count )
         {
            AV13WizardData_Segmentos_Grid.CurrentItem = ((SdtWPWizardPromoData_Segmentos_GridItem)AV13WizardData_Segmentos_Grid.Item(AV24GXV7));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 70;
            }
            if ( ( subSegmentos_grid_Islastpage == 1 ) || ( subSegmentos_grid_Rows == 0 ) || ( ( SEGMENTOS_GRID_nCurrentRecord >= SEGMENTOS_GRID_nFirstRecordOnPage ) && ( SEGMENTOS_GRID_nCurrentRecord < SEGMENTOS_GRID_nFirstRecordOnPage + subSegmentos_grid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_702( ) ;
            }
            SEGMENTOS_GRID_nEOF = (short)(((SEGMENTOS_GRID_nCurrentRecord<SEGMENTOS_GRID_nFirstRecordOnPage+subSegmentos_grid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"SEGMENTOS_GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(SEGMENTOS_GRID_nEOF), 1, 0, ".", "")));
            SEGMENTOS_GRID_nCurrentRecord = (long)(SEGMENTOS_GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_70_Refreshing )
            {
               DoAjaxLoad(70, Segmentos_gridRow);
            }
            AV24GXV7 = (int)(AV24GXV7+1);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E11272 ();
         if (returnInSub) return;
      }

      protected void E11272( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV10HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S122 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S132 ();
            if (returnInSub) return;
            AV5WebSession.Remove(AV6WebSessionKey);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E12272( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S122 ();
         if (returnInSub) return;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpwizardpromo.aspx"+UrlEncode(StringUtil.RTrim("Resumen")) + "," + UrlEncode(StringUtil.RTrim("Modelos")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wpwizardpromo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E13272( )
      {
         /* 'WizardGoTo Modelos' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S122 ();
         if (returnInSub) return;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpwizardpromo.aspx"+UrlEncode(StringUtil.RTrim("Resumen")) + "," + UrlEncode(StringUtil.RTrim("Modelos")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wpwizardpromo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E14272( )
      {
         /* 'WizardGoTo Segmentos' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S122 ();
         if (returnInSub) return;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpwizardpromo.aspx"+UrlEncode(StringUtil.RTrim("Resumen")) + "," + UrlEncode(StringUtil.RTrim("Segmentos")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wpwizardpromo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E15272( )
      {
         /* 'WizardGoTo InfoGeneral' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S122 ();
         if (returnInSub) return;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpwizardpromo.aspx"+UrlEncode(StringUtil.RTrim("Resumen")) + "," + UrlEncode(StringUtil.RTrim("InfoGeneral")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wpwizardpromo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV12WizardData_Modelos_Grid = AV11WizardData.gxTpr_Modelos.gxTpr_Grid;
         gx_BV87 = true;
         AV13WizardData_Segmentos_Grid = AV11WizardData.gxTpr_Segmentos.gxTpr_Grid;
         gx_BV70 = true;
      }

      protected void S122( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S132( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         AV14PromocionArte = AV5WebSession.Get(context.GetMessage( "ArteBlob", ""));
         new guardarpromocionwizard(context ).execute(  AV11WizardData,  AV14PromocionArte, out  AV15Resultado, out  AV16CodigoError) ;
         if ( AV16CodigoError == 0 )
         {
            GX_msglist.addItem(StringUtil.Trim( AV15Resultado));
            AV5WebSession.Remove(context.GetMessage( "ArteBlob", ""));
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            GX_msglist.addItem(StringUtil.Trim( AV15Resultado));
         }
      }

      private void E18273( )
      {
         /* Modelos_grid_Load Routine */
         returnInSub = false;
         AV26GXV9 = 1;
         while ( AV26GXV9 <= AV12WizardData_Modelos_Grid.Count )
         {
            AV12WizardData_Modelos_Grid.CurrentItem = ((SdtWPWizardPromoData_Modelos_GridItem)AV12WizardData_Modelos_Grid.Item(AV26GXV9));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 87;
            }
            if ( ( subModelos_grid_Islastpage == 1 ) || ( subModelos_grid_Rows == 0 ) || ( ( MODELOS_GRID_nCurrentRecord >= MODELOS_GRID_nFirstRecordOnPage ) && ( MODELOS_GRID_nCurrentRecord < MODELOS_GRID_nFirstRecordOnPage + subModelos_grid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_873( ) ;
            }
            MODELOS_GRID_nEOF = (short)(((MODELOS_GRID_nCurrentRecord<MODELOS_GRID_nFirstRecordOnPage+subModelos_grid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"MODELOS_GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(MODELOS_GRID_nEOF), 1, 0, ".", "")));
            MODELOS_GRID_nCurrentRecord = (long)(MODELOS_GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_87_Refreshing )
            {
               DoAjaxLoad(87, Modelos_gridRow);
            }
            AV26GXV9 = (int)(AV26GXV9+1);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         AV8PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         AV7GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
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
         PA272( ) ;
         WS272( ) ;
         WE272( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SESSION ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV6WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV8PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV7GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA272( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpwizardpromoresumen", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA272( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
            AV8PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
            AV7GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
         wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
         wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6WebSessionKey, wcpOAV6WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV8PreviousStep, wcpOAV8PreviousStep) != 0 ) || ( AV7GoingBack != wcpOAV7GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV6WebSessionKey = AV6WebSessionKey;
         wcpOAV8PreviousStep = AV8PreviousStep;
         wcpOAV7GoingBack = AV7GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV6WebSessionKey) > 0 )
         {
            AV6WebSessionKey = cgiGet( sCtrlAV6WebSessionKey);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         }
         else
         {
            AV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_PARM");
         }
         sCtrlAV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV8PreviousStep) > 0 )
         {
            AV8PreviousStep = cgiGet( sCtrlAV8PreviousStep);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         }
         else
         {
            AV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_PARM");
         }
         sCtrlAV7GoingBack = cgiGet( sPrefix+"AV7GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV7GoingBack) > 0 )
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV7GoingBack));
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         else
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV7GoingBack_PARM"));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA272( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS272( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS272( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_PARM", AV6WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV6WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_PARM", AV8PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV8PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_PARM", StringUtil.BoolToStr( AV7GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_CTRL", StringUtil.RTrim( sCtrlAV7GoingBack));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE272( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025102815461676", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("wpwizardpromoresumen.js", "?2025102815461676", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_702( )
      {
         cmbavWizarddata_segmentos_grid__segmento_Internalname = sPrefix+"WIZARDDATA_SEGMENTOS_GRID__SEGMENTO_"+sGXsfl_70_idx;
      }

      protected void SubsflControlProps_fel_702( )
      {
         cmbavWizarddata_segmentos_grid__segmento_Internalname = sPrefix+"WIZARDDATA_SEGMENTOS_GRID__SEGMENTO_"+sGXsfl_70_fel_idx;
      }

      protected void sendrow_702( )
      {
         sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
         SubsflControlProps_702( ) ;
         WB270( ) ;
         if ( ( subSegmentos_grid_Rows * 1 == 0 ) || ( nGXsfl_70_idx <= subSegmentos_grid_fnc_Recordsperpage( ) * 1 ) )
         {
            Segmentos_gridRow = GXWebRow.GetNew(context,Segmentos_gridContainer);
            if ( subSegmentos_grid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subSegmentos_grid_Backstyle = 0;
               if ( StringUtil.StrCmp(subSegmentos_grid_Class, "") != 0 )
               {
                  subSegmentos_grid_Linesclass = subSegmentos_grid_Class+"Odd";
               }
            }
            else if ( subSegmentos_grid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subSegmentos_grid_Backstyle = 0;
               subSegmentos_grid_Backcolor = subSegmentos_grid_Allbackcolor;
               if ( StringUtil.StrCmp(subSegmentos_grid_Class, "") != 0 )
               {
                  subSegmentos_grid_Linesclass = subSegmentos_grid_Class+"Uniform";
               }
            }
            else if ( subSegmentos_grid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subSegmentos_grid_Backstyle = 1;
               if ( StringUtil.StrCmp(subSegmentos_grid_Class, "") != 0 )
               {
                  subSegmentos_grid_Linesclass = subSegmentos_grid_Class+"Odd";
               }
               subSegmentos_grid_Backcolor = (int)(0x0);
            }
            else if ( subSegmentos_grid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subSegmentos_grid_Backstyle = 1;
               if ( ((int)((nGXsfl_70_idx) % (2))) == 0 )
               {
                  subSegmentos_grid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subSegmentos_grid_Class, "") != 0 )
                  {
                     subSegmentos_grid_Linesclass = subSegmentos_grid_Class+"Even";
                  }
               }
               else
               {
                  subSegmentos_grid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subSegmentos_grid_Class, "") != 0 )
                  {
                     subSegmentos_grid_Linesclass = subSegmentos_grid_Class+"Odd";
                  }
               }
            }
            if ( Segmentos_gridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridNoBorder WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_70_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Segmentos_gridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'" + sGXsfl_70_idx + "',70)\"";
            if ( ( cmbavWizarddata_segmentos_grid__segmento.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "WIZARDDATA_SEGMENTOS_GRID__SEGMENTO_" + sGXsfl_70_idx;
               cmbavWizarddata_segmentos_grid__segmento.Name = GXCCtl;
               cmbavWizarddata_segmentos_grid__segmento.WebTags = "";
               cmbavWizarddata_segmentos_grid__segmento.addItem("AUTO", context.GetMessage( "AUTO", ""), 0);
               cmbavWizarddata_segmentos_grid__segmento.addItem("CAMIONETA", context.GetMessage( "CAMIONETA", ""), 0);
               cmbavWizarddata_segmentos_grid__segmento.addItem("CAMIÓN", context.GetMessage( "CAMIÓN", ""), 0);
               cmbavWizarddata_segmentos_grid__segmento.addItem("AGRÍCOLA", context.GetMessage( "AGRÍCOLA", ""), 0);
               cmbavWizarddata_segmentos_grid__segmento.addItem("INDUSTRIAL", context.GetMessage( "INDUSTRIAL", ""), 0);
               cmbavWizarddata_segmentos_grid__segmento.addItem("OTR", context.GetMessage( "OTR", ""), 0);
               if ( cmbavWizarddata_segmentos_grid__segmento.ItemCount > 0 )
               {
                  if ( ( AV24GXV7 > 0 ) && ( AV13WizardData_Segmentos_Grid.Count >= AV24GXV7 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtWPWizardPromoData_Segmentos_GridItem)AV13WizardData_Segmentos_Grid.Item(AV24GXV7)).gxTpr_Segmento)) )
                  {
                     ((SdtWPWizardPromoData_Segmentos_GridItem)AV13WizardData_Segmentos_Grid.Item(AV24GXV7)).gxTpr_Segmento = cmbavWizarddata_segmentos_grid__segmento.getValidValue(((SdtWPWizardPromoData_Segmentos_GridItem)AV13WizardData_Segmentos_Grid.Item(AV24GXV7)).gxTpr_Segmento);
                  }
               }
            }
            /* ComboBox */
            Segmentos_gridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavWizarddata_segmentos_grid__segmento,(string)cmbavWizarddata_segmentos_grid__segmento_Internalname,StringUtil.RTrim( ((SdtWPWizardPromoData_Segmentos_GridItem)AV13WizardData_Segmentos_Grid.Item(AV24GXV7)).gxTpr_Segmento),(short)1,(string)cmbavWizarddata_segmentos_grid__segmento_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbavWizarddata_segmentos_grid__segmento.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"",(string)"",(bool)true,(short)0});
            cmbavWizarddata_segmentos_grid__segmento.CurrentValue = StringUtil.RTrim( ((SdtWPWizardPromoData_Segmentos_GridItem)AV13WizardData_Segmentos_Grid.Item(AV24GXV7)).gxTpr_Segmento);
            AssignProp(sPrefix, false, cmbavWizarddata_segmentos_grid__segmento_Internalname, "Values", (string)(cmbavWizarddata_segmentos_grid__segmento.ToJavascriptSource()), !bGXsfl_70_Refreshing);
            send_integrity_lvl_hashes272( ) ;
            Segmentos_gridContainer.AddRow(Segmentos_gridRow);
            nGXsfl_70_idx = ((subSegmentos_grid_Islastpage==1)&&(nGXsfl_70_idx+1>subSegmentos_grid_fnc_Recordsperpage( )) ? 1 : nGXsfl_70_idx+1);
            sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
            SubsflControlProps_702( ) ;
         }
         /* End function sendrow_702 */
      }

      protected void SubsflControlProps_873( )
      {
         edtavWizarddata_modelos_grid__modelodescripcion_Internalname = sPrefix+"WIZARDDATA_MODELOS_GRID__MODELODESCRIPCION_"+sGXsfl_87_idx;
         edtavWizarddata_modelos_grid__modeloid_Internalname = sPrefix+"WIZARDDATA_MODELOS_GRID__MODELOID_"+sGXsfl_87_idx;
         edtavWizarddata_modelos_grid__precio_Internalname = sPrefix+"WIZARDDATA_MODELOS_GRID__PRECIO_"+sGXsfl_87_idx;
      }

      protected void SubsflControlProps_fel_873( )
      {
         edtavWizarddata_modelos_grid__modelodescripcion_Internalname = sPrefix+"WIZARDDATA_MODELOS_GRID__MODELODESCRIPCION_"+sGXsfl_87_fel_idx;
         edtavWizarddata_modelos_grid__modeloid_Internalname = sPrefix+"WIZARDDATA_MODELOS_GRID__MODELOID_"+sGXsfl_87_fel_idx;
         edtavWizarddata_modelos_grid__precio_Internalname = sPrefix+"WIZARDDATA_MODELOS_GRID__PRECIO_"+sGXsfl_87_fel_idx;
      }

      protected void sendrow_873( )
      {
         sGXsfl_87_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_87_idx), 4, 0), 4, "0");
         SubsflControlProps_873( ) ;
         WB270( ) ;
         if ( ( subModelos_grid_Rows * 1 == 0 ) || ( nGXsfl_87_idx <= subModelos_grid_fnc_Recordsperpage( ) * 1 ) )
         {
            Modelos_gridRow = GXWebRow.GetNew(context,Modelos_gridContainer);
            if ( subModelos_grid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subModelos_grid_Backstyle = 0;
               if ( StringUtil.StrCmp(subModelos_grid_Class, "") != 0 )
               {
                  subModelos_grid_Linesclass = subModelos_grid_Class+"Odd";
               }
            }
            else if ( subModelos_grid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subModelos_grid_Backstyle = 0;
               subModelos_grid_Backcolor = subModelos_grid_Allbackcolor;
               if ( StringUtil.StrCmp(subModelos_grid_Class, "") != 0 )
               {
                  subModelos_grid_Linesclass = subModelos_grid_Class+"Uniform";
               }
            }
            else if ( subModelos_grid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subModelos_grid_Backstyle = 1;
               if ( StringUtil.StrCmp(subModelos_grid_Class, "") != 0 )
               {
                  subModelos_grid_Linesclass = subModelos_grid_Class+"Odd";
               }
               subModelos_grid_Backcolor = (int)(0x0);
            }
            else if ( subModelos_grid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subModelos_grid_Backstyle = 1;
               if ( ((int)((nGXsfl_87_idx) % (2))) == 0 )
               {
                  subModelos_grid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subModelos_grid_Class, "") != 0 )
                  {
                     subModelos_grid_Linesclass = subModelos_grid_Class+"Even";
                  }
               }
               else
               {
                  subModelos_grid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subModelos_grid_Class, "") != 0 )
                  {
                     subModelos_grid_Linesclass = subModelos_grid_Class+"Odd";
                  }
               }
            }
            if ( Modelos_gridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridNoBorder WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_87_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Modelos_gridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'" + sPrefix + "',false,'" + sGXsfl_87_idx + "',87)\"";
            ROClassString = "Attribute";
            Modelos_gridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWizarddata_modelos_grid__modelodescripcion_Internalname,((SdtWPWizardPromoData_Modelos_GridItem)AV12WizardData_Modelos_Grid.Item(AV26GXV9)).gxTpr_Modelodescripcion,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWizarddata_modelos_grid__modelodescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWizarddata_modelos_grid__modelodescripcion_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)87,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Modelos_gridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Modelos_gridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWizarddata_modelos_grid__modeloid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtWPWizardPromoData_Modelos_GridItem)AV12WizardData_Modelos_Grid.Item(AV26GXV9)).gxTpr_Modeloid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavWizarddata_modelos_grid__modeloid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtWPWizardPromoData_Modelos_GridItem)AV12WizardData_Modelos_Grid.Item(AV26GXV9)).gxTpr_Modeloid), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtWPWizardPromoData_Modelos_GridItem)AV12WizardData_Modelos_Grid.Item(AV26GXV9)).gxTpr_Modeloid), "ZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWizarddata_modelos_grid__modeloid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavWizarddata_modelos_grid__modeloid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)87,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Modelos_gridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'" + sPrefix + "',false,'" + sGXsfl_87_idx + "',87)\"";
            ROClassString = "Attribute";
            Modelos_gridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWizarddata_modelos_grid__precio_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtWPWizardPromoData_Modelos_GridItem)AV12WizardData_Modelos_Grid.Item(AV26GXV9)).gxTpr_Precio, 14, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavWizarddata_modelos_grid__precio_Enabled!=0) ? context.localUtil.Format( ((SdtWPWizardPromoData_Modelos_GridItem)AV12WizardData_Modelos_Grid.Item(AV26GXV9)).gxTpr_Precio, "$ Z,ZZZ,ZZ9.99") : context.localUtil.Format( ((SdtWPWizardPromoData_Modelos_GridItem)AV12WizardData_Modelos_Grid.Item(AV26GXV9)).gxTpr_Precio, "$ Z,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,90);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWizarddata_modelos_grid__precio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWizarddata_modelos_grid__precio_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)87,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes273( ) ;
            GXCCtl = "vWIZARDDATA_" + sGXsfl_87_idx;
            if ( context.isAjaxRequest( ) )
            {
               context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+GXCCtl, AV11WizardData);
            }
            else
            {
               context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+GXCCtl, AV11WizardData);
            }
            Modelos_gridContainer.AddRow(Modelos_gridRow);
            nGXsfl_87_idx = ((subModelos_grid_Islastpage==1)&&(nGXsfl_87_idx+1>subModelos_grid_fnc_Recordsperpage( )) ? 1 : nGXsfl_87_idx+1);
            sGXsfl_87_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_87_idx), 4, 0), 4, "0");
            SubsflControlProps_873( ) ;
         }
         /* End function sendrow_873 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "WIZARDDATA_SEGMENTOS_GRID__SEGMENTO_" + sGXsfl_70_idx;
         cmbavWizarddata_segmentos_grid__segmento.Name = GXCCtl;
         cmbavWizarddata_segmentos_grid__segmento.WebTags = "";
         cmbavWizarddata_segmentos_grid__segmento.addItem("AUTO", context.GetMessage( "AUTO", ""), 0);
         cmbavWizarddata_segmentos_grid__segmento.addItem("CAMIONETA", context.GetMessage( "CAMIONETA", ""), 0);
         cmbavWizarddata_segmentos_grid__segmento.addItem("CAMIÓN", context.GetMessage( "CAMIÓN", ""), 0);
         cmbavWizarddata_segmentos_grid__segmento.addItem("AGRÍCOLA", context.GetMessage( "AGRÍCOLA", ""), 0);
         cmbavWizarddata_segmentos_grid__segmento.addItem("INDUSTRIAL", context.GetMessage( "INDUSTRIAL", ""), 0);
         cmbavWizarddata_segmentos_grid__segmento.addItem("OTR", context.GetMessage( "OTR", ""), 0);
         if ( cmbavWizarddata_segmentos_grid__segmento.ItemCount > 0 )
         {
            if ( ( AV24GXV7 > 0 ) && ( AV13WizardData_Segmentos_Grid.Count >= AV24GXV7 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtWPWizardPromoData_Segmentos_GridItem)AV13WizardData_Segmentos_Grid.Item(AV24GXV7)).gxTpr_Segmento)) )
            {
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl70( )
      {
         if ( Segmentos_gridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Segmentos_gridContainer"+"DivS\" data-gxgridid=\"70\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subSegmentos_grid_Internalname, subSegmentos_grid_Internalname, "", "GridNoBorder WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subSegmentos_grid_Backcolorstyle == 0 )
            {
               subSegmentos_grid_Titlebackstyle = 0;
               if ( StringUtil.Len( subSegmentos_grid_Class) > 0 )
               {
                  subSegmentos_grid_Linesclass = subSegmentos_grid_Class+"Title";
               }
            }
            else
            {
               subSegmentos_grid_Titlebackstyle = 1;
               if ( subSegmentos_grid_Backcolorstyle == 1 )
               {
                  subSegmentos_grid_Titlebackcolor = subSegmentos_grid_Allbackcolor;
                  if ( StringUtil.Len( subSegmentos_grid_Class) > 0 )
                  {
                     subSegmentos_grid_Linesclass = subSegmentos_grid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subSegmentos_grid_Class) > 0 )
                  {
                     subSegmentos_grid_Linesclass = subSegmentos_grid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Segmento", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Segmentos_gridContainer.AddObjectProperty("GridName", "Segmentos_grid");
         }
         else
         {
            Segmentos_gridContainer.AddObjectProperty("GridName", "Segmentos_grid");
            Segmentos_gridContainer.AddObjectProperty("Header", subSegmentos_grid_Header);
            Segmentos_gridContainer.AddObjectProperty("Class", "GridNoBorder WorkWith");
            Segmentos_gridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Segmentos_gridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Segmentos_gridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSegmentos_grid_Backcolorstyle), 1, 0, ".", "")));
            Segmentos_gridContainer.AddObjectProperty("CmpContext", sPrefix);
            Segmentos_gridContainer.AddObjectProperty("InMasterPage", "false");
            Segmentos_gridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Segmentos_gridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavWizarddata_segmentos_grid__segmento.Enabled), 5, 0, ".", "")));
            Segmentos_gridContainer.AddColumnProperties(Segmentos_gridColumn);
            Segmentos_gridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSegmentos_grid_Selectedindex), 4, 0, ".", "")));
            Segmentos_gridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSegmentos_grid_Allowselection), 1, 0, ".", "")));
            Segmentos_gridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSegmentos_grid_Selectioncolor), 9, 0, ".", "")));
            Segmentos_gridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSegmentos_grid_Allowhovering), 1, 0, ".", "")));
            Segmentos_gridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSegmentos_grid_Hoveringcolor), 9, 0, ".", "")));
            Segmentos_gridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSegmentos_grid_Allowcollapsing), 1, 0, ".", "")));
            Segmentos_gridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSegmentos_grid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl87( )
      {
         if ( Modelos_gridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Modelos_gridContainer"+"DivS\" data-gxgridid=\"87\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subModelos_grid_Internalname, subModelos_grid_Internalname, "", "GridNoBorder WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subModelos_grid_Backcolorstyle == 0 )
            {
               subModelos_grid_Titlebackstyle = 0;
               if ( StringUtil.Len( subModelos_grid_Class) > 0 )
               {
                  subModelos_grid_Linesclass = subModelos_grid_Class+"Title";
               }
            }
            else
            {
               subModelos_grid_Titlebackstyle = 1;
               if ( subModelos_grid_Backcolorstyle == 1 )
               {
                  subModelos_grid_Titlebackcolor = subModelos_grid_Allbackcolor;
                  if ( StringUtil.Len( subModelos_grid_Class) > 0 )
                  {
                     subModelos_grid_Linesclass = subModelos_grid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subModelos_grid_Class) > 0 )
                  {
                     subModelos_grid_Linesclass = subModelos_grid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Modelo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Modelo ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Modelos_gridContainer.AddObjectProperty("GridName", "Modelos_grid");
         }
         else
         {
            Modelos_gridContainer.AddObjectProperty("GridName", "Modelos_grid");
            Modelos_gridContainer.AddObjectProperty("Header", subModelos_grid_Header);
            Modelos_gridContainer.AddObjectProperty("Class", "GridNoBorder WorkWith");
            Modelos_gridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Modelos_gridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Modelos_gridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subModelos_grid_Backcolorstyle), 1, 0, ".", "")));
            Modelos_gridContainer.AddObjectProperty("CmpContext", sPrefix);
            Modelos_gridContainer.AddObjectProperty("InMasterPage", "false");
            Modelos_gridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Modelos_gridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWizarddata_modelos_grid__modelodescripcion_Enabled), 5, 0, ".", "")));
            Modelos_gridContainer.AddColumnProperties(Modelos_gridColumn);
            Modelos_gridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Modelos_gridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWizarddata_modelos_grid__modeloid_Enabled), 5, 0, ".", "")));
            Modelos_gridContainer.AddColumnProperties(Modelos_gridColumn);
            Modelos_gridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Modelos_gridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWizarddata_modelos_grid__precio_Enabled), 5, 0, ".", "")));
            Modelos_gridContainer.AddColumnProperties(Modelos_gridColumn);
            Modelos_gridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subModelos_grid_Selectedindex), 4, 0, ".", "")));
            Modelos_gridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subModelos_grid_Allowselection), 1, 0, ".", "")));
            Modelos_gridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subModelos_grid_Selectioncolor), 9, 0, ".", "")));
            Modelos_gridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subModelos_grid_Allowhovering), 1, 0, ".", "")));
            Modelos_gridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subModelos_grid_Hoveringcolor), 9, 0, ".", "")));
            Modelos_gridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subModelos_grid_Allowcollapsing), 1, 0, ".", "")));
            Modelos_gridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subModelos_grid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblInfogeneral_summarytitle_Internalname = sPrefix+"INFOGENERAL_SUMMARYTITLE";
         bttBtnwizardgotoinfogeneral_Internalname = sPrefix+"BTNWIZARDGOTOINFOGENERAL";
         divInfogeneral_summaryheadertable_Internalname = sPrefix+"INFOGENERAL_SUMMARYHEADERTABLE";
         edtavWizarddata_infogeneral_promodescripcion_Internalname = sPrefix+"WIZARDDATA_INFOGENERAL_PROMODESCRIPCION";
         edtavWizarddata_infogeneral_iniciopromo_Internalname = sPrefix+"WIZARDDATA_INFOGENERAL_INICIOPROMO";
         edtavWizarddata_infogeneral_finpromo_Internalname = sPrefix+"WIZARDDATA_INFOGENERAL_FINPROMO";
         divInfogeneral_unnamedtable1_Internalname = sPrefix+"INFOGENERAL_UNNAMEDTABLE1";
         edtavWizarddata_infogeneral_promobase_Internalname = sPrefix+"WIZARDDATA_INFOGENERAL_PROMOBASE";
         edtavWizarddata_infogeneral_distribuidorid_description_Internalname = sPrefix+"WIZARDDATA_INFOGENERAL_DISTRIBUIDORID_DESCRIPTION";
         edtavWizarddata_infogeneral_promoarte_Internalname = sPrefix+"WIZARDDATA_INFOGENERAL_PROMOARTE";
         divInfogeneral_tableattributes_Internalname = sPrefix+"INFOGENERAL_TABLEATTRIBUTES";
         divInfogeneral_summarytable_Internalname = sPrefix+"INFOGENERAL_SUMMARYTABLE";
         lblSegmentos_summarytitle_Internalname = sPrefix+"SEGMENTOS_SUMMARYTITLE";
         bttBtnwizardgotosegmentos_Internalname = sPrefix+"BTNWIZARDGOTOSEGMENTOS";
         divSegmentos_summaryheadertable_Internalname = sPrefix+"SEGMENTOS_SUMMARYHEADERTABLE";
         cmbavWizarddata_segmentos_grid__segmento_Internalname = sPrefix+"WIZARDDATA_SEGMENTOS_GRID__SEGMENTO";
         divSegmentos_tablegrid_Internalname = sPrefix+"SEGMENTOS_TABLEGRID";
         divSegmentos_summarytable_Internalname = sPrefix+"SEGMENTOS_SUMMARYTABLE";
         lblModelos_summarytitle_Internalname = sPrefix+"MODELOS_SUMMARYTITLE";
         bttBtnwizardgotomodelos_Internalname = sPrefix+"BTNWIZARDGOTOMODELOS";
         divModelos_summaryheadertable_Internalname = sPrefix+"MODELOS_SUMMARYHEADERTABLE";
         edtavWizarddata_modelos_grid__modelodescripcion_Internalname = sPrefix+"WIZARDDATA_MODELOS_GRID__MODELODESCRIPCION";
         edtavWizarddata_modelos_grid__modeloid_Internalname = sPrefix+"WIZARDDATA_MODELOS_GRID__MODELOID";
         edtavWizarddata_modelos_grid__precio_Internalname = sPrefix+"WIZARDDATA_MODELOS_GRID__PRECIO";
         divModelos_tablegrid_Internalname = sPrefix+"MODELOS_TABLEGRID";
         divModelos_summarytable_Internalname = sPrefix+"MODELOS_SUMMARYTABLE";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardlastnext_Internalname = sPrefix+"BTNWIZARDLASTNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Modelos_grid_empowerer_Internalname = sPrefix+"MODELOS_GRID_EMPOWERER";
         Segmentos_grid_empowerer_Internalname = sPrefix+"SEGMENTOS_GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subSegmentos_grid_Internalname = sPrefix+"SEGMENTOS_GRID";
         subModelos_grid_Internalname = sPrefix+"MODELOS_GRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subModelos_grid_Allowcollapsing = 0;
         subModelos_grid_Allowselection = 0;
         subModelos_grid_Header = "";
         subSegmentos_grid_Allowcollapsing = 0;
         subSegmentos_grid_Allowselection = 0;
         subSegmentos_grid_Header = "";
         edtavWizarddata_modelos_grid__precio_Jsonclick = "";
         edtavWizarddata_modelos_grid__precio_Enabled = 0;
         edtavWizarddata_modelos_grid__modeloid_Jsonclick = "";
         edtavWizarddata_modelos_grid__modeloid_Enabled = 0;
         edtavWizarddata_modelos_grid__modelodescripcion_Jsonclick = "";
         edtavWizarddata_modelos_grid__modelodescripcion_Enabled = 0;
         subModelos_grid_Class = "GridNoBorder WorkWith";
         subModelos_grid_Backcolorstyle = 0;
         cmbavWizarddata_segmentos_grid__segmento_Jsonclick = "";
         cmbavWizarddata_segmentos_grid__segmento.Enabled = 0;
         subSegmentos_grid_Class = "GridNoBorder WorkWith";
         subSegmentos_grid_Backcolorstyle = 0;
         Btnwizardlastnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardlastnext_Caption = context.GetMessage( "WWP_WizardFinishCaption", "");
         Btnwizardlastnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardlastnext_Tooltiptext = "";
         Btnwizardprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardprevious_Caption = context.GetMessage( "GXM_previous", "");
         Btnwizardprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardprevious_Tooltiptext = "";
         edtavWizarddata_infogeneral_promoarte_Jsonclick = "";
         edtavWizarddata_infogeneral_promoarte_Parameters = "";
         edtavWizarddata_infogeneral_promoarte_Contenttype = "";
         edtavWizarddata_infogeneral_promoarte_Filetype = "";
         edtavWizarddata_infogeneral_promoarte_Enabled = 0;
         edtavWizarddata_infogeneral_distribuidorid_description_Jsonclick = "";
         edtavWizarddata_infogeneral_distribuidorid_description_Enabled = 0;
         edtavWizarddata_infogeneral_promobase_Enabled = 0;
         edtavWizarddata_infogeneral_finpromo_Jsonclick = "";
         edtavWizarddata_infogeneral_finpromo_Enabled = 0;
         edtavWizarddata_infogeneral_iniciopromo_Jsonclick = "";
         edtavWizarddata_infogeneral_iniciopromo_Enabled = 0;
         edtavWizarddata_infogeneral_promodescripcion_Jsonclick = "";
         edtavWizarddata_infogeneral_promodescripcion_Enabled = 0;
         edtavWizarddata_modelos_grid__precio_Enabled = -1;
         edtavWizarddata_modelos_grid__modeloid_Enabled = -1;
         edtavWizarddata_modelos_grid__modelodescripcion_Enabled = -1;
         cmbavWizarddata_segmentos_grid__segmento.Enabled = -1;
         edtavWizarddata_infogeneral_promoarte_Enabled = -1;
         edtavWizarddata_infogeneral_distribuidorid_description_Enabled = -1;
         edtavWizarddata_infogeneral_promobase_Enabled = -1;
         edtavWizarddata_infogeneral_finpromo_Enabled = -1;
         edtavWizarddata_infogeneral_iniciopromo_Enabled = -1;
         edtavWizarddata_infogeneral_promodescripcion_Enabled = -1;
         subModelos_grid_Rows = 0;
         subSegmentos_grid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"SEGMENTOS_GRID_nFirstRecordOnPage"},{"av":"SEGMENTOS_GRID_nEOF"},{"av":"AV13WizardData_Segmentos_Grid","fld":"vWIZARDDATA_SEGMENTOS_GRID","grid":70},{"av":"nGXsfl_70_idx","ctrl":"GRID","prop":"GridCurrRow","grid":70},{"av":"nRC_GXsfl_70","ctrl":"SEGMENTOS_GRID","prop":"GridRC","grid":70},{"av":"MODELOS_GRID_nFirstRecordOnPage"},{"av":"MODELOS_GRID_nEOF"},{"av":"AV12WizardData_Modelos_Grid","fld":"vWIZARDDATA_MODELOS_GRID","grid":87},{"av":"nGXsfl_87_idx","ctrl":"GRID","prop":"GridCurrRow","grid":87},{"av":"nRC_GXsfl_87","ctrl":"MODELOS_GRID","prop":"GridRC","grid":87},{"av":"subSegmentos_grid_Rows","ctrl":"SEGMENTOS_GRID","prop":"Rows"},{"av":"subModelos_grid_Rows","ctrl":"MODELOS_GRID","prop":"Rows"},{"av":"sPrefix"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]}""");
         setEventMetadata("MODELOS_GRID.LOAD","""{"handler":"E18273","iparms":[]}""");
         setEventMetadata("SEGMENTOS_GRID.LOAD","""{"handler":"E17272","iparms":[]}""");
         setEventMetadata("ENTER","""{"handler":"E11272","iparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV11WizardData","fld":"vWIZARDDATA"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E12272","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'WIZARDGOTO MODELOS'","""{"handler":"E13272","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"}]""");
         setEventMetadata("'WIZARDGOTO MODELOS'",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'WIZARDGOTO SEGMENTOS'","""{"handler":"E14272","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"}]""");
         setEventMetadata("'WIZARDGOTO SEGMENTOS'",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'WIZARDGOTO INFOGENERAL'","""{"handler":"E15272","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"}]""");
         setEventMetadata("'WIZARDGOTO INFOGENERAL'",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("SEGMENTOS_GRID_FIRSTPAGE","""{"handler":"subsegmentos_grid_firstpage","iparms":[{"av":"SEGMENTOS_GRID_nFirstRecordOnPage"},{"av":"SEGMENTOS_GRID_nEOF"},{"av":"AV13WizardData_Segmentos_Grid","fld":"vWIZARDDATA_SEGMENTOS_GRID","grid":70},{"av":"nGXsfl_70_idx","ctrl":"GRID","prop":"GridCurrRow","grid":70},{"av":"nRC_GXsfl_70","ctrl":"SEGMENTOS_GRID","prop":"GridRC","grid":70},{"av":"subSegmentos_grid_Rows","ctrl":"SEGMENTOS_GRID","prop":"Rows"},{"av":"subModelos_grid_Rows","ctrl":"MODELOS_GRID","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("SEGMENTOS_GRID_PREVPAGE","""{"handler":"subsegmentos_grid_previouspage","iparms":[{"av":"SEGMENTOS_GRID_nFirstRecordOnPage"},{"av":"SEGMENTOS_GRID_nEOF"},{"av":"AV13WizardData_Segmentos_Grid","fld":"vWIZARDDATA_SEGMENTOS_GRID","grid":70},{"av":"nGXsfl_70_idx","ctrl":"GRID","prop":"GridCurrRow","grid":70},{"av":"nRC_GXsfl_70","ctrl":"SEGMENTOS_GRID","prop":"GridRC","grid":70},{"av":"subSegmentos_grid_Rows","ctrl":"SEGMENTOS_GRID","prop":"Rows"},{"av":"subModelos_grid_Rows","ctrl":"MODELOS_GRID","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("SEGMENTOS_GRID_NEXTPAGE","""{"handler":"subsegmentos_grid_nextpage","iparms":[{"av":"SEGMENTOS_GRID_nFirstRecordOnPage"},{"av":"SEGMENTOS_GRID_nEOF"},{"av":"AV13WizardData_Segmentos_Grid","fld":"vWIZARDDATA_SEGMENTOS_GRID","grid":70},{"av":"nGXsfl_70_idx","ctrl":"GRID","prop":"GridCurrRow","grid":70},{"av":"nRC_GXsfl_70","ctrl":"SEGMENTOS_GRID","prop":"GridRC","grid":70},{"av":"subSegmentos_grid_Rows","ctrl":"SEGMENTOS_GRID","prop":"Rows"},{"av":"subModelos_grid_Rows","ctrl":"MODELOS_GRID","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("SEGMENTOS_GRID_LASTPAGE","""{"handler":"subsegmentos_grid_lastpage","iparms":[{"av":"SEGMENTOS_GRID_nFirstRecordOnPage"},{"av":"SEGMENTOS_GRID_nEOF"},{"av":"AV13WizardData_Segmentos_Grid","fld":"vWIZARDDATA_SEGMENTOS_GRID","grid":70},{"av":"nGXsfl_70_idx","ctrl":"GRID","prop":"GridCurrRow","grid":70},{"av":"nRC_GXsfl_70","ctrl":"SEGMENTOS_GRID","prop":"GridRC","grid":70},{"av":"subSegmentos_grid_Rows","ctrl":"SEGMENTOS_GRID","prop":"Rows"},{"av":"subModelos_grid_Rows","ctrl":"MODELOS_GRID","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("MODELOS_GRID_FIRSTPAGE","""{"handler":"submodelos_grid_firstpage","iparms":[{"av":"MODELOS_GRID_nFirstRecordOnPage"},{"av":"MODELOS_GRID_nEOF"},{"av":"AV12WizardData_Modelos_Grid","fld":"vWIZARDDATA_MODELOS_GRID","grid":87},{"av":"nGXsfl_87_idx","ctrl":"GRID","prop":"GridCurrRow","grid":87},{"av":"nRC_GXsfl_87","ctrl":"MODELOS_GRID","prop":"GridRC","grid":87},{"av":"subSegmentos_grid_Rows","ctrl":"SEGMENTOS_GRID","prop":"Rows"},{"av":"subModelos_grid_Rows","ctrl":"MODELOS_GRID","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("MODELOS_GRID_PREVPAGE","""{"handler":"submodelos_grid_previouspage","iparms":[{"av":"MODELOS_GRID_nFirstRecordOnPage"},{"av":"MODELOS_GRID_nEOF"},{"av":"AV12WizardData_Modelos_Grid","fld":"vWIZARDDATA_MODELOS_GRID","grid":87},{"av":"nGXsfl_87_idx","ctrl":"GRID","prop":"GridCurrRow","grid":87},{"av":"nRC_GXsfl_87","ctrl":"MODELOS_GRID","prop":"GridRC","grid":87},{"av":"subSegmentos_grid_Rows","ctrl":"SEGMENTOS_GRID","prop":"Rows"},{"av":"subModelos_grid_Rows","ctrl":"MODELOS_GRID","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("MODELOS_GRID_NEXTPAGE","""{"handler":"submodelos_grid_nextpage","iparms":[{"av":"MODELOS_GRID_nFirstRecordOnPage"},{"av":"MODELOS_GRID_nEOF"},{"av":"AV12WizardData_Modelos_Grid","fld":"vWIZARDDATA_MODELOS_GRID","grid":87},{"av":"nGXsfl_87_idx","ctrl":"GRID","prop":"GridCurrRow","grid":87},{"av":"nRC_GXsfl_87","ctrl":"MODELOS_GRID","prop":"GridRC","grid":87},{"av":"subSegmentos_grid_Rows","ctrl":"SEGMENTOS_GRID","prop":"Rows"},{"av":"subModelos_grid_Rows","ctrl":"MODELOS_GRID","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("MODELOS_GRID_LASTPAGE","""{"handler":"submodelos_grid_lastpage","iparms":[{"av":"MODELOS_GRID_nFirstRecordOnPage"},{"av":"MODELOS_GRID_nEOF"},{"av":"AV12WizardData_Modelos_Grid","fld":"vWIZARDDATA_MODELOS_GRID","grid":87},{"av":"nGXsfl_87_idx","ctrl":"GRID","prop":"GridCurrRow","grid":87},{"av":"nRC_GXsfl_87","ctrl":"MODELOS_GRID","prop":"GridRC","grid":87},{"av":"subSegmentos_grid_Rows","ctrl":"SEGMENTOS_GRID","prop":"Rows"},{"av":"subModelos_grid_Rows","ctrl":"MODELOS_GRID","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("VALIDV_GXV8","""{"handler":"Validv_Gxv8","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv12","iparms":[]}""");
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
         wcpOAV6WebSessionKey = "";
         wcpOAV8PreviousStep = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV11WizardData = new SdtWPWizardPromoData(context);
         AV13WizardData_Segmentos_Grid = new GXBaseCollection<SdtWPWizardPromoData_Segmentos_GridItem>( context, "WPWizardPromoData.Segmentos.GridItem", "");
         AV12WizardData_Modelos_Grid = new GXBaseCollection<SdtWPWizardPromoData_Modelos_GridItem>( context, "WPWizardPromoData.Modelos.GridItem", "");
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         lblInfogeneral_summarytitle_Jsonclick = "";
         TempTags = "";
         bttBtnwizardgotoinfogeneral_Jsonclick = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         lblSegmentos_summarytitle_Jsonclick = "";
         bttBtnwizardgotosegmentos_Jsonclick = "";
         Segmentos_gridContainer = new GXWebGrid( context);
         sStyleString = "";
         lblModelos_summarytitle_Jsonclick = "";
         bttBtnwizardgotomodelos_Jsonclick = "";
         Modelos_gridContainer = new GXWebGrid( context);
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardlastnext = new GXUserControl();
         ucModelos_grid_empowerer = new GXUserControl();
         ucSegmentos_grid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         Modelos_grid_empowerer_Gridinternalname = "";
         Segmentos_grid_empowerer_Gridinternalname = "";
         Segmentos_gridRow = new GXWebRow();
         AV5WebSession = context.GetSession();
         AV14PromocionArte = "";
         AV15Resultado = "";
         Modelos_gridRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         subSegmentos_grid_Linesclass = "";
         GXCCtl = "";
         subModelos_grid_Linesclass = "";
         ROClassString = "";
         Segmentos_gridColumn = new GXWebColumn();
         Modelos_gridColumn = new GXWebColumn();
         /* GeneXus formulas. */
         edtavWizarddata_infogeneral_promodescripcion_Enabled = 0;
         edtavWizarddata_infogeneral_iniciopromo_Enabled = 0;
         edtavWizarddata_infogeneral_finpromo_Enabled = 0;
         edtavWizarddata_infogeneral_promobase_Enabled = 0;
         edtavWizarddata_infogeneral_distribuidorid_description_Enabled = 0;
         edtavWizarddata_infogeneral_promoarte_Enabled = 0;
         cmbavWizarddata_segmentos_grid__segmento.Enabled = 0;
         edtavWizarddata_modelos_grid__modelodescripcion_Enabled = 0;
         edtavWizarddata_modelos_grid__modeloid_Enabled = 0;
         edtavWizarddata_modelos_grid__precio_Enabled = 0;
      }

      private short SEGMENTOS_GRID_nEOF ;
      private short MODELOS_GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subSegmentos_grid_Backcolorstyle ;
      private short subModelos_grid_Backcolorstyle ;
      private short gxcookieaux ;
      private short AV16CodigoError ;
      private short nGXWrapped ;
      private short subSegmentos_grid_Backstyle ;
      private short subModelos_grid_Backstyle ;
      private short subSegmentos_grid_Titlebackstyle ;
      private short subSegmentos_grid_Allowselection ;
      private short subSegmentos_grid_Allowhovering ;
      private short subSegmentos_grid_Allowcollapsing ;
      private short subSegmentos_grid_Collapsed ;
      private short subModelos_grid_Titlebackstyle ;
      private short subModelos_grid_Allowselection ;
      private short subModelos_grid_Allowhovering ;
      private short subModelos_grid_Allowcollapsing ;
      private short subModelos_grid_Collapsed ;
      private int nRC_GXsfl_70 ;
      private int nRC_GXsfl_87 ;
      private int subSegmentos_grid_Rows ;
      private int subModelos_grid_Rows ;
      private int nGXsfl_70_idx=1 ;
      private int nGXsfl_87_idx=1 ;
      private int edtavWizarddata_infogeneral_promodescripcion_Enabled ;
      private int edtavWizarddata_infogeneral_iniciopromo_Enabled ;
      private int edtavWizarddata_infogeneral_finpromo_Enabled ;
      private int edtavWizarddata_infogeneral_promobase_Enabled ;
      private int edtavWizarddata_infogeneral_distribuidorid_description_Enabled ;
      private int edtavWizarddata_infogeneral_promoarte_Enabled ;
      private int edtavWizarddata_modelos_grid__modelodescripcion_Enabled ;
      private int edtavWizarddata_modelos_grid__modeloid_Enabled ;
      private int edtavWizarddata_modelos_grid__precio_Enabled ;
      private int AV24GXV7 ;
      private int AV26GXV9 ;
      private int subSegmentos_grid_Islastpage ;
      private int subModelos_grid_Islastpage ;
      private int SEGMENTOS_GRID_nGridOutOfScope ;
      private int MODELOS_GRID_nGridOutOfScope ;
      private int nGXsfl_70_fel_idx=1 ;
      private int nGXsfl_87_fel_idx=1 ;
      private int idxLst ;
      private int subSegmentos_grid_Backcolor ;
      private int subSegmentos_grid_Allbackcolor ;
      private int subModelos_grid_Backcolor ;
      private int subModelos_grid_Allbackcolor ;
      private int subSegmentos_grid_Titlebackcolor ;
      private int subSegmentos_grid_Selectedindex ;
      private int subSegmentos_grid_Selectioncolor ;
      private int subSegmentos_grid_Hoveringcolor ;
      private int subModelos_grid_Titlebackcolor ;
      private int subModelos_grid_Selectedindex ;
      private int subModelos_grid_Selectioncolor ;
      private int subModelos_grid_Hoveringcolor ;
      private long SEGMENTOS_GRID_nFirstRecordOnPage ;
      private long MODELOS_GRID_nFirstRecordOnPage ;
      private long SEGMENTOS_GRID_nCurrentRecord ;
      private long MODELOS_GRID_nCurrentRecord ;
      private long SEGMENTOS_GRID_nRecordCount ;
      private long MODELOS_GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_70_idx="0001" ;
      private string sGXsfl_87_idx="0001" ;
      private string edtavWizarddata_infogeneral_promodescripcion_Internalname ;
      private string edtavWizarddata_infogeneral_iniciopromo_Internalname ;
      private string edtavWizarddata_infogeneral_finpromo_Internalname ;
      private string edtavWizarddata_infogeneral_promobase_Internalname ;
      private string edtavWizarddata_infogeneral_distribuidorid_description_Internalname ;
      private string edtavWizarddata_infogeneral_promoarte_Internalname ;
      private string cmbavWizarddata_segmentos_grid__segmento_Internalname ;
      private string edtavWizarddata_modelos_grid__modelodescripcion_Internalname ;
      private string edtavWizarddata_modelos_grid__modeloid_Internalname ;
      private string edtavWizarddata_modelos_grid__precio_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divInfogeneral_summarytable_Internalname ;
      private string divInfogeneral_summaryheadertable_Internalname ;
      private string lblInfogeneral_summarytitle_Internalname ;
      private string lblInfogeneral_summarytitle_Jsonclick ;
      private string TempTags ;
      private string bttBtnwizardgotoinfogeneral_Internalname ;
      private string bttBtnwizardgotoinfogeneral_Jsonclick ;
      private string divInfogeneral_tableattributes_Internalname ;
      private string edtavWizarddata_infogeneral_promodescripcion_Jsonclick ;
      private string divInfogeneral_unnamedtable1_Internalname ;
      private string edtavWizarddata_infogeneral_iniciopromo_Jsonclick ;
      private string edtavWizarddata_infogeneral_finpromo_Jsonclick ;
      private string edtavWizarddata_infogeneral_distribuidorid_description_Jsonclick ;
      private string edtavWizarddata_infogeneral_promoarte_Filetype ;
      private string edtavWizarddata_infogeneral_promoarte_Contenttype ;
      private string edtavWizarddata_infogeneral_promoarte_Parameters ;
      private string edtavWizarddata_infogeneral_promoarte_Jsonclick ;
      private string divSegmentos_summarytable_Internalname ;
      private string divSegmentos_summaryheadertable_Internalname ;
      private string lblSegmentos_summarytitle_Internalname ;
      private string lblSegmentos_summarytitle_Jsonclick ;
      private string bttBtnwizardgotosegmentos_Internalname ;
      private string bttBtnwizardgotosegmentos_Jsonclick ;
      private string divSegmentos_tablegrid_Internalname ;
      private string sStyleString ;
      private string subSegmentos_grid_Internalname ;
      private string divModelos_summarytable_Internalname ;
      private string divModelos_summaryheadertable_Internalname ;
      private string lblModelos_summarytitle_Internalname ;
      private string lblModelos_summarytitle_Jsonclick ;
      private string bttBtnwizardgotomodelos_Internalname ;
      private string bttBtnwizardgotomodelos_Jsonclick ;
      private string divModelos_tablegrid_Internalname ;
      private string subModelos_grid_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardprevious_Tooltiptext ;
      private string Btnwizardprevious_Beforeiconclass ;
      private string Btnwizardprevious_Caption ;
      private string Btnwizardprevious_Class ;
      private string Btnwizardprevious_Internalname ;
      private string Btnwizardlastnext_Tooltiptext ;
      private string Btnwizardlastnext_Aftericonclass ;
      private string Btnwizardlastnext_Caption ;
      private string Btnwizardlastnext_Class ;
      private string Btnwizardlastnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Modelos_grid_empowerer_Internalname ;
      private string Segmentos_grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sGXsfl_70_fel_idx="0001" ;
      private string sGXsfl_87_fel_idx="0001" ;
      private string Modelos_grid_empowerer_Gridinternalname ;
      private string Segmentos_grid_empowerer_Gridinternalname ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private string subSegmentos_grid_Class ;
      private string subSegmentos_grid_Linesclass ;
      private string GXCCtl ;
      private string cmbavWizarddata_segmentos_grid__segmento_Jsonclick ;
      private string subModelos_grid_Class ;
      private string subModelos_grid_Linesclass ;
      private string ROClassString ;
      private string edtavWizarddata_modelos_grid__modelodescripcion_Jsonclick ;
      private string edtavWizarddata_modelos_grid__modeloid_Jsonclick ;
      private string edtavWizarddata_modelos_grid__precio_Jsonclick ;
      private string subSegmentos_grid_Header ;
      private string subModelos_grid_Header ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool bGXsfl_70_Refreshing=false ;
      private bool bGXsfl_87_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV17Pasa ;
      private bool gx_BV87 ;
      private bool gx_BV70 ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV15Resultado ;
      private string AV14PromocionArte ;
      private GxFile gxblobfileaux ;
      private GXWebGrid Segmentos_gridContainer ;
      private GXWebGrid Modelos_gridContainer ;
      private GXWebRow Segmentos_gridRow ;
      private GXWebRow Modelos_gridRow ;
      private GXWebColumn Segmentos_gridColumn ;
      private GXWebColumn Modelos_gridColumn ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardlastnext ;
      private GXUserControl ucModelos_grid_empowerer ;
      private GXUserControl ucSegmentos_grid_empowerer ;
      private GXWebForm Form ;
      private IGxSession AV5WebSession ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavWizarddata_segmentos_grid__segmento ;
      private SdtWPWizardPromoData AV11WizardData ;
      private GXBaseCollection<SdtWPWizardPromoData_Segmentos_GridItem> AV13WizardData_Segmentos_Grid ;
      private GXBaseCollection<SdtWPWizardPromoData_Modelos_GridItem> AV12WizardData_Modelos_Grid ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
