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
   public class wpasignardistribuidorusuario : GXDataArea
   {
      public wpasignardistribuidorusuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpasignardistribuidorusuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           int aP1_DistribuidoresUsuarioID ,
                           int aP2_UsuarioID )
      {
         this.AV10TrnMode = aP0_TrnMode;
         this.AV14DistribuidoresUsuarioID = aP1_DistribuidoresUsuarioID;
         this.AV15UsuarioID = aP2_UsuarioID;
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
            gxfirstwebparm = GetFirstPar( "TrnMode");
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
               gxfirstwebparm = GetFirstPar( "TrnMode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TrnMode");
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

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageprompt", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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
         PA362( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START362( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpasignardistribuidorusuario.aspx"+UrlEncode(StringUtil.RTrim(AV10TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV14DistribuidoresUsuarioID,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV15UsuarioID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("wpasignardistribuidorusuario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV10TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vDISTRIBUIDORESUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14DistribuidoresUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDISTRIBUIDORESUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14DistribuidoresUsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15UsuarioID), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISTRIBUIDORESUSUARIO_DISTRIBUIDORID_DATA", AV6DistribuidoresUsuario_DistribuidorID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISTRIBUIDORESUSUARIO_DISTRIBUIDORID_DATA", AV6DistribuidoresUsuario_DistribuidorID_Data);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV10TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISTRIBUIDORESUSUARIO", AV5DistribuidoresUsuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISTRIBUIDORESUSUARIO", AV5DistribuidoresUsuario);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV12CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "USUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "USUARIOROL", StringUtil.RTrim( A40UsuarioRol));
         GxWebStd.gx_hidden_field( context, "DISTRIBUIDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10DistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV9Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV9Messages);
         }
         GxWebStd.gx_hidden_field( context, "vDISTRIBUIDORESUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14DistribuidoresUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDISTRIBUIDORESUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14DistribuidoresUsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID_Cls", StringUtil.RTrim( Combo_distribuidoresusuario_distribuidorid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID_Selectedvalue_set", StringUtil.RTrim( Combo_distribuidoresusuario_distribuidorid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID_Enabled", StringUtil.BoolToStr( Combo_distribuidoresusuario_distribuidorid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID_Emptyitem", StringUtil.BoolToStr( Combo_distribuidoresusuario_distribuidorid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID_Selectedvalue_get", StringUtil.RTrim( Combo_distribuidoresusuario_distribuidorid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID_Ddointernalname", StringUtil.RTrim( Combo_distribuidoresusuario_distribuidorid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID_Ddointernalname", StringUtil.RTrim( Combo_distribuidoresusuario_distribuidorid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID_Selectedvalue_get", StringUtil.RTrim( Combo_distribuidoresusuario_distribuidorid_Selectedvalue_get));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE362( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT362( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpasignardistribuidorusuario.aspx"+UrlEncode(StringUtil.RTrim(AV10TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV14DistribuidoresUsuarioID,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV15UsuarioID,9,0));
         return formatLink("wpasignardistribuidorusuario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WPAsignarDistribuidorUsuario" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Asignar Distribuidor", "") ;
      }

      protected void WB360( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableTransactionTemplate", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransactionPopUp", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplitteddistribuidoresusuario_distribuidorid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_distribuidoresusuario_distribuidorid_Internalname, context.GetMessage( "Seleccionar distribuidor", ""), "", "", lblTextblockcombo_distribuidoresusuario_distribuidorid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPAsignarDistribuidorUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_distribuidoresusuario_distribuidorid.SetProperty("Caption", Combo_distribuidoresusuario_distribuidorid_Caption);
            ucCombo_distribuidoresusuario_distribuidorid.SetProperty("Cls", Combo_distribuidoresusuario_distribuidorid_Cls);
            ucCombo_distribuidoresusuario_distribuidorid.SetProperty("EmptyItem", Combo_distribuidoresusuario_distribuidorid_Emptyitem);
            ucCombo_distribuidoresusuario_distribuidorid.SetProperty("DropDownOptionsData", AV6DistribuidoresUsuario_DistribuidorID_Data);
            ucCombo_distribuidoresusuario_distribuidorid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_distribuidoresusuario_distribuidorid_Internalname, "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORIDContainer");
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
            GxWebStd.gx_div_start( context, divUnnamedsection1_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, context.GetMessage( "Recuerda que si el Rol del usuario es Participante,  solo se le puede asignar un distribuidor", ""), "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WPAsignarDistribuidorUsuario.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPAsignarDistribuidorUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPAsignarDistribuidorUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START362( )
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
         Form.Meta.addItem("description", context.GetMessage( "Asignar Distribuidor", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP360( ) ;
      }

      protected void WS362( )
      {
         START362( ) ;
         EVT362( ) ;
      }

      protected void EVT362( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_distribuidoresusuario_distribuidorid.Onoptionclicked */
                              E11362 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E12362 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E13362 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E14362 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E15362 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE362( )
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

      protected void PA362( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpasignardistribuidorusuario.aspx")), "wpasignardistribuidorusuario.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpasignardistribuidorusuario.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "TrnMode");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV10TrnMode = gxfirstwebparm;
                     AssignAttri("", false, "AV10TrnMode", AV10TrnMode);
                     GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV14DistribuidoresUsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "DistribuidoresUsuarioID"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV14DistribuidoresUsuarioID", StringUtil.LTrimStr( (decimal)(AV14DistribuidoresUsuarioID), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vDISTRIBUIDORESUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14DistribuidoresUsuarioID), "ZZZZZZZZ9"), context));
                        AV15UsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "UsuarioID"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV15UsuarioID", StringUtil.LTrimStr( (decimal)(AV15UsuarioID), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15UsuarioID), "ZZZZZZZZ9"), context));
                     }
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
         RF362( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF362( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E13362 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15362 ();
            WB360( ) ;
         }
      }

      protected void send_integrity_lvl_hashes362( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP360( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12362 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDISTRIBUIDORESUSUARIO_DISTRIBUIDORID_DATA"), AV6DistribuidoresUsuario_DistribuidorID_Data);
            /* Read saved values. */
            Combo_distribuidoresusuario_distribuidorid_Cls = cgiGet( "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID_Cls");
            Combo_distribuidoresusuario_distribuidorid_Selectedvalue_set = cgiGet( "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID_Selectedvalue_set");
            Combo_distribuidoresusuario_distribuidorid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID_Enabled"));
            Combo_distribuidoresusuario_distribuidorid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID_Emptyitem"));
            Combo_distribuidoresusuario_distribuidorid_Ddointernalname = cgiGet( "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID_Ddointernalname");
            Combo_distribuidoresusuario_distribuidorid_Selectedvalue_get = cgiGet( "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID_Selectedvalue_get");
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
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
         E12362 ();
         if (returnInSub) return;
      }

      protected void E12362( )
      {
         /* Start Routine */
         returnInSub = false;
         AV5DistribuidoresUsuario.gxTpr_Usuarioid = AV15UsuarioID;
         /* Using cursor H00362 */
         pr_default.execute(0, new Object[] {AV15UsuarioID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29UsuarioID = H00362_A29UsuarioID[0];
            A40UsuarioRol = H00362_A40UsuarioRol[0];
            AV17UsuarioRol = A40UsuarioRol;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV11LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV10TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV10TrnMode, "INS") == 0 ) ) || ( ( StringUtil.StrCmp(AV10TrnMode, "UPD") == 0 ) ) || ( ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 ) ) )
         {
            if ( StringUtil.StrCmp(AV10TrnMode, "INS") != 0 )
            {
               AV5DistribuidoresUsuario.Load(AV14DistribuidoresUsuarioID);
               AV11LoadSuccess = AV5DistribuidoresUsuario.Success();
               if ( ! AV11LoadSuccess )
               {
                  AV9Messages = AV5DistribuidoresUsuario.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV10TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 ) )
               {
                  Combo_distribuidoresusuario_distribuidorid_Enabled = false;
                  ucCombo_distribuidoresusuario_distribuidorid.SendProperty(context, "", false, Combo_distribuidoresusuario_distribuidorid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_distribuidoresusuario_distribuidorid_Enabled));
               }
            }
         }
         else
         {
            AV11LoadSuccess = false;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         if ( AV11LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""));
            }
         }
         /* Execute user subroutine: 'LOADCOMBODISTRIBUIDORESUSUARIO_DISTRIBUIDORID' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E13362( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E11362( )
      {
         /* Combo_distribuidoresusuario_distribuidorid_Onoptionclicked Routine */
         returnInSub = false;
         AV5DistribuidoresUsuario.gxTpr_Distribuidorid = (int)(Math.Round(NumberUtil.Val( Combo_distribuidoresusuario_distribuidorid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5DistribuidoresUsuario", AV5DistribuidoresUsuario);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E14362 ();
         if (returnInSub) return;
      }

      protected void E14362( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV10TrnMode, "DSP") != 0 )
         {
            if ( StringUtil.StrCmp(AV10TrnMode, "DLT") != 0 )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S142 ();
               if (returnInSub) return;
            }
            if ( ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 ) || AV12CheckRequiredFieldsResult )
            {
               if ( StringUtil.StrCmp(AV10TrnMode, "DLT") == 0 )
               {
                  AV5DistribuidoresUsuario.Delete();
               }
               else
               {
                  AV5DistribuidoresUsuario.Save();
               }
               if ( AV5DistribuidoresUsuario.Success() )
               {
                  /* Execute user subroutine: 'AFTER_TRN' */
                  S152 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV9Messages = AV5DistribuidoresUsuario.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5DistribuidoresUsuario", AV5DistribuidoresUsuario);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9Messages", AV9Messages);
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV10TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV12CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         if ( (0==AV5DistribuidoresUsuario.gxTpr_Distribuidorid) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Seleccionar distribuidor", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_distribuidoresusuario_distribuidorid_Ddointernalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         /* Using cursor H00363 */
         pr_default.execute(1, new Object[] {AV15UsuarioID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29UsuarioID = H00363_A29UsuarioID[0];
            A40UsuarioRol = H00363_A40UsuarioRol[0];
            AV17UsuarioRol = A40UsuarioRol;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( StringUtil.StrCmp(AV17UsuarioRol, "Participante") == 0 )
         {
            AV16Count = 0;
            /* Optimized group. */
            /* Using cursor H00364 */
            pr_default.execute(2, new Object[] {AV15UsuarioID});
            cV16Count = H00364_AV16Count[0];
            pr_default.close(2);
            AV16Count = (short)(AV16Count+cV16Count*1);
            /* End optimized group. */
            if ( StringUtil.StrCmp(AV10TrnMode, "INS") == 0 )
            {
               if ( AV16Count > 0 )
               {
                  AV12CheckRequiredFieldsResult = false;
                  AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
               }
            }
            else
            {
               if ( AV16Count > 1 )
               {
                  AV12CheckRequiredFieldsResult = false;
                  AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
               }
            }
         }
         /* Using cursor H00365 */
         pr_default.execute(3, new Object[] {AV5DistribuidoresUsuario.gxTpr_Distribuidorid, AV15UsuarioID});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A10DistribuidorID = H00365_A10DistribuidorID[0];
            A29UsuarioID = H00365_A29UsuarioID[0];
            AV18ExisteDistribuidor = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( AV18ExisteDistribuidor )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Este distribuidor ya ha sido asignado al usuario", ""),  "error",  Combo_distribuidoresusuario_distribuidorid_Ddointernalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBODISTRIBUIDORESUSUARIO_DISTRIBUIDORID' Routine */
         returnInSub = false;
         /* Using cursor H00366 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A10DistribuidorID = H00366_A10DistribuidorID[0];
            A11DistribuidorDescripcion = H00366_A11DistribuidorDescripcion[0];
            AV7Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV7Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A10DistribuidorID), 9, 0));
            AV7Combo_DataItem.gxTpr_Title = A11DistribuidorDescripcion;
            AV6DistribuidoresUsuario_DistribuidorID_Data.Add(AV7Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_distribuidoresusuario_distribuidorid_Selectedvalue_set = ((0==AV5DistribuidoresUsuario.gxTpr_Distribuidorid) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5DistribuidoresUsuario.gxTpr_Distribuidorid), 9, 0)));
         ucCombo_distribuidoresusuario_distribuidorid.SendProperty(context, "", false, Combo_distribuidoresusuario_distribuidorid_Internalname, "SelectedValue_set", Combo_distribuidoresusuario_distribuidorid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV24GXV1 = 1;
         while ( AV24GXV1 <= AV9Messages.Count )
         {
            AV8Message = ((GeneXus.Utils.SdtMessages_Message)AV9Messages.Item(AV24GXV1));
            GX_msglist.addItem(AV8Message.gxTpr_Description);
            AV24GXV1 = (int)(AV24GXV1+1);
         }
      }

      protected void S152( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("wpasignardistribuidorusuario",pr_default);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E15362( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV10TrnMode", AV10TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10TrnMode, "")), context));
         AV14DistribuidoresUsuarioID = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV14DistribuidoresUsuarioID", StringUtil.LTrimStr( (decimal)(AV14DistribuidoresUsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vDISTRIBUIDORESUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14DistribuidoresUsuarioID), "ZZZZZZZZ9"), context));
         AV15UsuarioID = Convert.ToInt32(getParm(obj,2));
         AssignAttri("", false, "AV15UsuarioID", StringUtil.LTrimStr( (decimal)(AV15UsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15UsuarioID), "ZZZZZZZZ9"), context));
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
         PA362( ) ;
         WS362( ) ;
         WE362( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202510281546272", true, true);
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
         context.AddJavascriptSource("wpasignardistribuidorusuario.js", "?202510281546272", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockcombo_distribuidoresusuario_distribuidorid_Internalname = "TEXTBLOCKCOMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID";
         Combo_distribuidoresusuario_distribuidorid_Internalname = "COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID";
         divTablesplitteddistribuidoresusuario_distribuidorid_Internalname = "TABLESPLITTEDDISTRIBUIDORESUSUARIO_DISTRIBUIDORID";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divUnnamedsection1_Internalname = "UNNAMEDSECTION1";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         bttBtnenter_Visible = 1;
         Combo_distribuidoresusuario_distribuidorid_Emptyitem = Convert.ToBoolean( 0);
         Combo_distribuidoresusuario_distribuidorid_Enabled = Convert.ToBoolean( -1);
         Combo_distribuidoresusuario_distribuidorid_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Asignar Distribuidor", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV15UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV14DistribuidoresUsuarioID","fld":"vDISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID.ONOPTIONCLICKED","""{"handler":"E11362","iparms":[{"av":"Combo_distribuidoresusuario_distribuidorid_Selectedvalue_get","ctrl":"COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID","prop":"SelectedValue_get"},{"av":"AV5DistribuidoresUsuario","fld":"vDISTRIBUIDORESUSUARIO"}]""");
         setEventMetadata("COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID.ONOPTIONCLICKED",""","oparms":[{"av":"AV5DistribuidoresUsuario","fld":"vDISTRIBUIDORESUSUARIO"}]}""");
         setEventMetadata("ENTER","""{"handler":"E14362","iparms":[{"av":"AV10TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV5DistribuidoresUsuario","fld":"vDISTRIBUIDORESUSUARIO"},{"av":"Combo_distribuidoresusuario_distribuidorid_Ddointernalname","ctrl":"COMBO_DISTRIBUIDORESUSUARIO_DISTRIBUIDORID","prop":"DDOInternalName"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV15UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"AV9Messages","fld":"vMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5DistribuidoresUsuario","fld":"vDISTRIBUIDORESUSUARIO"},{"av":"AV9Messages","fld":"vMESSAGES"},{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
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
         wcpOAV10TrnMode = "";
         Combo_distribuidoresusuario_distribuidorid_Selectedvalue_get = "";
         Combo_distribuidoresusuario_distribuidorid_Ddointernalname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV6DistribuidoresUsuario_DistribuidorID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV5DistribuidoresUsuario = new SdtDistribuidoresUsuario(context);
         A40UsuarioRol = "";
         AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         Combo_distribuidoresusuario_distribuidorid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblTextblockcombo_distribuidoresusuario_distribuidorid_Jsonclick = "";
         ucCombo_distribuidoresusuario_distribuidorid = new GXUserControl();
         Combo_distribuidoresusuario_distribuidorid_Caption = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00362_A29UsuarioID = new int[1] ;
         H00362_A40UsuarioRol = new string[] {""} ;
         AV17UsuarioRol = "";
         H00363_A29UsuarioID = new int[1] ;
         H00363_A40UsuarioRol = new string[] {""} ;
         H00364_AV16Count = new short[1] ;
         H00365_A81DistribuidoresUsuarioID = new int[1] ;
         H00365_A10DistribuidorID = new int[1] ;
         H00365_A29UsuarioID = new int[1] ;
         H00366_A10DistribuidorID = new int[1] ;
         H00366_A11DistribuidorDescripcion = new string[] {""} ;
         A11DistribuidorDescripcion = "";
         AV7Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV8Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpasignardistribuidorusuario__default(),
            new Object[][] {
                new Object[] {
               H00362_A29UsuarioID, H00362_A40UsuarioRol
               }
               , new Object[] {
               H00363_A29UsuarioID, H00363_A40UsuarioRol
               }
               , new Object[] {
               H00364_AV16Count
               }
               , new Object[] {
               H00365_A81DistribuidoresUsuarioID, H00365_A10DistribuidorID, H00365_A29UsuarioID
               }
               , new Object[] {
               H00366_A10DistribuidorID, H00366_A11DistribuidorDescripcion
               }
            }
         );
         /* GeneXus formulas. */
      }

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
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short AV16Count ;
      private short cV16Count ;
      private short nGXWrapped ;
      private int AV14DistribuidoresUsuarioID ;
      private int AV15UsuarioID ;
      private int wcpOAV14DistribuidoresUsuarioID ;
      private int wcpOAV15UsuarioID ;
      private int A29UsuarioID ;
      private int A10DistribuidorID ;
      private int bttBtnenter_Visible ;
      private int AV24GXV1 ;
      private int idxLst ;
      private string AV10TrnMode ;
      private string wcpOAV10TrnMode ;
      private string Combo_distribuidoresusuario_distribuidorid_Selectedvalue_get ;
      private string Combo_distribuidoresusuario_distribuidorid_Ddointernalname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string A40UsuarioRol ;
      private string Combo_distribuidoresusuario_distribuidorid_Cls ;
      private string Combo_distribuidoresusuario_distribuidorid_Selectedvalue_set ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableattributes_Internalname ;
      private string divTablesplitteddistribuidoresusuario_distribuidorid_Internalname ;
      private string lblTextblockcombo_distribuidoresusuario_distribuidorid_Internalname ;
      private string lblTextblockcombo_distribuidoresusuario_distribuidorid_Jsonclick ;
      private string Combo_distribuidoresusuario_distribuidorid_Caption ;
      private string Combo_distribuidoresusuario_distribuidorid_Internalname ;
      private string divUnnamedsection1_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string TempTags ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string AV17UsuarioRol ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12CheckRequiredFieldsResult ;
      private bool Combo_distribuidoresusuario_distribuidorid_Enabled ;
      private bool Combo_distribuidoresusuario_distribuidorid_Emptyitem ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV11LoadSuccess ;
      private bool AV18ExisteDistribuidor ;
      private string A11DistribuidorDescripcion ;
      private GXUserControl ucCombo_distribuidoresusuario_distribuidorid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV6DistribuidoresUsuario_DistribuidorID_Data ;
      private SdtDistribuidoresUsuario AV5DistribuidoresUsuario ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9Messages ;
      private IDataStoreProvider pr_default ;
      private int[] H00362_A29UsuarioID ;
      private string[] H00362_A40UsuarioRol ;
      private int[] H00363_A29UsuarioID ;
      private string[] H00363_A40UsuarioRol ;
      private short[] H00364_AV16Count ;
      private int[] H00365_A81DistribuidoresUsuarioID ;
      private int[] H00365_A10DistribuidorID ;
      private int[] H00365_A29UsuarioID ;
      private int[] H00366_A10DistribuidorID ;
      private string[] H00366_A11DistribuidorDescripcion ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV7Combo_DataItem ;
      private GeneXus.Utils.SdtMessages_Message AV8Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpasignardistribuidorusuario__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH00362;
          prmH00362 = new Object[] {
          new ParDef("@AV15UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH00363;
          prmH00363 = new Object[] {
          new ParDef("@AV15UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH00364;
          prmH00364 = new Object[] {
          new ParDef("@AV15UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH00365;
          prmH00365 = new Object[] {
          new ParDef("@AV5Distr_1Distribuidorid",GXType.Int32,9,0) ,
          new ParDef("@AV15UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH00366;
          prmH00366 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00362", "SELECT `UsuarioID`, `UsuarioRol` FROM `Usuario` WHERE `UsuarioID` = @AV15UsuarioID ORDER BY `UsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00362,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00363", "SELECT `UsuarioID`, `UsuarioRol` FROM `Usuario` WHERE `UsuarioID` = @AV15UsuarioID ORDER BY `UsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00363,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00364", "SELECT COUNT(*) FROM `DistribuidoresUsuario` WHERE `UsuarioID` = @AV15UsuarioID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00364,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00365", "SELECT `DistribuidoresUsuarioID`, `DistribuidorID`, `UsuarioID` FROM `DistribuidoresUsuario` WHERE (`DistribuidorID` = @AV5Distr_1Distribuidorid) AND (`UsuarioID` = @AV15UsuarioID) ORDER BY `DistribuidorID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00365,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00366", "SELECT `DistribuidorID`, `DistribuidorDescripcion` FROM `Distribuidor` ORDER BY `DistribuidorDescripcion` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00366,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
