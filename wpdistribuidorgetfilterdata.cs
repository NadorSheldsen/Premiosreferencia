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
   public class wpdistribuidorgetfilterdata : GXProcedure
   {
      public wpdistribuidorgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpdistribuidorgetfilterdata( IGxContext context )
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
         this.AV32DDOName = aP0_DDOName;
         this.AV33SearchTxtParms = aP1_SearchTxtParms;
         this.AV34SearchTxtTo = aP2_SearchTxtTo;
         this.AV35OptionsJson = "" ;
         this.AV36OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV35OptionsJson;
         aP4_OptionsDescJson=this.AV36OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV37OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV32DDOName = aP0_DDOName;
         this.AV33SearchTxtParms = aP1_SearchTxtParms;
         this.AV34SearchTxtTo = aP2_SearchTxtTo;
         this.AV35OptionsJson = "" ;
         this.AV36OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV35OptionsJson;
         aP4_OptionsDescJson=this.AV36OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV22Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV19MaxItems = 10;
         AV18PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV33SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV33SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV16SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV33SearchTxtParms)) ? "" : StringUtil.Substring( AV33SearchTxtParms, 3, -1));
         AV17SkipItems = (short)(AV18PageIndex*AV19MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_DISTRIBUIDORDESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADDISTRIBUIDORDESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_DISTRIBUIDORRFC") == 0 )
         {
            /* Execute user subroutine: 'LOADDISTRIBUIDORRFCOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV35OptionsJson = AV22Options.ToJSonString(false);
         AV36OptionsDescJson = AV24OptionsDesc.ToJSonString(false);
         AV37OptionIndexesJson = AV25OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get("WPDistribuidorGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPDistribuidorGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("WPDistribuidorGridState"), null, "", "");
         }
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV39GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV38FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFDISTRIBUIDORDESCRIPCION") == 0 )
            {
               AV12TFDistribuidorDescripcion = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFDISTRIBUIDORDESCRIPCION_SEL") == 0 )
            {
               AV13TFDistribuidorDescripcion_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFDISTRIBUIDORRFC") == 0 )
            {
               AV14TFDistribuidorRFC = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFDISTRIBUIDORRFC_SEL") == 0 )
            {
               AV15TFDistribuidorRFC_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV39GXV1 = (int)(AV39GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADDISTRIBUIDORDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV12TFDistribuidorDescripcion = AV16SearchTxt;
         AV13TFDistribuidorDescripcion_Sel = "";
         AV41Wpdistribuidords_1_filterfulltext = AV38FilterFullText;
         AV42Wpdistribuidords_2_tfdistribuidordescripcion = AV12TFDistribuidorDescripcion;
         AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel = AV13TFDistribuidorDescripcion_Sel;
         AV44Wpdistribuidords_4_tfdistribuidorrfc = AV14TFDistribuidorRFC;
         AV45Wpdistribuidords_5_tfdistribuidorrfc_sel = AV15TFDistribuidorRFC_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV41Wpdistribuidords_1_filterfulltext ,
                                              AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel ,
                                              AV42Wpdistribuidords_2_tfdistribuidordescripcion ,
                                              AV45Wpdistribuidords_5_tfdistribuidorrfc_sel ,
                                              AV44Wpdistribuidords_4_tfdistribuidorrfc ,
                                              A11DistribuidorDescripcion ,
                                              A12DistribuidorRFC } ,
                                              new int[]{
                                              }
         });
         lV41Wpdistribuidords_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Wpdistribuidords_1_filterfulltext), "%", "");
         lV41Wpdistribuidords_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Wpdistribuidords_1_filterfulltext), "%", "");
         lV42Wpdistribuidords_2_tfdistribuidordescripcion = StringUtil.Concat( StringUtil.RTrim( AV42Wpdistribuidords_2_tfdistribuidordescripcion), "%", "");
         lV44Wpdistribuidords_4_tfdistribuidorrfc = StringUtil.PadR( StringUtil.RTrim( AV44Wpdistribuidords_4_tfdistribuidorrfc), 13, "%");
         /* Using cursor P002F2 */
         pr_default.execute(0, new Object[] {lV41Wpdistribuidords_1_filterfulltext, lV41Wpdistribuidords_1_filterfulltext, lV42Wpdistribuidords_2_tfdistribuidordescripcion, AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel, lV44Wpdistribuidords_4_tfdistribuidorrfc, AV45Wpdistribuidords_5_tfdistribuidorrfc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2F2 = false;
            A11DistribuidorDescripcion = P002F2_A11DistribuidorDescripcion[0];
            A12DistribuidorRFC = P002F2_A12DistribuidorRFC[0];
            A10DistribuidorID = P002F2_A10DistribuidorID[0];
            AV26count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002F2_A11DistribuidorDescripcion[0], A11DistribuidorDescripcion) == 0 ) )
            {
               BRK2F2 = false;
               A10DistribuidorID = P002F2_A10DistribuidorID[0];
               AV26count = (long)(AV26count+1);
               BRK2F2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A11DistribuidorDescripcion)) ? "<#Empty#>" : A11DistribuidorDescripcion);
               AV22Options.Add(AV21Option, 0);
               AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV22Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV17SkipItems = (short)(AV17SkipItems-1);
            }
            if ( ! BRK2F2 )
            {
               BRK2F2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADDISTRIBUIDORRFCOPTIONS' Routine */
         returnInSub = false;
         AV14TFDistribuidorRFC = AV16SearchTxt;
         AV15TFDistribuidorRFC_Sel = "";
         AV41Wpdistribuidords_1_filterfulltext = AV38FilterFullText;
         AV42Wpdistribuidords_2_tfdistribuidordescripcion = AV12TFDistribuidorDescripcion;
         AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel = AV13TFDistribuidorDescripcion_Sel;
         AV44Wpdistribuidords_4_tfdistribuidorrfc = AV14TFDistribuidorRFC;
         AV45Wpdistribuidords_5_tfdistribuidorrfc_sel = AV15TFDistribuidorRFC_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV41Wpdistribuidords_1_filterfulltext ,
                                              AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel ,
                                              AV42Wpdistribuidords_2_tfdistribuidordescripcion ,
                                              AV45Wpdistribuidords_5_tfdistribuidorrfc_sel ,
                                              AV44Wpdistribuidords_4_tfdistribuidorrfc ,
                                              A11DistribuidorDescripcion ,
                                              A12DistribuidorRFC } ,
                                              new int[]{
                                              }
         });
         lV41Wpdistribuidords_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Wpdistribuidords_1_filterfulltext), "%", "");
         lV41Wpdistribuidords_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV41Wpdistribuidords_1_filterfulltext), "%", "");
         lV42Wpdistribuidords_2_tfdistribuidordescripcion = StringUtil.Concat( StringUtil.RTrim( AV42Wpdistribuidords_2_tfdistribuidordescripcion), "%", "");
         lV44Wpdistribuidords_4_tfdistribuidorrfc = StringUtil.PadR( StringUtil.RTrim( AV44Wpdistribuidords_4_tfdistribuidorrfc), 13, "%");
         /* Using cursor P002F3 */
         pr_default.execute(1, new Object[] {lV41Wpdistribuidords_1_filterfulltext, lV41Wpdistribuidords_1_filterfulltext, lV42Wpdistribuidords_2_tfdistribuidordescripcion, AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel, lV44Wpdistribuidords_4_tfdistribuidorrfc, AV45Wpdistribuidords_5_tfdistribuidorrfc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2F4 = false;
            A12DistribuidorRFC = P002F3_A12DistribuidorRFC[0];
            A11DistribuidorDescripcion = P002F3_A11DistribuidorDescripcion[0];
            A10DistribuidorID = P002F3_A10DistribuidorID[0];
            AV26count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002F3_A12DistribuidorRFC[0], A12DistribuidorRFC) == 0 ) )
            {
               BRK2F4 = false;
               A10DistribuidorID = P002F3_A10DistribuidorID[0];
               AV26count = (long)(AV26count+1);
               BRK2F4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A12DistribuidorRFC)) ? "<#Empty#>" : A12DistribuidorRFC);
               AV22Options.Add(AV21Option, 0);
               AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV22Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV17SkipItems = (short)(AV17SkipItems-1);
            }
            if ( ! BRK2F4 )
            {
               BRK2F4 = true;
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
         AV35OptionsJson = "";
         AV36OptionsDescJson = "";
         AV37OptionIndexesJson = "";
         AV22Options = new GxSimpleCollection<string>();
         AV24OptionsDesc = new GxSimpleCollection<string>();
         AV25OptionIndexes = new GxSimpleCollection<string>();
         AV16SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27Session = context.GetSession();
         AV29GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV30GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV38FilterFullText = "";
         AV12TFDistribuidorDescripcion = "";
         AV13TFDistribuidorDescripcion_Sel = "";
         AV14TFDistribuidorRFC = "";
         AV15TFDistribuidorRFC_Sel = "";
         AV41Wpdistribuidords_1_filterfulltext = "";
         AV42Wpdistribuidords_2_tfdistribuidordescripcion = "";
         AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel = "";
         AV44Wpdistribuidords_4_tfdistribuidorrfc = "";
         AV45Wpdistribuidords_5_tfdistribuidorrfc_sel = "";
         lV41Wpdistribuidords_1_filterfulltext = "";
         lV42Wpdistribuidords_2_tfdistribuidordescripcion = "";
         lV44Wpdistribuidords_4_tfdistribuidorrfc = "";
         A11DistribuidorDescripcion = "";
         A12DistribuidorRFC = "";
         P002F2_A11DistribuidorDescripcion = new string[] {""} ;
         P002F2_A12DistribuidorRFC = new string[] {""} ;
         P002F2_A10DistribuidorID = new int[1] ;
         AV21Option = "";
         P002F3_A12DistribuidorRFC = new string[] {""} ;
         P002F3_A11DistribuidorDescripcion = new string[] {""} ;
         P002F3_A10DistribuidorID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpdistribuidorgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002F2_A11DistribuidorDescripcion, P002F2_A12DistribuidorRFC, P002F2_A10DistribuidorID
               }
               , new Object[] {
               P002F3_A12DistribuidorRFC, P002F3_A11DistribuidorDescripcion, P002F3_A10DistribuidorID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19MaxItems ;
      private short AV18PageIndex ;
      private short AV17SkipItems ;
      private int AV39GXV1 ;
      private int A10DistribuidorID ;
      private long AV26count ;
      private string AV14TFDistribuidorRFC ;
      private string AV15TFDistribuidorRFC_Sel ;
      private string AV44Wpdistribuidords_4_tfdistribuidorrfc ;
      private string AV45Wpdistribuidords_5_tfdistribuidorrfc_sel ;
      private string lV44Wpdistribuidords_4_tfdistribuidorrfc ;
      private string A12DistribuidorRFC ;
      private bool returnInSub ;
      private bool BRK2F2 ;
      private bool BRK2F4 ;
      private string AV35OptionsJson ;
      private string AV36OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string AV32DDOName ;
      private string AV33SearchTxtParms ;
      private string AV34SearchTxtTo ;
      private string AV16SearchTxt ;
      private string AV38FilterFullText ;
      private string AV12TFDistribuidorDescripcion ;
      private string AV13TFDistribuidorDescripcion_Sel ;
      private string AV41Wpdistribuidords_1_filterfulltext ;
      private string AV42Wpdistribuidords_2_tfdistribuidordescripcion ;
      private string AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel ;
      private string lV41Wpdistribuidords_1_filterfulltext ;
      private string lV42Wpdistribuidords_2_tfdistribuidordescripcion ;
      private string A11DistribuidorDescripcion ;
      private string AV21Option ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV22Options ;
      private GxSimpleCollection<string> AV24OptionsDesc ;
      private GxSimpleCollection<string> AV25OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV29GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P002F2_A11DistribuidorDescripcion ;
      private string[] P002F2_A12DistribuidorRFC ;
      private int[] P002F2_A10DistribuidorID ;
      private string[] P002F3_A12DistribuidorRFC ;
      private string[] P002F3_A11DistribuidorDescripcion ;
      private int[] P002F3_A10DistribuidorID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpdistribuidorgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002F2( IGxContext context ,
                                             string AV41Wpdistribuidords_1_filterfulltext ,
                                             string AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel ,
                                             string AV42Wpdistribuidords_2_tfdistribuidordescripcion ,
                                             string AV45Wpdistribuidords_5_tfdistribuidorrfc_sel ,
                                             string AV44Wpdistribuidords_4_tfdistribuidorrfc ,
                                             string A11DistribuidorDescripcion ,
                                             string A12DistribuidorRFC )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT `DistribuidorDescripcion`, `DistribuidorRFC`, `DistribuidorID` FROM `Distribuidor`";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Wpdistribuidords_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( `DistribuidorDescripcion` like CONCAT('%', @lV41Wpdistribuidords_1_filterfulltext)) or ( `DistribuidorRFC` like CONCAT('%', @lV41Wpdistribuidords_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Wpdistribuidords_2_tfdistribuidordescripcion)) ) )
         {
            AddWhere(sWhereString, "(`DistribuidorDescripcion` like @lV42Wpdistribuidords_2_tfdistribuidordescripcion)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel)) && ! ( StringUtil.StrCmp(AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`DistribuidorDescripcion` = @AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`DistribuidorDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Wpdistribuidords_5_tfdistribuidorrfc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Wpdistribuidords_4_tfdistribuidorrfc)) ) )
         {
            AddWhere(sWhereString, "(`DistribuidorRFC` like @lV44Wpdistribuidords_4_tfdistribuidorrfc)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Wpdistribuidords_5_tfdistribuidorrfc_sel)) && ! ( StringUtil.StrCmp(AV45Wpdistribuidords_5_tfdistribuidorrfc_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`DistribuidorRFC` = @AV45Wpdistribuidords_5_tfdistribuidorrfc_sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV45Wpdistribuidords_5_tfdistribuidorrfc_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`DistribuidorRFC`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `DistribuidorDescripcion`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002F3( IGxContext context ,
                                             string AV41Wpdistribuidords_1_filterfulltext ,
                                             string AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel ,
                                             string AV42Wpdistribuidords_2_tfdistribuidordescripcion ,
                                             string AV45Wpdistribuidords_5_tfdistribuidorrfc_sel ,
                                             string AV44Wpdistribuidords_4_tfdistribuidorrfc ,
                                             string A11DistribuidorDescripcion ,
                                             string A12DistribuidorRFC )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT `DistribuidorRFC`, `DistribuidorDescripcion`, `DistribuidorID` FROM `Distribuidor`";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Wpdistribuidords_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( `DistribuidorDescripcion` like CONCAT('%', @lV41Wpdistribuidords_1_filterfulltext)) or ( `DistribuidorRFC` like CONCAT('%', @lV41Wpdistribuidords_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Wpdistribuidords_2_tfdistribuidordescripcion)) ) )
         {
            AddWhere(sWhereString, "(`DistribuidorDescripcion` like @lV42Wpdistribuidords_2_tfdistribuidordescripcion)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel)) && ! ( StringUtil.StrCmp(AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`DistribuidorDescripcion` = @AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`DistribuidorDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Wpdistribuidords_5_tfdistribuidorrfc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Wpdistribuidords_4_tfdistribuidorrfc)) ) )
         {
            AddWhere(sWhereString, "(`DistribuidorRFC` like @lV44Wpdistribuidords_4_tfdistribuidorrfc)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Wpdistribuidords_5_tfdistribuidorrfc_sel)) && ! ( StringUtil.StrCmp(AV45Wpdistribuidords_5_tfdistribuidorrfc_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`DistribuidorRFC` = @AV45Wpdistribuidords_5_tfdistribuidorrfc_sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV45Wpdistribuidords_5_tfdistribuidorrfc_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`DistribuidorRFC`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `DistribuidorRFC`";
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
                     return conditional_P002F2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
               case 1 :
                     return conditional_P002F3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
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
          Object[] prmP002F2;
          prmP002F2 = new Object[] {
          new ParDef("@lV41Wpdistribuidords_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV41Wpdistribuidords_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV42Wpdistribuidords_2_tfdistribuidordescripcion",GXType.Char,80,0) ,
          new ParDef("@AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV44Wpdistribuidords_4_tfdistribuidorrfc",GXType.Char,13,0) ,
          new ParDef("@AV45Wpdistribuidords_5_tfdistribuidorrfc_sel",GXType.Char,13,0)
          };
          Object[] prmP002F3;
          prmP002F3 = new Object[] {
          new ParDef("@lV41Wpdistribuidords_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV41Wpdistribuidords_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV42Wpdistribuidords_2_tfdistribuidordescripcion",GXType.Char,80,0) ,
          new ParDef("@AV43Wpdistribuidords_3_tfdistribuidordescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV44Wpdistribuidords_4_tfdistribuidorrfc",GXType.Char,13,0) ,
          new ParDef("@AV45Wpdistribuidords_5_tfdistribuidorrfc_sel",GXType.Char,13,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 13);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 13);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
