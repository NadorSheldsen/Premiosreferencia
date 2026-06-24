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
   public class promociondistribuidor : GXDataArea
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
         Form.Meta.addItem("description", context.GetMessage( "Promocion Distribuidor", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPromocionDistribuidorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public promociondistribuidor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public promociondistribuidor( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Promocion Distribuidor", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_PromocionDistribuidor.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromocionDistribuidor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromocionDistribuidor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromocionDistribuidor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromocionDistribuidor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_PromocionDistribuidor.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromocionDistribuidorID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocionDistribuidorID_Internalname, context.GetMessage( "Distribuidor ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPromocionDistribuidorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A47PromocionDistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPromocionDistribuidorID_Enabled!=0) ? context.localUtil.Format( (decimal)(A47PromocionDistribuidorID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A47PromocionDistribuidorID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionDistribuidorID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocionDistribuidorID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_PromocionDistribuidor.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPromocionID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPromocionID_Enabled!=0) ? context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocionID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_PromocionDistribuidor.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPromocionDescripcion_Internalname, A42PromocionDescripcion, StringUtil.RTrim( context.localUtil.Format( A42PromocionDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocionDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_PromocionDistribuidor.htm");
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
         GxWebStd.gx_html_textarea( context, edtPromocionBase_Internalname, A43PromocionBase, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtPromocionBase_Enabled, 0, 80, "chr", 9, "row", 0, StyleString, ClassString, "", "", "700", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_PromocionDistribuidor.htm");
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
         GxWebStd.gx_bitmap( context, imgPromocionArte_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgPromocionArte_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", "", "", 0, A44PromocionArte_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_PromocionDistribuidor.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromocionFechaInicio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocionFechaInicio_Internalname, context.GetMessage( "Inicio de la promoción", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPromocionFechaInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPromocionFechaInicio_Internalname, context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"), context.localUtil.Format( A45PromocionFechaInicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionFechaInicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocionFechaInicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PromocionDistribuidor.htm");
         GxWebStd.gx_bitmap( context, edtPromocionFechaInicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPromocionFechaInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PromocionDistribuidor.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromocionFechaFin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocionFechaFin_Internalname, context.GetMessage( "Fin de la promoción", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPromocionFechaFin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPromocionFechaFin_Internalname, context.localUtil.Format(A46PromocionFechaFin, "99/99/99"), context.localUtil.Format( A46PromocionFechaFin, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionFechaFin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocionFechaFin_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PromocionDistribuidor.htm");
         GxWebStd.gx_bitmap( context, edtPromocionFechaFin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPromocionFechaFin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PromocionDistribuidor.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDistribuidorID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDistribuidorID_Internalname, context.GetMessage( "Distribuidor ID", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDistribuidorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10DistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtDistribuidorID_Enabled!=0) ? context.localUtil.Format( (decimal)(A10DistribuidorID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A10DistribuidorID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDistribuidorID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDistribuidorID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_PromocionDistribuidor.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDistribuidorDescripcion_Internalname, A11DistribuidorDescripcion, StringUtil.RTrim( context.localUtil.Format( A11DistribuidorDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDistribuidorDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDistribuidorDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_PromocionDistribuidor.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromocionDistribuidor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromocionDistribuidor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_PromocionDistribuidor.htm");
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
            Z47PromocionDistribuidorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z47PromocionDistribuidorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z41PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z41PromocionID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z10DistribuidorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z10DistribuidorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A40000PromocionArte_GXI = cgiGet( "PROMOCIONARTE_GXI");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtPromocionDistribuidorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPromocionDistribuidorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROMOCIONDISTRIBUIDORID");
               AnyError = 1;
               GX_FocusControl = edtPromocionDistribuidorID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A47PromocionDistribuidorID = 0;
               AssignAttri("", false, "A47PromocionDistribuidorID", StringUtil.LTrimStr( (decimal)(A47PromocionDistribuidorID), 9, 0));
            }
            else
            {
               A47PromocionDistribuidorID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPromocionDistribuidorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A47PromocionDistribuidorID", StringUtil.LTrimStr( (decimal)(A47PromocionDistribuidorID), 9, 0));
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
            A45PromocionFechaInicio = context.localUtil.CToD( cgiGet( edtPromocionFechaInicio_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri("", false, "A45PromocionFechaInicio", context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"));
            A46PromocionFechaFin = context.localUtil.CToD( cgiGet( edtPromocionFechaFin_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri("", false, "A46PromocionFechaFin", context.localUtil.Format(A46PromocionFechaFin, "99/99/99"));
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
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgPromocionArte_Internalname, ref  A44PromocionArte, ref  A40000PromocionArte_GXI);
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
               A47PromocionDistribuidorID = (int)(Math.Round(NumberUtil.Val( GetPar( "PromocionDistribuidorID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A47PromocionDistribuidorID", StringUtil.LTrimStr( (decimal)(A47PromocionDistribuidorID), 9, 0));
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
               InitAll0D13( ) ;
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
         DisableAttributes0D13( ) ;
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

      protected void ResetCaption0D0( )
      {
      }

      protected void ZM0D13( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z41PromocionID = T000D3_A41PromocionID[0];
               Z10DistribuidorID = T000D3_A10DistribuidorID[0];
            }
            else
            {
               Z41PromocionID = A41PromocionID;
               Z10DistribuidorID = A10DistribuidorID;
            }
         }
         if ( GX_JID == -1 )
         {
            Z47PromocionDistribuidorID = A47PromocionDistribuidorID;
            Z41PromocionID = A41PromocionID;
            Z10DistribuidorID = A10DistribuidorID;
            Z42PromocionDescripcion = A42PromocionDescripcion;
            Z43PromocionBase = A43PromocionBase;
            Z44PromocionArte = A44PromocionArte;
            Z40000PromocionArte_GXI = A40000PromocionArte_GXI;
            Z45PromocionFechaInicio = A45PromocionFechaInicio;
            Z46PromocionFechaFin = A46PromocionFechaFin;
            Z11DistribuidorDescripcion = A11DistribuidorDescripcion;
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

      protected void Load0D13( )
      {
         /* Using cursor T000D6 */
         pr_default.execute(4, new Object[] {A47PromocionDistribuidorID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound13 = 1;
            A42PromocionDescripcion = T000D6_A42PromocionDescripcion[0];
            AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
            A43PromocionBase = T000D6_A43PromocionBase[0];
            AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
            A40000PromocionArte_GXI = T000D6_A40000PromocionArte_GXI[0];
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            A45PromocionFechaInicio = T000D6_A45PromocionFechaInicio[0];
            AssignAttri("", false, "A45PromocionFechaInicio", context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"));
            A46PromocionFechaFin = T000D6_A46PromocionFechaFin[0];
            AssignAttri("", false, "A46PromocionFechaFin", context.localUtil.Format(A46PromocionFechaFin, "99/99/99"));
            A11DistribuidorDescripcion = T000D6_A11DistribuidorDescripcion[0];
            AssignAttri("", false, "A11DistribuidorDescripcion", A11DistribuidorDescripcion);
            A41PromocionID = T000D6_A41PromocionID[0];
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            A10DistribuidorID = T000D6_A10DistribuidorID[0];
            AssignAttri("", false, "A10DistribuidorID", StringUtil.LTrimStr( (decimal)(A10DistribuidorID), 9, 0));
            A44PromocionArte = T000D6_A44PromocionArte[0];
            AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            ZM0D13( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0D13( ) ;
      }

      protected void OnLoadActions0D13( )
      {
      }

      protected void CheckExtendedTable0D13( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000D4 */
         pr_default.execute(2, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
            GX_FocusControl = edtPromocionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A42PromocionDescripcion = T000D4_A42PromocionDescripcion[0];
         AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
         A43PromocionBase = T000D4_A43PromocionBase[0];
         AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
         A40000PromocionArte_GXI = T000D4_A40000PromocionArte_GXI[0];
         AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
         AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
         A45PromocionFechaInicio = T000D4_A45PromocionFechaInicio[0];
         AssignAttri("", false, "A45PromocionFechaInicio", context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"));
         A46PromocionFechaFin = T000D4_A46PromocionFechaFin[0];
         AssignAttri("", false, "A46PromocionFechaFin", context.localUtil.Format(A46PromocionFechaFin, "99/99/99"));
         A44PromocionArte = T000D4_A44PromocionArte[0];
         AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
         AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
         AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
         pr_default.close(2);
         /* Using cursor T000D5 */
         pr_default.execute(3, new Object[] {A10DistribuidorID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Distribuidor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DISTRIBUIDORID");
            AnyError = 1;
            GX_FocusControl = edtDistribuidorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A11DistribuidorDescripcion = T000D5_A11DistribuidorDescripcion[0];
         AssignAttri("", false, "A11DistribuidorDescripcion", A11DistribuidorDescripcion);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0D13( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( int A41PromocionID )
      {
         /* Using cursor T000D7 */
         pr_default.execute(5, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
            GX_FocusControl = edtPromocionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A42PromocionDescripcion = T000D7_A42PromocionDescripcion[0];
         AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
         A43PromocionBase = T000D7_A43PromocionBase[0];
         AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
         A40000PromocionArte_GXI = T000D7_A40000PromocionArte_GXI[0];
         AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
         AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
         A45PromocionFechaInicio = T000D7_A45PromocionFechaInicio[0];
         AssignAttri("", false, "A45PromocionFechaInicio", context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"));
         A46PromocionFechaFin = T000D7_A46PromocionFechaFin[0];
         AssignAttri("", false, "A46PromocionFechaFin", context.localUtil.Format(A46PromocionFechaFin, "99/99/99"));
         A44PromocionArte = T000D7_A44PromocionArte[0];
         AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
         AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
         AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A42PromocionDescripcion)+"\""+","+"\""+GXUtil.EncodeJSConstant( A43PromocionBase)+"\""+","+"\""+GXUtil.EncodeJSConstant( A44PromocionArte)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000PromocionArte_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A46PromocionFechaFin, "99/99/99"))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( int A10DistribuidorID )
      {
         /* Using cursor T000D8 */
         pr_default.execute(6, new Object[] {A10DistribuidorID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Distribuidor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DISTRIBUIDORID");
            AnyError = 1;
            GX_FocusControl = edtDistribuidorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A11DistribuidorDescripcion = T000D8_A11DistribuidorDescripcion[0];
         AssignAttri("", false, "A11DistribuidorDescripcion", A11DistribuidorDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A11DistribuidorDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0D13( )
      {
         /* Using cursor T000D9 */
         pr_default.execute(7, new Object[] {A47PromocionDistribuidorID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000D3 */
         pr_default.execute(1, new Object[] {A47PromocionDistribuidorID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D13( 1) ;
            RcdFound13 = 1;
            A47PromocionDistribuidorID = T000D3_A47PromocionDistribuidorID[0];
            AssignAttri("", false, "A47PromocionDistribuidorID", StringUtil.LTrimStr( (decimal)(A47PromocionDistribuidorID), 9, 0));
            A41PromocionID = T000D3_A41PromocionID[0];
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            A10DistribuidorID = T000D3_A10DistribuidorID[0];
            AssignAttri("", false, "A10DistribuidorID", StringUtil.LTrimStr( (decimal)(A10DistribuidorID), 9, 0));
            Z47PromocionDistribuidorID = A47PromocionDistribuidorID;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0D13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0D13( ) ;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0D13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D13( ) ;
         if ( RcdFound13 == 0 )
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
         RcdFound13 = 0;
         /* Using cursor T000D10 */
         pr_default.execute(8, new Object[] {A47PromocionDistribuidorID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000D10_A47PromocionDistribuidorID[0] < A47PromocionDistribuidorID ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000D10_A47PromocionDistribuidorID[0] > A47PromocionDistribuidorID ) ) )
            {
               A47PromocionDistribuidorID = T000D10_A47PromocionDistribuidorID[0];
               AssignAttri("", false, "A47PromocionDistribuidorID", StringUtil.LTrimStr( (decimal)(A47PromocionDistribuidorID), 9, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound13 = 0;
         /* Using cursor T000D11 */
         pr_default.execute(9, new Object[] {A47PromocionDistribuidorID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000D11_A47PromocionDistribuidorID[0] > A47PromocionDistribuidorID ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000D11_A47PromocionDistribuidorID[0] < A47PromocionDistribuidorID ) ) )
            {
               A47PromocionDistribuidorID = T000D11_A47PromocionDistribuidorID[0];
               AssignAttri("", false, "A47PromocionDistribuidorID", StringUtil.LTrimStr( (decimal)(A47PromocionDistribuidorID), 9, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0D13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPromocionDistribuidorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0D13( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( A47PromocionDistribuidorID != Z47PromocionDistribuidorID )
               {
                  A47PromocionDistribuidorID = Z47PromocionDistribuidorID;
                  AssignAttri("", false, "A47PromocionDistribuidorID", StringUtil.LTrimStr( (decimal)(A47PromocionDistribuidorID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROMOCIONDISTRIBUIDORID");
                  AnyError = 1;
                  GX_FocusControl = edtPromocionDistribuidorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPromocionDistribuidorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0D13( ) ;
                  GX_FocusControl = edtPromocionDistribuidorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A47PromocionDistribuidorID != Z47PromocionDistribuidorID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPromocionDistribuidorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0D13( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROMOCIONDISTRIBUIDORID");
                     AnyError = 1;
                     GX_FocusControl = edtPromocionDistribuidorID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPromocionDistribuidorID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0D13( ) ;
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
         if ( A47PromocionDistribuidorID != Z47PromocionDistribuidorID )
         {
            A47PromocionDistribuidorID = Z47PromocionDistribuidorID;
            AssignAttri("", false, "A47PromocionDistribuidorID", StringUtil.LTrimStr( (decimal)(A47PromocionDistribuidorID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROMOCIONDISTRIBUIDORID");
            AnyError = 1;
            GX_FocusControl = edtPromocionDistribuidorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPromocionDistribuidorID_Internalname;
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
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROMOCIONDISTRIBUIDORID");
            AnyError = 1;
            GX_FocusControl = edtPromocionDistribuidorID_Internalname;
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
         ScanStart0D13( ) ;
         if ( RcdFound13 == 0 )
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
         ScanEnd0D13( ) ;
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
         if ( RcdFound13 == 0 )
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
         if ( RcdFound13 == 0 )
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
         ScanStart0D13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound13 != 0 )
            {
               ScanNext0D13( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPromocionID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0D13( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0D13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000D2 */
            pr_default.execute(0, new Object[] {A47PromocionDistribuidorID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PromocionDistribuidor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z41PromocionID != T000D2_A41PromocionID[0] ) || ( Z10DistribuidorID != T000D2_A10DistribuidorID[0] ) )
            {
               if ( Z41PromocionID != T000D2_A41PromocionID[0] )
               {
                  GXUtil.WriteLog("promociondistribuidor:[seudo value changed for attri]"+"PromocionID");
                  GXUtil.WriteLogRaw("Old: ",Z41PromocionID);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A41PromocionID[0]);
               }
               if ( Z10DistribuidorID != T000D2_A10DistribuidorID[0] )
               {
                  GXUtil.WriteLog("promociondistribuidor:[seudo value changed for attri]"+"DistribuidorID");
                  GXUtil.WriteLogRaw("Old: ",Z10DistribuidorID);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A10DistribuidorID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PromocionDistribuidor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D13( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D13( 0) ;
            CheckOptimisticConcurrency0D13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D12 */
                     pr_default.execute(10, new Object[] {A41PromocionID, A10DistribuidorID});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000D13 */
                     pr_default.execute(11);
                     A47PromocionDistribuidorID = T000D13_A47PromocionDistribuidorID[0];
                     AssignAttri("", false, "A47PromocionDistribuidorID", StringUtil.LTrimStr( (decimal)(A47PromocionDistribuidorID), 9, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("PromocionDistribuidor");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0D0( ) ;
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
               Load0D13( ) ;
            }
            EndLevel0D13( ) ;
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void Update0D13( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D14 */
                     pr_default.execute(12, new Object[] {A41PromocionID, A10DistribuidorID, A47PromocionDistribuidorID});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("PromocionDistribuidor");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PromocionDistribuidor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0D0( ) ;
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
            EndLevel0D13( ) ;
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void DeferredUpdate0D13( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D13( ) ;
            AfterConfirm0D13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000D15 */
                  pr_default.execute(13, new Object[] {A47PromocionDistribuidorID});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("PromocionDistribuidor");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound13 == 0 )
                        {
                           InitAll0D13( ) ;
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
                        ResetCaption0D0( ) ;
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0D13( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0D13( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000D16 */
            pr_default.execute(14, new Object[] {A41PromocionID});
            A42PromocionDescripcion = T000D16_A42PromocionDescripcion[0];
            AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
            A43PromocionBase = T000D16_A43PromocionBase[0];
            AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
            A40000PromocionArte_GXI = T000D16_A40000PromocionArte_GXI[0];
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            A45PromocionFechaInicio = T000D16_A45PromocionFechaInicio[0];
            AssignAttri("", false, "A45PromocionFechaInicio", context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"));
            A46PromocionFechaFin = T000D16_A46PromocionFechaFin[0];
            AssignAttri("", false, "A46PromocionFechaFin", context.localUtil.Format(A46PromocionFechaFin, "99/99/99"));
            A44PromocionArte = T000D16_A44PromocionArte[0];
            AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            pr_default.close(14);
            /* Using cursor T000D17 */
            pr_default.execute(15, new Object[] {A10DistribuidorID});
            A11DistribuidorDescripcion = T000D17_A11DistribuidorDescripcion[0];
            AssignAttri("", false, "A11DistribuidorDescripcion", A11DistribuidorDescripcion);
            pr_default.close(15);
         }
      }

      protected void EndLevel0D13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("promociondistribuidor",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("promociondistribuidor",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0D13( )
      {
         /* Using cursor T000D18 */
         pr_default.execute(16);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound13 = 1;
            A47PromocionDistribuidorID = T000D18_A47PromocionDistribuidorID[0];
            AssignAttri("", false, "A47PromocionDistribuidorID", StringUtil.LTrimStr( (decimal)(A47PromocionDistribuidorID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0D13( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound13 = 1;
            A47PromocionDistribuidorID = T000D18_A47PromocionDistribuidorID[0];
            AssignAttri("", false, "A47PromocionDistribuidorID", StringUtil.LTrimStr( (decimal)(A47PromocionDistribuidorID), 9, 0));
         }
      }

      protected void ScanEnd0D13( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm0D13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D13( )
      {
         edtPromocionDistribuidorID_Enabled = 0;
         AssignProp("", false, edtPromocionDistribuidorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionDistribuidorID_Enabled), 5, 0), true);
         edtPromocionID_Enabled = 0;
         AssignProp("", false, edtPromocionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionID_Enabled), 5, 0), true);
         edtPromocionDescripcion_Enabled = 0;
         AssignProp("", false, edtPromocionDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionDescripcion_Enabled), 5, 0), true);
         edtPromocionBase_Enabled = 0;
         AssignProp("", false, edtPromocionBase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionBase_Enabled), 5, 0), true);
         imgPromocionArte_Enabled = 0;
         AssignProp("", false, imgPromocionArte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgPromocionArte_Enabled), 5, 0), true);
         edtPromocionFechaInicio_Enabled = 0;
         AssignProp("", false, edtPromocionFechaInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionFechaInicio_Enabled), 5, 0), true);
         edtPromocionFechaFin_Enabled = 0;
         AssignProp("", false, edtPromocionFechaFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionFechaFin_Enabled), 5, 0), true);
         edtDistribuidorID_Enabled = 0;
         AssignProp("", false, edtDistribuidorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDistribuidorID_Enabled), 5, 0), true);
         edtDistribuidorDescripcion_Enabled = 0;
         AssignProp("", false, edtDistribuidorDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDistribuidorDescripcion_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0D13( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0D0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("promociondistribuidor.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z47PromocionDistribuidorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z47PromocionDistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z41PromocionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z10DistribuidorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10DistribuidorID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PROMOCIONARTE_GXI", A40000PromocionArte_GXI);
         GXCCtlgxBlob = "PROMOCIONARTE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A44PromocionArte);
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
         return formatLink("promociondistribuidor.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "PromocionDistribuidor" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Promocion Distribuidor", "") ;
      }

      protected void InitializeNonKey0D13( )
      {
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
         A45PromocionFechaInicio = DateTime.MinValue;
         AssignAttri("", false, "A45PromocionFechaInicio", context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"));
         A46PromocionFechaFin = DateTime.MinValue;
         AssignAttri("", false, "A46PromocionFechaFin", context.localUtil.Format(A46PromocionFechaFin, "99/99/99"));
         A10DistribuidorID = 0;
         AssignAttri("", false, "A10DistribuidorID", StringUtil.LTrimStr( (decimal)(A10DistribuidorID), 9, 0));
         A11DistribuidorDescripcion = "";
         AssignAttri("", false, "A11DistribuidorDescripcion", A11DistribuidorDescripcion);
         Z41PromocionID = 0;
         Z10DistribuidorID = 0;
      }

      protected void InitAll0D13( )
      {
         A47PromocionDistribuidorID = 0;
         AssignAttri("", false, "A47PromocionDistribuidorID", StringUtil.LTrimStr( (decimal)(A47PromocionDistribuidorID), 9, 0));
         InitializeNonKey0D13( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025102815462034", true, true);
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
         context.AddJavascriptSource("promociondistribuidor.js", "?2025102815462035", false, true);
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
         edtPromocionDistribuidorID_Internalname = "PROMOCIONDISTRIBUIDORID";
         edtPromocionID_Internalname = "PROMOCIONID";
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION";
         edtPromocionBase_Internalname = "PROMOCIONBASE";
         imgPromocionArte_Internalname = "PROMOCIONARTE";
         edtPromocionFechaInicio_Internalname = "PROMOCIONFECHAINICIO";
         edtPromocionFechaFin_Internalname = "PROMOCIONFECHAFIN";
         edtDistribuidorID_Internalname = "DISTRIBUIDORID";
         edtDistribuidorDescripcion_Internalname = "DISTRIBUIDORDESCRIPCION";
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
         Form.Caption = context.GetMessage( "Promocion Distribuidor", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtDistribuidorDescripcion_Jsonclick = "";
         edtDistribuidorDescripcion_Enabled = 0;
         edtDistribuidorID_Jsonclick = "";
         edtDistribuidorID_Enabled = 1;
         edtPromocionFechaFin_Jsonclick = "";
         edtPromocionFechaFin_Enabled = 0;
         edtPromocionFechaInicio_Jsonclick = "";
         edtPromocionFechaInicio_Enabled = 0;
         imgPromocionArte_Enabled = 0;
         edtPromocionBase_Enabled = 0;
         edtPromocionDescripcion_Jsonclick = "";
         edtPromocionDescripcion_Enabled = 0;
         edtPromocionID_Jsonclick = "";
         edtPromocionID_Enabled = 1;
         edtPromocionDistribuidorID_Jsonclick = "";
         edtPromocionDistribuidorID_Enabled = 1;
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

      public void Valid_Promociondistribuidorid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A41PromocionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, ".", "")));
         AssignAttri("", false, "A10DistribuidorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10DistribuidorID), 9, 0, ".", "")));
         AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
         AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
         AssignAttri("", false, "A44PromocionArte", context.PathToRelativeUrl( A44PromocionArte));
         GXCCtlgxBlob = "PROMOCIONARTE" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A44PromocionArte));
         AssignAttri("", false, "A40000PromocionArte_GXI", A40000PromocionArte_GXI);
         AssignAttri("", false, "A45PromocionFechaInicio", context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"));
         AssignAttri("", false, "A46PromocionFechaFin", context.localUtil.Format(A46PromocionFechaFin, "99/99/99"));
         AssignAttri("", false, "A11DistribuidorDescripcion", A11DistribuidorDescripcion);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z47PromocionDistribuidorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z47PromocionDistribuidorID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z41PromocionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41PromocionID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z10DistribuidorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10DistribuidorID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z42PromocionDescripcion", Z42PromocionDescripcion);
         GxWebStd.gx_hidden_field( context, "Z43PromocionBase", Z43PromocionBase);
         GxWebStd.gx_hidden_field( context, "Z44PromocionArte", context.PathToRelativeUrl( Z44PromocionArte));
         GxWebStd.gx_hidden_field( context, "Z40000PromocionArte_GXI", Z40000PromocionArte_GXI);
         GxWebStd.gx_hidden_field( context, "Z45PromocionFechaInicio", context.localUtil.Format(Z45PromocionFechaInicio, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z46PromocionFechaFin", context.localUtil.Format(Z46PromocionFechaFin, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z11DistribuidorDescripcion", Z11DistribuidorDescripcion);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Promocionid( )
      {
         /* Using cursor T000D16 */
         pr_default.execute(14, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Promocion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROMOCIONID");
            AnyError = 1;
            GX_FocusControl = edtPromocionID_Internalname;
         }
         A42PromocionDescripcion = T000D16_A42PromocionDescripcion[0];
         A43PromocionBase = T000D16_A43PromocionBase[0];
         A40000PromocionArte_GXI = T000D16_A40000PromocionArte_GXI[0];
         A45PromocionFechaInicio = T000D16_A45PromocionFechaInicio[0];
         A46PromocionFechaFin = T000D16_A46PromocionFechaFin[0];
         A44PromocionArte = T000D16_A44PromocionArte[0];
         pr_default.close(14);
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
      }

      public void Valid_Distribuidorid( )
      {
         /* Using cursor T000D17 */
         pr_default.execute(15, new Object[] {A10DistribuidorID});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Distribuidor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DISTRIBUIDORID");
            AnyError = 1;
            GX_FocusControl = edtDistribuidorID_Internalname;
         }
         A11DistribuidorDescripcion = T000D17_A11DistribuidorDescripcion[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A11DistribuidorDescripcion", A11DistribuidorDescripcion);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_PROMOCIONDISTRIBUIDORID","""{"handler":"Valid_Promociondistribuidorid","iparms":[{"av":"A47PromocionDistribuidorID","fld":"PROMOCIONDISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_PROMOCIONDISTRIBUIDORID",""","oparms":[{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"A42PromocionDescripcion","fld":"PROMOCIONDESCRIPCION"},{"av":"A43PromocionBase","fld":"PROMOCIONBASE"},{"av":"A44PromocionArte","fld":"PROMOCIONARTE"},{"av":"A40000PromocionArte_GXI","fld":"PROMOCIONARTE_GXI"},{"av":"A45PromocionFechaInicio","fld":"PROMOCIONFECHAINICIO"},{"av":"A46PromocionFechaFin","fld":"PROMOCIONFECHAFIN"},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z47PromocionDistribuidorID"},{"av":"Z41PromocionID"},{"av":"Z10DistribuidorID"},{"av":"Z42PromocionDescripcion"},{"av":"Z43PromocionBase"},{"av":"Z44PromocionArte"},{"av":"Z40000PromocionArte_GXI"},{"av":"Z45PromocionFechaInicio"},{"av":"Z46PromocionFechaFin"},{"av":"Z11DistribuidorDescripcion"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_PROMOCIONID","""{"handler":"Valid_Promocionid","iparms":[{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"},{"av":"A42PromocionDescripcion","fld":"PROMOCIONDESCRIPCION"},{"av":"A43PromocionBase","fld":"PROMOCIONBASE"},{"av":"A44PromocionArte","fld":"PROMOCIONARTE"},{"av":"A40000PromocionArte_GXI","fld":"PROMOCIONARTE_GXI"},{"av":"A45PromocionFechaInicio","fld":"PROMOCIONFECHAINICIO"},{"av":"A46PromocionFechaFin","fld":"PROMOCIONFECHAFIN"}]""");
         setEventMetadata("VALID_PROMOCIONID",""","oparms":[{"av":"A42PromocionDescripcion","fld":"PROMOCIONDESCRIPCION"},{"av":"A43PromocionBase","fld":"PROMOCIONBASE"},{"av":"A44PromocionArte","fld":"PROMOCIONARTE"},{"av":"A40000PromocionArte_GXI","fld":"PROMOCIONARTE_GXI"},{"av":"A45PromocionFechaInicio","fld":"PROMOCIONFECHAINICIO"},{"av":"A46PromocionFechaFin","fld":"PROMOCIONFECHAFIN"}]}""");
         setEventMetadata("VALID_DISTRIBUIDORID","""{"handler":"Valid_Distribuidorid","iparms":[{"av":"A10DistribuidorID","fld":"DISTRIBUIDORID","pic":"ZZZZZZZZ9"},{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"}]""");
         setEventMetadata("VALID_DISTRIBUIDORID",""","oparms":[{"av":"A11DistribuidorDescripcion","fld":"DISTRIBUIDORDESCRIPCION"}]}""");
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
         pr_default.close(14);
         pr_default.close(15);
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
         A45PromocionFechaInicio = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         A11DistribuidorDescripcion = "";
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
         Z42PromocionDescripcion = "";
         Z43PromocionBase = "";
         Z44PromocionArte = "";
         Z40000PromocionArte_GXI = "";
         Z45PromocionFechaInicio = DateTime.MinValue;
         Z46PromocionFechaFin = DateTime.MinValue;
         Z11DistribuidorDescripcion = "";
         T000D6_A47PromocionDistribuidorID = new int[1] ;
         T000D6_A42PromocionDescripcion = new string[] {""} ;
         T000D6_A43PromocionBase = new string[] {""} ;
         T000D6_A40000PromocionArte_GXI = new string[] {""} ;
         T000D6_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000D6_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         T000D6_A11DistribuidorDescripcion = new string[] {""} ;
         T000D6_A41PromocionID = new int[1] ;
         T000D6_A10DistribuidorID = new int[1] ;
         T000D6_A44PromocionArte = new string[] {""} ;
         T000D4_A42PromocionDescripcion = new string[] {""} ;
         T000D4_A43PromocionBase = new string[] {""} ;
         T000D4_A40000PromocionArte_GXI = new string[] {""} ;
         T000D4_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000D4_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         T000D4_A44PromocionArte = new string[] {""} ;
         T000D5_A11DistribuidorDescripcion = new string[] {""} ;
         T000D7_A42PromocionDescripcion = new string[] {""} ;
         T000D7_A43PromocionBase = new string[] {""} ;
         T000D7_A40000PromocionArte_GXI = new string[] {""} ;
         T000D7_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000D7_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         T000D7_A44PromocionArte = new string[] {""} ;
         T000D8_A11DistribuidorDescripcion = new string[] {""} ;
         T000D9_A47PromocionDistribuidorID = new int[1] ;
         T000D3_A47PromocionDistribuidorID = new int[1] ;
         T000D3_A41PromocionID = new int[1] ;
         T000D3_A10DistribuidorID = new int[1] ;
         sMode13 = "";
         T000D10_A47PromocionDistribuidorID = new int[1] ;
         T000D11_A47PromocionDistribuidorID = new int[1] ;
         T000D2_A47PromocionDistribuidorID = new int[1] ;
         T000D2_A41PromocionID = new int[1] ;
         T000D2_A10DistribuidorID = new int[1] ;
         T000D13_A47PromocionDistribuidorID = new int[1] ;
         T000D16_A42PromocionDescripcion = new string[] {""} ;
         T000D16_A43PromocionBase = new string[] {""} ;
         T000D16_A40000PromocionArte_GXI = new string[] {""} ;
         T000D16_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000D16_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         T000D16_A44PromocionArte = new string[] {""} ;
         T000D17_A11DistribuidorDescripcion = new string[] {""} ;
         T000D18_A47PromocionDistribuidorID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZZ42PromocionDescripcion = "";
         ZZ43PromocionBase = "";
         ZZ44PromocionArte = "";
         ZZ40000PromocionArte_GXI = "";
         ZZ45PromocionFechaInicio = DateTime.MinValue;
         ZZ46PromocionFechaFin = DateTime.MinValue;
         ZZ11DistribuidorDescripcion = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.promociondistribuidor__default(),
            new Object[][] {
                new Object[] {
               T000D2_A47PromocionDistribuidorID, T000D2_A41PromocionID, T000D2_A10DistribuidorID
               }
               , new Object[] {
               T000D3_A47PromocionDistribuidorID, T000D3_A41PromocionID, T000D3_A10DistribuidorID
               }
               , new Object[] {
               T000D4_A42PromocionDescripcion, T000D4_A43PromocionBase, T000D4_A40000PromocionArte_GXI, T000D4_A45PromocionFechaInicio, T000D4_A46PromocionFechaFin, T000D4_A44PromocionArte
               }
               , new Object[] {
               T000D5_A11DistribuidorDescripcion
               }
               , new Object[] {
               T000D6_A47PromocionDistribuidorID, T000D6_A42PromocionDescripcion, T000D6_A43PromocionBase, T000D6_A40000PromocionArte_GXI, T000D6_A45PromocionFechaInicio, T000D6_A46PromocionFechaFin, T000D6_A11DistribuidorDescripcion, T000D6_A41PromocionID, T000D6_A10DistribuidorID, T000D6_A44PromocionArte
               }
               , new Object[] {
               T000D7_A42PromocionDescripcion, T000D7_A43PromocionBase, T000D7_A40000PromocionArte_GXI, T000D7_A45PromocionFechaInicio, T000D7_A46PromocionFechaFin, T000D7_A44PromocionArte
               }
               , new Object[] {
               T000D8_A11DistribuidorDescripcion
               }
               , new Object[] {
               T000D9_A47PromocionDistribuidorID
               }
               , new Object[] {
               T000D10_A47PromocionDistribuidorID
               }
               , new Object[] {
               T000D11_A47PromocionDistribuidorID
               }
               , new Object[] {
               }
               , new Object[] {
               T000D13_A47PromocionDistribuidorID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000D16_A42PromocionDescripcion, T000D16_A43PromocionBase, T000D16_A40000PromocionArte_GXI, T000D16_A45PromocionFechaInicio, T000D16_A46PromocionFechaFin, T000D16_A44PromocionArte
               }
               , new Object[] {
               T000D17_A11DistribuidorDescripcion
               }
               , new Object[] {
               T000D18_A47PromocionDistribuidorID
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
      private short RcdFound13 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z47PromocionDistribuidorID ;
      private int Z41PromocionID ;
      private int Z10DistribuidorID ;
      private int A41PromocionID ;
      private int A10DistribuidorID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A47PromocionDistribuidorID ;
      private int edtPromocionDistribuidorID_Enabled ;
      private int edtPromocionID_Enabled ;
      private int edtPromocionDescripcion_Enabled ;
      private int edtPromocionBase_Enabled ;
      private int imgPromocionArte_Enabled ;
      private int edtPromocionFechaInicio_Enabled ;
      private int edtPromocionFechaFin_Enabled ;
      private int edtDistribuidorID_Enabled ;
      private int edtDistribuidorDescripcion_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ47PromocionDistribuidorID ;
      private int ZZ41PromocionID ;
      private int ZZ10DistribuidorID ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPromocionDistribuidorID_Internalname ;
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
      private string edtPromocionDistribuidorID_Jsonclick ;
      private string edtPromocionID_Internalname ;
      private string edtPromocionID_Jsonclick ;
      private string edtPromocionDescripcion_Internalname ;
      private string edtPromocionDescripcion_Jsonclick ;
      private string edtPromocionBase_Internalname ;
      private string imgPromocionArte_Internalname ;
      private string sImgUrl ;
      private string edtPromocionFechaInicio_Internalname ;
      private string edtPromocionFechaInicio_Jsonclick ;
      private string edtPromocionFechaFin_Internalname ;
      private string edtPromocionFechaFin_Jsonclick ;
      private string edtDistribuidorID_Internalname ;
      private string edtDistribuidorID_Jsonclick ;
      private string edtDistribuidorDescripcion_Internalname ;
      private string edtDistribuidorDescripcion_Jsonclick ;
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
      private string sMode13 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private DateTime A45PromocionFechaInicio ;
      private DateTime A46PromocionFechaFin ;
      private DateTime Z45PromocionFechaInicio ;
      private DateTime Z46PromocionFechaFin ;
      private DateTime ZZ45PromocionFechaInicio ;
      private DateTime ZZ46PromocionFechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A44PromocionArte_IsBlob ;
      private string A42PromocionDescripcion ;
      private string A43PromocionBase ;
      private string A40000PromocionArte_GXI ;
      private string A11DistribuidorDescripcion ;
      private string Z42PromocionDescripcion ;
      private string Z43PromocionBase ;
      private string Z40000PromocionArte_GXI ;
      private string Z11DistribuidorDescripcion ;
      private string ZZ42PromocionDescripcion ;
      private string ZZ43PromocionBase ;
      private string ZZ40000PromocionArte_GXI ;
      private string ZZ11DistribuidorDescripcion ;
      private string A44PromocionArte ;
      private string Z44PromocionArte ;
      private string ZZ44PromocionArte ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000D6_A47PromocionDistribuidorID ;
      private string[] T000D6_A42PromocionDescripcion ;
      private string[] T000D6_A43PromocionBase ;
      private string[] T000D6_A40000PromocionArte_GXI ;
      private DateTime[] T000D6_A45PromocionFechaInicio ;
      private DateTime[] T000D6_A46PromocionFechaFin ;
      private string[] T000D6_A11DistribuidorDescripcion ;
      private int[] T000D6_A41PromocionID ;
      private int[] T000D6_A10DistribuidorID ;
      private string[] T000D6_A44PromocionArte ;
      private string[] T000D4_A42PromocionDescripcion ;
      private string[] T000D4_A43PromocionBase ;
      private string[] T000D4_A40000PromocionArte_GXI ;
      private DateTime[] T000D4_A45PromocionFechaInicio ;
      private DateTime[] T000D4_A46PromocionFechaFin ;
      private string[] T000D4_A44PromocionArte ;
      private string[] T000D5_A11DistribuidorDescripcion ;
      private string[] T000D7_A42PromocionDescripcion ;
      private string[] T000D7_A43PromocionBase ;
      private string[] T000D7_A40000PromocionArte_GXI ;
      private DateTime[] T000D7_A45PromocionFechaInicio ;
      private DateTime[] T000D7_A46PromocionFechaFin ;
      private string[] T000D7_A44PromocionArte ;
      private string[] T000D8_A11DistribuidorDescripcion ;
      private int[] T000D9_A47PromocionDistribuidorID ;
      private int[] T000D3_A47PromocionDistribuidorID ;
      private int[] T000D3_A41PromocionID ;
      private int[] T000D3_A10DistribuidorID ;
      private int[] T000D10_A47PromocionDistribuidorID ;
      private int[] T000D11_A47PromocionDistribuidorID ;
      private int[] T000D2_A47PromocionDistribuidorID ;
      private int[] T000D2_A41PromocionID ;
      private int[] T000D2_A10DistribuidorID ;
      private int[] T000D13_A47PromocionDistribuidorID ;
      private string[] T000D16_A42PromocionDescripcion ;
      private string[] T000D16_A43PromocionBase ;
      private string[] T000D16_A40000PromocionArte_GXI ;
      private DateTime[] T000D16_A45PromocionFechaInicio ;
      private DateTime[] T000D16_A46PromocionFechaFin ;
      private string[] T000D16_A44PromocionArte ;
      private string[] T000D17_A11DistribuidorDescripcion ;
      private int[] T000D18_A47PromocionDistribuidorID ;
   }

   public class promociondistribuidor__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000D2;
          prmT000D2 = new Object[] {
          new ParDef("@PromocionDistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmT000D3;
          prmT000D3 = new Object[] {
          new ParDef("@PromocionDistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmT000D4;
          prmT000D4 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000D5;
          prmT000D5 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmT000D6;
          prmT000D6 = new Object[] {
          new ParDef("@PromocionDistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmT000D7;
          prmT000D7 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000D8;
          prmT000D8 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmT000D9;
          prmT000D9 = new Object[] {
          new ParDef("@PromocionDistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmT000D10;
          prmT000D10 = new Object[] {
          new ParDef("@PromocionDistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmT000D11;
          prmT000D11 = new Object[] {
          new ParDef("@PromocionDistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmT000D12;
          prmT000D12 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0) ,
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmT000D13;
          prmT000D13 = new Object[] {
          };
          Object[] prmT000D14;
          prmT000D14 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0) ,
          new ParDef("@DistribuidorID",GXType.Int32,9,0) ,
          new ParDef("@PromocionDistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmT000D15;
          prmT000D15 = new Object[] {
          new ParDef("@PromocionDistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmT000D16;
          prmT000D16 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000D17;
          prmT000D17 = new Object[] {
          new ParDef("@DistribuidorID",GXType.Int32,9,0)
          };
          Object[] prmT000D18;
          prmT000D18 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000D2", "SELECT `PromocionDistribuidorID`, `PromocionID`, `DistribuidorID` FROM `PromocionDistribuidor` WHERE `PromocionDistribuidorID` = @PromocionDistribuidorID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D3", "SELECT `PromocionDistribuidorID`, `PromocionID`, `DistribuidorID` FROM `PromocionDistribuidor` WHERE `PromocionDistribuidorID` = @PromocionDistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D4", "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D5", "SELECT `DistribuidorDescripcion` FROM `Distribuidor` WHERE `DistribuidorID` = @DistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D6", "SELECT TM1.`PromocionDistribuidorID`, T2.`PromocionDescripcion`, T2.`PromocionBase`, T2.`PromocionArte_GXI`, T2.`PromocionFechaInicio`, T2.`PromocionFechaFin`, T3.`DistribuidorDescripcion`, TM1.`PromocionID`, TM1.`DistribuidorID`, T2.`PromocionArte` FROM ((`PromocionDistribuidor` TM1 INNER JOIN `Promocion` T2 ON T2.`PromocionID` = TM1.`PromocionID`) INNER JOIN `Distribuidor` T3 ON T3.`DistribuidorID` = TM1.`DistribuidorID`) WHERE TM1.`PromocionDistribuidorID` = @PromocionDistribuidorID ORDER BY TM1.`PromocionDistribuidorID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D7", "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D8", "SELECT `DistribuidorDescripcion` FROM `Distribuidor` WHERE `DistribuidorID` = @DistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D9", "SELECT `PromocionDistribuidorID` FROM `PromocionDistribuidor` WHERE `PromocionDistribuidorID` = @PromocionDistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D10", "SELECT `PromocionDistribuidorID` FROM `PromocionDistribuidor` WHERE ( `PromocionDistribuidorID` > @PromocionDistribuidorID) ORDER BY `PromocionDistribuidorID`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000D10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000D11", "SELECT `PromocionDistribuidorID` FROM `PromocionDistribuidor` WHERE ( `PromocionDistribuidorID` < @PromocionDistribuidorID) ORDER BY `PromocionDistribuidorID` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000D11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000D12", "INSERT INTO `PromocionDistribuidor`(`PromocionID`, `DistribuidorID`) VALUES(@PromocionID, @DistribuidorID)", GxErrorMask.GX_NOMASK,prmT000D12)
             ,new CursorDef("T000D13", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D14", "UPDATE `PromocionDistribuidor` SET `PromocionID`=@PromocionID, `DistribuidorID`=@DistribuidorID  WHERE `PromocionDistribuidorID` = @PromocionDistribuidorID", GxErrorMask.GX_NOMASK,prmT000D14)
             ,new CursorDef("T000D15", "DELETE FROM `PromocionDistribuidor`  WHERE `PromocionDistribuidorID` = @PromocionDistribuidorID", GxErrorMask.GX_NOMASK,prmT000D15)
             ,new CursorDef("T000D16", "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D17", "SELECT `DistribuidorDescripcion` FROM `Distribuidor` WHERE `DistribuidorID` = @DistribuidorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D18", "SELECT `PromocionDistribuidorID` FROM `PromocionDistribuidor` ORDER BY `PromocionDistribuidorID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D18,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(4));
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
