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
   public class wpfacturas : GXDataArea
   {
      public wpfacturas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpfacturas( IGxContext context )
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
         nRC_GXsfl_65 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_65"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_65_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_65_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_65_idx = GetPar( "sGXsfl_65_idx");
         edtavUseraction2_Class = GetNextPar( );
         AssignProp("", false, edtavUseraction2_Internalname, "Class", edtavUseraction2_Class, !bGXsfl_65_Refreshing);
         edtavUseraction2_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_65_Refreshing);
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
         AV23ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV18ColumnsSelector);
         AV265Pgmname = GetPar( "Pgmname");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV126DistribuidorID);
         A40UsuarioRol = GetPar( "UsuarioRol");
         A10DistribuidorID = (int)(Math.Round(NumberUtil.Val( GetPar( "DistribuidorID"), "."), 18, MidpointRounding.ToEven));
         AV263TFFacturaID = (int)(Math.Round(NumberUtil.Val( GetPar( "TFFacturaID"), "."), 18, MidpointRounding.ToEven));
         AV264TFFacturaID_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFFacturaID_To"), "."), 18, MidpointRounding.ToEven));
         AV41TFFacturaFechaRegistro = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaRegistro"));
         AV42TFFacturaFechaRegistro_To = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaRegistro_To"));
         AV28TFPromocionDescripcion = GetPar( "TFPromocionDescripcion");
         AV29TFPromocionDescripcion_Sel = GetPar( "TFPromocionDescripcion_Sel");
         AV34TFFacturaNo = GetPar( "TFFacturaNo");
         AV35TFFacturaNo_Sel = GetPar( "TFFacturaNo_Sel");
         AV36TFFacturaFechaFactura = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaFactura"));
         AV37TFFacturaFechaFactura_To = context.localUtil.ParseDateParm( GetPar( "TFFacturaFechaFactura_To"));
         AV73TFEstatusOperator = (short)(Math.Round(NumberUtil.Val( GetPar( "TFEstatusOperator"), "."), 18, MidpointRounding.ToEven));
         AV72TFEstatus = GetPar( "TFEstatus");
         AV48TFUsuarioNombreCompleto = GetPar( "TFUsuarioNombreCompleto");
         AV49TFUsuarioNombreCompleto_Sel = GetPar( "TFUsuarioNombreCompleto_Sel");
         edtavUseraction2_Class = GetNextPar( );
         AssignProp("", false, edtavUseraction2_Internalname, "Class", edtavUseraction2_Class, !bGXsfl_65_Refreshing);
         edtavUseraction2_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_65_Refreshing);
         AV70Estatus = GetPar( "Estatus");
         A81DistribuidoresUsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "DistribuidoresUsuarioID"), "."), 18, MidpointRounding.ToEven));
         AV91RegUsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "RegUsuarioID"), "."), 18, MidpointRounding.ToEven));
         A11DistribuidorDescripcion = GetPar( "DistribuidorDescripcion");
         AV262UsuarioCorreo = GetPar( "UsuarioCorreo");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV124FromDate, AV125ToDate, AV15FilterFullText, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV265Pgmname, AV126DistribuidorID, A40UsuarioRol, A10DistribuidorID, AV263TFFacturaID, AV264TFFacturaID_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV73TFEstatusOperator, AV72TFEstatus, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV70Estatus, A81DistribuidoresUsuarioID, AV91RegUsuarioID, A11DistribuidorDescripcion, AV262UsuarioCorreo) ;
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
         PA2Z2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2Z2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpfacturas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV265Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV265Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vREGUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV91RegUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREGUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV91RegUsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOCORREO", AV262UsuarioCorreo);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOCORREO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV262UsuarioCorreo, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFROMDATE", context.localUtil.Format(AV124FromDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vTODATE", context.localUtil.Format(AV125ToDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV15FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_65", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_65), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV60DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV60DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISTRIBUIDORID_DATA", AV137DistribuidorID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISTRIBUIDORID_DATA", AV137DistribuidorID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vELEMENTS", AV252Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vELEMENTS", AV252Elements);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPARAMETERS", AV253Parameters);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPARAMETERS", AV253Parameters);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCLICKDATA", AV254ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCLICKDATA", AV254ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMDOUBLECLICKDATA", AV255ItemDoubleClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMDOUBLECLICKDATA", AV255ItemDoubleClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDRAGANDDROPDATA", AV256DragAndDropData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDRAGANDDROPDATA", AV256DragAndDropData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERCHANGEDDATA", AV257FilterChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERCHANGEDDATA", AV257FilterChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMEXPANDDATA", AV258ItemExpandData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMEXPANDDATA", AV258ItemExpandData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCOLLAPSEDATA", AV259ItemCollapseData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCOLLAPSEDATA", AV259ItemCollapseData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV21ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV21ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV64GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV18ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV18ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_FACTURAFECHAREGISTROAUXDATETO", context.localUtil.DToC( AV249DDO_FacturaFechaRegistroAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_FACTURAFECHAFACTURAAUXDATETO", context.localUtil.DToC( AV251DDO_FacturaFechaFacturaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV265Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV265Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISTRIBUIDORID", AV126DistribuidorID);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISTRIBUIDORID", AV126DistribuidorID);
         }
         GxWebStd.gx_hidden_field( context, "USUARIOROL", StringUtil.RTrim( A40UsuarioRol));
         GxWebStd.gx_hidden_field( context, "DISTRIBUIDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10DistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV263TFFacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV264TFFacturaID_To), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAFECHAREGISTRO", context.localUtil.DToC( AV41TFFacturaFechaRegistro, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAFECHAREGISTRO_TO", context.localUtil.DToC( AV42TFFacturaFechaRegistro_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFPROMOCIONDESCRIPCION", AV28TFPromocionDescripcion);
         GxWebStd.gx_hidden_field( context, "vTFPROMOCIONDESCRIPCION_SEL", AV29TFPromocionDescripcion_Sel);
         GxWebStd.gx_hidden_field( context, "vTFFACTURANO", StringUtil.RTrim( AV34TFFacturaNo));
         GxWebStd.gx_hidden_field( context, "vTFFACTURANO_SEL", StringUtil.RTrim( AV35TFFacturaNo_Sel));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAFECHAFACTURA", context.localUtil.DToC( AV36TFFacturaFechaFactura, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAFECHAFACTURA_TO", context.localUtil.DToC( AV37TFFacturaFechaFactura_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFESTATUSOPERATOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV73TFEstatusOperator), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFESTATUS", StringUtil.RTrim( AV72TFEstatus));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIONOMBRECOMPLETO", AV48TFUsuarioNombreCompleto);
         GxWebStd.gx_hidden_field( context, "vTFUSUARIONOMBRECOMPLETO_SEL", AV49TFUsuarioNombreCompleto_Sel);
         GxWebStd.gx_hidden_field( context, "DISTRIBUIDORESUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A81DistribuidoresUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vREGUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV91RegUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREGUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV91RegUsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DISTRIBUIDORDESCRIPCION", A11DistribuidorDescripcion);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLISTAUSUARIOS", AV184ListaUsuarios);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLISTAUSUARIOS", AV184ListaUsuarios);
         }
         GxWebStd.gx_hidden_field( context, "vBLOB", AV85Blob);
         GxWebStd.gx_hidden_field( context, "vFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV123FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "FACTURAPDF", A75FacturaPDF);
         GxWebStd.gx_hidden_field( context, "vUSUARIOCORREO", AV262UsuarioCorreo);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOCORREO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV262UsuarioCorreo, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "USUARIONOMBRE", StringUtil.RTrim( A30UsuarioNombre));
         GxWebStd.gx_hidden_field( context, "USUARIOAPELLIDO", StringUtil.RTrim( A51UsuarioApellido));
         GxWebStd.gx_hidden_field( context, "vDDO_FACTURAFECHAREGISTROAUXDATE", context.localUtil.DToC( AV248DDO_FacturaFechaRegistroAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_FACTURAFECHAFACTURAAUXDATE", context.localUtil.DToC( AV250DDO_FacturaFechaFacturaAuxDate, 0, "/"));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedfixedfilter));
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
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Selectedvalue_get", StringUtil.RTrim( Combo_distribuidorid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "vUSERACTION2_Class", StringUtil.RTrim( edtavUseraction2_Class));
         GxWebStd.gx_hidden_field( context, "vUSERACTION2_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction2_Visible), 5, 0, ".", "")));
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
            WE2Z2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2Z2( ) ;
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
         return formatLink("wpfacturas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPFacturas" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Factura", "") ;
      }

      protected void WB2Z0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFromdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFromdate_Internalname, context.GetMessage( "Desde", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'" + sGXsfl_65_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFromdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFromdate_Internalname, context.localUtil.Format(AV124FromDate, "99/99/99"), context.localUtil.Format( AV124FromDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFromdate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFromdate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPFacturas.htm");
            GxWebStd.gx_bitmap( context, edtavFromdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFromdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPFacturas.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'" + sGXsfl_65_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTodate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTodate_Internalname, context.localUtil.Format(AV125ToDate, "99/99/99"), context.localUtil.Format( AV125ToDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTodate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTodate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPFacturas.htm");
            GxWebStd.gx_bitmap( context, edtavTodate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTodate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPFacturas.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_distribuidorid_Internalname, context.GetMessage( "Distribuidores", ""), "", "", lblTextblockcombo_distribuidorid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPFacturas.htm");
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
            ucCombo_distribuidorid.SetProperty("DropDownOptionsTitleSettingsIcons", AV60DDO_TitleSettingsIcons);
            ucCombo_distribuidorid.SetProperty("DropDownOptionsData", AV137DistribuidorID_Data);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction99_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(65), 2, 0)+","+"null"+");", context.GetMessage( "Filtrar", ""), bttBtnuseraction99_Jsonclick, 5, context.GetMessage( "Filtrar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION99\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPFacturas.htm");
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
            ucUtchartdoughnut.SetProperty("Elements", AV252Elements);
            ucUtchartdoughnut.SetProperty("Parameters", AV253Parameters);
            ucUtchartdoughnut.SetProperty("Type", Utchartdoughnut_Type);
            ucUtchartdoughnut.SetProperty("Title", Utchartdoughnut_Title);
            ucUtchartdoughnut.SetProperty("ShowValues", Utchartdoughnut_Showvalues);
            ucUtchartdoughnut.SetProperty("ChartType", Utchartdoughnut_Charttype);
            ucUtchartdoughnut.SetProperty("ItemClickData", AV254ItemClickData);
            ucUtchartdoughnut.SetProperty("ItemDoubleClickData", AV255ItemDoubleClickData);
            ucUtchartdoughnut.SetProperty("DragAndDropData", AV256DragAndDropData);
            ucUtchartdoughnut.SetProperty("FilterChangedData", AV257FilterChangedData);
            ucUtchartdoughnut.SetProperty("ItemExpandData", AV258ItemExpandData);
            ucUtchartdoughnut.SetProperty("ItemCollapseData", AV259ItemCollapseData);
            ucUtchartdoughnut.Render(context, "queryviewer", Utchartdoughnut_Internalname, "UTCHARTDOUGHNUTContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartcolumnline.SetProperty("Elements", AV252Elements);
            ucUtchartcolumnline.SetProperty("Parameters", AV253Parameters);
            ucUtchartcolumnline.SetProperty("Type", Utchartcolumnline_Type);
            ucUtchartcolumnline.SetProperty("Title", Utchartcolumnline_Title);
            ucUtchartcolumnline.SetProperty("ItemClickData", AV254ItemClickData);
            ucUtchartcolumnline.SetProperty("ItemDoubleClickData", AV255ItemDoubleClickData);
            ucUtchartcolumnline.SetProperty("DragAndDropData", AV256DragAndDropData);
            ucUtchartcolumnline.SetProperty("FilterChangedData", AV257FilterChangedData);
            ucUtchartcolumnline.SetProperty("ItemExpandData", AV258ItemExpandData);
            ucUtchartcolumnline.SetProperty("ItemCollapseData", AV259ItemCollapseData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(65), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WPFacturas.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_65_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WPFacturas.htm");
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
            StartGridControl65( ) ;
         }
         if ( wbEnd == 65 )
         {
            wbEnd = 0;
            nRC_GXsfl_65 = (int)(nGXsfl_65_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV62GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV63GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV64GridAppliedFilters);
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
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV60DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV60DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV18ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
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
               GxWebStd.gx_hidden_field( context, "W0100"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0100"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_65_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0100"+"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_65_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_facturafecharegistroauxdatetext_Internalname, AV45DDO_FacturaFechaRegistroAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV45DDO_FacturaFechaRegistroAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_facturafecharegistroauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPFacturas.htm");
            /* User Defined Control */
            ucTffacturafecharegistro_rangepicker.SetProperty("Start Date", AV248DDO_FacturaFechaRegistroAuxDate);
            ucTffacturafecharegistro_rangepicker.SetProperty("End Date", AV249DDO_FacturaFechaRegistroAuxDateTo);
            ucTffacturafecharegistro_rangepicker.Render(context, "wwp.daterangepicker", Tffacturafecharegistro_rangepicker_Internalname, "TFFACTURAFECHAREGISTRO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_facturafechafacturaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_65_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_facturafechafacturaauxdatetext_Internalname, AV40DDO_FacturaFechaFacturaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV40DDO_FacturaFechaFacturaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_facturafechafacturaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPFacturas.htm");
            /* User Defined Control */
            ucTffacturafechafactura_rangepicker.SetProperty("Start Date", AV250DDO_FacturaFechaFacturaAuxDate);
            ucTffacturafechafactura_rangepicker.SetProperty("End Date", AV251DDO_FacturaFechaFacturaAuxDateTo);
            ucTffacturafechafactura_rangepicker.Render(context, "wwp.daterangepicker", Tffacturafechafactura_rangepicker_Internalname, "TFFACTURAFECHAFACTURA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 65 )
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

      protected void START2Z2( )
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
         STRUP2Z0( ) ;
      }

      protected void WS2Z2( )
      {
         START2Z2( ) ;
         EVT2Z2( ) ;
      }

      protected void EVT2Z2( )
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
                              E112Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E122Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E132Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E142Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E152Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E162Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION99'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction99' */
                              E172Z2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VPARTIDAS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VUSERACTION4.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VUSERACTION2.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VUSERACTION1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VUSERACTION4.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VUSERACTION1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VPARTIDAS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VUSERACTION2.CLICK") == 0 ) )
                           {
                              nGXsfl_65_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
                              SubsflControlProps_652( ) ;
                              A69FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              AV79UserAction4 = cgiGet( edtavUseraction4_Internalname);
                              AssignProp("", false, edtavUseraction4_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV79UserAction4)) ? AV266Useraction4_GXI : context.convertURL( context.PathToRelativeUrl( AV79UserAction4))), !bGXsfl_65_Refreshing);
                              AssignProp("", false, edtavUseraction4_Internalname, "SrcSet", context.GetImageSrcSet( AV79UserAction4), true);
                              AV83UserAction1 = cgiGet( edtavUseraction1_Internalname);
                              AssignAttri("", false, edtavUseraction1_Internalname, AV83UserAction1);
                              A72FacturaFechaRegistro = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaRegistro_Internalname), 0));
                              A42PromocionDescripcion = cgiGet( edtPromocionDescripcion_Internalname);
                              A71FacturaNo = cgiGet( edtFacturaNo_Internalname);
                              A73FacturaFechaFactura = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaFactura_Internalname), 0));
                              AV87PartidasWithTags = cgiGet( edtavPartidaswithtags_Internalname);
                              AssignAttri("", false, edtavPartidaswithtags_Internalname, AV87PartidasWithTags);
                              AV86Partidas = cgiGet( edtavPartidas_Internalname);
                              AssignAttri("", false, edtavPartidas_Internalname, AV86Partidas);
                              AV80UserAction2 = cgiGet( edtavUseraction2_Internalname);
                              AssignAttri("", false, edtavUseraction2_Internalname, AV80UserAction2);
                              AV71EstatusWithTags = cgiGet( edtavEstatuswithtags_Internalname);
                              AssignAttri("", false, edtavEstatuswithtags_Internalname, AV71EstatusWithTags);
                              AV70Estatus = cgiGet( edtavEstatus_Internalname);
                              AssignAttri("", false, edtavEstatus_Internalname, AV70Estatus);
                              GxWebStd.gx_hidden_field( context, "gxhash_vESTATUS"+"_"+sGXsfl_65_idx, GetSecureSignedToken( sGXsfl_65_idx, StringUtil.RTrim( context.localUtil.Format( AV70Estatus, "")), context));
                              AV81Descripcion = cgiGet( edtavDescripcion_Internalname);
                              AssignAttri("", false, edtavDescripcion_Internalname, AV81Descripcion);
                              cmbFacturaEstatus.Name = cmbFacturaEstatus_Internalname;
                              cmbFacturaEstatus.CurrentValue = cgiGet( cmbFacturaEstatus_Internalname);
                              A80FacturaEstatus = cgiGet( cmbFacturaEstatus_Internalname);
                              A29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A52UsuarioNombreCompleto = cgiGet( edtUsuarioNombreCompleto_Internalname);
                              A21MotivoRechazoActivo = StringUtil.StrToBool( cgiGet( chkMotivoRechazoActivo_Internalname));
                              A20MotivoRechazoDescripcion = cgiGet( edtMotivoRechazoDescripcion_Internalname);
                              A19MotivoRechazoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMotivoRechazoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              AV97DistribuidorDescripcionVar = cgiGet( edtavDistribuidordescripcionvar_Internalname);
                              AssignAttri("", false, edtavDistribuidordescripcionvar_Internalname, AV97DistribuidorDescripcionVar);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E182Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E192Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E202Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VPARTIDAS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E212Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUSERACTION4.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E222Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUSERACTION2.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E232Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUSERACTION1.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E242Z2 ();
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
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vFROMDATE"), 0) != AV124FromDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Todate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vTODATE"), 0) != AV125ToDate )
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
                        if ( nCmpId == 100 )
                        {
                           OldWwpaux_wc = cgiGet( "W0100");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0100", "", sEvt);
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

      protected void WE2Z2( )
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

      protected void PA2Z2( )
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
         SubsflControlProps_652( ) ;
         while ( nGXsfl_65_idx <= nRC_GXsfl_65 )
         {
            sendrow_652( ) ;
            nGXsfl_65_idx = ((subGrid_Islastpage==1)&&(nGXsfl_65_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_65_idx+1);
            sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
            SubsflControlProps_652( ) ;
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
                                       short AV23ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV18ColumnsSelector ,
                                       string AV265Pgmname ,
                                       GxSimpleCollection<int> AV126DistribuidorID ,
                                       string A40UsuarioRol ,
                                       int A10DistribuidorID ,
                                       int AV263TFFacturaID ,
                                       int AV264TFFacturaID_To ,
                                       DateTime AV41TFFacturaFechaRegistro ,
                                       DateTime AV42TFFacturaFechaRegistro_To ,
                                       string AV28TFPromocionDescripcion ,
                                       string AV29TFPromocionDescripcion_Sel ,
                                       string AV34TFFacturaNo ,
                                       string AV35TFFacturaNo_Sel ,
                                       DateTime AV36TFFacturaFechaFactura ,
                                       DateTime AV37TFFacturaFechaFactura_To ,
                                       short AV73TFEstatusOperator ,
                                       string AV72TFEstatus ,
                                       string AV48TFUsuarioNombreCompleto ,
                                       string AV49TFUsuarioNombreCompleto_Sel ,
                                       string AV70Estatus ,
                                       int A81DistribuidoresUsuarioID ,
                                       int AV91RegUsuarioID ,
                                       string A11DistribuidorDescripcion ,
                                       string AV262UsuarioCorreo )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2Z2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "USUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTATUS", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV70Estatus, "")), context));
         GxWebStd.gx_hidden_field( context, "vESTATUS", StringUtil.RTrim( AV70Estatus));
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
         RF2Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV265Pgmname = "WPFacturas";
         edtavUseraction1_Enabled = 0;
         edtavPartidaswithtags_Enabled = 0;
         edtavPartidas_Enabled = 0;
         edtavUseraction2_Enabled = 0;
         edtavEstatuswithtags_Enabled = 0;
         edtavEstatus_Enabled = 0;
         edtavDescripcion_Enabled = 0;
         edtavDistribuidordescripcionvar_Enabled = 0;
      }

      protected void RF2Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 65;
         /* Execute user event: Refresh */
         E192Z2 ();
         nGXsfl_65_idx = 1;
         sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
         SubsflControlProps_652( ) ;
         bGXsfl_65_Refreshing = true;
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
            SubsflControlProps_652( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A29UsuarioID ,
                                                 AV184ListaUsuarios ,
                                                 AV15FilterFullText ,
                                                 AV263TFFacturaID ,
                                                 AV264TFFacturaID_To ,
                                                 AV41TFFacturaFechaRegistro ,
                                                 AV42TFFacturaFechaRegistro_To ,
                                                 AV29TFPromocionDescripcion_Sel ,
                                                 AV28TFPromocionDescripcion ,
                                                 AV35TFFacturaNo_Sel ,
                                                 AV34TFFacturaNo ,
                                                 AV36TFFacturaFechaFactura ,
                                                 AV37TFFacturaFechaFactura_To ,
                                                 AV73TFEstatusOperator ,
                                                 AV49TFUsuarioNombreCompleto_Sel ,
                                                 AV48TFUsuarioNombreCompleto ,
                                                 AV124FromDate ,
                                                 AV125ToDate ,
                                                 AV184ListaUsuarios.Count ,
                                                 A69FacturaID ,
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
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
            lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
            lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
            lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
            lV28TFPromocionDescripcion = StringUtil.Concat( StringUtil.RTrim( AV28TFPromocionDescripcion), "%", "");
            lV34TFFacturaNo = StringUtil.PadR( StringUtil.RTrim( AV34TFFacturaNo), 20, "%");
            lV48TFUsuarioNombreCompleto = StringUtil.Concat( StringUtil.RTrim( AV48TFUsuarioNombreCompleto), "%", "");
            /* Using cursor H002Z2 */
            pr_default.execute(0, new Object[] {lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, AV263TFFacturaID, AV264TFFacturaID_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, lV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, lV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, lV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV124FromDate, AV125ToDate, GXPagingFrom2, GXPagingTo2});
            nGXsfl_65_idx = 1;
            sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
            SubsflControlProps_652( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A41PromocionID = H002Z2_A41PromocionID[0];
               A93FacturaCompleta = H002Z2_A93FacturaCompleta[0];
               A19MotivoRechazoID = H002Z2_A19MotivoRechazoID[0];
               A20MotivoRechazoDescripcion = H002Z2_A20MotivoRechazoDescripcion[0];
               A21MotivoRechazoActivo = H002Z2_A21MotivoRechazoActivo[0];
               A29UsuarioID = H002Z2_A29UsuarioID[0];
               A80FacturaEstatus = H002Z2_A80FacturaEstatus[0];
               A73FacturaFechaFactura = H002Z2_A73FacturaFechaFactura[0];
               A71FacturaNo = H002Z2_A71FacturaNo[0];
               A42PromocionDescripcion = H002Z2_A42PromocionDescripcion[0];
               A72FacturaFechaRegistro = H002Z2_A72FacturaFechaRegistro[0];
               A69FacturaID = H002Z2_A69FacturaID[0];
               A51UsuarioApellido = H002Z2_A51UsuarioApellido[0];
               A30UsuarioNombre = H002Z2_A30UsuarioNombre[0];
               A42PromocionDescripcion = H002Z2_A42PromocionDescripcion[0];
               A20MotivoRechazoDescripcion = H002Z2_A20MotivoRechazoDescripcion[0];
               A21MotivoRechazoActivo = H002Z2_A21MotivoRechazoActivo[0];
               A51UsuarioApellido = H002Z2_A51UsuarioApellido[0];
               A30UsuarioNombre = H002Z2_A30UsuarioNombre[0];
               A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
               /* Execute user event: Grid.Load */
               E202Z2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 65;
            WB2Z0( ) ;
         }
         bGXsfl_65_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2Z2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV265Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV265Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOID"+"_"+sGXsfl_65_idx, GetSecureSignedToken( sGXsfl_65_idx, context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTATUS"+"_"+sGXsfl_65_idx, GetSecureSignedToken( sGXsfl_65_idx, StringUtil.RTrim( context.localUtil.Format( AV70Estatus, "")), context));
         GxWebStd.gx_hidden_field( context, "vREGUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV91RegUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREGUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV91RegUsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_FACTURAID"+"_"+sGXsfl_65_idx, GetSecureSignedToken( sGXsfl_65_idx, context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOCORREO", AV262UsuarioCorreo);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOCORREO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV262UsuarioCorreo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_FACTURAESTATUS"+"_"+sGXsfl_65_idx, GetSecureSignedToken( sGXsfl_65_idx, StringUtil.RTrim( context.localUtil.Format( A80FacturaEstatus, "")), context));
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
                                              A29UsuarioID ,
                                              AV184ListaUsuarios ,
                                              AV15FilterFullText ,
                                              AV263TFFacturaID ,
                                              AV264TFFacturaID_To ,
                                              AV41TFFacturaFechaRegistro ,
                                              AV42TFFacturaFechaRegistro_To ,
                                              AV29TFPromocionDescripcion_Sel ,
                                              AV28TFPromocionDescripcion ,
                                              AV35TFFacturaNo_Sel ,
                                              AV34TFFacturaNo ,
                                              AV36TFFacturaFechaFactura ,
                                              AV37TFFacturaFechaFactura_To ,
                                              AV73TFEstatusOperator ,
                                              AV49TFUsuarioNombreCompleto_Sel ,
                                              AV48TFUsuarioNombreCompleto ,
                                              AV124FromDate ,
                                              AV125ToDate ,
                                              AV184ListaUsuarios.Count ,
                                              A69FacturaID ,
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
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
         lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
         lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
         lV15FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV15FilterFullText), "%", "");
         lV28TFPromocionDescripcion = StringUtil.Concat( StringUtil.RTrim( AV28TFPromocionDescripcion), "%", "");
         lV34TFFacturaNo = StringUtil.PadR( StringUtil.RTrim( AV34TFFacturaNo), 20, "%");
         lV48TFUsuarioNombreCompleto = StringUtil.Concat( StringUtil.RTrim( AV48TFUsuarioNombreCompleto), "%", "");
         /* Using cursor H002Z3 */
         pr_default.execute(1, new Object[] {lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, lV15FilterFullText, AV263TFFacturaID, AV264TFFacturaID_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, lV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, lV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, lV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV124FromDate, AV125ToDate});
         GRID_nRecordCount = H002Z3_AGRID_nRecordCount[0];
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV124FromDate, AV125ToDate, AV15FilterFullText, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV265Pgmname, AV126DistribuidorID, A40UsuarioRol, A10DistribuidorID, AV263TFFacturaID, AV264TFFacturaID_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV73TFEstatusOperator, AV72TFEstatus, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV70Estatus, A81DistribuidoresUsuarioID, AV91RegUsuarioID, A11DistribuidorDescripcion, AV262UsuarioCorreo) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV124FromDate, AV125ToDate, AV15FilterFullText, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV265Pgmname, AV126DistribuidorID, A40UsuarioRol, A10DistribuidorID, AV263TFFacturaID, AV264TFFacturaID_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV73TFEstatusOperator, AV72TFEstatus, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV70Estatus, A81DistribuidoresUsuarioID, AV91RegUsuarioID, A11DistribuidorDescripcion, AV262UsuarioCorreo) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV124FromDate, AV125ToDate, AV15FilterFullText, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV265Pgmname, AV126DistribuidorID, A40UsuarioRol, A10DistribuidorID, AV263TFFacturaID, AV264TFFacturaID_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV73TFEstatusOperator, AV72TFEstatus, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV70Estatus, A81DistribuidoresUsuarioID, AV91RegUsuarioID, A11DistribuidorDescripcion, AV262UsuarioCorreo) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV124FromDate, AV125ToDate, AV15FilterFullText, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV265Pgmname, AV126DistribuidorID, A40UsuarioRol, A10DistribuidorID, AV263TFFacturaID, AV264TFFacturaID_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV73TFEstatusOperator, AV72TFEstatus, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV70Estatus, A81DistribuidoresUsuarioID, AV91RegUsuarioID, A11DistribuidorDescripcion, AV262UsuarioCorreo) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV124FromDate, AV125ToDate, AV15FilterFullText, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV265Pgmname, AV126DistribuidorID, A40UsuarioRol, A10DistribuidorID, AV263TFFacturaID, AV264TFFacturaID_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV73TFEstatusOperator, AV72TFEstatus, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV70Estatus, A81DistribuidoresUsuarioID, AV91RegUsuarioID, A11DistribuidorDescripcion, AV262UsuarioCorreo) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV265Pgmname = "WPFacturas";
         edtavUseraction1_Enabled = 0;
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
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E182Z2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV60DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vDISTRIBUIDORID_DATA"), AV137DistribuidorID_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vELEMENTS"), AV252Elements);
            ajax_req_read_hidden_sdt(cgiGet( "vPARAMETERS"), AV253Parameters);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCLICKDATA"), AV254ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMDOUBLECLICKDATA"), AV255ItemDoubleClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vDRAGANDDROPDATA"), AV256DragAndDropData);
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERCHANGEDDATA"), AV257FilterChangedData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMEXPANDDATA"), AV258ItemExpandData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCOLLAPSEDATA"), AV259ItemCollapseData);
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV21ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV18ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_65 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_65"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV62GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV63GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV64GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV248DDO_FacturaFechaRegistroAuxDate = context.localUtil.CToD( cgiGet( "vDDO_FACTURAFECHAREGISTROAUXDATE"), 0);
            AV249DDO_FacturaFechaRegistroAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_FACTURAFECHAREGISTROAUXDATETO"), 0);
            AV250DDO_FacturaFechaFacturaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_FACTURAFECHAFACTURAAUXDATE"), 0);
            AV251DDO_FacturaFechaFacturaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_FACTURAFECHAFACTURAAUXDATETO"), 0);
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
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Ddo_grid_Selectedfixedfilter = cgiGet( "DDO_GRID_Selectedfixedfilter");
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
            Combo_distribuidorid_Selectedvalue_get = cgiGet( "COMBO_DISTRIBUIDORID_Selectedvalue_get");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavFromdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "From Date", "")}), 1, "vFROMDATE");
               GX_FocusControl = edtavFromdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV124FromDate = DateTime.MinValue;
               AssignAttri("", false, "AV124FromDate", context.localUtil.Format(AV124FromDate, "99/99/99"));
            }
            else
            {
               AV124FromDate = context.localUtil.CToD( cgiGet( edtavFromdate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV124FromDate", context.localUtil.Format(AV124FromDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTodate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "To Date", "")}), 1, "vTODATE");
               GX_FocusControl = edtavTodate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV125ToDate = DateTime.MinValue;
               AssignAttri("", false, "AV125ToDate", context.localUtil.Format(AV125ToDate, "99/99/99"));
            }
            else
            {
               AV125ToDate = context.localUtil.CToD( cgiGet( edtavTodate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV125ToDate", context.localUtil.Format(AV125ToDate, "99/99/99"));
            }
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            AV45DDO_FacturaFechaRegistroAuxDateText = cgiGet( edtavDdo_facturafecharegistroauxdatetext_Internalname);
            AssignAttri("", false, "AV45DDO_FacturaFechaRegistroAuxDateText", AV45DDO_FacturaFechaRegistroAuxDateText);
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
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vFROMDATE"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV124FromDate ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vTODATE"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV125ToDate ) )
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
         E182Z2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E182Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV125ToDate = DateTimeUtil.Today( context);
         AssignAttri("", false, "AV125ToDate", context.localUtil.Format(AV125ToDate, "99/99/99"));
         AV124FromDate = DateTimeUtil.AddMth( AV125ToDate, -3);
         AssignAttri("", false, "AV124FromDate", context.localUtil.Format(AV124FromDate, "99/99/99"));
         /* Execute user subroutine: 'OBTIENELISTAUSUARIOS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Utchartdoughnut_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPFacturaEstatusFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV124FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV125ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV184ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartdoughnut.SendProperty(context, "", false, Utchartdoughnut_Internalname, "Object", Utchartdoughnut_Objectcall);
         Utchartcolumnline_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPGraficaFacturasPorMesFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV124FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV125ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV184ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartcolumnline.SendProperty(context, "", false, Utchartcolumnline_Internalname, "Object", Utchartcolumnline_Objectcall);
         edtavUseraction2_Class = context.GetMessage( "ColumnSizeLarge ColumnWeightBold ColumnHighlightBackground ColumnLeftDivision", "");
         AssignProp("", false, edtavUseraction2_Internalname, "Class", edtavUseraction2_Class, !bGXsfl_65_Refreshing);
         AV74UsuarioJSON = AV76WebSession.Get(context.GetMessage( "Usuario", ""));
         AV75SDTUsuario.FromJSonString(AV74UsuarioJSON, null);
         AV77UsuarioRol = AV75SDTUsuario.gxTpr_Usuariorol;
         AV262UsuarioCorreo = StringUtil.Lower( StringUtil.Trim( AV75SDTUsuario.gxTpr_Usuariocorreo));
         AssignAttri("", false, "AV262UsuarioCorreo", AV262UsuarioCorreo);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOCORREO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV262UsuarioCorreo, "")), context));
         if ( ( StringUtil.StrCmp(AV77UsuarioRol, "Administrador Yokohama") == 0 ) || ( StringUtil.StrCmp(AV77UsuarioRol, "Super Administrador") == 0 ) )
         {
            edtavUseraction2_Visible = 1;
            AssignProp("", false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            edtavUseraction2_Visible = 0;
            AssignProp("", false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_65_Refreshing);
         }
         Popover_partidas_Gridinternalname = subGrid_Internalname;
         ucPopover_partidas.SendProperty(context, "", false, Popover_partidas_Internalname, "GridInternalName", Popover_partidas_Gridinternalname);
         Popover_partidas_Iteminternalname = edtavPartidaswithtags_Internalname;
         ucPopover_partidas.SendProperty(context, "", false, Popover_partidas_Internalname, "ItemInternalName", Popover_partidas_Iteminternalname);
         this.executeUsercontrolMethod("", false, "TFFACTURAFECHAFACTURA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_facturafechafacturaauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFFACTURAFECHAREGISTRO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_facturafecharegistroauxdatetext_Internalname});
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV60DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV60DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV60DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV60DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E192Z2( )
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
         if ( StringUtil.StrCmp(AV20Session.Get("WPFacturasColumnsSelector"), "") != 0 )
         {
            AV16ColumnsSelectorXML = AV20Session.Get("WPFacturasColumnsSelector");
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
         edtFacturaID_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtFacturaID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaID_Visible), 5, 0), !bGXsfl_65_Refreshing);
         edtFacturaFechaRegistro_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtFacturaFechaRegistro_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaFechaRegistro_Visible), 5, 0), !bGXsfl_65_Refreshing);
         edtPromocionDescripcion_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPromocionDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPromocionDescripcion_Visible), 5, 0), !bGXsfl_65_Refreshing);
         edtFacturaNo_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtFacturaNo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaNo_Visible), 5, 0), !bGXsfl_65_Refreshing);
         edtFacturaFechaFactura_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtFacturaFechaFactura_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaFechaFactura_Visible), 5, 0), !bGXsfl_65_Refreshing);
         edtavPartidaswithtags_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavPartidaswithtags_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPartidaswithtags_Visible), 5, 0), !bGXsfl_65_Refreshing);
         edtavEstatuswithtags_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavEstatuswithtags_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEstatuswithtags_Visible), 5, 0), !bGXsfl_65_Refreshing);
         edtavDescripcion_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDescripcion_Visible), 5, 0), !bGXsfl_65_Refreshing);
         edtUsuarioNombreCompleto_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtUsuarioNombreCompleto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombreCompleto_Visible), 5, 0), !bGXsfl_65_Refreshing);
         edtavDistribuidordescripcionvar_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavDistribuidordescripcionvar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDistribuidordescripcionvar_Visible), 5, 0), !bGXsfl_65_Refreshing);
         AV62GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV62GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV62GridCurrentPage), 10, 0));
         AV63GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV63GridPageCount", StringUtil.LTrimStr( (decimal)(AV63GridPageCount), 10, 0));
         GXt_char2 = AV64GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV265Pgmname, out  GXt_char2) ;
         AV64GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV64GridAppliedFilters", AV64GridAppliedFilters);
         AV74UsuarioJSON = AV76WebSession.Get(context.GetMessage( "Usuario", ""));
         AV75SDTUsuario.FromJSonString(AV74UsuarioJSON, null);
         AV77UsuarioRol = AV75SDTUsuario.gxTpr_Usuariorol;
         if ( StringUtil.StrCmp(AV77UsuarioRol, "Administrador Yokohama") == 0 )
         {
            edtavUseraction2_Visible = 1;
            AssignProp("", false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            edtavUseraction2_Visible = 0;
            AssignProp("", false, edtavUseraction2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Visible), 5, 0), !bGXsfl_65_Refreshing);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV184ListaUsuarios", AV184ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E132Z2( )
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
            AV61PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV61PageToGo) ;
         }
      }

      protected void E142Z2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E152Z2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaID") == 0 )
            {
               AV263TFFacturaID = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV263TFFacturaID", StringUtil.LTrimStr( (decimal)(AV263TFFacturaID), 9, 0));
               AV264TFFacturaID_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV264TFFacturaID_To", StringUtil.LTrimStr( (decimal)(AV264TFFacturaID_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaFechaRegistro") == 0 )
            {
               AV41TFFacturaFechaRegistro = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV41TFFacturaFechaRegistro", context.localUtil.Format(AV41TFFacturaFechaRegistro, "99/99/99"));
               AV42TFFacturaFechaRegistro_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV42TFFacturaFechaRegistro_To", context.localUtil.Format(AV42TFFacturaFechaRegistro_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PromocionDescripcion") == 0 )
            {
               AV28TFPromocionDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV28TFPromocionDescripcion", AV28TFPromocionDescripcion);
               AV29TFPromocionDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFPromocionDescripcion_Sel", AV29TFPromocionDescripcion_Sel);
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
                  AV73TFEstatusOperator = 1;
                  AssignAttri("", false, "AV73TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV73TFEstatusOperator), 4, 0));
                  AV72TFEstatus = "";
                  AssignAttri("", false, "AV72TFEstatus", AV72TFEstatus);
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "2") == 0 )
               {
                  AV73TFEstatusOperator = 2;
                  AssignAttri("", false, "AV73TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV73TFEstatusOperator), 4, 0));
                  AV72TFEstatus = "";
                  AssignAttri("", false, "AV72TFEstatus", AV72TFEstatus);
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "3") == 0 )
               {
                  AV73TFEstatusOperator = 3;
                  AssignAttri("", false, "AV73TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV73TFEstatusOperator), 4, 0));
                  AV72TFEstatus = "";
                  AssignAttri("", false, "AV72TFEstatus", AV72TFEstatus);
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "4") == 0 )
               {
                  AV73TFEstatusOperator = 4;
                  AssignAttri("", false, "AV73TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV73TFEstatusOperator), 4, 0));
                  AV72TFEstatus = "";
                  AssignAttri("", false, "AV72TFEstatus", AV72TFEstatus);
               }
               else
               {
                  AV73TFEstatusOperator = 0;
                  AssignAttri("", false, "AV73TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV73TFEstatusOperator), 4, 0));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioNombreCompleto") == 0 )
            {
               AV48TFUsuarioNombreCompleto = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV48TFUsuarioNombreCompleto", AV48TFUsuarioNombreCompleto);
               AV49TFUsuarioNombreCompleto_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV49TFUsuarioNombreCompleto_Sel", AV49TFUsuarioNombreCompleto_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E202Z2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
         {
            AV81Descripcion = A20MotivoRechazoDescripcion;
            AssignAttri("", false, edtavDescripcion_Internalname, AV81Descripcion);
         }
         else
         {
            AV81Descripcion = context.GetMessage( "NA", "");
            AssignAttri("", false, edtavDescripcion_Internalname, AV81Descripcion);
         }
         AV86Partidas = context.GetMessage( "Partidas", "");
         AssignAttri("", false, edtavPartidas_Internalname, AV86Partidas);
         AV91RegUsuarioID = A29UsuarioID;
         AssignAttri("", false, "AV91RegUsuarioID", StringUtil.LTrimStr( (decimal)(AV91RegUsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vREGUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV91RegUsuarioID), "ZZZZZZZZ9"), context));
         /* Execute user subroutine: 'OBTIENEDISTRIBUIDOR' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         edtavUseraction4_gximage = "iconoPDF";
         AV79UserAction4 = context.GetImagePath( "b97efd0f-8d9d-4227-92c4-9cbec8912646", "", context.GetTheme( ));
         AssignAttri("", false, edtavUseraction4_Internalname, AV79UserAction4);
         AV266Useraction4_GXI = GXDbFile.PathToUrl( context.GetImagePath( "b97efd0f-8d9d-4227-92c4-9cbec8912646", "", context.GetTheme( )), context);
         edtavUseraction4_Tooltiptext = "";
         AV83UserAction1 = "<i class=\"IconoEditarAzul fas fa-magnifying-glass\"></i>";
         AssignAttri("", false, edtavUseraction1_Internalname, AV83UserAction1);
         AV80UserAction2 = context.GetMessage( "Cambiar estatus", "");
         AssignAttri("", false, edtavUseraction2_Internalname, AV80UserAction2);
         GXt_char2 = AV87PartidasWithTags;
         new WorkWithPlus.workwithplus_web.wwp_encodehtml(context ).execute(  AV86Partidas, out  GXt_char2) ;
         AV87PartidasWithTags = GXt_char2;
         AssignAttri("", false, edtavPartidaswithtags_Internalname, AV87PartidasWithTags);
         AV87PartidasWithTags += "<i class='WWPPopoverIcon FontColorIcon fas fa-angle-down'></i>";
         AssignAttri("", false, edtavPartidaswithtags_Internalname, AV87PartidasWithTags);
         GXt_char2 = AV71EstatusWithTags;
         new WorkWithPlus.workwithplus_web.wwp_encodehtml(context ).execute(  AV70Estatus, out  GXt_char2) ;
         AV71EstatusWithTags = GXt_char2;
         AssignAttri("", false, edtavEstatuswithtags_Internalname, AV71EstatusWithTags);
         if ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 )
         {
            AV71EstatusWithTags += StringUtil.Format( "<span class='AttributeTagWarning TagAfterText'>%1</span>", context.GetMessage( "En proceso", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavEstatuswithtags_Internalname, AV71EstatusWithTags);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 )
         {
            AV71EstatusWithTags += StringUtil.Format( "<span class='AttributeTagSuccess TagAfterText'>%1</span>", context.GetMessage( "Aprobada", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavEstatuswithtags_Internalname, AV71EstatusWithTags);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
         {
            AV71EstatusWithTags += StringUtil.Format( "<span class='AttributeTagDanger TagAfterText'>%1</span>", context.GetMessage( "Rechazada", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavEstatuswithtags_Internalname, AV71EstatusWithTags);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Cancelada") == 0 )
         {
            AV71EstatusWithTags += StringUtil.Format( "<span class='AttributeTagInfo TagAfterText'>%1</span>", context.GetMessage( "Cancelada", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavEstatuswithtags_Internalname, AV71EstatusWithTags);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 65;
         }
         sendrow_652( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_65_Refreshing )
         {
            DoAjaxLoad(65, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E162Z2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV16ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV18ColumnsSelector.FromJSonString(AV16ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WPFacturasColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV16ColumnsSelectorXML)) ? "" : AV18ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV184ListaUsuarios", AV184ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E122Z2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S202 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WPFacturasFilters")) + "," + UrlEncode(StringUtil.RTrim(AV265Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WPFacturasFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV23ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV22ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WPFacturasFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV22ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S202 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV265Pgmname+"GridState",  AV22ManageFiltersXml) ;
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
               S212 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV184ListaUsuarios", AV184ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
      }

      protected void E172Z2( )
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
         Utchartdoughnut_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPFacturaEstatusFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV124FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV125ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV184ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartdoughnut.SendProperty(context, "", false, Utchartdoughnut_Internalname, "Object", Utchartdoughnut_Objectcall);
         Utchartcolumnline_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPGraficaFacturasPorMesFiltrado")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV124FromDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV125ToDate, "99/99/99"))+"\", \""+StringUtil.JSONEncode( AV184ListaUsuarios.ToJSonString(false))+"\" ]";
         ucUtchartcolumnline.SendProperty(context, "", false, Utchartcolumnline_Internalname, "Object", Utchartcolumnline_Objectcall);
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV124FromDate, AV125ToDate, AV15FilterFullText, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV265Pgmname, AV126DistribuidorID, A40UsuarioRol, A10DistribuidorID, AV263TFFacturaID, AV264TFFacturaID_To, AV41TFFacturaFechaRegistro, AV42TFFacturaFechaRegistro_To, AV28TFPromocionDescripcion, AV29TFPromocionDescripcion_Sel, AV34TFFacturaNo, AV35TFFacturaNo_Sel, AV36TFFacturaFechaFactura, AV37TFFacturaFechaFactura_To, AV73TFEstatusOperator, AV72TFEstatus, AV48TFUsuarioNombreCompleto, AV49TFUsuarioNombreCompleto_Sel, AV70Estatus, A81DistribuidoresUsuarioID, AV91RegUsuarioID, A11DistribuidorDescripcion, AV262UsuarioCorreo) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV184ListaUsuarios", AV184ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E212Z2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0100",(string)"",(int)A69FacturaID});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0100"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E112Z2( )
      {
         /* Combo_distribuidorid_Onoptionclicked Routine */
         returnInSub = false;
         AV126DistribuidorID.FromJSonString(Combo_distribuidorid_Selectedvalue_get, null);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV126DistribuidorID", AV126DistribuidorID);
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
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "FacturaID",  "",  "ID",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "FacturaFechaRegistro",  "",  "Fecha Registro",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "PromocionDescripcion",  "",  "Nom. Promoción",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "FacturaNo",  "",  "No. Factura",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "FacturaFechaFactura",  "",  "Fecha Factura",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "&Partidas",  "",  "Partidas",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "&Estatus",  "",  "Estatus",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "&Descripcion",  "",  "Motivo de rechazo",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "UsuarioNombreCompleto",  "",  "Nombre completo",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "&DistribuidorDescripcionVar",  "",  "Distribuidor al que representa",  true,  "L") ;
         GXt_char2 = AV17UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WPFacturasColumnsSelector", out  GXt_char2) ;
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
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WPFacturasFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV21ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S202( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV263TFFacturaID = 0;
         AssignAttri("", false, "AV263TFFacturaID", StringUtil.LTrimStr( (decimal)(AV263TFFacturaID), 9, 0));
         AV264TFFacturaID_To = 0;
         AssignAttri("", false, "AV264TFFacturaID_To", StringUtil.LTrimStr( (decimal)(AV264TFFacturaID_To), 9, 0));
         AV41TFFacturaFechaRegistro = DateTime.MinValue;
         AssignAttri("", false, "AV41TFFacturaFechaRegistro", context.localUtil.Format(AV41TFFacturaFechaRegistro, "99/99/99"));
         AV42TFFacturaFechaRegistro_To = DateTime.MinValue;
         AssignAttri("", false, "AV42TFFacturaFechaRegistro_To", context.localUtil.Format(AV42TFFacturaFechaRegistro_To, "99/99/99"));
         AV28TFPromocionDescripcion = "";
         AssignAttri("", false, "AV28TFPromocionDescripcion", AV28TFPromocionDescripcion);
         AV29TFPromocionDescripcion_Sel = "";
         AssignAttri("", false, "AV29TFPromocionDescripcion_Sel", AV29TFPromocionDescripcion_Sel);
         AV34TFFacturaNo = "";
         AssignAttri("", false, "AV34TFFacturaNo", AV34TFFacturaNo);
         AV35TFFacturaNo_Sel = "";
         AssignAttri("", false, "AV35TFFacturaNo_Sel", AV35TFFacturaNo_Sel);
         AV36TFFacturaFechaFactura = DateTime.MinValue;
         AssignAttri("", false, "AV36TFFacturaFechaFactura", context.localUtil.Format(AV36TFFacturaFechaFactura, "99/99/99"));
         AV37TFFacturaFechaFactura_To = DateTime.MinValue;
         AssignAttri("", false, "AV37TFFacturaFechaFactura_To", context.localUtil.Format(AV37TFFacturaFechaFactura_To, "99/99/99"));
         AV73TFEstatusOperator = 0;
         AssignAttri("", false, "AV73TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV73TFEstatusOperator), 4, 0));
         Ddo_grid_Selectedfixedfilter = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
         AV48TFUsuarioNombreCompleto = "";
         AssignAttri("", false, "AV48TFUsuarioNombreCompleto", AV48TFUsuarioNombreCompleto);
         AV49TFUsuarioNombreCompleto_Sel = "";
         AssignAttri("", false, "AV49TFUsuarioNombreCompleto_Sel", AV49TFUsuarioNombreCompleto_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20Session.Get(AV265Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV265Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV20Session.Get(AV265Pgmname+"GridState"), null, "", "");
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
         S212 ();
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

      protected void S212( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV267GXV1 = 1;
         while ( AV267GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV267GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURAID") == 0 )
            {
               AV263TFFacturaID = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV263TFFacturaID", StringUtil.LTrimStr( (decimal)(AV263TFFacturaID), 9, 0));
               AV264TFFacturaID_To = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV264TFFacturaID_To", StringUtil.LTrimStr( (decimal)(AV264TFFacturaID_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURAFECHAREGISTRO") == 0 )
            {
               AV41TFFacturaFechaRegistro = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV41TFFacturaFechaRegistro", context.localUtil.Format(AV41TFFacturaFechaRegistro, "99/99/99"));
               AV42TFFacturaFechaRegistro_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV42TFFacturaFechaRegistro_To", context.localUtil.Format(AV42TFFacturaFechaRegistro_To, "99/99/99"));
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
               AV73TFEstatusOperator = AV11GridStateFilterValue.gxTpr_Operator;
               AssignAttri("", false, "AV73TFEstatusOperator", StringUtil.LTrimStr( (decimal)(AV73TFEstatusOperator), 4, 0));
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
            AV267GXV1 = (int)(AV267GXV1+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFPromocionDescripcion_Sel)),  AV29TFPromocionDescripcion_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFFacturaNo_Sel)),  AV35TFFacturaNo_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFUsuarioNombreCompleto_Sel)),  AV49TFUsuarioNombreCompleto_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = "||"+GXt_char2+"|"+GXt_char4+"|||||"+GXt_char5+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFPromocionDescripcion)),  AV28TFPromocionDescripcion, out  GXt_char5) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFFacturaNo)),  AV34TFFacturaNo, out  GXt_char4) ;
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFUsuarioNombreCompleto)),  AV48TFUsuarioNombreCompleto, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((0==AV263TFFacturaID) ? "" : StringUtil.Str( (decimal)(AV263TFFacturaID), 9, 0))+"|"+((DateTime.MinValue==AV41TFFacturaFechaRegistro) ? "" : context.localUtil.DToC( AV41TFFacturaFechaRegistro, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+GXt_char5+"|"+GXt_char4+"|"+((DateTime.MinValue==AV36TFFacturaFechaFactura) ? "" : context.localUtil.DToC( AV36TFFacturaFechaFactura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"||||"+GXt_char2+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV264TFFacturaID_To) ? "" : StringUtil.Str( (decimal)(AV264TFFacturaID_To), 9, 0))+"|"+((DateTime.MinValue==AV42TFFacturaFechaRegistro_To) ? "" : context.localUtil.DToC( AV42TFFacturaFechaRegistro_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|||"+((DateTime.MinValue==AV37TFFacturaFechaFactura_To) ? "" : context.localUtil.DToC( AV37TFFacturaFechaFactura_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         Ddo_grid_Selectedfixedfilter = "||||||"+((AV73TFEstatusOperator!=1) ? "" : "1")+((AV73TFEstatusOperator!=2) ? "" : "2")+((AV73TFEstatusOperator!=3) ? "" : "3")+((AV73TFEstatusOperator!=4) ? "" : "4")+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV20Session.Get(AV265Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFACTURAID",  context.GetMessage( "ID", ""),  !((0==AV263TFFacturaID)&&(0==AV264TFFacturaID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV263TFFacturaID), 9, 0)),  ((0==AV263TFFacturaID) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV263TFFacturaID), "ZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV264TFFacturaID_To), 9, 0)),  ((0==AV264TFFacturaID_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV264TFFacturaID_To), "ZZZZZZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFACTURAFECHAREGISTRO",  context.GetMessage( "Fecha Registro", ""),  !((DateTime.MinValue==AV41TFFacturaFechaRegistro)&&(DateTime.MinValue==AV42TFFacturaFechaRegistro_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV41TFFacturaFechaRegistro, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV41TFFacturaFechaRegistro) ? "" : StringUtil.Trim( context.localUtil.Format( AV41TFFacturaFechaRegistro, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV42TFFacturaFechaRegistro_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV42TFFacturaFechaRegistro_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV42TFFacturaFechaRegistro_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROMOCIONDESCRIPCION",  context.GetMessage( "Nom. Promoción", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFPromocionDescripcion)),  0,  AV28TFPromocionDescripcion,  AV28TFPromocionDescripcion,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFPromocionDescripcion_Sel)),  AV29TFPromocionDescripcion_Sel,  AV29TFPromocionDescripcion_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFFACTURANO",  context.GetMessage( "No. Factura", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFFacturaNo)),  0,  AV34TFFacturaNo,  AV34TFFacturaNo,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFFacturaNo_Sel)),  AV35TFFacturaNo_Sel,  AV35TFFacturaNo_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFACTURAFECHAFACTURA",  context.GetMessage( "Fecha Factura", ""),  !((DateTime.MinValue==AV36TFFacturaFechaFactura)&&(DateTime.MinValue==AV37TFFacturaFechaFactura_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV36TFFacturaFechaFactura, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV36TFFacturaFechaFactura) ? "" : StringUtil.Trim( context.localUtil.Format( AV36TFFacturaFechaFactura, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV37TFFacturaFechaFactura_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV37TFFacturaFechaFactura_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV37TFFacturaFechaFactura_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFESTATUS",  context.GetMessage( "Estatus", ""),  !(String.IsNullOrEmpty(StringUtil.RTrim( AV72TFEstatus))&&(0==AV73TFEstatusOperator)),  AV73TFEstatusOperator,  AV72TFEstatus,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV73TFEstatusOperator+1), 10, 0)), AV72TFEstatus, context.GetMessage( "En proceso", ""), context.GetMessage( "Aprobada", ""), context.GetMessage( "Rechazada", ""), context.GetMessage( "Cancelada", ""), "", "", "", ""),  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFUSUARIONOMBRECOMPLETO",  context.GetMessage( "Nombre completo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFUsuarioNombreCompleto)),  0,  AV48TFUsuarioNombreCompleto,  AV48TFUsuarioNombreCompleto,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFUsuarioNombreCompleto_Sel)),  AV49TFUsuarioNombreCompleto_Sel,  AV49TFUsuarioNombreCompleto_Sel) ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV265Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S142( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV265Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Factura";
         AV20Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void S122( )
      {
         /* 'LOADCOMBODISTRIBUIDORID' Routine */
         returnInSub = false;
         /* Using cursor H002Z4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A10DistribuidorID = H002Z4_A10DistribuidorID[0];
            A11DistribuidorDescripcion = H002Z4_A11DistribuidorDescripcion[0];
            AV138Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV138Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A10DistribuidorID), 9, 0));
            AV138Combo_DataItem.gxTpr_Title = A11DistribuidorDescripcion;
            AV137DistribuidorID_Data.Add(AV138Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_distribuidorid_Selectedvalue_set = AV126DistribuidorID.ToJSonString(false);
         ucCombo_distribuidorid.SendProperty(context, "", false, Combo_distribuidorid_Internalname, "SelectedValue_set", Combo_distribuidorid_Selectedvalue_set);
      }

      protected void E222Z2( )
      {
         /* Useraction4_Click Routine */
         returnInSub = false;
         AV123FacturaID = A69FacturaID;
         AssignAttri("", false, "AV123FacturaID", StringUtil.LTrimStr( (decimal)(AV123FacturaID), 9, 0));
         /* Execute user subroutine: 'OBTIENEPDF' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV84FileURL = context.PathToUrl( AV85Blob);
         Innwewindow_Target = AV84FileURL;
         ucInnwewindow.SendProperty(context, "", false, Innwewindow_Internalname, "Target", Innwewindow_Target);
         this.executeUsercontrolMethod("", false, "INNWEWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E232Z2( )
      {
         /* Useraction2_Click Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(AV262UsuarioCorreo, context.GetMessage( "lehr777@hotmail.com", "")) == 0 ) || ( StringUtil.StrCmp(AV262UsuarioCorreo, context.GetMessage( "mercadotecnia@yokohamatire.mx", "")) == 0 ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpcambiarestatus.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A69FacturaID,9,0));
            context.PopUp(formatLink("wpcambiarestatus.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            context.DoAjaxRefresh();
         }
         else
         {
            if ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "wpcambiarestatus.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A69FacturaID,9,0));
               context.PopUp(formatLink("wpcambiarestatus.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
               context.DoAjaxRefresh();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV184ListaUsuarios", AV184ListaUsuarios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E242Z2( )
      {
         /* Useraction1_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpdetallefactura.aspx"+UrlEncode(StringUtil.LTrimStr(A69FacturaID,9,0));
         CallWebObject(formatLink("wpdetallefactura.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S192( )
      {
         /* 'OBTIENEDISTRIBUIDOR' Routine */
         returnInSub = false;
         /* Using cursor H002Z5 */
         pr_default.execute(3, new Object[] {AV91RegUsuarioID});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A10DistribuidorID = H002Z5_A10DistribuidorID[0];
            A29UsuarioID = H002Z5_A29UsuarioID[0];
            A11DistribuidorDescripcion = H002Z5_A11DistribuidorDescripcion[0];
            A81DistribuidoresUsuarioID = H002Z5_A81DistribuidoresUsuarioID[0];
            A11DistribuidorDescripcion = H002Z5_A11DistribuidorDescripcion[0];
            AV97DistribuidorDescripcionVar = A11DistribuidorDescripcion;
            AssignAttri("", false, edtavDistribuidordescripcionvar_Internalname, AV97DistribuidorDescripcionVar);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S222( )
      {
         /* 'OBTIENEPDF' Routine */
         returnInSub = false;
         /* Using cursor H002Z6 */
         pr_default.execute(4, new Object[] {AV123FacturaID});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A69FacturaID = H002Z6_A69FacturaID[0];
            A40000FacturaPDF_GXI = H002Z6_A40000FacturaPDF_GXI[0];
            A75FacturaPDF = H002Z6_A75FacturaPDF[0];
            AV85Blob = A75FacturaPDF;
            AssignAttri("", false, "AV85Blob", AV85Blob);
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
         AV184ListaUsuarios.Clear();
         if ( AV126DistribuidorID.Count == 0 )
         {
            /* Using cursor H002Z7 */
            pr_default.execute(5);
            while ( (pr_default.getStatus(5) != 101) )
            {
               A40UsuarioRol = H002Z7_A40UsuarioRol[0];
               A29UsuarioID = H002Z7_A29UsuarioID[0];
               A40UsuarioRol = H002Z7_A40UsuarioRol[0];
               AV197Pasa = false;
               AV272GXV2 = 1;
               while ( AV272GXV2 <= AV184ListaUsuarios.Count )
               {
                  AV244UsuariosListaID = (int)(AV184ListaUsuarios.GetNumeric(AV272GXV2));
                  if ( AV244UsuariosListaID == A29UsuarioID )
                  {
                     AV197Pasa = true;
                     if (true) break;
                  }
                  AV272GXV2 = (int)(AV272GXV2+1);
               }
               if ( ! AV197Pasa )
               {
                  AV184ListaUsuarios.Add(A29UsuarioID, 0);
               }
               pr_default.readNext(5);
            }
            pr_default.close(5);
         }
         else
         {
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 A10DistribuidorID ,
                                                 AV126DistribuidorID ,
                                                 A40UsuarioRol } ,
                                                 new int[]{
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor H002Z8 */
            pr_default.execute(6);
            while ( (pr_default.getStatus(6) != 101) )
            {
               A40UsuarioRol = H002Z8_A40UsuarioRol[0];
               A10DistribuidorID = H002Z8_A10DistribuidorID[0];
               A29UsuarioID = H002Z8_A29UsuarioID[0];
               A40UsuarioRol = H002Z8_A40UsuarioRol[0];
               AV197Pasa = false;
               AV274GXV3 = 1;
               while ( AV274GXV3 <= AV184ListaUsuarios.Count )
               {
                  AV244UsuariosListaID = (int)(AV184ListaUsuarios.GetNumeric(AV274GXV3));
                  if ( AV244UsuariosListaID == A29UsuarioID )
                  {
                     AV197Pasa = true;
                     if (true) break;
                  }
                  AV274GXV3 = (int)(AV274GXV3+1);
               }
               if ( ! AV197Pasa )
               {
                  AV184ListaUsuarios.Add(A29UsuarioID, 0);
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
         PA2Z2( ) ;
         WS2Z2( ) ;
         WE2Z2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202651111311161", true, true);
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
         context.AddJavascriptSource("wpfacturas.js", "?202651111311161", false, true);
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

      protected void SubsflControlProps_652( )
      {
         edtFacturaID_Internalname = "FACTURAID_"+sGXsfl_65_idx;
         edtavUseraction4_Internalname = "vUSERACTION4_"+sGXsfl_65_idx;
         edtavUseraction1_Internalname = "vUSERACTION1_"+sGXsfl_65_idx;
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO_"+sGXsfl_65_idx;
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION_"+sGXsfl_65_idx;
         edtFacturaNo_Internalname = "FACTURANO_"+sGXsfl_65_idx;
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA_"+sGXsfl_65_idx;
         edtavPartidaswithtags_Internalname = "vPARTIDASWITHTAGS_"+sGXsfl_65_idx;
         edtavPartidas_Internalname = "vPARTIDAS_"+sGXsfl_65_idx;
         edtavUseraction2_Internalname = "vUSERACTION2_"+sGXsfl_65_idx;
         edtavEstatuswithtags_Internalname = "vESTATUSWITHTAGS_"+sGXsfl_65_idx;
         edtavEstatus_Internalname = "vESTATUS_"+sGXsfl_65_idx;
         edtavDescripcion_Internalname = "vDESCRIPCION_"+sGXsfl_65_idx;
         cmbFacturaEstatus_Internalname = "FACTURAESTATUS_"+sGXsfl_65_idx;
         edtUsuarioID_Internalname = "USUARIOID_"+sGXsfl_65_idx;
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO_"+sGXsfl_65_idx;
         chkMotivoRechazoActivo_Internalname = "MOTIVORECHAZOACTIVO_"+sGXsfl_65_idx;
         edtMotivoRechazoDescripcion_Internalname = "MOTIVORECHAZODESCRIPCION_"+sGXsfl_65_idx;
         edtMotivoRechazoID_Internalname = "MOTIVORECHAZOID_"+sGXsfl_65_idx;
         edtavDistribuidordescripcionvar_Internalname = "vDISTRIBUIDORDESCRIPCIONVAR_"+sGXsfl_65_idx;
      }

      protected void SubsflControlProps_fel_652( )
      {
         edtFacturaID_Internalname = "FACTURAID_"+sGXsfl_65_fel_idx;
         edtavUseraction4_Internalname = "vUSERACTION4_"+sGXsfl_65_fel_idx;
         edtavUseraction1_Internalname = "vUSERACTION1_"+sGXsfl_65_fel_idx;
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO_"+sGXsfl_65_fel_idx;
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION_"+sGXsfl_65_fel_idx;
         edtFacturaNo_Internalname = "FACTURANO_"+sGXsfl_65_fel_idx;
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA_"+sGXsfl_65_fel_idx;
         edtavPartidaswithtags_Internalname = "vPARTIDASWITHTAGS_"+sGXsfl_65_fel_idx;
         edtavPartidas_Internalname = "vPARTIDAS_"+sGXsfl_65_fel_idx;
         edtavUseraction2_Internalname = "vUSERACTION2_"+sGXsfl_65_fel_idx;
         edtavEstatuswithtags_Internalname = "vESTATUSWITHTAGS_"+sGXsfl_65_fel_idx;
         edtavEstatus_Internalname = "vESTATUS_"+sGXsfl_65_fel_idx;
         edtavDescripcion_Internalname = "vDESCRIPCION_"+sGXsfl_65_fel_idx;
         cmbFacturaEstatus_Internalname = "FACTURAESTATUS_"+sGXsfl_65_fel_idx;
         edtUsuarioID_Internalname = "USUARIOID_"+sGXsfl_65_fel_idx;
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO_"+sGXsfl_65_fel_idx;
         chkMotivoRechazoActivo_Internalname = "MOTIVORECHAZOACTIVO_"+sGXsfl_65_fel_idx;
         edtMotivoRechazoDescripcion_Internalname = "MOTIVORECHAZODESCRIPCION_"+sGXsfl_65_fel_idx;
         edtMotivoRechazoID_Internalname = "MOTIVORECHAZOID_"+sGXsfl_65_fel_idx;
         edtavDistribuidordescripcionvar_Internalname = "vDISTRIBUIDORDESCRIPCIONVAR_"+sGXsfl_65_fel_idx;
      }

      protected void sendrow_652( )
      {
         sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
         SubsflControlProps_652( ) ;
         WB2Z0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_65_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_65_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_65_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtFacturaID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtFacturaID_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',65)\"";
            ClassString = "BotonImagenChica" + " " + ((StringUtil.StrCmp(edtavUseraction4_gximage, "")==0) ? "" : "GX_Image_"+edtavUseraction4_gximage+"_Class");
            StyleString = "";
            AV79UserAction4_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV79UserAction4))&&String.IsNullOrEmpty(StringUtil.RTrim( AV266Useraction4_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV79UserAction4)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV79UserAction4)) ? AV266Useraction4_GXI : context.PathToRelativeUrl( AV79UserAction4));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseraction4_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)edtavUseraction4_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavUseraction4_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVUSERACTION4.CLICK."+sGXsfl_65_idx+"'",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV79UserAction4_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_65_idx + "',65)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseraction1_Internalname,StringUtil.RTrim( AV83UserAction1),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"","'"+""+"'"+",false,"+"'"+"EVUSERACTION1.CLICK."+sGXsfl_65_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUseraction1_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUseraction1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtFacturaFechaRegistro_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaRegistro_Internalname,context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"),context.localUtil.Format( A72FacturaFechaRegistro, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaRegistro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtFacturaFechaRegistro_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPromocionDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionDescripcion_Internalname,(string)A42PromocionDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPromocionDescripcion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtFacturaNo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaNo_Internalname,StringUtil.RTrim( A71FacturaNo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaNo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtFacturaNo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtFacturaFechaFactura_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaFactura_Internalname,context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"),context.localUtil.Format( A73FacturaFechaFactura, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaFactura_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtFacturaFechaFactura_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavPartidaswithtags_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_65_idx + "',65)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPartidaswithtags_Internalname,(string)AV87PartidasWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPartidaswithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnSizeLarge ColumnWeightBold ColumnHighlightBackground ColumnLeftDivision",(string)"",(int)edtavPartidaswithtags_Visible,(int)edtavPartidaswithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPartidas_Internalname,StringUtil.RTrim( AV86Partidas),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ","'"+""+"'"+",false,"+"'"+"EVPARTIDAS.CLICK."+sGXsfl_65_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPartidas_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnSizeLarge ColumnWeightBold ColumnHighlightBackground ColumnLeftDivision",(string)"",(short)0,(int)edtavPartidas_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUseraction2_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_65_idx + "',65)\"";
            ROClassString = edtavUseraction2_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseraction2_Internalname,StringUtil.RTrim( AV80UserAction2),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"","'"+""+"'"+",false,"+"'"+"EVUSERACTION2.CLICK."+sGXsfl_65_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUseraction2_Jsonclick,(short)5,(string)edtavUseraction2_Class,(string)"",(string)ROClassString,(string)"WWActionColumn",(string)"",(int)edtavUseraction2_Visible,(int)edtavUseraction2_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavEstatuswithtags_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_65_idx + "',65)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEstatuswithtags_Internalname,(string)AV71EstatusWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEstatuswithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavEstatuswithtags_Visible,(int)edtavEstatuswithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEstatus_Internalname,StringUtil.RTrim( AV70Estatus),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEstatus_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavEstatus_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_65_idx + "',65)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDescripcion_Internalname,(string)AV81Descripcion,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavDescripcion_Visible,(int)edtavDescripcion_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbFacturaEstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "FACTURAESTATUS_" + sGXsfl_65_idx;
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
            AssignProp("", false, cmbFacturaEstatus_Internalname, "Values", (string)(cmbFacturaEstatus.ToJavascriptSource()), !bGXsfl_65_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtUsuarioNombreCompleto_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombreCompleto_Internalname,(string)A52UsuarioNombreCompleto,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombreCompleto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtUsuarioNombreCompleto_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "MOTIVORECHAZOACTIVO_" + sGXsfl_65_idx;
            chkMotivoRechazoActivo.Name = GXCCtl;
            chkMotivoRechazoActivo.WebTags = "";
            chkMotivoRechazoActivo.Caption = "";
            AssignProp("", false, chkMotivoRechazoActivo_Internalname, "TitleCaption", chkMotivoRechazoActivo.Caption, !bGXsfl_65_Refreshing);
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoRechazoDescripcion_Internalname,(string)A20MotivoRechazoDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoRechazoDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoRechazoID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MotivoRechazoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A19MotivoRechazoID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoRechazoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDistribuidordescripcionvar_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_65_idx + "',65)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDistribuidordescripcionvar_Internalname,(string)AV97DistribuidorDescripcionVar,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDistribuidordescripcionvar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavDistribuidordescripcionvar_Visible,(int)edtavDistribuidordescripcionvar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2Z2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_65_idx = ((subGrid_Islastpage==1)&&(nGXsfl_65_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_65_idx+1);
            sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
            SubsflControlProps_652( ) ;
         }
         /* End function sendrow_652 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "FACTURAESTATUS_" + sGXsfl_65_idx;
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
         GXCCtl = "MOTIVORECHAZOACTIVO_" + sGXsfl_65_idx;
         chkMotivoRechazoActivo.Name = GXCCtl;
         chkMotivoRechazoActivo.WebTags = "";
         chkMotivoRechazoActivo.Caption = "";
         AssignProp("", false, chkMotivoRechazoActivo_Internalname, "TitleCaption", chkMotivoRechazoActivo.Caption, !bGXsfl_65_Refreshing);
         chkMotivoRechazoActivo.CheckedValue = "false";
         A21MotivoRechazoActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A21MotivoRechazoActivo));
         /* End function init_web_controls */
      }

      protected void StartGridControl65( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"65\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtFacturaID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "ID", "")) ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavUseraction2_Class+"\" "+" style=\""+((edtavUseraction2_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDistribuidordescripcionvar_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaID_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV79UserAction4));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUseraction4_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV83UserAction1)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction1_Enabled), 5, 0, ".", "")));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV87PartidasWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPartidaswithtags_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPartidaswithtags_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV86Partidas)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPartidas_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV80UserAction2)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavUseraction2_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction2_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction2_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV71EstatusWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEstatuswithtags_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEstatuswithtags_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV70Estatus)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEstatus_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV81Descripcion));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV97DistribuidorDescripcionVar));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDistribuidordescripcionvar_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDistribuidordescripcionvar_Visible), 5, 0, ".", "")));
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
         bttBtnuseraction99_Internalname = "BTNUSERACTION99";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Utchartdoughnut_Internalname = "UTCHARTDOUGHNUT";
         Utchartcolumnline_Internalname = "UTCHARTCOLUMNLINE";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
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
         edtavUseraction1_Internalname = "vUSERACTION1";
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO";
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION";
         edtFacturaNo_Internalname = "FACTURANO";
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA";
         edtavPartidaswithtags_Internalname = "vPARTIDASWITHTAGS";
         edtavPartidas_Internalname = "vPARTIDAS";
         edtavUseraction2_Internalname = "vUSERACTION2";
         edtavEstatuswithtags_Internalname = "vESTATUSWITHTAGS";
         edtavEstatus_Internalname = "vESTATUS";
         edtavDescripcion_Internalname = "vDESCRIPCION";
         cmbFacturaEstatus_Internalname = "FACTURAESTATUS";
         edtUsuarioID_Internalname = "USUARIOID";
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO";
         chkMotivoRechazoActivo_Internalname = "MOTIVORECHAZOACTIVO";
         edtMotivoRechazoDescripcion_Internalname = "MOTIVORECHAZODESCRIPCION";
         edtMotivoRechazoID_Internalname = "MOTIVORECHAZOID";
         edtavDistribuidordescripcionvar_Internalname = "vDISTRIBUIDORDESCRIPCIONVAR";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         Innwewindow_Internalname = "INNWEWINDOW";
         divTablemain_Internalname = "TABLEMAIN";
         Popover_partidas_Internalname = "POPOVER_PARTIDAS";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
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
         edtavUseraction1_Jsonclick = "";
         edtavUseraction1_Enabled = 1;
         edtavUseraction4_Jsonclick = "";
         edtavUseraction4_gximage = "";
         edtavUseraction4_Tooltiptext = "";
         edtFacturaID_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridNoBorder WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDistribuidordescripcionvar_Visible = -1;
         edtUsuarioNombreCompleto_Visible = -1;
         edtavDescripcion_Visible = -1;
         edtavEstatuswithtags_Visible = -1;
         edtavPartidaswithtags_Visible = -1;
         edtFacturaFechaFactura_Visible = -1;
         edtFacturaNo_Visible = -1;
         edtPromocionDescripcion_Visible = -1;
         edtFacturaFechaRegistro_Visible = -1;
         edtFacturaID_Visible = -1;
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
         Combo_distribuidorid_Caption = "";
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
         Ddo_grid_Format = "9.0|||||||||";
         Ddo_grid_Fixedfilters = "||||||1:En proceso:fa fa-circle FontColorIconWarning FontColorIconSmall ConditionalFormattingFilterIcon,2:Aprobada:fa fa-circle FontColorIconSuccess FontColorIconSmall ConditionalFormattingFilterIcon,3:Rechazada:fa fa-circle FontColorIconDanger FontColorIconSmall ConditionalFormattingFilterIcon,4:Cancelada:fa fa-circle FontColorIconInfo FontColorIconSmall ConditionalFormattingFilterIcon|||";
         Ddo_grid_Datalistproc = "WPFacturasGetFilterData";
         Ddo_grid_Datalisttype = "||Dynamic|Dynamic|||||Dynamic|";
         Ddo_grid_Includedatalist = "||T|T|||||T|";
         Ddo_grid_Filterisrange = "T|P|||P|||||";
         Ddo_grid_Filtertype = "Numeric|Date|Character|Character|Date||||Character|";
         Ddo_grid_Includefilter = "T|T|T|T|T||||T|";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|T|||||";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|||||";
         Ddo_grid_Columnids = "0:FacturaID|3:FacturaFechaRegistro|4:PromocionDescripcion|5:FacturaNo|6:FacturaFechaFactura|7:Partidas|10:Estatus|12:Descripcion|15:UsuarioNombreCompleto|19:DistribuidorDescripcionVar";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( " Factura", "");
         edtavUseraction2_Visible = -1;
         edtavUseraction2_Class = "Attribute";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"edtavUseraction2_Class","ctrl":"vUSERACTION2","prop":"Class"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV70Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV265Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV126DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"AV263TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV264TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV73TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV72TFEstatus","fld":"vTFESTATUS"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV91RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV262UsuarioCorreo","fld":"vUSUARIOCORREO","hsh":true},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtFacturaID_Visible","ctrl":"FACTURAID","prop":"Visible"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcionvar_Visible","ctrl":"vDISTRIBUIDORDESCRIPCIONVAR","prop":"Visible"},{"av":"AV62GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV63GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV64GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV184ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E132Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV265Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV126DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"AV263TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV264TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV73TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV72TFEstatus","fld":"vTFESTATUS"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"edtavUseraction2_Class","ctrl":"vUSERACTION2","prop":"Class"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV70Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV91RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV262UsuarioCorreo","fld":"vUSUARIOCORREO","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E142Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV265Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV126DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"AV263TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV264TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV73TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV72TFEstatus","fld":"vTFESTATUS"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"edtavUseraction2_Class","ctrl":"vUSERACTION2","prop":"Class"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV70Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV91RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV262UsuarioCorreo","fld":"vUSUARIOCORREO","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E152Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV265Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV126DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"AV263TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV264TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV73TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV72TFEstatus","fld":"vTFESTATUS"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"edtavUseraction2_Class","ctrl":"vUSERACTION2","prop":"Class"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV70Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV91RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV262UsuarioCorreo","fld":"vUSUARIOCORREO","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Selectedcolumnfixedfilter","ctrl":"DDO_GRID","prop":"SelectedColumnFixedFilter"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV72TFEstatus","fld":"vTFESTATUS"},{"av":"AV73TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV263TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV264TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E202Z2","iparms":[{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS","hsh":true},{"av":"A20MotivoRechazoDescripcion","fld":"MOTIVORECHAZODESCRIPCION"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV70Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV91RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV81Descripcion","fld":"vDESCRIPCION"},{"av":"AV86Partidas","fld":"vPARTIDAS"},{"av":"AV91RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV79UserAction4","fld":"vUSERACTION4"},{"av":"edtavUseraction4_Tooltiptext","ctrl":"vUSERACTION4","prop":"Tooltiptext"},{"av":"AV83UserAction1","fld":"vUSERACTION1"},{"av":"AV80UserAction2","fld":"vUSERACTION2"},{"av":"AV87PartidasWithTags","fld":"vPARTIDASWITHTAGS"},{"av":"AV71EstatusWithTags","fld":"vESTATUSWITHTAGS"},{"av":"AV97DistribuidorDescripcionVar","fld":"vDISTRIBUIDORDESCRIPCIONVAR"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E162Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV265Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV126DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"AV263TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV264TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV73TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV72TFEstatus","fld":"vTFESTATUS"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"edtavUseraction2_Class","ctrl":"vUSERACTION2","prop":"Class"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV70Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV91RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV262UsuarioCorreo","fld":"vUSUARIOCORREO","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtFacturaID_Visible","ctrl":"FACTURAID","prop":"Visible"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcionvar_Visible","ctrl":"vDISTRIBUIDORDESCRIPCIONVAR","prop":"Visible"},{"av":"AV62GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV63GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV64GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV184ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E122Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV265Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV126DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"AV263TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV264TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV73TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV72TFEstatus","fld":"vTFESTATUS"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"edtavUseraction2_Class","ctrl":"vUSERACTION2","prop":"Class"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV70Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV91RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV262UsuarioCorreo","fld":"vUSUARIOCORREO","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV263TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV264TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV73TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"Ddo_grid_Selectedfixedfilter","ctrl":"DDO_GRID","prop":"SelectedFixedFilter"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtFacturaID_Visible","ctrl":"FACTURAID","prop":"Visible"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcionvar_Visible","ctrl":"vDISTRIBUIDORDESCRIPCIONVAR","prop":"Visible"},{"av":"AV62GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV63GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV64GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV184ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOUSERACTION99'","""{"handler":"E172Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV265Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV126DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"AV263TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV264TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV73TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV72TFEstatus","fld":"vTFESTATUS"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"edtavUseraction2_Class","ctrl":"vUSERACTION2","prop":"Class"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV70Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV91RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV262UsuarioCorreo","fld":"vUSUARIOCORREO","hsh":true},{"av":"AV184ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOUSERACTION99'",""","oparms":[{"ctrl":"UTCHARTDOUGHNUT"},{"ctrl":"UTCHARTCOLUMNLINE"},{"av":"AV184ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtFacturaID_Visible","ctrl":"FACTURAID","prop":"Visible"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcionvar_Visible","ctrl":"vDISTRIBUIDORDESCRIPCIONVAR","prop":"Visible"},{"av":"AV62GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV63GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV64GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VPARTIDAS.CLICK","""{"handler":"E212Z2","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("VPARTIDAS.CLICK",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("COMBO_DISTRIBUIDORID.ONOPTIONCLICKED","""{"handler":"E112Z2","iparms":[{"av":"Combo_distribuidorid_Selectedvalue_get","ctrl":"COMBO_DISTRIBUIDORID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_DISTRIBUIDORID.ONOPTIONCLICKED",""","oparms":[{"av":"AV126DistribuidorID","fld":"vDISTRIBUIDORID"}]}""");
         setEventMetadata("VUSERACTION4.CLICK","""{"handler":"E222Z2","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV85Blob","fld":"vBLOB"},{"av":"AV123FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"A75FacturaPDF","fld":"FACTURAPDF"}]""");
         setEventMetadata("VUSERACTION4.CLICK",""","oparms":[{"av":"AV123FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"Innwewindow_Target","ctrl":"INNWEWINDOW","prop":"Target"},{"av":"AV85Blob","fld":"vBLOB"}]}""");
         setEventMetadata("VUSERACTION2.CLICK","""{"handler":"E232Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV124FromDate","fld":"vFROMDATE"},{"av":"AV125ToDate","fld":"vTODATE"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV265Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV126DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"AV263TFFacturaID","fld":"vTFFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV264TFFacturaID_To","fld":"vTFFACTURAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV41TFFacturaFechaRegistro","fld":"vTFFACTURAFECHAREGISTRO"},{"av":"AV42TFFacturaFechaRegistro_To","fld":"vTFFACTURAFECHAREGISTRO_TO"},{"av":"AV28TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV29TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV34TFFacturaNo","fld":"vTFFACTURANO"},{"av":"AV35TFFacturaNo_Sel","fld":"vTFFACTURANO_SEL"},{"av":"AV36TFFacturaFechaFactura","fld":"vTFFACTURAFECHAFACTURA"},{"av":"AV37TFFacturaFechaFactura_To","fld":"vTFFACTURAFECHAFACTURA_TO"},{"av":"AV73TFEstatusOperator","fld":"vTFESTATUSOPERATOR","pic":"ZZZ9"},{"av":"AV72TFEstatus","fld":"vTFESTATUS"},{"av":"AV48TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV49TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"edtavUseraction2_Class","ctrl":"vUSERACTION2","prop":"Class"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV70Estatus","fld":"vESTATUS","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV91RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV262UsuarioCorreo","fld":"vUSUARIOCORREO","hsh":true},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS","hsh":true},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("VUSERACTION2.CLICK",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtFacturaID_Visible","ctrl":"FACTURAID","prop":"Visible"},{"av":"edtFacturaFechaRegistro_Visible","ctrl":"FACTURAFECHAREGISTRO","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtFacturaNo_Visible","ctrl":"FACTURANO","prop":"Visible"},{"av":"edtFacturaFechaFactura_Visible","ctrl":"FACTURAFECHAFACTURA","prop":"Visible"},{"av":"edtavPartidaswithtags_Visible","ctrl":"vPARTIDASWITHTAGS","prop":"Visible"},{"av":"edtavEstatuswithtags_Visible","ctrl":"vESTATUSWITHTAGS","prop":"Visible"},{"av":"edtavDescripcion_Visible","ctrl":"vDESCRIPCION","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtavDistribuidordescripcionvar_Visible","ctrl":"vDISTRIBUIDORDESCRIPCIONVAR","prop":"Visible"},{"av":"AV62GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV63GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV64GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUseraction2_Visible","ctrl":"vUSERACTION2","prop":"Visible"},{"av":"AV184ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VUSERACTION1.CLICK","""{"handler":"E242Z2","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("VALIDV_FROMDATE","""{"handler":"Validv_Fromdate","iparms":[]}""");
         setEventMetadata("VALIDV_TODATE","""{"handler":"Validv_Todate","iparms":[]}""");
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
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Combo_distribuidorid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV124FromDate = DateTime.MinValue;
         AV125ToDate = DateTime.MinValue;
         AV15FilterFullText = "";
         AV18ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV265Pgmname = "";
         AV126DistribuidorID = new GxSimpleCollection<int>();
         A40UsuarioRol = "";
         AV41TFFacturaFechaRegistro = DateTime.MinValue;
         AV42TFFacturaFechaRegistro_To = DateTime.MinValue;
         AV28TFPromocionDescripcion = "";
         AV29TFPromocionDescripcion_Sel = "";
         AV34TFFacturaNo = "";
         AV35TFFacturaNo_Sel = "";
         AV36TFFacturaFechaFactura = DateTime.MinValue;
         AV37TFFacturaFechaFactura_To = DateTime.MinValue;
         AV72TFEstatus = "";
         AV48TFUsuarioNombreCompleto = "";
         AV49TFUsuarioNombreCompleto_Sel = "";
         AV70Estatus = "";
         A11DistribuidorDescripcion = "";
         AV262UsuarioCorreo = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV60DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV137DistribuidorID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV252Elements = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         AV253Parameters = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter>( context, "Parameter", "GeneXus.Reporting");
         AV254ItemClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData(context);
         AV255ItemDoubleClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData(context);
         AV256DragAndDropData = new GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData(context);
         AV257FilterChangedData = new GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData(context);
         AV258ItemExpandData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData(context);
         AV259ItemCollapseData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData(context);
         AV21ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV64GridAppliedFilters = "";
         AV249DDO_FacturaFechaRegistroAuxDateTo = DateTime.MinValue;
         AV251DDO_FacturaFechaFacturaAuxDateTo = DateTime.MinValue;
         AV10GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV184ListaUsuarios = new GxSimpleCollection<int>();
         AV85Blob = "";
         A75FacturaPDF = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         AV248DDO_FacturaFechaRegistroAuxDate = DateTime.MinValue;
         AV250DDO_FacturaFechaFacturaAuxDate = DateTime.MinValue;
         Combo_distribuidorid_Selectedvalue_set = "";
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
         lblTextblockcombo_distribuidorid_Jsonclick = "";
         ucCombo_distribuidorid = new GXUserControl();
         bttBtnuseraction99_Jsonclick = "";
         ucUtchartdoughnut = new GXUserControl();
         ucUtchartcolumnline = new GXUserControl();
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
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV79UserAction4 = "";
         AV266Useraction4_GXI = "";
         AV83UserAction1 = "";
         A72FacturaFechaRegistro = DateTime.MinValue;
         A42PromocionDescripcion = "";
         A71FacturaNo = "";
         A73FacturaFechaFactura = DateTime.MinValue;
         AV87PartidasWithTags = "";
         AV86Partidas = "";
         AV80UserAction2 = "";
         AV71EstatusWithTags = "";
         AV81Descripcion = "";
         A80FacturaEstatus = "";
         A52UsuarioNombreCompleto = "";
         A20MotivoRechazoDescripcion = "";
         AV97DistribuidorDescripcionVar = "";
         lV15FilterFullText = "";
         lV28TFPromocionDescripcion = "";
         lV34TFFacturaNo = "";
         lV48TFUsuarioNombreCompleto = "";
         H002Z2_A41PromocionID = new int[1] ;
         H002Z2_A93FacturaCompleta = new bool[] {false} ;
         H002Z2_A19MotivoRechazoID = new int[1] ;
         H002Z2_A20MotivoRechazoDescripcion = new string[] {""} ;
         H002Z2_A21MotivoRechazoActivo = new bool[] {false} ;
         H002Z2_A29UsuarioID = new int[1] ;
         H002Z2_A80FacturaEstatus = new string[] {""} ;
         H002Z2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         H002Z2_A71FacturaNo = new string[] {""} ;
         H002Z2_A42PromocionDescripcion = new string[] {""} ;
         H002Z2_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         H002Z2_A69FacturaID = new int[1] ;
         H002Z2_A51UsuarioApellido = new string[] {""} ;
         H002Z2_A30UsuarioNombre = new string[] {""} ;
         H002Z3_AGRID_nRecordCount = new long[1] ;
         AV74UsuarioJSON = "";
         AV76WebSession = context.GetSession();
         AV75SDTUsuario = new SdtSDTUsuario(context);
         AV77UsuarioRol = "";
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
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         H002Z4_A10DistribuidorID = new int[1] ;
         H002Z4_A11DistribuidorDescripcion = new string[] {""} ;
         AV138Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV84FileURL = "";
         H002Z5_A10DistribuidorID = new int[1] ;
         H002Z5_A29UsuarioID = new int[1] ;
         H002Z5_A11DistribuidorDescripcion = new string[] {""} ;
         H002Z5_A81DistribuidoresUsuarioID = new int[1] ;
         H002Z6_A69FacturaID = new int[1] ;
         H002Z6_A40000FacturaPDF_GXI = new string[] {""} ;
         H002Z6_A75FacturaPDF = new string[] {""} ;
         A40000FacturaPDF_GXI = "";
         H002Z7_A81DistribuidoresUsuarioID = new int[1] ;
         H002Z7_A40UsuarioRol = new string[] {""} ;
         H002Z7_A29UsuarioID = new int[1] ;
         H002Z8_A81DistribuidoresUsuarioID = new int[1] ;
         H002Z8_A40UsuarioRol = new string[] {""} ;
         H002Z8_A10DistribuidorID = new int[1] ;
         H002Z8_A29UsuarioID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpfacturas__default(),
            new Object[][] {
                new Object[] {
               H002Z2_A41PromocionID, H002Z2_A93FacturaCompleta, H002Z2_A19MotivoRechazoID, H002Z2_A20MotivoRechazoDescripcion, H002Z2_A21MotivoRechazoActivo, H002Z2_A29UsuarioID, H002Z2_A80FacturaEstatus, H002Z2_A73FacturaFechaFactura, H002Z2_A71FacturaNo, H002Z2_A42PromocionDescripcion,
               H002Z2_A72FacturaFechaRegistro, H002Z2_A69FacturaID, H002Z2_A51UsuarioApellido, H002Z2_A30UsuarioNombre
               }
               , new Object[] {
               H002Z3_AGRID_nRecordCount
               }
               , new Object[] {
               H002Z4_A10DistribuidorID, H002Z4_A11DistribuidorDescripcion
               }
               , new Object[] {
               H002Z5_A10DistribuidorID, H002Z5_A29UsuarioID, H002Z5_A11DistribuidorDescripcion, H002Z5_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               H002Z6_A69FacturaID, H002Z6_A40000FacturaPDF_GXI, H002Z6_A75FacturaPDF
               }
               , new Object[] {
               H002Z7_A81DistribuidoresUsuarioID, H002Z7_A40UsuarioRol, H002Z7_A29UsuarioID
               }
               , new Object[] {
               H002Z8_A81DistribuidoresUsuarioID, H002Z8_A40UsuarioRol, H002Z8_A10DistribuidorID, H002Z8_A29UsuarioID
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV265Pgmname = "WPFacturas";
         /* GeneXus formulas. */
         AV265Pgmname = "WPFacturas";
         edtavUseraction1_Enabled = 0;
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
      private short AV12OrderedBy ;
      private short AV23ManageFiltersExecutionStep ;
      private short AV73TFEstatusOperator ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
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
      private int edtavUseraction2_Visible ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_65 ;
      private int nGXsfl_65_idx=1 ;
      private int A10DistribuidorID ;
      private int AV263TFFacturaID ;
      private int AV264TFFacturaID_To ;
      private int A81DistribuidoresUsuarioID ;
      private int AV91RegUsuarioID ;
      private int AV123FacturaID ;
      private int Gridpaginationbar_Pagestoshow ;
      private int Popover_partidas_Popoverwidth ;
      private int edtavFromdate_Enabled ;
      private int edtavTodate_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int A69FacturaID ;
      private int A29UsuarioID ;
      private int A19MotivoRechazoID ;
      private int subGrid_Islastpage ;
      private int edtavUseraction1_Enabled ;
      private int edtavPartidaswithtags_Enabled ;
      private int edtavPartidas_Enabled ;
      private int edtavUseraction2_Enabled ;
      private int edtavEstatuswithtags_Enabled ;
      private int edtavEstatus_Enabled ;
      private int edtavDescripcion_Enabled ;
      private int edtavDistribuidordescripcionvar_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV184ListaUsuarios_Count ;
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
      private int edtFacturaID_Visible ;
      private int edtFacturaFechaRegistro_Visible ;
      private int edtPromocionDescripcion_Visible ;
      private int edtFacturaNo_Visible ;
      private int edtFacturaFechaFactura_Visible ;
      private int edtavPartidaswithtags_Visible ;
      private int edtavEstatuswithtags_Visible ;
      private int edtavDescripcion_Visible ;
      private int edtUsuarioNombreCompleto_Visible ;
      private int edtavDistribuidordescripcionvar_Visible ;
      private int AV61PageToGo ;
      private int AV267GXV1 ;
      private int AV272GXV2 ;
      private int AV244UsuariosListaID ;
      private int AV274GXV3 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV62GridCurrentPage ;
      private long AV63GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string edtavUseraction2_Class ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Selectedcolumnfixedfilter ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Combo_distribuidorid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_65_idx="0001" ;
      private string edtavUseraction2_Internalname ;
      private string AV265Pgmname ;
      private string A40UsuarioRol ;
      private string AV34TFFacturaNo ;
      private string AV35TFFacturaNo_Sel ;
      private string AV72TFEstatus ;
      private string AV70Estatus ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Fixedfilters ;
      private string Ddo_grid_Format ;
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
      private string divTablesplitteddistribuidorid_Internalname ;
      private string lblTextblockcombo_distribuidorid_Internalname ;
      private string lblTextblockcombo_distribuidorid_Jsonclick ;
      private string Combo_distribuidorid_Caption ;
      private string Combo_distribuidorid_Internalname ;
      private string bttBtnuseraction99_Internalname ;
      private string bttBtnuseraction99_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string Utchartdoughnut_Internalname ;
      private string Utchartcolumnline_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
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
      private string AV83UserAction1 ;
      private string edtavUseraction1_Internalname ;
      private string edtFacturaFechaRegistro_Internalname ;
      private string edtPromocionDescripcion_Internalname ;
      private string A71FacturaNo ;
      private string edtFacturaNo_Internalname ;
      private string edtFacturaFechaFactura_Internalname ;
      private string edtavPartidaswithtags_Internalname ;
      private string AV86Partidas ;
      private string edtavPartidas_Internalname ;
      private string AV80UserAction2 ;
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
      private string edtavDistribuidordescripcionvar_Internalname ;
      private string lV34TFFacturaNo ;
      private string AV77UsuarioRol ;
      private string edtavUseraction4_gximage ;
      private string edtavUseraction4_Tooltiptext ;
      private string GXEncryptionTmp ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string sGXsfl_65_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtFacturaID_Jsonclick ;
      private string sImgUrl ;
      private string edtavUseraction4_Jsonclick ;
      private string edtavUseraction1_Jsonclick ;
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
      private DateTime AV124FromDate ;
      private DateTime AV125ToDate ;
      private DateTime AV41TFFacturaFechaRegistro ;
      private DateTime AV42TFFacturaFechaRegistro_To ;
      private DateTime AV36TFFacturaFechaFactura ;
      private DateTime AV37TFFacturaFechaFactura_To ;
      private DateTime AV249DDO_FacturaFechaRegistroAuxDateTo ;
      private DateTime AV251DDO_FacturaFechaFacturaAuxDateTo ;
      private DateTime AV248DDO_FacturaFechaRegistroAuxDate ;
      private DateTime AV250DDO_FacturaFechaFacturaAuxDate ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A73FacturaFechaFactura ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_65_Refreshing=false ;
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
      private bool AV197Pasa ;
      private bool AV79UserAction4_IsBlob ;
      private string AV74UsuarioJSON ;
      private string AV16ColumnsSelectorXML ;
      private string AV22ManageFiltersXml ;
      private string AV17UserCustomValue ;
      private string AV15FilterFullText ;
      private string AV28TFPromocionDescripcion ;
      private string AV29TFPromocionDescripcion_Sel ;
      private string AV48TFUsuarioNombreCompleto ;
      private string AV49TFUsuarioNombreCompleto_Sel ;
      private string A11DistribuidorDescripcion ;
      private string AV262UsuarioCorreo ;
      private string AV64GridAppliedFilters ;
      private string AV45DDO_FacturaFechaRegistroAuxDateText ;
      private string AV40DDO_FacturaFechaFacturaAuxDateText ;
      private string AV266Useraction4_GXI ;
      private string A42PromocionDescripcion ;
      private string AV87PartidasWithTags ;
      private string AV71EstatusWithTags ;
      private string AV81Descripcion ;
      private string A52UsuarioNombreCompleto ;
      private string A20MotivoRechazoDescripcion ;
      private string AV97DistribuidorDescripcionVar ;
      private string lV15FilterFullText ;
      private string lV28TFPromocionDescripcion ;
      private string lV48TFUsuarioNombreCompleto ;
      private string AV84FileURL ;
      private string A40000FacturaPDF_GXI ;
      private string AV79UserAction4 ;
      private string A75FacturaPDF ;
      private string AV85Blob ;
      private IGxSession AV76WebSession ;
      private IGxSession AV20Session ;
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
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTffacturafecharegistro_rangepicker ;
      private GXUserControl ucTffacturafechafactura_rangepicker ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbFacturaEstatus ;
      private GXCheckbox chkMotivoRechazoActivo ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV18ColumnsSelector ;
      private GxSimpleCollection<int> AV126DistribuidorID ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV60DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV137DistribuidorID_Data ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV252Elements ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter> AV253Parameters ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData AV254ItemClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData AV255ItemDoubleClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData AV256DragAndDropData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData AV257FilterChangedData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData AV258ItemExpandData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData AV259ItemCollapseData ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV21ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV10GridState ;
      private GxSimpleCollection<int> AV184ListaUsuarios ;
      private IDataStoreProvider pr_default ;
      private int[] H002Z2_A41PromocionID ;
      private bool[] H002Z2_A93FacturaCompleta ;
      private int[] H002Z2_A19MotivoRechazoID ;
      private string[] H002Z2_A20MotivoRechazoDescripcion ;
      private bool[] H002Z2_A21MotivoRechazoActivo ;
      private int[] H002Z2_A29UsuarioID ;
      private string[] H002Z2_A80FacturaEstatus ;
      private DateTime[] H002Z2_A73FacturaFechaFactura ;
      private string[] H002Z2_A71FacturaNo ;
      private string[] H002Z2_A42PromocionDescripcion ;
      private DateTime[] H002Z2_A72FacturaFechaRegistro ;
      private int[] H002Z2_A69FacturaID ;
      private string[] H002Z2_A51UsuarioApellido ;
      private string[] H002Z2_A30UsuarioNombre ;
      private long[] H002Z3_AGRID_nRecordCount ;
      private SdtSDTUsuario AV75SDTUsuario ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV19ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private int[] H002Z4_A10DistribuidorID ;
      private string[] H002Z4_A11DistribuidorDescripcion ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV138Combo_DataItem ;
      private int[] H002Z5_A10DistribuidorID ;
      private int[] H002Z5_A29UsuarioID ;
      private string[] H002Z5_A11DistribuidorDescripcion ;
      private int[] H002Z5_A81DistribuidoresUsuarioID ;
      private int[] H002Z6_A69FacturaID ;
      private string[] H002Z6_A40000FacturaPDF_GXI ;
      private string[] H002Z6_A75FacturaPDF ;
      private int[] H002Z7_A81DistribuidoresUsuarioID ;
      private string[] H002Z7_A40UsuarioRol ;
      private int[] H002Z7_A29UsuarioID ;
      private int[] H002Z8_A81DistribuidoresUsuarioID ;
      private string[] H002Z8_A40UsuarioRol ;
      private int[] H002Z8_A10DistribuidorID ;
      private int[] H002Z8_A29UsuarioID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpfacturas__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002Z2( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV184ListaUsuarios ,
                                             string AV15FilterFullText ,
                                             int AV263TFFacturaID ,
                                             int AV264TFFacturaID_To ,
                                             DateTime AV41TFFacturaFechaRegistro ,
                                             DateTime AV42TFFacturaFechaRegistro_To ,
                                             string AV29TFPromocionDescripcion_Sel ,
                                             string AV28TFPromocionDescripcion ,
                                             string AV35TFFacturaNo_Sel ,
                                             string AV34TFFacturaNo ,
                                             DateTime AV36TFFacturaFechaFactura ,
                                             DateTime AV37TFFacturaFechaFactura_To ,
                                             short AV73TFEstatusOperator ,
                                             string AV49TFUsuarioNombreCompleto_Sel ,
                                             string AV48TFUsuarioNombreCompleto ,
                                             DateTime AV124FromDate ,
                                             DateTime AV125ToDate ,
                                             int AV184ListaUsuarios_Count ,
                                             int A69FacturaID ,
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
         short[] GXv_int6 = new short[20];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.`PromocionID`, T1.`FacturaCompleta`, T1.`MotivoRechazoID`, T3.`MotivoRechazoDescripcion`, T3.`MotivoRechazoActivo`, T1.`UsuarioID`, T1.`FacturaEstatus`, T1.`FacturaFechaFactura`, T1.`FacturaNo`, T2.`PromocionDescripcion`, T1.`FacturaFechaRegistro`, T1.`FacturaID`, T4.`UsuarioApellido`, T4.`UsuarioNombre`";
         sFromString = " FROM (((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `MotivoRechazo` T3 ON T3.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)) )
         {
            AddWhere(sWhereString, "(( (LPAD(REPLACE(FORMAT(T1.`FacturaID`,0), ',', ''), 9, ' ')) like CONCAT('%', @lV15FilterFullText)) or ( T2.`PromocionDescripcion` like CONCAT('%', @lV15FilterFullText)) or ( T1.`FacturaNo` like CONCAT('%', @lV15FilterFullText)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like CONCAT('%', @lV15FilterFullText)))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV263TFFacturaID) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` >= @AV263TFFacturaID)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! (0==AV264TFFacturaID_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` <= @AV264TFFacturaID_To)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV41TFFacturaFechaRegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV41TFFacturaFechaRegistro)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV42TFFacturaFechaRegistro_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV42TFFacturaFechaRegistro_To)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29TFPromocionDescripcion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFPromocionDescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV28TFPromocionDescripcion)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFPromocionDescripcion_Sel)) && ! ( StringUtil.StrCmp(AV29TFPromocionDescripcion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV29TFPromocionDescripcion_Sel)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( StringUtil.StrCmp(AV29TFPromocionDescripcion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFFacturaNo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFFacturaNo)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV34TFFacturaNo)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFFacturaNo_Sel)) && ! ( StringUtil.StrCmp(AV35TFFacturaNo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV35TFFacturaNo_Sel)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( StringUtil.StrCmp(AV35TFFacturaNo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV36TFFacturaFechaFactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV36TFFacturaFechaFactura)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV37TFFacturaFechaFactura_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV37TFFacturaFechaFactura_To)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( AV73TFEstatusOperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV73TFEstatusOperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV73TFEstatusOperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV73TFEstatusOperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFUsuarioNombreCompleto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFUsuarioNombreCompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like @lV48TFUsuarioNombreCompleto)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFUsuarioNombreCompleto_Sel)) && ! ( StringUtil.StrCmp(AV49TFUsuarioNombreCompleto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) = @AV49TFUsuarioNombreCompleto_Sel)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( StringUtil.StrCmp(AV49TFUsuarioNombreCompleto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T4.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T4.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV124FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV124FromDate)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV125ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV125ToDate)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( AV184ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV184ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
         }
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`FacturaID`";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`FacturaID` DESC";
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
            sOrderString += " ORDER BY T1.`FacturaNo`";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`FacturaNo` DESC";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`FacturaFechaFactura`";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
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

      protected Object[] conditional_H002Z3( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV184ListaUsuarios ,
                                             string AV15FilterFullText ,
                                             int AV263TFFacturaID ,
                                             int AV264TFFacturaID_To ,
                                             DateTime AV41TFFacturaFechaRegistro ,
                                             DateTime AV42TFFacturaFechaRegistro_To ,
                                             string AV29TFPromocionDescripcion_Sel ,
                                             string AV28TFPromocionDescripcion ,
                                             string AV35TFFacturaNo_Sel ,
                                             string AV34TFFacturaNo ,
                                             DateTime AV36TFFacturaFechaFactura ,
                                             DateTime AV37TFFacturaFechaFactura_To ,
                                             short AV73TFEstatusOperator ,
                                             string AV49TFUsuarioNombreCompleto_Sel ,
                                             string AV48TFUsuarioNombreCompleto ,
                                             DateTime AV124FromDate ,
                                             DateTime AV125ToDate ,
                                             int AV184ListaUsuarios_Count ,
                                             int A69FacturaID ,
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
         short[] GXv_int8 = new short[18];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `MotivoRechazo` T3 ON T3.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)) )
         {
            AddWhere(sWhereString, "(( (LPAD(REPLACE(FORMAT(T1.`FacturaID`,0), ',', ''), 9, ' ')) like CONCAT('%', @lV15FilterFullText)) or ( T2.`PromocionDescripcion` like CONCAT('%', @lV15FilterFullText)) or ( T1.`FacturaNo` like CONCAT('%', @lV15FilterFullText)) or ( CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like CONCAT('%', @lV15FilterFullText)))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
         }
         if ( ! (0==AV263TFFacturaID) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` >= @AV263TFFacturaID)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! (0==AV264TFFacturaID_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaID` <= @AV264TFFacturaID_To)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV41TFFacturaFechaRegistro) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` >= @AV41TFFacturaFechaRegistro)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV42TFFacturaFechaRegistro_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaRegistro` <= @AV42TFFacturaFechaRegistro_To)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29TFPromocionDescripcion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFPromocionDescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` like @lV28TFPromocionDescripcion)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFPromocionDescripcion_Sel)) && ! ( StringUtil.StrCmp(AV29TFPromocionDescripcion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`PromocionDescripcion` = @AV29TFPromocionDescripcion_Sel)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( StringUtil.StrCmp(AV29TFPromocionDescripcion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFFacturaNo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFFacturaNo)) ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` like @lV34TFFacturaNo)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFFacturaNo_Sel)) && ! ( StringUtil.StrCmp(AV35TFFacturaNo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV35TFFacturaNo_Sel)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( StringUtil.StrCmp(AV35TFFacturaNo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`FacturaNo`))=0))");
         }
         if ( ! (DateTime.MinValue==AV36TFFacturaFechaFactura) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV36TFFacturaFechaFactura)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV37TFFacturaFechaFactura_To) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV37TFFacturaFechaFactura_To)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV73TFEstatusOperator == 1 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'En Proceso')");
         }
         if ( AV73TFEstatusOperator == 2 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Aprobada')");
         }
         if ( AV73TFEstatusOperator == 3 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Rechazada')");
         }
         if ( AV73TFEstatusOperator == 4 )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = 'Cancelada')");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFUsuarioNombreCompleto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFUsuarioNombreCompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) like @lV48TFUsuarioNombreCompleto)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFUsuarioNombreCompleto_Sel)) && ! ( StringUtil.StrCmp(AV49TFUsuarioNombreCompleto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T4.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T4.`UsuarioApellido`))) = @AV49TFUsuarioNombreCompleto_Sel)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( StringUtil.StrCmp(AV49TFUsuarioNombreCompleto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T4.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T4.`UsuarioApellido`))))=0))");
         }
         if ( ! (DateTime.MinValue==AV124FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV124FromDate)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV125ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV125ToDate)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( AV184ListaUsuarios_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV184ListaUsuarios, "T1.`UsuarioID` IN (", ")")+")");
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
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
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

      protected Object[] conditional_H002Z8( IGxContext context ,
                                             int A10DistribuidorID ,
                                             GxSimpleCollection<int> AV126DistribuidorID ,
                                             string A40UsuarioRol )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.`DistribuidoresUsuarioID`, T2.`UsuarioRol`, T1.`DistribuidorID`, T1.`UsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV126DistribuidorID, "T1.`DistribuidorID` IN (", ")")+")");
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
                     return conditional_H002Z2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (bool)dynConstraints[29] );
               case 1 :
                     return conditional_H002Z3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (bool)dynConstraints[29] );
               case 6 :
                     return conditional_H002Z8(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] );
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
          Object[] prmH002Z4;
          prmH002Z4 = new Object[] {
          };
          Object[] prmH002Z5;
          prmH002Z5 = new Object[] {
          new ParDef("@AV91RegUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH002Z6;
          prmH002Z6 = new Object[] {
          new ParDef("@AV123FacturaID",GXType.Int32,9,0)
          };
          Object[] prmH002Z7;
          prmH002Z7 = new Object[] {
          };
          Object[] prmH002Z2;
          prmH002Z2 = new Object[] {
          new ParDef("@lV15FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.Char,100,0) ,
          new ParDef("@AV263TFFacturaID",GXType.Int32,9,0) ,
          new ParDef("@AV264TFFacturaID_To",GXType.Int32,9,0) ,
          new ParDef("@AV41TFFacturaFechaRegistro",GXType.Date,8,0) ,
          new ParDef("@AV42TFFacturaFechaRegistro_To",GXType.Date,8,0) ,
          new ParDef("@lV28TFPromocionDescripcion",GXType.Char,80,0) ,
          new ParDef("@AV29TFPromocionDescripcion_Sel",GXType.Char,80,0) ,
          new ParDef("@lV34TFFacturaNo",GXType.Char,20,0) ,
          new ParDef("@AV35TFFacturaNo_Sel",GXType.Char,20,0) ,
          new ParDef("@AV36TFFacturaFechaFactura",GXType.Date,8,0) ,
          new ParDef("@AV37TFFacturaFechaFactura_To",GXType.Date,8,0) ,
          new ParDef("@lV48TFUsuarioNombreCompleto",GXType.Char,40,0) ,
          new ParDef("@AV49TFUsuarioNombreCompleto_Sel",GXType.Char,40,0) ,
          new ParDef("@AV124FromDate",GXType.Date,8,0) ,
          new ParDef("@AV125ToDate",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002Z3;
          prmH002Z3 = new Object[] {
          new ParDef("@lV15FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.Char,100,0) ,
          new ParDef("@lV15FilterFullText",GXType.Char,100,0) ,
          new ParDef("@AV263TFFacturaID",GXType.Int32,9,0) ,
          new ParDef("@AV264TFFacturaID_To",GXType.Int32,9,0) ,
          new ParDef("@AV41TFFacturaFechaRegistro",GXType.Date,8,0) ,
          new ParDef("@AV42TFFacturaFechaRegistro_To",GXType.Date,8,0) ,
          new ParDef("@lV28TFPromocionDescripcion",GXType.Char,80,0) ,
          new ParDef("@AV29TFPromocionDescripcion_Sel",GXType.Char,80,0) ,
          new ParDef("@lV34TFFacturaNo",GXType.Char,20,0) ,
          new ParDef("@AV35TFFacturaNo_Sel",GXType.Char,20,0) ,
          new ParDef("@AV36TFFacturaFechaFactura",GXType.Date,8,0) ,
          new ParDef("@AV37TFFacturaFechaFactura_To",GXType.Date,8,0) ,
          new ParDef("@lV48TFUsuarioNombreCompleto",GXType.Char,40,0) ,
          new ParDef("@AV49TFUsuarioNombreCompleto_Sel",GXType.Char,40,0) ,
          new ParDef("@AV124FromDate",GXType.Date,8,0) ,
          new ParDef("@AV125ToDate",GXType.Date,8,0)
          };
          Object[] prmH002Z8;
          prmH002Z8 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H002Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Z2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002Z3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Z3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002Z4", "SELECT `DistribuidorID`, `DistribuidorDescripcion` FROM `Distribuidor` ORDER BY `DistribuidorDescripcion` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Z4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002Z5", "SELECT T1.`DistribuidorID`, T1.`UsuarioID`, T2.`DistribuidorDescripcion`, T1.`DistribuidoresUsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Distribuidor` T2 ON T2.`DistribuidorID` = T1.`DistribuidorID`) WHERE T1.`UsuarioID` = @AV91RegUsuarioID ORDER BY T1.`DistribuidoresUsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Z5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H002Z6", "SELECT `FacturaID`, `FacturaPDF_GXI`, `FacturaPDF` FROM `Factura` WHERE `FacturaID` = @AV123FacturaID ORDER BY `FacturaID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Z6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H002Z7", "SELECT T1.`DistribuidoresUsuarioID`, T2.`UsuarioRol`, T1.`UsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = T1.`UsuarioID`) WHERE T2.`UsuarioRol` = 'Participante' ORDER BY T1.`DistribuidoresUsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Z7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002Z8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Z8,100, GxCacheFrequency.OFF ,true,false )
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
