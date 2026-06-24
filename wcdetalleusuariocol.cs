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
   public class wcdetalleusuariocol : GXWebComponent
   {
      public wcdetalleusuariocol( )
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

      public wcdetalleusuariocol( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_UsuarioID )
      {
         this.AV6UsuarioID = aP0_UsuarioID;
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
         cmbavUsuario_usuariogenero = new GXCombobox();
         cmbavUsuario_usuariodirectoasociado = new GXCombobox();
         cmbavUsuario_usuariorol = new GXCombobox();
         cmbavUsuario_usuariozona = new GXCombobox();
         cmbavUsuario_usuarioproducto = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "UsuarioID");
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
                  AV6UsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "UsuarioID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV6UsuarioID", StringUtil.LTrimStr( (decimal)(AV6UsuarioID), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV6UsuarioID});
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
                  gxfirstwebparm = GetFirstPar( "UsuarioID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "UsuarioID");
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
            PA352( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavUsuario_usuarionombre_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_usuarionombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarionombre_Enabled), 5, 0), true);
               edtavUsuario_usuarioapellido_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_usuarioapellido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarioapellido_Enabled), 5, 0), true);
               edtavUsuario_usuariocorreo_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_usuariocorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocorreo_Enabled), 5, 0), true);
               edtavUsuario_puestodescripcion_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_puestodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_puestodescripcion_Enabled), 5, 0), true);
               cmbavUsuario_usuariogenero.Enabled = 0;
               AssignProp(sPrefix, false, cmbavUsuario_usuariogenero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariogenero.Enabled), 5, 0), true);
               cmbavUsuario_usuariodirectoasociado.Enabled = 0;
               AssignProp(sPrefix, false, cmbavUsuario_usuariodirectoasociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariodirectoasociado.Enabled), 5, 0), true);
               edtavUsuario_usuariorazonsocialasociado_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_usuariorazonsocialasociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariorazonsocialasociado_Enabled), 5, 0), true);
               edtavUsuario_usuarionombrecomercial_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_usuarionombrecomercial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarionombrecomercial_Enabled), 5, 0), true);
               edtavUsuario_usuariofechanacimiento_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_usuariofechanacimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariofechanacimiento_Enabled), 5, 0), true);
               edtavUsuario_usuariocolonia_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_usuariocolonia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocolonia_Enabled), 5, 0), true);
               edtavUsuario_usuariocallenum_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_usuariocallenum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocallenum_Enabled), 5, 0), true);
               edtavUsuario_usuariodelegacion_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_usuariodelegacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariodelegacion_Enabled), 5, 0), true);
               cmbavUsuario_usuariorol.Enabled = 0;
               AssignProp(sPrefix, false, cmbavUsuario_usuariorol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariorol.Enabled), 5, 0), true);
               edtavUsuario_usuariocelular_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_usuariocelular_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocelular_Enabled), 5, 0), true);
               edtavUsuario_usuariocp_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_usuariocp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocp_Enabled), 5, 0), true);
               cmbavUsuario_usuariozona.Enabled = 0;
               AssignProp(sPrefix, false, cmbavUsuario_usuariozona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariozona.Enabled), 5, 0), true);
               edtavUsuario_usuariotelefonosucursal_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_usuariotelefonosucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariotelefonosucursal_Enabled), 5, 0), true);
               edtavUsuario_paisdescripcion_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_paisdescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_paisdescripcion_Enabled), 5, 0), true);
               edtavUsuario_estadodescripcion_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_estadodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_estadodescripcion_Enabled), 5, 0), true);
               edtavUsuario_ciudaddescripcion_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_ciudaddescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_ciudaddescripcion_Enabled), 5, 0), true);
               edtavUsuario_usuariosucursal_Enabled = 0;
               AssignProp(sPrefix, false, edtavUsuario_usuariosucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariosucursal_Enabled), 5, 0), true);
               cmbavUsuario_usuarioproducto.Enabled = 0;
               AssignProp(sPrefix, false, cmbavUsuario_usuarioproducto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuarioproducto.Enabled), 5, 0), true);
               WS352( ) ;
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
            context.SendWebValue( context.GetMessage( "WCDetalle Usuario Col", "")) ;
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
            if ( nGXWrapped != 1 )
            {
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "wcdetalleusuariocol.aspx"+UrlEncode(StringUtil.LTrimStr(AV6UsuarioID,9,0));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcdetalleusuariocol.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Usuario", AV5Usuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Usuario", AV5Usuario);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6UsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUSUARIO", AV5Usuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUSUARIO", AV5Usuario);
         }
      }

      protected void RenderHtmlCloseForm352( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "WCDetalleUsuarioCol" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WCDetalle Usuario Col", "") ;
      }

      protected void WB350( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcdetalleusuariocol.aspx");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarionombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarionombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarionombre_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuarionombre), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuarionombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarionombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarionombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarioapellido_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarioapellido_Internalname, context.GetMessage( "Apellido(s)", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarioapellido_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioapellido), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuarioapellido, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarioapellido_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarioapellido_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocorreo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocorreo_Internalname, context.GetMessage( "Correo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocorreo_Internalname, AV5Usuario.gxTpr_Usuariocorreo, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariocorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocorreo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocorreo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_puestodescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_puestodescripcion_Internalname, context.GetMessage( "Puesto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_puestodescripcion_Internalname, AV5Usuario.gxTpr_Puestodescripcion, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Puestodescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_puestodescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_puestodescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuariogenero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuariogenero_Internalname, context.GetMessage( "Género", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariogenero, cmbavUsuario_usuariogenero_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariogenero), 1, cmbavUsuario_usuariogenero_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUsuario_usuariogenero.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", false, 0, "HLP_WCDetalleUsuarioCol.htm");
            cmbavUsuario_usuariogenero.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariogenero);
            AssignProp(sPrefix, false, cmbavUsuario_usuariogenero_Internalname, "Values", (string)(cmbavUsuario_usuariogenero.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuariodirectoasociado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuariodirectoasociado_Internalname, context.GetMessage( "Directo/Asociado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariodirectoasociado, cmbavUsuario_usuariodirectoasociado_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariodirectoasociado), 1, cmbavUsuario_usuariodirectoasociado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUsuario_usuariodirectoasociado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", false, 0, "HLP_WCDetalleUsuarioCol.htm");
            cmbavUsuario_usuariodirectoasociado.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariodirectoasociado);
            AssignProp(sPrefix, false, cmbavUsuario_usuariodirectoasociado_Internalname, "Values", (string)(cmbavUsuario_usuariodirectoasociado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariorazonsocialasociado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariorazonsocialasociado_Internalname, context.GetMessage( "Razón Social Asociado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariorazonsocialasociado_Internalname, AV5Usuario.gxTpr_Usuariorazonsocialasociado, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariorazonsocialasociado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariorazonsocialasociado_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariorazonsocialasociado_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarionombrecomercial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarionombrecomercial_Internalname, context.GetMessage( "Nombre Comercial", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarionombrecomercial_Internalname, AV5Usuario.gxTpr_Usuarionombrecomercial, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuarionombrecomercial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarionombrecomercial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarionombrecomercial_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariofechanacimiento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariofechanacimiento_Internalname, context.GetMessage( "Fecha de nacimiento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavUsuario_usuariofechanacimiento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariofechanacimiento_Internalname, context.localUtil.Format(AV5Usuario.gxTpr_Usuariofechanacimiento, "99/99/9999"), context.localUtil.Format( AV5Usuario.gxTpr_Usuariofechanacimiento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,59);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariofechanacimiento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariofechanacimiento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_bitmap( context, edtavUsuario_usuariofechanacimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavUsuario_usuariofechanacimiento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WCDetalleUsuarioCol.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocolonia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocolonia_Internalname, context.GetMessage( "Colonia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocolonia_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariocolonia), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariocolonia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocolonia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocolonia_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocallenum_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocallenum_Internalname, context.GetMessage( "Calle y número", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocallenum_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariocallenum), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariocallenum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocallenum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocallenum_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariodelegacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariodelegacion_Internalname, context.GetMessage( "Delegación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariodelegacion_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariodelegacion), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariodelegacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariodelegacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariodelegacion_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuariorol_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuariorol_Internalname, context.GetMessage( "Rol", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariorol, cmbavUsuario_usuariorol_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariorol), 1, cmbavUsuario_usuariorol_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUsuario_usuariorol.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", false, 0, "HLP_WCDetalleUsuarioCol.htm");
            cmbavUsuario_usuariorol.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariorol);
            AssignProp(sPrefix, false, cmbavUsuario_usuariorol_Internalname, "Values", (string)(cmbavUsuario_usuariorol.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocelular_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocelular_Internalname, context.GetMessage( "Celular", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocelular_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Usuariocelular), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavUsuario_usuariocelular_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariocelular), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariocelular), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,83);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocelular_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocelular_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocp_Internalname, context.GetMessage( "Código Postal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Usuariocp), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavUsuario_usuariocp_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariocp), "ZZZZ9") : context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariocp), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,88);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocp_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocp_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuariozona_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuariozona_Internalname, context.GetMessage( "Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariozona, cmbavUsuario_usuariozona_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariozona), 1, cmbavUsuario_usuariozona_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUsuario_usuariozona.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "", false, 0, "HLP_WCDetalleUsuarioCol.htm");
            cmbavUsuario_usuariozona.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariozona);
            AssignProp(sPrefix, false, cmbavUsuario_usuariozona_Internalname, "Values", (string)(cmbavUsuario_usuariozona.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariotelefonosucursal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariotelefonosucursal_Internalname, context.GetMessage( "Teléfono Sucursal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariotelefonosucursal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Usuariotelefonosucursal), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavUsuario_usuariotelefonosucursal_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariotelefonosucursal), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariotelefonosucursal), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,97);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariotelefonosucursal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariotelefonosucursal_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_paisdescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_paisdescripcion_Internalname, context.GetMessage( "País", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_paisdescripcion_Internalname, AV5Usuario.gxTpr_Paisdescripcion, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Paisdescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_paisdescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_paisdescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_estadodescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_estadodescripcion_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_estadodescripcion_Internalname, AV5Usuario.gxTpr_Estadodescripcion, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Estadodescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_estadodescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_estadodescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_ciudaddescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_ciudaddescripcion_Internalname, context.GetMessage( "Ciudad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_ciudaddescripcion_Internalname, AV5Usuario.gxTpr_Ciudaddescripcion, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Ciudaddescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_ciudaddescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_ciudaddescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariosucursal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariosucursal_Internalname, context.GetMessage( "Sucursal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariosucursal_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariosucursal), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariosucursal, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariosucursal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariosucursal_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuarioproducto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuarioproducto_Internalname, context.GetMessage( "Producto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuarioproducto, cmbavUsuario_usuarioproducto_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioproducto), 1, cmbavUsuario_usuarioproducto_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavUsuario_usuarioproducto.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "", false, 0, "HLP_WCDetalleUsuarioCol.htm");
            cmbavUsuario_usuarioproducto.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioproducto);
            AssignProp(sPrefix, false, cmbavUsuario_usuarioproducto_Internalname, "Values", (string)(cmbavUsuario_usuarioproducto.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_paisid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Paisid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Paisid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,123);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_paisid_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuario_paisid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_WCDetalleUsuarioCol.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_estadoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Estadoid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Estadoid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,124);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_estadoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuario_estadoid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_WCDetalleUsuarioCol.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_ciudadid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Ciudadid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Ciudadid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,125);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_ciudadid_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuario_ciudadid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_WCDetalleUsuarioCol.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Usuarioid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuarioid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,126);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuario_usuarioid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_WCDetalleUsuarioCol.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarionombrecompleto_Internalname, AV5Usuario.gxTpr_Usuarionombrecompleto, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuarionombrecompleto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarionombrecompleto_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuario_usuarionombrecompleto_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariopass_Internalname, AV5Usuario.gxTpr_Usuariopass, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariopass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariopass_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuario_usuariopass_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariokey_Internalname, AV5Usuario.gxTpr_Usuariokey, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariokey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariokey_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuario_usuariokey_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WCDetalleUsuarioCol.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_puestoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Puestoid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Puestoid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,130);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_puestoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuario_puestoid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_WCDetalleUsuarioCol.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START352( )
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
            Form.Meta.addItem("description", context.GetMessage( "WCDetalle Usuario Col", ""), 0) ;
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
               STRUP350( ) ;
            }
         }
      }

      protected void WS352( )
      {
         START352( ) ;
         EVT352( ) ;
      }

      protected void EVT352( )
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
                                 STRUP350( ) ;
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
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11352 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12352 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP350( ) ;
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
                                 STRUP350( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavUsuario_usuarionombre_Internalname;
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

      protected void WE352( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm352( ) ;
            }
         }
      }

      protected void PA352( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wcdetalleusuariocol.aspx")), "wcdetalleusuariocol.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wcdetalleusuariocol.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "UsuarioID");
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
               GX_FocusControl = edtavUsuario_usuarionombre_Internalname;
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
         if ( cmbavUsuario_usuariogenero.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariogenero = cmbavUsuario_usuariogenero.getValidValue(AV5Usuario.gxTpr_Usuariogenero);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuariogenero.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariogenero);
            AssignProp(sPrefix, false, cmbavUsuario_usuariogenero_Internalname, "Values", cmbavUsuario_usuariogenero.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuariodirectoasociado.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariodirectoasociado = cmbavUsuario_usuariodirectoasociado.getValidValue(AV5Usuario.gxTpr_Usuariodirectoasociado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuariodirectoasociado.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariodirectoasociado);
            AssignProp(sPrefix, false, cmbavUsuario_usuariodirectoasociado_Internalname, "Values", cmbavUsuario_usuariodirectoasociado.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuariorol.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariorol = cmbavUsuario_usuariorol.getValidValue(AV5Usuario.gxTpr_Usuariorol);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuariorol.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariorol);
            AssignProp(sPrefix, false, cmbavUsuario_usuariorol_Internalname, "Values", cmbavUsuario_usuariorol.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuariozona.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariozona = cmbavUsuario_usuariozona.getValidValue(AV5Usuario.gxTpr_Usuariozona);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuariozona.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariozona);
            AssignProp(sPrefix, false, cmbavUsuario_usuariozona_Internalname, "Values", cmbavUsuario_usuariozona.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuarioproducto.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuarioproducto = cmbavUsuario_usuarioproducto.getValidValue(AV5Usuario.gxTpr_Usuarioproducto);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuarioproducto.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioproducto);
            AssignProp(sPrefix, false, cmbavUsuario_usuarioproducto_Internalname, "Values", cmbavUsuario_usuarioproducto.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF352( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavUsuario_usuarionombre_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuarionombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarionombre_Enabled), 5, 0), true);
         edtavUsuario_usuarioapellido_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuarioapellido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarioapellido_Enabled), 5, 0), true);
         edtavUsuario_usuariocorreo_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariocorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocorreo_Enabled), 5, 0), true);
         edtavUsuario_puestodescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_puestodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_puestodescripcion_Enabled), 5, 0), true);
         cmbavUsuario_usuariogenero.Enabled = 0;
         AssignProp(sPrefix, false, cmbavUsuario_usuariogenero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariogenero.Enabled), 5, 0), true);
         cmbavUsuario_usuariodirectoasociado.Enabled = 0;
         AssignProp(sPrefix, false, cmbavUsuario_usuariodirectoasociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariodirectoasociado.Enabled), 5, 0), true);
         edtavUsuario_usuariorazonsocialasociado_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariorazonsocialasociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariorazonsocialasociado_Enabled), 5, 0), true);
         edtavUsuario_usuarionombrecomercial_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuarionombrecomercial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarionombrecomercial_Enabled), 5, 0), true);
         edtavUsuario_usuariofechanacimiento_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariofechanacimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariofechanacimiento_Enabled), 5, 0), true);
         edtavUsuario_usuariocolonia_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariocolonia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocolonia_Enabled), 5, 0), true);
         edtavUsuario_usuariocallenum_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariocallenum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocallenum_Enabled), 5, 0), true);
         edtavUsuario_usuariodelegacion_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariodelegacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariodelegacion_Enabled), 5, 0), true);
         cmbavUsuario_usuariorol.Enabled = 0;
         AssignProp(sPrefix, false, cmbavUsuario_usuariorol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariorol.Enabled), 5, 0), true);
         edtavUsuario_usuariocelular_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariocelular_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocelular_Enabled), 5, 0), true);
         edtavUsuario_usuariocp_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariocp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocp_Enabled), 5, 0), true);
         cmbavUsuario_usuariozona.Enabled = 0;
         AssignProp(sPrefix, false, cmbavUsuario_usuariozona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariozona.Enabled), 5, 0), true);
         edtavUsuario_usuariotelefonosucursal_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariotelefonosucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariotelefonosucursal_Enabled), 5, 0), true);
         edtavUsuario_paisdescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_paisdescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_paisdescripcion_Enabled), 5, 0), true);
         edtavUsuario_estadodescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_estadodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_estadodescripcion_Enabled), 5, 0), true);
         edtavUsuario_ciudaddescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_ciudaddescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_ciudaddescripcion_Enabled), 5, 0), true);
         edtavUsuario_usuariosucursal_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariosucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariosucursal_Enabled), 5, 0), true);
         cmbavUsuario_usuarioproducto.Enabled = 0;
         AssignProp(sPrefix, false, cmbavUsuario_usuarioproducto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuarioproducto.Enabled), 5, 0), true);
      }

      protected void RF352( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12352 ();
            WB350( ) ;
         }
      }

      protected void send_integrity_lvl_hashes352( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavUsuario_usuarionombre_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuarionombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarionombre_Enabled), 5, 0), true);
         edtavUsuario_usuarioapellido_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuarioapellido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarioapellido_Enabled), 5, 0), true);
         edtavUsuario_usuariocorreo_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariocorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocorreo_Enabled), 5, 0), true);
         edtavUsuario_puestodescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_puestodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_puestodescripcion_Enabled), 5, 0), true);
         cmbavUsuario_usuariogenero.Enabled = 0;
         AssignProp(sPrefix, false, cmbavUsuario_usuariogenero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariogenero.Enabled), 5, 0), true);
         cmbavUsuario_usuariodirectoasociado.Enabled = 0;
         AssignProp(sPrefix, false, cmbavUsuario_usuariodirectoasociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariodirectoasociado.Enabled), 5, 0), true);
         edtavUsuario_usuariorazonsocialasociado_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariorazonsocialasociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariorazonsocialasociado_Enabled), 5, 0), true);
         edtavUsuario_usuarionombrecomercial_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuarionombrecomercial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarionombrecomercial_Enabled), 5, 0), true);
         edtavUsuario_usuariofechanacimiento_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariofechanacimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariofechanacimiento_Enabled), 5, 0), true);
         edtavUsuario_usuariocolonia_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariocolonia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocolonia_Enabled), 5, 0), true);
         edtavUsuario_usuariocallenum_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariocallenum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocallenum_Enabled), 5, 0), true);
         edtavUsuario_usuariodelegacion_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariodelegacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariodelegacion_Enabled), 5, 0), true);
         cmbavUsuario_usuariorol.Enabled = 0;
         AssignProp(sPrefix, false, cmbavUsuario_usuariorol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariorol.Enabled), 5, 0), true);
         edtavUsuario_usuariocelular_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariocelular_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocelular_Enabled), 5, 0), true);
         edtavUsuario_usuariocp_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariocp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariocp_Enabled), 5, 0), true);
         cmbavUsuario_usuariozona.Enabled = 0;
         AssignProp(sPrefix, false, cmbavUsuario_usuariozona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariozona.Enabled), 5, 0), true);
         edtavUsuario_usuariotelefonosucursal_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariotelefonosucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariotelefonosucursal_Enabled), 5, 0), true);
         edtavUsuario_paisdescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_paisdescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_paisdescripcion_Enabled), 5, 0), true);
         edtavUsuario_estadodescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_estadodescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_estadodescripcion_Enabled), 5, 0), true);
         edtavUsuario_ciudaddescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_ciudaddescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_ciudaddescripcion_Enabled), 5, 0), true);
         edtavUsuario_usuariosucursal_Enabled = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariosucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariosucursal_Enabled), 5, 0), true);
         cmbavUsuario_usuarioproducto.Enabled = 0;
         AssignProp(sPrefix, false, cmbavUsuario_usuarioproducto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuarioproducto.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP350( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11352 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUSUARIO"), AV5Usuario);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Usuario"), AV5Usuario);
            /* Read saved values. */
            wcpOAV6UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6UsuarioID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         E11352 ();
         if (returnInSub) return;
      }

      protected void E11352( )
      {
         /* Start Routine */
         returnInSub = false;
         AV5Usuario.Load(AV6UsuarioID);
         edtavUsuario_paisid_Visible = 0;
         AssignProp(sPrefix, false, edtavUsuario_paisid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuario_paisid_Visible), 5, 0), true);
         edtavUsuario_estadoid_Visible = 0;
         AssignProp(sPrefix, false, edtavUsuario_estadoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuario_estadoid_Visible), 5, 0), true);
         edtavUsuario_ciudadid_Visible = 0;
         AssignProp(sPrefix, false, edtavUsuario_ciudadid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuario_ciudadid_Visible), 5, 0), true);
         edtavUsuario_usuarioid_Visible = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuarioid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarioid_Visible), 5, 0), true);
         edtavUsuario_usuarionombrecompleto_Visible = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuarionombrecompleto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarionombrecompleto_Visible), 5, 0), true);
         edtavUsuario_usuariopass_Visible = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariopass_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariopass_Visible), 5, 0), true);
         edtavUsuario_usuariokey_Visible = 0;
         AssignProp(sPrefix, false, edtavUsuario_usuariokey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuariokey_Visible), 5, 0), true);
         edtavUsuario_puestoid_Visible = 0;
         AssignProp(sPrefix, false, edtavUsuario_puestoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuario_puestoid_Visible), 5, 0), true);
      }

      protected void nextLoad( )
      {
      }

      protected void E12352( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6UsuarioID = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV6UsuarioID", StringUtil.LTrimStr( (decimal)(AV6UsuarioID), 9, 0));
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
         PA352( ) ;
         WS352( ) ;
         WE352( ) ;
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
         sCtrlAV6UsuarioID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA352( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcdetalleusuariocol", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA352( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6UsuarioID = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV6UsuarioID", StringUtil.LTrimStr( (decimal)(AV6UsuarioID), 9, 0));
         }
         wcpOAV6UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6UsuarioID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV6UsuarioID != wcpOAV6UsuarioID ) ) )
         {
            setjustcreated();
         }
         wcpOAV6UsuarioID = AV6UsuarioID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6UsuarioID = cgiGet( sPrefix+"AV6UsuarioID_CTRL");
         if ( StringUtil.Len( sCtrlAV6UsuarioID) > 0 )
         {
            AV6UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV6UsuarioID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV6UsuarioID", StringUtil.LTrimStr( (decimal)(AV6UsuarioID), 9, 0));
         }
         else
         {
            AV6UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV6UsuarioID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA352( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS352( ) ;
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
         WS352( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6UsuarioID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6UsuarioID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6UsuarioID_CTRL", StringUtil.RTrim( sCtrlAV6UsuarioID));
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
         WE352( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202651111305271", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("wcdetalleusuariocol.js", "?202651111305271", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavUsuario_usuariogenero.Name = "USUARIO_USUARIOGENERO";
         cmbavUsuario_usuariogenero.WebTags = "";
         cmbavUsuario_usuariogenero.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavUsuario_usuariogenero.addItem("Masculino", context.GetMessage( "Masculino", ""), 0);
         cmbavUsuario_usuariogenero.addItem("Femenino", context.GetMessage( "Femenino", ""), 0);
         if ( cmbavUsuario_usuariogenero.ItemCount > 0 )
         {
         }
         cmbavUsuario_usuariodirectoasociado.Name = "USUARIO_USUARIODIRECTOASOCIADO";
         cmbavUsuario_usuariodirectoasociado.WebTags = "";
         cmbavUsuario_usuariodirectoasociado.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavUsuario_usuariodirectoasociado.addItem("Directo", context.GetMessage( "Directo", ""), 0);
         cmbavUsuario_usuariodirectoasociado.addItem("Asociado", context.GetMessage( "Asociado", ""), 0);
         if ( cmbavUsuario_usuariodirectoasociado.ItemCount > 0 )
         {
         }
         cmbavUsuario_usuariorol.Name = "USUARIO_USUARIOROL";
         cmbavUsuario_usuariorol.WebTags = "";
         cmbavUsuario_usuariorol.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavUsuario_usuariorol.addItem("Super Administrador", context.GetMessage( "Super Administrador", ""), 0);
         cmbavUsuario_usuariorol.addItem("Administrador Yokohama", context.GetMessage( "Administrador Yokohama", ""), 0);
         cmbavUsuario_usuariorol.addItem("Asesor", context.GetMessage( "Asesor", ""), 0);
         cmbavUsuario_usuariorol.addItem("Participante", context.GetMessage( "Participante", ""), 0);
         if ( cmbavUsuario_usuariorol.ItemCount > 0 )
         {
         }
         cmbavUsuario_usuariozona.Name = "USUARIO_USUARIOZONA";
         cmbavUsuario_usuariozona.WebTags = "";
         cmbavUsuario_usuariozona.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavUsuario_usuariozona.addItem("Centro", context.GetMessage( "Centro", ""), 0);
         cmbavUsuario_usuariozona.addItem("Centro América", context.GetMessage( "Centro América", ""), 0);
         cmbavUsuario_usuariozona.addItem("Norte", context.GetMessage( "Norte", ""), 0);
         cmbavUsuario_usuariozona.addItem("Pacífico", context.GetMessage( "Pacifico", ""), 0);
         cmbavUsuario_usuariozona.addItem("Sur", context.GetMessage( "Sur", ""), 0);
         if ( cmbavUsuario_usuariozona.ItemCount > 0 )
         {
         }
         cmbavUsuario_usuarioproducto.Name = "USUARIO_USUARIOPRODUCTO";
         cmbavUsuario_usuarioproducto.WebTags = "";
         cmbavUsuario_usuarioproducto.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavUsuario_usuarioproducto.addItem("Auto y Camioneta", context.GetMessage( "Auto y Camioneta", ""), 0);
         cmbavUsuario_usuarioproducto.addItem("Auto y Camioneta/Camión", context.GetMessage( "Auto y Camioneta/Camión", ""), 0);
         cmbavUsuario_usuarioproducto.addItem("Camión", context.GetMessage( "Camión", ""), 0);
         cmbavUsuario_usuarioproducto.addItem("Empleado", context.GetMessage( "Empleado", ""), 0);
         cmbavUsuario_usuarioproducto.addItem("OTR/Camión", context.GetMessage( "OTR/Camión", ""), 0);
         if ( cmbavUsuario_usuarioproducto.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavUsuario_usuarionombre_Internalname = sPrefix+"USUARIO_USUARIONOMBRE";
         edtavUsuario_usuarioapellido_Internalname = sPrefix+"USUARIO_USUARIOAPELLIDO";
         edtavUsuario_usuariocorreo_Internalname = sPrefix+"USUARIO_USUARIOCORREO";
         edtavUsuario_puestodescripcion_Internalname = sPrefix+"USUARIO_PUESTODESCRIPCION";
         cmbavUsuario_usuariogenero_Internalname = sPrefix+"USUARIO_USUARIOGENERO";
         cmbavUsuario_usuariodirectoasociado_Internalname = sPrefix+"USUARIO_USUARIODIRECTOASOCIADO";
         edtavUsuario_usuariorazonsocialasociado_Internalname = sPrefix+"USUARIO_USUARIORAZONSOCIALASOCIADO";
         edtavUsuario_usuarionombrecomercial_Internalname = sPrefix+"USUARIO_USUARIONOMBRECOMERCIAL";
         edtavUsuario_usuariofechanacimiento_Internalname = sPrefix+"USUARIO_USUARIOFECHANACIMIENTO";
         edtavUsuario_usuariocolonia_Internalname = sPrefix+"USUARIO_USUARIOCOLONIA";
         edtavUsuario_usuariocallenum_Internalname = sPrefix+"USUARIO_USUARIOCALLENUM";
         edtavUsuario_usuariodelegacion_Internalname = sPrefix+"USUARIO_USUARIODELEGACION";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         cmbavUsuario_usuariorol_Internalname = sPrefix+"USUARIO_USUARIOROL";
         edtavUsuario_usuariocelular_Internalname = sPrefix+"USUARIO_USUARIOCELULAR";
         edtavUsuario_usuariocp_Internalname = sPrefix+"USUARIO_USUARIOCP";
         cmbavUsuario_usuariozona_Internalname = sPrefix+"USUARIO_USUARIOZONA";
         edtavUsuario_usuariotelefonosucursal_Internalname = sPrefix+"USUARIO_USUARIOTELEFONOSUCURSAL";
         edtavUsuario_paisdescripcion_Internalname = sPrefix+"USUARIO_PAISDESCRIPCION";
         edtavUsuario_estadodescripcion_Internalname = sPrefix+"USUARIO_ESTADODESCRIPCION";
         edtavUsuario_ciudaddescripcion_Internalname = sPrefix+"USUARIO_CIUDADDESCRIPCION";
         edtavUsuario_usuariosucursal_Internalname = sPrefix+"USUARIO_USUARIOSUCURSAL";
         cmbavUsuario_usuarioproducto_Internalname = sPrefix+"USUARIO_USUARIOPRODUCTO";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavUsuario_paisid_Internalname = sPrefix+"USUARIO_PAISID";
         edtavUsuario_estadoid_Internalname = sPrefix+"USUARIO_ESTADOID";
         edtavUsuario_ciudadid_Internalname = sPrefix+"USUARIO_CIUDADID";
         edtavUsuario_usuarioid_Internalname = sPrefix+"USUARIO_USUARIOID";
         edtavUsuario_usuarionombrecompleto_Internalname = sPrefix+"USUARIO_USUARIONOMBRECOMPLETO";
         edtavUsuario_usuariopass_Internalname = sPrefix+"USUARIO_USUARIOPASS";
         edtavUsuario_usuariokey_Internalname = sPrefix+"USUARIO_USUARIOKEY";
         edtavUsuario_puestoid_Internalname = sPrefix+"USUARIO_PUESTOID";
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
         edtavUsuario_puestoid_Jsonclick = "";
         edtavUsuario_puestoid_Visible = 1;
         edtavUsuario_usuariokey_Jsonclick = "";
         edtavUsuario_usuariokey_Visible = 1;
         edtavUsuario_usuariopass_Jsonclick = "";
         edtavUsuario_usuariopass_Visible = 1;
         edtavUsuario_usuarionombrecompleto_Jsonclick = "";
         edtavUsuario_usuarionombrecompleto_Visible = 1;
         edtavUsuario_usuarioid_Jsonclick = "";
         edtavUsuario_usuarioid_Visible = 1;
         edtavUsuario_ciudadid_Jsonclick = "";
         edtavUsuario_ciudadid_Visible = 1;
         edtavUsuario_estadoid_Jsonclick = "";
         edtavUsuario_estadoid_Visible = 1;
         edtavUsuario_paisid_Jsonclick = "";
         edtavUsuario_paisid_Visible = 1;
         cmbavUsuario_usuarioproducto_Jsonclick = "";
         cmbavUsuario_usuarioproducto.Enabled = 0;
         edtavUsuario_usuariosucursal_Jsonclick = "";
         edtavUsuario_usuariosucursal_Enabled = 0;
         edtavUsuario_ciudaddescripcion_Jsonclick = "";
         edtavUsuario_ciudaddescripcion_Enabled = 0;
         edtavUsuario_estadodescripcion_Jsonclick = "";
         edtavUsuario_estadodescripcion_Enabled = 0;
         edtavUsuario_paisdescripcion_Jsonclick = "";
         edtavUsuario_paisdescripcion_Enabled = 0;
         edtavUsuario_usuariotelefonosucursal_Jsonclick = "";
         edtavUsuario_usuariotelefonosucursal_Enabled = 0;
         cmbavUsuario_usuariozona_Jsonclick = "";
         cmbavUsuario_usuariozona.Enabled = 0;
         edtavUsuario_usuariocp_Jsonclick = "";
         edtavUsuario_usuariocp_Enabled = 0;
         edtavUsuario_usuariocelular_Jsonclick = "";
         edtavUsuario_usuariocelular_Enabled = 0;
         cmbavUsuario_usuariorol_Jsonclick = "";
         cmbavUsuario_usuariorol.Enabled = 0;
         edtavUsuario_usuariodelegacion_Jsonclick = "";
         edtavUsuario_usuariodelegacion_Enabled = 0;
         edtavUsuario_usuariocallenum_Jsonclick = "";
         edtavUsuario_usuariocallenum_Enabled = 0;
         edtavUsuario_usuariocolonia_Jsonclick = "";
         edtavUsuario_usuariocolonia_Enabled = 0;
         edtavUsuario_usuariofechanacimiento_Jsonclick = "";
         edtavUsuario_usuariofechanacimiento_Enabled = 0;
         edtavUsuario_usuarionombrecomercial_Jsonclick = "";
         edtavUsuario_usuarionombrecomercial_Enabled = 0;
         edtavUsuario_usuariorazonsocialasociado_Jsonclick = "";
         edtavUsuario_usuariorazonsocialasociado_Enabled = 0;
         cmbavUsuario_usuariodirectoasociado_Jsonclick = "";
         cmbavUsuario_usuariodirectoasociado.Enabled = 0;
         cmbavUsuario_usuariogenero_Jsonclick = "";
         cmbavUsuario_usuariogenero.Enabled = 0;
         edtavUsuario_puestodescripcion_Jsonclick = "";
         edtavUsuario_puestodescripcion_Enabled = 0;
         edtavUsuario_usuariocorreo_Jsonclick = "";
         edtavUsuario_usuariocorreo_Enabled = 0;
         edtavUsuario_usuarioapellido_Jsonclick = "";
         edtavUsuario_usuarioapellido_Enabled = 0;
         edtavUsuario_usuarionombre_Jsonclick = "";
         edtavUsuario_usuarionombre_Enabled = 0;
         cmbavUsuario_usuarioproducto.Enabled = -1;
         edtavUsuario_usuariosucursal_Enabled = -1;
         edtavUsuario_ciudaddescripcion_Enabled = -1;
         edtavUsuario_estadodescripcion_Enabled = -1;
         edtavUsuario_paisdescripcion_Enabled = -1;
         edtavUsuario_usuariotelefonosucursal_Enabled = -1;
         cmbavUsuario_usuariozona.Enabled = -1;
         edtavUsuario_usuariocp_Enabled = -1;
         edtavUsuario_usuariocelular_Enabled = -1;
         cmbavUsuario_usuariorol.Enabled = -1;
         edtavUsuario_usuariodelegacion_Enabled = -1;
         edtavUsuario_usuariocallenum_Enabled = -1;
         edtavUsuario_usuariocolonia_Enabled = -1;
         edtavUsuario_usuariofechanacimiento_Enabled = -1;
         edtavUsuario_usuarionombrecomercial_Enabled = -1;
         edtavUsuario_usuariorazonsocialasociado_Enabled = -1;
         cmbavUsuario_usuariodirectoasociado.Enabled = -1;
         cmbavUsuario_usuariogenero.Enabled = -1;
         edtavUsuario_puestodescripcion_Enabled = -1;
         edtavUsuario_usuariocorreo_Enabled = -1;
         edtavUsuario_usuarioapellido_Enabled = -1;
         edtavUsuario_usuarionombre_Enabled = -1;
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
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV5","""{"handler":"Validv_Gxv5","iparms":[]}""");
         setEventMetadata("VALIDV_GXV6","""{"handler":"Validv_Gxv6","iparms":[]}""");
         setEventMetadata("VALIDV_GXV13","""{"handler":"Validv_Gxv13","iparms":[]}""");
         setEventMetadata("VALIDV_GXV16","""{"handler":"Validv_Gxv16","iparms":[]}""");
         setEventMetadata("VALIDV_GXV22","""{"handler":"Validv_Gxv22","iparms":[]}""");
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
         AV5Usuario = new SdtUsuario(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6UsuarioID = "";
         /* GeneXus formulas. */
         edtavUsuario_usuarionombre_Enabled = 0;
         edtavUsuario_usuarioapellido_Enabled = 0;
         edtavUsuario_usuariocorreo_Enabled = 0;
         edtavUsuario_puestodescripcion_Enabled = 0;
         cmbavUsuario_usuariogenero.Enabled = 0;
         cmbavUsuario_usuariodirectoasociado.Enabled = 0;
         edtavUsuario_usuariorazonsocialasociado_Enabled = 0;
         edtavUsuario_usuarionombrecomercial_Enabled = 0;
         edtavUsuario_usuariofechanacimiento_Enabled = 0;
         edtavUsuario_usuariocolonia_Enabled = 0;
         edtavUsuario_usuariocallenum_Enabled = 0;
         edtavUsuario_usuariodelegacion_Enabled = 0;
         cmbavUsuario_usuariorol.Enabled = 0;
         edtavUsuario_usuariocelular_Enabled = 0;
         edtavUsuario_usuariocp_Enabled = 0;
         cmbavUsuario_usuariozona.Enabled = 0;
         edtavUsuario_usuariotelefonosucursal_Enabled = 0;
         edtavUsuario_paisdescripcion_Enabled = 0;
         edtavUsuario_estadodescripcion_Enabled = 0;
         edtavUsuario_ciudaddescripcion_Enabled = 0;
         edtavUsuario_usuariosucursal_Enabled = 0;
         cmbavUsuario_usuarioproducto.Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private int AV6UsuarioID ;
      private int wcpOAV6UsuarioID ;
      private int edtavUsuario_usuarionombre_Enabled ;
      private int edtavUsuario_usuarioapellido_Enabled ;
      private int edtavUsuario_usuariocorreo_Enabled ;
      private int edtavUsuario_puestodescripcion_Enabled ;
      private int edtavUsuario_usuariorazonsocialasociado_Enabled ;
      private int edtavUsuario_usuarionombrecomercial_Enabled ;
      private int edtavUsuario_usuariofechanacimiento_Enabled ;
      private int edtavUsuario_usuariocolonia_Enabled ;
      private int edtavUsuario_usuariocallenum_Enabled ;
      private int edtavUsuario_usuariodelegacion_Enabled ;
      private int edtavUsuario_usuariocelular_Enabled ;
      private int edtavUsuario_usuariocp_Enabled ;
      private int edtavUsuario_usuariotelefonosucursal_Enabled ;
      private int edtavUsuario_paisdescripcion_Enabled ;
      private int edtavUsuario_estadodescripcion_Enabled ;
      private int edtavUsuario_ciudaddescripcion_Enabled ;
      private int edtavUsuario_usuariosucursal_Enabled ;
      private int edtavUsuario_paisid_Visible ;
      private int edtavUsuario_estadoid_Visible ;
      private int edtavUsuario_ciudadid_Visible ;
      private int edtavUsuario_usuarioid_Visible ;
      private int edtavUsuario_usuarionombrecompleto_Visible ;
      private int edtavUsuario_usuariopass_Visible ;
      private int edtavUsuario_usuariokey_Visible ;
      private int edtavUsuario_puestoid_Visible ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavUsuario_usuarionombre_Internalname ;
      private string edtavUsuario_usuarioapellido_Internalname ;
      private string edtavUsuario_usuariocorreo_Internalname ;
      private string edtavUsuario_puestodescripcion_Internalname ;
      private string cmbavUsuario_usuariogenero_Internalname ;
      private string cmbavUsuario_usuariodirectoasociado_Internalname ;
      private string edtavUsuario_usuariorazonsocialasociado_Internalname ;
      private string edtavUsuario_usuarionombrecomercial_Internalname ;
      private string edtavUsuario_usuariofechanacimiento_Internalname ;
      private string edtavUsuario_usuariocolonia_Internalname ;
      private string edtavUsuario_usuariocallenum_Internalname ;
      private string edtavUsuario_usuariodelegacion_Internalname ;
      private string cmbavUsuario_usuariorol_Internalname ;
      private string edtavUsuario_usuariocelular_Internalname ;
      private string edtavUsuario_usuariocp_Internalname ;
      private string cmbavUsuario_usuariozona_Internalname ;
      private string edtavUsuario_usuariotelefonosucursal_Internalname ;
      private string edtavUsuario_paisdescripcion_Internalname ;
      private string edtavUsuario_estadodescripcion_Internalname ;
      private string edtavUsuario_ciudaddescripcion_Internalname ;
      private string edtavUsuario_usuariosucursal_Internalname ;
      private string cmbavUsuario_usuarioproducto_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string TempTags ;
      private string edtavUsuario_usuarionombre_Jsonclick ;
      private string edtavUsuario_usuarioapellido_Jsonclick ;
      private string edtavUsuario_usuariocorreo_Jsonclick ;
      private string edtavUsuario_puestodescripcion_Jsonclick ;
      private string cmbavUsuario_usuariogenero_Jsonclick ;
      private string cmbavUsuario_usuariodirectoasociado_Jsonclick ;
      private string edtavUsuario_usuariorazonsocialasociado_Jsonclick ;
      private string edtavUsuario_usuarionombrecomercial_Jsonclick ;
      private string edtavUsuario_usuariofechanacimiento_Jsonclick ;
      private string edtavUsuario_usuariocolonia_Jsonclick ;
      private string edtavUsuario_usuariocallenum_Jsonclick ;
      private string edtavUsuario_usuariodelegacion_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string cmbavUsuario_usuariorol_Jsonclick ;
      private string edtavUsuario_usuariocelular_Jsonclick ;
      private string edtavUsuario_usuariocp_Jsonclick ;
      private string cmbavUsuario_usuariozona_Jsonclick ;
      private string edtavUsuario_usuariotelefonosucursal_Jsonclick ;
      private string edtavUsuario_paisdescripcion_Jsonclick ;
      private string edtavUsuario_estadodescripcion_Jsonclick ;
      private string edtavUsuario_ciudaddescripcion_Jsonclick ;
      private string edtavUsuario_usuariosucursal_Jsonclick ;
      private string cmbavUsuario_usuarioproducto_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavUsuario_paisid_Internalname ;
      private string edtavUsuario_paisid_Jsonclick ;
      private string edtavUsuario_estadoid_Internalname ;
      private string edtavUsuario_estadoid_Jsonclick ;
      private string edtavUsuario_ciudadid_Internalname ;
      private string edtavUsuario_ciudadid_Jsonclick ;
      private string edtavUsuario_usuarioid_Internalname ;
      private string edtavUsuario_usuarioid_Jsonclick ;
      private string edtavUsuario_usuarionombrecompleto_Internalname ;
      private string edtavUsuario_usuarionombrecompleto_Jsonclick ;
      private string edtavUsuario_usuariopass_Internalname ;
      private string edtavUsuario_usuariopass_Jsonclick ;
      private string edtavUsuario_usuariokey_Internalname ;
      private string edtavUsuario_usuariokey_Jsonclick ;
      private string edtavUsuario_puestoid_Internalname ;
      private string edtavUsuario_puestoid_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlAV6UsuarioID ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavUsuario_usuariogenero ;
      private GXCombobox cmbavUsuario_usuariodirectoasociado ;
      private GXCombobox cmbavUsuario_usuariorol ;
      private GXCombobox cmbavUsuario_usuariozona ;
      private GXCombobox cmbavUsuario_usuarioproducto ;
      private SdtUsuario AV5Usuario ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
