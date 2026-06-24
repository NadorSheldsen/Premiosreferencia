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
   public class wpfacturamedida : GXDataArea
   {
      public wpfacturamedida( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpfacturamedida( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_FacturaID )
      {
         this.AV34FacturaID = aP0_FacturaID;
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
            gxfirstwebparm = GetFirstPar( "FacturaID");
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
               gxfirstwebparm = GetFirstPar( "FacturaID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "FacturaID");
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
         nRC_GXsfl_22 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_22"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_22_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_22_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_22_idx = GetPar( "sGXsfl_22_idx");
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
         AV34FacturaID = (int)(Math.Round(NumberUtil.Val( GetPar( "FacturaID"), "."), 18, MidpointRounding.ToEven));
         AV49Pgmname = GetPar( "Pgmname");
         AV24TFFacturaMedidaID = (int)(Math.Round(NumberUtil.Val( GetPar( "TFFacturaMedidaID"), "."), 18, MidpointRounding.ToEven));
         AV25TFFacturaMedidaID_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFFacturaMedidaID_To"), "."), 18, MidpointRounding.ToEven));
         AV37TFModeloDescripcion = GetPar( "TFModeloDescripcion");
         AV38TFModeloDescripcion_Sel = GetPar( "TFModeloDescripcion_Sel");
         AV39TFMedidaDescripcion = GetPar( "TFMedidaDescripcion");
         AV40TFMedidaDescripcion_Sel = GetPar( "TFMedidaDescripcion_Sel");
         AV41TFMedidaRin = GetPar( "TFMedidaRin");
         AV42TFMedidaRin_Sel = GetPar( "TFMedidaRin_Sel");
         AV43TFFacturaMedidaCantidad = (short)(Math.Round(NumberUtil.Val( GetPar( "TFFacturaMedidaCantidad"), "."), 18, MidpointRounding.ToEven));
         AV44TFFacturaMedidaCantidad_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFFacturaMedidaCantidad_To"), "."), 18, MidpointRounding.ToEven));
         AV45TFFacturaMedidaPrecio = NumberUtil.Val( GetPar( "TFFacturaMedidaPrecio"), ".");
         AV46TFFacturaMedidaPrecio_To = NumberUtil.Val( GetPar( "TFFacturaMedidaPrecio_To"), ".");
         A49PromocionModeloPrecio = NumberUtil.Val( GetPar( "PromocionModeloPrecio"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV34FacturaID, AV49Pgmname, AV24TFFacturaMedidaID, AV25TFFacturaMedidaID_To, AV37TFModeloDescripcion, AV38TFModeloDescripcion_Sel, AV39TFMedidaDescripcion, AV40TFMedidaDescripcion_Sel, AV41TFMedidaRin, AV42TFMedidaRin_Sel, AV43TFFacturaMedidaCantidad, AV44TFFacturaMedidaCantidad_To, AV45TFFacturaMedidaPrecio, AV46TFFacturaMedidaPrecio_To, A49PromocionModeloPrecio) ;
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
         PA4P2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4P2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpfacturamedida.aspx"+UrlEncode(StringUtil.LTrimStr(AV34FacturaID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpfacturamedida.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34FacturaID), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_22", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_22), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV32GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV28DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV28DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAMEDIDAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24TFFacturaMedidaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAMEDIDAID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25TFFacturaMedidaID_To), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFMODELODESCRIPCION", AV37TFModeloDescripcion);
         GxWebStd.gx_hidden_field( context, "vTFMODELODESCRIPCION_SEL", AV38TFModeloDescripcion_Sel);
         GxWebStd.gx_hidden_field( context, "vTFMEDIDADESCRIPCION", AV39TFMedidaDescripcion);
         GxWebStd.gx_hidden_field( context, "vTFMEDIDADESCRIPCION_SEL", AV40TFMedidaDescripcion_Sel);
         GxWebStd.gx_hidden_field( context, "vTFMEDIDARIN", StringUtil.RTrim( AV41TFMedidaRin));
         GxWebStd.gx_hidden_field( context, "vTFMEDIDARIN_SEL", StringUtil.RTrim( AV42TFMedidaRin_Sel));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAMEDIDACANTIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43TFFacturaMedidaCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAMEDIDACANTIDAD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44TFFacturaMedidaCantidad_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAMEDIDAPRECIO", StringUtil.LTrim( StringUtil.NToC( AV45TFFacturaMedidaPrecio, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFFACTURAMEDIDAPRECIO_TO", StringUtil.LTrim( StringUtil.NToC( AV46TFFacturaMedidaPrecio_To, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, "PROMOCIONMODELOPRECIO", StringUtil.LTrim( StringUtil.NToC( A49PromocionModeloPrecio, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34FacturaID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
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
            WE4P2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4P2( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpfacturamedida.aspx"+UrlEncode(StringUtil.LTrimStr(AV34FacturaID,9,0));
         return formatLink("wpfacturamedida.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WPFacturaMedida" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Factura Medida", "") ;
      }

      protected void WB4P0( )
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
            GxWebStd.gx_div_start( context, divInfo_Internalname, 1, 0, "px", 0, "px", "TableMainPopover", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitle_Internalname, context.GetMessage( "Title", ""), "col-sm-3 SimpleCardAttributeTitleLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_22_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitle_Internalname, AV47Title, StringUtil.RTrim( context.localUtil.Format( AV47Title, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitle_Jsonclick, 0, "SimpleCardAttributeTitle", "", "", "", "", 1, edtavTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPFacturaMedida.htm");
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
            StartGridControl22( ) ;
         }
         if ( wbEnd == 22 )
         {
            wbEnd = 0;
            nRC_GXsfl_22 = (int)(nGXsfl_22_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV30GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV31GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV32GridAppliedFilters);
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
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV28DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 22 )
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

      protected void START4P2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Factura Medida", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4P0( ) ;
      }

      protected void WS4P2( )
      {
         START4P2( ) ;
         EVT4P2( ) ;
      }

      protected void EVT4P2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E114P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E124P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E134P2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_22_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
                              SubsflControlProps_222( ) ;
                              A77FacturaMedidaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaMedidaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A69FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A41PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPromocionID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A26MedidaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMedidaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A22ModeloID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtModeloID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A23ModeloDescripcion = cgiGet( edtModeloDescripcion_Internalname);
                              A28MedidaDescripcion = cgiGet( edtMedidaDescripcion_Internalname);
                              A74MedidaRin = cgiGet( edtMedidaRin_Internalname);
                              A78FacturaMedidaCantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaMedidaCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              AV35BonoUnitario = context.localUtil.CToN( cgiGet( edtavBonounitario_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              AssignAttri("", false, edtavBonounitario_Internalname, StringUtil.LTrimStr( AV35BonoUnitario, 10, 2));
                              AV36BonoTotal = context.localUtil.CToN( cgiGet( edtavBonototal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              AssignAttri("", false, edtavBonototal_Internalname, StringUtil.LTrimStr( AV36BonoTotal, 10, 2));
                              A79FacturaMedidaPrecio = context.localUtil.CToN( cgiGet( edtFacturaMedidaPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E144P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E154P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E164P2 ();
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

      protected void WE4P2( )
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

      protected void PA4P2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpfacturamedida.aspx")), "wpfacturamedida.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpfacturamedida.aspx")))) ;
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
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "FacturaID");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV34FacturaID = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV34FacturaID", StringUtil.LTrimStr( (decimal)(AV34FacturaID), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vFACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34FacturaID), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavTitle_Internalname;
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
         SubsflControlProps_222( ) ;
         while ( nGXsfl_22_idx <= nRC_GXsfl_22 )
         {
            sendrow_222( ) ;
            nGXsfl_22_idx = ((subGrid_Islastpage==1)&&(nGXsfl_22_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_22_idx+1);
            sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
            SubsflControlProps_222( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       int AV34FacturaID ,
                                       string AV49Pgmname ,
                                       int AV24TFFacturaMedidaID ,
                                       int AV25TFFacturaMedidaID_To ,
                                       string AV37TFModeloDescripcion ,
                                       string AV38TFModeloDescripcion_Sel ,
                                       string AV39TFMedidaDescripcion ,
                                       string AV40TFMedidaDescripcion_Sel ,
                                       string AV41TFMedidaRin ,
                                       string AV42TFMedidaRin_Sel ,
                                       short AV43TFFacturaMedidaCantidad ,
                                       short AV44TFFacturaMedidaCantidad_To ,
                                       decimal AV45TFFacturaMedidaPrecio ,
                                       decimal AV46TFFacturaMedidaPrecio_To ,
                                       decimal A49PromocionModeloPrecio )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4P2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
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
         RF4P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV49Pgmname = "WPFacturaMedida";
         edtavTitle_Enabled = 0;
         AssignProp("", false, edtavTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitle_Enabled), 5, 0), true);
         edtavBonounitario_Enabled = 0;
         edtavBonototal_Enabled = 0;
      }

      protected void RF4P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 22;
         /* Execute user event: Refresh */
         E154P2 ();
         nGXsfl_22_idx = 1;
         sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
         SubsflControlProps_222( ) ;
         bGXsfl_22_Refreshing = true;
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
            SubsflControlProps_222( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV50Wpfacturamedidads_1_tffacturamedidaid ,
                                                 AV51Wpfacturamedidads_2_tffacturamedidaid_to ,
                                                 AV53Wpfacturamedidads_4_tfmodelodescripcion_sel ,
                                                 AV52Wpfacturamedidads_3_tfmodelodescripcion ,
                                                 AV55Wpfacturamedidads_6_tfmedidadescripcion_sel ,
                                                 AV54Wpfacturamedidads_5_tfmedidadescripcion ,
                                                 AV57Wpfacturamedidads_8_tfmedidarin_sel ,
                                                 AV56Wpfacturamedidads_7_tfmedidarin ,
                                                 AV58Wpfacturamedidads_9_tffacturamedidacantidad ,
                                                 AV59Wpfacturamedidads_10_tffacturamedidacantidad_to ,
                                                 AV60Wpfacturamedidads_11_tffacturamedidaprecio ,
                                                 AV61Wpfacturamedidads_12_tffacturamedidaprecio_to ,
                                                 A77FacturaMedidaID ,
                                                 A23ModeloDescripcion ,
                                                 A28MedidaDescripcion ,
                                                 A74MedidaRin ,
                                                 A78FacturaMedidaCantidad ,
                                                 A79FacturaMedidaPrecio ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 AV34FacturaID ,
                                                 A69FacturaID } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            lV52Wpfacturamedidads_3_tfmodelodescripcion = StringUtil.Concat( StringUtil.RTrim( AV52Wpfacturamedidads_3_tfmodelodescripcion), "%", "");
            lV54Wpfacturamedidads_5_tfmedidadescripcion = StringUtil.Concat( StringUtil.RTrim( AV54Wpfacturamedidads_5_tfmedidadescripcion), "%", "");
            lV56Wpfacturamedidads_7_tfmedidarin = StringUtil.PadR( StringUtil.RTrim( AV56Wpfacturamedidads_7_tfmedidarin), 20, "%");
            /* Using cursor H004P2 */
            pr_default.execute(0, new Object[] {AV34FacturaID, AV50Wpfacturamedidads_1_tffacturamedidaid, AV51Wpfacturamedidads_2_tffacturamedidaid_to, lV52Wpfacturamedidads_3_tfmodelodescripcion, AV53Wpfacturamedidads_4_tfmodelodescripcion_sel, lV54Wpfacturamedidads_5_tfmedidadescripcion, AV55Wpfacturamedidads_6_tfmedidadescripcion_sel, lV56Wpfacturamedidads_7_tfmedidarin, AV57Wpfacturamedidads_8_tfmedidarin_sel, AV58Wpfacturamedidads_9_tffacturamedidacantidad, AV59Wpfacturamedidads_10_tffacturamedidacantidad_to, AV60Wpfacturamedidads_11_tffacturamedidaprecio, AV61Wpfacturamedidads_12_tffacturamedidaprecio_to, GXPagingFrom2, GXPagingTo2});
            nGXsfl_22_idx = 1;
            sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
            SubsflControlProps_222( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A79FacturaMedidaPrecio = H004P2_A79FacturaMedidaPrecio[0];
               A78FacturaMedidaCantidad = H004P2_A78FacturaMedidaCantidad[0];
               A74MedidaRin = H004P2_A74MedidaRin[0];
               A28MedidaDescripcion = H004P2_A28MedidaDescripcion[0];
               A23ModeloDescripcion = H004P2_A23ModeloDescripcion[0];
               A22ModeloID = H004P2_A22ModeloID[0];
               A26MedidaID = H004P2_A26MedidaID[0];
               A41PromocionID = H004P2_A41PromocionID[0];
               A69FacturaID = H004P2_A69FacturaID[0];
               A77FacturaMedidaID = H004P2_A77FacturaMedidaID[0];
               A74MedidaRin = H004P2_A74MedidaRin[0];
               A28MedidaDescripcion = H004P2_A28MedidaDescripcion[0];
               A22ModeloID = H004P2_A22ModeloID[0];
               A23ModeloDescripcion = H004P2_A23ModeloDescripcion[0];
               A41PromocionID = H004P2_A41PromocionID[0];
               /* Execute user event: Grid.Load */
               E164P2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 22;
            WB4P0( ) ;
         }
         bGXsfl_22_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4P2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
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
         AV50Wpfacturamedidads_1_tffacturamedidaid = AV24TFFacturaMedidaID;
         AV51Wpfacturamedidads_2_tffacturamedidaid_to = AV25TFFacturaMedidaID_To;
         AV52Wpfacturamedidads_3_tfmodelodescripcion = AV37TFModeloDescripcion;
         AV53Wpfacturamedidads_4_tfmodelodescripcion_sel = AV38TFModeloDescripcion_Sel;
         AV54Wpfacturamedidads_5_tfmedidadescripcion = AV39TFMedidaDescripcion;
         AV55Wpfacturamedidads_6_tfmedidadescripcion_sel = AV40TFMedidaDescripcion_Sel;
         AV56Wpfacturamedidads_7_tfmedidarin = AV41TFMedidaRin;
         AV57Wpfacturamedidads_8_tfmedidarin_sel = AV42TFMedidaRin_Sel;
         AV58Wpfacturamedidads_9_tffacturamedidacantidad = AV43TFFacturaMedidaCantidad;
         AV59Wpfacturamedidads_10_tffacturamedidacantidad_to = AV44TFFacturaMedidaCantidad_To;
         AV60Wpfacturamedidads_11_tffacturamedidaprecio = AV45TFFacturaMedidaPrecio;
         AV61Wpfacturamedidads_12_tffacturamedidaprecio_to = AV46TFFacturaMedidaPrecio_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV50Wpfacturamedidads_1_tffacturamedidaid ,
                                              AV51Wpfacturamedidads_2_tffacturamedidaid_to ,
                                              AV53Wpfacturamedidads_4_tfmodelodescripcion_sel ,
                                              AV52Wpfacturamedidads_3_tfmodelodescripcion ,
                                              AV55Wpfacturamedidads_6_tfmedidadescripcion_sel ,
                                              AV54Wpfacturamedidads_5_tfmedidadescripcion ,
                                              AV57Wpfacturamedidads_8_tfmedidarin_sel ,
                                              AV56Wpfacturamedidads_7_tfmedidarin ,
                                              AV58Wpfacturamedidads_9_tffacturamedidacantidad ,
                                              AV59Wpfacturamedidads_10_tffacturamedidacantidad_to ,
                                              AV60Wpfacturamedidads_11_tffacturamedidaprecio ,
                                              AV61Wpfacturamedidads_12_tffacturamedidaprecio_to ,
                                              A77FacturaMedidaID ,
                                              A23ModeloDescripcion ,
                                              A28MedidaDescripcion ,
                                              A74MedidaRin ,
                                              A78FacturaMedidaCantidad ,
                                              A79FacturaMedidaPrecio ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              AV34FacturaID ,
                                              A69FacturaID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV52Wpfacturamedidads_3_tfmodelodescripcion = StringUtil.Concat( StringUtil.RTrim( AV52Wpfacturamedidads_3_tfmodelodescripcion), "%", "");
         lV54Wpfacturamedidads_5_tfmedidadescripcion = StringUtil.Concat( StringUtil.RTrim( AV54Wpfacturamedidads_5_tfmedidadescripcion), "%", "");
         lV56Wpfacturamedidads_7_tfmedidarin = StringUtil.PadR( StringUtil.RTrim( AV56Wpfacturamedidads_7_tfmedidarin), 20, "%");
         /* Using cursor H004P3 */
         pr_default.execute(1, new Object[] {AV34FacturaID, AV50Wpfacturamedidads_1_tffacturamedidaid, AV51Wpfacturamedidads_2_tffacturamedidaid_to, lV52Wpfacturamedidads_3_tfmodelodescripcion, AV53Wpfacturamedidads_4_tfmodelodescripcion_sel, lV54Wpfacturamedidads_5_tfmedidadescripcion, AV55Wpfacturamedidads_6_tfmedidadescripcion_sel, lV56Wpfacturamedidads_7_tfmedidarin, AV57Wpfacturamedidads_8_tfmedidarin_sel, AV58Wpfacturamedidads_9_tffacturamedidacantidad, AV59Wpfacturamedidads_10_tffacturamedidacantidad_to, AV60Wpfacturamedidads_11_tffacturamedidaprecio, AV61Wpfacturamedidads_12_tffacturamedidaprecio_to});
         GRID_nRecordCount = H004P3_AGRID_nRecordCount[0];
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
         AV50Wpfacturamedidads_1_tffacturamedidaid = AV24TFFacturaMedidaID;
         AV51Wpfacturamedidads_2_tffacturamedidaid_to = AV25TFFacturaMedidaID_To;
         AV52Wpfacturamedidads_3_tfmodelodescripcion = AV37TFModeloDescripcion;
         AV53Wpfacturamedidads_4_tfmodelodescripcion_sel = AV38TFModeloDescripcion_Sel;
         AV54Wpfacturamedidads_5_tfmedidadescripcion = AV39TFMedidaDescripcion;
         AV55Wpfacturamedidads_6_tfmedidadescripcion_sel = AV40TFMedidaDescripcion_Sel;
         AV56Wpfacturamedidads_7_tfmedidarin = AV41TFMedidaRin;
         AV57Wpfacturamedidads_8_tfmedidarin_sel = AV42TFMedidaRin_Sel;
         AV58Wpfacturamedidads_9_tffacturamedidacantidad = AV43TFFacturaMedidaCantidad;
         AV59Wpfacturamedidads_10_tffacturamedidacantidad_to = AV44TFFacturaMedidaCantidad_To;
         AV60Wpfacturamedidads_11_tffacturamedidaprecio = AV45TFFacturaMedidaPrecio;
         AV61Wpfacturamedidads_12_tffacturamedidaprecio_to = AV46TFFacturaMedidaPrecio_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV34FacturaID, AV49Pgmname, AV24TFFacturaMedidaID, AV25TFFacturaMedidaID_To, AV37TFModeloDescripcion, AV38TFModeloDescripcion_Sel, AV39TFMedidaDescripcion, AV40TFMedidaDescripcion_Sel, AV41TFMedidaRin, AV42TFMedidaRin_Sel, AV43TFFacturaMedidaCantidad, AV44TFFacturaMedidaCantidad_To, AV45TFFacturaMedidaPrecio, AV46TFFacturaMedidaPrecio_To, A49PromocionModeloPrecio) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV50Wpfacturamedidads_1_tffacturamedidaid = AV24TFFacturaMedidaID;
         AV51Wpfacturamedidads_2_tffacturamedidaid_to = AV25TFFacturaMedidaID_To;
         AV52Wpfacturamedidads_3_tfmodelodescripcion = AV37TFModeloDescripcion;
         AV53Wpfacturamedidads_4_tfmodelodescripcion_sel = AV38TFModeloDescripcion_Sel;
         AV54Wpfacturamedidads_5_tfmedidadescripcion = AV39TFMedidaDescripcion;
         AV55Wpfacturamedidads_6_tfmedidadescripcion_sel = AV40TFMedidaDescripcion_Sel;
         AV56Wpfacturamedidads_7_tfmedidarin = AV41TFMedidaRin;
         AV57Wpfacturamedidads_8_tfmedidarin_sel = AV42TFMedidaRin_Sel;
         AV58Wpfacturamedidads_9_tffacturamedidacantidad = AV43TFFacturaMedidaCantidad;
         AV59Wpfacturamedidads_10_tffacturamedidacantidad_to = AV44TFFacturaMedidaCantidad_To;
         AV60Wpfacturamedidads_11_tffacturamedidaprecio = AV45TFFacturaMedidaPrecio;
         AV61Wpfacturamedidads_12_tffacturamedidaprecio_to = AV46TFFacturaMedidaPrecio_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV34FacturaID, AV49Pgmname, AV24TFFacturaMedidaID, AV25TFFacturaMedidaID_To, AV37TFModeloDescripcion, AV38TFModeloDescripcion_Sel, AV39TFMedidaDescripcion, AV40TFMedidaDescripcion_Sel, AV41TFMedidaRin, AV42TFMedidaRin_Sel, AV43TFFacturaMedidaCantidad, AV44TFFacturaMedidaCantidad_To, AV45TFFacturaMedidaPrecio, AV46TFFacturaMedidaPrecio_To, A49PromocionModeloPrecio) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV50Wpfacturamedidads_1_tffacturamedidaid = AV24TFFacturaMedidaID;
         AV51Wpfacturamedidads_2_tffacturamedidaid_to = AV25TFFacturaMedidaID_To;
         AV52Wpfacturamedidads_3_tfmodelodescripcion = AV37TFModeloDescripcion;
         AV53Wpfacturamedidads_4_tfmodelodescripcion_sel = AV38TFModeloDescripcion_Sel;
         AV54Wpfacturamedidads_5_tfmedidadescripcion = AV39TFMedidaDescripcion;
         AV55Wpfacturamedidads_6_tfmedidadescripcion_sel = AV40TFMedidaDescripcion_Sel;
         AV56Wpfacturamedidads_7_tfmedidarin = AV41TFMedidaRin;
         AV57Wpfacturamedidads_8_tfmedidarin_sel = AV42TFMedidaRin_Sel;
         AV58Wpfacturamedidads_9_tffacturamedidacantidad = AV43TFFacturaMedidaCantidad;
         AV59Wpfacturamedidads_10_tffacturamedidacantidad_to = AV44TFFacturaMedidaCantidad_To;
         AV60Wpfacturamedidads_11_tffacturamedidaprecio = AV45TFFacturaMedidaPrecio;
         AV61Wpfacturamedidads_12_tffacturamedidaprecio_to = AV46TFFacturaMedidaPrecio_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV34FacturaID, AV49Pgmname, AV24TFFacturaMedidaID, AV25TFFacturaMedidaID_To, AV37TFModeloDescripcion, AV38TFModeloDescripcion_Sel, AV39TFMedidaDescripcion, AV40TFMedidaDescripcion_Sel, AV41TFMedidaRin, AV42TFMedidaRin_Sel, AV43TFFacturaMedidaCantidad, AV44TFFacturaMedidaCantidad_To, AV45TFFacturaMedidaPrecio, AV46TFFacturaMedidaPrecio_To, A49PromocionModeloPrecio) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV50Wpfacturamedidads_1_tffacturamedidaid = AV24TFFacturaMedidaID;
         AV51Wpfacturamedidads_2_tffacturamedidaid_to = AV25TFFacturaMedidaID_To;
         AV52Wpfacturamedidads_3_tfmodelodescripcion = AV37TFModeloDescripcion;
         AV53Wpfacturamedidads_4_tfmodelodescripcion_sel = AV38TFModeloDescripcion_Sel;
         AV54Wpfacturamedidads_5_tfmedidadescripcion = AV39TFMedidaDescripcion;
         AV55Wpfacturamedidads_6_tfmedidadescripcion_sel = AV40TFMedidaDescripcion_Sel;
         AV56Wpfacturamedidads_7_tfmedidarin = AV41TFMedidaRin;
         AV57Wpfacturamedidads_8_tfmedidarin_sel = AV42TFMedidaRin_Sel;
         AV58Wpfacturamedidads_9_tffacturamedidacantidad = AV43TFFacturaMedidaCantidad;
         AV59Wpfacturamedidads_10_tffacturamedidacantidad_to = AV44TFFacturaMedidaCantidad_To;
         AV60Wpfacturamedidads_11_tffacturamedidaprecio = AV45TFFacturaMedidaPrecio;
         AV61Wpfacturamedidads_12_tffacturamedidaprecio_to = AV46TFFacturaMedidaPrecio_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV34FacturaID, AV49Pgmname, AV24TFFacturaMedidaID, AV25TFFacturaMedidaID_To, AV37TFModeloDescripcion, AV38TFModeloDescripcion_Sel, AV39TFMedidaDescripcion, AV40TFMedidaDescripcion_Sel, AV41TFMedidaRin, AV42TFMedidaRin_Sel, AV43TFFacturaMedidaCantidad, AV44TFFacturaMedidaCantidad_To, AV45TFFacturaMedidaPrecio, AV46TFFacturaMedidaPrecio_To, A49PromocionModeloPrecio) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV50Wpfacturamedidads_1_tffacturamedidaid = AV24TFFacturaMedidaID;
         AV51Wpfacturamedidads_2_tffacturamedidaid_to = AV25TFFacturaMedidaID_To;
         AV52Wpfacturamedidads_3_tfmodelodescripcion = AV37TFModeloDescripcion;
         AV53Wpfacturamedidads_4_tfmodelodescripcion_sel = AV38TFModeloDescripcion_Sel;
         AV54Wpfacturamedidads_5_tfmedidadescripcion = AV39TFMedidaDescripcion;
         AV55Wpfacturamedidads_6_tfmedidadescripcion_sel = AV40TFMedidaDescripcion_Sel;
         AV56Wpfacturamedidads_7_tfmedidarin = AV41TFMedidaRin;
         AV57Wpfacturamedidads_8_tfmedidarin_sel = AV42TFMedidaRin_Sel;
         AV58Wpfacturamedidads_9_tffacturamedidacantidad = AV43TFFacturaMedidaCantidad;
         AV59Wpfacturamedidads_10_tffacturamedidacantidad_to = AV44TFFacturaMedidaCantidad_To;
         AV60Wpfacturamedidads_11_tffacturamedidaprecio = AV45TFFacturaMedidaPrecio;
         AV61Wpfacturamedidads_12_tffacturamedidaprecio_to = AV46TFFacturaMedidaPrecio_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV34FacturaID, AV49Pgmname, AV24TFFacturaMedidaID, AV25TFFacturaMedidaID_To, AV37TFModeloDescripcion, AV38TFModeloDescripcion_Sel, AV39TFMedidaDescripcion, AV40TFMedidaDescripcion_Sel, AV41TFMedidaRin, AV42TFMedidaRin_Sel, AV43TFFacturaMedidaCantidad, AV44TFFacturaMedidaCantidad_To, AV45TFFacturaMedidaPrecio, AV46TFFacturaMedidaPrecio_To, A49PromocionModeloPrecio) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV49Pgmname = "WPFacturaMedida";
         edtavTitle_Enabled = 0;
         AssignProp("", false, edtavTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitle_Enabled), 5, 0), true);
         edtavBonounitario_Enabled = 0;
         edtavBonototal_Enabled = 0;
         edtFacturaMedidaID_Enabled = 0;
         edtFacturaID_Enabled = 0;
         edtPromocionID_Enabled = 0;
         edtMedidaID_Enabled = 0;
         edtModeloID_Enabled = 0;
         edtModeloDescripcion_Enabled = 0;
         edtMedidaDescripcion_Enabled = 0;
         edtMedidaRin_Enabled = 0;
         edtFacturaMedidaCantidad_Enabled = 0;
         edtFacturaMedidaPrecio_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E144P2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV28DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_22 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_22"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV30GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV31GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV32GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            /* Read variables values. */
            AV47Title = cgiGet( edtavTitle_Internalname);
            AssignAttri("", false, "AV47Title", AV47Title);
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
         E144P2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E144P2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Factura Medida", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
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
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV28DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV28DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         new obtienetotalpartidas(context ).execute(  AV34FacturaID, out  AV48Precio) ;
         AV47Title = StringUtil.Format( context.GetMessage( "Bono total: $%1", ""), StringUtil.Str( AV48Precio, 10, 2), "", "", "", "", "", "", "", "");
         AssignAttri("", false, "AV47Title", AV47Title);
      }

      protected void E154P2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV30GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV30GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV30GridCurrentPage), 10, 0));
         AV31GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV31GridPageCount", StringUtil.LTrimStr( (decimal)(AV31GridPageCount), 10, 0));
         GXt_char2 = AV32GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV49Pgmname, out  GXt_char2) ;
         AV32GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV32GridAppliedFilters", AV32GridAppliedFilters);
         AV50Wpfacturamedidads_1_tffacturamedidaid = AV24TFFacturaMedidaID;
         AV51Wpfacturamedidads_2_tffacturamedidaid_to = AV25TFFacturaMedidaID_To;
         AV52Wpfacturamedidads_3_tfmodelodescripcion = AV37TFModeloDescripcion;
         AV53Wpfacturamedidads_4_tfmodelodescripcion_sel = AV38TFModeloDescripcion_Sel;
         AV54Wpfacturamedidads_5_tfmedidadescripcion = AV39TFMedidaDescripcion;
         AV55Wpfacturamedidads_6_tfmedidadescripcion_sel = AV40TFMedidaDescripcion_Sel;
         AV56Wpfacturamedidads_7_tfmedidarin = AV41TFMedidaRin;
         AV57Wpfacturamedidads_8_tfmedidarin_sel = AV42TFMedidaRin_Sel;
         AV58Wpfacturamedidads_9_tffacturamedidacantidad = AV43TFFacturaMedidaCantidad;
         AV59Wpfacturamedidads_10_tffacturamedidacantidad_to = AV44TFFacturaMedidaCantidad_To;
         AV60Wpfacturamedidads_11_tffacturamedidaprecio = AV45TFFacturaMedidaPrecio;
         AV61Wpfacturamedidads_12_tffacturamedidaprecio_to = AV46TFFacturaMedidaPrecio_To;
         /*  Sending Event outputs  */
      }

      protected void E114P2( )
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
            AV29PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV29PageToGo) ;
         }
      }

      protected void E124P2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E134P2( )
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
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaMedidaID") == 0 )
            {
               AV24TFFacturaMedidaID = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24TFFacturaMedidaID", StringUtil.LTrimStr( (decimal)(AV24TFFacturaMedidaID), 9, 0));
               AV25TFFacturaMedidaID_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFFacturaMedidaID_To", StringUtil.LTrimStr( (decimal)(AV25TFFacturaMedidaID_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ModeloDescripcion") == 0 )
            {
               AV37TFModeloDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFModeloDescripcion", AV37TFModeloDescripcion);
               AV38TFModeloDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFModeloDescripcion_Sel", AV38TFModeloDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MedidaDescripcion") == 0 )
            {
               AV39TFMedidaDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV39TFMedidaDescripcion", AV39TFMedidaDescripcion);
               AV40TFMedidaDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFMedidaDescripcion_Sel", AV40TFMedidaDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MedidaRin") == 0 )
            {
               AV41TFMedidaRin = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFMedidaRin", AV41TFMedidaRin);
               AV42TFMedidaRin_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFMedidaRin_Sel", AV42TFMedidaRin_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaMedidaCantidad") == 0 )
            {
               AV43TFFacturaMedidaCantidad = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV43TFFacturaMedidaCantidad", StringUtil.LTrimStr( (decimal)(AV43TFFacturaMedidaCantidad), 4, 0));
               AV44TFFacturaMedidaCantidad_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFFacturaMedidaCantidad_To", StringUtil.LTrimStr( (decimal)(AV44TFFacturaMedidaCantidad_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaMedidaPrecio") == 0 )
            {
               AV45TFFacturaMedidaPrecio = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV45TFFacturaMedidaPrecio", StringUtil.LTrimStr( AV45TFFacturaMedidaPrecio, 10, 2));
               AV46TFFacturaMedidaPrecio_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV46TFFacturaMedidaPrecio_To", StringUtil.LTrimStr( AV46TFFacturaMedidaPrecio_To, 10, 2));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E164P2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         /* Using cursor H004P4 */
         pr_default.execute(2, new Object[] {A22ModeloID, A41PromocionID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A41PromocionID = H004P4_A41PromocionID[0];
            A22ModeloID = H004P4_A22ModeloID[0];
            A49PromocionModeloPrecio = H004P4_A49PromocionModeloPrecio[0];
            AV35BonoUnitario = A49PromocionModeloPrecio;
            AssignAttri("", false, edtavBonounitario_Internalname, StringUtil.LTrimStr( AV35BonoUnitario, 10, 2));
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV36BonoTotal = (decimal)(AV35BonoUnitario*A78FacturaMedidaCantidad);
         AssignAttri("", false, edtavBonototal_Internalname, StringUtil.LTrimStr( AV36BonoTotal, 10, 2));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 22;
         }
         sendrow_222( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_22_Refreshing )
         {
            DoAjaxLoad(22, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20Session.Get(AV49Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV49Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV20Session.Get(AV49Pgmname+"GridState"), null, "", "");
         }
         AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV63GXV1 = 1;
         while ( AV63GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV63GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURAMEDIDAID") == 0 )
            {
               AV24TFFacturaMedidaID = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24TFFacturaMedidaID", StringUtil.LTrimStr( (decimal)(AV24TFFacturaMedidaID), 9, 0));
               AV25TFFacturaMedidaID_To = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFFacturaMedidaID_To", StringUtil.LTrimStr( (decimal)(AV25TFFacturaMedidaID_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMODELODESCRIPCION") == 0 )
            {
               AV37TFModeloDescripcion = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFModeloDescripcion", AV37TFModeloDescripcion);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMODELODESCRIPCION_SEL") == 0 )
            {
               AV38TFModeloDescripcion_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFModeloDescripcion_Sel", AV38TFModeloDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMEDIDADESCRIPCION") == 0 )
            {
               AV39TFMedidaDescripcion = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFMedidaDescripcion", AV39TFMedidaDescripcion);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMEDIDADESCRIPCION_SEL") == 0 )
            {
               AV40TFMedidaDescripcion_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFMedidaDescripcion_Sel", AV40TFMedidaDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMEDIDARIN") == 0 )
            {
               AV41TFMedidaRin = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFMedidaRin", AV41TFMedidaRin);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMEDIDARIN_SEL") == 0 )
            {
               AV42TFMedidaRin_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFMedidaRin_Sel", AV42TFMedidaRin_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURAMEDIDACANTIDAD") == 0 )
            {
               AV43TFFacturaMedidaCantidad = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV43TFFacturaMedidaCantidad", StringUtil.LTrimStr( (decimal)(AV43TFFacturaMedidaCantidad), 4, 0));
               AV44TFFacturaMedidaCantidad_To = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFFacturaMedidaCantidad_To", StringUtil.LTrimStr( (decimal)(AV44TFFacturaMedidaCantidad_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURAMEDIDAPRECIO") == 0 )
            {
               AV45TFFacturaMedidaPrecio = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV45TFFacturaMedidaPrecio", StringUtil.LTrimStr( AV45TFFacturaMedidaPrecio, 10, 2));
               AV46TFFacturaMedidaPrecio_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV46TFFacturaMedidaPrecio_To", StringUtil.LTrimStr( AV46TFFacturaMedidaPrecio_To, 10, 2));
            }
            AV63GXV1 = (int)(AV63GXV1+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFModeloDescripcion_Sel)),  AV38TFModeloDescripcion_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFMedidaDescripcion_Sel)),  AV40TFMedidaDescripcion_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFMedidaRin_Sel)),  AV42TFMedidaRin_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char3+"|"+GXt_char4+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFModeloDescripcion)),  AV37TFModeloDescripcion, out  GXt_char4) ;
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFMedidaDescripcion)),  AV39TFMedidaDescripcion, out  GXt_char3) ;
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFMedidaRin)),  AV41TFMedidaRin, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((0==AV24TFFacturaMedidaID) ? "" : StringUtil.Str( (decimal)(AV24TFFacturaMedidaID), 9, 0))+"|"+GXt_char4+"|"+GXt_char3+"|"+GXt_char2+"|"+((0==AV43TFFacturaMedidaCantidad) ? "" : StringUtil.Str( (decimal)(AV43TFFacturaMedidaCantidad), 4, 0))+"|"+((Convert.ToDecimal(0)==AV45TFFacturaMedidaPrecio) ? "" : StringUtil.Str( AV45TFFacturaMedidaPrecio, 10, 2));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV25TFFacturaMedidaID_To) ? "" : StringUtil.Str( (decimal)(AV25TFFacturaMedidaID_To), 9, 0))+"||||"+((0==AV44TFFacturaMedidaCantidad_To) ? "" : StringUtil.Str( (decimal)(AV44TFFacturaMedidaCantidad_To), 4, 0))+"|"+((Convert.ToDecimal(0)==AV46TFFacturaMedidaPrecio_To) ? "" : StringUtil.Str( AV46TFFacturaMedidaPrecio_To, 10, 2));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV20Session.Get(AV49Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFACTURAMEDIDAID",  context.GetMessage( "Medida ID", ""),  !((0==AV24TFFacturaMedidaID)&&(0==AV25TFFacturaMedidaID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV24TFFacturaMedidaID), 9, 0)),  ((0==AV24TFFacturaMedidaID) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV24TFFacturaMedidaID), "ZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV25TFFacturaMedidaID_To), 9, 0)),  ((0==AV25TFFacturaMedidaID_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV25TFFacturaMedidaID_To), "ZZZZZZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFMODELODESCRIPCION",  context.GetMessage( "Modelo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFModeloDescripcion)),  0,  AV37TFModeloDescripcion,  AV37TFModeloDescripcion,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFModeloDescripcion_Sel)),  AV38TFModeloDescripcion_Sel,  AV38TFModeloDescripcion_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFMEDIDADESCRIPCION",  context.GetMessage( "Medida", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFMedidaDescripcion)),  0,  AV39TFMedidaDescripcion,  AV39TFMedidaDescripcion,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFMedidaDescripcion_Sel)),  AV40TFMedidaDescripcion_Sel,  AV40TFMedidaDescripcion_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFMEDIDARIN",  context.GetMessage( "Rin", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFMedidaRin)),  0,  AV41TFMedidaRin,  AV41TFMedidaRin,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFMedidaRin_Sel)),  AV42TFMedidaRin_Sel,  AV42TFMedidaRin_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFACTURAMEDIDACANTIDAD",  context.GetMessage( "Cantidad", ""),  !((0==AV43TFFacturaMedidaCantidad)&&(0==AV44TFFacturaMedidaCantidad_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV43TFFacturaMedidaCantidad), 4, 0)),  ((0==AV43TFFacturaMedidaCantidad) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV43TFFacturaMedidaCantidad), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV44TFFacturaMedidaCantidad_To), 4, 0)),  ((0==AV44TFFacturaMedidaCantidad_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV44TFFacturaMedidaCantidad_To), "ZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFACTURAMEDIDAPRECIO",  context.GetMessage( "Precio Unitario", ""),  !((Convert.ToDecimal(0)==AV45TFFacturaMedidaPrecio)&&(Convert.ToDecimal(0)==AV46TFFacturaMedidaPrecio_To)),  0,  StringUtil.Trim( StringUtil.Str( AV45TFFacturaMedidaPrecio, 10, 2)),  ((Convert.ToDecimal(0)==AV45TFFacturaMedidaPrecio) ? "" : StringUtil.Trim( context.localUtil.Format( AV45TFFacturaMedidaPrecio, "$ Z,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV46TFFacturaMedidaPrecio_To, 10, 2)),  ((Convert.ToDecimal(0)==AV46TFFacturaMedidaPrecio_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV46TFFacturaMedidaPrecio_To, "$ Z,ZZZ,ZZ9.99")))) ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV49Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV49Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "FacturaMedida";
         AV20Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV34FacturaID = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV34FacturaID", StringUtil.LTrimStr( (decimal)(AV34FacturaID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vFACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34FacturaID), "ZZZZZZZZ9"), context));
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
         PA4P2( ) ;
         WS4P2( ) ;
         WE4P2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202651111311068", true, true);
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
         context.AddJavascriptSource("wpfacturamedida.js", "?202651111311068", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_222( )
      {
         edtFacturaMedidaID_Internalname = "FACTURAMEDIDAID_"+sGXsfl_22_idx;
         edtFacturaID_Internalname = "FACTURAID_"+sGXsfl_22_idx;
         edtPromocionID_Internalname = "PROMOCIONID_"+sGXsfl_22_idx;
         edtMedidaID_Internalname = "MEDIDAID_"+sGXsfl_22_idx;
         edtModeloID_Internalname = "MODELOID_"+sGXsfl_22_idx;
         edtModeloDescripcion_Internalname = "MODELODESCRIPCION_"+sGXsfl_22_idx;
         edtMedidaDescripcion_Internalname = "MEDIDADESCRIPCION_"+sGXsfl_22_idx;
         edtMedidaRin_Internalname = "MEDIDARIN_"+sGXsfl_22_idx;
         edtFacturaMedidaCantidad_Internalname = "FACTURAMEDIDACANTIDAD_"+sGXsfl_22_idx;
         edtavBonounitario_Internalname = "vBONOUNITARIO_"+sGXsfl_22_idx;
         edtavBonototal_Internalname = "vBONOTOTAL_"+sGXsfl_22_idx;
         edtFacturaMedidaPrecio_Internalname = "FACTURAMEDIDAPRECIO_"+sGXsfl_22_idx;
      }

      protected void SubsflControlProps_fel_222( )
      {
         edtFacturaMedidaID_Internalname = "FACTURAMEDIDAID_"+sGXsfl_22_fel_idx;
         edtFacturaID_Internalname = "FACTURAID_"+sGXsfl_22_fel_idx;
         edtPromocionID_Internalname = "PROMOCIONID_"+sGXsfl_22_fel_idx;
         edtMedidaID_Internalname = "MEDIDAID_"+sGXsfl_22_fel_idx;
         edtModeloID_Internalname = "MODELOID_"+sGXsfl_22_fel_idx;
         edtModeloDescripcion_Internalname = "MODELODESCRIPCION_"+sGXsfl_22_fel_idx;
         edtMedidaDescripcion_Internalname = "MEDIDADESCRIPCION_"+sGXsfl_22_fel_idx;
         edtMedidaRin_Internalname = "MEDIDARIN_"+sGXsfl_22_fel_idx;
         edtFacturaMedidaCantidad_Internalname = "FACTURAMEDIDACANTIDAD_"+sGXsfl_22_fel_idx;
         edtavBonounitario_Internalname = "vBONOUNITARIO_"+sGXsfl_22_fel_idx;
         edtavBonototal_Internalname = "vBONOTOTAL_"+sGXsfl_22_fel_idx;
         edtFacturaMedidaPrecio_Internalname = "FACTURAMEDIDAPRECIO_"+sGXsfl_22_fel_idx;
      }

      protected void sendrow_222( )
      {
         sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
         SubsflControlProps_222( ) ;
         WB4P0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_22_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_22_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_22_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaMedidaID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A77FacturaMedidaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A77FacturaMedidaID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaMedidaID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidaID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A26MedidaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A26MedidaID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidaID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtModeloID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A22ModeloID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A22ModeloID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtModeloID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtModeloDescripcion_Internalname,(string)A23ModeloDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtModeloDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidaDescripcion_Internalname,(string)A28MedidaDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidaDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidaRin_Internalname,StringUtil.RTrim( A74MedidaRin),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidaRin_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaMedidaCantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A78FacturaMedidaCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A78FacturaMedidaCantidad), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaMedidaCantidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_22_idx + "',22)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBonounitario_Internalname,StringUtil.LTrim( StringUtil.NToC( AV35BonoUnitario, 14, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavBonounitario_Enabled!=0) ? context.localUtil.Format( AV35BonoUnitario, "$ Z,ZZZ,ZZ9.99") : context.localUtil.Format( AV35BonoUnitario, "$ Z,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,32);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavBonounitario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavBonounitario_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_22_idx + "',22)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBonototal_Internalname,StringUtil.LTrim( StringUtil.NToC( AV36BonoTotal, 14, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavBonototal_Enabled!=0) ? context.localUtil.Format( AV36BonoTotal, "$ Z,ZZZ,ZZ9.99") : context.localUtil.Format( AV36BonoTotal, "$ Z,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,33);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavBonototal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavBonototal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaMedidaPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( A79FacturaMedidaPrecio, 14, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A79FacturaMedidaPrecio, "$ Z,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaMedidaPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes4P2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_22_idx = ((subGrid_Islastpage==1)&&(nGXsfl_22_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_22_idx+1);
            sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
            SubsflControlProps_222( ) ;
         }
         /* End function sendrow_222 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl22( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"22\">") ;
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
            context.SendWebValue( context.GetMessage( "Medida ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Modelo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Medida", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rin", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Cantidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Bono Unitario", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Bono Total", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio Unitario", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A77FacturaMedidaID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A26MedidaID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22ModeloID), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A23ModeloDescripcion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A28MedidaDescripcion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A74MedidaRin)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A78FacturaMedidaCantidad), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( AV35BonoUnitario, 14, 2, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBonounitario_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( AV36BonoTotal, 14, 2, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBonototal_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A79FacturaMedidaPrecio, 14, 2, ".", ""))));
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
         edtavTitle_Internalname = "vTITLE";
         divInfo_Internalname = "INFO";
         edtFacturaMedidaID_Internalname = "FACTURAMEDIDAID";
         edtFacturaID_Internalname = "FACTURAID";
         edtPromocionID_Internalname = "PROMOCIONID";
         edtMedidaID_Internalname = "MEDIDAID";
         edtModeloID_Internalname = "MODELOID";
         edtModeloDescripcion_Internalname = "MODELODESCRIPCION";
         edtMedidaDescripcion_Internalname = "MEDIDADESCRIPCION";
         edtMedidaRin_Internalname = "MEDIDARIN";
         edtFacturaMedidaCantidad_Internalname = "FACTURAMEDIDACANTIDAD";
         edtavBonounitario_Internalname = "vBONOUNITARIO";
         edtavBonototal_Internalname = "vBONOTOTAL";
         edtFacturaMedidaPrecio_Internalname = "FACTURAMEDIDAPRECIO";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
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
         edtFacturaMedidaPrecio_Jsonclick = "";
         edtavBonototal_Jsonclick = "";
         edtavBonototal_Enabled = 0;
         edtavBonounitario_Jsonclick = "";
         edtavBonounitario_Enabled = 0;
         edtFacturaMedidaCantidad_Jsonclick = "";
         edtMedidaRin_Jsonclick = "";
         edtMedidaDescripcion_Jsonclick = "";
         edtModeloDescripcion_Jsonclick = "";
         edtModeloID_Jsonclick = "";
         edtMedidaID_Jsonclick = "";
         edtPromocionID_Jsonclick = "";
         edtFacturaID_Jsonclick = "";
         edtFacturaMedidaID_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridNoBorder WorkWith";
         subGrid_Backcolorstyle = 0;
         edtFacturaMedidaPrecio_Enabled = 0;
         edtFacturaMedidaCantidad_Enabled = 0;
         edtMedidaRin_Enabled = 0;
         edtMedidaDescripcion_Enabled = 0;
         edtModeloDescripcion_Enabled = 0;
         edtModeloID_Enabled = 0;
         edtMedidaID_Enabled = 0;
         edtPromocionID_Enabled = 0;
         edtFacturaID_Enabled = 0;
         edtFacturaMedidaID_Enabled = 0;
         subGrid_Sortable = 0;
         edtavTitle_Jsonclick = "";
         edtavTitle_Enabled = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "4.0||||4.0|10.2";
         Ddo_grid_Datalistproc = "WPFacturaMedidaGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic||";
         Ddo_grid_Includedatalist = "|T|T|T||";
         Ddo_grid_Filterisrange = "T||||T|T";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Character|Numeric|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6";
         Ddo_grid_Columnids = "0:FacturaMedidaID|5:ModeloDescripcion|6:MedidaDescripcion|7:MedidaRin|8:FacturaMedidaCantidad|11:FacturaMedidaPrecio";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( " Factura Medida", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"A49PromocionModeloPrecio","fld":"PROMOCIONMODELOPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV34FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFFacturaMedidaID","fld":"vTFFACTURAMEDIDAID","pic":"ZZZZZZZZ9"},{"av":"AV25TFFacturaMedidaID_To","fld":"vTFFACTURAMEDIDAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV37TFModeloDescripcion","fld":"vTFMODELODESCRIPCION"},{"av":"AV38TFModeloDescripcion_Sel","fld":"vTFMODELODESCRIPCION_SEL"},{"av":"AV39TFMedidaDescripcion","fld":"vTFMEDIDADESCRIPCION"},{"av":"AV40TFMedidaDescripcion_Sel","fld":"vTFMEDIDADESCRIPCION_SEL"},{"av":"AV41TFMedidaRin","fld":"vTFMEDIDARIN"},{"av":"AV42TFMedidaRin_Sel","fld":"vTFMEDIDARIN_SEL"},{"av":"AV43TFFacturaMedidaCantidad","fld":"vTFFACTURAMEDIDACANTIDAD","pic":"ZZZ9"},{"av":"AV44TFFacturaMedidaCantidad_To","fld":"vTFFACTURAMEDIDACANTIDAD_TO","pic":"ZZZ9"},{"av":"AV45TFFacturaMedidaPrecio","fld":"vTFFACTURAMEDIDAPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV46TFFacturaMedidaPrecio_To","fld":"vTFFACTURAMEDIDAPRECIO_TO","pic":"$ Z,ZZZ,ZZ9.99"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV30GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV31GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV32GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E114P2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV34FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFFacturaMedidaID","fld":"vTFFACTURAMEDIDAID","pic":"ZZZZZZZZ9"},{"av":"AV25TFFacturaMedidaID_To","fld":"vTFFACTURAMEDIDAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV37TFModeloDescripcion","fld":"vTFMODELODESCRIPCION"},{"av":"AV38TFModeloDescripcion_Sel","fld":"vTFMODELODESCRIPCION_SEL"},{"av":"AV39TFMedidaDescripcion","fld":"vTFMEDIDADESCRIPCION"},{"av":"AV40TFMedidaDescripcion_Sel","fld":"vTFMEDIDADESCRIPCION_SEL"},{"av":"AV41TFMedidaRin","fld":"vTFMEDIDARIN"},{"av":"AV42TFMedidaRin_Sel","fld":"vTFMEDIDARIN_SEL"},{"av":"AV43TFFacturaMedidaCantidad","fld":"vTFFACTURAMEDIDACANTIDAD","pic":"ZZZ9"},{"av":"AV44TFFacturaMedidaCantidad_To","fld":"vTFFACTURAMEDIDACANTIDAD_TO","pic":"ZZZ9"},{"av":"AV45TFFacturaMedidaPrecio","fld":"vTFFACTURAMEDIDAPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV46TFFacturaMedidaPrecio_To","fld":"vTFFACTURAMEDIDAPRECIO_TO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"A49PromocionModeloPrecio","fld":"PROMOCIONMODELOPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E124P2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV34FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFFacturaMedidaID","fld":"vTFFACTURAMEDIDAID","pic":"ZZZZZZZZ9"},{"av":"AV25TFFacturaMedidaID_To","fld":"vTFFACTURAMEDIDAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV37TFModeloDescripcion","fld":"vTFMODELODESCRIPCION"},{"av":"AV38TFModeloDescripcion_Sel","fld":"vTFMODELODESCRIPCION_SEL"},{"av":"AV39TFMedidaDescripcion","fld":"vTFMEDIDADESCRIPCION"},{"av":"AV40TFMedidaDescripcion_Sel","fld":"vTFMEDIDADESCRIPCION_SEL"},{"av":"AV41TFMedidaRin","fld":"vTFMEDIDARIN"},{"av":"AV42TFMedidaRin_Sel","fld":"vTFMEDIDARIN_SEL"},{"av":"AV43TFFacturaMedidaCantidad","fld":"vTFFACTURAMEDIDACANTIDAD","pic":"ZZZ9"},{"av":"AV44TFFacturaMedidaCantidad_To","fld":"vTFFACTURAMEDIDACANTIDAD_TO","pic":"ZZZ9"},{"av":"AV45TFFacturaMedidaPrecio","fld":"vTFFACTURAMEDIDAPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV46TFFacturaMedidaPrecio_To","fld":"vTFFACTURAMEDIDAPRECIO_TO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"A49PromocionModeloPrecio","fld":"PROMOCIONMODELOPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E134P2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV34FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV49Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFFacturaMedidaID","fld":"vTFFACTURAMEDIDAID","pic":"ZZZZZZZZ9"},{"av":"AV25TFFacturaMedidaID_To","fld":"vTFFACTURAMEDIDAID_TO","pic":"ZZZZZZZZ9"},{"av":"AV37TFModeloDescripcion","fld":"vTFMODELODESCRIPCION"},{"av":"AV38TFModeloDescripcion_Sel","fld":"vTFMODELODESCRIPCION_SEL"},{"av":"AV39TFMedidaDescripcion","fld":"vTFMEDIDADESCRIPCION"},{"av":"AV40TFMedidaDescripcion_Sel","fld":"vTFMEDIDADESCRIPCION_SEL"},{"av":"AV41TFMedidaRin","fld":"vTFMEDIDARIN"},{"av":"AV42TFMedidaRin_Sel","fld":"vTFMEDIDARIN_SEL"},{"av":"AV43TFFacturaMedidaCantidad","fld":"vTFFACTURAMEDIDACANTIDAD","pic":"ZZZ9"},{"av":"AV44TFFacturaMedidaCantidad_To","fld":"vTFFACTURAMEDIDACANTIDAD_TO","pic":"ZZZ9"},{"av":"AV45TFFacturaMedidaPrecio","fld":"vTFFACTURAMEDIDAPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV46TFFacturaMedidaPrecio_To","fld":"vTFFACTURAMEDIDAPRECIO_TO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"A49PromocionModeloPrecio","fld":"PROMOCIONMODELOPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV45TFFacturaMedidaPrecio","fld":"vTFFACTURAMEDIDAPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV46TFFacturaMedidaPrecio_To","fld":"vTFFACTURAMEDIDAPRECIO_TO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV43TFFacturaMedidaCantidad","fld":"vTFFACTURAMEDIDACANTIDAD","pic":"ZZZ9"},{"av":"AV44TFFacturaMedidaCantidad_To","fld":"vTFFACTURAMEDIDACANTIDAD_TO","pic":"ZZZ9"},{"av":"AV41TFMedidaRin","fld":"vTFMEDIDARIN"},{"av":"AV42TFMedidaRin_Sel","fld":"vTFMEDIDARIN_SEL"},{"av":"AV39TFMedidaDescripcion","fld":"vTFMEDIDADESCRIPCION"},{"av":"AV40TFMedidaDescripcion_Sel","fld":"vTFMEDIDADESCRIPCION_SEL"},{"av":"AV37TFModeloDescripcion","fld":"vTFMODELODESCRIPCION"},{"av":"AV38TFModeloDescripcion_Sel","fld":"vTFMODELODESCRIPCION_SEL"},{"av":"AV24TFFacturaMedidaID","fld":"vTFFACTURAMEDIDAID","pic":"ZZZZZZZZ9"},{"av":"AV25TFFacturaMedidaID_To","fld":"vTFFACTURAMEDIDAID_TO","pic":"ZZZZZZZZ9"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E164P2","iparms":[{"av":"A22ModeloID","fld":"MODELOID","pic":"ZZZZZZZZ9"},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A49PromocionModeloPrecio","fld":"PROMOCIONMODELOPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"A78FacturaMedidaCantidad","fld":"FACTURAMEDIDACANTIDAD","pic":"ZZZ9"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV35BonoUnitario","fld":"vBONOUNITARIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV36BonoTotal","fld":"vBONOTOTAL","pic":"$ Z,ZZZ,ZZ9.99"}]}""");
         setEventMetadata("VALID_FACTURAID","""{"handler":"Valid_Facturaid","iparms":[]}""");
         setEventMetadata("VALID_MEDIDAID","""{"handler":"Valid_Medidaid","iparms":[]}""");
         setEventMetadata("VALID_MODELOID","""{"handler":"Valid_Modeloid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Facturamedidaprecio","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV49Pgmname = "";
         AV37TFModeloDescripcion = "";
         AV38TFModeloDescripcion_Sel = "";
         AV39TFMedidaDescripcion = "";
         AV40TFMedidaDescripcion_Sel = "";
         AV41TFMedidaRin = "";
         AV42TFMedidaRin_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV32GridAppliedFilters = "";
         AV28DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV47Title = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A23ModeloDescripcion = "";
         A28MedidaDescripcion = "";
         A74MedidaRin = "";
         GXDecQS = "";
         lV52Wpfacturamedidads_3_tfmodelodescripcion = "";
         lV54Wpfacturamedidads_5_tfmedidadescripcion = "";
         lV56Wpfacturamedidads_7_tfmedidarin = "";
         AV53Wpfacturamedidads_4_tfmodelodescripcion_sel = "";
         AV52Wpfacturamedidads_3_tfmodelodescripcion = "";
         AV55Wpfacturamedidads_6_tfmedidadescripcion_sel = "";
         AV54Wpfacturamedidads_5_tfmedidadescripcion = "";
         AV57Wpfacturamedidads_8_tfmedidarin_sel = "";
         AV56Wpfacturamedidads_7_tfmedidarin = "";
         H004P2_A79FacturaMedidaPrecio = new decimal[1] ;
         H004P2_A78FacturaMedidaCantidad = new short[1] ;
         H004P2_A74MedidaRin = new string[] {""} ;
         H004P2_A28MedidaDescripcion = new string[] {""} ;
         H004P2_A23ModeloDescripcion = new string[] {""} ;
         H004P2_A22ModeloID = new int[1] ;
         H004P2_A26MedidaID = new int[1] ;
         H004P2_A41PromocionID = new int[1] ;
         H004P2_A69FacturaID = new int[1] ;
         H004P2_A77FacturaMedidaID = new int[1] ;
         H004P3_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H004P4_A48PromocionModeloID = new int[1] ;
         H004P4_A41PromocionID = new int[1] ;
         H004P4_A22ModeloID = new int[1] ;
         H004P4_A49PromocionModeloPrecio = new decimal[1] ;
         GridRow = new GXWebRow();
         AV20Session = context.GetSession();
         AV10GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV11GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char4 = "";
         GXt_char3 = "";
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpfacturamedida__default(),
            new Object[][] {
                new Object[] {
               H004P2_A79FacturaMedidaPrecio, H004P2_A78FacturaMedidaCantidad, H004P2_A74MedidaRin, H004P2_A28MedidaDescripcion, H004P2_A23ModeloDescripcion, H004P2_A22ModeloID, H004P2_A26MedidaID, H004P2_A41PromocionID, H004P2_A69FacturaID, H004P2_A77FacturaMedidaID
               }
               , new Object[] {
               H004P3_AGRID_nRecordCount
               }
               , new Object[] {
               H004P4_A48PromocionModeloID, H004P4_A41PromocionID, H004P4_A22ModeloID, H004P4_A49PromocionModeloPrecio
               }
            }
         );
         AV49Pgmname = "WPFacturaMedida";
         /* GeneXus formulas. */
         AV49Pgmname = "WPFacturaMedida";
         edtavTitle_Enabled = 0;
         edtavBonounitario_Enabled = 0;
         edtavBonototal_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV12OrderedBy ;
      private short AV43TFFacturaMedidaCantidad ;
      private short AV44TFFacturaMedidaCantidad_To ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A78FacturaMedidaCantidad ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV58Wpfacturamedidads_9_tffacturamedidacantidad ;
      private short AV59Wpfacturamedidads_10_tffacturamedidacantidad_to ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV34FacturaID ;
      private int wcpOAV34FacturaID ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_22 ;
      private int nGXsfl_22_idx=1 ;
      private int AV24TFFacturaMedidaID ;
      private int AV25TFFacturaMedidaID_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavTitle_Enabled ;
      private int A77FacturaMedidaID ;
      private int A69FacturaID ;
      private int A41PromocionID ;
      private int A26MedidaID ;
      private int A22ModeloID ;
      private int subGrid_Islastpage ;
      private int edtavBonounitario_Enabled ;
      private int edtavBonototal_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV50Wpfacturamedidads_1_tffacturamedidaid ;
      private int AV51Wpfacturamedidads_2_tffacturamedidaid_to ;
      private int edtFacturaMedidaID_Enabled ;
      private int edtFacturaID_Enabled ;
      private int edtPromocionID_Enabled ;
      private int edtMedidaID_Enabled ;
      private int edtModeloID_Enabled ;
      private int edtModeloDescripcion_Enabled ;
      private int edtMedidaDescripcion_Enabled ;
      private int edtMedidaRin_Enabled ;
      private int edtFacturaMedidaCantidad_Enabled ;
      private int edtFacturaMedidaPrecio_Enabled ;
      private int AV29PageToGo ;
      private int AV63GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV30GridCurrentPage ;
      private long AV31GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV45TFFacturaMedidaPrecio ;
      private decimal AV46TFFacturaMedidaPrecio_To ;
      private decimal A49PromocionModeloPrecio ;
      private decimal AV35BonoUnitario ;
      private decimal AV36BonoTotal ;
      private decimal A79FacturaMedidaPrecio ;
      private decimal AV60Wpfacturamedidads_11_tffacturamedidaprecio ;
      private decimal AV61Wpfacturamedidads_12_tffacturamedidaprecio_to ;
      private decimal AV48Precio ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_22_idx="0001" ;
      private string AV49Pgmname ;
      private string AV41TFMedidaRin ;
      private string AV42TFMedidaRin_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divInfo_Internalname ;
      private string edtavTitle_Internalname ;
      private string TempTags ;
      private string edtavTitle_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtFacturaMedidaID_Internalname ;
      private string edtFacturaID_Internalname ;
      private string edtPromocionID_Internalname ;
      private string edtMedidaID_Internalname ;
      private string edtModeloID_Internalname ;
      private string edtModeloDescripcion_Internalname ;
      private string edtMedidaDescripcion_Internalname ;
      private string A74MedidaRin ;
      private string edtMedidaRin_Internalname ;
      private string edtFacturaMedidaCantidad_Internalname ;
      private string edtavBonounitario_Internalname ;
      private string edtavBonototal_Internalname ;
      private string edtFacturaMedidaPrecio_Internalname ;
      private string GXDecQS ;
      private string lV56Wpfacturamedidads_7_tfmedidarin ;
      private string AV57Wpfacturamedidads_8_tfmedidarin_sel ;
      private string AV56Wpfacturamedidads_7_tfmedidarin ;
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string sGXsfl_22_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtFacturaMedidaID_Jsonclick ;
      private string edtFacturaID_Jsonclick ;
      private string edtPromocionID_Jsonclick ;
      private string edtMedidaID_Jsonclick ;
      private string edtModeloID_Jsonclick ;
      private string edtModeloDescripcion_Jsonclick ;
      private string edtMedidaDescripcion_Jsonclick ;
      private string edtMedidaRin_Jsonclick ;
      private string edtFacturaMedidaCantidad_Jsonclick ;
      private string edtavBonounitario_Jsonclick ;
      private string edtavBonototal_Jsonclick ;
      private string edtFacturaMedidaPrecio_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_22_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV37TFModeloDescripcion ;
      private string AV38TFModeloDescripcion_Sel ;
      private string AV39TFMedidaDescripcion ;
      private string AV40TFMedidaDescripcion_Sel ;
      private string AV32GridAppliedFilters ;
      private string AV47Title ;
      private string A23ModeloDescripcion ;
      private string A28MedidaDescripcion ;
      private string lV52Wpfacturamedidads_3_tfmodelodescripcion ;
      private string lV54Wpfacturamedidads_5_tfmedidadescripcion ;
      private string AV53Wpfacturamedidads_4_tfmodelodescripcion_sel ;
      private string AV52Wpfacturamedidads_3_tfmodelodescripcion ;
      private string AV55Wpfacturamedidads_6_tfmedidadescripcion_sel ;
      private string AV54Wpfacturamedidads_5_tfmedidadescripcion ;
      private IGxSession AV20Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV28DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private decimal[] H004P2_A79FacturaMedidaPrecio ;
      private short[] H004P2_A78FacturaMedidaCantidad ;
      private string[] H004P2_A74MedidaRin ;
      private string[] H004P2_A28MedidaDescripcion ;
      private string[] H004P2_A23ModeloDescripcion ;
      private int[] H004P2_A22ModeloID ;
      private int[] H004P2_A26MedidaID ;
      private int[] H004P2_A41PromocionID ;
      private int[] H004P2_A69FacturaID ;
      private int[] H004P2_A77FacturaMedidaID ;
      private long[] H004P3_AGRID_nRecordCount ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private int[] H004P4_A48PromocionModeloID ;
      private int[] H004P4_A41PromocionID ;
      private int[] H004P4_A22ModeloID ;
      private decimal[] H004P4_A49PromocionModeloPrecio ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV10GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpfacturamedida__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004P2( IGxContext context ,
                                             int AV50Wpfacturamedidads_1_tffacturamedidaid ,
                                             int AV51Wpfacturamedidads_2_tffacturamedidaid_to ,
                                             string AV53Wpfacturamedidads_4_tfmodelodescripcion_sel ,
                                             string AV52Wpfacturamedidads_3_tfmodelodescripcion ,
                                             string AV55Wpfacturamedidads_6_tfmedidadescripcion_sel ,
                                             string AV54Wpfacturamedidads_5_tfmedidadescripcion ,
                                             string AV57Wpfacturamedidads_8_tfmedidarin_sel ,
                                             string AV56Wpfacturamedidads_7_tfmedidarin ,
                                             short AV58Wpfacturamedidads_9_tffacturamedidacantidad ,
                                             short AV59Wpfacturamedidads_10_tffacturamedidacantidad_to ,
                                             decimal AV60Wpfacturamedidads_11_tffacturamedidaprecio ,
                                             decimal AV61Wpfacturamedidads_12_tffacturamedidaprecio_to ,
                                             int A77FacturaMedidaID ,
                                             string A23ModeloDescripcion ,
                                             string A28MedidaDescripcion ,
                                             string A74MedidaRin ,
                                             short A78FacturaMedidaCantidad ,
                                             decimal A79FacturaMedidaPrecio ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int AV34FacturaID ,
                                             int A69FacturaID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[15];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.`FacturaMedidaPrecio`, T1.`FacturaMedidaCantidad`, T2.`MedidaRin`, T2.`MedidaDescripcion`, T3.`ModeloDescripcion`, T2.`ModeloID`, T1.`MedidaID`, T4.`PromocionID`, T1.`FacturaID`, T1.`FacturaMedidaID`";
         sFromString = " FROM (((`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T3 ON T3.`ModeloID` = T2.`ModeloID`) INNER JOIN `Factura` T4 ON T4.`FacturaID` = T1.`FacturaID`)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.`FacturaID` = @AV34FacturaID)");
         if ( ! (0==AV50Wpfacturamedidads_1_tffacturamedidaid) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaID` >= @AV50Wpfacturamedidads_1_tffacturamedidaid)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (0==AV51Wpfacturamedidads_2_tffacturamedidaid_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaID` <= @AV51Wpfacturamedidads_2_tffacturamedidaid_to)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wpfacturamedidads_4_tfmodelodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wpfacturamedidads_3_tfmodelodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` like @lV52Wpfacturamedidads_3_tfmodelodescripcion)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wpfacturamedidads_4_tfmodelodescripcion_sel)) && ! ( StringUtil.StrCmp(AV53Wpfacturamedidads_4_tfmodelodescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` = @AV53Wpfacturamedidads_4_tfmodelodescripcion_sel)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV53Wpfacturamedidads_4_tfmodelodescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`ModeloDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wpfacturamedidads_6_tfmedidadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wpfacturamedidads_5_tfmedidadescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` like @lV54Wpfacturamedidads_5_tfmedidadescripcion)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wpfacturamedidads_6_tfmedidadescripcion_sel)) && ! ( StringUtil.StrCmp(AV55Wpfacturamedidads_6_tfmedidadescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` = @AV55Wpfacturamedidads_6_tfmedidadescripcion_sel)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wpfacturamedidads_6_tfmedidadescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpfacturamedidads_8_tfmedidarin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wpfacturamedidads_7_tfmedidarin)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` like @lV56Wpfacturamedidads_7_tfmedidarin)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpfacturamedidads_8_tfmedidarin_sel)) && ! ( StringUtil.StrCmp(AV57Wpfacturamedidads_8_tfmedidarin_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` = @AV57Wpfacturamedidads_8_tfmedidarin_sel)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wpfacturamedidads_8_tfmedidarin_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaRin`))=0))");
         }
         if ( ! (0==AV58Wpfacturamedidads_9_tffacturamedidacantidad) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` >= @AV58Wpfacturamedidads_9_tffacturamedidacantidad)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (0==AV59Wpfacturamedidads_10_tffacturamedidacantidad_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` <= @AV59Wpfacturamedidads_10_tffacturamedidacantidad_to)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV60Wpfacturamedidads_11_tffacturamedidaprecio) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` >= @AV60Wpfacturamedidads_11_tffacturamedidaprecio)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Wpfacturamedidads_12_tffacturamedidaprecio_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` <= @AV61Wpfacturamedidads_12_tffacturamedidaprecio_to)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`FacturaMedidaID`";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`FacturaMedidaID` DESC";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T3.`ModeloDescripcion`";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.`ModeloDescripcion` DESC";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T2.`MedidaDescripcion`";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.`MedidaDescripcion` DESC";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T2.`MedidaRin`";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.`MedidaRin` DESC";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`FacturaMedidaCantidad`";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`FacturaMedidaCantidad` DESC";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`FacturaMedidaPrecio`";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`FacturaMedidaPrecio` DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.`FacturaMedidaID`";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " LIMIT " + "@GXPagingFrom2" + ", " + "@GXPagingTo2";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H004P3( IGxContext context ,
                                             int AV50Wpfacturamedidads_1_tffacturamedidaid ,
                                             int AV51Wpfacturamedidads_2_tffacturamedidaid_to ,
                                             string AV53Wpfacturamedidads_4_tfmodelodescripcion_sel ,
                                             string AV52Wpfacturamedidads_3_tfmodelodescripcion ,
                                             string AV55Wpfacturamedidads_6_tfmedidadescripcion_sel ,
                                             string AV54Wpfacturamedidads_5_tfmedidadescripcion ,
                                             string AV57Wpfacturamedidads_8_tfmedidarin_sel ,
                                             string AV56Wpfacturamedidads_7_tfmedidarin ,
                                             short AV58Wpfacturamedidads_9_tffacturamedidacantidad ,
                                             short AV59Wpfacturamedidads_10_tffacturamedidacantidad_to ,
                                             decimal AV60Wpfacturamedidads_11_tffacturamedidaprecio ,
                                             decimal AV61Wpfacturamedidads_12_tffacturamedidaprecio_to ,
                                             int A77FacturaMedidaID ,
                                             string A23ModeloDescripcion ,
                                             string A28MedidaDescripcion ,
                                             string A74MedidaRin ,
                                             short A78FacturaMedidaCantidad ,
                                             decimal A79FacturaMedidaPrecio ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int AV34FacturaID ,
                                             int A69FacturaID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[13];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((`FacturaMedida` T1 INNER JOIN `Medida` T3 ON T3.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T4 ON T4.`ModeloID` = T3.`ModeloID`) INNER JOIN `Factura` T2 ON T2.`FacturaID` = T1.`FacturaID`)";
         AddWhere(sWhereString, "(T1.`FacturaID` = @AV34FacturaID)");
         if ( ! (0==AV50Wpfacturamedidads_1_tffacturamedidaid) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaID` >= @AV50Wpfacturamedidads_1_tffacturamedidaid)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (0==AV51Wpfacturamedidads_2_tffacturamedidaid_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaID` <= @AV51Wpfacturamedidads_2_tffacturamedidaid_to)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wpfacturamedidads_4_tfmodelodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wpfacturamedidads_3_tfmodelodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T4.`ModeloDescripcion` like @lV52Wpfacturamedidads_3_tfmodelodescripcion)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wpfacturamedidads_4_tfmodelodescripcion_sel)) && ! ( StringUtil.StrCmp(AV53Wpfacturamedidads_4_tfmodelodescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.`ModeloDescripcion` = @AV53Wpfacturamedidads_4_tfmodelodescripcion_sel)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( StringUtil.StrCmp(AV53Wpfacturamedidads_4_tfmodelodescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T4.`ModeloDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wpfacturamedidads_6_tfmedidadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wpfacturamedidads_5_tfmedidadescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`MedidaDescripcion` like @lV54Wpfacturamedidads_5_tfmedidadescripcion)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wpfacturamedidads_6_tfmedidadescripcion_sel)) && ! ( StringUtil.StrCmp(AV55Wpfacturamedidads_6_tfmedidadescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`MedidaDescripcion` = @AV55Wpfacturamedidads_6_tfmedidadescripcion_sel)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wpfacturamedidads_6_tfmedidadescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`MedidaDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpfacturamedidads_8_tfmedidarin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wpfacturamedidads_7_tfmedidarin)) ) )
         {
            AddWhere(sWhereString, "(T3.`MedidaRin` like @lV56Wpfacturamedidads_7_tfmedidarin)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpfacturamedidads_8_tfmedidarin_sel)) && ! ( StringUtil.StrCmp(AV57Wpfacturamedidads_8_tfmedidarin_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`MedidaRin` = @AV57Wpfacturamedidads_8_tfmedidarin_sel)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( StringUtil.StrCmp(AV57Wpfacturamedidads_8_tfmedidarin_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`MedidaRin`))=0))");
         }
         if ( ! (0==AV58Wpfacturamedidads_9_tffacturamedidacantidad) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` >= @AV58Wpfacturamedidads_9_tffacturamedidacantidad)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! (0==AV59Wpfacturamedidads_10_tffacturamedidacantidad_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` <= @AV59Wpfacturamedidads_10_tffacturamedidacantidad_to)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV60Wpfacturamedidads_11_tffacturamedidaprecio) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` >= @AV60Wpfacturamedidads_11_tffacturamedidaprecio)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Wpfacturamedidads_12_tffacturamedidaprecio_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` <= @AV61Wpfacturamedidads_12_tffacturamedidaprecio_to)");
         }
         else
         {
            GXv_int7[12] = 1;
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
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
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
                     return conditional_H004P2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (decimal)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] );
               case 1 :
                     return conditional_H004P3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (decimal)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] );
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
          Object[] prmH004P4;
          prmH004P4 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0) ,
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmH004P2;
          prmH004P2 = new Object[] {
          new ParDef("@AV34FacturaID",GXType.Int32,9,0) ,
          new ParDef("@AV50Wpfacturamedidads_1_tffacturamedidaid",GXType.Int32,9,0) ,
          new ParDef("@AV51Wpfacturamedidads_2_tffacturamedidaid_to",GXType.Int32,9,0) ,
          new ParDef("@lV52Wpfacturamedidads_3_tfmodelodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV53Wpfacturamedidads_4_tfmodelodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV54Wpfacturamedidads_5_tfmedidadescripcion",GXType.Char,80,0) ,
          new ParDef("@AV55Wpfacturamedidads_6_tfmedidadescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV56Wpfacturamedidads_7_tfmedidarin",GXType.Char,20,0) ,
          new ParDef("@AV57Wpfacturamedidads_8_tfmedidarin_sel",GXType.Char,20,0) ,
          new ParDef("@AV58Wpfacturamedidads_9_tffacturamedidacantidad",GXType.Int16,4,0) ,
          new ParDef("@AV59Wpfacturamedidads_10_tffacturamedidacantidad_to",GXType.Int16,4,0) ,
          new ParDef("@AV60Wpfacturamedidads_11_tffacturamedidaprecio",GXType.Number,10,2) ,
          new ParDef("@AV61Wpfacturamedidads_12_tffacturamedidaprecio_to",GXType.Number,10,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004P3;
          prmH004P3 = new Object[] {
          new ParDef("@AV34FacturaID",GXType.Int32,9,0) ,
          new ParDef("@AV50Wpfacturamedidads_1_tffacturamedidaid",GXType.Int32,9,0) ,
          new ParDef("@AV51Wpfacturamedidads_2_tffacturamedidaid_to",GXType.Int32,9,0) ,
          new ParDef("@lV52Wpfacturamedidads_3_tfmodelodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV53Wpfacturamedidads_4_tfmodelodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV54Wpfacturamedidads_5_tfmedidadescripcion",GXType.Char,80,0) ,
          new ParDef("@AV55Wpfacturamedidads_6_tfmedidadescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV56Wpfacturamedidads_7_tfmedidarin",GXType.Char,20,0) ,
          new ParDef("@AV57Wpfacturamedidads_8_tfmedidarin_sel",GXType.Char,20,0) ,
          new ParDef("@AV58Wpfacturamedidads_9_tffacturamedidacantidad",GXType.Int16,4,0) ,
          new ParDef("@AV59Wpfacturamedidads_10_tffacturamedidacantidad_to",GXType.Int16,4,0) ,
          new ParDef("@AV60Wpfacturamedidads_11_tffacturamedidaprecio",GXType.Number,10,2) ,
          new ParDef("@AV61Wpfacturamedidads_12_tffacturamedidaprecio_to",GXType.Number,10,2)
          };
          def= new CursorDef[] {
              new CursorDef("H004P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004P2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004P3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004P3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004P4", "SELECT `PromocionModeloID`, `PromocionID`, `ModeloID`, `PromocionModeloPrecio` FROM `PromocionModelo` WHERE (`ModeloID` = @ModeloID) AND (`PromocionID` = @PromocionID) ORDER BY `PromocionModeloID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004P4,1, GxCacheFrequency.OFF ,false,true )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
       }
    }

 }

}
