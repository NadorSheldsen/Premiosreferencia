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
   public class wpfacturawizardresumen : GXWebComponent
   {
      public wpfacturawizardresumen( )
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

      public wpfacturawizardresumen( IGxContext context )
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Selecmedidas_grid") == 0 )
               {
                  gxnrSelecmedidas_grid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Selecmedidas_grid") == 0 )
               {
                  gxgrSelecmedidas_grid_refresh_invoke( ) ;
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

      protected void gxnrSelecmedidas_grid_newrow_invoke( )
      {
         nRC_GXsfl_76 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_76"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_76_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_76_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_76_idx = GetPar( "sGXsfl_76_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrSelecmedidas_grid_newrow( ) ;
         /* End function gxnrSelecmedidas_grid_newrow_invoke */
      }

      protected void gxgrSelecmedidas_grid_refresh_invoke( )
      {
         subSelecmedidas_grid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subSelecmedidas_grid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV15UsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "UsuarioID"), "."), 18, MidpointRounding.ToEven));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrSelecmedidas_grid_refresh( subSelecmedidas_grid_Rows, AV15UsuarioID, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrSelecmedidas_grid_refresh_invoke */
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
            PA2Y2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavWizarddata_selecpromo_promocionid_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_selecpromo_promocionid_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_promocionid_description_Enabled), 5, 0), true);
               edtavWizarddata_selecpromo_promocionvigencia_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_selecpromo_promocionvigencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_promocionvigencia_Enabled), 5, 0), true);
               edtavWizarddata_selecpromo_promocionbase_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_selecpromo_promocionbase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_promocionbase_Enabled), 5, 0), true);
               edtavWizarddata_selecpromo_facturano_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_selecpromo_facturano_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_facturano_Enabled), 5, 0), true);
               edtavWizarddata_selecpromo_facturafechafactura_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_selecpromo_facturafechafactura_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_facturafechafactura_Enabled), 5, 0), true);
               edtavWizarddata_selecpromo_modeloid_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_selecpromo_modeloid_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_modeloid_description_Enabled), 5, 0), true);
               edtavWizarddata_selecpromo_facturapdf_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_selecpromo_facturapdf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_facturapdf_Enabled), 5, 0), true);
               edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Enabled), 5, 0), !bGXsfl_76_Refreshing);
               edtavWizarddata_selecmedidas_grid__cantidad_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_selecmedidas_grid__cantidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecmedidas_grid__cantidad_Enabled), 5, 0), !bGXsfl_76_Refreshing);
               edtavWizarddata_selecmedidas_grid__precio_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_selecmedidas_grid__precio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecmedidas_grid__precio_Enabled), 5, 0), !bGXsfl_76_Refreshing);
               edtavWizarddata_selecmedidas_grid__medidaid_Enabled = 0;
               AssignProp(sPrefix, false, edtavWizarddata_selecmedidas_grid__medidaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecmedidas_grid__medidaid_Enabled), 5, 0), !bGXsfl_76_Refreshing);
               WS2Y2( ) ;
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
            context.SendWebValue( context.GetMessage( "WPFactura Wizard Resumen", "")) ;
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
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GXEncryptionTmp = "wpfacturawizardresumen.aspx"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpfacturawizardresumen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15UsuarioID), "ZZZZZZZZ9"), context));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Wizarddata_selecmedidas_grid", AV12WizardData_SelecMedidas_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Wizarddata_selecmedidas_grid", AV12WizardData_SelecMedidas_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_76", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_76), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vFINISHWIZARDOK", AV20FinishWizardOk);
         GxWebStd.gx_hidden_field( context, sPrefix+"FACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"FACTURACOMPLETA", A93FacturaCompleta);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA_SELECMEDIDAS_GRID", AV12WizardData_SelecMedidas_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA_SELECMEDIDAS_GRID", AV12WizardData_SelecMedidas_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"SELECMEDIDAS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(SELECMEDIDAS_GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SELECMEDIDAS_GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(SELECMEDIDAS_GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"SELECMEDIDAS_GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelecmedidas_grid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm2Y2( )
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
         return "WPFacturaWizardResumen" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WPFactura Wizard Resumen", "") ;
      }

      protected void WB2Y0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpfacturawizardresumen.aspx");
               context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divSelecpromo_summarytable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSelecpromo_summaryheadertable_Internalname, 1, 0, "px", 0, "px", "TableWizardSummaryStep", "start", "top", " "+"data-gx-flex"+" ", "justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSelecpromo_summarytitle_Internalname, context.GetMessage( "Seleccionar promoción", ""), "", "", lblSelecpromo_summarytitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "WizardStepDescription", 0, "", 1, 1, 0, 0, "HLP_WPFacturaWizardResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonAsLinkBasecolor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardgotoselecpromo_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(76), 2, 0)+","+"null"+");", context.GetMessage( "WWP_WizardGoToCaption", ""), bttBtnwizardgotoselecpromo_Jsonclick, 5, context.GetMessage( "WWP_WizardGoToCaption", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'WIZARDGOTO SELECPROMO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPFacturaWizardResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSelecpromo_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWizarddata_selecpromo_promocionid_description_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWizarddata_selecpromo_promocionid_description_Internalname, context.GetMessage( "Promoción", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_76_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWizarddata_selecpromo_promocionid_description_Internalname, AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionid_description, StringUtil.RTrim( context.localUtil.Format( AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionid_description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWizarddata_selecpromo_promocionid_description_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavWizarddata_selecpromo_promocionid_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPFacturaWizardResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSelecpromo_tableinfopromo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWizarddata_selecpromo_promocionvigencia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWizarddata_selecpromo_promocionvigencia_Internalname, context.GetMessage( "Vigencia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'" + sGXsfl_76_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWizarddata_selecpromo_promocionvigencia_Internalname, AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionvigencia, StringUtil.RTrim( context.localUtil.Format( AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionvigencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWizarddata_selecpromo_promocionvigencia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavWizarddata_selecpromo_promocionvigencia_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPFacturaWizardResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWizarddata_selecpromo_promocionbase_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWizarddata_selecpromo_promocionbase_Internalname, context.GetMessage( "Bases", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'" + sGXsfl_76_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavWizarddata_selecpromo_promocionbase_Internalname, AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionbase, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", 0, 1, edtavWizarddata_selecpromo_promocionbase_Enabled, 0, 80, "chr", 9, "row", 0, StyleString, ClassString, "", "", "700", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WPFacturaWizardResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWizarddata_selecpromo_facturano_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWizarddata_selecpromo_facturano_Internalname, context.GetMessage( "No. Factura", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'" + sGXsfl_76_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWizarddata_selecpromo_facturano_Internalname, StringUtil.RTrim( AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturano), StringUtil.RTrim( context.localUtil.Format( AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturano, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWizarddata_selecpromo_facturano_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavWizarddata_selecpromo_facturano_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPFacturaWizardResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWizarddata_selecpromo_facturafechafactura_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWizarddata_selecpromo_facturafechafactura_Internalname, context.GetMessage( "Fecha", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_76_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavWizarddata_selecpromo_facturafechafactura_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavWizarddata_selecpromo_facturafechafactura_Internalname, context.localUtil.Format(AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturafechafactura, "99/99/99"), context.localUtil.Format( AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturafechafactura, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWizarddata_selecpromo_facturafechafactura_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavWizarddata_selecpromo_facturafechafactura_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPFacturaWizardResumen.htm");
            GxWebStd.gx_bitmap( context, edtavWizarddata_selecpromo_facturafechafactura_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavWizarddata_selecpromo_facturafechafactura_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPFacturaWizardResumen.htm");
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
            ucUsercontrol1.Render(context, "fileupload", Usercontrol1_Internalname, sPrefix+"USERCONTROL1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWizarddata_selecpromo_modeloid_description_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWizarddata_selecpromo_modeloid_description_Internalname, context.GetMessage( "Modelos", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_76_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWizarddata_selecpromo_modeloid_description_Internalname, AV11WizardData.gxTpr_Selecpromo.gxTpr_Modeloid_description, StringUtil.RTrim( context.localUtil.Format( AV11WizardData.gxTpr_Selecpromo.gxTpr_Modeloid_description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWizarddata_selecpromo_modeloid_description_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavWizarddata_selecpromo_modeloid_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPFacturaWizardResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWizarddata_selecpromo_facturapdf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWizarddata_selecpromo_facturapdf_Internalname, context.GetMessage( "Factura", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            ClassString = "AttributeFL";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'" + sGXsfl_76_idx + "',0)\"";
            edtavWizarddata_selecpromo_facturapdf_Filetype = "tmp";
            AssignProp(sPrefix, false, edtavWizarddata_selecpromo_facturapdf_Internalname, "Filetype", edtavWizarddata_selecpromo_facturapdf_Filetype, true);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturapdf)) )
            {
               gxblobfileaux.Source = AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturapdf;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavWizarddata_selecpromo_facturapdf_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavWizarddata_selecpromo_facturapdf_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturapdf = gxblobfileaux.GetURI();
                  edtavWizarddata_selecpromo_facturapdf_Filetype = gxblobfileaux.GetExtension();
                  AssignProp(sPrefix, false, edtavWizarddata_selecpromo_facturapdf_Internalname, "Filetype", edtavWizarddata_selecpromo_facturapdf_Filetype, true);
               }
               AssignProp(sPrefix, false, edtavWizarddata_selecpromo_facturapdf_Internalname, "URL", context.PathToRelativeUrl( AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturapdf), true);
            }
            GxWebStd.gx_blob_field( context, edtavWizarddata_selecpromo_facturapdf_Internalname, StringUtil.RTrim( AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturapdf), context.PathToRelativeUrl( AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturapdf), (String.IsNullOrEmpty(StringUtil.RTrim( edtavWizarddata_selecpromo_facturapdf_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavWizarddata_selecpromo_facturapdf_Filetype)) ? AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturapdf : edtavWizarddata_selecpromo_facturapdf_Filetype)) : edtavWizarddata_selecpromo_facturapdf_Contenttype), false, "", edtavWizarddata_selecpromo_facturapdf_Parameters, 0, edtavWizarddata_selecpromo_facturapdf_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtavWizarddata_selecpromo_facturapdf_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", "", "HLP_WPFacturaWizardResumen.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSelecmedidas_summarytable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSelecmedidas_summaryheadertable_Internalname, 1, 0, "px", 0, "px", "TableWizardSummaryStep", "start", "top", " "+"data-gx-flex"+" ", "justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSelecmedidas_summarytitle_Internalname, context.GetMessage( "Seleccionar Medidas", ""), "", "", lblSelecmedidas_summarytitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "WizardStepDescription", 0, "", 1, 1, 0, 0, "HLP_WPFacturaWizardResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonAsLinkBasecolor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardgotoselecmedidas_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(76), 2, 0)+","+"null"+");", context.GetMessage( "WWP_WizardGoToCaption", ""), bttBtnwizardgotoselecmedidas_Jsonclick, 5, context.GetMessage( "WWP_WizardGoToCaption", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'WIZARDGOTO SELECMEDIDAS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPFacturaWizardResumen.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSelecmedidas_tablegrid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Selecmedidas_gridContainer.SetWrapped(nGXWrapped);
            StartGridControl76( ) ;
         }
         if ( wbEnd == 76 )
         {
            wbEnd = 0;
            nRC_GXsfl_76 = (int)(nGXsfl_76_idx-1);
            if ( Selecmedidas_gridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Selecmedidas_gridContainer.AddObjectProperty("SELECMEDIDAS_GRID_nEOF", SELECMEDIDAS_GRID_nEOF);
               Selecmedidas_gridContainer.AddObjectProperty("SELECMEDIDAS_GRID_nFirstRecordOnPage", SELECMEDIDAS_GRID_nFirstRecordOnPage);
               AV37GXV8 = nGXsfl_76_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Selecmedidas_gridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Selecmedidas_grid", Selecmedidas_gridContainer, subSelecmedidas_grid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Selecmedidas_gridContainerData", Selecmedidas_gridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Selecmedidas_gridContainerData"+"V", Selecmedidas_gridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Selecmedidas_gridContainerData"+"V"+"\" value='"+Selecmedidas_gridContainer.GridValuesHidden()+"'/>") ;
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
            ucSelecmedidas_grid_empowerer.Render(context, "wwp.gridempowerer", Selecmedidas_grid_empowerer_Internalname, sPrefix+"SELECMEDIDAS_GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 76 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Selecmedidas_gridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Selecmedidas_gridContainer.AddObjectProperty("SELECMEDIDAS_GRID_nEOF", SELECMEDIDAS_GRID_nEOF);
                  Selecmedidas_gridContainer.AddObjectProperty("SELECMEDIDAS_GRID_nFirstRecordOnPage", SELECMEDIDAS_GRID_nFirstRecordOnPage);
                  AV37GXV8 = nGXsfl_76_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Selecmedidas_gridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Selecmedidas_grid", Selecmedidas_gridContainer, subSelecmedidas_grid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Selecmedidas_gridContainerData", Selecmedidas_gridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Selecmedidas_gridContainerData"+"V", Selecmedidas_gridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Selecmedidas_gridContainerData"+"V"+"\" value='"+Selecmedidas_gridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2Y2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WPFactura Wizard Resumen", ""), 0) ;
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
               STRUP2Y0( ) ;
            }
         }
      }

      protected void WS2Y2( )
      {
         START2Y2( ) ;
         EVT2Y2( ) ;
      }

      protected void EVT2Y2( )
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
                                 STRUP2Y0( ) ;
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
                                 STRUP2Y0( ) ;
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
                                          E112Y2 ();
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
                                 STRUP2Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E122Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDGOTO SELECMEDIDAS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardGoTo SelecMedidas' */
                                    E132Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDGOTO SELECPROMO'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardGoTo SelecPromo' */
                                    E142Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavWizarddata_selecpromo_promocionid_description_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SELECMEDIDAS_GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Y0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"SELECMEDIDAS_GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subselecmedidas_grid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subselecmedidas_grid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subselecmedidas_grid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subselecmedidas_grid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "SELECMEDIDAS_GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Y0( ) ;
                              }
                              nGXsfl_76_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
                              SubsflControlProps_762( ) ;
                              AV37GXV8 = (int)(nGXsfl_76_idx+SELECMEDIDAS_GRID_nFirstRecordOnPage);
                              if ( ( AV12WizardData_SelecMedidas_Grid.Count >= AV37GXV8 ) && ( AV37GXV8 > 0 ) )
                              {
                                 AV12WizardData_SelecMedidas_Grid.CurrentItem = ((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV12WizardData_SelecMedidas_Grid.Item(AV37GXV8));
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
                                          GX_FocusControl = edtavWizarddata_selecpromo_promocionid_description_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E152Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "SELECMEDIDAS_GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavWizarddata_selecpromo_promocionid_description_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Selecmedidas_grid.Load */
                                          E162Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavWizarddata_selecpromo_promocionid_description_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E172Y2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP2Y0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavWizarddata_selecpromo_promocionid_description_Internalname;
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

      protected void WE2Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2Y2( ) ;
            }
         }
      }

      protected void PA2Y2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpfacturawizardresumen.aspx")), "wpfacturawizardresumen.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpfacturawizardresumen.aspx")))) ;
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
               GX_FocusControl = edtavWizarddata_selecpromo_promocionid_description_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrSelecmedidas_grid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_762( ) ;
         while ( nGXsfl_76_idx <= nRC_GXsfl_76 )
         {
            sendrow_762( ) ;
            nGXsfl_76_idx = ((subSelecmedidas_grid_Islastpage==1)&&(nGXsfl_76_idx+1>subSelecmedidas_grid_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_idx+1);
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_762( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Selecmedidas_gridContainer)) ;
         /* End function gxnrSelecmedidas_grid_newrow */
      }

      protected void gxgrSelecmedidas_grid_refresh( int subSelecmedidas_grid_Rows ,
                                                    int AV15UsuarioID ,
                                                    string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         SELECMEDIDAS_GRID_nCurrentRecord = 0;
         RF2Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrSelecmedidas_grid_refresh */
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
         RF2Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavWizarddata_selecpromo_promocionid_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_selecpromo_promocionid_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_promocionid_description_Enabled), 5, 0), true);
         edtavWizarddata_selecpromo_promocionvigencia_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_selecpromo_promocionvigencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_promocionvigencia_Enabled), 5, 0), true);
         edtavWizarddata_selecpromo_promocionbase_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_selecpromo_promocionbase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_promocionbase_Enabled), 5, 0), true);
         edtavWizarddata_selecpromo_facturano_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_selecpromo_facturano_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_facturano_Enabled), 5, 0), true);
         edtavWizarddata_selecpromo_facturafechafactura_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_selecpromo_facturafechafactura_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_facturafechafactura_Enabled), 5, 0), true);
         edtavWizarddata_selecpromo_modeloid_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_selecpromo_modeloid_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_modeloid_description_Enabled), 5, 0), true);
         edtavWizarddata_selecpromo_facturapdf_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_selecpromo_facturapdf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_facturapdf_Enabled), 5, 0), true);
         edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Enabled = 0;
         edtavWizarddata_selecmedidas_grid__cantidad_Enabled = 0;
         edtavWizarddata_selecmedidas_grid__precio_Enabled = 0;
         edtavWizarddata_selecmedidas_grid__medidaid_Enabled = 0;
      }

      protected void RF2Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Selecmedidas_gridContainer.ClearRows();
         }
         wbStart = 76;
         /* Execute user event: Refresh */
         E172Y2 ();
         nGXsfl_76_idx = 1;
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_762( ) ;
         bGXsfl_76_Refreshing = true;
         Selecmedidas_gridContainer.AddObjectProperty("GridName", "Selecmedidas_grid");
         Selecmedidas_gridContainer.AddObjectProperty("CmpContext", sPrefix);
         Selecmedidas_gridContainer.AddObjectProperty("InMasterPage", "false");
         Selecmedidas_gridContainer.AddObjectProperty("Class", "GridNoBorder WorkWith");
         Selecmedidas_gridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Selecmedidas_gridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Selecmedidas_gridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelecmedidas_grid_Backcolorstyle), 1, 0, ".", "")));
         Selecmedidas_gridContainer.PageSize = subSelecmedidas_grid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_762( ) ;
            /* Execute user event: Selecmedidas_grid.Load */
            E162Y2 ();
            if ( ( subSelecmedidas_grid_Islastpage == 0 ) && ( SELECMEDIDAS_GRID_nCurrentRecord > 0 ) && ( SELECMEDIDAS_GRID_nGridOutOfScope == 0 ) && ( nGXsfl_76_idx == 1 ) )
            {
               SELECMEDIDAS_GRID_nCurrentRecord = 0;
               SELECMEDIDAS_GRID_nGridOutOfScope = 1;
               subselecmedidas_grid_firstpage( ) ;
               /* Execute user event: Selecmedidas_grid.Load */
               E162Y2 ();
            }
            wbEnd = 76;
            WB2Y0( ) ;
         }
         bGXsfl_76_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2Y2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15UsuarioID), "ZZZZZZZZ9"), context));
      }

      protected int subSelecmedidas_grid_fnc_Pagecount( )
      {
         SELECMEDIDAS_GRID_nRecordCount = subSelecmedidas_grid_fnc_Recordcount( );
         if ( ((int)((SELECMEDIDAS_GRID_nRecordCount) % (subSelecmedidas_grid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(SELECMEDIDAS_GRID_nRecordCount/ (decimal)(subSelecmedidas_grid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(SELECMEDIDAS_GRID_nRecordCount/ (decimal)(subSelecmedidas_grid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subSelecmedidas_grid_fnc_Recordcount( )
      {
         return AV12WizardData_SelecMedidas_Grid.Count ;
      }

      protected int subSelecmedidas_grid_fnc_Recordsperpage( )
      {
         if ( subSelecmedidas_grid_Rows > 0 )
         {
            return subSelecmedidas_grid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subSelecmedidas_grid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(SELECMEDIDAS_GRID_nFirstRecordOnPage/ (decimal)(subSelecmedidas_grid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subselecmedidas_grid_firstpage( )
      {
         SELECMEDIDAS_GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"SELECMEDIDAS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(SELECMEDIDAS_GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrSelecmedidas_grid_refresh( subSelecmedidas_grid_Rows, AV15UsuarioID, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subselecmedidas_grid_nextpage( )
      {
         SELECMEDIDAS_GRID_nRecordCount = subSelecmedidas_grid_fnc_Recordcount( );
         if ( ( SELECMEDIDAS_GRID_nRecordCount >= subSelecmedidas_grid_fnc_Recordsperpage( ) ) && ( SELECMEDIDAS_GRID_nEOF == 0 ) )
         {
            SELECMEDIDAS_GRID_nFirstRecordOnPage = (long)(SELECMEDIDAS_GRID_nFirstRecordOnPage+subSelecmedidas_grid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"SELECMEDIDAS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(SELECMEDIDAS_GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         Selecmedidas_gridContainer.AddObjectProperty("SELECMEDIDAS_GRID_nFirstRecordOnPage", SELECMEDIDAS_GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrSelecmedidas_grid_refresh( subSelecmedidas_grid_Rows, AV15UsuarioID, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((SELECMEDIDAS_GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subselecmedidas_grid_previouspage( )
      {
         if ( SELECMEDIDAS_GRID_nFirstRecordOnPage >= subSelecmedidas_grid_fnc_Recordsperpage( ) )
         {
            SELECMEDIDAS_GRID_nFirstRecordOnPage = (long)(SELECMEDIDAS_GRID_nFirstRecordOnPage-subSelecmedidas_grid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"SELECMEDIDAS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(SELECMEDIDAS_GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrSelecmedidas_grid_refresh( subSelecmedidas_grid_Rows, AV15UsuarioID, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subselecmedidas_grid_lastpage( )
      {
         SELECMEDIDAS_GRID_nRecordCount = subSelecmedidas_grid_fnc_Recordcount( );
         if ( SELECMEDIDAS_GRID_nRecordCount > subSelecmedidas_grid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((SELECMEDIDAS_GRID_nRecordCount) % (subSelecmedidas_grid_fnc_Recordsperpage( )))) == 0 )
            {
               SELECMEDIDAS_GRID_nFirstRecordOnPage = (long)(SELECMEDIDAS_GRID_nRecordCount-subSelecmedidas_grid_fnc_Recordsperpage( ));
            }
            else
            {
               SELECMEDIDAS_GRID_nFirstRecordOnPage = (long)(SELECMEDIDAS_GRID_nRecordCount-((int)((SELECMEDIDAS_GRID_nRecordCount) % (subSelecmedidas_grid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            SELECMEDIDAS_GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"SELECMEDIDAS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(SELECMEDIDAS_GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrSelecmedidas_grid_refresh( subSelecmedidas_grid_Rows, AV15UsuarioID, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subselecmedidas_grid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            SELECMEDIDAS_GRID_nFirstRecordOnPage = (long)(subSelecmedidas_grid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            SELECMEDIDAS_GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"SELECMEDIDAS_GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(SELECMEDIDAS_GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrSelecmedidas_grid_refresh( subSelecmedidas_grid_Rows, AV15UsuarioID, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavWizarddata_selecpromo_promocionid_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_selecpromo_promocionid_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_promocionid_description_Enabled), 5, 0), true);
         edtavWizarddata_selecpromo_promocionvigencia_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_selecpromo_promocionvigencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_promocionvigencia_Enabled), 5, 0), true);
         edtavWizarddata_selecpromo_promocionbase_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_selecpromo_promocionbase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_promocionbase_Enabled), 5, 0), true);
         edtavWizarddata_selecpromo_facturano_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_selecpromo_facturano_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_facturano_Enabled), 5, 0), true);
         edtavWizarddata_selecpromo_facturafechafactura_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_selecpromo_facturafechafactura_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_facturafechafactura_Enabled), 5, 0), true);
         edtavWizarddata_selecpromo_modeloid_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_selecpromo_modeloid_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_modeloid_description_Enabled), 5, 0), true);
         edtavWizarddata_selecpromo_facturapdf_Enabled = 0;
         AssignProp(sPrefix, false, edtavWizarddata_selecpromo_facturapdf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWizarddata_selecpromo_facturapdf_Enabled), 5, 0), true);
         edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Enabled = 0;
         edtavWizarddata_selecmedidas_grid__cantidad_Enabled = 0;
         edtavWizarddata_selecmedidas_grid__precio_Enabled = 0;
         edtavWizarddata_selecmedidas_grid__medidaid_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E152Y2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vWIZARDDATA"), AV11WizardData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wizarddata"), AV11WizardData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Wizarddata_selecmedidas_grid"), AV12WizardData_SelecMedidas_Grid);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vWIZARDDATA_SELECMEDIDAS_GRID"), AV12WizardData_SelecMedidas_Grid);
            /* Read saved values. */
            nRC_GXsfl_76 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_76"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            SELECMEDIDAS_GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"SELECMEDIDAS_GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            SELECMEDIDAS_GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"SELECMEDIDAS_GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subSelecmedidas_grid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"SELECMEDIDAS_GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"SELECMEDIDAS_GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelecmedidas_grid_Rows), 6, 0, ".", "")));
            nRC_GXsfl_76 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_76"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_76_fel_idx = 0;
            while ( nGXsfl_76_fel_idx < nRC_GXsfl_76 )
            {
               nGXsfl_76_fel_idx = ((subSelecmedidas_grid_Islastpage==1)&&(nGXsfl_76_fel_idx+1>subSelecmedidas_grid_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_fel_idx+1);
               sGXsfl_76_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_762( ) ;
               AV37GXV8 = (int)(nGXsfl_76_fel_idx+SELECMEDIDAS_GRID_nFirstRecordOnPage);
               if ( ( AV12WizardData_SelecMedidas_Grid.Count >= AV37GXV8 ) && ( AV37GXV8 > 0 ) )
               {
                  AV12WizardData_SelecMedidas_Grid.CurrentItem = ((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV12WizardData_SelecMedidas_Grid.Item(AV37GXV8));
               }
            }
            if ( nGXsfl_76_fel_idx == 0 )
            {
               nGXsfl_76_idx = 1;
               sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
               SubsflControlProps_762( ) ;
            }
            nGXsfl_76_fel_idx = 1;
            /* Read variables values. */
            AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionid_description = cgiGet( edtavWizarddata_selecpromo_promocionid_description_Internalname);
            AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionvigencia = cgiGet( edtavWizarddata_selecpromo_promocionvigencia_Internalname);
            AV11WizardData.gxTpr_Selecpromo.gxTpr_Promocionbase = cgiGet( edtavWizarddata_selecpromo_promocionbase_Internalname);
            AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturano = cgiGet( edtavWizarddata_selecpromo_facturano_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavWizarddata_selecpromo_facturafechafactura_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {""}), 1, "WIZARDDATA_SELECPROMO_FACTURAFECHAFACTURA");
               GX_FocusControl = edtavWizarddata_selecpromo_facturafechafactura_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturafechafactura = DateTime.MinValue;
            }
            else
            {
               AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturafechafactura = context.localUtil.CToD( cgiGet( edtavWizarddata_selecpromo_facturafechafactura_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV11WizardData.gxTpr_Selecpromo.gxTpr_Modeloid_description = cgiGet( edtavWizarddata_selecpromo_modeloid_description_Internalname);
            AV11WizardData.gxTpr_Selecpromo.gxTpr_Facturapdf = cgiGet( edtavWizarddata_selecpromo_facturapdf_Internalname);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
         E152Y2 ();
         if (returnInSub) return;
      }

      protected void E152Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         Selecmedidas_grid_empowerer_Gridinternalname = subSelecmedidas_grid_Internalname;
         ucSelecmedidas_grid_empowerer.SendProperty(context, sPrefix, false, Selecmedidas_grid_empowerer_Internalname, "GridInternalName", Selecmedidas_grid_empowerer_Gridinternalname);
         subSelecmedidas_grid_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"SELECMEDIDAS_GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelecmedidas_grid_Rows), 6, 0, ".", "")));
         Usercontrol1_Visible = false;
         ucUsercontrol1.SendProperty(context, sPrefix, false, Usercontrol1_Internalname, "Visible", StringUtil.BoolToStr( Usercontrol1_Visible));
         AV14UsuarioJSON = AV5WebSession.Get(context.GetMessage( "Usuario", ""));
         AV16SDTUsuario.FromJSonString(AV14UsuarioJSON, null);
         AV15UsuarioID = AV16SDTUsuario.gxTpr_Usuarioid;
         AssignAttri(sPrefix, false, "AV15UsuarioID", StringUtil.LTrimStr( (decimal)(AV15UsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV15UsuarioID), "ZZZZZZZZ9"), context));
      }

      private void E162Y2( )
      {
         /* Selecmedidas_grid_Load Routine */
         returnInSub = false;
         AV37GXV8 = 1;
         while ( AV37GXV8 <= AV12WizardData_SelecMedidas_Grid.Count )
         {
            AV12WizardData_SelecMedidas_Grid.CurrentItem = ((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV12WizardData_SelecMedidas_Grid.Item(AV37GXV8));
            Usercontrol1_Visible = false;
            ucUsercontrol1.SendProperty(context, sPrefix, false, Usercontrol1_Internalname, "Visible", StringUtil.BoolToStr( Usercontrol1_Visible));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 76;
            }
            if ( ( subSelecmedidas_grid_Islastpage == 1 ) || ( subSelecmedidas_grid_Rows == 0 ) || ( ( SELECMEDIDAS_GRID_nCurrentRecord >= SELECMEDIDAS_GRID_nFirstRecordOnPage ) && ( SELECMEDIDAS_GRID_nCurrentRecord < SELECMEDIDAS_GRID_nFirstRecordOnPage + subSelecmedidas_grid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_762( ) ;
            }
            SELECMEDIDAS_GRID_nEOF = (short)(((SELECMEDIDAS_GRID_nCurrentRecord<SELECMEDIDAS_GRID_nFirstRecordOnPage+subSelecmedidas_grid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"SELECMEDIDAS_GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(SELECMEDIDAS_GRID_nEOF), 1, 0, ".", "")));
            SELECMEDIDAS_GRID_nCurrentRecord = (long)(SELECMEDIDAS_GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_76_Refreshing )
            {
               DoAjaxLoad(76, Selecmedidas_gridRow);
            }
            AV37GXV8 = (int)(AV37GXV8+1);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E112Y2 ();
         if (returnInSub) return;
      }

      protected void E112Y2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV19ValidaWWP = false;
         if ( AV19ValidaWWP )
         {
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
         }
         else
         {
            if ( ! AV10HasValidationErrors )
            {
               /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
               S122 ();
               if (returnInSub) return;
               /* Execute user subroutine: 'FINISHWIZARD' */
               S132 ();
               if (returnInSub) return;
               if ( AV20FinishWizardOk )
               {
                  AV5WebSession.Remove(AV6WebSessionKey);
                  AV5WebSession.Remove(context.GetMessage( "FacturaWizardID", ""));
                  CallWebObject(formatLink("wpfacturaspart.aspx") );
                  context.wjLocDisableFrm = 1;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E122Y2( )
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
         GXEncryptionTmp = "wpfacturawizard.aspx"+UrlEncode(StringUtil.RTrim("Resumen")) + "," + UrlEncode(StringUtil.RTrim("SelecMedidas")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wpfacturawizard.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E132Y2( )
      {
         /* 'WizardGoTo SelecMedidas' Routine */
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
         GXEncryptionTmp = "wpfacturawizard.aspx"+UrlEncode(StringUtil.RTrim("Resumen")) + "," + UrlEncode(StringUtil.RTrim("SelecMedidas")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wpfacturawizard.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E142Y2( )
      {
         /* 'WizardGoTo SelecPromo' Routine */
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
         GXEncryptionTmp = "wpfacturawizard.aspx"+UrlEncode(StringUtil.RTrim("Resumen")) + "," + UrlEncode(StringUtil.RTrim("SelecPromo")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wpfacturawizard.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV12WizardData_SelecMedidas_Grid = AV11WizardData.gxTpr_Selecmedidas.gxTpr_Grid;
         gx_BV76 = true;
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
         AV20FinishWizardOk = false;
         AssignAttri(sPrefix, false, "AV20FinishWizardOk", AV20FinishWizardOk);
         AV21FinalizarFacturaOK = true;
         AV22FacturaExiste = false;
         AV23TieneMedidasFactura = false;
         AV24FacturaIDTexto = AV5WebSession.Get(context.GetMessage( "FacturaWizardID", ""));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24FacturaIDTexto)) )
         {
            GX_msglist.addItem(context.GetMessage( "No se encontró la factura temporal. Vuelve a registrar la factura desde el inicio.", ""));
            AV10HasValidationErrors = true;
            AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
            AV21FinalizarFacturaOK = false;
         }
         else
         {
            AV25FacturaID = (int)(Math.Round(NumberUtil.Val( AV24FacturaIDTexto, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV25FacturaID", StringUtil.LTrimStr( (decimal)(AV25FacturaID), 9, 0));
            if ( (0==AV25FacturaID) )
            {
               GX_msglist.addItem(context.GetMessage( "No se encontró la factura temporal. Vuelve a registrar la factura desde el inicio.", ""));
               AV10HasValidationErrors = true;
               AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
               AV21FinalizarFacturaOK = false;
            }
         }
         if ( AV21FinalizarFacturaOK )
         {
            /* Using cursor H002Y2 */
            pr_default.execute(0, new Object[] {AV25FacturaID, AV15UsuarioID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A93FacturaCompleta = H002Y2_A93FacturaCompleta[0];
               A29UsuarioID = H002Y2_A29UsuarioID[0];
               A69FacturaID = H002Y2_A69FacturaID[0];
               AV22FacturaExiste = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( ! AV22FacturaExiste )
            {
               GX_msglist.addItem(context.GetMessage( "La factura temporal ya no existe o ya fue finalizada. Vuelve a registrar la factura desde el inicio.", ""));
               AV10HasValidationErrors = true;
               AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
               AV21FinalizarFacturaOK = false;
            }
         }
         if ( AV21FinalizarFacturaOK )
         {
            /* Using cursor H002Y3 */
            pr_default.execute(1, new Object[] {AV25FacturaID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A69FacturaID = H002Y3_A69FacturaID[0];
               AV23TieneMedidasFactura = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( ! AV23TieneMedidasFactura )
            {
               GX_msglist.addItem(context.GetMessage( "La factura no tiene medidas registradas. Regresa al paso anterior y captura al menos una medida.", ""));
               AV10HasValidationErrors = true;
               AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
               AV21FinalizarFacturaOK = false;
            }
         }
         if ( AV21FinalizarFacturaOK )
         {
            AV29Factura.Load(AV25FacturaID);
            if ( AV29Factura.Fail() )
            {
               GX_msglist.addItem(context.GetMessage( "Error al cargar la factura para finalizarla.", ""));
               AV27Messages = AV29Factura.GetMessages();
               AV44GXV13 = 1;
               while ( AV44GXV13 <= AV27Messages.Count )
               {
                  AV28Message = ((GeneXus.Utils.SdtMessages_Message)AV27Messages.Item(AV44GXV13));
                  GX_msglist.addItem(AV28Message.gxTpr_Description);
                  AV44GXV13 = (int)(AV44GXV13+1);
               }
               AV10HasValidationErrors = true;
               AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
               AV21FinalizarFacturaOK = false;
            }
            else
            {
               AV29Factura.gxTpr_Facturacompleta = true;
               AV29Factura.Save();
               if ( AV29Factura.Fail() )
               {
                  context.RollbackDataStores("wpfacturawizardresumen",pr_default);
                  GX_msglist.addItem(context.GetMessage( "Error al finalizar la factura.", ""));
                  AV27Messages = AV29Factura.GetMessages();
                  AV45GXV14 = 1;
                  while ( AV45GXV14 <= AV27Messages.Count )
                  {
                     AV28Message = ((GeneXus.Utils.SdtMessages_Message)AV27Messages.Item(AV45GXV14));
                     GX_msglist.addItem(AV28Message.gxTpr_Description);
                     AV45GXV14 = (int)(AV45GXV14+1);
                  }
                  AV10HasValidationErrors = true;
                  AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
                  AV21FinalizarFacturaOK = false;
               }
               else
               {
                  context.CommitDataStores("wpfacturawizardresumen",pr_default);
                  AV20FinishWizardOk = true;
                  AssignAttri(sPrefix, false, "AV20FinishWizardOk", AV20FinishWizardOk);
                  GX_msglist.addItem(context.GetMessage( "La factura fue guardada correctamente.", ""));
               }
            }
         }
      }

      protected void E172Y2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         Usercontrol1_Visible = false;
         ucUsercontrol1.SendProperty(context, sPrefix, false, Usercontrol1_Internalname, "Visible", StringUtil.BoolToStr( Usercontrol1_Visible));
         /*  Sending Event outputs  */
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
         PA2Y2( ) ;
         WS2Y2( ) ;
         WE2Y2( ) ;
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
         PA2Y2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpfacturawizardresumen", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2Y2( ) ;
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
         PA2Y2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2Y2( ) ;
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
         WS2Y2( ) ;
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
         WE2Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20265111130587", true, true);
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
         context.AddJavascriptSource("wpfacturawizardresumen.js", "?20265111130587", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_762( )
      {
         edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Internalname = sPrefix+"WIZARDDATA_SELECMEDIDAS_GRID__MEDIDANOMBRECOMPLETO_"+sGXsfl_76_idx;
         edtavWizarddata_selecmedidas_grid__cantidad_Internalname = sPrefix+"WIZARDDATA_SELECMEDIDAS_GRID__CANTIDAD_"+sGXsfl_76_idx;
         edtavWizarddata_selecmedidas_grid__precio_Internalname = sPrefix+"WIZARDDATA_SELECMEDIDAS_GRID__PRECIO_"+sGXsfl_76_idx;
         edtavWizarddata_selecmedidas_grid__medidaid_Internalname = sPrefix+"WIZARDDATA_SELECMEDIDAS_GRID__MEDIDAID_"+sGXsfl_76_idx;
      }

      protected void SubsflControlProps_fel_762( )
      {
         edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Internalname = sPrefix+"WIZARDDATA_SELECMEDIDAS_GRID__MEDIDANOMBRECOMPLETO_"+sGXsfl_76_fel_idx;
         edtavWizarddata_selecmedidas_grid__cantidad_Internalname = sPrefix+"WIZARDDATA_SELECMEDIDAS_GRID__CANTIDAD_"+sGXsfl_76_fel_idx;
         edtavWizarddata_selecmedidas_grid__precio_Internalname = sPrefix+"WIZARDDATA_SELECMEDIDAS_GRID__PRECIO_"+sGXsfl_76_fel_idx;
         edtavWizarddata_selecmedidas_grid__medidaid_Internalname = sPrefix+"WIZARDDATA_SELECMEDIDAS_GRID__MEDIDAID_"+sGXsfl_76_fel_idx;
      }

      protected void sendrow_762( )
      {
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_762( ) ;
         WB2Y0( ) ;
         if ( ( subSelecmedidas_grid_Rows * 1 == 0 ) || ( nGXsfl_76_idx <= subSelecmedidas_grid_fnc_Recordsperpage( ) * 1 ) )
         {
            Selecmedidas_gridRow = GXWebRow.GetNew(context,Selecmedidas_gridContainer);
            if ( subSelecmedidas_grid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subSelecmedidas_grid_Backstyle = 0;
               if ( StringUtil.StrCmp(subSelecmedidas_grid_Class, "") != 0 )
               {
                  subSelecmedidas_grid_Linesclass = subSelecmedidas_grid_Class+"Odd";
               }
            }
            else if ( subSelecmedidas_grid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subSelecmedidas_grid_Backstyle = 0;
               subSelecmedidas_grid_Backcolor = subSelecmedidas_grid_Allbackcolor;
               if ( StringUtil.StrCmp(subSelecmedidas_grid_Class, "") != 0 )
               {
                  subSelecmedidas_grid_Linesclass = subSelecmedidas_grid_Class+"Uniform";
               }
            }
            else if ( subSelecmedidas_grid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subSelecmedidas_grid_Backstyle = 1;
               if ( StringUtil.StrCmp(subSelecmedidas_grid_Class, "") != 0 )
               {
                  subSelecmedidas_grid_Linesclass = subSelecmedidas_grid_Class+"Odd";
               }
               subSelecmedidas_grid_Backcolor = (int)(0x0);
            }
            else if ( subSelecmedidas_grid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subSelecmedidas_grid_Backstyle = 1;
               if ( ((int)((nGXsfl_76_idx) % (2))) == 0 )
               {
                  subSelecmedidas_grid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subSelecmedidas_grid_Class, "") != 0 )
                  {
                     subSelecmedidas_grid_Linesclass = subSelecmedidas_grid_Class+"Even";
                  }
               }
               else
               {
                  subSelecmedidas_grid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subSelecmedidas_grid_Class, "") != 0 )
                  {
                     subSelecmedidas_grid_Linesclass = subSelecmedidas_grid_Class+"Odd";
                  }
               }
            }
            if ( Selecmedidas_gridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridNoBorder WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_76_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Selecmedidas_gridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'" + sGXsfl_76_idx + "',76)\"";
            ROClassString = "Attribute";
            Selecmedidas_gridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Internalname,((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV12WizardData_SelecMedidas_Grid.Item(AV37GXV8)).gxTpr_Medidanombrecompleto,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Selecmedidas_gridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'" + sGXsfl_76_idx + "',76)\"";
            ROClassString = "Attribute";
            Selecmedidas_gridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWizarddata_selecmedidas_grid__cantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV12WizardData_SelecMedidas_Grid.Item(AV37GXV8)).gxTpr_Cantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavWizarddata_selecmedidas_grid__cantidad_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV12WizardData_SelecMedidas_Grid.Item(AV37GXV8)).gxTpr_Cantidad), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV12WizardData_SelecMedidas_Grid.Item(AV37GXV8)).gxTpr_Cantidad), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,78);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWizarddata_selecmedidas_grid__cantidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWizarddata_selecmedidas_grid__cantidad_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Selecmedidas_gridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'" + sGXsfl_76_idx + "',76)\"";
            ROClassString = "Attribute";
            Selecmedidas_gridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWizarddata_selecmedidas_grid__precio_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV12WizardData_SelecMedidas_Grid.Item(AV37GXV8)).gxTpr_Precio, 14, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavWizarddata_selecmedidas_grid__precio_Enabled!=0) ? context.localUtil.Format( ((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV12WizardData_SelecMedidas_Grid.Item(AV37GXV8)).gxTpr_Precio, "$ Z,ZZZ,ZZ9.99") : context.localUtil.Format( ((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV12WizardData_SelecMedidas_Grid.Item(AV37GXV8)).gxTpr_Precio, "$ Z,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,79);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWizarddata_selecmedidas_grid__precio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWizarddata_selecmedidas_grid__precio_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Selecmedidas_gridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Selecmedidas_gridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWizarddata_selecmedidas_grid__medidaid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV12WizardData_SelecMedidas_Grid.Item(AV37GXV8)).gxTpr_Medidaid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavWizarddata_selecmedidas_grid__medidaid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV12WizardData_SelecMedidas_Grid.Item(AV37GXV8)).gxTpr_Medidaid), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV12WizardData_SelecMedidas_Grid.Item(AV37GXV8)).gxTpr_Medidaid), "ZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWizarddata_selecmedidas_grid__medidaid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavWizarddata_selecmedidas_grid__medidaid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes2Y2( ) ;
            Selecmedidas_gridContainer.AddRow(Selecmedidas_gridRow);
            nGXsfl_76_idx = ((subSelecmedidas_grid_Islastpage==1)&&(nGXsfl_76_idx+1>subSelecmedidas_grid_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_idx+1);
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_762( ) ;
         }
         /* End function sendrow_762 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl76( )
      {
         if ( Selecmedidas_gridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Selecmedidas_gridContainer"+"DivS\" data-gxgridid=\"76\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subSelecmedidas_grid_Internalname, subSelecmedidas_grid_Internalname, "", "GridNoBorder WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subSelecmedidas_grid_Backcolorstyle == 0 )
            {
               subSelecmedidas_grid_Titlebackstyle = 0;
               if ( StringUtil.Len( subSelecmedidas_grid_Class) > 0 )
               {
                  subSelecmedidas_grid_Linesclass = subSelecmedidas_grid_Class+"Title";
               }
            }
            else
            {
               subSelecmedidas_grid_Titlebackstyle = 1;
               if ( subSelecmedidas_grid_Backcolorstyle == 1 )
               {
                  subSelecmedidas_grid_Titlebackcolor = subSelecmedidas_grid_Allbackcolor;
                  if ( StringUtil.Len( subSelecmedidas_grid_Class) > 0 )
                  {
                     subSelecmedidas_grid_Linesclass = subSelecmedidas_grid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subSelecmedidas_grid_Class) > 0 )
                  {
                     subSelecmedidas_grid_Linesclass = subSelecmedidas_grid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Modelo/Medida/Código", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Cantidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio Unitario (IVA incluído)", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Medida ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Selecmedidas_gridContainer.AddObjectProperty("GridName", "Selecmedidas_grid");
         }
         else
         {
            Selecmedidas_gridContainer.AddObjectProperty("GridName", "Selecmedidas_grid");
            Selecmedidas_gridContainer.AddObjectProperty("Header", subSelecmedidas_grid_Header);
            Selecmedidas_gridContainer.AddObjectProperty("Class", "GridNoBorder WorkWith");
            Selecmedidas_gridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Selecmedidas_gridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Selecmedidas_gridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelecmedidas_grid_Backcolorstyle), 1, 0, ".", "")));
            Selecmedidas_gridContainer.AddObjectProperty("CmpContext", sPrefix);
            Selecmedidas_gridContainer.AddObjectProperty("InMasterPage", "false");
            Selecmedidas_gridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Selecmedidas_gridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Enabled), 5, 0, ".", "")));
            Selecmedidas_gridContainer.AddColumnProperties(Selecmedidas_gridColumn);
            Selecmedidas_gridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Selecmedidas_gridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWizarddata_selecmedidas_grid__cantidad_Enabled), 5, 0, ".", "")));
            Selecmedidas_gridContainer.AddColumnProperties(Selecmedidas_gridColumn);
            Selecmedidas_gridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Selecmedidas_gridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWizarddata_selecmedidas_grid__precio_Enabled), 5, 0, ".", "")));
            Selecmedidas_gridContainer.AddColumnProperties(Selecmedidas_gridColumn);
            Selecmedidas_gridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Selecmedidas_gridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWizarddata_selecmedidas_grid__medidaid_Enabled), 5, 0, ".", "")));
            Selecmedidas_gridContainer.AddColumnProperties(Selecmedidas_gridColumn);
            Selecmedidas_gridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelecmedidas_grid_Selectedindex), 4, 0, ".", "")));
            Selecmedidas_gridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelecmedidas_grid_Allowselection), 1, 0, ".", "")));
            Selecmedidas_gridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelecmedidas_grid_Selectioncolor), 9, 0, ".", "")));
            Selecmedidas_gridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelecmedidas_grid_Allowhovering), 1, 0, ".", "")));
            Selecmedidas_gridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelecmedidas_grid_Hoveringcolor), 9, 0, ".", "")));
            Selecmedidas_gridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelecmedidas_grid_Allowcollapsing), 1, 0, ".", "")));
            Selecmedidas_gridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelecmedidas_grid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblSelecpromo_summarytitle_Internalname = sPrefix+"SELECPROMO_SUMMARYTITLE";
         bttBtnwizardgotoselecpromo_Internalname = sPrefix+"BTNWIZARDGOTOSELECPROMO";
         divSelecpromo_summaryheadertable_Internalname = sPrefix+"SELECPROMO_SUMMARYHEADERTABLE";
         edtavWizarddata_selecpromo_promocionid_description_Internalname = sPrefix+"WIZARDDATA_SELECPROMO_PROMOCIONID_DESCRIPTION";
         edtavWizarddata_selecpromo_promocionvigencia_Internalname = sPrefix+"WIZARDDATA_SELECPROMO_PROMOCIONVIGENCIA";
         edtavWizarddata_selecpromo_promocionbase_Internalname = sPrefix+"WIZARDDATA_SELECPROMO_PROMOCIONBASE";
         edtavWizarddata_selecpromo_facturano_Internalname = sPrefix+"WIZARDDATA_SELECPROMO_FACTURANO";
         edtavWizarddata_selecpromo_facturafechafactura_Internalname = sPrefix+"WIZARDDATA_SELECPROMO_FACTURAFECHAFACTURA";
         Usercontrol1_Internalname = sPrefix+"USERCONTROL1";
         edtavWizarddata_selecpromo_modeloid_description_Internalname = sPrefix+"WIZARDDATA_SELECPROMO_MODELOID_DESCRIPTION";
         edtavWizarddata_selecpromo_facturapdf_Internalname = sPrefix+"WIZARDDATA_SELECPROMO_FACTURAPDF";
         divSelecpromo_tableinfopromo_Internalname = sPrefix+"SELECPROMO_TABLEINFOPROMO";
         divSelecpromo_tableattributes_Internalname = sPrefix+"SELECPROMO_TABLEATTRIBUTES";
         divSelecpromo_summarytable_Internalname = sPrefix+"SELECPROMO_SUMMARYTABLE";
         lblSelecmedidas_summarytitle_Internalname = sPrefix+"SELECMEDIDAS_SUMMARYTITLE";
         bttBtnwizardgotoselecmedidas_Internalname = sPrefix+"BTNWIZARDGOTOSELECMEDIDAS";
         divSelecmedidas_summaryheadertable_Internalname = sPrefix+"SELECMEDIDAS_SUMMARYHEADERTABLE";
         edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Internalname = sPrefix+"WIZARDDATA_SELECMEDIDAS_GRID__MEDIDANOMBRECOMPLETO";
         edtavWizarddata_selecmedidas_grid__cantidad_Internalname = sPrefix+"WIZARDDATA_SELECMEDIDAS_GRID__CANTIDAD";
         edtavWizarddata_selecmedidas_grid__precio_Internalname = sPrefix+"WIZARDDATA_SELECMEDIDAS_GRID__PRECIO";
         edtavWizarddata_selecmedidas_grid__medidaid_Internalname = sPrefix+"WIZARDDATA_SELECMEDIDAS_GRID__MEDIDAID";
         divSelecmedidas_tablegrid_Internalname = sPrefix+"SELECMEDIDAS_TABLEGRID";
         divSelecmedidas_summarytable_Internalname = sPrefix+"SELECMEDIDAS_SUMMARYTABLE";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardlastnext_Internalname = sPrefix+"BTNWIZARDLASTNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Selecmedidas_grid_empowerer_Internalname = sPrefix+"SELECMEDIDAS_GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subSelecmedidas_grid_Internalname = sPrefix+"SELECMEDIDAS_GRID";
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
         subSelecmedidas_grid_Allowcollapsing = 0;
         subSelecmedidas_grid_Allowselection = 0;
         subSelecmedidas_grid_Header = "";
         edtavWizarddata_selecmedidas_grid__medidaid_Jsonclick = "";
         edtavWizarddata_selecmedidas_grid__medidaid_Enabled = 0;
         edtavWizarddata_selecmedidas_grid__precio_Jsonclick = "";
         edtavWizarddata_selecmedidas_grid__precio_Enabled = 0;
         edtavWizarddata_selecmedidas_grid__cantidad_Jsonclick = "";
         edtavWizarddata_selecmedidas_grid__cantidad_Enabled = 0;
         edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Jsonclick = "";
         edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Enabled = 0;
         subSelecmedidas_grid_Class = "GridNoBorder WorkWith";
         subSelecmedidas_grid_Backcolorstyle = 0;
         Usercontrol1_Visible = Convert.ToBoolean( -1);
         Btnwizardlastnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardlastnext_Caption = context.GetMessage( "WWP_WizardFinishCaption", "");
         Btnwizardlastnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardlastnext_Tooltiptext = "";
         Btnwizardprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardprevious_Caption = context.GetMessage( "GXM_previous", "");
         Btnwizardprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardprevious_Tooltiptext = "";
         edtavWizarddata_selecpromo_facturapdf_Jsonclick = "";
         edtavWizarddata_selecpromo_facturapdf_Parameters = "";
         edtavWizarddata_selecpromo_facturapdf_Contenttype = "";
         edtavWizarddata_selecpromo_facturapdf_Filetype = "";
         edtavWizarddata_selecpromo_facturapdf_Enabled = 0;
         edtavWizarddata_selecpromo_modeloid_description_Jsonclick = "";
         edtavWizarddata_selecpromo_modeloid_description_Enabled = 0;
         Usercontrol1_Customfiletypes = "pdf";
         Usercontrol1_Acceptedfiletypes = "custom";
         Usercontrol1_Autodisableaddingfiles = Convert.ToBoolean( -1);
         Usercontrol1_Maxnumberoffiles = 1;
         Usercontrol1_Enableuploadedfilecanceling = Convert.ToBoolean( -1);
         Usercontrol1_Tooltiptext = "";
         Usercontrol1_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Usercontrol1_Autoupload = Convert.ToBoolean( -1);
         edtavWizarddata_selecpromo_facturafechafactura_Jsonclick = "";
         edtavWizarddata_selecpromo_facturafechafactura_Enabled = 0;
         edtavWizarddata_selecpromo_facturano_Jsonclick = "";
         edtavWizarddata_selecpromo_facturano_Enabled = 0;
         edtavWizarddata_selecpromo_promocionbase_Enabled = 0;
         edtavWizarddata_selecpromo_promocionvigencia_Jsonclick = "";
         edtavWizarddata_selecpromo_promocionvigencia_Enabled = 0;
         edtavWizarddata_selecpromo_promocionid_description_Jsonclick = "";
         edtavWizarddata_selecpromo_promocionid_description_Enabled = 0;
         edtavWizarddata_selecmedidas_grid__medidaid_Enabled = -1;
         edtavWizarddata_selecmedidas_grid__precio_Enabled = -1;
         edtavWizarddata_selecmedidas_grid__cantidad_Enabled = -1;
         edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Enabled = -1;
         edtavWizarddata_selecpromo_facturapdf_Enabled = -1;
         edtavWizarddata_selecpromo_modeloid_description_Enabled = -1;
         edtavWizarddata_selecpromo_facturafechafactura_Enabled = -1;
         edtavWizarddata_selecpromo_facturano_Enabled = -1;
         edtavWizarddata_selecpromo_promocionbase_Enabled = -1;
         edtavWizarddata_selecpromo_promocionvigencia_Enabled = -1;
         edtavWizarddata_selecpromo_promocionid_description_Enabled = -1;
         subSelecmedidas_grid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"SELECMEDIDAS_GRID_nFirstRecordOnPage"},{"av":"SELECMEDIDAS_GRID_nEOF"},{"av":"AV12WizardData_SelecMedidas_Grid","fld":"vWIZARDDATA_SELECMEDIDAS_GRID","grid":76},{"av":"nGXsfl_76_idx","ctrl":"GRID","prop":"GridCurrRow","grid":76},{"av":"nRC_GXsfl_76","ctrl":"SELECMEDIDAS_GRID","prop":"GridRC","grid":76},{"av":"subSelecmedidas_grid_Rows","ctrl":"SELECMEDIDAS_GRID","prop":"Rows"},{"av":"sPrefix"},{"av":"AV15UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Usercontrol1_Visible","ctrl":"USERCONTROL1","prop":"Visible"}]}""");
         setEventMetadata("SELECMEDIDAS_GRID.LOAD","""{"handler":"E162Y2","iparms":[]""");
         setEventMetadata("SELECMEDIDAS_GRID.LOAD",""","oparms":[{"av":"Usercontrol1_Visible","ctrl":"USERCONTROL1","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E112Y2","iparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV20FinishWizardOk","fld":"vFINISHWIZARDOK"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV25FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV15UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"AV20FinishWizardOk","fld":"vFINISHWIZARDOK"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS"},{"av":"AV25FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E122Y2","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'WIZARDGOTO SELECMEDIDAS'","""{"handler":"E132Y2","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"}]""");
         setEventMetadata("'WIZARDGOTO SELECMEDIDAS'",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'WIZARDGOTO SELECPROMO'","""{"handler":"E142Y2","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"}]""");
         setEventMetadata("'WIZARDGOTO SELECPROMO'",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("SELECMEDIDAS_GRID_FIRSTPAGE","""{"handler":"subselecmedidas_grid_firstpage","iparms":[{"av":"SELECMEDIDAS_GRID_nFirstRecordOnPage"},{"av":"SELECMEDIDAS_GRID_nEOF"},{"av":"AV12WizardData_SelecMedidas_Grid","fld":"vWIZARDDATA_SELECMEDIDAS_GRID","grid":76},{"av":"nGXsfl_76_idx","ctrl":"GRID","prop":"GridCurrRow","grid":76},{"av":"nRC_GXsfl_76","ctrl":"SELECMEDIDAS_GRID","prop":"GridRC","grid":76},{"av":"subSelecmedidas_grid_Rows","ctrl":"SELECMEDIDAS_GRID","prop":"Rows"},{"av":"AV15UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"sPrefix"}]""");
         setEventMetadata("SELECMEDIDAS_GRID_FIRSTPAGE",""","oparms":[{"av":"Usercontrol1_Visible","ctrl":"USERCONTROL1","prop":"Visible"}]}""");
         setEventMetadata("SELECMEDIDAS_GRID_PREVPAGE","""{"handler":"subselecmedidas_grid_previouspage","iparms":[{"av":"SELECMEDIDAS_GRID_nFirstRecordOnPage"},{"av":"SELECMEDIDAS_GRID_nEOF"},{"av":"AV12WizardData_SelecMedidas_Grid","fld":"vWIZARDDATA_SELECMEDIDAS_GRID","grid":76},{"av":"nGXsfl_76_idx","ctrl":"GRID","prop":"GridCurrRow","grid":76},{"av":"nRC_GXsfl_76","ctrl":"SELECMEDIDAS_GRID","prop":"GridRC","grid":76},{"av":"subSelecmedidas_grid_Rows","ctrl":"SELECMEDIDAS_GRID","prop":"Rows"},{"av":"AV15UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"sPrefix"}]""");
         setEventMetadata("SELECMEDIDAS_GRID_PREVPAGE",""","oparms":[{"av":"Usercontrol1_Visible","ctrl":"USERCONTROL1","prop":"Visible"}]}""");
         setEventMetadata("SELECMEDIDAS_GRID_NEXTPAGE","""{"handler":"subselecmedidas_grid_nextpage","iparms":[{"av":"SELECMEDIDAS_GRID_nFirstRecordOnPage"},{"av":"SELECMEDIDAS_GRID_nEOF"},{"av":"AV12WizardData_SelecMedidas_Grid","fld":"vWIZARDDATA_SELECMEDIDAS_GRID","grid":76},{"av":"nGXsfl_76_idx","ctrl":"GRID","prop":"GridCurrRow","grid":76},{"av":"nRC_GXsfl_76","ctrl":"SELECMEDIDAS_GRID","prop":"GridRC","grid":76},{"av":"subSelecmedidas_grid_Rows","ctrl":"SELECMEDIDAS_GRID","prop":"Rows"},{"av":"AV15UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"sPrefix"}]""");
         setEventMetadata("SELECMEDIDAS_GRID_NEXTPAGE",""","oparms":[{"av":"Usercontrol1_Visible","ctrl":"USERCONTROL1","prop":"Visible"}]}""");
         setEventMetadata("SELECMEDIDAS_GRID_LASTPAGE","""{"handler":"subselecmedidas_grid_lastpage","iparms":[{"av":"SELECMEDIDAS_GRID_nFirstRecordOnPage"},{"av":"SELECMEDIDAS_GRID_nEOF"},{"av":"AV12WizardData_SelecMedidas_Grid","fld":"vWIZARDDATA_SELECMEDIDAS_GRID","grid":76},{"av":"nGXsfl_76_idx","ctrl":"GRID","prop":"GridCurrRow","grid":76},{"av":"nRC_GXsfl_76","ctrl":"SELECMEDIDAS_GRID","prop":"GridRC","grid":76},{"av":"subSelecmedidas_grid_Rows","ctrl":"SELECMEDIDAS_GRID","prop":"Rows"},{"av":"AV15UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"sPrefix"}]""");
         setEventMetadata("SELECMEDIDAS_GRID_LASTPAGE",""","oparms":[{"av":"Usercontrol1_Visible","ctrl":"USERCONTROL1","prop":"Visible"}]}""");
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

      public override bool UploadEnabled( )
      {
         return true ;
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
         AV11WizardData = new SdtWPFacturaWizardData(context);
         AV12WizardData_SelecMedidas_Grid = new GXBaseCollection<SdtWPFacturaWizardData_SelecMedidas_GridItem>( context, "WPFacturaWizardData.SelecMedidas.GridItem", "");
         GX_FocusControl = "";
         lblSelecpromo_summarytitle_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnwizardgotoselecpromo_Jsonclick = "";
         ucUsercontrol1 = new GXUserControl();
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         lblSelecmedidas_summarytitle_Jsonclick = "";
         bttBtnwizardgotoselecmedidas_Jsonclick = "";
         Selecmedidas_gridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardlastnext = new GXUserControl();
         ucSelecmedidas_grid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         Selecmedidas_grid_empowerer_Gridinternalname = "";
         AV14UsuarioJSON = "";
         AV5WebSession = context.GetSession();
         AV16SDTUsuario = new SdtSDTUsuario(context);
         Selecmedidas_gridRow = new GXWebRow();
         AV24FacturaIDTexto = "";
         H002Y2_A93FacturaCompleta = new bool[] {false} ;
         H002Y2_A29UsuarioID = new int[1] ;
         H002Y2_A69FacturaID = new int[1] ;
         H002Y3_A77FacturaMedidaID = new int[1] ;
         H002Y3_A69FacturaID = new int[1] ;
         AV29Factura = new SdtFactura(context);
         AV27Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV28Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         subSelecmedidas_grid_Linesclass = "";
         ROClassString = "";
         Selecmedidas_gridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpfacturawizardresumen__default(),
            new Object[][] {
                new Object[] {
               H002Y2_A93FacturaCompleta, H002Y2_A29UsuarioID, H002Y2_A69FacturaID
               }
               , new Object[] {
               H002Y3_A77FacturaMedidaID, H002Y3_A69FacturaID
               }
            }
         );
         /* GeneXus formulas. */
         edtavWizarddata_selecpromo_promocionid_description_Enabled = 0;
         edtavWizarddata_selecpromo_promocionvigencia_Enabled = 0;
         edtavWizarddata_selecpromo_promocionbase_Enabled = 0;
         edtavWizarddata_selecpromo_facturano_Enabled = 0;
         edtavWizarddata_selecpromo_facturafechafactura_Enabled = 0;
         edtavWizarddata_selecpromo_modeloid_description_Enabled = 0;
         edtavWizarddata_selecpromo_facturapdf_Enabled = 0;
         edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Enabled = 0;
         edtavWizarddata_selecmedidas_grid__cantidad_Enabled = 0;
         edtavWizarddata_selecmedidas_grid__precio_Enabled = 0;
         edtavWizarddata_selecmedidas_grid__medidaid_Enabled = 0;
      }

      private short SELECMEDIDAS_GRID_nEOF ;
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
      private short subSelecmedidas_grid_Backcolorstyle ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subSelecmedidas_grid_Backstyle ;
      private short subSelecmedidas_grid_Titlebackstyle ;
      private short subSelecmedidas_grid_Allowselection ;
      private short subSelecmedidas_grid_Allowhovering ;
      private short subSelecmedidas_grid_Allowcollapsing ;
      private short subSelecmedidas_grid_Collapsed ;
      private int nRC_GXsfl_76 ;
      private int subSelecmedidas_grid_Rows ;
      private int nGXsfl_76_idx=1 ;
      private int AV15UsuarioID ;
      private int edtavWizarddata_selecpromo_promocionid_description_Enabled ;
      private int edtavWizarddata_selecpromo_promocionvigencia_Enabled ;
      private int edtavWizarddata_selecpromo_promocionbase_Enabled ;
      private int edtavWizarddata_selecpromo_facturano_Enabled ;
      private int edtavWizarddata_selecpromo_facturafechafactura_Enabled ;
      private int edtavWizarddata_selecpromo_modeloid_description_Enabled ;
      private int edtavWizarddata_selecpromo_facturapdf_Enabled ;
      private int edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Enabled ;
      private int edtavWizarddata_selecmedidas_grid__cantidad_Enabled ;
      private int edtavWizarddata_selecmedidas_grid__precio_Enabled ;
      private int edtavWizarddata_selecmedidas_grid__medidaid_Enabled ;
      private int A69FacturaID ;
      private int AV25FacturaID ;
      private int A29UsuarioID ;
      private int Usercontrol1_Maxnumberoffiles ;
      private int AV37GXV8 ;
      private int subSelecmedidas_grid_Islastpage ;
      private int SELECMEDIDAS_GRID_nGridOutOfScope ;
      private int nGXsfl_76_fel_idx=1 ;
      private int AV44GXV13 ;
      private int AV45GXV14 ;
      private int idxLst ;
      private int subSelecmedidas_grid_Backcolor ;
      private int subSelecmedidas_grid_Allbackcolor ;
      private int subSelecmedidas_grid_Titlebackcolor ;
      private int subSelecmedidas_grid_Selectedindex ;
      private int subSelecmedidas_grid_Selectioncolor ;
      private int subSelecmedidas_grid_Hoveringcolor ;
      private long SELECMEDIDAS_GRID_nFirstRecordOnPage ;
      private long SELECMEDIDAS_GRID_nCurrentRecord ;
      private long SELECMEDIDAS_GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_76_idx="0001" ;
      private string edtavWizarddata_selecpromo_promocionid_description_Internalname ;
      private string edtavWizarddata_selecpromo_promocionvigencia_Internalname ;
      private string edtavWizarddata_selecpromo_promocionbase_Internalname ;
      private string edtavWizarddata_selecpromo_facturano_Internalname ;
      private string edtavWizarddata_selecpromo_facturafechafactura_Internalname ;
      private string edtavWizarddata_selecpromo_modeloid_description_Internalname ;
      private string edtavWizarddata_selecpromo_facturapdf_Internalname ;
      private string edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Internalname ;
      private string edtavWizarddata_selecmedidas_grid__cantidad_Internalname ;
      private string edtavWizarddata_selecmedidas_grid__precio_Internalname ;
      private string edtavWizarddata_selecmedidas_grid__medidaid_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divSelecpromo_summarytable_Internalname ;
      private string divSelecpromo_summaryheadertable_Internalname ;
      private string lblSelecpromo_summarytitle_Internalname ;
      private string lblSelecpromo_summarytitle_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnwizardgotoselecpromo_Internalname ;
      private string bttBtnwizardgotoselecpromo_Jsonclick ;
      private string divSelecpromo_tableattributes_Internalname ;
      private string edtavWizarddata_selecpromo_promocionid_description_Jsonclick ;
      private string divSelecpromo_tableinfopromo_Internalname ;
      private string edtavWizarddata_selecpromo_promocionvigencia_Jsonclick ;
      private string edtavWizarddata_selecpromo_facturano_Jsonclick ;
      private string edtavWizarddata_selecpromo_facturafechafactura_Jsonclick ;
      private string Usercontrol1_Tooltiptext ;
      private string Usercontrol1_Acceptedfiletypes ;
      private string Usercontrol1_Customfiletypes ;
      private string Usercontrol1_Internalname ;
      private string edtavWizarddata_selecpromo_modeloid_description_Jsonclick ;
      private string edtavWizarddata_selecpromo_facturapdf_Filetype ;
      private string edtavWizarddata_selecpromo_facturapdf_Contenttype ;
      private string edtavWizarddata_selecpromo_facturapdf_Parameters ;
      private string edtavWizarddata_selecpromo_facturapdf_Jsonclick ;
      private string divSelecmedidas_summarytable_Internalname ;
      private string divSelecmedidas_summaryheadertable_Internalname ;
      private string lblSelecmedidas_summarytitle_Internalname ;
      private string lblSelecmedidas_summarytitle_Jsonclick ;
      private string bttBtnwizardgotoselecmedidas_Internalname ;
      private string bttBtnwizardgotoselecmedidas_Jsonclick ;
      private string divSelecmedidas_tablegrid_Internalname ;
      private string sStyleString ;
      private string subSelecmedidas_grid_Internalname ;
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
      private string Selecmedidas_grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sGXsfl_76_fel_idx="0001" ;
      private string Selecmedidas_grid_empowerer_Gridinternalname ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private string subSelecmedidas_grid_Class ;
      private string subSelecmedidas_grid_Linesclass ;
      private string ROClassString ;
      private string edtavWizarddata_selecmedidas_grid__medidanombrecompleto_Jsonclick ;
      private string edtavWizarddata_selecmedidas_grid__cantidad_Jsonclick ;
      private string edtavWizarddata_selecmedidas_grid__precio_Jsonclick ;
      private string edtavWizarddata_selecmedidas_grid__medidaid_Jsonclick ;
      private string subSelecmedidas_grid_Header ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_76_Refreshing=false ;
      private bool AV10HasValidationErrors ;
      private bool AV20FinishWizardOk ;
      private bool A93FacturaCompleta ;
      private bool wbLoad ;
      private bool Usercontrol1_Autoupload ;
      private bool Usercontrol1_Hideadditionalbuttons ;
      private bool Usercontrol1_Enableuploadedfilecanceling ;
      private bool Usercontrol1_Autodisableaddingfiles ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool Usercontrol1_Visible ;
      private bool AV19ValidaWWP ;
      private bool gx_BV76 ;
      private bool AV21FinalizarFacturaOK ;
      private bool AV22FacturaExiste ;
      private bool AV23TieneMedidasFactura ;
      private bool gx_refresh_fired ;
      private string AV14UsuarioJSON ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV24FacturaIDTexto ;
      private IGxSession AV5WebSession ;
      private GxFile gxblobfileaux ;
      private GXWebGrid Selecmedidas_gridContainer ;
      private GXWebRow Selecmedidas_gridRow ;
      private GXWebColumn Selecmedidas_gridColumn ;
      private GXUserControl ucUsercontrol1 ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardlastnext ;
      private GXUserControl ucSelecmedidas_grid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private SdtWPFacturaWizardData AV11WizardData ;
      private GXBaseCollection<SdtWPFacturaWizardData_SelecMedidas_GridItem> AV12WizardData_SelecMedidas_Grid ;
      private SdtSDTUsuario AV16SDTUsuario ;
      private IDataStoreProvider pr_default ;
      private bool[] H002Y2_A93FacturaCompleta ;
      private int[] H002Y2_A29UsuarioID ;
      private int[] H002Y2_A69FacturaID ;
      private int[] H002Y3_A77FacturaMedidaID ;
      private int[] H002Y3_A69FacturaID ;
      private SdtFactura AV29Factura ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV27Messages ;
      private GeneXus.Utils.SdtMessages_Message AV28Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpfacturawizardresumen__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH002Y2;
          prmH002Y2 = new Object[] {
          new ParDef("@AV25FacturaID",GXType.Int32,9,0) ,
          new ParDef("@AV15UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH002Y3;
          prmH002Y3 = new Object[] {
          new ParDef("@AV25FacturaID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002Y2", "SELECT `FacturaCompleta`, `UsuarioID`, `FacturaID` FROM `Factura` WHERE (`FacturaID` = @AV25FacturaID) AND (`UsuarioID` = @AV15UsuarioID) AND (`FacturaCompleta` = 0) ORDER BY `FacturaID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Y2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002Y3", "SELECT `FacturaMedidaID`, `FacturaID` FROM `FacturaMedida` WHERE `FacturaID` = @AV25FacturaID ORDER BY `FacturaID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Y3,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
