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
   public class wpusuariodetallefacturawc : GXWebComponent
   {
      public wpusuariodetallefacturawc( )
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

      public wpusuariodetallefacturawc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_UsuarioID )
      {
         this.AV7UsuarioID = aP0_UsuarioID;
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
         cmbUsuarioZona = new GXCombobox();
         cmbUsuarioGenero = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "UsuarioID");
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
                  AV7UsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "UsuarioID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV7UsuarioID", StringUtil.LTrimStr( (decimal)(AV7UsuarioID), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV7UsuarioID});
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
                  gxfirstwebparm = GetFirstPar( "UsuarioID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "UsuarioID");
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
         nRC_GXsfl_29 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_29"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_29_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_29_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_29_idx = GetPar( "sGXsfl_29_idx");
         sPrefix = GetPar( "sPrefix");
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
         AV15FilterFullText = GetPar( "FilterFullText");
         AV7UsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "UsuarioID"), "."), 18, MidpointRounding.ToEven));
         AV19ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV58Pgmname = GetPar( "Pgmname");
         AV28TFFacturaID = (int)(Math.Round(NumberUtil.Val( GetPar( "TFFacturaID"), "."), 18, MidpointRounding.ToEven));
         AV29TFFacturaID_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFFacturaID_To"), "."), 18, MidpointRounding.ToEven));
         AV30TFFacturaFechaRegistro = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaRegistro"));
         AV31TFFacturaFechaRegistro_To = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaRegistro_To"));
         AV35TFPromocionDescripcion = GetPar( "TFPromocionDescripcion");
         AV36TFPromocionDescripcion_Sel = GetPar( "TFPromocionDescripcion_Sel");
         AV37TFFacturaNo = GetPar( "TFFacturaNo");
         AV38TFFacturaNo_Sel = GetPar( "TFFacturaNo_Sel");
         AV39TFFacturaFechaFactura = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaFactura"));
         AV40TFFacturaFechaFactura_To = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaFactura_To"));
         AV27Estatus = GetPar( "Estatus");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV7UsuarioID, AV19ManageFiltersExecutionStep, AV58Pgmname, AV28TFFacturaID, AV29TFFacturaID_To, AV30TFFacturaFechaRegistro, AV31TFFacturaFechaRegistro_To, AV35TFPromocionDescripcion, AV36TFPromocionDescripcion_Sel, AV37TFFacturaNo, AV38TFFacturaNo_Sel, AV39TFFacturaFechaFactura, AV40TFFacturaFechaFactura_To, AV27Estatus, sPrefix) ;
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
            PA332( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV58Pgmname = "WPUsuarioDetalleFacturaWC";
               edtavEstatuswithtags_Enabled = 0;
               AssignProp(sPrefix, false, edtavEstatuswithtags_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEstatuswithtags_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               edtavEstatus_Enabled = 0;
               AssignProp(sPrefix, false, edtavEstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEstatus_Enabled), 5, 0), !bGXsfl_29_Refreshing);
               WS332( ) ;
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
            context.SendWebValue( context.GetMessage( "WPUsuario Detalle Factura WC", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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
            GXEncryptionTmp = "wpusuariodetallefacturawc.aspx"+UrlEncode(StringUtil.LTrimStr(AV7UsuarioID,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpusuariodetallefacturawc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV15FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_29", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_29), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV20DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV20DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_FACTURAFECHAREGISTROAUXDATETO", context.localUtil.DToC( AV33DDO_FacturaFechaRegistroAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_FACTURAFECHAFACTURAAUXDATETO", context.localUtil.DToC( AV42DDO_FacturaFechaFacturaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7UsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28TFFacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29TFFacturaID_To), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAFECHAREGISTRO", context.localUtil.DToC( AV30TFFacturaFechaRegistro, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAFECHAREGISTRO_TO", context.localUtil.DToC( AV31TFFacturaFechaRegistro_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROMOCIONDESCRIPCION", AV35TFPromocionDescripcion);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROMOCIONDESCRIPCION_SEL", AV36TFPromocionDescripcion_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURANO", StringUtil.RTrim( AV37TFFacturaNo));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURANO_SEL", StringUtil.RTrim( AV38TFFacturaNo_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAFECHAFACTURA", context.localUtil.DToC( AV39TFFacturaFechaFactura, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAFECHAFACTURA_TO", context.localUtil.DToC( AV40TFFacturaFechaFactura_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROMOCIONFECHAINICIO", context.localUtil.DToC( A45PromocionFechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROMOCIONFECHAFIN", context.localUtil.DToC( A46PromocionFechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIONOMBRE", StringUtil.RTrim( A30UsuarioNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIOAPELLIDO", StringUtil.RTrim( A51UsuarioApellido));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_FACTURAFECHAREGISTROAUXDATE", context.localUtil.DToC( AV32DDO_FacturaFechaRegistroAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_FACTURAFECHAFACTURAAUXDATE", context.localUtil.DToC( AV41DDO_FacturaFechaFacturaAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm332( )
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
         return "WPUsuarioDetalleFacturaWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WPUsuario Detalle Factura WC", "") ;
      }

      protected void WB330( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpusuariodetallefacturawc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'" + sGXsfl_29_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WPUsuarioDetalleFacturaWC.htm");
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
            StartGridControl29( ) ;
         }
         if ( wbEnd == 29 )
         {
            wbEnd = 0;
            nRC_GXsfl_29 = (int)(nGXsfl_29_idx-1);
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
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV20DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_facturafecharegistroauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'" + sGXsfl_29_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_facturafecharegistroauxdatetext_Internalname, AV34DDO_FacturaFechaRegistroAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV34DDO_FacturaFechaRegistroAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_facturafecharegistroauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPUsuarioDetalleFacturaWC.htm");
            /* User Defined Control */
            ucTffacturafecharegistro_rangepicker.SetProperty("Start Date", AV32DDO_FacturaFechaRegistroAuxDate);
            ucTffacturafecharegistro_rangepicker.SetProperty("End Date", AV33DDO_FacturaFechaRegistroAuxDateTo);
            ucTffacturafecharegistro_rangepicker.Render(context, "wwp.daterangepicker", Tffacturafecharegistro_rangepicker_Internalname, sPrefix+"TFFACTURAFECHAREGISTRO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_facturafechafacturaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'" + sPrefix + "',false,'" + sGXsfl_29_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_facturafechafacturaauxdatetext_Internalname, AV43DDO_FacturaFechaFacturaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV43DDO_FacturaFechaFacturaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_facturafechafacturaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPUsuarioDetalleFacturaWC.htm");
            /* User Defined Control */
            ucTffacturafechafactura_rangepicker.SetProperty("Start Date", AV41DDO_FacturaFechaFacturaAuxDate);
            ucTffacturafechafactura_rangepicker.SetProperty("End Date", AV42DDO_FacturaFechaFacturaAuxDateTo);
            ucTffacturafechafactura_rangepicker.Render(context, "wwp.daterangepicker", Tffacturafechafactura_rangepicker_Internalname, sPrefix+"TFFACTURAFECHAFACTURA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 29 )
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

      protected void START332( )
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
            Form.Meta.addItem("description", context.GetMessage( "WPUsuario Detalle Factura WC", ""), 0) ;
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
               STRUP330( ) ;
            }
         }
      }

      protected void WS332( )
      {
         START332( ) ;
         EVT332( ) ;
      }

      protected void EVT332( )
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
                                 STRUP330( ) ;
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
                                 STRUP330( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11332 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP330( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E12332 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP330( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E13332 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP330( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E14332 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP330( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavFilterfulltext_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP330( ) ;
                              }
                              nGXsfl_29_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
                              SubsflControlProps_292( ) ;
                              A69FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A41PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPromocionID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A72FacturaFechaRegistro = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaRegistro_Internalname), 0));
                              A42PromocionDescripcion = cgiGet( edtPromocionDescripcion_Internalname);
                              A43PromocionBase = cgiGet( edtPromocionBase_Internalname);
                              A44PromocionArte = cgiGet( edtPromocionArte_Internalname);
                              AssignProp(sPrefix, false, edtPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40001PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), !bGXsfl_29_Refreshing);
                              AssignProp(sPrefix, false, edtPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
                              A70PromocionVigencia = cgiGet( edtPromocionVigencia_Internalname);
                              A71FacturaNo = cgiGet( edtFacturaNo_Internalname);
                              A73FacturaFechaFactura = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaFactura_Internalname), 0));
                              AV56EstatusWithTags = cgiGet( edtavEstatuswithtags_Internalname);
                              AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV56EstatusWithTags);
                              AV27Estatus = cgiGet( edtavEstatus_Internalname);
                              AssignAttri(sPrefix, false, edtavEstatus_Internalname, AV27Estatus);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vESTATUS"+"_"+sGXsfl_29_idx, GetSecureSignedToken( sPrefix+sGXsfl_29_idx, StringUtil.RTrim( context.localUtil.Format( AV27Estatus, "")), context));
                              cmbFacturaEstatus.Name = cmbFacturaEstatus_Internalname;
                              cmbFacturaEstatus.CurrentValue = cgiGet( cmbFacturaEstatus_Internalname);
                              A80FacturaEstatus = cgiGet( cmbFacturaEstatus_Internalname);
                              A29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbUsuarioZona.Name = cmbUsuarioZona_Internalname;
                              cmbUsuarioZona.CurrentValue = cgiGet( cmbUsuarioZona_Internalname);
                              A63UsuarioZona = cgiGet( cmbUsuarioZona_Internalname);
                              A2EstadoDescripcion = cgiGet( edtEstadoDescripcion_Internalname);
                              A5CiudadDescripcion = cgiGet( edtCiudadDescripcion_Internalname);
                              A17PaisDescripcion = cgiGet( edtPaisDescripcion_Internalname);
                              A52UsuarioNombreCompleto = cgiGet( edtUsuarioNombreCompleto_Internalname);
                              cmbUsuarioGenero.Name = cmbUsuarioGenero_Internalname;
                              cmbUsuarioGenero.CurrentValue = cgiGet( cmbUsuarioGenero_Internalname);
                              A53UsuarioGenero = cgiGet( cmbUsuarioGenero_Internalname);
                              A75FacturaPDF = cgiGet( edtFacturaPDF_Internalname);
                              AssignProp(sPrefix, false, edtFacturaPDF_Internalname, "Multimedia", (String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)) ? A40000FacturaPDF_GXI : context.convertURL( context.PathToRelativeUrl( A75FacturaPDF))), !bGXsfl_29_Refreshing);
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E15332 ();
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E16332 ();
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E17332 ();
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
                                       STRUP330( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
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

      protected void WE332( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm332( ) ;
            }
         }
      }

      protected void PA332( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpusuariodetallefacturawc.aspx")), "wpusuariodetallefacturawc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpusuariodetallefacturawc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "UsuarioID");
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
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
         SubsflControlProps_292( ) ;
         while ( nGXsfl_29_idx <= nRC_GXsfl_29 )
         {
            sendrow_292( ) ;
            nGXsfl_29_idx = ((subGrid_Islastpage==1)&&(nGXsfl_29_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_29_idx+1);
            sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
            SubsflControlProps_292( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV15FilterFullText ,
                                       int AV7UsuarioID ,
                                       short AV19ManageFiltersExecutionStep ,
                                       string AV58Pgmname ,
                                       int AV28TFFacturaID ,
                                       int AV29TFFacturaID_To ,
                                       DateTime AV30TFFacturaFechaRegistro ,
                                       DateTime AV31TFFacturaFechaRegistro_To ,
                                       string AV35TFPromocionDescripcion ,
                                       string AV36TFPromocionDescripcion_Sel ,
                                       string AV37TFFacturaNo ,
                                       string AV38TFFacturaNo_Sel ,
                                       DateTime AV39TFFacturaFechaFactura ,
                                       DateTime AV40TFFacturaFechaFactura_To ,
                                       string AV27Estatus ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF332( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vESTATUS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV27Estatus, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vESTATUS", StringUtil.RTrim( AV27Estatus));
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
         RF332( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV58Pgmname = "WPUsuarioDetalleFacturaWC";
         edtavEstatuswithtags_Enabled = 0;
         edtavEstatus_Enabled = 0;
      }

      protected void RF332( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 29;
         /* Execute user event: Refresh */
         E16332 ();
         nGXsfl_29_idx = 1;
         sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
         SubsflControlProps_292( ) ;
         bGXsfl_29_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar GridNoBorder WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_292( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV15FilterFullText ,
                                                 AV28TFFacturaID ,
                                                 AV29TFFacturaID_To ,
                                                 AV30TFFacturaFechaRegistro ,
                                                 AV31TFFacturaFechaRegistro_To ,
                                                 AV36TFPromocionDescripcion_Sel ,
                                                 AV35TFPromocionDescripcion ,
                                                 AV38TFFacturaNo_Sel ,
                                                 AV37TFFacturaNo ,
                                                 AV39TFFacturaFechaFactura ,
                                                 AV40TFFacturaFechaFactura_To ,
                                                 A69FacturaID ,
                                                 A42PromocionDescripcion ,
                                                 A71FacturaNo ,
                                                 A72FacturaFechaRegistro ,
                                                 A73FacturaFechaFactura ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A93FacturaCompleta ,
                                                 AV7UsuarioID ,
                                                 A29UsuarioID } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
            lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
            lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
            lV35TFPromocionDescripcion = StringUtil.Concat( StringUtil.RTrim( AV35TFPromocionDescripcion), "%", "");
            lV37TFFacturaNo = StringUtil.PadR( StringUtil.RTrim( AV37TFFacturaNo), 20, "%");
            /* Using cursor H00332 */
            pr_default.execute(0, new Object[] {AV7UsuarioID, lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, AV28TFFacturaID, AV29TFFacturaID_To, AV30TFFacturaFechaRegistro, AV31TFFacturaFechaRegistro_To, lV35TFPromocionDescripcion, AV36TFPromocionDescripcion_Sel, lV37TFFacturaNo, AV38TFFacturaNo_Sel, AV39TFFacturaFechaFactura, AV40TFFacturaFechaFactura_To, GXPagingFrom2, GXPagingTo2});
            nGXsfl_29_idx = 1;
            sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
            SubsflControlProps_292( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A4CiudadID = H00332_A4CiudadID[0];
               n4CiudadID = H00332_n4CiudadID[0];
               A1EstadoID = H00332_A1EstadoID[0];
               A16PaisID = H00332_A16PaisID[0];
               A93FacturaCompleta = H00332_A93FacturaCompleta[0];
               A40000FacturaPDF_GXI = H00332_A40000FacturaPDF_GXI[0];
               A53UsuarioGenero = H00332_A53UsuarioGenero[0];
               A17PaisDescripcion = H00332_A17PaisDescripcion[0];
               A5CiudadDescripcion = H00332_A5CiudadDescripcion[0];
               A2EstadoDescripcion = H00332_A2EstadoDescripcion[0];
               A63UsuarioZona = H00332_A63UsuarioZona[0];
               A29UsuarioID = H00332_A29UsuarioID[0];
               A80FacturaEstatus = H00332_A80FacturaEstatus[0];
               A73FacturaFechaFactura = H00332_A73FacturaFechaFactura[0];
               A71FacturaNo = H00332_A71FacturaNo[0];
               A40001PromocionArte_GXI = H00332_A40001PromocionArte_GXI[0];
               AssignProp(sPrefix, false, edtPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40001PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), !bGXsfl_29_Refreshing);
               AssignProp(sPrefix, false, edtPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
               A43PromocionBase = H00332_A43PromocionBase[0];
               A42PromocionDescripcion = H00332_A42PromocionDescripcion[0];
               A72FacturaFechaRegistro = H00332_A72FacturaFechaRegistro[0];
               A41PromocionID = H00332_A41PromocionID[0];
               A69FacturaID = H00332_A69FacturaID[0];
               A46PromocionFechaFin = H00332_A46PromocionFechaFin[0];
               A45PromocionFechaInicio = H00332_A45PromocionFechaInicio[0];
               A51UsuarioApellido = H00332_A51UsuarioApellido[0];
               A30UsuarioNombre = H00332_A30UsuarioNombre[0];
               A75FacturaPDF = H00332_A75FacturaPDF[0];
               AssignProp(sPrefix, false, edtFacturaPDF_Internalname, "Multimedia", (String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)) ? A40000FacturaPDF_GXI : context.convertURL( context.PathToRelativeUrl( A75FacturaPDF))), !bGXsfl_29_Refreshing);
               A44PromocionArte = H00332_A44PromocionArte[0];
               AssignProp(sPrefix, false, edtPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40001PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), !bGXsfl_29_Refreshing);
               AssignProp(sPrefix, false, edtPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
               A4CiudadID = H00332_A4CiudadID[0];
               n4CiudadID = H00332_n4CiudadID[0];
               A53UsuarioGenero = H00332_A53UsuarioGenero[0];
               A63UsuarioZona = H00332_A63UsuarioZona[0];
               A51UsuarioApellido = H00332_A51UsuarioApellido[0];
               A30UsuarioNombre = H00332_A30UsuarioNombre[0];
               A1EstadoID = H00332_A1EstadoID[0];
               A5CiudadDescripcion = H00332_A5CiudadDescripcion[0];
               A16PaisID = H00332_A16PaisID[0];
               A2EstadoDescripcion = H00332_A2EstadoDescripcion[0];
               A17PaisDescripcion = H00332_A17PaisDescripcion[0];
               A40001PromocionArte_GXI = H00332_A40001PromocionArte_GXI[0];
               AssignProp(sPrefix, false, edtPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40001PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), !bGXsfl_29_Refreshing);
               AssignProp(sPrefix, false, edtPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
               A43PromocionBase = H00332_A43PromocionBase[0];
               A42PromocionDescripcion = H00332_A42PromocionDescripcion[0];
               A46PromocionFechaFin = H00332_A46PromocionFechaFin[0];
               A45PromocionFechaInicio = H00332_A45PromocionFechaInicio[0];
               A44PromocionArte = H00332_A44PromocionArte[0];
               AssignProp(sPrefix, false, edtPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40001PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), !bGXsfl_29_Refreshing);
               AssignProp(sPrefix, false, edtPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
               A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
               A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
               /* Execute user event: Grid.Load */
               E17332 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 29;
            WB330( ) ;
         }
         bGXsfl_29_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes332( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vESTATUS"+"_"+sGXsfl_29_idx, GetSecureSignedToken( sPrefix+sGXsfl_29_idx, StringUtil.RTrim( context.localUtil.Format( AV27Estatus, "")), context));
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV15FilterFullText ,
                                              AV28TFFacturaID ,
                                              AV29TFFacturaID_To ,
                                              AV30TFFacturaFechaRegistro ,
                                              AV31TFFacturaFechaRegistro_To ,
                                              AV36TFPromocionDescripcion_Sel ,
                                              AV35TFPromocionDescripcion ,
                                              AV38TFFacturaNo_Sel ,
                                              AV37TFFacturaNo ,
                                              AV39TFFacturaFechaFactura ,
                                              AV40TFFacturaFechaFactura_To ,
                                              A69FacturaID ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A93FacturaCompleta ,
                                              AV7UsuarioID ,
                                              A29UsuarioID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
         lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
         lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
         lV35TFPromocionDescripcion = StringUtil.Concat( StringUtil.RTrim( AV35TFPromocionDescripcion), "%", "");
         lV37TFFacturaNo = StringUtil.PadR( StringUtil.RTrim( AV37TFFacturaNo), 20, "%");
         /* Using cursor H00333 */
         pr_default.execute(1, new Object[] {AV7UsuarioID, lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, AV28TFFacturaID, AV29TFFacturaID_To, AV30TFFacturaFechaRegistro, AV31TFFacturaFechaRegistro_To, lV35TFPromocionDescripcion, AV36TFPromocionDescripcion_Sel, lV37TFFacturaNo, AV38TFFacturaNo_Sel, AV39TFFacturaFechaFactura, AV40TFFacturaFechaFactura_To});
         GRID_nRecordCount = H00333_AGRID_nRecordCount[0];
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV7UsuarioID, AV19ManageFiltersExecutionStep, AV58Pgmname, AV28TFFacturaID, AV29TFFacturaID_To, AV30TFFacturaFechaRegistro, AV31TFFacturaFechaRegistro_To, AV35TFPromocionDescripcion, AV36TFPromocionDescripcion_Sel, AV37TFFacturaNo, AV38TFFacturaNo_Sel, AV39TFFacturaFechaFactura, AV40TFFacturaFechaFactura_To, AV27Estatus, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV7UsuarioID, AV19ManageFiltersExecutionStep, AV58Pgmname, AV28TFFacturaID, AV29TFFacturaID_To, AV30TFFacturaFechaRegistro, AV31TFFacturaFechaRegistro_To, AV35TFPromocionDescripcion, AV36TFPromocionDescripcion_Sel, AV37TFFacturaNo, AV38TFFacturaNo_Sel, AV39TFFacturaFechaFactura, AV40TFFacturaFechaFactura_To, AV27Estatus, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV7UsuarioID, AV19ManageFiltersExecutionStep, AV58Pgmname, AV28TFFacturaID, AV29TFFacturaID_To, AV30TFFacturaFechaRegistro, AV31TFFacturaFechaRegistro_To, AV35TFPromocionDescripcion, AV36TFPromocionDescripcion_Sel, AV37TFFacturaNo, AV38TFFacturaNo_Sel, AV39TFFacturaFechaFactura, AV40TFFacturaFechaFactura_To, AV27Estatus, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV7UsuarioID, AV19ManageFiltersExecutionStep, AV58Pgmname, AV28TFFacturaID, AV29TFFacturaID_To, AV30TFFacturaFechaRegistro, AV31TFFacturaFechaRegistro_To, AV35TFPromocionDescripcion, AV36TFPromocionDescripcion_Sel, AV37TFFacturaNo, AV38TFFacturaNo_Sel, AV39TFFacturaFechaFactura, AV40TFFacturaFechaFactura_To, AV27Estatus, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV7UsuarioID, AV19ManageFiltersExecutionStep, AV58Pgmname, AV28TFFacturaID, AV29TFFacturaID_To, AV30TFFacturaFechaRegistro, AV31TFFacturaFechaRegistro_To, AV35TFPromocionDescripcion, AV36TFPromocionDescripcion_Sel, AV37TFFacturaNo, AV38TFFacturaNo_Sel, AV39TFFacturaFechaFactura, AV40TFFacturaFechaFactura_To, AV27Estatus, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV58Pgmname = "WPUsuarioDetalleFacturaWC";
         edtavEstatuswithtags_Enabled = 0;
         edtavEstatus_Enabled = 0;
         edtFacturaID_Enabled = 0;
         edtPromocionID_Enabled = 0;
         edtFacturaFechaRegistro_Enabled = 0;
         edtPromocionDescripcion_Enabled = 0;
         edtPromocionBase_Enabled = 0;
         edtPromocionArte_Enabled = 0;
         edtPromocionVigencia_Enabled = 0;
         edtFacturaNo_Enabled = 0;
         edtFacturaFechaFactura_Enabled = 0;
         cmbFacturaEstatus.Enabled = 0;
         edtUsuarioID_Enabled = 0;
         cmbUsuarioZona.Enabled = 0;
         edtEstadoDescripcion_Enabled = 0;
         edtCiudadDescripcion_Enabled = 0;
         edtPaisDescripcion_Enabled = 0;
         edtUsuarioNombreCompleto_Enabled = 0;
         cmbUsuarioGenero.Enabled = 0;
         edtFacturaPDF_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP330( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15332 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV20DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_29 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_29"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV23GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV24GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV25GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            AV32DDO_FacturaFechaRegistroAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_FACTURAFECHAREGISTROAUXDATE"), 0);
            AV33DDO_FacturaFechaRegistroAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_FACTURAFECHAREGISTROAUXDATETO"), 0);
            AV41DDO_FacturaFechaFacturaAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_FACTURAFECHAFACTURAAUXDATE"), 0);
            AV42DDO_FacturaFechaFacturaAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_FACTURAFECHAFACTURAAUXDATETO"), 0);
            wcpOAV7UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7UsuarioID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Ddo_grid_Format = cgiGet( sPrefix+"DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            AV34DDO_FacturaFechaRegistroAuxDateText = cgiGet( edtavDdo_facturafecharegistroauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV34DDO_FacturaFechaRegistroAuxDateText", AV34DDO_FacturaFechaRegistroAuxDateText);
            AV43DDO_FacturaFechaFacturaAuxDateText = cgiGet( edtavDdo_facturafechafacturaauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV43DDO_FacturaFechaFacturaAuxDateText", AV43DDO_FacturaFechaFacturaAuxDateText);
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
         E15332 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E15332( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFFACTURAFECHAFACTURA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_facturafechafacturaauxdatetext_Internalname});
         this.executeUsercontrolMethod(sPrefix, false, "TFFACTURAFECHAREGISTRO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_facturafecharegistroauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
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
            S142 ();
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

      protected void E16332( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
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
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S152 ();
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
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV58Pgmname, out  GXt_char2) ;
         AV25GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV25GridAppliedFilters", AV25GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridState", AV11GridState);
      }

      protected void E12332( )
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

      protected void E13332( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14332( )
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
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaID") == 0 )
            {
               AV28TFFacturaID = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV28TFFacturaID", StringUtil.LTrimStr( (decimal)(AV28TFFacturaID), 9, 0));
               AV29TFFacturaID_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV29TFFacturaID_To", StringUtil.LTrimStr( (decimal)(AV29TFFacturaID_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaFechaRegistro") == 0 )
            {
               AV30TFFacturaFechaRegistro = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV30TFFacturaFechaRegistro", context.localUtil.Format(AV30TFFacturaFechaRegistro, "99/99/99"));
               AV31TFFacturaFechaRegistro_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV31TFFacturaFechaRegistro_To", context.localUtil.Format(AV31TFFacturaFechaRegistro_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PromocionDescripcion") == 0 )
            {
               AV35TFPromocionDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV35TFPromocionDescripcion", AV35TFPromocionDescripcion);
               AV36TFPromocionDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV36TFPromocionDescripcion_Sel", AV36TFPromocionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaNo") == 0 )
            {
               AV37TFFacturaNo = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV37TFFacturaNo", AV37TFFacturaNo);
               AV38TFFacturaNo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV38TFFacturaNo_Sel", AV38TFFacturaNo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaFechaFactura") == 0 )
            {
               AV39TFFacturaFechaFactura = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV39TFFacturaFechaFactura", context.localUtil.Format(AV39TFFacturaFechaFactura, "99/99/99"));
               AV40TFFacturaFechaFactura_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV40TFFacturaFechaFactura_To", context.localUtil.Format(AV40TFFacturaFechaFactura_To, "99/99/99"));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E17332( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         GXt_char2 = AV56EstatusWithTags;
         new WorkWithPlus.workwithplus_web.wwp_encodehtml(context ).execute(  AV27Estatus, out  GXt_char2) ;
         AV56EstatusWithTags = GXt_char2;
         AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV56EstatusWithTags);
         if ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 )
         {
            AV56EstatusWithTags += StringUtil.Format( "<span class='AttributeTagWarning TagAfterText'>%1</span>", context.GetMessage( "En proceso", ""), "", "", "", "", "", "", "", "");
            AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV56EstatusWithTags);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 )
         {
            AV56EstatusWithTags += StringUtil.Format( "<span class='AttributeTagSuccess TagAfterText'>%1</span>", context.GetMessage( "Aprobada", ""), "", "", "", "", "", "", "", "");
            AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV56EstatusWithTags);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
         {
            AV56EstatusWithTags += StringUtil.Format( "<span class='AttributeTagDanger TagAfterText'>%1</span>", context.GetMessage( "Rechazada", ""), "", "", "", "", "", "", "", "");
            AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV56EstatusWithTags);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Cancelada") == 0 )
         {
            AV56EstatusWithTags += StringUtil.Format( "<span class='AttributeTagInfo TagAfterText'>%1</span>", context.GetMessage( "Cancelada", ""), "", "", "", "", "", "", "", "");
            AssignAttri(sPrefix, false, edtavEstatuswithtags_Internalname, AV56EstatusWithTags);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 29;
         }
         sendrow_292( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_29_Refreshing )
         {
            DoAjaxLoad(29, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E11332( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S162 ();
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
            S152 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WPUsuarioDetalleFacturaWCFilters")) + "," + UrlEncode(StringUtil.RTrim(AV58Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WPUsuarioDetalleFacturaWCFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV18ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WPUsuarioDetalleFacturaWCFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV18ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S162 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV58Pgmname+"GridState",  AV18ManageFiltersXml) ;
               AV11GridState.FromXml(AV18ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S172 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17ManageFiltersData", AV17ManageFiltersData);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV17ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WPUsuarioDetalleFacturaWCFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
         AV28TFFacturaID = 0;
         AssignAttri(sPrefix, false, "AV28TFFacturaID", StringUtil.LTrimStr( (decimal)(AV28TFFacturaID), 9, 0));
         AV29TFFacturaID_To = 0;
         AssignAttri(sPrefix, false, "AV29TFFacturaID_To", StringUtil.LTrimStr( (decimal)(AV29TFFacturaID_To), 9, 0));
         AV30TFFacturaFechaRegistro = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV30TFFacturaFechaRegistro", context.localUtil.Format(AV30TFFacturaFechaRegistro, "99/99/99"));
         AV31TFFacturaFechaRegistro_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV31TFFacturaFechaRegistro_To", context.localUtil.Format(AV31TFFacturaFechaRegistro_To, "99/99/99"));
         AV35TFPromocionDescripcion = "";
         AssignAttri(sPrefix, false, "AV35TFPromocionDescripcion", AV35TFPromocionDescripcion);
         AV36TFPromocionDescripcion_Sel = "";
         AssignAttri(sPrefix, false, "AV36TFPromocionDescripcion_Sel", AV36TFPromocionDescripcion_Sel);
         AV37TFFacturaNo = "";
         AssignAttri(sPrefix, false, "AV37TFFacturaNo", AV37TFFacturaNo);
         AV38TFFacturaNo_Sel = "";
         AssignAttri(sPrefix, false, "AV38TFFacturaNo_Sel", AV38TFFacturaNo_Sel);
         AV39TFFacturaFechaFactura = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV39TFFacturaFechaFactura", context.localUtil.Format(AV39TFFacturaFechaFactura, "99/99/99"));
         AV40TFFacturaFechaFactura_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV40TFFacturaFechaFactura_To", context.localUtil.Format(AV40TFFacturaFechaFactura_To, "99/99/99"));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV58Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV58Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV16Session.Get(AV58Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S172 ();
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

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFFACTURAID") == 0 )
            {
               AV28TFFacturaID = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV28TFFacturaID", StringUtil.LTrimStr( (decimal)(AV28TFFacturaID), 9, 0));
               AV29TFFacturaID_To = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV29TFFacturaID_To", StringUtil.LTrimStr( (decimal)(AV29TFFacturaID_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAREGISTRO") == 0 )
            {
               AV30TFFacturaFechaRegistro = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV30TFFacturaFechaRegistro", context.localUtil.Format(AV30TFFacturaFechaRegistro, "99/99/99"));
               AV31TFFacturaFechaRegistro_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV31TFFacturaFechaRegistro_To", context.localUtil.Format(AV31TFFacturaFechaRegistro_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION") == 0 )
            {
               AV35TFPromocionDescripcion = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV35TFPromocionDescripcion", AV35TFPromocionDescripcion);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION_SEL") == 0 )
            {
               AV36TFPromocionDescripcion_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV36TFPromocionDescripcion_Sel", AV36TFPromocionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFFACTURANO") == 0 )
            {
               AV37TFFacturaNo = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV37TFFacturaNo", AV37TFFacturaNo);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFFACTURANO_SEL") == 0 )
            {
               AV38TFFacturaNo_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV38TFFacturaNo_Sel", AV38TFFacturaNo_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAFACTURA") == 0 )
            {
               AV39TFFacturaFechaFactura = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV39TFFacturaFechaFactura", context.localUtil.Format(AV39TFFacturaFechaFactura, "99/99/99"));
               AV40TFFacturaFechaFactura_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV40TFFacturaFechaFactura_To", context.localUtil.Format(AV40TFFacturaFechaFactura_To, "99/99/99"));
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPromocionDescripcion_Sel)),  AV36TFPromocionDescripcion_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFFacturaNo_Sel)),  AV38TFFacturaNo_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = "||"+GXt_char2+"|"+GXt_char4+"||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPromocionDescripcion)),  AV35TFPromocionDescripcion, out  GXt_char4) ;
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFFacturaNo)),  AV37TFFacturaNo, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((0==AV28TFFacturaID) ? "" : StringUtil.Str( (decimal)(AV28TFFacturaID), 9, 0))+"|"+((DateTime.MinValue==AV30TFFacturaFechaRegistro) ? "" : context.localUtil.DToC( AV30TFFacturaFechaRegistro, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+GXt_char4+"|"+GXt_char2+"|"+((DateTime.MinValue==AV39TFFacturaFechaFactura) ? "" : context.localUtil.DToC( AV39TFFacturaFechaFactura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV29TFFacturaID_To) ? "" : StringUtil.Str( (decimal)(AV29TFFacturaID_To), 9, 0))+"|"+((DateTime.MinValue==AV31TFFacturaFechaRegistro_To) ? "" : context.localUtil.DToC( AV31TFFacturaFechaRegistro_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|||"+((DateTime.MinValue==AV40TFFacturaFechaFactura_To) ? "" : context.localUtil.DToC( AV40TFFacturaFechaFactura_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV16Session.Get(AV58Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFFACTURAID",  context.GetMessage( "Folio", ""),  !((0==AV28TFFacturaID)&&(0==AV29TFFacturaID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV28TFFacturaID), 9, 0)),  ((0==AV28TFFacturaID) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV28TFFacturaID), "ZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV29TFFacturaID_To), 9, 0)),  ((0==AV29TFFacturaID_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV29TFFacturaID_To), "ZZZZZZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFFACTURAFECHAREGISTRO",  context.GetMessage( "Fecha Registro", ""),  !((DateTime.MinValue==AV30TFFacturaFechaRegistro)&&(DateTime.MinValue==AV31TFFacturaFechaRegistro_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV30TFFacturaFechaRegistro, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV30TFFacturaFechaRegistro) ? "" : StringUtil.Trim( context.localUtil.Format( AV30TFFacturaFechaRegistro, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV31TFFacturaFechaRegistro_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV31TFFacturaFechaRegistro_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV31TFFacturaFechaRegistro_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROMOCIONDESCRIPCION",  context.GetMessage( "Nom. Promoción", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPromocionDescripcion)),  0,  AV35TFPromocionDescripcion,  AV35TFPromocionDescripcion,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPromocionDescripcion_Sel)),  AV36TFPromocionDescripcion_Sel,  AV36TFPromocionDescripcion_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFFACTURANO",  context.GetMessage( "No. Factura", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFFacturaNo)),  0,  AV37TFFacturaNo,  AV37TFFacturaNo,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFFacturaNo_Sel)),  AV38TFFacturaNo_Sel,  AV38TFFacturaNo_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFFACTURAFECHAFACTURA",  context.GetMessage( "Fecha Factura", ""),  !((DateTime.MinValue==AV39TFFacturaFechaFactura)&&(DateTime.MinValue==AV40TFFacturaFechaFactura_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV39TFFacturaFechaFactura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV39TFFacturaFechaFactura) ? "" : StringUtil.Trim( context.localUtil.Format( AV39TFFacturaFechaFactura, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV40TFFacturaFechaFactura_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV40TFFacturaFechaFactura_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV40TFFacturaFechaFactura_To, "99/99/99")))) ;
         if ( ! (0==AV7UsuarioID) )
         {
            AV12GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&USUARIOID";
            AV12GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV7UsuarioID), 9, 0);
            AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV58Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV58Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Factura";
         AV10TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV10TrnContextAtt.gxTpr_Attributename = "UsuarioID";
         AV10TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV7UsuarioID), 9, 0);
         AV9TrnContext.gxTpr_Attributes.Add(AV10TrnContextAtt, 0);
         AV16Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7UsuarioID = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV7UsuarioID", StringUtil.LTrimStr( (decimal)(AV7UsuarioID), 9, 0));
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
         PA332( ) ;
         WS332( ) ;
         WE332( ) ;
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
         sCtrlAV7UsuarioID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA332( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpusuariodetallefacturawc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA332( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV7UsuarioID = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV7UsuarioID", StringUtil.LTrimStr( (decimal)(AV7UsuarioID), 9, 0));
         }
         wcpOAV7UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7UsuarioID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV7UsuarioID != wcpOAV7UsuarioID ) ) )
         {
            setjustcreated();
         }
         wcpOAV7UsuarioID = AV7UsuarioID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV7UsuarioID = cgiGet( sPrefix+"AV7UsuarioID_CTRL");
         if ( StringUtil.Len( sCtrlAV7UsuarioID) > 0 )
         {
            AV7UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV7UsuarioID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV7UsuarioID", StringUtil.LTrimStr( (decimal)(AV7UsuarioID), 9, 0));
         }
         else
         {
            AV7UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV7UsuarioID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA332( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS332( ) ;
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
         WS332( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7UsuarioID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7UsuarioID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7UsuarioID_CTRL", StringUtil.RTrim( sCtrlAV7UsuarioID));
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
         WE332( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202651111305698", true, true);
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
         context.AddJavascriptSource("wpusuariodetallefacturawc.js", "?202651111305699", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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

      protected void SubsflControlProps_292( )
      {
         edtFacturaID_Internalname = sPrefix+"FACTURAID_"+sGXsfl_29_idx;
         edtPromocionID_Internalname = sPrefix+"PROMOCIONID_"+sGXsfl_29_idx;
         edtFacturaFechaRegistro_Internalname = sPrefix+"FACTURAFECHAREGISTRO_"+sGXsfl_29_idx;
         edtPromocionDescripcion_Internalname = sPrefix+"PROMOCIONDESCRIPCION_"+sGXsfl_29_idx;
         edtPromocionBase_Internalname = sPrefix+"PROMOCIONBASE_"+sGXsfl_29_idx;
         edtPromocionArte_Internalname = sPrefix+"PROMOCIONARTE_"+sGXsfl_29_idx;
         edtPromocionVigencia_Internalname = sPrefix+"PROMOCIONVIGENCIA_"+sGXsfl_29_idx;
         edtFacturaNo_Internalname = sPrefix+"FACTURANO_"+sGXsfl_29_idx;
         edtFacturaFechaFactura_Internalname = sPrefix+"FACTURAFECHAFACTURA_"+sGXsfl_29_idx;
         edtavEstatuswithtags_Internalname = sPrefix+"vESTATUSWITHTAGS_"+sGXsfl_29_idx;
         edtavEstatus_Internalname = sPrefix+"vESTATUS_"+sGXsfl_29_idx;
         cmbFacturaEstatus_Internalname = sPrefix+"FACTURAESTATUS_"+sGXsfl_29_idx;
         edtUsuarioID_Internalname = sPrefix+"USUARIOID_"+sGXsfl_29_idx;
         cmbUsuarioZona_Internalname = sPrefix+"USUARIOZONA_"+sGXsfl_29_idx;
         edtEstadoDescripcion_Internalname = sPrefix+"ESTADODESCRIPCION_"+sGXsfl_29_idx;
         edtCiudadDescripcion_Internalname = sPrefix+"CIUDADDESCRIPCION_"+sGXsfl_29_idx;
         edtPaisDescripcion_Internalname = sPrefix+"PAISDESCRIPCION_"+sGXsfl_29_idx;
         edtUsuarioNombreCompleto_Internalname = sPrefix+"USUARIONOMBRECOMPLETO_"+sGXsfl_29_idx;
         cmbUsuarioGenero_Internalname = sPrefix+"USUARIOGENERO_"+sGXsfl_29_idx;
         edtFacturaPDF_Internalname = sPrefix+"FACTURAPDF_"+sGXsfl_29_idx;
      }

      protected void SubsflControlProps_fel_292( )
      {
         edtFacturaID_Internalname = sPrefix+"FACTURAID_"+sGXsfl_29_fel_idx;
         edtPromocionID_Internalname = sPrefix+"PROMOCIONID_"+sGXsfl_29_fel_idx;
         edtFacturaFechaRegistro_Internalname = sPrefix+"FACTURAFECHAREGISTRO_"+sGXsfl_29_fel_idx;
         edtPromocionDescripcion_Internalname = sPrefix+"PROMOCIONDESCRIPCION_"+sGXsfl_29_fel_idx;
         edtPromocionBase_Internalname = sPrefix+"PROMOCIONBASE_"+sGXsfl_29_fel_idx;
         edtPromocionArte_Internalname = sPrefix+"PROMOCIONARTE_"+sGXsfl_29_fel_idx;
         edtPromocionVigencia_Internalname = sPrefix+"PROMOCIONVIGENCIA_"+sGXsfl_29_fel_idx;
         edtFacturaNo_Internalname = sPrefix+"FACTURANO_"+sGXsfl_29_fel_idx;
         edtFacturaFechaFactura_Internalname = sPrefix+"FACTURAFECHAFACTURA_"+sGXsfl_29_fel_idx;
         edtavEstatuswithtags_Internalname = sPrefix+"vESTATUSWITHTAGS_"+sGXsfl_29_fel_idx;
         edtavEstatus_Internalname = sPrefix+"vESTATUS_"+sGXsfl_29_fel_idx;
         cmbFacturaEstatus_Internalname = sPrefix+"FACTURAESTATUS_"+sGXsfl_29_fel_idx;
         edtUsuarioID_Internalname = sPrefix+"USUARIOID_"+sGXsfl_29_fel_idx;
         cmbUsuarioZona_Internalname = sPrefix+"USUARIOZONA_"+sGXsfl_29_fel_idx;
         edtEstadoDescripcion_Internalname = sPrefix+"ESTADODESCRIPCION_"+sGXsfl_29_fel_idx;
         edtCiudadDescripcion_Internalname = sPrefix+"CIUDADDESCRIPCION_"+sGXsfl_29_fel_idx;
         edtPaisDescripcion_Internalname = sPrefix+"PAISDESCRIPCION_"+sGXsfl_29_fel_idx;
         edtUsuarioNombreCompleto_Internalname = sPrefix+"USUARIONOMBRECOMPLETO_"+sGXsfl_29_fel_idx;
         cmbUsuarioGenero_Internalname = sPrefix+"USUARIOGENERO_"+sGXsfl_29_fel_idx;
         edtFacturaPDF_Internalname = sPrefix+"FACTURAPDF_"+sGXsfl_29_fel_idx;
      }

      protected void sendrow_292( )
      {
         sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
         SubsflControlProps_292( ) ;
         WB330( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_29_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_29_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_29_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaRegistro_Internalname,context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"),context.localUtil.Format( A72FacturaFechaRegistro, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaRegistro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionDescripcion_Internalname,(string)A42PromocionDescripcion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionBase_Internalname,(string)A43PromocionBase,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionBase_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)700,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A44PromocionArte_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001PromocionArte_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40001PromocionArte_GXI : context.PathToRelativeUrl( A44PromocionArte));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionArte_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)0,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A44PromocionArte_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionVigencia_Internalname,(string)A70PromocionVigencia,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionVigencia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaNo_Internalname,StringUtil.RTrim( A71FacturaNo),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaNo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaFactura_Internalname,context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"),context.localUtil.Format( A73FacturaFechaFactura, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaFactura_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'" + sGXsfl_29_idx + "',29)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEstatuswithtags_Internalname,(string)AV56EstatusWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEstatuswithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavEstatuswithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEstatus_Internalname,StringUtil.RTrim( AV27Estatus),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEstatus_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavEstatus_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbFacturaEstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "FACTURAESTATUS_" + sGXsfl_29_idx;
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
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbFacturaEstatus,(string)cmbFacturaEstatus_Internalname,StringUtil.RTrim( A80FacturaEstatus),(short)1,(string)cmbFacturaEstatus_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbFacturaEstatus.CurrentValue = StringUtil.RTrim( A80FacturaEstatus);
            AssignProp(sPrefix, false, cmbFacturaEstatus_Internalname, "Values", (string)(cmbFacturaEstatus.ToJavascriptSource()), !bGXsfl_29_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            GXCCtl = "USUARIOZONA_" + sGXsfl_29_idx;
            cmbUsuarioZona.Name = GXCCtl;
            cmbUsuarioZona.WebTags = "";
            cmbUsuarioZona.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
            cmbUsuarioZona.addItem("Centro", context.GetMessage( "Centro", ""), 0);
            cmbUsuarioZona.addItem("Centro América", context.GetMessage( "Centro América", ""), 0);
            cmbUsuarioZona.addItem("Norte", context.GetMessage( "Norte", ""), 0);
            cmbUsuarioZona.addItem("Pacífico", context.GetMessage( "Pacifico", ""), 0);
            cmbUsuarioZona.addItem("Sur", context.GetMessage( "Sur", ""), 0);
            if ( cmbUsuarioZona.ItemCount > 0 )
            {
               A63UsuarioZona = cmbUsuarioZona.getValidValue(A63UsuarioZona);
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbUsuarioZona,(string)cmbUsuarioZona_Internalname,StringUtil.RTrim( A63UsuarioZona),(short)1,(string)cmbUsuarioZona_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbUsuarioZona.CurrentValue = StringUtil.RTrim( A63UsuarioZona);
            AssignProp(sPrefix, false, cmbUsuarioZona_Internalname, "Values", (string)(cmbUsuarioZona.ToJavascriptSource()), !bGXsfl_29_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoDescripcion_Internalname,(string)A2EstadoDescripcion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCiudadDescripcion_Internalname,(string)A5CiudadDescripcion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCiudadDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaisDescripcion_Internalname,(string)A17PaisDescripcion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaisDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombreCompleto_Internalname,(string)A52UsuarioNombreCompleto,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombreCompleto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            GXCCtl = "USUARIOGENERO_" + sGXsfl_29_idx;
            cmbUsuarioGenero.Name = GXCCtl;
            cmbUsuarioGenero.WebTags = "";
            cmbUsuarioGenero.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
            cmbUsuarioGenero.addItem("Masculino", context.GetMessage( "Masculino", ""), 0);
            cmbUsuarioGenero.addItem("Femenino", context.GetMessage( "Femenino", ""), 0);
            if ( cmbUsuarioGenero.ItemCount > 0 )
            {
               A53UsuarioGenero = cmbUsuarioGenero.getValidValue(A53UsuarioGenero);
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbUsuarioGenero,(string)cmbUsuarioGenero_Internalname,StringUtil.RTrim( A53UsuarioGenero),(short)1,(string)cmbUsuarioGenero_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbUsuarioGenero.CurrentValue = StringUtil.RTrim( A53UsuarioGenero);
            AssignProp(sPrefix, false, cmbUsuarioGenero_Internalname, "Values", (string)(cmbUsuarioGenero.ToJavascriptSource()), !bGXsfl_29_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* BinaryFile Variable */
            ClassString = "Attribute";
            StyleString = "";
            A75FacturaPDF_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000FacturaPDF_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)));
            GridRow.AddColumnProperties("binaryfile", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaPDF_Internalname,(String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)) ? A40000FacturaPDF_GXI : context.PathToRelativeUrl( A75FacturaPDF)),(string)edtFacturaPDF_Filename,(short)1,(short)0,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A75FacturaPDF_IsBlob});
            send_integrity_lvl_hashes332( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_29_idx = ((subGrid_Islastpage==1)&&(nGXsfl_29_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_29_idx+1);
            sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
            SubsflControlProps_292( ) ;
         }
         /* End function sendrow_292 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "FACTURAESTATUS_" + sGXsfl_29_idx;
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
         GXCCtl = "USUARIOZONA_" + sGXsfl_29_idx;
         cmbUsuarioZona.Name = GXCCtl;
         cmbUsuarioZona.WebTags = "";
         cmbUsuarioZona.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbUsuarioZona.addItem("Centro", context.GetMessage( "Centro", ""), 0);
         cmbUsuarioZona.addItem("Centro América", context.GetMessage( "Centro América", ""), 0);
         cmbUsuarioZona.addItem("Norte", context.GetMessage( "Norte", ""), 0);
         cmbUsuarioZona.addItem("Pacífico", context.GetMessage( "Pacifico", ""), 0);
         cmbUsuarioZona.addItem("Sur", context.GetMessage( "Sur", ""), 0);
         if ( cmbUsuarioZona.ItemCount > 0 )
         {
         }
         GXCCtl = "USUARIOGENERO_" + sGXsfl_29_idx;
         cmbUsuarioGenero.Name = GXCCtl;
         cmbUsuarioGenero.WebTags = "";
         cmbUsuarioGenero.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbUsuarioGenero.addItem("Masculino", context.GetMessage( "Masculino", ""), 0);
         cmbUsuarioGenero.addItem("Femenino", context.GetMessage( "Femenino", ""), 0);
         if ( cmbUsuarioGenero.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl29( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"29\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Folio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Registro", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nom. Promoción", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Bases", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Arte", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Vigencia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "No. Factura", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Factura", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estatus", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estatus", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estatus", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Zona", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Ciudad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "País", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre completo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Género", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "PDF", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A42PromocionDescripcion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A43PromocionBase));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A44PromocionArte));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A70PromocionVigencia));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A71FacturaNo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A73FacturaFechaFactura, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV56EstatusWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEstatuswithtags_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV27Estatus)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEstatus_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A80FacturaEstatus)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A63UsuarioZona)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A2EstadoDescripcion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A5CiudadDescripcion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A17PaisDescripcion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A52UsuarioNombreCompleto));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A53UsuarioGenero)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A75FacturaPDF));
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
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         edtFacturaID_Internalname = sPrefix+"FACTURAID";
         edtPromocionID_Internalname = sPrefix+"PROMOCIONID";
         edtFacturaFechaRegistro_Internalname = sPrefix+"FACTURAFECHAREGISTRO";
         edtPromocionDescripcion_Internalname = sPrefix+"PROMOCIONDESCRIPCION";
         edtPromocionBase_Internalname = sPrefix+"PROMOCIONBASE";
         edtPromocionArte_Internalname = sPrefix+"PROMOCIONARTE";
         edtPromocionVigencia_Internalname = sPrefix+"PROMOCIONVIGENCIA";
         edtFacturaNo_Internalname = sPrefix+"FACTURANO";
         edtFacturaFechaFactura_Internalname = sPrefix+"FACTURAFECHAFACTURA";
         edtavEstatuswithtags_Internalname = sPrefix+"vESTATUSWITHTAGS";
         edtavEstatus_Internalname = sPrefix+"vESTATUS";
         cmbFacturaEstatus_Internalname = sPrefix+"FACTURAESTATUS";
         edtUsuarioID_Internalname = sPrefix+"USUARIOID";
         cmbUsuarioZona_Internalname = sPrefix+"USUARIOZONA";
         edtEstadoDescripcion_Internalname = sPrefix+"ESTADODESCRIPCION";
         edtCiudadDescripcion_Internalname = sPrefix+"CIUDADDESCRIPCION";
         edtPaisDescripcion_Internalname = sPrefix+"PAISDESCRIPCION";
         edtUsuarioNombreCompleto_Internalname = sPrefix+"USUARIONOMBRECOMPLETO";
         cmbUsuarioGenero_Internalname = sPrefix+"USUARIOGENERO";
         edtFacturaPDF_Internalname = sPrefix+"FACTURAPDF";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
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
         edtFacturaPDF_Filename = "";
         cmbUsuarioGenero_Jsonclick = "";
         edtUsuarioNombreCompleto_Jsonclick = "";
         edtPaisDescripcion_Jsonclick = "";
         edtCiudadDescripcion_Jsonclick = "";
         edtEstadoDescripcion_Jsonclick = "";
         cmbUsuarioZona_Jsonclick = "";
         edtUsuarioID_Jsonclick = "";
         cmbFacturaEstatus_Jsonclick = "";
         edtavEstatus_Jsonclick = "";
         edtavEstatus_Enabled = 0;
         edtavEstatuswithtags_Jsonclick = "";
         edtavEstatuswithtags_Enabled = 0;
         edtFacturaFechaFactura_Jsonclick = "";
         edtFacturaNo_Jsonclick = "";
         edtPromocionVigencia_Jsonclick = "";
         edtPromocionBase_Jsonclick = "";
         edtPromocionDescripcion_Jsonclick = "";
         edtFacturaFechaRegistro_Jsonclick = "";
         edtPromocionID_Jsonclick = "";
         edtFacturaID_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridNoBorder WorkWith";
         subGrid_Backcolorstyle = 0;
         edtFacturaPDF_Enabled = 0;
         cmbUsuarioGenero.Enabled = 0;
         edtUsuarioNombreCompleto_Enabled = 0;
         edtPaisDescripcion_Enabled = 0;
         edtCiudadDescripcion_Enabled = 0;
         edtEstadoDescripcion_Enabled = 0;
         cmbUsuarioZona.Enabled = 0;
         edtUsuarioID_Enabled = 0;
         cmbFacturaEstatus.Enabled = 0;
         edtFacturaFechaFactura_Enabled = 0;
         edtFacturaNo_Enabled = 0;
         edtPromocionVigencia_Enabled = 0;
         edtPromocionArte_Enabled = 0;
         edtPromocionBase_Enabled = 0;
         edtPromocionDescripcion_Enabled = 0;
         edtFacturaFechaRegistro_Enabled = 0;
         edtPromocionID_Enabled = 0;
         edtFacturaID_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_facturafechafacturaauxdatetext_Jsonclick = "";
         edtavDdo_facturafecharegistroauxdatetext_Jsonclick = "";
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "9.0|||||";
         Ddo_grid_Datalistproc = "WPUsuarioDetalleFacturaWCGetFilterData";
         Ddo_grid_Datalisttype = "||Dynamic|Dynamic||";
         Ddo_grid_Includedatalist = "||T|T||";
         Ddo_grid_Filterisrange = "T|P|||P|";
         Ddo_grid_Filtertype = "Numeric|Date|Character|Character|Date|";
         Ddo_grid_Includefilter = "T|T|T|T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "3|4|2|1|5|1";
         Ddo_grid_Columnids = "0:FacturaID|2:FacturaFechaRegistro|3:PromocionDescripcion|7:FacturaNo|8:FacturaFechaFactura|9:Estatus";
         Ddo_grid_Gridinternalname = "";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV27Estatus","fld":"vESTATUS","hsh":true},{"av":"sPrefix"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV7UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV28TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV29TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV30TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV31TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV35TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV36TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV37TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV38TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV39TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV40TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV23GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV24GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV25GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12332","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV7UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV28TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV29TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV30TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV31TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV35TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV36TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV37TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV38TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV39TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV40TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV27Estatus","fld":"vESTATUS","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13332","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV7UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV28TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV29TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV30TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV31TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV35TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV36TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV37TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV38TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV39TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV40TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV27Estatus","fld":"vESTATUS","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14332","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV7UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV28TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV29TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV30TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV31TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV35TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV36TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV37TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV38TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV39TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV40TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV27Estatus","fld":"vESTATUS","hsh":true},{"av":"sPrefix"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV28TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV29TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV30TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV31TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV35TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV36TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV37TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV38TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV39TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV40TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E17332","iparms":[{"av":"AV27Estatus","fld":"vESTATUS","hsh":true},{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV56EstatusWithTags","fld":"vESTATUSWITHTAGS"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11332","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV7UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV28TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV29TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV30TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV31TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV35TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV36TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV37TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV38TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV39TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV40TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV27Estatus","fld":"vESTATUS","hsh":true},{"av":"sPrefix"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV29TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV30TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV31TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV35TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV36TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV37TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV38TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV39TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV40TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV23GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV24GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV25GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VALID_PROMOCIONID","""{"handler":"Valid_Promocionid","iparms":[]}""");
         setEventMetadata("VALID_USUARIOID","""{"handler":"Valid_Usuarioid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Facturapdf","iparms":[]}""");
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
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15FilterFullText = "";
         AV58Pgmname = "";
         AV30TFFacturaFechaRegistro = DateTime.MinValue;
         AV31TFFacturaFechaRegistro_To = DateTime.MinValue;
         AV35TFPromocionDescripcion = "";
         AV36TFPromocionDescripcion_Sel = "";
         AV37TFFacturaNo = "";
         AV38TFFacturaNo_Sel = "";
         AV39TFFacturaFechaFactura = DateTime.MinValue;
         AV40TFFacturaFechaFactura_To = DateTime.MinValue;
         AV27Estatus = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV17ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV25GridAppliedFilters = "";
         AV20DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV33DDO_FacturaFechaRegistroAuxDateTo = DateTime.MinValue;
         AV42DDO_FacturaFechaFacturaAuxDateTo = DateTime.MinValue;
         AV11GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         A45PromocionFechaInicio = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         AV32DDO_FacturaFechaRegistroAuxDate = DateTime.MinValue;
         AV41DDO_FacturaFechaFacturaAuxDate = DateTime.MinValue;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         TempTags = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV34DDO_FacturaFechaRegistroAuxDateText = "";
         ucTffacturafecharegistro_rangepicker = new GXUserControl();
         AV43DDO_FacturaFechaFacturaAuxDateText = "";
         ucTffacturafechafactura_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A72FacturaFechaRegistro = DateTime.MinValue;
         A42PromocionDescripcion = "";
         A43PromocionBase = "";
         A44PromocionArte = "";
         A40001PromocionArte_GXI = "";
         A70PromocionVigencia = "";
         A71FacturaNo = "";
         A73FacturaFechaFactura = DateTime.MinValue;
         AV56EstatusWithTags = "";
         A80FacturaEstatus = "";
         A63UsuarioZona = "";
         A2EstadoDescripcion = "";
         A5CiudadDescripcion = "";
         A17PaisDescripcion = "";
         A52UsuarioNombreCompleto = "";
         A53UsuarioGenero = "";
         A75FacturaPDF = "";
         A40000FacturaPDF_GXI = "";
         GXDecQS = "";
         lV15FilterFullText = "";
         lV35TFPromocionDescripcion = "";
         lV37TFFacturaNo = "";
         H00332_A4CiudadID = new int[1] ;
         H00332_n4CiudadID = new bool[] {false} ;
         H00332_A1EstadoID = new int[1] ;
         H00332_A16PaisID = new int[1] ;
         H00332_A93FacturaCompleta = new bool[] {false} ;
         H00332_A40000FacturaPDF_GXI = new string[] {""} ;
         H00332_A53UsuarioGenero = new string[] {""} ;
         H00332_A17PaisDescripcion = new string[] {""} ;
         H00332_A5CiudadDescripcion = new string[] {""} ;
         H00332_A2EstadoDescripcion = new string[] {""} ;
         H00332_A63UsuarioZona = new string[] {""} ;
         H00332_A29UsuarioID = new int[1] ;
         H00332_A80FacturaEstatus = new string[] {""} ;
         H00332_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         H00332_A71FacturaNo = new string[] {""} ;
         H00332_A40001PromocionArte_GXI = new string[] {""} ;
         H00332_A43PromocionBase = new string[] {""} ;
         H00332_A42PromocionDescripcion = new string[] {""} ;
         H00332_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         H00332_A41PromocionID = new int[1] ;
         H00332_A69FacturaID = new int[1] ;
         H00332_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         H00332_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         H00332_A51UsuarioApellido = new string[] {""} ;
         H00332_A30UsuarioNombre = new string[] {""} ;
         H00332_A75FacturaPDF = new string[] {""} ;
         H00332_A44PromocionArte = new string[] {""} ;
         H00333_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV18ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV16Session = context.GetSession();
         AV12GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char4 = "";
         GXt_char2 = "";
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV10TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV7UsuarioID = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpusuariodetallefacturawc__default(),
            new Object[][] {
                new Object[] {
               H00332_A4CiudadID, H00332_n4CiudadID, H00332_A1EstadoID, H00332_A16PaisID, H00332_A93FacturaCompleta, H00332_A40000FacturaPDF_GXI, H00332_A53UsuarioGenero, H00332_A17PaisDescripcion, H00332_A5CiudadDescripcion, H00332_A2EstadoDescripcion,
               H00332_A63UsuarioZona, H00332_A29UsuarioID, H00332_A80FacturaEstatus, H00332_A73FacturaFechaFactura, H00332_A71FacturaNo, H00332_A40001PromocionArte_GXI, H00332_A43PromocionBase, H00332_A42PromocionDescripcion, H00332_A72FacturaFechaRegistro, H00332_A41PromocionID,
               H00332_A69FacturaID, H00332_A46PromocionFechaFin, H00332_A45PromocionFechaInicio, H00332_A51UsuarioApellido, H00332_A30UsuarioNombre, H00332_A75FacturaPDF, H00332_A44PromocionArte
               }
               , new Object[] {
               H00333_AGRID_nRecordCount
               }
            }
         );
         AV58Pgmname = "WPUsuarioDetalleFacturaWC";
         /* GeneXus formulas. */
         AV58Pgmname = "WPUsuarioDetalleFacturaWC";
         edtavEstatuswithtags_Enabled = 0;
         edtavEstatus_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV13OrderedBy ;
      private short AV19ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV7UsuarioID ;
      private int wcpOAV7UsuarioID ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_29 ;
      private int nGXsfl_29_idx=1 ;
      private int AV28TFFacturaID ;
      private int AV29TFFacturaID_To ;
      private int edtavEstatuswithtags_Enabled ;
      private int edtavEstatus_Enabled ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A69FacturaID ;
      private int A41PromocionID ;
      private int A29UsuarioID ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A4CiudadID ;
      private int A1EstadoID ;
      private int A16PaisID ;
      private int edtFacturaID_Enabled ;
      private int edtPromocionID_Enabled ;
      private int edtFacturaFechaRegistro_Enabled ;
      private int edtPromocionDescripcion_Enabled ;
      private int edtPromocionBase_Enabled ;
      private int edtPromocionArte_Enabled ;
      private int edtPromocionVigencia_Enabled ;
      private int edtFacturaNo_Enabled ;
      private int edtFacturaFechaFactura_Enabled ;
      private int edtUsuarioID_Enabled ;
      private int edtEstadoDescripcion_Enabled ;
      private int edtCiudadDescripcion_Enabled ;
      private int edtPaisDescripcion_Enabled ;
      private int edtUsuarioNombreCompleto_Enabled ;
      private int edtFacturaPDF_Enabled ;
      private int AV22PageToGo ;
      private int AV59GXV1 ;
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
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_29_idx="0001" ;
      private string AV58Pgmname ;
      private string AV37TFFacturaNo ;
      private string AV38TFFacturaNo_Sel ;
      private string AV27Estatus ;
      private string edtavEstatuswithtags_Internalname ;
      private string edtavEstatus_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
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
      private string Ddo_grid_Format ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablegridheader_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string TempTags ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
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
      private string edtPromocionID_Internalname ;
      private string edtFacturaFechaRegistro_Internalname ;
      private string edtPromocionDescripcion_Internalname ;
      private string edtPromocionBase_Internalname ;
      private string edtPromocionArte_Internalname ;
      private string edtPromocionVigencia_Internalname ;
      private string A71FacturaNo ;
      private string edtFacturaNo_Internalname ;
      private string edtFacturaFechaFactura_Internalname ;
      private string cmbFacturaEstatus_Internalname ;
      private string A80FacturaEstatus ;
      private string edtUsuarioID_Internalname ;
      private string cmbUsuarioZona_Internalname ;
      private string A63UsuarioZona ;
      private string edtEstadoDescripcion_Internalname ;
      private string edtCiudadDescripcion_Internalname ;
      private string edtPaisDescripcion_Internalname ;
      private string edtUsuarioNombreCompleto_Internalname ;
      private string cmbUsuarioGenero_Internalname ;
      private string A53UsuarioGenero ;
      private string edtFacturaPDF_Internalname ;
      private string GXDecQS ;
      private string lV37TFFacturaNo ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string sCtrlAV7UsuarioID ;
      private string sGXsfl_29_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtFacturaID_Jsonclick ;
      private string edtPromocionID_Jsonclick ;
      private string edtFacturaFechaRegistro_Jsonclick ;
      private string edtPromocionDescripcion_Jsonclick ;
      private string edtPromocionBase_Jsonclick ;
      private string sImgUrl ;
      private string edtPromocionVigencia_Jsonclick ;
      private string edtFacturaNo_Jsonclick ;
      private string edtFacturaFechaFactura_Jsonclick ;
      private string edtavEstatuswithtags_Jsonclick ;
      private string edtavEstatus_Jsonclick ;
      private string GXCCtl ;
      private string cmbFacturaEstatus_Jsonclick ;
      private string edtUsuarioID_Jsonclick ;
      private string cmbUsuarioZona_Jsonclick ;
      private string edtEstadoDescripcion_Jsonclick ;
      private string edtCiudadDescripcion_Jsonclick ;
      private string edtPaisDescripcion_Jsonclick ;
      private string edtUsuarioNombreCompleto_Jsonclick ;
      private string cmbUsuarioGenero_Jsonclick ;
      private string edtFacturaPDF_Filename ;
      private string subGrid_Header ;
      private DateTime AV30TFFacturaFechaRegistro ;
      private DateTime AV31TFFacturaFechaRegistro_To ;
      private DateTime AV39TFFacturaFechaFactura ;
      private DateTime AV40TFFacturaFechaFactura_To ;
      private DateTime AV33DDO_FacturaFechaRegistroAuxDateTo ;
      private DateTime AV42DDO_FacturaFechaFacturaAuxDateTo ;
      private DateTime A45PromocionFechaInicio ;
      private DateTime A46PromocionFechaFin ;
      private DateTime AV32DDO_FacturaFechaRegistroAuxDate ;
      private DateTime AV41DDO_FacturaFechaFacturaAuxDate ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A73FacturaFechaFactura ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool bGXsfl_29_Refreshing=false ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool A93FacturaCompleta ;
      private bool n4CiudadID ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool A44PromocionArte_IsBlob ;
      private bool A75FacturaPDF_IsBlob ;
      private string AV18ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV35TFPromocionDescripcion ;
      private string AV36TFPromocionDescripcion_Sel ;
      private string AV25GridAppliedFilters ;
      private string AV34DDO_FacturaFechaRegistroAuxDateText ;
      private string AV43DDO_FacturaFechaFacturaAuxDateText ;
      private string A42PromocionDescripcion ;
      private string A43PromocionBase ;
      private string A40001PromocionArte_GXI ;
      private string A70PromocionVigencia ;
      private string AV56EstatusWithTags ;
      private string A2EstadoDescripcion ;
      private string A5CiudadDescripcion ;
      private string A17PaisDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string A40000FacturaPDF_GXI ;
      private string lV15FilterFullText ;
      private string lV35TFPromocionDescripcion ;
      private string A44PromocionArte ;
      private string A75FacturaPDF ;
      private IGxSession AV16Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTffacturafecharegistro_rangepicker ;
      private GXUserControl ucTffacturafechafactura_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV8HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbFacturaEstatus ;
      private GXCombobox cmbUsuarioZona ;
      private GXCombobox cmbUsuarioGenero ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV20DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private int[] H00332_A4CiudadID ;
      private bool[] H00332_n4CiudadID ;
      private int[] H00332_A1EstadoID ;
      private int[] H00332_A16PaisID ;
      private bool[] H00332_A93FacturaCompleta ;
      private string[] H00332_A40000FacturaPDF_GXI ;
      private string[] H00332_A53UsuarioGenero ;
      private string[] H00332_A17PaisDescripcion ;
      private string[] H00332_A5CiudadDescripcion ;
      private string[] H00332_A2EstadoDescripcion ;
      private string[] H00332_A63UsuarioZona ;
      private int[] H00332_A29UsuarioID ;
      private string[] H00332_A80FacturaEstatus ;
      private DateTime[] H00332_A73FacturaFechaFactura ;
      private string[] H00332_A71FacturaNo ;
      private string[] H00332_A40001PromocionArte_GXI ;
      private string[] H00332_A43PromocionBase ;
      private string[] H00332_A42PromocionDescripcion ;
      private DateTime[] H00332_A72FacturaFechaRegistro ;
      private int[] H00332_A41PromocionID ;
      private int[] H00332_A69FacturaID ;
      private DateTime[] H00332_A46PromocionFechaFin ;
      private DateTime[] H00332_A45PromocionFechaInicio ;
      private string[] H00332_A51UsuarioApellido ;
      private string[] H00332_A30UsuarioNombre ;
      private string[] H00332_A75FacturaPDF ;
      private string[] H00332_A44PromocionArte ;
      private long[] H00333_AGRID_nRecordCount ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV10TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpusuariodetallefacturawc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00332( IGxContext context ,
                                             string AV15FilterFullText ,
                                             int AV28TFFacturaID ,
                                             int AV29TFFacturaID_To ,
                                             DateTime AV30TFFacturaFechaRegistro ,
                                             DateTime AV31TFFacturaFechaRegistro_To ,
                                             string AV36TFPromocionDescripcion_Sel ,
                                             string AV35TFPromocionDescripcion ,
                                             string AV38TFFacturaNo_Sel ,
                                             string AV37TFFacturaNo ,
                                             DateTime AV39TFFacturaFechaFactura ,
                                             DateTime AV40TFFacturaFechaFactura_To ,
                                             int A69FacturaID ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             bool A93FacturaCompleta ,
                                             int AV7UsuarioID ,
                                             int A29UsuarioID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[16];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.`CiudadID`, T3.`EstadoID`, T4.`PaisID`, T1.`FacturaCompleta`, T1.`FacturaPDF_GXI`, T2.`UsuarioGenero`, T5.`PaisDescripcion`, T3.`CiudadDescripcion`, T4.`EstadoDescripcion`, T2.`UsuarioZona`, T1.`UsuarioID`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaNo`, T6.`PromocionArte_GXI`, T6.`PromocionBase`, T6.`PromocionDescripcion`, T1.`FacturaFechaRegistro`, T1.`PromocionID`, T1.`FacturaID`, T6.`PromocionFechaFin`, T6.`PromocionFechaInicio`, T2.`UsuarioApellido`, T2.`UsuarioNombre`, T1.`FacturaPDF`, T6.`PromocionArte`";
         sFromString = " FROM (((((`Factura` T1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = T1.`UsuarioID`) LEFT JOIN `Ciudad` T3 ON T3.`CiudadID` = T2.`CiudadID`) LEFT JOIN `Estado` T4 ON T4.`EstadoID` = T3.`EstadoID`) LEFT JOIN `Pais` T5 ON T5.`PaisID` = T4.`PaisID`) INNER JOIN `Promocion` T6 ON T6.`PromocionID` = T1.`PromocionID`)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.`UsuarioID` = @AV7UsuarioID)");
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)) )
         {
            AddWhere(sWhereString, "(( (LPAD(REPLACE(FORMAT(T1.`FacturaID`,0), ',', ''), 9, ' ')) like CONCAT('%', @lV15FilterFullText)) or ( T6.`PromocionDescripcion` like CONCAT('%', @lV15FilterFullText)) or ( T1.`FacturaNo` like CONCAT('%', @lV15FilterFullText)))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV28TFFacturaID) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` >= @AV28TFFacturaID)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (0==AV29TFFacturaID_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` <= @AV29TFFacturaID_To)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV30TFFacturaFechaRegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV30TFFacturaFechaRegistro)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV31TFFacturaFechaRegistro_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV31TFFacturaFechaRegistro_To)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPromocionDescripcion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPromocionDescripcion)) ) )
         {
            AddWhere(sWhereString, "(T6.`PromocionDescripcion` like @lV35TFPromocionDescripcion)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPromocionDescripcion_Sel)) && ! ( StringUtil.StrCmp(AV36TFPromocionDescripcion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.`PromocionDescripcion` = @AV36TFPromocionDescripcion_Sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV36TFPromocionDescripcion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T6.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFFacturaNo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFFacturaNo)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV37TFFacturaNo)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFFacturaNo_Sel)) && ! ( StringUtil.StrCmp(AV38TFFacturaNo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV38TFFacturaNo_Sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV38TFFacturaNo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV39TFFacturaFechaFactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV39TFFacturaFechaFactura)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV40TFFacturaFechaFactura_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV40TFFacturaFechaFactura_To)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`UsuarioID`, T1.`FacturaNo`";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`UsuarioID` DESC, T1.`FacturaNo` DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`UsuarioID`, T6.`PromocionDescripcion`";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`UsuarioID` DESC, T6.`PromocionDescripcion` DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`UsuarioID`, T1.`FacturaID`";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`UsuarioID` DESC, T1.`FacturaID` DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`UsuarioID`, T1.`FacturaFechaRegistro`";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`UsuarioID` DESC, T1.`FacturaFechaRegistro` DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`UsuarioID`, T1.`FacturaFechaFactura`";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`UsuarioID` DESC, T1.`FacturaFechaFactura` DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.`FacturaID`";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " LIMIT " + "@GXPagingFrom2" + ", " + "@GXPagingTo2";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H00333( IGxContext context ,
                                             string AV15FilterFullText ,
                                             int AV28TFFacturaID ,
                                             int AV29TFFacturaID_To ,
                                             DateTime AV30TFFacturaFechaRegistro ,
                                             DateTime AV31TFFacturaFechaRegistro_To ,
                                             string AV36TFPromocionDescripcion_Sel ,
                                             string AV35TFPromocionDescripcion ,
                                             string AV38TFFacturaNo_Sel ,
                                             string AV37TFFacturaNo ,
                                             DateTime AV39TFFacturaFechaFactura ,
                                             DateTime AV40TFFacturaFechaFactura_To ,
                                             int A69FacturaID ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             bool A93FacturaCompleta ,
                                             int AV7UsuarioID ,
                                             int A29UsuarioID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[14];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((((`Factura` T1 INNER JOIN `Usuario` T3 ON T3.`UsuarioID` = T1.`UsuarioID`) LEFT JOIN `Ciudad` T4 ON T4.`CiudadID` = T3.`CiudadID`) LEFT JOIN `Estado` T5 ON T5.`EstadoID` = T4.`EstadoID`) LEFT JOIN `Pais` T6 ON T6.`PaisID` = T5.`PaisID`) INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`)";
         AddWhere(sWhereString, "(T1.`UsuarioID` = @AV7UsuarioID)");
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)) )
         {
            AddWhere(sWhereString, "(( (LPAD(REPLACE(FORMAT(T1.`FacturaID`,0), ',', ''), 9, ' ')) like CONCAT('%', @lV15FilterFullText)) or ( T2.`PromocionDescripcion` like CONCAT('%', @lV15FilterFullText)) or ( T1.`FacturaNo` like CONCAT('%', @lV15FilterFullText)))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( ! (0==AV28TFFacturaID) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` >= @AV28TFFacturaID)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! (0==AV29TFFacturaID_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` <= @AV29TFFacturaID_To)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV30TFFacturaFechaRegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV30TFFacturaFechaRegistro)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV31TFFacturaFechaRegistro_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV31TFFacturaFechaRegistro_To)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPromocionDescripcion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPromocionDescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV35TFPromocionDescripcion)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPromocionDescripcion_Sel)) && ! ( StringUtil.StrCmp(AV36TFPromocionDescripcion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV36TFPromocionDescripcion_Sel)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV36TFPromocionDescripcion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFFacturaNo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFFacturaNo)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV37TFFacturaNo)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFFacturaNo_Sel)) && ! ( StringUtil.StrCmp(AV38TFFacturaNo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV38TFFacturaNo_Sel)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV38TFFacturaNo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV39TFFacturaFechaFactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV39TFFacturaFechaFactura)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV40TFFacturaFechaFactura_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV40TFFacturaFechaFactura_To)");
         }
         else
         {
            GXv_int7[13] = 1;
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
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00332(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] , (bool)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] );
               case 1 :
                     return conditional_H00333(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] , (bool)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH00332;
          prmH00332 = new Object[] {
          new ParDef("@AV7UsuarioID",GXType.Int32,9,0) ,
          new ParDef("@lV15FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.Char,100,0) ,
          new ParDef("@AV28TFFacturaID",GXType.Int32,9,0) ,
          new ParDef("@AV29TFFacturaID_To",GXType.Int32,9,0) ,
          new ParDef("@AV30TFFacturaFechaRegistro",GXType.Date,8,0) ,
          new ParDef("@AV31TFFacturaFechaRegistro_To",GXType.Date,8,0) ,
          new ParDef("@lV35TFPromocionDescripcion",GXType.Char,80,0) ,
          new ParDef("@AV36TFPromocionDescripcion_Sel",GXType.Char,80,0) ,
          new ParDef("@lV37TFFacturaNo",GXType.Char,20,0) ,
          new ParDef("@AV38TFFacturaNo_Sel",GXType.Char,20,0) ,
          new ParDef("@AV39TFFacturaFechaFactura",GXType.Date,8,0) ,
          new ParDef("@AV40TFFacturaFechaFactura_To",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00333;
          prmH00333 = new Object[] {
          new ParDef("@AV7UsuarioID",GXType.Int32,9,0) ,
          new ParDef("@lV15FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.Char,100,0) ,
          new ParDef("@AV28TFFacturaID",GXType.Int32,9,0) ,
          new ParDef("@AV29TFFacturaID_To",GXType.Int32,9,0) ,
          new ParDef("@AV30TFFacturaFechaRegistro",GXType.Date,8,0) ,
          new ParDef("@AV31TFFacturaFechaRegistro_To",GXType.Date,8,0) ,
          new ParDef("@lV35TFPromocionDescripcion",GXType.Char,80,0) ,
          new ParDef("@AV36TFPromocionDescripcion_Sel",GXType.Char,80,0) ,
          new ParDef("@lV37TFFacturaNo",GXType.Char,20,0) ,
          new ParDef("@AV38TFFacturaNo_Sel",GXType.Char,20,0) ,
          new ParDef("@AV39TFFacturaFechaFactura",GXType.Date,8,0) ,
          new ParDef("@AV40TFFacturaFechaFactura_To",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00332", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00332,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00333", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00333,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 30);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((string[]) buf[12])[0] = rslt.getString(12, 20);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(13);
                ((string[]) buf[14])[0] = rslt.getString(14, 20);
                ((string[]) buf[15])[0] = rslt.getMultimediaUri(15);
                ((string[]) buf[16])[0] = rslt.getVarchar(16);
                ((string[]) buf[17])[0] = rslt.getVarchar(17);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(18);
                ((int[]) buf[19])[0] = rslt.getInt(19);
                ((int[]) buf[20])[0] = rslt.getInt(20);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(21);
                ((DateTime[]) buf[22])[0] = rslt.getGXDate(22);
                ((string[]) buf[23])[0] = rslt.getString(23, 50);
                ((string[]) buf[24])[0] = rslt.getString(24, 50);
                ((string[]) buf[25])[0] = rslt.getMultimediaFile(25, rslt.getVarchar(5));
                ((string[]) buf[26])[0] = rslt.getMultimediaFile(26, rslt.getVarchar(15));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
