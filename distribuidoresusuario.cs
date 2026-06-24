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
   public class distribuidoresusuario : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A29UsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "UsuarioID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A29UsuarioID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
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
            gxLoad_5( A13PuestoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
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
            gxLoad_6( A4CiudadID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A1EstadoID = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadoID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A1EstadoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A16PaisID = (int)(Math.Round(NumberUtil.Val( GetPar( "PaisID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A16PaisID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A10DistribuidorID = (int)(Math.Round(NumberUtil.Val( GetPar( "DistribuidorID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A10DistribuidorID", StringUtil.LTrimStr( (decimal)(A10DistribuidorID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A10DistribuidorID) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Distribuidores Usuario", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDistribuidoresUsuarioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public distribuidoresusuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public distribuidoresusuario( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Distribuidores Usuario", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_DistribuidoresUsuario.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_DistribuidoresUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_DistribuidoresUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_DistribuidoresUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_DistribuidoresUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_DistribuidoresUsuario.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDistribuidoresUsuarioID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDistribuidoresUsuarioID_Internalname, context.GetMessage( "Usuario ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDistribuidoresUsuarioID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A81DistribuidoresUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtDistribuidoresUsuarioID_Enabled!=0) ? context.localUtil.Format( (decimal)(A81DistribuidoresUsuarioID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A81DistribuidoresUsuarioID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDistribuidoresUsuarioID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDistribuidoresUsuarioID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_DistribuidoresUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioID_Internalname, context.GetMessage( "Usuario ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioID_Enabled!=0) ? context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombre_Internalname, StringUtil.RTrim( A30UsuarioNombre), StringUtil.RTrim( context.localUtil.Format( A30UsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioApellido_Internalname, StringUtil.RTrim( A51UsuarioApellido), StringUtil.RTrim( context.localUtil.Format( A51UsuarioApellido, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioApellido_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioApellido_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombreCompleto_Internalname, A52UsuarioNombreCompleto, StringUtil.RTrim( context.localUtil.Format( A52UsuarioNombreCompleto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombreCompleto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNombreCompleto_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioCorreo_Internalname, A31UsuarioCorreo, StringUtil.RTrim( context.localUtil.Format( A31UsuarioCorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A31UsuarioCorreo, "", "", "", edtUsuarioCorreo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioCorreo_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         GxWebStd.gx_label_element( context, edtUsuarioPass_Internalname, context.GetMessage( "Usuario Pass", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioPass_Internalname, A32UsuarioPass, StringUtil.RTrim( context.localUtil.Format( A32UsuarioPass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioPass_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioPass_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         GxWebStd.gx_label_element( context, edtUsuarioKey_Internalname, context.GetMessage( "Usuario Key", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioKey_Internalname, A33UsuarioKey, StringUtil.RTrim( context.localUtil.Format( A33UsuarioKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioKey_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioKey_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPuestoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PuestoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPuestoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A13PuestoID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A13PuestoID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPuestoID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPuestoID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPuestoDescripcion_Internalname, A14PuestoDescripcion, StringUtil.RTrim( context.localUtil.Format( A14PuestoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPuestoDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPuestoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioGenero, cmbUsuarioGenero_Internalname, StringUtil.RTrim( A53UsuarioGenero), 1, cmbUsuarioGenero_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioGenero.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "", true, 0, "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioDirectoAsociado, cmbUsuarioDirectoAsociado_Internalname, StringUtil.RTrim( A54UsuarioDirectoAsociado), 1, cmbUsuarioDirectoAsociado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioDirectoAsociado.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 0, "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioRazonSocialAsociado_Internalname, A55UsuarioRazonSocialAsociado, StringUtil.RTrim( context.localUtil.Format( A55UsuarioRazonSocialAsociado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioRazonSocialAsociado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioRazonSocialAsociado_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombreComercial_Internalname, A56UsuarioNombreComercial, StringUtil.RTrim( context.localUtil.Format( A56UsuarioNombreComercial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombreComercial_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNombreComercial_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtUsuarioFechaNacimiento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUsuarioFechaNacimiento_Internalname, context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"), context.localUtil.Format( A57UsuarioFechaNacimiento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioFechaNacimiento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioFechaNacimiento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_DistribuidoresUsuario.htm");
         GxWebStd.gx_bitmap( context, edtUsuarioFechaNacimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuarioFechaNacimiento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioCalleNum_Internalname, StringUtil.RTrim( A59UsuarioCalleNum), StringUtil.RTrim( context.localUtil.Format( A59UsuarioCalleNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioCalleNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioCalleNum_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioColonia_Internalname, StringUtil.RTrim( A60UsuarioColonia), StringUtil.RTrim( context.localUtil.Format( A60UsuarioColonia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioColonia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioColonia_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioDelegacion_Internalname, StringUtil.RTrim( A61UsuarioDelegacion), StringUtil.RTrim( context.localUtil.Format( A61UsuarioDelegacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioDelegacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioDelegacion_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioCP_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A62UsuarioCP), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioCP_Enabled!=0) ? context.localUtil.Format( (decimal)(A62UsuarioCP), "ZZZZ9") : context.localUtil.Format( (decimal)(A62UsuarioCP), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioCP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioCP_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_DistribuidoresUsuario.htm");
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
         GxWebStd.gx_label_element( context, cmbUsuarioZona_Internalname, context.GetMessage( "Usuario Zona", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioZona, cmbUsuarioZona_Internalname, StringUtil.RTrim( A63UsuarioZona), 1, cmbUsuarioZona_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioZona.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "", true, 0, "HLP_DistribuidoresUsuario.htm");
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
         GxWebStd.gx_label_element( context, edtUsuarioCelular_Internalname, context.GetMessage( "Usuario Celular", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioCelular_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A64UsuarioCelular), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioCelular_Enabled!=0) ? context.localUtil.Format( (decimal)(A64UsuarioCelular), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A64UsuarioCelular), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioCelular_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioCelular_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioTelefonoSucursal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A65UsuarioTelefonoSucursal), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioTelefonoSucursal_Enabled!=0) ? context.localUtil.Format( (decimal)(A65UsuarioTelefonoSucursal), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A65UsuarioTelefonoSucursal), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioTelefonoSucursal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioTelefonoSucursal_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPaisID_Enabled!=0) ? context.localUtil.Format( (decimal)(A16PaisID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A16PaisID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,144);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisDescripcion_Internalname, A17PaisDescripcion, StringUtil.RTrim( context.localUtil.Format( A17PaisDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtEstadoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EstadoID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1EstadoID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,154);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstadoID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadoDescripcion_Internalname, A2EstadoDescripcion, StringUtil.RTrim( context.localUtil.Format( A2EstadoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstadoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCiudadID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCiudadID_Enabled!=0) ? context.localUtil.Format( (decimal)(A4CiudadID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A4CiudadID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCiudadID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCiudadID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCiudadDescripcion_Internalname, A5CiudadDescripcion, StringUtil.RTrim( context.localUtil.Format( A5CiudadDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCiudadDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCiudadDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         GxWebStd.gx_label_element( context, edtUsuarioSucursal_Internalname, context.GetMessage( "Usuario Sucursal", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioSucursal_Internalname, StringUtil.RTrim( A66UsuarioSucursal), StringUtil.RTrim( context.localUtil.Format( A66UsuarioSucursal, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,174);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioSucursal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioSucursal_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioProducto, cmbUsuarioProducto_Internalname, StringUtil.RTrim( A67UsuarioProducto), 1, cmbUsuarioProducto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbUsuarioProducto.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,179);\"", "", true, 0, "HLP_DistribuidoresUsuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioRol, cmbUsuarioRol_Internalname, StringUtil.RTrim( A40UsuarioRol), 1, cmbUsuarioRol_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioRol.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,184);\"", "", true, 0, "HLP_DistribuidoresUsuario.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDistribuidorID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDistribuidorID_Internalname, context.GetMessage( "Distribuidor ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDistribuidorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10DistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtDistribuidorID_Enabled!=0) ? context.localUtil.Format( (decimal)(A10DistribuidorID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A10DistribuidorID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,189);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDistribuidorID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDistribuidorID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_DistribuidoresUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDistribuidorDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDistribuidorDescripcion_Internalname, context.GetMessage( "Distribuidor al que representas", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDistribuidorDescripcion_Internalname, A11DistribuidorDescripcion, StringUtil.RTrim( context.localUtil.Format( A11DistribuidorDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,194);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDistribuidorDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDistribuidorDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_DistribuidoresUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDistribuidorRFC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDistribuidorRFC_Internalname, context.GetMessage( "Distribuidor RFC", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 199,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDistribuidorRFC_Internalname, StringUtil.RTrim( A12DistribuidorRFC), StringUtil.RTrim( context.localUtil.Format( A12DistribuidorRFC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,199);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDistribuidorRFC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDistribuidorRFC_Enabled, 0, "text", "", 13, "chr", 1, "row", 13, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_DistribuidoresUsuario.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_DistribuidoresUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_DistribuidoresUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 208,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_DistribuidoresUsuario.htm");
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
            Z81DistribuidoresUsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z81DistribuidoresUsuarioID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z10DistribuidorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z10DistribuidorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z29UsuarioID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtDistribuidoresUsuarioID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDistribuidoresUsuarioID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DISTRIBUIDORESUSUARIOID");
               AnyError = 1;
               GX_FocusControl = edtDistribuidoresUsuarioID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A81DistribuidoresUsuarioID = 0;
               AssignAttri("", false, "A81DistribuidoresUsuarioID", StringUtil.LTrimStr( (decimal)(A81DistribuidoresUsuarioID), 9, 0));
            }
            else
            {
               A81DistribuidoresUsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDistribuidoresUsuarioID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A81DistribuidoresUsuarioID", StringUtil.LTrimStr( (decimal)(A81DistribuidoresUsuarioID), 9, 0));
            }
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
            A13PuestoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPuestoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n13PuestoID = false;
            AssignAttri("", false, "A13PuestoID", StringUtil.LTrimStr( (decimal)(A13PuestoID), 9, 0));
            A14PuestoDescripcion = cgiGet( edtPuestoDescripcion_Internalname);
            AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
            cmbUsuarioGenero.CurrentValue = cgiGet( cmbUsuarioGenero_Internalname);
            A53UsuarioGenero = cgiGet( cmbUsuarioGenero_Internalname);
            AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
            cmbUsuarioDirectoAsociado.CurrentValue = cgiGet( cmbUsuarioDirectoAsociado_Internalname);
            A54UsuarioDirectoAsociado = cgiGet( cmbUsuarioDirectoAsociado_Internalname);
            n54UsuarioDirectoAsociado = false;
            AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
            A55UsuarioRazonSocialAsociado = cgiGet( edtUsuarioRazonSocialAsociado_Internalname);
            AssignAttri("", false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
            A56UsuarioNombreComercial = cgiGet( edtUsuarioNombreComercial_Internalname);
            AssignAttri("", false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
            A57UsuarioFechaNacimiento = context.localUtil.CToD( cgiGet( edtUsuarioFechaNacimiento_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            n57UsuarioFechaNacimiento = false;
            AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
            A59UsuarioCalleNum = cgiGet( edtUsuarioCalleNum_Internalname);
            AssignAttri("", false, "A59UsuarioCalleNum", A59UsuarioCalleNum);
            A60UsuarioColonia = cgiGet( edtUsuarioColonia_Internalname);
            AssignAttri("", false, "A60UsuarioColonia", A60UsuarioColonia);
            A61UsuarioDelegacion = cgiGet( edtUsuarioDelegacion_Internalname);
            AssignAttri("", false, "A61UsuarioDelegacion", A61UsuarioDelegacion);
            A62UsuarioCP = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioCP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
            cmbUsuarioZona.CurrentValue = cgiGet( cmbUsuarioZona_Internalname);
            A63UsuarioZona = cgiGet( cmbUsuarioZona_Internalname);
            AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
            A64UsuarioCelular = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioCelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
            A65UsuarioTelefonoSucursal = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioTelefonoSucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
            A16PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPaisID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            A17PaisDescripcion = cgiGet( edtPaisDescripcion_Internalname);
            AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
            A1EstadoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            A2EstadoDescripcion = cgiGet( edtEstadoDescripcion_Internalname);
            AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
            A4CiudadID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCiudadID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n4CiudadID = false;
            AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
            A5CiudadDescripcion = cgiGet( edtCiudadDescripcion_Internalname);
            AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
            A66UsuarioSucursal = cgiGet( edtUsuarioSucursal_Internalname);
            AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
            cmbUsuarioProducto.CurrentValue = cgiGet( cmbUsuarioProducto_Internalname);
            A67UsuarioProducto = cgiGet( cmbUsuarioProducto_Internalname);
            n67UsuarioProducto = false;
            AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
            cmbUsuarioRol.CurrentValue = cgiGet( cmbUsuarioRol_Internalname);
            A40UsuarioRol = cgiGet( cmbUsuarioRol_Internalname);
            AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
            if ( ( ( context.localUtil.CToN( cgiGet( edtDistribuidorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDistribuidorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DISTRIBUIDORID");
               AnyError = 1;
               GX_FocusControl = edtDistribuidorID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A10DistribuidorID = 0;
               AssignAttri("", false, "A10DistribuidorID", StringUtil.LTrimStr( (decimal)(A10DistribuidorID), 9, 0));
            }
            else
            {
               A10DistribuidorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDistribuidorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A10DistribuidorID", StringUtil.LTrimStr( (decimal)(A10DistribuidorID), 9, 0));
            }
            A11DistribuidorDescripcion = cgiGet( edtDistribuidorDescripcion_Internalname);
            AssignAttri("", false, "A11DistribuidorDescripcion", A11DistribuidorDescripcion);
            A12DistribuidorRFC = cgiGet( edtDistribuidorRFC_Internalname);
            AssignAttri("", false, "A12DistribuidorRFC", A12DistribuidorRFC);
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
               A81DistribuidoresUsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "DistribuidoresUsuarioID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A81DistribuidoresUsuarioID", StringUtil.LTrimStr( (decimal)(A81DistribuidoresUsuarioID), 9, 0));
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
               InitAll0H10( ) ;
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
         DisableAttributes0H10( ) ;
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

      protected void ResetCaption0H0( )
      {
      }

      protected void ZM0H10( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z10DistribuidorID = T000H3_A10DistribuidorID[0];
               Z29UsuarioID = T000H3_A29UsuarioID[0];
            }
            else
            {
               Z10DistribuidorID = A10DistribuidorID;
               Z29UsuarioID = A29UsuarioID;
            }
         }
         if ( GX_JID == -2 )
         {
            Z81DistribuidoresUsuarioID = A81DistribuidoresUsuarioID;
            Z10DistribuidorID = A10DistribuidorID;
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
            Z13PuestoID = A13PuestoID;
            Z4CiudadID = A4CiudadID;
            Z14PuestoDescripcion = A14PuestoDescripcion;
            Z5CiudadDescripcion = A5CiudadDescripcion;
            Z1EstadoID = A1EstadoID;
            Z2EstadoDescripcion = A2EstadoDescripcion;
            Z16PaisID = A16PaisID;
            Z17PaisDescripcion = A17PaisDescripcion;
            Z11DistribuidorDescripcion = A11DistribuidorDescripcion;
            Z12DistribuidorRFC = A12DistribuidorRFC;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
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

      protected void Load0H10( )
      {
         /* Using cursor T000H10 */
         pr_default.execute(8, new Object[] {A81DistribuidoresUsuarioID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound10 = 1;
            A30UsuarioNombre = T000H10_A30UsuarioNombre[0];
            AssignAttri("", false, "A30UsuarioNombre", A30UsuarioNombre);
            A51UsuarioApellido = T000H10_A51UsuarioApellido[0];
            AssignAttri("", false, "A51UsuarioApellido", A51UsuarioApellido);
            A31UsuarioCorreo = T000H10_A31UsuarioCorreo[0];
            AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
            A32UsuarioPass = T000H10_A32UsuarioPass[0];
            AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
            A33UsuarioKey = T000H10_A33UsuarioKey[0];
            AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
            A14PuestoDescripcion = T000H10_A14PuestoDescripcion[0];
            AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
            A53UsuarioGenero = T000H10_A53UsuarioGenero[0];
            AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
            A54UsuarioDirectoAsociado = T000H10_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = T000H10_n54UsuarioDirectoAsociado[0];
            AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
            A55UsuarioRazonSocialAsociado = T000H10_A55UsuarioRazonSocialAsociado[0];
            AssignAttri("", false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
            A56UsuarioNombreComercial = T000H10_A56UsuarioNombreComercial[0];
            AssignAttri("", false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
            A57UsuarioFechaNacimiento = T000H10_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = T000H10_n57UsuarioFechaNacimiento[0];
            AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
            A59UsuarioCalleNum = T000H10_A59UsuarioCalleNum[0];
            AssignAttri("", false, "A59UsuarioCalleNum", A59UsuarioCalleNum);
            A60UsuarioColonia = T000H10_A60UsuarioColonia[0];
            AssignAttri("", false, "A60UsuarioColonia", A60UsuarioColonia);
            A61UsuarioDelegacion = T000H10_A61UsuarioDelegacion[0];
            AssignAttri("", false, "A61UsuarioDelegacion", A61UsuarioDelegacion);
            A62UsuarioCP = T000H10_A62UsuarioCP[0];
            AssignAttri("", false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
            A63UsuarioZona = T000H10_A63UsuarioZona[0];
            AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
            A64UsuarioCelular = T000H10_A64UsuarioCelular[0];
            AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
            A65UsuarioTelefonoSucursal = T000H10_A65UsuarioTelefonoSucursal[0];
            AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
            A17PaisDescripcion = T000H10_A17PaisDescripcion[0];
            AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
            A2EstadoDescripcion = T000H10_A2EstadoDescripcion[0];
            AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
            A5CiudadDescripcion = T000H10_A5CiudadDescripcion[0];
            AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
            A66UsuarioSucursal = T000H10_A66UsuarioSucursal[0];
            AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
            A67UsuarioProducto = T000H10_A67UsuarioProducto[0];
            n67UsuarioProducto = T000H10_n67UsuarioProducto[0];
            AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
            A40UsuarioRol = T000H10_A40UsuarioRol[0];
            AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
            A11DistribuidorDescripcion = T000H10_A11DistribuidorDescripcion[0];
            AssignAttri("", false, "A11DistribuidorDescripcion", A11DistribuidorDescripcion);
            A12DistribuidorRFC = T000H10_A12DistribuidorRFC[0];
            AssignAttri("", false, "A12DistribuidorRFC", A12DistribuidorRFC);
            A10DistribuidorID = T000H10_A10DistribuidorID[0];
            AssignAttri("", false, "A10DistribuidorID", StringUtil.LTrimStr( (decimal)(A10DistribuidorID), 9, 0));
            A29UsuarioID = T000H10_A29UsuarioID[0];
            AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
            A13PuestoID = T000H10_A13PuestoID[0];
            n13PuestoID = T000H10_n13PuestoID[0];
            AssignAttri("", false, "A13PuestoID", StringUtil.LTrimStr( (decimal)(A13PuestoID), 9, 0));
            A4CiudadID = T000H10_A4CiudadID[0];
            n4CiudadID = T000H10_n4CiudadID[0];
            AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
            A1EstadoID = T000H10_A1EstadoID[0];
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            A16PaisID = T000H10_A16PaisID[0];
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            ZM0H10( -2) ;
         }
         pr_default.close(8);
         OnLoadActions0H10( ) ;
      }

      protected void OnLoadActions0H10( )
      {
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
      }

      protected void CheckExtendedTable0H10( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000H5 */
         pr_default.execute(3, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A30UsuarioNombre = T000H5_A30UsuarioNombre[0];
         AssignAttri("", false, "A30UsuarioNombre", A30UsuarioNombre);
         A51UsuarioApellido = T000H5_A51UsuarioApellido[0];
         AssignAttri("", false, "A51UsuarioApellido", A51UsuarioApellido);
         A31UsuarioCorreo = T000H5_A31UsuarioCorreo[0];
         AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
         A32UsuarioPass = T000H5_A32UsuarioPass[0];
         AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
         A33UsuarioKey = T000H5_A33UsuarioKey[0];
         AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
         A53UsuarioGenero = T000H5_A53UsuarioGenero[0];
         AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
         A54UsuarioDirectoAsociado = T000H5_A54UsuarioDirectoAsociado[0];
         n54UsuarioDirectoAsociado = T000H5_n54UsuarioDirectoAsociado[0];
         AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
         A55UsuarioRazonSocialAsociado = T000H5_A55UsuarioRazonSocialAsociado[0];
         AssignAttri("", false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
         A56UsuarioNombreComercial = T000H5_A56UsuarioNombreComercial[0];
         AssignAttri("", false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
         A57UsuarioFechaNacimiento = T000H5_A57UsuarioFechaNacimiento[0];
         n57UsuarioFechaNacimiento = T000H5_n57UsuarioFechaNacimiento[0];
         AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
         A59UsuarioCalleNum = T000H5_A59UsuarioCalleNum[0];
         AssignAttri("", false, "A59UsuarioCalleNum", A59UsuarioCalleNum);
         A60UsuarioColonia = T000H5_A60UsuarioColonia[0];
         AssignAttri("", false, "A60UsuarioColonia", A60UsuarioColonia);
         A61UsuarioDelegacion = T000H5_A61UsuarioDelegacion[0];
         AssignAttri("", false, "A61UsuarioDelegacion", A61UsuarioDelegacion);
         A62UsuarioCP = T000H5_A62UsuarioCP[0];
         AssignAttri("", false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
         A63UsuarioZona = T000H5_A63UsuarioZona[0];
         AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
         A64UsuarioCelular = T000H5_A64UsuarioCelular[0];
         AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
         A65UsuarioTelefonoSucursal = T000H5_A65UsuarioTelefonoSucursal[0];
         AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
         A66UsuarioSucursal = T000H5_A66UsuarioSucursal[0];
         AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
         A67UsuarioProducto = T000H5_A67UsuarioProducto[0];
         n67UsuarioProducto = T000H5_n67UsuarioProducto[0];
         AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
         A40UsuarioRol = T000H5_A40UsuarioRol[0];
         AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
         A13PuestoID = T000H5_A13PuestoID[0];
         n13PuestoID = T000H5_n13PuestoID[0];
         AssignAttri("", false, "A13PuestoID", StringUtil.LTrimStr( (decimal)(A13PuestoID), 9, 0));
         A4CiudadID = T000H5_A4CiudadID[0];
         n4CiudadID = T000H5_n4CiudadID[0];
         AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
         pr_default.close(3);
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
         /* Using cursor T000H6 */
         pr_default.execute(4, new Object[] {n13PuestoID, A13PuestoID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A13PuestoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Puesto", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PUESTOID");
               AnyError = 1;
            }
         }
         A14PuestoDescripcion = T000H6_A14PuestoDescripcion[0];
         AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
         pr_default.close(4);
         /* Using cursor T000H7 */
         pr_default.execute(5, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
            }
         }
         A5CiudadDescripcion = T000H7_A5CiudadDescripcion[0];
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         A1EstadoID = T000H7_A1EstadoID[0];
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
         pr_default.close(5);
         /* Using cursor T000H8 */
         pr_default.execute(6, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A2EstadoDescripcion = T000H8_A2EstadoDescripcion[0];
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         A16PaisID = T000H8_A16PaisID[0];
         AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
         pr_default.close(6);
         /* Using cursor T000H9 */
         pr_default.execute(7, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = T000H9_A17PaisDescripcion[0];
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
         pr_default.close(7);
         /* Using cursor T000H4 */
         pr_default.execute(2, new Object[] {A10DistribuidorID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Distribuidor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DISTRIBUIDORID");
            AnyError = 1;
            GX_FocusControl = edtDistribuidorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A11DistribuidorDescripcion = T000H4_A11DistribuidorDescripcion[0];
         AssignAttri("", false, "A11DistribuidorDescripcion", A11DistribuidorDescripcion);
         A12DistribuidorRFC = T000H4_A12DistribuidorRFC[0];
         AssignAttri("", false, "A12DistribuidorRFC", A12DistribuidorRFC);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0H10( )
      {
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( int A29UsuarioID )
      {
         /* Using cursor T000H11 */
         pr_default.execute(9, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A30UsuarioNombre = T000H11_A30UsuarioNombre[0];
         AssignAttri("", false, "A30UsuarioNombre", A30UsuarioNombre);
         A51UsuarioApellido = T000H11_A51UsuarioApellido[0];
         AssignAttri("", false, "A51UsuarioApellido", A51UsuarioApellido);
         A31UsuarioCorreo = T000H11_A31UsuarioCorreo[0];
         AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
         A32UsuarioPass = T000H11_A32UsuarioPass[0];
         AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
         A33UsuarioKey = T000H11_A33UsuarioKey[0];
         AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
         A53UsuarioGenero = T000H11_A53UsuarioGenero[0];
         AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
         A54UsuarioDirectoAsociado = T000H11_A54UsuarioDirectoAsociado[0];
         n54UsuarioDirectoAsociado = T000H11_n54UsuarioDirectoAsociado[0];
         AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
         A55UsuarioRazonSocialAsociado = T000H11_A55UsuarioRazonSocialAsociado[0];
         AssignAttri("", false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
         A56UsuarioNombreComercial = T000H11_A56UsuarioNombreComercial[0];
         AssignAttri("", false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
         A57UsuarioFechaNacimiento = T000H11_A57UsuarioFechaNacimiento[0];
         n57UsuarioFechaNacimiento = T000H11_n57UsuarioFechaNacimiento[0];
         AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
         A59UsuarioCalleNum = T000H11_A59UsuarioCalleNum[0];
         AssignAttri("", false, "A59UsuarioCalleNum", A59UsuarioCalleNum);
         A60UsuarioColonia = T000H11_A60UsuarioColonia[0];
         AssignAttri("", false, "A60UsuarioColonia", A60UsuarioColonia);
         A61UsuarioDelegacion = T000H11_A61UsuarioDelegacion[0];
         AssignAttri("", false, "A61UsuarioDelegacion", A61UsuarioDelegacion);
         A62UsuarioCP = T000H11_A62UsuarioCP[0];
         AssignAttri("", false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
         A63UsuarioZona = T000H11_A63UsuarioZona[0];
         AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
         A64UsuarioCelular = T000H11_A64UsuarioCelular[0];
         AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
         A65UsuarioTelefonoSucursal = T000H11_A65UsuarioTelefonoSucursal[0];
         AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
         A66UsuarioSucursal = T000H11_A66UsuarioSucursal[0];
         AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
         A67UsuarioProducto = T000H11_A67UsuarioProducto[0];
         n67UsuarioProducto = T000H11_n67UsuarioProducto[0];
         AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
         A40UsuarioRol = T000H11_A40UsuarioRol[0];
         AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
         A13PuestoID = T000H11_A13PuestoID[0];
         n13PuestoID = T000H11_n13PuestoID[0];
         AssignAttri("", false, "A13PuestoID", StringUtil.LTrimStr( (decimal)(A13PuestoID), 9, 0));
         A4CiudadID = T000H11_A4CiudadID[0];
         n4CiudadID = T000H11_n4CiudadID[0];
         AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A30UsuarioNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A51UsuarioApellido))+"\""+","+"\""+GXUtil.EncodeJSConstant( A31UsuarioCorreo)+"\""+","+"\""+GXUtil.EncodeJSConstant( A32UsuarioPass)+"\""+","+"\""+GXUtil.EncodeJSConstant( A33UsuarioKey)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A53UsuarioGenero))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A54UsuarioDirectoAsociado))+"\""+","+"\""+GXUtil.EncodeJSConstant( A55UsuarioRazonSocialAsociado)+"\""+","+"\""+GXUtil.EncodeJSConstant( A56UsuarioNombreComercial)+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A59UsuarioCalleNum))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A60UsuarioColonia))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A61UsuarioDelegacion))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A62UsuarioCP), 5, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A63UsuarioZona))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A64UsuarioCelular), 10, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A65UsuarioTelefonoSucursal), 10, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A66UsuarioSucursal))+"\""+","+"\""+GXUtil.EncodeJSConstant( A67UsuarioProducto)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A40UsuarioRol))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PuestoID), 9, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_5( int A13PuestoID )
      {
         /* Using cursor T000H12 */
         pr_default.execute(10, new Object[] {n13PuestoID, A13PuestoID});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A13PuestoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Puesto", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PUESTOID");
               AnyError = 1;
            }
         }
         A14PuestoDescripcion = T000H12_A14PuestoDescripcion[0];
         AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A14PuestoDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_6( int A4CiudadID )
      {
         /* Using cursor T000H13 */
         pr_default.execute(11, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
            }
         }
         A5CiudadDescripcion = T000H13_A5CiudadDescripcion[0];
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         A1EstadoID = T000H13_A1EstadoID[0];
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A5CiudadDescripcion)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_7( int A1EstadoID )
      {
         /* Using cursor T000H14 */
         pr_default.execute(12, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A2EstadoDescripcion = T000H14_A2EstadoDescripcion[0];
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         A16PaisID = T000H14_A16PaisID[0];
         AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2EstadoDescripcion)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_8( int A16PaisID )
      {
         /* Using cursor T000H15 */
         pr_default.execute(13, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = T000H15_A17PaisDescripcion[0];
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A17PaisDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_3( int A10DistribuidorID )
      {
         /* Using cursor T000H16 */
         pr_default.execute(14, new Object[] {A10DistribuidorID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Distribuidor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DISTRIBUIDORID");
            AnyError = 1;
            GX_FocusControl = edtDistribuidorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A11DistribuidorDescripcion = T000H16_A11DistribuidorDescripcion[0];
         AssignAttri("", false, "A11DistribuidorDescripcion", A11DistribuidorDescripcion);
         A12DistribuidorRFC = T000H16_A12DistribuidorRFC[0];
         AssignAttri("", false, "A12DistribuidorRFC", A12DistribuidorRFC);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A11DistribuidorDescripcion)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A12DistribuidorRFC))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey0H10( )
      {
         /* Using cursor T000H17 */
         pr_default.execute(15, new Object[] {A81DistribuidoresUsuarioID});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000H3 */
         pr_default.execute(1, new Object[] {A81DistribuidoresUsuarioID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H10( 2) ;
            RcdFound10 = 1;
            A81DistribuidoresUsuarioID = T000H3_A81DistribuidoresUsuarioID[0];
            AssignAttri("", false, "A81DistribuidoresUsuarioID", StringUtil.LTrimStr( (decimal)(A81DistribuidoresUsuarioID), 9, 0));
            A10DistribuidorID = T000H3_A10DistribuidorID[0];
            AssignAttri("", false, "A10DistribuidorID", StringUtil.LTrimStr( (decimal)(A10DistribuidorID), 9, 0));
            A29UsuarioID = T000H3_A29UsuarioID[0];
            AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
            Z81DistribuidoresUsuarioID = A81DistribuidoresUsuarioID;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0H10( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0H10( ) ;
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0H10( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H10( ) ;
         if ( RcdFound10 == 0 )
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
         RcdFound10 = 0;
         /* Using cursor T000H18 */
         pr_default.execute(16, new Object[] {A81DistribuidoresUsuarioID});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( T000H18_A81DistribuidoresUsuarioID[0] < A81DistribuidoresUsuarioID ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( T000H18_A81DistribuidoresUsuarioID[0] > A81DistribuidoresUsuarioID ) ) )
            {
               A81DistribuidoresUsuarioID = T000H18_A81DistribuidoresUsuarioID[0];
               AssignAttri("", false, "A81DistribuidoresUsuarioID", StringUtil.LTrimStr( (decimal)(A81DistribuidoresUsuarioID), 9, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void move_previous( )
      {
         RcdFound10 = 0;
         /* Using cursor T000H19 */
         pr_default.execute(17, new Object[] {A81DistribuidoresUsuarioID});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( T000H19_A81DistribuidoresUsuarioID[0] > A81DistribuidoresUsuarioID ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( T000H19_A81DistribuidoresUsuarioID[0] < A81DistribuidoresUsuarioID ) ) )
            {
               A81DistribuidoresUsuarioID = T000H19_A81DistribuidoresUsuarioID[0];
               AssignAttri("", false, "A81DistribuidoresUsuarioID", StringUtil.LTrimStr( (decimal)(A81DistribuidoresUsuarioID), 9, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0H10( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDistribuidoresUsuarioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0H10( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A81DistribuidoresUsuarioID != Z81DistribuidoresUsuarioID )
               {
                  A81DistribuidoresUsuarioID = Z81DistribuidoresUsuarioID;
                  AssignAttri("", false, "A81DistribuidoresUsuarioID", StringUtil.LTrimStr( (decimal)(A81DistribuidoresUsuarioID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DISTRIBUIDORESUSUARIOID");
                  AnyError = 1;
                  GX_FocusControl = edtDistribuidoresUsuarioID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDistribuidoresUsuarioID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0H10( ) ;
                  GX_FocusControl = edtDistribuidoresUsuarioID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A81DistribuidoresUsuarioID != Z81DistribuidoresUsuarioID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtDistribuidoresUsuarioID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0H10( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DISTRIBUIDORESUSUARIOID");
                     AnyError = 1;
                     GX_FocusControl = edtDistribuidoresUsuarioID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtDistribuidoresUsuarioID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0H10( ) ;
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
         if ( A81DistribuidoresUsuarioID != Z81DistribuidoresUsuarioID )
         {
            A81DistribuidoresUsuarioID = Z81DistribuidoresUsuarioID;
            AssignAttri("", false, "A81DistribuidoresUsuarioID", StringUtil.LTrimStr( (decimal)(A81DistribuidoresUsuarioID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DISTRIBUIDORESUSUARIOID");
            AnyError = 1;
            GX_FocusControl = edtDistribuidoresUsuarioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDistribuidoresUsuarioID_Internalname;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "DISTRIBUIDORESUSUARIOID");
            AnyError = 1;
            GX_FocusControl = edtDistribuidoresUsuarioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtUsuarioID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0H10( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0H10( ) ;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioID_Internalname;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioID_Internalname;
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
         ScanStart0H10( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound10 != 0 )
            {
               ScanNext0H10( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0H10( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0H10( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000H2 */
            pr_default.execute(0, new Object[] {A81DistribuidoresUsuarioID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DistribuidoresUsuario"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z10DistribuidorID != T000H2_A10DistribuidorID[0] ) || ( Z29UsuarioID != T000H2_A29UsuarioID[0] ) )
            {
               if ( Z10DistribuidorID != T000H2_A10DistribuidorID[0] )
               {
                  GXUtil.WriteLog("distribuidoresusuario:[seudo value changed for attri]"+"DistribuidorID");
                  GXUtil.WriteLogRaw("Old: ",Z10DistribuidorID);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A10DistribuidorID[0]);
               }
               if ( Z29UsuarioID != T000H2_A29UsuarioID[0] )
               {
                  GXUtil.WriteLog("distribuidoresusuario:[seudo value changed for attri]"+"UsuarioID");
                  GXUtil.WriteLogRaw("Old: ",Z29UsuarioID);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A29UsuarioID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DistribuidoresUsuario"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H10( )
      {
         BeforeValidate0H10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H10( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H10( 0) ;
            CheckOptimisticConcurrency0H10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H20 */
                     pr_default.execute(18, new Object[] {A10DistribuidorID, A29UsuarioID});
                     pr_default.close(18);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000H21 */
                     pr_default.execute(19);
                     A81DistribuidoresUsuarioID = T000H21_A81DistribuidoresUsuarioID[0];
                     AssignAttri("", false, "A81DistribuidoresUsuarioID", StringUtil.LTrimStr( (decimal)(A81DistribuidoresUsuarioID), 9, 0));
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("DistribuidoresUsuario");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0H0( ) ;
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
               Load0H10( ) ;
            }
            EndLevel0H10( ) ;
         }
         CloseExtendedTableCursors0H10( ) ;
      }

      protected void Update0H10( )
      {
         BeforeValidate0H10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H10( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H22 */
                     pr_default.execute(20, new Object[] {A10DistribuidorID, A29UsuarioID, A81DistribuidoresUsuarioID});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("DistribuidoresUsuario");
                     if ( (pr_default.getStatus(20) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DistribuidoresUsuario"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H10( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0H0( ) ;
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
            EndLevel0H10( ) ;
         }
         CloseExtendedTableCursors0H10( ) ;
      }

      protected void DeferredUpdate0H10( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0H10( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H10( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H10( ) ;
            AfterConfirm0H10( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H10( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000H23 */
                  pr_default.execute(21, new Object[] {A81DistribuidoresUsuarioID});
                  pr_default.close(21);
                  pr_default.SmartCacheProvider.SetUpdated("DistribuidoresUsuario");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound10 == 0 )
                        {
                           InitAll0H10( ) ;
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
                        ResetCaption0H0( ) ;
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0H10( ) ;
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0H10( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000H24 */
            pr_default.execute(22, new Object[] {A29UsuarioID});
            A30UsuarioNombre = T000H24_A30UsuarioNombre[0];
            AssignAttri("", false, "A30UsuarioNombre", A30UsuarioNombre);
            A51UsuarioApellido = T000H24_A51UsuarioApellido[0];
            AssignAttri("", false, "A51UsuarioApellido", A51UsuarioApellido);
            A31UsuarioCorreo = T000H24_A31UsuarioCorreo[0];
            AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
            A32UsuarioPass = T000H24_A32UsuarioPass[0];
            AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
            A33UsuarioKey = T000H24_A33UsuarioKey[0];
            AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
            A53UsuarioGenero = T000H24_A53UsuarioGenero[0];
            AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
            A54UsuarioDirectoAsociado = T000H24_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = T000H24_n54UsuarioDirectoAsociado[0];
            AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
            A55UsuarioRazonSocialAsociado = T000H24_A55UsuarioRazonSocialAsociado[0];
            AssignAttri("", false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
            A56UsuarioNombreComercial = T000H24_A56UsuarioNombreComercial[0];
            AssignAttri("", false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
            A57UsuarioFechaNacimiento = T000H24_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = T000H24_n57UsuarioFechaNacimiento[0];
            AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
            A59UsuarioCalleNum = T000H24_A59UsuarioCalleNum[0];
            AssignAttri("", false, "A59UsuarioCalleNum", A59UsuarioCalleNum);
            A60UsuarioColonia = T000H24_A60UsuarioColonia[0];
            AssignAttri("", false, "A60UsuarioColonia", A60UsuarioColonia);
            A61UsuarioDelegacion = T000H24_A61UsuarioDelegacion[0];
            AssignAttri("", false, "A61UsuarioDelegacion", A61UsuarioDelegacion);
            A62UsuarioCP = T000H24_A62UsuarioCP[0];
            AssignAttri("", false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
            A63UsuarioZona = T000H24_A63UsuarioZona[0];
            AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
            A64UsuarioCelular = T000H24_A64UsuarioCelular[0];
            AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
            A65UsuarioTelefonoSucursal = T000H24_A65UsuarioTelefonoSucursal[0];
            AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
            A66UsuarioSucursal = T000H24_A66UsuarioSucursal[0];
            AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
            A67UsuarioProducto = T000H24_A67UsuarioProducto[0];
            n67UsuarioProducto = T000H24_n67UsuarioProducto[0];
            AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
            A40UsuarioRol = T000H24_A40UsuarioRol[0];
            AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
            A13PuestoID = T000H24_A13PuestoID[0];
            n13PuestoID = T000H24_n13PuestoID[0];
            AssignAttri("", false, "A13PuestoID", StringUtil.LTrimStr( (decimal)(A13PuestoID), 9, 0));
            A4CiudadID = T000H24_A4CiudadID[0];
            n4CiudadID = T000H24_n4CiudadID[0];
            AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
            pr_default.close(22);
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
            /* Using cursor T000H25 */
            pr_default.execute(23, new Object[] {n13PuestoID, A13PuestoID});
            A14PuestoDescripcion = T000H25_A14PuestoDescripcion[0];
            AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
            pr_default.close(23);
            /* Using cursor T000H26 */
            pr_default.execute(24, new Object[] {n4CiudadID, A4CiudadID});
            A5CiudadDescripcion = T000H26_A5CiudadDescripcion[0];
            AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
            A1EstadoID = T000H26_A1EstadoID[0];
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            pr_default.close(24);
            /* Using cursor T000H27 */
            pr_default.execute(25, new Object[] {A1EstadoID});
            A2EstadoDescripcion = T000H27_A2EstadoDescripcion[0];
            AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
            A16PaisID = T000H27_A16PaisID[0];
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            pr_default.close(25);
            /* Using cursor T000H28 */
            pr_default.execute(26, new Object[] {A16PaisID});
            A17PaisDescripcion = T000H28_A17PaisDescripcion[0];
            AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
            pr_default.close(26);
            /* Using cursor T000H29 */
            pr_default.execute(27, new Object[] {A10DistribuidorID});
            A11DistribuidorDescripcion = T000H29_A11DistribuidorDescripcion[0];
            AssignAttri("", false, "A11DistribuidorDescripcion", A11DistribuidorDescripcion);
            A12DistribuidorRFC = T000H29_A12DistribuidorRFC[0];
            AssignAttri("", false, "A12DistribuidorRFC", A12DistribuidorRFC);
            pr_default.close(27);
         }
      }

      protected void EndLevel0H10( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H10( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("distribuidoresusuario",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0H0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("distribuidoresusuario",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0H10( )
      {
         /* Using cursor T000H30 */
         pr_default.execute(28);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound10 = 1;
            A81DistribuidoresUsuarioID = T000H30_A81DistribuidoresUsuarioID[0];
            AssignAttri("", false, "A81DistribuidoresUsuarioID", StringUtil.LTrimStr( (decimal)(A81DistribuidoresUsuarioID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0H10( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound10 = 1;
            A81DistribuidoresUsuarioID = T000H30_A81DistribuidoresUsuarioID[0];
            AssignAttri("", false, "A81DistribuidoresUsuarioID", StringUtil.LTrimStr( (decimal)(A81DistribuidoresUsuarioID), 9, 0));
         }
      }

      protected void ScanEnd0H10( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm0H10( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H10( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H10( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H10( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H10( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H10( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H10( )
      {
         edtDistribuidoresUsuarioID_Enabled = 0;
         AssignProp("", false, edtDistribuidoresUsuarioID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDistribuidoresUsuarioID_Enabled), 5, 0), true);
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
         edtDistribuidorID_Enabled = 0;
         AssignProp("", false, edtDistribuidorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDistribuidorID_Enabled), 5, 0), true);
         edtDistribuidorDescripcion_Enabled = 0;
         AssignProp("", false, edtDistribuidorDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDistribuidorDescripcion_Enabled), 5, 0), true);
         edtDistribuidorRFC_Enabled = 0;
         AssignProp("", false, edtDistribuidorRFC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDistribuidorRFC_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0H10( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0H0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("distribuidoresusuario.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z81DistribuidoresUsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z81DistribuidoresUsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z10DistribuidorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10DistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z29UsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("distribuidoresusuario.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "DistribuidoresUsuario" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Distribuidores Usuario", "") ;
      }

      protected void InitializeNonKey0H10( )
      {
         A52UsuarioNombreCompleto = "";
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
         A29UsuarioID = 0;
         AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
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
         A14PuestoDescripcion = "";
         AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
         A53UsuarioGenero = "";
         AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
         A54UsuarioDirectoAsociado = "";
         n54UsuarioDirectoAsociado = false;
         AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
         A55UsuarioRazonSocialAsociado = "";
         AssignAttri("", false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
         A56UsuarioNombreComercial = "";
         AssignAttri("", false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
         A57UsuarioFechaNacimiento = DateTime.MinValue;
         n57UsuarioFechaNacimiento = false;
         AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
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
         A5CiudadDescripcion = "";
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         A66UsuarioSucursal = "";
         AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
         A67UsuarioProducto = "";
         n67UsuarioProducto = false;
         AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
         A40UsuarioRol = "";
         AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
         A10DistribuidorID = 0;
         AssignAttri("", false, "A10DistribuidorID", StringUtil.LTrimStr( (decimal)(A10DistribuidorID), 9, 0));
         A11DistribuidorDescripcion = "";
         AssignAttri("", false, "A11DistribuidorDescripcion", A11DistribuidorDescripcion);
         A12DistribuidorRFC = "";
         AssignAttri("", false, "A12DistribuidorRFC", A12DistribuidorRFC);
         Z10DistribuidorID = 0;
         Z29UsuarioID = 0;
      }

      protected void InitAll0H10( )
      {
         A81DistribuidoresUsuarioID = 0;
         AssignAttri("", false, "A81DistribuidoresUsuarioID", StringUtil.LTrimStr( (decimal)(A81DistribuidoresUsuarioID), 9, 0));
         InitializeNonKey0H10( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025102815462377", true, true);
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
         context.AddJavascriptSource("distribuidoresusuario.js", "?2025102815462377", false, true);
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
         edtDistribuidoresUsuarioID_Internalname = "DISTRIBUIDORESUSUARIOID";
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
         edtDistribuidorID_Internalname = "DISTRIBUIDORID";
         edtDistribuidorDescripcion_Internalname = "DISTRIBUIDORDESCRIPCION";
         edtDistribuidorRFC_Internalname = "DISTRIBUIDORRFC";
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
         Form.Caption = context.GetMessage( "Distribuidores Usuario", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtDistribuidorRFC_Jsonclick = "";
         edtDistribuidorRFC_Enabled = 0;
         edtDistribuidorDescripcion_Jsonclick = "";
         edtDistribuidorDescripcion_Enabled = 0;
         edtDistribuidorID_Jsonclick = "";
         edtDistribuidorID_Enabled = 1;
         cmbUsuarioRol_Jsonclick = "";
         cmbUsuarioRol.Enabled = 0;
         cmbUsuarioProducto_Jsonclick = "";
         cmbUsuarioProducto.Enabled = 0;
         edtUsuarioSucursal_Jsonclick = "";
         edtUsuarioSucursal_Enabled = 0;
         edtCiudadDescripcion_Jsonclick = "";
         edtCiudadDescripcion_Enabled = 0;
         edtCiudadID_Jsonclick = "";
         edtCiudadID_Enabled = 0;
         edtEstadoDescripcion_Jsonclick = "";
         edtEstadoDescripcion_Enabled = 0;
         edtEstadoID_Jsonclick = "";
         edtEstadoID_Enabled = 0;
         edtPaisDescripcion_Jsonclick = "";
         edtPaisDescripcion_Enabled = 0;
         edtPaisID_Jsonclick = "";
         edtPaisID_Enabled = 0;
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
         edtPuestoID_Jsonclick = "";
         edtPuestoID_Enabled = 0;
         edtUsuarioKey_Jsonclick = "";
         edtUsuarioKey_Enabled = 0;
         edtUsuarioPass_Jsonclick = "";
         edtUsuarioPass_Enabled = 0;
         edtUsuarioCorreo_Jsonclick = "";
         edtUsuarioCorreo_Enabled = 0;
         edtUsuarioNombreCompleto_Jsonclick = "";
         edtUsuarioNombreCompleto_Enabled = 0;
         edtUsuarioApellido_Jsonclick = "";
         edtUsuarioApellido_Enabled = 0;
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioNombre_Enabled = 0;
         edtUsuarioID_Jsonclick = "";
         edtUsuarioID_Enabled = 1;
         edtDistribuidoresUsuarioID_Jsonclick = "";
         edtDistribuidoresUsuarioID_Enabled = 1;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtUsuarioID_Internalname;
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

      public void Valid_Distribuidoresusuarioid( )
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
         /*  Sending validation outputs */
         AssignAttri("", false, "A29UsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, ".", "")));
         AssignAttri("", false, "A10DistribuidorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10DistribuidorID), 9, 0, ".", "")));
         AssignAttri("", false, "A30UsuarioNombre", StringUtil.RTrim( A30UsuarioNombre));
         AssignAttri("", false, "A51UsuarioApellido", StringUtil.RTrim( A51UsuarioApellido));
         AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
         AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
         AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
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
         AssignAttri("", false, "A66UsuarioSucursal", StringUtil.RTrim( A66UsuarioSucursal));
         AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
         cmbUsuarioProducto.CurrentValue = StringUtil.RTrim( A67UsuarioProducto);
         AssignProp("", false, cmbUsuarioProducto_Internalname, "Values", cmbUsuarioProducto.ToJavascriptSource(), true);
         AssignAttri("", false, "A40UsuarioRol", StringUtil.RTrim( A40UsuarioRol));
         cmbUsuarioRol.CurrentValue = StringUtil.RTrim( A40UsuarioRol);
         AssignProp("", false, cmbUsuarioRol_Internalname, "Values", cmbUsuarioRol.ToJavascriptSource(), true);
         AssignAttri("", false, "A13PuestoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PuestoID), 9, 0, ".", "")));
         AssignAttri("", false, "A4CiudadID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, ".", "")));
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
         AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, ".", "")));
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         AssignAttri("", false, "A16PaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, ".", "")));
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
         AssignAttri("", false, "A11DistribuidorDescripcion", A11DistribuidorDescripcion);
         AssignAttri("", false, "A12DistribuidorRFC", StringUtil.RTrim( A12DistribuidorRFC));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z81DistribuidoresUsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z81DistribuidoresUsuarioID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z29UsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29UsuarioID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z10DistribuidorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10DistribuidorID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z30UsuarioNombre", StringUtil.RTrim( Z30UsuarioNombre));
         GxWebStd.gx_hidden_field( context, "Z51UsuarioApellido", StringUtil.RTrim( Z51UsuarioApellido));
         GxWebStd.gx_hidden_field( context, "Z31UsuarioCorreo", Z31UsuarioCorreo);
         GxWebStd.gx_hidden_field( context, "Z32UsuarioPass", Z32UsuarioPass);
         GxWebStd.gx_hidden_field( context, "Z33UsuarioKey", Z33UsuarioKey);
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
         GxWebStd.gx_hidden_field( context, "Z66UsuarioSucursal", StringUtil.RTrim( Z66UsuarioSucursal));
         GxWebStd.gx_hidden_field( context, "Z67UsuarioProducto", Z67UsuarioProducto);
         GxWebStd.gx_hidden_field( context, "Z40UsuarioRol", StringUtil.RTrim( Z40UsuarioRol));
         GxWebStd.gx_hidden_field( context, "Z13PuestoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13PuestoID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4CiudadID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4CiudadID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z52UsuarioNombreCompleto", Z52UsuarioNombreCompleto);
         GxWebStd.gx_hidden_field( context, "Z14PuestoDescripcion", Z14PuestoDescripcion);
         GxWebStd.gx_hidden_field( context, "Z5CiudadDescripcion", Z5CiudadDescripcion);
         GxWebStd.gx_hidden_field( context, "Z1EstadoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EstadoID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2EstadoDescripcion", Z2EstadoDescripcion);
         GxWebStd.gx_hidden_field( context, "Z16PaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16PaisID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z17PaisDescripcion", Z17PaisDescripcion);
         GxWebStd.gx_hidden_field( context, "Z11DistribuidorDescripcion", Z11DistribuidorDescripcion);
         GxWebStd.gx_hidden_field( context, "Z12DistribuidorRFC", StringUtil.RTrim( Z12DistribuidorRFC));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Usuarioid( )
      {
         n13PuestoID = false;
         n4CiudadID = false;
         A53UsuarioGenero = cmbUsuarioGenero.CurrentValue;
         cmbUsuarioGenero.CurrentValue = A53UsuarioGenero;
         n54UsuarioDirectoAsociado = false;
         A54UsuarioDirectoAsociado = cmbUsuarioDirectoAsociado.CurrentValue;
         n54UsuarioDirectoAsociado = false;
         cmbUsuarioDirectoAsociado.CurrentValue = A54UsuarioDirectoAsociado;
         n57UsuarioFechaNacimiento = false;
         A63UsuarioZona = cmbUsuarioZona.CurrentValue;
         cmbUsuarioZona.CurrentValue = A63UsuarioZona;
         n67UsuarioProducto = false;
         A67UsuarioProducto = cmbUsuarioProducto.CurrentValue;
         n67UsuarioProducto = false;
         cmbUsuarioProducto.CurrentValue = A67UsuarioProducto;
         A40UsuarioRol = cmbUsuarioRol.CurrentValue;
         cmbUsuarioRol.CurrentValue = A40UsuarioRol;
         /* Using cursor T000H24 */
         pr_default.execute(22, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioID_Internalname;
         }
         A30UsuarioNombre = T000H24_A30UsuarioNombre[0];
         A51UsuarioApellido = T000H24_A51UsuarioApellido[0];
         A31UsuarioCorreo = T000H24_A31UsuarioCorreo[0];
         A32UsuarioPass = T000H24_A32UsuarioPass[0];
         A33UsuarioKey = T000H24_A33UsuarioKey[0];
         A53UsuarioGenero = T000H24_A53UsuarioGenero[0];
         cmbUsuarioGenero.CurrentValue = A53UsuarioGenero;
         A54UsuarioDirectoAsociado = T000H24_A54UsuarioDirectoAsociado[0];
         n54UsuarioDirectoAsociado = T000H24_n54UsuarioDirectoAsociado[0];
         cmbUsuarioDirectoAsociado.CurrentValue = A54UsuarioDirectoAsociado;
         A55UsuarioRazonSocialAsociado = T000H24_A55UsuarioRazonSocialAsociado[0];
         A56UsuarioNombreComercial = T000H24_A56UsuarioNombreComercial[0];
         A57UsuarioFechaNacimiento = T000H24_A57UsuarioFechaNacimiento[0];
         n57UsuarioFechaNacimiento = T000H24_n57UsuarioFechaNacimiento[0];
         A59UsuarioCalleNum = T000H24_A59UsuarioCalleNum[0];
         A60UsuarioColonia = T000H24_A60UsuarioColonia[0];
         A61UsuarioDelegacion = T000H24_A61UsuarioDelegacion[0];
         A62UsuarioCP = T000H24_A62UsuarioCP[0];
         A63UsuarioZona = T000H24_A63UsuarioZona[0];
         cmbUsuarioZona.CurrentValue = A63UsuarioZona;
         A64UsuarioCelular = T000H24_A64UsuarioCelular[0];
         A65UsuarioTelefonoSucursal = T000H24_A65UsuarioTelefonoSucursal[0];
         A66UsuarioSucursal = T000H24_A66UsuarioSucursal[0];
         A67UsuarioProducto = T000H24_A67UsuarioProducto[0];
         n67UsuarioProducto = T000H24_n67UsuarioProducto[0];
         cmbUsuarioProducto.CurrentValue = A67UsuarioProducto;
         A40UsuarioRol = T000H24_A40UsuarioRol[0];
         cmbUsuarioRol.CurrentValue = A40UsuarioRol;
         A13PuestoID = T000H24_A13PuestoID[0];
         n13PuestoID = T000H24_n13PuestoID[0];
         A4CiudadID = T000H24_A4CiudadID[0];
         n4CiudadID = T000H24_n4CiudadID[0];
         pr_default.close(22);
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
         /* Using cursor T000H25 */
         pr_default.execute(23, new Object[] {n13PuestoID, A13PuestoID});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (0==A13PuestoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Puesto", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PUESTOID");
               AnyError = 1;
            }
         }
         A14PuestoDescripcion = T000H25_A14PuestoDescripcion[0];
         pr_default.close(23);
         /* Using cursor T000H26 */
         pr_default.execute(24, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
            }
         }
         A5CiudadDescripcion = T000H26_A5CiudadDescripcion[0];
         A1EstadoID = T000H26_A1EstadoID[0];
         pr_default.close(24);
         /* Using cursor T000H27 */
         pr_default.execute(25, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A2EstadoDescripcion = T000H27_A2EstadoDescripcion[0];
         A16PaisID = T000H27_A16PaisID[0];
         pr_default.close(25);
         /* Using cursor T000H28 */
         pr_default.execute(26, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(26) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = T000H28_A17PaisDescripcion[0];
         pr_default.close(26);
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
         /*  Sending validation outputs */
         AssignAttri("", false, "A30UsuarioNombre", StringUtil.RTrim( A30UsuarioNombre));
         AssignAttri("", false, "A51UsuarioApellido", StringUtil.RTrim( A51UsuarioApellido));
         AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
         AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
         AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
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
         AssignAttri("", false, "A66UsuarioSucursal", StringUtil.RTrim( A66UsuarioSucursal));
         AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
         cmbUsuarioProducto.CurrentValue = StringUtil.RTrim( A67UsuarioProducto);
         AssignProp("", false, cmbUsuarioProducto_Internalname, "Values", cmbUsuarioProducto.ToJavascriptSource(), true);
         AssignAttri("", false, "A40UsuarioRol", StringUtil.RTrim( A40UsuarioRol));
         cmbUsuarioRol.CurrentValue = StringUtil.RTrim( A40UsuarioRol);
         AssignProp("", false, cmbUsuarioRol_Internalname, "Values", cmbUsuarioRol.ToJavascriptSource(), true);
         AssignAttri("", false, "A13PuestoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PuestoID), 9, 0, ".", "")));
         AssignAttri("", false, "A4CiudadID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, ".", "")));
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
         AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, ".", "")));
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         AssignAttri("", false, "A16PaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, ".", "")));
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
      }

      public void Valid_Distribuidorid( )
      {
         /* Using cursor T000H29 */
         pr_default.execute(27, new Object[] {A10DistribuidorID});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Distribuidor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DISTRIBUIDORID");
            AnyError = 1;
            GX_FocusControl = edtDistribuidorID_Internalname;
         }
         A11DistribuidorDescripcion = T000H29_A11DistribuidorDescripcion[0];
         A12DistribuidorRFC = T000H29_A12DistribuidorRFC[0];
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A11DistribuidorDescripcion", A11DistribuidorDescripcion);
         AssignAttri("", false, "A12DistribuidorRFC", StringUtil.RTrim( A12DistribuidorRFC));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_DISTRIBUIDORESUSUARIOID","""{"handler":"Valid_Distribuidoresusuarioid","iparms":[{"av":"cmbUsuarioRol"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"cmbUsuarioProducto"},{"av":"A67UsuarioProducto","fld":"USUARIOPRODUCTO"},{"av":"cmbUsuarioZona"},{"av":"A63UsuarioZona","fld":"USUARIOZONA"},{"av":"cmbUsuarioDirectoAsociado"},{"av":"A54UsuarioDirectoAsociado","fld":"USUARIODIRECTOASOCIADO"},{"av":"cmbUsuarioGenero"},{"av":"A53UsuarioGenero","fld":"USUARIOGENERO"},{"av":"A81DistribuidoresUsuarioID","fld":"DISTRIBUIDORESUSUARIOID","pic":"ZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_DISTRIBUIDORESUSUARIOID",""","oparms":[{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"A30UsuarioNombre","fld":"USUARIONOMBRE"},{"av":"A51UsuarioApellido","fld":"USUARIOAPELLIDO"},{"av":"A31UsuarioCorreo","fld":"USUARIOCORREO"},{"av":"A32UsuarioPass","fld":"USUARIOPASS"},{"av":"A33UsuarioKey","fld":"USUARIOKEY"},{"av":"cmbUsuarioGenero"},{"av":"A53UsuarioGenero","fld":"USUARIOGENERO"},{"av":"cmbUsuarioDirectoAsociado"},{"av":"A54UsuarioDirectoAsociado","fld":"USUARIODIRECTOASOCIADO"},{"av":"A55UsuarioRazonSocialAsociado","fld":"USUARIORAZONSOCIALASOCIADO"},{"av":"A56UsuarioNombreComercial","fld":"USUARIONOMBRECOMERCIAL"},{"av":"A57UsuarioFechaNacimiento","fld":"USUARIOFECHANACIMIENTO"},{"av":"A59UsuarioCalleNum","fld":"USUARIOCALLENUM"},{"av":"A60UsuarioColonia","fld":"USUARIOCOLONIA"},{"av":"A61UsuarioDelegacion","fld":"USUARIODELEGACION"},{"av":"A62UsuarioCP","fld":"USUARIOCP","pic":"ZZZZ9"},{"av":"cmbUsuarioZona"},{"av":"A63UsuarioZona","fld":"USUARIOZONA"},{"av":"A64UsuarioCelular","fld":"USUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"A65UsuarioTelefonoSucursal","fld":"USUARIOTELEFONOSUCURSAL","pic":"ZZZZZZZZZ9"},{"av":"A66UsuarioSucursal","fld":"USUARIOSUCURSAL"},{"av":"cmbUsuarioProducto"},{"av":"A67UsuarioProducto","fld":"USUARIOPRODUCTO"},{"av":"cmbUsuarioRol"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A13PuestoID","fld":"PUESTOID","pic":"ZZZZZZZZ9"},{"av":"A4CiudadID","fld":"CIUDADID","pic":"ZZZZZZZZ9"},{"av":"A52UsuarioNombreCompleto","fld":"USUARIONOMBRECOMPLETO"},{"av":"A14PuestoDescripcion","fld":"PUESTODESCRIPCION"},{"av":"A5CiudadDescripcion","fld":"CIUDADDESCRIPCION"},{"av":"A1EstadoID","fld":"ESTADOID","pic":"ZZZZZZZZ9"},{"av":"A2EstadoDescripcion","fld":"ESTADODESCRIPCION"},{"av":"A16PaisID","fld":"PAISID","pic":"ZZZZZZZZ9"},{"av":"A17PaisDescripcion","fld":"PAISDESCRIPCION"},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"A12DistribuidorRFC","fld":"DISTRIBUIDORRFC"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z81DistribuidoresUsuarioID"},{"av":"Z29UsuarioID"},{"av":"Z10DistribuidorID"},{"av":"Z30UsuarioNombre"},{"av":"Z51UsuarioApellido"},{"av":"Z31UsuarioCorreo"},{"av":"Z32UsuarioPass"},{"av":"Z33UsuarioKey"},{"av":"Z53UsuarioGenero"},{"av":"Z54UsuarioDirectoAsociado"},{"av":"Z55UsuarioRazonSocialAsociado"},{"av":"Z56UsuarioNombreComercial"},{"av":"Z57UsuarioFechaNacimiento"},{"av":"Z59UsuarioCalleNum"},{"av":"Z60UsuarioColonia"},{"av":"Z61UsuarioDelegacion"},{"av":"Z62UsuarioCP"},{"av":"Z63UsuarioZona"},{"av":"Z64UsuarioCelular"},{"av":"Z65UsuarioTelefonoSucursal"},{"av":"Z66UsuarioSucursal"},{"av":"Z67UsuarioProducto"},{"av":"Z40UsuarioRol"},{"av":"Z13PuestoID"},{"av":"Z4CiudadID"},{"av":"Z52UsuarioNombreCompleto"},{"av":"Z14PuestoDescripcion"},{"av":"Z5CiudadDescripcion"},{"av":"Z1EstadoID"},{"av":"Z2EstadoDescripcion"},{"av":"Z16PaisID"},{"av":"Z17PaisDescripcion"},{"av":"Z11DistribuidorDescripcion"},{"av":"Z12DistribuidorRFC"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_USUARIOID","""{"handler":"Valid_Usuarioid","iparms":[{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9"},{"av":"A30UsuarioNombre","fld":"USUARIONOMBRE"},{"av":"A51UsuarioApellido","fld":"USUARIOAPELLIDO"},{"av":"A13PuestoID","fld":"PUESTOID","pic":"ZZZZZZZZ9"},{"av":"A4CiudadID","fld":"CIUDADID","pic":"ZZZZZZZZ9"},{"av":"A1EstadoID","fld":"ESTADOID","pic":"ZZZZZZZZ9"},{"av":"A16PaisID","fld":"PAISID","pic":"ZZZZZZZZ9"},{"av":"A31UsuarioCorreo","fld":"USUARIOCORREO"},{"av":"A32UsuarioPass","fld":"USUARIOPASS"},{"av":"A33UsuarioKey","fld":"USUARIOKEY"},{"av":"cmbUsuarioGenero"},{"av":"A53UsuarioGenero","fld":"USUARIOGENERO"},{"av":"cmbUsuarioDirectoAsociado"},{"av":"A54UsuarioDirectoAsociado","fld":"USUARIODIRECTOASOCIADO"},{"av":"A55UsuarioRazonSocialAsociado","fld":"USUARIORAZONSOCIALASOCIADO"},{"av":"A56UsuarioNombreComercial","fld":"USUARIONOMBRECOMERCIAL"},{"av":"A57UsuarioFechaNacimiento","fld":"USUARIOFECHANACIMIENTO"},{"av":"A59UsuarioCalleNum","fld":"USUARIOCALLENUM"},{"av":"A60UsuarioColonia","fld":"USUARIOCOLONIA"},{"av":"A61UsuarioDelegacion","fld":"USUARIODELEGACION"},{"av":"A62UsuarioCP","fld":"USUARIOCP","pic":"ZZZZ9"},{"av":"cmbUsuarioZona"},{"av":"A63UsuarioZona","fld":"USUARIOZONA"},{"av":"A64UsuarioCelular","fld":"USUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"A65UsuarioTelefonoSucursal","fld":"USUARIOTELEFONOSUCURSAL","pic":"ZZZZZZZZZ9"},{"av":"A66UsuarioSucursal","fld":"USUARIOSUCURSAL"},{"av":"cmbUsuarioProducto"},{"av":"A67UsuarioProducto","fld":"USUARIOPRODUCTO"},{"av":"cmbUsuarioRol"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A52UsuarioNombreCompleto","fld":"USUARIONOMBRECOMPLETO"},{"av":"A14PuestoDescripcion","fld":"PUESTODESCRIPCION"},{"av":"A5CiudadDescripcion","fld":"CIUDADDESCRIPCION"},{"av":"A2EstadoDescripcion","fld":"ESTADODESCRIPCION"},{"av":"A17PaisDescripcion","fld":"PAISDESCRIPCION"}]""");
         setEventMetadata("VALID_USUARIOID",""","oparms":[{"av":"A30UsuarioNombre","fld":"USUARIONOMBRE"},{"av":"A51UsuarioApellido","fld":"USUARIOAPELLIDO"},{"av":"A31UsuarioCorreo","fld":"USUARIOCORREO"},{"av":"A32UsuarioPass","fld":"USUARIOPASS"},{"av":"A33UsuarioKey","fld":"USUARIOKEY"},{"av":"cmbUsuarioGenero"},{"av":"A53UsuarioGenero","fld":"USUARIOGENERO"},{"av":"cmbUsuarioDirectoAsociado"},{"av":"A54UsuarioDirectoAsociado","fld":"USUARIODIRECTOASOCIADO"},{"av":"A55UsuarioRazonSocialAsociado","fld":"USUARIORAZONSOCIALASOCIADO"},{"av":"A56UsuarioNombreComercial","fld":"USUARIONOMBRECOMERCIAL"},{"av":"A57UsuarioFechaNacimiento","fld":"USUARIOFECHANACIMIENTO"},{"av":"A59UsuarioCalleNum","fld":"USUARIOCALLENUM"},{"av":"A60UsuarioColonia","fld":"USUARIOCOLONIA"},{"av":"A61UsuarioDelegacion","fld":"USUARIODELEGACION"},{"av":"A62UsuarioCP","fld":"USUARIOCP","pic":"ZZZZ9"},{"av":"cmbUsuarioZona"},{"av":"A63UsuarioZona","fld":"USUARIOZONA"},{"av":"A64UsuarioCelular","fld":"USUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"A65UsuarioTelefonoSucursal","fld":"USUARIOTELEFONOSUCURSAL","pic":"ZZZZZZZZZ9"},{"av":"A66UsuarioSucursal","fld":"USUARIOSUCURSAL"},{"av":"cmbUsuarioProducto"},{"av":"A67UsuarioProducto","fld":"USUARIOPRODUCTO"},{"av":"cmbUsuarioRol"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A13PuestoID","fld":"PUESTOID","pic":"ZZZZZZZZ9"},{"av":"A4CiudadID","fld":"CIUDADID","pic":"ZZZZZZZZ9"},{"av":"A52UsuarioNombreCompleto","fld":"USUARIONOMBRECOMPLETO"},{"av":"A14PuestoDescripcion","fld":"PUESTODESCRIPCION"},{"av":"A5CiudadDescripcion","fld":"CIUDADDESCRIPCION"},{"av":"A1EstadoID","fld":"ESTADOID","pic":"ZZZZZZZZ9"},{"av":"A2EstadoDescripcion","fld":"ESTADODESCRIPCION"},{"av":"A16PaisID","fld":"PAISID","pic":"ZZZZZZZZ9"},{"av":"A17PaisDescripcion","fld":"PAISDESCRIPCION"}]}""");
         setEventMetadata("VALID_USUARIONOMBRE","""{"handler":"Valid_Usuarionombre","iparms":[]}""");
         setEventMetadata("VALID_USUARIOAPELLIDO","""{"handler":"Valid_Usuarioapellido","iparms":[]}""");
         setEventMetadata("VALID_PUESTOID","""{"handler":"Valid_Puestoid","iparms":[]}""");
         setEventMetadata("VALID_PAISID","""{"handler":"Valid_Paisid","iparms":[]}""");
         setEventMetadata("VALID_ESTADOID","""{"handler":"Valid_Estadoid","iparms":[]}""");
         setEventMetadata("VALID_CIUDADID","""{"handler":"Valid_Ciudadid","iparms":[]}""");
         setEventMetadata("VALID_DISTRIBUIDORID","""{"handler":"Valid_Distribuidorid","iparms":[{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"A12DistribuidorRFC","fld":"DISTRIBUIDORRFC"}]""");
         setEventMetadata("VALID_DISTRIBUIDORID",""","oparms":[{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"A12DistribuidorRFC","fld":"DISTRIBUIDORRFC"}]}""");
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
         pr_default.close(27);
         pr_default.close(22);
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(25);
         pr_default.close(26);
      }

      public override void initialize( )
      {
         sPrefix = "";
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
         A11DistribuidorDescripcion = "";
         A12DistribuidorRFC = "";
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
         Z14PuestoDescripcion = "";
         Z5CiudadDescripcion = "";
         Z2EstadoDescripcion = "";
         Z17PaisDescripcion = "";
         Z11DistribuidorDescripcion = "";
         Z12DistribuidorRFC = "";
         T000H10_A81DistribuidoresUsuarioID = new int[1] ;
         T000H10_A30UsuarioNombre = new string[] {""} ;
         T000H10_A51UsuarioApellido = new string[] {""} ;
         T000H10_A31UsuarioCorreo = new string[] {""} ;
         T000H10_A32UsuarioPass = new string[] {""} ;
         T000H10_A33UsuarioKey = new string[] {""} ;
         T000H10_A14PuestoDescripcion = new string[] {""} ;
         T000H10_A53UsuarioGenero = new string[] {""} ;
         T000H10_A54UsuarioDirectoAsociado = new string[] {""} ;
         T000H10_n54UsuarioDirectoAsociado = new bool[] {false} ;
         T000H10_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         T000H10_A56UsuarioNombreComercial = new string[] {""} ;
         T000H10_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T000H10_n57UsuarioFechaNacimiento = new bool[] {false} ;
         T000H10_A59UsuarioCalleNum = new string[] {""} ;
         T000H10_A60UsuarioColonia = new string[] {""} ;
         T000H10_A61UsuarioDelegacion = new string[] {""} ;
         T000H10_A62UsuarioCP = new int[1] ;
         T000H10_A63UsuarioZona = new string[] {""} ;
         T000H10_A64UsuarioCelular = new long[1] ;
         T000H10_A65UsuarioTelefonoSucursal = new long[1] ;
         T000H10_A17PaisDescripcion = new string[] {""} ;
         T000H10_A2EstadoDescripcion = new string[] {""} ;
         T000H10_A5CiudadDescripcion = new string[] {""} ;
         T000H10_A66UsuarioSucursal = new string[] {""} ;
         T000H10_A67UsuarioProducto = new string[] {""} ;
         T000H10_n67UsuarioProducto = new bool[] {false} ;
         T000H10_A40UsuarioRol = new string[] {""} ;
         T000H10_A11DistribuidorDescripcion = new string[] {""} ;
         T000H10_A12DistribuidorRFC = new string[] {""} ;
         T000H10_A10DistribuidorID = new int[1] ;
         T000H10_A29UsuarioID = new int[1] ;
         T000H10_A13PuestoID = new int[1] ;
         T000H10_n13PuestoID = new bool[] {false} ;
         T000H10_A4CiudadID = new int[1] ;
         T000H10_n4CiudadID = new bool[] {false} ;
         T000H10_A1EstadoID = new int[1] ;
         T000H10_A16PaisID = new int[1] ;
         T000H5_A30UsuarioNombre = new string[] {""} ;
         T000H5_A51UsuarioApellido = new string[] {""} ;
         T000H5_A31UsuarioCorreo = new string[] {""} ;
         T000H5_A32UsuarioPass = new string[] {""} ;
         T000H5_A33UsuarioKey = new string[] {""} ;
         T000H5_A53UsuarioGenero = new string[] {""} ;
         T000H5_A54UsuarioDirectoAsociado = new string[] {""} ;
         T000H5_n54UsuarioDirectoAsociado = new bool[] {false} ;
         T000H5_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         T000H5_A56UsuarioNombreComercial = new string[] {""} ;
         T000H5_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T000H5_n57UsuarioFechaNacimiento = new bool[] {false} ;
         T000H5_A59UsuarioCalleNum = new string[] {""} ;
         T000H5_A60UsuarioColonia = new string[] {""} ;
         T000H5_A61UsuarioDelegacion = new string[] {""} ;
         T000H5_A62UsuarioCP = new int[1] ;
         T000H5_A63UsuarioZona = new string[] {""} ;
         T000H5_A64UsuarioCelular = new long[1] ;
         T000H5_A65UsuarioTelefonoSucursal = new long[1] ;
         T000H5_A66UsuarioSucursal = new string[] {""} ;
         T000H5_A67UsuarioProducto = new string[] {""} ;
         T000H5_n67UsuarioProducto = new bool[] {false} ;
         T000H5_A40UsuarioRol = new string[] {""} ;
         T000H5_A13PuestoID = new int[1] ;
         T000H5_n13PuestoID = new bool[] {false} ;
         T000H5_A4CiudadID = new int[1] ;
         T000H5_n4CiudadID = new bool[] {false} ;
         T000H6_A14PuestoDescripcion = new string[] {""} ;
         T000H7_A5CiudadDescripcion = new string[] {""} ;
         T000H7_A1EstadoID = new int[1] ;
         T000H8_A2EstadoDescripcion = new string[] {""} ;
         T000H8_A16PaisID = new int[1] ;
         T000H9_A17PaisDescripcion = new string[] {""} ;
         T000H4_A11DistribuidorDescripcion = new string[] {""} ;
         T000H4_A12DistribuidorRFC = new string[] {""} ;
         T000H11_A30UsuarioNombre = new string[] {""} ;
         T000H11_A51UsuarioApellido = new string[] {""} ;
         T000H11_A31UsuarioCorreo = new string[] {""} ;
         T000H11_A32UsuarioPass = new string[] {""} ;
         T000H11_A33UsuarioKey = new string[] {""} ;
         T000H11_A53UsuarioGenero = new string[] {""} ;
         T000H11_A54UsuarioDirectoAsociado = new string[] {""} ;
         T000H11_n54UsuarioDirectoAsociado = new bool[] {false} ;
         T000H11_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         T000H11_A56UsuarioNombreComercial = new string[] {""} ;
         T000H11_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T000H11_n57UsuarioFechaNacimiento = new bool[] {false} ;
         T000H11_A59UsuarioCalleNum = new string[] {""} ;
         T000H11_A60UsuarioColonia = new string[] {""} ;
         T000H11_A61UsuarioDelegacion = new string[] {""} ;
         T000H11_A62UsuarioCP = new int[1] ;
         T000H11_A63UsuarioZona = new string[] {""} ;
         T000H11_A64UsuarioCelular = new long[1] ;
         T000H11_A65UsuarioTelefonoSucursal = new long[1] ;
         T000H11_A66UsuarioSucursal = new string[] {""} ;
         T000H11_A67UsuarioProducto = new string[] {""} ;
         T000H11_n67UsuarioProducto = new bool[] {false} ;
         T000H11_A40UsuarioRol = new string[] {""} ;
         T000H11_A13PuestoID = new int[1] ;
         T000H11_n13PuestoID = new bool[] {false} ;
         T000H11_A4CiudadID = new int[1] ;
         T000H11_n4CiudadID = new bool[] {false} ;
         T000H12_A14PuestoDescripcion = new string[] {""} ;
         T000H13_A5CiudadDescripcion = new string[] {""} ;
         T000H13_A1EstadoID = new int[1] ;
         T000H14_A2EstadoDescripcion = new string[] {""} ;
         T000H14_A16PaisID = new int[1] ;
         T000H15_A17PaisDescripcion = new string[] {""} ;
         T000H16_A11DistribuidorDescripcion = new string[] {""} ;
         T000H16_A12DistribuidorRFC = new string[] {""} ;
         T000H17_A81DistribuidoresUsuarioID = new int[1] ;
         T000H3_A81DistribuidoresUsuarioID = new int[1] ;
         T000H3_A10DistribuidorID = new int[1] ;
         T000H3_A29UsuarioID = new int[1] ;
         sMode10 = "";
         T000H18_A81DistribuidoresUsuarioID = new int[1] ;
         T000H19_A81DistribuidoresUsuarioID = new int[1] ;
         T000H2_A81DistribuidoresUsuarioID = new int[1] ;
         T000H2_A10DistribuidorID = new int[1] ;
         T000H2_A29UsuarioID = new int[1] ;
         T000H21_A81DistribuidoresUsuarioID = new int[1] ;
         T000H24_A30UsuarioNombre = new string[] {""} ;
         T000H24_A51UsuarioApellido = new string[] {""} ;
         T000H24_A31UsuarioCorreo = new string[] {""} ;
         T000H24_A32UsuarioPass = new string[] {""} ;
         T000H24_A33UsuarioKey = new string[] {""} ;
         T000H24_A53UsuarioGenero = new string[] {""} ;
         T000H24_A54UsuarioDirectoAsociado = new string[] {""} ;
         T000H24_n54UsuarioDirectoAsociado = new bool[] {false} ;
         T000H24_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         T000H24_A56UsuarioNombreComercial = new string[] {""} ;
         T000H24_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T000H24_n57UsuarioFechaNacimiento = new bool[] {false} ;
         T000H24_A59UsuarioCalleNum = new string[] {""} ;
         T000H24_A60UsuarioColonia = new string[] {""} ;
         T000H24_A61UsuarioDelegacion = new string[] {""} ;
         T000H24_A62UsuarioCP = new int[1] ;
         T000H24_A63UsuarioZona = new string[] {""} ;
         T000H24_A64UsuarioCelular = new long[1] ;
         T000H24_A65UsuarioTelefonoSucursal = new long[1] ;
         T000H24_A66UsuarioSucursal = new string[] {""} ;
         T000H24_A67UsuarioProducto = new string[] {""} ;
         T000H24_n67UsuarioProducto = new bool[] {false} ;
         T000H24_A40UsuarioRol = new string[] {""} ;
         T000H24_A13PuestoID = new int[1] ;
         T000H24_n13PuestoID = new bool[] {false} ;
         T000H24_A4CiudadID = new int[1] ;
         T000H24_n4CiudadID = new bool[] {false} ;
         T000H25_A14PuestoDescripcion = new string[] {""} ;
         T000H26_A5CiudadDescripcion = new string[] {""} ;
         T000H26_A1EstadoID = new int[1] ;
         T000H27_A2EstadoDescripcion = new string[] {""} ;
         T000H27_A16PaisID = new int[1] ;
         T000H28_A17PaisDescripcion = new string[] {""} ;
         T000H29_A11DistribuidorDescripcion = new string[] {""} ;
         T000H29_A12DistribuidorRFC = new string[] {""} ;
         T000H30_A81DistribuidoresUsuarioID = new int[1] ;
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
         ZZ52UsuarioNombreCompleto = "";
         ZZ14PuestoDescripcion = "";
         ZZ5CiudadDescripcion = "";
         ZZ2EstadoDescripcion = "";
         ZZ17PaisDescripcion = "";
         ZZ11DistribuidorDescripcion = "";
         ZZ12DistribuidorRFC = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.distribuidoresusuario__default(),
            new Object[][] {
                new Object[] {
               T000H2_A81DistribuidoresUsuarioID, T000H2_A10DistribuidorID, T000H2_A29UsuarioID
               }
               , new Object[] {
               T000H3_A81DistribuidoresUsuarioID, T000H3_A10DistribuidorID, T000H3_A29UsuarioID
               }
               , new Object[] {
               T000H4_A11DistribuidorDescripcion, T000H4_A12DistribuidorRFC
               }
               , new Object[] {
               T000H5_A30UsuarioNombre, T000H5_A51UsuarioApellido, T000H5_A31UsuarioCorreo, T000H5_A32UsuarioPass, T000H5_A33UsuarioKey, T000H5_A53UsuarioGenero, T000H5_A54UsuarioDirectoAsociado, T000H5_n54UsuarioDirectoAsociado, T000H5_A55UsuarioRazonSocialAsociado, T000H5_A56UsuarioNombreComercial,
               T000H5_A57UsuarioFechaNacimiento, T000H5_n57UsuarioFechaNacimiento, T000H5_A59UsuarioCalleNum, T000H5_A60UsuarioColonia, T000H5_A61UsuarioDelegacion, T000H5_A62UsuarioCP, T000H5_A63UsuarioZona, T000H5_A64UsuarioCelular, T000H5_A65UsuarioTelefonoSucursal, T000H5_A66UsuarioSucursal,
               T000H5_A67UsuarioProducto, T000H5_n67UsuarioProducto, T000H5_A40UsuarioRol, T000H5_A13PuestoID, T000H5_n13PuestoID, T000H5_A4CiudadID, T000H5_n4CiudadID
               }
               , new Object[] {
               T000H6_A14PuestoDescripcion
               }
               , new Object[] {
               T000H7_A5CiudadDescripcion, T000H7_A1EstadoID
               }
               , new Object[] {
               T000H8_A2EstadoDescripcion, T000H8_A16PaisID
               }
               , new Object[] {
               T000H9_A17PaisDescripcion
               }
               , new Object[] {
               T000H10_A81DistribuidoresUsuarioID, T000H10_A30UsuarioNombre, T000H10_A51UsuarioApellido, T000H10_A31UsuarioCorreo, T000H10_A32UsuarioPass, T000H10_A33UsuarioKey, T000H10_A14PuestoDescripcion, T000H10_A53UsuarioGenero, T000H10_A54UsuarioDirectoAsociado, T000H10_n54UsuarioDirectoAsociado,
               T000H10_A55UsuarioRazonSocialAsociado, T000H10_A56UsuarioNombreComercial, T000H10_A57UsuarioFechaNacimiento, T000H10_n57UsuarioFechaNacimiento, T000H10_A59UsuarioCalleNum, T000H10_A60UsuarioColonia, T000H10_A61UsuarioDelegacion, T000H10_A62UsuarioCP, T000H10_A63UsuarioZona, T000H10_A64UsuarioCelular,
               T000H10_A65UsuarioTelefonoSucursal, T000H10_A17PaisDescripcion, T000H10_A2EstadoDescripcion, T000H10_A5CiudadDescripcion, T000H10_A66UsuarioSucursal, T000H10_A67UsuarioProducto, T000H10_n67UsuarioProducto, T000H10_A40UsuarioRol, T000H10_A11DistribuidorDescripcion, T000H10_A12DistribuidorRFC,
               T000H10_A10DistribuidorID, T000H10_A29UsuarioID, T000H10_A13PuestoID, T000H10_n13PuestoID, T000H10_A4CiudadID, T000H10_n4CiudadID, T000H10_A1EstadoID, T000H10_A16PaisID
               }
               , new Object[] {
               T000H11_A30UsuarioNombre, T000H11_A51UsuarioApellido, T000H11_A31UsuarioCorreo, T000H11_A32UsuarioPass, T000H11_A33UsuarioKey, T000H11_A53UsuarioGenero, T000H11_A54UsuarioDirectoAsociado, T000H11_n54UsuarioDirectoAsociado, T000H11_A55UsuarioRazonSocialAsociado, T000H11_A56UsuarioNombreComercial,
               T000H11_A57UsuarioFechaNacimiento, T000H11_n57UsuarioFechaNacimiento, T000H11_A59UsuarioCalleNum, T000H11_A60UsuarioColonia, T000H11_A61UsuarioDelegacion, T000H11_A62UsuarioCP, T000H11_A63UsuarioZona, T000H11_A64UsuarioCelular, T000H11_A65UsuarioTelefonoSucursal, T000H11_A66UsuarioSucursal,
               T000H11_A67UsuarioProducto, T000H11_n67UsuarioProducto, T000H11_A40UsuarioRol, T000H11_A13PuestoID, T000H11_n13PuestoID, T000H11_A4CiudadID, T000H11_n4CiudadID
               }
               , new Object[] {
               T000H12_A14PuestoDescripcion
               }
               , new Object[] {
               T000H13_A5CiudadDescripcion, T000H13_A1EstadoID
               }
               , new Object[] {
               T000H14_A2EstadoDescripcion, T000H14_A16PaisID
               }
               , new Object[] {
               T000H15_A17PaisDescripcion
               }
               , new Object[] {
               T000H16_A11DistribuidorDescripcion, T000H16_A12DistribuidorRFC
               }
               , new Object[] {
               T000H17_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               T000H18_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               T000H19_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               }
               , new Object[] {
               T000H21_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000H24_A30UsuarioNombre, T000H24_A51UsuarioApellido, T000H24_A31UsuarioCorreo, T000H24_A32UsuarioPass, T000H24_A33UsuarioKey, T000H24_A53UsuarioGenero, T000H24_A54UsuarioDirectoAsociado, T000H24_n54UsuarioDirectoAsociado, T000H24_A55UsuarioRazonSocialAsociado, T000H24_A56UsuarioNombreComercial,
               T000H24_A57UsuarioFechaNacimiento, T000H24_n57UsuarioFechaNacimiento, T000H24_A59UsuarioCalleNum, T000H24_A60UsuarioColonia, T000H24_A61UsuarioDelegacion, T000H24_A62UsuarioCP, T000H24_A63UsuarioZona, T000H24_A64UsuarioCelular, T000H24_A65UsuarioTelefonoSucursal, T000H24_A66UsuarioSucursal,
               T000H24_A67UsuarioProducto, T000H24_n67UsuarioProducto, T000H24_A40UsuarioRol, T000H24_A13PuestoID, T000H24_n13PuestoID, T000H24_A4CiudadID, T000H24_n4CiudadID
               }
               , new Object[] {
               T000H25_A14PuestoDescripcion
               }
               , new Object[] {
               T000H26_A5CiudadDescripcion, T000H26_A1EstadoID
               }
               , new Object[] {
               T000H27_A2EstadoDescripcion, T000H27_A16PaisID
               }
               , new Object[] {
               T000H28_A17PaisDescripcion
               }
               , new Object[] {
               T000H29_A11DistribuidorDescripcion, T000H29_A12DistribuidorRFC
               }
               , new Object[] {
               T000H30_A81DistribuidoresUsuarioID
               }
            }
         );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound10 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z81DistribuidoresUsuarioID ;
      private int Z10DistribuidorID ;
      private int Z29UsuarioID ;
      private int A29UsuarioID ;
      private int A13PuestoID ;
      private int A4CiudadID ;
      private int A1EstadoID ;
      private int A16PaisID ;
      private int A10DistribuidorID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A81DistribuidoresUsuarioID ;
      private int edtDistribuidoresUsuarioID_Enabled ;
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
      private int edtDistribuidorID_Enabled ;
      private int edtDistribuidorDescripcion_Enabled ;
      private int edtDistribuidorRFC_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int Z62UsuarioCP ;
      private int Z13PuestoID ;
      private int Z4CiudadID ;
      private int Z1EstadoID ;
      private int Z16PaisID ;
      private int idxLst ;
      private int ZZ81DistribuidoresUsuarioID ;
      private int ZZ29UsuarioID ;
      private int ZZ10DistribuidorID ;
      private int ZZ62UsuarioCP ;
      private int ZZ13PuestoID ;
      private int ZZ4CiudadID ;
      private int ZZ1EstadoID ;
      private int ZZ16PaisID ;
      private long A64UsuarioCelular ;
      private long A65UsuarioTelefonoSucursal ;
      private long Z64UsuarioCelular ;
      private long Z65UsuarioTelefonoSucursal ;
      private long ZZ64UsuarioCelular ;
      private long ZZ65UsuarioTelefonoSucursal ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtDistribuidoresUsuarioID_Internalname ;
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
      private string edtDistribuidoresUsuarioID_Jsonclick ;
      private string edtUsuarioID_Internalname ;
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
      private string edtDistribuidorID_Internalname ;
      private string edtDistribuidorID_Jsonclick ;
      private string edtDistribuidorDescripcion_Internalname ;
      private string edtDistribuidorDescripcion_Jsonclick ;
      private string edtDistribuidorRFC_Internalname ;
      private string A12DistribuidorRFC ;
      private string edtDistribuidorRFC_Jsonclick ;
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
      private string Z12DistribuidorRFC ;
      private string sMode10 ;
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
      private string ZZ12DistribuidorRFC ;
      private DateTime A57UsuarioFechaNacimiento ;
      private DateTime Z57UsuarioFechaNacimiento ;
      private DateTime ZZ57UsuarioFechaNacimiento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n13PuestoID ;
      private bool n4CiudadID ;
      private bool wbErr ;
      private bool n54UsuarioDirectoAsociado ;
      private bool n67UsuarioProducto ;
      private bool n57UsuarioFechaNacimiento ;
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
      private string A11DistribuidorDescripcion ;
      private string Z31UsuarioCorreo ;
      private string Z32UsuarioPass ;
      private string Z33UsuarioKey ;
      private string Z55UsuarioRazonSocialAsociado ;
      private string Z56UsuarioNombreComercial ;
      private string Z67UsuarioProducto ;
      private string Z14PuestoDescripcion ;
      private string Z5CiudadDescripcion ;
      private string Z2EstadoDescripcion ;
      private string Z17PaisDescripcion ;
      private string Z11DistribuidorDescripcion ;
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
      private string ZZ11DistribuidorDescripcion ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbUsuarioGenero ;
      private GXCombobox cmbUsuarioDirectoAsociado ;
      private GXCombobox cmbUsuarioZona ;
      private GXCombobox cmbUsuarioProducto ;
      private GXCombobox cmbUsuarioRol ;
      private IDataStoreProvider pr_default ;
      private int[] T000H10_A81DistribuidoresUsuarioID ;
      private string[] T000H10_A30UsuarioNombre ;
      private string[] T000H10_A51UsuarioApellido ;
      private string[] T000H10_A31UsuarioCorreo ;
      private string[] T000H10_A32UsuarioPass ;
      private string[] T000H10_A33UsuarioKey ;
      private string[] T000H10_A14PuestoDescripcion ;
      private string[] T000H10_A53UsuarioGenero ;
      private string[] T000H10_A54UsuarioDirectoAsociado ;
      private bool[] T000H10_n54UsuarioDirectoAsociado ;
      private string[] T000H10_A55UsuarioRazonSocialAsociado ;
      private string[] T000H10_A56UsuarioNombreComercial ;
      private DateTime[] T000H10_A57UsuarioFechaNacimiento ;
      private bool[] T000H10_n57UsuarioFechaNacimiento ;
      private string[] T000H10_A59UsuarioCalleNum ;
      private string[] T000H10_A60UsuarioColonia ;
      private string[] T000H10_A61UsuarioDelegacion ;
      private int[] T000H10_A62UsuarioCP ;
      private string[] T000H10_A63UsuarioZona ;
      private long[] T000H10_A64UsuarioCelular ;
      private long[] T000H10_A65UsuarioTelefonoSucursal ;
      private string[] T000H10_A17PaisDescripcion ;
      private string[] T000H10_A2EstadoDescripcion ;
      private string[] T000H10_A5CiudadDescripcion ;
      private string[] T000H10_A66UsuarioSucursal ;
      private string[] T000H10_A67UsuarioProducto ;
      private bool[] T000H10_n67UsuarioProducto ;
      private string[] T000H10_A40UsuarioRol ;
      private string[] T000H10_A11DistribuidorDescripcion ;
      private string[] T000H10_A12DistribuidorRFC ;
      private int[] T000H10_A10DistribuidorID ;
      private int[] T000H10_A29UsuarioID ;
      private int[] T000H10_A13PuestoID ;
      private bool[] T000H10_n13PuestoID ;
      private int[] T000H10_A4CiudadID ;
      private bool[] T000H10_n4CiudadID ;
      private int[] T000H10_A1EstadoID ;
      private int[] T000H10_A16PaisID ;
      private string[] T000H5_A30UsuarioNombre ;
      private string[] T000H5_A51UsuarioApellido ;
      private string[] T000H5_A31UsuarioCorreo ;
      private string[] T000H5_A32UsuarioPass ;
      private string[] T000H5_A33UsuarioKey ;
      private string[] T000H5_A53UsuarioGenero ;
      private string[] T000H5_A54UsuarioDirectoAsociado ;
      private bool[] T000H5_n54UsuarioDirectoAsociado ;
      private string[] T000H5_A55UsuarioRazonSocialAsociado ;
      private string[] T000H5_A56UsuarioNombreComercial ;
      private DateTime[] T000H5_A57UsuarioFechaNacimiento ;
      private bool[] T000H5_n57UsuarioFechaNacimiento ;
      private string[] T000H5_A59UsuarioCalleNum ;
      private string[] T000H5_A60UsuarioColonia ;
      private string[] T000H5_A61UsuarioDelegacion ;
      private int[] T000H5_A62UsuarioCP ;
      private string[] T000H5_A63UsuarioZona ;
      private long[] T000H5_A64UsuarioCelular ;
      private long[] T000H5_A65UsuarioTelefonoSucursal ;
      private string[] T000H5_A66UsuarioSucursal ;
      private string[] T000H5_A67UsuarioProducto ;
      private bool[] T000H5_n67UsuarioProducto ;
      private string[] T000H5_A40UsuarioRol ;
      private int[] T000H5_A13PuestoID ;
      private bool[] T000H5_n13PuestoID ;
      private int[] T000H5_A4CiudadID ;
      private bool[] T000H5_n4CiudadID ;
      private string[] T000H6_A14PuestoDescripcion ;
      private string[] T000H7_A5CiudadDescripcion ;
      private int[] T000H7_A1EstadoID ;
      private string[] T000H8_A2EstadoDescripcion ;
      private int[] T000H8_A16PaisID ;
      private string[] T000H9_A17PaisDescripcion ;
      private string[] T000H4_A11DistribuidorDescripcion ;
      private string[] T000H4_A12DistribuidorRFC ;
      private string[] T000H11_A30UsuarioNombre ;
      private string[] T000H11_A51UsuarioApellido ;
      private string[] T000H11_A31UsuarioCorreo ;
      private string[] T000H11_A32UsuarioPass ;
      private string[] T000H11_A33UsuarioKey ;
      private string[] T000H11_A53UsuarioGenero ;
      private string[] T000H11_A54UsuarioDirectoAsociado ;
      private bool[] T000H11_n54UsuarioDirectoAsociado ;
      private string[] T000H11_A55UsuarioRazonSocialAsociado ;
      private string[] T000H11_A56UsuarioNombreComercial ;
      private DateTime[] T000H11_A57UsuarioFechaNacimiento ;
      private bool[] T000H11_n57UsuarioFechaNacimiento ;
      private string[] T000H11_A59UsuarioCalleNum ;
      private string[] T000H11_A60UsuarioColonia ;
      private string[] T000H11_A61UsuarioDelegacion ;
      private int[] T000H11_A62UsuarioCP ;
      private string[] T000H11_A63UsuarioZona ;
      private long[] T000H11_A64UsuarioCelular ;
      private long[] T000H11_A65UsuarioTelefonoSucursal ;
      private string[] T000H11_A66UsuarioSucursal ;
      private string[] T000H11_A67UsuarioProducto ;
      private bool[] T000H11_n67UsuarioProducto ;
      private string[] T000H11_A40UsuarioRol ;
      private int[] T000H11_A13PuestoID ;
      private bool[] T000H11_n13PuestoID ;
      private int[] T000H11_A4CiudadID ;
      private bool[] T000H11_n4CiudadID ;
      private string[] T000H12_A14PuestoDescripcion ;
      private string[] T000H13_A5CiudadDescripcion ;
      private int[] T000H13_A1EstadoID ;
      private string[] T000H14_A2EstadoDescripcion ;
      private int[] T000H14_A16PaisID ;
      private string[] T000H15_A17PaisDescripcion ;
      private string[] T000H16_A11DistribuidorDescripcion ;
      private string[] T000H16_A12DistribuidorRFC ;
      private int[] T000H17_A81DistribuidoresUsuarioID ;
      private int[] T000H3_A81DistribuidoresUsuarioID ;
      private int[] T000H3_A10DistribuidorID ;
      private int[] T000H3_A29UsuarioID ;
      private int[] T000H18_A81DistribuidoresUsuarioID ;
      private int[] T000H19_A81DistribuidoresUsuarioID ;
      private int[] T000H2_A81DistribuidoresUsuarioID ;
      private int[] T000H2_A10DistribuidorID ;
      private int[] T000H2_A29UsuarioID ;
      private int[] T000H21_A81DistribuidoresUsuarioID ;
      private string[] T000H24_A30UsuarioNombre ;
      private string[] T000H24_A51UsuarioApellido ;
      private string[] T000H24_A31UsuarioCorreo ;
      private string[] T000H24_A32UsuarioPass ;
      private string[] T000H24_A33UsuarioKey ;
      private string[] T000H24_A53UsuarioGenero ;
      private string[] T000H24_A54UsuarioDirectoAsociado ;
      private bool[] T000H24_n54UsuarioDirectoAsociado ;
      private string[] T000H24_A55UsuarioRazonSocialAsociado ;
      private string[] T000H24_A56UsuarioNombreComercial ;
      private DateTime[] T000H24_A57UsuarioFechaNacimiento ;
      private bool[] T000H24_n57UsuarioFechaNacimiento ;
      private string[] T000H24_A59UsuarioCalleNum ;
      private string[] T000H24_A60UsuarioColonia ;
      private string[] T000H24_A61UsuarioDelegacion ;
      private int[] T000H24_A62UsuarioCP ;
      private string[] T000H24_A63UsuarioZona ;
      private long[] T000H24_A64UsuarioCelular ;
      private long[] T000H24_A65UsuarioTelefonoSucursal ;
      private string[] T000H24_A66UsuarioSucursal ;
      private string[] T000H24_A67UsuarioProducto ;
      private bool[] T000H24_n67UsuarioProducto ;
      private string[] T000H24_A40UsuarioRol ;
      private int[] T000H24_A13PuestoID ;
      private bool[] T000H24_n13PuestoID ;
      private int[] T000H24_A4CiudadID ;
      private bool[] T000H24_n4CiudadID ;
      private string[] T000H25_A14PuestoDescripcion ;
      private string[] T000H26_A5CiudadDescripcion ;
      private int[] T000H26_A1EstadoID ;
      private string[] T000H27_A2EstadoDescripcion ;
      private int[] T000H27_A16PaisID ;
      private string[] T000H28_A17PaisDescripcion ;
      private string[] T000H29_A11DistribuidorDescripcion ;
      private string[] T000H29_A12DistribuidorRFC ;
      private int[] T000H30_A81DistribuidoresUsuarioID ;
   }

   public class distribuidoresusuario__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new UpdateCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000H2;
          prmT000H2 = new Object[] {
          new ParDef("@DistribuidoresUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000H3;
          prmT000H3 = new Object[] {
          new ParDef("@DistribuidoresUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000H4;
          prmT000H4 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmT000H5;
          prmT000H5 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000H6;
          prmT000H6 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000H7;
          prmT000H7 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000H8;
          prmT000H8 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000H9;
          prmT000H9 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT000H10;
          prmT000H10 = new Object[] {
          new ParDef("@DistribuidoresUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000H11;
          prmT000H11 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000H12;
          prmT000H12 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000H13;
          prmT000H13 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000H14;
          prmT000H14 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000H15;
          prmT000H15 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT000H16;
          prmT000H16 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmT000H17;
          prmT000H17 = new Object[] {
          new ParDef("@DistribuidoresUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000H18;
          prmT000H18 = new Object[] {
          new ParDef("@DistribuidoresUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000H19;
          prmT000H19 = new Object[] {
          new ParDef("@DistribuidoresUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000H20;
          prmT000H20 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0) ,
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000H21;
          prmT000H21 = new Object[] {
          };
          Object[] prmT000H22;
          prmT000H22 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0) ,
          new ParDef("@UsuarioID",GXType.Int32,9,0) ,
          new ParDef("@DistribuidoresUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000H23;
          prmT000H23 = new Object[] {
          new ParDef("@DistribuidoresUsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000H24;
          prmT000H24 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000H25;
          prmT000H25 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000H26;
          prmT000H26 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000H27;
          prmT000H27 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000H28;
          prmT000H28 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT000H29;
          prmT000H29 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmT000H30;
          prmT000H30 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000H2", "SELECT `DistribuidoresUsuarioID`, `DistribuidorID`, `UsuarioID` FROM `DistribuidoresUsuario` WHERE `DistribuidoresUsuarioID` = @DistribuidoresUsuarioID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H3", "SELECT `DistribuidoresUsuarioID`, `DistribuidorID`, `UsuarioID` FROM `DistribuidoresUsuario` WHERE `DistribuidoresUsuarioID` = @DistribuidoresUsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H4", "SELECT `DistribuidorDescripcion`, `DistribuidorRFC` FROM `Distribuidor` WHERE `DistribuidorID` = @DistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H5", "SELECT `UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioGenero`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioZona`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `PuestoID`, `CiudadID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H6", "SELECT `PuestoDescripcion` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H7", "SELECT `CiudadDescripcion`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H8", "SELECT `EstadoDescripcion`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H9", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H10", "SELECT TM1.`DistribuidoresUsuarioID`, T2.`UsuarioNombre`, T2.`UsuarioApellido`, T2.`UsuarioCorreo`, T2.`UsuarioPass`, T2.`UsuarioKey`, T3.`PuestoDescripcion`, T2.`UsuarioGenero`, T2.`UsuarioDirectoAsociado`, T2.`UsuarioRazonSocialAsociado`, T2.`UsuarioNombreComercial`, T2.`UsuarioFechaNacimiento`, T2.`UsuarioCalleNum`, T2.`UsuarioColonia`, T2.`UsuarioDelegacion`, T2.`UsuarioCP`, T2.`UsuarioZona`, T2.`UsuarioCelular`, T2.`UsuarioTelefonoSucursal`, T6.`PaisDescripcion`, T5.`EstadoDescripcion`, T4.`CiudadDescripcion`, T2.`UsuarioSucursal`, T2.`UsuarioProducto`, T2.`UsuarioRol`, T7.`DistribuidorDescripcion`, T7.`DistribuidorRFC`, TM1.`DistribuidorID`, TM1.`UsuarioID`, T2.`PuestoID`, T2.`CiudadID`, T4.`EstadoID`, T5.`PaisID` FROM ((((((`DistribuidoresUsuario` TM1 INNER JOIN `Usuario` T2 ON T2.`UsuarioID` = TM1.`UsuarioID`) LEFT JOIN `Puesto` T3 ON T3.`PuestoID` = T2.`PuestoID`) LEFT JOIN `Ciudad` T4 ON T4.`CiudadID` = T2.`CiudadID`) LEFT JOIN `Estado` T5 ON T5.`EstadoID` = T4.`EstadoID`) LEFT JOIN `Pais` T6 ON T6.`PaisID` = T5.`PaisID`) INNER JOIN `Distribuidor` T7 ON T7.`DistribuidorID` = TM1.`DistribuidorID`) WHERE TM1.`DistribuidoresUsuarioID` = @DistribuidoresUsuarioID ORDER BY TM1.`DistribuidoresUsuarioID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H11", "SELECT `UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioGenero`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioZona`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `PuestoID`, `CiudadID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H12", "SELECT `PuestoDescripcion` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H13", "SELECT `CiudadDescripcion`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H14", "SELECT `EstadoDescripcion`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H15", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H16", "SELECT `DistribuidorDescripcion`, `DistribuidorRFC` FROM `Distribuidor` WHERE `DistribuidorID` = @DistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H17", "SELECT `DistribuidoresUsuarioID` FROM `DistribuidoresUsuario` WHERE `DistribuidoresUsuarioID` = @DistribuidoresUsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H18", "SELECT `DistribuidoresUsuarioID` FROM `DistribuidoresUsuario` WHERE ( `DistribuidoresUsuarioID` > @DistribuidoresUsuarioID) ORDER BY `DistribuidoresUsuarioID`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000H18,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000H19", "SELECT `DistribuidoresUsuarioID` FROM `DistribuidoresUsuario` WHERE ( `DistribuidoresUsuarioID` < @DistribuidoresUsuarioID) ORDER BY `DistribuidoresUsuarioID` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000H19,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000H20", "INSERT INTO `DistribuidoresUsuario`(`DistribuidorID`, `UsuarioID`) VALUES(@DistribuidorID, @UsuarioID)", GxErrorMask.GX_NOMASK,prmT000H20)
             ,new CursorDef("T000H21", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H22", "UPDATE `DistribuidoresUsuario` SET `DistribuidorID`=@DistribuidorID, `UsuarioID`=@UsuarioID  WHERE `DistribuidoresUsuarioID` = @DistribuidoresUsuarioID", GxErrorMask.GX_NOMASK,prmT000H22)
             ,new CursorDef("T000H23", "DELETE FROM `DistribuidoresUsuario`  WHERE `DistribuidoresUsuarioID` = @DistribuidoresUsuarioID", GxErrorMask.GX_NOMASK,prmT000H23)
             ,new CursorDef("T000H24", "SELECT `UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioGenero`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioZona`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `PuestoID`, `CiudadID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H24,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H25", "SELECT `PuestoDescripcion` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H26", "SELECT `CiudadDescripcion`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H26,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H27", "SELECT `EstadoDescripcion`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H27,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H28", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H28,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H29", "SELECT `DistribuidorDescripcion`, `DistribuidorRFC` FROM `Distribuidor` WHERE `DistribuidorID` = @DistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H30", "SELECT `DistribuidoresUsuarioID` FROM `DistribuidoresUsuario` ORDER BY `DistribuidoresUsuarioID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H30,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 13);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 40);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((int[]) buf[15])[0] = rslt.getInt(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 30);
                ((long[]) buf[17])[0] = rslt.getLong(16);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 20);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((string[]) buf[22])[0] = rslt.getString(20, 40);
                ((int[]) buf[23])[0] = rslt.getInt(21);
                ((bool[]) buf[24])[0] = rslt.wasNull(21);
                ((int[]) buf[25])[0] = rslt.getInt(22);
                ((bool[]) buf[26])[0] = rslt.wasNull(22);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
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
                ((string[]) buf[28])[0] = rslt.getVarchar(26);
                ((string[]) buf[29])[0] = rslt.getString(27, 13);
                ((int[]) buf[30])[0] = rslt.getInt(28);
                ((int[]) buf[31])[0] = rslt.getInt(29);
                ((int[]) buf[32])[0] = rslt.getInt(30);
                ((bool[]) buf[33])[0] = rslt.wasNull(30);
                ((int[]) buf[34])[0] = rslt.getInt(31);
                ((bool[]) buf[35])[0] = rslt.wasNull(31);
                ((int[]) buf[36])[0] = rslt.getInt(32);
                ((int[]) buf[37])[0] = rslt.getInt(33);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 40);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((int[]) buf[15])[0] = rslt.getInt(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 30);
                ((long[]) buf[17])[0] = rslt.getLong(16);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 20);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((string[]) buf[22])[0] = rslt.getString(20, 40);
                ((int[]) buf[23])[0] = rslt.getInt(21);
                ((bool[]) buf[24])[0] = rslt.wasNull(21);
                ((int[]) buf[25])[0] = rslt.getInt(22);
                ((bool[]) buf[26])[0] = rslt.wasNull(22);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 13);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 40);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((int[]) buf[15])[0] = rslt.getInt(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 30);
                ((long[]) buf[17])[0] = rslt.getLong(16);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 20);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((string[]) buf[22])[0] = rslt.getString(20, 40);
                ((int[]) buf[23])[0] = rslt.getInt(21);
                ((bool[]) buf[24])[0] = rslt.wasNull(21);
                ((int[]) buf[25])[0] = rslt.getInt(22);
                ((bool[]) buf[26])[0] = rslt.wasNull(22);
                return;
             case 23 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 27 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 13);
                return;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
