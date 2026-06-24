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
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wcduplicarpromo : GXWebComponent
   {
      public wcduplicarpromo( )
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

      public wcduplicarpromo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PromocionIDEntra )
      {
         this.AV21PromocionIDEntra = aP0_PromocionIDEntra;
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
               gxfirstwebparm = GetFirstPar( "PromocionIDEntra");
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
                  AV21PromocionIDEntra = (int)(Math.Round(NumberUtil.Val( GetPar( "PromocionIDEntra"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV21PromocionIDEntra", StringUtil.LTrimStr( (decimal)(AV21PromocionIDEntra), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV21PromocionIDEntra});
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
                  gxfirstwebparm = GetFirstPar( "PromocionIDEntra");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "PromocionIDEntra");
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
            PA472( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS472( ) ;
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
            context.SendWebValue( context.GetMessage( "WCDuplicar Promo", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
            GXEncryptionTmp = "wcduplicarpromo.aspx"+UrlEncode(StringUtil.LTrimStr(AV21PromocionIDEntra,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcduplicarpromo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Promocion", AV5Promocion);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Promocion", AV5Promocion);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV21PromocionIDEntra", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV21PromocionIDEntra), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV10CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDTMODELOS", AV34SDTModelos);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDTMODELOS", AV34SDTModelos);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vERRORCODE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28ErrorCode), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROMOCIONIDENTRA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21PromocionIDEntra), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DISTRIBUIDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10DistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDISTRIBUIDORIDLISTA", AV22DistribuidorIDLista);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDISTRIBUIDORIDLISTA", AV22DistribuidorIDLista);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vSUCCESS", AV26Success);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"MODELOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22ModeloID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROMOCIONMODELOPRECIO", StringUtil.LTrim( StringUtil.NToC( A49PromocionModeloPrecio, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPROMOMODELLIST", AV31PromoModelList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPROMOMODELLIST", AV31PromoModelList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPROMODISTLIST", AV30PromoDistList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPROMODISTLIST", AV30PromoDistList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMESSAGES", AV7Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMESSAGES", AV7Messages);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPROMOCION", AV5Promocion);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPROMOCION", AV5Promocion);
         }
         GXCCtlgxBlob = "vPROMOARTE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtlgxBlob, AV13PromoArte);
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
      }

      protected void RenderHtmlCloseForm472( )
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
         return "WCDuplicarPromo" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WCDuplicar Promo", "") ;
      }

      protected void WB470( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcduplicarpromo.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableTransactionTemplate", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
            ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
            ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
            ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
            ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
            ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
            ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
            ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
            ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
            ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
            ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, sPrefix+"DVPANEL_TABLEATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPromocion_promociondescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPromocion_promociondescripcion_Internalname, context.GetMessage( "Nom. Promoción", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPromocion_promociondescripcion_Internalname, AV5Promocion.gxTpr_Promociondescripcion, StringUtil.RTrim( context.localUtil.Format( AV5Promocion.gxTpr_Promociondescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPromocion_promociondescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPromocion_promociondescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WCDuplicarPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPromoarte_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPromoarte_Internalname, context.GetMessage( "Subir arte", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            ClassString = "AttributeFL";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            edtavPromoarte_Filetype = "tmp";
            AssignProp(sPrefix, false, edtavPromoarte_Internalname, "Filetype", edtavPromoarte_Filetype, true);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13PromoArte)) )
            {
               gxblobfileaux.Source = AV13PromoArte;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavPromoarte_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavPromoarte_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV13PromoArte = gxblobfileaux.GetURI();
                  AssignProp(sPrefix, false, edtavPromoarte_Internalname, "URL", context.PathToRelativeUrl( AV13PromoArte), true);
                  edtavPromoarte_Filetype = gxblobfileaux.GetExtension();
                  AssignProp(sPrefix, false, edtavPromoarte_Internalname, "Filetype", edtavPromoarte_Filetype, true);
               }
               AssignProp(sPrefix, false, edtavPromoarte_Internalname, "URL", context.PathToRelativeUrl( AV13PromoArte), true);
            }
            GxWebStd.gx_blob_field( context, edtavPromoarte_Internalname, StringUtil.RTrim( AV13PromoArte), context.PathToRelativeUrl( AV13PromoArte), (String.IsNullOrEmpty(StringUtil.RTrim( edtavPromoarte_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavPromoarte_Filetype)) ? AV13PromoArte : edtavPromoarte_Filetype)) : edtavPromoarte_Contenttype), false, "", edtavPromoarte_Parameters, 0, edtavPromoarte_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtavPromoarte_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", "", "HLP_WCDuplicarPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPromocion_promocionfechainicio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPromocion_promocionfechainicio_Internalname, context.GetMessage( "Inicio de la promoción", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavPromocion_promocionfechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavPromocion_promocionfechainicio_Internalname, context.localUtil.Format(AV5Promocion.gxTpr_Promocionfechainicio, "99/99/99"), context.localUtil.Format( AV5Promocion.gxTpr_Promocionfechainicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,31);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPromocion_promocionfechainicio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPromocion_promocionfechainicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WCDuplicarPromo.htm");
            GxWebStd.gx_bitmap( context, edtavPromocion_promocionfechainicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavPromocion_promocionfechainicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WCDuplicarPromo.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPromocion_promocionfechafin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPromocion_promocionfechafin_Internalname, context.GetMessage( "Fin de la promoción", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavPromocion_promocionfechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavPromocion_promocionfechafin_Internalname, context.localUtil.Format(AV5Promocion.gxTpr_Promocionfechafin, "99/99/99"), context.localUtil.Format( AV5Promocion.gxTpr_Promocionfechafin, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPromocion_promocionfechafin_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPromocion_promocionfechafin_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WCDuplicarPromo.htm");
            GxWebStd.gx_bitmap( context, edtavPromocion_promocionfechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavPromocion_promocionfechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WCDuplicarPromo.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPromocion_promocionbase_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPromocion_promocionbase_Internalname, context.GetMessage( "Bases", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavPromocion_promocionbase_Internalname, AV5Promocion.gxTpr_Promocionbase, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", 0, 1, edtavPromocion_promocionbase_Enabled, 0, 80, "chr", 9, "row", 0, StyleString, ClassString, "", "", "700", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WCDuplicarPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WCDuplicarPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WCDuplicarPromo.htm");
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
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPromocion_promocionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Promocion.gxTpr_Promocionid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Promocion.gxTpr_Promocionid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,51);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPromocion_promocionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavPromocion_promocionid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WCDuplicarPromo.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPromocion_promocionvigencia_Internalname, AV5Promocion.gxTpr_Promocionvigencia, StringUtil.RTrim( context.localUtil.Format( AV5Promocion.gxTpr_Promocionvigencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPromocion_promocionvigencia_Jsonclick, 0, "Attribute", "", "", "", "", edtavPromocion_promocionvigencia_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WCDuplicarPromo.htm");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavPromocion_promocionsegmentosjson_Internalname, AV5Promocion.gxTpr_Promocionsegmentosjson, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", 0, edtavPromocion_promocionsegmentosjson_Visible, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WCDuplicarPromo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START472( )
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
            Form.Meta.addItem("description", context.GetMessage( "WCDuplicar Promo", ""), 0) ;
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
               STRUP470( ) ;
            }
         }
      }

      protected void WS472( )
      {
         START472( ) ;
         EVT472( ) ;
      }

      protected void EVT472( )
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
                                 STRUP470( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP470( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11472 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP470( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E12472 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VPROMOARTE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP470( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E13472 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP470( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E14472 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP470( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavPromocion_promociondescripcion_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE472( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm472( ) ;
            }
         }
      }

      protected void PA472( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wcduplicarpromo.aspx")), "wcduplicarpromo.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wcduplicarpromo.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "PromocionIDEntra");
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
               GX_FocusControl = edtavPromocion_promociondescripcion_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
         RF472( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF472( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E14472 ();
            WB470( ) ;
         }
      }

      protected void send_integrity_lvl_hashes472( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP470( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11472 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vPROMOCION"), AV5Promocion);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Promocion"), AV5Promocion);
            /* Read saved values. */
            wcpOAV21PromocionIDEntra = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV21PromocionIDEntra"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvpanel_tableattributes_Width = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Width");
            Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Autowidth"));
            Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Autoheight"));
            Dvpanel_tableattributes_Cls = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Cls");
            Dvpanel_tableattributes_Title = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Title");
            Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Collapsible"));
            Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Collapsed"));
            Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
            Dvpanel_tableattributes_Iconposition = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Iconposition");
            Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Autoscroll"));
            /* Read variables values. */
            AV5Promocion.gxTpr_Promociondescripcion = cgiGet( edtavPromocion_promociondescripcion_Internalname);
            AV13PromoArte = cgiGet( edtavPromoarte_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavPromocion_promocionfechainicio_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Inicio de la promoción", "")}), 1, "PROMOCION_PROMOCIONFECHAINICIO");
               GX_FocusControl = edtavPromocion_promocionfechainicio_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Promocion.gxTpr_Promocionfechainicio = DateTime.MinValue;
            }
            else
            {
               AV5Promocion.gxTpr_Promocionfechainicio = context.localUtil.CToD( cgiGet( edtavPromocion_promocionfechainicio_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavPromocion_promocionfechafin_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fin de la promoción", "")}), 1, "PROMOCION_PROMOCIONFECHAFIN");
               GX_FocusControl = edtavPromocion_promocionfechafin_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Promocion.gxTpr_Promocionfechafin = DateTime.MinValue;
            }
            else
            {
               AV5Promocion.gxTpr_Promocionfechafin = context.localUtil.CToD( cgiGet( edtavPromocion_promocionfechafin_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV5Promocion.gxTpr_Promocionbase = cgiGet( edtavPromocion_promocionbase_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPromocion_promocionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPromocion_promocionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROMOCION_PROMOCIONID");
               GX_FocusControl = edtavPromocion_promocionid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Promocion.gxTpr_Promocionid = 0;
            }
            else
            {
               AV5Promocion.gxTpr_Promocionid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPromocion_promocionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV5Promocion.gxTpr_Promocionvigencia = cgiGet( edtavPromocion_promocionvigencia_Internalname);
            AV5Promocion.gxTpr_Promocionsegmentosjson = cgiGet( edtavPromocion_promocionsegmentosjson_Internalname);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13PromoArte)) )
            {
               GXCCtlgxBlob = "vPROMOARTE" + "_gxBlob";
               AV13PromoArte = cgiGet( sPrefix+GXCCtlgxBlob);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11472 ();
         if (returnInSub) return;
      }

      protected void E11472( )
      {
         /* Start Routine */
         returnInSub = false;
         AV8TrnMode = "INS";
         AV9LoadSuccess = true;
         /* Execute user subroutine: 'OBTIENEINFOPROMO' */
         S112 ();
         if (returnInSub) return;
         if ( ! AV9LoadSuccess )
         {
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         edtavPromocion_promocionid_Visible = 0;
         AssignProp(sPrefix, false, edtavPromocion_promocionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPromocion_promocionid_Visible), 5, 0), true);
         edtavPromocion_promocionvigencia_Visible = 0;
         AssignProp(sPrefix, false, edtavPromocion_promocionvigencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPromocion_promocionvigencia_Visible), 5, 0), true);
         edtavPromocion_promocionsegmentosjson_Visible = 0;
         AssignProp(sPrefix, false, edtavPromocion_promocionsegmentosjson_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPromocion_promocionsegmentosjson_Visible), 5, 0), true);
         AV29Resultado = "";
         AV28ErrorCode = 0;
         AssignAttri(sPrefix, false, "AV28ErrorCode", StringUtil.LTrimStr( (decimal)(AV28ErrorCode), 4, 0));
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV10CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Promocion.gxTpr_Promociondescripcion)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Nom. Promoción", ""), "", "", "", "", "", "", "", ""),  "error",  edtavPromocion_promociondescripcion_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13PromoArte)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Subir arte", ""), "", "", "", "", "", "", "", ""),  "error",  edtavPromoarte_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( (DateTime.MinValue==AV5Promocion.gxTpr_Promocionfechainicio) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Inicio de la promoción", ""), "", "", "", "", "", "", "", ""),  "error",  edtavPromocion_promocionfechainicio_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( (DateTime.MinValue==AV5Promocion.gxTpr_Promocionfechafin) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Fin de la promoción", ""), "", "", "", "", "", "", "", ""),  "error",  edtavPromocion_promocionfechafin_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Promocion.gxTpr_Promocionbase)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Bases", ""), "", "", "", "", "", "", "", ""),  "error",  edtavPromocion_promocionbase_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12472 ();
         if (returnInSub) return;
      }

      protected void E12472( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV10CheckRequiredFieldsResult )
         {
            AV5Promocion.gxTpr_Promocionarte = AV39WebSession.Get(context.GetMessage( "ArteBlobDup", ""));
            AV26Success = true;
            AssignAttri(sPrefix, false, "AV26Success", AV26Success);
            AV5Promocion.Save();
            if ( AV5Promocion.Success() )
            {
               AV25PromocionID = AV5Promocion.gxTpr_Promocionid;
               AssignAttri(sPrefix, false, "AV25PromocionID", StringUtil.LTrimStr( (decimal)(AV25PromocionID), 9, 0));
               /* Execute user subroutine: 'OBTIENELISTADIST' */
               S132 ();
               if (returnInSub) return;
               /* Execute user subroutine: 'REGISTRAPROMODIST' */
               S142 ();
               if (returnInSub) return;
               /* Execute user subroutine: 'OBTIENELISTAMOD' */
               S152 ();
               if (returnInSub) return;
               if ( AV34SDTModelos.Count > 0 )
               {
                  /* Execute user subroutine: 'REGISTRAPROMOMOD' */
                  S162 ();
                  if (returnInSub) return;
               }
               /* Execute user subroutine: 'VALIDAFALLOS' */
               S172 ();
               if (returnInSub) return;
               if ( AV28ErrorCode == 0 )
               {
                  AV39WebSession.Remove(context.GetMessage( "ArteBlobDup", ""));
                  context.setWebReturnParms(new Object[] {});
                  context.setWebReturnParmsMetadata(new Object[] {});
                  context.wjLocDisableFrm = 1;
                  context.nUserReturn = 1;
                  returnInSub = true;
                  if (true) return;
               }
            }
            else
            {
               AV7Messages = AV5Promocion.GetMessages();
               /* Execute user subroutine: 'SHOW MESSAGES' */
               S182 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5Promocion", AV5Promocion);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV7Messages", AV7Messages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22DistribuidorIDLista", AV22DistribuidorIDLista);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30PromoDistList", AV30PromoDistList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV34SDTModelos", AV34SDTModelos);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31PromoModelList", AV31PromoModelList);
      }

      protected void E13472( )
      {
         /* Promoarte_Controlvaluechanged Routine */
         returnInSub = false;
         AV39WebSession.Set(context.GetMessage( "ArteBlobDup", ""), AV13PromoArte);
         /*  Sending Event outputs  */
      }

      protected void S182( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV47GXV8 = 1;
         while ( AV47GXV8 <= AV7Messages.Count )
         {
            AV6Message = ((GeneXus.Utils.SdtMessages_Message)AV7Messages.Item(AV47GXV8));
            GX_msglist.addItem(AV6Message.gxTpr_Description);
            AV47GXV8 = (int)(AV47GXV8+1);
         }
      }

      protected void S112( )
      {
         /* 'OBTIENEINFOPROMO' Routine */
         returnInSub = false;
         AV48GXLvl106 = 0;
         /* Using cursor H00472 */
         pr_default.execute(0, new Object[] {AV21PromocionIDEntra});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A41PromocionID = H00472_A41PromocionID[0];
            A42PromocionDescripcion = H00472_A42PromocionDescripcion[0];
            A43PromocionBase = H00472_A43PromocionBase[0];
            A45PromocionFechaInicio = H00472_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = H00472_A46PromocionFechaFin[0];
            A68PromocionSegmentosJson = H00472_A68PromocionSegmentosJson[0];
            AV48GXLvl106 = 1;
            AV5Promocion.gxTpr_Promociondescripcion = A42PromocionDescripcion;
            AV5Promocion.gxTpr_Promocionbase = A43PromocionBase;
            AV5Promocion.gxTpr_Promocionfechainicio = A45PromocionFechaInicio;
            AV5Promocion.gxTpr_Promocionfechafin = A46PromocionFechaFin;
            AV5Promocion.gxTpr_Promocionsegmentosjson = A68PromocionSegmentosJson;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV48GXLvl106 == 0 )
         {
            AV9LoadSuccess = false;
         }
      }

      protected void S132( )
      {
         /* 'OBTIENELISTADIST' Routine */
         returnInSub = false;
         AV22DistribuidorIDLista.Clear();
         /* Using cursor H00473 */
         pr_default.execute(1, new Object[] {AV21PromocionIDEntra});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A41PromocionID = H00473_A41PromocionID[0];
            A10DistribuidorID = H00473_A10DistribuidorID[0];
            AV23YaExiste = false;
            AV50GXV9 = 1;
            while ( AV50GXV9 <= AV22DistribuidorIDLista.Count )
            {
               AV24DistribuidorID = (int)(AV22DistribuidorIDLista.GetNumeric(AV50GXV9));
               if ( AV24DistribuidorID == A10DistribuidorID )
               {
                  AV23YaExiste = true;
                  if (true) break;
               }
               AV50GXV9 = (int)(AV50GXV9+1);
            }
            if ( ! AV23YaExiste )
            {
               AV22DistribuidorIDLista.Add(A10DistribuidorID, 0);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S152( )
      {
         /* 'OBTIENELISTAMOD' Routine */
         returnInSub = false;
         AV34SDTModelos.Clear();
         /* Using cursor H00474 */
         pr_default.execute(2, new Object[] {AV21PromocionIDEntra});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A41PromocionID = H00474_A41PromocionID[0];
            A22ModeloID = H00474_A22ModeloID[0];
            A49PromocionModeloPrecio = H00474_A49PromocionModeloPrecio[0];
            AV35SDTModelosItem = new SdtSDTModelos_SDTModelosItem(context);
            AV35SDTModelosItem.gxTpr_Modeloid = A22ModeloID;
            AV35SDTModelosItem.gxTpr_Promocionmodeloprecio = A49PromocionModeloPrecio;
            AV34SDTModelos.Add(AV35SDTModelosItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S142( )
      {
         /* 'REGISTRAPROMODIST' Routine */
         returnInSub = false;
         AV30PromoDistList = new GXBCCollection<SdtPromocionDistribuidor>( context, "PromocionDistribuidor", "Premios");
         AV52GXV10 = 1;
         while ( AV52GXV10 <= AV22DistribuidorIDLista.Count )
         {
            AV24DistribuidorID = (int)(AV22DistribuidorIDLista.GetNumeric(AV52GXV10));
            if ( AV26Success )
            {
               AV27PromocionDistribuidor = new SdtPromocionDistribuidor(context);
               AV27PromocionDistribuidor.gxTpr_Promocionid = AV25PromocionID;
               AV27PromocionDistribuidor.gxTpr_Distribuidorid = AV24DistribuidorID;
               AV27PromocionDistribuidor.Save();
               if ( AV27PromocionDistribuidor.Fail() )
               {
                  AV26Success = false;
                  AssignAttri(sPrefix, false, "AV26Success", AV26Success);
                  AV28ErrorCode = 2001;
                  AssignAttri(sPrefix, false, "AV28ErrorCode", StringUtil.LTrimStr( (decimal)(AV28ErrorCode), 4, 0));
                  AV29Resultado = context.GetMessage( "Error al guardar el distribuidor con ID: ", "") + StringUtil.Str( (decimal)(AV24DistribuidorID), 9, 0);
                  GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Error: %1. %2", ""), StringUtil.Str( (decimal)(AV28ErrorCode), 4, 0), StringUtil.Trim( AV29Resultado), "", "", "", "", "", "", ""));
                  if (true) break;
               }
               else
               {
                  AV30PromoDistList.Add(AV27PromocionDistribuidor, 0);
               }
            }
            AV52GXV10 = (int)(AV52GXV10+1);
         }
      }

      protected void S162( )
      {
         /* 'REGISTRAPROMOMOD' Routine */
         returnInSub = false;
         AV31PromoModelList.Clear();
         AV53GXV11 = 1;
         while ( AV53GXV11 <= AV34SDTModelos.Count )
         {
            AV35SDTModelosItem = ((SdtSDTModelos_SDTModelosItem)AV34SDTModelos.Item(AV53GXV11));
            if ( AV26Success )
            {
               AV36PromocionModelo = new SdtPromocionModelo(context);
               AV36PromocionModelo.gxTpr_Promocionid = AV25PromocionID;
               AV36PromocionModelo.gxTpr_Modeloid = AV35SDTModelosItem.gxTpr_Modeloid;
               AV36PromocionModelo.gxTpr_Promocionmodeloprecio = AV35SDTModelosItem.gxTpr_Promocionmodeloprecio;
               AV36PromocionModelo.Save();
               if ( AV36PromocionModelo.Fail() )
               {
                  AV26Success = false;
                  AssignAttri(sPrefix, false, "AV26Success", AV26Success);
                  AV28ErrorCode = 3001;
                  AssignAttri(sPrefix, false, "AV28ErrorCode", StringUtil.LTrimStr( (decimal)(AV28ErrorCode), 4, 0));
                  AV29Resultado = context.GetMessage( "Error al guardar el modelo con ID: ", "") + StringUtil.Str( (decimal)(AV35SDTModelosItem.gxTpr_Modeloid), 9, 0);
                  GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Error: %1. %2", ""), StringUtil.Str( (decimal)(AV28ErrorCode), 4, 0), StringUtil.Trim( AV29Resultado), "", "", "", "", "", "", ""));
                  context.setWebReturnParms(new Object[] {});
                  context.setWebReturnParmsMetadata(new Object[] {});
                  context.wjLocDisableFrm = 1;
                  context.nUserReturn = 1;
                  returnInSub = true;
                  if (true) return;
               }
               else
               {
                  AV31PromoModelList.Add(AV36PromocionModelo, 0);
               }
            }
            AV53GXV11 = (int)(AV53GXV11+1);
         }
      }

      protected void S172( )
      {
         /* 'VALIDAFALLOS' Routine */
         returnInSub = false;
         if ( ! AV26Success )
         {
            AV54GXV12 = 1;
            while ( AV54GXV12 <= AV31PromoModelList.Count )
            {
               AV37PM = ((SdtPromocionModelo)AV31PromoModelList.Item(AV54GXV12));
               AV37PM.Load(AV37PM.gxTpr_Promocionmodeloid);
               AV37PM.Delete();
               AV54GXV12 = (int)(AV54GXV12+1);
            }
            AV55GXV13 = 1;
            while ( AV55GXV13 <= AV30PromoDistList.Count )
            {
               AV38PD = ((SdtPromocionDistribuidor)AV30PromoDistList.Item(AV55GXV13));
               AV38PD.Load(AV38PD.gxTpr_Promociondistribuidorid);
               AV38PD.Delete();
               AV55GXV13 = (int)(AV55GXV13+1);
            }
            AV5Promocion.Delete();
            AV29Resultado = context.GetMessage( "Error general en el proceso, se revirtieron los cambios. Código de error: ", "") + StringUtil.Str( (decimal)(AV28ErrorCode), 4, 0);
            GX_msglist.addItem(StringUtil.Trim( AV29Resultado));
         }
         else
         {
            context.CommitDataStores("wcduplicarpromo",pr_default);
            AV28ErrorCode = 0;
            AssignAttri(sPrefix, false, "AV28ErrorCode", StringUtil.LTrimStr( (decimal)(AV28ErrorCode), 4, 0));
            AV29Resultado = context.GetMessage( "La promoción fue guardada correctamente.", "");
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E14472( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV21PromocionIDEntra = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV21PromocionIDEntra", StringUtil.LTrimStr( (decimal)(AV21PromocionIDEntra), 9, 0));
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
         PA472( ) ;
         WS472( ) ;
         WE472( ) ;
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
         sCtrlAV21PromocionIDEntra = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA472( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcduplicarpromo", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA472( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV21PromocionIDEntra = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV21PromocionIDEntra", StringUtil.LTrimStr( (decimal)(AV21PromocionIDEntra), 9, 0));
         }
         wcpOAV21PromocionIDEntra = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV21PromocionIDEntra"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV21PromocionIDEntra != wcpOAV21PromocionIDEntra ) ) )
         {
            setjustcreated();
         }
         wcpOAV21PromocionIDEntra = AV21PromocionIDEntra;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV21PromocionIDEntra = cgiGet( sPrefix+"AV21PromocionIDEntra_CTRL");
         if ( StringUtil.Len( sCtrlAV21PromocionIDEntra) > 0 )
         {
            AV21PromocionIDEntra = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV21PromocionIDEntra), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV21PromocionIDEntra", StringUtil.LTrimStr( (decimal)(AV21PromocionIDEntra), 9, 0));
         }
         else
         {
            AV21PromocionIDEntra = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV21PromocionIDEntra_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA472( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS472( ) ;
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
         WS472( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV21PromocionIDEntra_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21PromocionIDEntra), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV21PromocionIDEntra)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV21PromocionIDEntra_CTRL", StringUtil.RTrim( sCtrlAV21PromocionIDEntra));
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
         WE472( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025102815462089", true, true);
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
         context.AddJavascriptSource("wcduplicarpromo.js", "?2025102815462090", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavPromocion_promociondescripcion_Internalname = sPrefix+"PROMOCION_PROMOCIONDESCRIPCION";
         edtavPromoarte_Internalname = sPrefix+"vPROMOARTE";
         edtavPromocion_promocionfechainicio_Internalname = sPrefix+"PROMOCION_PROMOCIONFECHAINICIO";
         edtavPromocion_promocionfechafin_Internalname = sPrefix+"PROMOCION_PROMOCIONFECHAFIN";
         edtavPromocion_promocionbase_Internalname = sPrefix+"PROMOCION_PROMOCIONBASE";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = sPrefix+"DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtnenter_Internalname = sPrefix+"BTNENTER";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavPromocion_promocionid_Internalname = sPrefix+"PROMOCION_PROMOCIONID";
         edtavPromocion_promocionvigencia_Internalname = sPrefix+"PROMOCION_PROMOCIONVIGENCIA";
         edtavPromocion_promocionsegmentosjson_Internalname = sPrefix+"PROMOCION_PROMOCIONSEGMENTOSJSON";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
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
         edtavPromocion_promocionsegmentosjson_Visible = 1;
         edtavPromocion_promocionvigencia_Jsonclick = "";
         edtavPromocion_promocionvigencia_Visible = 1;
         edtavPromocion_promocionid_Jsonclick = "";
         edtavPromocion_promocionid_Visible = 1;
         edtavPromocion_promocionbase_Enabled = 1;
         edtavPromocion_promocionfechafin_Jsonclick = "";
         edtavPromocion_promocionfechafin_Enabled = 1;
         edtavPromocion_promocionfechainicio_Jsonclick = "";
         edtavPromocion_promocionfechainicio_Enabled = 1;
         edtavPromoarte_Jsonclick = "";
         edtavPromoarte_Parameters = "";
         edtavPromoarte_Contenttype = "";
         edtavPromoarte_Filetype = "";
         edtavPromoarte_Enabled = 1;
         edtavPromocion_promociondescripcion_Jsonclick = "";
         edtavPromocion_promociondescripcion_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = context.GetMessage( "WWP_TemplateDataPanelTitle", "");
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("ENTER","""{"handler":"E12472","iparms":[{"av":"AV10CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV5Promocion","fld":"vPROMOCION"},{"av":"AV34SDTModelos","fld":"vSDTMODELOS"},{"av":"AV28ErrorCode","fld":"vERRORCODE","pic":"ZZZ9"},{"av":"AV13PromoArte","fld":"vPROMOARTE"},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV21PromocionIDEntra","fld":"vPROMOCIONIDENTRA","pic":"ZZZZZZZZ9"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"AV22DistribuidorIDLista","fld":"vDISTRIBUIDORIDLISTA"},{"av":"AV26Success","fld":"vSUCCESS"},{"av":"AV25PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A22ModeloID","fld":"MODELOID","pic":"ZZZZZZZZ9"},{"av":"A49PromocionModeloPrecio","fld":"PROMOCIONMODELOPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"AV31PromoModelList","fld":"vPROMOMODELLIST"},{"av":"AV30PromoDistList","fld":"vPROMODISTLIST"},{"av":"AV7Messages","fld":"vMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5Promocion","fld":"vPROMOCION"},{"av":"AV26Success","fld":"vSUCCESS"},{"av":"AV25PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"AV7Messages","fld":"vMESSAGES"},{"av":"AV10CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV22DistribuidorIDLista","fld":"vDISTRIBUIDORIDLISTA"},{"av":"AV30PromoDistList","fld":"vPROMODISTLIST"},{"av":"AV28ErrorCode","fld":"vERRORCODE","pic":"ZZZ9"},{"av":"AV34SDTModelos","fld":"vSDTMODELOS"},{"av":"AV31PromoModelList","fld":"vPROMOMODELLIST"}]}""");
         setEventMetadata("VPROMOARTE.CONTROLVALUECHANGED","""{"handler":"E13472","iparms":[{"av":"AV13PromoArte","fld":"vPROMOARTE"}]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV5Promocion = new SdtPromocion(context);
         AV34SDTModelos = new GXBaseCollection<SdtSDTModelos_SDTModelosItem>( context, "SDTModelosItem", "Premios");
         AV22DistribuidorIDLista = new GxSimpleCollection<int>();
         AV31PromoModelList = new GXBCCollection<SdtPromocionModelo>( context, "PromocionModelo", "Premios");
         AV30PromoDistList = new GXBCCollection<SdtPromocionDistribuidor>( context, "PromocionDistribuidor", "Premios");
         AV7Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXCCtlgxBlob = "";
         AV13PromoArte = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV8TrnMode = "";
         AV29Resultado = "";
         AV39WebSession = context.GetSession();
         AV6Message = new GeneXus.Utils.SdtMessages_Message(context);
         H00472_A41PromocionID = new int[1] ;
         H00472_A42PromocionDescripcion = new string[] {""} ;
         H00472_A43PromocionBase = new string[] {""} ;
         H00472_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         H00472_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         H00472_A68PromocionSegmentosJson = new string[] {""} ;
         A42PromocionDescripcion = "";
         A43PromocionBase = "";
         A45PromocionFechaInicio = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         A68PromocionSegmentosJson = "";
         H00473_A47PromocionDistribuidorID = new int[1] ;
         H00473_A41PromocionID = new int[1] ;
         H00473_A10DistribuidorID = new int[1] ;
         H00474_A48PromocionModeloID = new int[1] ;
         H00474_A41PromocionID = new int[1] ;
         H00474_A22ModeloID = new int[1] ;
         H00474_A49PromocionModeloPrecio = new decimal[1] ;
         AV35SDTModelosItem = new SdtSDTModelos_SDTModelosItem(context);
         AV27PromocionDistribuidor = new SdtPromocionDistribuidor(context);
         AV36PromocionModelo = new SdtPromocionModelo(context);
         AV37PM = new SdtPromocionModelo(context);
         AV38PD = new SdtPromocionDistribuidor(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV21PromocionIDEntra = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcduplicarpromo__default(),
            new Object[][] {
                new Object[] {
               H00472_A41PromocionID, H00472_A42PromocionDescripcion, H00472_A43PromocionBase, H00472_A45PromocionFechaInicio, H00472_A46PromocionFechaFin, H00472_A68PromocionSegmentosJson
               }
               , new Object[] {
               H00473_A47PromocionDistribuidorID, H00473_A41PromocionID, H00473_A10DistribuidorID
               }
               , new Object[] {
               H00474_A48PromocionModeloID, H00474_A41PromocionID, H00474_A22ModeloID, H00474_A49PromocionModeloPrecio
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV28ErrorCode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short AV48GXLvl106 ;
      private short nGXWrapped ;
      private int AV21PromocionIDEntra ;
      private int wcpOAV21PromocionIDEntra ;
      private int A41PromocionID ;
      private int A10DistribuidorID ;
      private int AV25PromocionID ;
      private int A22ModeloID ;
      private int edtavPromocion_promociondescripcion_Enabled ;
      private int edtavPromoarte_Enabled ;
      private int edtavPromocion_promocionfechainicio_Enabled ;
      private int edtavPromocion_promocionfechafin_Enabled ;
      private int edtavPromocion_promocionbase_Enabled ;
      private int edtavPromocion_promocionid_Visible ;
      private int edtavPromocion_promocionvigencia_Visible ;
      private int edtavPromocion_promocionsegmentosjson_Visible ;
      private int AV47GXV8 ;
      private int AV50GXV9 ;
      private int AV24DistribuidorID ;
      private int AV52GXV10 ;
      private int AV53GXV11 ;
      private int AV54GXV12 ;
      private int AV55GXV13 ;
      private int idxLst ;
      private decimal A49PromocionModeloPrecio ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GXCCtlgxBlob ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavPromocion_promociondescripcion_Internalname ;
      private string TempTags ;
      private string edtavPromocion_promociondescripcion_Jsonclick ;
      private string edtavPromoarte_Internalname ;
      private string edtavPromoarte_Filetype ;
      private string edtavPromoarte_Contenttype ;
      private string edtavPromoarte_Parameters ;
      private string edtavPromoarte_Jsonclick ;
      private string edtavPromocion_promocionfechainicio_Internalname ;
      private string edtavPromocion_promocionfechainicio_Jsonclick ;
      private string edtavPromocion_promocionfechafin_Internalname ;
      private string edtavPromocion_promocionfechafin_Jsonclick ;
      private string edtavPromocion_promocionbase_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavPromocion_promocionid_Internalname ;
      private string edtavPromocion_promocionid_Jsonclick ;
      private string edtavPromocion_promocionvigencia_Internalname ;
      private string edtavPromocion_promocionvigencia_Jsonclick ;
      private string edtavPromocion_promocionsegmentosjson_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string AV8TrnMode ;
      private string sCtrlAV21PromocionIDEntra ;
      private DateTime A45PromocionFechaInicio ;
      private DateTime A46PromocionFechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10CheckRequiredFieldsResult ;
      private bool AV26Success ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9LoadSuccess ;
      private bool AV23YaExiste ;
      private string A68PromocionSegmentosJson ;
      private string AV29Resultado ;
      private string A42PromocionDescripcion ;
      private string A43PromocionBase ;
      private string AV13PromoArte ;
      private IGxSession AV39WebSession ;
      private GxFile gxblobfileaux ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private SdtPromocion AV5Promocion ;
      private GXBaseCollection<SdtSDTModelos_SDTModelosItem> AV34SDTModelos ;
      private GxSimpleCollection<int> AV22DistribuidorIDLista ;
      private GXBCCollection<SdtPromocionModelo> AV31PromoModelList ;
      private GXBCCollection<SdtPromocionDistribuidor> AV30PromoDistList ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV7Messages ;
      private GeneXus.Utils.SdtMessages_Message AV6Message ;
      private IDataStoreProvider pr_default ;
      private int[] H00472_A41PromocionID ;
      private string[] H00472_A42PromocionDescripcion ;
      private string[] H00472_A43PromocionBase ;
      private DateTime[] H00472_A45PromocionFechaInicio ;
      private DateTime[] H00472_A46PromocionFechaFin ;
      private string[] H00472_A68PromocionSegmentosJson ;
      private int[] H00473_A47PromocionDistribuidorID ;
      private int[] H00473_A41PromocionID ;
      private int[] H00473_A10DistribuidorID ;
      private int[] H00474_A48PromocionModeloID ;
      private int[] H00474_A41PromocionID ;
      private int[] H00474_A22ModeloID ;
      private decimal[] H00474_A49PromocionModeloPrecio ;
      private SdtSDTModelos_SDTModelosItem AV35SDTModelosItem ;
      private SdtPromocionDistribuidor AV27PromocionDistribuidor ;
      private SdtPromocionModelo AV36PromocionModelo ;
      private SdtPromocionModelo AV37PM ;
      private SdtPromocionDistribuidor AV38PD ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wcduplicarpromo__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH00472;
          prmH00472 = new Object[] {
          new ParDef("@AV21PromocionIDEntra",GXType.Int32,9,0)
          };
          Object[] prmH00473;
          prmH00473 = new Object[] {
          new ParDef("@AV21PromocionIDEntra",GXType.Int32,9,0)
          };
          Object[] prmH00474;
          prmH00474 = new Object[] {
          new ParDef("@AV21PromocionIDEntra",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00472", "SELECT `PromocionID`, `PromocionDescripcion`, `PromocionBase`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionSegmentosJson` FROM `Promocion` WHERE `PromocionID` = @AV21PromocionIDEntra ORDER BY `PromocionID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00472,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00473", "SELECT `PromocionDistribuidorID`, `PromocionID`, `DistribuidorID` FROM `PromocionDistribuidor` WHERE `PromocionID` = @AV21PromocionIDEntra ORDER BY `PromocionID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00473,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00474", "SELECT `PromocionModeloID`, `PromocionID`, `ModeloID`, `PromocionModeloPrecio` FROM `PromocionModelo` WHERE `PromocionID` = @AV21PromocionIDEntra ORDER BY `PromocionID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00474,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
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
