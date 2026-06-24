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
   public class promocionwwgetfilterdata : GXProcedure
   {
      public promocionwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public promocionwwgetfilterdata( IGxContext context )
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
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_PROMOCIONBASE") == 0 )
         {
            /* Execute user subroutine: 'LOADPROMOCIONBASEOPTIONS' */
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
         if ( StringUtil.StrCmp(AV31Session.Get("PromocionWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "PromocionWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("PromocionWWGridState"), null, "", "");
         }
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV43GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV42FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROMOCIONID") == 0 )
            {
               AV10TFPromocionID = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV11TFPromocionID_To = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION") == 0 )
            {
               AV12TFPromocionDescripcion = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROMOCIONDESCRIPCION_SEL") == 0 )
            {
               AV13TFPromocionDescripcion_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROMOCIONBASE") == 0 )
            {
               AV14TFPromocionBase = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROMOCIONBASE_SEL") == 0 )
            {
               AV15TFPromocionBase_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROMOCIONFECHAINICIO") == 0 )
            {
               AV16TFPromocionFechaInicio = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV17TFPromocionFechaInicio_To = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPROMOCIONFECHAFIN") == 0 )
            {
               AV18TFPromocionFechaFin = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV19TFPromocionFechaFin_To = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV43GXV1 = (int)(AV43GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROMOCIONDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV12TFPromocionDescripcion = AV20SearchTxt;
         AV13TFPromocionDescripcion_Sel = "";
         AV45Promocionwwds_1_filterfulltext = AV42FilterFullText;
         AV46Promocionwwds_2_tfpromocionid = AV10TFPromocionID;
         AV47Promocionwwds_3_tfpromocionid_to = AV11TFPromocionID_To;
         AV48Promocionwwds_4_tfpromociondescripcion = AV12TFPromocionDescripcion;
         AV49Promocionwwds_5_tfpromociondescripcion_sel = AV13TFPromocionDescripcion_Sel;
         AV50Promocionwwds_6_tfpromocionbase = AV14TFPromocionBase;
         AV51Promocionwwds_7_tfpromocionbase_sel = AV15TFPromocionBase_Sel;
         AV52Promocionwwds_8_tfpromocionfechainicio = AV16TFPromocionFechaInicio;
         AV53Promocionwwds_9_tfpromocionfechainicio_to = AV17TFPromocionFechaInicio_To;
         AV54Promocionwwds_10_tfpromocionfechafin = AV18TFPromocionFechaFin;
         AV55Promocionwwds_11_tfpromocionfechafin_to = AV19TFPromocionFechaFin_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV45Promocionwwds_1_filterfulltext ,
                                              AV46Promocionwwds_2_tfpromocionid ,
                                              AV47Promocionwwds_3_tfpromocionid_to ,
                                              AV49Promocionwwds_5_tfpromociondescripcion_sel ,
                                              AV48Promocionwwds_4_tfpromociondescripcion ,
                                              AV51Promocionwwds_7_tfpromocionbase_sel ,
                                              AV50Promocionwwds_6_tfpromocionbase ,
                                              AV52Promocionwwds_8_tfpromocionfechainicio ,
                                              AV53Promocionwwds_9_tfpromocionfechainicio_to ,
                                              AV54Promocionwwds_10_tfpromocionfechafin ,
                                              AV55Promocionwwds_11_tfpromocionfechafin_to ,
                                              A41PromocionID ,
                                              A42PromocionDescripcion ,
                                              A43PromocionBase ,
                                              A45PromocionFechaInicio ,
                                              A46PromocionFechaFin } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV45Promocionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Promocionwwds_1_filterfulltext), "%", "");
         lV45Promocionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Promocionwwds_1_filterfulltext), "%", "");
         lV45Promocionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Promocionwwds_1_filterfulltext), "%", "");
         lV48Promocionwwds_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV48Promocionwwds_4_tfpromociondescripcion), "%", "");
         lV50Promocionwwds_6_tfpromocionbase = StringUtil.Concat( StringUtil.RTrim( AV50Promocionwwds_6_tfpromocionbase), "%", "");
         /* Using cursor P002P2 */
         pr_default.execute(0, new Object[] {lV45Promocionwwds_1_filterfulltext, lV45Promocionwwds_1_filterfulltext, lV45Promocionwwds_1_filterfulltext, AV46Promocionwwds_2_tfpromocionid, AV47Promocionwwds_3_tfpromocionid_to, lV48Promocionwwds_4_tfpromociondescripcion, AV49Promocionwwds_5_tfpromociondescripcion_sel, lV50Promocionwwds_6_tfpromocionbase, AV51Promocionwwds_7_tfpromocionbase_sel, AV52Promocionwwds_8_tfpromocionfechainicio, AV53Promocionwwds_9_tfpromocionfechainicio_to, AV54Promocionwwds_10_tfpromocionfechafin, AV55Promocionwwds_11_tfpromocionfechafin_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2P2 = false;
            A42PromocionDescripcion = P002P2_A42PromocionDescripcion[0];
            A46PromocionFechaFin = P002P2_A46PromocionFechaFin[0];
            A45PromocionFechaInicio = P002P2_A45PromocionFechaInicio[0];
            A41PromocionID = P002P2_A41PromocionID[0];
            A43PromocionBase = P002P2_A43PromocionBase[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002P2_A42PromocionDescripcion[0], A42PromocionDescripcion) == 0 ) )
            {
               BRK2P2 = false;
               A41PromocionID = P002P2_A41PromocionID[0];
               AV30count = (long)(AV30count+1);
               BRK2P2 = true;
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
            if ( ! BRK2P2 )
            {
               BRK2P2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROMOCIONBASEOPTIONS' Routine */
         returnInSub = false;
         AV14TFPromocionBase = AV20SearchTxt;
         AV15TFPromocionBase_Sel = "";
         AV45Promocionwwds_1_filterfulltext = AV42FilterFullText;
         AV46Promocionwwds_2_tfpromocionid = AV10TFPromocionID;
         AV47Promocionwwds_3_tfpromocionid_to = AV11TFPromocionID_To;
         AV48Promocionwwds_4_tfpromociondescripcion = AV12TFPromocionDescripcion;
         AV49Promocionwwds_5_tfpromociondescripcion_sel = AV13TFPromocionDescripcion_Sel;
         AV50Promocionwwds_6_tfpromocionbase = AV14TFPromocionBase;
         AV51Promocionwwds_7_tfpromocionbase_sel = AV15TFPromocionBase_Sel;
         AV52Promocionwwds_8_tfpromocionfechainicio = AV16TFPromocionFechaInicio;
         AV53Promocionwwds_9_tfpromocionfechainicio_to = AV17TFPromocionFechaInicio_To;
         AV54Promocionwwds_10_tfpromocionfechafin = AV18TFPromocionFechaFin;
         AV55Promocionwwds_11_tfpromocionfechafin_to = AV19TFPromocionFechaFin_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV45Promocionwwds_1_filterfulltext ,
                                              AV46Promocionwwds_2_tfpromocionid ,
                                              AV47Promocionwwds_3_tfpromocionid_to ,
                                              AV49Promocionwwds_5_tfpromociondescripcion_sel ,
                                              AV48Promocionwwds_4_tfpromociondescripcion ,
                                              AV51Promocionwwds_7_tfpromocionbase_sel ,
                                              AV50Promocionwwds_6_tfpromocionbase ,
                                              AV52Promocionwwds_8_tfpromocionfechainicio ,
                                              AV53Promocionwwds_9_tfpromocionfechainicio_to ,
                                              AV54Promocionwwds_10_tfpromocionfechafin ,
                                              AV55Promocionwwds_11_tfpromocionfechafin_to ,
                                              A41PromocionID ,
                                              A42PromocionDescripcion ,
                                              A43PromocionBase ,
                                              A45PromocionFechaInicio ,
                                              A46PromocionFechaFin } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV45Promocionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Promocionwwds_1_filterfulltext), "%", "");
         lV45Promocionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Promocionwwds_1_filterfulltext), "%", "");
         lV45Promocionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Promocionwwds_1_filterfulltext), "%", "");
         lV48Promocionwwds_4_tfpromociondescripcion = StringUtil.Concat( StringUtil.RTrim( AV48Promocionwwds_4_tfpromociondescripcion), "%", "");
         lV50Promocionwwds_6_tfpromocionbase = StringUtil.Concat( StringUtil.RTrim( AV50Promocionwwds_6_tfpromocionbase), "%", "");
         /* Using cursor P002P3 */
         pr_default.execute(1, new Object[] {lV45Promocionwwds_1_filterfulltext, lV45Promocionwwds_1_filterfulltext, lV45Promocionwwds_1_filterfulltext, AV46Promocionwwds_2_tfpromocionid, AV47Promocionwwds_3_tfpromocionid_to, lV48Promocionwwds_4_tfpromociondescripcion, AV49Promocionwwds_5_tfpromociondescripcion_sel, lV50Promocionwwds_6_tfpromocionbase, AV51Promocionwwds_7_tfpromocionbase_sel, AV52Promocionwwds_8_tfpromocionfechainicio, AV53Promocionwwds_9_tfpromocionfechainicio_to, AV54Promocionwwds_10_tfpromocionfechafin, AV55Promocionwwds_11_tfpromocionfechafin_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2P4 = false;
            A43PromocionBase = P002P3_A43PromocionBase[0];
            A46PromocionFechaFin = P002P3_A46PromocionFechaFin[0];
            A45PromocionFechaInicio = P002P3_A45PromocionFechaInicio[0];
            A41PromocionID = P002P3_A41PromocionID[0];
            A42PromocionDescripcion = P002P3_A42PromocionDescripcion[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002P3_A43PromocionBase[0], A43PromocionBase) == 0 ) )
            {
               BRK2P4 = false;
               A41PromocionID = P002P3_A41PromocionID[0];
               AV30count = (long)(AV30count+1);
               BRK2P4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV21SkipItems) )
            {
               AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A43PromocionBase)) ? "<#Empty#>" : A43PromocionBase);
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
            if ( ! BRK2P4 )
            {
               BRK2P4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV14TFPromocionBase = "";
         AV15TFPromocionBase_Sel = "";
         AV16TFPromocionFechaInicio = DateTime.MinValue;
         AV17TFPromocionFechaInicio_To = DateTime.MinValue;
         AV18TFPromocionFechaFin = DateTime.MinValue;
         AV19TFPromocionFechaFin_To = DateTime.MinValue;
         AV45Promocionwwds_1_filterfulltext = "";
         AV48Promocionwwds_4_tfpromociondescripcion = "";
         AV49Promocionwwds_5_tfpromociondescripcion_sel = "";
         AV50Promocionwwds_6_tfpromocionbase = "";
         AV51Promocionwwds_7_tfpromocionbase_sel = "";
         AV52Promocionwwds_8_tfpromocionfechainicio = DateTime.MinValue;
         AV53Promocionwwds_9_tfpromocionfechainicio_to = DateTime.MinValue;
         AV54Promocionwwds_10_tfpromocionfechafin = DateTime.MinValue;
         AV55Promocionwwds_11_tfpromocionfechafin_to = DateTime.MinValue;
         lV45Promocionwwds_1_filterfulltext = "";
         lV48Promocionwwds_4_tfpromociondescripcion = "";
         lV50Promocionwwds_6_tfpromocionbase = "";
         A42PromocionDescripcion = "";
         A43PromocionBase = "";
         A45PromocionFechaInicio = DateTime.MinValue;
         A46PromocionFechaFin = DateTime.MinValue;
         P002P2_A42PromocionDescripcion = new string[] {""} ;
         P002P2_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         P002P2_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         P002P2_A41PromocionID = new int[1] ;
         P002P2_A43PromocionBase = new string[] {""} ;
         AV25Option = "";
         P002P3_A43PromocionBase = new string[] {""} ;
         P002P3_A46PromocionFechaFin = new DateTime[] {DateTime.MinValue} ;
         P002P3_A45PromocionFechaInicio = new DateTime[] {DateTime.MinValue} ;
         P002P3_A41PromocionID = new int[1] ;
         P002P3_A42PromocionDescripcion = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.promocionwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002P2_A42PromocionDescripcion, P002P2_A46PromocionFechaFin, P002P2_A45PromocionFechaInicio, P002P2_A41PromocionID, P002P2_A43PromocionBase
               }
               , new Object[] {
               P002P3_A43PromocionBase, P002P3_A46PromocionFechaFin, P002P3_A45PromocionFechaInicio, P002P3_A41PromocionID, P002P3_A42PromocionDescripcion
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV23MaxItems ;
      private short AV22PageIndex ;
      private short AV21SkipItems ;
      private int AV43GXV1 ;
      private int AV10TFPromocionID ;
      private int AV11TFPromocionID_To ;
      private int AV46Promocionwwds_2_tfpromocionid ;
      private int AV47Promocionwwds_3_tfpromocionid_to ;
      private int A41PromocionID ;
      private long AV30count ;
      private DateTime AV16TFPromocionFechaInicio ;
      private DateTime AV17TFPromocionFechaInicio_To ;
      private DateTime AV18TFPromocionFechaFin ;
      private DateTime AV19TFPromocionFechaFin_To ;
      private DateTime AV52Promocionwwds_8_tfpromocionfechainicio ;
      private DateTime AV53Promocionwwds_9_tfpromocionfechainicio_to ;
      private DateTime AV54Promocionwwds_10_tfpromocionfechafin ;
      private DateTime AV55Promocionwwds_11_tfpromocionfechafin_to ;
      private DateTime A45PromocionFechaInicio ;
      private DateTime A46PromocionFechaFin ;
      private bool returnInSub ;
      private bool BRK2P2 ;
      private bool BRK2P4 ;
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
      private string AV14TFPromocionBase ;
      private string AV15TFPromocionBase_Sel ;
      private string AV45Promocionwwds_1_filterfulltext ;
      private string AV48Promocionwwds_4_tfpromociondescripcion ;
      private string AV49Promocionwwds_5_tfpromociondescripcion_sel ;
      private string AV50Promocionwwds_6_tfpromocionbase ;
      private string AV51Promocionwwds_7_tfpromocionbase_sel ;
      private string lV45Promocionwwds_1_filterfulltext ;
      private string lV48Promocionwwds_4_tfpromociondescripcion ;
      private string lV50Promocionwwds_6_tfpromocionbase ;
      private string A42PromocionDescripcion ;
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
      private string[] P002P2_A42PromocionDescripcion ;
      private DateTime[] P002P2_A46PromocionFechaFin ;
      private DateTime[] P002P2_A45PromocionFechaInicio ;
      private int[] P002P2_A41PromocionID ;
      private string[] P002P2_A43PromocionBase ;
      private string[] P002P3_A43PromocionBase ;
      private DateTime[] P002P3_A46PromocionFechaFin ;
      private DateTime[] P002P3_A45PromocionFechaInicio ;
      private int[] P002P3_A41PromocionID ;
      private string[] P002P3_A42PromocionDescripcion ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class promocionwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002P2( IGxContext context ,
                                             string AV45Promocionwwds_1_filterfulltext ,
                                             int AV46Promocionwwds_2_tfpromocionid ,
                                             int AV47Promocionwwds_3_tfpromocionid_to ,
                                             string AV49Promocionwwds_5_tfpromociondescripcion_sel ,
                                             string AV48Promocionwwds_4_tfpromociondescripcion ,
                                             string AV51Promocionwwds_7_tfpromocionbase_sel ,
                                             string AV50Promocionwwds_6_tfpromocionbase ,
                                             DateTime AV52Promocionwwds_8_tfpromocionfechainicio ,
                                             DateTime AV53Promocionwwds_9_tfpromocionfechainicio_to ,
                                             DateTime AV54Promocionwwds_10_tfpromocionfechafin ,
                                             DateTime AV55Promocionwwds_11_tfpromocionfechafin_to ,
                                             int A41PromocionID ,
                                             string A42PromocionDescripcion ,
                                             string A43PromocionBase ,
                                             DateTime A45PromocionFechaInicio ,
                                             DateTime A46PromocionFechaFin )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[13];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT `PromocionDescripcion`, `PromocionFechaFin`, `PromocionFechaInicio`, `PromocionID`, `PromocionBase` FROM `Promocion`";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Promocionwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( (LPAD(REPLACE(FORMAT(`PromocionID`,0), ',', ''), 9, ' ')) like CONCAT('%', @lV45Promocionwwds_1_filterfulltext)) or ( `PromocionDescripcion` like CONCAT('%', @lV45Promocionwwds_1_filterfulltext)) or ( `PromocionBase` like CONCAT('%', @lV45Promocionwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV46Promocionwwds_2_tfpromocionid) )
         {
            AddWhere(sWhereString, "(`PromocionID` >= @AV46Promocionwwds_2_tfpromocionid)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV47Promocionwwds_3_tfpromocionid_to) )
         {
            AddWhere(sWhereString, "(`PromocionID` <= @AV47Promocionwwds_3_tfpromocionid_to)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Promocionwwds_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Promocionwwds_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` like @lV48Promocionwwds_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Promocionwwds_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV49Promocionwwds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` = @AV49Promocionwwds_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV49Promocionwwds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Promocionwwds_7_tfpromocionbase_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Promocionwwds_6_tfpromocionbase)) ) )
         {
            AddWhere(sWhereString, "(`PromocionBase` like @lV50Promocionwwds_6_tfpromocionbase)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Promocionwwds_7_tfpromocionbase_sel)) && ! ( StringUtil.StrCmp(AV51Promocionwwds_7_tfpromocionbase_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionBase` = @AV51Promocionwwds_7_tfpromocionbase_sel)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV51Promocionwwds_7_tfpromocionbase_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionBase`))=0))");
         }
         if ( ! (DateTime.MinValue==AV52Promocionwwds_8_tfpromocionfechainicio) )
         {
            AddWhere(sWhereString, "(`PromocionFechaInicio` >= @AV52Promocionwwds_8_tfpromocionfechainicio)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV53Promocionwwds_9_tfpromocionfechainicio_to) )
         {
            AddWhere(sWhereString, "(`PromocionFechaInicio` <= @AV53Promocionwwds_9_tfpromocionfechainicio_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV54Promocionwwds_10_tfpromocionfechafin) )
         {
            AddWhere(sWhereString, "(`PromocionFechaFin` >= @AV54Promocionwwds_10_tfpromocionfechafin)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV55Promocionwwds_11_tfpromocionfechafin_to) )
         {
            AddWhere(sWhereString, "(`PromocionFechaFin` <= @AV55Promocionwwds_11_tfpromocionfechafin_to)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `PromocionDescripcion`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002P3( IGxContext context ,
                                             string AV45Promocionwwds_1_filterfulltext ,
                                             int AV46Promocionwwds_2_tfpromocionid ,
                                             int AV47Promocionwwds_3_tfpromocionid_to ,
                                             string AV49Promocionwwds_5_tfpromociondescripcion_sel ,
                                             string AV48Promocionwwds_4_tfpromociondescripcion ,
                                             string AV51Promocionwwds_7_tfpromocionbase_sel ,
                                             string AV50Promocionwwds_6_tfpromocionbase ,
                                             DateTime AV52Promocionwwds_8_tfpromocionfechainicio ,
                                             DateTime AV53Promocionwwds_9_tfpromocionfechainicio_to ,
                                             DateTime AV54Promocionwwds_10_tfpromocionfechafin ,
                                             DateTime AV55Promocionwwds_11_tfpromocionfechafin_to ,
                                             int A41PromocionID ,
                                             string A42PromocionDescripcion ,
                                             string A43PromocionBase ,
                                             DateTime A45PromocionFechaInicio ,
                                             DateTime A46PromocionFechaFin )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[13];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT `PromocionBase`, `PromocionFechaFin`, `PromocionFechaInicio`, `PromocionID`, `PromocionDescripcion` FROM `Promocion`";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Promocionwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( (LPAD(REPLACE(FORMAT(`PromocionID`,0), ',', ''), 9, ' ')) like CONCAT('%', @lV45Promocionwwds_1_filterfulltext)) or ( `PromocionDescripcion` like CONCAT('%', @lV45Promocionwwds_1_filterfulltext)) or ( `PromocionBase` like CONCAT('%', @lV45Promocionwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV46Promocionwwds_2_tfpromocionid) )
         {
            AddWhere(sWhereString, "(`PromocionID` >= @AV46Promocionwwds_2_tfpromocionid)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV47Promocionwwds_3_tfpromocionid_to) )
         {
            AddWhere(sWhereString, "(`PromocionID` <= @AV47Promocionwwds_3_tfpromocionid_to)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Promocionwwds_5_tfpromociondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Promocionwwds_4_tfpromociondescripcion)) ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` like @lV48Promocionwwds_4_tfpromociondescripcion)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Promocionwwds_5_tfpromociondescripcion_sel)) && ! ( StringUtil.StrCmp(AV49Promocionwwds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionDescripcion` = @AV49Promocionwwds_5_tfpromociondescripcion_sel)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV49Promocionwwds_5_tfpromociondescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Promocionwwds_7_tfpromocionbase_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Promocionwwds_6_tfpromocionbase)) ) )
         {
            AddWhere(sWhereString, "(`PromocionBase` like @lV50Promocionwwds_6_tfpromocionbase)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Promocionwwds_7_tfpromocionbase_sel)) && ! ( StringUtil.StrCmp(AV51Promocionwwds_7_tfpromocionbase_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`PromocionBase` = @AV51Promocionwwds_7_tfpromocionbase_sel)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV51Promocionwwds_7_tfpromocionbase_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PromocionBase`))=0))");
         }
         if ( ! (DateTime.MinValue==AV52Promocionwwds_8_tfpromocionfechainicio) )
         {
            AddWhere(sWhereString, "(`PromocionFechaInicio` >= @AV52Promocionwwds_8_tfpromocionfechainicio)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV53Promocionwwds_9_tfpromocionfechainicio_to) )
         {
            AddWhere(sWhereString, "(`PromocionFechaInicio` <= @AV53Promocionwwds_9_tfpromocionfechainicio_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV54Promocionwwds_10_tfpromocionfechafin) )
         {
            AddWhere(sWhereString, "(`PromocionFechaFin` >= @AV54Promocionwwds_10_tfpromocionfechafin)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV55Promocionwwds_11_tfpromocionfechafin_to) )
         {
            AddWhere(sWhereString, "(`PromocionFechaFin` <= @AV55Promocionwwds_11_tfpromocionfechafin_to)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `PromocionBase`";
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
                     return conditional_P002P2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] );
               case 1 :
                     return conditional_P002P3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] );
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
          Object[] prmP002P2;
          prmP002P2 = new Object[] {
          new ParDef("@lV45Promocionwwds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV45Promocionwwds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV45Promocionwwds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV46Promocionwwds_2_tfpromocionid",GXType.Int32,9,0) ,
          new ParDef("@AV47Promocionwwds_3_tfpromocionid_to",GXType.Int32,9,0) ,
          new ParDef("@lV48Promocionwwds_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV49Promocionwwds_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV50Promocionwwds_6_tfpromocionbase",GXType.Char,700,0) ,
          new ParDef("@AV51Promocionwwds_7_tfpromocionbase_sel",GXType.Char,700,0) ,
          new ParDef("@AV52Promocionwwds_8_tfpromocionfechainicio",GXType.Date,8,0) ,
          new ParDef("@AV53Promocionwwds_9_tfpromocionfechainicio_to",GXType.Date,8,0) ,
          new ParDef("@AV54Promocionwwds_10_tfpromocionfechafin",GXType.Date,8,0) ,
          new ParDef("@AV55Promocionwwds_11_tfpromocionfechafin_to",GXType.Date,8,0)
          };
          Object[] prmP002P3;
          prmP002P3 = new Object[] {
          new ParDef("@lV45Promocionwwds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV45Promocionwwds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV45Promocionwwds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@AV46Promocionwwds_2_tfpromocionid",GXType.Int32,9,0) ,
          new ParDef("@AV47Promocionwwds_3_tfpromocionid_to",GXType.Int32,9,0) ,
          new ParDef("@lV48Promocionwwds_4_tfpromociondescripcion",GXType.Char,80,0) ,
          new ParDef("@AV49Promocionwwds_5_tfpromociondescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV50Promocionwwds_6_tfpromocionbase",GXType.Char,700,0) ,
          new ParDef("@AV51Promocionwwds_7_tfpromocionbase_sel",GXType.Char,700,0) ,
          new ParDef("@AV52Promocionwwds_8_tfpromocionfechainicio",GXType.Date,8,0) ,
          new ParDef("@AV53Promocionwwds_9_tfpromocionfechainicio_to",GXType.Date,8,0) ,
          new ParDef("@AV54Promocionwwds_10_tfpromocionfechafin",GXType.Date,8,0) ,
          new ParDef("@AV55Promocionwwds_11_tfpromocionfechafin_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002P2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002P3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002P3,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
