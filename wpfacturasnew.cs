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
   public class wpfacturasnew : GXDataArea
   {
      public wpfacturasnew( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpfacturasnew( IGxContext context )
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
         cmbavFacturaestatus = new GXCombobox();
         cmbFacturaEstatus = new GXCombobox();
         cmbavVarestatus = new GXCombobox();
         cmbavVarestatusadmin = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Freestylegrid1") == 0 )
            {
               gxnrFreestylegrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Freestylegrid1") == 0 )
            {
               gxgrFreestylegrid1_refresh_invoke( ) ;
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

      protected void gxnrFreestylegrid1_newrow_invoke( )
      {
         nRC_GXsfl_72 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_72"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_72_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_72_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_72_idx = GetPar( "sGXsfl_72_idx");
         edtFacturaID_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtFacturaID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaID_Visible), 5, 0), !bGXsfl_72_Refreshing);
         cmbFacturaEstatus.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, cmbFacturaEstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbFacturaEstatus.Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtUsuarioID_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtUsuarioID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioID_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtMotivoRechazoActivo_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtMotivoRechazoActivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoActivo_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtMotivoRechazoDescripcion_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtMotivoRechazoDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoDescripcion_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtMotivoRechazoID_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtMotivoRechazoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoID_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtavMotivorechazo_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavMotivorechazo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMotivorechazo_Visible), 5, 0), !bGXsfl_72_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFreestylegrid1_newrow( ) ;
         /* End function gxnrFreestylegrid1_newrow_invoke */
      }

      protected void gxgrFreestylegrid1_refresh_invoke( )
      {
         subFreestylegrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subFreestylegrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV22FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
         AV52ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
         cmbavFacturaestatus.FromJSonString( GetNextPar( ));
         AV92FacturaEstatus = GetPar( "FacturaEstatus");
         AV99FacturaNo = GetPar( "FacturaNo");
         AV90TotalRows = (long)(Math.Round(NumberUtil.Val( GetPar( "TotalRows"), "."), 18, MidpointRounding.ToEven));
         AV117DoScroll = StringUtil.StrToBool( GetPar( "DoScroll"));
         AV116KeepPage = (short)(Math.Round(NumberUtil.Val( GetPar( "KeepPage"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV95PromocionID);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV97UsuarioID);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV100UsuariosFiltro);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV62ListaUsuarios);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV15DistribuidorID);
         A40UsuarioRol = GetPar( "UsuarioRol");
         A10DistribuidorID = (int)(Math.Round(NumberUtil.Val( GetPar( "DistribuidorID"), "."), 18, MidpointRounding.ToEven));
         edtFacturaID_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtFacturaID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaID_Visible), 5, 0), !bGXsfl_72_Refreshing);
         cmbFacturaEstatus.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, cmbFacturaEstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbFacturaEstatus.Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtUsuarioID_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtUsuarioID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioID_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtMotivoRechazoActivo_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtMotivoRechazoActivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoActivo_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtMotivoRechazoDescripcion_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtMotivoRechazoDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoDescripcion_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtMotivoRechazoID_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtMotivoRechazoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoID_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtavMotivorechazo_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavMotivorechazo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMotivorechazo_Visible), 5, 0), !bGXsfl_72_Refreshing);
         A81DistribuidoresUsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "DistribuidoresUsuarioID"), "."), 18, MidpointRounding.ToEven));
         A11DistribuidorDescripcion = GetPar( "DistribuidorDescripcion");
         AV127EnCola = StringUtil.StrToBool( GetPar( "EnCola"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV121Cambios);
         AV19FacturaID = (int)(Math.Round(NumberUtil.Val( GetPar( "FacturaID"), "."), 18, MidpointRounding.ToEven));
         AV37RegUsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "RegUsuarioID"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFreestylegrid1_refresh( subFreestylegrid1_Rows, AV22FromDate, AV52ToDate, AV92FacturaEstatus, AV99FacturaNo, AV90TotalRows, AV117DoScroll, AV116KeepPage, AV95PromocionID, AV97UsuarioID, AV100UsuariosFiltro, AV62ListaUsuarios, AV15DistribuidorID, A40UsuarioRol, A10DistribuidorID, A81DistribuidoresUsuarioID, A11DistribuidorDescripcion, AV127EnCola, AV121Cambios, AV19FacturaID, AV37RegUsuarioID) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFreestylegrid1_refresh_invoke */
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
         PA4R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4R2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpfacturasnew.aspx") +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vDOSCROLL", AV117DoScroll);
         GxWebStd.gx_hidden_field( context, "gxhash_vDOSCROLL", GetSecureSignedToken( "", AV117DoScroll, context));
         GxWebStd.gx_hidden_field( context, "vKEEPPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV116KeepPage), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vKEEPPAGE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV116KeepPage), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vREGUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37RegUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREGUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV37RegUsuarioID), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFROMDATE", context.localUtil.Format(AV22FromDate, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vTODATE", context.localUtil.Format(AV52ToDate, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vFACTURAESTATUS", StringUtil.RTrim( AV92FacturaEstatus));
         GxWebStd.gx_hidden_field( context, "GXH_vFACTURANO", StringUtil.RTrim( AV99FacturaNo));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_72", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_72), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV12DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV12DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISTRIBUIDORID_DATA", AV16DistribuidorID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISTRIBUIDORID_DATA", AV16DistribuidorID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROMOCIONID_DATA", AV96PromocionID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROMOCIONID_DATA", AV96PromocionID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIOID_DATA", AV98UsuarioID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIOID_DATA", AV98UsuarioID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vELEMENTS", AV72Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vELEMENTS", AV72Elements);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPARAMETERS", AV73Parameters);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPARAMETERS", AV73Parameters);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCLICKDATA", AV74ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCLICKDATA", AV74ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMDOUBLECLICKDATA", AV75ItemDoubleClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMDOUBLECLICKDATA", AV75ItemDoubleClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDRAGANDDROPDATA", AV76DragAndDropData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDRAGANDDROPDATA", AV76DragAndDropData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERCHANGEDDATA", AV77FilterChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERCHANGEDDATA", AV77FilterChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMEXPANDDATA", AV78ItemExpandData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMEXPANDDATA", AV78ItemExpandData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCOLLAPSEDATA", AV79ItemCollapseData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCOLLAPSEDATA", AV79ItemCollapseData);
         }
         GxWebStd.gx_hidden_field( context, "vFREESTYLEGRID1PAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV87FreeStyleGrid1PageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vFREESTYLEGRID1APPLIEDFILTERS", AV88FreeStyleGrid1AppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMOTIVORECHAZOID_DATA", AV108MotivoRechazoID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMOTIVORECHAZOID_DATA", AV108MotivoRechazoID_Data);
         }
         GxWebStd.gx_hidden_field( context, "vTOTALROWS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV90TotalRows), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDOSCROLL", AV117DoScroll);
         GxWebStd.gx_hidden_field( context, "gxhash_vDOSCROLL", GetSecureSignedToken( "", AV117DoScroll, context));
         GxWebStd.gx_hidden_field( context, "vKEEPPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV116KeepPage), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vKEEPPAGE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV116KeepPage), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROMOCIONID", AV95PromocionID);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROMOCIONID", AV95PromocionID);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIOID", AV97UsuarioID);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIOID", AV97UsuarioID);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIOSFILTRO", AV100UsuariosFiltro);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIOSFILTRO", AV100UsuariosFiltro);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLISTAUSUARIOS", AV62ListaUsuarios);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLISTAUSUARIOS", AV62ListaUsuarios);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISTRIBUIDORID", AV15DistribuidorID);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISTRIBUIDORID", AV15DistribuidorID);
         }
         GxWebStd.gx_hidden_field( context, "USUARIOROL", StringUtil.RTrim( A40UsuarioRol));
         GxWebStd.gx_hidden_field( context, "DISTRIBUIDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10DistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "DISTRIBUIDORESUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A81DistribuidoresUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "DISTRIBUIDORDESCRIPCION", A11DistribuidorDescripcion);
         GxWebStd.gx_boolean_hidden_field( context, "vENCOLA", AV127EnCola);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCAMBIOS", AV121Cambios);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCAMBIOS", AV121Cambios);
         }
         GxWebStd.gx_hidden_field( context, "vFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vREGUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37RegUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREGUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV37RegUsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vBLOB", AV5Blob);
         GxWebStd.gx_hidden_field( context, "FACTURAPDF", A75FacturaPDF);
         GxWebStd.gx_hidden_field( context, "vSELESTATUSADMIN", StringUtil.RTrim( AV131SelEstatusAdmin));
         GxWebStd.gx_hidden_field( context, "vSELFACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV132SelFacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vSELFACTURAESTATUS", StringUtil.RTrim( AV134SelFacturaEstatus));
         GxWebStd.gx_hidden_field( context, "vSELMOTIVORECHAZOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV133SelMotivoRechazoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "USUARIONOMBRE", StringUtil.RTrim( A30UsuarioNombre));
         GxWebStd.gx_hidden_field( context, "USUARIOAPELLIDO", StringUtil.RTrim( A51UsuarioApellido));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Cls", StringUtil.RTrim( Combo_distribuidorid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Selectedvalue_set", StringUtil.RTrim( Combo_distribuidorid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Allowmultipleselection", StringUtil.BoolToStr( Combo_distribuidorid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_distribuidorid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Emptyitem", StringUtil.BoolToStr( Combo_distribuidorid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Multiplevaluestype", StringUtil.RTrim( Combo_distribuidorid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONID_Cls", StringUtil.RTrim( Combo_promocionid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONID_Selectedvalue_set", StringUtil.RTrim( Combo_promocionid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONID_Allowmultipleselection", StringUtil.BoolToStr( Combo_promocionid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_promocionid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONID_Multiplevaluestype", StringUtil.RTrim( Combo_promocionid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIOID_Cls", StringUtil.RTrim( Combo_usuarioid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIOID_Selectedvalue_set", StringUtil.RTrim( Combo_usuarioid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIOID_Allowmultipleselection", StringUtil.BoolToStr( Combo_usuarioid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIOID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_usuarioid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIOID_Multiplevaluestype", StringUtil.RTrim( Combo_usuarioid_Multiplevaluestype));
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
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Class", StringUtil.RTrim( Freestylegrid1paginationbar_Class));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Freestylegrid1paginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Freestylegrid1paginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Shownext", StringUtil.BoolToStr( Freestylegrid1paginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Showlast", StringUtil.BoolToStr( Freestylegrid1paginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Freestylegrid1paginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Freestylegrid1paginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Freestylegrid1paginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Freestylegrid1paginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Freestylegrid1paginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Freestylegrid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Freestylegrid1paginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Previous", StringUtil.RTrim( Freestylegrid1paginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Next", StringUtil.RTrim( Freestylegrid1paginationbar_Next));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Caption", StringUtil.RTrim( Freestylegrid1paginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Freestylegrid1paginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Freestylegrid1paginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "COMBO_MOTIVORECHAZOID_Cls", StringUtil.RTrim( Combo_motivorechazoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MOTIVORECHAZOID_Enabled", StringUtil.BoolToStr( Combo_motivorechazoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_MOTIVORECHAZOID_Visible", StringUtil.BoolToStr( Combo_motivorechazoid_Visible));
         GxWebStd.gx_hidden_field( context, "COMBO_MOTIVORECHAZOID_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_motivorechazoid_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_MOTIVORECHAZOID_Isgriditem", StringUtil.BoolToStr( Combo_motivorechazoid_Isgriditem));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Freestylegrid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Freestylegrid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIOID_Selectedvalue_get", StringUtil.RTrim( Combo_usuarioid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONID_Selectedvalue_get", StringUtil.RTrim( Combo_promocionid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Selectedvalue_get", StringUtil.RTrim( Combo_distribuidorid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "FACTURAID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaID_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FACTURAESTATUS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFacturaEstatus.Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioID_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MOTIVORECHAZOACTIVO_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMotivoRechazoActivo_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MOTIVORECHAZODESCRIPCION_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMotivoRechazoDescripcion_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MOTIVORECHAZOID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMotivoRechazoID_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMOTIVORECHAZO_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMotivorechazo_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Freestylegrid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Freestylegrid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIOID_Selectedvalue_get", StringUtil.RTrim( Combo_usuarioid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROMOCIONID_Selectedvalue_get", StringUtil.RTrim( Combo_promocionid_Selectedvalue_get));
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
         if ( ! ( WebComp_Allestatuswebcomponent1 == null ) )
         {
            WebComp_Allestatuswebcomponent1.componentjscripts();
         }
         if ( ! ( WebComp_Estatusenprocesowebcomponent1 == null ) )
         {
            WebComp_Estatusenprocesowebcomponent1.componentjscripts();
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
            WE4R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4R2( ) ;
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
         return formatLink("wpfacturasnew.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPFacturasNew" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Facturas", "") ;
      }

      protected void WB4R0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'" + sGXsfl_72_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFromdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFromdate_Internalname, context.localUtil.Format(AV22FromDate, "99/99/9999"), context.localUtil.Format( AV22FromDate, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFromdate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFromdate_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "FilterDate", "end", false, "", "HLP_WPFacturasNew.htm");
            GxWebStd.gx_bitmap( context, edtavFromdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFromdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPFacturasNew.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'" + sGXsfl_72_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTodate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTodate_Internalname, context.localUtil.Format(AV52ToDate, "99/99/9999"), context.localUtil.Format( AV52ToDate, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTodate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTodate_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "FilterDate", "end", false, "", "HLP_WPFacturasNew.htm");
            GxWebStd.gx_bitmap( context, edtavTodate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTodate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPFacturasNew.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavFacturaestatus_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFacturaestatus_Internalname, context.GetMessage( "Estatus", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'" + sGXsfl_72_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFacturaestatus, cmbavFacturaestatus_Internalname, StringUtil.RTrim( AV92FacturaEstatus), 1, cmbavFacturaestatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFacturaestatus.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "", true, 0, "HLP_WPFacturasNew.htm");
            cmbavFacturaestatus.CurrentValue = StringUtil.RTrim( AV92FacturaEstatus);
            AssignProp("", false, cmbavFacturaestatus_Internalname, "Values", (string)(cmbavFacturaestatus.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFacturano_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFacturano_Internalname, context.GetMessage( "No. Factura ", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_72_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFacturano_Internalname, StringUtil.RTrim( AV99FacturaNo), StringUtil.RTrim( context.localUtil.Format( AV99FacturaNo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFacturano_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFacturano_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPFacturasNew.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplitteddistribuidorid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_distribuidorid_Internalname, context.GetMessage( "Distribuidores", ""), "", "", lblTextblockcombo_distribuidorid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPFacturasNew.htm");
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
            ucCombo_distribuidorid.SetProperty("DropDownOptionsTitleSettingsIcons", AV12DDO_TitleSettingsIcons);
            ucCombo_distribuidorid.SetProperty("DropDownOptionsData", AV16DistribuidorID_Data);
            ucCombo_distribuidorid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_distribuidorid_Internalname, "COMBO_DISTRIBUIDORIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedpromocionid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_promocionid_Internalname, context.GetMessage( "Promoción", ""), "", "", lblTextblockcombo_promocionid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPFacturasNew.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_promocionid.SetProperty("Caption", Combo_promocionid_Caption);
            ucCombo_promocionid.SetProperty("Cls", Combo_promocionid_Cls);
            ucCombo_promocionid.SetProperty("AllowMultipleSelection", Combo_promocionid_Allowmultipleselection);
            ucCombo_promocionid.SetProperty("IncludeOnlySelectedOption", Combo_promocionid_Includeonlyselectedoption);
            ucCombo_promocionid.SetProperty("MultipleValuesType", Combo_promocionid_Multiplevaluestype);
            ucCombo_promocionid.SetProperty("DropDownOptionsTitleSettingsIcons", AV12DDO_TitleSettingsIcons);
            ucCombo_promocionid.SetProperty("DropDownOptionsData", AV96PromocionID_Data);
            ucCombo_promocionid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_promocionid_Internalname, "COMBO_PROMOCIONIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedusuarioid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_usuarioid_Internalname, context.GetMessage( "Usuarios", ""), "", "", lblTextblockcombo_usuarioid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPFacturasNew.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_usuarioid.SetProperty("Caption", Combo_usuarioid_Caption);
            ucCombo_usuarioid.SetProperty("Cls", Combo_usuarioid_Cls);
            ucCombo_usuarioid.SetProperty("AllowMultipleSelection", Combo_usuarioid_Allowmultipleselection);
            ucCombo_usuarioid.SetProperty("IncludeOnlySelectedOption", Combo_usuarioid_Includeonlyselectedoption);
            ucCombo_usuarioid.SetProperty("MultipleValuesType", Combo_usuarioid_Multiplevaluestype);
            ucCombo_usuarioid.SetProperty("DropDownOptionsTitleSettingsIcons", AV12DDO_TitleSettingsIcons);
            ucCombo_usuarioid.SetProperty("DropDownOptionsData", AV98UsuarioID_Data);
            ucCombo_usuarioid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_usuarioid_Internalname, "COMBO_USUARIOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction99_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(72), 2, 0)+","+"null"+");", context.GetMessage( "Aplicar filtro", ""), bttBtnuseraction99_Jsonclick, 5, context.GetMessage( "Aplicar filtro", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION99\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPFacturasNew.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "end", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "BotonImagenChicaVerde" + " " + ((StringUtil.StrCmp(imgGeneraexcel_gximage, "")==0) ? "GX_Image_ActionExport_Class" : "GX_Image_"+imgGeneraexcel_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgGeneraexcel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgGeneraexcel_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOGENERAEXCEL\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPFacturasNew.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
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
            ucUtchartdoughnut.SetProperty("Elements", AV72Elements);
            ucUtchartdoughnut.SetProperty("Parameters", AV73Parameters);
            ucUtchartdoughnut.SetProperty("Type", Utchartdoughnut_Type);
            ucUtchartdoughnut.SetProperty("Title", Utchartdoughnut_Title);
            ucUtchartdoughnut.SetProperty("ShowValues", Utchartdoughnut_Showvalues);
            ucUtchartdoughnut.SetProperty("ChartType", Utchartdoughnut_Charttype);
            ucUtchartdoughnut.SetProperty("ItemClickData", AV74ItemClickData);
            ucUtchartdoughnut.SetProperty("ItemDoubleClickData", AV75ItemDoubleClickData);
            ucUtchartdoughnut.SetProperty("DragAndDropData", AV76DragAndDropData);
            ucUtchartdoughnut.SetProperty("FilterChangedData", AV77FilterChangedData);
            ucUtchartdoughnut.SetProperty("ItemExpandData", AV78ItemExpandData);
            ucUtchartdoughnut.SetProperty("ItemCollapseData", AV79ItemCollapseData);
            ucUtchartdoughnut.Render(context, "queryviewer", Utchartdoughnut_Internalname, "UTCHARTDOUGHNUTContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartcolumnline.SetProperty("Elements", AV72Elements);
            ucUtchartcolumnline.SetProperty("Parameters", AV73Parameters);
            ucUtchartcolumnline.SetProperty("Type", Utchartcolumnline_Type);
            ucUtchartcolumnline.SetProperty("Title", Utchartcolumnline_Title);
            ucUtchartcolumnline.SetProperty("ItemClickData", AV74ItemClickData);
            ucUtchartcolumnline.SetProperty("ItemDoubleClickData", AV75ItemDoubleClickData);
            ucUtchartcolumnline.SetProperty("DragAndDropData", AV76DragAndDropData);
            ucUtchartcolumnline.SetProperty("FilterChangedData", AV77FilterChangedData);
            ucUtchartcolumnline.SetProperty("ItemExpandData", AV78ItemExpandData);
            ucUtchartcolumnline.SetProperty("ItemCollapseData", AV79ItemCollapseData);
            ucUtchartcolumnline.Render(context, "queryviewer", Utchartcolumnline_Internalname, "UTCHARTCOLUMNLINEContainer");
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
            GxWebStd.gx_div_start( context, divFreestylegrid1tablewithpaging_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Freestylegrid1Container.SetIsFreestyle(true);
            Freestylegrid1Container.SetWrapped(nGXWrapped);
            StartGridControl72( ) ;
         }
         if ( wbEnd == 72 )
         {
            wbEnd = 0;
            nRC_GXsfl_72 = (int)(nGXsfl_72_idx-1);
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucFreestylegrid1paginationbar.SetProperty("Class", Freestylegrid1paginationbar_Class);
            ucFreestylegrid1paginationbar.SetProperty("ShowFirst", Freestylegrid1paginationbar_Showfirst);
            ucFreestylegrid1paginationbar.SetProperty("ShowPrevious", Freestylegrid1paginationbar_Showprevious);
            ucFreestylegrid1paginationbar.SetProperty("ShowNext", Freestylegrid1paginationbar_Shownext);
            ucFreestylegrid1paginationbar.SetProperty("ShowLast", Freestylegrid1paginationbar_Showlast);
            ucFreestylegrid1paginationbar.SetProperty("PagesToShow", Freestylegrid1paginationbar_Pagestoshow);
            ucFreestylegrid1paginationbar.SetProperty("PagingButtonsPosition", Freestylegrid1paginationbar_Pagingbuttonsposition);
            ucFreestylegrid1paginationbar.SetProperty("PagingCaptionPosition", Freestylegrid1paginationbar_Pagingcaptionposition);
            ucFreestylegrid1paginationbar.SetProperty("EmptyGridClass", Freestylegrid1paginationbar_Emptygridclass);
            ucFreestylegrid1paginationbar.SetProperty("RowsPerPageSelector", Freestylegrid1paginationbar_Rowsperpageselector);
            ucFreestylegrid1paginationbar.SetProperty("RowsPerPageOptions", Freestylegrid1paginationbar_Rowsperpageoptions);
            ucFreestylegrid1paginationbar.SetProperty("Previous", Freestylegrid1paginationbar_Previous);
            ucFreestylegrid1paginationbar.SetProperty("Next", Freestylegrid1paginationbar_Next);
            ucFreestylegrid1paginationbar.SetProperty("Caption", Freestylegrid1paginationbar_Caption);
            ucFreestylegrid1paginationbar.SetProperty("EmptyGridCaption", Freestylegrid1paginationbar_Emptygridcaption);
            ucFreestylegrid1paginationbar.SetProperty("RowsPerPageCaption", Freestylegrid1paginationbar_Rowsperpagecaption);
            ucFreestylegrid1paginationbar.SetProperty("CurrentPage", AV86FreeStyleGrid1CurrentPage);
            ucFreestylegrid1paginationbar.SetProperty("PageCount", AV87FreeStyleGrid1PageCount);
            ucFreestylegrid1paginationbar.SetProperty("AppliedFilters", AV88FreeStyleGrid1AppliedFilters);
            ucFreestylegrid1paginationbar.Render(context, "dvelop.dvpaginationbar", Freestylegrid1paginationbar_Internalname, "FREESTYLEGRID1PAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 251,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncambiarestatus_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(72), 2, 0)+","+"null"+");", context.GetMessage( "Aplicar cambios", ""), bttBtncambiarestatus_Jsonclick, 5, context.GetMessage( "Aplicar cambios", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCAMBIARESTATUS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPFacturasNew.htm");
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
            ucCombo_motivorechazoid.SetProperty("Caption", Combo_motivorechazoid_Caption);
            ucCombo_motivorechazoid.SetProperty("Cls", Combo_motivorechazoid_Cls);
            ucCombo_motivorechazoid.SetProperty("IsGridItem", Combo_motivorechazoid_Isgriditem);
            ucCombo_motivorechazoid.SetProperty("DropDownOptionsData", AV108MotivoRechazoID_Data);
            ucCombo_motivorechazoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_motivorechazoid_Internalname, "COMBO_MOTIVORECHAZOIDContainer");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 256,'',false,'" + sGXsfl_72_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFreestylegrid1currentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV86FreeStyleGrid1CurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV86FreeStyleGrid1CurrentPage), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,256);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFreestylegrid1currentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavFreestylegrid1currentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPFacturasNew.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 72 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Freestylegrid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4R2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Facturas", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4R0( ) ;
      }

      protected void WS4R2( )
      {
         START4R2( ) ;
         EVT4R2( ) ;
      }

      protected void EVT4R2( )
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
                              E114R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_PROMOCIONID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_promocionid.Onoptionclicked */
                              E124R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_USUARIOID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_usuarioid.Onoptionclicked */
                              E134R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID1PAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Freestylegrid1paginationbar.Changepage */
                              E144R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID1PAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Freestylegrid1paginationbar.Changerowsperpage */
                              E154R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCAMBIARESTATUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCambiarEstatus' */
                              E164R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION99'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction99' */
                              E174R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOGENERAEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoGeneraExcel' */
                              E184R2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FREESTYLEGRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 31), "'DOESTATUSENPROCESOUSERACTION4'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "'DOALLESTATUSUSERACTION4'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "'DOUSERACTION4'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 36), "VVARESTATUSADMIN.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 36), "VMOTIVORECHAZOID.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "'DOALLESTATUSUSERACTION4'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 31), "'DOESTATUSENPROCESOUSERACTION4'") == 0 ) )
                           {
                              nGXsfl_72_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx), 4, 0), 4, "0");
                              SubsflControlProps_722( ) ;
                              A69FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbFacturaEstatus.Name = cmbFacturaEstatus_Internalname;
                              cmbFacturaEstatus.CurrentValue = cgiGet( cmbFacturaEstatus_Internalname);
                              A80FacturaEstatus = cgiGet( cmbFacturaEstatus_Internalname);
                              A29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A21MotivoRechazoActivo = StringUtil.StrToBool( cgiGet( edtMotivoRechazoActivo_Internalname));
                              A20MotivoRechazoDescripcion = cgiGet( edtMotivoRechazoDescripcion_Internalname);
                              A19MotivoRechazoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMotivoRechazoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A52UsuarioNombreCompleto = cgiGet( edtUsuarioNombreCompleto_Internalname);
                              A72FacturaFechaRegistro = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaRegistro_Internalname), 0));
                              A42PromocionDescripcion = cgiGet( edtPromocionDescripcion_Internalname);
                              A71FacturaNo = cgiGet( edtFacturaNo_Internalname);
                              A73FacturaFechaFactura = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaFactura_Internalname), 0));
                              AV85DistribuidorDescripcion = cgiGet( edtavDistribuidordescripcion_Internalname);
                              AssignAttri("", false, edtavDistribuidordescripcion_Internalname, AV85DistribuidorDescripcion);
                              cmbavVarestatus.Name = cmbavVarestatus_Internalname;
                              cmbavVarestatus.CurrentValue = cgiGet( cmbavVarestatus_Internalname);
                              AV103VarEstatus = cgiGet( cmbavVarestatus_Internalname);
                              AssignAttri("", false, cmbavVarestatus_Internalname, AV103VarEstatus);
                              AV111MotivoRechazo = cgiGet( edtavMotivorechazo_Internalname);
                              AssignAttri("", false, edtavMotivorechazo_Internalname, AV111MotivoRechazo);
                              A52UsuarioNombreCompleto = cgiGet( edtUsuarioNombreCompleto_Internalname);
                              A72FacturaFechaRegistro = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaRegistro_Internalname), 0));
                              A42PromocionDescripcion = cgiGet( edtPromocionDescripcion_Internalname);
                              A71FacturaNo = cgiGet( edtFacturaNo_Internalname);
                              A73FacturaFechaFactura = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFacturaFechaFactura_Internalname), 0));
                              AV85DistribuidorDescripcion = cgiGet( edtavDistribuidordescripcion_Internalname);
                              AssignAttri("", false, edtavDistribuidordescripcion_Internalname, AV85DistribuidorDescripcion);
                              cmbavVarestatusadmin.Name = cmbavVarestatusadmin_Internalname;
                              cmbavVarestatusadmin.CurrentValue = cgiGet( cmbavVarestatusadmin_Internalname);
                              AV105VarEstatusAdmin = cgiGet( cmbavVarestatusadmin_Internalname);
                              AssignAttri("", false, cmbavVarestatusadmin_Internalname, AV105VarEstatusAdmin);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavMotivorechazoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMotivorechazoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vMOTIVORECHAZOID");
                                 GX_FocusControl = edtavMotivorechazoid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV107MotivoRechazoID = 0;
                                 AssignAttri("", false, edtavMotivorechazoid_Internalname, StringUtil.LTrimStr( (decimal)(AV107MotivoRechazoID), 9, 0));
                              }
                              else
                              {
                                 AV107MotivoRechazoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavMotivorechazoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavMotivorechazoid_Internalname, StringUtil.LTrimStr( (decimal)(AV107MotivoRechazoID), 9, 0));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E194R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E204R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Freestylegrid1.Load */
                                    E214R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOESTATUSENPROCESOUSERACTION4'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoEstatusEnProcesoUserAction4' */
                                    E224R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOALLESTATUSUSERACTION4'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoAllEstatusUserAction4' */
                                    E234R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION4'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUserAction4' */
                                    E244R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VVARESTATUSADMIN.CONTROLVALUECHANGED") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E254R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VMOTIVORECHAZOID.CONTROLVALUECHANGED") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E264R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Fromdate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vFROMDATE"), 0) != AV22FromDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Todate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vTODATE"), 0) != AV52ToDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Facturaestatus Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFACTURAESTATUS"), AV92FacturaEstatus) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Facturano Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFACTURANO"), AV99FacturaNo) != 0 )
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
                        if ( nCmpId == 159 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0159" + sEvtType;
                           OldAllestatuswebcomponent1 = cgiGet( sCmpCtrl);
                           if ( ( StringUtil.Len( OldAllestatuswebcomponent1) == 0 ) || ( StringUtil.StrCmp(OldAllestatuswebcomponent1, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldAllestatuswebcomponent1, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldAllestatuswebcomponent1";
                              WebComp_GX_Process_Component = OldAllestatuswebcomponent1;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess("W0159", sEvtType, sEvt);
                           }
                           nGXsfl_72_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Allestatuswebcomponent1";
                           WebComp_GX_Process_Component = OldAllestatuswebcomponent1;
                        }
                        else if ( nCmpId == 242 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0242" + sEvtType;
                           OldEstatusenprocesowebcomponent1 = cgiGet( sCmpCtrl);
                           if ( ( StringUtil.Len( OldEstatusenprocesowebcomponent1) == 0 ) || ( StringUtil.StrCmp(OldEstatusenprocesowebcomponent1, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldEstatusenprocesowebcomponent1, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldEstatusenprocesowebcomponent1";
                              WebComp_GX_Process_Component = OldEstatusenprocesowebcomponent1;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess("W0242", sEvtType, sEvt);
                           }
                           nGXsfl_72_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Estatusenprocesowebcomponent1";
                           WebComp_GX_Process_Component = OldEstatusenprocesowebcomponent1;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE4R2( )
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

      protected void PA4R2( )
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

      protected void gxnrFreestylegrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_722( ) ;
         while ( nGXsfl_72_idx <= nRC_GXsfl_72 )
         {
            sendrow_722( ) ;
            nGXsfl_72_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_72_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_72_idx+1);
            sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx), 4, 0), 4, "0");
            SubsflControlProps_722( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Freestylegrid1Container)) ;
         /* End function gxnrFreestylegrid1_newrow */
      }

      protected void gxgrFreestylegrid1_refresh( int subFreestylegrid1_Rows ,
                                                 DateTime AV22FromDate ,
                                                 DateTime AV52ToDate ,
                                                 string AV92FacturaEstatus ,
                                                 string AV99FacturaNo ,
                                                 long AV90TotalRows ,
                                                 bool AV117DoScroll ,
                                                 short AV116KeepPage ,
                                                 GxSimpleCollection<int> AV95PromocionID ,
                                                 GxSimpleCollection<int> AV97UsuarioID ,
                                                 GxSimpleCollection<int> AV100UsuariosFiltro ,
                                                 GxSimpleCollection<int> AV62ListaUsuarios ,
                                                 GxSimpleCollection<int> AV15DistribuidorID ,
                                                 string A40UsuarioRol ,
                                                 int A10DistribuidorID ,
                                                 int A81DistribuidoresUsuarioID ,
                                                 string A11DistribuidorDescripcion ,
                                                 bool AV127EnCola ,
                                                 GXBaseCollection<SdtSDTCambioEstatus_SDTCambioEstatusItem> AV121Cambios ,
                                                 int AV19FacturaID ,
                                                 int AV37RegUsuarioID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FREESTYLEGRID1_nCurrentRecord = 0;
         RF4R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFreestylegrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_FACTURAFECHAFACTURA", GetSecureSignedToken( "", A73FacturaFechaFactura, context));
         GxWebStd.gx_hidden_field( context, "FACTURAFECHAFACTURA", context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_FACTURAESTATUS", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A80FacturaEstatus, "")), context));
         GxWebStd.gx_hidden_field( context, "FACTURAESTATUS", StringUtil.RTrim( A80FacturaEstatus));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "USUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_FACTURANO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A71FacturaNo, "")), context));
         GxWebStd.gx_hidden_field( context, "FACTURANO", StringUtil.RTrim( A71FacturaNo));
         GxWebStd.gx_hidden_field( context, "gxhash_FACTURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "FACTURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, ".", "")));
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
         if ( cmbavFacturaestatus.ItemCount > 0 )
         {
            AV92FacturaEstatus = cmbavFacturaestatus.getValidValue(AV92FacturaEstatus);
            AssignAttri("", false, "AV92FacturaEstatus", AV92FacturaEstatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFacturaestatus.CurrentValue = StringUtil.RTrim( AV92FacturaEstatus);
            AssignProp("", false, cmbavFacturaestatus_Internalname, "Values", cmbavFacturaestatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavDistribuidordescripcion_Enabled = 0;
         cmbavVarestatus.Enabled = 0;
         edtavMotivorechazo_Enabled = 0;
      }

      protected void RF4R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Freestylegrid1Container.ClearRows();
         }
         wbStart = 72;
         /* Execute user event: Refresh */
         E204R2 ();
         nGXsfl_72_idx = 1;
         sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx), 4, 0), 4, "0");
         SubsflControlProps_722( ) ;
         bGXsfl_72_Refreshing = true;
         Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         Freestylegrid1Container.AddObjectProperty("CmpContext", "");
         Freestylegrid1Container.AddObjectProperty("InMasterPage", "false");
         Freestylegrid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Freestylegrid1Container.AddObjectProperty("Class", "FreeStyleGrid");
         Freestylegrid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Backcolorstyle), 1, 0, ".", "")));
         Freestylegrid1Container.PageSize = subFreestylegrid1_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
               {
                  WebComp_GX_Process.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Allestatuswebcomponent1_Component) != 0 )
               {
                  WebComp_Allestatuswebcomponent1.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Estatusenprocesowebcomponent1_Component) != 0 )
               {
                  WebComp_Estatusenprocesowebcomponent1.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_722( ) ;
            GXPagingFrom2 = (int)(((subFreestylegrid1_Rows==0) ? 0 : FREESTYLEGRID1_nFirstRecordOnPage));
            GXPagingTo2 = ((subFreestylegrid1_Rows==0) ? 10000 : subFreestylegrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A29UsuarioID ,
                                                 AV100UsuariosFiltro ,
                                                 A41PromocionID ,
                                                 AV95PromocionID ,
                                                 AV22FromDate ,
                                                 AV52ToDate ,
                                                 AV100UsuariosFiltro.Count ,
                                                 AV92FacturaEstatus ,
                                                 AV95PromocionID.Count ,
                                                 AV99FacturaNo ,
                                                 A73FacturaFechaFactura ,
                                                 A80FacturaEstatus ,
                                                 A71FacturaNo ,
                                                 A93FacturaCompleta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor H004R2 */
            pr_default.execute(0, new Object[] {AV22FromDate, AV52ToDate, AV92FacturaEstatus, AV99FacturaNo, GXPagingFrom2, GXPagingTo2});
            nGXsfl_72_idx = 1;
            sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx), 4, 0), 4, "0");
            SubsflControlProps_722( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subFreestylegrid1_Rows == 0 ) || ( FREESTYLEGRID1_nCurrentRecord < subFreestylegrid1_fnc_Recordsperpage( ) ) ) ) )
            {
               A41PromocionID = H004R2_A41PromocionID[0];
               A93FacturaCompleta = H004R2_A93FacturaCompleta[0];
               A73FacturaFechaFactura = H004R2_A73FacturaFechaFactura[0];
               A71FacturaNo = H004R2_A71FacturaNo[0];
               A42PromocionDescripcion = H004R2_A42PromocionDescripcion[0];
               A72FacturaFechaRegistro = H004R2_A72FacturaFechaRegistro[0];
               A19MotivoRechazoID = H004R2_A19MotivoRechazoID[0];
               A20MotivoRechazoDescripcion = H004R2_A20MotivoRechazoDescripcion[0];
               A21MotivoRechazoActivo = H004R2_A21MotivoRechazoActivo[0];
               A29UsuarioID = H004R2_A29UsuarioID[0];
               A80FacturaEstatus = H004R2_A80FacturaEstatus[0];
               A69FacturaID = H004R2_A69FacturaID[0];
               A51UsuarioApellido = H004R2_A51UsuarioApellido[0];
               A30UsuarioNombre = H004R2_A30UsuarioNombre[0];
               A42PromocionDescripcion = H004R2_A42PromocionDescripcion[0];
               A20MotivoRechazoDescripcion = H004R2_A20MotivoRechazoDescripcion[0];
               A21MotivoRechazoActivo = H004R2_A21MotivoRechazoActivo[0];
               A51UsuarioApellido = H004R2_A51UsuarioApellido[0];
               A30UsuarioNombre = H004R2_A30UsuarioNombre[0];
               A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
               /* Execute user event: Freestylegrid1.Load */
               E214R2 ();
               pr_default.readNext(0);
            }
            FREESTYLEGRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 72;
            WB4R0( ) ;
         }
         bGXsfl_72_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4R2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vDOSCROLL", AV117DoScroll);
         GxWebStd.gx_hidden_field( context, "gxhash_vDOSCROLL", GetSecureSignedToken( "", AV117DoScroll, context));
         GxWebStd.gx_hidden_field( context, "vKEEPPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV116KeepPage), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vKEEPPAGE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV116KeepPage), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_FACTURAFECHAFACTURA"+"_"+sGXsfl_72_idx, GetSecureSignedToken( sGXsfl_72_idx, A73FacturaFechaFactura, context));
         GxWebStd.gx_hidden_field( context, "gxhash_FACTURAESTATUS"+"_"+sGXsfl_72_idx, GetSecureSignedToken( sGXsfl_72_idx, StringUtil.RTrim( context.localUtil.Format( A80FacturaEstatus, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOID"+"_"+sGXsfl_72_idx, GetSecureSignedToken( sGXsfl_72_idx, context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_FACTURANO"+"_"+sGXsfl_72_idx, GetSecureSignedToken( sGXsfl_72_idx, StringUtil.RTrim( context.localUtil.Format( A71FacturaNo, "")), context));
         GxWebStd.gx_hidden_field( context, "vREGUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37RegUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREGUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV37RegUsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_FACTURAID"+"_"+sGXsfl_72_idx, GetSecureSignedToken( sGXsfl_72_idx, context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9"), context));
      }

      protected int subFreestylegrid1_fnc_Pagecount( )
      {
         FREESTYLEGRID1_nRecordCount = subFreestylegrid1_fnc_Recordcount( );
         if ( ((int)((FREESTYLEGRID1_nRecordCount) % (subFreestylegrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(FREESTYLEGRID1_nRecordCount/ (decimal)(subFreestylegrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(FREESTYLEGRID1_nRecordCount/ (decimal)(subFreestylegrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subFreestylegrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A29UsuarioID ,
                                              AV100UsuariosFiltro ,
                                              A41PromocionID ,
                                              AV95PromocionID ,
                                              AV22FromDate ,
                                              AV52ToDate ,
                                              AV100UsuariosFiltro.Count ,
                                              AV92FacturaEstatus ,
                                              AV95PromocionID.Count ,
                                              AV99FacturaNo ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              A71FacturaNo ,
                                              A93FacturaCompleta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H004R3 */
         pr_default.execute(1, new Object[] {AV22FromDate, AV52ToDate, AV92FacturaEstatus, AV99FacturaNo});
         FREESTYLEGRID1_nRecordCount = H004R3_AFREESTYLEGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(FREESTYLEGRID1_nRecordCount) ;
      }

      protected int subFreestylegrid1_fnc_Recordsperpage( )
      {
         if ( subFreestylegrid1_Rows > 0 )
         {
            return subFreestylegrid1_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subFreestylegrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(FREESTYLEGRID1_nFirstRecordOnPage/ (decimal)(subFreestylegrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subfreestylegrid1_firstpage( )
      {
         FREESTYLEGRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrFreestylegrid1_refresh( subFreestylegrid1_Rows, AV22FromDate, AV52ToDate, AV92FacturaEstatus, AV99FacturaNo, AV90TotalRows, AV117DoScroll, AV116KeepPage, AV95PromocionID, AV97UsuarioID, AV100UsuariosFiltro, AV62ListaUsuarios, AV15DistribuidorID, A40UsuarioRol, A10DistribuidorID, A81DistribuidoresUsuarioID, A11DistribuidorDescripcion, AV127EnCola, AV121Cambios, AV19FacturaID, AV37RegUsuarioID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subfreestylegrid1_nextpage( )
      {
         FREESTYLEGRID1_nRecordCount = subFreestylegrid1_fnc_Recordcount( );
         if ( ( FREESTYLEGRID1_nRecordCount >= subFreestylegrid1_fnc_Recordsperpage( ) ) && ( FREESTYLEGRID1_nEOF == 0 ) )
         {
            FREESTYLEGRID1_nFirstRecordOnPage = (long)(FREESTYLEGRID1_nFirstRecordOnPage+subFreestylegrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("FREESTYLEGRID1_nFirstRecordOnPage", FREESTYLEGRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrFreestylegrid1_refresh( subFreestylegrid1_Rows, AV22FromDate, AV52ToDate, AV92FacturaEstatus, AV99FacturaNo, AV90TotalRows, AV117DoScroll, AV116KeepPage, AV95PromocionID, AV97UsuarioID, AV100UsuariosFiltro, AV62ListaUsuarios, AV15DistribuidorID, A40UsuarioRol, A10DistribuidorID, A81DistribuidoresUsuarioID, A11DistribuidorDescripcion, AV127EnCola, AV121Cambios, AV19FacturaID, AV37RegUsuarioID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((FREESTYLEGRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subfreestylegrid1_previouspage( )
      {
         if ( FREESTYLEGRID1_nFirstRecordOnPage >= subFreestylegrid1_fnc_Recordsperpage( ) )
         {
            FREESTYLEGRID1_nFirstRecordOnPage = (long)(FREESTYLEGRID1_nFirstRecordOnPage-subFreestylegrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrFreestylegrid1_refresh( subFreestylegrid1_Rows, AV22FromDate, AV52ToDate, AV92FacturaEstatus, AV99FacturaNo, AV90TotalRows, AV117DoScroll, AV116KeepPage, AV95PromocionID, AV97UsuarioID, AV100UsuariosFiltro, AV62ListaUsuarios, AV15DistribuidorID, A40UsuarioRol, A10DistribuidorID, A81DistribuidoresUsuarioID, A11DistribuidorDescripcion, AV127EnCola, AV121Cambios, AV19FacturaID, AV37RegUsuarioID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subfreestylegrid1_lastpage( )
      {
         FREESTYLEGRID1_nRecordCount = subFreestylegrid1_fnc_Recordcount( );
         if ( FREESTYLEGRID1_nRecordCount > subFreestylegrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((FREESTYLEGRID1_nRecordCount) % (subFreestylegrid1_fnc_Recordsperpage( )))) == 0 )
            {
               FREESTYLEGRID1_nFirstRecordOnPage = (long)(FREESTYLEGRID1_nRecordCount-subFreestylegrid1_fnc_Recordsperpage( ));
            }
            else
            {
               FREESTYLEGRID1_nFirstRecordOnPage = (long)(FREESTYLEGRID1_nRecordCount-((int)((FREESTYLEGRID1_nRecordCount) % (subFreestylegrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            FREESTYLEGRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrFreestylegrid1_refresh( subFreestylegrid1_Rows, AV22FromDate, AV52ToDate, AV92FacturaEstatus, AV99FacturaNo, AV90TotalRows, AV117DoScroll, AV116KeepPage, AV95PromocionID, AV97UsuarioID, AV100UsuariosFiltro, AV62ListaUsuarios, AV15DistribuidorID, A40UsuarioRol, A10DistribuidorID, A81DistribuidoresUsuarioID, A11DistribuidorDescripcion, AV127EnCola, AV121Cambios, AV19FacturaID, AV37RegUsuarioID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subfreestylegrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            FREESTYLEGRID1_nFirstRecordOnPage = (long)(subFreestylegrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            FREESTYLEGRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrFreestylegrid1_refresh( subFreestylegrid1_Rows, AV22FromDate, AV52ToDate, AV92FacturaEstatus, AV99FacturaNo, AV90TotalRows, AV117DoScroll, AV116KeepPage, AV95PromocionID, AV97UsuarioID, AV100UsuariosFiltro, AV62ListaUsuarios, AV15DistribuidorID, A40UsuarioRol, A10DistribuidorID, A81DistribuidoresUsuarioID, A11DistribuidorDescripcion, AV127EnCola, AV121Cambios, AV19FacturaID, AV37RegUsuarioID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavDistribuidordescripcion_Enabled = 0;
         cmbavVarestatus.Enabled = 0;
         edtavMotivorechazo_Enabled = 0;
         edtFacturaID_Enabled = 0;
         cmbFacturaEstatus.Enabled = 0;
         edtUsuarioID_Enabled = 0;
         edtMotivoRechazoActivo_Enabled = 0;
         edtMotivoRechazoDescripcion_Enabled = 0;
         edtMotivoRechazoID_Enabled = 0;
         edtUsuarioNombreCompleto_Enabled = 0;
         edtFacturaFechaRegistro_Enabled = 0;
         edtPromocionDescripcion_Enabled = 0;
         edtFacturaNo_Enabled = 0;
         edtFacturaFechaFactura_Enabled = 0;
         edtUsuarioNombreCompleto_Enabled = 0;
         edtFacturaFechaRegistro_Enabled = 0;
         edtPromocionDescripcion_Enabled = 0;
         edtFacturaNo_Enabled = 0;
         edtFacturaFechaFactura_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E194R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV12DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vDISTRIBUIDORID_DATA"), AV16DistribuidorID_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vPROMOCIONID_DATA"), AV96PromocionID_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vUSUARIOID_DATA"), AV98UsuarioID_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vELEMENTS"), AV72Elements);
            ajax_req_read_hidden_sdt(cgiGet( "vPARAMETERS"), AV73Parameters);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCLICKDATA"), AV74ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMDOUBLECLICKDATA"), AV75ItemDoubleClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vDRAGANDDROPDATA"), AV76DragAndDropData);
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERCHANGEDDATA"), AV77FilterChangedData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMEXPANDDATA"), AV78ItemExpandData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCOLLAPSEDATA"), AV79ItemCollapseData);
            ajax_req_read_hidden_sdt(cgiGet( "vMOTIVORECHAZOID_DATA"), AV108MotivoRechazoID_Data);
            /* Read saved values. */
            nRC_GXsfl_72 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_72"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV87FreeStyleGrid1PageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vFREESTYLEGRID1PAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV88FreeStyleGrid1AppliedFilters = cgiGet( "vFREESTYLEGRID1APPLIEDFILTERS");
            FREESTYLEGRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "FREESTYLEGRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            FREESTYLEGRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "FREESTYLEGRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subFreestylegrid1_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FREESTYLEGRID1_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Rows), 6, 0, ".", "")));
            Combo_distribuidorid_Cls = cgiGet( "COMBO_DISTRIBUIDORID_Cls");
            Combo_distribuidorid_Selectedvalue_set = cgiGet( "COMBO_DISTRIBUIDORID_Selectedvalue_set");
            Combo_distribuidorid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_DISTRIBUIDORID_Allowmultipleselection"));
            Combo_distribuidorid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_DISTRIBUIDORID_Includeonlyselectedoption"));
            Combo_distribuidorid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_DISTRIBUIDORID_Emptyitem"));
            Combo_distribuidorid_Multiplevaluestype = cgiGet( "COMBO_DISTRIBUIDORID_Multiplevaluestype");
            Combo_promocionid_Cls = cgiGet( "COMBO_PROMOCIONID_Cls");
            Combo_promocionid_Selectedvalue_set = cgiGet( "COMBO_PROMOCIONID_Selectedvalue_set");
            Combo_promocionid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROMOCIONID_Allowmultipleselection"));
            Combo_promocionid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROMOCIONID_Includeonlyselectedoption"));
            Combo_promocionid_Multiplevaluestype = cgiGet( "COMBO_PROMOCIONID_Multiplevaluestype");
            Combo_usuarioid_Cls = cgiGet( "COMBO_USUARIOID_Cls");
            Combo_usuarioid_Selectedvalue_set = cgiGet( "COMBO_USUARIOID_Selectedvalue_set");
            Combo_usuarioid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_USUARIOID_Allowmultipleselection"));
            Combo_usuarioid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_USUARIOID_Includeonlyselectedoption"));
            Combo_usuarioid_Multiplevaluestype = cgiGet( "COMBO_USUARIOID_Multiplevaluestype");
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
            Freestylegrid1paginationbar_Class = cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Class");
            Freestylegrid1paginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Showfirst"));
            Freestylegrid1paginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Showprevious"));
            Freestylegrid1paginationbar_Shownext = StringUtil.StrToBool( cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Shownext"));
            Freestylegrid1paginationbar_Showlast = StringUtil.StrToBool( cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Showlast"));
            Freestylegrid1paginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Freestylegrid1paginationbar_Pagingbuttonsposition = cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Pagingbuttonsposition");
            Freestylegrid1paginationbar_Pagingcaptionposition = cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Pagingcaptionposition");
            Freestylegrid1paginationbar_Emptygridclass = cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Emptygridclass");
            Freestylegrid1paginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Rowsperpageselector"));
            Freestylegrid1paginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Freestylegrid1paginationbar_Rowsperpageoptions = cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Rowsperpageoptions");
            Freestylegrid1paginationbar_Previous = cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Previous");
            Freestylegrid1paginationbar_Next = cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Next");
            Freestylegrid1paginationbar_Caption = cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Caption");
            Freestylegrid1paginationbar_Emptygridcaption = cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Emptygridcaption");
            Freestylegrid1paginationbar_Rowsperpagecaption = cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Rowsperpagecaption");
            Combo_motivorechazoid_Cls = cgiGet( "COMBO_MOTIVORECHAZOID_Cls");
            Combo_motivorechazoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_MOTIVORECHAZOID_Enabled"));
            Combo_motivorechazoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_MOTIVORECHAZOID_Visible"));
            Combo_motivorechazoid_Titlecontrolidtoreplace = cgiGet( "COMBO_MOTIVORECHAZOID_Titlecontrolidtoreplace");
            Combo_motivorechazoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_MOTIVORECHAZOID_Isgriditem"));
            subFreestylegrid1_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FREESTYLEGRID1_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Rows), 6, 0, ".", "")));
            Freestylegrid1paginationbar_Selectedpage = cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Selectedpage");
            Freestylegrid1paginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FREESTYLEGRID1PAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Combo_usuarioid_Selectedvalue_get = cgiGet( "COMBO_USUARIOID_Selectedvalue_get");
            Combo_promocionid_Selectedvalue_get = cgiGet( "COMBO_PROMOCIONID_Selectedvalue_get");
            Combo_distribuidorid_Selectedvalue_get = cgiGet( "COMBO_DISTRIBUIDORID_Selectedvalue_get");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavFromdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "From Date", "")}), 1, "vFROMDATE");
               GX_FocusControl = edtavFromdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22FromDate = DateTime.MinValue;
               AssignAttri("", false, "AV22FromDate", context.localUtil.Format(AV22FromDate, "99/99/9999"));
            }
            else
            {
               AV22FromDate = context.localUtil.CToD( cgiGet( edtavFromdate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV22FromDate", context.localUtil.Format(AV22FromDate, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTodate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "To Date", "")}), 1, "vTODATE");
               GX_FocusControl = edtavTodate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV52ToDate = DateTime.MinValue;
               AssignAttri("", false, "AV52ToDate", context.localUtil.Format(AV52ToDate, "99/99/9999"));
            }
            else
            {
               AV52ToDate = context.localUtil.CToD( cgiGet( edtavTodate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV52ToDate", context.localUtil.Format(AV52ToDate, "99/99/9999"));
            }
            cmbavFacturaestatus.Name = cmbavFacturaestatus_Internalname;
            cmbavFacturaestatus.CurrentValue = cgiGet( cmbavFacturaestatus_Internalname);
            AV92FacturaEstatus = cgiGet( cmbavFacturaestatus_Internalname);
            AssignAttri("", false, "AV92FacturaEstatus", AV92FacturaEstatus);
            AV99FacturaNo = cgiGet( edtavFacturano_Internalname);
            AssignAttri("", false, "AV99FacturaNo", AV99FacturaNo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFreestylegrid1currentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFreestylegrid1currentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFREESTYLEGRID1CURRENTPAGE");
               GX_FocusControl = edtavFreestylegrid1currentpage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV86FreeStyleGrid1CurrentPage = 0;
               AssignAttri("", false, "AV86FreeStyleGrid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV86FreeStyleGrid1CurrentPage), 10, 0));
            }
            else
            {
               AV86FreeStyleGrid1CurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavFreestylegrid1currentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV86FreeStyleGrid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV86FreeStyleGrid1CurrentPage), 10, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vFROMDATE"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV22FromDate ) )
            {
               FREESTYLEGRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vTODATE"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV52ToDate ) )
            {
               FREESTYLEGRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFACTURAESTATUS"), AV92FacturaEstatus) != 0 )
            {
               FREESTYLEGRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFACTURANO"), AV99FacturaNo) != 0 )
            {
               FREESTYLEGRID1_nFirstRecordOnPage = 0;
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
         E194R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E194R2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV52ToDate = DateTimeUtil.Today( context);
         AssignAttri("", false, "AV52ToDate", context.localUtil.Format(AV52ToDate, "99/99/9999"));
         AV22FromDate = DateTimeUtil.AddMth( AV52ToDate, -3);
         AssignAttri("", false, "AV22FromDate", context.localUtil.Format(AV22FromDate, "99/99/9999"));
         Form.Caption = context.GetMessage( "Facturas", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         Combo_motivorechazoid_Titlecontrolidtoreplace = edtavMotivorechazoid_Internalname;
         ucCombo_motivorechazoid.SendProperty(context, "", false, Combo_motivorechazoid_Internalname, "TitleControlIdToReplace", Combo_motivorechazoid_Titlecontrolidtoreplace);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV12DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV12DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         /* Execute user subroutine: 'LOADCOMBODISTRIBUIDORID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOPROMOCIONID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOUSUARIOID' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOMOTIVORECHAZOID' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subFreestylegrid1_Rows = 10;
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Rows), 6, 0, ".", "")));
         edtFacturaID_Visible = 0;
         AssignProp("", false, edtFacturaID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaID_Visible), 5, 0), !bGXsfl_72_Refreshing);
         cmbFacturaEstatus.Visible = 0;
         AssignProp("", false, cmbFacturaEstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbFacturaEstatus.Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtUsuarioID_Visible = 0;
         AssignProp("", false, edtUsuarioID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioID_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtMotivoRechazoActivo_Visible = 0;
         AssignProp("", false, edtMotivoRechazoActivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoActivo_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtMotivoRechazoDescripcion_Visible = 0;
         AssignProp("", false, edtMotivoRechazoDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoDescripcion_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtMotivoRechazoID_Visible = 0;
         AssignProp("", false, edtMotivoRechazoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoID_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtFacturaID_Visible = 0;
         AssignProp("", false, edtFacturaID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFacturaID_Visible), 5, 0), !bGXsfl_72_Refreshing);
         cmbFacturaEstatus.Visible = 0;
         AssignProp("", false, cmbFacturaEstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbFacturaEstatus.Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtUsuarioID_Visible = 0;
         AssignProp("", false, edtUsuarioID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioID_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtMotivoRechazoActivo_Visible = 0;
         AssignProp("", false, edtMotivoRechazoActivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoActivo_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtMotivoRechazoDescripcion_Visible = 0;
         AssignProp("", false, edtMotivoRechazoDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoDescripcion_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtMotivoRechazoID_Visible = 0;
         AssignProp("", false, edtMotivoRechazoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoID_Visible), 5, 0), !bGXsfl_72_Refreshing);
         AV86FreeStyleGrid1CurrentPage = 1;
         AssignAttri("", false, "AV86FreeStyleGrid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV86FreeStyleGrid1CurrentPage), 10, 0));
         edtavFreestylegrid1currentpage_Visible = 0;
         AssignProp("", false, edtavFreestylegrid1currentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFreestylegrid1currentpage_Visible), 5, 0), true);
         AV87FreeStyleGrid1PageCount = -1;
         AssignAttri("", false, "AV87FreeStyleGrid1PageCount", StringUtil.LTrimStr( (decimal)(AV87FreeStyleGrid1PageCount), 10, 0));
         Freestylegrid1paginationbar_Rowsperpageselectedvalue = subFreestylegrid1_Rows;
         ucFreestylegrid1paginationbar.SendProperty(context, "", false, Freestylegrid1paginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Freestylegrid1paginationbar_Rowsperpageselectedvalue), 9, 0));
         subFreestylegrid1_Rows = 100;
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Rows), 6, 0, ".", "")));
         Freestylegrid1paginationbar_Rowsperpageoptions = "10,25,50,100";
         ucFreestylegrid1paginationbar.SendProperty(context, "", false, Freestylegrid1paginationbar_Internalname, "RowsPerPageOptions", Freestylegrid1paginationbar_Rowsperpageoptions);
         Freestylegrid1paginationbar_Rowsperpageselectedvalue = subFreestylegrid1_Rows;
         ucFreestylegrid1paginationbar.SendProperty(context, "", false, Freestylegrid1paginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Freestylegrid1paginationbar_Rowsperpageselectedvalue), 9, 0));
         AV92FacturaEstatus = "";
         AssignAttri("", false, "AV92FacturaEstatus", AV92FacturaEstatus);
         /* Execute user subroutine: 'BUILDUSUARIOSFILTRO' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Utchartdoughnut_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPFacturaEstatusFiltradoNew")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV22FromDate, "99/99/9999"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV52ToDate, "99/99/9999"))+"\", \""+StringUtil.JSONEncode( AV100UsuariosFiltro.ToJSonString(false))+"\", \""+StringUtil.JSONEncode( AV95PromocionID.ToJSonString(false))+"\", \""+StringUtil.JSONEncode( AV99FacturaNo)+"\", \""+StringUtil.JSONEncode( AV92FacturaEstatus)+"\" ]";
         ucUtchartdoughnut.SendProperty(context, "", false, Utchartdoughnut_Internalname, "Object", Utchartdoughnut_Objectcall);
         Utchartcolumnline_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPGraficaFacturasPorMesFiltradoNew")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV22FromDate, "99/99/9999"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV52ToDate, "99/99/9999"))+"\", \""+StringUtil.JSONEncode( AV100UsuariosFiltro.ToJSonString(false))+"\", \""+StringUtil.JSONEncode( AV95PromocionID.ToJSonString(false))+"\", \""+StringUtil.JSONEncode( AV99FacturaNo)+"\", \""+StringUtil.JSONEncode( AV92FacturaEstatus)+"\" ]";
         ucUtchartcolumnline.SendProperty(context, "", false, Utchartcolumnline_Internalname, "Object", Utchartcolumnline_Objectcall);
      }

      protected void E204R2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CALCTOTALFILTRADO' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( subFreestylegrid1_Rows <= 0 )
         {
            AV87FreeStyleGrid1PageCount = 1;
            AssignAttri("", false, "AV87FreeStyleGrid1PageCount", StringUtil.LTrimStr( (decimal)(AV87FreeStyleGrid1PageCount), 10, 0));
         }
         else
         {
            AV87FreeStyleGrid1PageCount = (long)(Math.Round(NumberUtil.Trunc( AV90TotalRows/ (decimal)(subFreestylegrid1_Rows), 0), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV87FreeStyleGrid1PageCount", StringUtil.LTrimStr( (decimal)(AV87FreeStyleGrid1PageCount), 10, 0));
            if ( ((int)((AV90TotalRows) % (subFreestylegrid1_Rows))) > 0 )
            {
               AV87FreeStyleGrid1PageCount = (long)(AV87FreeStyleGrid1PageCount+1);
               AssignAttri("", false, "AV87FreeStyleGrid1PageCount", StringUtil.LTrimStr( (decimal)(AV87FreeStyleGrid1PageCount), 10, 0));
            }
         }
         if ( AV87FreeStyleGrid1PageCount < 1 )
         {
            AV87FreeStyleGrid1PageCount = 1;
            AssignAttri("", false, "AV87FreeStyleGrid1PageCount", StringUtil.LTrimStr( (decimal)(AV87FreeStyleGrid1PageCount), 10, 0));
         }
         AV86FreeStyleGrid1CurrentPage = subFreestylegrid1_fnc_Currentpage( );
         AssignAttri("", false, "AV86FreeStyleGrid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV86FreeStyleGrid1CurrentPage), 10, 0));
         Freestylegrid1paginationbar_Rowsperpageselectedvalue = subFreestylegrid1_Rows;
         ucFreestylegrid1paginationbar.SendProperty(context, "", false, Freestylegrid1paginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Freestylegrid1paginationbar_Rowsperpageselectedvalue), 9, 0));
         if ( AV117DoScroll && ( AV116KeepPage > 0 ) )
         {
            subfreestylegrid1_gotopage( AV116KeepPage) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV100UsuariosFiltro", AV100UsuariosFiltro);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV62ListaUsuarios", AV62ListaUsuarios);
      }

      private void E214R2( )
      {
         /* Freestylegrid1_Load Routine */
         returnInSub = false;
         cmbavVarestatusadmin.Visible = 0;
         cmbavVarestatusadmin.Enabled = 0;
         cmbavVarestatus.Visible = 0;
         cmbavVarestatus.Enabled = 0;
         Combo_motivorechazoid_Visible = false;
         ucCombo_motivorechazoid.SendProperty(context, "", false, Combo_motivorechazoid_Internalname, "Visible", StringUtil.BoolToStr( Combo_motivorechazoid_Visible));
         Combo_motivorechazoid_Enabled = false;
         ucCombo_motivorechazoid.SendProperty(context, "", false, Combo_motivorechazoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_motivorechazoid_Enabled));
         edtavMotivorechazoid_Visible = 0;
         edtavMotivorechazoid_Enabled = 0;
         divEstatusenprocesotablemr_Visible = 0;
         AssignProp("", false, divEstatusenprocesotablemr_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divEstatusenprocesotablemr_Visible), 5, 0), !bGXsfl_72_Refreshing);
         if ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 )
         {
            cmbavVarestatusadmin.Visible = 1;
            cmbavVarestatusadmin.Enabled = 1;
            /* Execute user subroutine: 'OBTIENEEQUIVALENCIA' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            cmbavVarestatus.Visible = 0;
            cmbavVarestatus.Enabled = 0;
         }
         else
         {
            cmbavVarestatus.Visible = 1;
            cmbavVarestatus.Enabled = 0;
            AV103VarEstatus = A80FacturaEstatus;
            AssignAttri("", false, cmbavVarestatus_Internalname, AV103VarEstatus);
            cmbavVarestatusadmin.Visible = 0;
            cmbavVarestatusadmin.Enabled = 0;
         }
         AV37RegUsuarioID = A29UsuarioID;
         AssignAttri("", false, "AV37RegUsuarioID", StringUtil.LTrimStr( (decimal)(AV37RegUsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vREGUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV37RegUsuarioID), "ZZZZZZZZ9"), context));
         /* Using cursor H004R4 */
         pr_default.execute(2, new Object[] {AV37RegUsuarioID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A10DistribuidorID = H004R4_A10DistribuidorID[0];
            A29UsuarioID = H004R4_A29UsuarioID[0];
            A11DistribuidorDescripcion = H004R4_A11DistribuidorDescripcion[0];
            A81DistribuidoresUsuarioID = H004R4_A81DistribuidoresUsuarioID[0];
            A11DistribuidorDescripcion = H004R4_A11DistribuidorDescripcion[0];
            AV85DistribuidorDescripcion = A11DistribuidorDescripcion;
            AssignAttri("", false, edtavDistribuidordescripcion_Internalname, AV85DistribuidorDescripcion);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 ) ) )
         {
            edtavMotivorechazo_Visible = 0;
            divMotivorechazo_cell_Class = "Invisible";
            AssignProp("", false, divMotivorechazo_cell_Internalname, "Class", divMotivorechazo_cell_Class, !bGXsfl_72_Refreshing);
         }
         else
         {
            edtavMotivorechazo_Visible = 1;
            divMotivorechazo_cell_Class = "col-xs-12 col-sm-3 DscTop";
            AssignProp("", false, divMotivorechazo_cell_Internalname, "Class", divMotivorechazo_cell_Class, !bGXsfl_72_Refreshing);
            AV111MotivoRechazo = A20MotivoRechazoDescripcion;
            AssignAttri("", false, edtavMotivorechazo_Internalname, AV111MotivoRechazo);
         }
         if ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 )
         {
            divEstatusenprocesotablestatusstrip_Class = "StatusStripEnProceso";
            AssignProp("", false, divEstatusenprocesotablestatusstrip_Internalname, "Class", divEstatusenprocesotablestatusstrip_Class, !bGXsfl_72_Refreshing);
            divAllestatustablestatusstrip_Class = "StatusStripEnProceso";
            AssignProp("", false, divAllestatustablestatusstrip_Internalname, "Class", divAllestatustablestatusstrip_Class, !bGXsfl_72_Refreshing);
         }
         else if ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 )
         {
            divEstatusenprocesotablestatusstrip_Class = "StatusStripAprobada";
            AssignProp("", false, divEstatusenprocesotablestatusstrip_Internalname, "Class", divEstatusenprocesotablestatusstrip_Class, !bGXsfl_72_Refreshing);
            divAllestatustablestatusstrip_Class = "StatusStripAprobada";
            AssignProp("", false, divAllestatustablestatusstrip_Internalname, "Class", divAllestatustablestatusstrip_Class, !bGXsfl_72_Refreshing);
         }
         else if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
         {
            divEstatusenprocesotablestatusstrip_Class = "StatusStripRechazada";
            AssignProp("", false, divEstatusenprocesotablestatusstrip_Internalname, "Class", divEstatusenprocesotablestatusstrip_Class, !bGXsfl_72_Refreshing);
            divAllestatustablestatusstrip_Class = "StatusStripRechazada";
            AssignProp("", false, divAllestatustablestatusstrip_Internalname, "Class", divAllestatustablestatusstrip_Class, !bGXsfl_72_Refreshing);
         }
         else if ( StringUtil.StrCmp(A80FacturaEstatus, "Cancelada") == 0 )
         {
            divEstatusenprocesotablestatusstrip_Class = "StatusStripCancelada";
            AssignProp("", false, divEstatusenprocesotablestatusstrip_Internalname, "Class", divEstatusenprocesotablestatusstrip_Class, !bGXsfl_72_Refreshing);
            divAllestatustablestatusstrip_Class = "StatusStripCancelada";
            AssignProp("", false, divAllestatustablestatusstrip_Internalname, "Class", divAllestatustablestatusstrip_Class, !bGXsfl_72_Refreshing);
         }
         else
         {
            divEstatusenprocesotablestatusstrip_Class = "";
            AssignProp("", false, divEstatusenprocesotablestatusstrip_Internalname, "Class", divEstatusenprocesotablestatusstrip_Class, !bGXsfl_72_Refreshing);
            divAllestatustablestatusstrip_Class = "";
            AssignProp("", false, divAllestatustablestatusstrip_Internalname, "Class", divAllestatustablestatusstrip_Class, !bGXsfl_72_Refreshing);
         }
         /* Execute user subroutine: 'ESTAENCOLA' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV127EnCola )
         {
         }
         else
         {
         }
         divAllestatustablecell_Visible = 0;
         AssignProp("", false, divAllestatustablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divAllestatustablecell_Visible), 5, 0), !bGXsfl_72_Refreshing);
         divEstatusenprocesotablecell_Visible = 0;
         AssignProp("", false, divEstatusenprocesotablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divEstatusenprocesotablecell_Visible), 5, 0), !bGXsfl_72_Refreshing);
         if ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 )
         {
            divEstatusenprocesotablecell_Visible = 1;
            AssignProp("", false, divEstatusenprocesotablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divEstatusenprocesotablecell_Visible), 5, 0), !bGXsfl_72_Refreshing);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Estatusenprocesowebcomponent1 = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Estatusenprocesowebcomponent1_Component), StringUtil.Lower( "WCPartidasFacturaNew")) != 0 )
            {
               WebComp_Estatusenprocesowebcomponent1 = getWebComponent(GetType(), "GeneXus.Programs", "wcpartidasfacturanew", new Object[] {context} );
               WebComp_Estatusenprocesowebcomponent1.ComponentInit();
               WebComp_Estatusenprocesowebcomponent1.Name = "WCPartidasFacturaNew";
               WebComp_Estatusenprocesowebcomponent1_Component = "WCPartidasFacturaNew";
            }
            if ( StringUtil.Len( WebComp_Estatusenprocesowebcomponent1_Component) != 0 )
            {
               WebComp_Estatusenprocesowebcomponent1.setjustcreated();
               WebComp_Estatusenprocesowebcomponent1.componentprepare(new Object[] {(string)"W0242",(string)sGXsfl_72_idx,(int)A69FacturaID,(string)A80FacturaEstatus});
               WebComp_Estatusenprocesowebcomponent1.componentbind(new Object[] {(string)"",(string)""});
            }
         }
         else
         {
            divAllestatustablecell_Visible = 1;
            AssignProp("", false, divAllestatustablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divAllestatustablecell_Visible), 5, 0), !bGXsfl_72_Refreshing);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Allestatuswebcomponent1 = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Allestatuswebcomponent1_Component), StringUtil.Lower( "WCPartidasFacturaNew")) != 0 )
            {
               WebComp_Allestatuswebcomponent1 = getWebComponent(GetType(), "GeneXus.Programs", "wcpartidasfacturanew", new Object[] {context} );
               WebComp_Allestatuswebcomponent1.ComponentInit();
               WebComp_Allestatuswebcomponent1.Name = "WCPartidasFacturaNew";
               WebComp_Allestatuswebcomponent1_Component = "WCPartidasFacturaNew";
            }
            if ( StringUtil.Len( WebComp_Allestatuswebcomponent1_Component) != 0 )
            {
               WebComp_Allestatuswebcomponent1.setjustcreated();
               WebComp_Allestatuswebcomponent1.componentprepare(new Object[] {(string)"W0159",(string)sGXsfl_72_idx,(int)A69FacturaID,(string)A80FacturaEstatus});
               WebComp_Allestatuswebcomponent1.componentbind(new Object[] {(string)"",(string)""});
            }
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 72;
         }
         sendrow_722( ) ;
         FREESTYLEGRID1_nCurrentRecord = (long)(FREESTYLEGRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_72_Refreshing )
         {
            DoAjaxLoad(72, Freestylegrid1Row);
         }
         /*  Sending Event outputs  */
         cmbavVarestatus.CurrentValue = StringUtil.RTrim( AV103VarEstatus);
         cmbavVarestatusadmin.CurrentValue = StringUtil.RTrim( AV105VarEstatusAdmin);
      }

      protected void E144R2( )
      {
         /* Freestylegrid1paginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Freestylegrid1paginationbar_Selectedpage, "Previous") == 0 )
         {
            AV86FreeStyleGrid1CurrentPage = (long)(AV86FreeStyleGrid1CurrentPage-1);
            AssignAttri("", false, "AV86FreeStyleGrid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV86FreeStyleGrid1CurrentPage), 10, 0));
            subfreestylegrid1_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Freestylegrid1paginationbar_Selectedpage, "Next") == 0 )
         {
            AV86FreeStyleGrid1CurrentPage = (long)(AV86FreeStyleGrid1CurrentPage+1);
            AssignAttri("", false, "AV86FreeStyleGrid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV86FreeStyleGrid1CurrentPage), 10, 0));
            subfreestylegrid1_nextpage( ) ;
         }
         else
         {
            AV34PageToGo = (int)(Math.Round(NumberUtil.Val( Freestylegrid1paginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            AV86FreeStyleGrid1CurrentPage = AV34PageToGo;
            AssignAttri("", false, "AV86FreeStyleGrid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV86FreeStyleGrid1CurrentPage), 10, 0));
            subfreestylegrid1_gotopage( AV34PageToGo) ;
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV100UsuariosFiltro", AV100UsuariosFiltro);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV62ListaUsuarios", AV62ListaUsuarios);
      }

      protected void E154R2( )
      {
         /* Freestylegrid1paginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subFreestylegrid1_Rows = Freestylegrid1paginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "FREESTYLEGRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Rows), 6, 0, ".", "")));
         AV86FreeStyleGrid1CurrentPage = 1;
         AssignAttri("", false, "AV86FreeStyleGrid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV86FreeStyleGrid1CurrentPage), 10, 0));
         subfreestylegrid1_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E164R2( )
      {
         /* 'DoCambiarEstatus' Routine */
         returnInSub = false;
         if ( AV121Cambios.Count == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "No hay cambios en la cola.", ""));
         }
         AV128OK = 0;
         context.Gx_err = 0;
         AV137GXV1 = 1;
         while ( AV137GXV1 <= AV121Cambios.Count )
         {
            AV122c = ((SdtSDTCambioEstatus_SDTCambioEstatusItem)AV121Cambios.Item(AV137GXV1));
            AV63Pasa = false;
            if ( ( StringUtil.StrCmp(AV122c.gxTpr_Facturaestatus, "Rechazada") == 0 ) && ( ( AV122c.gxTpr_Motivorechazoid == 0 ) || (0==AV122c.gxTpr_Motivorechazoid) ) )
            {
               GX_msglist.addItem(StringUtil.Format( "Factura %1: motivo de rechazo no especificado.", StringUtil.LTrimStr( (decimal)(AV122c.gxTpr_Facturaid), 9, 0), "", "", "", "", "", "", "", ""));
               context.Gx_err = (short)(context.Gx_err+1);
            }
            new cambiarestatus(context ).execute(  AV122c.gxTpr_Facturaestatus,  AV122c.gxTpr_Facturaid,  AV122c.gxTpr_Motivorechazoid, out  AV63Pasa) ;
            if ( AV63Pasa )
            {
               AV128OK = (short)(AV128OK+1);
            }
            else
            {
               context.Gx_err = (short)(context.Gx_err+1);
            }
            AV137GXV1 = (int)(AV137GXV1+1);
         }
         if ( context.Gx_err == 0 )
         {
            AV121Cambios.Clear();
            AV125CambiosCount = 0;
            GX_msglist.addItem(StringUtil.Format( "%1 cambios aplicados.", StringUtil.LTrimStr( (decimal)(AV128OK), 4, 0), "", "", "", "", "", "", "", ""));
         }
         else
         {
            AV129Tmp = new GXBaseCollection<SdtSDTCambioEstatus_SDTCambioEstatusItem>( context, "SDTCambioEstatusItem", "Premios");
            AV138GXV2 = 1;
            while ( AV138GXV2 <= AV121Cambios.Count )
            {
               AV122c = ((SdtSDTCambioEstatus_SDTCambioEstatusItem)AV121Cambios.Item(AV138GXV2));
               AV63Pasa = false;
               if ( ( StringUtil.StrCmp(AV122c.gxTpr_Facturaestatus, "Rechazada") == 0 ) && ( ( AV122c.gxTpr_Motivorechazoid == 0 ) || (0==AV122c.gxTpr_Motivorechazoid) ) )
               {
                  AV129Tmp.Add(AV122c, 0);
               }
               else
               {
               }
               AV138GXV2 = (int)(AV138GXV2+1);
            }
            AV121Cambios = AV129Tmp;
            AV125CambiosCount = AV121Cambios.Count;
            GX_msglist.addItem(StringUtil.Format( "Listo: %1 ok, %2 con error. Revisa la cola.", StringUtil.LTrimStr( (decimal)(AV128OK), 4, 0), StringUtil.LTrimStr( (decimal)(context.Gx_err), 3, 0), "", "", "", "", "", "", ""));
         }
         /* Execute user subroutine: 'CALCTOTALFILTRADO' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Utchartdoughnut_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPFacturaEstatusFiltradoNew")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV22FromDate, "99/99/9999"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV52ToDate, "99/99/9999"))+"\", \""+StringUtil.JSONEncode( AV100UsuariosFiltro.ToJSonString(false))+"\", \""+StringUtil.JSONEncode( AV95PromocionID.ToJSonString(false))+"\", \""+StringUtil.JSONEncode( AV99FacturaNo)+"\", \""+StringUtil.JSONEncode( AV92FacturaEstatus)+"\" ]";
         ucUtchartdoughnut.SendProperty(context, "", false, Utchartdoughnut_Internalname, "Object", Utchartdoughnut_Objectcall);
         Utchartcolumnline_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPGraficaFacturasPorMesFiltradoNew")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV22FromDate, "99/99/9999"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV52ToDate, "99/99/9999"))+"\", \""+StringUtil.JSONEncode( AV100UsuariosFiltro.ToJSonString(false))+"\", \""+StringUtil.JSONEncode( AV95PromocionID.ToJSonString(false))+"\", \""+StringUtil.JSONEncode( AV99FacturaNo)+"\", \""+StringUtil.JSONEncode( AV92FacturaEstatus)+"\" ]";
         ucUtchartcolumnline.SendProperty(context, "", false, Utchartcolumnline_Internalname, "Object", Utchartcolumnline_Objectcall);
         gxgrFreestylegrid1_refresh( subFreestylegrid1_Rows, AV22FromDate, AV52ToDate, AV92FacturaEstatus, AV99FacturaNo, AV90TotalRows, AV117DoScroll, AV116KeepPage, AV95PromocionID, AV97UsuarioID, AV100UsuariosFiltro, AV62ListaUsuarios, AV15DistribuidorID, A40UsuarioRol, A10DistribuidorID, A81DistribuidoresUsuarioID, A11DistribuidorDescripcion, AV127EnCola, AV121Cambios, AV19FacturaID, AV37RegUsuarioID) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV121Cambios", AV121Cambios);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV100UsuariosFiltro", AV100UsuariosFiltro);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV62ListaUsuarios", AV62ListaUsuarios);
      }

      protected void E224R2( )
      {
         /* 'DoEstatusEnProcesoUserAction4' Routine */
         returnInSub = false;
         AV19FacturaID = A69FacturaID;
         AssignAttri("", false, "AV19FacturaID", StringUtil.LTrimStr( (decimal)(AV19FacturaID), 9, 0));
         /* Execute user subroutine: 'OBTIENEPDF' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20FileURL = context.PathToUrl( AV5Blob);
         AV110Fragment = "page=1&view=FitH";
         if ( StringUtil.Contains( AV20FileURL, "#") )
         {
            AV20FileURL += "&" + AV110Fragment;
         }
         else
         {
            AV20FileURL += "#" + AV110Fragment;
         }
         AV109JS = "javascript:window.open('" + StringUtil.StringReplace( StringUtil.Trim( AV20FileURL), "'", "\\\\'") + "','PDF_Float','width=700,height=500,top=60,left=80,scrollbars=yes,resizable=yes,toolbar=no,menubar=no,location=no,status=no');";
         CallWebObject(formatLink(AV109JS) );
         context.wjLocDisableFrm = 0;
         /*  Sending Event outputs  */
      }

      protected void E234R2( )
      {
         /* 'DoAllEstatusUserAction4' Routine */
         returnInSub = false;
         AV19FacturaID = A69FacturaID;
         AssignAttri("", false, "AV19FacturaID", StringUtil.LTrimStr( (decimal)(AV19FacturaID), 9, 0));
         /* Execute user subroutine: 'OBTIENEPDF' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20FileURL = context.PathToUrl( AV5Blob);
         AV110Fragment = "page=1&view=FitH";
         if ( StringUtil.Contains( AV20FileURL, "#") )
         {
            AV20FileURL += "&" + AV110Fragment;
         }
         else
         {
            AV20FileURL += "#" + AV110Fragment;
         }
         AV109JS = "javascript:window.open('" + StringUtil.StringReplace( StringUtil.Trim( AV20FileURL), "'", "\\\\'") + "','PDF_Float','width=700,height=500,top=60,left=80,scrollbars=yes,resizable=yes,toolbar=no,menubar=no,location=no,status=no');";
         CallWebObject(formatLink(AV109JS) );
         context.wjLocDisableFrm = 0;
         /*  Sending Event outputs  */
      }

      protected void E174R2( )
      {
         /* 'DoUserAction99' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CALCTOTALFILTRADO' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Utchartdoughnut_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPFacturaEstatusFiltradoNew")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV22FromDate, "99/99/9999"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV52ToDate, "99/99/9999"))+"\", \""+StringUtil.JSONEncode( AV100UsuariosFiltro.ToJSonString(false))+"\", \""+StringUtil.JSONEncode( AV95PromocionID.ToJSonString(false))+"\", \""+StringUtil.JSONEncode( AV99FacturaNo)+"\", \""+StringUtil.JSONEncode( AV92FacturaEstatus)+"\" ]";
         ucUtchartdoughnut.SendProperty(context, "", false, Utchartdoughnut_Internalname, "Object", Utchartdoughnut_Objectcall);
         Utchartcolumnline_Objectcall = "[ \""+"dp"+"\", \""+StringUtil.JSONEncode( "DPGraficaFacturasPorMesFiltradoNew")+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV22FromDate, "99/99/9999"))+"\", \""+StringUtil.JSONEncode( context.localUtil.Format(AV52ToDate, "99/99/9999"))+"\", \""+StringUtil.JSONEncode( AV100UsuariosFiltro.ToJSonString(false))+"\", \""+StringUtil.JSONEncode( AV95PromocionID.ToJSonString(false))+"\", \""+StringUtil.JSONEncode( AV99FacturaNo)+"\", \""+StringUtil.JSONEncode( AV92FacturaEstatus)+"\" ]";
         ucUtchartcolumnline.SendProperty(context, "", false, Utchartcolumnline_Internalname, "Object", Utchartcolumnline_Objectcall);
         gxgrFreestylegrid1_refresh( subFreestylegrid1_Rows, AV22FromDate, AV52ToDate, AV92FacturaEstatus, AV99FacturaNo, AV90TotalRows, AV117DoScroll, AV116KeepPage, AV95PromocionID, AV97UsuarioID, AV100UsuariosFiltro, AV62ListaUsuarios, AV15DistribuidorID, A40UsuarioRol, A10DistribuidorID, A81DistribuidoresUsuarioID, A11DistribuidorDescripcion, AV127EnCola, AV121Cambios, AV19FacturaID, AV37RegUsuarioID) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV100UsuariosFiltro", AV100UsuariosFiltro);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV62ListaUsuarios", AV62ListaUsuarios);
      }

      protected void E184R2( )
      {
         /* 'DoGeneraExcel' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CALCTOTALFILTRADO' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new exportfacturasigualqueejemplo(context ).execute(  AV22FromDate,  AV52ToDate,  AV100UsuariosFiltro,  AV95PromocionID,  AV99FacturaNo,  AV92FacturaEstatus, out  AV118ExcelFilename) ;
         if ( StringUtil.StrCmp(AV118ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV118ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV100UsuariosFiltro", AV100UsuariosFiltro);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV62ListaUsuarios", AV62ListaUsuarios);
      }

      protected void E134R2( )
      {
         /* Combo_usuarioid_Onoptionclicked Routine */
         returnInSub = false;
         AV97UsuarioID.FromJSonString(Combo_usuarioid_Selectedvalue_get, null);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV97UsuarioID", AV97UsuarioID);
      }

      protected void E124R2( )
      {
         /* Combo_promocionid_Onoptionclicked Routine */
         returnInSub = false;
         AV95PromocionID.FromJSonString(Combo_promocionid_Selectedvalue_get, null);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV95PromocionID", AV95PromocionID);
      }

      protected void E114R2( )
      {
         /* Combo_distribuidorid_Onoptionclicked Routine */
         returnInSub = false;
         AV15DistribuidorID.FromJSonString(Combo_distribuidorid_Selectedvalue_get, null);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15DistribuidorID", AV15DistribuidorID);
      }

      protected void S152( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 ) ) )
         {
            edtavMotivorechazo_Visible = 0;
            AssignProp("", false, edtavMotivorechazo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMotivorechazo_Visible), 5, 0), !bGXsfl_72_Refreshing);
            divMotivorechazo_cell_Class = "Invisible";
            AssignProp("", false, divMotivorechazo_cell_Internalname, "Class", divMotivorechazo_cell_Class, !bGXsfl_72_Refreshing);
         }
         else
         {
            edtavMotivorechazo_Visible = 1;
            AssignProp("", false, edtavMotivorechazo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMotivorechazo_Visible), 5, 0), !bGXsfl_72_Refreshing);
            divMotivorechazo_cell_Class = "col-xs-12 col-sm-3 DscTop";
            AssignProp("", false, divMotivorechazo_cell_Internalname, "Class", divMotivorechazo_cell_Class, !bGXsfl_72_Refreshing);
         }
      }

      protected void S142( )
      {
         /* 'LOADCOMBOMOTIVORECHAZOID' Routine */
         returnInSub = false;
         /* Using cursor H004R5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A19MotivoRechazoID = H004R5_A19MotivoRechazoID[0];
            A20MotivoRechazoDescripcion = H004R5_A20MotivoRechazoDescripcion[0];
            AV9Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A19MotivoRechazoID), 9, 0));
            AV9Combo_DataItem.gxTpr_Title = A20MotivoRechazoDescripcion;
            AV108MotivoRechazoID_Data.Add(AV9Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOUSUARIOID' Routine */
         returnInSub = false;
         /* Using cursor H004R6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A40UsuarioRol = H004R6_A40UsuarioRol[0];
            A29UsuarioID = H004R6_A29UsuarioID[0];
            A52UsuarioNombreCompleto = H004R6_A52UsuarioNombreCompleto[0];
            A30UsuarioNombre = H004R6_A30UsuarioNombre[0];
            A51UsuarioApellido = H004R6_A51UsuarioApellido[0];
            AV9Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A29UsuarioID), 9, 0));
            AV9Combo_DataItem.gxTpr_Title = A52UsuarioNombreCompleto;
            AV98UsuarioID_Data.Add(AV9Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_usuarioid_Selectedvalue_set = AV97UsuarioID.ToJSonString(false);
         ucCombo_usuarioid.SendProperty(context, "", false, Combo_usuarioid_Internalname, "SelectedValue_set", Combo_usuarioid_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPROMOCIONID' Routine */
         returnInSub = false;
         /* Using cursor H004R7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A41PromocionID = H004R7_A41PromocionID[0];
            A42PromocionDescripcion = H004R7_A42PromocionDescripcion[0];
            AV9Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A41PromocionID), 9, 0));
            AV9Combo_DataItem.gxTpr_Title = A42PromocionDescripcion;
            AV96PromocionID_Data.Add(AV9Combo_DataItem, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         Combo_promocionid_Selectedvalue_set = AV95PromocionID.ToJSonString(false);
         ucCombo_promocionid.SendProperty(context, "", false, Combo_promocionid_Internalname, "SelectedValue_set", Combo_promocionid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBODISTRIBUIDORID' Routine */
         returnInSub = false;
         /* Using cursor H004R8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            A10DistribuidorID = H004R8_A10DistribuidorID[0];
            A11DistribuidorDescripcion = H004R8_A11DistribuidorDescripcion[0];
            AV9Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A10DistribuidorID), 9, 0));
            AV9Combo_DataItem.gxTpr_Title = A11DistribuidorDescripcion;
            AV16DistribuidorID_Data.Add(AV9Combo_DataItem, 0);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         Combo_distribuidorid_Selectedvalue_set = AV15DistribuidorID.ToJSonString(false);
         ucCombo_distribuidorid.SendProperty(context, "", false, Combo_distribuidorid_Internalname, "SelectedValue_set", Combo_distribuidorid_Selectedvalue_set);
      }

      protected void E244R2( )
      {
         /* 'DoUserAction4' Routine */
         returnInSub = false;
         AV19FacturaID = A69FacturaID;
         AssignAttri("", false, "AV19FacturaID", StringUtil.LTrimStr( (decimal)(AV19FacturaID), 9, 0));
         /* Execute user subroutine: 'OBTIENEPDF' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20FileURL = context.PathToUrl( AV5Blob);
         AV110Fragment = "page=1&view=FitH";
         if ( StringUtil.Contains( AV20FileURL, "#") )
         {
            AV20FileURL += "&" + AV110Fragment;
         }
         else
         {
            AV20FileURL += "#" + AV110Fragment;
         }
         AV109JS = "javascript:window.open('" + StringUtil.StringReplace( StringUtil.Trim( AV20FileURL), "'", "\\\\'") + "','PDF_Float','width=700,height=500,top=60,left=80,scrollbars=yes,resizable=yes,toolbar=no,menubar=no,location=no,status=no');";
         CallWebObject(formatLink(AV109JS) );
         context.wjLocDisableFrm = 0;
         /*  Sending Event outputs  */
      }

      protected void E254R2( )
      {
         /* Varestatusadmin_Controlvaluechanged Routine */
         returnInSub = false;
         AV132SelFacturaID = A69FacturaID;
         AssignAttri("", false, "AV132SelFacturaID", StringUtil.LTrimStr( (decimal)(AV132SelFacturaID), 9, 0));
         AV131SelEstatusAdmin = AV105VarEstatusAdmin;
         AssignAttri("", false, "AV131SelEstatusAdmin", AV131SelEstatusAdmin);
         AV133SelMotivoRechazoID = AV107MotivoRechazoID;
         AssignAttri("", false, "AV133SelMotivoRechazoID", StringUtil.LTrimStr( (decimal)(AV133SelMotivoRechazoID), 9, 0));
         AV112EsRechazada = (bool)(((StringUtil.StrCmp(AV105VarEstatusAdmin, "Rechazada")==0)));
         AV113CambiarEstatus = (bool)((!String.IsNullOrEmpty(StringUtil.RTrim( AV105VarEstatusAdmin))&&(StringUtil.StrCmp(AV105VarEstatusAdmin, "En Proceso")!=0)));
         Combo_motivorechazoid_Visible = AV112EsRechazada;
         ucCombo_motivorechazoid.SendProperty(context, "", false, Combo_motivorechazoid_Internalname, "Visible", StringUtil.BoolToStr( Combo_motivorechazoid_Visible));
         Combo_motivorechazoid_Enabled = AV112EsRechazada;
         ucCombo_motivorechazoid.SendProperty(context, "", false, Combo_motivorechazoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_motivorechazoid_Enabled));
         edtavMotivorechazoid_Visible = (AV112EsRechazada ? 1 : 0);
         AssignProp("", false, edtavMotivorechazoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMotivorechazoid_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtavMotivorechazoid_Enabled = (AV112EsRechazada ? 1 : 0);
         AssignProp("", false, edtavMotivorechazoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMotivorechazoid_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         edtMotivoRechazoID_Visible = (AV112EsRechazada ? 1 : 0);
         AssignProp("", false, edtMotivoRechazoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoID_Visible), 5, 0), !bGXsfl_72_Refreshing);
         edtMotivoRechazoID_Enabled = (AV112EsRechazada ? 1 : 0);
         AssignProp("", false, edtMotivoRechazoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoID_Enabled), 5, 0), !bGXsfl_72_Refreshing);
         divEstatusenprocesotablemr_Visible = (AV112EsRechazada ? 1 : 0);
         AssignProp("", false, divEstatusenprocesotablemr_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divEstatusenprocesotablemr_Visible), 5, 0), !bGXsfl_72_Refreshing);
         if ( StringUtil.StrCmp(AV105VarEstatusAdmin, "En Proceso") == 0 )
         {
            /* Execute user subroutine: 'REMOVECAMBIO' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV105VarEstatusAdmin, "Rechazada") == 0 )
         {
            if ( (0==AV107MotivoRechazoID) )
            {
               /* Execute user subroutine: 'REMOVECAMBIO' */
               S212 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               GX_msglist.addItem(context.GetMessage( "Selecciona el motivo de rechazo para poner esta factura en la cola.", ""));
            }
            else
            {
               /* Execute user subroutine: 'UPSERTCAMBIO' */
               S222 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
         }
         else
         {
            /* Execute user subroutine: 'UPSERTCAMBIO' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'ESTAENCOLA' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV125CambiosCount = AV121Cambios.Count;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV121Cambios", AV121Cambios);
      }

      protected void E264R2( )
      {
         /* Motivorechazoid_Controlvaluechanged Routine */
         returnInSub = false;
         AV133SelMotivoRechazoID = AV107MotivoRechazoID;
         AssignAttri("", false, "AV133SelMotivoRechazoID", StringUtil.LTrimStr( (decimal)(AV133SelMotivoRechazoID), 9, 0));
         if ( StringUtil.StrCmp(AV105VarEstatusAdmin, "Rechazada") == 0 )
         {
            if ( ! (0==AV107MotivoRechazoID) )
            {
               /* Execute user subroutine: 'UPSERTCAMBIO' */
               S222 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            else
            {
               /* Execute user subroutine: 'REMOVECAMBIO' */
               S212 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               GX_msglist.addItem(context.GetMessage( "Debes seleccionar un motivo de rechazo para poner esta factura en la cola.", ""));
            }
         }
         /* Execute user subroutine: 'ESTAENCOLA' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV125CambiosCount = AV121Cambios.Count;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV121Cambios", AV121Cambios);
      }

      protected void S232( )
      {
         /* 'OBTIENELISTAUSUARIOS' Routine */
         returnInSub = false;
         AV62ListaUsuarios.Clear();
         if ( AV15DistribuidorID.Count == 0 )
         {
            /* Using cursor H004R9 */
            pr_default.execute(7);
            while ( (pr_default.getStatus(7) != 101) )
            {
               A40UsuarioRol = H004R9_A40UsuarioRol[0];
               A29UsuarioID = H004R9_A29UsuarioID[0];
               A40UsuarioRol = H004R9_A40UsuarioRol[0];
               AV63Pasa = false;
               AV144GXV3 = 1;
               while ( AV144GXV3 <= AV62ListaUsuarios.Count )
               {
                  AV64UsuariosListaID = (int)(AV62ListaUsuarios.GetNumeric(AV144GXV3));
                  if ( AV64UsuariosListaID == A29UsuarioID )
                  {
                     AV63Pasa = true;
                     if (true) break;
                  }
                  AV144GXV3 = (int)(AV144GXV3+1);
               }
               if ( ! AV63Pasa )
               {
                  AV62ListaUsuarios.Add(A29UsuarioID, 0);
               }
               pr_default.readNext(7);
            }
            pr_default.close(7);
         }
         else
         {
            pr_default.dynParam(8, new Object[]{ new Object[]{
                                                 A10DistribuidorID ,
                                                 AV15DistribuidorID ,
                                                 A40UsuarioRol } ,
                                                 new int[]{
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor H004R10 */
            pr_default.execute(8);
            while ( (pr_default.getStatus(8) != 101) )
            {
               A40UsuarioRol = H004R10_A40UsuarioRol[0];
               A10DistribuidorID = H004R10_A10DistribuidorID[0];
               A29UsuarioID = H004R10_A29UsuarioID[0];
               A40UsuarioRol = H004R10_A40UsuarioRol[0];
               AV63Pasa = false;
               AV146GXV4 = 1;
               while ( AV146GXV4 <= AV62ListaUsuarios.Count )
               {
                  AV64UsuariosListaID = (int)(AV62ListaUsuarios.GetNumeric(AV146GXV4));
                  if ( AV64UsuariosListaID == A29UsuarioID )
                  {
                     AV63Pasa = true;
                     if (true) break;
                  }
                  AV146GXV4 = (int)(AV146GXV4+1);
               }
               if ( ! AV63Pasa )
               {
                  AV62ListaUsuarios.Add(A29UsuarioID, 0);
               }
               pr_default.readNext(8);
            }
            pr_default.close(8);
         }
      }

      protected void S172( )
      {
         /* 'CALCTOTALFILTRADO' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'BUILDUSUARIOSFILTRO' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV90TotalRows = 0;
         AssignAttri("", false, "AV90TotalRows", StringUtil.LTrimStr( (decimal)(AV90TotalRows), 18, 0));
         /* Optimized group. */
         pr_default.dynParam(9, new Object[]{ new Object[]{
                                              A41PromocionID ,
                                              AV95PromocionID ,
                                              A29UsuarioID ,
                                              AV100UsuariosFiltro ,
                                              AV22FromDate ,
                                              AV52ToDate ,
                                              AV92FacturaEstatus ,
                                              AV95PromocionID.Count ,
                                              AV97UsuarioID.Count ,
                                              AV99FacturaNo ,
                                              A73FacturaFechaFactura ,
                                              A80FacturaEstatus ,
                                              A71FacturaNo } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE
                                              }
         });
         /* Using cursor H004R11 */
         pr_default.execute(9, new Object[] {AV22FromDate, AV52ToDate, AV92FacturaEstatus, AV99FacturaNo});
         cV90TotalRows = H004R11_AV90TotalRows[0];
         pr_default.close(9);
         AV90TotalRows = (long)(AV90TotalRows+cV90TotalRows*1);
         AssignAttri("", false, "AV90TotalRows", StringUtil.LTrimStr( (decimal)(AV90TotalRows), 18, 0));
         /* End optimized group. */
      }

      protected void S162( )
      {
         /* 'BUILDUSUARIOSFILTRO' Routine */
         returnInSub = false;
         AV100UsuariosFiltro.Clear();
         AV102Caso = 0;
         if ( AV97UsuarioID.Count > 0 )
         {
            AV148GXV5 = 1;
            while ( AV148GXV5 <= AV97UsuarioID.Count )
            {
               AV101u = (int)(AV97UsuarioID.GetNumeric(AV148GXV5));
               AV100UsuariosFiltro.Add(AV101u, 0);
               AV148GXV5 = (int)(AV148GXV5+1);
            }
            AV102Caso = 1;
         }
         if ( ! ( AV102Caso == 1 ) )
         {
            /* Execute user subroutine: 'OBTIENELISTAUSUARIOS' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            AV149GXV6 = 1;
            while ( AV149GXV6 <= AV62ListaUsuarios.Count )
            {
               AV101u = (int)(AV62ListaUsuarios.GetNumeric(AV149GXV6));
               AV100UsuariosFiltro.Add(AV101u, 0);
               AV149GXV6 = (int)(AV149GXV6+1);
            }
         }
      }

      protected void S182( )
      {
         /* 'OBTIENEEQUIVALENCIA' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 )
         {
            AV105VarEstatusAdmin = "Aprobada";
            AssignAttri("", false, cmbavVarestatusadmin_Internalname, AV105VarEstatusAdmin);
         }
         else if ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 )
         {
            AV105VarEstatusAdmin = "Rechazada";
            AssignAttri("", false, cmbavVarestatusadmin_Internalname, AV105VarEstatusAdmin);
         }
         else if ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 )
         {
            AV105VarEstatusAdmin = "En Proceso";
            AssignAttri("", false, cmbavVarestatusadmin_Internalname, AV105VarEstatusAdmin);
         }
      }

      protected void S202( )
      {
         /* 'OBTIENEPDF' Routine */
         returnInSub = false;
         /* Using cursor H004R12 */
         pr_default.execute(10, new Object[] {AV19FacturaID});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A69FacturaID = H004R12_A69FacturaID[0];
            A40000FacturaPDF_GXI = H004R12_A40000FacturaPDF_GXI[0];
            A75FacturaPDF = H004R12_A75FacturaPDF[0];
            AV5Blob = A75FacturaPDF;
            AssignAttri("", false, "AV5Blob", AV5Blob);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(10);
      }

      protected void S222( )
      {
         /* 'UPSERTCAMBIO' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV131SelEstatusAdmin, "En Proceso") == 0 )
         {
            /* Execute user subroutine: 'REMOVECAMBIO' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'EQUIVALENCIAESTATUSVAR' */
         S242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV120Found = false;
         AV151GXV7 = 1;
         while ( AV151GXV7 <= AV121Cambios.Count )
         {
            AV122c = ((SdtSDTCambioEstatus_SDTCambioEstatusItem)AV121Cambios.Item(AV151GXV7));
            if ( AV122c.gxTpr_Facturaid == AV132SelFacturaID )
            {
               AV122c.gxTpr_Facturaestatus = AV134SelFacturaEstatus;
               AV122c.gxTpr_Motivorechazoid = AV133SelMotivoRechazoID;
               AV120Found = true;
               if (true) break;
            }
            AV151GXV7 = (int)(AV151GXV7+1);
         }
         if ( ! AV120Found )
         {
            AV124item = new SdtSDTCambioEstatus_SDTCambioEstatusItem(context);
            AV124item.gxTpr_Facturaid = AV132SelFacturaID;
            AV124item.gxTpr_Facturaestatus = AV134SelFacturaEstatus;
            AV124item.gxTpr_Motivorechazoid = AV133SelMotivoRechazoID;
            AV124item.gxTpr_Facturano = A71FacturaNo;
            AV121Cambios.Add(AV124item, 0);
         }
         AV125CambiosCount = AV121Cambios.Count;
      }

      protected void S242( )
      {
         /* 'EQUIVALENCIAESTATUSVAR' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV105VarEstatusAdmin, "En Proceso") == 0 )
         {
            AV134SelFacturaEstatus = "En Proceso";
            AssignAttri("", false, "AV134SelFacturaEstatus", AV134SelFacturaEstatus);
         }
         else if ( StringUtil.StrCmp(AV105VarEstatusAdmin, "Aprobada") == 0 )
         {
            AV134SelFacturaEstatus = "Aprobada";
            AssignAttri("", false, "AV134SelFacturaEstatus", AV134SelFacturaEstatus);
         }
         else if ( StringUtil.StrCmp(AV105VarEstatusAdmin, "Rechazada") == 0 )
         {
            AV134SelFacturaEstatus = "Rechazada";
            AssignAttri("", false, "AV134SelFacturaEstatus", AV134SelFacturaEstatus);
         }
      }

      protected void S212( )
      {
         /* 'REMOVECAMBIO' Routine */
         returnInSub = false;
         AV126Idx = 1;
         while ( AV126Idx <= AV121Cambios.Count )
         {
            if ( ((SdtSDTCambioEstatus_SDTCambioEstatusItem)AV121Cambios.Item((int)(AV126Idx))).gxTpr_Facturaid == AV19FacturaID )
            {
               AV121Cambios.RemoveItem((int)(AV126Idx));
            }
            else
            {
               AV126Idx = (long)(AV126Idx+1);
            }
         }
         AV125CambiosCount = AV121Cambios.Count;
      }

      protected void S192( )
      {
         /* 'ESTAENCOLA' Routine */
         returnInSub = false;
         AV127EnCola = false;
         AssignAttri("", false, "AV127EnCola", AV127EnCola);
         AV152GXV8 = 1;
         while ( AV152GXV8 <= AV121Cambios.Count )
         {
            AV122c = ((SdtSDTCambioEstatus_SDTCambioEstatusItem)AV121Cambios.Item(AV152GXV8));
            if ( AV122c.gxTpr_Facturaid == AV19FacturaID )
            {
               AV127EnCola = true;
               AssignAttri("", false, "AV127EnCola", AV127EnCola);
               if (true) break;
            }
            AV152GXV8 = (int)(AV152GXV8+1);
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
         PA4R2( ) ;
         WS4R2( ) ;
         WE4R2( ) ;
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
         if ( ! ( WebComp_Allestatuswebcomponent1 == null ) )
         {
            if ( StringUtil.Len( WebComp_Allestatuswebcomponent1_Component) != 0 )
            {
               WebComp_Allestatuswebcomponent1.componentthemes();
            }
         }
         if ( ! ( WebComp_Estatusenprocesowebcomponent1 == null ) )
         {
            if ( StringUtil.Len( WebComp_Estatusenprocesowebcomponent1_Component) != 0 )
            {
               WebComp_Estatusenprocesowebcomponent1.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202651111311886", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 1018140), false, true);
         context.AddJavascriptSource("wpfacturasnew.js", "?202651111311887", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_722( )
      {
         edtFacturaID_Internalname = "FACTURAID_"+sGXsfl_72_idx;
         cmbFacturaEstatus_Internalname = "FACTURAESTATUS_"+sGXsfl_72_idx;
         edtUsuarioID_Internalname = "USUARIOID_"+sGXsfl_72_idx;
         edtMotivoRechazoActivo_Internalname = "MOTIVORECHAZOACTIVO_"+sGXsfl_72_idx;
         edtMotivoRechazoDescripcion_Internalname = "MOTIVORECHAZODESCRIPCION_"+sGXsfl_72_idx;
         edtMotivoRechazoID_Internalname = "MOTIVORECHAZOID_"+sGXsfl_72_idx;
         lblAllestatusrowanchor_Internalname = "ALLESTATUSROWANCHOR_"+sGXsfl_72_idx;
         lblAllestatusemptytb_Internalname = "ALLESTATUSEMPTYTB_"+sGXsfl_72_idx;
         imgAllestatususeraction4_Internalname = "ALLESTATUSUSERACTION4_"+sGXsfl_72_idx;
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO_"+sGXsfl_72_idx;
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO_"+sGXsfl_72_idx;
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION_"+sGXsfl_72_idx;
         edtFacturaNo_Internalname = "FACTURANO_"+sGXsfl_72_idx;
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA_"+sGXsfl_72_idx;
         edtavDistribuidordescripcion_Internalname = "vDISTRIBUIDORDESCRIPCION_"+sGXsfl_72_idx;
         cmbavVarestatus_Internalname = "vVARESTATUS_"+sGXsfl_72_idx;
         edtavMotivorechazo_Internalname = "vMOTIVORECHAZO_"+sGXsfl_72_idx;
         lblEstatusenprocesorowanchor_Internalname = "ESTATUSENPROCESOROWANCHOR_"+sGXsfl_72_idx;
         lblEstatusenprocesoemptytb_Internalname = "ESTATUSENPROCESOEMPTYTB_"+sGXsfl_72_idx;
         imgEstatusenprocesouseraction4_Internalname = "ESTATUSENPROCESOUSERACTION4_"+sGXsfl_72_idx;
         lblEstatusenprocesotextblock2_Internalname = "ESTATUSENPROCESOTEXTBLOCK2_"+sGXsfl_72_idx;
         lblEstatusenprocesotextblock3_Internalname = "ESTATUSENPROCESOTEXTBLOCK3_"+sGXsfl_72_idx;
         lblEstatusenprocesotextblock4_Internalname = "ESTATUSENPROCESOTEXTBLOCK4_"+sGXsfl_72_idx;
         lblEstatusenprocesotextblock5_Internalname = "ESTATUSENPROCESOTEXTBLOCK5_"+sGXsfl_72_idx;
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO_"+sGXsfl_72_idx;
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO_"+sGXsfl_72_idx;
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION_"+sGXsfl_72_idx;
         edtFacturaNo_Internalname = "FACTURANO_"+sGXsfl_72_idx;
         lblEstatusenprocesotextblock6_Internalname = "ESTATUSENPROCESOTEXTBLOCK6_"+sGXsfl_72_idx;
         lblEstatusenprocesotextblock7_Internalname = "ESTATUSENPROCESOTEXTBLOCK7_"+sGXsfl_72_idx;
         lblEstatusenprocesotextblock8_Internalname = "ESTATUSENPROCESOTEXTBLOCK8_"+sGXsfl_72_idx;
         lblEstatusenprocesotextblock9_Internalname = "ESTATUSENPROCESOTEXTBLOCK9_"+sGXsfl_72_idx;
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA_"+sGXsfl_72_idx;
         edtavDistribuidordescripcion_Internalname = "vDISTRIBUIDORDESCRIPCION_"+sGXsfl_72_idx;
         cmbavVarestatusadmin_Internalname = "vVARESTATUSADMIN_"+sGXsfl_72_idx;
         edtavMotivorechazoid_Internalname = "vMOTIVORECHAZOID_"+sGXsfl_72_idx;
      }

      protected void SubsflControlProps_fel_722( )
      {
         edtFacturaID_Internalname = "FACTURAID_"+sGXsfl_72_fel_idx;
         cmbFacturaEstatus_Internalname = "FACTURAESTATUS_"+sGXsfl_72_fel_idx;
         edtUsuarioID_Internalname = "USUARIOID_"+sGXsfl_72_fel_idx;
         edtMotivoRechazoActivo_Internalname = "MOTIVORECHAZOACTIVO_"+sGXsfl_72_fel_idx;
         edtMotivoRechazoDescripcion_Internalname = "MOTIVORECHAZODESCRIPCION_"+sGXsfl_72_fel_idx;
         edtMotivoRechazoID_Internalname = "MOTIVORECHAZOID_"+sGXsfl_72_fel_idx;
         lblAllestatusrowanchor_Internalname = "ALLESTATUSROWANCHOR_"+sGXsfl_72_fel_idx;
         lblAllestatusemptytb_Internalname = "ALLESTATUSEMPTYTB_"+sGXsfl_72_fel_idx;
         imgAllestatususeraction4_Internalname = "ALLESTATUSUSERACTION4_"+sGXsfl_72_fel_idx;
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO_"+sGXsfl_72_fel_idx;
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO_"+sGXsfl_72_fel_idx;
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION_"+sGXsfl_72_fel_idx;
         edtFacturaNo_Internalname = "FACTURANO_"+sGXsfl_72_fel_idx;
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA_"+sGXsfl_72_fel_idx;
         edtavDistribuidordescripcion_Internalname = "vDISTRIBUIDORDESCRIPCION_"+sGXsfl_72_fel_idx;
         cmbavVarestatus_Internalname = "vVARESTATUS_"+sGXsfl_72_fel_idx;
         edtavMotivorechazo_Internalname = "vMOTIVORECHAZO_"+sGXsfl_72_fel_idx;
         lblEstatusenprocesorowanchor_Internalname = "ESTATUSENPROCESOROWANCHOR_"+sGXsfl_72_fel_idx;
         lblEstatusenprocesoemptytb_Internalname = "ESTATUSENPROCESOEMPTYTB_"+sGXsfl_72_fel_idx;
         imgEstatusenprocesouseraction4_Internalname = "ESTATUSENPROCESOUSERACTION4_"+sGXsfl_72_fel_idx;
         lblEstatusenprocesotextblock2_Internalname = "ESTATUSENPROCESOTEXTBLOCK2_"+sGXsfl_72_fel_idx;
         lblEstatusenprocesotextblock3_Internalname = "ESTATUSENPROCESOTEXTBLOCK3_"+sGXsfl_72_fel_idx;
         lblEstatusenprocesotextblock4_Internalname = "ESTATUSENPROCESOTEXTBLOCK4_"+sGXsfl_72_fel_idx;
         lblEstatusenprocesotextblock5_Internalname = "ESTATUSENPROCESOTEXTBLOCK5_"+sGXsfl_72_fel_idx;
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO_"+sGXsfl_72_fel_idx;
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO_"+sGXsfl_72_fel_idx;
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION_"+sGXsfl_72_fel_idx;
         edtFacturaNo_Internalname = "FACTURANO_"+sGXsfl_72_fel_idx;
         lblEstatusenprocesotextblock6_Internalname = "ESTATUSENPROCESOTEXTBLOCK6_"+sGXsfl_72_fel_idx;
         lblEstatusenprocesotextblock7_Internalname = "ESTATUSENPROCESOTEXTBLOCK7_"+sGXsfl_72_fel_idx;
         lblEstatusenprocesotextblock8_Internalname = "ESTATUSENPROCESOTEXTBLOCK8_"+sGXsfl_72_fel_idx;
         lblEstatusenprocesotextblock9_Internalname = "ESTATUSENPROCESOTEXTBLOCK9_"+sGXsfl_72_fel_idx;
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA_"+sGXsfl_72_fel_idx;
         edtavDistribuidordescripcion_Internalname = "vDISTRIBUIDORDESCRIPCION_"+sGXsfl_72_fel_idx;
         cmbavVarestatusadmin_Internalname = "vVARESTATUSADMIN_"+sGXsfl_72_fel_idx;
         edtavMotivorechazoid_Internalname = "vMOTIVORECHAZOID_"+sGXsfl_72_fel_idx;
      }

      protected void sendrow_722( )
      {
         sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx), 4, 0), 4, "0");
         SubsflControlProps_722( ) ;
         WB4R0( ) ;
         if ( ( subFreestylegrid1_Rows * 1 == 0 ) || ( nGXsfl_72_idx <= subFreestylegrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Freestylegrid1Row = GXWebRow.GetNew(context,Freestylegrid1Container);
            if ( subFreestylegrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subFreestylegrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
               }
            }
            else if ( subFreestylegrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subFreestylegrid1_Backstyle = 0;
               subFreestylegrid1_Backcolor = subFreestylegrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Uniform";
               }
            }
            else if ( subFreestylegrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subFreestylegrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
               }
               subFreestylegrid1_Backcolor = (int)(0xFFFFFF);
            }
            else if ( subFreestylegrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subFreestylegrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_72_idx) % (2))) == 0 )
               {
                  subFreestylegrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
                  {
                     subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Even";
                  }
               }
               else
               {
                  subFreestylegrid1_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
                  {
                     subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
                  }
               }
            }
            /* Start of Columns property logic. */
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr"+" class=\""+subFreestylegrid1_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_72_idx+"\">") ;
            }
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFreestylegrid1layouttable_Internalname+"_"+sGXsfl_72_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Invisible",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
            /* Table start */
            Freestylegrid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfreestylegrid1_Internalname+"_"+sGXsfl_72_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            Freestylegrid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtFacturaID_Internalname,context.GetMessage( "Factura ID", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            ROClassString = "Attribute";
            Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtFacturaID_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)9,(string)"chr",(short)1,(string)"row",(short)9,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               Freestylegrid1Container.CloseTag("cell");
            }
            Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)cmbFacturaEstatus_Internalname,context.GetMessage( "Factura Estatus", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            if ( ( cmbFacturaEstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "FACTURAESTATUS_" + sGXsfl_72_idx;
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
            Freestylegrid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbFacturaEstatus,(string)cmbFacturaEstatus_Internalname,StringUtil.RTrim( A80FacturaEstatus),(short)1,(string)cmbFacturaEstatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbFacturaEstatus.Visible,(short)0,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"Attribute",(string)"",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbFacturaEstatus.CurrentValue = StringUtil.RTrim( A80FacturaEstatus);
            AssignProp("", false, cmbFacturaEstatus_Internalname, "Values", (string)(cmbFacturaEstatus.ToJavascriptSource()), !bGXsfl_72_Refreshing);
            Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               Freestylegrid1Container.CloseTag("cell");
            }
            Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioID_Internalname,context.GetMessage( "Usuario ID", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            ROClassString = "Attribute";
            Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtUsuarioID_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)9,(string)"chr",(short)1,(string)"row",(short)9,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               Freestylegrid1Container.CloseTag("cell");
            }
            Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtMotivoRechazoActivo_Internalname,context.GetMessage( "Motivo Rechazo Activo", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            ROClassString = "Attribute";
            Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoRechazoActivo_Internalname,StringUtil.BoolToStr( A21MotivoRechazoActivo),StringUtil.BoolToStr( A21MotivoRechazoActivo),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoRechazoActivo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtMotivoRechazoActivo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)72,(short)0,(short)0,(short)0,(bool)true,(string)"Activo",(string)"end",(bool)false,(string)""});
            Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               Freestylegrid1Container.CloseTag("cell");
            }
            Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtMotivoRechazoDescripcion_Internalname,context.GetMessage( "Motivo de rechazo", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            ROClassString = "Attribute";
            Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoRechazoDescripcion_Internalname,(string)A20MotivoRechazoDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoRechazoDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtMotivoRechazoDescripcion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)80,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               Freestylegrid1Container.CloseTag("cell");
            }
            Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtMotivoRechazoID_Internalname,context.GetMessage( "Motivo Rechazo ID", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_72_idx + "',72)\"";
            ROClassString = "Attribute";
            Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoRechazoID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MotivoRechazoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A19MotivoRechazoID), "ZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,94);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoRechazoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtMotivoRechazoID_Visible,(int)edtMotivoRechazoID_Enabled,(short)1,(string)"text",(string)"1",(short)9,(string)"chr",(short)1,(string)"row",(short)9,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)0,(bool)true,(string)"ID",(string)"end",(bool)false,(string)""});
            Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               Freestylegrid1Container.CloseTag("cell");
            }
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               Freestylegrid1Container.CloseTag("row");
            }
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               Freestylegrid1Container.CloseTag("table");
            }
            /* End of table */
            Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divAllestatustablecell_Internalname+"_"+sGXsfl_72_idx,(int)divAllestatustablecell_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divAllestatustable_Internalname+"_"+sGXsfl_72_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"TableMainWithPadding",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divAllestatustablepanel_Internalname+"_"+sGXsfl_72_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divAllestatustablestatusstrip_Internalname+"_"+sGXsfl_72_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)divAllestatustablestatusstrip_Class,(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            sendrow_72230( ) ;
         }
      }

      protected void sendrow_72230( )
      {
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblAllestatusrowanchor_Internalname,(string)" ",(string)"",(string)"",(string)lblAllestatusrowanchor_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblAllestatusemptytb_Internalname,(string)" ",(string)"",(string)"",(string)lblAllestatusemptytb_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         /* Active images/pictures */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         ClassString = "BotonImagenChica" + " " + ((StringUtil.StrCmp(imgAllestatususeraction4_gximage, "")==0) ? "GX_Image_iconoPDF_Class" : "GX_Image_"+imgAllestatususeraction4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "b97efd0f-8d9d-4227-92c4-9cbec8912646", "", context.GetTheme( )));
         Freestylegrid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgAllestatususeraction4_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)imgAllestatususeraction4_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'DOALLESTATUSUSERACTION4\\'."+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)" "+"data-gx-image"+" "+TempTags,(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3 DscTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtUsuarioNombreCompleto_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombreCompleto_Internalname,context.GetMessage( "Nombre completo", ""),(string)" AttributeFLLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "AttributeFL";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombreCompleto_Internalname,(string)A52UsuarioNombreCompleto,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombreCompleto_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3 DscTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtFacturaFechaRegistro_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaRegistro_Internalname,context.GetMessage( "Fecha Registro", ""),(string)" AttributeFLLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "AttributeFL";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaRegistro_Internalname,context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"),context.localUtil.Format( A72FacturaFechaRegistro, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaRegistro_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)8,(string)"chr",(short)1,(string)"row",(short)8,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3 DscTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtPromocionDescripcion_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtPromocionDescripcion_Internalname,context.GetMessage( "Nom. Promoción", ""),(string)" AttributeFLLabel",(short)1,(bool)true,(string)""});
         sendrow_72260( ) ;
      }

      protected void sendrow_72260( )
      {
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "AttributeFL";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionDescripcion_Internalname,(string)A42PromocionDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionDescripcion_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)80,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3 DscTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtFacturaNo_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtFacturaNo_Internalname,context.GetMessage( "No. Factura", ""),(string)" AttributeFLLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "AttributeFL";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaNo_Internalname,StringUtil.RTrim( A71FacturaNo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaNo_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)20,(string)"chr",(short)1,(string)"row",(short)20,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3 DscTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtFacturaFechaFactura_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaFactura_Internalname,context.GetMessage( "Fecha Factura", ""),(string)" AttributeFLLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "AttributeFL";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaFactura_Internalname,context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"),context.localUtil.Format( A73FacturaFechaFactura, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaFactura_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)8,(string)"chr",(short)1,(string)"row",(short)8,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3 DscTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtavDistribuidordescripcion_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavDistribuidordescripcion_Internalname,context.GetMessage( "Distribuidor al que representa", ""),(string)" AttributeFLLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'" + sGXsfl_72_idx + "',72)\"";
         ROClassString = "AttributeFL";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDistribuidordescripcion_Internalname,(string)AV85DistribuidorDescripcion,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDistribuidordescripcion_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavDistribuidordescripcion_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)80,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2 DscTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",cmbavVarestatus.Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+cmbavVarestatus_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)cmbavVarestatus_Internalname,context.GetMessage( "Estatus", ""),(string)" AttributeFLLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'" + sGXsfl_72_idx + "',72)\"";
         GXCCtl = "vVARESTATUS_" + sGXsfl_72_idx;
         cmbavVarestatus.Name = GXCCtl;
         cmbavVarestatus.WebTags = "";
         cmbavVarestatus.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavVarestatus.addItem("En Proceso", context.GetMessage( "En Proceso", ""), 0);
         cmbavVarestatus.addItem("Aprobada", context.GetMessage( "Aprobada", ""), 0);
         cmbavVarestatus.addItem("Rechazada", context.GetMessage( "Rechazada", ""), 0);
         cmbavVarestatus.addItem("Cancelada", context.GetMessage( "Cancelada", ""), 0);
         if ( cmbavVarestatus.ItemCount > 0 )
         {
            AV103VarEstatus = cmbavVarestatus.getValidValue(AV103VarEstatus);
            AssignAttri("", false, cmbavVarestatus_Internalname, AV103VarEstatus);
         }
         /* ComboBox */
         Freestylegrid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavVarestatus,(string)cmbavVarestatus_Internalname,StringUtil.RTrim( AV103VarEstatus),(short)1,(string)cmbavVarestatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbavVarestatus.Visible,cmbavVarestatus.Enabled,(short)1,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"AttributeFL",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,152);\"",(string)"",(bool)true,(short)0});
         cmbavVarestatus.CurrentValue = StringUtil.RTrim( AV103VarEstatus);
         AssignProp("", false, cmbavVarestatus_Internalname, "Values", (string)(cmbavVarestatus.ToJavascriptSource()), !bGXsfl_72_Refreshing);
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divMotivorechazo_cell_Internalname+"_"+sGXsfl_72_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)divMotivorechazo_cell_Class,(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(int)edtavMotivorechazo_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtavMotivorechazo_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavMotivorechazo_Internalname,context.GetMessage( "Motivo de rechazo", ""),(string)" AttributeFLLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'" + sGXsfl_72_idx + "',72)\"";
         ROClassString = "AttributeFL";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMotivorechazo_Internalname,(string)AV111MotivoRechazo,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,156);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMotivorechazo_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavMotivorechazo_Visible,(int)edtavMotivorechazo_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)80,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, "W0159"+sGXsfl_72_idx, StringUtil.RTrim( WebComp_Allestatuswebcomponent1_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+"gxHTMLWrpW0159"+sGXsfl_72_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_72_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Allestatuswebcomponent1_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( "W0159"+sGXsfl_72_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Allestatuswebcomponent1_Component) != 0 )
                     {
                        WebComp_Allestatuswebcomponent1.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldAllestatuswebcomponent1), StringUtil.Lower( WebComp_Allestatuswebcomponent1_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0159"+sGXsfl_72_idx);
               }
               WebComp_Allestatuswebcomponent1.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldAllestatuswebcomponent1), StringUtil.Lower( WebComp_Allestatuswebcomponent1_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Allestatuswebcomponent1_Component = "";
         WebComp_Allestatuswebcomponent1.componentjscripts();
         Freestylegrid1Row.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Allestatuswebcomponent1"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divEstatusenprocesotablecell_Internalname+"_"+sGXsfl_72_idx,(int)divEstatusenprocesotablecell_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divEstatusenprocesotable_Internalname+"_"+sGXsfl_72_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"TableMainWithPadding",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         sendrow_72290( ) ;
      }

      protected void sendrow_72290( )
      {
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divEstatusenprocesotablepanel_Internalname+"_"+sGXsfl_72_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divEstatusenprocesotablestatusstrip_Internalname+"_"+sGXsfl_72_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)divEstatusenprocesotablestatusstrip_Class,(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblEstatusenprocesorowanchor_Internalname,(string)" ",(string)"",(string)"",(string)lblEstatusenprocesorowanchor_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblEstatusenprocesoemptytb_Internalname,(string)" ",(string)"",(string)"",(string)lblEstatusenprocesoemptytb_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         /* Active images/pictures */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'',false,'',0)\"";
         ClassString = "BotonImagenChica" + " " + ((StringUtil.StrCmp(imgEstatusenprocesouseraction4_gximage, "")==0) ? "GX_Image_iconoPDF_Class" : "GX_Image_"+imgEstatusenprocesouseraction4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "b97efd0f-8d9d-4227-92c4-9cbec8912646", "", context.GetTheme( )));
         Freestylegrid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgEstatusenprocesouseraction4_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)imgEstatusenprocesouseraction4_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'DOESTATUSENPROCESOUSERACTION4\\'."+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)" "+"data-gx-image"+" "+TempTags,(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 hidden-xs",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divEstatusenprocesotablelabel1_Internalname+"_"+sGXsfl_72_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         sendrow_722120( ) ;
      }

      protected void sendrow_722120( )
      {
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblEstatusenprocesotextblock2_Internalname,context.GetMessage( "Nombre completo", ""),(string)"",(string)"",(string)lblEstatusenprocesotextblock2_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"gx-label AttributeFLLabel control-label",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblEstatusenprocesotextblock3_Internalname,context.GetMessage( "Fecha Registro", ""),(string)"",(string)"",(string)lblEstatusenprocesotextblock3_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"gx-label AttributeFLLabel control-label",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblEstatusenprocesotextblock4_Internalname,context.GetMessage( "Nom. Promoción", ""),(string)"",(string)"",(string)lblEstatusenprocesotextblock4_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"gx-label AttributeFLLabel control-label",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblEstatusenprocesotextblock5_Internalname,context.GetMessage( "No. Factura", ""),(string)"",(string)"",(string)lblEstatusenprocesotextblock5_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"gx-label AttributeFLLabel control-label",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "AttributeFL";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombreCompleto_Internalname,(string)A52UsuarioNombreCompleto,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNombreCompleto_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "AttributeFL";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaRegistro_Internalname,context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"),context.localUtil.Format( A72FacturaFechaRegistro, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaRegistro_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)8,(string)"chr",(short)1,(string)"row",(short)8,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "AttributeFL";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPromocionDescripcion_Internalname,(string)A42PromocionDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPromocionDescripcion_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)80,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "AttributeFL";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaNo_Internalname,StringUtil.RTrim( A71FacturaNo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaNo_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)20,(string)"chr",(short)1,(string)"row",(short)20,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 hidden-xs",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divEstatusenprocesotablelabel2_Internalname+"_"+sGXsfl_72_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblEstatusenprocesotextblock6_Internalname,context.GetMessage( "Fecha Factura", ""),(string)"",(string)"",(string)lblEstatusenprocesotextblock6_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"gx-label AttributeFLLabel control-label",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblEstatusenprocesotextblock7_Internalname,context.GetMessage( "Distribuidor al que representa", ""),(string)"",(string)"",(string)lblEstatusenprocesotextblock7_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"gx-label AttributeFLLabel control-label",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblEstatusenprocesotextblock8_Internalname,context.GetMessage( "Estatus", ""),(string)"",(string)"",(string)lblEstatusenprocesotextblock8_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"gx-label AttributeFLLabel control-label",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         sendrow_722150( ) ;
      }

      protected void sendrow_722150( )
      {
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblEstatusenprocesotextblock9_Internalname,context.GetMessage( "Motivo de rechazo", ""),(string)"",(string)"",(string)lblEstatusenprocesotextblock9_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"gx-label AttributeFLLabel control-label",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "AttributeFL";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFacturaFechaFactura_Internalname,context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"),context.localUtil.Format( A73FacturaFechaFactura, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFacturaFechaFactura_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)8,(string)"chr",(short)1,(string)"row",(short)8,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 230,'',false,'" + sGXsfl_72_idx + "',72)\"";
         ROClassString = "AttributeFL";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDistribuidordescripcion_Internalname,(string)AV85DistribuidorDescripcion,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,230);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDistribuidordescripcion_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavDistribuidordescripcion_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)80,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)cmbavVarestatusadmin_Internalname,context.GetMessage( "Var Estatus Admin", ""),(string)"col-sm-3 AttributeFLLabel",(short)0,(bool)true,(string)""});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 233,'',false,'" + sGXsfl_72_idx + "',72)\"";
         GXCCtl = "vVARESTATUSADMIN_" + sGXsfl_72_idx;
         cmbavVarestatusadmin.Name = GXCCtl;
         cmbavVarestatusadmin.WebTags = "";
         cmbavVarestatusadmin.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavVarestatusadmin.addItem("En Proceso", context.GetMessage( "En Proceso", ""), 0);
         cmbavVarestatusadmin.addItem("Aprobada", context.GetMessage( "Aprobada", ""), 0);
         cmbavVarestatusadmin.addItem("Rechazada", context.GetMessage( "Rechazada", ""), 0);
         if ( cmbavVarestatusadmin.ItemCount > 0 )
         {
            AV105VarEstatusAdmin = cmbavVarestatusadmin.getValidValue(AV105VarEstatusAdmin);
            AssignAttri("", false, cmbavVarestatusadmin_Internalname, AV105VarEstatusAdmin);
         }
         /* ComboBox */
         Freestylegrid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavVarestatusadmin,(string)cmbavVarestatusadmin_Internalname,StringUtil.RTrim( AV105VarEstatusAdmin),(short)1,(string)cmbavVarestatusadmin_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbavVarestatusadmin.Visible,cmbavVarestatusadmin.Enabled,(short)1,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"AttributeFL",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,233);\"",(string)"",(bool)true,(short)0});
         cmbavVarestatusadmin.CurrentValue = StringUtil.RTrim( AV105VarEstatusAdmin);
         AssignProp("", false, cmbavVarestatusadmin_Internalname, "Values", (string)(cmbavVarestatusadmin.ToJavascriptSource()), !bGXsfl_72_Refreshing);
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divEstatusenprocesotablemr_Internalname+"_"+sGXsfl_72_idx,(int)divEstatusenprocesotablemr_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3 ExtendedComboCell",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavMotivorechazoid_Internalname,context.GetMessage( "Motivo Rechazo ID", ""),(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 239,'',false,'" + sGXsfl_72_idx + "',72)\"";
         ROClassString = "Attribute";
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMotivorechazoid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV107MotivoRechazoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV107MotivoRechazoID), "ZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,239);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMotivorechazoid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavMotivorechazoid_Visible,(int)edtavMotivorechazoid_Enabled,(short)1,(string)"text",(string)"1",(short)9,(string)"chr",(short)1,(string)"row",(short)9,(short)0,(short)0,(short)72,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, "W0242"+sGXsfl_72_idx, StringUtil.RTrim( WebComp_Estatusenprocesowebcomponent1_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+"gxHTMLWrpW0242"+sGXsfl_72_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_72_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Estatusenprocesowebcomponent1_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( "W0242"+sGXsfl_72_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Estatusenprocesowebcomponent1_Component) != 0 )
                     {
                        WebComp_Estatusenprocesowebcomponent1.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldEstatusenprocesowebcomponent1), StringUtil.Lower( WebComp_Estatusenprocesowebcomponent1_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0242"+sGXsfl_72_idx);
               }
               WebComp_Estatusenprocesowebcomponent1.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldEstatusenprocesowebcomponent1), StringUtil.Lower( WebComp_Estatusenprocesowebcomponent1_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Estatusenprocesowebcomponent1_Component = "";
         WebComp_Estatusenprocesowebcomponent1.componentjscripts();
         Freestylegrid1Row.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Estatusenprocesowebcomponent1"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes4R2( ) ;
         /* End of Columns property logic. */
         Freestylegrid1Container.AddRow(Freestylegrid1Row);
         nGXsfl_72_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_72_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_72_idx+1);
         sGXsfl_72_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_72_idx), 4, 0), 4, "0");
         SubsflControlProps_722( ) ;
         /* End function sendrow_722 */
      }

      protected void init_web_controls( )
      {
         cmbavFacturaestatus.Name = "vFACTURAESTATUS";
         cmbavFacturaestatus.WebTags = "";
         cmbavFacturaestatus.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavFacturaestatus.addItem("En Proceso", context.GetMessage( "En Proceso", ""), 0);
         cmbavFacturaestatus.addItem("Aprobada", context.GetMessage( "Aprobada", ""), 0);
         cmbavFacturaestatus.addItem("Rechazada", context.GetMessage( "Rechazada", ""), 0);
         cmbavFacturaestatus.addItem("Cancelada", context.GetMessage( "Cancelada", ""), 0);
         if ( cmbavFacturaestatus.ItemCount > 0 )
         {
            AV92FacturaEstatus = cmbavFacturaestatus.getValidValue(AV92FacturaEstatus);
            AssignAttri("", false, "AV92FacturaEstatus", AV92FacturaEstatus);
         }
         GXCCtl = "FACTURAESTATUS_" + sGXsfl_72_idx;
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
         GXCCtl = "vVARESTATUS_" + sGXsfl_72_idx;
         cmbavVarestatus.Name = GXCCtl;
         cmbavVarestatus.WebTags = "";
         cmbavVarestatus.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavVarestatus.addItem("En Proceso", context.GetMessage( "En Proceso", ""), 0);
         cmbavVarestatus.addItem("Aprobada", context.GetMessage( "Aprobada", ""), 0);
         cmbavVarestatus.addItem("Rechazada", context.GetMessage( "Rechazada", ""), 0);
         cmbavVarestatus.addItem("Cancelada", context.GetMessage( "Cancelada", ""), 0);
         if ( cmbavVarestatus.ItemCount > 0 )
         {
            AV103VarEstatus = cmbavVarestatus.getValidValue(AV103VarEstatus);
            AssignAttri("", false, cmbavVarestatus_Internalname, AV103VarEstatus);
         }
         GXCCtl = "vVARESTATUSADMIN_" + sGXsfl_72_idx;
         cmbavVarestatusadmin.Name = GXCCtl;
         cmbavVarestatusadmin.WebTags = "";
         cmbavVarestatusadmin.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavVarestatusadmin.addItem("En Proceso", context.GetMessage( "En Proceso", ""), 0);
         cmbavVarestatusadmin.addItem("Aprobada", context.GetMessage( "Aprobada", ""), 0);
         cmbavVarestatusadmin.addItem("Rechazada", context.GetMessage( "Rechazada", ""), 0);
         if ( cmbavVarestatusadmin.ItemCount > 0 )
         {
            AV105VarEstatusAdmin = cmbavVarestatusadmin.getValidValue(AV105VarEstatusAdmin);
            AssignAttri("", false, cmbavVarestatusadmin_Internalname, AV105VarEstatusAdmin);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl72( )
      {
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Freestylegrid1Container"+"DivS\" data-gxgridid=\"72\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFreestylegrid1_Internalname, subFreestylegrid1_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Freestylegrid1Container = new GXWebGrid( context);
            }
            else
            {
               Freestylegrid1Container.Clear();
            }
            Freestylegrid1Container.SetIsFreestyle(true);
            Freestylegrid1Container.SetWrapped(nGXWrapped);
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
            Freestylegrid1Container.AddObjectProperty("Header", subFreestylegrid1_Header);
            Freestylegrid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Freestylegrid1Container.AddObjectProperty("Class", "FreeStyleGrid");
            Freestylegrid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Backcolorstyle), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("CmpContext", "");
            Freestylegrid1Container.AddObjectProperty("InMasterPage", "false");
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, ".", ""))));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFacturaID_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A80FacturaEstatus)));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFacturaEstatus.Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, ".", ""))));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioID_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A21MotivoRechazoActivo)));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMotivoRechazoActivo_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A20MotivoRechazoDescripcion));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMotivoRechazoDescripcion_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MotivoRechazoID), 9, 0, ".", ""))));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMotivoRechazoID_Enabled), 5, 0, ".", "")));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMotivoRechazoID_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblAllestatusrowanchor_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblAllestatusrowanchor_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", context.convertURL( context.GetImagePath( "b97efd0f-8d9d-4227-92c4-9cbec8912646", "", context.GetTheme( ))));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A52UsuarioNombreCompleto));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A42PromocionDescripcion));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A71FacturaNo)));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A73FacturaFechaFactura, "99/99/99")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV85DistribuidorDescripcion));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDistribuidordescripcion_Enabled), 5, 0, ".", "")));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDistribuidordescripcion_Enabled), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV103VarEstatus)));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavVarestatus.Visible), 5, 0, ".", "")));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavVarestatus.Enabled), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV111MotivoRechazo));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMotivorechazo_Enabled), 5, 0, ".", "")));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMotivorechazo_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblAllestatusrowanchor_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblAllestatusrowanchor_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", context.convertURL( context.GetImagePath( "b97efd0f-8d9d-4227-92c4-9cbec8912646", "", context.GetTheme( ))));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblEstatusenprocesotextblock2_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblEstatusenprocesotextblock3_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblEstatusenprocesotextblock4_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblEstatusenprocesotextblock5_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A52UsuarioNombreCompleto));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A42PromocionDescripcion));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A71FacturaNo)));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblEstatusenprocesotextblock6_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblEstatusenprocesotextblock7_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblEstatusenprocesotextblock8_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblEstatusenprocesotextblock9_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A73FacturaFechaFactura, "99/99/99")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV85DistribuidorDescripcion));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDistribuidordescripcion_Enabled), 5, 0, ".", "")));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDistribuidordescripcion_Enabled), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV105VarEstatusAdmin)));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavVarestatusadmin.Visible), 5, 0, ".", "")));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavVarestatusadmin.Enabled), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV107MotivoRechazoID), 9, 0, ".", ""))));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMotivorechazoid_Enabled), 5, 0, ".", "")));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMotivorechazoid_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Selectedindex), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowselection), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Selectioncolor), 9, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowhovering), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Hoveringcolor), 9, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowcollapsing), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavFromdate_Internalname = "vFROMDATE";
         edtavTodate_Internalname = "vTODATE";
         cmbavFacturaestatus_Internalname = "vFACTURAESTATUS";
         edtavFacturano_Internalname = "vFACTURANO";
         lblTextblockcombo_distribuidorid_Internalname = "TEXTBLOCKCOMBO_DISTRIBUIDORID";
         Combo_distribuidorid_Internalname = "COMBO_DISTRIBUIDORID";
         divTablesplitteddistribuidorid_Internalname = "TABLESPLITTEDDISTRIBUIDORID";
         lblTextblockcombo_promocionid_Internalname = "TEXTBLOCKCOMBO_PROMOCIONID";
         Combo_promocionid_Internalname = "COMBO_PROMOCIONID";
         divTablesplittedpromocionid_Internalname = "TABLESPLITTEDPROMOCIONID";
         lblTextblockcombo_usuarioid_Internalname = "TEXTBLOCKCOMBO_USUARIOID";
         Combo_usuarioid_Internalname = "COMBO_USUARIOID";
         divTablesplittedusuarioid_Internalname = "TABLESPLITTEDUSUARIOID";
         bttBtnuseraction99_Internalname = "BTNUSERACTION99";
         imgGeneraexcel_Internalname = "GENERAEXCEL";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Utchartdoughnut_Internalname = "UTCHARTDOUGHNUT";
         Utchartcolumnline_Internalname = "UTCHARTCOLUMNLINE";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         edtFacturaID_Internalname = "FACTURAID";
         cmbFacturaEstatus_Internalname = "FACTURAESTATUS";
         edtUsuarioID_Internalname = "USUARIOID";
         edtMotivoRechazoActivo_Internalname = "MOTIVORECHAZOACTIVO";
         edtMotivoRechazoDescripcion_Internalname = "MOTIVORECHAZODESCRIPCION";
         edtMotivoRechazoID_Internalname = "MOTIVORECHAZOID";
         tblUnnamedtablecontentfsfreestylegrid1_Internalname = "UNNAMEDTABLECONTENTFSFREESTYLEGRID1";
         lblAllestatusrowanchor_Internalname = "ALLESTATUSROWANCHOR";
         lblAllestatusemptytb_Internalname = "ALLESTATUSEMPTYTB";
         imgAllestatususeraction4_Internalname = "ALLESTATUSUSERACTION4";
         divAllestatustablestatusstrip_Internalname = "ALLESTATUSTABLESTATUSSTRIP";
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO";
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO";
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION";
         edtFacturaNo_Internalname = "FACTURANO";
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA";
         edtavDistribuidordescripcion_Internalname = "vDISTRIBUIDORDESCRIPCION";
         cmbavVarestatus_Internalname = "vVARESTATUS";
         edtavMotivorechazo_Internalname = "vMOTIVORECHAZO";
         divMotivorechazo_cell_Internalname = "MOTIVORECHAZO_CELL";
         divAllestatustablepanel_Internalname = "ALLESTATUSTABLEPANEL";
         divAllestatustable_Internalname = "ALLESTATUSTABLE";
         divAllestatustablecell_Internalname = "ALLESTATUSTABLECELL";
         lblEstatusenprocesorowanchor_Internalname = "ESTATUSENPROCESOROWANCHOR";
         lblEstatusenprocesoemptytb_Internalname = "ESTATUSENPROCESOEMPTYTB";
         imgEstatusenprocesouseraction4_Internalname = "ESTATUSENPROCESOUSERACTION4";
         divEstatusenprocesotablestatusstrip_Internalname = "ESTATUSENPROCESOTABLESTATUSSTRIP";
         lblEstatusenprocesotextblock2_Internalname = "ESTATUSENPROCESOTEXTBLOCK2";
         lblEstatusenprocesotextblock3_Internalname = "ESTATUSENPROCESOTEXTBLOCK3";
         lblEstatusenprocesotextblock4_Internalname = "ESTATUSENPROCESOTEXTBLOCK4";
         lblEstatusenprocesotextblock5_Internalname = "ESTATUSENPROCESOTEXTBLOCK5";
         divEstatusenprocesotablelabel1_Internalname = "ESTATUSENPROCESOTABLELABEL1";
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO";
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO";
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION";
         edtFacturaNo_Internalname = "FACTURANO";
         lblEstatusenprocesotextblock6_Internalname = "ESTATUSENPROCESOTEXTBLOCK6";
         lblEstatusenprocesotextblock7_Internalname = "ESTATUSENPROCESOTEXTBLOCK7";
         lblEstatusenprocesotextblock8_Internalname = "ESTATUSENPROCESOTEXTBLOCK8";
         lblEstatusenprocesotextblock9_Internalname = "ESTATUSENPROCESOTEXTBLOCK9";
         divEstatusenprocesotablelabel2_Internalname = "ESTATUSENPROCESOTABLELABEL2";
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA";
         edtavDistribuidordescripcion_Internalname = "vDISTRIBUIDORDESCRIPCION";
         cmbavVarestatusadmin_Internalname = "vVARESTATUSADMIN";
         edtavMotivorechazoid_Internalname = "vMOTIVORECHAZOID";
         divEstatusenprocesotablemr_Internalname = "ESTATUSENPROCESOTABLEMR";
         divEstatusenprocesotablepanel_Internalname = "ESTATUSENPROCESOTABLEPANEL";
         divEstatusenprocesotable_Internalname = "ESTATUSENPROCESOTABLE";
         divEstatusenprocesotablecell_Internalname = "ESTATUSENPROCESOTABLECELL";
         divFreestylegrid1layouttable_Internalname = "FREESTYLEGRID1LAYOUTTABLE";
         Freestylegrid1paginationbar_Internalname = "FREESTYLEGRID1PAGINATIONBAR";
         divFreestylegrid1tablewithpaging_Internalname = "FREESTYLEGRID1TABLEWITHPAGING";
         bttBtncambiarestatus_Internalname = "BTNCAMBIARESTATUS";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divTablemain_Internalname = "TABLEMAIN";
         Combo_motivorechazoid_Internalname = "COMBO_MOTIVORECHAZOID";
         edtavFreestylegrid1currentpage_Internalname = "vFREESTYLEGRID1CURRENTPAGE";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subFreestylegrid1_Internalname = "FREESTYLEGRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subFreestylegrid1_Allowcollapsing = 0;
         lblEstatusenprocesotextblock9_Caption = context.GetMessage( "Motivo de rechazo", "");
         lblEstatusenprocesotextblock8_Caption = context.GetMessage( "Estatus", "");
         lblEstatusenprocesotextblock7_Caption = context.GetMessage( "Distribuidor al que representa", "");
         lblEstatusenprocesotextblock6_Caption = context.GetMessage( "Fecha Factura", "");
         lblEstatusenprocesotextblock5_Caption = context.GetMessage( "No. Factura", "");
         lblEstatusenprocesotextblock4_Caption = context.GetMessage( "Nom. Promoción", "");
         lblEstatusenprocesotextblock3_Caption = context.GetMessage( "Fecha Registro", "");
         lblEstatusenprocesotextblock2_Caption = context.GetMessage( "Nombre completo", "");
         lblAllestatusrowanchor_Caption = " ";
         edtavMotivorechazoid_Jsonclick = "";
         divEstatusenprocesotablemr_Visible = 1;
         cmbavVarestatusadmin_Jsonclick = "";
         cmbavVarestatusadmin.Visible = 1;
         cmbavVarestatusadmin.Enabled = 1;
         divEstatusenprocesotablecell_Visible = 1;
         edtavMotivorechazo_Jsonclick = "";
         edtavMotivorechazo_Enabled = 1;
         cmbavVarestatus_Jsonclick = "";
         cmbavVarestatus.Enabled = 1;
         cmbavVarestatus.Visible = 1;
         edtavDistribuidordescripcion_Jsonclick = "";
         edtavDistribuidordescripcion_Enabled = 1;
         edtFacturaFechaFactura_Jsonclick = "";
         edtFacturaNo_Jsonclick = "";
         edtPromocionDescripcion_Jsonclick = "";
         edtFacturaFechaRegistro_Jsonclick = "";
         edtUsuarioNombreCompleto_Jsonclick = "";
         divAllestatustablecell_Visible = 1;
         edtMotivoRechazoID_Jsonclick = "";
         edtMotivoRechazoDescripcion_Jsonclick = "";
         edtMotivoRechazoActivo_Jsonclick = "";
         edtUsuarioID_Jsonclick = "";
         cmbFacturaEstatus_Jsonclick = "";
         edtFacturaID_Jsonclick = "";
         subFreestylegrid1_Class = "FreeStyleGrid";
         edtavMotivorechazoid_Enabled = 1;
         edtavMotivorechazoid_Visible = 1;
         divAllestatustablestatusstrip_Class = "StatusStripEnProceso";
         divEstatusenprocesotablestatusstrip_Class = "StatusStripEnProceso";
         divMotivorechazo_cell_Class = "col-xs-12 col-sm-3";
         edtFacturaFechaFactura_Enabled = 0;
         edtFacturaNo_Enabled = 0;
         edtPromocionDescripcion_Enabled = 0;
         edtFacturaFechaRegistro_Enabled = 0;
         edtUsuarioNombreCompleto_Enabled = 0;
         edtMotivoRechazoID_Enabled = 0;
         edtMotivoRechazoDescripcion_Enabled = 0;
         edtMotivoRechazoActivo_Enabled = 0;
         edtUsuarioID_Enabled = 0;
         cmbFacturaEstatus.Enabled = 0;
         edtFacturaID_Enabled = 0;
         subFreestylegrid1_Backcolorstyle = 0;
         edtavFreestylegrid1currentpage_Jsonclick = "";
         edtavFreestylegrid1currentpage_Visible = 1;
         Combo_usuarioid_Caption = "";
         Combo_promocionid_Caption = "";
         Combo_distribuidorid_Caption = "";
         edtavFacturano_Jsonclick = "";
         edtavFacturano_Enabled = 1;
         cmbavFacturaestatus_Jsonclick = "";
         cmbavFacturaestatus.Enabled = 1;
         edtavTodate_Jsonclick = "";
         edtavTodate_Enabled = 1;
         edtavFromdate_Jsonclick = "";
         edtavFromdate_Enabled = 1;
         Combo_motivorechazoid_Isgriditem = Convert.ToBoolean( -1);
         Combo_motivorechazoid_Titlecontrolidtoreplace = "";
         Combo_motivorechazoid_Visible = Convert.ToBoolean( -1);
         Combo_motivorechazoid_Enabled = Convert.ToBoolean( -1);
         Combo_motivorechazoid_Cls = "ExtendedCombo AttributeFL";
         Freestylegrid1paginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Freestylegrid1paginationbar_Emptygridcaption = "No se encontraron facturas";
         Freestylegrid1paginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Freestylegrid1paginationbar_Next = "WWP_PagingNextCaption";
         Freestylegrid1paginationbar_Previous = "WWP_PagingPreviousCaption";
         Freestylegrid1paginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Freestylegrid1paginationbar_Rowsperpageselectedvalue = 10;
         Freestylegrid1paginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Freestylegrid1paginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Freestylegrid1paginationbar_Pagingcaptionposition = "Left";
         Freestylegrid1paginationbar_Pagingbuttonsposition = "Right";
         Freestylegrid1paginationbar_Pagestoshow = 5;
         Freestylegrid1paginationbar_Showlast = Convert.ToBoolean( 0);
         Freestylegrid1paginationbar_Shownext = Convert.ToBoolean( -1);
         Freestylegrid1paginationbar_Showprevious = Convert.ToBoolean( -1);
         Freestylegrid1paginationbar_Showfirst = Convert.ToBoolean( 0);
         Freestylegrid1paginationbar_Class = "PaginationBar";
         Utchartcolumnline_Title = context.GetMessage( "Bonos", "");
         Utchartcolumnline_Type = "Chart";
         Utchartcolumnline_Objectcall = "";
         Utchartdoughnut_Charttype = "Doughnut";
         Utchartdoughnut_Showvalues = Convert.ToBoolean( -1);
         Utchartdoughnut_Title = context.GetMessage( "Estatus", "");
         Utchartdoughnut_Type = "Chart";
         Utchartdoughnut_Objectcall = "";
         Combo_usuarioid_Multiplevaluestype = "Tags";
         Combo_usuarioid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_usuarioid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_usuarioid_Cls = "ExtendedCombo AttributeFL";
         Combo_promocionid_Multiplevaluestype = "Tags";
         Combo_promocionid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_promocionid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_promocionid_Cls = "ExtendedCombo AttributeFL";
         Combo_distribuidorid_Multiplevaluestype = "Tags";
         Combo_distribuidorid_Emptyitem = Convert.ToBoolean( 0);
         Combo_distribuidorid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_distribuidorid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_distribuidorid_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Facturas", "");
         edtavMotivorechazo_Visible = 1;
         edtMotivoRechazoID_Visible = 1;
         edtMotivoRechazoDescripcion_Visible = 1;
         edtMotivoRechazoActivo_Visible = 1;
         edtUsuarioID_Visible = 1;
         cmbFacturaEstatus.Visible = 1;
         edtFacturaID_Visible = 1;
         subFreestylegrid1_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"FREESTYLEGRID1_nEOF"},{"av":"edtFacturaID_Visible","ctrl":"FACTURAID","prop":"Visible"},{"av":"cmbFacturaEstatus"},{"av":"edtUsuarioID_Visible","ctrl":"USUARIOID","prop":"Visible"},{"av":"edtMotivoRechazoActivo_Visible","ctrl":"MOTIVORECHAZOACTIVO","prop":"Visible"},{"av":"edtMotivoRechazoDescripcion_Visible","ctrl":"MOTIVORECHAZODESCRIPCION","prop":"Visible"},{"av":"edtMotivoRechazoID_Visible","ctrl":"MOTIVORECHAZOID","prop":"Visible"},{"av":"edtavMotivorechazo_Visible","ctrl":"vMOTIVORECHAZO","prop":"Visible"},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV127EnCola","fld":"vENCOLA"},{"av":"AV121Cambios","fld":"vCAMBIOS"},{"av":"AV19FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"subFreestylegrid1_Rows","ctrl":"FREESTYLEGRID1","prop":"Rows"},{"av":"AV22FromDate","fld":"vFROMDATE"},{"av":"AV52ToDate","fld":"vTODATE"},{"av":"cmbavFacturaestatus"},{"av":"AV92FacturaEstatus","fld":"vFACTURAESTATUS"},{"av":"AV99FacturaNo","fld":"vFACTURANO"},{"av":"AV90TotalRows","fld":"vTOTALROWS","pic":"ZZZZZZZZZZZZZZZZZ9"},{"av":"AV117DoScroll","fld":"vDOSCROLL","hsh":true},{"av":"AV116KeepPage","fld":"vKEEPPAGE","pic":"ZZZ9","hsh":true},{"av":"AV95PromocionID","fld":"vPROMOCIONID"},{"av":"AV97UsuarioID","fld":"vUSUARIOID"},{"av":"AV100UsuariosFiltro","fld":"vUSUARIOSFILTRO"},{"av":"AV62ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV15DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"AV37RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA","hsh":true},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS","hsh":true},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A71FacturaNo","fld":"FACTURANO","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV87FreeStyleGrid1PageCount","fld":"vFREESTYLEGRID1PAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV86FreeStyleGrid1CurrentPage","fld":"vFREESTYLEGRID1CURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"Freestylegrid1paginationbar_Rowsperpageselectedvalue","ctrl":"FREESTYLEGRID1PAGINATIONBAR","prop":"RowsPerPageSelectedValue"},{"av":"AV90TotalRows","fld":"vTOTALROWS","pic":"ZZZZZZZZZZZZZZZZZ9"},{"av":"AV100UsuariosFiltro","fld":"vUSUARIOSFILTRO"},{"av":"AV62ListaUsuarios","fld":"vLISTAUSUARIOS"}]}""");
         setEventMetadata("FREESTYLEGRID1.LOAD","""{"handler":"E214R2","iparms":[{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS","hsh":true},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"A20MotivoRechazoDescripcion","fld":"MOTIVORECHAZODESCRIPCION"},{"av":"AV127EnCola","fld":"vENCOLA"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV121Cambios","fld":"vCAMBIOS"},{"av":"AV19FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV37RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("FREESTYLEGRID1.LOAD",""","oparms":[{"av":"cmbavVarestatusadmin"},{"av":"cmbavVarestatus"},{"av":"Combo_motivorechazoid_Visible","ctrl":"COMBO_MOTIVORECHAZOID","prop":"Visible"},{"av":"Combo_motivorechazoid_Enabled","ctrl":"COMBO_MOTIVORECHAZOID","prop":"Enabled"},{"av":"edtavMotivorechazoid_Visible","ctrl":"vMOTIVORECHAZOID","prop":"Visible"},{"av":"edtavMotivorechazoid_Enabled","ctrl":"vMOTIVORECHAZOID","prop":"Enabled"},{"av":"divEstatusenprocesotablemr_Visible","ctrl":"ESTATUSENPROCESOTABLEMR","prop":"Visible"},{"av":"AV103VarEstatus","fld":"vVARESTATUS"},{"av":"AV37RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV85DistribuidorDescripcion","fld":"vDISTRIBUIDORDESCRIPCION"},{"av":"AV111MotivoRechazo","fld":"vMOTIVORECHAZO"},{"av":"edtavMotivorechazo_Visible","ctrl":"vMOTIVORECHAZO","prop":"Visible"},{"av":"divMotivorechazo_cell_Class","ctrl":"MOTIVORECHAZO_CELL","prop":"Class"},{"av":"divEstatusenprocesotablestatusstrip_Class","ctrl":"ESTATUSENPROCESOTABLESTATUSSTRIP","prop":"Class"},{"av":"divAllestatustablestatusstrip_Class","ctrl":"ALLESTATUSTABLESTATUSSTRIP","prop":"Class"},{"av":"divAllestatustablecell_Visible","ctrl":"ALLESTATUSTABLECELL","prop":"Visible"},{"av":"divEstatusenprocesotablecell_Visible","ctrl":"ESTATUSENPROCESOTABLECELL","prop":"Visible"},{"ctrl":"ESTATUSENPROCESOWEBCOMPONENT1"},{"ctrl":"ALLESTATUSWEBCOMPONENT1"},{"av":"AV105VarEstatusAdmin","fld":"vVARESTATUSADMIN"},{"av":"AV127EnCola","fld":"vENCOLA"}]}""");
         setEventMetadata("FREESTYLEGRID1PAGINATIONBAR.CHANGEPAGE","""{"handler":"E144R2","iparms":[{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"FREESTYLEGRID1_nEOF"},{"av":"subFreestylegrid1_Rows","ctrl":"FREESTYLEGRID1","prop":"Rows"},{"av":"AV22FromDate","fld":"vFROMDATE"},{"av":"AV52ToDate","fld":"vTODATE"},{"av":"cmbavFacturaestatus"},{"av":"AV92FacturaEstatus","fld":"vFACTURAESTATUS"},{"av":"AV99FacturaNo","fld":"vFACTURANO"},{"av":"AV90TotalRows","fld":"vTOTALROWS","pic":"ZZZZZZZZZZZZZZZZZ9"},{"av":"AV117DoScroll","fld":"vDOSCROLL","hsh":true},{"av":"AV116KeepPage","fld":"vKEEPPAGE","pic":"ZZZ9","hsh":true},{"av":"AV95PromocionID","fld":"vPROMOCIONID"},{"av":"AV97UsuarioID","fld":"vUSUARIOID"},{"av":"AV100UsuariosFiltro","fld":"vUSUARIOSFILTRO"},{"av":"AV62ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV15DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"edtFacturaID_Visible","ctrl":"FACTURAID","prop":"Visible"},{"av":"cmbFacturaEstatus"},{"av":"edtUsuarioID_Visible","ctrl":"USUARIOID","prop":"Visible"},{"av":"edtMotivoRechazoActivo_Visible","ctrl":"MOTIVORECHAZOACTIVO","prop":"Visible"},{"av":"edtMotivoRechazoDescripcion_Visible","ctrl":"MOTIVORECHAZODESCRIPCION","prop":"Visible"},{"av":"edtMotivoRechazoID_Visible","ctrl":"MOTIVORECHAZOID","prop":"Visible"},{"av":"edtavMotivorechazo_Visible","ctrl":"vMOTIVORECHAZO","prop":"Visible"},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV127EnCola","fld":"vENCOLA"},{"av":"AV121Cambios","fld":"vCAMBIOS"},{"av":"AV19FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV37RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"Freestylegrid1paginationbar_Selectedpage","ctrl":"FREESTYLEGRID1PAGINATIONBAR","prop":"SelectedPage"},{"av":"AV86FreeStyleGrid1CurrentPage","fld":"vFREESTYLEGRID1CURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA","hsh":true},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS","hsh":true},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A71FacturaNo","fld":"FACTURANO","hsh":true}]""");
         setEventMetadata("FREESTYLEGRID1PAGINATIONBAR.CHANGEPAGE",""","oparms":[{"av":"AV86FreeStyleGrid1CurrentPage","fld":"vFREESTYLEGRID1CURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV87FreeStyleGrid1PageCount","fld":"vFREESTYLEGRID1PAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"Freestylegrid1paginationbar_Rowsperpageselectedvalue","ctrl":"FREESTYLEGRID1PAGINATIONBAR","prop":"RowsPerPageSelectedValue"},{"av":"AV90TotalRows","fld":"vTOTALROWS","pic":"ZZZZZZZZZZZZZZZZZ9"},{"av":"AV100UsuariosFiltro","fld":"vUSUARIOSFILTRO"},{"av":"AV62ListaUsuarios","fld":"vLISTAUSUARIOS"}]}""");
         setEventMetadata("FREESTYLEGRID1PAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E154R2","iparms":[{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"FREESTYLEGRID1_nEOF"},{"av":"subFreestylegrid1_Rows","ctrl":"FREESTYLEGRID1","prop":"Rows"},{"av":"AV22FromDate","fld":"vFROMDATE"},{"av":"AV52ToDate","fld":"vTODATE"},{"av":"cmbavFacturaestatus"},{"av":"AV92FacturaEstatus","fld":"vFACTURAESTATUS"},{"av":"AV99FacturaNo","fld":"vFACTURANO"},{"av":"AV90TotalRows","fld":"vTOTALROWS","pic":"ZZZZZZZZZZZZZZZZZ9"},{"av":"AV117DoScroll","fld":"vDOSCROLL","hsh":true},{"av":"AV116KeepPage","fld":"vKEEPPAGE","pic":"ZZZ9","hsh":true},{"av":"AV95PromocionID","fld":"vPROMOCIONID"},{"av":"AV97UsuarioID","fld":"vUSUARIOID"},{"av":"AV100UsuariosFiltro","fld":"vUSUARIOSFILTRO"},{"av":"AV62ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV15DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"edtFacturaID_Visible","ctrl":"FACTURAID","prop":"Visible"},{"av":"cmbFacturaEstatus"},{"av":"edtUsuarioID_Visible","ctrl":"USUARIOID","prop":"Visible"},{"av":"edtMotivoRechazoActivo_Visible","ctrl":"MOTIVORECHAZOACTIVO","prop":"Visible"},{"av":"edtMotivoRechazoDescripcion_Visible","ctrl":"MOTIVORECHAZODESCRIPCION","prop":"Visible"},{"av":"edtMotivoRechazoID_Visible","ctrl":"MOTIVORECHAZOID","prop":"Visible"},{"av":"edtavMotivorechazo_Visible","ctrl":"vMOTIVORECHAZO","prop":"Visible"},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV127EnCola","fld":"vENCOLA"},{"av":"AV121Cambios","fld":"vCAMBIOS"},{"av":"AV19FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV37RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"Freestylegrid1paginationbar_Rowsperpageselectedvalue","ctrl":"FREESTYLEGRID1PAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("FREESTYLEGRID1PAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subFreestylegrid1_Rows","ctrl":"FREESTYLEGRID1","prop":"Rows"},{"av":"AV86FreeStyleGrid1CurrentPage","fld":"vFREESTYLEGRID1CURRENTPAGE","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("'DOCAMBIARESTATUS'","""{"handler":"E164R2","iparms":[{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"FREESTYLEGRID1_nEOF"},{"av":"subFreestylegrid1_Rows","ctrl":"FREESTYLEGRID1","prop":"Rows"},{"av":"AV22FromDate","fld":"vFROMDATE"},{"av":"AV52ToDate","fld":"vTODATE"},{"av":"cmbavFacturaestatus"},{"av":"AV92FacturaEstatus","fld":"vFACTURAESTATUS"},{"av":"AV99FacturaNo","fld":"vFACTURANO"},{"av":"AV90TotalRows","fld":"vTOTALROWS","pic":"ZZZZZZZZZZZZZZZZZ9"},{"av":"AV117DoScroll","fld":"vDOSCROLL","hsh":true},{"av":"AV116KeepPage","fld":"vKEEPPAGE","pic":"ZZZ9","hsh":true},{"av":"AV95PromocionID","fld":"vPROMOCIONID"},{"av":"AV97UsuarioID","fld":"vUSUARIOID"},{"av":"AV100UsuariosFiltro","fld":"vUSUARIOSFILTRO"},{"av":"AV62ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV15DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"edtFacturaID_Visible","ctrl":"FACTURAID","prop":"Visible"},{"av":"cmbFacturaEstatus"},{"av":"edtUsuarioID_Visible","ctrl":"USUARIOID","prop":"Visible"},{"av":"edtMotivoRechazoActivo_Visible","ctrl":"MOTIVORECHAZOACTIVO","prop":"Visible"},{"av":"edtMotivoRechazoDescripcion_Visible","ctrl":"MOTIVORECHAZODESCRIPCION","prop":"Visible"},{"av":"edtMotivoRechazoID_Visible","ctrl":"MOTIVORECHAZOID","prop":"Visible"},{"av":"edtavMotivorechazo_Visible","ctrl":"vMOTIVORECHAZO","prop":"Visible"},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV127EnCola","fld":"vENCOLA"},{"av":"AV121Cambios","fld":"vCAMBIOS"},{"av":"AV19FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV37RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA","hsh":true},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS","hsh":true},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A71FacturaNo","fld":"FACTURANO","hsh":true}]""");
         setEventMetadata("'DOCAMBIARESTATUS'",""","oparms":[{"av":"AV121Cambios","fld":"vCAMBIOS"},{"ctrl":"UTCHARTDOUGHNUT"},{"ctrl":"UTCHARTCOLUMNLINE"},{"av":"AV90TotalRows","fld":"vTOTALROWS","pic":"ZZZZZZZZZZZZZZZZZ9"},{"av":"AV100UsuariosFiltro","fld":"vUSUARIOSFILTRO"},{"av":"AV62ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV87FreeStyleGrid1PageCount","fld":"vFREESTYLEGRID1PAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV86FreeStyleGrid1CurrentPage","fld":"vFREESTYLEGRID1CURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"Freestylegrid1paginationbar_Rowsperpageselectedvalue","ctrl":"FREESTYLEGRID1PAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]}""");
         setEventMetadata("'DOESTATUSENPROCESOUSERACTION4'","""{"handler":"E224R2","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV5Blob","fld":"vBLOB"},{"av":"AV19FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"A75FacturaPDF","fld":"FACTURAPDF"}]""");
         setEventMetadata("'DOESTATUSENPROCESOUSERACTION4'",""","oparms":[{"av":"AV19FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV5Blob","fld":"vBLOB"}]}""");
         setEventMetadata("'DOALLESTATUSUSERACTION4'","""{"handler":"E234R2","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV5Blob","fld":"vBLOB"},{"av":"AV19FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"A75FacturaPDF","fld":"FACTURAPDF"}]""");
         setEventMetadata("'DOALLESTATUSUSERACTION4'",""","oparms":[{"av":"AV19FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV5Blob","fld":"vBLOB"}]}""");
         setEventMetadata("'DOUSERACTION99'","""{"handler":"E174R2","iparms":[{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"FREESTYLEGRID1_nEOF"},{"av":"subFreestylegrid1_Rows","ctrl":"FREESTYLEGRID1","prop":"Rows"},{"av":"AV22FromDate","fld":"vFROMDATE"},{"av":"AV52ToDate","fld":"vTODATE"},{"av":"cmbavFacturaestatus"},{"av":"AV92FacturaEstatus","fld":"vFACTURAESTATUS"},{"av":"AV99FacturaNo","fld":"vFACTURANO"},{"av":"AV90TotalRows","fld":"vTOTALROWS","pic":"ZZZZZZZZZZZZZZZZZ9"},{"av":"AV117DoScroll","fld":"vDOSCROLL","hsh":true},{"av":"AV116KeepPage","fld":"vKEEPPAGE","pic":"ZZZ9","hsh":true},{"av":"AV95PromocionID","fld":"vPROMOCIONID"},{"av":"AV97UsuarioID","fld":"vUSUARIOID"},{"av":"AV100UsuariosFiltro","fld":"vUSUARIOSFILTRO"},{"av":"AV62ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV15DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"edtFacturaID_Visible","ctrl":"FACTURAID","prop":"Visible"},{"av":"cmbFacturaEstatus"},{"av":"edtUsuarioID_Visible","ctrl":"USUARIOID","prop":"Visible"},{"av":"edtMotivoRechazoActivo_Visible","ctrl":"MOTIVORECHAZOACTIVO","prop":"Visible"},{"av":"edtMotivoRechazoDescripcion_Visible","ctrl":"MOTIVORECHAZODESCRIPCION","prop":"Visible"},{"av":"edtMotivoRechazoID_Visible","ctrl":"MOTIVORECHAZOID","prop":"Visible"},{"av":"edtavMotivorechazo_Visible","ctrl":"vMOTIVORECHAZO","prop":"Visible"},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"AV127EnCola","fld":"vENCOLA"},{"av":"AV121Cambios","fld":"vCAMBIOS"},{"av":"AV19FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV37RegUsuarioID","fld":"vREGUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA","hsh":true},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS","hsh":true},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A71FacturaNo","fld":"FACTURANO","hsh":true}]""");
         setEventMetadata("'DOUSERACTION99'",""","oparms":[{"ctrl":"UTCHARTDOUGHNUT"},{"ctrl":"UTCHARTCOLUMNLINE"},{"av":"AV90TotalRows","fld":"vTOTALROWS","pic":"ZZZZZZZZZZZZZZZZZ9"},{"av":"AV100UsuariosFiltro","fld":"vUSUARIOSFILTRO"},{"av":"AV62ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV87FreeStyleGrid1PageCount","fld":"vFREESTYLEGRID1PAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV86FreeStyleGrid1CurrentPage","fld":"vFREESTYLEGRID1CURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"Freestylegrid1paginationbar_Rowsperpageselectedvalue","ctrl":"FREESTYLEGRID1PAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]}""");
         setEventMetadata("'DOGENERAEXCEL'","""{"handler":"E184R2","iparms":[{"av":"AV22FromDate","fld":"vFROMDATE"},{"av":"AV52ToDate","fld":"vTODATE"},{"av":"AV100UsuariosFiltro","fld":"vUSUARIOSFILTRO"},{"av":"AV95PromocionID","fld":"vPROMOCIONID"},{"av":"AV99FacturaNo","fld":"vFACTURANO"},{"av":"cmbavFacturaestatus"},{"av":"AV92FacturaEstatus","fld":"vFACTURAESTATUS"},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA","hsh":true},{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS","hsh":true},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV97UsuarioID","fld":"vUSUARIOID"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A71FacturaNo","fld":"FACTURANO","hsh":true},{"av":"AV62ListaUsuarios","fld":"vLISTAUSUARIOS"},{"av":"AV15DistribuidorID","fld":"vDISTRIBUIDORID"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"}]""");
         setEventMetadata("'DOGENERAEXCEL'",""","oparms":[{"av":"AV90TotalRows","fld":"vTOTALROWS","pic":"ZZZZZZZZZZZZZZZZZ9"},{"av":"AV100UsuariosFiltro","fld":"vUSUARIOSFILTRO"},{"av":"AV62ListaUsuarios","fld":"vLISTAUSUARIOS"}]}""");
         setEventMetadata("COMBO_USUARIOID.ONOPTIONCLICKED","""{"handler":"E134R2","iparms":[{"av":"Combo_usuarioid_Selectedvalue_get","ctrl":"COMBO_USUARIOID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_USUARIOID.ONOPTIONCLICKED",""","oparms":[{"av":"AV97UsuarioID","fld":"vUSUARIOID"}]}""");
         setEventMetadata("COMBO_PROMOCIONID.ONOPTIONCLICKED","""{"handler":"E124R2","iparms":[{"av":"Combo_promocionid_Selectedvalue_get","ctrl":"COMBO_PROMOCIONID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_PROMOCIONID.ONOPTIONCLICKED",""","oparms":[{"av":"AV95PromocionID","fld":"vPROMOCIONID"}]}""");
         setEventMetadata("COMBO_DISTRIBUIDORID.ONOPTIONCLICKED","""{"handler":"E114R2","iparms":[{"av":"Combo_distribuidorid_Selectedvalue_get","ctrl":"COMBO_DISTRIBUIDORID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_DISTRIBUIDORID.ONOPTIONCLICKED",""","oparms":[{"av":"AV15DistribuidorID","fld":"vDISTRIBUIDORID"}]}""");
         setEventMetadata("'DOUSERACTION4'","""{"handler":"E244R2","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV5Blob","fld":"vBLOB"},{"av":"AV19FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"A75FacturaPDF","fld":"FACTURAPDF"}]""");
         setEventMetadata("'DOUSERACTION4'",""","oparms":[{"av":"AV19FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV5Blob","fld":"vBLOB"}]}""");
         setEventMetadata("VVARESTATUSADMIN.CONTROLVALUECHANGED","""{"handler":"E254R2","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9","hsh":true},{"av":"cmbavVarestatusadmin"},{"av":"AV105VarEstatusAdmin","fld":"vVARESTATUSADMIN"},{"av":"AV107MotivoRechazoID","fld":"vMOTIVORECHAZOID","pic":"ZZZZZZZZ9"},{"av":"AV121Cambios","fld":"vCAMBIOS"},{"av":"AV19FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV131SelEstatusAdmin","fld":"vSELESTATUSADMIN"},{"av":"AV132SelFacturaID","fld":"vSELFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV134SelFacturaEstatus","fld":"vSELFACTURAESTATUS"},{"av":"AV133SelMotivoRechazoID","fld":"vSELMOTIVORECHAZOID","pic":"ZZZZZZZZ9"},{"av":"A71FacturaNo","fld":"FACTURANO","hsh":true}]""");
         setEventMetadata("VVARESTATUSADMIN.CONTROLVALUECHANGED",""","oparms":[{"av":"AV132SelFacturaID","fld":"vSELFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV131SelEstatusAdmin","fld":"vSELESTATUSADMIN"},{"av":"AV133SelMotivoRechazoID","fld":"vSELMOTIVORECHAZOID","pic":"ZZZZZZZZ9"},{"av":"Combo_motivorechazoid_Visible","ctrl":"COMBO_MOTIVORECHAZOID","prop":"Visible"},{"av":"Combo_motivorechazoid_Enabled","ctrl":"COMBO_MOTIVORECHAZOID","prop":"Enabled"},{"av":"edtavMotivorechazoid_Visible","ctrl":"vMOTIVORECHAZOID","prop":"Visible"},{"av":"edtavMotivorechazoid_Enabled","ctrl":"vMOTIVORECHAZOID","prop":"Enabled"},{"av":"edtMotivoRechazoID_Visible","ctrl":"MOTIVORECHAZOID","prop":"Visible"},{"av":"edtMotivoRechazoID_Enabled","ctrl":"MOTIVORECHAZOID","prop":"Enabled"},{"av":"divEstatusenprocesotablemr_Visible","ctrl":"ESTATUSENPROCESOTABLEMR","prop":"Visible"},{"av":"AV121Cambios","fld":"vCAMBIOS"},{"av":"AV127EnCola","fld":"vENCOLA"},{"av":"AV134SelFacturaEstatus","fld":"vSELFACTURAESTATUS"}]}""");
         setEventMetadata("VMOTIVORECHAZOID.CONTROLVALUECHANGED","""{"handler":"E264R2","iparms":[{"av":"AV107MotivoRechazoID","fld":"vMOTIVORECHAZOID","pic":"ZZZZZZZZ9"},{"av":"cmbavVarestatusadmin"},{"av":"AV105VarEstatusAdmin","fld":"vVARESTATUSADMIN"},{"av":"AV121Cambios","fld":"vCAMBIOS"},{"av":"AV131SelEstatusAdmin","fld":"vSELESTATUSADMIN"},{"av":"AV132SelFacturaID","fld":"vSELFACTURAID","pic":"ZZZZZZZZ9"},{"av":"AV134SelFacturaEstatus","fld":"vSELFACTURAESTATUS"},{"av":"AV133SelMotivoRechazoID","fld":"vSELMOTIVORECHAZOID","pic":"ZZZZZZZZ9"},{"av":"A71FacturaNo","fld":"FACTURANO","hsh":true},{"av":"AV19FacturaID","fld":"vFACTURAID","pic":"ZZZZZZZZ9"}]""");
         setEventMetadata("VMOTIVORECHAZOID.CONTROLVALUECHANGED",""","oparms":[{"av":"AV133SelMotivoRechazoID","fld":"vSELMOTIVORECHAZOID","pic":"ZZZZZZZZ9"},{"av":"AV121Cambios","fld":"vCAMBIOS"},{"av":"AV127EnCola","fld":"vENCOLA"},{"av":"AV134SelFacturaEstatus","fld":"vSELFACTURAESTATUS"}]}""");
         setEventMetadata("VALIDV_FROMDATE","""{"handler":"Validv_Fromdate","iparms":[]}""");
         setEventMetadata("VALIDV_TODATE","""{"handler":"Validv_Todate","iparms":[]}""");
         setEventMetadata("VALIDV_FACTURAESTATUS","""{"handler":"Validv_Facturaestatus","iparms":[]}""");
         setEventMetadata("VALID_USUARIOID","""{"handler":"Valid_Usuarioid","iparms":[]}""");
         setEventMetadata("VALID_MOTIVORECHAZOID","""{"handler":"Valid_Motivorechazoid","iparms":[]}""");
         setEventMetadata("VALIDV_VARESTATUS","""{"handler":"Validv_Varestatus","iparms":[]}""");
         setEventMetadata("VALIDV_VARESTATUSADMIN","""{"handler":"Validv_Varestatusadmin","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Motivorechazoid","iparms":[]}""");
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
         Freestylegrid1paginationbar_Selectedpage = "";
         Combo_usuarioid_Selectedvalue_get = "";
         Combo_promocionid_Selectedvalue_get = "";
         Combo_distribuidorid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV22FromDate = DateTime.MinValue;
         AV52ToDate = DateTime.MinValue;
         AV92FacturaEstatus = "En Proceso";
         AV99FacturaNo = "";
         AV95PromocionID = new GxSimpleCollection<int>();
         AV97UsuarioID = new GxSimpleCollection<int>();
         AV100UsuariosFiltro = new GxSimpleCollection<int>();
         AV62ListaUsuarios = new GxSimpleCollection<int>();
         AV15DistribuidorID = new GxSimpleCollection<int>();
         A40UsuarioRol = "";
         A11DistribuidorDescripcion = "";
         AV121Cambios = new GXBaseCollection<SdtSDTCambioEstatus_SDTCambioEstatusItem>( context, "SDTCambioEstatusItem", "Premios");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV12DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV16DistribuidorID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV96PromocionID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV98UsuarioID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV72Elements = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         AV73Parameters = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter>( context, "Parameter", "GeneXus.Reporting");
         AV74ItemClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData(context);
         AV75ItemDoubleClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData(context);
         AV76DragAndDropData = new GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData(context);
         AV77FilterChangedData = new GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData(context);
         AV78ItemExpandData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData(context);
         AV79ItemCollapseData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData(context);
         AV88FreeStyleGrid1AppliedFilters = "";
         AV108MotivoRechazoID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV5Blob = "";
         A75FacturaPDF = "";
         AV131SelEstatusAdmin = "";
         AV134SelFacturaEstatus = "En Proceso";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         Combo_distribuidorid_Selectedvalue_set = "";
         Combo_promocionid_Selectedvalue_set = "";
         Combo_usuarioid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblTextblockcombo_distribuidorid_Jsonclick = "";
         ucCombo_distribuidorid = new GXUserControl();
         lblTextblockcombo_promocionid_Jsonclick = "";
         ucCombo_promocionid = new GXUserControl();
         lblTextblockcombo_usuarioid_Jsonclick = "";
         ucCombo_usuarioid = new GXUserControl();
         bttBtnuseraction99_Jsonclick = "";
         imgGeneraexcel_gximage = "";
         sImgUrl = "";
         imgGeneraexcel_Jsonclick = "";
         ucUtchartdoughnut = new GXUserControl();
         ucUtchartcolumnline = new GXUserControl();
         Freestylegrid1Container = new GXWebGrid( context);
         sStyleString = "";
         ucFreestylegrid1paginationbar = new GXUserControl();
         bttBtncambiarestatus_Jsonclick = "";
         ucCombo_motivorechazoid = new GXUserControl();
         Combo_motivorechazoid_Caption = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A80FacturaEstatus = "";
         A20MotivoRechazoDescripcion = "";
         A52UsuarioNombreCompleto = "";
         A72FacturaFechaRegistro = DateTime.MinValue;
         A42PromocionDescripcion = "";
         A71FacturaNo = "";
         A73FacturaFechaFactura = DateTime.MinValue;
         AV85DistribuidorDescripcion = "";
         AV103VarEstatus = "";
         AV111MotivoRechazo = "";
         AV105VarEstatusAdmin = "";
         OldAllestatuswebcomponent1 = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         OldEstatusenprocesowebcomponent1 = "";
         WebComp_Allestatuswebcomponent1_Component = "";
         WebComp_Estatusenprocesowebcomponent1_Component = "";
         H004R2_A41PromocionID = new int[1] ;
         H004R2_A93FacturaCompleta = new bool[] {false} ;
         H004R2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         H004R2_A71FacturaNo = new string[] {""} ;
         H004R2_A42PromocionDescripcion = new string[] {""} ;
         H004R2_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         H004R2_A19MotivoRechazoID = new int[1] ;
         H004R2_A20MotivoRechazoDescripcion = new string[] {""} ;
         H004R2_A21MotivoRechazoActivo = new bool[] {false} ;
         H004R2_A29UsuarioID = new int[1] ;
         H004R2_A80FacturaEstatus = new string[] {""} ;
         H004R2_A69FacturaID = new int[1] ;
         H004R2_A51UsuarioApellido = new string[] {""} ;
         H004R2_A30UsuarioNombre = new string[] {""} ;
         H004R3_AFREESTYLEGRID1_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         H004R4_A10DistribuidorID = new int[1] ;
         H004R4_A29UsuarioID = new int[1] ;
         H004R4_A11DistribuidorDescripcion = new string[] {""} ;
         H004R4_A81DistribuidoresUsuarioID = new int[1] ;
         Freestylegrid1Row = new GXWebRow();
         AV122c = new SdtSDTCambioEstatus_SDTCambioEstatusItem(context);
         AV129Tmp = new GXBaseCollection<SdtSDTCambioEstatus_SDTCambioEstatusItem>( context, "SDTCambioEstatusItem", "Premios");
         AV20FileURL = "";
         AV110Fragment = "";
         AV109JS = "";
         AV118ExcelFilename = "";
         H004R5_A19MotivoRechazoID = new int[1] ;
         H004R5_A20MotivoRechazoDescripcion = new string[] {""} ;
         AV9Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         H004R6_A40UsuarioRol = new string[] {""} ;
         H004R6_A29UsuarioID = new int[1] ;
         H004R6_A52UsuarioNombreCompleto = new string[] {""} ;
         H004R6_A30UsuarioNombre = new string[] {""} ;
         H004R6_A51UsuarioApellido = new string[] {""} ;
         H004R7_A41PromocionID = new int[1] ;
         H004R7_A42PromocionDescripcion = new string[] {""} ;
         H004R8_A10DistribuidorID = new int[1] ;
         H004R8_A11DistribuidorDescripcion = new string[] {""} ;
         H004R9_A81DistribuidoresUsuarioID = new int[1] ;
         H004R9_A40UsuarioRol = new string[] {""} ;
         H004R9_A29UsuarioID = new int[1] ;
         H004R10_A81DistribuidoresUsuarioID = new int[1] ;
         H004R10_A40UsuarioRol = new string[] {""} ;
         H004R10_A10DistribuidorID = new int[1] ;
         H004R10_A29UsuarioID = new int[1] ;
         H004R11_AV90TotalRows = new long[1] ;
         H004R12_A69FacturaID = new int[1] ;
         H004R12_A40000FacturaPDF_GXI = new string[] {""} ;
         H004R12_A75FacturaPDF = new string[] {""} ;
         A40000FacturaPDF_GXI = "";
         AV124item = new SdtSDTCambioEstatus_SDTCambioEstatusItem(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subFreestylegrid1_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         lblAllestatusrowanchor_Jsonclick = "";
         lblAllestatusemptytb_Jsonclick = "";
         imgAllestatususeraction4_gximage = "";
         imgAllestatususeraction4_Jsonclick = "";
         lblEstatusenprocesorowanchor_Jsonclick = "";
         lblEstatusenprocesoemptytb_Jsonclick = "";
         imgEstatusenprocesouseraction4_gximage = "";
         imgEstatusenprocesouseraction4_Jsonclick = "";
         lblEstatusenprocesotextblock2_Jsonclick = "";
         lblEstatusenprocesotextblock3_Jsonclick = "";
         lblEstatusenprocesotextblock4_Jsonclick = "";
         lblEstatusenprocesotextblock5_Jsonclick = "";
         lblEstatusenprocesotextblock6_Jsonclick = "";
         lblEstatusenprocesotextblock7_Jsonclick = "";
         lblEstatusenprocesotextblock8_Jsonclick = "";
         lblEstatusenprocesotextblock9_Jsonclick = "";
         subFreestylegrid1_Header = "";
         Freestylegrid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpfacturasnew__default(),
            new Object[][] {
                new Object[] {
               H004R2_A41PromocionID, H004R2_A93FacturaCompleta, H004R2_A73FacturaFechaFactura, H004R2_A71FacturaNo, H004R2_A42PromocionDescripcion, H004R2_A72FacturaFechaRegistro, H004R2_A19MotivoRechazoID, H004R2_A20MotivoRechazoDescripcion, H004R2_A21MotivoRechazoActivo, H004R2_A29UsuarioID,
               H004R2_A80FacturaEstatus, H004R2_A69FacturaID, H004R2_A51UsuarioApellido, H004R2_A30UsuarioNombre
               }
               , new Object[] {
               H004R3_AFREESTYLEGRID1_nRecordCount
               }
               , new Object[] {
               H004R4_A10DistribuidorID, H004R4_A29UsuarioID, H004R4_A11DistribuidorDescripcion, H004R4_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               H004R5_A19MotivoRechazoID, H004R5_A20MotivoRechazoDescripcion
               }
               , new Object[] {
               H004R6_A40UsuarioRol, H004R6_A29UsuarioID, H004R6_A52UsuarioNombreCompleto, H004R6_A30UsuarioNombre, H004R6_A51UsuarioApellido
               }
               , new Object[] {
               H004R7_A41PromocionID, H004R7_A42PromocionDescripcion
               }
               , new Object[] {
               H004R8_A10DistribuidorID, H004R8_A11DistribuidorDescripcion
               }
               , new Object[] {
               H004R9_A81DistribuidoresUsuarioID, H004R9_A40UsuarioRol, H004R9_A29UsuarioID
               }
               , new Object[] {
               H004R10_A81DistribuidoresUsuarioID, H004R10_A40UsuarioRol, H004R10_A10DistribuidorID, H004R10_A29UsuarioID
               }
               , new Object[] {
               H004R11_AV90TotalRows
               }
               , new Object[] {
               H004R12_A69FacturaID, H004R12_A40000FacturaPDF_GXI, H004R12_A75FacturaPDF
               }
            }
         );
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Allestatuswebcomponent1 = new GeneXus.Http.GXNullWebComponent();
         WebComp_Estatusenprocesowebcomponent1 = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavDistribuidordescripcion_Enabled = 0;
         cmbavVarestatus.Enabled = 0;
         edtavMotivorechazo_Enabled = 0;
      }

      private short FREESTYLEGRID1_nEOF ;
      private short nRcdExists_11 ;
      private short nIsMod_11 ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
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
      private short AV116KeepPage ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subFreestylegrid1_Backcolorstyle ;
      private short AV128OK ;
      private short AV102Caso ;
      private short nGXWrapped ;
      private short subFreestylegrid1_Backstyle ;
      private short subFreestylegrid1_Allowselection ;
      private short subFreestylegrid1_Allowhovering ;
      private short subFreestylegrid1_Allowcollapsing ;
      private short subFreestylegrid1_Collapsed ;
      private int edtFacturaID_Visible ;
      private int edtUsuarioID_Visible ;
      private int edtMotivoRechazoActivo_Visible ;
      private int edtMotivoRechazoDescripcion_Visible ;
      private int edtMotivoRechazoID_Visible ;
      private int edtavMotivorechazo_Visible ;
      private int subFreestylegrid1_Rows ;
      private int Freestylegrid1paginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_72 ;
      private int nGXsfl_72_idx=1 ;
      private int A10DistribuidorID ;
      private int A81DistribuidoresUsuarioID ;
      private int AV19FacturaID ;
      private int AV37RegUsuarioID ;
      private int A41PromocionID ;
      private int AV132SelFacturaID ;
      private int AV133SelMotivoRechazoID ;
      private int Freestylegrid1paginationbar_Pagestoshow ;
      private int edtavFromdate_Enabled ;
      private int edtavTodate_Enabled ;
      private int edtavFacturano_Enabled ;
      private int edtavFreestylegrid1currentpage_Visible ;
      private int A69FacturaID ;
      private int A29UsuarioID ;
      private int A19MotivoRechazoID ;
      private int AV107MotivoRechazoID ;
      private int nGXsfl_72_webc_idx=0 ;
      private int subFreestylegrid1_Islastpage ;
      private int edtavDistribuidordescripcion_Enabled ;
      private int edtavMotivorechazo_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV100UsuariosFiltro_Count ;
      private int AV95PromocionID_Count ;
      private int edtFacturaID_Enabled ;
      private int edtUsuarioID_Enabled ;
      private int edtMotivoRechazoActivo_Enabled ;
      private int edtMotivoRechazoDescripcion_Enabled ;
      private int edtMotivoRechazoID_Enabled ;
      private int edtUsuarioNombreCompleto_Enabled ;
      private int edtFacturaFechaRegistro_Enabled ;
      private int edtPromocionDescripcion_Enabled ;
      private int edtFacturaNo_Enabled ;
      private int edtFacturaFechaFactura_Enabled ;
      private int edtavMotivorechazoid_Visible ;
      private int edtavMotivorechazoid_Enabled ;
      private int divEstatusenprocesotablemr_Visible ;
      private int divAllestatustablecell_Visible ;
      private int divEstatusenprocesotablecell_Visible ;
      private int AV34PageToGo ;
      private int AV137GXV1 ;
      private int AV138GXV2 ;
      private int AV144GXV3 ;
      private int AV64UsuariosListaID ;
      private int AV146GXV4 ;
      private int AV97UsuarioID_Count ;
      private int AV148GXV5 ;
      private int AV101u ;
      private int AV149GXV6 ;
      private int AV151GXV7 ;
      private int AV152GXV8 ;
      private int idxLst ;
      private int subFreestylegrid1_Backcolor ;
      private int subFreestylegrid1_Allbackcolor ;
      private int subFreestylegrid1_Selectedindex ;
      private int subFreestylegrid1_Selectioncolor ;
      private int subFreestylegrid1_Hoveringcolor ;
      private long FREESTYLEGRID1_nFirstRecordOnPage ;
      private long AV90TotalRows ;
      private long AV87FreeStyleGrid1PageCount ;
      private long AV86FreeStyleGrid1CurrentPage ;
      private long FREESTYLEGRID1_nCurrentRecord ;
      private long FREESTYLEGRID1_nRecordCount ;
      private long AV125CambiosCount ;
      private long cV90TotalRows ;
      private long AV126Idx ;
      private string Freestylegrid1paginationbar_Selectedpage ;
      private string Combo_usuarioid_Selectedvalue_get ;
      private string Combo_promocionid_Selectedvalue_get ;
      private string Combo_distribuidorid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_72_idx="0001" ;
      private string edtFacturaID_Internalname ;
      private string cmbFacturaEstatus_Internalname ;
      private string edtUsuarioID_Internalname ;
      private string edtMotivoRechazoActivo_Internalname ;
      private string edtMotivoRechazoDescripcion_Internalname ;
      private string edtMotivoRechazoID_Internalname ;
      private string edtavMotivorechazo_Internalname ;
      private string AV92FacturaEstatus ;
      private string AV99FacturaNo ;
      private string A40UsuarioRol ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV131SelEstatusAdmin ;
      private string AV134SelFacturaEstatus ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
      private string Combo_distribuidorid_Cls ;
      private string Combo_distribuidorid_Selectedvalue_set ;
      private string Combo_distribuidorid_Multiplevaluestype ;
      private string Combo_promocionid_Cls ;
      private string Combo_promocionid_Selectedvalue_set ;
      private string Combo_promocionid_Multiplevaluestype ;
      private string Combo_usuarioid_Cls ;
      private string Combo_usuarioid_Selectedvalue_set ;
      private string Combo_usuarioid_Multiplevaluestype ;
      private string Utchartdoughnut_Objectcall ;
      private string Utchartdoughnut_Type ;
      private string Utchartdoughnut_Title ;
      private string Utchartdoughnut_Charttype ;
      private string Utchartcolumnline_Objectcall ;
      private string Utchartcolumnline_Type ;
      private string Utchartcolumnline_Title ;
      private string Freestylegrid1paginationbar_Class ;
      private string Freestylegrid1paginationbar_Pagingbuttonsposition ;
      private string Freestylegrid1paginationbar_Pagingcaptionposition ;
      private string Freestylegrid1paginationbar_Emptygridclass ;
      private string Freestylegrid1paginationbar_Rowsperpageoptions ;
      private string Freestylegrid1paginationbar_Previous ;
      private string Freestylegrid1paginationbar_Next ;
      private string Freestylegrid1paginationbar_Caption ;
      private string Freestylegrid1paginationbar_Emptygridcaption ;
      private string Freestylegrid1paginationbar_Rowsperpagecaption ;
      private string Combo_motivorechazoid_Cls ;
      private string Combo_motivorechazoid_Titlecontrolidtoreplace ;
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
      private string cmbavFacturaestatus_Internalname ;
      private string cmbavFacturaestatus_Jsonclick ;
      private string edtavFacturano_Internalname ;
      private string edtavFacturano_Jsonclick ;
      private string divTablesplitteddistribuidorid_Internalname ;
      private string lblTextblockcombo_distribuidorid_Internalname ;
      private string lblTextblockcombo_distribuidorid_Jsonclick ;
      private string Combo_distribuidorid_Caption ;
      private string Combo_distribuidorid_Internalname ;
      private string divTablesplittedpromocionid_Internalname ;
      private string lblTextblockcombo_promocionid_Internalname ;
      private string lblTextblockcombo_promocionid_Jsonclick ;
      private string Combo_promocionid_Caption ;
      private string Combo_promocionid_Internalname ;
      private string divTablesplittedusuarioid_Internalname ;
      private string lblTextblockcombo_usuarioid_Internalname ;
      private string lblTextblockcombo_usuarioid_Jsonclick ;
      private string Combo_usuarioid_Caption ;
      private string Combo_usuarioid_Internalname ;
      private string bttBtnuseraction99_Internalname ;
      private string bttBtnuseraction99_Jsonclick ;
      private string imgGeneraexcel_gximage ;
      private string sImgUrl ;
      private string imgGeneraexcel_Internalname ;
      private string imgGeneraexcel_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string Utchartdoughnut_Internalname ;
      private string Utchartcolumnline_Internalname ;
      private string divFreestylegrid1tablewithpaging_Internalname ;
      private string sStyleString ;
      private string subFreestylegrid1_Internalname ;
      private string Freestylegrid1paginationbar_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string bttBtncambiarestatus_Internalname ;
      private string bttBtncambiarestatus_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Combo_motivorechazoid_Caption ;
      private string Combo_motivorechazoid_Internalname ;
      private string edtavFreestylegrid1currentpage_Internalname ;
      private string edtavFreestylegrid1currentpage_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string A80FacturaEstatus ;
      private string edtUsuarioNombreCompleto_Internalname ;
      private string edtFacturaFechaRegistro_Internalname ;
      private string edtPromocionDescripcion_Internalname ;
      private string A71FacturaNo ;
      private string edtFacturaNo_Internalname ;
      private string edtFacturaFechaFactura_Internalname ;
      private string edtavDistribuidordescripcion_Internalname ;
      private string cmbavVarestatus_Internalname ;
      private string AV103VarEstatus ;
      private string cmbavVarestatusadmin_Internalname ;
      private string AV105VarEstatusAdmin ;
      private string edtavMotivorechazoid_Internalname ;
      private string OldAllestatuswebcomponent1 ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string OldEstatusenprocesowebcomponent1 ;
      private string WebComp_Allestatuswebcomponent1_Component ;
      private string WebComp_Estatusenprocesowebcomponent1_Component ;
      private string divEstatusenprocesotablemr_Internalname ;
      private string divMotivorechazo_cell_Class ;
      private string divMotivorechazo_cell_Internalname ;
      private string divEstatusenprocesotablestatusstrip_Class ;
      private string divEstatusenprocesotablestatusstrip_Internalname ;
      private string divAllestatustablestatusstrip_Class ;
      private string divAllestatustablestatusstrip_Internalname ;
      private string divAllestatustablecell_Internalname ;
      private string divEstatusenprocesotablecell_Internalname ;
      private string AV110Fragment ;
      private string lblAllestatusrowanchor_Internalname ;
      private string lblAllestatusemptytb_Internalname ;
      private string imgAllestatususeraction4_Internalname ;
      private string lblEstatusenprocesorowanchor_Internalname ;
      private string lblEstatusenprocesoemptytb_Internalname ;
      private string imgEstatusenprocesouseraction4_Internalname ;
      private string lblEstatusenprocesotextblock2_Internalname ;
      private string lblEstatusenprocesotextblock3_Internalname ;
      private string lblEstatusenprocesotextblock4_Internalname ;
      private string lblEstatusenprocesotextblock5_Internalname ;
      private string lblEstatusenprocesotextblock6_Internalname ;
      private string lblEstatusenprocesotextblock7_Internalname ;
      private string lblEstatusenprocesotextblock8_Internalname ;
      private string lblEstatusenprocesotextblock9_Internalname ;
      private string sGXsfl_72_fel_idx="0001" ;
      private string subFreestylegrid1_Class ;
      private string subFreestylegrid1_Linesclass ;
      private string divFreestylegrid1layouttable_Internalname ;
      private string tblUnnamedtablecontentfsfreestylegrid1_Internalname ;
      private string ROClassString ;
      private string edtFacturaID_Jsonclick ;
      private string GXCCtl ;
      private string cmbFacturaEstatus_Jsonclick ;
      private string edtUsuarioID_Jsonclick ;
      private string edtMotivoRechazoActivo_Jsonclick ;
      private string edtMotivoRechazoDescripcion_Jsonclick ;
      private string edtMotivoRechazoID_Jsonclick ;
      private string divAllestatustable_Internalname ;
      private string divAllestatustablepanel_Internalname ;
      private string lblAllestatusrowanchor_Jsonclick ;
      private string lblAllestatusemptytb_Jsonclick ;
      private string imgAllestatususeraction4_gximage ;
      private string imgAllestatususeraction4_Jsonclick ;
      private string edtUsuarioNombreCompleto_Jsonclick ;
      private string edtFacturaFechaRegistro_Jsonclick ;
      private string edtPromocionDescripcion_Jsonclick ;
      private string edtFacturaNo_Jsonclick ;
      private string edtFacturaFechaFactura_Jsonclick ;
      private string edtavDistribuidordescripcion_Jsonclick ;
      private string cmbavVarestatus_Jsonclick ;
      private string edtavMotivorechazo_Jsonclick ;
      private string divEstatusenprocesotable_Internalname ;
      private string divEstatusenprocesotablepanel_Internalname ;
      private string lblEstatusenprocesorowanchor_Jsonclick ;
      private string lblEstatusenprocesoemptytb_Jsonclick ;
      private string imgEstatusenprocesouseraction4_gximage ;
      private string imgEstatusenprocesouseraction4_Jsonclick ;
      private string divEstatusenprocesotablelabel1_Internalname ;
      private string lblEstatusenprocesotextblock2_Jsonclick ;
      private string lblEstatusenprocesotextblock3_Jsonclick ;
      private string lblEstatusenprocesotextblock4_Jsonclick ;
      private string lblEstatusenprocesotextblock5_Jsonclick ;
      private string divEstatusenprocesotablelabel2_Internalname ;
      private string lblEstatusenprocesotextblock6_Jsonclick ;
      private string lblEstatusenprocesotextblock7_Jsonclick ;
      private string lblEstatusenprocesotextblock8_Jsonclick ;
      private string lblEstatusenprocesotextblock9_Jsonclick ;
      private string cmbavVarestatusadmin_Jsonclick ;
      private string edtavMotivorechazoid_Jsonclick ;
      private string subFreestylegrid1_Header ;
      private string lblAllestatusrowanchor_Caption ;
      private string lblEstatusenprocesotextblock2_Caption ;
      private string lblEstatusenprocesotextblock3_Caption ;
      private string lblEstatusenprocesotextblock4_Caption ;
      private string lblEstatusenprocesotextblock5_Caption ;
      private string lblEstatusenprocesotextblock6_Caption ;
      private string lblEstatusenprocesotextblock7_Caption ;
      private string lblEstatusenprocesotextblock8_Caption ;
      private string lblEstatusenprocesotextblock9_Caption ;
      private DateTime AV22FromDate ;
      private DateTime AV52ToDate ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A73FacturaFechaFactura ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_72_Refreshing=false ;
      private bool AV117DoScroll ;
      private bool AV127EnCola ;
      private bool Combo_distribuidorid_Allowmultipleselection ;
      private bool Combo_distribuidorid_Includeonlyselectedoption ;
      private bool Combo_distribuidorid_Emptyitem ;
      private bool Combo_promocionid_Allowmultipleselection ;
      private bool Combo_promocionid_Includeonlyselectedoption ;
      private bool Combo_usuarioid_Allowmultipleselection ;
      private bool Combo_usuarioid_Includeonlyselectedoption ;
      private bool Utchartdoughnut_Showvalues ;
      private bool Freestylegrid1paginationbar_Showfirst ;
      private bool Freestylegrid1paginationbar_Showprevious ;
      private bool Freestylegrid1paginationbar_Shownext ;
      private bool Freestylegrid1paginationbar_Showlast ;
      private bool Freestylegrid1paginationbar_Rowsperpageselector ;
      private bool Combo_motivorechazoid_Enabled ;
      private bool Combo_motivorechazoid_Visible ;
      private bool Combo_motivorechazoid_Isgriditem ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool A21MotivoRechazoActivo ;
      private bool gxdyncontrolsrefreshing ;
      private bool A93FacturaCompleta ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Estatusenprocesowebcomponent1 ;
      private bool bDynCreated_Allestatuswebcomponent1 ;
      private bool AV63Pasa ;
      private bool AV112EsRechazada ;
      private bool AV113CambiarEstatus ;
      private bool AV120Found ;
      private string AV109JS ;
      private string A11DistribuidorDescripcion ;
      private string AV88FreeStyleGrid1AppliedFilters ;
      private string A20MotivoRechazoDescripcion ;
      private string A52UsuarioNombreCompleto ;
      private string A42PromocionDescripcion ;
      private string AV85DistribuidorDescripcion ;
      private string AV111MotivoRechazo ;
      private string AV20FileURL ;
      private string AV118ExcelFilename ;
      private string A40000FacturaPDF_GXI ;
      private string A75FacturaPDF ;
      private string AV5Blob ;
      private GXWebComponent WebComp_Allestatuswebcomponent1 ;
      private GXWebComponent WebComp_Estatusenprocesowebcomponent1 ;
      private GXWebGrid Freestylegrid1Container ;
      private GXWebRow Freestylegrid1Row ;
      private GXWebColumn Freestylegrid1Column ;
      private GXUserControl ucCombo_distribuidorid ;
      private GXUserControl ucCombo_promocionid ;
      private GXUserControl ucCombo_usuarioid ;
      private GXUserControl ucUtchartdoughnut ;
      private GXUserControl ucUtchartcolumnline ;
      private GXUserControl ucFreestylegrid1paginationbar ;
      private GXUserControl ucCombo_motivorechazoid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavFacturaestatus ;
      private GXCombobox cmbFacturaEstatus ;
      private GXCombobox cmbavVarestatus ;
      private GXCombobox cmbavVarestatusadmin ;
      private GxSimpleCollection<int> AV95PromocionID ;
      private GxSimpleCollection<int> AV97UsuarioID ;
      private GxSimpleCollection<int> AV100UsuariosFiltro ;
      private GxSimpleCollection<int> AV62ListaUsuarios ;
      private GxSimpleCollection<int> AV15DistribuidorID ;
      private GXBaseCollection<SdtSDTCambioEstatus_SDTCambioEstatusItem> AV121Cambios ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV12DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV16DistribuidorID_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV96PromocionID_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV98UsuarioID_Data ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV72Elements ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter> AV73Parameters ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData AV74ItemClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData AV75ItemDoubleClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData AV76DragAndDropData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData AV77FilterChangedData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData AV78ItemExpandData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData AV79ItemCollapseData ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV108MotivoRechazoID_Data ;
      private GXWebComponent WebComp_GX_Process ;
      private IDataStoreProvider pr_default ;
      private int[] H004R2_A41PromocionID ;
      private bool[] H004R2_A93FacturaCompleta ;
      private DateTime[] H004R2_A73FacturaFechaFactura ;
      private string[] H004R2_A71FacturaNo ;
      private string[] H004R2_A42PromocionDescripcion ;
      private DateTime[] H004R2_A72FacturaFechaRegistro ;
      private int[] H004R2_A19MotivoRechazoID ;
      private string[] H004R2_A20MotivoRechazoDescripcion ;
      private bool[] H004R2_A21MotivoRechazoActivo ;
      private int[] H004R2_A29UsuarioID ;
      private string[] H004R2_A80FacturaEstatus ;
      private int[] H004R2_A69FacturaID ;
      private string[] H004R2_A51UsuarioApellido ;
      private string[] H004R2_A30UsuarioNombre ;
      private long[] H004R3_AFREESTYLEGRID1_nRecordCount ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private int[] H004R4_A10DistribuidorID ;
      private int[] H004R4_A29UsuarioID ;
      private string[] H004R4_A11DistribuidorDescripcion ;
      private int[] H004R4_A81DistribuidoresUsuarioID ;
      private SdtSDTCambioEstatus_SDTCambioEstatusItem AV122c ;
      private GXBaseCollection<SdtSDTCambioEstatus_SDTCambioEstatusItem> AV129Tmp ;
      private int[] H004R5_A19MotivoRechazoID ;
      private string[] H004R5_A20MotivoRechazoDescripcion ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV9Combo_DataItem ;
      private string[] H004R6_A40UsuarioRol ;
      private int[] H004R6_A29UsuarioID ;
      private string[] H004R6_A52UsuarioNombreCompleto ;
      private string[] H004R6_A30UsuarioNombre ;
      private string[] H004R6_A51UsuarioApellido ;
      private int[] H004R7_A41PromocionID ;
      private string[] H004R7_A42PromocionDescripcion ;
      private int[] H004R8_A10DistribuidorID ;
      private string[] H004R8_A11DistribuidorDescripcion ;
      private int[] H004R9_A81DistribuidoresUsuarioID ;
      private string[] H004R9_A40UsuarioRol ;
      private int[] H004R9_A29UsuarioID ;
      private int[] H004R10_A81DistribuidoresUsuarioID ;
      private string[] H004R10_A40UsuarioRol ;
      private int[] H004R10_A10DistribuidorID ;
      private int[] H004R10_A29UsuarioID ;
      private long[] H004R11_AV90TotalRows ;
      private int[] H004R12_A69FacturaID ;
      private string[] H004R12_A40000FacturaPDF_GXI ;
      private string[] H004R12_A75FacturaPDF ;
      private SdtSDTCambioEstatus_SDTCambioEstatusItem AV124item ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpfacturasnew__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004R2( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV100UsuariosFiltro ,
                                             int A41PromocionID ,
                                             GxSimpleCollection<int> AV95PromocionID ,
                                             DateTime AV22FromDate ,
                                             DateTime AV52ToDate ,
                                             int AV100UsuariosFiltro_Count ,
                                             string AV92FacturaEstatus ,
                                             int AV95PromocionID_Count ,
                                             string AV99FacturaNo ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             string A71FacturaNo ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.`PromocionID`, T1.`FacturaCompleta`, T1.`FacturaFechaFactura`, T1.`FacturaNo`, T2.`PromocionDescripcion`, T1.`FacturaFechaRegistro`, T1.`MotivoRechazoID`, T3.`MotivoRechazoDescripcion`, T3.`MotivoRechazoActivo`, T1.`UsuarioID`, T1.`FacturaEstatus`, T1.`FacturaID`, T4.`UsuarioApellido`, T4.`UsuarioNombre`";
         sFromString = " FROM (((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `MotivoRechazo` T3 ON T3.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! (DateTime.MinValue==AV22FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV22FromDate)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV52ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV52ToDate)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV100UsuariosFiltro_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV100UsuariosFiltro, "T1.`UsuarioID` IN (", ")")+")");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92FacturaEstatus)) )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = @AV92FacturaEstatus)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV95PromocionID_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV95PromocionID, "T1.`PromocionID` IN (", ")")+")");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99FacturaNo)) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV99FacturaNo)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         sOrderString += " ORDER BY T1.`FacturaID`";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " LIMIT " + "@GXPagingFrom2" + ", " + "@GXPagingTo2";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H004R3( IGxContext context ,
                                             int A29UsuarioID ,
                                             GxSimpleCollection<int> AV100UsuariosFiltro ,
                                             int A41PromocionID ,
                                             GxSimpleCollection<int> AV95PromocionID ,
                                             DateTime AV22FromDate ,
                                             DateTime AV52ToDate ,
                                             int AV100UsuariosFiltro_Count ,
                                             string AV92FacturaEstatus ,
                                             int AV95PromocionID_Count ,
                                             string AV99FacturaNo ,
                                             DateTime A73FacturaFechaFactura ,
                                             string A80FacturaEstatus ,
                                             string A71FacturaNo ,
                                             bool A93FacturaCompleta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((`Factura` T1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = T1.`PromocionID`) INNER JOIN `MotivoRechazo` T3 ON T3.`MotivoRechazoID` = T1.`MotivoRechazoID`) INNER JOIN `Usuario` T4 ON T4.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "(T1.`FacturaCompleta` = 1)");
         if ( ! (DateTime.MinValue==AV22FromDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` >= @AV22FromDate)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV52ToDate) )
         {
            AddWhere(sWhereString, "(T1.`FacturaFechaFactura` <= @AV52ToDate)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV100UsuariosFiltro_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV100UsuariosFiltro, "T1.`UsuarioID` IN (", ")")+")");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92FacturaEstatus)) )
         {
            AddWhere(sWhereString, "(T1.`FacturaEstatus` = @AV92FacturaEstatus)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV95PromocionID_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV95PromocionID, "T1.`PromocionID` IN (", ")")+")");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99FacturaNo)) )
         {
            AddWhere(sWhereString, "(T1.`FacturaNo` = @AV99FacturaNo)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H004R10( IGxContext context ,
                                              int A10DistribuidorID ,
                                              GxSimpleCollection<int> AV15DistribuidorID ,
                                              string A40UsuarioRol )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.`DistribuidoresUsuarioID`, T2.`UsuarioRol`, T1.`DistribuidorID`, T1.`UsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = T1.`UsuarioID`)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV15DistribuidorID, "T1.`DistribuidorID` IN (", ")")+")");
         AddWhere(sWhereString, "(T2.`UsuarioRol` = 'Participante')");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`DistribuidoresUsuarioID`";
         GXv_Object6[0] = scmdbuf;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H004R11( IGxContext context ,
                                              int A41PromocionID ,
                                              GxSimpleCollection<int> AV95PromocionID ,
                                              int A29UsuarioID ,
                                              GxSimpleCollection<int> AV100UsuariosFiltro ,
                                              DateTime AV22FromDate ,
                                              DateTime AV52ToDate ,
                                              string AV92FacturaEstatus ,
                                              int AV95PromocionID_Count ,
                                              int AV97UsuarioID_Count ,
                                              string AV99FacturaNo ,
                                              DateTime A73FacturaFechaFactura ,
                                              string A80FacturaEstatus ,
                                              string A71FacturaNo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[4];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM `Factura`";
         if ( ! (DateTime.MinValue==AV22FromDate) )
         {
            AddWhere(sWhereString, "(`FacturaFechaFactura` >= @AV22FromDate)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV52ToDate) )
         {
            AddWhere(sWhereString, "(`FacturaFechaFactura` <= @AV52ToDate)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92FacturaEstatus)) )
         {
            AddWhere(sWhereString, "(`FacturaEstatus` = @AV92FacturaEstatus)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( AV95PromocionID_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV95PromocionID, "`PromocionID` IN (", ")")+")");
         }
         if ( AV97UsuarioID_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV100UsuariosFiltro, "`UsuarioID` IN (", ")")+")");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99FacturaNo)) )
         {
            AddWhere(sWhereString, "(`FacturaNo` = @AV99FacturaNo)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         scmdbuf += sWhereString;
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
                     return conditional_H004R2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (GxSimpleCollection<int>)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] );
               case 1 :
                     return conditional_H004R3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (GxSimpleCollection<int>)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] );
               case 8 :
                     return conditional_H004R10(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] );
               case 9 :
                     return conditional_H004R11(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (GxSimpleCollection<int>)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH004R4;
          prmH004R4 = new Object[] {
          new ParDef("@AV37RegUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH004R5;
          prmH004R5 = new Object[] {
          };
          Object[] prmH004R6;
          prmH004R6 = new Object[] {
          };
          Object[] prmH004R7;
          prmH004R7 = new Object[] {
          };
          Object[] prmH004R8;
          prmH004R8 = new Object[] {
          };
          Object[] prmH004R9;
          prmH004R9 = new Object[] {
          };
          Object[] prmH004R12;
          prmH004R12 = new Object[] {
          new ParDef("@AV19FacturaID",GXType.Int32,9,0)
          };
          Object[] prmH004R2;
          prmH004R2 = new Object[] {
          new ParDef("@AV22FromDate",GXType.Date,8,0) ,
          new ParDef("@AV52ToDate",GXType.Date,8,0) ,
          new ParDef("@AV92FacturaEstatus",GXType.Char,20,0) ,
          new ParDef("@AV99FacturaNo",GXType.Char,20,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004R3;
          prmH004R3 = new Object[] {
          new ParDef("@AV22FromDate",GXType.Date,8,0) ,
          new ParDef("@AV52ToDate",GXType.Date,8,0) ,
          new ParDef("@AV92FacturaEstatus",GXType.Char,20,0) ,
          new ParDef("@AV99FacturaNo",GXType.Char,20,0)
          };
          Object[] prmH004R10;
          prmH004R10 = new Object[] {
          };
          Object[] prmH004R11;
          prmH004R11 = new Object[] {
          new ParDef("@AV22FromDate",GXType.Date,8,0) ,
          new ParDef("@AV52ToDate",GXType.Date,8,0) ,
          new ParDef("@AV92FacturaEstatus",GXType.Char,20,0) ,
          new ParDef("@AV99FacturaNo",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004R4", "SELECT T1.`DistribuidorID`, T1.`UsuarioID`, T2.`DistribuidorDescripcion`, T1.`DistribuidoresUsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Distribuidor` T2 ON T2.`DistribuidorID` = T1.`DistribuidorID`) WHERE T1.`UsuarioID` = @AV37RegUsuarioID ORDER BY T1.`DistribuidoresUsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H004R5", "SELECT `MotivoRechazoID`, `MotivoRechazoDescripcion` FROM `MotivoRechazo` ORDER BY `MotivoRechazoDescripcion` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004R6", "SELECT `UsuarioRol`, `UsuarioID`, CONCAT(CONCAT(RTRIM(LTRIM(`UsuarioNombre`)), ' '), RTRIM(LTRIM(`UsuarioApellido`))) AS UsuarioNombreCompleto, `UsuarioNombre`, `UsuarioApellido` FROM `Usuario` WHERE `UsuarioRol` = 'Participante' ORDER BY `UsuarioNombreCompleto` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004R7", "SELECT `PromocionID`, `PromocionDescripcion` FROM `Promocion` ORDER BY `PromocionDescripcion` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004R8", "SELECT `DistribuidorID`, `DistribuidorDescripcion` FROM `Distribuidor` ORDER BY `DistribuidorDescripcion` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004R9", "SELECT T1.`DistribuidoresUsuarioID`, T2.`UsuarioRol`, T1.`UsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = T1.`UsuarioID`) WHERE T2.`UsuarioRol` = 'Participante' ORDER BY T1.`DistribuidoresUsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004R10", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004R11", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004R12", "SELECT `FacturaID`, `FacturaPDF_GXI`, `FacturaPDF` FROM `Factura` WHERE `FacturaID` = @AV19FacturaID ORDER BY `FacturaID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R12,1, GxCacheFrequency.OFF ,true,true )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.getBool(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 20);
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getString(5, 50);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
       }
    }

 }

}
