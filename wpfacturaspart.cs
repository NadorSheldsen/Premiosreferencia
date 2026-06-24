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
   public class wpfacturaspart : GXDataArea
   {
      public wpfacturaspart( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpfacturaspart( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbFacturaEstatus = new GXCombobox();
         chkMotivoRechazoActivo = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_59 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_59"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_59_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_59_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_59_idx = GetPar( "sGXsfl_59_idx");
         edtavUseraction3_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavUseraction3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction3_Visible), 5, 0), !bGXsfl_59_Refreshing);
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
         AV88FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
         AV89ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
         AV15FilterFullText = GetPar( "FilterFullText");
         AV24ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV19ColumnsSelector);
         AV101Pgmname = GetPar( "Pgmname");
         AV27TFFacturaFechaRegistro = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaRegistro"));
         AV28TFFacturaFechaRegistro_To = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaRegistro_To"));
         AV32TFPromocionDescripcion = GetPar( "TFPromocionDescripcion");
         AV33TFPromocionDescripcion_Sel = GetPar( "TFPromocionDescripcion_Sel");
         AV34TFFacturaNo = GetPar( "TFFacturaNo");
         AV35TFFacturaNo_Sel = GetPar( "TFFacturaNo_Sel");
         AV36TFFacturaFechaFactura = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaFactura"));
         AV37TFFacturaFechaFactura_To = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaFactura_To"));
         AV41TFEstatus = GetPar( "TFEstatus");
         AV42TFEstatusOperator = (short)(Math.Round(NumberUtil.Val( GetPar( "TFEstatusOperator"), "."), 18, MidpointRounding.ToEven));
         AV53TFUsuarioNombreCompleto = GetPar( "TFUsuarioNombreCompleto");
         AV54TFUsuarioNombreCompleto_Sel = GetPar( "TFUsuarioNombreCompleto_Sel");
         AV65UsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "UsuarioID"), "."), 18, MidpointRounding.ToEven));
         edtavUseraction3_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavUseraction3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction3_Visible), 5, 0), !bGXsfl_59_Refreshing);
         AV16Estatus = GetPar( "Estatus");
         AV83RegUsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "RegUsuarioID"), "."), 18, MidpointRounding.ToEven));
         A11DistribuidorDescripcion = GetPar( "DistribuidorDescripcion");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV88FromDate, AV89ToDate, AV15FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV101Pgmname, AV27TFFacturaFechaRegistro, AV28TFFacturaFechaRegistro_To, AV32TFPromocionDescripcion, AV33TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV41TFEstatus, AV42TFEstatusOperator, AV53TFUsuarioNombreCompleto, AV54TFUsuarioNombreCompleto_Sel, AV65UsuarioID, AV16Estatus, AV83RegUsuarioID, A11DistribuidorDescripcion) ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
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
         PA3B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3B2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpfacturaspart.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV101Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV101Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV65UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vREGUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV83RegUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREGUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV83RegUsuarioID), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFROMDATE", context.localUtil.Format(AV88FromDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vTODATE", context.localUtil.Format(AV89ToDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV15FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_59", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_59), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vELEMENTS", AV90Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vELEMENTS", AV90Elements);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPARAMETERS", AV91Parameters);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPARAMETERS", AV91Parameters);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCLICKDATA", AV92ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCLICKDATA", AV92ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMDOUBLECLICKDATA", AV93ItemDoubleClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMDOUBLECLICKDATA", AV93ItemDoubleClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDRAGANDDROPDATA", AV94DragAndDropData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDRAGANDDROPDATA", AV94DragAndDropData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERCHANGEDDATA", AV95FilterChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERCHANGEDDATA", AV95FilterChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMEXPANDDATA", AV96ItemExpandData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMEXPANDDATA", AV96ItemExpandData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCOLLAPSEDATA", AV97ItemCollapseData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCOLLAPSEDATA", AV97ItemCollapseData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV22ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV22ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV62GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV57DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV57DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV19ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV19ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_FACTURAFECHAREGISTROAUXDATETO", context.localUtil.DToC( AV30DDO_FacturaFechaRegistroAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_FACTURAFECHAFACTURAAUXDATETO", context.localUtil.DToC( AV39DDO_FacturaFechaFacturaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV101Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV101Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAFECHAREGISTRO", context.localUtil.DToC( AV27TFFacturaFechaRegistro, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAFECHAREGISTRO_TO", context.localUtil.DToC( AV28TFFacturaFechaRegistro_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFPROMOCIONDESCRIPCION", AV32TFPromocionDescripcion);
         GxWebStd.gx_hidden_field( context, "vTFPROMOCIONDESCRIPCION_SEL", AV33TFPromocionDescripcion_Sel);
         GxWebStd.gx_hidden_field( context, "vTFFACTURANO", StringUtil.RTrim( AV34TFFacturaNo));
         GxWebStd.gx_hidden_field( context, "vTFFACTURANO_SEL", StringUtil.RTrim( AV35TFFacturaNo_Sel));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAFECHAFACTURA", context.localUtil.DToC( AV36TFFacturaFechaFactura, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAFECHAFACTURA_TO", context.localUtil.DToC( AV37TFFacturaFechaFactura_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFESTATUS", StringUtil.RTrim( AV41TFEstatus));
         GxWebStd.gx_hidden_field( context, "vTFESTATUSOPERATOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42TFEstatusOperator), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIONOMBRECOMPLETO", AV53TFUsuarioNombreCompleto);
         GxWebStd.gx_hidden_field( context, "vTFUSUARIONOMBRECOMPLETO_SEL", AV54TFUsuarioNombreCompleto_Sel);
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV65UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vREGUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV83RegUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREGUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV83RegUsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DISTRIBUIDORDESCRIPCION", A11DistribuidorDescripcion);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_hidden_field( context, "vFACTURAID_SELECTED", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV73FacturaID_Selected), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLISTAUSUARIOS", AV100ListaUsuarios);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLISTAUSUARIOS", AV100ListaUsuarios);
         }
         GxWebStd.gx_hidden_field( context, "vBLOB", AV85Blob);
         GxWebStd.gx_hidden_field( context, "vFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV87FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "FACTURAPDF", A75FacturaPDF);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "USUARIONOMBRE", StringUtil.RTrim( A30UsuarioNombre));
         GxWebStd.gx_hidden_field( context, "USUARIOAPELLIDO", StringUtil.RTrim( A51UsuarioApellido));
         GxWebStd.gx_hidden_field( context, "vDDO_FACTURAFECHAREGISTROAUXDATE", context.localUtil.DToC( AV29DDO_FacturaFechaRegistroAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_FACTURAFECHAFACTURAAUXDATE", context.localUtil.DToC( AV38DDO_FacturaFechaFacturaAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UTCHARTDOUGHNUT_Objectcall", StringUtil.RTrim( Utchartdoughnut_Objectcall));
         GxWebStd.gx_hidden_field( context, "UTCHARTDOUGHNUT_Objectcall", StringUtil.RTrim( Utchartdoughnut_Objectcall));
         GxWebStd.gx_hidden_field( context, "UTCHARTDOUGHNUT_Type", StringUtil.RTrim( Utchartdoughnut_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTDOUGHNUT_Title", StringUtil.RTrim( Utchartdoughnut_Title));
         GxWebStd.gx_hidden_field( context, "UTCHARTDOUGHNUT_Showvalues", StringUtil.BoolToStr( Utchartdoughnut_Showvalues));
         GxWebStd.gx_hidden_field( context, "UTCHARTDOUGHNUT_Charttype", StringUtil.RTrim( Utchartdoughnut_Charttype));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Objectcall", StringUtil.RTrim( Utchartcolumnline_Objectcall));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Objectcall", StringUtil.RTrim( Utchartcolumnline_Objectcall));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Type", StringUtil.RTrim( Utchartcolumnline_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Title", StringUtil.RTrim( Utchartcolumnline_Title));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "INNWEWINDOW_Target", StringUtil.RTrim( Innwewindow_Target));
         GxWebStd.gx_hidden_field( context, "POPOVER_PARTIDAS_Gridinternalname", StringUtil.RTrim( Popover_partidas_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "POPOVER_PARTIDAS_Iteminternalname", StringUtil.RTrim( Popover_partidas_Iteminternalname));
         GxWebStd.gx_hidden_field( context, "POPOVER_PARTIDAS_Isgriditem", StringUtil.BoolToStr( Popover_partidas_Isgriditem));
         GxWebStd.gx_hidden_field( context, "POPOVER_PARTIDAS_Trigger", StringUtil.RTrim( Popover_partidas_Trigger));
         GxWebStd.gx_hidden_field( context, "POPOVER_PARTIDAS_Popoverwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Popover_partidas_Popoverwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POPOVER_PARTIDAS_Position", StringUtil.RTrim( Popover_partidas_Position));
         GxWebStd.gx_hidden_field( context, "POPOVER_PARTIDAS_Keepopened", StringUtil.BoolToStr( Popover_partidas_Keepopened));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixedfilters", StringUtil.RTrim( Ddo_grid_Fixedfilters));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedfixedfilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTION3_Title", StringUtil.RTrim( Dvelop_confirmpanel_useraction3_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTION3_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useraction3_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTION3_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useraction3_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTION3_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useraction3_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTION3_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useraction3_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTION3_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useraction3_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTION3_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useraction3_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Popoversingrid", StringUtil.RTrim( Grid_empowerer_Popoversingrid));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumnfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedcolumnfixedfilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTION3_Result", StringUtil.RTrim( Dvelop_confirmpanel_useraction3_Result));
         GxWebStd.gx_hidden_field( context, "vUSERACTION3_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction3_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumnfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedcolumnfixedfilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTION3_Result", StringUtil.RTrim( Dvelop_confirmpanel_useraction3_Result));
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE3B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3B2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wpfacturaspart.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPFacturasPart" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Factura", "") ;
      }

      protected void WB3B0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'" + sGXsfl_59_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFromdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFromdate_Internalname, context.localUtil.Format(AV88FromDate, "99/99/99"), context.localUtil.Format( AV88FromDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFromdate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFromdate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPFacturasPart.htm");
            GxWebStd.gx_bitmap( context, edtavFromdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFromdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPFacturasPart.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'" + sGXsfl_59_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTodate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTodate_Internalname, context.localUtil.Format(AV89ToDate, "99/99/99"), context.localUtil.Format( AV89ToDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTodate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTodate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPFacturasPart.htm");
            GxWebStd.gx_bitmap( context, edtavTodate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTodate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPFacturasPart.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction99_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(59), 2, 0)+","+"null"+");", context.GetMessage( "Filtrar", ""), bttBtnuseraction99_Jsonclick, 5, context.GetMessage( "Filtrar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION99\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPFacturasPart.htm");
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
            ucUtchartdoughnut.SetProperty("Elements", AV90Elements);
            ucUtchartdoughnut.SetProperty("Parameters", AV91Parameters);
            ucUtchartdoughnut.SetProperty("Type", Utchartdoughnut_Type);
            ucUtchartdoughnut.SetProperty("Title", Utchartdoughnut_Title);
            ucUtchartdoughnut.SetProperty("ShowValues", Utchartdoughnut_Showvalues);
            ucUtchartdoughnut.SetProperty("ChartType", Utchartdoughnut_Charttype);
            ucUtchartdoughnut.SetProperty("ItemClickData", AV92ItemClickData);
            ucUtchartdoughnut.SetProperty("ItemDoubleClickData", AV93ItemDoubleClickData);
            ucUtchartdoughnut.SetProperty("DragAndDropData", AV94DragAndDropData);
            ucUtchartdoughnut.SetProperty("FilterChangedData", AV95FilterChangedData);
            ucUtchartdoughnut.SetProperty("ItemExpandData", AV96ItemExpandData);
            ucUtchartdoughnut.SetProperty("ItemCollapseData", AV97ItemCollapseData);
            ucUtchartdoughnut.Render(context, "queryviewer", Utchartdoughnut_Internalname, "UTCHARTDOUGHNUTContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartcolumnline.SetProperty("Elements", AV90Elements);
            ucUtchartcolumnline.SetProperty("Parameters", AV91Parameters);
            ucUtchartcolumnline.SetProperty("Type", Utchartcolumnline_Type);
            ucUtchartcolumnline.SetProperty("Title", Utchartcolumnline_Title);
            ucUtchartcolumnline.SetProperty("ItemClickData", AV92ItemClickData);
            ucUtchartcolumnline.SetProperty("ItemDoubleClickData", AV93ItemDoubleClickData);
            ucUtchartcolumnline.SetProperty("DragAndDropData", AV94DragAndDropData);
            ucUtchartcolumnline.SetProperty("FilterChangedData", AV95FilterChangedData);
            ucUtchartcolumnline.SetProperty("ItemExpandData", AV96ItemExpandData);
            ucUtchartcolumnline.SetProperty("ItemCollapseData", AV97ItemCollapseData);
            ucUtchartcolumnline.Render(context, "queryviewer", Utchartcolumnline_Internalname, "UTCHARTCOLUMNLINEContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(59), 2, 0)+","+"null"+");", context.GetMessage( "Agregar", ""), bttBtnuseraction1_Jsonclick, 5, context.GetMessage( "Agregar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION1\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPFacturasPart.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(59), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WPFacturasPart.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV22ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_59_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WPFacturasPart.htm");
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
            StartGridControl59( ) ;
         }
         if ( wbEnd == 59 )
         {
            wbEnd = 0;
            nRC_GXsfl_59 = (int)(nGXsfl_59_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV60GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV61GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV62GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            ucInnwewindow.Render(context, "innewwindow", Innwewindow_Internalname, "INNWEWINDOWContainer");
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
            ucPopover_partidas.Render(context, "dvelop.wwppopover", Popover_partidas_Internalname, "POPOVER_PARTIDASContainer");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV57DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV57DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV19ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table1_92_3B2( true) ;
         }
         else
         {
            wb_table1_92_3B2( false) ;
         }
         return  ;
      }

      protected void wb_table1_92_3B2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("PopoversInGrid", Grid_empowerer_Popoversingrid);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0099"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0099"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_59_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0099"+"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_59_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_facturafecharegistroauxdatetext_Internalname, AV31DDO_FacturaFechaRegistroAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV31DDO_FacturaFechaRegistroAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_facturafecharegistroauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPFacturasPart.htm");
            /* User Defined Control */
            ucTffacturafecharegistro_rangepicker.SetProperty("Start Date", AV29DDO_FacturaFechaRegistroAuxDate);
            ucTffacturafecharegistro_rangepicker.SetProperty("End Date", AV30DDO_FacturaFechaRegistroAuxDateTo);
            ucTffacturafecharegistro_rangepicker.Render(context, "wwp.daterangepicker", Tffacturafecharegistro_rangepicker_Internalname, "TFFACTURAFECHAREGISTRO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_facturafechafacturaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'" + sGXsfl_59_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_facturafechafacturaauxdatetext_Internalname, AV40DDO_FacturaFechaFacturaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV40DDO_FacturaFechaFacturaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_facturafechafacturaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPFacturasPart.htm");
            /* User Defined Control */
            ucTffacturafechafactura_rangepicker.SetProperty("Start Date", AV38DDO_FacturaFechaFacturaAuxDate);
            ucTffacturafechafactura_rangepicker.SetProperty("End Date", AV39DDO_FacturaFechaFacturaAuxDateTo);
            ucTffacturafechafactura_rangepicker.Render(context, "wwp.daterangepicker", Tffacturafechafactura_rangepicker_Internalname, "TFFACTURAFECHAFACTURA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 59 )
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
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3B2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Factura", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3B0( ) ;
      }

      protected void WS3B2( )
      {
         START3B2( ) ;
         EVT3B2( ) ;
      }

      protected void EVT3B2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E113B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E123B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E133B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E143B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E153B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTION3.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_useraction3.Close */
                              E163B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction1' */
                              E173B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION99'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction99' */
                              E183B2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VPARTIDAS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VUSERACTION4.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VUSERACTION4.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VPARTIDAS.CLICK") == 0 ) )
                           {
                              nGXsfl_59_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
                              SubsflControlProps_592( ) ;
                              A69FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              AV69UserAction4 = cgiGet( edtavUseraction4_Internalname);
                              AssignProp("", false, edtavUseraction4_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV69UserAction4)) ? AV115Useraction4_GXI : context.convertURL( context.PathToRelativeUrl( AV69UserAction4))), !bGXsfl_59_Refreshing);
                              AssignProp("", false, edtavUseraction4_Internalname, "SrcSet", context.GetImageSrcSet( AV69UserAction4), true);
                              AV77UserAction8 = cgiGet( edtavUseraction8_Internalname);
                              AssignAttri("", false, edtavUseraction8_Internalname, AV77UserAction8);
                              A72FacturaFechaRegistro = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaRegistro_Internalname), 0));
                              A42PromocionDescripcion = cgiGet( edtPromocionDescripcion_Internalname);
                              A71FacturaNo = cgiGet( edtFacturaNo_Internalname);
                              A73FacturaFechaFactura = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaFactura_Internalname), 0));
                              AV82PartidasWithTags = cgiGet( edtavPartidaswithtags_Internalname);
                              AssignAttri("", false, edtavPartidaswithtags_Internalname, AV82PartidasWithTags);
                              AV81Partidas = cgiGet( edtavPartidas_Internalname);
                              AssignAttri("", false, edtavPartidas_Internalname, AV81Partidas);
                              AV75UserAction3 = cgiGet( edtavUseraction3_Internalname);
                              AssignAttri("", false, edtavUseraction3_Internalname, AV75UserAction3);
                              AV58EstatusWithTags = cgiGet( edtavEstatuswithtags_Internalname);
                              AssignAttri("", false, edtavEstatuswithtags_Internalname, AV58EstatusWithTags);
                              AV16Estatus = cgiGet( edtavEstatus_Internalname);
                              AssignAttri("", false, edtavEstatus_Internalname, AV16Estatus);
                              GxWebStd.gx_hidden_field( context, "gxhash_vESTATUS"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, StringUtil.RTrim( context.localUtil.Format( AV16Estatus, "")), context));
                              AV74Descripcion = cgiGet( edtavDescripcion_Internalname);
                              AssignAttri("", false, edtavDescripcion_Internalname, AV74Descripcion);
                              cmbFacturaEstatus.Name = cmbFacturaEstatus_Internalname;
                              cmbFacturaEstatus.CurrentValue = cgiGet( cmbFacturaEstatus_Internalname);
                              A80FacturaEstatus = cgiGet( cmbFacturaEstatus_Internalname);
                              A29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A52UsuarioNombreCompleto = cgiGet( edtUsuarioNombreCompleto_Internalname);
                              A21MotivoRechazoActivo = StringUtil.StrToBool( cgiGet( chkMotivoRechazoActivo_Internalname));
                              A20MotivoRechazoDescripcion = cgiGet( edtMotivoRechazoDescripcion_Internalname);
                              A19MotivoRechazoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMotivoRechazoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              AV84DistribuidorDescripcion = cgiGet( edtavDistribuidordescripcion_Internalname);
                              AssignAttri("", false, edtavDistribuidordescripcion_Internalname, AV84DistribuidorDescripcion);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E193B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E203B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E213B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VPARTIDAS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E223B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUSERACTION4.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E233B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Fromdate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vFROMDATE"), 0) != AV88FromDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Todate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vTODATE"), 0) != AV89ToDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
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
                        if ( nCmpId == 99 )
                        {
                           OldWwpaux_wc = cgiGet( "W0099");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0099", "", sEvt);
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

      protected void WE3B2( )
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

      protected void PA3B2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
               GX_FocusControl = edtavFromdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_592( ) ;
         while ( nGXsfl_59_idx <= nRC_GXsfl_59 )
         {
            sendrow_592( ) ;
            nGXsfl_59_idx = ((subGrid_Islastpage==1)&&(nGXsfl_59_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_59_idx+1);
            sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
            SubsflControlProps_592( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       DateTime AV88FromDate ,
                                       DateTime AV89ToDate ,
                                       string AV15FilterFullText ,
                                       short AV24ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV19ColumnsSelector ,
                                       string AV101Pgmname ,
                                       DateTime AV27TFFacturaFechaRegistro ,
                                       DateTime AV28TFFacturaFechaRegistro_To ,
                                       string AV32TFPromocionDescripcion ,
                                       string AV33TFPromocionDescripcion_Sel ,
                                       string AV34TFFacturaNo ,
                                       string AV35TFFacturaNo_Sel ,
                                       DateTime AV36TFFacturaFechaFactura ,
                                       DateTime AV37TFFacturaFechaFactura_To ,
                                       string AV41TFEstatus ,
                                       short AV42TFEstatusOperator ,
                                       string AV53TFUsuarioNombreCompleto ,
                                       string AV54TFUsuarioNombreCompleto_Sel ,
                                       int AV65UsuarioID ,
                                       string AV16Estatus ,
                                       int AV83RegUsuarioID ,
                                       string A11DistribuidorDescripcion )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3B2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vESTATUS", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16Estatus, "")), context));
         GxWebStd.gx_hidden_field( context, "vESTATUS", StringUtil.RTrim( AV16Estatus));
         GxWebStd.gx_hidden_field( context, "gxhash_FACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "FACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_FACTURAESTATUS", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A80FacturaEstatus, "")), context));
         GxWebStd.gx_hidden_field( context, "FACTURAESTATUS", StringUtil.RTrim( A80FacturaEstatus));
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
         RF3B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV101Pgmname = "WPFacturasPart";
         edtavUseraction8_Enabled = 0;
         edtavPartidaswithtags_Enabled = 0;
         edtavPartidas_Enabled = 0;
         edtavUseraction3_Enabled = 0;
         edtavEstatuswithtags_Enabled = 0;
         edtavEstatus_Enabled = 0;
         edtavDescripcion_Enabled = 0;
         edtavDistribuidordescripcion_Enabled = 0;
      }

      protected void RF3B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 59;
         /* Execute user event: Refresh */
         E203B2 ();
         nGXsfl_59_idx = 1;
         sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
         SubsflControlProps_592( ) ;
         bGXsfl_59_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
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
            SubsflControlProps_592( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A29UsuarioID ,
                                                 AV100ListaUsuarios ,
                                                 AV102Wpfacturaspartds_1_filterfulltext ,
                                                 AV103Wpfacturaspartds_2_tffacturafecharegistro ,
                                                 AV104Wpfacturaspartds_3_tffacturafecharegistro_to ,
                                                 AV106Wpfacturaspartds_5_tfpromociondescripcion_sel ,
                                                 AV105Wpfacturaspartds_4_tfpromociondescripcion ,
                                                 AV108Wpfacturaspartds_7_tffacturano_sel ,
                                                 AV107Wpfacturaspartds_6_tffacturano ,
                                                 AV109Wpfacturaspartds_8_tffacturafechafactura ,
                                                 AV110Wpfacturaspartds_9_tffacturafechafactura_to ,
                                                 AV112Wpfacturaspartds_11_tfestatusoperator ,
                                                 AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel ,
                                                 AV113Wpfacturaspartds_12_tfusuarionombrecompleto ,
                                                 AV88FromDate ,
                                                 AV89ToDate ,
                                                 AV100ListaUsuarios.Count ,
                                                 A42PromocionDescripcion ,
                                                 A71FacturaNo ,
                                                 A30UsuarioNombre ,
                                                 A51UsuarioApellido ,
                                                 A72FacturaFechaRegistro ,
                                                 A73FacturaFechaFactura ,
                                                 A80FacturaEstatus ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 A93FacturaCompleta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV102Wpfacturaspartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV102Wpfacturaspartds_1_filterfulltext), "%", "");
            lV102Wpfacturaspartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV102Wpfacturaspartds_1_filterfulltext), "%", "");
            lV102Wpfacturaspartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV102Wpfacturaspartds_1_filterfulltext), "%", "");
            lV105Wpfacturaspartds_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV105Wpfacturaspartds_4_tfpromociondescripcion), "%", "");
            lV107Wpfacturaspartds_6_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV107Wpfacturaspartds_6_tffacturano), 20, "%");
            lV113Wpfacturaspartds_12_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV113Wpfacturaspartds_12_tfusuarionombrecompleto), "%", "");
            /* Using cursor H003B2 */
            pr_default.execute(0, new Object[] {lV102Wpfacturaspartds_1_filterfulltext, lV102Wpfacturaspartds_1_filterfulltext, lV102Wpfacturaspartds_1_filterfulltext, AV103Wpfacturaspartds_2_tffacturafecharegistro, AV104Wpfacturaspartds_3_tffacturafecharegistro_to, lV105Wpfacturaspartds_4_tfpromociondescripcion, AV106Wpfacturaspartds_5_tfpromociondescripcion_sel, lV107Wpfacturaspartds_6_tffacturano, AV108Wpfacturaspartds_7_tffacturano_sel, AV109Wpfacturaspartds_8_tffacturafechafactura, AV110Wpfacturaspartds_9_tffacturafechafactura_to, lV113Wpfacturaspartds_12_tfusuarionombrecompleto, AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel, AV88FromDate, AV89ToDate, GXPagingFrom2, GXPagingTo2});
            nGXsfl_59_idx = 1;
            sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
            SubsflControlProps_592( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A41PromocionID = H003B2_A41PromocionID[0];
               A93FacturaCompleta = H003B2_A93FacturaCompleta[0];
               A19MotivoRechazoID = H003B2_A19MotivoRechazoID[0];
               A20MotivoRechazoDescripcion = H003B2_A20MotivoRechazoDescripcion[0];
               A21MotivoRechazoActivo = H003B2_A21MotivoRechazoActivo[0];
               A29UsuarioID = H003B2_A29UsuarioID[0];
               A80FacturaEstatus = H003B2_A80FacturaEstatus[0];
               A73FacturaFechaFactura = H003B2_A73FacturaFechaFactura[0];
               A71FacturaNo = H003B2_A71FacturaNo[0];
               A42PromocionDescripcion = H003B2_A42PromocionDescripcion[0];
               A72FacturaFechaRegistro = H003B2_A72FacturaFechaRegistro[0];
               A69FacturaID = H003B2_A69FacturaID[0];
               A51UsuarioApellido = H003B2_A51UsuarioApellido[0];
               A30UsuarioNombre = H003B2_A30UsuarioNombre[0];
               A42PromocionDescripcion = H003B2_A42PromocionDescripcion[0];
               A20MotivoRechazoDescripcion = H003B2_A20MotivoRechazoDescripcion[0];
               A21MotivoRechazoActivo = H003B2_A21MotivoRechazoActivo[0];
               A51UsuarioApellido = H003B2_A51UsuarioApellido[0];
               A30UsuarioNombre = H003B2_A30UsuarioNombre[0];
               A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
               /* Execute user event: Grid.Load */
               E213B2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 59;
            WB3B0( ) ;
         }
         bGXsfl_59_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3B2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV101Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV101Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV65UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTATUS"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, StringUtil.RTrim( context.localUtil.Format( AV16Estatus, "")), context));
         GxWebStd.gx_hidden_field( context, "vREGUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV83RegUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREGUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV83RegUsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_FACTURAID"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_FACTURAESTATUS"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, StringUtil.RTrim( context.localUtil.Format( A80FacturaEstatus, "")), context));
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
         AV102Wpfacturaspartds_1_filterfulltext = AV15FilterFullText;
         AV103Wpfacturaspartds_2_tffacturafecharegistro = AV27TFFacturaFechaRegistro;
         AV104Wpfacturaspartds_3_tffacturafecharegistro_to = AV28TFFacturaFechaRegistro_To;
         AV105Wpfacturaspartds_4_tfpromociondescripcion = AV32TFPromocionDescripcion;
         AV106Wpfacturaspartds_5_tfpromociondescripcion_sel = AV33TFPromocionDescripcion_Sel;
         AV107Wpfacturaspartds_6_tffacturano = AV34TFFacturaNo;
         AV108Wpfacturaspartds_7_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV109Wpfacturaspartds_8_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV110Wpfacturaspartds_9_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV111Wpfacturaspartds_10_tfestatus = AV41TFEstatus;
         AV112Wpfacturaspartds_11_tfestatusoperator = AV42TFEstatusOperator;
         AV113Wpfacturaspartds_12_tfusuarionombrecompleto = AV53TFUsuarioNombreCompleto;
         AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel = AV54TFUsuarioNombreCompleto_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV100ListaUsuarios ,
                                              AV102Wpfacturaspartds_1_filterfulltext ,
                                              AV103Wpfacturaspartds_2_tffacturafecharegistro ,
                                              AV104Wpfacturaspartds_3_tffacturafecharegistro_to ,
                                              AV106Wpfacturaspartds_5_tfpromociondescripcion_sel ,
                                              AV105Wpfacturaspartds_4_tfpromociondescripcion ,
                                              AV108Wpfacturaspartds_7_tffacturano_sel ,
                                              AV107Wpfacturaspartds_6_tffacturano ,
                                              AV109Wpfacturaspartds_8_tffacturafechafactura ,
                                              AV110Wpfacturaspartds_9_tffacturafechafactura_to ,
                                              AV112Wpfacturaspartds_11_tfestatusoperator ,
                                              AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel ,
                                              AV113Wpfacturaspartds_12_tfusuarionombrecompleto ,
                                              AV88FromDate ,
                                              AV89ToDate ,
                                              AV100ListaUsuarios.Count ,
                                              A42PromocionDescripcion ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A72FacturaFechaRegistro ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV102Wpfacturaspartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV102Wpfacturaspartds_1_filterfulltext), "%", "");
         lV102Wpfacturaspartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV102Wpfacturaspartds_1_filterfulltext), "%", "");
         lV102Wpfacturaspartds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV102Wpfacturaspartds_1_filterfulltext), "%", "");
         lV105Wpfacturaspartds_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV105Wpfacturaspartds_4_tfpromociondescripcion), "%", "");
         lV107Wpfacturaspartds_6_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV107Wpfacturaspartds_6_tffacturano), 20, "%");
         lV113Wpfacturaspartds_12_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV113Wpfacturaspartds_12_tfusuarionombrecompleto), "%", "");
         /* Using cursor H003B3 */
         pr_default.execute(1, new Object[] {lV102Wpfacturaspartds_1_filterfulltext, lV102Wpfacturaspartds_1_filterfulltext, lV102Wpfacturaspartds_1_filterfulltext, AV103Wpfacturaspartds_2_tffacturafecharegistro, AV104Wpfacturaspartds_3_tffacturafecharegistro_to, lV105Wpfacturaspartds_4_tfpromociondescripcion, AV106Wpfacturaspartds_5_tfpromociondescripcion_sel, lV107Wpfacturaspartds_6_tffacturano, AV108Wpfacturaspartds_7_tffacturano_sel, AV109Wpfacturaspartds_8_tffacturafechafactura, AV110Wpfacturaspartds_9_tffacturafechafactura_to, lV113Wpfacturaspartds_12_tfusuarionombrecompleto, AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel, AV88FromDate, AV89ToDate});
         GRID_nRecordCount = H003B3_AGRID_nRecordCount[0];
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
         AV102Wpfacturaspartds_1_filterfulltext = AV15FilterFullText;
         AV103Wpfacturaspartds_2_tffacturafecharegistro = AV27TFFacturaFechaRegistro;
         AV104Wpfacturaspartds_3_tffacturafecharegistro_to = AV28TFFacturaFechaRegistro_To;
         AV105Wpfacturaspartds_4_tfpromociondescripcion = AV32TFPromocionDescripcion;
         AV106Wpfacturaspartds_5_tfpromociondescripcion_sel = AV33TFPromocionDescripcion_Sel;
         AV107Wpfacturaspartds_6_tffacturano = AV34TFFacturaNo;
         AV108Wpfacturaspartds_7_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV109Wpfacturaspartds_8_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV110Wpfacturaspartds_9_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV111Wpfacturaspartds_10_tfestatus = AV41TFEstatus;
         AV112Wpfacturaspartds_11_tfestatusoperator = AV42TFEstatusOperator;
         AV113Wpfacturaspartds_12_tfusuarionombrecompleto = AV53TFUsuarioNombreCompleto;
         AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel = AV54TFUsuarioNombreCompleto_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV88FromDate, AV89ToDate, AV15FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV101Pgmname, AV27TFFacturaFechaRegistro, AV28TFFacturaFechaRegistro_To, AV32TFPromocionDescripcion, AV33TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV41TFEstatus, AV42TFEstatusOperator, AV53TFUsuarioNombreCompleto, AV54TFUsuarioNombreCompleto_Sel, AV65UsuarioID, AV16Estatus, AV83RegUsuarioID, A11DistribuidorDescripcion) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV102Wpfacturaspartds_1_filterfulltext = AV15FilterFullText;
         AV103Wpfacturaspartds_2_tffacturafecharegistro = AV27TFFacturaFechaRegistro;
         AV104Wpfacturaspartds_3_tffacturafecharegistro_to = AV28TFFacturaFechaRegistro_To;
         AV105Wpfacturaspartds_4_tfpromociondescripcion = AV32TFPromocionDescripcion;
         AV106Wpfacturaspartds_5_tfpromociondescripcion_sel = AV33TFPromocionDescripcion_Sel;
         AV107Wpfacturaspartds_6_tffacturano = AV34TFFacturaNo;
         AV108Wpfacturaspartds_7_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV109Wpfacturaspartds_8_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV110Wpfacturaspartds_9_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV111Wpfacturaspartds_10_tfestatus = AV41TFEstatus;
         AV112Wpfacturaspartds_11_tfestatusoperator = AV42TFEstatusOperator;
         AV113Wpfacturaspartds_12_tfusuarionombrecompleto = AV53TFUsuarioNombreCompleto;
         AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel = AV54TFUsuarioNombreCompleto_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV88FromDate, AV89ToDate, AV15FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV101Pgmname, AV27TFFacturaFechaRegistro, AV28TFFacturaFechaRegistro_To, AV32TFPromocionDescripcion, AV33TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV41TFEstatus, AV42TFEstatusOperator, AV53TFUsuarioNombreCompleto, AV54TFUsuarioNombreCompleto_Sel, AV65UsuarioID, AV16Estatus, AV83RegUsuarioID, A11DistribuidorDescripcion) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV102Wpfacturaspartds_1_filterfulltext = AV15FilterFullText;
         AV103Wpfacturaspartds_2_tffacturafecharegistro = AV27TFFacturaFechaRegistro;
         AV104Wpfacturaspartds_3_tffacturafecharegistro_to = AV28TFFacturaFechaRegistro_To;
         AV105Wpfacturaspartds_4_tfpromociondescripcion = AV32TFPromocionDescripcion;
         AV106Wpfacturaspartds_5_tfpromociondescripcion_sel = AV33TFPromocionDescripcion_Sel;
         AV107Wpfacturaspartds_6_tffacturano = AV34TFFacturaNo;
         AV108Wpfacturaspartds_7_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV109Wpfacturaspartds_8_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV110Wpfacturaspartds_9_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV111Wpfacturaspartds_10_tfestatus = AV41TFEstatus;
         AV112Wpfacturaspartds_11_tfestatusoperator = AV42TFEstatusOperator;
         AV113Wpfacturaspartds_12_tfusuarionombrecompleto = AV53TFUsuarioNombreCompleto;
         AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel = AV54TFUsuarioNombreCompleto_Sel;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV88FromDate, AV89ToDate, AV15FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV101Pgmname, AV27TFFacturaFechaRegistro, AV28TFFacturaFechaRegistro_To, AV32TFPromocionDescripcion, AV33TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV41TFEstatus, AV42TFEstatusOperator, AV53TFUsuarioNombreCompleto, AV54TFUsuarioNombreCompleto_Sel, AV65UsuarioID, AV16Estatus, AV83RegUsuarioID, A11DistribuidorDescripcion) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV102Wpfacturaspartds_1_filterfulltext = AV15FilterFullText;
         AV103Wpfacturaspartds_2_tffacturafecharegistro = AV27TFFacturaFechaRegistro;
         AV104Wpfacturaspartds_3_tffacturafecharegistro_to = AV28TFFacturaFechaRegistro_To;
         AV105Wpfacturaspartds_4_tfpromociondescripcion = AV32TFPromocionDescripcion;
         AV106Wpfacturaspartds_5_tfpromociondescripcion_sel = AV33TFPromocionDescripcion_Sel;
         AV107Wpfacturaspartds_6_tffacturano = AV34TFFacturaNo;
         AV108Wpfacturaspartds_7_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV109Wpfacturaspartds_8_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV110Wpfacturaspartds_9_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV111Wpfacturaspartds_10_tfestatus = AV41TFEstatus;
         AV112Wpfacturaspartds_11_tfestatusoperator = AV42TFEstatusOperator;
         AV113Wpfacturaspartds_12_tfusuarionombrecompleto = AV53TFUsuarioNombreCompleto;
         AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel = AV54TFUsuarioNombreCompleto_Sel;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV88FromDate, AV89ToDate, AV15FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV101Pgmname, AV27TFFacturaFechaRegistro, AV28TFFacturaFechaRegistro_To, AV32TFPromocionDescripcion, AV33TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV41TFEstatus, AV42TFEstatusOperator, AV53TFUsuarioNombreCompleto, AV54TFUsuarioNombreCompleto_Sel, AV65UsuarioID, AV16Estatus, AV83RegUsuarioID, A11DistribuidorDescripcion) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV102Wpfacturaspartds_1_filterfulltext = AV15FilterFullText;
         AV103Wpfacturaspartds_2_tffacturafecharegistro = AV27TFFacturaFechaRegistro;
         AV104Wpfacturaspartds_3_tffacturafecharegistro_to = AV28TFFacturaFechaRegistro_To;
         AV105Wpfacturaspartds_4_tfpromociondescripcion = AV32TFPromocionDescripcion;
         AV106Wpfacturaspartds_5_tfpromociondescripcion_sel = AV33TFPromocionDescripcion_Sel;
         AV107Wpfacturaspartds_6_tffacturano = AV34TFFacturaNo;
         AV108Wpfacturaspartds_7_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV109Wpfacturaspartds_8_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV110Wpfacturaspartds_9_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV111Wpfacturaspartds_10_tfestatus = AV41TFEstatus;
         AV112Wpfacturaspartds_11_tfestatusoperator = AV42TFEstatusOperator;
         AV113Wpfacturaspartds_12_tfusuarionombrecompleto = AV53TFUsuarioNombreCompleto;
         AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel = AV54TFUsuarioNombreCompleto_Sel;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV88FromDate, AV89ToDate, AV15FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV101Pgmname, AV27TFFacturaFechaRegistro, AV28TFFacturaFechaRegistro_To, AV32TFPromocionDescripcion, AV33TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV41TFEstatus, AV42TFEstatusOperator, AV53TFUsuarioNombreCompleto, AV54TFUsuarioNombreCompleto_Sel, AV65UsuarioID, AV16Estatus, AV83RegUsuarioID, A11DistribuidorDescripcion) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV101Pgmname = "WPFacturasPart";
         edtavUseraction8_Enabled = 0;
         edtavPartidaswithtags_Enabled = 0;
         edtavPartidas_Enabled = 0;
         edtavUseraction3_Enabled = 0;
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

      protected void STRUP3B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E193B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vELEMENTS"), AV90Elements);
            ajax_req_read_hidden_sdt(cgiGet( "vPARAMETERS"), AV91Parameters);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCLICKDATA"), AV92ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMDOUBLECLICKDATA"), AV93ItemDoubleClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vDRAGANDDROPDATA"), AV94DragAndDropData);
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERCHANGEDDATA"), AV95FilterChangedData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMEXPANDDATA"), AV96ItemExpandData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCOLLAPSEDATA"), AV97ItemCollapseData);
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV22ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV57DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV19ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_59 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_59"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV60GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV61GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV62GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV29DDO_FacturaFechaRegistroAuxDate = context.localUtil.CToD( cgiGet( "vDDO_FACTURAFECHAREGISTROAUXDATE"), 0);
            AV30DDO_FacturaFechaRegistroAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_FACTURAFECHAREGISTROAUXDATETO"), 0);
            AV38DDO_FacturaFechaFacturaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_FACTURAFECHAFACTURAAUXDATE"), 0);
            AV39DDO_FacturaFechaFacturaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_FACTURAFECHAFACTURAAUXDATETO"), 0);
            AV73FacturaID_Selected = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vFACTURAID_SELECTED"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Utchartdoughnut_Objectcall = cgiGet( "UTCHARTDOUGHNUT_Objectcall");
            Utchartdoughnut_Objectcall = cgiGet( "UTCHARTDOUGHNUT_Objectcall");
            Utchartdoughnut_Type = cgiGet( "UTCHARTDOUGHNUT_Type");
            Utchartdoughnut_Title = cgiGet( "UTCHARTDOUGHNUT_Title");
            Utchartdoughnut_Showvalues = StringUtil.StrToBool( cgiGet( "UTCHARTDOUGHNUT_Showvalues"));
            Utchartdoughnut_Charttype = cgiGet( "UTCHARTDOUGHNUT_Charttype");
            Utchartcolumnline_Objectcall = cgiGet( "UTCHARTCOLUMNLINE_Objectcall");
            Utchartcolumnline_Objectcall = cgiGet( "UTCHARTCOLUMNLINE_Objectcall");
            Utchartcolumnline_Type = cgiGet( "UTCHARTCOLUMNLINE_Type");
            Utchartcolumnline_Title = cgiGet( "UTCHARTCOLUMNLINE_Title");
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Innwewindow_Target = cgiGet( "INNWEWINDOW_Target");
            Popover_partidas_Gridinternalname = cgiGet( "POPOVER_PARTIDAS_Gridinternalname");
            Popover_partidas_Iteminternalname = cgiGet( "POPOVER_PARTIDAS_Iteminternalname");
            Popover_partidas_Isgriditem = StringUtil.StrToBool( cgiGet( "POPOVER_PARTIDAS_Isgriditem"));
            Popover_partidas_Trigger = cgiGet( "POPOVER_PARTIDAS_Trigger");
            Popover_partidas_Popoverwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POPOVER_PARTIDAS_Popoverwidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Popover_partidas_Position = cgiGet( "POPOVER_PARTIDAS_Position");
            Popover_partidas_Keepopened = StringUtil.StrToBool( cgiGet( "POPOVER_PARTIDAS_Keepopened"));
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Fixedfilters = cgiGet( "DDO_GRID_Fixedfilters");
            Ddo_grid_Selectedfixedfilter = cgiGet( "DDO_GRID_Selectedfixedfilter");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Dvelop_confirmpanel_useraction3_Title = cgiGet( "DVELOP_CONFIRMPANEL_USERACTION3_Title");
            Dvelop_confirmpanel_useraction3_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_USERACTION3_Confirmationtext");
            Dvelop_confirmpanel_useraction3_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTION3_Yesbuttoncaption");
            Dvelop_confirmpanel_useraction3_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTION3_Nobuttoncaption");
            Dvelop_confirmpanel_useraction3_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTION3_Cancelbuttoncaption");
            Dvelop_confirmpanel_useraction3_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_USERACTION3_Yesbuttonposition");
            Dvelop_confirmpanel_useraction3_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_USERACTION3_Confirmtype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            Grid_empowerer_Popoversingrid = cgiGet( "GRID_EMPOWERER_Popoversingrid");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Selectedcolumnfixedfilter = cgiGet( "DDO_GRID_Selectedcolumnfixedfilter");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_useraction3_Result = cgiGet( "DVELOP_CONFIRMPANEL_USERACTION3_Result");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavFromdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "From Date", "")}), 1, "vFROMDATE");
               GX_FocusControl = edtavFromdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV88FromDate = DateTime.MinValue;
               AssignAttri("", false, "AV88FromDate", context.localUtil.Format(AV88FromDate, "99/99/99"));
            }
            else
            {
               AV88FromDate = context.localUtil.CToD( cgiGet( edtavFromdate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV88FromDate", context.localUtil.Format(AV88FromDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTodate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "To Date", "")}), 1, "vTODATE");
               GX_FocusControl = edtavTodate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV89ToDate = DateTime.MinValue;
               AssignAttri("", false, "AV89ToDate", context.localUtil.Format(AV89ToDate, "99/99/99"));
            }
            else
            {
               AV89ToDate = context.localUtil.CToD( cgiGet( edtavTodate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV89ToDate", context.localUtil.Format(AV89ToDate, "99/99/99"));
            }
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            AV31DDO_FacturaFechaRegistroAuxDateText = cgiGet( edtavDdo_facturafecharegistroauxdatetext_Internalname);
            AssignAttri("", false, "AV31DDO_FacturaFechaRegistroAuxDateText", AV31DDO_FacturaFechaRegistroAuxDateText);
            AV40DDO_FacturaFechaFacturaAuxDateText = cgiGet( edtavDdo_facturafechafacturaauxdatetext_Internalname);
            AssignAttri("", false, "AV40DDO_FacturaFechaFacturaAuxDateText", AV40DDO_FacturaFechaFacturaAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vFROMDATE"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV88FromDate ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vTODATE"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV89ToDate ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
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
         E193B2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E193B2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV89ToDate = DateTimeUtil.Today( context);
         AssignAttri("", false, "AV89ToDate", context.localUtil.Format(AV89ToDate, "99/99/99"));
         AV88FromDate = DateTimeUtil.AddMth( AV89ToDate, -3);
         AssignAttri("", false, "AV88FromDate", context.localUtil.Format(AV88FromDate, "99/99/99"));
         /* Execute user subroutine: 'OBTIENELISTAUSUARIOS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Utchartdoughnut_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPFacturaEstatusFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV88FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV89ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV100ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartdoughnut.SendProperty(context, "", false, Utchartdoughnut_Internalname, "Object", Utchartdoughnut_Objectcall);
         Utchartcolumnline_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPGraficaFacturasPorMesFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV88FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV89ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV100ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartcolumnline.SendProperty(context, "", false, Utchartcolumnline_Internalname, "Object", Utchartcolumnline_Objectcall);
         AV66UsuarioJSON = AV67WebSession.Get(context.GetMessage( "Usuario", ""));
         AV68SDTUsuario.FromJSonString(AV66UsuarioJSON, null);
         AV65UsuarioID = AV68SDTUsuario.gxTpr_Usuarioid;
         AssignAttri("", false, "AV65UsuarioID", StringUtil.LTrimStr( (decimal)(AV65UsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV65UsuarioID), "ZZZZZZZZ9"), context));
         AV72UsuarioRol = AV68SDTUsuario.gxTpr_Usuariorol;
         if ( StringUtil.StrCmp(AV72UsuarioRol, "Participante") == 0 )
         {
            edtavUseraction3_Visible = 1;
            AssignProp("", false, edtavUseraction3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction3_Visible), 5, 0), !bGXsfl_59_Refreshing);
         }
         else
         {
            edtavUseraction3_Visible = 0;
            AssignProp("", false, edtavUseraction3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction3_Visible), 5, 0), !bGXsfl_59_Refreshing);
         }
         Popover_partidas_Gridinternalname = subGrid_Internalname;
         ucPopover_partidas.SendProperty(context, "", false, Popover_partidas_Internalname, "GridInternalName", Popover_partidas_Gridinternalname);
         Popover_partidas_Iteminternalname = edtavPartidaswithtags_Internalname;
         ucPopover_partidas.SendProperty(context, "", false, Popover_partidas_Internalname, "ItemInternalName", Popover_partidas_Iteminternalname);
         this.executeUsercontrolMethod("", false, "TFFACTURAFECHAFACTURA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_facturafechafacturaauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFFACTURAFECHAREGISTRO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_facturafecharegistroauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Factura", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
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
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV57DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV57DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E203B2( )
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
         AV66UsuarioJSON = AV67WebSession.Get(context.GetMessage( "Usuario", ""));
         AV68SDTUsuario.FromJSonString(AV66UsuarioJSON, null);
         AV65UsuarioID = AV68SDTUsuario.gxTpr_Usuarioid;
         AssignAttri("", false, "AV65UsuarioID", StringUtil.LTrimStr( (decimal)(AV65UsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV65UsuarioID), "ZZZZZZZZ9"), context));
         AV72UsuarioRol = AV68SDTUsuario.gxTpr_Usuariorol;
         if ( StringUtil.StrCmp(AV72UsuarioRol, "Participante") == 0 )
         {
            edtavUseraction3_Visible = 1;
            AssignProp("", false, edtavUseraction3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction3_Visible), 5, 0), !bGXsfl_59_Refreshing);
         }
         else
         {
            edtavUseraction3_Visible = 0;
            AssignProp("", false, edtavUseraction3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction3_Visible), 5, 0), !bGXsfl_59_Refreshing);
         }
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV24ManageFiltersExecutionStep == 1 )
         {
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV24ManageFiltersExecutionStep == 2 )
         {
            AV24ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
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
         if ( StringUtil.StrCmp(AV21Session.Get("WPFacturasPartColumnsSelector"), "") != 0 )
         {
            AV17ColumnsSelectorXML = AV21Session.Get("WPFacturasPartColumnsSelector");
            AV19ColumnsSelector.FromXml(AV17ColumnsSelectorXML, null, "", "");
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
         edtFacturaFechaRegistro_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtFacturaFechaRegistro_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaFechaRegistro_Visible), 5, 0), !bGXsfl_59_Refreshing);
         edtPromocionDescripcion_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPromocionDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPromocionDescripcion_Visible), 5, 0), !bGXsfl_59_Refreshing);
         edtFacturaNo_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtFacturaNo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaNo_Visible), 5, 0), !bGXsfl_59_Refreshing);
         edtFacturaFechaFactura_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtFacturaFechaFactura_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaFechaFactura_Visible), 5, 0), !bGXsfl_59_Refreshing);
         edtavPartidaswithtags_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavPartidaswithtags_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPartidaswithtags_Visible), 5, 0), !bGXsfl_59_Refreshing);
         edtavEstatuswithtags_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavEstatuswithtags_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEstatuswithtags_Visible), 5, 0), !bGXsfl_59_Refreshing);
         edtavDescripcion_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDescripcion_Visible), 5, 0), !bGXsfl_59_Refreshing);
         edtUsuarioNombreCompleto_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtUsuarioNombreCompleto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombreCompleto_Visible), 5, 0), !bGXsfl_59_Refreshing);
         edtavDistribuidordescripcion_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV19ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavDistribuidordescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDistribuidordescripcion_Visible), 5, 0), !bGXsfl_59_Refreshing);
         AV60GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV60GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV60GridCurrentPage), 10, 0));
         AV61GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV61GridPageCount", StringUtil.LTrimStr( (decimal)(AV61GridPageCount), 10, 0));
         GXt_char2 = AV62GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV101Pgmname, out  GXt_char2) ;
         AV62GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV62GridAppliedFilters", AV62GridAppliedFilters);
         AV102Wpfacturaspartds_1_filterfulltext = AV15FilterFullText;
         AV103Wpfacturaspartds_2_tffacturafecharegistro = AV27TFFacturaFechaRegistro;
         AV104Wpfacturaspartds_3_tffacturafecharegistro_to = AV28TFFacturaFechaRegistro_To;
         AV105Wpfacturaspartds_4_tfpromociondescripcion = AV32TFPromocionDescripcion;
         AV106Wpfacturaspartds_5_tfpromociondescripcion_sel = AV33TFPromocionDescripcion_Sel;
         AV107Wpfacturaspartds_6_tffacturano = AV34TFFacturaNo;
         AV108Wpfacturaspartds_7_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV109Wpfacturaspartds_8_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV110Wpfacturaspartds_9_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV111Wpfacturaspartds_10_tfestatus = AV41TFEstatus;
         AV112Wpfacturaspartds_11_tfestatusoperator = AV42TFEstatusOperator;
         AV113Wpfacturaspartds_12_tfusuarionombrecompleto = AV53TFUsuarioNombreCompleto;
         AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel = AV54TFUsuarioNombreCompleto_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV100ListaUsuarios", AV100ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E123B2( )
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
            AV59PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV59PageToGo) ;
         }
      }

      protected void E133B2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E143B2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
               AV27TFFacturaFechaRegistro = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV27TFFacturaFechaRegistro", context.localUtil.Format(AV27TFFacturaFechaRegistro, "99/99/99"));
               AV28TFFacturaFechaRegistro_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV28TFFacturaFechaRegistro_To", context.localUtil.Format(AV28TFFacturaFechaRegistro_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PromocionDescripcion") == 0 )
            {
               AV32TFPromocionDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV32TFPromocionDescripcion", AV32TFPromocionDescripcion);
               AV33TFPromocionDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV33TFPromocionDescripcion_Sel", AV33TFPromocionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaNo") == 0 )
            {
               AV34TFFacturaNo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV34TFFacturaNo", AV34TFFacturaNo);
               AV35TFFacturaNo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV35TFFacturaNo_Sel", AV35TFFacturaNo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaFechaFactura") == 0 )
            {
               AV36TFFacturaFechaFactura = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV36TFFacturaFechaFactura", context.localUtil.Format(AV36TFFacturaFechaFactura, "99/99/99"));
               AV37TFFacturaFechaFactura_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV37TFFacturaFechaFactura_To", context.localUtil.Format(AV37TFFacturaFechaFactura_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Estatus") == 0 )
            {
               if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "1") == 0 )
               {
                  AV42TFEstatusOperator = 1;
                  AssignAttri("", false, "AV42TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV42TFEstatusOperator), 4, 0));
                  AV41TFEstatus = "";
                  AssignAttri("", false, "AV41TFEstatus", AV41TFEstatus);
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "2") == 0 )
               {
                  AV42TFEstatusOperator = 2;
                  AssignAttri("", false, "AV42TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV42TFEstatusOperator), 4, 0));
                  AV41TFEstatus = "";
                  AssignAttri("", false, "AV41TFEstatus", AV41TFEstatus);
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "3") == 0 )
               {
                  AV42TFEstatusOperator = 3;
                  AssignAttri("", false, "AV42TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV42TFEstatusOperator), 4, 0));
                  AV41TFEstatus = "";
                  AssignAttri("", false, "AV41TFEstatus", AV41TFEstatus);
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "4") == 0 )
               {
                  AV42TFEstatusOperator = 4;
                  AssignAttri("", false, "AV42TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV42TFEstatusOperator), 4, 0));
                  AV41TFEstatus = "";
                  AssignAttri("", false, "AV41TFEstatus", AV41TFEstatus);
               }
               else
               {
                  AV42TFEstatusOperator = 0;
                  AssignAttri("", false, "AV42TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV42TFEstatusOperator), 4, 0));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioNombreCompleto") == 0 )
            {
               AV53TFUsuarioNombreCompleto = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV53TFUsuarioNombreCompleto", AV53TFUsuarioNombreCompleto);
               AV54TFUsuarioNombreCompleto_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV54TFUsuarioNombreCompleto_Sel", AV54TFUsuarioNombreCompleto_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E213B2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
         {
            AV74Descripcion = A20MotivoRechazoDescripcion;
            AssignAttri("", false, edtavDescripcion_Internalname, AV74Descripcion);
         }
         else
         {
            AV74Descripcion = context.GetMessage( "NA", "");
            AssignAttri("", false, edtavDescripcion_Internalname, AV74Descripcion);
         }
         AV81Partidas = context.GetMessage( "Partidas", "");
         AssignAttri("", false, edtavPartidas_Internalname, AV81Partidas);
         AV83RegUsuarioID = A29UsuarioID;
         AssignAttri("", false, "AV83RegUsuarioID", StringUtil.LTrimStr( (decimal)(AV83RegUsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vREGUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV83RegUsuarioID), "ZZZZZZZZ9"), context));
         /* Execute user subroutine: 'OBTIENEDISTRIBUIDOR' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         edtavUseraction4_gximage = "iconoPDF";
         AV69UserAction4 = context.GetImagePath( "b97efd0f-8d9d-4227-92c4-9cbec8912646", "", context.GetTheme( ));
         AssignAttri("", false, edtavUseraction4_Internalname, AV69UserAction4);
         AV115Useraction4_GXI = GXDbFile.PathToUrl( context.GetImagePath( "b97efd0f-8d9d-4227-92c4-9cbec8912646", "", context.GetTheme( )), context);
         edtavUseraction4_Tooltiptext = "";
         AV77UserAction8 = "<i class=\"IconoEditarAzul fas fa-magnifying-glass\"></i>";
         AssignAttri("", false, edtavUseraction8_Internalname, AV77UserAction8);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpdetallefactura.aspx"+UrlEncode(StringUtil.LTrimStr(A69FacturaID,9,0));
         edtavUseraction8_Link = formatLink("wpdetallefactura.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV75UserAction3 = context.GetMessage( "Cancelar factura", "");
         AssignAttri("", false, edtavUseraction3_Internalname, AV75UserAction3);
         GXt_char2 = AV82PartidasWithTags;
         new WorkWithPlus.workwithplus_web.wwp_encodehtml(context ).execute(  AV81Partidas, out  GXt_char2) ;
         AV82PartidasWithTags = GXt_char2;
         AssignAttri("", false, edtavPartidaswithtags_Internalname, AV82PartidasWithTags);
         AV82PartidasWithTags += "<i class='WWPPopoverIcon FontColorIcon fas fa-angle-down'></i>";
         AssignAttri("", false, edtavPartidaswithtags_Internalname, AV82PartidasWithTags);
         GXt_char2 = AV58EstatusWithTags;
         new WorkWithPlus.workwithplus_web.wwp_encodehtml(context ).execute(  AV16Estatus, out  GXt_char2) ;
         AV58EstatusWithTags = GXt_char2;
         AssignAttri("", false, edtavEstatuswithtags_Internalname, AV58EstatusWithTags);
         if ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 )
         {
            AV58EstatusWithTags += StringUtil.Format( "<span class='AttributeTagWarning TagAfterText'>%1</span>", context.GetMessage( "En proceso", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavEstatuswithtags_Internalname, AV58EstatusWithTags);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 )
         {
            AV58EstatusWithTags += StringUtil.Format( "<span class='AttributeTagSuccess TagAfterText'>%1</span>", context.GetMessage( "Aprobada", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavEstatuswithtags_Internalname, AV58EstatusWithTags);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
         {
            AV58EstatusWithTags += StringUtil.Format( "<span class='AttributeTagDanger TagAfterText'>%1</span>", context.GetMessage( "Rechazada", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavEstatuswithtags_Internalname, AV58EstatusWithTags);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Cancelada") == 0 )
         {
            AV58EstatusWithTags += StringUtil.Format( "<span class='AttributeTagInfo TagAfterText'>%1</span>", context.GetMessage( "Cancelada", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavEstatuswithtags_Internalname, AV58EstatusWithTags);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 59;
         }
         sendrow_592( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_59_Refreshing )
         {
            DoAjaxLoad(59, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E153B2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV17ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV19ColumnsSelector.FromJSonString(AV17ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WPFacturasPartColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV17ColumnsSelectorXML)) ? "" : AV19ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV100ListaUsuarios", AV100ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E113B2( )
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
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WPFacturasPartFilters")) + "," + UrlEncode(StringUtil.RTrim(AV101Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WPFacturasPartFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV24ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV24ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV24ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV23ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WPFacturasPartFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV23ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23ManageFiltersXml)) )
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
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV101Pgmname+"GridState",  AV23ManageFiltersXml) ;
               AV10GridState.FromXml(AV23ManageFiltersXml, null, "", "");
               AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
               AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV100ListaUsuarios", AV100ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
      }

      protected void E163B2( )
      {
         /* Dvelop_confirmpanel_useraction3_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useraction3_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO USERACTION3' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV100ListaUsuarios", AV100ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E173B2( )
      {
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         AV80PromocionID = 0;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpfacturawizard.aspx"+UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.BoolToStr(false));
         CallWebObject(formatLink("wpfacturawizard.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV100ListaUsuarios", AV100ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E183B2( )
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
         Utchartdoughnut_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPFacturaEstatusFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV88FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV89ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV100ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartdoughnut.SendProperty(context, "", false, Utchartdoughnut_Internalname, "Object", Utchartdoughnut_Objectcall);
         Utchartcolumnline_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPGraficaFacturasPorMesFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV88FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV89ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV100ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartcolumnline.SendProperty(context, "", false, Utchartcolumnline_Internalname, "Object", Utchartcolumnline_Objectcall);
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV88FromDate, AV89ToDate, AV15FilterFullText, AV24ManageFiltersExecutionStep, AV19ColumnsSelector, AV101Pgmname, AV27TFFacturaFechaRegistro, AV28TFFacturaFechaRegistro_To, AV32TFPromocionDescripcion, AV33TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV41TFEstatus, AV42TFEstatusOperator, AV53TFUsuarioNombreCompleto, AV54TFUsuarioNombreCompleto_Sel, AV65UsuarioID, AV16Estatus, AV83RegUsuarioID, A11DistribuidorDescripcion) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV100ListaUsuarios", AV100ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ColumnsSelector", AV19ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E223B2( )
      {
         /* Partidas_Click Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0099",(string)"",(int)A69FacturaID});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0099"+"");
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
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV19ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "FacturaFechaRegistro",  "",  "Fecha Registro",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "PromocionDescripcion",  "",  "Nom. Promoción",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "FacturaNo",  "",  "No. Factura",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "FacturaFechaFactura",  "",  "Fecha Factura",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "&Partidas",  "",  "Partidas",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "&Estatus",  "",  "Estatus",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "&Descripcion",  "",  "Motivo de rechazo",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "UsuarioNombreCompleto",  "",  "Nombre completo",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV19ColumnsSelector,  "&DistribuidorDescripcion",  "",  "Distribuidor al que representa",  true,  "") ;
         GXt_char2 = AV18UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WPFacturasPartColumnsSelector", out  GXt_char2) ;
         AV18UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV18UserCustomValue)) ) )
         {
            AV20ColumnsSelectorAux.FromXml(AV18UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV20ColumnsSelectorAux, ref  AV19ColumnsSelector) ;
         }
      }

      protected void S122( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV22ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WPFacturasPartFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV22ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S192( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV27TFFacturaFechaRegistro = DateTime.MinValue;
         AssignAttri("", false, "AV27TFFacturaFechaRegistro", context.localUtil.Format(AV27TFFacturaFechaRegistro, "99/99/99"));
         AV28TFFacturaFechaRegistro_To = DateTime.MinValue;
         AssignAttri("", false, "AV28TFFacturaFechaRegistro_To", context.localUtil.Format(AV28TFFacturaFechaRegistro_To, "99/99/99"));
         AV32TFPromocionDescripcion = "";
         AssignAttri("", false, "AV32TFPromocionDescripcion", AV32TFPromocionDescripcion);
         AV33TFPromocionDescripcion_Sel = "";
         AssignAttri("", false, "AV33TFPromocionDescripcion_Sel", AV33TFPromocionDescripcion_Sel);
         AV34TFFacturaNo = "";
         AssignAttri("", false, "AV34TFFacturaNo", AV34TFFacturaNo);
         AV35TFFacturaNo_Sel = "";
         AssignAttri("", false, "AV35TFFacturaNo_Sel", AV35TFFacturaNo_Sel);
         AV36TFFacturaFechaFactura = DateTime.MinValue;
         AssignAttri("", false, "AV36TFFacturaFechaFactura", context.localUtil.Format(AV36TFFacturaFechaFactura, "99/99/99"));
         AV37TFFacturaFechaFactura_To = DateTime.MinValue;
         AssignAttri("", false, "AV37TFFacturaFechaFactura_To", context.localUtil.Format(AV37TFFacturaFechaFactura_To, "99/99/99"));
         AV42TFEstatusOperator = 0;
         AssignAttri("", false, "AV42TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV42TFEstatusOperator), 4, 0));
         Ddo_grid_Selectedfixedfilter = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
         AV53TFUsuarioNombreCompleto = "";
         AssignAttri("", false, "AV53TFUsuarioNombreCompleto", AV53TFUsuarioNombreCompleto);
         AV54TFUsuarioNombreCompleto_Sel = "";
         AssignAttri("", false, "AV54TFUsuarioNombreCompleto_Sel", AV54TFUsuarioNombreCompleto_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S212( )
      {
         /* 'DO USERACTION3' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Cancelada") == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "La factura ya ha sido cancelada", ""));
         }
         else if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "No se puede cancelar la factura porque ya ha sido rechazada", ""));
         }
         else if ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "No se puede cancelar la factura porque ya ha sido aprobada", ""));
         }
         else if ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 )
         {
            new cancelarfactura(context ).execute(  AV73FacturaID_Selected) ;
            context.DoAjaxRefresh();
         }
      }

      protected void S142( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV21Session.Get(AV101Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV101Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV21Session.Get(AV101Pgmname+"GridState"), null, "", "");
         }
         AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S202( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV116GXV1 = 1;
         while ( AV116GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV116GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAREGISTRO") == 0 )
            {
               AV27TFFacturaFechaRegistro = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV27TFFacturaFechaRegistro", context.localUtil.Format(AV27TFFacturaFechaRegistro, "99/99/99"));
               AV28TFFacturaFechaRegistro_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV28TFFacturaFechaRegistro_To", context.localUtil.Format(AV28TFFacturaFechaRegistro_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION") == 0 )
            {
               AV32TFPromocionDescripcion = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFPromocionDescripcion", AV32TFPromocionDescripcion);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION_SEL") == 0 )
            {
               AV33TFPromocionDescripcion_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFPromocionDescripcion_Sel", AV33TFPromocionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURANO") == 0 )
            {
               AV34TFFacturaNo = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFFacturaNo", AV34TFFacturaNo);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURANO_SEL") == 0 )
            {
               AV35TFFacturaNo_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFFacturaNo_Sel", AV35TFFacturaNo_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAFACTURA") == 0 )
            {
               AV36TFFacturaFechaFactura = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV36TFFacturaFechaFactura", context.localUtil.Format(AV36TFFacturaFechaFactura, "99/99/99"));
               AV37TFFacturaFechaFactura_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV37TFFacturaFechaFactura_To", context.localUtil.Format(AV37TFFacturaFechaFactura_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFESTATUS") == 0 )
            {
               AV42TFEstatusOperator = AV11GridStateFilterValue.gxTpr_Operator;
               AssignAttri("", false, "AV42TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV42TFEstatusOperator), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO") == 0 )
            {
               AV53TFUsuarioNombreCompleto = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV53TFUsuarioNombreCompleto", AV53TFUsuarioNombreCompleto);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO_SEL") == 0 )
            {
               AV54TFUsuarioNombreCompleto_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFUsuarioNombreCompleto_Sel", AV54TFUsuarioNombreCompleto_Sel);
            }
            AV116GXV1 = (int)(AV116GXV1+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFPromocionDescripcion_Sel)),  AV33TFPromocionDescripcion_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFFacturaNo_Sel)),  AV35TFFacturaNo_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFUsuarioNombreCompleto_Sel)),  AV54TFUsuarioNombreCompleto_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char4+"|||||"+GXt_char5+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFPromocionDescripcion)),  AV32TFPromocionDescripcion, out  GXt_char5) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFFacturaNo)),  AV34TFFacturaNo, out  GXt_char4) ;
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV53TFUsuarioNombreCompleto)),  AV53TFUsuarioNombreCompleto, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((DateTime.MinValue==AV27TFFacturaFechaRegistro) ? "" : context.localUtil.DToC( AV27TFFacturaFechaRegistro, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+GXt_char5+"|"+GXt_char4+"|"+((DateTime.MinValue==AV36TFFacturaFechaFactura) ? "" : context.localUtil.DToC( AV36TFFacturaFechaFactura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"||||"+GXt_char2+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((DateTime.MinValue==AV28TFFacturaFechaRegistro_To) ? "" : context.localUtil.DToC( AV28TFFacturaFechaRegistro_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|||"+((DateTime.MinValue==AV37TFFacturaFechaFactura_To) ? "" : context.localUtil.DToC( AV37TFFacturaFechaFactura_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         Ddo_grid_Selectedfixedfilter = "|||||"+((AV42TFEstatusOperator!=1) ? "" : "1")+((AV42TFEstatusOperator!=2) ? "" : "2")+((AV42TFEstatusOperator!=3) ? "" : "3")+((AV42TFEstatusOperator!=4) ? "" : "4")+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV21Session.Get(AV101Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFACTURAFECHAREGISTRO",  context.GetMessage( "Fecha Registro", ""),  !((DateTime.MinValue==AV27TFFacturaFechaRegistro)&&(DateTime.MinValue==AV28TFFacturaFechaRegistro_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV27TFFacturaFechaRegistro, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV27TFFacturaFechaRegistro) ? "" : StringUtil.Trim( context.localUtil.Format( AV27TFFacturaFechaRegistro, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV28TFFacturaFechaRegistro_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV28TFFacturaFechaRegistro_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV28TFFacturaFechaRegistro_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROMOCIONDESCRIPCION",  context.GetMessage( "Nom. Promoción", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFPromocionDescripcion)),  0,  AV32TFPromocionDescripcion,  AV32TFPromocionDescripcion,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFPromocionDescripcion_Sel)),  AV33TFPromocionDescripcion_Sel,  AV33TFPromocionDescripcion_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFFACTURANO",  context.GetMessage( "No. Factura", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFFacturaNo)),  0,  AV34TFFacturaNo,  AV34TFFacturaNo,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFFacturaNo_Sel)),  AV35TFFacturaNo_Sel,  AV35TFFacturaNo_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFACTURAFECHAFACTURA",  context.GetMessage( "Fecha Factura", ""),  !((DateTime.MinValue==AV36TFFacturaFechaFactura)&&(DateTime.MinValue==AV37TFFacturaFechaFactura_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV36TFFacturaFechaFactura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV36TFFacturaFechaFactura) ? "" : StringUtil.Trim( context.localUtil.Format( AV36TFFacturaFechaFactura, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV37TFFacturaFechaFactura_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV37TFFacturaFechaFactura_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV37TFFacturaFechaFactura_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFESTATUS",  context.GetMessage( "Estatus", ""),  !(String.IsNullOrEmpty(StringUtil.RTrim( AV41TFEstatus))&&(0==AV42TFEstatusOperator)),  AV42TFEstatusOperator,  AV41TFEstatus,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV42TFEstatusOperator+1), 10, 0)), AV41TFEstatus, context.GetMessage( "En proceso", ""), context.GetMessage( "Aprobada", ""), context.GetMessage( "Rechazada", ""), context.GetMessage( "Cancelada", ""), "", "", "", ""),  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFUSUARIONOMBRECOMPLETO",  context.GetMessage( "Nombre completo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV53TFUsuarioNombreCompleto)),  0,  AV53TFUsuarioNombreCompleto,  AV53TFUsuarioNombreCompleto,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFUsuarioNombreCompleto_Sel)),  AV54TFUsuarioNombreCompleto_Sel,  AV54TFUsuarioNombreCompleto_Sel) ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV101Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S132( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV101Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Factura";
         AV21Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void E233B2( )
      {
         /* Useraction4_Click Routine */
         returnInSub = false;
         AV87FacturaID = A69FacturaID;
         AssignAttri("", false, "AV87FacturaID", StringUtil.LTrimStr( (decimal)(AV87FacturaID), 9, 0));
         /* Execute user subroutine: 'OBTIENEPDF' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV86FileURL = context.PathToUrl( AV85Blob);
         Innwewindow_Target = AV86FileURL;
         ucInnwewindow.SendProperty(context, "", false, Innwewindow_Internalname, "Target", Innwewindow_Target);
         this.executeUsercontrolMethod("", false, "INNWEWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void S182( )
      {
         /* 'OBTIENEDISTRIBUIDOR' Routine */
         returnInSub = false;
         /* Using cursor H003B4 */
         pr_default.execute(2, new Object[] {AV83RegUsuarioID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A10DistribuidorID = H003B4_A10DistribuidorID[0];
            A29UsuarioID = H003B4_A29UsuarioID[0];
            A11DistribuidorDescripcion = H003B4_A11DistribuidorDescripcion[0];
            A11DistribuidorDescripcion = H003B4_A11DistribuidorDescripcion[0];
            AV84DistribuidorDescripcion = A11DistribuidorDescripcion;
            AssignAttri("", false, edtavDistribuidordescripcion_Internalname, AV84DistribuidorDescripcion);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S222( )
      {
         /* 'OBTIENEPDF' Routine */
         returnInSub = false;
         /* Using cursor H003B5 */
         pr_default.execute(3, new Object[] {AV87FacturaID});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A69FacturaID = H003B5_A69FacturaID[0];
            A40000FacturaPDF_GXI = H003B5_A40000FacturaPDF_GXI[0];
            A75FacturaPDF = H003B5_A75FacturaPDF[0];
            AV85Blob = A75FacturaPDF;
            AssignAttri("", false, "AV85Blob", AV85Blob);
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
         AV100ListaUsuarios.Clear();
         AV100ListaUsuarios.Add(AV65UsuarioID, 0);
      }

      protected void wb_table1_92_3B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_useraction3_Internalname, tblTabledvelop_confirmpanel_useraction3_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_useraction3.SetProperty("Title", Dvelop_confirmpanel_useraction3_Title);
            ucDvelop_confirmpanel_useraction3.SetProperty("ConfirmationText", Dvelop_confirmpanel_useraction3_Confirmationtext);
            ucDvelop_confirmpanel_useraction3.SetProperty("YesButtonCaption", Dvelop_confirmpanel_useraction3_Yesbuttoncaption);
            ucDvelop_confirmpanel_useraction3.SetProperty("NoButtonCaption", Dvelop_confirmpanel_useraction3_Nobuttoncaption);
            ucDvelop_confirmpanel_useraction3.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_useraction3_Cancelbuttoncaption);
            ucDvelop_confirmpanel_useraction3.SetProperty("YesButtonPosition", Dvelop_confirmpanel_useraction3_Yesbuttonposition);
            ucDvelop_confirmpanel_useraction3.SetProperty("ConfirmType", Dvelop_confirmpanel_useraction3_Confirmtype);
            ucDvelop_confirmpanel_useraction3.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_useraction3_Internalname, "DVELOP_CONFIRMPANEL_USERACTION3Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_USERACTION3Container"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_92_3B2e( true) ;
         }
         else
         {
            wb_table1_92_3B2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA3B2( ) ;
         WS3B2( ) ;
         WE3B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20265111131151", true, true);
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
         context.AddJavascriptSource("wpfacturaspart.js", "?20265111131152", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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

      protected void SubsflControlProps_592( )
      {
         edtFacturaID_Internalname = "FACTURAID_"+sGXsfl_59_idx;
         edtavUseraction4_Internalname = "vUSERACTION4_"+sGXsfl_59_idx;
         edtavUseraction8_Internalname = "vUSERACTION8_"+sGXsfl_59_idx;
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO_"+sGXsfl_59_idx;
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION_"+sGXsfl_59_idx;
         edtFacturaNo_Internalname = "FACTURANO_"+sGXsfl_59_idx;
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA_"+sGXsfl_59_idx;
         edtavPartidaswithtags_Internalname = "vPARTIDASWITHTAGS_"+sGXsfl_59_idx;
         edtavPartidas_Internalname = "vPARTIDAS_"+sGXsfl_59_idx;
         edtavUseraction3_Internalname = "vUSERACTION3_"+sGXsfl_59_idx;
         edtavEstatuswithtags_Internalname = "vESTATUSWITHTAGS_"+sGXsfl_59_idx;
         edtavEstatus_Internalname = "vESTATUS_"+sGXsfl_59_idx;
         edtavDescripcion_Internalname = "vDESCRIPCION_"+sGXsfl_59_idx;
         cmbFacturaEstatus_Internalname = "FACTURAESTATUS_"+sGXsfl_59_idx;
         edtUsuarioID_Internalname = "USUARIOID_"+sGXsfl_59_idx;
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO_"+sGXsfl_59_idx;
         chkMotivoRechazoActivo_Internalname = "MOTIVORECHAZOACTIVO_"+sGXsfl_59_idx;
         edtMotivoRechazoDescripcion_Internalname = "MOTIVORECHAZODESCRIPCION_"+sGXsfl_59_idx;
         edtMotivoRechazoID_Internalname = "MOTIVORECHAZOID_"+sGXsfl_59_idx;
         edtavDistribuidordescripcion_Internalname = "vDISTRIBUIDORDESCRIPCION_"+sGXsfl_59_idx;
      }

      protected void SubsflControlProps_fel_592( )
      {
         edtFacturaID_Internalname = "FACTURAID_"+sGXsfl_59_fel_idx;
         edtavUseraction4_Internalname = "vUSERACTION4_"+sGXsfl_59_fel_idx;
         edtavUseraction8_Internalname = "vUSERACTION8_"+sGXsfl_59_fel_idx;
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO_"+sGXsfl_59_fel_idx;
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION_"+sGXsfl_59_fel_idx;
         edtFacturaNo_Internalname = "FACTURANO_"+sGXsfl_59_fel_idx;
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA_"+sGXsfl_59_fel_idx;
         edtavPartidaswithtags_Internalname = "vPARTIDASWITHTAGS_"+sGXsfl_59_fel_idx;
         edtavPartidas_Internalname = "vPARTIDAS_"+sGXsfl_59_fel_idx;
         edtavUseraction3_Internalname = "vUSERACTION3_"+sGXsfl_59_fel_idx;
         edtavEstatuswithtags_Internalname = "vESTATUSWITHTAGS_"+sGXsfl_59_fel_idx;
         edtavEstatus_Internalname = "vESTATUS_"+sGXsfl_59_fel_idx;
         edtavDescripcion_Internalname = "vDESCRIPCION_"+sGXsfl_59_fel_idx;
         cmbFacturaEstatus_Internalname = "FACTURAESTATUS_"+sGXsfl_59_fel_idx;
         edtUsuarioID_Internalname = "USUARIOID_"+sGXsfl_59_fel_idx;
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO_"+sGXsfl_59_fel_idx;
         chkMotivoRechazoActivo_Internalname = "MOTIVORECHAZOACTIVO_"+sGXsfl_59_fel_idx;
         edtMotivoRechazoDescripcion_Internalname = "MOTIVORECHAZODESCRIPCION_"+sGXsfl_59_fel_idx;
         edtMotivoRechazoID_Internalname = "MOTIVORECHAZOID_"+sGXsfl_59_fel_idx;
         edtavDistribuidordescripcion_Internalname = "vDISTRIBUIDORDESCRIPCION_"+sGXsfl_59_fel_idx;
      }

      protected void sendrow_592( )
      {
         sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
         SubsflControlProps_592( ) ;
         WB3B0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_59_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_59_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_59_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',59)\"";
            ClassString = "BotonImagenChica" + " " + ((StringUtil.StrCmp(edtavUseraction4_gximage, "")==0) ? "" : "GX_Image_"+edtavUseraction4_gximage+"_Class");
            StyleString = "";
            AV69UserAction4_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV69UserAction4))&&String.IsNullOrEmpty(StringUtil.RTrim( AV115Useraction4_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV69UserAction4)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV69UserAction4)) ? AV115Useraction4_GXI : context.PathToRelativeUrl( AV69UserAction4));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseraction4_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)edtavUseraction4_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavUseraction4_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVUSERACTION4.CLICK."+sGXsfl_59_idx+"'",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV69UserAction4_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_59_idx + "',59)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseraction8_Internalname,StringUtil.RTrim( AV77UserAction8),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUseraction8_Link,(string)"",(string)"",(string)"",(string)edtavUseraction8_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUseraction8_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtFacturaFechaRegistro_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaRegistro_Internalname,context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"),context.localUtil.Format( A72FacturaFechaRegistro, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaRegistro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtFacturaFechaRegistro_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPromocionDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionDescripcion_Internalname,(string)A42PromocionDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPromocionDescripcion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtFacturaNo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaNo_Internalname,StringUtil.RTrim( A71FacturaNo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaNo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtFacturaNo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtFacturaFechaFactura_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaFactura_Internalname,context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"),context.localUtil.Format( A73FacturaFechaFactura, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaFactura_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtFacturaFechaFactura_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavPartidaswithtags_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_59_idx + "',59)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPartidaswithtags_Internalname,(string)AV82PartidasWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPartidaswithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnSizeLarge ColumnWeightBold ColumnHighlightBackground ColumnLeftDivision",(string)"",(int)edtavPartidaswithtags_Visible,(int)edtavPartidaswithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPartidas_Internalname,StringUtil.RTrim( AV81Partidas),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ","'"+""+"'"+",false,"+"'"+"EVPARTIDAS.CLICK."+sGXsfl_59_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPartidas_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnSizeLarge ColumnWeightBold ColumnHighlightBackground ColumnLeftDivision",(string)"",(short)0,(int)edtavPartidas_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUseraction3_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_59_idx + "',59)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseraction3_Internalname,StringUtil.RTrim( AV75UserAction3),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"",(string)"'"+""+"'"+",false,"+"'"+"e243b2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUseraction3_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWActionColumn",(string)"",(int)edtavUseraction3_Visible,(int)edtavUseraction3_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavEstatuswithtags_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_59_idx + "',59)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEstatuswithtags_Internalname,(string)AV58EstatusWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEstatuswithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavEstatuswithtags_Visible,(int)edtavEstatuswithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEstatus_Internalname,StringUtil.RTrim( AV16Estatus),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEstatus_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavEstatus_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_59_idx + "',59)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDescripcion_Internalname,(string)AV74Descripcion,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavDescripcion_Visible,(int)edtavDescripcion_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbFacturaEstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "FACTURAESTATUS_" + sGXsfl_59_idx;
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
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbFacturaEstatus,(string)cmbFacturaEstatus_Internalname,StringUtil.RTrim( A80FacturaEstatus),(short)1,(string)cmbFacturaEstatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbFacturaEstatus.CurrentValue = StringUtil.RTrim( A80FacturaEstatus);
            AssignProp("", false, cmbFacturaEstatus_Internalname, "Values", (string)(cmbFacturaEstatus.ToJavascriptSource()), !bGXsfl_59_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtUsuarioNombreCompleto_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombreCompleto_Internalname,(string)A52UsuarioNombreCompleto,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombreCompleto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtUsuarioNombreCompleto_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "MOTIVORECHAZOACTIVO_" + sGXsfl_59_idx;
            chkMotivoRechazoActivo.Name = GXCCtl;
            chkMotivoRechazoActivo.WebTags = "";
            chkMotivoRechazoActivo.Caption = "";
            AssignProp("", false, chkMotivoRechazoActivo_Internalname, "TitleCaption", chkMotivoRechazoActivo.Caption, !bGXsfl_59_Refreshing);
            chkMotivoRechazoActivo.CheckedValue = "false";
            A21MotivoRechazoActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A21MotivoRechazoActivo));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkMotivoRechazoActivo_Internalname,StringUtil.BoolToStr( A21MotivoRechazoActivo),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoRechazoDescripcion_Internalname,(string)A20MotivoRechazoDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoRechazoDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoRechazoID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MotivoRechazoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A19MotivoRechazoID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoRechazoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDistribuidordescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_59_idx + "',59)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDistribuidordescripcion_Internalname,(string)AV84DistribuidorDescripcion,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDistribuidordescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavDistribuidordescripcion_Visible,(int)edtavDistribuidordescripcion_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes3B2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_59_idx = ((subGrid_Islastpage==1)&&(nGXsfl_59_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_59_idx+1);
            sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
            SubsflControlProps_592( ) ;
         }
         /* End function sendrow_592 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "FACTURAESTATUS_" + sGXsfl_59_idx;
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
         GXCCtl = "MOTIVORECHAZOACTIVO_" + sGXsfl_59_idx;
         chkMotivoRechazoActivo.Name = GXCCtl;
         chkMotivoRechazoActivo.WebTags = "";
         chkMotivoRechazoActivo.Caption = "";
         AssignProp("", false, chkMotivoRechazoActivo_Internalname, "TitleCaption", chkMotivoRechazoActivo.Caption, !bGXsfl_59_Refreshing);
         chkMotivoRechazoActivo.CheckedValue = "false";
         A21MotivoRechazoActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A21MotivoRechazoActivo));
         /* End function init_web_controls */
      }

      protected void StartGridControl59( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"59\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUseraction3_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
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
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV69UserAction4));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUseraction4_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV77UserAction8)));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV82PartidasWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPartidaswithtags_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPartidaswithtags_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV81Partidas)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPartidas_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV75UserAction3)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction3_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction3_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV58EstatusWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEstatuswithtags_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEstatuswithtags_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV16Estatus)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEstatus_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV74Descripcion));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV84DistribuidorDescripcion));
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
         edtavFromdate_Internalname = "vFROMDATE";
         edtavTodate_Internalname = "vTODATE";
         bttBtnuseraction99_Internalname = "BTNUSERACTION99";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Utchartdoughnut_Internalname = "UTCHARTDOUGHNUT";
         Utchartcolumnline_Internalname = "UTCHARTCOLUMNLINE";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         bttBtnuseraction1_Internalname = "BTNUSERACTION1";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtFacturaID_Internalname = "FACTURAID";
         edtavUseraction4_Internalname = "vUSERACTION4";
         edtavUseraction8_Internalname = "vUSERACTION8";
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO";
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION";
         edtFacturaNo_Internalname = "FACTURANO";
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA";
         edtavPartidaswithtags_Internalname = "vPARTIDASWITHTAGS";
         edtavPartidas_Internalname = "vPARTIDAS";
         edtavUseraction3_Internalname = "vUSERACTION3";
         edtavEstatuswithtags_Internalname = "vESTATUSWITHTAGS";
         edtavEstatus_Internalname = "vESTATUS";
         edtavDescripcion_Internalname = "vDESCRIPCION";
         cmbFacturaEstatus_Internalname = "FACTURAESTATUS";
         edtUsuarioID_Internalname = "USUARIOID";
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO";
         chkMotivoRechazoActivo_Internalname = "MOTIVORECHAZOACTIVO";
         edtMotivoRechazoDescripcion_Internalname = "MOTIVORECHAZODESCRIPCION";
         edtMotivoRechazoID_Internalname = "MOTIVORECHAZOID";
         edtavDistribuidordescripcion_Internalname = "vDISTRIBUIDORDESCRIPCION";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         Innwewindow_Internalname = "INNWEWINDOW";
         divTablemain_Internalname = "TABLEMAIN";
         Popover_partidas_Internalname = "POPOVER_PARTIDAS";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Dvelop_confirmpanel_useraction3_Internalname = "DVELOP_CONFIRMPANEL_USERACTION3";
         tblTabledvelop_confirmpanel_useraction3_Internalname = "TABLEDVELOP_CONFIRMPANEL_USERACTION3";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_facturafecharegistroauxdatetext_Internalname = "vDDO_FACTURAFECHAREGISTROAUXDATETEXT";
         Tffacturafecharegistro_rangepicker_Internalname = "TFFACTURAFECHAREGISTRO_RANGEPICKER";
         divDdo_facturafecharegistroauxdates_Internalname = "DDO_FACTURAFECHAREGISTROAUXDATES";
         edtavDdo_facturafechafacturaauxdatetext_Internalname = "vDDO_FACTURAFECHAFACTURAAUXDATETEXT";
         Tffacturafechafactura_rangepicker_Internalname = "TFFACTURAFECHAFACTURA_RANGEPICKER";
         divDdo_facturafechafacturaauxdates_Internalname = "DDO_FACTURAFECHAFACTURAAUXDATES";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
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
         edtavUseraction3_Jsonclick = "";
         edtavUseraction3_Enabled = 1;
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
         Dvelop_confirmpanel_useraction3_Confirmtype = "1";
         Dvelop_confirmpanel_useraction3_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useraction3_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useraction3_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useraction3_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useraction3_Confirmationtext = "Al cancelar la factura, un administrador no podrá cambiar el estatus de la misma";
         Dvelop_confirmpanel_useraction3_Title = context.GetMessage( "¿Quieres cancelar esta factura?", "");
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Fixedfilters = "|||||1:En proceso:fa fa-circle FontColorIconWarning FontColorIconSmall ConditionalFormattingFilterIcon,2:Aprobada:fa fa-circle FontColorIconSuccess FontColorIconSmall ConditionalFormattingFilterIcon,3:Rechazada:fa fa-circle FontColorIconDanger FontColorIconSmall ConditionalFormattingFilterIcon,4:Cancelada:fa fa-circle FontColorIconInfo FontColorIconSmall ConditionalFormattingFilterIcon|||";
         Ddo_grid_Datalistproc = "WPFacturasPartGetFilterData";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( " Factura", "");
         edtavUseraction3_Visible = -1;
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV88FromDate","fld":"vFROMDATE"},{"av":"AV89ToDate","fld":"vTODATE"},{"av":"edtavUseraction3_Visible","ctrl":"vUSERACTION3","prop":"Visible"},{"av":"AV16Estatus","fld":"vESTATUS","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV101Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV28TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV32TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV33TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFEstatus","fld":"vTFESTATUS"},{"av":"AV42TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV53TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV54TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV65UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV83RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV65UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction3_Visible","ctrl":"vUSERACTION3","prop":"Visible"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcion_Visible","ctrl":"vDISTRIBUIDORDESCRIPCION","prop":"Visible"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV100ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E123B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV88FromDate","fld":"vFROMDATE"},{"av":"AV89ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV101Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV28TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV32TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV33TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFEstatus","fld":"vTFESTATUS"},{"av":"AV42TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV53TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV54TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV65UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction3_Visible","ctrl":"vUSERACTION3","prop":"Visible"},{"av":"AV16Estatus","fld":"vESTATUS","hsh":true},{"av":"AV83RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E133B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV88FromDate","fld":"vFROMDATE"},{"av":"AV89ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV101Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV28TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV32TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV33TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFEstatus","fld":"vTFESTATUS"},{"av":"AV42TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV53TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV54TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV65UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction3_Visible","ctrl":"vUSERACTION3","prop":"Visible"},{"av":"AV16Estatus","fld":"vESTATUS","hsh":true},{"av":"AV83RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E143B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV88FromDate","fld":"vFROMDATE"},{"av":"AV89ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV101Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV28TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV32TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV33TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFEstatus","fld":"vTFESTATUS"},{"av":"AV42TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV53TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV54TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV65UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction3_Visible","ctrl":"vUSERACTION3","prop":"Visible"},{"av":"AV16Estatus","fld":"vESTATUS","hsh":true},{"av":"AV83RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Selectedcolumnfixedfilter","ctrl":"DDO_GRID","prop":"SelectedColumnFixedFilter"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV53TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV54TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV41TFEstatus","fld":"vTFESTATUS"},{"av":"AV42TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV32TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV33TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV27TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV28TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E213B2","iparms":[{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS","hsh":true},{"av":"A20MotivoRechazoDescripcion","fld":"MOTIVORECHAZODESCRIPCION"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV16Estatus","fld":"vESTATUS","hsh":true},{"av":"AV83RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV74Descripcion","fld":"vDESCRIPCION"},{"av":"AV81Partidas","fld":"vPARTIDAS"},{"av":"AV83RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV69UserAction4","fld":"vUSERACTION4"},{"av":"edtavUseraction4_Tooltiptext","ctrl":"vUSERACTION4","prop":"Tooltiptext"},{"av":"AV77UserAction8","fld":"vUSERACTION8"},{"av":"edtavUseraction8_Link","ctrl":"vUSERACTION8","prop":"Link"},{"av":"AV75UserAction3","fld":"vUSERACTION3"},{"av":"AV82PartidasWithTags","fld":"vPARTIDASWITHTAGS"},{"av":"AV58EstatusWithTags","fld":"vESTATUSWITHTAGS"},{"av":"AV84DistribuidorDescripcion","fld":"vDISTRIBUIDORDESCRIPCION"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E153B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV88FromDate","fld":"vFROMDATE"},{"av":"AV89ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV101Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV28TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV32TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV33TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFEstatus","fld":"vTFESTATUS"},{"av":"AV42TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV53TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV54TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV65UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction3_Visible","ctrl":"vUSERACTION3","prop":"Visible"},{"av":"AV16Estatus","fld":"vESTATUS","hsh":true},{"av":"AV83RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV65UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction3_Visible","ctrl":"vUSERACTION3","prop":"Visible"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcion_Visible","ctrl":"vDISTRIBUIDORDESCRIPCION","prop":"Visible"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV100ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E113B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV88FromDate","fld":"vFROMDATE"},{"av":"AV89ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV101Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV28TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV32TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV33TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFEstatus","fld":"vTFESTATUS"},{"av":"AV42TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV53TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV54TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV65UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction3_Visible","ctrl":"vUSERACTION3","prop":"Visible"},{"av":"AV16Estatus","fld":"vESTATUS","hsh":true},{"av":"AV83RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV27TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV28TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV32TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV33TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV42TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"Ddo_grid_Selectedfixedfilter","ctrl":"DDO_GRID","prop":"SelectedFixedFilter"},{"av":"AV53TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV54TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV65UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction3_Visible","ctrl":"vUSERACTION3","prop":"Visible"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcion_Visible","ctrl":"vDISTRIBUIDORDESCRIPCION","prop":"Visible"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV100ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VUSERACTION3.CLICK","""{"handler":"E243B2","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("VUSERACTION3.CLICK",""","oparms":[{"av":"AV73FacturaID_Selected","fld":"vFACTURAID_SELECTED","pic":"ZZZZZZZZ9"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTION3.CLOSE","""{"handler":"E163B2","iparms":[{"av":"Dvelop_confirmpanel_useraction3_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTION3","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV88FromDate","fld":"vFROMDATE"},{"av":"AV89ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV101Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV28TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV32TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV33TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFEstatus","fld":"vTFESTATUS"},{"av":"AV42TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV53TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV54TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV65UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction3_Visible","ctrl":"vUSERACTION3","prop":"Visible"},{"av":"AV16Estatus","fld":"vESTATUS","hsh":true},{"av":"AV83RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS","hsh":true},{"av":"AV73FacturaID_Selected","fld":"vFACTURAID_SELECTED","pic":"ZZZZZZZZ9"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTION3.CLOSE",""","oparms":[{"av":"AV65UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction3_Visible","ctrl":"vUSERACTION3","prop":"Visible"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcion_Visible","ctrl":"vDISTRIBUIDORDESCRIPCION","prop":"Visible"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV100ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOUSERACTION1'","""{"handler":"E173B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV88FromDate","fld":"vFROMDATE"},{"av":"AV89ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV101Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV28TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV32TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV33TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFEstatus","fld":"vTFESTATUS"},{"av":"AV42TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV53TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV54TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV65UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction3_Visible","ctrl":"vUSERACTION3","prop":"Visible"},{"av":"AV16Estatus","fld":"vESTATUS","hsh":true},{"av":"AV83RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"}]""");
         setEventMetadata("'DOUSERACTION1'",""","oparms":[{"av":"AV65UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction3_Visible","ctrl":"vUSERACTION3","prop":"Visible"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcion_Visible","ctrl":"vDISTRIBUIDORDESCRIPCION","prop":"Visible"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV100ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOUSERACTION99'","""{"handler":"E183B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV88FromDate","fld":"vFROMDATE"},{"av":"AV89ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV101Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV27TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV28TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV32TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV33TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFEstatus","fld":"vTFESTATUS"},{"av":"AV42TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV53TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV54TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV65UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction3_Visible","ctrl":"vUSERACTION3","prop":"Visible"},{"av":"AV16Estatus","fld":"vESTATUS","hsh":true},{"av":"AV83RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV100ListaUsuarios","fld":"vLISTAUSUARIOS"}]""");
         setEventMetadata("'DOUSERACTION99'",""","oparms":[{"ctrl":"UTCHARTDOUGHNUT"},{"ctrl":"UTCHARTCOLUMNLINE"},{"av":"AV100ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV65UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"edtavUseraction3_Visible","ctrl":"vUSERACTION3","prop":"Visible"},{"av":"AV24ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV19ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcion_Visible","ctrl":"vDISTRIBUIDORDESCRIPCION","prop":"Visible"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VPARTIDAS.CLICK","""{"handler":"E223B2","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("VPARTIDAS.CLICK",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VUSERACTION4.CLICK","""{"handler":"E233B2","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV85Blob","fld":"vBLOB"},{"av":"AV87FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"A75FacturaPDF","fld":"FACTURAPDF"}]""");
         setEventMetadata("VUSERACTION4.CLICK",""","oparms":[{"av":"AV87FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"Innwewindow_Target","ctrl":"INNWEWINDOW","prop":"Target"},{"av":"AV85Blob","fld":"vBLOB"}]}""");
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
         Dvelop_confirmpanel_useraction3_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV88FromDate = DateTime.MinValue;
         AV89ToDate = DateTime.MinValue;
         AV15FilterFullText = "";
         AV19ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV101Pgmname = "";
         AV27TFFacturaFechaRegistro = DateTime.MinValue;
         AV28TFFacturaFechaRegistro_To = DateTime.MinValue;
         AV32TFPromocionDescripcion = "";
         AV33TFPromocionDescripcion_Sel = "";
         AV34TFFacturaNo = "";
         AV35TFFacturaNo_Sel = "";
         AV36TFFacturaFechaFactura = DateTime.MinValue;
         AV37TFFacturaFechaFactura_To = DateTime.MinValue;
         AV41TFEstatus = "";
         AV53TFUsuarioNombreCompleto = "";
         AV54TFUsuarioNombreCompleto_Sel = "";
         AV16Estatus = "";
         A11DistribuidorDescripcion = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV90Elements = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         AV91Parameters = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter>( context, "Parameter", "GeneXus.Reporting");
         AV92ItemClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData(context);
         AV93ItemDoubleClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData(context);
         AV94DragAndDropData = new GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData(context);
         AV95FilterChangedData = new GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData(context);
         AV96ItemExpandData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData(context);
         AV97ItemCollapseData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData(context);
         AV22ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV62GridAppliedFilters = "";
         AV57DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV30DDO_FacturaFechaRegistroAuxDateTo = DateTime.MinValue;
         AV39DDO_FacturaFechaFacturaAuxDateTo = DateTime.MinValue;
         AV10GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV100ListaUsuarios = new GxSimpleCollection<int>();
         AV85Blob = "";
         A75FacturaPDF = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         AV29DDO_FacturaFechaRegistroAuxDate = DateTime.MinValue;
         AV38DDO_FacturaFechaFacturaAuxDate = DateTime.MinValue;
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
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnuseraction99_Jsonclick = "";
         ucUtchartdoughnut = new GXUserControl();
         ucUtchartcolumnline = new GXUserControl();
         bttBtnuseraction1_Jsonclick = "";
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
         AV31DDO_FacturaFechaRegistroAuxDateText = "";
         ucTffacturafecharegistro_rangepicker = new GXUserControl();
         AV40DDO_FacturaFechaFacturaAuxDateText = "";
         ucTffacturafechafactura_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV69UserAction4 = "";
         AV115Useraction4_GXI = "";
         AV77UserAction8 = "";
         A72FacturaFechaRegistro = DateTime.MinValue;
         A42PromocionDescripcion = "";
         A71FacturaNo = "";
         A73FacturaFechaFactura = DateTime.MinValue;
         AV82PartidasWithTags = "";
         AV81Partidas = "";
         AV75UserAction3 = "";
         AV58EstatusWithTags = "";
         AV74Descripcion = "";
         A80FacturaEstatus = "";
         A52UsuarioNombreCompleto = "";
         A20MotivoRechazoDescripcion = "";
         AV84DistribuidorDescripcion = "";
         lV102Wpfacturaspartds_1_filterfulltext = "";
         lV105Wpfacturaspartds_4_tfpromociondescripcion = "";
         lV107Wpfacturaspartds_6_tffacturano = "";
         lV113Wpfacturaspartds_12_tfusuarionombrecompleto = "";
         AV102Wpfacturaspartds_1_filterfulltext = "";
         AV103Wpfacturaspartds_2_tffacturafecharegistro = DateTime.MinValue;
         AV104Wpfacturaspartds_3_tffacturafecharegistro_to = DateTime.MinValue;
         AV106Wpfacturaspartds_5_tfpromociondescripcion_sel = "";
         AV105Wpfacturaspartds_4_tfpromociondescripcion = "";
         AV108Wpfacturaspartds_7_tffacturano_sel = "";
         AV107Wpfacturaspartds_6_tffacturano = "";
         AV109Wpfacturaspartds_8_tffacturafechafactura = DateTime.MinValue;
         AV110Wpfacturaspartds_9_tffacturafechafactura_to = DateTime.MinValue;
         AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel = "";
         AV113Wpfacturaspartds_12_tfusuarionombrecompleto = "";
         H003B2_A41PromocionID = new int[1] ;
         H003B2_A93FacturaCompleta = new bool[] {false} ;
         H003B2_A19MotivoRechazoID = new int[1] ;
         H003B2_A20MotivoRechazoDescripcion = new string[] {""} ;
         H003B2_A21MotivoRechazoActivo = new bool[] {false} ;
         H003B2_A29UsuarioID = new int[1] ;
         H003B2_A80FacturaEstatus = new string[] {""} ;
         H003B2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         H003B2_A71FacturaNo = new string[] {""} ;
         H003B2_A42PromocionDescripcion = new string[] {""} ;
         H003B2_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         H003B2_A69FacturaID = new int[1] ;
         H003B2_A51UsuarioApellido = new string[] {""} ;
         H003B2_A30UsuarioNombre = new string[] {""} ;
         AV111Wpfacturaspartds_10_tfestatus = "";
         H003B3_AGRID_nRecordCount = new long[1] ;
         AV66UsuarioJSON = "";
         AV67WebSession = context.GetSession();
         AV68SDTUsuario = new SdtSDTUsuario(context);
         AV72UsuarioRol = "";
         AV7HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV21Session = context.GetSession();
         AV17ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV23ManageFiltersXml = "";
         AV18UserCustomValue = "";
         AV20ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV11GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV86FileURL = "";
         H003B4_A81DistribuidoresUsuarioID = new int[1] ;
         H003B4_A10DistribuidorID = new int[1] ;
         H003B4_A29UsuarioID = new int[1] ;
         H003B4_A11DistribuidorDescripcion = new string[] {""} ;
         H003B5_A69FacturaID = new int[1] ;
         H003B5_A40000FacturaPDF_GXI = new string[] {""} ;
         H003B5_A75FacturaPDF = new string[] {""} ;
         A40000FacturaPDF_GXI = "";
         ucDvelop_confirmpanel_useraction3 = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpfacturaspart__default(),
            new Object[][] {
                new Object[] {
               H003B2_A41PromocionID, H003B2_A93FacturaCompleta, H003B2_A19MotivoRechazoID, H003B2_A20MotivoRechazoDescripcion, H003B2_A21MotivoRechazoActivo, H003B2_A29UsuarioID, H003B2_A80FacturaEstatus, H003B2_A73FacturaFechaFactura, H003B2_A71FacturaNo, H003B2_A42PromocionDescripcion,
               H003B2_A72FacturaFechaRegistro, H003B2_A69FacturaID, H003B2_A51UsuarioApellido, H003B2_A30UsuarioNombre
               }
               , new Object[] {
               H003B3_AGRID_nRecordCount
               }
               , new Object[] {
               H003B4_A81DistribuidoresUsuarioID, H003B4_A10DistribuidorID, H003B4_A29UsuarioID, H003B4_A11DistribuidorDescripcion
               }
               , new Object[] {
               H003B5_A69FacturaID, H003B5_A40000FacturaPDF_GXI, H003B5_A75FacturaPDF
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV101Pgmname = "WPFacturasPart";
         /* GeneXus formulas. */
         AV101Pgmname = "WPFacturasPart";
         edtavUseraction8_Enabled = 0;
         edtavPartidaswithtags_Enabled = 0;
         edtavPartidas_Enabled = 0;
         edtavUseraction3_Enabled = 0;
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
      private short AV12OrderedBy ;
      private short AV24ManageFiltersExecutionStep ;
      private short AV42TFEstatusOperator ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV112Wpfacturaspartds_11_tfestatusoperator ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int edtavUseraction3_Visible ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_59 ;
      private int nGXsfl_59_idx=1 ;
      private int AV65UsuarioID ;
      private int AV83RegUsuarioID ;
      private int AV73FacturaID_Selected ;
      private int AV87FacturaID ;
      private int Gridpaginationbar_Pagestoshow ;
      private int Popover_partidas_Popoverwidth ;
      private int edtavFromdate_Enabled ;
      private int edtavTodate_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int A69FacturaID ;
      private int A29UsuarioID ;
      private int A19MotivoRechazoID ;
      private int subGrid_Islastpage ;
      private int edtavUseraction8_Enabled ;
      private int edtavPartidaswithtags_Enabled ;
      private int edtavPartidas_Enabled ;
      private int edtavUseraction3_Enabled ;
      private int edtavEstatuswithtags_Enabled ;
      private int edtavEstatus_Enabled ;
      private int edtavDescripcion_Enabled ;
      private int edtavDistribuidordescripcion_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV100ListaUsuarios_Count ;
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
      private int AV59PageToGo ;
      private int AV80PromocionID ;
      private int AV116GXV1 ;
      private int A10DistribuidorID ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV60GridCurrentPage ;
      private long AV61GridPageCount ;
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
      private string Dvelop_confirmpanel_useraction3_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_59_idx="0001" ;
      private string edtavUseraction3_Internalname ;
      private string AV101Pgmname ;
      private string AV34TFFacturaNo ;
      private string AV35TFFacturaNo_Sel ;
      private string AV41TFEstatus ;
      private string AV16Estatus ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string Dvelop_confirmpanel_useraction3_Title ;
      private string Dvelop_confirmpanel_useraction3_Confirmationtext ;
      private string Dvelop_confirmpanel_useraction3_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useraction3_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useraction3_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useraction3_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useraction3_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Popoversingrid ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divUnnamedtable1_Internalname ;
      private string edtavFromdate_Internalname ;
      private string TempTags ;
      private string edtavFromdate_Jsonclick ;
      private string edtavTodate_Internalname ;
      private string edtavTodate_Jsonclick ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtFacturaID_Internalname ;
      private string edtavUseraction4_Internalname ;
      private string AV77UserAction8 ;
      private string edtavUseraction8_Internalname ;
      private string edtFacturaFechaRegistro_Internalname ;
      private string edtPromocionDescripcion_Internalname ;
      private string A71FacturaNo ;
      private string edtFacturaNo_Internalname ;
      private string edtFacturaFechaFactura_Internalname ;
      private string edtavPartidaswithtags_Internalname ;
      private string AV81Partidas ;
      private string edtavPartidas_Internalname ;
      private string AV75UserAction3 ;
      private string edtavEstatuswithtags_Internalname ;
      private string edtavEstatus_Internalname ;
      private string edtavDescripcion_Internalname ;
      private string cmbFacturaEstatus_Internalname ;
      private string A80FacturaEstatus ;
      private string edtUsuarioID_Internalname ;
      private string edtUsuarioNombreCompleto_Internalname ;
      private string chkMotivoRechazoActivo_Internalname ;
      private string edtMotivoRechazoDescripcion_Internalname ;
      private string edtMotivoRechazoID_Internalname ;
      private string edtavDistribuidordescripcion_Internalname ;
      private string lV107Wpfacturaspartds_6_tffacturano ;
      private string AV108Wpfacturaspartds_7_tffacturano_sel ;
      private string AV107Wpfacturaspartds_6_tffacturano ;
      private string AV111Wpfacturaspartds_10_tfestatus ;
      private string AV72UsuarioRol ;
      private string edtavUseraction4_gximage ;
      private string edtavUseraction4_Tooltiptext ;
      private string edtavUseraction8_Link ;
      private string GXEncryptionTmp ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string tblTabledvelop_confirmpanel_useraction3_Internalname ;
      private string Dvelop_confirmpanel_useraction3_Internalname ;
      private string sGXsfl_59_fel_idx="0001" ;
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
      private string edtavUseraction3_Jsonclick ;
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
      private DateTime AV88FromDate ;
      private DateTime AV89ToDate ;
      private DateTime AV27TFFacturaFechaRegistro ;
      private DateTime AV28TFFacturaFechaRegistro_To ;
      private DateTime AV36TFFacturaFechaFactura ;
      private DateTime AV37TFFacturaFechaFactura_To ;
      private DateTime AV30DDO_FacturaFechaRegistroAuxDateTo ;
      private DateTime AV39DDO_FacturaFechaFacturaAuxDateTo ;
      private DateTime AV29DDO_FacturaFechaRegistroAuxDate ;
      private DateTime AV38DDO_FacturaFechaFacturaAuxDate ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A73FacturaFechaFactura ;
      private DateTime AV103Wpfacturaspartds_2_tffacturafecharegistro ;
      private DateTime AV104Wpfacturaspartds_3_tffacturafecharegistro_to ;
      private DateTime AV109Wpfacturaspartds_8_tffacturafechafactura ;
      private DateTime AV110Wpfacturaspartds_9_tffacturafechafactura_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_59_Refreshing=false ;
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
      private bool AV69UserAction4_IsBlob ;
      private string AV66UsuarioJSON ;
      private string AV17ColumnsSelectorXML ;
      private string AV23ManageFiltersXml ;
      private string AV18UserCustomValue ;
      private string AV15FilterFullText ;
      private string AV32TFPromocionDescripcion ;
      private string AV33TFPromocionDescripcion_Sel ;
      private string AV53TFUsuarioNombreCompleto ;
      private string AV54TFUsuarioNombreCompleto_Sel ;
      private string A11DistribuidorDescripcion ;
      private string AV62GridAppliedFilters ;
      private string AV31DDO_FacturaFechaRegistroAuxDateText ;
      private string AV40DDO_FacturaFechaFacturaAuxDateText ;
      private string AV115Useraction4_GXI ;
      private string A42PromocionDescripcion ;
      private string AV82PartidasWithTags ;
      private string AV58EstatusWithTags ;
      private string AV74Descripcion ;
      private string A52UsuarioNombreCompleto ;
      private string A20MotivoRechazoDescripcion ;
      private string AV84DistribuidorDescripcion ;
      private string lV102Wpfacturaspartds_1_filterfulltext ;
      private string lV105Wpfacturaspartds_4_tfpromociondescripcion ;
      private string lV113Wpfacturaspartds_12_tfusuarionombrecompleto ;
      private string AV102Wpfacturaspartds_1_filterfulltext ;
      private string AV106Wpfacturaspartds_5_tfpromociondescripcion_sel ;
      private string AV105Wpfacturaspartds_4_tfpromociondescripcion ;
      private string AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel ;
      private string AV113Wpfacturaspartds_12_tfusuarionombrecompleto ;
      private string AV86FileURL ;
      private string A40000FacturaPDF_GXI ;
      private string AV69UserAction4 ;
      private string A75FacturaPDF ;
      private string AV85Blob ;
      private IGxSession AV67WebSession ;
      private IGxSession AV21Session ;
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
      private GXUserControl ucDvelop_confirmpanel_useraction3 ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbFacturaEstatus ;
      private GXCheckbox chkMotivoRechazoActivo ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV19ColumnsSelector ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV90Elements ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter> AV91Parameters ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData AV92ItemClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData AV93ItemDoubleClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData AV94DragAndDropData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData AV95FilterChangedData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData AV96ItemExpandData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData AV97ItemCollapseData ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV22ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV57DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV10GridState ;
      private GxSimpleCollection<int> AV100ListaUsuarios ;
      private IDataStoreProvider pr_default ;
      private int[] H003B2_A41PromocionID ;
      private bool[] H003B2_A93FacturaCompleta ;
      private int[] H003B2_A19MotivoRechazoID ;
      private string[] H003B2_A20MotivoRechazoDescripcion ;
      private bool[] H003B2_A21MotivoRechazoActivo ;
      private int[] H003B2_A29UsuarioID ;
      private string[] H003B2_A80FacturaEstatus ;
      private DateTime[] H003B2_A73FacturaFechaFactura ;
      private string[] H003B2_A71FacturaNo ;
      private string[] H003B2_A42PromocionDescripcion ;
      private DateTime[] H003B2_A72FacturaFechaRegistro ;
      private int[] H003B2_A69FacturaID ;
      private string[] H003B2_A51UsuarioApellido ;
      private string[] H003B2_A30UsuarioNombre ;
      private long[] H003B3_AGRID_nRecordCount ;
      private SdtSDTUsuario AV68SDTUsuario ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV20ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private int[] H003B4_A81DistribuidoresUsuarioID ;
      private int[] H003B4_A10DistribuidorID ;
      private int[] H003B4_A29UsuarioID ;
      private string[] H003B4_A11DistribuidorDescripcion ;
      private int[] H003B5_A69FacturaID ;
      private string[] H003B5_A40000FacturaPDF_GXI ;
      private string[] H003B5_A75FacturaPDF ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpfacturaspart__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003B2( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV100ListaUsuarios ,
                                             string AV102Wpfacturaspartds_1_filterfulltext ,
                                             DateTime AV103Wpfacturaspartds_2_tffacturafecharegistro ,
                                             DateTime AV104Wpfacturaspartds_3_tffacturafecharegistro_to ,
                                             string AV106Wpfacturaspartds_5_tfpromociondescripcion_sel ,
                                             string AV105Wpfacturaspartds_4_tfpromociondescripcion ,
                                             string AV108Wpfacturaspartds_7_tffacturano_sel ,
                                             string AV107Wpfacturaspartds_6_tffacturano ,
                                             DateTime AV109Wpfacturaspartds_8_tffacturafechafactura ,
                                             DateTime AV110Wpfacturaspartds_9_tffacturafechafactura_to ,
                                             short AV112Wpfacturaspartds_11_tfestatusoperator ,
                                             string AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel ,
                                             string AV113Wpfacturaspartds_12_tfusuarionombrecompleto ,
                                             DateTime AV88FromDate ,
                                             DateTime AV89ToDate ,
                                             int AV100ListaUsuarios_Count ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[17];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.`PromocionID`, T1.`FacturaCompleta`, T1.`MotivoRechazoID`, T3.`MotivoRechazoDescripcion`, T3.`MotivoRechazoActivo`, T1.`UsuarioID`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaNo`, T2.`PromocionDescripcion`, T1.`FacturaFechaRegistro`, T1.`FacturaID`, T4.`UsuarioApellido`, T4.`UsuarioNombre`";
         sFromString = " FROM (((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `MotivoRechazo` T3 ON T3.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wpfacturaspartds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.`PromocionDescripcion` like CONCAT('%', @lV102Wpfacturaspartds_1_filterfulltext)) or ( T1.`FacturaNo` like CONCAT('%', @lV102Wpfacturaspartds_1_filterfulltext)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like CONCAT('%', @lV102Wpfacturaspartds_1_filterfulltext)))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV103Wpfacturaspartds_2_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV103Wpfacturaspartds_2_tffacturafecharegistro)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV104Wpfacturaspartds_3_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV104Wpfacturaspartds_3_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Wpfacturaspartds_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wpfacturaspartds_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV105Wpfacturaspartds_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wpfacturaspartds_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV106Wpfacturaspartds_5_tfpromociondescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV106Wpfacturaspartds_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV106Wpfacturaspartds_5_tfpromociondescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Wpfacturaspartds_7_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wpfacturaspartds_6_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV107Wpfacturaspartds_6_tffacturano)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wpfacturaspartds_7_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV108Wpfacturaspartds_7_tffacturano_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV108Wpfacturaspartds_7_tffacturano_sel)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV108Wpfacturaspartds_7_tffacturano_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV109Wpfacturaspartds_8_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV109Wpfacturaspartds_8_tffacturafechafactura)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV110Wpfacturaspartds_9_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV110Wpfacturaspartds_9_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV112Wpfacturaspartds_11_tfestatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV112Wpfacturaspartds_11_tfestatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV112Wpfacturaspartds_11_tfestatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV112Wpfacturaspartds_11_tfestatusoperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wpfacturaspartds_12_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like @lV113Wpfacturaspartds_12_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) = @AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( StringUtil.StrCmp(AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T4.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T4.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV88FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV88FromDate)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV89ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV89ToDate)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV100ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV100ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
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

      protected Object[] conditional_H003B3( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV100ListaUsuarios ,
                                             string AV102Wpfacturaspartds_1_filterfulltext ,
                                             DateTime AV103Wpfacturaspartds_2_tffacturafecharegistro ,
                                             DateTime AV104Wpfacturaspartds_3_tffacturafecharegistro_to ,
                                             string AV106Wpfacturaspartds_5_tfpromociondescripcion_sel ,
                                             string AV105Wpfacturaspartds_4_tfpromociondescripcion ,
                                             string AV108Wpfacturaspartds_7_tffacturano_sel ,
                                             string AV107Wpfacturaspartds_6_tffacturano ,
                                             DateTime AV109Wpfacturaspartds_8_tffacturafechafactura ,
                                             DateTime AV110Wpfacturaspartds_9_tffacturafechafactura_to ,
                                             short AV112Wpfacturaspartds_11_tfestatusoperator ,
                                             string AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel ,
                                             string AV113Wpfacturaspartds_12_tfusuarionombrecompleto ,
                                             DateTime AV88FromDate ,
                                             DateTime AV89ToDate ,
                                             int AV100ListaUsuarios_Count ,
                                             string A42PromocionDescripcion ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             DateTime A72FacturaFechaRegistro ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[15];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `MotivoRechazo` T3 ON T3.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wpfacturaspartds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.`PromocionDescripcion` like CONCAT('%', @lV102Wpfacturaspartds_1_filterfulltext)) or ( T1.`FacturaNo` like CONCAT('%', @lV102Wpfacturaspartds_1_filterfulltext)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like CONCAT('%', @lV102Wpfacturaspartds_1_filterfulltext)))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV103Wpfacturaspartds_2_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV103Wpfacturaspartds_2_tffacturafecharegistro)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV104Wpfacturaspartds_3_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV104Wpfacturaspartds_3_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Wpfacturaspartds_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wpfacturaspartds_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV105Wpfacturaspartds_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wpfacturaspartds_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV106Wpfacturaspartds_5_tfpromociondescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV106Wpfacturaspartds_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( StringUtil.StrCmp(AV106Wpfacturaspartds_5_tfpromociondescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Wpfacturaspartds_7_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wpfacturaspartds_6_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV107Wpfacturaspartds_6_tffacturano)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wpfacturaspartds_7_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV108Wpfacturaspartds_7_tffacturano_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV108Wpfacturaspartds_7_tffacturano_sel)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( StringUtil.StrCmp(AV108Wpfacturaspartds_7_tffacturano_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV109Wpfacturaspartds_8_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV109Wpfacturaspartds_8_tffacturafechafactura)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV110Wpfacturaspartds_9_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV110Wpfacturaspartds_9_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV112Wpfacturaspartds_11_tfestatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV112Wpfacturaspartds_11_tfestatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV112Wpfacturaspartds_11_tfestatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV112Wpfacturaspartds_11_tfestatusoperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wpfacturaspartds_12_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like @lV113Wpfacturaspartds_12_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) = @AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T4.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T4.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV88FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV88FromDate)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV89ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV89ToDate)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV100ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV100ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
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
                     return conditional_H003B2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (bool)dynConstraints[26] );
               case 1 :
                     return conditional_H003B3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (bool)dynConstraints[26] );
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
          Object[] prmH003B4;
          prmH003B4 = new Object[] {
          new ParDef("@AV83RegUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH003B5;
          prmH003B5 = new Object[] {
          new ParDef("@AV87FacturaID",GXType.Int32,9,0)
          };
          Object[] prmH003B2;
          prmH003B2 = new Object[] {
          new ParDef("@lV102Wpfacturaspartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV102Wpfacturaspartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV102Wpfacturaspartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV103Wpfacturaspartds_2_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV104Wpfacturaspartds_3_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV105Wpfacturaspartds_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV106Wpfacturaspartds_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV107Wpfacturaspartds_6_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV108Wpfacturaspartds_7_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@AV109Wpfacturaspartds_8_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV110Wpfacturaspartds_9_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@lV113Wpfacturaspartds_12_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@AV88FromDate",GXType.Date,8,0) ,
          new ParDef("@AV89ToDate",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH003B3;
          prmH003B3 = new Object[] {
          new ParDef("@lV102Wpfacturaspartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV102Wpfacturaspartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV102Wpfacturaspartds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV103Wpfacturaspartds_2_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV104Wpfacturaspartds_3_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV105Wpfacturaspartds_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV106Wpfacturaspartds_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV107Wpfacturaspartds_6_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV108Wpfacturaspartds_7_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@AV109Wpfacturaspartds_8_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV110Wpfacturaspartds_9_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@lV113Wpfacturaspartds_12_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV114Wpfacturaspartds_13_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@AV88FromDate",GXType.Date,8,0) ,
          new ParDef("@AV89ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003B2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003B3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003B4", "SELECT T1.`DistribuidoresUsuarioID`, T1.`DistribuidorID`, T1.`UsuarioID`, T2.`DistribuidorDescripcion` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Distribuidor` T2 ON T2.`DistribuidorID` = T1.`DistribuidorID`) WHERE T1.`UsuarioID` = @AV83RegUsuarioID ORDER BY T1.`UsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003B4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H003B5", "SELECT `FacturaID`, `FacturaPDF_GXI`, `FacturaPDF` FROM `Factura` WHERE `FacturaID` = @AV87FacturaID ORDER BY `FacturaID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003B5,1, GxCacheFrequency.OFF ,true,true )
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
