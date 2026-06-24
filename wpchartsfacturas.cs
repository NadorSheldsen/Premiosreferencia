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
   public class wpchartsfacturas : GXDataArea
   {
      public wpchartsfacturas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpchartsfacturas( IGxContext context )
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
         cmbavGridactions = new GXCombobox();
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
         nRC_GXsfl_67 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_67"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_67_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_67_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_67_idx = GetPar( "sGXsfl_67_idx");
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
         AV84FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
         AV85ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
         AV23ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV18ColumnsSelector);
         AV108Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV28TFPromocionDescripcion = GetPar( "TFPromocionDescripcion");
         AV29TFPromocionDescripcion_Sel = GetPar( "TFPromocionDescripcion_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV61TFFacturaEstatus_Sels);
         AV36TFFacturaFechaFactura = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaFactura"));
         AV37TFFacturaFechaFactura_To = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaFactura_To"));
         AV41TFFacturaFechaRegistro = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaRegistro"));
         AV42TFFacturaFechaRegistro_To = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaRegistro_To"));
         AV34TFFacturaNo = GetPar( "TFFacturaNo");
         AV35TFFacturaNo_Sel = GetPar( "TFFacturaNo_Sel");
         AV48TFUsuarioNombreCompleto = GetPar( "TFUsuarioNombreCompleto");
         AV49TFUsuarioNombreCompleto_Sel = GetPar( "TFUsuarioNombreCompleto_Sel");
         AV64TFMotivoRechazoDescripcion = GetPar( "TFMotivoRechazoDescripcion");
         AV65TFMotivoRechazoDescripcion_Sel = GetPar( "TFMotivoRechazoDescripcion_Sel");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV84FromDate, AV85ToDate, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV108Pgmname, AV15FilterFullText, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV61TFFacturaEstatus_Sels, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV64TFMotivoRechazoDescripcion, AV65TFMotivoRechazoDescripcion_Sel) ;
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
         PA4G2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4G2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpchartsfacturas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV108Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV108Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFROMDATE", context.localUtil.Format(AV84FromDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vTODATE", context.localUtil.Format(AV85ToDate, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_67", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_67), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV67DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV67DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISTRIBUIDORID_DATA", AV87DistribuidorID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISTRIBUIDORID_DATA", AV87DistribuidorID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vELEMENTS", AV74Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vELEMENTS", AV74Elements);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPARAMETERS", AV75Parameters);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPARAMETERS", AV75Parameters);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCLICKDATA", AV76ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCLICKDATA", AV76ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMDOUBLECLICKDATA", AV77ItemDoubleClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMDOUBLECLICKDATA", AV77ItemDoubleClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDRAGANDDROPDATA", AV78DragAndDropData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDRAGANDDROPDATA", AV78DragAndDropData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERCHANGEDDATA", AV79FilterChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERCHANGEDDATA", AV79FilterChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMEXPANDDATA", AV80ItemExpandData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMEXPANDDATA", AV80ItemExpandData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCOLLAPSEDATA", AV81ItemCollapseData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCOLLAPSEDATA", AV81ItemCollapseData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV21ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV21ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV69GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV71GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV18ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV18ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_FACTURAFECHAFACTURAAUXDATETO", context.localUtil.DToC( AV39DDO_FacturaFechaFacturaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_FACTURAFECHAREGISTROAUXDATETO", context.localUtil.DToC( AV44DDO_FacturaFechaRegistroAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV108Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV108Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFPROMOCIONDESCRIPCION", AV28TFPromocionDescripcion);
         GxWebStd.gx_hidden_field( context, "vTFPROMOCIONDESCRIPCION_SEL", AV29TFPromocionDescripcion_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFFACTURAESTATUS_SELS", AV61TFFacturaEstatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFFACTURAESTATUS_SELS", AV61TFFacturaEstatus_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFFACTURAFECHAFACTURA", context.localUtil.DToC( AV36TFFacturaFechaFactura, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAFECHAFACTURA_TO", context.localUtil.DToC( AV37TFFacturaFechaFactura_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAFECHAREGISTRO", context.localUtil.DToC( AV41TFFacturaFechaRegistro, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAFECHAREGISTRO_TO", context.localUtil.DToC( AV42TFFacturaFechaRegistro_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFFACTURANO", StringUtil.RTrim( AV34TFFacturaNo));
         GxWebStd.gx_hidden_field( context, "vTFFACTURANO_SEL", StringUtil.RTrim( AV35TFFacturaNo_Sel));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIONOMBRECOMPLETO", AV48TFUsuarioNombreCompleto);
         GxWebStd.gx_hidden_field( context, "vTFUSUARIONOMBRECOMPLETO_SEL", AV49TFUsuarioNombreCompleto_Sel);
         GxWebStd.gx_hidden_field( context, "vTFMOTIVORECHAZODESCRIPCION", AV64TFMotivoRechazoDescripcion);
         GxWebStd.gx_hidden_field( context, "vTFMOTIVORECHAZODESCRIPCION_SEL", AV65TFMotivoRechazoDescripcion_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV13OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFFACTURAESTATUS_SELSJSON", AV60TFFacturaEstatus_SelsJson);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLISTAUSUARIOS", AV102ListaUsuarios);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLISTAUSUARIOS", AV102ListaUsuarios);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISTRIBUIDORID", AV86DistribuidorID);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISTRIBUIDORID", AV86DistribuidorID);
         }
         GxWebStd.gx_hidden_field( context, "USUARIOROL", StringUtil.RTrim( A40UsuarioRol));
         GxWebStd.gx_hidden_field( context, "DISTRIBUIDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10DistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vDDO_FACTURAFECHAFACTURAAUXDATE", context.localUtil.DToC( AV38DDO_FacturaFechaFacturaAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_FACTURAFECHAREGISTROAUXDATE", context.localUtil.DToC( AV43DDO_FacturaFechaRegistroAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Cls", StringUtil.RTrim( Combo_distribuidorid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Selectedvalue_set", StringUtil.RTrim( Combo_distribuidorid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Allowmultipleselection", StringUtil.BoolToStr( Combo_distribuidorid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_distribuidorid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Emptyitem", StringUtil.BoolToStr( Combo_distribuidorid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Multiplevaluestype", StringUtil.RTrim( Combo_distribuidorid_Multiplevaluestype));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Selectedvalue_get", StringUtil.RTrim( Combo_distribuidorid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Selectedvalue_get", StringUtil.RTrim( Combo_distribuidorid_Selectedvalue_get));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE4G2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4G2( ) ;
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
         return formatLink("wpchartsfacturas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPChartsFacturas" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Factura", "") ;
      }

      protected void WB4G0( )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'" + sGXsfl_67_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFromdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFromdate_Internalname, context.localUtil.Format(AV84FromDate, "99/99/99"), context.localUtil.Format( AV84FromDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,14);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFromdate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFromdate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPChartsFacturas.htm");
            GxWebStd.gx_bitmap( context, edtavFromdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFromdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPChartsFacturas.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_67_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTodate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTodate_Internalname, context.localUtil.Format(AV85ToDate, "99/99/99"), context.localUtil.Format( AV85ToDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTodate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTodate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPChartsFacturas.htm");
            GxWebStd.gx_bitmap( context, edtavTodate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTodate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPChartsFacturas.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_distribuidorid_Internalname, context.GetMessage( "Distribuidores", ""), "", "", lblTextblockcombo_distribuidorid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPChartsFacturas.htm");
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
            ucCombo_distribuidorid.SetProperty("DropDownOptionsTitleSettingsIcons", AV67DDO_TitleSettingsIcons);
            ucCombo_distribuidorid.SetProperty("DropDownOptionsData", AV87DistribuidorID_Data);
            ucCombo_distribuidorid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_distribuidorid_Internalname, "COMBO_DISTRIBUIDORIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(67), 2, 0)+","+"null"+");", context.GetMessage( "Filtrar", ""), bttBtnuseraction1_Jsonclick, 5, context.GetMessage( "Filtrar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION1\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPChartsFacturas.htm");
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
            ucUtchartdoughnut.SetProperty("Elements", AV74Elements);
            ucUtchartdoughnut.SetProperty("Parameters", AV75Parameters);
            ucUtchartdoughnut.SetProperty("Type", Utchartdoughnut_Type);
            ucUtchartdoughnut.SetProperty("Title", Utchartdoughnut_Title);
            ucUtchartdoughnut.SetProperty("ShowValues", Utchartdoughnut_Showvalues);
            ucUtchartdoughnut.SetProperty("ChartType", Utchartdoughnut_Charttype);
            ucUtchartdoughnut.SetProperty("ItemClickData", AV76ItemClickData);
            ucUtchartdoughnut.SetProperty("ItemDoubleClickData", AV77ItemDoubleClickData);
            ucUtchartdoughnut.SetProperty("DragAndDropData", AV78DragAndDropData);
            ucUtchartdoughnut.SetProperty("FilterChangedData", AV79FilterChangedData);
            ucUtchartdoughnut.SetProperty("ItemExpandData", AV80ItemExpandData);
            ucUtchartdoughnut.SetProperty("ItemCollapseData", AV81ItemCollapseData);
            ucUtchartdoughnut.Render(context, "queryviewer", Utchartdoughnut_Internalname, "UTCHARTDOUGHNUTContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartcolumnline.SetProperty("Elements", AV74Elements);
            ucUtchartcolumnline.SetProperty("Parameters", AV75Parameters);
            ucUtchartcolumnline.SetProperty("Type", Utchartcolumnline_Type);
            ucUtchartcolumnline.SetProperty("Title", Utchartcolumnline_Title);
            ucUtchartcolumnline.SetProperty("ItemClickData", AV76ItemClickData);
            ucUtchartcolumnline.SetProperty("ItemDoubleClickData", AV77ItemDoubleClickData);
            ucUtchartcolumnline.SetProperty("DragAndDropData", AV78DragAndDropData);
            ucUtchartcolumnline.SetProperty("FilterChangedData", AV79FilterChangedData);
            ucUtchartcolumnline.SetProperty("ItemExpandData", AV80ItemExpandData);
            ucUtchartcolumnline.SetProperty("ItemCollapseData", AV81ItemCollapseData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(67), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPChartsFacturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(67), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WPChartsFacturas.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_67_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WPChartsFacturas.htm");
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV69GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV70GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV71GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV67DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV67DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV18ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_facturafechafacturaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_67_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_facturafechafacturaauxdatetext_Internalname, AV40DDO_FacturaFechaFacturaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV40DDO_FacturaFechaFacturaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_facturafechafacturaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPChartsFacturas.htm");
            /* User Defined Control */
            ucTffacturafechafactura_rangepicker.SetProperty("Start Date", AV38DDO_FacturaFechaFacturaAuxDate);
            ucTffacturafechafactura_rangepicker.SetProperty("End Date", AV39DDO_FacturaFechaFacturaAuxDateTo);
            ucTffacturafechafactura_rangepicker.Render(context, "wwp.daterangepicker", Tffacturafechafactura_rangepicker_Internalname, "TFFACTURAFECHAFACTURA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_facturafecharegistroauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_67_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_facturafecharegistroauxdatetext_Internalname, AV45DDO_FacturaFechaRegistroAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV45DDO_FacturaFechaRegistroAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_facturafecharegistroauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPChartsFacturas.htm");
            /* User Defined Control */
            ucTffacturafecharegistro_rangepicker.SetProperty("Start Date", AV43DDO_FacturaFechaRegistroAuxDate);
            ucTffacturafecharegistro_rangepicker.SetProperty("End Date", AV44DDO_FacturaFechaRegistroAuxDateTo);
            ucTffacturafecharegistro_rangepicker.Render(context, "wwp.daterangepicker", Tffacturafecharegistro_rangepicker_Internalname, "TFFACTURAFECHAREGISTRO_RANGEPICKERContainer");
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

      protected void START4G2( )
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
         STRUP4G0( ) ;
      }

      protected void WS4G2( )
      {
         START4G2( ) ;
         EVT4G2( ) ;
      }

      protected void EVT4G2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_DISTRIBUIDORID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_distribuidorid.Onoptionclicked */
                              E114G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E124G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E134G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E144G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E154G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E164G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E174G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction1' */
                              E184G2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_67_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
                              SubsflControlProps_672( ) ;
                              A69FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A42PromocionDescripcion = cgiGet( edtPromocionDescripcion_Internalname);
                              cmbFacturaEstatus.Name = cmbFacturaEstatus_Internalname;
                              cmbFacturaEstatus.CurrentValue = cgiGet( cmbFacturaEstatus_Internalname);
                              A80FacturaEstatus = cgiGet( cmbFacturaEstatus_Internalname);
                              A73FacturaFechaFactura = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaFactura_Internalname), 0));
                              A72FacturaFechaRegistro = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaRegistro_Internalname), 0));
                              A71FacturaNo = cgiGet( edtFacturaNo_Internalname);
                              A52UsuarioNombreCompleto = cgiGet( edtUsuarioNombreCompleto_Internalname);
                              A20MotivoRechazoDescripcion = cgiGet( edtMotivoRechazoDescripcion_Internalname);
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV72GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV72GridActions), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E194G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E204G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E214G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E224G2 ();
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
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vFROMDATE"), 0) != AV84FromDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Todate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vTODATE"), 0) != AV85ToDate )
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE4G2( )
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

      protected void PA4G2( )
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
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       DateTime AV84FromDate ,
                                       DateTime AV85ToDate ,
                                       short AV23ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV18ColumnsSelector ,
                                       string AV108Pgmname ,
                                       string AV15FilterFullText ,
                                       string AV28TFPromocionDescripcion ,
                                       string AV29TFPromocionDescripcion_Sel ,
                                       GxSimpleCollection<string> AV61TFFacturaEstatus_Sels ,
                                       DateTime AV36TFFacturaFechaFactura ,
                                       DateTime AV37TFFacturaFechaFactura_To ,
                                       DateTime AV41TFFacturaFechaRegistro ,
                                       DateTime AV42TFFacturaFechaRegistro_To ,
                                       string AV34TFFacturaNo ,
                                       string AV35TFFacturaNo_Sel ,
                                       string AV48TFUsuarioNombreCompleto ,
                                       string AV49TFUsuarioNombreCompleto_Sel ,
                                       string AV64TFMotivoRechazoDescripcion ,
                                       string AV65TFMotivoRechazoDescripcion_Sel )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4G2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "USUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, ".", "")));
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
         RF4G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV108Pgmname = "WPChartsFacturas";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV109Wpchartsfacturasds_1_filterfulltext = AV15FilterFullText;
         AV110Wpchartsfacturasds_2_tfpromociondescripcion = AV28TFPromocionDescripcion;
         AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel = AV29TFPromocionDescripcion_Sel;
         AV112Wpchartsfacturasds_4_tffacturaestatus_sels = AV61TFFacturaEstatus_Sels;
         AV113Wpchartsfacturasds_5_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV114Wpchartsfacturasds_6_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV115Wpchartsfacturasds_7_tffacturafecharegistro = AV41TFFacturaFechaRegistro;
         AV116Wpchartsfacturasds_8_tffacturafecharegistro_to = AV42TFFacturaFechaRegistro_To;
         AV117Wpchartsfacturasds_9_tffacturano = AV34TFFacturaNo;
         AV118Wpchartsfacturasds_10_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV119Wpchartsfacturasds_11_tfusuarionombrecompleto = AV48TFUsuarioNombreCompleto;
         AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel = AV49TFUsuarioNombreCompleto_Sel;
         AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion = AV64TFMotivoRechazoDescripcion;
         AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel = AV65TFMotivoRechazoDescripcion_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV102ListaUsuarios ,
                                              A80FacturaEstatus ,
                                              AV112Wpchartsfacturasds_4_tffacturaestatus_sels ,
                                              AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel ,
                                              AV110Wpchartsfacturasds_2_tfpromociondescripcion ,
                                              AV112Wpchartsfacturasds_4_tffacturaestatus_sels.Count ,
                                              AV113Wpchartsfacturasds_5_tffacturafechafactura ,
                                              AV114Wpchartsfacturasds_6_tffacturafechafactura_to ,
                                              AV115Wpchartsfacturasds_7_tffacturafecharegistro ,
                                              AV116Wpchartsfacturasds_8_tffacturafecharegistro_to ,
                                              AV118Wpchartsfacturasds_10_tffacturano_sel ,
                                              AV117Wpchartsfacturasds_9_tffacturano ,
                                              AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel ,
                                              AV119Wpchartsfacturasds_11_tfusuarionombrecompleto ,
                                              AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel ,
                                              AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion ,
                                              A42PromocionDescripcion ,
                                              A73FacturaFechaFactura ,
                                              A72FacturaFechaRegistro ,
                                              A71FacturaNo ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A20MotivoRechazoDescripcion ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              AV109Wpchartsfacturasds_1_filterfulltext ,
                                              A52UsuarioNombreCompleto ,
                                              AV84FromDate ,
                                              AV85ToDate ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV110Wpchartsfacturasds_2_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV110Wpchartsfacturasds_2_tfpromociondescripcion), "%", "");
         lV117Wpchartsfacturasds_9_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV117Wpchartsfacturasds_9_tffacturano), 20, "%");
         lV119Wpchartsfacturasds_11_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV119Wpchartsfacturasds_11_tfusuarionombrecompleto), "%", "");
         lV121Wpchartsfacturasds_13_tfmotivorechazodescripcion = StringUtil.Concat( StringUtil.RTrim( AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion), "%", "");
         /* Using cursor H004G2 */
         pr_default.execute(0, new Object[] {AV84FromDate, AV85ToDate, lV110Wpchartsfacturasds_2_tfpromociondescripcion, AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel, AV113Wpchartsfacturasds_5_tffacturafechafactura, AV114Wpchartsfacturasds_6_tffacturafechafactura_to, AV115Wpchartsfacturasds_7_tffacturafecharegistro, AV116Wpchartsfacturasds_8_tffacturafecharegistro_to, lV117Wpchartsfacturasds_9_tffacturano, AV118Wpchartsfacturasds_10_tffacturano_sel, lV119Wpchartsfacturasds_11_tfusuarionombrecompleto, AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, lV121Wpchartsfacturasds_13_tfmotivorechazodescripcion, AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A41PromocionID = H004G2_A41PromocionID[0];
            A19MotivoRechazoID = H004G2_A19MotivoRechazoID[0];
            A93FacturaCompleta = H004G2_A93FacturaCompleta[0];
            A20MotivoRechazoDescripcion = H004G2_A20MotivoRechazoDescripcion[0];
            A52UsuarioNombreCompleto = H004G2_A52UsuarioNombreCompleto[0];
            A71FacturaNo = H004G2_A71FacturaNo[0];
            A72FacturaFechaRegistro = H004G2_A72FacturaFechaRegistro[0];
            A73FacturaFechaFactura = H004G2_A73FacturaFechaFactura[0];
            A80FacturaEstatus = H004G2_A80FacturaEstatus[0];
            A42PromocionDescripcion = H004G2_A42PromocionDescripcion[0];
            A29UsuarioID = H004G2_A29UsuarioID[0];
            A69FacturaID = H004G2_A69FacturaID[0];
            A30UsuarioNombre = H004G2_A30UsuarioNombre[0];
            A51UsuarioApellido = H004G2_A51UsuarioApellido[0];
            A42PromocionDescripcion = H004G2_A42PromocionDescripcion[0];
            A20MotivoRechazoDescripcion = H004G2_A20MotivoRechazoDescripcion[0];
            A52UsuarioNombreCompleto = H004G2_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = H004G2_A30UsuarioNombre[0];
            A51UsuarioApellido = H004G2_A51UsuarioApellido[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Wpchartsfacturasds_1_filterfulltext)) || ( ( StringUtil.Like( A42PromocionDescripcion , StringUtil.PadR( "%" + AV109Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "gx_emptyitemtext", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A80FacturaEstatus)) ) || ( StringUtil.Like( context.GetMessage( "en proceso", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "aprobada", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "rechazada", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cancelada", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, "Cancelada") == 0 ) ) || ( StringUtil.Like( A71FacturaNo , StringUtil.PadR( "%" + AV109Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV109Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A20MotivoRechazoDescripcion , StringUtil.PadR( "%" + AV109Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF4G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 67;
         /* Execute user event: Refresh */
         E204G2 ();
         nGXsfl_67_idx = 1;
         sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
         SubsflControlProps_672( ) ;
         bGXsfl_67_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
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
            SubsflControlProps_672( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A29UsuarioID ,
                                                 AV102ListaUsuarios ,
                                                 A80FacturaEstatus ,
                                                 AV112Wpchartsfacturasds_4_tffacturaestatus_sels ,
                                                 AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel ,
                                                 AV110Wpchartsfacturasds_2_tfpromociondescripcion ,
                                                 AV112Wpchartsfacturasds_4_tffacturaestatus_sels.Count ,
                                                 AV113Wpchartsfacturasds_5_tffacturafechafactura ,
                                                 AV114Wpchartsfacturasds_6_tffacturafechafactura_to ,
                                                 AV115Wpchartsfacturasds_7_tffacturafecharegistro ,
                                                 AV116Wpchartsfacturasds_8_tffacturafecharegistro_to ,
                                                 AV118Wpchartsfacturasds_10_tffacturano_sel ,
                                                 AV117Wpchartsfacturasds_9_tffacturano ,
                                                 AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel ,
                                                 AV119Wpchartsfacturasds_11_tfusuarionombrecompleto ,
                                                 AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel ,
                                                 AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion ,
                                                 A42PromocionDescripcion ,
                                                 A73FacturaFechaFactura ,
                                                 A72FacturaFechaRegistro ,
                                                 A71FacturaNo ,
                                                 A30UsuarioNombre ,
                                                 A51UsuarioApellido ,
                                                 A20MotivoRechazoDescripcion ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 AV109Wpchartsfacturasds_1_filterfulltext ,
                                                 A52UsuarioNombreCompleto ,
                                                 AV84FromDate ,
                                                 AV85ToDate ,
                                                 A93FacturaCompleta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                                 }
            });
            lV110Wpchartsfacturasds_2_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV110Wpchartsfacturasds_2_tfpromociondescripcion), "%", "");
            lV117Wpchartsfacturasds_9_tffacturano = StringUtil.PadR( StringUtil.RTrim( AV117Wpchartsfacturasds_9_tffacturano), 20, "%");
            lV119Wpchartsfacturasds_11_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV119Wpchartsfacturasds_11_tfusuarionombrecompleto), "%", "");
            lV121Wpchartsfacturasds_13_tfmotivorechazodescripcion = StringUtil.Concat( StringUtil.RTrim( AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion), "%", "");
            /* Using cursor H004G3 */
            pr_default.execute(1, new Object[] {AV84FromDate, AV85ToDate, lV110Wpchartsfacturasds_2_tfpromociondescripcion, AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel, AV113Wpchartsfacturasds_5_tffacturafechafactura, AV114Wpchartsfacturasds_6_tffacturafechafactura_to, AV115Wpchartsfacturasds_7_tffacturafecharegistro, AV116Wpchartsfacturasds_8_tffacturafecharegistro_to, lV117Wpchartsfacturasds_9_tffacturano, AV118Wpchartsfacturasds_10_tffacturano_sel, lV119Wpchartsfacturasds_11_tfusuarionombrecompleto, AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, lV121Wpchartsfacturasds_13_tfmotivorechazodescripcion, AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel});
            nGXsfl_67_idx = 1;
            sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
            SubsflControlProps_672( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A41PromocionID = H004G3_A41PromocionID[0];
               A19MotivoRechazoID = H004G3_A19MotivoRechazoID[0];
               A93FacturaCompleta = H004G3_A93FacturaCompleta[0];
               A20MotivoRechazoDescripcion = H004G3_A20MotivoRechazoDescripcion[0];
               A52UsuarioNombreCompleto = H004G3_A52UsuarioNombreCompleto[0];
               A71FacturaNo = H004G3_A71FacturaNo[0];
               A72FacturaFechaRegistro = H004G3_A72FacturaFechaRegistro[0];
               A73FacturaFechaFactura = H004G3_A73FacturaFechaFactura[0];
               A80FacturaEstatus = H004G3_A80FacturaEstatus[0];
               A42PromocionDescripcion = H004G3_A42PromocionDescripcion[0];
               A29UsuarioID = H004G3_A29UsuarioID[0];
               A69FacturaID = H004G3_A69FacturaID[0];
               A30UsuarioNombre = H004G3_A30UsuarioNombre[0];
               A51UsuarioApellido = H004G3_A51UsuarioApellido[0];
               A42PromocionDescripcion = H004G3_A42PromocionDescripcion[0];
               A20MotivoRechazoDescripcion = H004G3_A20MotivoRechazoDescripcion[0];
               A52UsuarioNombreCompleto = H004G3_A52UsuarioNombreCompleto[0];
               A30UsuarioNombre = H004G3_A30UsuarioNombre[0];
               A51UsuarioApellido = H004G3_A51UsuarioApellido[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Wpchartsfacturasds_1_filterfulltext)) || ( ( StringUtil.Like( A42PromocionDescripcion , StringUtil.PadR( "%" + AV109Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "gx_emptyitemtext", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A80FacturaEstatus)) ) || ( StringUtil.Like( context.GetMessage( "en proceso", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "aprobada", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "rechazada", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cancelada", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Wpchartsfacturasds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A80FacturaEstatus, "Cancelada") == 0 ) ) || ( StringUtil.Like( A71FacturaNo , StringUtil.PadR( "%" + AV109Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV109Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A20MotivoRechazoDescripcion , StringUtil.PadR( "%" + AV109Wpchartsfacturasds_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
               {
                  /* Execute user event: Grid.Load */
                  E214G2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 67;
            WB4G0( ) ;
         }
         bGXsfl_67_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4G2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV108Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV108Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOID"+"_"+sGXsfl_67_idx, GetSecureSignedToken( sGXsfl_67_idx, context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9"), context));
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
         return (int)(subGridclient_rec_count_fnc()) ;
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
         AV109Wpchartsfacturasds_1_filterfulltext = AV15FilterFullText;
         AV110Wpchartsfacturasds_2_tfpromociondescripcion = AV28TFPromocionDescripcion;
         AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel = AV29TFPromocionDescripcion_Sel;
         AV112Wpchartsfacturasds_4_tffacturaestatus_sels = AV61TFFacturaEstatus_Sels;
         AV113Wpchartsfacturasds_5_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV114Wpchartsfacturasds_6_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV115Wpchartsfacturasds_7_tffacturafecharegistro = AV41TFFacturaFechaRegistro;
         AV116Wpchartsfacturasds_8_tffacturafecharegistro_to = AV42TFFacturaFechaRegistro_To;
         AV117Wpchartsfacturasds_9_tffacturano = AV34TFFacturaNo;
         AV118Wpchartsfacturasds_10_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV119Wpchartsfacturasds_11_tfusuarionombrecompleto = AV48TFUsuarioNombreCompleto;
         AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel = AV49TFUsuarioNombreCompleto_Sel;
         AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion = AV64TFMotivoRechazoDescripcion;
         AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel = AV65TFMotivoRechazoDescripcion_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV84FromDate, AV85ToDate, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV108Pgmname, AV15FilterFullText, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV61TFFacturaEstatus_Sels, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV64TFMotivoRechazoDescripcion, AV65TFMotivoRechazoDescripcion_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV109Wpchartsfacturasds_1_filterfulltext = AV15FilterFullText;
         AV110Wpchartsfacturasds_2_tfpromociondescripcion = AV28TFPromocionDescripcion;
         AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel = AV29TFPromocionDescripcion_Sel;
         AV112Wpchartsfacturasds_4_tffacturaestatus_sels = AV61TFFacturaEstatus_Sels;
         AV113Wpchartsfacturasds_5_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV114Wpchartsfacturasds_6_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV115Wpchartsfacturasds_7_tffacturafecharegistro = AV41TFFacturaFechaRegistro;
         AV116Wpchartsfacturasds_8_tffacturafecharegistro_to = AV42TFFacturaFechaRegistro_To;
         AV117Wpchartsfacturasds_9_tffacturano = AV34TFFacturaNo;
         AV118Wpchartsfacturasds_10_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV119Wpchartsfacturasds_11_tfusuarionombrecompleto = AV48TFUsuarioNombreCompleto;
         AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel = AV49TFUsuarioNombreCompleto_Sel;
         AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion = AV64TFMotivoRechazoDescripcion;
         AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel = AV65TFMotivoRechazoDescripcion_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV84FromDate, AV85ToDate, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV108Pgmname, AV15FilterFullText, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV61TFFacturaEstatus_Sels, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV64TFMotivoRechazoDescripcion, AV65TFMotivoRechazoDescripcion_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV109Wpchartsfacturasds_1_filterfulltext = AV15FilterFullText;
         AV110Wpchartsfacturasds_2_tfpromociondescripcion = AV28TFPromocionDescripcion;
         AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel = AV29TFPromocionDescripcion_Sel;
         AV112Wpchartsfacturasds_4_tffacturaestatus_sels = AV61TFFacturaEstatus_Sels;
         AV113Wpchartsfacturasds_5_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV114Wpchartsfacturasds_6_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV115Wpchartsfacturasds_7_tffacturafecharegistro = AV41TFFacturaFechaRegistro;
         AV116Wpchartsfacturasds_8_tffacturafecharegistro_to = AV42TFFacturaFechaRegistro_To;
         AV117Wpchartsfacturasds_9_tffacturano = AV34TFFacturaNo;
         AV118Wpchartsfacturasds_10_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV119Wpchartsfacturasds_11_tfusuarionombrecompleto = AV48TFUsuarioNombreCompleto;
         AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel = AV49TFUsuarioNombreCompleto_Sel;
         AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion = AV64TFMotivoRechazoDescripcion;
         AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel = AV65TFMotivoRechazoDescripcion_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV84FromDate, AV85ToDate, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV108Pgmname, AV15FilterFullText, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV61TFFacturaEstatus_Sels, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV64TFMotivoRechazoDescripcion, AV65TFMotivoRechazoDescripcion_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV109Wpchartsfacturasds_1_filterfulltext = AV15FilterFullText;
         AV110Wpchartsfacturasds_2_tfpromociondescripcion = AV28TFPromocionDescripcion;
         AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel = AV29TFPromocionDescripcion_Sel;
         AV112Wpchartsfacturasds_4_tffacturaestatus_sels = AV61TFFacturaEstatus_Sels;
         AV113Wpchartsfacturasds_5_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV114Wpchartsfacturasds_6_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV115Wpchartsfacturasds_7_tffacturafecharegistro = AV41TFFacturaFechaRegistro;
         AV116Wpchartsfacturasds_8_tffacturafecharegistro_to = AV42TFFacturaFechaRegistro_To;
         AV117Wpchartsfacturasds_9_tffacturano = AV34TFFacturaNo;
         AV118Wpchartsfacturasds_10_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV119Wpchartsfacturasds_11_tfusuarionombrecompleto = AV48TFUsuarioNombreCompleto;
         AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel = AV49TFUsuarioNombreCompleto_Sel;
         AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion = AV64TFMotivoRechazoDescripcion;
         AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel = AV65TFMotivoRechazoDescripcion_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV84FromDate, AV85ToDate, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV108Pgmname, AV15FilterFullText, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV61TFFacturaEstatus_Sels, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV64TFMotivoRechazoDescripcion, AV65TFMotivoRechazoDescripcion_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV109Wpchartsfacturasds_1_filterfulltext = AV15FilterFullText;
         AV110Wpchartsfacturasds_2_tfpromociondescripcion = AV28TFPromocionDescripcion;
         AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel = AV29TFPromocionDescripcion_Sel;
         AV112Wpchartsfacturasds_4_tffacturaestatus_sels = AV61TFFacturaEstatus_Sels;
         AV113Wpchartsfacturasds_5_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV114Wpchartsfacturasds_6_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV115Wpchartsfacturasds_7_tffacturafecharegistro = AV41TFFacturaFechaRegistro;
         AV116Wpchartsfacturasds_8_tffacturafecharegistro_to = AV42TFFacturaFechaRegistro_To;
         AV117Wpchartsfacturasds_9_tffacturano = AV34TFFacturaNo;
         AV118Wpchartsfacturasds_10_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV119Wpchartsfacturasds_11_tfusuarionombrecompleto = AV48TFUsuarioNombreCompleto;
         AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel = AV49TFUsuarioNombreCompleto_Sel;
         AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion = AV64TFMotivoRechazoDescripcion;
         AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel = AV65TFMotivoRechazoDescripcion_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV84FromDate, AV85ToDate, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV108Pgmname, AV15FilterFullText, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV61TFFacturaEstatus_Sels, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV64TFMotivoRechazoDescripcion, AV65TFMotivoRechazoDescripcion_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV108Pgmname = "WPChartsFacturas";
         edtFacturaID_Enabled = 0;
         edtUsuarioID_Enabled = 0;
         edtPromocionDescripcion_Enabled = 0;
         cmbFacturaEstatus.Enabled = 0;
         edtFacturaFechaFactura_Enabled = 0;
         edtFacturaFechaRegistro_Enabled = 0;
         edtFacturaNo_Enabled = 0;
         edtUsuarioNombreCompleto_Enabled = 0;
         edtMotivoRechazoDescripcion_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E194G2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV67DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vDISTRIBUIDORID_DATA"), AV87DistribuidorID_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vELEMENTS"), AV74Elements);
            ajax_req_read_hidden_sdt(cgiGet( "vPARAMETERS"), AV75Parameters);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCLICKDATA"), AV76ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMDOUBLECLICKDATA"), AV77ItemDoubleClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vDRAGANDDROPDATA"), AV78DragAndDropData);
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERCHANGEDDATA"), AV79FilterChangedData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMEXPANDDATA"), AV80ItemExpandData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCOLLAPSEDATA"), AV81ItemCollapseData);
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV21ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV18ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_67 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_67"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV69GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV70GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV71GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV38DDO_FacturaFechaFacturaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_FACTURAFECHAFACTURAAUXDATE"), 0);
            AV39DDO_FacturaFechaFacturaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_FACTURAFECHAFACTURAAUXDATETO"), 0);
            AV43DDO_FacturaFechaRegistroAuxDate = context.localUtil.CToD( cgiGet( "vDDO_FACTURAFECHAREGISTROAUXDATE"), 0);
            AV44DDO_FacturaFechaRegistroAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_FACTURAFECHAREGISTROAUXDATETO"), 0);
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Combo_distribuidorid_Cls = cgiGet( "COMBO_DISTRIBUIDORID_Cls");
            Combo_distribuidorid_Selectedvalue_set = cgiGet( "COMBO_DISTRIBUIDORID_Selectedvalue_set");
            Combo_distribuidorid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_DISTRIBUIDORID_Allowmultipleselection"));
            Combo_distribuidorid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_DISTRIBUIDORID_Includeonlyselectedoption"));
            Combo_distribuidorid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_DISTRIBUIDORID_Emptyitem"));
            Combo_distribuidorid_Multiplevaluestype = cgiGet( "COMBO_DISTRIBUIDORID_Multiplevaluestype");
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
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Combo_distribuidorid_Selectedvalue_get = cgiGet( "COMBO_DISTRIBUIDORID_Selectedvalue_get");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavFromdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "From Date", "")}), 1, "vFROMDATE");
               GX_FocusControl = edtavFromdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV84FromDate = DateTime.MinValue;
               AssignAttri("", false, "AV84FromDate", context.localUtil.Format(AV84FromDate, "99/99/99"));
            }
            else
            {
               AV84FromDate = context.localUtil.CToD( cgiGet( edtavFromdate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV84FromDate", context.localUtil.Format(AV84FromDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTodate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "To Date", "")}), 1, "vTODATE");
               GX_FocusControl = edtavTodate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV85ToDate = DateTime.MinValue;
               AssignAttri("", false, "AV85ToDate", context.localUtil.Format(AV85ToDate, "99/99/99"));
            }
            else
            {
               AV85ToDate = context.localUtil.CToD( cgiGet( edtavTodate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV85ToDate", context.localUtil.Format(AV85ToDate, "99/99/99"));
            }
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            AV40DDO_FacturaFechaFacturaAuxDateText = cgiGet( edtavDdo_facturafechafacturaauxdatetext_Internalname);
            AssignAttri("", false, "AV40DDO_FacturaFechaFacturaAuxDateText", AV40DDO_FacturaFechaFacturaAuxDateText);
            AV45DDO_FacturaFechaRegistroAuxDateText = cgiGet( edtavDdo_facturafecharegistroauxdatetext_Internalname);
            AssignAttri("", false, "AV45DDO_FacturaFechaRegistroAuxDateText", AV45DDO_FacturaFechaRegistroAuxDateText);
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
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vFROMDATE"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV84FromDate ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vTODATE"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV85ToDate ) )
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
         E194G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E194G2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV85ToDate = DateTimeUtil.Today( context);
         AssignAttri("", false, "AV85ToDate", context.localUtil.Format(AV85ToDate, "99/99/99"));
         AV84FromDate = DateTimeUtil.AddMth( AV85ToDate, -3);
         AssignAttri("", false, "AV84FromDate", context.localUtil.Format(AV84FromDate, "99/99/99"));
         /* Execute user subroutine: 'OBTIENELISTAUSUARIOS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Utchartdoughnut_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPFacturaEstatusFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV84FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV85ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV102ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartdoughnut.SendProperty(context, "", false, Utchartdoughnut_Internalname, "Object", Utchartdoughnut_Objectcall);
         Utchartcolumnline_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPGraficaFacturasPorMesFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV84FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV85ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV102ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartcolumnline.SendProperty(context, "", false, Utchartcolumnline_Internalname, "Object", Utchartcolumnline_Objectcall);
         this.executeUsercontrolMethod("", false, "TFFACTURAFECHAREGISTRO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_facturafecharegistroauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFFACTURAFECHAFACTURA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_facturafechafacturaauxdatetext_Internalname});
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV67DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV67DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         /* Execute user subroutine: 'LOADCOMBODISTRIBUIDORID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S132 ();
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
         if ( AV12OrderedBy < 1 )
         {
            AV12OrderedBy = 1;
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV67DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV67DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E204G2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV23ManageFiltersExecutionStep == 1 )
         {
            AV23ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV23ManageFiltersExecutionStep == 2 )
         {
            AV23ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
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
         if ( StringUtil.StrCmp(AV20Session.Get("WPChartsFacturasColumnsSelector"), "") != 0 )
         {
            AV16ColumnsSelectorXML = AV20Session.Get("WPChartsFacturasColumnsSelector");
            AV18ColumnsSelector.FromXml(AV16ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtPromocionDescripcion_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPromocionDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPromocionDescripcion_Visible), 5, 0), !bGXsfl_67_Refreshing);
         cmbFacturaEstatus.Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbFacturaEstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbFacturaEstatus.Visible), 5, 0), !bGXsfl_67_Refreshing);
         edtFacturaFechaFactura_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtFacturaFechaFactura_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaFechaFactura_Visible), 5, 0), !bGXsfl_67_Refreshing);
         edtFacturaFechaRegistro_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtFacturaFechaRegistro_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaFechaRegistro_Visible), 5, 0), !bGXsfl_67_Refreshing);
         edtFacturaNo_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtFacturaNo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaNo_Visible), 5, 0), !bGXsfl_67_Refreshing);
         edtUsuarioNombreCompleto_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtUsuarioNombreCompleto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombreCompleto_Visible), 5, 0), !bGXsfl_67_Refreshing);
         edtMotivoRechazoDescripcion_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMotivoRechazoDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoDescripcion_Visible), 5, 0), !bGXsfl_67_Refreshing);
         AV69GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV69GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV69GridCurrentPage), 10, 0));
         AV70GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV70GridPageCount", StringUtil.LTrimStr( (decimal)(AV70GridPageCount), 10, 0));
         GXt_char2 = AV71GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV108Pgmname, out  GXt_char2) ;
         AV71GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV71GridAppliedFilters", AV71GridAppliedFilters);
         AV109Wpchartsfacturasds_1_filterfulltext = AV15FilterFullText;
         AV110Wpchartsfacturasds_2_tfpromociondescripcion = AV28TFPromocionDescripcion;
         AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel = AV29TFPromocionDescripcion_Sel;
         AV112Wpchartsfacturasds_4_tffacturaestatus_sels = AV61TFFacturaEstatus_Sels;
         AV113Wpchartsfacturasds_5_tffacturafechafactura = AV36TFFacturaFechaFactura;
         AV114Wpchartsfacturasds_6_tffacturafechafactura_to = AV37TFFacturaFechaFactura_To;
         AV115Wpchartsfacturasds_7_tffacturafecharegistro = AV41TFFacturaFechaRegistro;
         AV116Wpchartsfacturasds_8_tffacturafecharegistro_to = AV42TFFacturaFechaRegistro_To;
         AV117Wpchartsfacturasds_9_tffacturano = AV34TFFacturaNo;
         AV118Wpchartsfacturasds_10_tffacturano_sel = AV35TFFacturaNo_Sel;
         AV119Wpchartsfacturasds_11_tfusuarionombrecompleto = AV48TFUsuarioNombreCompleto;
         AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel = AV49TFUsuarioNombreCompleto_Sel;
         AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion = AV64TFMotivoRechazoDescripcion;
         AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel = AV65TFMotivoRechazoDescripcion_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E134G2( )
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
            AV68PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV68PageToGo) ;
         }
      }

      protected void E144G2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E154G2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PromocionDescripcion") == 0 )
            {
               AV28TFPromocionDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV28TFPromocionDescripcion", AV28TFPromocionDescripcion);
               AV29TFPromocionDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFPromocionDescripcion_Sel", AV29TFPromocionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaEstatus") == 0 )
            {
               AV60TFFacturaEstatus_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV60TFFacturaEstatus_SelsJson", AV60TFFacturaEstatus_SelsJson);
               AV61TFFacturaEstatus_Sels.FromJSonString(AV60TFFacturaEstatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaFechaFactura") == 0 )
            {
               AV36TFFacturaFechaFactura = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV36TFFacturaFechaFactura", context.localUtil.Format(AV36TFFacturaFechaFactura, "99/99/99"));
               AV37TFFacturaFechaFactura_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV37TFFacturaFechaFactura_To", context.localUtil.Format(AV37TFFacturaFechaFactura_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaFechaRegistro") == 0 )
            {
               AV41TFFacturaFechaRegistro = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV41TFFacturaFechaRegistro", context.localUtil.Format(AV41TFFacturaFechaRegistro, "99/99/99"));
               AV42TFFacturaFechaRegistro_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV42TFFacturaFechaRegistro_To", context.localUtil.Format(AV42TFFacturaFechaRegistro_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaNo") == 0 )
            {
               AV34TFFacturaNo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV34TFFacturaNo", AV34TFFacturaNo);
               AV35TFFacturaNo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV35TFFacturaNo_Sel", AV35TFFacturaNo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioNombreCompleto") == 0 )
            {
               AV48TFUsuarioNombreCompleto = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV48TFUsuarioNombreCompleto", AV48TFUsuarioNombreCompleto);
               AV49TFUsuarioNombreCompleto_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV49TFUsuarioNombreCompleto_Sel", AV49TFUsuarioNombreCompleto_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MotivoRechazoDescripcion") == 0 )
            {
               AV64TFMotivoRechazoDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV64TFMotivoRechazoDescripcion", AV64TFMotivoRechazoDescripcion);
               AV65TFMotivoRechazoDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV65TFMotivoRechazoDescripcion_Sel", AV65TFMotivoRechazoDescripcion_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61TFFacturaEstatus_Sels", AV61TFFacturaEstatus_Sels);
      }

      private void E214G2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 67;
            }
            sendrow_672( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_67_Refreshing )
         {
            DoAjaxLoad(67, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72GridActions), 4, 0));
      }

      protected void E164G2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV16ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV18ColumnsSelector.FromJSonString(AV16ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WPChartsFacturasColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV16ColumnsSelectorXML)) ? "" : AV18ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E124G2( )
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
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WPChartsFacturasFilters")) + "," + UrlEncode(StringUtil.RTrim(AV108Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV23ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WPChartsFacturasFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV23ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV22ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WPChartsFacturasFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
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
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV108Pgmname+"GridState",  AV22ManageFiltersXml) ;
               AV10GridState.FromXml(AV22ManageFiltersXml, null, "", "");
               AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
               AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61TFFacturaEstatus_Sels", AV61TFFacturaEstatus_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
      }

      protected void E224G2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV72GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV72GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV72GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV72GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E174G2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "factura.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("factura.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
      }

      protected void E184G2( )
      {
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'OBTIENELISTAUSUARIOS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Utchartdoughnut_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPFacturaEstatusFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV84FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV85ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV102ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartdoughnut.SendProperty(context, "", false, Utchartdoughnut_Internalname, "Object", Utchartdoughnut_Objectcall);
         Utchartcolumnline_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPGraficaFacturasPorMesFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV84FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV85ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV102ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartcolumnline.SendProperty(context, "", false, Utchartcolumnline_Internalname, "Object", Utchartcolumnline_Objectcall);
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV84FromDate, AV85ToDate, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV108Pgmname, AV15FilterFullText, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV61TFFacturaEstatus_Sels, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV64TFMotivoRechazoDescripcion, AV65TFMotivoRechazoDescripcion_Sel) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV102ListaUsuarios", AV102ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E114G2( )
      {
         /* Combo_distribuidorid_Onoptionclicked Routine */
         returnInSub = false;
         AV86DistribuidorID.FromJSonString(Combo_distribuidorid_Selectedvalue_get, null);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV86DistribuidorID", AV86DistribuidorID);
      }

      protected void S162( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S182( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV18ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "PromocionDescripcion",  "",  "Promoción",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "FacturaEstatus",  "",  "Estatus",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "FacturaFechaFactura",  "",  "Fecha Factura",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "FacturaFechaRegistro",  "",  "Fecha Registro",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "FacturaNo",  "",  "No",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "UsuarioNombreCompleto",  "",  "Nombre completo",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "MotivoRechazoDescripcion",  "",  "Motivo de rechazo",  true,  "") ;
         GXt_char2 = AV17UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WPChartsFacturasColumnsSelector", out  GXt_char2) ;
         AV17UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV17UserCustomValue)) ) )
         {
            AV19ColumnsSelectorAux.FromXml(AV17UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV19ColumnsSelectorAux, ref  AV18ColumnsSelector) ;
         }
      }

      protected void S132( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV21ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WPChartsFacturasFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV21ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S192( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV28TFPromocionDescripcion = "";
         AssignAttri("", false, "AV28TFPromocionDescripcion", AV28TFPromocionDescripcion);
         AV29TFPromocionDescripcion_Sel = "";
         AssignAttri("", false, "AV29TFPromocionDescripcion_Sel", AV29TFPromocionDescripcion_Sel);
         AV61TFFacturaEstatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36TFFacturaFechaFactura = DateTime.MinValue;
         AssignAttri("", false, "AV36TFFacturaFechaFactura", context.localUtil.Format(AV36TFFacturaFechaFactura, "99/99/99"));
         AV37TFFacturaFechaFactura_To = DateTime.MinValue;
         AssignAttri("", false, "AV37TFFacturaFechaFactura_To", context.localUtil.Format(AV37TFFacturaFechaFactura_To, "99/99/99"));
         AV41TFFacturaFechaRegistro = DateTime.MinValue;
         AssignAttri("", false, "AV41TFFacturaFechaRegistro", context.localUtil.Format(AV41TFFacturaFechaRegistro, "99/99/99"));
         AV42TFFacturaFechaRegistro_To = DateTime.MinValue;
         AssignAttri("", false, "AV42TFFacturaFechaRegistro_To", context.localUtil.Format(AV42TFFacturaFechaRegistro_To, "99/99/99"));
         AV34TFFacturaNo = "";
         AssignAttri("", false, "AV34TFFacturaNo", AV34TFFacturaNo);
         AV35TFFacturaNo_Sel = "";
         AssignAttri("", false, "AV35TFFacturaNo_Sel", AV35TFFacturaNo_Sel);
         AV48TFUsuarioNombreCompleto = "";
         AssignAttri("", false, "AV48TFUsuarioNombreCompleto", AV48TFUsuarioNombreCompleto);
         AV49TFUsuarioNombreCompleto_Sel = "";
         AssignAttri("", false, "AV49TFUsuarioNombreCompleto_Sel", AV49TFUsuarioNombreCompleto_Sel);
         AV64TFMotivoRechazoDescripcion = "";
         AssignAttri("", false, "AV64TFMotivoRechazoDescripcion", AV64TFMotivoRechazoDescripcion);
         AV65TFMotivoRechazoDescripcion_Sel = "";
         AssignAttri("", false, "AV65TFMotivoRechazoDescripcion_Sel", AV65TFMotivoRechazoDescripcion_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S212( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "factura.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A69FacturaID,9,0));
         CallWebObject(formatLink("factura.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "factura.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A69FacturaID,9,0));
         CallWebObject(formatLink("factura.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20Session.Get(AV108Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV108Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV20Session.Get(AV108Pgmname+"GridState"), null, "", "");
         }
         AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
         AV123GXV1 = 1;
         while ( AV123GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV123GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION") == 0 )
            {
               AV28TFPromocionDescripcion = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFPromocionDescripcion", AV28TFPromocionDescripcion);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION_SEL") == 0 )
            {
               AV29TFPromocionDescripcion_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFPromocionDescripcion_Sel", AV29TFPromocionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURAESTATUS_SEL") == 0 )
            {
               AV60TFFacturaEstatus_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV60TFFacturaEstatus_SelsJson", AV60TFFacturaEstatus_SelsJson);
               AV61TFFacturaEstatus_Sels.FromJSonString(AV60TFFacturaEstatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAFACTURA") == 0 )
            {
               AV36TFFacturaFechaFactura = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV36TFFacturaFechaFactura", context.localUtil.Format(AV36TFFacturaFechaFactura, "99/99/99"));
               AV37TFFacturaFechaFactura_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV37TFFacturaFechaFactura_To", context.localUtil.Format(AV37TFFacturaFechaFactura_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAREGISTRO") == 0 )
            {
               AV41TFFacturaFechaRegistro = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV41TFFacturaFechaRegistro", context.localUtil.Format(AV41TFFacturaFechaRegistro, "99/99/99"));
               AV42TFFacturaFechaRegistro_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV42TFFacturaFechaRegistro_To", context.localUtil.Format(AV42TFFacturaFechaRegistro_To, "99/99/99"));
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
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO") == 0 )
            {
               AV48TFUsuarioNombreCompleto = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFUsuarioNombreCompleto", AV48TFUsuarioNombreCompleto);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO_SEL") == 0 )
            {
               AV49TFUsuarioNombreCompleto_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFUsuarioNombreCompleto_Sel", AV49TFUsuarioNombreCompleto_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMOTIVORECHAZODESCRIPCION") == 0 )
            {
               AV64TFMotivoRechazoDescripcion = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV64TFMotivoRechazoDescripcion", AV64TFMotivoRechazoDescripcion);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMOTIVORECHAZODESCRIPCION_SEL") == 0 )
            {
               AV65TFMotivoRechazoDescripcion_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV65TFMotivoRechazoDescripcion_Sel", AV65TFMotivoRechazoDescripcion_Sel);
            }
            AV123GXV1 = (int)(AV123GXV1+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFPromocionDescripcion_Sel)),  AV29TFPromocionDescripcion_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  (AV61TFFacturaEstatus_Sels.Count==0),  AV60TFFacturaEstatus_SelsJson, out  GXt_char4) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFFacturaNo_Sel)),  AV35TFFacturaNo_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFUsuarioNombreCompleto_Sel)),  AV49TFUsuarioNombreCompleto_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV65TFMotivoRechazoDescripcion_Sel)),  AV65TFMotivoRechazoDescripcion_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|||"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFPromocionDescripcion)),  AV28TFPromocionDescripcion, out  GXt_char7) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFFacturaNo)),  AV34TFFacturaNo, out  GXt_char6) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFUsuarioNombreCompleto)),  AV48TFUsuarioNombreCompleto, out  GXt_char5) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV64TFMotivoRechazoDescripcion)),  AV64TFMotivoRechazoDescripcion, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char7+"||"+((DateTime.MinValue==AV36TFFacturaFechaFactura) ? "" : context.localUtil.DToC( AV36TFFacturaFechaFactura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV41TFFacturaFechaRegistro) ? "" : context.localUtil.DToC( AV41TFFacturaFechaRegistro, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char4;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV37TFFacturaFechaFactura_To) ? "" : context.localUtil.DToC( AV37TFFacturaFechaFactura_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV42TFFacturaFechaRegistro_To) ? "" : context.localUtil.DToC( AV42TFFacturaFechaRegistro_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV20Session.Get(AV108Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROMOCIONDESCRIPCION",  context.GetMessage( "Promoción", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFPromocionDescripcion)),  0,  AV28TFPromocionDescripcion,  AV28TFPromocionDescripcion,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFPromocionDescripcion_Sel)),  AV29TFPromocionDescripcion_Sel,  AV29TFPromocionDescripcion_Sel) ;
         AV73AuxText = ((AV61TFFacturaEstatus_Sels.Count==1) ? "["+AV61TFFacturaEstatus_Sels.GetString(1)+"]" : context.GetMessage( "WWP_FilterValueDescription_MultipleValues", ""));
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFACTURAESTATUS_SEL",  context.GetMessage( "Estatus", ""),  !(AV61TFFacturaEstatus_Sels.Count==0),  0,  AV61TFFacturaEstatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV73AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV73AuxText, "[En Proceso]", context.GetMessage( "En Proceso", "")), "[Aprobada]", context.GetMessage( "Aprobada", "")), "[Rechazada]", context.GetMessage( "Rechazada", "")), "[Cancelada]", context.GetMessage( "Cancelada", ""))),  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFACTURAFECHAFACTURA",  context.GetMessage( "Fecha Factura", ""),  !((DateTime.MinValue==AV36TFFacturaFechaFactura)&&(DateTime.MinValue==AV37TFFacturaFechaFactura_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV36TFFacturaFechaFactura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV36TFFacturaFechaFactura) ? "" : StringUtil.Trim( context.localUtil.Format( AV36TFFacturaFechaFactura, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV37TFFacturaFechaFactura_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV37TFFacturaFechaFactura_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV37TFFacturaFechaFactura_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFACTURAFECHAREGISTRO",  context.GetMessage( "Fecha Registro", ""),  !((DateTime.MinValue==AV41TFFacturaFechaRegistro)&&(DateTime.MinValue==AV42TFFacturaFechaRegistro_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV41TFFacturaFechaRegistro, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV41TFFacturaFechaRegistro) ? "" : StringUtil.Trim( context.localUtil.Format( AV41TFFacturaFechaRegistro, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV42TFFacturaFechaRegistro_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV42TFFacturaFechaRegistro_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV42TFFacturaFechaRegistro_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFFACTURANO",  context.GetMessage( "No", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFFacturaNo)),  0,  AV34TFFacturaNo,  AV34TFFacturaNo,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFFacturaNo_Sel)),  AV35TFFacturaNo_Sel,  AV35TFFacturaNo_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFUSUARIONOMBRECOMPLETO",  context.GetMessage( "Nombre completo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFUsuarioNombreCompleto)),  0,  AV48TFUsuarioNombreCompleto,  AV48TFUsuarioNombreCompleto,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFUsuarioNombreCompleto_Sel)),  AV49TFUsuarioNombreCompleto_Sel,  AV49TFUsuarioNombreCompleto_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFMOTIVORECHAZODESCRIPCION",  context.GetMessage( "Motivo de rechazo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV64TFMotivoRechazoDescripcion)),  0,  AV64TFMotivoRechazoDescripcion,  AV64TFMotivoRechazoDescripcion,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV65TFMotivoRechazoDescripcion_Sel)),  AV65TFMotivoRechazoDescripcion_Sel,  AV65TFMotivoRechazoDescripcion_Sel) ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV108Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S142( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV108Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Factura";
         AV20Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void S122( )
      {
         /* 'LOADCOMBODISTRIBUIDORID' Routine */
         returnInSub = false;
         /* Using cursor H004G4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A10DistribuidorID = H004G4_A10DistribuidorID[0];
            A11DistribuidorDescripcion = H004G4_A11DistribuidorDescripcion[0];
            AV88Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV88Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A10DistribuidorID), 9, 0));
            AV88Combo_DataItem.gxTpr_Title = A11DistribuidorDescripcion;
            AV87DistribuidorID_Data.Add(AV88Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_distribuidorid_Selectedvalue_set = AV86DistribuidorID.ToJSonString(false);
         ucCombo_distribuidorid.SendProperty(context, "", false, Combo_distribuidorid_Internalname, "SelectedValue_set", Combo_distribuidorid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'OBTIENELISTAUSUARIOS' Routine */
         returnInSub = false;
         AV102ListaUsuarios.Clear();
         if ( AV86DistribuidorID.Count == 0 )
         {
            /* Using cursor H004G5 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               A40UsuarioRol = H004G5_A40UsuarioRol[0];
               A29UsuarioID = H004G5_A29UsuarioID[0];
               A40UsuarioRol = H004G5_A40UsuarioRol[0];
               AV98Pasa = false;
               AV126GXV2 = 1;
               while ( AV126GXV2 <= AV102ListaUsuarios.Count )
               {
                  AV100UsuariosListaID = (int)(AV102ListaUsuarios.GetNumeric(AV126GXV2));
                  if ( AV100UsuariosListaID == A29UsuarioID )
                  {
                     AV98Pasa = true;
                     if (true) break;
                  }
                  AV126GXV2 = (int)(AV126GXV2+1);
               }
               if ( ! AV98Pasa )
               {
                  AV102ListaUsuarios.Add(A29UsuarioID, 0);
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
         else
         {
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 A10DistribuidorID ,
                                                 AV86DistribuidorID ,
                                                 A40UsuarioRol } ,
                                                 new int[]{
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor H004G6 */
            pr_default.execute(4);
            while ( (pr_default.getStatus(4) != 101) )
            {
               A40UsuarioRol = H004G6_A40UsuarioRol[0];
               A10DistribuidorID = H004G6_A10DistribuidorID[0];
               A29UsuarioID = H004G6_A29UsuarioID[0];
               A40UsuarioRol = H004G6_A40UsuarioRol[0];
               AV98Pasa = false;
               AV128GXV3 = 1;
               while ( AV128GXV3 <= AV102ListaUsuarios.Count )
               {
                  AV100UsuariosListaID = (int)(AV102ListaUsuarios.GetNumeric(AV128GXV3));
                  if ( AV100UsuariosListaID == A29UsuarioID )
                  {
                     AV98Pasa = true;
                     if (true) break;
                  }
                  AV128GXV3 = (int)(AV128GXV3+1);
               }
               if ( ! AV98Pasa )
               {
                  AV102ListaUsuarios.Add(A29UsuarioID, 0);
               }
               pr_default.readNext(4);
            }
            pr_default.close(4);
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
         PA4G2( ) ;
         WS4G2( ) ;
         WE4G2( ) ;
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202651111311615", true, true);
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
         context.AddJavascriptSource("wpchartsfacturas.js", "?202651111311615", false, true);
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

      protected void SubsflControlProps_672( )
      {
         edtFacturaID_Internalname = "FACTURAID_"+sGXsfl_67_idx;
         edtUsuarioID_Internalname = "USUARIOID_"+sGXsfl_67_idx;
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION_"+sGXsfl_67_idx;
         cmbFacturaEstatus_Internalname = "FACTURAESTATUS_"+sGXsfl_67_idx;
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA_"+sGXsfl_67_idx;
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO_"+sGXsfl_67_idx;
         edtFacturaNo_Internalname = "FACTURANO_"+sGXsfl_67_idx;
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO_"+sGXsfl_67_idx;
         edtMotivoRechazoDescripcion_Internalname = "MOTIVORECHAZODESCRIPCION_"+sGXsfl_67_idx;
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_67_idx;
      }

      protected void SubsflControlProps_fel_672( )
      {
         edtFacturaID_Internalname = "FACTURAID_"+sGXsfl_67_fel_idx;
         edtUsuarioID_Internalname = "USUARIOID_"+sGXsfl_67_fel_idx;
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION_"+sGXsfl_67_fel_idx;
         cmbFacturaEstatus_Internalname = "FACTURAESTATUS_"+sGXsfl_67_fel_idx;
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA_"+sGXsfl_67_fel_idx;
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO_"+sGXsfl_67_fel_idx;
         edtFacturaNo_Internalname = "FACTURANO_"+sGXsfl_67_fel_idx;
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO_"+sGXsfl_67_fel_idx;
         edtMotivoRechazoDescripcion_Internalname = "MOTIVORECHAZODESCRIPCION_"+sGXsfl_67_fel_idx;
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_67_fel_idx;
      }

      protected void sendrow_672( )
      {
         sGXsfl_67_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_67_idx), 4, 0), 4, "0");
         SubsflControlProps_672( ) ;
         WB4G0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPromocionDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionDescripcion_Internalname,(string)A42PromocionDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPromocionDescripcion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbFacturaEstatus.Visible==0) ? "display:none;" : "")+"\">") ;
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
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbFacturaEstatus,(string)cmbFacturaEstatus_Internalname,StringUtil.RTrim( A80FacturaEstatus),(short)1,(string)cmbFacturaEstatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbFacturaEstatus.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbFacturaEstatus.CurrentValue = StringUtil.RTrim( A80FacturaEstatus);
            AssignProp("", false, cmbFacturaEstatus_Internalname, "Values", (string)(cmbFacturaEstatus.ToJavascriptSource()), !bGXsfl_67_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtFacturaFechaFactura_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaFactura_Internalname,context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"),context.localUtil.Format( A73FacturaFechaFactura, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaFactura_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtFacturaFechaFactura_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtFacturaFechaRegistro_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaRegistro_Internalname,context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"),context.localUtil.Format( A72FacturaFechaRegistro, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaRegistro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtFacturaFechaRegistro_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtFacturaNo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaNo_Internalname,StringUtil.RTrim( A71FacturaNo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaNo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtFacturaNo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtUsuarioNombreCompleto_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombreCompleto_Internalname,(string)A52UsuarioNombreCompleto,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombreCompleto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtUsuarioNombreCompleto_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMotivoRechazoDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoRechazoDescripcion_Internalname,(string)A20MotivoRechazoDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoRechazoDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMotivoRechazoDescripcion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)67,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_67_idx + "',67)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_67_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV72GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV72GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV72GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV72GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_67_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_67_Refreshing);
            send_integrity_lvl_hashes4G2( ) ;
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
            A80FacturaEstatus = cmbFacturaEstatus.getValidValue(A80FacturaEstatus);
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_67_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV72GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV72GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV72GridActions), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl67( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"67\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPromocionDescripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Promoción", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbFacturaEstatus.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estatus", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtFacturaFechaFactura_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Factura", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtFacturaFechaRegistro_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Registro", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtFacturaNo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "No", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtUsuarioNombreCompleto_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre completo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMotivoRechazoDescripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Motivo de rechazo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A42PromocionDescripcion));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPromocionDescripcion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A80FacturaEstatus)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFacturaEstatus.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A73FacturaFechaFactura, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaFechaFactura_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaFechaRegistro_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A71FacturaNo)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaNo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A52UsuarioNombreCompleto));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioNombreCompleto_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A20MotivoRechazoDescripcion));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMotivoRechazoDescripcion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV72GridActions), 4, 0, ".", ""))));
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
         lblTextblockcombo_distribuidorid_Internalname = "TEXTBLOCKCOMBO_DISTRIBUIDORID";
         Combo_distribuidorid_Internalname = "COMBO_DISTRIBUIDORID";
         divTablesplitteddistribuidorid_Internalname = "TABLESPLITTEDDISTRIBUIDORID";
         bttBtnuseraction1_Internalname = "BTNUSERACTION1";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Utchartdoughnut_Internalname = "UTCHARTDOUGHNUT";
         Utchartcolumnline_Internalname = "UTCHARTCOLUMNLINE";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtFacturaID_Internalname = "FACTURAID";
         edtUsuarioID_Internalname = "USUARIOID";
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION";
         cmbFacturaEstatus_Internalname = "FACTURAESTATUS";
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA";
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO";
         edtFacturaNo_Internalname = "FACTURANO";
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO";
         edtMotivoRechazoDescripcion_Internalname = "MOTIVORECHAZODESCRIPCION";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_facturafechafacturaauxdatetext_Internalname = "vDDO_FACTURAFECHAFACTURAAUXDATETEXT";
         Tffacturafechafactura_rangepicker_Internalname = "TFFACTURAFECHAFACTURA_RANGEPICKER";
         divDdo_facturafechafacturaauxdates_Internalname = "DDO_FACTURAFECHAFACTURAAUXDATES";
         edtavDdo_facturafecharegistroauxdatetext_Internalname = "vDDO_FACTURAFECHAREGISTROAUXDATETEXT";
         Tffacturafecharegistro_rangepicker_Internalname = "TFFACTURAFECHAREGISTRO_RANGEPICKER";
         divDdo_facturafecharegistroauxdates_Internalname = "DDO_FACTURAFECHAREGISTROAUXDATES";
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
         cmbavGridactions_Jsonclick = "";
         edtMotivoRechazoDescripcion_Jsonclick = "";
         edtUsuarioNombreCompleto_Jsonclick = "";
         edtFacturaNo_Jsonclick = "";
         edtFacturaFechaRegistro_Jsonclick = "";
         edtFacturaFechaFactura_Jsonclick = "";
         cmbFacturaEstatus_Jsonclick = "";
         edtPromocionDescripcion_Jsonclick = "";
         edtUsuarioID_Jsonclick = "";
         edtFacturaID_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridNoBorder WorkWith";
         subGrid_Backcolorstyle = 0;
         edtMotivoRechazoDescripcion_Visible = -1;
         edtUsuarioNombreCompleto_Visible = -1;
         edtFacturaNo_Visible = -1;
         edtFacturaFechaRegistro_Visible = -1;
         edtFacturaFechaFactura_Visible = -1;
         cmbFacturaEstatus.Visible = -1;
         edtPromocionDescripcion_Visible = -1;
         edtMotivoRechazoDescripcion_Enabled = 0;
         edtUsuarioNombreCompleto_Enabled = 0;
         edtFacturaNo_Enabled = 0;
         edtFacturaFechaRegistro_Enabled = 0;
         edtFacturaFechaFactura_Enabled = 0;
         cmbFacturaEstatus.Enabled = 0;
         edtPromocionDescripcion_Enabled = 0;
         edtUsuarioID_Enabled = 0;
         edtFacturaID_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_facturafecharegistroauxdatetext_Jsonclick = "";
         edtavDdo_facturafechafacturaauxdatetext_Jsonclick = "";
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Combo_distribuidorid_Caption = "";
         edtavTodate_Jsonclick = "";
         edtavTodate_Enabled = 1;
         edtavFromdate_Jsonclick = "";
         edtavFromdate_Enabled = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Datalistproc = "WPChartsFacturasGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|En Proceso:En Proceso,Aprobada:Aprobada,Rechazada:Rechazada,Cancelada:Cancelada|||||";
         Ddo_grid_Allowmultipleselection = "|T|||||";
         Ddo_grid_Datalisttype = "Dynamic|FixedValues|||Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T|T|||T|T|T";
         Ddo_grid_Filterisrange = "||P|P|||";
         Ddo_grid_Filtertype = "Character||Date|Date|Character|Character|Character";
         Ddo_grid_Includefilter = "T||T|T|T|T|T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|T||T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|1||6";
         Ddo_grid_Columnids = "2:PromocionDescripcion|3:FacturaEstatus|4:FacturaFechaFactura|5:FacturaFechaRegistro|6:FacturaNo|7:UsuarioNombreCompleto|8:MotivoRechazoDescripcion";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( " Factura", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV84FromDate","fld":"vFROMDATE"},{"av":"AV85ToDate","fld":"vTODATE"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV108Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV61TFFacturaEstatus_Sels","fld":"vTFFACTURAESTATUS_SELS"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV64TFMotivoRechazoDescripcion","fld":"vTFMOTIVORECHAZODESCRIPCION"},{"av":"AV65TFMotivoRechazoDescripcion_Sel","fld":"vTFMOTIVORECHAZODESCRIPCION_SEL"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"cmbFacturaEstatus"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtMotivoRechazoDescripcion_Visible","ctrl":"MOTIVORECHAZODESCRIPCION","prop":"Visible"},{"av":"AV69GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV70GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV71GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E134G2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV84FromDate","fld":"vFROMDATE"},{"av":"AV85ToDate","fld":"vTODATE"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV108Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV61TFFacturaEstatus_Sels","fld":"vTFFACTURAESTATUS_SELS"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV64TFMotivoRechazoDescripcion","fld":"vTFMOTIVORECHAZODESCRIPCION"},{"av":"AV65TFMotivoRechazoDescripcion_Sel","fld":"vTFMOTIVORECHAZODESCRIPCION_SEL"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E144G2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV84FromDate","fld":"vFROMDATE"},{"av":"AV85ToDate","fld":"vTODATE"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV108Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV61TFFacturaEstatus_Sels","fld":"vTFFACTURAESTATUS_SELS"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV64TFMotivoRechazoDescripcion","fld":"vTFMOTIVORECHAZODESCRIPCION"},{"av":"AV65TFMotivoRechazoDescripcion_Sel","fld":"vTFMOTIVORECHAZODESCRIPCION_SEL"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E154G2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV84FromDate","fld":"vFROMDATE"},{"av":"AV85ToDate","fld":"vTODATE"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV108Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV61TFFacturaEstatus_Sels","fld":"vTFFACTURAESTATUS_SELS"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV64TFMotivoRechazoDescripcion","fld":"vTFMOTIVORECHAZODESCRIPCION"},{"av":"AV65TFMotivoRechazoDescripcion_Sel","fld":"vTFMOTIVORECHAZODESCRIPCION_SEL"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV64TFMotivoRechazoDescripcion","fld":"vTFMOTIVORECHAZODESCRIPCION"},{"av":"AV65TFMotivoRechazoDescripcion_Sel","fld":"vTFMOTIVORECHAZODESCRIPCION_SEL"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV60TFFacturaEstatus_SelsJson","fld":"vTFFACTURAESTATUS_SELSJSON"},{"av":"AV61TFFacturaEstatus_Sels","fld":"vTFFACTURAESTATUS_SELS"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E214G2","iparms":[]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavGridactions"},{"av":"AV72GridActions","fld":"vGRIDACTIONS","pic":"ZZZ9"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E164G2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV84FromDate","fld":"vFROMDATE"},{"av":"AV85ToDate","fld":"vTODATE"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV108Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV61TFFacturaEstatus_Sels","fld":"vTFFACTURAESTATUS_SELS"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV64TFMotivoRechazoDescripcion","fld":"vTFMOTIVORECHAZODESCRIPCION"},{"av":"AV65TFMotivoRechazoDescripcion_Sel","fld":"vTFMOTIVORECHAZODESCRIPCION_SEL"},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"cmbFacturaEstatus"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtMotivoRechazoDescripcion_Visible","ctrl":"MOTIVORECHAZODESCRIPCION","prop":"Visible"},{"av":"AV69GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV70GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV71GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E124G2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV84FromDate","fld":"vFROMDATE"},{"av":"AV85ToDate","fld":"vTODATE"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV108Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV61TFFacturaEstatus_Sels","fld":"vTFFACTURAESTATUS_SELS"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV64TFMotivoRechazoDescripcion","fld":"vTFMOTIVORECHAZODESCRIPCION"},{"av":"AV65TFMotivoRechazoDescripcion_Sel","fld":"vTFMOTIVORECHAZODESCRIPCION_SEL"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV60TFFacturaEstatus_SelsJson","fld":"vTFFACTURAESTATUS_SELSJSON"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV61TFFacturaEstatus_Sels","fld":"vTFFACTURAESTATUS_SELS"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV64TFMotivoRechazoDescripcion","fld":"vTFMOTIVORECHAZODESCRIPCION"},{"av":"AV65TFMotivoRechazoDescripcion_Sel","fld":"vTFMOTIVORECHAZODESCRIPCION_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV60TFFacturaEstatus_SelsJson","fld":"vTFFACTURAESTATUS_SELSJSON"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"cmbFacturaEstatus"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtMotivoRechazoDescripcion_Visible","ctrl":"MOTIVORECHAZODESCRIPCION","prop":"Visible"},{"av":"AV69GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV70GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV71GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VGRIDACTIONS.CLICK","""{"handler":"E224G2","iparms":[{"av":"cmbavGridactions"},{"av":"AV72GridActions","fld":"vGRIDACTIONS","pic":"ZZZ9"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"}]""");
         setEventMetadata("VGRIDACTIONS.CLICK",""","oparms":[{"av":"cmbavGridactions"},{"av":"AV72GridActions","fld":"vGRIDACTIONS","pic":"ZZZ9"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E174G2","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"}]}""");
         setEventMetadata("'DOUSERACTION1'","""{"handler":"E184G2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV84FromDate","fld":"vFROMDATE"},{"av":"AV85ToDate","fld":"vTODATE"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV108Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV61TFFacturaEstatus_Sels","fld":"vTFFACTURAESTATUS_SELS"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV64TFMotivoRechazoDescripcion","fld":"vTFMOTIVORECHAZODESCRIPCION"},{"av":"AV65TFMotivoRechazoDescripcion_Sel","fld":"vTFMOTIVORECHAZODESCRIPCION_SEL"},{"av":"AV102ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV86DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"}]""");
         setEventMetadata("'DOUSERACTION1'",""","oparms":[{"ctrl":"UTCHARTDOUGHNUT"},{"ctrl":"UTCHARTCOLUMNLINE"},{"av":"AV102ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"cmbFacturaEstatus"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtMotivoRechazoDescripcion_Visible","ctrl":"MOTIVORECHAZODESCRIPCION","prop":"Visible"},{"av":"AV69GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV70GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV71GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("COMBO_DISTRIBUIDORID.ONOPTIONCLICKED","""{"handler":"E114G2","iparms":[{"av":"Combo_distribuidorid_Selectedvalue_get","ctrl":"COMBO_DISTRIBUIDORID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_DISTRIBUIDORID.ONOPTIONCLICKED",""","oparms":[{"av":"AV86DistribuidorID","fld":"vDISTRIBUIDORID"}]}""");
         setEventMetadata("VALIDV_FROMDATE","""{"handler":"Validv_Fromdate","iparms":[]}""");
         setEventMetadata("VALIDV_TODATE","""{"handler":"Validv_Todate","iparms":[]}""");
         setEventMetadata("VALID_USUARIOID","""{"handler":"Valid_Usuarioid","iparms":[]}""");
         setEventMetadata("VALID_PROMOCIONDESCRIPCION","""{"handler":"Valid_Promociondescripcion","iparms":[]}""");
         setEventMetadata("VALID_FACTURAESTATUS","""{"handler":"Valid_Facturaestatus","iparms":[]}""");
         setEventMetadata("VALID_FACTURANO","""{"handler":"Valid_Facturano","iparms":[]}""");
         setEventMetadata("VALID_USUARIONOMBRECOMPLETO","""{"handler":"Valid_Usuarionombrecompleto","iparms":[]}""");
         setEventMetadata("VALID_MOTIVORECHAZODESCRIPCION","""{"handler":"Valid_Motivorechazodescripcion","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gridactions","iparms":[]}""");
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
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Combo_distribuidorid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV84FromDate = DateTime.MinValue;
         AV85ToDate = DateTime.MinValue;
         AV18ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV108Pgmname = "";
         AV15FilterFullText = "";
         AV28TFPromocionDescripcion = "";
         AV29TFPromocionDescripcion_Sel = "";
         AV61TFFacturaEstatus_Sels = new GxSimpleCollection<string>();
         AV36TFFacturaFechaFactura = DateTime.MinValue;
         AV37TFFacturaFechaFactura_To = DateTime.MinValue;
         AV41TFFacturaFechaRegistro = DateTime.MinValue;
         AV42TFFacturaFechaRegistro_To = DateTime.MinValue;
         AV34TFFacturaNo = "";
         AV35TFFacturaNo_Sel = "";
         AV48TFUsuarioNombreCompleto = "";
         AV49TFUsuarioNombreCompleto_Sel = "";
         AV64TFMotivoRechazoDescripcion = "";
         AV65TFMotivoRechazoDescripcion_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV67DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV87DistribuidorID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV74Elements = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         AV75Parameters = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter>( context, "Parameter", "GeneXus.Reporting");
         AV76ItemClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData(context);
         AV77ItemDoubleClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData(context);
         AV78DragAndDropData = new GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData(context);
         AV79FilterChangedData = new GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData(context);
         AV80ItemExpandData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData(context);
         AV81ItemCollapseData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData(context);
         AV21ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV71GridAppliedFilters = "";
         AV39DDO_FacturaFechaFacturaAuxDateTo = DateTime.MinValue;
         AV44DDO_FacturaFechaRegistroAuxDateTo = DateTime.MinValue;
         AV10GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV60TFFacturaEstatus_SelsJson = "";
         AV102ListaUsuarios = new GxSimpleCollection<int>();
         AV86DistribuidorID = new GxSimpleCollection<int>();
         A40UsuarioRol = "";
         AV38DDO_FacturaFechaFacturaAuxDate = DateTime.MinValue;
         AV43DDO_FacturaFechaRegistroAuxDate = DateTime.MinValue;
         Combo_distribuidorid_Selectedvalue_set = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         lblTextblockcombo_distribuidorid_Jsonclick = "";
         ucCombo_distribuidorid = new GXUserControl();
         ClassString = "";
         StyleString = "";
         bttBtnuseraction1_Jsonclick = "";
         ucUtchartdoughnut = new GXUserControl();
         ucUtchartcolumnline = new GXUserControl();
         bttBtninsert_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV40DDO_FacturaFechaFacturaAuxDateText = "";
         ucTffacturafechafactura_rangepicker = new GXUserControl();
         AV45DDO_FacturaFechaRegistroAuxDateText = "";
         ucTffacturafecharegistro_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A42PromocionDescripcion = "";
         A80FacturaEstatus = "";
         A73FacturaFechaFactura = DateTime.MinValue;
         A72FacturaFechaRegistro = DateTime.MinValue;
         A71FacturaNo = "";
         A52UsuarioNombreCompleto = "";
         A20MotivoRechazoDescripcion = "";
         AV109Wpchartsfacturasds_1_filterfulltext = "";
         AV110Wpchartsfacturasds_2_tfpromociondescripcion = "";
         AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel = "";
         AV112Wpchartsfacturasds_4_tffacturaestatus_sels = new GxSimpleCollection<string>();
         AV113Wpchartsfacturasds_5_tffacturafechafactura = DateTime.MinValue;
         AV114Wpchartsfacturasds_6_tffacturafechafactura_to = DateTime.MinValue;
         AV115Wpchartsfacturasds_7_tffacturafecharegistro = DateTime.MinValue;
         AV116Wpchartsfacturasds_8_tffacturafecharegistro_to = DateTime.MinValue;
         AV117Wpchartsfacturasds_9_tffacturano = "";
         AV118Wpchartsfacturasds_10_tffacturano_sel = "";
         AV119Wpchartsfacturasds_11_tfusuarionombrecompleto = "";
         AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel = "";
         AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion = "";
         AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel = "";
         lV109Wpchartsfacturasds_1_filterfulltext = "";
         lV110Wpchartsfacturasds_2_tfpromociondescripcion = "";
         lV117Wpchartsfacturasds_9_tffacturano = "";
         lV119Wpchartsfacturasds_11_tfusuarionombrecompleto = "";
         lV121Wpchartsfacturasds_13_tfmotivorechazodescripcion = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         H004G2_A41PromocionID = new int[1] ;
         H004G2_A19MotivoRechazoID = new int[1] ;
         H004G2_A93FacturaCompleta = new bool[] {false} ;
         H004G2_A20MotivoRechazoDescripcion = new string[] {""} ;
         H004G2_A52UsuarioNombreCompleto = new string[] {""} ;
         H004G2_A71FacturaNo = new string[] {""} ;
         H004G2_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         H004G2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         H004G2_A80FacturaEstatus = new string[] {""} ;
         H004G2_A42PromocionDescripcion = new string[] {""} ;
         H004G2_A29UsuarioID = new int[1] ;
         H004G2_A69FacturaID = new int[1] ;
         H004G2_A30UsuarioNombre = new string[] {""} ;
         H004G2_A51UsuarioApellido = new string[] {""} ;
         H004G3_A41PromocionID = new int[1] ;
         H004G3_A19MotivoRechazoID = new int[1] ;
         H004G3_A93FacturaCompleta = new bool[] {false} ;
         H004G3_A20MotivoRechazoDescripcion = new string[] {""} ;
         H004G3_A52UsuarioNombreCompleto = new string[] {""} ;
         H004G3_A71FacturaNo = new string[] {""} ;
         H004G3_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         H004G3_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         H004G3_A80FacturaEstatus = new string[] {""} ;
         H004G3_A42PromocionDescripcion = new string[] {""} ;
         H004G3_A29UsuarioID = new int[1] ;
         H004G3_A69FacturaID = new int[1] ;
         H004G3_A30UsuarioNombre = new string[] {""} ;
         H004G3_A51UsuarioApellido = new string[] {""} ;
         AV7HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV20Session = context.GetSession();
         AV16ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV22ManageFiltersXml = "";
         AV17UserCustomValue = "";
         AV19ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV11GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV73AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         H004G4_A10DistribuidorID = new int[1] ;
         H004G4_A11DistribuidorDescripcion = new string[] {""} ;
         A11DistribuidorDescripcion = "";
         AV88Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         H004G5_A81DistribuidoresUsuarioID = new int[1] ;
         H004G5_A40UsuarioRol = new string[] {""} ;
         H004G5_A29UsuarioID = new int[1] ;
         H004G6_A81DistribuidoresUsuarioID = new int[1] ;
         H004G6_A40UsuarioRol = new string[] {""} ;
         H004G6_A10DistribuidorID = new int[1] ;
         H004G6_A29UsuarioID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpchartsfacturas__default(),
            new Object[][] {
                new Object[] {
               H004G2_A41PromocionID, H004G2_A19MotivoRechazoID, H004G2_A93FacturaCompleta, H004G2_A20MotivoRechazoDescripcion, H004G2_A52UsuarioNombreCompleto, H004G2_A71FacturaNo, H004G2_A72FacturaFechaRegistro, H004G2_A73FacturaFechaFactura, H004G2_A80FacturaEstatus, H004G2_A42PromocionDescripcion,
               H004G2_A29UsuarioID, H004G2_A69FacturaID, H004G2_A30UsuarioNombre, H004G2_A51UsuarioApellido
               }
               , new Object[] {
               H004G3_A41PromocionID, H004G3_A19MotivoRechazoID, H004G3_A93FacturaCompleta, H004G3_A20MotivoRechazoDescripcion, H004G3_A52UsuarioNombreCompleto, H004G3_A71FacturaNo, H004G3_A72FacturaFechaRegistro, H004G3_A73FacturaFechaFactura, H004G3_A80FacturaEstatus, H004G3_A42PromocionDescripcion,
               H004G3_A29UsuarioID, H004G3_A69FacturaID, H004G3_A30UsuarioNombre, H004G3_A51UsuarioApellido
               }
               , new Object[] {
               H004G4_A10DistribuidorID, H004G4_A11DistribuidorDescripcion
               }
               , new Object[] {
               H004G5_A81DistribuidoresUsuarioID, H004G5_A40UsuarioRol, H004G5_A29UsuarioID
               }
               , new Object[] {
               H004G6_A81DistribuidoresUsuarioID, H004G6_A40UsuarioRol, H004G6_A10DistribuidorID, H004G6_A29UsuarioID
               }
            }
         );
         AV108Pgmname = "WPChartsFacturas";
         /* GeneXus formulas. */
         AV108Pgmname = "WPChartsFacturas";
      }

      private short GRID_nEOF ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV12OrderedBy ;
      private short AV23ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV72GridActions ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_67 ;
      private int nGXsfl_67_idx=1 ;
      private int A10DistribuidorID ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFromdate_Enabled ;
      private int edtavTodate_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int A69FacturaID ;
      private int A29UsuarioID ;
      private int subGrid_Islastpage ;
      private int AV112Wpchartsfacturasds_4_tffacturaestatus_sels_Count ;
      private int A41PromocionID ;
      private int A19MotivoRechazoID ;
      private int edtFacturaID_Enabled ;
      private int edtUsuarioID_Enabled ;
      private int edtPromocionDescripcion_Enabled ;
      private int edtFacturaFechaFactura_Enabled ;
      private int edtFacturaFechaRegistro_Enabled ;
      private int edtFacturaNo_Enabled ;
      private int edtUsuarioNombreCompleto_Enabled ;
      private int edtMotivoRechazoDescripcion_Enabled ;
      private int edtPromocionDescripcion_Visible ;
      private int edtFacturaFechaFactura_Visible ;
      private int edtFacturaFechaRegistro_Visible ;
      private int edtFacturaNo_Visible ;
      private int edtUsuarioNombreCompleto_Visible ;
      private int edtMotivoRechazoDescripcion_Visible ;
      private int AV68PageToGo ;
      private int AV123GXV1 ;
      private int AV126GXV2 ;
      private int AV100UsuariosListaID ;
      private int AV128GXV3 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV69GridCurrentPage ;
      private long AV70GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Combo_distribuidorid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_67_idx="0001" ;
      private string AV108Pgmname ;
      private string AV34TFFacturaNo ;
      private string AV35TFFacturaNo_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A40UsuarioRol ;
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
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
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
      private string bttBtnuseraction1_Internalname ;
      private string bttBtnuseraction1_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string Utchartdoughnut_Internalname ;
      private string Utchartcolumnline_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
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
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_facturafechafacturaauxdates_Internalname ;
      private string edtavDdo_facturafechafacturaauxdatetext_Internalname ;
      private string edtavDdo_facturafechafacturaauxdatetext_Jsonclick ;
      private string Tffacturafechafactura_rangepicker_Internalname ;
      private string divDdo_facturafecharegistroauxdates_Internalname ;
      private string edtavDdo_facturafecharegistroauxdatetext_Internalname ;
      private string edtavDdo_facturafecharegistroauxdatetext_Jsonclick ;
      private string Tffacturafecharegistro_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtFacturaID_Internalname ;
      private string edtUsuarioID_Internalname ;
      private string edtPromocionDescripcion_Internalname ;
      private string cmbFacturaEstatus_Internalname ;
      private string A80FacturaEstatus ;
      private string edtFacturaFechaFactura_Internalname ;
      private string edtFacturaFechaRegistro_Internalname ;
      private string A71FacturaNo ;
      private string edtFacturaNo_Internalname ;
      private string edtUsuarioNombreCompleto_Internalname ;
      private string edtMotivoRechazoDescripcion_Internalname ;
      private string cmbavGridactions_Internalname ;
      private string AV117Wpchartsfacturasds_9_tffacturano ;
      private string AV118Wpchartsfacturasds_10_tffacturano_sel ;
      private string lV117Wpchartsfacturasds_9_tffacturano ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string sGXsfl_67_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtFacturaID_Jsonclick ;
      private string edtUsuarioID_Jsonclick ;
      private string edtPromocionDescripcion_Jsonclick ;
      private string GXCCtl ;
      private string cmbFacturaEstatus_Jsonclick ;
      private string edtFacturaFechaFactura_Jsonclick ;
      private string edtFacturaFechaRegistro_Jsonclick ;
      private string edtFacturaNo_Jsonclick ;
      private string edtUsuarioNombreCompleto_Jsonclick ;
      private string edtMotivoRechazoDescripcion_Jsonclick ;
      private string cmbavGridactions_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV84FromDate ;
      private DateTime AV85ToDate ;
      private DateTime AV36TFFacturaFechaFactura ;
      private DateTime AV37TFFacturaFechaFactura_To ;
      private DateTime AV41TFFacturaFechaRegistro ;
      private DateTime AV42TFFacturaFechaRegistro_To ;
      private DateTime AV39DDO_FacturaFechaFacturaAuxDateTo ;
      private DateTime AV44DDO_FacturaFechaRegistroAuxDateTo ;
      private DateTime AV38DDO_FacturaFechaFacturaAuxDate ;
      private DateTime AV43DDO_FacturaFechaRegistroAuxDate ;
      private DateTime A73FacturaFechaFactura ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime AV113Wpchartsfacturasds_5_tffacturafechafactura ;
      private DateTime AV114Wpchartsfacturasds_6_tffacturafechafactura_to ;
      private DateTime AV115Wpchartsfacturasds_7_tffacturafecharegistro ;
      private DateTime AV116Wpchartsfacturasds_8_tffacturafecharegistro_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool Combo_distribuidorid_Allowmultipleselection ;
      private bool Combo_distribuidorid_Includeonlyselectedoption ;
      private bool Combo_distribuidorid_Emptyitem ;
      private bool Utchartdoughnut_Showvalues ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool A93FacturaCompleta ;
      private bool bGXsfl_67_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV98Pasa ;
      private string AV60TFFacturaEstatus_SelsJson ;
      private string AV16ColumnsSelectorXML ;
      private string AV22ManageFiltersXml ;
      private string AV17UserCustomValue ;
      private string AV15FilterFullText ;
      private string AV28TFPromocionDescripcion ;
      private string AV29TFPromocionDescripcion_Sel ;
      private string AV48TFUsuarioNombreCompleto ;
      private string AV49TFUsuarioNombreCompleto_Sel ;
      private string AV64TFMotivoRechazoDescripcion ;
      private string AV65TFMotivoRechazoDescripcion_Sel ;
      private string AV71GridAppliedFilters ;
      private string AV40DDO_FacturaFechaFacturaAuxDateText ;
      private string AV45DDO_FacturaFechaRegistroAuxDateText ;
      private string A42PromocionDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string A20MotivoRechazoDescripcion ;
      private string AV109Wpchartsfacturasds_1_filterfulltext ;
      private string AV110Wpchartsfacturasds_2_tfpromociondescripcion ;
      private string AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel ;
      private string AV119Wpchartsfacturasds_11_tfusuarionombrecompleto ;
      private string AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel ;
      private string AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion ;
      private string AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel ;
      private string lV109Wpchartsfacturasds_1_filterfulltext ;
      private string lV110Wpchartsfacturasds_2_tfpromociondescripcion ;
      private string lV119Wpchartsfacturasds_11_tfusuarionombrecompleto ;
      private string lV121Wpchartsfacturasds_13_tfmotivorechazodescripcion ;
      private string AV73AuxText ;
      private string A11DistribuidorDescripcion ;
      private IGxSession AV20Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucCombo_distribuidorid ;
      private GXUserControl ucUtchartdoughnut ;
      private GXUserControl ucUtchartcolumnline ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTffacturafechafactura_rangepicker ;
      private GXUserControl ucTffacturafecharegistro_rangepicker ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbFacturaEstatus ;
      private GXCombobox cmbavGridactions ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV18ColumnsSelector ;
      private GxSimpleCollection<string> AV61TFFacturaEstatus_Sels ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV67DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV87DistribuidorID_Data ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV74Elements ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter> AV75Parameters ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData AV76ItemClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData AV77ItemDoubleClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData AV78DragAndDropData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData AV79FilterChangedData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData AV80ItemExpandData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData AV81ItemCollapseData ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV21ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV10GridState ;
      private GxSimpleCollection<int> AV102ListaUsuarios ;
      private GxSimpleCollection<int> AV86DistribuidorID ;
      private GxSimpleCollection<string> AV112Wpchartsfacturasds_4_tffacturaestatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] H004G2_A41PromocionID ;
      private int[] H004G2_A19MotivoRechazoID ;
      private bool[] H004G2_A93FacturaCompleta ;
      private string[] H004G2_A20MotivoRechazoDescripcion ;
      private string[] H004G2_A52UsuarioNombreCompleto ;
      private string[] H004G2_A71FacturaNo ;
      private DateTime[] H004G2_A72FacturaFechaRegistro ;
      private DateTime[] H004G2_A73FacturaFechaFactura ;
      private string[] H004G2_A80FacturaEstatus ;
      private string[] H004G2_A42PromocionDescripcion ;
      private int[] H004G2_A29UsuarioID ;
      private int[] H004G2_A69FacturaID ;
      private string[] H004G2_A30UsuarioNombre ;
      private string[] H004G2_A51UsuarioApellido ;
      private int[] H004G3_A41PromocionID ;
      private int[] H004G3_A19MotivoRechazoID ;
      private bool[] H004G3_A93FacturaCompleta ;
      private string[] H004G3_A20MotivoRechazoDescripcion ;
      private string[] H004G3_A52UsuarioNombreCompleto ;
      private string[] H004G3_A71FacturaNo ;
      private DateTime[] H004G3_A72FacturaFechaRegistro ;
      private DateTime[] H004G3_A73FacturaFechaFactura ;
      private string[] H004G3_A80FacturaEstatus ;
      private string[] H004G3_A42PromocionDescripcion ;
      private int[] H004G3_A29UsuarioID ;
      private int[] H004G3_A69FacturaID ;
      private string[] H004G3_A30UsuarioNombre ;
      private string[] H004G3_A51UsuarioApellido ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV19ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private int[] H004G4_A10DistribuidorID ;
      private string[] H004G4_A11DistribuidorDescripcion ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV88Combo_DataItem ;
      private int[] H004G5_A81DistribuidoresUsuarioID ;
      private string[] H004G5_A40UsuarioRol ;
      private int[] H004G5_A29UsuarioID ;
      private int[] H004G6_A81DistribuidoresUsuarioID ;
      private string[] H004G6_A40UsuarioRol ;
      private int[] H004G6_A10DistribuidorID ;
      private int[] H004G6_A29UsuarioID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpchartsfacturas__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004G2( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV102ListaUsuarios ,
                                             string A80FacturaEstatus ,
                                             GxSimpleCollection<string> AV112Wpchartsfacturasds_4_tffacturaestatus_sels ,
                                             string AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel ,
                                             string AV110Wpchartsfacturasds_2_tfpromociondescripcion ,
                                             int AV112Wpchartsfacturasds_4_tffacturaestatus_sels_Count ,
                                             DateTime AV113Wpchartsfacturasds_5_tffacturafechafactura ,
                                             DateTime AV114Wpchartsfacturasds_6_tffacturafechafactura_to ,
                                             DateTime AV115Wpchartsfacturasds_7_tffacturafecharegistro ,
                                             DateTime AV116Wpchartsfacturasds_8_tffacturafecharegistro_to ,
                                             string AV118Wpchartsfacturasds_10_tffacturano_sel ,
                                             string AV117Wpchartsfacturasds_9_tffacturano ,
                                             string AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel ,
                                             string AV119Wpchartsfacturasds_11_tfusuarionombrecompleto ,
                                             string AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel ,
                                             string AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion ,
                                             string A42PromocionDescripcion ,
                                             DateTime A73FacturaFechaFactura ,
                                             DateTime A72FacturaFechaRegistro ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A20MotivoRechazoDescripcion ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             string AV109Wpchartsfacturasds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto ,
                                             DateTime AV84FromDate ,
                                             DateTime AV85ToDate ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[14];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.`PromocionID`, T1.`MotivoRechazoID`, T1.`FacturaCompleta`, T3.`MotivoRechazoDescripcion`, CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`FacturaNo`, T1.`FacturaFechaRegistro`, T1.`FacturaFechaFactura`, T1.`FacturaEstatus`, T2.`PromocionDescripcion`, T1.`UsuarioID`, T1.`FacturaID`, T4.`UsuarioNombre`, T4.`UsuarioApellido` FROM (((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `MotivoRechazo` T3 ON T3.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV84FromDate and T1.`FacturaFechaFactura` <= @AV85ToDate and "+new GxDbmsUtils( new GxSqlServer()).ValueList(AV102ListaUsuarios, "T1.`UsuarioID` IN (", ")")+" and T1.`FacturaCompleta` = 1)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Wpchartsfacturasds_2_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV110Wpchartsfacturasds_2_tfpromociondescripcion)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( StringUtil.StrCmp(AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( AV112Wpchartsfacturasds_4_tffacturaestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV112Wpchartsfacturasds_4_tffacturaestatus_sels, "T1.`FacturaEstatus` IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV113Wpchartsfacturasds_5_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV113Wpchartsfacturasds_5_tffacturafechafactura)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV114Wpchartsfacturasds_6_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV114Wpchartsfacturasds_6_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV115Wpchartsfacturasds_7_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV115Wpchartsfacturasds_7_tffacturafecharegistro)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV116Wpchartsfacturasds_8_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV116Wpchartsfacturasds_8_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Wpchartsfacturasds_10_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wpchartsfacturasds_9_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV117Wpchartsfacturasds_9_tffacturano)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wpchartsfacturasds_10_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV118Wpchartsfacturasds_10_tffacturano_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV118Wpchartsfacturasds_10_tffacturano_sel)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( StringUtil.StrCmp(AV118Wpchartsfacturasds_10_tffacturano_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Wpchartsfacturasds_11_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like @lV119Wpchartsfacturasds_11_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) = @AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( StringUtil.StrCmp(AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T4.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T4.`UsuarioApellido`))))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`MotivoRechazoDescripcion` like @lV121Wpchartsfacturasds_13_tfmotivorechazodescripcion)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)) && ! ( StringUtil.StrCmp(AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`MotivoRechazoDescripcion` = @AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( StringUtil.StrCmp(AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`MotivoRechazoDescripcion`))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`FacturaNo`";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`FacturaNo` DESC";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.`PromocionDescripcion`";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.`PromocionDescripcion` DESC";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`FacturaEstatus`";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`FacturaEstatus` DESC";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`FacturaFechaFactura`";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`FacturaFechaFactura` DESC";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`FacturaFechaRegistro`";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`FacturaFechaRegistro` DESC";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.`MotivoRechazoDescripcion`";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.`MotivoRechazoDescripcion` DESC";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H004G3( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV102ListaUsuarios ,
                                             string A80FacturaEstatus ,
                                             GxSimpleCollection<string> AV112Wpchartsfacturasds_4_tffacturaestatus_sels ,
                                             string AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel ,
                                             string AV110Wpchartsfacturasds_2_tfpromociondescripcion ,
                                             int AV112Wpchartsfacturasds_4_tffacturaestatus_sels_Count ,
                                             DateTime AV113Wpchartsfacturasds_5_tffacturafechafactura ,
                                             DateTime AV114Wpchartsfacturasds_6_tffacturafechafactura_to ,
                                             DateTime AV115Wpchartsfacturasds_7_tffacturafecharegistro ,
                                             DateTime AV116Wpchartsfacturasds_8_tffacturafecharegistro_to ,
                                             string AV118Wpchartsfacturasds_10_tffacturano_sel ,
                                             string AV117Wpchartsfacturasds_9_tffacturano ,
                                             string AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel ,
                                             string AV119Wpchartsfacturasds_11_tfusuarionombrecompleto ,
                                             string AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel ,
                                             string AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion ,
                                             string A42PromocionDescripcion ,
                                             DateTime A73FacturaFechaFactura ,
                                             DateTime A72FacturaFechaRegistro ,
                                             string A71FacturaNo ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A20MotivoRechazoDescripcion ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             string AV109Wpchartsfacturasds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto ,
                                             DateTime AV84FromDate ,
                                             DateTime AV85ToDate ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[14];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.`PromocionID`, T1.`MotivoRechazoID`, T1.`FacturaCompleta`, T3.`MotivoRechazoDescripcion`, CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`FacturaNo`, T1.`FacturaFechaRegistro`, T1.`FacturaFechaFactura`, T1.`FacturaEstatus`, T2.`PromocionDescripcion`, T1.`UsuarioID`, T1.`FacturaID`, T4.`UsuarioNombre`, T4.`UsuarioApellido` FROM (((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `MotivoRechazo` T3 ON T3.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV84FromDate and T1.`FacturaFechaFactura` <= @AV85ToDate and "+new GxDbmsUtils( new GxSqlServer()).ValueList(AV102ListaUsuarios, "T1.`UsuarioID` IN (", ")")+" and T1.`FacturaCompleta` = 1)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Wpchartsfacturasds_2_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV110Wpchartsfacturasds_2_tfpromociondescripcion)");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( StringUtil.StrCmp(AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( AV112Wpchartsfacturasds_4_tffacturaestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV112Wpchartsfacturasds_4_tffacturaestatus_sels, "T1.`FacturaEstatus` IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV113Wpchartsfacturasds_5_tffacturafechafactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV113Wpchartsfacturasds_5_tffacturafechafactura)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV114Wpchartsfacturasds_6_tffacturafechafactura_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV114Wpchartsfacturasds_6_tffacturafechafactura_to)");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV115Wpchartsfacturasds_7_tffacturafecharegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV115Wpchartsfacturasds_7_tffacturafecharegistro)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV116Wpchartsfacturasds_8_tffacturafecharegistro_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV116Wpchartsfacturasds_8_tffacturafecharegistro_to)");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Wpchartsfacturasds_10_tffacturano_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wpchartsfacturasds_9_tffacturano)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV117Wpchartsfacturasds_9_tffacturano)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wpchartsfacturasds_10_tffacturano_sel)) && ! ( StringUtil.StrCmp(AV118Wpchartsfacturasds_10_tffacturano_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV118Wpchartsfacturasds_10_tffacturano_sel)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( StringUtil.StrCmp(AV118Wpchartsfacturasds_10_tffacturano_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Wpchartsfacturasds_11_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like @lV119Wpchartsfacturasds_11_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) = @AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( StringUtil.StrCmp(AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T4.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T4.`UsuarioApellido`))))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wpchartsfacturasds_13_tfmotivorechazodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`MotivoRechazoDescripcion` like @lV121Wpchartsfacturasds_13_tfmotivorechazodescripcion)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)) && ! ( StringUtil.StrCmp(AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`MotivoRechazoDescripcion` = @AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( StringUtil.StrCmp(AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`MotivoRechazoDescripcion`))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`FacturaNo`";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`FacturaNo` DESC";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.`PromocionDescripcion`";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.`PromocionDescripcion` DESC";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`FacturaEstatus`";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`FacturaEstatus` DESC";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`FacturaFechaFactura`";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`FacturaFechaFactura` DESC";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`FacturaFechaRegistro`";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`FacturaFechaRegistro` DESC";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.`MotivoRechazoDescripcion`";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.`MotivoRechazoDescripcion` DESC";
         }
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_H004G6( IGxContext context ,
                                             int A10DistribuidorID ,
                                             GxSimpleCollection<int> AV86DistribuidorID ,
                                             string A40UsuarioRol )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.`DistribuidoresUsuarioID`, T2.`UsuarioRol`, T1.`DistribuidorID`, T1.`UsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV86DistribuidorID, "T1.`DistribuidorID` IN (", ")")+")");
         AddWhere(sWhereString, "(T2.`UsuarioRol` = 'Participante')");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`DistribuidoresUsuarioID`";
         GXv_Object12[0] = scmdbuf;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H004G2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (bool)dynConstraints[30] );
               case 1 :
                     return conditional_H004G3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (bool)dynConstraints[30] );
               case 4 :
                     return conditional_H004G6(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH004G4;
          prmH004G4 = new Object[] {
          };
          Object[] prmH004G5;
          prmH004G5 = new Object[] {
          };
          Object[] prmH004G2;
          prmH004G2 = new Object[] {
          new ParDef("@AV84FromDate",GXType.Date,8,0) ,
          new ParDef("@AV85ToDate",GXType.Date,8,0) ,
          new ParDef("@lV110Wpchartsfacturasds_2_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV113Wpchartsfacturasds_5_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV114Wpchartsfacturasds_6_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@AV115Wpchartsfacturasds_7_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV116Wpchartsfacturasds_8_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV117Wpchartsfacturasds_9_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV118Wpchartsfacturasds_10_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@lV119Wpchartsfacturasds_11_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV121Wpchartsfacturasds_13_tfmotivorechazodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel",GXType.Char,80,0)
          };
          Object[] prmH004G3;
          prmH004G3 = new Object[] {
          new ParDef("@AV84FromDate",GXType.Date,8,0) ,
          new ParDef("@AV85ToDate",GXType.Date,8,0) ,
          new ParDef("@lV110Wpchartsfacturasds_2_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV111Wpchartsfacturasds_3_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV113Wpchartsfacturasds_5_tffacturafechafactura",GXType.Date,8,0) ,
          new ParDef("@AV114Wpchartsfacturasds_6_tffacturafechafactura_to",GXType.Date,8,0) ,
          new ParDef("@AV115Wpchartsfacturasds_7_tffacturafecharegistro",GXType.Date,8,0) ,
          new ParDef("@AV116Wpchartsfacturasds_8_tffacturafecharegistro_to",GXType.Date,8,0) ,
          new ParDef("@lV117Wpchartsfacturasds_9_tffacturano",GXType.Char,20,0) ,
          new ParDef("@AV118Wpchartsfacturasds_10_tffacturano_sel",GXType.Char,20,0) ,
          new ParDef("@lV119Wpchartsfacturasds_11_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV120Wpchartsfacturasds_12_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV121Wpchartsfacturasds_13_tfmotivorechazodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV122Wpchartsfacturasds_14_tfmotivorechazodescripcion_sel",GXType.Char,80,0)
          };
          Object[] prmH004G6;
          prmH004G6 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H004G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004G2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004G3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004G4", "SELECT `DistribuidorID`, `DistribuidorDescripcion` FROM `Distribuidor` ORDER BY `DistribuidorDescripcion` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004G4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H004G5", "SELECT T1.`DistribuidoresUsuarioID`, T2.`UsuarioRol`, T1.`UsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = T1.`UsuarioID`) WHERE T2.`UsuarioRol` = 'Participante' ORDER BY T1.`DistribuidoresUsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004G5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H004G6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004G6,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((int[]) buf[11])[0] = rslt.getInt(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 50);
                ((string[]) buf[13])[0] = rslt.getString(14, 50);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((int[]) buf[11])[0] = rslt.getInt(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 50);
                ((string[]) buf[13])[0] = rslt.getString(14, 50);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
