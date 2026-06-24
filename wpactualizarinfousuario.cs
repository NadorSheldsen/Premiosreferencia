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
   public class wpactualizarinfousuario : GXDataArea
   {
      public wpactualizarinfousuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpactualizarinfousuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_UsuarioID )
      {
         this.AV12UsuarioID = aP0_UsuarioID;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavUsuario_usuariogenero = new GXCombobox();
         cmbavUsuario_usuariodirectoasociado = new GXCombobox();
         cmbavUsuario_usuariozona = new GXCombobox();
         cmbavUsuario_usuarioproducto = new GXCombobox();
         cmbavUsuario_usuariorol = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageempty", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageempty", new Object[] {context});
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
         PA3T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3T2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpactualizarinfousuario.aspx"+UrlEncode(StringUtil.LTrimStr(AV12UsuarioID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpactualizarinfousuario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vUSUARIOROL", StringUtil.RTrim( AV31UsuarioRol));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOROL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31UsuarioRol, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12UsuarioID), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Usuario", AV5Usuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Usuario", AV5Usuario);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV18DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV18DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIO_PUESTOID_DATA", AV17Usuario_PuestoID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIO_PUESTOID_DATA", AV17Usuario_PuestoID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPAISID_DATA", AV20PaisID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPAISID_DATA", AV20PaisID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vESTADOID_DATA", AV21EstadoID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vESTADOID_DATA", AV21EstadoID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIO_CIUDADID_DATA", AV23Usuario_CiudadID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIO_CIUDADID_DATA", AV23Usuario_CiudadID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISTRIBUIDORID_DATA", AV27DistribuidorID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISTRIBUIDORID_DATA", AV27DistribuidorID_Data);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV10CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "vUSUARIOROL", StringUtil.RTrim( AV31UsuarioRol));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOROL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31UsuarioRol, "")), context));
         GxWebStd.gx_hidden_field( context, "USUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12UsuarioID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DISTRIBUIDORESUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A81DistribuidoresUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "USUARIONOMBRE", StringUtil.RTrim( A30UsuarioNombre));
         GxWebStd.gx_hidden_field( context, "USUARIOCORREO", A31UsuarioCorreo);
         GxWebStd.gx_hidden_field( context, "USUARIOROL", StringUtil.RTrim( A40UsuarioRol));
         GxWebStd.gx_hidden_field( context, "USUARIOAPELLIDO", StringUtil.RTrim( A51UsuarioApellido));
         GxWebStd.gx_hidden_field( context, "USUARIONOMBRECOMPLETO", A52UsuarioNombreCompleto);
         GxWebStd.gx_hidden_field( context, "PUESTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PuestoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PUESTODESCRIPCION", A14PuestoDescripcion);
         GxWebStd.gx_hidden_field( context, "USUARIOGENERO", StringUtil.RTrim( A53UsuarioGenero));
         GxWebStd.gx_hidden_field( context, "USUARIODIRECTOASOCIADO", StringUtil.RTrim( A54UsuarioDirectoAsociado));
         GxWebStd.gx_hidden_field( context, "USUARIORAZONSOCIALASOCIADO", A55UsuarioRazonSocialAsociado);
         GxWebStd.gx_hidden_field( context, "USUARIONOMBRECOMERCIAL", A56UsuarioNombreComercial);
         GxWebStd.gx_hidden_field( context, "USUARIOFECHANACIMIENTO", context.localUtil.DToC( A57UsuarioFechaNacimiento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "USUARIOCALLENUM", StringUtil.RTrim( A59UsuarioCalleNum));
         GxWebStd.gx_hidden_field( context, "USUARIOCOLONIA", StringUtil.RTrim( A60UsuarioColonia));
         GxWebStd.gx_hidden_field( context, "USUARIODELEGACION", StringUtil.RTrim( A61UsuarioDelegacion));
         GxWebStd.gx_hidden_field( context, "USUARIOCP", StringUtil.LTrim( StringUtil.NToC( (decimal)(A62UsuarioCP), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "USUARIOZONA", StringUtil.RTrim( A63UsuarioZona));
         GxWebStd.gx_hidden_field( context, "USUARIOCELULAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(A64UsuarioCelular), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "USUARIOTELEFONOSUCURSAL", StringUtil.LTrim( StringUtil.NToC( (decimal)(A65UsuarioTelefonoSucursal), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PAISDESCRIPCION", A17PaisDescripcion);
         GxWebStd.gx_hidden_field( context, "ESTADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ESTADODESCRIPCION", A2EstadoDescripcion);
         GxWebStd.gx_hidden_field( context, "CIUDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CIUDADDESCRIPCION", A5CiudadDescripcion);
         GxWebStd.gx_hidden_field( context, "USUARIOSUCURSAL", StringUtil.RTrim( A66UsuarioSucursal));
         GxWebStd.gx_hidden_field( context, "USUARIOPRODUCTO", A67UsuarioProducto);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV7Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV7Messages);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIO", AV5Usuario);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIO", AV5Usuario);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_PUESTOID_Cls", StringUtil.RTrim( Combo_usuario_puestoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_PUESTOID_Selectedvalue_set", StringUtil.RTrim( Combo_usuario_puestoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_PUESTOID_Emptyitem", StringUtil.BoolToStr( Combo_usuario_puestoid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Cls", StringUtil.RTrim( Combo_paisid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Selectedvalue_set", StringUtil.RTrim( Combo_paisid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Cls", StringUtil.RTrim( Combo_estadoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Selectedvalue_set", StringUtil.RTrim( Combo_estadoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Selectedtext_set", StringUtil.RTrim( Combo_estadoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Datalistproc", StringUtil.RTrim( Combo_estadoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_estadoid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Cls", StringUtil.RTrim( Combo_usuario_ciudadid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Selectedvalue_set", StringUtil.RTrim( Combo_usuario_ciudadid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Selectedtext_set", StringUtil.RTrim( Combo_usuario_ciudadid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Datalistproc", StringUtil.RTrim( Combo_usuario_ciudadid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_usuario_ciudadid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Cls", StringUtil.RTrim( Combo_distribuidorid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Selectedvalue_set", StringUtil.RTrim( Combo_distribuidorid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Width", StringUtil.RTrim( Dvpanel_datosdistribuidor_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Autowidth", StringUtil.BoolToStr( Dvpanel_datosdistribuidor_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Autoheight", StringUtil.BoolToStr( Dvpanel_datosdistribuidor_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Cls", StringUtil.RTrim( Dvpanel_datosdistribuidor_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Title", StringUtil.RTrim( Dvpanel_datosdistribuidor_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Collapsible", StringUtil.BoolToStr( Dvpanel_datosdistribuidor_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Collapsed", StringUtil.BoolToStr( Dvpanel_datosdistribuidor_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_datosdistribuidor_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Iconposition", StringUtil.RTrim( Dvpanel_datosdistribuidor_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_DATOSDISTRIBUIDOR_Autoscroll", StringUtil.BoolToStr( Dvpanel_datosdistribuidor_Autoscroll));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Selectedvalue_get", StringUtil.RTrim( Combo_distribuidorid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Selectedvalue_get", StringUtil.RTrim( Combo_usuario_ciudadid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Selectedvalue_get", StringUtil.RTrim( Combo_estadoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Selectedvalue_get", StringUtil.RTrim( Combo_paisid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_PUESTOID_Selectedvalue_get", StringUtil.RTrim( Combo_usuario_puestoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_PUESTOID_Ddointernalname", StringUtil.RTrim( Combo_usuario_puestoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Ddointernalname", StringUtil.RTrim( Combo_paisid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Ddointernalname", StringUtil.RTrim( Combo_estadoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Ddointernalname", StringUtil.RTrim( Combo_usuario_ciudadid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Ddointernalname", StringUtil.RTrim( Combo_distribuidorid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_PUESTOID_Ddointernalname", StringUtil.RTrim( Combo_usuario_puestoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Ddointernalname", StringUtil.RTrim( Combo_paisid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Ddointernalname", StringUtil.RTrim( Combo_estadoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Ddointernalname", StringUtil.RTrim( Combo_usuario_ciudadid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_DISTRIBUIDORID_Ddointernalname", StringUtil.RTrim( Combo_distribuidorid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_CIUDADID_Selectedvalue_get", StringUtil.RTrim( Combo_usuario_ciudadid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTADOID_Selectedvalue_get", StringUtil.RTrim( Combo_estadoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Selectedvalue_get", StringUtil.RTrim( Combo_paisid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIO_PUESTOID_Selectedvalue_get", StringUtil.RTrim( Combo_usuario_puestoid_Selectedvalue_get));
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
            WE3T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3T2( ) ;
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
         GXEncryptionTmp = "wpactualizarinfousuario.aspx"+UrlEncode(StringUtil.LTrimStr(AV12UsuarioID,9,0));
         return formatLink("wpactualizarinfousuario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WPActualizarInfoUsuario" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WPActualizar Info Usuario", "") ;
      }

      protected void WB3T0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "start", "top", "", "", "div");
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
            ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarionombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarionombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarionombre_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuarionombre), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuarionombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarionombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarionombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarioapellido_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarioapellido_Internalname, context.GetMessage( "Apellido(s)", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarioapellido_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioapellido), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuarioapellido, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarioapellido_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarioapellido_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocorreo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocorreo_Internalname, context.GetMessage( "Correo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocorreo_Internalname, AV5Usuario.gxTpr_Usuariocorreo, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariocorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocorreo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocorreo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuariogenero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuariogenero_Internalname, context.GetMessage( "Género", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariogenero, cmbavUsuario_usuariogenero_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariogenero), 1, cmbavUsuario_usuariogenero_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUsuario_usuariogenero.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 0, "HLP_WPActualizarInfoUsuario.htm");
            cmbavUsuario_usuariogenero.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariogenero);
            AssignProp("", false, cmbavUsuario_usuariogenero_Internalname, "Values", (string)(cmbavUsuario_usuariogenero.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavUsuario_usuariofechanacimiento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariofechanacimiento_Internalname, context.localUtil.Format(AV5Usuario.gxTpr_Usuariofechanacimiento, "99/99/9999"), context.localUtil.Format( AV5Usuario.gxTpr_Usuariofechanacimiento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariofechanacimiento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariofechanacimiento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_bitmap( context, edtavUsuario_usuariofechanacimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavUsuario_usuariofechanacimiento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPActualizarInfoUsuario.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocelular_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocelular_Internalname, context.GetMessage( "Celular", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocelular_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Usuariocelular), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavUsuario_usuariocelular_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariocelular), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariocelular), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocelular_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocelular_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedusuario_puestoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_usuario_puestoid_Internalname, context.GetMessage( "Puesto", ""), "", "", lblTextblockcombo_usuario_puestoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_usuario_puestoid.SetProperty("Caption", Combo_usuario_puestoid_Caption);
            ucCombo_usuario_puestoid.SetProperty("Cls", Combo_usuario_puestoid_Cls);
            ucCombo_usuario_puestoid.SetProperty("EmptyItem", Combo_usuario_puestoid_Emptyitem);
            ucCombo_usuario_puestoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV18DDO_TitleSettingsIcons);
            ucCombo_usuario_puestoid.SetProperty("DropDownOptionsData", AV17Usuario_PuestoID_Data);
            ucCombo_usuario_puestoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_usuario_puestoid_Internalname, "COMBO_USUARIO_PUESTOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPass_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPass_Internalname, context.GetMessage( "Contraseña", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPass_Internalname, StringUtil.RTrim( AV13Pass), StringUtil.RTrim( context.localUtil.Format( AV13Pass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\""+" "+"data-gx-password-reveal"+" "+"idenableshowpasswordhint=\"True\""+" ", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPass_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPass_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPass2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPass2_Internalname, context.GetMessage( "Confirmar contraseña", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPass2_Internalname, StringUtil.RTrim( AV14Pass2), StringUtil.RTrim( context.localUtil.Format( AV14Pass2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\""+" "+"data-gx-password-reveal"+" "+"idenableshowpasswordhint=\"True\""+" ", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPass2_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPass2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, " ", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_datosdistribuidor.SetProperty("Width", Dvpanel_datosdistribuidor_Width);
            ucDvpanel_datosdistribuidor.SetProperty("AutoWidth", Dvpanel_datosdistribuidor_Autowidth);
            ucDvpanel_datosdistribuidor.SetProperty("AutoHeight", Dvpanel_datosdistribuidor_Autoheight);
            ucDvpanel_datosdistribuidor.SetProperty("Cls", Dvpanel_datosdistribuidor_Cls);
            ucDvpanel_datosdistribuidor.SetProperty("Title", Dvpanel_datosdistribuidor_Title);
            ucDvpanel_datosdistribuidor.SetProperty("Collapsible", Dvpanel_datosdistribuidor_Collapsible);
            ucDvpanel_datosdistribuidor.SetProperty("Collapsed", Dvpanel_datosdistribuidor_Collapsed);
            ucDvpanel_datosdistribuidor.SetProperty("ShowCollapseIcon", Dvpanel_datosdistribuidor_Showcollapseicon);
            ucDvpanel_datosdistribuidor.SetProperty("IconPosition", Dvpanel_datosdistribuidor_Iconposition);
            ucDvpanel_datosdistribuidor.SetProperty("AutoScroll", Dvpanel_datosdistribuidor_Autoscroll);
            ucDvpanel_datosdistribuidor.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_datosdistribuidor_Internalname, "DVPANEL_DATOSDISTRIBUIDORContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_DATOSDISTRIBUIDORContainer"+"DatosDistribuidor"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatosdistribuidor_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariorazonsocialasociado_Internalname, AV5Usuario.gxTpr_Usuariorazonsocialasociado, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariorazonsocialasociado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariorazonsocialasociado_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariorazonsocialasociado_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPActualizarInfoUsuario.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarionombrecomercial_Internalname, AV5Usuario.gxTpr_Usuarionombrecomercial, StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuarionombrecomercial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarionombrecomercial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarionombrecomercial_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPActualizarInfoUsuario.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariosucursal_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariosucursal), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariosucursal, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariosucursal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariosucursal_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPActualizarInfoUsuario.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariodirectoasociado, cmbavUsuario_usuariodirectoasociado_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariodirectoasociado), 1, cmbavUsuario_usuariodirectoasociado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUsuario_usuariodirectoasociado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "", true, 0, "HLP_WPActualizarInfoUsuario.htm");
            cmbavUsuario_usuariodirectoasociado.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariodirectoasociado);
            AssignProp("", false, cmbavUsuario_usuariodirectoasociado_Internalname, "Values", (string)(cmbavUsuario_usuariodirectoasociado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedpaisid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_paisid_Internalname, context.GetMessage( "País", ""), "", "", lblTextblockcombo_paisid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_paisid.SetProperty("Caption", Combo_paisid_Caption);
            ucCombo_paisid.SetProperty("Cls", Combo_paisid_Cls);
            ucCombo_paisid.SetProperty("DropDownOptionsTitleSettingsIcons", AV18DDO_TitleSettingsIcons);
            ucCombo_paisid.SetProperty("DropDownOptionsData", AV20PaisID_Data);
            ucCombo_paisid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_paisid_Internalname, "COMBO_PAISIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedestadoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_estadoid_Internalname, context.GetMessage( "Estado", ""), "", "", lblTextblockcombo_estadoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_estadoid.SetProperty("Caption", Combo_estadoid_Caption);
            ucCombo_estadoid.SetProperty("Cls", Combo_estadoid_Cls);
            ucCombo_estadoid.SetProperty("DataListProc", Combo_estadoid_Datalistproc);
            ucCombo_estadoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV18DDO_TitleSettingsIcons);
            ucCombo_estadoid.SetProperty("DropDownOptionsData", AV21EstadoID_Data);
            ucCombo_estadoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_estadoid_Internalname, "COMBO_ESTADOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedusuario_ciudadid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_usuario_ciudadid_Internalname, context.GetMessage( "Ciudad", ""), "", "", lblTextblockcombo_usuario_ciudadid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_usuario_ciudadid.SetProperty("Caption", Combo_usuario_ciudadid_Caption);
            ucCombo_usuario_ciudadid.SetProperty("Cls", Combo_usuario_ciudadid_Cls);
            ucCombo_usuario_ciudadid.SetProperty("DataListProc", Combo_usuario_ciudadid_Datalistproc);
            ucCombo_usuario_ciudadid.SetProperty("DropDownOptionsTitleSettingsIcons", AV18DDO_TitleSettingsIcons);
            ucCombo_usuario_ciudadid.SetProperty("DropDownOptionsData", AV23Usuario_CiudadID_Data);
            ucCombo_usuario_ciudadid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_usuario_ciudadid_Internalname, "COMBO_USUARIO_CIUDADIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocallenum_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocallenum_Internalname, context.GetMessage( "Calle y número", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocallenum_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariocallenum), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariocallenum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocallenum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocallenum_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocolonia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocolonia_Internalname, context.GetMessage( "Colonia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocolonia_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariocolonia), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariocolonia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocolonia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocolonia_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariodelegacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariodelegacion_Internalname, context.GetMessage( "Delegación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariodelegacion_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariodelegacion), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuariodelegacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,133);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariodelegacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariodelegacion_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariocp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariocp_Internalname, context.GetMessage( "Código Postal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariocp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Usuariocp), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavUsuario_usuariocp_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariocp), "ZZZZ9") : context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariocp), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,137);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariocp_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariocp_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuariozona_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuariozona_Internalname, context.GetMessage( "Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariozona, cmbavUsuario_usuariozona_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariozona), 1, cmbavUsuario_usuariozona_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUsuario_usuariozona.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,142);\"", "", true, 0, "HLP_WPActualizarInfoUsuario.htm");
            cmbavUsuario_usuariozona.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariozona);
            AssignProp("", false, cmbavUsuario_usuariozona_Internalname, "Values", (string)(cmbavUsuario_usuariozona.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuariotelefonosucursal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuariotelefonosucursal_Internalname, context.GetMessage( "Teléfono Sucursal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuariotelefonosucursal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Usuariotelefonosucursal), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavUsuario_usuariotelefonosucursal_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariotelefonosucursal), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuariotelefonosucursal), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuariotelefonosucursal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuariotelefonosucursal_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUsuario_usuarioproducto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUsuario_usuarioproducto_Internalname, context.GetMessage( "Producto que vendes", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuarioproducto, cmbavUsuario_usuarioproducto_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioproducto), 1, cmbavUsuario_usuarioproducto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavUsuario_usuarioproducto.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "", true, 0, "HLP_WPActualizarInfoUsuario.htm");
            cmbavUsuario_usuarioproducto.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioproducto);
            AssignProp("", false, cmbavUsuario_usuarioproducto_Internalname, "Values", (string)(cmbavUsuario_usuarioproducto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarionocuentabroxel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarionocuentabroxel_Internalname, context.GetMessage( "No Cuenta BROXEL", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarionocuentabroxel_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuarionocuentabroxel), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuarionocuentabroxel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,155);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarionocuentabroxel_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarionocuentabroxel_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsuario_usuarioreferenciabroxel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuario_usuarioreferenciabroxel_Internalname, context.GetMessage( "Referencia BROXEL", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarioreferenciabroxel_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioreferenciabroxel), StringUtil.RTrim( context.localUtil.Format( AV5Usuario.gxTpr_Usuarioreferenciabroxel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,160);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarioreferenciabroxel_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsuario_usuarioreferenciabroxel_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledistribuidor_Internalname, divTabledistribuidor_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCombo_distribuidorid_cell_Internalname, 1, 0, "px", 0, "px", divCombo_distribuidorid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplitteddistribuidorid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_distribuidorid_Internalname, context.GetMessage( "Distribuidor", ""), "", "", lblTextblockcombo_distribuidorid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_distribuidorid.SetProperty("Caption", Combo_distribuidorid_Caption);
            ucCombo_distribuidorid.SetProperty("Cls", Combo_distribuidorid_Cls);
            ucCombo_distribuidorid.SetProperty("DropDownOptionsTitleSettingsIcons", AV18DDO_TitleSettingsIcons);
            ucCombo_distribuidorid.SetProperty("DropDownOptionsData", AV27DistribuidorID_Data);
            ucCombo_distribuidorid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_distribuidorid_Internalname, "COMBO_DISTRIBUIDORIDContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPActualizarInfoUsuario.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPaisid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15PaisID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15PaisID), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,181);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPaisid_Jsonclick, 0, "Attribute", "", "", "", "", edtavPaisid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPActualizarInfoUsuario.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 182,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEstadoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16EstadoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16EstadoID), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,182);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEstadoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavEstadoid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPActualizarInfoUsuario.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 183,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDistribuidorid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26DistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV26DistribuidorID), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,183);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDistribuidorid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDistribuidorid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPActualizarInfoUsuario.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUsuario_usuariorol, cmbavUsuario_usuariorol_Internalname, StringUtil.RTrim( AV5Usuario.gxTpr_Usuariorol), 1, cmbavUsuario_usuariorol_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavUsuario_usuariorol.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,184);\"", "", true, 0, "HLP_WPActualizarInfoUsuario.htm");
            cmbavUsuario_usuariorol.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariorol);
            AssignProp("", false, cmbavUsuario_usuariorol_Internalname, "Values", (string)(cmbavUsuario_usuariorol.ToJavascriptSource()), true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 185,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuario_usuarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Usuario.gxTpr_Usuarioid), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Usuario.gxTpr_Usuarioid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,185);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuario_usuarioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuario_usuarioid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPActualizarInfoUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3T2( )
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
         Form.Meta.addItem("description", context.GetMessage( "WPActualizar Info Usuario", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3T0( ) ;
      }

      protected void WS3T2( )
      {
         START3T2( ) ;
         EVT3T2( ) ;
      }

      protected void EVT3T2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_USUARIO_PUESTOID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_usuario_puestoid.Onoptionclicked */
                              E113T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_PAISID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_paisid.Onoptionclicked */
                              E123T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_ESTADOID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_estadoid.Onoptionclicked */
                              E133T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_USUARIO_CIUDADID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_usuario_ciudadid.Onoptionclicked */
                              E143T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E153T2 ();
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
                                    E163T2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E173T2 ();
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

      protected void WE3T2( )
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

      protected void PA3T2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpactualizarinfousuario.aspx")), "wpactualizarinfousuario.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpactualizarinfousuario.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "UsuarioID");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV12UsuarioID = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV12UsuarioID", StringUtil.LTrimStr( (decimal)(AV12UsuarioID), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12UsuarioID), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavUsuario_usuarionombre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
            AssignProp("", false, cmbavUsuario_usuariogenero_Internalname, "Values", cmbavUsuario_usuariogenero.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuariodirectoasociado.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariodirectoasociado = cmbavUsuario_usuariodirectoasociado.getValidValue(AV5Usuario.gxTpr_Usuariodirectoasociado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuariodirectoasociado.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariodirectoasociado);
            AssignProp("", false, cmbavUsuario_usuariodirectoasociado_Internalname, "Values", cmbavUsuario_usuariodirectoasociado.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuariozona.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariozona = cmbavUsuario_usuariozona.getValidValue(AV5Usuario.gxTpr_Usuariozona);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuariozona.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariozona);
            AssignProp("", false, cmbavUsuario_usuariozona_Internalname, "Values", cmbavUsuario_usuariozona.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuarioproducto.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuarioproducto = cmbavUsuario_usuarioproducto.getValidValue(AV5Usuario.gxTpr_Usuarioproducto);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuarioproducto.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioproducto);
            AssignProp("", false, cmbavUsuario_usuarioproducto_Internalname, "Values", cmbavUsuario_usuarioproducto.ToJavascriptSource(), true);
         }
         if ( cmbavUsuario_usuariorol.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariorol = cmbavUsuario_usuariorol.getValidValue(AV5Usuario.gxTpr_Usuariorol);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUsuario_usuariorol.CurrentValue = StringUtil.RTrim( AV5Usuario.gxTpr_Usuariorol);
            AssignProp("", false, cmbavUsuario_usuariorol_Internalname, "Values", cmbavUsuario_usuariorol.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF3T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E173T2 ();
            WB3T0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3T2( )
      {
         GxWebStd.gx_hidden_field( context, "vUSUARIOROL", StringUtil.RTrim( AV31UsuarioRol));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOROL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31UsuarioRol, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E153T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vUSUARIO"), AV5Usuario);
            ajax_req_read_hidden_sdt(cgiGet( "Usuario"), AV5Usuario);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV18DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vUSUARIO_PUESTOID_DATA"), AV17Usuario_PuestoID_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vPAISID_DATA"), AV20PaisID_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vESTADOID_DATA"), AV21EstadoID_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vUSUARIO_CIUDADID_DATA"), AV23Usuario_CiudadID_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vDISTRIBUIDORID_DATA"), AV27DistribuidorID_Data);
            /* Read saved values. */
            Combo_usuario_puestoid_Cls = cgiGet( "COMBO_USUARIO_PUESTOID_Cls");
            Combo_usuario_puestoid_Selectedvalue_set = cgiGet( "COMBO_USUARIO_PUESTOID_Selectedvalue_set");
            Combo_usuario_puestoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_USUARIO_PUESTOID_Emptyitem"));
            Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
            Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
            Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
            Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
            Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
            Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
            Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
            Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
            Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
            Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
            Combo_paisid_Cls = cgiGet( "COMBO_PAISID_Cls");
            Combo_paisid_Selectedvalue_set = cgiGet( "COMBO_PAISID_Selectedvalue_set");
            Combo_estadoid_Cls = cgiGet( "COMBO_ESTADOID_Cls");
            Combo_estadoid_Selectedvalue_set = cgiGet( "COMBO_ESTADOID_Selectedvalue_set");
            Combo_estadoid_Selectedtext_set = cgiGet( "COMBO_ESTADOID_Selectedtext_set");
            Combo_estadoid_Datalistproc = cgiGet( "COMBO_ESTADOID_Datalistproc");
            Combo_estadoid_Datalistprocparametersprefix = cgiGet( "COMBO_ESTADOID_Datalistprocparametersprefix");
            Combo_usuario_ciudadid_Cls = cgiGet( "COMBO_USUARIO_CIUDADID_Cls");
            Combo_usuario_ciudadid_Selectedvalue_set = cgiGet( "COMBO_USUARIO_CIUDADID_Selectedvalue_set");
            Combo_usuario_ciudadid_Selectedtext_set = cgiGet( "COMBO_USUARIO_CIUDADID_Selectedtext_set");
            Combo_usuario_ciudadid_Datalistproc = cgiGet( "COMBO_USUARIO_CIUDADID_Datalistproc");
            Combo_usuario_ciudadid_Datalistprocparametersprefix = cgiGet( "COMBO_USUARIO_CIUDADID_Datalistprocparametersprefix");
            Combo_distribuidorid_Cls = cgiGet( "COMBO_DISTRIBUIDORID_Cls");
            Combo_distribuidorid_Selectedvalue_set = cgiGet( "COMBO_DISTRIBUIDORID_Selectedvalue_set");
            Dvpanel_datosdistribuidor_Width = cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Width");
            Dvpanel_datosdistribuidor_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Autowidth"));
            Dvpanel_datosdistribuidor_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Autoheight"));
            Dvpanel_datosdistribuidor_Cls = cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Cls");
            Dvpanel_datosdistribuidor_Title = cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Title");
            Dvpanel_datosdistribuidor_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Collapsible"));
            Dvpanel_datosdistribuidor_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Collapsed"));
            Dvpanel_datosdistribuidor_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Showcollapseicon"));
            Dvpanel_datosdistribuidor_Iconposition = cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Iconposition");
            Dvpanel_datosdistribuidor_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_DATOSDISTRIBUIDOR_Autoscroll"));
            Combo_usuario_puestoid_Ddointernalname = cgiGet( "COMBO_USUARIO_PUESTOID_Ddointernalname");
            Combo_paisid_Ddointernalname = cgiGet( "COMBO_PAISID_Ddointernalname");
            Combo_estadoid_Ddointernalname = cgiGet( "COMBO_ESTADOID_Ddointernalname");
            Combo_usuario_ciudadid_Ddointernalname = cgiGet( "COMBO_USUARIO_CIUDADID_Ddointernalname");
            Combo_distribuidorid_Ddointernalname = cgiGet( "COMBO_DISTRIBUIDORID_Ddointernalname");
            Combo_usuario_ciudadid_Selectedvalue_get = cgiGet( "COMBO_USUARIO_CIUDADID_Selectedvalue_get");
            Combo_estadoid_Selectedvalue_get = cgiGet( "COMBO_ESTADOID_Selectedvalue_get");
            Combo_paisid_Selectedvalue_get = cgiGet( "COMBO_PAISID_Selectedvalue_get");
            Combo_usuario_puestoid_Selectedvalue_get = cgiGet( "COMBO_USUARIO_PUESTOID_Selectedvalue_get");
            /* Read variables values. */
            AV5Usuario.gxTpr_Usuarionombre = cgiGet( edtavUsuario_usuarionombre_Internalname);
            AV5Usuario.gxTpr_Usuarioapellido = cgiGet( edtavUsuario_usuarioapellido_Internalname);
            AV5Usuario.gxTpr_Usuariocorreo = cgiGet( edtavUsuario_usuariocorreo_Internalname);
            cmbavUsuario_usuariogenero.CurrentValue = cgiGet( cmbavUsuario_usuariogenero_Internalname);
            AV5Usuario.gxTpr_Usuariogenero = cgiGet( cmbavUsuario_usuariogenero_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavUsuario_usuariofechanacimiento_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha de nacimiento", "")}), 1, "USUARIO_USUARIOFECHANACIMIENTO");
               GX_FocusControl = edtavUsuario_usuariofechanacimiento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Usuario.gxTpr_Usuariofechanacimiento = DateTime.MinValue;
            }
            else
            {
               AV5Usuario.gxTpr_Usuariofechanacimiento = context.localUtil.CToD( cgiGet( edtavUsuario_usuariofechanacimiento_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariocelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariocelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_USUARIOCELULAR");
               GX_FocusControl = edtavUsuario_usuariocelular_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Usuario.gxTpr_Usuariocelular = 0;
            }
            else
            {
               AV5Usuario.gxTpr_Usuariocelular = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_usuariocelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV13Pass = cgiGet( edtavPass_Internalname);
            AssignAttri("", false, "AV13Pass", AV13Pass);
            AV14Pass2 = cgiGet( edtavPass2_Internalname);
            AssignAttri("", false, "AV14Pass2", AV14Pass2);
            AV5Usuario.gxTpr_Usuariorazonsocialasociado = cgiGet( edtavUsuario_usuariorazonsocialasociado_Internalname);
            AV5Usuario.gxTpr_Usuarionombrecomercial = cgiGet( edtavUsuario_usuarionombrecomercial_Internalname);
            AV5Usuario.gxTpr_Usuariosucursal = cgiGet( edtavUsuario_usuariosucursal_Internalname);
            cmbavUsuario_usuariodirectoasociado.CurrentValue = cgiGet( cmbavUsuario_usuariodirectoasociado_Internalname);
            AV5Usuario.gxTpr_Usuariodirectoasociado = cgiGet( cmbavUsuario_usuariodirectoasociado_Internalname);
            AV5Usuario.gxTpr_Usuariocallenum = cgiGet( edtavUsuario_usuariocallenum_Internalname);
            AV5Usuario.gxTpr_Usuariocolonia = cgiGet( edtavUsuario_usuariocolonia_Internalname);
            AV5Usuario.gxTpr_Usuariodelegacion = cgiGet( edtavUsuario_usuariodelegacion_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariocp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariocp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_USUARIOCP");
               GX_FocusControl = edtavUsuario_usuariocp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Usuario.gxTpr_Usuariocp = 0;
            }
            else
            {
               AV5Usuario.gxTpr_Usuariocp = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_usuariocp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            cmbavUsuario_usuariozona.CurrentValue = cgiGet( cmbavUsuario_usuariozona_Internalname);
            AV5Usuario.gxTpr_Usuariozona = cgiGet( cmbavUsuario_usuariozona_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariotelefonosucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuariotelefonosucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_USUARIOTELEFONOSUCURSAL");
               GX_FocusControl = edtavUsuario_usuariotelefonosucursal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Usuario.gxTpr_Usuariotelefonosucursal = 0;
            }
            else
            {
               AV5Usuario.gxTpr_Usuariotelefonosucursal = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_usuariotelefonosucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            cmbavUsuario_usuarioproducto.CurrentValue = cgiGet( cmbavUsuario_usuarioproducto_Internalname);
            AV5Usuario.gxTpr_Usuarioproducto = cgiGet( cmbavUsuario_usuarioproducto_Internalname);
            AV5Usuario.gxTpr_Usuarionocuentabroxel = cgiGet( edtavUsuario_usuarionocuentabroxel_Internalname);
            AV5Usuario.gxTpr_Usuarioreferenciabroxel = cgiGet( edtavUsuario_usuarioreferenciabroxel_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPaisid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPaisid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPAISID");
               GX_FocusControl = edtavPaisid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15PaisID = 0;
               AssignAttri("", false, "AV15PaisID", StringUtil.LTrimStr( (decimal)(AV15PaisID), 9, 0));
            }
            else
            {
               AV15PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPaisid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15PaisID", StringUtil.LTrimStr( (decimal)(AV15PaisID), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEstadoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEstadoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vESTADOID");
               GX_FocusControl = edtavEstadoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16EstadoID = 0;
               AssignAttri("", false, "AV16EstadoID", StringUtil.LTrimStr( (decimal)(AV16EstadoID), 9, 0));
            }
            else
            {
               AV16EstadoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavEstadoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV16EstadoID", StringUtil.LTrimStr( (decimal)(AV16EstadoID), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDistribuidorid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDistribuidorid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDISTRIBUIDORID");
               GX_FocusControl = edtavDistribuidorid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV26DistribuidorID = 0;
               AssignAttri("", false, "AV26DistribuidorID", StringUtil.LTrimStr( (decimal)(AV26DistribuidorID), 9, 0));
            }
            else
            {
               AV26DistribuidorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavDistribuidorid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26DistribuidorID", StringUtil.LTrimStr( (decimal)(AV26DistribuidorID), 9, 0));
            }
            cmbavUsuario_usuariorol.CurrentValue = cgiGet( cmbavUsuario_usuariorol_Internalname);
            AV5Usuario.gxTpr_Usuariorol = cgiGet( cmbavUsuario_usuariorol_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsuario_usuarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIO_USUARIOID");
               GX_FocusControl = edtavUsuario_usuarioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Usuario.gxTpr_Usuarioid = 0;
            }
            else
            {
               AV5Usuario.gxTpr_Usuarioid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsuario_usuarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
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
         E153T2 ();
         if (returnInSub) return;
      }

      protected void E153T2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'OBTIENEDATOSSESION' */
         S112 ();
         if (returnInSub) return;
         AV8TrnMode = "UPD";
         AV9LoadSuccess = true;
         if ( StringUtil.StrCmp(AV8TrnMode, "UPD") == 0 )
         {
            AV5Usuario.Load(AV12UsuarioID);
            AV9LoadSuccess = AV5Usuario.Success();
            if ( ! AV9LoadSuccess )
            {
               AV7Messages = AV5Usuario.GetMessages();
               /* Execute user subroutine: 'SHOW MESSAGES' */
               S122 ();
               if (returnInSub) return;
            }
         }
         else
         {
            AV9LoadSuccess = false;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV18DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV18DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavDistribuidorid_Visible = 0;
         AssignProp("", false, edtavDistribuidorid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDistribuidorid_Visible), 5, 0), true);
         edtavEstadoid_Visible = 0;
         AssignProp("", false, edtavEstadoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEstadoid_Visible), 5, 0), true);
         edtavPaisid_Visible = 0;
         AssignProp("", false, edtavPaisid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPaisid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOUSUARIO_PUESTOID' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOPAISID' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOESTADOID' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOUSUARIO_CIUDADID' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBODISTRIBUIDORID' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S182 ();
         if (returnInSub) return;
         cmbavUsuario_usuariorol.Visible = 0;
         AssignProp("", false, cmbavUsuario_usuariorol_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUsuario_usuariorol.Visible), 5, 0), true);
         edtavUsuario_usuarioid_Visible = 0;
         AssignProp("", false, edtavUsuario_usuarioid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuario_usuarioid_Visible), 5, 0), true);
         AV5Usuario.gxTpr_Usuarioproducto = "";
         AV5Usuario.gxTpr_Ciudadid = 0;
         AV5Usuario.gxTpr_Usuariosucursal = "";
         AV5Usuario.gxTpr_Usuariotelefonosucursal = 0;
         AV5Usuario.gxTpr_Usuariocelular = 0;
         AV5Usuario.gxTpr_Usuariozona = "";
         AV5Usuario.gxTpr_Usuariocp = 0;
         AV5Usuario.gxTpr_Usuariodelegacion = "";
         AV5Usuario.gxTpr_Usuariocolonia = "";
         AV5Usuario.gxTpr_Usuariocallenum = "";
         AV5Usuario.gxTpr_Usuariofechanacimiento = DateTime.MinValue;
         AV5Usuario.gxTpr_Usuarionombrecomercial = "";
         AV5Usuario.gxTpr_Usuariorazonsocialasociado = "";
         AV5Usuario.gxTpr_Usuariodirectoasociado = "";
         AV5Usuario.gxTpr_Usuariogenero = "";
         AV5Usuario.gxTpr_Usuarionocuentabroxel = "";
         AV5Usuario.gxTpr_Usuarioreferenciabroxel = "";
         if ( StringUtil.StrCmp(AV31UsuarioRol, "Participante") == 0 )
         {
            divTabledistribuidor_Visible = 1;
            AssignProp("", false, divTabledistribuidor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTabledistribuidor_Visible), 5, 0), true);
         }
         else
         {
            divTabledistribuidor_Visible = 0;
            AssignProp("", false, divTabledistribuidor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTabledistribuidor_Visible), 5, 0), true);
         }
      }

      protected void E143T2( )
      {
         /* Combo_usuario_ciudadid_Onoptionclicked Routine */
         returnInSub = false;
         AV5Usuario.gxTpr_Ciudadid = (int)(Math.Round(NumberUtil.Val( Combo_usuario_ciudadid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Usuario", AV5Usuario);
      }

      protected void E133T2( )
      {
         /* Combo_estadoid_Onoptionclicked Routine */
         returnInSub = false;
         AV24Cond_EstadoID = AV16EstadoID;
         AssignAttri("", false, "AV24Cond_EstadoID", StringUtil.LTrimStr( (decimal)(AV24Cond_EstadoID), 9, 0));
         AV16EstadoID = (int)(Math.Round(NumberUtil.Val( Combo_estadoid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV16EstadoID", StringUtil.LTrimStr( (decimal)(AV16EstadoID), 9, 0));
         if ( AV24Cond_EstadoID != AV16EstadoID )
         {
            AV5Usuario.gxTpr_Ciudadid = 0;
            Combo_usuario_ciudadid_Selectedvalue_set = "";
            ucCombo_usuario_ciudadid.SendProperty(context, "", false, Combo_usuario_ciudadid_Internalname, "SelectedValue_set", Combo_usuario_ciudadid_Selectedvalue_set);
            Combo_usuario_ciudadid_Selectedtext_set = "";
            ucCombo_usuario_ciudadid.SendProperty(context, "", false, Combo_usuario_ciudadid_Internalname, "SelectedText_set", Combo_usuario_ciudadid_Selectedtext_set);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Usuario", AV5Usuario);
      }

      protected void E123T2( )
      {
         /* Combo_paisid_Onoptionclicked Routine */
         returnInSub = false;
         AV22Cond_PaisID = AV15PaisID;
         AssignAttri("", false, "AV22Cond_PaisID", StringUtil.LTrimStr( (decimal)(AV22Cond_PaisID), 9, 0));
         AV15PaisID = (int)(Math.Round(NumberUtil.Val( Combo_paisid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV15PaisID", StringUtil.LTrimStr( (decimal)(AV15PaisID), 9, 0));
         if ( AV22Cond_PaisID != AV15PaisID )
         {
            AV16EstadoID = 0;
            AssignAttri("", false, "AV16EstadoID", StringUtil.LTrimStr( (decimal)(AV16EstadoID), 9, 0));
            Combo_estadoid_Selectedvalue_set = "";
            ucCombo_estadoid.SendProperty(context, "", false, Combo_estadoid_Internalname, "SelectedValue_set", Combo_estadoid_Selectedvalue_set);
            Combo_estadoid_Selectedtext_set = "";
            ucCombo_estadoid.SendProperty(context, "", false, Combo_estadoid_Internalname, "SelectedText_set", Combo_estadoid_Selectedtext_set);
         }
         /*  Sending Event outputs  */
      }

      protected void E113T2( )
      {
         /* Combo_usuario_puestoid_Onoptionclicked Routine */
         returnInSub = false;
         AV5Usuario.gxTpr_Puestoid = (int)(Math.Round(NumberUtil.Val( Combo_usuario_puestoid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Usuario", AV5Usuario);
      }

      protected void S192( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV10CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuarionombre)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Nombre", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuarionombre_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuarioapellido)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Apellido(s)", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuarioapellido_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuariocorreo)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Correo", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuariocorreo_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuariogenero)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Género", ""), "", "", "", "", "", "", "", ""),  "error",  cmbavUsuario_usuariogenero_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( (0==AV5Usuario.gxTpr_Usuariocelular) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Celular", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuariocelular_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( (0==AV5Usuario.gxTpr_Puestoid) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Puesto", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_usuario_puestoid_Ddointernalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13Pass)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Contraseña", ""), "", "", "", "", "", "", "", ""),  "error",  edtavPass_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14Pass2)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Confirmar contraseña", ""), "", "", "", "", "", "", "", ""),  "error",  edtavPass2_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( (0==AV15PaisID) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "País", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_paisid_Ddointernalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( (0==AV16EstadoID) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_estadoid_Ddointernalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( (0==AV5Usuario.gxTpr_Ciudadid) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_usuario_ciudadid_Ddointernalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuariocallenum)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Calle y número", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuariocallenum_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuariocolonia)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Colonia", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuariocolonia_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuariodelegacion)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Delegación", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuariodelegacion_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( (0==AV5Usuario.gxTpr_Usuariocp) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Código Postal", ""), "", "", "", "", "", "", "", ""),  "error",  edtavUsuario_usuariocp_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Usuario.gxTpr_Usuariozona)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Zona", ""), "", "", "", "", "", "", "", ""),  "error",  cmbavUsuario_usuariozona_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
         if ( ( ( StringUtil.StrCmp(AV31UsuarioRol, "Participante") == 0 ) ) && (0==AV26DistribuidorID) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Distribuidor", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_distribuidorid_Ddointernalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
      }

      protected void S182( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31UsuarioRol, "Participante") == 0 )
         {
            divCombo_distribuidorid_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell";
            AssignProp("", false, divCombo_distribuidorid_cell_Internalname, "Class", divCombo_distribuidorid_cell_Class, true);
         }
         else
         {
            divCombo_distribuidorid_cell_Class = "col-xs-12 DataContentCellFL ExtendedComboCell";
            AssignProp("", false, divCombo_distribuidorid_cell_Internalname, "Class", divCombo_distribuidorid_cell_Class, true);
         }
      }

      protected void S172( )
      {
         /* 'LOADCOMBODISTRIBUIDORID' Routine */
         returnInSub = false;
         /* Using cursor H003T2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11DistribuidorDescripcion = H003T2_A11DistribuidorDescripcion[0];
            A10DistribuidorID = H003T2_A10DistribuidorID[0];
            if ( ! StringUtil.Like( A11DistribuidorDescripcion , StringUtil.PadR( context.GetMessage( "YOKOHAMA", "") , 254 , "%"),  ' ' ) )
            {
               AV19Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV19Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A10DistribuidorID), 9, 0));
               AV19Combo_DataItem.gxTpr_Title = A11DistribuidorDescripcion;
               AV27DistribuidorID_Data.Add(AV19Combo_DataItem, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_distribuidorid_Selectedvalue_set = ((0==AV26DistribuidorID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV26DistribuidorID), 9, 0)));
         ucCombo_distribuidorid.SendProperty(context, "", false, Combo_distribuidorid_Internalname, "SelectedValue_set", Combo_distribuidorid_Selectedvalue_set);
      }

      protected void S162( )
      {
         /* 'LOADCOMBOUSUARIO_CIUDADID' Routine */
         returnInSub = false;
         Combo_usuario_ciudadid_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"Usuario_CiudadID\", \"Cond_PaisID\": \"#%1#\", \"Cond_EstadoID\": \"#%2#\"", edtavPaisid_Internalname, edtavEstadoid_Internalname, "", "", "", "", "", "", "");
         ucCombo_usuario_ciudadid.SendProperty(context, "", false, Combo_usuario_ciudadid_Internalname, "DataListProcParametersPrefix", Combo_usuario_ciudadid_Datalistprocparametersprefix);
         AV24Cond_EstadoID = AV16EstadoID;
         AssignAttri("", false, "AV24Cond_EstadoID", StringUtil.LTrimStr( (decimal)(AV24Cond_EstadoID), 9, 0));
         AV59GXLvl250 = 0;
         /* Using cursor H003T3 */
         pr_default.execute(1, new Object[] {AV5Usuario.gxTpr_Ciudadid, AV24Cond_EstadoID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A1EstadoID = H003T3_A1EstadoID[0];
            A4CiudadID = H003T3_A4CiudadID[0];
            n4CiudadID = H003T3_n4CiudadID[0];
            A5CiudadDescripcion = H003T3_A5CiudadDescripcion[0];
            AV59GXLvl250 = 1;
            Combo_usuario_ciudadid_Selectedtext_set = A5CiudadDescripcion;
            ucCombo_usuario_ciudadid.SendProperty(context, "", false, Combo_usuario_ciudadid_Internalname, "SelectedText_set", Combo_usuario_ciudadid_Selectedtext_set);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( AV59GXLvl250 == 0 )
         {
            Combo_usuario_ciudadid_Selectedtext_set = "";
            ucCombo_usuario_ciudadid.SendProperty(context, "", false, Combo_usuario_ciudadid_Internalname, "SelectedText_set", Combo_usuario_ciudadid_Selectedtext_set);
         }
         Combo_usuario_ciudadid_Selectedvalue_set = ((0==AV5Usuario.gxTpr_Ciudadid) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5Usuario.gxTpr_Ciudadid), 9, 0)));
         ucCombo_usuario_ciudadid.SendProperty(context, "", false, Combo_usuario_ciudadid_Internalname, "SelectedValue_set", Combo_usuario_ciudadid_Selectedvalue_set);
      }

      protected void S152( )
      {
         /* 'LOADCOMBOESTADOID' Routine */
         returnInSub = false;
         Combo_estadoid_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"EstadoID\", \"Cond_PaisID\": \"#%1#\", \"Cond_EstadoID\": \"#%2#\"", edtavPaisid_Internalname, edtavEstadoid_Internalname, "", "", "", "", "", "", "");
         ucCombo_estadoid.SendProperty(context, "", false, Combo_estadoid_Internalname, "DataListProcParametersPrefix", Combo_estadoid_Datalistprocparametersprefix);
         AV22Cond_PaisID = AV15PaisID;
         AssignAttri("", false, "AV22Cond_PaisID", StringUtil.LTrimStr( (decimal)(AV22Cond_PaisID), 9, 0));
         AV60GXLvl271 = 0;
         /* Using cursor H003T4 */
         pr_default.execute(2, new Object[] {AV16EstadoID, AV22Cond_PaisID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A16PaisID = H003T4_A16PaisID[0];
            A1EstadoID = H003T4_A1EstadoID[0];
            A2EstadoDescripcion = H003T4_A2EstadoDescripcion[0];
            AV60GXLvl271 = 1;
            Combo_estadoid_Selectedtext_set = A2EstadoDescripcion;
            ucCombo_estadoid.SendProperty(context, "", false, Combo_estadoid_Internalname, "SelectedText_set", Combo_estadoid_Selectedtext_set);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( AV60GXLvl271 == 0 )
         {
            Combo_estadoid_Selectedtext_set = "";
            ucCombo_estadoid.SendProperty(context, "", false, Combo_estadoid_Internalname, "SelectedText_set", Combo_estadoid_Selectedtext_set);
         }
         Combo_estadoid_Selectedvalue_set = ((0==AV16EstadoID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV16EstadoID), 9, 0)));
         ucCombo_estadoid.SendProperty(context, "", false, Combo_estadoid_Internalname, "SelectedValue_set", Combo_estadoid_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOPAISID' Routine */
         returnInSub = false;
         /* Using cursor H003T5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A16PaisID = H003T5_A16PaisID[0];
            A17PaisDescripcion = H003T5_A17PaisDescripcion[0];
            AV19Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV19Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A16PaisID), 9, 0));
            AV19Combo_DataItem.gxTpr_Title = A17PaisDescripcion;
            AV20PaisID_Data.Add(AV19Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_paisid_Selectedvalue_set = ((0==AV15PaisID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV15PaisID), 9, 0)));
         ucCombo_paisid.SendProperty(context, "", false, Combo_paisid_Internalname, "SelectedValue_set", Combo_paisid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOUSUARIO_PUESTOID' Routine */
         returnInSub = false;
         /* Using cursor H003T6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A15PuestoActivo = H003T6_A15PuestoActivo[0];
            A13PuestoID = H003T6_A13PuestoID[0];
            n13PuestoID = H003T6_n13PuestoID[0];
            A14PuestoDescripcion = H003T6_A14PuestoDescripcion[0];
            AV19Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV19Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A13PuestoID), 9, 0));
            AV19Combo_DataItem.gxTpr_Title = A14PuestoDescripcion;
            AV17Usuario_PuestoID_Data.Add(AV19Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_usuario_puestoid_Selectedvalue_set = ((0==AV5Usuario.gxTpr_Puestoid) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5Usuario.gxTpr_Puestoid), 9, 0)));
         ucCombo_usuario_puestoid.SendProperty(context, "", false, Combo_usuario_puestoid_Internalname, "SelectedValue_set", Combo_usuario_puestoid_Selectedvalue_set);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E163T2 ();
         if (returnInSub) return;
      }

      protected void E163T2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ! ( StringUtil.StrCmp(AV13Pass, context.GetMessage( "Yokohama1", "")) == 0 ) )
         {
            if ( StringUtil.StrCmp(AV13Pass, AV14Pass2) == 0 )
            {
               AV25UsuarioKey = Crypto.GetEncryptionKey( );
               AV5Usuario.gxTpr_Usuariopass = Encrypt64( AV14Pass2, AV25UsuarioKey);
               AV5Usuario.gxTpr_Usuariokey = AV25UsuarioKey;
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S192 ();
               if (returnInSub) return;
               if ( AV10CheckRequiredFieldsResult )
               {
                  AV5Usuario.Save();
                  if ( AV5Usuario.Success() )
                  {
                     if ( StringUtil.StrCmp(AV31UsuarioRol, "Participante") == 0 )
                     {
                        /* Using cursor H003T7 */
                        pr_default.execute(5, new Object[] {AV12UsuarioID});
                        while ( (pr_default.getStatus(5) != 101) )
                        {
                           A29UsuarioID = H003T7_A29UsuarioID[0];
                           A81DistribuidoresUsuarioID = H003T7_A81DistribuidoresUsuarioID[0];
                           AV34DistribuidoresUsuario.Load(A81DistribuidoresUsuarioID);
                           AV34DistribuidoresUsuario.Delete();
                           pr_default.readNext(5);
                        }
                        pr_default.close(5);
                        AV35DistribuidoresUsuario2 = new SdtDistribuidoresUsuario(context);
                        AV35DistribuidoresUsuario2.gxTpr_Usuarioid = AV12UsuarioID;
                        AV35DistribuidoresUsuario2.gxTpr_Distribuidorid = AV26DistribuidorID;
                        AV35DistribuidoresUsuario2.Save();
                        if ( AV35DistribuidoresUsuario2.Success() )
                        {
                           context.CommitDataStores("wpactualizarinfousuario",pr_default);
                        }
                     }
                     context.CommitDataStores("wpactualizarinfousuario",pr_default);
                     /* Execute user subroutine: 'GUARDADATOSSESION' */
                     S202 ();
                     if (returnInSub) return;
                     new obtienevalordirectiva(context ).execute(  context.GetMessage( "VALIDAMOSTRARVIDEO", ""), out  AV36VALIDAMOSTRARVIDEO) ;
                     if ( StringUtil.StrCmp(AV36VALIDAMOSTRARVIDEO, context.GetMessage( "TRUE", "")) == 0 )
                     {
                        CallWebObject(formatLink("wpvideo.aspx") );
                        context.wjLocDisableFrm = 1;
                     }
                     else
                     {
                        CallWebObject(formatLink("inicio.aspx") );
                        context.wjLocDisableFrm = 1;
                     }
                  }
                  else
                  {
                     AV7Messages = AV5Usuario.GetMessages();
                     /* Execute user subroutine: 'SHOW MESSAGES' */
                     S122 ();
                     if (returnInSub) return;
                  }
               }
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "Error, las contraseñas no coinciden, intenta de nuevo", ""));
               GX_FocusControl = edtavPass2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               context.DoAjaxSetFocus(GX_FocusControl);
            }
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "La contraseña no puede ser Yokohama1, intente con otra", ""));
            AV13Pass = "";
            AssignAttri("", false, "AV13Pass", AV13Pass);
            AV14Pass2 = "";
            AssignAttri("", false, "AV14Pass2", AV14Pass2);
            GX_FocusControl = edtavPass_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            context.DoAjaxSetFocus(GX_FocusControl);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Usuario", AV5Usuario);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Messages", AV7Messages);
      }

      protected void S122( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV64GXV22 = 1;
         while ( AV64GXV22 <= AV7Messages.Count )
         {
            AV6Message = ((GeneXus.Utils.SdtMessages_Message)AV7Messages.Item(AV64GXV22));
            GX_msglist.addItem(AV6Message.gxTpr_Description);
            AV64GXV22 = (int)(AV64GXV22+1);
         }
      }

      protected void S202( )
      {
         /* 'GUARDADATOSSESION' Routine */
         returnInSub = false;
         /* Using cursor H003T8 */
         pr_default.execute(6, new Object[] {AV12UsuarioID});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A29UsuarioID = H003T8_A29UsuarioID[0];
            A31UsuarioCorreo = H003T8_A31UsuarioCorreo[0];
            A40UsuarioRol = H003T8_A40UsuarioRol[0];
            A13PuestoID = H003T8_A13PuestoID[0];
            n13PuestoID = H003T8_n13PuestoID[0];
            A14PuestoDescripcion = H003T8_A14PuestoDescripcion[0];
            A53UsuarioGenero = H003T8_A53UsuarioGenero[0];
            A54UsuarioDirectoAsociado = H003T8_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = H003T8_n54UsuarioDirectoAsociado[0];
            A55UsuarioRazonSocialAsociado = H003T8_A55UsuarioRazonSocialAsociado[0];
            A56UsuarioNombreComercial = H003T8_A56UsuarioNombreComercial[0];
            A57UsuarioFechaNacimiento = H003T8_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = H003T8_n57UsuarioFechaNacimiento[0];
            A59UsuarioCalleNum = H003T8_A59UsuarioCalleNum[0];
            A60UsuarioColonia = H003T8_A60UsuarioColonia[0];
            A61UsuarioDelegacion = H003T8_A61UsuarioDelegacion[0];
            A62UsuarioCP = H003T8_A62UsuarioCP[0];
            A63UsuarioZona = H003T8_A63UsuarioZona[0];
            A64UsuarioCelular = H003T8_A64UsuarioCelular[0];
            A65UsuarioTelefonoSucursal = H003T8_A65UsuarioTelefonoSucursal[0];
            A16PaisID = H003T8_A16PaisID[0];
            A17PaisDescripcion = H003T8_A17PaisDescripcion[0];
            A1EstadoID = H003T8_A1EstadoID[0];
            A2EstadoDescripcion = H003T8_A2EstadoDescripcion[0];
            A4CiudadID = H003T8_A4CiudadID[0];
            n4CiudadID = H003T8_n4CiudadID[0];
            A5CiudadDescripcion = H003T8_A5CiudadDescripcion[0];
            A66UsuarioSucursal = H003T8_A66UsuarioSucursal[0];
            A67UsuarioProducto = H003T8_A67UsuarioProducto[0];
            n67UsuarioProducto = H003T8_n67UsuarioProducto[0];
            A51UsuarioApellido = H003T8_A51UsuarioApellido[0];
            A30UsuarioNombre = H003T8_A30UsuarioNombre[0];
            A14PuestoDescripcion = H003T8_A14PuestoDescripcion[0];
            A1EstadoID = H003T8_A1EstadoID[0];
            A5CiudadDescripcion = H003T8_A5CiudadDescripcion[0];
            A16PaisID = H003T8_A16PaisID[0];
            A2EstadoDescripcion = H003T8_A2EstadoDescripcion[0];
            A17PaisDescripcion = H003T8_A17PaisDescripcion[0];
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
            AV30SDTUsuario = new SdtSDTUsuario(context);
            AV30SDTUsuario.gxTpr_Usuarioid = A29UsuarioID;
            AV30SDTUsuario.gxTpr_Usuarionombre = A30UsuarioNombre;
            AV30SDTUsuario.gxTpr_Usuariocorreo = A31UsuarioCorreo;
            AV30SDTUsuario.gxTpr_Usuariorol = A40UsuarioRol;
            AV30SDTUsuario.gxTpr_Usuarioapellido = A51UsuarioApellido;
            AV30SDTUsuario.gxTpr_Usuarionombrecompleto = A52UsuarioNombreCompleto;
            AV30SDTUsuario.gxTpr_Puestoid = A13PuestoID;
            AV30SDTUsuario.gxTpr_Puestodescripcion = A14PuestoDescripcion;
            AV30SDTUsuario.gxTpr_Usuariogenero = A53UsuarioGenero;
            AV30SDTUsuario.gxTpr_Usuariodirectoasociado = A54UsuarioDirectoAsociado;
            AV30SDTUsuario.gxTpr_Usuariorazonsocialasociado = A55UsuarioRazonSocialAsociado;
            AV30SDTUsuario.gxTpr_Usuarionombrecomercial = A56UsuarioNombreComercial;
            AV30SDTUsuario.gxTpr_Usuariofechanacimiento = A57UsuarioFechaNacimiento;
            AV30SDTUsuario.gxTpr_Usuariocallenum = A59UsuarioCalleNum;
            AV30SDTUsuario.gxTpr_Usuariocolonia = A60UsuarioColonia;
            AV30SDTUsuario.gxTpr_Usuariodelegacion = A61UsuarioDelegacion;
            AV30SDTUsuario.gxTpr_Usuariocp = A62UsuarioCP;
            AV30SDTUsuario.gxTpr_Usuariozona = A63UsuarioZona;
            AV30SDTUsuario.gxTpr_Usuariocelular = A64UsuarioCelular;
            AV30SDTUsuario.gxTpr_Usuariotelefonosucursal = A65UsuarioTelefonoSucursal;
            AV30SDTUsuario.gxTpr_Paisid = A16PaisID;
            AV30SDTUsuario.gxTpr_Paisdescripcion = A17PaisDescripcion;
            AV30SDTUsuario.gxTpr_Estadoid = A1EstadoID;
            AV30SDTUsuario.gxTpr_Estadodescripcion = A2EstadoDescripcion;
            AV30SDTUsuario.gxTpr_Ciudadid = A4CiudadID;
            AV30SDTUsuario.gxTpr_Ciudaddescripcion = A5CiudadDescripcion;
            AV30SDTUsuario.gxTpr_Usuariosucursal = A66UsuarioSucursal;
            AV30SDTUsuario.gxTpr_Usuarioproducto = A67UsuarioProducto;
            AV28UsuarioJSON = AV30SDTUsuario.ToJSonString(false, true);
            AV29WebSession.Set(context.GetMessage( "Usuario", ""), AV28UsuarioJSON);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(6);
      }

      protected void S112( )
      {
         /* 'OBTIENEDATOSSESION' Routine */
         returnInSub = false;
         /* Using cursor H003T9 */
         pr_default.execute(7, new Object[] {AV12UsuarioID});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A29UsuarioID = H003T9_A29UsuarioID[0];
            A40UsuarioRol = H003T9_A40UsuarioRol[0];
            AV31UsuarioRol = A40UsuarioRol;
            AssignAttri("", false, "AV31UsuarioRol", AV31UsuarioRol);
            GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOROL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31UsuarioRol, "")), context));
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(7);
      }

      protected void nextLoad( )
      {
      }

      protected void E173T2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12UsuarioID = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV12UsuarioID", StringUtil.LTrimStr( (decimal)(AV12UsuarioID), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12UsuarioID), "ZZZZZZZZ9"), context));
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
         PA3T2( ) ;
         WS3T2( ) ;
         WE3T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20265111131947", true, true);
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
         context.AddJavascriptSource("wpactualizarinfousuario.js", "?20265111131947", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            AV5Usuario.gxTpr_Usuariogenero = cmbavUsuario_usuariogenero.getValidValue(AV5Usuario.gxTpr_Usuariogenero);
         }
         cmbavUsuario_usuariodirectoasociado.Name = "USUARIO_USUARIODIRECTOASOCIADO";
         cmbavUsuario_usuariodirectoasociado.WebTags = "";
         cmbavUsuario_usuariodirectoasociado.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbavUsuario_usuariodirectoasociado.addItem("Directo", context.GetMessage( "Directo", ""), 0);
         cmbavUsuario_usuariodirectoasociado.addItem("Asociado", context.GetMessage( "Asociado", ""), 0);
         if ( cmbavUsuario_usuariodirectoasociado.ItemCount > 0 )
         {
            AV5Usuario.gxTpr_Usuariodirectoasociado = cmbavUsuario_usuariodirectoasociado.getValidValue(AV5Usuario.gxTpr_Usuariodirectoasociado);
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
            AV5Usuario.gxTpr_Usuariozona = cmbavUsuario_usuariozona.getValidValue(AV5Usuario.gxTpr_Usuariozona);
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
            AV5Usuario.gxTpr_Usuarioproducto = cmbavUsuario_usuarioproducto.getValidValue(AV5Usuario.gxTpr_Usuarioproducto);
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
            AV5Usuario.gxTpr_Usuariorol = cmbavUsuario_usuariorol.getValidValue(AV5Usuario.gxTpr_Usuariorol);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavUsuario_usuarionombre_Internalname = "USUARIO_USUARIONOMBRE";
         edtavUsuario_usuarioapellido_Internalname = "USUARIO_USUARIOAPELLIDO";
         edtavUsuario_usuariocorreo_Internalname = "USUARIO_USUARIOCORREO";
         cmbavUsuario_usuariogenero_Internalname = "USUARIO_USUARIOGENERO";
         edtavUsuario_usuariofechanacimiento_Internalname = "USUARIO_USUARIOFECHANACIMIENTO";
         edtavUsuario_usuariocelular_Internalname = "USUARIO_USUARIOCELULAR";
         lblTextblockcombo_usuario_puestoid_Internalname = "TEXTBLOCKCOMBO_USUARIO_PUESTOID";
         Combo_usuario_puestoid_Internalname = "COMBO_USUARIO_PUESTOID";
         divTablesplittedusuario_puestoid_Internalname = "TABLESPLITTEDUSUARIO_PUESTOID";
         edtavPass_Internalname = "vPASS";
         edtavPass2_Internalname = "vPASS2";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         edtavUsuario_usuariorazonsocialasociado_Internalname = "USUARIO_USUARIORAZONSOCIALASOCIADO";
         edtavUsuario_usuarionombrecomercial_Internalname = "USUARIO_USUARIONOMBRECOMERCIAL";
         edtavUsuario_usuariosucursal_Internalname = "USUARIO_USUARIOSUCURSAL";
         cmbavUsuario_usuariodirectoasociado_Internalname = "USUARIO_USUARIODIRECTOASOCIADO";
         lblTextblockcombo_paisid_Internalname = "TEXTBLOCKCOMBO_PAISID";
         Combo_paisid_Internalname = "COMBO_PAISID";
         divTablesplittedpaisid_Internalname = "TABLESPLITTEDPAISID";
         lblTextblockcombo_estadoid_Internalname = "TEXTBLOCKCOMBO_ESTADOID";
         Combo_estadoid_Internalname = "COMBO_ESTADOID";
         divTablesplittedestadoid_Internalname = "TABLESPLITTEDESTADOID";
         lblTextblockcombo_usuario_ciudadid_Internalname = "TEXTBLOCKCOMBO_USUARIO_CIUDADID";
         Combo_usuario_ciudadid_Internalname = "COMBO_USUARIO_CIUDADID";
         divTablesplittedusuario_ciudadid_Internalname = "TABLESPLITTEDUSUARIO_CIUDADID";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         edtavUsuario_usuariocallenum_Internalname = "USUARIO_USUARIOCALLENUM";
         edtavUsuario_usuariocolonia_Internalname = "USUARIO_USUARIOCOLONIA";
         edtavUsuario_usuariodelegacion_Internalname = "USUARIO_USUARIODELEGACION";
         edtavUsuario_usuariocp_Internalname = "USUARIO_USUARIOCP";
         cmbavUsuario_usuariozona_Internalname = "USUARIO_USUARIOZONA";
         edtavUsuario_usuariotelefonosucursal_Internalname = "USUARIO_USUARIOTELEFONOSUCURSAL";
         cmbavUsuario_usuarioproducto_Internalname = "USUARIO_USUARIOPRODUCTO";
         edtavUsuario_usuarionocuentabroxel_Internalname = "USUARIO_USUARIONOCUENTABROXEL";
         edtavUsuario_usuarioreferenciabroxel_Internalname = "USUARIO_USUARIOREFERENCIABROXEL";
         lblTextblockcombo_distribuidorid_Internalname = "TEXTBLOCKCOMBO_DISTRIBUIDORID";
         Combo_distribuidorid_Internalname = "COMBO_DISTRIBUIDORID";
         divTablesplitteddistribuidorid_Internalname = "TABLESPLITTEDDISTRIBUIDORID";
         divCombo_distribuidorid_cell_Internalname = "COMBO_DISTRIBUIDORID_CELL";
         divTabledistribuidor_Internalname = "TABLEDISTRIBUIDOR";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divDatosdistribuidor_Internalname = "DATOSDISTRIBUIDOR";
         Dvpanel_datosdistribuidor_Internalname = "DVPANEL_DATOSDISTRIBUIDOR";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavPaisid_Internalname = "vPAISID";
         edtavEstadoid_Internalname = "vESTADOID";
         edtavDistribuidorid_Internalname = "vDISTRIBUIDORID";
         cmbavUsuario_usuariorol_Internalname = "USUARIO_USUARIOROL";
         edtavUsuario_usuarioid_Internalname = "USUARIO_USUARIOID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
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
         edtavUsuario_usuarioid_Jsonclick = "";
         edtavUsuario_usuarioid_Visible = 1;
         cmbavUsuario_usuariorol_Jsonclick = "";
         cmbavUsuario_usuariorol.Visible = 1;
         edtavDistribuidorid_Jsonclick = "";
         edtavDistribuidorid_Visible = 1;
         edtavEstadoid_Jsonclick = "";
         edtavEstadoid_Visible = 1;
         edtavPaisid_Jsonclick = "";
         edtavPaisid_Visible = 1;
         Combo_distribuidorid_Caption = "";
         divCombo_distribuidorid_cell_Class = "col-xs-12";
         divTabledistribuidor_Visible = 1;
         edtavUsuario_usuarioreferenciabroxel_Jsonclick = "";
         edtavUsuario_usuarioreferenciabroxel_Enabled = 1;
         edtavUsuario_usuarionocuentabroxel_Jsonclick = "";
         edtavUsuario_usuarionocuentabroxel_Enabled = 1;
         cmbavUsuario_usuarioproducto_Jsonclick = "";
         cmbavUsuario_usuarioproducto.Enabled = 1;
         edtavUsuario_usuariotelefonosucursal_Jsonclick = "";
         edtavUsuario_usuariotelefonosucursal_Enabled = 1;
         cmbavUsuario_usuariozona_Jsonclick = "";
         cmbavUsuario_usuariozona.Enabled = 1;
         edtavUsuario_usuariocp_Jsonclick = "";
         edtavUsuario_usuariocp_Enabled = 1;
         edtavUsuario_usuariodelegacion_Jsonclick = "";
         edtavUsuario_usuariodelegacion_Enabled = 1;
         edtavUsuario_usuariocolonia_Jsonclick = "";
         edtavUsuario_usuariocolonia_Enabled = 1;
         edtavUsuario_usuariocallenum_Jsonclick = "";
         edtavUsuario_usuariocallenum_Enabled = 1;
         Combo_usuario_ciudadid_Caption = "";
         Combo_estadoid_Caption = "";
         Combo_paisid_Caption = "";
         cmbavUsuario_usuariodirectoasociado_Jsonclick = "";
         cmbavUsuario_usuariodirectoasociado.Enabled = 1;
         edtavUsuario_usuariosucursal_Jsonclick = "";
         edtavUsuario_usuariosucursal_Enabled = 1;
         edtavUsuario_usuarionombrecomercial_Jsonclick = "";
         edtavUsuario_usuarionombrecomercial_Enabled = 1;
         edtavUsuario_usuariorazonsocialasociado_Jsonclick = "";
         edtavUsuario_usuariorazonsocialasociado_Enabled = 1;
         edtavPass2_Jsonclick = "";
         edtavPass2_Enabled = 1;
         edtavPass_Jsonclick = "";
         edtavPass_Enabled = 1;
         Combo_usuario_puestoid_Caption = "";
         edtavUsuario_usuariocelular_Jsonclick = "";
         edtavUsuario_usuariocelular_Enabled = 1;
         edtavUsuario_usuariofechanacimiento_Jsonclick = "";
         edtavUsuario_usuariofechanacimiento_Enabled = 1;
         cmbavUsuario_usuariogenero_Jsonclick = "";
         cmbavUsuario_usuariogenero.Enabled = 1;
         edtavUsuario_usuariocorreo_Jsonclick = "";
         edtavUsuario_usuariocorreo_Enabled = 1;
         edtavUsuario_usuarioapellido_Jsonclick = "";
         edtavUsuario_usuarioapellido_Enabled = 1;
         edtavUsuario_usuarionombre_Jsonclick = "";
         edtavUsuario_usuarionombre_Enabled = 1;
         Dvpanel_datosdistribuidor_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_datosdistribuidor_Iconposition = "Right";
         Dvpanel_datosdistribuidor_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_datosdistribuidor_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_datosdistribuidor_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_datosdistribuidor_Title = context.GetMessage( "Datos Distribuidor", "");
         Dvpanel_datosdistribuidor_Cls = "PanelCard_GrayTitle";
         Dvpanel_datosdistribuidor_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_datosdistribuidor_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_datosdistribuidor_Width = "100%";
         Combo_distribuidorid_Cls = "ExtendedCombo AttributeFL";
         Combo_usuario_ciudadid_Datalistprocparametersprefix = "";
         Combo_usuario_ciudadid_Datalistproc = "WPActualizarInfoUsuarioLoadDVCombo";
         Combo_usuario_ciudadid_Cls = "ExtendedCombo AttributeFL";
         Combo_estadoid_Datalistprocparametersprefix = "";
         Combo_estadoid_Datalistproc = "WPActualizarInfoUsuarioLoadDVCombo";
         Combo_estadoid_Cls = "ExtendedCombo AttributeFL";
         Combo_paisid_Cls = "ExtendedCombo AttributeFL";
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = context.GetMessage( "Datos personales", "");
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         Combo_usuario_puestoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_usuario_puestoid_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "WPActualizar Info Usuario", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV31UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"AV12UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("COMBO_USUARIO_CIUDADID.ONOPTIONCLICKED","""{"handler":"E143T2","iparms":[{"av":"Combo_usuario_ciudadid_Selectedvalue_get","ctrl":"COMBO_USUARIO_CIUDADID","prop":"SelectedValue_get"},{"av":"AV5Usuario","fld":"vUSUARIO"}]""");
         setEventMetadata("COMBO_USUARIO_CIUDADID.ONOPTIONCLICKED",""","oparms":[{"av":"AV5Usuario","fld":"vUSUARIO"}]}""");
         setEventMetadata("COMBO_ESTADOID.ONOPTIONCLICKED","""{"handler":"E133T2","iparms":[{"av":"AV16EstadoID","fld":"vESTADOID","pic":"ZZZZZZZZ9"},{"av":"Combo_estadoid_Selectedvalue_get","ctrl":"COMBO_ESTADOID","prop":"SelectedValue_get"},{"av":"AV5Usuario","fld":"vUSUARIO"}]""");
         setEventMetadata("COMBO_ESTADOID.ONOPTIONCLICKED",""","oparms":[{"av":"AV24Cond_EstadoID","fld":"vCOND_ESTADOID","pic":"ZZZZZZZZ9"},{"av":"AV16EstadoID","fld":"vESTADOID","pic":"ZZZZZZZZ9"},{"av":"AV5Usuario","fld":"vUSUARIO"},{"av":"Combo_usuario_ciudadid_Selectedvalue_set","ctrl":"COMBO_USUARIO_CIUDADID","prop":"SelectedValue_set"},{"av":"Combo_usuario_ciudadid_Selectedtext_set","ctrl":"COMBO_USUARIO_CIUDADID","prop":"SelectedText_set"}]}""");
         setEventMetadata("COMBO_PAISID.ONOPTIONCLICKED","""{"handler":"E123T2","iparms":[{"av":"AV15PaisID","fld":"vPAISID","pic":"ZZZZZZZZ9"},{"av":"Combo_paisid_Selectedvalue_get","ctrl":"COMBO_PAISID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_PAISID.ONOPTIONCLICKED",""","oparms":[{"av":"AV22Cond_PaisID","fld":"vCOND_PAISID","pic":"ZZZZZZZZ9"},{"av":"AV15PaisID","fld":"vPAISID","pic":"ZZZZZZZZ9"},{"av":"AV16EstadoID","fld":"vESTADOID","pic":"ZZZZZZZZ9"},{"av":"Combo_estadoid_Selectedvalue_set","ctrl":"COMBO_ESTADOID","prop":"SelectedValue_set"},{"av":"Combo_estadoid_Selectedtext_set","ctrl":"COMBO_ESTADOID","prop":"SelectedText_set"}]}""");
         setEventMetadata("COMBO_USUARIO_PUESTOID.ONOPTIONCLICKED","""{"handler":"E113T2","iparms":[{"av":"Combo_usuario_puestoid_Selectedvalue_get","ctrl":"COMBO_USUARIO_PUESTOID","prop":"SelectedValue_get"},{"av":"AV5Usuario","fld":"vUSUARIO"}]""");
         setEventMetadata("COMBO_USUARIO_PUESTOID.ONOPTIONCLICKED",""","oparms":[{"av":"AV5Usuario","fld":"vUSUARIO"}]}""");
         setEventMetadata("ENTER","""{"handler":"E163T2","iparms":[{"av":"AV13Pass","fld":"vPASS"},{"av":"AV14Pass2","fld":"vPASS2"},{"av":"AV5Usuario","fld":"vUSUARIO"},{"av":"AV10CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV31UsuarioRol","fld":"vUSUARIOROL","hsh":true},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV12UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV26DistribuidorID","fld":"vDISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"Combo_usuario_puestoid_Ddointernalname","ctrl":"COMBO_USUARIO_PUESTOID","prop":"DDOInternalName"},{"av":"AV15PaisID","fld":"vPAISID","pic":"ZZZZZZZZ9"},{"av":"Combo_paisid_Ddointernalname","ctrl":"COMBO_PAISID","prop":"DDOInternalName"},{"av":"AV16EstadoID","fld":"vESTADOID","pic":"ZZZZZZZZ9"},{"av":"Combo_estadoid_Ddointernalname","ctrl":"COMBO_ESTADOID","prop":"DDOInternalName"},{"av":"Combo_usuario_ciudadid_Ddointernalname","ctrl":"COMBO_USUARIO_CIUDADID","prop":"DDOInternalName"},{"av":"Combo_distribuidorid_Ddointernalname","ctrl":"COMBO_DISTRIBUIDORID","prop":"DDOInternalName"},{"av":"A30UsuarioNombre","fld":"USUARIONOMBRE"},{"av":"A31UsuarioCorreo","fld":"USUARIOCORREO"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A51UsuarioApellido","fld":"USUARIOAPELLIDO"},{"av":"A52UsuarioNombreCompleto","fld":"USUARIONOMBRECOMPLETO"},{"av":"A13PuestoID","fld":"PUESTOID","pic":"ZZZZZZZZ9"},{"av":"A14PuestoDescripcion","fld":"PUESTODESCRIPCION"},{"av":"A53UsuarioGenero","fld":"USUARIOGENERO"},{"av":"A54UsuarioDirectoAsociado","fld":"USUARIODIRECTOASOCIADO"},{"av":"A55UsuarioRazonSocialAsociado","fld":"USUARIORAZONSOCIALASOCIADO"},{"av":"A56UsuarioNombreComercial","fld":"USUARIONOMBRECOMERCIAL"},{"av":"A57UsuarioFechaNacimiento","fld":"USUARIOFECHANACIMIENTO"},{"av":"A59UsuarioCalleNum","fld":"USUARIOCALLENUM"},{"av":"A60UsuarioColonia","fld":"USUARIOCOLONIA"},{"av":"A61UsuarioDelegacion","fld":"USUARIODELEGACION"},{"av":"A62UsuarioCP","fld":"USUARIOCP","pic":"ZZZZ9"},{"av":"A63UsuarioZona","fld":"USUARIOZONA"},{"av":"A64UsuarioCelular","fld":"USUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"A65UsuarioTelefonoSucursal","fld":"USUARIOTELEFONOSUCURSAL","pic":"ZZZZZZZZZ9"},{"av":"A16PaisID","fld":"PAISID","pic":"ZZZZZZZZ9"},{"av":"A17PaisDescripcion","fld":"PAISDESCRIPCION"},{"av":"A1EstadoID","fld":"ESTADOID","pic":"ZZZZZZZZ9"},{"av":"A2EstadoDescripcion","fld":"ESTADODESCRIPCION"},{"av":"A4CiudadID","fld":"CIUDADID","pic":"ZZZZZZZZ9"},{"av":"A5CiudadDescripcion","fld":"CIUDADDESCRIPCION"},{"av":"A66UsuarioSucursal","fld":"USUARIOSUCURSAL"},{"av":"A67UsuarioProducto","fld":"USUARIOPRODUCTO"},{"av":"AV7Messages","fld":"vMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5Usuario","fld":"vUSUARIO"},{"av":"AV7Messages","fld":"vMESSAGES"},{"av":"AV13Pass","fld":"vPASS"},{"av":"AV14Pass2","fld":"vPASS2"},{"av":"AV10CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV10","""{"handler":"Validv_Gxv10","iparms":[]}""");
         setEventMetadata("VALIDV_GXV15","""{"handler":"Validv_Gxv15","iparms":[]}""");
         setEventMetadata("VALIDV_GXV17","""{"handler":"Validv_Gxv17","iparms":[]}""");
         setEventMetadata("VALIDV_ESTADOID","""{"handler":"Validv_Estadoid","iparms":[]}""");
         setEventMetadata("VALIDV_GXV20","""{"handler":"Validv_Gxv20","iparms":[]}""");
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
         Combo_distribuidorid_Selectedvalue_get = "";
         Combo_usuario_ciudadid_Selectedvalue_get = "";
         Combo_estadoid_Selectedvalue_get = "";
         Combo_paisid_Selectedvalue_get = "";
         Combo_usuario_puestoid_Selectedvalue_get = "";
         Combo_usuario_puestoid_Ddointernalname = "";
         Combo_paisid_Ddointernalname = "";
         Combo_estadoid_Ddointernalname = "";
         Combo_usuario_ciudadid_Ddointernalname = "";
         Combo_distribuidorid_Ddointernalname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV31UsuarioRol = "";
         AV5Usuario = new SdtUsuario(context);
         AV18DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV17Usuario_PuestoID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV20PaisID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV21EstadoID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV23Usuario_CiudadID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV27DistribuidorID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A30UsuarioNombre = "";
         A31UsuarioCorreo = "";
         A40UsuarioRol = "";
         A51UsuarioApellido = "";
         A52UsuarioNombreCompleto = "";
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
         AV7Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         Combo_usuario_puestoid_Selectedvalue_set = "";
         Combo_paisid_Selectedvalue_set = "";
         Combo_estadoid_Selectedvalue_set = "";
         Combo_estadoid_Selectedtext_set = "";
         Combo_usuario_ciudadid_Selectedvalue_set = "";
         Combo_usuario_ciudadid_Selectedtext_set = "";
         Combo_distribuidorid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         lblTextblockcombo_usuario_puestoid_Jsonclick = "";
         ucCombo_usuario_puestoid = new GXUserControl();
         AV13Pass = "";
         AV14Pass2 = "";
         lblTextblock1_Jsonclick = "";
         ucDvpanel_datosdistribuidor = new GXUserControl();
         lblTextblockcombo_paisid_Jsonclick = "";
         ucCombo_paisid = new GXUserControl();
         lblTextblockcombo_estadoid_Jsonclick = "";
         ucCombo_estadoid = new GXUserControl();
         lblTextblockcombo_usuario_ciudadid_Jsonclick = "";
         ucCombo_usuario_ciudadid = new GXUserControl();
         lblTextblockcombo_distribuidorid_Jsonclick = "";
         ucCombo_distribuidorid = new GXUserControl();
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV8TrnMode = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         H003T2_A11DistribuidorDescripcion = new string[] {""} ;
         H003T2_A10DistribuidorID = new int[1] ;
         A11DistribuidorDescripcion = "";
         AV19Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         H003T3_A1EstadoID = new int[1] ;
         H003T3_A4CiudadID = new int[1] ;
         H003T3_n4CiudadID = new bool[] {false} ;
         H003T3_A5CiudadDescripcion = new string[] {""} ;
         H003T4_A16PaisID = new int[1] ;
         H003T4_A1EstadoID = new int[1] ;
         H003T4_A2EstadoDescripcion = new string[] {""} ;
         H003T5_A16PaisID = new int[1] ;
         H003T5_A17PaisDescripcion = new string[] {""} ;
         H003T6_A15PuestoActivo = new bool[] {false} ;
         H003T6_A13PuestoID = new int[1] ;
         H003T6_n13PuestoID = new bool[] {false} ;
         H003T6_A14PuestoDescripcion = new string[] {""} ;
         AV25UsuarioKey = "";
         H003T7_A29UsuarioID = new int[1] ;
         H003T7_A81DistribuidoresUsuarioID = new int[1] ;
         AV34DistribuidoresUsuario = new SdtDistribuidoresUsuario(context);
         AV35DistribuidoresUsuario2 = new SdtDistribuidoresUsuario(context);
         AV36VALIDAMOSTRARVIDEO = "";
         AV6Message = new GeneXus.Utils.SdtMessages_Message(context);
         H003T8_A29UsuarioID = new int[1] ;
         H003T8_A31UsuarioCorreo = new string[] {""} ;
         H003T8_A40UsuarioRol = new string[] {""} ;
         H003T8_A13PuestoID = new int[1] ;
         H003T8_n13PuestoID = new bool[] {false} ;
         H003T8_A14PuestoDescripcion = new string[] {""} ;
         H003T8_A53UsuarioGenero = new string[] {""} ;
         H003T8_A54UsuarioDirectoAsociado = new string[] {""} ;
         H003T8_n54UsuarioDirectoAsociado = new bool[] {false} ;
         H003T8_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         H003T8_A56UsuarioNombreComercial = new string[] {""} ;
         H003T8_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         H003T8_n57UsuarioFechaNacimiento = new bool[] {false} ;
         H003T8_A59UsuarioCalleNum = new string[] {""} ;
         H003T8_A60UsuarioColonia = new string[] {""} ;
         H003T8_A61UsuarioDelegacion = new string[] {""} ;
         H003T8_A62UsuarioCP = new int[1] ;
         H003T8_A63UsuarioZona = new string[] {""} ;
         H003T8_A64UsuarioCelular = new long[1] ;
         H003T8_A65UsuarioTelefonoSucursal = new long[1] ;
         H003T8_A16PaisID = new int[1] ;
         H003T8_A17PaisDescripcion = new string[] {""} ;
         H003T8_A1EstadoID = new int[1] ;
         H003T8_A2EstadoDescripcion = new string[] {""} ;
         H003T8_A4CiudadID = new int[1] ;
         H003T8_n4CiudadID = new bool[] {false} ;
         H003T8_A5CiudadDescripcion = new string[] {""} ;
         H003T8_A66UsuarioSucursal = new string[] {""} ;
         H003T8_A67UsuarioProducto = new string[] {""} ;
         H003T8_n67UsuarioProducto = new bool[] {false} ;
         H003T8_A51UsuarioApellido = new string[] {""} ;
         H003T8_A30UsuarioNombre = new string[] {""} ;
         AV30SDTUsuario = new SdtSDTUsuario(context);
         AV28UsuarioJSON = "";
         AV29WebSession = context.GetSession();
         H003T9_A29UsuarioID = new int[1] ;
         H003T9_A40UsuarioRol = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpactualizarinfousuario__default(),
            new Object[][] {
                new Object[] {
               H003T2_A11DistribuidorDescripcion, H003T2_A10DistribuidorID
               }
               , new Object[] {
               H003T3_A1EstadoID, H003T3_A4CiudadID, H003T3_A5CiudadDescripcion
               }
               , new Object[] {
               H003T4_A16PaisID, H003T4_A1EstadoID, H003T4_A2EstadoDescripcion
               }
               , new Object[] {
               H003T5_A16PaisID, H003T5_A17PaisDescripcion
               }
               , new Object[] {
               H003T6_A15PuestoActivo, H003T6_A13PuestoID, H003T6_A14PuestoDescripcion
               }
               , new Object[] {
               H003T7_A29UsuarioID, H003T7_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               H003T8_A29UsuarioID, H003T8_A31UsuarioCorreo, H003T8_A40UsuarioRol, H003T8_A13PuestoID, H003T8_n13PuestoID, H003T8_A14PuestoDescripcion, H003T8_A53UsuarioGenero, H003T8_A54UsuarioDirectoAsociado, H003T8_n54UsuarioDirectoAsociado, H003T8_A55UsuarioRazonSocialAsociado,
               H003T8_A56UsuarioNombreComercial, H003T8_A57UsuarioFechaNacimiento, H003T8_n57UsuarioFechaNacimiento, H003T8_A59UsuarioCalleNum, H003T8_A60UsuarioColonia, H003T8_A61UsuarioDelegacion, H003T8_A62UsuarioCP, H003T8_A63UsuarioZona, H003T8_A64UsuarioCelular, H003T8_A65UsuarioTelefonoSucursal,
               H003T8_A16PaisID, H003T8_A17PaisDescripcion, H003T8_A1EstadoID, H003T8_A2EstadoDescripcion, H003T8_A4CiudadID, H003T8_n4CiudadID, H003T8_A5CiudadDescripcion, H003T8_A66UsuarioSucursal, H003T8_A67UsuarioProducto, H003T8_n67UsuarioProducto,
               H003T8_A51UsuarioApellido, H003T8_A30UsuarioNombre
               }
               , new Object[] {
               H003T9_A29UsuarioID, H003T9_A40UsuarioRol
               }
            }
         );
         /* GeneXus formulas. */
      }

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
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short AV59GXLvl250 ;
      private short AV60GXLvl271 ;
      private short nGXWrapped ;
      private int AV12UsuarioID ;
      private int wcpOAV12UsuarioID ;
      private int A29UsuarioID ;
      private int A81DistribuidoresUsuarioID ;
      private int A13PuestoID ;
      private int A62UsuarioCP ;
      private int A16PaisID ;
      private int A1EstadoID ;
      private int A4CiudadID ;
      private int edtavUsuario_usuarionombre_Enabled ;
      private int edtavUsuario_usuarioapellido_Enabled ;
      private int edtavUsuario_usuariocorreo_Enabled ;
      private int edtavUsuario_usuariofechanacimiento_Enabled ;
      private int edtavUsuario_usuariocelular_Enabled ;
      private int edtavPass_Enabled ;
      private int edtavPass2_Enabled ;
      private int edtavUsuario_usuariorazonsocialasociado_Enabled ;
      private int edtavUsuario_usuarionombrecomercial_Enabled ;
      private int edtavUsuario_usuariosucursal_Enabled ;
      private int edtavUsuario_usuariocallenum_Enabled ;
      private int edtavUsuario_usuariocolonia_Enabled ;
      private int edtavUsuario_usuariodelegacion_Enabled ;
      private int edtavUsuario_usuariocp_Enabled ;
      private int edtavUsuario_usuariotelefonosucursal_Enabled ;
      private int edtavUsuario_usuarionocuentabroxel_Enabled ;
      private int edtavUsuario_usuarioreferenciabroxel_Enabled ;
      private int divTabledistribuidor_Visible ;
      private int AV15PaisID ;
      private int edtavPaisid_Visible ;
      private int AV16EstadoID ;
      private int edtavEstadoid_Visible ;
      private int AV26DistribuidorID ;
      private int edtavDistribuidorid_Visible ;
      private int edtavUsuario_usuarioid_Visible ;
      private int AV24Cond_EstadoID ;
      private int AV22Cond_PaisID ;
      private int A10DistribuidorID ;
      private int AV64GXV22 ;
      private int idxLst ;
      private long A64UsuarioCelular ;
      private long A65UsuarioTelefonoSucursal ;
      private string Combo_distribuidorid_Selectedvalue_get ;
      private string Combo_usuario_ciudadid_Selectedvalue_get ;
      private string Combo_estadoid_Selectedvalue_get ;
      private string Combo_paisid_Selectedvalue_get ;
      private string Combo_usuario_puestoid_Selectedvalue_get ;
      private string Combo_usuario_puestoid_Ddointernalname ;
      private string Combo_paisid_Ddointernalname ;
      private string Combo_estadoid_Ddointernalname ;
      private string Combo_usuario_ciudadid_Ddointernalname ;
      private string Combo_distribuidorid_Ddointernalname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV31UsuarioRol ;
      private string A30UsuarioNombre ;
      private string A40UsuarioRol ;
      private string A51UsuarioApellido ;
      private string A53UsuarioGenero ;
      private string A54UsuarioDirectoAsociado ;
      private string A59UsuarioCalleNum ;
      private string A60UsuarioColonia ;
      private string A61UsuarioDelegacion ;
      private string A63UsuarioZona ;
      private string A66UsuarioSucursal ;
      private string Combo_usuario_puestoid_Cls ;
      private string Combo_usuario_puestoid_Selectedvalue_set ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Combo_paisid_Cls ;
      private string Combo_paisid_Selectedvalue_set ;
      private string Combo_estadoid_Cls ;
      private string Combo_estadoid_Selectedvalue_set ;
      private string Combo_estadoid_Selectedtext_set ;
      private string Combo_estadoid_Datalistproc ;
      private string Combo_estadoid_Datalistprocparametersprefix ;
      private string Combo_usuario_ciudadid_Cls ;
      private string Combo_usuario_ciudadid_Selectedvalue_set ;
      private string Combo_usuario_ciudadid_Selectedtext_set ;
      private string Combo_usuario_ciudadid_Datalistproc ;
      private string Combo_usuario_ciudadid_Datalistprocparametersprefix ;
      private string Combo_distribuidorid_Cls ;
      private string Combo_distribuidorid_Selectedvalue_set ;
      private string Dvpanel_datosdistribuidor_Width ;
      private string Dvpanel_datosdistribuidor_Cls ;
      private string Dvpanel_datosdistribuidor_Title ;
      private string Dvpanel_datosdistribuidor_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavUsuario_usuarionombre_Internalname ;
      private string TempTags ;
      private string edtavUsuario_usuarionombre_Jsonclick ;
      private string edtavUsuario_usuarioapellido_Internalname ;
      private string edtavUsuario_usuarioapellido_Jsonclick ;
      private string edtavUsuario_usuariocorreo_Internalname ;
      private string edtavUsuario_usuariocorreo_Jsonclick ;
      private string cmbavUsuario_usuariogenero_Internalname ;
      private string cmbavUsuario_usuariogenero_Jsonclick ;
      private string edtavUsuario_usuariofechanacimiento_Internalname ;
      private string edtavUsuario_usuariofechanacimiento_Jsonclick ;
      private string edtavUsuario_usuariocelular_Internalname ;
      private string edtavUsuario_usuariocelular_Jsonclick ;
      private string divTablesplittedusuario_puestoid_Internalname ;
      private string lblTextblockcombo_usuario_puestoid_Internalname ;
      private string lblTextblockcombo_usuario_puestoid_Jsonclick ;
      private string Combo_usuario_puestoid_Caption ;
      private string Combo_usuario_puestoid_Internalname ;
      private string edtavPass_Internalname ;
      private string AV13Pass ;
      private string edtavPass_Jsonclick ;
      private string edtavPass2_Internalname ;
      private string AV14Pass2 ;
      private string edtavPass2_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string Dvpanel_datosdistribuidor_Internalname ;
      private string divDatosdistribuidor_Internalname ;
      private string edtavUsuario_usuariorazonsocialasociado_Internalname ;
      private string edtavUsuario_usuariorazonsocialasociado_Jsonclick ;
      private string edtavUsuario_usuarionombrecomercial_Internalname ;
      private string edtavUsuario_usuarionombrecomercial_Jsonclick ;
      private string edtavUsuario_usuariosucursal_Internalname ;
      private string edtavUsuario_usuariosucursal_Jsonclick ;
      private string cmbavUsuario_usuariodirectoasociado_Internalname ;
      private string cmbavUsuario_usuariodirectoasociado_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string divTablesplittedpaisid_Internalname ;
      private string lblTextblockcombo_paisid_Internalname ;
      private string lblTextblockcombo_paisid_Jsonclick ;
      private string Combo_paisid_Caption ;
      private string Combo_paisid_Internalname ;
      private string divTablesplittedestadoid_Internalname ;
      private string lblTextblockcombo_estadoid_Internalname ;
      private string lblTextblockcombo_estadoid_Jsonclick ;
      private string Combo_estadoid_Caption ;
      private string Combo_estadoid_Internalname ;
      private string divTablesplittedusuario_ciudadid_Internalname ;
      private string lblTextblockcombo_usuario_ciudadid_Internalname ;
      private string lblTextblockcombo_usuario_ciudadid_Jsonclick ;
      private string Combo_usuario_ciudadid_Caption ;
      private string Combo_usuario_ciudadid_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtavUsuario_usuariocallenum_Internalname ;
      private string edtavUsuario_usuariocallenum_Jsonclick ;
      private string edtavUsuario_usuariocolonia_Internalname ;
      private string edtavUsuario_usuariocolonia_Jsonclick ;
      private string edtavUsuario_usuariodelegacion_Internalname ;
      private string edtavUsuario_usuariodelegacion_Jsonclick ;
      private string edtavUsuario_usuariocp_Internalname ;
      private string edtavUsuario_usuariocp_Jsonclick ;
      private string cmbavUsuario_usuariozona_Internalname ;
      private string cmbavUsuario_usuariozona_Jsonclick ;
      private string edtavUsuario_usuariotelefonosucursal_Internalname ;
      private string edtavUsuario_usuariotelefonosucursal_Jsonclick ;
      private string cmbavUsuario_usuarioproducto_Internalname ;
      private string cmbavUsuario_usuarioproducto_Jsonclick ;
      private string edtavUsuario_usuarionocuentabroxel_Internalname ;
      private string edtavUsuario_usuarionocuentabroxel_Jsonclick ;
      private string edtavUsuario_usuarioreferenciabroxel_Internalname ;
      private string edtavUsuario_usuarioreferenciabroxel_Jsonclick ;
      private string divTabledistribuidor_Internalname ;
      private string divCombo_distribuidorid_cell_Internalname ;
      private string divCombo_distribuidorid_cell_Class ;
      private string divTablesplitteddistribuidorid_Internalname ;
      private string lblTextblockcombo_distribuidorid_Internalname ;
      private string lblTextblockcombo_distribuidorid_Jsonclick ;
      private string Combo_distribuidorid_Caption ;
      private string Combo_distribuidorid_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavPaisid_Internalname ;
      private string edtavPaisid_Jsonclick ;
      private string edtavEstadoid_Internalname ;
      private string edtavEstadoid_Jsonclick ;
      private string edtavDistribuidorid_Internalname ;
      private string edtavDistribuidorid_Jsonclick ;
      private string cmbavUsuario_usuariorol_Internalname ;
      private string cmbavUsuario_usuariorol_Jsonclick ;
      private string edtavUsuario_usuarioid_Internalname ;
      private string edtavUsuario_usuarioid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string AV8TrnMode ;
      private DateTime A57UsuarioFechaNacimiento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10CheckRequiredFieldsResult ;
      private bool Combo_usuario_puestoid_Emptyitem ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_datosdistribuidor_Autowidth ;
      private bool Dvpanel_datosdistribuidor_Autoheight ;
      private bool Dvpanel_datosdistribuidor_Collapsible ;
      private bool Dvpanel_datosdistribuidor_Collapsed ;
      private bool Dvpanel_datosdistribuidor_Showcollapseicon ;
      private bool Dvpanel_datosdistribuidor_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9LoadSuccess ;
      private bool n4CiudadID ;
      private bool A15PuestoActivo ;
      private bool n13PuestoID ;
      private bool n54UsuarioDirectoAsociado ;
      private bool n57UsuarioFechaNacimiento ;
      private bool n67UsuarioProducto ;
      private string AV28UsuarioJSON ;
      private string A31UsuarioCorreo ;
      private string A52UsuarioNombreCompleto ;
      private string A14PuestoDescripcion ;
      private string A55UsuarioRazonSocialAsociado ;
      private string A56UsuarioNombreComercial ;
      private string A17PaisDescripcion ;
      private string A2EstadoDescripcion ;
      private string A5CiudadDescripcion ;
      private string A67UsuarioProducto ;
      private string A11DistribuidorDescripcion ;
      private string AV25UsuarioKey ;
      private string AV36VALIDAMOSTRARVIDEO ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_usuario_puestoid ;
      private GXUserControl ucDvpanel_datosdistribuidor ;
      private GXUserControl ucCombo_paisid ;
      private GXUserControl ucCombo_estadoid ;
      private GXUserControl ucCombo_usuario_ciudadid ;
      private GXUserControl ucCombo_distribuidorid ;
      private IGxSession AV29WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavUsuario_usuariogenero ;
      private GXCombobox cmbavUsuario_usuariodirectoasociado ;
      private GXCombobox cmbavUsuario_usuariozona ;
      private GXCombobox cmbavUsuario_usuarioproducto ;
      private GXCombobox cmbavUsuario_usuariorol ;
      private SdtUsuario AV5Usuario ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV18DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV17Usuario_PuestoID_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV20PaisID_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV21EstadoID_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV23Usuario_CiudadID_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV27DistribuidorID_Data ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV7Messages ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private IDataStoreProvider pr_default ;
      private string[] H003T2_A11DistribuidorDescripcion ;
      private int[] H003T2_A10DistribuidorID ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV19Combo_DataItem ;
      private int[] H003T3_A1EstadoID ;
      private int[] H003T3_A4CiudadID ;
      private bool[] H003T3_n4CiudadID ;
      private string[] H003T3_A5CiudadDescripcion ;
      private int[] H003T4_A16PaisID ;
      private int[] H003T4_A1EstadoID ;
      private string[] H003T4_A2EstadoDescripcion ;
      private int[] H003T5_A16PaisID ;
      private string[] H003T5_A17PaisDescripcion ;
      private bool[] H003T6_A15PuestoActivo ;
      private int[] H003T6_A13PuestoID ;
      private bool[] H003T6_n13PuestoID ;
      private string[] H003T6_A14PuestoDescripcion ;
      private int[] H003T7_A29UsuarioID ;
      private int[] H003T7_A81DistribuidoresUsuarioID ;
      private SdtDistribuidoresUsuario AV34DistribuidoresUsuario ;
      private SdtDistribuidoresUsuario AV35DistribuidoresUsuario2 ;
      private GeneXus.Utils.SdtMessages_Message AV6Message ;
      private int[] H003T8_A29UsuarioID ;
      private string[] H003T8_A31UsuarioCorreo ;
      private string[] H003T8_A40UsuarioRol ;
      private int[] H003T8_A13PuestoID ;
      private bool[] H003T8_n13PuestoID ;
      private string[] H003T8_A14PuestoDescripcion ;
      private string[] H003T8_A53UsuarioGenero ;
      private string[] H003T8_A54UsuarioDirectoAsociado ;
      private bool[] H003T8_n54UsuarioDirectoAsociado ;
      private string[] H003T8_A55UsuarioRazonSocialAsociado ;
      private string[] H003T8_A56UsuarioNombreComercial ;
      private DateTime[] H003T8_A57UsuarioFechaNacimiento ;
      private bool[] H003T8_n57UsuarioFechaNacimiento ;
      private string[] H003T8_A59UsuarioCalleNum ;
      private string[] H003T8_A60UsuarioColonia ;
      private string[] H003T8_A61UsuarioDelegacion ;
      private int[] H003T8_A62UsuarioCP ;
      private string[] H003T8_A63UsuarioZona ;
      private long[] H003T8_A64UsuarioCelular ;
      private long[] H003T8_A65UsuarioTelefonoSucursal ;
      private int[] H003T8_A16PaisID ;
      private string[] H003T8_A17PaisDescripcion ;
      private int[] H003T8_A1EstadoID ;
      private string[] H003T8_A2EstadoDescripcion ;
      private int[] H003T8_A4CiudadID ;
      private bool[] H003T8_n4CiudadID ;
      private string[] H003T8_A5CiudadDescripcion ;
      private string[] H003T8_A66UsuarioSucursal ;
      private string[] H003T8_A67UsuarioProducto ;
      private bool[] H003T8_n67UsuarioProducto ;
      private string[] H003T8_A51UsuarioApellido ;
      private string[] H003T8_A30UsuarioNombre ;
      private SdtSDTUsuario AV30SDTUsuario ;
      private int[] H003T9_A29UsuarioID ;
      private string[] H003T9_A40UsuarioRol ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpactualizarinfousuario__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH003T2;
          prmH003T2 = new Object[] {
          };
          Object[] prmH003T3;
          prmH003T3 = new Object[] {
          new ParDef("@AV5Usuario__Ciudadid",GXType.Int32,9,0) ,
          new ParDef("@AV24Cond_EstadoID",GXType.Int32,9,0)
          };
          Object[] prmH003T4;
          prmH003T4 = new Object[] {
          new ParDef("@AV16EstadoID",GXType.Int32,9,0) ,
          new ParDef("@AV22Cond_PaisID",GXType.Int32,9,0)
          };
          Object[] prmH003T5;
          prmH003T5 = new Object[] {
          };
          Object[] prmH003T6;
          prmH003T6 = new Object[] {
          };
          Object[] prmH003T7;
          prmH003T7 = new Object[] {
          new ParDef("@AV12UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH003T8;
          prmH003T8 = new Object[] {
          new ParDef("@AV12UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmH003T9;
          prmH003T9 = new Object[] {
          new ParDef("@AV12UsuarioID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003T2", "SELECT `DistribuidorDescripcion`, `DistribuidorID` FROM `Distribuidor` ORDER BY `DistribuidorDescripcion` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003T2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H003T3", "SELECT `EstadoID`, `CiudadID`, `CiudadDescripcion` FROM `Ciudad` WHERE (`CiudadID` = @AV5Usuario__Ciudadid) AND (`EstadoID` = @AV24Cond_EstadoID) ORDER BY `CiudadID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003T3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H003T4", "SELECT `PaisID`, `EstadoID`, `EstadoDescripcion` FROM `Estado` WHERE (`EstadoID` = @AV16EstadoID) AND (`PaisID` = @AV22Cond_PaisID) ORDER BY `EstadoID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003T4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H003T5", "SELECT `PaisID`, `PaisDescripcion` FROM `Pais` ORDER BY `PaisDescripcion` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003T5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H003T6", "SELECT `PuestoActivo`, `PuestoID`, `PuestoDescripcion` FROM `Puesto` WHERE `PuestoActivo` = 1 ORDER BY `PuestoDescripcion` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003T6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H003T7", "SELECT `UsuarioID`, `DistribuidoresUsuarioID` FROM `DistribuidoresUsuario` WHERE `UsuarioID` = @AV12UsuarioID ORDER BY `UsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003T7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003T8", "SELECT T1.`UsuarioID`, T1.`UsuarioCorreo`, T1.`UsuarioRol`, T1.`PuestoID`, T2.`PuestoDescripcion`, T1.`UsuarioGenero`, T1.`UsuarioDirectoAsociado`, T1.`UsuarioRazonSocialAsociado`, T1.`UsuarioNombreComercial`, T1.`UsuarioFechaNacimiento`, T1.`UsuarioCalleNum`, T1.`UsuarioColonia`, T1.`UsuarioDelegacion`, T1.`UsuarioCP`, T1.`UsuarioZona`, T1.`UsuarioCelular`, T1.`UsuarioTelefonoSucursal`, T4.`PaisID`, T5.`PaisDescripcion`, T3.`EstadoID`, T4.`EstadoDescripcion`, T1.`CiudadID`, T3.`CiudadDescripcion`, T1.`UsuarioSucursal`, T1.`UsuarioProducto`, T1.`UsuarioApellido`, T1.`UsuarioNombre` FROM ((((`Usuario` T1 LEFT JOIN `Puesto` T2 ON T2.`PuestoID` = T1.`PuestoID`) LEFT JOIN `Ciudad` T3 ON T3.`CiudadID` = T1.`CiudadID`) LEFT JOIN `Estado` T4 ON T4.`EstadoID` = T3.`EstadoID`) LEFT JOIN `Pais` T5 ON T5.`PaisID` = T4.`PaisID`) WHERE T1.`UsuarioID` = @AV12UsuarioID ORDER BY T1.`UsuarioID` ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003T8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H003T9", "SELECT `UsuarioID`, `UsuarioRol` FROM `Usuario` WHERE `UsuarioID` = @AV12UsuarioID ORDER BY `UsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003T9,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 40);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((string[]) buf[13])[0] = rslt.getString(11, 40);
                ((string[]) buf[14])[0] = rslt.getString(12, 20);
                ((string[]) buf[15])[0] = rslt.getString(13, 20);
                ((int[]) buf[16])[0] = rslt.getInt(14);
                ((string[]) buf[17])[0] = rslt.getString(15, 30);
                ((long[]) buf[18])[0] = rslt.getLong(16);
                ((long[]) buf[19])[0] = rslt.getLong(17);
                ((int[]) buf[20])[0] = rslt.getInt(18);
                ((string[]) buf[21])[0] = rslt.getVarchar(19);
                ((int[]) buf[22])[0] = rslt.getInt(20);
                ((string[]) buf[23])[0] = rslt.getVarchar(21);
                ((int[]) buf[24])[0] = rslt.getInt(22);
                ((bool[]) buf[25])[0] = rslt.wasNull(22);
                ((string[]) buf[26])[0] = rslt.getVarchar(23);
                ((string[]) buf[27])[0] = rslt.getString(24, 20);
                ((string[]) buf[28])[0] = rslt.getVarchar(25);
                ((bool[]) buf[29])[0] = rslt.wasNull(25);
                ((string[]) buf[30])[0] = rslt.getString(26, 50);
                ((string[]) buf[31])[0] = rslt.getString(27, 50);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                return;
       }
    }

 }

}
