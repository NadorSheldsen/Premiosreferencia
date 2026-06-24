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
   public class wppaisgetfilterdata : GXProcedure
   {
      public wppaisgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wppaisgetfilterdata( IGxContext context )
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
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV36OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV18MaxItems = 10;
         AV17PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV32SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV15SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? "" : StringUtil.Substring( AV32SearchTxtParms, 3, -1));
         AV16SkipItems = (short)(AV17PageIndex*AV18MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_PAISDESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADPAISDESCRIPCIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV34OptionsJson = AV21Options.ToJSonString(false);
         AV35OptionsDescJson = AV23OptionsDesc.ToJSonString(false);
         AV36OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get("WPPaisGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPPaisGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("WPPaisGridState"), null, "", "");
         }
         AV38GXV1 = 1;
         while ( AV38GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV38GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPAISDESCRIPCION") == 0 )
            {
               AV12TFPaisDescripcion = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPAISDESCRIPCION_SEL") == 0 )
            {
               AV13TFPaisDescripcion_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPAISACTIVO_SEL") == 0 )
            {
               AV14TFPaisActivo_Sel = (short)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV38GXV1 = (int)(AV38GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPAISDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV12TFPaisDescripcion = AV15SearchTxt;
         AV13TFPaisDescripcion_Sel = "";
         AV40Wppaisds_1_filterfulltext = AV37FilterFullText;
         AV41Wppaisds_2_tfpaisdescripcion = AV12TFPaisDescripcion;
         AV42Wppaisds_3_tfpaisdescripcion_sel = AV13TFPaisDescripcion_Sel;
         AV43Wppaisds_4_tfpaisactivo_sel = AV14TFPaisActivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV40Wppaisds_1_filterfulltext ,
                                              AV42Wppaisds_3_tfpaisdescripcion_sel ,
                                              AV41Wppaisds_2_tfpaisdescripcion ,
                                              AV43Wppaisds_4_tfpaisactivo_sel ,
                                              A17PaisDescripcion ,
                                              A18PaisActivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV40Wppaisds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Wppaisds_1_filterfulltext), "%", "");
         lV41Wppaisds_2_tfpaisdescripcion = StringUtil.Concat( StringUtil.RTrim( AV41Wppaisds_2_tfpaisdescripcion), "%", "");
         /* Using cursor P00282 */
         pr_default.execute(0, new Object[] {lV40Wppaisds_1_filterfulltext, lV41Wppaisds_2_tfpaisdescripcion, AV42Wppaisds_3_tfpaisdescripcion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK282 = false;
            A17PaisDescripcion = P00282_A17PaisDescripcion[0];
            A18PaisActivo = P00282_A18PaisActivo[0];
            A16PaisID = P00282_A16PaisID[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00282_A17PaisDescripcion[0], A17PaisDescripcion) == 0 ) )
            {
               BRK282 = false;
               A16PaisID = P00282_A16PaisID[0];
               AV25count = (long)(AV25count+1);
               BRK282 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A17PaisDescripcion)) ? "<#Empty#>" : A17PaisDescripcion);
               AV21Options.Add(AV20Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRK282 )
            {
               BRK282 = true;
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
         AV34OptionsJson = "";
         AV35OptionsDescJson = "";
         AV36OptionIndexesJson = "";
         AV21Options = new GxSimpleCollection<string>();
         AV23OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV15SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV26Session = context.GetSession();
         AV28GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV29GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV37FilterFullText = "";
         AV12TFPaisDescripcion = "";
         AV13TFPaisDescripcion_Sel = "";
         AV40Wppaisds_1_filterfulltext = "";
         AV41Wppaisds_2_tfpaisdescripcion = "";
         AV42Wppaisds_3_tfpaisdescripcion_sel = "";
         lV40Wppaisds_1_filterfulltext = "";
         lV41Wppaisds_2_tfpaisdescripcion = "";
         A17PaisDescripcion = "";
         P00282_A17PaisDescripcion = new string[] {""} ;
         P00282_A18PaisActivo = new bool[] {false} ;
         P00282_A16PaisID = new int[1] ;
         AV20Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wppaisgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00282_A17PaisDescripcion, P00282_A18PaisActivo, P00282_A16PaisID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private short AV14TFPaisActivo_Sel ;
      private short AV43Wppaisds_4_tfpaisactivo_sel ;
      private int AV38GXV1 ;
      private int A16PaisID ;
      private long AV25count ;
      private bool returnInSub ;
      private bool A18PaisActivo ;
      private bool BRK282 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV12TFPaisDescripcion ;
      private string AV13TFPaisDescripcion_Sel ;
      private string AV40Wppaisds_1_filterfulltext ;
      private string AV41Wppaisds_2_tfpaisdescripcion ;
      private string AV42Wppaisds_3_tfpaisdescripcion_sel ;
      private string lV40Wppaisds_1_filterfulltext ;
      private string lV41Wppaisds_2_tfpaisdescripcion ;
      private string A17PaisDescripcion ;
      private string AV20Option ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV28GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00282_A17PaisDescripcion ;
      private bool[] P00282_A18PaisActivo ;
      private int[] P00282_A16PaisID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wppaisgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00282( IGxContext context ,
                                             string AV40Wppaisds_1_filterfulltext ,
                                             string AV42Wppaisds_3_tfpaisdescripcion_sel ,
                                             string AV41Wppaisds_2_tfpaisdescripcion ,
                                             short AV43Wppaisds_4_tfpaisactivo_sel ,
                                             string A17PaisDescripcion ,
                                             bool A18PaisActivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT `PaisDescripcion`, `PaisActivo`, `PaisID` FROM `Pais`";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Wppaisds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( `PaisDescripcion` like CONCAT('%', @lV40Wppaisds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Wppaisds_3_tfpaisdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Wppaisds_2_tfpaisdescripcion)) ) )
         {
            AddWhere(sWhereString, "(`PaisDescripcion` like @lV41Wppaisds_2_tfpaisdescripcion)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Wppaisds_3_tfpaisdescripcion_sel)) && ! ( StringUtil.StrCmp(AV42Wppaisds_3_tfpaisdescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(`PaisDescripcion` = @AV42Wppaisds_3_tfpaisdescripcion_sel)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV42Wppaisds_3_tfpaisdescripcion_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((LENGTH(TRIM(`PaisDescripcion`))=0))");
         }
         if ( AV43Wppaisds_4_tfpaisactivo_sel == 1 )
         {
            AddWhere(sWhereString, "(`PaisActivo` = 1)");
         }
         if ( AV43Wppaisds_4_tfpaisactivo_sel == 2 )
         {
            AddWhere(sWhereString, "(`PaisActivo` = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY `PaisDescripcion`";
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
                     return conditional_P00282(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] );
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
          Object[] prmP00282;
          prmP00282 = new Object[] {
          new ParDef("@lV40Wppaisds_1_filterfulltext",GXType.Char,100,0) ,
          new ParDef("@lV41Wppaisds_2_tfpaisdescripcion",GXType.Char,80,0) ,
          new ParDef("@AV42Wppaisds_3_tfpaisdescripcion_sel",GXType.Char,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00282", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00282,100, GxCacheFrequency.OFF ,true,false )
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
