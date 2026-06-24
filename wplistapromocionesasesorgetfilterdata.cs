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
   public class wplistapromocionesasesorgetfilterdata : GXProcedure
   {
      public wplistapromocionesasesorgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wplistapromocionesasesorgetfilterdata( IGxContext context )
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
         this.AV38DDOName = aP0_DDOName;
         this.AV39SearchTxtParms = aP1_SearchTxtParms;
         this.AV40SearchTxtTo = aP2_SearchTxtTo;
         this.AV41OptionsJson = "" ;
         this.AV42OptionsDescJson = "" ;
         this.AV43OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV41OptionsJson;
         aP4_OptionsDescJson=this.AV42OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV43OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV38DDOName = aP0_DDOName;
         this.AV39SearchTxtParms = aP1_SearchTxtParms;
         this.AV40SearchTxtTo = aP2_SearchTxtTo;
         this.AV41OptionsJson = "" ;
         this.AV42OptionsDescJson = "" ;
         this.AV43OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV41OptionsJson;
         aP4_OptionsDescJson=this.AV42OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV28Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25MaxItems = 10;
         AV24PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV39SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV39SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV22SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV39SearchTxtParms)) ? "" : StringUtil.Substring( AV39SearchTxtParms, 3, -1));
         AV23SkipItems = (short)(AV24PageIndex*AV25MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_PROMOCIONDESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADPROMOCIONDESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_PROMOCIONBASE") == 0 )
         {
            /* Execute user subroutine: 'LOADPROMOCIONBASEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_PROMOCIONVIGENCIA") == 0 )
         {
            /* Execute user subroutine: 'LOADPROMOCIONVIGENCIAOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV41OptionsJson = AV28Options.ToJSonString(false);
         AV42OptionsDescJson = AV30OptionsDesc.ToJSonString(false);
         AV43OptionIndexesJson = AV31OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get("WPListaPromocionesAsesorGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPListaPromocionesAsesorGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("WPListaPromocionesAsesorGridState"), null, "", "");
         }
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV46GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV44FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROMOCIONID") == 0 )
            {
               AV10TFPromocionID = (int)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV11TFPromocionID_To = (int)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION") == 0 )
            {
               AV12TFPromocionDescripcion = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION_SEL") == 0 )
            {
               AV13TFPromocionDescripcion_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROMOCIONBASE") == 0 )
            {
               AV14TFPromocionBase = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROMOCIONBASE_SEL") == 0 )
            {
               AV15TFPromocionBase_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROMOCIONVIGENCIA") == 0 )
            {
               AV20TFPromocionVigencia = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROMOCIONVIGENCIA_SEL") == 0 )
            {
               AV21TFPromocionVigencia_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROMOCIONDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV12TFPromocionDescripcion = AV22SearchTxt;
         AV13TFPromocionDescripcion_Sel = "";
         AV48Wplistapromocionesasesords_1_filterfulltext = AV44FilterFullText;
         AV49Wplistapromocionesasesords_2_tfpromocionid = AV10TFPromocionID;
         AV50Wplistapromocionesasesords_3_tfpromocionid_to = AV11TFPromocionID_To;
         AV51Wplistapromocionesasesords_4_tfpromociondescripcion = AV12TFPromocionDescripcion;
         AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel = AV13TFPromocionDescripcion_Sel;
         AV53Wplistapromocionesasesords_6_tfpromocionbase = AV14TFPromocionBase;
         AV54Wplistapromocionesasesords_7_tfpromocionbase_sel = AV15TFPromocionBase_Sel;
         AV55Wplistapromocionesasesords_8_tfpromocionvigencia = AV20TFPromocionVigencia;
         AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel = AV21TFPromocionVigencia_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A41PromocionID ,
                                              AV45ListaPromociones ,
                                              AV49Wplistapromocionesasesords_2_tfpromocionid ,
                                              AV50Wplistapromocionesasesords_3_tfpromocionid_to ,
                                              AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel ,
                                              AV51Wplistapromocionesasesords_4_tfpromociondescripcion ,
                                              AV54Wplistapromocionesasesords_7_tfpromocionbase_sel ,
                                              AV53Wplistapromocionesasesords_6_tfpromocionbase ,
                                              A42PromocionDescripcion ,
                                              A43PromocionBase ,
                                              AV48Wplistapromocionesasesords_1_filterfulltext ,
                                              A70PromocionVigencia ,
                                              AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel ,
                                              AV55Wplistapromocionesasesords_8_tfpromocionvigencia } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV51Wplistapromocionesasesords_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV51Wplistapromocionesasesords_4_tfpromociondescripcion), "%", "");
         lV53Wplistapromocionesasesords_6_tfpromocionbase = StringUtil.Concat( StringUtil.RTrim( AV53Wplistapromocionesasesords_6_tfpromocionbase), "%", "");
         /* Using cursor P003M2 */
         pr_default.execute(0, new Object[] {AV49Wplistapromocionesasesords_2_tfpromocionid, AV50Wplistapromocionesasesords_3_tfpromocionid_to, lV51Wplistapromocionesasesords_4_tfpromociondescripcion, AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel, lV53Wplistapromocionesasesords_6_tfpromocionbase, AV54Wplistapromocionesasesords_7_tfpromocionbase_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3M2 = false;
            A42PromocionDescripcion = P003M2_A42PromocionDescripcion[0];
            A41PromocionID = P003M2_A41PromocionID[0];
            A43PromocionBase = P003M2_A43PromocionBase[0];
            A46PromocionFechaFin = P003M2_A46PromocionFechaFin[0];
            A45PromocionFechaInicio = P003M2_A45PromocionFechaInicio[0];
            A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wplistapromocionesasesords_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A41PromocionID), 9, 0) , StringUtil.PadR( "%" + AV48Wplistapromocionesasesords_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A42PromocionDescripcion , StringUtil.PadR( "%" + AV48Wplistapromocionesasesords_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A43PromocionBase , StringUtil.PadR( "%" + AV48Wplistapromocionesasesords_1_filterfulltext , 700 , "%"),  ' ' ) ) || ( StringUtil.Like( A70PromocionVigencia , StringUtil.PadR( "%" + AV48Wplistapromocionesasesords_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wplistapromocionesasesords_8_tfpromocionvigencia)) ) ) || ( StringUtil.Like( A70PromocionVigencia , StringUtil.PadR( AV55Wplistapromocionesasesords_8_tfpromocionvigencia , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel)) && ! ( StringUtil.StrCmp(AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) ) || ( ( StringUtil.StrCmp(A70PromocionVigencia, AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel) == 0 ) ) )
                  {
                     if ( ! ( ( StringUtil.StrCmp(AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A70PromocionVigencia)) ) )
                     {
                        AV32count = 0;
                        while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P003M2_A42PromocionDescripcion[0], A42PromocionDescripcion) == 0 ) )
                        {
                           BRK3M2 = false;
                           A41PromocionID = P003M2_A41PromocionID[0];
                           if ( (AV45ListaPromociones.IndexOf(A41PromocionID)>0) )
                           {
                              AV32count = (long)(AV32count+1);
                           }
                           BRK3M2 = true;
                           pr_default.readNext(0);
                        }
                        if ( (0==AV23SkipItems) )
                        {
                           AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A42PromocionDescripcion)) ? "<#Empty#>" : A42PromocionDescripcion);
                           AV28Options.Add(AV27Option, 0);
                           AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV28Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV23SkipItems = (short)(AV23SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRK3M2 )
            {
               BRK3M2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROMOCIONBASEOPTIONS' Routine */
         returnInSub = false;
         AV14TFPromocionBase = AV22SearchTxt;
         AV15TFPromocionBase_Sel = "";
         AV48Wplistapromocionesasesords_1_filterfulltext = AV44FilterFullText;
         AV49Wplistapromocionesasesords_2_tfpromocionid = AV10TFPromocionID;
         AV50Wplistapromocionesasesords_3_tfpromocionid_to = AV11TFPromocionID_To;
         AV51Wplistapromocionesasesords_4_tfpromociondescripcion = AV12TFPromocionDescripcion;
         AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel = AV13TFPromocionDescripcion_Sel;
         AV53Wplistapromocionesasesords_6_tfpromocionbase = AV14TFPromocionBase;
         AV54Wplistapromocionesasesords_7_tfpromocionbase_sel = AV15TFPromocionBase_Sel;
         AV55Wplistapromocionesasesords_8_tfpromocionvigencia = AV20TFPromocionVigencia;
         AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel = AV21TFPromocionVigencia_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A41PromocionID ,
                                              AV45ListaPromociones ,
                                              AV49Wplistapromocionesasesords_2_tfpromocionid ,
                                              AV50Wplistapromocionesasesords_3_tfpromocionid_to ,
                                              AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel ,
                                              AV51Wplistapromocionesasesords_4_tfpromociondescripcion ,
                                              AV54Wplistapromocionesasesords_7_tfpromocionbase_sel ,
                                              AV53Wplistapromocionesasesords_6_tfpromocionbase ,
                                              A42PromocionDescripcion ,
                                              A43PromocionBase ,
                                              AV48Wplistapromocionesasesords_1_filterfulltext ,
                                              A70PromocionVigencia ,
                                              AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel ,
                                              AV55Wplistapromocionesasesords_8_tfpromocionvigencia } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV51Wplistapromocionesasesords_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV51Wplistapromocionesasesords_4_tfpromociondescripcion), "%", "");
         lV53Wplistapromocionesasesords_6_tfpromocionbase = StringUtil.Concat( StringUtil.RTrim( AV53Wplistapromocionesasesords_6_tfpromocionbase), "%", "");
         /* Using cursor P003M3 */
         pr_default.execute(1, new Object[] {AV49Wplistapromocionesasesords_2_tfpromocionid, AV50Wplistapromocionesasesords_3_tfpromocionid_to, lV51Wplistapromocionesasesords_4_tfpromociondescripcion, AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel, lV53Wplistapromocionesasesords_6_tfpromocionbase, AV54Wplistapromocionesasesords_7_tfpromocionbase_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK3M4 = false;
            A43PromocionBase = P003M3_A43PromocionBase[0];
            A41PromocionID = P003M3_A41PromocionID[0];
            A42PromocionDescripcion = P003M3_A42PromocionDescripcion[0];
            A46PromocionFechaFin = P003M3_A46PromocionFechaFin[0];
            A45PromocionFechaInicio = P003M3_A45PromocionFechaInicio[0];
            A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wplistapromocionesasesords_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A41PromocionID), 9, 0) , StringUtil.PadR( "%" + AV48Wplistapromocionesasesords_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A42PromocionDescripcion , StringUtil.PadR( "%" + AV48Wplistapromocionesasesords_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A43PromocionBase , StringUtil.PadR( "%" + AV48Wplistapromocionesasesords_1_filterfulltext , 700 , "%"),  ' ' ) ) || ( StringUtil.Like( A70PromocionVigencia , StringUtil.PadR( "%" + AV48Wplistapromocionesasesords_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wplistapromocionesasesords_8_tfpromocionvigencia)) ) ) || ( StringUtil.Like( A70PromocionVigencia , StringUtil.PadR( AV55Wplistapromocionesasesords_8_tfpromocionvigencia , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel)) && ! ( StringUtil.StrCmp(AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) ) || ( ( StringUtil.StrCmp(A70PromocionVigencia, AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel) == 0 ) ) )
                  {
                     if ( ! ( ( StringUtil.StrCmp(AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A70PromocionVigencia)) ) )
                     {
                        AV32count = 0;
                        while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P003M3_A43PromocionBase[0], A43PromocionBase) == 0 ) )
                        {
                           BRK3M4 = false;
                           A41PromocionID = P003M3_A41PromocionID[0];
                           if ( (AV45ListaPromociones.IndexOf(A41PromocionID)>0) )
                           {
                              AV32count = (long)(AV32count+1);
                           }
                           BRK3M4 = true;
                           pr_default.readNext(1);
                        }
                        if ( (0==AV23SkipItems) )
                        {
                           AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A43PromocionBase)) ? "<#Empty#>" : A43PromocionBase);
                           AV28Options.Add(AV27Option, 0);
                           AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV28Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV23SkipItems = (short)(AV23SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRK3M4 )
            {
               BRK3M4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPROMOCIONVIGENCIAOPTIONS' Routine */
         returnInSub = false;
         AV20TFPromocionVigencia = AV22SearchTxt;
         AV21TFPromocionVigencia_Sel = "";
         AV48Wplistapromocionesasesords_1_filterfulltext = AV44FilterFullText;
         AV49Wplistapromocionesasesords_2_tfpromocionid = AV10TFPromocionID;
         AV50Wplistapromocionesasesords_3_tfpromocionid_to = AV11TFPromocionID_To;
         AV51Wplistapromocionesasesords_4_tfpromociondescripcion = AV12TFPromocionDescripcion;
         AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel = AV13TFPromocionDescripcion_Sel;
         AV53Wplistapromocionesasesords_6_tfpromocionbase = AV14TFPromocionBase;
         AV54Wplistapromocionesasesords_7_tfpromocionbase_sel = AV15TFPromocionBase_Sel;
         AV55Wplistapromocionesasesords_8_tfpromocionvigencia = AV20TFPromocionVigencia;
         AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel = AV21TFPromocionVigencia_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A41PromocionID ,
                                              AV45ListaPromociones ,
                                              AV49Wplistapromocionesasesords_2_tfpromocionid ,
                                              AV50Wplistapromocionesasesords_3_tfpromocionid_to ,
                                              AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel ,
                                              AV51Wplistapromocionesasesords_4_tfpromociondescripcion ,
                                              AV54Wplistapromocionesasesords_7_tfpromocionbase_sel ,
                                              AV53Wplistapromocionesasesords_6_tfpromocionbase ,
                                              A42PromocionDescripcion ,
                                              A43PromocionBase ,
                                              AV48Wplistapromocionesasesords_1_filterfulltext ,
                                              A70PromocionVigencia ,
                                              AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel ,
                                              AV55Wplistapromocionesasesords_8_tfpromocionvigencia } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV51Wplistapromocionesasesords_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV51Wplistapromocionesasesords_4_tfpromociondescripcion), "%", "");
         lV53Wplistapromocionesasesords_6_tfpromocionbase = StringUtil.Concat( StringUtil.RTrim( AV53Wplistapromocionesasesords_6_tfpromocionbase), "%", "");
         /* Using cursor P003M4 */
         pr_default.execute(2, new Object[] {AV49Wplistapromocionesasesords_2_tfpromocionid, AV50Wplistapromocionesasesords_3_tfpromocionid_to, lV51Wplistapromocionesasesords_4_tfpromociondescripcion, AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel, lV53Wplistapromocionesasesords_6_tfpromocionbase, AV54Wplistapromocionesasesords_7_tfpromocionbase_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A41PromocionID = P003M4_A41PromocionID[0];
            A43PromocionBase = P003M4_A43PromocionBase[0];
            A42PromocionDescripcion = P003M4_A42PromocionDescripcion[0];
            A46PromocionFechaFin = P003M4_A46PromocionFechaFin[0];
            A45PromocionFechaInicio = P003M4_A45PromocionFechaInicio[0];
            A70PromocionVigencia = StringUtil.Trim( context.localUtil.DToC( A45PromocionFechaInicio, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")) + " - " + StringUtil.Trim( context.localUtil.DToC( A46PromocionFechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wplistapromocionesasesords_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A41PromocionID), 9, 0) , StringUtil.PadR( "%" + AV48Wplistapromocionesasesords_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A42PromocionDescripcion , StringUtil.PadR( "%" + AV48Wplistapromocionesasesords_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A43PromocionBase , StringUtil.PadR( "%" + AV48Wplistapromocionesasesords_1_filterfulltext , 700 , "%"),  ' ' ) ) || ( StringUtil.Like( A70PromocionVigencia , StringUtil.PadR( "%" + AV48Wplistapromocionesasesords_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wplistapromocionesasesords_8_tfpromocionvigencia)) ) ) || ( StringUtil.Like( A70PromocionVigencia , StringUtil.PadR( AV55Wplistapromocionesasesords_8_tfpromocionvigencia , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel)) && ! ( StringUtil.StrCmp(AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) ) || ( ( StringUtil.StrCmp(A70PromocionVigencia, AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel) == 0 ) ) )
                  {
                     if ( ! ( ( StringUtil.StrCmp(AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A70PromocionVigencia)) ) )
                     {
                        AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A70PromocionVigencia)) ? "<#Empty#>" : A70PromocionVigencia);
                        AV26InsertIndex = 1;
                        while ( ( StringUtil.StrCmp(AV27Option, "<#Empty#>") != 0 ) && ( AV26InsertIndex <= AV28Options.Count ) && ( ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), AV27Option) < 0 ) || ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), "<#Empty#>") == 0 ) ) )
                        {
                           AV26InsertIndex = (int)(AV26InsertIndex+1);
                        }
                        if ( ( AV26InsertIndex <= AV28Options.Count ) && ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), AV27Option) == 0 ) )
                        {
                           AV32count = (long)(Math.Round(NumberUtil.Val( ((string)AV31OptionIndexes.Item(AV26InsertIndex)), "."), 18, MidpointRounding.ToEven));
                           AV32count = (long)(AV32count+1);
                           AV31OptionIndexes.RemoveItem(AV26InsertIndex);
                           AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), AV26InsertIndex);
                        }
                        else
                        {
                           AV28Options.Add(AV27Option, AV26InsertIndex);
                           AV31OptionIndexes.Add("1", AV26InsertIndex);
                        }
                        if ( AV28Options.Count == AV23SkipItems + 11 )
                        {
                           AV28Options.RemoveItem(AV28Options.Count);
                           AV31OptionIndexes.RemoveItem(AV31OptionIndexes.Count);
                        }
                     }
                  }
               }
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         while ( AV23SkipItems > 0 )
         {
            AV28Options.RemoveItem(1);
            AV31OptionIndexes.RemoveItem(1);
            AV23SkipItems = (short)(AV23SkipItems-1);
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
         AV41OptionsJson = "";
         AV42OptionsDescJson = "";
         AV43OptionIndexesJson = "";
         AV28Options = new GxSimpleCollection<string>();
         AV30OptionsDesc = new GxSimpleCollection<string>();
         AV31OptionIndexes = new GxSimpleCollection<string>();
         AV22SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV33Session = context.GetSession();
         AV35GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV36GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV44FilterFullText = "";
         AV12TFPromocionDescripcion = "";
         AV13TFPromocionDescripcion_Sel = "";
         AV14TFPromocionBase = "";
         AV15TFPromocionBase_Sel = "";
         AV20TFPromocionVigencia = "";
         AV21TFPromocionVigencia_Sel = "";
         AV48Wplistapromocionesasesords_1_filterfulltext = "";
         AV51Wplistapromocionesasesords_4_tfpromociondescripcion = "";
         AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel = "";
         AV53Wplistapromocionesasesords_6_tfpromocionbase = "";
         AV54Wplistapromocionesasesords_7_tfpromocionbase_sel = "";
         AV55Wplistapromocionesasesords_8_tfpromocionvigencia = "";
         AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel = "";
         lV51Wplistapromocionesasesords_4_tfpromociondescripcion = "";
         lV53Wplistapromocionesasesords_6_tfpromocionbase = "";
         AV45ListaPromociones = new GxSimpleCollection<int>();
         A42PromocionDescripcion = "";
         A43PromocionBase = "";
         A70PromocionVigencia = "";
         P003M2_A42PromocionDescripcion = new string[] {""} ;
         P003M2_A41PromocionID = new int[1] ;
         P003M2_A43PromocionBase = new string[] {""} ;
         P003M2_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         P003M2_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         A46PromocionFechaFin = DateTime.MinValue;
         A45PromocionFechaInicio = DateTime.MinValue;
         AV27Option = "";
         P003M3_A43PromocionBase = new string[] {""} ;
         P003M3_A41PromocionID = new int[1] ;
         P003M3_A42PromocionDescripcion = new string[] {""} ;
         P003M3_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         P003M3_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         P003M4_A41PromocionID = new int[1] ;
         P003M4_A43PromocionBase = new string[] {""} ;
         P003M4_A42PromocionDescripcion = new string[] {""} ;
         P003M4_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         P003M4_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wplistapromocionesasesorgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003M2_A42PromocionDescripcion, P003M2_A41PromocionID, P003M2_A43PromocionBase, P003M2_A46PromocionFechaFin, P003M2_A45PromocionFechaInicio
               }
               , new Object[] {
               P003M3_A43PromocionBase, P003M3_A41PromocionID, P003M3_A42PromocionDescripcion, P003M3_A46PromocionFechaFin, P003M3_A45PromocionFechaInicio
               }
               , new Object[] {
               P003M4_A41PromocionID, P003M4_A43PromocionBase, P003M4_A42PromocionDescripcion, P003M4_A46PromocionFechaFin, P003M4_A45PromocionFechaInicio
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV25MaxItems ;
      private short AV24PageIndex ;
      private short AV23SkipItems ;
      private int AV46GXV1 ;
      private int AV10TFPromocionID ;
      private int AV11TFPromocionID_To ;
      private int AV49Wplistapromocionesasesords_2_tfpromocionid ;
      private int AV50Wplistapromocionesasesords_3_tfpromocionid_to ;
      private int A41PromocionID ;
      private int AV26InsertIndex ;
      private long AV32count ;
      private DateTime A46PromocionFechaFin ;
      private DateTime A45PromocionFechaInicio ;
      private bool returnInSub ;
      private bool BRK3M2 ;
      private bool BRK3M4 ;
      private string AV41OptionsJson ;
      private string AV42OptionsDescJson ;
      private string AV43OptionIndexesJson ;
      private string AV38DDOName ;
      private string AV39SearchTxtParms ;
      private string AV40SearchTxtTo ;
      private string AV22SearchTxt ;
      private string AV44FilterFullText ;
      private string AV12TFPromocionDescripcion ;
      private string AV13TFPromocionDescripcion_Sel ;
      private string AV14TFPromocionBase ;
      private string AV15TFPromocionBase_Sel ;
      private string AV20TFPromocionVigencia ;
      private string AV21TFPromocionVigencia_Sel ;
      private string AV48Wplistapromocionesasesords_1_filterfulltext ;
      private string AV51Wplistapromocionesasesords_4_tfpromociondescripcion ;
      private string AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel ;
      private string AV53Wplistapromocionesasesords_6_tfpromocionbase ;
      private string AV54Wplistapromocionesasesords_7_tfpromocionbase_sel ;
      private string AV55Wplistapromocionesasesords_8_tfpromocionvigencia ;
      private string AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel ;
      private string lV51Wplistapromocionesasesords_4_tfpromociondescripcion ;
      private string lV53Wplistapromocionesasesords_6_tfpromocionbase ;
      private string A42PromocionDescripcion ;
      private string A43PromocionBase ;
      private string A70PromocionVigencia ;
      private string AV27Option ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV28Options ;
      private GxSimpleCollection<string> AV30OptionsDesc ;
      private GxSimpleCollection<string> AV31OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV35GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GxSimpleCollection<int> AV45ListaPromociones ;
      private IDataStoreProvider pr_default ;
      private string[] P003M2_A42PromocionDescripcion ;
      private int[] P003M2_A41PromocionID ;
      private string[] P003M2_A43PromocionBase ;
      private DateTime[] P003M2_A46PromocionFechaFin ;
      private DateTime[] P003M2_A45PromocionFechaInicio ;
      private string[] P003M3_A43PromocionBase ;
      private int[] P003M3_A41PromocionID ;
      private string[] P003M3_A42PromocionDescripcion ;
      private DateTime[] P003M3_A46PromocionFechaFin ;
      private DateTime[] P003M3_A45PromocionFechaInicio ;
      private int[] P003M4_A41PromocionID ;
      private string[] P003M4_A43PromocionBase ;
      private string[] P003M4_A42PromocionDescripcion ;
      private DateTime[] P003M4_A46PromocionFechaFin ;
      private DateTime[] P003M4_A45PromocionFechaInicio ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wplistapromocionesasesorgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003M2( IGxContext context ,
                                             int A41PromocionID ,
                                             GxSimpleCollection<int> AV45ListaPromociones ,
                                             int AV49Wplistapromocionesasesords_2_tfpromocionid ,
                                             int AV50Wplistapromocionesasesords_3_tfpromocionid_to ,
                                             string AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel ,
                                             string AV51Wplistapromocionesasesords_4_tfpromociondescripcion ,
                                             string AV54Wplistapromocionesasesords_7_tfpromocionbase_sel ,
                                             string AV53Wplistapromocionesasesords_6_tfpromocionbase ,
                                             string A42PromocionDescripcion ,
                                             string A43PromocionBase ,
                                             string AV48Wplistapromocionesasesords_1_filterfulltext ,
                                             string A70PromocionVigencia ,
                                             string AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel ,
                                             string AV55Wplistapromocionesasesords_8_tfpromocionvigencia )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT `PromocionDescripcion`, `PromocionID`, `PromocionBase`, `PromocionFechaFin`, `PromocionFechaInicio` FROM `Promocion`";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV45ListaPromociones, "`PromocionID` IN (", ")")+")");
         if ( ! (0==AV49Wplistapromocionesasesords_2_tfpromocionid) )
         {
            AddWhere(sWhereString, "(`PromocionID` >= @AV49Wplistapromocionesasesords_2_tfpromocionid)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV50Wplistapromocionesasesords_3_tfpromocionid_to) )
         {
            AddWhere(sWhereString, "(`PromocionID` <= @AV50Wplistapromocionesasesords_3_tfpromocionid_to)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wplistapromocionesasesords_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` like @lV51Wplistapromocionesasesords_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` = @AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wplistapromocionesasesords_7_tfpromocionbase_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wplistapromocionesasesords_6_tfpromocionbase)) ) )
         {
            AddWhere(sWhereString, "(`PromocionBase` like @lV53Wplistapromocionesasesords_6_tfpromocionbase)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wplistapromocionesasesords_7_tfpromocionbase_sel)) && ! ( StringUtil.StrCmp(AV54Wplistapromocionesasesords_7_tfpromocionbase_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionBase` = @AV54Wplistapromocionesasesords_7_tfpromocionbase_sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wplistapromocionesasesords_7_tfpromocionbase_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionBase`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `PromocionDescripcion`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P003M3( IGxContext context ,
                                             int A41PromocionID ,
                                             GxSimpleCollection<int> AV45ListaPromociones ,
                                             int AV49Wplistapromocionesasesords_2_tfpromocionid ,
                                             int AV50Wplistapromocionesasesords_3_tfpromocionid_to ,
                                             string AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel ,
                                             string AV51Wplistapromocionesasesords_4_tfpromociondescripcion ,
                                             string AV54Wplistapromocionesasesords_7_tfpromocionbase_sel ,
                                             string AV53Wplistapromocionesasesords_6_tfpromocionbase ,
                                             string A42PromocionDescripcion ,
                                             string A43PromocionBase ,
                                             string AV48Wplistapromocionesasesords_1_filterfulltext ,
                                             string A70PromocionVigencia ,
                                             string AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel ,
                                             string AV55Wplistapromocionesasesords_8_tfpromocionvigencia )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT `PromocionBase`, `PromocionID`, `PromocionDescripcion`, `PromocionFechaFin`, `PromocionFechaInicio` FROM `Promocion`";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV45ListaPromociones, "`PromocionID` IN (", ")")+")");
         if ( ! (0==AV49Wplistapromocionesasesords_2_tfpromocionid) )
         {
            AddWhere(sWhereString, "(`PromocionID` >= @AV49Wplistapromocionesasesords_2_tfpromocionid)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV50Wplistapromocionesasesords_3_tfpromocionid_to) )
         {
            AddWhere(sWhereString, "(`PromocionID` <= @AV50Wplistapromocionesasesords_3_tfpromocionid_to)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wplistapromocionesasesords_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` like @lV51Wplistapromocionesasesords_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` = @AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wplistapromocionesasesords_7_tfpromocionbase_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wplistapromocionesasesords_6_tfpromocionbase)) ) )
         {
            AddWhere(sWhereString, "(`PromocionBase` like @lV53Wplistapromocionesasesords_6_tfpromocionbase)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wplistapromocionesasesords_7_tfpromocionbase_sel)) && ! ( StringUtil.StrCmp(AV54Wplistapromocionesasesords_7_tfpromocionbase_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionBase` = @AV54Wplistapromocionesasesords_7_tfpromocionbase_sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wplistapromocionesasesords_7_tfpromocionbase_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionBase`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `PromocionBase`";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P003M4( IGxContext context ,
                                             int A41PromocionID ,
                                             GxSimpleCollection<int> AV45ListaPromociones ,
                                             int AV49Wplistapromocionesasesords_2_tfpromocionid ,
                                             int AV50Wplistapromocionesasesords_3_tfpromocionid_to ,
                                             string AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel ,
                                             string AV51Wplistapromocionesasesords_4_tfpromociondescripcion ,
                                             string AV54Wplistapromocionesasesords_7_tfpromocionbase_sel ,
                                             string AV53Wplistapromocionesasesords_6_tfpromocionbase ,
                                             string A42PromocionDescripcion ,
                                             string A43PromocionBase ,
                                             string AV48Wplistapromocionesasesords_1_filterfulltext ,
                                             string A70PromocionVigencia ,
                                             string AV56Wplistapromocionesasesords_9_tfpromocionvigencia_sel ,
                                             string AV55Wplistapromocionesasesords_8_tfpromocionvigencia )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[6];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT `PromocionID`, `PromocionBase`, `PromocionDescripcion`, `PromocionFechaFin`, `PromocionFechaInicio` FROM `Promocion`";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV45ListaPromociones, "`PromocionID` IN (", ")")+")");
         if ( ! (0==AV49Wplistapromocionesasesords_2_tfpromocionid) )
         {
            AddWhere(sWhereString, "(`PromocionID` >= @AV49Wplistapromocionesasesords_2_tfpromocionid)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (0==AV50Wplistapromocionesasesords_3_tfpromocionid_to) )
         {
            AddWhere(sWhereString, "(`PromocionID` <= @AV50Wplistapromocionesasesords_3_tfpromocionid_to)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wplistapromocionesasesords_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` like @lV51Wplistapromocionesasesords_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` = @AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wplistapromocionesasesords_7_tfpromocionbase_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wplistapromocionesasesords_6_tfpromocionbase)) ) )
         {
            AddWhere(sWhereString, "(`PromocionBase` like @lV53Wplistapromocionesasesords_6_tfpromocionbase)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wplistapromocionesasesords_7_tfpromocionbase_sel)) && ! ( StringUtil.StrCmp(AV54Wplistapromocionesasesords_7_tfpromocionbase_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionBase` = @AV54Wplistapromocionesasesords_7_tfpromocionbase_sel)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wplistapromocionesasesords_7_tfpromocionbase_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionBase`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `PromocionID`";
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
                     return conditional_P003M2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
               case 1 :
                     return conditional_P003M3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
               case 2 :
                     return conditional_P003M4(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
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
          Object[] prmP003M2;
          prmP003M2 = new Object[] {
          new ParDef("@AV49Wplistapromocionesasesords_2_tfpromocionid",GXType.Int32,9,0) ,
          new ParDef("@AV50Wplistapromocionesasesords_3_tfpromocionid_to",GXType.Int32,9,0) ,
          new ParDef("@lV51Wplistapromocionesasesords_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV53Wplistapromocionesasesords_6_tfpromocionbase",GXType.Char,700,0) ,
          new ParDef("@AV54Wplistapromocionesasesords_7_tfpromocionbase_sel",GXType.Char,700,0)
          };
          Object[] prmP003M3;
          prmP003M3 = new Object[] {
          new ParDef("@AV49Wplistapromocionesasesords_2_tfpromocionid",GXType.Int32,9,0) ,
          new ParDef("@AV50Wplistapromocionesasesords_3_tfpromocionid_to",GXType.Int32,9,0) ,
          new ParDef("@lV51Wplistapromocionesasesords_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV53Wplistapromocionesasesords_6_tfpromocionbase",GXType.Char,700,0) ,
          new ParDef("@AV54Wplistapromocionesasesords_7_tfpromocionbase_sel",GXType.Char,700,0)
          };
          Object[] prmP003M4;
          prmP003M4 = new Object[] {
          new ParDef("@AV49Wplistapromocionesasesords_2_tfpromocionid",GXType.Int32,9,0) ,
          new ParDef("@AV50Wplistapromocionesasesords_3_tfpromocionid_to",GXType.Int32,9,0) ,
          new ParDef("@lV51Wplistapromocionesasesords_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV52Wplistapromocionesasesords_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV53Wplistapromocionesasesords_6_tfpromocionbase",GXType.Char,700,0) ,
          new ParDef("@AV54Wplistapromocionesasesords_7_tfpromocionbase_sel",GXType.Char,700,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003M2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003M3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003M3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003M4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003M4,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                return;
       }
    }

 }

}
