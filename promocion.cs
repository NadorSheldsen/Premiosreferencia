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
   public class promocion : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "promocion.aspx")), "promocion.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "promocion.aspx")))) ;
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
                  AV7PromocionID = (int)(Math.Round(NumberUtil.Val( GetPar( "PromocionID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7PromocionID", StringUtil.LTrimStr( (decimal)(AV7PromocionID), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PromocionID), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Promocion", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPromocionDescripcion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public promocion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public promocion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_PromocionID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PromocionID = aP1_PromocionID;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromocionDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocionDescripcion_Internalname, context.GetMessage( "Nom. Promoción", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPromocionDescripcion_Internalname, A42PromocionDescripcion, StringUtil.RTrim( context.localUtil.Format( A42PromocionDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionDescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPromocionDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Descripcion", "start", true, "", "HLP_Promocion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromocionBase_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocionBase_Internalname, context.GetMessage( "Bases", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPromocionBase_Internalname, A43PromocionBase, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", 0, 1, edtPromocionBase_Enabled, 0, 80, "chr", 9, "row", 0, StyleString, ClassString, "", "", "700", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Promocion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgPromocionArte_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Arte", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A44PromocionArte_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000PromocionArte_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.PathToRelativeUrl( A44PromocionArte));
         GxWebStd.gx_bitmap( context, imgPromocionArte_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgPromocionArte_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", "", "", 0, A44PromocionArte_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Promocion.htm");
         AssignProp("", false, imgPromocionArte_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.PathToRelativeUrl( A44PromocionArte)), true);
         AssignProp("", false, imgPromocionArte_Internalname, "IsBlob", StringUtil.BoolToStr( A44PromocionArte_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromocionFechaInicio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocionFechaInicio_Internalname, context.GetMessage( "Inicio de la promoción", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPromocionFechaInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPromocionFechaInicio_Internalname, context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"), context.localUtil.Format( A45PromocionFechaInicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionFechaInicio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPromocionFechaInicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Promocion.htm");
         GxWebStd.gx_bitmap( context, edtPromocionFechaInicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPromocionFechaInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Promocion.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPromocionFechaFin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocionFechaFin_Internalname, context.GetMessage( "Fin de la promoción", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPromocionFechaFin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPromocionFechaFin_Internalname, context.localUtil.Format(A46PromocionFechaFin, "99/99/99"), context.localUtil.Format( A46PromocionFechaFin, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionFechaFin_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPromocionFechaFin_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Promocion.htm");
         GxWebStd.gx_bitmap( context, edtPromocionFechaFin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPromocionFechaFin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Promocion.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promocion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promocion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promocion.htm");
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
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPromocionID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPromocionID_Enabled!=0) ? context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocionID_Jsonclick, 0, "Attribute", "", "", "", "", edtPromocionID_Visible, edtPromocionID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "ID", "end", false, "", "HLP_Promocion.htm");
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
         E110C2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z41PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z41PromocionID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z42PromocionDescripcion = cgiGet( "Z42PromocionDescripcion");
               Z43PromocionBase = cgiGet( "Z43PromocionBase");
               Z45PromocionFechaInicio = context.localUtil.CToD( cgiGet( "Z45PromocionFechaInicio"), 0);
               Z46PromocionFechaFin = context.localUtil.CToD( cgiGet( "Z46PromocionFechaFin"), 0);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               A70PromocionVigencia = cgiGet( "PROMOCIONVIGENCIA");
               AV7PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vPROMOCIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A40000PromocionArte_GXI = cgiGet( "PROMOCIONARTE_GXI");
               A68PromocionSegmentosJson = cgiGet( "PROMOCIONSEGMENTOSJSON");
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
               A42PromocionDescripcion = cgiGet( edtPromocionDescripcion_Internalname);
               AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
               A43PromocionBase = cgiGet( edtPromocionBase_Internalname);
               AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
               A44PromocionArte = cgiGet( imgPromocionArte_Internalname);
               AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
               if ( context.localUtil.VCDate( cgiGet( edtPromocionFechaInicio_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Inicio de la promoción", "")}), 1, "PROMOCIONFECHAINICIO");
                  AnyError = 1;
                  GX_FocusControl = edtPromocionFechaInicio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A45PromocionFechaInicio = DateTime.MinValue;
                  AssignAttri("", false, "A45PromocionFechaInicio", context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"));
               }
               else
               {
                  A45PromocionFechaInicio = context.localUtil.CToD( cgiGet( edtPromocionFechaInicio_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A45PromocionFechaInicio", context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtPromocionFechaFin_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fin de la promoción", "")}), 1, "PROMOCIONFECHAFIN");
                  AnyError = 1;
                  GX_FocusControl = edtPromocionFechaFin_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A46PromocionFechaFin = DateTime.MinValue;
                  AssignAttri("", false, "A46PromocionFechaFin", context.localUtil.Format(A46PromocionFechaFin, "99/99/99"));
               }
               else
               {
                  A46PromocionFechaFin = context.localUtil.CToD( cgiGet( edtPromocionFechaFin_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A46PromocionFechaFin", context.localUtil.Format(A46PromocionFechaFin, "99/99/99"));
               }
               A41PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPromocionID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgPromocionArte_Internalname, ref  A44PromocionArte, ref  A40000PromocionArte_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Promocion");
               A41PromocionID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPromocionID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
               forbiddenHiddens.Add("PromocionID", context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A41PromocionID != Z41PromocionID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("promocion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A41PromocionID = (int)(Math.Round(NumberUtil.Val( GetPar( "PromocionID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
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
                     sMode12 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode12;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound12 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0C0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PROMOCIONID");
                        AnyError = 1;
                        GX_FocusControl = edtPromocionID_Internalname;
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
                           E110C2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120C2 ();
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
            E120C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0C12( ) ;
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
            DisableAttributes0C12( ) ;
         }
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C12( ) ;
            }
            else
            {
               CheckExtendedTable0C12( ) ;
               CloseExtendedTableCursors0C12( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0C0( )
      {
      }

      protected void E110C2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtPromocionID_Visible = 0;
         AssignProp("", false, edtPromocionID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPromocionID_Visible), 5, 0), true);
      }

      protected void E120C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("promocionww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0C12( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z42PromocionDescripcion = T000C3_A42PromocionDescripcion[0];
               Z43PromocionBase = T000C3_A43PromocionBase[0];
               Z45PromocionFechaInicio = T000C3_A45PromocionFechaInicio[0];
               Z46PromocionFechaFin = T000C3_A46PromocionFechaFin[0];
            }
            else
            {
               Z42PromocionDescripcion = A42PromocionDescripcion;
               Z43PromocionBase = A43PromocionBase;
               Z45PromocionFechaInicio = A45PromocionFechaInicio;
               Z46PromocionFechaFin = A46PromocionFechaFin;
            }
         }
         if ( GX_JID == -6 )
         {
            Z41PromocionID = A41PromocionID;
            Z42PromocionDescripcion = A42PromocionDescripcion;
            Z43PromocionBase = A43PromocionBase;
            Z44PromocionArte = A44PromocionArte;
            Z40000PromocionArte_GXI = A40000PromocionArte_GXI;
            Z45PromocionFechaInicio = A45PromocionFechaInicio;
            Z46PromocionFechaFin = A46PromocionFechaFin;
            Z68PromocionSegmentosJson = A68PromocionSegmentosJson;
         }
      }

      protected void standaloneNotModal( )
      {
         edtPromocionID_Enabled = 0;
         AssignProp("", false, edtPromocionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionID_Enabled), 5, 0), true);
         edtPromocionID_Enabled = 0;
         AssignProp("", false, edtPromocionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionID_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7PromocionID) )
         {
            A41PromocionID = AV7PromocionID;
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
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
      }

      protected void Load0C12( )
      {
         /* Using cursor T000C4 */
         pr_default.execute(2, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound12 = 1;
            A42PromocionDescripcion = T000C4_A42PromocionDescripcion[0];
            AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
            A43PromocionBase = T000C4_A43PromocionBase[0];
            AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
            A40000PromocionArte_GXI = T000C4_A40000PromocionArte_GXI[0];
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            A45PromocionFechaInicio = T000C4_A45PromocionFechaInicio[0];
            AssignAttri("", false, "A45PromocionFechaInicio", context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"));
            A46PromocionFechaFin = T000C4_A46PromocionFechaFin[0];
            AssignAttri("", false, "A46PromocionFechaFin", context.localUtil.Format(A46PromocionFechaFin, "99/99/99"));
            A68PromocionSegmentosJson = T000C4_A68PromocionSegmentosJson[0];
            A44PromocionArte = T000C4_A44PromocionArte[0];
            AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            ZM0C12( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0C12( ) ;
      }

      protected void OnLoadActions0C12( )
      {
         A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         AssignAttri("", false, "A70PromocionVigencia", A70PromocionVigencia);
      }

      protected void CheckExtendedTable0C12( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A45PromocionFechaInicio) || ( DateTimeUtil.ResetTime ( A45PromocionFechaInicio ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1000, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Inicio de la promoción", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PROMOCIONFECHAINICIO");
            AnyError = 1;
            GX_FocusControl = edtPromocionFechaInicio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         AssignAttri("", false, "A70PromocionVigencia", A70PromocionVigencia);
         if ( ! ( (DateTime.MinValue==A46PromocionFechaFin) || ( DateTimeUtil.ResetTime ( A46PromocionFechaFin ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1000, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fin de la promoción", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PROMOCIONFECHAFIN");
            AnyError = 1;
            GX_FocusControl = edtPromocionFechaFin_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0C12( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C12( )
      {
         /* Using cursor T000C5 */
         pr_default.execute(3, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000C3 */
         pr_default.execute(1, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C12( 6) ;
            RcdFound12 = 1;
            A41PromocionID = T000C3_A41PromocionID[0];
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            A42PromocionDescripcion = T000C3_A42PromocionDescripcion[0];
            AssignAttri("", false, "A42PromocionDescripcion", A42PromocionDescripcion);
            A43PromocionBase = T000C3_A43PromocionBase[0];
            AssignAttri("", false, "A43PromocionBase", A43PromocionBase);
            A40000PromocionArte_GXI = T000C3_A40000PromocionArte_GXI[0];
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            A45PromocionFechaInicio = T000C3_A45PromocionFechaInicio[0];
            AssignAttri("", false, "A45PromocionFechaInicio", context.localUtil.Format(A45PromocionFechaInicio, "99/99/99"));
            A46PromocionFechaFin = T000C3_A46PromocionFechaFin[0];
            AssignAttri("", false, "A46PromocionFechaFin", context.localUtil.Format(A46PromocionFechaFin, "99/99/99"));
            A68PromocionSegmentosJson = T000C3_A68PromocionSegmentosJson[0];
            A44PromocionArte = T000C3_A44PromocionArte[0];
            AssignAttri("", false, "A44PromocionArte", A44PromocionArte);
            AssignProp("", false, imgPromocionArte_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A44PromocionArte)) ? A40000PromocionArte_GXI : context.convertURL( context.PathToRelativeUrl( A44PromocionArte))), true);
            AssignProp("", false, imgPromocionArte_Internalname, "SrcSet", context.GetImageSrcSet( A44PromocionArte), true);
            Z41PromocionID = A41PromocionID;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0C12( ) ;
            if ( AnyError == 1 )
            {
               RcdFound12 = 0;
               InitializeNonKey0C12( ) ;
            }
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0C12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C12( ) ;
         if ( RcdFound12 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound12 = 0;
         /* Using cursor T000C6 */
         pr_default.execute(4, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000C6_A41PromocionID[0] < A41PromocionID ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000C6_A41PromocionID[0] > A41PromocionID ) ) )
            {
               A41PromocionID = T000C6_A41PromocionID[0];
               AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
               RcdFound12 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound12 = 0;
         /* Using cursor T000C7 */
         pr_default.execute(5, new Object[] {A41PromocionID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000C7_A41PromocionID[0] > A41PromocionID ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000C7_A41PromocionID[0] < A41PromocionID ) ) )
            {
               A41PromocionID = T000C7_A41PromocionID[0];
               AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
               RcdFound12 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0C12( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPromocionDescripcion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0C12( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound12 == 1 )
            {
               if ( A41PromocionID != Z41PromocionID )
               {
                  A41PromocionID = Z41PromocionID;
                  AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROMOCIONID");
                  AnyError = 1;
                  GX_FocusControl = edtPromocionID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPromocionDescripcion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0C12( ) ;
                  GX_FocusControl = edtPromocionDescripcion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A41PromocionID != Z41PromocionID )
               {
                  /* Insert record */
                  GX_FocusControl = edtPromocionDescripcion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0C12( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROMOCIONID");
                     AnyError = 1;
                     GX_FocusControl = edtPromocionID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPromocionDescripcion_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0C12( ) ;
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
         if ( A41PromocionID != Z41PromocionID )
         {
            A41PromocionID = Z41PromocionID;
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROMOCIONID");
            AnyError = 1;
            GX_FocusControl = edtPromocionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPromocionDescripcion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0C12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C2 */
            pr_default.execute(0, new Object[] {A41PromocionID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Promocion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z42PromocionDescripcion, T000C2_A42PromocionDescripcion[0]) != 0 ) || ( StringUtil.StrCmp(Z43PromocionBase, T000C2_A43PromocionBase[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z45PromocionFechaInicio ) != DateTimeUtil.ResetTime ( T000C2_A45PromocionFechaInicio[0] ) ) || ( DateTimeUtil.ResetTime ( Z46PromocionFechaFin ) != DateTimeUtil.ResetTime ( T000C2_A46PromocionFechaFin[0] ) ) )
            {
               if ( StringUtil.StrCmp(Z42PromocionDescripcion, T000C2_A42PromocionDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("promocion:[seudo value changed for attri]"+"PromocionDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z42PromocionDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A42PromocionDescripcion[0]);
               }
               if ( StringUtil.StrCmp(Z43PromocionBase, T000C2_A43PromocionBase[0]) != 0 )
               {
                  GXUtil.WriteLog("promocion:[seudo value changed for attri]"+"PromocionBase");
                  GXUtil.WriteLogRaw("Old: ",Z43PromocionBase);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A43PromocionBase[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z45PromocionFechaInicio ) != DateTimeUtil.ResetTime ( T000C2_A45PromocionFechaInicio[0] ) )
               {
                  GXUtil.WriteLog("promocion:[seudo value changed for attri]"+"PromocionFechaInicio");
                  GXUtil.WriteLogRaw("Old: ",Z45PromocionFechaInicio);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A45PromocionFechaInicio[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z46PromocionFechaFin ) != DateTimeUtil.ResetTime ( T000C2_A46PromocionFechaFin[0] ) )
               {
                  GXUtil.WriteLog("promocion:[seudo value changed for attri]"+"PromocionFechaFin");
                  GXUtil.WriteLogRaw("Old: ",Z46PromocionFechaFin);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A46PromocionFechaFin[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Promocion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C12( )
      {
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C12( 0) ;
            CheckOptimisticConcurrency0C12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C8 */
                     pr_default.execute(6, new Object[] {A42PromocionDescripcion, A43PromocionBase, A44PromocionArte, A40000PromocionArte_GXI, A45PromocionFechaInicio, A46PromocionFechaFin, A68PromocionSegmentosJson});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000C9 */
                     pr_default.execute(7);
                     A41PromocionID = T000C9_A41PromocionID[0];
                     AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Promocion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0C0( ) ;
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
               Load0C12( ) ;
            }
            EndLevel0C12( ) ;
         }
         CloseExtendedTableCursors0C12( ) ;
      }

      protected void Update0C12( )
      {
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C12( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C10 */
                     pr_default.execute(8, new Object[] {A42PromocionDescripcion, A43PromocionBase, A45PromocionFechaInicio, A46PromocionFechaFin, A68PromocionSegmentosJson, A41PromocionID});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Promocion");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Promocion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C12( ) ;
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
            EndLevel0C12( ) ;
         }
         CloseExtendedTableCursors0C12( ) ;
      }

      protected void DeferredUpdate0C12( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000C11 */
            pr_default.execute(9, new Object[] {A44PromocionArte, A40000PromocionArte_GXI, A41PromocionID});
            pr_default.close(9);
            pr_default.SmartCacheProvider.SetUpdated("Promocion");
         }
      }

      protected void delete( )
      {
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C12( ) ;
            AfterConfirm0C12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C12( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000C12 */
                  pr_default.execute(10, new Object[] {A41PromocionID});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Promocion");
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
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0C12( ) ;
         Gx_mode = sMode12;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C12( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            AssignAttri("", false, "A70PromocionVigencia", A70PromocionVigencia);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000C13 */
            pr_default.execute(11, new Object[] {A41PromocionID});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Factura", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000C14 */
            pr_default.execute(12, new Object[] {A41PromocionID});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Promocion Modelo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000C15 */
            pr_default.execute(13, new Object[] {A41PromocionID});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Promocion Distribuidor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0C12( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C12( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("promocion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("promocion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0C12( )
      {
         /* Scan By routine */
         /* Using cursor T000C16 */
         pr_default.execute(14);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound12 = 1;
            A41PromocionID = T000C16_A41PromocionID[0];
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C12( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound12 = 1;
            A41PromocionID = T000C16_A41PromocionID[0];
            AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
         }
      }

      protected void ScanEnd0C12( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0C12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C12( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C12( )
      {
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
         edtPromocionID_Enabled = 0;
         AssignProp("", false, edtPromocionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocionID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0C12( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0C0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         GXEncryptionTmp = "promocion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PromocionID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("promocion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Promocion");
         forbiddenHiddens.Add("PromocionID", context.localUtil.Format( (decimal)(A41PromocionID), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("promocion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z41PromocionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z42PromocionDescripcion", Z42PromocionDescripcion);
         GxWebStd.gx_hidden_field( context, "Z43PromocionBase", Z43PromocionBase);
         GxWebStd.gx_hidden_field( context, "Z45PromocionFechaInicio", context.localUtil.DToC( Z45PromocionFechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z46PromocionFechaFin", context.localUtil.DToC( Z46PromocionFechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "PROMOCIONVIGENCIA", A70PromocionVigencia);
         GxWebStd.gx_hidden_field( context, "vPROMOCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PromocionID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PromocionID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROMOCIONARTE_GXI", A40000PromocionArte_GXI);
         GxWebStd.gx_hidden_field( context, "PROMOCIONSEGMENTOSJSON", A68PromocionSegmentosJson);
         GXCCtlgxBlob = "PROMOCIONARTE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A44PromocionArte);
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
         GXEncryptionTmp = "promocion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PromocionID,9,0));
         return formatLink("promocion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Promocion" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Promocion", "") ;
      }

      protected void InitializeNonKey0C12( )
      {
         A70PromocionVigencia = "";
         AssignAttri("", false, "A70PromocionVigencia", A70PromocionVigencia);
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
         A68PromocionSegmentosJson = "";
         AssignAttri("", false, "A68PromocionSegmentosJson", A68PromocionSegmentosJson);
         Z42PromocionDescripcion = "";
         Z43PromocionBase = "";
         Z45PromocionFechaInicio = DateTime.MinValue;
         Z46PromocionFechaFin = DateTime.MinValue;
      }

      protected void InitAll0C12( )
      {
         A41PromocionID = 0;
         AssignAttri("", false, "A41PromocionID", StringUtil.LTrimStr( (decimal)(A41PromocionID), 9, 0));
         InitializeNonKey0C12( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025102815461974", true, true);
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
         context.AddJavascriptSource("promocion.js", "?2025102815461974", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtPromocionDescripcion_Internalname = "PROMOCIONDESCRIPCION";
         edtPromocionBase_Internalname = "PROMOCIONBASE";
         imgPromocionArte_Internalname = "PROMOCIONARTE";
         edtPromocionFechaInicio_Internalname = "PROMOCIONFECHAINICIO";
         edtPromocionFechaFin_Internalname = "PROMOCIONFECHAFIN";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtPromocionID_Internalname = "PROMOCIONID";
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
         Form.Caption = context.GetMessage( "Promocion", "");
         edtPromocionID_Jsonclick = "";
         edtPromocionID_Enabled = 0;
         edtPromocionID_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtPromocionFechaFin_Jsonclick = "";
         edtPromocionFechaFin_Enabled = 1;
         edtPromocionFechaInicio_Jsonclick = "";
         edtPromocionFechaInicio_Enabled = 1;
         imgPromocionArte_Enabled = 1;
         edtPromocionBase_Enabled = 1;
         edtPromocionDescripcion_Jsonclick = "";
         edtPromocionDescripcion_Enabled = 1;
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7PromocionID","fld":"vPROMOCIONID","pic":"ZZZZZZZZ9","hsh":true},{"av":"A41PromocionID","fld":"PROMOCIONID","pic":"ZZZZZZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120C2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_PROMOCIONFECHAINICIO","""{"handler":"Valid_Promocionfechainicio","iparms":[]}""");
         setEventMetadata("VALID_PROMOCIONFECHAFIN","""{"handler":"Valid_Promocionfechafin","iparms":[]}""");
         setEventMetadata("VALID_PROMOCIONID","""{"handler":"Valid_Promocionid","iparms":[]}""");
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
         wcpOGx_mode = "";
         Z42PromocionDescripcion = "";
         Z43PromocionBase = "";
         Z45PromocionFechaInicio = DateTime.MinValue;
         Z46PromocionFechaFin = DateTime.MinValue;
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
         A42PromocionDescripcion = "";
         A43PromocionBase = "";
         A44PromocionArte = "";
         A40000PromocionArte_GXI = "";
         sImgUrl = "";
         A45PromocionFechaInicio = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A70PromocionVigencia = "";
         A68PromocionSegmentosJson = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode12 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z44PromocionArte = "";
         Z40000PromocionArte_GXI = "";
         Z68PromocionSegmentosJson = "";
         T000C4_A41PromocionID = new int[1] ;
         T000C4_A42PromocionDescripcion = new string[] {""} ;
         T000C4_A43PromocionBase = new string[] {""} ;
         T000C4_A40000PromocionArte_GXI = new string[] {""} ;
         T000C4_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000C4_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         T000C4_A68PromocionSegmentosJson = new string[] {""} ;
         T000C4_A44PromocionArte = new string[] {""} ;
         T000C5_A41PromocionID = new int[1] ;
         T000C3_A41PromocionID = new int[1] ;
         T000C3_A42PromocionDescripcion = new string[] {""} ;
         T000C3_A43PromocionBase = new string[] {""} ;
         T000C3_A40000PromocionArte_GXI = new string[] {""} ;
         T000C3_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000C3_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         T000C3_A68PromocionSegmentosJson = new string[] {""} ;
         T000C3_A44PromocionArte = new string[] {""} ;
         T000C6_A41PromocionID = new int[1] ;
         T000C7_A41PromocionID = new int[1] ;
         T000C2_A41PromocionID = new int[1] ;
         T000C2_A42PromocionDescripcion = new string[] {""} ;
         T000C2_A43PromocionBase = new string[] {""} ;
         T000C2_A40000PromocionArte_GXI = new string[] {""} ;
         T000C2_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         T000C2_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         T000C2_A68PromocionSegmentosJson = new string[] {""} ;
         T000C2_A44PromocionArte = new string[] {""} ;
         T000C9_A41PromocionID = new int[1] ;
         T000C13_A69FacturaID = new int[1] ;
         T000C14_A48PromocionModeloID = new int[1] ;
         T000C15_A47PromocionDistribuidorID = new int[1] ;
         T000C16_A41PromocionID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXCCtlgxBlob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.promocion__default(),
            new Object[][] {
                new Object[] {
               T000C2_A41PromocionID, T000C2_A42PromocionDescripcion, T000C2_A43PromocionBase, T000C2_A40000PromocionArte_GXI, T000C2_A45PromocionFechaInicio, T000C2_A46PromocionFechaFin, T000C2_A68PromocionSegmentosJson, T000C2_A44PromocionArte
               }
               , new Object[] {
               T000C3_A41PromocionID, T000C3_A42PromocionDescripcion, T000C3_A43PromocionBase, T000C3_A40000PromocionArte_GXI, T000C3_A45PromocionFechaInicio, T000C3_A46PromocionFechaFin, T000C3_A68PromocionSegmentosJson, T000C3_A44PromocionArte
               }
               , new Object[] {
               T000C4_A41PromocionID, T000C4_A42PromocionDescripcion, T000C4_A43PromocionBase, T000C4_A40000PromocionArte_GXI, T000C4_A45PromocionFechaInicio, T000C4_A46PromocionFechaFin, T000C4_A68PromocionSegmentosJson, T000C4_A44PromocionArte
               }
               , new Object[] {
               T000C5_A41PromocionID
               }
               , new Object[] {
               T000C6_A41PromocionID
               }
               , new Object[] {
               T000C7_A41PromocionID
               }
               , new Object[] {
               }
               , new Object[] {
               T000C9_A41PromocionID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000C13_A69FacturaID
               }
               , new Object[] {
               T000C14_A48PromocionModeloID
               }
               , new Object[] {
               T000C15_A47PromocionDistribuidorID
               }
               , new Object[] {
               T000C16_A41PromocionID
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound12 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7PromocionID ;
      private int Z41PromocionID ;
      private int AV7PromocionID ;
      private int trnEnded ;
      private int edtPromocionDescripcion_Enabled ;
      private int edtPromocionBase_Enabled ;
      private int imgPromocionArte_Enabled ;
      private int edtPromocionFechaInicio_Enabled ;
      private int edtPromocionFechaFin_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A41PromocionID ;
      private int edtPromocionID_Enabled ;
      private int edtPromocionID_Visible ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPromocionDescripcion_Internalname ;
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
      private string TempTags ;
      private string edtPromocionDescripcion_Jsonclick ;
      private string edtPromocionBase_Internalname ;
      private string imgPromocionArte_Internalname ;
      private string sImgUrl ;
      private string edtPromocionFechaInicio_Internalname ;
      private string edtPromocionFechaInicio_Jsonclick ;
      private string edtPromocionFechaFin_Internalname ;
      private string edtPromocionFechaFin_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtPromocionID_Internalname ;
      private string edtPromocionID_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode12 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXCCtlgxBlob ;
      private DateTime Z45PromocionFechaInicio ;
      private DateTime Z46PromocionFechaFin ;
      private DateTime A45PromocionFechaInicio ;
      private DateTime A46PromocionFechaFin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A44PromocionArte_IsBlob ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string A68PromocionSegmentosJson ;
      private string Z68PromocionSegmentosJson ;
      private string Z42PromocionDescripcion ;
      private string Z43PromocionBase ;
      private string A42PromocionDescripcion ;
      private string A43PromocionBase ;
      private string A40000PromocionArte_GXI ;
      private string A70PromocionVigencia ;
      private string Z40000PromocionArte_GXI ;
      private string A44PromocionArte ;
      private string Z44PromocionArte ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] T000C4_A41PromocionID ;
      private string[] T000C4_A42PromocionDescripcion ;
      private string[] T000C4_A43PromocionBase ;
      private string[] T000C4_A40000PromocionArte_GXI ;
      private DateTime[] T000C4_A45PromocionFechaInicio ;
      private DateTime[] T000C4_A46PromocionFechaFin ;
      private string[] T000C4_A68PromocionSegmentosJson ;
      private string[] T000C4_A44PromocionArte ;
      private int[] T000C5_A41PromocionID ;
      private int[] T000C3_A41PromocionID ;
      private string[] T000C3_A42PromocionDescripcion ;
      private string[] T000C3_A43PromocionBase ;
      private string[] T000C3_A40000PromocionArte_GXI ;
      private DateTime[] T000C3_A45PromocionFechaInicio ;
      private DateTime[] T000C3_A46PromocionFechaFin ;
      private string[] T000C3_A68PromocionSegmentosJson ;
      private string[] T000C3_A44PromocionArte ;
      private int[] T000C6_A41PromocionID ;
      private int[] T000C7_A41PromocionID ;
      private int[] T000C2_A41PromocionID ;
      private string[] T000C2_A42PromocionDescripcion ;
      private string[] T000C2_A43PromocionBase ;
      private string[] T000C2_A40000PromocionArte_GXI ;
      private DateTime[] T000C2_A45PromocionFechaInicio ;
      private DateTime[] T000C2_A46PromocionFechaFin ;
      private string[] T000C2_A68PromocionSegmentosJson ;
      private string[] T000C2_A44PromocionArte ;
      private int[] T000C9_A41PromocionID ;
      private int[] T000C13_A69FacturaID ;
      private int[] T000C14_A48PromocionModeloID ;
      private int[] T000C15_A47PromocionDistribuidorID ;
      private int[] T000C16_A41PromocionID ;
   }

   public class promocion__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
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
          Object[] prmT000C2;
          prmT000C2 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000C3;
          prmT000C3 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000C4;
          prmT000C4 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000C5;
          prmT000C5 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000C6;
          prmT000C6 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000C7;
          prmT000C7 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000C8;
          prmT000C8 = new Object[] {
          new ParDef("@PromocionDescripcion",GXType.Char,80,0) ,
          new ParDef("@PromocionBase",GXType.Char,700,0) ,
          new ParDef("@PromocionArte",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PromocionArte_GXI",GXType.Char,2048,0){AddAtt=true, ImgIdx=2, Tbl="Promocion", Fld="PromocionArte"} ,
          new ParDef("@PromocionFechaInicio",GXType.Date,8,0) ,
          new ParDef("@PromocionFechaFin",GXType.Date,8,0) ,
          new ParDef("@PromocionSegmentosJson",GXType.Char,2097152,0)
          };
          Object[] prmT000C9;
          prmT000C9 = new Object[] {
          };
          Object[] prmT000C10;
          prmT000C10 = new Object[] {
          new ParDef("@PromocionDescripcion",GXType.Char,80,0) ,
          new ParDef("@PromocionBase",GXType.Char,700,0) ,
          new ParDef("@PromocionFechaInicio",GXType.Date,8,0) ,
          new ParDef("@PromocionFechaFin",GXType.Date,8,0) ,
          new ParDef("@PromocionSegmentosJson",GXType.Char,2097152,0) ,
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000C11;
          prmT000C11 = new Object[] {
          new ParDef("@PromocionArte",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PromocionArte_GXI",GXType.Char,2048,0){AddAtt=true, ImgIdx=0, Tbl="Promocion", Fld="PromocionArte"} ,
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000C12;
          prmT000C12 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000C13;
          prmT000C13 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000C14;
          prmT000C14 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000C15;
          prmT000C15 = new Object[] {
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmT000C16;
          prmT000C16 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000C2", "SELECT `PromocionID`, `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionSegmentosJson`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID  FOR UPDATE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C3", "SELECT `PromocionID`, `PromocionDescripcion`, `PromocionBase`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionSegmentosJson`, `PromocionArte` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C4", "SELECT TM1.`PromocionID`, TM1.`PromocionDescripcion`, TM1.`PromocionBase`, TM1.`PromocionArte_GXI`, TM1.`PromocionFechaInicio`, TM1.`PromocionFechaFin`, TM1.`PromocionSegmentosJson`, TM1.`PromocionArte` FROM `Promocion` TM1 WHERE TM1.`PromocionID` = @PromocionID ORDER BY TM1.`PromocionID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C5", "SELECT `PromocionID` FROM `Promocion` WHERE `PromocionID` = @PromocionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C6", "SELECT `PromocionID` FROM `Promocion` WHERE ( `PromocionID` > @PromocionID) ORDER BY `PromocionID`  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000C6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C7", "SELECT `PromocionID` FROM `Promocion` WHERE ( `PromocionID` < @PromocionID) ORDER BY `PromocionID` DESC  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000C7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C8", "INSERT INTO `Promocion`(`PromocionDescripcion`, `PromocionBase`, `PromocionArte`, `PromocionArte_GXI`, `PromocionFechaInicio`, `PromocionFechaFin`, `PromocionSegmentosJson`) VALUES(@PromocionDescripcion, @PromocionBase, @PromocionArte, @PromocionArte_GXI, @PromocionFechaInicio, @PromocionFechaFin, @PromocionSegmentosJson)", GxErrorMask.GX_NOMASK,prmT000C8)
             ,new CursorDef("T000C9", "SELECT LAST_INSERT_ID() ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C10", "UPDATE `Promocion` SET `PromocionDescripcion`=@PromocionDescripcion, `PromocionBase`=@PromocionBase, `PromocionFechaInicio`=@PromocionFechaInicio, `PromocionFechaFin`=@PromocionFechaFin, `PromocionSegmentosJson`=@PromocionSegmentosJson  WHERE `PromocionID` = @PromocionID", GxErrorMask.GX_NOMASK,prmT000C10)
             ,new CursorDef("T000C11", "UPDATE `Promocion` SET `PromocionArte`=@PromocionArte, `PromocionArte_GXI`=@PromocionArte_GXI  WHERE `PromocionID` = @PromocionID", GxErrorMask.GX_NOMASK,prmT000C11)
             ,new CursorDef("T000C12", "DELETE FROM `Promocion`  WHERE `PromocionID` = @PromocionID", GxErrorMask.GX_NOMASK,prmT000C12)
             ,new CursorDef("T000C13", "SELECT `FacturaID` FROM `Factura` WHERE `PromocionID` = @PromocionID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000C13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C14", "SELECT `PromocionModeloID` FROM `PromocionModelo` WHERE `PromocionID` = @PromocionID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000C14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C15", "SELECT `PromocionDistribuidorID` FROM `PromocionDistribuidor` WHERE `PromocionID` = @PromocionID  LIMIT 1",true, GxErrorMask.GX_NOMASK, false, this,prmT000C15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C16", "SELECT `PromocionID` FROM `Promocion` ORDER BY `PromocionID` ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C16,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(4));
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(4));
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(4));
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
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
