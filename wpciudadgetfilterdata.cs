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
   public class wpciudadgetfilterdata : GXProcedure
   {
      public wpciudadgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpciudadgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_CIUDADDESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADCIUDADDESCRIPCIONOPTIONS' */
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
         if ( StringUtil.StrCmp(AV24Session.Get("WPCiudadGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPCiudadGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("WPCiudadGridState"), null, "", "");
         }
         AV37GXV1 = 1;
         while ( AV37GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV37GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV35FilterFullText = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFCIUDADDESCRIPCION") == 0 )
            {
               AV10TFCiudadDescripcion = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFCIUDADDESCRIPCION_SEL") == 0 )
            {
               AV11TFCiudadDescripcion_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFCIUDADACTIVO_SEL") == 0 )
            {
               AV12TFCiudadActivo_Sel = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV37GXV1 = (int)(AV37GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCIUDADDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV10TFCiudadDescripcion = AV13SearchTxt;
         AV11TFCiudadDescripcion_Sel = "";
         AV39Wpciudadds_1_filterfulltext = AV35FilterFullText;
         AV40Wpciudadds_2_tfciudaddescripcion = AV10TFCiudadDescripcion;
         AV41Wpciudadds_3_tfciudaddescripcion_sel = AV11TFCiudadDescripcion_Sel;
         AV42Wpciudadds_4_tfciudadactivo_sel = AV12TFCiudadActivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV39Wpciudadds_1_filterfulltext ,
                                              AV41Wpciudadds_3_tfciudaddescripcion_sel ,
                                              AV40Wpciudadds_2_tfciudaddescripcion ,
                                              AV42Wpciudadds_4_tfciudadactivo_sel ,
                                              A5CiudadDescripcion ,
                                              A6CiudadActivo ,
                                              A1EstadoID ,
                                              AV36EstadoID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV39Wpciudadds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV39Wpciudadds_1_filterfulltext), "%", "");
         lV40Wpciudadds_2_tfciudaddescripcion = StringUtil.Concat( StringUtil.RTrim( AV40Wpciudadds_2_tfciudaddescripcion), "%", "");
         /* Using cursor P002E2 */
         pr_default.execute(0, new Object[] {AV36EstadoID, lV39Wpciudadds_1_filterfulltext, lV40Wpciudadds_2_tfciudaddescripcion, AV41Wpciudadds_3_tfciudaddescripcion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2E2 = false;
            A5CiudadDescripcion = P002E2_A5CiudadDescripcion[0];
            A1EstadoID = P002E2_A1EstadoID[0];
            A6CiudadActivo = P002E2_A6CiudadActivo[0];
            A4CiudadID = P002E2_A4CiudadID[0];
            AV23count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002E2_A5CiudadDescripcion[0], A5CiudadDescripcion) == 0 ) )
            {
               BRK2E2 = false;
               A4CiudadID = P002E2_A4CiudadID[0];
               AV23count = (long)(AV23count+1);
               BRK2E2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A5CiudadDescripcion)) ? "<#Empty#>" : A5CiudadDescripcion);
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
            if ( ! BRK2E2 )
            {
               BRK2E2 = true;
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
         AV10TFCiudadDescripcion = "";
         AV11TFCiudadDescripcion_Sel = "";
         AV39Wpciudadds_1_filterfulltext = "";
         AV40Wpciudadds_2_tfciudaddescripcion = "";
         AV41Wpciudadds_3_tfciudaddescripcion_sel = "";
         lV39Wpciudadds_1_filterfulltext = "";
         lV40Wpciudadds_2_tfciudaddescripcion = "";
         A5CiudadDescripcion = "";
         P002E2_A5CiudadDescripcion = new string[] {""} ;
         P002E2_A1EstadoID = new int[1] ;
         P002E2_A6CiudadActivo = new bool[] {false} ;
         P002E2_A4CiudadID = new int[1] ;
         AV18Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpciudadgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002E2_A5CiudadDescripcion, P002E2_A1EstadoID, P002E2_A6CiudadActivo, P002E2_A4CiudadID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private short AV12TFCiudadActivo_Sel ;
      private short AV42Wpciudadds_4_tfciudadactivo_sel ;
      private int AV37GXV1 ;
      private int A1EstadoID ;
      private int AV36EstadoID ;
      private int A4CiudadID ;
      private long AV23count ;
      private bool returnInSub ;
      private bool A6CiudadActivo ;
      private bool BRK2E2 ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV35FilterFullText ;
      private string AV10TFCiudadDescripcion ;
      private string AV11TFCiudadDescripcion_Sel ;
      private string AV39Wpciudadds_1_filterfulltext ;
      private string AV40Wpciudadds_2_tfciudaddescripcion ;
      private string AV41Wpciudadds_3_tfciudaddescripcion_sel ;
      private string lV39Wpciudadds_1_filterfulltext ;
      private string lV40Wpciudadds_2_tfciudaddescripcion ;
      private string A5CiudadDescripcion ;
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
      private string[] P002E2_A5CiudadDescripcion ;
      private int[] P002E2_A1EstadoID ;
      private bool[] P002E2_A6CiudadActivo ;
      private int[] P002E2_A4CiudadID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpciudadgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002E2( IGxContext context ,
                                             string AV39Wpciudadds_1_filterfulltext ,
                                             string AV41Wpciudadds_3_tfciudaddescripcion_sel ,
                                             string AV40Wpciudadds_2_tfciudaddescripcion ,
                                             short AV42Wpciudadds_4_tfciudadactivo_sel ,
                                             string A5CiudadDescripcion ,
                                             bool A6CiudadActivo ,
                                             int A1EstadoID ,
                                             int AV36EstadoID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT `CiudadDescripcion`, `EstadoID`, `CiudadActivo`, `CiudadID` FROM `Ciudad`";
         AddWhere(sWhereString, "(`EstadoID` = @AV36EstadoID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Wpciudadds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( `CiudadDescripcion` like CONCAT('%', @lV39Wpciudadds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41Wpciudadds_3_tfciudaddescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Wpciudadds_2_tfciudaddescripcion)) ) )
         {
            AddWhere(sWhereString, "(`CiudadDescripcion` like @lV40Wpciudadds_2_tfciudaddescripcion)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Wpciudadds_3_tfciudaddescripcion_sel)) && ! ( StringUtil.StrCmp(AV41Wpciudadds_3_tfciudaddescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`CiudadDescripcion` = @AV41Wpciudadds_3_tfciudaddescripcion_sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV41Wpciudadds_3_tfciudaddescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`CiudadDescripcion`))=0))");
         }
         if ( AV42Wpciudadds_4_tfciudadactivo_sel == 1 )
         {
            AddWhere(sWhereString, "(`CiudadActivo` = 1)");
         }
         if ( AV42Wpciudadds_4_tfciudadactivo_sel == 2 )
         {
            AddWhere(sWhereString, "(`CiudadActivo` = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `CiudadDescripcion`";
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
                     return conditional_P002E2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] );
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
          Object[] prmP002E2;
          prmP002E2 = new Object[] {
          new ParDef("@AV36EstadoID",GXType.Int32,9,0) ,
          new ParDef("@lV39Wpciudadds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV40Wpciudadds_2_tfciudaddescripcion",GXType.Char,80,0) ,
          new ParDef("@AV41Wpciudadds_3_tfciudaddescripcion_sel",GXType.Char,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002E2,100, GxCacheFrequency.OFF ,true,false )
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
