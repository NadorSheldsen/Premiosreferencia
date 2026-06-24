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
   public class modelo : GXDataArea
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
         Form.Meta.addItem("description", context.GetMessage( "Modelo", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtModeloID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public modelo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public modelo( IGxContext context )
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
         chkModeloActivo = new GXCheckbox();
         cmbModeloSegmento = new GXCombobox();
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
         A24ModeloActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A24ModeloActivo));
         AssignAttri("", false, "A24ModeloActivo", A24ModeloActivo);
         if ( cmbModeloSegmento.ItemCount > 0 )
         {
            A25ModeloSegmento = cmbModeloSegmento.getValidValue(A25ModeloSegmento);
            AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbModeloSegmento.CurrentValue = StringUtil.RTrim( A25ModeloSegmento);
            AssignProp("", false, cmbModeloSegmento_Internalname, "Values", cmbModeloSegmento.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Modelo", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Modelo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Modelo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Modelo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Modelo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Modelo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Modelo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtModeloID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtModeloID_Internalname, context.GetMessage( "ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtModeloID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22ModeloID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtModeloID_Enabled!=0) ? context.localUtil.Format( (decimal)(A22ModeloID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A22ModeloID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtModeloID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtModeloID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Modelo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtModeloDescripcion_Internalname, A23ModeloDescripcion, StringUtil.RTrim( context.localUtil.Format( A23ModeloDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtModeloDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtModeloDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Modelo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkModeloActivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkModeloActivo_Internalname, context.GetMessage( "Activo", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkModeloActivo_Internalname, StringUtil.BoolToStr( A24ModeloActivo), "", context.GetMessage( "Activo", ""), 1, chkModeloActivo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(44, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,44);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbModeloSegmento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbModeloSegmento_Internalname, context.GetMessage( "Segmento", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbModeloSegmento, cmbModeloSegmento_Internalname, StringUtil.RTrim( A25ModeloSegmento), 1, cmbModeloSegmento_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbModeloSegmento.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_Modelo.htm");
         cmbModeloSegmento.CurrentValue = StringUtil.RTrim( A25ModeloSegmento);
         AssignProp("", false, cmbModeloSegmento_Internalname, "Values", (string)(cmbModeloSegmento.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtModeloMarca_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtModeloMarca_Internalname, context.GetMessage( "Marca", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtModeloMarca_Internalname, A84ModeloMarca, StringUtil.RTrim( context.localUtil.Format( A84ModeloMarca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtModeloMarca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtModeloMarca_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Modelo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Modelo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Modelo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Modelo.htm");
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
            Z22ModeloID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z22ModeloID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z23ModeloDescripcion = cgiGet( "Z23ModeloDescripcion");
            Z24ModeloActivo = StringUtil.StrToBool( cgiGet( "Z24ModeloActivo"));
            Z25ModeloSegmento = cgiGet( "Z25ModeloSegmento");
            Z84ModeloMarca = cgiGet( "Z84ModeloMarca");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtModeloID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtModeloID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MODELOID");
               AnyError = 1;
               GX_FocusControl = edtModeloID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A22ModeloID = 0;
               AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
            }
            else
            {
               A22ModeloID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtModeloID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
            }
            A23ModeloDescripcion = cgiGet( edtModeloDescripcion_Internalname);
            AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
            A24ModeloActivo = StringUtil.StrToBool( cgiGet( chkModeloActivo_Internalname));
            AssignAttri("", false, "A24ModeloActivo", A24ModeloActivo);
            cmbModeloSegmento.CurrentValue = cgiGet( cmbModeloSegmento_Internalname);
            A25ModeloSegmento = cgiGet( cmbModeloSegmento_Internalname);
            AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
            A84ModeloMarca = cgiGet( edtModeloMarca_Internalname);
            AssignAttri("", false, "A84ModeloMarca", A84ModeloMarca);
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
               A22ModeloID = (int)(Math.Round(NumberUtil.Val( GetPar( "ModeloID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
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
               InitAll088( ) ;
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
         DisableAttributes088( ) ;
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

      protected void ResetCaption080( )
      {
      }

      protected void ZM088( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z23ModeloDescripcion = T00083_A23ModeloDescripcion[0];
               Z24ModeloActivo = T00083_A24ModeloActivo[0];
               Z25ModeloSegmento = T00083_A25ModeloSegmento[0];
               Z84ModeloMarca = T00083_A84ModeloMarca[0];
            }
            else
            {
               Z23ModeloDescripcion = A23ModeloDescripcion;
               Z24ModeloActivo = A24ModeloActivo;
               Z25ModeloSegmento = A25ModeloSegmento;
               Z84ModeloMarca = A84ModeloMarca;
            }
         }
         if ( GX_JID == -2 )
         {
            Z22ModeloID = A22ModeloID;
            Z23ModeloDescripcion = A23ModeloDescripcion;
            Z24ModeloActivo = A24ModeloActivo;
            Z25ModeloSegmento = A25ModeloSegmento;
            Z84ModeloMarca = A84ModeloMarca;
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

      protected void Load088( )
      {
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound8 = 1;
            A23ModeloDescripcion = T00084_A23ModeloDescripcion[0];
            AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
            A24ModeloActivo = T00084_A24ModeloActivo[0];
            AssignAttri("", false, "A24ModeloActivo", A24ModeloActivo);
            A25ModeloSegmento = T00084_A25ModeloSegmento[0];
            AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
            A84ModeloMarca = T00084_A84ModeloMarca[0];
            AssignAttri("", false, "A84ModeloMarca", A84ModeloMarca);
            ZM088( -2) ;
         }
         pr_default.close(2);
         OnLoadActions088( ) ;
      }

      protected void OnLoadActions088( )
      {
      }

      protected void CheckExtendedTable088( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A25ModeloSegmento, "AUTO") == 0 ) || ( StringUtil.StrCmp(A25ModeloSegmento, "CAMIONETA") == 0 ) || ( StringUtil.StrCmp(A25ModeloSegmento, "CAMIÓN") == 0 ) || ( StringUtil.StrCmp(A25ModeloSegmento, "AGRÍCOLA") == 0 ) || ( StringUtil.StrCmp(A25ModeloSegmento, "INDUSTRIAL") == 0 ) || ( StringUtil.StrCmp(A25ModeloSegmento, "OTR") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Modelo Segmento", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "MODELOSEGMENTO");
            AnyError = 1;
            GX_FocusControl = cmbModeloSegmento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors088( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey088( )
      {
         /* Using cursor T00085 */
         pr_default.execute(3, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM088( 2) ;
            RcdFound8 = 1;
            A22ModeloID = T00083_A22ModeloID[0];
            AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
            A23ModeloDescripcion = T00083_A23ModeloDescripcion[0];
            AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
            A24ModeloActivo = T00083_A24ModeloActivo[0];
            AssignAttri("", false, "A24ModeloActivo", A24ModeloActivo);
            A25ModeloSegmento = T00083_A25ModeloSegmento[0];
            AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
            A84ModeloMarca = T00083_A84ModeloMarca[0];
            AssignAttri("", false, "A84ModeloMarca", A84ModeloMarca);
            Z22ModeloID = A22ModeloID;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load088( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey088( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey088( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey088( ) ;
         if ( RcdFound8 == 0 )
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
         RcdFound8 = 0;
         /* Using cursor T00086 */
         pr_default.execute(4, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00086_A22ModeloID[0] < A22ModeloID ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00086_A22ModeloID[0] > A22ModeloID ) ) )
            {
               A22ModeloID = T00086_A22ModeloID[0];
               AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T00087 */
         pr_default.execute(5, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00087_A22ModeloID[0] > A22ModeloID ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00087_A22ModeloID[0] < A22ModeloID ) ) )
            {
               A22ModeloID = T00087_A22ModeloID[0];
               AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey088( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtModeloID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert088( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A22ModeloID != Z22ModeloID )
               {
                  A22ModeloID = Z22ModeloID;
                  AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MODELOID");
                  AnyError = 1;
                  GX_FocusControl = edtModeloID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtModeloID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update088( ) ;
                  GX_FocusControl = edtModeloID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A22ModeloID != Z22ModeloID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtModeloID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert088( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MODELOID");
                     AnyError = 1;
                     GX_FocusControl = edtModeloID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtModeloID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert088( ) ;
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
         if ( A22ModeloID != Z22ModeloID )
         {
            A22ModeloID = Z22ModeloID;
            AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MODELOID");
            AnyError = 1;
            GX_FocusControl = edtModeloID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtModeloID_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "MODELOID");
            AnyError = 1;
            GX_FocusControl = edtModeloID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtModeloDescripcion_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtModeloDescripcion_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd088( ) ;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtModeloDescripcion_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtModeloDescripcion_Internalname;
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
         ScanStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound8 != 0 )
            {
               ScanNext088( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtModeloDescripcion_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd088( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency088( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {A22ModeloID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Modelo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z23ModeloDescripcion, T00082_A23ModeloDescripcion[0]) != 0 ) || ( Z24ModeloActivo != T00082_A24ModeloActivo[0] ) || ( StringUtil.StrCmp(Z25ModeloSegmento, T00082_A25ModeloSegmento[0]) != 0 ) || ( StringUtil.StrCmp(Z84ModeloMarca, T00082_A84ModeloMarca[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z23ModeloDescripcion, T00082_A23ModeloDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("modelo:[seudo value changed for attri]"+"ModeloDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z23ModeloDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T00082_A23ModeloDescripcion[0]);
               }
               if ( Z24ModeloActivo != T00082_A24ModeloActivo[0] )
               {
                  GXUtil.WriteLog("modelo:[seudo value changed for attri]"+"ModeloActivo");
                  GXUtil.WriteLogRaw("Old: ",Z24ModeloActivo);
                  GXUtil.WriteLogRaw("Current: ",T00082_A24ModeloActivo[0]);
               }
               if ( StringUtil.StrCmp(Z25ModeloSegmento, T00082_A25ModeloSegmento[0]) != 0 )
               {
                  GXUtil.WriteLog("modelo:[seudo value changed for attri]"+"ModeloSegmento");
                  GXUtil.WriteLogRaw("Old: ",Z25ModeloSegmento);
                  GXUtil.WriteLogRaw("Current: ",T00082_A25ModeloSegmento[0]);
               }
               if ( StringUtil.StrCmp(Z84ModeloMarca, T00082_A84ModeloMarca[0]) != 0 )
               {
                  GXUtil.WriteLog("modelo:[seudo value changed for attri]"+"ModeloMarca");
                  GXUtil.WriteLogRaw("Old: ",Z84ModeloMarca);
                  GXUtil.WriteLogRaw("Current: ",T00082_A84ModeloMarca[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Modelo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM088( 0) ;
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00088 */
                     pr_default.execute(6, new Object[] {A23ModeloDescripcion, A24ModeloActivo, A25ModeloSegmento, A84ModeloMarca});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T00089 */
                     pr_default.execute(7);
                     A22ModeloID = T00089_A22ModeloID[0];
                     AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Modelo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption080( ) ;
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
               Load088( ) ;
            }
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void Update088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000810 */
                     pr_default.execute(8, new Object[] {A23ModeloDescripcion, A24ModeloActivo, A25ModeloSegmento, A84ModeloMarca, A22ModeloID});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Modelo");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Modelo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate088( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption080( ) ;
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
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void DeferredUpdate088( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls088( ) ;
            AfterConfirm088( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete088( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000811 */
                  pr_default.execute(9, new Object[] {A22ModeloID});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Modelo");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound8 == 0 )
                        {
                           InitAll088( ) ;
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
                        ResetCaption080( ) ;
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel088( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls088( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000812 */
            pr_default.execute(10, new Object[] {A22ModeloID});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Promocion Modelo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000813 */
            pr_default.execute(11, new Object[] {A22ModeloID});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Medida", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel088( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete088( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("modelo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("modelo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart088( )
      {
         /* Using cursor T000814 */
         pr_default.execute(12);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound8 = 1;
            A22ModeloID = T000814_A22ModeloID[0];
            AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext088( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound8 = 1;
            A22ModeloID = T000814_A22ModeloID[0];
            AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
         }
      }

      protected void ScanEnd088( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm088( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert088( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate088( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete088( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete088( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate088( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes088( )
      {
         edtModeloID_Enabled = 0;
         AssignProp("", false, edtModeloID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtModeloID_Enabled), 5, 0), true);
         edtModeloDescripcion_Enabled = 0;
         AssignProp("", false, edtModeloDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtModeloDescripcion_Enabled), 5, 0), true);
         chkModeloActivo.Enabled = 0;
         AssignProp("", false, chkModeloActivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkModeloActivo.Enabled), 5, 0), true);
         cmbModeloSegmento.Enabled = 0;
         AssignProp("", false, cmbModeloSegmento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbModeloSegmento.Enabled), 5, 0), true);
         edtModeloMarca_Enabled = 0;
         AssignProp("", false, edtModeloMarca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtModeloMarca_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes088( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues080( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("modelo.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z22ModeloID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22ModeloID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z23ModeloDescripcion", Z23ModeloDescripcion);
         GxWebStd.gx_boolean_hidden_field( context, "Z24ModeloActivo", Z24ModeloActivo);
         GxWebStd.gx_hidden_field( context, "Z25ModeloSegmento", StringUtil.RTrim( Z25ModeloSegmento));
         GxWebStd.gx_hidden_field( context, "Z84ModeloMarca", Z84ModeloMarca);
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
         return formatLink("modelo.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Modelo" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Modelo", "") ;
      }

      protected void InitializeNonKey088( )
      {
         A23ModeloDescripcion = "";
         AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
         A24ModeloActivo = false;
         AssignAttri("", false, "A24ModeloActivo", A24ModeloActivo);
         A25ModeloSegmento = "";
         AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
         A84ModeloMarca = "";
         AssignAttri("", false, "A84ModeloMarca", A84ModeloMarca);
         Z23ModeloDescripcion = "";
         Z24ModeloActivo = false;
         Z25ModeloSegmento = "";
         Z84ModeloMarca = "";
      }

      protected void InitAll088( )
      {
         A22ModeloID = 0;
         AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
         InitializeNonKey088( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025102815461916", true, true);
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
         context.AddJavascriptSource("modelo.js", "?2025102815461916", false, true);
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
         edtModeloID_Internalname = "MODELOID";
         edtModeloDescripcion_Internalname = "MODELODESCRIPCION";
         chkModeloActivo_Internalname = "MODELOACTIVO";
         cmbModeloSegmento_Internalname = "MODELOSEGMENTO";
         edtModeloMarca_Internalname = "MODELOMARCA";
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
         Form.Caption = context.GetMessage( "Modelo", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtModeloMarca_Jsonclick = "";
         edtModeloMarca_Enabled = 1;
         cmbModeloSegmento_Jsonclick = "";
         cmbModeloSegmento.Enabled = 1;
         chkModeloActivo.Enabled = 1;
         edtModeloDescripcion_Jsonclick = "";
         edtModeloDescripcion_Enabled = 1;
         edtModeloID_Jsonclick = "";
         edtModeloID_Enabled = 1;
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
         chkModeloActivo.Name = "MODELOACTIVO";
         chkModeloActivo.WebTags = "";
         chkModeloActivo.Caption = context.GetMessage( "Activo", "");
         AssignProp("", false, chkModeloActivo_Internalname, "TitleCaption", chkModeloActivo.Caption, true);
         chkModeloActivo.CheckedValue = "false";
         A24ModeloActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A24ModeloActivo));
         AssignAttri("", false, "A24ModeloActivo", A24ModeloActivo);
         cmbModeloSegmento.Name = "MODELOSEGMENTO";
         cmbModeloSegmento.WebTags = "";
         cmbModeloSegmento.addItem("AUTO", context.GetMessage( "AUTO", ""), 0);
         cmbModeloSegmento.addItem("CAMIONETA", context.GetMessage( "CAMIONETA", ""), 0);
         cmbModeloSegmento.addItem("CAMIÓN", context.GetMessage( "CAMIÓN", ""), 0);
         cmbModeloSegmento.addItem("AGRÍCOLA", context.GetMessage( "AGRÍCOLA", ""), 0);
         cmbModeloSegmento.addItem("INDUSTRIAL", context.GetMessage( "INDUSTRIAL", ""), 0);
         cmbModeloSegmento.addItem("OTR", context.GetMessage( "OTR", ""), 0);
         if ( cmbModeloSegmento.ItemCount > 0 )
         {
            A25ModeloSegmento = cmbModeloSegmento.getValidValue(A25ModeloSegmento);
            AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtModeloDescripcion_Internalname;
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

      public void Valid_Modeloid( )
      {
         A25ModeloSegmento = cmbModeloSegmento.CurrentValue;
         cmbModeloSegmento.CurrentValue = A25ModeloSegmento;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A24ModeloActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A24ModeloActivo));
         if ( cmbModeloSegmento.ItemCount > 0 )
         {
            A25ModeloSegmento = cmbModeloSegmento.getValidValue(A25ModeloSegmento);
            cmbModeloSegmento.CurrentValue = A25ModeloSegmento;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbModeloSegmento.CurrentValue = StringUtil.RTrim( A25ModeloSegmento);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
         AssignAttri("", false, "A24ModeloActivo", A24ModeloActivo);
         AssignAttri("", false, "A25ModeloSegmento", StringUtil.RTrim( A25ModeloSegmento));
         cmbModeloSegmento.CurrentValue = StringUtil.RTrim( A25ModeloSegmento);
         AssignProp("", false, cmbModeloSegmento_Internalname, "Values", cmbModeloSegmento.ToJavascriptSource(), true);
         AssignAttri("", false, "A84ModeloMarca", A84ModeloMarca);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z22ModeloID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22ModeloID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23ModeloDescripcion", Z23ModeloDescripcion);
         GxWebStd.gx_hidden_field( context, "Z24ModeloActivo", StringUtil.BoolToStr( Z24ModeloActivo));
         GxWebStd.gx_hidden_field( context, "Z25ModeloSegmento", StringUtil.RTrim( Z25ModeloSegmento));
         GxWebStd.gx_hidden_field( context, "Z84ModeloMarca", Z84ModeloMarca);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A24ModeloActivo","fld":"MODELOACTIVO"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A24ModeloActivo","fld":"MODELOACTIVO"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A24ModeloActivo","fld":"MODELOACTIVO"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A24ModeloActivo","fld":"MODELOACTIVO"}]}""");
         setEventMetadata("VALID_MODELOID","""{"handler":"Valid_Modeloid","iparms":[{"av":"cmbModeloSegmento"},{"av":"A25ModeloSegmento","fld":"MODELOSEGMENTO"},{"av":"A22ModeloID","fld":"MODELOID","pic":"ZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A24ModeloActivo","fld":"MODELOACTIVO"}]""");
         setEventMetadata("VALID_MODELOID",""","oparms":[{"av":"A23ModeloDescripcion","fld":"MODELODESCRIPCION"},{"av":"cmbModeloSegmento"},{"av":"A25ModeloSegmento","fld":"MODELOSEGMENTO"},{"av":"A84ModeloMarca","fld":"MODELOMARCA"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z22ModeloID"},{"av":"Z23ModeloDescripcion"},{"av":"Z24ModeloActivo"},{"av":"Z25ModeloSegmento"},{"av":"Z84ModeloMarca"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A24ModeloActivo","fld":"MODELOACTIVO"}]}""");
         setEventMetadata("VALID_MODELOSEGMENTO","""{"handler":"Valid_Modelosegmento","iparms":[{"av":"A24ModeloActivo","fld":"MODELOACTIVO"}]""");
         setEventMetadata("VALID_MODELOSEGMENTO",""","oparms":[{"av":"A24ModeloActivo","fld":"MODELOACTIVO"}]}""");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z23ModeloDescripcion = "";
         Z25ModeloSegmento = "";
         Z84ModeloMarca = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A25ModeloSegmento = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A23ModeloDescripcion = "";
         A84ModeloMarca = "";
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
         T00084_A22ModeloID = new int[1] ;
         T00084_A23ModeloDescripcion = new string[] {""} ;
         T00084_A24ModeloActivo = new bool[] {false} ;
         T00084_A25ModeloSegmento = new string[] {""} ;
         T00084_A84ModeloMarca = new string[] {""} ;
         T00085_A22ModeloID = new int[1] ;
         T00083_A22ModeloID = new int[1] ;
         T00083_A23ModeloDescripcion = new string[] {""} ;
         T00083_A24ModeloActivo = new bool[] {false} ;
         T00083_A25ModeloSegmento = new string[] {""} ;
         T00083_A84ModeloMarca = new string[] {""} ;
         sMode8 = "";
         T00086_A22ModeloID = new int[1] ;
         T00087_A22ModeloID = new int[1] ;
         T00082_A22ModeloID = new int[1] ;
         T00082_A23ModeloDescripcion = new string[] {""} ;
         T00082_A24ModeloActivo = new bool[] {false} ;
         T00082_A25ModeloSegmento = new string[] {""} ;
         T00082_A84ModeloMarca = new string[] {""} ;
         T00089_A22ModeloID = new int[1] ;
         T000812_A48PromocionModeloID = new int[1] ;
         T000813_A26MedidaID = new int[1] ;
         T000814_A22ModeloID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ23ModeloDescripcion = "";
         ZZ25ModeloSegmento = "";
         ZZ84ModeloMarca = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.modelo__default(),
            new Object[][] {
                new Object[] {
               T00082_A22ModeloID, T00082_A23ModeloDescripcion, T00082_A24ModeloActivo, T00082_A25ModeloSegmento, T00082_A84ModeloMarca
               }
               , new Object[] {
               T00083_A22ModeloID, T00083_A23ModeloDescripcion, T00083_A24ModeloActivo, T00083_A25ModeloSegmento, T00083_A84ModeloMarca
               }
               , new Object[] {
               T00084_A22ModeloID, T00084_A23ModeloDescripcion, T00084_A24ModeloActivo, T00084_A25ModeloSegmento, T00084_A84ModeloMarca
               }
               , new Object[] {
               T00085_A22ModeloID
               }
               , new Object[] {
               T00086_A22ModeloID
               }
               , new Object[] {
               T00087_A22ModeloID
               }
               , new Object[] {
               }
               , new Object[] {
               T00089_A22ModeloID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000812_A48PromocionModeloID
               }
               , new Object[] {
               T000813_A26MedidaID
               }
               , new Object[] {
               T000814_A22ModeloID
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
      private short RcdFound8 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z22ModeloID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A22ModeloID ;
      private int edtModeloID_Enabled ;
      private int edtModeloDescripcion_Enabled ;
      private int edtModeloMarca_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ22ModeloID ;
      private string sPrefix ;
      private string Z25ModeloSegmento ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtModeloID_Internalname ;
      private string A25ModeloSegmento ;
      private string cmbModeloSegmento_Internalname ;
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
      private string edtModeloID_Jsonclick ;
      private string edtModeloDescripcion_Internalname ;
      private string edtModeloDescripcion_Jsonclick ;
      private string chkModeloActivo_Internalname ;
      private string cmbModeloSegmento_Jsonclick ;
      private string edtModeloMarca_Internalname ;
      private string edtModeloMarca_Jsonclick ;
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
      private string sMode8 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ25ModeloSegmento ;
      private bool Z24ModeloActivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A24ModeloActivo ;
      private bool ZZ24ModeloActivo ;
      private string Z23ModeloDescripcion ;
      private string Z84ModeloMarca ;
      private string A23ModeloDescripcion ;
      private string A84ModeloMarca ;
      private string ZZ23ModeloDescripcion ;
      private string ZZ84ModeloMarca ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkModeloActivo ;
      private GXCombobox cmbModeloSegmento ;
      private IDataStoreProvider pr_default ;
      private int[] T00084_A22ModeloID ;
      private string[] T00084_A23ModeloDescripcion ;
      private bool[] T00084_A24ModeloActivo ;
      private string[] T00084_A25ModeloSegmento ;
      private string[] T00084_A84ModeloMarca ;
      private int[] T00085_A22ModeloID ;
      private int[] T00083_A22ModeloID ;
      private string[] T00083_A23ModeloDescripcion ;
      private bool[] T00083_A24ModeloActivo ;
      private string[] T00083_A25ModeloSegmento ;
      private string[] T00083_A84ModeloMarca ;
      private int[] T00086_A22ModeloID ;
      private int[] T00087_A22ModeloID ;
      private int[] T00082_A22ModeloID ;
      private string[] T00082_A23ModeloDescripcion ;
      private bool[] T00082_A24ModeloActivo ;
      private string[] T00082_A25ModeloSegmento ;
      private string[] T00082_A84ModeloMarca ;
      private int[] T00089_A22ModeloID ;
      private int[] T000812_A48PromocionModeloID ;
      private int[] T000813_A26MedidaID ;
      private int[] T000814_A22ModeloID ;
   }

   public class modelo__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00082;
          prmT00082 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT00083;
          prmT00083 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT00084;
          prmT00084 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT00085;
          prmT00085 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT00086;
          prmT00086 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT00087;
          prmT00087 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT00088;
          prmT00088 = new Object[] {
          new ParDef("@ModeloDescripcion",GXType.Char,80,0) ,
          new ParDef("@ModeloActivo",GXType.Byte,4,0) ,
          new ParDef("@ModeloSegmento",GXType.Char,20,0) ,
          new ParDef("@ModeloMarca",GXType.Char,80,0)
          };
          Object[] prmT00089;
          prmT00089 = new Object[] {
          };
          Object[] prmT000810;
          prmT000810 = new Object[] {
          new ParDef("@ModeloDescripcion",GXType.Char,80,0) ,
          new ParDef("@ModeloActivo",GXType.Byte,4,0) ,
          new ParDef("@ModeloSegmento",GXType.Char,20,0) ,
          new ParDef("@ModeloMarca",GXType.Char,80,0) ,
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000811;
          prmT000811 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000812;
          prmT000812 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000813;
          prmT000813 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000814;
          prmT000814 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00082", "SELECT `ModeloID`, `ModeloDescripcion`, `ModeloActivo`, `ModeloSegmento`, `ModeloMarca` FROM `Modelo` WHERE `ModeloID` = @ModeloID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00083", "SELECT `ModeloID`, `ModeloDescripcion`, `ModeloActivo`, `ModeloSegmento`, `ModeloMarca` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00084", "SELECT TM1.`ModeloID`, TM1.`ModeloDescripcion`, TM1.`ModeloActivo`, TM1.`ModeloSegmento`, TM1.`ModeloMarca` FROM `Modelo` TM1 WHERE TM1.`ModeloID` = @ModeloID ORDER BY TM1.`ModeloID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00085", "SELECT `ModeloID` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00086", "SELECT `ModeloID` FROM `Modelo` WHERE ( `ModeloID` > @ModeloID) ORDER BY `ModeloID`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00087", "SELECT `ModeloID` FROM `Modelo` WHERE ( `ModeloID` < @ModeloID) ORDER BY `ModeloID` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00088", "INSERT INTO `Modelo`(`ModeloDescripcion`, `ModeloActivo`, `ModeloSegmento`, `ModeloMarca`) VALUES(@ModeloDescripcion, @ModeloActivo, @ModeloSegmento, @ModeloMarca)", GxErrorMask.GX_NOMASK,prmT00088)
             ,new CursorDef("T00089", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000810", "UPDATE `Modelo` SET `ModeloDescripcion`=@ModeloDescripcion, `ModeloActivo`=@ModeloActivo, `ModeloSegmento`=@ModeloSegmento, `ModeloMarca`=@ModeloMarca  WHERE `ModeloID` = @ModeloID", GxErrorMask.GX_NOMASK,prmT000810)
             ,new CursorDef("T000811", "DELETE FROM `Modelo`  WHERE `ModeloID` = @ModeloID", GxErrorMask.GX_NOMASK,prmT000811)
             ,new CursorDef("T000812", "SELECT `PromocionModeloID` FROM `PromocionModelo` WHERE `ModeloID` = @ModeloID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000812,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000813", "SELECT `MedidaID` FROM `Medida` WHERE `ModeloID` = @ModeloID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000813,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000814", "SELECT `ModeloID` FROM `Modelo` ORDER BY `ModeloID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000814,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
