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
   public class wcpartidasfactura : GXWebComponent
   {
      public wcpartidasfactura( )
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

      public wcpartidasfactura( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_FacturaID )
      {
         this.AV42FacturaID = aP0_FacturaID;
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
                  AV42FacturaID = (int)(Math.Round(NumberUtil.Val( GetPar( "FacturaID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV42FacturaID", StringUtil.LTrimStr( (decimal)(AV42FacturaID), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV42FacturaID});
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
         nRC_GXsfl_15 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_15"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_15_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_15_idx = GetPar( "sGXsfl_15_idx");
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
         AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV42FacturaID = (int)(Math.Round(NumberUtil.Val( GetPar( "FacturaID"), "."), 18, MidpointRounding.ToEven));
         AV47Pgmname = GetPar( "Pgmname");
         AV35TFModeloDescripcion = GetPar( "TFModeloDescripcion");
         AV36TFModeloDescripcion_Sel = GetPar( "TFModeloDescripcion_Sel");
         AV37TFMedidaDescripcion = GetPar( "TFMedidaDescripcion");
         AV38TFMedidaDescripcion_Sel = GetPar( "TFMedidaDescripcion_Sel");
         AV39TFMedidaRin = GetPar( "TFMedidaRin");
         AV40TFMedidaRin_Sel = GetPar( "TFMedidaRin_Sel");
         AV19TFFacturaMedidaCantidad = (short)(Math.Round(NumberUtil.Val( GetPar( "TFFacturaMedidaCantidad"), "."), 18, MidpointRounding.ToEven));
         AV20TFFacturaMedidaCantidad_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFFacturaMedidaCantidad_To"), "."), 18, MidpointRounding.ToEven));
         AV21TFFacturaMedidaPrecio = NumberUtil.Val( GetPar( "TFFacturaMedidaPrecio"), ".");
         AV22TFFacturaMedidaPrecio_To = NumberUtil.Val( GetPar( "TFFacturaMedidaPrecio_To"), ".");
         A49PromocionModeloPrecio = NumberUtil.Val( GetPar( "PromocionModeloPrecio"), ".");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV42FacturaID, AV47Pgmname, AV35TFModeloDescripcion, AV36TFModeloDescripcion_Sel, AV37TFMedidaDescripcion, AV38TFMedidaDescripcion_Sel, AV39TFMedidaRin, AV40TFMedidaRin_Sel, AV19TFFacturaMedidaCantidad, AV20TFFacturaMedidaCantidad_To, AV21TFFacturaMedidaPrecio, AV22TFFacturaMedidaPrecio_To, A49PromocionModeloPrecio, sPrefix) ;
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
            PA3F2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV47Pgmname = "WCPartidasFactura";
               edtavBonounitario_Enabled = 0;
               AssignProp(sPrefix, false, edtavBonounitario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBonounitario_Enabled), 5, 0), !bGXsfl_15_Refreshing);
               edtavBonototal_Enabled = 0;
               AssignProp(sPrefix, false, edtavBonototal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBonototal_Enabled), 5, 0), !bGXsfl_15_Refreshing);
               WS3F2( ) ;
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
            context.SendWebValue( context.GetMessage( " Factura Medida", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GXEncryptionTmp = "wcpartidasfactura.aspx"+UrlEncode(StringUtil.LTrimStr(AV42FacturaID,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcpartidasfactura.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV47Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV47Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_15", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_15), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV27GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV23DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV23DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV42FacturaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV42FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV47Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV47Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMODELODESCRIPCION", AV35TFModeloDescripcion);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMODELODESCRIPCION_SEL", AV36TFModeloDescripcion_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMEDIDADESCRIPCION", AV37TFMedidaDescripcion);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMEDIDADESCRIPCION_SEL", AV38TFMedidaDescripcion_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMEDIDARIN", StringUtil.RTrim( AV39TFMedidaRin));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMEDIDARIN_SEL", StringUtil.RTrim( AV40TFMedidaRin_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAMEDIDACANTIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19TFFacturaMedidaCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAMEDIDACANTIDAD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20TFFacturaMedidaCantidad_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAMEDIDAPRECIO", StringUtil.LTrim( StringUtil.NToC( AV21TFFacturaMedidaPrecio, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFFACTURAMEDIDAPRECIO_TO", StringUtil.LTrim( StringUtil.NToC( AV22TFFacturaMedidaPrecio_To, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"PROMOCIONMODELOPRECIO", StringUtil.LTrim( StringUtil.NToC( A49PromocionModeloPrecio, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
      }

      protected void RenderHtmlCloseForm3F2( )
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
         return "WCPartidasFactura" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Factura Medida", "") ;
      }

      protected void WB3F0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcpartidasfactura.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            StartGridControl15( ) ;
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            nRC_GXsfl_15 = (int)(nGXsfl_15_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV25GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV26GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV27GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 15 )
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

      protected void START3F2( )
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
            Form.Meta.addItem("description", context.GetMessage( " Factura Medida", ""), 0) ;
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
               STRUP3F0( ) ;
            }
         }
      }

      protected void WS3F2( )
      {
         START3F2( ) ;
         EVT3F2( ) ;
      }

      protected void EVT3F2( )
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
                                 STRUP3F0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E113F2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E123F2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E133F2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
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
                                 STRUP3F0( ) ;
                              }
                              nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              A77FacturaMedidaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaMedidaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A69FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A41PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPromocionID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A26MedidaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMedidaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A22ModeloID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtModeloID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A23ModeloDescripcion = cgiGet( edtModeloDescripcion_Internalname);
                              A28MedidaDescripcion = cgiGet( edtMedidaDescripcion_Internalname);
                              A74MedidaRin = cgiGet( edtMedidaRin_Internalname);
                              A78FacturaMedidaCantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaMedidaCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              AV29BonoUnitario = context.localUtil.CToN( cgiGet( edtavBonounitario_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              AssignAttri(sPrefix, false, edtavBonounitario_Internalname, StringUtil.LTrimStr( AV29BonoUnitario, 10, 2));
                              AV30BonoTotal = context.localUtil.CToN( cgiGet( edtavBonototal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              AssignAttri(sPrefix, false, edtavBonototal_Internalname, StringUtil.LTrimStr( AV30BonoTotal, 10, 2));
                              A79FacturaMedidaPrecio = context.localUtil.CToN( cgiGet( edtFacturaMedidaPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
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
                                          /* Execute user event: Start */
                                          E143F2 ();
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
                                          /* Execute user event: Refresh */
                                          E153F2 ();
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
                                          /* Execute user event: Grid.Load */
                                          E163F2 ();
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
                                       STRUP3F0( ) ;
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

      protected void WE3F2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3F2( ) ;
            }
         }
      }

      protected void PA3F2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wcpartidasfactura.aspx")), "wcpartidasfactura.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wcpartidasfactura.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "FacturaID");
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
         SubsflControlProps_152( ) ;
         while ( nGXsfl_15_idx <= nRC_GXsfl_15 )
         {
            sendrow_152( ) ;
            nGXsfl_15_idx = ((subGrid_Islastpage==1)&&(nGXsfl_15_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       int AV42FacturaID ,
                                       string AV47Pgmname ,
                                       string AV35TFModeloDescripcion ,
                                       string AV36TFModeloDescripcion_Sel ,
                                       string AV37TFMedidaDescripcion ,
                                       string AV38TFMedidaDescripcion_Sel ,
                                       string AV39TFMedidaRin ,
                                       string AV40TFMedidaRin_Sel ,
                                       short AV19TFFacturaMedidaCantidad ,
                                       short AV20TFFacturaMedidaCantidad_To ,
                                       decimal AV21TFFacturaMedidaPrecio ,
                                       decimal AV22TFFacturaMedidaPrecio_To ,
                                       decimal A49PromocionModeloPrecio ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3F2( ) ;
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
         RF3F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV47Pgmname = "WCPartidasFactura";
         edtavBonounitario_Enabled = 0;
         edtavBonototal_Enabled = 0;
      }

      protected void RF3F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 15;
         /* Execute user event: Refresh */
         E153F2 ();
         nGXsfl_15_idx = 1;
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         bGXsfl_15_Refreshing = true;
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
            SubsflControlProps_152( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel ,
                                                 AV48Wcpartidasfacturads_1_tfmodelodescripcion ,
                                                 AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel ,
                                                 AV50Wcpartidasfacturads_3_tfmedidadescripcion ,
                                                 AV53Wcpartidasfacturads_6_tfmedidarin_sel ,
                                                 AV52Wcpartidasfacturads_5_tfmedidarin ,
                                                 AV54Wcpartidasfacturads_7_tffacturamedidacantidad ,
                                                 AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to ,
                                                 AV56Wcpartidasfacturads_9_tffacturamedidaprecio ,
                                                 AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to ,
                                                 A23ModeloDescripcion ,
                                                 A28MedidaDescripcion ,
                                                 A74MedidaRin ,
                                                 A78FacturaMedidaCantidad ,
                                                 A79FacturaMedidaPrecio ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 AV42FacturaID ,
                                                 A69FacturaID } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            lV48Wcpartidasfacturads_1_tfmodelodescripcion = StringUtil.Concat( StringUtil.RTrim( AV48Wcpartidasfacturads_1_tfmodelodescripcion), "%", "");
            lV50Wcpartidasfacturads_3_tfmedidadescripcion = StringUtil.Concat( StringUtil.RTrim( AV50Wcpartidasfacturads_3_tfmedidadescripcion), "%", "");
            lV52Wcpartidasfacturads_5_tfmedidarin = StringUtil.PadR( StringUtil.RTrim( AV52Wcpartidasfacturads_5_tfmedidarin), 20, "%");
            /* Using cursor H003F2 */
            pr_default.execute(0, new Object[] {AV42FacturaID, lV48Wcpartidasfacturads_1_tfmodelodescripcion, AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel, lV50Wcpartidasfacturads_3_tfmedidadescripcion, AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel, lV52Wcpartidasfacturads_5_tfmedidarin, AV53Wcpartidasfacturads_6_tfmedidarin_sel, AV54Wcpartidasfacturads_7_tffacturamedidacantidad, AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to, AV56Wcpartidasfacturads_9_tffacturamedidaprecio, AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to, GXPagingFrom2, GXPagingTo2});
            nGXsfl_15_idx = 1;
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A79FacturaMedidaPrecio = H003F2_A79FacturaMedidaPrecio[0];
               A78FacturaMedidaCantidad = H003F2_A78FacturaMedidaCantidad[0];
               A74MedidaRin = H003F2_A74MedidaRin[0];
               A28MedidaDescripcion = H003F2_A28MedidaDescripcion[0];
               A23ModeloDescripcion = H003F2_A23ModeloDescripcion[0];
               A22ModeloID = H003F2_A22ModeloID[0];
               A26MedidaID = H003F2_A26MedidaID[0];
               A41PromocionID = H003F2_A41PromocionID[0];
               A69FacturaID = H003F2_A69FacturaID[0];
               A77FacturaMedidaID = H003F2_A77FacturaMedidaID[0];
               A74MedidaRin = H003F2_A74MedidaRin[0];
               A28MedidaDescripcion = H003F2_A28MedidaDescripcion[0];
               A22ModeloID = H003F2_A22ModeloID[0];
               A23ModeloDescripcion = H003F2_A23ModeloDescripcion[0];
               A41PromocionID = H003F2_A41PromocionID[0];
               /* Execute user event: Grid.Load */
               E163F2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 15;
            WB3F0( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3F2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV47Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV47Pgmname, "")), context));
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
         AV48Wcpartidasfacturads_1_tfmodelodescripcion = AV35TFModeloDescripcion;
         AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel = AV36TFModeloDescripcion_Sel;
         AV50Wcpartidasfacturads_3_tfmedidadescripcion = AV37TFMedidaDescripcion;
         AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel = AV38TFMedidaDescripcion_Sel;
         AV52Wcpartidasfacturads_5_tfmedidarin = AV39TFMedidaRin;
         AV53Wcpartidasfacturads_6_tfmedidarin_sel = AV40TFMedidaRin_Sel;
         AV54Wcpartidasfacturads_7_tffacturamedidacantidad = AV19TFFacturaMedidaCantidad;
         AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to = AV20TFFacturaMedidaCantidad_To;
         AV56Wcpartidasfacturads_9_tffacturamedidaprecio = AV21TFFacturaMedidaPrecio;
         AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to = AV22TFFacturaMedidaPrecio_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel ,
                                              AV48Wcpartidasfacturads_1_tfmodelodescripcion ,
                                              AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel ,
                                              AV50Wcpartidasfacturads_3_tfmedidadescripcion ,
                                              AV53Wcpartidasfacturads_6_tfmedidarin_sel ,
                                              AV52Wcpartidasfacturads_5_tfmedidarin ,
                                              AV54Wcpartidasfacturads_7_tffacturamedidacantidad ,
                                              AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to ,
                                              AV56Wcpartidasfacturads_9_tffacturamedidaprecio ,
                                              AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to ,
                                              A23ModeloDescripcion ,
                                              A28MedidaDescripcion ,
                                              A74MedidaRin ,
                                              A78FacturaMedidaCantidad ,
                                              A79FacturaMedidaPrecio ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              AV42FacturaID ,
                                              A69FacturaID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV48Wcpartidasfacturads_1_tfmodelodescripcion = StringUtil.Concat( StringUtil.RTrim( AV48Wcpartidasfacturads_1_tfmodelodescripcion), "%", "");
         lV50Wcpartidasfacturads_3_tfmedidadescripcion = StringUtil.Concat( StringUtil.RTrim( AV50Wcpartidasfacturads_3_tfmedidadescripcion), "%", "");
         lV52Wcpartidasfacturads_5_tfmedidarin = StringUtil.PadR( StringUtil.RTrim( AV52Wcpartidasfacturads_5_tfmedidarin), 20, "%");
         /* Using cursor H003F3 */
         pr_default.execute(1, new Object[] {AV42FacturaID, lV48Wcpartidasfacturads_1_tfmodelodescripcion, AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel, lV50Wcpartidasfacturads_3_tfmedidadescripcion, AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel, lV52Wcpartidasfacturads_5_tfmedidarin, AV53Wcpartidasfacturads_6_tfmedidarin_sel, AV54Wcpartidasfacturads_7_tffacturamedidacantidad, AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to, AV56Wcpartidasfacturads_9_tffacturamedidaprecio, AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to});
         GRID_nRecordCount = H003F3_AGRID_nRecordCount[0];
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
         AV48Wcpartidasfacturads_1_tfmodelodescripcion = AV35TFModeloDescripcion;
         AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel = AV36TFModeloDescripcion_Sel;
         AV50Wcpartidasfacturads_3_tfmedidadescripcion = AV37TFMedidaDescripcion;
         AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel = AV38TFMedidaDescripcion_Sel;
         AV52Wcpartidasfacturads_5_tfmedidarin = AV39TFMedidaRin;
         AV53Wcpartidasfacturads_6_tfmedidarin_sel = AV40TFMedidaRin_Sel;
         AV54Wcpartidasfacturads_7_tffacturamedidacantidad = AV19TFFacturaMedidaCantidad;
         AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to = AV20TFFacturaMedidaCantidad_To;
         AV56Wcpartidasfacturads_9_tffacturamedidaprecio = AV21TFFacturaMedidaPrecio;
         AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to = AV22TFFacturaMedidaPrecio_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV42FacturaID, AV47Pgmname, AV35TFModeloDescripcion, AV36TFModeloDescripcion_Sel, AV37TFMedidaDescripcion, AV38TFMedidaDescripcion_Sel, AV39TFMedidaRin, AV40TFMedidaRin_Sel, AV19TFFacturaMedidaCantidad, AV20TFFacturaMedidaCantidad_To, AV21TFFacturaMedidaPrecio, AV22TFFacturaMedidaPrecio_To, A49PromocionModeloPrecio, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV48Wcpartidasfacturads_1_tfmodelodescripcion = AV35TFModeloDescripcion;
         AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel = AV36TFModeloDescripcion_Sel;
         AV50Wcpartidasfacturads_3_tfmedidadescripcion = AV37TFMedidaDescripcion;
         AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel = AV38TFMedidaDescripcion_Sel;
         AV52Wcpartidasfacturads_5_tfmedidarin = AV39TFMedidaRin;
         AV53Wcpartidasfacturads_6_tfmedidarin_sel = AV40TFMedidaRin_Sel;
         AV54Wcpartidasfacturads_7_tffacturamedidacantidad = AV19TFFacturaMedidaCantidad;
         AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to = AV20TFFacturaMedidaCantidad_To;
         AV56Wcpartidasfacturads_9_tffacturamedidaprecio = AV21TFFacturaMedidaPrecio;
         AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to = AV22TFFacturaMedidaPrecio_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV42FacturaID, AV47Pgmname, AV35TFModeloDescripcion, AV36TFModeloDescripcion_Sel, AV37TFMedidaDescripcion, AV38TFMedidaDescripcion_Sel, AV39TFMedidaRin, AV40TFMedidaRin_Sel, AV19TFFacturaMedidaCantidad, AV20TFFacturaMedidaCantidad_To, AV21TFFacturaMedidaPrecio, AV22TFFacturaMedidaPrecio_To, A49PromocionModeloPrecio, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV48Wcpartidasfacturads_1_tfmodelodescripcion = AV35TFModeloDescripcion;
         AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel = AV36TFModeloDescripcion_Sel;
         AV50Wcpartidasfacturads_3_tfmedidadescripcion = AV37TFMedidaDescripcion;
         AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel = AV38TFMedidaDescripcion_Sel;
         AV52Wcpartidasfacturads_5_tfmedidarin = AV39TFMedidaRin;
         AV53Wcpartidasfacturads_6_tfmedidarin_sel = AV40TFMedidaRin_Sel;
         AV54Wcpartidasfacturads_7_tffacturamedidacantidad = AV19TFFacturaMedidaCantidad;
         AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to = AV20TFFacturaMedidaCantidad_To;
         AV56Wcpartidasfacturads_9_tffacturamedidaprecio = AV21TFFacturaMedidaPrecio;
         AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to = AV22TFFacturaMedidaPrecio_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV42FacturaID, AV47Pgmname, AV35TFModeloDescripcion, AV36TFModeloDescripcion_Sel, AV37TFMedidaDescripcion, AV38TFMedidaDescripcion_Sel, AV39TFMedidaRin, AV40TFMedidaRin_Sel, AV19TFFacturaMedidaCantidad, AV20TFFacturaMedidaCantidad_To, AV21TFFacturaMedidaPrecio, AV22TFFacturaMedidaPrecio_To, A49PromocionModeloPrecio, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV48Wcpartidasfacturads_1_tfmodelodescripcion = AV35TFModeloDescripcion;
         AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel = AV36TFModeloDescripcion_Sel;
         AV50Wcpartidasfacturads_3_tfmedidadescripcion = AV37TFMedidaDescripcion;
         AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel = AV38TFMedidaDescripcion_Sel;
         AV52Wcpartidasfacturads_5_tfmedidarin = AV39TFMedidaRin;
         AV53Wcpartidasfacturads_6_tfmedidarin_sel = AV40TFMedidaRin_Sel;
         AV54Wcpartidasfacturads_7_tffacturamedidacantidad = AV19TFFacturaMedidaCantidad;
         AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to = AV20TFFacturaMedidaCantidad_To;
         AV56Wcpartidasfacturads_9_tffacturamedidaprecio = AV21TFFacturaMedidaPrecio;
         AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to = AV22TFFacturaMedidaPrecio_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV42FacturaID, AV47Pgmname, AV35TFModeloDescripcion, AV36TFModeloDescripcion_Sel, AV37TFMedidaDescripcion, AV38TFMedidaDescripcion_Sel, AV39TFMedidaRin, AV40TFMedidaRin_Sel, AV19TFFacturaMedidaCantidad, AV20TFFacturaMedidaCantidad_To, AV21TFFacturaMedidaPrecio, AV22TFFacturaMedidaPrecio_To, A49PromocionModeloPrecio, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV48Wcpartidasfacturads_1_tfmodelodescripcion = AV35TFModeloDescripcion;
         AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel = AV36TFModeloDescripcion_Sel;
         AV50Wcpartidasfacturads_3_tfmedidadescripcion = AV37TFMedidaDescripcion;
         AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel = AV38TFMedidaDescripcion_Sel;
         AV52Wcpartidasfacturads_5_tfmedidarin = AV39TFMedidaRin;
         AV53Wcpartidasfacturads_6_tfmedidarin_sel = AV40TFMedidaRin_Sel;
         AV54Wcpartidasfacturads_7_tffacturamedidacantidad = AV19TFFacturaMedidaCantidad;
         AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to = AV20TFFacturaMedidaCantidad_To;
         AV56Wcpartidasfacturads_9_tffacturamedidaprecio = AV21TFFacturaMedidaPrecio;
         AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to = AV22TFFacturaMedidaPrecio_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV42FacturaID, AV47Pgmname, AV35TFModeloDescripcion, AV36TFModeloDescripcion_Sel, AV37TFMedidaDescripcion, AV38TFMedidaDescripcion_Sel, AV39TFMedidaRin, AV40TFMedidaRin_Sel, AV19TFFacturaMedidaCantidad, AV20TFFacturaMedidaCantidad_To, AV21TFFacturaMedidaPrecio, AV22TFFacturaMedidaPrecio_To, A49PromocionModeloPrecio, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV47Pgmname = "WCPartidasFactura";
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

      protected void STRUP3F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E143F2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV23DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_15 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_15"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV25GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV26GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV27GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOAV42FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV42FacturaID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            /* Read variables values. */
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
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E143F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E143F2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
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
            AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV23DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV23DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E153F2( )
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
         AV25GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV25GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV25GridCurrentPage), 10, 0));
         AV26GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV26GridPageCount", StringUtil.LTrimStr( (decimal)(AV26GridPageCount), 10, 0));
         GXt_char2 = AV27GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV47Pgmname, out  GXt_char2) ;
         AV27GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV27GridAppliedFilters", AV27GridAppliedFilters);
         AV48Wcpartidasfacturads_1_tfmodelodescripcion = AV35TFModeloDescripcion;
         AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel = AV36TFModeloDescripcion_Sel;
         AV50Wcpartidasfacturads_3_tfmedidadescripcion = AV37TFMedidaDescripcion;
         AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel = AV38TFMedidaDescripcion_Sel;
         AV52Wcpartidasfacturads_5_tfmedidarin = AV39TFMedidaRin;
         AV53Wcpartidasfacturads_6_tfmedidarin_sel = AV40TFMedidaRin_Sel;
         AV54Wcpartidasfacturads_7_tffacturamedidacantidad = AV19TFFacturaMedidaCantidad;
         AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to = AV20TFFacturaMedidaCantidad_To;
         AV56Wcpartidasfacturads_9_tffacturamedidaprecio = AV21TFFacturaMedidaPrecio;
         AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to = AV22TFFacturaMedidaPrecio_To;
         /*  Sending Event outputs  */
      }

      protected void E113F2( )
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
            AV24PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV24PageToGo) ;
         }
      }

      protected void E123F2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E133F2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ModeloDescripcion") == 0 )
            {
               AV35TFModeloDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV35TFModeloDescripcion", AV35TFModeloDescripcion);
               AV36TFModeloDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV36TFModeloDescripcion_Sel", AV36TFModeloDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MedidaDescripcion") == 0 )
            {
               AV37TFMedidaDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV37TFMedidaDescripcion", AV37TFMedidaDescripcion);
               AV38TFMedidaDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV38TFMedidaDescripcion_Sel", AV38TFMedidaDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MedidaRin") == 0 )
            {
               AV39TFMedidaRin = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV39TFMedidaRin", AV39TFMedidaRin);
               AV40TFMedidaRin_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV40TFMedidaRin_Sel", AV40TFMedidaRin_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaMedidaCantidad") == 0 )
            {
               AV19TFFacturaMedidaCantidad = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV19TFFacturaMedidaCantidad", StringUtil.LTrimStr( (decimal)(AV19TFFacturaMedidaCantidad), 4, 0));
               AV20TFFacturaMedidaCantidad_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV20TFFacturaMedidaCantidad_To", StringUtil.LTrimStr( (decimal)(AV20TFFacturaMedidaCantidad_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FacturaMedidaPrecio") == 0 )
            {
               AV21TFFacturaMedidaPrecio = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV21TFFacturaMedidaPrecio", StringUtil.LTrimStr( AV21TFFacturaMedidaPrecio, 10, 2));
               AV22TFFacturaMedidaPrecio_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV22TFFacturaMedidaPrecio_To", StringUtil.LTrimStr( AV22TFFacturaMedidaPrecio_To, 10, 2));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E163F2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         /* Using cursor H003F4 */
         pr_default.execute(2, new Object[] {A22ModeloID, A41PromocionID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A41PromocionID = H003F4_A41PromocionID[0];
            A22ModeloID = H003F4_A22ModeloID[0];
            A49PromocionModeloPrecio = H003F4_A49PromocionModeloPrecio[0];
            AV29BonoUnitario = A49PromocionModeloPrecio;
            AssignAttri(sPrefix, false, edtavBonounitario_Internalname, StringUtil.LTrimStr( AV29BonoUnitario, 10, 2));
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV30BonoTotal = (decimal)(AV29BonoUnitario*A78FacturaMedidaCantidad);
         AssignAttri(sPrefix, false, edtavBonototal_Internalname, StringUtil.LTrimStr( AV30BonoTotal, 10, 2));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV15Session.Get(AV47Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV47Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV15Session.Get(AV47Pgmname+"GridState"), null, "", "");
         }
         AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMODELODESCRIPCION") == 0 )
            {
               AV35TFModeloDescripcion = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV35TFModeloDescripcion", AV35TFModeloDescripcion);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMODELODESCRIPCION_SEL") == 0 )
            {
               AV36TFModeloDescripcion_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV36TFModeloDescripcion_Sel", AV36TFModeloDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMEDIDADESCRIPCION") == 0 )
            {
               AV37TFMedidaDescripcion = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV37TFMedidaDescripcion", AV37TFMedidaDescripcion);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMEDIDADESCRIPCION_SEL") == 0 )
            {
               AV38TFMedidaDescripcion_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV38TFMedidaDescripcion_Sel", AV38TFMedidaDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMEDIDARIN") == 0 )
            {
               AV39TFMedidaRin = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV39TFMedidaRin", AV39TFMedidaRin);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFMEDIDARIN_SEL") == 0 )
            {
               AV40TFMedidaRin_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV40TFMedidaRin_Sel", AV40TFMedidaRin_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURAMEDIDACANTIDAD") == 0 )
            {
               AV19TFFacturaMedidaCantidad = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV19TFFacturaMedidaCantidad", StringUtil.LTrimStr( (decimal)(AV19TFFacturaMedidaCantidad), 4, 0));
               AV20TFFacturaMedidaCantidad_To = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV20TFFacturaMedidaCantidad_To", StringUtil.LTrimStr( (decimal)(AV20TFFacturaMedidaCantidad_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFACTURAMEDIDAPRECIO") == 0 )
            {
               AV21TFFacturaMedidaPrecio = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV21TFFacturaMedidaPrecio", StringUtil.LTrimStr( AV21TFFacturaMedidaPrecio, 10, 2));
               AV22TFFacturaMedidaPrecio_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV22TFFacturaMedidaPrecio_To", StringUtil.LTrimStr( AV22TFFacturaMedidaPrecio_To, 10, 2));
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFModeloDescripcion_Sel)),  AV36TFModeloDescripcion_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFMedidaDescripcion_Sel)),  AV38TFMedidaDescripcion_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFMedidaRin_Sel)),  AV40TFMedidaRin_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char3+"|"+GXt_char4+"||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFModeloDescripcion)),  AV35TFModeloDescripcion, out  GXt_char4) ;
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFMedidaDescripcion)),  AV37TFMedidaDescripcion, out  GXt_char3) ;
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFMedidaRin)),  AV39TFMedidaRin, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"|"+GXt_char3+"|"+GXt_char2+"|"+((0==AV19TFFacturaMedidaCantidad) ? "" : StringUtil.Str( (decimal)(AV19TFFacturaMedidaCantidad), 4, 0))+"|"+((Convert.ToDecimal(0)==AV21TFFacturaMedidaPrecio) ? "" : StringUtil.Str( AV21TFFacturaMedidaPrecio, 10, 2));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|||"+((0==AV20TFFacturaMedidaCantidad_To) ? "" : StringUtil.Str( (decimal)(AV20TFFacturaMedidaCantidad_To), 4, 0))+"|"+((Convert.ToDecimal(0)==AV22TFFacturaMedidaPrecio_To) ? "" : StringUtil.Str( AV22TFFacturaMedidaPrecio_To, 10, 2));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV15Session.Get(AV47Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFMODELODESCRIPCION",  context.GetMessage( "Modelo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFModeloDescripcion)),  0,  AV35TFModeloDescripcion,  AV35TFModeloDescripcion,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFModeloDescripcion_Sel)),  AV36TFModeloDescripcion_Sel,  AV36TFModeloDescripcion_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFMEDIDADESCRIPCION",  context.GetMessage( "Medida", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFMedidaDescripcion)),  0,  AV37TFMedidaDescripcion,  AV37TFMedidaDescripcion,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFMedidaDescripcion_Sel)),  AV38TFMedidaDescripcion_Sel,  AV38TFMedidaDescripcion_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFMEDIDARIN",  context.GetMessage( "Rin", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFMedidaRin)),  0,  AV39TFMedidaRin,  AV39TFMedidaRin,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFMedidaRin_Sel)),  AV40TFMedidaRin_Sel,  AV40TFMedidaRin_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFACTURAMEDIDACANTIDAD",  context.GetMessage( "Cantidad", ""),  !((0==AV19TFFacturaMedidaCantidad)&&(0==AV20TFFacturaMedidaCantidad_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV19TFFacturaMedidaCantidad), 4, 0)),  ((0==AV19TFFacturaMedidaCantidad) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV19TFFacturaMedidaCantidad), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV20TFFacturaMedidaCantidad_To), 4, 0)),  ((0==AV20TFFacturaMedidaCantidad_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV20TFFacturaMedidaCantidad_To), "ZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFACTURAMEDIDAPRECIO",  context.GetMessage( "Precio Unitario", ""),  !((Convert.ToDecimal(0)==AV21TFFacturaMedidaPrecio)&&(Convert.ToDecimal(0)==AV22TFFacturaMedidaPrecio_To)),  0,  StringUtil.Trim( StringUtil.Str( AV21TFFacturaMedidaPrecio, 10, 2)),  ((Convert.ToDecimal(0)==AV21TFFacturaMedidaPrecio) ? "" : StringUtil.Trim( context.localUtil.Format( AV21TFFacturaMedidaPrecio, "$ Z,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV22TFFacturaMedidaPrecio_To, 10, 2)),  ((Convert.ToDecimal(0)==AV22TFFacturaMedidaPrecio_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV22TFFacturaMedidaPrecio_To, "$ Z,ZZZ,ZZ9.99")))) ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV47Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV47Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "FacturaMedida";
         AV15Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV42FacturaID = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV42FacturaID", StringUtil.LTrimStr( (decimal)(AV42FacturaID), 9, 0));
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
         PA3F2( ) ;
         WS3F2( ) ;
         WE3F2( ) ;
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
         sCtrlAV42FacturaID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3F2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcpartidasfactura", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3F2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV42FacturaID = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV42FacturaID", StringUtil.LTrimStr( (decimal)(AV42FacturaID), 9, 0));
         }
         wcpOAV42FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV42FacturaID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV42FacturaID != wcpOAV42FacturaID ) ) )
         {
            setjustcreated();
         }
         wcpOAV42FacturaID = AV42FacturaID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV42FacturaID = cgiGet( sPrefix+"AV42FacturaID_CTRL");
         if ( StringUtil.Len( sCtrlAV42FacturaID) > 0 )
         {
            AV42FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV42FacturaID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV42FacturaID", StringUtil.LTrimStr( (decimal)(AV42FacturaID), 9, 0));
         }
         else
         {
            AV42FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV42FacturaID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA3F2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3F2( ) ;
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
         WS3F2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV42FacturaID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV42FacturaID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV42FacturaID_CTRL", StringUtil.RTrim( sCtrlAV42FacturaID));
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
         WE3F2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202651111305827", true, true);
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
         context.AddJavascriptSource("wcpartidasfactura.js", "?202651111305827", false, true);
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

      protected void SubsflControlProps_152( )
      {
         edtFacturaMedidaID_Internalname = sPrefix+"FACTURAMEDIDAID_"+sGXsfl_15_idx;
         edtFacturaID_Internalname = sPrefix+"FACTURAID_"+sGXsfl_15_idx;
         edtPromocionID_Internalname = sPrefix+"PROMOCIONID_"+sGXsfl_15_idx;
         edtMedidaID_Internalname = sPrefix+"MEDIDAID_"+sGXsfl_15_idx;
         edtModeloID_Internalname = sPrefix+"MODELOID_"+sGXsfl_15_idx;
         edtModeloDescripcion_Internalname = sPrefix+"MODELODESCRIPCION_"+sGXsfl_15_idx;
         edtMedidaDescripcion_Internalname = sPrefix+"MEDIDADESCRIPCION_"+sGXsfl_15_idx;
         edtMedidaRin_Internalname = sPrefix+"MEDIDARIN_"+sGXsfl_15_idx;
         edtFacturaMedidaCantidad_Internalname = sPrefix+"FACTURAMEDIDACANTIDAD_"+sGXsfl_15_idx;
         edtavBonounitario_Internalname = sPrefix+"vBONOUNITARIO_"+sGXsfl_15_idx;
         edtavBonototal_Internalname = sPrefix+"vBONOTOTAL_"+sGXsfl_15_idx;
         edtFacturaMedidaPrecio_Internalname = sPrefix+"FACTURAMEDIDAPRECIO_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         edtFacturaMedidaID_Internalname = sPrefix+"FACTURAMEDIDAID_"+sGXsfl_15_fel_idx;
         edtFacturaID_Internalname = sPrefix+"FACTURAID_"+sGXsfl_15_fel_idx;
         edtPromocionID_Internalname = sPrefix+"PROMOCIONID_"+sGXsfl_15_fel_idx;
         edtMedidaID_Internalname = sPrefix+"MEDIDAID_"+sGXsfl_15_fel_idx;
         edtModeloID_Internalname = sPrefix+"MODELOID_"+sGXsfl_15_fel_idx;
         edtModeloDescripcion_Internalname = sPrefix+"MODELODESCRIPCION_"+sGXsfl_15_fel_idx;
         edtMedidaDescripcion_Internalname = sPrefix+"MEDIDADESCRIPCION_"+sGXsfl_15_fel_idx;
         edtMedidaRin_Internalname = sPrefix+"MEDIDARIN_"+sGXsfl_15_fel_idx;
         edtFacturaMedidaCantidad_Internalname = sPrefix+"FACTURAMEDIDACANTIDAD_"+sGXsfl_15_fel_idx;
         edtavBonounitario_Internalname = sPrefix+"vBONOUNITARIO_"+sGXsfl_15_fel_idx;
         edtavBonototal_Internalname = sPrefix+"vBONOTOTAL_"+sGXsfl_15_fel_idx;
         edtFacturaMedidaPrecio_Internalname = sPrefix+"FACTURAMEDIDAPRECIO_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         WB3F0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_15_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_15_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_15_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaMedidaID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A77FacturaMedidaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A77FacturaMedidaID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaMedidaID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidaID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A26MedidaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A26MedidaID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidaID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtModeloID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A22ModeloID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A22ModeloID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtModeloID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtModeloDescripcion_Internalname,(string)A23ModeloDescripcion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtModeloDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidaDescripcion_Internalname,(string)A28MedidaDescripcion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidaDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidaRin_Internalname,StringUtil.RTrim( A74MedidaRin),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidaRin_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaMedidaCantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A78FacturaMedidaCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A78FacturaMedidaCantidad), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaMedidaCantidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'" + sGXsfl_15_idx + "',15)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBonounitario_Internalname,StringUtil.LTrim( StringUtil.NToC( AV29BonoUnitario, 14, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavBonounitario_Enabled!=0) ? context.localUtil.Format( AV29BonoUnitario, "$ Z,ZZZ,ZZ9.99") : context.localUtil.Format( AV29BonoUnitario, "$ Z,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,25);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavBonounitario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavBonounitario_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'" + sGXsfl_15_idx + "',15)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBonototal_Internalname,StringUtil.LTrim( StringUtil.NToC( AV30BonoTotal, 14, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavBonototal_Enabled!=0) ? context.localUtil.Format( AV30BonoTotal, "$ Z,ZZZ,ZZ9.99") : context.localUtil.Format( AV30BonoTotal, "$ Z,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,26);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavBonototal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavBonototal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaMedidaPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( A79FacturaMedidaPrecio, 14, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A79FacturaMedidaPrecio, "$ Z,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaMedidaPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes3F2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_15_idx = ((subGrid_Islastpage==1)&&(nGXsfl_15_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         /* End function sendrow_152 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl15( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"15\">") ;
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
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( AV29BonoUnitario, 14, 2, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBonounitario_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( AV30BonoTotal, 14, 2, ".", ""))));
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
         edtFacturaMedidaID_Internalname = sPrefix+"FACTURAMEDIDAID";
         edtFacturaID_Internalname = sPrefix+"FACTURAID";
         edtPromocionID_Internalname = sPrefix+"PROMOCIONID";
         edtMedidaID_Internalname = sPrefix+"MEDIDAID";
         edtModeloID_Internalname = sPrefix+"MODELOID";
         edtModeloDescripcion_Internalname = sPrefix+"MODELODESCRIPCION";
         edtMedidaDescripcion_Internalname = sPrefix+"MEDIDADESCRIPCION";
         edtMedidaRin_Internalname = sPrefix+"MEDIDARIN";
         edtFacturaMedidaCantidad_Internalname = sPrefix+"FACTURAMEDIDACANTIDAD";
         edtavBonounitario_Internalname = sPrefix+"vBONOUNITARIO";
         edtavBonototal_Internalname = sPrefix+"vBONOTOTAL";
         edtFacturaMedidaPrecio_Internalname = sPrefix+"FACTURAMEDIDAPRECIO";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
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
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "|||4.0|10.2";
         Ddo_grid_Datalistproc = "WCPartidasFacturaGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic||";
         Ddo_grid_Includedatalist = "T|T|T||";
         Ddo_grid_Filterisrange = "|||T|T";
         Ddo_grid_Filtertype = "Character|Character|Character|Numeric|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5";
         Ddo_grid_Columnids = "5:ModeloDescripcion|6:MedidaDescripcion|7:MedidaRin|8:FacturaMedidaCantidad|11:FacturaMedidaPrecio";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV42FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"A49PromocionModeloPrecio","fld":"PROMOCIONMODELOPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"sPrefix"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV35TFModeloDescripcion","fld":"vTFMODELODESCRIPCION"},{"av":"AV36TFModeloDescripcion_Sel","fld":"vTFMODELODESCRIPCION_SEL"},{"av":"AV37TFMedidaDescripcion","fld":"vTFMEDIDADESCRIPCION"},{"av":"AV38TFMedidaDescripcion_Sel","fld":"vTFMEDIDADESCRIPCION_SEL"},{"av":"AV39TFMedidaRin","fld":"vTFMEDIDARIN"},{"av":"AV40TFMedidaRin_Sel","fld":"vTFMEDIDARIN_SEL"},{"av":"AV19TFFacturaMedidaCantidad","fld":"vTFFACTURAMEDIDACANTIDAD","pic":"ZZZ9"},{"av":"AV20TFFacturaMedidaCantidad_To","fld":"vTFFACTURAMEDIDACANTIDAD_TO","pic":"ZZZ9"},{"av":"AV21TFFacturaMedidaPrecio","fld":"vTFFACTURAMEDIDAPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV22TFFacturaMedidaPrecio_To","fld":"vTFFACTURAMEDIDAPRECIO_TO","pic":"$ Z,ZZZ,ZZ9.99"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV25GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV26GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV27GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E113F2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV42FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV35TFModeloDescripcion","fld":"vTFMODELODESCRIPCION"},{"av":"AV36TFModeloDescripcion_Sel","fld":"vTFMODELODESCRIPCION_SEL"},{"av":"AV37TFMedidaDescripcion","fld":"vTFMEDIDADESCRIPCION"},{"av":"AV38TFMedidaDescripcion_Sel","fld":"vTFMEDIDADESCRIPCION_SEL"},{"av":"AV39TFMedidaRin","fld":"vTFMEDIDARIN"},{"av":"AV40TFMedidaRin_Sel","fld":"vTFMEDIDARIN_SEL"},{"av":"AV19TFFacturaMedidaCantidad","fld":"vTFFACTURAMEDIDACANTIDAD","pic":"ZZZ9"},{"av":"AV20TFFacturaMedidaCantidad_To","fld":"vTFFACTURAMEDIDACANTIDAD_TO","pic":"ZZZ9"},{"av":"AV21TFFacturaMedidaPrecio","fld":"vTFFACTURAMEDIDAPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV22TFFacturaMedidaPrecio_To","fld":"vTFFACTURAMEDIDAPRECIO_TO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"A49PromocionModeloPrecio","fld":"PROMOCIONMODELOPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"sPrefix"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E123F2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV42FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV35TFModeloDescripcion","fld":"vTFMODELODESCRIPCION"},{"av":"AV36TFModeloDescripcion_Sel","fld":"vTFMODELODESCRIPCION_SEL"},{"av":"AV37TFMedidaDescripcion","fld":"vTFMEDIDADESCRIPCION"},{"av":"AV38TFMedidaDescripcion_Sel","fld":"vTFMEDIDADESCRIPCION_SEL"},{"av":"AV39TFMedidaRin","fld":"vTFMEDIDARIN"},{"av":"AV40TFMedidaRin_Sel","fld":"vTFMEDIDARIN_SEL"},{"av":"AV19TFFacturaMedidaCantidad","fld":"vTFFACTURAMEDIDACANTIDAD","pic":"ZZZ9"},{"av":"AV20TFFacturaMedidaCantidad_To","fld":"vTFFACTURAMEDIDACANTIDAD_TO","pic":"ZZZ9"},{"av":"AV21TFFacturaMedidaPrecio","fld":"vTFFACTURAMEDIDAPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV22TFFacturaMedidaPrecio_To","fld":"vTFFACTURAMEDIDAPRECIO_TO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"A49PromocionModeloPrecio","fld":"PROMOCIONMODELOPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"sPrefix"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E133F2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV42FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV35TFModeloDescripcion","fld":"vTFMODELODESCRIPCION"},{"av":"AV36TFModeloDescripcion_Sel","fld":"vTFMODELODESCRIPCION_SEL"},{"av":"AV37TFMedidaDescripcion","fld":"vTFMEDIDADESCRIPCION"},{"av":"AV38TFMedidaDescripcion_Sel","fld":"vTFMEDIDADESCRIPCION_SEL"},{"av":"AV39TFMedidaRin","fld":"vTFMEDIDARIN"},{"av":"AV40TFMedidaRin_Sel","fld":"vTFMEDIDARIN_SEL"},{"av":"AV19TFFacturaMedidaCantidad","fld":"vTFFACTURAMEDIDACANTIDAD","pic":"ZZZ9"},{"av":"AV20TFFacturaMedidaCantidad_To","fld":"vTFFACTURAMEDIDACANTIDAD_TO","pic":"ZZZ9"},{"av":"AV21TFFacturaMedidaPrecio","fld":"vTFFACTURAMEDIDAPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV22TFFacturaMedidaPrecio_To","fld":"vTFFACTURAMEDIDAPRECIO_TO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"A49PromocionModeloPrecio","fld":"PROMOCIONMODELOPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"sPrefix"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV35TFModeloDescripcion","fld":"vTFMODELODESCRIPCION"},{"av":"AV36TFModeloDescripcion_Sel","fld":"vTFMODELODESCRIPCION_SEL"},{"av":"AV37TFMedidaDescripcion","fld":"vTFMEDIDADESCRIPCION"},{"av":"AV38TFMedidaDescripcion_Sel","fld":"vTFMEDIDADESCRIPCION_SEL"},{"av":"AV39TFMedidaRin","fld":"vTFMEDIDARIN"},{"av":"AV40TFMedidaRin_Sel","fld":"vTFMEDIDARIN_SEL"},{"av":"AV19TFFacturaMedidaCantidad","fld":"vTFFACTURAMEDIDACANTIDAD","pic":"ZZZ9"},{"av":"AV20TFFacturaMedidaCantidad_To","fld":"vTFFACTURAMEDIDACANTIDAD_TO","pic":"ZZZ9"},{"av":"AV21TFFacturaMedidaPrecio","fld":"vTFFACTURAMEDIDAPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV22TFFacturaMedidaPrecio_To","fld":"vTFFACTURAMEDIDAPRECIO_TO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E163F2","iparms":[{"av":"A22ModeloID","fld":"MODELOID","pic":"ZZZZZZZZ9"},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A49PromocionModeloPrecio","fld":"PROMOCIONMODELOPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"A78FacturaMedidaCantidad","fld":"FACTURAMEDIDACANTIDAD","pic":"ZZZ9"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV29BonoUnitario","fld":"vBONOUNITARIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV30BonoTotal","fld":"vBONOTOTAL","pic":"$ Z,ZZZ,ZZ9.99"}]}""");
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
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV47Pgmname = "";
         AV35TFModeloDescripcion = "";
         AV36TFModeloDescripcion_Sel = "";
         AV37TFMedidaDescripcion = "";
         AV38TFMedidaDescripcion_Sel = "";
         AV39TFMedidaRin = "";
         AV40TFMedidaRin_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV27GridAppliedFilters = "";
         AV23DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A23ModeloDescripcion = "";
         A28MedidaDescripcion = "";
         A74MedidaRin = "";
         GXDecQS = "";
         lV48Wcpartidasfacturads_1_tfmodelodescripcion = "";
         lV50Wcpartidasfacturads_3_tfmedidadescripcion = "";
         lV52Wcpartidasfacturads_5_tfmedidarin = "";
         AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel = "";
         AV48Wcpartidasfacturads_1_tfmodelodescripcion = "";
         AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel = "";
         AV50Wcpartidasfacturads_3_tfmedidadescripcion = "";
         AV53Wcpartidasfacturads_6_tfmedidarin_sel = "";
         AV52Wcpartidasfacturads_5_tfmedidarin = "";
         H003F2_A79FacturaMedidaPrecio = new decimal[1] ;
         H003F2_A78FacturaMedidaCantidad = new short[1] ;
         H003F2_A74MedidaRin = new string[] {""} ;
         H003F2_A28MedidaDescripcion = new string[] {""} ;
         H003F2_A23ModeloDescripcion = new string[] {""} ;
         H003F2_A22ModeloID = new int[1] ;
         H003F2_A26MedidaID = new int[1] ;
         H003F2_A41PromocionID = new int[1] ;
         H003F2_A69FacturaID = new int[1] ;
         H003F2_A77FacturaMedidaID = new int[1] ;
         H003F3_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H003F4_A48PromocionModeloID = new int[1] ;
         H003F4_A41PromocionID = new int[1] ;
         H003F4_A22ModeloID = new int[1] ;
         H003F4_A49PromocionModeloPrecio = new decimal[1] ;
         GridRow = new GXWebRow();
         AV15Session = context.GetSession();
         AV10GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV11GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char4 = "";
         GXt_char3 = "";
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV42FacturaID = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         TempTags = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcpartidasfactura__default(),
            new Object[][] {
                new Object[] {
               H003F2_A79FacturaMedidaPrecio, H003F2_A78FacturaMedidaCantidad, H003F2_A74MedidaRin, H003F2_A28MedidaDescripcion, H003F2_A23ModeloDescripcion, H003F2_A22ModeloID, H003F2_A26MedidaID, H003F2_A41PromocionID, H003F2_A69FacturaID, H003F2_A77FacturaMedidaID
               }
               , new Object[] {
               H003F3_AGRID_nRecordCount
               }
               , new Object[] {
               H003F4_A48PromocionModeloID, H003F4_A41PromocionID, H003F4_A22ModeloID, H003F4_A49PromocionModeloPrecio
               }
            }
         );
         AV47Pgmname = "WCPartidasFactura";
         /* GeneXus formulas. */
         AV47Pgmname = "WCPartidasFactura";
         edtavBonounitario_Enabled = 0;
         edtavBonototal_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV12OrderedBy ;
      private short AV19TFFacturaMedidaCantidad ;
      private short AV20TFFacturaMedidaCantidad_To ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A78FacturaMedidaCantidad ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV54Wcpartidasfacturads_7_tffacturamedidacantidad ;
      private short AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV42FacturaID ;
      private int wcpOAV42FacturaID ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_15 ;
      private int nGXsfl_15_idx=1 ;
      private int edtavBonounitario_Enabled ;
      private int edtavBonototal_Enabled ;
      private int Gridpaginationbar_Pagestoshow ;
      private int A77FacturaMedidaID ;
      private int A69FacturaID ;
      private int A41PromocionID ;
      private int A26MedidaID ;
      private int A22ModeloID ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
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
      private int AV24PageToGo ;
      private int AV59GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV25GridCurrentPage ;
      private long AV26GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV21TFFacturaMedidaPrecio ;
      private decimal AV22TFFacturaMedidaPrecio_To ;
      private decimal A49PromocionModeloPrecio ;
      private decimal AV29BonoUnitario ;
      private decimal AV30BonoTotal ;
      private decimal A79FacturaMedidaPrecio ;
      private decimal AV56Wcpartidasfacturads_9_tffacturamedidaprecio ;
      private decimal AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_15_idx="0001" ;
      private string AV47Pgmname ;
      private string AV39TFMedidaRin ;
      private string AV40TFMedidaRin_Sel ;
      private string edtavBonounitario_Internalname ;
      private string edtavBonototal_Internalname ;
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
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
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
      private string edtFacturaMedidaPrecio_Internalname ;
      private string GXDecQS ;
      private string lV52Wcpartidasfacturads_5_tfmedidarin ;
      private string AV53Wcpartidasfacturads_6_tfmedidarin_sel ;
      private string AV52Wcpartidasfacturads_5_tfmedidarin ;
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string sCtrlAV42FacturaID ;
      private string sGXsfl_15_fel_idx="0001" ;
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
      private string TempTags ;
      private string edtavBonounitario_Jsonclick ;
      private string edtavBonototal_Jsonclick ;
      private string edtFacturaMedidaPrecio_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool bGXsfl_15_Refreshing=false ;
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
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV35TFModeloDescripcion ;
      private string AV36TFModeloDescripcion_Sel ;
      private string AV37TFMedidaDescripcion ;
      private string AV38TFMedidaDescripcion_Sel ;
      private string AV27GridAppliedFilters ;
      private string A23ModeloDescripcion ;
      private string A28MedidaDescripcion ;
      private string lV48Wcpartidasfacturads_1_tfmodelodescripcion ;
      private string lV50Wcpartidasfacturads_3_tfmedidadescripcion ;
      private string AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel ;
      private string AV48Wcpartidasfacturads_1_tfmodelodescripcion ;
      private string AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel ;
      private string AV50Wcpartidasfacturads_3_tfmedidadescripcion ;
      private IGxSession AV15Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV23DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private decimal[] H003F2_A79FacturaMedidaPrecio ;
      private short[] H003F2_A78FacturaMedidaCantidad ;
      private string[] H003F2_A74MedidaRin ;
      private string[] H003F2_A28MedidaDescripcion ;
      private string[] H003F2_A23ModeloDescripcion ;
      private int[] H003F2_A22ModeloID ;
      private int[] H003F2_A26MedidaID ;
      private int[] H003F2_A41PromocionID ;
      private int[] H003F2_A69FacturaID ;
      private int[] H003F2_A77FacturaMedidaID ;
      private long[] H003F3_AGRID_nRecordCount ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private int[] H003F4_A48PromocionModeloID ;
      private int[] H003F4_A41PromocionID ;
      private int[] H003F4_A22ModeloID ;
      private decimal[] H003F4_A49PromocionModeloPrecio ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV10GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wcpartidasfactura__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003F2( IGxContext context ,
                                             string AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel ,
                                             string AV48Wcpartidasfacturads_1_tfmodelodescripcion ,
                                             string AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel ,
                                             string AV50Wcpartidasfacturads_3_tfmedidadescripcion ,
                                             string AV53Wcpartidasfacturads_6_tfmedidarin_sel ,
                                             string AV52Wcpartidasfacturads_5_tfmedidarin ,
                                             short AV54Wcpartidasfacturads_7_tffacturamedidacantidad ,
                                             short AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to ,
                                             decimal AV56Wcpartidasfacturads_9_tffacturamedidaprecio ,
                                             decimal AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to ,
                                             string A23ModeloDescripcion ,
                                             string A28MedidaDescripcion ,
                                             string A74MedidaRin ,
                                             short A78FacturaMedidaCantidad ,
                                             decimal A79FacturaMedidaPrecio ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int AV42FacturaID ,
                                             int A69FacturaID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[13];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.`FacturaMedidaPrecio`, T1.`FacturaMedidaCantidad`, T2.`MedidaRin`, T2.`MedidaDescripcion`, T3.`ModeloDescripcion`, T2.`ModeloID`, T1.`MedidaID`, T4.`PromocionID`, T1.`FacturaID`, T1.`FacturaMedidaID`";
         sFromString = " FROM (((`FacturaMedida` T1 INNER JOIN `Medida` T2 ON T2.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T3 ON T3.`ModeloID` = T2.`ModeloID`) INNER JOIN `Factura` T4 ON T4.`FacturaID` = T1.`FacturaID`)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.`FacturaID` = @AV42FacturaID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wcpartidasfacturads_1_tfmodelodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` like @lV48Wcpartidasfacturads_1_tfmodelodescripcion)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel)) && ! ( StringUtil.StrCmp(AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`ModeloDescripcion` = @AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( StringUtil.StrCmp(AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`ModeloDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wcpartidasfacturads_3_tfmedidadescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` like @lV50Wcpartidasfacturads_3_tfmedidadescripcion)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel)) && ! ( StringUtil.StrCmp(AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaDescripcion` = @AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wcpartidasfacturads_6_tfmedidarin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wcpartidasfacturads_5_tfmedidarin)) ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` like @lV52Wcpartidasfacturads_5_tfmedidarin)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wcpartidasfacturads_6_tfmedidarin_sel)) && ! ( StringUtil.StrCmp(AV53Wcpartidasfacturads_6_tfmedidarin_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`MedidaRin` = @AV53Wcpartidasfacturads_6_tfmedidarin_sel)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV53Wcpartidasfacturads_6_tfmedidarin_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`MedidaRin`))=0))");
         }
         if ( ! (0==AV54Wcpartidasfacturads_7_tffacturamedidacantidad) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` >= @AV54Wcpartidasfacturads_7_tffacturamedidacantidad)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (0==AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` <= @AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV56Wcpartidasfacturads_9_tffacturamedidaprecio) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` >= @AV56Wcpartidasfacturads_9_tffacturamedidaprecio)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` <= @AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T3.`ModeloDescripcion`";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.`ModeloDescripcion` DESC";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T2.`MedidaDescripcion`";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.`MedidaDescripcion` DESC";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T2.`MedidaRin`";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.`MedidaRin` DESC";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`FacturaMedidaCantidad`";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.`FacturaMedidaCantidad` DESC";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.`FacturaMedidaPrecio`";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
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

      protected Object[] conditional_H003F3( IGxContext context ,
                                             string AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel ,
                                             string AV48Wcpartidasfacturads_1_tfmodelodescripcion ,
                                             string AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel ,
                                             string AV50Wcpartidasfacturads_3_tfmedidadescripcion ,
                                             string AV53Wcpartidasfacturads_6_tfmedidarin_sel ,
                                             string AV52Wcpartidasfacturads_5_tfmedidarin ,
                                             short AV54Wcpartidasfacturads_7_tffacturamedidacantidad ,
                                             short AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to ,
                                             decimal AV56Wcpartidasfacturads_9_tffacturamedidaprecio ,
                                             decimal AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to ,
                                             string A23ModeloDescripcion ,
                                             string A28MedidaDescripcion ,
                                             string A74MedidaRin ,
                                             short A78FacturaMedidaCantidad ,
                                             decimal A79FacturaMedidaPrecio ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int AV42FacturaID ,
                                             int A69FacturaID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[11];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((`FacturaMedida` T1 INNER JOIN `Medida` T3 ON T3.`MedidaID` = T1.`MedidaID`) INNER JOIN `Modelo` T4 ON T4.`ModeloID` = T3.`ModeloID`) INNER JOIN `Factura` T2 ON T2.`FacturaID` = T1.`FacturaID`)";
         AddWhere(sWhereString, "(T1.`FacturaID` = @AV42FacturaID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wcpartidasfacturads_1_tfmodelodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T4.`ModeloDescripcion` like @lV48Wcpartidasfacturads_1_tfmodelodescripcion)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel)) && ! ( StringUtil.StrCmp(AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.`ModeloDescripcion` = @AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( StringUtil.StrCmp(AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T4.`ModeloDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wcpartidasfacturads_3_tfmedidadescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.`MedidaDescripcion` like @lV50Wcpartidasfacturads_3_tfmedidadescripcion)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel)) && ! ( StringUtil.StrCmp(AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`MedidaDescripcion` = @AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`MedidaDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wcpartidasfacturads_6_tfmedidarin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wcpartidasfacturads_5_tfmedidarin)) ) )
         {
            AddWhere(sWhereString, "(T3.`MedidaRin` like @lV52Wcpartidasfacturads_5_tfmedidarin)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wcpartidasfacturads_6_tfmedidarin_sel)) && ! ( StringUtil.StrCmp(AV53Wcpartidasfacturads_6_tfmedidarin_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.`MedidaRin` = @AV53Wcpartidasfacturads_6_tfmedidarin_sel)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( StringUtil.StrCmp(AV53Wcpartidasfacturads_6_tfmedidarin_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T3.`MedidaRin`))=0))");
         }
         if ( ! (0==AV54Wcpartidasfacturads_7_tffacturamedidacantidad) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` >= @AV54Wcpartidasfacturads_7_tffacturamedidacantidad)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! (0==AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaCantidad` <= @AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV56Wcpartidasfacturads_9_tffacturamedidaprecio) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` >= @AV56Wcpartidasfacturads_9_tffacturamedidaprecio)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to) )
         {
            AddWhere(sWhereString, "(T1.`FacturaMedidaPrecio` <= @AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to)");
         }
         else
         {
            GXv_int7[10] = 1;
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
                     return conditional_H003F2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] );
               case 1 :
                     return conditional_H003F3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] );
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
          Object[] prmH003F4;
          prmH003F4 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0) ,
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmH003F2;
          prmH003F2 = new Object[] {
          new ParDef("@AV42FacturaID",GXType.Int32,9,0) ,
          new ParDef("@lV48Wcpartidasfacturads_1_tfmodelodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV50Wcpartidasfacturads_3_tfmedidadescripcion",GXType.Char,80,0) ,
          new ParDef("@AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV52Wcpartidasfacturads_5_tfmedidarin",GXType.Char,20,0) ,
          new ParDef("@AV53Wcpartidasfacturads_6_tfmedidarin_sel",GXType.Char,20,0) ,
          new ParDef("@AV54Wcpartidasfacturads_7_tffacturamedidacantidad",GXType.Int16,4,0) ,
          new ParDef("@AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to",GXType.Int16,4,0) ,
          new ParDef("@AV56Wcpartidasfacturads_9_tffacturamedidaprecio",GXType.Number,10,2) ,
          new ParDef("@AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to",GXType.Number,10,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH003F3;
          prmH003F3 = new Object[] {
          new ParDef("@AV42FacturaID",GXType.Int32,9,0) ,
          new ParDef("@lV48Wcpartidasfacturads_1_tfmodelodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV49Wcpartidasfacturads_2_tfmodelodescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV50Wcpartidasfacturads_3_tfmedidadescripcion",GXType.Char,80,0) ,
          new ParDef("@AV51Wcpartidasfacturads_4_tfmedidadescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV52Wcpartidasfacturads_5_tfmedidarin",GXType.Char,20,0) ,
          new ParDef("@AV53Wcpartidasfacturads_6_tfmedidarin_sel",GXType.Char,20,0) ,
          new ParDef("@AV54Wcpartidasfacturads_7_tffacturamedidacantidad",GXType.Int16,4,0) ,
          new ParDef("@AV55Wcpartidasfacturads_8_tffacturamedidacantidad_to",GXType.Int16,4,0) ,
          new ParDef("@AV56Wcpartidasfacturads_9_tffacturamedidaprecio",GXType.Number,10,2) ,
          new ParDef("@AV57Wcpartidasfacturads_10_tffacturamedidaprecio_to",GXType.Number,10,2)
          };
          def= new CursorDef[] {
              new CursorDef("H003F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003F2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003F3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003F4", "SELECT `PromocionModeloID`, `PromocionID`, `ModeloID`, `PromocionModeloPrecio` FROM `PromocionModelo` WHERE (`ModeloID` = @ModeloID) AND (`PromocionID` = @PromocionID) ORDER BY `PromocionModeloID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003F4,1, GxCacheFrequency.OFF ,false,true )
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
