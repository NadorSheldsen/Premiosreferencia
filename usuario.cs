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
   public class usuario : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A13PuestoID = (int)(Math.Round(NumberUtil.Val( GetPar( "PuestoID"), "."), 18, MidpointRounding.ToEven));
            n13PuestoID = false;
            AssignAttri("", false, "A13PuestoID", StringUtil.LTrimStr( (decimal)(A13PuestoID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A13PuestoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A4CiudadID = (int)(Math.Round(NumberUtil.Val( GetPar( "CiudadID"), "."), 18, MidpointRounding.ToEven));
            n4CiudadID = false;
            AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A4CiudadID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A1EstadoID = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadoID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A1EstadoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A16PaisID = (int)(Math.Round(NumberUtil.Val( GetPar( "PaisID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A16PaisID) ;
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Usuario", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtUsuarioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public usuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usuario( IGxContext context )
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
         cmbUsuarioGenero = new GXCombobox();
         cmbUsuarioDirectoAsociado = new GXCombobox();
         cmbUsuarioZona = new GXCombobox();
         cmbUsuarioProducto = new GXCombobox();
         cmbUsuarioRol = new GXCombobox();
         chkUsuarioAvisoPrivacidad = new GXCheckbox();
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
         if ( cmbUsuarioGenero.ItemCount > 0 )
         {
            A53UsuarioGenero = cmbUsuarioGenero.getValidValue(A53UsuarioGenero);
            AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioGenero.CurrentValue = StringUtil.RTrim( A53UsuarioGenero);
            AssignProp("", false, cmbUsuarioGenero_Internalname, "Values", cmbUsuarioGenero.ToJavascriptSource(), true);
         }
         if ( cmbUsuarioDirectoAsociado.ItemCount > 0 )
         {
            A54UsuarioDirectoAsociado = cmbUsuarioDirectoAsociado.getValidValue(A54UsuarioDirectoAsociado);
            n54UsuarioDirectoAsociado = false;
            AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioDirectoAsociado.CurrentValue = StringUtil.RTrim( A54UsuarioDirectoAsociado);
            AssignProp("", false, cmbUsuarioDirectoAsociado_Internalname, "Values", cmbUsuarioDirectoAsociado.ToJavascriptSource(), true);
         }
         if ( cmbUsuarioZona.ItemCount > 0 )
         {
            A63UsuarioZona = cmbUsuarioZona.getValidValue(A63UsuarioZona);
            AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioZona.CurrentValue = StringUtil.RTrim( A63UsuarioZona);
            AssignProp("", false, cmbUsuarioZona_Internalname, "Values", cmbUsuarioZona.ToJavascriptSource(), true);
         }
         if ( cmbUsuarioProducto.ItemCount > 0 )
         {
            A67UsuarioProducto = cmbUsuarioProducto.getValidValue(A67UsuarioProducto);
            n67UsuarioProducto = false;
            AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioProducto.CurrentValue = StringUtil.RTrim( A67UsuarioProducto);
            AssignProp("", false, cmbUsuarioProducto_Internalname, "Values", cmbUsuarioProducto.ToJavascriptSource(), true);
         }
         if ( cmbUsuarioRol.ItemCount > 0 )
         {
            A40UsuarioRol = cmbUsuarioRol.getValidValue(A40UsuarioRol);
            AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioRol.CurrentValue = StringUtil.RTrim( A40UsuarioRol);
            AssignProp("", false, cmbUsuarioRol_Internalname, "Values", cmbUsuarioRol.ToJavascriptSource(), true);
         }
         A92UsuarioAvisoPrivacidad = StringUtil.StrToBool( StringUtil.BoolToStr( A92UsuarioAvisoPrivacidad));
         AssignAttri("", false, "A92UsuarioAvisoPrivacidad", A92UsuarioAvisoPrivacidad);
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Usuario", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Usuario.htm");
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
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioID_Internalname, context.GetMessage( "ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioID_Enabled!=0) ? context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombre_Internalname, StringUtil.RTrim( A30UsuarioNombre), StringUtil.RTrim( context.localUtil.Format( A30UsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioApellido_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioApellido_Internalname, context.GetMessage( "Apellido(s)", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioApellido_Internalname, StringUtil.RTrim( A51UsuarioApellido), StringUtil.RTrim( context.localUtil.Format( A51UsuarioApellido, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioApellido_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioApellido_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioNombreCompleto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioNombreCompleto_Internalname, context.GetMessage( "Nombre completo", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombreCompleto_Internalname, A52UsuarioNombreCompleto, StringUtil.RTrim( context.localUtil.Format( A52UsuarioNombreCompleto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombreCompleto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNombreCompleto_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioCorreo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioCorreo_Internalname, context.GetMessage( "Correo", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioCorreo_Internalname, A31UsuarioCorreo, StringUtil.RTrim( context.localUtil.Format( A31UsuarioCorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A31UsuarioCorreo, "", "", "", edtUsuarioCorreo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioCorreo_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioPass_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioPass_Internalname, context.GetMessage( "Pass", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioPass_Internalname, A32UsuarioPass, StringUtil.RTrim( context.localUtil.Format( A32UsuarioPass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioPass_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioPass_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioKey_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioKey_Internalname, context.GetMessage( "Key", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioKey_Internalname, A33UsuarioKey, StringUtil.RTrim( context.localUtil.Format( A33UsuarioKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioKey_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioKey_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPuestoID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPuestoID_Internalname, context.GetMessage( "Puesto ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPuestoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PuestoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPuestoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A13PuestoID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A13PuestoID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPuestoID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPuestoID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPuestoDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPuestoDescripcion_Internalname, context.GetMessage( "Puesto", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPuestoDescripcion_Internalname, A14PuestoDescripcion, StringUtil.RTrim( context.localUtil.Format( A14PuestoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPuestoDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPuestoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbUsuarioGenero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbUsuarioGenero_Internalname, context.GetMessage( "Género", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioGenero, cmbUsuarioGenero_Internalname, StringUtil.RTrim( A53UsuarioGenero), 1, cmbUsuarioGenero_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioGenero.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_Usuario.htm");
         cmbUsuarioGenero.CurrentValue = StringUtil.RTrim( A53UsuarioGenero);
         AssignProp("", false, cmbUsuarioGenero_Internalname, "Values", (string)(cmbUsuarioGenero.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbUsuarioDirectoAsociado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbUsuarioDirectoAsociado_Internalname, context.GetMessage( "Directo/Asociado", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioDirectoAsociado, cmbUsuarioDirectoAsociado_Internalname, StringUtil.RTrim( A54UsuarioDirectoAsociado), 1, cmbUsuarioDirectoAsociado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioDirectoAsociado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "", true, 0, "HLP_Usuario.htm");
         cmbUsuarioDirectoAsociado.CurrentValue = StringUtil.RTrim( A54UsuarioDirectoAsociado);
         AssignProp("", false, cmbUsuarioDirectoAsociado_Internalname, "Values", (string)(cmbUsuarioDirectoAsociado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioRazonSocialAsociado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioRazonSocialAsociado_Internalname, context.GetMessage( "Razón Social Asociado", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioRazonSocialAsociado_Internalname, A55UsuarioRazonSocialAsociado, StringUtil.RTrim( context.localUtil.Format( A55UsuarioRazonSocialAsociado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioRazonSocialAsociado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioRazonSocialAsociado_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioNombreComercial_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioNombreComercial_Internalname, context.GetMessage( "Nombre Comercial", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombreComercial_Internalname, A56UsuarioNombreComercial, StringUtil.RTrim( context.localUtil.Format( A56UsuarioNombreComercial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombreComercial_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNombreComercial_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioFechaNacimiento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioFechaNacimiento_Internalname, context.GetMessage( "Fecha de nacimiento", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtUsuarioFechaNacimiento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUsuarioFechaNacimiento_Internalname, context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"), context.localUtil.Format( A57UsuarioFechaNacimiento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioFechaNacimiento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioFechaNacimiento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Usuario.htm");
         GxWebStd.gx_bitmap( context, edtUsuarioFechaNacimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuarioFechaNacimiento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Usuario.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioCalleNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioCalleNum_Internalname, context.GetMessage( "Calle y número", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioCalleNum_Internalname, StringUtil.RTrim( A59UsuarioCalleNum), StringUtil.RTrim( context.localUtil.Format( A59UsuarioCalleNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioCalleNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioCalleNum_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioColonia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioColonia_Internalname, context.GetMessage( "Colonia", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioColonia_Internalname, StringUtil.RTrim( A60UsuarioColonia), StringUtil.RTrim( context.localUtil.Format( A60UsuarioColonia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioColonia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioColonia_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioDelegacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioDelegacion_Internalname, context.GetMessage( "Delegación", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioDelegacion_Internalname, StringUtil.RTrim( A61UsuarioDelegacion), StringUtil.RTrim( context.localUtil.Format( A61UsuarioDelegacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioDelegacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioDelegacion_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioCP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioCP_Internalname, context.GetMessage( "Código Postal", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioCP_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A62UsuarioCP), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioCP_Enabled!=0) ? context.localUtil.Format( (decimal)(A62UsuarioCP), "ZZZZ9") : context.localUtil.Format( (decimal)(A62UsuarioCP), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioCP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioCP_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbUsuarioZona_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbUsuarioZona_Internalname, context.GetMessage( "Zona", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioZona, cmbUsuarioZona_Internalname, StringUtil.RTrim( A63UsuarioZona), 1, cmbUsuarioZona_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioZona.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"", "", true, 0, "HLP_Usuario.htm");
         cmbUsuarioZona.CurrentValue = StringUtil.RTrim( A63UsuarioZona);
         AssignProp("", false, cmbUsuarioZona_Internalname, "Values", (string)(cmbUsuarioZona.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioCelular_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioCelular_Internalname, context.GetMessage( "Celular", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioCelular_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A64UsuarioCelular), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioCelular_Enabled!=0) ? context.localUtil.Format( (decimal)(A64UsuarioCelular), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A64UsuarioCelular), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioCelular_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioCelular_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioTelefonoSucursal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioTelefonoSucursal_Internalname, context.GetMessage( "Teléfono Sucursal", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioTelefonoSucursal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A65UsuarioTelefonoSucursal), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioTelefonoSucursal_Enabled!=0) ? context.localUtil.Format( (decimal)(A65UsuarioTelefonoSucursal), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A65UsuarioTelefonoSucursal), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioTelefonoSucursal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioTelefonoSucursal_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisID_Internalname, context.GetMessage( "Pais ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPaisID_Enabled!=0) ? context.localUtil.Format( (decimal)(A16PaisID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A16PaisID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisDescripcion_Internalname, context.GetMessage( "País", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisDescripcion_Internalname, A17PaisDescripcion, StringUtil.RTrim( context.localUtil.Format( A17PaisDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadoID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoID_Internalname, context.GetMessage( "Estado ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtEstadoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EstadoID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1EstadoID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,149);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstadoID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadoDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoDescripcion_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadoDescripcion_Internalname, A2EstadoDescripcion, StringUtil.RTrim( context.localUtil.Format( A2EstadoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,154);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstadoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCiudadID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCiudadID_Internalname, context.GetMessage( "Ciudad ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCiudadID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCiudadID_Enabled!=0) ? context.localUtil.Format( (decimal)(A4CiudadID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A4CiudadID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,159);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCiudadID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCiudadID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCiudadDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCiudadDescripcion_Internalname, context.GetMessage( "Ciudad", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCiudadDescripcion_Internalname, A5CiudadDescripcion, StringUtil.RTrim( context.localUtil.Format( A5CiudadDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCiudadDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCiudadDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioSucursal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioSucursal_Internalname, context.GetMessage( "Sucursal", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioSucursal_Internalname, StringUtil.RTrim( A66UsuarioSucursal), StringUtil.RTrim( context.localUtil.Format( A66UsuarioSucursal, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioSucursal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioSucursal_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbUsuarioProducto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbUsuarioProducto_Internalname, context.GetMessage( "Producto que vendes", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioProducto, cmbUsuarioProducto_Internalname, StringUtil.RTrim( A67UsuarioProducto), 1, cmbUsuarioProducto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbUsuarioProducto.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,174);\"", "", true, 0, "HLP_Usuario.htm");
         cmbUsuarioProducto.CurrentValue = StringUtil.RTrim( A67UsuarioProducto);
         AssignProp("", false, cmbUsuarioProducto_Internalname, "Values", (string)(cmbUsuarioProducto.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbUsuarioRol_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbUsuarioRol_Internalname, context.GetMessage( "Rol", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioRol, cmbUsuarioRol_Internalname, StringUtil.RTrim( A40UsuarioRol), 1, cmbUsuarioRol_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioRol.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,179);\"", "", true, 0, "HLP_Usuario.htm");
         cmbUsuarioRol.CurrentValue = StringUtil.RTrim( A40UsuarioRol);
         AssignProp("", false, cmbUsuarioRol_Internalname, "Values", (string)(cmbUsuarioRol.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioNoCuentaBROXEL_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioNoCuentaBROXEL_Internalname, context.GetMessage( "Cuenta BROXEL", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioNoCuentaBROXEL_Internalname, StringUtil.RTrim( A82UsuarioNoCuentaBROXEL), StringUtil.RTrim( context.localUtil.Format( A82UsuarioNoCuentaBROXEL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,184);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNoCuentaBROXEL_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNoCuentaBROXEL_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioReferenciaBROXEL_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioReferenciaBROXEL_Internalname, context.GetMessage( "Referencia BROXEL", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioReferenciaBROXEL_Internalname, StringUtil.RTrim( A83UsuarioReferenciaBROXEL), StringUtil.RTrim( context.localUtil.Format( A83UsuarioReferenciaBROXEL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,189);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioReferenciaBROXEL_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioReferenciaBROXEL_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioFechaRegistro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioFechaRegistro_Internalname, context.GetMessage( "Fecha Registro", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtUsuarioFechaRegistro_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUsuarioFechaRegistro_Internalname, context.localUtil.Format(A87UsuarioFechaRegistro, "99/99/99"), context.localUtil.Format( A87UsuarioFechaRegistro, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,194);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioFechaRegistro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioFechaRegistro_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Usuario.htm");
         GxWebStd.gx_bitmap( context, edtUsuarioFechaRegistro_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuarioFechaRegistro_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Usuario.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkUsuarioAvisoPrivacidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuarioAvisoPrivacidad_Internalname, context.GetMessage( "de Privacidad", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 199,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuarioAvisoPrivacidad_Internalname, StringUtil.BoolToStr( A92UsuarioAvisoPrivacidad), "", context.GetMessage( "de Privacidad", ""), 1, chkUsuarioAvisoPrivacidad.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(199, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,199);\"");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 208,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z29UsuarioID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z30UsuarioNombre = cgiGet( "Z30UsuarioNombre");
            Z51UsuarioApellido = cgiGet( "Z51UsuarioApellido");
            Z31UsuarioCorreo = cgiGet( "Z31UsuarioCorreo");
            Z32UsuarioPass = cgiGet( "Z32UsuarioPass");
            Z33UsuarioKey = cgiGet( "Z33UsuarioKey");
            Z53UsuarioGenero = cgiGet( "Z53UsuarioGenero");
            Z54UsuarioDirectoAsociado = cgiGet( "Z54UsuarioDirectoAsociado");
            n54UsuarioDirectoAsociado = (String.IsNullOrEmpty(StringUtil.RTrim( A54UsuarioDirectoAsociado)) ? true : false);
            Z55UsuarioRazonSocialAsociado = cgiGet( "Z55UsuarioRazonSocialAsociado");
            Z56UsuarioNombreComercial = cgiGet( "Z56UsuarioNombreComercial");
            Z57UsuarioFechaNacimiento = context.localUtil.CToD( cgiGet( "Z57UsuarioFechaNacimiento"), 0);
            n57UsuarioFechaNacimiento = ((DateTime.MinValue==A57UsuarioFechaNacimiento) ? true : false);
            Z59UsuarioCalleNum = cgiGet( "Z59UsuarioCalleNum");
            Z60UsuarioColonia = cgiGet( "Z60UsuarioColonia");
            Z61UsuarioDelegacion = cgiGet( "Z61UsuarioDelegacion");
            Z62UsuarioCP = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z62UsuarioCP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z63UsuarioZona = cgiGet( "Z63UsuarioZona");
            Z64UsuarioCelular = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z64UsuarioCelular"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z65UsuarioTelefonoSucursal = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z65UsuarioTelefonoSucursal"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z66UsuarioSucursal = cgiGet( "Z66UsuarioSucursal");
            Z67UsuarioProducto = cgiGet( "Z67UsuarioProducto");
            n67UsuarioProducto = (String.IsNullOrEmpty(StringUtil.RTrim( A67UsuarioProducto)) ? true : false);
            Z40UsuarioRol = cgiGet( "Z40UsuarioRol");
            Z82UsuarioNoCuentaBROXEL = cgiGet( "Z82UsuarioNoCuentaBROXEL");
            Z83UsuarioReferenciaBROXEL = cgiGet( "Z83UsuarioReferenciaBROXEL");
            Z87UsuarioFechaRegistro = context.localUtil.CToD( cgiGet( "Z87UsuarioFechaRegistro"), 0);
            n87UsuarioFechaRegistro = ((DateTime.MinValue==A87UsuarioFechaRegistro) ? true : false);
            Z92UsuarioAvisoPrivacidad = StringUtil.StrToBool( cgiGet( "Z92UsuarioAvisoPrivacidad"));
            Z13PuestoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z13PuestoID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n13PuestoID = ((0==A13PuestoID) ? true : false);
            Z4CiudadID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z4CiudadID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n4CiudadID = ((0==A4CiudadID) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuarioID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuarioID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOID");
               AnyError = 1;
               GX_FocusControl = edtUsuarioID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A29UsuarioID = 0;
               AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
            }
            else
            {
               A29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
            }
            A30UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
            AssignAttri("", false, "A30UsuarioNombre", A30UsuarioNombre);
            A51UsuarioApellido = cgiGet( edtUsuarioApellido_Internalname);
            AssignAttri("", false, "A51UsuarioApellido", A51UsuarioApellido);
            A52UsuarioNombreCompleto = cgiGet( edtUsuarioNombreCompleto_Internalname);
            AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
            A31UsuarioCorreo = cgiGet( edtUsuarioCorreo_Internalname);
            AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
            A32UsuarioPass = cgiGet( edtUsuarioPass_Internalname);
            AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
            A33UsuarioKey = cgiGet( edtUsuarioKey_Internalname);
            AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPuestoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPuestoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PUESTOID");
               AnyError = 1;
               GX_FocusControl = edtPuestoID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A13PuestoID = 0;
               n13PuestoID = false;
               AssignAttri("", false, "A13PuestoID", StringUtil.LTrimStr( (decimal)(A13PuestoID), 9, 0));
            }
            else
            {
               A13PuestoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPuestoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n13PuestoID = false;
               AssignAttri("", false, "A13PuestoID", StringUtil.LTrimStr( (decimal)(A13PuestoID), 9, 0));
            }
            n13PuestoID = ((0==A13PuestoID) ? true : false);
            A14PuestoDescripcion = cgiGet( edtPuestoDescripcion_Internalname);
            AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
            cmbUsuarioGenero.CurrentValue = cgiGet( cmbUsuarioGenero_Internalname);
            A53UsuarioGenero = cgiGet( cmbUsuarioGenero_Internalname);
            AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
            cmbUsuarioDirectoAsociado.CurrentValue = cgiGet( cmbUsuarioDirectoAsociado_Internalname);
            A54UsuarioDirectoAsociado = cgiGet( cmbUsuarioDirectoAsociado_Internalname);
            n54UsuarioDirectoAsociado = false;
            AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
            n54UsuarioDirectoAsociado = (String.IsNullOrEmpty(StringUtil.RTrim( A54UsuarioDirectoAsociado)) ? true : false);
            A55UsuarioRazonSocialAsociado = cgiGet( edtUsuarioRazonSocialAsociado_Internalname);
            AssignAttri("", false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
            A56UsuarioNombreComercial = cgiGet( edtUsuarioNombreComercial_Internalname);
            AssignAttri("", false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
            if ( context.localUtil.VCDate( cgiGet( edtUsuarioFechaNacimiento_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha de nacimiento", "")}), 1, "USUARIOFECHANACIMIENTO");
               AnyError = 1;
               GX_FocusControl = edtUsuarioFechaNacimiento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A57UsuarioFechaNacimiento = DateTime.MinValue;
               n57UsuarioFechaNacimiento = false;
               AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
            }
            else
            {
               A57UsuarioFechaNacimiento = context.localUtil.CToD( cgiGet( edtUsuarioFechaNacimiento_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               n57UsuarioFechaNacimiento = false;
               AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
            }
            n57UsuarioFechaNacimiento = ((DateTime.MinValue==A57UsuarioFechaNacimiento) ? true : false);
            A59UsuarioCalleNum = cgiGet( edtUsuarioCalleNum_Internalname);
            AssignAttri("", false, "A59UsuarioCalleNum", A59UsuarioCalleNum);
            A60UsuarioColonia = cgiGet( edtUsuarioColonia_Internalname);
            AssignAttri("", false, "A60UsuarioColonia", A60UsuarioColonia);
            A61UsuarioDelegacion = cgiGet( edtUsuarioDelegacion_Internalname);
            AssignAttri("", false, "A61UsuarioDelegacion", A61UsuarioDelegacion);
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuarioCP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuarioCP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOCP");
               AnyError = 1;
               GX_FocusControl = edtUsuarioCP_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A62UsuarioCP = 0;
               AssignAttri("", false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
            }
            else
            {
               A62UsuarioCP = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioCP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
            }
            cmbUsuarioZona.CurrentValue = cgiGet( cmbUsuarioZona_Internalname);
            A63UsuarioZona = cgiGet( cmbUsuarioZona_Internalname);
            AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuarioCelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuarioCelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOCELULAR");
               AnyError = 1;
               GX_FocusControl = edtUsuarioCelular_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A64UsuarioCelular = 0;
               AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
            }
            else
            {
               A64UsuarioCelular = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioCelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuarioTelefonoSucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuarioTelefonoSucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOTELEFONOSUCURSAL");
               AnyError = 1;
               GX_FocusControl = edtUsuarioTelefonoSucursal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A65UsuarioTelefonoSucursal = 0;
               AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
            }
            else
            {
               A65UsuarioTelefonoSucursal = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioTelefonoSucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
            }
            A16PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPaisID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            A17PaisDescripcion = cgiGet( edtPaisDescripcion_Internalname);
            AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
            A1EstadoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            A2EstadoDescripcion = cgiGet( edtEstadoDescripcion_Internalname);
            AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCiudadID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCiudadID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CIUDADID");
               AnyError = 1;
               GX_FocusControl = edtCiudadID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A4CiudadID = 0;
               n4CiudadID = false;
               AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
            }
            else
            {
               A4CiudadID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCiudadID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n4CiudadID = false;
               AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
            }
            n4CiudadID = ((0==A4CiudadID) ? true : false);
            A5CiudadDescripcion = cgiGet( edtCiudadDescripcion_Internalname);
            AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
            A66UsuarioSucursal = cgiGet( edtUsuarioSucursal_Internalname);
            AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
            cmbUsuarioProducto.CurrentValue = cgiGet( cmbUsuarioProducto_Internalname);
            A67UsuarioProducto = cgiGet( cmbUsuarioProducto_Internalname);
            n67UsuarioProducto = false;
            AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
            n67UsuarioProducto = (String.IsNullOrEmpty(StringUtil.RTrim( A67UsuarioProducto)) ? true : false);
            cmbUsuarioRol.CurrentValue = cgiGet( cmbUsuarioRol_Internalname);
            A40UsuarioRol = cgiGet( cmbUsuarioRol_Internalname);
            AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
            A82UsuarioNoCuentaBROXEL = cgiGet( edtUsuarioNoCuentaBROXEL_Internalname);
            AssignAttri("", false, "A82UsuarioNoCuentaBROXEL", A82UsuarioNoCuentaBROXEL);
            A83UsuarioReferenciaBROXEL = cgiGet( edtUsuarioReferenciaBROXEL_Internalname);
            AssignAttri("", false, "A83UsuarioReferenciaBROXEL", A83UsuarioReferenciaBROXEL);
            if ( context.localUtil.VCDate( cgiGet( edtUsuarioFechaRegistro_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Usuario Fecha Registro", "")}), 1, "USUARIOFECHAREGISTRO");
               AnyError = 1;
               GX_FocusControl = edtUsuarioFechaRegistro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A87UsuarioFechaRegistro = DateTime.MinValue;
               n87UsuarioFechaRegistro = false;
               AssignAttri("", false, "A87UsuarioFechaRegistro", context.localUtil.Format(A87UsuarioFechaRegistro, "99/99/99"));
            }
            else
            {
               A87UsuarioFechaRegistro = context.localUtil.CToD( cgiGet( edtUsuarioFechaRegistro_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               n87UsuarioFechaRegistro = false;
               AssignAttri("", false, "A87UsuarioFechaRegistro", context.localUtil.Format(A87UsuarioFechaRegistro, "99/99/99"));
            }
            n87UsuarioFechaRegistro = ((DateTime.MinValue==A87UsuarioFechaRegistro) ? true : false);
            A92UsuarioAvisoPrivacidad = StringUtil.StrToBool( cgiGet( chkUsuarioAvisoPrivacidad_Internalname));
            AssignAttri("", false, "A92UsuarioAvisoPrivacidad", A92UsuarioAvisoPrivacidad);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A29UsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "UsuarioID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0A18( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes0A18( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption0A0( )
      {
      }

      protected void ZM0A18( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z30UsuarioNombre = T000A3_A30UsuarioNombre[0];
               Z51UsuarioApellido = T000A3_A51UsuarioApellido[0];
               Z31UsuarioCorreo = T000A3_A31UsuarioCorreo[0];
               Z32UsuarioPass = T000A3_A32UsuarioPass[0];
               Z33UsuarioKey = T000A3_A33UsuarioKey[0];
               Z53UsuarioGenero = T000A3_A53UsuarioGenero[0];
               Z54UsuarioDirectoAsociado = T000A3_A54UsuarioDirectoAsociado[0];
               Z55UsuarioRazonSocialAsociado = T000A3_A55UsuarioRazonSocialAsociado[0];
               Z56UsuarioNombreComercial = T000A3_A56UsuarioNombreComercial[0];
               Z57UsuarioFechaNacimiento = T000A3_A57UsuarioFechaNacimiento[0];
               Z59UsuarioCalleNum = T000A3_A59UsuarioCalleNum[0];
               Z60UsuarioColonia = T000A3_A60UsuarioColonia[0];
               Z61UsuarioDelegacion = T000A3_A61UsuarioDelegacion[0];
               Z62UsuarioCP = T000A3_A62UsuarioCP[0];
               Z63UsuarioZona = T000A3_A63UsuarioZona[0];
               Z64UsuarioCelular = T000A3_A64UsuarioCelular[0];
               Z65UsuarioTelefonoSucursal = T000A3_A65UsuarioTelefonoSucursal[0];
               Z66UsuarioSucursal = T000A3_A66UsuarioSucursal[0];
               Z67UsuarioProducto = T000A3_A67UsuarioProducto[0];
               Z40UsuarioRol = T000A3_A40UsuarioRol[0];
               Z82UsuarioNoCuentaBROXEL = T000A3_A82UsuarioNoCuentaBROXEL[0];
               Z83UsuarioReferenciaBROXEL = T000A3_A83UsuarioReferenciaBROXEL[0];
               Z87UsuarioFechaRegistro = T000A3_A87UsuarioFechaRegistro[0];
               Z92UsuarioAvisoPrivacidad = T000A3_A92UsuarioAvisoPrivacidad[0];
               Z13PuestoID = T000A3_A13PuestoID[0];
               Z4CiudadID = T000A3_A4CiudadID[0];
            }
            else
            {
               Z30UsuarioNombre = A30UsuarioNombre;
               Z51UsuarioApellido = A51UsuarioApellido;
               Z31UsuarioCorreo = A31UsuarioCorreo;
               Z32UsuarioPass = A32UsuarioPass;
               Z33UsuarioKey = A33UsuarioKey;
               Z53UsuarioGenero = A53UsuarioGenero;
               Z54UsuarioDirectoAsociado = A54UsuarioDirectoAsociado;
               Z55UsuarioRazonSocialAsociado = A55UsuarioRazonSocialAsociado;
               Z56UsuarioNombreComercial = A56UsuarioNombreComercial;
               Z57UsuarioFechaNacimiento = A57UsuarioFechaNacimiento;
               Z59UsuarioCalleNum = A59UsuarioCalleNum;
               Z60UsuarioColonia = A60UsuarioColonia;
               Z61UsuarioDelegacion = A61UsuarioDelegacion;
               Z62UsuarioCP = A62UsuarioCP;
               Z63UsuarioZona = A63UsuarioZona;
               Z64UsuarioCelular = A64UsuarioCelular;
               Z65UsuarioTelefonoSucursal = A65UsuarioTelefonoSucursal;
               Z66UsuarioSucursal = A66UsuarioSucursal;
               Z67UsuarioProducto = A67UsuarioProducto;
               Z40UsuarioRol = A40UsuarioRol;
               Z82UsuarioNoCuentaBROXEL = A82UsuarioNoCuentaBROXEL;
               Z83UsuarioReferenciaBROXEL = A83UsuarioReferenciaBROXEL;
               Z87UsuarioFechaRegistro = A87UsuarioFechaRegistro;
               Z92UsuarioAvisoPrivacidad = A92UsuarioAvisoPrivacidad;
               Z13PuestoID = A13PuestoID;
               Z4CiudadID = A4CiudadID;
            }
         }
         if ( GX_JID == -11 )
         {
            Z29UsuarioID = A29UsuarioID;
            Z30UsuarioNombre = A30UsuarioNombre;
            Z51UsuarioApellido = A51UsuarioApellido;
            Z31UsuarioCorreo = A31UsuarioCorreo;
            Z32UsuarioPass = A32UsuarioPass;
            Z33UsuarioKey = A33UsuarioKey;
            Z53UsuarioGenero = A53UsuarioGenero;
            Z54UsuarioDirectoAsociado = A54UsuarioDirectoAsociado;
            Z55UsuarioRazonSocialAsociado = A55UsuarioRazonSocialAsociado;
            Z56UsuarioNombreComercial = A56UsuarioNombreComercial;
            Z57UsuarioFechaNacimiento = A57UsuarioFechaNacimiento;
            Z59UsuarioCalleNum = A59UsuarioCalleNum;
            Z60UsuarioColonia = A60UsuarioColonia;
            Z61UsuarioDelegacion = A61UsuarioDelegacion;
            Z62UsuarioCP = A62UsuarioCP;
            Z63UsuarioZona = A63UsuarioZona;
            Z64UsuarioCelular = A64UsuarioCelular;
            Z65UsuarioTelefonoSucursal = A65UsuarioTelefonoSucursal;
            Z66UsuarioSucursal = A66UsuarioSucursal;
            Z67UsuarioProducto = A67UsuarioProducto;
            Z40UsuarioRol = A40UsuarioRol;
            Z82UsuarioNoCuentaBROXEL = A82UsuarioNoCuentaBROXEL;
            Z83UsuarioReferenciaBROXEL = A83UsuarioReferenciaBROXEL;
            Z87UsuarioFechaRegistro = A87UsuarioFechaRegistro;
            Z92UsuarioAvisoPrivacidad = A92UsuarioAvisoPrivacidad;
            Z13PuestoID = A13PuestoID;
            Z4CiudadID = A4CiudadID;
            Z14PuestoDescripcion = A14PuestoDescripcion;
            Z5CiudadDescripcion = A5CiudadDescripcion;
            Z1EstadoID = A1EstadoID;
            Z2EstadoDescripcion = A2EstadoDescripcion;
            Z16PaisID = A16PaisID;
            Z17PaisDescripcion = A17PaisDescripcion;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A92UsuarioAvisoPrivacidad) && ( Gx_BScreen == 0 ) )
         {
            A92UsuarioAvisoPrivacidad = false;
            AssignAttri("", false, "A92UsuarioAvisoPrivacidad", A92UsuarioAvisoPrivacidad);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0A18( )
      {
         /* Using cursor T000A8 */
         pr_default.execute(6, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound18 = 1;
            A30UsuarioNombre = T000A8_A30UsuarioNombre[0];
            AssignAttri("", false, "A30UsuarioNombre", A30UsuarioNombre);
            A51UsuarioApellido = T000A8_A51UsuarioApellido[0];
            AssignAttri("", false, "A51UsuarioApellido", A51UsuarioApellido);
            A31UsuarioCorreo = T000A8_A31UsuarioCorreo[0];
            AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
            A32UsuarioPass = T000A8_A32UsuarioPass[0];
            AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
            A33UsuarioKey = T000A8_A33UsuarioKey[0];
            AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
            A14PuestoDescripcion = T000A8_A14PuestoDescripcion[0];
            AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
            A53UsuarioGenero = T000A8_A53UsuarioGenero[0];
            AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
            A54UsuarioDirectoAsociado = T000A8_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = T000A8_n54UsuarioDirectoAsociado[0];
            AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
            A55UsuarioRazonSocialAsociado = T000A8_A55UsuarioRazonSocialAsociado[0];
            AssignAttri("", false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
            A56UsuarioNombreComercial = T000A8_A56UsuarioNombreComercial[0];
            AssignAttri("", false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
            A57UsuarioFechaNacimiento = T000A8_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = T000A8_n57UsuarioFechaNacimiento[0];
            AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
            A59UsuarioCalleNum = T000A8_A59UsuarioCalleNum[0];
            AssignAttri("", false, "A59UsuarioCalleNum", A59UsuarioCalleNum);
            A60UsuarioColonia = T000A8_A60UsuarioColonia[0];
            AssignAttri("", false, "A60UsuarioColonia", A60UsuarioColonia);
            A61UsuarioDelegacion = T000A8_A61UsuarioDelegacion[0];
            AssignAttri("", false, "A61UsuarioDelegacion", A61UsuarioDelegacion);
            A62UsuarioCP = T000A8_A62UsuarioCP[0];
            AssignAttri("", false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
            A63UsuarioZona = T000A8_A63UsuarioZona[0];
            AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
            A64UsuarioCelular = T000A8_A64UsuarioCelular[0];
            AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
            A65UsuarioTelefonoSucursal = T000A8_A65UsuarioTelefonoSucursal[0];
            AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
            A17PaisDescripcion = T000A8_A17PaisDescripcion[0];
            AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
            A2EstadoDescripcion = T000A8_A2EstadoDescripcion[0];
            AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
            A5CiudadDescripcion = T000A8_A5CiudadDescripcion[0];
            AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
            A66UsuarioSucursal = T000A8_A66UsuarioSucursal[0];
            AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
            A67UsuarioProducto = T000A8_A67UsuarioProducto[0];
            n67UsuarioProducto = T000A8_n67UsuarioProducto[0];
            AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
            A40UsuarioRol = T000A8_A40UsuarioRol[0];
            AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
            A82UsuarioNoCuentaBROXEL = T000A8_A82UsuarioNoCuentaBROXEL[0];
            AssignAttri("", false, "A82UsuarioNoCuentaBROXEL", A82UsuarioNoCuentaBROXEL);
            A83UsuarioReferenciaBROXEL = T000A8_A83UsuarioReferenciaBROXEL[0];
            AssignAttri("", false, "A83UsuarioReferenciaBROXEL", A83UsuarioReferenciaBROXEL);
            A87UsuarioFechaRegistro = T000A8_A87UsuarioFechaRegistro[0];
            n87UsuarioFechaRegistro = T000A8_n87UsuarioFechaRegistro[0];
            AssignAttri("", false, "A87UsuarioFechaRegistro", context.localUtil.Format(A87UsuarioFechaRegistro, "99/99/99"));
            A92UsuarioAvisoPrivacidad = T000A8_A92UsuarioAvisoPrivacidad[0];
            AssignAttri("", false, "A92UsuarioAvisoPrivacidad", A92UsuarioAvisoPrivacidad);
            A13PuestoID = T000A8_A13PuestoID[0];
            n13PuestoID = T000A8_n13PuestoID[0];
            AssignAttri("", false, "A13PuestoID", StringUtil.LTrimStr( (decimal)(A13PuestoID), 9, 0));
            A4CiudadID = T000A8_A4CiudadID[0];
            n4CiudadID = T000A8_n4CiudadID[0];
            AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
            A1EstadoID = T000A8_A1EstadoID[0];
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            A16PaisID = T000A8_A16PaisID[0];
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            ZM0A18( -11) ;
         }
         pr_default.close(6);
         OnLoadActions0A18( ) ;
      }

      protected void OnLoadActions0A18( )
      {
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
      }

      protected void CheckExtendedTable0A18( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
         if ( ! ( GxRegex.IsMatch(A31UsuarioCorreo,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Correo", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "USUARIOCORREO");
            AnyError = 1;
            GX_FocusControl = edtUsuarioCorreo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000A4 */
         pr_default.execute(2, new Object[] {n13PuestoID, A13PuestoID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A13PuestoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Puesto", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PUESTOID");
               AnyError = 1;
               GX_FocusControl = edtPuestoID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A14PuestoDescripcion = T000A4_A14PuestoDescripcion[0];
         AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A53UsuarioGenero, "Masculino") == 0 ) || ( StringUtil.StrCmp(A53UsuarioGenero, "Femenino") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Género", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "USUARIOGENERO");
            AnyError = 1;
            GX_FocusControl = cmbUsuarioGenero_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A54UsuarioDirectoAsociado, "Directo") == 0 ) || ( StringUtil.StrCmp(A54UsuarioDirectoAsociado, "Asociado") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A54UsuarioDirectoAsociado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Directo/Asociado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "USUARIODIRECTOASOCIADO");
            AnyError = 1;
            GX_FocusControl = cmbUsuarioDirectoAsociado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A57UsuarioFechaNacimiento) || ( DateTimeUtil.ResetTime ( A57UsuarioFechaNacimiento ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1000, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha de nacimiento", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "USUARIOFECHANACIMIENTO");
            AnyError = 1;
            GX_FocusControl = edtUsuarioFechaNacimiento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A63UsuarioZona, "Centro") == 0 ) || ( StringUtil.StrCmp(A63UsuarioZona, "Centro América") == 0 ) || ( StringUtil.StrCmp(A63UsuarioZona, "Norte") == 0 ) || ( StringUtil.StrCmp(A63UsuarioZona, "Pacífico") == 0 ) || ( StringUtil.StrCmp(A63UsuarioZona, "Sur") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Usuario Zona", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "USUARIOZONA");
            AnyError = 1;
            GX_FocusControl = cmbUsuarioZona_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000A5 */
         pr_default.execute(3, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
               GX_FocusControl = edtCiudadID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A5CiudadDescripcion = T000A5_A5CiudadDescripcion[0];
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         A1EstadoID = T000A5_A1EstadoID[0];
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
         pr_default.close(3);
         /* Using cursor T000A6 */
         pr_default.execute(4, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A2EstadoDescripcion = T000A6_A2EstadoDescripcion[0];
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         A16PaisID = T000A6_A16PaisID[0];
         AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
         pr_default.close(4);
         /* Using cursor T000A7 */
         pr_default.execute(5, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = T000A7_A17PaisDescripcion[0];
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
         pr_default.close(5);
         if ( ! ( ( StringUtil.StrCmp(A67UsuarioProducto, "Auto y Camioneta") == 0 ) || ( StringUtil.StrCmp(A67UsuarioProducto, "Auto y Camioneta/Camión") == 0 ) || ( StringUtil.StrCmp(A67UsuarioProducto, "Camión") == 0 ) || ( StringUtil.StrCmp(A67UsuarioProducto, "Empleado") == 0 ) || ( StringUtil.StrCmp(A67UsuarioProducto, "OTR/Camión") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A67UsuarioProducto)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Producto que vendes", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "USUARIOPRODUCTO");
            AnyError = 1;
            GX_FocusControl = cmbUsuarioProducto_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A40UsuarioRol, "Super Administrador") == 0 ) || ( StringUtil.StrCmp(A40UsuarioRol, "Administrador Yokohama") == 0 ) || ( StringUtil.StrCmp(A40UsuarioRol, "Asesor") == 0 ) || ( StringUtil.StrCmp(A40UsuarioRol, "Participante") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Rol", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "USUARIOROL");
            AnyError = 1;
            GX_FocusControl = cmbUsuarioRol_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A87UsuarioFechaRegistro) || ( DateTimeUtil.ResetTime ( A87UsuarioFechaRegistro ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1000, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Usuario Fecha Registro", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "USUARIOFECHAREGISTRO");
            AnyError = 1;
            GX_FocusControl = edtUsuarioFechaRegistro_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0A18( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( int A13PuestoID )
      {
         /* Using cursor T000A9 */
         pr_default.execute(7, new Object[] {n13PuestoID, A13PuestoID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A13PuestoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Puesto", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PUESTOID");
               AnyError = 1;
               GX_FocusControl = edtPuestoID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A14PuestoDescripcion = T000A9_A14PuestoDescripcion[0];
         AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A14PuestoDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_13( int A4CiudadID )
      {
         /* Using cursor T000A10 */
         pr_default.execute(8, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
               GX_FocusControl = edtCiudadID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A5CiudadDescripcion = T000A10_A5CiudadDescripcion[0];
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         A1EstadoID = T000A10_A1EstadoID[0];
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A5CiudadDescripcion)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_14( int A1EstadoID )
      {
         /* Using cursor T000A11 */
         pr_default.execute(9, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A2EstadoDescripcion = T000A11_A2EstadoDescripcion[0];
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         A16PaisID = T000A11_A16PaisID[0];
         AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2EstadoDescripcion)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_15( int A16PaisID )
      {
         /* Using cursor T000A12 */
         pr_default.execute(10, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = T000A12_A17PaisDescripcion[0];
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A17PaisDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey0A18( )
      {
         /* Using cursor T000A13 */
         pr_default.execute(11, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A18( 11) ;
            RcdFound18 = 1;
            A29UsuarioID = T000A3_A29UsuarioID[0];
            AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
            A30UsuarioNombre = T000A3_A30UsuarioNombre[0];
            AssignAttri("", false, "A30UsuarioNombre", A30UsuarioNombre);
            A51UsuarioApellido = T000A3_A51UsuarioApellido[0];
            AssignAttri("", false, "A51UsuarioApellido", A51UsuarioApellido);
            A31UsuarioCorreo = T000A3_A31UsuarioCorreo[0];
            AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
            A32UsuarioPass = T000A3_A32UsuarioPass[0];
            AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
            A33UsuarioKey = T000A3_A33UsuarioKey[0];
            AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
            A53UsuarioGenero = T000A3_A53UsuarioGenero[0];
            AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
            A54UsuarioDirectoAsociado = T000A3_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = T000A3_n54UsuarioDirectoAsociado[0];
            AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
            A55UsuarioRazonSocialAsociado = T000A3_A55UsuarioRazonSocialAsociado[0];
            AssignAttri("", false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
            A56UsuarioNombreComercial = T000A3_A56UsuarioNombreComercial[0];
            AssignAttri("", false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
            A57UsuarioFechaNacimiento = T000A3_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = T000A3_n57UsuarioFechaNacimiento[0];
            AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
            A59UsuarioCalleNum = T000A3_A59UsuarioCalleNum[0];
            AssignAttri("", false, "A59UsuarioCalleNum", A59UsuarioCalleNum);
            A60UsuarioColonia = T000A3_A60UsuarioColonia[0];
            AssignAttri("", false, "A60UsuarioColonia", A60UsuarioColonia);
            A61UsuarioDelegacion = T000A3_A61UsuarioDelegacion[0];
            AssignAttri("", false, "A61UsuarioDelegacion", A61UsuarioDelegacion);
            A62UsuarioCP = T000A3_A62UsuarioCP[0];
            AssignAttri("", false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
            A63UsuarioZona = T000A3_A63UsuarioZona[0];
            AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
            A64UsuarioCelular = T000A3_A64UsuarioCelular[0];
            AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
            A65UsuarioTelefonoSucursal = T000A3_A65UsuarioTelefonoSucursal[0];
            AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
            A66UsuarioSucursal = T000A3_A66UsuarioSucursal[0];
            AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
            A67UsuarioProducto = T000A3_A67UsuarioProducto[0];
            n67UsuarioProducto = T000A3_n67UsuarioProducto[0];
            AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
            A40UsuarioRol = T000A3_A40UsuarioRol[0];
            AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
            A82UsuarioNoCuentaBROXEL = T000A3_A82UsuarioNoCuentaBROXEL[0];
            AssignAttri("", false, "A82UsuarioNoCuentaBROXEL", A82UsuarioNoCuentaBROXEL);
            A83UsuarioReferenciaBROXEL = T000A3_A83UsuarioReferenciaBROXEL[0];
            AssignAttri("", false, "A83UsuarioReferenciaBROXEL", A83UsuarioReferenciaBROXEL);
            A87UsuarioFechaRegistro = T000A3_A87UsuarioFechaRegistro[0];
            n87UsuarioFechaRegistro = T000A3_n87UsuarioFechaRegistro[0];
            AssignAttri("", false, "A87UsuarioFechaRegistro", context.localUtil.Format(A87UsuarioFechaRegistro, "99/99/99"));
            A92UsuarioAvisoPrivacidad = T000A3_A92UsuarioAvisoPrivacidad[0];
            AssignAttri("", false, "A92UsuarioAvisoPrivacidad", A92UsuarioAvisoPrivacidad);
            A13PuestoID = T000A3_A13PuestoID[0];
            n13PuestoID = T000A3_n13PuestoID[0];
            AssignAttri("", false, "A13PuestoID", StringUtil.LTrimStr( (decimal)(A13PuestoID), 9, 0));
            A4CiudadID = T000A3_A4CiudadID[0];
            n4CiudadID = T000A3_n4CiudadID[0];
            AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
            Z29UsuarioID = A29UsuarioID;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0A18( ) ;
            if ( AnyError == 1 )
            {
               RcdFound18 = 0;
               InitializeNonKey0A18( ) ;
            }
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0A18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A18( ) ;
         if ( RcdFound18 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound18 = 0;
         /* Using cursor T000A14 */
         pr_default.execute(12, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000A14_A29UsuarioID[0] < A29UsuarioID ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000A14_A29UsuarioID[0] > A29UsuarioID ) ) )
            {
               A29UsuarioID = T000A14_A29UsuarioID[0];
               AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
               RcdFound18 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound18 = 0;
         /* Using cursor T000A15 */
         pr_default.execute(13, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000A15_A29UsuarioID[0] > A29UsuarioID ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000A15_A29UsuarioID[0] < A29UsuarioID ) ) )
            {
               A29UsuarioID = T000A15_A29UsuarioID[0];
               AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
               RcdFound18 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0A18( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuarioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0A18( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound18 == 1 )
            {
               if ( A29UsuarioID != Z29UsuarioID )
               {
                  A29UsuarioID = Z29UsuarioID;
                  AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "USUARIOID");
                  AnyError = 1;
                  GX_FocusControl = edtUsuarioID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUsuarioID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0A18( ) ;
                  GX_FocusControl = edtUsuarioID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A29UsuarioID != Z29UsuarioID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUsuarioID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0A18( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "USUARIOID");
                     AnyError = 1;
                     GX_FocusControl = edtUsuarioID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtUsuarioID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0A18( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A29UsuarioID != Z29UsuarioID )
         {
            A29UsuarioID = Z29UsuarioID;
            AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUsuarioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtUsuarioNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0A18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A18( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0A18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound18 != 0 )
            {
               ScanNext0A18( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A18( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0A18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A2 */
            pr_default.execute(0, new Object[] {A29UsuarioID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuario"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z30UsuarioNombre, T000A2_A30UsuarioNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z51UsuarioApellido, T000A2_A51UsuarioApellido[0]) != 0 ) || ( StringUtil.StrCmp(Z31UsuarioCorreo, T000A2_A31UsuarioCorreo[0]) != 0 ) || ( StringUtil.StrCmp(Z32UsuarioPass, T000A2_A32UsuarioPass[0]) != 0 ) || ( StringUtil.StrCmp(Z33UsuarioKey, T000A2_A33UsuarioKey[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z53UsuarioGenero, T000A2_A53UsuarioGenero[0]) != 0 ) || ( StringUtil.StrCmp(Z54UsuarioDirectoAsociado, T000A2_A54UsuarioDirectoAsociado[0]) != 0 ) || ( StringUtil.StrCmp(Z55UsuarioRazonSocialAsociado, T000A2_A55UsuarioRazonSocialAsociado[0]) != 0 ) || ( StringUtil.StrCmp(Z56UsuarioNombreComercial, T000A2_A56UsuarioNombreComercial[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z57UsuarioFechaNacimiento ) != DateTimeUtil.ResetTime ( T000A2_A57UsuarioFechaNacimiento[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z59UsuarioCalleNum, T000A2_A59UsuarioCalleNum[0]) != 0 ) || ( StringUtil.StrCmp(Z60UsuarioColonia, T000A2_A60UsuarioColonia[0]) != 0 ) || ( StringUtil.StrCmp(Z61UsuarioDelegacion, T000A2_A61UsuarioDelegacion[0]) != 0 ) || ( Z62UsuarioCP != T000A2_A62UsuarioCP[0] ) || ( StringUtil.StrCmp(Z63UsuarioZona, T000A2_A63UsuarioZona[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z64UsuarioCelular != T000A2_A64UsuarioCelular[0] ) || ( Z65UsuarioTelefonoSucursal != T000A2_A65UsuarioTelefonoSucursal[0] ) || ( StringUtil.StrCmp(Z66UsuarioSucursal, T000A2_A66UsuarioSucursal[0]) != 0 ) || ( StringUtil.StrCmp(Z67UsuarioProducto, T000A2_A67UsuarioProducto[0]) != 0 ) || ( StringUtil.StrCmp(Z40UsuarioRol, T000A2_A40UsuarioRol[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z82UsuarioNoCuentaBROXEL, T000A2_A82UsuarioNoCuentaBROXEL[0]) != 0 ) || ( StringUtil.StrCmp(Z83UsuarioReferenciaBROXEL, T000A2_A83UsuarioReferenciaBROXEL[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z87UsuarioFechaRegistro ) != DateTimeUtil.ResetTime ( T000A2_A87UsuarioFechaRegistro[0] ) ) || ( Z92UsuarioAvisoPrivacidad != T000A2_A92UsuarioAvisoPrivacidad[0] ) || ( Z13PuestoID != T000A2_A13PuestoID[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z4CiudadID != T000A2_A4CiudadID[0] ) )
            {
               if ( StringUtil.StrCmp(Z30UsuarioNombre, T000A2_A30UsuarioNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioNombre");
                  GXUtil.WriteLogRaw("Old: ",Z30UsuarioNombre);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A30UsuarioNombre[0]);
               }
               if ( StringUtil.StrCmp(Z51UsuarioApellido, T000A2_A51UsuarioApellido[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioApellido");
                  GXUtil.WriteLogRaw("Old: ",Z51UsuarioApellido);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A51UsuarioApellido[0]);
               }
               if ( StringUtil.StrCmp(Z31UsuarioCorreo, T000A2_A31UsuarioCorreo[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioCorreo");
                  GXUtil.WriteLogRaw("Old: ",Z31UsuarioCorreo);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A31UsuarioCorreo[0]);
               }
               if ( StringUtil.StrCmp(Z32UsuarioPass, T000A2_A32UsuarioPass[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioPass");
                  GXUtil.WriteLogRaw("Old: ",Z32UsuarioPass);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A32UsuarioPass[0]);
               }
               if ( StringUtil.StrCmp(Z33UsuarioKey, T000A2_A33UsuarioKey[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioKey");
                  GXUtil.WriteLogRaw("Old: ",Z33UsuarioKey);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A33UsuarioKey[0]);
               }
               if ( StringUtil.StrCmp(Z53UsuarioGenero, T000A2_A53UsuarioGenero[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioGenero");
                  GXUtil.WriteLogRaw("Old: ",Z53UsuarioGenero);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A53UsuarioGenero[0]);
               }
               if ( StringUtil.StrCmp(Z54UsuarioDirectoAsociado, T000A2_A54UsuarioDirectoAsociado[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioDirectoAsociado");
                  GXUtil.WriteLogRaw("Old: ",Z54UsuarioDirectoAsociado);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A54UsuarioDirectoAsociado[0]);
               }
               if ( StringUtil.StrCmp(Z55UsuarioRazonSocialAsociado, T000A2_A55UsuarioRazonSocialAsociado[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioRazonSocialAsociado");
                  GXUtil.WriteLogRaw("Old: ",Z55UsuarioRazonSocialAsociado);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A55UsuarioRazonSocialAsociado[0]);
               }
               if ( StringUtil.StrCmp(Z56UsuarioNombreComercial, T000A2_A56UsuarioNombreComercial[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioNombreComercial");
                  GXUtil.WriteLogRaw("Old: ",Z56UsuarioNombreComercial);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A56UsuarioNombreComercial[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z57UsuarioFechaNacimiento ) != DateTimeUtil.ResetTime ( T000A2_A57UsuarioFechaNacimiento[0] ) )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioFechaNacimiento");
                  GXUtil.WriteLogRaw("Old: ",Z57UsuarioFechaNacimiento);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A57UsuarioFechaNacimiento[0]);
               }
               if ( StringUtil.StrCmp(Z59UsuarioCalleNum, T000A2_A59UsuarioCalleNum[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioCalleNum");
                  GXUtil.WriteLogRaw("Old: ",Z59UsuarioCalleNum);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A59UsuarioCalleNum[0]);
               }
               if ( StringUtil.StrCmp(Z60UsuarioColonia, T000A2_A60UsuarioColonia[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioColonia");
                  GXUtil.WriteLogRaw("Old: ",Z60UsuarioColonia);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A60UsuarioColonia[0]);
               }
               if ( StringUtil.StrCmp(Z61UsuarioDelegacion, T000A2_A61UsuarioDelegacion[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioDelegacion");
                  GXUtil.WriteLogRaw("Old: ",Z61UsuarioDelegacion);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A61UsuarioDelegacion[0]);
               }
               if ( Z62UsuarioCP != T000A2_A62UsuarioCP[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioCP");
                  GXUtil.WriteLogRaw("Old: ",Z62UsuarioCP);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A62UsuarioCP[0]);
               }
               if ( StringUtil.StrCmp(Z63UsuarioZona, T000A2_A63UsuarioZona[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioZona");
                  GXUtil.WriteLogRaw("Old: ",Z63UsuarioZona);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A63UsuarioZona[0]);
               }
               if ( Z64UsuarioCelular != T000A2_A64UsuarioCelular[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioCelular");
                  GXUtil.WriteLogRaw("Old: ",Z64UsuarioCelular);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A64UsuarioCelular[0]);
               }
               if ( Z65UsuarioTelefonoSucursal != T000A2_A65UsuarioTelefonoSucursal[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioTelefonoSucursal");
                  GXUtil.WriteLogRaw("Old: ",Z65UsuarioTelefonoSucursal);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A65UsuarioTelefonoSucursal[0]);
               }
               if ( StringUtil.StrCmp(Z66UsuarioSucursal, T000A2_A66UsuarioSucursal[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioSucursal");
                  GXUtil.WriteLogRaw("Old: ",Z66UsuarioSucursal);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A66UsuarioSucursal[0]);
               }
               if ( StringUtil.StrCmp(Z67UsuarioProducto, T000A2_A67UsuarioProducto[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioProducto");
                  GXUtil.WriteLogRaw("Old: ",Z67UsuarioProducto);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A67UsuarioProducto[0]);
               }
               if ( StringUtil.StrCmp(Z40UsuarioRol, T000A2_A40UsuarioRol[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioRol");
                  GXUtil.WriteLogRaw("Old: ",Z40UsuarioRol);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A40UsuarioRol[0]);
               }
               if ( StringUtil.StrCmp(Z82UsuarioNoCuentaBROXEL, T000A2_A82UsuarioNoCuentaBROXEL[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioNoCuentaBROXEL");
                  GXUtil.WriteLogRaw("Old: ",Z82UsuarioNoCuentaBROXEL);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A82UsuarioNoCuentaBROXEL[0]);
               }
               if ( StringUtil.StrCmp(Z83UsuarioReferenciaBROXEL, T000A2_A83UsuarioReferenciaBROXEL[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioReferenciaBROXEL");
                  GXUtil.WriteLogRaw("Old: ",Z83UsuarioReferenciaBROXEL);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A83UsuarioReferenciaBROXEL[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z87UsuarioFechaRegistro ) != DateTimeUtil.ResetTime ( T000A2_A87UsuarioFechaRegistro[0] ) )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioFechaRegistro");
                  GXUtil.WriteLogRaw("Old: ",Z87UsuarioFechaRegistro);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A87UsuarioFechaRegistro[0]);
               }
               if ( Z92UsuarioAvisoPrivacidad != T000A2_A92UsuarioAvisoPrivacidad[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioAvisoPrivacidad");
                  GXUtil.WriteLogRaw("Old: ",Z92UsuarioAvisoPrivacidad);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A92UsuarioAvisoPrivacidad[0]);
               }
               if ( Z13PuestoID != T000A2_A13PuestoID[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"PuestoID");
                  GXUtil.WriteLogRaw("Old: ",Z13PuestoID);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A13PuestoID[0]);
               }
               if ( Z4CiudadID != T000A2_A4CiudadID[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"CiudadID");
                  GXUtil.WriteLogRaw("Old: ",Z4CiudadID);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A4CiudadID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Usuario"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A18( )
      {
         BeforeValidate0A18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A18( 0) ;
            CheckOptimisticConcurrency0A18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A16 */
                     pr_default.execute(14, new Object[] {A30UsuarioNombre, A51UsuarioApellido, A31UsuarioCorreo, A32UsuarioPass, A33UsuarioKey, A53UsuarioGenero, n54UsuarioDirectoAsociado, A54UsuarioDirectoAsociado, A55UsuarioRazonSocialAsociado, A56UsuarioNombreComercial, n57UsuarioFechaNacimiento, A57UsuarioFechaNacimiento, A59UsuarioCalleNum, A60UsuarioColonia, A61UsuarioDelegacion, A62UsuarioCP, A63UsuarioZona, A64UsuarioCelular, A65UsuarioTelefonoSucursal, A66UsuarioSucursal, n67UsuarioProducto, A67UsuarioProducto, A40UsuarioRol, A82UsuarioNoCuentaBROXEL, A83UsuarioReferenciaBROXEL, n87UsuarioFechaRegistro, A87UsuarioFechaRegistro, A92UsuarioAvisoPrivacidad, n13PuestoID, A13PuestoID, n4CiudadID, A4CiudadID});
                     pr_default.close(14);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000A17 */
                     pr_default.execute(15);
                     A29UsuarioID = T000A17_A29UsuarioID[0];
                     AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Usuario");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0A0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0A18( ) ;
            }
            EndLevel0A18( ) ;
         }
         CloseExtendedTableCursors0A18( ) ;
      }

      protected void Update0A18( )
      {
         BeforeValidate0A18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A18 */
                     pr_default.execute(16, new Object[] {A30UsuarioNombre, A51UsuarioApellido, A31UsuarioCorreo, A32UsuarioPass, A33UsuarioKey, A53UsuarioGenero, n54UsuarioDirectoAsociado, A54UsuarioDirectoAsociado, A55UsuarioRazonSocialAsociado, A56UsuarioNombreComercial, n57UsuarioFechaNacimiento, A57UsuarioFechaNacimiento, A59UsuarioCalleNum, A60UsuarioColonia, A61UsuarioDelegacion, A62UsuarioCP, A63UsuarioZona, A64UsuarioCelular, A65UsuarioTelefonoSucursal, A66UsuarioSucursal, n67UsuarioProducto, A67UsuarioProducto, A40UsuarioRol, A82UsuarioNoCuentaBROXEL, A83UsuarioReferenciaBROXEL, n87UsuarioFechaRegistro, A87UsuarioFechaRegistro, A92UsuarioAvisoPrivacidad, n13PuestoID, A13PuestoID, n4CiudadID, A4CiudadID, A29UsuarioID});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Usuario");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuario"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A18( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0A0( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0A18( ) ;
         }
         CloseExtendedTableCursors0A18( ) ;
      }

      protected void DeferredUpdate0A18( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0A18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A18( ) ;
            AfterConfirm0A18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000A19 */
                  pr_default.execute(17, new Object[] {A29UsuarioID});
                  pr_default.close(17);
                  pr_default.SmartCacheProvider.SetUpdated("Usuario");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound18 == 0 )
                        {
                           InitAll0A18( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption0A0( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A18( ) ;
         Gx_mode = sMode18;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A18( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
            /* Using cursor T000A20 */
            pr_default.execute(18, new Object[] {n13PuestoID, A13PuestoID});
            A14PuestoDescripcion = T000A20_A14PuestoDescripcion[0];
            AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
            pr_default.close(18);
            /* Using cursor T000A21 */
            pr_default.execute(19, new Object[] {n4CiudadID, A4CiudadID});
            A5CiudadDescripcion = T000A21_A5CiudadDescripcion[0];
            AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
            A1EstadoID = T000A21_A1EstadoID[0];
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            pr_default.close(19);
            /* Using cursor T000A22 */
            pr_default.execute(20, new Object[] {A1EstadoID});
            A2EstadoDescripcion = T000A22_A2EstadoDescripcion[0];
            AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
            A16PaisID = T000A22_A16PaisID[0];
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            pr_default.close(20);
            /* Using cursor T000A23 */
            pr_default.execute(21, new Object[] {A16PaisID});
            A17PaisDescripcion = T000A23_A17PaisDescripcion[0];
            AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
            pr_default.close(21);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000A24 */
            pr_default.execute(22, new Object[] {A29UsuarioID});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Factura", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T000A25 */
            pr_default.execute(23, new Object[] {A29UsuarioID});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "DistribuidoresUsuario", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
         }
      }

      protected void EndLevel0A18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A18( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("usuario",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("usuario",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A18( )
      {
         /* Using cursor T000A26 */
         pr_default.execute(24);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound18 = 1;
            A29UsuarioID = T000A26_A29UsuarioID[0];
            AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A18( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound18 = 1;
            A29UsuarioID = T000A26_A29UsuarioID[0];
            AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
         }
      }

      protected void ScanEnd0A18( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm0A18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A18( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A18( )
      {
         edtUsuarioID_Enabled = 0;
         AssignProp("", false, edtUsuarioID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioID_Enabled), 5, 0), true);
         edtUsuarioNombre_Enabled = 0;
         AssignProp("", false, edtUsuarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Enabled), 5, 0), true);
         edtUsuarioApellido_Enabled = 0;
         AssignProp("", false, edtUsuarioApellido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioApellido_Enabled), 5, 0), true);
         edtUsuarioNombreCompleto_Enabled = 0;
         AssignProp("", false, edtUsuarioNombreCompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombreCompleto_Enabled), 5, 0), true);
         edtUsuarioCorreo_Enabled = 0;
         AssignProp("", false, edtUsuarioCorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioCorreo_Enabled), 5, 0), true);
         edtUsuarioPass_Enabled = 0;
         AssignProp("", false, edtUsuarioPass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioPass_Enabled), 5, 0), true);
         edtUsuarioKey_Enabled = 0;
         AssignProp("", false, edtUsuarioKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioKey_Enabled), 5, 0), true);
         edtPuestoID_Enabled = 0;
         AssignProp("", false, edtPuestoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPuestoID_Enabled), 5, 0), true);
         edtPuestoDescripcion_Enabled = 0;
         AssignProp("", false, edtPuestoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPuestoDescripcion_Enabled), 5, 0), true);
         cmbUsuarioGenero.Enabled = 0;
         AssignProp("", false, cmbUsuarioGenero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuarioGenero.Enabled), 5, 0), true);
         cmbUsuarioDirectoAsociado.Enabled = 0;
         AssignProp("", false, cmbUsuarioDirectoAsociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuarioDirectoAsociado.Enabled), 5, 0), true);
         edtUsuarioRazonSocialAsociado_Enabled = 0;
         AssignProp("", false, edtUsuarioRazonSocialAsociado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioRazonSocialAsociado_Enabled), 5, 0), true);
         edtUsuarioNombreComercial_Enabled = 0;
         AssignProp("", false, edtUsuarioNombreComercial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombreComercial_Enabled), 5, 0), true);
         edtUsuarioFechaNacimiento_Enabled = 0;
         AssignProp("", false, edtUsuarioFechaNacimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFechaNacimiento_Enabled), 5, 0), true);
         edtUsuarioCalleNum_Enabled = 0;
         AssignProp("", false, edtUsuarioCalleNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioCalleNum_Enabled), 5, 0), true);
         edtUsuarioColonia_Enabled = 0;
         AssignProp("", false, edtUsuarioColonia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioColonia_Enabled), 5, 0), true);
         edtUsuarioDelegacion_Enabled = 0;
         AssignProp("", false, edtUsuarioDelegacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioDelegacion_Enabled), 5, 0), true);
         edtUsuarioCP_Enabled = 0;
         AssignProp("", false, edtUsuarioCP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioCP_Enabled), 5, 0), true);
         cmbUsuarioZona.Enabled = 0;
         AssignProp("", false, cmbUsuarioZona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuarioZona.Enabled), 5, 0), true);
         edtUsuarioCelular_Enabled = 0;
         AssignProp("", false, edtUsuarioCelular_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioCelular_Enabled), 5, 0), true);
         edtUsuarioTelefonoSucursal_Enabled = 0;
         AssignProp("", false, edtUsuarioTelefonoSucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioTelefonoSucursal_Enabled), 5, 0), true);
         edtPaisID_Enabled = 0;
         AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         edtPaisDescripcion_Enabled = 0;
         AssignProp("", false, edtPaisDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisDescripcion_Enabled), 5, 0), true);
         edtEstadoID_Enabled = 0;
         AssignProp("", false, edtEstadoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoID_Enabled), 5, 0), true);
         edtEstadoDescripcion_Enabled = 0;
         AssignProp("", false, edtEstadoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoDescripcion_Enabled), 5, 0), true);
         edtCiudadID_Enabled = 0;
         AssignProp("", false, edtCiudadID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadID_Enabled), 5, 0), true);
         edtCiudadDescripcion_Enabled = 0;
         AssignProp("", false, edtCiudadDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadDescripcion_Enabled), 5, 0), true);
         edtUsuarioSucursal_Enabled = 0;
         AssignProp("", false, edtUsuarioSucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSucursal_Enabled), 5, 0), true);
         cmbUsuarioProducto.Enabled = 0;
         AssignProp("", false, cmbUsuarioProducto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuarioProducto.Enabled), 5, 0), true);
         cmbUsuarioRol.Enabled = 0;
         AssignProp("", false, cmbUsuarioRol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuarioRol.Enabled), 5, 0), true);
         edtUsuarioNoCuentaBROXEL_Enabled = 0;
         AssignProp("", false, edtUsuarioNoCuentaBROXEL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNoCuentaBROXEL_Enabled), 5, 0), true);
         edtUsuarioReferenciaBROXEL_Enabled = 0;
         AssignProp("", false, edtUsuarioReferenciaBROXEL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioReferenciaBROXEL_Enabled), 5, 0), true);
         edtUsuarioFechaRegistro_Enabled = 0;
         AssignProp("", false, edtUsuarioFechaRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFechaRegistro_Enabled), 5, 0), true);
         chkUsuarioAvisoPrivacidad.Enabled = 0;
         AssignProp("", false, chkUsuarioAvisoPrivacidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuarioAvisoPrivacidad.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0A18( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0A0( )
      {
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
         MasterPageObj.master_styles();
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("usuario.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z29UsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z30UsuarioNombre", StringUtil.RTrim( Z30UsuarioNombre));
         GxWebStd.gx_hidden_field( context, "Z51UsuarioApellido", StringUtil.RTrim( Z51UsuarioApellido));
         GxWebStd.gx_hidden_field( context, "Z31UsuarioCorreo", Z31UsuarioCorreo);
         GxWebStd.gx_hidden_field( context, "Z32UsuarioPass", Z32UsuarioPass);
         GxWebStd.gx_hidden_field( context, "Z33UsuarioKey", Z33UsuarioKey);
         GxWebStd.gx_hidden_field( context, "Z53UsuarioGenero", StringUtil.RTrim( Z53UsuarioGenero));
         GxWebStd.gx_hidden_field( context, "Z54UsuarioDirectoAsociado", StringUtil.RTrim( Z54UsuarioDirectoAsociado));
         GxWebStd.gx_hidden_field( context, "Z55UsuarioRazonSocialAsociado", Z55UsuarioRazonSocialAsociado);
         GxWebStd.gx_hidden_field( context, "Z56UsuarioNombreComercial", Z56UsuarioNombreComercial);
         GxWebStd.gx_hidden_field( context, "Z57UsuarioFechaNacimiento", context.localUtil.DToC( Z57UsuarioFechaNacimiento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z59UsuarioCalleNum", StringUtil.RTrim( Z59UsuarioCalleNum));
         GxWebStd.gx_hidden_field( context, "Z60UsuarioColonia", StringUtil.RTrim( Z60UsuarioColonia));
         GxWebStd.gx_hidden_field( context, "Z61UsuarioDelegacion", StringUtil.RTrim( Z61UsuarioDelegacion));
         GxWebStd.gx_hidden_field( context, "Z62UsuarioCP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z62UsuarioCP), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z63UsuarioZona", StringUtil.RTrim( Z63UsuarioZona));
         GxWebStd.gx_hidden_field( context, "Z64UsuarioCelular", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64UsuarioCelular), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z65UsuarioTelefonoSucursal", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z65UsuarioTelefonoSucursal), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z66UsuarioSucursal", StringUtil.RTrim( Z66UsuarioSucursal));
         GxWebStd.gx_hidden_field( context, "Z67UsuarioProducto", Z67UsuarioProducto);
         GxWebStd.gx_hidden_field( context, "Z40UsuarioRol", StringUtil.RTrim( Z40UsuarioRol));
         GxWebStd.gx_hidden_field( context, "Z82UsuarioNoCuentaBROXEL", StringUtil.RTrim( Z82UsuarioNoCuentaBROXEL));
         GxWebStd.gx_hidden_field( context, "Z83UsuarioReferenciaBROXEL", StringUtil.RTrim( Z83UsuarioReferenciaBROXEL));
         GxWebStd.gx_hidden_field( context, "Z87UsuarioFechaRegistro", context.localUtil.DToC( Z87UsuarioFechaRegistro, 0, "/"));
         GxWebStd.gx_boolean_hidden_field( context, "Z92UsuarioAvisoPrivacidad", Z92UsuarioAvisoPrivacidad);
         GxWebStd.gx_hidden_field( context, "Z13PuestoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13PuestoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z4CiudadID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4CiudadID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("usuario.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Usuario" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Usuario", "") ;
      }

      protected void InitializeNonKey0A18( )
      {
         A52UsuarioNombreCompleto = "";
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
         A30UsuarioNombre = "";
         AssignAttri("", false, "A30UsuarioNombre", A30UsuarioNombre);
         A51UsuarioApellido = "";
         AssignAttri("", false, "A51UsuarioApellido", A51UsuarioApellido);
         A31UsuarioCorreo = "";
         AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
         A32UsuarioPass = "";
         AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
         A33UsuarioKey = "";
         AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
         A13PuestoID = 0;
         n13PuestoID = false;
         AssignAttri("", false, "A13PuestoID", StringUtil.LTrimStr( (decimal)(A13PuestoID), 9, 0));
         n13PuestoID = ((0==A13PuestoID) ? true : false);
         A14PuestoDescripcion = "";
         AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
         A53UsuarioGenero = "";
         AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
         A54UsuarioDirectoAsociado = "";
         n54UsuarioDirectoAsociado = false;
         AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
         n54UsuarioDirectoAsociado = (String.IsNullOrEmpty(StringUtil.RTrim( A54UsuarioDirectoAsociado)) ? true : false);
         A55UsuarioRazonSocialAsociado = "";
         AssignAttri("", false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
         A56UsuarioNombreComercial = "";
         AssignAttri("", false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
         A57UsuarioFechaNacimiento = DateTime.MinValue;
         n57UsuarioFechaNacimiento = false;
         AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
         n57UsuarioFechaNacimiento = ((DateTime.MinValue==A57UsuarioFechaNacimiento) ? true : false);
         A59UsuarioCalleNum = "";
         AssignAttri("", false, "A59UsuarioCalleNum", A59UsuarioCalleNum);
         A60UsuarioColonia = "";
         AssignAttri("", false, "A60UsuarioColonia", A60UsuarioColonia);
         A61UsuarioDelegacion = "";
         AssignAttri("", false, "A61UsuarioDelegacion", A61UsuarioDelegacion);
         A62UsuarioCP = 0;
         AssignAttri("", false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
         A63UsuarioZona = "";
         AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
         A64UsuarioCelular = 0;
         AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
         A65UsuarioTelefonoSucursal = 0;
         AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
         A16PaisID = 0;
         AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
         A17PaisDescripcion = "";
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
         A1EstadoID = 0;
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
         A2EstadoDescripcion = "";
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         A4CiudadID = 0;
         n4CiudadID = false;
         AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
         n4CiudadID = ((0==A4CiudadID) ? true : false);
         A5CiudadDescripcion = "";
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         A66UsuarioSucursal = "";
         AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
         A67UsuarioProducto = "";
         n67UsuarioProducto = false;
         AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
         n67UsuarioProducto = (String.IsNullOrEmpty(StringUtil.RTrim( A67UsuarioProducto)) ? true : false);
         A40UsuarioRol = "";
         AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
         A82UsuarioNoCuentaBROXEL = "";
         AssignAttri("", false, "A82UsuarioNoCuentaBROXEL", A82UsuarioNoCuentaBROXEL);
         A83UsuarioReferenciaBROXEL = "";
         AssignAttri("", false, "A83UsuarioReferenciaBROXEL", A83UsuarioReferenciaBROXEL);
         A87UsuarioFechaRegistro = DateTime.MinValue;
         n87UsuarioFechaRegistro = false;
         AssignAttri("", false, "A87UsuarioFechaRegistro", context.localUtil.Format(A87UsuarioFechaRegistro, "99/99/99"));
         n87UsuarioFechaRegistro = ((DateTime.MinValue==A87UsuarioFechaRegistro) ? true : false);
         A92UsuarioAvisoPrivacidad = false;
         AssignAttri("", false, "A92UsuarioAvisoPrivacidad", A92UsuarioAvisoPrivacidad);
         Z30UsuarioNombre = "";
         Z51UsuarioApellido = "";
         Z31UsuarioCorreo = "";
         Z32UsuarioPass = "";
         Z33UsuarioKey = "";
         Z53UsuarioGenero = "";
         Z54UsuarioDirectoAsociado = "";
         Z55UsuarioRazonSocialAsociado = "";
         Z56UsuarioNombreComercial = "";
         Z57UsuarioFechaNacimiento = DateTime.MinValue;
         Z59UsuarioCalleNum = "";
         Z60UsuarioColonia = "";
         Z61UsuarioDelegacion = "";
         Z62UsuarioCP = 0;
         Z63UsuarioZona = "";
         Z64UsuarioCelular = 0;
         Z65UsuarioTelefonoSucursal = 0;
         Z66UsuarioSucursal = "";
         Z67UsuarioProducto = "";
         Z40UsuarioRol = "";
         Z82UsuarioNoCuentaBROXEL = "";
         Z83UsuarioReferenciaBROXEL = "";
         Z87UsuarioFechaRegistro = DateTime.MinValue;
         Z92UsuarioAvisoPrivacidad = false;
         Z13PuestoID = 0;
         Z4CiudadID = 0;
      }

      protected void InitAll0A18( )
      {
         A29UsuarioID = 0;
         AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
         InitializeNonKey0A18( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A92UsuarioAvisoPrivacidad = i92UsuarioAvisoPrivacidad;
         AssignAttri("", false, "A92UsuarioAvisoPrivacidad", A92UsuarioAvisoPrivacidad);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202651111305648", true, true);
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
         context.AddJavascriptSource("usuario.js", "?202651111305648", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtUsuarioID_Internalname = "USUARIOID";
         edtUsuarioNombre_Internalname = "USUARIONOMBRE";
         edtUsuarioApellido_Internalname = "USUARIOAPELLIDO";
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO";
         edtUsuarioCorreo_Internalname = "USUARIOCORREO";
         edtUsuarioPass_Internalname = "USUARIOPASS";
         edtUsuarioKey_Internalname = "USUARIOKEY";
         edtPuestoID_Internalname = "PUESTOID";
         edtPuestoDescripcion_Internalname = "PUESTODESCRIPCION";
         cmbUsuarioGenero_Internalname = "USUARIOGENERO";
         cmbUsuarioDirectoAsociado_Internalname = "USUARIODIRECTOASOCIADO";
         edtUsuarioRazonSocialAsociado_Internalname = "USUARIORAZONSOCIALASOCIADO";
         edtUsuarioNombreComercial_Internalname = "USUARIONOMBRECOMERCIAL";
         edtUsuarioFechaNacimiento_Internalname = "USUARIOFECHANACIMIENTO";
         edtUsuarioCalleNum_Internalname = "USUARIOCALLENUM";
         edtUsuarioColonia_Internalname = "USUARIOCOLONIA";
         edtUsuarioDelegacion_Internalname = "USUARIODELEGACION";
         edtUsuarioCP_Internalname = "USUARIOCP";
         cmbUsuarioZona_Internalname = "USUARIOZONA";
         edtUsuarioCelular_Internalname = "USUARIOCELULAR";
         edtUsuarioTelefonoSucursal_Internalname = "USUARIOTELEFONOSUCURSAL";
         edtPaisID_Internalname = "PAISID";
         edtPaisDescripcion_Internalname = "PAISDESCRIPCION";
         edtEstadoID_Internalname = "ESTADOID";
         edtEstadoDescripcion_Internalname = "ESTADODESCRIPCION";
         edtCiudadID_Internalname = "CIUDADID";
         edtCiudadDescripcion_Internalname = "CIUDADDESCRIPCION";
         edtUsuarioSucursal_Internalname = "USUARIOSUCURSAL";
         cmbUsuarioProducto_Internalname = "USUARIOPRODUCTO";
         cmbUsuarioRol_Internalname = "USUARIOROL";
         edtUsuarioNoCuentaBROXEL_Internalname = "USUARIONOCUENTABROXEL";
         edtUsuarioReferenciaBROXEL_Internalname = "USUARIOREFERENCIABROXEL";
         edtUsuarioFechaRegistro_Internalname = "USUARIOFECHAREGISTRO";
         chkUsuarioAvisoPrivacidad_Internalname = "USUARIOAVISOPRIVACIDAD";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Usuario", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkUsuarioAvisoPrivacidad.Enabled = 1;
         edtUsuarioFechaRegistro_Jsonclick = "";
         edtUsuarioFechaRegistro_Enabled = 1;
         edtUsuarioReferenciaBROXEL_Jsonclick = "";
         edtUsuarioReferenciaBROXEL_Enabled = 1;
         edtUsuarioNoCuentaBROXEL_Jsonclick = "";
         edtUsuarioNoCuentaBROXEL_Enabled = 1;
         cmbUsuarioRol_Jsonclick = "";
         cmbUsuarioRol.Enabled = 1;
         cmbUsuarioProducto_Jsonclick = "";
         cmbUsuarioProducto.Enabled = 1;
         edtUsuarioSucursal_Jsonclick = "";
         edtUsuarioSucursal_Enabled = 1;
         edtCiudadDescripcion_Jsonclick = "";
         edtCiudadDescripcion_Enabled = 0;
         edtCiudadID_Jsonclick = "";
         edtCiudadID_Enabled = 1;
         edtEstadoDescripcion_Jsonclick = "";
         edtEstadoDescripcion_Enabled = 0;
         edtEstadoID_Jsonclick = "";
         edtEstadoID_Enabled = 0;
         edtPaisDescripcion_Jsonclick = "";
         edtPaisDescripcion_Enabled = 0;
         edtPaisID_Jsonclick = "";
         edtPaisID_Enabled = 0;
         edtUsuarioTelefonoSucursal_Jsonclick = "";
         edtUsuarioTelefonoSucursal_Enabled = 1;
         edtUsuarioCelular_Jsonclick = "";
         edtUsuarioCelular_Enabled = 1;
         cmbUsuarioZona_Jsonclick = "";
         cmbUsuarioZona.Enabled = 1;
         edtUsuarioCP_Jsonclick = "";
         edtUsuarioCP_Enabled = 1;
         edtUsuarioDelegacion_Jsonclick = "";
         edtUsuarioDelegacion_Enabled = 1;
         edtUsuarioColonia_Jsonclick = "";
         edtUsuarioColonia_Enabled = 1;
         edtUsuarioCalleNum_Jsonclick = "";
         edtUsuarioCalleNum_Enabled = 1;
         edtUsuarioFechaNacimiento_Jsonclick = "";
         edtUsuarioFechaNacimiento_Enabled = 1;
         edtUsuarioNombreComercial_Jsonclick = "";
         edtUsuarioNombreComercial_Enabled = 1;
         edtUsuarioRazonSocialAsociado_Jsonclick = "";
         edtUsuarioRazonSocialAsociado_Enabled = 1;
         cmbUsuarioDirectoAsociado_Jsonclick = "";
         cmbUsuarioDirectoAsociado.Enabled = 1;
         cmbUsuarioGenero_Jsonclick = "";
         cmbUsuarioGenero.Enabled = 1;
         edtPuestoDescripcion_Jsonclick = "";
         edtPuestoDescripcion_Enabled = 0;
         edtPuestoID_Jsonclick = "";
         edtPuestoID_Enabled = 1;
         edtUsuarioKey_Jsonclick = "";
         edtUsuarioKey_Enabled = 1;
         edtUsuarioPass_Jsonclick = "";
         edtUsuarioPass_Enabled = 1;
         edtUsuarioCorreo_Jsonclick = "";
         edtUsuarioCorreo_Enabled = 1;
         edtUsuarioNombreCompleto_Jsonclick = "";
         edtUsuarioNombreCompleto_Enabled = 0;
         edtUsuarioApellido_Jsonclick = "";
         edtUsuarioApellido_Enabled = 1;
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioNombre_Enabled = 1;
         edtUsuarioID_Jsonclick = "";
         edtUsuarioID_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
            A53UsuarioGenero = cmbUsuarioGenero.getValidValue(A53UsuarioGenero);
            AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
         }
         cmbUsuarioDirectoAsociado.Name = "USUARIODIRECTOASOCIADO";
         cmbUsuarioDirectoAsociado.WebTags = "";
         cmbUsuarioDirectoAsociado.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbUsuarioDirectoAsociado.addItem("Directo", context.GetMessage( "Directo", ""), 0);
         cmbUsuarioDirectoAsociado.addItem("Asociado", context.GetMessage( "Asociado", ""), 0);
         if ( cmbUsuarioDirectoAsociado.ItemCount > 0 )
         {
            A54UsuarioDirectoAsociado = cmbUsuarioDirectoAsociado.getValidValue(A54UsuarioDirectoAsociado);
            n54UsuarioDirectoAsociado = false;
            AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
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
            A63UsuarioZona = cmbUsuarioZona.getValidValue(A63UsuarioZona);
            AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
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
            A67UsuarioProducto = cmbUsuarioProducto.getValidValue(A67UsuarioProducto);
            n67UsuarioProducto = false;
            AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
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
            A40UsuarioRol = cmbUsuarioRol.getValidValue(A40UsuarioRol);
            AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
         }
         chkUsuarioAvisoPrivacidad.Name = "USUARIOAVISOPRIVACIDAD";
         chkUsuarioAvisoPrivacidad.WebTags = "";
         chkUsuarioAvisoPrivacidad.Caption = context.GetMessage( "de Privacidad", "");
         AssignProp("", false, chkUsuarioAvisoPrivacidad_Internalname, "TitleCaption", chkUsuarioAvisoPrivacidad.Caption, true);
         chkUsuarioAvisoPrivacidad.CheckedValue = "false";
         if ( IsIns( ) && (false==A92UsuarioAvisoPrivacidad) )
         {
            A92UsuarioAvisoPrivacidad = false;
            AssignAttri("", false, "A92UsuarioAvisoPrivacidad", A92UsuarioAvisoPrivacidad);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtUsuarioNombre_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Usuarioid( )
      {
         A40UsuarioRol = cmbUsuarioRol.CurrentValue;
         cmbUsuarioRol.CurrentValue = A40UsuarioRol;
         n67UsuarioProducto = false;
         A67UsuarioProducto = cmbUsuarioProducto.CurrentValue;
         n67UsuarioProducto = false;
         cmbUsuarioProducto.CurrentValue = A67UsuarioProducto;
         A63UsuarioZona = cmbUsuarioZona.CurrentValue;
         cmbUsuarioZona.CurrentValue = A63UsuarioZona;
         n54UsuarioDirectoAsociado = false;
         A54UsuarioDirectoAsociado = cmbUsuarioDirectoAsociado.CurrentValue;
         n54UsuarioDirectoAsociado = false;
         cmbUsuarioDirectoAsociado.CurrentValue = A54UsuarioDirectoAsociado;
         A53UsuarioGenero = cmbUsuarioGenero.CurrentValue;
         cmbUsuarioGenero.CurrentValue = A53UsuarioGenero;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbUsuarioGenero.ItemCount > 0 )
         {
            A53UsuarioGenero = cmbUsuarioGenero.getValidValue(A53UsuarioGenero);
            cmbUsuarioGenero.CurrentValue = A53UsuarioGenero;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioGenero.CurrentValue = StringUtil.RTrim( A53UsuarioGenero);
         }
         if ( cmbUsuarioDirectoAsociado.ItemCount > 0 )
         {
            A54UsuarioDirectoAsociado = cmbUsuarioDirectoAsociado.getValidValue(A54UsuarioDirectoAsociado);
            n54UsuarioDirectoAsociado = false;
            cmbUsuarioDirectoAsociado.CurrentValue = A54UsuarioDirectoAsociado;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioDirectoAsociado.CurrentValue = StringUtil.RTrim( A54UsuarioDirectoAsociado);
         }
         if ( cmbUsuarioZona.ItemCount > 0 )
         {
            A63UsuarioZona = cmbUsuarioZona.getValidValue(A63UsuarioZona);
            cmbUsuarioZona.CurrentValue = A63UsuarioZona;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioZona.CurrentValue = StringUtil.RTrim( A63UsuarioZona);
         }
         if ( cmbUsuarioProducto.ItemCount > 0 )
         {
            A67UsuarioProducto = cmbUsuarioProducto.getValidValue(A67UsuarioProducto);
            n67UsuarioProducto = false;
            cmbUsuarioProducto.CurrentValue = A67UsuarioProducto;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioProducto.CurrentValue = StringUtil.RTrim( A67UsuarioProducto);
         }
         if ( cmbUsuarioRol.ItemCount > 0 )
         {
            A40UsuarioRol = cmbUsuarioRol.getValidValue(A40UsuarioRol);
            cmbUsuarioRol.CurrentValue = A40UsuarioRol;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioRol.CurrentValue = StringUtil.RTrim( A40UsuarioRol);
         }
         A92UsuarioAvisoPrivacidad = StringUtil.StrToBool( StringUtil.BoolToStr( A92UsuarioAvisoPrivacidad));
         /*  Sending validation outputs */
         AssignAttri("", false, "A30UsuarioNombre", StringUtil.RTrim( A30UsuarioNombre));
         AssignAttri("", false, "A51UsuarioApellido", StringUtil.RTrim( A51UsuarioApellido));
         AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
         AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
         AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
         AssignAttri("", false, "A13PuestoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PuestoID), 9, 0, ".", "")));
         AssignAttri("", false, "A53UsuarioGenero", StringUtil.RTrim( A53UsuarioGenero));
         cmbUsuarioGenero.CurrentValue = StringUtil.RTrim( A53UsuarioGenero);
         AssignProp("", false, cmbUsuarioGenero_Internalname, "Values", cmbUsuarioGenero.ToJavascriptSource(), true);
         AssignAttri("", false, "A54UsuarioDirectoAsociado", StringUtil.RTrim( A54UsuarioDirectoAsociado));
         cmbUsuarioDirectoAsociado.CurrentValue = StringUtil.RTrim( A54UsuarioDirectoAsociado);
         AssignProp("", false, cmbUsuarioDirectoAsociado_Internalname, "Values", cmbUsuarioDirectoAsociado.ToJavascriptSource(), true);
         AssignAttri("", false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
         AssignAttri("", false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
         AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
         AssignAttri("", false, "A59UsuarioCalleNum", StringUtil.RTrim( A59UsuarioCalleNum));
         AssignAttri("", false, "A60UsuarioColonia", StringUtil.RTrim( A60UsuarioColonia));
         AssignAttri("", false, "A61UsuarioDelegacion", StringUtil.RTrim( A61UsuarioDelegacion));
         AssignAttri("", false, "A62UsuarioCP", StringUtil.LTrim( StringUtil.NToC( (decimal)(A62UsuarioCP), 5, 0, ".", "")));
         AssignAttri("", false, "A63UsuarioZona", StringUtil.RTrim( A63UsuarioZona));
         cmbUsuarioZona.CurrentValue = StringUtil.RTrim( A63UsuarioZona);
         AssignProp("", false, cmbUsuarioZona_Internalname, "Values", cmbUsuarioZona.ToJavascriptSource(), true);
         AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrim( StringUtil.NToC( (decimal)(A64UsuarioCelular), 10, 0, ".", "")));
         AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrim( StringUtil.NToC( (decimal)(A65UsuarioTelefonoSucursal), 10, 0, ".", "")));
         AssignAttri("", false, "A4CiudadID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, ".", "")));
         AssignAttri("", false, "A66UsuarioSucursal", StringUtil.RTrim( A66UsuarioSucursal));
         AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
         cmbUsuarioProducto.CurrentValue = StringUtil.RTrim( A67UsuarioProducto);
         AssignProp("", false, cmbUsuarioProducto_Internalname, "Values", cmbUsuarioProducto.ToJavascriptSource(), true);
         AssignAttri("", false, "A40UsuarioRol", StringUtil.RTrim( A40UsuarioRol));
         cmbUsuarioRol.CurrentValue = StringUtil.RTrim( A40UsuarioRol);
         AssignProp("", false, cmbUsuarioRol_Internalname, "Values", cmbUsuarioRol.ToJavascriptSource(), true);
         AssignAttri("", false, "A82UsuarioNoCuentaBROXEL", StringUtil.RTrim( A82UsuarioNoCuentaBROXEL));
         AssignAttri("", false, "A83UsuarioReferenciaBROXEL", StringUtil.RTrim( A83UsuarioReferenciaBROXEL));
         AssignAttri("", false, "A87UsuarioFechaRegistro", context.localUtil.Format(A87UsuarioFechaRegistro, "99/99/99"));
         AssignAttri("", false, "A92UsuarioAvisoPrivacidad", A92UsuarioAvisoPrivacidad);
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
         AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, ".", "")));
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         AssignAttri("", false, "A16PaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, ".", "")));
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z29UsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29UsuarioID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z30UsuarioNombre", StringUtil.RTrim( Z30UsuarioNombre));
         GxWebStd.gx_hidden_field( context, "Z51UsuarioApellido", StringUtil.RTrim( Z51UsuarioApellido));
         GxWebStd.gx_hidden_field( context, "Z31UsuarioCorreo", Z31UsuarioCorreo);
         GxWebStd.gx_hidden_field( context, "Z32UsuarioPass", Z32UsuarioPass);
         GxWebStd.gx_hidden_field( context, "Z33UsuarioKey", Z33UsuarioKey);
         GxWebStd.gx_hidden_field( context, "Z13PuestoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13PuestoID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z53UsuarioGenero", StringUtil.RTrim( Z53UsuarioGenero));
         GxWebStd.gx_hidden_field( context, "Z54UsuarioDirectoAsociado", StringUtil.RTrim( Z54UsuarioDirectoAsociado));
         GxWebStd.gx_hidden_field( context, "Z55UsuarioRazonSocialAsociado", Z55UsuarioRazonSocialAsociado);
         GxWebStd.gx_hidden_field( context, "Z56UsuarioNombreComercial", Z56UsuarioNombreComercial);
         GxWebStd.gx_hidden_field( context, "Z57UsuarioFechaNacimiento", context.localUtil.Format(Z57UsuarioFechaNacimiento, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z59UsuarioCalleNum", StringUtil.RTrim( Z59UsuarioCalleNum));
         GxWebStd.gx_hidden_field( context, "Z60UsuarioColonia", StringUtil.RTrim( Z60UsuarioColonia));
         GxWebStd.gx_hidden_field( context, "Z61UsuarioDelegacion", StringUtil.RTrim( Z61UsuarioDelegacion));
         GxWebStd.gx_hidden_field( context, "Z62UsuarioCP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z62UsuarioCP), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z63UsuarioZona", StringUtil.RTrim( Z63UsuarioZona));
         GxWebStd.gx_hidden_field( context, "Z64UsuarioCelular", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64UsuarioCelular), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z65UsuarioTelefonoSucursal", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z65UsuarioTelefonoSucursal), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4CiudadID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4CiudadID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z66UsuarioSucursal", StringUtil.RTrim( Z66UsuarioSucursal));
         GxWebStd.gx_hidden_field( context, "Z67UsuarioProducto", Z67UsuarioProducto);
         GxWebStd.gx_hidden_field( context, "Z40UsuarioRol", StringUtil.RTrim( Z40UsuarioRol));
         GxWebStd.gx_hidden_field( context, "Z82UsuarioNoCuentaBROXEL", StringUtil.RTrim( Z82UsuarioNoCuentaBROXEL));
         GxWebStd.gx_hidden_field( context, "Z83UsuarioReferenciaBROXEL", StringUtil.RTrim( Z83UsuarioReferenciaBROXEL));
         GxWebStd.gx_hidden_field( context, "Z87UsuarioFechaRegistro", context.localUtil.Format(Z87UsuarioFechaRegistro, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z92UsuarioAvisoPrivacidad", StringUtil.BoolToStr( Z92UsuarioAvisoPrivacidad));
         GxWebStd.gx_hidden_field( context, "Z52UsuarioNombreCompleto", Z52UsuarioNombreCompleto);
         GxWebStd.gx_hidden_field( context, "Z14PuestoDescripcion", Z14PuestoDescripcion);
         GxWebStd.gx_hidden_field( context, "Z5CiudadDescripcion", Z5CiudadDescripcion);
         GxWebStd.gx_hidden_field( context, "Z1EstadoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EstadoID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2EstadoDescripcion", Z2EstadoDescripcion);
         GxWebStd.gx_hidden_field( context, "Z16PaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16PaisID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z17PaisDescripcion", Z17PaisDescripcion);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Puestoid( )
      {
         n13PuestoID = false;
         /* Using cursor T000A20 */
         pr_default.execute(18, new Object[] {n13PuestoID, A13PuestoID});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( (0==A13PuestoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Puesto", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PUESTOID");
               AnyError = 1;
               GX_FocusControl = edtPuestoID_Internalname;
            }
         }
         A14PuestoDescripcion = T000A20_A14PuestoDescripcion[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
      }

      public void Valid_Paisid( )
      {
         /* Using cursor T000A23 */
         pr_default.execute(21, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = T000A23_A17PaisDescripcion[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
      }

      public void Valid_Estadoid( )
      {
         /* Using cursor T000A22 */
         pr_default.execute(20, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A2EstadoDescripcion = T000A22_A2EstadoDescripcion[0];
         A16PaisID = T000A22_A16PaisID[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         AssignAttri("", false, "A16PaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, ".", "")));
      }

      public void Valid_Ciudadid( )
      {
         n4CiudadID = false;
         /* Using cursor T000A21 */
         pr_default.execute(19, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
               GX_FocusControl = edtCiudadID_Internalname;
            }
         }
         A5CiudadDescripcion = T000A21_A5CiudadDescripcion[0];
         A1EstadoID = T000A21_A1EstadoID[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_USUARIOID","""{"handler":"Valid_Usuarioid","iparms":[{"av":"cmbUsuarioRol"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"cmbUsuarioProducto"},{"av":"A67UsuarioProducto","fld":"USUARIOPRODUCTO"},{"av":"cmbUsuarioZona"},{"av":"A63UsuarioZona","fld":"USUARIOZONA"},{"av":"cmbUsuarioDirectoAsociado"},{"av":"A54UsuarioDirectoAsociado","fld":"USUARIODIRECTOASOCIADO"},{"av":"cmbUsuarioGenero"},{"av":"A53UsuarioGenero","fld":"USUARIOGENERO"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("VALID_USUARIOID",""","oparms":[{"av":"A30UsuarioNombre","fld":"USUARIONOMBRE"},{"av":"A51UsuarioApellido","fld":"USUARIOAPELLIDO"},{"av":"A31UsuarioCorreo","fld":"USUARIOCORREO"},{"av":"A32UsuarioPass","fld":"USUARIOPASS"},{"av":"A33UsuarioKey","fld":"USUARIOKEY"},{"av":"A13PuestoID","fld":"PUESTOID","pic":"ZZZZZZZZ9"},{"av":"cmbUsuarioGenero"},{"av":"A53UsuarioGenero","fld":"USUARIOGENERO"},{"av":"cmbUsuarioDirectoAsociado"},{"av":"A54UsuarioDirectoAsociado","fld":"USUARIODIRECTOASOCIADO"},{"av":"A55UsuarioRazonSocialAsociado","fld":"USUARIORAZONSOCIALASOCIADO"},{"av":"A56UsuarioNombreComercial","fld":"USUARIONOMBRECOMERCIAL"},{"av":"A57UsuarioFechaNacimiento","fld":"USUARIOFECHANACIMIENTO"},{"av":"A59UsuarioCalleNum","fld":"USUARIOCALLENUM"},{"av":"A60UsuarioColonia","fld":"USUARIOCOLONIA"},{"av":"A61UsuarioDelegacion","fld":"USUARIODELEGACION"},{"av":"A62UsuarioCP","fld":"USUARIOCP","pic":"ZZZZ9"},{"av":"cmbUsuarioZona"},{"av":"A63UsuarioZona","fld":"USUARIOZONA"},{"av":"A64UsuarioCelular","fld":"USUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"A65UsuarioTelefonoSucursal","fld":"USUARIOTELEFONOSUCURSAL","pic":"ZZZZZZZZZ9"},{"av":"A4CiudadID","fld":"CIUDADID","pic":"ZZZZZZZZ9"},{"av":"A66UsuarioSucursal","fld":"USUARIOSUCURSAL"},{"av":"cmbUsuarioProducto"},{"av":"A67UsuarioProducto","fld":"USUARIOPRODUCTO"},{"av":"cmbUsuarioRol"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A82UsuarioNoCuentaBROXEL","fld":"USUARIONOCUENTABROXEL"},{"av":"A83UsuarioReferenciaBROXEL","fld":"USUARIOREFERENCIABROXEL"},{"av":"A87UsuarioFechaRegistro","fld":"USUARIOFECHAREGISTRO"},{"av":"A52UsuarioNombreCompleto","fld":"USUARIONOMBRECOMPLETO"},{"av":"A14PuestoDescripcion","fld":"PUESTODESCRIPCION"},{"av":"A5CiudadDescripcion","fld":"CIUDADDESCRIPCION"},{"av":"A1EstadoID","fld":"ESTADOID","pic":"ZZZZZZZZ9"},{"av":"A2EstadoDescripcion","fld":"ESTADODESCRIPCION"},{"av":"A16PaisID","fld":"PAISID","pic":"ZZZZZZZZ9"},{"av":"A17PaisDescripcion","fld":"PAISDESCRIPCION"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z29UsuarioID"},{"av":"Z30UsuarioNombre"},{"av":"Z51UsuarioApellido"},{"av":"Z31UsuarioCorreo"},{"av":"Z32UsuarioPass"},{"av":"Z33UsuarioKey"},{"av":"Z13PuestoID"},{"av":"Z53UsuarioGenero"},{"av":"Z54UsuarioDirectoAsociado"},{"av":"Z55UsuarioRazonSocialAsociado"},{"av":"Z56UsuarioNombreComercial"},{"av":"Z57UsuarioFechaNacimiento"},{"av":"Z59UsuarioCalleNum"},{"av":"Z60UsuarioColonia"},{"av":"Z61UsuarioDelegacion"},{"av":"Z62UsuarioCP"},{"av":"Z63UsuarioZona"},{"av":"Z64UsuarioCelular"},{"av":"Z65UsuarioTelefonoSucursal"},{"av":"Z4CiudadID"},{"av":"Z66UsuarioSucursal"},{"av":"Z67UsuarioProducto"},{"av":"Z40UsuarioRol"},{"av":"Z82UsuarioNoCuentaBROXEL"},{"av":"Z83UsuarioReferenciaBROXEL"},{"av":"Z87UsuarioFechaRegistro"},{"av":"Z92UsuarioAvisoPrivacidad"},{"av":"Z52UsuarioNombreCompleto"},{"av":"Z14PuestoDescripcion"},{"av":"Z5CiudadDescripcion"},{"av":"Z1EstadoID"},{"av":"Z2EstadoDescripcion"},{"av":"Z16PaisID"},{"av":"Z17PaisDescripcion"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_USUARIONOMBRE","""{"handler":"Valid_Usuarionombre","iparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("VALID_USUARIONOMBRE",""","oparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_USUARIOAPELLIDO","""{"handler":"Valid_Usuarioapellido","iparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("VALID_USUARIOAPELLIDO",""","oparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_USUARIOCORREO","""{"handler":"Valid_Usuariocorreo","iparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("VALID_USUARIOCORREO",""","oparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_PUESTOID","""{"handler":"Valid_Puestoid","iparms":[{"av":"A13PuestoID","fld":"PUESTOID","pic":"ZZZZZZZZ9"},{"av":"A14PuestoDescripcion","fld":"PUESTODESCRIPCION"},{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("VALID_PUESTOID",""","oparms":[{"av":"A14PuestoDescripcion","fld":"PUESTODESCRIPCION"},{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_USUARIOGENERO","""{"handler":"Valid_Usuariogenero","iparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("VALID_USUARIOGENERO",""","oparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_USUARIODIRECTOASOCIADO","""{"handler":"Valid_Usuariodirectoasociado","iparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("VALID_USUARIODIRECTOASOCIADO",""","oparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_USUARIOFECHANACIMIENTO","""{"handler":"Valid_Usuariofechanacimiento","iparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("VALID_USUARIOFECHANACIMIENTO",""","oparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_USUARIOZONA","""{"handler":"Valid_Usuariozona","iparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("VALID_USUARIOZONA",""","oparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_PAISID","""{"handler":"Valid_Paisid","iparms":[{"av":"A16PaisID","fld":"PAISID","pic":"ZZZZZZZZ9"},{"av":"A17PaisDescripcion","fld":"PAISDESCRIPCION"},{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("VALID_PAISID",""","oparms":[{"av":"A17PaisDescripcion","fld":"PAISDESCRIPCION"},{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_ESTADOID","""{"handler":"Valid_Estadoid","iparms":[{"av":"A1EstadoID","fld":"ESTADOID","pic":"ZZZZZZZZ9"},{"av":"A2EstadoDescripcion","fld":"ESTADODESCRIPCION"},{"av":"A16PaisID","fld":"PAISID","pic":"ZZZZZZZZ9"},{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("VALID_ESTADOID",""","oparms":[{"av":"A2EstadoDescripcion","fld":"ESTADODESCRIPCION"},{"av":"A16PaisID","fld":"PAISID","pic":"ZZZZZZZZ9"},{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_CIUDADID","""{"handler":"Valid_Ciudadid","iparms":[{"av":"A4CiudadID","fld":"CIUDADID","pic":"ZZZZZZZZ9"},{"av":"A5CiudadDescripcion","fld":"CIUDADDESCRIPCION"},{"av":"A1EstadoID","fld":"ESTADOID","pic":"ZZZZZZZZ9"},{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("VALID_CIUDADID",""","oparms":[{"av":"A5CiudadDescripcion","fld":"CIUDADDESCRIPCION"},{"av":"A1EstadoID","fld":"ESTADOID","pic":"ZZZZZZZZ9"},{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_USUARIOPRODUCTO","""{"handler":"Valid_Usuarioproducto","iparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("VALID_USUARIOPRODUCTO",""","oparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_USUARIOROL","""{"handler":"Valid_Usuariorol","iparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("VALID_USUARIOROL",""","oparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
         setEventMetadata("VALID_USUARIOFECHAREGISTRO","""{"handler":"Valid_Usuariofecharegistro","iparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]""");
         setEventMetadata("VALID_USUARIOFECHAREGISTRO",""","oparms":[{"av":"A92UsuarioAvisoPrivacidad","fld":"USUARIOAVISOPRIVACIDAD"}]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(20);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z30UsuarioNombre = "";
         Z51UsuarioApellido = "";
         Z31UsuarioCorreo = "";
         Z32UsuarioPass = "";
         Z33UsuarioKey = "";
         Z53UsuarioGenero = "";
         Z54UsuarioDirectoAsociado = "";
         Z55UsuarioRazonSocialAsociado = "";
         Z56UsuarioNombreComercial = "";
         Z57UsuarioFechaNacimiento = DateTime.MinValue;
         Z59UsuarioCalleNum = "";
         Z60UsuarioColonia = "";
         Z61UsuarioDelegacion = "";
         Z63UsuarioZona = "";
         Z66UsuarioSucursal = "";
         Z67UsuarioProducto = "";
         Z40UsuarioRol = "";
         Z82UsuarioNoCuentaBROXEL = "";
         Z83UsuarioReferenciaBROXEL = "";
         Z87UsuarioFechaRegistro = DateTime.MinValue;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A53UsuarioGenero = "";
         A54UsuarioDirectoAsociado = "";
         A63UsuarioZona = "";
         A67UsuarioProducto = "";
         A40UsuarioRol = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A52UsuarioNombreCompleto = "";
         A31UsuarioCorreo = "";
         A32UsuarioPass = "";
         A33UsuarioKey = "";
         A14PuestoDescripcion = "";
         A55UsuarioRazonSocialAsociado = "";
         A56UsuarioNombreComercial = "";
         A57UsuarioFechaNacimiento = DateTime.MinValue;
         A59UsuarioCalleNum = "";
         A60UsuarioColonia = "";
         A61UsuarioDelegacion = "";
         A17PaisDescripcion = "";
         A2EstadoDescripcion = "";
         A5CiudadDescripcion = "";
         A66UsuarioSucursal = "";
         A82UsuarioNoCuentaBROXEL = "";
         A83UsuarioReferenciaBROXEL = "";
         A87UsuarioFechaRegistro = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z14PuestoDescripcion = "";
         Z5CiudadDescripcion = "";
         Z2EstadoDescripcion = "";
         Z17PaisDescripcion = "";
         T000A8_A29UsuarioID = new int[1] ;
         T000A8_A30UsuarioNombre = new string[] {""} ;
         T000A8_A51UsuarioApellido = new string[] {""} ;
         T000A8_A31UsuarioCorreo = new string[] {""} ;
         T000A8_A32UsuarioPass = new string[] {""} ;
         T000A8_A33UsuarioKey = new string[] {""} ;
         T000A8_A14PuestoDescripcion = new string[] {""} ;
         T000A8_A53UsuarioGenero = new string[] {""} ;
         T000A8_A54UsuarioDirectoAsociado = new string[] {""} ;
         T000A8_n54UsuarioDirectoAsociado = new bool[] {false} ;
         T000A8_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         T000A8_A56UsuarioNombreComercial = new string[] {""} ;
         T000A8_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T000A8_n57UsuarioFechaNacimiento = new bool[] {false} ;
         T000A8_A59UsuarioCalleNum = new string[] {""} ;
         T000A8_A60UsuarioColonia = new string[] {""} ;
         T000A8_A61UsuarioDelegacion = new string[] {""} ;
         T000A8_A62UsuarioCP = new int[1] ;
         T000A8_A63UsuarioZona = new string[] {""} ;
         T000A8_A64UsuarioCelular = new long[1] ;
         T000A8_A65UsuarioTelefonoSucursal = new long[1] ;
         T000A8_A17PaisDescripcion = new string[] {""} ;
         T000A8_A2EstadoDescripcion = new string[] {""} ;
         T000A8_A5CiudadDescripcion = new string[] {""} ;
         T000A8_A66UsuarioSucursal = new string[] {""} ;
         T000A8_A67UsuarioProducto = new string[] {""} ;
         T000A8_n67UsuarioProducto = new bool[] {false} ;
         T000A8_A40UsuarioRol = new string[] {""} ;
         T000A8_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         T000A8_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         T000A8_A87UsuarioFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         T000A8_n87UsuarioFechaRegistro = new bool[] {false} ;
         T000A8_A92UsuarioAvisoPrivacidad = new bool[] {false} ;
         T000A8_A13PuestoID = new int[1] ;
         T000A8_n13PuestoID = new bool[] {false} ;
         T000A8_A4CiudadID = new int[1] ;
         T000A8_n4CiudadID = new bool[] {false} ;
         T000A8_A1EstadoID = new int[1] ;
         T000A8_A16PaisID = new int[1] ;
         T000A4_A14PuestoDescripcion = new string[] {""} ;
         T000A5_A5CiudadDescripcion = new string[] {""} ;
         T000A5_A1EstadoID = new int[1] ;
         T000A6_A2EstadoDescripcion = new string[] {""} ;
         T000A6_A16PaisID = new int[1] ;
         T000A7_A17PaisDescripcion = new string[] {""} ;
         T000A9_A14PuestoDescripcion = new string[] {""} ;
         T000A10_A5CiudadDescripcion = new string[] {""} ;
         T000A10_A1EstadoID = new int[1] ;
         T000A11_A2EstadoDescripcion = new string[] {""} ;
         T000A11_A16PaisID = new int[1] ;
         T000A12_A17PaisDescripcion = new string[] {""} ;
         T000A13_A29UsuarioID = new int[1] ;
         T000A3_A29UsuarioID = new int[1] ;
         T000A3_A30UsuarioNombre = new string[] {""} ;
         T000A3_A51UsuarioApellido = new string[] {""} ;
         T000A3_A31UsuarioCorreo = new string[] {""} ;
         T000A3_A32UsuarioPass = new string[] {""} ;
         T000A3_A33UsuarioKey = new string[] {""} ;
         T000A3_A53UsuarioGenero = new string[] {""} ;
         T000A3_A54UsuarioDirectoAsociado = new string[] {""} ;
         T000A3_n54UsuarioDirectoAsociado = new bool[] {false} ;
         T000A3_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         T000A3_A56UsuarioNombreComercial = new string[] {""} ;
         T000A3_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T000A3_n57UsuarioFechaNacimiento = new bool[] {false} ;
         T000A3_A59UsuarioCalleNum = new string[] {""} ;
         T000A3_A60UsuarioColonia = new string[] {""} ;
         T000A3_A61UsuarioDelegacion = new string[] {""} ;
         T000A3_A62UsuarioCP = new int[1] ;
         T000A3_A63UsuarioZona = new string[] {""} ;
         T000A3_A64UsuarioCelular = new long[1] ;
         T000A3_A65UsuarioTelefonoSucursal = new long[1] ;
         T000A3_A66UsuarioSucursal = new string[] {""} ;
         T000A3_A67UsuarioProducto = new string[] {""} ;
         T000A3_n67UsuarioProducto = new bool[] {false} ;
         T000A3_A40UsuarioRol = new string[] {""} ;
         T000A3_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         T000A3_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         T000A3_A87UsuarioFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         T000A3_n87UsuarioFechaRegistro = new bool[] {false} ;
         T000A3_A92UsuarioAvisoPrivacidad = new bool[] {false} ;
         T000A3_A13PuestoID = new int[1] ;
         T000A3_n13PuestoID = new bool[] {false} ;
         T000A3_A4CiudadID = new int[1] ;
         T000A3_n4CiudadID = new bool[] {false} ;
         sMode18 = "";
         T000A14_A29UsuarioID = new int[1] ;
         T000A15_A29UsuarioID = new int[1] ;
         T000A2_A29UsuarioID = new int[1] ;
         T000A2_A30UsuarioNombre = new string[] {""} ;
         T000A2_A51UsuarioApellido = new string[] {""} ;
         T000A2_A31UsuarioCorreo = new string[] {""} ;
         T000A2_A32UsuarioPass = new string[] {""} ;
         T000A2_A33UsuarioKey = new string[] {""} ;
         T000A2_A53UsuarioGenero = new string[] {""} ;
         T000A2_A54UsuarioDirectoAsociado = new string[] {""} ;
         T000A2_n54UsuarioDirectoAsociado = new bool[] {false} ;
         T000A2_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         T000A2_A56UsuarioNombreComercial = new string[] {""} ;
         T000A2_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T000A2_n57UsuarioFechaNacimiento = new bool[] {false} ;
         T000A2_A59UsuarioCalleNum = new string[] {""} ;
         T000A2_A60UsuarioColonia = new string[] {""} ;
         T000A2_A61UsuarioDelegacion = new string[] {""} ;
         T000A2_A62UsuarioCP = new int[1] ;
         T000A2_A63UsuarioZona = new string[] {""} ;
         T000A2_A64UsuarioCelular = new long[1] ;
         T000A2_A65UsuarioTelefonoSucursal = new long[1] ;
         T000A2_A66UsuarioSucursal = new string[] {""} ;
         T000A2_A67UsuarioProducto = new string[] {""} ;
         T000A2_n67UsuarioProducto = new bool[] {false} ;
         T000A2_A40UsuarioRol = new string[] {""} ;
         T000A2_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         T000A2_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         T000A2_A87UsuarioFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         T000A2_n87UsuarioFechaRegistro = new bool[] {false} ;
         T000A2_A92UsuarioAvisoPrivacidad = new bool[] {false} ;
         T000A2_A13PuestoID = new int[1] ;
         T000A2_n13PuestoID = new bool[] {false} ;
         T000A2_A4CiudadID = new int[1] ;
         T000A2_n4CiudadID = new bool[] {false} ;
         T000A17_A29UsuarioID = new int[1] ;
         T000A20_A14PuestoDescripcion = new string[] {""} ;
         T000A21_A5CiudadDescripcion = new string[] {""} ;
         T000A21_A1EstadoID = new int[1] ;
         T000A22_A2EstadoDescripcion = new string[] {""} ;
         T000A22_A16PaisID = new int[1] ;
         T000A23_A17PaisDescripcion = new string[] {""} ;
         T000A24_A69FacturaID = new int[1] ;
         T000A25_A81DistribuidoresUsuarioID = new int[1] ;
         T000A26_A29UsuarioID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Z52UsuarioNombreCompleto = "";
         ZZ30UsuarioNombre = "";
         ZZ51UsuarioApellido = "";
         ZZ31UsuarioCorreo = "";
         ZZ32UsuarioPass = "";
         ZZ33UsuarioKey = "";
         ZZ53UsuarioGenero = "";
         ZZ54UsuarioDirectoAsociado = "";
         ZZ55UsuarioRazonSocialAsociado = "";
         ZZ56UsuarioNombreComercial = "";
         ZZ57UsuarioFechaNacimiento = DateTime.MinValue;
         ZZ59UsuarioCalleNum = "";
         ZZ60UsuarioColonia = "";
         ZZ61UsuarioDelegacion = "";
         ZZ63UsuarioZona = "";
         ZZ66UsuarioSucursal = "";
         ZZ67UsuarioProducto = "";
         ZZ40UsuarioRol = "";
         ZZ82UsuarioNoCuentaBROXEL = "";
         ZZ83UsuarioReferenciaBROXEL = "";
         ZZ87UsuarioFechaRegistro = DateTime.MinValue;
         ZZ52UsuarioNombreCompleto = "";
         ZZ14PuestoDescripcion = "";
         ZZ5CiudadDescripcion = "";
         ZZ2EstadoDescripcion = "";
         ZZ17PaisDescripcion = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuario__default(),
            new Object[][] {
                new Object[] {
               T000A2_A29UsuarioID, T000A2_A30UsuarioNombre, T000A2_A51UsuarioApellido, T000A2_A31UsuarioCorreo, T000A2_A32UsuarioPass, T000A2_A33UsuarioKey, T000A2_A53UsuarioGenero, T000A2_A54UsuarioDirectoAsociado, T000A2_n54UsuarioDirectoAsociado, T000A2_A55UsuarioRazonSocialAsociado,
               T000A2_A56UsuarioNombreComercial, T000A2_A57UsuarioFechaNacimiento, T000A2_n57UsuarioFechaNacimiento, T000A2_A59UsuarioCalleNum, T000A2_A60UsuarioColonia, T000A2_A61UsuarioDelegacion, T000A2_A62UsuarioCP, T000A2_A63UsuarioZona, T000A2_A64UsuarioCelular, T000A2_A65UsuarioTelefonoSucursal,
               T000A2_A66UsuarioSucursal, T000A2_A67UsuarioProducto, T000A2_n67UsuarioProducto, T000A2_A40UsuarioRol, T000A2_A82UsuarioNoCuentaBROXEL, T000A2_A83UsuarioReferenciaBROXEL, T000A2_A87UsuarioFechaRegistro, T000A2_n87UsuarioFechaRegistro, T000A2_A92UsuarioAvisoPrivacidad, T000A2_A13PuestoID,
               T000A2_n13PuestoID, T000A2_A4CiudadID, T000A2_n4CiudadID
               }
               , new Object[] {
               T000A3_A29UsuarioID, T000A3_A30UsuarioNombre, T000A3_A51UsuarioApellido, T000A3_A31UsuarioCorreo, T000A3_A32UsuarioPass, T000A3_A33UsuarioKey, T000A3_A53UsuarioGenero, T000A3_A54UsuarioDirectoAsociado, T000A3_n54UsuarioDirectoAsociado, T000A3_A55UsuarioRazonSocialAsociado,
               T000A3_A56UsuarioNombreComercial, T000A3_A57UsuarioFechaNacimiento, T000A3_n57UsuarioFechaNacimiento, T000A3_A59UsuarioCalleNum, T000A3_A60UsuarioColonia, T000A3_A61UsuarioDelegacion, T000A3_A62UsuarioCP, T000A3_A63UsuarioZona, T000A3_A64UsuarioCelular, T000A3_A65UsuarioTelefonoSucursal,
               T000A3_A66UsuarioSucursal, T000A3_A67UsuarioProducto, T000A3_n67UsuarioProducto, T000A3_A40UsuarioRol, T000A3_A82UsuarioNoCuentaBROXEL, T000A3_A83UsuarioReferenciaBROXEL, T000A3_A87UsuarioFechaRegistro, T000A3_n87UsuarioFechaRegistro, T000A3_A92UsuarioAvisoPrivacidad, T000A3_A13PuestoID,
               T000A3_n13PuestoID, T000A3_A4CiudadID, T000A3_n4CiudadID
               }
               , new Object[] {
               T000A4_A14PuestoDescripcion
               }
               , new Object[] {
               T000A5_A5CiudadDescripcion, T000A5_A1EstadoID
               }
               , new Object[] {
               T000A6_A2EstadoDescripcion, T000A6_A16PaisID
               }
               , new Object[] {
               T000A7_A17PaisDescripcion
               }
               , new Object[] {
               T000A8_A29UsuarioID, T000A8_A30UsuarioNombre, T000A8_A51UsuarioApellido, T000A8_A31UsuarioCorreo, T000A8_A32UsuarioPass, T000A8_A33UsuarioKey, T000A8_A14PuestoDescripcion, T000A8_A53UsuarioGenero, T000A8_A54UsuarioDirectoAsociado, T000A8_n54UsuarioDirectoAsociado,
               T000A8_A55UsuarioRazonSocialAsociado, T000A8_A56UsuarioNombreComercial, T000A8_A57UsuarioFechaNacimiento, T000A8_n57UsuarioFechaNacimiento, T000A8_A59UsuarioCalleNum, T000A8_A60UsuarioColonia, T000A8_A61UsuarioDelegacion, T000A8_A62UsuarioCP, T000A8_A63UsuarioZona, T000A8_A64UsuarioCelular,
               T000A8_A65UsuarioTelefonoSucursal, T000A8_A17PaisDescripcion, T000A8_A2EstadoDescripcion, T000A8_A5CiudadDescripcion, T000A8_A66UsuarioSucursal, T000A8_A67UsuarioProducto, T000A8_n67UsuarioProducto, T000A8_A40UsuarioRol, T000A8_A82UsuarioNoCuentaBROXEL, T000A8_A83UsuarioReferenciaBROXEL,
               T000A8_A87UsuarioFechaRegistro, T000A8_n87UsuarioFechaRegistro, T000A8_A92UsuarioAvisoPrivacidad, T000A8_A13PuestoID, T000A8_n13PuestoID, T000A8_A4CiudadID, T000A8_n4CiudadID, T000A8_A1EstadoID, T000A8_A16PaisID
               }
               , new Object[] {
               T000A9_A14PuestoDescripcion
               }
               , new Object[] {
               T000A10_A5CiudadDescripcion, T000A10_A1EstadoID
               }
               , new Object[] {
               T000A11_A2EstadoDescripcion, T000A11_A16PaisID
               }
               , new Object[] {
               T000A12_A17PaisDescripcion
               }
               , new Object[] {
               T000A13_A29UsuarioID
               }
               , new Object[] {
               T000A14_A29UsuarioID
               }
               , new Object[] {
               T000A15_A29UsuarioID
               }
               , new Object[] {
               }
               , new Object[] {
               T000A17_A29UsuarioID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A20_A14PuestoDescripcion
               }
               , new Object[] {
               T000A21_A5CiudadDescripcion, T000A21_A1EstadoID
               }
               , new Object[] {
               T000A22_A2EstadoDescripcion, T000A22_A16PaisID
               }
               , new Object[] {
               T000A23_A17PaisDescripcion
               }
               , new Object[] {
               T000A24_A69FacturaID
               }
               , new Object[] {
               T000A25_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               T000A26_A29UsuarioID
               }
            }
         );
         Z92UsuarioAvisoPrivacidad = false;
         A92UsuarioAvisoPrivacidad = false;
         i92UsuarioAvisoPrivacidad = false;
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound18 ;
      private short gxajaxcallmode ;
      private int Z29UsuarioID ;
      private int Z62UsuarioCP ;
      private int Z13PuestoID ;
      private int Z4CiudadID ;
      private int A13PuestoID ;
      private int A4CiudadID ;
      private int A1EstadoID ;
      private int A16PaisID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A29UsuarioID ;
      private int edtUsuarioID_Enabled ;
      private int edtUsuarioNombre_Enabled ;
      private int edtUsuarioApellido_Enabled ;
      private int edtUsuarioNombreCompleto_Enabled ;
      private int edtUsuarioCorreo_Enabled ;
      private int edtUsuarioPass_Enabled ;
      private int edtUsuarioKey_Enabled ;
      private int edtPuestoID_Enabled ;
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
      private int edtPaisID_Enabled ;
      private int edtPaisDescripcion_Enabled ;
      private int edtEstadoID_Enabled ;
      private int edtEstadoDescripcion_Enabled ;
      private int edtCiudadID_Enabled ;
      private int edtCiudadDescripcion_Enabled ;
      private int edtUsuarioSucursal_Enabled ;
      private int edtUsuarioNoCuentaBROXEL_Enabled ;
      private int edtUsuarioReferenciaBROXEL_Enabled ;
      private int edtUsuarioFechaRegistro_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int Z1EstadoID ;
      private int Z16PaisID ;
      private int idxLst ;
      private int ZZ29UsuarioID ;
      private int ZZ13PuestoID ;
      private int ZZ62UsuarioCP ;
      private int ZZ4CiudadID ;
      private int ZZ1EstadoID ;
      private int ZZ16PaisID ;
      private long Z64UsuarioCelular ;
      private long Z65UsuarioTelefonoSucursal ;
      private long A64UsuarioCelular ;
      private long A65UsuarioTelefonoSucursal ;
      private long ZZ64UsuarioCelular ;
      private long ZZ65UsuarioTelefonoSucursal ;
      private string sPrefix ;
      private string Z30UsuarioNombre ;
      private string Z51UsuarioApellido ;
      private string Z53UsuarioGenero ;
      private string Z54UsuarioDirectoAsociado ;
      private string Z59UsuarioCalleNum ;
      private string Z60UsuarioColonia ;
      private string Z61UsuarioDelegacion ;
      private string Z63UsuarioZona ;
      private string Z66UsuarioSucursal ;
      private string Z40UsuarioRol ;
      private string Z82UsuarioNoCuentaBROXEL ;
      private string Z83UsuarioReferenciaBROXEL ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtUsuarioID_Internalname ;
      private string A53UsuarioGenero ;
      private string cmbUsuarioGenero_Internalname ;
      private string A54UsuarioDirectoAsociado ;
      private string cmbUsuarioDirectoAsociado_Internalname ;
      private string A63UsuarioZona ;
      private string cmbUsuarioZona_Internalname ;
      private string cmbUsuarioProducto_Internalname ;
      private string A40UsuarioRol ;
      private string cmbUsuarioRol_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
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
      private string edtPuestoID_Internalname ;
      private string edtPuestoID_Jsonclick ;
      private string edtPuestoDescripcion_Internalname ;
      private string edtPuestoDescripcion_Jsonclick ;
      private string cmbUsuarioGenero_Jsonclick ;
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
      private string edtCiudadID_Internalname ;
      private string edtCiudadID_Jsonclick ;
      private string edtCiudadDescripcion_Internalname ;
      private string edtCiudadDescripcion_Jsonclick ;
      private string edtUsuarioSucursal_Internalname ;
      private string A66UsuarioSucursal ;
      private string edtUsuarioSucursal_Jsonclick ;
      private string cmbUsuarioProducto_Jsonclick ;
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
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode18 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ30UsuarioNombre ;
      private string ZZ51UsuarioApellido ;
      private string ZZ53UsuarioGenero ;
      private string ZZ54UsuarioDirectoAsociado ;
      private string ZZ59UsuarioCalleNum ;
      private string ZZ60UsuarioColonia ;
      private string ZZ61UsuarioDelegacion ;
      private string ZZ63UsuarioZona ;
      private string ZZ66UsuarioSucursal ;
      private string ZZ40UsuarioRol ;
      private string ZZ82UsuarioNoCuentaBROXEL ;
      private string ZZ83UsuarioReferenciaBROXEL ;
      private DateTime Z57UsuarioFechaNacimiento ;
      private DateTime Z87UsuarioFechaRegistro ;
      private DateTime A57UsuarioFechaNacimiento ;
      private DateTime A87UsuarioFechaRegistro ;
      private DateTime ZZ57UsuarioFechaNacimiento ;
      private DateTime ZZ87UsuarioFechaRegistro ;
      private bool Z92UsuarioAvisoPrivacidad ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n13PuestoID ;
      private bool n4CiudadID ;
      private bool wbErr ;
      private bool n54UsuarioDirectoAsociado ;
      private bool n67UsuarioProducto ;
      private bool A92UsuarioAvisoPrivacidad ;
      private bool n57UsuarioFechaNacimiento ;
      private bool n87UsuarioFechaRegistro ;
      private bool Gx_longc ;
      private bool i92UsuarioAvisoPrivacidad ;
      private bool ZZ92UsuarioAvisoPrivacidad ;
      private string Z31UsuarioCorreo ;
      private string Z32UsuarioPass ;
      private string Z33UsuarioKey ;
      private string Z55UsuarioRazonSocialAsociado ;
      private string Z56UsuarioNombreComercial ;
      private string Z67UsuarioProducto ;
      private string A67UsuarioProducto ;
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
      private string Z14PuestoDescripcion ;
      private string Z5CiudadDescripcion ;
      private string Z2EstadoDescripcion ;
      private string Z17PaisDescripcion ;
      private string Z52UsuarioNombreCompleto ;
      private string ZZ31UsuarioCorreo ;
      private string ZZ32UsuarioPass ;
      private string ZZ33UsuarioKey ;
      private string ZZ55UsuarioRazonSocialAsociado ;
      private string ZZ56UsuarioNombreComercial ;
      private string ZZ67UsuarioProducto ;
      private string ZZ52UsuarioNombreCompleto ;
      private string ZZ14PuestoDescripcion ;
      private string ZZ5CiudadDescripcion ;
      private string ZZ2EstadoDescripcion ;
      private string ZZ17PaisDescripcion ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbUsuarioGenero ;
      private GXCombobox cmbUsuarioDirectoAsociado ;
      private GXCombobox cmbUsuarioZona ;
      private GXCombobox cmbUsuarioProducto ;
      private GXCombobox cmbUsuarioRol ;
      private GXCheckbox chkUsuarioAvisoPrivacidad ;
      private IDataStoreProvider pr_default ;
      private int[] T000A8_A29UsuarioID ;
      private string[] T000A8_A30UsuarioNombre ;
      private string[] T000A8_A51UsuarioApellido ;
      private string[] T000A8_A31UsuarioCorreo ;
      private string[] T000A8_A32UsuarioPass ;
      private string[] T000A8_A33UsuarioKey ;
      private string[] T000A8_A14PuestoDescripcion ;
      private string[] T000A8_A53UsuarioGenero ;
      private string[] T000A8_A54UsuarioDirectoAsociado ;
      private bool[] T000A8_n54UsuarioDirectoAsociado ;
      private string[] T000A8_A55UsuarioRazonSocialAsociado ;
      private string[] T000A8_A56UsuarioNombreComercial ;
      private DateTime[] T000A8_A57UsuarioFechaNacimiento ;
      private bool[] T000A8_n57UsuarioFechaNacimiento ;
      private string[] T000A8_A59UsuarioCalleNum ;
      private string[] T000A8_A60UsuarioColonia ;
      private string[] T000A8_A61UsuarioDelegacion ;
      private int[] T000A8_A62UsuarioCP ;
      private string[] T000A8_A63UsuarioZona ;
      private long[] T000A8_A64UsuarioCelular ;
      private long[] T000A8_A65UsuarioTelefonoSucursal ;
      private string[] T000A8_A17PaisDescripcion ;
      private string[] T000A8_A2EstadoDescripcion ;
      private string[] T000A8_A5CiudadDescripcion ;
      private string[] T000A8_A66UsuarioSucursal ;
      private string[] T000A8_A67UsuarioProducto ;
      private bool[] T000A8_n67UsuarioProducto ;
      private string[] T000A8_A40UsuarioRol ;
      private string[] T000A8_A82UsuarioNoCuentaBROXEL ;
      private string[] T000A8_A83UsuarioReferenciaBROXEL ;
      private DateTime[] T000A8_A87UsuarioFechaRegistro ;
      private bool[] T000A8_n87UsuarioFechaRegistro ;
      private bool[] T000A8_A92UsuarioAvisoPrivacidad ;
      private int[] T000A8_A13PuestoID ;
      private bool[] T000A8_n13PuestoID ;
      private int[] T000A8_A4CiudadID ;
      private bool[] T000A8_n4CiudadID ;
      private int[] T000A8_A1EstadoID ;
      private int[] T000A8_A16PaisID ;
      private string[] T000A4_A14PuestoDescripcion ;
      private string[] T000A5_A5CiudadDescripcion ;
      private int[] T000A5_A1EstadoID ;
      private string[] T000A6_A2EstadoDescripcion ;
      private int[] T000A6_A16PaisID ;
      private string[] T000A7_A17PaisDescripcion ;
      private string[] T000A9_A14PuestoDescripcion ;
      private string[] T000A10_A5CiudadDescripcion ;
      private int[] T000A10_A1EstadoID ;
      private string[] T000A11_A2EstadoDescripcion ;
      private int[] T000A11_A16PaisID ;
      private string[] T000A12_A17PaisDescripcion ;
      private int[] T000A13_A29UsuarioID ;
      private int[] T000A3_A29UsuarioID ;
      private string[] T000A3_A30UsuarioNombre ;
      private string[] T000A3_A51UsuarioApellido ;
      private string[] T000A3_A31UsuarioCorreo ;
      private string[] T000A3_A32UsuarioPass ;
      private string[] T000A3_A33UsuarioKey ;
      private string[] T000A3_A53UsuarioGenero ;
      private string[] T000A3_A54UsuarioDirectoAsociado ;
      private bool[] T000A3_n54UsuarioDirectoAsociado ;
      private string[] T000A3_A55UsuarioRazonSocialAsociado ;
      private string[] T000A3_A56UsuarioNombreComercial ;
      private DateTime[] T000A3_A57UsuarioFechaNacimiento ;
      private bool[] T000A3_n57UsuarioFechaNacimiento ;
      private string[] T000A3_A59UsuarioCalleNum ;
      private string[] T000A3_A60UsuarioColonia ;
      private string[] T000A3_A61UsuarioDelegacion ;
      private int[] T000A3_A62UsuarioCP ;
      private string[] T000A3_A63UsuarioZona ;
      private long[] T000A3_A64UsuarioCelular ;
      private long[] T000A3_A65UsuarioTelefonoSucursal ;
      private string[] T000A3_A66UsuarioSucursal ;
      private string[] T000A3_A67UsuarioProducto ;
      private bool[] T000A3_n67UsuarioProducto ;
      private string[] T000A3_A40UsuarioRol ;
      private string[] T000A3_A82UsuarioNoCuentaBROXEL ;
      private string[] T000A3_A83UsuarioReferenciaBROXEL ;
      private DateTime[] T000A3_A87UsuarioFechaRegistro ;
      private bool[] T000A3_n87UsuarioFechaRegistro ;
      private bool[] T000A3_A92UsuarioAvisoPrivacidad ;
      private int[] T000A3_A13PuestoID ;
      private bool[] T000A3_n13PuestoID ;
      private int[] T000A3_A4CiudadID ;
      private bool[] T000A3_n4CiudadID ;
      private int[] T000A14_A29UsuarioID ;
      private int[] T000A15_A29UsuarioID ;
      private int[] T000A2_A29UsuarioID ;
      private string[] T000A2_A30UsuarioNombre ;
      private string[] T000A2_A51UsuarioApellido ;
      private string[] T000A2_A31UsuarioCorreo ;
      private string[] T000A2_A32UsuarioPass ;
      private string[] T000A2_A33UsuarioKey ;
      private string[] T000A2_A53UsuarioGenero ;
      private string[] T000A2_A54UsuarioDirectoAsociado ;
      private bool[] T000A2_n54UsuarioDirectoAsociado ;
      private string[] T000A2_A55UsuarioRazonSocialAsociado ;
      private string[] T000A2_A56UsuarioNombreComercial ;
      private DateTime[] T000A2_A57UsuarioFechaNacimiento ;
      private bool[] T000A2_n57UsuarioFechaNacimiento ;
      private string[] T000A2_A59UsuarioCalleNum ;
      private string[] T000A2_A60UsuarioColonia ;
      private string[] T000A2_A61UsuarioDelegacion ;
      private int[] T000A2_A62UsuarioCP ;
      private string[] T000A2_A63UsuarioZona ;
      private long[] T000A2_A64UsuarioCelular ;
      private long[] T000A2_A65UsuarioTelefonoSucursal ;
      private string[] T000A2_A66UsuarioSucursal ;
      private string[] T000A2_A67UsuarioProducto ;
      private bool[] T000A2_n67UsuarioProducto ;
      private string[] T000A2_A40UsuarioRol ;
      private string[] T000A2_A82UsuarioNoCuentaBROXEL ;
      private string[] T000A2_A83UsuarioReferenciaBROXEL ;
      private DateTime[] T000A2_A87UsuarioFechaRegistro ;
      private bool[] T000A2_n87UsuarioFechaRegistro ;
      private bool[] T000A2_A92UsuarioAvisoPrivacidad ;
      private int[] T000A2_A13PuestoID ;
      private bool[] T000A2_n13PuestoID ;
      private int[] T000A2_A4CiudadID ;
      private bool[] T000A2_n4CiudadID ;
      private int[] T000A17_A29UsuarioID ;
      private string[] T000A20_A14PuestoDescripcion ;
      private string[] T000A21_A5CiudadDescripcion ;
      private int[] T000A21_A1EstadoID ;
      private string[] T000A22_A2EstadoDescripcion ;
      private int[] T000A22_A16PaisID ;
      private string[] T000A23_A17PaisDescripcion ;
      private int[] T000A24_A69FacturaID ;
      private int[] T000A25_A81DistribuidoresUsuarioID ;
      private int[] T000A26_A29UsuarioID ;
   }

   public class usuario__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000A2;
          prmT000A2 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000A3;
          prmT000A3 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000A4;
          prmT000A4 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000A5;
          prmT000A5 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000A6;
          prmT000A6 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000A7;
          prmT000A7 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT000A8;
          prmT000A8 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000A9;
          prmT000A9 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000A10;
          prmT000A10 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000A11;
          prmT000A11 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000A12;
          prmT000A12 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT000A13;
          prmT000A13 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000A14;
          prmT000A14 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000A15;
          prmT000A15 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000A16;
          prmT000A16 = new Object[] {
          new ParDef("@UsuarioNombre",GXType.Char,50,0) ,
          new ParDef("@UsuarioApellido",GXType.Char,50,0) ,
          new ParDef("@UsuarioCorreo",GXType.Char,100,0) ,
          new ParDef("@UsuarioPass",GXType.Char,40,0) ,
          new ParDef("@UsuarioKey",GXType.Char,40,0) ,
          new ParDef("@UsuarioGenero",GXType.Char,20,0) ,
          new ParDef("@UsuarioDirectoAsociado",GXType.Char,20,0){Nullable=true} ,
          new ParDef("@UsuarioRazonSocialAsociado",GXType.Char,40,0) ,
          new ParDef("@UsuarioNombreComercial",GXType.Char,40,0) ,
          new ParDef("@UsuarioFechaNacimiento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@UsuarioCalleNum",GXType.Char,40,0) ,
          new ParDef("@UsuarioColonia",GXType.Char,20,0) ,
          new ParDef("@UsuarioDelegacion",GXType.Char,20,0) ,
          new ParDef("@UsuarioCP",GXType.Int32,5,0) ,
          new ParDef("@UsuarioZona",GXType.Char,30,0) ,
          new ParDef("@UsuarioCelular",GXType.Int64,10,0) ,
          new ParDef("@UsuarioTelefonoSucursal",GXType.Int64,10,0) ,
          new ParDef("@UsuarioSucursal",GXType.Char,20,0) ,
          new ParDef("@UsuarioProducto",GXType.Char,40,0){Nullable=true} ,
          new ParDef("@UsuarioRol",GXType.Char,40,0) ,
          new ParDef("@UsuarioNoCuentaBROXEL",GXType.Char,20,0) ,
          new ParDef("@UsuarioReferenciaBROXEL",GXType.Char,20,0) ,
          new ParDef("@UsuarioFechaRegistro",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@UsuarioAvisoPrivacidad",GXType.Byte,4,0) ,
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000A17;
          prmT000A17 = new Object[] {
          };
          Object[] prmT000A18;
          prmT000A18 = new Object[] {
          new ParDef("@UsuarioNombre",GXType.Char,50,0) ,
          new ParDef("@UsuarioApellido",GXType.Char,50,0) ,
          new ParDef("@UsuarioCorreo",GXType.Char,100,0) ,
          new ParDef("@UsuarioPass",GXType.Char,40,0) ,
          new ParDef("@UsuarioKey",GXType.Char,40,0) ,
          new ParDef("@UsuarioGenero",GXType.Char,20,0) ,
          new ParDef("@UsuarioDirectoAsociado",GXType.Char,20,0){Nullable=true} ,
          new ParDef("@UsuarioRazonSocialAsociado",GXType.Char,40,0) ,
          new ParDef("@UsuarioNombreComercial",GXType.Char,40,0) ,
          new ParDef("@UsuarioFechaNacimiento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@UsuarioCalleNum",GXType.Char,40,0) ,
          new ParDef("@UsuarioColonia",GXType.Char,20,0) ,
          new ParDef("@UsuarioDelegacion",GXType.Char,20,0) ,
          new ParDef("@UsuarioCP",GXType.Int32,5,0) ,
          new ParDef("@UsuarioZona",GXType.Char,30,0) ,
          new ParDef("@UsuarioCelular",GXType.Int64,10,0) ,
          new ParDef("@UsuarioTelefonoSucursal",GXType.Int64,10,0) ,
          new ParDef("@UsuarioSucursal",GXType.Char,20,0) ,
          new ParDef("@UsuarioProducto",GXType.Char,40,0){Nullable=true} ,
          new ParDef("@UsuarioRol",GXType.Char,40,0) ,
          new ParDef("@UsuarioNoCuentaBROXEL",GXType.Char,20,0) ,
          new ParDef("@UsuarioReferenciaBROXEL",GXType.Char,20,0) ,
          new ParDef("@UsuarioFechaRegistro",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@UsuarioAvisoPrivacidad",GXType.Byte,4,0) ,
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000A19;
          prmT000A19 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000A20;
          prmT000A20 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000A21;
          prmT000A21 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000A22;
          prmT000A22 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000A23;
          prmT000A23 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT000A24;
          prmT000A24 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000A25;
          prmT000A25 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000A26;
          prmT000A26 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000A2", "SELECT `UsuarioID`, `UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioGenero`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioZona`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `UsuarioNoCuentaBROXEL`, `UsuarioReferenciaBROXEL`, `UsuarioFechaRegistro`, `UsuarioAvisoPrivacidad`, `PuestoID`, `CiudadID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A3", "SELECT `UsuarioID`, `UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioGenero`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioZona`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `UsuarioNoCuentaBROXEL`, `UsuarioReferenciaBROXEL`, `UsuarioFechaRegistro`, `UsuarioAvisoPrivacidad`, `PuestoID`, `CiudadID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A4", "SELECT `PuestoDescripcion` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A5", "SELECT `CiudadDescripcion`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A6", "SELECT `EstadoDescripcion`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A7", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A8", "SELECT TM1.`UsuarioID`, TM1.`UsuarioNombre`, TM1.`UsuarioApellido`, TM1.`UsuarioCorreo`, TM1.`UsuarioPass`, TM1.`UsuarioKey`, T2.`PuestoDescripcion`, TM1.`UsuarioGenero`, TM1.`UsuarioDirectoAsociado`, TM1.`UsuarioRazonSocialAsociado`, TM1.`UsuarioNombreComercial`, TM1.`UsuarioFechaNacimiento`, TM1.`UsuarioCalleNum`, TM1.`UsuarioColonia`, TM1.`UsuarioDelegacion`, TM1.`UsuarioCP`, TM1.`UsuarioZona`, TM1.`UsuarioCelular`, TM1.`UsuarioTelefonoSucursal`, T5.`PaisDescripcion`, T4.`EstadoDescripcion`, T3.`CiudadDescripcion`, TM1.`UsuarioSucursal`, TM1.`UsuarioProducto`, TM1.`UsuarioRol`, TM1.`UsuarioNoCuentaBROXEL`, TM1.`UsuarioReferenciaBROXEL`, TM1.`UsuarioFechaRegistro`, TM1.`UsuarioAvisoPrivacidad`, TM1.`PuestoID`, TM1.`CiudadID`, T3.`EstadoID`, T4.`PaisID` FROM ((((`Usuario` TM1 LEFT JOIN `Puesto` T2 ON T2.`PuestoID` = TM1.`PuestoID`) LEFT JOIN `Ciudad` T3 ON T3.`CiudadID` = TM1.`CiudadID`) LEFT JOIN `Estado` T4 ON T4.`EstadoID` = T3.`EstadoID`) LEFT JOIN `Pais` T5 ON T5.`PaisID` = T4.`PaisID`) WHERE TM1.`UsuarioID` = @UsuarioID ORDER BY TM1.`UsuarioID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A9", "SELECT `PuestoDescripcion` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A10", "SELECT `CiudadDescripcion`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A11", "SELECT `EstadoDescripcion`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A12", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A13", "SELECT `UsuarioID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A14", "SELECT `UsuarioID` FROM `Usuario` WHERE ( `UsuarioID` > @UsuarioID) ORDER BY `UsuarioID`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000A14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A15", "SELECT `UsuarioID` FROM `Usuario` WHERE ( `UsuarioID` < @UsuarioID) ORDER BY `UsuarioID` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000A15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A16", "INSERT INTO `Usuario`(`UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioGenero`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioZona`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `UsuarioNoCuentaBROXEL`, `UsuarioReferenciaBROXEL`, `UsuarioFechaRegistro`, `UsuarioAvisoPrivacidad`, `PuestoID`, `CiudadID`) VALUES(@UsuarioNombre, @UsuarioApellido, @UsuarioCorreo, @UsuarioPass, @UsuarioKey, @UsuarioGenero, @UsuarioDirectoAsociado, @UsuarioRazonSocialAsociado, @UsuarioNombreComercial, @UsuarioFechaNacimiento, @UsuarioCalleNum, @UsuarioColonia, @UsuarioDelegacion, @UsuarioCP, @UsuarioZona, @UsuarioCelular, @UsuarioTelefonoSucursal, @UsuarioSucursal, @UsuarioProducto, @UsuarioRol, @UsuarioNoCuentaBROXEL, @UsuarioReferenciaBROXEL, @UsuarioFechaRegistro, @UsuarioAvisoPrivacidad, @PuestoID, @CiudadID)", GxErrorMask.GX_NOMASK,prmT000A16)
             ,new CursorDef("T000A17", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A18", "UPDATE `Usuario` SET `UsuarioNombre`=@UsuarioNombre, `UsuarioApellido`=@UsuarioApellido, `UsuarioCorreo`=@UsuarioCorreo, `UsuarioPass`=@UsuarioPass, `UsuarioKey`=@UsuarioKey, `UsuarioGenero`=@UsuarioGenero, `UsuarioDirectoAsociado`=@UsuarioDirectoAsociado, `UsuarioRazonSocialAsociado`=@UsuarioRazonSocialAsociado, `UsuarioNombreComercial`=@UsuarioNombreComercial, `UsuarioFechaNacimiento`=@UsuarioFechaNacimiento, `UsuarioCalleNum`=@UsuarioCalleNum, `UsuarioColonia`=@UsuarioColonia, `UsuarioDelegacion`=@UsuarioDelegacion, `UsuarioCP`=@UsuarioCP, `UsuarioZona`=@UsuarioZona, `UsuarioCelular`=@UsuarioCelular, `UsuarioTelefonoSucursal`=@UsuarioTelefonoSucursal, `UsuarioSucursal`=@UsuarioSucursal, `UsuarioProducto`=@UsuarioProducto, `UsuarioRol`=@UsuarioRol, `UsuarioNoCuentaBROXEL`=@UsuarioNoCuentaBROXEL, `UsuarioReferenciaBROXEL`=@UsuarioReferenciaBROXEL, `UsuarioFechaRegistro`=@UsuarioFechaRegistro, `UsuarioAvisoPrivacidad`=@UsuarioAvisoPrivacidad, `PuestoID`=@PuestoID, `CiudadID`=@CiudadID  WHERE `UsuarioID` = @UsuarioID", GxErrorMask.GX_NOMASK,prmT000A18)
             ,new CursorDef("T000A19", "DELETE FROM `Usuario`  WHERE `UsuarioID` = @UsuarioID", GxErrorMask.GX_NOMASK,prmT000A19)
             ,new CursorDef("T000A20", "SELECT `PuestoDescripcion` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A21", "SELECT `CiudadDescripcion`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A22", "SELECT `EstadoDescripcion`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A23", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A24", "SELECT `FacturaID` FROM `Factura` WHERE `UsuarioID` = @UsuarioID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000A24,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A25", "SELECT `DistribuidoresUsuarioID` FROM `DistribuidoresUsuario` WHERE `UsuarioID` = @UsuarioID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000A25,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A26", "SELECT `UsuarioID` FROM `Usuario` ORDER BY `UsuarioID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A26,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 40);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((string[]) buf[15])[0] = rslt.getString(14, 20);
                ((int[]) buf[16])[0] = rslt.getInt(15);
                ((string[]) buf[17])[0] = rslt.getString(16, 30);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                ((long[]) buf[19])[0] = rslt.getLong(18);
                ((string[]) buf[20])[0] = rslt.getString(19, 20);
                ((string[]) buf[21])[0] = rslt.getVarchar(20);
                ((bool[]) buf[22])[0] = rslt.wasNull(20);
                ((string[]) buf[23])[0] = rslt.getString(21, 40);
                ((string[]) buf[24])[0] = rslt.getString(22, 20);
                ((string[]) buf[25])[0] = rslt.getString(23, 20);
                ((DateTime[]) buf[26])[0] = rslt.getGXDate(24);
                ((bool[]) buf[27])[0] = rslt.wasNull(24);
                ((bool[]) buf[28])[0] = rslt.getBool(25);
                ((int[]) buf[29])[0] = rslt.getInt(26);
                ((bool[]) buf[30])[0] = rslt.wasNull(26);
                ((int[]) buf[31])[0] = rslt.getInt(27);
                ((bool[]) buf[32])[0] = rslt.wasNull(27);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 40);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((string[]) buf[15])[0] = rslt.getString(14, 20);
                ((int[]) buf[16])[0] = rslt.getInt(15);
                ((string[]) buf[17])[0] = rslt.getString(16, 30);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                ((long[]) buf[19])[0] = rslt.getLong(18);
                ((string[]) buf[20])[0] = rslt.getString(19, 20);
                ((string[]) buf[21])[0] = rslt.getVarchar(20);
                ((bool[]) buf[22])[0] = rslt.wasNull(20);
                ((string[]) buf[23])[0] = rslt.getString(21, 40);
                ((string[]) buf[24])[0] = rslt.getString(22, 20);
                ((string[]) buf[25])[0] = rslt.getString(23, 20);
                ((DateTime[]) buf[26])[0] = rslt.getGXDate(24);
                ((bool[]) buf[27])[0] = rslt.wasNull(24);
                ((bool[]) buf[28])[0] = rslt.getBool(25);
                ((int[]) buf[29])[0] = rslt.getInt(26);
                ((bool[]) buf[30])[0] = rslt.wasNull(26);
                ((int[]) buf[31])[0] = rslt.getInt(27);
                ((bool[]) buf[32])[0] = rslt.wasNull(27);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(12);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 40);
                ((string[]) buf[15])[0] = rslt.getString(14, 20);
                ((string[]) buf[16])[0] = rslt.getString(15, 20);
                ((int[]) buf[17])[0] = rslt.getInt(16);
                ((string[]) buf[18])[0] = rslt.getString(17, 30);
                ((long[]) buf[19])[0] = rslt.getLong(18);
                ((long[]) buf[20])[0] = rslt.getLong(19);
                ((string[]) buf[21])[0] = rslt.getVarchar(20);
                ((string[]) buf[22])[0] = rslt.getVarchar(21);
                ((string[]) buf[23])[0] = rslt.getVarchar(22);
                ((string[]) buf[24])[0] = rslt.getString(23, 20);
                ((string[]) buf[25])[0] = rslt.getVarchar(24);
                ((bool[]) buf[26])[0] = rslt.wasNull(24);
                ((string[]) buf[27])[0] = rslt.getString(25, 40);
                ((string[]) buf[28])[0] = rslt.getString(26, 20);
                ((string[]) buf[29])[0] = rslt.getString(27, 20);
                ((DateTime[]) buf[30])[0] = rslt.getGXDate(28);
                ((bool[]) buf[31])[0] = rslt.wasNull(28);
                ((bool[]) buf[32])[0] = rslt.getBool(29);
                ((int[]) buf[33])[0] = rslt.getInt(30);
                ((bool[]) buf[34])[0] = rslt.wasNull(30);
                ((int[]) buf[35])[0] = rslt.getInt(31);
                ((bool[]) buf[36])[0] = rslt.wasNull(31);
                ((int[]) buf[37])[0] = rslt.getInt(32);
                ((int[]) buf[38])[0] = rslt.getInt(33);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
