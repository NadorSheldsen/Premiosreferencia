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
   public class wppromociongetfilterdata : GXProcedure
   {
      public wppromociongetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wppromociongetfilterdata( IGxContext context )
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
         this.AV36DDOName = aP0_DDOName;
         this.AV37SearchTxtParms = aP1_SearchTxtParms;
         this.AV38SearchTxtTo = aP2_SearchTxtTo;
         this.AV39OptionsJson = "" ;
         this.AV40OptionsDescJson = "" ;
         this.AV41OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV39OptionsJson;
         aP4_OptionsDescJson=this.AV40OptionsDescJson;
         aP5_OptionIndexesJson=this.AV41OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV41OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV36DDOName = aP0_DDOName;
         this.AV37SearchTxtParms = aP1_SearchTxtParms;
         this.AV38SearchTxtTo = aP2_SearchTxtTo;
         this.AV39OptionsJson = "" ;
         this.AV40OptionsDescJson = "" ;
         this.AV41OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV39OptionsJson;
         aP4_OptionsDescJson=this.AV40OptionsDescJson;
         aP5_OptionIndexesJson=this.AV41OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV26Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23MaxItems = 10;
         AV22PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV37SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV37SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV20SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV37SearchTxtParms)) ? "" : StringUtil.Substring( AV37SearchTxtParms, 3, -1));
         AV21SkipItems = (short)(AV22PageIndex*AV23MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_PROMOCIONDESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADPROMOCIONDESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_PROMOCIONVIGENCIA") == 0 )
         {
            /* Execute user subroutine: 'LOADPROMOCIONVIGENCIAOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV39OptionsJson = AV26Options.ToJSonString(false);
         AV40OptionsDescJson = AV28OptionsDesc.ToJSonString(false);
         AV41OptionIndexesJson = AV29OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get("WPPromocionGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPPromocionGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("WPPromocionGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV42FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION") == 0 )
            {
               AV12TFPromocionDescripcion = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION_SEL") == 0 )
            {
               AV13TFPromocionDescripcion_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROMOCIONVIGENCIA") == 0 )
            {
               AV47TFPromocionVigencia = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROMOCIONVIGENCIA_SEL") == 0 )
            {
               AV48TFPromocionVigencia_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROMOCIONDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV12TFPromocionDescripcion = AV20SearchTxt;
         AV13TFPromocionDescripcion_Sel = "";
         AV51Wppromocionds_1_filterfulltext = AV42FilterFullText;
         AV52Wppromocionds_2_tfpromociondescripcion = AV12TFPromocionDescripcion;
         AV53Wppromocionds_3_tfpromociondescripcion_sel = AV13TFPromocionDescripcion_Sel;
         AV54Wppromocionds_4_tfpromocionvigencia = AV47TFPromocionVigencia;
         AV55Wppromocionds_5_tfpromocionvigencia_sel = AV48TFPromocionVigencia_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV53Wppromocionds_3_tfpromociondescripcion_sel ,
                                              AV52Wppromocionds_2_tfpromociondescripcion ,
                                              A42PromocionDescripcion ,
                                              AV51Wppromocionds_1_filterfulltext ,
                                              A70PromocionVigencia ,
                                              A43PromocionBase ,
                                              AV55Wppromocionds_5_tfpromocionvigencia_sel ,
                                              AV54Wppromocionds_4_tfpromocionvigencia } ,
                                              new int[]{
                                              }
         });
         lV52Wppromocionds_2_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV52Wppromocionds_2_tfpromociondescripcion), "%", "");
         /* Using cursor P002O2 */
         pr_default.execute(0, new Object[] {lV52Wppromocionds_2_tfpromociondescripcion, AV53Wppromocionds_3_tfpromociondescripcion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2O2 = false;
            A42PromocionDescripcion = P002O2_A42PromocionDescripcion[0];
            A43PromocionBase = P002O2_A43PromocionBase[0];
            A46PromocionFechaFin = P002O2_A46PromocionFechaFin[0];
            A45PromocionFechaInicio = P002O2_A45PromocionFechaInicio[0];
            A41PromocionID = P002O2_A41PromocionID[0];
            A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wppromocionds_1_filterfulltext)) || ( ( StringUtil.Like( A42PromocionDescripcion , StringUtil.PadR( "%" + AV51Wppromocionds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A70PromocionVigencia , StringUtil.PadR( "%" + AV51Wppromocionds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A43PromocionBase , StringUtil.PadR( "%" + AV51Wppromocionds_1_filterfulltext , 700 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wppromocionds_5_tfpromocionvigencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wppromocionds_4_tfpromocionvigencia)) ) ) || ( StringUtil.Like( A70PromocionVigencia , StringUtil.PadR( AV54Wppromocionds_4_tfpromocionvigencia , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wppromocionds_5_tfpromocionvigencia_sel)) && ! ( StringUtil.StrCmp(AV55Wppromocionds_5_tfpromocionvigencia_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) ) || ( ( StringUtil.StrCmp(A70PromocionVigencia, AV55Wppromocionds_5_tfpromocionvigencia_sel) == 0 ) ) )
                  {
                     if ( ! ( ( StringUtil.StrCmp(AV55Wppromocionds_5_tfpromocionvigencia_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A70PromocionVigencia)) ) )
                     {
                        AV30count = 0;
                        while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002O2_A42PromocionDescripcion[0], A42PromocionDescripcion) == 0 ) )
                        {
                           BRK2O2 = false;
                           A41PromocionID = P002O2_A41PromocionID[0];
                           AV30count = (long)(AV30count+1);
                           BRK2O2 = true;
                           pr_default.readNext(0);
                        }
                        if ( (0==AV21SkipItems) )
                        {
                           AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A42PromocionDescripcion)) ? "<#Empty#>" : A42PromocionDescripcion);
                           AV26Options.Add(AV25Option, 0);
                           AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV26Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV21SkipItems = (short)(AV21SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRK2O2 )
            {
               BRK2O2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROMOCIONVIGENCIAOPTIONS' Routine */
         returnInSub = false;
         AV47TFPromocionVigencia = AV20SearchTxt;
         AV48TFPromocionVigencia_Sel = "";
         AV51Wppromocionds_1_filterfulltext = AV42FilterFullText;
         AV52Wppromocionds_2_tfpromociondescripcion = AV12TFPromocionDescripcion;
         AV53Wppromocionds_3_tfpromociondescripcion_sel = AV13TFPromocionDescripcion_Sel;
         AV54Wppromocionds_4_tfpromocionvigencia = AV47TFPromocionVigencia;
         AV55Wppromocionds_5_tfpromocionvigencia_sel = AV48TFPromocionVigencia_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV53Wppromocionds_3_tfpromociondescripcion_sel ,
                                              AV52Wppromocionds_2_tfpromociondescripcion ,
                                              A42PromocionDescripcion ,
                                              AV51Wppromocionds_1_filterfulltext ,
                                              A70PromocionVigencia ,
                                              A43PromocionBase ,
                                              AV55Wppromocionds_5_tfpromocionvigencia_sel ,
                                              AV54Wppromocionds_4_tfpromocionvigencia } ,
                                              new int[]{
                                              }
         });
         lV52Wppromocionds_2_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV52Wppromocionds_2_tfpromociondescripcion), "%", "");
         /* Using cursor P002O3 */
         pr_default.execute(1, new Object[] {lV52Wppromocionds_2_tfpromociondescripcion, AV53Wppromocionds_3_tfpromociondescripcion_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A43PromocionBase = P002O3_A43PromocionBase[0];
            A42PromocionDescripcion = P002O3_A42PromocionDescripcion[0];
            A46PromocionFechaFin = P002O3_A46PromocionFechaFin[0];
            A45PromocionFechaInicio = P002O3_A45PromocionFechaInicio[0];
            A41PromocionID = P002O3_A41PromocionID[0];
            A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wppromocionds_1_filterfulltext)) || ( ( StringUtil.Like( A42PromocionDescripcion , StringUtil.PadR( "%" + AV51Wppromocionds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A70PromocionVigencia , StringUtil.PadR( "%" + AV51Wppromocionds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A43PromocionBase , StringUtil.PadR( "%" + AV51Wppromocionds_1_filterfulltext , 700 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wppromocionds_5_tfpromocionvigencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wppromocionds_4_tfpromocionvigencia)) ) ) || ( StringUtil.Like( A70PromocionVigencia , StringUtil.PadR( AV54Wppromocionds_4_tfpromocionvigencia , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wppromocionds_5_tfpromocionvigencia_sel)) && ! ( StringUtil.StrCmp(AV55Wppromocionds_5_tfpromocionvigencia_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) ) || ( ( StringUtil.StrCmp(A70PromocionVigencia, AV55Wppromocionds_5_tfpromocionvigencia_sel) == 0 ) ) )
                  {
                     if ( ! ( ( StringUtil.StrCmp(AV55Wppromocionds_5_tfpromocionvigencia_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A70PromocionVigencia)) ) )
                     {
                        AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A70PromocionVigencia)) ? "<#Empty#>" : A70PromocionVigencia);
                        AV24InsertIndex = 1;
                        while ( ( StringUtil.StrCmp(AV25Option, "<#Empty#>") != 0 ) && ( AV24InsertIndex <= AV26Options.Count ) && ( ( StringUtil.StrCmp(((string)AV26Options.Item(AV24InsertIndex)), AV25Option) < 0 ) || ( StringUtil.StrCmp(((string)AV26Options.Item(AV24InsertIndex)), "<#Empty#>") == 0 ) ) )
                        {
                           AV24InsertIndex = (int)(AV24InsertIndex+1);
                        }
                        if ( ( AV24InsertIndex <= AV26Options.Count ) && ( StringUtil.StrCmp(((string)AV26Options.Item(AV24InsertIndex)), AV25Option) == 0 ) )
                        {
                           AV30count = (long)(Math.Round(NumberUtil.Val( ((string)AV29OptionIndexes.Item(AV24InsertIndex)), "."), 18, MidpointRounding.ToEven));
                           AV30count = (long)(AV30count+1);
                           AV29OptionIndexes.RemoveItem(AV24InsertIndex);
                           AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), AV24InsertIndex);
                        }
                        else
                        {
                           AV26Options.Add(AV25Option, AV24InsertIndex);
                           AV29OptionIndexes.Add("1", AV24InsertIndex);
                        }
                        if ( AV26Options.Count == AV21SkipItems + 11 )
                        {
                           AV26Options.RemoveItem(AV26Options.Count);
                           AV29OptionIndexes.RemoveItem(AV29OptionIndexes.Count);
                        }
                     }
                  }
               }
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         while ( AV21SkipItems > 0 )
         {
            AV26Options.RemoveItem(1);
            AV29OptionIndexes.RemoveItem(1);
            AV21SkipItems = (short)(AV21SkipItems-1);
         }
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
         AV39OptionsJson = "";
         AV40OptionsDescJson = "";
         AV41OptionIndexesJson = "";
         AV26Options = new GxSimpleCollection<string>();
         AV28OptionsDesc = new GxSimpleCollection<string>();
         AV29OptionIndexes = new GxSimpleCollection<string>();
         AV20SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV31Session = context.GetSession();
         AV33GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV34GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV42FilterFullText = "";
         AV12TFPromocionDescripcion = "";
         AV13TFPromocionDescripcion_Sel = "";
         AV47TFPromocionVigencia = "";
         AV48TFPromocionVigencia_Sel = "";
         AV51Wppromocionds_1_filterfulltext = "";
         AV52Wppromocionds_2_tfpromociondescripcion = "";
         AV53Wppromocionds_3_tfpromociondescripcion_sel = "";
         AV54Wppromocionds_4_tfpromocionvigencia = "";
         AV55Wppromocionds_5_tfpromocionvigencia_sel = "";
         lV51Wppromocionds_1_filterfulltext = "";
         lV52Wppromocionds_2_tfpromociondescripcion = "";
         A42PromocionDescripcion = "";
         A70PromocionVigencia = "";
         A43PromocionBase = "";
         P002O2_A42PromocionDescripcion = new string[] {""} ;
         P002O2_A43PromocionBase = new string[] {""} ;
         P002O2_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         P002O2_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         P002O2_A41PromocionID = new int[1] ;
         A46PromocionFechaFin = DateTime.MinValue;
         A45PromocionFechaInicio = DateTime.MinValue;
         AV25Option = "";
         P002O3_A43PromocionBase = new string[] {""} ;
         P002O3_A42PromocionDescripcion = new string[] {""} ;
         P002O3_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         P002O3_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         P002O3_A41PromocionID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wppromociongetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002O2_A42PromocionDescripcion, P002O2_A43PromocionBase, P002O2_A46PromocionFechaFin, P002O2_A45PromocionFechaInicio, P002O2_A41PromocionID
               }
               , new Object[] {
               P002O3_A43PromocionBase, P002O3_A42PromocionDescripcion, P002O3_A46PromocionFechaFin, P002O3_A45PromocionFechaInicio, P002O3_A41PromocionID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV23MaxItems ;
      private short AV22PageIndex ;
      private short AV21SkipItems ;
      private int AV49GXV1 ;
      private int A41PromocionID ;
      private int AV24InsertIndex ;
      private long AV30count ;
      private DateTime A46PromocionFechaFin ;
      private DateTime A45PromocionFechaInicio ;
      private bool returnInSub ;
      private bool BRK2O2 ;
      private string AV39OptionsJson ;
      private string AV40OptionsDescJson ;
      private string AV41OptionIndexesJson ;
      private string AV36DDOName ;
      private string AV37SearchTxtParms ;
      private string AV38SearchTxtTo ;
      private string AV20SearchTxt ;
      private string AV42FilterFullText ;
      private string AV12TFPromocionDescripcion ;
      private string AV13TFPromocionDescripcion_Sel ;
      private string AV47TFPromocionVigencia ;
      private string AV48TFPromocionVigencia_Sel ;
      private string AV51Wppromocionds_1_filterfulltext ;
      private string AV52Wppromocionds_2_tfpromociondescripcion ;
      private string AV53Wppromocionds_3_tfpromociondescripcion_sel ;
      private string AV54Wppromocionds_4_tfpromocionvigencia ;
      private string AV55Wppromocionds_5_tfpromocionvigencia_sel ;
      private string lV51Wppromocionds_1_filterfulltext ;
      private string lV52Wppromocionds_2_tfpromociondescripcion ;
      private string A42PromocionDescripcion ;
      private string A70PromocionVigencia ;
      private string A43PromocionBase ;
      private string AV25Option ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV26Options ;
      private GxSimpleCollection<string> AV28OptionsDesc ;
      private GxSimpleCollection<string> AV29OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV33GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P002O2_A42PromocionDescripcion ;
      private string[] P002O2_A43PromocionBase ;
      private DateTime[] P002O2_A46PromocionFechaFin ;
      private DateTime[] P002O2_A45PromocionFechaInicio ;
      private int[] P002O2_A41PromocionID ;
      private string[] P002O3_A43PromocionBase ;
      private string[] P002O3_A42PromocionDescripcion ;
      private DateTime[] P002O3_A46PromocionFechaFin ;
      private DateTime[] P002O3_A45PromocionFechaInicio ;
      private int[] P002O3_A41PromocionID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wppromociongetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002O2( IGxContext context ,
                                             string AV53Wppromocionds_3_tfpromociondescripcion_sel ,
                                             string AV52Wppromocionds_2_tfpromociondescripcion ,
                                             string A42PromocionDescripcion ,
                                             string AV51Wppromocionds_1_filterfulltext ,
                                             string A70PromocionVigencia ,
                                             string A43PromocionBase ,
                                             string AV55Wppromocionds_5_tfpromocionvigencia_sel ,
                                             string AV54Wppromocionds_4_tfpromocionvigencia )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT `PromocionDescripcion`, `PromocionBase`, `PromocionFechaFin`, `PromocionFechaInicio`, `PromocionID` FROM `Promocion`";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wppromocionds_3_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wppromocionds_2_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` like @lV52Wppromocionds_2_tfpromociondescripcion)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wppromocionds_3_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV53Wppromocionds_3_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` = @AV53Wppromocionds_3_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV53Wppromocionds_3_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionDescripcion`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `PromocionDescripcion`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002O3( IGxContext context ,
                                             string AV53Wppromocionds_3_tfpromociondescripcion_sel ,
                                             string AV52Wppromocionds_2_tfpromociondescripcion ,
                                             string A42PromocionDescripcion ,
                                             string AV51Wppromocionds_1_filterfulltext ,
                                             string A70PromocionVigencia ,
                                             string A43PromocionBase ,
                                             string AV55Wppromocionds_5_tfpromocionvigencia_sel ,
                                             string AV54Wppromocionds_4_tfpromocionvigencia )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT `PromocionBase`, `PromocionDescripcion`, `PromocionFechaFin`, `PromocionFechaInicio`, `PromocionID` FROM `Promocion`";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wppromocionds_3_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wppromocionds_2_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` like @lV52Wppromocionds_2_tfpromociondescripcion)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wppromocionds_3_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV53Wppromocionds_3_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` = @AV53Wppromocionds_3_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( StringUtil.StrCmp(AV53Wppromocionds_3_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionDescripcion`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `PromocionID`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002O2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] );
               case 1 :
                     return conditional_P002O3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002O2;
          prmP002O2 = new Object[] {
          new ParDef("@lV52Wppromocionds_2_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV53Wppromocionds_3_tfpromociondescripcion_sel",GXType.Char,80,0)
          };
          Object[] prmP002O3;
          prmP002O3 = new Object[] {
          new ParDef("@lV52Wppromocionds_2_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV53Wppromocionds_3_tfpromociondescripcion_sel",GXType.Char,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002O2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002O3,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
