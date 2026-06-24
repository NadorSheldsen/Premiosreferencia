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
   public class promocionmodelo : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A41PromocionID = (int)(Math.Round(NumberUtil.Val( GetPar( "PromocionID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A41PromocionID) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Promocion Modelo", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPromocionModeloID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public promocionmodelo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public promocionmodelo( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Promocion Modelo", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_PromocionModelo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromocionModelo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromocionModelo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromocionModelo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromocionModelo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_PromocionModelo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromocionModeloID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocionModeloID_Internalname, context.GetMessage( "Modelo ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPromocionModeloID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A48PromocionModeloID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPromocionModeloID_Enabled!=0) ? context.localUtil.Format( (decimal)(A48PromocionModeloID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A48PromocionModeloID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionModeloID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocionModeloID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_PromocionModelo.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPromocionID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPromocionID_Enabled!=0) ? context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocionID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_PromocionModelo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtModeloID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22ModeloID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtModeloID_Enabled!=0) ? context.localUtil.Format( (decimal)(A22ModeloID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A22ModeloID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtModeloID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtModeloID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_PromocionModelo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtModeloDescripcion_Internalname, A23ModeloDescripcion, StringUtil.RTrim( context.localUtil.Format( A23ModeloDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtModeloDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtModeloDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_PromocionModelo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbModeloSegmento, cmbModeloSegmento_Internalname, StringUtil.RTrim( A25ModeloSegmento), 1, cmbModeloSegmento_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbModeloSegmento.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_PromocionModelo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromocionModeloPrecio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocionModeloPrecio_Internalname, context.GetMessage( "Comisión", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPromocionModeloPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( A49PromocionModeloPrecio, 14, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPromocionModeloPrecio_Enabled!=0) ? context.localUtil.Format( A49PromocionModeloPrecio, "$ Z,ZZZ,ZZ9.99") : context.localUtil.Format( A49PromocionModeloPrecio, "$ Z,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionModeloPrecio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocionModeloPrecio_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_PromocionModelo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromocionModelo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromocionModelo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromocionModelo.htm");
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
            Z48PromocionModeloID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z48PromocionModeloID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z49PromocionModeloPrecio = context.localUtil.CToN( cgiGet( "Z49PromocionModeloPrecio"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            Z41PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z41PromocionID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z22ModeloID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z22ModeloID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtPromocionModeloID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPromocionModeloID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROMOCIONMODELOID");
               AnyError = 1;
               GX_FocusControl = edtPromocionModeloID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A48PromocionModeloID = 0;
               AssignAttri("", false, "A48PromocionModeloID", StringUtil.LTrimStr( (decimal)(A48PromocionModeloID), 9, 0));
            }
            else
            {
               A48PromocionModeloID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPromocionModeloID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A48PromocionModeloID", StringUtil.LTrimStr( (decimal)(A48PromocionModeloID), 9, 0));
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
            cmbModeloSegmento.CurrentValue = cgiGet( cmbModeloSegmento_Internalname);
            A25ModeloSegmento = cgiGet( cmbModeloSegmento_Internalname);
            AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPromocionModeloPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPromocionModeloPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROMOCIONMODELOPRECIO");
               AnyError = 1;
               GX_FocusControl = edtPromocionModeloPrecio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A49PromocionModeloPrecio = 0;
               AssignAttri("", false, "A49PromocionModeloPrecio", StringUtil.LTrimStr( A49PromocionModeloPrecio, 10, 2));
            }
            else
            {
               A49PromocionModeloPrecio = context.localUtil.CToN( cgiGet( edtPromocionModeloPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A49PromocionModeloPrecio", StringUtil.LTrimStr( A49PromocionModeloPrecio, 10, 2));
            }
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
               A48PromocionModeloID = (int)(Math.Round(NumberUtil.Val( GetPar( "PromocionModeloID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A48PromocionModeloID", StringUtil.LTrimStr( (decimal)(A48PromocionModeloID), 9, 0));
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
               InitAll0E14( ) ;
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
         DisableAttributes0E14( ) ;
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

      protected void ResetCaption0E0( )
      {
      }

      protected void ZM0E14( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z49PromocionModeloPrecio = T000E3_A49PromocionModeloPrecio[0];
               Z41PromocionID = T000E3_A41PromocionID[0];
               Z22ModeloID = T000E3_A22ModeloID[0];
            }
            else
            {
               Z49PromocionModeloPrecio = A49PromocionModeloPrecio;
               Z41PromocionID = A41PromocionID;
               Z22ModeloID = A22ModeloID;
            }
         }
         if ( GX_JID == -1 )
         {
            Z48PromocionModeloID = A48PromocionModeloID;
            Z49PromocionModeloPrecio = A49PromocionModeloPrecio;
            Z41PromocionID = A41PromocionID;
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

      protected void Load0E14( )
      {
         /* Using cursor T000E6 */
         pr_default.execute(4, new Object[] {A48PromocionModeloID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound14 = 1;
            A23ModeloDescripcion = T000E6_A23ModeloDescripcion[0];
            AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
            A25ModeloSegmento = T000E6_A25ModeloSegmento[0];
            AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
            A49PromocionModeloPrecio = T000E6_A49PromocionModeloPrecio[0];
            AssignAttri("", false, "A49PromocionModeloPrecio", StringUtil.LTrimStr( A49PromocionModeloPrecio, 10, 2));
            A41PromocionID = T000E6_A41PromocionID[0];
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            A22ModeloID = T000E6_A22ModeloID[0];
            AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
            ZM0E14( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0E14( ) ;
      }

      protected void OnLoadActions0E14( )
      {
      }

      protected void CheckExtendedTable0E14( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000E4 */
         pr_default.execute(2, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
            GX_FocusControl = edtPromocionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000E5 */
         pr_default.execute(3, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Modelo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MODELOID");
            AnyError = 1;
            GX_FocusControl = edtModeloID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A23ModeloDescripcion = T000E5_A23ModeloDescripcion[0];
         AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
         A25ModeloSegmento = T000E5_A25ModeloSegmento[0];
         AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0E14( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( int A41PromocionID )
      {
         /* Using cursor T000E7 */
         pr_default.execute(5, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
            GX_FocusControl = edtPromocionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( int A22ModeloID )
      {
         /* Using cursor T000E8 */
         pr_default.execute(6, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Modelo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MODELOID");
            AnyError = 1;
            GX_FocusControl = edtModeloID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A23ModeloDescripcion = T000E8_A23ModeloDescripcion[0];
         AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
         A25ModeloSegmento = T000E8_A25ModeloSegmento[0];
         AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A23ModeloDescripcion)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A25ModeloSegmento))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0E14( )
      {
         /* Using cursor T000E9 */
         pr_default.execute(7, new Object[] {A48PromocionModeloID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000E3 */
         pr_default.execute(1, new Object[] {A48PromocionModeloID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E14( 1) ;
            RcdFound14 = 1;
            A48PromocionModeloID = T000E3_A48PromocionModeloID[0];
            AssignAttri("", false, "A48PromocionModeloID", StringUtil.LTrimStr( (decimal)(A48PromocionModeloID), 9, 0));
            A49PromocionModeloPrecio = T000E3_A49PromocionModeloPrecio[0];
            AssignAttri("", false, "A49PromocionModeloPrecio", StringUtil.LTrimStr( A49PromocionModeloPrecio, 10, 2));
            A41PromocionID = T000E3_A41PromocionID[0];
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            A22ModeloID = T000E3_A22ModeloID[0];
            AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
            Z48PromocionModeloID = A48PromocionModeloID;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0E14( ) ;
            if ( AnyError == 1 )
            {
               RcdFound14 = 0;
               InitializeNonKey0E14( ) ;
            }
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0E14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E14( ) ;
         if ( RcdFound14 == 0 )
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
         RcdFound14 = 0;
         /* Using cursor T000E10 */
         pr_default.execute(8, new Object[] {A48PromocionModeloID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000E10_A48PromocionModeloID[0] < A48PromocionModeloID ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000E10_A48PromocionModeloID[0] > A48PromocionModeloID ) ) )
            {
               A48PromocionModeloID = T000E10_A48PromocionModeloID[0];
               AssignAttri("", false, "A48PromocionModeloID", StringUtil.LTrimStr( (decimal)(A48PromocionModeloID), 9, 0));
               RcdFound14 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound14 = 0;
         /* Using cursor T000E11 */
         pr_default.execute(9, new Object[] {A48PromocionModeloID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000E11_A48PromocionModeloID[0] > A48PromocionModeloID ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000E11_A48PromocionModeloID[0] < A48PromocionModeloID ) ) )
            {
               A48PromocionModeloID = T000E11_A48PromocionModeloID[0];
               AssignAttri("", false, "A48PromocionModeloID", StringUtil.LTrimStr( (decimal)(A48PromocionModeloID), 9, 0));
               RcdFound14 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0E14( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPromocionModeloID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0E14( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound14 == 1 )
            {
               if ( A48PromocionModeloID != Z48PromocionModeloID )
               {
                  A48PromocionModeloID = Z48PromocionModeloID;
                  AssignAttri("", false, "A48PromocionModeloID", StringUtil.LTrimStr( (decimal)(A48PromocionModeloID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROMOCIONMODELOID");
                  AnyError = 1;
                  GX_FocusControl = edtPromocionModeloID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPromocionModeloID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0E14( ) ;
                  GX_FocusControl = edtPromocionModeloID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A48PromocionModeloID != Z48PromocionModeloID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPromocionModeloID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0E14( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROMOCIONMODELOID");
                     AnyError = 1;
                     GX_FocusControl = edtPromocionModeloID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPromocionModeloID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0E14( ) ;
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
         if ( A48PromocionModeloID != Z48PromocionModeloID )
         {
            A48PromocionModeloID = Z48PromocionModeloID;
            AssignAttri("", false, "A48PromocionModeloID", StringUtil.LTrimStr( (decimal)(A48PromocionModeloID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROMOCIONMODELOID");
            AnyError = 1;
            GX_FocusControl = edtPromocionModeloID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPromocionModeloID_Internalname;
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
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROMOCIONMODELOID");
            AnyError = 1;
            GX_FocusControl = edtPromocionModeloID_Internalname;
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
         ScanStart0E14( ) ;
         if ( RcdFound14 == 0 )
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
         ScanEnd0E14( ) ;
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
         if ( RcdFound14 == 0 )
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
         if ( RcdFound14 == 0 )
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
         ScanStart0E14( ) ;
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound14 != 0 )
            {
               ScanNext0E14( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPromocionID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0E14( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0E14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000E2 */
            pr_default.execute(0, new Object[] {A48PromocionModeloID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PromocionModelo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z49PromocionModeloPrecio != T000E2_A49PromocionModeloPrecio[0] ) || ( Z41PromocionID != T000E2_A41PromocionID[0] ) || ( Z22ModeloID != T000E2_A22ModeloID[0] ) )
            {
               if ( Z49PromocionModeloPrecio != T000E2_A49PromocionModeloPrecio[0] )
               {
                  GXUtil.WriteLog("promocionmodelo:[seudo value changed for attri]"+"PromocionModeloPrecio");
                  GXUtil.WriteLogRaw("Old: ",Z49PromocionModeloPrecio);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A49PromocionModeloPrecio[0]);
               }
               if ( Z41PromocionID != T000E2_A41PromocionID[0] )
               {
                  GXUtil.WriteLog("promocionmodelo:[seudo value changed for attri]"+"PromocionID");
                  GXUtil.WriteLogRaw("Old: ",Z41PromocionID);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A41PromocionID[0]);
               }
               if ( Z22ModeloID != T000E2_A22ModeloID[0] )
               {
                  GXUtil.WriteLog("promocionmodelo:[seudo value changed for attri]"+"ModeloID");
                  GXUtil.WriteLogRaw("Old: ",Z22ModeloID);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A22ModeloID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PromocionModelo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E14( )
      {
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E14( 0) ;
            CheckOptimisticConcurrency0E14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E12 */
                     pr_default.execute(10, new Object[] {A49PromocionModeloPrecio, A41PromocionID, A22ModeloID});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000E13 */
                     pr_default.execute(11);
                     A48PromocionModeloID = T000E13_A48PromocionModeloID[0];
                     AssignAttri("", false, "A48PromocionModeloID", StringUtil.LTrimStr( (decimal)(A48PromocionModeloID), 9, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("PromocionModelo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0E0( ) ;
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
               Load0E14( ) ;
            }
            EndLevel0E14( ) ;
         }
         CloseExtendedTableCursors0E14( ) ;
      }

      protected void Update0E14( )
      {
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E14 */
                     pr_default.execute(12, new Object[] {A49PromocionModeloPrecio, A41PromocionID, A22ModeloID, A48PromocionModeloID});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("PromocionModelo");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PromocionModelo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E14( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0E0( ) ;
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
            EndLevel0E14( ) ;
         }
         CloseExtendedTableCursors0E14( ) ;
      }

      protected void DeferredUpdate0E14( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E14( ) ;
            AfterConfirm0E14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000E15 */
                  pr_default.execute(13, new Object[] {A48PromocionModeloID});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("PromocionModelo");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound14 == 0 )
                        {
                           InitAll0E14( ) ;
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
                        ResetCaption0E0( ) ;
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
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0E14( ) ;
         Gx_mode = sMode14;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0E14( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000E16 */
            pr_default.execute(14, new Object[] {A22ModeloID});
            A23ModeloDescripcion = T000E16_A23ModeloDescripcion[0];
            AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
            A25ModeloSegmento = T000E16_A25ModeloSegmento[0];
            AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
            pr_default.close(14);
         }
      }

      protected void EndLevel0E14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("promocionmodelo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("promocionmodelo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0E14( )
      {
         /* Using cursor T000E17 */
         pr_default.execute(15);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound14 = 1;
            A48PromocionModeloID = T000E17_A48PromocionModeloID[0];
            AssignAttri("", false, "A48PromocionModeloID", StringUtil.LTrimStr( (decimal)(A48PromocionModeloID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0E14( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound14 = 1;
            A48PromocionModeloID = T000E17_A48PromocionModeloID[0];
            AssignAttri("", false, "A48PromocionModeloID", StringUtil.LTrimStr( (decimal)(A48PromocionModeloID), 9, 0));
         }
      }

      protected void ScanEnd0E14( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0E14( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E14( )
      {
         edtPromocionModeloID_Enabled = 0;
         AssignProp("", false, edtPromocionModeloID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionModeloID_Enabled), 5, 0), true);
         edtPromocionID_Enabled = 0;
         AssignProp("", false, edtPromocionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionID_Enabled), 5, 0), true);
         edtModeloID_Enabled = 0;
         AssignProp("", false, edtModeloID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtModeloID_Enabled), 5, 0), true);
         edtModeloDescripcion_Enabled = 0;
         AssignProp("", false, edtModeloDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtModeloDescripcion_Enabled), 5, 0), true);
         cmbModeloSegmento.Enabled = 0;
         AssignProp("", false, cmbModeloSegmento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbModeloSegmento.Enabled), 5, 0), true);
         edtPromocionModeloPrecio_Enabled = 0;
         AssignProp("", false, edtPromocionModeloPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionModeloPrecio_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0E14( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0E0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("promocionmodelo.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z48PromocionModeloID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z48PromocionModeloID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z49PromocionModeloPrecio", StringUtil.LTrim( StringUtil.NToC( Z49PromocionModeloPrecio, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z41PromocionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("promocionmodelo.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "PromocionModelo" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Promocion Modelo", "") ;
      }

      protected void InitializeNonKey0E14( )
      {
         A41PromocionID = 0;
         AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
         A22ModeloID = 0;
         AssignAttri("", false, "A22ModeloID", StringUtil.LTrimStr( (decimal)(A22ModeloID), 9, 0));
         A23ModeloDescripcion = "";
         AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
         A25ModeloSegmento = "";
         AssignAttri("", false, "A25ModeloSegmento", A25ModeloSegmento);
         A49PromocionModeloPrecio = 0;
         AssignAttri("", false, "A49PromocionModeloPrecio", StringUtil.LTrimStr( A49PromocionModeloPrecio, 10, 2));
         Z49PromocionModeloPrecio = 0;
         Z41PromocionID = 0;
         Z22ModeloID = 0;
      }

      protected void InitAll0E14( )
      {
         A48PromocionModeloID = 0;
         AssignAttri("", false, "A48PromocionModeloID", StringUtil.LTrimStr( (decimal)(A48PromocionModeloID), 9, 0));
         InitializeNonKey0E14( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025102815462270", true, true);
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
         context.AddJavascriptSource("promocionmodelo.js", "?2025102815462270", false, true);
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
         edtPromocionModeloID_Internalname = "PROMOCIONMODELOID";
         edtPromocionID_Internalname = "PROMOCIONID";
         edtModeloID_Internalname = "MODELOID";
         edtModeloDescripcion_Internalname = "MODELODESCRIPCION";
         cmbModeloSegmento_Internalname = "MODELOSEGMENTO";
         edtPromocionModeloPrecio_Internalname = "PROMOCIONMODELOPRECIO";
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
         Form.Caption = context.GetMessage( "Promocion Modelo", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPromocionModeloPrecio_Jsonclick = "";
         edtPromocionModeloPrecio_Enabled = 1;
         cmbModeloSegmento_Jsonclick = "";
         cmbModeloSegmento.Enabled = 0;
         edtModeloDescripcion_Jsonclick = "";
         edtModeloDescripcion_Enabled = 0;
         edtModeloID_Jsonclick = "";
         edtModeloID_Enabled = 1;
         edtPromocionID_Jsonclick = "";
         edtPromocionID_Enabled = 1;
         edtPromocionModeloID_Jsonclick = "";
         edtPromocionModeloID_Enabled = 1;
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

      public void Valid_Promocionmodeloid( )
      {
         A25ModeloSegmento = cmbModeloSegmento.CurrentValue;
         cmbModeloSegmento.CurrentValue = A25ModeloSegmento;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
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
         AssignAttri("", false, "A41PromocionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, ".", "")));
         AssignAttri("", false, "A22ModeloID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22ModeloID), 9, 0, ".", "")));
         AssignAttri("", false, "A49PromocionModeloPrecio", StringUtil.LTrim( StringUtil.NToC( A49PromocionModeloPrecio, 10, 2, ".", "")));
         AssignAttri("", false, "A23ModeloDescripcion", A23ModeloDescripcion);
         AssignAttri("", false, "A25ModeloSegmento", StringUtil.RTrim( A25ModeloSegmento));
         cmbModeloSegmento.CurrentValue = StringUtil.RTrim( A25ModeloSegmento);
         AssignProp("", false, cmbModeloSegmento_Internalname, "Values", cmbModeloSegmento.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z48PromocionModeloID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z48PromocionModeloID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z41PromocionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41PromocionID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z22ModeloID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22ModeloID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z49PromocionModeloPrecio", StringUtil.LTrim( StringUtil.NToC( Z49PromocionModeloPrecio, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23ModeloDescripcion", Z23ModeloDescripcion);
         GxWebStd.gx_hidden_field( context, "Z25ModeloSegmento", StringUtil.RTrim( Z25ModeloSegmento));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Promocionid( )
      {
         /* Using cursor T000E18 */
         pr_default.execute(16, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
            GX_FocusControl = edtPromocionID_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Modeloid( )
      {
         A25ModeloSegmento = cmbModeloSegmento.CurrentValue;
         cmbModeloSegmento.CurrentValue = A25ModeloSegmento;
         /* Using cursor T000E16 */
         pr_default.execute(14, new Object[] {A22ModeloID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Modelo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MODELOID");
            AnyError = 1;
            GX_FocusControl = edtModeloID_Internalname;
         }
         A23ModeloDescripcion = T000E16_A23ModeloDescripcion[0];
         A25ModeloSegmento = T000E16_A25ModeloSegmento[0];
         cmbModeloSegmento.CurrentValue = A25ModeloSegmento;
         pr_default.close(14);
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
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_PROMOCIONMODELOID","""{"handler":"Valid_Promocionmodeloid","iparms":[{"av":"cmbModeloSegmento"},{"av":"A25ModeloSegmento","fld":"MODELOSEGMENTO"},{"av":"A48PromocionModeloID","fld":"PROMOCIONMODELOID","pic":"ZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_PROMOCIONMODELOID",""","oparms":[{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A22ModeloID","fld":"MODELOID","pic":"ZZZZZZZZ9"},{"av":"A49PromocionModeloPrecio","fld":"PROMOCIONMODELOPRECIO","pic":"$ Z,ZZZ,ZZ9.99"},{"av":"A23ModeloDescripcion","fld":"MODELODESCRIPCION"},{"av":"cmbModeloSegmento"},{"av":"A25ModeloSegmento","fld":"MODELOSEGMENTO"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z48PromocionModeloID"},{"av":"Z41PromocionID"},{"av":"Z22ModeloID"},{"av":"Z49PromocionModeloPrecio"},{"av":"Z23ModeloDescripcion"},{"av":"Z25ModeloSegmento"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_PROMOCIONID","""{"handler":"Valid_Promocionid","iparms":[{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_MODELOID","""{"handler":"Valid_Modeloid","iparms":[{"av":"A22ModeloID","fld":"MODELOID","pic":"ZZZZZZZZ9"},{"av":"A23ModeloDescripcion","fld":"MODELODESCRIPCION"},{"av":"cmbModeloSegmento"},{"av":"A25ModeloSegmento","fld":"MODELOSEGMENTO"}]""");
         setEventMetadata("VALID_MODELOID",""","oparms":[{"av":"A23ModeloDescripcion","fld":"MODELODESCRIPCION"},{"av":"cmbModeloSegmento"},{"av":"A25ModeloSegmento","fld":"MODELOSEGMENTO"}]}""");
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
         pr_default.close(16);
         pr_default.close(14);
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
         T000E6_A48PromocionModeloID = new int[1] ;
         T000E6_A23ModeloDescripcion = new string[] {""} ;
         T000E6_A25ModeloSegmento = new string[] {""} ;
         T000E6_A49PromocionModeloPrecio = new decimal[1] ;
         T000E6_A41PromocionID = new int[1] ;
         T000E6_A22ModeloID = new int[1] ;
         T000E4_A41PromocionID = new int[1] ;
         T000E5_A23ModeloDescripcion = new string[] {""} ;
         T000E5_A25ModeloSegmento = new string[] {""} ;
         T000E7_A41PromocionID = new int[1] ;
         T000E8_A23ModeloDescripcion = new string[] {""} ;
         T000E8_A25ModeloSegmento = new string[] {""} ;
         T000E9_A48PromocionModeloID = new int[1] ;
         T000E3_A48PromocionModeloID = new int[1] ;
         T000E3_A49PromocionModeloPrecio = new decimal[1] ;
         T000E3_A41PromocionID = new int[1] ;
         T000E3_A22ModeloID = new int[1] ;
         sMode14 = "";
         T000E10_A48PromocionModeloID = new int[1] ;
         T000E11_A48PromocionModeloID = new int[1] ;
         T000E2_A48PromocionModeloID = new int[1] ;
         T000E2_A49PromocionModeloPrecio = new decimal[1] ;
         T000E2_A41PromocionID = new int[1] ;
         T000E2_A22ModeloID = new int[1] ;
         T000E13_A48PromocionModeloID = new int[1] ;
         T000E16_A23ModeloDescripcion = new string[] {""} ;
         T000E16_A25ModeloSegmento = new string[] {""} ;
         T000E17_A48PromocionModeloID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ23ModeloDescripcion = "";
         ZZ25ModeloSegmento = "";
         T000E18_A41PromocionID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.promocionmodelo__default(),
            new Object[][] {
                new Object[] {
               T000E2_A48PromocionModeloID, T000E2_A49PromocionModeloPrecio, T000E2_A41PromocionID, T000E2_A22ModeloID
               }
               , new Object[] {
               T000E3_A48PromocionModeloID, T000E3_A49PromocionModeloPrecio, T000E3_A41PromocionID, T000E3_A22ModeloID
               }
               , new Object[] {
               T000E4_A41PromocionID
               }
               , new Object[] {
               T000E5_A23ModeloDescripcion, T000E5_A25ModeloSegmento
               }
               , new Object[] {
               T000E6_A48PromocionModeloID, T000E6_A23ModeloDescripcion, T000E6_A25ModeloSegmento, T000E6_A49PromocionModeloPrecio, T000E6_A41PromocionID, T000E6_A22ModeloID
               }
               , new Object[] {
               T000E7_A41PromocionID
               }
               , new Object[] {
               T000E8_A23ModeloDescripcion, T000E8_A25ModeloSegmento
               }
               , new Object[] {
               T000E9_A48PromocionModeloID
               }
               , new Object[] {
               T000E10_A48PromocionModeloID
               }
               , new Object[] {
               T000E11_A48PromocionModeloID
               }
               , new Object[] {
               }
               , new Object[] {
               T000E13_A48PromocionModeloID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000E16_A23ModeloDescripcion, T000E16_A25ModeloSegmento
               }
               , new Object[] {
               T000E17_A48PromocionModeloID
               }
               , new Object[] {
               T000E18_A41PromocionID
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
      private short RcdFound14 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z48PromocionModeloID ;
      private int Z41PromocionID ;
      private int Z22ModeloID ;
      private int A41PromocionID ;
      private int A22ModeloID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A48PromocionModeloID ;
      private int edtPromocionModeloID_Enabled ;
      private int edtPromocionID_Enabled ;
      private int edtModeloID_Enabled ;
      private int edtModeloDescripcion_Enabled ;
      private int edtPromocionModeloPrecio_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ48PromocionModeloID ;
      private int ZZ41PromocionID ;
      private int ZZ22ModeloID ;
      private decimal Z49PromocionModeloPrecio ;
      private decimal A49PromocionModeloPrecio ;
      private decimal ZZ49PromocionModeloPrecio ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPromocionModeloID_Internalname ;
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
      private string edtPromocionModeloID_Jsonclick ;
      private string edtPromocionID_Internalname ;
      private string edtPromocionID_Jsonclick ;
      private string edtModeloID_Internalname ;
      private string edtModeloID_Jsonclick ;
      private string edtModeloDescripcion_Internalname ;
      private string edtModeloDescripcion_Jsonclick ;
      private string cmbModeloSegmento_Jsonclick ;
      private string edtPromocionModeloPrecio_Internalname ;
      private string edtPromocionModeloPrecio_Jsonclick ;
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
      private string sMode14 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ25ModeloSegmento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string A23ModeloDescripcion ;
      private string Z23ModeloDescripcion ;
      private string ZZ23ModeloDescripcion ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbModeloSegmento ;
      private IDataStoreProvider pr_default ;
      private int[] T000E6_A48PromocionModeloID ;
      private string[] T000E6_A23ModeloDescripcion ;
      private string[] T000E6_A25ModeloSegmento ;
      private decimal[] T000E6_A49PromocionModeloPrecio ;
      private int[] T000E6_A41PromocionID ;
      private int[] T000E6_A22ModeloID ;
      private int[] T000E4_A41PromocionID ;
      private string[] T000E5_A23ModeloDescripcion ;
      private string[] T000E5_A25ModeloSegmento ;
      private int[] T000E7_A41PromocionID ;
      private string[] T000E8_A23ModeloDescripcion ;
      private string[] T000E8_A25ModeloSegmento ;
      private int[] T000E9_A48PromocionModeloID ;
      private int[] T000E3_A48PromocionModeloID ;
      private decimal[] T000E3_A49PromocionModeloPrecio ;
      private int[] T000E3_A41PromocionID ;
      private int[] T000E3_A22ModeloID ;
      private int[] T000E10_A48PromocionModeloID ;
      private int[] T000E11_A48PromocionModeloID ;
      private int[] T000E2_A48PromocionModeloID ;
      private decimal[] T000E2_A49PromocionModeloPrecio ;
      private int[] T000E2_A41PromocionID ;
      private int[] T000E2_A22ModeloID ;
      private int[] T000E13_A48PromocionModeloID ;
      private string[] T000E16_A23ModeloDescripcion ;
      private string[] T000E16_A25ModeloSegmento ;
      private int[] T000E17_A48PromocionModeloID ;
      private int[] T000E18_A41PromocionID ;
   }

   public class promocionmodelo__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000E2;
          prmT000E2 = new Object[] {
          new ParDef("@PromocionModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000E3;
          prmT000E3 = new Object[] {
          new ParDef("@PromocionModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000E4;
          prmT000E4 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000E5;
          prmT000E5 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000E6;
          prmT000E6 = new Object[] {
          new ParDef("@PromocionModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000E7;
          prmT000E7 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000E8;
          prmT000E8 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000E9;
          prmT000E9 = new Object[] {
          new ParDef("@PromocionModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000E10;
          prmT000E10 = new Object[] {
          new ParDef("@PromocionModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000E11;
          prmT000E11 = new Object[] {
          new ParDef("@PromocionModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000E12;
          prmT000E12 = new Object[] {
          new ParDef("@PromocionModeloPrecio",GXType.Number,10,2) ,
          new ParDef("@PromocionID",GXType.Int32,9,0) ,
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000E13;
          prmT000E13 = new Object[] {
          };
          Object[] prmT000E14;
          prmT000E14 = new Object[] {
          new ParDef("@PromocionModeloPrecio",GXType.Number,10,2) ,
          new ParDef("@PromocionID",GXType.Int32,9,0) ,
          new ParDef("@ModeloID",GXType.Int32,9,0) ,
          new ParDef("@PromocionModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000E15;
          prmT000E15 = new Object[] {
          new ParDef("@PromocionModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000E16;
          prmT000E16 = new Object[] {
          new ParDef("@ModeloID",GXType.Int32,9,0)
          };
          Object[] prmT000E17;
          prmT000E17 = new Object[] {
          };
          Object[] prmT000E18;
          prmT000E18 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000E2", "SELECT `PromocionModeloID`, `PromocionModeloPrecio`, `PromocionID`, `ModeloID` FROM `PromocionModelo` WHERE `PromocionModeloID` = @PromocionModeloID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E3", "SELECT `PromocionModeloID`, `PromocionModeloPrecio`, `PromocionID`, `ModeloID` FROM `PromocionModelo` WHERE `PromocionModeloID` = @PromocionModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E4", "SELECT `PromocionID` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E5", "SELECT `ModeloDescripcion`, `ModeloSegmento` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E6", "SELECT TM1.`PromocionModeloID`, T2.`ModeloDescripcion`, T2.`ModeloSegmento`, TM1.`PromocionModeloPrecio`, TM1.`PromocionID`, TM1.`ModeloID` FROM (`PromocionModelo` TM1 INNER JOIN `Modelo` T2 ON T2.`ModeloID` = TM1.`ModeloID`) WHERE TM1.`PromocionModeloID` = @PromocionModeloID ORDER BY TM1.`PromocionModeloID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E7", "SELECT `PromocionID` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E8", "SELECT `ModeloDescripcion`, `ModeloSegmento` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E9", "SELECT `PromocionModeloID` FROM `PromocionModelo` WHERE `PromocionModeloID` = @PromocionModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E10", "SELECT `PromocionModeloID` FROM `PromocionModelo` WHERE ( `PromocionModeloID` > @PromocionModeloID) ORDER BY `PromocionModeloID`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000E10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000E11", "SELECT `PromocionModeloID` FROM `PromocionModelo` WHERE ( `PromocionModeloID` < @PromocionModeloID) ORDER BY `PromocionModeloID` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000E11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000E12", "INSERT INTO `PromocionModelo`(`PromocionModeloPrecio`, `PromocionID`, `ModeloID`) VALUES(@PromocionModeloPrecio, @PromocionID, @ModeloID)", GxErrorMask.GX_NOMASK,prmT000E12)
             ,new CursorDef("T000E13", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E14", "UPDATE `PromocionModelo` SET `PromocionModeloPrecio`=@PromocionModeloPrecio, `PromocionID`=@PromocionID, `ModeloID`=@ModeloID  WHERE `PromocionModeloID` = @PromocionModeloID", GxErrorMask.GX_NOMASK,prmT000E14)
             ,new CursorDef("T000E15", "DELETE FROM `PromocionModelo`  WHERE `PromocionModeloID` = @PromocionModeloID", GxErrorMask.GX_NOMASK,prmT000E15)
             ,new CursorDef("T000E16", "SELECT `ModeloDescripcion`, `ModeloSegmento` FROM `Modelo` WHERE `ModeloID` = @ModeloID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E17", "SELECT `PromocionModeloID` FROM `PromocionModelo` ORDER BY `PromocionModeloID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E17,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E18", "SELECT `PromocionID` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E18,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
