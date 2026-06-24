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
   public class wplistapromocionesasesor : GXDataArea
   {
      public wplistapromocionesasesor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wplistapromocionesasesor( IGxContext context )
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
         nRC_GXsfl_35 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_35"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_35_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_35_idx = GetPar( "sGXsfl_35_idx");
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
         ajax_req_read_hidden_sdt(GetNextPar( ), AV208ListaPromociones);
         AV23ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV18ColumnsSelector);
         AV242Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV24TFPromocionID = (int)(Math.Round(NumberUtil.Val( GetPar( "TFPromocionID"), "."), 18, MidpointRounding.ToEven));
         AV25TFPromocionID_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFPromocionID_To"), "."), 18, MidpointRounding.ToEven));
         AV26TFPromocionDescripcion = GetPar( "TFPromocionDescripcion");
         AV27TFPromocionDescripcion_Sel = GetPar( "TFPromocionDescripcion_Sel");
         AV28TFPromocionBase = GetPar( "TFPromocionBase");
         AV29TFPromocionBase_Sel = GetPar( "TFPromocionBase_Sel");
         AV40TFPromocionVigencia = GetPar( "TFPromocionVigencia");
         AV41TFPromocionVigencia_Sel = GetPar( "TFPromocionVigencia_Sel");
         AV198UsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "UsuarioID"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV208ListaPromociones, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV242Pgmname, AV15FilterFullText, AV24TFPromocionID, AV25TFPromocionID_To, AV26TFPromocionDescripcion, AV27TFPromocionDescripcion_Sel, AV28TFPromocionBase, AV29TFPromocionBase_Sel, AV40TFPromocionVigencia, AV41TFPromocionVigencia_Sel, AV198UsuarioID) ;
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
         PA3U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3U2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wplistapromocionesasesor.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV242Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV242Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV198UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV198UsuarioID), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_35", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_35), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV21ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV21ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV46GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV242Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV242Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFPROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24TFPromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPROMOCIONID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25TFPromocionID_To), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPROMOCIONDESCRIPCION", AV26TFPromocionDescripcion);
         GxWebStd.gx_hidden_field( context, "vTFPROMOCIONDESCRIPCION_SEL", AV27TFPromocionDescripcion_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPROMOCIONBASE", AV28TFPromocionBase);
         GxWebStd.gx_hidden_field( context, "vTFPROMOCIONBASE_SEL", AV29TFPromocionBase_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPROMOCIONVIGENCIA", AV40TFPromocionVigencia);
         GxWebStd.gx_hidden_field( context, "vTFPROMOCIONVIGENCIA_SEL", AV41TFPromocionVigencia_Sel);
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
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV198UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV198UsuarioID), "ZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLISTAPROMOCIONES", AV208ListaPromociones);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLISTAPROMOCIONES", AV208ListaPromociones);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WE3U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3U2( ) ;
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
         return formatLink("wplistapromocionesasesor.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPListaPromocionesAsesor" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Promocion", "") ;
      }

      protected void WB3U0( )
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
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WPListaPromocionesAsesor.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WPListaPromocionesAsesor.htm");
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
            StartGridControl35( ) ;
         }
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            nRC_GXsfl_35 = (int)(nGXsfl_35_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV44GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV45GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV46GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV42DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV42DDO_TitleSettingsIcons);
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
         if ( wbEnd == 35 )
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

      protected void START3U2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Promocion", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3U0( ) ;
      }

      protected void WS3U2( )
      {
         START3U2( ) ;
         EVT3U2( ) ;
      }

      protected void EVT3U2( )
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
                              E113U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E123U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E133U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E143U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E153U2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VEXCELDETALLADO.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VEXCELDETALLADO.CLICK") == 0 ) )
                           {
                              nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
                              SubsflControlProps_352( ) ;
                              A41PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPromocionID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A42PromocionDescripcion = cgiGet( edtPromocionDescripcion_Internalname);
                              A43PromocionBase = cgiGet( edtPromocionBase_Internalname);
                              A44PromocionArte = cgiGet( edtPromocionArte_Internalname);
                              AssignProp("", false, edtPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), !bGXsfl_35_Refreshing);
                              AssignProp("", false, edtPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
                              A45PromocionFechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPromocionFechaInicio_Internalname), 0));
                              A46PromocionFechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPromocionFechaFin_Internalname), 0));
                              AV217PromocionVigenciaWithTags = cgiGet( edtavPromocionvigenciawithtags_Internalname);
                              AssignAttri("", false, edtavPromocionvigenciawithtags_Internalname, AV217PromocionVigenciaWithTags);
                              A70PromocionVigencia = cgiGet( edtPromocionVigencia_Internalname);
                              AV218ExcelDetallado = cgiGet( edtavExceldetallado_Internalname);
                              AssignAttri("", false, edtavExceldetallado_Internalname, AV218ExcelDetallado);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E163U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E173U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E183U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VEXCELDETALLADO.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E193U2 ();
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

      protected void WE3U2( )
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

      protected void PA3U2( )
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
         SubsflControlProps_352( ) ;
         while ( nGXsfl_35_idx <= nRC_GXsfl_35 )
         {
            sendrow_352( ) ;
            nGXsfl_35_idx = ((subGrid_Islastpage==1)&&(nGXsfl_35_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       GxSimpleCollection<int> AV208ListaPromociones ,
                                       short AV23ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV18ColumnsSelector ,
                                       string AV242Pgmname ,
                                       string AV15FilterFullText ,
                                       int AV24TFPromocionID ,
                                       int AV25TFPromocionID_To ,
                                       string AV26TFPromocionDescripcion ,
                                       string AV27TFPromocionDescripcion_Sel ,
                                       string AV28TFPromocionBase ,
                                       string AV29TFPromocionBase_Sel ,
                                       string AV40TFPromocionVigencia ,
                                       string AV41TFPromocionVigencia_Sel ,
                                       int AV198UsuarioID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3U2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROMOCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, ".", "")));
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
         RF3U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV242Pgmname = "WPListaPromocionesAsesor";
         edtavPromocionvigenciawithtags_Enabled = 0;
         edtavExceldetallado_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV243Wplistapromocionesasesords_1_filterfulltext = AV15FilterFullText;
         AV244Wplistapromocionesasesords_2_tfpromocionid = AV24TFPromocionID;
         AV245Wplistapromocionesasesords_3_tfpromocionid_to = AV25TFPromocionID_To;
         AV246Wplistapromocionesasesords_4_tfpromociondescripcion = AV26TFPromocionDescripcion;
         AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel = AV27TFPromocionDescripcion_Sel;
         AV248Wplistapromocionesasesords_6_tfpromocionbase = AV28TFPromocionBase;
         AV249Wplistapromocionesasesords_7_tfpromocionbase_sel = AV29TFPromocionBase_Sel;
         AV250Wplistapromocionesasesords_8_tfpromocionvigencia = AV40TFPromocionVigencia;
         AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel = AV41TFPromocionVigencia_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A41PromocionID ,
                                              AV208ListaPromociones ,
                                              AV244Wplistapromocionesasesords_2_tfpromocionid ,
                                              AV245Wplistapromocionesasesords_3_tfpromocionid_to ,
                                              AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel ,
                                              AV246Wplistapromocionesasesords_4_tfpromociondescripcion ,
                                              AV249Wplistapromocionesasesords_7_tfpromocionbase_sel ,
                                              AV248Wplistapromocionesasesords_6_tfpromocionbase ,
                                              A42PromocionDescripcion ,
                                              A43PromocionBase ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              AV243Wplistapromocionesasesords_1_filterfulltext ,
                                              A70PromocionVigencia ,
                                              AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel ,
                                              AV250Wplistapromocionesasesords_8_tfpromocionvigencia } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV246Wplistapromocionesasesords_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV246Wplistapromocionesasesords_4_tfpromociondescripcion), "%", "");
         lV248Wplistapromocionesasesords_6_tfpromocionbase = StringUtil.Concat( StringUtil.RTrim( AV248Wplistapromocionesasesords_6_tfpromocionbase), "%", "");
         /* Using cursor H003U2 */
         pr_default.execute(0, new Object[] {AV244Wplistapromocionesasesords_2_tfpromocionid, AV245Wplistapromocionesasesords_3_tfpromocionid_to, lV246Wplistapromocionesasesords_4_tfpromociondescripcion, AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel, lV248Wplistapromocionesasesords_6_tfpromocionbase, AV249Wplistapromocionesasesords_7_tfpromocionbase_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A40000PromocionArte_GXI = H003U2_A40000PromocionArte_GXI[0];
            AssignProp("", false, edtPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), !bGXsfl_35_Refreshing);
            AssignProp("", false, edtPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            A43PromocionBase = H003U2_A43PromocionBase[0];
            A42PromocionDescripcion = H003U2_A42PromocionDescripcion[0];
            A41PromocionID = H003U2_A41PromocionID[0];
            A46PromocionFechaFin = H003U2_A46PromocionFechaFin[0];
            A45PromocionFechaInicio = H003U2_A45PromocionFechaInicio[0];
            A44PromocionArte = H003U2_A44PromocionArte[0];
            AssignProp("", false, edtPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), !bGXsfl_35_Refreshing);
            AssignProp("", false, edtPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV243Wplistapromocionesasesords_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A41PromocionID), 9, 0) , StringUtil.PadR( "%" + AV243Wplistapromocionesasesords_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A42PromocionDescripcion , StringUtil.PadR( "%" + AV243Wplistapromocionesasesords_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A43PromocionBase , StringUtil.PadR( "%" + AV243Wplistapromocionesasesords_1_filterfulltext , 700 , "%"),  ' ' ) ) || ( StringUtil.Like( A70PromocionVigencia , StringUtil.PadR( "%" + AV243Wplistapromocionesasesords_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV250Wplistapromocionesasesords_8_tfpromocionvigencia)) ) ) || ( StringUtil.Like( A70PromocionVigencia , StringUtil.PadR( AV250Wplistapromocionesasesords_8_tfpromocionvigencia , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel)) && ! ( StringUtil.StrCmp(AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A70PromocionVigencia, AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A70PromocionVigencia)) ) )
                     {
                        GRID_nRecordCount = (long)(GRID_nRecordCount+1);
                     }
                  }
               }
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF3U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 35;
         /* Execute user event: Refresh */
         E173U2 ();
         nGXsfl_35_idx = 1;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         bGXsfl_35_Refreshing = true;
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
            SubsflControlProps_352( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A41PromocionID ,
                                                 AV208ListaPromociones ,
                                                 AV244Wplistapromocionesasesords_2_tfpromocionid ,
                                                 AV245Wplistapromocionesasesords_3_tfpromocionid_to ,
                                                 AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel ,
                                                 AV246Wplistapromocionesasesords_4_tfpromociondescripcion ,
                                                 AV249Wplistapromocionesasesords_7_tfpromocionbase_sel ,
                                                 AV248Wplistapromocionesasesords_6_tfpromocionbase ,
                                                 A42PromocionDescripcion ,
                                                 A43PromocionBase ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 AV243Wplistapromocionesasesords_1_filterfulltext ,
                                                 A70PromocionVigencia ,
                                                 AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel ,
                                                 AV250Wplistapromocionesasesords_8_tfpromocionvigencia } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV246Wplistapromocionesasesords_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV246Wplistapromocionesasesords_4_tfpromociondescripcion), "%", "");
            lV248Wplistapromocionesasesords_6_tfpromocionbase = StringUtil.Concat( StringUtil.RTrim( AV248Wplistapromocionesasesords_6_tfpromocionbase), "%", "");
            /* Using cursor H003U3 */
            pr_default.execute(1, new Object[] {AV244Wplistapromocionesasesords_2_tfpromocionid, AV245Wplistapromocionesasesords_3_tfpromocionid_to, lV246Wplistapromocionesasesords_4_tfpromociondescripcion, AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel, lV248Wplistapromocionesasesords_6_tfpromocionbase, AV249Wplistapromocionesasesords_7_tfpromocionbase_sel});
            nGXsfl_35_idx = 1;
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A40000PromocionArte_GXI = H003U3_A40000PromocionArte_GXI[0];
               AssignProp("", false, edtPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), !bGXsfl_35_Refreshing);
               AssignProp("", false, edtPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
               A43PromocionBase = H003U3_A43PromocionBase[0];
               A42PromocionDescripcion = H003U3_A42PromocionDescripcion[0];
               A41PromocionID = H003U3_A41PromocionID[0];
               A46PromocionFechaFin = H003U3_A46PromocionFechaFin[0];
               A45PromocionFechaInicio = H003U3_A45PromocionFechaInicio[0];
               A44PromocionArte = H003U3_A44PromocionArte[0];
               AssignProp("", false, edtPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), !bGXsfl_35_Refreshing);
               AssignProp("", false, edtPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
               A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV243Wplistapromocionesasesords_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A41PromocionID), 9, 0) , StringUtil.PadR( "%" + AV243Wplistapromocionesasesords_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A42PromocionDescripcion , StringUtil.PadR( "%" + AV243Wplistapromocionesasesords_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A43PromocionBase , StringUtil.PadR( "%" + AV243Wplistapromocionesasesords_1_filterfulltext , 700 , "%"),  ' ' ) ) || ( StringUtil.Like( A70PromocionVigencia , StringUtil.PadR( "%" + AV243Wplistapromocionesasesords_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
               {
                  if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV250Wplistapromocionesasesords_8_tfpromocionvigencia)) ) ) || ( StringUtil.Like( A70PromocionVigencia , StringUtil.PadR( AV250Wplistapromocionesasesords_8_tfpromocionvigencia , 40 , "%"),  ' ' ) ) )
                  {
                     if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel)) && ! ( StringUtil.StrCmp(AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A70PromocionVigencia, AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel) == 0 ) ) )
                     {
                        if ( ( StringUtil.StrCmp(AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A70PromocionVigencia)) ) )
                        {
                           /* Execute user event: Grid.Load */
                           E183U2 ();
                        }
                     }
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 35;
            WB3U0( ) ;
         }
         bGXsfl_35_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3U2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV242Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV242Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV198UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV198UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROMOCIONID"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sGXsfl_35_idx, context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9"), context));
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
         AV243Wplistapromocionesasesords_1_filterfulltext = AV15FilterFullText;
         AV244Wplistapromocionesasesords_2_tfpromocionid = AV24TFPromocionID;
         AV245Wplistapromocionesasesords_3_tfpromocionid_to = AV25TFPromocionID_To;
         AV246Wplistapromocionesasesords_4_tfpromociondescripcion = AV26TFPromocionDescripcion;
         AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel = AV27TFPromocionDescripcion_Sel;
         AV248Wplistapromocionesasesords_6_tfpromocionbase = AV28TFPromocionBase;
         AV249Wplistapromocionesasesords_7_tfpromocionbase_sel = AV29TFPromocionBase_Sel;
         AV250Wplistapromocionesasesords_8_tfpromocionvigencia = AV40TFPromocionVigencia;
         AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel = AV41TFPromocionVigencia_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV208ListaPromociones, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV242Pgmname, AV15FilterFullText, AV24TFPromocionID, AV25TFPromocionID_To, AV26TFPromocionDescripcion, AV27TFPromocionDescripcion_Sel, AV28TFPromocionBase, AV29TFPromocionBase_Sel, AV40TFPromocionVigencia, AV41TFPromocionVigencia_Sel, AV198UsuarioID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV243Wplistapromocionesasesords_1_filterfulltext = AV15FilterFullText;
         AV244Wplistapromocionesasesords_2_tfpromocionid = AV24TFPromocionID;
         AV245Wplistapromocionesasesords_3_tfpromocionid_to = AV25TFPromocionID_To;
         AV246Wplistapromocionesasesords_4_tfpromociondescripcion = AV26TFPromocionDescripcion;
         AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel = AV27TFPromocionDescripcion_Sel;
         AV248Wplistapromocionesasesords_6_tfpromocionbase = AV28TFPromocionBase;
         AV249Wplistapromocionesasesords_7_tfpromocionbase_sel = AV29TFPromocionBase_Sel;
         AV250Wplistapromocionesasesords_8_tfpromocionvigencia = AV40TFPromocionVigencia;
         AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel = AV41TFPromocionVigencia_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV208ListaPromociones, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV242Pgmname, AV15FilterFullText, AV24TFPromocionID, AV25TFPromocionID_To, AV26TFPromocionDescripcion, AV27TFPromocionDescripcion_Sel, AV28TFPromocionBase, AV29TFPromocionBase_Sel, AV40TFPromocionVigencia, AV41TFPromocionVigencia_Sel, AV198UsuarioID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV243Wplistapromocionesasesords_1_filterfulltext = AV15FilterFullText;
         AV244Wplistapromocionesasesords_2_tfpromocionid = AV24TFPromocionID;
         AV245Wplistapromocionesasesords_3_tfpromocionid_to = AV25TFPromocionID_To;
         AV246Wplistapromocionesasesords_4_tfpromociondescripcion = AV26TFPromocionDescripcion;
         AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel = AV27TFPromocionDescripcion_Sel;
         AV248Wplistapromocionesasesords_6_tfpromocionbase = AV28TFPromocionBase;
         AV249Wplistapromocionesasesords_7_tfpromocionbase_sel = AV29TFPromocionBase_Sel;
         AV250Wplistapromocionesasesords_8_tfpromocionvigencia = AV40TFPromocionVigencia;
         AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel = AV41TFPromocionVigencia_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV208ListaPromociones, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV242Pgmname, AV15FilterFullText, AV24TFPromocionID, AV25TFPromocionID_To, AV26TFPromocionDescripcion, AV27TFPromocionDescripcion_Sel, AV28TFPromocionBase, AV29TFPromocionBase_Sel, AV40TFPromocionVigencia, AV41TFPromocionVigencia_Sel, AV198UsuarioID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV243Wplistapromocionesasesords_1_filterfulltext = AV15FilterFullText;
         AV244Wplistapromocionesasesords_2_tfpromocionid = AV24TFPromocionID;
         AV245Wplistapromocionesasesords_3_tfpromocionid_to = AV25TFPromocionID_To;
         AV246Wplistapromocionesasesords_4_tfpromociondescripcion = AV26TFPromocionDescripcion;
         AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel = AV27TFPromocionDescripcion_Sel;
         AV248Wplistapromocionesasesords_6_tfpromocionbase = AV28TFPromocionBase;
         AV249Wplistapromocionesasesords_7_tfpromocionbase_sel = AV29TFPromocionBase_Sel;
         AV250Wplistapromocionesasesords_8_tfpromocionvigencia = AV40TFPromocionVigencia;
         AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel = AV41TFPromocionVigencia_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV208ListaPromociones, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV242Pgmname, AV15FilterFullText, AV24TFPromocionID, AV25TFPromocionID_To, AV26TFPromocionDescripcion, AV27TFPromocionDescripcion_Sel, AV28TFPromocionBase, AV29TFPromocionBase_Sel, AV40TFPromocionVigencia, AV41TFPromocionVigencia_Sel, AV198UsuarioID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV243Wplistapromocionesasesords_1_filterfulltext = AV15FilterFullText;
         AV244Wplistapromocionesasesords_2_tfpromocionid = AV24TFPromocionID;
         AV245Wplistapromocionesasesords_3_tfpromocionid_to = AV25TFPromocionID_To;
         AV246Wplistapromocionesasesords_4_tfpromociondescripcion = AV26TFPromocionDescripcion;
         AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel = AV27TFPromocionDescripcion_Sel;
         AV248Wplistapromocionesasesords_6_tfpromocionbase = AV28TFPromocionBase;
         AV249Wplistapromocionesasesords_7_tfpromocionbase_sel = AV29TFPromocionBase_Sel;
         AV250Wplistapromocionesasesords_8_tfpromocionvigencia = AV40TFPromocionVigencia;
         AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel = AV41TFPromocionVigencia_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV208ListaPromociones, AV23ManageFiltersExecutionStep, AV18ColumnsSelector, AV242Pgmname, AV15FilterFullText, AV24TFPromocionID, AV25TFPromocionID_To, AV26TFPromocionDescripcion, AV27TFPromocionDescripcion_Sel, AV28TFPromocionBase, AV29TFPromocionBase_Sel, AV40TFPromocionVigencia, AV41TFPromocionVigencia_Sel, AV198UsuarioID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV242Pgmname = "WPListaPromocionesAsesor";
         edtavPromocionvigenciawithtags_Enabled = 0;
         edtavExceldetallado_Enabled = 0;
         edtPromocionID_Enabled = 0;
         edtPromocionDescripcion_Enabled = 0;
         edtPromocionBase_Enabled = 0;
         edtPromocionArte_Enabled = 0;
         edtPromocionFechaInicio_Enabled = 0;
         edtPromocionFechaFin_Enabled = 0;
         edtPromocionVigencia_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E163U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV21ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV42DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV18ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_35 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_35"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV44GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV45GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV46GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
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
         E163U2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E163U2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV199UsuarioJSON = AV204WebSession.Get(context.GetMessage( "Usuario", ""));
         AV107SDTUsuario.FromJSonString(AV199UsuarioJSON, null);
         AV198UsuarioID = AV107SDTUsuario.gxTpr_Usuarioid;
         AssignAttri("", false, "AV198UsuarioID", StringUtil.LTrimStr( (decimal)(AV198UsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV198UsuarioID), "ZZZZZZZZ9"), context));
         AV86ListaDistribuidores.Clear();
         AV208ListaPromociones.Clear();
         /* Using cursor H003U4 */
         pr_default.execute(2, new Object[] {AV198UsuarioID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A29UsuarioID = H003U4_A29UsuarioID[0];
            A10DistribuidorID = H003U4_A10DistribuidorID[0];
            AV207YaExiste = false;
            AV239GXV1 = 1;
            while ( AV239GXV1 <= AV86ListaDistribuidores.Count )
            {
               AV67DistribuidorID = (int)(AV86ListaDistribuidores.GetNumeric(AV239GXV1));
               if ( AV67DistribuidorID == A10DistribuidorID )
               {
                  AV207YaExiste = true;
                  if (true) break;
               }
               AV239GXV1 = (int)(AV239GXV1+1);
            }
            if ( ! AV207YaExiste )
            {
               AV86ListaDistribuidores.Add(A10DistribuidorID, 0);
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A10DistribuidorID ,
                                              AV86ListaDistribuidores } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         /* Using cursor H003U5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A10DistribuidorID = H003U5_A10DistribuidorID[0];
            A41PromocionID = H003U5_A41PromocionID[0];
            AV103Pasa = false;
            AV241GXV2 = 1;
            while ( AV241GXV2 <= AV208ListaPromociones.Count )
            {
               AV209PromocionID = (int)(AV208ListaPromociones.GetNumeric(AV241GXV2));
               if ( AV209PromocionID == A41PromocionID )
               {
                  AV103Pasa = true;
                  if (true) break;
               }
               AV241GXV2 = (int)(AV241GXV2+1);
            }
            if ( ! AV103Pasa )
            {
               AV208ListaPromociones.Add(A41PromocionID, 0);
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
         Form.Caption = context.GetMessage( " Promocion", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV42DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV42DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E173U2( )
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
         if ( StringUtil.StrCmp(AV20Session.Get("WPListaPromocionesAsesorColumnsSelector"), "") != 0 )
         {
            AV16ColumnsSelectorXML = AV20Session.Get("WPListaPromocionesAsesorColumnsSelector");
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
         edtPromocionID_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPromocionID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPromocionID_Visible), 5, 0), !bGXsfl_35_Refreshing);
         edtPromocionDescripcion_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPromocionDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPromocionDescripcion_Visible), 5, 0), !bGXsfl_35_Refreshing);
         edtPromocionBase_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPromocionBase_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPromocionBase_Visible), 5, 0), !bGXsfl_35_Refreshing);
         edtPromocionArte_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPromocionArte_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPromocionArte_Visible), 5, 0), !bGXsfl_35_Refreshing);
         edtavPromocionvigenciawithtags_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV18ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavPromocionvigenciawithtags_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPromocionvigenciawithtags_Visible), 5, 0), !bGXsfl_35_Refreshing);
         AV44GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV44GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV44GridCurrentPage), 10, 0));
         AV45GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV45GridPageCount", StringUtil.LTrimStr( (decimal)(AV45GridPageCount), 10, 0));
         GXt_char2 = AV46GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV242Pgmname, out  GXt_char2) ;
         AV46GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV46GridAppliedFilters", AV46GridAppliedFilters);
         AV243Wplistapromocionesasesords_1_filterfulltext = AV15FilterFullText;
         AV244Wplistapromocionesasesords_2_tfpromocionid = AV24TFPromocionID;
         AV245Wplistapromocionesasesords_3_tfpromocionid_to = AV25TFPromocionID_To;
         AV246Wplistapromocionesasesords_4_tfpromociondescripcion = AV26TFPromocionDescripcion;
         AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel = AV27TFPromocionDescripcion_Sel;
         AV248Wplistapromocionesasesords_6_tfpromocionbase = AV28TFPromocionBase;
         AV249Wplistapromocionesasesords_7_tfpromocionbase_sel = AV29TFPromocionBase_Sel;
         AV250Wplistapromocionesasesords_8_tfpromocionvigencia = AV40TFPromocionVigencia;
         AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel = AV41TFPromocionVigencia_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E123U2( )
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
            AV43PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV43PageToGo) ;
         }
      }

      protected void E133U2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E143U2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PromocionID") == 0 )
            {
               AV24TFPromocionID = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24TFPromocionID", StringUtil.LTrimStr( (decimal)(AV24TFPromocionID), 9, 0));
               AV25TFPromocionID_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFPromocionID_To", StringUtil.LTrimStr( (decimal)(AV25TFPromocionID_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PromocionDescripcion") == 0 )
            {
               AV26TFPromocionDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV26TFPromocionDescripcion", AV26TFPromocionDescripcion);
               AV27TFPromocionDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV27TFPromocionDescripcion_Sel", AV27TFPromocionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PromocionBase") == 0 )
            {
               AV28TFPromocionBase = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV28TFPromocionBase", AV28TFPromocionBase);
               AV29TFPromocionBase_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFPromocionBase_Sel", AV29TFPromocionBase_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PromocionVigencia") == 0 )
            {
               AV40TFPromocionVigencia = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV40TFPromocionVigencia", AV40TFPromocionVigencia);
               AV41TFPromocionVigencia_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV41TFPromocionVigencia_Sel", AV41TFPromocionVigencia_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E183U2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV218ExcelDetallado = "<i class=\"fas fa-file-excel\"></i>";
            AssignAttri("", false, edtavExceldetallado_Internalname, AV218ExcelDetallado);
            GXt_char2 = AV217PromocionVigenciaWithTags;
            new WorkWithPlus.workwithplus_web.wwp_encodehtml(context ).execute(  A70PromocionVigencia, out  GXt_char2) ;
            AV217PromocionVigenciaWithTags = GXt_char2;
            AssignAttri("", false, edtavPromocionvigenciawithtags_Internalname, AV217PromocionVigenciaWithTags);
            if ( DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) > DateTimeUtil.ResetTime ( A46PromocionFechaFin ) )
            {
               AV217PromocionVigenciaWithTags += StringUtil.Format( "<span class='AttributeTagDanger TagAfterText'>%1</span>", context.GetMessage( "Inactiva", ""), "", "", "", "", "", "", "", "");
               AssignAttri("", false, edtavPromocionvigenciawithtags_Internalname, AV217PromocionVigenciaWithTags);
            }
            if ( DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) <= DateTimeUtil.ResetTime ( A46PromocionFechaFin ) )
            {
               AV217PromocionVigenciaWithTags += StringUtil.Format( "<span class='AttributeTagSuccess TagAfterText'>%1</span>", context.GetMessage( "Activa", ""), "", "", "", "", "", "", "", "");
               AssignAttri("", false, edtavPromocionvigenciawithtags_Internalname, AV217PromocionVigenciaWithTags);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 35;
            }
            sendrow_352( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_35_Refreshing )
         {
            DoAjaxLoad(35, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E153U2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV16ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV18ColumnsSelector.FromJSonString(AV16ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WPListaPromocionesAsesorColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV16ColumnsSelectorXML)) ? "" : AV18ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E113U2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WPListaPromocionesAsesorFilters")) + "," + UrlEncode(StringUtil.RTrim(AV242Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WPListaPromocionesAsesorFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV23ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV22ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WPListaPromocionesAsesorFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV22ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22ManageFiltersXml)) )
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
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV242Pgmname+"GridState",  AV22ManageFiltersXml) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ColumnsSelector", AV18ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
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
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "PromocionID",  "",  "ID",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "PromocionDescripcion",  "",  "Nom. Promoción",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "PromocionBase",  "",  "Bases",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "PromocionArte",  "",  "Arte",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV18ColumnsSelector,  "PromocionVigencia",  "",  "Vigencia",  true,  "") ;
         GXt_char2 = AV17UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WPListaPromocionesAsesorColumnsSelector", out  GXt_char2) ;
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
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WPListaPromocionesAsesorFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV21ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV24TFPromocionID = 0;
         AssignAttri("", false, "AV24TFPromocionID", StringUtil.LTrimStr( (decimal)(AV24TFPromocionID), 9, 0));
         AV25TFPromocionID_To = 0;
         AssignAttri("", false, "AV25TFPromocionID_To", StringUtil.LTrimStr( (decimal)(AV25TFPromocionID_To), 9, 0));
         AV26TFPromocionDescripcion = "";
         AssignAttri("", false, "AV26TFPromocionDescripcion", AV26TFPromocionDescripcion);
         AV27TFPromocionDescripcion_Sel = "";
         AssignAttri("", false, "AV27TFPromocionDescripcion_Sel", AV27TFPromocionDescripcion_Sel);
         AV28TFPromocionBase = "";
         AssignAttri("", false, "AV28TFPromocionBase", AV28TFPromocionBase);
         AV29TFPromocionBase_Sel = "";
         AssignAttri("", false, "AV29TFPromocionBase_Sel", AV29TFPromocionBase_Sel);
         AV40TFPromocionVigencia = "";
         AssignAttri("", false, "AV40TFPromocionVigencia", AV40TFPromocionVigencia);
         AV41TFPromocionVigencia_Sel = "";
         AssignAttri("", false, "AV41TFPromocionVigencia_Sel", AV41TFPromocionVigencia_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20Session.Get(AV242Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV242Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV20Session.Get(AV242Pgmname+"GridState"), null, "", "");
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
         S182 ();
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

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV252GXV3 = 1;
         while ( AV252GXV3 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV252GXV3));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROMOCIONID") == 0 )
            {
               AV24TFPromocionID = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24TFPromocionID", StringUtil.LTrimStr( (decimal)(AV24TFPromocionID), 9, 0));
               AV25TFPromocionID_To = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFPromocionID_To", StringUtil.LTrimStr( (decimal)(AV25TFPromocionID_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION") == 0 )
            {
               AV26TFPromocionDescripcion = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV26TFPromocionDescripcion", AV26TFPromocionDescripcion);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION_SEL") == 0 )
            {
               AV27TFPromocionDescripcion_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFPromocionDescripcion_Sel", AV27TFPromocionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROMOCIONBASE") == 0 )
            {
               AV28TFPromocionBase = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFPromocionBase", AV28TFPromocionBase);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROMOCIONBASE_SEL") == 0 )
            {
               AV29TFPromocionBase_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFPromocionBase_Sel", AV29TFPromocionBase_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROMOCIONVIGENCIA") == 0 )
            {
               AV40TFPromocionVigencia = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFPromocionVigencia", AV40TFPromocionVigencia);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROMOCIONVIGENCIA_SEL") == 0 )
            {
               AV41TFPromocionVigencia_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFPromocionVigencia_Sel", AV41TFPromocionVigencia_Sel);
            }
            AV252GXV3 = (int)(AV252GXV3+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFPromocionDescripcion_Sel)),  AV27TFPromocionDescripcion_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFPromocionBase_Sel)),  AV29TFPromocionBase_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFPromocionVigencia_Sel)),  AV41TFPromocionVigencia_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char4+"||"+GXt_char5;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFPromocionDescripcion)),  AV26TFPromocionDescripcion, out  GXt_char5) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFPromocionBase)),  AV28TFPromocionBase, out  GXt_char4) ;
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFPromocionVigencia)),  AV40TFPromocionVigencia, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((0==AV24TFPromocionID) ? "" : StringUtil.Str( (decimal)(AV24TFPromocionID), 9, 0))+"|"+GXt_char5+"|"+GXt_char4+"||"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV25TFPromocionID_To) ? "" : StringUtil.Str( (decimal)(AV25TFPromocionID_To), 9, 0))+"||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV20Session.Get(AV242Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROMOCIONID",  context.GetMessage( "ID", ""),  !((0==AV24TFPromocionID)&&(0==AV25TFPromocionID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV24TFPromocionID), 9, 0)),  ((0==AV24TFPromocionID) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV24TFPromocionID), "ZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV25TFPromocionID_To), 9, 0)),  ((0==AV25TFPromocionID_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV25TFPromocionID_To), "ZZZZZZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROMOCIONDESCRIPCION",  context.GetMessage( "Nom. Promoción", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFPromocionDescripcion)),  0,  AV26TFPromocionDescripcion,  AV26TFPromocionDescripcion,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFPromocionDescripcion_Sel)),  AV27TFPromocionDescripcion_Sel,  AV27TFPromocionDescripcion_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROMOCIONBASE",  context.GetMessage( "Bases", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFPromocionBase)),  0,  AV28TFPromocionBase,  AV28TFPromocionBase,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFPromocionBase_Sel)),  AV29TFPromocionBase_Sel,  AV29TFPromocionBase_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROMOCIONVIGENCIA",  context.GetMessage( "Vigencia", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFPromocionVigencia)),  0,  AV40TFPromocionVigencia,  AV40TFPromocionVigencia,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFPromocionVigencia_Sel)),  AV41TFPromocionVigencia_Sel,  AV41TFPromocionVigencia_Sel) ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV242Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV242Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Promocion";
         AV20Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void E193U2( )
      {
         /* Exceldetallado_Click Routine */
         returnInSub = false;
         new obtienelistaparticipantesasesor(context ).execute(  AV198UsuarioID, out  AV237ListaUsuarioID) ;
         new generaexcelpartidasfiltrado(context ).execute(  A41PromocionID,  AV237ListaUsuarioID, out  AV233ExcelFilename, out  AV230ErrorMessage) ;
         if ( StringUtil.StrCmp(AV233ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV233ExcelFilename) );
            context.wjLocDisableFrm = 0;
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
         PA3U2( ) ;
         WS3U2( ) ;
         WE3U2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20265111131697", true, true);
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
         context.AddJavascriptSource("wplistapromocionesasesor.js", "?20265111131697", false, true);
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

      protected void SubsflControlProps_352( )
      {
         edtPromocionID_Internalname = "PROMOCIONID_"+sGXsfl_35_idx;
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION_"+sGXsfl_35_idx;
         edtPromocionBase_Internalname = "PROMOCIONBASE_"+sGXsfl_35_idx;
         edtPromocionArte_Internalname = "PROMOCIONARTE_"+sGXsfl_35_idx;
         edtPromocionFechaInicio_Internalname = "PROMOCIONFECHAINICIO_"+sGXsfl_35_idx;
         edtPromocionFechaFin_Internalname = "PROMOCIONFECHAFIN_"+sGXsfl_35_idx;
         edtavPromocionvigenciawithtags_Internalname = "vPROMOCIONVIGENCIAWITHTAGS_"+sGXsfl_35_idx;
         edtPromocionVigencia_Internalname = "PROMOCIONVIGENCIA_"+sGXsfl_35_idx;
         edtavExceldetallado_Internalname = "vEXCELDETALLADO_"+sGXsfl_35_idx;
      }

      protected void SubsflControlProps_fel_352( )
      {
         edtPromocionID_Internalname = "PROMOCIONID_"+sGXsfl_35_fel_idx;
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION_"+sGXsfl_35_fel_idx;
         edtPromocionBase_Internalname = "PROMOCIONBASE_"+sGXsfl_35_fel_idx;
         edtPromocionArte_Internalname = "PROMOCIONARTE_"+sGXsfl_35_fel_idx;
         edtPromocionFechaInicio_Internalname = "PROMOCIONFECHAINICIO_"+sGXsfl_35_fel_idx;
         edtPromocionFechaFin_Internalname = "PROMOCIONFECHAFIN_"+sGXsfl_35_fel_idx;
         edtavPromocionvigenciawithtags_Internalname = "vPROMOCIONVIGENCIAWITHTAGS_"+sGXsfl_35_fel_idx;
         edtPromocionVigencia_Internalname = "PROMOCIONVIGENCIA_"+sGXsfl_35_fel_idx;
         edtavExceldetallado_Internalname = "vEXCELDETALLADO_"+sGXsfl_35_fel_idx;
      }

      protected void sendrow_352( )
      {
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         WB3U0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_35_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_35_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_35_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtPromocionID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPromocionID_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPromocionDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionDescripcion_Internalname,(string)A42PromocionDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPromocionDescripcion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPromocionBase_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionBase_Internalname,(string)A43PromocionBase,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionBase_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPromocionBase_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)700,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtPromocionArte_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A44PromocionArte_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000PromocionArte_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.PathToRelativeUrl( A44PromocionArte));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionArte_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtPromocionArte_Visible,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A44PromocionArte_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionFechaInicio_Internalname,context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"),context.localUtil.Format( A45PromocionFechaInicio, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionFechaInicio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionFechaFin_Internalname,context.localUtil.Format(A46PromocionFechaFin, "99/99/99"),context.localUtil.Format( A46PromocionFechaFin, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionFechaFin_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavPromocionvigenciawithtags_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPromocionvigenciawithtags_Internalname,(string)AV217PromocionVigenciaWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPromocionvigenciawithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavPromocionvigenciawithtags_Visible,(int)edtavPromocionvigenciawithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionVigencia_Internalname,(string)A70PromocionVigencia,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionVigencia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavExceldetallado_Internalname,StringUtil.RTrim( AV218ExcelDetallado),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"","'"+""+"'"+",false,"+"'"+"EVEXCELDETALLADO.CLICK."+sGXsfl_35_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavExceldetallado_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavExceldetallado_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes3U2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_35_idx = ((subGrid_Islastpage==1)&&(nGXsfl_35_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         /* End function sendrow_352 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl35( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"35\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPromocionID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPromocionDescripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nom. Promoción", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPromocionBase_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Bases", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPromocionArte_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Arte", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavPromocionvigenciawithtags_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Vigencia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPromocionID_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A42PromocionDescripcion));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPromocionDescripcion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A43PromocionBase));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPromocionBase_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A44PromocionArte));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPromocionArte_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A45PromocionFechaInicio, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A46PromocionFechaFin, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV217PromocionVigenciaWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPromocionvigenciawithtags_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPromocionvigenciawithtags_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A70PromocionVigencia));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV218ExcelDetallado)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExceldetallado_Enabled), 5, 0, ".", "")));
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
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtPromocionID_Internalname = "PROMOCIONID";
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION";
         edtPromocionBase_Internalname = "PROMOCIONBASE";
         edtPromocionArte_Internalname = "PROMOCIONARTE";
         edtPromocionFechaInicio_Internalname = "PROMOCIONFECHAINICIO";
         edtPromocionFechaFin_Internalname = "PROMOCIONFECHAFIN";
         edtavPromocionvigenciawithtags_Internalname = "vPROMOCIONVIGENCIAWITHTAGS";
         edtPromocionVigencia_Internalname = "PROMOCIONVIGENCIA";
         edtavExceldetallado_Internalname = "vEXCELDETALLADO";
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
         edtavExceldetallado_Jsonclick = "";
         edtavExceldetallado_Enabled = 1;
         edtPromocionVigencia_Jsonclick = "";
         edtavPromocionvigenciawithtags_Jsonclick = "";
         edtavPromocionvigenciawithtags_Enabled = 1;
         edtPromocionFechaFin_Jsonclick = "";
         edtPromocionFechaInicio_Jsonclick = "";
         edtPromocionBase_Jsonclick = "";
         edtPromocionDescripcion_Jsonclick = "";
         edtPromocionID_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridNoBorder WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavPromocionvigenciawithtags_Visible = -1;
         edtPromocionArte_Visible = -1;
         edtPromocionBase_Visible = -1;
         edtPromocionDescripcion_Visible = -1;
         edtPromocionID_Visible = -1;
         edtPromocionVigencia_Enabled = 0;
         edtPromocionFechaFin_Enabled = 0;
         edtPromocionFechaInicio_Enabled = 0;
         edtPromocionArte_Enabled = 0;
         edtPromocionBase_Enabled = 0;
         edtPromocionDescripcion_Enabled = 0;
         edtPromocionID_Enabled = 0;
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
         Ddo_grid_Format = "4.0||||";
         Ddo_grid_Datalistproc = "WPListaPromocionesAsesorGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic||Dynamic";
         Ddo_grid_Includedatalist = "|T|T||T";
         Ddo_grid_Filterisrange = "T||||";
         Ddo_grid_Filtertype = "Numeric|Character|Character||Character";
         Ddo_grid_Includefilter = "T|T|T||T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|T|T||";
         Ddo_grid_Columnssortvalues = "2|1|3||";
         Ddo_grid_Columnids = "0:PromocionID|1:PromocionDescripcion|2:PromocionBase|3:PromocionArte|6:PromocionVigencia";
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
         Form.Caption = context.GetMessage( " Promocion", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV208ListaPromociones","fld":"vLISTAPROMOCIONES"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV242Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFPromocionID","fld":"vTFPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV25TFPromocionID_To","fld":"vTFPROMOCIONID_TO","pic":"ZZZZZZZZ9"},{"av":"AV26TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV27TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV28TFPromocionBase","fld":"vTFPROMOCIONBASE"},{"av":"AV29TFPromocionBase_Sel","fld":"vTFPROMOCIONBASE_SEL"},{"av":"AV40TFPromocionVigencia","fld":"vTFPROMOCIONVIGENCIA"},{"av":"AV41TFPromocionVigencia_Sel","fld":"vTFPROMOCIONVIGENCIA_SEL"},{"av":"AV198UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtPromocionID_Visible","ctrl":"PROMOCIONID","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtPromocionBase_Visible","ctrl":"PROMOCIONBASE","prop":"Visible"},{"av":"edtPromocionArte_Visible","ctrl":"PROMOCIONARTE","prop":"Visible"},{"av":"edtavPromocionvigenciawithtags_Visible","ctrl":"vPROMOCIONVIGENCIAWITHTAGS","prop":"Visible"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E123U2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV208ListaPromociones","fld":"vLISTAPROMOCIONES"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV242Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFPromocionID","fld":"vTFPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV25TFPromocionID_To","fld":"vTFPROMOCIONID_TO","pic":"ZZZZZZZZ9"},{"av":"AV26TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV27TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV28TFPromocionBase","fld":"vTFPROMOCIONBASE"},{"av":"AV29TFPromocionBase_Sel","fld":"vTFPROMOCIONBASE_SEL"},{"av":"AV40TFPromocionVigencia","fld":"vTFPROMOCIONVIGENCIA"},{"av":"AV41TFPromocionVigencia_Sel","fld":"vTFPROMOCIONVIGENCIA_SEL"},{"av":"AV198UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E133U2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV208ListaPromociones","fld":"vLISTAPROMOCIONES"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV242Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFPromocionID","fld":"vTFPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV25TFPromocionID_To","fld":"vTFPROMOCIONID_TO","pic":"ZZZZZZZZ9"},{"av":"AV26TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV27TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV28TFPromocionBase","fld":"vTFPROMOCIONBASE"},{"av":"AV29TFPromocionBase_Sel","fld":"vTFPROMOCIONBASE_SEL"},{"av":"AV40TFPromocionVigencia","fld":"vTFPROMOCIONVIGENCIA"},{"av":"AV41TFPromocionVigencia_Sel","fld":"vTFPROMOCIONVIGENCIA_SEL"},{"av":"AV198UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E143U2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV208ListaPromociones","fld":"vLISTAPROMOCIONES"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV242Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFPromocionID","fld":"vTFPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV25TFPromocionID_To","fld":"vTFPROMOCIONID_TO","pic":"ZZZZZZZZ9"},{"av":"AV26TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV27TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV28TFPromocionBase","fld":"vTFPROMOCIONBASE"},{"av":"AV29TFPromocionBase_Sel","fld":"vTFPROMOCIONBASE_SEL"},{"av":"AV40TFPromocionVigencia","fld":"vTFPROMOCIONVIGENCIA"},{"av":"AV41TFPromocionVigencia_Sel","fld":"vTFPROMOCIONVIGENCIA_SEL"},{"av":"AV198UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV24TFPromocionID","fld":"vTFPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV25TFPromocionID_To","fld":"vTFPROMOCIONID_TO","pic":"ZZZZZZZZ9"},{"av":"AV26TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV27TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV28TFPromocionBase","fld":"vTFPROMOCIONBASE"},{"av":"AV29TFPromocionBase_Sel","fld":"vTFPROMOCIONBASE_SEL"},{"av":"AV40TFPromocionVigencia","fld":"vTFPROMOCIONVIGENCIA"},{"av":"AV41TFPromocionVigencia_Sel","fld":"vTFPROMOCIONVIGENCIA_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E183U2","iparms":[{"av":"A70PromocionVigencia","fld":"PROMOCIONVIGENCIA"},{"av":"A46PromocionFechaFin","fld":"PROMOCIONFECHAFIN"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV218ExcelDetallado","fld":"vEXCELDETALLADO"},{"av":"AV217PromocionVigenciaWithTags","fld":"vPROMOCIONVIGENCIAWITHTAGS"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E153U2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV208ListaPromociones","fld":"vLISTAPROMOCIONES"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV242Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFPromocionID","fld":"vTFPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV25TFPromocionID_To","fld":"vTFPROMOCIONID_TO","pic":"ZZZZZZZZ9"},{"av":"AV26TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV27TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV28TFPromocionBase","fld":"vTFPROMOCIONBASE"},{"av":"AV29TFPromocionBase_Sel","fld":"vTFPROMOCIONBASE_SEL"},{"av":"AV40TFPromocionVigencia","fld":"vTFPROMOCIONVIGENCIA"},{"av":"AV41TFPromocionVigencia_Sel","fld":"vTFPROMOCIONVIGENCIA_SEL"},{"av":"AV198UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtPromocionID_Visible","ctrl":"PROMOCIONID","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtPromocionBase_Visible","ctrl":"PROMOCIONBASE","prop":"Visible"},{"av":"edtPromocionArte_Visible","ctrl":"PROMOCIONARTE","prop":"Visible"},{"av":"edtavPromocionvigenciawithtags_Visible","ctrl":"vPROMOCIONVIGENCIAWITHTAGS","prop":"Visible"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E113U2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV208ListaPromociones","fld":"vLISTAPROMOCIONES"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV242Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFPromocionID","fld":"vTFPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV25TFPromocionID_To","fld":"vTFPROMOCIONID_TO","pic":"ZZZZZZZZ9"},{"av":"AV26TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV27TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV28TFPromocionBase","fld":"vTFPROMOCIONBASE"},{"av":"AV29TFPromocionBase_Sel","fld":"vTFPROMOCIONBASE_SEL"},{"av":"AV40TFPromocionVigencia","fld":"vTFPROMOCIONVIGENCIA"},{"av":"AV41TFPromocionVigencia_Sel","fld":"vTFPROMOCIONVIGENCIA_SEL"},{"av":"AV198UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFPromocionID","fld":"vTFPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV25TFPromocionID_To","fld":"vTFPROMOCIONID_TO","pic":"ZZZZZZZZ9"},{"av":"AV26TFPromocionDescripcion","fld":"vTFPROMOCIONDESCRIPCION"},{"av":"AV27TFPromocionDescripcion_Sel","fld":"vTFPROMOCIONDESCRIPCION_SEL"},{"av":"AV28TFPromocionBase","fld":"vTFPROMOCIONBASE"},{"av":"AV29TFPromocionBase_Sel","fld":"vTFPROMOCIONBASE_SEL"},{"av":"AV40TFPromocionVigencia","fld":"vTFPROMOCIONVIGENCIA"},{"av":"AV41TFPromocionVigencia_Sel","fld":"vTFPROMOCIONVIGENCIA_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV18ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtPromocionID_Visible","ctrl":"PROMOCIONID","prop":"Visible"},{"av":"edtPromocionDescripcion_Visible","ctrl":"PROMOCIONDESCRIPCION","prop":"Visible"},{"av":"edtPromocionBase_Visible","ctrl":"PROMOCIONBASE","prop":"Visible"},{"av":"edtPromocionArte_Visible","ctrl":"PROMOCIONARTE","prop":"Visible"},{"av":"edtavPromocionvigenciawithtags_Visible","ctrl":"vPROMOCIONVIGENCIAWITHTAGS","prop":"Visible"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VEXCELDETALLADO.CLICK","""{"handler":"E193U2","iparms":[{"av":"AV198UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("VALID_PROMOCIONID","""{"handler":"Valid_Promocionid","iparms":[]}""");
         setEventMetadata("VALID_PROMOCIONDESCRIPCION","""{"handler":"Valid_Promociondescripcion","iparms":[]}""");
         setEventMetadata("VALID_PROMOCIONBASE","""{"handler":"Valid_Promocionbase","iparms":[]}""");
         setEventMetadata("VALID_PROMOCIONFECHAINICIO","""{"handler":"Valid_Promocionfechainicio","iparms":[]}""");
         setEventMetadata("VALID_PROMOCIONFECHAFIN","""{"handler":"Valid_Promocionfechafin","iparms":[]}""");
         setEventMetadata("VALID_PROMOCIONVIGENCIA","""{"handler":"Valid_Promocionvigencia","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Exceldetallado","iparms":[]}""");
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
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV208ListaPromociones = new GxSimpleCollection<int>();
         AV18ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV242Pgmname = "";
         AV15FilterFullText = "";
         AV26TFPromocionDescripcion = "";
         AV27TFPromocionDescripcion_Sel = "";
         AV28TFPromocionBase = "";
         AV29TFPromocionBase_Sel = "";
         AV40TFPromocionVigencia = "";
         AV41TFPromocionVigencia_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV21ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV46GridAppliedFilters = "";
         AV42DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV10GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
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
         A42PromocionDescripcion = "";
         A43PromocionBase = "";
         A44PromocionArte = "";
         A40000PromocionArte_GXI = "";
         A45PromocionFechaInicio = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         AV217PromocionVigenciaWithTags = "";
         A70PromocionVigencia = "";
         AV218ExcelDetallado = "";
         AV243Wplistapromocionesasesords_1_filterfulltext = "";
         AV246Wplistapromocionesasesords_4_tfpromociondescripcion = "";
         AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel = "";
         AV248Wplistapromocionesasesords_6_tfpromocionbase = "";
         AV249Wplistapromocionesasesords_7_tfpromocionbase_sel = "";
         AV250Wplistapromocionesasesords_8_tfpromocionvigencia = "";
         AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel = "";
         lV246Wplistapromocionesasesords_4_tfpromociondescripcion = "";
         lV248Wplistapromocionesasesords_6_tfpromocionbase = "";
         H003U2_A40000PromocionArte_GXI = new string[] {""} ;
         H003U2_A43PromocionBase = new string[] {""} ;
         H003U2_A42PromocionDescripcion = new string[] {""} ;
         H003U2_A41PromocionID = new int[1] ;
         H003U2_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         H003U2_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         H003U2_A44PromocionArte = new string[] {""} ;
         H003U3_A40000PromocionArte_GXI = new string[] {""} ;
         H003U3_A43PromocionBase = new string[] {""} ;
         H003U3_A42PromocionDescripcion = new string[] {""} ;
         H003U3_A41PromocionID = new int[1] ;
         H003U3_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         H003U3_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         H003U3_A44PromocionArte = new string[] {""} ;
         AV199UsuarioJSON = "";
         AV204WebSession = context.GetSession();
         AV107SDTUsuario = new SdtSDTUsuario(context);
         AV86ListaDistribuidores = new GxSimpleCollection<int>();
         H003U4_A81DistribuidoresUsuarioID = new int[1] ;
         H003U4_A29UsuarioID = new int[1] ;
         H003U4_A10DistribuidorID = new int[1] ;
         H003U5_A47PromocionDistribuidorID = new int[1] ;
         H003U5_A10DistribuidorID = new int[1] ;
         H003U5_A41PromocionID = new int[1] ;
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
         AV237ListaUsuarioID = new GxSimpleCollection<int>();
         AV233ExcelFilename = "";
         AV230ErrorMessage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wplistapromocionesasesor__default(),
            new Object[][] {
                new Object[] {
               H003U2_A40000PromocionArte_GXI, H003U2_A43PromocionBase, H003U2_A42PromocionDescripcion, H003U2_A41PromocionID, H003U2_A46PromocionFechaFin, H003U2_A45PromocionFechaInicio, H003U2_A44PromocionArte
               }
               , new Object[] {
               H003U3_A40000PromocionArte_GXI, H003U3_A43PromocionBase, H003U3_A42PromocionDescripcion, H003U3_A41PromocionID, H003U3_A46PromocionFechaFin, H003U3_A45PromocionFechaInicio, H003U3_A44PromocionArte
               }
               , new Object[] {
               H003U4_A81DistribuidoresUsuarioID, H003U4_A29UsuarioID, H003U4_A10DistribuidorID
               }
               , new Object[] {
               H003U5_A47PromocionDistribuidorID, H003U5_A10DistribuidorID, H003U5_A41PromocionID
               }
            }
         );
         AV242Pgmname = "WPListaPromocionesAsesor";
         /* GeneXus formulas. */
         AV242Pgmname = "WPListaPromocionesAsesor";
         edtavPromocionvigenciawithtags_Enabled = 0;
         edtavExceldetallado_Enabled = 0;
      }

      private short GRID_nEOF ;
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
      private int nRC_GXsfl_35 ;
      private int nGXsfl_35_idx=1 ;
      private int AV24TFPromocionID ;
      private int AV25TFPromocionID_To ;
      private int AV198UsuarioID ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A41PromocionID ;
      private int subGrid_Islastpage ;
      private int edtavPromocionvigenciawithtags_Enabled ;
      private int edtavExceldetallado_Enabled ;
      private int AV244Wplistapromocionesasesords_2_tfpromocionid ;
      private int AV245Wplistapromocionesasesords_3_tfpromocionid_to ;
      private int edtPromocionID_Enabled ;
      private int edtPromocionDescripcion_Enabled ;
      private int edtPromocionBase_Enabled ;
      private int edtPromocionArte_Enabled ;
      private int edtPromocionFechaInicio_Enabled ;
      private int edtPromocionFechaFin_Enabled ;
      private int edtPromocionVigencia_Enabled ;
      private int A29UsuarioID ;
      private int A10DistribuidorID ;
      private int AV239GXV1 ;
      private int AV67DistribuidorID ;
      private int AV241GXV2 ;
      private int AV209PromocionID ;
      private int edtPromocionID_Visible ;
      private int edtPromocionDescripcion_Visible ;
      private int edtPromocionBase_Visible ;
      private int edtPromocionArte_Visible ;
      private int edtavPromocionvigenciawithtags_Visible ;
      private int AV43PageToGo ;
      private int AV252GXV3 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV44GridCurrentPage ;
      private long AV45GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_35_idx="0001" ;
      private string AV242Pgmname ;
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
      private string edtPromocionID_Internalname ;
      private string edtPromocionDescripcion_Internalname ;
      private string edtPromocionBase_Internalname ;
      private string edtPromocionArte_Internalname ;
      private string edtPromocionFechaInicio_Internalname ;
      private string edtPromocionFechaFin_Internalname ;
      private string edtavPromocionvigenciawithtags_Internalname ;
      private string edtPromocionVigencia_Internalname ;
      private string AV218ExcelDetallado ;
      private string edtavExceldetallado_Internalname ;
      private string GXEncryptionTmp ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string sGXsfl_35_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtPromocionID_Jsonclick ;
      private string edtPromocionDescripcion_Jsonclick ;
      private string edtPromocionBase_Jsonclick ;
      private string sImgUrl ;
      private string edtPromocionFechaInicio_Jsonclick ;
      private string edtPromocionFechaFin_Jsonclick ;
      private string edtavPromocionvigenciawithtags_Jsonclick ;
      private string edtPromocionVigencia_Jsonclick ;
      private string edtavExceldetallado_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A45PromocionFechaInicio ;
      private DateTime A46PromocionFechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
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
      private bool bGXsfl_35_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV207YaExiste ;
      private bool AV103Pasa ;
      private bool gx_refresh_fired ;
      private bool A44PromocionArte_IsBlob ;
      private string AV199UsuarioJSON ;
      private string AV16ColumnsSelectorXML ;
      private string AV22ManageFiltersXml ;
      private string AV17UserCustomValue ;
      private string AV15FilterFullText ;
      private string AV26TFPromocionDescripcion ;
      private string AV27TFPromocionDescripcion_Sel ;
      private string AV28TFPromocionBase ;
      private string AV29TFPromocionBase_Sel ;
      private string AV40TFPromocionVigencia ;
      private string AV41TFPromocionVigencia_Sel ;
      private string AV46GridAppliedFilters ;
      private string A42PromocionDescripcion ;
      private string A43PromocionBase ;
      private string A40000PromocionArte_GXI ;
      private string AV217PromocionVigenciaWithTags ;
      private string A70PromocionVigencia ;
      private string AV243Wplistapromocionesasesords_1_filterfulltext ;
      private string AV246Wplistapromocionesasesords_4_tfpromociondescripcion ;
      private string AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel ;
      private string AV248Wplistapromocionesasesords_6_tfpromocionbase ;
      private string AV249Wplistapromocionesasesords_7_tfpromocionbase_sel ;
      private string AV250Wplistapromocionesasesords_8_tfpromocionvigencia ;
      private string AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel ;
      private string lV246Wplistapromocionesasesords_4_tfpromociondescripcion ;
      private string lV248Wplistapromocionesasesords_6_tfpromocionbase ;
      private string AV233ExcelFilename ;
      private string AV230ErrorMessage ;
      private string A44PromocionArte ;
      private IGxSession AV204WebSession ;
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
      private GxSimpleCollection<int> AV208ListaPromociones ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV18ColumnsSelector ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV21ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV42DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV10GridState ;
      private IDataStoreProvider pr_default ;
      private string[] H003U2_A40000PromocionArte_GXI ;
      private string[] H003U2_A43PromocionBase ;
      private string[] H003U2_A42PromocionDescripcion ;
      private int[] H003U2_A41PromocionID ;
      private DateTime[] H003U2_A46PromocionFechaFin ;
      private DateTime[] H003U2_A45PromocionFechaInicio ;
      private string[] H003U2_A44PromocionArte ;
      private string[] H003U3_A40000PromocionArte_GXI ;
      private string[] H003U3_A43PromocionBase ;
      private string[] H003U3_A42PromocionDescripcion ;
      private int[] H003U3_A41PromocionID ;
      private DateTime[] H003U3_A46PromocionFechaFin ;
      private DateTime[] H003U3_A45PromocionFechaInicio ;
      private string[] H003U3_A44PromocionArte ;
      private SdtSDTUsuario AV107SDTUsuario ;
      private GxSimpleCollection<int> AV86ListaDistribuidores ;
      private int[] H003U4_A81DistribuidoresUsuarioID ;
      private int[] H003U4_A29UsuarioID ;
      private int[] H003U4_A10DistribuidorID ;
      private int[] H003U5_A47PromocionDistribuidorID ;
      private int[] H003U5_A10DistribuidorID ;
      private int[] H003U5_A41PromocionID ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV19ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GxSimpleCollection<int> AV237ListaUsuarioID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wplistapromocionesasesor__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003U2( IGxContext context ,
                                             int A41PromocionID ,
                                             GxSimpleCollection<int> AV208ListaPromociones ,
                                             int AV244Wplistapromocionesasesords_2_tfpromocionid ,
                                             int AV245Wplistapromocionesasesords_3_tfpromocionid_to ,
                                             string AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel ,
                                             string AV246Wplistapromocionesasesords_4_tfpromociondescripcion ,
                                             string AV249Wplistapromocionesasesords_7_tfpromocionbase_sel ,
                                             string AV248Wplistapromocionesasesords_6_tfpromocionbase ,
                                             string A42PromocionDescripcion ,
                                             string A43PromocionBase ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             string AV243Wplistapromocionesasesords_1_filterfulltext ,
                                             string A70PromocionVigencia ,
                                             string AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel ,
                                             string AV250Wplistapromocionesasesords_8_tfpromocionvigencia )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[6];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT `PromocionArte_GXI`, `PromocionBase`, `PromocionDescripcion`, `PromocionID`, `PromocionFechaFin`, `PromocionFechaInicio`, `PromocionArte` FROM `Promocion`";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV208ListaPromociones, "`PromocionID` IN (", ")")+")");
         if ( ! (0==AV244Wplistapromocionesasesords_2_tfpromocionid) )
         {
            AddWhere(sWhereString, "(`PromocionID` >= @AV244Wplistapromocionesasesords_2_tfpromocionid)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! (0==AV245Wplistapromocionesasesords_3_tfpromocionid_to) )
         {
            AddWhere(sWhereString, "(`PromocionID` <= @AV245Wplistapromocionesasesords_3_tfpromocionid_to)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV246Wplistapromocionesasesords_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` like @lV246Wplistapromocionesasesords_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` = @AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( StringUtil.StrCmp(AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV249Wplistapromocionesasesords_7_tfpromocionbase_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV248Wplistapromocionesasesords_6_tfpromocionbase)) ) )
         {
            AddWhere(sWhereString, "(`PromocionBase` like @lV248Wplistapromocionesasesords_6_tfpromocionbase)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV249Wplistapromocionesasesords_7_tfpromocionbase_sel)) && ! ( StringUtil.StrCmp(AV249Wplistapromocionesasesords_7_tfpromocionbase_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionBase` = @AV249Wplistapromocionesasesords_7_tfpromocionbase_sel)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( StringUtil.StrCmp(AV249Wplistapromocionesasesords_7_tfpromocionbase_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionBase`))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY `PromocionDescripcion`";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY `PromocionDescripcion` DESC";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY `PromocionID`";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY `PromocionID` DESC";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY `PromocionBase`";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY `PromocionBase` DESC";
         }
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H003U3( IGxContext context ,
                                             int A41PromocionID ,
                                             GxSimpleCollection<int> AV208ListaPromociones ,
                                             int AV244Wplistapromocionesasesords_2_tfpromocionid ,
                                             int AV245Wplistapromocionesasesords_3_tfpromocionid_to ,
                                             string AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel ,
                                             string AV246Wplistapromocionesasesords_4_tfpromociondescripcion ,
                                             string AV249Wplistapromocionesasesords_7_tfpromocionbase_sel ,
                                             string AV248Wplistapromocionesasesords_6_tfpromocionbase ,
                                             string A42PromocionDescripcion ,
                                             string A43PromocionBase ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             string AV243Wplistapromocionesasesords_1_filterfulltext ,
                                             string A70PromocionVigencia ,
                                             string AV251Wplistapromocionesasesords_9_tfpromocionvigencia_sel ,
                                             string AV250Wplistapromocionesasesords_8_tfpromocionvigencia )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[6];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT `PromocionArte_GXI`, `PromocionBase`, `PromocionDescripcion`, `PromocionID`, `PromocionFechaFin`, `PromocionFechaInicio`, `PromocionArte` FROM `Promocion`";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV208ListaPromociones, "`PromocionID` IN (", ")")+")");
         if ( ! (0==AV244Wplistapromocionesasesords_2_tfpromocionid) )
         {
            AddWhere(sWhereString, "(`PromocionID` >= @AV244Wplistapromocionesasesords_2_tfpromocionid)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ! (0==AV245Wplistapromocionesasesords_3_tfpromocionid_to) )
         {
            AddWhere(sWhereString, "(`PromocionID` <= @AV245Wplistapromocionesasesords_3_tfpromocionid_to)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV246Wplistapromocionesasesords_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` like @lV246Wplistapromocionesasesords_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` = @AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( StringUtil.StrCmp(AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV249Wplistapromocionesasesords_7_tfpromocionbase_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV248Wplistapromocionesasesords_6_tfpromocionbase)) ) )
         {
            AddWhere(sWhereString, "(`PromocionBase` like @lV248Wplistapromocionesasesords_6_tfpromocionbase)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV249Wplistapromocionesasesords_7_tfpromocionbase_sel)) && ! ( StringUtil.StrCmp(AV249Wplistapromocionesasesords_7_tfpromocionbase_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionBase` = @AV249Wplistapromocionesasesords_7_tfpromocionbase_sel)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( StringUtil.StrCmp(AV249Wplistapromocionesasesords_7_tfpromocionbase_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionBase`))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY `PromocionDescripcion`";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY `PromocionDescripcion` DESC";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY `PromocionID`";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY `PromocionID` DESC";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY `PromocionBase`";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += " ORDER BY `PromocionBase` DESC";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H003U5( IGxContext context ,
                                             int A10DistribuidorID ,
                                             GxSimpleCollection<int> AV86ListaDistribuidores )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT `PromocionDistribuidorID`, `DistribuidorID`, `PromocionID` FROM `PromocionDistribuidor`";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV86ListaDistribuidores, "`DistribuidorID` IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `PromocionDistribuidorID`";
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
                     return conditional_H003U2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 1 :
                     return conditional_H003U3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 3 :
                     return conditional_H003U5(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] );
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
          Object[] prmH003U4;
          prmH003U4 = new Object[] {
          new ParDef("@AV198UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH003U2;
          prmH003U2 = new Object[] {
          new ParDef("@AV244Wplistapromocionesasesords_2_tfpromocionid",GXType.Int32,9,0) ,
          new ParDef("@AV245Wplistapromocionesasesords_3_tfpromocionid_to",GXType.Int32,9,0) ,
          new ParDef("@lV246Wplistapromocionesasesords_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV248Wplistapromocionesasesords_6_tfpromocionbase",GXType.Char,700,0) ,
          new ParDef("@AV249Wplistapromocionesasesords_7_tfpromocionbase_sel",GXType.Char,700,0)
          };
          Object[] prmH003U3;
          prmH003U3 = new Object[] {
          new ParDef("@AV244Wplistapromocionesasesords_2_tfpromocionid",GXType.Int32,9,0) ,
          new ParDef("@AV245Wplistapromocionesasesords_3_tfpromocionid_to",GXType.Int32,9,0) ,
          new ParDef("@lV246Wplistapromocionesasesords_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV247Wplistapromocionesasesords_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV248Wplistapromocionesasesords_6_tfpromocionbase",GXType.Char,700,0) ,
          new ParDef("@AV249Wplistapromocionesasesords_7_tfpromocionbase_sel",GXType.Char,700,0)
          };
          Object[] prmH003U5;
          prmH003U5 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H003U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003U2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003U3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003U3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003U4", "SELECT `DistribuidoresUsuarioID`, `UsuarioID`, `DistribuidorID` FROM `DistribuidoresUsuario` WHERE `UsuarioID` = @AV198UsuarioID ORDER BY `UsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003U4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H003U5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003U5,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(1));
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(1));
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
