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
   public class wpfacturawizardloaddvcombo : GXProcedure
   {
      public wpfacturawizardloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpfacturawizardloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           int aP1_Cond_SelecPromo_PromocionID ,
                           string aP2_SearchTxtParms ,
                           out string aP3_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV20Cond_SelecPromo_PromocionID = aP1_Cond_SelecPromo_PromocionID;
         this.AV17SearchTxtParms = aP2_SearchTxtParms;
         this.AV18Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_Combo_DataJson=this.AV18Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                int aP1_Cond_SelecPromo_PromocionID ,
                                string aP2_SearchTxtParms )
      {
         execute(aP0_ComboName, aP1_Cond_SelecPromo_PromocionID, aP2_SearchTxtParms, out aP3_Combo_DataJson);
         return AV18Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 int aP1_Cond_SelecPromo_PromocionID ,
                                 string aP2_SearchTxtParms ,
                                 out string aP3_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV20Cond_SelecPromo_PromocionID = aP1_Cond_SelecPromo_PromocionID;
         this.AV17SearchTxtParms = aP2_SearchTxtParms;
         this.AV18Combo_DataJson = "" ;
         SubmitImpl();
         aP3_Combo_DataJson=this.AV18Combo_DataJson;
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
         if ( StringUtil.StrCmp(AV16ComboName, "WPFacturaWizardSelecPromo_ModeloID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_WPFACTURAWIZARDSELECPROMO_MODELOID' */
            S111 ();
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
         /* 'LOADCOMBOITEMS_WPFACTURAWIZARDSELECPROMO_MODELOID' Routine */
         returnInSub = false;
         GXPagingFrom2 = AV11SkipItems;
         GXPagingTo2 = ((AV10MaxItems>0) ? AV10MaxItems : 100000000);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV13SearchTxt ,
                                              A23ModeloDescripcion ,
                                              A41PromocionID ,
                                              AV20Cond_SelecPromo_PromocionID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
         /* Using cursor P002U2 */
         pr_default.execute(0, new Object[] {AV20Cond_SelecPromo_PromocionID, lV13SearchTxt, GXPagingFrom2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A41PromocionID = P002U2_A41PromocionID[0];
            A23ModeloDescripcion = P002U2_A23ModeloDescripcion[0];
            A22ModeloID = P002U2_A22ModeloID[0];
            A48PromocionModeloID = P002U2_A48PromocionModeloID[0];
            A23ModeloDescripcion = P002U2_A23ModeloDescripcion[0];
            AV15Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A22ModeloID), 9, 0));
            AV15Combo_DataItem.gxTpr_Title = A23ModeloDescripcion;
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
         A23ModeloDescripcion = "";
         P002U2_A41PromocionID = new int[1] ;
         P002U2_A23ModeloDescripcion = new string[] {""} ;
         P002U2_A22ModeloID = new int[1] ;
         P002U2_A48PromocionModeloID = new int[1] ;
         AV15Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpfacturawizardloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P002U2_A41PromocionID, P002U2_A23ModeloDescripcion, P002U2_A22ModeloID, P002U2_A48PromocionModeloID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private int AV20Cond_SelecPromo_PromocionID ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A41PromocionID ;
      private int A22ModeloID ;
      private int A48PromocionModeloID ;
      private bool returnInSub ;
      private string AV18Combo_DataJson ;
      private string AV16ComboName ;
      private string AV17SearchTxtParms ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private string A23ModeloDescripcion ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private int[] P002U2_A41PromocionID ;
      private string[] P002U2_A23ModeloDescripcion ;
      private int[] P002U2_A22ModeloID ;
      private int[] P002U2_A48PromocionModeloID ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private string aP3_Combo_DataJson ;
   }

   public class wpfacturawizardloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002U2( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A23ModeloDescripcion ,
                                             int A41PromocionID ,
                                             int AV20Cond_SelecPromo_PromocionID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.`PromocionID`, T2.`ModeloDescripcion`, T1.`ModeloID`, T1.`PromocionModeloID`";
         sFromString = " FROM (`PromocionModelo` T1 INNER JOIN `Modelo` T2 ON T2.`ModeloID` = T1.`ModeloID`)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.`PromocionID` = @AV20Cond_SelecPromo_PromocionID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(T2.`ModeloDescripcion` like CONCAT('%', @lV13SearchTxt))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         sOrderString += " ORDER BY T2.`ModeloDescripcion`";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " LIMIT " + "@GXPagingFrom2" + ", " + "@GXPagingTo2";
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
                     return conditional_P002U2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] );
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
          Object[] prmP002U2;
          prmP002U2 = new Object[] {
          new ParDef("@AV20Cond_SelecPromo_PromocionID",GXType.Int32,9,0) ,
          new ParDef("@lV13SearchTxt",GXType.Char,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002U2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
