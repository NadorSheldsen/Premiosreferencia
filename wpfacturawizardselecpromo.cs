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
   public class wpfacturawizardselecpromo : GXWebComponent
   {
      public wpfacturawizardselecpromo( )
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

      public wpfacturawizardselecpromo( IGxContext context )
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
            PA2U2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               Gx_date = DateTimeUtil.Today( context);
               AssignAttri(sPrefix, false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
               edtavPromocionvigencia_Enabled = 0;
               AssignProp(sPrefix, false, edtavPromocionvigencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPromocionvigencia_Enabled), 5, 0), true);
               edtavPromocionbase_Enabled = 0;
               AssignProp(sPrefix, false, edtavPromocionbase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPromocionbase_Enabled), 5, 0), true);
               WS2U2( ) ;
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
            context.SendWebValue( context.GetMessage( "WPFactura Wizard Selec Promo", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GXEncryptionTmp = "wpfacturawizardselecpromo.aspx"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpfacturawizardselecpromo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDTUSUARIO", AV65SDTUsuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDTUSUARIO", AV65SDTUsuario);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDTUSUARIO", GetSecureSignedToken( sPrefix, AV65SDTUsuario, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV23DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV23DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPROMOCIONID_DATA", AV18PromocionID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPROMOCIONID_DATA", AV18PromocionID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILES", AV35UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILES", AV35UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFAILEDFILES", AV36FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFAILEDFILES", AV36FailedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMODELOID_DATA", AV79ModeloID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMODELOID_DATA", AV79ModeloID_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV21CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMODELOID", AV30ModeloID);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMODELOID", AV30ModeloID);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROMOCIONFECHAINICIO", context.localUtil.DToC( AV45PromocionFechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROMOCIONFECHAFIN", context.localUtil.DToC( AV43PromocionFechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDTUSUARIO", AV65SDTUsuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDTUSUARIO", AV65SDTUsuario);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDTUSUARIO", GetSecureSignedToken( sPrefix, AV65SDTUsuario, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROMOCIONARTE", AV15PromocionArte);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROMOCIONARTE_GXI", AV93Promocionarte_GXI);
         GxWebStd.gx_hidden_field( context, sPrefix+"PROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROMOCIONARTE", A44PromocionArte);
         GxWebStd.gx_hidden_field( context, sPrefix+"PROMOCIONARTE_GXI", A40000PromocionArte_GXI);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"PROMOCIONBASE", A43PromocionBase);
         GxWebStd.gx_hidden_field( context, sPrefix+"PROMOCIONVIGENCIA", A70PromocionVigencia);
         GxWebStd.gx_hidden_field( context, sPrefix+"PROMOCIONFECHAINICIO", context.localUtil.DToC( A45PromocionFechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROMOCIONFECHAFIN", context.localUtil.DToC( A46PromocionFechaFin, 0, "/"));
         GXCCtlgxBlob = "vFACTURAPDF" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtlgxBlob, AV80FacturaPDF);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PROMOCIONID_Ddointernalname", StringUtil.RTrim( Combo_promocionid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MODELOID_Ddointernalname", StringUtil.RTrim( Combo_modeloid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFACTURAPDF_Filename", StringUtil.RTrim( edtavFacturapdf_Filename));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PROMOCIONID_Selectedtext_get", StringUtil.RTrim( Combo_promocionid_Selectedtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MODELOID_Selectedtext_get", StringUtil.RTrim( Combo_modeloid_Selectedtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MODELOID_Selectedvalue_get", StringUtil.RTrim( Combo_modeloid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PROMOCIONID_Selectedvalue_get", StringUtil.RTrim( Combo_promocionid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PROMOCIONID_Ddointernalname", StringUtil.RTrim( Combo_promocionid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MODELOID_Ddointernalname", StringUtil.RTrim( Combo_modeloid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFACTURAPDF_Filename", StringUtil.RTrim( edtavFacturapdf_Filename));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PROMOCIONID_Selectedtext_get", StringUtil.RTrim( Combo_promocionid_Selectedtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MODELOID_Selectedtext_get", StringUtil.RTrim( Combo_modeloid_Selectedtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PROMOCIONID_Selectedvalue_get", StringUtil.RTrim( Combo_promocionid_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm2U2( )
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
         return "WPFacturaWizardSelecPromo" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WPFactura Wizard Selec Promo", "") ;
      }

      protected void WB2U0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpfacturawizardselecpromo.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto auto auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 100, "%", 0, "px", "CellMarginTop10", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
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
            ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, sPrefix+"DVPANEL_TABLEATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedpromocionid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_promocionid_Internalname, context.GetMessage( "Promoción", ""), "", "", lblTextblockcombo_promocionid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPFacturaWizardSelecPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_promocionid.SetProperty("Caption", Combo_promocionid_Caption);
            ucCombo_promocionid.SetProperty("Cls", Combo_promocionid_Cls);
            ucCombo_promocionid.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
            ucCombo_promocionid.SetProperty("DropDownOptionsData", AV18PromocionID_Data);
            ucCombo_promocionid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_promocionid_Internalname, sPrefix+"COMBO_PROMOCIONIDContainer");
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
            GxWebStd.gx_div_start( context, divTableinfopromo_Internalname, divTableinfopromo_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPromocionvigencia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPromocionvigencia_Internalname, context.GetMessage( "Vigencia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPromocionvigencia_Internalname, AV13PromocionVigencia, StringUtil.RTrim( context.localUtil.Format( AV13PromocionVigencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPromocionvigencia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPromocionvigencia_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPFacturaWizardSelecPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPromocionbase_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPromocionbase_Internalname, context.GetMessage( "Bases", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavPromocionbase_Internalname, AV14PromocionBase, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", 0, 1, edtavPromocionbase_Enabled, 0, 80, "chr", 9, "row", 0, StyleString, ClassString, "", "", "700", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WPFacturaWizardSelecPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "", context.GetMessage( "Ver arte", ""), bttBtnuseraction1_Jsonclick, 5, context.GetMessage( "Ver arte", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUSERACTION1\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPFacturaWizardSelecPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFacturano_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFacturano_Internalname, context.GetMessage( "No. Factura", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFacturano_Internalname, StringUtil.RTrim( AV16FacturaNo), StringUtil.RTrim( context.localUtil.Format( AV16FacturaNo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFacturano_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFacturano_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPFacturaWizardSelecPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFacturafechafactura_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFacturafechafactura_Internalname, context.GetMessage( "Fecha", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFacturafechafactura_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFacturafechafactura_Internalname, context.localUtil.Format(AV44FacturaFechaFactura, "99/99/99"), context.localUtil.Format( AV44FacturaFechaFactura, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,48);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFacturafechafactura_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFacturafechafactura_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPFacturaWizardSelecPromo.htm");
            GxWebStd.gx_bitmap( context, edtavFacturafechafactura_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFacturafechafactura_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPFacturaWizardSelecPromo.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUsercontrol1.SetProperty("AutoUpload", Usercontrol1_Autoupload);
            ucUsercontrol1.SetProperty("HideAdditionalButtons", Usercontrol1_Hideadditionalbuttons);
            ucUsercontrol1.SetProperty("TooltipText", Usercontrol1_Tooltiptext);
            ucUsercontrol1.SetProperty("EnableUploadedFileCanceling", Usercontrol1_Enableuploadedfilecanceling);
            ucUsercontrol1.SetProperty("MaxNumberOfFiles", Usercontrol1_Maxnumberoffiles);
            ucUsercontrol1.SetProperty("AutoDisableAddingFiles", Usercontrol1_Autodisableaddingfiles);
            ucUsercontrol1.SetProperty("AcceptedFileTypes", Usercontrol1_Acceptedfiletypes);
            ucUsercontrol1.SetProperty("CustomFileTypes", Usercontrol1_Customfiletypes);
            ucUsercontrol1.SetProperty("UploadedFiles", AV35UploadedFiles);
            ucUsercontrol1.SetProperty("FailedFiles", AV36FailedFiles);
            ucUsercontrol1.Render(context, "fileupload", Usercontrol1_Internalname, sPrefix+"USERCONTROL1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedmodeloid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_modeloid_Internalname, context.GetMessage( "Modelos", ""), "", "", lblTextblockcombo_modeloid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPFacturaWizardSelecPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_modeloid.SetProperty("Caption", Combo_modeloid_Caption);
            ucCombo_modeloid.SetProperty("Cls", Combo_modeloid_Cls);
            ucCombo_modeloid.SetProperty("AllowMultipleSelection", Combo_modeloid_Allowmultipleselection);
            ucCombo_modeloid.SetProperty("DataListProc", Combo_modeloid_Datalistproc);
            ucCombo_modeloid.SetProperty("IncludeOnlySelectedOption", Combo_modeloid_Includeonlyselectedoption);
            ucCombo_modeloid.SetProperty("MultipleValuesType", Combo_modeloid_Multiplevaluestype);
            ucCombo_modeloid.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
            ucCombo_modeloid.SetProperty("DropDownOptionsData", AV79ModeloID_Data);
            ucCombo_modeloid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_modeloid_Internalname, sPrefix+"COMBO_MODELOIDContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFacturapdf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFacturapdf_Internalname, context.GetMessage( "Factura", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            ClassString = "AttributeFL";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            edtavFacturapdf_Filetype = "tmp";
            AssignProp(sPrefix, false, edtavFacturapdf_Internalname, "Filetype", edtavFacturapdf_Filetype, true);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80FacturaPDF)) )
            {
               gxblobfileaux.Source = AV80FacturaPDF;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavFacturapdf_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavFacturapdf_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV80FacturaPDF = gxblobfileaux.GetURI();
                  AssignProp(sPrefix, false, edtavFacturapdf_Internalname, "URL", context.PathToRelativeUrl( AV80FacturaPDF), true);
                  edtavFacturapdf_Filetype = gxblobfileaux.GetExtension();
                  AssignProp(sPrefix, false, edtavFacturapdf_Internalname, "Filetype", edtavFacturapdf_Filetype, true);
               }
               AssignProp(sPrefix, false, edtavFacturapdf_Internalname, "URL", context.PathToRelativeUrl( AV80FacturaPDF), true);
            }
            GxWebStd.gx_blob_field( context, edtavFacturapdf_Internalname, StringUtil.RTrim( AV80FacturaPDF), context.PathToRelativeUrl( AV80FacturaPDF), (String.IsNullOrEmpty(StringUtil.RTrim( edtavFacturapdf_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavFacturapdf_Filetype)) ? AV80FacturaPDF : edtavFacturapdf_Filetype)) : edtavFacturapdf_Contenttype), false, "", edtavFacturapdf_Parameters, 0, edtavFacturapdf_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtavFacturapdf_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", "", "HLP_WPFacturaWizardSelecPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellWizardActions", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardfirstprevious.SetProperty("TooltipText", Btnwizardfirstprevious_Tooltiptext);
            ucBtnwizardfirstprevious.SetProperty("BeforeIconClass", Btnwizardfirstprevious_Beforeiconclass);
            ucBtnwizardfirstprevious.SetProperty("Caption", Btnwizardfirstprevious_Caption);
            ucBtnwizardfirstprevious.SetProperty("Class", Btnwizardfirstprevious_Class);
            ucBtnwizardfirstprevious.Render(context, "wwp_iconbutton", Btnwizardfirstprevious_Internalname, sPrefix+"BTNWIZARDFIRSTPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardnext.SetProperty("TooltipText", Btnwizardnext_Tooltiptext);
            ucBtnwizardnext.SetProperty("AfterIconClass", Btnwizardnext_Aftericonclass);
            ucBtnwizardnext.SetProperty("Caption", Btnwizardnext_Caption);
            ucBtnwizardnext.SetProperty("Class", Btnwizardnext_Class);
            ucBtnwizardnext.Render(context, "wwp_iconbutton", Btnwizardnext_Internalname, sPrefix+"BTNWIZARDNEXTContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPromocionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12PromocionID), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPromocionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavPromocionid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPFacturaWizardSelecPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2U2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WPFactura Wizard Selec Promo", ""), 0) ;
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
               STRUP2U0( ) ;
            }
         }
      }

      protected void WS2U2( )
      {
         START2U2( ) ;
         EVT2U2( ) ;
      }

      protected void EVT2U2( )
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
                                 STRUP2U0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_PROMOCIONID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_promocionid.Onoptionclicked */
                                    E112U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E122U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E132U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2U0( ) ;
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
                                          E142U2 ();
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
                                 STRUP2U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E152U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUserAction1' */
                                    E162U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFACTURAPDF.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E172U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E182U2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavPromocionvigencia_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
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

      protected void WE2U2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2U2( ) ;
            }
         }
      }

      protected void PA2U2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpfacturawizardselecpromo.aspx")), "wpfacturawizardselecpromo.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpfacturawizardselecpromo.aspx")))) ;
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
               GX_FocusControl = edtavPromocionvigencia_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         RF2U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri(sPrefix, false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         edtavPromocionvigencia_Enabled = 0;
         AssignProp(sPrefix, false, edtavPromocionvigencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPromocionvigencia_Enabled), 5, 0), true);
         edtavPromocionbase_Enabled = 0;
         AssignProp(sPrefix, false, edtavPromocionbase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPromocionbase_Enabled), 5, 0), true);
      }

      protected void RF2U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E132U2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E182U2 ();
            WB2U0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2U2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDTUSUARIO", AV65SDTUsuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDTUSUARIO", AV65SDTUsuario);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDTUSUARIO", GetSecureSignedToken( sPrefix, AV65SDTUsuario, context));
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri(sPrefix, false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         edtavPromocionvigencia_Enabled = 0;
         AssignProp(sPrefix, false, edtavPromocionvigencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPromocionvigencia_Enabled), 5, 0), true);
         edtavPromocionbase_Enabled = 0;
         AssignProp(sPrefix, false, edtavPromocionbase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPromocionbase_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122U2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV23DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vPROMOCIONID_DATA"), AV18PromocionID_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILES"), AV35UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFAILEDFILES"), AV36FailedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMODELOID_DATA"), AV79ModeloID_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMODELOID"), AV30ModeloID);
            /* Read saved values. */
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            Combo_promocionid_Ddointernalname = cgiGet( sPrefix+"COMBO_PROMOCIONID_Ddointernalname");
            Combo_modeloid_Ddointernalname = cgiGet( sPrefix+"COMBO_MODELOID_Ddointernalname");
            edtavFacturapdf_Filename = cgiGet( sPrefix+"vFACTURAPDF_Filename");
            Combo_promocionid_Selectedtext_get = cgiGet( sPrefix+"COMBO_PROMOCIONID_Selectedtext_get");
            Combo_modeloid_Selectedtext_get = cgiGet( sPrefix+"COMBO_MODELOID_Selectedtext_get");
            Combo_promocionid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_PROMOCIONID_Selectedvalue_get");
            /* Read variables values. */
            AV13PromocionVigencia = cgiGet( edtavPromocionvigencia_Internalname);
            AssignAttri(sPrefix, false, "AV13PromocionVigencia", AV13PromocionVigencia);
            AV14PromocionBase = cgiGet( edtavPromocionbase_Internalname);
            AssignAttri(sPrefix, false, "AV14PromocionBase", AV14PromocionBase);
            AV16FacturaNo = cgiGet( edtavFacturano_Internalname);
            AssignAttri(sPrefix, false, "AV16FacturaNo", AV16FacturaNo);
            if ( context.localUtil.VCDate( cgiGet( edtavFacturafechafactura_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Factura Fecha Factura", "")}), 1, "vFACTURAFECHAFACTURA");
               GX_FocusControl = edtavFacturafechafactura_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV44FacturaFechaFactura = DateTime.MinValue;
               AssignAttri(sPrefix, false, "AV44FacturaFechaFactura", context.localUtil.Format(AV44FacturaFechaFactura, "99/99/99"));
            }
            else
            {
               AV44FacturaFechaFactura = context.localUtil.CToD( cgiGet( edtavFacturafechafactura_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV44FacturaFechaFactura", context.localUtil.Format(AV44FacturaFechaFactura, "99/99/99"));
            }
            AV80FacturaPDF = cgiGet( edtavFacturapdf_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPromocionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPromocionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROMOCIONID");
               GX_FocusControl = edtavPromocionid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12PromocionID = 0;
               AssignAttri(sPrefix, false, "AV12PromocionID", StringUtil.LTrimStr( (decimal)(AV12PromocionID), 9, 0));
            }
            else
            {
               AV12PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPromocionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV12PromocionID", StringUtil.LTrimStr( (decimal)(AV12PromocionID), 9, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80FacturaPDF)) )
            {
               GXCCtlgxBlob = "vFACTURAPDF" + "_gxBlob";
               AV80FacturaPDF = cgiGet( sPrefix+GXCCtlgxBlob);
            }
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
         E122U2 ();
         if (returnInSub) return;
      }

      protected void E122U2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV70UsuarioJSON = AV5WebSession.Get(context.GetMessage( "Usuario", ""));
         AV65SDTUsuario.FromJSonString(AV70UsuarioJSON, null);
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri(sPrefix, false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV23DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV23DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavPromocionid_Visible = 0;
         AssignProp(sPrefix, false, edtavPromocionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPromocionid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOPROMOCIONID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOMODELOID' */
         S132 ();
         if (returnInSub) return;
         if ( AV7GoingBack && ( StringUtil.StrCmp(AV8PreviousStep, "Resumen") == 0 ) )
         {
            Btnwizardnext_Caption = context.GetMessage( "WWP_WizardReturnToSummary", "");
            ucBtnwizardnext.SendProperty(context, sPrefix, false, Btnwizardnext_Internalname, "Caption", Btnwizardnext_Caption);
         }
         if ( AV7GoingBack )
         {
            AV12PromocionID = AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionid;
            AssignAttri(sPrefix, false, "AV12PromocionID", StringUtil.LTrimStr( (decimal)(AV12PromocionID), 9, 0));
         }
         else
         {
            AV83PromocionJSON = AV5WebSession.Get(context.GetMessage( "Promocion", ""));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83PromocionJSON)) )
            {
               AV84SDTPromocion.FromJSonString(AV83PromocionJSON, null);
               AV12PromocionID = AV84SDTPromocion.gxTpr_Promocionid;
               AssignAttri(sPrefix, false, "AV12PromocionID", StringUtil.LTrimStr( (decimal)(AV12PromocionID), 9, 0));
               AV5WebSession.Remove(context.GetMessage( "Promocion", ""));
            }
         }
         AV18PromocionID_Data.Clear();
         /* Execute user subroutine: 'LOADCOMBOPROMOCIONID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOMODELOID' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADPROMOCIONINFO' */
         S142 ();
         if (returnInSub) return;
      }

      protected void E132U2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E142U2 ();
         if (returnInSub) return;
      }

      protected void E142U2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV88ValidaWWP = false;
         if ( AV88ValidaWWP )
         {
            /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
            S162 ();
            if (returnInSub) return;
            if ( AV21CheckRequiredFieldsResult && ! AV10HasValidationErrors )
            {
               /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
               S172 ();
               if (returnInSub) return;
               if ( AV7GoingBack && ( StringUtil.StrCmp(AV8PreviousStep, "Resumen") == 0 ) )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                     {
                        gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                     }
                  }
                  GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                  GXEncryptionTmp = "wpfacturawizard.aspx"+UrlEncode(StringUtil.RTrim("SelecPromo")) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(false));
                  CallWebObject(formatLink("wpfacturawizard.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                     {
                        gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                     }
                  }
                  GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                  GXEncryptionTmp = "wpfacturawizard.aspx"+UrlEncode(StringUtil.RTrim("SelecPromo")) + "," + UrlEncode(StringUtil.RTrim("SelecMedidas")) + "," + UrlEncode(StringUtil.BoolToStr(false));
                  CallWebObject(formatLink("wpfacturawizard.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
                  context.wjLocDisableFrm = 1;
               }
            }
         }
         else
         {
            /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
            S162 ();
            if (returnInSub) return;
            if ( AV21CheckRequiredFieldsResult && ! AV10HasValidationErrors )
            {
               /* Execute user subroutine: 'GUARDARFACTURA' */
               S182 ();
               if (returnInSub) return;
               if ( AV21CheckRequiredFieldsResult )
               {
                  AV80FacturaPDF = "";
                  AssignProp(sPrefix, false, edtavFacturapdf_Internalname, "URL", context.PathToRelativeUrl( AV80FacturaPDF), true);
                  /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
                  S172 ();
                  if (returnInSub) return;
                  if ( AV7GoingBack && ( StringUtil.StrCmp(AV8PreviousStep, "Resumen") == 0 ) )
                  {
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                        {
                           gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                        }
                     }
                     GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                     GXEncryptionTmp = "wpfacturawizard.aspx"+UrlEncode(StringUtil.RTrim("SelecPromo")) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(false));
                     CallWebObject(formatLink("wpfacturawizard.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
                     context.wjLocDisableFrm = 1;
                  }
                  else
                  {
                     if ( StringUtil.Len( sPrefix) == 0 )
                     {
                        if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                        {
                           gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                        }
                     }
                     GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                     GXEncryptionTmp = "wpfacturawizard.aspx"+UrlEncode(StringUtil.RTrim("SelecPromo")) + "," + UrlEncode(StringUtil.RTrim("SelecMedidas")) + "," + UrlEncode(StringUtil.BoolToStr(false));
                     CallWebObject(formatLink("wpfacturawizard.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
                     context.wjLocDisableFrm = 1;
                  }
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E152U2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E162U2( )
      {
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV15PromocionArte)) && String.IsNullOrEmpty(StringUtil.RTrim( AV93Promocionarte_GXI)) ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpfotogrande.aspx"+UrlEncode(StringUtil.RTrim(AV15PromocionArte));
            context.PopUp(formatLink("wpfotogrande.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else
         {
            AV94GXLvl114 = 0;
            /* Using cursor H002U2 */
            pr_default.execute(0, new Object[] {AV12PromocionID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A41PromocionID = H002U2_A41PromocionID[0];
               A40000PromocionArte_GXI = H002U2_A40000PromocionArte_GXI[0];
               A44PromocionArte = H002U2_A44PromocionArte[0];
               AV94GXLvl114 = 1;
               AV15PromocionArte = A44PromocionArte;
               AssignAttri(sPrefix, false, "AV15PromocionArte", AV15PromocionArte);
               AV93Promocionarte_GXI = A40000PromocionArte_GXI;
               AssignAttri(sPrefix, false, "AV93Promocionarte_GXI", AV93Promocionarte_GXI);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( AV94GXLvl114 == 0 )
            {
               /* Using cursor H002U3 */
               pr_default.execute(1, new Object[] {AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionid});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A41PromocionID = H002U3_A41PromocionID[0];
                  A40000PromocionArte_GXI = H002U3_A40000PromocionArte_GXI[0];
                  A44PromocionArte = H002U3_A44PromocionArte[0];
                  AV15PromocionArte = A44PromocionArte;
                  AssignAttri(sPrefix, false, "AV15PromocionArte", AV15PromocionArte);
                  AV93Promocionarte_GXI = A40000PromocionArte_GXI;
                  AssignAttri(sPrefix, false, "AV93Promocionarte_GXI", AV93Promocionarte_GXI);
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                     {
                        gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                     }
                  }
                  GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                  GXEncryptionTmp = "wpfotogrande.aspx"+UrlEncode(StringUtil.RTrim(AV15PromocionArte));
                  context.PopUp(formatLink("wpfotogrande.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpfotogrande.aspx"+UrlEncode(StringUtil.RTrim(AV15PromocionArte));
            context.PopUp(formatLink("wpfotogrande.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         /*  Sending Event outputs  */
      }

      protected void E112U2( )
      {
         /* Combo_promocionid_Onoptionclicked Routine */
         returnInSub = false;
         AV27Cond_SelecPromo_PromocionID = AV12PromocionID;
         AssignAttri(sPrefix, false, "AV27Cond_SelecPromo_PromocionID", StringUtil.LTrimStr( (decimal)(AV27Cond_SelecPromo_PromocionID), 9, 0));
         AV12PromocionID = (int)(Math.Round(NumberUtil.Val( Combo_promocionid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri(sPrefix, false, "AV12PromocionID", StringUtil.LTrimStr( (decimal)(AV12PromocionID), 9, 0));
         if ( AV27Cond_SelecPromo_PromocionID != AV12PromocionID )
         {
            AV30ModeloID.Clear();
            Combo_modeloid_Selectedvalue_set = "";
            ucCombo_modeloid.SendProperty(context, sPrefix, false, Combo_modeloid_Internalname, "SelectedValue_set", Combo_modeloid_Selectedvalue_set);
            Combo_modeloid_Selectedtext_set = "";
            ucCombo_modeloid.SendProperty(context, sPrefix, false, Combo_modeloid_Internalname, "SelectedText_set", Combo_modeloid_Selectedtext_set);
         }
         /* Execute user subroutine: 'LOADPROMOCIONINFO' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30ModeloID", AV30ModeloID);
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV7GoingBack ) )
         {
            Btnwizardfirstprevious_Visible = false;
            ucBtnwizardfirstprevious.SendProperty(context, sPrefix, false, Btnwizardfirstprevious_Internalname, "Visible", StringUtil.BoolToStr( Btnwizardfirstprevious_Visible));
         }
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV12PromocionID = AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionid;
         AssignAttri(sPrefix, false, "AV12PromocionID", StringUtil.LTrimStr( (decimal)(AV12PromocionID), 9, 0));
         AV13PromocionVigencia = AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionvigencia;
         AssignAttri(sPrefix, false, "AV13PromocionVigencia", AV13PromocionVigencia);
         AV14PromocionBase = AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionbase;
         AssignAttri(sPrefix, false, "AV14PromocionBase", AV14PromocionBase);
         AV16FacturaNo = AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturano;
         AssignAttri(sPrefix, false, "AV16FacturaNo", AV16FacturaNo);
         AV44FacturaFechaFactura = AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturafechafactura;
         AssignAttri(sPrefix, false, "AV44FacturaFechaFactura", context.localUtil.Format(AV44FacturaFechaFactura, "99/99/99"));
         AV30ModeloID = AV11WizardData.gxTpr_Selecpromo.gxTpr_Modeloid;
         AV80FacturaPDF = AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturapdf;
         AssignProp(sPrefix, false, edtavFacturapdf_Internalname, "URL", context.PathToRelativeUrl( AV80FacturaPDF), true);
      }

      protected void S172( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionid_description = Combo_promocionid_Selectedtext_get;
         AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionid = AV12PromocionID;
         AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionvigencia = AV13PromocionVigencia;
         AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionbase = AV14PromocionBase;
         AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturano = AV16FacturaNo;
         AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturafechafactura = AV44FacturaFechaFactura;
         AV11WizardData.gxTpr_Selecpromo.gxTpr_Modeloid_description = "";
         AV28SelectedTextCol.FromJSonString(Combo_modeloid_Selectedtext_get, null);
         AV96GXV1 = 1;
         while ( AV96GXV1 <= AV28SelectedTextCol.Count )
         {
            AV34SelectedTextVal = ((string)AV28SelectedTextCol.Item(AV96GXV1));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11WizardData.gxTpr_Selecpromo.gxTpr_Modeloid_description)) )
            {
               AV11WizardData.gxTpr_Selecpromo.gxTpr_Modeloid_description = AV11WizardData.gxTpr_Selecpromo.gxTpr_Modeloid_description+", ";
            }
            AV11WizardData.gxTpr_Selecpromo.gxTpr_Modeloid_description = AV11WizardData.gxTpr_Selecpromo.gxTpr_Modeloid_description+AV34SelectedTextVal;
            AV96GXV1 = (int)(AV96GXV1+1);
         }
         AV11WizardData.gxTpr_Selecpromo.gxTpr_Modeloid = AV30ModeloID;
         AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturapdf = AV80FacturaPDF;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S162( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV21CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV21CheckRequiredFieldsResult", AV21CheckRequiredFieldsResult);
         if ( (0==AV12PromocionID) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Promoción", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_promocionid_Ddointernalname,  "true",  ""));
            AV21CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV21CheckRequiredFieldsResult", AV21CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FacturaNo)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "No. Factura", ""), "", "", "", "", "", "", "", ""),  "error",  edtavFacturano_Internalname,  "true",  ""));
            AV21CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV21CheckRequiredFieldsResult", AV21CheckRequiredFieldsResult);
         }
         if ( (DateTime.MinValue==AV44FacturaFechaFactura) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Fecha", ""), "", "", "", "", "", "", "", ""),  "error",  edtavFacturafechafactura_Internalname,  "true",  ""));
            AV21CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV21CheckRequiredFieldsResult", AV21CheckRequiredFieldsResult);
         }
         if ( AV30ModeloID.Count == 0 )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Modelos", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_modeloid_Ddointernalname,  "true",  ""));
            AV21CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV21CheckRequiredFieldsResult", AV21CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80FacturaPDF)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "La factura es requerida", ""),  "error",  edtavFacturapdf_Internalname,  "true",  ""));
            AV21CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV21CheckRequiredFieldsResult", AV21CheckRequiredFieldsResult);
         }
         if ( DateTimeUtil.ResetTime ( AV44FacturaFechaFactura ) < DateTimeUtil.ResetTime ( AV45PromocionFechaInicio ) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Error, la fecha de la factura no puede ser menor a la fecha de inicio de la promoción.", ""),  "error",  edtavFacturafechafactura_Internalname,  "true",  ""));
            AV21CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV21CheckRequiredFieldsResult", AV21CheckRequiredFieldsResult);
         }
         if ( DateTimeUtil.ResetTime ( AV44FacturaFechaFactura ) > DateTimeUtil.ResetTime ( AV43PromocionFechaFin ) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Error, la fecha de la factura no puede ser mayor a la fecha de fin de la promoción.", ""),  "error",  edtavFacturafechafactura_Internalname,  "true",  ""));
            AV21CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV21CheckRequiredFieldsResult", AV21CheckRequiredFieldsResult);
         }
         if ( AV21CheckRequiredFieldsResult )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80FacturaPDF)) )
            {
               GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "La factura es requerida", ""),  "error",  edtavFacturapdf_Internalname,  "true",  ""));
               AV21CheckRequiredFieldsResult = false;
               AssignAttri(sPrefix, false, "AV21CheckRequiredFieldsResult", AV21CheckRequiredFieldsResult);
            }
            else
            {
               AV81FacturaNombre = StringUtil.Lower( edtavFacturapdf_Filename);
               if ( ! StringUtil.EndsWith( AV81FacturaNombre, context.GetMessage( ".pdf", "")) )
               {
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Error, la factura debe ser un archivo .pdf", ""),  "error",  edtavFacturapdf_Internalname,  "true",  ""));
                  AV80FacturaPDF = "";
                  AssignProp(sPrefix, false, edtavFacturapdf_Internalname, "URL", context.PathToRelativeUrl( AV80FacturaPDF), true);
                  AV21CheckRequiredFieldsResult = false;
                  AssignAttri(sPrefix, false, "AV21CheckRequiredFieldsResult", AV21CheckRequiredFieldsResult);
               }
            }
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOMODELOID' Routine */
         returnInSub = false;
         Combo_modeloid_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"WPFacturaWizardSelecPromo_ModeloID\", \"Cond_SelecPromo_PromocionID\": \"#%1#\"", edtavPromocionid_Internalname, "", "", "", "", "", "", "", "");
         ucCombo_modeloid.SendProperty(context, sPrefix, false, Combo_modeloid_Internalname, "DataListProcParametersPrefix", Combo_modeloid_Datalistprocparametersprefix);
         AV27Cond_SelecPromo_PromocionID = AV12PromocionID;
         AssignAttri(sPrefix, false, "AV27Cond_SelecPromo_PromocionID", StringUtil.LTrimStr( (decimal)(AV27Cond_SelecPromo_PromocionID), 9, 0));
         AV28SelectedTextCol = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV97GXV2 = 1;
         while ( AV97GXV2 <= AV30ModeloID.Count )
         {
            AV32ModeloIDKey = (int)(AV30ModeloID.GetNumeric(AV97GXV2));
            AssignAttri(sPrefix, false, "AV32ModeloIDKey", StringUtil.LTrimStr( (decimal)(AV32ModeloIDKey), 9, 0));
            AV98GXLvl286 = 0;
            /* Using cursor H002U4 */
            pr_default.execute(2, new Object[] {AV27Cond_SelecPromo_PromocionID, AV32ModeloIDKey});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A41PromocionID = H002U4_A41PromocionID[0];
               A22ModeloID = H002U4_A22ModeloID[0];
               A23ModeloDescripcion = H002U4_A23ModeloDescripcion[0];
               A23ModeloDescripcion = H002U4_A23ModeloDescripcion[0];
               AV98GXLvl286 = 1;
               AV28SelectedTextCol.Add(A23ModeloDescripcion, 0);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( AV98GXLvl286 == 0 )
            {
               AV28SelectedTextCol.Add(StringUtil.Trim( StringUtil.Str( (decimal)(AV32ModeloIDKey), 9, 0)), 0);
            }
            AV97GXV2 = (int)(AV97GXV2+1);
         }
         Combo_modeloid_Selectedtext_set = AV28SelectedTextCol.ToJSonString(false);
         ucCombo_modeloid.SendProperty(context, sPrefix, false, Combo_modeloid_Internalname, "SelectedText_set", Combo_modeloid_Selectedtext_set);
         Combo_modeloid_Selectedvalue_set = AV30ModeloID.ToJSonString(false);
         ucCombo_modeloid.SendProperty(context, sPrefix, false, Combo_modeloid_Internalname, "SelectedValue_set", Combo_modeloid_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPROMOCIONID' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTADISTRIUBIDORES' */
         S192 ();
         if (returnInSub) return;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A10DistribuidorID ,
                                              AV58ListaDistribuidores ,
                                              A46PromocionFechaFin ,
                                              Gx_date } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor H002U5 */
         pr_default.execute(3, new Object[] {Gx_date});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A10DistribuidorID = H002U5_A10DistribuidorID[0];
            A46PromocionFechaFin = H002U5_A46PromocionFechaFin[0];
            A41PromocionID = H002U5_A41PromocionID[0];
            A42PromocionDescripcion = H002U5_A42PromocionDescripcion[0];
            A46PromocionFechaFin = H002U5_A46PromocionFechaFin[0];
            A42PromocionDescripcion = H002U5_A42PromocionDescripcion[0];
            AV20Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV20Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A41PromocionID), 9, 0));
            AV20Combo_DataItem.gxTpr_Title = A42PromocionDescripcion;
            AV18PromocionID_Data.Add(AV20Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_promocionid_Selectedvalue_set = ((0==AV12PromocionID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV12PromocionID), 9, 0)));
         ucCombo_promocionid.SendProperty(context, sPrefix, false, Combo_promocionid_Internalname, "SelectedValue_set", Combo_promocionid_Selectedvalue_set);
      }

      protected void E172U2( )
      {
         /* Facturapdf_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80FacturaPDF)) )
         {
            AV81FacturaNombre = StringUtil.Lower( edtavFacturapdf_Filename);
            if ( ! StringUtil.EndsWith( AV81FacturaNombre, context.GetMessage( ".pdf", "")) )
            {
               GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Error, la factura debe ser un archivo .pdf", ""),  "error",  edtavFacturapdf_Internalname,  "true",  ""));
               AV80FacturaPDF = "";
               AssignProp(sPrefix, false, edtavFacturapdf_Internalname, "URL", context.PathToRelativeUrl( AV80FacturaPDF), true);
            }
         }
         /*  Sending Event outputs  */
      }

      protected void S192( )
      {
         /* 'LOADLISTADISTRIUBIDORES' Routine */
         returnInSub = false;
         AV69UsuarioID = AV65SDTUsuario.gxTpr_Usuarioid;
         AssignAttri(sPrefix, false, "AV69UsuarioID", StringUtil.LTrimStr( (decimal)(AV69UsuarioID), 9, 0));
         AV58ListaDistribuidores.Clear();
         /* Using cursor H002U6 */
         pr_default.execute(4, new Object[] {AV69UsuarioID});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A29UsuarioID = H002U6_A29UsuarioID[0];
            A10DistribuidorID = H002U6_A10DistribuidorID[0];
            AV73YaExiste = false;
            AV101GXV3 = 1;
            while ( AV101GXV3 <= AV58ListaDistribuidores.Count )
            {
               AV52DistribuidorID = (int)(AV58ListaDistribuidores.GetNumeric(AV101GXV3));
               if ( AV52DistribuidorID == A10DistribuidorID )
               {
                  AV73YaExiste = true;
                  if (true) break;
               }
               AV101GXV3 = (int)(AV101GXV3+1);
            }
            if ( ! AV73YaExiste )
            {
               AV58ListaDistribuidores.Add(A10DistribuidorID, 0);
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S142( )
      {
         /* 'LOADPROMOCIONINFO' Routine */
         returnInSub = false;
         if ( (0==AV12PromocionID) )
         {
            divTableinfopromo_Visible = 0;
            AssignProp(sPrefix, false, divTableinfopromo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableinfopromo_Visible), 5, 0), true);
            AV14PromocionBase = "";
            AssignAttri(sPrefix, false, "AV14PromocionBase", AV14PromocionBase);
            AV13PromocionVigencia = "";
            AssignAttri(sPrefix, false, "AV13PromocionVigencia", AV13PromocionVigencia);
            AV15PromocionArte = "";
            AssignAttri(sPrefix, false, "AV15PromocionArte", AV15PromocionArte);
            AV93Promocionarte_GXI = "";
            AssignAttri(sPrefix, false, "AV93Promocionarte_GXI", AV93Promocionarte_GXI);
            AV45PromocionFechaInicio = DateTime.MinValue;
            AssignAttri(sPrefix, false, "AV45PromocionFechaInicio", context.localUtil.Format(AV45PromocionFechaInicio, "99/99/99"));
            AV43PromocionFechaFin = DateTime.MinValue;
            AssignAttri(sPrefix, false, "AV43PromocionFechaFin", context.localUtil.Format(AV43PromocionFechaFin, "99/99/99"));
         }
         else
         {
            /* Using cursor H002U7 */
            pr_default.execute(5, new Object[] {AV12PromocionID});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A41PromocionID = H002U7_A41PromocionID[0];
               A40000PromocionArte_GXI = H002U7_A40000PromocionArte_GXI[0];
               A43PromocionBase = H002U7_A43PromocionBase[0];
               A46PromocionFechaFin = H002U7_A46PromocionFechaFin[0];
               A45PromocionFechaInicio = H002U7_A45PromocionFechaInicio[0];
               A44PromocionArte = H002U7_A44PromocionArte[0];
               A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
               AssignAttri(sPrefix, false, "A70PromocionVigencia", A70PromocionVigencia);
               AV14PromocionBase = A43PromocionBase;
               AssignAttri(sPrefix, false, "AV14PromocionBase", AV14PromocionBase);
               AV13PromocionVigencia = A70PromocionVigencia;
               AssignAttri(sPrefix, false, "AV13PromocionVigencia", AV13PromocionVigencia);
               AV15PromocionArte = A44PromocionArte;
               AssignAttri(sPrefix, false, "AV15PromocionArte", AV15PromocionArte);
               AV93Promocionarte_GXI = A40000PromocionArte_GXI;
               AssignAttri(sPrefix, false, "AV93Promocionarte_GXI", AV93Promocionarte_GXI);
               AV45PromocionFechaInicio = A45PromocionFechaInicio;
               AssignAttri(sPrefix, false, "AV45PromocionFechaInicio", context.localUtil.Format(AV45PromocionFechaInicio, "99/99/99"));
               AV43PromocionFechaFin = A46PromocionFechaFin;
               AssignAttri(sPrefix, false, "AV43PromocionFechaFin", context.localUtil.Format(AV43PromocionFechaFin, "99/99/99"));
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(5);
            divTableinfopromo_Visible = 1;
            AssignProp(sPrefix, false, divTableinfopromo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableinfopromo_Visible), 5, 0), true);
         }
      }

      protected void S182( )
      {
         /* 'GUARDARFACTURA' Routine */
         returnInSub = false;
         new guardarfacturatemporal(context ).execute(  AV16FacturaNo,  AV44FacturaFechaFactura,  AV12PromocionID,  AV65SDTUsuario.gxTpr_Usuarioid,  AV80FacturaPDF, out  AV89FacturaID, out  AV91Resultado, out  AV90ErrorCode) ;
         if ( AV90ErrorCode == 0 )
         {
            AV5WebSession.Set(context.GetMessage( "FacturaWizardID", ""), StringUtil.Trim( StringUtil.Str( (decimal)(AV89FacturaID), 9, 0)));
         }
         else
         {
            AV21CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV21CheckRequiredFieldsResult", AV21CheckRequiredFieldsResult);
            GX_msglist.addItem(StringUtil.Trim( AV91Resultado));
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E182U2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA2U2( ) ;
         WS2U2( ) ;
         WE2U2( ) ;
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
         PA2U2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpfacturawizardselecpromo", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2U2( ) ;
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
         PA2U2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2U2( ) ;
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
         WS2U2( ) ;
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
         WE2U2( ) ;
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
         AddStyleSheetFile("FileUpload/fileupload.min.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202651111305831", true, true);
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
         context.AddJavascriptSource("wpfacturawizardselecpromo.js", "?202651111305831", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockcombo_promocionid_Internalname = sPrefix+"TEXTBLOCKCOMBO_PROMOCIONID";
         Combo_promocionid_Internalname = sPrefix+"COMBO_PROMOCIONID";
         divTablesplittedpromocionid_Internalname = sPrefix+"TABLESPLITTEDPROMOCIONID";
         edtavPromocionvigencia_Internalname = sPrefix+"vPROMOCIONVIGENCIA";
         edtavPromocionbase_Internalname = sPrefix+"vPROMOCIONBASE";
         bttBtnuseraction1_Internalname = sPrefix+"BTNUSERACTION1";
         edtavFacturano_Internalname = sPrefix+"vFACTURANO";
         edtavFacturafechafactura_Internalname = sPrefix+"vFACTURAFECHAFACTURA";
         Usercontrol1_Internalname = sPrefix+"USERCONTROL1";
         lblTextblockcombo_modeloid_Internalname = sPrefix+"TEXTBLOCKCOMBO_MODELOID";
         Combo_modeloid_Internalname = sPrefix+"COMBO_MODELOID";
         divTablesplittedmodeloid_Internalname = sPrefix+"TABLESPLITTEDMODELOID";
         edtavFacturapdf_Internalname = sPrefix+"vFACTURAPDF";
         divTableinfopromo_Internalname = sPrefix+"TABLEINFOPROMO";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = sPrefix+"DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardfirstprevious_Internalname = sPrefix+"BTNWIZARDFIRSTPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavPromocionid_Internalname = sPrefix+"vPROMOCIONID";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
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
         Combo_modeloid_Datalistprocparametersprefix = "";
         Btnwizardfirstprevious_Visible = Convert.ToBoolean( -1);
         edtavPromocionid_Jsonclick = "";
         edtavPromocionid_Visible = 1;
         Btnwizardnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardnext_Caption = context.GetMessage( "GXM_next", "");
         Btnwizardnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardnext_Tooltiptext = "";
         Btnwizardfirstprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardfirstprevious_Caption = context.GetMessage( "GX_BtnCancel", "");
         Btnwizardfirstprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardfirstprevious_Tooltiptext = "";
         edtavFacturapdf_Jsonclick = "";
         edtavFacturapdf_Parameters = "";
         edtavFacturapdf_Contenttype = "";
         edtavFacturapdf_Filetype = "";
         edtavFacturapdf_Enabled = 1;
         Combo_modeloid_Multiplevaluestype = "Tags";
         Combo_modeloid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_modeloid_Datalistproc = "WPFacturaWizardLoadDVCombo";
         Combo_modeloid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_modeloid_Cls = "ExtendedCombo AttributeFL";
         Combo_modeloid_Caption = "";
         Usercontrol1_Customfiletypes = "pdf";
         Usercontrol1_Acceptedfiletypes = "custom";
         Usercontrol1_Autodisableaddingfiles = Convert.ToBoolean( -1);
         Usercontrol1_Maxnumberoffiles = 1;
         Usercontrol1_Enableuploadedfilecanceling = Convert.ToBoolean( -1);
         Usercontrol1_Tooltiptext = "";
         Usercontrol1_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Usercontrol1_Autoupload = Convert.ToBoolean( -1);
         edtavFacturafechafactura_Jsonclick = "";
         edtavFacturafechafactura_Enabled = 1;
         edtavFacturano_Jsonclick = "";
         edtavFacturano_Enabled = 1;
         edtavPromocionbase_Enabled = 1;
         edtavPromocionvigencia_Jsonclick = "";
         edtavPromocionvigencia_Enabled = 1;
         divTableinfopromo_Visible = 1;
         Combo_promocionid_Cls = "ExtendedCombo AttributeFL";
         Combo_promocionid_Caption = "";
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = context.GetMessage( "Capturar Datos", "");
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         edtavFacturapdf_Filename = "";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV7GoingBack","fld":"vGOINGBACK"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV65SDTUsuario","fld":"vSDTUSUARIO","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E142U2","iparms":[{"av":"AV21CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV7GoingBack","fld":"vGOINGBACK"},{"av":"AV8PreviousStep","fld":"vPREVIOUSSTEP"},{"av":"AV12PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"Combo_promocionid_Ddointernalname","ctrl":"COMBO_PROMOCIONID","prop":"DDOInternalName"},{"av":"AV16FacturaNo","fld":"vFACTURANO"},{"av":"AV44FacturaFechaFactura","fld":"vFACTURAFECHAFACTURA"},{"av":"AV30ModeloID","fld":"vMODELOID"},{"av":"Combo_modeloid_Ddointernalname","ctrl":"COMBO_MODELOID","prop":"DDOInternalName"},{"av":"AV80FacturaPDF","fld":"vFACTURAPDF"},{"av":"AV45PromocionFechaInicio","fld":"vPROMOCIONFECHAINICIO"},{"av":"AV43PromocionFechaFin","fld":"vPROMOCIONFECHAFIN"},{"av":"edtavFacturapdf_Filename","ctrl":"vFACTURAPDF","prop":"Filename"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"Combo_promocionid_Selectedtext_get","ctrl":"COMBO_PROMOCIONID","prop":"SelectedText_get"},{"av":"AV13PromocionVigencia","fld":"vPROMOCIONVIGENCIA"},{"av":"AV14PromocionBase","fld":"vPROMOCIONBASE"},{"av":"Combo_modeloid_Selectedtext_get","ctrl":"COMBO_MODELOID","prop":"SelectedText_get"},{"av":"AV65SDTUsuario","fld":"vSDTUSUARIO","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV80FacturaPDF","fld":"vFACTURAPDF"},{"av":"AV21CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV11WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E152U2","iparms":[]}""");
         setEventMetadata("'DOUSERACTION1'","""{"handler":"E162U2","iparms":[{"av":"AV15PromocionArte","fld":"vPROMOCIONARTE"},{"av":"AV93Promocionarte_GXI","fld":"vPROMOCIONARTE_GXI"},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV12PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A44PromocionArte","fld":"PROMOCIONARTE"},{"av":"A40000PromocionArte_GXI","fld":"PROMOCIONARTE_GXI"},{"av":"AV11WizardData","fld":"vWIZARDDATA"}]""");
         setEventMetadata("'DOUSERACTION1'",""","oparms":[{"av":"AV15PromocionArte","fld":"vPROMOCIONARTE"}]}""");
         setEventMetadata("COMBO_PROMOCIONID.ONOPTIONCLICKED","""{"handler":"E112U2","iparms":[{"av":"AV12PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"Combo_promocionid_Selectedvalue_get","ctrl":"COMBO_PROMOCIONID","prop":"SelectedValue_get"},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A43PromocionBase","fld":"PROMOCIONBASE"},{"av":"A70PromocionVigencia","fld":"PROMOCIONVIGENCIA"},{"av":"A44PromocionArte","fld":"PROMOCIONARTE"},{"av":"A40000PromocionArte_GXI","fld":"PROMOCIONARTE_GXI"},{"av":"A45PromocionFechaInicio","fld":"PROMOCIONFECHAINICIO"},{"av":"A46PromocionFechaFin","fld":"PROMOCIONFECHAFIN"}]""");
         setEventMetadata("COMBO_PROMOCIONID.ONOPTIONCLICKED",""","oparms":[{"av":"AV27Cond_SelecPromo_PromocionID","fld":"vCOND_SELECPROMO_PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV12PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV30ModeloID","fld":"vMODELOID"},{"av":"Combo_modeloid_Selectedvalue_set","ctrl":"COMBO_MODELOID","prop":"SelectedValue_set"},{"av":"Combo_modeloid_Selectedtext_set","ctrl":"COMBO_MODELOID","prop":"SelectedText_set"},{"av":"AV93Promocionarte_GXI","fld":"vPROMOCIONARTE_GXI"},{"av":"divTableinfopromo_Visible","ctrl":"TABLEINFOPROMO","prop":"Visible"},{"av":"AV14PromocionBase","fld":"vPROMOCIONBASE"},{"av":"AV13PromocionVigencia","fld":"vPROMOCIONVIGENCIA"},{"av":"AV15PromocionArte","fld":"vPROMOCIONARTE"},{"av":"AV45PromocionFechaInicio","fld":"vPROMOCIONFECHAINICIO"},{"av":"AV43PromocionFechaFin","fld":"vPROMOCIONFECHAFIN"}]}""");
         setEventMetadata("VFACTURAPDF.CONTROLVALUECHANGED","""{"handler":"E172U2","iparms":[{"av":"AV80FacturaPDF","fld":"vFACTURAPDF"},{"av":"edtavFacturapdf_Filename","ctrl":"vFACTURAPDF","prop":"Filename"}]""");
         setEventMetadata("VFACTURAPDF.CONTROLVALUECHANGED",""","oparms":[{"av":"AV80FacturaPDF","fld":"vFACTURAPDF"}]}""");
         setEventMetadata("VALIDV_FACTURAFECHAFACTURA","""{"handler":"Validv_Facturafechafactura","iparms":[]}""");
         setEventMetadata("VALIDV_PROMOCIONID","""{"handler":"Validv_Promocionid","iparms":[]}""");
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

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         wcpOAV6WebSessionKey = "";
         wcpOAV8PreviousStep = "";
         Combo_promocionid_Ddointernalname = "";
         Combo_modeloid_Ddointernalname = "";
         Combo_promocionid_Selectedtext_get = "";
         Combo_modeloid_Selectedtext_get = "";
         Combo_modeloid_Selectedvalue_get = "";
         Combo_promocionid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV65SDTUsuario = new SdtSDTUsuario(context);
         AV23DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV18PromocionID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV35UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Premios");
         AV36FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Premios");
         AV79ModeloID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV30ModeloID = new GxSimpleCollection<int>();
         AV45PromocionFechaInicio = DateTime.MinValue;
         AV43PromocionFechaFin = DateTime.MinValue;
         AV15PromocionArte = "";
         AV93Promocionarte_GXI = "";
         A44PromocionArte = "";
         A40000PromocionArte_GXI = "";
         AV11WizardData = new SdtWPFacturaWizardData(context);
         A43PromocionBase = "";
         A70PromocionVigencia = "";
         A45PromocionFechaInicio = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         GXCCtlgxBlob = "";
         AV80FacturaPDF = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         lblTextblockcombo_promocionid_Jsonclick = "";
         ucCombo_promocionid = new GXUserControl();
         TempTags = "";
         AV13PromocionVigencia = "";
         AV14PromocionBase = "";
         bttBtnuseraction1_Jsonclick = "";
         AV16FacturaNo = "";
         AV44FacturaFechaFactura = DateTime.MinValue;
         ucUsercontrol1 = new GXUserControl();
         lblTextblockcombo_modeloid_Jsonclick = "";
         ucCombo_modeloid = new GXUserControl();
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         ucBtnwizardfirstprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV70UsuarioJSON = "";
         AV5WebSession = context.GetSession();
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV83PromocionJSON = "";
         AV84SDTPromocion = new SdtSDTPromocion(context);
         H002U2_A41PromocionID = new int[1] ;
         H002U2_A40000PromocionArte_GXI = new string[] {""} ;
         H002U2_A44PromocionArte = new string[] {""} ;
         H002U3_A41PromocionID = new int[1] ;
         H002U3_A40000PromocionArte_GXI = new string[] {""} ;
         H002U3_A44PromocionArte = new string[] {""} ;
         Combo_modeloid_Selectedvalue_set = "";
         Combo_modeloid_Selectedtext_set = "";
         AV28SelectedTextCol = new GxSimpleCollection<string>();
         AV34SelectedTextVal = "";
         AV81FacturaNombre = "";
         H002U4_A48PromocionModeloID = new int[1] ;
         H002U4_A41PromocionID = new int[1] ;
         H002U4_A22ModeloID = new int[1] ;
         H002U4_A23ModeloDescripcion = new string[] {""} ;
         A23ModeloDescripcion = "";
         AV58ListaDistribuidores = new GxSimpleCollection<int>();
         H002U5_A47PromocionDistribuidorID = new int[1] ;
         H002U5_A10DistribuidorID = new int[1] ;
         H002U5_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         H002U5_A41PromocionID = new int[1] ;
         H002U5_A42PromocionDescripcion = new string[] {""} ;
         A42PromocionDescripcion = "";
         AV20Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         Combo_promocionid_Selectedvalue_set = "";
         H002U6_A81DistribuidoresUsuarioID = new int[1] ;
         H002U6_A29UsuarioID = new int[1] ;
         H002U6_A10DistribuidorID = new int[1] ;
         H002U7_A41PromocionID = new int[1] ;
         H002U7_A40000PromocionArte_GXI = new string[] {""} ;
         H002U7_A43PromocionBase = new string[] {""} ;
         H002U7_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         H002U7_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         H002U7_A44PromocionArte = new string[] {""} ;
         AV91Resultado = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpfacturawizardselecpromo__default(),
            new Object[][] {
                new Object[] {
               H002U2_A41PromocionID, H002U2_A40000PromocionArte_GXI, H002U2_A44PromocionArte
               }
               , new Object[] {
               H002U3_A41PromocionID, H002U3_A40000PromocionArte_GXI, H002U3_A44PromocionArte
               }
               , new Object[] {
               H002U4_A48PromocionModeloID, H002U4_A41PromocionID, H002U4_A22ModeloID, H002U4_A23ModeloDescripcion
               }
               , new Object[] {
               H002U5_A47PromocionDistribuidorID, H002U5_A10DistribuidorID, H002U5_A46PromocionFechaFin, H002U5_A41PromocionID, H002U5_A42PromocionDescripcion
               }
               , new Object[] {
               H002U6_A81DistribuidoresUsuarioID, H002U6_A29UsuarioID, H002U6_A10DistribuidorID
               }
               , new Object[] {
               H002U7_A41PromocionID, H002U7_A40000PromocionArte_GXI, H002U7_A43PromocionBase, H002U7_A46PromocionFechaFin, H002U7_A45PromocionFechaInicio, H002U7_A44PromocionArte
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         edtavPromocionvigencia_Enabled = 0;
         edtavPromocionbase_Enabled = 0;
      }

      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
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
      private short gxcookieaux ;
      private short AV94GXLvl114 ;
      private short AV98GXLvl286 ;
      private short AV90ErrorCode ;
      private short nGXWrapped ;
      private int edtavPromocionvigencia_Enabled ;
      private int edtavPromocionbase_Enabled ;
      private int A41PromocionID ;
      private int divTableinfopromo_Visible ;
      private int edtavFacturano_Enabled ;
      private int edtavFacturafechafactura_Enabled ;
      private int Usercontrol1_Maxnumberoffiles ;
      private int edtavFacturapdf_Enabled ;
      private int AV12PromocionID ;
      private int edtavPromocionid_Visible ;
      private int AV27Cond_SelecPromo_PromocionID ;
      private int AV96GXV1 ;
      private int AV97GXV2 ;
      private int AV32ModeloIDKey ;
      private int A22ModeloID ;
      private int A10DistribuidorID ;
      private int AV69UsuarioID ;
      private int A29UsuarioID ;
      private int AV101GXV3 ;
      private int AV52DistribuidorID ;
      private int AV89FacturaID ;
      private int idxLst ;
      private string Combo_promocionid_Ddointernalname ;
      private string Combo_modeloid_Ddointernalname ;
      private string edtavFacturapdf_Filename ;
      private string Combo_promocionid_Selectedtext_get ;
      private string Combo_modeloid_Selectedtext_get ;
      private string Combo_modeloid_Selectedvalue_get ;
      private string Combo_promocionid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavPromocionvigencia_Internalname ;
      private string edtavPromocionbase_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GXCCtlgxBlob ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string divTablesplittedpromocionid_Internalname ;
      private string lblTextblockcombo_promocionid_Internalname ;
      private string lblTextblockcombo_promocionid_Jsonclick ;
      private string Combo_promocionid_Caption ;
      private string Combo_promocionid_Cls ;
      private string Combo_promocionid_Internalname ;
      private string divTableinfopromo_Internalname ;
      private string TempTags ;
      private string edtavPromocionvigencia_Jsonclick ;
      private string bttBtnuseraction1_Internalname ;
      private string bttBtnuseraction1_Jsonclick ;
      private string edtavFacturano_Internalname ;
      private string AV16FacturaNo ;
      private string edtavFacturano_Jsonclick ;
      private string edtavFacturafechafactura_Internalname ;
      private string edtavFacturafechafactura_Jsonclick ;
      private string Usercontrol1_Tooltiptext ;
      private string Usercontrol1_Acceptedfiletypes ;
      private string Usercontrol1_Customfiletypes ;
      private string Usercontrol1_Internalname ;
      private string divTablesplittedmodeloid_Internalname ;
      private string lblTextblockcombo_modeloid_Internalname ;
      private string lblTextblockcombo_modeloid_Jsonclick ;
      private string Combo_modeloid_Caption ;
      private string Combo_modeloid_Cls ;
      private string Combo_modeloid_Datalistproc ;
      private string Combo_modeloid_Multiplevaluestype ;
      private string Combo_modeloid_Internalname ;
      private string edtavFacturapdf_Internalname ;
      private string edtavFacturapdf_Filetype ;
      private string edtavFacturapdf_Contenttype ;
      private string edtavFacturapdf_Parameters ;
      private string edtavFacturapdf_Jsonclick ;
      private string divTableactions_Internalname ;
      private string Btnwizardfirstprevious_Tooltiptext ;
      private string Btnwizardfirstprevious_Beforeiconclass ;
      private string Btnwizardfirstprevious_Caption ;
      private string Btnwizardfirstprevious_Class ;
      private string Btnwizardfirstprevious_Internalname ;
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Aftericonclass ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavPromocionid_Internalname ;
      private string edtavPromocionid_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Combo_modeloid_Selectedvalue_set ;
      private string Combo_modeloid_Selectedtext_set ;
      private string Combo_modeloid_Datalistprocparametersprefix ;
      private string Combo_promocionid_Selectedvalue_set ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private DateTime Gx_date ;
      private DateTime AV45PromocionFechaInicio ;
      private DateTime AV43PromocionFechaFin ;
      private DateTime A45PromocionFechaInicio ;
      private DateTime A46PromocionFechaFin ;
      private DateTime AV44FacturaFechaFactura ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool AV21CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Usercontrol1_Autoupload ;
      private bool Usercontrol1_Hideadditionalbuttons ;
      private bool Usercontrol1_Enableuploadedfilecanceling ;
      private bool Usercontrol1_Autodisableaddingfiles ;
      private bool Combo_modeloid_Allowmultipleselection ;
      private bool Combo_modeloid_Includeonlyselectedoption ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV88ValidaWWP ;
      private bool Btnwizardfirstprevious_Visible ;
      private bool AV73YaExiste ;
      private string AV70UsuarioJSON ;
      private string AV81FacturaNombre ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV93Promocionarte_GXI ;
      private string A40000PromocionArte_GXI ;
      private string A43PromocionBase ;
      private string A70PromocionVigencia ;
      private string AV13PromocionVigencia ;
      private string AV14PromocionBase ;
      private string AV83PromocionJSON ;
      private string AV34SelectedTextVal ;
      private string A23ModeloDescripcion ;
      private string A42PromocionDescripcion ;
      private string AV91Resultado ;
      private string AV15PromocionArte ;
      private string A44PromocionArte ;
      private string AV80FacturaPDF ;
      private IGxSession AV5WebSession ;
      private GxFile gxblobfileaux ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_promocionid ;
      private GXUserControl ucUsercontrol1 ;
      private GXUserControl ucCombo_modeloid ;
      private GXUserControl ucBtnwizardfirstprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private SdtSDTUsuario AV65SDTUsuario ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV23DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV18PromocionID_Data ;
      private GXBaseCollection<SdtFileUploadData> AV35UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV36FailedFiles ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV79ModeloID_Data ;
      private GxSimpleCollection<int> AV30ModeloID ;
      private SdtWPFacturaWizardData AV11WizardData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private SdtSDTPromocion AV84SDTPromocion ;
      private IDataStoreProvider pr_default ;
      private int[] H002U2_A41PromocionID ;
      private string[] H002U2_A40000PromocionArte_GXI ;
      private string[] H002U2_A44PromocionArte ;
      private int[] H002U3_A41PromocionID ;
      private string[] H002U3_A40000PromocionArte_GXI ;
      private string[] H002U3_A44PromocionArte ;
      private GxSimpleCollection<string> AV28SelectedTextCol ;
      private int[] H002U4_A48PromocionModeloID ;
      private int[] H002U4_A41PromocionID ;
      private int[] H002U4_A22ModeloID ;
      private string[] H002U4_A23ModeloDescripcion ;
      private GxSimpleCollection<int> AV58ListaDistribuidores ;
      private int[] H002U5_A47PromocionDistribuidorID ;
      private int[] H002U5_A10DistribuidorID ;
      private DateTime[] H002U5_A46PromocionFechaFin ;
      private int[] H002U5_A41PromocionID ;
      private string[] H002U5_A42PromocionDescripcion ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV20Combo_DataItem ;
      private int[] H002U6_A81DistribuidoresUsuarioID ;
      private int[] H002U6_A29UsuarioID ;
      private int[] H002U6_A10DistribuidorID ;
      private int[] H002U7_A41PromocionID ;
      private string[] H002U7_A40000PromocionArte_GXI ;
      private string[] H002U7_A43PromocionBase ;
      private DateTime[] H002U7_A46PromocionFechaFin ;
      private DateTime[] H002U7_A45PromocionFechaInicio ;
      private string[] H002U7_A44PromocionArte ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpfacturawizardselecpromo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002U5( IGxContext context ,
                                             int A10DistribuidorID ,
                                             GxSimpleCollection<int> AV58ListaDistribuidores ,
                                             DateTime A46PromocionFechaFin ,
                                             DateTime Gx_date )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[1];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.`PromocionDistribuidorID`, T1.`DistribuidorID`, T2.`PromocionFechaFin`, T1.`PromocionID`, T2.`PromocionDescripcion` FROM (`PromocionDistribuidor` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`)";
         AddWhere(sWhereString, "(T2.`PromocionFechaFin` >= @Gx_date and "+new GxDbmsUtils( new GxSqlServer()).ValueList(AV58ListaDistribuidores, "T1.`DistribuidorID` IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.`PromocionDescripcion`";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_H002U5(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002U2;
          prmH002U2 = new Object[] {
          new ParDef("@AV12PromocionID",GXType.Int32,9,0)
          };
          Object[] prmH002U3;
          prmH002U3 = new Object[] {
          new ParDef("@AV11Wiza_1Selecpromo_1Promoci",GXType.Int32,9,0)
          };
          Object[] prmH002U4;
          prmH002U4 = new Object[] {
          new ParDef("@AV27Cond_SelecPromo_PromocionID",GXType.Int32,9,0) ,
          new ParDef("@AV32ModeloIDKey",GXType.Int32,9,0)
          };
          Object[] prmH002U6;
          prmH002U6 = new Object[] {
          new ParDef("@AV69UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH002U7;
          prmH002U7 = new Object[] {
          new ParDef("@AV12PromocionID",GXType.Int32,9,0)
          };
          Object[] prmH002U5;
          prmH002U5 = new Object[] {
          new ParDef("@Gx_date",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002U2", "SELECT `PromocionID`, `PromocionArte_GXI`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @AV12PromocionID ORDER BY `PromocionID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002U2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002U3", "SELECT `PromocionID`, `PromocionArte_GXI`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @AV11Wiza_1Selecpromo_1Promoci ORDER BY `PromocionID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002U3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002U4", "SELECT T1.`PromocionModeloID`, T1.`PromocionID`, T1.`ModeloID`, T2.`ModeloDescripcion` FROM (`PromocionModelo` T1 INNER JOIN `Modelo` T2 ON T2.`ModeloID` = T1.`ModeloID`) WHERE T1.`PromocionID` = @AV27Cond_SelecPromo_PromocionID and T1.`ModeloID` = @AV32ModeloIDKey ORDER BY T1.`PromocionID`, T1.`ModeloID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002U4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002U5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002U5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H002U6", "SELECT `DistribuidoresUsuarioID`, `UsuarioID`, `DistribuidorID` FROM `DistribuidoresUsuario` WHERE `UsuarioID` = @AV69UsuarioID ORDER BY `UsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002U6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H002U7", "SELECT `PromocionID`, `PromocionArte_GXI`, `PromocionBase`, `PromocionFechaFin`, `PromocionFechaInicio`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @AV12PromocionID ORDER BY `PromocionID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002U7,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(2));
                return;
       }
    }

 }

}
