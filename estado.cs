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
   public class estado : GXDataArea
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
         gxfirstwebparm = GetFirstPar( "Mode");
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
            A16PaisID = (int)(Math.Round(NumberUtil.Val( GetPar( "PaisID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A16PaisID) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "estado.aspx")), "estado.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "estado.aspx")))) ;
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
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7EstadoID = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7EstadoID", StringUtil.LTrimStr( (decimal)(AV7EstadoID), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vESTADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EstadoID), "ZZZZZZZZ9"), context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Estado", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public estado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public estado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_EstadoID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EstadoID = aP1_EstadoID;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkEstadoActivo = new GXCheckbox();
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
         A3EstadoActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A3EstadoActivo));
         AssignAttri("", false, "A3EstadoActivo", A3EstadoActivo);
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
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadoID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoID_Internalname, context.GetMessage( "ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EstadoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtEstadoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EstadoID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1EstadoID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadoID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Estado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedpaisid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockpaisid_Internalname, context.GetMessage( "Pais", ""), "", "", lblTextblockpaisid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Estado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_paisid.SetProperty("Caption", Combo_paisid_Caption);
         ucCombo_paisid.SetProperty("Cls", Combo_paisid_Cls);
         ucCombo_paisid.SetProperty("DataListProc", Combo_paisid_Datalistproc);
         ucCombo_paisid.SetProperty("DataListProcParametersPrefix", Combo_paisid_Datalistprocparametersprefix);
         ucCombo_paisid.SetProperty("EmptyItem", Combo_paisid_Emptyitem);
         ucCombo_paisid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_paisid.SetProperty("DropDownOptionsData", AV13PaisID_Data);
         ucCombo_paisid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_paisid_Internalname, "COMBO_PAISIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisID_Internalname, context.GetMessage( "Pais ID", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A16PaisID), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "Attribute", "", "", "", "", edtPaisID_Visible, edtPaisID_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Estado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadoDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoDescripcion_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadoDescripcion_Internalname, A2EstadoDescripcion, StringUtil.RTrim( context.localUtil.Format( A2EstadoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoDescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Estado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkEstadoActivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkEstadoActivo_Internalname, context.GetMessage( "Activo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkEstadoActivo_Internalname, StringUtil.BoolToStr( A3EstadoActivo), "", context.GetMessage( "Activo", ""), 1, chkEstadoActivo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(43, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,43);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Estado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Estado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Estado.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_paisid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombopaisid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ComboPaisID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCombopaisid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18ComboPaisID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV18ComboPaisID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombopaisid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombopaisid_Visible, edtavCombopaisid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Estado.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11012 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPAISID_DATA"), AV13PaisID_Data);
               /* Read saved values. */
               Z1EstadoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1EstadoID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z2EstadoDescripcion = cgiGet( "Z2EstadoDescripcion");
               Z3EstadoActivo = StringUtil.StrToBool( cgiGet( "Z3EstadoActivo"));
               Z16PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z16PaisID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N16PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N16PaisID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7EstadoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vESTADOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV11Insert_PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PAISID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A17PaisDescripcion = cgiGet( "PAISDESCRIPCION");
               AV19Pgmname = cgiGet( "vPGMNAME");
               Combo_paisid_Objectcall = cgiGet( "COMBO_PAISID_Objectcall");
               Combo_paisid_Class = cgiGet( "COMBO_PAISID_Class");
               Combo_paisid_Icontype = cgiGet( "COMBO_PAISID_Icontype");
               Combo_paisid_Icon = cgiGet( "COMBO_PAISID_Icon");
               Combo_paisid_Caption = cgiGet( "COMBO_PAISID_Caption");
               Combo_paisid_Tooltip = cgiGet( "COMBO_PAISID_Tooltip");
               Combo_paisid_Cls = cgiGet( "COMBO_PAISID_Cls");
               Combo_paisid_Selectedvalue_set = cgiGet( "COMBO_PAISID_Selectedvalue_set");
               Combo_paisid_Selectedvalue_get = cgiGet( "COMBO_PAISID_Selectedvalue_get");
               Combo_paisid_Selectedtext_set = cgiGet( "COMBO_PAISID_Selectedtext_set");
               Combo_paisid_Selectedtext_get = cgiGet( "COMBO_PAISID_Selectedtext_get");
               Combo_paisid_Gamoauthtoken = cgiGet( "COMBO_PAISID_Gamoauthtoken");
               Combo_paisid_Ddointernalname = cgiGet( "COMBO_PAISID_Ddointernalname");
               Combo_paisid_Titlecontrolalign = cgiGet( "COMBO_PAISID_Titlecontrolalign");
               Combo_paisid_Dropdownoptionstype = cgiGet( "COMBO_PAISID_Dropdownoptionstype");
               Combo_paisid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Enabled"));
               Combo_paisid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Visible"));
               Combo_paisid_Titlecontrolidtoreplace = cgiGet( "COMBO_PAISID_Titlecontrolidtoreplace");
               Combo_paisid_Datalisttype = cgiGet( "COMBO_PAISID_Datalisttype");
               Combo_paisid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Allowmultipleselection"));
               Combo_paisid_Datalistfixedvalues = cgiGet( "COMBO_PAISID_Datalistfixedvalues");
               Combo_paisid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Isgriditem"));
               Combo_paisid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Hasdescription"));
               Combo_paisid_Datalistproc = cgiGet( "COMBO_PAISID_Datalistproc");
               Combo_paisid_Datalistprocparametersprefix = cgiGet( "COMBO_PAISID_Datalistprocparametersprefix");
               Combo_paisid_Remoteservicesparameters = cgiGet( "COMBO_PAISID_Remoteservicesparameters");
               Combo_paisid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PAISID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_paisid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Includeonlyselectedoption"));
               Combo_paisid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Includeselectalloption"));
               Combo_paisid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Emptyitem"));
               Combo_paisid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PAISID_Includeaddnewoption"));
               Combo_paisid_Htmltemplate = cgiGet( "COMBO_PAISID_Htmltemplate");
               Combo_paisid_Multiplevaluestype = cgiGet( "COMBO_PAISID_Multiplevaluestype");
               Combo_paisid_Loadingdata = cgiGet( "COMBO_PAISID_Loadingdata");
               Combo_paisid_Noresultsfound = cgiGet( "COMBO_PAISID_Noresultsfound");
               Combo_paisid_Emptyitemtext = cgiGet( "COMBO_PAISID_Emptyitemtext");
               Combo_paisid_Onlyselectedvalues = cgiGet( "COMBO_PAISID_Onlyselectedvalues");
               Combo_paisid_Selectalltext = cgiGet( "COMBO_PAISID_Selectalltext");
               Combo_paisid_Multiplevaluesseparator = cgiGet( "COMBO_PAISID_Multiplevaluesseparator");
               Combo_paisid_Addnewoptiontext = cgiGet( "COMBO_PAISID_Addnewoptiontext");
               Combo_paisid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PAISID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Titletype = cgiGet( "DVPANEL_TABLEATTRIBUTES_Titletype");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               /* Read variables values. */
               A1EstadoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtPaisID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPaisID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAISID");
                  AnyError = 1;
                  GX_FocusControl = edtPaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A16PaisID = 0;
                  AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
               }
               else
               {
                  A16PaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPaisID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
               }
               A2EstadoDescripcion = cgiGet( edtEstadoDescripcion_Internalname);
               AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
               A3EstadoActivo = StringUtil.StrToBool( cgiGet( chkEstadoActivo_Internalname));
               AssignAttri("", false, "A3EstadoActivo", A3EstadoActivo);
               AV18ComboPaisID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombopaisid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18ComboPaisID", StringUtil.LTrimStr( (decimal)(AV18ComboPaisID), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Estado");
               A1EstadoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
               forbiddenHiddens.Add("EstadoID", context.localUtil.Format( (decimal)(A1EstadoID), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1EstadoID != Z1EstadoID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("estado:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A1EstadoID = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode1 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode1;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound1 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_010( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ESTADOID");
                        AnyError = 1;
                        GX_FocusControl = edtEstadoID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
            /* Execute user event: After Trn */
            E12012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
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
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes011( ) ;
         }
         AssignProp("", false, edtavCombopaisid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopaisid_Enabled), 5, 0), true);
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption010( )
      {
      }

      protected void E11012( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtPaisID_Visible = 0;
         AssignProp("", false, edtPaisID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPaisID_Visible), 5, 0), true);
         AV18ComboPaisID = 0;
         AssignAttri("", false, "AV18ComboPaisID", StringUtil.LTrimStr( (decimal)(AV18ComboPaisID), 9, 0));
         edtavCombopaisid_Visible = 0;
         AssignProp("", false, edtavCombopaisid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombopaisid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOPAISID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV19Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV20GXV1 = 1;
            AssignAttri("", false, "AV20GXV1", StringUtil.LTrimStr( (decimal)(AV20GXV1), 8, 0));
            while ( AV20GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV20GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "PaisID") == 0 )
               {
                  AV11Insert_PaisID = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_PaisID", StringUtil.LTrimStr( (decimal)(AV11Insert_PaisID), 9, 0));
                  if ( ! (0==AV11Insert_PaisID) )
                  {
                     AV18ComboPaisID = AV11Insert_PaisID;
                     AssignAttri("", false, "AV18ComboPaisID", StringUtil.LTrimStr( (decimal)(AV18ComboPaisID), 9, 0));
                     Combo_paisid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV18ComboPaisID), 9, 0));
                     ucCombo_paisid.SendProperty(context, "", false, Combo_paisid_Internalname, "SelectedValue_set", Combo_paisid_Selectedvalue_set);
                     GXt_char2 = AV17Combo_DataJson;
                     new estadoloaddvcombo(context ).execute(  "PaisID",  "GET",  false,  AV7EstadoID,  AV12TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
                     AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
                     AV17Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
                     Combo_paisid_Selectedtext_set = AV16ComboSelectedText;
                     ucCombo_paisid.SendProperty(context, "", false, Combo_paisid_Internalname, "SelectedText_set", Combo_paisid_Selectedtext_set);
                     Combo_paisid_Enabled = false;
                     ucCombo_paisid.SendProperty(context, "", false, Combo_paisid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paisid_Enabled));
                  }
               }
               AV20GXV1 = (int)(AV20GXV1+1);
               AssignAttri("", false, "AV20GXV1", StringUtil.LTrimStr( (decimal)(AV20GXV1), 8, 0));
            }
         }
      }

      protected void E12012( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("estadoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPAISID' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new estadoloaddvcombo(context ).execute(  "PaisID",  Gx_mode,  false,  AV7EstadoID,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
         Combo_paisid_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_paisid.SendProperty(context, "", false, Combo_paisid_Internalname, "SelectedValue_set", Combo_paisid_Selectedvalue_set);
         Combo_paisid_Selectedtext_set = AV16ComboSelectedText;
         ucCombo_paisid.SendProperty(context, "", false, Combo_paisid_Internalname, "SelectedText_set", Combo_paisid_Selectedtext_set);
         AV18ComboPaisID = (int)(Math.Round(NumberUtil.Val( AV15ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV18ComboPaisID", StringUtil.LTrimStr( (decimal)(AV18ComboPaisID), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_paisid_Enabled = false;
            ucCombo_paisid.SendProperty(context, "", false, Combo_paisid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paisid_Enabled));
         }
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2EstadoDescripcion = T00013_A2EstadoDescripcion[0];
               Z3EstadoActivo = T00013_A3EstadoActivo[0];
               Z16PaisID = T00013_A16PaisID[0];
            }
            else
            {
               Z2EstadoDescripcion = A2EstadoDescripcion;
               Z3EstadoActivo = A3EstadoActivo;
               Z16PaisID = A16PaisID;
            }
         }
         if ( GX_JID == -8 )
         {
            Z1EstadoID = A1EstadoID;
            Z2EstadoDescripcion = A2EstadoDescripcion;
            Z3EstadoActivo = A3EstadoActivo;
            Z16PaisID = A16PaisID;
            Z17PaisDescripcion = A17PaisDescripcion;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEstadoID_Enabled = 0;
         AssignProp("", false, edtEstadoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoID_Enabled), 5, 0), true);
         AV19Pgmname = "Estado";
         AssignAttri("", false, "AV19Pgmname", AV19Pgmname);
         edtEstadoID_Enabled = 0;
         AssignProp("", false, edtEstadoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoID_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7EstadoID) )
         {
            A1EstadoID = AV7EstadoID;
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PaisID) )
         {
            edtPaisID_Enabled = 0;
            AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         }
         else
         {
            edtPaisID_Enabled = 1;
            AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PaisID) )
         {
            A16PaisID = AV11Insert_PaisID;
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
         }
         else
         {
            A16PaisID = AV18ComboPaisID;
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00014 */
            pr_default.execute(2, new Object[] {A16PaisID});
            A17PaisDescripcion = T00014_A17PaisDescripcion[0];
            pr_default.close(2);
         }
      }

      protected void Load011( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
            A17PaisDescripcion = T00015_A17PaisDescripcion[0];
            A2EstadoDescripcion = T00015_A2EstadoDescripcion[0];
            AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
            A3EstadoActivo = T00015_A3EstadoActivo[0];
            AssignAttri("", false, "A3EstadoActivo", A3EstadoActivo);
            A16PaisID = T00015_A16PaisID[0];
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            ZM011( -8) ;
         }
         pr_default.close(3);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A17PaisDescripcion = T00014_A17PaisDescripcion[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors011( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( int A16PaisID )
      {
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A17PaisDescripcion = T00016_A17PaisDescripcion[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A17PaisDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey011( )
      {
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 8) ;
            RcdFound1 = 1;
            A1EstadoID = T00013_A1EstadoID[0];
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            A2EstadoDescripcion = T00013_A2EstadoDescripcion[0];
            AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
            A3EstadoActivo = T00013_A3EstadoActivo[0];
            AssignAttri("", false, "A3EstadoActivo", A3EstadoActivo);
            A16PaisID = T00013_A16PaisID[0];
            AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
            Z1EstadoID = A1EstadoID;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T00018 */
         pr_default.execute(6, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00018_A1EstadoID[0] < A1EstadoID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00018_A1EstadoID[0] > A1EstadoID ) ) )
            {
               A1EstadoID = T00018_A1EstadoID[0];
               AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00019 */
         pr_default.execute(7, new Object[] {A1EstadoID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00019_A1EstadoID[0] > A1EstadoID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00019_A1EstadoID[0] < A1EstadoID ) ) )
            {
               A1EstadoID = T00019_A1EstadoID[0];
               AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1EstadoID != Z1EstadoID )
               {
                  A1EstadoID = Z1EstadoID;
                  AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ESTADOID");
                  AnyError = 1;
                  GX_FocusControl = edtEstadoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtPaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1EstadoID != Z1EstadoID )
               {
                  /* Insert record */
                  GX_FocusControl = edtPaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ESTADOID");
                     AnyError = 1;
                     GX_FocusControl = edtEstadoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPaisID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A1EstadoID != Z1EstadoID )
         {
            A1EstadoID = Z1EstadoID;
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ESTADOID");
            AnyError = 1;
            GX_FocusControl = edtEstadoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1EstadoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Estado"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2EstadoDescripcion, T00012_A2EstadoDescripcion[0]) != 0 ) || ( Z3EstadoActivo != T00012_A3EstadoActivo[0] ) || ( Z16PaisID != T00012_A16PaisID[0] ) )
            {
               if ( StringUtil.StrCmp(Z2EstadoDescripcion, T00012_A2EstadoDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("estado:[seudo value changed for attri]"+"EstadoDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z2EstadoDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T00012_A2EstadoDescripcion[0]);
               }
               if ( Z3EstadoActivo != T00012_A3EstadoActivo[0] )
               {
                  GXUtil.WriteLog("estado:[seudo value changed for attri]"+"EstadoActivo");
                  GXUtil.WriteLogRaw("Old: ",Z3EstadoActivo);
                  GXUtil.WriteLogRaw("Current: ",T00012_A3EstadoActivo[0]);
               }
               if ( Z16PaisID != T00012_A16PaisID[0] )
               {
                  GXUtil.WriteLog("estado:[seudo value changed for attri]"+"PaisID");
                  GXUtil.WriteLogRaw("Old: ",Z16PaisID);
                  GXUtil.WriteLogRaw("Current: ",T00012_A16PaisID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Estado"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000110 */
                     pr_default.execute(8, new Object[] {A2EstadoDescripcion, A3EstadoActivo, A16PaisID});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000111 */
                     pr_default.execute(9);
                     A1EstadoID = T000111_A1EstadoID[0];
                     AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Estado");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption010( ) ;
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000112 */
                     pr_default.execute(10, new Object[] {A2EstadoDescripcion, A3EstadoActivo, A16PaisID, A1EstadoID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Estado");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Estado"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
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
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000113 */
                  pr_default.execute(11, new Object[] {A1EstadoID});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Estado");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
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
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000114 */
            pr_default.execute(12, new Object[] {A16PaisID});
            A17PaisDescripcion = T000114_A17PaisDescripcion[0];
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000115 */
            pr_default.execute(13, new Object[] {A1EstadoID});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Ciudad", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("estado",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("estado",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Scan By routine */
         /* Using cursor T000116 */
         pr_default.execute(14);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound1 = 1;
            A1EstadoID = T000116_A1EstadoID[0];
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound1 = 1;
            A1EstadoID = T000116_A1EstadoID[0];
            AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtEstadoID_Enabled = 0;
         AssignProp("", false, edtEstadoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoID_Enabled), 5, 0), true);
         edtPaisID_Enabled = 0;
         AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         edtEstadoDescripcion_Enabled = 0;
         AssignProp("", false, edtEstadoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoDescripcion_Enabled), 5, 0), true);
         chkEstadoActivo.Enabled = 0;
         AssignProp("", false, chkEstadoActivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEstadoActivo.Enabled), 5, 0), true);
         edtavCombopaisid_Enabled = 0;
         AssignProp("", false, edtavCombopaisid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopaisid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "estado.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7EstadoID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("estado.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Estado");
         forbiddenHiddens.Add("EstadoID", context.localUtil.Format( (decimal)(A1EstadoID), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("estado:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1EstadoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EstadoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z2EstadoDescripcion", Z2EstadoDescripcion);
         GxWebStd.gx_boolean_hidden_field( context, "Z3EstadoActivo", Z3EstadoActivo);
         GxWebStd.gx_hidden_field( context, "Z16PaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16PaisID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N16PaisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPAISID_DATA", AV13PaisID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPAISID_DATA", AV13PaisID_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vESTADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EstadoID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EstadoID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_PaisID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PAISDESCRIPCION", A17PaisDescripcion);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV19Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Objectcall", StringUtil.RTrim( Combo_paisid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Cls", StringUtil.RTrim( Combo_paisid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Selectedvalue_set", StringUtil.RTrim( Combo_paisid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Selectedtext_set", StringUtil.RTrim( Combo_paisid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Enabled", StringUtil.BoolToStr( Combo_paisid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Datalistproc", StringUtil.RTrim( Combo_paisid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_paisid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PAISID_Emptyitem", StringUtil.BoolToStr( Combo_paisid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "estado.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7EstadoID,9,0));
         return formatLink("estado.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Estado" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Estado", "") ;
      }

      protected void InitializeNonKey011( )
      {
         A16PaisID = 0;
         AssignAttri("", false, "A16PaisID", StringUtil.LTrimStr( (decimal)(A16PaisID), 9, 0));
         A17PaisDescripcion = "";
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
         A2EstadoDescripcion = "";
         AssignAttri("", false, "A2EstadoDescripcion", A2EstadoDescripcion);
         A3EstadoActivo = false;
         AssignAttri("", false, "A3EstadoActivo", A3EstadoActivo);
         Z2EstadoDescripcion = "";
         Z3EstadoActivo = false;
         Z16PaisID = 0;
      }

      protected void InitAll011( )
      {
         A1EstadoID = 0;
         AssignAttri("", false, "A1EstadoID", StringUtil.LTrimStr( (decimal)(A1EstadoID), 9, 0));
         InitializeNonKey011( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025102815461884", true, true);
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
         context.AddJavascriptSource("estado.js", "?2025102815461885", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtEstadoID_Internalname = "ESTADOID";
         lblTextblockpaisid_Internalname = "TEXTBLOCKPAISID";
         Combo_paisid_Internalname = "COMBO_PAISID";
         edtPaisID_Internalname = "PAISID";
         divTablesplittedpaisid_Internalname = "TABLESPLITTEDPAISID";
         edtEstadoDescripcion_Internalname = "ESTADODESCRIPCION";
         chkEstadoActivo_Internalname = "ESTADOACTIVO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombopaisid_Internalname = "vCOMBOPAISID";
         divSectionattribute_paisid_Internalname = "SECTIONATTRIBUTE_PAISID";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Estado", "");
         edtavCombopaisid_Jsonclick = "";
         edtavCombopaisid_Enabled = 0;
         edtavCombopaisid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkEstadoActivo.Enabled = 1;
         edtEstadoDescripcion_Jsonclick = "";
         edtEstadoDescripcion_Enabled = 1;
         edtPaisID_Jsonclick = "";
         edtPaisID_Enabled = 1;
         edtPaisID_Visible = 1;
         Combo_paisid_Emptyitem = Convert.ToBoolean( 0);
         Combo_paisid_Datalistprocparametersprefix = " \"ComboName\": \"PaisID\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"EstadoID\": 0";
         Combo_paisid_Datalistproc = "EstadoLoadDVCombo";
         Combo_paisid_Cls = "ExtendedCombo AttributeFL";
         Combo_paisid_Caption = "";
         Combo_paisid_Enabled = Convert.ToBoolean( -1);
         edtEstadoID_Jsonclick = "";
         edtEstadoID_Enabled = 0;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = context.GetMessage( "WWP_TemplateDataPanelTitle", "");
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
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
         chkEstadoActivo.Name = "ESTADOACTIVO";
         chkEstadoActivo.WebTags = "";
         chkEstadoActivo.Caption = context.GetMessage( "Activo", "");
         AssignProp("", false, chkEstadoActivo_Internalname, "TitleCaption", chkEstadoActivo.Caption, true);
         chkEstadoActivo.CheckedValue = "false";
         A3EstadoActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A3EstadoActivo));
         AssignAttri("", false, "A3EstadoActivo", A3EstadoActivo);
         /* End function init_web_controls */
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

      public void Valid_Paisid( )
      {
         /* Using cursor T000114 */
         pr_default.execute(12, new Object[] {A16PaisID});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Pais", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisID_Internalname;
         }
         A17PaisDescripcion = T000114_A17PaisDescripcion[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A17PaisDescripcion", A17PaisDescripcion);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7EstadoID","fld":"vESTADOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A3EstadoActivo","fld":"ESTADOACTIVO"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A3EstadoActivo","fld":"ESTADOACTIVO"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7EstadoID","fld":"vESTADOID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A1EstadoID","fld":"ESTADOID","pic":"ZZZZZZZZ9"},{"av":"A3EstadoActivo","fld":"ESTADOACTIVO"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A3EstadoActivo","fld":"ESTADOACTIVO"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12012","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"A3EstadoActivo","fld":"ESTADOACTIVO"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"A3EstadoActivo","fld":"ESTADOACTIVO"}]}""");
         setEventMetadata("VALID_ESTADOID","""{"handler":"Valid_Estadoid","iparms":[{"av":"A3EstadoActivo","fld":"ESTADOACTIVO"}]""");
         setEventMetadata("VALID_ESTADOID",""","oparms":[{"av":"A3EstadoActivo","fld":"ESTADOACTIVO"}]}""");
         setEventMetadata("VALID_PAISID","""{"handler":"Valid_Paisid","iparms":[{"av":"A16PaisID","fld":"PAISID","pic":"ZZZZZZZZ9"},{"av":"A17PaisDescripcion","fld":"PAISDESCRIPCION"},{"av":"A3EstadoActivo","fld":"ESTADOACTIVO"}]""");
         setEventMetadata("VALID_PAISID",""","oparms":[{"av":"A17PaisDescripcion","fld":"PAISDESCRIPCION"},{"av":"A3EstadoActivo","fld":"ESTADOACTIVO"}]}""");
         setEventMetadata("VALIDV_COMBOPAISID","""{"handler":"Validv_Combopaisid","iparms":[{"av":"A3EstadoActivo","fld":"ESTADOACTIVO"}]""");
         setEventMetadata("VALIDV_COMBOPAISID",""","oparms":[{"av":"A3EstadoActivo","fld":"ESTADOACTIVO"}]}""");
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
         wcpOGx_mode = "";
         Z2EstadoDescripcion = "";
         Combo_paisid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         lblTextblockpaisid_Jsonclick = "";
         ucCombo_paisid = new GXUserControl();
         AV14DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13PaisID_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A2EstadoDescripcion = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A17PaisDescripcion = "";
         AV19Pgmname = "";
         Combo_paisid_Objectcall = "";
         Combo_paisid_Class = "";
         Combo_paisid_Icontype = "";
         Combo_paisid_Icon = "";
         Combo_paisid_Tooltip = "";
         Combo_paisid_Selectedvalue_set = "";
         Combo_paisid_Selectedtext_set = "";
         Combo_paisid_Selectedtext_get = "";
         Combo_paisid_Gamoauthtoken = "";
         Combo_paisid_Ddointernalname = "";
         Combo_paisid_Titlecontrolalign = "";
         Combo_paisid_Dropdownoptionstype = "";
         Combo_paisid_Titlecontrolidtoreplace = "";
         Combo_paisid_Datalisttype = "";
         Combo_paisid_Datalistfixedvalues = "";
         Combo_paisid_Remoteservicesparameters = "";
         Combo_paisid_Htmltemplate = "";
         Combo_paisid_Multiplevaluestype = "";
         Combo_paisid_Loadingdata = "";
         Combo_paisid_Noresultsfound = "";
         Combo_paisid_Emptyitemtext = "";
         Combo_paisid_Onlyselectedvalues = "";
         Combo_paisid_Selectalltext = "";
         Combo_paisid_Multiplevaluesseparator = "";
         Combo_paisid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV17Combo_DataJson = "";
         AV15ComboSelectedValue = "";
         AV16ComboSelectedText = "";
         GXt_char2 = "";
         Z17PaisDescripcion = "";
         T00014_A17PaisDescripcion = new string[] {""} ;
         T00015_A1EstadoID = new int[1] ;
         T00015_A17PaisDescripcion = new string[] {""} ;
         T00015_A2EstadoDescripcion = new string[] {""} ;
         T00015_A3EstadoActivo = new bool[] {false} ;
         T00015_A16PaisID = new int[1] ;
         T00016_A17PaisDescripcion = new string[] {""} ;
         T00017_A1EstadoID = new int[1] ;
         T00013_A1EstadoID = new int[1] ;
         T00013_A2EstadoDescripcion = new string[] {""} ;
         T00013_A3EstadoActivo = new bool[] {false} ;
         T00013_A16PaisID = new int[1] ;
         T00018_A1EstadoID = new int[1] ;
         T00019_A1EstadoID = new int[1] ;
         T00012_A1EstadoID = new int[1] ;
         T00012_A2EstadoDescripcion = new string[] {""} ;
         T00012_A3EstadoActivo = new bool[] {false} ;
         T00012_A16PaisID = new int[1] ;
         T000111_A1EstadoID = new int[1] ;
         T000114_A17PaisDescripcion = new string[] {""} ;
         T000115_A4CiudadID = new int[1] ;
         T000116_A1EstadoID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estado__default(),
            new Object[][] {
                new Object[] {
               T00012_A1EstadoID, T00012_A2EstadoDescripcion, T00012_A3EstadoActivo, T00012_A16PaisID
               }
               , new Object[] {
               T00013_A1EstadoID, T00013_A2EstadoDescripcion, T00013_A3EstadoActivo, T00013_A16PaisID
               }
               , new Object[] {
               T00014_A17PaisDescripcion
               }
               , new Object[] {
               T00015_A1EstadoID, T00015_A17PaisDescripcion, T00015_A2EstadoDescripcion, T00015_A3EstadoActivo, T00015_A16PaisID
               }
               , new Object[] {
               T00016_A17PaisDescripcion
               }
               , new Object[] {
               T00017_A1EstadoID
               }
               , new Object[] {
               T00018_A1EstadoID
               }
               , new Object[] {
               T00019_A1EstadoID
               }
               , new Object[] {
               }
               , new Object[] {
               T000111_A1EstadoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000114_A17PaisDescripcion
               }
               , new Object[] {
               T000115_A4CiudadID
               }
               , new Object[] {
               T000116_A1EstadoID
               }
            }
         );
         AV19Pgmname = "Estado";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound1 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7EstadoID ;
      private int Z1EstadoID ;
      private int Z16PaisID ;
      private int N16PaisID ;
      private int A16PaisID ;
      private int AV7EstadoID ;
      private int trnEnded ;
      private int A1EstadoID ;
      private int edtEstadoID_Enabled ;
      private int edtPaisID_Visible ;
      private int edtPaisID_Enabled ;
      private int edtEstadoDescripcion_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV18ComboPaisID ;
      private int edtavCombopaisid_Enabled ;
      private int edtavCombopaisid_Visible ;
      private int AV11Insert_PaisID ;
      private int Combo_paisid_Datalistupdateminimumcharacters ;
      private int Combo_paisid_Gxcontroltype ;
      private int AV20GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_paisid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPaisID_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtEstadoID_Internalname ;
      private string TempTags ;
      private string edtEstadoID_Jsonclick ;
      private string divTablesplittedpaisid_Internalname ;
      private string lblTextblockpaisid_Internalname ;
      private string lblTextblockpaisid_Jsonclick ;
      private string Combo_paisid_Caption ;
      private string Combo_paisid_Cls ;
      private string Combo_paisid_Datalistproc ;
      private string Combo_paisid_Datalistprocparametersprefix ;
      private string Combo_paisid_Internalname ;
      private string edtPaisID_Jsonclick ;
      private string edtEstadoDescripcion_Internalname ;
      private string edtEstadoDescripcion_Jsonclick ;
      private string chkEstadoActivo_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_paisid_Internalname ;
      private string edtavCombopaisid_Internalname ;
      private string edtavCombopaisid_Jsonclick ;
      private string AV19Pgmname ;
      private string Combo_paisid_Objectcall ;
      private string Combo_paisid_Class ;
      private string Combo_paisid_Icontype ;
      private string Combo_paisid_Icon ;
      private string Combo_paisid_Tooltip ;
      private string Combo_paisid_Selectedvalue_set ;
      private string Combo_paisid_Selectedtext_set ;
      private string Combo_paisid_Selectedtext_get ;
      private string Combo_paisid_Gamoauthtoken ;
      private string Combo_paisid_Ddointernalname ;
      private string Combo_paisid_Titlecontrolalign ;
      private string Combo_paisid_Dropdownoptionstype ;
      private string Combo_paisid_Titlecontrolidtoreplace ;
      private string Combo_paisid_Datalisttype ;
      private string Combo_paisid_Datalistfixedvalues ;
      private string Combo_paisid_Remoteservicesparameters ;
      private string Combo_paisid_Htmltemplate ;
      private string Combo_paisid_Multiplevaluestype ;
      private string Combo_paisid_Loadingdata ;
      private string Combo_paisid_Noresultsfound ;
      private string Combo_paisid_Emptyitemtext ;
      private string Combo_paisid_Onlyselectedvalues ;
      private string Combo_paisid_Selectalltext ;
      private string Combo_paisid_Multiplevaluesseparator ;
      private string Combo_paisid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode1 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool Z3EstadoActivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A3EstadoActivo ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_paisid_Emptyitem ;
      private bool Combo_paisid_Enabled ;
      private bool Combo_paisid_Visible ;
      private bool Combo_paisid_Allowmultipleselection ;
      private bool Combo_paisid_Isgriditem ;
      private bool Combo_paisid_Hasdescription ;
      private bool Combo_paisid_Includeonlyselectedoption ;
      private bool Combo_paisid_Includeselectalloption ;
      private bool Combo_paisid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV17Combo_DataJson ;
      private string Z2EstadoDescripcion ;
      private string A2EstadoDescripcion ;
      private string A17PaisDescripcion ;
      private string AV15ComboSelectedValue ;
      private string AV16ComboSelectedText ;
      private string Z17PaisDescripcion ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_paisid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkEstadoActivo ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV13PaisID_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00014_A17PaisDescripcion ;
      private int[] T00015_A1EstadoID ;
      private string[] T00015_A17PaisDescripcion ;
      private string[] T00015_A2EstadoDescripcion ;
      private bool[] T00015_A3EstadoActivo ;
      private int[] T00015_A16PaisID ;
      private string[] T00016_A17PaisDescripcion ;
      private int[] T00017_A1EstadoID ;
      private int[] T00013_A1EstadoID ;
      private string[] T00013_A2EstadoDescripcion ;
      private bool[] T00013_A3EstadoActivo ;
      private int[] T00013_A16PaisID ;
      private int[] T00018_A1EstadoID ;
      private int[] T00019_A1EstadoID ;
      private int[] T00012_A1EstadoID ;
      private string[] T00012_A2EstadoDescripcion ;
      private bool[] T00012_A3EstadoActivo ;
      private int[] T00012_A16PaisID ;
      private int[] T000111_A1EstadoID ;
      private string[] T000114_A17PaisDescripcion ;
      private int[] T000115_A4CiudadID ;
      private int[] T000116_A1EstadoID ;
   }

   public class estado__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00012;
          prmT00012 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT00013;
          prmT00013 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT00014;
          prmT00014 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT00015;
          prmT00015 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT00016;
          prmT00016 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT00017;
          prmT00017 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT00018;
          prmT00018 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT00019;
          prmT00019 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000110;
          prmT000110 = new Object[] {
          new ParDef("@EstadoDescripcion",GXType.Char,80,0) ,
          new ParDef("@EstadoActivo",GXType.Byte,4,0) ,
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT000111;
          prmT000111 = new Object[] {
          };
          Object[] prmT000112;
          prmT000112 = new Object[] {
          new ParDef("@EstadoDescripcion",GXType.Char,80,0) ,
          new ParDef("@EstadoActivo",GXType.Byte,4,0) ,
          new ParDef("@PaisID",GXType.Int32,9,0) ,
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000113;
          prmT000113 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000114;
          prmT000114 = new Object[] {
          new ParDef("@PaisID",GXType.Int32,9,0)
          };
          Object[] prmT000115;
          prmT000115 = new Object[] {
          new ParDef("@EstadoID",GXType.Int32,9,0)
          };
          Object[] prmT000116;
          prmT000116 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT `EstadoID`, `EstadoDescripcion`, `EstadoActivo`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT `EstadoID`, `EstadoDescripcion`, `EstadoActivo`, `PaisID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT TM1.`EstadoID`, T2.`PaisDescripcion`, TM1.`EstadoDescripcion`, TM1.`EstadoActivo`, TM1.`PaisID` FROM (`Estado` TM1 INNER JOIN `Pais` T2 ON T2.`PaisID` = TM1.`PaisID`) WHERE TM1.`EstadoID` = @EstadoID ORDER BY TM1.`EstadoID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00017", "SELECT `EstadoID` FROM `Estado` WHERE `EstadoID` = @EstadoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00018", "SELECT `EstadoID` FROM `Estado` WHERE ( `EstadoID` > @EstadoID) ORDER BY `EstadoID`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00018,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00019", "SELECT `EstadoID` FROM `Estado` WHERE ( `EstadoID` < @EstadoID) ORDER BY `EstadoID` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT00019,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000110", "INSERT INTO `Estado`(`EstadoDescripcion`, `EstadoActivo`, `PaisID`) VALUES(@EstadoDescripcion, @EstadoActivo, @PaisID)", GxErrorMask.GX_NOMASK,prmT000110)
             ,new CursorDef("T000111", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmT000111,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000112", "UPDATE `Estado` SET `EstadoDescripcion`=@EstadoDescripcion, `EstadoActivo`=@EstadoActivo, `PaisID`=@PaisID  WHERE `EstadoID` = @EstadoID", GxErrorMask.GX_NOMASK,prmT000112)
             ,new CursorDef("T000113", "DELETE FROM `Estado`  WHERE `EstadoID` = @EstadoID", GxErrorMask.GX_NOMASK,prmT000113)
             ,new CursorDef("T000114", "SELECT `PaisDescripcion` FROM `Pais` WHERE `PaisID` = @PaisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000114,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000115", "SELECT `CiudadID` FROM `Ciudad` WHERE `EstadoID` = @EstadoID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000115,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000116", "SELECT `EstadoID` FROM `Estado` ORDER BY `EstadoID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000116,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
