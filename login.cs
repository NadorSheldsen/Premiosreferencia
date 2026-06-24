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
   public class login : GXDataArea
   {
      public login( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public login( IGxContext context )
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
         PA0E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0E2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("login.aspx") +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "USUARIOCORREO", A31UsuarioCorreo);
         GxWebStd.gx_hidden_field( context, "USUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "USUARIOPASS", A32UsuarioPass);
         GxWebStd.gx_hidden_field( context, "USUARIOKEY", A33UsuarioKey);
         GxWebStd.gx_boolean_hidden_field( context, "USUARIOAVISOPRIVACIDAD", A92UsuarioAvisoPrivacidad);
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vURL", AV17URL);
         GxWebStd.gx_boolean_hidden_field( context, "vACEPTA", AV16Acepta);
         GxWebStd.gx_boolean_hidden_field( context, "vPASA", AV27Pasa);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV29Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV29Messages);
         }
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
            WE0E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0E2( ) ;
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
         return formatLink("login.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Login" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Login", "") ;
      }

      protected void WB0E0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginLogin", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "ImageTop" + " " + ((StringUtil.StrCmp(imgLogologin_gximage, "")==0) ? "GX_Image_ImageLogin_Class" : "GX_Image_"+imgLogologin_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "744438f0-bfeb-4cf7-9c66-74a715f16bf7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLogologin_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Login.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablelogin_Internalname, 1, 0, "px", 0, "px", "TableLogin", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSignin_Internalname, context.GetMessage( "WWP_GAM_SignIn", ""), "", "", lblSignin_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleLogin", 0, "", 1, 1, 0, 0, "HLP_Login.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellLogin CellPaddingLogin", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername_Internalname, context.GetMessage( "Sec User Name", ""), "col-sm-3 AttributeLoginLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername_Internalname, AV7SecUserName, StringUtil.RTrim( context.localUtil.Format( AV7SecUserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Email", ""), edtavSecusername_Jsonclick, 0, "AttributeLogin", "", "", "", "", 1, edtavSecusername_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Login.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellLogin CellPaddingLogin", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuserpassword_Internalname, context.GetMessage( "Sec User Password", ""), "col-sm-3 AttributeLoginLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuserpassword_Internalname, AV8SecUserPassword, StringUtil.RTrim( context.localUtil.Format( AV8SecUserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\""+" "+"data-gx-password-reveal"+" "+"idenableshowpasswordhint=\"True\""+" ", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Password", ""), edtavSecuserpassword_Jsonclick, 0, "AttributeLogin", "", "", "", "", 1, edtavSecuserpassword_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_Login.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 TableActionsCellLogin", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "WWP_GAM_Login", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Login.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAvisoprivacidad_Internalname, context.GetMessage( "Aviso de Privacidad", ""), "", "", lblAvisoprivacidad_Jsonclick, "'"+""+"'"+",false,"+"'"+"EAVISOPRIVACIDAD.CLICK."+"'", "", "TextBlock", 5, "", 1, 1, 0, 0, "HLP_Login.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0E2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Login", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0E0( ) ;
      }

      protected void WS0E2( )
      {
         START0E2( ) ;
         EVT0E2( ) ;
      }

      protected void EVT0E2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E110E2 ();
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
                                    E120E2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "AVISOPRIVACIDAD.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Avisoprivacidad.Click */
                              E130E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.PRIVACYDECISION") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E140E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E150E2 ();
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

      protected void WE0E2( )
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

      protected void PA0E2( )
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
               GX_FocusControl = edtavSecusername_Internalname;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E150E2 ();
            WB0E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0E2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV7SecUserName = cgiGet( edtavSecusername_Internalname);
            AssignAttri("", false, "AV7SecUserName", AV7SecUserName);
            AV8SecUserPassword = cgiGet( edtavSecuserpassword_Internalname);
            AssignAttri("", false, "AV8SecUserPassword", AV8SecUserPassword);
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
         E110E2 ();
         if (returnInSub) return;
      }

      protected void E110E2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV13UsuarioJSON = AV6WebSession.Get(context.GetMessage( "Usuario", ""));
         AV35AuthOK = AV6WebSession.Get(context.GetMessage( "AuthOK", ""));
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13UsuarioJSON)) && ( StringUtil.StrCmp(AV35AuthOK, "1") == 0 ) )
         {
            CallWebObject(formatLink("inicio.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV6WebSession.Remove(context.GetMessage( "Usuario", ""));
            AV6WebSession.Set(context.GetMessage( "AuthOK", ""), "0");
            AV6WebSession.Remove(context.GetMessage( "AuthPending", ""));
            AV6WebSession.Remove(context.GetMessage( "EsPassGenerica", ""));
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E120E2 ();
         if (returnInSub) return;
      }

      protected void E120E2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV6WebSession.Remove("Usuario");
         AV6WebSession.Remove("UsuarioID");
         AV6WebSession.Set("AuthOK", "0");
         AV6WebSession.Remove("AuthPending");
         AV6WebSession.Remove("EsPassGenerica");
         /* Execute user subroutine: 'ENTER' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E130E2( )
      {
         /* Avisoprivacidad_Click Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wpavisoprivacidad.aspx"+UrlEncode(StringUtil.BoolToStr(true));
         AV31AP_URL = formatLink("wpavisoprivacidad.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV21JS = "javascript:window.open('" + StringUtil.StringReplace( StringUtil.Trim( AV31AP_URL), "'", "\\\\'") + "','_blank');";
         CallWebObject(formatLink(AV21JS) );
         context.wjLocDisableFrm = 0;
      }

      protected void E140E2( )
      {
         /* General\GlobalEvents_Privacydecision Routine */
         returnInSub = false;
         if ( AV16Acepta )
         {
            /* Execute user subroutine: 'CAMBIAVALORAVISOPRIVACIDAD' */
            S122 ();
            if (returnInSub) return;
            if ( AV27Pasa )
            {
               AV6WebSession.Set(context.GetMessage( "AuthOK", ""), "1");
               AV6WebSession.Set(context.GetMessage( "AuthPending", ""), "0");
               /* Execute user subroutine: 'NAVEGASIGUIENTEPASO' */
               S132 ();
               if (returnInSub) return;
            }
            else
            {
               AV39GXV1 = 1;
               while ( AV39GXV1 <= AV29Messages.Count )
               {
                  AV30Message = ((GeneXus.Utils.SdtMessages_Message)AV29Messages.Item(AV39GXV1));
                  GX_msglist.addItem(AV30Message.gxTpr_Description);
                  AV39GXV1 = (int)(AV39GXV1+1);
               }
            }
         }
         else
         {
            /* Execute user subroutine: 'CANCELARSESIONPENDING' */
            S142 ();
            if (returnInSub) return;
            GX_msglist.addItem(context.GetMessage( "Necesitas aceptar el aviso para continuar.", ""));
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29Messages", AV29Messages);
      }

      protected void S112( )
      {
         /* 'ENTER' Routine */
         returnInSub = false;
         AV40GXLvl75 = 0;
         /* Using cursor H000E2 */
         pr_default.execute(0, new Object[] {AV7SecUserName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A31UsuarioCorreo = H000E2_A31UsuarioCorreo[0];
            A29UsuarioID = H000E2_A29UsuarioID[0];
            A33UsuarioKey = H000E2_A33UsuarioKey[0];
            A32UsuarioPass = H000E2_A32UsuarioPass[0];
            A92UsuarioAvisoPrivacidad = H000E2_A92UsuarioAvisoPrivacidad[0];
            AV40GXLvl75 = 1;
            AV26UsuarioID = A29UsuarioID;
            AssignAttri("", false, "AV26UsuarioID", StringUtil.LTrimStr( (decimal)(AV26UsuarioID), 9, 0));
            AV6WebSession.Set(context.GetMessage( "UsuarioID", ""), StringUtil.Str( (decimal)(AV26UsuarioID), 9, 0));
            AV9Pass = Decrypt64( A32UsuarioPass, A33UsuarioKey);
            if ( StringUtil.StrCmp(AV8SecUserPassword, AV9Pass) == 0 )
            {
               /* Execute user subroutine: 'GUARDADATOSUSUARIOPENDING' */
               S153 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               AV32EsPassGenerica = (bool)(((StringUtil.StrCmp(AV9Pass, context.GetMessage( "Yokohama1", ""))==0)));
               AV6WebSession.Set(context.GetMessage( "EsPassGenerica", ""), (AV32EsPassGenerica ? "1" : "0"));
               AV25UsuarioAvisoPrivacidad = A92UsuarioAvisoPrivacidad;
               if ( AV25UsuarioAvisoPrivacidad )
               {
                  AV6WebSession.Set(context.GetMessage( "AuthOK", ""), "1");
                  AV6WebSession.Set(context.GetMessage( "AuthPending", ""), "0");
                  /* Execute user subroutine: 'NAVEGASIGUIENTEPASO' */
                  S132 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               else
               {
                  AV6WebSession.Set(context.GetMessage( "AuthOK", ""), "0");
                  AV6WebSession.Set(context.GetMessage( "AuthPending", ""), "1");
                  GXKey = Crypto.GetSiteKey( );
                  GXEncryptionTmp = "wpavisoprivacidad.aspx"+UrlEncode(StringUtil.BoolToStr(false));
                  context.PopUp(formatLink("wpavisoprivacidad.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
               }
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "Usuario y contraseña incorrectos", ""));
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV40GXLvl75 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "Datos no encontrados", ""));
         }
      }

      protected void S142( )
      {
         /* 'CANCELARSESIONPENDING' Routine */
         returnInSub = false;
         AV6WebSession.Remove(context.GetMessage( "Usuario", ""));
         AV6WebSession.Remove(context.GetMessage( "AuthOK", ""));
         AV6WebSession.Remove(context.GetMessage( "AuthPending", ""));
         AV6WebSession.Remove(context.GetMessage( "EsPassGenerica", ""));
         AV6WebSession.Remove(context.GetMessage( "UsuarioID", ""));
      }

      protected void S132( )
      {
         /* 'NAVEGASIGUIENTEPASO' Routine */
         returnInSub = false;
         AV33Flag = AV6WebSession.Get(context.GetMessage( "EsPassGenerica", ""));
         if ( StringUtil.StrCmp(AV33Flag, "1") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpactualizarinfousuario.aspx"+UrlEncode(StringUtil.LTrimStr(AV26UsuarioID,9,0));
            AV34Next = formatLink("wpactualizarinfousuario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AV21JS = "javascript:window.top.location.href='" + StringUtil.StringReplace( StringUtil.Trim( AV34Next), "'", "\\\\'") + "';";
            CallWebObject(formatLink(AV21JS) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            /* Execute user subroutine: 'OBTIENEURLDESTINO' */
            S162 ();
            if (returnInSub) return;
            AV21JS = "javascript:window.top.location.href='" + StringUtil.StringReplace( StringUtil.Trim( AV17URL), "'", "\\\\'") + "';";
            CallWebObject(formatLink(AV21JS) );
            context.wjLocDisableFrm = 0;
         }
      }

      protected void S122( )
      {
         /* 'CAMBIAVALORAVISOPRIVACIDAD' Routine */
         returnInSub = false;
         AV27Pasa = false;
         AssignAttri("", false, "AV27Pasa", AV27Pasa);
         AV26UsuarioID = (int)(Math.Round(NumberUtil.Val( AV6WebSession.Get(context.GetMessage( "UsuarioID", "")), "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV26UsuarioID", StringUtil.LTrimStr( (decimal)(AV26UsuarioID), 9, 0));
         AV28Usuario = new SdtUsuario(context);
         AV28Usuario.Load(AV26UsuarioID);
         AV28Usuario.gxTpr_Usuarioavisoprivacidad = true;
         AV28Usuario.Update();
         if ( AV28Usuario.Success() )
         {
            AV27Pasa = true;
            AssignAttri("", false, "AV27Pasa", AV27Pasa);
            context.CommitDataStores("login",pr_default);
         }
         else
         {
            AV29Messages = AV28Usuario.GetMessages();
         }
      }

      protected void S162( )
      {
         /* 'OBTIENEURLDESTINO' Routine */
         returnInSub = false;
         new obtienevalordirectiva(context ).execute(  context.GetMessage( "VALIDAMOSTRARANUNCIO", ""), out  AV38VALIDAMOSTRARANUNCIO) ;
         new obtienevalordirectiva(context ).execute(  context.GetMessage( "VALIDAMOSTRARVIDEO", ""), out  AV15VALIDAMOSTRARVIDEO) ;
         if ( StringUtil.StrCmp(StringUtil.Upper( AV15VALIDAMOSTRARVIDEO), context.GetMessage( "TRUE", "")) == 0 )
         {
            AV17URL = formatLink("wpvideo.aspx") ;
            AssignAttri("", false, "AV17URL", AV17URL);
         }
         else
         {
            if ( StringUtil.StrCmp(StringUtil.Upper( AV38VALIDAMOSTRARANUNCIO), context.GetMessage( "TRUE", "")) == 0 )
            {
               AV17URL = formatLink("wpavisomensaje.aspx") ;
               AssignAttri("", false, "AV17URL", AV17URL);
            }
            else
            {
               AV17URL = formatLink("inicio.aspx") ;
               AssignAttri("", false, "AV17URL", AV17URL);
            }
         }
      }

      protected void S153( )
      {
         /* 'GUARDADATOSUSUARIOPENDING' Routine */
         returnInSub = false;
         AV37Temp_Usuario = new SdtUsuario(context);
         AV37Temp_Usuario.Load(AV26UsuarioID);
         AV12SDTUsuario = new SdtSDTUsuario(context);
         AV12SDTUsuario.gxTpr_Usuarioid = AV37Temp_Usuario.gxTpr_Usuarioid;
         AV12SDTUsuario.gxTpr_Usuarionombre = AV37Temp_Usuario.gxTpr_Usuarionombre;
         AV12SDTUsuario.gxTpr_Usuariocorreo = AV37Temp_Usuario.gxTpr_Usuariocorreo;
         AV12SDTUsuario.gxTpr_Usuariorol = AV37Temp_Usuario.gxTpr_Usuariorol;
         AV12SDTUsuario.gxTpr_Usuarioapellido = AV37Temp_Usuario.gxTpr_Usuarioapellido;
         AV12SDTUsuario.gxTpr_Usuarionombrecompleto = AV37Temp_Usuario.gxTpr_Usuarionombrecompleto;
         AV12SDTUsuario.gxTpr_Puestoid = AV37Temp_Usuario.gxTpr_Puestoid;
         AV12SDTUsuario.gxTpr_Puestodescripcion = AV37Temp_Usuario.gxTpr_Puestodescripcion;
         AV12SDTUsuario.gxTpr_Usuariogenero = AV37Temp_Usuario.gxTpr_Usuariogenero;
         AV12SDTUsuario.gxTpr_Usuariodirectoasociado = AV37Temp_Usuario.gxTpr_Usuariodirectoasociado;
         AV12SDTUsuario.gxTpr_Usuariorazonsocialasociado = AV37Temp_Usuario.gxTpr_Usuariorazonsocialasociado;
         AV12SDTUsuario.gxTpr_Usuarionombrecomercial = AV37Temp_Usuario.gxTpr_Usuarionombrecomercial;
         AV12SDTUsuario.gxTpr_Usuariofechanacimiento = AV37Temp_Usuario.gxTpr_Usuariofechanacimiento;
         AV12SDTUsuario.gxTpr_Usuariocallenum = AV37Temp_Usuario.gxTpr_Usuariocallenum;
         AV12SDTUsuario.gxTpr_Usuariocolonia = AV37Temp_Usuario.gxTpr_Usuariocolonia;
         AV12SDTUsuario.gxTpr_Usuariodelegacion = AV37Temp_Usuario.gxTpr_Usuariodelegacion;
         AV12SDTUsuario.gxTpr_Usuariocp = AV37Temp_Usuario.gxTpr_Usuariocp;
         AV12SDTUsuario.gxTpr_Usuariozona = AV37Temp_Usuario.gxTpr_Usuariozona;
         AV12SDTUsuario.gxTpr_Usuariocelular = AV37Temp_Usuario.gxTpr_Usuariocelular;
         AV12SDTUsuario.gxTpr_Usuariotelefonosucursal = AV37Temp_Usuario.gxTpr_Usuariotelefonosucursal;
         AV12SDTUsuario.gxTpr_Paisid = AV37Temp_Usuario.gxTpr_Paisid;
         AV12SDTUsuario.gxTpr_Paisdescripcion = AV37Temp_Usuario.gxTpr_Paisdescripcion;
         AV12SDTUsuario.gxTpr_Estadoid = AV37Temp_Usuario.gxTpr_Estadoid;
         AV12SDTUsuario.gxTpr_Estadodescripcion = AV37Temp_Usuario.gxTpr_Estadodescripcion;
         AV12SDTUsuario.gxTpr_Ciudadid = AV37Temp_Usuario.gxTpr_Ciudadid;
         AV12SDTUsuario.gxTpr_Ciudaddescripcion = AV37Temp_Usuario.gxTpr_Ciudaddescripcion;
         AV12SDTUsuario.gxTpr_Usuariosucursal = AV37Temp_Usuario.gxTpr_Usuariosucursal;
         AV12SDTUsuario.gxTpr_Usuarioproducto = AV37Temp_Usuario.gxTpr_Usuarioproducto;
         AV12SDTUsuario.gxTpr_Usuarioavisoprivacidad = AV37Temp_Usuario.gxTpr_Usuarioavisoprivacidad;
         AV13UsuarioJSON = AV12SDTUsuario.ToJSonString(false, true);
         AV6WebSession.Set(context.GetMessage( "Usuario", ""), AV13UsuarioJSON);
      }

      protected void nextLoad( )
      {
      }

      protected void E150E2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA0E2( ) ;
         WS0E2( ) ;
         WE0E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20265111131283", true, true);
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
         context.AddJavascriptSource("login.js", "?20265111131283", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgLogologin_Internalname = "LOGOLOGIN";
         lblSignin_Internalname = "SIGNIN";
         edtavSecusername_Internalname = "vSECUSERNAME";
         edtavSecuserpassword_Internalname = "vSECUSERPASSWORD";
         bttBtnenter_Internalname = "BTNENTER";
         lblAvisoprivacidad_Internalname = "AVISOPRIVACIDAD";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         divTablelogin_Internalname = "TABLELOGIN";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablecontent_Internalname = "TABLECONTENT";
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
         edtavSecuserpassword_Jsonclick = "";
         edtavSecuserpassword_Enabled = 1;
         edtavSecusername_Jsonclick = "";
         edtavSecusername_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Login", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("ENTER","""{"handler":"E120E2","iparms":[{"av":"A31UsuarioCorreo","fld":"USUARIOCORREO"},{"av":"AV7SecUserName","fld":"vSECUSERNAME"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9"},{"av":"A32UsuarioPass","fld":"USUARIOPASS"},{"av":"A33UsuarioKey","fld":"USUARIOKEY"},{"av":"AV8SecUserPassword","fld":"vSECUSERPASSWORD"},{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"},{"av":"AV26UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV17URL","fld":"vURL"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV26UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV17URL","fld":"vURL"}]}""");
         setEventMetadata("AVISOPRIVACIDAD.CLICK","""{"handler":"E130E2","iparms":[]}""");
         setEventMetadata("GLOBALEVENTS.PRIVACYDECISION","""{"handler":"E140E2","iparms":[{"av":"AV17URL","fld":"vURL"},{"av":"AV16Acepta","fld":"vACEPTA"},{"av":"AV27Pasa","fld":"vPASA"},{"av":"AV29Messages","fld":"vMESSAGES"},{"av":"AV26UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9"}]""");
         setEventMetadata("GLOBALEVENTS.PRIVACYDECISION",""","oparms":[{"av":"AV27Pasa","fld":"vPASA"},{"av":"AV26UsuarioID","fld":"vUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"AV29Messages","fld":"vMESSAGES"},{"av":"AV17URL","fld":"vURL"}]}""");
         setEventMetadata("VALIDV_SECUSERNAME","""{"handler":"Validv_Secusername","iparms":[]}""");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         A31UsuarioCorreo = "";
         A32UsuarioPass = "";
         A33UsuarioKey = "";
         AV17URL = "";
         AV29Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         imgLogologin_gximage = "";
         StyleString = "";
         sImgUrl = "";
         lblSignin_Jsonclick = "";
         TempTags = "";
         AV7SecUserName = "";
         AV8SecUserPassword = "";
         bttBtnenter_Jsonclick = "";
         lblAvisoprivacidad_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV13UsuarioJSON = "";
         AV6WebSession = context.GetSession();
         AV35AuthOK = "";
         AV31AP_URL = "";
         GXEncryptionTmp = "";
         AV21JS = "";
         AV30Message = new GeneXus.Utils.SdtMessages_Message(context);
         H000E2_A31UsuarioCorreo = new string[] {""} ;
         H000E2_A29UsuarioID = new int[1] ;
         H000E2_A33UsuarioKey = new string[] {""} ;
         H000E2_A32UsuarioPass = new string[] {""} ;
         H000E2_A92UsuarioAvisoPrivacidad = new bool[] {false} ;
         AV9Pass = "";
         AV25UsuarioAvisoPrivacidad = false;
         AV33Flag = "";
         AV34Next = "";
         AV28Usuario = new SdtUsuario(context);
         AV38VALIDAMOSTRARANUNCIO = "";
         AV15VALIDAMOSTRARVIDEO = "";
         AV37Temp_Usuario = new SdtUsuario(context);
         AV12SDTUsuario = new SdtSDTUsuario(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.login__default(),
            new Object[][] {
                new Object[] {
               H000E2_A31UsuarioCorreo, H000E2_A29UsuarioID, H000E2_A33UsuarioKey, H000E2_A32UsuarioPass, H000E2_A92UsuarioAvisoPrivacidad
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV40GXLvl75 ;
      private short nGXWrapped ;
      private int A29UsuarioID ;
      private int AV26UsuarioID ;
      private int edtavSecusername_Enabled ;
      private int edtavSecuserpassword_Enabled ;
      private int AV39GXV1 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string ClassString ;
      private string imgLogologin_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgLogologin_Internalname ;
      private string divTablelogin_Internalname ;
      private string lblSignin_Internalname ;
      private string lblSignin_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string edtavSecusername_Internalname ;
      private string TempTags ;
      private string edtavSecusername_Jsonclick ;
      private string edtavSecuserpassword_Internalname ;
      private string edtavSecuserpassword_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string lblAvisoprivacidad_Internalname ;
      private string lblAvisoprivacidad_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV35AuthOK ;
      private string GXEncryptionTmp ;
      private string AV9Pass ;
      private string AV33Flag ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool A92UsuarioAvisoPrivacidad ;
      private bool AV16Acepta ;
      private bool AV27Pasa ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV32EsPassGenerica ;
      private bool AV25UsuarioAvisoPrivacidad ;
      private string AV13UsuarioJSON ;
      private string AV21JS ;
      private string A31UsuarioCorreo ;
      private string A32UsuarioPass ;
      private string A33UsuarioKey ;
      private string AV17URL ;
      private string AV7SecUserName ;
      private string AV8SecUserPassword ;
      private string AV31AP_URL ;
      private string AV34Next ;
      private string AV38VALIDAMOSTRARANUNCIO ;
      private string AV15VALIDAMOSTRARVIDEO ;
      private IGxSession AV6WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV29Messages ;
      private GeneXus.Utils.SdtMessages_Message AV30Message ;
      private IDataStoreProvider pr_default ;
      private string[] H000E2_A31UsuarioCorreo ;
      private int[] H000E2_A29UsuarioID ;
      private string[] H000E2_A33UsuarioKey ;
      private string[] H000E2_A32UsuarioPass ;
      private bool[] H000E2_A92UsuarioAvisoPrivacidad ;
      private SdtUsuario AV28Usuario ;
      private SdtUsuario AV37Temp_Usuario ;
      private SdtSDTUsuario AV12SDTUsuario ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class login__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000E2;
          prmH000E2 = new Object[] {
          new ParDef("@AV7SecUserName",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000E2", "SELECT `UsuarioCorreo`, `UsuarioID`, `UsuarioKey`, `UsuarioPass`, `UsuarioAvisoPrivacidad` FROM `Usuario` WHERE `UsuarioCorreo` = @AV7SecUserName ORDER BY `UsuarioID`  LIMIT 1",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000E2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                return;
       }
    }

 }

}
