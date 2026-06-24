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
   public class wpfacturaspromopart : GXWebComponent
   {
      public wpfacturaspromopart( )
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

      public wpfacturaspromopart( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PromocionID )
      {
         this.AV71PromocionID = aP0_PromocionID;
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
                  AV71PromocionID = (int)(Math.Round(NumberUtil.Val( GetPar( "PromocionID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV71PromocionID", StringUtil.LTrimStr( (decimal)(AV71PromocionID), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV71PromocionID});
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
         nRC_GXsfl_61 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_61"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_61_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_61_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_61_idx = GetPar( "sGXsfl_61_idx");
         sPrefix = GetPar( "sPrefix");
         edtavUseraction2_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_61_Refreshing);
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
         AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV124FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
         AV125ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
         AV15FilterFullText = GetPar( "FilterFullText");
         AV71PromocionID = (int)(Math.Round(NumberUtil.Val( GetPar( "PromocionID"), "."), 18, MidpointRounding.ToEven));
         AV23ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV18ColumnsSelector);
         AV235Pgmname = GetPar( "Pgmname");
         AV41TFFacturaFechaRegistro = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaRegistro"));
         AV42TFFacturaFechaRegistro_To = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaRegistro_To"));
         AV28TFPromocionDescripcion = GetPar( "TFPromocionDescripcion");
         AV29TFPromocionDescripcion_Sel = GetPar( "TFPromocionDescripcion_Sel");
         AV34TFFacturaNo = GetPar( "TFFacturaNo");
         AV35TFFacturaNo_Sel = GetPar( "TFFacturaNo_Sel");
         AV36TFFacturaFechaFactura = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaFactura"));
         AV37TFFacturaFechaFactura_To = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaFactura_To"));
         AV74TFEstatus = GetPar( "TFEstatus");
         AV75TFEstatusOperator = (short)(Math.Round(NumberUtil.Val( GetPar( "TFEstatusOperator"), "."), 18, MidpointRounding.ToEven));
         AV48TFUsuarioNombreCompleto = GetPar( "TFUsuarioNombreCompleto");
         AV49TFUsuarioNombreCompleto_Sel = GetPar( "TFUsuarioNombreCompleto_Sel");
         AV83UsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "UsuarioID"), "."), 18, MidpointRounding.ToEven));
         edtavUseraction2_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_61_Refreshing);
         AV69Estatus = GetPar( "Estatus");
         AV90RegUsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "RegUsuarioID"), "."), 18, MidpointRounding.ToEven));
         A11DistribuidorDescripcion = GetPar( "DistribuidorDescripcion");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV124FromDate, AV125ToDate, AV15FilterFullText, AV71PromocionID, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV235Pgmname, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV74TFEstatus, AV75TFEstatusOperator, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV83UsuarioID, AV69Estatus, AV90RegUsuarioID, A11DistribuidorDescripcion, sPrefix) ;
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
            PA302( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV235Pgmname = "WPFacturasPromoPart";
               edtavUseraction8_Enabled = 0;
               AssignProp(sPrefix, false, edtavUseraction8_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUseraction8_Enabled), 5, 0), !bGXsfl_61_Refreshing);
               edtavPartidaswithtags_Enabled = 0;
               AssignProp(sPrefix, false, edtavPartidaswithtags_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPartidaswithtags_Enabled), 5, 0), !bGXsfl_61_Refreshing);
               edtavPartidas_Enabled = 0;
               AssignProp(sPrefix, false, edtavPartidas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPartidas_Enabled), 5, 0), !bGXsfl_61_Refreshing);
               edtavUseraction2_Enabled = 0;
               AssignProp(sPrefix, false, edtavUseraction2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Enabled), 5, 0), !bGXsfl_61_Refreshing);
               edtavEstatuswithtags_Enabled = 0;
               AssignProp(sPrefix, false, edtavEstatuswithtags_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEstatuswithtags_Enabled), 5, 0), !bGXsfl_61_Refreshing);
               edtavEstatus_Enabled = 0;
               AssignProp(sPrefix, false, edtavEstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEstatus_Enabled), 5, 0), !bGXsfl_61_Refreshing);
               edtavDescripcion_Enabled = 0;
               AssignProp(sPrefix, false, edtavDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDescripcion_Enabled), 5, 0), !bGXsfl_61_Refreshing);
               edtavDistribuidordescripcion_Enabled = 0;
               AssignProp(sPrefix, false, edtavDistribuidordescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDistribuidordescripcion_Enabled), 5, 0), !bGXsfl_61_Refreshing);
               WS302( ) ;
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
            context.SendWebValue( context.GetMessage( " Factura", "")) ;
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
            GXEncryptionTmp = "wpfacturaspromopart.aspx"+UrlEncode(StringUtil.LTrimStr(AV71PromocionID,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpfacturaspromopart.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV235Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV235Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV83UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV83UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vREGUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV90RegUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREGUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV90RegUsuarioID), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFROMDATE", context.localUtil.Format(AV124FromDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vTODATE", context.localUtil.Format(AV125ToDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV15FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_61", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_61), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vELEMENTS", AV225Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vELEMENTS", AV225Elements);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPARAMETERS", AV226Parameters);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPARAMETERS", AV226Parameters);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMCLICKDATA", AV227ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMCLICKDATA", AV227ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMDOUBLECLICKDATA", AV228ItemDoubleClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMDOUBLECLICKDATA", AV228ItemDoubleClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDRAGANDDROPDATA", AV229DragAndDropData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDRAGANDDROPDATA", AV229DragAndDropData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERCHANGEDDATA", AV230FilterChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERCHANGEDDATA", AV230FilterChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMEXPANDDATA", AV231ItemExpandData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMEXPANDDATA", AV231ItemExpandData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMCOLLAPSEDATA", AV232ItemCollapseData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMCOLLAPSEDATA", AV232ItemCollapseData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV21ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV21ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV64GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV66GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV62DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV62DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOLUMNSSELECTOR", AV18ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOLUMNSSELECTOR", AV18ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_FACTURAFECHAREGISTROAUXDATETO", context.localUtil.DToC( AV222DDO_FacturaFechaRegistroAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_FACTURAFECHAFACTURAAUXDATETO", context.localUtil.DToC( AV224DDO_FacturaFechaFacturaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV71PromocionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV71PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV235Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV235Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAFECHAREGISTRO", context.localUtil.DToC( AV41TFFacturaFechaRegistro, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAFECHAREGISTRO_TO", context.localUtil.DToC( AV42TFFacturaFechaRegistro_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROMOCIONDESCRIPCION", AV28TFPromocionDescripcion);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROMOCIONDESCRIPCION_SEL", AV29TFPromocionDescripcion_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURANO", StringUtil.RTrim( AV34TFFacturaNo));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURANO_SEL", StringUtil.RTrim( AV35TFFacturaNo_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAFECHAFACTURA", context.localUtil.DToC( AV36TFFacturaFechaFactura, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAFECHAFACTURA_TO", context.localUtil.DToC( AV37TFFacturaFechaFactura_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTATUS", StringUtil.RTrim( AV74TFEstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTATUSOPERATOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV75TFEstatusOperator), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFUSUARIONOMBRECOMPLETO", AV48TFUsuarioNombreCompleto);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFUSUARIONOMBRECOMPLETO_SEL", AV49TFUsuarioNombreCompleto_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV83UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV83UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vREGUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV90RegUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREGUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV90RegUsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"DISTRIBUIDORDESCRIPCION", A11DistribuidorDescripcion);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV71PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLISTAUSUARIOS", AV180ListaUsuarios);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLISTAUSUARIOS", AV180ListaUsuarios);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vBLOB", AV91Blob);
         GxWebStd.gx_hidden_field( context, sPrefix+"vFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV93FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FACTURAPDF", A75FacturaPDF);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIONOMBRE", StringUtil.RTrim( A30UsuarioNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIOAPELLIDO", StringUtil.RTrim( A51UsuarioApellido));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_FACTURAFECHAREGISTROAUXDATE", context.localUtil.DToC( AV221DDO_FacturaFechaRegistroAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_FACTURAFECHAFACTURAAUXDATE", context.localUtil.DToC( AV223DDO_FacturaFechaFacturaAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Fixedfilters", StringUtil.RTrim( Ddo_grid_Fixedfilters));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedfixedfilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm302( )
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
         return "WPFacturasPromoPart" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Factura", "") ;
      }

      protected void WB300( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpfacturaspromopart.aspx");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "TableMainWithShadow", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFromdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFromdate_Internalname, context.GetMessage( "Desde", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'" + sGXsfl_61_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFromdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFromdate_Internalname, context.localUtil.Format(AV124FromDate, "99/99/99"), context.localUtil.Format( AV124FromDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFromdate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFromdate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPFacturasPromoPart.htm");
            GxWebStd.gx_bitmap( context, edtavFromdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFromdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPFacturasPromoPart.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTodate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTodate_Internalname, context.GetMessage( "Hasta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'" + sGXsfl_61_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTodate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTodate_Internalname, context.localUtil.Format(AV125ToDate, "99/99/99"), context.localUtil.Format( AV125ToDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTodate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTodate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPFacturasPromoPart.htm");
            GxWebStd.gx_bitmap( context, edtavTodate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTodate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPFacturasPromoPart.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction99_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(61), 2, 0)+","+"null"+");", context.GetMessage( "Filtrar", ""), bttBtnuseraction99_Jsonclick, 5, context.GetMessage( "Filtrar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUSERACTION99\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPFacturasPromoPart.htm");
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
            ucUtchartdoughnut.SetProperty("Elements", AV225Elements);
            ucUtchartdoughnut.SetProperty("Parameters", AV226Parameters);
            ucUtchartdoughnut.SetProperty("Type", Utchartdoughnut_Type);
            ucUtchartdoughnut.SetProperty("Title", Utchartdoughnut_Title);
            ucUtchartdoughnut.SetProperty("ShowValues", Utchartdoughnut_Showvalues);
            ucUtchartdoughnut.SetProperty("ChartType", Utchartdoughnut_Charttype);
            ucUtchartdoughnut.SetProperty("ItemClickData", AV227ItemClickData);
            ucUtchartdoughnut.SetProperty("ItemDoubleClickData", AV228ItemDoubleClickData);
            ucUtchartdoughnut.SetProperty("DragAndDropData", AV229DragAndDropData);
            ucUtchartdoughnut.SetProperty("FilterChangedData", AV230FilterChangedData);
            ucUtchartdoughnut.SetProperty("ItemExpandData", AV231ItemExpandData);
            ucUtchartdoughnut.SetProperty("ItemCollapseData", AV232ItemCollapseData);
            ucUtchartdoughnut.Render(context, "queryviewer", Utchartdoughnut_Internalname, sPrefix+"UTCHARTDOUGHNUTContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartcolumnline.SetProperty("Elements", AV225Elements);
            ucUtchartcolumnline.SetProperty("Parameters", AV226Parameters);
            ucUtchartcolumnline.SetProperty("Type", Utchartcolumnline_Type);
            ucUtchartcolumnline.SetProperty("Title", Utchartcolumnline_Title);
            ucUtchartcolumnline.SetProperty("ItemClickData", AV227ItemClickData);
            ucUtchartcolumnline.SetProperty("ItemDoubleClickData", AV228ItemDoubleClickData);
            ucUtchartcolumnline.SetProperty("DragAndDropData", AV229DragAndDropData);
            ucUtchartcolumnline.SetProperty("FilterChangedData", AV230FilterChangedData);
            ucUtchartcolumnline.SetProperty("ItemExpandData", AV231ItemExpandData);
            ucUtchartcolumnline.SetProperty("ItemCollapseData", AV232ItemCollapseData);
            ucUtchartcolumnline.Render(context, "queryviewer", Utchartcolumnline_Internalname, sPrefix+"UTCHARTCOLUMNLINEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(61), 2, 0)+","+"null"+");", context.GetMessage( "Agregar", ""), bttBtnuseraction1_Jsonclick, 5, context.GetMessage( "Agregar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUSERACTION1\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPFacturasPromoPart.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexceldetallado_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(61), 2, 0)+","+"null"+");", context.GetMessage( "Excel detallado", ""), bttBtnexceldetallado_Jsonclick, 5, context.GetMessage( "Excel detallado", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXCELDETALLADO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPFacturasPromoPart.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(61), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WPFacturasPromoPart.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV21ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'" + sGXsfl_61_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WPFacturasPromoPart.htm");
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
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
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
            StartGridControl61( ) ;
         }
         if ( wbEnd == 61 )
         {
            wbEnd = 0;
            nRC_GXsfl_61 = (int)(nGXsfl_61_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV64GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV65GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV66GridAppliedFilters);
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
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("FixedFilters", Ddo_grid_Fixedfilters);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV62DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV62DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV18ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, sPrefix+"DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("PopoversInGrid", Grid_empowerer_Popoversingrid);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0096"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0096"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_61_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0096"+"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'" + sPrefix + "',false,'" + sGXsfl_61_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_facturafecharegistroauxdatetext_Internalname, AV45DDO_FacturaFechaRegistroAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV45DDO_FacturaFechaRegistroAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_facturafecharegistroauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPFacturasPromoPart.htm");
            /* User Defined Control */
            ucTffacturafecharegistro_rangepicker.SetProperty("Start Date", AV221DDO_FacturaFechaRegistroAuxDate);
            ucTffacturafecharegistro_rangepicker.SetProperty("End Date", AV222DDO_FacturaFechaRegistroAuxDateTo);
            ucTffacturafecharegistro_rangepicker.Render(context, "wwp.daterangepicker", Tffacturafecharegistro_rangepicker_Internalname, sPrefix+"TFFACTURAFECHAREGISTRO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_facturafechafacturaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'" + sPrefix + "',false,'" + sGXsfl_61_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_facturafechafacturaauxdatetext_Internalname, AV40DDO_FacturaFechaFacturaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV40DDO_FacturaFechaFacturaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_facturafechafacturaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPFacturasPromoPart.htm");
            /* User Defined Control */
            ucTffacturafechafactura_rangepicker.SetProperty("Start Date", AV223DDO_FacturaFechaFacturaAuxDate);
            ucTffacturafechafactura_rangepicker.SetProperty("End Date", AV224DDO_FacturaFechaFacturaAuxDateTo);
            ucTffacturafechafactura_rangepicker.Render(context, "wwp.daterangepicker", Tffacturafechafactura_rangepicker_Internalname, sPrefix+"TFFACTURAFECHAFACTURA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 61 )
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

      protected void START302( )
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
            Form.Meta.addItem("description", context.GetMessage( " Factura", ""), 0) ;
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
               STRUP300( ) ;
            }
         }
      }

      protected void WS302( )
      {
         START302( ) ;
         EVT302( ) ;
      }

      protected void EVT302( )
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
                                 STRUP300( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E12302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E13302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E14302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                                    E15302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUserAction1' */
                                    E16302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXCELDETALLADO'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExcelDetallado' */
                                    E17302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION99'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUserAction99' */
                                    E18302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
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
                                 STRUP300( ) ;
                              }
                              nGXsfl_61_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_61_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_61_idx), 4, 0), 4, "0");
                              SubsflControlProps_612( ) ;
                              A69FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              AV77UserAction4 = cgiGet( edtavUseraction4_Internalname);
                              AssignProp(sPrefix, false, edtavUseraction4_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV77UserAction4)) ? AV249Useraction4_GXI : context.convertURL( context.PathToRelativeUrl( AV77UserAction4))), !bGXsfl_61_Refreshing);
                              AssignProp(sPrefix, false, edtavUseraction4_Internalname, "SrcSet", context.GetImageSrcSet( AV77UserAction4), true);
                              AV78UserAction8 = cgiGet( edtavUseraction8_Internalname);
                              AssignAttri(sPrefix, false, edtavUseraction8_Internalname, AV78UserAction8);
                              A72FacturaFechaRegistro = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaRegistro_Internalname), 0));
                              A42PromocionDescripcion = cgiGet( edtPromocionDescripcion_Internalname);
                              A71FacturaNo = cgiGet( edtFacturaNo_Internalname);
                              A73FacturaFechaFactura = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaFactura_Internalname), 0));
                              AV88PartidasWithTags = cgiGet( edtavPartidaswithtags_Internalname);
                              AssignAttri(sPrefix, false, edtavPartidaswithtags_Internalname, AV88PartidasWithTags);
                              AV87Partidas = cgiGet( edtavPartidas_Internalname);
                              AssignAttri(sPrefix, false, edtavPartidas_Internalname, AV87Partidas);
                              AV76UserAction2 = cgiGet( edtavUseraction2_Internalname);
                              AssignAttri(sPrefix, false, edtavUseraction2_Internalname, AV76UserAction2);
                              AV70EstatusWithTags = cgiGet( edtavEstatuswithtags_Internalname);
                              AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV70EstatusWithTags);
                              AV69Estatus = cgiGet( edtavEstatus_Internalname);
                              AssignAttri(sPrefix, false, edtavEstatus_Internalname, AV69Estatus);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vESTATUS"+"_"+sGXsfl_61_idx, GetSecureSignedToken( sPrefix+sGXsfl_61_idx, StringUtil.RTrim( context.localUtil.Format( AV69Estatus, "")), context));
                              AV73Descripcion = cgiGet( edtavDescripcion_Internalname);
                              AssignAttri(sPrefix, false, edtavDescripcion_Internalname, AV73Descripcion);
                              cmbFacturaEstatus.Name = cmbFacturaEstatus_Internalname;
                              cmbFacturaEstatus.CurrentValue = cgiGet( cmbFacturaEstatus_Internalname);
                              A80FacturaEstatus = cgiGet( cmbFacturaEstatus_Internalname);
                              A29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A52UsuarioNombreCompleto = cgiGet( edtUsuarioNombreCompleto_Internalname);
                              A21MotivoRechazoActivo = StringUtil.StrToBool( cgiGet( chkMotivoRechazoActivo_Internalname));
                              A20MotivoRechazoDescripcion = cgiGet( edtMotivoRechazoDescripcion_Internalname);
                              A19MotivoRechazoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMotivoRechazoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              AV89DistribuidorDescripcion = cgiGet( edtavDistribuidordescripcion_Internalname);
                              AssignAttri(sPrefix, false, edtavDistribuidordescripcion_Internalname, AV89DistribuidorDescripcion);
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
                                          E19302 ();
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
                                          E20302 ();
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
                                          E21302 ();
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
                                          E22302 ();
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
                                          E23302 ();
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
                                          E24302 ();
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
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV13OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Fromdate Changed */
                                             if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vFROMDATE"), 0) != AV124FromDate )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Todate Changed */
                                             if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vTODATE"), 0) != AV125ToDate )
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
                                       STRUP300( ) ;
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
                        if ( nCmpId == 96 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0096");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0096", "", sEvt);
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

      protected void WE302( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm302( ) ;
            }
         }
      }

      protected void PA302( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpfacturaspromopart.aspx")), "wpfacturaspromopart.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpfacturaspromopart.aspx")))) ;
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
         SubsflControlProps_612( ) ;
         while ( nGXsfl_61_idx <= nRC_GXsfl_61 )
         {
            sendrow_612( ) ;
            nGXsfl_61_idx = ((subGrid_Islastpage==1)&&(nGXsfl_61_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_61_idx+1);
            sGXsfl_61_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_61_idx), 4, 0), 4, "0");
            SubsflControlProps_612( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       DateTime AV124FromDate ,
                                       DateTime AV125ToDate ,
                                       string AV15FilterFullText ,
                                       int AV71PromocionID ,
                                       short AV23ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV18ColumnsSelector ,
                                       string AV235Pgmname ,
                                       DateTime AV41TFFacturaFechaRegistro ,
                                       DateTime AV42TFFacturaFechaRegistro_To ,
                                       string AV28TFPromocionDescripcion ,
                                       string AV29TFPromocionDescripcion_Sel ,
                                       string AV34TFFacturaNo ,
                                       string AV35TFFacturaNo_Sel ,
                                       DateTime AV36TFFacturaFechaFactura ,
                                       DateTime AV37TFFacturaFechaFactura_To ,
                                       string AV74TFEstatus ,
                                       short AV75TFEstatusOperator ,
                                       string AV48TFUsuarioNombreCompleto ,
                                       string AV49TFUsuarioNombreCompleto_Sel ,
                                       int AV83UsuarioID ,
                                       string AV69Estatus ,
                                       int AV90RegUsuarioID ,
                                       string A11DistribuidorDescripcion ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF302( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vESTATUS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV69Estatus, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vESTATUS", StringUtil.RTrim( AV69Estatus));
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
         RF302( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV235Pgmname = "WPFacturasPromoPart";
         edtavUseraction8_Enabled = 0;
         edtavPartidaswithtags_Enabled = 0;
         edtavPartidas_Enabled = 0;
         edtavUseraction2_Enabled = 0;
         edtavEstatuswithtags_Enabled = 0;
         edtavEstatus_Enabled = 0;
         edtavDescripcion_Enabled = 0;
         edtavDistribuidordescripcion_Enabled = 0;
      }

      protected void RF302( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 61;
         /* Execute user event: Refresh */
         E20302 ();
         nGXsfl_61_idx = 1;
         sGXsfl_61_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_61_idx), 4, 0), 4, "0");
         SubsflControlProps_612( ) ;
         bGXsfl_61_Refreshing = true;
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
            SubsflControlProps_612( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A29UsuarioID ,
                                                 AV180ListaUsuarios ,
                                                 AV236Wpfacturaspromopartds_1_filterfulltext ,
                                                 AV237Wpfacturaspromopartds_2_tffacturafecharegistro ,
                                                 AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to ,
                                                 AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel ,
                                                 AV239Wpfacturaspromopartds_4_tfpromociondescripcion ,
                                                 AV242Wpfacturaspromopartds_7_tffacturano_sel ,
                                                 AV241Wpfacturaspromopartds_6_tffacturano ,
                                                 AV243Wpfacturaspromopartds_8_tffacturafechafactura ,
                                                 AV244Wpfacturaspromopartds_9_tffacturafechafactura_to ,
                                                 AV246Wpfacturaspromopartds_11_tfestatusoperator ,
                                                 AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel ,
                                                 AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto ,
                                                 AV124FromDate ,
                                                 AV125ToDate ,
                                                 AV180ListaUsuarios.Count ,
                                                 A42PromocionDescripcion ,
                                                 A71FacturaNo ,
                                                 A30UsuarioNombre ,
                                                 A51UsuarioApellido ,
                                                 A72FacturaFechaRegistro ,
                                                 A73FacturaFechaFactura ,
                                                 A80FacturaEstatus ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 A93FacturaCompleta ,
                                                 AV71PromocionID ,
                                                 A41PromocionID } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            lV236Wpfacturaspromopartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV236Wpfacturaspromopartds_1_filterfulltext), "%", "");
            lV236Wpfacturaspromopartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV236Wpfacturaspromopartds_1_filterfulltext), "%", "");
            lV236Wpfacturaspromopartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV236Wpfacturaspromopartds_1_filterfulltext), "%", "");
            lV239Wpfacturaspromopartds_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV239Wpfacturaspromopartds_4_tfpromociondescripcion), "%", "");
            lV241Wpfacturaspromopartds_6_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV241Wpfacturaspromopartds_6_tffacturano), 20, "%");
            lV247Wpfacturaspromopartds_12_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto), "%", "");
            /* Using cursor H00302 */
            pr_default.execute(0, new Object[] {AV71PromocionID, lV236Wpfacturaspromopartds_1_filterfulltext, lV236Wpfacturaspromopartds_1_filterfulltext, lV236Wpfacturaspromopartds_1_filterfulltext, AV237Wpfacturaspromopartds_2_tffacturafecharegistro, AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to, lV239Wpfacturaspromopartds_4_tfpromociondescripcion, AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel, lV241Wpfacturaspromopartds_6_tffacturano, AV242Wpfacturaspromopartds_7_tffacturano_sel, AV243Wpfacturaspromopartds_8_tffacturafechafactura, AV244Wpfacturaspromopartds_9_tffacturafechafactura_to, lV247Wpfacturaspromopartds_12_tfusuarionombrecompleto, AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel, AV124FromDate, AV125ToDate, GXPagingFrom2, GXPagingTo2});
            nGXsfl_61_idx = 1;
            sGXsfl_61_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_61_idx), 4, 0), 4, "0");
            SubsflControlProps_612( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A41PromocionID = H00302_A41PromocionID[0];
               A93FacturaCompleta = H00302_A93FacturaCompleta[0];
               A19MotivoRechazoID = H00302_A19MotivoRechazoID[0];
               A20MotivoRechazoDescripcion = H00302_A20MotivoRechazoDescripcion[0];
               A21MotivoRechazoActivo = H00302_A21MotivoRechazoActivo[0];
               A29UsuarioID = H00302_A29UsuarioID[0];
               A80FacturaEstatus = H00302_A80FacturaEstatus[0];
               A73FacturaFechaFactura = H00302_A73FacturaFechaFactura[0];
               A71FacturaNo = H00302_A71FacturaNo[0];
               A42PromocionDescripcion = H00302_A42PromocionDescripcion[0];
               A72FacturaFechaRegistro = H00302_A72FacturaFechaRegistro[0];
               A69FacturaID = H00302_A69FacturaID[0];
               A51UsuarioApellido = H00302_A51UsuarioApellido[0];
               A30UsuarioNombre = H00302_A30UsuarioNombre[0];
               A42PromocionDescripcion = H00302_A42PromocionDescripcion[0];
               A20MotivoRechazoDescripcion = H00302_A20MotivoRechazoDescripcion[0];
               A21MotivoRechazoActivo = H00302_A21MotivoRechazoActivo[0];
               A51UsuarioApellido = H00302_A51UsuarioApellido[0];
               A30UsuarioNombre = H00302_A30UsuarioNombre[0];
               A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
               /* Execute user event: Grid.Load */
               E21302 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 61;
            WB300( ) ;
         }
         bGXsfl_61_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes302( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV235Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV235Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV83UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV83UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vESTATUS"+"_"+sGXsfl_61_idx, GetSecureSignedToken( sPrefix+sGXsfl_61_idx, StringUtil.RTrim( context.localUtil.Format( AV69Estatus, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vREGUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV90RegUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREGUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV90RegUsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_FACTURAID"+"_"+sGXsfl_61_idx, GetSecureSignedToken( sPrefix+sGXsfl_61_idx, context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_FACTURAESTATUS"+"_"+sGXsfl_61_idx, GetSecureSignedToken( sPrefix+sGXsfl_61_idx, StringUtil.RTrim( context.localUtil.Format( A80FacturaEstatus, "")), context));
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
         AV236Wpfacturaspromopartds_1_filterfulltext = AV15FilterFullText;
         AV237Wpfacturaspromopartds_2_tffacturafecharegistro = AV41TFFacturaFechaRegistro;
         AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to = AV42TFFacturaFechaRegistro_To;
         AV239Wpfacturaspromopartds_4_tfpromociondescripcion = AV28TFPromocionDescripcion;
         AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel = AV29TFPromocionDescripcion_Sel;
         AV241Wpfacturaspromopartds_6_tffacturano = AV34TFFacturaNo;
         AV242Wpfacturaspromopartds_7_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV243Wpfacturaspromopartds_8_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV244Wpfacturaspromopartds_9_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV245Wpfacturaspromopartds_10_tfestatus = AV74TFEstatus;
         AV246Wpfacturaspromopartds_11_tfestatusoperator = AV75TFEstatusOperator;
         AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto = AV48TFUsuarioNombreCompleto;
         AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel = AV49TFUsuarioNombreCompleto_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV180ListaUsuarios ,
                                              AV236Wpfacturaspromopartds_1_filterfulltext ,
                                              AV237Wpfacturaspromopartds_2_tffacturafecharegistro ,
                                              AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to ,
                                              AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel ,
                                              AV239Wpfacturaspromopartds_4_tfpromociondescripcion ,
                                              AV242Wpfacturaspromopartds_7_tffacturano_sel ,
                                              AV241Wpfacturaspromopartds_6_tffacturano ,
                                              AV243Wpfacturaspromopartds_8_tffacturafechafactura ,
                                              AV244Wpfacturaspromopartds_9_tffacturafechafactura_to ,
                                              AV246Wpfacturaspromopartds_11_tfestatusoperator ,
                                              AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel ,
                                              AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto ,
                                              AV124FromDate ,
                                              AV125ToDate ,
                                              AV180ListaUsuarios.Count ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              A93FacturaCompleta ,
                                              AV71PromocionID ,
                                              A41PromocionID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV236Wpfacturaspromopartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV236Wpfacturaspromopartds_1_filterfulltext), "%", "");
         lV236Wpfacturaspromopartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV236Wpfacturaspromopartds_1_filterfulltext), "%", "");
         lV236Wpfacturaspromopartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV236Wpfacturaspromopartds_1_filterfulltext), "%", "");
         lV239Wpfacturaspromopartds_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV239Wpfacturaspromopartds_4_tfpromociondescripcion), "%", "");
         lV241Wpfacturaspromopartds_6_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV241Wpfacturaspromopartds_6_tffacturano), 20, "%");
         lV247Wpfacturaspromopartds_12_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto), "%", "");
         /* Using cursor H00303 */
         pr_default.execute(1, new Object[] {AV71PromocionID, lV236Wpfacturaspromopartds_1_filterfulltext, lV236Wpfacturaspromopartds_1_filterfulltext, lV236Wpfacturaspromopartds_1_filterfulltext, AV237Wpfacturaspromopartds_2_tffacturafecharegistro, AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to, lV239Wpfacturaspromopartds_4_tfpromociondescripcion, AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel, lV241Wpfacturaspromopartds_6_tffacturano, AV242Wpfacturaspromopartds_7_tffacturano_sel, AV243Wpfacturaspromopartds_8_tffacturafechafactura, AV244Wpfacturaspromopartds_9_tffacturafechafactura_to, lV247Wpfacturaspromopartds_12_tfusuarionombrecompleto, AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel, AV124FromDate, AV125ToDate});
         GRID_nRecordCount = H00303_AGRID_nRecordCount[0];
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
         AV236Wpfacturaspromopartds_1_filterfulltext = AV15FilterFullText;
         AV237Wpfacturaspromopartds_2_tffacturafecharegistro = AV41TFFacturaFechaRegistro;
         AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to = AV42TFFacturaFechaRegistro_To;
         AV239Wpfacturaspromopartds_4_tfpromociondescripcion = AV28TFPromocionDescripcion;
         AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel = AV29TFPromocionDescripcion_Sel;
         AV241Wpfacturaspromopartds_6_tffacturano = AV34TFFacturaNo;
         AV242Wpfacturaspromopartds_7_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV243Wpfacturaspromopartds_8_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV244Wpfacturaspromopartds_9_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV245Wpfacturaspromopartds_10_tfestatus = AV74TFEstatus;
         AV246Wpfacturaspromopartds_11_tfestatusoperator = AV75TFEstatusOperator;
         AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto = AV48TFUsuarioNombreCompleto;
         AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel = AV49TFUsuarioNombreCompleto_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV124FromDate, AV125ToDate, AV15FilterFullText, AV71PromocionID, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV235Pgmname, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV74TFEstatus, AV75TFEstatusOperator, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV83UsuarioID, AV69Estatus, AV90RegUsuarioID, A11DistribuidorDescripcion, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV236Wpfacturaspromopartds_1_filterfulltext = AV15FilterFullText;
         AV237Wpfacturaspromopartds_2_tffacturafecharegistro = AV41TFFacturaFechaRegistro;
         AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to = AV42TFFacturaFechaRegistro_To;
         AV239Wpfacturaspromopartds_4_tfpromociondescripcion = AV28TFPromocionDescripcion;
         AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel = AV29TFPromocionDescripcion_Sel;
         AV241Wpfacturaspromopartds_6_tffacturano = AV34TFFacturaNo;
         AV242Wpfacturaspromopartds_7_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV243Wpfacturaspromopartds_8_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV244Wpfacturaspromopartds_9_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV245Wpfacturaspromopartds_10_tfestatus = AV74TFEstatus;
         AV246Wpfacturaspromopartds_11_tfestatusoperator = AV75TFEstatusOperator;
         AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto = AV48TFUsuarioNombreCompleto;
         AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel = AV49TFUsuarioNombreCompleto_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV124FromDate, AV125ToDate, AV15FilterFullText, AV71PromocionID, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV235Pgmname, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV74TFEstatus, AV75TFEstatusOperator, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV83UsuarioID, AV69Estatus, AV90RegUsuarioID, A11DistribuidorDescripcion, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV236Wpfacturaspromopartds_1_filterfulltext = AV15FilterFullText;
         AV237Wpfacturaspromopartds_2_tffacturafecharegistro = AV41TFFacturaFechaRegistro;
         AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to = AV42TFFacturaFechaRegistro_To;
         AV239Wpfacturaspromopartds_4_tfpromociondescripcion = AV28TFPromocionDescripcion;
         AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel = AV29TFPromocionDescripcion_Sel;
         AV241Wpfacturaspromopartds_6_tffacturano = AV34TFFacturaNo;
         AV242Wpfacturaspromopartds_7_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV243Wpfacturaspromopartds_8_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV244Wpfacturaspromopartds_9_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV245Wpfacturaspromopartds_10_tfestatus = AV74TFEstatus;
         AV246Wpfacturaspromopartds_11_tfestatusoperator = AV75TFEstatusOperator;
         AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto = AV48TFUsuarioNombreCompleto;
         AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel = AV49TFUsuarioNombreCompleto_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV124FromDate, AV125ToDate, AV15FilterFullText, AV71PromocionID, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV235Pgmname, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV74TFEstatus, AV75TFEstatusOperator, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV83UsuarioID, AV69Estatus, AV90RegUsuarioID, A11DistribuidorDescripcion, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV236Wpfacturaspromopartds_1_filterfulltext = AV15FilterFullText;
         AV237Wpfacturaspromopartds_2_tffacturafecharegistro = AV41TFFacturaFechaRegistro;
         AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to = AV42TFFacturaFechaRegistro_To;
         AV239Wpfacturaspromopartds_4_tfpromociondescripcion = AV28TFPromocionDescripcion;
         AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel = AV29TFPromocionDescripcion_Sel;
         AV241Wpfacturaspromopartds_6_tffacturano = AV34TFFacturaNo;
         AV242Wpfacturaspromopartds_7_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV243Wpfacturaspromopartds_8_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV244Wpfacturaspromopartds_9_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV245Wpfacturaspromopartds_10_tfestatus = AV74TFEstatus;
         AV246Wpfacturaspromopartds_11_tfestatusoperator = AV75TFEstatusOperator;
         AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto = AV48TFUsuarioNombreCompleto;
         AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel = AV49TFUsuarioNombreCompleto_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV124FromDate, AV125ToDate, AV15FilterFullText, AV71PromocionID, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV235Pgmname, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV74TFEstatus, AV75TFEstatusOperator, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV83UsuarioID, AV69Estatus, AV90RegUsuarioID, A11DistribuidorDescripcion, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV236Wpfacturaspromopartds_1_filterfulltext = AV15FilterFullText;
         AV237Wpfacturaspromopartds_2_tffacturafecharegistro = AV41TFFacturaFechaRegistro;
         AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to = AV42TFFacturaFechaRegistro_To;
         AV239Wpfacturaspromopartds_4_tfpromociondescripcion = AV28TFPromocionDescripcion;
         AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel = AV29TFPromocionDescripcion_Sel;
         AV241Wpfacturaspromopartds_6_tffacturano = AV34TFFacturaNo;
         AV242Wpfacturaspromopartds_7_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV243Wpfacturaspromopartds_8_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV244Wpfacturaspromopartds_9_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV245Wpfacturaspromopartds_10_tfestatus = AV74TFEstatus;
         AV246Wpfacturaspromopartds_11_tfestatusoperator = AV75TFEstatusOperator;
         AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto = AV48TFUsuarioNombreCompleto;
         AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel = AV49TFUsuarioNombreCompleto_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV124FromDate, AV125ToDate, AV15FilterFullText, AV71PromocionID, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV235Pgmname, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV74TFEstatus, AV75TFEstatusOperator, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV83UsuarioID, AV69Estatus, AV90RegUsuarioID, A11DistribuidorDescripcion, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV235Pgmname = "WPFacturasPromoPart";
         edtavUseraction8_Enabled = 0;
         edtavPartidaswithtags_Enabled = 0;
         edtavPartidas_Enabled = 0;
         edtavUseraction2_Enabled = 0;
         edtavEstatuswithtags_Enabled = 0;
         edtavEstatus_Enabled = 0;
         edtavDescripcion_Enabled = 0;
         edtavDistribuidordescripcion_Enabled = 0;
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
         fix_multi_value_controls( ) ;
      }

      protected void STRUP300( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19302 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vELEMENTS"), AV225Elements);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vPARAMETERS"), AV226Parameters);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMCLICKDATA"), AV227ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMDOUBLECLICKDATA"), AV228ItemDoubleClickData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDRAGANDDROPDATA"), AV229DragAndDropData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERCHANGEDDATA"), AV230FilterChangedData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMEXPANDDATA"), AV231ItemExpandData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMCOLLAPSEDATA"), AV232ItemCollapseData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV21ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV62DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCOLUMNSSELECTOR"), AV18ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_61 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_61"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV64GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV65GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV66GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            AV221DDO_FacturaFechaRegistroAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_FACTURAFECHAREGISTROAUXDATE"), 0);
            AV222DDO_FacturaFechaRegistroAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_FACTURAFECHAREGISTROAUXDATETO"), 0);
            AV223DDO_FacturaFechaFacturaAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_FACTURAFECHAFACTURAAUXDATE"), 0);
            AV224DDO_FacturaFechaFacturaAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_FACTURAFECHAFACTURAAUXDATETO"), 0);
            wcpOAV71PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV71PromocionID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Ddo_grid_Fixable = cgiGet( sPrefix+"DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Ddo_grid_Fixedfilters = cgiGet( sPrefix+"DDO_GRID_Fixedfilters");
            Ddo_grid_Selectedfixedfilter = cgiGet( sPrefix+"DDO_GRID_Selectedfixedfilter");
            Ddo_gridcolumnsselector_Icontype = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hascolumnsselector"));
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
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavFromdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "From Date", "")}), 1, "vFROMDATE");
               GX_FocusControl = edtavFromdate_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV124FromDate = DateTime.MinValue;
               AssignAttri(sPrefix, false, "AV124FromDate", context.localUtil.Format(AV124FromDate, "99/99/99"));
            }
            else
            {
               AV124FromDate = context.localUtil.CToD( cgiGet( edtavFromdate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV124FromDate", context.localUtil.Format(AV124FromDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTodate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "To Date", "")}), 1, "vTODATE");
               GX_FocusControl = edtavTodate_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV125ToDate = DateTime.MinValue;
               AssignAttri(sPrefix, false, "AV125ToDate", context.localUtil.Format(AV125ToDate, "99/99/99"));
            }
            else
            {
               AV125ToDate = context.localUtil.CToD( cgiGet( edtavTodate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV125ToDate", context.localUtil.Format(AV125ToDate, "99/99/99"));
            }
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            AV45DDO_FacturaFechaRegistroAuxDateText = cgiGet( edtavDdo_facturafecharegistroauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV45DDO_FacturaFechaRegistroAuxDateText", AV45DDO_FacturaFechaRegistroAuxDateText);
            AV40DDO_FacturaFechaFacturaAuxDateText = cgiGet( edtavDdo_facturafechafacturaauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV40DDO_FacturaFechaFacturaAuxDateText", AV40DDO_FacturaFechaFacturaAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV13OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( sPrefix+"GXH_vFROMDATE"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV124FromDate ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( sPrefix+"GXH_vTODATE"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV125ToDate ) )
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
         E19302 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19302( )
      {
         /* Start Routine */
         returnInSub = false;
         AV125ToDate = DateTimeUtil.Today( context);
         AssignAttri(sPrefix, false, "AV125ToDate", context.localUtil.Format(AV125ToDate, "99/99/99"));
         AV124FromDate = DateTimeUtil.AddMth( AV125ToDate, -3);
         AssignAttri(sPrefix, false, "AV124FromDate", context.localUtil.Format(AV124FromDate, "99/99/99"));
         /* Execute user subroutine: 'OBTIENELISTAUSUARIOS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Utchartdoughnut_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPFacturaEstatusFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV124FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV125ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV180ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartdoughnut.SendProperty(context, sPrefix, false, Utchartdoughnut_Internalname, "Object", Utchartdoughnut_Objectcall);
         Utchartcolumnline_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPGraficaFacturasPorMesFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV124FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV125ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV180ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartcolumnline.SendProperty(context, sPrefix, false, Utchartcolumnline_Internalname, "Object", Utchartcolumnline_Objectcall);
         AV79UsuarioJSON = AV80WebSession.Get(context.GetMessage( "Usuario", ""));
         AV81SDTUsuario.FromJSonString(AV79UsuarioJSON, null);
         AV83UsuarioID = AV81SDTUsuario.gxTpr_Usuarioid;
         AssignAttri(sPrefix, false, "AV83UsuarioID", StringUtil.LTrimStr( (decimal)(AV83UsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV83UsuarioID), "ZZZZZZZZ9"), context));
         AV82UsuarioRol = AV81SDTUsuario.gxTpr_Usuariorol;
         if ( StringUtil.StrCmp(AV82UsuarioRol, "Participante") == 0 )
         {
            edtavUseraction2_Visible = 1;
            AssignProp(sPrefix, false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_61_Refreshing);
         }
         else
         {
            edtavUseraction2_Visible = 0;
            AssignProp(sPrefix, false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_61_Refreshing);
         }
         Popover_partidas_Gridinternalname = subGrid_Internalname;
         ucPopover_partidas.SendProperty(context, sPrefix, false, Popover_partidas_Internalname, "GridInternalName", Popover_partidas_Gridinternalname);
         Popover_partidas_Iteminternalname = edtavPartidaswithtags_Internalname;
         ucPopover_partidas.SendProperty(context, sPrefix, false, Popover_partidas_Internalname, "ItemInternalName", Popover_partidas_Iteminternalname);
         this.executeUsercontrolMethod(sPrefix, false, "TFFACTURAFECHAFACTURA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_facturafechafacturaauxdatetext_Internalname});
         this.executeUsercontrolMethod(sPrefix, false, "TFFACTURAFECHAREGISTRO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_facturafecharegistroauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, sPrefix, false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV12OrderedBy < 1 )
         {
            AV12OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV62DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV62DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, sPrefix, false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E20302( )
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
         if ( AV23ManageFiltersExecutionStep == 1 )
         {
            AV23ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV23ManageFiltersExecutionStep == 2 )
         {
            AV23ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV20Session.Get("WPFacturasPromoPartColumnsSelector"), "") != 0 )
         {
            AV16ColumnsSelectorXML = AV20Session.Get("WPFacturasPromoPartColumnsSelector");
            AV18ColumnsSelector.FromXml(AV16ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtFacturaFechaRegistro_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtFacturaFechaRegistro_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaFechaRegistro_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtPromocionDescripcion_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtPromocionDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPromocionDescripcion_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtFacturaNo_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtFacturaNo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaNo_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtFacturaFechaFactura_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtFacturaFechaFactura_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaFechaFactura_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtavPartidaswithtags_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtavPartidaswithtags_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPartidaswithtags_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtavEstatuswithtags_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtavEstatuswithtags_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEstatuswithtags_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtavDescripcion_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtavDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDescripcion_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtUsuarioNombreCompleto_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtUsuarioNombreCompleto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombreCompleto_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtavDistribuidordescripcion_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtavDistribuidordescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDistribuidordescripcion_Visible), 5, 0), !bGXsfl_61_Refreshing);
         AV64GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV64GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV64GridCurrentPage), 10, 0));
         AV65GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV65GridPageCount", StringUtil.LTrimStr( (decimal)(AV65GridPageCount), 10, 0));
         GXt_char2 = AV66GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV235Pgmname, out  GXt_char2) ;
         AV66GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV66GridAppliedFilters", AV66GridAppliedFilters);
         AV79UsuarioJSON = AV80WebSession.Get(context.GetMessage( "Usuario", ""));
         AV81SDTUsuario.FromJSonString(AV79UsuarioJSON, null);
         AV82UsuarioRol = AV81SDTUsuario.gxTpr_Usuariorol;
         if ( StringUtil.StrCmp(AV82UsuarioRol, "Participante") == 0 )
         {
            edtavUseraction2_Visible = 1;
            AssignProp(sPrefix, false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_61_Refreshing);
         }
         else
         {
            edtavUseraction2_Visible = 0;
            AssignProp(sPrefix, false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_61_Refreshing);
         }
         AV236Wpfacturaspromopartds_1_filterfulltext = AV15FilterFullText;
         AV237Wpfacturaspromopartds_2_tffacturafecharegistro = AV41TFFacturaFechaRegistro;
         AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to = AV42TFFacturaFechaRegistro_To;
         AV239Wpfacturaspromopartds_4_tfpromociondescripcion = AV28TFPromocionDescripcion;
         AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel = AV29TFPromocionDescripcion_Sel;
         AV241Wpfacturaspromopartds_6_tffacturano = AV34TFFacturaNo;
         AV242Wpfacturaspromopartds_7_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV243Wpfacturaspromopartds_8_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV244Wpfacturaspromopartds_9_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV245Wpfacturaspromopartds_10_tfestatus = AV74TFEstatus;
         AV246Wpfacturaspromopartds_11_tfestatusoperator = AV75TFEstatusOperator;
         AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto = AV48TFUsuarioNombreCompleto;
         AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel = AV49TFUsuarioNombreCompleto_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV180ListaUsuarios", AV180ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E12302( )
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
            AV63PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV63PageToGo) ;
         }
      }

      protected void E13302( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14302( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
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
               AV41TFFacturaFechaRegistro = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV41TFFacturaFechaRegistro", context.localUtil.Format(AV41TFFacturaFechaRegistro, "99/99/99"));
               AV42TFFacturaFechaRegistro_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV42TFFacturaFechaRegistro_To", context.localUtil.Format(AV42TFFacturaFechaRegistro_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PromocionDescripcion") == 0 )
            {
               AV28TFPromocionDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV28TFPromocionDescripcion", AV28TFPromocionDescripcion);
               AV29TFPromocionDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV29TFPromocionDescripcion_Sel", AV29TFPromocionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaNo") == 0 )
            {
               AV34TFFacturaNo = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV34TFFacturaNo", AV34TFFacturaNo);
               AV35TFFacturaNo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV35TFFacturaNo_Sel", AV35TFFacturaNo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaFechaFactura") == 0 )
            {
               AV36TFFacturaFechaFactura = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV36TFFacturaFechaFactura", context.localUtil.Format(AV36TFFacturaFechaFactura, "99/99/99"));
               AV37TFFacturaFechaFactura_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV37TFFacturaFechaFactura_To", context.localUtil.Format(AV37TFFacturaFechaFactura_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Estatus") == 0 )
            {
               if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "1") == 0 )
               {
                  AV75TFEstatusOperator = 1;
                  AssignAttri(sPrefix, false, "AV75TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV75TFEstatusOperator), 4, 0));
                  AV74TFEstatus = "";
                  AssignAttri(sPrefix, false, "AV74TFEstatus", AV74TFEstatus);
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "2") == 0 )
               {
                  AV75TFEstatusOperator = 2;
                  AssignAttri(sPrefix, false, "AV75TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV75TFEstatusOperator), 4, 0));
                  AV74TFEstatus = "";
                  AssignAttri(sPrefix, false, "AV74TFEstatus", AV74TFEstatus);
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "3") == 0 )
               {
                  AV75TFEstatusOperator = 3;
                  AssignAttri(sPrefix, false, "AV75TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV75TFEstatusOperator), 4, 0));
                  AV74TFEstatus = "";
                  AssignAttri(sPrefix, false, "AV74TFEstatus", AV74TFEstatus);
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "4") == 0 )
               {
                  AV75TFEstatusOperator = 4;
                  AssignAttri(sPrefix, false, "AV75TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV75TFEstatusOperator), 4, 0));
                  AV74TFEstatus = "";
                  AssignAttri(sPrefix, false, "AV74TFEstatus", AV74TFEstatus);
               }
               else
               {
                  AV75TFEstatusOperator = 0;
                  AssignAttri(sPrefix, false, "AV75TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV75TFEstatusOperator), 4, 0));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioNombreCompleto") == 0 )
            {
               AV48TFUsuarioNombreCompleto = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV48TFUsuarioNombreCompleto", AV48TFUsuarioNombreCompleto);
               AV49TFUsuarioNombreCompleto_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV49TFUsuarioNombreCompleto_Sel", AV49TFUsuarioNombreCompleto_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E21302( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
         {
            AV73Descripcion = A20MotivoRechazoDescripcion;
            AssignAttri(sPrefix, false, edtavDescripcion_Internalname, AV73Descripcion);
         }
         else
         {
            AV73Descripcion = context.GetMessage( "NA", "");
            AssignAttri(sPrefix, false, edtavDescripcion_Internalname, AV73Descripcion);
         }
         AV87Partidas = context.GetMessage( "Partidas", "");
         AssignAttri(sPrefix, false, edtavPartidas_Internalname, AV87Partidas);
         AV90RegUsuarioID = A29UsuarioID;
         AssignAttri(sPrefix, false, "AV90RegUsuarioID", StringUtil.LTrimStr( (decimal)(AV90RegUsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREGUSUARIOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV90RegUsuarioID), "ZZZZZZZZ9"), context));
         /* Execute user subroutine: 'OBTIENEDISTRIBUIDOR' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         edtavUseraction4_gximage = "iconoPDF";
         AV77UserAction4 = context.GetImagePath( "b97efd0f-8d9d-4227-92c4-9cbec8912646", "", context.GetTheme( ));
         AssignAttri(sPrefix, false, edtavUseraction4_Internalname, AV77UserAction4);
         AV249Useraction4_GXI = GXDbFile.PathToUrl( context.GetImagePath( "b97efd0f-8d9d-4227-92c4-9cbec8912646", "", context.GetTheme( )), context);
         edtavUseraction4_Tooltiptext = "";
         AV78UserAction8 = "<i class=\"IconoEditarAzul fas fa-magnifying-glass\"></i>";
         AssignAttri(sPrefix, false, edtavUseraction8_Internalname, AV78UserAction8);
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
         AV76UserAction2 = context.GetMessage( "Cancelar factura", "");
         AssignAttri(sPrefix, false, edtavUseraction2_Internalname, AV76UserAction2);
         GXt_char2 = AV88PartidasWithTags;
         new WorkWithPlus.workwithplus_web.wwp_encodehtml(context ).execute(  AV87Partidas, out  GXt_char2) ;
         AV88PartidasWithTags = GXt_char2;
         AssignAttri(sPrefix, false, edtavPartidaswithtags_Internalname, AV88PartidasWithTags);
         AV88PartidasWithTags += "<i class='WWPPopoverIcon FontColorIcon fas fa-angle-down'></i>";
         AssignAttri(sPrefix, false, edtavPartidaswithtags_Internalname, AV88PartidasWithTags);
         GXt_char2 = AV70EstatusWithTags;
         new WorkWithPlus.workwithplus_web.wwp_encodehtml(context ).execute(  AV69Estatus, out  GXt_char2) ;
         AV70EstatusWithTags = GXt_char2;
         AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV70EstatusWithTags);
         if ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 )
         {
            AV70EstatusWithTags += StringUtil.Format( "<span class='AttributeTagWarning TagAfterText'>%1</span>", context.GetMessage( "En proceso", ""), "", "", "", "", "", "", "", "");
            AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV70EstatusWithTags);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 )
         {
            AV70EstatusWithTags += StringUtil.Format( "<span class='AttributeTagSuccess TagAfterText'>%1</span>", context.GetMessage( "Aprobada", ""), "", "", "", "", "", "", "", "");
            AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV70EstatusWithTags);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
         {
            AV70EstatusWithTags += StringUtil.Format( "<span class='AttributeTagDanger TagAfterText'>%1</span>", context.GetMessage( "Rechazada", ""), "", "", "", "", "", "", "", "");
            AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV70EstatusWithTags);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Cancelada") == 0 )
         {
            AV70EstatusWithTags += StringUtil.Format( "<span class='AttributeTagInfo TagAfterText'>%1</span>", context.GetMessage( "Cancelada", ""), "", "", "", "", "", "", "", "");
            AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV70EstatusWithTags);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 61;
         }
         sendrow_612( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_61_Refreshing )
         {
            DoAjaxLoad(61, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E15302( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV16ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV18ColumnsSelector.FromJSonString(AV16ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WPFacturasPromoPartColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV16ColumnsSelectorXML)) ? "" : AV18ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV180ListaUsuarios", AV180ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E11302( )
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
            S162 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WPFacturasPromoPartFilters")) + "," + UrlEncode(StringUtil.RTrim(AV235Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV23ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WPFacturasPromoPartFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV23ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV22ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WPFacturasPromoPartFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV22ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22ManageFiltersXml)) )
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
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV235Pgmname+"GridState",  AV22ManageFiltersXml) ;
               AV10GridState.FromXml(AV22ManageFiltersXml, null, "", "");
               AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
               AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S152 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV180ListaUsuarios", AV180ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21ManageFiltersData", AV21ManageFiltersData);
      }

      protected void E16302( )
      {
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         AV85SDTPromocion = new SdtSDTPromocion(context);
         AV85SDTPromocion.gxTpr_Promocionid = AV71PromocionID;
         AV86PromocionJSON = AV85SDTPromocion.ToJSonString(false, true);
         AV80WebSession.Set(context.GetMessage( "Promocion", ""), AV86PromocionJSON);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpfacturawizard.aspx"+UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.BoolToStr(false));
         CallWebObject(formatLink("wpfacturawizard.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV180ListaUsuarios", AV180ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E17302( )
      {
         /* 'DoExcelDetallado' Routine */
         returnInSub = false;
         AV116ListaUsuarioID.Clear();
         AV116ListaUsuarioID.Add(AV83UsuarioID, 0);
         new generaexcelpartidasfiltrado(context ).execute(  AV71PromocionID,  AV116ListaUsuarioID, out  AV105ExcelFilename, out  AV103ErrorMessage) ;
         if ( StringUtil.StrCmp(AV105ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV105ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
      }

      protected void E18302( )
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
         Utchartdoughnut_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPFacturaEstatusFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV124FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV125ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV180ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartdoughnut.SendProperty(context, sPrefix, false, Utchartdoughnut_Internalname, "Object", Utchartdoughnut_Objectcall);
         Utchartcolumnline_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPGraficaFacturasPorMesFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV124FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV125ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV180ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartcolumnline.SendProperty(context, sPrefix, false, Utchartcolumnline_Internalname, "Object", Utchartcolumnline_Objectcall);
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV124FromDate, AV125ToDate, AV15FilterFullText, AV71PromocionID, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV235Pgmname, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV74TFEstatus, AV75TFEstatusOperator, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV83UsuarioID, AV69Estatus, AV90RegUsuarioID, A11DistribuidorDescripcion, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV180ListaUsuarios", AV180ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E22302( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0096",(string)"",(int)A69FacturaID});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0096"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV18ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "FacturaFechaRegistro",  "",  "Fecha Registro",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "PromocionDescripcion",  "",  "Nom. Promoción",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "FacturaNo",  "",  "No. Factura",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "FacturaFechaFactura",  "",  "Fecha Factura",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "&Partidas",  "",  "Partidas",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "&Estatus",  "",  "Estatus",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "&Descripcion",  "",  "Motivo de rechazo",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "UsuarioNombreCompleto",  "",  "Nombre completo",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "&DistribuidorDescripcion",  "",  "Distribuidor al que representa",  true,  "") ;
         GXt_char2 = AV17UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WPFacturasPromoPartColumnsSelector", out  GXt_char2) ;
         AV17UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV17UserCustomValue)) ) )
         {
            AV19ColumnsSelectorAux.FromXml(AV17UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV19ColumnsSelectorAux, ref  AV18ColumnsSelector) ;
         }
      }

      protected void S122( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV21ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WPFacturasPromoPartFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV21ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S192( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
         AV41TFFacturaFechaRegistro = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV41TFFacturaFechaRegistro", context.localUtil.Format(AV41TFFacturaFechaRegistro, "99/99/99"));
         AV42TFFacturaFechaRegistro_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV42TFFacturaFechaRegistro_To", context.localUtil.Format(AV42TFFacturaFechaRegistro_To, "99/99/99"));
         AV28TFPromocionDescripcion = "";
         AssignAttri(sPrefix, false, "AV28TFPromocionDescripcion", AV28TFPromocionDescripcion);
         AV29TFPromocionDescripcion_Sel = "";
         AssignAttri(sPrefix, false, "AV29TFPromocionDescripcion_Sel", AV29TFPromocionDescripcion_Sel);
         AV34TFFacturaNo = "";
         AssignAttri(sPrefix, false, "AV34TFFacturaNo", AV34TFFacturaNo);
         AV35TFFacturaNo_Sel = "";
         AssignAttri(sPrefix, false, "AV35TFFacturaNo_Sel", AV35TFFacturaNo_Sel);
         AV36TFFacturaFechaFactura = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV36TFFacturaFechaFactura", context.localUtil.Format(AV36TFFacturaFechaFactura, "99/99/99"));
         AV37TFFacturaFechaFactura_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV37TFFacturaFechaFactura_To", context.localUtil.Format(AV37TFFacturaFechaFactura_To, "99/99/99"));
         AV75TFEstatusOperator = 0;
         AssignAttri(sPrefix, false, "AV75TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV75TFEstatusOperator), 4, 0));
         Ddo_grid_Selectedfixedfilter = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
         AV48TFUsuarioNombreCompleto = "";
         AssignAttri(sPrefix, false, "AV48TFUsuarioNombreCompleto", AV48TFUsuarioNombreCompleto);
         AV49TFUsuarioNombreCompleto_Sel = "";
         AssignAttri(sPrefix, false, "AV49TFUsuarioNombreCompleto_Sel", AV49TFUsuarioNombreCompleto_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S142( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20Session.Get(AV235Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV235Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV20Session.Get(AV235Pgmname+"GridState"), null, "", "");
         }
         AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S152 ();
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S202( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV250GXV1 = 1;
         while ( AV250GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV250GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAREGISTRO") == 0 )
            {
               AV41TFFacturaFechaRegistro = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV41TFFacturaFechaRegistro", context.localUtil.Format(AV41TFFacturaFechaRegistro, "99/99/99"));
               AV42TFFacturaFechaRegistro_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV42TFFacturaFechaRegistro_To", context.localUtil.Format(AV42TFFacturaFechaRegistro_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION") == 0 )
            {
               AV28TFPromocionDescripcion = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV28TFPromocionDescripcion", AV28TFPromocionDescripcion);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION_SEL") == 0 )
            {
               AV29TFPromocionDescripcion_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV29TFPromocionDescripcion_Sel", AV29TFPromocionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURANO") == 0 )
            {
               AV34TFFacturaNo = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV34TFFacturaNo", AV34TFFacturaNo);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURANO_SEL") == 0 )
            {
               AV35TFFacturaNo_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV35TFFacturaNo_Sel", AV35TFFacturaNo_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAFACTURA") == 0 )
            {
               AV36TFFacturaFechaFactura = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV36TFFacturaFechaFactura", context.localUtil.Format(AV36TFFacturaFechaFactura, "99/99/99"));
               AV37TFFacturaFechaFactura_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV37TFFacturaFechaFactura_To", context.localUtil.Format(AV37TFFacturaFechaFactura_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFESTATUS") == 0 )
            {
               AV75TFEstatusOperator = AV11GridStateFilterValue.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV75TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV75TFEstatusOperator), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO") == 0 )
            {
               AV48TFUsuarioNombreCompleto = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV48TFUsuarioNombreCompleto", AV48TFUsuarioNombreCompleto);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO_SEL") == 0 )
            {
               AV49TFUsuarioNombreCompleto_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV49TFUsuarioNombreCompleto_Sel", AV49TFUsuarioNombreCompleto_Sel);
            }
            AV250GXV1 = (int)(AV250GXV1+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFPromocionDescripcion_Sel)),  AV29TFPromocionDescripcion_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFFacturaNo_Sel)),  AV35TFFacturaNo_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFUsuarioNombreCompleto_Sel)),  AV49TFUsuarioNombreCompleto_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char4+"|||||"+GXt_char5+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFPromocionDescripcion)),  AV28TFPromocionDescripcion, out  GXt_char5) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFFacturaNo)),  AV34TFFacturaNo, out  GXt_char4) ;
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFUsuarioNombreCompleto)),  AV48TFUsuarioNombreCompleto, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((DateTime.MinValue==AV41TFFacturaFechaRegistro) ? "" : context.localUtil.DToC( AV41TFFacturaFechaRegistro, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+GXt_char5+"|"+GXt_char4+"|"+((DateTime.MinValue==AV36TFFacturaFechaFactura) ? "" : context.localUtil.DToC( AV36TFFacturaFechaFactura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"||||"+GXt_char2+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((DateTime.MinValue==AV42TFFacturaFechaRegistro_To) ? "" : context.localUtil.DToC( AV42TFFacturaFechaRegistro_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|||"+((DateTime.MinValue==AV37TFFacturaFechaFactura_To) ? "" : context.localUtil.DToC( AV37TFFacturaFechaFactura_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|||||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         Ddo_grid_Selectedfixedfilter = "|||||"+((AV75TFEstatusOperator!=1) ? "" : "1")+((AV75TFEstatusOperator!=2) ? "" : "2")+((AV75TFEstatusOperator!=3) ? "" : "3")+((AV75TFEstatusOperator!=4) ? "" : "4")+"|||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV20Session.Get(AV235Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFACTURAFECHAREGISTRO",  context.GetMessage( "Fecha Registro", ""),  !((DateTime.MinValue==AV41TFFacturaFechaRegistro)&&(DateTime.MinValue==AV42TFFacturaFechaRegistro_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV41TFFacturaFechaRegistro, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV41TFFacturaFechaRegistro) ? "" : StringUtil.Trim( context.localUtil.Format( AV41TFFacturaFechaRegistro, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV42TFFacturaFechaRegistro_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV42TFFacturaFechaRegistro_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV42TFFacturaFechaRegistro_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROMOCIONDESCRIPCION",  context.GetMessage( "Nom. Promoción", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFPromocionDescripcion)),  0,  AV28TFPromocionDescripcion,  AV28TFPromocionDescripcion,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFPromocionDescripcion_Sel)),  AV29TFPromocionDescripcion_Sel,  AV29TFPromocionDescripcion_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFFACTURANO",  context.GetMessage( "No. Factura", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFFacturaNo)),  0,  AV34TFFacturaNo,  AV34TFFacturaNo,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFFacturaNo_Sel)),  AV35TFFacturaNo_Sel,  AV35TFFacturaNo_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFACTURAFECHAFACTURA",  context.GetMessage( "Fecha Factura", ""),  !((DateTime.MinValue==AV36TFFacturaFechaFactura)&&(DateTime.MinValue==AV37TFFacturaFechaFactura_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV36TFFacturaFechaFactura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV36TFFacturaFechaFactura) ? "" : StringUtil.Trim( context.localUtil.Format( AV36TFFacturaFechaFactura, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV37TFFacturaFechaFactura_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV37TFFacturaFechaFactura_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV37TFFacturaFechaFactura_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFESTATUS",  context.GetMessage( "Estatus", ""),  !(String.IsNullOrEmpty(StringUtil.RTrim( AV74TFEstatus))&&(0==AV75TFEstatusOperator)),  AV75TFEstatusOperator,  AV74TFEstatus,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV75TFEstatusOperator+1), 10, 0)), AV74TFEstatus, context.GetMessage( "En proceso", ""), context.GetMessage( "Aprobada", ""), context.GetMessage( "Rechazada", ""), context.GetMessage( "Cancelada", ""), "", "", "", ""),  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFUSUARIONOMBRECOMPLETO",  context.GetMessage( "Nombre completo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFUsuarioNombreCompleto)),  0,  AV48TFUsuarioNombreCompleto,  AV48TFUsuarioNombreCompleto,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFUsuarioNombreCompleto_Sel)),  AV49TFUsuarioNombreCompleto_Sel,  AV49TFUsuarioNombreCompleto_Sel) ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV235Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S132( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV235Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Factura";
         AV20Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void E23302( )
      {
         /* Useraction4_Click Routine */
         returnInSub = false;
         AV93FacturaID = A69FacturaID;
         AssignAttri(sPrefix, false, "AV93FacturaID", StringUtil.LTrimStr( (decimal)(AV93FacturaID), 9, 0));
         /* Execute user subroutine: 'OBTIENEPDF' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV92FileURL = context.PathToUrl( AV91Blob);
         Innwewindow_Target = AV92FileURL;
         ucInnwewindow.SendProperty(context, sPrefix, false, Innwewindow_Internalname, "Target", Innwewindow_Target);
         this.executeUsercontrolMethod(sPrefix, false, "INNWEWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E24302( )
      {
         /* Useraction2_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Cancelada") == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "La factura ya ha sido cancelada", ""));
         }
         else if ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "No se puede cancelar una factura aprobada", ""));
         }
         else if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "No se puede cancelar una factura rechazada", ""));
         }
         else
         {
            new cancelarfactura(context ).execute(  A69FacturaID) ;
            context.DoAjaxRefreshCmp(sPrefix);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV180ListaUsuarios", AV180ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void S182( )
      {
         /* 'OBTIENEDISTRIBUIDOR' Routine */
         returnInSub = false;
         /* Using cursor H00304 */
         pr_default.execute(2, new Object[] {AV90RegUsuarioID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A10DistribuidorID = H00304_A10DistribuidorID[0];
            A29UsuarioID = H00304_A29UsuarioID[0];
            A11DistribuidorDescripcion = H00304_A11DistribuidorDescripcion[0];
            A11DistribuidorDescripcion = H00304_A11DistribuidorDescripcion[0];
            AV89DistribuidorDescripcion = A11DistribuidorDescripcion;
            AssignAttri(sPrefix, false, edtavDistribuidordescripcion_Internalname, AV89DistribuidorDescripcion);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S212( )
      {
         /* 'OBTIENEPDF' Routine */
         returnInSub = false;
         /* Using cursor H00305 */
         pr_default.execute(3, new Object[] {AV93FacturaID});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A69FacturaID = H00305_A69FacturaID[0];
            A40000FacturaPDF_GXI = H00305_A40000FacturaPDF_GXI[0];
            A75FacturaPDF = H00305_A75FacturaPDF[0];
            AV91Blob = A75FacturaPDF;
            AssignAttri(sPrefix, false, "AV91Blob", AV91Blob);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
      }

      protected void S112( )
      {
         /* 'OBTIENELISTAUSUARIOS' Routine */
         returnInSub = false;
         AV180ListaUsuarios.Clear();
         AV180ListaUsuarios.Add(AV83UsuarioID, 0);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV71PromocionID = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV71PromocionID", StringUtil.LTrimStr( (decimal)(AV71PromocionID), 9, 0));
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
         PA302( ) ;
         WS302( ) ;
         WE302( ) ;
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
         sCtrlAV71PromocionID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA302( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpfacturaspromopart", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA302( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV71PromocionID = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV71PromocionID", StringUtil.LTrimStr( (decimal)(AV71PromocionID), 9, 0));
         }
         wcpOAV71PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV71PromocionID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV71PromocionID != wcpOAV71PromocionID ) ) )
         {
            setjustcreated();
         }
         wcpOAV71PromocionID = AV71PromocionID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV71PromocionID = cgiGet( sPrefix+"AV71PromocionID_CTRL");
         if ( StringUtil.Len( sCtrlAV71PromocionID) > 0 )
         {
            AV71PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV71PromocionID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV71PromocionID", StringUtil.LTrimStr( (decimal)(AV71PromocionID), 9, 0));
         }
         else
         {
            AV71PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV71PromocionID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA302( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS302( ) ;
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
         WS302( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV71PromocionID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV71PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV71PromocionID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV71PromocionID_CTRL", StringUtil.RTrim( sCtrlAV71PromocionID));
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
         WE302( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026511113164", true, true);
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
         context.AddJavascriptSource("wpfacturaspromopart.js", "?2026511113165", false, true);
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

      protected void SubsflControlProps_612( )
      {
         edtFacturaID_Internalname = sPrefix+"FACTURAID_"+sGXsfl_61_idx;
         edtavUseraction4_Internalname = sPrefix+"vUSERACTION4_"+sGXsfl_61_idx;
         edtavUseraction8_Internalname = sPrefix+"vUSERACTION8_"+sGXsfl_61_idx;
         edtFacturaFechaRegistro_Internalname = sPrefix+"FACTURAFECHAREGISTRO_"+sGXsfl_61_idx;
         edtPromocionDescripcion_Internalname = sPrefix+"PROMOCIONDESCRIPCION_"+sGXsfl_61_idx;
         edtFacturaNo_Internalname = sPrefix+"FACTURANO_"+sGXsfl_61_idx;
         edtFacturaFechaFactura_Internalname = sPrefix+"FACTURAFECHAFACTURA_"+sGXsfl_61_idx;
         edtavPartidaswithtags_Internalname = sPrefix+"vPARTIDASWITHTAGS_"+sGXsfl_61_idx;
         edtavPartidas_Internalname = sPrefix+"vPARTIDAS_"+sGXsfl_61_idx;
         edtavUseraction2_Internalname = sPrefix+"vUSERACTION2_"+sGXsfl_61_idx;
         edtavEstatuswithtags_Internalname = sPrefix+"vESTATUSWITHTAGS_"+sGXsfl_61_idx;
         edtavEstatus_Internalname = sPrefix+"vESTATUS_"+sGXsfl_61_idx;
         edtavDescripcion_Internalname = sPrefix+"vDESCRIPCION_"+sGXsfl_61_idx;
         cmbFacturaEstatus_Internalname = sPrefix+"FACTURAESTATUS_"+sGXsfl_61_idx;
         edtUsuarioID_Internalname = sPrefix+"USUARIOID_"+sGXsfl_61_idx;
         edtUsuarioNombreCompleto_Internalname = sPrefix+"USUARIONOMBRECOMPLETO_"+sGXsfl_61_idx;
         chkMotivoRechazoActivo_Internalname = sPrefix+"MOTIVORECHAZOACTIVO_"+sGXsfl_61_idx;
         edtMotivoRechazoDescripcion_Internalname = sPrefix+"MOTIVORECHAZODESCRIPCION_"+sGXsfl_61_idx;
         edtMotivoRechazoID_Internalname = sPrefix+"MOTIVORECHAZOID_"+sGXsfl_61_idx;
         edtavDistribuidordescripcion_Internalname = sPrefix+"vDISTRIBUIDORDESCRIPCION_"+sGXsfl_61_idx;
      }

      protected void SubsflControlProps_fel_612( )
      {
         edtFacturaID_Internalname = sPrefix+"FACTURAID_"+sGXsfl_61_fel_idx;
         edtavUseraction4_Internalname = sPrefix+"vUSERACTION4_"+sGXsfl_61_fel_idx;
         edtavUseraction8_Internalname = sPrefix+"vUSERACTION8_"+sGXsfl_61_fel_idx;
         edtFacturaFechaRegistro_Internalname = sPrefix+"FACTURAFECHAREGISTRO_"+sGXsfl_61_fel_idx;
         edtPromocionDescripcion_Internalname = sPrefix+"PROMOCIONDESCRIPCION_"+sGXsfl_61_fel_idx;
         edtFacturaNo_Internalname = sPrefix+"FACTURANO_"+sGXsfl_61_fel_idx;
         edtFacturaFechaFactura_Internalname = sPrefix+"FACTURAFECHAFACTURA_"+sGXsfl_61_fel_idx;
         edtavPartidaswithtags_Internalname = sPrefix+"vPARTIDASWITHTAGS_"+sGXsfl_61_fel_idx;
         edtavPartidas_Internalname = sPrefix+"vPARTIDAS_"+sGXsfl_61_fel_idx;
         edtavUseraction2_Internalname = sPrefix+"vUSERACTION2_"+sGXsfl_61_fel_idx;
         edtavEstatuswithtags_Internalname = sPrefix+"vESTATUSWITHTAGS_"+sGXsfl_61_fel_idx;
         edtavEstatus_Internalname = sPrefix+"vESTATUS_"+sGXsfl_61_fel_idx;
         edtavDescripcion_Internalname = sPrefix+"vDESCRIPCION_"+sGXsfl_61_fel_idx;
         cmbFacturaEstatus_Internalname = sPrefix+"FACTURAESTATUS_"+sGXsfl_61_fel_idx;
         edtUsuarioID_Internalname = sPrefix+"USUARIOID_"+sGXsfl_61_fel_idx;
         edtUsuarioNombreCompleto_Internalname = sPrefix+"USUARIONOMBRECOMPLETO_"+sGXsfl_61_fel_idx;
         chkMotivoRechazoActivo_Internalname = sPrefix+"MOTIVORECHAZOACTIVO_"+sGXsfl_61_fel_idx;
         edtMotivoRechazoDescripcion_Internalname = sPrefix+"MOTIVORECHAZODESCRIPCION_"+sGXsfl_61_fel_idx;
         edtMotivoRechazoID_Internalname = sPrefix+"MOTIVORECHAZOID_"+sGXsfl_61_fel_idx;
         edtavDistribuidordescripcion_Internalname = sPrefix+"vDISTRIBUIDORDESCRIPCION_"+sGXsfl_61_fel_idx;
      }

      protected void sendrow_612( )
      {
         sGXsfl_61_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_61_idx), 4, 0), 4, "0");
         SubsflControlProps_612( ) ;
         WB300( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_61_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_61_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_61_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'',61)\"";
            ClassString = "BotonImagenChica" + " " + ((StringUtil.StrCmp(edtavUseraction4_gximage, "")==0) ? "" : "GX_Image_"+edtavUseraction4_gximage+"_Class");
            StyleString = "";
            AV77UserAction4_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV77UserAction4))&&String.IsNullOrEmpty(StringUtil.RTrim( AV249Useraction4_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV77UserAction4)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV77UserAction4)) ? AV249Useraction4_GXI : context.PathToRelativeUrl( AV77UserAction4));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseraction4_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)edtavUseraction4_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavUseraction4_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUSERACTION4.CLICK."+sGXsfl_61_idx+"'",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV77UserAction4_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'" + sGXsfl_61_idx + "',61)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseraction8_Internalname,StringUtil.RTrim( AV78UserAction8),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavUseraction8_Link,(string)"",(string)"",(string)"",(string)edtavUseraction8_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUseraction8_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtFacturaFechaRegistro_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaRegistro_Internalname,context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"),context.localUtil.Format( A72FacturaFechaRegistro, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaRegistro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtFacturaFechaRegistro_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPromocionDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionDescripcion_Internalname,(string)A42PromocionDescripcion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPromocionDescripcion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtFacturaNo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaNo_Internalname,StringUtil.RTrim( A71FacturaNo),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaNo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtFacturaNo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtFacturaFechaFactura_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaFactura_Internalname,context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"),context.localUtil.Format( A73FacturaFechaFactura, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaFactura_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtFacturaFechaFactura_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavPartidaswithtags_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'" + sGXsfl_61_idx + "',61)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPartidaswithtags_Internalname,(string)AV88PartidasWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPartidaswithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnSizeLarge ColumnWeightBold ColumnHighlightBackground ColumnLeftDivision",(string)"",(int)edtavPartidaswithtags_Visible,(int)edtavPartidaswithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPartidas_Internalname,StringUtil.RTrim( AV87Partidas),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVPARTIDAS.CLICK."+sGXsfl_61_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPartidas_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnSizeLarge ColumnWeightBold ColumnHighlightBackground ColumnLeftDivision",(string)"",(short)0,(int)edtavPartidas_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUseraction2_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'" + sGXsfl_61_idx + "',61)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseraction2_Internalname,StringUtil.RTrim( AV76UserAction2),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUSERACTION2.CLICK."+sGXsfl_61_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUseraction2_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWActionColumn",(string)"",(int)edtavUseraction2_Visible,(int)edtavUseraction2_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavEstatuswithtags_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'" + sGXsfl_61_idx + "',61)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEstatuswithtags_Internalname,(string)AV70EstatusWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEstatuswithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavEstatuswithtags_Visible,(int)edtavEstatuswithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEstatus_Internalname,StringUtil.RTrim( AV69Estatus),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEstatus_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavEstatus_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_61_idx + "',61)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDescripcion_Internalname,(string)AV73Descripcion,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavDescripcion_Visible,(int)edtavDescripcion_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbFacturaEstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "FACTURAESTATUS_" + sGXsfl_61_idx;
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
            AssignProp(sPrefix, false, cmbFacturaEstatus_Internalname, "Values", (string)(cmbFacturaEstatus.ToJavascriptSource()), !bGXsfl_61_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtUsuarioNombreCompleto_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombreCompleto_Internalname,(string)A52UsuarioNombreCompleto,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombreCompleto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtUsuarioNombreCompleto_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "MOTIVORECHAZOACTIVO_" + sGXsfl_61_idx;
            chkMotivoRechazoActivo.Name = GXCCtl;
            chkMotivoRechazoActivo.WebTags = "";
            chkMotivoRechazoActivo.Caption = "";
            AssignProp(sPrefix, false, chkMotivoRechazoActivo_Internalname, "TitleCaption", chkMotivoRechazoActivo.Caption, !bGXsfl_61_Refreshing);
            chkMotivoRechazoActivo.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkMotivoRechazoActivo_Internalname,StringUtil.BoolToStr( A21MotivoRechazoActivo),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoRechazoDescripcion_Internalname,(string)A20MotivoRechazoDescripcion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoRechazoDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoRechazoID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MotivoRechazoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A19MotivoRechazoID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoRechazoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDistribuidordescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'" + sGXsfl_61_idx + "',61)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDistribuidordescripcion_Internalname,(string)AV89DistribuidorDescripcion,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDistribuidordescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavDistribuidordescripcion_Visible,(int)edtavDistribuidordescripcion_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes302( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_61_idx = ((subGrid_Islastpage==1)&&(nGXsfl_61_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_61_idx+1);
            sGXsfl_61_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_61_idx), 4, 0), 4, "0");
            SubsflControlProps_612( ) ;
         }
         /* End function sendrow_612 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "FACTURAESTATUS_" + sGXsfl_61_idx;
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
         GXCCtl = "MOTIVORECHAZOACTIVO_" + sGXsfl_61_idx;
         chkMotivoRechazoActivo.Name = GXCCtl;
         chkMotivoRechazoActivo.WebTags = "";
         chkMotivoRechazoActivo.Caption = "";
         AssignProp(sPrefix, false, chkMotivoRechazoActivo_Internalname, "TitleCaption", chkMotivoRechazoActivo.Caption, !bGXsfl_61_Refreshing);
         chkMotivoRechazoActivo.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl61( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"61\">") ;
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
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"BotonImagenChica"+" "+((StringUtil.StrCmp(edtavUseraction4_gximage, "")==0) ? "" : "GX_Image_"+edtavUseraction4_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtFacturaFechaRegistro_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Registro", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPromocionDescripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nom. Promoción", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtFacturaNo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "No. Factura", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtFacturaFechaFactura_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Factura", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavPartidaswithtags_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Partidas", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUseraction2_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavEstatuswithtags_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estatus", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDescripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Motivo de rechazo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtUsuarioNombreCompleto_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre completo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDistribuidordescripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", context.convertURL( AV77UserAction4));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUseraction4_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV78UserAction8)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction8_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUseraction8_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaFechaRegistro_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A42PromocionDescripcion));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPromocionDescripcion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A71FacturaNo)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaNo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A73FacturaFechaFactura, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaFechaFactura_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV88PartidasWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPartidaswithtags_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPartidaswithtags_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV87Partidas)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPartidas_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV76UserAction2)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction2_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction2_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV70EstatusWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEstatuswithtags_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEstatuswithtags_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV69Estatus)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEstatus_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV73Descripcion));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDescripcion_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDescripcion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A80FacturaEstatus)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A52UsuarioNombreCompleto));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioNombreCompleto_Visible), 5, 0, ".", "")));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV89DistribuidorDescripcion));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDistribuidordescripcion_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDistribuidordescripcion_Visible), 5, 0, ".", "")));
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
         bttBtnuseraction99_Internalname = sPrefix+"BTNUSERACTION99";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         Utchartdoughnut_Internalname = sPrefix+"UTCHARTDOUGHNUT";
         Utchartcolumnline_Internalname = sPrefix+"UTCHARTCOLUMNLINE";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         bttBtnuseraction1_Internalname = sPrefix+"BTNUSERACTION1";
         bttBtnexceldetallado_Internalname = sPrefix+"BTNEXCELDETALLADO";
         bttBtneditcolumns_Internalname = sPrefix+"BTNEDITCOLUMNS";
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
         edtavDistribuidordescripcion_Internalname = sPrefix+"vDISTRIBUIDORDESCRIPCION";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         Innwewindow_Internalname = sPrefix+"INNWEWINDOW";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Popover_partidas_Internalname = sPrefix+"POPOVER_PARTIDAS";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = sPrefix+"DDO_GRIDCOLUMNSSELECTOR";
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
         edtavDistribuidordescripcion_Jsonclick = "";
         edtavDistribuidordescripcion_Enabled = 1;
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
         edtavDistribuidordescripcion_Visible = -1;
         edtUsuarioNombreCompleto_Visible = -1;
         edtavDescripcion_Visible = -1;
         edtavEstatuswithtags_Visible = -1;
         edtavPartidaswithtags_Visible = -1;
         edtFacturaFechaFactura_Visible = -1;
         edtFacturaNo_Visible = -1;
         edtPromocionDescripcion_Visible = -1;
         edtFacturaFechaRegistro_Visible = -1;
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
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavTodate_Jsonclick = "";
         edtavTodate_Enabled = 1;
         edtavFromdate_Jsonclick = "";
         edtavFromdate_Enabled = 1;
         Grid_empowerer_Popoversingrid = "Popover_Partidas";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Fixedfilters = "|||||1:En proceso:fa fa-circle FontColorIconWarning FontColorIconSmall ConditionalFormattingFilterIcon,2:Aprobada:fa fa-circle FontColorIconSuccess FontColorIconSmall ConditionalFormattingFilterIcon,3:Rechazada:fa fa-circle FontColorIconDanger FontColorIconSmall ConditionalFormattingFilterIcon,4:Cancelada:fa fa-circle FontColorIconInfo FontColorIconSmall ConditionalFormattingFilterIcon|||";
         Ddo_grid_Datalistproc = "WPFacturasPromoPartGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|||||Dynamic|";
         Ddo_grid_Includedatalist = "|T|T|||||T|";
         Ddo_grid_Filterisrange = "P|||P|||||";
         Ddo_grid_Filtertype = "Date|Character|Character|Date||||Character|";
         Ddo_grid_Includefilter = "T|T|T|T||||T|";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|||||";
         Ddo_grid_Columnssortvalues = "2|3|1|4|||||";
         Ddo_grid_Columnids = "3:FacturaFechaRegistro|4:PromocionDescripcion|5:FacturaNo|6:FacturaFechaFactura|7:Partidas|10:Estatus|12:Descripcion|15:UsuarioNombreCompleto|19:DistribuidorDescripcion";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV71PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV69Estatus","fld":"vESTATUS","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"sPrefix"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV235Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV74TFEstatus","fld":"vTFESTATUS"},{"av":"AV75TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV83UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV90RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcion_Visible","ctrl":"vDISTRIBUIDORDESCRIPCION","prop":"Visible"},{"av":"AV64GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV65GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV66GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV180ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12302","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV71PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV235Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV74TFEstatus","fld":"vTFESTATUS"},{"av":"AV75TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV83UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV69Estatus","fld":"vESTATUS","hsh":true},{"av":"AV90RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"sPrefix"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13302","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV71PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV235Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV74TFEstatus","fld":"vTFESTATUS"},{"av":"AV75TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV83UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV69Estatus","fld":"vESTATUS","hsh":true},{"av":"AV90RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"sPrefix"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14302","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV71PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV235Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV74TFEstatus","fld":"vTFESTATUS"},{"av":"AV75TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV83UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV69Estatus","fld":"vESTATUS","hsh":true},{"av":"AV90RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"sPrefix"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Selectedcolumnfixedfilter","ctrl":"DDO_GRID","prop":"SelectedColumnFixedFilter"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV74TFEstatus","fld":"vTFESTATUS"},{"av":"AV75TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E21302","iparms":[{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS","hsh":true},{"av":"A20MotivoRechazoDescripcion","fld":"MOTIVORECHAZODESCRIPCION"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV69Estatus","fld":"vESTATUS","hsh":true},{"av":"AV90RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV73Descripcion","fld":"vDESCRIPCION"},{"av":"AV87Partidas","fld":"vPARTIDAS"},{"av":"AV90RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV77UserAction4","fld":"vUSERACTION4"},{"av":"edtavUseraction4_Tooltiptext","ctrl":"vUSERACTION4","prop":"Tooltiptext"},{"av":"AV78UserAction8","fld":"vUSERACTION8"},{"av":"edtavUseraction8_Link","ctrl":"vUSERACTION8","prop":"Link"},{"av":"AV76UserAction2","fld":"vUSERACTION2"},{"av":"AV88PartidasWithTags","fld":"vPARTIDASWITHTAGS"},{"av":"AV70EstatusWithTags","fld":"vESTATUSWITHTAGS"},{"av":"AV89DistribuidorDescripcion","fld":"vDISTRIBUIDORDESCRIPCION"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E15302","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV71PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV235Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV74TFEstatus","fld":"vTFESTATUS"},{"av":"AV75TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV83UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV69Estatus","fld":"vESTATUS","hsh":true},{"av":"AV90RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"sPrefix"},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcion_Visible","ctrl":"vDISTRIBUIDORDESCRIPCION","prop":"Visible"},{"av":"AV64GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV65GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV66GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV180ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11302","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV71PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV235Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV74TFEstatus","fld":"vTFESTATUS"},{"av":"AV75TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV83UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV69Estatus","fld":"vESTATUS","hsh":true},{"av":"AV90RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"sPrefix"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV75TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"Ddo_grid_Selectedfixedfilter","ctrl":"DDO_GRID","prop":"SelectedFixedFilter"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcion_Visible","ctrl":"vDISTRIBUIDORDESCRIPCION","prop":"Visible"},{"av":"AV64GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV65GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV66GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV180ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOUSERACTION1'","""{"handler":"E16302","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV71PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV235Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV74TFEstatus","fld":"vTFESTATUS"},{"av":"AV75TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV83UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV69Estatus","fld":"vESTATUS","hsh":true},{"av":"AV90RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"sPrefix"}]""");
         setEventMetadata("'DOUSERACTION1'",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcion_Visible","ctrl":"vDISTRIBUIDORDESCRIPCION","prop":"Visible"},{"av":"AV64GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV65GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV66GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV180ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOEXCELDETALLADO'","""{"handler":"E17302","iparms":[{"av":"AV83UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV71PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"}]}""");
         setEventMetadata("'DOUSERACTION99'","""{"handler":"E18302","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV71PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV235Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV74TFEstatus","fld":"vTFESTATUS"},{"av":"AV75TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV83UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV69Estatus","fld":"vESTATUS","hsh":true},{"av":"AV90RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"sPrefix"},{"av":"AV180ListaUsuarios","fld":"vLISTAUSUARIOS"}]""");
         setEventMetadata("'DOUSERACTION99'",""","oparms":[{"ctrl":"UTCHARTDOUGHNUT"},{"ctrl":"UTCHARTCOLUMNLINE"},{"av":"AV180ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcion_Visible","ctrl":"vDISTRIBUIDORDESCRIPCION","prop":"Visible"},{"av":"AV64GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV65GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV66GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VPARTIDAS.CLICK","""{"handler":"E22302","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("VPARTIDAS.CLICK",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VUSERACTION4.CLICK","""{"handler":"E23302","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV91Blob","fld":"vBLOB"},{"av":"AV93FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"A75FacturaPDF","fld":"FACTURAPDF"}]""");
         setEventMetadata("VUSERACTION4.CLICK",""","oparms":[{"av":"AV93FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"Innwewindow_Target","ctrl":"INNWEWINDOW","prop":"Target"},{"av":"AV91Blob","fld":"vBLOB"}]}""");
         setEventMetadata("VUSERACTION2.CLICK","""{"handler":"E24302","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV71PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV235Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV74TFEstatus","fld":"vTFESTATUS"},{"av":"AV75TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV83UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV69Estatus","fld":"vESTATUS","hsh":true},{"av":"AV90RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"sPrefix"},{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS","hsh":true},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("VUSERACTION2.CLICK",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcion_Visible","ctrl":"vDISTRIBUIDORDESCRIPCION","prop":"Visible"},{"av":"AV64GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV65GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV66GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV180ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VALIDV_FROMDATE","""{"handler":"Validv_Fromdate","iparms":[]}""");
         setEventMetadata("VALIDV_TODATE","""{"handler":"Validv_Todate","iparms":[]}""");
         setEventMetadata("VALID_USUARIOID","""{"handler":"Valid_Usuarioid","iparms":[]}""");
         setEventMetadata("VALID_MOTIVORECHAZOID","""{"handler":"Valid_Motivorechazoid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Distribuidordescripcion","iparms":[]}""");
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
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV124FromDate = DateTime.MinValue;
         AV125ToDate = DateTime.MinValue;
         AV15FilterFullText = "";
         AV18ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV235Pgmname = "";
         AV41TFFacturaFechaRegistro = DateTime.MinValue;
         AV42TFFacturaFechaRegistro_To = DateTime.MinValue;
         AV28TFPromocionDescripcion = "";
         AV29TFPromocionDescripcion_Sel = "";
         AV34TFFacturaNo = "";
         AV35TFFacturaNo_Sel = "";
         AV36TFFacturaFechaFactura = DateTime.MinValue;
         AV37TFFacturaFechaFactura_To = DateTime.MinValue;
         AV74TFEstatus = "";
         AV48TFUsuarioNombreCompleto = "";
         AV49TFUsuarioNombreCompleto_Sel = "";
         AV69Estatus = "";
         A11DistribuidorDescripcion = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV225Elements = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         AV226Parameters = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter>( context, "Parameter", "GeneXus.Reporting");
         AV227ItemClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData(context);
         AV228ItemDoubleClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData(context);
         AV229DragAndDropData = new GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData(context);
         AV230FilterChangedData = new GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData(context);
         AV231ItemExpandData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData(context);
         AV232ItemCollapseData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData(context);
         AV21ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV66GridAppliedFilters = "";
         AV62DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV222DDO_FacturaFechaRegistroAuxDateTo = DateTime.MinValue;
         AV224DDO_FacturaFechaFacturaAuxDateTo = DateTime.MinValue;
         AV10GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV180ListaUsuarios = new GxSimpleCollection<int>();
         AV91Blob = "";
         A75FacturaPDF = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         AV221DDO_FacturaFechaRegistroAuxDate = DateTime.MinValue;
         AV223DDO_FacturaFechaFacturaAuxDate = DateTime.MinValue;
         Popover_partidas_Gridinternalname = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_grid_Selectedfixedfilter = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnuseraction99_Jsonclick = "";
         ucUtchartdoughnut = new GXUserControl();
         ucUtchartcolumnline = new GXUserControl();
         bttBtnuseraction1_Jsonclick = "";
         bttBtnexceldetallado_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucInnwewindow = new GXUserControl();
         ucPopover_partidas = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV45DDO_FacturaFechaRegistroAuxDateText = "";
         ucTffacturafecharegistro_rangepicker = new GXUserControl();
         AV40DDO_FacturaFechaFacturaAuxDateText = "";
         ucTffacturafechafactura_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV77UserAction4 = "";
         AV249Useraction4_GXI = "";
         AV78UserAction8 = "";
         A72FacturaFechaRegistro = DateTime.MinValue;
         A42PromocionDescripcion = "";
         A71FacturaNo = "";
         A73FacturaFechaFactura = DateTime.MinValue;
         AV88PartidasWithTags = "";
         AV87Partidas = "";
         AV76UserAction2 = "";
         AV70EstatusWithTags = "";
         AV73Descripcion = "";
         A80FacturaEstatus = "";
         A52UsuarioNombreCompleto = "";
         A20MotivoRechazoDescripcion = "";
         AV89DistribuidorDescripcion = "";
         GXDecQS = "";
         lV236Wpfacturaspromopartds_1_filterfulltext = "";
         lV239Wpfacturaspromopartds_4_tfpromociondescripcion = "";
         lV241Wpfacturaspromopartds_6_tffacturano = "";
         lV247Wpfacturaspromopartds_12_tfusuarionombrecompleto = "";
         AV236Wpfacturaspromopartds_1_filterfulltext = "";
         AV237Wpfacturaspromopartds_2_tffacturafecharegistro = DateTime.MinValue;
         AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to = DateTime.MinValue;
         AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel = "";
         AV239Wpfacturaspromopartds_4_tfpromociondescripcion = "";
         AV242Wpfacturaspromopartds_7_tffacturano_sel = "";
         AV241Wpfacturaspromopartds_6_tffacturano = "";
         AV243Wpfacturaspromopartds_8_tffacturafechafactura = DateTime.MinValue;
         AV244Wpfacturaspromopartds_9_tffacturafechafactura_to = DateTime.MinValue;
         AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel = "";
         AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto = "";
         H00302_A41PromocionID = new int[1] ;
         H00302_A93FacturaCompleta = new bool[] {false} ;
         H00302_A19MotivoRechazoID = new int[1] ;
         H00302_A20MotivoRechazoDescripcion = new string[] {""} ;
         H00302_A21MotivoRechazoActivo = new bool[] {false} ;
         H00302_A29UsuarioID = new int[1] ;
         H00302_A80FacturaEstatus = new string[] {""} ;
         H00302_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         H00302_A71FacturaNo = new string[] {""} ;
         H00302_A42PromocionDescripcion = new string[] {""} ;
         H00302_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         H00302_A69FacturaID = new int[1] ;
         H00302_A51UsuarioApellido = new string[] {""} ;
         H00302_A30UsuarioNombre = new string[] {""} ;
         AV245Wpfacturaspromopartds_10_tfestatus = "";
         H00303_AGRID_nRecordCount = new long[1] ;
         AV79UsuarioJSON = "";
         AV80WebSession = context.GetSession();
         AV81SDTUsuario = new SdtSDTUsuario(context);
         AV82UsuarioRol = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV20Session = context.GetSession();
         AV16ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV22ManageFiltersXml = "";
         AV85SDTPromocion = new SdtSDTPromocion(context);
         AV86PromocionJSON = "";
         AV116ListaUsuarioID = new GxSimpleCollection<int>();
         AV105ExcelFilename = "";
         AV103ErrorMessage = "";
         AV17UserCustomValue = "";
         AV19ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV11GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV92FileURL = "";
         H00304_A81DistribuidoresUsuarioID = new int[1] ;
         H00304_A10DistribuidorID = new int[1] ;
         H00304_A29UsuarioID = new int[1] ;
         H00304_A11DistribuidorDescripcion = new string[] {""} ;
         H00305_A69FacturaID = new int[1] ;
         H00305_A40000FacturaPDF_GXI = new string[] {""} ;
         H00305_A75FacturaPDF = new string[] {""} ;
         A40000FacturaPDF_GXI = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV71PromocionID = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpfacturaspromopart__default(),
            new Object[][] {
                new Object[] {
               H00302_A41PromocionID, H00302_A93FacturaCompleta, H00302_A19MotivoRechazoID, H00302_A20MotivoRechazoDescripcion, H00302_A21MotivoRechazoActivo, H00302_A29UsuarioID, H00302_A80FacturaEstatus, H00302_A73FacturaFechaFactura, H00302_A71FacturaNo, H00302_A42PromocionDescripcion,
               H00302_A72FacturaFechaRegistro, H00302_A69FacturaID, H00302_A51UsuarioApellido, H00302_A30UsuarioNombre
               }
               , new Object[] {
               H00303_AGRID_nRecordCount
               }
               , new Object[] {
               H00304_A81DistribuidoresUsuarioID, H00304_A10DistribuidorID, H00304_A29UsuarioID, H00304_A11DistribuidorDescripcion
               }
               , new Object[] {
               H00305_A69FacturaID, H00305_A40000FacturaPDF_GXI, H00305_A75FacturaPDF
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV235Pgmname = "WPFacturasPromoPart";
         /* GeneXus formulas. */
         AV235Pgmname = "WPFacturasPromoPart";
         edtavUseraction8_Enabled = 0;
         edtavPartidaswithtags_Enabled = 0;
         edtavPartidas_Enabled = 0;
         edtavUseraction2_Enabled = 0;
         edtavEstatuswithtags_Enabled = 0;
         edtavEstatus_Enabled = 0;
         edtavDescripcion_Enabled = 0;
         edtavDistribuidordescripcion_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV12OrderedBy ;
      private short AV23ManageFiltersExecutionStep ;
      private short AV75TFEstatusOperator ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV246Wpfacturaspromopartds_11_tfestatusoperator ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV71PromocionID ;
      private int wcpOAV71PromocionID ;
      private int edtavUseraction2_Visible ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_61 ;
      private int nGXsfl_61_idx=1 ;
      private int AV83UsuarioID ;
      private int AV90RegUsuarioID ;
      private int edtavUseraction8_Enabled ;
      private int edtavPartidaswithtags_Enabled ;
      private int edtavPartidas_Enabled ;
      private int edtavUseraction2_Enabled ;
      private int edtavEstatuswithtags_Enabled ;
      private int edtavEstatus_Enabled ;
      private int edtavDescripcion_Enabled ;
      private int edtavDistribuidordescripcion_Enabled ;
      private int AV93FacturaID ;
      private int Gridpaginationbar_Pagestoshow ;
      private int Popover_partidas_Popoverwidth ;
      private int edtavFromdate_Enabled ;
      private int edtavTodate_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int A69FacturaID ;
      private int A29UsuarioID ;
      private int A19MotivoRechazoID ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV180ListaUsuarios_Count ;
      private int A41PromocionID ;
      private int edtFacturaID_Enabled ;
      private int edtFacturaFechaRegistro_Enabled ;
      private int edtPromocionDescripcion_Enabled ;
      private int edtFacturaNo_Enabled ;
      private int edtFacturaFechaFactura_Enabled ;
      private int edtUsuarioID_Enabled ;
      private int edtUsuarioNombreCompleto_Enabled ;
      private int edtMotivoRechazoDescripcion_Enabled ;
      private int edtMotivoRechazoID_Enabled ;
      private int edtFacturaFechaRegistro_Visible ;
      private int edtPromocionDescripcion_Visible ;
      private int edtFacturaNo_Visible ;
      private int edtFacturaFechaFactura_Visible ;
      private int edtavPartidaswithtags_Visible ;
      private int edtavEstatuswithtags_Visible ;
      private int edtavDescripcion_Visible ;
      private int edtUsuarioNombreCompleto_Visible ;
      private int edtavDistribuidordescripcion_Visible ;
      private int AV63PageToGo ;
      private int AV250GXV1 ;
      private int A10DistribuidorID ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV64GridCurrentPage ;
      private long AV65GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Selectedcolumnfixedfilter ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_61_idx="0001" ;
      private string edtavUseraction2_Internalname ;
      private string AV235Pgmname ;
      private string AV34TFFacturaNo ;
      private string AV35TFFacturaNo_Sel ;
      private string AV74TFEstatus ;
      private string AV69Estatus ;
      private string edtavUseraction8_Internalname ;
      private string edtavPartidaswithtags_Internalname ;
      private string edtavPartidas_Internalname ;
      private string edtavEstatuswithtags_Internalname ;
      private string edtavEstatus_Internalname ;
      private string edtavDescripcion_Internalname ;
      private string edtavDistribuidordescripcion_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
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
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Fixedfilters ;
      private string Ddo_grid_Selectedfixedfilter ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Popoversingrid ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtavFromdate_Internalname ;
      private string TempTags ;
      private string edtavFromdate_Jsonclick ;
      private string edtavTodate_Internalname ;
      private string edtavTodate_Jsonclick ;
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
      private string bttBtnuseraction1_Internalname ;
      private string bttBtnuseraction1_Jsonclick ;
      private string bttBtnexceldetallado_Internalname ;
      private string bttBtnexceldetallado_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
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
      private string Ddo_gridcolumnsselector_Internalname ;
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
      private string AV78UserAction8 ;
      private string edtFacturaFechaRegistro_Internalname ;
      private string edtPromocionDescripcion_Internalname ;
      private string A71FacturaNo ;
      private string edtFacturaNo_Internalname ;
      private string edtFacturaFechaFactura_Internalname ;
      private string AV87Partidas ;
      private string AV76UserAction2 ;
      private string cmbFacturaEstatus_Internalname ;
      private string A80FacturaEstatus ;
      private string edtUsuarioID_Internalname ;
      private string edtUsuarioNombreCompleto_Internalname ;
      private string chkMotivoRechazoActivo_Internalname ;
      private string edtMotivoRechazoDescripcion_Internalname ;
      private string edtMotivoRechazoID_Internalname ;
      private string GXDecQS ;
      private string lV241Wpfacturaspromopartds_6_tffacturano ;
      private string AV242Wpfacturaspromopartds_7_tffacturano_sel ;
      private string AV241Wpfacturaspromopartds_6_tffacturano ;
      private string AV245Wpfacturaspromopartds_10_tfestatus ;
      private string AV82UsuarioRol ;
      private string edtavUseraction4_gximage ;
      private string edtavUseraction4_Tooltiptext ;
      private string edtavUseraction8_Link ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string sCtrlAV71PromocionID ;
      private string sGXsfl_61_fel_idx="0001" ;
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
      private string edtavDistribuidordescripcion_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV124FromDate ;
      private DateTime AV125ToDate ;
      private DateTime AV41TFFacturaFechaRegistro ;
      private DateTime AV42TFFacturaFechaRegistro_To ;
      private DateTime AV36TFFacturaFechaFactura ;
      private DateTime AV37TFFacturaFechaFactura_To ;
      private DateTime AV222DDO_FacturaFechaRegistroAuxDateTo ;
      private DateTime AV224DDO_FacturaFechaFacturaAuxDateTo ;
      private DateTime AV221DDO_FacturaFechaRegistroAuxDate ;
      private DateTime AV223DDO_FacturaFechaFacturaAuxDate ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A73FacturaFechaFactura ;
      private DateTime AV237Wpfacturaspromopartds_2_tffacturafecharegistro ;
      private DateTime AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to ;
      private DateTime AV243Wpfacturaspromopartds_8_tffacturafechafactura ;
      private DateTime AV244Wpfacturaspromopartds_9_tffacturafechafactura_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_61_Refreshing=false ;
      private bool AV13OrderedDsc ;
      private bool Utchartdoughnut_Showvalues ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Popover_partidas_Isgriditem ;
      private bool Popover_partidas_Keepopened ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool A21MotivoRechazoActivo ;
      private bool gxdyncontrolsrefreshing ;
      private bool A93FacturaCompleta ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV77UserAction4_IsBlob ;
      private string AV79UsuarioJSON ;
      private string AV16ColumnsSelectorXML ;
      private string AV22ManageFiltersXml ;
      private string AV17UserCustomValue ;
      private string AV15FilterFullText ;
      private string AV28TFPromocionDescripcion ;
      private string AV29TFPromocionDescripcion_Sel ;
      private string AV48TFUsuarioNombreCompleto ;
      private string AV49TFUsuarioNombreCompleto_Sel ;
      private string A11DistribuidorDescripcion ;
      private string AV66GridAppliedFilters ;
      private string AV45DDO_FacturaFechaRegistroAuxDateText ;
      private string AV40DDO_FacturaFechaFacturaAuxDateText ;
      private string AV249Useraction4_GXI ;
      private string A42PromocionDescripcion ;
      private string AV88PartidasWithTags ;
      private string AV70EstatusWithTags ;
      private string AV73Descripcion ;
      private string A52UsuarioNombreCompleto ;
      private string A20MotivoRechazoDescripcion ;
      private string AV89DistribuidorDescripcion ;
      private string lV236Wpfacturaspromopartds_1_filterfulltext ;
      private string lV239Wpfacturaspromopartds_4_tfpromociondescripcion ;
      private string lV247Wpfacturaspromopartds_12_tfusuarionombrecompleto ;
      private string AV236Wpfacturaspromopartds_1_filterfulltext ;
      private string AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel ;
      private string AV239Wpfacturaspromopartds_4_tfpromociondescripcion ;
      private string AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel ;
      private string AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto ;
      private string AV86PromocionJSON ;
      private string AV105ExcelFilename ;
      private string AV103ErrorMessage ;
      private string AV92FileURL ;
      private string A40000FacturaPDF_GXI ;
      private string AV77UserAction4 ;
      private string A75FacturaPDF ;
      private string AV91Blob ;
      private IGxSession AV80WebSession ;
      private IGxSession AV20Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucUtchartdoughnut ;
      private GXUserControl ucUtchartcolumnline ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucInnwewindow ;
      private GXUserControl ucPopover_partidas ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTffacturafecharegistro_rangepicker ;
      private GXUserControl ucTffacturafechafactura_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbFacturaEstatus ;
      private GXCheckbox chkMotivoRechazoActivo ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV18ColumnsSelector ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV225Elements ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter> AV226Parameters ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData AV227ItemClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData AV228ItemDoubleClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData AV229DragAndDropData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData AV230FilterChangedData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData AV231ItemExpandData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData AV232ItemCollapseData ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV21ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV62DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV10GridState ;
      private GxSimpleCollection<int> AV180ListaUsuarios ;
      private IDataStoreProvider pr_default ;
      private int[] H00302_A41PromocionID ;
      private bool[] H00302_A93FacturaCompleta ;
      private int[] H00302_A19MotivoRechazoID ;
      private string[] H00302_A20MotivoRechazoDescripcion ;
      private bool[] H00302_A21MotivoRechazoActivo ;
      private int[] H00302_A29UsuarioID ;
      private string[] H00302_A80FacturaEstatus ;
      private DateTime[] H00302_A73FacturaFechaFactura ;
      private string[] H00302_A71FacturaNo ;
      private string[] H00302_A42PromocionDescripcion ;
      private DateTime[] H00302_A72FacturaFechaRegistro ;
      private int[] H00302_A69FacturaID ;
      private string[] H00302_A51UsuarioApellido ;
      private string[] H00302_A30UsuarioNombre ;
      private long[] H00303_AGRID_nRecordCount ;
      private SdtSDTUsuario AV81SDTUsuario ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private SdtSDTPromocion AV85SDTPromocion ;
      private GxSimpleCollection<int> AV116ListaUsuarioID ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV19ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private int[] H00304_A81DistribuidoresUsuarioID ;
      private int[] H00304_A10DistribuidorID ;
      private int[] H00304_A29UsuarioID ;
      private string[] H00304_A11DistribuidorDescripcion ;
      private int[] H00305_A69FacturaID ;
      private string[] H00305_A40000FacturaPDF_GXI ;
      private string[] H00305_A75FacturaPDF ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpfacturaspromopart__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00302( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV180ListaUsuarios ,
                                             string AV236Wpfacturaspromopartds_1_filterfulltext ,
                                             DateTime AV237Wpfacturaspromopartds_2_tffacturafecharegistro ,
                                             DateTime AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to ,
                                             string AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel ,
                                             string AV239Wpfacturaspromopartds_4_tfpromociondescripcion ,
                                             string AV242Wpfacturaspromopartds_7_tffacturano_sel ,
                                             string AV241Wpfacturaspromopartds_6_tffacturano ,
                                             DateTime AV243Wpfacturaspromopartds_8_tffacturafechafactura ,
                                             DateTime AV244Wpfacturaspromopartds_9_tffacturafechafactura_to ,
                                             short AV246Wpfacturaspromopartds_11_tfestatusoperator ,
                                             string AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel ,
                                             string AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto ,
                                             DateTime AV124FromDate ,
                                             DateTime AV125ToDate ,
                                             int AV180ListaUsuarios_Count ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             bool A93FacturaCompleta ,
                                             int AV71PromocionID ,
                                             int A41PromocionID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[18];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.`PromocionID`, T1.`FacturaCompleta`, T1.`MotivoRechazoID`, T3.`MotivoRechazoDescripcion`, T3.`MotivoRechazoActivo`, T1.`UsuarioID`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaNo`, T2.`PromocionDescripcion`, T1.`FacturaFechaRegistro`, T1.`FacturaID`, T4.`UsuarioApellido`, T4.`UsuarioNombre`";
         sFromString = " FROM (((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `MotivoRechazo` T3 ON T3.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.`PromocionID` = @AV71PromocionID)");
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV236Wpfacturaspromopartds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.`PromocionDescripcion` like CONCAT('%', @lV236Wpfacturaspromopartds_1_filterfulltext)) or ( T1.`FacturaNo` like CONCAT('%', @lV236Wpfacturaspromopartds_1_filterfulltext)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like CONCAT('%', @lV236Wpfacturaspromopartds_1_filterfulltext)))");
         }
         else
         {
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV237Wpfacturaspromopartds_2_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV237Wpfacturaspromopartds_2_tffacturafecharegistro)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV239Wpfacturaspromopartds_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV239Wpfacturaspromopartds_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( StringUtil.StrCmp(AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV242Wpfacturaspromopartds_7_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV241Wpfacturaspromopartds_6_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV241Wpfacturaspromopartds_6_tffacturano)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV242Wpfacturaspromopartds_7_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV242Wpfacturaspromopartds_7_tffacturano_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV242Wpfacturaspromopartds_7_tffacturano_sel)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( StringUtil.StrCmp(AV242Wpfacturaspromopartds_7_tffacturano_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV243Wpfacturaspromopartds_8_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV243Wpfacturaspromopartds_8_tffacturafechafactura)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV244Wpfacturaspromopartds_9_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV244Wpfacturaspromopartds_9_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV246Wpfacturaspromopartds_11_tfestatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV246Wpfacturaspromopartds_11_tfestatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV246Wpfacturaspromopartds_11_tfestatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV246Wpfacturaspromopartds_11_tfestatusoperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like @lV247Wpfacturaspromopartds_12_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) = @AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( StringUtil.StrCmp(AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T4.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T4.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV124FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV124FromDate)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV125ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV125ToDate)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV180ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV180ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         }
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`FacturaNo`";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`FacturaNo` DESC";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`FacturaFechaRegistro`";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`FacturaFechaRegistro` DESC";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T2.`PromocionDescripcion`";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.`PromocionDescripcion` DESC";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`FacturaFechaFactura`";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`FacturaFechaFactura` DESC";
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

      protected Object[] conditional_H00303( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV180ListaUsuarios ,
                                             string AV236Wpfacturaspromopartds_1_filterfulltext ,
                                             DateTime AV237Wpfacturaspromopartds_2_tffacturafecharegistro ,
                                             DateTime AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to ,
                                             string AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel ,
                                             string AV239Wpfacturaspromopartds_4_tfpromociondescripcion ,
                                             string AV242Wpfacturaspromopartds_7_tffacturano_sel ,
                                             string AV241Wpfacturaspromopartds_6_tffacturano ,
                                             DateTime AV243Wpfacturaspromopartds_8_tffacturafechafactura ,
                                             DateTime AV244Wpfacturaspromopartds_9_tffacturafechafactura_to ,
                                             short AV246Wpfacturaspromopartds_11_tfestatusoperator ,
                                             string AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel ,
                                             string AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto ,
                                             DateTime AV124FromDate ,
                                             DateTime AV125ToDate ,
                                             int AV180ListaUsuarios_Count ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             bool A93FacturaCompleta ,
                                             int AV71PromocionID ,
                                             int A41PromocionID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[16];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `MotivoRechazo` T3 ON T3.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`PromocionID` = @AV71PromocionID)");
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV236Wpfacturaspromopartds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.`PromocionDescripcion` like CONCAT('%', @lV236Wpfacturaspromopartds_1_filterfulltext)) or ( T1.`FacturaNo` like CONCAT('%', @lV236Wpfacturaspromopartds_1_filterfulltext)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like CONCAT('%', @lV236Wpfacturaspromopartds_1_filterfulltext)))");
         }
         else
         {
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV237Wpfacturaspromopartds_2_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV237Wpfacturaspromopartds_2_tffacturafecharegistro)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV239Wpfacturaspromopartds_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV239Wpfacturaspromopartds_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( StringUtil.StrCmp(AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV242Wpfacturaspromopartds_7_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV241Wpfacturaspromopartds_6_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV241Wpfacturaspromopartds_6_tffacturano)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV242Wpfacturaspromopartds_7_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV242Wpfacturaspromopartds_7_tffacturano_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV242Wpfacturaspromopartds_7_tffacturano_sel)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( StringUtil.StrCmp(AV242Wpfacturaspromopartds_7_tffacturano_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV243Wpfacturaspromopartds_8_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV243Wpfacturaspromopartds_8_tffacturafechafactura)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV244Wpfacturaspromopartds_9_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV244Wpfacturaspromopartds_9_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV246Wpfacturaspromopartds_11_tfestatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV246Wpfacturaspromopartds_11_tfestatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV246Wpfacturaspromopartds_11_tfestatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV246Wpfacturaspromopartds_11_tfestatusoperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV247Wpfacturaspromopartds_12_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like @lV247Wpfacturaspromopartds_12_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) = @AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( StringUtil.StrCmp(AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T4.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T4.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV124FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV124FromDate)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV125ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV125ToDate)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV180ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV180ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
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

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00302(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (bool)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
               case 1 :
                     return conditional_H00303(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (bool)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00304;
          prmH00304 = new Object[] {
          new ParDef("@AV90RegUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH00305;
          prmH00305 = new Object[] {
          new ParDef("@AV93FacturaID",GXType.Int32,9,0)
          };
          Object[] prmH00302;
          prmH00302 = new Object[] {
          new ParDef("@AV71PromocionID",GXType.Int32,9,0) ,
          new ParDef("@lV236Wpfacturaspromopartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV236Wpfacturaspromopartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV236Wpfacturaspromopartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV237Wpfacturaspromopartds_2_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV239Wpfacturaspromopartds_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV241Wpfacturaspromopartds_6_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV242Wpfacturaspromopartds_7_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@AV243Wpfacturaspromopartds_8_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV244Wpfacturaspromopartds_9_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@lV247Wpfacturaspromopartds_12_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@AV124FromDate",GXType.Date,8,0) ,
          new ParDef("@AV125ToDate",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00303;
          prmH00303 = new Object[] {
          new ParDef("@AV71PromocionID",GXType.Int32,9,0) ,
          new ParDef("@lV236Wpfacturaspromopartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV236Wpfacturaspromopartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV236Wpfacturaspromopartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV237Wpfacturaspromopartds_2_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV238Wpfacturaspromopartds_3_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV239Wpfacturaspromopartds_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV240Wpfacturaspromopartds_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV241Wpfacturaspromopartds_6_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV242Wpfacturaspromopartds_7_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@AV243Wpfacturaspromopartds_8_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV244Wpfacturaspromopartds_9_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@lV247Wpfacturaspromopartds_12_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV248Wpfacturaspromopartds_13_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@AV124FromDate",GXType.Date,8,0) ,
          new ParDef("@AV125ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00302", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00302,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00303", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00303,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00304", "SELECT T1.`DistribuidoresUsuarioID`, T1.`DistribuidorID`, T1.`UsuarioID`, T2.`DistribuidorDescripcion` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Distribuidor` T2 ON T2.`DistribuidorID` = T1.`DistribuidorID`) WHERE T1.`UsuarioID` = @AV90RegUsuarioID ORDER BY T1.`UsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00304,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00305", "SELECT `FacturaID`, `FacturaPDF_GXI`, `FacturaPDF` FROM `Factura` WHERE `FacturaID` = @AV93FacturaID ORDER BY `FacturaID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00305,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((int[]) buf[11])[0] = rslt.getInt(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 50);
                ((string[]) buf[13])[0] = rslt.getString(14, 50);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
       }
    }

 }

}
