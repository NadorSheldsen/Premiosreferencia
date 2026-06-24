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
   public class facturamedida : GXDataArea
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
            A69FacturaID = (int)(Math.Round(NumberUtil.Val( GetPar( "FacturaID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A69FacturaID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A41PromocionID = (int)(Math.Round(NumberUtil.Val( GetPar( "PromocionID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A41PromocionID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A19MotivoRechazoID = (int)(Math.Round(NumberUtil.Val( GetPar( "MotivoRechazoID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrimStr( (decimal)(A19MotivoRechazoID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A19MotivoRechazoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A29UsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "UsuarioID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A29UsuarioID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
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
            gxLoad_9( A13PuestoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
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
            gxLoad_10( A4CiudadID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A1EstadoID = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadoID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A1EstadoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A16PaisID = (int)(Math.Round(NumberUtil.Val( GetPar( "PaisID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A16PaisID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A26MedidaID = (int)(Math.Round(NumberUtil.Val( GetPar( "MedidaID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A26MedidaID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A22ModeloID = (int)(Math.Round(NumberUtil.Val( GetPar( "ModeloID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A22ModeloID) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Factura Medida", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFacturaMedidaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public facturamedida( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public facturamedida( IGxContext context )
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
         cmbUsuarioZona = new GXCombobox();
         cmbUsuarioGenero = new GXCombobox();
         cmbFacturaEstatus = new GXCombobox();
         chkMotivoRechazoActivo = new GXCheckbox();
         cmbUsuarioDirectoAsociado = new GXCombobox();
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
         if ( cmbFacturaEstatus.ItemCount > 0 )
         {
            A80FacturaEstatus = cmbFacturaEstatus.getValidValue(A80FacturaEstatus);
            AssignAttri("", false, "A80FacturaEstatus", A80FacturaEstatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbFacturaEstatus.CurrentValue = StringUtil.RTrim( A80FacturaEstatus);
            AssignProp("", false, cmbFacturaEstatus_Internalname, "Values", cmbFacturaEstatus.ToJavascriptSource(), true);
         }
         A21MotivoRechazoActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A21MotivoRechazoActivo));
         AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Factura Medida", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_FacturaMedida.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_FacturaMedida.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFacturaMedidaID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFacturaMedidaID_Internalname, context.GetMessage( "Medida ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFacturaMedidaID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A77FacturaMedidaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtFacturaMedidaID_Enabled!=0) ? context.localUtil.Format( (decimal)(A77FacturaMedidaID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A77FacturaMedidaID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFacturaMedidaID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFacturaMedidaID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFacturaID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFacturaID_Internalname, context.GetMessage( "Factura ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFacturaID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtFacturaID_Enabled!=0) ? context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFacturaID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFacturaID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromocionDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocionDescripcion_Internalname, context.GetMessage( "Nom. Promoción", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPromocionDescripcion_Internalname, A42PromocionDescripcion, StringUtil.RTrim( context.localUtil.Format( A42PromocionDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocionDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromocionBase_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocionBase_Internalname, context.GetMessage( "Bases", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPromocionBase_Internalname, A43PromocionBase, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtPromocionBase_Enabled, 0, 80, "chr", 9, "row", 0, StyleString, ClassString, "", "", "700", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgPromocionArte_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Promocion Arte", ""), "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A44PromocionArte_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000PromocionArte_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.PathToRelativeUrl( A44PromocionArte));
         GxWebStd.gx_bitmap( context, imgPromocionArte_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgPromocionArte_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", "", "", 0, A44PromocionArte_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_FacturaMedida.htm");
         AssignProp("", false, imgPromocionArte_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.PathToRelativeUrl( A44PromocionArte)), true);
         AssignProp("", false, imgPromocionArte_Internalname, "IsBlob", StringUtil.BoolToStr( A44PromocionArte_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromocionVigencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocionVigencia_Internalname, context.GetMessage( "Promocion Vigencia", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPromocionVigencia_Internalname, A70PromocionVigencia, StringUtil.RTrim( context.localUtil.Format( A70PromocionVigencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionVigencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocionVigencia_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFacturaNo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFacturaNo_Internalname, context.GetMessage( "Factura No", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFacturaNo_Internalname, StringUtil.RTrim( A71FacturaNo), StringUtil.RTrim( context.localUtil.Format( A71FacturaNo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFacturaNo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFacturaNo_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFacturaFechaFactura_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFacturaFechaFactura_Internalname, context.GetMessage( "Factura Fecha Factura", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFacturaFechaFactura_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFacturaFechaFactura_Internalname, context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"), context.localUtil.Format( A73FacturaFechaFactura, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFacturaFechaFactura_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFacturaFechaFactura_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_bitmap( context, edtFacturaFechaFactura_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFacturaFechaFactura_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_FacturaMedida.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFacturaFechaRegistro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFacturaFechaRegistro_Internalname, context.GetMessage( "Factura Fecha Registro", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFacturaFechaRegistro_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFacturaFechaRegistro_Internalname, context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"), context.localUtil.Format( A72FacturaFechaRegistro, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFacturaFechaRegistro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFacturaFechaRegistro_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_bitmap( context, edtFacturaFechaRegistro_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFacturaFechaRegistro_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_FacturaMedida.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioID_Internalname, context.GetMessage( "Usuario ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioID_Enabled!=0) ? context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombreCompleto_Internalname, A52UsuarioNombreCompleto, StringUtil.RTrim( context.localUtil.Format( A52UsuarioNombreCompleto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombreCompleto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNombreCompleto_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioZona, cmbUsuarioZona_Internalname, StringUtil.RTrim( A63UsuarioZona), 1, cmbUsuarioZona_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioZona.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 0, "HLP_FacturaMedida.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadoDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoDescripcion_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadoDescripcion_Internalname, A2EstadoDescripcion, StringUtil.RTrim( context.localUtil.Format( A2EstadoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstadoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCiudadDescripcion_Internalname, A5CiudadDescripcion, StringUtil.RTrim( context.localUtil.Format( A5CiudadDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCiudadDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCiudadDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisDescripcion_Internalname, A17PaisDescripcion, StringUtil.RTrim( context.localUtil.Format( A17PaisDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioGenero, cmbUsuarioGenero_Internalname, StringUtil.RTrim( A53UsuarioGenero), 1, cmbUsuarioGenero_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioGenero.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "", true, 0, "HLP_FacturaMedida.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFacturaPDF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFacturaPDF_Internalname, context.GetMessage( "Factura PDF", ""), "col-sm-3 DownloadAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* BinaryFile Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         ClassString = "DownloadAttribute";
         StyleString = "";
         A75FacturaPDF_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001FacturaPDF_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)));
         GxWebStd.gx_file( context, edtFacturaPDF_Internalname, (String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)) ? A40001FacturaPDF_GXI : context.PathToRelativeUrl( A75FacturaPDF)), edtFacturaPDF_Filename, 1, 1, edtFacturaPDF_Enabled, 0, 0, "", 0, "", 0, "", "", StyleString, ClassString, "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "", "", 0, A75FacturaPDF_IsBlob, "HLP_FacturaMedida.htm");
         AssignProp("", false, edtFacturaPDF_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)) ? A40001FacturaPDF_GXI : context.PathToRelativeUrl( A75FacturaPDF)), true);
         AssignProp("", false, edtFacturaPDF_Internalname, "IsBlob", StringUtil.BoolToStr( A75FacturaPDF_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbFacturaEstatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbFacturaEstatus_Internalname, context.GetMessage( "Factura Estatus", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbFacturaEstatus, cmbFacturaEstatus_Internalname, StringUtil.RTrim( A80FacturaEstatus), 1, cmbFacturaEstatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbFacturaEstatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "", true, 0, "HLP_FacturaMedida.htm");
         cmbFacturaEstatus.CurrentValue = StringUtil.RTrim( A80FacturaEstatus);
         AssignProp("", false, cmbFacturaEstatus_Internalname, "Values", (string)(cmbFacturaEstatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMotivoRechazoID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMotivoRechazoID_Internalname, context.GetMessage( "Motivo Rechazo ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMotivoRechazoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MotivoRechazoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtMotivoRechazoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A19MotivoRechazoID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A19MotivoRechazoID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMotivoRechazoID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMotivoRechazoID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMotivoRechazoDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMotivoRechazoDescripcion_Internalname, context.GetMessage( "Motivo de rechazo", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMotivoRechazoDescripcion_Internalname, A20MotivoRechazoDescripcion, StringUtil.RTrim( context.localUtil.Format( A20MotivoRechazoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMotivoRechazoDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMotivoRechazoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkMotivoRechazoActivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkMotivoRechazoActivo_Internalname, context.GetMessage( "Motivo Rechazo Activo", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkMotivoRechazoActivo_Internalname, StringUtil.BoolToStr( A21MotivoRechazoActivo), "", context.GetMessage( "Motivo Rechazo Activo", ""), 1, chkMotivoRechazoActivo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(134, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,134);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromocionID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocionID_Internalname, context.GetMessage( "Promocion ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPromocionID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPromocionID_Enabled!=0) ? context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocionID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMedidaID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMedidaID_Internalname, context.GetMessage( "Medida ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedidaID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26MedidaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtMedidaID_Enabled!=0) ? context.localUtil.Format( (decimal)(A26MedidaID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A26MedidaID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,144);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedidaID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMedidaID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMedidaDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMedidaDescripcion_Internalname, context.GetMessage( "Medida", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedidaDescripcion_Internalname, A28MedidaDescripcion, StringUtil.RTrim( context.localUtil.Format( A28MedidaDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedidaDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMedidaDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMedidaRin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMedidaRin_Internalname, context.GetMessage( "Medida Rin", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedidaRin_Internalname, StringUtil.RTrim( A74MedidaRin), StringUtil.RTrim( context.localUtil.Format( A74MedidaRin, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,154);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedidaRin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMedidaRin_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMedidaCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMedidaCodigo_Internalname, context.GetMessage( "Código", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedidaCodigo_Internalname, StringUtil.RTrim( A27MedidaCodigo), StringUtil.RTrim( context.localUtil.Format( A27MedidaCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedidaCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMedidaCodigo_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtModeloID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtModeloID_Internalname, context.GetMessage( "Modelo ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtModeloID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22ModeloID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtModeloID_Enabled!=0) ? context.localUtil.Format( (decimal)(A22ModeloID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A22ModeloID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtModeloID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtModeloID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtModeloDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtModeloDescripcion_Internalname, context.GetMessage( "Modelo", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtModeloDescripcion_Internalname, A23ModeloDescripcion, StringUtil.RTrim( context.localUtil.Format( A23ModeloDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtModeloDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtModeloDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFacturaMedidaCantidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFacturaMedidaCantidad_Internalname, context.GetMessage( "Medida Cantidad", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFacturaMedidaCantidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A78FacturaMedidaCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtFacturaMedidaCantidad_Enabled!=0) ? context.localUtil.Format( (decimal)(A78FacturaMedidaCantidad), "ZZZ9") : context.localUtil.Format( (decimal)(A78FacturaMedidaCantidad), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,174);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFacturaMedidaCantidad_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFacturaMedidaCantidad_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFacturaMedidaPrecio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFacturaMedidaPrecio_Internalname, context.GetMessage( "Medida Precio", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFacturaMedidaPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( A79FacturaMedidaPrecio, 14, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtFacturaMedidaPrecio_Enabled!=0) ? context.localUtil.Format( A79FacturaMedidaPrecio, "$ Z,ZZZ,ZZ9.99") : context.localUtil.Format( A79FacturaMedidaPrecio, "$ Z,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,179);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFacturaMedidaPrecio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFacturaMedidaPrecio_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombre_Internalname, StringUtil.RTrim( A30UsuarioNombre), StringUtil.RTrim( context.localUtil.Format( A30UsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,184);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioApellido_Internalname, StringUtil.RTrim( A51UsuarioApellido), StringUtil.RTrim( context.localUtil.Format( A51UsuarioApellido, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,189);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioApellido_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioApellido_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioCorreo_Internalname, A31UsuarioCorreo, StringUtil.RTrim( context.localUtil.Format( A31UsuarioCorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,194);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A31UsuarioCorreo, "", "", "", edtUsuarioCorreo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioCorreo_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 199,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioPass_Internalname, A32UsuarioPass, StringUtil.RTrim( context.localUtil.Format( A32UsuarioPass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,199);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioPass_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioPass_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioKey_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioKey_Internalname, context.GetMessage( "Usuario Key", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioKey_Internalname, A33UsuarioKey, StringUtil.RTrim( context.localUtil.Format( A33UsuarioKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,204);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioKey_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioKey_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 209,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPuestoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PuestoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPuestoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A13PuestoID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A13PuestoID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,209);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPuestoID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPuestoID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 214,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPuestoDescripcion_Internalname, A14PuestoDescripcion, StringUtil.RTrim( context.localUtil.Format( A14PuestoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,214);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPuestoDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPuestoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 219,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioDirectoAsociado, cmbUsuarioDirectoAsociado_Internalname, StringUtil.RTrim( A54UsuarioDirectoAsociado), 1, cmbUsuarioDirectoAsociado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioDirectoAsociado.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,219);\"", "", true, 0, "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 224,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioRazonSocialAsociado_Internalname, A55UsuarioRazonSocialAsociado, StringUtil.RTrim( context.localUtil.Format( A55UsuarioRazonSocialAsociado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,224);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioRazonSocialAsociado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioRazonSocialAsociado_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 229,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombreComercial_Internalname, A56UsuarioNombreComercial, StringUtil.RTrim( context.localUtil.Format( A56UsuarioNombreComercial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,229);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombreComercial_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNombreComercial_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 234,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtUsuarioFechaNacimiento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUsuarioFechaNacimiento_Internalname, context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"), context.localUtil.Format( A57UsuarioFechaNacimiento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,234);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioFechaNacimiento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioFechaNacimiento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FacturaMedida.htm");
         GxWebStd.gx_bitmap( context, edtUsuarioFechaNacimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuarioFechaNacimiento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 239,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioCalleNum_Internalname, StringUtil.RTrim( A59UsuarioCalleNum), StringUtil.RTrim( context.localUtil.Format( A59UsuarioCalleNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,239);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioCalleNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioCalleNum_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 244,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioColonia_Internalname, StringUtil.RTrim( A60UsuarioColonia), StringUtil.RTrim( context.localUtil.Format( A60UsuarioColonia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,244);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioColonia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioColonia_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 249,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioDelegacion_Internalname, StringUtil.RTrim( A61UsuarioDelegacion), StringUtil.RTrim( context.localUtil.Format( A61UsuarioDelegacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,249);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioDelegacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioDelegacion_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 254,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioCP_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A62UsuarioCP), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioCP_Enabled!=0) ? context.localUtil.Format( (decimal)(A62UsuarioCP), "ZZZZ9") : context.localUtil.Format( (decimal)(A62UsuarioCP), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,254);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioCP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioCP_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 259,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioCelular_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A64UsuarioCelular), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioCelular_Enabled!=0) ? context.localUtil.Format( (decimal)(A64UsuarioCelular), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A64UsuarioCelular), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,259);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioCelular_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioCelular_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 264,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioTelefonoSucursal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A65UsuarioTelefonoSucursal), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioTelefonoSucursal_Enabled!=0) ? context.localUtil.Format( (decimal)(A65UsuarioTelefonoSucursal), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A65UsuarioTelefonoSucursal), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,264);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioTelefonoSucursal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioTelefonoSucursal_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 269,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPaisID_Enabled!=0) ? context.localUtil.Format( (decimal)(A16PaisID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A16PaisID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,269);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 274,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtEstadoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EstadoID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1EstadoID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,274);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstadoID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 279,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCiudadID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCiudadID_Enabled!=0) ? context.localUtil.Format( (decimal)(A4CiudadID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A4CiudadID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,279);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCiudadID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCiudadID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 284,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioSucursal_Internalname, StringUtil.RTrim( A66UsuarioSucursal), StringUtil.RTrim( context.localUtil.Format( A66UsuarioSucursal, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,284);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioSucursal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioSucursal_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 289,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioProducto, cmbUsuarioProducto_Internalname, StringUtil.RTrim( A67UsuarioProducto), 1, cmbUsuarioProducto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbUsuarioProducto.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,289);\"", "", true, 0, "HLP_FacturaMedida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 294,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioRol, cmbUsuarioRol_Internalname, StringUtil.RTrim( A40UsuarioRol), 1, cmbUsuarioRol_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioRol.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,294);\"", "", true, 0, "HLP_FacturaMedida.htm");
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
         GxWebStd.gx_label_element( context, edtUsuarioNoCuentaBROXEL_Internalname, context.GetMessage( "Usuario No Cuenta BROXEL", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 299,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioNoCuentaBROXEL_Internalname, StringUtil.RTrim( A82UsuarioNoCuentaBROXEL), StringUtil.RTrim( context.localUtil.Format( A82UsuarioNoCuentaBROXEL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,299);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNoCuentaBROXEL_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNoCuentaBROXEL_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
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
         GxWebStd.gx_label_element( context, edtUsuarioReferenciaBROXEL_Internalname, context.GetMessage( "Usuario Referencia BROXEL", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 304,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioReferenciaBROXEL_Internalname, StringUtil.RTrim( A83UsuarioReferenciaBROXEL), StringUtil.RTrim( context.localUtil.Format( A83UsuarioReferenciaBROXEL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,304);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioReferenciaBROXEL_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioReferenciaBROXEL_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FacturaMedida.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 309,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 311,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_FacturaMedida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 313,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_FacturaMedida.htm");
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
            Z77FacturaMedidaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z77FacturaMedidaID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z78FacturaMedidaCantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z78FacturaMedidaCantidad"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z79FacturaMedidaPrecio = context.localUtil.CToN( cgiGet( "Z79FacturaMedidaPrecio"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            Z69FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z69FacturaID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z26MedidaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z26MedidaID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A45PromocionFechaInicio = context.localUtil.CToD( cgiGet( "PROMOCIONFECHAINICIO"), 0);
            A46PromocionFechaFin = context.localUtil.CToD( cgiGet( "PROMOCIONFECHAFIN"), 0);
            A40001FacturaPDF_GXI = cgiGet( "FACTURAPDF_GXI");
            A40000PromocionArte_GXI = cgiGet( "PROMOCIONARTE_GXI");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtFacturaMedidaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFacturaMedidaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FACTURAMEDIDAID");
               AnyError = 1;
               GX_FocusControl = edtFacturaMedidaID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A77FacturaMedidaID = 0;
               AssignAttri("", false, "A77FacturaMedidaID", StringUtil.LTrimStr( (decimal)(A77FacturaMedidaID), 9, 0));
            }
            else
            {
               A77FacturaMedidaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaMedidaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A77FacturaMedidaID", StringUtil.LTrimStr( (decimal)(A77FacturaMedidaID), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFacturaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFacturaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FACTURAID");
               AnyError = 1;
               GX_FocusControl = edtFacturaID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A69FacturaID = 0;
               AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
            }
            else
            {
               A69FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
            }
            A42PromocionDescripcion = cgiGet( edtPromocionDescripcion_Internalname);
            AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
            A43PromocionBase = cgiGet( edtPromocionBase_Internalname);
            AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
            A44PromocionArte = cgiGet( imgPromocionArte_Internalname);
            AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
            A70PromocionVigencia = cgiGet( edtPromocionVigencia_Internalname);
            AssignAttri("", false, "A70PromocionVigencia", A70PromocionVigencia);
            A71FacturaNo = cgiGet( edtFacturaNo_Internalname);
            AssignAttri("", false, "A71FacturaNo", A71FacturaNo);
            A73FacturaFechaFactura = context.localUtil.CToD( cgiGet( edtFacturaFechaFactura_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri("", false, "A73FacturaFechaFactura", context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"));
            A72FacturaFechaRegistro = context.localUtil.CToD( cgiGet( edtFacturaFechaRegistro_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri("", false, "A72FacturaFechaRegistro", context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"));
            A29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
            A52UsuarioNombreCompleto = cgiGet( edtUsuarioNombreCompleto_Internalname);
            AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
            cmbUsuarioZona.CurrentValue = cgiGet( cmbUsuarioZona_Internalname);
            A63UsuarioZona = cgiGet( cmbUsuarioZona_Internalname);
            AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
            A2EstadoDescripcion = cgiGet( edtEstadoDescripcion_Internalname);
            AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
            A5CiudadDescripcion = cgiGet( edtCiudadDescripcion_Internalname);
            AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
            A17PaisDescripcion = cgiGet( edtPaisDescripcion_Internalname);
            AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
            cmbUsuarioGenero.CurrentValue = cgiGet( cmbUsuarioGenero_Internalname);
            A53UsuarioGenero = cgiGet( cmbUsuarioGenero_Internalname);
            AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
            A75FacturaPDF = cgiGet( edtFacturaPDF_Internalname);
            AssignAttri("", false, "A75FacturaPDF", A75FacturaPDF);
            cmbFacturaEstatus.CurrentValue = cgiGet( cmbFacturaEstatus_Internalname);
            A80FacturaEstatus = cgiGet( cmbFacturaEstatus_Internalname);
            AssignAttri("", false, "A80FacturaEstatus", A80FacturaEstatus);
            A19MotivoRechazoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMotivoRechazoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrimStr( (decimal)(A19MotivoRechazoID), 9, 0));
            A20MotivoRechazoDescripcion = cgiGet( edtMotivoRechazoDescripcion_Internalname);
            AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
            A21MotivoRechazoActivo = StringUtil.StrToBool( cgiGet( chkMotivoRechazoActivo_Internalname));
            AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
            A41PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPromocionID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtMedidaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMedidaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MEDIDAID");
               AnyError = 1;
               GX_FocusControl = edtMedidaID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A26MedidaID = 0;
               AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
            }
            else
            {
               A26MedidaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMedidaID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
            }
            A28MedidaDescripcion = cgiGet( edtMedidaDescripcion_Internalname);
            AssignAttri("", false, "A28MedidaDescripcion", A28MedidaDescripcion);
            A74MedidaRin = cgiGet( edtMedidaRin_Internalname);
            AssignAttri("", false, "A74MedidaRin", A74MedidaRin);
            A27MedidaCodigo = cgiGet( edtMedidaCodigo_Internalname);
            AssignAttri("", false, "A27MedidaCodigo", A27MedidaCodigo);
            A22ModeloID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtModeloID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
            A23ModeloDescripcion = cgiGet( edtModeloDescripcion_Internalname);
            AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
            if ( ( ( context.localUtil.CToN( cgiGet( edtFacturaMedidaCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFacturaMedidaCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FACTURAMEDIDACANTIDAD");
               AnyError = 1;
               GX_FocusControl = edtFacturaMedidaCantidad_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A78FacturaMedidaCantidad = 0;
               AssignAttri("", false, "A78FacturaMedidaCantidad", StringUtil.LTrimStr( (decimal)(A78FacturaMedidaCantidad), 4, 0));
            }
            else
            {
               A78FacturaMedidaCantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFacturaMedidaCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A78FacturaMedidaCantidad", StringUtil.LTrimStr( (decimal)(A78FacturaMedidaCantidad), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFacturaMedidaPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFacturaMedidaPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FACTURAMEDIDAPRECIO");
               AnyError = 1;
               GX_FocusControl = edtFacturaMedidaPrecio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A79FacturaMedidaPrecio = 0;
               AssignAttri("", false, "A79FacturaMedidaPrecio", StringUtil.LTrimStr( A79FacturaMedidaPrecio, 10, 2));
            }
            else
            {
               A79FacturaMedidaPrecio = context.localUtil.CToN( cgiGet( edtFacturaMedidaPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A79FacturaMedidaPrecio", StringUtil.LTrimStr( A79FacturaMedidaPrecio, 10, 2));
            }
            A30UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
            AssignAttri("", false, "A30UsuarioNombre", A30UsuarioNombre);
            A51UsuarioApellido = cgiGet( edtUsuarioApellido_Internalname);
            AssignAttri("", false, "A51UsuarioApellido", A51UsuarioApellido);
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
            A64UsuarioCelular = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioCelular_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
            A65UsuarioTelefonoSucursal = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioTelefonoSucursal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
            A16PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPaisID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            A1EstadoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            A4CiudadID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCiudadID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n4CiudadID = false;
            AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
            A66UsuarioSucursal = cgiGet( edtUsuarioSucursal_Internalname);
            AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
            cmbUsuarioProducto.CurrentValue = cgiGet( cmbUsuarioProducto_Internalname);
            A67UsuarioProducto = cgiGet( cmbUsuarioProducto_Internalname);
            n67UsuarioProducto = false;
            AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
            cmbUsuarioRol.CurrentValue = cgiGet( cmbUsuarioRol_Internalname);
            A40UsuarioRol = cgiGet( cmbUsuarioRol_Internalname);
            AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
            A82UsuarioNoCuentaBROXEL = cgiGet( edtUsuarioNoCuentaBROXEL_Internalname);
            AssignAttri("", false, "A82UsuarioNoCuentaBROXEL", A82UsuarioNoCuentaBROXEL);
            A83UsuarioReferenciaBROXEL = cgiGet( edtUsuarioReferenciaBROXEL_Internalname);
            AssignAttri("", false, "A83UsuarioReferenciaBROXEL", A83UsuarioReferenciaBROXEL);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgPromocionArte_Internalname, ref  A44PromocionArte, ref  A40000PromocionArte_GXI);
            getMultimediaValue(edtFacturaPDF_Internalname, ref  A75FacturaPDF, ref  A40001FacturaPDF_GXI);
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
               A77FacturaMedidaID = (int)(Math.Round(NumberUtil.Val( GetPar( "FacturaMedidaID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A77FacturaMedidaID", StringUtil.LTrimStr( (decimal)(A77FacturaMedidaID), 9, 0));
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
               InitAll0G16( ) ;
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
         DisableAttributes0G16( ) ;
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

      protected void ResetCaption0G0( )
      {
      }

      protected void ZM0G16( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z78FacturaMedidaCantidad = T000G3_A78FacturaMedidaCantidad[0];
               Z79FacturaMedidaPrecio = T000G3_A79FacturaMedidaPrecio[0];
               Z69FacturaID = T000G3_A69FacturaID[0];
               Z26MedidaID = T000G3_A26MedidaID[0];
            }
            else
            {
               Z78FacturaMedidaCantidad = A78FacturaMedidaCantidad;
               Z79FacturaMedidaPrecio = A79FacturaMedidaPrecio;
               Z69FacturaID = A69FacturaID;
               Z26MedidaID = A26MedidaID;
            }
         }
         if ( GX_JID == -3 )
         {
            Z77FacturaMedidaID = A77FacturaMedidaID;
            Z78FacturaMedidaCantidad = A78FacturaMedidaCantidad;
            Z79FacturaMedidaPrecio = A79FacturaMedidaPrecio;
            Z69FacturaID = A69FacturaID;
            Z26MedidaID = A26MedidaID;
            Z71FacturaNo = A71FacturaNo;
            Z73FacturaFechaFactura = A73FacturaFechaFactura;
            Z72FacturaFechaRegistro = A72FacturaFechaRegistro;
            Z75FacturaPDF = A75FacturaPDF;
            Z40001FacturaPDF_GXI = A40001FacturaPDF_GXI;
            Z80FacturaEstatus = A80FacturaEstatus;
            Z41PromocionID = A41PromocionID;
            Z19MotivoRechazoID = A19MotivoRechazoID;
            Z29UsuarioID = A29UsuarioID;
            Z42PromocionDescripcion = A42PromocionDescripcion;
            Z43PromocionBase = A43PromocionBase;
            Z44PromocionArte = A44PromocionArte;
            Z40000PromocionArte_GXI = A40000PromocionArte_GXI;
            Z45PromocionFechaInicio = A45PromocionFechaInicio;
            Z46PromocionFechaFin = A46PromocionFechaFin;
            Z20MotivoRechazoDescripcion = A20MotivoRechazoDescripcion;
            Z21MotivoRechazoActivo = A21MotivoRechazoActivo;
            Z63UsuarioZona = A63UsuarioZona;
            Z53UsuarioGenero = A53UsuarioGenero;
            Z30UsuarioNombre = A30UsuarioNombre;
            Z51UsuarioApellido = A51UsuarioApellido;
            Z31UsuarioCorreo = A31UsuarioCorreo;
            Z32UsuarioPass = A32UsuarioPass;
            Z33UsuarioKey = A33UsuarioKey;
            Z54UsuarioDirectoAsociado = A54UsuarioDirectoAsociado;
            Z55UsuarioRazonSocialAsociado = A55UsuarioRazonSocialAsociado;
            Z56UsuarioNombreComercial = A56UsuarioNombreComercial;
            Z57UsuarioFechaNacimiento = A57UsuarioFechaNacimiento;
            Z59UsuarioCalleNum = A59UsuarioCalleNum;
            Z60UsuarioColonia = A60UsuarioColonia;
            Z61UsuarioDelegacion = A61UsuarioDelegacion;
            Z62UsuarioCP = A62UsuarioCP;
            Z64UsuarioCelular = A64UsuarioCelular;
            Z65UsuarioTelefonoSucursal = A65UsuarioTelefonoSucursal;
            Z66UsuarioSucursal = A66UsuarioSucursal;
            Z67UsuarioProducto = A67UsuarioProducto;
            Z40UsuarioRol = A40UsuarioRol;
            Z82UsuarioNoCuentaBROXEL = A82UsuarioNoCuentaBROXEL;
            Z83UsuarioReferenciaBROXEL = A83UsuarioReferenciaBROXEL;
            Z13PuestoID = A13PuestoID;
            Z4CiudadID = A4CiudadID;
            Z14PuestoDescripcion = A14PuestoDescripcion;
            Z5CiudadDescripcion = A5CiudadDescripcion;
            Z1EstadoID = A1EstadoID;
            Z2EstadoDescripcion = A2EstadoDescripcion;
            Z16PaisID = A16PaisID;
            Z17PaisDescripcion = A17PaisDescripcion;
            Z28MedidaDescripcion = A28MedidaDescripcion;
            Z74MedidaRin = A74MedidaRin;
            Z27MedidaCodigo = A27MedidaCodigo;
            Z22ModeloID = A22ModeloID;
            Z23ModeloDescripcion = A23ModeloDescripcion;
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

      protected void Load0G16( )
      {
         /* Using cursor T000G14 */
         pr_default.execute(12, new Object[] {A77FacturaMedidaID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound16 = 1;
            A42PromocionDescripcion = T000G14_A42PromocionDescripcion[0];
            AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
            A43PromocionBase = T000G14_A43PromocionBase[0];
            AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
            A40000PromocionArte_GXI = T000G14_A40000PromocionArte_GXI[0];
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            A71FacturaNo = T000G14_A71FacturaNo[0];
            AssignAttri("", false, "A71FacturaNo", A71FacturaNo);
            A73FacturaFechaFactura = T000G14_A73FacturaFechaFactura[0];
            AssignAttri("", false, "A73FacturaFechaFactura", context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"));
            A72FacturaFechaRegistro = T000G14_A72FacturaFechaRegistro[0];
            AssignAttri("", false, "A72FacturaFechaRegistro", context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"));
            A63UsuarioZona = T000G14_A63UsuarioZona[0];
            AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
            A2EstadoDescripcion = T000G14_A2EstadoDescripcion[0];
            AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
            A5CiudadDescripcion = T000G14_A5CiudadDescripcion[0];
            AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
            A17PaisDescripcion = T000G14_A17PaisDescripcion[0];
            AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
            A53UsuarioGenero = T000G14_A53UsuarioGenero[0];
            AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
            A40001FacturaPDF_GXI = T000G14_A40001FacturaPDF_GXI[0];
            A80FacturaEstatus = T000G14_A80FacturaEstatus[0];
            AssignAttri("", false, "A80FacturaEstatus", A80FacturaEstatus);
            A20MotivoRechazoDescripcion = T000G14_A20MotivoRechazoDescripcion[0];
            AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
            A21MotivoRechazoActivo = T000G14_A21MotivoRechazoActivo[0];
            AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
            A28MedidaDescripcion = T000G14_A28MedidaDescripcion[0];
            AssignAttri("", false, "A28MedidaDescripcion", A28MedidaDescripcion);
            A74MedidaRin = T000G14_A74MedidaRin[0];
            AssignAttri("", false, "A74MedidaRin", A74MedidaRin);
            A27MedidaCodigo = T000G14_A27MedidaCodigo[0];
            AssignAttri("", false, "A27MedidaCodigo", A27MedidaCodigo);
            A23ModeloDescripcion = T000G14_A23ModeloDescripcion[0];
            AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
            A78FacturaMedidaCantidad = T000G14_A78FacturaMedidaCantidad[0];
            AssignAttri("", false, "A78FacturaMedidaCantidad", StringUtil.LTrimStr( (decimal)(A78FacturaMedidaCantidad), 4, 0));
            A79FacturaMedidaPrecio = T000G14_A79FacturaMedidaPrecio[0];
            AssignAttri("", false, "A79FacturaMedidaPrecio", StringUtil.LTrimStr( A79FacturaMedidaPrecio, 10, 2));
            A30UsuarioNombre = T000G14_A30UsuarioNombre[0];
            AssignAttri("", false, "A30UsuarioNombre", A30UsuarioNombre);
            A51UsuarioApellido = T000G14_A51UsuarioApellido[0];
            AssignAttri("", false, "A51UsuarioApellido", A51UsuarioApellido);
            A31UsuarioCorreo = T000G14_A31UsuarioCorreo[0];
            AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
            A32UsuarioPass = T000G14_A32UsuarioPass[0];
            AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
            A33UsuarioKey = T000G14_A33UsuarioKey[0];
            AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
            A14PuestoDescripcion = T000G14_A14PuestoDescripcion[0];
            AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
            A54UsuarioDirectoAsociado = T000G14_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = T000G14_n54UsuarioDirectoAsociado[0];
            AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
            A55UsuarioRazonSocialAsociado = T000G14_A55UsuarioRazonSocialAsociado[0];
            AssignAttri("", false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
            A56UsuarioNombreComercial = T000G14_A56UsuarioNombreComercial[0];
            AssignAttri("", false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
            A57UsuarioFechaNacimiento = T000G14_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = T000G14_n57UsuarioFechaNacimiento[0];
            AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
            A59UsuarioCalleNum = T000G14_A59UsuarioCalleNum[0];
            AssignAttri("", false, "A59UsuarioCalleNum", A59UsuarioCalleNum);
            A60UsuarioColonia = T000G14_A60UsuarioColonia[0];
            AssignAttri("", false, "A60UsuarioColonia", A60UsuarioColonia);
            A61UsuarioDelegacion = T000G14_A61UsuarioDelegacion[0];
            AssignAttri("", false, "A61UsuarioDelegacion", A61UsuarioDelegacion);
            A62UsuarioCP = T000G14_A62UsuarioCP[0];
            AssignAttri("", false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
            A64UsuarioCelular = T000G14_A64UsuarioCelular[0];
            AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
            A65UsuarioTelefonoSucursal = T000G14_A65UsuarioTelefonoSucursal[0];
            AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
            A66UsuarioSucursal = T000G14_A66UsuarioSucursal[0];
            AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
            A67UsuarioProducto = T000G14_A67UsuarioProducto[0];
            n67UsuarioProducto = T000G14_n67UsuarioProducto[0];
            AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
            A40UsuarioRol = T000G14_A40UsuarioRol[0];
            AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
            A82UsuarioNoCuentaBROXEL = T000G14_A82UsuarioNoCuentaBROXEL[0];
            AssignAttri("", false, "A82UsuarioNoCuentaBROXEL", A82UsuarioNoCuentaBROXEL);
            A83UsuarioReferenciaBROXEL = T000G14_A83UsuarioReferenciaBROXEL[0];
            AssignAttri("", false, "A83UsuarioReferenciaBROXEL", A83UsuarioReferenciaBROXEL);
            A45PromocionFechaInicio = T000G14_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = T000G14_A46PromocionFechaFin[0];
            A69FacturaID = T000G14_A69FacturaID[0];
            AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
            A26MedidaID = T000G14_A26MedidaID[0];
            AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
            A41PromocionID = T000G14_A41PromocionID[0];
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            A19MotivoRechazoID = T000G14_A19MotivoRechazoID[0];
            AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrimStr( (decimal)(A19MotivoRechazoID), 9, 0));
            A29UsuarioID = T000G14_A29UsuarioID[0];
            AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
            A13PuestoID = T000G14_A13PuestoID[0];
            n13PuestoID = T000G14_n13PuestoID[0];
            AssignAttri("", false, "A13PuestoID", StringUtil.LTrimStr( (decimal)(A13PuestoID), 9, 0));
            A4CiudadID = T000G14_A4CiudadID[0];
            n4CiudadID = T000G14_n4CiudadID[0];
            AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
            A1EstadoID = T000G14_A1EstadoID[0];
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            A16PaisID = T000G14_A16PaisID[0];
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            A22ModeloID = T000G14_A22ModeloID[0];
            AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
            A44PromocionArte = T000G14_A44PromocionArte[0];
            AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            A75FacturaPDF = T000G14_A75FacturaPDF[0];
            AssignAttri("", false, "A75FacturaPDF", A75FacturaPDF);
            AssignProp("", false, edtFacturaPDF_Internalname, "Multimedia", (String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)) ? A40001FacturaPDF_GXI : context.convertURL( context.PathToRelativeUrl( A75FacturaPDF))), true);
            ZM0G16( -3) ;
         }
         pr_default.close(12);
         OnLoadActions0G16( ) ;
      }

      protected void OnLoadActions0G16( )
      {
         A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         AssignAttri("", false, "A70PromocionVigencia", A70PromocionVigencia);
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
      }

      protected void CheckExtendedTable0G16( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000G4 */
         pr_default.execute(2, new Object[] {A69FacturaID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Factura", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "FACTURAID");
            AnyError = 1;
            GX_FocusControl = edtFacturaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A71FacturaNo = T000G4_A71FacturaNo[0];
         AssignAttri("", false, "A71FacturaNo", A71FacturaNo);
         A73FacturaFechaFactura = T000G4_A73FacturaFechaFactura[0];
         AssignAttri("", false, "A73FacturaFechaFactura", context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"));
         A72FacturaFechaRegistro = T000G4_A72FacturaFechaRegistro[0];
         AssignAttri("", false, "A72FacturaFechaRegistro", context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"));
         A40001FacturaPDF_GXI = T000G4_A40001FacturaPDF_GXI[0];
         A80FacturaEstatus = T000G4_A80FacturaEstatus[0];
         AssignAttri("", false, "A80FacturaEstatus", A80FacturaEstatus);
         A41PromocionID = T000G4_A41PromocionID[0];
         AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
         A19MotivoRechazoID = T000G4_A19MotivoRechazoID[0];
         AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrimStr( (decimal)(A19MotivoRechazoID), 9, 0));
         A29UsuarioID = T000G4_A29UsuarioID[0];
         AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
         A75FacturaPDF = T000G4_A75FacturaPDF[0];
         AssignAttri("", false, "A75FacturaPDF", A75FacturaPDF);
         AssignProp("", false, edtFacturaPDF_Internalname, "Multimedia", (String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)) ? A40001FacturaPDF_GXI : context.convertURL( context.PathToRelativeUrl( A75FacturaPDF))), true);
         pr_default.close(2);
         /* Using cursor T000G6 */
         pr_default.execute(4, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
         }
         A42PromocionDescripcion = T000G6_A42PromocionDescripcion[0];
         AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
         A43PromocionBase = T000G6_A43PromocionBase[0];
         AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
         A40000PromocionArte_GXI = T000G6_A40000PromocionArte_GXI[0];
         AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
         AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
         A45PromocionFechaInicio = T000G6_A45PromocionFechaInicio[0];
         A46PromocionFechaFin = T000G6_A46PromocionFechaFin[0];
         A44PromocionArte = T000G6_A44PromocionArte[0];
         AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
         AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
         AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
         pr_default.close(4);
         A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         AssignAttri("", false, "A70PromocionVigencia", A70PromocionVigencia);
         /* Using cursor T000G7 */
         pr_default.execute(5, new Object[] {A19MotivoRechazoID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Motivo Rechazo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MOTIVORECHAZOID");
            AnyError = 1;
         }
         A20MotivoRechazoDescripcion = T000G7_A20MotivoRechazoDescripcion[0];
         AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
         A21MotivoRechazoActivo = T000G7_A21MotivoRechazoActivo[0];
         AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
         pr_default.close(5);
         /* Using cursor T000G8 */
         pr_default.execute(6, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
         }
         A63UsuarioZona = T000G8_A63UsuarioZona[0];
         AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
         A53UsuarioGenero = T000G8_A53UsuarioGenero[0];
         AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
         A30UsuarioNombre = T000G8_A30UsuarioNombre[0];
         AssignAttri("", false, "A30UsuarioNombre", A30UsuarioNombre);
         A51UsuarioApellido = T000G8_A51UsuarioApellido[0];
         AssignAttri("", false, "A51UsuarioApellido", A51UsuarioApellido);
         A31UsuarioCorreo = T000G8_A31UsuarioCorreo[0];
         AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
         A32UsuarioPass = T000G8_A32UsuarioPass[0];
         AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
         A33UsuarioKey = T000G8_A33UsuarioKey[0];
         AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
         A54UsuarioDirectoAsociado = T000G8_A54UsuarioDirectoAsociado[0];
         n54UsuarioDirectoAsociado = T000G8_n54UsuarioDirectoAsociado[0];
         AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
         A55UsuarioRazonSocialAsociado = T000G8_A55UsuarioRazonSocialAsociado[0];
         AssignAttri("", false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
         A56UsuarioNombreComercial = T000G8_A56UsuarioNombreComercial[0];
         AssignAttri("", false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
         A57UsuarioFechaNacimiento = T000G8_A57UsuarioFechaNacimiento[0];
         n57UsuarioFechaNacimiento = T000G8_n57UsuarioFechaNacimiento[0];
         AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
         A59UsuarioCalleNum = T000G8_A59UsuarioCalleNum[0];
         AssignAttri("", false, "A59UsuarioCalleNum", A59UsuarioCalleNum);
         A60UsuarioColonia = T000G8_A60UsuarioColonia[0];
         AssignAttri("", false, "A60UsuarioColonia", A60UsuarioColonia);
         A61UsuarioDelegacion = T000G8_A61UsuarioDelegacion[0];
         AssignAttri("", false, "A61UsuarioDelegacion", A61UsuarioDelegacion);
         A62UsuarioCP = T000G8_A62UsuarioCP[0];
         AssignAttri("", false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
         A64UsuarioCelular = T000G8_A64UsuarioCelular[0];
         AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
         A65UsuarioTelefonoSucursal = T000G8_A65UsuarioTelefonoSucursal[0];
         AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
         A66UsuarioSucursal = T000G8_A66UsuarioSucursal[0];
         AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
         A67UsuarioProducto = T000G8_A67UsuarioProducto[0];
         n67UsuarioProducto = T000G8_n67UsuarioProducto[0];
         AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
         A40UsuarioRol = T000G8_A40UsuarioRol[0];
         AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
         A82UsuarioNoCuentaBROXEL = T000G8_A82UsuarioNoCuentaBROXEL[0];
         AssignAttri("", false, "A82UsuarioNoCuentaBROXEL", A82UsuarioNoCuentaBROXEL);
         A83UsuarioReferenciaBROXEL = T000G8_A83UsuarioReferenciaBROXEL[0];
         AssignAttri("", false, "A83UsuarioReferenciaBROXEL", A83UsuarioReferenciaBROXEL);
         A13PuestoID = T000G8_A13PuestoID[0];
         n13PuestoID = T000G8_n13PuestoID[0];
         AssignAttri("", false, "A13PuestoID", StringUtil.LTrimStr( (decimal)(A13PuestoID), 9, 0));
         A4CiudadID = T000G8_A4CiudadID[0];
         n4CiudadID = T000G8_n4CiudadID[0];
         AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
         pr_default.close(6);
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
         /* Using cursor T000G9 */
         pr_default.execute(7, new Object[] {n13PuestoID, A13PuestoID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A13PuestoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Puesto", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PUESTOID");
               AnyError = 1;
            }
         }
         A14PuestoDescripcion = T000G9_A14PuestoDescripcion[0];
         AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
         pr_default.close(7);
         /* Using cursor T000G10 */
         pr_default.execute(8, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
            }
         }
         A5CiudadDescripcion = T000G10_A5CiudadDescripcion[0];
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         A1EstadoID = T000G10_A1EstadoID[0];
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
         pr_default.close(8);
         /* Using cursor T000G11 */
         pr_default.execute(9, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A2EstadoDescripcion = T000G11_A2EstadoDescripcion[0];
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         A16PaisID = T000G11_A16PaisID[0];
         AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
         pr_default.close(9);
         /* Using cursor T000G12 */
         pr_default.execute(10, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = T000G12_A17PaisDescripcion[0];
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
         pr_default.close(10);
         /* Using cursor T000G5 */
         pr_default.execute(3, new Object[] {A26MedidaID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Medida", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDIDAID");
            AnyError = 1;
            GX_FocusControl = edtMedidaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28MedidaDescripcion = T000G5_A28MedidaDescripcion[0];
         AssignAttri("", false, "A28MedidaDescripcion", A28MedidaDescripcion);
         A74MedidaRin = T000G5_A74MedidaRin[0];
         AssignAttri("", false, "A74MedidaRin", A74MedidaRin);
         A27MedidaCodigo = T000G5_A27MedidaCodigo[0];
         AssignAttri("", false, "A27MedidaCodigo", A27MedidaCodigo);
         A22ModeloID = T000G5_A22ModeloID[0];
         AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
         pr_default.close(3);
         /* Using cursor T000G13 */
         pr_default.execute(11, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Modelo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MODELOID");
            AnyError = 1;
         }
         A23ModeloDescripcion = T000G13_A23ModeloDescripcion[0];
         AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
         pr_default.close(11);
      }

      protected void CloseExtendedTableCursors0G16( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
         pr_default.close(3);
         pr_default.close(11);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( int A69FacturaID )
      {
         /* Using cursor T000G15 */
         pr_default.execute(13, new Object[] {A69FacturaID});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Factura", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "FACTURAID");
            AnyError = 1;
            GX_FocusControl = edtFacturaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A71FacturaNo = T000G15_A71FacturaNo[0];
         AssignAttri("", false, "A71FacturaNo", A71FacturaNo);
         A73FacturaFechaFactura = T000G15_A73FacturaFechaFactura[0];
         AssignAttri("", false, "A73FacturaFechaFactura", context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"));
         A72FacturaFechaRegistro = T000G15_A72FacturaFechaRegistro[0];
         AssignAttri("", false, "A72FacturaFechaRegistro", context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"));
         A40001FacturaPDF_GXI = T000G15_A40001FacturaPDF_GXI[0];
         A80FacturaEstatus = T000G15_A80FacturaEstatus[0];
         AssignAttri("", false, "A80FacturaEstatus", A80FacturaEstatus);
         A41PromocionID = T000G15_A41PromocionID[0];
         AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
         A19MotivoRechazoID = T000G15_A19MotivoRechazoID[0];
         AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrimStr( (decimal)(A19MotivoRechazoID), 9, 0));
         A29UsuarioID = T000G15_A29UsuarioID[0];
         AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
         A75FacturaPDF = T000G15_A75FacturaPDF[0];
         AssignAttri("", false, "A75FacturaPDF", A75FacturaPDF);
         AssignProp("", false, edtFacturaPDF_Internalname, "Multimedia", (String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)) ? A40001FacturaPDF_GXI : context.convertURL( context.PathToRelativeUrl( A75FacturaPDF))), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A71FacturaNo))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"))+"\""+","+"\""+GXUtil.EncodeJSConstant( A75FacturaPDF)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40001FacturaPDF_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A80FacturaEstatus))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MotivoRechazoID), 9, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_6( int A41PromocionID )
      {
         /* Using cursor T000G16 */
         pr_default.execute(14, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
         }
         A42PromocionDescripcion = T000G16_A42PromocionDescripcion[0];
         AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
         A43PromocionBase = T000G16_A43PromocionBase[0];
         AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
         A40000PromocionArte_GXI = T000G16_A40000PromocionArte_GXI[0];
         AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
         AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
         A45PromocionFechaInicio = T000G16_A45PromocionFechaInicio[0];
         A46PromocionFechaFin = T000G16_A46PromocionFechaFin[0];
         A44PromocionArte = T000G16_A44PromocionArte[0];
         AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
         AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
         AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A42PromocionDescripcion)+"\""+","+"\""+GXUtil.EncodeJSConstant( A43PromocionBase)+"\""+","+"\""+GXUtil.EncodeJSConstant( A44PromocionArte)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000PromocionArte_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A46PromocionFechaFin, "99/99/99"))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_7( int A19MotivoRechazoID )
      {
         /* Using cursor T000G17 */
         pr_default.execute(15, new Object[] {A19MotivoRechazoID});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Motivo Rechazo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MOTIVORECHAZOID");
            AnyError = 1;
         }
         A20MotivoRechazoDescripcion = T000G17_A20MotivoRechazoDescripcion[0];
         AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
         A21MotivoRechazoActivo = T000G17_A21MotivoRechazoActivo[0];
         AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A20MotivoRechazoDescripcion)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A21MotivoRechazoActivo))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_8( int A29UsuarioID )
      {
         /* Using cursor T000G18 */
         pr_default.execute(16, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
         }
         A63UsuarioZona = T000G18_A63UsuarioZona[0];
         AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
         A53UsuarioGenero = T000G18_A53UsuarioGenero[0];
         AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
         A30UsuarioNombre = T000G18_A30UsuarioNombre[0];
         AssignAttri("", false, "A30UsuarioNombre", A30UsuarioNombre);
         A51UsuarioApellido = T000G18_A51UsuarioApellido[0];
         AssignAttri("", false, "A51UsuarioApellido", A51UsuarioApellido);
         A31UsuarioCorreo = T000G18_A31UsuarioCorreo[0];
         AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
         A32UsuarioPass = T000G18_A32UsuarioPass[0];
         AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
         A33UsuarioKey = T000G18_A33UsuarioKey[0];
         AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
         A54UsuarioDirectoAsociado = T000G18_A54UsuarioDirectoAsociado[0];
         n54UsuarioDirectoAsociado = T000G18_n54UsuarioDirectoAsociado[0];
         AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
         A55UsuarioRazonSocialAsociado = T000G18_A55UsuarioRazonSocialAsociado[0];
         AssignAttri("", false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
         A56UsuarioNombreComercial = T000G18_A56UsuarioNombreComercial[0];
         AssignAttri("", false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
         A57UsuarioFechaNacimiento = T000G18_A57UsuarioFechaNacimiento[0];
         n57UsuarioFechaNacimiento = T000G18_n57UsuarioFechaNacimiento[0];
         AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
         A59UsuarioCalleNum = T000G18_A59UsuarioCalleNum[0];
         AssignAttri("", false, "A59UsuarioCalleNum", A59UsuarioCalleNum);
         A60UsuarioColonia = T000G18_A60UsuarioColonia[0];
         AssignAttri("", false, "A60UsuarioColonia", A60UsuarioColonia);
         A61UsuarioDelegacion = T000G18_A61UsuarioDelegacion[0];
         AssignAttri("", false, "A61UsuarioDelegacion", A61UsuarioDelegacion);
         A62UsuarioCP = T000G18_A62UsuarioCP[0];
         AssignAttri("", false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
         A64UsuarioCelular = T000G18_A64UsuarioCelular[0];
         AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
         A65UsuarioTelefonoSucursal = T000G18_A65UsuarioTelefonoSucursal[0];
         AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
         A66UsuarioSucursal = T000G18_A66UsuarioSucursal[0];
         AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
         A67UsuarioProducto = T000G18_A67UsuarioProducto[0];
         n67UsuarioProducto = T000G18_n67UsuarioProducto[0];
         AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
         A40UsuarioRol = T000G18_A40UsuarioRol[0];
         AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
         A82UsuarioNoCuentaBROXEL = T000G18_A82UsuarioNoCuentaBROXEL[0];
         AssignAttri("", false, "A82UsuarioNoCuentaBROXEL", A82UsuarioNoCuentaBROXEL);
         A83UsuarioReferenciaBROXEL = T000G18_A83UsuarioReferenciaBROXEL[0];
         AssignAttri("", false, "A83UsuarioReferenciaBROXEL", A83UsuarioReferenciaBROXEL);
         A13PuestoID = T000G18_A13PuestoID[0];
         n13PuestoID = T000G18_n13PuestoID[0];
         AssignAttri("", false, "A13PuestoID", StringUtil.LTrimStr( (decimal)(A13PuestoID), 9, 0));
         A4CiudadID = T000G18_A4CiudadID[0];
         n4CiudadID = T000G18_n4CiudadID[0];
         AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A63UsuarioZona))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A53UsuarioGenero))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A30UsuarioNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A51UsuarioApellido))+"\""+","+"\""+GXUtil.EncodeJSConstant( A31UsuarioCorreo)+"\""+","+"\""+GXUtil.EncodeJSConstant( A32UsuarioPass)+"\""+","+"\""+GXUtil.EncodeJSConstant( A33UsuarioKey)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A54UsuarioDirectoAsociado))+"\""+","+"\""+GXUtil.EncodeJSConstant( A55UsuarioRazonSocialAsociado)+"\""+","+"\""+GXUtil.EncodeJSConstant( A56UsuarioNombreComercial)+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A59UsuarioCalleNum))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A60UsuarioColonia))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A61UsuarioDelegacion))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A62UsuarioCP), 5, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A64UsuarioCelular), 10, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A65UsuarioTelefonoSucursal), 10, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A66UsuarioSucursal))+"\""+","+"\""+GXUtil.EncodeJSConstant( A67UsuarioProducto)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A40UsuarioRol))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A82UsuarioNoCuentaBROXEL))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A83UsuarioReferenciaBROXEL))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PuestoID), 9, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_9( int A13PuestoID )
      {
         /* Using cursor T000G19 */
         pr_default.execute(17, new Object[] {n13PuestoID, A13PuestoID});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (0==A13PuestoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Puesto", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PUESTOID");
               AnyError = 1;
            }
         }
         A14PuestoDescripcion = T000G19_A14PuestoDescripcion[0];
         AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A14PuestoDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_10( int A4CiudadID )
      {
         /* Using cursor T000G20 */
         pr_default.execute(18, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
            }
         }
         A5CiudadDescripcion = T000G20_A5CiudadDescripcion[0];
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         A1EstadoID = T000G20_A1EstadoID[0];
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A5CiudadDescripcion)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_11( int A1EstadoID )
      {
         /* Using cursor T000G21 */
         pr_default.execute(19, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A2EstadoDescripcion = T000G21_A2EstadoDescripcion[0];
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         A16PaisID = T000G21_A16PaisID[0];
         AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2EstadoDescripcion)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_12( int A16PaisID )
      {
         /* Using cursor T000G22 */
         pr_default.execute(20, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = T000G22_A17PaisDescripcion[0];
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A17PaisDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void gxLoad_5( int A26MedidaID )
      {
         /* Using cursor T000G23 */
         pr_default.execute(21, new Object[] {A26MedidaID});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Medida", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDIDAID");
            AnyError = 1;
            GX_FocusControl = edtMedidaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28MedidaDescripcion = T000G23_A28MedidaDescripcion[0];
         AssignAttri("", false, "A28MedidaDescripcion", A28MedidaDescripcion);
         A74MedidaRin = T000G23_A74MedidaRin[0];
         AssignAttri("", false, "A74MedidaRin", A74MedidaRin);
         A27MedidaCodigo = T000G23_A27MedidaCodigo[0];
         AssignAttri("", false, "A27MedidaCodigo", A27MedidaCodigo);
         A22ModeloID = T000G23_A22ModeloID[0];
         AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A28MedidaDescripcion)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A74MedidaRin))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A27MedidaCodigo))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22ModeloID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(21) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(21);
      }

      protected void gxLoad_13( int A22ModeloID )
      {
         /* Using cursor T000G24 */
         pr_default.execute(22, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Modelo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MODELOID");
            AnyError = 1;
         }
         A23ModeloDescripcion = T000G24_A23ModeloDescripcion[0];
         AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A23ModeloDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(22) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(22);
      }

      protected void GetKey0G16( )
      {
         /* Using cursor T000G25 */
         pr_default.execute(23, new Object[] {A77FacturaMedidaID});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(23);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000G3 */
         pr_default.execute(1, new Object[] {A77FacturaMedidaID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G16( 3) ;
            RcdFound16 = 1;
            A77FacturaMedidaID = T000G3_A77FacturaMedidaID[0];
            AssignAttri("", false, "A77FacturaMedidaID", StringUtil.LTrimStr( (decimal)(A77FacturaMedidaID), 9, 0));
            A78FacturaMedidaCantidad = T000G3_A78FacturaMedidaCantidad[0];
            AssignAttri("", false, "A78FacturaMedidaCantidad", StringUtil.LTrimStr( (decimal)(A78FacturaMedidaCantidad), 4, 0));
            A79FacturaMedidaPrecio = T000G3_A79FacturaMedidaPrecio[0];
            AssignAttri("", false, "A79FacturaMedidaPrecio", StringUtil.LTrimStr( A79FacturaMedidaPrecio, 10, 2));
            A69FacturaID = T000G3_A69FacturaID[0];
            AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
            A26MedidaID = T000G3_A26MedidaID[0];
            AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
            Z77FacturaMedidaID = A77FacturaMedidaID;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0G16( ) ;
            if ( AnyError == 1 )
            {
               RcdFound16 = 0;
               InitializeNonKey0G16( ) ;
            }
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0G16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G16( ) ;
         if ( RcdFound16 == 0 )
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
         RcdFound16 = 0;
         /* Using cursor T000G26 */
         pr_default.execute(24, new Object[] {A77FacturaMedidaID});
         if ( (pr_default.getStatus(24) != 101) )
         {
            while ( (pr_default.getStatus(24) != 101) && ( ( T000G26_A77FacturaMedidaID[0] < A77FacturaMedidaID ) ) )
            {
               pr_default.readNext(24);
            }
            if ( (pr_default.getStatus(24) != 101) && ( ( T000G26_A77FacturaMedidaID[0] > A77FacturaMedidaID ) ) )
            {
               A77FacturaMedidaID = T000G26_A77FacturaMedidaID[0];
               AssignAttri("", false, "A77FacturaMedidaID", StringUtil.LTrimStr( (decimal)(A77FacturaMedidaID), 9, 0));
               RcdFound16 = 1;
            }
         }
         pr_default.close(24);
      }

      protected void move_previous( )
      {
         RcdFound16 = 0;
         /* Using cursor T000G27 */
         pr_default.execute(25, new Object[] {A77FacturaMedidaID});
         if ( (pr_default.getStatus(25) != 101) )
         {
            while ( (pr_default.getStatus(25) != 101) && ( ( T000G27_A77FacturaMedidaID[0] > A77FacturaMedidaID ) ) )
            {
               pr_default.readNext(25);
            }
            if ( (pr_default.getStatus(25) != 101) && ( ( T000G27_A77FacturaMedidaID[0] < A77FacturaMedidaID ) ) )
            {
               A77FacturaMedidaID = T000G27_A77FacturaMedidaID[0];
               AssignAttri("", false, "A77FacturaMedidaID", StringUtil.LTrimStr( (decimal)(A77FacturaMedidaID), 9, 0));
               RcdFound16 = 1;
            }
         }
         pr_default.close(25);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0G16( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFacturaMedidaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0G16( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound16 == 1 )
            {
               if ( A77FacturaMedidaID != Z77FacturaMedidaID )
               {
                  A77FacturaMedidaID = Z77FacturaMedidaID;
                  AssignAttri("", false, "A77FacturaMedidaID", StringUtil.LTrimStr( (decimal)(A77FacturaMedidaID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FACTURAMEDIDAID");
                  AnyError = 1;
                  GX_FocusControl = edtFacturaMedidaID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFacturaMedidaID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0G16( ) ;
                  GX_FocusControl = edtFacturaMedidaID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A77FacturaMedidaID != Z77FacturaMedidaID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtFacturaMedidaID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0G16( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FACTURAMEDIDAID");
                     AnyError = 1;
                     GX_FocusControl = edtFacturaMedidaID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtFacturaMedidaID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0G16( ) ;
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
         if ( A77FacturaMedidaID != Z77FacturaMedidaID )
         {
            A77FacturaMedidaID = Z77FacturaMedidaID;
            AssignAttri("", false, "A77FacturaMedidaID", StringUtil.LTrimStr( (decimal)(A77FacturaMedidaID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FACTURAMEDIDAID");
            AnyError = 1;
            GX_FocusControl = edtFacturaMedidaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFacturaMedidaID_Internalname;
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
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "FACTURAMEDIDAID");
            AnyError = 1;
            GX_FocusControl = edtFacturaMedidaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtFacturaID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0G16( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFacturaID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G16( ) ;
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
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFacturaID_Internalname;
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
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFacturaID_Internalname;
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
         ScanStart0G16( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound16 != 0 )
            {
               ScanNext0G16( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFacturaID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G16( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0G16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000G2 */
            pr_default.execute(0, new Object[] {A77FacturaMedidaID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FacturaMedida"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z78FacturaMedidaCantidad != T000G2_A78FacturaMedidaCantidad[0] ) || ( Z79FacturaMedidaPrecio != T000G2_A79FacturaMedidaPrecio[0] ) || ( Z69FacturaID != T000G2_A69FacturaID[0] ) || ( Z26MedidaID != T000G2_A26MedidaID[0] ) )
            {
               if ( Z78FacturaMedidaCantidad != T000G2_A78FacturaMedidaCantidad[0] )
               {
                  GXUtil.WriteLog("facturamedida:[seudo value changed for attri]"+"FacturaMedidaCantidad");
                  GXUtil.WriteLogRaw("Old: ",Z78FacturaMedidaCantidad);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A78FacturaMedidaCantidad[0]);
               }
               if ( Z79FacturaMedidaPrecio != T000G2_A79FacturaMedidaPrecio[0] )
               {
                  GXUtil.WriteLog("facturamedida:[seudo value changed for attri]"+"FacturaMedidaPrecio");
                  GXUtil.WriteLogRaw("Old: ",Z79FacturaMedidaPrecio);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A79FacturaMedidaPrecio[0]);
               }
               if ( Z69FacturaID != T000G2_A69FacturaID[0] )
               {
                  GXUtil.WriteLog("facturamedida:[seudo value changed for attri]"+"FacturaID");
                  GXUtil.WriteLogRaw("Old: ",Z69FacturaID);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A69FacturaID[0]);
               }
               if ( Z26MedidaID != T000G2_A26MedidaID[0] )
               {
                  GXUtil.WriteLog("facturamedida:[seudo value changed for attri]"+"MedidaID");
                  GXUtil.WriteLogRaw("Old: ",Z26MedidaID);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A26MedidaID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FacturaMedida"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G16( )
      {
         BeforeValidate0G16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G16( 0) ;
            CheckOptimisticConcurrency0G16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G28 */
                     pr_default.execute(26, new Object[] {A78FacturaMedidaCantidad, A79FacturaMedidaPrecio, A69FacturaID, A26MedidaID});
                     pr_default.close(26);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000G29 */
                     pr_default.execute(27);
                     A77FacturaMedidaID = T000G29_A77FacturaMedidaID[0];
                     AssignAttri("", false, "A77FacturaMedidaID", StringUtil.LTrimStr( (decimal)(A77FacturaMedidaID), 9, 0));
                     pr_default.close(27);
                     pr_default.SmartCacheProvider.SetUpdated("FacturaMedida");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0G0( ) ;
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
               Load0G16( ) ;
            }
            EndLevel0G16( ) ;
         }
         CloseExtendedTableCursors0G16( ) ;
      }

      protected void Update0G16( )
      {
         BeforeValidate0G16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G16( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G30 */
                     pr_default.execute(28, new Object[] {A78FacturaMedidaCantidad, A79FacturaMedidaPrecio, A69FacturaID, A26MedidaID, A77FacturaMedidaID});
                     pr_default.close(28);
                     pr_default.SmartCacheProvider.SetUpdated("FacturaMedida");
                     if ( (pr_default.getStatus(28) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FacturaMedida"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G16( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0G0( ) ;
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
            EndLevel0G16( ) ;
         }
         CloseExtendedTableCursors0G16( ) ;
      }

      protected void DeferredUpdate0G16( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0G16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G16( ) ;
            AfterConfirm0G16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G16( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000G31 */
                  pr_default.execute(29, new Object[] {A77FacturaMedidaID});
                  pr_default.close(29);
                  pr_default.SmartCacheProvider.SetUpdated("FacturaMedida");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound16 == 0 )
                        {
                           InitAll0G16( ) ;
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
                        ResetCaption0G0( ) ;
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
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0G16( ) ;
         Gx_mode = sMode16;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0G16( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000G32 */
            pr_default.execute(30, new Object[] {A69FacturaID});
            A71FacturaNo = T000G32_A71FacturaNo[0];
            AssignAttri("", false, "A71FacturaNo", A71FacturaNo);
            A73FacturaFechaFactura = T000G32_A73FacturaFechaFactura[0];
            AssignAttri("", false, "A73FacturaFechaFactura", context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"));
            A72FacturaFechaRegistro = T000G32_A72FacturaFechaRegistro[0];
            AssignAttri("", false, "A72FacturaFechaRegistro", context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"));
            A40001FacturaPDF_GXI = T000G32_A40001FacturaPDF_GXI[0];
            A80FacturaEstatus = T000G32_A80FacturaEstatus[0];
            AssignAttri("", false, "A80FacturaEstatus", A80FacturaEstatus);
            A41PromocionID = T000G32_A41PromocionID[0];
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            A19MotivoRechazoID = T000G32_A19MotivoRechazoID[0];
            AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrimStr( (decimal)(A19MotivoRechazoID), 9, 0));
            A29UsuarioID = T000G32_A29UsuarioID[0];
            AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
            A75FacturaPDF = T000G32_A75FacturaPDF[0];
            AssignAttri("", false, "A75FacturaPDF", A75FacturaPDF);
            AssignProp("", false, edtFacturaPDF_Internalname, "Multimedia", (String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)) ? A40001FacturaPDF_GXI : context.convertURL( context.PathToRelativeUrl( A75FacturaPDF))), true);
            pr_default.close(30);
            /* Using cursor T000G33 */
            pr_default.execute(31, new Object[] {A41PromocionID});
            A42PromocionDescripcion = T000G33_A42PromocionDescripcion[0];
            AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
            A43PromocionBase = T000G33_A43PromocionBase[0];
            AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
            A40000PromocionArte_GXI = T000G33_A40000PromocionArte_GXI[0];
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            A45PromocionFechaInicio = T000G33_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = T000G33_A46PromocionFechaFin[0];
            A44PromocionArte = T000G33_A44PromocionArte[0];
            AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            pr_default.close(31);
            A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            AssignAttri("", false, "A70PromocionVigencia", A70PromocionVigencia);
            /* Using cursor T000G34 */
            pr_default.execute(32, new Object[] {A19MotivoRechazoID});
            A20MotivoRechazoDescripcion = T000G34_A20MotivoRechazoDescripcion[0];
            AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
            A21MotivoRechazoActivo = T000G34_A21MotivoRechazoActivo[0];
            AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
            pr_default.close(32);
            /* Using cursor T000G35 */
            pr_default.execute(33, new Object[] {A29UsuarioID});
            A63UsuarioZona = T000G35_A63UsuarioZona[0];
            AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
            A53UsuarioGenero = T000G35_A53UsuarioGenero[0];
            AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
            A30UsuarioNombre = T000G35_A30UsuarioNombre[0];
            AssignAttri("", false, "A30UsuarioNombre", A30UsuarioNombre);
            A51UsuarioApellido = T000G35_A51UsuarioApellido[0];
            AssignAttri("", false, "A51UsuarioApellido", A51UsuarioApellido);
            A31UsuarioCorreo = T000G35_A31UsuarioCorreo[0];
            AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
            A32UsuarioPass = T000G35_A32UsuarioPass[0];
            AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
            A33UsuarioKey = T000G35_A33UsuarioKey[0];
            AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
            A54UsuarioDirectoAsociado = T000G35_A54UsuarioDirectoAsociado[0];
            n54UsuarioDirectoAsociado = T000G35_n54UsuarioDirectoAsociado[0];
            AssignAttri("", false, "A54UsuarioDirectoAsociado", A54UsuarioDirectoAsociado);
            A55UsuarioRazonSocialAsociado = T000G35_A55UsuarioRazonSocialAsociado[0];
            AssignAttri("", false, "A55UsuarioRazonSocialAsociado", A55UsuarioRazonSocialAsociado);
            A56UsuarioNombreComercial = T000G35_A56UsuarioNombreComercial[0];
            AssignAttri("", false, "A56UsuarioNombreComercial", A56UsuarioNombreComercial);
            A57UsuarioFechaNacimiento = T000G35_A57UsuarioFechaNacimiento[0];
            n57UsuarioFechaNacimiento = T000G35_n57UsuarioFechaNacimiento[0];
            AssignAttri("", false, "A57UsuarioFechaNacimiento", context.localUtil.Format(A57UsuarioFechaNacimiento, "99/99/9999"));
            A59UsuarioCalleNum = T000G35_A59UsuarioCalleNum[0];
            AssignAttri("", false, "A59UsuarioCalleNum", A59UsuarioCalleNum);
            A60UsuarioColonia = T000G35_A60UsuarioColonia[0];
            AssignAttri("", false, "A60UsuarioColonia", A60UsuarioColonia);
            A61UsuarioDelegacion = T000G35_A61UsuarioDelegacion[0];
            AssignAttri("", false, "A61UsuarioDelegacion", A61UsuarioDelegacion);
            A62UsuarioCP = T000G35_A62UsuarioCP[0];
            AssignAttri("", false, "A62UsuarioCP", StringUtil.LTrimStr( (decimal)(A62UsuarioCP), 5, 0));
            A64UsuarioCelular = T000G35_A64UsuarioCelular[0];
            AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
            A65UsuarioTelefonoSucursal = T000G35_A65UsuarioTelefonoSucursal[0];
            AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
            A66UsuarioSucursal = T000G35_A66UsuarioSucursal[0];
            AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
            A67UsuarioProducto = T000G35_A67UsuarioProducto[0];
            n67UsuarioProducto = T000G35_n67UsuarioProducto[0];
            AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
            A40UsuarioRol = T000G35_A40UsuarioRol[0];
            AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
            A82UsuarioNoCuentaBROXEL = T000G35_A82UsuarioNoCuentaBROXEL[0];
            AssignAttri("", false, "A82UsuarioNoCuentaBROXEL", A82UsuarioNoCuentaBROXEL);
            A83UsuarioReferenciaBROXEL = T000G35_A83UsuarioReferenciaBROXEL[0];
            AssignAttri("", false, "A83UsuarioReferenciaBROXEL", A83UsuarioReferenciaBROXEL);
            A13PuestoID = T000G35_A13PuestoID[0];
            n13PuestoID = T000G35_n13PuestoID[0];
            AssignAttri("", false, "A13PuestoID", StringUtil.LTrimStr( (decimal)(A13PuestoID), 9, 0));
            A4CiudadID = T000G35_A4CiudadID[0];
            n4CiudadID = T000G35_n4CiudadID[0];
            AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
            pr_default.close(33);
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
            /* Using cursor T000G36 */
            pr_default.execute(34, new Object[] {n13PuestoID, A13PuestoID});
            A14PuestoDescripcion = T000G36_A14PuestoDescripcion[0];
            AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
            pr_default.close(34);
            /* Using cursor T000G37 */
            pr_default.execute(35, new Object[] {n4CiudadID, A4CiudadID});
            A5CiudadDescripcion = T000G37_A5CiudadDescripcion[0];
            AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
            A1EstadoID = T000G37_A1EstadoID[0];
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            pr_default.close(35);
            /* Using cursor T000G38 */
            pr_default.execute(36, new Object[] {A1EstadoID});
            A2EstadoDescripcion = T000G38_A2EstadoDescripcion[0];
            AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
            A16PaisID = T000G38_A16PaisID[0];
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            pr_default.close(36);
            /* Using cursor T000G39 */
            pr_default.execute(37, new Object[] {A16PaisID});
            A17PaisDescripcion = T000G39_A17PaisDescripcion[0];
            AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
            pr_default.close(37);
            /* Using cursor T000G40 */
            pr_default.execute(38, new Object[] {A26MedidaID});
            A28MedidaDescripcion = T000G40_A28MedidaDescripcion[0];
            AssignAttri("", false, "A28MedidaDescripcion", A28MedidaDescripcion);
            A74MedidaRin = T000G40_A74MedidaRin[0];
            AssignAttri("", false, "A74MedidaRin", A74MedidaRin);
            A27MedidaCodigo = T000G40_A27MedidaCodigo[0];
            AssignAttri("", false, "A27MedidaCodigo", A27MedidaCodigo);
            A22ModeloID = T000G40_A22ModeloID[0];
            AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
            pr_default.close(38);
            /* Using cursor T000G41 */
            pr_default.execute(39, new Object[] {A22ModeloID});
            A23ModeloDescripcion = T000G41_A23ModeloDescripcion[0];
            AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
            pr_default.close(39);
         }
      }

      protected void EndLevel0G16( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G16( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("facturamedida",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("facturamedida",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0G16( )
      {
         /* Using cursor T000G42 */
         pr_default.execute(40);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound16 = 1;
            A77FacturaMedidaID = T000G42_A77FacturaMedidaID[0];
            AssignAttri("", false, "A77FacturaMedidaID", StringUtil.LTrimStr( (decimal)(A77FacturaMedidaID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0G16( )
      {
         /* Scan next routine */
         pr_default.readNext(40);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound16 = 1;
            A77FacturaMedidaID = T000G42_A77FacturaMedidaID[0];
            AssignAttri("", false, "A77FacturaMedidaID", StringUtil.LTrimStr( (decimal)(A77FacturaMedidaID), 9, 0));
         }
      }

      protected void ScanEnd0G16( )
      {
         pr_default.close(40);
      }

      protected void AfterConfirm0G16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G16( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G16( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G16( )
      {
         edtFacturaMedidaID_Enabled = 0;
         AssignProp("", false, edtFacturaMedidaID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFacturaMedidaID_Enabled), 5, 0), true);
         edtFacturaID_Enabled = 0;
         AssignProp("", false, edtFacturaID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFacturaID_Enabled), 5, 0), true);
         edtPromocionDescripcion_Enabled = 0;
         AssignProp("", false, edtPromocionDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionDescripcion_Enabled), 5, 0), true);
         edtPromocionBase_Enabled = 0;
         AssignProp("", false, edtPromocionBase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionBase_Enabled), 5, 0), true);
         imgPromocionArte_Enabled = 0;
         AssignProp("", false, imgPromocionArte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgPromocionArte_Enabled), 5, 0), true);
         edtPromocionVigencia_Enabled = 0;
         AssignProp("", false, edtPromocionVigencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionVigencia_Enabled), 5, 0), true);
         edtFacturaNo_Enabled = 0;
         AssignProp("", false, edtFacturaNo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFacturaNo_Enabled), 5, 0), true);
         edtFacturaFechaFactura_Enabled = 0;
         AssignProp("", false, edtFacturaFechaFactura_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFacturaFechaFactura_Enabled), 5, 0), true);
         edtFacturaFechaRegistro_Enabled = 0;
         AssignProp("", false, edtFacturaFechaRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFacturaFechaRegistro_Enabled), 5, 0), true);
         edtUsuarioID_Enabled = 0;
         AssignProp("", false, edtUsuarioID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioID_Enabled), 5, 0), true);
         edtUsuarioNombreCompleto_Enabled = 0;
         AssignProp("", false, edtUsuarioNombreCompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombreCompleto_Enabled), 5, 0), true);
         cmbUsuarioZona.Enabled = 0;
         AssignProp("", false, cmbUsuarioZona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuarioZona.Enabled), 5, 0), true);
         edtEstadoDescripcion_Enabled = 0;
         AssignProp("", false, edtEstadoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoDescripcion_Enabled), 5, 0), true);
         edtCiudadDescripcion_Enabled = 0;
         AssignProp("", false, edtCiudadDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadDescripcion_Enabled), 5, 0), true);
         edtPaisDescripcion_Enabled = 0;
         AssignProp("", false, edtPaisDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisDescripcion_Enabled), 5, 0), true);
         cmbUsuarioGenero.Enabled = 0;
         AssignProp("", false, cmbUsuarioGenero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuarioGenero.Enabled), 5, 0), true);
         edtFacturaPDF_Enabled = 0;
         AssignProp("", false, edtFacturaPDF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFacturaPDF_Enabled), 5, 0), true);
         cmbFacturaEstatus.Enabled = 0;
         AssignProp("", false, cmbFacturaEstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFacturaEstatus.Enabled), 5, 0), true);
         edtMotivoRechazoID_Enabled = 0;
         AssignProp("", false, edtMotivoRechazoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoID_Enabled), 5, 0), true);
         edtMotivoRechazoDescripcion_Enabled = 0;
         AssignProp("", false, edtMotivoRechazoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMotivoRechazoDescripcion_Enabled), 5, 0), true);
         chkMotivoRechazoActivo.Enabled = 0;
         AssignProp("", false, chkMotivoRechazoActivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkMotivoRechazoActivo.Enabled), 5, 0), true);
         edtPromocionID_Enabled = 0;
         AssignProp("", false, edtPromocionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionID_Enabled), 5, 0), true);
         edtMedidaID_Enabled = 0;
         AssignProp("", false, edtMedidaID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidaID_Enabled), 5, 0), true);
         edtMedidaDescripcion_Enabled = 0;
         AssignProp("", false, edtMedidaDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidaDescripcion_Enabled), 5, 0), true);
         edtMedidaRin_Enabled = 0;
         AssignProp("", false, edtMedidaRin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidaRin_Enabled), 5, 0), true);
         edtMedidaCodigo_Enabled = 0;
         AssignProp("", false, edtMedidaCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidaCodigo_Enabled), 5, 0), true);
         edtModeloID_Enabled = 0;
         AssignProp("", false, edtModeloID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtModeloID_Enabled), 5, 0), true);
         edtModeloDescripcion_Enabled = 0;
         AssignProp("", false, edtModeloDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtModeloDescripcion_Enabled), 5, 0), true);
         edtFacturaMedidaCantidad_Enabled = 0;
         AssignProp("", false, edtFacturaMedidaCantidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFacturaMedidaCantidad_Enabled), 5, 0), true);
         edtFacturaMedidaPrecio_Enabled = 0;
         AssignProp("", false, edtFacturaMedidaPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFacturaMedidaPrecio_Enabled), 5, 0), true);
         edtUsuarioNombre_Enabled = 0;
         AssignProp("", false, edtUsuarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Enabled), 5, 0), true);
         edtUsuarioApellido_Enabled = 0;
         AssignProp("", false, edtUsuarioApellido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioApellido_Enabled), 5, 0), true);
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
         edtUsuarioCelular_Enabled = 0;
         AssignProp("", false, edtUsuarioCelular_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioCelular_Enabled), 5, 0), true);
         edtUsuarioTelefonoSucursal_Enabled = 0;
         AssignProp("", false, edtUsuarioTelefonoSucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioTelefonoSucursal_Enabled), 5, 0), true);
         edtPaisID_Enabled = 0;
         AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         edtEstadoID_Enabled = 0;
         AssignProp("", false, edtEstadoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoID_Enabled), 5, 0), true);
         edtCiudadID_Enabled = 0;
         AssignProp("", false, edtCiudadID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCiudadID_Enabled), 5, 0), true);
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
      }

      protected void send_integrity_lvl_hashes0G16( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0G0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("facturamedida.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z77FacturaMedidaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z77FacturaMedidaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z78FacturaMedidaCantidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z78FacturaMedidaCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z79FacturaMedidaPrecio", StringUtil.LTrim( StringUtil.NToC( Z79FacturaMedidaPrecio, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z69FacturaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z26MedidaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26MedidaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PROMOCIONFECHAINICIO", context.localUtil.DToC( A45PromocionFechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "PROMOCIONFECHAFIN", context.localUtil.DToC( A46PromocionFechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "FACTURAPDF_GXI", A40001FacturaPDF_GXI);
         GxWebStd.gx_hidden_field( context, "PROMOCIONARTE_GXI", A40000PromocionArte_GXI);
         GXCCtlgxBlob = "PROMOCIONARTE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A44PromocionArte);
         GXCCtlgxBlob = "FACTURAPDF" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A75FacturaPDF);
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
         return formatLink("facturamedida.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "FacturaMedida" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Factura Medida", "") ;
      }

      protected void InitializeNonKey0G16( )
      {
         A52UsuarioNombreCompleto = "";
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
         A69FacturaID = 0;
         AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
         A42PromocionDescripcion = "";
         AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
         A43PromocionBase = "";
         AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
         A44PromocionArte = "";
         AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
         AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
         AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
         A40000PromocionArte_GXI = "";
         AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
         AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
         A70PromocionVigencia = "";
         AssignAttri("", false, "A70PromocionVigencia", A70PromocionVigencia);
         A71FacturaNo = "";
         AssignAttri("", false, "A71FacturaNo", A71FacturaNo);
         A73FacturaFechaFactura = DateTime.MinValue;
         AssignAttri("", false, "A73FacturaFechaFactura", context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"));
         A72FacturaFechaRegistro = DateTime.MinValue;
         AssignAttri("", false, "A72FacturaFechaRegistro", context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"));
         A29UsuarioID = 0;
         AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
         A63UsuarioZona = "";
         AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
         A2EstadoDescripcion = "";
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         A5CiudadDescripcion = "";
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         A17PaisDescripcion = "";
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
         A53UsuarioGenero = "";
         AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
         A75FacturaPDF = "";
         AssignAttri("", false, "A75FacturaPDF", A75FacturaPDF);
         AssignProp("", false, edtFacturaPDF_Internalname, "Multimedia", (String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)) ? A40001FacturaPDF_GXI : context.convertURL( context.PathToRelativeUrl( A75FacturaPDF))), true);
         A40001FacturaPDF_GXI = "";
         AssignAttri("", false, "A40001FacturaPDF_GXI", A40001FacturaPDF_GXI);
         A80FacturaEstatus = "";
         AssignAttri("", false, "A80FacturaEstatus", A80FacturaEstatus);
         A19MotivoRechazoID = 0;
         AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrimStr( (decimal)(A19MotivoRechazoID), 9, 0));
         A20MotivoRechazoDescripcion = "";
         AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
         A21MotivoRechazoActivo = false;
         AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
         A41PromocionID = 0;
         AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
         A26MedidaID = 0;
         AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
         A28MedidaDescripcion = "";
         AssignAttri("", false, "A28MedidaDescripcion", A28MedidaDescripcion);
         A74MedidaRin = "";
         AssignAttri("", false, "A74MedidaRin", A74MedidaRin);
         A27MedidaCodigo = "";
         AssignAttri("", false, "A27MedidaCodigo", A27MedidaCodigo);
         A22ModeloID = 0;
         AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
         A23ModeloDescripcion = "";
         AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
         A78FacturaMedidaCantidad = 0;
         AssignAttri("", false, "A78FacturaMedidaCantidad", StringUtil.LTrimStr( (decimal)(A78FacturaMedidaCantidad), 4, 0));
         A79FacturaMedidaPrecio = 0;
         AssignAttri("", false, "A79FacturaMedidaPrecio", StringUtil.LTrimStr( A79FacturaMedidaPrecio, 10, 2));
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
         A64UsuarioCelular = 0;
         AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrimStr( (decimal)(A64UsuarioCelular), 10, 0));
         A65UsuarioTelefonoSucursal = 0;
         AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrimStr( (decimal)(A65UsuarioTelefonoSucursal), 10, 0));
         A16PaisID = 0;
         AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
         A1EstadoID = 0;
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
         A4CiudadID = 0;
         n4CiudadID = false;
         AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
         A66UsuarioSucursal = "";
         AssignAttri("", false, "A66UsuarioSucursal", A66UsuarioSucursal);
         A67UsuarioProducto = "";
         n67UsuarioProducto = false;
         AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
         A40UsuarioRol = "";
         AssignAttri("", false, "A40UsuarioRol", A40UsuarioRol);
         A82UsuarioNoCuentaBROXEL = "";
         AssignAttri("", false, "A82UsuarioNoCuentaBROXEL", A82UsuarioNoCuentaBROXEL);
         A83UsuarioReferenciaBROXEL = "";
         AssignAttri("", false, "A83UsuarioReferenciaBROXEL", A83UsuarioReferenciaBROXEL);
         A45PromocionFechaInicio = DateTime.MinValue;
         AssignAttri("", false, "A45PromocionFechaInicio", context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"));
         A46PromocionFechaFin = DateTime.MinValue;
         AssignAttri("", false, "A46PromocionFechaFin", context.localUtil.Format(A46PromocionFechaFin, "99/99/99"));
         Z78FacturaMedidaCantidad = 0;
         Z79FacturaMedidaPrecio = 0;
         Z69FacturaID = 0;
         Z26MedidaID = 0;
      }

      protected void InitAll0G16( )
      {
         A77FacturaMedidaID = 0;
         AssignAttri("", false, "A77FacturaMedidaID", StringUtil.LTrimStr( (decimal)(A77FacturaMedidaID), 9, 0));
         InitializeNonKey0G16( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025102815462511", true, true);
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
         context.AddJavascriptSource("facturamedida.js", "?2025102815462511", false, true);
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
         edtFacturaMedidaID_Internalname = "FACTURAMEDIDAID";
         edtFacturaID_Internalname = "FACTURAID";
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION";
         edtPromocionBase_Internalname = "PROMOCIONBASE";
         imgPromocionArte_Internalname = "PROMOCIONARTE";
         edtPromocionVigencia_Internalname = "PROMOCIONVIGENCIA";
         edtFacturaNo_Internalname = "FACTURANO";
         edtFacturaFechaFactura_Internalname = "FACTURAFECHAFACTURA";
         edtFacturaFechaRegistro_Internalname = "FACTURAFECHAREGISTRO";
         edtUsuarioID_Internalname = "USUARIOID";
         edtUsuarioNombreCompleto_Internalname = "USUARIONOMBRECOMPLETO";
         cmbUsuarioZona_Internalname = "USUARIOZONA";
         edtEstadoDescripcion_Internalname = "ESTADODESCRIPCION";
         edtCiudadDescripcion_Internalname = "CIUDADDESCRIPCION";
         edtPaisDescripcion_Internalname = "PAISDESCRIPCION";
         cmbUsuarioGenero_Internalname = "USUARIOGENERO";
         edtFacturaPDF_Internalname = "FACTURAPDF";
         cmbFacturaEstatus_Internalname = "FACTURAESTATUS";
         edtMotivoRechazoID_Internalname = "MOTIVORECHAZOID";
         edtMotivoRechazoDescripcion_Internalname = "MOTIVORECHAZODESCRIPCION";
         chkMotivoRechazoActivo_Internalname = "MOTIVORECHAZOACTIVO";
         edtPromocionID_Internalname = "PROMOCIONID";
         edtMedidaID_Internalname = "MEDIDAID";
         edtMedidaDescripcion_Internalname = "MEDIDADESCRIPCION";
         edtMedidaRin_Internalname = "MEDIDARIN";
         edtMedidaCodigo_Internalname = "MEDIDACODIGO";
         edtModeloID_Internalname = "MODELOID";
         edtModeloDescripcion_Internalname = "MODELODESCRIPCION";
         edtFacturaMedidaCantidad_Internalname = "FACTURAMEDIDACANTIDAD";
         edtFacturaMedidaPrecio_Internalname = "FACTURAMEDIDAPRECIO";
         edtUsuarioNombre_Internalname = "USUARIONOMBRE";
         edtUsuarioApellido_Internalname = "USUARIOAPELLIDO";
         edtUsuarioCorreo_Internalname = "USUARIOCORREO";
         edtUsuarioPass_Internalname = "USUARIOPASS";
         edtUsuarioKey_Internalname = "USUARIOKEY";
         edtPuestoID_Internalname = "PUESTOID";
         edtPuestoDescripcion_Internalname = "PUESTODESCRIPCION";
         cmbUsuarioDirectoAsociado_Internalname = "USUARIODIRECTOASOCIADO";
         edtUsuarioRazonSocialAsociado_Internalname = "USUARIORAZONSOCIALASOCIADO";
         edtUsuarioNombreComercial_Internalname = "USUARIONOMBRECOMERCIAL";
         edtUsuarioFechaNacimiento_Internalname = "USUARIOFECHANACIMIENTO";
         edtUsuarioCalleNum_Internalname = "USUARIOCALLENUM";
         edtUsuarioColonia_Internalname = "USUARIOCOLONIA";
         edtUsuarioDelegacion_Internalname = "USUARIODELEGACION";
         edtUsuarioCP_Internalname = "USUARIOCP";
         edtUsuarioCelular_Internalname = "USUARIOCELULAR";
         edtUsuarioTelefonoSucursal_Internalname = "USUARIOTELEFONOSUCURSAL";
         edtPaisID_Internalname = "PAISID";
         edtEstadoID_Internalname = "ESTADOID";
         edtCiudadID_Internalname = "CIUDADID";
         edtUsuarioSucursal_Internalname = "USUARIOSUCURSAL";
         cmbUsuarioProducto_Internalname = "USUARIOPRODUCTO";
         cmbUsuarioRol_Internalname = "USUARIOROL";
         edtUsuarioNoCuentaBROXEL_Internalname = "USUARIONOCUENTABROXEL";
         edtUsuarioReferenciaBROXEL_Internalname = "USUARIOREFERENCIABROXEL";
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
         Form.Caption = context.GetMessage( "Factura Medida", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
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
         edtCiudadID_Jsonclick = "";
         edtCiudadID_Enabled = 0;
         edtEstadoID_Jsonclick = "";
         edtEstadoID_Enabled = 0;
         edtPaisID_Jsonclick = "";
         edtPaisID_Enabled = 0;
         edtUsuarioTelefonoSucursal_Jsonclick = "";
         edtUsuarioTelefonoSucursal_Enabled = 0;
         edtUsuarioCelular_Jsonclick = "";
         edtUsuarioCelular_Enabled = 0;
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
         edtUsuarioApellido_Jsonclick = "";
         edtUsuarioApellido_Enabled = 0;
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioNombre_Enabled = 0;
         edtFacturaMedidaPrecio_Jsonclick = "";
         edtFacturaMedidaPrecio_Enabled = 1;
         edtFacturaMedidaCantidad_Jsonclick = "";
         edtFacturaMedidaCantidad_Enabled = 1;
         edtModeloDescripcion_Jsonclick = "";
         edtModeloDescripcion_Enabled = 0;
         edtModeloID_Jsonclick = "";
         edtModeloID_Enabled = 0;
         edtMedidaCodigo_Jsonclick = "";
         edtMedidaCodigo_Enabled = 0;
         edtMedidaRin_Jsonclick = "";
         edtMedidaRin_Enabled = 0;
         edtMedidaDescripcion_Jsonclick = "";
         edtMedidaDescripcion_Enabled = 0;
         edtMedidaID_Jsonclick = "";
         edtMedidaID_Enabled = 1;
         edtPromocionID_Jsonclick = "";
         edtPromocionID_Enabled = 0;
         chkMotivoRechazoActivo.Enabled = 0;
         edtMotivoRechazoDescripcion_Jsonclick = "";
         edtMotivoRechazoDescripcion_Enabled = 0;
         edtMotivoRechazoID_Jsonclick = "";
         edtMotivoRechazoID_Enabled = 0;
         cmbFacturaEstatus_Jsonclick = "";
         cmbFacturaEstatus.Enabled = 0;
         edtFacturaPDF_Filename = "";
         edtFacturaPDF_Enabled = 0;
         cmbUsuarioGenero_Jsonclick = "";
         cmbUsuarioGenero.Enabled = 0;
         edtPaisDescripcion_Jsonclick = "";
         edtPaisDescripcion_Enabled = 0;
         edtCiudadDescripcion_Jsonclick = "";
         edtCiudadDescripcion_Enabled = 0;
         edtEstadoDescripcion_Jsonclick = "";
         edtEstadoDescripcion_Enabled = 0;
         cmbUsuarioZona_Jsonclick = "";
         cmbUsuarioZona.Enabled = 0;
         edtUsuarioNombreCompleto_Jsonclick = "";
         edtUsuarioNombreCompleto_Enabled = 0;
         edtUsuarioID_Jsonclick = "";
         edtUsuarioID_Enabled = 0;
         edtFacturaFechaRegistro_Jsonclick = "";
         edtFacturaFechaRegistro_Enabled = 0;
         edtFacturaFechaFactura_Jsonclick = "";
         edtFacturaFechaFactura_Enabled = 0;
         edtFacturaNo_Jsonclick = "";
         edtFacturaNo_Enabled = 0;
         edtPromocionVigencia_Jsonclick = "";
         edtPromocionVigencia_Enabled = 0;
         imgPromocionArte_Enabled = 0;
         edtPromocionBase_Enabled = 0;
         edtPromocionDescripcion_Jsonclick = "";
         edtPromocionDescripcion_Enabled = 0;
         edtFacturaID_Jsonclick = "";
         edtFacturaID_Enabled = 1;
         edtFacturaMedidaID_Jsonclick = "";
         edtFacturaMedidaID_Enabled = 1;
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
         cmbFacturaEstatus.Name = "FACTURAESTATUS";
         cmbFacturaEstatus.WebTags = "";
         cmbFacturaEstatus.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbFacturaEstatus.addItem("En Proceso", context.GetMessage( "En Proceso", ""), 0);
         cmbFacturaEstatus.addItem("Aprobada", context.GetMessage( "Aprobada", ""), 0);
         cmbFacturaEstatus.addItem("Rechazada", context.GetMessage( "Rechazada", ""), 0);
         cmbFacturaEstatus.addItem("Cancelada", context.GetMessage( "Cancelada", ""), 0);
         if ( cmbFacturaEstatus.ItemCount > 0 )
         {
            A80FacturaEstatus = cmbFacturaEstatus.getValidValue(A80FacturaEstatus);
            AssignAttri("", false, "A80FacturaEstatus", A80FacturaEstatus);
         }
         chkMotivoRechazoActivo.Name = "MOTIVORECHAZOACTIVO";
         chkMotivoRechazoActivo.WebTags = "";
         chkMotivoRechazoActivo.Caption = context.GetMessage( "Motivo Rechazo Activo", "");
         AssignProp("", false, chkMotivoRechazoActivo_Internalname, "TitleCaption", chkMotivoRechazoActivo.Caption, true);
         chkMotivoRechazoActivo.CheckedValue = "false";
         A21MotivoRechazoActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A21MotivoRechazoActivo));
         AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
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
         GX_FocusControl = edtFacturaID_Internalname;
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

      public void Valid_Facturamedidaid( )
      {
         A40UsuarioRol = cmbUsuarioRol.CurrentValue;
         cmbUsuarioRol.CurrentValue = A40UsuarioRol;
         n67UsuarioProducto = false;
         A67UsuarioProducto = cmbUsuarioProducto.CurrentValue;
         n67UsuarioProducto = false;
         cmbUsuarioProducto.CurrentValue = A67UsuarioProducto;
         n54UsuarioDirectoAsociado = false;
         A54UsuarioDirectoAsociado = cmbUsuarioDirectoAsociado.CurrentValue;
         n54UsuarioDirectoAsociado = false;
         cmbUsuarioDirectoAsociado.CurrentValue = A54UsuarioDirectoAsociado;
         A53UsuarioGenero = cmbUsuarioGenero.CurrentValue;
         cmbUsuarioGenero.CurrentValue = A53UsuarioGenero;
         A63UsuarioZona = cmbUsuarioZona.CurrentValue;
         cmbUsuarioZona.CurrentValue = A63UsuarioZona;
         A80FacturaEstatus = cmbFacturaEstatus.CurrentValue;
         cmbFacturaEstatus.CurrentValue = A80FacturaEstatus;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbFacturaEstatus.ItemCount > 0 )
         {
            A80FacturaEstatus = cmbFacturaEstatus.getValidValue(A80FacturaEstatus);
            cmbFacturaEstatus.CurrentValue = A80FacturaEstatus;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbFacturaEstatus.CurrentValue = StringUtil.RTrim( A80FacturaEstatus);
         }
         A21MotivoRechazoActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A21MotivoRechazoActivo));
         if ( cmbUsuarioZona.ItemCount > 0 )
         {
            A63UsuarioZona = cmbUsuarioZona.getValidValue(A63UsuarioZona);
            cmbUsuarioZona.CurrentValue = A63UsuarioZona;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioZona.CurrentValue = StringUtil.RTrim( A63UsuarioZona);
         }
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
         AssignAttri("", false, "A69FacturaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, ".", "")));
         AssignAttri("", false, "A26MedidaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26MedidaID), 9, 0, ".", "")));
         AssignAttri("", false, "A78FacturaMedidaCantidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(A78FacturaMedidaCantidad), 4, 0, ".", "")));
         AssignAttri("", false, "A79FacturaMedidaPrecio", StringUtil.LTrim( StringUtil.NToC( A79FacturaMedidaPrecio, 10, 2, ".", "")));
         AssignAttri("", false, "A71FacturaNo", StringUtil.RTrim( A71FacturaNo));
         AssignAttri("", false, "A73FacturaFechaFactura", context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"));
         AssignAttri("", false, "A72FacturaFechaRegistro", context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"));
         AssignAttri("", false, "A75FacturaPDF", context.PathToRelativeUrl( A75FacturaPDF));
         AssignAttri("", false, "A40001FacturaPDF_GXI", A40001FacturaPDF_GXI);
         AssignAttri("", false, "A80FacturaEstatus", StringUtil.RTrim( A80FacturaEstatus));
         cmbFacturaEstatus.CurrentValue = StringUtil.RTrim( A80FacturaEstatus);
         AssignProp("", false, cmbFacturaEstatus_Internalname, "Values", cmbFacturaEstatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A41PromocionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, ".", "")));
         AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MotivoRechazoID), 9, 0, ".", "")));
         AssignAttri("", false, "A29UsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, ".", "")));
         AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
         AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
         AssignAttri("", false, "A44PromocionArte", context.PathToRelativeUrl( A44PromocionArte));
         GXCCtlgxBlob = "PROMOCIONARTE" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A44PromocionArte));
         AssignAttri("", false, "A40000PromocionArte_GXI", A40000PromocionArte_GXI);
         AssignAttri("", false, "A45PromocionFechaInicio", context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"));
         AssignAttri("", false, "A46PromocionFechaFin", context.localUtil.Format(A46PromocionFechaFin, "99/99/99"));
         AssignAttri("", false, "A70PromocionVigencia", A70PromocionVigencia);
         AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
         AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
         AssignAttri("", false, "A63UsuarioZona", StringUtil.RTrim( A63UsuarioZona));
         cmbUsuarioZona.CurrentValue = StringUtil.RTrim( A63UsuarioZona);
         AssignProp("", false, cmbUsuarioZona_Internalname, "Values", cmbUsuarioZona.ToJavascriptSource(), true);
         AssignAttri("", false, "A53UsuarioGenero", StringUtil.RTrim( A53UsuarioGenero));
         cmbUsuarioGenero.CurrentValue = StringUtil.RTrim( A53UsuarioGenero);
         AssignProp("", false, cmbUsuarioGenero_Internalname, "Values", cmbUsuarioGenero.ToJavascriptSource(), true);
         AssignAttri("", false, "A30UsuarioNombre", StringUtil.RTrim( A30UsuarioNombre));
         AssignAttri("", false, "A51UsuarioApellido", StringUtil.RTrim( A51UsuarioApellido));
         AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
         AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
         AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
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
         AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrim( StringUtil.NToC( (decimal)(A64UsuarioCelular), 10, 0, ".", "")));
         AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrim( StringUtil.NToC( (decimal)(A65UsuarioTelefonoSucursal), 10, 0, ".", "")));
         AssignAttri("", false, "A66UsuarioSucursal", StringUtil.RTrim( A66UsuarioSucursal));
         AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
         cmbUsuarioProducto.CurrentValue = StringUtil.RTrim( A67UsuarioProducto);
         AssignProp("", false, cmbUsuarioProducto_Internalname, "Values", cmbUsuarioProducto.ToJavascriptSource(), true);
         AssignAttri("", false, "A40UsuarioRol", StringUtil.RTrim( A40UsuarioRol));
         cmbUsuarioRol.CurrentValue = StringUtil.RTrim( A40UsuarioRol);
         AssignProp("", false, cmbUsuarioRol_Internalname, "Values", cmbUsuarioRol.ToJavascriptSource(), true);
         AssignAttri("", false, "A82UsuarioNoCuentaBROXEL", StringUtil.RTrim( A82UsuarioNoCuentaBROXEL));
         AssignAttri("", false, "A83UsuarioReferenciaBROXEL", StringUtil.RTrim( A83UsuarioReferenciaBROXEL));
         AssignAttri("", false, "A13PuestoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13PuestoID), 9, 0, ".", "")));
         AssignAttri("", false, "A4CiudadID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, ".", "")));
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
         AssignAttri("", false, "A14PuestoDescripcion", A14PuestoDescripcion);
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, ".", "")));
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         AssignAttri("", false, "A16PaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, ".", "")));
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
         AssignAttri("", false, "A28MedidaDescripcion", A28MedidaDescripcion);
         AssignAttri("", false, "A74MedidaRin", StringUtil.RTrim( A74MedidaRin));
         AssignAttri("", false, "A27MedidaCodigo", StringUtil.RTrim( A27MedidaCodigo));
         AssignAttri("", false, "A22ModeloID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22ModeloID), 9, 0, ".", "")));
         AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z77FacturaMedidaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z77FacturaMedidaID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z69FacturaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z69FacturaID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z26MedidaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26MedidaID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z78FacturaMedidaCantidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z78FacturaMedidaCantidad), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z79FacturaMedidaPrecio", StringUtil.LTrim( StringUtil.NToC( Z79FacturaMedidaPrecio, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z71FacturaNo", StringUtil.RTrim( Z71FacturaNo));
         GxWebStd.gx_hidden_field( context, "Z73FacturaFechaFactura", context.localUtil.Format(Z73FacturaFechaFactura, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z72FacturaFechaRegistro", context.localUtil.Format(Z72FacturaFechaRegistro, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z75FacturaPDF", context.PathToRelativeUrl( Z75FacturaPDF));
         GxWebStd.gx_hidden_field( context, "Z40001FacturaPDF_GXI", Z40001FacturaPDF_GXI);
         GxWebStd.gx_hidden_field( context, "Z80FacturaEstatus", StringUtil.RTrim( Z80FacturaEstatus));
         GxWebStd.gx_hidden_field( context, "Z41PromocionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41PromocionID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z19MotivoRechazoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19MotivoRechazoID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z29UsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29UsuarioID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z42PromocionDescripcion", Z42PromocionDescripcion);
         GxWebStd.gx_hidden_field( context, "Z43PromocionBase", Z43PromocionBase);
         GxWebStd.gx_hidden_field( context, "Z44PromocionArte", context.PathToRelativeUrl( Z44PromocionArte));
         GxWebStd.gx_hidden_field( context, "Z40000PromocionArte_GXI", Z40000PromocionArte_GXI);
         GxWebStd.gx_hidden_field( context, "Z45PromocionFechaInicio", context.localUtil.Format(Z45PromocionFechaInicio, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z46PromocionFechaFin", context.localUtil.Format(Z46PromocionFechaFin, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z70PromocionVigencia", Z70PromocionVigencia);
         GxWebStd.gx_hidden_field( context, "Z20MotivoRechazoDescripcion", Z20MotivoRechazoDescripcion);
         GxWebStd.gx_hidden_field( context, "Z21MotivoRechazoActivo", StringUtil.BoolToStr( Z21MotivoRechazoActivo));
         GxWebStd.gx_hidden_field( context, "Z63UsuarioZona", StringUtil.RTrim( Z63UsuarioZona));
         GxWebStd.gx_hidden_field( context, "Z53UsuarioGenero", StringUtil.RTrim( Z53UsuarioGenero));
         GxWebStd.gx_hidden_field( context, "Z30UsuarioNombre", StringUtil.RTrim( Z30UsuarioNombre));
         GxWebStd.gx_hidden_field( context, "Z51UsuarioApellido", StringUtil.RTrim( Z51UsuarioApellido));
         GxWebStd.gx_hidden_field( context, "Z31UsuarioCorreo", Z31UsuarioCorreo);
         GxWebStd.gx_hidden_field( context, "Z32UsuarioPass", Z32UsuarioPass);
         GxWebStd.gx_hidden_field( context, "Z33UsuarioKey", Z33UsuarioKey);
         GxWebStd.gx_hidden_field( context, "Z54UsuarioDirectoAsociado", StringUtil.RTrim( Z54UsuarioDirectoAsociado));
         GxWebStd.gx_hidden_field( context, "Z55UsuarioRazonSocialAsociado", Z55UsuarioRazonSocialAsociado);
         GxWebStd.gx_hidden_field( context, "Z56UsuarioNombreComercial", Z56UsuarioNombreComercial);
         GxWebStd.gx_hidden_field( context, "Z57UsuarioFechaNacimiento", context.localUtil.Format(Z57UsuarioFechaNacimiento, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z59UsuarioCalleNum", StringUtil.RTrim( Z59UsuarioCalleNum));
         GxWebStd.gx_hidden_field( context, "Z60UsuarioColonia", StringUtil.RTrim( Z60UsuarioColonia));
         GxWebStd.gx_hidden_field( context, "Z61UsuarioDelegacion", StringUtil.RTrim( Z61UsuarioDelegacion));
         GxWebStd.gx_hidden_field( context, "Z62UsuarioCP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z62UsuarioCP), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z64UsuarioCelular", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64UsuarioCelular), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z65UsuarioTelefonoSucursal", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z65UsuarioTelefonoSucursal), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z66UsuarioSucursal", StringUtil.RTrim( Z66UsuarioSucursal));
         GxWebStd.gx_hidden_field( context, "Z67UsuarioProducto", Z67UsuarioProducto);
         GxWebStd.gx_hidden_field( context, "Z40UsuarioRol", StringUtil.RTrim( Z40UsuarioRol));
         GxWebStd.gx_hidden_field( context, "Z82UsuarioNoCuentaBROXEL", StringUtil.RTrim( Z82UsuarioNoCuentaBROXEL));
         GxWebStd.gx_hidden_field( context, "Z83UsuarioReferenciaBROXEL", StringUtil.RTrim( Z83UsuarioReferenciaBROXEL));
         GxWebStd.gx_hidden_field( context, "Z13PuestoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13PuestoID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4CiudadID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4CiudadID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z52UsuarioNombreCompleto", Z52UsuarioNombreCompleto);
         GxWebStd.gx_hidden_field( context, "Z14PuestoDescripcion", Z14PuestoDescripcion);
         GxWebStd.gx_hidden_field( context, "Z5CiudadDescripcion", Z5CiudadDescripcion);
         GxWebStd.gx_hidden_field( context, "Z1EstadoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EstadoID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2EstadoDescripcion", Z2EstadoDescripcion);
         GxWebStd.gx_hidden_field( context, "Z16PaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16PaisID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z17PaisDescripcion", Z17PaisDescripcion);
         GxWebStd.gx_hidden_field( context, "Z28MedidaDescripcion", Z28MedidaDescripcion);
         GxWebStd.gx_hidden_field( context, "Z74MedidaRin", StringUtil.RTrim( Z74MedidaRin));
         GxWebStd.gx_hidden_field( context, "Z27MedidaCodigo", StringUtil.RTrim( Z27MedidaCodigo));
         GxWebStd.gx_hidden_field( context, "Z22ModeloID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22ModeloID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23ModeloDescripcion", Z23ModeloDescripcion);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Facturaid( )
      {
         n13PuestoID = false;
         n4CiudadID = false;
         A80FacturaEstatus = cmbFacturaEstatus.CurrentValue;
         cmbFacturaEstatus.CurrentValue = A80FacturaEstatus;
         A63UsuarioZona = cmbUsuarioZona.CurrentValue;
         cmbUsuarioZona.CurrentValue = A63UsuarioZona;
         A53UsuarioGenero = cmbUsuarioGenero.CurrentValue;
         cmbUsuarioGenero.CurrentValue = A53UsuarioGenero;
         n54UsuarioDirectoAsociado = false;
         A54UsuarioDirectoAsociado = cmbUsuarioDirectoAsociado.CurrentValue;
         n54UsuarioDirectoAsociado = false;
         cmbUsuarioDirectoAsociado.CurrentValue = A54UsuarioDirectoAsociado;
         n57UsuarioFechaNacimiento = false;
         n67UsuarioProducto = false;
         A67UsuarioProducto = cmbUsuarioProducto.CurrentValue;
         n67UsuarioProducto = false;
         cmbUsuarioProducto.CurrentValue = A67UsuarioProducto;
         A40UsuarioRol = cmbUsuarioRol.CurrentValue;
         cmbUsuarioRol.CurrentValue = A40UsuarioRol;
         /* Using cursor T000G32 */
         pr_default.execute(30, new Object[] {A69FacturaID});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Factura", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "FACTURAID");
            AnyError = 1;
            GX_FocusControl = edtFacturaID_Internalname;
         }
         A71FacturaNo = T000G32_A71FacturaNo[0];
         A73FacturaFechaFactura = T000G32_A73FacturaFechaFactura[0];
         A72FacturaFechaRegistro = T000G32_A72FacturaFechaRegistro[0];
         A40001FacturaPDF_GXI = T000G32_A40001FacturaPDF_GXI[0];
         A80FacturaEstatus = T000G32_A80FacturaEstatus[0];
         cmbFacturaEstatus.CurrentValue = A80FacturaEstatus;
         A41PromocionID = T000G32_A41PromocionID[0];
         A19MotivoRechazoID = T000G32_A19MotivoRechazoID[0];
         A29UsuarioID = T000G32_A29UsuarioID[0];
         A75FacturaPDF = T000G32_A75FacturaPDF[0];
         pr_default.close(30);
         /* Using cursor T000G33 */
         pr_default.execute(31, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
         }
         A42PromocionDescripcion = T000G33_A42PromocionDescripcion[0];
         A43PromocionBase = T000G33_A43PromocionBase[0];
         A40000PromocionArte_GXI = T000G33_A40000PromocionArte_GXI[0];
         A45PromocionFechaInicio = T000G33_A45PromocionFechaInicio[0];
         A46PromocionFechaFin = T000G33_A46PromocionFechaFin[0];
         A44PromocionArte = T000G33_A44PromocionArte[0];
         pr_default.close(31);
         A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         /* Using cursor T000G34 */
         pr_default.execute(32, new Object[] {A19MotivoRechazoID});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Motivo Rechazo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MOTIVORECHAZOID");
            AnyError = 1;
         }
         A20MotivoRechazoDescripcion = T000G34_A20MotivoRechazoDescripcion[0];
         A21MotivoRechazoActivo = T000G34_A21MotivoRechazoActivo[0];
         pr_default.close(32);
         /* Using cursor T000G35 */
         pr_default.execute(33, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(33) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
         }
         A63UsuarioZona = T000G35_A63UsuarioZona[0];
         cmbUsuarioZona.CurrentValue = A63UsuarioZona;
         A53UsuarioGenero = T000G35_A53UsuarioGenero[0];
         cmbUsuarioGenero.CurrentValue = A53UsuarioGenero;
         A30UsuarioNombre = T000G35_A30UsuarioNombre[0];
         A51UsuarioApellido = T000G35_A51UsuarioApellido[0];
         A31UsuarioCorreo = T000G35_A31UsuarioCorreo[0];
         A32UsuarioPass = T000G35_A32UsuarioPass[0];
         A33UsuarioKey = T000G35_A33UsuarioKey[0];
         A54UsuarioDirectoAsociado = T000G35_A54UsuarioDirectoAsociado[0];
         n54UsuarioDirectoAsociado = T000G35_n54UsuarioDirectoAsociado[0];
         cmbUsuarioDirectoAsociado.CurrentValue = A54UsuarioDirectoAsociado;
         A55UsuarioRazonSocialAsociado = T000G35_A55UsuarioRazonSocialAsociado[0];
         A56UsuarioNombreComercial = T000G35_A56UsuarioNombreComercial[0];
         A57UsuarioFechaNacimiento = T000G35_A57UsuarioFechaNacimiento[0];
         n57UsuarioFechaNacimiento = T000G35_n57UsuarioFechaNacimiento[0];
         A59UsuarioCalleNum = T000G35_A59UsuarioCalleNum[0];
         A60UsuarioColonia = T000G35_A60UsuarioColonia[0];
         A61UsuarioDelegacion = T000G35_A61UsuarioDelegacion[0];
         A62UsuarioCP = T000G35_A62UsuarioCP[0];
         A64UsuarioCelular = T000G35_A64UsuarioCelular[0];
         A65UsuarioTelefonoSucursal = T000G35_A65UsuarioTelefonoSucursal[0];
         A66UsuarioSucursal = T000G35_A66UsuarioSucursal[0];
         A67UsuarioProducto = T000G35_A67UsuarioProducto[0];
         n67UsuarioProducto = T000G35_n67UsuarioProducto[0];
         cmbUsuarioProducto.CurrentValue = A67UsuarioProducto;
         A40UsuarioRol = T000G35_A40UsuarioRol[0];
         cmbUsuarioRol.CurrentValue = A40UsuarioRol;
         A82UsuarioNoCuentaBROXEL = T000G35_A82UsuarioNoCuentaBROXEL[0];
         A83UsuarioReferenciaBROXEL = T000G35_A83UsuarioReferenciaBROXEL[0];
         A13PuestoID = T000G35_A13PuestoID[0];
         n13PuestoID = T000G35_n13PuestoID[0];
         A4CiudadID = T000G35_A4CiudadID[0];
         n4CiudadID = T000G35_n4CiudadID[0];
         pr_default.close(33);
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
         /* Using cursor T000G36 */
         pr_default.execute(34, new Object[] {n13PuestoID, A13PuestoID});
         if ( (pr_default.getStatus(34) == 101) )
         {
            if ( ! ( (0==A13PuestoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Puesto", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PUESTOID");
               AnyError = 1;
            }
         }
         A14PuestoDescripcion = T000G36_A14PuestoDescripcion[0];
         pr_default.close(34);
         /* Using cursor T000G37 */
         pr_default.execute(35, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(35) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
            }
         }
         A5CiudadDescripcion = T000G37_A5CiudadDescripcion[0];
         A1EstadoID = T000G37_A1EstadoID[0];
         pr_default.close(35);
         /* Using cursor T000G38 */
         pr_default.execute(36, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(36) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A2EstadoDescripcion = T000G38_A2EstadoDescripcion[0];
         A16PaisID = T000G38_A16PaisID[0];
         pr_default.close(36);
         /* Using cursor T000G39 */
         pr_default.execute(37, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(37) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = T000G39_A17PaisDescripcion[0];
         pr_default.close(37);
         dynload_actions( ) ;
         if ( cmbFacturaEstatus.ItemCount > 0 )
         {
            A80FacturaEstatus = cmbFacturaEstatus.getValidValue(A80FacturaEstatus);
            cmbFacturaEstatus.CurrentValue = A80FacturaEstatus;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbFacturaEstatus.CurrentValue = StringUtil.RTrim( A80FacturaEstatus);
         }
         A21MotivoRechazoActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A21MotivoRechazoActivo));
         if ( cmbUsuarioZona.ItemCount > 0 )
         {
            A63UsuarioZona = cmbUsuarioZona.getValidValue(A63UsuarioZona);
            cmbUsuarioZona.CurrentValue = A63UsuarioZona;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioZona.CurrentValue = StringUtil.RTrim( A63UsuarioZona);
         }
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
         AssignAttri("", false, "A71FacturaNo", StringUtil.RTrim( A71FacturaNo));
         AssignAttri("", false, "A73FacturaFechaFactura", context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"));
         AssignAttri("", false, "A72FacturaFechaRegistro", context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"));
         AssignAttri("", false, "A75FacturaPDF", context.PathToRelativeUrl( A75FacturaPDF));
         AssignAttri("", false, "A40001FacturaPDF_GXI", A40001FacturaPDF_GXI);
         AssignAttri("", false, "A80FacturaEstatus", StringUtil.RTrim( A80FacturaEstatus));
         cmbFacturaEstatus.CurrentValue = StringUtil.RTrim( A80FacturaEstatus);
         AssignProp("", false, cmbFacturaEstatus_Internalname, "Values", cmbFacturaEstatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A41PromocionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, ".", "")));
         AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MotivoRechazoID), 9, 0, ".", "")));
         AssignAttri("", false, "A29UsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, ".", "")));
         AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
         AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
         AssignAttri("", false, "A44PromocionArte", context.PathToRelativeUrl( A44PromocionArte));
         GXCCtlgxBlob = "PROMOCIONARTE" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A44PromocionArte));
         AssignAttri("", false, "A40000PromocionArte_GXI", A40000PromocionArte_GXI);
         AssignAttri("", false, "A45PromocionFechaInicio", context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"));
         AssignAttri("", false, "A46PromocionFechaFin", context.localUtil.Format(A46PromocionFechaFin, "99/99/99"));
         AssignAttri("", false, "A70PromocionVigencia", A70PromocionVigencia);
         AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
         AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
         AssignAttri("", false, "A63UsuarioZona", StringUtil.RTrim( A63UsuarioZona));
         cmbUsuarioZona.CurrentValue = StringUtil.RTrim( A63UsuarioZona);
         AssignProp("", false, cmbUsuarioZona_Internalname, "Values", cmbUsuarioZona.ToJavascriptSource(), true);
         AssignAttri("", false, "A53UsuarioGenero", StringUtil.RTrim( A53UsuarioGenero));
         cmbUsuarioGenero.CurrentValue = StringUtil.RTrim( A53UsuarioGenero);
         AssignProp("", false, cmbUsuarioGenero_Internalname, "Values", cmbUsuarioGenero.ToJavascriptSource(), true);
         AssignAttri("", false, "A30UsuarioNombre", StringUtil.RTrim( A30UsuarioNombre));
         AssignAttri("", false, "A51UsuarioApellido", StringUtil.RTrim( A51UsuarioApellido));
         AssignAttri("", false, "A31UsuarioCorreo", A31UsuarioCorreo);
         AssignAttri("", false, "A32UsuarioPass", A32UsuarioPass);
         AssignAttri("", false, "A33UsuarioKey", A33UsuarioKey);
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
         AssignAttri("", false, "A64UsuarioCelular", StringUtil.LTrim( StringUtil.NToC( (decimal)(A64UsuarioCelular), 10, 0, ".", "")));
         AssignAttri("", false, "A65UsuarioTelefonoSucursal", StringUtil.LTrim( StringUtil.NToC( (decimal)(A65UsuarioTelefonoSucursal), 10, 0, ".", "")));
         AssignAttri("", false, "A66UsuarioSucursal", StringUtil.RTrim( A66UsuarioSucursal));
         AssignAttri("", false, "A67UsuarioProducto", A67UsuarioProducto);
         cmbUsuarioProducto.CurrentValue = StringUtil.RTrim( A67UsuarioProducto);
         AssignProp("", false, cmbUsuarioProducto_Internalname, "Values", cmbUsuarioProducto.ToJavascriptSource(), true);
         AssignAttri("", false, "A40UsuarioRol", StringUtil.RTrim( A40UsuarioRol));
         cmbUsuarioRol.CurrentValue = StringUtil.RTrim( A40UsuarioRol);
         AssignProp("", false, cmbUsuarioRol_Internalname, "Values", cmbUsuarioRol.ToJavascriptSource(), true);
         AssignAttri("", false, "A82UsuarioNoCuentaBROXEL", StringUtil.RTrim( A82UsuarioNoCuentaBROXEL));
         AssignAttri("", false, "A83UsuarioReferenciaBROXEL", StringUtil.RTrim( A83UsuarioReferenciaBROXEL));
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

      public void Valid_Medidaid( )
      {
         /* Using cursor T000G40 */
         pr_default.execute(38, new Object[] {A26MedidaID});
         if ( (pr_default.getStatus(38) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Medida", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDIDAID");
            AnyError = 1;
            GX_FocusControl = edtMedidaID_Internalname;
         }
         A28MedidaDescripcion = T000G40_A28MedidaDescripcion[0];
         A74MedidaRin = T000G40_A74MedidaRin[0];
         A27MedidaCodigo = T000G40_A27MedidaCodigo[0];
         A22ModeloID = T000G40_A22ModeloID[0];
         pr_default.close(38);
         /* Using cursor T000G41 */
         pr_default.execute(39, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(39) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Modelo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MODELOID");
            AnyError = 1;
         }
         A23ModeloDescripcion = T000G41_A23ModeloDescripcion[0];
         pr_default.close(39);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A28MedidaDescripcion", A28MedidaDescripcion);
         AssignAttri("", false, "A74MedidaRin", StringUtil.RTrim( A74MedidaRin));
         AssignAttri("", false, "A27MedidaCodigo", StringUtil.RTrim( A27MedidaCodigo));
         AssignAttri("", false, "A22ModeloID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22ModeloID), 9, 0, ".", "")));
         AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]}""");
         setEventMetadata("VALID_FACTURAMEDIDAID","""{"handler":"Valid_Facturamedidaid","iparms":[{"av":"cmbUsuarioRol"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"cmbUsuarioProducto"},{"av":"A67UsuarioProducto","fld":"USUARIOPRODUCTO"},{"av":"cmbUsuarioDirectoAsociado"},{"av":"A54UsuarioDirectoAsociado","fld":"USUARIODIRECTOASOCIADO"},{"av":"cmbUsuarioGenero"},{"av":"A53UsuarioGenero","fld":"USUARIOGENERO"},{"av":"cmbUsuarioZona"},{"av":"A63UsuarioZona","fld":"USUARIOZONA"},{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS"},{"av":"A77FacturaMedidaID","fld":"FACTURAMEDIDAID","pic":"ZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]""");
         setEventMetadata("VALID_FACTURAMEDIDAID",""","oparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"},{"av":"A26MedidaID","fld":"MEDIDAID","pic":"ZZZZZZZZ9"},{"av":"A78FacturaMedidaCantidad","fld":"FACTURAMEDIDACANTIDAD","pic":"ZZZ9"},{"av":"A79FacturaMedidaPrecio","fld":"FACTURAMEDIDAPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"A71FacturaNo","fld":"FACTURANO"},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA"},{"av":"A72FacturaFechaRegistro","fld":"FACTURAFECHAREGISTRO"},{"av":"A75FacturaPDF","fld":"FACTURAPDF"},{"av":"A40001FacturaPDF_GXI","fld":"FACTURAPDF_GXI"},{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS"},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A19MotivoRechazoID","fld":"MOTIVORECHAZOID","pic":"ZZZZZZZZ9"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9"},{"av":"A42PromocionDescripcion","fld":"PROMOCIONDESCRIPCION"},{"av":"A43PromocionBase","fld":"PROMOCIONBASE"},{"av":"A44PromocionArte","fld":"PROMOCIONARTE"},{"av":"A40000PromocionArte_GXI","fld":"PROMOCIONARTE_GXI"},{"av":"A45PromocionFechaInicio","fld":"PROMOCIONFECHAINICIO"},{"av":"A46PromocionFechaFin","fld":"PROMOCIONFECHAFIN"},{"av":"A70PromocionVigencia","fld":"PROMOCIONVIGENCIA"},{"av":"A20MotivoRechazoDescripcion","fld":"MOTIVORECHAZODESCRIPCION"},{"av":"cmbUsuarioZona"},{"av":"A63UsuarioZona","fld":"USUARIOZONA"},{"av":"cmbUsuarioGenero"},{"av":"A53UsuarioGenero","fld":"USUARIOGENERO"},{"av":"A30UsuarioNombre","fld":"USUARIONOMBRE"},{"av":"A51UsuarioApellido","fld":"USUARIOAPELLIDO"},{"av":"A31UsuarioCorreo","fld":"USUARIOCORREO"},{"av":"A32UsuarioPass","fld":"USUARIOPASS"},{"av":"A33UsuarioKey","fld":"USUARIOKEY"},{"av":"cmbUsuarioDirectoAsociado"},{"av":"A54UsuarioDirectoAsociado","fld":"USUARIODIRECTOASOCIADO"},{"av":"A55UsuarioRazonSocialAsociado","fld":"USUARIORAZONSOCIALASOCIADO"},{"av":"A56UsuarioNombreComercial","fld":"USUARIONOMBRECOMERCIAL"},{"av":"A57UsuarioFechaNacimiento","fld":"USUARIOFECHANACIMIENTO"},{"av":"A59UsuarioCalleNum","fld":"USUARIOCALLENUM"},{"av":"A60UsuarioColonia","fld":"USUARIOCOLONIA"},{"av":"A61UsuarioDelegacion","fld":"USUARIODELEGACION"},{"av":"A62UsuarioCP","fld":"USUARIOCP","pic":"ZZZZ9"},{"av":"A64UsuarioCelular","fld":"USUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"A65UsuarioTelefonoSucursal","fld":"USUARIOTELEFONOSUCURSAL","pic":"ZZZZZZZZZ9"},{"av":"A66UsuarioSucursal","fld":"USUARIOSUCURSAL"},{"av":"cmbUsuarioProducto"},{"av":"A67UsuarioProducto","fld":"USUARIOPRODUCTO"},{"av":"cmbUsuarioRol"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A82UsuarioNoCuentaBROXEL","fld":"USUARIONOCUENTABROXEL"},{"av":"A83UsuarioReferenciaBROXEL","fld":"USUARIOREFERENCIABROXEL"},{"av":"A13PuestoID","fld":"PUESTOID","pic":"ZZZZZZZZ9"},{"av":"A4CiudadID","fld":"CIUDADID","pic":"ZZZZZZZZ9"},{"av":"A52UsuarioNombreCompleto","fld":"USUARIONOMBRECOMPLETO"},{"av":"A14PuestoDescripcion","fld":"PUESTODESCRIPCION"},{"av":"A5CiudadDescripcion","fld":"CIUDADDESCRIPCION"},{"av":"A1EstadoID","fld":"ESTADOID","pic":"ZZZZZZZZ9"},{"av":"A2EstadoDescripcion","fld":"ESTADODESCRIPCION"},{"av":"A16PaisID","fld":"PAISID","pic":"ZZZZZZZZ9"},{"av":"A17PaisDescripcion","fld":"PAISDESCRIPCION"},{"av":"A28MedidaDescripcion","fld":"MEDIDADESCRIPCION"},{"av":"A74MedidaRin","fld":"MEDIDARIN"},{"av":"A27MedidaCodigo","fld":"MEDIDACODIGO"},{"av":"A22ModeloID","fld":"MODELOID","pic":"ZZZZZZZZ9"},{"av":"A23ModeloDescripcion","fld":"MODELODESCRIPCION"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z77FacturaMedidaID"},{"av":"Z69FacturaID"},{"av":"Z26MedidaID"},{"av":"Z78FacturaMedidaCantidad"},{"av":"Z79FacturaMedidaPrecio"},{"av":"Z71FacturaNo"},{"av":"Z73FacturaFechaFactura"},{"av":"Z72FacturaFechaRegistro"},{"av":"Z75FacturaPDF"},{"av":"Z40001FacturaPDF_GXI"},{"av":"Z80FacturaEstatus"},{"av":"Z41PromocionID"},{"av":"Z19MotivoRechazoID"},{"av":"Z29UsuarioID"},{"av":"Z42PromocionDescripcion"},{"av":"Z43PromocionBase"},{"av":"Z44PromocionArte"},{"av":"Z40000PromocionArte_GXI"},{"av":"Z45PromocionFechaInicio"},{"av":"Z46PromocionFechaFin"},{"av":"Z70PromocionVigencia"},{"av":"Z20MotivoRechazoDescripcion"},{"av":"Z21MotivoRechazoActivo"},{"av":"Z63UsuarioZona"},{"av":"Z53UsuarioGenero"},{"av":"Z30UsuarioNombre"},{"av":"Z51UsuarioApellido"},{"av":"Z31UsuarioCorreo"},{"av":"Z32UsuarioPass"},{"av":"Z33UsuarioKey"},{"av":"Z54UsuarioDirectoAsociado"},{"av":"Z55UsuarioRazonSocialAsociado"},{"av":"Z56UsuarioNombreComercial"},{"av":"Z57UsuarioFechaNacimiento"},{"av":"Z59UsuarioCalleNum"},{"av":"Z60UsuarioColonia"},{"av":"Z61UsuarioDelegacion"},{"av":"Z62UsuarioCP"},{"av":"Z64UsuarioCelular"},{"av":"Z65UsuarioTelefonoSucursal"},{"av":"Z66UsuarioSucursal"},{"av":"Z67UsuarioProducto"},{"av":"Z40UsuarioRol"},{"av":"Z82UsuarioNoCuentaBROXEL"},{"av":"Z83UsuarioReferenciaBROXEL"},{"av":"Z13PuestoID"},{"av":"Z4CiudadID"},{"av":"Z52UsuarioNombreCompleto"},{"av":"Z14PuestoDescripcion"},{"av":"Z5CiudadDescripcion"},{"av":"Z1EstadoID"},{"av":"Z2EstadoDescripcion"},{"av":"Z16PaisID"},{"av":"Z17PaisDescripcion"},{"av":"Z28MedidaDescripcion"},{"av":"Z74MedidaRin"},{"av":"Z27MedidaCodigo"},{"av":"Z22ModeloID"},{"av":"Z23ModeloDescripcion"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]}""");
         setEventMetadata("VALID_FACTURAID","""{"handler":"Valid_Facturaid","iparms":[{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A45PromocionFechaInicio","fld":"PROMOCIONFECHAINICIO"},{"av":"A46PromocionFechaFin","fld":"PROMOCIONFECHAFIN"},{"av":"A19MotivoRechazoID","fld":"MOTIVORECHAZOID","pic":"ZZZZZZZZ9"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9"},{"av":"A30UsuarioNombre","fld":"USUARIONOMBRE"},{"av":"A51UsuarioApellido","fld":"USUARIOAPELLIDO"},{"av":"A13PuestoID","fld":"PUESTOID","pic":"ZZZZZZZZ9"},{"av":"A4CiudadID","fld":"CIUDADID","pic":"ZZZZZZZZ9"},{"av":"A1EstadoID","fld":"ESTADOID","pic":"ZZZZZZZZ9"},{"av":"A16PaisID","fld":"PAISID","pic":"ZZZZZZZZ9"},{"av":"A71FacturaNo","fld":"FACTURANO"},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA"},{"av":"A72FacturaFechaRegistro","fld":"FACTURAFECHAREGISTRO"},{"av":"A75FacturaPDF","fld":"FACTURAPDF"},{"av":"A40001FacturaPDF_GXI","fld":"FACTURAPDF_GXI"},{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS"},{"av":"A42PromocionDescripcion","fld":"PROMOCIONDESCRIPCION"},{"av":"A43PromocionBase","fld":"PROMOCIONBASE"},{"av":"A44PromocionArte","fld":"PROMOCIONARTE"},{"av":"A40000PromocionArte_GXI","fld":"PROMOCIONARTE_GXI"},{"av":"A70PromocionVigencia","fld":"PROMOCIONVIGENCIA"},{"av":"A20MotivoRechazoDescripcion","fld":"MOTIVORECHAZODESCRIPCION"},{"av":"cmbUsuarioZona"},{"av":"A63UsuarioZona","fld":"USUARIOZONA"},{"av":"cmbUsuarioGenero"},{"av":"A53UsuarioGenero","fld":"USUARIOGENERO"},{"av":"A31UsuarioCorreo","fld":"USUARIOCORREO"},{"av":"A32UsuarioPass","fld":"USUARIOPASS"},{"av":"A33UsuarioKey","fld":"USUARIOKEY"},{"av":"cmbUsuarioDirectoAsociado"},{"av":"A54UsuarioDirectoAsociado","fld":"USUARIODIRECTOASOCIADO"},{"av":"A55UsuarioRazonSocialAsociado","fld":"USUARIORAZONSOCIALASOCIADO"},{"av":"A56UsuarioNombreComercial","fld":"USUARIONOMBRECOMERCIAL"},{"av":"A57UsuarioFechaNacimiento","fld":"USUARIOFECHANACIMIENTO"},{"av":"A59UsuarioCalleNum","fld":"USUARIOCALLENUM"},{"av":"A60UsuarioColonia","fld":"USUARIOCOLONIA"},{"av":"A61UsuarioDelegacion","fld":"USUARIODELEGACION"},{"av":"A62UsuarioCP","fld":"USUARIOCP","pic":"ZZZZ9"},{"av":"A64UsuarioCelular","fld":"USUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"A65UsuarioTelefonoSucursal","fld":"USUARIOTELEFONOSUCURSAL","pic":"ZZZZZZZZZ9"},{"av":"A66UsuarioSucursal","fld":"USUARIOSUCURSAL"},{"av":"cmbUsuarioProducto"},{"av":"A67UsuarioProducto","fld":"USUARIOPRODUCTO"},{"av":"cmbUsuarioRol"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A82UsuarioNoCuentaBROXEL","fld":"USUARIONOCUENTABROXEL"},{"av":"A83UsuarioReferenciaBROXEL","fld":"USUARIOREFERENCIABROXEL"},{"av":"A52UsuarioNombreCompleto","fld":"USUARIONOMBRECOMPLETO"},{"av":"A14PuestoDescripcion","fld":"PUESTODESCRIPCION"},{"av":"A5CiudadDescripcion","fld":"CIUDADDESCRIPCION"},{"av":"A2EstadoDescripcion","fld":"ESTADODESCRIPCION"},{"av":"A17PaisDescripcion","fld":"PAISDESCRIPCION"},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]""");
         setEventMetadata("VALID_FACTURAID",""","oparms":[{"av":"A71FacturaNo","fld":"FACTURANO"},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA"},{"av":"A72FacturaFechaRegistro","fld":"FACTURAFECHAREGISTRO"},{"av":"A75FacturaPDF","fld":"FACTURAPDF"},{"av":"A40001FacturaPDF_GXI","fld":"FACTURAPDF_GXI"},{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS"},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A19MotivoRechazoID","fld":"MOTIVORECHAZOID","pic":"ZZZZZZZZ9"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9"},{"av":"A42PromocionDescripcion","fld":"PROMOCIONDESCRIPCION"},{"av":"A43PromocionBase","fld":"PROMOCIONBASE"},{"av":"A44PromocionArte","fld":"PROMOCIONARTE"},{"av":"A40000PromocionArte_GXI","fld":"PROMOCIONARTE_GXI"},{"av":"A45PromocionFechaInicio","fld":"PROMOCIONFECHAINICIO"},{"av":"A46PromocionFechaFin","fld":"PROMOCIONFECHAFIN"},{"av":"A70PromocionVigencia","fld":"PROMOCIONVIGENCIA"},{"av":"A20MotivoRechazoDescripcion","fld":"MOTIVORECHAZODESCRIPCION"},{"av":"cmbUsuarioZona"},{"av":"A63UsuarioZona","fld":"USUARIOZONA"},{"av":"cmbUsuarioGenero"},{"av":"A53UsuarioGenero","fld":"USUARIOGENERO"},{"av":"A30UsuarioNombre","fld":"USUARIONOMBRE"},{"av":"A51UsuarioApellido","fld":"USUARIOAPELLIDO"},{"av":"A31UsuarioCorreo","fld":"USUARIOCORREO"},{"av":"A32UsuarioPass","fld":"USUARIOPASS"},{"av":"A33UsuarioKey","fld":"USUARIOKEY"},{"av":"cmbUsuarioDirectoAsociado"},{"av":"A54UsuarioDirectoAsociado","fld":"USUARIODIRECTOASOCIADO"},{"av":"A55UsuarioRazonSocialAsociado","fld":"USUARIORAZONSOCIALASOCIADO"},{"av":"A56UsuarioNombreComercial","fld":"USUARIONOMBRECOMERCIAL"},{"av":"A57UsuarioFechaNacimiento","fld":"USUARIOFECHANACIMIENTO"},{"av":"A59UsuarioCalleNum","fld":"USUARIOCALLENUM"},{"av":"A60UsuarioColonia","fld":"USUARIOCOLONIA"},{"av":"A61UsuarioDelegacion","fld":"USUARIODELEGACION"},{"av":"A62UsuarioCP","fld":"USUARIOCP","pic":"ZZZZ9"},{"av":"A64UsuarioCelular","fld":"USUARIOCELULAR","pic":"ZZZZZZZZZ9"},{"av":"A65UsuarioTelefonoSucursal","fld":"USUARIOTELEFONOSUCURSAL","pic":"ZZZZZZZZZ9"},{"av":"A66UsuarioSucursal","fld":"USUARIOSUCURSAL"},{"av":"cmbUsuarioProducto"},{"av":"A67UsuarioProducto","fld":"USUARIOPRODUCTO"},{"av":"cmbUsuarioRol"},{"av":"A40UsuarioRol","fld":"USUARIOROL"},{"av":"A82UsuarioNoCuentaBROXEL","fld":"USUARIONOCUENTABROXEL"},{"av":"A83UsuarioReferenciaBROXEL","fld":"USUARIOREFERENCIABROXEL"},{"av":"A13PuestoID","fld":"PUESTOID","pic":"ZZZZZZZZ9"},{"av":"A4CiudadID","fld":"CIUDADID","pic":"ZZZZZZZZ9"},{"av":"A52UsuarioNombreCompleto","fld":"USUARIONOMBRECOMPLETO"},{"av":"A14PuestoDescripcion","fld":"PUESTODESCRIPCION"},{"av":"A5CiudadDescripcion","fld":"CIUDADDESCRIPCION"},{"av":"A1EstadoID","fld":"ESTADOID","pic":"ZZZZZZZZ9"},{"av":"A2EstadoDescripcion","fld":"ESTADODESCRIPCION"},{"av":"A16PaisID","fld":"PAISID","pic":"ZZZZZZZZ9"},{"av":"A17PaisDescripcion","fld":"PAISDESCRIPCION"},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]}""");
         setEventMetadata("VALID_USUARIOID","""{"handler":"Valid_Usuarioid","iparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]""");
         setEventMetadata("VALID_USUARIOID",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]}""");
         setEventMetadata("VALID_MOTIVORECHAZOID","""{"handler":"Valid_Motivorechazoid","iparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]""");
         setEventMetadata("VALID_MOTIVORECHAZOID",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]}""");
         setEventMetadata("VALID_PROMOCIONID","""{"handler":"Valid_Promocionid","iparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]""");
         setEventMetadata("VALID_PROMOCIONID",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]}""");
         setEventMetadata("VALID_MEDIDAID","""{"handler":"Valid_Medidaid","iparms":[{"av":"A26MedidaID","fld":"MEDIDAID","pic":"ZZZZZZZZ9"},{"av":"A22ModeloID","fld":"MODELOID","pic":"ZZZZZZZZ9"},{"av":"A28MedidaDescripcion","fld":"MEDIDADESCRIPCION"},{"av":"A74MedidaRin","fld":"MEDIDARIN"},{"av":"A27MedidaCodigo","fld":"MEDIDACODIGO"},{"av":"A23ModeloDescripcion","fld":"MODELODESCRIPCION"},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]""");
         setEventMetadata("VALID_MEDIDAID",""","oparms":[{"av":"A28MedidaDescripcion","fld":"MEDIDADESCRIPCION"},{"av":"A74MedidaRin","fld":"MEDIDARIN"},{"av":"A27MedidaCodigo","fld":"MEDIDACODIGO"},{"av":"A22ModeloID","fld":"MODELOID","pic":"ZZZZZZZZ9"},{"av":"A23ModeloDescripcion","fld":"MODELODESCRIPCION"},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]}""");
         setEventMetadata("VALID_MODELOID","""{"handler":"Valid_Modeloid","iparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]""");
         setEventMetadata("VALID_MODELOID",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]}""");
         setEventMetadata("VALID_USUARIONOMBRE","""{"handler":"Valid_Usuarionombre","iparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]""");
         setEventMetadata("VALID_USUARIONOMBRE",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]}""");
         setEventMetadata("VALID_USUARIOAPELLIDO","""{"handler":"Valid_Usuarioapellido","iparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]""");
         setEventMetadata("VALID_USUARIOAPELLIDO",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]}""");
         setEventMetadata("VALID_PUESTOID","""{"handler":"Valid_Puestoid","iparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]""");
         setEventMetadata("VALID_PUESTOID",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]}""");
         setEventMetadata("VALID_PAISID","""{"handler":"Valid_Paisid","iparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]""");
         setEventMetadata("VALID_PAISID",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]}""");
         setEventMetadata("VALID_ESTADOID","""{"handler":"Valid_Estadoid","iparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]""");
         setEventMetadata("VALID_ESTADOID",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]}""");
         setEventMetadata("VALID_CIUDADID","""{"handler":"Valid_Ciudadid","iparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]""");
         setEventMetadata("VALID_CIUDADID",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"}]}""");
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
         pr_default.close(30);
         pr_default.close(38);
         pr_default.close(31);
         pr_default.close(32);
         pr_default.close(33);
         pr_default.close(34);
         pr_default.close(35);
         pr_default.close(36);
         pr_default.close(37);
         pr_default.close(39);
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
         A63UsuarioZona = "";
         A53UsuarioGenero = "";
         A80FacturaEstatus = "";
         A54UsuarioDirectoAsociado = "";
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
         A42PromocionDescripcion = "";
         A43PromocionBase = "";
         A44PromocionArte = "";
         A40000PromocionArte_GXI = "";
         sImgUrl = "";
         A70PromocionVigencia = "";
         A71FacturaNo = "";
         A73FacturaFechaFactura = DateTime.MinValue;
         A72FacturaFechaRegistro = DateTime.MinValue;
         A52UsuarioNombreCompleto = "";
         A2EstadoDescripcion = "";
         A5CiudadDescripcion = "";
         A17PaisDescripcion = "";
         A75FacturaPDF = "";
         A40001FacturaPDF_GXI = "";
         A20MotivoRechazoDescripcion = "";
         A28MedidaDescripcion = "";
         A74MedidaRin = "";
         A27MedidaCodigo = "";
         A23ModeloDescripcion = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
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
         A66UsuarioSucursal = "";
         A82UsuarioNoCuentaBROXEL = "";
         A83UsuarioReferenciaBROXEL = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         A45PromocionFechaInicio = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z71FacturaNo = "";
         Z73FacturaFechaFactura = DateTime.MinValue;
         Z72FacturaFechaRegistro = DateTime.MinValue;
         Z75FacturaPDF = "";
         Z40001FacturaPDF_GXI = "";
         Z80FacturaEstatus = "";
         Z42PromocionDescripcion = "";
         Z43PromocionBase = "";
         Z44PromocionArte = "";
         Z40000PromocionArte_GXI = "";
         Z45PromocionFechaInicio = DateTime.MinValue;
         Z46PromocionFechaFin = DateTime.MinValue;
         Z20MotivoRechazoDescripcion = "";
         Z63UsuarioZona = "";
         Z53UsuarioGenero = "";
         Z30UsuarioNombre = "";
         Z51UsuarioApellido = "";
         Z31UsuarioCorreo = "";
         Z32UsuarioPass = "";
         Z33UsuarioKey = "";
         Z54UsuarioDirectoAsociado = "";
         Z55UsuarioRazonSocialAsociado = "";
         Z56UsuarioNombreComercial = "";
         Z57UsuarioFechaNacimiento = DateTime.MinValue;
         Z59UsuarioCalleNum = "";
         Z60UsuarioColonia = "";
         Z61UsuarioDelegacion = "";
         Z66UsuarioSucursal = "";
         Z67UsuarioProducto = "";
         Z40UsuarioRol = "";
         Z82UsuarioNoCuentaBROXEL = "";
         Z83UsuarioReferenciaBROXEL = "";
         Z14PuestoDescripcion = "";
         Z5CiudadDescripcion = "";
         Z2EstadoDescripcion = "";
         Z17PaisDescripcion = "";
         Z28MedidaDescripcion = "";
         Z74MedidaRin = "";
         Z27MedidaCodigo = "";
         Z23ModeloDescripcion = "";
         T000G14_A77FacturaMedidaID = new int[1] ;
         T000G14_A42PromocionDescripcion = new string[] {""} ;
         T000G14_A43PromocionBase = new string[] {""} ;
         T000G14_A40000PromocionArte_GXI = new string[] {""} ;
         T000G14_A71FacturaNo = new string[] {""} ;
         T000G14_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         T000G14_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         T000G14_A63UsuarioZona = new string[] {""} ;
         T000G14_A2EstadoDescripcion = new string[] {""} ;
         T000G14_A5CiudadDescripcion = new string[] {""} ;
         T000G14_A17PaisDescripcion = new string[] {""} ;
         T000G14_A53UsuarioGenero = new string[] {""} ;
         T000G14_A40001FacturaPDF_GXI = new string[] {""} ;
         T000G14_A80FacturaEstatus = new string[] {""} ;
         T000G14_A20MotivoRechazoDescripcion = new string[] {""} ;
         T000G14_A21MotivoRechazoActivo = new bool[] {false} ;
         T000G14_A28MedidaDescripcion = new string[] {""} ;
         T000G14_A74MedidaRin = new string[] {""} ;
         T000G14_A27MedidaCodigo = new string[] {""} ;
         T000G14_A23ModeloDescripcion = new string[] {""} ;
         T000G14_A78FacturaMedidaCantidad = new short[1] ;
         T000G14_A79FacturaMedidaPrecio = new decimal[1] ;
         T000G14_A30UsuarioNombre = new string[] {""} ;
         T000G14_A51UsuarioApellido = new string[] {""} ;
         T000G14_A31UsuarioCorreo = new string[] {""} ;
         T000G14_A32UsuarioPass = new string[] {""} ;
         T000G14_A33UsuarioKey = new string[] {""} ;
         T000G14_A14PuestoDescripcion = new string[] {""} ;
         T000G14_A54UsuarioDirectoAsociado = new string[] {""} ;
         T000G14_n54UsuarioDirectoAsociado = new bool[] {false} ;
         T000G14_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         T000G14_A56UsuarioNombreComercial = new string[] {""} ;
         T000G14_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T000G14_n57UsuarioFechaNacimiento = new bool[] {false} ;
         T000G14_A59UsuarioCalleNum = new string[] {""} ;
         T000G14_A60UsuarioColonia = new string[] {""} ;
         T000G14_A61UsuarioDelegacion = new string[] {""} ;
         T000G14_A62UsuarioCP = new int[1] ;
         T000G14_A64UsuarioCelular = new long[1] ;
         T000G14_A65UsuarioTelefonoSucursal = new long[1] ;
         T000G14_A66UsuarioSucursal = new string[] {""} ;
         T000G14_A67UsuarioProducto = new string[] {""} ;
         T000G14_n67UsuarioProducto = new bool[] {false} ;
         T000G14_A40UsuarioRol = new string[] {""} ;
         T000G14_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         T000G14_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         T000G14_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000G14_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         T000G14_A69FacturaID = new int[1] ;
         T000G14_A26MedidaID = new int[1] ;
         T000G14_A41PromocionID = new int[1] ;
         T000G14_A19MotivoRechazoID = new int[1] ;
         T000G14_A29UsuarioID = new int[1] ;
         T000G14_A13PuestoID = new int[1] ;
         T000G14_n13PuestoID = new bool[] {false} ;
         T000G14_A4CiudadID = new int[1] ;
         T000G14_n4CiudadID = new bool[] {false} ;
         T000G14_A1EstadoID = new int[1] ;
         T000G14_A16PaisID = new int[1] ;
         T000G14_A22ModeloID = new int[1] ;
         T000G14_A44PromocionArte = new string[] {""} ;
         T000G14_A75FacturaPDF = new string[] {""} ;
         T000G4_A71FacturaNo = new string[] {""} ;
         T000G4_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         T000G4_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         T000G4_A40001FacturaPDF_GXI = new string[] {""} ;
         T000G4_A80FacturaEstatus = new string[] {""} ;
         T000G4_A41PromocionID = new int[1] ;
         T000G4_A19MotivoRechazoID = new int[1] ;
         T000G4_A29UsuarioID = new int[1] ;
         T000G4_A75FacturaPDF = new string[] {""} ;
         T000G6_A42PromocionDescripcion = new string[] {""} ;
         T000G6_A43PromocionBase = new string[] {""} ;
         T000G6_A40000PromocionArte_GXI = new string[] {""} ;
         T000G6_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000G6_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         T000G6_A44PromocionArte = new string[] {""} ;
         T000G7_A20MotivoRechazoDescripcion = new string[] {""} ;
         T000G7_A21MotivoRechazoActivo = new bool[] {false} ;
         T000G8_A63UsuarioZona = new string[] {""} ;
         T000G8_A53UsuarioGenero = new string[] {""} ;
         T000G8_A30UsuarioNombre = new string[] {""} ;
         T000G8_A51UsuarioApellido = new string[] {""} ;
         T000G8_A31UsuarioCorreo = new string[] {""} ;
         T000G8_A32UsuarioPass = new string[] {""} ;
         T000G8_A33UsuarioKey = new string[] {""} ;
         T000G8_A54UsuarioDirectoAsociado = new string[] {""} ;
         T000G8_n54UsuarioDirectoAsociado = new bool[] {false} ;
         T000G8_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         T000G8_A56UsuarioNombreComercial = new string[] {""} ;
         T000G8_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T000G8_n57UsuarioFechaNacimiento = new bool[] {false} ;
         T000G8_A59UsuarioCalleNum = new string[] {""} ;
         T000G8_A60UsuarioColonia = new string[] {""} ;
         T000G8_A61UsuarioDelegacion = new string[] {""} ;
         T000G8_A62UsuarioCP = new int[1] ;
         T000G8_A64UsuarioCelular = new long[1] ;
         T000G8_A65UsuarioTelefonoSucursal = new long[1] ;
         T000G8_A66UsuarioSucursal = new string[] {""} ;
         T000G8_A67UsuarioProducto = new string[] {""} ;
         T000G8_n67UsuarioProducto = new bool[] {false} ;
         T000G8_A40UsuarioRol = new string[] {""} ;
         T000G8_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         T000G8_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         T000G8_A13PuestoID = new int[1] ;
         T000G8_n13PuestoID = new bool[] {false} ;
         T000G8_A4CiudadID = new int[1] ;
         T000G8_n4CiudadID = new bool[] {false} ;
         T000G9_A14PuestoDescripcion = new string[] {""} ;
         T000G10_A5CiudadDescripcion = new string[] {""} ;
         T000G10_A1EstadoID = new int[1] ;
         T000G11_A2EstadoDescripcion = new string[] {""} ;
         T000G11_A16PaisID = new int[1] ;
         T000G12_A17PaisDescripcion = new string[] {""} ;
         T000G5_A28MedidaDescripcion = new string[] {""} ;
         T000G5_A74MedidaRin = new string[] {""} ;
         T000G5_A27MedidaCodigo = new string[] {""} ;
         T000G5_A22ModeloID = new int[1] ;
         T000G13_A23ModeloDescripcion = new string[] {""} ;
         T000G15_A71FacturaNo = new string[] {""} ;
         T000G15_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         T000G15_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         T000G15_A40001FacturaPDF_GXI = new string[] {""} ;
         T000G15_A80FacturaEstatus = new string[] {""} ;
         T000G15_A41PromocionID = new int[1] ;
         T000G15_A19MotivoRechazoID = new int[1] ;
         T000G15_A29UsuarioID = new int[1] ;
         T000G15_A75FacturaPDF = new string[] {""} ;
         T000G16_A42PromocionDescripcion = new string[] {""} ;
         T000G16_A43PromocionBase = new string[] {""} ;
         T000G16_A40000PromocionArte_GXI = new string[] {""} ;
         T000G16_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000G16_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         T000G16_A44PromocionArte = new string[] {""} ;
         T000G17_A20MotivoRechazoDescripcion = new string[] {""} ;
         T000G17_A21MotivoRechazoActivo = new bool[] {false} ;
         T000G18_A63UsuarioZona = new string[] {""} ;
         T000G18_A53UsuarioGenero = new string[] {""} ;
         T000G18_A30UsuarioNombre = new string[] {""} ;
         T000G18_A51UsuarioApellido = new string[] {""} ;
         T000G18_A31UsuarioCorreo = new string[] {""} ;
         T000G18_A32UsuarioPass = new string[] {""} ;
         T000G18_A33UsuarioKey = new string[] {""} ;
         T000G18_A54UsuarioDirectoAsociado = new string[] {""} ;
         T000G18_n54UsuarioDirectoAsociado = new bool[] {false} ;
         T000G18_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         T000G18_A56UsuarioNombreComercial = new string[] {""} ;
         T000G18_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T000G18_n57UsuarioFechaNacimiento = new bool[] {false} ;
         T000G18_A59UsuarioCalleNum = new string[] {""} ;
         T000G18_A60UsuarioColonia = new string[] {""} ;
         T000G18_A61UsuarioDelegacion = new string[] {""} ;
         T000G18_A62UsuarioCP = new int[1] ;
         T000G18_A64UsuarioCelular = new long[1] ;
         T000G18_A65UsuarioTelefonoSucursal = new long[1] ;
         T000G18_A66UsuarioSucursal = new string[] {""} ;
         T000G18_A67UsuarioProducto = new string[] {""} ;
         T000G18_n67UsuarioProducto = new bool[] {false} ;
         T000G18_A40UsuarioRol = new string[] {""} ;
         T000G18_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         T000G18_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         T000G18_A13PuestoID = new int[1] ;
         T000G18_n13PuestoID = new bool[] {false} ;
         T000G18_A4CiudadID = new int[1] ;
         T000G18_n4CiudadID = new bool[] {false} ;
         T000G19_A14PuestoDescripcion = new string[] {""} ;
         T000G20_A5CiudadDescripcion = new string[] {""} ;
         T000G20_A1EstadoID = new int[1] ;
         T000G21_A2EstadoDescripcion = new string[] {""} ;
         T000G21_A16PaisID = new int[1] ;
         T000G22_A17PaisDescripcion = new string[] {""} ;
         T000G23_A28MedidaDescripcion = new string[] {""} ;
         T000G23_A74MedidaRin = new string[] {""} ;
         T000G23_A27MedidaCodigo = new string[] {""} ;
         T000G23_A22ModeloID = new int[1] ;
         T000G24_A23ModeloDescripcion = new string[] {""} ;
         T000G25_A77FacturaMedidaID = new int[1] ;
         T000G3_A77FacturaMedidaID = new int[1] ;
         T000G3_A78FacturaMedidaCantidad = new short[1] ;
         T000G3_A79FacturaMedidaPrecio = new decimal[1] ;
         T000G3_A69FacturaID = new int[1] ;
         T000G3_A26MedidaID = new int[1] ;
         sMode16 = "";
         T000G26_A77FacturaMedidaID = new int[1] ;
         T000G27_A77FacturaMedidaID = new int[1] ;
         T000G2_A77FacturaMedidaID = new int[1] ;
         T000G2_A78FacturaMedidaCantidad = new short[1] ;
         T000G2_A79FacturaMedidaPrecio = new decimal[1] ;
         T000G2_A69FacturaID = new int[1] ;
         T000G2_A26MedidaID = new int[1] ;
         T000G29_A77FacturaMedidaID = new int[1] ;
         T000G32_A71FacturaNo = new string[] {""} ;
         T000G32_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         T000G32_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         T000G32_A40001FacturaPDF_GXI = new string[] {""} ;
         T000G32_A80FacturaEstatus = new string[] {""} ;
         T000G32_A41PromocionID = new int[1] ;
         T000G32_A19MotivoRechazoID = new int[1] ;
         T000G32_A29UsuarioID = new int[1] ;
         T000G32_A75FacturaPDF = new string[] {""} ;
         T000G33_A42PromocionDescripcion = new string[] {""} ;
         T000G33_A43PromocionBase = new string[] {""} ;
         T000G33_A40000PromocionArte_GXI = new string[] {""} ;
         T000G33_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000G33_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         T000G33_A44PromocionArte = new string[] {""} ;
         T000G34_A20MotivoRechazoDescripcion = new string[] {""} ;
         T000G34_A21MotivoRechazoActivo = new bool[] {false} ;
         T000G35_A63UsuarioZona = new string[] {""} ;
         T000G35_A53UsuarioGenero = new string[] {""} ;
         T000G35_A30UsuarioNombre = new string[] {""} ;
         T000G35_A51UsuarioApellido = new string[] {""} ;
         T000G35_A31UsuarioCorreo = new string[] {""} ;
         T000G35_A32UsuarioPass = new string[] {""} ;
         T000G35_A33UsuarioKey = new string[] {""} ;
         T000G35_A54UsuarioDirectoAsociado = new string[] {""} ;
         T000G35_n54UsuarioDirectoAsociado = new bool[] {false} ;
         T000G35_A55UsuarioRazonSocialAsociado = new string[] {""} ;
         T000G35_A56UsuarioNombreComercial = new string[] {""} ;
         T000G35_A57UsuarioFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T000G35_n57UsuarioFechaNacimiento = new bool[] {false} ;
         T000G35_A59UsuarioCalleNum = new string[] {""} ;
         T000G35_A60UsuarioColonia = new string[] {""} ;
         T000G35_A61UsuarioDelegacion = new string[] {""} ;
         T000G35_A62UsuarioCP = new int[1] ;
         T000G35_A64UsuarioCelular = new long[1] ;
         T000G35_A65UsuarioTelefonoSucursal = new long[1] ;
         T000G35_A66UsuarioSucursal = new string[] {""} ;
         T000G35_A67UsuarioProducto = new string[] {""} ;
         T000G35_n67UsuarioProducto = new bool[] {false} ;
         T000G35_A40UsuarioRol = new string[] {""} ;
         T000G35_A82UsuarioNoCuentaBROXEL = new string[] {""} ;
         T000G35_A83UsuarioReferenciaBROXEL = new string[] {""} ;
         T000G35_A13PuestoID = new int[1] ;
         T000G35_n13PuestoID = new bool[] {false} ;
         T000G35_A4CiudadID = new int[1] ;
         T000G35_n4CiudadID = new bool[] {false} ;
         T000G36_A14PuestoDescripcion = new string[] {""} ;
         T000G37_A5CiudadDescripcion = new string[] {""} ;
         T000G37_A1EstadoID = new int[1] ;
         T000G38_A2EstadoDescripcion = new string[] {""} ;
         T000G38_A16PaisID = new int[1] ;
         T000G39_A17PaisDescripcion = new string[] {""} ;
         T000G40_A28MedidaDescripcion = new string[] {""} ;
         T000G40_A74MedidaRin = new string[] {""} ;
         T000G40_A27MedidaCodigo = new string[] {""} ;
         T000G40_A22ModeloID = new int[1] ;
         T000G41_A23ModeloDescripcion = new string[] {""} ;
         T000G42_A77FacturaMedidaID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         Z70PromocionVigencia = "";
         Z52UsuarioNombreCompleto = "";
         ZZ71FacturaNo = "";
         ZZ73FacturaFechaFactura = DateTime.MinValue;
         ZZ72FacturaFechaRegistro = DateTime.MinValue;
         ZZ75FacturaPDF = "";
         ZZ40001FacturaPDF_GXI = "";
         ZZ80FacturaEstatus = "";
         ZZ42PromocionDescripcion = "";
         ZZ43PromocionBase = "";
         ZZ44PromocionArte = "";
         ZZ40000PromocionArte_GXI = "";
         ZZ45PromocionFechaInicio = DateTime.MinValue;
         ZZ46PromocionFechaFin = DateTime.MinValue;
         ZZ70PromocionVigencia = "";
         ZZ20MotivoRechazoDescripcion = "";
         ZZ63UsuarioZona = "";
         ZZ53UsuarioGenero = "";
         ZZ30UsuarioNombre = "";
         ZZ51UsuarioApellido = "";
         ZZ31UsuarioCorreo = "";
         ZZ32UsuarioPass = "";
         ZZ33UsuarioKey = "";
         ZZ54UsuarioDirectoAsociado = "";
         ZZ55UsuarioRazonSocialAsociado = "";
         ZZ56UsuarioNombreComercial = "";
         ZZ57UsuarioFechaNacimiento = DateTime.MinValue;
         ZZ59UsuarioCalleNum = "";
         ZZ60UsuarioColonia = "";
         ZZ61UsuarioDelegacion = "";
         ZZ66UsuarioSucursal = "";
         ZZ67UsuarioProducto = "";
         ZZ40UsuarioRol = "";
         ZZ82UsuarioNoCuentaBROXEL = "";
         ZZ83UsuarioReferenciaBROXEL = "";
         ZZ52UsuarioNombreCompleto = "";
         ZZ14PuestoDescripcion = "";
         ZZ5CiudadDescripcion = "";
         ZZ2EstadoDescripcion = "";
         ZZ17PaisDescripcion = "";
         ZZ28MedidaDescripcion = "";
         ZZ74MedidaRin = "";
         ZZ27MedidaCodigo = "";
         ZZ23ModeloDescripcion = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.facturamedida__default(),
            new Object[][] {
                new Object[] {
               T000G2_A77FacturaMedidaID, T000G2_A78FacturaMedidaCantidad, T000G2_A79FacturaMedidaPrecio, T000G2_A69FacturaID, T000G2_A26MedidaID
               }
               , new Object[] {
               T000G3_A77FacturaMedidaID, T000G3_A78FacturaMedidaCantidad, T000G3_A79FacturaMedidaPrecio, T000G3_A69FacturaID, T000G3_A26MedidaID
               }
               , new Object[] {
               T000G4_A71FacturaNo, T000G4_A73FacturaFechaFactura, T000G4_A72FacturaFechaRegistro, T000G4_A40001FacturaPDF_GXI, T000G4_A80FacturaEstatus, T000G4_A41PromocionID, T000G4_A19MotivoRechazoID, T000G4_A29UsuarioID, T000G4_A75FacturaPDF
               }
               , new Object[] {
               T000G5_A28MedidaDescripcion, T000G5_A74MedidaRin, T000G5_A27MedidaCodigo, T000G5_A22ModeloID
               }
               , new Object[] {
               T000G6_A42PromocionDescripcion, T000G6_A43PromocionBase, T000G6_A40000PromocionArte_GXI, T000G6_A45PromocionFechaInicio, T000G6_A46PromocionFechaFin, T000G6_A44PromocionArte
               }
               , new Object[] {
               T000G7_A20MotivoRechazoDescripcion, T000G7_A21MotivoRechazoActivo
               }
               , new Object[] {
               T000G8_A63UsuarioZona, T000G8_A53UsuarioGenero, T000G8_A30UsuarioNombre, T000G8_A51UsuarioApellido, T000G8_A31UsuarioCorreo, T000G8_A32UsuarioPass, T000G8_A33UsuarioKey, T000G8_A54UsuarioDirectoAsociado, T000G8_n54UsuarioDirectoAsociado, T000G8_A55UsuarioRazonSocialAsociado,
               T000G8_A56UsuarioNombreComercial, T000G8_A57UsuarioFechaNacimiento, T000G8_n57UsuarioFechaNacimiento, T000G8_A59UsuarioCalleNum, T000G8_A60UsuarioColonia, T000G8_A61UsuarioDelegacion, T000G8_A62UsuarioCP, T000G8_A64UsuarioCelular, T000G8_A65UsuarioTelefonoSucursal, T000G8_A66UsuarioSucursal,
               T000G8_A67UsuarioProducto, T000G8_n67UsuarioProducto, T000G8_A40UsuarioRol, T000G8_A82UsuarioNoCuentaBROXEL, T000G8_A83UsuarioReferenciaBROXEL, T000G8_A13PuestoID, T000G8_n13PuestoID, T000G8_A4CiudadID, T000G8_n4CiudadID
               }
               , new Object[] {
               T000G9_A14PuestoDescripcion
               }
               , new Object[] {
               T000G10_A5CiudadDescripcion, T000G10_A1EstadoID
               }
               , new Object[] {
               T000G11_A2EstadoDescripcion, T000G11_A16PaisID
               }
               , new Object[] {
               T000G12_A17PaisDescripcion
               }
               , new Object[] {
               T000G13_A23ModeloDescripcion
               }
               , new Object[] {
               T000G14_A77FacturaMedidaID, T000G14_A42PromocionDescripcion, T000G14_A43PromocionBase, T000G14_A40000PromocionArte_GXI, T000G14_A71FacturaNo, T000G14_A73FacturaFechaFactura, T000G14_A72FacturaFechaRegistro, T000G14_A63UsuarioZona, T000G14_A2EstadoDescripcion, T000G14_A5CiudadDescripcion,
               T000G14_A17PaisDescripcion, T000G14_A53UsuarioGenero, T000G14_A40001FacturaPDF_GXI, T000G14_A80FacturaEstatus, T000G14_A20MotivoRechazoDescripcion, T000G14_A21MotivoRechazoActivo, T000G14_A28MedidaDescripcion, T000G14_A74MedidaRin, T000G14_A27MedidaCodigo, T000G14_A23ModeloDescripcion,
               T000G14_A78FacturaMedidaCantidad, T000G14_A79FacturaMedidaPrecio, T000G14_A30UsuarioNombre, T000G14_A51UsuarioApellido, T000G14_A31UsuarioCorreo, T000G14_A32UsuarioPass, T000G14_A33UsuarioKey, T000G14_A14PuestoDescripcion, T000G14_A54UsuarioDirectoAsociado, T000G14_n54UsuarioDirectoAsociado,
               T000G14_A55UsuarioRazonSocialAsociado, T000G14_A56UsuarioNombreComercial, T000G14_A57UsuarioFechaNacimiento, T000G14_n57UsuarioFechaNacimiento, T000G14_A59UsuarioCalleNum, T000G14_A60UsuarioColonia, T000G14_A61UsuarioDelegacion, T000G14_A62UsuarioCP, T000G14_A64UsuarioCelular, T000G14_A65UsuarioTelefonoSucursal,
               T000G14_A66UsuarioSucursal, T000G14_A67UsuarioProducto, T000G14_n67UsuarioProducto, T000G14_A40UsuarioRol, T000G14_A82UsuarioNoCuentaBROXEL, T000G14_A83UsuarioReferenciaBROXEL, T000G14_A45PromocionFechaInicio, T000G14_A46PromocionFechaFin, T000G14_A69FacturaID, T000G14_A26MedidaID,
               T000G14_A41PromocionID, T000G14_A19MotivoRechazoID, T000G14_A29UsuarioID, T000G14_A13PuestoID, T000G14_n13PuestoID, T000G14_A4CiudadID, T000G14_n4CiudadID, T000G14_A1EstadoID, T000G14_A16PaisID, T000G14_A22ModeloID,
               T000G14_A44PromocionArte, T000G14_A75FacturaPDF
               }
               , new Object[] {
               T000G15_A71FacturaNo, T000G15_A73FacturaFechaFactura, T000G15_A72FacturaFechaRegistro, T000G15_A40001FacturaPDF_GXI, T000G15_A80FacturaEstatus, T000G15_A41PromocionID, T000G15_A19MotivoRechazoID, T000G15_A29UsuarioID, T000G15_A75FacturaPDF
               }
               , new Object[] {
               T000G16_A42PromocionDescripcion, T000G16_A43PromocionBase, T000G16_A40000PromocionArte_GXI, T000G16_A45PromocionFechaInicio, T000G16_A46PromocionFechaFin, T000G16_A44PromocionArte
               }
               , new Object[] {
               T000G17_A20MotivoRechazoDescripcion, T000G17_A21MotivoRechazoActivo
               }
               , new Object[] {
               T000G18_A63UsuarioZona, T000G18_A53UsuarioGenero, T000G18_A30UsuarioNombre, T000G18_A51UsuarioApellido, T000G18_A31UsuarioCorreo, T000G18_A32UsuarioPass, T000G18_A33UsuarioKey, T000G18_A54UsuarioDirectoAsociado, T000G18_n54UsuarioDirectoAsociado, T000G18_A55UsuarioRazonSocialAsociado,
               T000G18_A56UsuarioNombreComercial, T000G18_A57UsuarioFechaNacimiento, T000G18_n57UsuarioFechaNacimiento, T000G18_A59UsuarioCalleNum, T000G18_A60UsuarioColonia, T000G18_A61UsuarioDelegacion, T000G18_A62UsuarioCP, T000G18_A64UsuarioCelular, T000G18_A65UsuarioTelefonoSucursal, T000G18_A66UsuarioSucursal,
               T000G18_A67UsuarioProducto, T000G18_n67UsuarioProducto, T000G18_A40UsuarioRol, T000G18_A82UsuarioNoCuentaBROXEL, T000G18_A83UsuarioReferenciaBROXEL, T000G18_A13PuestoID, T000G18_n13PuestoID, T000G18_A4CiudadID, T000G18_n4CiudadID
               }
               , new Object[] {
               T000G19_A14PuestoDescripcion
               }
               , new Object[] {
               T000G20_A5CiudadDescripcion, T000G20_A1EstadoID
               }
               , new Object[] {
               T000G21_A2EstadoDescripcion, T000G21_A16PaisID
               }
               , new Object[] {
               T000G22_A17PaisDescripcion
               }
               , new Object[] {
               T000G23_A28MedidaDescripcion, T000G23_A74MedidaRin, T000G23_A27MedidaCodigo, T000G23_A22ModeloID
               }
               , new Object[] {
               T000G24_A23ModeloDescripcion
               }
               , new Object[] {
               T000G25_A77FacturaMedidaID
               }
               , new Object[] {
               T000G26_A77FacturaMedidaID
               }
               , new Object[] {
               T000G27_A77FacturaMedidaID
               }
               , new Object[] {
               }
               , new Object[] {
               T000G29_A77FacturaMedidaID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000G32_A71FacturaNo, T000G32_A73FacturaFechaFactura, T000G32_A72FacturaFechaRegistro, T000G32_A40001FacturaPDF_GXI, T000G32_A80FacturaEstatus, T000G32_A41PromocionID, T000G32_A19MotivoRechazoID, T000G32_A29UsuarioID, T000G32_A75FacturaPDF
               }
               , new Object[] {
               T000G33_A42PromocionDescripcion, T000G33_A43PromocionBase, T000G33_A40000PromocionArte_GXI, T000G33_A45PromocionFechaInicio, T000G33_A46PromocionFechaFin, T000G33_A44PromocionArte
               }
               , new Object[] {
               T000G34_A20MotivoRechazoDescripcion, T000G34_A21MotivoRechazoActivo
               }
               , new Object[] {
               T000G35_A63UsuarioZona, T000G35_A53UsuarioGenero, T000G35_A30UsuarioNombre, T000G35_A51UsuarioApellido, T000G35_A31UsuarioCorreo, T000G35_A32UsuarioPass, T000G35_A33UsuarioKey, T000G35_A54UsuarioDirectoAsociado, T000G35_n54UsuarioDirectoAsociado, T000G35_A55UsuarioRazonSocialAsociado,
               T000G35_A56UsuarioNombreComercial, T000G35_A57UsuarioFechaNacimiento, T000G35_n57UsuarioFechaNacimiento, T000G35_A59UsuarioCalleNum, T000G35_A60UsuarioColonia, T000G35_A61UsuarioDelegacion, T000G35_A62UsuarioCP, T000G35_A64UsuarioCelular, T000G35_A65UsuarioTelefonoSucursal, T000G35_A66UsuarioSucursal,
               T000G35_A67UsuarioProducto, T000G35_n67UsuarioProducto, T000G35_A40UsuarioRol, T000G35_A82UsuarioNoCuentaBROXEL, T000G35_A83UsuarioReferenciaBROXEL, T000G35_A13PuestoID, T000G35_n13PuestoID, T000G35_A4CiudadID, T000G35_n4CiudadID
               }
               , new Object[] {
               T000G36_A14PuestoDescripcion
               }
               , new Object[] {
               T000G37_A5CiudadDescripcion, T000G37_A1EstadoID
               }
               , new Object[] {
               T000G38_A2EstadoDescripcion, T000G38_A16PaisID
               }
               , new Object[] {
               T000G39_A17PaisDescripcion
               }
               , new Object[] {
               T000G40_A28MedidaDescripcion, T000G40_A74MedidaRin, T000G40_A27MedidaCodigo, T000G40_A22ModeloID
               }
               , new Object[] {
               T000G41_A23ModeloDescripcion
               }
               , new Object[] {
               T000G42_A77FacturaMedidaID
               }
            }
         );
      }

      private short Z78FacturaMedidaCantidad ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A78FacturaMedidaCantidad ;
      private short RcdFound16 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ78FacturaMedidaCantidad ;
      private int Z77FacturaMedidaID ;
      private int Z69FacturaID ;
      private int Z26MedidaID ;
      private int A69FacturaID ;
      private int A41PromocionID ;
      private int A19MotivoRechazoID ;
      private int A29UsuarioID ;
      private int A13PuestoID ;
      private int A4CiudadID ;
      private int A1EstadoID ;
      private int A16PaisID ;
      private int A26MedidaID ;
      private int A22ModeloID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A77FacturaMedidaID ;
      private int edtFacturaMedidaID_Enabled ;
      private int edtFacturaID_Enabled ;
      private int edtPromocionDescripcion_Enabled ;
      private int edtPromocionBase_Enabled ;
      private int imgPromocionArte_Enabled ;
      private int edtPromocionVigencia_Enabled ;
      private int edtFacturaNo_Enabled ;
      private int edtFacturaFechaFactura_Enabled ;
      private int edtFacturaFechaRegistro_Enabled ;
      private int edtUsuarioID_Enabled ;
      private int edtUsuarioNombreCompleto_Enabled ;
      private int edtEstadoDescripcion_Enabled ;
      private int edtCiudadDescripcion_Enabled ;
      private int edtPaisDescripcion_Enabled ;
      private int edtFacturaPDF_Enabled ;
      private int edtMotivoRechazoID_Enabled ;
      private int edtMotivoRechazoDescripcion_Enabled ;
      private int edtPromocionID_Enabled ;
      private int edtMedidaID_Enabled ;
      private int edtMedidaDescripcion_Enabled ;
      private int edtMedidaRin_Enabled ;
      private int edtMedidaCodigo_Enabled ;
      private int edtModeloID_Enabled ;
      private int edtModeloDescripcion_Enabled ;
      private int edtFacturaMedidaCantidad_Enabled ;
      private int edtFacturaMedidaPrecio_Enabled ;
      private int edtUsuarioNombre_Enabled ;
      private int edtUsuarioApellido_Enabled ;
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
      private int edtEstadoID_Enabled ;
      private int edtCiudadID_Enabled ;
      private int edtUsuarioSucursal_Enabled ;
      private int edtUsuarioNoCuentaBROXEL_Enabled ;
      private int edtUsuarioReferenciaBROXEL_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int Z41PromocionID ;
      private int Z19MotivoRechazoID ;
      private int Z29UsuarioID ;
      private int Z62UsuarioCP ;
      private int Z13PuestoID ;
      private int Z4CiudadID ;
      private int Z1EstadoID ;
      private int Z16PaisID ;
      private int Z22ModeloID ;
      private int idxLst ;
      private int ZZ77FacturaMedidaID ;
      private int ZZ69FacturaID ;
      private int ZZ26MedidaID ;
      private int ZZ41PromocionID ;
      private int ZZ19MotivoRechazoID ;
      private int ZZ29UsuarioID ;
      private int ZZ62UsuarioCP ;
      private int ZZ13PuestoID ;
      private int ZZ4CiudadID ;
      private int ZZ1EstadoID ;
      private int ZZ16PaisID ;
      private int ZZ22ModeloID ;
      private long A64UsuarioCelular ;
      private long A65UsuarioTelefonoSucursal ;
      private long Z64UsuarioCelular ;
      private long Z65UsuarioTelefonoSucursal ;
      private long ZZ64UsuarioCelular ;
      private long ZZ65UsuarioTelefonoSucursal ;
      private decimal Z79FacturaMedidaPrecio ;
      private decimal A79FacturaMedidaPrecio ;
      private decimal ZZ79FacturaMedidaPrecio ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtFacturaMedidaID_Internalname ;
      private string A63UsuarioZona ;
      private string cmbUsuarioZona_Internalname ;
      private string A53UsuarioGenero ;
      private string cmbUsuarioGenero_Internalname ;
      private string A80FacturaEstatus ;
      private string cmbFacturaEstatus_Internalname ;
      private string A54UsuarioDirectoAsociado ;
      private string cmbUsuarioDirectoAsociado_Internalname ;
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
      private string edtFacturaMedidaID_Jsonclick ;
      private string edtFacturaID_Internalname ;
      private string edtFacturaID_Jsonclick ;
      private string edtPromocionDescripcion_Internalname ;
      private string edtPromocionDescripcion_Jsonclick ;
      private string edtPromocionBase_Internalname ;
      private string imgPromocionArte_Internalname ;
      private string sImgUrl ;
      private string edtPromocionVigencia_Internalname ;
      private string edtPromocionVigencia_Jsonclick ;
      private string edtFacturaNo_Internalname ;
      private string A71FacturaNo ;
      private string edtFacturaNo_Jsonclick ;
      private string edtFacturaFechaFactura_Internalname ;
      private string edtFacturaFechaFactura_Jsonclick ;
      private string edtFacturaFechaRegistro_Internalname ;
      private string edtFacturaFechaRegistro_Jsonclick ;
      private string edtUsuarioID_Internalname ;
      private string edtUsuarioID_Jsonclick ;
      private string edtUsuarioNombreCompleto_Internalname ;
      private string edtUsuarioNombreCompleto_Jsonclick ;
      private string cmbUsuarioZona_Jsonclick ;
      private string edtEstadoDescripcion_Internalname ;
      private string edtEstadoDescripcion_Jsonclick ;
      private string edtCiudadDescripcion_Internalname ;
      private string edtCiudadDescripcion_Jsonclick ;
      private string edtPaisDescripcion_Internalname ;
      private string edtPaisDescripcion_Jsonclick ;
      private string cmbUsuarioGenero_Jsonclick ;
      private string edtFacturaPDF_Internalname ;
      private string edtFacturaPDF_Filename ;
      private string cmbFacturaEstatus_Jsonclick ;
      private string edtMotivoRechazoID_Internalname ;
      private string edtMotivoRechazoID_Jsonclick ;
      private string edtMotivoRechazoDescripcion_Internalname ;
      private string edtMotivoRechazoDescripcion_Jsonclick ;
      private string chkMotivoRechazoActivo_Internalname ;
      private string edtPromocionID_Internalname ;
      private string edtPromocionID_Jsonclick ;
      private string edtMedidaID_Internalname ;
      private string edtMedidaID_Jsonclick ;
      private string edtMedidaDescripcion_Internalname ;
      private string edtMedidaDescripcion_Jsonclick ;
      private string edtMedidaRin_Internalname ;
      private string A74MedidaRin ;
      private string edtMedidaRin_Jsonclick ;
      private string edtMedidaCodigo_Internalname ;
      private string A27MedidaCodigo ;
      private string edtMedidaCodigo_Jsonclick ;
      private string edtModeloID_Internalname ;
      private string edtModeloID_Jsonclick ;
      private string edtModeloDescripcion_Internalname ;
      private string edtModeloDescripcion_Jsonclick ;
      private string edtFacturaMedidaCantidad_Internalname ;
      private string edtFacturaMedidaCantidad_Jsonclick ;
      private string edtFacturaMedidaPrecio_Internalname ;
      private string edtFacturaMedidaPrecio_Jsonclick ;
      private string edtUsuarioNombre_Internalname ;
      private string A30UsuarioNombre ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtUsuarioApellido_Internalname ;
      private string A51UsuarioApellido ;
      private string edtUsuarioApellido_Jsonclick ;
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
      private string edtUsuarioCelular_Internalname ;
      private string edtUsuarioCelular_Jsonclick ;
      private string edtUsuarioTelefonoSucursal_Internalname ;
      private string edtUsuarioTelefonoSucursal_Jsonclick ;
      private string edtPaisID_Internalname ;
      private string edtPaisID_Jsonclick ;
      private string edtEstadoID_Internalname ;
      private string edtEstadoID_Jsonclick ;
      private string edtCiudadID_Internalname ;
      private string edtCiudadID_Jsonclick ;
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
      private string Z71FacturaNo ;
      private string Z80FacturaEstatus ;
      private string Z63UsuarioZona ;
      private string Z53UsuarioGenero ;
      private string Z30UsuarioNombre ;
      private string Z51UsuarioApellido ;
      private string Z54UsuarioDirectoAsociado ;
      private string Z59UsuarioCalleNum ;
      private string Z60UsuarioColonia ;
      private string Z61UsuarioDelegacion ;
      private string Z66UsuarioSucursal ;
      private string Z40UsuarioRol ;
      private string Z82UsuarioNoCuentaBROXEL ;
      private string Z83UsuarioReferenciaBROXEL ;
      private string Z74MedidaRin ;
      private string Z27MedidaCodigo ;
      private string sMode16 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string ZZ71FacturaNo ;
      private string ZZ80FacturaEstatus ;
      private string ZZ63UsuarioZona ;
      private string ZZ53UsuarioGenero ;
      private string ZZ30UsuarioNombre ;
      private string ZZ51UsuarioApellido ;
      private string ZZ54UsuarioDirectoAsociado ;
      private string ZZ59UsuarioCalleNum ;
      private string ZZ60UsuarioColonia ;
      private string ZZ61UsuarioDelegacion ;
      private string ZZ66UsuarioSucursal ;
      private string ZZ40UsuarioRol ;
      private string ZZ82UsuarioNoCuentaBROXEL ;
      private string ZZ83UsuarioReferenciaBROXEL ;
      private string ZZ74MedidaRin ;
      private string ZZ27MedidaCodigo ;
      private DateTime A73FacturaFechaFactura ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A57UsuarioFechaNacimiento ;
      private DateTime A45PromocionFechaInicio ;
      private DateTime A46PromocionFechaFin ;
      private DateTime Z73FacturaFechaFactura ;
      private DateTime Z72FacturaFechaRegistro ;
      private DateTime Z45PromocionFechaInicio ;
      private DateTime Z46PromocionFechaFin ;
      private DateTime Z57UsuarioFechaNacimiento ;
      private DateTime ZZ73FacturaFechaFactura ;
      private DateTime ZZ72FacturaFechaRegistro ;
      private DateTime ZZ45PromocionFechaInicio ;
      private DateTime ZZ46PromocionFechaFin ;
      private DateTime ZZ57UsuarioFechaNacimiento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n13PuestoID ;
      private bool n4CiudadID ;
      private bool wbErr ;
      private bool A21MotivoRechazoActivo ;
      private bool n54UsuarioDirectoAsociado ;
      private bool n67UsuarioProducto ;
      private bool A44PromocionArte_IsBlob ;
      private bool A75FacturaPDF_IsBlob ;
      private bool n57UsuarioFechaNacimiento ;
      private bool Z21MotivoRechazoActivo ;
      private bool ZZ21MotivoRechazoActivo ;
      private string A67UsuarioProducto ;
      private string A42PromocionDescripcion ;
      private string A43PromocionBase ;
      private string A40000PromocionArte_GXI ;
      private string A70PromocionVigencia ;
      private string A52UsuarioNombreCompleto ;
      private string A2EstadoDescripcion ;
      private string A5CiudadDescripcion ;
      private string A17PaisDescripcion ;
      private string A40001FacturaPDF_GXI ;
      private string A20MotivoRechazoDescripcion ;
      private string A28MedidaDescripcion ;
      private string A23ModeloDescripcion ;
      private string A31UsuarioCorreo ;
      private string A32UsuarioPass ;
      private string A33UsuarioKey ;
      private string A14PuestoDescripcion ;
      private string A55UsuarioRazonSocialAsociado ;
      private string A56UsuarioNombreComercial ;
      private string Z40001FacturaPDF_GXI ;
      private string Z42PromocionDescripcion ;
      private string Z43PromocionBase ;
      private string Z40000PromocionArte_GXI ;
      private string Z20MotivoRechazoDescripcion ;
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
      private string Z28MedidaDescripcion ;
      private string Z23ModeloDescripcion ;
      private string Z70PromocionVigencia ;
      private string Z52UsuarioNombreCompleto ;
      private string ZZ40001FacturaPDF_GXI ;
      private string ZZ42PromocionDescripcion ;
      private string ZZ43PromocionBase ;
      private string ZZ40000PromocionArte_GXI ;
      private string ZZ70PromocionVigencia ;
      private string ZZ20MotivoRechazoDescripcion ;
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
      private string ZZ28MedidaDescripcion ;
      private string ZZ23ModeloDescripcion ;
      private string A44PromocionArte ;
      private string Z44PromocionArte ;
      private string ZZ44PromocionArte ;
      private string A75FacturaPDF ;
      private string Z75FacturaPDF ;
      private string ZZ75FacturaPDF ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbUsuarioZona ;
      private GXCombobox cmbUsuarioGenero ;
      private GXCombobox cmbFacturaEstatus ;
      private GXCheckbox chkMotivoRechazoActivo ;
      private GXCombobox cmbUsuarioDirectoAsociado ;
      private GXCombobox cmbUsuarioProducto ;
      private GXCombobox cmbUsuarioRol ;
      private IDataStoreProvider pr_default ;
      private int[] T000G14_A77FacturaMedidaID ;
      private string[] T000G14_A42PromocionDescripcion ;
      private string[] T000G14_A43PromocionBase ;
      private string[] T000G14_A40000PromocionArte_GXI ;
      private string[] T000G14_A71FacturaNo ;
      private DateTime[] T000G14_A73FacturaFechaFactura ;
      private DateTime[] T000G14_A72FacturaFechaRegistro ;
      private string[] T000G14_A63UsuarioZona ;
      private string[] T000G14_A2EstadoDescripcion ;
      private string[] T000G14_A5CiudadDescripcion ;
      private string[] T000G14_A17PaisDescripcion ;
      private string[] T000G14_A53UsuarioGenero ;
      private string[] T000G14_A40001FacturaPDF_GXI ;
      private string[] T000G14_A80FacturaEstatus ;
      private string[] T000G14_A20MotivoRechazoDescripcion ;
      private bool[] T000G14_A21MotivoRechazoActivo ;
      private string[] T000G14_A28MedidaDescripcion ;
      private string[] T000G14_A74MedidaRin ;
      private string[] T000G14_A27MedidaCodigo ;
      private string[] T000G14_A23ModeloDescripcion ;
      private short[] T000G14_A78FacturaMedidaCantidad ;
      private decimal[] T000G14_A79FacturaMedidaPrecio ;
      private string[] T000G14_A30UsuarioNombre ;
      private string[] T000G14_A51UsuarioApellido ;
      private string[] T000G14_A31UsuarioCorreo ;
      private string[] T000G14_A32UsuarioPass ;
      private string[] T000G14_A33UsuarioKey ;
      private string[] T000G14_A14PuestoDescripcion ;
      private string[] T000G14_A54UsuarioDirectoAsociado ;
      private bool[] T000G14_n54UsuarioDirectoAsociado ;
      private string[] T000G14_A55UsuarioRazonSocialAsociado ;
      private string[] T000G14_A56UsuarioNombreComercial ;
      private DateTime[] T000G14_A57UsuarioFechaNacimiento ;
      private bool[] T000G14_n57UsuarioFechaNacimiento ;
      private string[] T000G14_A59UsuarioCalleNum ;
      private string[] T000G14_A60UsuarioColonia ;
      private string[] T000G14_A61UsuarioDelegacion ;
      private int[] T000G14_A62UsuarioCP ;
      private long[] T000G14_A64UsuarioCelular ;
      private long[] T000G14_A65UsuarioTelefonoSucursal ;
      private string[] T000G14_A66UsuarioSucursal ;
      private string[] T000G14_A67UsuarioProducto ;
      private bool[] T000G14_n67UsuarioProducto ;
      private string[] T000G14_A40UsuarioRol ;
      private string[] T000G14_A82UsuarioNoCuentaBROXEL ;
      private string[] T000G14_A83UsuarioReferenciaBROXEL ;
      private DateTime[] T000G14_A45PromocionFechaInicio ;
      private DateTime[] T000G14_A46PromocionFechaFin ;
      private int[] T000G14_A69FacturaID ;
      private int[] T000G14_A26MedidaID ;
      private int[] T000G14_A41PromocionID ;
      private int[] T000G14_A19MotivoRechazoID ;
      private int[] T000G14_A29UsuarioID ;
      private int[] T000G14_A13PuestoID ;
      private bool[] T000G14_n13PuestoID ;
      private int[] T000G14_A4CiudadID ;
      private bool[] T000G14_n4CiudadID ;
      private int[] T000G14_A1EstadoID ;
      private int[] T000G14_A16PaisID ;
      private int[] T000G14_A22ModeloID ;
      private string[] T000G14_A44PromocionArte ;
      private string[] T000G14_A75FacturaPDF ;
      private string[] T000G4_A71FacturaNo ;
      private DateTime[] T000G4_A73FacturaFechaFactura ;
      private DateTime[] T000G4_A72FacturaFechaRegistro ;
      private string[] T000G4_A40001FacturaPDF_GXI ;
      private string[] T000G4_A80FacturaEstatus ;
      private int[] T000G4_A41PromocionID ;
      private int[] T000G4_A19MotivoRechazoID ;
      private int[] T000G4_A29UsuarioID ;
      private string[] T000G4_A75FacturaPDF ;
      private string[] T000G6_A42PromocionDescripcion ;
      private string[] T000G6_A43PromocionBase ;
      private string[] T000G6_A40000PromocionArte_GXI ;
      private DateTime[] T000G6_A45PromocionFechaInicio ;
      private DateTime[] T000G6_A46PromocionFechaFin ;
      private string[] T000G6_A44PromocionArte ;
      private string[] T000G7_A20MotivoRechazoDescripcion ;
      private bool[] T000G7_A21MotivoRechazoActivo ;
      private string[] T000G8_A63UsuarioZona ;
      private string[] T000G8_A53UsuarioGenero ;
      private string[] T000G8_A30UsuarioNombre ;
      private string[] T000G8_A51UsuarioApellido ;
      private string[] T000G8_A31UsuarioCorreo ;
      private string[] T000G8_A32UsuarioPass ;
      private string[] T000G8_A33UsuarioKey ;
      private string[] T000G8_A54UsuarioDirectoAsociado ;
      private bool[] T000G8_n54UsuarioDirectoAsociado ;
      private string[] T000G8_A55UsuarioRazonSocialAsociado ;
      private string[] T000G8_A56UsuarioNombreComercial ;
      private DateTime[] T000G8_A57UsuarioFechaNacimiento ;
      private bool[] T000G8_n57UsuarioFechaNacimiento ;
      private string[] T000G8_A59UsuarioCalleNum ;
      private string[] T000G8_A60UsuarioColonia ;
      private string[] T000G8_A61UsuarioDelegacion ;
      private int[] T000G8_A62UsuarioCP ;
      private long[] T000G8_A64UsuarioCelular ;
      private long[] T000G8_A65UsuarioTelefonoSucursal ;
      private string[] T000G8_A66UsuarioSucursal ;
      private string[] T000G8_A67UsuarioProducto ;
      private bool[] T000G8_n67UsuarioProducto ;
      private string[] T000G8_A40UsuarioRol ;
      private string[] T000G8_A82UsuarioNoCuentaBROXEL ;
      private string[] T000G8_A83UsuarioReferenciaBROXEL ;
      private int[] T000G8_A13PuestoID ;
      private bool[] T000G8_n13PuestoID ;
      private int[] T000G8_A4CiudadID ;
      private bool[] T000G8_n4CiudadID ;
      private string[] T000G9_A14PuestoDescripcion ;
      private string[] T000G10_A5CiudadDescripcion ;
      private int[] T000G10_A1EstadoID ;
      private string[] T000G11_A2EstadoDescripcion ;
      private int[] T000G11_A16PaisID ;
      private string[] T000G12_A17PaisDescripcion ;
      private string[] T000G5_A28MedidaDescripcion ;
      private string[] T000G5_A74MedidaRin ;
      private string[] T000G5_A27MedidaCodigo ;
      private int[] T000G5_A22ModeloID ;
      private string[] T000G13_A23ModeloDescripcion ;
      private string[] T000G15_A71FacturaNo ;
      private DateTime[] T000G15_A73FacturaFechaFactura ;
      private DateTime[] T000G15_A72FacturaFechaRegistro ;
      private string[] T000G15_A40001FacturaPDF_GXI ;
      private string[] T000G15_A80FacturaEstatus ;
      private int[] T000G15_A41PromocionID ;
      private int[] T000G15_A19MotivoRechazoID ;
      private int[] T000G15_A29UsuarioID ;
      private string[] T000G15_A75FacturaPDF ;
      private string[] T000G16_A42PromocionDescripcion ;
      private string[] T000G16_A43PromocionBase ;
      private string[] T000G16_A40000PromocionArte_GXI ;
      private DateTime[] T000G16_A45PromocionFechaInicio ;
      private DateTime[] T000G16_A46PromocionFechaFin ;
      private string[] T000G16_A44PromocionArte ;
      private string[] T000G17_A20MotivoRechazoDescripcion ;
      private bool[] T000G17_A21MotivoRechazoActivo ;
      private string[] T000G18_A63UsuarioZona ;
      private string[] T000G18_A53UsuarioGenero ;
      private string[] T000G18_A30UsuarioNombre ;
      private string[] T000G18_A51UsuarioApellido ;
      private string[] T000G18_A31UsuarioCorreo ;
      private string[] T000G18_A32UsuarioPass ;
      private string[] T000G18_A33UsuarioKey ;
      private string[] T000G18_A54UsuarioDirectoAsociado ;
      private bool[] T000G18_n54UsuarioDirectoAsociado ;
      private string[] T000G18_A55UsuarioRazonSocialAsociado ;
      private string[] T000G18_A56UsuarioNombreComercial ;
      private DateTime[] T000G18_A57UsuarioFechaNacimiento ;
      private bool[] T000G18_n57UsuarioFechaNacimiento ;
      private string[] T000G18_A59UsuarioCalleNum ;
      private string[] T000G18_A60UsuarioColonia ;
      private string[] T000G18_A61UsuarioDelegacion ;
      private int[] T000G18_A62UsuarioCP ;
      private long[] T000G18_A64UsuarioCelular ;
      private long[] T000G18_A65UsuarioTelefonoSucursal ;
      private string[] T000G18_A66UsuarioSucursal ;
      private string[] T000G18_A67UsuarioProducto ;
      private bool[] T000G18_n67UsuarioProducto ;
      private string[] T000G18_A40UsuarioRol ;
      private string[] T000G18_A82UsuarioNoCuentaBROXEL ;
      private string[] T000G18_A83UsuarioReferenciaBROXEL ;
      private int[] T000G18_A13PuestoID ;
      private bool[] T000G18_n13PuestoID ;
      private int[] T000G18_A4CiudadID ;
      private bool[] T000G18_n4CiudadID ;
      private string[] T000G19_A14PuestoDescripcion ;
      private string[] T000G20_A5CiudadDescripcion ;
      private int[] T000G20_A1EstadoID ;
      private string[] T000G21_A2EstadoDescripcion ;
      private int[] T000G21_A16PaisID ;
      private string[] T000G22_A17PaisDescripcion ;
      private string[] T000G23_A28MedidaDescripcion ;
      private string[] T000G23_A74MedidaRin ;
      private string[] T000G23_A27MedidaCodigo ;
      private int[] T000G23_A22ModeloID ;
      private string[] T000G24_A23ModeloDescripcion ;
      private int[] T000G25_A77FacturaMedidaID ;
      private int[] T000G3_A77FacturaMedidaID ;
      private short[] T000G3_A78FacturaMedidaCantidad ;
      private decimal[] T000G3_A79FacturaMedidaPrecio ;
      private int[] T000G3_A69FacturaID ;
      private int[] T000G3_A26MedidaID ;
      private int[] T000G26_A77FacturaMedidaID ;
      private int[] T000G27_A77FacturaMedidaID ;
      private int[] T000G2_A77FacturaMedidaID ;
      private short[] T000G2_A78FacturaMedidaCantidad ;
      private decimal[] T000G2_A79FacturaMedidaPrecio ;
      private int[] T000G2_A69FacturaID ;
      private int[] T000G2_A26MedidaID ;
      private int[] T000G29_A77FacturaMedidaID ;
      private string[] T000G32_A71FacturaNo ;
      private DateTime[] T000G32_A73FacturaFechaFactura ;
      private DateTime[] T000G32_A72FacturaFechaRegistro ;
      private string[] T000G32_A40001FacturaPDF_GXI ;
      private string[] T000G32_A80FacturaEstatus ;
      private int[] T000G32_A41PromocionID ;
      private int[] T000G32_A19MotivoRechazoID ;
      private int[] T000G32_A29UsuarioID ;
      private string[] T000G32_A75FacturaPDF ;
      private string[] T000G33_A42PromocionDescripcion ;
      private string[] T000G33_A43PromocionBase ;
      private string[] T000G33_A40000PromocionArte_GXI ;
      private DateTime[] T000G33_A45PromocionFechaInicio ;
      private DateTime[] T000G33_A46PromocionFechaFin ;
      private string[] T000G33_A44PromocionArte ;
      private string[] T000G34_A20MotivoRechazoDescripcion ;
      private bool[] T000G34_A21MotivoRechazoActivo ;
      private string[] T000G35_A63UsuarioZona ;
      private string[] T000G35_A53UsuarioGenero ;
      private string[] T000G35_A30UsuarioNombre ;
      private string[] T000G35_A51UsuarioApellido ;
      private string[] T000G35_A31UsuarioCorreo ;
      private string[] T000G35_A32UsuarioPass ;
      private string[] T000G35_A33UsuarioKey ;
      private string[] T000G35_A54UsuarioDirectoAsociado ;
      private bool[] T000G35_n54UsuarioDirectoAsociado ;
      private string[] T000G35_A55UsuarioRazonSocialAsociado ;
      private string[] T000G35_A56UsuarioNombreComercial ;
      private DateTime[] T000G35_A57UsuarioFechaNacimiento ;
      private bool[] T000G35_n57UsuarioFechaNacimiento ;
      private string[] T000G35_A59UsuarioCalleNum ;
      private string[] T000G35_A60UsuarioColonia ;
      private string[] T000G35_A61UsuarioDelegacion ;
      private int[] T000G35_A62UsuarioCP ;
      private long[] T000G35_A64UsuarioCelular ;
      private long[] T000G35_A65UsuarioTelefonoSucursal ;
      private string[] T000G35_A66UsuarioSucursal ;
      private string[] T000G35_A67UsuarioProducto ;
      private bool[] T000G35_n67UsuarioProducto ;
      private string[] T000G35_A40UsuarioRol ;
      private string[] T000G35_A82UsuarioNoCuentaBROXEL ;
      private string[] T000G35_A83UsuarioReferenciaBROXEL ;
      private int[] T000G35_A13PuestoID ;
      private bool[] T000G35_n13PuestoID ;
      private int[] T000G35_A4CiudadID ;
      private bool[] T000G35_n4CiudadID ;
      private string[] T000G36_A14PuestoDescripcion ;
      private string[] T000G37_A5CiudadDescripcion ;
      private int[] T000G37_A1EstadoID ;
      private string[] T000G38_A2EstadoDescripcion ;
      private int[] T000G38_A16PaisID ;
      private string[] T000G39_A17PaisDescripcion ;
      private string[] T000G40_A28MedidaDescripcion ;
      private string[] T000G40_A74MedidaRin ;
      private string[] T000G40_A27MedidaCodigo ;
      private int[] T000G40_A22ModeloID ;
      private string[] T000G41_A23ModeloDescripcion ;
      private int[] T000G42_A77FacturaMedidaID ;
   }

   public class facturamedida__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new UpdateCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new UpdateCursor(def[28])
         ,new UpdateCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
         ,new ForEachCursor(def[36])
         ,new ForEachCursor(def[37])
         ,new ForEachCursor(def[38])
         ,new ForEachCursor(def[39])
         ,new ForEachCursor(def[40])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000G2;
          prmT000G2 = new Object[] {
          new ParDef("@FacturaMedidaID",GXType.Int32,9,0)
          };
          Object[] prmT000G3;
          prmT000G3 = new Object[] {
          new ParDef("@FacturaMedidaID",GXType.Int32,9,0)
          };
          Object[] prmT000G4;
          prmT000G4 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmT000G5;
          prmT000G5 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmT000G6;
          prmT000G6 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000G7;
          prmT000G7 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmT000G8;
          prmT000G8 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000G9;
          prmT000G9 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000G10;
          prmT000G10 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000G11;
          prmT000G11 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000G12;
          prmT000G12 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT000G13;
          prmT000G13 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000G14;
          prmT000G14 = new Object[] {
          new ParDef("@FacturaMedidaID",GXType.Int32,9,0)
          };
          string cmdBufferT000G14;
          cmdBufferT000G14=" SELECT TM1.`FacturaMedidaID`, T3.`PromocionDescripcion`, T3.`PromocionBase`, T3.`PromocionArte_GXI`, T2.`FacturaNo`, T2.`FacturaFechaFactura`, T2.`FacturaFechaRegistro`, T5.`UsuarioZona`, T8.`EstadoDescripcion`, T7.`CiudadDescripcion`, T9.`PaisDescripcion`, T5.`UsuarioGenero`, T2.`FacturaPDF_GXI`, T2.`FacturaEstatus`, T4.`MotivoRechazoDescripcion`, T4.`MotivoRechazoActivo`, T10.`MedidaDescripcion`, T10.`MedidaRin`, T10.`MedidaCodigo`, T11.`ModeloDescripcion`, TM1.`FacturaMedidaCantidad`, TM1.`FacturaMedidaPrecio`, T5.`UsuarioNombre`, T5.`UsuarioApellido`, T5.`UsuarioCorreo`, T5.`UsuarioPass`, T5.`UsuarioKey`, T6.`PuestoDescripcion`, T5.`UsuarioDirectoAsociado`, T5.`UsuarioRazonSocialAsociado`, T5.`UsuarioNombreComercial`, T5.`UsuarioFechaNacimiento`, T5.`UsuarioCalleNum`, T5.`UsuarioColonia`, T5.`UsuarioDelegacion`, T5.`UsuarioCP`, T5.`UsuarioCelular`, T5.`UsuarioTelefonoSucursal`, T5.`UsuarioSucursal`, T5.`UsuarioProducto`, T5.`UsuarioRol`, T5.`UsuarioNoCuentaBROXEL`, T5.`UsuarioReferenciaBROXEL`, T3.`PromocionFechaInicio`, T3.`PromocionFechaFin`, TM1.`FacturaID`, TM1.`MedidaID`, T2.`PromocionID`, T2.`MotivoRechazoID`, T2.`UsuarioID`, T5.`PuestoID`, T5.`CiudadID`, T7.`EstadoID`, T8.`PaisID`, T10.`ModeloID`, T3.`PromocionArte`, T2.`FacturaPDF` FROM ((((((((((`FacturaMedida` TM1 INNER JOIN `Factura` T2 ON T2.`FacturaID` = TM1.`FacturaID`) INNER JOIN `Promocion` T3 ON T3.`PromocionID` = T2.`PromocionID`) INNER JOIN `MotivoRechazo` T4 ON T4.`MotivoRechazoID` = T2.`MotivoRechazoID`) INNER JOIN `Usuario` T5 ON T5.`UsuarioID` = T2.`UsuarioID`) LEFT JOIN `Puesto` T6 ON T6.`PuestoID` = T5.`PuestoID`) LEFT JOIN `Ciudad` T7 ON T7.`CiudadID` = T5.`CiudadID`) LEFT JOIN `Estado` T8 ON T8.`EstadoID` = T7.`EstadoID`) LEFT JOIN `Pais` T9 ON T9.`PaisID` = T8.`PaisID`) INNER JOIN `Medida` "
          + " T10 ON T10.`MedidaID` = TM1.`MedidaID`) INNER JOIN `Modelo` T11 ON T11.`ModeloID` = T10.`ModeloID`) WHERE TM1.`FacturaMedidaID` = @FacturaMedidaID ORDER BY TM1.`FacturaMedidaID`" ;
          Object[] prmT000G15;
          prmT000G15 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmT000G16;
          prmT000G16 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000G17;
          prmT000G17 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmT000G18;
          prmT000G18 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000G19;
          prmT000G19 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000G20;
          prmT000G20 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000G21;
          prmT000G21 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000G22;
          prmT000G22 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT000G23;
          prmT000G23 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmT000G24;
          prmT000G24 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000G25;
          prmT000G25 = new Object[] {
          new ParDef("@FacturaMedidaID",GXType.Int32,9,0)
          };
          Object[] prmT000G26;
          prmT000G26 = new Object[] {
          new ParDef("@FacturaMedidaID",GXType.Int32,9,0)
          };
          Object[] prmT000G27;
          prmT000G27 = new Object[] {
          new ParDef("@FacturaMedidaID",GXType.Int32,9,0)
          };
          Object[] prmT000G28;
          prmT000G28 = new Object[] {
          new ParDef("@FacturaMedidaCantidad",GXType.Int16,4,0) ,
          new ParDef("@FacturaMedidaPrecio",GXType.Number,10,2) ,
          new ParDef("@FacturaID",GXType.Int32,9,0) ,
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmT000G29;
          prmT000G29 = new Object[] {
          };
          Object[] prmT000G30;
          prmT000G30 = new Object[] {
          new ParDef("@FacturaMedidaCantidad",GXType.Int16,4,0) ,
          new ParDef("@FacturaMedidaPrecio",GXType.Number,10,2) ,
          new ParDef("@FacturaID",GXType.Int32,9,0) ,
          new ParDef("@MedidaID",GXType.Int32,9,0) ,
          new ParDef("@FacturaMedidaID",GXType.Int32,9,0)
          };
          Object[] prmT000G31;
          prmT000G31 = new Object[] {
          new ParDef("@FacturaMedidaID",GXType.Int32,9,0)
          };
          Object[] prmT000G32;
          prmT000G32 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmT000G33;
          prmT000G33 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000G34;
          prmT000G34 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmT000G35;
          prmT000G35 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000G36;
          prmT000G36 = new Object[] {
          new ParDef("@PuestoID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000G37;
          prmT000G37 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000G38;
          prmT000G38 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000G39;
          prmT000G39 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT000G40;
          prmT000G40 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmT000G41;
          prmT000G41 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000G42;
          prmT000G42 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000G2", "SELECT `FacturaMedidaID`, `FacturaMedidaCantidad`, `FacturaMedidaPrecio`, `FacturaID`, `MedidaID` FROM `FacturaMedida` WHERE `FacturaMedidaID` = @FacturaMedidaID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G3", "SELECT `FacturaMedidaID`, `FacturaMedidaCantidad`, `FacturaMedidaPrecio`, `FacturaID`, `MedidaID` FROM `FacturaMedida` WHERE `FacturaMedidaID` = @FacturaMedidaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G4", "SELECT `FacturaNo`, `FacturaFechaFactura`, `FacturaFechaRegistro`, `FacturaPDF_GXI`, `FacturaEstatus`, `PromocionID`, `MotivoRechazoID`, `UsuarioID`, `FacturaPDF` FROM `Factura` WHERE `FacturaID` = @FacturaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G5", "SELECT `MedidaDescripcion`, `MedidaRin`, `MedidaCodigo`, `ModeloID` FROM `Medida` WHERE `MedidaID` = @MedidaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G6", "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G7", "SELECT `MotivoRechazoDescripcion`, `MotivoRechazoActivo` FROM `MotivoRechazo` WHERE `MotivoRechazoID` = @MotivoRechazoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G8", "SELECT `UsuarioZona`, `UsuarioGenero`, `UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `UsuarioNoCuentaBROXEL`, `UsuarioReferenciaBROXEL`, `PuestoID`, `CiudadID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G9", "SELECT `PuestoDescripcion` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G10", "SELECT `CiudadDescripcion`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G11", "SELECT `EstadoDescripcion`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G12", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G13", "SELECT `ModeloDescripcion` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G14", cmdBufferT000G14,true, GxErrorMask.GX_NOMASK, false, this,prmT000G14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G15", "SELECT `FacturaNo`, `FacturaFechaFactura`, `FacturaFechaRegistro`, `FacturaPDF_GXI`, `FacturaEstatus`, `PromocionID`, `MotivoRechazoID`, `UsuarioID`, `FacturaPDF` FROM `Factura` WHERE `FacturaID` = @FacturaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G16", "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G17", "SELECT `MotivoRechazoDescripcion`, `MotivoRechazoActivo` FROM `MotivoRechazo` WHERE `MotivoRechazoID` = @MotivoRechazoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G18", "SELECT `UsuarioZona`, `UsuarioGenero`, `UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `UsuarioNoCuentaBROXEL`, `UsuarioReferenciaBROXEL`, `PuestoID`, `CiudadID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G19", "SELECT `PuestoDescripcion` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G20", "SELECT `CiudadDescripcion`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G21", "SELECT `EstadoDescripcion`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G22", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G23", "SELECT `MedidaDescripcion`, `MedidaRin`, `MedidaCodigo`, `ModeloID` FROM `Medida` WHERE `MedidaID` = @MedidaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G24", "SELECT `ModeloDescripcion` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G24,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G25", "SELECT `FacturaMedidaID` FROM `FacturaMedida` WHERE `FacturaMedidaID` = @FacturaMedidaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G26", "SELECT `FacturaMedidaID` FROM `FacturaMedida` WHERE ( `FacturaMedidaID` > @FacturaMedidaID) ORDER BY `FacturaMedidaID`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000G26,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000G27", "SELECT `FacturaMedidaID` FROM `FacturaMedida` WHERE ( `FacturaMedidaID` < @FacturaMedidaID) ORDER BY `FacturaMedidaID` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000G27,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000G28", "INSERT INTO `FacturaMedida`(`FacturaMedidaCantidad`, `FacturaMedidaPrecio`, `FacturaID`, `MedidaID`) VALUES(@FacturaMedidaCantidad, @FacturaMedidaPrecio, @FacturaID, @MedidaID)", GxErrorMask.GX_NOMASK,prmT000G28)
             ,new CursorDef("T000G29", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G30", "UPDATE `FacturaMedida` SET `FacturaMedidaCantidad`=@FacturaMedidaCantidad, `FacturaMedidaPrecio`=@FacturaMedidaPrecio, `FacturaID`=@FacturaID, `MedidaID`=@MedidaID  WHERE `FacturaMedidaID` = @FacturaMedidaID", GxErrorMask.GX_NOMASK,prmT000G30)
             ,new CursorDef("T000G31", "DELETE FROM `FacturaMedida`  WHERE `FacturaMedidaID` = @FacturaMedidaID", GxErrorMask.GX_NOMASK,prmT000G31)
             ,new CursorDef("T000G32", "SELECT `FacturaNo`, `FacturaFechaFactura`, `FacturaFechaRegistro`, `FacturaPDF_GXI`, `FacturaEstatus`, `PromocionID`, `MotivoRechazoID`, `UsuarioID`, `FacturaPDF` FROM `Factura` WHERE `FacturaID` = @FacturaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G32,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G33", "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G33,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G34", "SELECT `MotivoRechazoDescripcion`, `MotivoRechazoActivo` FROM `MotivoRechazo` WHERE `MotivoRechazoID` = @MotivoRechazoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G34,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G35", "SELECT `UsuarioZona`, `UsuarioGenero`, `UsuarioNombre`, `UsuarioApellido`, `UsuarioCorreo`, `UsuarioPass`, `UsuarioKey`, `UsuarioDirectoAsociado`, `UsuarioRazonSocialAsociado`, `UsuarioNombreComercial`, `UsuarioFechaNacimiento`, `UsuarioCalleNum`, `UsuarioColonia`, `UsuarioDelegacion`, `UsuarioCP`, `UsuarioCelular`, `UsuarioTelefonoSucursal`, `UsuarioSucursal`, `UsuarioProducto`, `UsuarioRol`, `UsuarioNoCuentaBROXEL`, `UsuarioReferenciaBROXEL`, `PuestoID`, `CiudadID` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G35,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G36", "SELECT `PuestoDescripcion` FROM `Puesto` WHERE `PuestoID` = @PuestoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G36,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G37", "SELECT `CiudadDescripcion`, `EstadoID` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G37,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G38", "SELECT `EstadoDescripcion`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G38,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G39", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G39,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G40", "SELECT `MedidaDescripcion`, `MedidaRin`, `MedidaCodigo`, `ModeloID` FROM `Medida` WHERE `MedidaID` = @MedidaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G40,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G41", "SELECT `ModeloDescripcion` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G41,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G42", "SELECT `FacturaMedidaID` FROM `FacturaMedida` ORDER BY `FacturaMedidaID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G42,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
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
                ((long[]) buf[17])[0] = rslt.getLong(16);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 20);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((string[]) buf[22])[0] = rslt.getString(20, 40);
                ((string[]) buf[23])[0] = rslt.getString(21, 20);
                ((string[]) buf[24])[0] = rslt.getString(22, 20);
                ((int[]) buf[25])[0] = rslt.getInt(23);
                ((bool[]) buf[26])[0] = rslt.wasNull(23);
                ((int[]) buf[27])[0] = rslt.getInt(24);
                ((bool[]) buf[28])[0] = rslt.wasNull(24);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 30);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((string[]) buf[12])[0] = rslt.getMultimediaUri(13);
                ((string[]) buf[13])[0] = rslt.getString(14, 20);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((bool[]) buf[15])[0] = rslt.getBool(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                ((string[]) buf[17])[0] = rslt.getString(18, 20);
                ((string[]) buf[18])[0] = rslt.getString(19, 20);
                ((string[]) buf[19])[0] = rslt.getVarchar(20);
                ((short[]) buf[20])[0] = rslt.getShort(21);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(22);
                ((string[]) buf[22])[0] = rslt.getString(23, 50);
                ((string[]) buf[23])[0] = rslt.getString(24, 50);
                ((string[]) buf[24])[0] = rslt.getVarchar(25);
                ((string[]) buf[25])[0] = rslt.getVarchar(26);
                ((string[]) buf[26])[0] = rslt.getVarchar(27);
                ((string[]) buf[27])[0] = rslt.getVarchar(28);
                ((string[]) buf[28])[0] = rslt.getString(29, 20);
                ((bool[]) buf[29])[0] = rslt.wasNull(29);
                ((string[]) buf[30])[0] = rslt.getVarchar(30);
                ((string[]) buf[31])[0] = rslt.getVarchar(31);
                ((DateTime[]) buf[32])[0] = rslt.getGXDate(32);
                ((bool[]) buf[33])[0] = rslt.wasNull(32);
                ((string[]) buf[34])[0] = rslt.getString(33, 40);
                ((string[]) buf[35])[0] = rslt.getString(34, 20);
                ((string[]) buf[36])[0] = rslt.getString(35, 20);
                ((int[]) buf[37])[0] = rslt.getInt(36);
                ((long[]) buf[38])[0] = rslt.getLong(37);
                ((long[]) buf[39])[0] = rslt.getLong(38);
                ((string[]) buf[40])[0] = rslt.getString(39, 20);
                ((string[]) buf[41])[0] = rslt.getVarchar(40);
                ((bool[]) buf[42])[0] = rslt.wasNull(40);
                ((string[]) buf[43])[0] = rslt.getString(41, 40);
                ((string[]) buf[44])[0] = rslt.getString(42, 20);
                ((string[]) buf[45])[0] = rslt.getString(43, 20);
                ((DateTime[]) buf[46])[0] = rslt.getGXDate(44);
                ((DateTime[]) buf[47])[0] = rslt.getGXDate(45);
                ((int[]) buf[48])[0] = rslt.getInt(46);
                ((int[]) buf[49])[0] = rslt.getInt(47);
                ((int[]) buf[50])[0] = rslt.getInt(48);
                ((int[]) buf[51])[0] = rslt.getInt(49);
                ((int[]) buf[52])[0] = rslt.getInt(50);
                ((int[]) buf[53])[0] = rslt.getInt(51);
                ((bool[]) buf[54])[0] = rslt.wasNull(51);
                ((int[]) buf[55])[0] = rslt.getInt(52);
                ((bool[]) buf[56])[0] = rslt.wasNull(52);
                ((int[]) buf[57])[0] = rslt.getInt(53);
                ((int[]) buf[58])[0] = rslt.getInt(54);
                ((int[]) buf[59])[0] = rslt.getInt(55);
                ((string[]) buf[60])[0] = rslt.getMultimediaFile(56, rslt.getVarchar(4));
                ((string[]) buf[61])[0] = rslt.getMultimediaFile(57, rslt.getVarchar(13));
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
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
                ((long[]) buf[17])[0] = rslt.getLong(16);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 20);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((string[]) buf[22])[0] = rslt.getString(20, 40);
                ((string[]) buf[23])[0] = rslt.getString(21, 20);
                ((string[]) buf[24])[0] = rslt.getString(22, 20);
                ((int[]) buf[25])[0] = rslt.getInt(23);
                ((bool[]) buf[26])[0] = rslt.wasNull(23);
                ((int[]) buf[27])[0] = rslt.getInt(24);
                ((bool[]) buf[28])[0] = rslt.wasNull(24);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 25 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 27 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
                return;
             case 31 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 32 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
             case 33 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
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
                ((long[]) buf[17])[0] = rslt.getLong(16);
                ((long[]) buf[18])[0] = rslt.getLong(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 20);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((string[]) buf[22])[0] = rslt.getString(20, 40);
                ((string[]) buf[23])[0] = rslt.getString(21, 20);
                ((string[]) buf[24])[0] = rslt.getString(22, 20);
                ((int[]) buf[25])[0] = rslt.getInt(23);
                ((bool[]) buf[26])[0] = rslt.wasNull(23);
                ((int[]) buf[27])[0] = rslt.getInt(24);
                ((bool[]) buf[28])[0] = rslt.wasNull(24);
                return;
             case 34 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 35 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 36 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 37 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 38 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 39 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 40 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
