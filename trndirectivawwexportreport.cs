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
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trndirectivawwexportreport : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public trndirectivawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trndirectivawwexportreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("TrnDirectivaWWExportReport");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            AV45Title = context.GetMessage( "Lista de Directivas", "");
            GXt_char1 = AV38AppName;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Name", out  GXt_char1) ;
            AV38AppName = GXt_char1;
            GXt_char1 = AV44Phone;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Phone", out  GXt_char1) ;
            AV44Phone = GXt_char1;
            GXt_char1 = AV42Mail;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Mail", out  GXt_char1) ;
            AV42Mail = GXt_char1;
            GXt_char1 = AV46Website;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Website", out  GXt_char1) ;
            AV46Website = GXt_char1;
            GXt_char1 = AV35AddressLine1;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Address", out  GXt_char1) ;
            AV35AddressLine1 = GXt_char1;
            GXt_char1 = AV36AddressLine2;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_Neighbour", out  GXt_char1) ;
            AV36AddressLine2 = GXt_char1;
            GXt_char1 = AV37AddressLine3;
            new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context ).execute(  "AD_Application_CityAndCountry", out  GXt_char1) ;
            AV37AddressLine3 = GXt_char1;
            /* Execute user subroutine: 'PRINTFILTERS' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTCOLUMNTITLES' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTDATA' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTFOOTER' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H4G0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'PRINTFILTERS' Routine */
         returnInSub = false;
         if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV25GridStateDynamicFilter = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(1));
            AV12DynamicFiltersSelector1 = AV25GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "TRNDIRECTIVATITLE") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV49TrnDirectivaTitle1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TrnDirectivaTitle1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV50FilterTrnDirectivaTitleDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Directiva", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV50FilterTrnDirectivaTitleDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Directiva", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV51TrnDirectivaTitle = AV49TrnDirectivaTitle1;
                  H4G0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50FilterTrnDirectivaTitleDescription, "")), 25, Gx_line+0, 154, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TrnDirectivaTitle, "")), 154, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "TRNDIRECTIVAVALUE") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV14TrnDirectivaValue1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TrnDirectivaValue1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterTrnDirectivaValueDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Valor", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterTrnDirectivaValueDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Valor", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV16TrnDirectivaValue = AV14TrnDirectivaValue1;
                  H4G0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterTrnDirectivaValueDescription, "")), 25, Gx_line+0, 154, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16TrnDirectivaValue, "")), 154, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV17DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "TRNDIRECTIVATITLE") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV52TrnDirectivaTitle2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TrnDirectivaTitle2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV50FilterTrnDirectivaTitleDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Directiva", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV50FilterTrnDirectivaTitleDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Directiva", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV51TrnDirectivaTitle = AV52TrnDirectivaTitle2;
                     H4G0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50FilterTrnDirectivaTitleDescription, "")), 25, Gx_line+0, 154, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TrnDirectivaTitle, "")), 154, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "TRNDIRECTIVAVALUE") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV20TrnDirectivaValue2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TrnDirectivaValue2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterTrnDirectivaValueDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Valor", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterTrnDirectivaValueDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Valor", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV16TrnDirectivaValue = AV20TrnDirectivaValue2;
                     H4G0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterTrnDirectivaValueDescription, "")), 25, Gx_line+0, 154, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16TrnDirectivaValue, "")), 154, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "TRNDIRECTIVATITLE") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV53TrnDirectivaTitle3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53TrnDirectivaTitle3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV50FilterTrnDirectivaTitleDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Directiva", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV50FilterTrnDirectivaTitleDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Directiva", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV51TrnDirectivaTitle = AV53TrnDirectivaTitle3;
                        H4G0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50FilterTrnDirectivaTitleDescription, "")), 25, Gx_line+0, 154, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TrnDirectivaTitle, "")), 154, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "TRNDIRECTIVAVALUE") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV24TrnDirectivaValue3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TrnDirectivaValue3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterTrnDirectivaValueDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Valor", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterTrnDirectivaValueDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Valor", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV16TrnDirectivaValue = AV24TrnDirectivaValue3;
                        H4G0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterTrnDirectivaValueDescription, "")), 25, Gx_line+0, 154, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16TrnDirectivaValue, "")), 154, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFTrnDirectivaTitle_Sel)) )
         {
            AV34TempBoolean = (bool)(((StringUtil.StrCmp(AV31TFTrnDirectivaTitle_Sel, "<#Empty#>")==0)));
            AV31TFTrnDirectivaTitle_Sel = (AV34TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV31TFTrnDirectivaTitle_Sel);
            H4G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Directiva", ""), 25, Gx_line+0, 154, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TFTrnDirectivaTitle_Sel, "")), 154, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV31TFTrnDirectivaTitle_Sel = (AV34TempBoolean ? "<#Empty#>" : AV31TFTrnDirectivaTitle_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TFTrnDirectivaTitle)) )
            {
               H4G0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Directiva", ""), 25, Gx_line+0, 154, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30TFTrnDirectivaTitle, "")), 154, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTrnDirectivaValue_Sel)) )
         {
            AV34TempBoolean = (bool)(((StringUtil.StrCmp(AV33TFTrnDirectivaValue_Sel, "<#Empty#>")==0)));
            AV33TFTrnDirectivaValue_Sel = (AV34TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV33TFTrnDirectivaValue_Sel);
            H4G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 25, Gx_line+0, 154, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFTrnDirectivaValue_Sel, "")), 154, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV33TFTrnDirectivaValue_Sel = (AV34TempBoolean ? "<#Empty#>" : AV33TFTrnDirectivaValue_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFTrnDirectivaValue)) )
            {
               H4G0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 25, Gx_line+0, 154, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFTrnDirectivaValue, "")), 154, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFTrnDirectivaDescripcion_Sel)) )
         {
            AV34TempBoolean = (bool)(((StringUtil.StrCmp(AV48TFTrnDirectivaDescripcion_Sel, "<#Empty#>")==0)));
            AV48TFTrnDirectivaDescripcion_Sel = (AV34TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV48TFTrnDirectivaDescripcion_Sel);
            H4G0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Descripción", ""), 25, Gx_line+0, 154, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFTrnDirectivaDescripcion_Sel, "")), 154, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV48TFTrnDirectivaDescripcion_Sel = (AV34TempBoolean ? "<#Empty#>" : AV48TFTrnDirectivaDescripcion_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFTrnDirectivaDescripcion)) )
            {
               H4G0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Descripción", ""), 25, Gx_line+0, 154, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFTrnDirectivaDescripcion, "")), 154, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4G0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4G0( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Directiva", ""), 30, Gx_line+10, 279, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 283, Gx_line+10, 533, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Descripción", ""), 537, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV57Trndirectivawwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV58Trndirectivawwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV59Trndirectivawwds_3_trndirectivatitle1 = AV49TrnDirectivaTitle1;
         AV60Trndirectivawwds_4_trndirectivavalue1 = AV14TrnDirectivaValue1;
         AV61Trndirectivawwds_5_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV62Trndirectivawwds_6_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV63Trndirectivawwds_7_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV64Trndirectivawwds_8_trndirectivatitle2 = AV52TrnDirectivaTitle2;
         AV65Trndirectivawwds_9_trndirectivavalue2 = AV20TrnDirectivaValue2;
         AV66Trndirectivawwds_10_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV67Trndirectivawwds_11_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV68Trndirectivawwds_12_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV69Trndirectivawwds_13_trndirectivatitle3 = AV53TrnDirectivaTitle3;
         AV70Trndirectivawwds_14_trndirectivavalue3 = AV24TrnDirectivaValue3;
         AV71Trndirectivawwds_15_tftrndirectivatitle = AV30TFTrnDirectivaTitle;
         AV72Trndirectivawwds_16_tftrndirectivatitle_sel = AV31TFTrnDirectivaTitle_Sel;
         AV73Trndirectivawwds_17_tftrndirectivavalue = AV32TFTrnDirectivaValue;
         AV74Trndirectivawwds_18_tftrndirectivavalue_sel = AV33TFTrnDirectivaValue_Sel;
         AV75Trndirectivawwds_19_tftrndirectivadescripcion = AV47TFTrnDirectivaDescripcion;
         AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel = AV48TFTrnDirectivaDescripcion_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV57Trndirectivawwds_1_dynamicfiltersselector1 ,
                                              AV58Trndirectivawwds_2_dynamicfiltersoperator1 ,
                                              AV59Trndirectivawwds_3_trndirectivatitle1 ,
                                              AV60Trndirectivawwds_4_trndirectivavalue1 ,
                                              AV61Trndirectivawwds_5_dynamicfiltersenabled2 ,
                                              AV62Trndirectivawwds_6_dynamicfiltersselector2 ,
                                              AV63Trndirectivawwds_7_dynamicfiltersoperator2 ,
                                              AV64Trndirectivawwds_8_trndirectivatitle2 ,
                                              AV65Trndirectivawwds_9_trndirectivavalue2 ,
                                              AV66Trndirectivawwds_10_dynamicfiltersenabled3 ,
                                              AV67Trndirectivawwds_11_dynamicfiltersselector3 ,
                                              AV68Trndirectivawwds_12_dynamicfiltersoperator3 ,
                                              AV69Trndirectivawwds_13_trndirectivatitle3 ,
                                              AV70Trndirectivawwds_14_trndirectivavalue3 ,
                                              AV72Trndirectivawwds_16_tftrndirectivatitle_sel ,
                                              AV71Trndirectivawwds_15_tftrndirectivatitle ,
                                              AV74Trndirectivawwds_18_tftrndirectivavalue_sel ,
                                              AV73Trndirectivawwds_17_tftrndirectivavalue ,
                                              AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel ,
                                              AV75Trndirectivawwds_19_tftrndirectivadescripcion ,
                                              A89TrnDirectivaTitle ,
                                              A90TrnDirectivaValue ,
                                              A91TrnDirectivaDescripcion ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV59Trndirectivawwds_3_trndirectivatitle1 = StringUtil.Concat( StringUtil.RTrim( AV59Trndirectivawwds_3_trndirectivatitle1), "%", "");
         lV59Trndirectivawwds_3_trndirectivatitle1 = StringUtil.Concat( StringUtil.RTrim( AV59Trndirectivawwds_3_trndirectivatitle1), "%", "");
         lV60Trndirectivawwds_4_trndirectivavalue1 = StringUtil.Concat( StringUtil.RTrim( AV60Trndirectivawwds_4_trndirectivavalue1), "%", "");
         lV60Trndirectivawwds_4_trndirectivavalue1 = StringUtil.Concat( StringUtil.RTrim( AV60Trndirectivawwds_4_trndirectivavalue1), "%", "");
         lV64Trndirectivawwds_8_trndirectivatitle2 = StringUtil.Concat( StringUtil.RTrim( AV64Trndirectivawwds_8_trndirectivatitle2), "%", "");
         lV64Trndirectivawwds_8_trndirectivatitle2 = StringUtil.Concat( StringUtil.RTrim( AV64Trndirectivawwds_8_trndirectivatitle2), "%", "");
         lV65Trndirectivawwds_9_trndirectivavalue2 = StringUtil.Concat( StringUtil.RTrim( AV65Trndirectivawwds_9_trndirectivavalue2), "%", "");
         lV65Trndirectivawwds_9_trndirectivavalue2 = StringUtil.Concat( StringUtil.RTrim( AV65Trndirectivawwds_9_trndirectivavalue2), "%", "");
         lV69Trndirectivawwds_13_trndirectivatitle3 = StringUtil.Concat( StringUtil.RTrim( AV69Trndirectivawwds_13_trndirectivatitle3), "%", "");
         lV69Trndirectivawwds_13_trndirectivatitle3 = StringUtil.Concat( StringUtil.RTrim( AV69Trndirectivawwds_13_trndirectivatitle3), "%", "");
         lV70Trndirectivawwds_14_trndirectivavalue3 = StringUtil.Concat( StringUtil.RTrim( AV70Trndirectivawwds_14_trndirectivavalue3), "%", "");
         lV70Trndirectivawwds_14_trndirectivavalue3 = StringUtil.Concat( StringUtil.RTrim( AV70Trndirectivawwds_14_trndirectivavalue3), "%", "");
         lV71Trndirectivawwds_15_tftrndirectivatitle = StringUtil.Concat( StringUtil.RTrim( AV71Trndirectivawwds_15_tftrndirectivatitle), "%", "");
         lV73Trndirectivawwds_17_tftrndirectivavalue = StringUtil.Concat( StringUtil.RTrim( AV73Trndirectivawwds_17_tftrndirectivavalue), "%", "");
         lV75Trndirectivawwds_19_tftrndirectivadescripcion = StringUtil.Concat( StringUtil.RTrim( AV75Trndirectivawwds_19_tftrndirectivadescripcion), "%", "");
         /* Using cursor P004G2 */
         pr_default.execute(0, new Object[] {lV59Trndirectivawwds_3_trndirectivatitle1, lV59Trndirectivawwds_3_trndirectivatitle1, lV60Trndirectivawwds_4_trndirectivavalue1, lV60Trndirectivawwds_4_trndirectivavalue1, lV64Trndirectivawwds_8_trndirectivatitle2, lV64Trndirectivawwds_8_trndirectivatitle2, lV65Trndirectivawwds_9_trndirectivavalue2, lV65Trndirectivawwds_9_trndirectivavalue2, lV69Trndirectivawwds_13_trndirectivatitle3, lV69Trndirectivawwds_13_trndirectivatitle3, lV70Trndirectivawwds_14_trndirectivavalue3, lV70Trndirectivawwds_14_trndirectivavalue3, lV71Trndirectivawwds_15_tftrndirectivatitle, AV72Trndirectivawwds_16_tftrndirectivatitle_sel, lV73Trndirectivawwds_17_tftrndirectivavalue, AV74Trndirectivawwds_18_tftrndirectivavalue_sel, lV75Trndirectivawwds_19_tftrndirectivadescripcion, AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A91TrnDirectivaDescripcion = P004G2_A91TrnDirectivaDescripcion[0];
            A90TrnDirectivaValue = P004G2_A90TrnDirectivaValue[0];
            A89TrnDirectivaTitle = P004G2_A89TrnDirectivaTitle[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H4G0( false, 66) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A89TrnDirectivaTitle, "")), 30, Gx_line+10, 279, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A90TrnDirectivaValue, "")), 283, Gx_line+10, 533, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(A91TrnDirectivaDescripcion, 537, Gx_line+10, 787, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+65, 789, Gx_line+65, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+66);
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S161 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get("TrnDirectivaWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "TrnDirectivaWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("TrnDirectivaWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV77GXV1 = 1;
         while ( AV77GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV77GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVATITLE") == 0 )
            {
               AV30TFTrnDirectivaTitle = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVATITLE_SEL") == 0 )
            {
               AV31TFTrnDirectivaTitle_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVAVALUE") == 0 )
            {
               AV32TFTrnDirectivaValue = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVAVALUE_SEL") == 0 )
            {
               AV33TFTrnDirectivaValue_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVADESCRIPCION") == 0 )
            {
               AV47TFTrnDirectivaDescripcion = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVADESCRIPCION_SEL") == 0 )
            {
               AV48TFTrnDirectivaDescripcion_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV77GXV1 = (int)(AV77GXV1+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void H4G0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  AV43PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV40DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+128);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV45Title = "";
         AV38AppName = "";
         AV44Phone = "";
         AV42Mail = "";
         AV46Website = "";
         AV35AddressLine1 = "";
         AV36AddressLine2 = "";
         AV37AddressLine3 = "";
         GXt_char1 = "";
         AV28GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV25GridStateDynamicFilter = new WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV49TrnDirectivaTitle1 = "";
         AV50FilterTrnDirectivaTitleDescription = "";
         AV51TrnDirectivaTitle = "";
         AV14TrnDirectivaValue1 = "";
         AV15FilterTrnDirectivaValueDescription = "";
         AV16TrnDirectivaValue = "";
         AV18DynamicFiltersSelector2 = "";
         AV52TrnDirectivaTitle2 = "";
         AV20TrnDirectivaValue2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV53TrnDirectivaTitle3 = "";
         AV24TrnDirectivaValue3 = "";
         AV31TFTrnDirectivaTitle_Sel = "";
         AV30TFTrnDirectivaTitle = "";
         AV33TFTrnDirectivaValue_Sel = "";
         AV32TFTrnDirectivaValue = "";
         AV48TFTrnDirectivaDescripcion_Sel = "";
         AV47TFTrnDirectivaDescripcion = "";
         AV57Trndirectivawwds_1_dynamicfiltersselector1 = "";
         AV59Trndirectivawwds_3_trndirectivatitle1 = "";
         AV60Trndirectivawwds_4_trndirectivavalue1 = "";
         AV62Trndirectivawwds_6_dynamicfiltersselector2 = "";
         AV64Trndirectivawwds_8_trndirectivatitle2 = "";
         AV65Trndirectivawwds_9_trndirectivavalue2 = "";
         AV67Trndirectivawwds_11_dynamicfiltersselector3 = "";
         AV69Trndirectivawwds_13_trndirectivatitle3 = "";
         AV70Trndirectivawwds_14_trndirectivavalue3 = "";
         AV71Trndirectivawwds_15_tftrndirectivatitle = "";
         AV72Trndirectivawwds_16_tftrndirectivatitle_sel = "";
         AV73Trndirectivawwds_17_tftrndirectivavalue = "";
         AV74Trndirectivawwds_18_tftrndirectivavalue_sel = "";
         AV75Trndirectivawwds_19_tftrndirectivadescripcion = "";
         AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel = "";
         lV59Trndirectivawwds_3_trndirectivatitle1 = "";
         lV60Trndirectivawwds_4_trndirectivavalue1 = "";
         lV64Trndirectivawwds_8_trndirectivatitle2 = "";
         lV65Trndirectivawwds_9_trndirectivavalue2 = "";
         lV69Trndirectivawwds_13_trndirectivatitle3 = "";
         lV70Trndirectivawwds_14_trndirectivavalue3 = "";
         lV71Trndirectivawwds_15_tftrndirectivatitle = "";
         lV73Trndirectivawwds_17_tftrndirectivavalue = "";
         lV75Trndirectivawwds_19_tftrndirectivadescripcion = "";
         A89TrnDirectivaTitle = "";
         A90TrnDirectivaValue = "";
         A91TrnDirectivaDescripcion = "";
         P004G2_A91TrnDirectivaDescripcion = new string[] {""} ;
         P004G2_A90TrnDirectivaValue = new string[] {""} ;
         P004G2_A89TrnDirectivaTitle = new string[] {""} ;
         AV26Session = context.GetSession();
         AV29GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV43PageInfo = "";
         AV40DateInfo = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trndirectivawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004G2_A91TrnDirectivaDescripcion, P004G2_A90TrnDirectivaValue, P004G2_A89TrnDirectivaTitle
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13DynamicFiltersOperator1 ;
      private short AV19DynamicFiltersOperator2 ;
      private short AV23DynamicFiltersOperator3 ;
      private short AV58Trndirectivawwds_2_dynamicfiltersoperator1 ;
      private short AV63Trndirectivawwds_7_dynamicfiltersoperator2 ;
      private short AV68Trndirectivawwds_12_dynamicfiltersoperator3 ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV77GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string GXt_char1 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV34TempBoolean ;
      private bool AV61Trndirectivawwds_5_dynamicfiltersenabled2 ;
      private bool AV66Trndirectivawwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV75Trndirectivawwds_19_tftrndirectivadescripcion ;
      private string AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel ;
      private string lV75Trndirectivawwds_19_tftrndirectivadescripcion ;
      private string A91TrnDirectivaDescripcion ;
      private string AV45Title ;
      private string AV38AppName ;
      private string AV44Phone ;
      private string AV42Mail ;
      private string AV46Website ;
      private string AV35AddressLine1 ;
      private string AV36AddressLine2 ;
      private string AV37AddressLine3 ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV49TrnDirectivaTitle1 ;
      private string AV50FilterTrnDirectivaTitleDescription ;
      private string AV51TrnDirectivaTitle ;
      private string AV14TrnDirectivaValue1 ;
      private string AV15FilterTrnDirectivaValueDescription ;
      private string AV16TrnDirectivaValue ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV52TrnDirectivaTitle2 ;
      private string AV20TrnDirectivaValue2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV53TrnDirectivaTitle3 ;
      private string AV24TrnDirectivaValue3 ;
      private string AV31TFTrnDirectivaTitle_Sel ;
      private string AV30TFTrnDirectivaTitle ;
      private string AV33TFTrnDirectivaValue_Sel ;
      private string AV32TFTrnDirectivaValue ;
      private string AV48TFTrnDirectivaDescripcion_Sel ;
      private string AV47TFTrnDirectivaDescripcion ;
      private string AV57Trndirectivawwds_1_dynamicfiltersselector1 ;
      private string AV59Trndirectivawwds_3_trndirectivatitle1 ;
      private string AV60Trndirectivawwds_4_trndirectivavalue1 ;
      private string AV62Trndirectivawwds_6_dynamicfiltersselector2 ;
      private string AV64Trndirectivawwds_8_trndirectivatitle2 ;
      private string AV65Trndirectivawwds_9_trndirectivavalue2 ;
      private string AV67Trndirectivawwds_11_dynamicfiltersselector3 ;
      private string AV69Trndirectivawwds_13_trndirectivatitle3 ;
      private string AV70Trndirectivawwds_14_trndirectivavalue3 ;
      private string AV71Trndirectivawwds_15_tftrndirectivatitle ;
      private string AV72Trndirectivawwds_16_tftrndirectivatitle_sel ;
      private string AV73Trndirectivawwds_17_tftrndirectivavalue ;
      private string AV74Trndirectivawwds_18_tftrndirectivavalue_sel ;
      private string lV59Trndirectivawwds_3_trndirectivatitle1 ;
      private string lV60Trndirectivawwds_4_trndirectivavalue1 ;
      private string lV64Trndirectivawwds_8_trndirectivatitle2 ;
      private string lV65Trndirectivawwds_9_trndirectivavalue2 ;
      private string lV69Trndirectivawwds_13_trndirectivatitle3 ;
      private string lV70Trndirectivawwds_14_trndirectivavalue3 ;
      private string lV71Trndirectivawwds_15_tftrndirectivatitle ;
      private string lV73Trndirectivawwds_17_tftrndirectivavalue ;
      private string A89TrnDirectivaTitle ;
      private string A90TrnDirectivaValue ;
      private string AV43PageInfo ;
      private string AV40DateInfo ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV28GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P004G2_A91TrnDirectivaDescripcion ;
      private string[] P004G2_A90TrnDirectivaValue ;
      private string[] P004G2_A89TrnDirectivaTitle ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
   }

   public class trndirectivawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004G2( IGxContext context ,
                                             string AV57Trndirectivawwds_1_dynamicfiltersselector1 ,
                                             short AV58Trndirectivawwds_2_dynamicfiltersoperator1 ,
                                             string AV59Trndirectivawwds_3_trndirectivatitle1 ,
                                             string AV60Trndirectivawwds_4_trndirectivavalue1 ,
                                             bool AV61Trndirectivawwds_5_dynamicfiltersenabled2 ,
                                             string AV62Trndirectivawwds_6_dynamicfiltersselector2 ,
                                             short AV63Trndirectivawwds_7_dynamicfiltersoperator2 ,
                                             string AV64Trndirectivawwds_8_trndirectivatitle2 ,
                                             string AV65Trndirectivawwds_9_trndirectivavalue2 ,
                                             bool AV66Trndirectivawwds_10_dynamicfiltersenabled3 ,
                                             string AV67Trndirectivawwds_11_dynamicfiltersselector3 ,
                                             short AV68Trndirectivawwds_12_dynamicfiltersoperator3 ,
                                             string AV69Trndirectivawwds_13_trndirectivatitle3 ,
                                             string AV70Trndirectivawwds_14_trndirectivavalue3 ,
                                             string AV72Trndirectivawwds_16_tftrndirectivatitle_sel ,
                                             string AV71Trndirectivawwds_15_tftrndirectivatitle ,
                                             string AV74Trndirectivawwds_18_tftrndirectivavalue_sel ,
                                             string AV73Trndirectivawwds_17_tftrndirectivavalue ,
                                             string AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel ,
                                             string AV75Trndirectivawwds_19_tftrndirectivadescripcion ,
                                             string A89TrnDirectivaTitle ,
                                             string A90TrnDirectivaValue ,
                                             string A91TrnDirectivaDescripcion ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[18];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT `TrnDirectivaDescripcion`, `TrnDirectivaValue`, `TrnDirectivaTitle` FROM `TrnDirectiva`";
         if ( ( StringUtil.StrCmp(AV57Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV58Trndirectivawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trndirectivawwds_3_trndirectivatitle1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV59Trndirectivawwds_3_trndirectivatitle1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV58Trndirectivawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trndirectivawwds_3_trndirectivatitle1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like CONCAT('%', @lV59Trndirectivawwds_3_trndirectivatitle1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV58Trndirectivawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trndirectivawwds_4_trndirectivavalue1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV60Trndirectivawwds_4_trndirectivavalue1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV58Trndirectivawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trndirectivawwds_4_trndirectivavalue1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like CONCAT('%', @lV60Trndirectivawwds_4_trndirectivavalue1))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV61Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV63Trndirectivawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trndirectivawwds_8_trndirectivatitle2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV64Trndirectivawwds_8_trndirectivatitle2)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV61Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV63Trndirectivawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trndirectivawwds_8_trndirectivatitle2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like CONCAT('%', @lV64Trndirectivawwds_8_trndirectivatitle2))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV61Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV63Trndirectivawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trndirectivawwds_9_trndirectivavalue2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV65Trndirectivawwds_9_trndirectivavalue2)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV61Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV63Trndirectivawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trndirectivawwds_9_trndirectivavalue2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like CONCAT('%', @lV65Trndirectivawwds_9_trndirectivavalue2))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV66Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV68Trndirectivawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trndirectivawwds_13_trndirectivatitle3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV69Trndirectivawwds_13_trndirectivatitle3)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV66Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV68Trndirectivawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trndirectivawwds_13_trndirectivatitle3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like CONCAT('%', @lV69Trndirectivawwds_13_trndirectivatitle3))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV66Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV68Trndirectivawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trndirectivawwds_14_trndirectivavalue3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV70Trndirectivawwds_14_trndirectivavalue3)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV66Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV68Trndirectivawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trndirectivawwds_14_trndirectivavalue3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like CONCAT('%', @lV70Trndirectivawwds_14_trndirectivavalue3))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trndirectivawwds_16_tftrndirectivatitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trndirectivawwds_15_tftrndirectivatitle)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV71Trndirectivawwds_15_tftrndirectivatitle)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trndirectivawwds_16_tftrndirectivatitle_sel)) && ! ( StringUtil.StrCmp(AV72Trndirectivawwds_16_tftrndirectivatitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` = @AV72Trndirectivawwds_16_tftrndirectivatitle_sel)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trndirectivawwds_16_tftrndirectivatitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`TrnDirectivaTitle`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trndirectivawwds_18_tftrndirectivavalue_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trndirectivawwds_17_tftrndirectivavalue)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV73Trndirectivawwds_17_tftrndirectivavalue)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trndirectivawwds_18_tftrndirectivavalue_sel)) && ! ( StringUtil.StrCmp(AV74Trndirectivawwds_18_tftrndirectivavalue_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` = @AV74Trndirectivawwds_18_tftrndirectivavalue_sel)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trndirectivawwds_18_tftrndirectivavalue_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`TrnDirectivaValue`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trndirectivawwds_19_tftrndirectivadescripcion)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaDescripcion` like @lV75Trndirectivawwds_19_tftrndirectivadescripcion)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel)) && ! ( StringUtil.StrCmp(AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaDescripcion` = @AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`TrnDirectivaDescripcion`))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY `TrnDirectivaTitle`";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY `TrnDirectivaTitle` DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY `TrnDirectivaValue`";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY `TrnDirectivaValue` DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY `TrnDirectivaDescripcion`";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY `TrnDirectivaDescripcion` DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004G2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004G2;
          prmP004G2 = new Object[] {
          new ParDef("@lV59Trndirectivawwds_3_trndirectivatitle1",GXType.Char,100,0) ,
          new ParDef("@lV59Trndirectivawwds_3_trndirectivatitle1",GXType.Char,100,0) ,
          new ParDef("@lV60Trndirectivawwds_4_trndirectivavalue1",GXType.Char,100,0) ,
          new ParDef("@lV60Trndirectivawwds_4_trndirectivavalue1",GXType.Char,100,0) ,
          new ParDef("@lV64Trndirectivawwds_8_trndirectivatitle2",GXType.Char,100,0) ,
          new ParDef("@lV64Trndirectivawwds_8_trndirectivatitle2",GXType.Char,100,0) ,
          new ParDef("@lV65Trndirectivawwds_9_trndirectivavalue2",GXType.Char,100,0) ,
          new ParDef("@lV65Trndirectivawwds_9_trndirectivavalue2",GXType.Char,100,0) ,
          new ParDef("@lV69Trndirectivawwds_13_trndirectivatitle3",GXType.Char,100,0) ,
          new ParDef("@lV69Trndirectivawwds_13_trndirectivatitle3",GXType.Char,100,0) ,
          new ParDef("@lV70Trndirectivawwds_14_trndirectivavalue3",GXType.Char,100,0) ,
          new ParDef("@lV70Trndirectivawwds_14_trndirectivavalue3",GXType.Char,100,0) ,
          new ParDef("@lV71Trndirectivawwds_15_tftrndirectivatitle",GXType.Char,100,0) ,
          new ParDef("@AV72Trndirectivawwds_16_tftrndirectivatitle_sel",GXType.Char,100,0) ,
          new ParDef("@lV73Trndirectivawwds_17_tftrndirectivavalue",GXType.Char,100,0) ,
          new ParDef("@AV74Trndirectivawwds_18_tftrndirectivavalue_sel",GXType.Char,100,0) ,
          new ParDef("@lV75Trndirectivawwds_19_tftrndirectivadescripcion",GXType.Char,2097152,0) ,
          new ParDef("@AV76Trndirectivawwds_20_tftrndirectivadescripcion_sel",GXType.Char,2097152,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004G2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
