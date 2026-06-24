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
   public class wpfacturawizardselecmedidas : GXWebComponent
   {
      public wpfacturawizardselecmedidas( )
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

      public wpfacturawizardselecmedidas( IGxContext context )
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
         chkavGridselected = new GXCheckbox();
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  gxnrGrid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  gxgrGrid_refresh_invoke( ) ;
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_18 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_18"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_18_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_18_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_18_idx = GetPar( "sGXsfl_18_idx");
         sPrefix = GetPar( "sPrefix");
         chkavGridselected_Titleformat = (short)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         chkavGridselected.Title.Text = GetNextPar( );
         AssignProp(sPrefix, false, chkavGridselected_Internalname, "Title", chkavGridselected.Title.Text, !bGXsfl_18_Refreshing);
         AV12MedidaNombreCompleto = GetPar( "MedidaNombreCompleto");
         AV21MedidaID = (int)(Math.Round(NumberUtil.Val( GetPar( "MedidaID"), "."), 18, MidpointRounding.ToEven));
         AV16Cantidad = (short)(Math.Round(NumberUtil.Val( GetPar( "Cantidad"), "."), 18, MidpointRounding.ToEven));
         edtavCantidad_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavCantidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCantidad_Enabled), 5, 0), !bGXsfl_18_Refreshing);
         AV17Precio = NumberUtil.Val( GetPar( "Precio"), ".");
         edtavPrecio_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPrecio_Enabled), 5, 0), !bGXsfl_18_Refreshing);
         AV13GridSelected = StringUtil.StrToBool( GetPar( "GridSelected"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         chkavGridselected_Titleformat = (short)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         chkavGridselected.Title.Text = GetNextPar( );
         AssignProp(sPrefix, false, chkavGridselected_Internalname, "Title", chkavGridselected.Title.Text, !bGXsfl_18_Refreshing);
         AV12MedidaNombreCompleto = GetPar( "MedidaNombreCompleto");
         AV21MedidaID = (int)(Math.Round(NumberUtil.Val( GetPar( "MedidaID"), "."), 18, MidpointRounding.ToEven));
         AV16Cantidad = (short)(Math.Round(NumberUtil.Val( GetPar( "Cantidad"), "."), 18, MidpointRounding.ToEven));
         edtavCantidad_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavCantidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCantidad_Enabled), 5, 0), !bGXsfl_18_Refreshing);
         AV17Precio = NumberUtil.Val( GetPar( "Precio"), ".");
         edtavPrecio_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPrecio_Enabled), 5, 0), !bGXsfl_18_Refreshing);
         AV13GridSelected = StringUtil.StrToBool( GetPar( "GridSelected"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11WizardData);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12MedidaNombreCompleto, AV21MedidaID, AV16Cantidad, AV17Precio, AV13GridSelected, AV11WizardData, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            PA2X2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavMedidanombrecompleto_Enabled = 0;
               AssignProp(sPrefix, false, edtavMedidanombrecompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMedidanombrecompleto_Enabled), 5, 0), !bGXsfl_18_Refreshing);
               edtavMedidaid_Enabled = 0;
               AssignProp(sPrefix, false, edtavMedidaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMedidaid_Enabled), 5, 0), !bGXsfl_18_Refreshing);
               WS2X2( ) ;
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
            context.SendWebValue( context.GetMessage( "WPFactura Wizard Selec Medidas", "")) ;
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
            GXEncryptionTmp = "wpfacturawizardselecmedidas.aspx"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpfacturawizardselecmedidas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_18", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_18), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"FACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"FACTURACOMPLETA", A93FacturaCompleta);
         GxWebStd.gx_hidden_field( context, sPrefix+"FACTURAMEDIDAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A77FacturaMedidaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSELECTED_Titleformat", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavGridselected_Titleformat), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDSELECTED_Title", StringUtil.RTrim( chkavGridselected.Title.Text));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCANTIDAD_Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCantidad_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPRECIO_Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPrecio_Enabled), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm2X2( )
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
         return "WPFacturaWizardSelecMedidas" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WPFactura Wizard Selec Medidas", "") ;
      }

      protected void WB2X0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpfacturawizardselecmedidas.aspx");
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableWithSelectableGrid", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegrid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl18( ) ;
         }
         if ( wbEnd == 18 )
         {
            wbEnd = 0;
            nRC_GXsfl_18 = (int)(nGXsfl_18_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 18 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2X2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WPFactura Wizard Selec Medidas", ""), 0) ;
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
               STRUP2X0( ) ;
            }
         }
      }

      protected void WS2X2( )
      {
         START2X2( ) ;
         EVT2X2( ) ;
      }

      protected void EVT2X2( )
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
                                 STRUP2X0( ) ;
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
                                 STRUP2X0( ) ;
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
                                          E112X2 ();
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
                                 STRUP2X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E122X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavGridselected_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2X0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2X0( ) ;
                              }
                              nGXsfl_18_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
                              SubsflControlProps_182( ) ;
                              AV13GridSelected = StringUtil.StrToBool( cgiGet( chkavGridselected_Internalname));
                              AssignAttri(sPrefix, false, chkavGridselected_Internalname, AV13GridSelected);
                              AV12MedidaNombreCompleto = cgiGet( edtavMedidanombrecompleto_Internalname);
                              AssignAttri(sPrefix, false, edtavMedidanombrecompleto_Internalname, AV12MedidaNombreCompleto);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vMEDIDANOMBRECOMPLETO"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, StringUtil.RTrim( context.localUtil.Format( AV12MedidaNombreCompleto, "")), context));
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCANTIDAD");
                                 GX_FocusControl = edtavCantidad_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV16Cantidad = 0;
                                 AssignAttri(sPrefix, false, edtavCantidad_Internalname, StringUtil.LTrimStr( (decimal)(AV16Cantidad), 4, 0));
                              }
                              else
                              {
                                 AV16Cantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavCantidad_Internalname, StringUtil.LTrimStr( (decimal)(AV16Cantidad), 4, 0));
                              }
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 9999999.99m ) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRECIO");
                                 GX_FocusControl = edtavPrecio_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV17Precio = 0;
                                 AssignAttri(sPrefix, false, edtavPrecio_Internalname, StringUtil.LTrimStr( AV17Precio, 10, 2));
                              }
                              else
                              {
                                 AV17Precio = context.localUtil.CToN( cgiGet( edtavPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                                 AssignAttri(sPrefix, false, edtavPrecio_Internalname, StringUtil.LTrimStr( AV17Precio, 10, 2));
                              }
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavMedidaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMedidaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMEDIDAID");
                                 GX_FocusControl = edtavMedidaid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV21MedidaID = 0;
                                 AssignAttri(sPrefix, false, edtavMedidaid_Internalname, StringUtil.LTrimStr( (decimal)(AV21MedidaID), 9, 0));
                                 GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vMEDIDAID"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, context.localUtil.Format( (decimal)(AV21MedidaID), "ZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV21MedidaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavMedidaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavMedidaid_Internalname, StringUtil.LTrimStr( (decimal)(AV21MedidaID), 9, 0));
                                 GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vMEDIDAID"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, context.localUtil.Format( (decimal)(AV21MedidaID), "ZZZZZZZZ9"), context));
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
                                          GX_FocusControl = chkavGridselected_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E132X2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavGridselected_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E142X2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP2X0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavGridselected_Internalname;
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

      protected void WE2X2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2X2( ) ;
            }
         }
      }

      protected void PA2X2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpfacturawizardselecmedidas.aspx")), "wpfacturawizardselecmedidas.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpfacturawizardselecmedidas.aspx")))) ;
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_182( ) ;
         while ( nGXsfl_18_idx <= nRC_GXsfl_18 )
         {
            sendrow_182( ) ;
            nGXsfl_18_idx = ((subGrid_Islastpage==1)&&(nGXsfl_18_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_18_idx+1);
            sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
            SubsflControlProps_182( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV12MedidaNombreCompleto ,
                                       int AV21MedidaID ,
                                       short AV16Cantidad ,
                                       decimal AV17Precio ,
                                       bool AV13GridSelected ,
                                       SdtWPFacturaWizardData AV11WizardData ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2X2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vMEDIDANOMBRECOMPLETO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV12MedidaNombreCompleto, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMEDIDANOMBRECOMPLETO", AV12MedidaNombreCompleto);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vMEDIDAID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV21MedidaID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMEDIDAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21MedidaID), 9, 0, ".", "")));
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
         RF2X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavMedidanombrecompleto_Enabled = 0;
         edtavMedidaid_Enabled = 0;
      }

      protected void RF2X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 18;
         nGXsfl_18_idx = 1;
         sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
         SubsflControlProps_182( ) ;
         bGXsfl_18_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridNoBorder WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_182( ) ;
            /* Execute user event: Grid.Load */
            E142X2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_18_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E142X2 ();
            }
            wbEnd = 18;
            WB2X0( ) ;
         }
         bGXsfl_18_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2X2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vMEDIDANOMBRECOMPLETO"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, StringUtil.RTrim( context.localUtil.Format( AV12MedidaNombreCompleto, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vMEDIDAID"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, context.localUtil.Format( (decimal)(AV21MedidaID), "ZZZZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(((subGrid_Recordcount==0) ? GRID_nFirstRecordOnPage+1 : subGrid_Recordcount)) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(((subGrid_Islastpage==1) ? NumberUtil.Int( (long)(Math.Round(subGrid_fnc_Recordcount( )/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+((((int)((subGrid_fnc_Recordcount( )) % (subGrid_fnc_Recordsperpage( ))))==0) ? 0 : 1) : NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1)) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12MedidaNombreCompleto, AV21MedidaID, AV16Cantidad, AV17Precio, AV13GridSelected, AV11WizardData, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12MedidaNombreCompleto, AV21MedidaID, AV16Cantidad, AV17Precio, AV13GridSelected, AV11WizardData, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12MedidaNombreCompleto, AV21MedidaID, AV16Cantidad, AV17Precio, AV13GridSelected, AV11WizardData, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12MedidaNombreCompleto, AV21MedidaID, AV16Cantidad, AV17Precio, AV13GridSelected, AV11WizardData, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12MedidaNombreCompleto, AV21MedidaID, AV16Cantidad, AV17Precio, AV13GridSelected, AV11WizardData, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavMedidanombrecompleto_Enabled = 0;
         edtavMedidaid_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E132X2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_18 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_18"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subGrid_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
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
         E132X2 ();
         if (returnInSub) return;
      }

      protected void E132X2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         if ( AV7GoingBack && ( StringUtil.StrCmp(AV8PreviousStep, "Resumen") == 0 ) )
         {
            Btnwizardnext_Caption = context.GetMessage( "WWP_WizardReturnToSummary", "");
            ucBtnwizardnext.SendProperty(context, sPrefix, false, Btnwizardnext_Internalname, "Caption", Btnwizardnext_Caption);
         }
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         subGrid_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         chkavGridselected_Titleformat = 1;
         chkavGridselected.Title.Text = StringUtil.Format( "<input name=\"selectAllCheckboxGrid\" type=\"checkbox\" value=\"Select All\" onClick=\"WWPSelectAll(this, %1);\" onMouseOver=\"WWPSelectAllRemoveParentOnClick(this)\" class=\"AttributeCheckBox\" >", "'GRIDSELECTED'", "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, chkavGridselected_Internalname, "Title", chkavGridselected.Title.Text, !bGXsfl_18_Refreshing);
         AV15ModeloID = AV11WizardData.gxTpr_Selecpromo.gxTpr_Modeloid;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A22ModeloID ,
                                              AV15ModeloID } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         /* Using cursor H002X2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A22ModeloID = H002X2_A22ModeloID[0];
            A26MedidaID = H002X2_A26MedidaID[0];
            A23ModeloDescripcion = H002X2_A23ModeloDescripcion[0];
            A27MedidaCodigo = H002X2_A27MedidaCodigo[0];
            A28MedidaDescripcion = H002X2_A28MedidaDescripcion[0];
            A23ModeloDescripcion = H002X2_A23ModeloDescripcion[0];
            A76MedidaNombreCompleto = StringUtil.Trim( A23ModeloDescripcion) + " / " + StringUtil.Trim( A28MedidaDescripcion) + " / " + StringUtil.Trim( A27MedidaCodigo);
            AssignAttri(sPrefix, false, "A76MedidaNombreCompleto", A76MedidaNombreCompleto);
            AV12MedidaNombreCompleto = A76MedidaNombreCompleto;
            AssignAttri(sPrefix, false, edtavMedidanombrecompleto_Internalname, AV12MedidaNombreCompleto);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vMEDIDANOMBRECOMPLETO"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, StringUtil.RTrim( context.localUtil.Format( AV12MedidaNombreCompleto, "")), context));
            AV21MedidaID = A26MedidaID;
            AssignAttri(sPrefix, false, edtavMedidaid_Internalname, StringUtil.LTrimStr( (decimal)(AV21MedidaID), 9, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vMEDIDAID"+"_"+sGXsfl_18_idx, GetSecureSignedToken( sPrefix+sGXsfl_18_idx, context.localUtil.Format( (decimal)(AV21MedidaID), "ZZZZZZZZ9"), context));
            AV19EstaGuardado = false;
            AV39GXV1 = 1;
            while ( AV39GXV1 <= AV11WizardData.gxTpr_Selecmedidas.gxTpr_Grid.Count )
            {
               AV20MedidaRow = ((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV11WizardData.gxTpr_Selecmedidas.gxTpr_Grid.Item(AV39GXV1));
               if ( AV20MedidaRow.gxTpr_Medidaid == AV21MedidaID )
               {
                  AV16Cantidad = AV20MedidaRow.gxTpr_Cantidad;
                  AssignAttri(sPrefix, false, edtavCantidad_Internalname, StringUtil.LTrimStr( (decimal)(AV16Cantidad), 4, 0));
                  edtavCantidad_Enabled = 1;
                  AssignProp(sPrefix, false, edtavCantidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCantidad_Enabled), 5, 0), !bGXsfl_18_Refreshing);
                  AV17Precio = AV20MedidaRow.gxTpr_Precio;
                  AssignAttri(sPrefix, false, edtavPrecio_Internalname, StringUtil.LTrimStr( AV17Precio, 10, 2));
                  edtavPrecio_Enabled = 1;
                  AssignProp(sPrefix, false, edtavPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPrecio_Enabled), 5, 0), !bGXsfl_18_Refreshing);
                  AV13GridSelected = true;
                  AssignAttri(sPrefix, false, chkavGridselected_Internalname, AV13GridSelected);
                  AV19EstaGuardado = true;
                  if (true) break;
               }
               AV39GXV1 = (int)(AV39GXV1+1);
            }
            if ( ! AV19EstaGuardado )
            {
               AV16Cantidad = 0;
               AssignAttri(sPrefix, false, edtavCantidad_Internalname, StringUtil.LTrimStr( (decimal)(AV16Cantidad), 4, 0));
               edtavCantidad_Enabled = 0;
               AssignProp(sPrefix, false, edtavCantidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCantidad_Enabled), 5, 0), !bGXsfl_18_Refreshing);
               AV17Precio = 0;
               AssignAttri(sPrefix, false, edtavPrecio_Internalname, StringUtil.LTrimStr( AV17Precio, 10, 2));
               edtavPrecio_Enabled = 0;
               AssignProp(sPrefix, false, edtavPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPrecio_Enabled), 5, 0), !bGXsfl_18_Refreshing);
               AV13GridSelected = false;
               AssignAttri(sPrefix, false, chkavGridselected_Internalname, AV13GridSelected);
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_182( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            subGrid_Recordcount = (int)(GRID_nCurrentRecord);
            if ( isFullAjaxMode( ) && ! bGXsfl_18_Refreshing )
            {
               DoAjaxLoad(18, GridRow);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      private void E142X2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV13GridSelected = false;
         AssignAttri(sPrefix, false, chkavGridselected_Internalname, AV13GridSelected);
         AV16Cantidad = 0;
         AssignAttri(sPrefix, false, edtavCantidad_Internalname, StringUtil.LTrimStr( (decimal)(AV16Cantidad), 4, 0));
         AV17Precio = 0;
         AssignAttri(sPrefix, false, edtavPrecio_Internalname, StringUtil.LTrimStr( AV17Precio, 10, 2));
         AV40GXV2 = 1;
         while ( AV40GXV2 <= AV11WizardData.gxTpr_Selecmedidas.gxTpr_Grid.Count )
         {
            AV14GridSelectedRow = ((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV11WizardData.gxTpr_Selecmedidas.gxTpr_Grid.Item(AV40GXV2));
            if ( ( StringUtil.StrCmp(AV14GridSelectedRow.gxTpr_Medidanombrecompleto, AV12MedidaNombreCompleto) == 0 ) && ( AV14GridSelectedRow.gxTpr_Medidaid == AV21MedidaID ) )
            {
               AV13GridSelected = true;
               AssignAttri(sPrefix, false, chkavGridselected_Internalname, AV13GridSelected);
               AV16Cantidad = AV14GridSelectedRow.gxTpr_Cantidad;
               AssignAttri(sPrefix, false, edtavCantidad_Internalname, StringUtil.LTrimStr( (decimal)(AV16Cantidad), 4, 0));
               AV17Precio = AV14GridSelectedRow.gxTpr_Precio;
               AssignAttri(sPrefix, false, edtavPrecio_Internalname, StringUtil.LTrimStr( AV17Precio, 10, 2));
               if (true) break;
            }
            AV40GXV2 = (int)(AV40GXV2+1);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E112X2 ();
         if (returnInSub) return;
      }

      protected void E112X2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV24ValidaWWP = false;
         if ( AV24ValidaWWP )
         {
            /* Execute user subroutine: 'VALIDARFILASSELECCIONADAS' */
            S122 ();
            if (returnInSub) return;
            if ( ! AV10HasValidationErrors )
            {
               /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
               S132 ();
               if (returnInSub) return;
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                  {
                     gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                  }
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "wpfacturawizard.aspx"+UrlEncode(StringUtil.RTrim("SelecMedidas")) + "," + UrlEncode(StringUtil.RTrim("Resumen")) + "," + UrlEncode(StringUtil.BoolToStr(false));
               CallWebObject(formatLink("wpfacturawizard.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
         }
         else
         {
            /* Execute user subroutine: 'VALIDARFILASSELECCIONADAS' */
            S122 ();
            if (returnInSub) return;
            if ( ! AV10HasValidationErrors )
            {
               /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
               S132 ();
               if (returnInSub) return;
               /* Execute user subroutine: 'GUARDARMEDIDASFACTURA' */
               S142 ();
               if (returnInSub) return;
               if ( ! AV10HasValidationErrors )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                     {
                        gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                     }
                  }
                  GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                  GXEncryptionTmp = "wpfacturawizard.aspx"+UrlEncode(StringUtil.RTrim("SelecMedidas")) + "," + UrlEncode(StringUtil.RTrim("Resumen")) + "," + UrlEncode(StringUtil.BoolToStr(false));
                  CallWebObject(formatLink("wpfacturawizard.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
                  context.wjLocDisableFrm = 1;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E122X2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S132 ();
         if (returnInSub) return;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpfacturawizard.aspx"+UrlEncode(StringUtil.RTrim("SelecMedidas")) + "," + UrlEncode(StringUtil.RTrim("SelecPromo")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wpfacturawizard.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void S152( )
      {
         /* 'LOADGRIDSELECTEDROWS' Routine */
         returnInSub = false;
         AV11WizardData.gxTpr_Selecmedidas.gxTpr_Grid.Clear();
         /* Start For Each Line in Grid */
         nRC_GXsfl_18 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_18"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         nGXsfl_18_fel_idx = 0;
         while ( nGXsfl_18_fel_idx < nRC_GXsfl_18 )
         {
            nGXsfl_18_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_18_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_18_fel_idx+1);
            sGXsfl_18_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_182( ) ;
            AV13GridSelected = StringUtil.StrToBool( cgiGet( chkavGridselected_Internalname));
            AV12MedidaNombreCompleto = cgiGet( edtavMedidanombrecompleto_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCANTIDAD");
               GX_FocusControl = edtavCantidad_Internalname;
               wbErr = true;
               AV16Cantidad = 0;
            }
            else
            {
               AV16Cantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRECIO");
               GX_FocusControl = edtavPrecio_Internalname;
               wbErr = true;
               AV17Precio = 0;
            }
            else
            {
               AV17Precio = context.localUtil.CToN( cgiGet( edtavPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMedidaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMedidaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMEDIDAID");
               GX_FocusControl = edtavMedidaid_Internalname;
               wbErr = true;
               AV21MedidaID = 0;
            }
            else
            {
               AV21MedidaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavMedidaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            if ( AV13GridSelected )
            {
               AV14GridSelectedRow = new SdtWPFacturaWizardData_SelecMedidas_GridItem(context);
               AV14GridSelectedRow.gxTpr_Medidanombrecompleto = AV12MedidaNombreCompleto;
               AV14GridSelectedRow.gxTpr_Cantidad = AV16Cantidad;
               AV14GridSelectedRow.gxTpr_Precio = AV17Precio;
               AV14GridSelectedRow.gxTpr_Medidaid = AV21MedidaID;
               AV11WizardData.gxTpr_Selecmedidas.gxTpr_Grid.Add(AV14GridSelectedRow, 0);
            }
            /* End For Each Line */
         }
         if ( nGXsfl_18_fel_idx == 0 )
         {
            nGXsfl_18_idx = 1;
            sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
            SubsflControlProps_182( ) ;
         }
         nGXsfl_18_fel_idx = 1;
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         /* Execute user subroutine: 'LOADGRIDSELECTEDROWS' */
         S152 ();
         if (returnInSub) return;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S122( )
      {
         /* 'VALIDARFILASSELECCIONADAS' Routine */
         returnInSub = false;
         AV10HasValidationErrors = false;
         AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
         AV18TieneSeleccion = false;
         /* Start For Each Line in Grid */
         nRC_GXsfl_18 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_18"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         nGXsfl_18_fel_idx = 0;
         while ( nGXsfl_18_fel_idx < nRC_GXsfl_18 )
         {
            nGXsfl_18_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_18_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_18_fel_idx+1);
            sGXsfl_18_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_182( ) ;
            AV13GridSelected = StringUtil.StrToBool( cgiGet( chkavGridselected_Internalname));
            AV12MedidaNombreCompleto = cgiGet( edtavMedidanombrecompleto_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCANTIDAD");
               GX_FocusControl = edtavCantidad_Internalname;
               wbErr = true;
               AV16Cantidad = 0;
            }
            else
            {
               AV16Cantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRECIO");
               GX_FocusControl = edtavPrecio_Internalname;
               wbErr = true;
               AV17Precio = 0;
            }
            else
            {
               AV17Precio = context.localUtil.CToN( cgiGet( edtavPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMedidaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMedidaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMEDIDAID");
               GX_FocusControl = edtavMedidaid_Internalname;
               wbErr = true;
               AV21MedidaID = 0;
            }
            else
            {
               AV21MedidaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavMedidaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            if ( AV13GridSelected )
            {
               AV18TieneSeleccion = true;
               if ( (0==AV16Cantidad) )
               {
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "El campo Cantidad es requerido", ""),  "error",  edtavCantidad_Internalname,  "true",  ""));
                  AV10HasValidationErrors = true;
                  AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               if ( (Convert.ToDecimal(0)==AV17Precio) )
               {
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "El campo Precio Unitario es requerido", ""),  "error",  edtavPrecio_Internalname,  "true",  ""));
                  AV10HasValidationErrors = true;
                  AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               if ( AV16Cantidad <= 0 )
               {
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "La cantidad debe ser mayor a cero", ""),  "error",  edtavCantidad_Internalname,  "true",  ""));
                  AV10HasValidationErrors = true;
                  AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               if ( ( AV17Precio <= Convert.ToDecimal( 0 )) )
               {
                  GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "El precio unitario debe ser mayor a cero", ""),  "error",  edtavPrecio_Internalname,  "true",  ""));
                  AV10HasValidationErrors = true;
                  AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            /* End For Each Line */
         }
         if ( nGXsfl_18_fel_idx == 0 )
         {
            nGXsfl_18_idx = 1;
            sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
            SubsflControlProps_182( ) ;
         }
         nGXsfl_18_fel_idx = 1;
         if ( ! AV18TieneSeleccion && ! AV10HasValidationErrors )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Debe seleccionar al menos una medida", ""),  "error",  subGrid_Internalname,  "true",  ""));
            AV10HasValidationErrors = true;
            AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
         }
      }

      protected void S142( )
      {
         /* 'GUARDARMEDIDASFACTURA' Routine */
         returnInSub = false;
         AV30GuardarMedidasOK = true;
         AV33FacturaExiste = false;
         AV37FacturaCompletaAux = false;
         AV31FacturaIDTexto = AV5WebSession.Get(context.GetMessage( "FacturaWizardID", ""));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV31FacturaIDTexto)) )
         {
            GX_msglist.addItem(context.GetMessage( "No se encontró la factura temporal. Vuelve a registrar la factura desde el inicio.", ""));
            AV10HasValidationErrors = true;
            AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
            AV30GuardarMedidasOK = false;
         }
         else
         {
            AV32FacturaID = (int)(Math.Round(NumberUtil.Val( AV31FacturaIDTexto, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV32FacturaID", StringUtil.LTrimStr( (decimal)(AV32FacturaID), 9, 0));
            if ( (0==AV32FacturaID) )
            {
               GX_msglist.addItem(context.GetMessage( "No se encontró la factura temporal. Vuelve a registrar la factura desde el inicio.", ""));
               AV10HasValidationErrors = true;
               AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
               AV30GuardarMedidasOK = false;
            }
         }
         if ( AV30GuardarMedidasOK )
         {
            /* Using cursor H002X3 */
            pr_default.execute(1, new Object[] {AV32FacturaID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A69FacturaID = H002X3_A69FacturaID[0];
               A93FacturaCompleta = H002X3_A93FacturaCompleta[0];
               AV33FacturaExiste = true;
               AV37FacturaCompletaAux = A93FacturaCompleta;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( ! AV33FacturaExiste )
            {
               GX_msglist.addItem(context.GetMessage( "La factura temporal no existe. Vuelve a registrar la factura desde el inicio.", ""));
               AV10HasValidationErrors = true;
               AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
               AV30GuardarMedidasOK = false;
            }
            else
            {
               if ( AV37FacturaCompletaAux )
               {
                  GX_msglist.addItem(context.GetMessage( "La factura temporal ya fue finalizada. Vuelve a registrar la factura desde el inicio.", ""));
                  AV10HasValidationErrors = true;
                  AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
                  AV30GuardarMedidasOK = false;
               }
            }
         }
         if ( AV30GuardarMedidasOK )
         {
            AV35FacturaMedidaIDCollection.Clear();
            /* Using cursor H002X4 */
            pr_default.execute(2, new Object[] {AV32FacturaID});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A69FacturaID = H002X4_A69FacturaID[0];
               A77FacturaMedidaID = H002X4_A77FacturaMedidaID[0];
               AV35FacturaMedidaIDCollection.Add(A77FacturaMedidaID, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV46GXV3 = 1;
            while ( AV46GXV3 <= AV35FacturaMedidaIDCollection.Count )
            {
               AV34FacturaMedidaID = (int)(AV35FacturaMedidaIDCollection.GetNumeric(AV46GXV3));
               AV26FacturaMedida.Load(AV34FacturaMedidaID);
               AV26FacturaMedida.Delete();
               if ( AV26FacturaMedida.Fail() )
               {
                  context.RollbackDataStores("wpfacturawizardselecmedidas",pr_default);
                  GX_msglist.addItem(context.GetMessage( "Error al limpiar las medidas anteriores de la factura.", ""));
                  AV27Messages = AV26FacturaMedida.GetMessages();
                  AV47GXV4 = 1;
                  while ( AV47GXV4 <= AV27Messages.Count )
                  {
                     AV29Message = ((GeneXus.Utils.SdtMessages_Message)AV27Messages.Item(AV47GXV4));
                     GX_msglist.addItem(AV29Message.gxTpr_Description);
                     AV47GXV4 = (int)(AV47GXV4+1);
                  }
                  AV10HasValidationErrors = true;
                  AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
                  AV30GuardarMedidasOK = false;
                  if (true) break;
               }
               AV46GXV3 = (int)(AV46GXV3+1);
            }
         }
         if ( AV30GuardarMedidasOK )
         {
            AV48GXV5 = 1;
            while ( AV48GXV5 <= AV11WizardData.gxTpr_Selecmedidas.gxTpr_Grid.Count )
            {
               AV14GridSelectedRow = ((SdtWPFacturaWizardData_SelecMedidas_GridItem)AV11WizardData.gxTpr_Selecmedidas.gxTpr_Grid.Item(AV48GXV5));
               AV26FacturaMedida = new SdtFacturaMedida(context);
               AV26FacturaMedida.gxTpr_Facturaid = AV32FacturaID;
               AV26FacturaMedida.gxTpr_Medidaid = AV14GridSelectedRow.gxTpr_Medidaid;
               AV26FacturaMedida.gxTpr_Facturamedidacantidad = AV14GridSelectedRow.gxTpr_Cantidad;
               AV26FacturaMedida.gxTpr_Facturamedidaprecio = AV14GridSelectedRow.gxTpr_Precio;
               AV26FacturaMedida.Save();
               if ( AV26FacturaMedida.Fail() )
               {
                  context.RollbackDataStores("wpfacturawizardselecmedidas",pr_default);
                  GX_msglist.addItem(context.GetMessage( "Error al guardar una medida de la factura.", ""));
                  AV27Messages = AV26FacturaMedida.GetMessages();
                  AV49GXV6 = 1;
                  while ( AV49GXV6 <= AV27Messages.Count )
                  {
                     AV29Message = ((GeneXus.Utils.SdtMessages_Message)AV27Messages.Item(AV49GXV6));
                     GX_msglist.addItem(AV29Message.gxTpr_Description);
                     AV49GXV6 = (int)(AV49GXV6+1);
                  }
                  AV10HasValidationErrors = true;
                  AssignAttri(sPrefix, false, "AV10HasValidationErrors", AV10HasValidationErrors);
                  AV30GuardarMedidasOK = false;
                  if (true) break;
               }
               AV48GXV5 = (int)(AV48GXV5+1);
            }
         }
         if ( AV30GuardarMedidasOK )
         {
            context.CommitDataStores("wpfacturawizardselecmedidas",pr_default);
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
         PA2X2( ) ;
         WS2X2( ) ;
         WE2X2( ) ;
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
         PA2X2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpfacturawizardselecmedidas", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2X2( ) ;
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
         PA2X2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2X2( ) ;
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
         WS2X2( ) ;
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
         WE2X2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202651111305719", true, true);
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
         context.AddJavascriptSource("wpfacturawizardselecmedidas.js", "?202651111305719", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_182( )
      {
         chkavGridselected_Internalname = sPrefix+"vGRIDSELECTED_"+sGXsfl_18_idx;
         edtavMedidanombrecompleto_Internalname = sPrefix+"vMEDIDANOMBRECOMPLETO_"+sGXsfl_18_idx;
         edtavCantidad_Internalname = sPrefix+"vCANTIDAD_"+sGXsfl_18_idx;
         edtavPrecio_Internalname = sPrefix+"vPRECIO_"+sGXsfl_18_idx;
         edtavMedidaid_Internalname = sPrefix+"vMEDIDAID_"+sGXsfl_18_idx;
      }

      protected void SubsflControlProps_fel_182( )
      {
         chkavGridselected_Internalname = sPrefix+"vGRIDSELECTED_"+sGXsfl_18_fel_idx;
         edtavMedidanombrecompleto_Internalname = sPrefix+"vMEDIDANOMBRECOMPLETO_"+sGXsfl_18_fel_idx;
         edtavCantidad_Internalname = sPrefix+"vCANTIDAD_"+sGXsfl_18_fel_idx;
         edtavPrecio_Internalname = sPrefix+"vPRECIO_"+sGXsfl_18_fel_idx;
         edtavMedidaid_Internalname = sPrefix+"vMEDIDAID_"+sGXsfl_18_fel_idx;
      }

      protected void sendrow_182( )
      {
         sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
         SubsflControlProps_182( ) ;
         WB2X0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_18_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_18_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridNoBorder WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_18_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "vGRIDSELECTED_" + sGXsfl_18_idx;
            chkavGridselected.Name = GXCCtl;
            chkavGridselected.WebTags = "";
            chkavGridselected.Caption = "";
            AssignProp(sPrefix, false, chkavGridselected_Internalname, "TitleCaption", chkavGridselected.Caption, !bGXsfl_18_Refreshing);
            chkavGridselected.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavGridselected_Internalname,StringUtil.BoolToStr( AV13GridSelected),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(19, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,19);\""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMedidanombrecompleto_Internalname,(string)AV12MedidaNombreCompleto,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMedidanombrecompleto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavMedidanombrecompleto_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)18,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16Cantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16Cantidad), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,21);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCantidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavCantidad_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)18,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'" + sGXsfl_18_idx + "',18)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( AV17Precio, 14, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( AV17Precio, "$ Z,ZZZ,ZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,22);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavPrecio_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)18,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMedidaid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21MedidaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavMedidaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV21MedidaID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV21MedidaID), "ZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMedidaid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavMedidaid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)18,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes2X2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_18_idx = ((subGrid_Islastpage==1)&&(nGXsfl_18_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_18_idx+1);
            sGXsfl_18_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_18_idx), 4, 0), 4, "0");
            SubsflControlProps_182( ) ;
         }
         /* End function sendrow_182 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vGRIDSELECTED_" + sGXsfl_18_idx;
         chkavGridselected.Name = GXCCtl;
         chkavGridselected.WebTags = "";
         chkavGridselected.Caption = "";
         AssignProp(sPrefix, false, chkavGridselected_Internalname, "TitleCaption", chkavGridselected.Caption, !bGXsfl_18_Refreshing);
         chkavGridselected.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl18( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"18\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridNoBorder WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
            if ( chkavGridselected_Titleformat == 0 )
            {
               context.SendWebValue( chkavGridselected.Title.Text) ;
            }
            else
            {
               context.WriteHtmlText( chkavGridselected.Title.Text) ;
            }
            context.WriteHtmlTextNl( "</th>") ;
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
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridNoBorder WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV13GridSelected)));
            GridColumn.AddObjectProperty("Title", StringUtil.RTrim( chkavGridselected.Title.Text));
            GridColumn.AddObjectProperty("Titleformat", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavGridselected_Titleformat), 4, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV12MedidaNombreCompleto));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMedidanombrecompleto_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16Cantidad), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCantidad_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( AV17Precio, 14, 2, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPrecio_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21MedidaID), 9, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMedidaid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         chkavGridselected_Internalname = sPrefix+"vGRIDSELECTED";
         edtavMedidanombrecompleto_Internalname = sPrefix+"vMEDIDANOMBRECOMPLETO";
         edtavCantidad_Internalname = sPrefix+"vCANTIDAD";
         edtavPrecio_Internalname = sPrefix+"vPRECIO";
         edtavMedidaid_Internalname = sPrefix+"vMEDIDAID";
         divTablegrid_Internalname = sPrefix+"TABLEGRID";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavMedidaid_Jsonclick = "";
         edtavMedidaid_Enabled = 1;
         edtavPrecio_Jsonclick = "";
         edtavCantidad_Jsonclick = "";
         edtavMedidanombrecompleto_Jsonclick = "";
         edtavMedidanombrecompleto_Enabled = 1;
         chkavGridselected.Caption = "";
         subGrid_Class = "GridNoBorder WorkWith";
         subGrid_Backcolorstyle = 0;
         Btnwizardnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardnext_Caption = context.GetMessage( "GXM_next", "");
         Btnwizardnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardnext_Tooltiptext = "";
         Btnwizardprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardprevious_Caption = context.GetMessage( "GXM_previous", "");
         Btnwizardprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardprevious_Tooltiptext = "";
         chkavGridselected_Titleformat = 0;
         edtavPrecio_Enabled = 1;
         edtavCantidad_Enabled = 1;
         chkavGridselected.Title.Text = "";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"chkavGridselected_Titleformat","ctrl":"vGRIDSELECTED","prop":"Titleformat"},{"av":"chkavGridselected.Title.Text","ctrl":"vGRIDSELECTED","prop":"Title"},{"av":"AV12MedidaNombreCompleto","fld":"vMEDIDANOMBRECOMPLETO","hsh":true},{"av":"AV21MedidaID","fld":"vMEDIDAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV16Cantidad","fld":"vCANTIDAD","pic":"ZZZ9"},{"av":"edtavCantidad_Enabled","ctrl":"vCANTIDAD","prop":"Enabled"},{"av":"AV17Precio","fld":"vPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"edtavPrecio_Enabled","ctrl":"vPRECIO","prop":"Enabled"},{"av":"AV13GridSelected","fld":"vGRIDSELECTED"},{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"sPrefix"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E142X2","iparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"AV12MedidaNombreCompleto","fld":"vMEDIDANOMBRECOMPLETO","hsh":true},{"av":"AV21MedidaID","fld":"vMEDIDAID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV13GridSelected","fld":"vGRIDSELECTED"},{"av":"AV16Cantidad","fld":"vCANTIDAD","pic":"ZZZ9"},{"av":"AV17Precio","fld":"vPRECIO","pic":"$ Z,ZZZ,ZZ9.99"}]}""");
         setEventMetadata("ENTER","""{"handler":"E112X2","iparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS"},{"av":"AV13GridSelected","fld":"vGRIDSELECTED","grid":18},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_18","ctrl":"GRID","grid":18,"prop":"GridRC","grid":18},{"av":"AV16Cantidad","fld":"vCANTIDAD","grid":18,"pic":"ZZZ9"},{"av":"AV17Precio","fld":"vPRECIO","grid":18,"pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV32FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"},{"av":"A77FacturaMedidaID","fld":"FACTURAMEDIDAID","pic":"ZZZZZZZZ9"},{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"AV12MedidaNombreCompleto","fld":"vMEDIDANOMBRECOMPLETO","grid":18,"hsh":true},{"av":"AV21MedidaID","fld":"vMEDIDAID","grid":18,"pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS"},{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"AV32FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E122X2","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"AV13GridSelected","fld":"vGRIDSELECTED","grid":18},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_18","ctrl":"GRID","grid":18,"prop":"GridRC","grid":18},{"av":"AV12MedidaNombreCompleto","fld":"vMEDIDANOMBRECOMPLETO","grid":18,"hsh":true},{"av":"AV16Cantidad","fld":"vCANTIDAD","grid":18,"pic":"ZZZ9"},{"av":"AV17Precio","fld":"vPRECIO","grid":18,"pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV21MedidaID","fld":"vMEDIDAID","grid":18,"pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"chkavGridselected_Titleformat","ctrl":"vGRIDSELECTED","prop":"Titleformat"},{"av":"chkavGridselected.Title.Text","ctrl":"vGRIDSELECTED","prop":"Title"},{"av":"AV12MedidaNombreCompleto","fld":"vMEDIDANOMBRECOMPLETO","hsh":true},{"av":"AV21MedidaID","fld":"vMEDIDAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV16Cantidad","fld":"vCANTIDAD","pic":"ZZZ9"},{"av":"edtavCantidad_Enabled","ctrl":"vCANTIDAD","prop":"Enabled"},{"av":"AV17Precio","fld":"vPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"edtavPrecio_Enabled","ctrl":"vPRECIO","prop":"Enabled"},{"av":"AV13GridSelected","fld":"vGRIDSELECTED"},{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"sPrefix"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"chkavGridselected_Titleformat","ctrl":"vGRIDSELECTED","prop":"Titleformat"},{"av":"chkavGridselected.Title.Text","ctrl":"vGRIDSELECTED","prop":"Title"},{"av":"AV12MedidaNombreCompleto","fld":"vMEDIDANOMBRECOMPLETO","hsh":true},{"av":"AV21MedidaID","fld":"vMEDIDAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV16Cantidad","fld":"vCANTIDAD","pic":"ZZZ9"},{"av":"edtavCantidad_Enabled","ctrl":"vCANTIDAD","prop":"Enabled"},{"av":"AV17Precio","fld":"vPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"edtavPrecio_Enabled","ctrl":"vPRECIO","prop":"Enabled"},{"av":"AV13GridSelected","fld":"vGRIDSELECTED"},{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"sPrefix"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"chkavGridselected_Titleformat","ctrl":"vGRIDSELECTED","prop":"Titleformat"},{"av":"chkavGridselected.Title.Text","ctrl":"vGRIDSELECTED","prop":"Title"},{"av":"AV12MedidaNombreCompleto","fld":"vMEDIDANOMBRECOMPLETO","hsh":true},{"av":"AV21MedidaID","fld":"vMEDIDAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV16Cantidad","fld":"vCANTIDAD","pic":"ZZZ9"},{"av":"edtavCantidad_Enabled","ctrl":"vCANTIDAD","prop":"Enabled"},{"av":"AV17Precio","fld":"vPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"edtavPrecio_Enabled","ctrl":"vPRECIO","prop":"Enabled"},{"av":"AV13GridSelected","fld":"vGRIDSELECTED"},{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"sPrefix"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"chkavGridselected_Titleformat","ctrl":"vGRIDSELECTED","prop":"Titleformat"},{"av":"chkavGridselected.Title.Text","ctrl":"vGRIDSELECTED","prop":"Title"},{"av":"AV12MedidaNombreCompleto","fld":"vMEDIDANOMBRECOMPLETO","hsh":true},{"av":"AV21MedidaID","fld":"vMEDIDAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV16Cantidad","fld":"vCANTIDAD","pic":"ZZZ9"},{"av":"edtavCantidad_Enabled","ctrl":"vCANTIDAD","prop":"Enabled"},{"av":"AV17Precio","fld":"vPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"edtavPrecio_Enabled","ctrl":"vPRECIO","prop":"Enabled"},{"av":"AV13GridSelected","fld":"vGRIDSELECTED"},{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"sPrefix"},{"av":"subGrid_Recordcount"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Medidaid","iparms":[]}""");
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
         AV12MedidaNombreCompleto = "";
         AV11WizardData = new SdtWPFacturaWizardData(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         Grid_empowerer_Gridinternalname = "";
         AV15ModeloID = new GxSimpleCollection<int>();
         H002X2_A22ModeloID = new int[1] ;
         H002X2_A26MedidaID = new int[1] ;
         H002X2_A23ModeloDescripcion = new string[] {""} ;
         H002X2_A27MedidaCodigo = new string[] {""} ;
         H002X2_A28MedidaDescripcion = new string[] {""} ;
         A23ModeloDescripcion = "";
         A27MedidaCodigo = "";
         A28MedidaDescripcion = "";
         A76MedidaNombreCompleto = "";
         AV20MedidaRow = new SdtWPFacturaWizardData_SelecMedidas_GridItem(context);
         GridRow = new GXWebRow();
         AV14GridSelectedRow = new SdtWPFacturaWizardData_SelecMedidas_GridItem(context);
         AV5WebSession = context.GetSession();
         AV31FacturaIDTexto = "";
         H002X3_A69FacturaID = new int[1] ;
         H002X3_A93FacturaCompleta = new bool[] {false} ;
         AV35FacturaMedidaIDCollection = new GxSimpleCollection<int>();
         H002X4_A69FacturaID = new int[1] ;
         H002X4_A77FacturaMedidaID = new int[1] ;
         AV26FacturaMedida = new SdtFacturaMedida(context);
         AV27Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV29Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         subGrid_Linesclass = "";
         TempTags = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpfacturawizardselecmedidas__default(),
            new Object[][] {
                new Object[] {
               H002X2_A22ModeloID, H002X2_A26MedidaID, H002X2_A23ModeloDescripcion, H002X2_A27MedidaCodigo, H002X2_A28MedidaDescripcion
               }
               , new Object[] {
               H002X3_A69FacturaID, H002X3_A93FacturaCompleta
               }
               , new Object[] {
               H002X4_A69FacturaID, H002X4_A77FacturaMedidaID
               }
            }
         );
         /* GeneXus formulas. */
         edtavMedidanombrecompleto_Enabled = 0;
         edtavMedidaid_Enabled = 0;
      }

      private short chkavGridselected_Titleformat ;
      private short GRID_nEOF ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV16Cantidad ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int edtavCantidad_Enabled ;
      private int edtavPrecio_Enabled ;
      private int nRC_GXsfl_18 ;
      private int subGrid_Recordcount ;
      private int subGrid_Rows ;
      private int nGXsfl_18_idx=1 ;
      private int AV21MedidaID ;
      private int edtavMedidanombrecompleto_Enabled ;
      private int edtavMedidaid_Enabled ;
      private int A69FacturaID ;
      private int AV32FacturaID ;
      private int A77FacturaMedidaID ;
      private int subGrid_Islastpage ;
      private int GRID_nGridOutOfScope ;
      private int A22ModeloID ;
      private int A26MedidaID ;
      private int AV39GXV1 ;
      private int AV40GXV2 ;
      private int nGXsfl_18_fel_idx=1 ;
      private int AV46GXV3 ;
      private int AV34FacturaMedidaID ;
      private int AV47GXV4 ;
      private int AV48GXV5 ;
      private int AV49GXV6 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private decimal AV17Precio ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_18_idx="0001" ;
      private string chkavGridselected_Internalname ;
      private string edtavCantidad_Internalname ;
      private string edtavPrecio_Internalname ;
      private string edtavMedidanombrecompleto_Internalname ;
      private string edtavMedidaid_Internalname ;
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
      private string divTablefilters_Internalname ;
      private string divTablegrid_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardprevious_Tooltiptext ;
      private string Btnwizardprevious_Beforeiconclass ;
      private string Btnwizardprevious_Caption ;
      private string Btnwizardprevious_Class ;
      private string Btnwizardprevious_Internalname ;
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Aftericonclass ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Grid_empowerer_Gridinternalname ;
      private string A27MedidaCodigo ;
      private string sGXsfl_18_fel_idx="0001" ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string TempTags ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtavMedidanombrecompleto_Jsonclick ;
      private string edtavCantidad_Jsonclick ;
      private string edtavPrecio_Jsonclick ;
      private string edtavMedidaid_Jsonclick ;
      private string subGrid_Header ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_18_Refreshing=false ;
      private bool AV13GridSelected ;
      private bool AV10HasValidationErrors ;
      private bool A93FacturaCompleta ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV19EstaGuardado ;
      private bool AV24ValidaWWP ;
      private bool AV18TieneSeleccion ;
      private bool AV30GuardarMedidasOK ;
      private bool AV33FacturaExiste ;
      private bool AV37FacturaCompletaAux ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV12MedidaNombreCompleto ;
      private string A23ModeloDescripcion ;
      private string A28MedidaDescripcion ;
      private string A76MedidaNombreCompleto ;
      private string AV31FacturaIDTexto ;
      private IGxSession AV5WebSession ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavGridselected ;
      private SdtWPFacturaWizardData AV11WizardData ;
      private GxSimpleCollection<int> AV15ModeloID ;
      private IDataStoreProvider pr_default ;
      private int[] H002X2_A22ModeloID ;
      private int[] H002X2_A26MedidaID ;
      private string[] H002X2_A23ModeloDescripcion ;
      private string[] H002X2_A27MedidaCodigo ;
      private string[] H002X2_A28MedidaDescripcion ;
      private SdtWPFacturaWizardData_SelecMedidas_GridItem AV20MedidaRow ;
      private SdtWPFacturaWizardData_SelecMedidas_GridItem AV14GridSelectedRow ;
      private int[] H002X3_A69FacturaID ;
      private bool[] H002X3_A93FacturaCompleta ;
      private GxSimpleCollection<int> AV35FacturaMedidaIDCollection ;
      private int[] H002X4_A69FacturaID ;
      private int[] H002X4_A77FacturaMedidaID ;
      private SdtFacturaMedida AV26FacturaMedida ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV27Messages ;
      private GeneXus.Utils.SdtMessages_Message AV29Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpfacturawizardselecmedidas__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002X2( IGxContext context ,
                                             int A22ModeloID ,
                                             GxSimpleCollection<int> AV15ModeloID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object1 = new Object[2];
         scmdbuf = "SELECT T1.`ModeloID`, T1.`MedidaID`, T2.`ModeloDescripcion`, T1.`MedidaCodigo`, T1.`MedidaDescripcion` FROM (`Medida` T1 INNER JOIN `Modelo` T2 ON T2.`ModeloID` = T1.`ModeloID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV15ModeloID, "T1.`ModeloID` IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`MedidaID`";
         GXv_Object1[0] = scmdbuf;
         return GXv_Object1 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H002X2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] );
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
          Object[] prmH002X3;
          prmH002X3 = new Object[] {
          new ParDef("@AV32FacturaID",GXType.Int32,9,0)
          };
          Object[] prmH002X4;
          prmH002X4 = new Object[] {
          new ParDef("@AV32FacturaID",GXType.Int32,9,0)
          };
          Object[] prmH002X2;
          prmH002X2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H002X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002X2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H002X3", "SELECT `FacturaID`, `FacturaCompleta` FROM `Factura` WHERE `FacturaID` = @AV32FacturaID ORDER BY `FacturaID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002X3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002X4", "SELECT `FacturaID`, `FacturaMedidaID` FROM `FacturaMedida` WHERE `FacturaID` = @AV32FacturaID ORDER BY `FacturaID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002X4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
