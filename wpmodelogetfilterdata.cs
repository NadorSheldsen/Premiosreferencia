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
   public class wpmodelogetfilterdata : GXProcedure
   {
      public wpmodelogetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpmodelogetfilterdata( IGxContext context )
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
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV38OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV23Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV20MaxItems = 10;
         AV19PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV34SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV17SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? "" : StringUtil.Substring( AV34SearchTxtParms, 3, -1));
         AV18SkipItems = (short)(AV19PageIndex*AV20MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_MODELODESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADMODELODESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV36OptionsJson = AV23Options.ToJSonString(false);
         AV37OptionsDescJson = AV25OptionsDesc.ToJSonString(false);
         AV38OptionIndexesJson = AV26OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("WPModeloGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPModeloGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("WPModeloGridState"), null, "", "");
         }
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV40GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFMODELODESCRIPCION") == 0 )
            {
               AV12TFModeloDescripcion = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFMODELODESCRIPCION_SEL") == 0 )
            {
               AV13TFModeloDescripcion_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFMODELOACTIVO_SEL") == 0 )
            {
               AV14TFModeloActivo_Sel = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFMODELOSEGMENTO_SEL") == 0 )
            {
               AV15TFModeloSegmento_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV16TFModeloSegmento_Sels.FromJSonString(AV15TFModeloSegmento_SelsJson, null);
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADMODELODESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV12TFModeloDescripcion = AV17SearchTxt;
         AV13TFModeloDescripcion_Sel = "";
         AV42Wpmodelods_1_filterfulltext = AV39FilterFullText;
         AV43Wpmodelods_2_tfmodelodescripcion = AV12TFModeloDescripcion;
         AV44Wpmodelods_3_tfmodelodescripcion_sel = AV13TFModeloDescripcion_Sel;
         AV45Wpmodelods_4_tfmodeloactivo_sel = AV14TFModeloActivo_Sel;
         AV46Wpmodelods_5_tfmodelosegmento_sels = AV16TFModeloSegmento_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A25ModeloSegmento ,
                                              AV46Wpmodelods_5_tfmodelosegmento_sels ,
                                              AV44Wpmodelods_3_tfmodelodescripcion_sel ,
                                              AV43Wpmodelods_2_tfmodelodescripcion ,
                                              AV45Wpmodelods_4_tfmodeloactivo_sel ,
                                              AV46Wpmodelods_5_tfmodelosegmento_sels.Count ,
                                              A23ModeloDescripcion ,
                                              A24ModeloActivo ,
                                              AV42Wpmodelods_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV43Wpmodelods_2_tfmodelodescripcion = StringUtil.Concat( StringUtil.RTrim( AV43Wpmodelods_2_tfmodelodescripcion), "%", "");
         /* Using cursor P002J2 */
         pr_default.execute(0, new Object[] {lV43Wpmodelods_2_tfmodelodescripcion, AV44Wpmodelods_3_tfmodelodescripcion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2J2 = false;
            A23ModeloDescripcion = P002J2_A23ModeloDescripcion[0];
            A24ModeloActivo = P002J2_A24ModeloActivo[0];
            A25ModeloSegmento = P002J2_A25ModeloSegmento[0];
            A22ModeloID = P002J2_A22ModeloID[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Wpmodelods_1_filterfulltext)) || ( ( StringUtil.Like( A23ModeloDescripcion , StringUtil.PadR( "%" + AV42Wpmodelods_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "auto", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV42Wpmodelods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A25ModeloSegmento, context.GetMessage( "AUTO", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "camioneta", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV42Wpmodelods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A25ModeloSegmento, context.GetMessage( "CAMIONETA", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "camión", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV42Wpmodelods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A25ModeloSegmento, context.GetMessage( "CAMIÓN", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "agrícola", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV42Wpmodelods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A25ModeloSegmento, context.GetMessage( "AGRÍCOLA", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "industrial", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV42Wpmodelods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A25ModeloSegmento, context.GetMessage( "INDUSTRIAL", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "otr", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV42Wpmodelods_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A25ModeloSegmento, context.GetMessage( "OTR", "")) == 0 ) ) ) )
            {
               AV27count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002J2_A23ModeloDescripcion[0], A23ModeloDescripcion) == 0 ) )
               {
                  BRK2J2 = false;
                  A22ModeloID = P002J2_A22ModeloID[0];
                  AV27count = (long)(AV27count+1);
                  BRK2J2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV18SkipItems) )
               {
                  AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A23ModeloDescripcion)) ? "<#Empty#>" : A23ModeloDescripcion);
                  AV23Options.Add(AV22Option, 0);
                  AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV23Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV18SkipItems = (short)(AV18SkipItems-1);
               }
            }
            if ( ! BRK2J2 )
            {
               BRK2J2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV36OptionsJson = "";
         AV37OptionsDescJson = "";
         AV38OptionIndexesJson = "";
         AV23Options = new GxSimpleCollection<string>();
         AV25OptionsDesc = new GxSimpleCollection<string>();
         AV26OptionIndexes = new GxSimpleCollection<string>();
         AV17SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV28Session = context.GetSession();
         AV30GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV31GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV39FilterFullText = "";
         AV12TFModeloDescripcion = "";
         AV13TFModeloDescripcion_Sel = "";
         AV15TFModeloSegmento_SelsJson = "";
         AV16TFModeloSegmento_Sels = new GxSimpleCollection<string>();
         AV42Wpmodelods_1_filterfulltext = "";
         AV43Wpmodelods_2_tfmodelodescripcion = "";
         AV44Wpmodelods_3_tfmodelodescripcion_sel = "";
         AV46Wpmodelods_5_tfmodelosegmento_sels = new GxSimpleCollection<string>();
         lV43Wpmodelods_2_tfmodelodescripcion = "";
         A25ModeloSegmento = "";
         A23ModeloDescripcion = "";
         P002J2_A23ModeloDescripcion = new string[] {""} ;
         P002J2_A24ModeloActivo = new bool[] {false} ;
         P002J2_A25ModeloSegmento = new string[] {""} ;
         P002J2_A22ModeloID = new int[1] ;
         AV22Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpmodelogetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002J2_A23ModeloDescripcion, P002J2_A24ModeloActivo, P002J2_A25ModeloSegmento, P002J2_A22ModeloID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV14TFModeloActivo_Sel ;
      private short AV45Wpmodelods_4_tfmodeloactivo_sel ;
      private int AV40GXV1 ;
      private int AV46Wpmodelods_5_tfmodelosegmento_sels_Count ;
      private int A22ModeloID ;
      private long AV27count ;
      private string A25ModeloSegmento ;
      private bool returnInSub ;
      private bool A24ModeloActivo ;
      private bool BRK2J2 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV15TFModeloSegmento_SelsJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV12TFModeloDescripcion ;
      private string AV13TFModeloDescripcion_Sel ;
      private string AV42Wpmodelods_1_filterfulltext ;
      private string AV43Wpmodelods_2_tfmodelodescripcion ;
      private string AV44Wpmodelods_3_tfmodelodescripcion_sel ;
      private string lV43Wpmodelods_2_tfmodelodescripcion ;
      private string A23ModeloDescripcion ;
      private string AV22Option ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV26OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV30GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GxSimpleCollection<string> AV16TFModeloSegmento_Sels ;
      private GxSimpleCollection<string> AV46Wpmodelods_5_tfmodelosegmento_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P002J2_A23ModeloDescripcion ;
      private bool[] P002J2_A24ModeloActivo ;
      private string[] P002J2_A25ModeloSegmento ;
      private int[] P002J2_A22ModeloID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpmodelogetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002J2( IGxContext context ,
                                             string A25ModeloSegmento ,
                                             GxSimpleCollection<string> AV46Wpmodelods_5_tfmodelosegmento_sels ,
                                             string AV44Wpmodelods_3_tfmodelodescripcion_sel ,
                                             string AV43Wpmodelods_2_tfmodelodescripcion ,
                                             short AV45Wpmodelods_4_tfmodeloactivo_sel ,
                                             int AV46Wpmodelods_5_tfmodelosegmento_sels_Count ,
                                             string A23ModeloDescripcion ,
                                             bool A24ModeloActivo ,
                                             string AV42Wpmodelods_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT `ModeloDescripcion`, `ModeloActivo`, `ModeloSegmento`, `ModeloID` FROM `Modelo`";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Wpmodelods_3_tfmodelodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Wpmodelods_2_tfmodelodescripcion)) ) )
         {
            AddWhere(sWhereString, "(`ModeloDescripcion` like @lV43Wpmodelods_2_tfmodelodescripcion)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Wpmodelods_3_tfmodelodescripcion_sel)) && ! ( StringUtil.StrCmp(AV44Wpmodelods_3_tfmodelodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`ModeloDescripcion` = @AV44Wpmodelods_3_tfmodelodescripcion_sel)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV44Wpmodelods_3_tfmodelodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`ModeloDescripcion`))=0))");
         }
         if ( AV45Wpmodelods_4_tfmodeloactivo_sel == 1 )
         {
            AddWhere(sWhereString, "(`ModeloActivo` = 1)");
         }
         if ( AV45Wpmodelods_4_tfmodeloactivo_sel == 2 )
         {
            AddWhere(sWhereString, "(`ModeloActivo` = 0)");
         }
         if ( AV46Wpmodelods_5_tfmodelosegmento_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV46Wpmodelods_5_tfmodelosegmento_sels, "`ModeloSegmento` IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `ModeloDescripcion`";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002J2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] );
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
          Object[] prmP002J2;
          prmP002J2 = new Object[] {
          new ParDef("@lV43Wpmodelods_2_tfmodelodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV44Wpmodelods_3_tfmodelodescripcion_sel",GXType.Char,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002J2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
