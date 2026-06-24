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
   public class wpestadogetfilterdata : GXProcedure
   {
      public wpestadogetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpestadogetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_ESTADODESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADESTADODESCRIPCIONOPTIONS' */
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
         if ( StringUtil.StrCmp(AV28Session.Get("WPEstadoGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPEstadoGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("WPEstadoGridState"), null, "", "");
         }
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV41GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFESTADODESCRIPCION") == 0 )
            {
               AV14TFEstadoDescripcion = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFESTADODESCRIPCION_SEL") == 0 )
            {
               AV15TFEstadoDescripcion_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFESTADOACTIVO_SEL") == 0 )
            {
               AV16TFEstadoActivo_Sel = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV41GXV1 = (int)(AV41GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADESTADODESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV14TFEstadoDescripcion = AV17SearchTxt;
         AV15TFEstadoDescripcion_Sel = "";
         AV43Wpestadods_1_filterfulltext = AV39FilterFullText;
         AV44Wpestadods_2_tfestadodescripcion = AV14TFEstadoDescripcion;
         AV45Wpestadods_3_tfestadodescripcion_sel = AV15TFEstadoDescripcion_Sel;
         AV46Wpestadods_4_tfestadoactivo_sel = AV16TFEstadoActivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV43Wpestadods_1_filterfulltext ,
                                              AV45Wpestadods_3_tfestadodescripcion_sel ,
                                              AV44Wpestadods_2_tfestadodescripcion ,
                                              AV46Wpestadods_4_tfestadoactivo_sel ,
                                              A2EstadoDescripcion ,
                                              A3EstadoActivo ,
                                              A16PaisID ,
                                              AV40PaisID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV43Wpestadods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Wpestadods_1_filterfulltext), "%", "");
         lV44Wpestadods_2_tfestadodescripcion = StringUtil.Concat( StringUtil.RTrim( AV44Wpestadods_2_tfestadodescripcion), "%", "");
         /* Using cursor P00292 */
         pr_default.execute(0, new Object[] {AV40PaisID, lV43Wpestadods_1_filterfulltext, lV44Wpestadods_2_tfestadodescripcion, AV45Wpestadods_3_tfestadodescripcion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK292 = false;
            A2EstadoDescripcion = P00292_A2EstadoDescripcion[0];
            A16PaisID = P00292_A16PaisID[0];
            A3EstadoActivo = P00292_A3EstadoActivo[0];
            A1EstadoID = P00292_A1EstadoID[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00292_A2EstadoDescripcion[0], A2EstadoDescripcion) == 0 ) )
            {
               BRK292 = false;
               A1EstadoID = P00292_A1EstadoID[0];
               AV27count = (long)(AV27count+1);
               BRK292 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A2EstadoDescripcion)) ? "<#Empty#>" : A2EstadoDescripcion);
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
            if ( ! BRK292 )
            {
               BRK292 = true;
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
         AV14TFEstadoDescripcion = "";
         AV15TFEstadoDescripcion_Sel = "";
         AV43Wpestadods_1_filterfulltext = "";
         AV44Wpestadods_2_tfestadodescripcion = "";
         AV45Wpestadods_3_tfestadodescripcion_sel = "";
         lV43Wpestadods_1_filterfulltext = "";
         lV44Wpestadods_2_tfestadodescripcion = "";
         A2EstadoDescripcion = "";
         P00292_A2EstadoDescripcion = new string[] {""} ;
         P00292_A16PaisID = new int[1] ;
         P00292_A3EstadoActivo = new bool[] {false} ;
         P00292_A1EstadoID = new int[1] ;
         AV22Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpestadogetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00292_A2EstadoDescripcion, P00292_A16PaisID, P00292_A3EstadoActivo, P00292_A1EstadoID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV16TFEstadoActivo_Sel ;
      private short AV46Wpestadods_4_tfestadoactivo_sel ;
      private int AV41GXV1 ;
      private int A16PaisID ;
      private int AV40PaisID ;
      private int A1EstadoID ;
      private long AV27count ;
      private bool returnInSub ;
      private bool A3EstadoActivo ;
      private bool BRK292 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV14TFEstadoDescripcion ;
      private string AV15TFEstadoDescripcion_Sel ;
      private string AV43Wpestadods_1_filterfulltext ;
      private string AV44Wpestadods_2_tfestadodescripcion ;
      private string AV45Wpestadods_3_tfestadodescripcion_sel ;
      private string lV43Wpestadods_1_filterfulltext ;
      private string lV44Wpestadods_2_tfestadodescripcion ;
      private string A2EstadoDescripcion ;
      private string AV22Option ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV26OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV30GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00292_A2EstadoDescripcion ;
      private int[] P00292_A16PaisID ;
      private bool[] P00292_A3EstadoActivo ;
      private int[] P00292_A1EstadoID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpestadogetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00292( IGxContext context ,
                                             string AV43Wpestadods_1_filterfulltext ,
                                             string AV45Wpestadods_3_tfestadodescripcion_sel ,
                                             string AV44Wpestadods_2_tfestadodescripcion ,
                                             short AV46Wpestadods_4_tfestadoactivo_sel ,
                                             string A2EstadoDescripcion ,
                                             bool A3EstadoActivo ,
                                             int A16PaisID ,
                                             int AV40PaisID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT `EstadoDescripcion`, `PaisID`, `EstadoActivo`, `EstadoID` FROM `Estado`";
         AddWhere(sWhereString, "(`PaisID` = @AV40PaisID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Wpestadods_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( `EstadoDescripcion` like CONCAT('%', @lV43Wpestadods_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Wpestadods_3_tfestadodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Wpestadods_2_tfestadodescripcion)) ) )
         {
            AddWhere(sWhereString, "(`EstadoDescripcion` like @lV44Wpestadods_2_tfestadodescripcion)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Wpestadods_3_tfestadodescripcion_sel)) && ! ( StringUtil.StrCmp(AV45Wpestadods_3_tfestadodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`EstadoDescripcion` = @AV45Wpestadods_3_tfestadodescripcion_sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV45Wpestadods_3_tfestadodescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`EstadoDescripcion`))=0))");
         }
         if ( AV46Wpestadods_4_tfestadoactivo_sel == 1 )
         {
            AddWhere(sWhereString, "(`EstadoActivo` = 1)");
         }
         if ( AV46Wpestadods_4_tfestadoactivo_sel == 2 )
         {
            AddWhere(sWhereString, "(`EstadoActivo` = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `EstadoDescripcion`";
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
                     return conditional_P00292(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] );
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
          Object[] prmP00292;
          prmP00292 = new Object[] {
          new ParDef("@AV40PaisID",GXType.Int32,9,0) ,
          new ParDef("@lV43Wpestadods_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV44Wpestadods_2_tfestadodescripcion",GXType.Char,80,0) ,
          new ParDef("@AV45Wpestadods_3_tfestadodescripcion_sel",GXType.Char,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00292", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00292,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
