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
   public class wplistaparticipantes : GXDataArea
   {
      public wplistaparticipantes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wplistaparticipantes( IGxContext context )
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
         cmbUsuarioRol = new GXCombobox();
         cmbUsuarioGenero = new GXCombobox();
         cmbUsuarioDirectoAsociado = new GXCombobox();
         cmbUsuarioZona = new GXCombobox();
         cmbUsuarioProducto = new GXCombobox();
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
         nRC_GXsfl_37 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_37"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_37_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_37_idx = GetPar( "sGXsfl_37_idx");
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
         AV25OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV27OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV116ListaUsuariosAsesores);
         AV23ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV6ColumnsSelector);
         AV207Pgmname = GetPar( "Pgmname");
         AV13FilterFullText = GetPar( "FilterFullText");
         AV74TFUsuarioNombreCompleto = GetPar( "TFUsuarioNombreCompleto");
         AV75TFUsuarioNombreCompleto_Sel = GetPar( "TFUsuarioNombreCompleto_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV82TFUsuarioRol_Sels);
         AV54TFUsuarioCorreo = GetPar( "TFUsuarioCorreo");
         AV55TFUsuarioCorreo_Sel = GetPar( "TFUsuarioCorreo_Sel");
         AV42TFPuestoDescripcion = GetPar( "TFPuestoDescripcion");
         AV43TFPuestoDescripcion_Sel = GetPar( "TFPuestoDescripcion_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV64TFUsuarioGenero_Sels);
         AV50TFUsuarioCelular = (long)(Math.Round(NumberUtil.Val( GetPar( "TFUsuarioCelular"), "."), 18, MidpointRounding.ToEven));
         AV51TFUsuarioCelular_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFUsuarioCelular_To"), "."), 18, MidpointRounding.ToEven));
         AV84TFUsuarioSucursal = GetPar( "TFUsuarioSucursal");
         AV85TFUsuarioSucursal_Sel = GetPar( "TFUsuarioSucursal_Sel");
         AV155UsuarioRol = GetPar( "UsuarioRol");
         AV152UsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "UsuarioID"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV25OrderedBy, AV27OrderedDsc, AV116ListaUsuariosAsesores, AV23ManageFiltersExecutionStep, AV6ColumnsSelector, AV207Pgmname, AV13FilterFullText, AV74TFUsuarioNombreCompleto, AV75TFUsuarioNombreCompleto_Sel, AV82TFUsuarioRol_Sels, AV54TFUsuarioCorreo, AV55TFUsuarioCorreo_Sel, AV42TFPuestoDescripcion, AV43TFPuestoDescripcion_Sel, AV64TFUsuarioGenero_Sels, AV50TFUsuarioCelular, AV51TFUsuarioCelular_To, AV84TFUsuarioSucursal, AV85TFUsuarioSucursal_Sel, AV155UsuarioRol, AV152UsuarioID) ;
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
         PA3D2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3D2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wplistaparticipantes.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV207Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV207Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOROL", StringUtil.RTrim( AV155UsuarioRol));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOROL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV155UsuarioRol, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV152UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV152UsuarioID), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV27OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV22ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV22ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV15GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV9DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV9DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV6ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV6ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV207Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV207Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIONOMBRECOMPLETO", AV74TFUsuarioNombreCompleto);
         GxWebStd.gx_hidden_field( context, "vTFUSUARIONOMBRECOMPLETO_SEL", AV75TFUsuarioNombreCompleto_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFUSUARIOROL_SELS", AV82TFUsuarioRol_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFUSUARIOROL_SELS", AV82TFUsuarioRol_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOCORREO", AV54TFUsuarioCorreo);
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOCORREO_SEL", AV55TFUsuarioCorreo_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPUESTODESCRIPCION", AV42TFPuestoDescripcion);
         GxWebStd.gx_hidden_field( context, "vTFPUESTODESCRIPCION_SEL", AV43TFPuestoDescripcion_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFUSUARIOGENERO_SELS", AV64TFUsuarioGenero_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFUSUARIOGENERO_SELS", AV64TFUsuarioGenero_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOCELULAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50TFUsuarioCelular), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOCELULAR_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51TFUsuarioCelular_To), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSUCURSAL", StringUtil.RTrim( AV84TFUsuarioSucursal));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSUCURSAL_SEL", StringUtil.RTrim( AV85TFUsuarioSucursal_Sel));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV27OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vUSUARIOROL", StringUtil.RTrim( AV155UsuarioRol));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOROL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV155UsuarioRol, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV18GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV18GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOROL_SELSJSON", AV83TFUsuarioRol_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOGENERO_SELSJSON", AV65TFUsuarioGenero_SelsJson);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISTRIBUIDORIDCOL", AV178DistribuidorIDCol);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISTRIBUIDORIDCOL", AV178DistribuidorIDCol);
         }
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV152UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV152UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DISTRIBUIDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10DistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLISTAUSUARIOSASESORES", AV116ListaUsuariosAsesores);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLISTAUSUARIOSASESORES", AV116ListaUsuariosAsesores);
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
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
            WE3D2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3D2( ) ;
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
         return formatLink("wplistaparticipantes.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPListaParticipantes" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Usuario", "") ;
      }

      protected void WB3D0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainWithShadow", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColorFilledActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "Agregar", ""), bttBtnuseraction1_Jsonclick, 5, context.GetMessage( "Agregar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION1\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPListaParticipantes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WPListaParticipantes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV13FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WPListaParticipantes.htm");
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
            StartGridControl37( ) ;
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            nRC_GXsfl_37 = (int)(nGXsfl_37_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV16GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV17GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV15GridAppliedFilters);
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
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV9DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV9DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV6ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 37 )
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

      protected void START3D2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Usuario", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3D0( ) ;
      }

      protected void WS3D2( )
      {
         START3D2( ) ;
         EVT3D2( ) ;
      }

      protected void EVT3D2( )
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
                              E113D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E123D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E133D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E143D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E153D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction1' */
                              E163D2 ();
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
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              A29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A30UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
                              A51UsuarioApellido = cgiGet( edtUsuarioApellido_Internalname);
                              A52UsuarioNombreCompleto = cgiGet( edtUsuarioNombreCompleto_Internalname);
                              cmbUsuarioRol.Name = cmbUsuarioRol_Internalname;
                              cmbUsuarioRol.CurrentValue = cgiGet( cmbUsuarioRol_Internalname);
                              A40UsuarioRol = cgiGet( cmbUsuarioRol_Internalname);
                              A31UsuarioCorreo = cgiGet( edtUsuarioCorreo_Internalname);
                              A32UsuarioPass = cgiGet( edtUsuarioPass_Internalname);
                              A33UsuarioKey = cgiGet( edtUsuarioKey_Internalname);
                              A13PuestoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPuestoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n13PuestoID = false;
                              A14PuestoDescripcion = cgiGet( edtPuestoDescripcion_Internalname);
                              cmbUsuarioGenero.Name = cmbUsuarioGenero_Internalname;
                              cmbUsuarioGenero.CurrentValue = cgiGet( cmbUsuarioGenero_Internalname);
                              A53UsuarioGenero = cgiGet( cmbUsuarioGenero_Internalname);
                              cmbUsuarioDirectoAsociado.Name = cmbUsuarioDirectoAsociado_Internalname;
                              cmbUsuarioDirectoAsociado.CurrentValue = cgiGet( cmbUsuarioDirectoAsociado_Internalname);
                              A54UsuarioDirectoAsociado = cgiGet( cmbUsuarioDirectoAsociado_Internalname);
                              n54UsuarioDirectoAsociado = false;
                              A55UsuarioRazonSocialAsociado = cgiGet( edtUsuarioRazonSocialAsociado_Internalname);
                              A56UsuarioNombreComercial = cgiGet( edtUsuarioNombreComercial_Internalname);
                              A57UsuarioFechaNacimiento = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtUsuarioFechaNacimiento_Internalname), 0));
                              n57UsuarioFechaNacimiento = false;
                              A59UsuarioCalleNum = cgiGet( edtUsuarioCalleNum_Internalname);
                              A60UsuarioColonia = cgiGet( edtUsuarioColonia_Internalname);
                              A61UsuarioDelegacion = cgiGet( edtUsuarioDelegacion_Internalname);
                              A62UsuarioCP = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioCP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbUsuarioZona.Name = cmbUsuarioZona_Internalname;
                              cmbUsuarioZona.CurrentValue = cgiGet( cmbUsuarioZona_Internalname);
                              A63UsuarioZona = cgiGet( cmbUsuarioZona_Internalname);
                              A64UsuarioCelular = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioCelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A65UsuarioTelefonoSucursal = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioTelefonoSucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A16PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPaisID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A17PaisDescripcion = cgiGet( edtPaisDescripcion_Internalname);
                              A1EstadoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A2EstadoDescripcion = cgiGet( edtEstadoDescripcion_Internalname);
                              A4CiudadID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCiudadID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n4CiudadID = false;
                              A5CiudadDescripcion = cgiGet( edtCiudadDescripcion_Internalname);
                              A66UsuarioSucursal = cgiGet( edtUsuarioSucursal_Internalname);
                              AV161Pass = cgiGet( edtavPass_Internalname);
                              AssignAttri("", false, edtavPass_Internalname, AV161Pass);
                              cmbUsuarioProducto.Name = cmbUsuarioProducto_Internalname;
                              cmbUsuarioProducto.CurrentValue = cgiGet( cmbUsuarioProducto_Internalname);
                              A67UsuarioProducto = cgiGet( cmbUsuarioProducto_Internalname);
                              n67UsuarioProducto = false;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV14GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV14GridActions), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E173D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E183D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E193D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E203D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV25OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV27OrderedDsc )
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

      protected void WE3D2( )
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

      protected void PA3D2( )
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
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
         SubsflControlProps_372( ) ;
         while ( nGXsfl_37_idx <= nRC_GXsfl_37 )
         {
            sendrow_372( ) ;
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV25OrderedBy ,
                                       bool AV27OrderedDsc ,
                                       GxSimpleCollection<int> AV116ListaUsuariosAsesores ,
                                       short AV23ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV6ColumnsSelector ,
                                       string AV207Pgmname ,
                                       string AV13FilterFullText ,
                                       string AV74TFUsuarioNombreCompleto ,
                                       string AV75TFUsuarioNombreCompleto_Sel ,
                                       GxSimpleCollection<string> AV82TFUsuarioRol_Sels ,
                                       string AV54TFUsuarioCorreo ,
                                       string AV55TFUsuarioCorreo_Sel ,
                                       string AV42TFPuestoDescripcion ,
                                       string AV43TFPuestoDescripcion_Sel ,
                                       GxSimpleCollection<string> AV64TFUsuarioGenero_Sels ,
                                       long AV50TFUsuarioCelular ,
                                       long AV51TFUsuarioCelular_To ,
                                       string AV84TFUsuarioSucursal ,
                                       string AV85TFUsuarioSucursal_Sel ,
                                       string AV155UsuarioRol ,
                                       int AV152UsuarioID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3D2( ) ;
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
         RF3D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV207Pgmname = "WPListaParticipantes";
         edtavPass_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV208Wplistaparticipantesds_1_filterfulltext = AV13FilterFullText;
         AV209Wplistaparticipantesds_2_tfusuarionombrecompleto = AV74TFUsuarioNombreCompleto;
         AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel = AV75TFUsuarioNombreCompleto_Sel;
         AV211Wplistaparticipantesds_4_tfusuariorol_sels = AV82TFUsuarioRol_Sels;
         AV212Wplistaparticipantesds_5_tfusuariocorreo = AV54TFUsuarioCorreo;
         AV213Wplistaparticipantesds_6_tfusuariocorreo_sel = AV55TFUsuarioCorreo_Sel;
         AV214Wplistaparticipantesds_7_tfpuestodescripcion = AV42TFPuestoDescripcion;
         AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel = AV43TFPuestoDescripcion_Sel;
         AV216Wplistaparticipantesds_9_tfusuariogenero_sels = AV64TFUsuarioGenero_Sels;
         AV217Wplistaparticipantesds_10_tfusuariocelular = AV50TFUsuarioCelular;
         AV218Wplistaparticipantesds_11_tfusuariocelular_to = AV51TFUsuarioCelular_To;
         AV219Wplistaparticipantesds_12_tfusuariosucursal = AV84TFUsuarioSucursal;
         AV220Wplistaparticipantesds_13_tfusuariosucursal_sel = AV85TFUsuarioSucursal_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV116ListaUsuariosAsesores ,
                                              A40UsuarioRol ,
                                              AV211Wplistaparticipantesds_4_tfusuariorol_sels ,
                                              A53UsuarioGenero ,
                                              AV216Wplistaparticipantesds_9_tfusuariogenero_sels ,
                                              AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel ,
                                              AV209Wplistaparticipantesds_2_tfusuarionombrecompleto ,
                                              AV211Wplistaparticipantesds_4_tfusuariorol_sels.Count ,
                                              AV213Wplistaparticipantesds_6_tfusuariocorreo_sel ,
                                              AV212Wplistaparticipantesds_5_tfusuariocorreo ,
                                              AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel ,
                                              AV214Wplistaparticipantesds_7_tfpuestodescripcion ,
                                              AV216Wplistaparticipantesds_9_tfusuariogenero_sels.Count ,
                                              AV217Wplistaparticipantesds_10_tfusuariocelular ,
                                              AV218Wplistaparticipantesds_11_tfusuariocelular_to ,
                                              AV220Wplistaparticipantesds_13_tfusuariosucursal_sel ,
                                              AV219Wplistaparticipantesds_12_tfusuariosucursal ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A31UsuarioCorreo ,
                                              A14PuestoDescripcion ,
                                              A64UsuarioCelular ,
                                              A66UsuarioSucursal ,
                                              AV25OrderedBy ,
                                              AV27OrderedDsc ,
                                              AV208Wplistaparticipantesds_1_filterfulltext ,
                                              A52UsuarioNombreCompleto } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV209Wplistaparticipantesds_2_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV209Wplistaparticipantesds_2_tfusuarionombrecompleto), "%", "");
         lV212Wplistaparticipantesds_5_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV212Wplistaparticipantesds_5_tfusuariocorreo), "%", "");
         lV214Wplistaparticipantesds_7_tfpuestodescripcion = StringUtil.Concat( StringUtil.RTrim( AV214Wplistaparticipantesds_7_tfpuestodescripcion), "%", "");
         lV219Wplistaparticipantesds_12_tfusuariosucursal = StringUtil.PadR( StringUtil.RTrim( AV219Wplistaparticipantesds_12_tfusuariosucursal), 20, "%");
         /* Using cursor H003D2 */
         pr_default.execute(0, new Object[] {lV209Wplistaparticipantesds_2_tfusuarionombrecompleto, AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, lV212Wplistaparticipantesds_5_tfusuariocorreo, AV213Wplistaparticipantesds_6_tfusuariocorreo_sel, lV214Wplistaparticipantesds_7_tfpuestodescripcion, AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel, AV217Wplistaparticipantesds_10_tfusuariocelular, AV218Wplistaparticipantesds_11_tfusuariocelular_to, lV219Wplistaparticipantesds_12_tfusuariosucursal, AV220Wplistaparticipantesds_13_tfusuariosucursal_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A67UsuarioProducto = H003D2_A67UsuarioProducto[0];
            n67UsuarioProducto = H003D2_n67UsuarioProducto[0];
            A66UsuarioSucursal = H003D2_A66UsuarioSucursal[0];
            A5CiudadDescripcion = H003D2_A5CiudadDescripcion[0];
            A4CiudadID = H003D2_A4CiudadID[0];
            n4CiudadID = H003D2_n4CiudadID[0];
            A2EstadoDescripcion = H003D2_A2EstadoDescripcion[0];
            A1EstadoID = H003D2_A1EstadoID[0];
            A17PaisDescripcion = H003D2_A17PaisDescripcion[0];
            A16PaisID = H003D2_A16PaisID[0];
            A65UsuarioTelefonoSucursal = H003D2_A65UsuarioTelefonoSucursal[0];
            A64UsuarioCelular = H003D2_A64UsuarioCelular[0];
            A63UsuarioZona = H003D2_A63UsuarioZona[0];
            A62UsuarioCP = H003D2_A62UsuarioCP[0];
            A61UsuarioDelegacion = H003D2_A61UsuarioDelegacion[0];
            A60UsuarioColonia = H003D2_A60UsuarioColonia[0];
            A59UsuarioCalleNum = H003D2_A59UsuarioCalleNum[0];
            A57UsuarioFechaNacimiento = H003D2_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = H003D2_n57UsuarioFechaNacimiento[0];
            A56UsuarioNombreComercial = H003D2_A56UsuarioNombreComercial[0];
            A55UsuarioRazonSocialAsociado = H003D2_A55UsuarioRazonSocialAsociado[0];
            A54UsuarioDirectoAsociado = H003D2_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = H003D2_n54UsuarioDirectoAsociado[0];
            A53UsuarioGenero = H003D2_A53UsuarioGenero[0];
            A14PuestoDescripcion = H003D2_A14PuestoDescripcion[0];
            A13PuestoID = H003D2_A13PuestoID[0];
            n13PuestoID = H003D2_n13PuestoID[0];
            A33UsuarioKey = H003D2_A33UsuarioKey[0];
            A32UsuarioPass = H003D2_A32UsuarioPass[0];
            A31UsuarioCorreo = H003D2_A31UsuarioCorreo[0];
            A40UsuarioRol = H003D2_A40UsuarioRol[0];
            A52UsuarioNombreCompleto = H003D2_A52UsuarioNombreCompleto[0];
            A29UsuarioID = H003D2_A29UsuarioID[0];
            A30UsuarioNombre = H003D2_A30UsuarioNombre[0];
            A51UsuarioApellido = H003D2_A51UsuarioApellido[0];
            A5CiudadDescripcion = H003D2_A5CiudadDescripcion[0];
            A1EstadoID = H003D2_A1EstadoID[0];
            A2EstadoDescripcion = H003D2_A2EstadoDescripcion[0];
            A16PaisID = H003D2_A16PaisID[0];
            A17PaisDescripcion = H003D2_A17PaisDescripcion[0];
            A14PuestoDescripcion = H003D2_A14PuestoDescripcion[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV208Wplistaparticipantesds_1_filterfulltext)) || ( ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV208Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "gx_emptyitemtext", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
            ( StringUtil.Like( context.GetMessage( "super administrador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, "Super Administrador") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrador yokohama", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, "Administrador Yokohama") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "asesor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, "Asesor") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "participante", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A40UsuarioRol, "Participante") == 0 ) ) || ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV208Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A14PuestoDescripcion , StringUtil.PadR( "%" + AV208Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "gx_emptyitemtext", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A53UsuarioGenero)) ) ||
            ( StringUtil.Like( context.GetMessage( "masculino", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, "Masculino") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "femenino", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A53UsuarioGenero, "Femenino") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV208Wplistaparticipantesds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A66UsuarioSucursal , StringUtil.PadR( "%" + AV208Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
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

      protected void RF3D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E183D2 ();
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
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
            SubsflControlProps_372( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A29UsuarioID ,
                                                 AV116ListaUsuariosAsesores ,
                                                 A40UsuarioRol ,
                                                 AV211Wplistaparticipantesds_4_tfusuariorol_sels ,
                                                 A53UsuarioGenero ,
                                                 AV216Wplistaparticipantesds_9_tfusuariogenero_sels ,
                                                 AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel ,
                                                 AV209Wplistaparticipantesds_2_tfusuarionombrecompleto ,
                                                 AV211Wplistaparticipantesds_4_tfusuariorol_sels.Count ,
                                                 AV213Wplistaparticipantesds_6_tfusuariocorreo_sel ,
                                                 AV212Wplistaparticipantesds_5_tfusuariocorreo ,
                                                 AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel ,
                                                 AV214Wplistaparticipantesds_7_tfpuestodescripcion ,
                                                 AV216Wplistaparticipantesds_9_tfusuariogenero_sels.Count ,
                                                 AV217Wplistaparticipantesds_10_tfusuariocelular ,
                                                 AV218Wplistaparticipantesds_11_tfusuariocelular_to ,
                                                 AV220Wplistaparticipantesds_13_tfusuariosucursal_sel ,
                                                 AV219Wplistaparticipantesds_12_tfusuariosucursal ,
                                                 A30UsuarioNombre ,
                                                 A51UsuarioApellido ,
                                                 A31UsuarioCorreo ,
                                                 A14PuestoDescripcion ,
                                                 A64UsuarioCelular ,
                                                 A66UsuarioSucursal ,
                                                 AV25OrderedBy ,
                                                 AV27OrderedDsc ,
                                                 AV208Wplistaparticipantesds_1_filterfulltext ,
                                                 A52UsuarioNombreCompleto } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV209Wplistaparticipantesds_2_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV209Wplistaparticipantesds_2_tfusuarionombrecompleto), "%", "");
            lV212Wplistaparticipantesds_5_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV212Wplistaparticipantesds_5_tfusuariocorreo), "%", "");
            lV214Wplistaparticipantesds_7_tfpuestodescripcion = StringUtil.Concat( StringUtil.RTrim( AV214Wplistaparticipantesds_7_tfpuestodescripcion), "%", "");
            lV219Wplistaparticipantesds_12_tfusuariosucursal = StringUtil.PadR( StringUtil.RTrim( AV219Wplistaparticipantesds_12_tfusuariosucursal), 20, "%");
            /* Using cursor H003D3 */
            pr_default.execute(1, new Object[] {lV209Wplistaparticipantesds_2_tfusuarionombrecompleto, AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, lV212Wplistaparticipantesds_5_tfusuariocorreo, AV213Wplistaparticipantesds_6_tfusuariocorreo_sel, lV214Wplistaparticipantesds_7_tfpuestodescripcion, AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel, AV217Wplistaparticipantesds_10_tfusuariocelular, AV218Wplistaparticipantesds_11_tfusuariocelular_to, lV219Wplistaparticipantesds_12_tfusuariosucursal, AV220Wplistaparticipantesds_13_tfusuariosucursal_sel});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A67UsuarioProducto = H003D3_A67UsuarioProducto[0];
               n67UsuarioProducto = H003D3_n67UsuarioProducto[0];
               A66UsuarioSucursal = H003D3_A66UsuarioSucursal[0];
               A5CiudadDescripcion = H003D3_A5CiudadDescripcion[0];
               A4CiudadID = H003D3_A4CiudadID[0];
               n4CiudadID = H003D3_n4CiudadID[0];
               A2EstadoDescripcion = H003D3_A2EstadoDescripcion[0];
               A1EstadoID = H003D3_A1EstadoID[0];
               A17PaisDescripcion = H003D3_A17PaisDescripcion[0];
               A16PaisID = H003D3_A16PaisID[0];
               A65UsuarioTelefonoSucursal = H003D3_A65UsuarioTelefonoSucursal[0];
               A64UsuarioCelular = H003D3_A64UsuarioCelular[0];
               A63UsuarioZona = H003D3_A63UsuarioZona[0];
               A62UsuarioCP = H003D3_A62UsuarioCP[0];
               A61UsuarioDelegacion = H003D3_A61UsuarioDelegacion[0];
               A60UsuarioColonia = H003D3_A60UsuarioColonia[0];
               A59UsuarioCalleNum = H003D3_A59UsuarioCalleNum[0];
               A57UsuarioFechaNacimiento = H003D3_A57UsuarioFechaNacimiento[0];
               n57UsuarioFechaNacimiento = H003D3_n57UsuarioFechaNacimiento[0];
               A56UsuarioNombreComercial = H003D3_A56UsuarioNombreComercial[0];
               A55UsuarioRazonSocialAsociado = H003D3_A55UsuarioRazonSocialAsociado[0];
               A54UsuarioDirectoAsociado = H003D3_A54UsuarioDirectoAsociado[0];
               n54UsuarioDirectoAsociado = H003D3_n54UsuarioDirectoAsociado[0];
               A53UsuarioGenero = H003D3_A53UsuarioGenero[0];
               A14PuestoDescripcion = H003D3_A14PuestoDescripcion[0];
               A13PuestoID = H003D3_A13PuestoID[0];
               n13PuestoID = H003D3_n13PuestoID[0];
               A33UsuarioKey = H003D3_A33UsuarioKey[0];
               A32UsuarioPass = H003D3_A32UsuarioPass[0];
               A31UsuarioCorreo = H003D3_A31UsuarioCorreo[0];
               A40UsuarioRol = H003D3_A40UsuarioRol[0];
               A52UsuarioNombreCompleto = H003D3_A52UsuarioNombreCompleto[0];
               A29UsuarioID = H003D3_A29UsuarioID[0];
               A30UsuarioNombre = H003D3_A30UsuarioNombre[0];
               A51UsuarioApellido = H003D3_A51UsuarioApellido[0];
               A5CiudadDescripcion = H003D3_A5CiudadDescripcion[0];
               A1EstadoID = H003D3_A1EstadoID[0];
               A2EstadoDescripcion = H003D3_A2EstadoDescripcion[0];
               A16PaisID = H003D3_A16PaisID[0];
               A17PaisDescripcion = H003D3_A17PaisDescripcion[0];
               A14PuestoDescripcion = H003D3_A14PuestoDescripcion[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV208Wplistaparticipantesds_1_filterfulltext)) || ( ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV208Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "gx_emptyitemtext", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
               ( StringUtil.Like( context.GetMessage( "super administrador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, "Super Administrador") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "administrador yokohama", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, "Administrador Yokohama") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "asesor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, "Asesor") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "participante", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A40UsuarioRol, "Participante") == 0 ) ) || ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV208Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A14PuestoDescripcion , StringUtil.PadR( "%" + AV208Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "gx_emptyitemtext", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A53UsuarioGenero)) ) ||
               ( StringUtil.Like( context.GetMessage( "masculino", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A53UsuarioGenero, "Masculino") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "femenino", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV208Wplistaparticipantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A53UsuarioGenero, "Femenino") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV208Wplistaparticipantesds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A66UsuarioSucursal , StringUtil.PadR( "%" + AV208Wplistaparticipantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E193D2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 37;
            WB3D0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3D2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV207Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV207Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOROL", StringUtil.RTrim( AV155UsuarioRol));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOROL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV155UsuarioRol, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV152UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV152UsuarioID), "ZZZZZZZZ9"), context));
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
         AV208Wplistaparticipantesds_1_filterfulltext = AV13FilterFullText;
         AV209Wplistaparticipantesds_2_tfusuarionombrecompleto = AV74TFUsuarioNombreCompleto;
         AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel = AV75TFUsuarioNombreCompleto_Sel;
         AV211Wplistaparticipantesds_4_tfusuariorol_sels = AV82TFUsuarioRol_Sels;
         AV212Wplistaparticipantesds_5_tfusuariocorreo = AV54TFUsuarioCorreo;
         AV213Wplistaparticipantesds_6_tfusuariocorreo_sel = AV55TFUsuarioCorreo_Sel;
         AV214Wplistaparticipantesds_7_tfpuestodescripcion = AV42TFPuestoDescripcion;
         AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel = AV43TFPuestoDescripcion_Sel;
         AV216Wplistaparticipantesds_9_tfusuariogenero_sels = AV64TFUsuarioGenero_Sels;
         AV217Wplistaparticipantesds_10_tfusuariocelular = AV50TFUsuarioCelular;
         AV218Wplistaparticipantesds_11_tfusuariocelular_to = AV51TFUsuarioCelular_To;
         AV219Wplistaparticipantesds_12_tfusuariosucursal = AV84TFUsuarioSucursal;
         AV220Wplistaparticipantesds_13_tfusuariosucursal_sel = AV85TFUsuarioSucursal_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV25OrderedBy, AV27OrderedDsc, AV116ListaUsuariosAsesores, AV23ManageFiltersExecutionStep, AV6ColumnsSelector, AV207Pgmname, AV13FilterFullText, AV74TFUsuarioNombreCompleto, AV75TFUsuarioNombreCompleto_Sel, AV82TFUsuarioRol_Sels, AV54TFUsuarioCorreo, AV55TFUsuarioCorreo_Sel, AV42TFPuestoDescripcion, AV43TFPuestoDescripcion_Sel, AV64TFUsuarioGenero_Sels, AV50TFUsuarioCelular, AV51TFUsuarioCelular_To, AV84TFUsuarioSucursal, AV85TFUsuarioSucursal_Sel, AV155UsuarioRol, AV152UsuarioID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV208Wplistaparticipantesds_1_filterfulltext = AV13FilterFullText;
         AV209Wplistaparticipantesds_2_tfusuarionombrecompleto = AV74TFUsuarioNombreCompleto;
         AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel = AV75TFUsuarioNombreCompleto_Sel;
         AV211Wplistaparticipantesds_4_tfusuariorol_sels = AV82TFUsuarioRol_Sels;
         AV212Wplistaparticipantesds_5_tfusuariocorreo = AV54TFUsuarioCorreo;
         AV213Wplistaparticipantesds_6_tfusuariocorreo_sel = AV55TFUsuarioCorreo_Sel;
         AV214Wplistaparticipantesds_7_tfpuestodescripcion = AV42TFPuestoDescripcion;
         AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel = AV43TFPuestoDescripcion_Sel;
         AV216Wplistaparticipantesds_9_tfusuariogenero_sels = AV64TFUsuarioGenero_Sels;
         AV217Wplistaparticipantesds_10_tfusuariocelular = AV50TFUsuarioCelular;
         AV218Wplistaparticipantesds_11_tfusuariocelular_to = AV51TFUsuarioCelular_To;
         AV219Wplistaparticipantesds_12_tfusuariosucursal = AV84TFUsuarioSucursal;
         AV220Wplistaparticipantesds_13_tfusuariosucursal_sel = AV85TFUsuarioSucursal_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV25OrderedBy, AV27OrderedDsc, AV116ListaUsuariosAsesores, AV23ManageFiltersExecutionStep, AV6ColumnsSelector, AV207Pgmname, AV13FilterFullText, AV74TFUsuarioNombreCompleto, AV75TFUsuarioNombreCompleto_Sel, AV82TFUsuarioRol_Sels, AV54TFUsuarioCorreo, AV55TFUsuarioCorreo_Sel, AV42TFPuestoDescripcion, AV43TFPuestoDescripcion_Sel, AV64TFUsuarioGenero_Sels, AV50TFUsuarioCelular, AV51TFUsuarioCelular_To, AV84TFUsuarioSucursal, AV85TFUsuarioSucursal_Sel, AV155UsuarioRol, AV152UsuarioID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV208Wplistaparticipantesds_1_filterfulltext = AV13FilterFullText;
         AV209Wplistaparticipantesds_2_tfusuarionombrecompleto = AV74TFUsuarioNombreCompleto;
         AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel = AV75TFUsuarioNombreCompleto_Sel;
         AV211Wplistaparticipantesds_4_tfusuariorol_sels = AV82TFUsuarioRol_Sels;
         AV212Wplistaparticipantesds_5_tfusuariocorreo = AV54TFUsuarioCorreo;
         AV213Wplistaparticipantesds_6_tfusuariocorreo_sel = AV55TFUsuarioCorreo_Sel;
         AV214Wplistaparticipantesds_7_tfpuestodescripcion = AV42TFPuestoDescripcion;
         AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel = AV43TFPuestoDescripcion_Sel;
         AV216Wplistaparticipantesds_9_tfusuariogenero_sels = AV64TFUsuarioGenero_Sels;
         AV217Wplistaparticipantesds_10_tfusuariocelular = AV50TFUsuarioCelular;
         AV218Wplistaparticipantesds_11_tfusuariocelular_to = AV51TFUsuarioCelular_To;
         AV219Wplistaparticipantesds_12_tfusuariosucursal = AV84TFUsuarioSucursal;
         AV220Wplistaparticipantesds_13_tfusuariosucursal_sel = AV85TFUsuarioSucursal_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV25OrderedBy, AV27OrderedDsc, AV116ListaUsuariosAsesores, AV23ManageFiltersExecutionStep, AV6ColumnsSelector, AV207Pgmname, AV13FilterFullText, AV74TFUsuarioNombreCompleto, AV75TFUsuarioNombreCompleto_Sel, AV82TFUsuarioRol_Sels, AV54TFUsuarioCorreo, AV55TFUsuarioCorreo_Sel, AV42TFPuestoDescripcion, AV43TFPuestoDescripcion_Sel, AV64TFUsuarioGenero_Sels, AV50TFUsuarioCelular, AV51TFUsuarioCelular_To, AV84TFUsuarioSucursal, AV85TFUsuarioSucursal_Sel, AV155UsuarioRol, AV152UsuarioID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV208Wplistaparticipantesds_1_filterfulltext = AV13FilterFullText;
         AV209Wplistaparticipantesds_2_tfusuarionombrecompleto = AV74TFUsuarioNombreCompleto;
         AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel = AV75TFUsuarioNombreCompleto_Sel;
         AV211Wplistaparticipantesds_4_tfusuariorol_sels = AV82TFUsuarioRol_Sels;
         AV212Wplistaparticipantesds_5_tfusuariocorreo = AV54TFUsuarioCorreo;
         AV213Wplistaparticipantesds_6_tfusuariocorreo_sel = AV55TFUsuarioCorreo_Sel;
         AV214Wplistaparticipantesds_7_tfpuestodescripcion = AV42TFPuestoDescripcion;
         AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel = AV43TFPuestoDescripcion_Sel;
         AV216Wplistaparticipantesds_9_tfusuariogenero_sels = AV64TFUsuarioGenero_Sels;
         AV217Wplistaparticipantesds_10_tfusuariocelular = AV50TFUsuarioCelular;
         AV218Wplistaparticipantesds_11_tfusuariocelular_to = AV51TFUsuarioCelular_To;
         AV219Wplistaparticipantesds_12_tfusuariosucursal = AV84TFUsuarioSucursal;
         AV220Wplistaparticipantesds_13_tfusuariosucursal_sel = AV85TFUsuarioSucursal_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV25OrderedBy, AV27OrderedDsc, AV116ListaUsuariosAsesores, AV23ManageFiltersExecutionStep, AV6ColumnsSelector, AV207Pgmname, AV13FilterFullText, AV74TFUsuarioNombreCompleto, AV75TFUsuarioNombreCompleto_Sel, AV82TFUsuarioRol_Sels, AV54TFUsuarioCorreo, AV55TFUsuarioCorreo_Sel, AV42TFPuestoDescripcion, AV43TFPuestoDescripcion_Sel, AV64TFUsuarioGenero_Sels, AV50TFUsuarioCelular, AV51TFUsuarioCelular_To, AV84TFUsuarioSucursal, AV85TFUsuarioSucursal_Sel, AV155UsuarioRol, AV152UsuarioID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV208Wplistaparticipantesds_1_filterfulltext = AV13FilterFullText;
         AV209Wplistaparticipantesds_2_tfusuarionombrecompleto = AV74TFUsuarioNombreCompleto;
         AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel = AV75TFUsuarioNombreCompleto_Sel;
         AV211Wplistaparticipantesds_4_tfusuariorol_sels = AV82TFUsuarioRol_Sels;
         AV212Wplistaparticipantesds_5_tfusuariocorreo = AV54TFUsuarioCorreo;
         AV213Wplistaparticipantesds_6_tfusuariocorreo_sel = AV55TFUsuarioCorreo_Sel;
         AV214Wplistaparticipantesds_7_tfpuestodescripcion = AV42TFPuestoDescripcion;
         AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel = AV43TFPuestoDescripcion_Sel;
         AV216Wplistaparticipantesds_9_tfusuariogenero_sels = AV64TFUsuarioGenero_Sels;
         AV217Wplistaparticipantesds_10_tfusuariocelular = AV50TFUsuarioCelular;
         AV218Wplistaparticipantesds_11_tfusuariocelular_to = AV51TFUsuarioCelular_To;
         AV219Wplistaparticipantesds_12_tfusuariosucursal = AV84TFUsuarioSucursal;
         AV220Wplistaparticipantesds_13_tfusuariosucursal_sel = AV85TFUsuarioSucursal_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV25OrderedBy, AV27OrderedDsc, AV116ListaUsuariosAsesores, AV23ManageFiltersExecutionStep, AV6ColumnsSelector, AV207Pgmname, AV13FilterFullText, AV74TFUsuarioNombreCompleto, AV75TFUsuarioNombreCompleto_Sel, AV82TFUsuarioRol_Sels, AV54TFUsuarioCorreo, AV55TFUsuarioCorreo_Sel, AV42TFPuestoDescripcion, AV43TFPuestoDescripcion_Sel, AV64TFUsuarioGenero_Sels, AV50TFUsuarioCelular, AV51TFUsuarioCelular_To, AV84TFUsuarioSucursal, AV85TFUsuarioSucursal_Sel, AV155UsuarioRol, AV152UsuarioID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV207Pgmname = "WPListaParticipantes";
         edtavPass_Enabled = 0;
         edtUsuarioID_Enabled = 0;
         edtUsuarioNombre_Enabled = 0;
         edtUsuarioApellido_Enabled = 0;
         edtUsuarioNombreCompleto_Enabled = 0;
         cmbUsuarioRol.Enabled = 0;
         edtUsuarioCorreo_Enabled = 0;
         edtUsuarioPass_Enabled = 0;
         edtUsuarioKey_Enabled = 0;
         edtPuestoID_Enabled = 0;
         edtPuestoDescripcion_Enabled = 0;
         cmbUsuarioGenero.Enabled = 0;
         cmbUsuarioDirectoAsociado.Enabled = 0;
         edtUsuarioRazonSocialAsociado_Enabled = 0;
         edtUsuarioNombreComercial_Enabled = 0;
         edtUsuarioFechaNacimiento_Enabled = 0;
         edtUsuarioCalleNum_Enabled = 0;
         edtUsuarioColonia_Enabled = 0;
         edtUsuarioDelegacion_Enabled = 0;
         edtUsuarioCP_Enabled = 0;
         cmbUsuarioZona.Enabled = 0;
         edtUsuarioCelular_Enabled = 0;
         edtUsuarioTelefonoSucursal_Enabled = 0;
         edtPaisID_Enabled = 0;
         edtPaisDescripcion_Enabled = 0;
         edtEstadoID_Enabled = 0;
         edtEstadoDescripcion_Enabled = 0;
         edtCiudadID_Enabled = 0;
         edtCiudadDescripcion_Enabled = 0;
         edtUsuarioSucursal_Enabled = 0;
         cmbUsuarioProducto.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E173D2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV22ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV9DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV6ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV16GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV17GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV15GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
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
            /* Read variables values. */
            AV13FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV25OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV27OrderedDsc )
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
         E173D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E173D2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV153UsuarioJSON = AV158WebSession.Get(context.GetMessage( "Usuario", ""));
         AV127SDTUsuario.FromJSonString(AV153UsuarioJSON, null);
         AV152UsuarioID = AV127SDTUsuario.gxTpr_Usuarioid;
         AssignAttri("", false, "AV152UsuarioID", StringUtil.LTrimStr( (decimal)(AV152UsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV152UsuarioID), "ZZZZZZZZ9"), context));
         AV155UsuarioRol = AV127SDTUsuario.gxTpr_Usuariorol;
         AssignAttri("", false, "AV155UsuarioRol", AV155UsuarioRol);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOROL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV155UsuarioRol, "")), context));
         AV115ListaDistribuidores.Clear();
         AV116ListaUsuariosAsesores.Clear();
         /* Using cursor H003D4 */
         pr_default.execute(2, new Object[] {AV152UsuarioID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A29UsuarioID = H003D4_A29UsuarioID[0];
            A10DistribuidorID = H003D4_A10DistribuidorID[0];
            AV160YaExiste = false;
            AV204GXV1 = 1;
            while ( AV204GXV1 <= AV115ListaDistribuidores.Count )
            {
               AV105DistribuidorID = (int)(AV115ListaDistribuidores.GetNumeric(AV204GXV1));
               if ( AV105DistribuidorID == A10DistribuidorID )
               {
                  AV160YaExiste = true;
                  if (true) break;
               }
               AV204GXV1 = (int)(AV204GXV1+1);
            }
            if ( ! AV160YaExiste )
            {
               AV115ListaDistribuidores.Add(A10DistribuidorID, 0);
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A10DistribuidorID ,
                                              AV115ListaDistribuidores ,
                                              A40UsuarioRol } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         /* Using cursor H003D5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A40UsuarioRol = H003D5_A40UsuarioRol[0];
            A10DistribuidorID = H003D5_A10DistribuidorID[0];
            A29UsuarioID = H003D5_A29UsuarioID[0];
            A40UsuarioRol = H003D5_A40UsuarioRol[0];
            AV125Pasa = false;
            AV206GXV2 = 1;
            while ( AV206GXV2 <= AV116ListaUsuariosAsesores.Count )
            {
               AV156UsuariosListaID = (int)(AV116ListaUsuariosAsesores.GetNumeric(AV206GXV2));
               if ( AV156UsuariosListaID == A29UsuarioID )
               {
                  AV125Pasa = true;
                  if (true) break;
               }
               AV206GXV2 = (int)(AV206GXV2+1);
            }
            if ( ! AV125Pasa )
            {
               AV116ListaUsuariosAsesores.Add(A29UsuarioID, 0);
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV20HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( "Participantes asignados", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
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
         if ( AV25OrderedBy < 1 )
         {
            AV25OrderedBy = 1;
            AssignAttri("", false, "AV25OrderedBy", StringUtil.LTrimStr( (decimal)(AV25OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV9DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV9DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E183D2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV93WWPContext) ;
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
         if ( StringUtil.StrCmp(AV29Session.Get("WPListaParticipantesColumnsSelector"), "") != 0 )
         {
            AV8ColumnsSelectorXML = AV29Session.Get("WPListaParticipantesColumnsSelector");
            AV6ColumnsSelector.FromXml(AV8ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtUsuarioNombreCompleto_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtUsuarioNombreCompleto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombreCompleto_Visible), 5, 0), !bGXsfl_37_Refreshing);
         cmbUsuarioRol.Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbUsuarioRol_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbUsuarioRol.Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtUsuarioCorreo_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtUsuarioCorreo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioCorreo_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtPuestoDescripcion_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPuestoDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPuestoDescripcion_Visible), 5, 0), !bGXsfl_37_Refreshing);
         cmbUsuarioGenero.Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbUsuarioGenero_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbUsuarioGenero.Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtUsuarioCelular_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtUsuarioCelular_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioCelular_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtUsuarioSucursal_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtUsuarioSucursal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSucursal_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavPass_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavPass_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPass_Visible), 5, 0), !bGXsfl_37_Refreshing);
         AV16GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV16GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV16GridCurrentPage), 10, 0));
         AV17GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV17GridPageCount", StringUtil.LTrimStr( (decimal)(AV17GridPageCount), 10, 0));
         GXt_char2 = AV15GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV207Pgmname, out  GXt_char2) ;
         AV15GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV15GridAppliedFilters", AV15GridAppliedFilters);
         AV208Wplistaparticipantesds_1_filterfulltext = AV13FilterFullText;
         AV209Wplistaparticipantesds_2_tfusuarionombrecompleto = AV74TFUsuarioNombreCompleto;
         AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel = AV75TFUsuarioNombreCompleto_Sel;
         AV211Wplistaparticipantesds_4_tfusuariorol_sels = AV82TFUsuarioRol_Sels;
         AV212Wplistaparticipantesds_5_tfusuariocorreo = AV54TFUsuarioCorreo;
         AV213Wplistaparticipantesds_6_tfusuariocorreo_sel = AV55TFUsuarioCorreo_Sel;
         AV214Wplistaparticipantesds_7_tfpuestodescripcion = AV42TFPuestoDescripcion;
         AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel = AV43TFPuestoDescripcion_Sel;
         AV216Wplistaparticipantesds_9_tfusuariogenero_sels = AV64TFUsuarioGenero_Sels;
         AV217Wplistaparticipantesds_10_tfusuariocelular = AV50TFUsuarioCelular;
         AV218Wplistaparticipantesds_11_tfusuariocelular_to = AV51TFUsuarioCelular_To;
         AV219Wplistaparticipantesds_12_tfusuariosucursal = AV84TFUsuarioSucursal;
         AV220Wplistaparticipantesds_13_tfusuariosucursal_sel = AV85TFUsuarioSucursal_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6ColumnsSelector", AV6ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18GridState", AV18GridState);
      }

      protected void E123D2( )
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
            AV28PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV28PageToGo) ;
         }
      }

      protected void E133D2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E143D2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV25OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25OrderedBy", StringUtil.LTrimStr( (decimal)(AV25OrderedBy), 4, 0));
            AV27OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV27OrderedDsc", AV27OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioNombreCompleto") == 0 )
            {
               AV74TFUsuarioNombreCompleto = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV74TFUsuarioNombreCompleto", AV74TFUsuarioNombreCompleto);
               AV75TFUsuarioNombreCompleto_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV75TFUsuarioNombreCompleto_Sel", AV75TFUsuarioNombreCompleto_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioRol") == 0 )
            {
               AV83TFUsuarioRol_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV83TFUsuarioRol_SelsJson", AV83TFUsuarioRol_SelsJson);
               AV82TFUsuarioRol_Sels.FromJSonString(AV83TFUsuarioRol_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioCorreo") == 0 )
            {
               AV54TFUsuarioCorreo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV54TFUsuarioCorreo", AV54TFUsuarioCorreo);
               AV55TFUsuarioCorreo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV55TFUsuarioCorreo_Sel", AV55TFUsuarioCorreo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PuestoDescripcion") == 0 )
            {
               AV42TFPuestoDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV42TFPuestoDescripcion", AV42TFPuestoDescripcion);
               AV43TFPuestoDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV43TFPuestoDescripcion_Sel", AV43TFPuestoDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioGenero") == 0 )
            {
               AV65TFUsuarioGenero_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV65TFUsuarioGenero_SelsJson", AV65TFUsuarioGenero_SelsJson);
               AV64TFUsuarioGenero_Sels.FromJSonString(AV65TFUsuarioGenero_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioCelular") == 0 )
            {
               AV50TFUsuarioCelular = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50TFUsuarioCelular", StringUtil.LTrimStr( (decimal)(AV50TFUsuarioCelular), 10, 0));
               AV51TFUsuarioCelular_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV51TFUsuarioCelular_To", StringUtil.LTrimStr( (decimal)(AV51TFUsuarioCelular_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioSucursal") == 0 )
            {
               AV84TFUsuarioSucursal = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV84TFUsuarioSucursal", AV84TFUsuarioSucursal);
               AV85TFUsuarioSucursal_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV85TFUsuarioSucursal_Sel", AV85TFUsuarioSucursal_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV64TFUsuarioGenero_Sels", AV64TFUsuarioGenero_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV82TFUsuarioRol_Sels", AV82TFUsuarioRol_Sels);
      }

      private void E193D2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV162PuedeVer = false;
            new puedeverpassword(context ).execute(  AV155UsuarioRol,  A40UsuarioRol, out  AV162PuedeVer) ;
            if ( AV162PuedeVer )
            {
               AV161Pass = Decrypt64( A32UsuarioPass, A33UsuarioKey);
               AssignAttri("", false, edtavPass_Internalname, AV161Pass);
            }
            else
            {
               AV161Pass = "*******";
               AssignAttri("", false, edtavPass_Internalname, AV161Pass);
            }
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Detalle", ""), "fas fa-magnifying-glass", "", "", "", "", "", "", ""), 0);
            cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Modificar", ""), "fas fa-pencil", "", "", "", "", "", "", ""), 0);
            cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "Eliminar", ""), "fas fa-xmark", "", "", "", "", "", "", ""), 0);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 37;
            }
            sendrow_372( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
         {
            DoAjaxLoad(37, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14GridActions), 4, 0));
      }

      protected void E153D2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV8ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV6ColumnsSelector.FromJSonString(AV8ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WPListaParticipantesColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV8ColumnsSelectorXML)) ? "" : AV6ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6ColumnsSelector", AV6ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18GridState", AV18GridState);
      }

      protected void E113D2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S172 ();
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
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WPListaParticipantesFilters")) + "," + UrlEncode(StringUtil.RTrim(AV207Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WPListaParticipantesFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV23ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV24ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WPListaParticipantesFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV24ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV207Pgmname+"GridState",  AV24ManageFiltersXml) ;
               AV18GridState.FromXml(AV24ManageFiltersXml, null, "", "");
               AV25OrderedBy = AV18GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV25OrderedBy", StringUtil.LTrimStr( (decimal)(AV25OrderedBy), 4, 0));
               AV27OrderedDsc = AV18GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV27OrderedDsc", AV27OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18GridState", AV18GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV82TFUsuarioRol_Sels", AV82TFUsuarioRol_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV64TFUsuarioGenero_Sels", AV64TFUsuarioGenero_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6ColumnsSelector", AV6ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
      }

      protected void E203D2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV14GridActions == 1 )
         {
            /* Execute user subroutine: 'DO USERACTION4' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV14GridActions == 2 )
         {
            /* Execute user subroutine: 'DO USERACTION2' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV14GridActions == 3 )
         {
            /* Execute user subroutine: 'DO USERACTION3' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV14GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV14GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6ColumnsSelector", AV6ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18GridState", AV18GridState);
      }

      protected void E163D2( )
      {
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADCOMBODISTRIBUIDORID' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV202Cuenta = (short)(AV178DistribuidorIDCol.Count);
         if ( AV202Cuenta > 0 )
         {
            context.PopUp(formatLink("testagregarparticipante.aspx") , new Object[] {});
            context.DoAjaxRefresh();
         }
         else
         {
            context.PopUp(formatLink("wpavisodistr.aspx") , new Object[] {});
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV178DistribuidorIDCol", AV178DistribuidorIDCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6ColumnsSelector", AV6ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ManageFiltersData", AV22ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18GridState", AV18GridState);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV25OrderedBy), 4, 0))+":"+(AV27OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S162( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV6ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "UsuarioNombreCompleto",  "",  "Nombre completo",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "UsuarioRol",  "",  "Rol",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "UsuarioCorreo",  "",  "Correo",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "PuestoDescripcion",  "",  "Puesto",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "UsuarioGenero",  "",  "Género",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "UsuarioCelular",  "",  "Celular",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "UsuarioSucursal",  "",  "Sucursal",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "&Pass",  "",  "Contraseña",  true,  "") ;
         GXt_char2 = AV92UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WPListaParticipantesColumnsSelector", out  GXt_char2) ;
         AV92UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV92UserCustomValue)) ) )
         {
            AV7ColumnsSelectorAux.FromXml(AV92UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV7ColumnsSelectorAux, ref  AV6ColumnsSelector) ;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV22ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WPListaParticipantesFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV22ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV13FilterFullText = "";
         AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
         AV74TFUsuarioNombreCompleto = "";
         AssignAttri("", false, "AV74TFUsuarioNombreCompleto", AV74TFUsuarioNombreCompleto);
         AV75TFUsuarioNombreCompleto_Sel = "";
         AssignAttri("", false, "AV75TFUsuarioNombreCompleto_Sel", AV75TFUsuarioNombreCompleto_Sel);
         AV82TFUsuarioRol_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV54TFUsuarioCorreo = "";
         AssignAttri("", false, "AV54TFUsuarioCorreo", AV54TFUsuarioCorreo);
         AV55TFUsuarioCorreo_Sel = "";
         AssignAttri("", false, "AV55TFUsuarioCorreo_Sel", AV55TFUsuarioCorreo_Sel);
         AV42TFPuestoDescripcion = "";
         AssignAttri("", false, "AV42TFPuestoDescripcion", AV42TFPuestoDescripcion);
         AV43TFPuestoDescripcion_Sel = "";
         AssignAttri("", false, "AV43TFPuestoDescripcion_Sel", AV43TFPuestoDescripcion_Sel);
         AV64TFUsuarioGenero_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV50TFUsuarioCelular = 0;
         AssignAttri("", false, "AV50TFUsuarioCelular", StringUtil.LTrimStr( (decimal)(AV50TFUsuarioCelular), 10, 0));
         AV51TFUsuarioCelular_To = 0;
         AssignAttri("", false, "AV51TFUsuarioCelular_To", StringUtil.LTrimStr( (decimal)(AV51TFUsuarioCelular_To), 10, 0));
         AV84TFUsuarioSucursal = "";
         AssignAttri("", false, "AV84TFUsuarioSucursal", AV84TFUsuarioSucursal);
         AV85TFUsuarioSucursal_Sel = "";
         AssignAttri("", false, "AV85TFUsuarioSucursal_Sel", AV85TFUsuarioSucursal_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S192( )
      {
         /* 'DO USERACTION4' Routine */
         returnInSub = false;
         AV162PuedeVer = false;
         new puedeverpassword(context ).execute(  AV155UsuarioRol,  A40UsuarioRol, out  AV162PuedeVer) ;
         if ( AV162PuedeVer )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpusuariodetalle.aspx"+UrlEncode(StringUtil.LTrimStr(A29UsuarioID,9,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            CallWebObject(formatLink("wpusuariodetalle.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "No tienes permiso para realizar esta acción", ""));
         }
      }

      protected void S202( )
      {
         /* 'DO USERACTION2' Routine */
         returnInSub = false;
         AV162PuedeVer = false;
         new puedeverpassword(context ).execute(  AV155UsuarioRol,  A40UsuarioRol, out  AV162PuedeVer) ;
         if ( AV162PuedeVer )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpagregarusuario.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A29UsuarioID,9,0));
            context.PopUp(formatLink("wpagregarusuario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            context.DoAjaxRefresh();
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "No tienes permiso para realizar esta acción", ""));
         }
      }

      protected void S212( )
      {
         /* 'DO USERACTION3' Routine */
         returnInSub = false;
         AV162PuedeVer = false;
         new puedeverpassword(context ).execute(  AV155UsuarioRol,  A40UsuarioRol, out  AV162PuedeVer) ;
         if ( AV162PuedeVer )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpagregarusuario.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A29UsuarioID,9,0));
            context.PopUp(formatLink("wpagregarusuario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            context.DoAjaxRefresh();
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "No tienes permiso para realizar esta acción", ""));
         }
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get(AV207Pgmname+"GridState"), "") == 0 )
         {
            AV18GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV207Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV18GridState.FromXml(AV29Session.Get(AV207Pgmname+"GridState"), null, "", "");
         }
         AV25OrderedBy = AV18GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV25OrderedBy", StringUtil.LTrimStr( (decimal)(AV25OrderedBy), 4, 0));
         AV27OrderedDsc = AV18GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV27OrderedDsc", AV27OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV18GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV18GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV18GridState.gxTpr_Currentpage) ;
      }

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV221GXV3 = 1;
         while ( AV221GXV3 <= AV18GridState.gxTpr_Filtervalues.Count )
         {
            AV19GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV18GridState.gxTpr_Filtervalues.Item(AV221GXV3));
            if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO") == 0 )
            {
               AV74TFUsuarioNombreCompleto = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV74TFUsuarioNombreCompleto", AV74TFUsuarioNombreCompleto);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO_SEL") == 0 )
            {
               AV75TFUsuarioNombreCompleto_Sel = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV75TFUsuarioNombreCompleto_Sel", AV75TFUsuarioNombreCompleto_Sel);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFUSUARIOROL_SEL") == 0 )
            {
               AV83TFUsuarioRol_SelsJson = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV83TFUsuarioRol_SelsJson", AV83TFUsuarioRol_SelsJson);
               AV82TFUsuarioRol_Sels.FromJSonString(AV83TFUsuarioRol_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFUSUARIOCORREO") == 0 )
            {
               AV54TFUsuarioCorreo = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFUsuarioCorreo", AV54TFUsuarioCorreo);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFUSUARIOCORREO_SEL") == 0 )
            {
               AV55TFUsuarioCorreo_Sel = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFUsuarioCorreo_Sel", AV55TFUsuarioCorreo_Sel);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFPUESTODESCRIPCION") == 0 )
            {
               AV42TFPuestoDescripcion = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFPuestoDescripcion", AV42TFPuestoDescripcion);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFPUESTODESCRIPCION_SEL") == 0 )
            {
               AV43TFPuestoDescripcion_Sel = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFPuestoDescripcion_Sel", AV43TFPuestoDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFUSUARIOGENERO_SEL") == 0 )
            {
               AV65TFUsuarioGenero_SelsJson = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV65TFUsuarioGenero_SelsJson", AV65TFUsuarioGenero_SelsJson);
               AV64TFUsuarioGenero_Sels.FromJSonString(AV65TFUsuarioGenero_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFUSUARIOCELULAR") == 0 )
            {
               AV50TFUsuarioCelular = (long)(Math.Round(NumberUtil.Val( AV19GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50TFUsuarioCelular", StringUtil.LTrimStr( (decimal)(AV50TFUsuarioCelular), 10, 0));
               AV51TFUsuarioCelular_To = (long)(Math.Round(NumberUtil.Val( AV19GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV51TFUsuarioCelular_To", StringUtil.LTrimStr( (decimal)(AV51TFUsuarioCelular_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFUSUARIOSUCURSAL") == 0 )
            {
               AV84TFUsuarioSucursal = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV84TFUsuarioSucursal", AV84TFUsuarioSucursal);
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFUSUARIOSUCURSAL_SEL") == 0 )
            {
               AV85TFUsuarioSucursal_Sel = AV19GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV85TFUsuarioSucursal_Sel", AV85TFUsuarioSucursal_Sel);
            }
            AV221GXV3 = (int)(AV221GXV3+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV75TFUsuarioNombreCompleto_Sel)),  AV75TFUsuarioNombreCompleto_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  (AV82TFUsuarioRol_Sels.Count==0),  AV83TFUsuarioRol_SelsJson, out  GXt_char4) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFUsuarioCorreo_Sel)),  AV55TFUsuarioCorreo_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFPuestoDescripcion_Sel)),  AV43TFPuestoDescripcion_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  (AV64TFUsuarioGenero_Sels.Count==0),  AV65TFUsuarioGenero_SelsJson, out  GXt_char7) ;
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV85TFUsuarioSucursal_Sel)),  AV85TFUsuarioSucursal_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"||"+GXt_char8+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV74TFUsuarioNombreCompleto)),  AV74TFUsuarioNombreCompleto, out  GXt_char8) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFUsuarioCorreo)),  AV54TFUsuarioCorreo, out  GXt_char7) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFPuestoDescripcion)),  AV42TFPuestoDescripcion, out  GXt_char6) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV84TFUsuarioSucursal)),  AV84TFUsuarioSucursal, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char8+"||"+GXt_char7+"|"+GXt_char6+"||"+((0==AV50TFUsuarioCelular) ? "" : StringUtil.Str( (decimal)(AV50TFUsuarioCelular), 10, 0))+"|"+GXt_char5+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|||||"+((0==AV51TFUsuarioCelular_To) ? "" : StringUtil.Str( (decimal)(AV51TFUsuarioCelular_To), 10, 0))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV18GridState.FromXml(AV29Session.Get(AV207Pgmname+"GridState"), null, "", "");
         AV18GridState.gxTpr_Orderedby = AV25OrderedBy;
         AV18GridState.gxTpr_Ordereddsc = AV27OrderedDsc;
         AV18GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV18GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)),  0,  AV13FilterFullText,  AV13FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV18GridState,  "TFUSUARIONOMBRECOMPLETO",  context.GetMessage( "Nombre completo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV74TFUsuarioNombreCompleto)),  0,  AV74TFUsuarioNombreCompleto,  AV74TFUsuarioNombreCompleto,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV75TFUsuarioNombreCompleto_Sel)),  AV75TFUsuarioNombreCompleto_Sel,  AV75TFUsuarioNombreCompleto_Sel) ;
         AV5AuxText = ((AV82TFUsuarioRol_Sels.Count==1) ? "["+AV82TFUsuarioRol_Sels.GetString(1)+"]" : context.GetMessage( "WWP_FilterValueDescription_MultipleValues", ""));
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV18GridState,  "TFUSUARIOROL_SEL",  context.GetMessage( "Rol", ""),  !(AV82TFUsuarioRol_Sels.Count==0),  0,  AV82TFUsuarioRol_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV5AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV5AuxText, "[Super Administrador]", context.GetMessage( "Super Administrador", "")), "[Administrador Yokohama]", context.GetMessage( "Administrador Yokohama", "")), "[Asesor]", context.GetMessage( "Asesor", "")), "[Participante]", context.GetMessage( "Participante", ""))),  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV18GridState,  "TFUSUARIOCORREO",  context.GetMessage( "Correo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFUsuarioCorreo)),  0,  AV54TFUsuarioCorreo,  AV54TFUsuarioCorreo,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFUsuarioCorreo_Sel)),  AV55TFUsuarioCorreo_Sel,  AV55TFUsuarioCorreo_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV18GridState,  "TFPUESTODESCRIPCION",  context.GetMessage( "Puesto", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFPuestoDescripcion)),  0,  AV42TFPuestoDescripcion,  AV42TFPuestoDescripcion,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFPuestoDescripcion_Sel)),  AV43TFPuestoDescripcion_Sel,  AV43TFPuestoDescripcion_Sel) ;
         AV5AuxText = ((AV64TFUsuarioGenero_Sels.Count==1) ? "["+AV64TFUsuarioGenero_Sels.GetString(1)+"]" : context.GetMessage( "WWP_FilterValueDescription_MultipleValues", ""));
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV18GridState,  "TFUSUARIOGENERO_SEL",  context.GetMessage( "Género", ""),  !(AV64TFUsuarioGenero_Sels.Count==0),  0,  AV64TFUsuarioGenero_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV5AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( AV5AuxText, "[Masculino]", context.GetMessage( "Masculino", "")), "[Femenino]", context.GetMessage( "Femenino", ""))),  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV18GridState,  "TFUSUARIOCELULAR",  context.GetMessage( "Celular", ""),  !((0==AV50TFUsuarioCelular)&&(0==AV51TFUsuarioCelular_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV50TFUsuarioCelular), 10, 0)),  ((0==AV50TFUsuarioCelular) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV50TFUsuarioCelular), "ZZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV51TFUsuarioCelular_To), 10, 0)),  ((0==AV51TFUsuarioCelular_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV51TFUsuarioCelular_To), "ZZZZZZZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV18GridState,  "TFUSUARIOSUCURSAL",  context.GetMessage( "Sucursal", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV84TFUsuarioSucursal)),  0,  AV84TFUsuarioSucursal,  AV84TFUsuarioSucursal,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV85TFUsuarioSucursal_Sel)),  AV85TFUsuarioSucursal_Sel,  AV85TFUsuarioSucursal_Sel) ;
         AV18GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV18GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV207Pgmname+"GridState",  AV18GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV90TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV90TrnContext.gxTpr_Callerobject = AV207Pgmname;
         AV90TrnContext.gxTpr_Callerondelete = true;
         AV90TrnContext.gxTpr_Callerurl = AV20HTTPRequest.ScriptName+"?"+AV20HTTPRequest.QueryString;
         AV90TrnContext.gxTpr_Transactionname = "Usuario";
         AV29Session.Set("TrnContext", AV90TrnContext.ToXml(false, true, "", ""));
      }

      protected void S222( )
      {
         /* 'LOADCOMBODISTRIBUIDORID' Routine */
         returnInSub = false;
         AV178DistribuidorIDCol.Clear();
         /* Using cursor H003D6 */
         pr_default.execute(4, new Object[] {AV152UsuarioID});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A29UsuarioID = H003D6_A29UsuarioID[0];
            A10DistribuidorID = H003D6_A10DistribuidorID[0];
            AV160YaExiste = false;
            AV223GXV4 = 1;
            while ( AV223GXV4 <= AV178DistribuidorIDCol.Count )
            {
               AV179DistribuidorIDItem = (int)(AV178DistribuidorIDCol.GetNumeric(AV223GXV4));
               if ( AV179DistribuidorIDItem == A10DistribuidorID )
               {
                  AV160YaExiste = true;
                  if (true) break;
               }
               AV223GXV4 = (int)(AV223GXV4+1);
            }
            if ( ! AV160YaExiste )
            {
               AV178DistribuidorIDCol.Add(A10DistribuidorID, 0);
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
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
         PA3D2( ) ;
         WS3D2( ) ;
         WE3D2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20265111131923", true, true);
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
         context.AddJavascriptSource("wplistaparticipantes.js", "?20265111131923", false, true);
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
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_372( )
      {
         edtUsuarioID_Internalname = "USUARIOID_"+sGXsfl_37_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_37_idx;
         edtUsuarioApellido_Internalname = "USUARIOAPELLIDO_"+sGXsfl_37_idx;
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO_"+sGXsfl_37_idx;
         cmbUsuarioRol_Internalname = "USUARIOROL_"+sGXsfl_37_idx;
         edtUsuarioCorreo_Internalname = "USUARIOCORREO_"+sGXsfl_37_idx;
         edtUsuarioPass_Internalname = "USUARIOPASS_"+sGXsfl_37_idx;
         edtUsuarioKey_Internalname = "USUARIOKEY_"+sGXsfl_37_idx;
         edtPuestoID_Internalname = "PUESTOID_"+sGXsfl_37_idx;
         edtPuestoDescripcion_Internalname = "PUESTODESCRIPCION_"+sGXsfl_37_idx;
         cmbUsuarioGenero_Internalname = "USUARIOGENERO_"+sGXsfl_37_idx;
         cmbUsuarioDirectoAsociado_Internalname = "USUARIODIRECTOASOCIADO_"+sGXsfl_37_idx;
         edtUsuarioRazonSocialAsociado_Internalname = "USUARIORAZONSOCIALASOCIADO_"+sGXsfl_37_idx;
         edtUsuarioNombreComercial_Internalname = "USUARIONOMBRECOMERCIAL_"+sGXsfl_37_idx;
         edtUsuarioFechaNacimiento_Internalname = "USUARIOFECHANACIMIENTO_"+sGXsfl_37_idx;
         edtUsuarioCalleNum_Internalname = "USUARIOCALLENUM_"+sGXsfl_37_idx;
         edtUsuarioColonia_Internalname = "USUARIOCOLONIA_"+sGXsfl_37_idx;
         edtUsuarioDelegacion_Internalname = "USUARIODELEGACION_"+sGXsfl_37_idx;
         edtUsuarioCP_Internalname = "USUARIOCP_"+sGXsfl_37_idx;
         cmbUsuarioZona_Internalname = "USUARIOZONA_"+sGXsfl_37_idx;
         edtUsuarioCelular_Internalname = "USUARIOCELULAR_"+sGXsfl_37_idx;
         edtUsuarioTelefonoSucursal_Internalname = "USUARIOTELEFONOSUCURSAL_"+sGXsfl_37_idx;
         edtPaisID_Internalname = "PAISID_"+sGXsfl_37_idx;
         edtPaisDescripcion_Internalname = "PAISDESCRIPCION_"+sGXsfl_37_idx;
         edtEstadoID_Internalname = "ESTADOID_"+sGXsfl_37_idx;
         edtEstadoDescripcion_Internalname = "ESTADODESCRIPCION_"+sGXsfl_37_idx;
         edtCiudadID_Internalname = "CIUDADID_"+sGXsfl_37_idx;
         edtCiudadDescripcion_Internalname = "CIUDADDESCRIPCION_"+sGXsfl_37_idx;
         edtUsuarioSucursal_Internalname = "USUARIOSUCURSAL_"+sGXsfl_37_idx;
         edtavPass_Internalname = "vPASS_"+sGXsfl_37_idx;
         cmbUsuarioProducto_Internalname = "USUARIOPRODUCTO_"+sGXsfl_37_idx;
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtUsuarioID_Internalname = "USUARIOID_"+sGXsfl_37_fel_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_37_fel_idx;
         edtUsuarioApellido_Internalname = "USUARIOAPELLIDO_"+sGXsfl_37_fel_idx;
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO_"+sGXsfl_37_fel_idx;
         cmbUsuarioRol_Internalname = "USUARIOROL_"+sGXsfl_37_fel_idx;
         edtUsuarioCorreo_Internalname = "USUARIOCORREO_"+sGXsfl_37_fel_idx;
         edtUsuarioPass_Internalname = "USUARIOPASS_"+sGXsfl_37_fel_idx;
         edtUsuarioKey_Internalname = "USUARIOKEY_"+sGXsfl_37_fel_idx;
         edtPuestoID_Internalname = "PUESTOID_"+sGXsfl_37_fel_idx;
         edtPuestoDescripcion_Internalname = "PUESTODESCRIPCION_"+sGXsfl_37_fel_idx;
         cmbUsuarioGenero_Internalname = "USUARIOGENERO_"+sGXsfl_37_fel_idx;
         cmbUsuarioDirectoAsociado_Internalname = "USUARIODIRECTOASOCIADO_"+sGXsfl_37_fel_idx;
         edtUsuarioRazonSocialAsociado_Internalname = "USUARIORAZONSOCIALASOCIADO_"+sGXsfl_37_fel_idx;
         edtUsuarioNombreComercial_Internalname = "USUARIONOMBRECOMERCIAL_"+sGXsfl_37_fel_idx;
         edtUsuarioFechaNacimiento_Internalname = "USUARIOFECHANACIMIENTO_"+sGXsfl_37_fel_idx;
         edtUsuarioCalleNum_Internalname = "USUARIOCALLENUM_"+sGXsfl_37_fel_idx;
         edtUsuarioColonia_Internalname = "USUARIOCOLONIA_"+sGXsfl_37_fel_idx;
         edtUsuarioDelegacion_Internalname = "USUARIODELEGACION_"+sGXsfl_37_fel_idx;
         edtUsuarioCP_Internalname = "USUARIOCP_"+sGXsfl_37_fel_idx;
         cmbUsuarioZona_Internalname = "USUARIOZONA_"+sGXsfl_37_fel_idx;
         edtUsuarioCelular_Internalname = "USUARIOCELULAR_"+sGXsfl_37_fel_idx;
         edtUsuarioTelefonoSucursal_Internalname = "USUARIOTELEFONOSUCURSAL_"+sGXsfl_37_fel_idx;
         edtPaisID_Internalname = "PAISID_"+sGXsfl_37_fel_idx;
         edtPaisDescripcion_Internalname = "PAISDESCRIPCION_"+sGXsfl_37_fel_idx;
         edtEstadoID_Internalname = "ESTADOID_"+sGXsfl_37_fel_idx;
         edtEstadoDescripcion_Internalname = "ESTADODESCRIPCION_"+sGXsfl_37_fel_idx;
         edtCiudadID_Internalname = "CIUDADID_"+sGXsfl_37_fel_idx;
         edtCiudadDescripcion_Internalname = "CIUDADDESCRIPCION_"+sGXsfl_37_fel_idx;
         edtUsuarioSucursal_Internalname = "USUARIOSUCURSAL_"+sGXsfl_37_fel_idx;
         edtavPass_Internalname = "vPASS_"+sGXsfl_37_fel_idx;
         cmbUsuarioProducto_Internalname = "USUARIOPRODUCTO_"+sGXsfl_37_fel_idx;
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB3D0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_37_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_37_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_37_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombre_Internalname,StringUtil.RTrim( A30UsuarioNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioApellido_Internalname,StringUtil.RTrim( A51UsuarioApellido),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioApellido_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtUsuarioNombreCompleto_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombreCompleto_Internalname,(string)A52UsuarioNombreCompleto,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombreCompleto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtUsuarioNombreCompleto_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbUsuarioRol.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            GXCCtl = "USUARIOROL_" + sGXsfl_37_idx;
            cmbUsuarioRol.Name = GXCCtl;
            cmbUsuarioRol.WebTags = "";
            cmbUsuarioRol.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
            cmbUsuarioRol.addItem("Super Administrador", context.GetMessage( "Super Administrador", ""), 0);
            cmbUsuarioRol.addItem("Administrador Yokohama", context.GetMessage( "Administrador Yokohama", ""), 0);
            cmbUsuarioRol.addItem("Asesor", context.GetMessage( "Asesor", ""), 0);
            cmbUsuarioRol.addItem("Participante", context.GetMessage( "Participante", ""), 0);
            if ( cmbUsuarioRol.ItemCount > 0 )
            {
               A40UsuarioRol = cmbUsuarioRol.getValidValue(A40UsuarioRol);
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbUsuarioRol,(string)cmbUsuarioRol_Internalname,StringUtil.RTrim( A40UsuarioRol),(short)1,(string)cmbUsuarioRol_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbUsuarioRol.Visible,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbUsuarioRol.CurrentValue = StringUtil.RTrim( A40UsuarioRol);
            AssignProp("", false, cmbUsuarioRol_Internalname, "Values", (string)(cmbUsuarioRol.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtUsuarioCorreo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioCorreo_Internalname,(string)A31UsuarioCorreo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A31UsuarioCorreo,(string)"",(string)"",(string)"",(string)edtUsuarioCorreo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtUsuarioCorreo_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioPass_Internalname,(string)A32UsuarioPass,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioPass_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioKey_Internalname,(string)A33UsuarioKey,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioKey_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPuestoID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PuestoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A13PuestoID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPuestoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPuestoDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPuestoDescripcion_Internalname,(string)A14PuestoDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPuestoDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPuestoDescripcion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbUsuarioGenero.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbUsuarioGenero.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "USUARIOGENERO_" + sGXsfl_37_idx;
               cmbUsuarioGenero.Name = GXCCtl;
               cmbUsuarioGenero.WebTags = "";
               cmbUsuarioGenero.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
               cmbUsuarioGenero.addItem("Masculino", context.GetMessage( "Masculino", ""), 0);
               cmbUsuarioGenero.addItem("Femenino", context.GetMessage( "Femenino", ""), 0);
               if ( cmbUsuarioGenero.ItemCount > 0 )
               {
                  A53UsuarioGenero = cmbUsuarioGenero.getValidValue(A53UsuarioGenero);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbUsuarioGenero,(string)cmbUsuarioGenero_Internalname,StringUtil.RTrim( A53UsuarioGenero),(short)1,(string)cmbUsuarioGenero_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbUsuarioGenero.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbUsuarioGenero.CurrentValue = StringUtil.RTrim( A53UsuarioGenero);
            AssignProp("", false, cmbUsuarioGenero_Internalname, "Values", (string)(cmbUsuarioGenero.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbUsuarioDirectoAsociado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "USUARIODIRECTOASOCIADO_" + sGXsfl_37_idx;
               cmbUsuarioDirectoAsociado.Name = GXCCtl;
               cmbUsuarioDirectoAsociado.WebTags = "";
               cmbUsuarioDirectoAsociado.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
               cmbUsuarioDirectoAsociado.addItem("Directo", context.GetMessage( "Directo", ""), 0);
               cmbUsuarioDirectoAsociado.addItem("Asociado", context.GetMessage( "Asociado", ""), 0);
               if ( cmbUsuarioDirectoAsociado.ItemCount > 0 )
               {
                  A54UsuarioDirectoAsociado = cmbUsuarioDirectoAsociado.getValidValue(A54UsuarioDirectoAsociado);
                  n54UsuarioDirectoAsociado = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbUsuarioDirectoAsociado,(string)cmbUsuarioDirectoAsociado_Internalname,StringUtil.RTrim( A54UsuarioDirectoAsociado),(short)1,(string)cmbUsuarioDirectoAsociado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbUsuarioDirectoAsociado.CurrentValue = StringUtil.RTrim( A54UsuarioDirectoAsociado);
            AssignProp("", false, cmbUsuarioDirectoAsociado_Internalname, "Values", (string)(cmbUsuarioDirectoAsociado.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioRazonSocialAsociado_Internalname,(string)A55UsuarioRazonSocialAsociado,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioRazonSocialAsociado_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombreComercial_Internalname,(string)A56UsuarioNombreComercial,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombreComercial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioFechaNacimiento_Internalname,context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"),context.localUtil.Format( A57UsuarioFechaNacimiento, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioFechaNacimiento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioCalleNum_Internalname,StringUtil.RTrim( A59UsuarioCalleNum),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioCalleNum_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioColonia_Internalname,StringUtil.RTrim( A60UsuarioColonia),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioColonia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioDelegacion_Internalname,StringUtil.RTrim( A61UsuarioDelegacion),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioDelegacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioCP_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A62UsuarioCP), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A62UsuarioCP), "ZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioCP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbUsuarioZona.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "USUARIOZONA_" + sGXsfl_37_idx;
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
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbUsuarioZona,(string)cmbUsuarioZona_Internalname,StringUtil.RTrim( A63UsuarioZona),(short)1,(string)cmbUsuarioZona_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbUsuarioZona.CurrentValue = StringUtil.RTrim( A63UsuarioZona);
            AssignProp("", false, cmbUsuarioZona_Internalname, "Values", (string)(cmbUsuarioZona.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtUsuarioCelular_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioCelular_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A64UsuarioCelular), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A64UsuarioCelular), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioCelular_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtUsuarioCelular_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioTelefonoSucursal_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A65UsuarioTelefonoSucursal), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A65UsuarioTelefonoSucursal), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioTelefonoSucursal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaisID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A16PaisID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaisID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaisDescripcion_Internalname,(string)A17PaisDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaisDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EstadoID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoDescripcion_Internalname,(string)A2EstadoDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCiudadID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A4CiudadID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCiudadID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCiudadDescripcion_Internalname,(string)A5CiudadDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCiudadDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtUsuarioSucursal_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioSucursal_Internalname,StringUtil.RTrim( A66UsuarioSucursal),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioSucursal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtUsuarioSucursal_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavPass_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPass_Internalname,StringUtil.RTrim( AV161Pass),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPass_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavPass_Visible,(int)edtavPass_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbUsuarioProducto.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "USUARIOPRODUCTO_" + sGXsfl_37_idx;
               cmbUsuarioProducto.Name = GXCCtl;
               cmbUsuarioProducto.WebTags = "";
               cmbUsuarioProducto.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
               cmbUsuarioProducto.addItem("Auto y Camioneta", context.GetMessage( "Auto y Camioneta", ""), 0);
               cmbUsuarioProducto.addItem("Auto y Camioneta/Camión", context.GetMessage( "Auto y Camioneta/Camión", ""), 0);
               cmbUsuarioProducto.addItem("Camión", context.GetMessage( "Camión", ""), 0);
               cmbUsuarioProducto.addItem("Empleado", context.GetMessage( "Empleado", ""), 0);
               cmbUsuarioProducto.addItem("OTR/Camión", context.GetMessage( "OTR/Camión", ""), 0);
               if ( cmbUsuarioProducto.ItemCount > 0 )
               {
                  A67UsuarioProducto = cmbUsuarioProducto.getValidValue(A67UsuarioProducto);
                  n67UsuarioProducto = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbUsuarioProducto,(string)cmbUsuarioProducto_Internalname,StringUtil.RTrim( A67UsuarioProducto),(short)1,(string)cmbUsuarioProducto_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbUsuarioProducto.CurrentValue = StringUtil.RTrim( A67UsuarioProducto);
            AssignProp("", false, cmbUsuarioProducto_Internalname, "Values", (string)(cmbUsuarioProducto.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_37_idx + "',37)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_37_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV14GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV14GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV14GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV14GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_37_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            send_integrity_lvl_hashes3D2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "USUARIOROL_" + sGXsfl_37_idx;
         cmbUsuarioRol.Name = GXCCtl;
         cmbUsuarioRol.WebTags = "";
         cmbUsuarioRol.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbUsuarioRol.addItem("Super Administrador", context.GetMessage( "Super Administrador", ""), 0);
         cmbUsuarioRol.addItem("Administrador Yokohama", context.GetMessage( "Administrador Yokohama", ""), 0);
         cmbUsuarioRol.addItem("Asesor", context.GetMessage( "Asesor", ""), 0);
         cmbUsuarioRol.addItem("Participante", context.GetMessage( "Participante", ""), 0);
         if ( cmbUsuarioRol.ItemCount > 0 )
         {
            A40UsuarioRol = cmbUsuarioRol.getValidValue(A40UsuarioRol);
         }
         GXCCtl = "USUARIOGENERO_" + sGXsfl_37_idx;
         cmbUsuarioGenero.Name = GXCCtl;
         cmbUsuarioGenero.WebTags = "";
         cmbUsuarioGenero.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbUsuarioGenero.addItem("Masculino", context.GetMessage( "Masculino", ""), 0);
         cmbUsuarioGenero.addItem("Femenino", context.GetMessage( "Femenino", ""), 0);
         if ( cmbUsuarioGenero.ItemCount > 0 )
         {
            A53UsuarioGenero = cmbUsuarioGenero.getValidValue(A53UsuarioGenero);
         }
         GXCCtl = "USUARIODIRECTOASOCIADO_" + sGXsfl_37_idx;
         cmbUsuarioDirectoAsociado.Name = GXCCtl;
         cmbUsuarioDirectoAsociado.WebTags = "";
         cmbUsuarioDirectoAsociado.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbUsuarioDirectoAsociado.addItem("Directo", context.GetMessage( "Directo", ""), 0);
         cmbUsuarioDirectoAsociado.addItem("Asociado", context.GetMessage( "Asociado", ""), 0);
         if ( cmbUsuarioDirectoAsociado.ItemCount > 0 )
         {
            A54UsuarioDirectoAsociado = cmbUsuarioDirectoAsociado.getValidValue(A54UsuarioDirectoAsociado);
            n54UsuarioDirectoAsociado = false;
         }
         GXCCtl = "USUARIOZONA_" + sGXsfl_37_idx;
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
         GXCCtl = "USUARIOPRODUCTO_" + sGXsfl_37_idx;
         cmbUsuarioProducto.Name = GXCCtl;
         cmbUsuarioProducto.WebTags = "";
         cmbUsuarioProducto.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbUsuarioProducto.addItem("Auto y Camioneta", context.GetMessage( "Auto y Camioneta", ""), 0);
         cmbUsuarioProducto.addItem("Auto y Camioneta/Camión", context.GetMessage( "Auto y Camioneta/Camión", ""), 0);
         cmbUsuarioProducto.addItem("Camión", context.GetMessage( "Camión", ""), 0);
         cmbUsuarioProducto.addItem("Empleado", context.GetMessage( "Empleado", ""), 0);
         cmbUsuarioProducto.addItem("OTR/Camión", context.GetMessage( "OTR/Camión", ""), 0);
         if ( cmbUsuarioProducto.ItemCount > 0 )
         {
            A67UsuarioProducto = cmbUsuarioProducto.getValidValue(A67UsuarioProducto);
            n67UsuarioProducto = false;
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_37_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV14GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV14GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV14GridActions), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"37\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtUsuarioNombreCompleto_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre completo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbUsuarioRol.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rol", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtUsuarioCorreo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Correo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPuestoDescripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Puesto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbUsuarioGenero.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Género", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtUsuarioCelular_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Celular", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtUsuarioSucursal_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Sucursal", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavPass_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Contraseña", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A30UsuarioNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A51UsuarioApellido)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A52UsuarioNombreCompleto));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioNombreCompleto_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A40UsuarioRol)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbUsuarioRol.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A31UsuarioCorreo));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioCorreo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A32UsuarioPass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A33UsuarioKey));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PuestoID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A14PuestoDescripcion));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPuestoDescripcion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A53UsuarioGenero)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbUsuarioGenero.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A54UsuarioDirectoAsociado)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A55UsuarioRazonSocialAsociado));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A56UsuarioNombreComercial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A59UsuarioCalleNum)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A60UsuarioColonia)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A61UsuarioDelegacion)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A62UsuarioCP), 5, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A63UsuarioZona)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A64UsuarioCelular), 10, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioCelular_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A65UsuarioTelefonoSucursal), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A17PaisDescripcion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A2EstadoDescripcion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A5CiudadDescripcion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A66UsuarioSucursal)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioSucursal_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV161Pass)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPass_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPass_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A67UsuarioProducto));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14GridActions), 4, 0, ".", ""))));
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
         bttBtnuseraction1_Internalname = "BTNUSERACTION1";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtUsuarioID_Internalname = "USUARIOID";
         edtUsuarioNombre_Internalname = "USUARIONOMBRE";
         edtUsuarioApellido_Internalname = "USUARIOAPELLIDO";
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO";
         cmbUsuarioRol_Internalname = "USUARIOROL";
         edtUsuarioCorreo_Internalname = "USUARIOCORREO";
         edtUsuarioPass_Internalname = "USUARIOPASS";
         edtUsuarioKey_Internalname = "USUARIOKEY";
         edtPuestoID_Internalname = "PUESTOID";
         edtPuestoDescripcion_Internalname = "PUESTODESCRIPCION";
         cmbUsuarioGenero_Internalname = "USUARIOGENERO";
         cmbUsuarioDirectoAsociado_Internalname = "USUARIODIRECTOASOCIADO";
         edtUsuarioRazonSocialAsociado_Internalname = "USUARIORAZONSOCIALASOCIADO";
         edtUsuarioNombreComercial_Internalname = "USUARIONOMBRECOMERCIAL";
         edtUsuarioFechaNacimiento_Internalname = "USUARIOFECHANACIMIENTO";
         edtUsuarioCalleNum_Internalname = "USUARIOCALLENUM";
         edtUsuarioColonia_Internalname = "USUARIOCOLONIA";
         edtUsuarioDelegacion_Internalname = "USUARIODELEGACION";
         edtUsuarioCP_Internalname = "USUARIOCP";
         cmbUsuarioZona_Internalname = "USUARIOZONA";
         edtUsuarioCelular_Internalname = "USUARIOCELULAR";
         edtUsuarioTelefonoSucursal_Internalname = "USUARIOTELEFONOSUCURSAL";
         edtPaisID_Internalname = "PAISID";
         edtPaisDescripcion_Internalname = "PAISDESCRIPCION";
         edtEstadoID_Internalname = "ESTADOID";
         edtEstadoDescripcion_Internalname = "ESTADODESCRIPCION";
         edtCiudadID_Internalname = "CIUDADID";
         edtCiudadDescripcion_Internalname = "CIUDADDESCRIPCION";
         edtUsuarioSucursal_Internalname = "USUARIOSUCURSAL";
         edtavPass_Internalname = "vPASS";
         cmbUsuarioProducto_Internalname = "USUARIOPRODUCTO";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
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
         cmbUsuarioProducto_Jsonclick = "";
         edtavPass_Jsonclick = "";
         edtavPass_Enabled = 1;
         edtUsuarioSucursal_Jsonclick = "";
         edtCiudadDescripcion_Jsonclick = "";
         edtCiudadID_Jsonclick = "";
         edtEstadoDescripcion_Jsonclick = "";
         edtEstadoID_Jsonclick = "";
         edtPaisDescripcion_Jsonclick = "";
         edtPaisID_Jsonclick = "";
         edtUsuarioTelefonoSucursal_Jsonclick = "";
         edtUsuarioCelular_Jsonclick = "";
         cmbUsuarioZona_Jsonclick = "";
         edtUsuarioCP_Jsonclick = "";
         edtUsuarioDelegacion_Jsonclick = "";
         edtUsuarioColonia_Jsonclick = "";
         edtUsuarioCalleNum_Jsonclick = "";
         edtUsuarioFechaNacimiento_Jsonclick = "";
         edtUsuarioNombreComercial_Jsonclick = "";
         edtUsuarioRazonSocialAsociado_Jsonclick = "";
         cmbUsuarioDirectoAsociado_Jsonclick = "";
         cmbUsuarioGenero_Jsonclick = "";
         edtPuestoDescripcion_Jsonclick = "";
         edtPuestoID_Jsonclick = "";
         edtUsuarioKey_Jsonclick = "";
         edtUsuarioPass_Jsonclick = "";
         edtUsuarioCorreo_Jsonclick = "";
         cmbUsuarioRol_Jsonclick = "";
         edtUsuarioNombreCompleto_Jsonclick = "";
         edtUsuarioApellido_Jsonclick = "";
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioID_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridNoBorder WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavPass_Visible = -1;
         edtUsuarioSucursal_Visible = -1;
         edtUsuarioCelular_Visible = -1;
         cmbUsuarioGenero.Visible = -1;
         edtPuestoDescripcion_Visible = -1;
         edtUsuarioCorreo_Visible = -1;
         cmbUsuarioRol.Visible = -1;
         edtUsuarioNombreCompleto_Visible = -1;
         cmbUsuarioProducto.Enabled = 0;
         edtUsuarioSucursal_Enabled = 0;
         edtCiudadDescripcion_Enabled = 0;
         edtCiudadID_Enabled = 0;
         edtEstadoDescripcion_Enabled = 0;
         edtEstadoID_Enabled = 0;
         edtPaisDescripcion_Enabled = 0;
         edtPaisID_Enabled = 0;
         edtUsuarioTelefonoSucursal_Enabled = 0;
         edtUsuarioCelular_Enabled = 0;
         cmbUsuarioZona.Enabled = 0;
         edtUsuarioCP_Enabled = 0;
         edtUsuarioDelegacion_Enabled = 0;
         edtUsuarioColonia_Enabled = 0;
         edtUsuarioCalleNum_Enabled = 0;
         edtUsuarioFechaNacimiento_Enabled = 0;
         edtUsuarioNombreComercial_Enabled = 0;
         edtUsuarioRazonSocialAsociado_Enabled = 0;
         cmbUsuarioDirectoAsociado.Enabled = 0;
         cmbUsuarioGenero.Enabled = 0;
         edtPuestoDescripcion_Enabled = 0;
         edtPuestoID_Enabled = 0;
         edtUsuarioKey_Enabled = 0;
         edtUsuarioPass_Enabled = 0;
         edtUsuarioCorreo_Enabled = 0;
         cmbUsuarioRol.Enabled = 0;
         edtUsuarioNombreCompleto_Enabled = 0;
         edtUsuarioApellido_Enabled = 0;
         edtUsuarioNombre_Enabled = 0;
         edtUsuarioID_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Format = "|||||10.0||";
         Ddo_grid_Datalistproc = "WPListaParticipantesGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|Super Administrador:Super Administrador,Administrador Yokohama:Administrador Yokohama,Asesor:Asesor,Participante:Participante|||Masculino:Masculino,Femenino:Femenino|||";
         Ddo_grid_Allowmultipleselection = "|T|||T|||";
         Ddo_grid_Datalisttype = "Dynamic|FixedValues|Dynamic|Dynamic|FixedValues||Dynamic|";
         Ddo_grid_Includedatalist = "T|T|T|T|T||T|";
         Ddo_grid_Filterisrange = "|||||T||";
         Ddo_grid_Filtertype = "Character||Character|Character||Numeric|Character|";
         Ddo_grid_Includefilter = "T||T|T||T|T|";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "|T|T|T|T|T|T|";
         Ddo_grid_Columnssortvalues = "|1|2|3|4|5|6|";
         Ddo_grid_Columnids = "3:UsuarioNombreCompleto|4:UsuarioRol|5:UsuarioCorreo|9:PuestoDescripcion|10:UsuarioGenero|20:UsuarioCelular|28:UsuarioSucursal|29:Pass";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( " Usuario", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV116ListaUsuariosAsesores","fld":"vLISTAUSUARIOSASESORES"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV25OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV207Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV74TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV75TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV82TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV54TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV55TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV42TFPuestoDescripcion","fld":"vTFPUESTODESCRIPCION"},{"av":"AV43TFPuestoDescripcion_Sel","fld":"vTFPUESTODESCRIPCION_SEL"},{"av":"AV64TFUsuarioGenero_Sels","fld":"vTFUSUARIOGENERO_SELS"},{"av":"AV50TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV51TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV84TFUsuarioSucursal","fld":"vTFUSUARIOSUCURSAL"},{"av":"AV85TFUsuarioSucursal_Sel","fld":"vTFUSUARIOSUCURSAL_SEL"},{"av":"AV155UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"AV152UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"cmbUsuarioRol"},{"av":"edtUsuarioCorreo_Visible","ctrl":"USUARIOCORREO","prop":"Visible"},{"av":"edtPuestoDescripcion_Visible","ctrl":"PUESTODESCRIPCION","prop":"Visible"},{"av":"cmbUsuarioGenero"},{"av":"edtUsuarioCelular_Visible","ctrl":"USUARIOCELULAR","prop":"Visible"},{"av":"edtUsuarioSucursal_Visible","ctrl":"USUARIOSUCURSAL","prop":"Visible"},{"av":"edtavPass_Visible","ctrl":"vPASS","prop":"Visible"},{"av":"AV16GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV17GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV15GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV18GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E123D2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV25OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV116ListaUsuariosAsesores","fld":"vLISTAUSUARIOSASESORES"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV207Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV74TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV75TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV82TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV54TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV55TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV42TFPuestoDescripcion","fld":"vTFPUESTODESCRIPCION"},{"av":"AV43TFPuestoDescripcion_Sel","fld":"vTFPUESTODESCRIPCION_SEL"},{"av":"AV64TFUsuarioGenero_Sels","fld":"vTFUSUARIOGENERO_SELS"},{"av":"AV50TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV51TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV84TFUsuarioSucursal","fld":"vTFUSUARIOSUCURSAL"},{"av":"AV85TFUsuarioSucursal_Sel","fld":"vTFUSUARIOSUCURSAL_SEL"},{"av":"AV155UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"AV152UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E133D2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV25OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV116ListaUsuariosAsesores","fld":"vLISTAUSUARIOSASESORES"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV207Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV74TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV75TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV82TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV54TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV55TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV42TFPuestoDescripcion","fld":"vTFPUESTODESCRIPCION"},{"av":"AV43TFPuestoDescripcion_Sel","fld":"vTFPUESTODESCRIPCION_SEL"},{"av":"AV64TFUsuarioGenero_Sels","fld":"vTFUSUARIOGENERO_SELS"},{"av":"AV50TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV51TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV84TFUsuarioSucursal","fld":"vTFUSUARIOSUCURSAL"},{"av":"AV85TFUsuarioSucursal_Sel","fld":"vTFUSUARIOSUCURSAL_SEL"},{"av":"AV155UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"AV152UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E143D2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV25OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV116ListaUsuariosAsesores","fld":"vLISTAUSUARIOSASESORES"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV207Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV74TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV75TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV82TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV54TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV55TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV42TFPuestoDescripcion","fld":"vTFPUESTODESCRIPCION"},{"av":"AV43TFPuestoDescripcion_Sel","fld":"vTFPUESTODESCRIPCION_SEL"},{"av":"AV64TFUsuarioGenero_Sels","fld":"vTFUSUARIOGENERO_SELS"},{"av":"AV50TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV51TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV84TFUsuarioSucursal","fld":"vTFUSUARIOSUCURSAL"},{"av":"AV85TFUsuarioSucursal_Sel","fld":"vTFUSUARIOSUCURSAL_SEL"},{"av":"AV155UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"AV152UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV25OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV84TFUsuarioSucursal","fld":"vTFUSUARIOSUCURSAL"},{"av":"AV85TFUsuarioSucursal_Sel","fld":"vTFUSUARIOSUCURSAL_SEL"},{"av":"AV50TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV51TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV65TFUsuarioGenero_SelsJson","fld":"vTFUSUARIOGENERO_SELSJSON"},{"av":"AV64TFUsuarioGenero_Sels","fld":"vTFUSUARIOGENERO_SELS"},{"av":"AV42TFPuestoDescripcion","fld":"vTFPUESTODESCRIPCION"},{"av":"AV43TFPuestoDescripcion_Sel","fld":"vTFPUESTODESCRIPCION_SEL"},{"av":"AV54TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV55TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV83TFUsuarioRol_SelsJson","fld":"vTFUSUARIOROL_SELSJSON"},{"av":"AV82TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV74TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV75TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E193D2","iparms":[{"av":"AV155UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"cmbUsuarioRol"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A32UsuarioPass","fld":"USUARIOPASS"},{"av":"A33UsuarioKey","fld":"USUARIOKEY"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV161Pass","fld":"vPASS"},{"av":"cmbavGridactions"},{"av":"AV14GridActions","fld":"vGRIDACTIONS","pic":"ZZZ9"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E153D2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV25OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV116ListaUsuariosAsesores","fld":"vLISTAUSUARIOSASESORES"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV207Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV74TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV75TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV82TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV54TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV55TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV42TFPuestoDescripcion","fld":"vTFPUESTODESCRIPCION"},{"av":"AV43TFPuestoDescripcion_Sel","fld":"vTFPUESTODESCRIPCION_SEL"},{"av":"AV64TFUsuarioGenero_Sels","fld":"vTFUSUARIOGENERO_SELS"},{"av":"AV50TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV51TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV84TFUsuarioSucursal","fld":"vTFUSUARIOSUCURSAL"},{"av":"AV85TFUsuarioSucursal_Sel","fld":"vTFUSUARIOSUCURSAL_SEL"},{"av":"AV155UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"AV152UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"cmbUsuarioRol"},{"av":"edtUsuarioCorreo_Visible","ctrl":"USUARIOCORREO","prop":"Visible"},{"av":"edtPuestoDescripcion_Visible","ctrl":"PUESTODESCRIPCION","prop":"Visible"},{"av":"cmbUsuarioGenero"},{"av":"edtUsuarioCelular_Visible","ctrl":"USUARIOCELULAR","prop":"Visible"},{"av":"edtUsuarioSucursal_Visible","ctrl":"USUARIOSUCURSAL","prop":"Visible"},{"av":"edtavPass_Visible","ctrl":"vPASS","prop":"Visible"},{"av":"AV16GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV17GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV15GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV18GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E113D2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV25OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV116ListaUsuariosAsesores","fld":"vLISTAUSUARIOSASESORES"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV207Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV74TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV75TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV82TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV54TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV55TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV42TFPuestoDescripcion","fld":"vTFPUESTODESCRIPCION"},{"av":"AV43TFPuestoDescripcion_Sel","fld":"vTFPUESTODESCRIPCION_SEL"},{"av":"AV64TFUsuarioGenero_Sels","fld":"vTFUSUARIOGENERO_SELS"},{"av":"AV50TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV51TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV84TFUsuarioSucursal","fld":"vTFUSUARIOSUCURSAL"},{"av":"AV85TFUsuarioSucursal_Sel","fld":"vTFUSUARIOSUCURSAL_SEL"},{"av":"AV155UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"AV152UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV18GridState","fld":"vGRIDSTATE"},{"av":"AV83TFUsuarioRol_SelsJson","fld":"vTFUSUARIOROL_SELSJSON"},{"av":"AV65TFUsuarioGenero_SelsJson","fld":"vTFUSUARIOGENERO_SELSJSON"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18GridState","fld":"vGRIDSTATE"},{"av":"AV25OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV74TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV75TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV82TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV54TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV55TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV42TFPuestoDescripcion","fld":"vTFPUESTODESCRIPCION"},{"av":"AV43TFPuestoDescripcion_Sel","fld":"vTFPUESTODESCRIPCION_SEL"},{"av":"AV64TFUsuarioGenero_Sels","fld":"vTFUSUARIOGENERO_SELS"},{"av":"AV50TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV51TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV84TFUsuarioSucursal","fld":"vTFUSUARIOSUCURSAL"},{"av":"AV85TFUsuarioSucursal_Sel","fld":"vTFUSUARIOSUCURSAL_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV65TFUsuarioGenero_SelsJson","fld":"vTFUSUARIOGENERO_SELSJSON"},{"av":"AV83TFUsuarioRol_SelsJson","fld":"vTFUSUARIOROL_SELSJSON"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"cmbUsuarioRol"},{"av":"edtUsuarioCorreo_Visible","ctrl":"USUARIOCORREO","prop":"Visible"},{"av":"edtPuestoDescripcion_Visible","ctrl":"PUESTODESCRIPCION","prop":"Visible"},{"av":"cmbUsuarioGenero"},{"av":"edtUsuarioCelular_Visible","ctrl":"USUARIOCELULAR","prop":"Visible"},{"av":"edtUsuarioSucursal_Visible","ctrl":"USUARIOSUCURSAL","prop":"Visible"},{"av":"edtavPass_Visible","ctrl":"vPASS","prop":"Visible"},{"av":"AV16GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV17GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV15GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VGRIDACTIONS.CLICK","""{"handler":"E203D2","iparms":[{"av":"cmbavGridactions"},{"av":"AV14GridActions","fld":"vGRIDACTIONS","pic":"ZZZ9"},{"av":"AV155UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"cmbUsuarioRol"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV25OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV116ListaUsuariosAsesores","fld":"vLISTAUSUARIOSASESORES"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV207Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV74TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV75TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV82TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV54TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV55TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV42TFPuestoDescripcion","fld":"vTFPUESTODESCRIPCION"},{"av":"AV43TFPuestoDescripcion_Sel","fld":"vTFPUESTODESCRIPCION_SEL"},{"av":"AV64TFUsuarioGenero_Sels","fld":"vTFUSUARIOGENERO_SELS"},{"av":"AV50TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV51TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV84TFUsuarioSucursal","fld":"vTFUSUARIOSUCURSAL"},{"av":"AV85TFUsuarioSucursal_Sel","fld":"vTFUSUARIOSUCURSAL_SEL"},{"av":"AV152UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("VGRIDACTIONS.CLICK",""","oparms":[{"av":"cmbavGridactions"},{"av":"AV14GridActions","fld":"vGRIDACTIONS","pic":"ZZZ9"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"cmbUsuarioRol"},{"av":"edtUsuarioCorreo_Visible","ctrl":"USUARIOCORREO","prop":"Visible"},{"av":"edtPuestoDescripcion_Visible","ctrl":"PUESTODESCRIPCION","prop":"Visible"},{"av":"cmbUsuarioGenero"},{"av":"edtUsuarioCelular_Visible","ctrl":"USUARIOCELULAR","prop":"Visible"},{"av":"edtUsuarioSucursal_Visible","ctrl":"USUARIOSUCURSAL","prop":"Visible"},{"av":"edtavPass_Visible","ctrl":"vPASS","prop":"Visible"},{"av":"AV16GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV17GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV15GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV18GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOUSERACTION1'","""{"handler":"E163D2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV25OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV116ListaUsuariosAsesores","fld":"vLISTAUSUARIOSASESORES"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV207Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV74TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV75TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV82TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV54TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV55TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV42TFPuestoDescripcion","fld":"vTFPUESTODESCRIPCION"},{"av":"AV43TFPuestoDescripcion_Sel","fld":"vTFPUESTODESCRIPCION_SEL"},{"av":"AV64TFUsuarioGenero_Sels","fld":"vTFUSUARIOGENERO_SELS"},{"av":"AV50TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV51TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV84TFUsuarioSucursal","fld":"vTFUSUARIOSUCURSAL"},{"av":"AV85TFUsuarioSucursal_Sel","fld":"vTFUSUARIOSUCURSAL_SEL"},{"av":"AV155UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"AV152UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV178DistribuidorIDCol","fld":"vDISTRIBUIDORIDCOL"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"}]""");
         setEventMetadata("'DOUSERACTION1'",""","oparms":[{"av":"AV178DistribuidorIDCol","fld":"vDISTRIBUIDORIDCOL"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"cmbUsuarioRol"},{"av":"edtUsuarioCorreo_Visible","ctrl":"USUARIOCORREO","prop":"Visible"},{"av":"edtPuestoDescripcion_Visible","ctrl":"PUESTODESCRIPCION","prop":"Visible"},{"av":"cmbUsuarioGenero"},{"av":"edtUsuarioCelular_Visible","ctrl":"USUARIOCELULAR","prop":"Visible"},{"av":"edtUsuarioSucursal_Visible","ctrl":"USUARIOSUCURSAL","prop":"Visible"},{"av":"edtavPass_Visible","ctrl":"vPASS","prop":"Visible"},{"av":"AV16GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV17GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV15GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV22ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV18GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VALID_USUARIOID","""{"handler":"Valid_Usuarioid","iparms":[]}""");
         setEventMetadata("VALID_USUARIONOMBRECOMPLETO","""{"handler":"Valid_Usuarionombrecompleto","iparms":[]}""");
         setEventMetadata("VALID_USUARIOROL","""{"handler":"Valid_Usuariorol","iparms":[]}""");
         setEventMetadata("VALID_USUARIOCORREO","""{"handler":"Valid_Usuariocorreo","iparms":[]}""");
         setEventMetadata("VALID_PUESTOID","""{"handler":"Valid_Puestoid","iparms":[]}""");
         setEventMetadata("VALID_PUESTODESCRIPCION","""{"handler":"Valid_Puestodescripcion","iparms":[]}""");
         setEventMetadata("VALID_USUARIOGENERO","""{"handler":"Valid_Usuariogenero","iparms":[]}""");
         setEventMetadata("VALID_USUARIOCELULAR","""{"handler":"Valid_Usuariocelular","iparms":[]}""");
         setEventMetadata("VALID_PAISID","""{"handler":"Valid_Paisid","iparms":[]}""");
         setEventMetadata("VALID_ESTADOID","""{"handler":"Valid_Estadoid","iparms":[]}""");
         setEventMetadata("VALID_CIUDADID","""{"handler":"Valid_Ciudadid","iparms":[]}""");
         setEventMetadata("VALID_USUARIOSUCURSAL","""{"handler":"Valid_Usuariosucursal","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV116ListaUsuariosAsesores = new GxSimpleCollection<int>();
         AV6ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV207Pgmname = "";
         AV13FilterFullText = "";
         AV74TFUsuarioNombreCompleto = "";
         AV75TFUsuarioNombreCompleto_Sel = "";
         AV82TFUsuarioRol_Sels = new GxSimpleCollection<string>();
         AV54TFUsuarioCorreo = "";
         AV55TFUsuarioCorreo_Sel = "";
         AV42TFPuestoDescripcion = "";
         AV43TFPuestoDescripcion_Sel = "";
         AV64TFUsuarioGenero_Sels = new GxSimpleCollection<string>();
         AV84TFUsuarioSucursal = "";
         AV85TFUsuarioSucursal_Sel = "";
         AV155UsuarioRol = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV22ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV15GridAppliedFilters = "";
         AV9DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV18GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV83TFUsuarioRol_SelsJson = "";
         AV65TFUsuarioGenero_SelsJson = "";
         AV178DistribuidorIDCol = new GxSimpleCollection<int>();
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
         ClassString = "";
         StyleString = "";
         bttBtnuseraction1_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A52UsuarioNombreCompleto = "";
         A40UsuarioRol = "";
         A31UsuarioCorreo = "";
         A32UsuarioPass = "";
         A33UsuarioKey = "";
         A14PuestoDescripcion = "";
         A53UsuarioGenero = "";
         A54UsuarioDirectoAsociado = "";
         A55UsuarioRazonSocialAsociado = "";
         A56UsuarioNombreComercial = "";
         A57UsuarioFechaNacimiento = DateTime.MinValue;
         A59UsuarioCalleNum = "";
         A60UsuarioColonia = "";
         A61UsuarioDelegacion = "";
         A63UsuarioZona = "";
         A17PaisDescripcion = "";
         A2EstadoDescripcion = "";
         A5CiudadDescripcion = "";
         A66UsuarioSucursal = "";
         AV161Pass = "";
         A67UsuarioProducto = "";
         AV208Wplistaparticipantesds_1_filterfulltext = "";
         AV209Wplistaparticipantesds_2_tfusuarionombrecompleto = "";
         AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel = "";
         AV211Wplistaparticipantesds_4_tfusuariorol_sels = new GxSimpleCollection<string>();
         AV212Wplistaparticipantesds_5_tfusuariocorreo = "";
         AV213Wplistaparticipantesds_6_tfusuariocorreo_sel = "";
         AV214Wplistaparticipantesds_7_tfpuestodescripcion = "";
         AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel = "";
         AV216Wplistaparticipantesds_9_tfusuariogenero_sels = new GxSimpleCollection<string>();
         AV219Wplistaparticipantesds_12_tfusuariosucursal = "";
         AV220Wplistaparticipantesds_13_tfusuariosucursal_sel = "";
         lV208Wplistaparticipantesds_1_filterfulltext = "";
         lV209Wplistaparticipantesds_2_tfusuarionombrecompleto = "";
         lV212Wplistaparticipantesds_5_tfusuariocorreo = "";
         lV214Wplistaparticipantesds_7_tfpuestodescripcion = "";
         lV219Wplistaparticipantesds_12_tfusuariosucursal = "";
         H003D2_A67UsuarioProducto = new string[] {""} ;
         H003D2_n67UsuarioProducto = new bool[] {false} ;
         H003D2_A66UsuarioSucursal = new string[] {""} ;
         H003D2_A5CiudadDescripcion = new string[] {""} ;
         H003D2_A4CiudadID = new int[1] ;
         H003D2_n4CiudadID = new bool[] {false} ;
         H003D2_A2EstadoDescripcion = new string[] {""} ;
         H003D2_A1EstadoID = new int[1] ;
         H003D2_A17PaisDescripcion = new string[] {""} ;
         H003D2_A16PaisID = new int[1] ;
         H003D2_A65UsuarioTelefonoSucursal = new long[1] ;
         H003D2_A64UsuarioCelular = new long[1] ;
         H003D2_A63UsuarioZona = new string[] {""} ;
         H003D2_A62UsuarioCP = new int[1] ;
         H003D2_A61UsuarioDelegacion = new string[] {""} ;
         H003D2_A60UsuarioColonia = new string[] {""} ;
         H003D2_A59UsuarioCalleNum = new string[] {""} ;
         H003D2_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         H003D2_n57UsuarioFechaNacimiento = new bool[] {false} ;
         H003D2_A56UsuarioNombreComercial = new string[] {""} ;
         H003D2_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         H003D2_A54UsuarioDirectoAsociado = new string[] {""} ;
         H003D2_n54UsuarioDirectoAsociado = new bool[] {false} ;
         H003D2_A53UsuarioGenero = new string[] {""} ;
         H003D2_A14PuestoDescripcion = new string[] {""} ;
         H003D2_A13PuestoID = new int[1] ;
         H003D2_n13PuestoID = new bool[] {false} ;
         H003D2_A33UsuarioKey = new string[] {""} ;
         H003D2_A32UsuarioPass = new string[] {""} ;
         H003D2_A31UsuarioCorreo = new string[] {""} ;
         H003D2_A40UsuarioRol = new string[] {""} ;
         H003D2_A52UsuarioNombreCompleto = new string[] {""} ;
         H003D2_A29UsuarioID = new int[1] ;
         H003D2_A30UsuarioNombre = new string[] {""} ;
         H003D2_A51UsuarioApellido = new string[] {""} ;
         H003D3_A67UsuarioProducto = new string[] {""} ;
         H003D3_n67UsuarioProducto = new bool[] {false} ;
         H003D3_A66UsuarioSucursal = new string[] {""} ;
         H003D3_A5CiudadDescripcion = new string[] {""} ;
         H003D3_A4CiudadID = new int[1] ;
         H003D3_n4CiudadID = new bool[] {false} ;
         H003D3_A2EstadoDescripcion = new string[] {""} ;
         H003D3_A1EstadoID = new int[1] ;
         H003D3_A17PaisDescripcion = new string[] {""} ;
         H003D3_A16PaisID = new int[1] ;
         H003D3_A65UsuarioTelefonoSucursal = new long[1] ;
         H003D3_A64UsuarioCelular = new long[1] ;
         H003D3_A63UsuarioZona = new string[] {""} ;
         H003D3_A62UsuarioCP = new int[1] ;
         H003D3_A61UsuarioDelegacion = new string[] {""} ;
         H003D3_A60UsuarioColonia = new string[] {""} ;
         H003D3_A59UsuarioCalleNum = new string[] {""} ;
         H003D3_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         H003D3_n57UsuarioFechaNacimiento = new bool[] {false} ;
         H003D3_A56UsuarioNombreComercial = new string[] {""} ;
         H003D3_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         H003D3_A54UsuarioDirectoAsociado = new string[] {""} ;
         H003D3_n54UsuarioDirectoAsociado = new bool[] {false} ;
         H003D3_A53UsuarioGenero = new string[] {""} ;
         H003D3_A14PuestoDescripcion = new string[] {""} ;
         H003D3_A13PuestoID = new int[1] ;
         H003D3_n13PuestoID = new bool[] {false} ;
         H003D3_A33UsuarioKey = new string[] {""} ;
         H003D3_A32UsuarioPass = new string[] {""} ;
         H003D3_A31UsuarioCorreo = new string[] {""} ;
         H003D3_A40UsuarioRol = new string[] {""} ;
         H003D3_A52UsuarioNombreCompleto = new string[] {""} ;
         H003D3_A29UsuarioID = new int[1] ;
         H003D3_A30UsuarioNombre = new string[] {""} ;
         H003D3_A51UsuarioApellido = new string[] {""} ;
         AV153UsuarioJSON = "";
         AV158WebSession = context.GetSession();
         AV127SDTUsuario = new SdtSDTUsuario(context);
         AV115ListaDistribuidores = new GxSimpleCollection<int>();
         H003D4_A81DistribuidoresUsuarioID = new int[1] ;
         H003D4_A29UsuarioID = new int[1] ;
         H003D4_A10DistribuidorID = new int[1] ;
         H003D5_A81DistribuidoresUsuarioID = new int[1] ;
         H003D5_A40UsuarioRol = new string[] {""} ;
         H003D5_A10DistribuidorID = new int[1] ;
         H003D5_A29UsuarioID = new int[1] ;
         AV20HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV93WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29Session = context.GetSession();
         AV8ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV24ManageFiltersXml = "";
         AV92UserCustomValue = "";
         AV7ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV19GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char4 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV5AuxText = "";
         AV90TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         H003D6_A81DistribuidoresUsuarioID = new int[1] ;
         H003D6_A29UsuarioID = new int[1] ;
         H003D6_A10DistribuidorID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wplistaparticipantes__default(),
            new Object[][] {
                new Object[] {
               H003D2_A67UsuarioProducto, H003D2_n67UsuarioProducto, H003D2_A66UsuarioSucursal, H003D2_A5CiudadDescripcion, H003D2_A4CiudadID, H003D2_n4CiudadID, H003D2_A2EstadoDescripcion, H003D2_A1EstadoID, H003D2_A17PaisDescripcion, H003D2_A16PaisID,
               H003D2_A65UsuarioTelefonoSucursal, H003D2_A64UsuarioCelular, H003D2_A63UsuarioZona, H003D2_A62UsuarioCP, H003D2_A61UsuarioDelegacion, H003D2_A60UsuarioColonia, H003D2_A59UsuarioCalleNum, H003D2_A57UsuarioFechaNacimiento, H003D2_n57UsuarioFechaNacimiento, H003D2_A56UsuarioNombreComercial,
               H003D2_A55UsuarioRazonSocialAsociado, H003D2_A54UsuarioDirectoAsociado, H003D2_n54UsuarioDirectoAsociado, H003D2_A53UsuarioGenero, H003D2_A14PuestoDescripcion, H003D2_A13PuestoID, H003D2_n13PuestoID, H003D2_A33UsuarioKey, H003D2_A32UsuarioPass, H003D2_A31UsuarioCorreo,
               H003D2_A40UsuarioRol, H003D2_A52UsuarioNombreCompleto, H003D2_A29UsuarioID, H003D2_A30UsuarioNombre, H003D2_A51UsuarioApellido
               }
               , new Object[] {
               H003D3_A67UsuarioProducto, H003D3_n67UsuarioProducto, H003D3_A66UsuarioSucursal, H003D3_A5CiudadDescripcion, H003D3_A4CiudadID, H003D3_n4CiudadID, H003D3_A2EstadoDescripcion, H003D3_A1EstadoID, H003D3_A17PaisDescripcion, H003D3_A16PaisID,
               H003D3_A65UsuarioTelefonoSucursal, H003D3_A64UsuarioCelular, H003D3_A63UsuarioZona, H003D3_A62UsuarioCP, H003D3_A61UsuarioDelegacion, H003D3_A60UsuarioColonia, H003D3_A59UsuarioCalleNum, H003D3_A57UsuarioFechaNacimiento, H003D3_n57UsuarioFechaNacimiento, H003D3_A56UsuarioNombreComercial,
               H003D3_A55UsuarioRazonSocialAsociado, H003D3_A54UsuarioDirectoAsociado, H003D3_n54UsuarioDirectoAsociado, H003D3_A53UsuarioGenero, H003D3_A14PuestoDescripcion, H003D3_A13PuestoID, H003D3_n13PuestoID, H003D3_A33UsuarioKey, H003D3_A32UsuarioPass, H003D3_A31UsuarioCorreo,
               H003D3_A40UsuarioRol, H003D3_A52UsuarioNombreCompleto, H003D3_A29UsuarioID, H003D3_A30UsuarioNombre, H003D3_A51UsuarioApellido
               }
               , new Object[] {
               H003D4_A81DistribuidoresUsuarioID, H003D4_A29UsuarioID, H003D4_A10DistribuidorID
               }
               , new Object[] {
               H003D5_A81DistribuidoresUsuarioID, H003D5_A40UsuarioRol, H003D5_A10DistribuidorID, H003D5_A29UsuarioID
               }
               , new Object[] {
               H003D6_A81DistribuidoresUsuarioID, H003D6_A29UsuarioID, H003D6_A10DistribuidorID
               }
            }
         );
         AV207Pgmname = "WPListaParticipantes";
         /* GeneXus formulas. */
         AV207Pgmname = "WPListaParticipantes";
         edtavPass_Enabled = 0;
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
      private short AV25OrderedBy ;
      private short AV23ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV14GridActions ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV202Cuenta ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_37 ;
      private int nGXsfl_37_idx=1 ;
      private int AV152UsuarioID ;
      private int A10DistribuidorID ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A29UsuarioID ;
      private int A13PuestoID ;
      private int A62UsuarioCP ;
      private int A16PaisID ;
      private int A1EstadoID ;
      private int A4CiudadID ;
      private int subGrid_Islastpage ;
      private int edtavPass_Enabled ;
      private int AV211Wplistaparticipantesds_4_tfusuariorol_sels_Count ;
      private int AV216Wplistaparticipantesds_9_tfusuariogenero_sels_Count ;
      private int edtUsuarioID_Enabled ;
      private int edtUsuarioNombre_Enabled ;
      private int edtUsuarioApellido_Enabled ;
      private int edtUsuarioNombreCompleto_Enabled ;
      private int edtUsuarioCorreo_Enabled ;
      private int edtUsuarioPass_Enabled ;
      private int edtUsuarioKey_Enabled ;
      private int edtPuestoID_Enabled ;
      private int edtPuestoDescripcion_Enabled ;
      private int edtUsuarioRazonSocialAsociado_Enabled ;
      private int edtUsuarioNombreComercial_Enabled ;
      private int edtUsuarioFechaNacimiento_Enabled ;
      private int edtUsuarioCalleNum_Enabled ;
      private int edtUsuarioColonia_Enabled ;
      private int edtUsuarioDelegacion_Enabled ;
      private int edtUsuarioCP_Enabled ;
      private int edtUsuarioCelular_Enabled ;
      private int edtUsuarioTelefonoSucursal_Enabled ;
      private int edtPaisID_Enabled ;
      private int edtPaisDescripcion_Enabled ;
      private int edtEstadoID_Enabled ;
      private int edtEstadoDescripcion_Enabled ;
      private int edtCiudadID_Enabled ;
      private int edtCiudadDescripcion_Enabled ;
      private int edtUsuarioSucursal_Enabled ;
      private int AV204GXV1 ;
      private int AV105DistribuidorID ;
      private int AV206GXV2 ;
      private int AV156UsuariosListaID ;
      private int edtUsuarioNombreCompleto_Visible ;
      private int edtUsuarioCorreo_Visible ;
      private int edtPuestoDescripcion_Visible ;
      private int edtUsuarioCelular_Visible ;
      private int edtUsuarioSucursal_Visible ;
      private int edtavPass_Visible ;
      private int AV28PageToGo ;
      private int AV221GXV3 ;
      private int AV223GXV4 ;
      private int AV179DistribuidorIDItem ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV50TFUsuarioCelular ;
      private long AV51TFUsuarioCelular_To ;
      private long AV16GridCurrentPage ;
      private long AV17GridPageCount ;
      private long A64UsuarioCelular ;
      private long A65UsuarioTelefonoSucursal ;
      private long GRID_nCurrentRecord ;
      private long AV217Wplistaparticipantesds_10_tfusuariocelular ;
      private long AV218Wplistaparticipantesds_11_tfusuariocelular_to ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV207Pgmname ;
      private string AV84TFUsuarioSucursal ;
      private string AV85TFUsuarioSucursal_Sel ;
      private string AV155UsuarioRol ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string Ddo_grid_Format ;
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
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
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
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtUsuarioID_Internalname ;
      private string A30UsuarioNombre ;
      private string edtUsuarioNombre_Internalname ;
      private string A51UsuarioApellido ;
      private string edtUsuarioApellido_Internalname ;
      private string edtUsuarioNombreCompleto_Internalname ;
      private string cmbUsuarioRol_Internalname ;
      private string A40UsuarioRol ;
      private string edtUsuarioCorreo_Internalname ;
      private string edtUsuarioPass_Internalname ;
      private string edtUsuarioKey_Internalname ;
      private string edtPuestoID_Internalname ;
      private string edtPuestoDescripcion_Internalname ;
      private string cmbUsuarioGenero_Internalname ;
      private string A53UsuarioGenero ;
      private string cmbUsuarioDirectoAsociado_Internalname ;
      private string A54UsuarioDirectoAsociado ;
      private string edtUsuarioRazonSocialAsociado_Internalname ;
      private string edtUsuarioNombreComercial_Internalname ;
      private string edtUsuarioFechaNacimiento_Internalname ;
      private string A59UsuarioCalleNum ;
      private string edtUsuarioCalleNum_Internalname ;
      private string A60UsuarioColonia ;
      private string edtUsuarioColonia_Internalname ;
      private string A61UsuarioDelegacion ;
      private string edtUsuarioDelegacion_Internalname ;
      private string edtUsuarioCP_Internalname ;
      private string cmbUsuarioZona_Internalname ;
      private string A63UsuarioZona ;
      private string edtUsuarioCelular_Internalname ;
      private string edtUsuarioTelefonoSucursal_Internalname ;
      private string edtPaisID_Internalname ;
      private string edtPaisDescripcion_Internalname ;
      private string edtEstadoID_Internalname ;
      private string edtEstadoDescripcion_Internalname ;
      private string edtCiudadID_Internalname ;
      private string edtCiudadDescripcion_Internalname ;
      private string A66UsuarioSucursal ;
      private string edtUsuarioSucursal_Internalname ;
      private string AV161Pass ;
      private string edtavPass_Internalname ;
      private string cmbUsuarioProducto_Internalname ;
      private string cmbavGridactions_Internalname ;
      private string AV219Wplistaparticipantesds_12_tfusuariosucursal ;
      private string AV220Wplistaparticipantesds_13_tfusuariosucursal_sel ;
      private string lV219Wplistaparticipantesds_12_tfusuariosucursal ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtUsuarioID_Jsonclick ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtUsuarioApellido_Jsonclick ;
      private string edtUsuarioNombreCompleto_Jsonclick ;
      private string GXCCtl ;
      private string cmbUsuarioRol_Jsonclick ;
      private string edtUsuarioCorreo_Jsonclick ;
      private string edtUsuarioPass_Jsonclick ;
      private string edtUsuarioKey_Jsonclick ;
      private string edtPuestoID_Jsonclick ;
      private string edtPuestoDescripcion_Jsonclick ;
      private string cmbUsuarioGenero_Jsonclick ;
      private string cmbUsuarioDirectoAsociado_Jsonclick ;
      private string edtUsuarioRazonSocialAsociado_Jsonclick ;
      private string edtUsuarioNombreComercial_Jsonclick ;
      private string edtUsuarioFechaNacimiento_Jsonclick ;
      private string edtUsuarioCalleNum_Jsonclick ;
      private string edtUsuarioColonia_Jsonclick ;
      private string edtUsuarioDelegacion_Jsonclick ;
      private string edtUsuarioCP_Jsonclick ;
      private string cmbUsuarioZona_Jsonclick ;
      private string edtUsuarioCelular_Jsonclick ;
      private string edtUsuarioTelefonoSucursal_Jsonclick ;
      private string edtPaisID_Jsonclick ;
      private string edtPaisDescripcion_Jsonclick ;
      private string edtEstadoID_Jsonclick ;
      private string edtEstadoDescripcion_Jsonclick ;
      private string edtCiudadID_Jsonclick ;
      private string edtCiudadDescripcion_Jsonclick ;
      private string edtUsuarioSucursal_Jsonclick ;
      private string edtavPass_Jsonclick ;
      private string cmbUsuarioProducto_Jsonclick ;
      private string cmbavGridactions_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A57UsuarioFechaNacimiento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV27OrderedDsc ;
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
      private bool n13PuestoID ;
      private bool n54UsuarioDirectoAsociado ;
      private bool n57UsuarioFechaNacimiento ;
      private bool n4CiudadID ;
      private bool n67UsuarioProducto ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV160YaExiste ;
      private bool AV125Pasa ;
      private bool gx_refresh_fired ;
      private bool AV162PuedeVer ;
      private string AV83TFUsuarioRol_SelsJson ;
      private string AV65TFUsuarioGenero_SelsJson ;
      private string AV153UsuarioJSON ;
      private string AV8ColumnsSelectorXML ;
      private string AV24ManageFiltersXml ;
      private string AV92UserCustomValue ;
      private string AV13FilterFullText ;
      private string AV74TFUsuarioNombreCompleto ;
      private string AV75TFUsuarioNombreCompleto_Sel ;
      private string AV54TFUsuarioCorreo ;
      private string AV55TFUsuarioCorreo_Sel ;
      private string AV42TFPuestoDescripcion ;
      private string AV43TFPuestoDescripcion_Sel ;
      private string AV15GridAppliedFilters ;
      private string A52UsuarioNombreCompleto ;
      private string A31UsuarioCorreo ;
      private string A32UsuarioPass ;
      private string A33UsuarioKey ;
      private string A14PuestoDescripcion ;
      private string A55UsuarioRazonSocialAsociado ;
      private string A56UsuarioNombreComercial ;
      private string A17PaisDescripcion ;
      private string A2EstadoDescripcion ;
      private string A5CiudadDescripcion ;
      private string A67UsuarioProducto ;
      private string AV208Wplistaparticipantesds_1_filterfulltext ;
      private string AV209Wplistaparticipantesds_2_tfusuarionombrecompleto ;
      private string AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel ;
      private string AV212Wplistaparticipantesds_5_tfusuariocorreo ;
      private string AV213Wplistaparticipantesds_6_tfusuariocorreo_sel ;
      private string AV214Wplistaparticipantesds_7_tfpuestodescripcion ;
      private string AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel ;
      private string lV208Wplistaparticipantesds_1_filterfulltext ;
      private string lV209Wplistaparticipantesds_2_tfusuarionombrecompleto ;
      private string lV212Wplistaparticipantesds_5_tfusuariocorreo ;
      private string lV214Wplistaparticipantesds_7_tfpuestodescripcion ;
      private string AV5AuxText ;
      private IGxSession AV158WebSession ;
      private IGxSession AV29Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV20HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbUsuarioRol ;
      private GXCombobox cmbUsuarioGenero ;
      private GXCombobox cmbUsuarioDirectoAsociado ;
      private GXCombobox cmbUsuarioZona ;
      private GXCombobox cmbUsuarioProducto ;
      private GXCombobox cmbavGridactions ;
      private GxSimpleCollection<int> AV116ListaUsuariosAsesores ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV6ColumnsSelector ;
      private GxSimpleCollection<string> AV82TFUsuarioRol_Sels ;
      private GxSimpleCollection<string> AV64TFUsuarioGenero_Sels ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV22ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV9DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV18GridState ;
      private GxSimpleCollection<int> AV178DistribuidorIDCol ;
      private GxSimpleCollection<string> AV211Wplistaparticipantesds_4_tfusuariorol_sels ;
      private GxSimpleCollection<string> AV216Wplistaparticipantesds_9_tfusuariogenero_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H003D2_A67UsuarioProducto ;
      private bool[] H003D2_n67UsuarioProducto ;
      private string[] H003D2_A66UsuarioSucursal ;
      private string[] H003D2_A5CiudadDescripcion ;
      private int[] H003D2_A4CiudadID ;
      private bool[] H003D2_n4CiudadID ;
      private string[] H003D2_A2EstadoDescripcion ;
      private int[] H003D2_A1EstadoID ;
      private string[] H003D2_A17PaisDescripcion ;
      private int[] H003D2_A16PaisID ;
      private long[] H003D2_A65UsuarioTelefonoSucursal ;
      private long[] H003D2_A64UsuarioCelular ;
      private string[] H003D2_A63UsuarioZona ;
      private int[] H003D2_A62UsuarioCP ;
      private string[] H003D2_A61UsuarioDelegacion ;
      private string[] H003D2_A60UsuarioColonia ;
      private string[] H003D2_A59UsuarioCalleNum ;
      private DateTime[] H003D2_A57UsuarioFechaNacimiento ;
      private bool[] H003D2_n57UsuarioFechaNacimiento ;
      private string[] H003D2_A56UsuarioNombreComercial ;
      private string[] H003D2_A55UsuarioRazonSocialAsociado ;
      private string[] H003D2_A54UsuarioDirectoAsociado ;
      private bool[] H003D2_n54UsuarioDirectoAsociado ;
      private string[] H003D2_A53UsuarioGenero ;
      private string[] H003D2_A14PuestoDescripcion ;
      private int[] H003D2_A13PuestoID ;
      private bool[] H003D2_n13PuestoID ;
      private string[] H003D2_A33UsuarioKey ;
      private string[] H003D2_A32UsuarioPass ;
      private string[] H003D2_A31UsuarioCorreo ;
      private string[] H003D2_A40UsuarioRol ;
      private string[] H003D2_A52UsuarioNombreCompleto ;
      private int[] H003D2_A29UsuarioID ;
      private string[] H003D2_A30UsuarioNombre ;
      private string[] H003D2_A51UsuarioApellido ;
      private string[] H003D3_A67UsuarioProducto ;
      private bool[] H003D3_n67UsuarioProducto ;
      private string[] H003D3_A66UsuarioSucursal ;
      private string[] H003D3_A5CiudadDescripcion ;
      private int[] H003D3_A4CiudadID ;
      private bool[] H003D3_n4CiudadID ;
      private string[] H003D3_A2EstadoDescripcion ;
      private int[] H003D3_A1EstadoID ;
      private string[] H003D3_A17PaisDescripcion ;
      private int[] H003D3_A16PaisID ;
      private long[] H003D3_A65UsuarioTelefonoSucursal ;
      private long[] H003D3_A64UsuarioCelular ;
      private string[] H003D3_A63UsuarioZona ;
      private int[] H003D3_A62UsuarioCP ;
      private string[] H003D3_A61UsuarioDelegacion ;
      private string[] H003D3_A60UsuarioColonia ;
      private string[] H003D3_A59UsuarioCalleNum ;
      private DateTime[] H003D3_A57UsuarioFechaNacimiento ;
      private bool[] H003D3_n57UsuarioFechaNacimiento ;
      private string[] H003D3_A56UsuarioNombreComercial ;
      private string[] H003D3_A55UsuarioRazonSocialAsociado ;
      private string[] H003D3_A54UsuarioDirectoAsociado ;
      private bool[] H003D3_n54UsuarioDirectoAsociado ;
      private string[] H003D3_A53UsuarioGenero ;
      private string[] H003D3_A14PuestoDescripcion ;
      private int[] H003D3_A13PuestoID ;
      private bool[] H003D3_n13PuestoID ;
      private string[] H003D3_A33UsuarioKey ;
      private string[] H003D3_A32UsuarioPass ;
      private string[] H003D3_A31UsuarioCorreo ;
      private string[] H003D3_A40UsuarioRol ;
      private string[] H003D3_A52UsuarioNombreCompleto ;
      private int[] H003D3_A29UsuarioID ;
      private string[] H003D3_A30UsuarioNombre ;
      private string[] H003D3_A51UsuarioApellido ;
      private SdtSDTUsuario AV127SDTUsuario ;
      private GxSimpleCollection<int> AV115ListaDistribuidores ;
      private int[] H003D4_A81DistribuidoresUsuarioID ;
      private int[] H003D4_A29UsuarioID ;
      private int[] H003D4_A10DistribuidorID ;
      private int[] H003D5_A81DistribuidoresUsuarioID ;
      private string[] H003D5_A40UsuarioRol ;
      private int[] H003D5_A10DistribuidorID ;
      private int[] H003D5_A29UsuarioID ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV93WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV7ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV19GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV90TrnContext ;
      private int[] H003D6_A81DistribuidoresUsuarioID ;
      private int[] H003D6_A29UsuarioID ;
      private int[] H003D6_A10DistribuidorID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wplistaparticipantes__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003D2( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV116ListaUsuariosAsesores ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV211Wplistaparticipantesds_4_tfusuariorol_sels ,
                                             string A53UsuarioGenero ,
                                             GxSimpleCollection<string> AV216Wplistaparticipantesds_9_tfusuariogenero_sels ,
                                             string AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel ,
                                             string AV209Wplistaparticipantesds_2_tfusuarionombrecompleto ,
                                             int AV211Wplistaparticipantesds_4_tfusuariorol_sels_Count ,
                                             string AV213Wplistaparticipantesds_6_tfusuariocorreo_sel ,
                                             string AV212Wplistaparticipantesds_5_tfusuariocorreo ,
                                             string AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel ,
                                             string AV214Wplistaparticipantesds_7_tfpuestodescripcion ,
                                             int AV216Wplistaparticipantesds_9_tfusuariogenero_sels_Count ,
                                             long AV217Wplistaparticipantesds_10_tfusuariocelular ,
                                             long AV218Wplistaparticipantesds_11_tfusuariocelular_to ,
                                             string AV220Wplistaparticipantesds_13_tfusuariosucursal_sel ,
                                             string AV219Wplistaparticipantesds_12_tfusuariosucursal ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             string A14PuestoDescripcion ,
                                             long A64UsuarioCelular ,
                                             string A66UsuarioSucursal ,
                                             short AV25OrderedBy ,
                                             bool AV27OrderedDsc ,
                                             string AV208Wplistaparticipantesds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[10];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.`UsuarioProducto`, T1.`UsuarioSucursal`, T2.`CiudadDescripcion`, T1.`CiudadID`, T3.`EstadoDescripcion`, T2.`EstadoID`, T4.`PaisDescripcion`, T3.`PaisID`, T1.`UsuarioTelefonoSucursal`, T1.`UsuarioCelular`, T1.`UsuarioZona`, T1.`UsuarioCP`, T1.`UsuarioDelegacion`, T1.`UsuarioColonia`, T1.`UsuarioCalleNum`, T1.`UsuarioFechaNacimiento`, T1.`UsuarioNombreComercial`, T1.`UsuarioRazonSocialAsociado`, T1.`UsuarioDirectoAsociado`, T1.`UsuarioGenero`, T5.`PuestoDescripcion`, T1.`PuestoID`, T1.`UsuarioKey`, T1.`UsuarioPass`, T1.`UsuarioCorreo`, T1.`UsuarioRol`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioID`, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM ((((`Usuario` T1 LEFT JOIN `Ciudad` T2 ON T2.`CiudadID` = T1.`CiudadID`) LEFT JOIN `Estado` T3 ON T3.`EstadoID` = T2.`EstadoID`) LEFT JOIN `Pais` T4 ON T4.`PaisID` = T3.`PaisID`) LEFT JOIN `Puesto` T5 ON T5.`PuestoID` = T1.`PuestoID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV116ListaUsuariosAsesores, "T1.`UsuarioID` IN (", ")")+")");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV209Wplistaparticipantesds_2_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV209Wplistaparticipantesds_2_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( StringUtil.StrCmp(AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( AV211Wplistaparticipantesds_4_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV211Wplistaparticipantesds_4_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV213Wplistaparticipantesds_6_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV212Wplistaparticipantesds_5_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV212Wplistaparticipantesds_5_tfusuariocorreo)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV213Wplistaparticipantesds_6_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV213Wplistaparticipantesds_6_tfusuariocorreo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV213Wplistaparticipantesds_6_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( StringUtil.StrCmp(AV213Wplistaparticipantesds_6_tfusuariocorreo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV214Wplistaparticipantesds_7_tfpuestodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T5.`PuestoDescripcion` like @lV214Wplistaparticipantesds_7_tfpuestodescripcion)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel)) && ! ( StringUtil.StrCmp(AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.`PuestoDescripcion` = @AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.`PuestoDescripcion` IS NULL or (LENGTH(TRIM(T5.`PuestoDescripcion`))=0))");
         }
         if ( AV216Wplistaparticipantesds_9_tfusuariogenero_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV216Wplistaparticipantesds_9_tfusuariogenero_sels, "T1.`UsuarioGenero` IN (", ")")+")");
         }
         if ( ! (0==AV217Wplistaparticipantesds_10_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV217Wplistaparticipantesds_10_tfusuariocelular)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! (0==AV218Wplistaparticipantesds_11_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV218Wplistaparticipantesds_11_tfusuariocelular_to)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV220Wplistaparticipantesds_13_tfusuariosucursal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV219Wplistaparticipantesds_12_tfusuariosucursal)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` like @lV219Wplistaparticipantesds_12_tfusuariosucursal)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV220Wplistaparticipantesds_13_tfusuariosucursal_sel)) && ! ( StringUtil.StrCmp(AV220Wplistaparticipantesds_13_tfusuariosucursal_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` = @AV220Wplistaparticipantesds_13_tfusuariosucursal_sel)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV220Wplistaparticipantesds_13_tfusuariosucursal_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioSucursal`))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV25OrderedBy == 1 ) && ! AV27OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioRol`";
         }
         else if ( ( AV25OrderedBy == 1 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioRol` DESC";
         }
         else if ( ( AV25OrderedBy == 2 ) && ! AV27OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCorreo`";
         }
         else if ( ( AV25OrderedBy == 2 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCorreo` DESC";
         }
         else if ( ( AV25OrderedBy == 3 ) && ! AV27OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.`PuestoDescripcion`";
         }
         else if ( ( AV25OrderedBy == 3 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.`PuestoDescripcion` DESC";
         }
         else if ( ( AV25OrderedBy == 4 ) && ! AV27OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioGenero`";
         }
         else if ( ( AV25OrderedBy == 4 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioGenero` DESC";
         }
         else if ( ( AV25OrderedBy == 5 ) && ! AV27OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCelular`";
         }
         else if ( ( AV25OrderedBy == 5 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCelular` DESC";
         }
         else if ( ( AV25OrderedBy == 6 ) && ! AV27OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioSucursal`";
         }
         else if ( ( AV25OrderedBy == 6 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioSucursal` DESC";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H003D3( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV116ListaUsuariosAsesores ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV211Wplistaparticipantesds_4_tfusuariorol_sels ,
                                             string A53UsuarioGenero ,
                                             GxSimpleCollection<string> AV216Wplistaparticipantesds_9_tfusuariogenero_sels ,
                                             string AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel ,
                                             string AV209Wplistaparticipantesds_2_tfusuarionombrecompleto ,
                                             int AV211Wplistaparticipantesds_4_tfusuariorol_sels_Count ,
                                             string AV213Wplistaparticipantesds_6_tfusuariocorreo_sel ,
                                             string AV212Wplistaparticipantesds_5_tfusuariocorreo ,
                                             string AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel ,
                                             string AV214Wplistaparticipantesds_7_tfpuestodescripcion ,
                                             int AV216Wplistaparticipantesds_9_tfusuariogenero_sels_Count ,
                                             long AV217Wplistaparticipantesds_10_tfusuariocelular ,
                                             long AV218Wplistaparticipantesds_11_tfusuariocelular_to ,
                                             string AV220Wplistaparticipantesds_13_tfusuariosucursal_sel ,
                                             string AV219Wplistaparticipantesds_12_tfusuariosucursal ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             string A14PuestoDescripcion ,
                                             long A64UsuarioCelular ,
                                             string A66UsuarioSucursal ,
                                             short AV25OrderedBy ,
                                             bool AV27OrderedDsc ,
                                             string AV208Wplistaparticipantesds_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[10];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.`UsuarioProducto`, T1.`UsuarioSucursal`, T2.`CiudadDescripcion`, T1.`CiudadID`, T3.`EstadoDescripcion`, T2.`EstadoID`, T4.`PaisDescripcion`, T3.`PaisID`, T1.`UsuarioTelefonoSucursal`, T1.`UsuarioCelular`, T1.`UsuarioZona`, T1.`UsuarioCP`, T1.`UsuarioDelegacion`, T1.`UsuarioColonia`, T1.`UsuarioCalleNum`, T1.`UsuarioFechaNacimiento`, T1.`UsuarioNombreComercial`, T1.`UsuarioRazonSocialAsociado`, T1.`UsuarioDirectoAsociado`, T1.`UsuarioGenero`, T5.`PuestoDescripcion`, T1.`PuestoID`, T1.`UsuarioKey`, T1.`UsuarioPass`, T1.`UsuarioCorreo`, T1.`UsuarioRol`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioID`, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM ((((`Usuario` T1 LEFT JOIN `Ciudad` T2 ON T2.`CiudadID` = T1.`CiudadID`) LEFT JOIN `Estado` T3 ON T3.`EstadoID` = T2.`EstadoID`) LEFT JOIN `Pais` T4 ON T4.`PaisID` = T3.`PaisID`) LEFT JOIN `Puesto` T5 ON T5.`PuestoID` = T1.`PuestoID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV116ListaUsuariosAsesores, "T1.`UsuarioID` IN (", ")")+")");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV209Wplistaparticipantesds_2_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV209Wplistaparticipantesds_2_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int11[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( StringUtil.StrCmp(AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( AV211Wplistaparticipantesds_4_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV211Wplistaparticipantesds_4_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV213Wplistaparticipantesds_6_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV212Wplistaparticipantesds_5_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV212Wplistaparticipantesds_5_tfusuariocorreo)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV213Wplistaparticipantesds_6_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV213Wplistaparticipantesds_6_tfusuariocorreo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV213Wplistaparticipantesds_6_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( StringUtil.StrCmp(AV213Wplistaparticipantesds_6_tfusuariocorreo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV214Wplistaparticipantesds_7_tfpuestodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T5.`PuestoDescripcion` like @lV214Wplistaparticipantesds_7_tfpuestodescripcion)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel)) && ! ( StringUtil.StrCmp(AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.`PuestoDescripcion` = @AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( StringUtil.StrCmp(AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.`PuestoDescripcion` IS NULL or (LENGTH(TRIM(T5.`PuestoDescripcion`))=0))");
         }
         if ( AV216Wplistaparticipantesds_9_tfusuariogenero_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV216Wplistaparticipantesds_9_tfusuariogenero_sels, "T1.`UsuarioGenero` IN (", ")")+")");
         }
         if ( ! (0==AV217Wplistaparticipantesds_10_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV217Wplistaparticipantesds_10_tfusuariocelular)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( ! (0==AV218Wplistaparticipantesds_11_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV218Wplistaparticipantesds_11_tfusuariocelular_to)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV220Wplistaparticipantesds_13_tfusuariosucursal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV219Wplistaparticipantesds_12_tfusuariosucursal)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` like @lV219Wplistaparticipantesds_12_tfusuariosucursal)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV220Wplistaparticipantesds_13_tfusuariosucursal_sel)) && ! ( StringUtil.StrCmp(AV220Wplistaparticipantesds_13_tfusuariosucursal_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioSucursal` = @AV220Wplistaparticipantesds_13_tfusuariosucursal_sel)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( StringUtil.StrCmp(AV220Wplistaparticipantesds_13_tfusuariosucursal_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioSucursal`))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV25OrderedBy == 1 ) && ! AV27OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioRol`";
         }
         else if ( ( AV25OrderedBy == 1 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioRol` DESC";
         }
         else if ( ( AV25OrderedBy == 2 ) && ! AV27OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCorreo`";
         }
         else if ( ( AV25OrderedBy == 2 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCorreo` DESC";
         }
         else if ( ( AV25OrderedBy == 3 ) && ! AV27OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.`PuestoDescripcion`";
         }
         else if ( ( AV25OrderedBy == 3 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.`PuestoDescripcion` DESC";
         }
         else if ( ( AV25OrderedBy == 4 ) && ! AV27OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioGenero`";
         }
         else if ( ( AV25OrderedBy == 4 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioGenero` DESC";
         }
         else if ( ( AV25OrderedBy == 5 ) && ! AV27OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCelular`";
         }
         else if ( ( AV25OrderedBy == 5 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCelular` DESC";
         }
         else if ( ( AV25OrderedBy == 6 ) && ! AV27OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioSucursal`";
         }
         else if ( ( AV25OrderedBy == 6 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioSucursal` DESC";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_H003D5( IGxContext context ,
                                             int A10DistribuidorID ,
                                             GxSimpleCollection<int> AV115ListaDistribuidores ,
                                             string A40UsuarioRol )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T1.`DistribuidoresUsuarioID`, T2.`UsuarioRol`, T1.`DistribuidorID`, T1.`UsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV115ListaDistribuidores, "T1.`DistribuidorID` IN (", ")")+")");
         AddWhere(sWhereString, "(T2.`UsuarioRol` = 'Participante')");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`DistribuidoresUsuarioID`";
         GXv_Object13[0] = scmdbuf;
         return GXv_Object13 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H003D2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 1 :
                     return conditional_H003D3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 3 :
                     return conditional_H003D5(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] );
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
          Object[] prmH003D4;
          prmH003D4 = new Object[] {
          new ParDef("@AV152UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH003D6;
          prmH003D6 = new Object[] {
          new ParDef("@AV152UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH003D2;
          prmH003D2 = new Object[] {
          new ParDef("@lV209Wplistaparticipantesds_2_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV212Wplistaparticipantesds_5_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV213Wplistaparticipantesds_6_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@lV214Wplistaparticipantesds_7_tfpuestodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV217Wplistaparticipantesds_10_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV218Wplistaparticipantesds_11_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV219Wplistaparticipantesds_12_tfusuariosucursal",GXType.Char,20,0) ,
          new ParDef("@AV220Wplistaparticipantesds_13_tfusuariosucursal_sel",GXType.Char,20,0)
          };
          Object[] prmH003D3;
          prmH003D3 = new Object[] {
          new ParDef("@lV209Wplistaparticipantesds_2_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV210Wplistaparticipantesds_3_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV212Wplistaparticipantesds_5_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV213Wplistaparticipantesds_6_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@lV214Wplistaparticipantesds_7_tfpuestodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV215Wplistaparticipantesds_8_tfpuestodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@AV217Wplistaparticipantesds_10_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV218Wplistaparticipantesds_11_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV219Wplistaparticipantesds_12_tfusuariosucursal",GXType.Char,20,0) ,
          new ParDef("@AV220Wplistaparticipantesds_13_tfusuariosucursal_sel",GXType.Char,20,0)
          };
          Object[] prmH003D5;
          prmH003D5 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H003D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003D2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003D3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003D4", "SELECT `DistribuidoresUsuarioID`, `UsuarioID`, `DistribuidorID` FROM `DistribuidoresUsuario` WHERE `UsuarioID` = @AV152UsuarioID ORDER BY `UsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003D4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H003D5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003D5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H003D6", "SELECT `DistribuidoresUsuarioID`, `UsuarioID`, `DistribuidorID` FROM `DistribuidoresUsuario` WHERE `UsuarioID` = @AV152UsuarioID ORDER BY `UsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003D6,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                ((long[]) buf[11])[0] = rslt.getLong(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((string[]) buf[15])[0] = rslt.getString(14, 20);
                ((string[]) buf[16])[0] = rslt.getString(15, 40);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(16);
                ((bool[]) buf[18])[0] = rslt.wasNull(16);
                ((string[]) buf[19])[0] = rslt.getVarchar(17);
                ((string[]) buf[20])[0] = rslt.getVarchar(18);
                ((string[]) buf[21])[0] = rslt.getString(19, 20);
                ((bool[]) buf[22])[0] = rslt.wasNull(19);
                ((string[]) buf[23])[0] = rslt.getString(20, 20);
                ((string[]) buf[24])[0] = rslt.getVarchar(21);
                ((int[]) buf[25])[0] = rslt.getInt(22);
                ((bool[]) buf[26])[0] = rslt.wasNull(22);
                ((string[]) buf[27])[0] = rslt.getVarchar(23);
                ((string[]) buf[28])[0] = rslt.getVarchar(24);
                ((string[]) buf[29])[0] = rslt.getVarchar(25);
                ((string[]) buf[30])[0] = rslt.getString(26, 40);
                ((string[]) buf[31])[0] = rslt.getVarchar(27);
                ((int[]) buf[32])[0] = rslt.getInt(28);
                ((string[]) buf[33])[0] = rslt.getString(29, 50);
                ((string[]) buf[34])[0] = rslt.getString(30, 50);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                ((long[]) buf[11])[0] = rslt.getLong(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((string[]) buf[15])[0] = rslt.getString(14, 20);
                ((string[]) buf[16])[0] = rslt.getString(15, 40);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(16);
                ((bool[]) buf[18])[0] = rslt.wasNull(16);
                ((string[]) buf[19])[0] = rslt.getVarchar(17);
                ((string[]) buf[20])[0] = rslt.getVarchar(18);
                ((string[]) buf[21])[0] = rslt.getString(19, 20);
                ((bool[]) buf[22])[0] = rslt.wasNull(19);
                ((string[]) buf[23])[0] = rslt.getString(20, 20);
                ((string[]) buf[24])[0] = rslt.getVarchar(21);
                ((int[]) buf[25])[0] = rslt.getInt(22);
                ((bool[]) buf[26])[0] = rslt.wasNull(22);
                ((string[]) buf[27])[0] = rslt.getVarchar(23);
                ((string[]) buf[28])[0] = rslt.getVarchar(24);
                ((string[]) buf[29])[0] = rslt.getVarchar(25);
                ((string[]) buf[30])[0] = rslt.getString(26, 40);
                ((string[]) buf[31])[0] = rslt.getVarchar(27);
                ((int[]) buf[32])[0] = rslt.getInt(28);
                ((string[]) buf[33])[0] = rslt.getString(29, 50);
                ((string[]) buf[34])[0] = rslt.getString(30, 50);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
