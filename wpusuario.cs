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
   public class wpusuario : GXDataArea
   {
      public wpusuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpusuario( IGxContext context )
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
         cmbUsuarioProducto = new GXCombobox();
         cmbUsuarioRol = new GXCombobox();
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
         AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV23ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV18ColumnsSelector);
         AV64Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV24TFUsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "TFUsuarioID"), "."), 18, MidpointRounding.ToEven));
         AV25TFUsuarioID_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFUsuarioID_To"), "."), 18, MidpointRounding.ToEven));
         AV44TFUsuarioNombreCompleto = GetPar( "TFUsuarioNombreCompleto");
         AV45TFUsuarioNombreCompleto_Sel = GetPar( "TFUsuarioNombreCompleto_Sel");
         AV28TFUsuarioCorreo = GetPar( "TFUsuarioCorreo");
         AV29TFUsuarioCorreo_Sel = GetPar( "TFUsuarioCorreo_Sel");
         AV51TFUsuarioCelular = (long)(Math.Round(NumberUtil.Val( GetPar( "TFUsuarioCelular"), "."), 18, MidpointRounding.ToEven));
         AV52TFUsuarioCelular_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFUsuarioCelular_To"), "."), 18, MidpointRounding.ToEven));
         AV53TFEstadoDescripcion = GetPar( "TFEstadoDescripcion");
         AV54TFEstadoDescripcion_Sel = GetPar( "TFEstadoDescripcion_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV56TFUsuarioProducto_Sels);
         AV57TFUsuarioNoCuentaBROXEL = GetPar( "TFUsuarioNoCuentaBROXEL");
         AV58TFUsuarioNoCuentaBROXEL_Sel = GetPar( "TFUsuarioNoCuentaBROXEL_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV42TFUsuarioRol_Sels);
         AV49UsuarioRol = GetPar( "UsuarioRol");
         AV61UsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "UsuarioID"), "."), 18, MidpointRounding.ToEven));
         A11DistribuidorDescripcion = GetPar( "DistribuidorDescripcion");
         A93FacturaCompleta = StringUtil.StrToBool( GetPar( "FacturaCompleta"));
         A69FacturaID = (int)(Math.Round(NumberUtil.Val( GetPar( "FacturaID"), "."), 18, MidpointRounding.ToEven));
         A73FacturaFechaFactura = context.localUtil.ParseDateParm( GetPar( "FacturaFechaFactura"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV64Pgmname, AV15FilterFullText, AV24TFUsuarioID, AV25TFUsuarioID_To, AV44TFUsuarioNombreCompleto, AV45TFUsuarioNombreCompleto_Sel, AV28TFUsuarioCorreo, AV29TFUsuarioCorreo_Sel, AV51TFUsuarioCelular, AV52TFUsuarioCelular_To, AV53TFEstadoDescripcion, AV54TFEstadoDescripcion_Sel, AV56TFUsuarioProducto_Sels, AV57TFUsuarioNoCuentaBROXEL, AV58TFUsuarioNoCuentaBROXEL_Sel, AV42TFUsuarioRol_Sels, AV49UsuarioRol, AV61UsuarioID, A11DistribuidorDescripcion, A93FacturaCompleta, A69FacturaID, A73FacturaFechaFactura) ;
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
         PA0Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0Y2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpusuario.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV64Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOROL", StringUtil.RTrim( AV49UsuarioRol));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOROL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49UsuarioRol, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV61UsuarioID), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV21ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV21ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV38GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV34DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV34DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV18ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV18ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV64Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24TFUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25TFUsuarioID_To), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIONOMBRECOMPLETO", AV44TFUsuarioNombreCompleto);
         GxWebStd.gx_hidden_field( context, "vTFUSUARIONOMBRECOMPLETO_SEL", AV45TFUsuarioNombreCompleto_Sel);
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOCORREO", AV28TFUsuarioCorreo);
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOCORREO_SEL", AV29TFUsuarioCorreo_Sel);
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOCELULAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51TFUsuarioCelular), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOCELULAR_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52TFUsuarioCelular_To), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFESTADODESCRIPCION", AV53TFEstadoDescripcion);
         GxWebStd.gx_hidden_field( context, "vTFESTADODESCRIPCION_SEL", AV54TFEstadoDescripcion_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFUSUARIOPRODUCTO_SELS", AV56TFUsuarioProducto_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFUSUARIOPRODUCTO_SELS", AV56TFUsuarioProducto_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFUSUARIONOCUENTABROXEL", StringUtil.RTrim( AV57TFUsuarioNoCuentaBROXEL));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIONOCUENTABROXEL_SEL", StringUtil.RTrim( AV58TFUsuarioNoCuentaBROXEL_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFUSUARIOROL_SELS", AV42TFUsuarioRol_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFUSUARIOROL_SELS", AV42TFUsuarioRol_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vUSUARIOROL", StringUtil.RTrim( AV49UsuarioRol));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOROL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49UsuarioRol, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV61UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DISTRIBUIDORDESCRIPCION", A11DistribuidorDescripcion);
         GxWebStd.gx_boolean_hidden_field( context, "FACTURACOMPLETA", A93FacturaCompleta);
         GxWebStd.gx_hidden_field( context, "FACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "FACTURAFECHAFACTURA", context.localUtil.DToC( A73FacturaFechaFactura, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOPRODUCTO_SELSJSON", AV55TFUsuarioProducto_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOROL_SELSJSON", AV41TFUsuarioRol_SelsJson);
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
            WE0Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0Y2( ) ;
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
         return formatLink("wpusuario.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPUsuario" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Usuario", "") ;
      }

      protected void WB0Y0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "Agregar", ""), bttBtnuseraction1_Jsonclick, 5, context.GetMessage( "Agregar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION1\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUsuario.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WPUsuario.htm");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV36GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV37GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV38GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV34DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV34DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV18ColumnsSelector);
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

      protected void START0Y2( )
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
         STRUP0Y0( ) ;
      }

      protected void WS0Y2( )
      {
         START0Y2( ) ;
         EVT0Y2( ) ;
      }

      protected void EVT0Y2( )
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
                              E110Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E120Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E130Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E140Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E150Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction1' */
                              E160Y2 ();
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
                              A52UsuarioNombreCompleto = cgiGet( edtUsuarioNombreCompleto_Internalname);
                              A31UsuarioCorreo = cgiGet( edtUsuarioCorreo_Internalname);
                              A64UsuarioCelular = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioCelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              AV59Distribuidor = cgiGet( edtavDistribuidor_Internalname);
                              AssignAttri("", false, edtavDistribuidor_Internalname, AV59Distribuidor);
                              A2EstadoDescripcion = cgiGet( edtEstadoDescripcion_Internalname);
                              cmbUsuarioProducto.Name = cmbUsuarioProducto_Internalname;
                              cmbUsuarioProducto.CurrentValue = cgiGet( cmbUsuarioProducto_Internalname);
                              A67UsuarioProducto = cgiGet( cmbUsuarioProducto_Internalname);
                              n67UsuarioProducto = false;
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavNofacturas_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNofacturas_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNOFACTURAS");
                                 GX_FocusControl = edtavNofacturas_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV62NoFacturas = 0;
                                 AssignAttri("", false, edtavNofacturas_Internalname, StringUtil.LTrimStr( (decimal)(AV62NoFacturas), 4, 0));
                              }
                              else
                              {
                                 AV62NoFacturas = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavNofacturas_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavNofacturas_Internalname, StringUtil.LTrimStr( (decimal)(AV62NoFacturas), 4, 0));
                              }
                              if ( context.localUtil.VCDateTime( cgiGet( edtavFechaultimafactura_Internalname), 0, 0) == 0 )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha Ultima Factura", "")}), 1, "vFECHAULTIMAFACTURA");
                                 GX_FocusControl = edtavFechaultimafactura_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV63FechaUltimaFactura = (DateTime)(DateTime.MinValue);
                                 AssignAttri("", false, edtavFechaultimafactura_Internalname, context.localUtil.Format(AV63FechaUltimaFactura, "99/99/99"));
                              }
                              else
                              {
                                 AV63FechaUltimaFactura = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtavFechaultimafactura_Internalname), 0));
                                 AssignAttri("", false, edtavFechaultimafactura_Internalname, context.localUtil.Format(AV63FechaUltimaFactura, "99/99/99"));
                              }
                              A82UsuarioNoCuentaBROXEL = cgiGet( edtUsuarioNoCuentaBROXEL_Internalname);
                              AV40Pass = cgiGet( edtavPass_Internalname);
                              AssignAttri("", false, edtavPass_Internalname, AV40Pass);
                              cmbUsuarioRol.Name = cmbUsuarioRol_Internalname;
                              cmbUsuarioRol.CurrentValue = cgiGet( cmbUsuarioRol_Internalname);
                              A40UsuarioRol = cgiGet( cmbUsuarioRol_Internalname);
                              A32UsuarioPass = cgiGet( edtUsuarioPass_Internalname);
                              A33UsuarioKey = cgiGet( edtUsuarioKey_Internalname);
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV39GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV39GridActions), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E170Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E180Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E190Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E200Y2 ();
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

      protected void WE0Y2( )
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

      protected void PA0Y2( )
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
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       short AV23ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV18ColumnsSelector ,
                                       string AV64Pgmname ,
                                       string AV15FilterFullText ,
                                       int AV24TFUsuarioID ,
                                       int AV25TFUsuarioID_To ,
                                       string AV44TFUsuarioNombreCompleto ,
                                       string AV45TFUsuarioNombreCompleto_Sel ,
                                       string AV28TFUsuarioCorreo ,
                                       string AV29TFUsuarioCorreo_Sel ,
                                       long AV51TFUsuarioCelular ,
                                       long AV52TFUsuarioCelular_To ,
                                       string AV53TFEstadoDescripcion ,
                                       string AV54TFEstadoDescripcion_Sel ,
                                       GxSimpleCollection<string> AV56TFUsuarioProducto_Sels ,
                                       string AV57TFUsuarioNoCuentaBROXEL ,
                                       string AV58TFUsuarioNoCuentaBROXEL_Sel ,
                                       GxSimpleCollection<string> AV42TFUsuarioRol_Sels ,
                                       string AV49UsuarioRol ,
                                       int AV61UsuarioID ,
                                       string A11DistribuidorDescripcion ,
                                       bool A93FacturaCompleta ,
                                       int A69FacturaID ,
                                       DateTime A73FacturaFechaFactura )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOROL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A40UsuarioRol, "")), context));
         GxWebStd.gx_hidden_field( context, "USUARIOROL", StringUtil.RTrim( A40UsuarioRol));
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
         RF0Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV64Pgmname = "WPUsuario";
         edtavDistribuidor_Enabled = 0;
         edtavNofacturas_Enabled = 0;
         edtavFechaultimafactura_Enabled = 0;
         edtavPass_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV65Wpusuariods_1_filterfulltext = AV15FilterFullText;
         AV66Wpusuariods_2_tfusuarioid = AV24TFUsuarioID;
         AV67Wpusuariods_3_tfusuarioid_to = AV25TFUsuarioID_To;
         AV68Wpusuariods_4_tfusuarionombrecompleto = AV44TFUsuarioNombreCompleto;
         AV69Wpusuariods_5_tfusuarionombrecompleto_sel = AV45TFUsuarioNombreCompleto_Sel;
         AV70Wpusuariods_6_tfusuariocorreo = AV28TFUsuarioCorreo;
         AV71Wpusuariods_7_tfusuariocorreo_sel = AV29TFUsuarioCorreo_Sel;
         AV72Wpusuariods_8_tfusuariocelular = AV51TFUsuarioCelular;
         AV73Wpusuariods_9_tfusuariocelular_to = AV52TFUsuarioCelular_To;
         AV74Wpusuariods_10_tfestadodescripcion = AV53TFEstadoDescripcion;
         AV75Wpusuariods_11_tfestadodescripcion_sel = AV54TFEstadoDescripcion_Sel;
         AV76Wpusuariods_12_tfusuarioproducto_sels = AV56TFUsuarioProducto_Sels;
         AV77Wpusuariods_13_tfusuarionocuentabroxel = AV57TFUsuarioNoCuentaBROXEL;
         AV78Wpusuariods_14_tfusuarionocuentabroxel_sel = AV58TFUsuarioNoCuentaBROXEL_Sel;
         AV79Wpusuariods_15_tfusuariorol_sels = AV42TFUsuarioRol_Sels;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A67UsuarioProducto ,
                                              AV76Wpusuariods_12_tfusuarioproducto_sels ,
                                              A40UsuarioRol ,
                                              AV79Wpusuariods_15_tfusuariorol_sels ,
                                              AV66Wpusuariods_2_tfusuarioid ,
                                              AV67Wpusuariods_3_tfusuarioid_to ,
                                              AV69Wpusuariods_5_tfusuarionombrecompleto_sel ,
                                              AV68Wpusuariods_4_tfusuarionombrecompleto ,
                                              AV71Wpusuariods_7_tfusuariocorreo_sel ,
                                              AV70Wpusuariods_6_tfusuariocorreo ,
                                              AV72Wpusuariods_8_tfusuariocelular ,
                                              AV73Wpusuariods_9_tfusuariocelular_to ,
                                              AV75Wpusuariods_11_tfestadodescripcion_sel ,
                                              AV74Wpusuariods_10_tfestadodescripcion ,
                                              AV76Wpusuariods_12_tfusuarioproducto_sels.Count ,
                                              AV78Wpusuariods_14_tfusuarionocuentabroxel_sel ,
                                              AV77Wpusuariods_13_tfusuarionocuentabroxel ,
                                              AV79Wpusuariods_15_tfusuariorol_sels.Count ,
                                              A29UsuarioID ,
                                              A30UsuarioNombre ,
                                              A51UsuarioApellido ,
                                              A31UsuarioCorreo ,
                                              A64UsuarioCelular ,
                                              A2EstadoDescripcion ,
                                              A82UsuarioNoCuentaBROXEL ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              AV65Wpusuariods_1_filterfulltext ,
                                              A52UsuarioNombreCompleto } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV68Wpusuariods_4_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV68Wpusuariods_4_tfusuarionombrecompleto), "%", "");
         lV70Wpusuariods_6_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV70Wpusuariods_6_tfusuariocorreo), "%", "");
         lV74Wpusuariods_10_tfestadodescripcion = StringUtil.Concat( StringUtil.RTrim( AV74Wpusuariods_10_tfestadodescripcion), "%", "");
         lV77Wpusuariods_13_tfusuarionocuentabroxel = StringUtil.PadR( StringUtil.RTrim( AV77Wpusuariods_13_tfusuarionocuentabroxel), 20, "%");
         /* Using cursor H000Y2 */
         pr_default.execute(0, new Object[] {AV66Wpusuariods_2_tfusuarioid, AV67Wpusuariods_3_tfusuarioid_to, lV68Wpusuariods_4_tfusuarionombrecompleto, AV69Wpusuariods_5_tfusuarionombrecompleto_sel, lV70Wpusuariods_6_tfusuariocorreo, AV71Wpusuariods_7_tfusuariocorreo_sel, AV72Wpusuariods_8_tfusuariocelular, AV73Wpusuariods_9_tfusuariocelular_to, lV74Wpusuariods_10_tfestadodescripcion, AV75Wpusuariods_11_tfestadodescripcion_sel, lV77Wpusuariods_13_tfusuarionocuentabroxel, AV78Wpusuariods_14_tfusuarionocuentabroxel_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4CiudadID = H000Y2_A4CiudadID[0];
            n4CiudadID = H000Y2_n4CiudadID[0];
            A1EstadoID = H000Y2_A1EstadoID[0];
            A33UsuarioKey = H000Y2_A33UsuarioKey[0];
            A32UsuarioPass = H000Y2_A32UsuarioPass[0];
            A40UsuarioRol = H000Y2_A40UsuarioRol[0];
            A82UsuarioNoCuentaBROXEL = H000Y2_A82UsuarioNoCuentaBROXEL[0];
            A67UsuarioProducto = H000Y2_A67UsuarioProducto[0];
            n67UsuarioProducto = H000Y2_n67UsuarioProducto[0];
            A2EstadoDescripcion = H000Y2_A2EstadoDescripcion[0];
            A64UsuarioCelular = H000Y2_A64UsuarioCelular[0];
            A31UsuarioCorreo = H000Y2_A31UsuarioCorreo[0];
            A52UsuarioNombreCompleto = H000Y2_A52UsuarioNombreCompleto[0];
            A29UsuarioID = H000Y2_A29UsuarioID[0];
            A30UsuarioNombre = H000Y2_A30UsuarioNombre[0];
            A51UsuarioApellido = H000Y2_A51UsuarioApellido[0];
            A1EstadoID = H000Y2_A1EstadoID[0];
            A2EstadoDescripcion = H000Y2_A2EstadoDescripcion[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpusuariods_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A29UsuarioID), 9, 0) , StringUtil.PadR( "%" + AV65Wpusuariods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV65Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV65Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV65Wpusuariods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A2EstadoDescripcion , StringUtil.PadR( "%" + AV65Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "gx_emptyitemtext", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A67UsuarioProducto)) ) || ( StringUtil.Like( context.GetMessage( "auto y camioneta", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A67UsuarioProducto, "Auto y Camioneta") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "auto y camioneta/camión", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, "Auto y Camioneta/Camión") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "camión", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, "Camión") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "empleado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A67UsuarioProducto, "Empleado") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otr/camión", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, "OTR/Camión") == 0 ) ) ||
            ( StringUtil.Like( A82UsuarioNoCuentaBROXEL , StringUtil.PadR( "%" + AV65Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "gx_emptyitemtext", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
            ( StringUtil.Like( context.GetMessage( "super administrador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, "Super Administrador") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrador yokohama", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, "Administrador Yokohama") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "asesor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A40UsuarioRol, "Asesor") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "participante", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, "Participante") == 0 ) ) )
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

      protected void RF0Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E180Y2 ();
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
                                                 A67UsuarioProducto ,
                                                 AV76Wpusuariods_12_tfusuarioproducto_sels ,
                                                 A40UsuarioRol ,
                                                 AV79Wpusuariods_15_tfusuariorol_sels ,
                                                 AV66Wpusuariods_2_tfusuarioid ,
                                                 AV67Wpusuariods_3_tfusuarioid_to ,
                                                 AV69Wpusuariods_5_tfusuarionombrecompleto_sel ,
                                                 AV68Wpusuariods_4_tfusuarionombrecompleto ,
                                                 AV71Wpusuariods_7_tfusuariocorreo_sel ,
                                                 AV70Wpusuariods_6_tfusuariocorreo ,
                                                 AV72Wpusuariods_8_tfusuariocelular ,
                                                 AV73Wpusuariods_9_tfusuariocelular_to ,
                                                 AV75Wpusuariods_11_tfestadodescripcion_sel ,
                                                 AV74Wpusuariods_10_tfestadodescripcion ,
                                                 AV76Wpusuariods_12_tfusuarioproducto_sels.Count ,
                                                 AV78Wpusuariods_14_tfusuarionocuentabroxel_sel ,
                                                 AV77Wpusuariods_13_tfusuarionocuentabroxel ,
                                                 AV79Wpusuariods_15_tfusuariorol_sels.Count ,
                                                 A29UsuarioID ,
                                                 A30UsuarioNombre ,
                                                 A51UsuarioApellido ,
                                                 A31UsuarioCorreo ,
                                                 A64UsuarioCelular ,
                                                 A2EstadoDescripcion ,
                                                 A82UsuarioNoCuentaBROXEL ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 AV65Wpusuariods_1_filterfulltext ,
                                                 A52UsuarioNombreCompleto } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV68Wpusuariods_4_tfusuarionombrecompleto = StringUtil.Concat( StringUtil.RTrim( AV68Wpusuariods_4_tfusuarionombrecompleto), "%", "");
            lV70Wpusuariods_6_tfusuariocorreo = StringUtil.Concat( StringUtil.RTrim( AV70Wpusuariods_6_tfusuariocorreo), "%", "");
            lV74Wpusuariods_10_tfestadodescripcion = StringUtil.Concat( StringUtil.RTrim( AV74Wpusuariods_10_tfestadodescripcion), "%", "");
            lV77Wpusuariods_13_tfusuarionocuentabroxel = StringUtil.PadR( StringUtil.RTrim( AV77Wpusuariods_13_tfusuarionocuentabroxel), 20, "%");
            /* Using cursor H000Y3 */
            pr_default.execute(1, new Object[] {AV66Wpusuariods_2_tfusuarioid, AV67Wpusuariods_3_tfusuarioid_to, lV68Wpusuariods_4_tfusuarionombrecompleto, AV69Wpusuariods_5_tfusuarionombrecompleto_sel, lV70Wpusuariods_6_tfusuariocorreo, AV71Wpusuariods_7_tfusuariocorreo_sel, AV72Wpusuariods_8_tfusuariocelular, AV73Wpusuariods_9_tfusuariocelular_to, lV74Wpusuariods_10_tfestadodescripcion, AV75Wpusuariods_11_tfestadodescripcion_sel, lV77Wpusuariods_13_tfusuarionocuentabroxel, AV78Wpusuariods_14_tfusuarionocuentabroxel_sel});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A4CiudadID = H000Y3_A4CiudadID[0];
               n4CiudadID = H000Y3_n4CiudadID[0];
               A1EstadoID = H000Y3_A1EstadoID[0];
               A33UsuarioKey = H000Y3_A33UsuarioKey[0];
               A32UsuarioPass = H000Y3_A32UsuarioPass[0];
               A40UsuarioRol = H000Y3_A40UsuarioRol[0];
               A82UsuarioNoCuentaBROXEL = H000Y3_A82UsuarioNoCuentaBROXEL[0];
               A67UsuarioProducto = H000Y3_A67UsuarioProducto[0];
               n67UsuarioProducto = H000Y3_n67UsuarioProducto[0];
               A2EstadoDescripcion = H000Y3_A2EstadoDescripcion[0];
               A64UsuarioCelular = H000Y3_A64UsuarioCelular[0];
               A31UsuarioCorreo = H000Y3_A31UsuarioCorreo[0];
               A52UsuarioNombreCompleto = H000Y3_A52UsuarioNombreCompleto[0];
               A29UsuarioID = H000Y3_A29UsuarioID[0];
               A30UsuarioNombre = H000Y3_A30UsuarioNombre[0];
               A51UsuarioApellido = H000Y3_A51UsuarioApellido[0];
               A1EstadoID = H000Y3_A1EstadoID[0];
               A2EstadoDescripcion = H000Y3_A2EstadoDescripcion[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Wpusuariods_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A29UsuarioID), 9, 0) , StringUtil.PadR( "%" + AV65Wpusuariods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A52UsuarioNombreCompleto , StringUtil.PadR( "%" + AV65Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( A31UsuarioCorreo , StringUtil.PadR( "%" + AV65Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A64UsuarioCelular), 10, 0) , StringUtil.PadR( "%" + AV65Wpusuariods_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A2EstadoDescripcion , StringUtil.PadR( "%" + AV65Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "gx_emptyitemtext", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A67UsuarioProducto)) ) || ( StringUtil.Like( context.GetMessage( "auto y camioneta", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A67UsuarioProducto, "Auto y Camioneta") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "auto y camioneta/camión", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, "Auto y Camioneta/Camión") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "camión", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, "Camión") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "empleado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A67UsuarioProducto, "Empleado") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otr/camión", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A67UsuarioProducto, "OTR/Camión") == 0 ) ) ||
               ( StringUtil.Like( A82UsuarioNoCuentaBROXEL , StringUtil.PadR( "%" + AV65Wpusuariods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "gx_emptyitemtext", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && String.IsNullOrEmpty(StringUtil.RTrim( A40UsuarioRol)) ) ||
               ( StringUtil.Like( context.GetMessage( "super administrador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, "Super Administrador") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "administrador yokohama", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, "Administrador Yokohama") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "asesor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A40UsuarioRol, "Asesor") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "participante", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Wpusuariods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A40UsuarioRol, "Participante") == 0 ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E190Y2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 37;
            WB0Y0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0Y2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV64Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOROL", StringUtil.RTrim( AV49UsuarioRol));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOROL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49UsuarioRol, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV61UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOROL"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A40UsuarioRol, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9"), context));
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
         AV65Wpusuariods_1_filterfulltext = AV15FilterFullText;
         AV66Wpusuariods_2_tfusuarioid = AV24TFUsuarioID;
         AV67Wpusuariods_3_tfusuarioid_to = AV25TFUsuarioID_To;
         AV68Wpusuariods_4_tfusuarionombrecompleto = AV44TFUsuarioNombreCompleto;
         AV69Wpusuariods_5_tfusuarionombrecompleto_sel = AV45TFUsuarioNombreCompleto_Sel;
         AV70Wpusuariods_6_tfusuariocorreo = AV28TFUsuarioCorreo;
         AV71Wpusuariods_7_tfusuariocorreo_sel = AV29TFUsuarioCorreo_Sel;
         AV72Wpusuariods_8_tfusuariocelular = AV51TFUsuarioCelular;
         AV73Wpusuariods_9_tfusuariocelular_to = AV52TFUsuarioCelular_To;
         AV74Wpusuariods_10_tfestadodescripcion = AV53TFEstadoDescripcion;
         AV75Wpusuariods_11_tfestadodescripcion_sel = AV54TFEstadoDescripcion_Sel;
         AV76Wpusuariods_12_tfusuarioproducto_sels = AV56TFUsuarioProducto_Sels;
         AV77Wpusuariods_13_tfusuarionocuentabroxel = AV57TFUsuarioNoCuentaBROXEL;
         AV78Wpusuariods_14_tfusuarionocuentabroxel_sel = AV58TFUsuarioNoCuentaBROXEL_Sel;
         AV79Wpusuariods_15_tfusuariorol_sels = AV42TFUsuarioRol_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV64Pgmname, AV15FilterFullText, AV24TFUsuarioID, AV25TFUsuarioID_To, AV44TFUsuarioNombreCompleto, AV45TFUsuarioNombreCompleto_Sel, AV28TFUsuarioCorreo, AV29TFUsuarioCorreo_Sel, AV51TFUsuarioCelular, AV52TFUsuarioCelular_To, AV53TFEstadoDescripcion, AV54TFEstadoDescripcion_Sel, AV56TFUsuarioProducto_Sels, AV57TFUsuarioNoCuentaBROXEL, AV58TFUsuarioNoCuentaBROXEL_Sel, AV42TFUsuarioRol_Sels, AV49UsuarioRol, AV61UsuarioID, A11DistribuidorDescripcion, A93FacturaCompleta, A69FacturaID, A73FacturaFechaFactura) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV65Wpusuariods_1_filterfulltext = AV15FilterFullText;
         AV66Wpusuariods_2_tfusuarioid = AV24TFUsuarioID;
         AV67Wpusuariods_3_tfusuarioid_to = AV25TFUsuarioID_To;
         AV68Wpusuariods_4_tfusuarionombrecompleto = AV44TFUsuarioNombreCompleto;
         AV69Wpusuariods_5_tfusuarionombrecompleto_sel = AV45TFUsuarioNombreCompleto_Sel;
         AV70Wpusuariods_6_tfusuariocorreo = AV28TFUsuarioCorreo;
         AV71Wpusuariods_7_tfusuariocorreo_sel = AV29TFUsuarioCorreo_Sel;
         AV72Wpusuariods_8_tfusuariocelular = AV51TFUsuarioCelular;
         AV73Wpusuariods_9_tfusuariocelular_to = AV52TFUsuarioCelular_To;
         AV74Wpusuariods_10_tfestadodescripcion = AV53TFEstadoDescripcion;
         AV75Wpusuariods_11_tfestadodescripcion_sel = AV54TFEstadoDescripcion_Sel;
         AV76Wpusuariods_12_tfusuarioproducto_sels = AV56TFUsuarioProducto_Sels;
         AV77Wpusuariods_13_tfusuarionocuentabroxel = AV57TFUsuarioNoCuentaBROXEL;
         AV78Wpusuariods_14_tfusuarionocuentabroxel_sel = AV58TFUsuarioNoCuentaBROXEL_Sel;
         AV79Wpusuariods_15_tfusuariorol_sels = AV42TFUsuarioRol_Sels;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV64Pgmname, AV15FilterFullText, AV24TFUsuarioID, AV25TFUsuarioID_To, AV44TFUsuarioNombreCompleto, AV45TFUsuarioNombreCompleto_Sel, AV28TFUsuarioCorreo, AV29TFUsuarioCorreo_Sel, AV51TFUsuarioCelular, AV52TFUsuarioCelular_To, AV53TFEstadoDescripcion, AV54TFEstadoDescripcion_Sel, AV56TFUsuarioProducto_Sels, AV57TFUsuarioNoCuentaBROXEL, AV58TFUsuarioNoCuentaBROXEL_Sel, AV42TFUsuarioRol_Sels, AV49UsuarioRol, AV61UsuarioID, A11DistribuidorDescripcion, A93FacturaCompleta, A69FacturaID, A73FacturaFechaFactura) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV65Wpusuariods_1_filterfulltext = AV15FilterFullText;
         AV66Wpusuariods_2_tfusuarioid = AV24TFUsuarioID;
         AV67Wpusuariods_3_tfusuarioid_to = AV25TFUsuarioID_To;
         AV68Wpusuariods_4_tfusuarionombrecompleto = AV44TFUsuarioNombreCompleto;
         AV69Wpusuariods_5_tfusuarionombrecompleto_sel = AV45TFUsuarioNombreCompleto_Sel;
         AV70Wpusuariods_6_tfusuariocorreo = AV28TFUsuarioCorreo;
         AV71Wpusuariods_7_tfusuariocorreo_sel = AV29TFUsuarioCorreo_Sel;
         AV72Wpusuariods_8_tfusuariocelular = AV51TFUsuarioCelular;
         AV73Wpusuariods_9_tfusuariocelular_to = AV52TFUsuarioCelular_To;
         AV74Wpusuariods_10_tfestadodescripcion = AV53TFEstadoDescripcion;
         AV75Wpusuariods_11_tfestadodescripcion_sel = AV54TFEstadoDescripcion_Sel;
         AV76Wpusuariods_12_tfusuarioproducto_sels = AV56TFUsuarioProducto_Sels;
         AV77Wpusuariods_13_tfusuarionocuentabroxel = AV57TFUsuarioNoCuentaBROXEL;
         AV78Wpusuariods_14_tfusuarionocuentabroxel_sel = AV58TFUsuarioNoCuentaBROXEL_Sel;
         AV79Wpusuariods_15_tfusuariorol_sels = AV42TFUsuarioRol_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV64Pgmname, AV15FilterFullText, AV24TFUsuarioID, AV25TFUsuarioID_To, AV44TFUsuarioNombreCompleto, AV45TFUsuarioNombreCompleto_Sel, AV28TFUsuarioCorreo, AV29TFUsuarioCorreo_Sel, AV51TFUsuarioCelular, AV52TFUsuarioCelular_To, AV53TFEstadoDescripcion, AV54TFEstadoDescripcion_Sel, AV56TFUsuarioProducto_Sels, AV57TFUsuarioNoCuentaBROXEL, AV58TFUsuarioNoCuentaBROXEL_Sel, AV42TFUsuarioRol_Sels, AV49UsuarioRol, AV61UsuarioID, A11DistribuidorDescripcion, A93FacturaCompleta, A69FacturaID, A73FacturaFechaFactura) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV65Wpusuariods_1_filterfulltext = AV15FilterFullText;
         AV66Wpusuariods_2_tfusuarioid = AV24TFUsuarioID;
         AV67Wpusuariods_3_tfusuarioid_to = AV25TFUsuarioID_To;
         AV68Wpusuariods_4_tfusuarionombrecompleto = AV44TFUsuarioNombreCompleto;
         AV69Wpusuariods_5_tfusuarionombrecompleto_sel = AV45TFUsuarioNombreCompleto_Sel;
         AV70Wpusuariods_6_tfusuariocorreo = AV28TFUsuarioCorreo;
         AV71Wpusuariods_7_tfusuariocorreo_sel = AV29TFUsuarioCorreo_Sel;
         AV72Wpusuariods_8_tfusuariocelular = AV51TFUsuarioCelular;
         AV73Wpusuariods_9_tfusuariocelular_to = AV52TFUsuarioCelular_To;
         AV74Wpusuariods_10_tfestadodescripcion = AV53TFEstadoDescripcion;
         AV75Wpusuariods_11_tfestadodescripcion_sel = AV54TFEstadoDescripcion_Sel;
         AV76Wpusuariods_12_tfusuarioproducto_sels = AV56TFUsuarioProducto_Sels;
         AV77Wpusuariods_13_tfusuarionocuentabroxel = AV57TFUsuarioNoCuentaBROXEL;
         AV78Wpusuariods_14_tfusuarionocuentabroxel_sel = AV58TFUsuarioNoCuentaBROXEL_Sel;
         AV79Wpusuariods_15_tfusuariorol_sels = AV42TFUsuarioRol_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV64Pgmname, AV15FilterFullText, AV24TFUsuarioID, AV25TFUsuarioID_To, AV44TFUsuarioNombreCompleto, AV45TFUsuarioNombreCompleto_Sel, AV28TFUsuarioCorreo, AV29TFUsuarioCorreo_Sel, AV51TFUsuarioCelular, AV52TFUsuarioCelular_To, AV53TFEstadoDescripcion, AV54TFEstadoDescripcion_Sel, AV56TFUsuarioProducto_Sels, AV57TFUsuarioNoCuentaBROXEL, AV58TFUsuarioNoCuentaBROXEL_Sel, AV42TFUsuarioRol_Sels, AV49UsuarioRol, AV61UsuarioID, A11DistribuidorDescripcion, A93FacturaCompleta, A69FacturaID, A73FacturaFechaFactura) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV65Wpusuariods_1_filterfulltext = AV15FilterFullText;
         AV66Wpusuariods_2_tfusuarioid = AV24TFUsuarioID;
         AV67Wpusuariods_3_tfusuarioid_to = AV25TFUsuarioID_To;
         AV68Wpusuariods_4_tfusuarionombrecompleto = AV44TFUsuarioNombreCompleto;
         AV69Wpusuariods_5_tfusuarionombrecompleto_sel = AV45TFUsuarioNombreCompleto_Sel;
         AV70Wpusuariods_6_tfusuariocorreo = AV28TFUsuarioCorreo;
         AV71Wpusuariods_7_tfusuariocorreo_sel = AV29TFUsuarioCorreo_Sel;
         AV72Wpusuariods_8_tfusuariocelular = AV51TFUsuarioCelular;
         AV73Wpusuariods_9_tfusuariocelular_to = AV52TFUsuarioCelular_To;
         AV74Wpusuariods_10_tfestadodescripcion = AV53TFEstadoDescripcion;
         AV75Wpusuariods_11_tfestadodescripcion_sel = AV54TFEstadoDescripcion_Sel;
         AV76Wpusuariods_12_tfusuarioproducto_sels = AV56TFUsuarioProducto_Sels;
         AV77Wpusuariods_13_tfusuarionocuentabroxel = AV57TFUsuarioNoCuentaBROXEL;
         AV78Wpusuariods_14_tfusuarionocuentabroxel_sel = AV58TFUsuarioNoCuentaBROXEL_Sel;
         AV79Wpusuariods_15_tfusuariorol_sels = AV42TFUsuarioRol_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV64Pgmname, AV15FilterFullText, AV24TFUsuarioID, AV25TFUsuarioID_To, AV44TFUsuarioNombreCompleto, AV45TFUsuarioNombreCompleto_Sel, AV28TFUsuarioCorreo, AV29TFUsuarioCorreo_Sel, AV51TFUsuarioCelular, AV52TFUsuarioCelular_To, AV53TFEstadoDescripcion, AV54TFEstadoDescripcion_Sel, AV56TFUsuarioProducto_Sels, AV57TFUsuarioNoCuentaBROXEL, AV58TFUsuarioNoCuentaBROXEL_Sel, AV42TFUsuarioRol_Sels, AV49UsuarioRol, AV61UsuarioID, A11DistribuidorDescripcion, A93FacturaCompleta, A69FacturaID, A73FacturaFechaFactura) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV64Pgmname = "WPUsuario";
         edtavDistribuidor_Enabled = 0;
         edtavNofacturas_Enabled = 0;
         edtavFechaultimafactura_Enabled = 0;
         edtavPass_Enabled = 0;
         edtUsuarioID_Enabled = 0;
         edtUsuarioNombreCompleto_Enabled = 0;
         edtUsuarioCorreo_Enabled = 0;
         edtUsuarioCelular_Enabled = 0;
         edtEstadoDescripcion_Enabled = 0;
         cmbUsuarioProducto.Enabled = 0;
         edtUsuarioNoCuentaBROXEL_Enabled = 0;
         cmbUsuarioRol.Enabled = 0;
         edtUsuarioPass_Enabled = 0;
         edtUsuarioKey_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E170Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV21ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV34DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV18ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV36GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV37GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV38GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
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
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E170Y2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E170Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV46UsuarioJSON = AV47WebSession.Get(context.GetMessage( "Usuario", ""));
         AV48SDTUsuario.FromJSonString(AV46UsuarioJSON, null);
         AV49UsuarioRol = AV48SDTUsuario.gxTpr_Usuariorol;
         AssignAttri("", false, "AV49UsuarioRol", AV49UsuarioRol);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOROL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49UsuarioRol, "")), context));
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
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
         Form.Caption = context.GetMessage( " Usuario", "");
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
         if ( AV12OrderedBy < 1 )
         {
            AV12OrderedBy = 1;
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV34DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV34DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E180Y2( )
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
         if ( StringUtil.StrCmp(AV20Session.Get("WPUsuarioColumnsSelector"), "") != 0 )
         {
            AV16ColumnsSelectorXML = AV20Session.Get("WPUsuarioColumnsSelector");
            AV18ColumnsSelector.FromXml(AV16ColumnsSelectorXML, null, "", "");
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
         edtUsuarioID_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtUsuarioID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioID_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtUsuarioNombreCompleto_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtUsuarioNombreCompleto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombreCompleto_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtUsuarioCorreo_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtUsuarioCorreo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioCorreo_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtUsuarioCelular_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtUsuarioCelular_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioCelular_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavDistribuidor_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavDistribuidor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDistribuidor_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtEstadoDescripcion_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEstadoDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadoDescripcion_Visible), 5, 0), !bGXsfl_37_Refreshing);
         cmbUsuarioProducto.Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbUsuarioProducto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbUsuarioProducto.Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavNofacturas_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavNofacturas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNofacturas_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavFechaultimafactura_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavFechaultimafactura_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFechaultimafactura_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtUsuarioNoCuentaBROXEL_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtUsuarioNoCuentaBROXEL_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNoCuentaBROXEL_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavPass_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(11)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavPass_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPass_Visible), 5, 0), !bGXsfl_37_Refreshing);
         cmbUsuarioRol.Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(12)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbUsuarioRol_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbUsuarioRol.Visible), 5, 0), !bGXsfl_37_Refreshing);
         AV36GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV36GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV36GridCurrentPage), 10, 0));
         AV37GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV37GridPageCount", StringUtil.LTrimStr( (decimal)(AV37GridPageCount), 10, 0));
         GXt_char2 = AV38GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV64Pgmname, out  GXt_char2) ;
         AV38GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV38GridAppliedFilters", AV38GridAppliedFilters);
         AV65Wpusuariods_1_filterfulltext = AV15FilterFullText;
         AV66Wpusuariods_2_tfusuarioid = AV24TFUsuarioID;
         AV67Wpusuariods_3_tfusuarioid_to = AV25TFUsuarioID_To;
         AV68Wpusuariods_4_tfusuarionombrecompleto = AV44TFUsuarioNombreCompleto;
         AV69Wpusuariods_5_tfusuarionombrecompleto_sel = AV45TFUsuarioNombreCompleto_Sel;
         AV70Wpusuariods_6_tfusuariocorreo = AV28TFUsuarioCorreo;
         AV71Wpusuariods_7_tfusuariocorreo_sel = AV29TFUsuarioCorreo_Sel;
         AV72Wpusuariods_8_tfusuariocelular = AV51TFUsuarioCelular;
         AV73Wpusuariods_9_tfusuariocelular_to = AV52TFUsuarioCelular_To;
         AV74Wpusuariods_10_tfestadodescripcion = AV53TFEstadoDescripcion;
         AV75Wpusuariods_11_tfestadodescripcion_sel = AV54TFEstadoDescripcion_Sel;
         AV76Wpusuariods_12_tfusuarioproducto_sels = AV56TFUsuarioProducto_Sels;
         AV77Wpusuariods_13_tfusuarionocuentabroxel = AV57TFUsuarioNoCuentaBROXEL;
         AV78Wpusuariods_14_tfusuarionocuentabroxel_sel = AV58TFUsuarioNoCuentaBROXEL_Sel;
         AV79Wpusuariods_15_tfusuariorol_sels = AV42TFUsuarioRol_Sels;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E120Y2( )
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
            AV35PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV35PageToGo) ;
         }
      }

      protected void E130Y2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E140Y2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioID") == 0 )
            {
               AV24TFUsuarioID = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24TFUsuarioID", StringUtil.LTrimStr( (decimal)(AV24TFUsuarioID), 9, 0));
               AV25TFUsuarioID_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFUsuarioID_To", StringUtil.LTrimStr( (decimal)(AV25TFUsuarioID_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioNombreCompleto") == 0 )
            {
               AV44TFUsuarioNombreCompleto = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV44TFUsuarioNombreCompleto", AV44TFUsuarioNombreCompleto);
               AV45TFUsuarioNombreCompleto_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV45TFUsuarioNombreCompleto_Sel", AV45TFUsuarioNombreCompleto_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioCorreo") == 0 )
            {
               AV28TFUsuarioCorreo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV28TFUsuarioCorreo", AV28TFUsuarioCorreo);
               AV29TFUsuarioCorreo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFUsuarioCorreo_Sel", AV29TFUsuarioCorreo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioCelular") == 0 )
            {
               AV51TFUsuarioCelular = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV51TFUsuarioCelular", StringUtil.LTrimStr( (decimal)(AV51TFUsuarioCelular), 10, 0));
               AV52TFUsuarioCelular_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV52TFUsuarioCelular_To", StringUtil.LTrimStr( (decimal)(AV52TFUsuarioCelular_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstadoDescripcion") == 0 )
            {
               AV53TFEstadoDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV53TFEstadoDescripcion", AV53TFEstadoDescripcion);
               AV54TFEstadoDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV54TFEstadoDescripcion_Sel", AV54TFEstadoDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioProducto") == 0 )
            {
               AV55TFUsuarioProducto_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV55TFUsuarioProducto_SelsJson", AV55TFUsuarioProducto_SelsJson);
               AV56TFUsuarioProducto_Sels.FromJSonString(AV55TFUsuarioProducto_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioNoCuentaBROXEL") == 0 )
            {
               AV57TFUsuarioNoCuentaBROXEL = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV57TFUsuarioNoCuentaBROXEL", AV57TFUsuarioNoCuentaBROXEL);
               AV58TFUsuarioNoCuentaBROXEL_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV58TFUsuarioNoCuentaBROXEL_Sel", AV58TFUsuarioNoCuentaBROXEL_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UsuarioRol") == 0 )
            {
               AV41TFUsuarioRol_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV41TFUsuarioRol_SelsJson", AV41TFUsuarioRol_SelsJson);
               AV42TFUsuarioRol_Sels.FromJSonString(AV41TFUsuarioRol_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42TFUsuarioRol_Sels", AV42TFUsuarioRol_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV56TFUsuarioProducto_Sels", AV56TFUsuarioProducto_Sels);
      }

      private void E190Y2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV50PuedeVer = false;
            new puedever(context ).execute(  AV49UsuarioRol, out  AV50PuedeVer) ;
            if ( AV50PuedeVer )
            {
               AV40Pass = Decrypt64( A32UsuarioPass, A33UsuarioKey);
               AssignAttri("", false, edtavPass_Internalname, AV40Pass);
            }
            else
            {
               AV40Pass = "*******";
               AssignAttri("", false, edtavPass_Internalname, AV40Pass);
            }
            AV61UsuarioID = A29UsuarioID;
            AssignAttri("", false, "AV61UsuarioID", StringUtil.LTrimStr( (decimal)(AV61UsuarioID), 9, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV61UsuarioID), "ZZZZZZZZ9"), context));
            /* Execute user subroutine: 'CARGARDISTRIBUIDORES' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'CARGARNOFACTURAS' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'CARGARFECHAULTIMAFACTURA' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
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
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActions), 4, 0));
      }

      protected void E150Y2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV16ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV18ColumnsSelector.FromJSonString(AV16ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WPUsuarioColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV16ColumnsSelectorXML)) ? "" : AV18ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E110Y2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WPUsuarioFilters")) + "," + UrlEncode(StringUtil.RTrim(AV64Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WPUsuarioFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV23ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV22ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WPUsuarioFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
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
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV64Pgmname+"GridState",  AV22ManageFiltersXml) ;
               AV10GridState.FromXml(AV22ManageFiltersXml, null, "", "");
               AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
               AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV56TFUsuarioProducto_Sels", AV56TFUsuarioProducto_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42TFUsuarioRol_Sels", AV42TFUsuarioRol_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
      }

      protected void E200Y2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV39GridActions == 1 )
         {
            /* Execute user subroutine: 'DO USERACTION4' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV39GridActions == 2 )
         {
            /* Execute user subroutine: 'DO USERACTION2' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV39GridActions == 3 )
         {
            /* Execute user subroutine: 'DO USERACTION3' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV39GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV39GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E160Y2( )
      {
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpagregarusuario.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         context.PopUp(formatLink("wpagregarusuario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S162( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV18ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "UsuarioID",  "",  "ID",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "UsuarioNombreCompleto",  "",  "Nombre completo",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "UsuarioCorreo",  "",  "Correo",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "UsuarioCelular",  "",  "Número de celular",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "&Distribuidor",  "",  "Distribuidor",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "EstadoDescripcion",  "",  "Estado",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "UsuarioProducto",  "",  "Segmento",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "&NoFacturas",  "",  "Facturas registradas",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "&FechaUltimaFactura",  "",  "Fecha de última factura",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "UsuarioNoCuentaBROXEL",  "",  "No. Cuenta Broxel",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "&Pass",  "",  "Contraseña",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "UsuarioRol",  "",  "Rol",  true,  "") ;
         GXt_char2 = AV17UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WPUsuarioColumnsSelector", out  GXt_char2) ;
         AV17UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV17UserCustomValue)) ) )
         {
            AV19ColumnsSelectorAux.FromXml(AV17UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV19ColumnsSelectorAux, ref  AV18ColumnsSelector) ;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV21ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WPUsuarioFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV21ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S202( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV24TFUsuarioID = 0;
         AssignAttri("", false, "AV24TFUsuarioID", StringUtil.LTrimStr( (decimal)(AV24TFUsuarioID), 9, 0));
         AV25TFUsuarioID_To = 0;
         AssignAttri("", false, "AV25TFUsuarioID_To", StringUtil.LTrimStr( (decimal)(AV25TFUsuarioID_To), 9, 0));
         AV44TFUsuarioNombreCompleto = "";
         AssignAttri("", false, "AV44TFUsuarioNombreCompleto", AV44TFUsuarioNombreCompleto);
         AV45TFUsuarioNombreCompleto_Sel = "";
         AssignAttri("", false, "AV45TFUsuarioNombreCompleto_Sel", AV45TFUsuarioNombreCompleto_Sel);
         AV28TFUsuarioCorreo = "";
         AssignAttri("", false, "AV28TFUsuarioCorreo", AV28TFUsuarioCorreo);
         AV29TFUsuarioCorreo_Sel = "";
         AssignAttri("", false, "AV29TFUsuarioCorreo_Sel", AV29TFUsuarioCorreo_Sel);
         AV51TFUsuarioCelular = 0;
         AssignAttri("", false, "AV51TFUsuarioCelular", StringUtil.LTrimStr( (decimal)(AV51TFUsuarioCelular), 10, 0));
         AV52TFUsuarioCelular_To = 0;
         AssignAttri("", false, "AV52TFUsuarioCelular_To", StringUtil.LTrimStr( (decimal)(AV52TFUsuarioCelular_To), 10, 0));
         AV53TFEstadoDescripcion = "";
         AssignAttri("", false, "AV53TFEstadoDescripcion", AV53TFEstadoDescripcion);
         AV54TFEstadoDescripcion_Sel = "";
         AssignAttri("", false, "AV54TFEstadoDescripcion_Sel", AV54TFEstadoDescripcion_Sel);
         AV56TFUsuarioProducto_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV57TFUsuarioNoCuentaBROXEL = "";
         AssignAttri("", false, "AV57TFUsuarioNoCuentaBROXEL", AV57TFUsuarioNoCuentaBROXEL);
         AV58TFUsuarioNoCuentaBROXEL_Sel = "";
         AssignAttri("", false, "AV58TFUsuarioNoCuentaBROXEL_Sel", AV58TFUsuarioNoCuentaBROXEL_Sel);
         AV42TFUsuarioRol_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S222( )
      {
         /* 'DO USERACTION4' Routine */
         returnInSub = false;
         AV50PuedeVer = false;
         new puedeverpassword(context ).execute(  AV49UsuarioRol,  A40UsuarioRol, out  AV50PuedeVer) ;
         if ( AV50PuedeVer )
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

      protected void S232( )
      {
         /* 'DO USERACTION2' Routine */
         returnInSub = false;
         AV50PuedeVer = false;
         new puedeverpassword(context ).execute(  AV49UsuarioRol,  A40UsuarioRol, out  AV50PuedeVer) ;
         if ( AV50PuedeVer )
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

      protected void S242( )
      {
         /* 'DO USERACTION3' Routine */
         returnInSub = false;
         AV50PuedeVer = false;
         new puedeverpassword(context ).execute(  AV49UsuarioRol,  A40UsuarioRol, out  AV50PuedeVer) ;
         if ( AV50PuedeVer )
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
         if ( StringUtil.StrCmp(AV20Session.Get(AV64Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV64Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV20Session.Get(AV64Pgmname+"GridState"), null, "", "");
         }
         AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
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
         AV80GXV1 = 1;
         while ( AV80GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV80GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIOID") == 0 )
            {
               AV24TFUsuarioID = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24TFUsuarioID", StringUtil.LTrimStr( (decimal)(AV24TFUsuarioID), 9, 0));
               AV25TFUsuarioID_To = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFUsuarioID_To", StringUtil.LTrimStr( (decimal)(AV25TFUsuarioID_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO") == 0 )
            {
               AV44TFUsuarioNombreCompleto = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFUsuarioNombreCompleto", AV44TFUsuarioNombreCompleto);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIONOMBRECOMPLETO_SEL") == 0 )
            {
               AV45TFUsuarioNombreCompleto_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFUsuarioNombreCompleto_Sel", AV45TFUsuarioNombreCompleto_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIOCORREO") == 0 )
            {
               AV28TFUsuarioCorreo = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFUsuarioCorreo", AV28TFUsuarioCorreo);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIOCORREO_SEL") == 0 )
            {
               AV29TFUsuarioCorreo_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFUsuarioCorreo_Sel", AV29TFUsuarioCorreo_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIOCELULAR") == 0 )
            {
               AV51TFUsuarioCelular = (long)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV51TFUsuarioCelular", StringUtil.LTrimStr( (decimal)(AV51TFUsuarioCelular), 10, 0));
               AV52TFUsuarioCelular_To = (long)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV52TFUsuarioCelular_To", StringUtil.LTrimStr( (decimal)(AV52TFUsuarioCelular_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFESTADODESCRIPCION") == 0 )
            {
               AV53TFEstadoDescripcion = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV53TFEstadoDescripcion", AV53TFEstadoDescripcion);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFESTADODESCRIPCION_SEL") == 0 )
            {
               AV54TFEstadoDescripcion_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFEstadoDescripcion_Sel", AV54TFEstadoDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIOPRODUCTO_SEL") == 0 )
            {
               AV55TFUsuarioProducto_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFUsuarioProducto_SelsJson", AV55TFUsuarioProducto_SelsJson);
               AV56TFUsuarioProducto_Sels.FromJSonString(AV55TFUsuarioProducto_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIONOCUENTABROXEL") == 0 )
            {
               AV57TFUsuarioNoCuentaBROXEL = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV57TFUsuarioNoCuentaBROXEL", AV57TFUsuarioNoCuentaBROXEL);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIONOCUENTABROXEL_SEL") == 0 )
            {
               AV58TFUsuarioNoCuentaBROXEL_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV58TFUsuarioNoCuentaBROXEL_Sel", AV58TFUsuarioNoCuentaBROXEL_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUSUARIOROL_SEL") == 0 )
            {
               AV41TFUsuarioRol_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFUsuarioRol_SelsJson", AV41TFUsuarioRol_SelsJson);
               AV42TFUsuarioRol_Sels.FromJSonString(AV41TFUsuarioRol_SelsJson, null);
            }
            AV80GXV1 = (int)(AV80GXV1+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFUsuarioNombreCompleto_Sel)),  AV45TFUsuarioNombreCompleto_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFUsuarioCorreo_Sel)),  AV29TFUsuarioCorreo_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFEstadoDescripcion_Sel)),  AV54TFEstadoDescripcion_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  (AV56TFUsuarioProducto_Sels.Count==0),  AV55TFUsuarioProducto_SelsJson, out  GXt_char6) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV58TFUsuarioNoCuentaBROXEL_Sel)),  AV58TFUsuarioNoCuentaBROXEL_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  (AV42TFUsuarioRol_Sels.Count==0),  AV41TFUsuarioRol_SelsJson, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char4+"|||"+GXt_char5+"|"+GXt_char6+"|||"+GXt_char7+"||"+GXt_char8;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFUsuarioNombreCompleto)),  AV44TFUsuarioNombreCompleto, out  GXt_char8) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFUsuarioCorreo)),  AV28TFUsuarioCorreo, out  GXt_char7) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV53TFEstadoDescripcion)),  AV53TFEstadoDescripcion, out  GXt_char6) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV57TFUsuarioNoCuentaBROXEL)),  AV57TFUsuarioNoCuentaBROXEL, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = ((0==AV24TFUsuarioID) ? "" : StringUtil.Str( (decimal)(AV24TFUsuarioID), 9, 0))+"|"+GXt_char8+"|"+GXt_char7+"|"+((0==AV51TFUsuarioCelular) ? "" : StringUtil.Str( (decimal)(AV51TFUsuarioCelular), 10, 0))+"||"+GXt_char6+"||||"+GXt_char5+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV25TFUsuarioID_To) ? "" : StringUtil.Str( (decimal)(AV25TFUsuarioID_To), 9, 0))+"|||"+((0==AV52TFUsuarioCelular_To) ? "" : StringUtil.Str( (decimal)(AV52TFUsuarioCelular_To), 10, 0))+"||||||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV20Session.Get(AV64Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFUSUARIOID",  context.GetMessage( "ID", ""),  !((0==AV24TFUsuarioID)&&(0==AV25TFUsuarioID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV24TFUsuarioID), 9, 0)),  ((0==AV24TFUsuarioID) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV24TFUsuarioID), "ZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV25TFUsuarioID_To), 9, 0)),  ((0==AV25TFUsuarioID_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV25TFUsuarioID_To), "ZZZZZZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFUSUARIONOMBRECOMPLETO",  context.GetMessage( "Nombre completo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFUsuarioNombreCompleto)),  0,  AV44TFUsuarioNombreCompleto,  AV44TFUsuarioNombreCompleto,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFUsuarioNombreCompleto_Sel)),  AV45TFUsuarioNombreCompleto_Sel,  AV45TFUsuarioNombreCompleto_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFUSUARIOCORREO",  context.GetMessage( "Correo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFUsuarioCorreo)),  0,  AV28TFUsuarioCorreo,  AV28TFUsuarioCorreo,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFUsuarioCorreo_Sel)),  AV29TFUsuarioCorreo_Sel,  AV29TFUsuarioCorreo_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFUSUARIOCELULAR",  context.GetMessage( "Número de celular", ""),  !((0==AV51TFUsuarioCelular)&&(0==AV52TFUsuarioCelular_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV51TFUsuarioCelular), 10, 0)),  ((0==AV51TFUsuarioCelular) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV51TFUsuarioCelular), "ZZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV52TFUsuarioCelular_To), 10, 0)),  ((0==AV52TFUsuarioCelular_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV52TFUsuarioCelular_To), "ZZZZZZZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFESTADODESCRIPCION",  context.GetMessage( "Estado", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV53TFEstadoDescripcion)),  0,  AV53TFEstadoDescripcion,  AV53TFEstadoDescripcion,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFEstadoDescripcion_Sel)),  AV54TFEstadoDescripcion_Sel,  AV54TFEstadoDescripcion_Sel) ;
         AV43AuxText = ((AV56TFUsuarioProducto_Sels.Count==1) ? "["+((string)AV56TFUsuarioProducto_Sels.Item(1))+"]" : context.GetMessage( "WWP_FilterValueDescription_MultipleValues", ""));
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFUSUARIOPRODUCTO_SEL",  context.GetMessage( "Segmento", ""),  !(AV56TFUsuarioProducto_Sels.Count==0),  0,  AV56TFUsuarioProducto_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV43AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV43AuxText, "[Auto y Camioneta]", context.GetMessage( "Auto y Camioneta", "")), "[Auto y Camioneta/Camión]", context.GetMessage( "Auto y Camioneta/Camión", "")), "[Camión]", context.GetMessage( "Camión", "")), "[Empleado]", context.GetMessage( "Empleado", "")), "[OTR/Camión]", context.GetMessage( "OTR/Camión", ""))),  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFUSUARIONOCUENTABROXEL",  context.GetMessage( "No. Cuenta Broxel", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV57TFUsuarioNoCuentaBROXEL)),  0,  AV57TFUsuarioNoCuentaBROXEL,  AV57TFUsuarioNoCuentaBROXEL,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV58TFUsuarioNoCuentaBROXEL_Sel)),  AV58TFUsuarioNoCuentaBROXEL_Sel,  AV58TFUsuarioNoCuentaBROXEL_Sel) ;
         AV43AuxText = ((AV42TFUsuarioRol_Sels.Count==1) ? "["+AV42TFUsuarioRol_Sels.GetString(1)+"]" : context.GetMessage( "WWP_FilterValueDescription_MultipleValues", ""));
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFUSUARIOROL_SEL",  context.GetMessage( "Rol", ""),  !(AV42TFUsuarioRol_Sels.Count==0),  0,  AV42TFUsuarioRol_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV43AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV43AuxText, "[Super Administrador]", context.GetMessage( "Super Administrador", "")), "[Administrador Yokohama]", context.GetMessage( "Administrador Yokohama", "")), "[Asesor]", context.GetMessage( "Asesor", "")), "[Participante]", context.GetMessage( "Participante", ""))),  false,  "",  "") ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV64Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV64Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Usuario";
         AV20Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void S172( )
      {
         /* 'CARGARDISTRIBUIDORES' Routine */
         returnInSub = false;
         AV59Distribuidor = "";
         AssignAttri("", false, edtavDistribuidor_Internalname, AV59Distribuidor);
         AV60EsPrimera = true;
         AV81GXLvl512 = 0;
         /* Using cursor H000Y4 */
         pr_default.execute(2, new Object[] {AV61UsuarioID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A10DistribuidorID = H000Y4_A10DistribuidorID[0];
            A29UsuarioID = H000Y4_A29UsuarioID[0];
            A11DistribuidorDescripcion = H000Y4_A11DistribuidorDescripcion[0];
            A11DistribuidorDescripcion = H000Y4_A11DistribuidorDescripcion[0];
            AV81GXLvl512 = 1;
            if ( AV60EsPrimera )
            {
               AV59Distribuidor += A11DistribuidorDescripcion;
               AssignAttri("", false, edtavDistribuidor_Internalname, AV59Distribuidor);
               AV60EsPrimera = false;
            }
            else
            {
               AV59Distribuidor += ", " + A11DistribuidorDescripcion;
               AssignAttri("", false, edtavDistribuidor_Internalname, AV59Distribuidor);
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( AV81GXLvl512 == 0 )
         {
            AV59Distribuidor = context.GetMessage( "Sin distribuidores asignados", "");
            AssignAttri("", false, edtavDistribuidor_Internalname, AV59Distribuidor);
         }
      }

      protected void S182( )
      {
         /* 'CARGARNOFACTURAS' Routine */
         returnInSub = false;
         AV62NoFacturas = 0;
         AssignAttri("", false, edtavNofacturas_Internalname, StringUtil.LTrimStr( (decimal)(AV62NoFacturas), 4, 0));
         /* Optimized group. */
         /* Using cursor H000Y5 */
         pr_default.execute(3, new Object[] {AV61UsuarioID});
         cV62NoFacturas = H000Y5_AV62NoFacturas[0];
         AssignAttri("", false, edtavNofacturas_Internalname, StringUtil.LTrimStr( (decimal)(cV62NoFacturas), 4, 0));
         pr_default.close(3);
         AV62NoFacturas = (short)(AV62NoFacturas+cV62NoFacturas*1);
         AssignAttri("", false, edtavNofacturas_Internalname, StringUtil.LTrimStr( (decimal)(AV62NoFacturas), 4, 0));
         /* End optimized group. */
      }

      protected void S192( )
      {
         /* 'CARGARFECHAULTIMAFACTURA' Routine */
         returnInSub = false;
         AV63FechaUltimaFactura = DateTime.MinValue;
         AssignAttri("", false, edtavFechaultimafactura_Internalname, context.localUtil.Format(AV63FechaUltimaFactura, "99/99/99"));
         /* Using cursor H000Y6 */
         pr_default.execute(4, new Object[] {AV61UsuarioID});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A93FacturaCompleta = H000Y6_A93FacturaCompleta[0];
            A29UsuarioID = H000Y6_A29UsuarioID[0];
            A73FacturaFechaFactura = H000Y6_A73FacturaFechaFactura[0];
            A69FacturaID = H000Y6_A69FacturaID[0];
            AV63FechaUltimaFactura = A73FacturaFechaFactura;
            AssignAttri("", false, edtavFechaultimafactura_Internalname, context.localUtil.Format(AV63FechaUltimaFactura, "99/99/99"));
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         PA0Y2( ) ;
         WS0Y2( ) ;
         WE0Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20265111131240", true, true);
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
         context.AddJavascriptSource("wpusuario.js", "?20265111131240", false, true);
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
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO_"+sGXsfl_37_idx;
         edtUsuarioCorreo_Internalname = "USUARIOCORREO_"+sGXsfl_37_idx;
         edtUsuarioCelular_Internalname = "USUARIOCELULAR_"+sGXsfl_37_idx;
         edtavDistribuidor_Internalname = "vDISTRIBUIDOR_"+sGXsfl_37_idx;
         edtEstadoDescripcion_Internalname = "ESTADODESCRIPCION_"+sGXsfl_37_idx;
         cmbUsuarioProducto_Internalname = "USUARIOPRODUCTO_"+sGXsfl_37_idx;
         edtavNofacturas_Internalname = "vNOFACTURAS_"+sGXsfl_37_idx;
         edtavFechaultimafactura_Internalname = "vFECHAULTIMAFACTURA_"+sGXsfl_37_idx;
         edtUsuarioNoCuentaBROXEL_Internalname = "USUARIONOCUENTABROXEL_"+sGXsfl_37_idx;
         edtavPass_Internalname = "vPASS_"+sGXsfl_37_idx;
         cmbUsuarioRol_Internalname = "USUARIOROL_"+sGXsfl_37_idx;
         edtUsuarioPass_Internalname = "USUARIOPASS_"+sGXsfl_37_idx;
         edtUsuarioKey_Internalname = "USUARIOKEY_"+sGXsfl_37_idx;
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtUsuarioID_Internalname = "USUARIOID_"+sGXsfl_37_fel_idx;
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO_"+sGXsfl_37_fel_idx;
         edtUsuarioCorreo_Internalname = "USUARIOCORREO_"+sGXsfl_37_fel_idx;
         edtUsuarioCelular_Internalname = "USUARIOCELULAR_"+sGXsfl_37_fel_idx;
         edtavDistribuidor_Internalname = "vDISTRIBUIDOR_"+sGXsfl_37_fel_idx;
         edtEstadoDescripcion_Internalname = "ESTADODESCRIPCION_"+sGXsfl_37_fel_idx;
         cmbUsuarioProducto_Internalname = "USUARIOPRODUCTO_"+sGXsfl_37_fel_idx;
         edtavNofacturas_Internalname = "vNOFACTURAS_"+sGXsfl_37_fel_idx;
         edtavFechaultimafactura_Internalname = "vFECHAULTIMAFACTURA_"+sGXsfl_37_fel_idx;
         edtUsuarioNoCuentaBROXEL_Internalname = "USUARIONOCUENTABROXEL_"+sGXsfl_37_fel_idx;
         edtavPass_Internalname = "vPASS_"+sGXsfl_37_fel_idx;
         cmbUsuarioRol_Internalname = "USUARIOROL_"+sGXsfl_37_fel_idx;
         edtUsuarioPass_Internalname = "USUARIOPASS_"+sGXsfl_37_fel_idx;
         edtUsuarioKey_Internalname = "USUARIOKEY_"+sGXsfl_37_fel_idx;
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB0Y0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtUsuarioID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtUsuarioID_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtUsuarioCorreo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioCorreo_Internalname,(string)A31UsuarioCorreo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A31UsuarioCorreo,(string)"",(string)"",(string)"",(string)edtUsuarioCorreo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtUsuarioCorreo_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDistribuidor_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDistribuidor_Internalname,(string)AV59Distribuidor,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDistribuidor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavDistribuidor_Visible,(int)edtavDistribuidor_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtEstadoDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoDescripcion_Internalname,(string)A2EstadoDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtEstadoDescripcion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbUsuarioProducto.Visible==0) ? "display:none;" : "")+"\">") ;
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
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbUsuarioProducto,(string)cmbUsuarioProducto_Internalname,StringUtil.RTrim( A67UsuarioProducto),(short)1,(string)cmbUsuarioProducto_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",cmbUsuarioProducto.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbUsuarioProducto.CurrentValue = StringUtil.RTrim( A67UsuarioProducto);
            AssignProp("", false, cmbUsuarioProducto_Internalname, "Values", (string)(cmbUsuarioProducto.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtavNofacturas_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNofacturas_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62NoFacturas), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavNofacturas_Enabled!=0) ? context.localUtil.Format( (decimal)(AV62NoFacturas), "ZZZ9") : context.localUtil.Format( (decimal)(AV62NoFacturas), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,45);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNofacturas_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavNofacturas_Visible,(int)edtavNofacturas_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtavFechaultimafactura_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavFechaultimafactura_Internalname,context.localUtil.Format(AV63FechaUltimaFactura, "99/99/99"),context.localUtil.Format( AV63FechaUltimaFactura, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,46);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavFechaultimafactura_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavFechaultimafactura_Visible,(int)edtavFechaultimafactura_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtUsuarioNoCuentaBROXEL_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNoCuentaBROXEL_Internalname,StringUtil.RTrim( A82UsuarioNoCuentaBROXEL),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNoCuentaBROXEL_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtUsuarioNoCuentaBROXEL_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavPass_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPass_Internalname,StringUtil.RTrim( AV40Pass),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPass_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavPass_Visible,(int)edtavPass_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbUsuarioRol.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbUsuarioRol.ItemCount == 0 ) && isAjaxCallMode( ) )
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
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbUsuarioRol,(string)cmbUsuarioRol_Internalname,StringUtil.RTrim( A40UsuarioRol),(short)1,(string)cmbUsuarioRol_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbUsuarioRol.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbUsuarioRol.CurrentValue = StringUtil.RTrim( A40UsuarioRol);
            AssignProp("", false, cmbUsuarioRol_Internalname, "Values", (string)(cmbUsuarioRol.ToJavascriptSource()), !bGXsfl_37_Refreshing);
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_37_idx + "',37)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_37_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV39GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV39GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_37_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            send_integrity_lvl_hashes0Y2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
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
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_37_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV39GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV39GridActions), 4, 0));
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtUsuarioID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtUsuarioNombreCompleto_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre completo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtUsuarioCorreo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Correo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtUsuarioCelular_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Número de celular", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDistribuidor_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Distribuidor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEstadoDescripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbUsuarioProducto.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Segmento", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavNofacturas_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Facturas registradas", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavFechaultimafactura_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha de última factura", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtUsuarioNoCuentaBROXEL_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "No. Cuenta Broxel", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavPass_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Contraseña", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbUsuarioRol.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rol", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioID_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A52UsuarioNombreCompleto));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioNombreCompleto_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A31UsuarioCorreo));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioCorreo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A64UsuarioCelular), 10, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioCelular_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV59Distribuidor));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDistribuidor_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDistribuidor_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A2EstadoDescripcion));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoDescripcion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A67UsuarioProducto));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbUsuarioProducto.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62NoFacturas), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNofacturas_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNofacturas_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(AV63FechaUltimaFactura, "99/99/99")));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFechaultimafactura_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFechaultimafactura_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A82UsuarioNoCuentaBROXEL)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioNoCuentaBROXEL_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV40Pass)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPass_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPass_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A40UsuarioRol)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbUsuarioRol.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A32UsuarioPass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A33UsuarioKey));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GridActions), 4, 0, ".", ""))));
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
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO";
         edtUsuarioCorreo_Internalname = "USUARIOCORREO";
         edtUsuarioCelular_Internalname = "USUARIOCELULAR";
         edtavDistribuidor_Internalname = "vDISTRIBUIDOR";
         edtEstadoDescripcion_Internalname = "ESTADODESCRIPCION";
         cmbUsuarioProducto_Internalname = "USUARIOPRODUCTO";
         edtavNofacturas_Internalname = "vNOFACTURAS";
         edtavFechaultimafactura_Internalname = "vFECHAULTIMAFACTURA";
         edtUsuarioNoCuentaBROXEL_Internalname = "USUARIONOCUENTABROXEL";
         edtavPass_Internalname = "vPASS";
         cmbUsuarioRol_Internalname = "USUARIOROL";
         edtUsuarioPass_Internalname = "USUARIOPASS";
         edtUsuarioKey_Internalname = "USUARIOKEY";
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
         edtUsuarioKey_Jsonclick = "";
         edtUsuarioPass_Jsonclick = "";
         cmbUsuarioRol_Jsonclick = "";
         edtavPass_Jsonclick = "";
         edtavPass_Enabled = 1;
         edtUsuarioNoCuentaBROXEL_Jsonclick = "";
         edtavFechaultimafactura_Jsonclick = "";
         edtavFechaultimafactura_Enabled = 1;
         edtavNofacturas_Jsonclick = "";
         edtavNofacturas_Enabled = 1;
         cmbUsuarioProducto_Jsonclick = "";
         edtEstadoDescripcion_Jsonclick = "";
         edtavDistribuidor_Jsonclick = "";
         edtavDistribuidor_Enabled = 1;
         edtUsuarioCelular_Jsonclick = "";
         edtUsuarioCorreo_Jsonclick = "";
         edtUsuarioNombreCompleto_Jsonclick = "";
         edtUsuarioID_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridNoBorder WorkWith";
         subGrid_Backcolorstyle = 0;
         cmbUsuarioRol.Visible = -1;
         edtavPass_Visible = -1;
         edtUsuarioNoCuentaBROXEL_Visible = -1;
         edtavFechaultimafactura_Visible = -1;
         edtavNofacturas_Visible = -1;
         cmbUsuarioProducto.Visible = -1;
         edtEstadoDescripcion_Visible = -1;
         edtavDistribuidor_Visible = -1;
         edtUsuarioCelular_Visible = -1;
         edtUsuarioCorreo_Visible = -1;
         edtUsuarioNombreCompleto_Visible = -1;
         edtUsuarioID_Visible = -1;
         edtUsuarioKey_Enabled = 0;
         edtUsuarioPass_Enabled = 0;
         cmbUsuarioRol.Enabled = 0;
         edtUsuarioNoCuentaBROXEL_Enabled = 0;
         cmbUsuarioProducto.Enabled = 0;
         edtEstadoDescripcion_Enabled = 0;
         edtUsuarioCelular_Enabled = 0;
         edtUsuarioCorreo_Enabled = 0;
         edtUsuarioNombreCompleto_Enabled = 0;
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
         Ddo_grid_Format = "9.0|||10.0||||||||";
         Ddo_grid_Datalistproc = "WPUsuarioGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||||Auto y Camioneta:Auto y Camioneta,Auto y Camioneta/Camión:Auto y Camioneta/Camión,Camión:Camión,Empleado:Empleado,OTR/Camión:OTR/Camión|||||Super Administrador:Super Administrador,Administrador Yokohama:Administrador Yokohama,Asesor:Asesor,Participante:Participante";
         Ddo_grid_Allowmultipleselection = "||||||T|||||T";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|||Dynamic|FixedValues|||Dynamic||FixedValues";
         Ddo_grid_Includedatalist = "|T|T|||T|T|||T||T";
         Ddo_grid_Filterisrange = "T|||T||||||||";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Numeric||Character||||Character||";
         Ddo_grid_Includefilter = "T|T|T|T||T||||T||";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T||T|T||T|T|||T||T";
         Ddo_grid_Columnssortvalues = "2||3|4||5|6|||7||8";
         Ddo_grid_Columnids = "0:UsuarioID|1:UsuarioNombreCompleto|2:UsuarioCorreo|3:UsuarioCelular|4:Distribuidor|5:EstadoDescripcion|6:UsuarioProducto|7:NoFacturas|8:FechaUltimaFactura|9:UsuarioNoCuentaBROXEL|10:Pass|11:UsuarioRol";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFUsuarioID","fld":"vTFUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV25TFUsuarioID_To","fld":"vTFUSUARIOID_TO","pic":"ZZZZZZZZ9"},{"av":"AV44TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV45TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV28TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV29TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV51TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV52TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV53TFEstadoDescripcion","fld":"vTFESTADODESCRIPCION"},{"av":"AV54TFEstadoDescripcion_Sel","fld":"vTFESTADODESCRIPCION_SEL"},{"av":"AV56TFUsuarioProducto_Sels","fld":"vTFUSUARIOPRODUCTO_SELS"},{"av":"AV57TFUsuarioNoCuentaBROXEL","fld":"vTFUSUARIONOCUENTABROXEL"},{"av":"AV58TFUsuarioNoCuentaBROXEL_Sel","fld":"vTFUSUARIONOCUENTABROXEL_SEL"},{"av":"AV42TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV49UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"AV61UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtUsuarioID_Visible","ctrl":"USUARIOID","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtUsuarioCorreo_Visible","ctrl":"USUARIOCORREO","prop":"Visible"},{"av":"edtUsuarioCelular_Visible","ctrl":"USUARIOCELULAR","prop":"Visible"},{"av":"edtavDistribuidor_Visible","ctrl":"vDISTRIBUIDOR","prop":"Visible"},{"av":"edtEstadoDescripcion_Visible","ctrl":"ESTADODESCRIPCION","prop":"Visible"},{"av":"cmbUsuarioProducto"},{"av":"edtavNofacturas_Visible","ctrl":"vNOFACTURAS","prop":"Visible"},{"av":"edtavFechaultimafactura_Visible","ctrl":"vFECHAULTIMAFACTURA","prop":"Visible"},{"av":"edtUsuarioNoCuentaBROXEL_Visible","ctrl":"USUARIONOCUENTABROXEL","prop":"Visible"},{"av":"edtavPass_Visible","ctrl":"vPASS","prop":"Visible"},{"av":"cmbUsuarioRol"},{"av":"AV36GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV37GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV38GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E120Y2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFUsuarioID","fld":"vTFUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV25TFUsuarioID_To","fld":"vTFUSUARIOID_TO","pic":"ZZZZZZZZ9"},{"av":"AV44TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV45TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV28TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV29TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV51TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV52TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV53TFEstadoDescripcion","fld":"vTFESTADODESCRIPCION"},{"av":"AV54TFEstadoDescripcion_Sel","fld":"vTFESTADODESCRIPCION_SEL"},{"av":"AV56TFUsuarioProducto_Sels","fld":"vTFUSUARIOPRODUCTO_SELS"},{"av":"AV57TFUsuarioNoCuentaBROXEL","fld":"vTFUSUARIONOCUENTABROXEL"},{"av":"AV58TFUsuarioNoCuentaBROXEL_Sel","fld":"vTFUSUARIONOCUENTABROXEL_SEL"},{"av":"AV42TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV49UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"AV61UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E130Y2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFUsuarioID","fld":"vTFUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV25TFUsuarioID_To","fld":"vTFUSUARIOID_TO","pic":"ZZZZZZZZ9"},{"av":"AV44TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV45TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV28TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV29TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV51TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV52TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV53TFEstadoDescripcion","fld":"vTFESTADODESCRIPCION"},{"av":"AV54TFEstadoDescripcion_Sel","fld":"vTFESTADODESCRIPCION_SEL"},{"av":"AV56TFUsuarioProducto_Sels","fld":"vTFUSUARIOPRODUCTO_SELS"},{"av":"AV57TFUsuarioNoCuentaBROXEL","fld":"vTFUSUARIONOCUENTABROXEL"},{"av":"AV58TFUsuarioNoCuentaBROXEL_Sel","fld":"vTFUSUARIONOCUENTABROXEL_SEL"},{"av":"AV42TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV49UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"AV61UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E140Y2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFUsuarioID","fld":"vTFUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV25TFUsuarioID_To","fld":"vTFUSUARIOID_TO","pic":"ZZZZZZZZ9"},{"av":"AV44TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV45TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV28TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV29TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV51TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV52TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV53TFEstadoDescripcion","fld":"vTFESTADODESCRIPCION"},{"av":"AV54TFEstadoDescripcion_Sel","fld":"vTFESTADODESCRIPCION_SEL"},{"av":"AV56TFUsuarioProducto_Sels","fld":"vTFUSUARIOPRODUCTO_SELS"},{"av":"AV57TFUsuarioNoCuentaBROXEL","fld":"vTFUSUARIONOCUENTABROXEL"},{"av":"AV58TFUsuarioNoCuentaBROXEL_Sel","fld":"vTFUSUARIONOCUENTABROXEL_SEL"},{"av":"AV42TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV49UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"AV61UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV41TFUsuarioRol_SelsJson","fld":"vTFUSUARIOROL_SELSJSON"},{"av":"AV42TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV57TFUsuarioNoCuentaBROXEL","fld":"vTFUSUARIONOCUENTABROXEL"},{"av":"AV58TFUsuarioNoCuentaBROXEL_Sel","fld":"vTFUSUARIONOCUENTABROXEL_SEL"},{"av":"AV55TFUsuarioProducto_SelsJson","fld":"vTFUSUARIOPRODUCTO_SELSJSON"},{"av":"AV56TFUsuarioProducto_Sels","fld":"vTFUSUARIOPRODUCTO_SELS"},{"av":"AV53TFEstadoDescripcion","fld":"vTFESTADODESCRIPCION"},{"av":"AV54TFEstadoDescripcion_Sel","fld":"vTFESTADODESCRIPCION_SEL"},{"av":"AV51TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV52TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV28TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV29TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV44TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV45TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV24TFUsuarioID","fld":"vTFUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV25TFUsuarioID_To","fld":"vTFUSUARIOID_TO","pic":"ZZZZZZZZ9"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E190Y2","iparms":[{"av":"AV49UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"A32UsuarioPass","fld":"USUARIOPASS"},{"av":"A33UsuarioKey","fld":"USUARIOKEY"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV61UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV40Pass","fld":"vPASS"},{"av":"AV61UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"cmbavGridactions"},{"av":"AV39GridActions","fld":"vGRIDACTIONS","pic":"ZZZ9"},{"av":"AV59Distribuidor","fld":"vDISTRIBUIDOR"},{"av":"AV62NoFacturas","fld":"vNOFACTURAS","pic":"ZZZ9"},{"av":"AV63FechaUltimaFactura","fld":"vFECHAULTIMAFACTURA"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E150Y2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFUsuarioID","fld":"vTFUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV25TFUsuarioID_To","fld":"vTFUSUARIOID_TO","pic":"ZZZZZZZZ9"},{"av":"AV44TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV45TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV28TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV29TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV51TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV52TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV53TFEstadoDescripcion","fld":"vTFESTADODESCRIPCION"},{"av":"AV54TFEstadoDescripcion_Sel","fld":"vTFESTADODESCRIPCION_SEL"},{"av":"AV56TFUsuarioProducto_Sels","fld":"vTFUSUARIOPRODUCTO_SELS"},{"av":"AV57TFUsuarioNoCuentaBROXEL","fld":"vTFUSUARIONOCUENTABROXEL"},{"av":"AV58TFUsuarioNoCuentaBROXEL_Sel","fld":"vTFUSUARIONOCUENTABROXEL_SEL"},{"av":"AV42TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV49UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"AV61UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA"},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtUsuarioID_Visible","ctrl":"USUARIOID","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtUsuarioCorreo_Visible","ctrl":"USUARIOCORREO","prop":"Visible"},{"av":"edtUsuarioCelular_Visible","ctrl":"USUARIOCELULAR","prop":"Visible"},{"av":"edtavDistribuidor_Visible","ctrl":"vDISTRIBUIDOR","prop":"Visible"},{"av":"edtEstadoDescripcion_Visible","ctrl":"ESTADODESCRIPCION","prop":"Visible"},{"av":"cmbUsuarioProducto"},{"av":"edtavNofacturas_Visible","ctrl":"vNOFACTURAS","prop":"Visible"},{"av":"edtavFechaultimafactura_Visible","ctrl":"vFECHAULTIMAFACTURA","prop":"Visible"},{"av":"edtUsuarioNoCuentaBROXEL_Visible","ctrl":"USUARIONOCUENTABROXEL","prop":"Visible"},{"av":"edtavPass_Visible","ctrl":"vPASS","prop":"Visible"},{"av":"cmbUsuarioRol"},{"av":"AV36GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV37GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV38GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E110Y2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFUsuarioID","fld":"vTFUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV25TFUsuarioID_To","fld":"vTFUSUARIOID_TO","pic":"ZZZZZZZZ9"},{"av":"AV44TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV45TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV28TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV29TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV51TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV52TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV53TFEstadoDescripcion","fld":"vTFESTADODESCRIPCION"},{"av":"AV54TFEstadoDescripcion_Sel","fld":"vTFESTADODESCRIPCION_SEL"},{"av":"AV56TFUsuarioProducto_Sels","fld":"vTFUSUARIOPRODUCTO_SELS"},{"av":"AV57TFUsuarioNoCuentaBROXEL","fld":"vTFUSUARIONOCUENTABROXEL"},{"av":"AV58TFUsuarioNoCuentaBROXEL_Sel","fld":"vTFUSUARIONOCUENTABROXEL_SEL"},{"av":"AV42TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV49UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"AV61UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV55TFUsuarioProducto_SelsJson","fld":"vTFUSUARIOPRODUCTO_SELSJSON"},{"av":"AV41TFUsuarioRol_SelsJson","fld":"vTFUSUARIOROL_SELSJSON"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFUsuarioID","fld":"vTFUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV25TFUsuarioID_To","fld":"vTFUSUARIOID_TO","pic":"ZZZZZZZZ9"},{"av":"AV44TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV45TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV28TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV29TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV51TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV52TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV53TFEstadoDescripcion","fld":"vTFESTADODESCRIPCION"},{"av":"AV54TFEstadoDescripcion_Sel","fld":"vTFESTADODESCRIPCION_SEL"},{"av":"AV56TFUsuarioProducto_Sels","fld":"vTFUSUARIOPRODUCTO_SELS"},{"av":"AV57TFUsuarioNoCuentaBROXEL","fld":"vTFUSUARIONOCUENTABROXEL"},{"av":"AV58TFUsuarioNoCuentaBROXEL_Sel","fld":"vTFUSUARIONOCUENTABROXEL_SEL"},{"av":"AV42TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV41TFUsuarioRol_SelsJson","fld":"vTFUSUARIOROL_SELSJSON"},{"av":"AV55TFUsuarioProducto_SelsJson","fld":"vTFUSUARIOPRODUCTO_SELSJSON"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtUsuarioID_Visible","ctrl":"USUARIOID","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtUsuarioCorreo_Visible","ctrl":"USUARIOCORREO","prop":"Visible"},{"av":"edtUsuarioCelular_Visible","ctrl":"USUARIOCELULAR","prop":"Visible"},{"av":"edtavDistribuidor_Visible","ctrl":"vDISTRIBUIDOR","prop":"Visible"},{"av":"edtEstadoDescripcion_Visible","ctrl":"ESTADODESCRIPCION","prop":"Visible"},{"av":"cmbUsuarioProducto"},{"av":"edtavNofacturas_Visible","ctrl":"vNOFACTURAS","prop":"Visible"},{"av":"edtavFechaultimafactura_Visible","ctrl":"vFECHAULTIMAFACTURA","prop":"Visible"},{"av":"edtUsuarioNoCuentaBROXEL_Visible","ctrl":"USUARIONOCUENTABROXEL","prop":"Visible"},{"av":"edtavPass_Visible","ctrl":"vPASS","prop":"Visible"},{"av":"cmbUsuarioRol"},{"av":"AV36GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV37GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV38GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VGRIDACTIONS.CLICK","""{"handler":"E200Y2","iparms":[{"av":"cmbavGridactions"},{"av":"AV39GridActions","fld":"vGRIDACTIONS","pic":"ZZZ9"},{"av":"AV49UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"cmbUsuarioRol"},{"av":"A40UsuarioRol","fld":"USUARIOROL","hsh":true},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFUsuarioID","fld":"vTFUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV25TFUsuarioID_To","fld":"vTFUSUARIOID_TO","pic":"ZZZZZZZZ9"},{"av":"AV44TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV45TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV28TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV29TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV51TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV52TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV53TFEstadoDescripcion","fld":"vTFESTADODESCRIPCION"},{"av":"AV54TFEstadoDescripcion_Sel","fld":"vTFESTADODESCRIPCION_SEL"},{"av":"AV56TFUsuarioProducto_Sels","fld":"vTFUSUARIOPRODUCTO_SELS"},{"av":"AV57TFUsuarioNoCuentaBROXEL","fld":"vTFUSUARIONOCUENTABROXEL"},{"av":"AV58TFUsuarioNoCuentaBROXEL_Sel","fld":"vTFUSUARIONOCUENTABROXEL_SEL"},{"av":"AV42TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV61UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA"}]""");
         setEventMetadata("VGRIDACTIONS.CLICK",""","oparms":[{"av":"cmbavGridactions"},{"av":"AV39GridActions","fld":"vGRIDACTIONS","pic":"ZZZ9"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtUsuarioID_Visible","ctrl":"USUARIOID","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtUsuarioCorreo_Visible","ctrl":"USUARIOCORREO","prop":"Visible"},{"av":"edtUsuarioCelular_Visible","ctrl":"USUARIOCELULAR","prop":"Visible"},{"av":"edtavDistribuidor_Visible","ctrl":"vDISTRIBUIDOR","prop":"Visible"},{"av":"edtEstadoDescripcion_Visible","ctrl":"ESTADODESCRIPCION","prop":"Visible"},{"av":"cmbUsuarioProducto"},{"av":"edtavNofacturas_Visible","ctrl":"vNOFACTURAS","prop":"Visible"},{"av":"edtavFechaultimafactura_Visible","ctrl":"vFECHAULTIMAFACTURA","prop":"Visible"},{"av":"edtUsuarioNoCuentaBROXEL_Visible","ctrl":"USUARIONOCUENTABROXEL","prop":"Visible"},{"av":"edtavPass_Visible","ctrl":"vPASS","prop":"Visible"},{"av":"cmbUsuarioRol"},{"av":"AV36GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV37GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV38GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOUSERACTION1'","""{"handler":"E160Y2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFUsuarioID","fld":"vTFUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV25TFUsuarioID_To","fld":"vTFUSUARIOID_TO","pic":"ZZZZZZZZ9"},{"av":"AV44TFUsuarioNombreCompleto","fld":"vTFUSUARIONOMBRECOMPLETO"},{"av":"AV45TFUsuarioNombreCompleto_Sel","fld":"vTFUSUARIONOMBRECOMPLETO_SEL"},{"av":"AV28TFUsuarioCorreo","fld":"vTFUSUARIOCORREO"},{"av":"AV29TFUsuarioCorreo_Sel","fld":"vTFUSUARIOCORREO_SEL"},{"av":"AV51TFUsuarioCelular","fld":"vTFUSUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"AV52TFUsuarioCelular_To","fld":"vTFUSUARIOCELULAR_TO","pic":"ZZZZZZZZZ9"},{"av":"AV53TFEstadoDescripcion","fld":"vTFESTADODESCRIPCION"},{"av":"AV54TFEstadoDescripcion_Sel","fld":"vTFESTADODESCRIPCION_SEL"},{"av":"AV56TFUsuarioProducto_Sels","fld":"vTFUSUARIOPRODUCTO_SELS"},{"av":"AV57TFUsuarioNoCuentaBROXEL","fld":"vTFUSUARIONOCUENTABROXEL"},{"av":"AV58TFUsuarioNoCuentaBROXEL_Sel","fld":"vTFUSUARIONOCUENTABROXEL_SEL"},{"av":"AV42TFUsuarioRol_Sels","fld":"vTFUSUARIOROL_SELS"},{"av":"AV49UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"AV61UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOUSERACTION1'",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtUsuarioID_Visible","ctrl":"USUARIOID","prop":"Visible"},{"av":"edtUsuarioNombreCompleto_Visible","ctrl":"USUARIONOMBRECOMPLETO","prop":"Visible"},{"av":"edtUsuarioCorreo_Visible","ctrl":"USUARIOCORREO","prop":"Visible"},{"av":"edtUsuarioCelular_Visible","ctrl":"USUARIOCELULAR","prop":"Visible"},{"av":"edtavDistribuidor_Visible","ctrl":"vDISTRIBUIDOR","prop":"Visible"},{"av":"edtEstadoDescripcion_Visible","ctrl":"ESTADODESCRIPCION","prop":"Visible"},{"av":"cmbUsuarioProducto"},{"av":"edtavNofacturas_Visible","ctrl":"vNOFACTURAS","prop":"Visible"},{"av":"edtavFechaultimafactura_Visible","ctrl":"vFECHAULTIMAFACTURA","prop":"Visible"},{"av":"edtUsuarioNoCuentaBROXEL_Visible","ctrl":"USUARIONOCUENTABROXEL","prop":"Visible"},{"av":"edtavPass_Visible","ctrl":"vPASS","prop":"Visible"},{"av":"cmbUsuarioRol"},{"av":"AV36GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV37GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV38GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VALID_USUARIOID","""{"handler":"Valid_Usuarioid","iparms":[]}""");
         setEventMetadata("VALID_USUARIONOMBRECOMPLETO","""{"handler":"Valid_Usuarionombrecompleto","iparms":[]}""");
         setEventMetadata("VALID_USUARIOCORREO","""{"handler":"Valid_Usuariocorreo","iparms":[]}""");
         setEventMetadata("VALID_USUARIOCELULAR","""{"handler":"Valid_Usuariocelular","iparms":[]}""");
         setEventMetadata("VALID_ESTADODESCRIPCION","""{"handler":"Valid_Estadodescripcion","iparms":[]}""");
         setEventMetadata("VALID_USUARIOPRODUCTO","""{"handler":"Valid_Usuarioproducto","iparms":[]}""");
         setEventMetadata("VALIDV_FECHAULTIMAFACTURA","""{"handler":"Validv_Fechaultimafactura","iparms":[]}""");
         setEventMetadata("VALID_USUARIONOCUENTABROXEL","""{"handler":"Valid_Usuarionocuentabroxel","iparms":[]}""");
         setEventMetadata("VALID_USUARIOROL","""{"handler":"Valid_Usuariorol","iparms":[]}""");
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
         AV18ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV64Pgmname = "";
         AV15FilterFullText = "";
         AV44TFUsuarioNombreCompleto = "";
         AV45TFUsuarioNombreCompleto_Sel = "";
         AV28TFUsuarioCorreo = "";
         AV29TFUsuarioCorreo_Sel = "";
         AV53TFEstadoDescripcion = "";
         AV54TFEstadoDescripcion_Sel = "";
         AV56TFUsuarioProducto_Sels = new GxSimpleCollection<string>();
         AV57TFUsuarioNoCuentaBROXEL = "";
         AV58TFUsuarioNoCuentaBROXEL_Sel = "";
         AV42TFUsuarioRol_Sels = new GxSimpleCollection<string>();
         AV49UsuarioRol = "";
         A11DistribuidorDescripcion = "";
         A73FacturaFechaFactura = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV21ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV38GridAppliedFilters = "";
         AV34DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV10GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV55TFUsuarioProducto_SelsJson = "";
         AV41TFUsuarioRol_SelsJson = "";
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
         A52UsuarioNombreCompleto = "";
         A31UsuarioCorreo = "";
         AV59Distribuidor = "";
         A2EstadoDescripcion = "";
         A67UsuarioProducto = "";
         AV63FechaUltimaFactura = DateTime.MinValue;
         A82UsuarioNoCuentaBROXEL = "";
         AV40Pass = "";
         A40UsuarioRol = "";
         A32UsuarioPass = "";
         A33UsuarioKey = "";
         AV65Wpusuariods_1_filterfulltext = "";
         AV68Wpusuariods_4_tfusuarionombrecompleto = "";
         AV69Wpusuariods_5_tfusuarionombrecompleto_sel = "";
         AV70Wpusuariods_6_tfusuariocorreo = "";
         AV71Wpusuariods_7_tfusuariocorreo_sel = "";
         AV74Wpusuariods_10_tfestadodescripcion = "";
         AV75Wpusuariods_11_tfestadodescripcion_sel = "";
         AV76Wpusuariods_12_tfusuarioproducto_sels = new GxSimpleCollection<string>();
         AV77Wpusuariods_13_tfusuarionocuentabroxel = "";
         AV78Wpusuariods_14_tfusuarionocuentabroxel_sel = "";
         AV79Wpusuariods_15_tfusuariorol_sels = new GxSimpleCollection<string>();
         lV68Wpusuariods_4_tfusuarionombrecompleto = "";
         lV70Wpusuariods_6_tfusuariocorreo = "";
         lV74Wpusuariods_10_tfestadodescripcion = "";
         lV77Wpusuariods_13_tfusuarionocuentabroxel = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         H000Y2_A4CiudadID = new int[1] ;
         H000Y2_n4CiudadID = new bool[] {false} ;
         H000Y2_A1EstadoID = new int[1] ;
         H000Y2_A33UsuarioKey = new string[] {""} ;
         H000Y2_A32UsuarioPass = new string[] {""} ;
         H000Y2_A40UsuarioRol = new string[] {""} ;
         H000Y2_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         H000Y2_A67UsuarioProducto = new string[] {""} ;
         H000Y2_n67UsuarioProducto = new bool[] {false} ;
         H000Y2_A2EstadoDescripcion = new string[] {""} ;
         H000Y2_A64UsuarioCelular = new long[1] ;
         H000Y2_A31UsuarioCorreo = new string[] {""} ;
         H000Y2_A52UsuarioNombreCompleto = new string[] {""} ;
         H000Y2_A29UsuarioID = new int[1] ;
         H000Y2_A30UsuarioNombre = new string[] {""} ;
         H000Y2_A51UsuarioApellido = new string[] {""} ;
         H000Y3_A4CiudadID = new int[1] ;
         H000Y3_n4CiudadID = new bool[] {false} ;
         H000Y3_A1EstadoID = new int[1] ;
         H000Y3_A33UsuarioKey = new string[] {""} ;
         H000Y3_A32UsuarioPass = new string[] {""} ;
         H000Y3_A40UsuarioRol = new string[] {""} ;
         H000Y3_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         H000Y3_A67UsuarioProducto = new string[] {""} ;
         H000Y3_n67UsuarioProducto = new bool[] {false} ;
         H000Y3_A2EstadoDescripcion = new string[] {""} ;
         H000Y3_A64UsuarioCelular = new long[1] ;
         H000Y3_A31UsuarioCorreo = new string[] {""} ;
         H000Y3_A52UsuarioNombreCompleto = new string[] {""} ;
         H000Y3_A29UsuarioID = new int[1] ;
         H000Y3_A30UsuarioNombre = new string[] {""} ;
         H000Y3_A51UsuarioApellido = new string[] {""} ;
         AV46UsuarioJSON = "";
         AV47WebSession = context.GetSession();
         AV48SDTUsuario = new SdtSDTUsuario(context);
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
         GXt_char4 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV43AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         H000Y4_A81DistribuidoresUsuarioID = new int[1] ;
         H000Y4_A10DistribuidorID = new int[1] ;
         H000Y4_A29UsuarioID = new int[1] ;
         H000Y4_A11DistribuidorDescripcion = new string[] {""} ;
         H000Y5_AV62NoFacturas = new short[1] ;
         H000Y6_A93FacturaCompleta = new bool[] {false} ;
         H000Y6_A29UsuarioID = new int[1] ;
         H000Y6_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         H000Y6_A69FacturaID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpusuario__default(),
            new Object[][] {
                new Object[] {
               H000Y2_A4CiudadID, H000Y2_n4CiudadID, H000Y2_A1EstadoID, H000Y2_A33UsuarioKey, H000Y2_A32UsuarioPass, H000Y2_A40UsuarioRol, H000Y2_A82UsuarioNoCuentaBROXEL, H000Y2_A67UsuarioProducto, H000Y2_n67UsuarioProducto, H000Y2_A2EstadoDescripcion,
               H000Y2_A64UsuarioCelular, H000Y2_A31UsuarioCorreo, H000Y2_A52UsuarioNombreCompleto, H000Y2_A29UsuarioID, H000Y2_A30UsuarioNombre, H000Y2_A51UsuarioApellido
               }
               , new Object[] {
               H000Y3_A4CiudadID, H000Y3_n4CiudadID, H000Y3_A1EstadoID, H000Y3_A33UsuarioKey, H000Y3_A32UsuarioPass, H000Y3_A40UsuarioRol, H000Y3_A82UsuarioNoCuentaBROXEL, H000Y3_A67UsuarioProducto, H000Y3_n67UsuarioProducto, H000Y3_A2EstadoDescripcion,
               H000Y3_A64UsuarioCelular, H000Y3_A31UsuarioCorreo, H000Y3_A52UsuarioNombreCompleto, H000Y3_A29UsuarioID, H000Y3_A30UsuarioNombre, H000Y3_A51UsuarioApellido
               }
               , new Object[] {
               H000Y4_A81DistribuidoresUsuarioID, H000Y4_A10DistribuidorID, H000Y4_A29UsuarioID, H000Y4_A11DistribuidorDescripcion
               }
               , new Object[] {
               H000Y5_AV62NoFacturas
               }
               , new Object[] {
               H000Y6_A93FacturaCompleta, H000Y6_A29UsuarioID, H000Y6_A73FacturaFechaFactura, H000Y6_A69FacturaID
               }
            }
         );
         AV64Pgmname = "WPUsuario";
         /* GeneXus formulas. */
         AV64Pgmname = "WPUsuario";
         edtavDistribuidor_Enabled = 0;
         edtavNofacturas_Enabled = 0;
         edtavFechaultimafactura_Enabled = 0;
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
      private short AV12OrderedBy ;
      private short AV23ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV62NoFacturas ;
      private short AV39GridActions ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV81GXLvl512 ;
      private short cV62NoFacturas ;
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
      private int AV24TFUsuarioID ;
      private int AV25TFUsuarioID_To ;
      private int AV61UsuarioID ;
      private int A69FacturaID ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A29UsuarioID ;
      private int subGrid_Islastpage ;
      private int edtavDistribuidor_Enabled ;
      private int edtavNofacturas_Enabled ;
      private int edtavFechaultimafactura_Enabled ;
      private int edtavPass_Enabled ;
      private int AV66Wpusuariods_2_tfusuarioid ;
      private int AV67Wpusuariods_3_tfusuarioid_to ;
      private int AV76Wpusuariods_12_tfusuarioproducto_sels_Count ;
      private int AV79Wpusuariods_15_tfusuariorol_sels_Count ;
      private int A4CiudadID ;
      private int A1EstadoID ;
      private int edtUsuarioID_Enabled ;
      private int edtUsuarioNombreCompleto_Enabled ;
      private int edtUsuarioCorreo_Enabled ;
      private int edtUsuarioCelular_Enabled ;
      private int edtEstadoDescripcion_Enabled ;
      private int edtUsuarioNoCuentaBROXEL_Enabled ;
      private int edtUsuarioPass_Enabled ;
      private int edtUsuarioKey_Enabled ;
      private int edtUsuarioID_Visible ;
      private int edtUsuarioNombreCompleto_Visible ;
      private int edtUsuarioCorreo_Visible ;
      private int edtUsuarioCelular_Visible ;
      private int edtavDistribuidor_Visible ;
      private int edtEstadoDescripcion_Visible ;
      private int edtavNofacturas_Visible ;
      private int edtavFechaultimafactura_Visible ;
      private int edtUsuarioNoCuentaBROXEL_Visible ;
      private int edtavPass_Visible ;
      private int AV35PageToGo ;
      private int AV80GXV1 ;
      private int A10DistribuidorID ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV51TFUsuarioCelular ;
      private long AV52TFUsuarioCelular_To ;
      private long AV36GridCurrentPage ;
      private long AV37GridPageCount ;
      private long A64UsuarioCelular ;
      private long GRID_nCurrentRecord ;
      private long AV72Wpusuariods_8_tfusuariocelular ;
      private long AV73Wpusuariods_9_tfusuariocelular_to ;
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
      private string AV64Pgmname ;
      private string AV57TFUsuarioNoCuentaBROXEL ;
      private string AV58TFUsuarioNoCuentaBROXEL_Sel ;
      private string AV49UsuarioRol ;
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
      private string edtUsuarioNombreCompleto_Internalname ;
      private string edtUsuarioCorreo_Internalname ;
      private string edtUsuarioCelular_Internalname ;
      private string edtavDistribuidor_Internalname ;
      private string edtEstadoDescripcion_Internalname ;
      private string cmbUsuarioProducto_Internalname ;
      private string edtavNofacturas_Internalname ;
      private string edtavFechaultimafactura_Internalname ;
      private string A82UsuarioNoCuentaBROXEL ;
      private string edtUsuarioNoCuentaBROXEL_Internalname ;
      private string AV40Pass ;
      private string edtavPass_Internalname ;
      private string cmbUsuarioRol_Internalname ;
      private string A40UsuarioRol ;
      private string edtUsuarioPass_Internalname ;
      private string edtUsuarioKey_Internalname ;
      private string cmbavGridactions_Internalname ;
      private string AV77Wpusuariods_13_tfusuarionocuentabroxel ;
      private string AV78Wpusuariods_14_tfusuarionocuentabroxel_sel ;
      private string lV77Wpusuariods_13_tfusuarionocuentabroxel ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
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
      private string edtUsuarioNombreCompleto_Jsonclick ;
      private string edtUsuarioCorreo_Jsonclick ;
      private string edtUsuarioCelular_Jsonclick ;
      private string edtavDistribuidor_Jsonclick ;
      private string edtEstadoDescripcion_Jsonclick ;
      private string GXCCtl ;
      private string cmbUsuarioProducto_Jsonclick ;
      private string edtavNofacturas_Jsonclick ;
      private string edtavFechaultimafactura_Jsonclick ;
      private string edtUsuarioNoCuentaBROXEL_Jsonclick ;
      private string edtavPass_Jsonclick ;
      private string cmbUsuarioRol_Jsonclick ;
      private string edtUsuarioPass_Jsonclick ;
      private string edtUsuarioKey_Jsonclick ;
      private string cmbavGridactions_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A73FacturaFechaFactura ;
      private DateTime AV63FechaUltimaFactura ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool A93FacturaCompleta ;
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
      private bool n67UsuarioProducto ;
      private bool n4CiudadID ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV50PuedeVer ;
      private bool AV60EsPrimera ;
      private string AV55TFUsuarioProducto_SelsJson ;
      private string AV41TFUsuarioRol_SelsJson ;
      private string AV46UsuarioJSON ;
      private string AV16ColumnsSelectorXML ;
      private string AV22ManageFiltersXml ;
      private string AV17UserCustomValue ;
      private string AV15FilterFullText ;
      private string AV44TFUsuarioNombreCompleto ;
      private string AV45TFUsuarioNombreCompleto_Sel ;
      private string AV28TFUsuarioCorreo ;
      private string AV29TFUsuarioCorreo_Sel ;
      private string AV53TFEstadoDescripcion ;
      private string AV54TFEstadoDescripcion_Sel ;
      private string A11DistribuidorDescripcion ;
      private string AV38GridAppliedFilters ;
      private string A52UsuarioNombreCompleto ;
      private string A31UsuarioCorreo ;
      private string AV59Distribuidor ;
      private string A2EstadoDescripcion ;
      private string A67UsuarioProducto ;
      private string A32UsuarioPass ;
      private string A33UsuarioKey ;
      private string AV65Wpusuariods_1_filterfulltext ;
      private string AV68Wpusuariods_4_tfusuarionombrecompleto ;
      private string AV69Wpusuariods_5_tfusuarionombrecompleto_sel ;
      private string AV70Wpusuariods_6_tfusuariocorreo ;
      private string AV71Wpusuariods_7_tfusuariocorreo_sel ;
      private string AV74Wpusuariods_10_tfestadodescripcion ;
      private string AV75Wpusuariods_11_tfestadodescripcion_sel ;
      private string lV68Wpusuariods_4_tfusuarionombrecompleto ;
      private string lV70Wpusuariods_6_tfusuariocorreo ;
      private string lV74Wpusuariods_10_tfestadodescripcion ;
      private string AV43AuxText ;
      private IGxSession AV47WebSession ;
      private IGxSession AV20Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbUsuarioProducto ;
      private GXCombobox cmbUsuarioRol ;
      private GXCombobox cmbavGridactions ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV18ColumnsSelector ;
      private GxSimpleCollection<string> AV56TFUsuarioProducto_Sels ;
      private GxSimpleCollection<string> AV42TFUsuarioRol_Sels ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV21ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV34DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV10GridState ;
      private GxSimpleCollection<string> AV76Wpusuariods_12_tfusuarioproducto_sels ;
      private GxSimpleCollection<string> AV79Wpusuariods_15_tfusuariorol_sels ;
      private IDataStoreProvider pr_default ;
      private int[] H000Y2_A4CiudadID ;
      private bool[] H000Y2_n4CiudadID ;
      private int[] H000Y2_A1EstadoID ;
      private string[] H000Y2_A33UsuarioKey ;
      private string[] H000Y2_A32UsuarioPass ;
      private string[] H000Y2_A40UsuarioRol ;
      private string[] H000Y2_A82UsuarioNoCuentaBROXEL ;
      private string[] H000Y2_A67UsuarioProducto ;
      private bool[] H000Y2_n67UsuarioProducto ;
      private string[] H000Y2_A2EstadoDescripcion ;
      private long[] H000Y2_A64UsuarioCelular ;
      private string[] H000Y2_A31UsuarioCorreo ;
      private string[] H000Y2_A52UsuarioNombreCompleto ;
      private int[] H000Y2_A29UsuarioID ;
      private string[] H000Y2_A30UsuarioNombre ;
      private string[] H000Y2_A51UsuarioApellido ;
      private int[] H000Y3_A4CiudadID ;
      private bool[] H000Y3_n4CiudadID ;
      private int[] H000Y3_A1EstadoID ;
      private string[] H000Y3_A33UsuarioKey ;
      private string[] H000Y3_A32UsuarioPass ;
      private string[] H000Y3_A40UsuarioRol ;
      private string[] H000Y3_A82UsuarioNoCuentaBROXEL ;
      private string[] H000Y3_A67UsuarioProducto ;
      private bool[] H000Y3_n67UsuarioProducto ;
      private string[] H000Y3_A2EstadoDescripcion ;
      private long[] H000Y3_A64UsuarioCelular ;
      private string[] H000Y3_A31UsuarioCorreo ;
      private string[] H000Y3_A52UsuarioNombreCompleto ;
      private int[] H000Y3_A29UsuarioID ;
      private string[] H000Y3_A30UsuarioNombre ;
      private string[] H000Y3_A51UsuarioApellido ;
      private SdtSDTUsuario AV48SDTUsuario ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV19ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private int[] H000Y4_A81DistribuidoresUsuarioID ;
      private int[] H000Y4_A10DistribuidorID ;
      private int[] H000Y4_A29UsuarioID ;
      private string[] H000Y4_A11DistribuidorDescripcion ;
      private short[] H000Y5_AV62NoFacturas ;
      private bool[] H000Y6_A93FacturaCompleta ;
      private int[] H000Y6_A29UsuarioID ;
      private DateTime[] H000Y6_A73FacturaFechaFactura ;
      private int[] H000Y6_A69FacturaID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpusuario__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000Y2( IGxContext context ,
                                             string A67UsuarioProducto ,
                                             GxSimpleCollection<string> AV76Wpusuariods_12_tfusuarioproducto_sels ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV79Wpusuariods_15_tfusuariorol_sels ,
                                             int AV66Wpusuariods_2_tfusuarioid ,
                                             int AV67Wpusuariods_3_tfusuarioid_to ,
                                             string AV69Wpusuariods_5_tfusuarionombrecompleto_sel ,
                                             string AV68Wpusuariods_4_tfusuarionombrecompleto ,
                                             string AV71Wpusuariods_7_tfusuariocorreo_sel ,
                                             string AV70Wpusuariods_6_tfusuariocorreo ,
                                             long AV72Wpusuariods_8_tfusuariocelular ,
                                             long AV73Wpusuariods_9_tfusuariocelular_to ,
                                             string AV75Wpusuariods_11_tfestadodescripcion_sel ,
                                             string AV74Wpusuariods_10_tfestadodescripcion ,
                                             int AV76Wpusuariods_12_tfusuarioproducto_sels_Count ,
                                             string AV78Wpusuariods_14_tfusuarionocuentabroxel_sel ,
                                             string AV77Wpusuariods_13_tfusuarionocuentabroxel ,
                                             int AV79Wpusuariods_15_tfusuariorol_sels_Count ,
                                             int A29UsuarioID ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             long A64UsuarioCelular ,
                                             string A2EstadoDescripcion ,
                                             string A82UsuarioNoCuentaBROXEL ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             string AV65Wpusuariods_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[12];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.`CiudadID`, T2.`EstadoID`, T1.`UsuarioKey`, T1.`UsuarioPass`, T1.`UsuarioRol`, T1.`UsuarioNoCuentaBROXEL`, T1.`UsuarioProducto`, T3.`EstadoDescripcion`, T1.`UsuarioCelular`, T1.`UsuarioCorreo`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioID`, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM ((`Usuario` T1 LEFT JOIN `Ciudad` T2 ON T2.`CiudadID` = T1.`CiudadID`) LEFT JOIN `Estado` T3 ON T3.`EstadoID` = T2.`EstadoID`)";
         if ( ! (0==AV66Wpusuariods_2_tfusuarioid) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioID` >= @AV66Wpusuariods_2_tfusuarioid)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! (0==AV67Wpusuariods_3_tfusuarioid_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioID` <= @AV67Wpusuariods_3_tfusuarioid_to)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpusuariods_5_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wpusuariods_4_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV68Wpusuariods_4_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpusuariods_5_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV69Wpusuariods_5_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV69Wpusuariods_5_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( StringUtil.StrCmp(AV69Wpusuariods_5_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpusuariods_7_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpusuariods_6_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV70Wpusuariods_6_tfusuariocorreo)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpusuariods_7_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV71Wpusuariods_7_tfusuariocorreo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV71Wpusuariods_7_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV71Wpusuariods_7_tfusuariocorreo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( ! (0==AV72Wpusuariods_8_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV72Wpusuariods_8_tfusuariocelular)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! (0==AV73Wpusuariods_9_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV73Wpusuariods_9_tfusuariocelular_to)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpusuariods_11_tfestadodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpusuariods_10_tfestadodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`EstadoDescripcion` like @lV74Wpusuariods_10_tfestadodescripcion)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpusuariods_11_tfestadodescripcion_sel)) && ! ( StringUtil.StrCmp(AV75Wpusuariods_11_tfestadodescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`EstadoDescripcion` = @AV75Wpusuariods_11_tfestadodescripcion_sel)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV75Wpusuariods_11_tfestadodescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`EstadoDescripcion`))=0))");
         }
         if ( AV76Wpusuariods_12_tfusuarioproducto_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Wpusuariods_12_tfusuarioproducto_sels, "T1.`UsuarioProducto` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpusuariods_14_tfusuarionocuentabroxel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpusuariods_13_tfusuarionocuentabroxel)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioNoCuentaBROXEL` like @lV77Wpusuariods_13_tfusuarionocuentabroxel)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpusuariods_14_tfusuarionocuentabroxel_sel)) && ! ( StringUtil.StrCmp(AV78Wpusuariods_14_tfusuarionocuentabroxel_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioNoCuentaBROXEL` = @AV78Wpusuariods_14_tfusuarionocuentabroxel_sel)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV78Wpusuariods_14_tfusuarionocuentabroxel_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioNoCuentaBROXEL`))=0))");
         }
         if ( AV79Wpusuariods_15_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Wpusuariods_15_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV12OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.`UsuarioNombre`";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioID`";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioID` DESC";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCorreo`";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCorreo` DESC";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCelular`";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCelular` DESC";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.`EstadoDescripcion`";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.`EstadoDescripcion` DESC";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioProducto`";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioProducto` DESC";
         }
         else if ( ( AV12OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioNoCuentaBROXEL`";
         }
         else if ( ( AV12OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioNoCuentaBROXEL` DESC";
         }
         else if ( ( AV12OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioRol`";
         }
         else if ( ( AV12OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioRol` DESC";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H000Y3( IGxContext context ,
                                             string A67UsuarioProducto ,
                                             GxSimpleCollection<string> AV76Wpusuariods_12_tfusuarioproducto_sels ,
                                             string A40UsuarioRol ,
                                             GxSimpleCollection<string> AV79Wpusuariods_15_tfusuariorol_sels ,
                                             int AV66Wpusuariods_2_tfusuarioid ,
                                             int AV67Wpusuariods_3_tfusuarioid_to ,
                                             string AV69Wpusuariods_5_tfusuarionombrecompleto_sel ,
                                             string AV68Wpusuariods_4_tfusuarionombrecompleto ,
                                             string AV71Wpusuariods_7_tfusuariocorreo_sel ,
                                             string AV70Wpusuariods_6_tfusuariocorreo ,
                                             long AV72Wpusuariods_8_tfusuariocelular ,
                                             long AV73Wpusuariods_9_tfusuariocelular_to ,
                                             string AV75Wpusuariods_11_tfestadodescripcion_sel ,
                                             string AV74Wpusuariods_10_tfestadodescripcion ,
                                             int AV76Wpusuariods_12_tfusuarioproducto_sels_Count ,
                                             string AV78Wpusuariods_14_tfusuarionocuentabroxel_sel ,
                                             string AV77Wpusuariods_13_tfusuarionocuentabroxel ,
                                             int AV79Wpusuariods_15_tfusuariorol_sels_Count ,
                                             int A29UsuarioID ,
                                             string A30UsuarioNombre ,
                                             string A51UsuarioApellido ,
                                             string A31UsuarioCorreo ,
                                             long A64UsuarioCelular ,
                                             string A2EstadoDescripcion ,
                                             string A82UsuarioNoCuentaBROXEL ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             string AV65Wpusuariods_1_filterfulltext ,
                                             string A52UsuarioNombreCompleto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[12];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.`CiudadID`, T2.`EstadoID`, T1.`UsuarioKey`, T1.`UsuarioPass`, T1.`UsuarioRol`, T1.`UsuarioNoCuentaBROXEL`, T1.`UsuarioProducto`, T3.`EstadoDescripcion`, T1.`UsuarioCelular`, T1.`UsuarioCorreo`, CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) AS UsuarioNombreCompleto, T1.`UsuarioID`, T1.`UsuarioNombre`, T1.`UsuarioApellido` FROM ((`Usuario` T1 LEFT JOIN `Ciudad` T2 ON T2.`CiudadID` = T1.`CiudadID`) LEFT JOIN `Estado` T3 ON T3.`EstadoID` = T2.`EstadoID`)";
         if ( ! (0==AV66Wpusuariods_2_tfusuarioid) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioID` >= @AV66Wpusuariods_2_tfusuarioid)");
         }
         else
         {
            GXv_int11[0] = 1;
         }
         if ( ! (0==AV67Wpusuariods_3_tfusuarioid_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioID` <= @AV67Wpusuariods_3_tfusuarioid_to)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpusuariods_5_tfusuarionombrecompleto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wpusuariods_4_tfusuarionombrecompleto)) ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) like @lV68Wpusuariods_4_tfusuarionombrecompleto)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpusuariods_5_tfusuarionombrecompleto_sel)) && ! ( StringUtil.StrCmp(AV69Wpusuariods_5_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CONCAT(CONCAT(RTRIM(LTRIM(T1.`UsuarioNombre`)), ' '), RTRIM(LTRIM(T1.`UsuarioApellido`))) = @AV69Wpusuariods_5_tfusuarionombrecompleto_sel)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( StringUtil.StrCmp(AV69Wpusuariods_5_tfusuarionombrecompleto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(RTRIM(LTRIM(T1.`UsuarioNombre`)) || ' ' || RTRIM(LTRIM(T1.`UsuarioApellido`))))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpusuariods_7_tfusuariocorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpusuariods_6_tfusuariocorreo)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` like @lV70Wpusuariods_6_tfusuariocorreo)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpusuariods_7_tfusuariocorreo_sel)) && ! ( StringUtil.StrCmp(AV71Wpusuariods_7_tfusuariocorreo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCorreo` = @AV71Wpusuariods_7_tfusuariocorreo_sel)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( StringUtil.StrCmp(AV71Wpusuariods_7_tfusuariocorreo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioCorreo`))=0))");
         }
         if ( ! (0==AV72Wpusuariods_8_tfusuariocelular) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` >= @AV72Wpusuariods_8_tfusuariocelular)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( ! (0==AV73Wpusuariods_9_tfusuariocelular_to) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioCelular` <= @AV73Wpusuariods_9_tfusuariocelular_to)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpusuariods_11_tfestadodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpusuariods_10_tfestadodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`EstadoDescripcion` like @lV74Wpusuariods_10_tfestadodescripcion)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpusuariods_11_tfestadodescripcion_sel)) && ! ( StringUtil.StrCmp(AV75Wpusuariods_11_tfestadodescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`EstadoDescripcion` = @AV75Wpusuariods_11_tfestadodescripcion_sel)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( StringUtil.StrCmp(AV75Wpusuariods_11_tfestadodescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`EstadoDescripcion`))=0))");
         }
         if ( AV76Wpusuariods_12_tfusuarioproducto_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Wpusuariods_12_tfusuarioproducto_sels, "T1.`UsuarioProducto` IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpusuariods_14_tfusuarionocuentabroxel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpusuariods_13_tfusuarionocuentabroxel)) ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioNoCuentaBROXEL` like @lV77Wpusuariods_13_tfusuarionocuentabroxel)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpusuariods_14_tfusuarionocuentabroxel_sel)) && ! ( StringUtil.StrCmp(AV78Wpusuariods_14_tfusuarionocuentabroxel_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.`UsuarioNoCuentaBROXEL` = @AV78Wpusuariods_14_tfusuarionocuentabroxel_sel)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( StringUtil.StrCmp(AV78Wpusuariods_14_tfusuarionocuentabroxel_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T1.`UsuarioNoCuentaBROXEL`))=0))");
         }
         if ( AV79Wpusuariods_15_tfusuariorol_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Wpusuariods_15_tfusuariorol_sels, "T1.`UsuarioRol` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV12OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.`UsuarioNombre`";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioID`";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioID` DESC";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCorreo`";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCorreo` DESC";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCelular`";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioCelular` DESC";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.`EstadoDescripcion`";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.`EstadoDescripcion` DESC";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioProducto`";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioProducto` DESC";
         }
         else if ( ( AV12OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioNoCuentaBROXEL`";
         }
         else if ( ( AV12OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioNoCuentaBROXEL` DESC";
         }
         else if ( ( AV12OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.`UsuarioRol`";
         }
         else if ( ( AV12OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.`UsuarioRol` DESC";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000Y2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] );
               case 1 :
                     return conditional_H000Y3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmH000Y4;
          prmH000Y4 = new Object[] {
          new ParDef("@AV61UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH000Y5;
          prmH000Y5 = new Object[] {
          new ParDef("@AV61UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH000Y6;
          prmH000Y6 = new Object[] {
          new ParDef("@AV61UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH000Y2;
          prmH000Y2 = new Object[] {
          new ParDef("@AV66Wpusuariods_2_tfusuarioid",GXType.Int32,9,0) ,
          new ParDef("@AV67Wpusuariods_3_tfusuarioid_to",GXType.Int32,9,0) ,
          new ParDef("@lV68Wpusuariods_4_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV69Wpusuariods_5_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV70Wpusuariods_6_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV71Wpusuariods_7_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@AV72Wpusuariods_8_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV73Wpusuariods_9_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV74Wpusuariods_10_tfestadodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV75Wpusuariods_11_tfestadodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV77Wpusuariods_13_tfusuarionocuentabroxel",GXType.Char,20,0) ,
          new ParDef("@AV78Wpusuariods_14_tfusuarionocuentabroxel_sel",GXType.Char,20,0)
          };
          Object[] prmH000Y3;
          prmH000Y3 = new Object[] {
          new ParDef("@AV66Wpusuariods_2_tfusuarioid",GXType.Int32,9,0) ,
          new ParDef("@AV67Wpusuariods_3_tfusuarioid_to",GXType.Int32,9,0) ,
          new ParDef("@lV68Wpusuariods_4_tfusuarionombrecompleto",GXType.Char,40,0) ,
          new ParDef("@AV69Wpusuariods_5_tfusuarionombrecompleto_sel",GXType.Char,40,0) ,
          new ParDef("@lV70Wpusuariods_6_tfusuariocorreo",GXType.Char,100,0) ,
          new ParDef("@AV71Wpusuariods_7_tfusuariocorreo_sel",GXType.Char,100,0) ,
          new ParDef("@AV72Wpusuariods_8_tfusuariocelular",GXType.Int64,10,0) ,
          new ParDef("@AV73Wpusuariods_9_tfusuariocelular_to",GXType.Int64,10,0) ,
          new ParDef("@lV74Wpusuariods_10_tfestadodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV75Wpusuariods_11_tfestadodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV77Wpusuariods_13_tfusuarionocuentabroxel",GXType.Char,20,0) ,
          new ParDef("@AV78Wpusuariods_14_tfusuarionocuentabroxel_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Y2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Y3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Y4", "SELECT T1.`DistribuidoresUsuarioID`, T1.`DistribuidorID`, T1.`UsuarioID`, T2.`DistribuidorDescripcion` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Distribuidor` T2 ON T2.`DistribuidorID` = T1.`DistribuidorID`) WHERE T1.`UsuarioID` = @AV61UsuarioID ORDER BY T1.`UsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Y4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000Y5", "SELECT COUNT(*) FROM `Factura` WHERE (`UsuarioID` = @AV61UsuarioID) AND (`FacturaCompleta` = 1) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Y5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Y6", "SELECT `FacturaCompleta`, `UsuarioID`, `FacturaFechaFactura`, `FacturaID` FROM `Factura` WHERE (`UsuarioID` = @AV61UsuarioID) AND (`FacturaCompleta` = 1) ORDER BY `FacturaID` DESC  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Y6,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 40);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 50);
                ((string[]) buf[15])[0] = rslt.getString(14, 50);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 40);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 50);
                ((string[]) buf[15])[0] = rslt.getString(14, 50);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
