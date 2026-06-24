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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trndirectivawwgetfilterdata : GXProcedure
   {
      public trndirectivawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trndirectivawwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV35OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV20Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV17MaxItems = 10;
         AV16PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV31SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? "" : StringUtil.Substring( AV31SearchTxtParms, 3, -1));
         AV15SkipItems = (short)(AV16PageIndex*AV17MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_TRNDIRECTIVATITLE") == 0 )
         {
            /* Execute user subroutine: 'LOADTRNDIRECTIVATITLEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_TRNDIRECTIVAVALUE") == 0 )
         {
            /* Execute user subroutine: 'LOADTRNDIRECTIVAVALUEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_TRNDIRECTIVADESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADTRNDIRECTIVADESCRIPCIONOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV33OptionsJson = AV20Options.ToJSonString(false);
         AV34OptionsDescJson = AV22OptionsDesc.ToJSonString(false);
         AV35OptionIndexesJson = AV23OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV25Session.Get("TrnDirectivaWWGridState"), "") == 0 )
         {
            AV27GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "TrnDirectivaWWGridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV25Session.Get("TrnDirectivaWWGridState"), null, "", "");
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVATITLE") == 0 )
            {
               AV10TFTrnDirectivaTitle = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVATITLE_SEL") == 0 )
            {
               AV11TFTrnDirectivaTitle_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVAVALUE") == 0 )
            {
               AV12TFTrnDirectivaValue = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVAVALUE_SEL") == 0 )
            {
               AV13TFTrnDirectivaValue_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVADESCRIPCION") == 0 )
            {
               AV47TFTrnDirectivaDescripcion = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFTRNDIRECTIVADESCRIPCION_SEL") == 0 )
            {
               AV48TFTrnDirectivaDescripcion_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
         if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV29GridStateDynamicFilter = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV29GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "TRNDIRECTIVATITLE") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV49TrnDirectivaTitle1 = AV29GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "TRNDIRECTIVAVALUE") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV38TrnDirectivaValue1 = AV29GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "TRNDIRECTIVATITLE") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV50TrnDirectivaTitle2 = AV29GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "TRNDIRECTIVAVALUE") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV42TrnDirectivaValue2 = AV29GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV27GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter)AV27GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "TRNDIRECTIVATITLE") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV51TrnDirectivaTitle3 = AV29GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "TRNDIRECTIVAVALUE") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV46TrnDirectivaValue3 = AV29GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTRNDIRECTIVATITLEOPTIONS' Routine */
         returnInSub = false;
         AV10TFTrnDirectivaTitle = AV14SearchTxt;
         AV11TFTrnDirectivaTitle_Sel = "";
         AV54Trndirectivawwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV55Trndirectivawwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV56Trndirectivawwds_3_trndirectivatitle1 = AV49TrnDirectivaTitle1;
         AV57Trndirectivawwds_4_trndirectivavalue1 = AV38TrnDirectivaValue1;
         AV58Trndirectivawwds_5_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV59Trndirectivawwds_6_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV60Trndirectivawwds_7_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV61Trndirectivawwds_8_trndirectivatitle2 = AV50TrnDirectivaTitle2;
         AV62Trndirectivawwds_9_trndirectivavalue2 = AV42TrnDirectivaValue2;
         AV63Trndirectivawwds_10_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV64Trndirectivawwds_11_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV65Trndirectivawwds_12_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV66Trndirectivawwds_13_trndirectivatitle3 = AV51TrnDirectivaTitle3;
         AV67Trndirectivawwds_14_trndirectivavalue3 = AV46TrnDirectivaValue3;
         AV68Trndirectivawwds_15_tftrndirectivatitle = AV10TFTrnDirectivaTitle;
         AV69Trndirectivawwds_16_tftrndirectivatitle_sel = AV11TFTrnDirectivaTitle_Sel;
         AV70Trndirectivawwds_17_tftrndirectivavalue = AV12TFTrnDirectivaValue;
         AV71Trndirectivawwds_18_tftrndirectivavalue_sel = AV13TFTrnDirectivaValue_Sel;
         AV72Trndirectivawwds_19_tftrndirectivadescripcion = AV47TFTrnDirectivaDescripcion;
         AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel = AV48TFTrnDirectivaDescripcion_Sel;
         GXPagingFrom2 = AV15SkipItems;
         GXPagingTo2 = ((AV17MaxItems>0) ? AV17MaxItems : 100000000);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Trndirectivawwds_1_dynamicfiltersselector1 ,
                                              AV55Trndirectivawwds_2_dynamicfiltersoperator1 ,
                                              AV56Trndirectivawwds_3_trndirectivatitle1 ,
                                              AV57Trndirectivawwds_4_trndirectivavalue1 ,
                                              AV58Trndirectivawwds_5_dynamicfiltersenabled2 ,
                                              AV59Trndirectivawwds_6_dynamicfiltersselector2 ,
                                              AV60Trndirectivawwds_7_dynamicfiltersoperator2 ,
                                              AV61Trndirectivawwds_8_trndirectivatitle2 ,
                                              AV62Trndirectivawwds_9_trndirectivavalue2 ,
                                              AV63Trndirectivawwds_10_dynamicfiltersenabled3 ,
                                              AV64Trndirectivawwds_11_dynamicfiltersselector3 ,
                                              AV65Trndirectivawwds_12_dynamicfiltersoperator3 ,
                                              AV66Trndirectivawwds_13_trndirectivatitle3 ,
                                              AV67Trndirectivawwds_14_trndirectivavalue3 ,
                                              AV69Trndirectivawwds_16_tftrndirectivatitle_sel ,
                                              AV68Trndirectivawwds_15_tftrndirectivatitle ,
                                              AV71Trndirectivawwds_18_tftrndirectivavalue_sel ,
                                              AV70Trndirectivawwds_17_tftrndirectivavalue ,
                                              AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel ,
                                              AV72Trndirectivawwds_19_tftrndirectivadescripcion ,
                                              A89TrnDirectivaTitle ,
                                              A90TrnDirectivaValue ,
                                              A91TrnDirectivaDescripcion } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV56Trndirectivawwds_3_trndirectivatitle1 = StringUtil.Concat( StringUtil.RTrim( AV56Trndirectivawwds_3_trndirectivatitle1), "%", "");
         lV56Trndirectivawwds_3_trndirectivatitle1 = StringUtil.Concat( StringUtil.RTrim( AV56Trndirectivawwds_3_trndirectivatitle1), "%", "");
         lV57Trndirectivawwds_4_trndirectivavalue1 = StringUtil.Concat( StringUtil.RTrim( AV57Trndirectivawwds_4_trndirectivavalue1), "%", "");
         lV57Trndirectivawwds_4_trndirectivavalue1 = StringUtil.Concat( StringUtil.RTrim( AV57Trndirectivawwds_4_trndirectivavalue1), "%", "");
         lV61Trndirectivawwds_8_trndirectivatitle2 = StringUtil.Concat( StringUtil.RTrim( AV61Trndirectivawwds_8_trndirectivatitle2), "%", "");
         lV61Trndirectivawwds_8_trndirectivatitle2 = StringUtil.Concat( StringUtil.RTrim( AV61Trndirectivawwds_8_trndirectivatitle2), "%", "");
         lV62Trndirectivawwds_9_trndirectivavalue2 = StringUtil.Concat( StringUtil.RTrim( AV62Trndirectivawwds_9_trndirectivavalue2), "%", "");
         lV62Trndirectivawwds_9_trndirectivavalue2 = StringUtil.Concat( StringUtil.RTrim( AV62Trndirectivawwds_9_trndirectivavalue2), "%", "");
         lV66Trndirectivawwds_13_trndirectivatitle3 = StringUtil.Concat( StringUtil.RTrim( AV66Trndirectivawwds_13_trndirectivatitle3), "%", "");
         lV66Trndirectivawwds_13_trndirectivatitle3 = StringUtil.Concat( StringUtil.RTrim( AV66Trndirectivawwds_13_trndirectivatitle3), "%", "");
         lV67Trndirectivawwds_14_trndirectivavalue3 = StringUtil.Concat( StringUtil.RTrim( AV67Trndirectivawwds_14_trndirectivavalue3), "%", "");
         lV67Trndirectivawwds_14_trndirectivavalue3 = StringUtil.Concat( StringUtil.RTrim( AV67Trndirectivawwds_14_trndirectivavalue3), "%", "");
         lV68Trndirectivawwds_15_tftrndirectivatitle = StringUtil.Concat( StringUtil.RTrim( AV68Trndirectivawwds_15_tftrndirectivatitle), "%", "");
         lV70Trndirectivawwds_17_tftrndirectivavalue = StringUtil.Concat( StringUtil.RTrim( AV70Trndirectivawwds_17_tftrndirectivavalue), "%", "");
         lV72Trndirectivawwds_19_tftrndirectivadescripcion = StringUtil.Concat( StringUtil.RTrim( AV72Trndirectivawwds_19_tftrndirectivadescripcion), "%", "");
         /* Using cursor P004E2 */
         pr_default.execute(0, new Object[] {lV56Trndirectivawwds_3_trndirectivatitle1, lV56Trndirectivawwds_3_trndirectivatitle1, lV57Trndirectivawwds_4_trndirectivavalue1, lV57Trndirectivawwds_4_trndirectivavalue1, lV61Trndirectivawwds_8_trndirectivatitle2, lV61Trndirectivawwds_8_trndirectivatitle2, lV62Trndirectivawwds_9_trndirectivavalue2, lV62Trndirectivawwds_9_trndirectivavalue2, lV66Trndirectivawwds_13_trndirectivatitle3, lV66Trndirectivawwds_13_trndirectivatitle3, lV67Trndirectivawwds_14_trndirectivavalue3, lV67Trndirectivawwds_14_trndirectivavalue3, lV68Trndirectivawwds_15_tftrndirectivatitle, AV69Trndirectivawwds_16_tftrndirectivatitle_sel, lV70Trndirectivawwds_17_tftrndirectivavalue, AV71Trndirectivawwds_18_tftrndirectivavalue_sel, lV72Trndirectivawwds_19_tftrndirectivadescripcion, AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel, GXPagingFrom2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A91TrnDirectivaDescripcion = P004E2_A91TrnDirectivaDescripcion[0];
            A90TrnDirectivaValue = P004E2_A90TrnDirectivaValue[0];
            A89TrnDirectivaTitle = P004E2_A89TrnDirectivaTitle[0];
            AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A89TrnDirectivaTitle)) ? "<#Empty#>" : A89TrnDirectivaTitle);
            AV20Options.Add(AV19Option, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTRNDIRECTIVAVALUEOPTIONS' Routine */
         returnInSub = false;
         AV12TFTrnDirectivaValue = AV14SearchTxt;
         AV13TFTrnDirectivaValue_Sel = "";
         AV54Trndirectivawwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV55Trndirectivawwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV56Trndirectivawwds_3_trndirectivatitle1 = AV49TrnDirectivaTitle1;
         AV57Trndirectivawwds_4_trndirectivavalue1 = AV38TrnDirectivaValue1;
         AV58Trndirectivawwds_5_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV59Trndirectivawwds_6_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV60Trndirectivawwds_7_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV61Trndirectivawwds_8_trndirectivatitle2 = AV50TrnDirectivaTitle2;
         AV62Trndirectivawwds_9_trndirectivavalue2 = AV42TrnDirectivaValue2;
         AV63Trndirectivawwds_10_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV64Trndirectivawwds_11_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV65Trndirectivawwds_12_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV66Trndirectivawwds_13_trndirectivatitle3 = AV51TrnDirectivaTitle3;
         AV67Trndirectivawwds_14_trndirectivavalue3 = AV46TrnDirectivaValue3;
         AV68Trndirectivawwds_15_tftrndirectivatitle = AV10TFTrnDirectivaTitle;
         AV69Trndirectivawwds_16_tftrndirectivatitle_sel = AV11TFTrnDirectivaTitle_Sel;
         AV70Trndirectivawwds_17_tftrndirectivavalue = AV12TFTrnDirectivaValue;
         AV71Trndirectivawwds_18_tftrndirectivavalue_sel = AV13TFTrnDirectivaValue_Sel;
         AV72Trndirectivawwds_19_tftrndirectivadescripcion = AV47TFTrnDirectivaDescripcion;
         AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel = AV48TFTrnDirectivaDescripcion_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV54Trndirectivawwds_1_dynamicfiltersselector1 ,
                                              AV55Trndirectivawwds_2_dynamicfiltersoperator1 ,
                                              AV56Trndirectivawwds_3_trndirectivatitle1 ,
                                              AV57Trndirectivawwds_4_trndirectivavalue1 ,
                                              AV58Trndirectivawwds_5_dynamicfiltersenabled2 ,
                                              AV59Trndirectivawwds_6_dynamicfiltersselector2 ,
                                              AV60Trndirectivawwds_7_dynamicfiltersoperator2 ,
                                              AV61Trndirectivawwds_8_trndirectivatitle2 ,
                                              AV62Trndirectivawwds_9_trndirectivavalue2 ,
                                              AV63Trndirectivawwds_10_dynamicfiltersenabled3 ,
                                              AV64Trndirectivawwds_11_dynamicfiltersselector3 ,
                                              AV65Trndirectivawwds_12_dynamicfiltersoperator3 ,
                                              AV66Trndirectivawwds_13_trndirectivatitle3 ,
                                              AV67Trndirectivawwds_14_trndirectivavalue3 ,
                                              AV69Trndirectivawwds_16_tftrndirectivatitle_sel ,
                                              AV68Trndirectivawwds_15_tftrndirectivatitle ,
                                              AV71Trndirectivawwds_18_tftrndirectivavalue_sel ,
                                              AV70Trndirectivawwds_17_tftrndirectivavalue ,
                                              AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel ,
                                              AV72Trndirectivawwds_19_tftrndirectivadescripcion ,
                                              A89TrnDirectivaTitle ,
                                              A90TrnDirectivaValue ,
                                              A91TrnDirectivaDescripcion } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV56Trndirectivawwds_3_trndirectivatitle1 = StringUtil.Concat( StringUtil.RTrim( AV56Trndirectivawwds_3_trndirectivatitle1), "%", "");
         lV56Trndirectivawwds_3_trndirectivatitle1 = StringUtil.Concat( StringUtil.RTrim( AV56Trndirectivawwds_3_trndirectivatitle1), "%", "");
         lV57Trndirectivawwds_4_trndirectivavalue1 = StringUtil.Concat( StringUtil.RTrim( AV57Trndirectivawwds_4_trndirectivavalue1), "%", "");
         lV57Trndirectivawwds_4_trndirectivavalue1 = StringUtil.Concat( StringUtil.RTrim( AV57Trndirectivawwds_4_trndirectivavalue1), "%", "");
         lV61Trndirectivawwds_8_trndirectivatitle2 = StringUtil.Concat( StringUtil.RTrim( AV61Trndirectivawwds_8_trndirectivatitle2), "%", "");
         lV61Trndirectivawwds_8_trndirectivatitle2 = StringUtil.Concat( StringUtil.RTrim( AV61Trndirectivawwds_8_trndirectivatitle2), "%", "");
         lV62Trndirectivawwds_9_trndirectivavalue2 = StringUtil.Concat( StringUtil.RTrim( AV62Trndirectivawwds_9_trndirectivavalue2), "%", "");
         lV62Trndirectivawwds_9_trndirectivavalue2 = StringUtil.Concat( StringUtil.RTrim( AV62Trndirectivawwds_9_trndirectivavalue2), "%", "");
         lV66Trndirectivawwds_13_trndirectivatitle3 = StringUtil.Concat( StringUtil.RTrim( AV66Trndirectivawwds_13_trndirectivatitle3), "%", "");
         lV66Trndirectivawwds_13_trndirectivatitle3 = StringUtil.Concat( StringUtil.RTrim( AV66Trndirectivawwds_13_trndirectivatitle3), "%", "");
         lV67Trndirectivawwds_14_trndirectivavalue3 = StringUtil.Concat( StringUtil.RTrim( AV67Trndirectivawwds_14_trndirectivavalue3), "%", "");
         lV67Trndirectivawwds_14_trndirectivavalue3 = StringUtil.Concat( StringUtil.RTrim( AV67Trndirectivawwds_14_trndirectivavalue3), "%", "");
         lV68Trndirectivawwds_15_tftrndirectivatitle = StringUtil.Concat( StringUtil.RTrim( AV68Trndirectivawwds_15_tftrndirectivatitle), "%", "");
         lV70Trndirectivawwds_17_tftrndirectivavalue = StringUtil.Concat( StringUtil.RTrim( AV70Trndirectivawwds_17_tftrndirectivavalue), "%", "");
         lV72Trndirectivawwds_19_tftrndirectivadescripcion = StringUtil.Concat( StringUtil.RTrim( AV72Trndirectivawwds_19_tftrndirectivadescripcion), "%", "");
         /* Using cursor P004E3 */
         pr_default.execute(1, new Object[] {lV56Trndirectivawwds_3_trndirectivatitle1, lV56Trndirectivawwds_3_trndirectivatitle1, lV57Trndirectivawwds_4_trndirectivavalue1, lV57Trndirectivawwds_4_trndirectivavalue1, lV61Trndirectivawwds_8_trndirectivatitle2, lV61Trndirectivawwds_8_trndirectivatitle2, lV62Trndirectivawwds_9_trndirectivavalue2, lV62Trndirectivawwds_9_trndirectivavalue2, lV66Trndirectivawwds_13_trndirectivatitle3, lV66Trndirectivawwds_13_trndirectivatitle3, lV67Trndirectivawwds_14_trndirectivavalue3, lV67Trndirectivawwds_14_trndirectivavalue3, lV68Trndirectivawwds_15_tftrndirectivatitle, AV69Trndirectivawwds_16_tftrndirectivatitle_sel, lV70Trndirectivawwds_17_tftrndirectivavalue, AV71Trndirectivawwds_18_tftrndirectivavalue_sel, lV72Trndirectivawwds_19_tftrndirectivadescripcion, AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4E3 = false;
            A90TrnDirectivaValue = P004E3_A90TrnDirectivaValue[0];
            A91TrnDirectivaDescripcion = P004E3_A91TrnDirectivaDescripcion[0];
            A89TrnDirectivaTitle = P004E3_A89TrnDirectivaTitle[0];
            AV24count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P004E3_A90TrnDirectivaValue[0], A90TrnDirectivaValue) == 0 ) )
            {
               BRK4E3 = false;
               A89TrnDirectivaTitle = P004E3_A89TrnDirectivaTitle[0];
               AV24count = (long)(AV24count+1);
               BRK4E3 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A90TrnDirectivaValue)) ? "<#Empty#>" : A90TrnDirectivaValue);
               AV20Options.Add(AV19Option, 0);
               AV23OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV24count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV20Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV15SkipItems = (short)(AV15SkipItems-1);
            }
            if ( ! BRK4E3 )
            {
               BRK4E3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADTRNDIRECTIVADESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV47TFTrnDirectivaDescripcion = AV14SearchTxt;
         AV48TFTrnDirectivaDescripcion_Sel = "";
         AV54Trndirectivawwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV55Trndirectivawwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV56Trndirectivawwds_3_trndirectivatitle1 = AV49TrnDirectivaTitle1;
         AV57Trndirectivawwds_4_trndirectivavalue1 = AV38TrnDirectivaValue1;
         AV58Trndirectivawwds_5_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV59Trndirectivawwds_6_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV60Trndirectivawwds_7_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV61Trndirectivawwds_8_trndirectivatitle2 = AV50TrnDirectivaTitle2;
         AV62Trndirectivawwds_9_trndirectivavalue2 = AV42TrnDirectivaValue2;
         AV63Trndirectivawwds_10_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV64Trndirectivawwds_11_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV65Trndirectivawwds_12_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV66Trndirectivawwds_13_trndirectivatitle3 = AV51TrnDirectivaTitle3;
         AV67Trndirectivawwds_14_trndirectivavalue3 = AV46TrnDirectivaValue3;
         AV68Trndirectivawwds_15_tftrndirectivatitle = AV10TFTrnDirectivaTitle;
         AV69Trndirectivawwds_16_tftrndirectivatitle_sel = AV11TFTrnDirectivaTitle_Sel;
         AV70Trndirectivawwds_17_tftrndirectivavalue = AV12TFTrnDirectivaValue;
         AV71Trndirectivawwds_18_tftrndirectivavalue_sel = AV13TFTrnDirectivaValue_Sel;
         AV72Trndirectivawwds_19_tftrndirectivadescripcion = AV47TFTrnDirectivaDescripcion;
         AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel = AV48TFTrnDirectivaDescripcion_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV54Trndirectivawwds_1_dynamicfiltersselector1 ,
                                              AV55Trndirectivawwds_2_dynamicfiltersoperator1 ,
                                              AV56Trndirectivawwds_3_trndirectivatitle1 ,
                                              AV57Trndirectivawwds_4_trndirectivavalue1 ,
                                              AV58Trndirectivawwds_5_dynamicfiltersenabled2 ,
                                              AV59Trndirectivawwds_6_dynamicfiltersselector2 ,
                                              AV60Trndirectivawwds_7_dynamicfiltersoperator2 ,
                                              AV61Trndirectivawwds_8_trndirectivatitle2 ,
                                              AV62Trndirectivawwds_9_trndirectivavalue2 ,
                                              AV63Trndirectivawwds_10_dynamicfiltersenabled3 ,
                                              AV64Trndirectivawwds_11_dynamicfiltersselector3 ,
                                              AV65Trndirectivawwds_12_dynamicfiltersoperator3 ,
                                              AV66Trndirectivawwds_13_trndirectivatitle3 ,
                                              AV67Trndirectivawwds_14_trndirectivavalue3 ,
                                              AV69Trndirectivawwds_16_tftrndirectivatitle_sel ,
                                              AV68Trndirectivawwds_15_tftrndirectivatitle ,
                                              AV71Trndirectivawwds_18_tftrndirectivavalue_sel ,
                                              AV70Trndirectivawwds_17_tftrndirectivavalue ,
                                              AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel ,
                                              AV72Trndirectivawwds_19_tftrndirectivadescripcion ,
                                              A89TrnDirectivaTitle ,
                                              A90TrnDirectivaValue ,
                                              A91TrnDirectivaDescripcion } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV56Trndirectivawwds_3_trndirectivatitle1 = StringUtil.Concat( StringUtil.RTrim( AV56Trndirectivawwds_3_trndirectivatitle1), "%", "");
         lV56Trndirectivawwds_3_trndirectivatitle1 = StringUtil.Concat( StringUtil.RTrim( AV56Trndirectivawwds_3_trndirectivatitle1), "%", "");
         lV57Trndirectivawwds_4_trndirectivavalue1 = StringUtil.Concat( StringUtil.RTrim( AV57Trndirectivawwds_4_trndirectivavalue1), "%", "");
         lV57Trndirectivawwds_4_trndirectivavalue1 = StringUtil.Concat( StringUtil.RTrim( AV57Trndirectivawwds_4_trndirectivavalue1), "%", "");
         lV61Trndirectivawwds_8_trndirectivatitle2 = StringUtil.Concat( StringUtil.RTrim( AV61Trndirectivawwds_8_trndirectivatitle2), "%", "");
         lV61Trndirectivawwds_8_trndirectivatitle2 = StringUtil.Concat( StringUtil.RTrim( AV61Trndirectivawwds_8_trndirectivatitle2), "%", "");
         lV62Trndirectivawwds_9_trndirectivavalue2 = StringUtil.Concat( StringUtil.RTrim( AV62Trndirectivawwds_9_trndirectivavalue2), "%", "");
         lV62Trndirectivawwds_9_trndirectivavalue2 = StringUtil.Concat( StringUtil.RTrim( AV62Trndirectivawwds_9_trndirectivavalue2), "%", "");
         lV66Trndirectivawwds_13_trndirectivatitle3 = StringUtil.Concat( StringUtil.RTrim( AV66Trndirectivawwds_13_trndirectivatitle3), "%", "");
         lV66Trndirectivawwds_13_trndirectivatitle3 = StringUtil.Concat( StringUtil.RTrim( AV66Trndirectivawwds_13_trndirectivatitle3), "%", "");
         lV67Trndirectivawwds_14_trndirectivavalue3 = StringUtil.Concat( StringUtil.RTrim( AV67Trndirectivawwds_14_trndirectivavalue3), "%", "");
         lV67Trndirectivawwds_14_trndirectivavalue3 = StringUtil.Concat( StringUtil.RTrim( AV67Trndirectivawwds_14_trndirectivavalue3), "%", "");
         lV68Trndirectivawwds_15_tftrndirectivatitle = StringUtil.Concat( StringUtil.RTrim( AV68Trndirectivawwds_15_tftrndirectivatitle), "%", "");
         lV70Trndirectivawwds_17_tftrndirectivavalue = StringUtil.Concat( StringUtil.RTrim( AV70Trndirectivawwds_17_tftrndirectivavalue), "%", "");
         lV72Trndirectivawwds_19_tftrndirectivadescripcion = StringUtil.Concat( StringUtil.RTrim( AV72Trndirectivawwds_19_tftrndirectivadescripcion), "%", "");
         /* Using cursor P004E4 */
         pr_default.execute(2, new Object[] {lV56Trndirectivawwds_3_trndirectivatitle1, lV56Trndirectivawwds_3_trndirectivatitle1, lV57Trndirectivawwds_4_trndirectivavalue1, lV57Trndirectivawwds_4_trndirectivavalue1, lV61Trndirectivawwds_8_trndirectivatitle2, lV61Trndirectivawwds_8_trndirectivatitle2, lV62Trndirectivawwds_9_trndirectivavalue2, lV62Trndirectivawwds_9_trndirectivavalue2, lV66Trndirectivawwds_13_trndirectivatitle3, lV66Trndirectivawwds_13_trndirectivatitle3, lV67Trndirectivawwds_14_trndirectivavalue3, lV67Trndirectivawwds_14_trndirectivavalue3, lV68Trndirectivawwds_15_tftrndirectivatitle, AV69Trndirectivawwds_16_tftrndirectivatitle_sel, lV70Trndirectivawwds_17_tftrndirectivavalue, AV71Trndirectivawwds_18_tftrndirectivavalue_sel, lV72Trndirectivawwds_19_tftrndirectivadescripcion, AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK4E5 = false;
            A91TrnDirectivaDescripcion = P004E4_A91TrnDirectivaDescripcion[0];
            A90TrnDirectivaValue = P004E4_A90TrnDirectivaValue[0];
            A89TrnDirectivaTitle = P004E4_A89TrnDirectivaTitle[0];
            AV24count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P004E4_A91TrnDirectivaDescripcion[0], A91TrnDirectivaDescripcion) == 0 ) )
            {
               BRK4E5 = false;
               A89TrnDirectivaTitle = P004E4_A89TrnDirectivaTitle[0];
               AV24count = (long)(AV24count+1);
               BRK4E5 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A91TrnDirectivaDescripcion)) ? "<#Empty#>" : A91TrnDirectivaDescripcion);
               AV20Options.Add(AV19Option, 0);
               AV23OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV24count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV20Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV15SkipItems = (short)(AV15SkipItems-1);
            }
            if ( ! BRK4E5 )
            {
               BRK4E5 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV33OptionsJson = "";
         AV34OptionsDescJson = "";
         AV35OptionIndexesJson = "";
         AV20Options = new GxSimpleCollection<string>();
         AV22OptionsDesc = new GxSimpleCollection<string>();
         AV23OptionIndexes = new GxSimpleCollection<string>();
         AV14SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV25Session = context.GetSession();
         AV27GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV28GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV10TFTrnDirectivaTitle = "";
         AV11TFTrnDirectivaTitle_Sel = "";
         AV12TFTrnDirectivaValue = "";
         AV13TFTrnDirectivaValue_Sel = "";
         AV47TFTrnDirectivaDescripcion = "";
         AV48TFTrnDirectivaDescripcion_Sel = "";
         AV29GridStateDynamicFilter = new WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV49TrnDirectivaTitle1 = "";
         AV38TrnDirectivaValue1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV50TrnDirectivaTitle2 = "";
         AV42TrnDirectivaValue2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV51TrnDirectivaTitle3 = "";
         AV46TrnDirectivaValue3 = "";
         AV54Trndirectivawwds_1_dynamicfiltersselector1 = "";
         AV56Trndirectivawwds_3_trndirectivatitle1 = "";
         AV57Trndirectivawwds_4_trndirectivavalue1 = "";
         AV59Trndirectivawwds_6_dynamicfiltersselector2 = "";
         AV61Trndirectivawwds_8_trndirectivatitle2 = "";
         AV62Trndirectivawwds_9_trndirectivavalue2 = "";
         AV64Trndirectivawwds_11_dynamicfiltersselector3 = "";
         AV66Trndirectivawwds_13_trndirectivatitle3 = "";
         AV67Trndirectivawwds_14_trndirectivavalue3 = "";
         AV68Trndirectivawwds_15_tftrndirectivatitle = "";
         AV69Trndirectivawwds_16_tftrndirectivatitle_sel = "";
         AV70Trndirectivawwds_17_tftrndirectivavalue = "";
         AV71Trndirectivawwds_18_tftrndirectivavalue_sel = "";
         AV72Trndirectivawwds_19_tftrndirectivadescripcion = "";
         AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel = "";
         lV56Trndirectivawwds_3_trndirectivatitle1 = "";
         lV57Trndirectivawwds_4_trndirectivavalue1 = "";
         lV61Trndirectivawwds_8_trndirectivatitle2 = "";
         lV62Trndirectivawwds_9_trndirectivavalue2 = "";
         lV66Trndirectivawwds_13_trndirectivatitle3 = "";
         lV67Trndirectivawwds_14_trndirectivavalue3 = "";
         lV68Trndirectivawwds_15_tftrndirectivatitle = "";
         lV70Trndirectivawwds_17_tftrndirectivavalue = "";
         lV72Trndirectivawwds_19_tftrndirectivadescripcion = "";
         A89TrnDirectivaTitle = "";
         A90TrnDirectivaValue = "";
         A91TrnDirectivaDescripcion = "";
         P004E2_A91TrnDirectivaDescripcion = new string[] {""} ;
         P004E2_A90TrnDirectivaValue = new string[] {""} ;
         P004E2_A89TrnDirectivaTitle = new string[] {""} ;
         AV19Option = "";
         P004E3_A90TrnDirectivaValue = new string[] {""} ;
         P004E3_A91TrnDirectivaDescripcion = new string[] {""} ;
         P004E3_A89TrnDirectivaTitle = new string[] {""} ;
         P004E4_A91TrnDirectivaDescripcion = new string[] {""} ;
         P004E4_A90TrnDirectivaValue = new string[] {""} ;
         P004E4_A89TrnDirectivaTitle = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trndirectivawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004E2_A91TrnDirectivaDescripcion, P004E2_A90TrnDirectivaValue, P004E2_A89TrnDirectivaTitle
               }
               , new Object[] {
               P004E3_A90TrnDirectivaValue, P004E3_A91TrnDirectivaDescripcion, P004E3_A89TrnDirectivaTitle
               }
               , new Object[] {
               P004E4_A91TrnDirectivaDescripcion, P004E4_A90TrnDirectivaValue, P004E4_A89TrnDirectivaTitle
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17MaxItems ;
      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV55Trndirectivawwds_2_dynamicfiltersoperator1 ;
      private short AV60Trndirectivawwds_7_dynamicfiltersoperator2 ;
      private short AV65Trndirectivawwds_12_dynamicfiltersoperator3 ;
      private int AV52GXV1 ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private long AV24count ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV58Trndirectivawwds_5_dynamicfiltersenabled2 ;
      private bool AV63Trndirectivawwds_10_dynamicfiltersenabled3 ;
      private bool BRK4E3 ;
      private bool BRK4E5 ;
      private string AV33OptionsJson ;
      private string AV34OptionsDescJson ;
      private string AV35OptionIndexesJson ;
      private string AV72Trndirectivawwds_19_tftrndirectivadescripcion ;
      private string AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel ;
      private string lV72Trndirectivawwds_19_tftrndirectivadescripcion ;
      private string A91TrnDirectivaDescripcion ;
      private string AV30DDOName ;
      private string AV31SearchTxtParms ;
      private string AV32SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV10TFTrnDirectivaTitle ;
      private string AV11TFTrnDirectivaTitle_Sel ;
      private string AV12TFTrnDirectivaValue ;
      private string AV13TFTrnDirectivaValue_Sel ;
      private string AV47TFTrnDirectivaDescripcion ;
      private string AV48TFTrnDirectivaDescripcion_Sel ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV49TrnDirectivaTitle1 ;
      private string AV38TrnDirectivaValue1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV50TrnDirectivaTitle2 ;
      private string AV42TrnDirectivaValue2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV51TrnDirectivaTitle3 ;
      private string AV46TrnDirectivaValue3 ;
      private string AV54Trndirectivawwds_1_dynamicfiltersselector1 ;
      private string AV56Trndirectivawwds_3_trndirectivatitle1 ;
      private string AV57Trndirectivawwds_4_trndirectivavalue1 ;
      private string AV59Trndirectivawwds_6_dynamicfiltersselector2 ;
      private string AV61Trndirectivawwds_8_trndirectivatitle2 ;
      private string AV62Trndirectivawwds_9_trndirectivavalue2 ;
      private string AV64Trndirectivawwds_11_dynamicfiltersselector3 ;
      private string AV66Trndirectivawwds_13_trndirectivatitle3 ;
      private string AV67Trndirectivawwds_14_trndirectivavalue3 ;
      private string AV68Trndirectivawwds_15_tftrndirectivatitle ;
      private string AV69Trndirectivawwds_16_tftrndirectivatitle_sel ;
      private string AV70Trndirectivawwds_17_tftrndirectivavalue ;
      private string AV71Trndirectivawwds_18_tftrndirectivavalue_sel ;
      private string lV56Trndirectivawwds_3_trndirectivatitle1 ;
      private string lV57Trndirectivawwds_4_trndirectivavalue1 ;
      private string lV61Trndirectivawwds_8_trndirectivatitle2 ;
      private string lV62Trndirectivawwds_9_trndirectivavalue2 ;
      private string lV66Trndirectivawwds_13_trndirectivatitle3 ;
      private string lV67Trndirectivawwds_14_trndirectivavalue3 ;
      private string lV68Trndirectivawwds_15_tftrndirectivatitle ;
      private string lV70Trndirectivawwds_17_tftrndirectivavalue ;
      private string A89TrnDirectivaTitle ;
      private string A90TrnDirectivaValue ;
      private string AV19Option ;
      private IGxSession AV25Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV20Options ;
      private GxSimpleCollection<string> AV22OptionsDesc ;
      private GxSimpleCollection<string> AV23OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV27GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV28GridStateFilterValue ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P004E2_A91TrnDirectivaDescripcion ;
      private string[] P004E2_A90TrnDirectivaValue ;
      private string[] P004E2_A89TrnDirectivaTitle ;
      private string[] P004E3_A90TrnDirectivaValue ;
      private string[] P004E3_A91TrnDirectivaDescripcion ;
      private string[] P004E3_A89TrnDirectivaTitle ;
      private string[] P004E4_A91TrnDirectivaDescripcion ;
      private string[] P004E4_A90TrnDirectivaValue ;
      private string[] P004E4_A89TrnDirectivaTitle ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trndirectivawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004E2( IGxContext context ,
                                             string AV54Trndirectivawwds_1_dynamicfiltersselector1 ,
                                             short AV55Trndirectivawwds_2_dynamicfiltersoperator1 ,
                                             string AV56Trndirectivawwds_3_trndirectivatitle1 ,
                                             string AV57Trndirectivawwds_4_trndirectivavalue1 ,
                                             bool AV58Trndirectivawwds_5_dynamicfiltersenabled2 ,
                                             string AV59Trndirectivawwds_6_dynamicfiltersselector2 ,
                                             short AV60Trndirectivawwds_7_dynamicfiltersoperator2 ,
                                             string AV61Trndirectivawwds_8_trndirectivatitle2 ,
                                             string AV62Trndirectivawwds_9_trndirectivavalue2 ,
                                             bool AV63Trndirectivawwds_10_dynamicfiltersenabled3 ,
                                             string AV64Trndirectivawwds_11_dynamicfiltersselector3 ,
                                             short AV65Trndirectivawwds_12_dynamicfiltersoperator3 ,
                                             string AV66Trndirectivawwds_13_trndirectivatitle3 ,
                                             string AV67Trndirectivawwds_14_trndirectivavalue3 ,
                                             string AV69Trndirectivawwds_16_tftrndirectivatitle_sel ,
                                             string AV68Trndirectivawwds_15_tftrndirectivatitle ,
                                             string AV71Trndirectivawwds_18_tftrndirectivavalue_sel ,
                                             string AV70Trndirectivawwds_17_tftrndirectivavalue ,
                                             string AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel ,
                                             string AV72Trndirectivawwds_19_tftrndirectivadescripcion ,
                                             string A89TrnDirectivaTitle ,
                                             string A90TrnDirectivaValue ,
                                             string A91TrnDirectivaDescripcion )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " DISTINCT NULL AS `TrnDirectivaDescripcion`, NULL AS `TrnDirectivaValue`, `TrnDirectivaTitle` FROM ( SELECT `TrnDirectivaDescripcion`, `TrnDirectivaValue`, `TrnDirectivaTitle`";
         sFromString = " FROM `TrnDirectiva`";
         sOrderString = "";
         string sOrderStringT;
         sOrderStringT = " ORDER BY `TrnDirectivaTitle`";
         if ( ( StringUtil.StrCmp(AV54Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV55Trndirectivawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trndirectivawwds_3_trndirectivatitle1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV56Trndirectivawwds_3_trndirectivatitle1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV55Trndirectivawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trndirectivawwds_3_trndirectivatitle1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like CONCAT('%', @lV56Trndirectivawwds_3_trndirectivatitle1))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV55Trndirectivawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trndirectivawwds_4_trndirectivavalue1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV57Trndirectivawwds_4_trndirectivavalue1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV55Trndirectivawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trndirectivawwds_4_trndirectivavalue1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like CONCAT('%', @lV57Trndirectivawwds_4_trndirectivavalue1))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV58Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV60Trndirectivawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trndirectivawwds_8_trndirectivatitle2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV61Trndirectivawwds_8_trndirectivatitle2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV58Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV60Trndirectivawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trndirectivawwds_8_trndirectivatitle2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like CONCAT('%', @lV61Trndirectivawwds_8_trndirectivatitle2))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV58Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV60Trndirectivawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trndirectivawwds_9_trndirectivavalue2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV62Trndirectivawwds_9_trndirectivavalue2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV58Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV60Trndirectivawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trndirectivawwds_9_trndirectivavalue2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like CONCAT('%', @lV62Trndirectivawwds_9_trndirectivavalue2))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV63Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV65Trndirectivawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trndirectivawwds_13_trndirectivatitle3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV66Trndirectivawwds_13_trndirectivatitle3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV63Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV65Trndirectivawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trndirectivawwds_13_trndirectivatitle3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like CONCAT('%', @lV66Trndirectivawwds_13_trndirectivatitle3))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV63Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV65Trndirectivawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trndirectivawwds_14_trndirectivavalue3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV67Trndirectivawwds_14_trndirectivavalue3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV63Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV65Trndirectivawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trndirectivawwds_14_trndirectivavalue3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like CONCAT('%', @lV67Trndirectivawwds_14_trndirectivavalue3))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trndirectivawwds_16_tftrndirectivatitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trndirectivawwds_15_tftrndirectivatitle)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV68Trndirectivawwds_15_tftrndirectivatitle)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trndirectivawwds_16_tftrndirectivatitle_sel)) && ! ( StringUtil.StrCmp(AV69Trndirectivawwds_16_tftrndirectivatitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` = @AV69Trndirectivawwds_16_tftrndirectivatitle_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trndirectivawwds_16_tftrndirectivatitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`TrnDirectivaTitle`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Trndirectivawwds_18_tftrndirectivavalue_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trndirectivawwds_17_tftrndirectivavalue)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV70Trndirectivawwds_17_tftrndirectivavalue)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trndirectivawwds_18_tftrndirectivavalue_sel)) && ! ( StringUtil.StrCmp(AV71Trndirectivawwds_18_tftrndirectivavalue_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` = @AV71Trndirectivawwds_18_tftrndirectivavalue_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV71Trndirectivawwds_18_tftrndirectivavalue_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`TrnDirectivaValue`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trndirectivawwds_19_tftrndirectivadescripcion)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaDescripcion` like @lV72Trndirectivawwds_19_tftrndirectivadescripcion)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel)) && ! ( StringUtil.StrCmp(AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaDescripcion` = @AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( StringUtil.StrCmp(AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`TrnDirectivaDescripcion`))=0))");
         }
         sOrderString += " ORDER BY `TrnDirectivaTitle`";
         sOrderStringT = " ORDER BY `TrnDirectivaTitle`";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + ") DistinctT" + sOrderStringT + " LIMIT " + "@GXPagingFrom2" + ", " + "@GXPagingTo2";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P004E3( IGxContext context ,
                                             string AV54Trndirectivawwds_1_dynamicfiltersselector1 ,
                                             short AV55Trndirectivawwds_2_dynamicfiltersoperator1 ,
                                             string AV56Trndirectivawwds_3_trndirectivatitle1 ,
                                             string AV57Trndirectivawwds_4_trndirectivavalue1 ,
                                             bool AV58Trndirectivawwds_5_dynamicfiltersenabled2 ,
                                             string AV59Trndirectivawwds_6_dynamicfiltersselector2 ,
                                             short AV60Trndirectivawwds_7_dynamicfiltersoperator2 ,
                                             string AV61Trndirectivawwds_8_trndirectivatitle2 ,
                                             string AV62Trndirectivawwds_9_trndirectivavalue2 ,
                                             bool AV63Trndirectivawwds_10_dynamicfiltersenabled3 ,
                                             string AV64Trndirectivawwds_11_dynamicfiltersselector3 ,
                                             short AV65Trndirectivawwds_12_dynamicfiltersoperator3 ,
                                             string AV66Trndirectivawwds_13_trndirectivatitle3 ,
                                             string AV67Trndirectivawwds_14_trndirectivavalue3 ,
                                             string AV69Trndirectivawwds_16_tftrndirectivatitle_sel ,
                                             string AV68Trndirectivawwds_15_tftrndirectivatitle ,
                                             string AV71Trndirectivawwds_18_tftrndirectivavalue_sel ,
                                             string AV70Trndirectivawwds_17_tftrndirectivavalue ,
                                             string AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel ,
                                             string AV72Trndirectivawwds_19_tftrndirectivadescripcion ,
                                             string A89TrnDirectivaTitle ,
                                             string A90TrnDirectivaValue ,
                                             string A91TrnDirectivaDescripcion )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[18];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT `TrnDirectivaValue`, `TrnDirectivaDescripcion`, `TrnDirectivaTitle` FROM `TrnDirectiva`";
         if ( ( StringUtil.StrCmp(AV54Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV55Trndirectivawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trndirectivawwds_3_trndirectivatitle1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV56Trndirectivawwds_3_trndirectivatitle1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV55Trndirectivawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trndirectivawwds_3_trndirectivatitle1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like CONCAT('%', @lV56Trndirectivawwds_3_trndirectivatitle1))");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV55Trndirectivawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trndirectivawwds_4_trndirectivavalue1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV57Trndirectivawwds_4_trndirectivavalue1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV55Trndirectivawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trndirectivawwds_4_trndirectivavalue1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like CONCAT('%', @lV57Trndirectivawwds_4_trndirectivavalue1))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV58Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV60Trndirectivawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trndirectivawwds_8_trndirectivatitle2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV61Trndirectivawwds_8_trndirectivatitle2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV58Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV60Trndirectivawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trndirectivawwds_8_trndirectivatitle2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like CONCAT('%', @lV61Trndirectivawwds_8_trndirectivatitle2))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV58Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV60Trndirectivawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trndirectivawwds_9_trndirectivavalue2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV62Trndirectivawwds_9_trndirectivavalue2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV58Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV60Trndirectivawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trndirectivawwds_9_trndirectivavalue2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like CONCAT('%', @lV62Trndirectivawwds_9_trndirectivavalue2))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV63Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV65Trndirectivawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trndirectivawwds_13_trndirectivatitle3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV66Trndirectivawwds_13_trndirectivatitle3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV63Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV65Trndirectivawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trndirectivawwds_13_trndirectivatitle3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like CONCAT('%', @lV66Trndirectivawwds_13_trndirectivatitle3))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV63Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV65Trndirectivawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trndirectivawwds_14_trndirectivavalue3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV67Trndirectivawwds_14_trndirectivavalue3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV63Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV65Trndirectivawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trndirectivawwds_14_trndirectivavalue3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like CONCAT('%', @lV67Trndirectivawwds_14_trndirectivavalue3))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trndirectivawwds_16_tftrndirectivatitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trndirectivawwds_15_tftrndirectivatitle)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV68Trndirectivawwds_15_tftrndirectivatitle)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trndirectivawwds_16_tftrndirectivatitle_sel)) && ! ( StringUtil.StrCmp(AV69Trndirectivawwds_16_tftrndirectivatitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` = @AV69Trndirectivawwds_16_tftrndirectivatitle_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trndirectivawwds_16_tftrndirectivatitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`TrnDirectivaTitle`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Trndirectivawwds_18_tftrndirectivavalue_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trndirectivawwds_17_tftrndirectivavalue)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV70Trndirectivawwds_17_tftrndirectivavalue)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trndirectivawwds_18_tftrndirectivavalue_sel)) && ! ( StringUtil.StrCmp(AV71Trndirectivawwds_18_tftrndirectivavalue_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` = @AV71Trndirectivawwds_18_tftrndirectivavalue_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV71Trndirectivawwds_18_tftrndirectivavalue_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`TrnDirectivaValue`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trndirectivawwds_19_tftrndirectivadescripcion)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaDescripcion` like @lV72Trndirectivawwds_19_tftrndirectivadescripcion)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel)) && ! ( StringUtil.StrCmp(AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaDescripcion` = @AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`TrnDirectivaDescripcion`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `TrnDirectivaValue`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P004E4( IGxContext context ,
                                             string AV54Trndirectivawwds_1_dynamicfiltersselector1 ,
                                             short AV55Trndirectivawwds_2_dynamicfiltersoperator1 ,
                                             string AV56Trndirectivawwds_3_trndirectivatitle1 ,
                                             string AV57Trndirectivawwds_4_trndirectivavalue1 ,
                                             bool AV58Trndirectivawwds_5_dynamicfiltersenabled2 ,
                                             string AV59Trndirectivawwds_6_dynamicfiltersselector2 ,
                                             short AV60Trndirectivawwds_7_dynamicfiltersoperator2 ,
                                             string AV61Trndirectivawwds_8_trndirectivatitle2 ,
                                             string AV62Trndirectivawwds_9_trndirectivavalue2 ,
                                             bool AV63Trndirectivawwds_10_dynamicfiltersenabled3 ,
                                             string AV64Trndirectivawwds_11_dynamicfiltersselector3 ,
                                             short AV65Trndirectivawwds_12_dynamicfiltersoperator3 ,
                                             string AV66Trndirectivawwds_13_trndirectivatitle3 ,
                                             string AV67Trndirectivawwds_14_trndirectivavalue3 ,
                                             string AV69Trndirectivawwds_16_tftrndirectivatitle_sel ,
                                             string AV68Trndirectivawwds_15_tftrndirectivatitle ,
                                             string AV71Trndirectivawwds_18_tftrndirectivavalue_sel ,
                                             string AV70Trndirectivawwds_17_tftrndirectivavalue ,
                                             string AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel ,
                                             string AV72Trndirectivawwds_19_tftrndirectivadescripcion ,
                                             string A89TrnDirectivaTitle ,
                                             string A90TrnDirectivaValue ,
                                             string A91TrnDirectivaDescripcion )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[18];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT `TrnDirectivaDescripcion`, `TrnDirectivaValue`, `TrnDirectivaTitle` FROM `TrnDirectiva`";
         if ( ( StringUtil.StrCmp(AV54Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV55Trndirectivawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trndirectivawwds_3_trndirectivatitle1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV56Trndirectivawwds_3_trndirectivatitle1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV55Trndirectivawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trndirectivawwds_3_trndirectivatitle1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like CONCAT('%', @lV56Trndirectivawwds_3_trndirectivatitle1))");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV55Trndirectivawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trndirectivawwds_4_trndirectivavalue1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV57Trndirectivawwds_4_trndirectivavalue1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Trndirectivawwds_1_dynamicfiltersselector1, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV55Trndirectivawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trndirectivawwds_4_trndirectivavalue1)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like CONCAT('%', @lV57Trndirectivawwds_4_trndirectivavalue1))");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV58Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV60Trndirectivawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trndirectivawwds_8_trndirectivatitle2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV61Trndirectivawwds_8_trndirectivatitle2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV58Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV60Trndirectivawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trndirectivawwds_8_trndirectivatitle2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like CONCAT('%', @lV61Trndirectivawwds_8_trndirectivatitle2))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV58Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV60Trndirectivawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trndirectivawwds_9_trndirectivavalue2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV62Trndirectivawwds_9_trndirectivavalue2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV58Trndirectivawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Trndirectivawwds_6_dynamicfiltersselector2, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV60Trndirectivawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trndirectivawwds_9_trndirectivavalue2)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like CONCAT('%', @lV62Trndirectivawwds_9_trndirectivavalue2))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV63Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV65Trndirectivawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trndirectivawwds_13_trndirectivatitle3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV66Trndirectivawwds_13_trndirectivatitle3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV63Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVATITLE", "")) == 0 ) && ( AV65Trndirectivawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trndirectivawwds_13_trndirectivatitle3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like CONCAT('%', @lV66Trndirectivawwds_13_trndirectivatitle3))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV63Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV65Trndirectivawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trndirectivawwds_14_trndirectivavalue3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV67Trndirectivawwds_14_trndirectivavalue3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV63Trndirectivawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Trndirectivawwds_11_dynamicfiltersselector3, context.GetMessage( "TRNDIRECTIVAVALUE", "")) == 0 ) && ( AV65Trndirectivawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trndirectivawwds_14_trndirectivavalue3)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like CONCAT('%', @lV67Trndirectivawwds_14_trndirectivavalue3))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trndirectivawwds_16_tftrndirectivatitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trndirectivawwds_15_tftrndirectivatitle)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` like @lV68Trndirectivawwds_15_tftrndirectivatitle)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trndirectivawwds_16_tftrndirectivatitle_sel)) && ! ( StringUtil.StrCmp(AV69Trndirectivawwds_16_tftrndirectivatitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaTitle` = @AV69Trndirectivawwds_16_tftrndirectivatitle_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trndirectivawwds_16_tftrndirectivatitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`TrnDirectivaTitle`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Trndirectivawwds_18_tftrndirectivavalue_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trndirectivawwds_17_tftrndirectivavalue)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` like @lV70Trndirectivawwds_17_tftrndirectivavalue)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trndirectivawwds_18_tftrndirectivavalue_sel)) && ! ( StringUtil.StrCmp(AV71Trndirectivawwds_18_tftrndirectivavalue_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaValue` = @AV71Trndirectivawwds_18_tftrndirectivavalue_sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV71Trndirectivawwds_18_tftrndirectivavalue_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`TrnDirectivaValue`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trndirectivawwds_19_tftrndirectivadescripcion)) ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaDescripcion` like @lV72Trndirectivawwds_19_tftrndirectivadescripcion)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel)) && ! ( StringUtil.StrCmp(AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`TrnDirectivaDescripcion` = @AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( StringUtil.StrCmp(AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`TrnDirectivaDescripcion`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `TrnDirectivaDescripcion`";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004E2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] );
               case 1 :
                     return conditional_P004E3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] );
               case 2 :
                     return conditional_P004E4(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004E2;
          prmP004E2 = new Object[] {
          new ParDef("@lV56Trndirectivawwds_3_trndirectivatitle1",GXType.Char,100,0) ,
          new ParDef("@lV56Trndirectivawwds_3_trndirectivatitle1",GXType.Char,100,0) ,
          new ParDef("@lV57Trndirectivawwds_4_trndirectivavalue1",GXType.Char,100,0) ,
          new ParDef("@lV57Trndirectivawwds_4_trndirectivavalue1",GXType.Char,100,0) ,
          new ParDef("@lV61Trndirectivawwds_8_trndirectivatitle2",GXType.Char,100,0) ,
          new ParDef("@lV61Trndirectivawwds_8_trndirectivatitle2",GXType.Char,100,0) ,
          new ParDef("@lV62Trndirectivawwds_9_trndirectivavalue2",GXType.Char,100,0) ,
          new ParDef("@lV62Trndirectivawwds_9_trndirectivavalue2",GXType.Char,100,0) ,
          new ParDef("@lV66Trndirectivawwds_13_trndirectivatitle3",GXType.Char,100,0) ,
          new ParDef("@lV66Trndirectivawwds_13_trndirectivatitle3",GXType.Char,100,0) ,
          new ParDef("@lV67Trndirectivawwds_14_trndirectivavalue3",GXType.Char,100,0) ,
          new ParDef("@lV67Trndirectivawwds_14_trndirectivavalue3",GXType.Char,100,0) ,
          new ParDef("@lV68Trndirectivawwds_15_tftrndirectivatitle",GXType.Char,100,0) ,
          new ParDef("@AV69Trndirectivawwds_16_tftrndirectivatitle_sel",GXType.Char,100,0) ,
          new ParDef("@lV70Trndirectivawwds_17_tftrndirectivavalue",GXType.Char,100,0) ,
          new ParDef("@AV71Trndirectivawwds_18_tftrndirectivavalue_sel",GXType.Char,100,0) ,
          new ParDef("@lV72Trndirectivawwds_19_tftrndirectivadescripcion",GXType.Char,2097152,0) ,
          new ParDef("@AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel",GXType.Char,2097152,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP004E3;
          prmP004E3 = new Object[] {
          new ParDef("@lV56Trndirectivawwds_3_trndirectivatitle1",GXType.Char,100,0) ,
          new ParDef("@lV56Trndirectivawwds_3_trndirectivatitle1",GXType.Char,100,0) ,
          new ParDef("@lV57Trndirectivawwds_4_trndirectivavalue1",GXType.Char,100,0) ,
          new ParDef("@lV57Trndirectivawwds_4_trndirectivavalue1",GXType.Char,100,0) ,
          new ParDef("@lV61Trndirectivawwds_8_trndirectivatitle2",GXType.Char,100,0) ,
          new ParDef("@lV61Trndirectivawwds_8_trndirectivatitle2",GXType.Char,100,0) ,
          new ParDef("@lV62Trndirectivawwds_9_trndirectivavalue2",GXType.Char,100,0) ,
          new ParDef("@lV62Trndirectivawwds_9_trndirectivavalue2",GXType.Char,100,0) ,
          new ParDef("@lV66Trndirectivawwds_13_trndirectivatitle3",GXType.Char,100,0) ,
          new ParDef("@lV66Trndirectivawwds_13_trndirectivatitle3",GXType.Char,100,0) ,
          new ParDef("@lV67Trndirectivawwds_14_trndirectivavalue3",GXType.Char,100,0) ,
          new ParDef("@lV67Trndirectivawwds_14_trndirectivavalue3",GXType.Char,100,0) ,
          new ParDef("@lV68Trndirectivawwds_15_tftrndirectivatitle",GXType.Char,100,0) ,
          new ParDef("@AV69Trndirectivawwds_16_tftrndirectivatitle_sel",GXType.Char,100,0) ,
          new ParDef("@lV70Trndirectivawwds_17_tftrndirectivavalue",GXType.Char,100,0) ,
          new ParDef("@AV71Trndirectivawwds_18_tftrndirectivavalue_sel",GXType.Char,100,0) ,
          new ParDef("@lV72Trndirectivawwds_19_tftrndirectivadescripcion",GXType.Char,2097152,0) ,
          new ParDef("@AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel",GXType.Char,2097152,0)
          };
          Object[] prmP004E4;
          prmP004E4 = new Object[] {
          new ParDef("@lV56Trndirectivawwds_3_trndirectivatitle1",GXType.Char,100,0) ,
          new ParDef("@lV56Trndirectivawwds_3_trndirectivatitle1",GXType.Char,100,0) ,
          new ParDef("@lV57Trndirectivawwds_4_trndirectivavalue1",GXType.Char,100,0) ,
          new ParDef("@lV57Trndirectivawwds_4_trndirectivavalue1",GXType.Char,100,0) ,
          new ParDef("@lV61Trndirectivawwds_8_trndirectivatitle2",GXType.Char,100,0) ,
          new ParDef("@lV61Trndirectivawwds_8_trndirectivatitle2",GXType.Char,100,0) ,
          new ParDef("@lV62Trndirectivawwds_9_trndirectivavalue2",GXType.Char,100,0) ,
          new ParDef("@lV62Trndirectivawwds_9_trndirectivavalue2",GXType.Char,100,0) ,
          new ParDef("@lV66Trndirectivawwds_13_trndirectivatitle3",GXType.Char,100,0) ,
          new ParDef("@lV66Trndirectivawwds_13_trndirectivatitle3",GXType.Char,100,0) ,
          new ParDef("@lV67Trndirectivawwds_14_trndirectivavalue3",GXType.Char,100,0) ,
          new ParDef("@lV67Trndirectivawwds_14_trndirectivavalue3",GXType.Char,100,0) ,
          new ParDef("@lV68Trndirectivawwds_15_tftrndirectivatitle",GXType.Char,100,0) ,
          new ParDef("@AV69Trndirectivawwds_16_tftrndirectivatitle_sel",GXType.Char,100,0) ,
          new ParDef("@lV70Trndirectivawwds_17_tftrndirectivavalue",GXType.Char,100,0) ,
          new ParDef("@AV71Trndirectivawwds_18_tftrndirectivavalue_sel",GXType.Char,100,0) ,
          new ParDef("@lV72Trndirectivawwds_19_tftrndirectivadescripcion",GXType.Char,2097152,0) ,
          new ParDef("@AV73Trndirectivawwds_20_tftrndirectivadescripcion_sel",GXType.Char,2097152,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004E2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004E3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004E4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004E4,100, GxCacheFrequency.OFF ,true,false )
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
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
