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
   public class medida : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A22ModeloID = (int)(Math.Round(NumberUtil.Val( GetPar( "ModeloID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A22ModeloID) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Medida", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMedidaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public medida( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public medida( IGxContext context )
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
         cmbModeloSegmento = new GXCombobox();
         chkMedidaActivo = new GXCheckbox();
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
         A86MedidaActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A86MedidaActivo));
         AssignAttri("", false, "A86MedidaActivo", A86MedidaActivo);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Medida", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Medida.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Medida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Medida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Medida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Medida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Medida.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMedidaID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMedidaID_Internalname, context.GetMessage( "ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedidaID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26MedidaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtMedidaID_Enabled!=0) ? context.localUtil.Format( (decimal)(A26MedidaID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A26MedidaID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedidaID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMedidaID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Medida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedidaCodigo_Internalname, StringUtil.RTrim( A27MedidaCodigo), StringUtil.RTrim( context.localUtil.Format( A27MedidaCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedidaCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMedidaCodigo_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Medida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedidaDescripcion_Internalname, A28MedidaDescripcion, StringUtil.RTrim( context.localUtil.Format( A28MedidaDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedidaDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMedidaDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Medida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtModeloID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22ModeloID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtModeloID_Enabled!=0) ? context.localUtil.Format( (decimal)(A22ModeloID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A22ModeloID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtModeloID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtModeloID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Medida.htm");
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
         GxWebStd.gx_label_element( context, edtMedidaRin_Internalname, context.GetMessage( "Rin", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedidaRin_Internalname, StringUtil.RTrim( A74MedidaRin), StringUtil.RTrim( context.localUtil.Format( A74MedidaRin, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedidaRin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMedidaRin_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Medida.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtModeloDescripcion_Internalname, A23ModeloDescripcion, StringUtil.RTrim( context.localUtil.Format( A23ModeloDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtModeloDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtModeloDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Medida.htm");
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
         GxWebStd.gx_label_element( context, cmbModeloSegmento_Internalname, context.GetMessage( "Modelo Segmento", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbModeloSegmento, cmbModeloSegmento_Internalname, StringUtil.RTrim( A25ModeloSegmento), 1, cmbModeloSegmento_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbModeloSegmento.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_Medida.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMedidaNombreCompleto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMedidaNombreCompleto_Internalname, context.GetMessage( "Nombre Completo", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedidaNombreCompleto_Internalname, A76MedidaNombreCompleto, StringUtil.RTrim( context.localUtil.Format( A76MedidaNombreCompleto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedidaNombreCompleto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMedidaNombreCompleto_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Medida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMedidaComentario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMedidaComentario_Internalname, context.GetMessage( "Comentario", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedidaComentario_Internalname, A85MedidaComentario, StringUtil.RTrim( context.localUtil.Format( A85MedidaComentario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedidaComentario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMedidaComentario_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Medida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkMedidaActivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkMedidaActivo_Internalname, context.GetMessage( "Activo", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkMedidaActivo_Internalname, StringUtil.BoolToStr( A86MedidaActivo), "", context.GetMessage( "Activo", ""), 1, chkMedidaActivo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(79, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,79);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Medida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Medida.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Medida.htm");
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
            Z26MedidaID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z26MedidaID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z27MedidaCodigo = cgiGet( "Z27MedidaCodigo");
            Z28MedidaDescripcion = cgiGet( "Z28MedidaDescripcion");
            Z74MedidaRin = cgiGet( "Z74MedidaRin");
            Z85MedidaComentario = cgiGet( "Z85MedidaComentario");
            Z86MedidaActivo = StringUtil.StrToBool( cgiGet( "Z86MedidaActivo"));
            Z22ModeloID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z22ModeloID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
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
            A27MedidaCodigo = cgiGet( edtMedidaCodigo_Internalname);
            AssignAttri("", false, "A27MedidaCodigo", A27MedidaCodigo);
            A28MedidaDescripcion = cgiGet( edtMedidaDescripcion_Internalname);
            AssignAttri("", false, "A28MedidaDescripcion", A28MedidaDescripcion);
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
            A74MedidaRin = cgiGet( edtMedidaRin_Internalname);
            AssignAttri("", false, "A74MedidaRin", A74MedidaRin);
            A23ModeloDescripcion = cgiGet( edtModeloDescripcion_Internalname);
            AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
            cmbModeloSegmento.CurrentValue = cgiGet( cmbModeloSegmento_Internalname);
            A25ModeloSegmento = cgiGet( cmbModeloSegmento_Internalname);
            AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
            A76MedidaNombreCompleto = cgiGet( edtMedidaNombreCompleto_Internalname);
            AssignAttri("", false, "A76MedidaNombreCompleto", A76MedidaNombreCompleto);
            A85MedidaComentario = cgiGet( edtMedidaComentario_Internalname);
            AssignAttri("", false, "A85MedidaComentario", A85MedidaComentario);
            A86MedidaActivo = StringUtil.StrToBool( cgiGet( chkMedidaActivo_Internalname));
            AssignAttri("", false, "A86MedidaActivo", A86MedidaActivo);
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
               A26MedidaID = (int)(Math.Round(NumberUtil.Val( GetPar( "MedidaID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
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
               InitAll099( ) ;
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
         DisableAttributes099( ) ;
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

      protected void ResetCaption090( )
      {
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z27MedidaCodigo = T00093_A27MedidaCodigo[0];
               Z28MedidaDescripcion = T00093_A28MedidaDescripcion[0];
               Z74MedidaRin = T00093_A74MedidaRin[0];
               Z85MedidaComentario = T00093_A85MedidaComentario[0];
               Z86MedidaActivo = T00093_A86MedidaActivo[0];
               Z22ModeloID = T00093_A22ModeloID[0];
            }
            else
            {
               Z27MedidaCodigo = A27MedidaCodigo;
               Z28MedidaDescripcion = A28MedidaDescripcion;
               Z74MedidaRin = A74MedidaRin;
               Z85MedidaComentario = A85MedidaComentario;
               Z86MedidaActivo = A86MedidaActivo;
               Z22ModeloID = A22ModeloID;
            }
         }
         if ( GX_JID == -2 )
         {
            Z26MedidaID = A26MedidaID;
            Z27MedidaCodigo = A27MedidaCodigo;
            Z28MedidaDescripcion = A28MedidaDescripcion;
            Z74MedidaRin = A74MedidaRin;
            Z85MedidaComentario = A85MedidaComentario;
            Z86MedidaActivo = A86MedidaActivo;
            Z22ModeloID = A22ModeloID;
            Z23ModeloDescripcion = A23ModeloDescripcion;
            Z25ModeloSegmento = A25ModeloSegmento;
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

      protected void Load099( )
      {
         /* Using cursor T00095 */
         pr_default.execute(3, new Object[] {A26MedidaID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
            A27MedidaCodigo = T00095_A27MedidaCodigo[0];
            AssignAttri("", false, "A27MedidaCodigo", A27MedidaCodigo);
            A28MedidaDescripcion = T00095_A28MedidaDescripcion[0];
            AssignAttri("", false, "A28MedidaDescripcion", A28MedidaDescripcion);
            A74MedidaRin = T00095_A74MedidaRin[0];
            AssignAttri("", false, "A74MedidaRin", A74MedidaRin);
            A23ModeloDescripcion = T00095_A23ModeloDescripcion[0];
            AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
            A25ModeloSegmento = T00095_A25ModeloSegmento[0];
            AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
            A85MedidaComentario = T00095_A85MedidaComentario[0];
            AssignAttri("", false, "A85MedidaComentario", A85MedidaComentario);
            A86MedidaActivo = T00095_A86MedidaActivo[0];
            AssignAttri("", false, "A86MedidaActivo", A86MedidaActivo);
            A22ModeloID = T00095_A22ModeloID[0];
            AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
            ZM099( -2) ;
         }
         pr_default.close(3);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
         A76MedidaNombreCompleto = StringUtil.Trim( A23ModeloDescripcion) + " / " + StringUtil.Trim( A28MedidaDescripcion) + " / " + StringUtil.Trim( A27MedidaCodigo);
         AssignAttri("", false, "A76MedidaNombreCompleto", A76MedidaNombreCompleto);
      }

      protected void CheckExtendedTable099( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Modelo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MODELOID");
            AnyError = 1;
            GX_FocusControl = edtModeloID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A23ModeloDescripcion = T00094_A23ModeloDescripcion[0];
         AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
         A25ModeloSegmento = T00094_A25ModeloSegmento[0];
         AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
         pr_default.close(2);
         A76MedidaNombreCompleto = StringUtil.Trim( A23ModeloDescripcion) + " / " + StringUtil.Trim( A28MedidaDescripcion) + " / " + StringUtil.Trim( A27MedidaCodigo);
         AssignAttri("", false, "A76MedidaNombreCompleto", A76MedidaNombreCompleto);
      }

      protected void CloseExtendedTableCursors099( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A22ModeloID )
      {
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Modelo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MODELOID");
            AnyError = 1;
            GX_FocusControl = edtModeloID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A23ModeloDescripcion = T00096_A23ModeloDescripcion[0];
         AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
         A25ModeloSegmento = T00096_A25ModeloSegmento[0];
         AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A23ModeloDescripcion)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A25ModeloSegmento))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey099( )
      {
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A26MedidaID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A26MedidaID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM099( 2) ;
            RcdFound9 = 1;
            A26MedidaID = T00093_A26MedidaID[0];
            AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
            A27MedidaCodigo = T00093_A27MedidaCodigo[0];
            AssignAttri("", false, "A27MedidaCodigo", A27MedidaCodigo);
            A28MedidaDescripcion = T00093_A28MedidaDescripcion[0];
            AssignAttri("", false, "A28MedidaDescripcion", A28MedidaDescripcion);
            A74MedidaRin = T00093_A74MedidaRin[0];
            AssignAttri("", false, "A74MedidaRin", A74MedidaRin);
            A85MedidaComentario = T00093_A85MedidaComentario[0];
            AssignAttri("", false, "A85MedidaComentario", A85MedidaComentario);
            A86MedidaActivo = T00093_A86MedidaActivo[0];
            AssignAttri("", false, "A86MedidaActivo", A86MedidaActivo);
            A22ModeloID = T00093_A22ModeloID[0];
            AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
            Z26MedidaID = A26MedidaID;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
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
         RcdFound9 = 0;
         /* Using cursor T00098 */
         pr_default.execute(6, new Object[] {A26MedidaID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00098_A26MedidaID[0] < A26MedidaID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00098_A26MedidaID[0] > A26MedidaID ) ) )
            {
               A26MedidaID = T00098_A26MedidaID[0];
               AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T00099 */
         pr_default.execute(7, new Object[] {A26MedidaID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00099_A26MedidaID[0] > A26MedidaID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00099_A26MedidaID[0] < A26MedidaID ) ) )
            {
               A26MedidaID = T00099_A26MedidaID[0];
               AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMedidaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert099( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A26MedidaID != Z26MedidaID )
               {
                  A26MedidaID = Z26MedidaID;
                  AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MEDIDAID");
                  AnyError = 1;
                  GX_FocusControl = edtMedidaID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMedidaID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update099( ) ;
                  GX_FocusControl = edtMedidaID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A26MedidaID != Z26MedidaID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtMedidaID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert099( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MEDIDAID");
                     AnyError = 1;
                     GX_FocusControl = edtMedidaID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtMedidaID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert099( ) ;
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
         if ( A26MedidaID != Z26MedidaID )
         {
            A26MedidaID = Z26MedidaID;
            AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MEDIDAID");
            AnyError = 1;
            GX_FocusControl = edtMedidaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMedidaID_Internalname;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "MEDIDAID");
            AnyError = 1;
            GX_FocusControl = edtMedidaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtMedidaCodigo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMedidaCodigo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd099( ) ;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMedidaCodigo_Internalname;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMedidaCodigo_Internalname;
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
         ScanStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound9 != 0 )
            {
               ScanNext099( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMedidaCodigo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd099( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A26MedidaID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Medida"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z27MedidaCodigo, T00092_A27MedidaCodigo[0]) != 0 ) || ( StringUtil.StrCmp(Z28MedidaDescripcion, T00092_A28MedidaDescripcion[0]) != 0 ) || ( StringUtil.StrCmp(Z74MedidaRin, T00092_A74MedidaRin[0]) != 0 ) || ( StringUtil.StrCmp(Z85MedidaComentario, T00092_A85MedidaComentario[0]) != 0 ) || ( Z86MedidaActivo != T00092_A86MedidaActivo[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z22ModeloID != T00092_A22ModeloID[0] ) )
            {
               if ( StringUtil.StrCmp(Z27MedidaCodigo, T00092_A27MedidaCodigo[0]) != 0 )
               {
                  GXUtil.WriteLog("medida:[seudo value changed for attri]"+"MedidaCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z27MedidaCodigo);
                  GXUtil.WriteLogRaw("Current: ",T00092_A27MedidaCodigo[0]);
               }
               if ( StringUtil.StrCmp(Z28MedidaDescripcion, T00092_A28MedidaDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("medida:[seudo value changed for attri]"+"MedidaDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z28MedidaDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T00092_A28MedidaDescripcion[0]);
               }
               if ( StringUtil.StrCmp(Z74MedidaRin, T00092_A74MedidaRin[0]) != 0 )
               {
                  GXUtil.WriteLog("medida:[seudo value changed for attri]"+"MedidaRin");
                  GXUtil.WriteLogRaw("Old: ",Z74MedidaRin);
                  GXUtil.WriteLogRaw("Current: ",T00092_A74MedidaRin[0]);
               }
               if ( StringUtil.StrCmp(Z85MedidaComentario, T00092_A85MedidaComentario[0]) != 0 )
               {
                  GXUtil.WriteLog("medida:[seudo value changed for attri]"+"MedidaComentario");
                  GXUtil.WriteLogRaw("Old: ",Z85MedidaComentario);
                  GXUtil.WriteLogRaw("Current: ",T00092_A85MedidaComentario[0]);
               }
               if ( Z86MedidaActivo != T00092_A86MedidaActivo[0] )
               {
                  GXUtil.WriteLog("medida:[seudo value changed for attri]"+"MedidaActivo");
                  GXUtil.WriteLogRaw("Old: ",Z86MedidaActivo);
                  GXUtil.WriteLogRaw("Current: ",T00092_A86MedidaActivo[0]);
               }
               if ( Z22ModeloID != T00092_A22ModeloID[0] )
               {
                  GXUtil.WriteLog("medida:[seudo value changed for attri]"+"ModeloID");
                  GXUtil.WriteLogRaw("Old: ",Z22ModeloID);
                  GXUtil.WriteLogRaw("Current: ",T00092_A22ModeloID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Medida"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM099( 0) ;
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000910 */
                     pr_default.execute(8, new Object[] {A27MedidaCodigo, A28MedidaDescripcion, A74MedidaRin, A85MedidaComentario, A86MedidaActivo, A22ModeloID});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000911 */
                     pr_default.execute(9);
                     A26MedidaID = T000911_A26MedidaID[0];
                     AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Medida");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption090( ) ;
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
               Load099( ) ;
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void Update099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000912 */
                     pr_default.execute(10, new Object[] {A27MedidaCodigo, A28MedidaDescripcion, A74MedidaRin, A85MedidaComentario, A86MedidaActivo, A22ModeloID, A26MedidaID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Medida");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Medida"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate099( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption090( ) ;
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
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void DeferredUpdate099( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls099( ) ;
            AfterConfirm099( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete099( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000913 */
                  pr_default.execute(11, new Object[] {A26MedidaID});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Medida");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound9 == 0 )
                        {
                           InitAll099( ) ;
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
                        ResetCaption090( ) ;
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel099( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000914 */
            pr_default.execute(12, new Object[] {A22ModeloID});
            A23ModeloDescripcion = T000914_A23ModeloDescripcion[0];
            AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
            A25ModeloSegmento = T000914_A25ModeloSegmento[0];
            AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
            pr_default.close(12);
            A76MedidaNombreCompleto = StringUtil.Trim( A23ModeloDescripcion) + " / " + StringUtil.Trim( A28MedidaDescripcion) + " / " + StringUtil.Trim( A27MedidaCodigo);
            AssignAttri("", false, "A76MedidaNombreCompleto", A76MedidaNombreCompleto);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000915 */
            pr_default.execute(13, new Object[] {A26MedidaID});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Factura Medida", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel099( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete099( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("medida",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("medida",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart099( )
      {
         /* Using cursor T000916 */
         pr_default.execute(14);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound9 = 1;
            A26MedidaID = T000916_A26MedidaID[0];
            AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound9 = 1;
            A26MedidaID = T000916_A26MedidaID[0];
            AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
         }
      }

      protected void ScanEnd099( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm099( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert099( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate099( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete099( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete099( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate099( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes099( )
      {
         edtMedidaID_Enabled = 0;
         AssignProp("", false, edtMedidaID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidaID_Enabled), 5, 0), true);
         edtMedidaCodigo_Enabled = 0;
         AssignProp("", false, edtMedidaCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidaCodigo_Enabled), 5, 0), true);
         edtMedidaDescripcion_Enabled = 0;
         AssignProp("", false, edtMedidaDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidaDescripcion_Enabled), 5, 0), true);
         edtModeloID_Enabled = 0;
         AssignProp("", false, edtModeloID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtModeloID_Enabled), 5, 0), true);
         edtMedidaRin_Enabled = 0;
         AssignProp("", false, edtMedidaRin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidaRin_Enabled), 5, 0), true);
         edtModeloDescripcion_Enabled = 0;
         AssignProp("", false, edtModeloDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtModeloDescripcion_Enabled), 5, 0), true);
         cmbModeloSegmento.Enabled = 0;
         AssignProp("", false, cmbModeloSegmento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbModeloSegmento.Enabled), 5, 0), true);
         edtMedidaNombreCompleto_Enabled = 0;
         AssignProp("", false, edtMedidaNombreCompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidaNombreCompleto_Enabled), 5, 0), true);
         edtMedidaComentario_Enabled = 0;
         AssignProp("", false, edtMedidaComentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidaComentario_Enabled), 5, 0), true);
         chkMedidaActivo.Enabled = 0;
         AssignProp("", false, chkMedidaActivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkMedidaActivo.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues090( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("medida.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z26MedidaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26MedidaID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z27MedidaCodigo", StringUtil.RTrim( Z27MedidaCodigo));
         GxWebStd.gx_hidden_field( context, "Z28MedidaDescripcion", Z28MedidaDescripcion);
         GxWebStd.gx_hidden_field( context, "Z74MedidaRin", StringUtil.RTrim( Z74MedidaRin));
         GxWebStd.gx_hidden_field( context, "Z85MedidaComentario", Z85MedidaComentario);
         GxWebStd.gx_boolean_hidden_field( context, "Z86MedidaActivo", Z86MedidaActivo);
         GxWebStd.gx_hidden_field( context, "Z22ModeloID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22ModeloID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("medida.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Medida" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Medida", "") ;
      }

      protected void InitializeNonKey099( )
      {
         A76MedidaNombreCompleto = "";
         AssignAttri("", false, "A76MedidaNombreCompleto", A76MedidaNombreCompleto);
         A27MedidaCodigo = "";
         AssignAttri("", false, "A27MedidaCodigo", A27MedidaCodigo);
         A28MedidaDescripcion = "";
         AssignAttri("", false, "A28MedidaDescripcion", A28MedidaDescripcion);
         A22ModeloID = 0;
         AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
         A74MedidaRin = "";
         AssignAttri("", false, "A74MedidaRin", A74MedidaRin);
         A23ModeloDescripcion = "";
         AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
         A25ModeloSegmento = "";
         AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
         A85MedidaComentario = "";
         AssignAttri("", false, "A85MedidaComentario", A85MedidaComentario);
         A86MedidaActivo = false;
         AssignAttri("", false, "A86MedidaActivo", A86MedidaActivo);
         Z27MedidaCodigo = "";
         Z28MedidaDescripcion = "";
         Z74MedidaRin = "";
         Z85MedidaComentario = "";
         Z86MedidaActivo = false;
         Z22ModeloID = 0;
      }

      protected void InitAll099( )
      {
         A26MedidaID = 0;
         AssignAttri("", false, "A26MedidaID", StringUtil.LTrimStr( (decimal)(A26MedidaID), 9, 0));
         InitializeNonKey099( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025102815461954", true, true);
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
         context.AddJavascriptSource("medida.js", "?2025102815461954", false, true);
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
         edtMedidaID_Internalname = "MEDIDAID";
         edtMedidaCodigo_Internalname = "MEDIDACODIGO";
         edtMedidaDescripcion_Internalname = "MEDIDADESCRIPCION";
         edtModeloID_Internalname = "MODELOID";
         edtMedidaRin_Internalname = "MEDIDARIN";
         edtModeloDescripcion_Internalname = "MODELODESCRIPCION";
         cmbModeloSegmento_Internalname = "MODELOSEGMENTO";
         edtMedidaNombreCompleto_Internalname = "MEDIDANOMBRECOMPLETO";
         edtMedidaComentario_Internalname = "MEDIDACOMENTARIO";
         chkMedidaActivo_Internalname = "MEDIDAACTIVO";
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
         Form.Caption = context.GetMessage( "Medida", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkMedidaActivo.Enabled = 1;
         edtMedidaComentario_Jsonclick = "";
         edtMedidaComentario_Enabled = 1;
         edtMedidaNombreCompleto_Jsonclick = "";
         edtMedidaNombreCompleto_Enabled = 0;
         cmbModeloSegmento_Jsonclick = "";
         cmbModeloSegmento.Enabled = 0;
         edtModeloDescripcion_Jsonclick = "";
         edtModeloDescripcion_Enabled = 0;
         edtMedidaRin_Jsonclick = "";
         edtMedidaRin_Enabled = 1;
         edtModeloID_Jsonclick = "";
         edtModeloID_Enabled = 1;
         edtMedidaDescripcion_Jsonclick = "";
         edtMedidaDescripcion_Enabled = 1;
         edtMedidaCodigo_Jsonclick = "";
         edtMedidaCodigo_Enabled = 1;
         edtMedidaID_Jsonclick = "";
         edtMedidaID_Enabled = 1;
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
         chkMedidaActivo.Name = "MEDIDAACTIVO";
         chkMedidaActivo.WebTags = "";
         chkMedidaActivo.Caption = context.GetMessage( "Activo", "");
         AssignProp("", false, chkMedidaActivo_Internalname, "TitleCaption", chkMedidaActivo.Caption, true);
         chkMedidaActivo.CheckedValue = "false";
         A86MedidaActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A86MedidaActivo));
         AssignAttri("", false, "A86MedidaActivo", A86MedidaActivo);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtMedidaCodigo_Internalname;
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

      public void Valid_Medidaid( )
      {
         A25ModeloSegmento = cmbModeloSegmento.CurrentValue;
         cmbModeloSegmento.CurrentValue = A25ModeloSegmento;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A86MedidaActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A86MedidaActivo));
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
         AssignAttri("", false, "A27MedidaCodigo", StringUtil.RTrim( A27MedidaCodigo));
         AssignAttri("", false, "A28MedidaDescripcion", A28MedidaDescripcion);
         AssignAttri("", false, "A22ModeloID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22ModeloID), 9, 0, ".", "")));
         AssignAttri("", false, "A74MedidaRin", StringUtil.RTrim( A74MedidaRin));
         AssignAttri("", false, "A85MedidaComentario", A85MedidaComentario);
         AssignAttri("", false, "A86MedidaActivo", A86MedidaActivo);
         AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
         AssignAttri("", false, "A25ModeloSegmento", StringUtil.RTrim( A25ModeloSegmento));
         cmbModeloSegmento.CurrentValue = StringUtil.RTrim( A25ModeloSegmento);
         AssignProp("", false, cmbModeloSegmento_Internalname, "Values", cmbModeloSegmento.ToJavascriptSource(), true);
         AssignAttri("", false, "A76MedidaNombreCompleto", A76MedidaNombreCompleto);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z26MedidaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26MedidaID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z27MedidaCodigo", StringUtil.RTrim( Z27MedidaCodigo));
         GxWebStd.gx_hidden_field( context, "Z28MedidaDescripcion", Z28MedidaDescripcion);
         GxWebStd.gx_hidden_field( context, "Z22ModeloID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22ModeloID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z74MedidaRin", StringUtil.RTrim( Z74MedidaRin));
         GxWebStd.gx_hidden_field( context, "Z85MedidaComentario", Z85MedidaComentario);
         GxWebStd.gx_hidden_field( context, "Z86MedidaActivo", StringUtil.BoolToStr( Z86MedidaActivo));
         GxWebStd.gx_hidden_field( context, "Z23ModeloDescripcion", Z23ModeloDescripcion);
         GxWebStd.gx_hidden_field( context, "Z25ModeloSegmento", StringUtil.RTrim( Z25ModeloSegmento));
         GxWebStd.gx_hidden_field( context, "Z76MedidaNombreCompleto", Z76MedidaNombreCompleto);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Modeloid( )
      {
         A25ModeloSegmento = cmbModeloSegmento.CurrentValue;
         cmbModeloSegmento.CurrentValue = A25ModeloSegmento;
         /* Using cursor T000914 */
         pr_default.execute(12, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Modelo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MODELOID");
            AnyError = 1;
            GX_FocusControl = edtModeloID_Internalname;
         }
         A23ModeloDescripcion = T000914_A23ModeloDescripcion[0];
         A25ModeloSegmento = T000914_A25ModeloSegmento[0];
         cmbModeloSegmento.CurrentValue = A25ModeloSegmento;
         pr_default.close(12);
         A76MedidaNombreCompleto = StringUtil.Trim( A23ModeloDescripcion) + " / " + StringUtil.Trim( A28MedidaDescripcion) + " / " + StringUtil.Trim( A27MedidaCodigo);
         dynload_actions( ) ;
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
         AssignAttri("", false, "A25ModeloSegmento", StringUtil.RTrim( A25ModeloSegmento));
         cmbModeloSegmento.CurrentValue = StringUtil.RTrim( A25ModeloSegmento);
         AssignProp("", false, cmbModeloSegmento_Internalname, "Values", cmbModeloSegmento.ToJavascriptSource(), true);
         AssignAttri("", false, "A76MedidaNombreCompleto", A76MedidaNombreCompleto);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A86MedidaActivo","fld":"MEDIDAACTIVO"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A86MedidaActivo","fld":"MEDIDAACTIVO"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A86MedidaActivo","fld":"MEDIDAACTIVO"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A86MedidaActivo","fld":"MEDIDAACTIVO"}]}""");
         setEventMetadata("VALID_MEDIDAID","""{"handler":"Valid_Medidaid","iparms":[{"av":"cmbModeloSegmento"},{"av":"A25ModeloSegmento","fld":"MODELOSEGMENTO"},{"av":"A26MedidaID","fld":"MEDIDAID","pic":"ZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A86MedidaActivo","fld":"MEDIDAACTIVO"}]""");
         setEventMetadata("VALID_MEDIDAID",""","oparms":[{"av":"A27MedidaCodigo","fld":"MEDIDACODIGO"},{"av":"A28MedidaDescripcion","fld":"MEDIDADESCRIPCION"},{"av":"A22ModeloID","fld":"MODELOID","pic":"ZZZZZZZZ9"},{"av":"A74MedidaRin","fld":"MEDIDARIN"},{"av":"A85MedidaComentario","fld":"MEDIDACOMENTARIO"},{"av":"A23ModeloDescripcion","fld":"MODELODESCRIPCION"},{"av":"cmbModeloSegmento"},{"av":"A25ModeloSegmento","fld":"MODELOSEGMENTO"},{"av":"A76MedidaNombreCompleto","fld":"MEDIDANOMBRECOMPLETO"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z26MedidaID"},{"av":"Z27MedidaCodigo"},{"av":"Z28MedidaDescripcion"},{"av":"Z22ModeloID"},{"av":"Z74MedidaRin"},{"av":"Z85MedidaComentario"},{"av":"Z86MedidaActivo"},{"av":"Z23ModeloDescripcion"},{"av":"Z25ModeloSegmento"},{"av":"Z76MedidaNombreCompleto"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A86MedidaActivo","fld":"MEDIDAACTIVO"}]}""");
         setEventMetadata("VALID_MEDIDACODIGO","""{"handler":"Valid_Medidacodigo","iparms":[{"av":"A86MedidaActivo","fld":"MEDIDAACTIVO"}]""");
         setEventMetadata("VALID_MEDIDACODIGO",""","oparms":[{"av":"A86MedidaActivo","fld":"MEDIDAACTIVO"}]}""");
         setEventMetadata("VALID_MEDIDADESCRIPCION","""{"handler":"Valid_Medidadescripcion","iparms":[{"av":"A86MedidaActivo","fld":"MEDIDAACTIVO"}]""");
         setEventMetadata("VALID_MEDIDADESCRIPCION",""","oparms":[{"av":"A86MedidaActivo","fld":"MEDIDAACTIVO"}]}""");
         setEventMetadata("VALID_MODELOID","""{"handler":"Valid_Modeloid","iparms":[{"av":"A22ModeloID","fld":"MODELOID","pic":"ZZZZZZZZ9"},{"av":"A23ModeloDescripcion","fld":"MODELODESCRIPCION"},{"av":"A28MedidaDescripcion","fld":"MEDIDADESCRIPCION"},{"av":"A27MedidaCodigo","fld":"MEDIDACODIGO"},{"av":"cmbModeloSegmento"},{"av":"A25ModeloSegmento","fld":"MODELOSEGMENTO"},{"av":"A76MedidaNombreCompleto","fld":"MEDIDANOMBRECOMPLETO"},{"av":"A86MedidaActivo","fld":"MEDIDAACTIVO"}]""");
         setEventMetadata("VALID_MODELOID",""","oparms":[{"av":"A23ModeloDescripcion","fld":"MODELODESCRIPCION"},{"av":"cmbModeloSegmento"},{"av":"A25ModeloSegmento","fld":"MODELOSEGMENTO"},{"av":"A76MedidaNombreCompleto","fld":"MEDIDANOMBRECOMPLETO"},{"av":"A86MedidaActivo","fld":"MEDIDAACTIVO"}]}""");
         setEventMetadata("VALID_MODELODESCRIPCION","""{"handler":"Valid_Modelodescripcion","iparms":[{"av":"A86MedidaActivo","fld":"MEDIDAACTIVO"}]""");
         setEventMetadata("VALID_MODELODESCRIPCION",""","oparms":[{"av":"A86MedidaActivo","fld":"MEDIDAACTIVO"}]}""");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z27MedidaCodigo = "";
         Z28MedidaDescripcion = "";
         Z74MedidaRin = "";
         Z85MedidaComentario = "";
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
         A27MedidaCodigo = "";
         A28MedidaDescripcion = "";
         A74MedidaRin = "";
         A23ModeloDescripcion = "";
         A76MedidaNombreCompleto = "";
         A85MedidaComentario = "";
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
         Z23ModeloDescripcion = "";
         Z25ModeloSegmento = "";
         T00095_A26MedidaID = new int[1] ;
         T00095_A27MedidaCodigo = new string[] {""} ;
         T00095_A28MedidaDescripcion = new string[] {""} ;
         T00095_A74MedidaRin = new string[] {""} ;
         T00095_A23ModeloDescripcion = new string[] {""} ;
         T00095_A25ModeloSegmento = new string[] {""} ;
         T00095_A85MedidaComentario = new string[] {""} ;
         T00095_A86MedidaActivo = new bool[] {false} ;
         T00095_A22ModeloID = new int[1] ;
         T00094_A23ModeloDescripcion = new string[] {""} ;
         T00094_A25ModeloSegmento = new string[] {""} ;
         T00096_A23ModeloDescripcion = new string[] {""} ;
         T00096_A25ModeloSegmento = new string[] {""} ;
         T00097_A26MedidaID = new int[1] ;
         T00093_A26MedidaID = new int[1] ;
         T00093_A27MedidaCodigo = new string[] {""} ;
         T00093_A28MedidaDescripcion = new string[] {""} ;
         T00093_A74MedidaRin = new string[] {""} ;
         T00093_A85MedidaComentario = new string[] {""} ;
         T00093_A86MedidaActivo = new bool[] {false} ;
         T00093_A22ModeloID = new int[1] ;
         sMode9 = "";
         T00098_A26MedidaID = new int[1] ;
         T00099_A26MedidaID = new int[1] ;
         T00092_A26MedidaID = new int[1] ;
         T00092_A27MedidaCodigo = new string[] {""} ;
         T00092_A28MedidaDescripcion = new string[] {""} ;
         T00092_A74MedidaRin = new string[] {""} ;
         T00092_A85MedidaComentario = new string[] {""} ;
         T00092_A86MedidaActivo = new bool[] {false} ;
         T00092_A22ModeloID = new int[1] ;
         T000911_A26MedidaID = new int[1] ;
         T000914_A23ModeloDescripcion = new string[] {""} ;
         T000914_A25ModeloSegmento = new string[] {""} ;
         T000915_A77FacturaMedidaID = new int[1] ;
         T000916_A26MedidaID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Z76MedidaNombreCompleto = "";
         ZZ27MedidaCodigo = "";
         ZZ28MedidaDescripcion = "";
         ZZ74MedidaRin = "";
         ZZ85MedidaComentario = "";
         ZZ23ModeloDescripcion = "";
         ZZ25ModeloSegmento = "";
         ZZ76MedidaNombreCompleto = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.medida__default(),
            new Object[][] {
                new Object[] {
               T00092_A26MedidaID, T00092_A27MedidaCodigo, T00092_A28MedidaDescripcion, T00092_A74MedidaRin, T00092_A85MedidaComentario, T00092_A86MedidaActivo, T00092_A22ModeloID
               }
               , new Object[] {
               T00093_A26MedidaID, T00093_A27MedidaCodigo, T00093_A28MedidaDescripcion, T00093_A74MedidaRin, T00093_A85MedidaComentario, T00093_A86MedidaActivo, T00093_A22ModeloID
               }
               , new Object[] {
               T00094_A23ModeloDescripcion, T00094_A25ModeloSegmento
               }
               , new Object[] {
               T00095_A26MedidaID, T00095_A27MedidaCodigo, T00095_A28MedidaDescripcion, T00095_A74MedidaRin, T00095_A23ModeloDescripcion, T00095_A25ModeloSegmento, T00095_A85MedidaComentario, T00095_A86MedidaActivo, T00095_A22ModeloID
               }
               , new Object[] {
               T00096_A23ModeloDescripcion, T00096_A25ModeloSegmento
               }
               , new Object[] {
               T00097_A26MedidaID
               }
               , new Object[] {
               T00098_A26MedidaID
               }
               , new Object[] {
               T00099_A26MedidaID
               }
               , new Object[] {
               }
               , new Object[] {
               T000911_A26MedidaID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000914_A23ModeloDescripcion, T000914_A25ModeloSegmento
               }
               , new Object[] {
               T000915_A77FacturaMedidaID
               }
               , new Object[] {
               T000916_A26MedidaID
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
      private short RcdFound9 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z26MedidaID ;
      private int Z22ModeloID ;
      private int A22ModeloID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A26MedidaID ;
      private int edtMedidaID_Enabled ;
      private int edtMedidaCodigo_Enabled ;
      private int edtMedidaDescripcion_Enabled ;
      private int edtModeloID_Enabled ;
      private int edtMedidaRin_Enabled ;
      private int edtModeloDescripcion_Enabled ;
      private int edtMedidaNombreCompleto_Enabled ;
      private int edtMedidaComentario_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ26MedidaID ;
      private int ZZ22ModeloID ;
      private string sPrefix ;
      private string Z27MedidaCodigo ;
      private string Z74MedidaRin ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMedidaID_Internalname ;
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
      private string edtMedidaID_Jsonclick ;
      private string edtMedidaCodigo_Internalname ;
      private string A27MedidaCodigo ;
      private string edtMedidaCodigo_Jsonclick ;
      private string edtMedidaDescripcion_Internalname ;
      private string edtMedidaDescripcion_Jsonclick ;
      private string edtModeloID_Internalname ;
      private string edtModeloID_Jsonclick ;
      private string edtMedidaRin_Internalname ;
      private string A74MedidaRin ;
      private string edtMedidaRin_Jsonclick ;
      private string edtModeloDescripcion_Internalname ;
      private string edtModeloDescripcion_Jsonclick ;
      private string cmbModeloSegmento_Jsonclick ;
      private string edtMedidaNombreCompleto_Internalname ;
      private string edtMedidaNombreCompleto_Jsonclick ;
      private string edtMedidaComentario_Internalname ;
      private string edtMedidaComentario_Jsonclick ;
      private string chkMedidaActivo_Internalname ;
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
      private string Z25ModeloSegmento ;
      private string sMode9 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ27MedidaCodigo ;
      private string ZZ74MedidaRin ;
      private string ZZ25ModeloSegmento ;
      private bool Z86MedidaActivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A86MedidaActivo ;
      private bool Gx_longc ;
      private bool ZZ86MedidaActivo ;
      private string Z28MedidaDescripcion ;
      private string Z85MedidaComentario ;
      private string A28MedidaDescripcion ;
      private string A23ModeloDescripcion ;
      private string A76MedidaNombreCompleto ;
      private string A85MedidaComentario ;
      private string Z23ModeloDescripcion ;
      private string Z76MedidaNombreCompleto ;
      private string ZZ28MedidaDescripcion ;
      private string ZZ85MedidaComentario ;
      private string ZZ23ModeloDescripcion ;
      private string ZZ76MedidaNombreCompleto ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbModeloSegmento ;
      private GXCheckbox chkMedidaActivo ;
      private IDataStoreProvider pr_default ;
      private int[] T00095_A26MedidaID ;
      private string[] T00095_A27MedidaCodigo ;
      private string[] T00095_A28MedidaDescripcion ;
      private string[] T00095_A74MedidaRin ;
      private string[] T00095_A23ModeloDescripcion ;
      private string[] T00095_A25ModeloSegmento ;
      private string[] T00095_A85MedidaComentario ;
      private bool[] T00095_A86MedidaActivo ;
      private int[] T00095_A22ModeloID ;
      private string[] T00094_A23ModeloDescripcion ;
      private string[] T00094_A25ModeloSegmento ;
      private string[] T00096_A23ModeloDescripcion ;
      private string[] T00096_A25ModeloSegmento ;
      private int[] T00097_A26MedidaID ;
      private int[] T00093_A26MedidaID ;
      private string[] T00093_A27MedidaCodigo ;
      private string[] T00093_A28MedidaDescripcion ;
      private string[] T00093_A74MedidaRin ;
      private string[] T00093_A85MedidaComentario ;
      private bool[] T00093_A86MedidaActivo ;
      private int[] T00093_A22ModeloID ;
      private int[] T00098_A26MedidaID ;
      private int[] T00099_A26MedidaID ;
      private int[] T00092_A26MedidaID ;
      private string[] T00092_A27MedidaCodigo ;
      private string[] T00092_A28MedidaDescripcion ;
      private string[] T00092_A74MedidaRin ;
      private string[] T00092_A85MedidaComentario ;
      private bool[] T00092_A86MedidaActivo ;
      private int[] T00092_A22ModeloID ;
      private int[] T000911_A26MedidaID ;
      private string[] T000914_A23ModeloDescripcion ;
      private string[] T000914_A25ModeloSegmento ;
      private int[] T000915_A77FacturaMedidaID ;
      private int[] T000916_A26MedidaID ;
   }

   public class medida__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00092;
          prmT00092 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmT00093;
          prmT00093 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmT00094;
          prmT00094 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT00095;
          prmT00095 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmT00096;
          prmT00096 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT00097;
          prmT00097 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmT00098;
          prmT00098 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmT00099;
          prmT00099 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmT000910;
          prmT000910 = new Object[] {
          new ParDef("@MedidaCodigo",GXType.Char,20,0) ,
          new ParDef("@MedidaDescripcion",GXType.Char,80,0) ,
          new ParDef("@MedidaRin",GXType.Char,20,0) ,
          new ParDef("@MedidaComentario",GXType.Char,80,0) ,
          new ParDef("@MedidaActivo",GXType.Byte,4,0) ,
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000911;
          prmT000911 = new Object[] {
          };
          Object[] prmT000912;
          prmT000912 = new Object[] {
          new ParDef("@MedidaCodigo",GXType.Char,20,0) ,
          new ParDef("@MedidaDescripcion",GXType.Char,80,0) ,
          new ParDef("@MedidaRin",GXType.Char,20,0) ,
          new ParDef("@MedidaComentario",GXType.Char,80,0) ,
          new ParDef("@MedidaActivo",GXType.Byte,4,0) ,
          new ParDef("@ModeloID",GXType.Int32,9,0) ,
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmT000913;
          prmT000913 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmT000914;
          prmT000914 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000915;
          prmT000915 = new Object[] {
          new ParDef("@MedidaID",GXType.Int32,9,0)
          };
          Object[] prmT000916;
          prmT000916 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00092", "SELECT `MedidaID`, `MedidaCodigo`, `MedidaDescripcion`, `MedidaRin`, `MedidaComentario`, `MedidaActivo`, `ModeloID` FROM `Medida` WHERE `MedidaID` = @MedidaID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00093", "SELECT `MedidaID`, `MedidaCodigo`, `MedidaDescripcion`, `MedidaRin`, `MedidaComentario`, `MedidaActivo`, `ModeloID` FROM `Medida` WHERE `MedidaID` = @MedidaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00094", "SELECT `ModeloDescripcion`, `ModeloSegmento` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00095", "SELECT TM1.`MedidaID`, TM1.`MedidaCodigo`, TM1.`MedidaDescripcion`, TM1.`MedidaRin`, T2.`ModeloDescripcion`, T2.`ModeloSegmento`, TM1.`MedidaComentario`, TM1.`MedidaActivo`, TM1.`ModeloID` FROM (`Medida` TM1 INNER JOIN `Modelo` T2 ON T2.`ModeloID` = TM1.`ModeloID`) WHERE TM1.`MedidaID` = @MedidaID ORDER BY TM1.`MedidaID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00096", "SELECT `ModeloDescripcion`, `ModeloSegmento` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00097", "SELECT `MedidaID` FROM `Medida` WHERE `MedidaID` = @MedidaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00098", "SELECT `MedidaID` FROM `Medida` WHERE ( `MedidaID` > @MedidaID) ORDER BY `MedidaID`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00098,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00099", "SELECT `MedidaID` FROM `Medida` WHERE ( `MedidaID` < @MedidaID) ORDER BY `MedidaID` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000910", "INSERT INTO `Medida`(`MedidaCodigo`, `MedidaDescripcion`, `MedidaRin`, `MedidaComentario`, `MedidaActivo`, `ModeloID`) VALUES(@MedidaCodigo, @MedidaDescripcion, @MedidaRin, @MedidaComentario, @MedidaActivo, @ModeloID)", GxErrorMask.GX_NOMASK,prmT000910)
             ,new CursorDef("T000911", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmT000911,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000912", "UPDATE `Medida` SET `MedidaCodigo`=@MedidaCodigo, `MedidaDescripcion`=@MedidaDescripcion, `MedidaRin`=@MedidaRin, `MedidaComentario`=@MedidaComentario, `MedidaActivo`=@MedidaActivo, `ModeloID`=@ModeloID  WHERE `MedidaID` = @MedidaID", GxErrorMask.GX_NOMASK,prmT000912)
             ,new CursorDef("T000913", "DELETE FROM `Medida`  WHERE `MedidaID` = @MedidaID", GxErrorMask.GX_NOMASK,prmT000913)
             ,new CursorDef("T000914", "SELECT `ModeloDescripcion`, `ModeloSegmento` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000914,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000915", "SELECT `FacturaMedidaID` FROM `FacturaMedida` WHERE `MedidaID` = @MedidaID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000915,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000916", "SELECT `MedidaID` FROM `Medida` ORDER BY `MedidaID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000916,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
