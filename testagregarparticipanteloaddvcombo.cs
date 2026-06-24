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
   public class testagregarparticipanteloaddvcombo : GXProcedure
   {
      public testagregarparticipanteloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public testagregarparticipanteloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           int aP1_Cond_PaisID ,
                           int aP2_Cond_EstadoID ,
                           string aP3_SearchTxtParms ,
                           out string aP4_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV20Cond_PaisID = aP1_Cond_PaisID;
         this.AV21Cond_EstadoID = aP2_Cond_EstadoID;
         this.AV17SearchTxtParms = aP3_SearchTxtParms;
         this.AV18Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP4_Combo_DataJson=this.AV18Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                int aP1_Cond_PaisID ,
                                int aP2_Cond_EstadoID ,
                                string aP3_SearchTxtParms )
      {
         execute(aP0_ComboName, aP1_Cond_PaisID, aP2_Cond_EstadoID, aP3_SearchTxtParms, out aP4_Combo_DataJson);
         return AV18Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 int aP1_Cond_PaisID ,
                                 int aP2_Cond_EstadoID ,
                                 string aP3_SearchTxtParms ,
                                 out string aP4_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV20Cond_PaisID = aP1_Cond_PaisID;
         this.AV21Cond_EstadoID = aP2_Cond_EstadoID;
         this.AV17SearchTxtParms = aP3_SearchTxtParms;
         this.AV18Combo_DataJson = "" ;
         SubmitImpl();
         aP4_Combo_DataJson=this.AV18Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10MaxItems = 10;
         AV12PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV17SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV17SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV13SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV17SearchTxtParms)) ? "" : StringUtil.Substring( AV17SearchTxtParms, 3, -1));
         AV11SkipItems = (short)(AV12PageIndex*AV10MaxItems);
         if ( StringUtil.StrCmp(AV16ComboName, "EstadoID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_ESTADOID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "Usuario_CiudadID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_USUARIO_CIUDADID' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_ESTADOID' Routine */
         returnInSub = false;
         GXPagingFrom2 = AV11SkipItems;
         GXPagingTo2 = ((AV10MaxItems>0) ? AV10MaxItems : 100000000);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV13SearchTxt ,
                                              A2EstadoDescripcion ,
                                              A16PaisID ,
                                              AV20Cond_PaisID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
         /* Using cursor P003R2 */
         pr_default.execute(0, new Object[] {AV20Cond_PaisID, lV13SearchTxt, GXPagingFrom2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2EstadoDescripcion = P003R2_A2EstadoDescripcion[0];
            A16PaisID = P003R2_A16PaisID[0];
            A1EstadoID = P003R2_A1EstadoID[0];
            AV15Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A1EstadoID), 9, 0));
            AV15Combo_DataItem.gxTpr_Title = A2EstadoDescripcion;
            AV14Combo_Data.Add(AV15Combo_DataItem, 0);
            if ( AV14Combo_Data.Count > AV10MaxItems )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV18Combo_DataJson = AV14Combo_Data.ToJSonString(false);
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_USUARIO_CIUDADID' Routine */
         returnInSub = false;
         GXPagingFrom3 = AV11SkipItems;
         GXPagingTo3 = ((AV10MaxItems>0) ? AV10MaxItems : 100000000);
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV13SearchTxt ,
                                              A5CiudadDescripcion ,
                                              A1EstadoID ,
                                              AV21Cond_EstadoID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
         /* Using cursor P003R3 */
         pr_default.execute(1, new Object[] {AV21Cond_EstadoID, lV13SearchTxt, GXPagingFrom3, GXPagingTo3});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A5CiudadDescripcion = P003R3_A5CiudadDescripcion[0];
            A1EstadoID = P003R3_A1EstadoID[0];
            A4CiudadID = P003R3_A4CiudadID[0];
            AV15Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A4CiudadID), 9, 0));
            AV15Combo_DataItem.gxTpr_Title = A5CiudadDescripcion;
            AV14Combo_Data.Add(AV15Combo_DataItem, 0);
            if ( AV14Combo_Data.Count > AV10MaxItems )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV18Combo_DataJson = AV14Combo_Data.ToJSonString(false);
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
         AV18Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13SearchTxt = "";
         lV13SearchTxt = "";
         A2EstadoDescripcion = "";
         P003R2_A2EstadoDescripcion = new string[] {""} ;
         P003R2_A16PaisID = new int[1] ;
         P003R2_A1EstadoID = new int[1] ;
         AV15Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A5CiudadDescripcion = "";
         P003R3_A5CiudadDescripcion = new string[] {""} ;
         P003R3_A1EstadoID = new int[1] ;
         P003R3_A4CiudadID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.testagregarparticipanteloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P003R2_A2EstadoDescripcion, P003R2_A16PaisID, P003R2_A1EstadoID
               }
               , new Object[] {
               P003R3_A5CiudadDescripcion, P003R3_A1EstadoID, P003R3_A4CiudadID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private int AV20Cond_PaisID ;
      private int AV21Cond_EstadoID ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A16PaisID ;
      private int A1EstadoID ;
      private int GXPagingFrom3 ;
      private int GXPagingTo3 ;
      private int A4CiudadID ;
      private bool returnInSub ;
      private string AV18Combo_DataJson ;
      private string AV16ComboName ;
      private string AV17SearchTxtParms ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private string A2EstadoDescripcion ;
      private string A5CiudadDescripcion ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P003R2_A2EstadoDescripcion ;
      private int[] P003R2_A16PaisID ;
      private int[] P003R2_A1EstadoID ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private string[] P003R3_A5CiudadDescripcion ;
      private int[] P003R3_A1EstadoID ;
      private int[] P003R3_A4CiudadID ;
      private string aP4_Combo_DataJson ;
   }

   public class testagregarparticipanteloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003R2( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A2EstadoDescripcion ,
                                             int A16PaisID ,
                                             int AV20Cond_PaisID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " `EstadoDescripcion`, `PaisID`, `EstadoID`";
         sFromString = " FROM `Estado`";
         sOrderString = "";
         AddWhere(sWhereString, "(`PaisID` = @AV20Cond_PaisID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(`EstadoDescripcion` like CONCAT('%', @lV13SearchTxt))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         sOrderString += " ORDER BY `EstadoDescripcion`";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " LIMIT " + "@GXPagingFrom2" + ", " + "@GXPagingTo2";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P003R3( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A5CiudadDescripcion ,
                                             int A1EstadoID ,
                                             int AV21Cond_EstadoID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " `CiudadDescripcion`, `EstadoID`, `CiudadID`";
         sFromString = " FROM `Ciudad`";
         sOrderString = "";
         AddWhere(sWhereString, "(`EstadoID` = @AV21Cond_EstadoID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(`CiudadDescripcion` like CONCAT('%', @lV13SearchTxt))");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         sOrderString += " ORDER BY `CiudadDescripcion`";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " LIMIT " + "@GXPagingFrom3" + ", " + "@GXPagingTo3";
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
                     return conditional_P003R2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] );
               case 1 :
                     return conditional_P003R3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] );
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
          Object[] prmP003R2;
          prmP003R2 = new Object[] {
          new ParDef("@AV20Cond_PaisID",GXType.Int32,9,0) ,
          new ParDef("@lV13SearchTxt",GXType.Char,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP003R3;
          prmP003R3 = new Object[] {
          new ParDef("@AV21Cond_EstadoID",GXType.Int32,9,0) ,
          new ParDef("@lV13SearchTxt",GXType.Char,40,0) ,
          new ParDef("@GXPagingFrom3",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo3",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003R2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P003R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003R3,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
