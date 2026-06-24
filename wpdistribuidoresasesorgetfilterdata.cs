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
   public class wpdistribuidoresasesorgetfilterdata : GXProcedure
   {
      public wpdistribuidoresasesorgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpdistribuidoresasesorgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_DISTRIBUIDORDESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADDISTRIBUIDORDESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_DISTRIBUIDORRFC") == 0 )
         {
            /* Execute user subroutine: 'LOADDISTRIBUIDORRFCOPTIONS' */
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
         if ( StringUtil.StrCmp(AV31Session.Get("WPDistribuidoresAsesorGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPDistribuidoresAsesorGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("WPDistribuidoresAsesorGridState"), null, "", "");
         }
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV44GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV42FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFDISTRIBUIDORDESCRIPCION") == 0 )
            {
               AV16TFDistribuidorDescripcion = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFDISTRIBUIDORDESCRIPCION_SEL") == 0 )
            {
               AV17TFDistribuidorDescripcion_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFDISTRIBUIDORRFC") == 0 )
            {
               AV18TFDistribuidorRFC = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFDISTRIBUIDORRFC_SEL") == 0 )
            {
               AV19TFDistribuidorRFC_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADDISTRIBUIDORDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV16TFDistribuidorDescripcion = AV20SearchTxt;
         AV17TFDistribuidorDescripcion_Sel = "";
         AV46Wpdistribuidoresasesords_1_filterfulltext = AV42FilterFullText;
         AV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion = AV16TFDistribuidorDescripcion;
         AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel = AV17TFDistribuidorDescripcion_Sel;
         AV49Wpdistribuidoresasesords_4_tfdistribuidorrfc = AV18TFDistribuidorRFC;
         AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel = AV19TFDistribuidorRFC_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV46Wpdistribuidoresasesords_1_filterfulltext ,
                                              AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel ,
                                              AV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion ,
                                              AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel ,
                                              AV49Wpdistribuidoresasesords_4_tfdistribuidorrfc ,
                                              A11DistribuidorDescripcion ,
                                              A12DistribuidorRFC ,
                                              A29UsuarioID ,
                                              AV43UsuarioID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV46Wpdistribuidoresasesords_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Wpdistribuidoresasesords_1_filterfulltext), "%", "");
         lV46Wpdistribuidoresasesords_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Wpdistribuidoresasesords_1_filterfulltext), "%", "");
         lV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion = StringUtil.Concat( StringUtil.RTrim( AV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion), "%", "");
         lV49Wpdistribuidoresasesords_4_tfdistribuidorrfc = StringUtil.PadR( StringUtil.RTrim( AV49Wpdistribuidoresasesords_4_tfdistribuidorrfc), 13, "%");
         /* Using cursor P003N2 */
         pr_default.execute(0, new Object[] {AV43UsuarioID, lV46Wpdistribuidoresasesords_1_filterfulltext, lV46Wpdistribuidoresasesords_1_filterfulltext, lV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion, AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel, lV49Wpdistribuidoresasesords_4_tfdistribuidorrfc, AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3N2 = false;
            A10DistribuidorID = P003N2_A10DistribuidorID[0];
            A29UsuarioID = P003N2_A29UsuarioID[0];
            A12DistribuidorRFC = P003N2_A12DistribuidorRFC[0];
            A11DistribuidorDescripcion = P003N2_A11DistribuidorDescripcion[0];
            A81DistribuidoresUsuarioID = P003N2_A81DistribuidoresUsuarioID[0];
            A12DistribuidorRFC = P003N2_A12DistribuidorRFC[0];
            A11DistribuidorDescripcion = P003N2_A11DistribuidorDescripcion[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P003N2_A10DistribuidorID[0] == A10DistribuidorID ) )
            {
               BRK3N2 = false;
               A81DistribuidoresUsuarioID = P003N2_A81DistribuidoresUsuarioID[0];
               AV30count = (long)(AV30count+1);
               BRK3N2 = true;
               pr_default.readNext(0);
            }
            AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A11DistribuidorDescripcion)) ? "<#Empty#>" : A11DistribuidorDescripcion);
            AV24InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV25Option, "<#Empty#>") != 0 ) && ( AV24InsertIndex <= AV26Options.Count ) && ( ( StringUtil.StrCmp(((string)AV26Options.Item(AV24InsertIndex)), AV25Option) < 0 ) || ( StringUtil.StrCmp(((string)AV26Options.Item(AV24InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV24InsertIndex = (int)(AV24InsertIndex+1);
            }
            AV26Options.Add(AV25Option, AV24InsertIndex);
            AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), AV24InsertIndex);
            if ( AV26Options.Count == AV21SkipItems + 11 )
            {
               AV26Options.RemoveItem(AV26Options.Count);
               AV29OptionIndexes.RemoveItem(AV29OptionIndexes.Count);
            }
            if ( ! BRK3N2 )
            {
               BRK3N2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV21SkipItems > 0 )
         {
            AV26Options.RemoveItem(1);
            AV29OptionIndexes.RemoveItem(1);
            AV21SkipItems = (short)(AV21SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADDISTRIBUIDORRFCOPTIONS' Routine */
         returnInSub = false;
         AV18TFDistribuidorRFC = AV20SearchTxt;
         AV19TFDistribuidorRFC_Sel = "";
         AV46Wpdistribuidoresasesords_1_filterfulltext = AV42FilterFullText;
         AV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion = AV16TFDistribuidorDescripcion;
         AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel = AV17TFDistribuidorDescripcion_Sel;
         AV49Wpdistribuidoresasesords_4_tfdistribuidorrfc = AV18TFDistribuidorRFC;
         AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel = AV19TFDistribuidorRFC_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV46Wpdistribuidoresasesords_1_filterfulltext ,
                                              AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel ,
                                              AV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion ,
                                              AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel ,
                                              AV49Wpdistribuidoresasesords_4_tfdistribuidorrfc ,
                                              A11DistribuidorDescripcion ,
                                              A12DistribuidorRFC ,
                                              A29UsuarioID ,
                                              AV43UsuarioID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV46Wpdistribuidoresasesords_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Wpdistribuidoresasesords_1_filterfulltext), "%", "");
         lV46Wpdistribuidoresasesords_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Wpdistribuidoresasesords_1_filterfulltext), "%", "");
         lV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion = StringUtil.Concat( StringUtil.RTrim( AV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion), "%", "");
         lV49Wpdistribuidoresasesords_4_tfdistribuidorrfc = StringUtil.PadR( StringUtil.RTrim( AV49Wpdistribuidoresasesords_4_tfdistribuidorrfc), 13, "%");
         /* Using cursor P003N3 */
         pr_default.execute(1, new Object[] {AV43UsuarioID, lV46Wpdistribuidoresasesords_1_filterfulltext, lV46Wpdistribuidoresasesords_1_filterfulltext, lV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion, AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel, lV49Wpdistribuidoresasesords_4_tfdistribuidorrfc, AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK3N4 = false;
            A10DistribuidorID = P003N3_A10DistribuidorID[0];
            A29UsuarioID = P003N3_A29UsuarioID[0];
            A12DistribuidorRFC = P003N3_A12DistribuidorRFC[0];
            A11DistribuidorDescripcion = P003N3_A11DistribuidorDescripcion[0];
            A81DistribuidoresUsuarioID = P003N3_A81DistribuidoresUsuarioID[0];
            A12DistribuidorRFC = P003N3_A12DistribuidorRFC[0];
            A11DistribuidorDescripcion = P003N3_A11DistribuidorDescripcion[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P003N3_A12DistribuidorRFC[0], A12DistribuidorRFC) == 0 ) )
            {
               BRK3N4 = false;
               A10DistribuidorID = P003N3_A10DistribuidorID[0];
               A81DistribuidoresUsuarioID = P003N3_A81DistribuidoresUsuarioID[0];
               AV30count = (long)(AV30count+1);
               BRK3N4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV21SkipItems) )
            {
               AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A12DistribuidorRFC)) ? "<#Empty#>" : A12DistribuidorRFC);
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
            if ( ! BRK3N4 )
            {
               BRK3N4 = true;
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
         AV16TFDistribuidorDescripcion = "";
         AV17TFDistribuidorDescripcion_Sel = "";
         AV18TFDistribuidorRFC = "";
         AV19TFDistribuidorRFC_Sel = "";
         AV46Wpdistribuidoresasesords_1_filterfulltext = "";
         AV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion = "";
         AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel = "";
         AV49Wpdistribuidoresasesords_4_tfdistribuidorrfc = "";
         AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel = "";
         lV46Wpdistribuidoresasesords_1_filterfulltext = "";
         lV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion = "";
         lV49Wpdistribuidoresasesords_4_tfdistribuidorrfc = "";
         A11DistribuidorDescripcion = "";
         A12DistribuidorRFC = "";
         P003N2_A10DistribuidorID = new int[1] ;
         P003N2_A29UsuarioID = new int[1] ;
         P003N2_A12DistribuidorRFC = new string[] {""} ;
         P003N2_A11DistribuidorDescripcion = new string[] {""} ;
         P003N2_A81DistribuidoresUsuarioID = new int[1] ;
         AV25Option = "";
         P003N3_A10DistribuidorID = new int[1] ;
         P003N3_A29UsuarioID = new int[1] ;
         P003N3_A12DistribuidorRFC = new string[] {""} ;
         P003N3_A11DistribuidorDescripcion = new string[] {""} ;
         P003N3_A81DistribuidoresUsuarioID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpdistribuidoresasesorgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003N2_A10DistribuidorID, P003N2_A29UsuarioID, P003N2_A12DistribuidorRFC, P003N2_A11DistribuidorDescripcion, P003N2_A81DistribuidoresUsuarioID
               }
               , new Object[] {
               P003N3_A10DistribuidorID, P003N3_A29UsuarioID, P003N3_A12DistribuidorRFC, P003N3_A11DistribuidorDescripcion, P003N3_A81DistribuidoresUsuarioID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV23MaxItems ;
      private short AV22PageIndex ;
      private short AV21SkipItems ;
      private int AV44GXV1 ;
      private int A29UsuarioID ;
      private int AV43UsuarioID ;
      private int A10DistribuidorID ;
      private int A81DistribuidoresUsuarioID ;
      private int AV24InsertIndex ;
      private long AV30count ;
      private string AV18TFDistribuidorRFC ;
      private string AV19TFDistribuidorRFC_Sel ;
      private string AV49Wpdistribuidoresasesords_4_tfdistribuidorrfc ;
      private string AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel ;
      private string lV49Wpdistribuidoresasesords_4_tfdistribuidorrfc ;
      private string A12DistribuidorRFC ;
      private bool returnInSub ;
      private bool BRK3N2 ;
      private bool BRK3N4 ;
      private string AV39OptionsJson ;
      private string AV40OptionsDescJson ;
      private string AV41OptionIndexesJson ;
      private string AV36DDOName ;
      private string AV37SearchTxtParms ;
      private string AV38SearchTxtTo ;
      private string AV20SearchTxt ;
      private string AV42FilterFullText ;
      private string AV16TFDistribuidorDescripcion ;
      private string AV17TFDistribuidorDescripcion_Sel ;
      private string AV46Wpdistribuidoresasesords_1_filterfulltext ;
      private string AV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion ;
      private string AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel ;
      private string lV46Wpdistribuidoresasesords_1_filterfulltext ;
      private string lV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion ;
      private string A11DistribuidorDescripcion ;
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
      private int[] P003N2_A10DistribuidorID ;
      private int[] P003N2_A29UsuarioID ;
      private string[] P003N2_A12DistribuidorRFC ;
      private string[] P003N2_A11DistribuidorDescripcion ;
      private int[] P003N2_A81DistribuidoresUsuarioID ;
      private int[] P003N3_A10DistribuidorID ;
      private int[] P003N3_A29UsuarioID ;
      private string[] P003N3_A12DistribuidorRFC ;
      private string[] P003N3_A11DistribuidorDescripcion ;
      private int[] P003N3_A81DistribuidoresUsuarioID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpdistribuidoresasesorgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003N2( IGxContext context ,
                                             string AV46Wpdistribuidoresasesords_1_filterfulltext ,
                                             string AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel ,
                                             string AV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion ,
                                             string AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel ,
                                             string AV49Wpdistribuidoresasesords_4_tfdistribuidorrfc ,
                                             string A11DistribuidorDescripcion ,
                                             string A12DistribuidorRFC ,
                                             int A29UsuarioID ,
                                             int AV43UsuarioID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.`DistribuidorID`, T1.`UsuarioID`, T2.`DistribuidorRFC`, T2.`DistribuidorDescripcion`, T1.`DistribuidoresUsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Distribuidor` T2 ON T2.`DistribuidorID` = T1.`DistribuidorID`)";
         AddWhere(sWhereString, "(T1.`UsuarioID` = @AV43UsuarioID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Wpdistribuidoresasesords_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.`DistribuidorDescripcion` like CONCAT('%', @lV46Wpdistribuidoresasesords_1_filterfulltext)) or ( T2.`DistribuidorRFC` like CONCAT('%', @lV46Wpdistribuidoresasesords_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`DistribuidorDescripcion` like @lV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel)) && ! ( StringUtil.StrCmp(AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`DistribuidorDescripcion` = @AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`DistribuidorDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wpdistribuidoresasesords_4_tfdistribuidorrfc)) ) )
         {
            AddWhere(sWhereString, "(T2.`DistribuidorRFC` like @lV49Wpdistribuidoresasesords_4_tfdistribuidorrfc)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel)) && ! ( StringUtil.StrCmp(AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`DistribuidorRFC` = @AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`DistribuidorRFC`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.`DistribuidorID`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P003N3( IGxContext context ,
                                             string AV46Wpdistribuidoresasesords_1_filterfulltext ,
                                             string AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel ,
                                             string AV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion ,
                                             string AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel ,
                                             string AV49Wpdistribuidoresasesords_4_tfdistribuidorrfc ,
                                             string A11DistribuidorDescripcion ,
                                             string A12DistribuidorRFC ,
                                             int A29UsuarioID ,
                                             int AV43UsuarioID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.`DistribuidorID`, T1.`UsuarioID`, T2.`DistribuidorRFC`, T2.`DistribuidorDescripcion`, T1.`DistribuidoresUsuarioID` FROM (`DistribuidoresUsuario` T1 INNER JOIN `Distribuidor` T2 ON T2.`DistribuidorID` = T1.`DistribuidorID`)";
         AddWhere(sWhereString, "(T1.`UsuarioID` = @AV43UsuarioID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Wpdistribuidoresasesords_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.`DistribuidorDescripcion` like CONCAT('%', @lV46Wpdistribuidoresasesords_1_filterfulltext)) or ( T2.`DistribuidorRFC` like CONCAT('%', @lV46Wpdistribuidoresasesords_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion)) ) )
         {
            AddWhere(sWhereString, "(T2.`DistribuidorDescripcion` like @lV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel)) && ! ( StringUtil.StrCmp(AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`DistribuidorDescripcion` = @AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`DistribuidorDescripcion`))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wpdistribuidoresasesords_4_tfdistribuidorrfc)) ) )
         {
            AddWhere(sWhereString, "(T2.`DistribuidorRFC` like @lV49Wpdistribuidoresasesords_4_tfdistribuidorrfc)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel)) && ! ( StringUtil.StrCmp(AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.`DistribuidorRFC` = @AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(T2.`DistribuidorRFC`))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.`DistribuidorRFC`";
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
                     return conditional_P003N2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] );
               case 1 :
                     return conditional_P003N3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] );
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
          Object[] prmP003N2;
          prmP003N2 = new Object[] {
          new ParDef("@AV43UsuarioID",GXType.Int32,9,0) ,
          new ParDef("@lV46Wpdistribuidoresasesords_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV46Wpdistribuidoresasesords_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion",GXType.Char,80,0) ,
          new ParDef("@AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV49Wpdistribuidoresasesords_4_tfdistribuidorrfc",GXType.Char,13,0) ,
          new ParDef("@AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel",GXType.Char,13,0)
          };
          Object[] prmP003N3;
          prmP003N3 = new Object[] {
          new ParDef("@AV43UsuarioID",GXType.Int32,9,0) ,
          new ParDef("@lV46Wpdistribuidoresasesords_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV46Wpdistribuidoresasesords_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV47Wpdistribuidoresasesords_2_tfdistribuidordescripcion",GXType.Char,80,0) ,
          new ParDef("@AV48Wpdistribuidoresasesords_3_tfdistribuidordescripcion_sel",GXType.Char,80,0) ,
          new ParDef("@lV49Wpdistribuidoresasesords_4_tfdistribuidorrfc",GXType.Char,13,0) ,
          new ParDef("@AV50Wpdistribuidoresasesords_5_tfdistribuidorrfc_sel",GXType.Char,13,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003N2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003N3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003N3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 13);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 13);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
