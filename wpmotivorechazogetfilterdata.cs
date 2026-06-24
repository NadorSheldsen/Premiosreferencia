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
   public class wpmotivorechazogetfilterdata : GXProcedure
   {
      public wpmotivorechazogetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpmotivorechazogetfilterdata( IGxContext context )
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
         this.AV29DDOName = aP0_DDOName;
         this.AV30SearchTxtParms = aP1_SearchTxtParms;
         this.AV31SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV34OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV34OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV29DDOName = aP0_DDOName;
         this.AV30SearchTxtParms = aP1_SearchTxtParms;
         this.AV31SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV34OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV16MaxItems = 10;
         AV15PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV30SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV30SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV13SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV30SearchTxtParms)) ? "" : StringUtil.Substring( AV30SearchTxtParms, 3, -1));
         AV14SkipItems = (short)(AV15PageIndex*AV16MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_MOTIVORECHAZODESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADMOTIVORECHAZODESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV32OptionsJson = AV19Options.ToJSonString(false);
         AV33OptionsDescJson = AV21OptionsDesc.ToJSonString(false);
         AV34OptionIndexesJson = AV22OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV24Session.Get("WPMotivoRechazoGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPMotivoRechazoGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("WPMotivoRechazoGridState"), null, "", "");
         }
         AV36GXV1 = 1;
         while ( AV36GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV36GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV35FilterFullText = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFMOTIVORECHAZODESCRIPCION") == 0 )
            {
               AV10TFMotivoRechazoDescripcion = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFMOTIVORECHAZODESCRIPCION_SEL") == 0 )
            {
               AV11TFMotivoRechazoDescripcion_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFMOTIVORECHAZOACTIVO_SEL") == 0 )
            {
               AV12TFMotivoRechazoActivo_Sel = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV36GXV1 = (int)(AV36GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADMOTIVORECHAZODESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV10TFMotivoRechazoDescripcion = AV13SearchTxt;
         AV11TFMotivoRechazoDescripcion_Sel = "";
         AV38Wpmotivorechazods_1_filterfulltext = AV35FilterFullText;
         AV39Wpmotivorechazods_2_tfmotivorechazodescripcion = AV10TFMotivoRechazoDescripcion;
         AV40Wpmotivorechazods_3_tfmotivorechazodescripcion_sel = AV11TFMotivoRechazoDescripcion_Sel;
         AV41Wpmotivorechazods_4_tfmotivorechazoactivo_sel = AV12TFMotivoRechazoActivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV38Wpmotivorechazods_1_filterfulltext ,
                                              AV40Wpmotivorechazods_3_tfmotivorechazodescripcion_sel ,
                                              AV39Wpmotivorechazods_2_tfmotivorechazodescripcion ,
                                              AV41Wpmotivorechazods_4_tfmotivorechazoactivo_sel ,
                                              A20MotivoRechazoDescripcion ,
                                              A21MotivoRechazoActivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV38Wpmotivorechazods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV38Wpmotivorechazods_1_filterfulltext), "%", "");
         lV39Wpmotivorechazods_2_tfmotivorechazodescripcion = StringUtil.Concat( StringUtil.RTrim( AV39Wpmotivorechazods_2_tfmotivorechazodescripcion), "%", "");
         /* Using cursor P002I2 */
         pr_default.execute(0, new Object[] {lV38Wpmotivorechazods_1_filterfulltext, lV39Wpmotivorechazods_2_tfmotivorechazodescripcion, AV40Wpmotivorechazods_3_tfmotivorechazodescripcion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2I2 = false;
            A20MotivoRechazoDescripcion = P002I2_A20MotivoRechazoDescripcion[0];
            A21MotivoRechazoActivo = P002I2_A21MotivoRechazoActivo[0];
            A19MotivoRechazoID = P002I2_A19MotivoRechazoID[0];
            AV23count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002I2_A20MotivoRechazoDescripcion[0], A20MotivoRechazoDescripcion) == 0 ) )
            {
               BRK2I2 = false;
               A19MotivoRechazoID = P002I2_A19MotivoRechazoID[0];
               AV23count = (long)(AV23count+1);
               BRK2I2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A20MotivoRechazoDescripcion)) ? "<#Empty#>" : A20MotivoRechazoDescripcion);
               AV19Options.Add(AV18Option, 0);
               AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV19Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV14SkipItems = (short)(AV14SkipItems-1);
            }
            if ( ! BRK2I2 )
            {
               BRK2I2 = true;
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
         AV32OptionsJson = "";
         AV33OptionsDescJson = "";
         AV34OptionIndexesJson = "";
         AV19Options = new GxSimpleCollection<string>();
         AV21OptionsDesc = new GxSimpleCollection<string>();
         AV22OptionIndexes = new GxSimpleCollection<string>();
         AV13SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV24Session = context.GetSession();
         AV26GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV27GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV35FilterFullText = "";
         AV10TFMotivoRechazoDescripcion = "";
         AV11TFMotivoRechazoDescripcion_Sel = "";
         AV38Wpmotivorechazods_1_filterfulltext = "";
         AV39Wpmotivorechazods_2_tfmotivorechazodescripcion = "";
         AV40Wpmotivorechazods_3_tfmotivorechazodescripcion_sel = "";
         lV38Wpmotivorechazods_1_filterfulltext = "";
         lV39Wpmotivorechazods_2_tfmotivorechazodescripcion = "";
         A20MotivoRechazoDescripcion = "";
         P002I2_A20MotivoRechazoDescripcion = new string[] {""} ;
         P002I2_A21MotivoRechazoActivo = new bool[] {false} ;
         P002I2_A19MotivoRechazoID = new int[1] ;
         AV18Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpmotivorechazogetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002I2_A20MotivoRechazoDescripcion, P002I2_A21MotivoRechazoActivo, P002I2_A19MotivoRechazoID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private short AV12TFMotivoRechazoActivo_Sel ;
      private short AV41Wpmotivorechazods_4_tfmotivorechazoactivo_sel ;
      private int AV36GXV1 ;
      private int A19MotivoRechazoID ;
      private long AV23count ;
      private bool returnInSub ;
      private bool A21MotivoRechazoActivo ;
      private bool BRK2I2 ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV35FilterFullText ;
      private string AV10TFMotivoRechazoDescripcion ;
      private string AV11TFMotivoRechazoDescripcion_Sel ;
      private string AV38Wpmotivorechazods_1_filterfulltext ;
      private string AV39Wpmotivorechazods_2_tfmotivorechazodescripcion ;
      private string AV40Wpmotivorechazods_3_tfmotivorechazodescripcion_sel ;
      private string lV38Wpmotivorechazods_1_filterfulltext ;
      private string lV39Wpmotivorechazods_2_tfmotivorechazodescripcion ;
      private string A20MotivoRechazoDescripcion ;
      private string AV18Option ;
      private IGxSession AV24Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV19Options ;
      private GxSimpleCollection<string> AV21OptionsDesc ;
      private GxSimpleCollection<string> AV22OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV26GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV27GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P002I2_A20MotivoRechazoDescripcion ;
      private bool[] P002I2_A21MotivoRechazoActivo ;
      private int[] P002I2_A19MotivoRechazoID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpmotivorechazogetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002I2( IGxContext context ,
                                             string AV38Wpmotivorechazods_1_filterfulltext ,
                                             string AV40Wpmotivorechazods_3_tfmotivorechazodescripcion_sel ,
                                             string AV39Wpmotivorechazods_2_tfmotivorechazodescripcion ,
                                             short AV41Wpmotivorechazods_4_tfmotivorechazoactivo_sel ,
                                             string A20MotivoRechazoDescripcion ,
                                             bool A21MotivoRechazoActivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT `MotivoRechazoDescripcion`, `MotivoRechazoActivo`, `MotivoRechazoID` FROM `MotivoRechazo`";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38Wpmotivorechazods_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( `MotivoRechazoDescripcion` like CONCAT('%', @lV38Wpmotivorechazods_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40Wpmotivorechazods_3_tfmotivorechazodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Wpmotivorechazods_2_tfmotivorechazodescripcion)) ) )
         {
            AddWhere(sWhereString, "(`MotivoRechazoDescripcion` like @lV39Wpmotivorechazods_2_tfmotivorechazodescripcion)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Wpmotivorechazods_3_tfmotivorechazodescripcion_sel)) && ! ( StringUtil.StrCmp(AV40Wpmotivorechazods_3_tfmotivorechazodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`MotivoRechazoDescripcion` = @AV40Wpmotivorechazods_3_tfmotivorechazodescripcion_sel)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV40Wpmotivorechazods_3_tfmotivorechazodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`MotivoRechazoDescripcion`))=0))");
         }
         if ( AV41Wpmotivorechazods_4_tfmotivorechazoactivo_sel == 1 )
         {
            AddWhere(sWhereString, "(`MotivoRechazoActivo` = 1)");
         }
         if ( AV41Wpmotivorechazods_4_tfmotivorechazoactivo_sel == 2 )
         {
            AddWhere(sWhereString, "(`MotivoRechazoActivo` = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `MotivoRechazoDescripcion`";
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
                     return conditional_P002I2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] );
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
          Object[] prmP002I2;
          prmP002I2 = new Object[] {
          new ParDef("@lV38Wpmotivorechazods_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV39Wpmotivorechazods_2_tfmotivorechazodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV40Wpmotivorechazods_3_tfmotivorechazodescripcion_sel",GXType.Char,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002I2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
