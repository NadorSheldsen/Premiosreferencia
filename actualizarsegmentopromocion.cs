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
   public class actualizarsegmentopromocion : GXProcedure
   {
      public actualizarsegmentopromocion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public actualizarsegmentopromocion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PromocionID ,
                           GXBaseCollection<SdtSDTSegmentos_Segmento> aP1_SDTSegmentosGuardados )
      {
         this.AV10PromocionID = aP0_PromocionID;
         this.AV13SDTSegmentosGuardados = aP1_SDTSegmentosGuardados;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( int aP0_PromocionID ,
                                 GXBaseCollection<SdtSDTSegmentos_Segmento> aP1_SDTSegmentosGuardados )
      {
         this.AV10PromocionID = aP0_PromocionID;
         this.AV13SDTSegmentosGuardados = aP1_SDTSegmentosGuardados;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P002T2 */
         pr_default.execute(0, new Object[] {AV10PromocionID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A41PromocionID = P002T2_A41PromocionID[0];
            A68PromocionSegmentosJson = P002T2_A68PromocionSegmentosJson[0];
            A68PromocionSegmentosJson = AV13SDTSegmentosGuardados.ToJSonString(false);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            /* Using cursor P002T3 */
            pr_default.execute(1, new Object[] {A68PromocionSegmentosJson, A41PromocionID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Promocion");
            if (true) break;
            /* Using cursor P002T4 */
            pr_default.execute(2, new Object[] {A68PromocionSegmentosJson, A41PromocionID});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("Promocion");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("actualizarsegmentopromocion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P002T2_A41PromocionID = new int[1] ;
         P002T2_A68PromocionSegmentosJson = new string[] {""} ;
         A68PromocionSegmentosJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actualizarsegmentopromocion__default(),
            new Object[][] {
                new Object[] {
               P002T2_A41PromocionID, P002T2_A68PromocionSegmentosJson
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV10PromocionID ;
      private int A41PromocionID ;
      private string A68PromocionSegmentosJson ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTSegmentos_Segmento> AV13SDTSegmentosGuardados ;
      private IDataStoreProvider pr_default ;
      private int[] P002T2_A41PromocionID ;
      private string[] P002T2_A68PromocionSegmentosJson ;
   }

   public class actualizarsegmentopromocion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002T2;
          prmP002T2 = new Object[] {
          new ParDef("@AV10PromocionID",GXType.Int32,9,0)
          };
          Object[] prmP002T3;
          prmP002T3 = new Object[] {
          new ParDef("@PromocionSegmentosJson",GXType.Char,2097152,0) ,
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          Object[] prmP002T4;
          prmP002T4 = new Object[] {
          new ParDef("@PromocionSegmentosJson",GXType.Char,2097152,0) ,
          new ParDef("@PromocionID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002T2", "SELECT `PromocionID`, `PromocionSegmentosJson` FROM `Promocion` WHERE `PromocionID` = @AV10PromocionID ORDER BY `PromocionID`  LIMIT 1 FOR UPDATE ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002T2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P002T3", "UPDATE `Promocion` SET `PromocionSegmentosJson`=@PromocionSegmentosJson  WHERE `PromocionID` = @PromocionID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002T3)
             ,new CursorDef("P002T4", "UPDATE `Promocion` SET `PromocionSegmentosJson`=@PromocionSegmentosJson  WHERE `PromocionID` = @PromocionID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002T4)
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                return;
       }
    }

 }

}
