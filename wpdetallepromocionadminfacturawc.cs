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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wpdetallepromocionadminfacturawc : GXWebComponent
   {
      public wpdetallepromocionadminfacturawc( )
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

      public wpdetallepromocionadminfacturawc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PromocionID )
      {
         this.AV7PromocionID = aP0_PromocionID;
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
         cmbFacturaEstatus = new GXCombobox();
         chkMotivoRechazoActivo = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "PromocionID");
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
                  AV7PromocionID = (int)(Math.Round(NumberUtil.Val( GetPar( "PromocionID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV7PromocionID", StringUtil.LTrimStr( (decimal)(AV7PromocionID), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV7PromocionID});
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
                  gxfirstwebparm = GetFirstPar( "PromocionID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "PromocionID");
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
         nRC_GXsfl_67 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_67"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_67_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_67_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_67_idx = GetPar( "sGXsfl_67_idx");
         sPrefix = GetPar( "sPrefix");
         edtavUseraction2_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_67_Refreshing);
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
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV100FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
         AV101ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
         AV15FilterFullText = GetPar( "FilterFullText");
         AV7PromocionID = (int)(Math.Round(NumberUtil.Val( GetPar( "PromocionID"), "."), 18, MidpointRounding.ToEven));
         AV19ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV120Pgmname = GetPar( "Pgmname");
         AV87TFFacturaFechaRegistro = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaRegistro"));
         AV88TFFacturaFechaRegistro_To = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaRegistro_To"));
         AV37TFPromocionDescripcion = GetPar( "TFPromocionDescripcion");
         AV38TFPromocionDescripcion_Sel = GetPar( "TFPromocionDescripcion_Sel");
         AV39TFFacturaNo = GetPar( "TFFacturaNo");
         AV40TFFacturaNo_Sel = GetPar( "TFFacturaNo_Sel");
         AV92TFFacturaFechaFactura = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaFactura"));
         AV93TFFacturaFechaFactura_To = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaFactura_To"));
         AV46TFEstatus = GetPar( "TFEstatus");
         AV47TFEstatusOperator = (short)(Math.Round(NumberUtil.Val( GetPar( "TFEstatusOperator"), "."), 18, MidpointRounding.ToEven));
         AV56TFUsuarioNombreCompleto = GetPar( "TFUsuarioNombreCompleto");
         AV57TFUsuarioNombreCompleto_Sel = GetPar( "TFUsuarioNombreCompleto_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV112DistribuidorID);
         A40UsuarioRol = GetPar( "UsuarioRol");
         A10DistribuidorID = (int)(Math.Round(NumberUtil.Val( GetPar( "DistribuidorID"), "."), 18, MidpointRounding.ToEven));
         edtavUseraction2_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_67_Refreshing);
         AV28Estatus = GetPar( "Estatus");
         A81DistribuidoresUsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "DistribuidoresUsuarioID"), "."), 18, MidpointRounding.ToEven));
         AV98RegUsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "RegUsuarioID"), "."), 18, MidpointRounding.ToEven));
         A11DistribuidorDescripcion = GetPar( "DistribuidorDescripcion");
         AV121Wpdetallepromocionadminfacturawcds_1_promocionid = (int)(Math.Round(NumberUtil.Val( GetPar( "Wpdetallepromocionadminfacturawcds_1_promocionid"), "."), 18, MidpointRounding.ToEven));
         AV119UsuarioCorreo = GetPar( "UsuarioCorreo");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV100FromDate, AV101ToDate, AV15FilterFullText, AV7PromocionID, AV19ManageFiltersExecutionStep, AV120Pgmname, AV87TFFacturaFechaRegistro, AV88TFFacturaFechaRegistro_To, AV37TFPromocionDescripcion, AV38TFPromocionDescripcion_Sel, AV39TFFacturaNo, AV40TFFacturaNo_Sel, AV92TFFacturaFechaFactura, AV93TFFacturaFechaFactura_To, AV46TFEstatus, AV47TFEstatusOperator, AV56TFUsuarioNombreCompleto, AV57TFUsuarioNombreCompleto_Sel, AV112DistribuidorID, A40UsuarioRol, A10DistribuidorID, AV28Estatus, A81DistribuidoresUsuarioID, AV98RegUsuarioID, A11DistribuidorDescripcion, AV121Wpdetallepromocionadminfacturawcds_1_promocionid, AV119UsuarioCorreo, sPrefix) ;
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
            PA3P2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV120Pgmname = "WPDetallePromocionAdminFacturaWC";
               edtavUseraction8_Enabled = 0;
               AssignProp(sPrefix, false, edtavUseraction8_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUseraction8_Enabled), 5, 0), !bGXsfl_67_Refreshing);
               edtavPartidaswithtags_Enabled = 0;
               AssignProp(sPrefix, false, edtavPartidaswithtags_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPartidaswithtags_Enabled), 5, 0), !bGXsfl_67_Refreshing);
               edtavPartidas_Enabled = 0;
               AssignProp(sPrefix, false, edtavPartidas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPartidas_Enabled), 5, 0), !bGXsfl_67_Refreshing);
               edtavUseraction2_Enabled = 0;
               AssignProp(sPrefix, false, edtavUseraction2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Enabled), 5, 0), !bGXsfl_67_Refreshing);
               edtavEstatuswithtags_Enabled = 0;
               AssignProp(sPrefix, false, edtavEstatuswithtags_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEstatuswithtags_Enabled), 5, 0), !bGXsfl_67_Refreshing);
               edtavEstatus_Enabled = 0;
               AssignProp(sPrefix, false, edtavEstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEstatus_Enabled), 5, 0), !bGXsfl_67_Refreshing);
               edtavDescripcion_Enabled = 0;
               AssignProp(sPrefix, false, edtavDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDescripcion_Enabled), 5, 0), !bGXsfl_67_Refreshing);
               edtavDistribuidordescripcionvar_Enabled = 0;
               AssignProp(sPrefix, false, edtavDistribuidordescripcionvar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDistribuidordescripcionvar_Enabled), 5, 0), !bGXsfl_67_Refreshing);
               WS3P2( ) ;
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
            context.SendWebValue( context.GetMessage( "WPDetalle Promocion Admin Factura WC", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Popover/WWPPopoverRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpdetallepromocionadminfacturawc.aspx"+UrlEncode(StringUtil.LTrimStr(AV7PromocionID,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpdetallepromocionadminfacturawc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV120Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV120Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vREGUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV98RegUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREGUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV98RegUsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOCORREO", AV119UsuarioCorreo);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOCORREO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV119UsuarioCorreo, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFROMDATE", context.localUtil.Format(AV100FromDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vTODATE", context.localUtil.Format(AV101ToDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV15FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_67", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_67), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV20DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV20DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDISTRIBUIDORID_DATA", AV113DistribuidorID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDISTRIBUIDORID_DATA", AV113DistribuidorID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vELEMENTS", AV102Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vELEMENTS", AV102Elements);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPARAMETERS", AV103Parameters);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPARAMETERS", AV103Parameters);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMCLICKDATA", AV104ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMCLICKDATA", AV104ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMDOUBLECLICKDATA", AV105ItemDoubleClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMDOUBLECLICKDATA", AV105ItemDoubleClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDRAGANDDROPDATA", AV106DragAndDropData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDRAGANDDROPDATA", AV106DragAndDropData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERCHANGEDDATA", AV107FilterChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERCHANGEDDATA", AV107FilterChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMEXPANDDATA", AV108ItemExpandData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMEXPANDDATA", AV108ItemExpandData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMCOLLAPSEDATA", AV109ItemCollapseData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMCOLLAPSEDATA", AV109ItemCollapseData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV25GridAppliedFilters);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_FACTURAFECHAREGISTROAUXDATETO", context.localUtil.DToC( AV90DDO_FacturaFechaRegistroAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_FACTURAFECHAFACTURAAUXDATETO", context.localUtil.DToC( AV95DDO_FacturaFechaFacturaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7PromocionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV120Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV120Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAFECHAREGISTRO", context.localUtil.DToC( AV87TFFacturaFechaRegistro, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAFECHAREGISTRO_TO", context.localUtil.DToC( AV88TFFacturaFechaRegistro_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROMOCIONDESCRIPCION", AV37TFPromocionDescripcion);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROMOCIONDESCRIPCION_SEL", AV38TFPromocionDescripcion_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURANO", StringUtil.RTrim( AV39TFFacturaNo));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURANO_SEL", StringUtil.RTrim( AV40TFFacturaNo_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAFECHAFACTURA", context.localUtil.DToC( AV92TFFacturaFechaFactura, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAFECHAFACTURA_TO", context.localUtil.DToC( AV93TFFacturaFechaFactura_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTATUS", StringUtil.RTrim( AV46TFEstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTATUSOPERATOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47TFEstatusOperator), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFUSUARIONOMBRECOMPLETO", AV56TFUsuarioNombreCompleto);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFUSUARIONOMBRECOMPLETO_SEL", AV57TFUsuarioNombreCompleto_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDISTRIBUIDORID", AV112DistribuidorID);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDISTRIBUIDORID", AV112DistribuidorID);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIOROL", StringUtil.RTrim( A40UsuarioRol));
         GxWebStd.gx_hidden_field( context, sPrefix+"DISTRIBUIDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10DistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"DISTRIBUIDORESUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A81DistribuidoresUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vREGUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV98RegUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREGUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV98RegUsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"DISTRIBUIDORDESCRIPCION", A11DistribuidorDescripcion);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV11GridState);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLISTAUSUARIOS", AV116ListaUsuarios);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLISTAUSUARIOS", AV116ListaUsuarios);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vBLOB", AV83Blob);
         GxWebStd.gx_hidden_field( context, sPrefix+"vFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV99FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FACTURAPDF", A75FacturaPDF);
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOCORREO", AV119UsuarioCorreo);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOCORREO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV119UsuarioCorreo, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWPDETALLEPROMOCIONADMINFACTURAWCDS_1_PROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV121Wpdetallepromocionadminfacturawcds_1_promocionid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIONOMBRE", StringUtil.RTrim( A30UsuarioNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIOAPELLIDO", StringUtil.RTrim( A51UsuarioApellido));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_FACTURAFECHAREGISTROAUXDATE", context.localUtil.DToC( AV89DDO_FacturaFechaRegistroAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_FACTURAFECHAFACTURAAUXDATE", context.localUtil.DToC( AV94DDO_FacturaFechaFacturaAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DISTRIBUIDORID_Cls", StringUtil.RTrim( Combo_distribuidorid_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DISTRIBUIDORID_Selectedvalue_set", StringUtil.RTrim( Combo_distribuidorid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DISTRIBUIDORID_Allowmultipleselection", StringUtil.BoolToStr( Combo_distribuidorid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DISTRIBUIDORID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_distribuidorid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DISTRIBUIDORID_Emptyitem", StringUtil.BoolToStr( Combo_distribuidorid_Emptyitem));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DISTRIBUIDORID_Multiplevaluestype", StringUtil.RTrim( Combo_distribuidorid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, sPrefix+"UTCHARTDOUGHNUT_Objectcall", StringUtil.RTrim( Utchartdoughnut_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"UTCHARTDOUGHNUT_Objectcall", StringUtil.RTrim( Utchartdoughnut_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"UTCHARTDOUGHNUT_Type", StringUtil.RTrim( Utchartdoughnut_Type));
         GxWebStd.gx_hidden_field( context, sPrefix+"UTCHARTDOUGHNUT_Title", StringUtil.RTrim( Utchartdoughnut_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"UTCHARTDOUGHNUT_Showvalues", StringUtil.BoolToStr( Utchartdoughnut_Showvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"UTCHARTDOUGHNUT_Charttype", StringUtil.RTrim( Utchartdoughnut_Charttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"UTCHARTCOLUMNLINE_Objectcall", StringUtil.RTrim( Utchartcolumnline_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"UTCHARTCOLUMNLINE_Objectcall", StringUtil.RTrim( Utchartcolumnline_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"UTCHARTCOLUMNLINE_Type", StringUtil.RTrim( Utchartcolumnline_Type));
         GxWebStd.gx_hidden_field( context, sPrefix+"UTCHARTCOLUMNLINE_Title", StringUtil.RTrim( Utchartcolumnline_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"INNWEWINDOW_Target", StringUtil.RTrim( Innwewindow_Target));
         GxWebStd.gx_hidden_field( context, sPrefix+"POPOVER_PARTIDAS_Gridinternalname", StringUtil.RTrim( Popover_partidas_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"POPOVER_PARTIDAS_Iteminternalname", StringUtil.RTrim( Popover_partidas_Iteminternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"POPOVER_PARTIDAS_Isgriditem", StringUtil.BoolToStr( Popover_partidas_Isgriditem));
         GxWebStd.gx_hidden_field( context, sPrefix+"POPOVER_PARTIDAS_Trigger", StringUtil.RTrim( Popover_partidas_Trigger));
         GxWebStd.gx_hidden_field( context, sPrefix+"POPOVER_PARTIDAS_Popoverwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Popover_partidas_Popoverwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"POPOVER_PARTIDAS_Position", StringUtil.RTrim( Popover_partidas_Position));
         GxWebStd.gx_hidden_field( context, sPrefix+"POPOVER_PARTIDAS_Keepopened", StringUtil.BoolToStr( Popover_partidas_Keepopened));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Fixedfilters", StringUtil.RTrim( Ddo_grid_Fixedfilters));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedfixedfilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Popoversingrid", StringUtil.RTrim( Grid_empowerer_Popoversingrid));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumnfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedcolumnfixedfilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DISTRIBUIDORID_Selectedvalue_get", StringUtil.RTrim( Combo_distribuidorid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSERACTION2_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction2_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumnfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedcolumnfixedfilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DISTRIBUIDORID_Selectedvalue_get", StringUtil.RTrim( Combo_distribuidorid_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm3P2( )
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
            if ( ! ( WebComp_Wwpaux_wc == null ) )
            {
               WebComp_Wwpaux_wc.componentjscripts();
            }
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
         return "WPDetallePromocionAdminFacturaWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WPDetalle Promocion Admin Factura WC", "") ;
      }

      protected void WB3P0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpdetallepromocionadminfacturawc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
               context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
               context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
               context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
               context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Popover/WWPPopoverRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablegridheader_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "TableMainWithShadow", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFromdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFromdate_Internalname, context.GetMessage( "Desde", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFromdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFromdate_Internalname, context.localUtil.Format(AV100FromDate, "99/99/99"), context.localUtil.Format( AV100FromDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFromdate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFromdate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDetallePromocionAdminFacturaWC.htm");
            GxWebStd.gx_bitmap( context, edtavFromdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFromdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPDetallePromocionAdminFacturaWC.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTodate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTodate_Internalname, context.GetMessage( "Hasta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTodate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTodate_Internalname, context.localUtil.Format(AV101ToDate, "99/99/99"), context.localUtil.Format( AV101ToDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTodate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTodate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPDetallePromocionAdminFacturaWC.htm");
            GxWebStd.gx_bitmap( context, edtavTodate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTodate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPDetallePromocionAdminFacturaWC.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplitteddistribuidorid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_distribuidorid_Internalname, context.GetMessage( "Distribuidores", ""), "", "", lblTextblockcombo_distribuidorid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPDetallePromocionAdminFacturaWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_distribuidorid.SetProperty("Caption", Combo_distribuidorid_Caption);
            ucCombo_distribuidorid.SetProperty("Cls", Combo_distribuidorid_Cls);
            ucCombo_distribuidorid.SetProperty("AllowMultipleSelection", Combo_distribuidorid_Allowmultipleselection);
            ucCombo_distribuidorid.SetProperty("IncludeOnlySelectedOption", Combo_distribuidorid_Includeonlyselectedoption);
            ucCombo_distribuidorid.SetProperty("EmptyItem", Combo_distribuidorid_Emptyitem);
            ucCombo_distribuidorid.SetProperty("MultipleValuesType", Combo_distribuidorid_Multiplevaluestype);
            ucCombo_distribuidorid.SetProperty("DropDownOptionsTitleSettingsIcons", AV20DDO_TitleSettingsIcons);
            ucCombo_distribuidorid.SetProperty("DropDownOptionsData", AV113DistribuidorID_Data);
            ucCombo_distribuidorid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_distribuidorid_Internalname, sPrefix+"COMBO_DISTRIBUIDORIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction99_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(67), 2, 0)+","+"null"+");", context.GetMessage( "Filtrar", ""), bttBtnuseraction99_Jsonclick, 5, context.GetMessage( "Filtrar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUSERACTION99\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPDetallePromocionAdminFacturaWC.htm");
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
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "TableMainWithShadow", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartdoughnut.SetProperty("Elements", AV102Elements);
            ucUtchartdoughnut.SetProperty("Parameters", AV103Parameters);
            ucUtchartdoughnut.SetProperty("Type", Utchartdoughnut_Type);
            ucUtchartdoughnut.SetProperty("Title", Utchartdoughnut_Title);
            ucUtchartdoughnut.SetProperty("ShowValues", Utchartdoughnut_Showvalues);
            ucUtchartdoughnut.SetProperty("ChartType", Utchartdoughnut_Charttype);
            ucUtchartdoughnut.SetProperty("ItemClickData", AV104ItemClickData);
            ucUtchartdoughnut.SetProperty("ItemDoubleClickData", AV105ItemDoubleClickData);
            ucUtchartdoughnut.SetProperty("DragAndDropData", AV106DragAndDropData);
            ucUtchartdoughnut.SetProperty("FilterChangedData", AV107FilterChangedData);
            ucUtchartdoughnut.SetProperty("ItemExpandData", AV108ItemExpandData);
            ucUtchartdoughnut.SetProperty("ItemCollapseData", AV109ItemCollapseData);
            ucUtchartdoughnut.Render(context, "queryviewer", Utchartdoughnut_Internalname, sPrefix+"UTCHARTDOUGHNUTContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartcolumnline.SetProperty("Elements", AV102Elements);
            ucUtchartcolumnline.SetProperty("Parameters", AV103Parameters);
            ucUtchartcolumnline.SetProperty("Type", Utchartcolumnline_Type);
            ucUtchartcolumnline.SetProperty("Title", Utchartcolumnline_Title);
            ucUtchartcolumnline.SetProperty("ItemClickData", AV104ItemClickData);
            ucUtchartcolumnline.SetProperty("ItemDoubleClickData", AV105ItemDoubleClickData);
            ucUtchartcolumnline.SetProperty("DragAndDropData", AV106DragAndDropData);
            ucUtchartcolumnline.SetProperty("FilterChangedData", AV107FilterChangedData);
            ucUtchartcolumnline.SetProperty("ItemExpandData", AV108ItemExpandData);
            ucUtchartcolumnline.SetProperty("ItemCollapseData", AV109ItemCollapseData);
            ucUtchartcolumnline.Render(context, "queryviewer", Utchartcolumnline_Internalname, sPrefix+"UTCHARTCOLUMNLINEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "TableMainWithShadow", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColorFilledActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexceldetallado_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(67), 2, 0)+","+"null"+");", context.GetMessage( "Excel detallado", ""), bttBtnexceldetallado_Jsonclick, 5, context.GetMessage( "Excel detallado", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXCELDETALLADO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPDetallePromocionAdminFacturaWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexcelconcentrado_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(67), 2, 0)+","+"null"+");", context.GetMessage( "Excel concentrado", ""), bttBtnexcelconcentrado_Jsonclick, 5, context.GetMessage( "Excel concentrado", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXCELCONCENTRADO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPDetallePromocionAdminFacturaWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV17ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, sPrefix+"DDO_MANAGEFILTERSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WPDetallePromocionAdminFacturaWC.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl67( ) ;
         }
         if ( wbEnd == 67 )
         {
            wbEnd = 0;
            nRC_GXsfl_67 = (int)(nGXsfl_67_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV23GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV24GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV25GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, sPrefix+"GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucInnwewindow.Render(context, "innewwindow", Innwewindow_Internalname, sPrefix+"INNWEWINDOWContainer");
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
            ucPopover_partidas.SetProperty("IsGridItem", Popover_partidas_Isgriditem);
            ucPopover_partidas.SetProperty("Trigger", Popover_partidas_Trigger);
            ucPopover_partidas.SetProperty("PopoverWidth", Popover_partidas_Popoverwidth);
            ucPopover_partidas.SetProperty("Position", Popover_partidas_Position);
            ucPopover_partidas.SetProperty("KeepOpened", Popover_partidas_Keepopened);
            ucPopover_partidas.Render(context, "dvelop.wwppopover", Popover_partidas_Internalname, sPrefix+"POPOVER_PARTIDASContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("FixedFilters", Ddo_grid_Fixedfilters);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV20DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPromocionID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionID_Jsonclick, 0, "Attribute", "", "", "", "", edtPromocionID_Visible, 0, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_WPDetallePromocionAdminFacturaWC.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("PopoversInGrid", Grid_empowerer_Popoversingrid);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0102"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0102"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_67_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0102"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_facturafecharegistroauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_facturafecharegistroauxdatetext_Internalname, AV91DDO_FacturaFechaRegistroAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV91DDO_FacturaFechaRegistroAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_facturafecharegistroauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDetallePromocionAdminFacturaWC.htm");
            /* User Defined Control */
            ucTffacturafecharegistro_rangepicker.SetProperty("Start Date", AV89DDO_FacturaFechaRegistroAuxDate);
            ucTffacturafecharegistro_rangepicker.SetProperty("End Date", AV90DDO_FacturaFechaRegistroAuxDateTo);
            ucTffacturafecharegistro_rangepicker.Render(context, "wwp.daterangepicker", Tffacturafecharegistro_rangepicker_Internalname, sPrefix+"TFFACTURAFECHAREGISTRO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_facturafechafacturaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_facturafechafacturaauxdatetext_Internalname, AV96DDO_FacturaFechaFacturaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV96DDO_FacturaFechaFacturaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_facturafechafacturaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPDetallePromocionAdminFacturaWC.htm");
            /* User Defined Control */
            ucTffacturafechafactura_rangepicker.SetProperty("Start Date", AV94DDO_FacturaFechaFacturaAuxDate);
            ucTffacturafechafactura_rangepicker.SetProperty("End Date", AV95DDO_FacturaFechaFacturaAuxDateTo);
            ucTffacturafechafactura_rangepicker.Render(context, "wwp.daterangepicker", Tffacturafechafactura_rangepicker_Internalname, sPrefix+"TFFACTURAFECHAFACTURA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 67 )
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

      protected void START3P2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WPDetalle Promocion Admin Factura WC", ""), 0) ;
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
               STRUP3P0( ) ;
            }
         }
      }

      protected void WS3P2( )
      {
         START3P2( ) ;
         EVT3P2( ) ;
      }

      protected void EVT3P2( )
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
                                 STRUP3P0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_DISTRIBUIDORID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_distribuidorid.Onoptionclicked */
                                    E113P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E123P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E133P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E143P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E153P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXCELDETALLADO'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExcelDetallado' */
                                    E163P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXCELCONCENTRADO'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExcelConcentrado' */
                                    E173P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION99'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUserAction99' */
                                    E183P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavUseraction8_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VPARTIDAS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VUSERACTION4.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VUSERACTION2.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VUSERACTION4.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VPARTIDAS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VUSERACTION2.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3P0( ) ;
                              }
                              nGXsfl_67_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
                              SubsflControlProps_672( ) ;
                              A69FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              AV62UserAction4 = cgiGet( edtavUseraction4_Internalname);
                              AssignProp(sPrefix, false, edtavUseraction4_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV62UserAction4)) ? AV135Useraction4_GXI : context.convertURL( context.PathToRelativeUrl( AV62UserAction4))), !bGXsfl_67_Refreshing);
                              AssignProp(sPrefix, false, edtavUseraction4_Internalname, "SrcSet", context.GetImageSrcSet( AV62UserAction4), true);
                              AV63UserAction8 = cgiGet( edtavUseraction8_Internalname);
                              AssignAttri(sPrefix, false, edtavUseraction8_Internalname, AV63UserAction8);
                              A72FacturaFechaRegistro = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaRegistro_Internalname), 0));
                              A42PromocionDescripcion = cgiGet( edtPromocionDescripcion_Internalname);
                              A71FacturaNo = cgiGet( edtFacturaNo_Internalname);
                              A73FacturaFechaFactura = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaFactura_Internalname), 0));
                              AV97PartidasWithTags = cgiGet( edtavPartidaswithtags_Internalname);
                              AssignAttri(sPrefix, false, edtavPartidaswithtags_Internalname, AV97PartidasWithTags);
                              AV85Partidas = cgiGet( edtavPartidas_Internalname);
                              AssignAttri(sPrefix, false, edtavPartidas_Internalname, AV85Partidas);
                              AV61UserAction2 = cgiGet( edtavUseraction2_Internalname);
                              AssignAttri(sPrefix, false, edtavUseraction2_Internalname, AV61UserAction2);
                              AV60EstatusWithTags = cgiGet( edtavEstatuswithtags_Internalname);
                              AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV60EstatusWithTags);
                              AV28Estatus = cgiGet( edtavEstatus_Internalname);
                              AssignAttri(sPrefix, false, edtavEstatus_Internalname, AV28Estatus);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vESTATUS"+"_"+sGXsfl_67_idx, GetSecureSignedToken( sPrefix+sGXsfl_67_idx, StringUtil.RTrim( context.localUtil.Format( AV28Estatus, "")), context));
                              AV29Descripcion = cgiGet( edtavDescripcion_Internalname);
                              AssignAttri(sPrefix, false, edtavDescripcion_Internalname, AV29Descripcion);
                              cmbFacturaEstatus.Name = cmbFacturaEstatus_Internalname;
                              cmbFacturaEstatus.CurrentValue = cgiGet( cmbFacturaEstatus_Internalname);
                              A80FacturaEstatus = cgiGet( cmbFacturaEstatus_Internalname);
                              A29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A52UsuarioNombreCompleto = cgiGet( edtUsuarioNombreCompleto_Internalname);
                              A21MotivoRechazoActivo = StringUtil.StrToBool( cgiGet( chkMotivoRechazoActivo_Internalname));
                              A20MotivoRechazoDescripcion = cgiGet( edtMotivoRechazoDescripcion_Internalname);
                              A19MotivoRechazoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMotivoRechazoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              AV86DistribuidorDescripcionVar = cgiGet( edtavDistribuidordescripcionvar_Internalname);
                              AssignAttri(sPrefix, false, edtavDistribuidordescripcionvar_Internalname, AV86DistribuidorDescripcionVar);
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
                                          GX_FocusControl = edtavUseraction8_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E193P2 ();
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
                                          GX_FocusControl = edtavUseraction8_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E203P2 ();
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
                                          GX_FocusControl = edtavUseraction8_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E213P2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VPARTIDAS.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavUseraction8_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E223P2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUSERACTION4.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavUseraction8_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E233P2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUSERACTION2.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavUseraction8_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E243P2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             /* Set Refresh If Orderedby Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Fromdate Changed */
                                             if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vFROMDATE"), 0) != AV100FromDate )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Todate Changed */
                                             if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vTODATE"), 0) != AV101ToDate )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP3P0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavUseraction8_Internalname;
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 102 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0102");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0102", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3P2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3P2( ) ;
            }
         }
      }

      protected void PA3P2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpdetallepromocionadminfacturawc.aspx")), "wpdetallepromocionadminfacturawc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpdetallepromocionadminfacturawc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "PromocionID");
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
               GX_FocusControl = edtavFromdate_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_672( ) ;
         while ( nGXsfl_67_idx <= nRC_GXsfl_67 )
         {
            sendrow_672( ) ;
            nGXsfl_67_idx = ((subGrid_Islastpage==1)&&(nGXsfl_67_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_67_idx+1);
            sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
            SubsflControlProps_672( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       DateTime AV100FromDate ,
                                       DateTime AV101ToDate ,
                                       string AV15FilterFullText ,
                                       int AV7PromocionID ,
                                       short AV19ManageFiltersExecutionStep ,
                                       string AV120Pgmname ,
                                       DateTime AV87TFFacturaFechaRegistro ,
                                       DateTime AV88TFFacturaFechaRegistro_To ,
                                       string AV37TFPromocionDescripcion ,
                                       string AV38TFPromocionDescripcion_Sel ,
                                       string AV39TFFacturaNo ,
                                       string AV40TFFacturaNo_Sel ,
                                       DateTime AV92TFFacturaFechaFactura ,
                                       DateTime AV93TFFacturaFechaFactura_To ,
                                       string AV46TFEstatus ,
                                       short AV47TFEstatusOperator ,
                                       string AV56TFUsuarioNombreCompleto ,
                                       string AV57TFUsuarioNombreCompleto_Sel ,
                                       GxSimpleCollection<int> AV112DistribuidorID ,
                                       string A40UsuarioRol ,
                                       int A10DistribuidorID ,
                                       string AV28Estatus ,
                                       int A81DistribuidoresUsuarioID ,
                                       int AV98RegUsuarioID ,
                                       string A11DistribuidorDescripcion ,
                                       int AV121Wpdetallepromocionadminfacturawcds_1_promocionid ,
                                       string AV119UsuarioCorreo ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3P2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_USUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vESTATUS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV28Estatus, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vESTATUS", StringUtil.RTrim( AV28Estatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_FACTURAID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"FACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_FACTURAESTATUS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( A80FacturaEstatus, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"FACTURAESTATUS", StringUtil.RTrim( A80FacturaEstatus));
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
         RF3P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV120Pgmname = "WPDetallePromocionAdminFacturaWC";
         edtavUseraction8_Enabled = 0;
         edtavPartidaswithtags_Enabled = 0;
         edtavPartidas_Enabled = 0;
         edtavUseraction2_Enabled = 0;
         edtavEstatuswithtags_Enabled = 0;
         edtavEstatus_Enabled = 0;
         edtavDescripcion_Enabled = 0;
         edtavDistribuidordescripcionvar_Enabled = 0;
      }

      protected void RF3P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 67;
         /* Execute user event: Refresh */
         E203P2 ();
         nGXsfl_67_idx = 1;
         sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
         SubsflControlProps_672( ) ;
         bGXsfl_67_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar GridNoBorder WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_672( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A29UsuarioID ,
                                                 AV116ListaUsuarios ,
                                                 AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext ,
                                                 AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro ,
                                                 AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to ,
                                                 AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel ,
                                                 AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion ,
                                                 AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel ,
                                                 AV127Wpdetallepromocionadminfacturawcds_7_tffacturano ,
                                                 AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura ,
                                                 AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to ,
                                                 AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator ,
                                                 AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel ,
                                                 AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto ,
                                                 AV100FromDate ,
                                                 AV101ToDate ,
                                                 AV116ListaUsuarios.Count ,
                                                 A42PromocionDescripcion ,
                                                 A71FacturaNo ,
                                                 A30UsuarioNombre ,
                                                 A51UsuarioApellido ,
                                                 A72FacturaFechaRegistro ,
                                                 A73FacturaFechaFactura ,
                                                 A80FacturaEstatus ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A41PromocionID ,
                                                 AV7PromocionID ,
                                                 AV121Wpdetallepromocionadminfacturawcds_1_promocionid } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext), "%", "");
            lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext), "%", "");
            lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext), "%", "");
            lV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion), "%", "");
            lV127Wpdetallepromocionadminfacturawcds_7_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV127Wpdetallepromocionadminfacturawcds_7_tffacturano), 20, "%");
            lV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto), "%", "");
            /* Using cursor H003P2 */
            pr_default.execute(0, new Object[] {AV121Wpdetallepromocionadminfacturawcds_1_promocionid, AV7PromocionID, lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext, lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext, lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext, AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro, AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to, lV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion, AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel, lV127Wpdetallepromocionadminfacturawcds_7_tffacturano, AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel, AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura, AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to, lV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto, AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel, AV100FromDate, AV101ToDate, GXPagingFrom2, GXPagingTo2});
            nGXsfl_67_idx = 1;
            sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
            SubsflControlProps_672( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A41PromocionID = H003P2_A41PromocionID[0];
               AssignAttri(sPrefix, false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
               A19MotivoRechazoID = H003P2_A19MotivoRechazoID[0];
               A20MotivoRechazoDescripcion = H003P2_A20MotivoRechazoDescripcion[0];
               A21MotivoRechazoActivo = H003P2_A21MotivoRechazoActivo[0];
               A29UsuarioID = H003P2_A29UsuarioID[0];
               A80FacturaEstatus = H003P2_A80FacturaEstatus[0];
               A73FacturaFechaFactura = H003P2_A73FacturaFechaFactura[0];
               A71FacturaNo = H003P2_A71FacturaNo[0];
               A42PromocionDescripcion = H003P2_A42PromocionDescripcion[0];
               A72FacturaFechaRegistro = H003P2_A72FacturaFechaRegistro[0];
               A69FacturaID = H003P2_A69FacturaID[0];
               A51UsuarioApellido = H003P2_A51UsuarioApellido[0];
               A30UsuarioNombre = H003P2_A30UsuarioNombre[0];
               A42PromocionDescripcion = H003P2_A42PromocionDescripcion[0];
               A20MotivoRechazoDescripcion = H003P2_A20MotivoRechazoDescripcion[0];
               A21MotivoRechazoActivo = H003P2_A21MotivoRechazoActivo[0];
               A51UsuarioApellido = H003P2_A51UsuarioApellido[0];
               A30UsuarioNombre = H003P2_A30UsuarioNombre[0];
               A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
               /* Execute user event: Grid.Load */
               E213P2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 67;
            WB3P0( ) ;
         }
         bGXsfl_67_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3P2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV120Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV120Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_USUARIOID"+"_"+sGXsfl_67_idx, GetSecureSignedToken( sPrefix+sGXsfl_67_idx, context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vESTATUS"+"_"+sGXsfl_67_idx, GetSecureSignedToken( sPrefix+sGXsfl_67_idx, StringUtil.RTrim( context.localUtil.Format( AV28Estatus, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vREGUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV98RegUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREGUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV98RegUsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_FACTURAID"+"_"+sGXsfl_67_idx, GetSecureSignedToken( sPrefix+sGXsfl_67_idx, context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOCORREO", AV119UsuarioCorreo);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOCORREO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV119UsuarioCorreo, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_FACTURAESTATUS"+"_"+sGXsfl_67_idx, GetSecureSignedToken( sPrefix+sGXsfl_67_idx, StringUtil.RTrim( context.localUtil.Format( A80FacturaEstatus, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV121Wpdetallepromocionadminfacturawcds_1_promocionid = AV7PromocionID;
         AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext = AV15FilterFullText;
         AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro = AV87TFFacturaFechaRegistro;
         AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to = AV88TFFacturaFechaRegistro_To;
         AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = AV37TFPromocionDescripcion;
         AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel = AV38TFPromocionDescripcion_Sel;
         AV127Wpdetallepromocionadminfacturawcds_7_tffacturano = AV39TFFacturaNo;
         AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel = AV40TFFacturaNo_Sel;
         AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura = AV92TFFacturaFechaFactura;
         AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to = AV93TFFacturaFechaFactura_To;
         AV131Wpdetallepromocionadminfacturawcds_11_tfestatus = AV46TFEstatus;
         AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator = AV47TFEstatusOperator;
         AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = AV56TFUsuarioNombreCompleto;
         AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel = AV57TFUsuarioNombreCompleto_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV116ListaUsuarios ,
                                              AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext ,
                                              AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro ,
                                              AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to ,
                                              AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel ,
                                              AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion ,
                                              AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel ,
                                              AV127Wpdetallepromocionadminfacturawcds_7_tffacturano ,
                                              AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura ,
                                              AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to ,
                                              AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator ,
                                              AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel ,
                                              AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto ,
                                              AV100FromDate ,
                                              AV101ToDate ,
                                              AV116ListaUsuarios.Count ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A41PromocionID ,
                                              AV7PromocionID ,
                                              AV121Wpdetallepromocionadminfacturawcds_1_promocionid } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext), "%", "");
         lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext), "%", "");
         lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext), "%", "");
         lV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion), "%", "");
         lV127Wpdetallepromocionadminfacturawcds_7_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV127Wpdetallepromocionadminfacturawcds_7_tffacturano), 20, "%");
         lV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto), "%", "");
         /* Using cursor H003P3 */
         pr_default.execute(1, new Object[] {AV121Wpdetallepromocionadminfacturawcds_1_promocionid, AV7PromocionID, lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext, lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext, lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext, AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro, AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to, lV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion, AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel, lV127Wpdetallepromocionadminfacturawcds_7_tffacturano, AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel, AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura, AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to, lV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto, AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel, AV100FromDate, AV101ToDate});
         GRID_nRecordCount = H003P3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
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
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV121Wpdetallepromocionadminfacturawcds_1_promocionid = AV7PromocionID;
         AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext = AV15FilterFullText;
         AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro = AV87TFFacturaFechaRegistro;
         AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to = AV88TFFacturaFechaRegistro_To;
         AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = AV37TFPromocionDescripcion;
         AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel = AV38TFPromocionDescripcion_Sel;
         AV127Wpdetallepromocionadminfacturawcds_7_tffacturano = AV39TFFacturaNo;
         AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel = AV40TFFacturaNo_Sel;
         AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura = AV92TFFacturaFechaFactura;
         AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to = AV93TFFacturaFechaFactura_To;
         AV131Wpdetallepromocionadminfacturawcds_11_tfestatus = AV46TFEstatus;
         AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator = AV47TFEstatusOperator;
         AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = AV56TFUsuarioNombreCompleto;
         AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel = AV57TFUsuarioNombreCompleto_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV100FromDate, AV101ToDate, AV15FilterFullText, AV7PromocionID, AV19ManageFiltersExecutionStep, AV120Pgmname, AV87TFFacturaFechaRegistro, AV88TFFacturaFechaRegistro_To, AV37TFPromocionDescripcion, AV38TFPromocionDescripcion_Sel, AV39TFFacturaNo, AV40TFFacturaNo_Sel, AV92TFFacturaFechaFactura, AV93TFFacturaFechaFactura_To, AV46TFEstatus, AV47TFEstatusOperator, AV56TFUsuarioNombreCompleto, AV57TFUsuarioNombreCompleto_Sel, AV112DistribuidorID, A40UsuarioRol, A10DistribuidorID, AV28Estatus, A81DistribuidoresUsuarioID, AV98RegUsuarioID, A11DistribuidorDescripcion, AV121Wpdetallepromocionadminfacturawcds_1_promocionid, AV119UsuarioCorreo, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV121Wpdetallepromocionadminfacturawcds_1_promocionid = AV7PromocionID;
         AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext = AV15FilterFullText;
         AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro = AV87TFFacturaFechaRegistro;
         AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to = AV88TFFacturaFechaRegistro_To;
         AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = AV37TFPromocionDescripcion;
         AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel = AV38TFPromocionDescripcion_Sel;
         AV127Wpdetallepromocionadminfacturawcds_7_tffacturano = AV39TFFacturaNo;
         AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel = AV40TFFacturaNo_Sel;
         AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura = AV92TFFacturaFechaFactura;
         AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to = AV93TFFacturaFechaFactura_To;
         AV131Wpdetallepromocionadminfacturawcds_11_tfestatus = AV46TFEstatus;
         AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator = AV47TFEstatusOperator;
         AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = AV56TFUsuarioNombreCompleto;
         AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel = AV57TFUsuarioNombreCompleto_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV100FromDate, AV101ToDate, AV15FilterFullText, AV7PromocionID, AV19ManageFiltersExecutionStep, AV120Pgmname, AV87TFFacturaFechaRegistro, AV88TFFacturaFechaRegistro_To, AV37TFPromocionDescripcion, AV38TFPromocionDescripcion_Sel, AV39TFFacturaNo, AV40TFFacturaNo_Sel, AV92TFFacturaFechaFactura, AV93TFFacturaFechaFactura_To, AV46TFEstatus, AV47TFEstatusOperator, AV56TFUsuarioNombreCompleto, AV57TFUsuarioNombreCompleto_Sel, AV112DistribuidorID, A40UsuarioRol, A10DistribuidorID, AV28Estatus, A81DistribuidoresUsuarioID, AV98RegUsuarioID, A11DistribuidorDescripcion, AV121Wpdetallepromocionadminfacturawcds_1_promocionid, AV119UsuarioCorreo, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV121Wpdetallepromocionadminfacturawcds_1_promocionid = AV7PromocionID;
         AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext = AV15FilterFullText;
         AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro = AV87TFFacturaFechaRegistro;
         AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to = AV88TFFacturaFechaRegistro_To;
         AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = AV37TFPromocionDescripcion;
         AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel = AV38TFPromocionDescripcion_Sel;
         AV127Wpdetallepromocionadminfacturawcds_7_tffacturano = AV39TFFacturaNo;
         AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel = AV40TFFacturaNo_Sel;
         AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura = AV92TFFacturaFechaFactura;
         AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to = AV93TFFacturaFechaFactura_To;
         AV131Wpdetallepromocionadminfacturawcds_11_tfestatus = AV46TFEstatus;
         AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator = AV47TFEstatusOperator;
         AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = AV56TFUsuarioNombreCompleto;
         AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel = AV57TFUsuarioNombreCompleto_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV100FromDate, AV101ToDate, AV15FilterFullText, AV7PromocionID, AV19ManageFiltersExecutionStep, AV120Pgmname, AV87TFFacturaFechaRegistro, AV88TFFacturaFechaRegistro_To, AV37TFPromocionDescripcion, AV38TFPromocionDescripcion_Sel, AV39TFFacturaNo, AV40TFFacturaNo_Sel, AV92TFFacturaFechaFactura, AV93TFFacturaFechaFactura_To, AV46TFEstatus, AV47TFEstatusOperator, AV56TFUsuarioNombreCompleto, AV57TFUsuarioNombreCompleto_Sel, AV112DistribuidorID, A40UsuarioRol, A10DistribuidorID, AV28Estatus, A81DistribuidoresUsuarioID, AV98RegUsuarioID, A11DistribuidorDescripcion, AV121Wpdetallepromocionadminfacturawcds_1_promocionid, AV119UsuarioCorreo, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV121Wpdetallepromocionadminfacturawcds_1_promocionid = AV7PromocionID;
         AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext = AV15FilterFullText;
         AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro = AV87TFFacturaFechaRegistro;
         AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to = AV88TFFacturaFechaRegistro_To;
         AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = AV37TFPromocionDescripcion;
         AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel = AV38TFPromocionDescripcion_Sel;
         AV127Wpdetallepromocionadminfacturawcds_7_tffacturano = AV39TFFacturaNo;
         AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel = AV40TFFacturaNo_Sel;
         AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura = AV92TFFacturaFechaFactura;
         AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to = AV93TFFacturaFechaFactura_To;
         AV131Wpdetallepromocionadminfacturawcds_11_tfestatus = AV46TFEstatus;
         AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator = AV47TFEstatusOperator;
         AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = AV56TFUsuarioNombreCompleto;
         AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel = AV57TFUsuarioNombreCompleto_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV100FromDate, AV101ToDate, AV15FilterFullText, AV7PromocionID, AV19ManageFiltersExecutionStep, AV120Pgmname, AV87TFFacturaFechaRegistro, AV88TFFacturaFechaRegistro_To, AV37TFPromocionDescripcion, AV38TFPromocionDescripcion_Sel, AV39TFFacturaNo, AV40TFFacturaNo_Sel, AV92TFFacturaFechaFactura, AV93TFFacturaFechaFactura_To, AV46TFEstatus, AV47TFEstatusOperator, AV56TFUsuarioNombreCompleto, AV57TFUsuarioNombreCompleto_Sel, AV112DistribuidorID, A40UsuarioRol, A10DistribuidorID, AV28Estatus, A81DistribuidoresUsuarioID, AV98RegUsuarioID, A11DistribuidorDescripcion, AV121Wpdetallepromocionadminfacturawcds_1_promocionid, AV119UsuarioCorreo, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV121Wpdetallepromocionadminfacturawcds_1_promocionid = AV7PromocionID;
         AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext = AV15FilterFullText;
         AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro = AV87TFFacturaFechaRegistro;
         AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to = AV88TFFacturaFechaRegistro_To;
         AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = AV37TFPromocionDescripcion;
         AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel = AV38TFPromocionDescripcion_Sel;
         AV127Wpdetallepromocionadminfacturawcds_7_tffacturano = AV39TFFacturaNo;
         AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel = AV40TFFacturaNo_Sel;
         AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura = AV92TFFacturaFechaFactura;
         AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to = AV93TFFacturaFechaFactura_To;
         AV131Wpdetallepromocionadminfacturawcds_11_tfestatus = AV46TFEstatus;
         AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator = AV47TFEstatusOperator;
         AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = AV56TFUsuarioNombreCompleto;
         AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel = AV57TFUsuarioNombreCompleto_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV100FromDate, AV101ToDate, AV15FilterFullText, AV7PromocionID, AV19ManageFiltersExecutionStep, AV120Pgmname, AV87TFFacturaFechaRegistro, AV88TFFacturaFechaRegistro_To, AV37TFPromocionDescripcion, AV38TFPromocionDescripcion_Sel, AV39TFFacturaNo, AV40TFFacturaNo_Sel, AV92TFFacturaFechaFactura, AV93TFFacturaFechaFactura_To, AV46TFEstatus, AV47TFEstatusOperator, AV56TFUsuarioNombreCompleto, AV57TFUsuarioNombreCompleto_Sel, AV112DistribuidorID, A40UsuarioRol, A10DistribuidorID, AV28Estatus, A81DistribuidoresUsuarioID, AV98RegUsuarioID, A11DistribuidorDescripcion, AV121Wpdetallepromocionadminfacturawcds_1_promocionid, AV119UsuarioCorreo, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV120Pgmname = "WPDetallePromocionAdminFacturaWC";
         edtavUseraction8_Enabled = 0;
         edtavPartidaswithtags_Enabled = 0;
         edtavPartidas_Enabled = 0;
         edtavUseraction2_Enabled = 0;
         edtavEstatuswithtags_Enabled = 0;
         edtavEstatus_Enabled = 0;
         edtavDescripcion_Enabled = 0;
         edtavDistribuidordescripcionvar_Enabled = 0;
         edtFacturaID_Enabled = 0;
         edtFacturaFechaRegistro_Enabled = 0;
         edtPromocionDescripcion_Enabled = 0;
         edtFacturaNo_Enabled = 0;
         edtFacturaFechaFactura_Enabled = 0;
         cmbFacturaEstatus.Enabled = 0;
         edtUsuarioID_Enabled = 0;
         edtUsuarioNombreCompleto_Enabled = 0;
         chkMotivoRechazoActivo.Enabled = 0;
         edtMotivoRechazoDescripcion_Enabled = 0;
         edtMotivoRechazoID_Enabled = 0;
         edtPromocionID_Enabled = 0;
         AssignProp(sPrefix, false, edtPromocionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionID_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E193P2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV20DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDISTRIBUIDORID_DATA"), AV113DistribuidorID_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vELEMENTS"), AV102Elements);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vPARAMETERS"), AV103Parameters);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMCLICKDATA"), AV104ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMDOUBLECLICKDATA"), AV105ItemDoubleClickData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDRAGANDDROPDATA"), AV106DragAndDropData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERCHANGEDDATA"), AV107FilterChangedData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMEXPANDDATA"), AV108ItemExpandData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMCOLLAPSEDATA"), AV109ItemCollapseData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            /* Read saved values. */
            nRC_GXsfl_67 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_67"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV23GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV24GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV25GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            AV89DDO_FacturaFechaRegistroAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_FACTURAFECHAREGISTROAUXDATE"), 0);
            AV90DDO_FacturaFechaRegistroAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_FACTURAFECHAREGISTROAUXDATETO"), 0);
            AV94DDO_FacturaFechaFacturaAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_FACTURAFECHAFACTURAAUXDATE"), 0);
            AV95DDO_FacturaFechaFacturaAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_FACTURAFECHAFACTURAAUXDATETO"), 0);
            wcpOAV7PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7PromocionID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Combo_distribuidorid_Cls = cgiGet( sPrefix+"COMBO_DISTRIBUIDORID_Cls");
            Combo_distribuidorid_Selectedvalue_set = cgiGet( sPrefix+"COMBO_DISTRIBUIDORID_Selectedvalue_set");
            Combo_distribuidorid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DISTRIBUIDORID_Allowmultipleselection"));
            Combo_distribuidorid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DISTRIBUIDORID_Includeonlyselectedoption"));
            Combo_distribuidorid_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DISTRIBUIDORID_Emptyitem"));
            Combo_distribuidorid_Multiplevaluestype = cgiGet( sPrefix+"COMBO_DISTRIBUIDORID_Multiplevaluestype");
            Utchartdoughnut_Objectcall = cgiGet( sPrefix+"UTCHARTDOUGHNUT_Objectcall");
            Utchartdoughnut_Objectcall = cgiGet( sPrefix+"UTCHARTDOUGHNUT_Objectcall");
            Utchartdoughnut_Type = cgiGet( sPrefix+"UTCHARTDOUGHNUT_Type");
            Utchartdoughnut_Title = cgiGet( sPrefix+"UTCHARTDOUGHNUT_Title");
            Utchartdoughnut_Showvalues = StringUtil.StrToBool( cgiGet( sPrefix+"UTCHARTDOUGHNUT_Showvalues"));
            Utchartdoughnut_Charttype = cgiGet( sPrefix+"UTCHARTDOUGHNUT_Charttype");
            Utchartcolumnline_Objectcall = cgiGet( sPrefix+"UTCHARTCOLUMNLINE_Objectcall");
            Utchartcolumnline_Objectcall = cgiGet( sPrefix+"UTCHARTCOLUMNLINE_Objectcall");
            Utchartcolumnline_Type = cgiGet( sPrefix+"UTCHARTCOLUMNLINE_Type");
            Utchartcolumnline_Title = cgiGet( sPrefix+"UTCHARTCOLUMNLINE_Title");
            Ddo_managefilters_Icontype = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption");
            Innwewindow_Target = cgiGet( sPrefix+"INNWEWINDOW_Target");
            Popover_partidas_Gridinternalname = cgiGet( sPrefix+"POPOVER_PARTIDAS_Gridinternalname");
            Popover_partidas_Iteminternalname = cgiGet( sPrefix+"POPOVER_PARTIDAS_Iteminternalname");
            Popover_partidas_Isgriditem = StringUtil.StrToBool( cgiGet( sPrefix+"POPOVER_PARTIDAS_Isgriditem"));
            Popover_partidas_Trigger = cgiGet( sPrefix+"POPOVER_PARTIDAS_Trigger");
            Popover_partidas_Popoverwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"POPOVER_PARTIDAS_Popoverwidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Popover_partidas_Position = cgiGet( sPrefix+"POPOVER_PARTIDAS_Position");
            Popover_partidas_Keepopened = StringUtil.StrToBool( cgiGet( sPrefix+"POPOVER_PARTIDAS_Keepopened"));
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Ddo_grid_Fixedfilters = cgiGet( sPrefix+"DDO_GRID_Fixedfilters");
            Ddo_grid_Selectedfixedfilter = cgiGet( sPrefix+"DDO_GRID_Selectedfixedfilter");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Popoversingrid = cgiGet( sPrefix+"GRID_EMPOWERER_Popoversingrid");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_grid_Selectedcolumnfixedfilter = cgiGet( sPrefix+"DDO_GRID_Selectedcolumnfixedfilter");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Combo_distribuidorid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_DISTRIBUIDORID_Selectedvalue_get");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavFromdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "From Date", "")}), 1, "vFROMDATE");
               GX_FocusControl = edtavFromdate_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV100FromDate = DateTime.MinValue;
               AssignAttri(sPrefix, false, "AV100FromDate", context.localUtil.Format(AV100FromDate, "99/99/99"));
            }
            else
            {
               AV100FromDate = context.localUtil.CToD( cgiGet( edtavFromdate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV100FromDate", context.localUtil.Format(AV100FromDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTodate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "To Date", "")}), 1, "vTODATE");
               GX_FocusControl = edtavTodate_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV101ToDate = DateTime.MinValue;
               AssignAttri(sPrefix, false, "AV101ToDate", context.localUtil.Format(AV101ToDate, "99/99/99"));
            }
            else
            {
               AV101ToDate = context.localUtil.CToD( cgiGet( edtavTodate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV101ToDate", context.localUtil.Format(AV101ToDate, "99/99/99"));
            }
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            A41PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPromocionID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            AV91DDO_FacturaFechaRegistroAuxDateText = cgiGet( edtavDdo_facturafecharegistroauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV91DDO_FacturaFechaRegistroAuxDateText", AV91DDO_FacturaFechaRegistroAuxDateText);
            AV96DDO_FacturaFechaFacturaAuxDateText = cgiGet( edtavDdo_facturafechafacturaauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV96DDO_FacturaFechaFacturaAuxDateText", AV96DDO_FacturaFechaFacturaAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( sPrefix+"GXH_vFROMDATE"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV100FromDate ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( sPrefix+"GXH_vTODATE"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV101ToDate ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E193P2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E193P2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV101ToDate = DateTimeUtil.Today( context);
         AssignAttri(sPrefix, false, "AV101ToDate", context.localUtil.Format(AV101ToDate, "99/99/99"));
         AV100FromDate = DateTimeUtil.AddMth( AV101ToDate, -3);
         AssignAttri(sPrefix, false, "AV100FromDate", context.localUtil.Format(AV100FromDate, "99/99/99"));
         /* Execute user subroutine: 'OBTIENELISTAUSUARIOS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Utchartdoughnut_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPFacturaEstatusFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV100FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV101ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV116ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartdoughnut.SendProperty(context, sPrefix, false, Utchartdoughnut_Internalname, "Object", Utchartdoughnut_Objectcall);
         Utchartcolumnline_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPGraficaFacturasPorMesFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV100FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV101ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV116ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartcolumnline.SendProperty(context, sPrefix, false, Utchartcolumnline_Internalname, "Object", Utchartcolumnline_Objectcall);
         AV65UsuarioJSON = AV66WebSession.Get(context.GetMessage( "Usuario", ""));
         AV67SDTUsuario.FromJSonString(AV65UsuarioJSON, null);
         AV68UsuarioRol = AV67SDTUsuario.gxTpr_Usuariorol;
         AV119UsuarioCorreo = StringUtil.Lower( StringUtil.Trim( AV67SDTUsuario.gxTpr_Usuariocorreo));
         AssignAttri(sPrefix, false, "AV119UsuarioCorreo", AV119UsuarioCorreo);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOCORREO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV119UsuarioCorreo, "")), context));
         if ( ( StringUtil.StrCmp(AV68UsuarioRol, "Administrador Yokohama") == 0 ) || ( StringUtil.StrCmp(AV68UsuarioRol, "Super Administrador") == 0 ) )
         {
            edtavUseraction2_Visible = 1;
            AssignProp(sPrefix, false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_67_Refreshing);
         }
         else
         {
            edtavUseraction2_Visible = 0;
            AssignProp(sPrefix, false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_67_Refreshing);
         }
         Popover_partidas_Gridinternalname = subGrid_Internalname;
         ucPopover_partidas.SendProperty(context, sPrefix, false, Popover_partidas_Internalname, "GridInternalName", Popover_partidas_Gridinternalname);
         Popover_partidas_Iteminternalname = edtavPartidaswithtags_Internalname;
         ucPopover_partidas.SendProperty(context, sPrefix, false, Popover_partidas_Internalname, "ItemInternalName", Popover_partidas_Iteminternalname);
         this.executeUsercontrolMethod(sPrefix, false, "TFFACTURAFECHAFACTURA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_facturafechafacturaauxdatetext_Internalname});
         this.executeUsercontrolMethod(sPrefix, false, "TFFACTURAFECHAREGISTRO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_facturafecharegistroauxdatetext_Internalname});
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV20DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV20DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         /* Execute user subroutine: 'LOADCOMBODISTRIBUIDORID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         edtPromocionID_Visible = 0;
         AssignProp(sPrefix, false, edtPromocionID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPromocionID_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV20DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV20DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E203P2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'OBTIENELISTAUSUARIOS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV19ManageFiltersExecutionStep == 1 )
         {
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV19ManageFiltersExecutionStep == 2 )
         {
            AV19ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV23GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV23GridCurrentPage), 10, 0));
         AV24GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV24GridPageCount", StringUtil.LTrimStr( (decimal)(AV24GridPageCount), 10, 0));
         GXt_char2 = AV25GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV120Pgmname, out  GXt_char2) ;
         AV25GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV25GridAppliedFilters", AV25GridAppliedFilters);
         AV65UsuarioJSON = AV66WebSession.Get(context.GetMessage( "Usuario", ""));
         AV67SDTUsuario.FromJSonString(AV65UsuarioJSON, null);
         AV68UsuarioRol = AV67SDTUsuario.gxTpr_Usuariorol;
         if ( StringUtil.StrCmp(AV68UsuarioRol, "Administrador Yokohama") == 0 )
         {
            edtavUseraction2_Visible = 1;
            AssignProp(sPrefix, false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_67_Refreshing);
         }
         else
         {
            edtavUseraction2_Visible = 0;
            AssignProp(sPrefix, false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_67_Refreshing);
         }
         AV121Wpdetallepromocionadminfacturawcds_1_promocionid = AV7PromocionID;
         AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext = AV15FilterFullText;
         AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro = AV87TFFacturaFechaRegistro;
         AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to = AV88TFFacturaFechaRegistro_To;
         AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = AV37TFPromocionDescripcion;
         AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel = AV38TFPromocionDescripcion_Sel;
         AV127Wpdetallepromocionadminfacturawcds_7_tffacturano = AV39TFFacturaNo;
         AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel = AV40TFFacturaNo_Sel;
         AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura = AV92TFFacturaFechaFactura;
         AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to = AV93TFFacturaFechaFactura_To;
         AV131Wpdetallepromocionadminfacturawcds_11_tfestatus = AV46TFEstatus;
         AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator = AV47TFEstatusOperator;
         AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = AV56TFUsuarioNombreCompleto;
         AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel = AV57TFUsuarioNombreCompleto_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV116ListaUsuarios", AV116ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridState", AV11GridState);
      }

      protected void E133P2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV22PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV22PageToGo) ;
         }
      }

      protected void E143P2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E153P2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaFechaRegistro") == 0 )
            {
               AV87TFFacturaFechaRegistro = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV87TFFacturaFechaRegistro", context.localUtil.Format(AV87TFFacturaFechaRegistro, "99/99/99"));
               AV88TFFacturaFechaRegistro_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV88TFFacturaFechaRegistro_To", context.localUtil.Format(AV88TFFacturaFechaRegistro_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PromocionDescripcion") == 0 )
            {
               AV37TFPromocionDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV37TFPromocionDescripcion", AV37TFPromocionDescripcion);
               AV38TFPromocionDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV38TFPromocionDescripcion_Sel", AV38TFPromocionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaNo") == 0 )
            {
               AV39TFFacturaNo = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV39TFFacturaNo", AV39TFFacturaNo);
               AV40TFFacturaNo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV40TFFacturaNo_Sel", AV40TFFacturaNo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaFechaFactura") == 0 )
            {
               AV92TFFacturaFechaFactura = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV92TFFacturaFechaFactura", context.localUtil.Format(AV92TFFacturaFechaFactura, "99/99/99"));
               AV93TFFacturaFechaFactura_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV93TFFacturaFechaFactura_To", context.localUtil.Format(AV93TFFacturaFechaFactura_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Estatus") == 0 )
            {
               if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "1") == 0 )
               {
                  AV47TFEstatusOperator = 1;
                  AssignAttri(sPrefix, false, "AV47TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV47TFEstatusOperator), 4, 0));
                  AV46TFEstatus = "";
                  AssignAttri(sPrefix, false, "AV46TFEstatus", AV46TFEstatus);
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "2") == 0 )
               {
                  AV47TFEstatusOperator = 2;
                  AssignAttri(sPrefix, false, "AV47TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV47TFEstatusOperator), 4, 0));
                  AV46TFEstatus = "";
                  AssignAttri(sPrefix, false, "AV46TFEstatus", AV46TFEstatus);
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "3") == 0 )
               {
                  AV47TFEstatusOperator = 3;
                  AssignAttri(sPrefix, false, "AV47TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV47TFEstatusOperator), 4, 0));
                  AV46TFEstatus = "";
                  AssignAttri(sPrefix, false, "AV46TFEstatus", AV46TFEstatus);
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "4") == 0 )
               {
                  AV47TFEstatusOperator = 4;
                  AssignAttri(sPrefix, false, "AV47TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV47TFEstatusOperator), 4, 0));
                  AV46TFEstatus = "";
                  AssignAttri(sPrefix, false, "AV46TFEstatus", AV46TFEstatus);
               }
               else
               {
                  AV47TFEstatusOperator = 0;
                  AssignAttri(sPrefix, false, "AV47TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV47TFEstatusOperator), 4, 0));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioNombreCompleto") == 0 )
            {
               AV56TFUsuarioNombreCompleto = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV56TFUsuarioNombreCompleto", AV56TFUsuarioNombreCompleto);
               AV57TFUsuarioNombreCompleto_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV57TFUsuarioNombreCompleto_Sel", AV57TFUsuarioNombreCompleto_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E213P2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
         {
            AV29Descripcion = A20MotivoRechazoDescripcion;
            AssignAttri(sPrefix, false, edtavDescripcion_Internalname, AV29Descripcion);
         }
         else
         {
            AV29Descripcion = context.GetMessage( "NA", "");
            AssignAttri(sPrefix, false, edtavDescripcion_Internalname, AV29Descripcion);
         }
         AV85Partidas = context.GetMessage( "Partidas", "");
         AssignAttri(sPrefix, false, edtavPartidas_Internalname, AV85Partidas);
         AV98RegUsuarioID = A29UsuarioID;
         AssignAttri(sPrefix, false, "AV98RegUsuarioID", StringUtil.LTrimStr( (decimal)(AV98RegUsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREGUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV98RegUsuarioID), "ZZZZZZZZ9"), context));
         /* Execute user subroutine: 'OBTIENEDISTRIBUIDOR' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         edtavUseraction4_gximage = "iconoPDF";
         AV62UserAction4 = context.GetImagePath( "b97efd0f-8d9d-4227-92c4-9cbec8912646", "", context.GetTheme( ));
         AssignAttri(sPrefix, false, edtavUseraction4_Internalname, AV62UserAction4);
         AV135Useraction4_GXI = GXDbFile.PathToUrl( context.GetImagePath( "b97efd0f-8d9d-4227-92c4-9cbec8912646", "", context.GetTheme( )), context);
         edtavUseraction4_Tooltiptext = "";
         AV63UserAction8 = "<i class=\"IconoEditarAzul fas fa-magnifying-glass\"></i>";
         AssignAttri(sPrefix, false, edtavUseraction8_Internalname, AV63UserAction8);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpdetallefactura.aspx"+UrlEncode(StringUtil.LTrimStr(A69FacturaID,9,0));
         edtavUseraction8_Link = formatLink("wpdetallefactura.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV61UserAction2 = context.GetMessage( "Cambiar estatus", "");
         AssignAttri(sPrefix, false, edtavUseraction2_Internalname, AV61UserAction2);
         GXt_char2 = AV97PartidasWithTags;
         new WorkWithPlus.workwithplus_web.wwp_encodehtml(context ).execute(  AV85Partidas, out  GXt_char2) ;
         AV97PartidasWithTags = GXt_char2;
         AssignAttri(sPrefix, false, edtavPartidaswithtags_Internalname, AV97PartidasWithTags);
         AV97PartidasWithTags += "<i class='WWPPopoverIcon FontColorIcon fas fa-angle-down'></i>";
         AssignAttri(sPrefix, false, edtavPartidaswithtags_Internalname, AV97PartidasWithTags);
         GXt_char2 = AV60EstatusWithTags;
         new WorkWithPlus.workwithplus_web.wwp_encodehtml(context ).execute(  AV28Estatus, out  GXt_char2) ;
         AV60EstatusWithTags = GXt_char2;
         AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV60EstatusWithTags);
         if ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 )
         {
            AV60EstatusWithTags += StringUtil.Format( "<span class='AttributeTagWarning TagAfterText'>%1</span>", context.GetMessage( "En proceso", ""), "", "", "", "", "", "", "", "");
            AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV60EstatusWithTags);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 )
         {
            AV60EstatusWithTags += StringUtil.Format( "<span class='AttributeTagSuccess TagAfterText'>%1</span>", context.GetMessage( "Aprobada", ""), "", "", "", "", "", "", "", "");
            AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV60EstatusWithTags);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
         {
            AV60EstatusWithTags += StringUtil.Format( "<span class='AttributeTagDanger TagAfterText'>%1</span>", context.GetMessage( "Rechazada", ""), "", "", "", "", "", "", "", "");
            AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV60EstatusWithTags);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Cancelada") == 0 )
         {
            AV60EstatusWithTags += StringUtil.Format( "<span class='AttributeTagInfo TagAfterText'>%1</span>", context.GetMessage( "Cancelada", ""), "", "", "", "", "", "", "", "");
            AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV60EstatusWithTags);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 67;
         }
         sendrow_672( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_67_Refreshing )
         {
            DoAjaxLoad(67, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E123P2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WPDetallePromocionAdminFacturaWCFilters")) + "," + UrlEncode(StringUtil.RTrim(AV120Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WPDetallePromocionAdminFacturaWCFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV18ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WPDetallePromocionAdminFacturaWCFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV18ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV120Pgmname+"GridState",  AV18ManageFiltersXml) ;
               AV11GridState.FromXml(AV18ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S162 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S202 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV116ListaUsuarios", AV116ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17ManageFiltersData", AV17ManageFiltersData);
      }

      protected void E163P2( )
      {
         /* 'DoExcelDetallado' Routine */
         returnInSub = false;
         new generaexcelpartidas(context ).execute(  AV7PromocionID, out  AV80ExcelFilename, out  AV79ErrorMessage) ;
         if ( StringUtil.StrCmp(AV80ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV80ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
      }

      protected void E173P2( )
      {
         /* 'DoExcelConcentrado' Routine */
         returnInSub = false;
         new generaexcelresumenpromocion(context ).execute(  AV7PromocionID, out  AV80ExcelFilename) ;
         if ( StringUtil.StrCmp(AV80ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV80ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
      }

      protected void E183P2( )
      {
         /* 'DoUserAction99' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'OBTIENELISTAUSUARIOS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Utchartdoughnut_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPFacturaEstatusFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV100FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV101ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV116ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartdoughnut.SendProperty(context, sPrefix, false, Utchartdoughnut_Internalname, "Object", Utchartdoughnut_Objectcall);
         Utchartcolumnline_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPGraficaFacturasPorMesFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV100FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV101ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV116ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartcolumnline.SendProperty(context, sPrefix, false, Utchartcolumnline_Internalname, "Object", Utchartcolumnline_Objectcall);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV100FromDate, AV101ToDate, AV15FilterFullText, AV7PromocionID, AV19ManageFiltersExecutionStep, AV120Pgmname, AV87TFFacturaFechaRegistro, AV88TFFacturaFechaRegistro_To, AV37TFPromocionDescripcion, AV38TFPromocionDescripcion_Sel, AV39TFFacturaNo, AV40TFFacturaNo_Sel, AV92TFFacturaFechaFactura, AV93TFFacturaFechaFactura_To, AV46TFEstatus, AV47TFEstatusOperator, AV56TFUsuarioNombreCompleto, AV57TFUsuarioNombreCompleto_Sel, AV112DistribuidorID, A40UsuarioRol, A10DistribuidorID, AV28Estatus, A81DistribuidoresUsuarioID, AV98RegUsuarioID, A11DistribuidorDescripcion, AV121Wpdetallepromocionadminfacturawcds_1_promocionid, AV119UsuarioCorreo, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV116ListaUsuarios", AV116ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridState", AV11GridState);
      }

      protected void E223P2( )
      {
         /* Partidas_Click Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WCPartidasFacturaPopover")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wcpartidasfacturapopover", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WCPartidasFacturaPopover";
            WebComp_Wwpaux_wc_Component = "WCPartidasFacturaPopover";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0102",(string)"",(int)A69FacturaID});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0102"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E113P2( )
      {
         /* Combo_distribuidorid_Onoptionclicked Routine */
         returnInSub = false;
         AV112DistribuidorID.FromJSonString(Combo_distribuidorid_Selectedvalue_get, null);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV112DistribuidorID", AV112DistribuidorID);
      }

      protected void S162( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S132( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV17ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WPDetallePromocionAdminFacturaWCFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S192( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
         AV87TFFacturaFechaRegistro = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV87TFFacturaFechaRegistro", context.localUtil.Format(AV87TFFacturaFechaRegistro, "99/99/99"));
         AV88TFFacturaFechaRegistro_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV88TFFacturaFechaRegistro_To", context.localUtil.Format(AV88TFFacturaFechaRegistro_To, "99/99/99"));
         AV37TFPromocionDescripcion = "";
         AssignAttri(sPrefix, false, "AV37TFPromocionDescripcion", AV37TFPromocionDescripcion);
         AV38TFPromocionDescripcion_Sel = "";
         AssignAttri(sPrefix, false, "AV38TFPromocionDescripcion_Sel", AV38TFPromocionDescripcion_Sel);
         AV39TFFacturaNo = "";
         AssignAttri(sPrefix, false, "AV39TFFacturaNo", AV39TFFacturaNo);
         AV40TFFacturaNo_Sel = "";
         AssignAttri(sPrefix, false, "AV40TFFacturaNo_Sel", AV40TFFacturaNo_Sel);
         AV92TFFacturaFechaFactura = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV92TFFacturaFechaFactura", context.localUtil.Format(AV92TFFacturaFechaFactura, "99/99/99"));
         AV93TFFacturaFechaFactura_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV93TFFacturaFechaFactura_To", context.localUtil.Format(AV93TFFacturaFechaFactura_To, "99/99/99"));
         AV47TFEstatusOperator = 0;
         AssignAttri(sPrefix, false, "AV47TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV47TFEstatusOperator), 4, 0));
         Ddo_grid_Selectedfixedfilter = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
         AV56TFUsuarioNombreCompleto = "";
         AssignAttri(sPrefix, false, "AV56TFUsuarioNombreCompleto", AV56TFUsuarioNombreCompleto);
         AV57TFUsuarioNombreCompleto_Sel = "";
         AssignAttri(sPrefix, false, "AV57TFUsuarioNombreCompleto_Sel", AV57TFUsuarioNombreCompleto_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV120Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV120Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV16Session.Get(AV120Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
      }

      protected void S202( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV136GXV1 = 1;
         while ( AV136GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV136GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAREGISTRO") == 0 )
            {
               AV87TFFacturaFechaRegistro = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV87TFFacturaFechaRegistro", context.localUtil.Format(AV87TFFacturaFechaRegistro, "99/99/99"));
               AV88TFFacturaFechaRegistro_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV88TFFacturaFechaRegistro_To", context.localUtil.Format(AV88TFFacturaFechaRegistro_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION") == 0 )
            {
               AV37TFPromocionDescripcion = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV37TFPromocionDescripcion", AV37TFPromocionDescripcion);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION_SEL") == 0 )
            {
               AV38TFPromocionDescripcion_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV38TFPromocionDescripcion_Sel", AV38TFPromocionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFFACTURANO") == 0 )
            {
               AV39TFFacturaNo = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV39TFFacturaNo", AV39TFFacturaNo);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFFACTURANO_SEL") == 0 )
            {
               AV40TFFacturaNo_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV40TFFacturaNo_Sel", AV40TFFacturaNo_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAFACTURA") == 0 )
            {
               AV92TFFacturaFechaFactura = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV92TFFacturaFechaFactura", context.localUtil.Format(AV92TFFacturaFechaFactura, "99/99/99"));
               AV93TFFacturaFechaFactura_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV93TFFacturaFechaFactura_To", context.localUtil.Format(AV93TFFacturaFechaFactura_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFESTATUS") == 0 )
            {
               AV47TFEstatusOperator = AV12GridStateFilterValue.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV47TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV47TFEstatusOperator), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO") == 0 )
            {
               AV56TFUsuarioNombreCompleto = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV56TFUsuarioNombreCompleto", AV56TFUsuarioNombreCompleto);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO_SEL") == 0 )
            {
               AV57TFUsuarioNombreCompleto_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV57TFUsuarioNombreCompleto_Sel", AV57TFUsuarioNombreCompleto_Sel);
            }
            AV136GXV1 = (int)(AV136GXV1+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPromocionDescripcion_Sel)),  AV38TFPromocionDescripcion_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFFacturaNo_Sel)),  AV40TFFacturaNo_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV57TFUsuarioNombreCompleto_Sel)),  AV57TFUsuarioNombreCompleto_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char4+"|||"+GXt_char5;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFPromocionDescripcion)),  AV37TFPromocionDescripcion, out  GXt_char5) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFFacturaNo)),  AV39TFFacturaNo, out  GXt_char4) ;
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV56TFUsuarioNombreCompleto)),  AV56TFUsuarioNombreCompleto, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((DateTime.MinValue==AV87TFFacturaFechaRegistro) ? "" : context.localUtil.DToC( AV87TFFacturaFechaRegistro, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+GXt_char5+"|"+GXt_char4+"|"+((DateTime.MinValue==AV92TFFacturaFechaFactura) ? "" : context.localUtil.DToC( AV92TFFacturaFechaFactura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"||"+GXt_char2;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((DateTime.MinValue==AV88TFFacturaFechaRegistro_To) ? "" : context.localUtil.DToC( AV88TFFacturaFechaRegistro_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|||"+((DateTime.MinValue==AV93TFFacturaFechaFactura_To) ? "" : context.localUtil.DToC( AV93TFFacturaFechaFactura_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         Ddo_grid_Selectedfixedfilter = "||||"+((AV47TFEstatusOperator!=1) ? "" : "1")+((AV47TFEstatusOperator!=2) ? "" : "2")+((AV47TFEstatusOperator!=3) ? "" : "3")+((AV47TFEstatusOperator!=4) ? "" : "4")+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV16Session.Get(AV120Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFFACTURAFECHAREGISTRO",  context.GetMessage( "Fecha Registro", ""),  !((DateTime.MinValue==AV87TFFacturaFechaRegistro)&&(DateTime.MinValue==AV88TFFacturaFechaRegistro_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV87TFFacturaFechaRegistro, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV87TFFacturaFechaRegistro) ? "" : StringUtil.Trim( context.localUtil.Format( AV87TFFacturaFechaRegistro, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV88TFFacturaFechaRegistro_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV88TFFacturaFechaRegistro_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV88TFFacturaFechaRegistro_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROMOCIONDESCRIPCION",  context.GetMessage( "Nom. Promoción", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFPromocionDescripcion)),  0,  AV37TFPromocionDescripcion,  AV37TFPromocionDescripcion,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPromocionDescripcion_Sel)),  AV38TFPromocionDescripcion_Sel,  AV38TFPromocionDescripcion_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFFACTURANO",  context.GetMessage( "No. Factura", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFFacturaNo)),  0,  AV39TFFacturaNo,  AV39TFFacturaNo,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFFacturaNo_Sel)),  AV40TFFacturaNo_Sel,  AV40TFFacturaNo_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFFACTURAFECHAFACTURA",  context.GetMessage( "Fecha Factura", ""),  !((DateTime.MinValue==AV92TFFacturaFechaFactura)&&(DateTime.MinValue==AV93TFFacturaFechaFactura_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV92TFFacturaFechaFactura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV92TFFacturaFechaFactura) ? "" : StringUtil.Trim( context.localUtil.Format( AV92TFFacturaFechaFactura, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV93TFFacturaFechaFactura_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV93TFFacturaFechaFactura_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV93TFFacturaFechaFactura_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFESTATUS",  context.GetMessage( "Estatus", ""),  !(String.IsNullOrEmpty(StringUtil.RTrim( AV46TFEstatus))&&(0==AV47TFEstatusOperator)),  AV47TFEstatusOperator,  AV46TFEstatus,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV47TFEstatusOperator+1), 10, 0)), AV46TFEstatus, context.GetMessage( "En proceso", ""), context.GetMessage( "Aprobada", ""), context.GetMessage( "Rechazada", ""), context.GetMessage( "Cancelada", ""), "", "", "", ""),  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFUSUARIONOMBRECOMPLETO",  context.GetMessage( "Nombre completo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV56TFUsuarioNombreCompleto)),  0,  AV56TFUsuarioNombreCompleto,  AV56TFUsuarioNombreCompleto,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV57TFUsuarioNombreCompleto_Sel)),  AV57TFUsuarioNombreCompleto_Sel,  AV57TFUsuarioNombreCompleto_Sel) ;
         if ( ! (0==AV7PromocionID) )
         {
            AV12GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&PROMOCIONID";
            AV12GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV7PromocionID), 9, 0);
            AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV120Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S142( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV120Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Factura";
         AV10TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV10TrnContextAtt.gxTpr_Attributename = "PromocionID";
         AV10TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV7PromocionID), 9, 0);
         AV9TrnContext.gxTpr_Attributes.Add(AV10TrnContextAtt, 0);
         AV16Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S122( )
      {
         /* 'LOADCOMBODISTRIBUIDORID' Routine */
         returnInSub = false;
         /* Using cursor H003P4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A10DistribuidorID = H003P4_A10DistribuidorID[0];
            A11DistribuidorDescripcion = H003P4_A11DistribuidorDescripcion[0];
            AV115Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV115Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A10DistribuidorID), 9, 0));
            AV115Combo_DataItem.gxTpr_Title = A11DistribuidorDescripcion;
            AV113DistribuidorID_Data.Add(AV115Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_distribuidorid_Selectedvalue_set = AV112DistribuidorID.ToJSonString(false);
         ucCombo_distribuidorid.SendProperty(context, sPrefix, false, Combo_distribuidorid_Internalname, "SelectedValue_set", Combo_distribuidorid_Selectedvalue_set);
      }

      protected void E233P2( )
      {
         /* Useraction4_Click Routine */
         returnInSub = false;
         AV99FacturaID = A69FacturaID;
         AssignAttri(sPrefix, false, "AV99FacturaID", StringUtil.LTrimStr( (decimal)(AV99FacturaID), 9, 0));
         /* Execute user subroutine: 'OBTIENEPDF' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV84FileURL = context.PathToUrl( AV83Blob);
         Innwewindow_Target = AV84FileURL;
         ucInnwewindow.SendProperty(context, sPrefix, false, Innwewindow_Internalname, "Target", Innwewindow_Target);
         this.executeUsercontrolMethod(sPrefix, false, "INNWEWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E243P2( )
      {
         /* Useraction2_Click Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(AV119UsuarioCorreo, context.GetMessage( "lehr777@hotmail.com", "")) == 0 ) || ( StringUtil.StrCmp(AV119UsuarioCorreo, context.GetMessage( "mercadotecnia@yokohamatire.mx", "")) == 0 ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpcambiarestatus.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A69FacturaID,9,0));
            context.PopUp(formatLink("wpcambiarestatus.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            if ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                  {
                     gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                  }
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "wpcambiarestatus.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A69FacturaID,9,0));
               context.PopUp(formatLink("wpcambiarestatus.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
               context.DoAjaxRefreshCmp(sPrefix);
            }
            else
            {
               if ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "No se puede cambiar el estatus de esta factura porque ya ha sido aprobada", ""));
               }
               else if ( StringUtil.StrCmp(A80FacturaEstatus, "Cancelada") == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "No se puede cambiar el estatus de esta factura porque ya ha sido cancelada", ""));
               }
               else if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "No se puede cambiar el estatus de esta factura porque ya ha sido rechazada", ""));
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV116ListaUsuarios", AV116ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridState", AV11GridState);
      }

      protected void S182( )
      {
         /* 'OBTIENEDISTRIBUIDOR' Routine */
         returnInSub = false;
         /* Using cursor H003P5 */
         pr_default.execute(3, new Object[] {AV98RegUsuarioID});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A10DistribuidorID = H003P5_A10DistribuidorID[0];
            A29UsuarioID = H003P5_A29UsuarioID[0];
            A11DistribuidorDescripcion = H003P5_A11DistribuidorDescripcion[0];
            A81DistribuidoresUsuarioID = H003P5_A81DistribuidoresUsuarioID[0];
            A11DistribuidorDescripcion = H003P5_A11DistribuidorDescripcion[0];
            AV86DistribuidorDescripcionVar = A11DistribuidorDescripcion;
            AssignAttri(sPrefix, false, edtavDistribuidordescripcionvar_Internalname, AV86DistribuidorDescripcionVar);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S212( )
      {
         /* 'OBTIENEPDF' Routine */
         returnInSub = false;
         /* Using cursor H003P6 */
         pr_default.execute(4, new Object[] {AV99FacturaID});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A69FacturaID = H003P6_A69FacturaID[0];
            A40000FacturaPDF_GXI = H003P6_A40000FacturaPDF_GXI[0];
            A75FacturaPDF = H003P6_A75FacturaPDF[0];
            AV83Blob = A75FacturaPDF;
            AssignAttri(sPrefix, false, "AV83Blob", AV83Blob);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
      }

      protected void S112( )
      {
         /* 'OBTIENELISTAUSUARIOS' Routine */
         returnInSub = false;
         AV116ListaUsuarios.Clear();
         if ( AV112DistribuidorID.Count == 0 )
         {
            /* Using cursor H003P7 */
            pr_default.execute(5);
            while ( (pr_default.getStatus(5) != 101) )
            {
               A40UsuarioRol = H003P7_A40UsuarioRol[0];
               A29UsuarioID = H003P7_A29UsuarioID[0];
               A40UsuarioRol = H003P7_A40UsuarioRol[0];
               AV117Pasa = false;
               AV141GXV2 = 1;
               while ( AV141GXV2 <= AV116ListaUsuarios.Count )
               {
                  AV118UsuariosListaID = (int)(AV116ListaUsuarios.GetNumeric(AV141GXV2));
                  if ( AV118UsuariosListaID == A29UsuarioID )
                  {
                     AV117Pasa = true;
                     if (true) break;
                  }
                  AV141GXV2 = (int)(AV141GXV2+1);
               }
               if ( ! AV117Pasa )
               {
                  AV116ListaUsuarios.Add(A29UsuarioID, 0);
               }
               pr_default.readNext(5);
            }
            pr_default.close(5);
         }
         else
         {
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 A10DistribuidorID ,
                                                 AV112DistribuidorID ,
                                                 A40UsuarioRol } ,
                                                 new int[]{
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor H003P8 */
            pr_default.execute(6);
            while ( (pr_default.getStatus(6) != 101) )
            {
               A40UsuarioRol = H003P8_A40UsuarioRol[0];
               A10DistribuidorID = H003P8_A10DistribuidorID[0];
               A29UsuarioID = H003P8_A29UsuarioID[0];
               A40UsuarioRol = H003P8_A40UsuarioRol[0];
               AV117Pasa = false;
               AV143GXV3 = 1;
               while ( AV143GXV3 <= AV116ListaUsuarios.Count )
               {
                  AV118UsuariosListaID = (int)(AV116ListaUsuarios.GetNumeric(AV143GXV3));
                  if ( AV118UsuariosListaID == A29UsuarioID )
                  {
                     AV117Pasa = true;
                     if (true) break;
                  }
                  AV143GXV3 = (int)(AV143GXV3+1);
               }
               if ( ! AV117Pasa )
               {
                  AV116ListaUsuarios.Add(A29UsuarioID, 0);
               }
               pr_default.readNext(6);
            }
            pr_default.close(6);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7PromocionID = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV7PromocionID", StringUtil.LTrimStr( (decimal)(AV7PromocionID), 9, 0));
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
         PA3P2( ) ;
         WS3P2( ) ;
         WE3P2( ) ;
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
         sCtrlAV7PromocionID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3P2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpdetallepromocionadminfacturawc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3P2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV7PromocionID = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV7PromocionID", StringUtil.LTrimStr( (decimal)(AV7PromocionID), 9, 0));
         }
         wcpOAV7PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7PromocionID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV7PromocionID != wcpOAV7PromocionID ) ) )
         {
            setjustcreated();
         }
         wcpOAV7PromocionID = AV7PromocionID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV7PromocionID = cgiGet( sPrefix+"AV7PromocionID_CTRL");
         if ( StringUtil.Len( sCtrlAV7PromocionID) > 0 )
         {
            AV7PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV7PromocionID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV7PromocionID", StringUtil.LTrimStr( (decimal)(AV7PromocionID), 9, 0));
         }
         else
         {
            AV7PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV7PromocionID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA3P2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3P2( ) ;
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
         WS3P2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7PromocionID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7PromocionID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7PromocionID_CTRL", StringUtil.RTrim( sCtrlAV7PromocionID));
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
         WE3P2( ) ;
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20265111131915", true, true);
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
         context.AddJavascriptSource("wpdetallepromocionadminfacturawc.js", "?20265111131915", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Popover/WWPPopoverRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_672( )
      {
         edtFacturaID_Internalname = sPrefix+"FACTURAID_"+sGXsfl_67_idx;
         edtavUseraction4_Internalname = sPrefix+"vUSERACTION4_"+sGXsfl_67_idx;
         edtavUseraction8_Internalname = sPrefix+"vUSERACTION8_"+sGXsfl_67_idx;
         edtFacturaFechaRegistro_Internalname = sPrefix+"FACTURAFECHAREGISTRO_"+sGXsfl_67_idx;
         edtPromocionDescripcion_Internalname = sPrefix+"PROMOCIONDESCRIPCION_"+sGXsfl_67_idx;
         edtFacturaNo_Internalname = sPrefix+"FACTURANO_"+sGXsfl_67_idx;
         edtFacturaFechaFactura_Internalname = sPrefix+"FACTURAFECHAFACTURA_"+sGXsfl_67_idx;
         edtavPartidaswithtags_Internalname = sPrefix+"vPARTIDASWITHTAGS_"+sGXsfl_67_idx;
         edtavPartidas_Internalname = sPrefix+"vPARTIDAS_"+sGXsfl_67_idx;
         edtavUseraction2_Internalname = sPrefix+"vUSERACTION2_"+sGXsfl_67_idx;
         edtavEstatuswithtags_Internalname = sPrefix+"vESTATUSWITHTAGS_"+sGXsfl_67_idx;
         edtavEstatus_Internalname = sPrefix+"vESTATUS_"+sGXsfl_67_idx;
         edtavDescripcion_Internalname = sPrefix+"vDESCRIPCION_"+sGXsfl_67_idx;
         cmbFacturaEstatus_Internalname = sPrefix+"FACTURAESTATUS_"+sGXsfl_67_idx;
         edtUsuarioID_Internalname = sPrefix+"USUARIOID_"+sGXsfl_67_idx;
         edtUsuarioNombreCompleto_Internalname = sPrefix+"USUARIONOMBRECOMPLETO_"+sGXsfl_67_idx;
         chkMotivoRechazoActivo_Internalname = sPrefix+"MOTIVORECHAZOACTIVO_"+sGXsfl_67_idx;
         edtMotivoRechazoDescripcion_Internalname = sPrefix+"MOTIVORECHAZODESCRIPCION_"+sGXsfl_67_idx;
         edtMotivoRechazoID_Internalname = sPrefix+"MOTIVORECHAZOID_"+sGXsfl_67_idx;
         edtavDistribuidordescripcionvar_Internalname = sPrefix+"vDISTRIBUIDORDESCRIPCIONVAR_"+sGXsfl_67_idx;
      }

      protected void SubsflControlProps_fel_672( )
      {
         edtFacturaID_Internalname = sPrefix+"FACTURAID_"+sGXsfl_67_fel_idx;
         edtavUseraction4_Internalname = sPrefix+"vUSERACTION4_"+sGXsfl_67_fel_idx;
         edtavUseraction8_Internalname = sPrefix+"vUSERACTION8_"+sGXsfl_67_fel_idx;
         edtFacturaFechaRegistro_Internalname = sPrefix+"FACTURAFECHAREGISTRO_"+sGXsfl_67_fel_idx;
         edtPromocionDescripcion_Internalname = sPrefix+"PROMOCIONDESCRIPCION_"+sGXsfl_67_fel_idx;
         edtFacturaNo_Internalname = sPrefix+"FACTURANO_"+sGXsfl_67_fel_idx;
         edtFacturaFechaFactura_Internalname = sPrefix+"FACTURAFECHAFACTURA_"+sGXsfl_67_fel_idx;
         edtavPartidaswithtags_Internalname = sPrefix+"vPARTIDASWITHTAGS_"+sGXsfl_67_fel_idx;
         edtavPartidas_Internalname = sPrefix+"vPARTIDAS_"+sGXsfl_67_fel_idx;
         edtavUseraction2_Internalname = sPrefix+"vUSERACTION2_"+sGXsfl_67_fel_idx;
         edtavEstatuswithtags_Internalname = sPrefix+"vESTATUSWITHTAGS_"+sGXsfl_67_fel_idx;
         edtavEstatus_Internalname = sPrefix+"vESTATUS_"+sGXsfl_67_fel_idx;
         edtavDescripcion_Internalname = sPrefix+"vDESCRIPCION_"+sGXsfl_67_fel_idx;
         cmbFacturaEstatus_Internalname = sPrefix+"FACTURAESTATUS_"+sGXsfl_67_fel_idx;
         edtUsuarioID_Internalname = sPrefix+"USUARIOID_"+sGXsfl_67_fel_idx;
         edtUsuarioNombreCompleto_Internalname = sPrefix+"USUARIONOMBRECOMPLETO_"+sGXsfl_67_fel_idx;
         chkMotivoRechazoActivo_Internalname = sPrefix+"MOTIVORECHAZOACTIVO_"+sGXsfl_67_fel_idx;
         edtMotivoRechazoDescripcion_Internalname = sPrefix+"MOTIVORECHAZODESCRIPCION_"+sGXsfl_67_fel_idx;
         edtMotivoRechazoID_Internalname = sPrefix+"MOTIVORECHAZOID_"+sGXsfl_67_fel_idx;
         edtavDistribuidordescripcionvar_Internalname = sPrefix+"vDISTRIBUIDORDESCRIPCIONVAR_"+sGXsfl_67_fel_idx;
      }

      protected void sendrow_672( )
      {
         sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
         SubsflControlProps_672( ) ;
         WB3P0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_67_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_67_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar GridNoBorder WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_67_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',67)\"";
            ClassString = "BotonImagenChica" + " " + ((StringUtil.StrCmp(edtavUseraction4_gximage, "")==0) ? "" : "GX_Image_"+edtavUseraction4_gximage+"_Class");
            StyleString = "";
            AV62UserAction4_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV62UserAction4))&&String.IsNullOrEmpty(StringUtil.RTrim( AV135Useraction4_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV62UserAction4)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV62UserAction4)) ? AV135Useraction4_GXI : context.PathToRelativeUrl( AV62UserAction4));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseraction4_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)edtavUseraction4_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavUseraction4_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUSERACTION4.CLICK."+sGXsfl_67_idx+"'",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV62UserAction4_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',67)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseraction8_Internalname,StringUtil.RTrim( AV63UserAction8),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavUseraction8_Link,(string)"",(string)"",(string)"",(string)edtavUseraction8_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUseraction8_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaRegistro_Internalname,context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"),context.localUtil.Format( A72FacturaFechaRegistro, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaRegistro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionDescripcion_Internalname,(string)A42PromocionDescripcion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaNo_Internalname,StringUtil.RTrim( A71FacturaNo),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaNo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaFactura_Internalname,context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"),context.localUtil.Format( A73FacturaFechaFactura, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaFactura_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',67)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPartidaswithtags_Internalname,(string)AV97PartidasWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPartidaswithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnSizeLarge ColumnWeightBold ColumnHighlightBackground ColumnLeftDivision",(string)"",(short)-1,(int)edtavPartidaswithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPartidas_Internalname,StringUtil.RTrim( AV85Partidas),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVPARTIDAS.CLICK."+sGXsfl_67_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPartidas_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnSizeLarge ColumnWeightBold ColumnHighlightBackground ColumnLeftDivision",(string)"",(short)0,(int)edtavPartidas_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUseraction2_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',67)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseraction2_Internalname,StringUtil.RTrim( AV61UserAction2),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUSERACTION2.CLICK."+sGXsfl_67_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUseraction2_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWActionColumn",(string)"",(int)edtavUseraction2_Visible,(int)edtavUseraction2_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',67)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEstatuswithtags_Internalname,(string)AV60EstatusWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEstatuswithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavEstatuswithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEstatus_Internalname,StringUtil.RTrim( AV28Estatus),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEstatus_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavEstatus_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',67)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDescripcion_Internalname,(string)AV29Descripcion,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavDescripcion_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbFacturaEstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "FACTURAESTATUS_" + sGXsfl_67_idx;
               cmbFacturaEstatus.Name = GXCCtl;
               cmbFacturaEstatus.WebTags = "";
               cmbFacturaEstatus.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
               cmbFacturaEstatus.addItem("En Proceso", context.GetMessage( "En Proceso", ""), 0);
               cmbFacturaEstatus.addItem("Aprobada", context.GetMessage( "Aprobada", ""), 0);
               cmbFacturaEstatus.addItem("Rechazada", context.GetMessage( "Rechazada", ""), 0);
               cmbFacturaEstatus.addItem("Cancelada", context.GetMessage( "Cancelada", ""), 0);
               if ( cmbFacturaEstatus.ItemCount > 0 )
               {
                  A80FacturaEstatus = cmbFacturaEstatus.getValidValue(A80FacturaEstatus);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbFacturaEstatus,(string)cmbFacturaEstatus_Internalname,StringUtil.RTrim( A80FacturaEstatus),(short)1,(string)cmbFacturaEstatus_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbFacturaEstatus.CurrentValue = StringUtil.RTrim( A80FacturaEstatus);
            AssignProp(sPrefix, false, cmbFacturaEstatus_Internalname, "Values", (string)(cmbFacturaEstatus.ToJavascriptSource()), !bGXsfl_67_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombreCompleto_Internalname,(string)A52UsuarioNombreCompleto,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombreCompleto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "MOTIVORECHAZOACTIVO_" + sGXsfl_67_idx;
            chkMotivoRechazoActivo.Name = GXCCtl;
            chkMotivoRechazoActivo.WebTags = "";
            chkMotivoRechazoActivo.Caption = "";
            AssignProp(sPrefix, false, chkMotivoRechazoActivo_Internalname, "TitleCaption", chkMotivoRechazoActivo.Caption, !bGXsfl_67_Refreshing);
            chkMotivoRechazoActivo.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkMotivoRechazoActivo_Internalname,StringUtil.BoolToStr( A21MotivoRechazoActivo),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoRechazoDescripcion_Internalname,(string)A20MotivoRechazoDescripcion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoRechazoDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoRechazoID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MotivoRechazoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A19MotivoRechazoID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoRechazoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'" + sGXsfl_67_idx + "',67)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDistribuidordescripcionvar_Internalname,(string)AV86DistribuidorDescripcionVar,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDistribuidordescripcionvar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavDistribuidordescripcionvar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes3P2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_67_idx = ((subGrid_Islastpage==1)&&(nGXsfl_67_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_67_idx+1);
            sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
            SubsflControlProps_672( ) ;
         }
         /* End function sendrow_672 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "FACTURAESTATUS_" + sGXsfl_67_idx;
         cmbFacturaEstatus.Name = GXCCtl;
         cmbFacturaEstatus.WebTags = "";
         cmbFacturaEstatus.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbFacturaEstatus.addItem("En Proceso", context.GetMessage( "En Proceso", ""), 0);
         cmbFacturaEstatus.addItem("Aprobada", context.GetMessage( "Aprobada", ""), 0);
         cmbFacturaEstatus.addItem("Rechazada", context.GetMessage( "Rechazada", ""), 0);
         cmbFacturaEstatus.addItem("Cancelada", context.GetMessage( "Cancelada", ""), 0);
         if ( cmbFacturaEstatus.ItemCount > 0 )
         {
         }
         GXCCtl = "MOTIVORECHAZOACTIVO_" + sGXsfl_67_idx;
         chkMotivoRechazoActivo.Name = GXCCtl;
         chkMotivoRechazoActivo.WebTags = "";
         chkMotivoRechazoActivo.Caption = "";
         AssignProp(sPrefix, false, chkMotivoRechazoActivo_Internalname, "TitleCaption", chkMotivoRechazoActivo.Caption, !bGXsfl_67_Refreshing);
         chkMotivoRechazoActivo.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl67( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"67\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar GridNoBorder WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Folio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"BotonImagenChica"+" "+((StringUtil.StrCmp(edtavUseraction4_gximage, "")==0) ? "" : "GX_Image_"+edtavUseraction4_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Registro", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nom. Promoción", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "No. Factura", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Factura", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Partidas", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Partidas", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUseraction2_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estatus", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estatus", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Motivo de rechazo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estatus", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "UsuarioID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre completo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Motivo Rechazo Activo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Motivo de rechazo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Motivo Rechazo ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Distribuidor al que representa", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar GridNoBorder WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV62UserAction4));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUseraction4_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV63UserAction8)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction8_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUseraction8_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A42PromocionDescripcion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A71FacturaNo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A73FacturaFechaFactura, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV97PartidasWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPartidaswithtags_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV85Partidas)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPartidas_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV61UserAction2)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction2_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction2_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV60EstatusWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEstatuswithtags_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV28Estatus)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEstatus_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV29Descripcion));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDescripcion_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A80FacturaEstatus)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A52UsuarioNombreCompleto));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A21MotivoRechazoActivo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A20MotivoRechazoDescripcion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MotivoRechazoID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV86DistribuidorDescripcionVar));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDistribuidordescripcionvar_Enabled), 5, 0, ".", "")));
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
         edtavFromdate_Internalname = sPrefix+"vFROMDATE";
         edtavTodate_Internalname = sPrefix+"vTODATE";
         lblTextblockcombo_distribuidorid_Internalname = sPrefix+"TEXTBLOCKCOMBO_DISTRIBUIDORID";
         Combo_distribuidorid_Internalname = sPrefix+"COMBO_DISTRIBUIDORID";
         divTablesplitteddistribuidorid_Internalname = sPrefix+"TABLESPLITTEDDISTRIBUIDORID";
         bttBtnuseraction99_Internalname = sPrefix+"BTNUSERACTION99";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         Utchartdoughnut_Internalname = sPrefix+"UTCHARTDOUGHNUT";
         Utchartcolumnline_Internalname = sPrefix+"UTCHARTCOLUMNLINE";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         bttBtnexceldetallado_Internalname = sPrefix+"BTNEXCELDETALLADO";
         bttBtnexcelconcentrado_Internalname = sPrefix+"BTNEXCELCONCENTRADO";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         edtFacturaID_Internalname = sPrefix+"FACTURAID";
         edtavUseraction4_Internalname = sPrefix+"vUSERACTION4";
         edtavUseraction8_Internalname = sPrefix+"vUSERACTION8";
         edtFacturaFechaRegistro_Internalname = sPrefix+"FACTURAFECHAREGISTRO";
         edtPromocionDescripcion_Internalname = sPrefix+"PROMOCIONDESCRIPCION";
         edtFacturaNo_Internalname = sPrefix+"FACTURANO";
         edtFacturaFechaFactura_Internalname = sPrefix+"FACTURAFECHAFACTURA";
         edtavPartidaswithtags_Internalname = sPrefix+"vPARTIDASWITHTAGS";
         edtavPartidas_Internalname = sPrefix+"vPARTIDAS";
         edtavUseraction2_Internalname = sPrefix+"vUSERACTION2";
         edtavEstatuswithtags_Internalname = sPrefix+"vESTATUSWITHTAGS";
         edtavEstatus_Internalname = sPrefix+"vESTATUS";
         edtavDescripcion_Internalname = sPrefix+"vDESCRIPCION";
         cmbFacturaEstatus_Internalname = sPrefix+"FACTURAESTATUS";
         edtUsuarioID_Internalname = sPrefix+"USUARIOID";
         edtUsuarioNombreCompleto_Internalname = sPrefix+"USUARIONOMBRECOMPLETO";
         chkMotivoRechazoActivo_Internalname = sPrefix+"MOTIVORECHAZOACTIVO";
         edtMotivoRechazoDescripcion_Internalname = sPrefix+"MOTIVORECHAZODESCRIPCION";
         edtMotivoRechazoID_Internalname = sPrefix+"MOTIVORECHAZOID";
         edtavDistribuidordescripcionvar_Internalname = sPrefix+"vDISTRIBUIDORDESCRIPCIONVAR";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         Innwewindow_Internalname = sPrefix+"INNWEWINDOW";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Popover_partidas_Internalname = sPrefix+"POPOVER_PARTIDAS";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtPromocionID_Internalname = sPrefix+"PROMOCIONID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = sPrefix+"DIV_WWPAUXWC";
         edtavDdo_facturafecharegistroauxdatetext_Internalname = sPrefix+"vDDO_FACTURAFECHAREGISTROAUXDATETEXT";
         Tffacturafecharegistro_rangepicker_Internalname = sPrefix+"TFFACTURAFECHAREGISTRO_RANGEPICKER";
         divDdo_facturafecharegistroauxdates_Internalname = sPrefix+"DDO_FACTURAFECHAREGISTROAUXDATES";
         edtavDdo_facturafechafacturaauxdatetext_Internalname = sPrefix+"vDDO_FACTURAFECHAFACTURAAUXDATETEXT";
         Tffacturafechafactura_rangepicker_Internalname = sPrefix+"TFFACTURAFECHAFACTURA_RANGEPICKER";
         divDdo_facturafechafacturaauxdates_Internalname = sPrefix+"DDO_FACTURAFECHAFACTURAAUXDATES";
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
         edtavDistribuidordescripcionvar_Jsonclick = "";
         edtavDistribuidordescripcionvar_Enabled = 1;
         edtMotivoRechazoID_Jsonclick = "";
         edtMotivoRechazoDescripcion_Jsonclick = "";
         chkMotivoRechazoActivo.Caption = "";
         edtUsuarioNombreCompleto_Jsonclick = "";
         edtUsuarioID_Jsonclick = "";
         cmbFacturaEstatus_Jsonclick = "";
         edtavDescripcion_Jsonclick = "";
         edtavDescripcion_Enabled = 1;
         edtavEstatus_Jsonclick = "";
         edtavEstatus_Enabled = 1;
         edtavEstatuswithtags_Jsonclick = "";
         edtavEstatuswithtags_Enabled = 1;
         edtavUseraction2_Jsonclick = "";
         edtavUseraction2_Enabled = 1;
         edtavPartidas_Jsonclick = "";
         edtavPartidas_Enabled = 1;
         edtavPartidaswithtags_Jsonclick = "";
         edtavPartidaswithtags_Enabled = 1;
         edtFacturaFechaFactura_Jsonclick = "";
         edtFacturaNo_Jsonclick = "";
         edtPromocionDescripcion_Jsonclick = "";
         edtFacturaFechaRegistro_Jsonclick = "";
         edtavUseraction8_Jsonclick = "";
         edtavUseraction8_Link = "";
         edtavUseraction8_Enabled = 1;
         edtavUseraction4_Jsonclick = "";
         edtavUseraction4_gximage = "";
         edtavUseraction4_Tooltiptext = "";
         edtFacturaID_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridNoBorder WorkWith";
         subGrid_Backcolorstyle = 0;
         edtPromocionID_Enabled = 0;
         edtMotivoRechazoID_Enabled = 0;
         edtMotivoRechazoDescripcion_Enabled = 0;
         chkMotivoRechazoActivo.Enabled = 0;
         edtUsuarioNombreCompleto_Enabled = 0;
         edtUsuarioID_Enabled = 0;
         cmbFacturaEstatus.Enabled = 0;
         edtFacturaFechaFactura_Enabled = 0;
         edtFacturaNo_Enabled = 0;
         edtPromocionDescripcion_Enabled = 0;
         edtFacturaFechaRegistro_Enabled = 0;
         edtFacturaID_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_facturafechafacturaauxdatetext_Jsonclick = "";
         edtavDdo_facturafecharegistroauxdatetext_Jsonclick = "";
         edtPromocionID_Jsonclick = "";
         edtPromocionID_Visible = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Combo_distribuidorid_Caption = "";
         edtavTodate_Jsonclick = "";
         edtavTodate_Enabled = 1;
         edtavFromdate_Jsonclick = "";
         edtavFromdate_Enabled = 1;
         Grid_empowerer_Popoversingrid = "Popover_Partidas";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Fixedfilters = "||||1:En proceso:fa fa-circle FontColorIconWarning FontColorIconSmall ConditionalFormattingFilterIcon,2:Aprobada:fa fa-circle FontColorIconSuccess FontColorIconSmall ConditionalFormattingFilterIcon,3:Rechazada:fa fa-circle FontColorIconDanger FontColorIconSmall ConditionalFormattingFilterIcon,4:Cancelada:fa fa-circle FontColorIconInfo FontColorIconSmall ConditionalFormattingFilterIcon|";
         Ddo_grid_Datalistproc = "WPDetallePromocionAdminFacturaWCGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|||Dynamic";
         Ddo_grid_Includedatalist = "|T|T|||T";
         Ddo_grid_Filterisrange = "P|||P||";
         Ddo_grid_Filtertype = "Date|Character|Character|Date||Character";
         Ddo_grid_Includefilter = "T|T|T|T||T";
         Ddo_grid_Includesortasc = "T|T|T|T||";
         Ddo_grid_Columnssortvalues = "2|3|1|4||";
         Ddo_grid_Columnids = "3:FacturaFechaRegistro|4:PromocionDescripcion|5:FacturaNo|6:FacturaFechaFactura|10:Estatus|15:UsuarioNombreCompleto";
         Ddo_grid_Gridinternalname = "";
         Popover_partidas_Keepopened = Convert.ToBoolean( 0);
         Popover_partidas_Position = "Bottom";
         Popover_partidas_Popoverwidth = 400;
         Popover_partidas_Trigger = "Click";
         Popover_partidas_Isgriditem = Convert.ToBoolean( -1);
         Popover_partidas_Iteminternalname = "";
         Innwewindow_Target = "";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Utchartcolumnline_Title = context.GetMessage( "Bonos", "");
         Utchartcolumnline_Type = "Chart";
         Utchartcolumnline_Objectcall = "";
         Utchartdoughnut_Charttype = "Doughnut";
         Utchartdoughnut_Showvalues = Convert.ToBoolean( -1);
         Utchartdoughnut_Title = context.GetMessage( "Estatus", "");
         Utchartdoughnut_Type = "Chart";
         Utchartdoughnut_Objectcall = "";
         Combo_distribuidorid_Multiplevaluestype = "Tags";
         Combo_distribuidorid_Emptyitem = Convert.ToBoolean( 0);
         Combo_distribuidorid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_distribuidorid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_distribuidorid_Cls = "ExtendedCombo AttributeFL";
         edtavUseraction2_Visible = -1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV100FromDate","fld":"vFROMDATE"},{"av":"AV101ToDate","fld":"vTODATE"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV28Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV121Wpdetallepromocionadminfacturawcds_1_promocionid","fld":"vWPDETALLEPROMOCIONADMINFACTURAWCDS_1_PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"sPrefix"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV7PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV120Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV87TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV88TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV37TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV38TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV39TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV40TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV92TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV93TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV46TFEstatus","fld":"vTFESTATUS"},{"av":"AV47TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV56TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV57TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV112DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"AV98RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV119UsuarioCorreo","fld":"vUSUARIOCORREO","hsh":true},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV23GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV24GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV25GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV116ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E133P2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV100FromDate","fld":"vFROMDATE"},{"av":"AV101ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV7PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV120Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV87TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV88TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV37TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV38TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV39TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV40TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV92TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV93TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV46TFEstatus","fld":"vTFESTATUS"},{"av":"AV47TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV56TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV57TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV112DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV28Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV98RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV121Wpdetallepromocionadminfacturawcds_1_promocionid","fld":"vWPDETALLEPROMOCIONADMINFACTURAWCDS_1_PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV119UsuarioCorreo","fld":"vUSUARIOCORREO","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E143P2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV100FromDate","fld":"vFROMDATE"},{"av":"AV101ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV7PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV120Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV87TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV88TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV37TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV38TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV39TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV40TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV92TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV93TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV46TFEstatus","fld":"vTFESTATUS"},{"av":"AV47TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV56TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV57TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV112DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV28Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV98RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV121Wpdetallepromocionadminfacturawcds_1_promocionid","fld":"vWPDETALLEPROMOCIONADMINFACTURAWCDS_1_PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV119UsuarioCorreo","fld":"vUSUARIOCORREO","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E153P2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV100FromDate","fld":"vFROMDATE"},{"av":"AV101ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV7PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV120Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV87TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV88TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV37TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV38TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV39TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV40TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV92TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV93TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV46TFEstatus","fld":"vTFESTATUS"},{"av":"AV47TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV56TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV57TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV112DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV28Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV98RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV121Wpdetallepromocionadminfacturawcds_1_promocionid","fld":"vWPDETALLEPROMOCIONADMINFACTURAWCDS_1_PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV119UsuarioCorreo","fld":"vUSUARIOCORREO","hsh":true},{"av":"sPrefix"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Selectedcolumnfixedfilter","ctrl":"DDO_GRID","prop":"SelectedColumnFixedFilter"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV56TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV57TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV46TFEstatus","fld":"vTFESTATUS"},{"av":"AV47TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV92TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV93TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV39TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV40TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV37TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV38TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV87TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV88TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E213P2","iparms":[{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS","hsh":true},{"av":"A20MotivoRechazoDescripcion","fld":"MOTIVORECHAZODESCRIPCION"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV28Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV98RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV29Descripcion","fld":"vDESCRIPCION"},{"av":"AV85Partidas","fld":"vPARTIDAS"},{"av":"AV98RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV62UserAction4","fld":"vUSERACTION4"},{"av":"edtavUseraction4_Tooltiptext","ctrl":"vUSERACTION4","prop":"Tooltiptext"},{"av":"AV63UserAction8","fld":"vUSERACTION8"},{"av":"edtavUseraction8_Link","ctrl":"vUSERACTION8","prop":"Link"},{"av":"AV61UserAction2","fld":"vUSERACTION2"},{"av":"AV97PartidasWithTags","fld":"vPARTIDASWITHTAGS"},{"av":"AV60EstatusWithTags","fld":"vESTATUSWITHTAGS"},{"av":"AV86DistribuidorDescripcionVar","fld":"vDISTRIBUIDORDESCRIPCIONVAR"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E123P2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV100FromDate","fld":"vFROMDATE"},{"av":"AV101ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV7PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV120Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV87TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV88TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV37TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV38TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV39TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV40TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV92TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV93TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV46TFEstatus","fld":"vTFESTATUS"},{"av":"AV47TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV56TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV57TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV112DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV28Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV98RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV121Wpdetallepromocionadminfacturawcds_1_promocionid","fld":"vWPDETALLEPROMOCIONADMINFACTURAWCDS_1_PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV119UsuarioCorreo","fld":"vUSUARIOCORREO","hsh":true},{"av":"sPrefix"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV87TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV88TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV37TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV38TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV39TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV40TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV92TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV93TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV47TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"Ddo_grid_Selectedfixedfilter","ctrl":"DDO_GRID","prop":"SelectedFixedFilter"},{"av":"AV56TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV57TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV23GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV24GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV25GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV116ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOEXCELDETALLADO'","""{"handler":"E163P2","iparms":[{"av":"AV7PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"}]}""");
         setEventMetadata("'DOEXCELCONCENTRADO'","""{"handler":"E173P2","iparms":[{"av":"AV7PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"}]}""");
         setEventMetadata("'DOUSERACTION99'","""{"handler":"E183P2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV100FromDate","fld":"vFROMDATE"},{"av":"AV101ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV7PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV120Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV87TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV88TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV37TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV38TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV39TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV40TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV92TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV93TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV46TFEstatus","fld":"vTFESTATUS"},{"av":"AV47TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV56TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV57TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV112DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV28Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV98RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV121Wpdetallepromocionadminfacturawcds_1_promocionid","fld":"vWPDETALLEPROMOCIONADMINFACTURAWCDS_1_PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV119UsuarioCorreo","fld":"vUSUARIOCORREO","hsh":true},{"av":"sPrefix"},{"av":"AV116ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOUSERACTION99'",""","oparms":[{"ctrl":"UTCHARTDOUGHNUT"},{"ctrl":"UTCHARTCOLUMNLINE"},{"av":"AV116ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV23GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV24GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV25GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VPARTIDAS.CLICK","""{"handler":"E223P2","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("VPARTIDAS.CLICK",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("COMBO_DISTRIBUIDORID.ONOPTIONCLICKED","""{"handler":"E113P2","iparms":[{"av":"Combo_distribuidorid_Selectedvalue_get","ctrl":"COMBO_DISTRIBUIDORID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_DISTRIBUIDORID.ONOPTIONCLICKED",""","oparms":[{"av":"AV112DistribuidorID","fld":"vDISTRIBUIDORID"}]}""");
         setEventMetadata("VUSERACTION4.CLICK","""{"handler":"E233P2","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV83Blob","fld":"vBLOB"},{"av":"AV99FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"A75FacturaPDF","fld":"FACTURAPDF"}]""");
         setEventMetadata("VUSERACTION4.CLICK",""","oparms":[{"av":"AV99FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"Innwewindow_Target","ctrl":"INNWEWINDOW","prop":"Target"},{"av":"AV83Blob","fld":"vBLOB"}]}""");
         setEventMetadata("VUSERACTION2.CLICK","""{"handler":"E243P2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV100FromDate","fld":"vFROMDATE"},{"av":"AV101ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV7PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV120Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV87TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV88TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV37TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV38TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV39TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV40TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV92TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV93TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV46TFEstatus","fld":"vTFESTATUS"},{"av":"AV47TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV56TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV57TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV112DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV28Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV98RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV121Wpdetallepromocionadminfacturawcds_1_promocionid","fld":"vWPDETALLEPROMOCIONADMINFACTURAWCDS_1_PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV119UsuarioCorreo","fld":"vUSUARIOCORREO","hsh":true},{"av":"sPrefix"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS","hsh":true},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("VUSERACTION2.CLICK",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV23GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV24GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV25GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV116ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VALIDV_FROMDATE","""{"handler":"Validv_Fromdate","iparms":[]}""");
         setEventMetadata("VALIDV_TODATE","""{"handler":"Validv_Todate","iparms":[]}""");
         setEventMetadata("VALID_PROMOCIONID","""{"handler":"Valid_Promocionid","iparms":[]}""");
         setEventMetadata("VALID_USUARIOID","""{"handler":"Valid_Usuarioid","iparms":[]}""");
         setEventMetadata("VALID_MOTIVORECHAZOID","""{"handler":"Valid_Motivorechazoid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Distribuidordescripcionvar","iparms":[]}""");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Selectedcolumnfixedfilter = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         Combo_distribuidorid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV100FromDate = DateTime.MinValue;
         AV101ToDate = DateTime.MinValue;
         AV15FilterFullText = "";
         AV120Pgmname = "";
         AV87TFFacturaFechaRegistro = DateTime.MinValue;
         AV88TFFacturaFechaRegistro_To = DateTime.MinValue;
         AV37TFPromocionDescripcion = "";
         AV38TFPromocionDescripcion_Sel = "";
         AV39TFFacturaNo = "";
         AV40TFFacturaNo_Sel = "";
         AV92TFFacturaFechaFactura = DateTime.MinValue;
         AV93TFFacturaFechaFactura_To = DateTime.MinValue;
         AV46TFEstatus = "";
         AV56TFUsuarioNombreCompleto = "";
         AV57TFUsuarioNombreCompleto_Sel = "";
         AV112DistribuidorID = new GxSimpleCollection<int>();
         A40UsuarioRol = "";
         AV28Estatus = "";
         A11DistribuidorDescripcion = "";
         AV119UsuarioCorreo = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV20DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV113DistribuidorID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV102Elements = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         AV103Parameters = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter>( context, "Parameter", "GeneXus.Reporting");
         AV104ItemClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData(context);
         AV105ItemDoubleClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData(context);
         AV106DragAndDropData = new GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData(context);
         AV107FilterChangedData = new GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData(context);
         AV108ItemExpandData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData(context);
         AV109ItemCollapseData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData(context);
         AV17ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV25GridAppliedFilters = "";
         AV90DDO_FacturaFechaRegistroAuxDateTo = DateTime.MinValue;
         AV95DDO_FacturaFechaFacturaAuxDateTo = DateTime.MinValue;
         AV11GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV116ListaUsuarios = new GxSimpleCollection<int>();
         AV83Blob = "";
         A75FacturaPDF = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         AV89DDO_FacturaFechaRegistroAuxDate = DateTime.MinValue;
         AV94DDO_FacturaFechaFacturaAuxDate = DateTime.MinValue;
         Combo_distribuidorid_Selectedvalue_set = "";
         Popover_partidas_Gridinternalname = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_grid_Selectedfixedfilter = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         TempTags = "";
         lblTextblockcombo_distribuidorid_Jsonclick = "";
         ucCombo_distribuidorid = new GXUserControl();
         ClassString = "";
         StyleString = "";
         bttBtnuseraction99_Jsonclick = "";
         ucUtchartdoughnut = new GXUserControl();
         ucUtchartcolumnline = new GXUserControl();
         bttBtnexceldetallado_Jsonclick = "";
         bttBtnexcelconcentrado_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucInnwewindow = new GXUserControl();
         ucPopover_partidas = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV91DDO_FacturaFechaRegistroAuxDateText = "";
         ucTffacturafecharegistro_rangepicker = new GXUserControl();
         AV96DDO_FacturaFechaFacturaAuxDateText = "";
         ucTffacturafechafactura_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV62UserAction4 = "";
         AV135Useraction4_GXI = "";
         AV63UserAction8 = "";
         A72FacturaFechaRegistro = DateTime.MinValue;
         A42PromocionDescripcion = "";
         A71FacturaNo = "";
         A73FacturaFechaFactura = DateTime.MinValue;
         AV97PartidasWithTags = "";
         AV85Partidas = "";
         AV61UserAction2 = "";
         AV60EstatusWithTags = "";
         AV29Descripcion = "";
         A80FacturaEstatus = "";
         A52UsuarioNombreCompleto = "";
         A20MotivoRechazoDescripcion = "";
         AV86DistribuidorDescripcionVar = "";
         GXDecQS = "";
         lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext = "";
         lV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = "";
         lV127Wpdetallepromocionadminfacturawcds_7_tffacturano = "";
         lV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = "";
         AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext = "";
         AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro = DateTime.MinValue;
         AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to = DateTime.MinValue;
         AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel = "";
         AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion = "";
         AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel = "";
         AV127Wpdetallepromocionadminfacturawcds_7_tffacturano = "";
         AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura = DateTime.MinValue;
         AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to = DateTime.MinValue;
         AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel = "";
         AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto = "";
         H003P2_A41PromocionID = new int[1] ;
         H003P2_A19MotivoRechazoID = new int[1] ;
         H003P2_A20MotivoRechazoDescripcion = new string[] {""} ;
         H003P2_A21MotivoRechazoActivo = new bool[] {false} ;
         H003P2_A29UsuarioID = new int[1] ;
         H003P2_A80FacturaEstatus = new string[] {""} ;
         H003P2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         H003P2_A71FacturaNo = new string[] {""} ;
         H003P2_A42PromocionDescripcion = new string[] {""} ;
         H003P2_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         H003P2_A69FacturaID = new int[1] ;
         H003P2_A51UsuarioApellido = new string[] {""} ;
         H003P2_A30UsuarioNombre = new string[] {""} ;
         AV131Wpdetallepromocionadminfacturawcds_11_tfestatus = "";
         H003P3_AGRID_nRecordCount = new long[1] ;
         AV65UsuarioJSON = "";
         AV66WebSession = context.GetSession();
         AV67SDTUsuario = new SdtSDTUsuario(context);
         AV68UsuarioRol = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV18ManageFiltersXml = "";
         AV80ExcelFilename = "";
         AV79ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV16Session = context.GetSession();
         AV12GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV10TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         H003P4_A10DistribuidorID = new int[1] ;
         H003P4_A11DistribuidorDescripcion = new string[] {""} ;
         AV115Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV84FileURL = "";
         H003P5_A10DistribuidorID = new int[1] ;
         H003P5_A29UsuarioID = new int[1] ;
         H003P5_A11DistribuidorDescripcion = new string[] {""} ;
         H003P5_A81DistribuidoresUsuarioID = new int[1] ;
         H003P6_A69FacturaID = new int[1] ;
         H003P6_A40000FacturaPDF_GXI = new string[] {""} ;
         H003P6_A75FacturaPDF = new string[] {""} ;
         A40000FacturaPDF_GXI = "";
         H003P7_A81DistribuidoresUsuarioID = new int[1] ;
         H003P7_A40UsuarioRol = new string[] {""} ;
         H003P7_A29UsuarioID = new int[1] ;
         H003P8_A81DistribuidoresUsuarioID = new int[1] ;
         H003P8_A40UsuarioRol = new string[] {""} ;
         H003P8_A10DistribuidorID = new int[1] ;
         H003P8_A29UsuarioID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV7PromocionID = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpdetallepromocionadminfacturawc__default(),
            new Object[][] {
                new Object[] {
               H003P2_A41PromocionID, H003P2_A19MotivoRechazoID, H003P2_A20MotivoRechazoDescripcion, H003P2_A21MotivoRechazoActivo, H003P2_A29UsuarioID, H003P2_A80FacturaEstatus, H003P2_A73FacturaFechaFactura, H003P2_A71FacturaNo, H003P2_A42PromocionDescripcion, H003P2_A72FacturaFechaRegistro,
               H003P2_A69FacturaID, H003P2_A51UsuarioApellido, H003P2_A30UsuarioNombre
               }
               , new Object[] {
               H003P3_AGRID_nRecordCount
               }
               , new Object[] {
               H003P4_A10DistribuidorID, H003P4_A11DistribuidorDescripcion
               }
               , new Object[] {
               H003P5_A10DistribuidorID, H003P5_A29UsuarioID, H003P5_A11DistribuidorDescripcion, H003P5_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               H003P6_A69FacturaID, H003P6_A40000FacturaPDF_GXI, H003P6_A75FacturaPDF
               }
               , new Object[] {
               H003P7_A81DistribuidoresUsuarioID, H003P7_A40UsuarioRol, H003P7_A29UsuarioID
               }
               , new Object[] {
               H003P8_A81DistribuidoresUsuarioID, H003P8_A40UsuarioRol, H003P8_A10DistribuidorID, H003P8_A29UsuarioID
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV120Pgmname = "WPDetallePromocionAdminFacturaWC";
         /* GeneXus formulas. */
         AV120Pgmname = "WPDetallePromocionAdminFacturaWC";
         edtavUseraction8_Enabled = 0;
         edtavPartidaswithtags_Enabled = 0;
         edtavPartidas_Enabled = 0;
         edtavUseraction2_Enabled = 0;
         edtavEstatuswithtags_Enabled = 0;
         edtavEstatus_Enabled = 0;
         edtavDescripcion_Enabled = 0;
         edtavDistribuidordescripcionvar_Enabled = 0;
      }

      private short GRID_nEOF ;
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
      private short AV13OrderedBy ;
      private short AV19ManageFiltersExecutionStep ;
      private short AV47TFEstatusOperator ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV7PromocionID ;
      private int wcpOAV7PromocionID ;
      private int edtavUseraction2_Visible ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_67 ;
      private int nGXsfl_67_idx=1 ;
      private int A10DistribuidorID ;
      private int A81DistribuidoresUsuarioID ;
      private int AV98RegUsuarioID ;
      private int AV121Wpdetallepromocionadminfacturawcds_1_promocionid ;
      private int edtavUseraction8_Enabled ;
      private int edtavPartidaswithtags_Enabled ;
      private int edtavPartidas_Enabled ;
      private int edtavUseraction2_Enabled ;
      private int edtavEstatuswithtags_Enabled ;
      private int edtavEstatus_Enabled ;
      private int edtavDescripcion_Enabled ;
      private int edtavDistribuidordescripcionvar_Enabled ;
      private int AV99FacturaID ;
      private int Gridpaginationbar_Pagestoshow ;
      private int Popover_partidas_Popoverwidth ;
      private int edtavFromdate_Enabled ;
      private int edtavTodate_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int A41PromocionID ;
      private int edtPromocionID_Visible ;
      private int A69FacturaID ;
      private int A29UsuarioID ;
      private int A19MotivoRechazoID ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV116ListaUsuarios_Count ;
      private int edtFacturaID_Enabled ;
      private int edtFacturaFechaRegistro_Enabled ;
      private int edtPromocionDescripcion_Enabled ;
      private int edtFacturaNo_Enabled ;
      private int edtFacturaFechaFactura_Enabled ;
      private int edtUsuarioID_Enabled ;
      private int edtUsuarioNombreCompleto_Enabled ;
      private int edtMotivoRechazoDescripcion_Enabled ;
      private int edtMotivoRechazoID_Enabled ;
      private int edtPromocionID_Enabled ;
      private int AV22PageToGo ;
      private int AV136GXV1 ;
      private int AV141GXV2 ;
      private int AV118UsuariosListaID ;
      private int AV143GXV3 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV23GridCurrentPage ;
      private long AV24GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Selectedcolumnfixedfilter ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Combo_distribuidorid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_67_idx="0001" ;
      private string edtavUseraction2_Internalname ;
      private string AV120Pgmname ;
      private string AV39TFFacturaNo ;
      private string AV40TFFacturaNo_Sel ;
      private string AV46TFEstatus ;
      private string A40UsuarioRol ;
      private string AV28Estatus ;
      private string edtavUseraction8_Internalname ;
      private string edtavPartidaswithtags_Internalname ;
      private string edtavPartidas_Internalname ;
      private string edtavEstatuswithtags_Internalname ;
      private string edtavEstatus_Internalname ;
      private string edtavDescripcion_Internalname ;
      private string edtavDistribuidordescripcionvar_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
      private string Combo_distribuidorid_Cls ;
      private string Combo_distribuidorid_Selectedvalue_set ;
      private string Combo_distribuidorid_Multiplevaluestype ;
      private string Utchartdoughnut_Objectcall ;
      private string Utchartdoughnut_Type ;
      private string Utchartdoughnut_Title ;
      private string Utchartdoughnut_Charttype ;
      private string Utchartcolumnline_Objectcall ;
      private string Utchartcolumnline_Type ;
      private string Utchartcolumnline_Title ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Innwewindow_Target ;
      private string Popover_partidas_Gridinternalname ;
      private string Popover_partidas_Iteminternalname ;
      private string Popover_partidas_Trigger ;
      private string Popover_partidas_Position ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Fixedfilters ;
      private string Ddo_grid_Selectedfixedfilter ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Popoversingrid ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablegridheader_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtavFromdate_Internalname ;
      private string TempTags ;
      private string edtavFromdate_Jsonclick ;
      private string edtavTodate_Internalname ;
      private string edtavTodate_Jsonclick ;
      private string divTablesplitteddistribuidorid_Internalname ;
      private string lblTextblockcombo_distribuidorid_Internalname ;
      private string lblTextblockcombo_distribuidorid_Jsonclick ;
      private string Combo_distribuidorid_Caption ;
      private string Combo_distribuidorid_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnuseraction99_Internalname ;
      private string bttBtnuseraction99_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string Utchartdoughnut_Internalname ;
      private string Utchartcolumnline_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string bttBtnexceldetallado_Internalname ;
      private string bttBtnexceldetallado_Jsonclick ;
      private string bttBtnexcelconcentrado_Internalname ;
      private string bttBtnexcelconcentrado_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string Innwewindow_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Popover_partidas_Internalname ;
      private string Ddo_grid_Internalname ;
      private string edtPromocionID_Internalname ;
      private string edtPromocionID_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string divDdo_facturafecharegistroauxdates_Internalname ;
      private string edtavDdo_facturafecharegistroauxdatetext_Internalname ;
      private string edtavDdo_facturafecharegistroauxdatetext_Jsonclick ;
      private string Tffacturafecharegistro_rangepicker_Internalname ;
      private string divDdo_facturafechafacturaauxdates_Internalname ;
      private string edtavDdo_facturafechafacturaauxdatetext_Internalname ;
      private string edtavDdo_facturafechafacturaauxdatetext_Jsonclick ;
      private string Tffacturafechafactura_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtFacturaID_Internalname ;
      private string edtavUseraction4_Internalname ;
      private string AV63UserAction8 ;
      private string edtFacturaFechaRegistro_Internalname ;
      private string edtPromocionDescripcion_Internalname ;
      private string A71FacturaNo ;
      private string edtFacturaNo_Internalname ;
      private string edtFacturaFechaFactura_Internalname ;
      private string AV85Partidas ;
      private string AV61UserAction2 ;
      private string cmbFacturaEstatus_Internalname ;
      private string A80FacturaEstatus ;
      private string edtUsuarioID_Internalname ;
      private string edtUsuarioNombreCompleto_Internalname ;
      private string chkMotivoRechazoActivo_Internalname ;
      private string edtMotivoRechazoDescripcion_Internalname ;
      private string edtMotivoRechazoID_Internalname ;
      private string GXDecQS ;
      private string lV127Wpdetallepromocionadminfacturawcds_7_tffacturano ;
      private string AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel ;
      private string AV127Wpdetallepromocionadminfacturawcds_7_tffacturano ;
      private string AV131Wpdetallepromocionadminfacturawcds_11_tfestatus ;
      private string AV68UsuarioRol ;
      private string edtavUseraction4_gximage ;
      private string edtavUseraction4_Tooltiptext ;
      private string edtavUseraction8_Link ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string sCtrlAV7PromocionID ;
      private string sGXsfl_67_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtFacturaID_Jsonclick ;
      private string sImgUrl ;
      private string edtavUseraction4_Jsonclick ;
      private string edtavUseraction8_Jsonclick ;
      private string edtFacturaFechaRegistro_Jsonclick ;
      private string edtPromocionDescripcion_Jsonclick ;
      private string edtFacturaNo_Jsonclick ;
      private string edtFacturaFechaFactura_Jsonclick ;
      private string edtavPartidaswithtags_Jsonclick ;
      private string edtavPartidas_Jsonclick ;
      private string edtavUseraction2_Jsonclick ;
      private string edtavEstatuswithtags_Jsonclick ;
      private string edtavEstatus_Jsonclick ;
      private string edtavDescripcion_Jsonclick ;
      private string GXCCtl ;
      private string cmbFacturaEstatus_Jsonclick ;
      private string edtUsuarioID_Jsonclick ;
      private string edtUsuarioNombreCompleto_Jsonclick ;
      private string edtMotivoRechazoDescripcion_Jsonclick ;
      private string edtMotivoRechazoID_Jsonclick ;
      private string edtavDistribuidordescripcionvar_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV100FromDate ;
      private DateTime AV101ToDate ;
      private DateTime AV87TFFacturaFechaRegistro ;
      private DateTime AV88TFFacturaFechaRegistro_To ;
      private DateTime AV92TFFacturaFechaFactura ;
      private DateTime AV93TFFacturaFechaFactura_To ;
      private DateTime AV90DDO_FacturaFechaRegistroAuxDateTo ;
      private DateTime AV95DDO_FacturaFechaFacturaAuxDateTo ;
      private DateTime AV89DDO_FacturaFechaRegistroAuxDate ;
      private DateTime AV94DDO_FacturaFechaFacturaAuxDate ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A73FacturaFechaFactura ;
      private DateTime AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro ;
      private DateTime AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to ;
      private DateTime AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura ;
      private DateTime AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_67_Refreshing=false ;
      private bool AV14OrderedDsc ;
      private bool Combo_distribuidorid_Allowmultipleselection ;
      private bool Combo_distribuidorid_Includeonlyselectedoption ;
      private bool Combo_distribuidorid_Emptyitem ;
      private bool Utchartdoughnut_Showvalues ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Popover_partidas_Isgriditem ;
      private bool Popover_partidas_Keepopened ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool A21MotivoRechazoActivo ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV117Pasa ;
      private bool AV62UserAction4_IsBlob ;
      private string AV65UsuarioJSON ;
      private string AV18ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV37TFPromocionDescripcion ;
      private string AV38TFPromocionDescripcion_Sel ;
      private string AV56TFUsuarioNombreCompleto ;
      private string AV57TFUsuarioNombreCompleto_Sel ;
      private string A11DistribuidorDescripcion ;
      private string AV119UsuarioCorreo ;
      private string AV25GridAppliedFilters ;
      private string AV91DDO_FacturaFechaRegistroAuxDateText ;
      private string AV96DDO_FacturaFechaFacturaAuxDateText ;
      private string AV135Useraction4_GXI ;
      private string A42PromocionDescripcion ;
      private string AV97PartidasWithTags ;
      private string AV60EstatusWithTags ;
      private string AV29Descripcion ;
      private string A52UsuarioNombreCompleto ;
      private string A20MotivoRechazoDescripcion ;
      private string AV86DistribuidorDescripcionVar ;
      private string lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext ;
      private string lV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion ;
      private string lV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto ;
      private string AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext ;
      private string AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel ;
      private string AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion ;
      private string AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel ;
      private string AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto ;
      private string AV80ExcelFilename ;
      private string AV79ErrorMessage ;
      private string AV84FileURL ;
      private string A40000FacturaPDF_GXI ;
      private string AV62UserAction4 ;
      private string A75FacturaPDF ;
      private string AV83Blob ;
      private IGxSession AV66WebSession ;
      private IGxSession AV16Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucCombo_distribuidorid ;
      private GXUserControl ucUtchartdoughnut ;
      private GXUserControl ucUtchartcolumnline ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucInnwewindow ;
      private GXUserControl ucPopover_partidas ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTffacturafecharegistro_rangepicker ;
      private GXUserControl ucTffacturafechafactura_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV8HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbFacturaEstatus ;
      private GXCheckbox chkMotivoRechazoActivo ;
      private GxSimpleCollection<int> AV112DistribuidorID ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV20DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV113DistribuidorID_Data ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV102Elements ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter> AV103Parameters ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData AV104ItemClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData AV105ItemDoubleClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData AV106DragAndDropData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData AV107FilterChangedData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData AV108ItemExpandData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData AV109ItemCollapseData ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV11GridState ;
      private GxSimpleCollection<int> AV116ListaUsuarios ;
      private IDataStoreProvider pr_default ;
      private int[] H003P2_A41PromocionID ;
      private int[] H003P2_A19MotivoRechazoID ;
      private string[] H003P2_A20MotivoRechazoDescripcion ;
      private bool[] H003P2_A21MotivoRechazoActivo ;
      private int[] H003P2_A29UsuarioID ;
      private string[] H003P2_A80FacturaEstatus ;
      private DateTime[] H003P2_A73FacturaFechaFactura ;
      private string[] H003P2_A71FacturaNo ;
      private string[] H003P2_A42PromocionDescripcion ;
      private DateTime[] H003P2_A72FacturaFechaRegistro ;
      private int[] H003P2_A69FacturaID ;
      private string[] H003P2_A51UsuarioApellido ;
      private string[] H003P2_A30UsuarioNombre ;
      private long[] H003P3_AGRID_nRecordCount ;
      private SdtSDTUsuario AV67SDTUsuario ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV10TrnContextAtt ;
      private int[] H003P4_A10DistribuidorID ;
      private string[] H003P4_A11DistribuidorDescripcion ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV115Combo_DataItem ;
      private int[] H003P5_A10DistribuidorID ;
      private int[] H003P5_A29UsuarioID ;
      private string[] H003P5_A11DistribuidorDescripcion ;
      private int[] H003P5_A81DistribuidoresUsuarioID ;
      private int[] H003P6_A69FacturaID ;
      private string[] H003P6_A40000FacturaPDF_GXI ;
      private string[] H003P6_A75FacturaPDF ;
      private int[] H003P7_A81DistribuidoresUsuarioID ;
      private string[] H003P7_A40UsuarioRol ;
      private int[] H003P7_A29UsuarioID ;
      private int[] H003P8_A81DistribuidoresUsuarioID ;
      private string[] H003P8_A40UsuarioRol ;
      private int[] H003P8_A10DistribuidorID ;
      private int[] H003P8_A29UsuarioID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpdetallepromocionadminfacturawc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003P2( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV116ListaUsuarios ,
                                             string AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext ,
                                             DateTime AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro ,
                                             DateTime AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to ,
                                             string AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel ,
                                             string AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion ,
                                             string AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel ,
                                             string AV127Wpdetallepromocionadminfacturawcds_7_tffacturano ,
                                             DateTime AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura ,
                                             DateTime AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to ,
                                             short AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator ,
                                             string AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel ,
                                             string AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto ,
                                             DateTime AV100FromDate ,
                                             DateTime AV101ToDate ,
                                             int AV116ListaUsuarios_Count ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A41PromocionID ,
                                             int AV7PromocionID ,
                                             int AV121Wpdetallepromocionadminfacturawcds_1_promocionid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[19];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.`PromocionID`, T1.`MotivoRechazoID`, T3.`MotivoRechazoDescripcion`, T3.`MotivoRechazoActivo`, T1.`UsuarioID`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaNo`, T2.`PromocionDescripcion`, T1.`FacturaFechaRegistro`, T1.`FacturaID`, T4.`UsuarioApellido`, T4.`UsuarioNombre`";
         sFromString = " FROM (((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `MotivoRechazo` T3 ON T3.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.`PromocionID` = @AV121Wpdetallepromocionadminfacturawcds_1_promocionid)");
         AddWhere(sWhereString, "(T1.`PromocionID` = @AV7PromocionID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.`PromocionDescripcion` like CONCAT('%', @lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext)) or ( T1.`FacturaNo` like CONCAT('%', @lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like CONCAT('%', @lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext)))");
         }
         else
         {
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wpdetallepromocionadminfacturawcds_7_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV127Wpdetallepromocionadminfacturawcds_7_tffacturano)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( StringUtil.StrCmp(AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like @lV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecomple)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) = @AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecomple)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( StringUtil.StrCmp(AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T4.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T4.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV100FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV100FromDate)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV101ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV101ToDate)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( AV116ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV116ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`PromocionID`, T1.`FacturaNo`";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`PromocionID` DESC, T1.`FacturaNo` DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`PromocionID`, T1.`FacturaFechaRegistro`";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`PromocionID` DESC, T1.`FacturaFechaRegistro` DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`PromocionID`, T2.`PromocionDescripcion`";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`PromocionID` DESC, T2.`PromocionDescripcion` DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`PromocionID`, T1.`FacturaFechaFactura`";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`PromocionID` DESC, T1.`FacturaFechaFactura` DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.`FacturaID`";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " LIMIT " + "@GXPagingFrom2" + ", " + "@GXPagingTo2";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H003P3( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV116ListaUsuarios ,
                                             string AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext ,
                                             DateTime AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro ,
                                             DateTime AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to ,
                                             string AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel ,
                                             string AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion ,
                                             string AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel ,
                                             string AV127Wpdetallepromocionadminfacturawcds_7_tffacturano ,
                                             DateTime AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura ,
                                             DateTime AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to ,
                                             short AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator ,
                                             string AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel ,
                                             string AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto ,
                                             DateTime AV100FromDate ,
                                             DateTime AV101ToDate ,
                                             int AV116ListaUsuarios_Count ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A41PromocionID ,
                                             int AV7PromocionID ,
                                             int AV121Wpdetallepromocionadminfacturawcds_1_promocionid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[17];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `MotivoRechazo` T3 ON T3.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`PromocionID` = @AV121Wpdetallepromocionadminfacturawcds_1_promocionid)");
         AddWhere(sWhereString, "(T1.`PromocionID` = @AV7PromocionID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wpdetallepromocionadminfacturawcds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.`PromocionDescripcion` like CONCAT('%', @lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext)) or ( T1.`FacturaNo` like CONCAT('%', @lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like CONCAT('%', @lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext)))");
         }
         else
         {
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( StringUtil.StrCmp(AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wpdetallepromocionadminfacturawcds_7_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV127Wpdetallepromocionadminfacturawcds_7_tffacturano)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( StringUtil.StrCmp(AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV132Wpdetallepromocionadminfacturawcds_12_tfestatusoperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like @lV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecomple)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) = @AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecomple)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( StringUtil.StrCmp(AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T4.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T4.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV100FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV100FromDate)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV101ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV101ToDate)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV116ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV116ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H003P8( IGxContext context ,
                                             int A10DistribuidorID ,
                                             GxSimpleCollection<int> AV112DistribuidorID ,
                                             string A40UsuarioRol )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.`DistribuidoresUsuarioID`, T2.`UsuarioRol`, T1.`DistribuidorID`, T1.`UsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV112DistribuidorID, "T1.`DistribuidorID` IN (", ")")+")");
         AddWhere(sWhereString, "(T2.`UsuarioRol` = 'Participante')");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`DistribuidoresUsuarioID`";
         GXv_Object10[0] = scmdbuf;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H003P2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
               case 1 :
                     return conditional_H003P3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
               case 6 :
                     return conditional_H003P8(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] );
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
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH003P4;
          prmH003P4 = new Object[] {
          };
          Object[] prmH003P5;
          prmH003P5 = new Object[] {
          new ParDef("@AV98RegUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH003P6;
          prmH003P6 = new Object[] {
          new ParDef("@AV99FacturaID",GXType.Int32,9,0)
          };
          Object[] prmH003P7;
          prmH003P7 = new Object[] {
          };
          Object[] prmH003P2;
          prmH003P2 = new Object[] {
          new ParDef("@AV121Wpdetallepromocionadminfacturawcds_1_promocionid",GXType.Int32,9,0) ,
          new ParDef("@AV7PromocionID",GXType.Int32,9,0) ,
          new ParDef("@lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@lV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@lV127Wpdetallepromocionadminfacturawcds_7_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@lV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecomple",GXType.Char,40,0) ,
          new ParDef("@AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecomple",GXType.Char,40,0) ,
          new ParDef("@AV100FromDate",GXType.Date,8,0) ,
          new ParDef("@AV101ToDate",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH003P3;
          prmH003P3 = new Object[] {
          new ParDef("@AV121Wpdetallepromocionadminfacturawcds_1_promocionid",GXType.Int32,9,0) ,
          new ParDef("@AV7PromocionID",GXType.Int32,9,0) ,
          new ParDef("@lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV122Wpdetallepromocionadminfacturawcds_2_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV123Wpdetallepromocionadminfacturawcds_3_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV124Wpdetallepromocionadminfacturawcds_4_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@lV125Wpdetallepromocionadminfacturawcds_5_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV126Wpdetallepromocionadminfacturawcds_6_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@lV127Wpdetallepromocionadminfacturawcds_7_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV128Wpdetallepromocionadminfacturawcds_8_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@AV129Wpdetallepromocionadminfacturawcds_9_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV130Wpdetallepromocionadminfacturawcds_10_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@lV133Wpdetallepromocionadminfacturawcds_13_tfusuarionombrecomple",GXType.Char,40,0) ,
          new ParDef("@AV134Wpdetallepromocionadminfacturawcds_14_tfusuarionombrecomple",GXType.Char,40,0) ,
          new ParDef("@AV100FromDate",GXType.Date,8,0) ,
          new ParDef("@AV101ToDate",GXType.Date,8,0)
          };
          Object[] prmH003P8;
          prmH003P8 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H003P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003P2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003P3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003P3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003P4", "SELECT `DistribuidorID`, `DistribuidorDescripcion` FROM `Distribuidor` ORDER BY `DistribuidorDescripcion` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003P4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003P5", "SELECT T1.`DistribuidorID`, T1.`UsuarioID`, T2.`DistribuidorDescripcion`, T1.`DistribuidoresUsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Distribuidor` T2 ON T2.`DistribuidorID` = T1.`DistribuidorID`) WHERE T1.`UsuarioID` = @AV98RegUsuarioID ORDER BY T1.`DistribuidoresUsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003P5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H003P6", "SELECT `FacturaID`, `FacturaPDF_GXI`, `FacturaPDF` FROM `Factura` WHERE `FacturaID` = @AV99FacturaID ORDER BY `FacturaID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003P6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H003P7", "SELECT T1.`DistribuidoresUsuarioID`, T2.`UsuarioRol`, T1.`UsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = T1.`UsuarioID`) WHERE T2.`UsuarioRol` = 'Participante' ORDER BY T1.`DistribuidoresUsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003P7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003P8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003P8,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 50);
                ((string[]) buf[12])[0] = rslt.getString(13, 50);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
