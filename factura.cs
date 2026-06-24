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
   public class factura : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A41PromocionID = (int)(Math.Round(NumberUtil.Val( GetPar( "PromocionID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A41PromocionID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A29UsuarioID = (int)(Math.Round(NumberUtil.Val( GetPar( "UsuarioID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A29UsuarioID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
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
            gxLoad_12( A4CiudadID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A1EstadoID = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadoID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A1EstadoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A16PaisID = (int)(Math.Round(NumberUtil.Val( GetPar( "PaisID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A16PaisID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A19MotivoRechazoID = (int)(Math.Round(NumberUtil.Val( GetPar( "MotivoRechazoID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrimStr( (decimal)(A19MotivoRechazoID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A19MotivoRechazoID) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Factura", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFacturaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public factura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public factura( IGxContext context )
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
         chkFacturaCompleta = new GXCheckbox();
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
         A93FacturaCompleta = StringUtil.StrToBool( StringUtil.BoolToStr( A93FacturaCompleta));
         AssignAttri("", false, "A93FacturaCompleta", A93FacturaCompleta);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Factura", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Factura.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Factura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Factura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Factura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Factura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Factura.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFacturaID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFacturaID_Internalname, context.GetMessage( "ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFacturaID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtFacturaID_Enabled!=0) ? context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A69FacturaID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFacturaID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFacturaID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Factura.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPromocionID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPromocionID_Enabled!=0) ? context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocionID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Factura.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPromocionDescripcion_Internalname, A42PromocionDescripcion, StringUtil.RTrim( context.localUtil.Format( A42PromocionDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocionDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Factura.htm");
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
         GxWebStd.gx_html_textarea( context, edtPromocionBase_Internalname, A43PromocionBase, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtPromocionBase_Enabled, 0, 80, "chr", 9, "row", 0, StyleString, ClassString, "", "", "700", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Factura.htm");
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
         GxWebStd.gx_bitmap( context, imgPromocionArte_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgPromocionArte_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", "", "", 0, A44PromocionArte_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Factura.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPromocionVigencia_Internalname, A70PromocionVigencia, StringUtil.RTrim( context.localUtil.Format( A70PromocionVigencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionVigencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocionVigencia_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Factura.htm");
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
         GxWebStd.gx_label_element( context, edtFacturaNo_Internalname, context.GetMessage( "No", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFacturaNo_Internalname, StringUtil.RTrim( A71FacturaNo), StringUtil.RTrim( context.localUtil.Format( A71FacturaNo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFacturaNo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFacturaNo_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Factura.htm");
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
         GxWebStd.gx_label_element( context, edtFacturaFechaFactura_Internalname, context.GetMessage( "Fecha Factura", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFacturaFechaFactura_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFacturaFechaFactura_Internalname, context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"), context.localUtil.Format( A73FacturaFechaFactura, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFacturaFechaFactura_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFacturaFechaFactura_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Factura.htm");
         GxWebStd.gx_bitmap( context, edtFacturaFechaFactura_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFacturaFechaFactura_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Factura.htm");
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
         GxWebStd.gx_label_element( context, edtFacturaFechaRegistro_Internalname, context.GetMessage( "Fecha Registro", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFacturaFechaRegistro_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFacturaFechaRegistro_Internalname, context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"), context.localUtil.Format( A72FacturaFechaRegistro, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFacturaFechaRegistro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFacturaFechaRegistro_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Factura.htm");
         GxWebStd.gx_bitmap( context, edtFacturaFechaRegistro_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFacturaFechaRegistro_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Factura.htm");
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
         GxWebStd.gx_single_line_edit( context, edtUsuarioID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioID_Enabled!=0) ? context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A29UsuarioID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Factura.htm");
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
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombreCompleto_Internalname, A52UsuarioNombreCompleto, StringUtil.RTrim( context.localUtil.Format( A52UsuarioNombreCompleto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombreCompleto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNombreCompleto_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Factura.htm");
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
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioZona, cmbUsuarioZona_Internalname, StringUtil.RTrim( A63UsuarioZona), 1, cmbUsuarioZona_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioZona.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 0, "HLP_Factura.htm");
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
         GxWebStd.gx_single_line_edit( context, edtEstadoDescripcion_Internalname, A2EstadoDescripcion, StringUtil.RTrim( context.localUtil.Format( A2EstadoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstadoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Factura.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCiudadDescripcion_Internalname, A5CiudadDescripcion, StringUtil.RTrim( context.localUtil.Format( A5CiudadDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCiudadDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCiudadDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Factura.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPaisDescripcion_Internalname, A17PaisDescripcion, StringUtil.RTrim( context.localUtil.Format( A17PaisDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Factura.htm");
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
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioGenero, cmbUsuarioGenero_Internalname, StringUtil.RTrim( A53UsuarioGenero), 1, cmbUsuarioGenero_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbUsuarioGenero.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "", true, 0, "HLP_Factura.htm");
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
         GxWebStd.gx_label_element( context, edtFacturaPDF_Internalname, context.GetMessage( "PDF", ""), "col-sm-3 DownloadAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* BinaryFile Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         ClassString = "DownloadAttribute";
         StyleString = "";
         A75FacturaPDF_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001FacturaPDF_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)));
         GxWebStd.gx_file( context, edtFacturaPDF_Internalname, (String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)) ? A40001FacturaPDF_GXI : context.PathToRelativeUrl( A75FacturaPDF)), edtFacturaPDF_Filename, 1, 1, edtFacturaPDF_Enabled, 0, 0, "", 0, "", 0, "", "", StyleString, ClassString, "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "", "", 0, A75FacturaPDF_IsBlob, "HLP_Factura.htm");
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
         GxWebStd.gx_label_element( context, cmbFacturaEstatus_Internalname, context.GetMessage( "Estatus", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbFacturaEstatus, cmbFacturaEstatus_Internalname, StringUtil.RTrim( A80FacturaEstatus), 1, cmbFacturaEstatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbFacturaEstatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "", true, 0, "HLP_Factura.htm");
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
         GxWebStd.gx_single_line_edit( context, edtMotivoRechazoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MotivoRechazoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtMotivoRechazoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A19MotivoRechazoID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A19MotivoRechazoID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMotivoRechazoID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMotivoRechazoID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Factura.htm");
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
         GxWebStd.gx_single_line_edit( context, edtMotivoRechazoDescripcion_Internalname, A20MotivoRechazoDescripcion, StringUtil.RTrim( context.localUtil.Format( A20MotivoRechazoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMotivoRechazoDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMotivoRechazoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Factura.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkFacturaCompleta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkFacturaCompleta_Internalname, context.GetMessage( "Completa", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkFacturaCompleta_Internalname, StringUtil.BoolToStr( A93FacturaCompleta), "", context.GetMessage( "Completa", ""), 1, chkFacturaCompleta.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(139, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,139);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Factura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Factura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Factura.htm");
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
            Z69FacturaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z69FacturaID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z71FacturaNo = cgiGet( "Z71FacturaNo");
            Z73FacturaFechaFactura = context.localUtil.CToD( cgiGet( "Z73FacturaFechaFactura"), 0);
            Z72FacturaFechaRegistro = context.localUtil.CToD( cgiGet( "Z72FacturaFechaRegistro"), 0);
            Z80FacturaEstatus = cgiGet( "Z80FacturaEstatus");
            Z93FacturaCompleta = StringUtil.StrToBool( cgiGet( "Z93FacturaCompleta"));
            Z41PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z41PromocionID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z19MotivoRechazoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z19MotivoRechazoID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z29UsuarioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z29UsuarioID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A30UsuarioNombre = cgiGet( "USUARIONOMBRE");
            A51UsuarioApellido = cgiGet( "USUARIOAPELLIDO");
            A45PromocionFechaInicio = context.localUtil.CToD( cgiGet( "PROMOCIONFECHAINICIO"), 0);
            A46PromocionFechaFin = context.localUtil.CToD( cgiGet( "PROMOCIONFECHAFIN"), 0);
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A40001FacturaPDF_GXI = cgiGet( "FACTURAPDF_GXI");
            A40000PromocionArte_GXI = cgiGet( "PROMOCIONARTE_GXI");
            A4CiudadID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CIUDADID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A1EstadoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A16PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAISID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtPromocionID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPromocionID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROMOCIONID");
               AnyError = 1;
               GX_FocusControl = edtPromocionID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A41PromocionID = 0;
               AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            }
            else
            {
               A41PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPromocionID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
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
            if ( context.localUtil.VCDate( cgiGet( edtFacturaFechaFactura_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Factura Fecha Factura", "")}), 1, "FACTURAFECHAFACTURA");
               AnyError = 1;
               GX_FocusControl = edtFacturaFechaFactura_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A73FacturaFechaFactura = DateTime.MinValue;
               AssignAttri("", false, "A73FacturaFechaFactura", context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"));
            }
            else
            {
               A73FacturaFechaFactura = context.localUtil.CToD( cgiGet( edtFacturaFechaFactura_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "A73FacturaFechaFactura", context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtFacturaFechaRegistro_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Factura Fecha Registro", "")}), 1, "FACTURAFECHAREGISTRO");
               AnyError = 1;
               GX_FocusControl = edtFacturaFechaRegistro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A72FacturaFechaRegistro = DateTime.MinValue;
               AssignAttri("", false, "A72FacturaFechaRegistro", context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"));
            }
            else
            {
               A72FacturaFechaRegistro = context.localUtil.CToD( cgiGet( edtFacturaFechaRegistro_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "A72FacturaFechaRegistro", context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"));
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtMotivoRechazoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMotivoRechazoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MOTIVORECHAZOID");
               AnyError = 1;
               GX_FocusControl = edtMotivoRechazoID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A19MotivoRechazoID = 0;
               AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrimStr( (decimal)(A19MotivoRechazoID), 9, 0));
            }
            else
            {
               A19MotivoRechazoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMotivoRechazoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrimStr( (decimal)(A19MotivoRechazoID), 9, 0));
            }
            A20MotivoRechazoDescripcion = cgiGet( edtMotivoRechazoDescripcion_Internalname);
            AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
            A21MotivoRechazoActivo = StringUtil.StrToBool( cgiGet( chkMotivoRechazoActivo_Internalname));
            AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
            A93FacturaCompleta = StringUtil.StrToBool( cgiGet( chkFacturaCompleta_Internalname));
            AssignAttri("", false, "A93FacturaCompleta", A93FacturaCompleta);
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
               A69FacturaID = (int)(Math.Round(NumberUtil.Val( GetPar( "FacturaID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
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
               InitAll0F15( ) ;
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
         DisableAttributes0F15( ) ;
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

      protected void ResetCaption0F0( )
      {
      }

      protected void ZM0F15( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z71FacturaNo = T000F3_A71FacturaNo[0];
               Z73FacturaFechaFactura = T000F3_A73FacturaFechaFactura[0];
               Z72FacturaFechaRegistro = T000F3_A72FacturaFechaRegistro[0];
               Z80FacturaEstatus = T000F3_A80FacturaEstatus[0];
               Z93FacturaCompleta = T000F3_A93FacturaCompleta[0];
               Z41PromocionID = T000F3_A41PromocionID[0];
               Z19MotivoRechazoID = T000F3_A19MotivoRechazoID[0];
               Z29UsuarioID = T000F3_A29UsuarioID[0];
            }
            else
            {
               Z71FacturaNo = A71FacturaNo;
               Z73FacturaFechaFactura = A73FacturaFechaFactura;
               Z72FacturaFechaRegistro = A72FacturaFechaRegistro;
               Z80FacturaEstatus = A80FacturaEstatus;
               Z93FacturaCompleta = A93FacturaCompleta;
               Z41PromocionID = A41PromocionID;
               Z19MotivoRechazoID = A19MotivoRechazoID;
               Z29UsuarioID = A29UsuarioID;
            }
         }
         if ( GX_JID == -8 )
         {
            Z69FacturaID = A69FacturaID;
            Z71FacturaNo = A71FacturaNo;
            Z73FacturaFechaFactura = A73FacturaFechaFactura;
            Z72FacturaFechaRegistro = A72FacturaFechaRegistro;
            Z75FacturaPDF = A75FacturaPDF;
            Z40001FacturaPDF_GXI = A40001FacturaPDF_GXI;
            Z80FacturaEstatus = A80FacturaEstatus;
            Z93FacturaCompleta = A93FacturaCompleta;
            Z41PromocionID = A41PromocionID;
            Z19MotivoRechazoID = A19MotivoRechazoID;
            Z29UsuarioID = A29UsuarioID;
            Z42PromocionDescripcion = A42PromocionDescripcion;
            Z43PromocionBase = A43PromocionBase;
            Z44PromocionArte = A44PromocionArte;
            Z40000PromocionArte_GXI = A40000PromocionArte_GXI;
            Z45PromocionFechaInicio = A45PromocionFechaInicio;
            Z46PromocionFechaFin = A46PromocionFechaFin;
            Z4CiudadID = A4CiudadID;
            Z63UsuarioZona = A63UsuarioZona;
            Z53UsuarioGenero = A53UsuarioGenero;
            Z30UsuarioNombre = A30UsuarioNombre;
            Z51UsuarioApellido = A51UsuarioApellido;
            Z1EstadoID = A1EstadoID;
            Z5CiudadDescripcion = A5CiudadDescripcion;
            Z16PaisID = A16PaisID;
            Z2EstadoDescripcion = A2EstadoDescripcion;
            Z17PaisDescripcion = A17PaisDescripcion;
            Z20MotivoRechazoDescripcion = A20MotivoRechazoDescripcion;
            Z21MotivoRechazoActivo = A21MotivoRechazoActivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A93FacturaCompleta) && ( Gx_BScreen == 0 ) )
         {
            A93FacturaCompleta = false;
            AssignAttri("", false, "A93FacturaCompleta", A93FacturaCompleta);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A80FacturaEstatus)) && ( Gx_BScreen == 0 ) )
         {
            A80FacturaEstatus = "En Proceso";
            AssignAttri("", false, "A80FacturaEstatus", A80FacturaEstatus);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0F15( )
      {
         /* Using cursor T000F10 */
         pr_default.execute(8, new Object[] {A69FacturaID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound15 = 1;
            A4CiudadID = T000F10_A4CiudadID[0];
            n4CiudadID = T000F10_n4CiudadID[0];
            A1EstadoID = T000F10_A1EstadoID[0];
            A16PaisID = T000F10_A16PaisID[0];
            A42PromocionDescripcion = T000F10_A42PromocionDescripcion[0];
            AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
            A43PromocionBase = T000F10_A43PromocionBase[0];
            AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
            A40000PromocionArte_GXI = T000F10_A40000PromocionArte_GXI[0];
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            A71FacturaNo = T000F10_A71FacturaNo[0];
            AssignAttri("", false, "A71FacturaNo", A71FacturaNo);
            A73FacturaFechaFactura = T000F10_A73FacturaFechaFactura[0];
            AssignAttri("", false, "A73FacturaFechaFactura", context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"));
            A72FacturaFechaRegistro = T000F10_A72FacturaFechaRegistro[0];
            AssignAttri("", false, "A72FacturaFechaRegistro", context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"));
            A63UsuarioZona = T000F10_A63UsuarioZona[0];
            AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
            A2EstadoDescripcion = T000F10_A2EstadoDescripcion[0];
            AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
            A5CiudadDescripcion = T000F10_A5CiudadDescripcion[0];
            AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
            A17PaisDescripcion = T000F10_A17PaisDescripcion[0];
            AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
            A53UsuarioGenero = T000F10_A53UsuarioGenero[0];
            AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
            A40001FacturaPDF_GXI = T000F10_A40001FacturaPDF_GXI[0];
            A80FacturaEstatus = T000F10_A80FacturaEstatus[0];
            AssignAttri("", false, "A80FacturaEstatus", A80FacturaEstatus);
            A20MotivoRechazoDescripcion = T000F10_A20MotivoRechazoDescripcion[0];
            AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
            A21MotivoRechazoActivo = T000F10_A21MotivoRechazoActivo[0];
            AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
            A93FacturaCompleta = T000F10_A93FacturaCompleta[0];
            AssignAttri("", false, "A93FacturaCompleta", A93FacturaCompleta);
            A30UsuarioNombre = T000F10_A30UsuarioNombre[0];
            A51UsuarioApellido = T000F10_A51UsuarioApellido[0];
            A45PromocionFechaInicio = T000F10_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = T000F10_A46PromocionFechaFin[0];
            A41PromocionID = T000F10_A41PromocionID[0];
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            A19MotivoRechazoID = T000F10_A19MotivoRechazoID[0];
            AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrimStr( (decimal)(A19MotivoRechazoID), 9, 0));
            A29UsuarioID = T000F10_A29UsuarioID[0];
            AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
            A44PromocionArte = T000F10_A44PromocionArte[0];
            AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            A75FacturaPDF = T000F10_A75FacturaPDF[0];
            AssignAttri("", false, "A75FacturaPDF", A75FacturaPDF);
            AssignProp("", false, edtFacturaPDF_Internalname, "Multimedia", (String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)) ? A40001FacturaPDF_GXI : context.convertURL( context.PathToRelativeUrl( A75FacturaPDF))), true);
            ZM0F15( -8) ;
         }
         pr_default.close(8);
         OnLoadActions0F15( ) ;
      }

      protected void OnLoadActions0F15( )
      {
         A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         AssignAttri("", false, "A70PromocionVigencia", A70PromocionVigencia);
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
      }

      protected void CheckExtendedTable0F15( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000F4 */
         pr_default.execute(2, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
            GX_FocusControl = edtPromocionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A42PromocionDescripcion = T000F4_A42PromocionDescripcion[0];
         AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
         A43PromocionBase = T000F4_A43PromocionBase[0];
         AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
         A40000PromocionArte_GXI = T000F4_A40000PromocionArte_GXI[0];
         AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
         AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
         A45PromocionFechaInicio = T000F4_A45PromocionFechaInicio[0];
         A46PromocionFechaFin = T000F4_A46PromocionFechaFin[0];
         A44PromocionArte = T000F4_A44PromocionArte[0];
         AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
         AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
         AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
         pr_default.close(2);
         A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         AssignAttri("", false, "A70PromocionVigencia", A70PromocionVigencia);
         if ( ! ( (DateTime.MinValue==A73FacturaFechaFactura) || ( DateTimeUtil.ResetTime ( A73FacturaFechaFactura ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1000, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Factura Fecha Factura", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "FACTURAFECHAFACTURA");
            AnyError = 1;
            GX_FocusControl = edtFacturaFechaFactura_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A72FacturaFechaRegistro) || ( DateTimeUtil.ResetTime ( A72FacturaFechaRegistro ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1000, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Factura Fecha Registro", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "FACTURAFECHAREGISTRO");
            AnyError = 1;
            GX_FocusControl = edtFacturaFechaRegistro_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000F6 */
         pr_default.execute(4, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A4CiudadID = T000F6_A4CiudadID[0];
         n4CiudadID = T000F6_n4CiudadID[0];
         A63UsuarioZona = T000F6_A63UsuarioZona[0];
         AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
         A53UsuarioGenero = T000F6_A53UsuarioGenero[0];
         AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
         A30UsuarioNombre = T000F6_A30UsuarioNombre[0];
         A51UsuarioApellido = T000F6_A51UsuarioApellido[0];
         pr_default.close(4);
         /* Using cursor T000F7 */
         pr_default.execute(5, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
            }
         }
         A1EstadoID = T000F7_A1EstadoID[0];
         A5CiudadDescripcion = T000F7_A5CiudadDescripcion[0];
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         pr_default.close(5);
         /* Using cursor T000F8 */
         pr_default.execute(6, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A16PaisID = T000F8_A16PaisID[0];
         A2EstadoDescripcion = T000F8_A2EstadoDescripcion[0];
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         pr_default.close(6);
         /* Using cursor T000F9 */
         pr_default.execute(7, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = T000F9_A17PaisDescripcion[0];
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
         pr_default.close(7);
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
         if ( ! ( ( StringUtil.StrCmp(A80FacturaEstatus, "En Proceso") == 0 ) || ( StringUtil.StrCmp(A80FacturaEstatus, "Aprobada") == 0 ) || ( StringUtil.StrCmp(A80FacturaEstatus, "Rechazada") == 0 ) || ( StringUtil.StrCmp(A80FacturaEstatus, "Cancelada") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Factura Estatus", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "FACTURAESTATUS");
            AnyError = 1;
            GX_FocusControl = cmbFacturaEstatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000F5 */
         pr_default.execute(3, new Object[] {A19MotivoRechazoID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Motivo Rechazo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MOTIVORECHAZOID");
            AnyError = 1;
            GX_FocusControl = edtMotivoRechazoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A20MotivoRechazoDescripcion = T000F5_A20MotivoRechazoDescripcion[0];
         AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
         A21MotivoRechazoActivo = T000F5_A21MotivoRechazoActivo[0];
         AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0F15( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( int A41PromocionID )
      {
         /* Using cursor T000F11 */
         pr_default.execute(9, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
            GX_FocusControl = edtPromocionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A42PromocionDescripcion = T000F11_A42PromocionDescripcion[0];
         AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
         A43PromocionBase = T000F11_A43PromocionBase[0];
         AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
         A40000PromocionArte_GXI = T000F11_A40000PromocionArte_GXI[0];
         AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
         AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
         A45PromocionFechaInicio = T000F11_A45PromocionFechaInicio[0];
         A46PromocionFechaFin = T000F11_A46PromocionFechaFin[0];
         A44PromocionArte = T000F11_A44PromocionArte[0];
         AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
         AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
         AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A42PromocionDescripcion)+"\""+","+"\""+GXUtil.EncodeJSConstant( A43PromocionBase)+"\""+","+"\""+GXUtil.EncodeJSConstant( A44PromocionArte)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000PromocionArte_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A46PromocionFechaFin, "99/99/99"))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_11( int A29UsuarioID )
      {
         /* Using cursor T000F12 */
         pr_default.execute(10, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A4CiudadID = T000F12_A4CiudadID[0];
         n4CiudadID = T000F12_n4CiudadID[0];
         A63UsuarioZona = T000F12_A63UsuarioZona[0];
         AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
         A53UsuarioGenero = T000F12_A53UsuarioGenero[0];
         AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
         A30UsuarioNombre = T000F12_A30UsuarioNombre[0];
         A51UsuarioApellido = T000F12_A51UsuarioApellido[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A63UsuarioZona))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A53UsuarioGenero))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A30UsuarioNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A51UsuarioApellido))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_12( int A4CiudadID )
      {
         /* Using cursor T000F13 */
         pr_default.execute(11, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
            }
         }
         A1EstadoID = T000F13_A1EstadoID[0];
         A5CiudadDescripcion = T000F13_A5CiudadDescripcion[0];
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A5CiudadDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_13( int A1EstadoID )
      {
         /* Using cursor T000F14 */
         pr_default.execute(12, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A16PaisID = T000F14_A16PaisID[0];
         A2EstadoDescripcion = T000F14_A2EstadoDescripcion[0];
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A2EstadoDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_14( int A16PaisID )
      {
         /* Using cursor T000F15 */
         pr_default.execute(13, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = T000F15_A17PaisDescripcion[0];
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

      protected void gxLoad_10( int A19MotivoRechazoID )
      {
         /* Using cursor T000F16 */
         pr_default.execute(14, new Object[] {A19MotivoRechazoID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Motivo Rechazo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MOTIVORECHAZOID");
            AnyError = 1;
            GX_FocusControl = edtMotivoRechazoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A20MotivoRechazoDescripcion = T000F16_A20MotivoRechazoDescripcion[0];
         AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
         A21MotivoRechazoActivo = T000F16_A21MotivoRechazoActivo[0];
         AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A20MotivoRechazoDescripcion)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A21MotivoRechazoActivo))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey0F15( )
      {
         /* Using cursor T000F17 */
         pr_default.execute(15, new Object[] {A69FacturaID});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000F3 */
         pr_default.execute(1, new Object[] {A69FacturaID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F15( 8) ;
            RcdFound15 = 1;
            A69FacturaID = T000F3_A69FacturaID[0];
            AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
            A71FacturaNo = T000F3_A71FacturaNo[0];
            AssignAttri("", false, "A71FacturaNo", A71FacturaNo);
            A73FacturaFechaFactura = T000F3_A73FacturaFechaFactura[0];
            AssignAttri("", false, "A73FacturaFechaFactura", context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"));
            A72FacturaFechaRegistro = T000F3_A72FacturaFechaRegistro[0];
            AssignAttri("", false, "A72FacturaFechaRegistro", context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"));
            A40001FacturaPDF_GXI = T000F3_A40001FacturaPDF_GXI[0];
            A80FacturaEstatus = T000F3_A80FacturaEstatus[0];
            AssignAttri("", false, "A80FacturaEstatus", A80FacturaEstatus);
            A93FacturaCompleta = T000F3_A93FacturaCompleta[0];
            AssignAttri("", false, "A93FacturaCompleta", A93FacturaCompleta);
            A41PromocionID = T000F3_A41PromocionID[0];
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            A19MotivoRechazoID = T000F3_A19MotivoRechazoID[0];
            AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrimStr( (decimal)(A19MotivoRechazoID), 9, 0));
            A29UsuarioID = T000F3_A29UsuarioID[0];
            AssignAttri("", false, "A29UsuarioID", StringUtil.LTrimStr( (decimal)(A29UsuarioID), 9, 0));
            A75FacturaPDF = T000F3_A75FacturaPDF[0];
            AssignAttri("", false, "A75FacturaPDF", A75FacturaPDF);
            AssignProp("", false, edtFacturaPDF_Internalname, "Multimedia", (String.IsNullOrEmpty(StringUtil.RTrim( A75FacturaPDF)) ? A40001FacturaPDF_GXI : context.convertURL( context.PathToRelativeUrl( A75FacturaPDF))), true);
            Z69FacturaID = A69FacturaID;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0F15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0F15( ) ;
            }
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0F15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F15( ) ;
         if ( RcdFound15 == 0 )
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
         RcdFound15 = 0;
         /* Using cursor T000F18 */
         pr_default.execute(16, new Object[] {A69FacturaID});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( T000F18_A69FacturaID[0] < A69FacturaID ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( T000F18_A69FacturaID[0] > A69FacturaID ) ) )
            {
               A69FacturaID = T000F18_A69FacturaID[0];
               AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void move_previous( )
      {
         RcdFound15 = 0;
         /* Using cursor T000F19 */
         pr_default.execute(17, new Object[] {A69FacturaID});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( T000F19_A69FacturaID[0] > A69FacturaID ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( T000F19_A69FacturaID[0] < A69FacturaID ) ) )
            {
               A69FacturaID = T000F19_A69FacturaID[0];
               AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0F15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFacturaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0F15( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A69FacturaID != Z69FacturaID )
               {
                  A69FacturaID = Z69FacturaID;
                  AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FACTURAID");
                  AnyError = 1;
                  GX_FocusControl = edtFacturaID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFacturaID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0F15( ) ;
                  GX_FocusControl = edtFacturaID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A69FacturaID != Z69FacturaID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtFacturaID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0F15( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FACTURAID");
                     AnyError = 1;
                     GX_FocusControl = edtFacturaID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtFacturaID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0F15( ) ;
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
         if ( A69FacturaID != Z69FacturaID )
         {
            A69FacturaID = Z69FacturaID;
            AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FACTURAID");
            AnyError = 1;
            GX_FocusControl = edtFacturaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFacturaID_Internalname;
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
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "FACTURAID");
            AnyError = 1;
            GX_FocusControl = edtFacturaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPromocionID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0F15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPromocionID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0F15( ) ;
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
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPromocionID_Internalname;
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
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPromocionID_Internalname;
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
         ScanStart0F15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound15 != 0 )
            {
               ScanNext0F15( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPromocionID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0F15( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0F15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000F2 */
            pr_default.execute(0, new Object[] {A69FacturaID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Factura"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z71FacturaNo, T000F2_A71FacturaNo[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z73FacturaFechaFactura ) != DateTimeUtil.ResetTime ( T000F2_A73FacturaFechaFactura[0] ) ) || ( DateTimeUtil.ResetTime ( Z72FacturaFechaRegistro ) != DateTimeUtil.ResetTime ( T000F2_A72FacturaFechaRegistro[0] ) ) || ( StringUtil.StrCmp(Z80FacturaEstatus, T000F2_A80FacturaEstatus[0]) != 0 ) || ( Z93FacturaCompleta != T000F2_A93FacturaCompleta[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z41PromocionID != T000F2_A41PromocionID[0] ) || ( Z19MotivoRechazoID != T000F2_A19MotivoRechazoID[0] ) || ( Z29UsuarioID != T000F2_A29UsuarioID[0] ) )
            {
               if ( StringUtil.StrCmp(Z71FacturaNo, T000F2_A71FacturaNo[0]) != 0 )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"FacturaNo");
                  GXUtil.WriteLogRaw("Old: ",Z71FacturaNo);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A71FacturaNo[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z73FacturaFechaFactura ) != DateTimeUtil.ResetTime ( T000F2_A73FacturaFechaFactura[0] ) )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"FacturaFechaFactura");
                  GXUtil.WriteLogRaw("Old: ",Z73FacturaFechaFactura);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A73FacturaFechaFactura[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z72FacturaFechaRegistro ) != DateTimeUtil.ResetTime ( T000F2_A72FacturaFechaRegistro[0] ) )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"FacturaFechaRegistro");
                  GXUtil.WriteLogRaw("Old: ",Z72FacturaFechaRegistro);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A72FacturaFechaRegistro[0]);
               }
               if ( StringUtil.StrCmp(Z80FacturaEstatus, T000F2_A80FacturaEstatus[0]) != 0 )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"FacturaEstatus");
                  GXUtil.WriteLogRaw("Old: ",Z80FacturaEstatus);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A80FacturaEstatus[0]);
               }
               if ( Z93FacturaCompleta != T000F2_A93FacturaCompleta[0] )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"FacturaCompleta");
                  GXUtil.WriteLogRaw("Old: ",Z93FacturaCompleta);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A93FacturaCompleta[0]);
               }
               if ( Z41PromocionID != T000F2_A41PromocionID[0] )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"PromocionID");
                  GXUtil.WriteLogRaw("Old: ",Z41PromocionID);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A41PromocionID[0]);
               }
               if ( Z19MotivoRechazoID != T000F2_A19MotivoRechazoID[0] )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"MotivoRechazoID");
                  GXUtil.WriteLogRaw("Old: ",Z19MotivoRechazoID);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A19MotivoRechazoID[0]);
               }
               if ( Z29UsuarioID != T000F2_A29UsuarioID[0] )
               {
                  GXUtil.WriteLog("factura:[seudo value changed for attri]"+"UsuarioID");
                  GXUtil.WriteLogRaw("Old: ",Z29UsuarioID);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A29UsuarioID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Factura"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F15( )
      {
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F15( 0) ;
            CheckOptimisticConcurrency0F15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F20 */
                     pr_default.execute(18, new Object[] {A71FacturaNo, A73FacturaFechaFactura, A72FacturaFechaRegistro, A75FacturaPDF, A40001FacturaPDF_GXI, A80FacturaEstatus, A93FacturaCompleta, A41PromocionID, A19MotivoRechazoID, A29UsuarioID});
                     pr_default.close(18);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000F21 */
                     pr_default.execute(19);
                     A69FacturaID = T000F21_A69FacturaID[0];
                     AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("Factura");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0F0( ) ;
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
               Load0F15( ) ;
            }
            EndLevel0F15( ) ;
         }
         CloseExtendedTableCursors0F15( ) ;
      }

      protected void Update0F15( )
      {
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F22 */
                     pr_default.execute(20, new Object[] {A71FacturaNo, A73FacturaFechaFactura, A72FacturaFechaRegistro, A80FacturaEstatus, A93FacturaCompleta, A41PromocionID, A19MotivoRechazoID, A29UsuarioID, A69FacturaID});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("Factura");
                     if ( (pr_default.getStatus(20) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Factura"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F15( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0F0( ) ;
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
            EndLevel0F15( ) ;
         }
         CloseExtendedTableCursors0F15( ) ;
      }

      protected void DeferredUpdate0F15( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000F23 */
            pr_default.execute(21, new Object[] {A75FacturaPDF, A40001FacturaPDF_GXI, A69FacturaID});
            pr_default.close(21);
            pr_default.SmartCacheProvider.SetUpdated("Factura");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F15( ) ;
            AfterConfirm0F15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000F24 */
                  pr_default.execute(22, new Object[] {A69FacturaID});
                  pr_default.close(22);
                  pr_default.SmartCacheProvider.SetUpdated("Factura");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound15 == 0 )
                        {
                           InitAll0F15( ) ;
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
                        ResetCaption0F0( ) ;
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0F15( ) ;
         Gx_mode = sMode15;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0F15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000F25 */
            pr_default.execute(23, new Object[] {A41PromocionID});
            A42PromocionDescripcion = T000F25_A42PromocionDescripcion[0];
            AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
            A43PromocionBase = T000F25_A43PromocionBase[0];
            AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
            A40000PromocionArte_GXI = T000F25_A40000PromocionArte_GXI[0];
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            A45PromocionFechaInicio = T000F25_A45PromocionFechaInicio[0];
            A46PromocionFechaFin = T000F25_A46PromocionFechaFin[0];
            A44PromocionArte = T000F25_A44PromocionArte[0];
            AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            pr_default.close(23);
            A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            AssignAttri("", false, "A70PromocionVigencia", A70PromocionVigencia);
            /* Using cursor T000F26 */
            pr_default.execute(24, new Object[] {A29UsuarioID});
            A4CiudadID = T000F26_A4CiudadID[0];
            n4CiudadID = T000F26_n4CiudadID[0];
            A63UsuarioZona = T000F26_A63UsuarioZona[0];
            AssignAttri("", false, "A63UsuarioZona", A63UsuarioZona);
            A53UsuarioGenero = T000F26_A53UsuarioGenero[0];
            AssignAttri("", false, "A53UsuarioGenero", A53UsuarioGenero);
            A30UsuarioNombre = T000F26_A30UsuarioNombre[0];
            A51UsuarioApellido = T000F26_A51UsuarioApellido[0];
            pr_default.close(24);
            /* Using cursor T000F27 */
            pr_default.execute(25, new Object[] {n4CiudadID, A4CiudadID});
            A1EstadoID = T000F27_A1EstadoID[0];
            A5CiudadDescripcion = T000F27_A5CiudadDescripcion[0];
            AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
            pr_default.close(25);
            /* Using cursor T000F28 */
            pr_default.execute(26, new Object[] {A1EstadoID});
            A16PaisID = T000F28_A16PaisID[0];
            A2EstadoDescripcion = T000F28_A2EstadoDescripcion[0];
            AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
            pr_default.close(26);
            /* Using cursor T000F29 */
            pr_default.execute(27, new Object[] {A16PaisID});
            A17PaisDescripcion = T000F29_A17PaisDescripcion[0];
            AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
            pr_default.close(27);
            A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
            AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
            /* Using cursor T000F30 */
            pr_default.execute(28, new Object[] {A19MotivoRechazoID});
            A20MotivoRechazoDescripcion = T000F30_A20MotivoRechazoDescripcion[0];
            AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
            A21MotivoRechazoActivo = T000F30_A21MotivoRechazoActivo[0];
            AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
            pr_default.close(28);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000F31 */
            pr_default.execute(29, new Object[] {A69FacturaID});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Factura Medida", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
         }
      }

      protected void EndLevel0F15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("factura",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("factura",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0F15( )
      {
         /* Using cursor T000F32 */
         pr_default.execute(30);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound15 = 1;
            A69FacturaID = T000F32_A69FacturaID[0];
            AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0F15( )
      {
         /* Scan next routine */
         pr_default.readNext(30);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound15 = 1;
            A69FacturaID = T000F32_A69FacturaID[0];
            AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
         }
      }

      protected void ScanEnd0F15( )
      {
         pr_default.close(30);
      }

      protected void AfterConfirm0F15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F15( )
      {
         edtFacturaID_Enabled = 0;
         AssignProp("", false, edtFacturaID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFacturaID_Enabled), 5, 0), true);
         edtPromocionID_Enabled = 0;
         AssignProp("", false, edtPromocionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionID_Enabled), 5, 0), true);
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
         chkFacturaCompleta.Enabled = 0;
         AssignProp("", false, chkFacturaCompleta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkFacturaCompleta.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0F15( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0F0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("factura.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z69FacturaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z69FacturaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z71FacturaNo", StringUtil.RTrim( Z71FacturaNo));
         GxWebStd.gx_hidden_field( context, "Z73FacturaFechaFactura", context.localUtil.DToC( Z73FacturaFechaFactura, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z72FacturaFechaRegistro", context.localUtil.DToC( Z72FacturaFechaRegistro, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z80FacturaEstatus", StringUtil.RTrim( Z80FacturaEstatus));
         GxWebStd.gx_boolean_hidden_field( context, "Z93FacturaCompleta", Z93FacturaCompleta);
         GxWebStd.gx_hidden_field( context, "Z41PromocionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z19MotivoRechazoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19MotivoRechazoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z29UsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29UsuarioID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "USUARIONOMBRE", StringUtil.RTrim( A30UsuarioNombre));
         GxWebStd.gx_hidden_field( context, "USUARIOAPELLIDO", StringUtil.RTrim( A51UsuarioApellido));
         GxWebStd.gx_hidden_field( context, "PROMOCIONFECHAINICIO", context.localUtil.DToC( A45PromocionFechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "PROMOCIONFECHAFIN", context.localUtil.DToC( A46PromocionFechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "FACTURAPDF_GXI", A40001FacturaPDF_GXI);
         GxWebStd.gx_hidden_field( context, "PROMOCIONARTE_GXI", A40000PromocionArte_GXI);
         GxWebStd.gx_hidden_field( context, "CIUDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ESTADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("factura.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Factura" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Factura", "") ;
      }

      protected void InitializeNonKey0F15( )
      {
         A16PaisID = 0;
         AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
         A1EstadoID = 0;
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
         A4CiudadID = 0;
         n4CiudadID = false;
         AssignAttri("", false, "A4CiudadID", StringUtil.LTrimStr( (decimal)(A4CiudadID), 9, 0));
         A41PromocionID = 0;
         AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
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
         A52UsuarioNombreCompleto = "";
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
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
         A19MotivoRechazoID = 0;
         AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrimStr( (decimal)(A19MotivoRechazoID), 9, 0));
         A20MotivoRechazoDescripcion = "";
         AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
         A21MotivoRechazoActivo = false;
         AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
         A30UsuarioNombre = "";
         AssignAttri("", false, "A30UsuarioNombre", A30UsuarioNombre);
         A51UsuarioApellido = "";
         AssignAttri("", false, "A51UsuarioApellido", A51UsuarioApellido);
         A45PromocionFechaInicio = DateTime.MinValue;
         AssignAttri("", false, "A45PromocionFechaInicio", context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"));
         A46PromocionFechaFin = DateTime.MinValue;
         AssignAttri("", false, "A46PromocionFechaFin", context.localUtil.Format(A46PromocionFechaFin, "99/99/99"));
         A80FacturaEstatus = "En Proceso";
         AssignAttri("", false, "A80FacturaEstatus", A80FacturaEstatus);
         A93FacturaCompleta = false;
         AssignAttri("", false, "A93FacturaCompleta", A93FacturaCompleta);
         Z71FacturaNo = "";
         Z73FacturaFechaFactura = DateTime.MinValue;
         Z72FacturaFechaRegistro = DateTime.MinValue;
         Z80FacturaEstatus = "";
         Z93FacturaCompleta = false;
         Z41PromocionID = 0;
         Z19MotivoRechazoID = 0;
         Z29UsuarioID = 0;
      }

      protected void InitAll0F15( )
      {
         A69FacturaID = 0;
         AssignAttri("", false, "A69FacturaID", StringUtil.LTrimStr( (decimal)(A69FacturaID), 9, 0));
         InitializeNonKey0F15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A93FacturaCompleta = i93FacturaCompleta;
         AssignAttri("", false, "A93FacturaCompleta", A93FacturaCompleta);
         A80FacturaEstatus = i80FacturaEstatus;
         AssignAttri("", false, "A80FacturaEstatus", A80FacturaEstatus);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202651111305580", true, true);
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
         context.AddJavascriptSource("factura.js", "?202651111305580", false, true);
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
         edtFacturaID_Internalname = "FACTURAID";
         edtPromocionID_Internalname = "PROMOCIONID";
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
         chkFacturaCompleta_Internalname = "FACTURACOMPLETA";
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
         Form.Caption = context.GetMessage( "Factura", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkFacturaCompleta.Enabled = 1;
         chkMotivoRechazoActivo.Enabled = 0;
         edtMotivoRechazoDescripcion_Jsonclick = "";
         edtMotivoRechazoDescripcion_Enabled = 0;
         edtMotivoRechazoID_Jsonclick = "";
         edtMotivoRechazoID_Enabled = 1;
         cmbFacturaEstatus_Jsonclick = "";
         cmbFacturaEstatus.Enabled = 1;
         edtFacturaPDF_Filename = "";
         edtFacturaPDF_Enabled = 1;
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
         edtUsuarioID_Enabled = 1;
         edtFacturaFechaRegistro_Jsonclick = "";
         edtFacturaFechaRegistro_Enabled = 1;
         edtFacturaFechaFactura_Jsonclick = "";
         edtFacturaFechaFactura_Enabled = 1;
         edtFacturaNo_Jsonclick = "";
         edtFacturaNo_Enabled = 1;
         edtPromocionVigencia_Jsonclick = "";
         edtPromocionVigencia_Enabled = 0;
         imgPromocionArte_Enabled = 0;
         edtPromocionBase_Enabled = 0;
         edtPromocionDescripcion_Jsonclick = "";
         edtPromocionDescripcion_Enabled = 0;
         edtPromocionID_Jsonclick = "";
         edtPromocionID_Enabled = 1;
         edtFacturaID_Jsonclick = "";
         edtFacturaID_Enabled = 1;
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
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A80FacturaEstatus)) )
            {
               A80FacturaEstatus = "En Proceso";
               AssignAttri("", false, "A80FacturaEstatus", A80FacturaEstatus);
            }
         }
         chkMotivoRechazoActivo.Name = "MOTIVORECHAZOACTIVO";
         chkMotivoRechazoActivo.WebTags = "";
         chkMotivoRechazoActivo.Caption = context.GetMessage( "Motivo Rechazo Activo", "");
         AssignProp("", false, chkMotivoRechazoActivo_Internalname, "TitleCaption", chkMotivoRechazoActivo.Caption, true);
         chkMotivoRechazoActivo.CheckedValue = "false";
         A21MotivoRechazoActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A21MotivoRechazoActivo));
         AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
         chkFacturaCompleta.Name = "FACTURACOMPLETA";
         chkFacturaCompleta.WebTags = "";
         chkFacturaCompleta.Caption = context.GetMessage( "Completa", "");
         AssignProp("", false, chkFacturaCompleta_Internalname, "TitleCaption", chkFacturaCompleta.Caption, true);
         chkFacturaCompleta.CheckedValue = "false";
         if ( IsIns( ) && (false==A93FacturaCompleta) )
         {
            A93FacturaCompleta = false;
            AssignAttri("", false, "A93FacturaCompleta", A93FacturaCompleta);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtPromocionID_Internalname;
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

      public void Valid_Facturaid( )
      {
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
         A93FacturaCompleta = StringUtil.StrToBool( StringUtil.BoolToStr( A93FacturaCompleta));
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
         A21MotivoRechazoActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A21MotivoRechazoActivo));
         /*  Sending validation outputs */
         AssignAttri("", false, "A41PromocionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, ".", "")));
         AssignAttri("", false, "A71FacturaNo", StringUtil.RTrim( A71FacturaNo));
         AssignAttri("", false, "A73FacturaFechaFactura", context.localUtil.Format(A73FacturaFechaFactura, "99/99/99"));
         AssignAttri("", false, "A72FacturaFechaRegistro", context.localUtil.Format(A72FacturaFechaRegistro, "99/99/99"));
         AssignAttri("", false, "A29UsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29UsuarioID), 9, 0, ".", "")));
         AssignAttri("", false, "A75FacturaPDF", context.PathToRelativeUrl( A75FacturaPDF));
         AssignAttri("", false, "A40001FacturaPDF_GXI", A40001FacturaPDF_GXI);
         AssignAttri("", false, "A80FacturaEstatus", StringUtil.RTrim( A80FacturaEstatus));
         cmbFacturaEstatus.CurrentValue = StringUtil.RTrim( A80FacturaEstatus);
         AssignProp("", false, cmbFacturaEstatus_Internalname, "Values", cmbFacturaEstatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A19MotivoRechazoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MotivoRechazoID), 9, 0, ".", "")));
         AssignAttri("", false, "A93FacturaCompleta", A93FacturaCompleta);
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
         AssignAttri("", false, "A4CiudadID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, ".", "")));
         AssignAttri("", false, "A63UsuarioZona", StringUtil.RTrim( A63UsuarioZona));
         cmbUsuarioZona.CurrentValue = StringUtil.RTrim( A63UsuarioZona);
         AssignProp("", false, cmbUsuarioZona_Internalname, "Values", cmbUsuarioZona.ToJavascriptSource(), true);
         AssignAttri("", false, "A53UsuarioGenero", StringUtil.RTrim( A53UsuarioGenero));
         cmbUsuarioGenero.CurrentValue = StringUtil.RTrim( A53UsuarioGenero);
         AssignProp("", false, cmbUsuarioGenero_Internalname, "Values", cmbUsuarioGenero.ToJavascriptSource(), true);
         AssignAttri("", false, "A30UsuarioNombre", StringUtil.RTrim( A30UsuarioNombre));
         AssignAttri("", false, "A51UsuarioApellido", StringUtil.RTrim( A51UsuarioApellido));
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, ".", "")));
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         AssignAttri("", false, "A16PaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, ".", "")));
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
         AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
         AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z69FacturaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z69FacturaID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z41PromocionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41PromocionID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z71FacturaNo", StringUtil.RTrim( Z71FacturaNo));
         GxWebStd.gx_hidden_field( context, "Z73FacturaFechaFactura", context.localUtil.Format(Z73FacturaFechaFactura, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z72FacturaFechaRegistro", context.localUtil.Format(Z72FacturaFechaRegistro, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z29UsuarioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29UsuarioID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z75FacturaPDF", context.PathToRelativeUrl( Z75FacturaPDF));
         GxWebStd.gx_hidden_field( context, "Z40001FacturaPDF_GXI", Z40001FacturaPDF_GXI);
         GxWebStd.gx_hidden_field( context, "Z80FacturaEstatus", StringUtil.RTrim( Z80FacturaEstatus));
         GxWebStd.gx_hidden_field( context, "Z19MotivoRechazoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19MotivoRechazoID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z93FacturaCompleta", StringUtil.BoolToStr( Z93FacturaCompleta));
         GxWebStd.gx_hidden_field( context, "Z42PromocionDescripcion", Z42PromocionDescripcion);
         GxWebStd.gx_hidden_field( context, "Z43PromocionBase", Z43PromocionBase);
         GxWebStd.gx_hidden_field( context, "Z44PromocionArte", context.PathToRelativeUrl( Z44PromocionArte));
         GxWebStd.gx_hidden_field( context, "Z40000PromocionArte_GXI", Z40000PromocionArte_GXI);
         GxWebStd.gx_hidden_field( context, "Z45PromocionFechaInicio", context.localUtil.Format(Z45PromocionFechaInicio, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z46PromocionFechaFin", context.localUtil.Format(Z46PromocionFechaFin, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z70PromocionVigencia", Z70PromocionVigencia);
         GxWebStd.gx_hidden_field( context, "Z4CiudadID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4CiudadID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z63UsuarioZona", StringUtil.RTrim( Z63UsuarioZona));
         GxWebStd.gx_hidden_field( context, "Z53UsuarioGenero", StringUtil.RTrim( Z53UsuarioGenero));
         GxWebStd.gx_hidden_field( context, "Z30UsuarioNombre", StringUtil.RTrim( Z30UsuarioNombre));
         GxWebStd.gx_hidden_field( context, "Z51UsuarioApellido", StringUtil.RTrim( Z51UsuarioApellido));
         GxWebStd.gx_hidden_field( context, "Z1EstadoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EstadoID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5CiudadDescripcion", Z5CiudadDescripcion);
         GxWebStd.gx_hidden_field( context, "Z16PaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16PaisID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2EstadoDescripcion", Z2EstadoDescripcion);
         GxWebStd.gx_hidden_field( context, "Z17PaisDescripcion", Z17PaisDescripcion);
         GxWebStd.gx_hidden_field( context, "Z52UsuarioNombreCompleto", Z52UsuarioNombreCompleto);
         GxWebStd.gx_hidden_field( context, "Z20MotivoRechazoDescripcion", Z20MotivoRechazoDescripcion);
         GxWebStd.gx_hidden_field( context, "Z21MotivoRechazoActivo", StringUtil.BoolToStr( Z21MotivoRechazoActivo));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Promocionid( )
      {
         /* Using cursor T000F25 */
         pr_default.execute(23, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
            GX_FocusControl = edtPromocionID_Internalname;
         }
         A42PromocionDescripcion = T000F25_A42PromocionDescripcion[0];
         A43PromocionBase = T000F25_A43PromocionBase[0];
         A40000PromocionArte_GXI = T000F25_A40000PromocionArte_GXI[0];
         A45PromocionFechaInicio = T000F25_A45PromocionFechaInicio[0];
         A46PromocionFechaFin = T000F25_A46PromocionFechaFin[0];
         A44PromocionArte = T000F25_A44PromocionArte[0];
         pr_default.close(23);
         A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         dynload_actions( ) ;
         /*  Sending validation outputs */
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
      }

      public void Valid_Usuarioid( )
      {
         n4CiudadID = false;
         A63UsuarioZona = cmbUsuarioZona.CurrentValue;
         cmbUsuarioZona.CurrentValue = A63UsuarioZona;
         A53UsuarioGenero = cmbUsuarioGenero.CurrentValue;
         cmbUsuarioGenero.CurrentValue = A53UsuarioGenero;
         /* Using cursor T000F26 */
         pr_default.execute(24, new Object[] {A29UsuarioID});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioID_Internalname;
         }
         A4CiudadID = T000F26_A4CiudadID[0];
         n4CiudadID = T000F26_n4CiudadID[0];
         A63UsuarioZona = T000F26_A63UsuarioZona[0];
         cmbUsuarioZona.CurrentValue = A63UsuarioZona;
         A53UsuarioGenero = T000F26_A53UsuarioGenero[0];
         cmbUsuarioGenero.CurrentValue = A53UsuarioGenero;
         A30UsuarioNombre = T000F26_A30UsuarioNombre[0];
         A51UsuarioApellido = T000F26_A51UsuarioApellido[0];
         pr_default.close(24);
         /* Using cursor T000F27 */
         pr_default.execute(25, new Object[] {n4CiudadID, A4CiudadID});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( (0==A4CiudadID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ciudad", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CIUDADID");
               AnyError = 1;
            }
         }
         A1EstadoID = T000F27_A1EstadoID[0];
         A5CiudadDescripcion = T000F27_A5CiudadDescripcion[0];
         pr_default.close(25);
         /* Using cursor T000F28 */
         pr_default.execute(26, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(26) == 101) )
         {
            if ( ! ( (0==A1EstadoID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOID");
               AnyError = 1;
            }
         }
         A16PaisID = T000F28_A16PaisID[0];
         A2EstadoDescripcion = T000F28_A2EstadoDescripcion[0];
         pr_default.close(26);
         /* Using cursor T000F29 */
         pr_default.execute(27, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(27) == 101) )
         {
            if ( ! ( (0==A16PaisID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
            }
         }
         A17PaisDescripcion = T000F29_A17PaisDescripcion[0];
         pr_default.close(27);
         A52UsuarioNombreCompleto = StringUtil.Trim( A30UsuarioNombre) + " " + StringUtil.Trim( A51UsuarioApellido);
         dynload_actions( ) ;
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
         /*  Sending validation outputs */
         AssignAttri("", false, "A4CiudadID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4CiudadID), 9, 0, ".", "")));
         AssignAttri("", false, "A63UsuarioZona", StringUtil.RTrim( A63UsuarioZona));
         cmbUsuarioZona.CurrentValue = StringUtil.RTrim( A63UsuarioZona);
         AssignProp("", false, cmbUsuarioZona_Internalname, "Values", cmbUsuarioZona.ToJavascriptSource(), true);
         AssignAttri("", false, "A53UsuarioGenero", StringUtil.RTrim( A53UsuarioGenero));
         cmbUsuarioGenero.CurrentValue = StringUtil.RTrim( A53UsuarioGenero);
         AssignProp("", false, cmbUsuarioGenero_Internalname, "Values", cmbUsuarioGenero.ToJavascriptSource(), true);
         AssignAttri("", false, "A30UsuarioNombre", StringUtil.RTrim( A30UsuarioNombre));
         AssignAttri("", false, "A51UsuarioApellido", StringUtil.RTrim( A51UsuarioApellido));
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, ".", "")));
         AssignAttri("", false, "A5CiudadDescripcion", A5CiudadDescripcion);
         AssignAttri("", false, "A16PaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, ".", "")));
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
         AssignAttri("", false, "A52UsuarioNombreCompleto", A52UsuarioNombreCompleto);
      }

      public void Valid_Motivorechazoid( )
      {
         /* Using cursor T000F30 */
         pr_default.execute(28, new Object[] {A19MotivoRechazoID});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Motivo Rechazo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MOTIVORECHAZOID");
            AnyError = 1;
            GX_FocusControl = edtMotivoRechazoID_Internalname;
         }
         A20MotivoRechazoDescripcion = T000F30_A20MotivoRechazoDescripcion[0];
         A21MotivoRechazoActivo = T000F30_A21MotivoRechazoActivo[0];
         pr_default.close(28);
         dynload_actions( ) ;
         A21MotivoRechazoActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A21MotivoRechazoActivo));
         /*  Sending validation outputs */
         AssignAttri("", false, "A20MotivoRechazoDescripcion", A20MotivoRechazoDescripcion);
         AssignAttri("", false, "A21MotivoRechazoActivo", A21MotivoRechazoActivo);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]}""");
         setEventMetadata("VALID_FACTURAID","""{"handler":"Valid_Facturaid","iparms":[{"av":"cmbUsuarioGenero"},{"av":"A53UsuarioGenero","fld":"USUARIOGENERO"},{"av":"cmbUsuarioZona"},{"av":"A63UsuarioZona","fld":"USUARIOZONA"},{"av":"A69FacturaID","fld":"FACTURAID","pic":"ZZZZZZZZ9"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS"},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]""");
         setEventMetadata("VALID_FACTURAID",""","oparms":[{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A71FacturaNo","fld":"FACTURANO"},{"av":"A73FacturaFechaFactura","fld":"FACTURAFECHAFACTURA"},{"av":"A72FacturaFechaRegistro","fld":"FACTURAFECHAREGISTRO"},{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9"},{"av":"A75FacturaPDF","fld":"FACTURAPDF"},{"av":"A40001FacturaPDF_GXI","fld":"FACTURAPDF_GXI"},{"av":"cmbFacturaEstatus"},{"av":"A80FacturaEstatus","fld":"FACTURAESTATUS"},{"av":"A19MotivoRechazoID","fld":"MOTIVORECHAZOID","pic":"ZZZZZZZZ9"},{"av":"A42PromocionDescripcion","fld":"PROMOCIONDESCRIPCION"},{"av":"A43PromocionBase","fld":"PROMOCIONBASE"},{"av":"A44PromocionArte","fld":"PROMOCIONARTE"},{"av":"A40000PromocionArte_GXI","fld":"PROMOCIONARTE_GXI"},{"av":"A45PromocionFechaInicio","fld":"PROMOCIONFECHAINICIO"},{"av":"A46PromocionFechaFin","fld":"PROMOCIONFECHAFIN"},{"av":"A70PromocionVigencia","fld":"PROMOCIONVIGENCIA"},{"av":"A4CiudadID","fld":"CIUDADID","pic":"ZZZZZZZZ9"},{"av":"cmbUsuarioZona"},{"av":"A63UsuarioZona","fld":"USUARIOZONA"},{"av":"cmbUsuarioGenero"},{"av":"A53UsuarioGenero","fld":"USUARIOGENERO"},{"av":"A30UsuarioNombre","fld":"USUARIONOMBRE"},{"av":"A51UsuarioApellido","fld":"USUARIOAPELLIDO"},{"av":"A1EstadoID","fld":"ESTADOID","pic":"ZZZZZZZZ9"},{"av":"A5CiudadDescripcion","fld":"CIUDADDESCRIPCION"},{"av":"A16PaisID","fld":"PAISID","pic":"ZZZZZZZZ9"},{"av":"A2EstadoDescripcion","fld":"ESTADODESCRIPCION"},{"av":"A17PaisDescripcion","fld":"PAISDESCRIPCION"},{"av":"A52UsuarioNombreCompleto","fld":"USUARIONOMBRECOMPLETO"},{"av":"A20MotivoRechazoDescripcion","fld":"MOTIVORECHAZODESCRIPCION"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z69FacturaID"},{"av":"Z41PromocionID"},{"av":"Z71FacturaNo"},{"av":"Z73FacturaFechaFactura"},{"av":"Z72FacturaFechaRegistro"},{"av":"Z29UsuarioID"},{"av":"Z75FacturaPDF"},{"av":"Z40001FacturaPDF_GXI"},{"av":"Z80FacturaEstatus"},{"av":"Z19MotivoRechazoID"},{"av":"Z93FacturaCompleta"},{"av":"Z42PromocionDescripcion"},{"av":"Z43PromocionBase"},{"av":"Z44PromocionArte"},{"av":"Z40000PromocionArte_GXI"},{"av":"Z45PromocionFechaInicio"},{"av":"Z46PromocionFechaFin"},{"av":"Z70PromocionVigencia"},{"av":"Z4CiudadID"},{"av":"Z63UsuarioZona"},{"av":"Z53UsuarioGenero"},{"av":"Z30UsuarioNombre"},{"av":"Z51UsuarioApellido"},{"av":"Z1EstadoID"},{"av":"Z5CiudadDescripcion"},{"av":"Z16PaisID"},{"av":"Z2EstadoDescripcion"},{"av":"Z17PaisDescripcion"},{"av":"Z52UsuarioNombreCompleto"},{"av":"Z20MotivoRechazoDescripcion"},{"av":"Z21MotivoRechazoActivo"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]}""");
         setEventMetadata("VALID_PROMOCIONID","""{"handler":"Valid_Promocionid","iparms":[{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A45PromocionFechaInicio","fld":"PROMOCIONFECHAINICIO"},{"av":"A46PromocionFechaFin","fld":"PROMOCIONFECHAFIN"},{"av":"A42PromocionDescripcion","fld":"PROMOCIONDESCRIPCION"},{"av":"A43PromocionBase","fld":"PROMOCIONBASE"},{"av":"A44PromocionArte","fld":"PROMOCIONARTE"},{"av":"A40000PromocionArte_GXI","fld":"PROMOCIONARTE_GXI"},{"av":"A70PromocionVigencia","fld":"PROMOCIONVIGENCIA"},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]""");
         setEventMetadata("VALID_PROMOCIONID",""","oparms":[{"av":"A42PromocionDescripcion","fld":"PROMOCIONDESCRIPCION"},{"av":"A43PromocionBase","fld":"PROMOCIONBASE"},{"av":"A44PromocionArte","fld":"PROMOCIONARTE"},{"av":"A40000PromocionArte_GXI","fld":"PROMOCIONARTE_GXI"},{"av":"A45PromocionFechaInicio","fld":"PROMOCIONFECHAINICIO"},{"av":"A46PromocionFechaFin","fld":"PROMOCIONFECHAFIN"},{"av":"A70PromocionVigencia","fld":"PROMOCIONVIGENCIA"},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]}""");
         setEventMetadata("VALID_FACTURAFECHAFACTURA","""{"handler":"Valid_Facturafechafactura","iparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]""");
         setEventMetadata("VALID_FACTURAFECHAFACTURA",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]}""");
         setEventMetadata("VALID_FACTURAFECHAREGISTRO","""{"handler":"Valid_Facturafecharegistro","iparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]""");
         setEventMetadata("VALID_FACTURAFECHAREGISTRO",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]}""");
         setEventMetadata("VALID_USUARIOID","""{"handler":"Valid_Usuarioid","iparms":[{"av":"A29UsuarioID","fld":"USUARIOID","pic":"ZZZZZZZZ9"},{"av":"A4CiudadID","fld":"CIUDADID","pic":"ZZZZZZZZ9"},{"av":"A1EstadoID","fld":"ESTADOID","pic":"ZZZZZZZZ9"},{"av":"A16PaisID","fld":"PAISID","pic":"ZZZZZZZZ9"},{"av":"A30UsuarioNombre","fld":"USUARIONOMBRE"},{"av":"A51UsuarioApellido","fld":"USUARIOAPELLIDO"},{"av":"cmbUsuarioZona"},{"av":"A63UsuarioZona","fld":"USUARIOZONA"},{"av":"cmbUsuarioGenero"},{"av":"A53UsuarioGenero","fld":"USUARIOGENERO"},{"av":"A5CiudadDescripcion","fld":"CIUDADDESCRIPCION"},{"av":"A2EstadoDescripcion","fld":"ESTADODESCRIPCION"},{"av":"A17PaisDescripcion","fld":"PAISDESCRIPCION"},{"av":"A52UsuarioNombreCompleto","fld":"USUARIONOMBRECOMPLETO"},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]""");
         setEventMetadata("VALID_USUARIOID",""","oparms":[{"av":"A4CiudadID","fld":"CIUDADID","pic":"ZZZZZZZZ9"},{"av":"cmbUsuarioZona"},{"av":"A63UsuarioZona","fld":"USUARIOZONA"},{"av":"cmbUsuarioGenero"},{"av":"A53UsuarioGenero","fld":"USUARIOGENERO"},{"av":"A30UsuarioNombre","fld":"USUARIONOMBRE"},{"av":"A51UsuarioApellido","fld":"USUARIOAPELLIDO"},{"av":"A1EstadoID","fld":"ESTADOID","pic":"ZZZZZZZZ9"},{"av":"A5CiudadDescripcion","fld":"CIUDADDESCRIPCION"},{"av":"A16PaisID","fld":"PAISID","pic":"ZZZZZZZZ9"},{"av":"A2EstadoDescripcion","fld":"ESTADODESCRIPCION"},{"av":"A17PaisDescripcion","fld":"PAISDESCRIPCION"},{"av":"A52UsuarioNombreCompleto","fld":"USUARIONOMBRECOMPLETO"},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]}""");
         setEventMetadata("VALID_FACTURAESTATUS","""{"handler":"Valid_Facturaestatus","iparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]""");
         setEventMetadata("VALID_FACTURAESTATUS",""","oparms":[{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]}""");
         setEventMetadata("VALID_MOTIVORECHAZOID","""{"handler":"Valid_Motivorechazoid","iparms":[{"av":"A19MotivoRechazoID","fld":"MOTIVORECHAZOID","pic":"ZZZZZZZZ9"},{"av":"A20MotivoRechazoDescripcion","fld":"MOTIVORECHAZODESCRIPCION"},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]""");
         setEventMetadata("VALID_MOTIVORECHAZOID",""","oparms":[{"av":"A20MotivoRechazoDescripcion","fld":"MOTIVORECHAZODESCRIPCION"},{"av":"A21MotivoRechazoActivo","fld":"MOTIVORECHAZOACTIVO"},{"av":"A93FacturaCompleta","fld":"FACTURACOMPLETA"}]}""");
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
         pr_default.close(23);
         pr_default.close(28);
         pr_default.close(24);
         pr_default.close(25);
         pr_default.close(26);
         pr_default.close(27);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z71FacturaNo = "";
         Z73FacturaFechaFactura = DateTime.MinValue;
         Z72FacturaFechaRegistro = DateTime.MinValue;
         Z80FacturaEstatus = "";
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
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         A30UsuarioNombre = "";
         A51UsuarioApellido = "";
         A45PromocionFechaInicio = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z75FacturaPDF = "";
         Z40001FacturaPDF_GXI = "";
         Z42PromocionDescripcion = "";
         Z43PromocionBase = "";
         Z44PromocionArte = "";
         Z40000PromocionArte_GXI = "";
         Z45PromocionFechaInicio = DateTime.MinValue;
         Z46PromocionFechaFin = DateTime.MinValue;
         Z63UsuarioZona = "";
         Z53UsuarioGenero = "";
         Z30UsuarioNombre = "";
         Z51UsuarioApellido = "";
         Z5CiudadDescripcion = "";
         Z2EstadoDescripcion = "";
         Z17PaisDescripcion = "";
         Z20MotivoRechazoDescripcion = "";
         T000F10_A4CiudadID = new int[1] ;
         T000F10_n4CiudadID = new bool[] {false} ;
         T000F10_A1EstadoID = new int[1] ;
         T000F10_A16PaisID = new int[1] ;
         T000F10_A69FacturaID = new int[1] ;
         T000F10_A42PromocionDescripcion = new string[] {""} ;
         T000F10_A43PromocionBase = new string[] {""} ;
         T000F10_A40000PromocionArte_GXI = new string[] {""} ;
         T000F10_A71FacturaNo = new string[] {""} ;
         T000F10_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         T000F10_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         T000F10_A63UsuarioZona = new string[] {""} ;
         T000F10_A2EstadoDescripcion = new string[] {""} ;
         T000F10_A5CiudadDescripcion = new string[] {""} ;
         T000F10_A17PaisDescripcion = new string[] {""} ;
         T000F10_A53UsuarioGenero = new string[] {""} ;
         T000F10_A40001FacturaPDF_GXI = new string[] {""} ;
         T000F10_A80FacturaEstatus = new string[] {""} ;
         T000F10_A20MotivoRechazoDescripcion = new string[] {""} ;
         T000F10_A21MotivoRechazoActivo = new bool[] {false} ;
         T000F10_A93FacturaCompleta = new bool[] {false} ;
         T000F10_A30UsuarioNombre = new string[] {""} ;
         T000F10_A51UsuarioApellido = new string[] {""} ;
         T000F10_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000F10_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         T000F10_A41PromocionID = new int[1] ;
         T000F10_A19MotivoRechazoID = new int[1] ;
         T000F10_A29UsuarioID = new int[1] ;
         T000F10_A44PromocionArte = new string[] {""} ;
         T000F10_A75FacturaPDF = new string[] {""} ;
         T000F4_A42PromocionDescripcion = new string[] {""} ;
         T000F4_A43PromocionBase = new string[] {""} ;
         T000F4_A40000PromocionArte_GXI = new string[] {""} ;
         T000F4_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000F4_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         T000F4_A44PromocionArte = new string[] {""} ;
         T000F6_A4CiudadID = new int[1] ;
         T000F6_n4CiudadID = new bool[] {false} ;
         T000F6_A63UsuarioZona = new string[] {""} ;
         T000F6_A53UsuarioGenero = new string[] {""} ;
         T000F6_A30UsuarioNombre = new string[] {""} ;
         T000F6_A51UsuarioApellido = new string[] {""} ;
         T000F7_A1EstadoID = new int[1] ;
         T000F7_A5CiudadDescripcion = new string[] {""} ;
         T000F8_A16PaisID = new int[1] ;
         T000F8_A2EstadoDescripcion = new string[] {""} ;
         T000F9_A17PaisDescripcion = new string[] {""} ;
         T000F5_A20MotivoRechazoDescripcion = new string[] {""} ;
         T000F5_A21MotivoRechazoActivo = new bool[] {false} ;
         T000F11_A42PromocionDescripcion = new string[] {""} ;
         T000F11_A43PromocionBase = new string[] {""} ;
         T000F11_A40000PromocionArte_GXI = new string[] {""} ;
         T000F11_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000F11_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         T000F11_A44PromocionArte = new string[] {""} ;
         T000F12_A4CiudadID = new int[1] ;
         T000F12_n4CiudadID = new bool[] {false} ;
         T000F12_A63UsuarioZona = new string[] {""} ;
         T000F12_A53UsuarioGenero = new string[] {""} ;
         T000F12_A30UsuarioNombre = new string[] {""} ;
         T000F12_A51UsuarioApellido = new string[] {""} ;
         T000F13_A1EstadoID = new int[1] ;
         T000F13_A5CiudadDescripcion = new string[] {""} ;
         T000F14_A16PaisID = new int[1] ;
         T000F14_A2EstadoDescripcion = new string[] {""} ;
         T000F15_A17PaisDescripcion = new string[] {""} ;
         T000F16_A20MotivoRechazoDescripcion = new string[] {""} ;
         T000F16_A21MotivoRechazoActivo = new bool[] {false} ;
         T000F17_A69FacturaID = new int[1] ;
         T000F3_A69FacturaID = new int[1] ;
         T000F3_A71FacturaNo = new string[] {""} ;
         T000F3_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         T000F3_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         T000F3_A40001FacturaPDF_GXI = new string[] {""} ;
         T000F3_A80FacturaEstatus = new string[] {""} ;
         T000F3_A93FacturaCompleta = new bool[] {false} ;
         T000F3_A41PromocionID = new int[1] ;
         T000F3_A19MotivoRechazoID = new int[1] ;
         T000F3_A29UsuarioID = new int[1] ;
         T000F3_A75FacturaPDF = new string[] {""} ;
         sMode15 = "";
         T000F18_A69FacturaID = new int[1] ;
         T000F19_A69FacturaID = new int[1] ;
         T000F2_A69FacturaID = new int[1] ;
         T000F2_A71FacturaNo = new string[] {""} ;
         T000F2_A73FacturaFechaFactura = new DateTime[] {DateTime.MinValue} ;
         T000F2_A72FacturaFechaRegistro = new DateTime[] {DateTime.MinValue} ;
         T000F2_A40001FacturaPDF_GXI = new string[] {""} ;
         T000F2_A80FacturaEstatus = new string[] {""} ;
         T000F2_A93FacturaCompleta = new bool[] {false} ;
         T000F2_A41PromocionID = new int[1] ;
         T000F2_A19MotivoRechazoID = new int[1] ;
         T000F2_A29UsuarioID = new int[1] ;
         T000F2_A75FacturaPDF = new string[] {""} ;
         T000F21_A69FacturaID = new int[1] ;
         T000F25_A42PromocionDescripcion = new string[] {""} ;
         T000F25_A43PromocionBase = new string[] {""} ;
         T000F25_A40000PromocionArte_GXI = new string[] {""} ;
         T000F25_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000F25_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         T000F25_A44PromocionArte = new string[] {""} ;
         T000F26_A4CiudadID = new int[1] ;
         T000F26_n4CiudadID = new bool[] {false} ;
         T000F26_A63UsuarioZona = new string[] {""} ;
         T000F26_A53UsuarioGenero = new string[] {""} ;
         T000F26_A30UsuarioNombre = new string[] {""} ;
         T000F26_A51UsuarioApellido = new string[] {""} ;
         T000F27_A1EstadoID = new int[1] ;
         T000F27_A5CiudadDescripcion = new string[] {""} ;
         T000F28_A16PaisID = new int[1] ;
         T000F28_A2EstadoDescripcion = new string[] {""} ;
         T000F29_A17PaisDescripcion = new string[] {""} ;
         T000F30_A20MotivoRechazoDescripcion = new string[] {""} ;
         T000F30_A21MotivoRechazoActivo = new bool[] {false} ;
         T000F31_A77FacturaMedidaID = new int[1] ;
         T000F32_A69FacturaID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         i80FacturaEstatus = "";
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
         ZZ63UsuarioZona = "";
         ZZ53UsuarioGenero = "";
         ZZ30UsuarioNombre = "";
         ZZ51UsuarioApellido = "";
         ZZ5CiudadDescripcion = "";
         ZZ2EstadoDescripcion = "";
         ZZ17PaisDescripcion = "";
         ZZ52UsuarioNombreCompleto = "";
         ZZ20MotivoRechazoDescripcion = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.factura__default(),
            new Object[][] {
                new Object[] {
               T000F2_A69FacturaID, T000F2_A71FacturaNo, T000F2_A73FacturaFechaFactura, T000F2_A72FacturaFechaRegistro, T000F2_A40001FacturaPDF_GXI, T000F2_A80FacturaEstatus, T000F2_A93FacturaCompleta, T000F2_A41PromocionID, T000F2_A19MotivoRechazoID, T000F2_A29UsuarioID,
               T000F2_A75FacturaPDF
               }
               , new Object[] {
               T000F3_A69FacturaID, T000F3_A71FacturaNo, T000F3_A73FacturaFechaFactura, T000F3_A72FacturaFechaRegistro, T000F3_A40001FacturaPDF_GXI, T000F3_A80FacturaEstatus, T000F3_A93FacturaCompleta, T000F3_A41PromocionID, T000F3_A19MotivoRechazoID, T000F3_A29UsuarioID,
               T000F3_A75FacturaPDF
               }
               , new Object[] {
               T000F4_A42PromocionDescripcion, T000F4_A43PromocionBase, T000F4_A40000PromocionArte_GXI, T000F4_A45PromocionFechaInicio, T000F4_A46PromocionFechaFin, T000F4_A44PromocionArte
               }
               , new Object[] {
               T000F5_A20MotivoRechazoDescripcion, T000F5_A21MotivoRechazoActivo
               }
               , new Object[] {
               T000F6_A4CiudadID, T000F6_n4CiudadID, T000F6_A63UsuarioZona, T000F6_A53UsuarioGenero, T000F6_A30UsuarioNombre, T000F6_A51UsuarioApellido
               }
               , new Object[] {
               T000F7_A1EstadoID, T000F7_A5CiudadDescripcion
               }
               , new Object[] {
               T000F8_A16PaisID, T000F8_A2EstadoDescripcion
               }
               , new Object[] {
               T000F9_A17PaisDescripcion
               }
               , new Object[] {
               T000F10_A4CiudadID, T000F10_n4CiudadID, T000F10_A1EstadoID, T000F10_A16PaisID, T000F10_A69FacturaID, T000F10_A42PromocionDescripcion, T000F10_A43PromocionBase, T000F10_A40000PromocionArte_GXI, T000F10_A71FacturaNo, T000F10_A73FacturaFechaFactura,
               T000F10_A72FacturaFechaRegistro, T000F10_A63UsuarioZona, T000F10_A2EstadoDescripcion, T000F10_A5CiudadDescripcion, T000F10_A17PaisDescripcion, T000F10_A53UsuarioGenero, T000F10_A40001FacturaPDF_GXI, T000F10_A80FacturaEstatus, T000F10_A20MotivoRechazoDescripcion, T000F10_A21MotivoRechazoActivo,
               T000F10_A93FacturaCompleta, T000F10_A30UsuarioNombre, T000F10_A51UsuarioApellido, T000F10_A45PromocionFechaInicio, T000F10_A46PromocionFechaFin, T000F10_A41PromocionID, T000F10_A19MotivoRechazoID, T000F10_A29UsuarioID, T000F10_A44PromocionArte, T000F10_A75FacturaPDF
               }
               , new Object[] {
               T000F11_A42PromocionDescripcion, T000F11_A43PromocionBase, T000F11_A40000PromocionArte_GXI, T000F11_A45PromocionFechaInicio, T000F11_A46PromocionFechaFin, T000F11_A44PromocionArte
               }
               , new Object[] {
               T000F12_A4CiudadID, T000F12_n4CiudadID, T000F12_A63UsuarioZona, T000F12_A53UsuarioGenero, T000F12_A30UsuarioNombre, T000F12_A51UsuarioApellido
               }
               , new Object[] {
               T000F13_A1EstadoID, T000F13_A5CiudadDescripcion
               }
               , new Object[] {
               T000F14_A16PaisID, T000F14_A2EstadoDescripcion
               }
               , new Object[] {
               T000F15_A17PaisDescripcion
               }
               , new Object[] {
               T000F16_A20MotivoRechazoDescripcion, T000F16_A21MotivoRechazoActivo
               }
               , new Object[] {
               T000F17_A69FacturaID
               }
               , new Object[] {
               T000F18_A69FacturaID
               }
               , new Object[] {
               T000F19_A69FacturaID
               }
               , new Object[] {
               }
               , new Object[] {
               T000F21_A69FacturaID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000F25_A42PromocionDescripcion, T000F25_A43PromocionBase, T000F25_A40000PromocionArte_GXI, T000F25_A45PromocionFechaInicio, T000F25_A46PromocionFechaFin, T000F25_A44PromocionArte
               }
               , new Object[] {
               T000F26_A4CiudadID, T000F26_n4CiudadID, T000F26_A63UsuarioZona, T000F26_A53UsuarioGenero, T000F26_A30UsuarioNombre, T000F26_A51UsuarioApellido
               }
               , new Object[] {
               T000F27_A1EstadoID, T000F27_A5CiudadDescripcion
               }
               , new Object[] {
               T000F28_A16PaisID, T000F28_A2EstadoDescripcion
               }
               , new Object[] {
               T000F29_A17PaisDescripcion
               }
               , new Object[] {
               T000F30_A20MotivoRechazoDescripcion, T000F30_A21MotivoRechazoActivo
               }
               , new Object[] {
               T000F31_A77FacturaMedidaID
               }
               , new Object[] {
               T000F32_A69FacturaID
               }
            }
         );
         Z93FacturaCompleta = false;
         A93FacturaCompleta = false;
         i93FacturaCompleta = false;
         Z80FacturaEstatus = "En Proceso";
         A80FacturaEstatus = "En Proceso";
         i80FacturaEstatus = "En Proceso";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound15 ;
      private short gxajaxcallmode ;
      private int Z69FacturaID ;
      private int Z41PromocionID ;
      private int Z19MotivoRechazoID ;
      private int Z29UsuarioID ;
      private int A41PromocionID ;
      private int A29UsuarioID ;
      private int A4CiudadID ;
      private int A1EstadoID ;
      private int A16PaisID ;
      private int A19MotivoRechazoID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A69FacturaID ;
      private int edtFacturaID_Enabled ;
      private int edtPromocionID_Enabled ;
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
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int Z4CiudadID ;
      private int Z1EstadoID ;
      private int Z16PaisID ;
      private int idxLst ;
      private int ZZ69FacturaID ;
      private int ZZ41PromocionID ;
      private int ZZ29UsuarioID ;
      private int ZZ19MotivoRechazoID ;
      private int ZZ4CiudadID ;
      private int ZZ1EstadoID ;
      private int ZZ16PaisID ;
      private string sPrefix ;
      private string Z71FacturaNo ;
      private string Z80FacturaEstatus ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtFacturaID_Internalname ;
      private string A63UsuarioZona ;
      private string cmbUsuarioZona_Internalname ;
      private string A53UsuarioGenero ;
      private string cmbUsuarioGenero_Internalname ;
      private string A80FacturaEstatus ;
      private string cmbFacturaEstatus_Internalname ;
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
      private string edtFacturaID_Jsonclick ;
      private string edtPromocionID_Internalname ;
      private string edtPromocionID_Jsonclick ;
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
      private string chkFacturaCompleta_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string A30UsuarioNombre ;
      private string A51UsuarioApellido ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z63UsuarioZona ;
      private string Z53UsuarioGenero ;
      private string Z30UsuarioNombre ;
      private string Z51UsuarioApellido ;
      private string sMode15 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string i80FacturaEstatus ;
      private string ZZ71FacturaNo ;
      private string ZZ80FacturaEstatus ;
      private string ZZ63UsuarioZona ;
      private string ZZ53UsuarioGenero ;
      private string ZZ30UsuarioNombre ;
      private string ZZ51UsuarioApellido ;
      private DateTime Z73FacturaFechaFactura ;
      private DateTime Z72FacturaFechaRegistro ;
      private DateTime A73FacturaFechaFactura ;
      private DateTime A72FacturaFechaRegistro ;
      private DateTime A45PromocionFechaInicio ;
      private DateTime A46PromocionFechaFin ;
      private DateTime Z45PromocionFechaInicio ;
      private DateTime Z46PromocionFechaFin ;
      private DateTime ZZ73FacturaFechaFactura ;
      private DateTime ZZ72FacturaFechaRegistro ;
      private DateTime ZZ45PromocionFechaInicio ;
      private DateTime ZZ46PromocionFechaFin ;
      private bool Z93FacturaCompleta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n4CiudadID ;
      private bool wbErr ;
      private bool A21MotivoRechazoActivo ;
      private bool A93FacturaCompleta ;
      private bool A44PromocionArte_IsBlob ;
      private bool A75FacturaPDF_IsBlob ;
      private bool Z21MotivoRechazoActivo ;
      private bool Gx_longc ;
      private bool i93FacturaCompleta ;
      private bool ZZ93FacturaCompleta ;
      private bool ZZ21MotivoRechazoActivo ;
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
      private string Z40001FacturaPDF_GXI ;
      private string Z42PromocionDescripcion ;
      private string Z43PromocionBase ;
      private string Z40000PromocionArte_GXI ;
      private string Z5CiudadDescripcion ;
      private string Z2EstadoDescripcion ;
      private string Z17PaisDescripcion ;
      private string Z20MotivoRechazoDescripcion ;
      private string Z70PromocionVigencia ;
      private string Z52UsuarioNombreCompleto ;
      private string ZZ40001FacturaPDF_GXI ;
      private string ZZ42PromocionDescripcion ;
      private string ZZ43PromocionBase ;
      private string ZZ40000PromocionArte_GXI ;
      private string ZZ70PromocionVigencia ;
      private string ZZ5CiudadDescripcion ;
      private string ZZ2EstadoDescripcion ;
      private string ZZ17PaisDescripcion ;
      private string ZZ52UsuarioNombreCompleto ;
      private string ZZ20MotivoRechazoDescripcion ;
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
      private GXCheckbox chkFacturaCompleta ;
      private IDataStoreProvider pr_default ;
      private int[] T000F10_A4CiudadID ;
      private bool[] T000F10_n4CiudadID ;
      private int[] T000F10_A1EstadoID ;
      private int[] T000F10_A16PaisID ;
      private int[] T000F10_A69FacturaID ;
      private string[] T000F10_A42PromocionDescripcion ;
      private string[] T000F10_A43PromocionBase ;
      private string[] T000F10_A40000PromocionArte_GXI ;
      private string[] T000F10_A71FacturaNo ;
      private DateTime[] T000F10_A73FacturaFechaFactura ;
      private DateTime[] T000F10_A72FacturaFechaRegistro ;
      private string[] T000F10_A63UsuarioZona ;
      private string[] T000F10_A2EstadoDescripcion ;
      private string[] T000F10_A5CiudadDescripcion ;
      private string[] T000F10_A17PaisDescripcion ;
      private string[] T000F10_A53UsuarioGenero ;
      private string[] T000F10_A40001FacturaPDF_GXI ;
      private string[] T000F10_A80FacturaEstatus ;
      private string[] T000F10_A20MotivoRechazoDescripcion ;
      private bool[] T000F10_A21MotivoRechazoActivo ;
      private bool[] T000F10_A93FacturaCompleta ;
      private string[] T000F10_A30UsuarioNombre ;
      private string[] T000F10_A51UsuarioApellido ;
      private DateTime[] T000F10_A45PromocionFechaInicio ;
      private DateTime[] T000F10_A46PromocionFechaFin ;
      private int[] T000F10_A41PromocionID ;
      private int[] T000F10_A19MotivoRechazoID ;
      private int[] T000F10_A29UsuarioID ;
      private string[] T000F10_A44PromocionArte ;
      private string[] T000F10_A75FacturaPDF ;
      private string[] T000F4_A42PromocionDescripcion ;
      private string[] T000F4_A43PromocionBase ;
      private string[] T000F4_A40000PromocionArte_GXI ;
      private DateTime[] T000F4_A45PromocionFechaInicio ;
      private DateTime[] T000F4_A46PromocionFechaFin ;
      private string[] T000F4_A44PromocionArte ;
      private int[] T000F6_A4CiudadID ;
      private bool[] T000F6_n4CiudadID ;
      private string[] T000F6_A63UsuarioZona ;
      private string[] T000F6_A53UsuarioGenero ;
      private string[] T000F6_A30UsuarioNombre ;
      private string[] T000F6_A51UsuarioApellido ;
      private int[] T000F7_A1EstadoID ;
      private string[] T000F7_A5CiudadDescripcion ;
      private int[] T000F8_A16PaisID ;
      private string[] T000F8_A2EstadoDescripcion ;
      private string[] T000F9_A17PaisDescripcion ;
      private string[] T000F5_A20MotivoRechazoDescripcion ;
      private bool[] T000F5_A21MotivoRechazoActivo ;
      private string[] T000F11_A42PromocionDescripcion ;
      private string[] T000F11_A43PromocionBase ;
      private string[] T000F11_A40000PromocionArte_GXI ;
      private DateTime[] T000F11_A45PromocionFechaInicio ;
      private DateTime[] T000F11_A46PromocionFechaFin ;
      private string[] T000F11_A44PromocionArte ;
      private int[] T000F12_A4CiudadID ;
      private bool[] T000F12_n4CiudadID ;
      private string[] T000F12_A63UsuarioZona ;
      private string[] T000F12_A53UsuarioGenero ;
      private string[] T000F12_A30UsuarioNombre ;
      private string[] T000F12_A51UsuarioApellido ;
      private int[] T000F13_A1EstadoID ;
      private string[] T000F13_A5CiudadDescripcion ;
      private int[] T000F14_A16PaisID ;
      private string[] T000F14_A2EstadoDescripcion ;
      private string[] T000F15_A17PaisDescripcion ;
      private string[] T000F16_A20MotivoRechazoDescripcion ;
      private bool[] T000F16_A21MotivoRechazoActivo ;
      private int[] T000F17_A69FacturaID ;
      private int[] T000F3_A69FacturaID ;
      private string[] T000F3_A71FacturaNo ;
      private DateTime[] T000F3_A73FacturaFechaFactura ;
      private DateTime[] T000F3_A72FacturaFechaRegistro ;
      private string[] T000F3_A40001FacturaPDF_GXI ;
      private string[] T000F3_A80FacturaEstatus ;
      private bool[] T000F3_A93FacturaCompleta ;
      private int[] T000F3_A41PromocionID ;
      private int[] T000F3_A19MotivoRechazoID ;
      private int[] T000F3_A29UsuarioID ;
      private string[] T000F3_A75FacturaPDF ;
      private int[] T000F18_A69FacturaID ;
      private int[] T000F19_A69FacturaID ;
      private int[] T000F2_A69FacturaID ;
      private string[] T000F2_A71FacturaNo ;
      private DateTime[] T000F2_A73FacturaFechaFactura ;
      private DateTime[] T000F2_A72FacturaFechaRegistro ;
      private string[] T000F2_A40001FacturaPDF_GXI ;
      private string[] T000F2_A80FacturaEstatus ;
      private bool[] T000F2_A93FacturaCompleta ;
      private int[] T000F2_A41PromocionID ;
      private int[] T000F2_A19MotivoRechazoID ;
      private int[] T000F2_A29UsuarioID ;
      private string[] T000F2_A75FacturaPDF ;
      private int[] T000F21_A69FacturaID ;
      private string[] T000F25_A42PromocionDescripcion ;
      private string[] T000F25_A43PromocionBase ;
      private string[] T000F25_A40000PromocionArte_GXI ;
      private DateTime[] T000F25_A45PromocionFechaInicio ;
      private DateTime[] T000F25_A46PromocionFechaFin ;
      private string[] T000F25_A44PromocionArte ;
      private int[] T000F26_A4CiudadID ;
      private bool[] T000F26_n4CiudadID ;
      private string[] T000F26_A63UsuarioZona ;
      private string[] T000F26_A53UsuarioGenero ;
      private string[] T000F26_A30UsuarioNombre ;
      private string[] T000F26_A51UsuarioApellido ;
      private int[] T000F27_A1EstadoID ;
      private string[] T000F27_A5CiudadDescripcion ;
      private int[] T000F28_A16PaisID ;
      private string[] T000F28_A2EstadoDescripcion ;
      private string[] T000F29_A17PaisDescripcion ;
      private string[] T000F30_A20MotivoRechazoDescripcion ;
      private bool[] T000F30_A21MotivoRechazoActivo ;
      private int[] T000F31_A77FacturaMedidaID ;
      private int[] T000F32_A69FacturaID ;
   }

   public class factura__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000F2;
          prmT000F2 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmT000F3;
          prmT000F3 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmT000F4;
          prmT000F4 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000F5;
          prmT000F5 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmT000F6;
          prmT000F6 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000F7;
          prmT000F7 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000F8;
          prmT000F8 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000F9;
          prmT000F9 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT000F10;
          prmT000F10 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmT000F11;
          prmT000F11 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000F12;
          prmT000F12 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000F13;
          prmT000F13 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000F14;
          prmT000F14 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000F15;
          prmT000F15 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT000F16;
          prmT000F16 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmT000F17;
          prmT000F17 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmT000F18;
          prmT000F18 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmT000F19;
          prmT000F19 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmT000F20;
          prmT000F20 = new Object[] {
          new ParDef("@FacturaNo",GXType.Char,20,0) ,
          new ParDef("@FacturaFechaFactura",GXType.Date,8,0) ,
          new ParDef("@FacturaFechaRegistro",GXType.Date,8,0) ,
          new ParDef("@FacturaPDF",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@FacturaPDF_GXI",GXType.Char,2048,0){AddAtt=true, ImgIdx=3, Tbl="Factura", Fld="FacturaPDF"} ,
          new ParDef("@FacturaEstatus",GXType.Char,20,0) ,
          new ParDef("@FacturaCompleta",GXType.Byte,4,0) ,
          new ParDef("@PromocionID",GXType.Int32,9,0) ,
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0) ,
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000F21;
          prmT000F21 = new Object[] {
          };
          Object[] prmT000F22;
          prmT000F22 = new Object[] {
          new ParDef("@FacturaNo",GXType.Char,20,0) ,
          new ParDef("@FacturaFechaFactura",GXType.Date,8,0) ,
          new ParDef("@FacturaFechaRegistro",GXType.Date,8,0) ,
          new ParDef("@FacturaEstatus",GXType.Char,20,0) ,
          new ParDef("@FacturaCompleta",GXType.Byte,4,0) ,
          new ParDef("@PromocionID",GXType.Int32,9,0) ,
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0) ,
          new ParDef("@UsuarioID",GXType.Int32,9,0) ,
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmT000F23;
          prmT000F23 = new Object[] {
          new ParDef("@FacturaPDF",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@FacturaPDF_GXI",GXType.Char,2048,0){AddAtt=true, ImgIdx=0, Tbl="Factura", Fld="FacturaPDF"} ,
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmT000F24;
          prmT000F24 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmT000F25;
          prmT000F25 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000F26;
          prmT000F26 = new Object[] {
          new ParDef("@UsuarioID",GXType.Int32,9,0)
          };
          Object[] prmT000F27;
          prmT000F27 = new Object[] {
          new ParDef("@CiudadID",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000F28;
          prmT000F28 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000F29;
          prmT000F29 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT000F30;
          prmT000F30 = new Object[] {
          new ParDef("@MotivoRechazoID",GXType.Int32,9,0)
          };
          Object[] prmT000F31;
          prmT000F31 = new Object[] {
          new ParDef("@FacturaID",GXType.Int32,9,0)
          };
          Object[] prmT000F32;
          prmT000F32 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000F2", "SELECT `FacturaID`, `FacturaNo`, `FacturaFechaFactura`, `FacturaFechaRegistro`, `FacturaPDF_GXI`, `FacturaEstatus`, `FacturaCompleta`, `PromocionID`, `MotivoRechazoID`, `UsuarioID`, `FacturaPDF` FROM `Factura` WHERE `FacturaID` = @FacturaID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F3", "SELECT `FacturaID`, `FacturaNo`, `FacturaFechaFactura`, `FacturaFechaRegistro`, `FacturaPDF_GXI`, `FacturaEstatus`, `FacturaCompleta`, `PromocionID`, `MotivoRechazoID`, `UsuarioID`, `FacturaPDF` FROM `Factura` WHERE `FacturaID` = @FacturaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F4", "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F5", "SELECT `MotivoRechazoDescripcion`, `MotivoRechazoActivo` FROM `MotivoRechazo` WHERE `MotivoRechazoID` = @MotivoRechazoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F6", "SELECT `CiudadID`, `UsuarioZona`, `UsuarioGenero`, `UsuarioNombre`, `UsuarioApellido` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F7", "SELECT `EstadoID`, `CiudadDescripcion` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F8", "SELECT `PaisID`, `EstadoDescripcion` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F9", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F10", "SELECT T3.`CiudadID`, T4.`EstadoID`, T5.`PaisID`, TM1.`FacturaID`, T2.`PromocionDescripcion`, T2.`PromocionBase`, T2.`PromocionArte_GXI`, TM1.`FacturaNo`, TM1.`FacturaFechaFactura`, TM1.`FacturaFechaRegistro`, T3.`UsuarioZona`, T5.`EstadoDescripcion`, T4.`CiudadDescripcion`, T6.`PaisDescripcion`, T3.`UsuarioGenero`, TM1.`FacturaPDF_GXI`, TM1.`FacturaEstatus`, T7.`MotivoRechazoDescripcion`, T7.`MotivoRechazoActivo`, TM1.`FacturaCompleta`, T3.`UsuarioNombre`, T3.`UsuarioApellido`, T2.`PromocionFechaInicio`, T2.`PromocionFechaFin`, TM1.`PromocionID`, TM1.`MotivoRechazoID`, TM1.`UsuarioID`, T2.`PromocionArte`, TM1.`FacturaPDF` FROM ((((((`Factura` TM1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = TM1.`PromocionID`) INNER JOIN `Usuario` T3 ON T3.`UsuarioID` = TM1.`UsuarioID`) LEFT JOIN `Ciudad` T4 ON T4.`CiudadID` = T3.`CiudadID`) LEFT JOIN `Estado` T5 ON T5.`EstadoID` = T4.`EstadoID`) LEFT JOIN `Pais` T6 ON T6.`PaisID` = T5.`PaisID`) INNER JOIN `MotivoRechazo` T7 ON T7.`MotivoRechazoID` = TM1.`MotivoRechazoID`) WHERE TM1.`FacturaID` = @FacturaID ORDER BY TM1.`FacturaID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F11", "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F12", "SELECT `CiudadID`, `UsuarioZona`, `UsuarioGenero`, `UsuarioNombre`, `UsuarioApellido` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F13", "SELECT `EstadoID`, `CiudadDescripcion` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F14", "SELECT `PaisID`, `EstadoDescripcion` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F15", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F16", "SELECT `MotivoRechazoDescripcion`, `MotivoRechazoActivo` FROM `MotivoRechazo` WHERE `MotivoRechazoID` = @MotivoRechazoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F17", "SELECT `FacturaID` FROM `Factura` WHERE `FacturaID` = @FacturaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F18", "SELECT `FacturaID` FROM `Factura` WHERE ( `FacturaID` > @FacturaID) ORDER BY `FacturaID`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000F18,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000F19", "SELECT `FacturaID` FROM `Factura` WHERE ( `FacturaID` < @FacturaID) ORDER BY `FacturaID` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000F19,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000F20", "INSERT INTO `Factura`(`FacturaNo`, `FacturaFechaFactura`, `FacturaFechaRegistro`, `FacturaPDF`, `FacturaPDF_GXI`, `FacturaEstatus`, `FacturaCompleta`, `PromocionID`, `MotivoRechazoID`, `UsuarioID`) VALUES(@FacturaNo, @FacturaFechaFactura, @FacturaFechaRegistro, @FacturaPDF, @FacturaPDF_GXI, @FacturaEstatus, @FacturaCompleta, @PromocionID, @MotivoRechazoID, @UsuarioID)", GxErrorMask.GX_NOMASK,prmT000F20)
             ,new CursorDef("T000F21", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F22", "UPDATE `Factura` SET `FacturaNo`=@FacturaNo, `FacturaFechaFactura`=@FacturaFechaFactura, `FacturaFechaRegistro`=@FacturaFechaRegistro, `FacturaEstatus`=@FacturaEstatus, `FacturaCompleta`=@FacturaCompleta, `PromocionID`=@PromocionID, `MotivoRechazoID`=@MotivoRechazoID, `UsuarioID`=@UsuarioID  WHERE `FacturaID` = @FacturaID", GxErrorMask.GX_NOMASK,prmT000F22)
             ,new CursorDef("T000F23", "UPDATE `Factura` SET `FacturaPDF`=@FacturaPDF, `FacturaPDF_GXI`=@FacturaPDF_GXI  WHERE `FacturaID` = @FacturaID", GxErrorMask.GX_NOMASK,prmT000F23)
             ,new CursorDef("T000F24", "DELETE FROM `Factura`  WHERE `FacturaID` = @FacturaID", GxErrorMask.GX_NOMASK,prmT000F24)
             ,new CursorDef("T000F25", "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F26", "SELECT `CiudadID`, `UsuarioZona`, `UsuarioGenero`, `UsuarioNombre`, `UsuarioApellido` FROM `Usuario` WHERE `UsuarioID` = @UsuarioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F26,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F27", "SELECT `EstadoID`, `CiudadDescripcion` FROM `Ciudad` WHERE `CiudadID` = @CiudadID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F27,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F28", "SELECT `PaisID`, `EstadoDescripcion` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F28,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F29", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F30", "SELECT `MotivoRechazoDescripcion`, `MotivoRechazoActivo` FROM `MotivoRechazo` WHERE `MotivoRechazoID` = @MotivoRechazoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F30,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F31", "SELECT `FacturaMedidaID` FROM `FacturaMedida` WHERE `FacturaID` = @FacturaID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000F31,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000F32", "SELECT `FacturaID` FROM `Factura` ORDER BY `FacturaID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F32,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 30);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((string[]) buf[4])[0] = rslt.getString(4, 50);
                ((string[]) buf[5])[0] = rslt.getString(5, 50);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getMultimediaUri(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 30);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getVarchar(13);
                ((string[]) buf[14])[0] = rslt.getVarchar(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 20);
                ((string[]) buf[16])[0] = rslt.getMultimediaUri(16);
                ((string[]) buf[17])[0] = rslt.getString(17, 20);
                ((string[]) buf[18])[0] = rslt.getVarchar(18);
                ((bool[]) buf[19])[0] = rslt.getBool(19);
                ((bool[]) buf[20])[0] = rslt.getBool(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 50);
                ((string[]) buf[22])[0] = rslt.getString(22, 50);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(23);
                ((DateTime[]) buf[24])[0] = rslt.getGXDate(24);
                ((int[]) buf[25])[0] = rslt.getInt(25);
                ((int[]) buf[26])[0] = rslt.getInt(26);
                ((int[]) buf[27])[0] = rslt.getInt(27);
                ((string[]) buf[28])[0] = rslt.getMultimediaFile(28, rslt.getVarchar(7));
                ((string[]) buf[29])[0] = rslt.getMultimediaFile(29, rslt.getVarchar(16));
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 30);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((string[]) buf[4])[0] = rslt.getString(4, 50);
                ((string[]) buf[5])[0] = rslt.getString(5, 50);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
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
             case 23 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 30);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((string[]) buf[4])[0] = rslt.getString(4, 50);
                ((string[]) buf[5])[0] = rslt.getString(5, 50);
                return;
             case 25 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 26 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 27 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 28 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
             case 29 :
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
