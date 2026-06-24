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
   public class wpusuariodetallegeneral : GXWebComponent
   {
      public wpusuariodetallegeneral( )
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

      public wpusuariodetallegeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_UsuarioID )
      {
         this.A29UsuarioID = aP0_UsuarioID;
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
         cmbUsuarioGenero = new GXCombobox();
         cmbUsuarioDirectoAsociado = new GXCombobox();
         cmbUsuarioZona = new GXCombobox();
         cmbUsuarioProducto = new GXCombobox();
         cmbUsuarioRol = new GXCombobox();
         chkUsuarioAvisoPrivacidad = new GXCheckbox();
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
                  A29UsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "UsuarioID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)A29UsuarioID});
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
            PA322( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV11Pgmname = "WPUsuarioDetalleGeneral";
               WS322( ) ;
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
            context.SendWebValue( context.GetMessage( "WPUsuario Detalle General", "")) ;
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
               GXEncryptionTmp = "wpusuariodetallegeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A29UsuarioID,9,0));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpusuariodetallegeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA29UsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseForm322( )
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
         return "WPUsuarioDetalleGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WPUsuario Detalle General", "") ;
      }

      protected void WB320( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpusuariodetallegeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtUsuarioID_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioID_Internalname, context.GetMessage( "ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioID_Enabled!=0) ? context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioID_Jsonclick, 0, "AttributeFL", "", "", "", "", edtUsuarioID_Visible, edtUsuarioID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioNombre_Internalname, StringUtil.RTrim( A30UsuarioNombre), StringUtil.RTrim( context.localUtil.Format( A30UsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioNombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioApellido_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioApellido_Internalname, context.GetMessage( "Apellido(s)", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioApellido_Internalname, StringUtil.RTrim( A51UsuarioApellido), StringUtil.RTrim( context.localUtil.Format( A51UsuarioApellido, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioApellido_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioApellido_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtUsuarioNombreCompleto_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioNombreCompleto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioNombreCompleto_Internalname, context.GetMessage( "Nombre completo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioNombreCompleto_Internalname, A52UsuarioNombreCompleto, StringUtil.RTrim( context.localUtil.Format( A52UsuarioNombreCompleto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombreCompleto_Jsonclick, 0, "AttributeFL", "", "", "", "", edtUsuarioNombreCompleto_Visible, edtUsuarioNombreCompleto_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioCorreo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioCorreo_Internalname, context.GetMessage( "Correo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioCorreo_Internalname, A31UsuarioCorreo, StringUtil.RTrim( context.localUtil.Format( A31UsuarioCorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A31UsuarioCorreo, "", "", "", edtUsuarioCorreo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioCorreo_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtUsuarioPass_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioPass_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioPass_Internalname, context.GetMessage( "Pass", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioPass_Internalname, A32UsuarioPass, StringUtil.RTrim( context.localUtil.Format( A32UsuarioPass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioPass_Jsonclick, 0, "AttributeFL", "", "", "", "", edtUsuarioPass_Visible, edtUsuarioPass_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtUsuarioKey_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioKey_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioKey_Internalname, context.GetMessage( "Key", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioKey_Internalname, A33UsuarioKey, StringUtil.RTrim( context.localUtil.Format( A33UsuarioKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioKey_Jsonclick, 0, "AttributeFL", "", "", "", "", edtUsuarioKey_Visible, edtUsuarioKey_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPuestoDescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPuestoDescripcion_Internalname, context.GetMessage( "Puesto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPuestoDescripcion_Internalname, A14PuestoDescripcion, StringUtil.RTrim( context.localUtil.Format( A14PuestoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPuestoDescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPuestoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbUsuarioGenero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbUsuarioGenero_Internalname, context.GetMessage( "Género", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioGenero, cmbUsuarioGenero_Internalname, StringUtil.RTrim( A53UsuarioGenero), 1, cmbUsuarioGenero_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioGenero.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_WPUsuarioDetalleGeneral.htm");
            cmbUsuarioGenero.CurrentValue = StringUtil.RTrim( A53UsuarioGenero);
            AssignProp(sPrefix, false, cmbUsuarioGenero_Internalname, "Values", (string)(cmbUsuarioGenero.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbUsuarioDirectoAsociado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbUsuarioDirectoAsociado_Internalname, context.GetMessage( "Directo/Asociado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioDirectoAsociado, cmbUsuarioDirectoAsociado_Internalname, StringUtil.RTrim( A54UsuarioDirectoAsociado), 1, cmbUsuarioDirectoAsociado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioDirectoAsociado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_WPUsuarioDetalleGeneral.htm");
            cmbUsuarioDirectoAsociado.CurrentValue = StringUtil.RTrim( A54UsuarioDirectoAsociado);
            AssignProp(sPrefix, false, cmbUsuarioDirectoAsociado_Internalname, "Values", (string)(cmbUsuarioDirectoAsociado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioRazonSocialAsociado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioRazonSocialAsociado_Internalname, context.GetMessage( "Razón Social Asociado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioRazonSocialAsociado_Internalname, A55UsuarioRazonSocialAsociado, StringUtil.RTrim( context.localUtil.Format( A55UsuarioRazonSocialAsociado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioRazonSocialAsociado_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioRazonSocialAsociado_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioNombreComercial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioNombreComercial_Internalname, context.GetMessage( "Nombre Comercial", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioNombreComercial_Internalname, A56UsuarioNombreComercial, StringUtil.RTrim( context.localUtil.Format( A56UsuarioNombreComercial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombreComercial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioNombreComercial_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioFechaNacimiento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioFechaNacimiento_Internalname, context.GetMessage( "Fecha de nacimiento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtUsuarioFechaNacimiento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtUsuarioFechaNacimiento_Internalname, context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"), context.localUtil.Format( A57UsuarioFechaNacimiento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioFechaNacimiento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioFechaNacimiento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_bitmap( context, edtUsuarioFechaNacimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuarioFechaNacimiento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPUsuarioDetalleGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioCalleNum_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioCalleNum_Internalname, context.GetMessage( "Calle y número", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioCalleNum_Internalname, StringUtil.RTrim( A59UsuarioCalleNum), StringUtil.RTrim( context.localUtil.Format( A59UsuarioCalleNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioCalleNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioCalleNum_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioColonia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioColonia_Internalname, context.GetMessage( "Colonia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioColonia_Internalname, StringUtil.RTrim( A60UsuarioColonia), StringUtil.RTrim( context.localUtil.Format( A60UsuarioColonia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioColonia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioColonia_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioDelegacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioDelegacion_Internalname, context.GetMessage( "Delegación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioDelegacion_Internalname, StringUtil.RTrim( A61UsuarioDelegacion), StringUtil.RTrim( context.localUtil.Format( A61UsuarioDelegacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioDelegacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioDelegacion_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioCP_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioCP_Internalname, context.GetMessage( "Código Postal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioCP_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A62UsuarioCP), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioCP_Enabled!=0) ? context.localUtil.Format( (decimal)(A62UsuarioCP), "ZZZZ9") : context.localUtil.Format( (decimal)(A62UsuarioCP), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,94);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioCP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioCP_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbUsuarioZona_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbUsuarioZona_Internalname, context.GetMessage( "Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioZona, cmbUsuarioZona_Internalname, StringUtil.RTrim( A63UsuarioZona), 1, cmbUsuarioZona_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioZona.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 0, "HLP_WPUsuarioDetalleGeneral.htm");
            cmbUsuarioZona.CurrentValue = StringUtil.RTrim( A63UsuarioZona);
            AssignProp(sPrefix, false, cmbUsuarioZona_Internalname, "Values", (string)(cmbUsuarioZona.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioCelular_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioCelular_Internalname, context.GetMessage( "Celular", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioCelular_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A64UsuarioCelular), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioCelular_Enabled!=0) ? context.localUtil.Format( (decimal)(A64UsuarioCelular), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A64UsuarioCelular), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,104);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioCelular_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioCelular_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioTelefonoSucursal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioTelefonoSucursal_Internalname, context.GetMessage( "Teléfono Sucursal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioTelefonoSucursal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A65UsuarioTelefonoSucursal), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioTelefonoSucursal_Enabled!=0) ? context.localUtil.Format( (decimal)(A65UsuarioTelefonoSucursal), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A65UsuarioTelefonoSucursal), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,109);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioTelefonoSucursal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioTelefonoSucursal_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtPaisID_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPaisID_Internalname, context.GetMessage( "Pais ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPaisID_Enabled!=0) ? context.localUtil.Format( (decimal)(A16PaisID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A16PaisID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,114);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "AttributeFL", "", "", "", "", edtPaisID_Visible, edtPaisID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisDescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPaisDescripcion_Internalname, context.GetMessage( "País", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPaisDescripcion_Internalname, A17PaisDescripcion, StringUtil.RTrim( context.localUtil.Format( A17PaisDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisDescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPaisDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtEstadoID_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadoID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEstadoID_Internalname, context.GetMessage( "Estado ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEstadoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtEstadoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EstadoID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1EstadoID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,124);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoID_Jsonclick, 0, "AttributeFL", "", "", "", "", edtEstadoID_Visible, edtEstadoID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadoDescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEstadoDescripcion_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEstadoDescripcion_Internalname, A2EstadoDescripcion, StringUtil.RTrim( context.localUtil.Format( A2EstadoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoDescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCiudadDescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCiudadDescripcion_Internalname, context.GetMessage( "Ciudad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCiudadDescripcion_Internalname, A5CiudadDescripcion, StringUtil.RTrim( context.localUtil.Format( A5CiudadDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCiudadDescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCiudadDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioSucursal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioSucursal_Internalname, context.GetMessage( "Sucursal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioSucursal_Internalname, StringUtil.RTrim( A66UsuarioSucursal), StringUtil.RTrim( context.localUtil.Format( A66UsuarioSucursal, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioSucursal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioSucursal_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbUsuarioProducto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbUsuarioProducto_Internalname, context.GetMessage( "Producto que vendes", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioProducto, cmbUsuarioProducto_Internalname, StringUtil.RTrim( A67UsuarioProducto), 1, cmbUsuarioProducto_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbUsuarioProducto.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "", true, 0, "HLP_WPUsuarioDetalleGeneral.htm");
            cmbUsuarioProducto.CurrentValue = StringUtil.RTrim( A67UsuarioProducto);
            AssignProp(sPrefix, false, cmbUsuarioProducto_Internalname, "Values", (string)(cmbUsuarioProducto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbUsuarioRol_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbUsuarioRol_Internalname, context.GetMessage( "Rol", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioRol, cmbUsuarioRol_Internalname, StringUtil.RTrim( A40UsuarioRol), 1, cmbUsuarioRol_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioRol.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "", true, 0, "HLP_WPUsuarioDetalleGeneral.htm");
            cmbUsuarioRol.CurrentValue = StringUtil.RTrim( A40UsuarioRol);
            AssignProp(sPrefix, false, cmbUsuarioRol_Internalname, "Values", (string)(cmbUsuarioRol.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioNoCuentaBROXEL_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioNoCuentaBROXEL_Internalname, context.GetMessage( "Cuenta BROXEL", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioNoCuentaBROXEL_Internalname, StringUtil.RTrim( A82UsuarioNoCuentaBROXEL), StringUtil.RTrim( context.localUtil.Format( A82UsuarioNoCuentaBROXEL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,154);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNoCuentaBROXEL_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioNoCuentaBROXEL_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioReferenciaBROXEL_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioReferenciaBROXEL_Internalname, context.GetMessage( "Referencia BROXEL", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtUsuarioReferenciaBROXEL_Internalname, StringUtil.RTrim( A83UsuarioReferenciaBROXEL), StringUtil.RTrim( context.localUtil.Format( A83UsuarioReferenciaBROXEL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioReferenciaBROXEL_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioReferenciaBROXEL_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioFechaRegistro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUsuarioFechaRegistro_Internalname, context.GetMessage( "Fecha Registro", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtUsuarioFechaRegistro_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtUsuarioFechaRegistro_Internalname, context.localUtil.Format(A87UsuarioFechaRegistro, "99/99/99"), context.localUtil.Format( A87UsuarioFechaRegistro, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,164);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioFechaRegistro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuarioFechaRegistro_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPUsuarioDetalleGeneral.htm");
            GxWebStd.gx_bitmap( context, edtUsuarioFechaRegistro_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuarioFechaRegistro_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPUsuarioDetalleGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkUsuarioAvisoPrivacidad_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkUsuarioAvisoPrivacidad_Internalname, context.GetMessage( "de Privacidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkUsuarioAvisoPrivacidad_Internalname, StringUtil.BoolToStr( A92UsuarioAvisoPrivacidad), "", context.GetMessage( "de Privacidad", ""), 1, chkUsuarioAvisoPrivacidad.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(169, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,169);\"");
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
         }
         wbLoad = true;
      }

      protected void START322( )
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
            Form.Meta.addItem("description", context.GetMessage( "WPUsuario Detalle General", ""), 0) ;
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
               STRUP320( ) ;
            }
         }
      }

      protected void WS322( )
      {
         START322( ) ;
         EVT322( ) ;
      }

      protected void EVT322( )
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
                                 STRUP320( ) ;
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
                                 STRUP320( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11322 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP320( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12322 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP320( ) ;
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
                                 STRUP320( ) ;
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE322( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm322( ) ;
            }
         }
      }

      protected void PA322( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpusuariodetallegeneral.aspx")), "wpusuariodetallegeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpusuariodetallegeneral.aspx")))) ;
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
         if ( cmbUsuarioGenero.ItemCount > 0 )
         {
            A53UsuarioGenero = cmbUsuarioGenero.getValidValue(A53UsuarioGenero);
            AssignAttri(sPrefix, false, "A53UsuarioGenero", A53UsuarioGenero);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioGenero.CurrentValue = StringUtil.RTrim( A53UsuarioGenero);
            AssignProp(sPrefix, false, cmbUsuarioGenero_Internalname, "Values", cmbUsuarioGenero.ToJavascriptSource(), true);
         }
         if ( cmbUsuarioDirectoAsociado.ItemCount > 0 )
         {
            A54UsuarioDirectoAsociado = cmbUsuarioDirectoAsociado.getValidValue(A54UsuarioDirectoAsociado);
            n54UsuarioDirectoAsociado = false;
            AssignAttri(sPrefix, false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioDirectoAsociado.CurrentValue = StringUtil.RTrim( A54UsuarioDirectoAsociado);
            AssignProp(sPrefix, false, cmbUsuarioDirectoAsociado_Internalname, "Values", cmbUsuarioDirectoAsociado.ToJavascriptSource(), true);
         }
         if ( cmbUsuarioZona.ItemCount > 0 )
         {
            A63UsuarioZona = cmbUsuarioZona.getValidValue(A63UsuarioZona);
            AssignAttri(sPrefix, false, "A63UsuarioZona", A63UsuarioZona);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioZona.CurrentValue = StringUtil.RTrim( A63UsuarioZona);
            AssignProp(sPrefix, false, cmbUsuarioZona_Internalname, "Values", cmbUsuarioZona.ToJavascriptSource(), true);
         }
         if ( cmbUsuarioProducto.ItemCount > 0 )
         {
            A67UsuarioProducto = cmbUsuarioProducto.getValidValue(A67UsuarioProducto);
            n67UsuarioProducto = false;
            AssignAttri(sPrefix, false, "A67UsuarioProducto", A67UsuarioProducto);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioProducto.CurrentValue = StringUtil.RTrim( A67UsuarioProducto);
            AssignProp(sPrefix, false, cmbUsuarioProducto_Internalname, "Values", cmbUsuarioProducto.ToJavascriptSource(), true);
         }
         if ( cmbUsuarioRol.ItemCount > 0 )
         {
            A40UsuarioRol = cmbUsuarioRol.getValidValue(A40UsuarioRol);
            AssignAttri(sPrefix, false, "A40UsuarioRol", A40UsuarioRol);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioRol.CurrentValue = StringUtil.RTrim( A40UsuarioRol);
            AssignProp(sPrefix, false, cmbUsuarioRol_Internalname, "Values", cmbUsuarioRol.ToJavascriptSource(), true);
         }
         A92UsuarioAvisoPrivacidad = StringUtil.StrToBool( StringUtil.BoolToStr( A92UsuarioAvisoPrivacidad));
         AssignAttri(sPrefix, false, "A92UsuarioAvisoPrivacidad", A92UsuarioAvisoPrivacidad);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF322( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV11Pgmname = "WPUsuarioDetalleGeneral";
      }

      protected void RF322( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00322 */
            pr_default.execute(0, new Object[] {A29UsuarioID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A13PuestoID = H00322_A13PuestoID[0];
               n13PuestoID = H00322_n13PuestoID[0];
               A4CiudadID = H00322_A4CiudadID[0];
               n4CiudadID = H00322_n4CiudadID[0];
               A92UsuarioAvisoPrivacidad = H00322_A92UsuarioAvisoPrivacidad[0];
               AssignAttri(sPrefix, false, "A92UsuarioAvisoPrivacidad", A92UsuarioAvisoPrivacidad);
               A87UsuarioFechaRegistro = H00322_A87UsuarioFechaRegistro[0];
               n87UsuarioFechaRegistro = H00322_n87UsuarioFechaRegistro[0];
               AssignAttri(sPrefix, false, "A87UsuarioFechaRegistro", context.localUtil.Format(A87UsuarioFechaRegistro, "99/99/99"));
               A83UsuarioReferenciaBROXEL = H00322_A83UsuarioReferenciaBROXEL[0];
               AssignAttri(sPrefix, false, "A83UsuarioReferenciaBROXEL", A83UsuarioReferenciaBROXEL);
               A82UsuarioNoCuentaBROXEL = H00322_A82UsuarioNoCuentaBROXEL[0];
               AssignAttri(sPrefix, false, "A82UsuarioNoCuentaBROXEL", A82UsuarioNoCuentaBROXEL);
               A40UsuarioRol = H00322_A40UsuarioRol[0];
               AssignAttri(sPrefix, false, "A40UsuarioRol", A40UsuarioRol);
               A67UsuarioProducto = H00322_A67UsuarioProducto[0];
               n67UsuarioProducto = H00322_n67UsuarioProducto[0];
               AssignAttri(sPrefix, false, "A67UsuarioProducto", A67UsuarioProducto);
               A66UsuarioSucursal = H00322_A66UsuarioSucursal[0];
               AssignAttri(sPrefix, false, "A66UsuarioSucursal", A66UsuarioSucursal);
               A5CiudadDescripcion = H00322_A5CiudadDescripcion[0];
               AssignAttri(sPrefix, false, "A5CiudadDescripcion", A5CiudadDescripcion);
               A2EstadoDescripcion = H00322_A2EstadoDescripcion[0];
               AssignAttri(sPrefix, false, "A2EstadoDescripcion", A2EstadoDescripcion);
               A1EstadoID = H00322_A1EstadoID[0];
               AssignAttri(sPrefix, false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
               A17PaisDescripcion = H00322_A17PaisDescripcion[0];
               AssignAttri(sPrefix, false, "A17PaisDescripcion", A17PaisDescripcion);
               A16PaisID = H00322_A16PaisID[0];
               AssignAttri(sPrefix, false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
               A65UsuarioTelefonoSucursal = H00322_A65UsuarioTelefonoSucursal[0];
               AssignAttri(sPrefix, false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
               A64UsuarioCelular = H00322_A64UsuarioCelular[0];
               AssignAttri(sPrefix, false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
               A63UsuarioZona = H00322_A63UsuarioZona[0];
               AssignAttri(sPrefix, false, "A63UsuarioZona", A63UsuarioZona);
               A62UsuarioCP = H00322_A62UsuarioCP[0];
               AssignAttri(sPrefix, false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
               A61UsuarioDelegacion = H00322_A61UsuarioDelegacion[0];
               AssignAttri(sPrefix, false, "A61UsuarioDelegacion", A61UsuarioDelegacion);
               A60UsuarioColonia = H00322_A60UsuarioColonia[0];
               AssignAttri(sPrefix, false, "A60UsuarioColonia", A60UsuarioColonia);
               A59UsuarioCalleNum = H00322_A59UsuarioCalleNum[0];
               AssignAttri(sPrefix, false, "A59UsuarioCalleNum", A59UsuarioCalleNum);
               A57UsuarioFechaNacimiento = H00322_A57UsuarioFechaNacimiento[0];
               n57UsuarioFechaNacimiento = H00322_n57UsuarioFechaNacimiento[0];
               AssignAttri(sPrefix, false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
               A56UsuarioNombreComercial = H00322_A56UsuarioNombreComercial[0];
               AssignAttri(sPrefix, false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
               A55UsuarioRazonSocialAsociado = H00322_A55UsuarioRazonSocialAsociado[0];
               AssignAttri(sPrefix, false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
               A54UsuarioDirectoAsociado = H00322_A54UsuarioDirectoAsociado[0];
               n54UsuarioDirectoAsociado = H00322_n54UsuarioDirectoAsociado[0];
               AssignAttri(sPrefix, false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
               A53UsuarioGenero = H00322_A53UsuarioGenero[0];
               AssignAttri(sPrefix, false, "A53UsuarioGenero", A53UsuarioGenero);
               A14PuestoDescripcion = H00322_A14PuestoDescripcion[0];
               AssignAttri(sPrefix, false, "A14PuestoDescripcion", A14PuestoDescripcion);
               A33UsuarioKey = H00322_A33UsuarioKey[0];
               AssignAttri(sPrefix, false, "A33UsuarioKey", A33UsuarioKey);
               A32UsuarioPass = H00322_A32UsuarioPass[0];
               AssignAttri(sPrefix, false, "A32UsuarioPass", A32UsuarioPass);
               A31UsuarioCorreo = H00322_A31UsuarioCorreo[0];
               AssignAttri(sPrefix, false, "A31UsuarioCorreo", A31UsuarioCorreo);
               A51UsuarioApellido = H00322_A51UsuarioApellido[0];
               AssignAttri(sPrefix, false, "A51UsuarioApellido", A51UsuarioApellido);
               A30UsuarioNombre = H00322_A30UsuarioNombre[0];
               AssignAttri(sPrefix, false, "A30UsuarioNombre", A30UsuarioNombre);
               A14PuestoDescripcion = H00322_A14PuestoDescripcion[0];
               AssignAttri(sPrefix, false, "A14PuestoDescripcion", A14PuestoDescripcion);
               A5CiudadDescripcion = H00322_A5CiudadDescripcion[0];
               AssignAttri(sPrefix, false, "A5CiudadDescripcion", A5CiudadDescripcion);
               A1EstadoID = H00322_A1EstadoID[0];
               AssignAttri(sPrefix, false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
               A2EstadoDescripcion = H00322_A2EstadoDescripcion[0];
               AssignAttri(sPrefix, false, "A2EstadoDescripcion", A2EstadoDescripcion);
               A16PaisID = H00322_A16PaisID[0];
               AssignAttri(sPrefix, false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
               A17PaisDescripcion = H00322_A17PaisDescripcion[0];
               AssignAttri(sPrefix, false, "A17PaisDescripcion", A17PaisDescripcion);
               A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
               AssignAttri(sPrefix, false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
               /* Execute user event: Load */
               E12322 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB320( ) ;
         }
      }

      protected void send_integrity_lvl_hashes322( )
      {
      }

      protected void before_start_formulas( )
      {
         AV11Pgmname = "WPUsuarioDetalleGeneral";
         edtUsuarioID_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioID_Enabled), 5, 0), true);
         edtUsuarioNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Enabled), 5, 0), true);
         edtUsuarioApellido_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioApellido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioApellido_Enabled), 5, 0), true);
         edtUsuarioNombreCompleto_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioNombreCompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombreCompleto_Enabled), 5, 0), true);
         edtUsuarioCorreo_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioCorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioCorreo_Enabled), 5, 0), true);
         edtUsuarioPass_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioPass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioPass_Enabled), 5, 0), true);
         edtUsuarioKey_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioKey_Enabled), 5, 0), true);
         edtPuestoDescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtPuestoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPuestoDescripcion_Enabled), 5, 0), true);
         cmbUsuarioGenero.Enabled = 0;
         AssignProp(sPrefix, false, cmbUsuarioGenero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuarioGenero.Enabled), 5, 0), true);
         cmbUsuarioDirectoAsociado.Enabled = 0;
         AssignProp(sPrefix, false, cmbUsuarioDirectoAsociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuarioDirectoAsociado.Enabled), 5, 0), true);
         edtUsuarioRazonSocialAsociado_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioRazonSocialAsociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioRazonSocialAsociado_Enabled), 5, 0), true);
         edtUsuarioNombreComercial_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioNombreComercial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombreComercial_Enabled), 5, 0), true);
         edtUsuarioFechaNacimiento_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioFechaNacimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFechaNacimiento_Enabled), 5, 0), true);
         edtUsuarioCalleNum_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioCalleNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioCalleNum_Enabled), 5, 0), true);
         edtUsuarioColonia_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioColonia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioColonia_Enabled), 5, 0), true);
         edtUsuarioDelegacion_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioDelegacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioDelegacion_Enabled), 5, 0), true);
         edtUsuarioCP_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioCP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioCP_Enabled), 5, 0), true);
         cmbUsuarioZona.Enabled = 0;
         AssignProp(sPrefix, false, cmbUsuarioZona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuarioZona.Enabled), 5, 0), true);
         edtUsuarioCelular_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioCelular_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioCelular_Enabled), 5, 0), true);
         edtUsuarioTelefonoSucursal_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioTelefonoSucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioTelefonoSucursal_Enabled), 5, 0), true);
         edtPaisID_Enabled = 0;
         AssignProp(sPrefix, false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         edtPaisDescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtPaisDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisDescripcion_Enabled), 5, 0), true);
         edtEstadoID_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoID_Enabled), 5, 0), true);
         edtEstadoDescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoDescripcion_Enabled), 5, 0), true);
         edtCiudadDescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtCiudadDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadDescripcion_Enabled), 5, 0), true);
         edtUsuarioSucursal_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioSucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSucursal_Enabled), 5, 0), true);
         cmbUsuarioProducto.Enabled = 0;
         AssignProp(sPrefix, false, cmbUsuarioProducto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuarioProducto.Enabled), 5, 0), true);
         cmbUsuarioRol.Enabled = 0;
         AssignProp(sPrefix, false, cmbUsuarioRol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuarioRol.Enabled), 5, 0), true);
         edtUsuarioNoCuentaBROXEL_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioNoCuentaBROXEL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNoCuentaBROXEL_Enabled), 5, 0), true);
         edtUsuarioReferenciaBROXEL_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioReferenciaBROXEL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioReferenciaBROXEL_Enabled), 5, 0), true);
         edtUsuarioFechaRegistro_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioFechaRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFechaRegistro_Enabled), 5, 0), true);
         chkUsuarioAvisoPrivacidad.Enabled = 0;
         AssignProp(sPrefix, false, chkUsuarioAvisoPrivacidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuarioAvisoPrivacidad.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP320( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11322 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA29UsuarioID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A30UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
            AssignAttri(sPrefix, false, "A30UsuarioNombre", A30UsuarioNombre);
            A51UsuarioApellido = cgiGet( edtUsuarioApellido_Internalname);
            AssignAttri(sPrefix, false, "A51UsuarioApellido", A51UsuarioApellido);
            A52UsuarioNombreCompleto = cgiGet( edtUsuarioNombreCompleto_Internalname);
            AssignAttri(sPrefix, false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
            A31UsuarioCorreo = cgiGet( edtUsuarioCorreo_Internalname);
            AssignAttri(sPrefix, false, "A31UsuarioCorreo", A31UsuarioCorreo);
            A32UsuarioPass = cgiGet( edtUsuarioPass_Internalname);
            AssignAttri(sPrefix, false, "A32UsuarioPass", A32UsuarioPass);
            A33UsuarioKey = cgiGet( edtUsuarioKey_Internalname);
            AssignAttri(sPrefix, false, "A33UsuarioKey", A33UsuarioKey);
            A14PuestoDescripcion = cgiGet( edtPuestoDescripcion_Internalname);
            AssignAttri(sPrefix, false, "A14PuestoDescripcion", A14PuestoDescripcion);
            cmbUsuarioGenero.CurrentValue = cgiGet( cmbUsuarioGenero_Internalname);
            A53UsuarioGenero = cgiGet( cmbUsuarioGenero_Internalname);
            AssignAttri(sPrefix, false, "A53UsuarioGenero", A53UsuarioGenero);
            cmbUsuarioDirectoAsociado.CurrentValue = cgiGet( cmbUsuarioDirectoAsociado_Internalname);
            A54UsuarioDirectoAsociado = cgiGet( cmbUsuarioDirectoAsociado_Internalname);
            n54UsuarioDirectoAsociado = false;
            AssignAttri(sPrefix, false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
            A55UsuarioRazonSocialAsociado = cgiGet( edtUsuarioRazonSocialAsociado_Internalname);
            AssignAttri(sPrefix, false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
            A56UsuarioNombreComercial = cgiGet( edtUsuarioNombreComercial_Internalname);
            AssignAttri(sPrefix, false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
            A57UsuarioFechaNacimiento = context.localUtil.CToD( cgiGet( edtUsuarioFechaNacimiento_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            n57UsuarioFechaNacimiento = false;
            AssignAttri(sPrefix, false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
            A59UsuarioCalleNum = cgiGet( edtUsuarioCalleNum_Internalname);
            AssignAttri(sPrefix, false, "A59UsuarioCalleNum", A59UsuarioCalleNum);
            A60UsuarioColonia = cgiGet( edtUsuarioColonia_Internalname);
            AssignAttri(sPrefix, false, "A60UsuarioColonia", A60UsuarioColonia);
            A61UsuarioDelegacion = cgiGet( edtUsuarioDelegacion_Internalname);
            AssignAttri(sPrefix, false, "A61UsuarioDelegacion", A61UsuarioDelegacion);
            A62UsuarioCP = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioCP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
            cmbUsuarioZona.CurrentValue = cgiGet( cmbUsuarioZona_Internalname);
            A63UsuarioZona = cgiGet( cmbUsuarioZona_Internalname);
            AssignAttri(sPrefix, false, "A63UsuarioZona", A63UsuarioZona);
            A64UsuarioCelular = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioCelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
            A65UsuarioTelefonoSucursal = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioTelefonoSucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
            A16PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPaisID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            A17PaisDescripcion = cgiGet( edtPaisDescripcion_Internalname);
            AssignAttri(sPrefix, false, "A17PaisDescripcion", A17PaisDescripcion);
            A1EstadoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            A2EstadoDescripcion = cgiGet( edtEstadoDescripcion_Internalname);
            AssignAttri(sPrefix, false, "A2EstadoDescripcion", A2EstadoDescripcion);
            A5CiudadDescripcion = cgiGet( edtCiudadDescripcion_Internalname);
            AssignAttri(sPrefix, false, "A5CiudadDescripcion", A5CiudadDescripcion);
            A66UsuarioSucursal = cgiGet( edtUsuarioSucursal_Internalname);
            AssignAttri(sPrefix, false, "A66UsuarioSucursal", A66UsuarioSucursal);
            cmbUsuarioProducto.CurrentValue = cgiGet( cmbUsuarioProducto_Internalname);
            A67UsuarioProducto = cgiGet( cmbUsuarioProducto_Internalname);
            n67UsuarioProducto = false;
            AssignAttri(sPrefix, false, "A67UsuarioProducto", A67UsuarioProducto);
            cmbUsuarioRol.CurrentValue = cgiGet( cmbUsuarioRol_Internalname);
            A40UsuarioRol = cgiGet( cmbUsuarioRol_Internalname);
            AssignAttri(sPrefix, false, "A40UsuarioRol", A40UsuarioRol);
            A82UsuarioNoCuentaBROXEL = cgiGet( edtUsuarioNoCuentaBROXEL_Internalname);
            AssignAttri(sPrefix, false, "A82UsuarioNoCuentaBROXEL", A82UsuarioNoCuentaBROXEL);
            A83UsuarioReferenciaBROXEL = cgiGet( edtUsuarioReferenciaBROXEL_Internalname);
            AssignAttri(sPrefix, false, "A83UsuarioReferenciaBROXEL", A83UsuarioReferenciaBROXEL);
            A87UsuarioFechaRegistro = context.localUtil.CToD( cgiGet( edtUsuarioFechaRegistro_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            n87UsuarioFechaRegistro = false;
            AssignAttri(sPrefix, false, "A87UsuarioFechaRegistro", context.localUtil.Format(A87UsuarioFechaRegistro, "99/99/99"));
            A92UsuarioAvisoPrivacidad = StringUtil.StrToBool( cgiGet( chkUsuarioAvisoPrivacidad_Internalname));
            AssignAttri(sPrefix, false, "A92UsuarioAvisoPrivacidad", A92UsuarioAvisoPrivacidad);
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
         E11322 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11322( )
      {
         /* Start Routine */
         returnInSub = false;
         edtUsuarioID_Visible = 0;
         AssignProp(sPrefix, false, edtUsuarioID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioID_Visible), 5, 0), true);
         edtUsuarioNombreCompleto_Visible = 0;
         AssignProp(sPrefix, false, edtUsuarioNombreCompleto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioNombreCompleto_Visible), 5, 0), true);
         edtUsuarioPass_Visible = 0;
         AssignProp(sPrefix, false, edtUsuarioPass_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioPass_Visible), 5, 0), true);
         edtUsuarioKey_Visible = 0;
         AssignProp(sPrefix, false, edtUsuarioKey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioKey_Visible), 5, 0), true);
         edtPaisID_Visible = 0;
         AssignProp(sPrefix, false, edtPaisID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPaisID_Visible), 5, 0), true);
         edtEstadoID_Visible = 0;
         AssignProp(sPrefix, false, edtEstadoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadoID_Visible), 5, 0), true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12322( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV11Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Usuario";
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A29UsuarioID = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
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
         PA322( ) ;
         WS322( ) ;
         WE322( ) ;
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
         sCtrlA29UsuarioID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA322( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpusuariodetallegeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA322( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A29UsuarioID = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
         }
         wcpOA29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA29UsuarioID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A29UsuarioID != wcpOA29UsuarioID ) ) )
         {
            setjustcreated();
         }
         wcpOA29UsuarioID = A29UsuarioID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA29UsuarioID = cgiGet( sPrefix+"A29UsuarioID_CTRL");
         if ( StringUtil.Len( sCtrlA29UsuarioID) > 0 )
         {
            A29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA29UsuarioID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
         }
         else
         {
            A29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A29UsuarioID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA322( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS322( ) ;
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
         WS322( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A29UsuarioID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA29UsuarioID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A29UsuarioID_CTRL", StringUtil.RTrim( sCtrlA29UsuarioID));
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
         WE322( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202651111305056", true, true);
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
            context.AddJavascriptSource("wpusuariodetallegeneral.js", "?202651111305057", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbUsuarioGenero.Name = "USUARIOGENERO";
         cmbUsuarioGenero.WebTags = "";
         cmbUsuarioGenero.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbUsuarioGenero.addItem("Masculino", context.GetMessage( "Masculino", ""), 0);
         cmbUsuarioGenero.addItem("Femenino", context.GetMessage( "Femenino", ""), 0);
         if ( cmbUsuarioGenero.ItemCount > 0 )
         {
         }
         cmbUsuarioDirectoAsociado.Name = "USUARIODIRECTOASOCIADO";
         cmbUsuarioDirectoAsociado.WebTags = "";
         cmbUsuarioDirectoAsociado.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbUsuarioDirectoAsociado.addItem("Directo", context.GetMessage( "Directo", ""), 0);
         cmbUsuarioDirectoAsociado.addItem("Asociado", context.GetMessage( "Asociado", ""), 0);
         if ( cmbUsuarioDirectoAsociado.ItemCount > 0 )
         {
         }
         cmbUsuarioZona.Name = "USUARIOZONA";
         cmbUsuarioZona.WebTags = "";
         cmbUsuarioZona.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbUsuarioZona.addItem("Centro", context.GetMessage( "Centro", ""), 0);
         cmbUsuarioZona.addItem("Centro América", context.GetMessage( "Centro América", ""), 0);
         cmbUsuarioZona.addItem("Norte", context.GetMessage( "Norte", ""), 0);
         cmbUsuarioZona.addItem("Pacífico", context.GetMessage( "Pacifico", ""), 0);
         cmbUsuarioZona.addItem("Sur", context.GetMessage( "Sur", ""), 0);
         if ( cmbUsuarioZona.ItemCount > 0 )
         {
         }
         cmbUsuarioProducto.Name = "USUARIOPRODUCTO";
         cmbUsuarioProducto.WebTags = "";
         cmbUsuarioProducto.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbUsuarioProducto.addItem("Auto y Camioneta", context.GetMessage( "Auto y Camioneta", ""), 0);
         cmbUsuarioProducto.addItem("Auto y Camioneta/Camión", context.GetMessage( "Auto y Camioneta/Camión", ""), 0);
         cmbUsuarioProducto.addItem("Camión", context.GetMessage( "Camión", ""), 0);
         cmbUsuarioProducto.addItem("Empleado", context.GetMessage( "Empleado", ""), 0);
         cmbUsuarioProducto.addItem("OTR/Camión", context.GetMessage( "OTR/Camión", ""), 0);
         if ( cmbUsuarioProducto.ItemCount > 0 )
         {
         }
         cmbUsuarioRol.Name = "USUARIOROL";
         cmbUsuarioRol.WebTags = "";
         cmbUsuarioRol.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbUsuarioRol.addItem("Super Administrador", context.GetMessage( "Super Administrador", ""), 0);
         cmbUsuarioRol.addItem("Administrador Yokohama", context.GetMessage( "Administrador Yokohama", ""), 0);
         cmbUsuarioRol.addItem("Asesor", context.GetMessage( "Asesor", ""), 0);
         cmbUsuarioRol.addItem("Participante", context.GetMessage( "Participante", ""), 0);
         if ( cmbUsuarioRol.ItemCount > 0 )
         {
         }
         chkUsuarioAvisoPrivacidad.Name = "USUARIOAVISOPRIVACIDAD";
         chkUsuarioAvisoPrivacidad.WebTags = "";
         chkUsuarioAvisoPrivacidad.Caption = context.GetMessage( "de Privacidad", "");
         AssignProp(sPrefix, false, chkUsuarioAvisoPrivacidad_Internalname, "TitleCaption", chkUsuarioAvisoPrivacidad.Caption, true);
         chkUsuarioAvisoPrivacidad.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtUsuarioID_Internalname = sPrefix+"USUARIOID";
         edtUsuarioNombre_Internalname = sPrefix+"USUARIONOMBRE";
         edtUsuarioApellido_Internalname = sPrefix+"USUARIOAPELLIDO";
         edtUsuarioNombreCompleto_Internalname = sPrefix+"USUARIONOMBRECOMPLETO";
         edtUsuarioCorreo_Internalname = sPrefix+"USUARIOCORREO";
         edtUsuarioPass_Internalname = sPrefix+"USUARIOPASS";
         edtUsuarioKey_Internalname = sPrefix+"USUARIOKEY";
         edtPuestoDescripcion_Internalname = sPrefix+"PUESTODESCRIPCION";
         cmbUsuarioGenero_Internalname = sPrefix+"USUARIOGENERO";
         cmbUsuarioDirectoAsociado_Internalname = sPrefix+"USUARIODIRECTOASOCIADO";
         edtUsuarioRazonSocialAsociado_Internalname = sPrefix+"USUARIORAZONSOCIALASOCIADO";
         edtUsuarioNombreComercial_Internalname = sPrefix+"USUARIONOMBRECOMERCIAL";
         edtUsuarioFechaNacimiento_Internalname = sPrefix+"USUARIOFECHANACIMIENTO";
         edtUsuarioCalleNum_Internalname = sPrefix+"USUARIOCALLENUM";
         edtUsuarioColonia_Internalname = sPrefix+"USUARIOCOLONIA";
         edtUsuarioDelegacion_Internalname = sPrefix+"USUARIODELEGACION";
         edtUsuarioCP_Internalname = sPrefix+"USUARIOCP";
         cmbUsuarioZona_Internalname = sPrefix+"USUARIOZONA";
         edtUsuarioCelular_Internalname = sPrefix+"USUARIOCELULAR";
         edtUsuarioTelefonoSucursal_Internalname = sPrefix+"USUARIOTELEFONOSUCURSAL";
         edtPaisID_Internalname = sPrefix+"PAISID";
         edtPaisDescripcion_Internalname = sPrefix+"PAISDESCRIPCION";
         edtEstadoID_Internalname = sPrefix+"ESTADOID";
         edtEstadoDescripcion_Internalname = sPrefix+"ESTADODESCRIPCION";
         edtCiudadDescripcion_Internalname = sPrefix+"CIUDADDESCRIPCION";
         edtUsuarioSucursal_Internalname = sPrefix+"USUARIOSUCURSAL";
         cmbUsuarioProducto_Internalname = sPrefix+"USUARIOPRODUCTO";
         cmbUsuarioRol_Internalname = sPrefix+"USUARIOROL";
         edtUsuarioNoCuentaBROXEL_Internalname = sPrefix+"USUARIONOCUENTABROXEL";
         edtUsuarioReferenciaBROXEL_Internalname = sPrefix+"USUARIOREFERENCIABROXEL";
         edtUsuarioFechaRegistro_Internalname = sPrefix+"USUARIOFECHAREGISTRO";
         chkUsuarioAvisoPrivacidad_Internalname = sPrefix+"USUARIOAVISOPRIVACIDAD";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         divTable_Internalname = sPrefix+"TABLE";
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
         chkUsuarioAvisoPrivacidad.Caption = context.GetMessage( "de Privacidad", "");
         chkUsuarioAvisoPrivacidad.Enabled = 0;
         edtUsuarioFechaRegistro_Jsonclick = "";
         edtUsuarioFechaRegistro_Enabled = 0;
         edtUsuarioReferenciaBROXEL_Jsonclick = "";
         edtUsuarioReferenciaBROXEL_Enabled = 0;
         edtUsuarioNoCuentaBROXEL_Jsonclick = "";
         edtUsuarioNoCuentaBROXEL_Enabled = 0;
         cmbUsuarioRol_Jsonclick = "";
         cmbUsuarioRol.Enabled = 0;
         cmbUsuarioProducto_Jsonclick = "";
         cmbUsuarioProducto.Enabled = 0;
         edtUsuarioSucursal_Jsonclick = "";
         edtUsuarioSucursal_Enabled = 0;
         edtCiudadDescripcion_Jsonclick = "";
         edtCiudadDescripcion_Enabled = 0;
         edtEstadoDescripcion_Jsonclick = "";
         edtEstadoDescripcion_Enabled = 0;
         edtEstadoID_Jsonclick = "";
         edtEstadoID_Enabled = 0;
         edtEstadoID_Visible = 1;
         edtPaisDescripcion_Jsonclick = "";
         edtPaisDescripcion_Enabled = 0;
         edtPaisID_Jsonclick = "";
         edtPaisID_Enabled = 0;
         edtPaisID_Visible = 1;
         edtUsuarioTelefonoSucursal_Jsonclick = "";
         edtUsuarioTelefonoSucursal_Enabled = 0;
         edtUsuarioCelular_Jsonclick = "";
         edtUsuarioCelular_Enabled = 0;
         cmbUsuarioZona_Jsonclick = "";
         cmbUsuarioZona.Enabled = 0;
         edtUsuarioCP_Jsonclick = "";
         edtUsuarioCP_Enabled = 0;
         edtUsuarioDelegacion_Jsonclick = "";
         edtUsuarioDelegacion_Enabled = 0;
         edtUsuarioColonia_Jsonclick = "";
         edtUsuarioColonia_Enabled = 0;
         edtUsuarioCalleNum_Jsonclick = "";
         edtUsuarioCalleNum_Enabled = 0;
         edtUsuarioFechaNacimiento_Jsonclick = "";
         edtUsuarioFechaNacimiento_Enabled = 0;
         edtUsuarioNombreComercial_Jsonclick = "";
         edtUsuarioNombreComercial_Enabled = 0;
         edtUsuarioRazonSocialAsociado_Jsonclick = "";
         edtUsuarioRazonSocialAsociado_Enabled = 0;
         cmbUsuarioDirectoAsociado_Jsonclick = "";
         cmbUsuarioDirectoAsociado.Enabled = 0;
         cmbUsuarioGenero_Jsonclick = "";
         cmbUsuarioGenero.Enabled = 0;
         edtPuestoDescripcion_Jsonclick = "";
         edtPuestoDescripcion_Enabled = 0;
         edtUsuarioKey_Jsonclick = "";
         edtUsuarioKey_Enabled = 0;
         edtUsuarioKey_Visible = 1;
         edtUsuarioPass_Jsonclick = "";
         edtUsuarioPass_Enabled = 0;
         edtUsuarioPass_Visible = 1;
         edtUsuarioCorreo_Jsonclick = "";
         edtUsuarioCorreo_Enabled = 0;
         edtUsuarioNombreCompleto_Jsonclick = "";
         edtUsuarioNombreCompleto_Enabled = 0;
         edtUsuarioNombreCompleto_Visible = 1;
         edtUsuarioApellido_Jsonclick = "";
         edtUsuarioApellido_Enabled = 0;
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioNombre_Enabled = 0;
         edtUsuarioID_Jsonclick = "";
         edtUsuarioID_Enabled = 0;
         edtUsuarioID_Visible = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9"},{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_USUARIOID","""{"handler":"Valid_Usuarioid","iparms":[]}""");
         setEventMetadata("VALID_USUARIONOMBRE","""{"handler":"Valid_Usuarionombre","iparms":[]}""");
         setEventMetadata("VALID_USUARIOAPELLIDO","""{"handler":"Valid_Usuarioapellido","iparms":[]}""");
         setEventMetadata("VALID_PAISID","""{"handler":"Valid_Paisid","iparms":[]}""");
         setEventMetadata("VALID_ESTADOID","""{"handler":"Valid_Estadoid","iparms":[]}""");
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
         AV11Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         TempTags = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A52UsuarioNombreCompleto = "";
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
         A67UsuarioProducto = "";
         A40UsuarioRol = "";
         A82UsuarioNoCuentaBROXEL = "";
         A83UsuarioReferenciaBROXEL = "";
         A87UsuarioFechaRegistro = DateTime.MinValue;
         ClassString = "";
         StyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00322_A13PuestoID = new int[1] ;
         H00322_n13PuestoID = new bool[] {false} ;
         H00322_A4CiudadID = new int[1] ;
         H00322_n4CiudadID = new bool[] {false} ;
         H00322_A29UsuarioID = new int[1] ;
         H00322_A92UsuarioAvisoPrivacidad = new bool[] {false} ;
         H00322_A87UsuarioFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         H00322_n87UsuarioFechaRegistro = new bool[] {false} ;
         H00322_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         H00322_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         H00322_A40UsuarioRol = new string[] {""} ;
         H00322_A67UsuarioProducto = new string[] {""} ;
         H00322_n67UsuarioProducto = new bool[] {false} ;
         H00322_A66UsuarioSucursal = new string[] {""} ;
         H00322_A5CiudadDescripcion = new string[] {""} ;
         H00322_A2EstadoDescripcion = new string[] {""} ;
         H00322_A1EstadoID = new int[1] ;
         H00322_A17PaisDescripcion = new string[] {""} ;
         H00322_A16PaisID = new int[1] ;
         H00322_A65UsuarioTelefonoSucursal = new long[1] ;
         H00322_A64UsuarioCelular = new long[1] ;
         H00322_A63UsuarioZona = new string[] {""} ;
         H00322_A62UsuarioCP = new int[1] ;
         H00322_A61UsuarioDelegacion = new string[] {""} ;
         H00322_A60UsuarioColonia = new string[] {""} ;
         H00322_A59UsuarioCalleNum = new string[] {""} ;
         H00322_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         H00322_n57UsuarioFechaNacimiento = new bool[] {false} ;
         H00322_A56UsuarioNombreComercial = new string[] {""} ;
         H00322_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         H00322_A54UsuarioDirectoAsociado = new string[] {""} ;
         H00322_n54UsuarioDirectoAsociado = new bool[] {false} ;
         H00322_A53UsuarioGenero = new string[] {""} ;
         H00322_A14PuestoDescripcion = new string[] {""} ;
         H00322_A33UsuarioKey = new string[] {""} ;
         H00322_A32UsuarioPass = new string[] {""} ;
         H00322_A31UsuarioCorreo = new string[] {""} ;
         H00322_A51UsuarioApellido = new string[] {""} ;
         H00322_A30UsuarioNombre = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV7TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA29UsuarioID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpusuariodetallegeneral__default(),
            new Object[][] {
                new Object[] {
               H00322_A13PuestoID, H00322_n13PuestoID, H00322_A4CiudadID, H00322_n4CiudadID, H00322_A29UsuarioID, H00322_A92UsuarioAvisoPrivacidad, H00322_A87UsuarioFechaRegistro, H00322_n87UsuarioFechaRegistro, H00322_A83UsuarioReferenciaBROXEL, H00322_A82UsuarioNoCuentaBROXEL,
               H00322_A40UsuarioRol, H00322_A67UsuarioProducto, H00322_n67UsuarioProducto, H00322_A66UsuarioSucursal, H00322_A5CiudadDescripcion, H00322_A2EstadoDescripcion, H00322_A1EstadoID, H00322_A17PaisDescripcion, H00322_A16PaisID, H00322_A65UsuarioTelefonoSucursal,
               H00322_A64UsuarioCelular, H00322_A63UsuarioZona, H00322_A62UsuarioCP, H00322_A61UsuarioDelegacion, H00322_A60UsuarioColonia, H00322_A59UsuarioCalleNum, H00322_A57UsuarioFechaNacimiento, H00322_n57UsuarioFechaNacimiento, H00322_A56UsuarioNombreComercial, H00322_A55UsuarioRazonSocialAsociado,
               H00322_A54UsuarioDirectoAsociado, H00322_n54UsuarioDirectoAsociado, H00322_A53UsuarioGenero, H00322_A14PuestoDescripcion, H00322_A33UsuarioKey, H00322_A32UsuarioPass, H00322_A31UsuarioCorreo, H00322_A51UsuarioApellido, H00322_A30UsuarioNombre
               }
            }
         );
         AV11Pgmname = "WPUsuarioDetalleGeneral";
         /* GeneXus formulas. */
         AV11Pgmname = "WPUsuarioDetalleGeneral";
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
      private int A29UsuarioID ;
      private int wcpOA29UsuarioID ;
      private int edtUsuarioID_Visible ;
      private int edtUsuarioID_Enabled ;
      private int edtUsuarioNombre_Enabled ;
      private int edtUsuarioApellido_Enabled ;
      private int edtUsuarioNombreCompleto_Visible ;
      private int edtUsuarioNombreCompleto_Enabled ;
      private int edtUsuarioCorreo_Enabled ;
      private int edtUsuarioPass_Visible ;
      private int edtUsuarioPass_Enabled ;
      private int edtUsuarioKey_Visible ;
      private int edtUsuarioKey_Enabled ;
      private int edtPuestoDescripcion_Enabled ;
      private int edtUsuarioRazonSocialAsociado_Enabled ;
      private int edtUsuarioNombreComercial_Enabled ;
      private int edtUsuarioFechaNacimiento_Enabled ;
      private int edtUsuarioCalleNum_Enabled ;
      private int edtUsuarioColonia_Enabled ;
      private int edtUsuarioDelegacion_Enabled ;
      private int A62UsuarioCP ;
      private int edtUsuarioCP_Enabled ;
      private int edtUsuarioCelular_Enabled ;
      private int edtUsuarioTelefonoSucursal_Enabled ;
      private int edtPaisID_Visible ;
      private int A16PaisID ;
      private int edtPaisID_Enabled ;
      private int edtPaisDescripcion_Enabled ;
      private int edtEstadoID_Visible ;
      private int A1EstadoID ;
      private int edtEstadoID_Enabled ;
      private int edtEstadoDescripcion_Enabled ;
      private int edtCiudadDescripcion_Enabled ;
      private int edtUsuarioSucursal_Enabled ;
      private int edtUsuarioNoCuentaBROXEL_Enabled ;
      private int edtUsuarioReferenciaBROXEL_Enabled ;
      private int edtUsuarioFechaRegistro_Enabled ;
      private int A13PuestoID ;
      private int A4CiudadID ;
      private int idxLst ;
      private long A64UsuarioCelular ;
      private long A65UsuarioTelefonoSucursal ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV11Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtUsuarioID_Internalname ;
      private string TempTags ;
      private string edtUsuarioID_Jsonclick ;
      private string edtUsuarioNombre_Internalname ;
      private string A30UsuarioNombre ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtUsuarioApellido_Internalname ;
      private string A51UsuarioApellido ;
      private string edtUsuarioApellido_Jsonclick ;
      private string edtUsuarioNombreCompleto_Internalname ;
      private string edtUsuarioNombreCompleto_Jsonclick ;
      private string edtUsuarioCorreo_Internalname ;
      private string edtUsuarioCorreo_Jsonclick ;
      private string edtUsuarioPass_Internalname ;
      private string edtUsuarioPass_Jsonclick ;
      private string edtUsuarioKey_Internalname ;
      private string edtUsuarioKey_Jsonclick ;
      private string edtPuestoDescripcion_Internalname ;
      private string edtPuestoDescripcion_Jsonclick ;
      private string cmbUsuarioGenero_Internalname ;
      private string A53UsuarioGenero ;
      private string cmbUsuarioGenero_Jsonclick ;
      private string cmbUsuarioDirectoAsociado_Internalname ;
      private string A54UsuarioDirectoAsociado ;
      private string cmbUsuarioDirectoAsociado_Jsonclick ;
      private string edtUsuarioRazonSocialAsociado_Internalname ;
      private string edtUsuarioRazonSocialAsociado_Jsonclick ;
      private string edtUsuarioNombreComercial_Internalname ;
      private string edtUsuarioNombreComercial_Jsonclick ;
      private string edtUsuarioFechaNacimiento_Internalname ;
      private string edtUsuarioFechaNacimiento_Jsonclick ;
      private string edtUsuarioCalleNum_Internalname ;
      private string A59UsuarioCalleNum ;
      private string edtUsuarioCalleNum_Jsonclick ;
      private string edtUsuarioColonia_Internalname ;
      private string A60UsuarioColonia ;
      private string edtUsuarioColonia_Jsonclick ;
      private string edtUsuarioDelegacion_Internalname ;
      private string A61UsuarioDelegacion ;
      private string edtUsuarioDelegacion_Jsonclick ;
      private string edtUsuarioCP_Internalname ;
      private string edtUsuarioCP_Jsonclick ;
      private string cmbUsuarioZona_Internalname ;
      private string A63UsuarioZona ;
      private string cmbUsuarioZona_Jsonclick ;
      private string edtUsuarioCelular_Internalname ;
      private string edtUsuarioCelular_Jsonclick ;
      private string edtUsuarioTelefonoSucursal_Internalname ;
      private string edtUsuarioTelefonoSucursal_Jsonclick ;
      private string edtPaisID_Internalname ;
      private string edtPaisID_Jsonclick ;
      private string edtPaisDescripcion_Internalname ;
      private string edtPaisDescripcion_Jsonclick ;
      private string edtEstadoID_Internalname ;
      private string edtEstadoID_Jsonclick ;
      private string edtEstadoDescripcion_Internalname ;
      private string edtEstadoDescripcion_Jsonclick ;
      private string edtCiudadDescripcion_Internalname ;
      private string edtCiudadDescripcion_Jsonclick ;
      private string edtUsuarioSucursal_Internalname ;
      private string A66UsuarioSucursal ;
      private string edtUsuarioSucursal_Jsonclick ;
      private string cmbUsuarioProducto_Internalname ;
      private string cmbUsuarioProducto_Jsonclick ;
      private string cmbUsuarioRol_Internalname ;
      private string A40UsuarioRol ;
      private string cmbUsuarioRol_Jsonclick ;
      private string edtUsuarioNoCuentaBROXEL_Internalname ;
      private string A82UsuarioNoCuentaBROXEL ;
      private string edtUsuarioNoCuentaBROXEL_Jsonclick ;
      private string edtUsuarioReferenciaBROXEL_Internalname ;
      private string A83UsuarioReferenciaBROXEL ;
      private string edtUsuarioReferenciaBROXEL_Jsonclick ;
      private string edtUsuarioFechaRegistro_Internalname ;
      private string edtUsuarioFechaRegistro_Jsonclick ;
      private string chkUsuarioAvisoPrivacidad_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlA29UsuarioID ;
      private DateTime A57UsuarioFechaNacimiento ;
      private DateTime A87UsuarioFechaRegistro ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A92UsuarioAvisoPrivacidad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n54UsuarioDirectoAsociado ;
      private bool n67UsuarioProducto ;
      private bool gxdyncontrolsrefreshing ;
      private bool n13PuestoID ;
      private bool n4CiudadID ;
      private bool n87UsuarioFechaRegistro ;
      private bool n57UsuarioFechaNacimiento ;
      private bool returnInSub ;
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
      private GXWebForm Form ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbUsuarioGenero ;
      private GXCombobox cmbUsuarioDirectoAsociado ;
      private GXCombobox cmbUsuarioZona ;
      private GXCombobox cmbUsuarioProducto ;
      private GXCombobox cmbUsuarioRol ;
      private GXCheckbox chkUsuarioAvisoPrivacidad ;
      private IDataStoreProvider pr_default ;
      private int[] H00322_A13PuestoID ;
      private bool[] H00322_n13PuestoID ;
      private int[] H00322_A4CiudadID ;
      private bool[] H00322_n4CiudadID ;
      private int[] H00322_A29UsuarioID ;
      private bool[] H00322_A92UsuarioAvisoPrivacidad ;
      private DateTime[] H00322_A87UsuarioFechaRegistro ;
      private bool[] H00322_n87UsuarioFechaRegistro ;
      private string[] H00322_A83UsuarioReferenciaBROXEL ;
      private string[] H00322_A82UsuarioNoCuentaBROXEL ;
      private string[] H00322_A40UsuarioRol ;
      private string[] H00322_A67UsuarioProducto ;
      private bool[] H00322_n67UsuarioProducto ;
      private string[] H00322_A66UsuarioSucursal ;
      private string[] H00322_A5CiudadDescripcion ;
      private string[] H00322_A2EstadoDescripcion ;
      private int[] H00322_A1EstadoID ;
      private string[] H00322_A17PaisDescripcion ;
      private int[] H00322_A16PaisID ;
      private long[] H00322_A65UsuarioTelefonoSucursal ;
      private long[] H00322_A64UsuarioCelular ;
      private string[] H00322_A63UsuarioZona ;
      private int[] H00322_A62UsuarioCP ;
      private string[] H00322_A61UsuarioDelegacion ;
      private string[] H00322_A60UsuarioColonia ;
      private string[] H00322_A59UsuarioCalleNum ;
      private DateTime[] H00322_A57UsuarioFechaNacimiento ;
      private bool[] H00322_n57UsuarioFechaNacimiento ;
      private string[] H00322_A56UsuarioNombreComercial ;
      private string[] H00322_A55UsuarioRazonSocialAsociado ;
      private string[] H00322_A54UsuarioDirectoAsociado ;
      private bool[] H00322_n54UsuarioDirectoAsociado ;
      private string[] H00322_A53UsuarioGenero ;
      private string[] H00322_A14PuestoDescripcion ;
      private string[] H00322_A33UsuarioKey ;
      private string[] H00322_A32UsuarioPass ;
      private string[] H00322_A31UsuarioCorreo ;
      private string[] H00322_A51UsuarioApellido ;
      private string[] H00322_A30UsuarioNombre ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV7TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpusuariodetallegeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00322;
          prmH00322 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00322", "SELECT T1.`PuestoID`, T1.`CiudadID`, T1.`UsuarioID`, T1.`UsuarioAvisoPrivacidad`, T1.`UsuarioFechaRegistro`, T1.`UsuarioReferenciaBROXEL`, T1.`UsuarioNoCuentaBROXEL`, T1.`UsuarioRol`, T1.`UsuarioProducto`, T1.`UsuarioSucursal`, T3.`CiudadDescripcion`, T4.`EstadoDescripcion`, T3.`EstadoID`, T5.`PaisDescripcion`, T4.`PaisID`, T1.`UsuarioTelefonoSucursal`, T1.`UsuarioCelular`, T1.`UsuarioZona`, T1.`UsuarioCP`, T1.`UsuarioDelegacion`, T1.`UsuarioColonia`, T1.`UsuarioCalleNum`, T1.`UsuarioFechaNacimiento`, T1.`UsuarioNombreComercial`, T1.`UsuarioRazonSocialAsociado`, T1.`UsuarioDirectoAsociado`, T1.`UsuarioGenero`, T2.`PuestoDescripcion`, T1.`UsuarioKey`, T1.`UsuarioPass`, T1.`UsuarioCorreo`, T1.`UsuarioApellido`, T1.`UsuarioNombre` FROM ((((`Usuario` T1 LEFT JOIN `Puesto` T2 ON T2.`PuestoID` = T1.`PuestoID`) LEFT JOIN `Ciudad` T3 ON T3.`CiudadID` = T1.`CiudadID`) LEFT JOIN `Estado` T4 ON T4.`EstadoID` = T3.`EstadoID`) LEFT JOIN `Pais` T5 ON T5.`PaisID` = T4.`PaisID`) WHERE T1.`UsuarioID` = @UsuarioID ORDER BY T1.`UsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00322,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 20);
                ((string[]) buf[9])[0] = rslt.getString(7, 20);
                ((string[]) buf[10])[0] = rslt.getString(8, 40);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getString(10, 20);
                ((string[]) buf[14])[0] = rslt.getVarchar(11);
                ((string[]) buf[15])[0] = rslt.getVarchar(12);
                ((int[]) buf[16])[0] = rslt.getInt(13);
                ((string[]) buf[17])[0] = rslt.getVarchar(14);
                ((int[]) buf[18])[0] = rslt.getInt(15);
                ((long[]) buf[19])[0] = rslt.getLong(16);
                ((long[]) buf[20])[0] = rslt.getLong(17);
                ((string[]) buf[21])[0] = rslt.getString(18, 30);
                ((int[]) buf[22])[0] = rslt.getInt(19);
                ((string[]) buf[23])[0] = rslt.getString(20, 20);
                ((string[]) buf[24])[0] = rslt.getString(21, 20);
                ((string[]) buf[25])[0] = rslt.getString(22, 40);
                ((DateTime[]) buf[26])[0] = rslt.getGXDate(23);
                ((bool[]) buf[27])[0] = rslt.wasNull(23);
                ((string[]) buf[28])[0] = rslt.getVarchar(24);
                ((string[]) buf[29])[0] = rslt.getVarchar(25);
                ((string[]) buf[30])[0] = rslt.getString(26, 20);
                ((bool[]) buf[31])[0] = rslt.wasNull(26);
                ((string[]) buf[32])[0] = rslt.getString(27, 20);
                ((string[]) buf[33])[0] = rslt.getVarchar(28);
                ((string[]) buf[34])[0] = rslt.getVarchar(29);
                ((string[]) buf[35])[0] = rslt.getVarchar(30);
                ((string[]) buf[36])[0] = rslt.getVarchar(31);
                ((string[]) buf[37])[0] = rslt.getString(32, 50);
                ((string[]) buf[38])[0] = rslt.getString(33, 50);
                return;
       }
    }

 }

}
